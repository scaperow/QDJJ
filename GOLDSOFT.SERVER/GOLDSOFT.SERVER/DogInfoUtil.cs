using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJSOFT.LIVING;

namespace GOLDSOFT.SERVER
{
    public class DogInfo
    {
        private  int LIV_APP_CODE = 0x53584a4a;

        public  bool IsUseHandle;

        public  bool IsChangeHandle;

        public bool IsOwenr;

        public  bool IsPassValie;

        public bool IsReadHeandle;


        private JJSOFT.LIVING.LivingDog.LIV_hardware_info m_CurrLivInfo;
        /// <summary>
        /// 当前硬件信息
        /// </summary>
        private JJSOFT.LIVING.LivingDog.LIV_hardware_info CurrLivInfo
        {
            set
            {
                m_CurrLivInfo = value;
                CurrNo = System.Text.ASCIIEncoding.ASCII.GetString(value.serialNumber);
                if (CurrNo.Trim('\0') != string.Empty) { this.IsUseHandle = true; }
                else { this.IsUseHandle = false; }
                //第一次
                if (this.PreNo != null)
                {
                    //不相同的说明更换了加密狗
                    if (PreNo != CurrNo)
                    {
                        if (this.IsUseHandle)
                        {

                            PreNo = CurrNo;

                            this.IsChangeHandle = true;
                            //OnChangeHardWare(this, value);
                        }
                    }
                    else
                    {
                        this.IsChangeHandle = false;
                    }
                }
                else { PreNo = CurrNo; this.IsChangeHandle = true; }

                // PreNo = 
            }
            get
            {
                return m_CurrLivInfo;
            }
        }

        public string Information
        {
            get { return string.Format("{0},{1},{2},{3},{4},{5}", this.Fun, this.State, this.UseCount, this.DateCount, this.Time, this.CurrNo); }
        }


        /// <summary>
        /// 上次硬件信息
        /// </summary>
        private string PreNo = null;
        /// <summary>
        /// 当前号
        /// </summary>
        public string CurrNo = null;


        public long Fun = 0;
        public string State = string.Empty;
        public long UseCount = 0;
        public long DateCount = 0;
        public long Time = 0;

        bool ispass = false;

        public bool IsLoginSucess
        {
            get
            {
                return IsOwenr && IsPassValie && IsReadHeandle;
            }
        }

        public  int getDogInfo()
        {
            LivingDog m_LivingDog = new LivingDog();
            try
            {
                m_LivingDog.Grand_OpenDog(LIV_APP_CODE, 0);
                CurrLivInfo = m_LivingDog.Grand_GetHardware_info();
                //密码验证
                if(CurrLivInfo.RetCode == 0)
                {
                    //判断加密狗的合法性 (密码验证+数据验证)
                    if (!ispass)
                    {
                        ispass = CanPassValie(m_LivingDog);
                    }
                    if (ispass)
                    {
                        IsOwenr = true;
                        IsPassValie = true;
                        this.ReadHandle(m_LivingDog);
                        return 0;
                    }
                    else
                    {
                        IsOwenr = false;
                        IsReadHeandle = false;
                        return 3;//功能不存在
                    }
                }
                else
                {
                    this.IsPassValie = false;
                    this.IsOwenr = false;
                    this.IsReadHeandle = false;
                    return -1;
                }
            }
            catch
            {
                IsOwenr = false;
                return -1;
            }
            finally
            {
                m_LivingDog.Grand_CloseDog();
            }
        }

        /// <summary>
        /// 功能 以及 合法性验证 
        /// </summary>
        /// <param name="p_dog"></param>
        /// <returns></returns>
        public  void ReadHandle(LivingDog p_dog)
        {
            int Result = p_dog.Grand_Passwd(0, "20JJSoft13");

            if (Result == 0)
            {
                byte[] outByte = new byte[512];
                //读取加密狗的数据
                if (p_dog.Grand_Read(2, outByte) == LivingDog.LIV_SUCCESS)
                {
                    string str = System.Text.ASCIIEncoding.Default.GetString(outByte).Trim('\0');
                    int index = str.IndexOf("\0");
                    if (index > 0)
                        str = str.Substring(0, index);
                    if (!IsEmptyHandle(str))
                    {
                        //读取数据
                        string[] data = str.Split(',');
                        this.Read(data);
                        this.IsReadHeandle = true;
                    }
                    else
                    {
                        //数据读取失败
                        this.IsReadHeandle = false;
                    }
                }
            }
        }

        private void Read(string[] data)
        {
            this.Fun = long.Parse(data[0]);
            this.State = data[1].ToString();
            this.UseCount = long.Parse(data[2]);
            this.DateCount = long.Parse(data[3]);
            this.Time = long.Parse(data[4]);
        }


        /// <summary>
        /// 判断是否空数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsEmptyHandle(string str)
        {
            if (str == string.Empty) return true;
            //必须满足4个基本数据
            string[] data = str.Split(',');
            if (data.Length == 5) return false;
            return true;
        }


        bool CanPassValie(LivingDog p_dog)
        {
            //1.密码验证
            //2.合法性验证
            //string pwd = "09JJSoft12";
            string pwd = "20JJSoft13";
            if (p_dog.Grand_Passwd(1, pwd) == LivingDog.LIV_SUCCESS)
            {
                //功能验证 读取加密狗数据
                byte[] outByte = new byte[50];
                if (p_dog.Grand_Read(1, outByte) == LivingDog.LIV_SUCCESS)
                {
                    string strs = System.Text.ASCIIEncoding.Default.GetString(outByte).Trim('\0');

                    if (strs[3] == '1') //加密狗有效性验证
                    {
                        //合法加密狗
                        this.IsPassValie = true;
                        return true;
                    }
                    else
                    {
                        //非法加密狗
                        this.IsPassValie = false;
                        return false;
                    }

                }

                return true;
            }
            return false;
        }
    }
}
