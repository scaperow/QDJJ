/*
 加密狗识别对象类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJSOFT.LIVING;
using System.ComponentModel;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace GOLDSOFT.QDJJ.UI.Client
{
    /// <summary>
    /// 委托-硬件验证成功后执行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void HardWareSuccHandler(object sender, int args);
    /// <summary>
    /// 委托-硬件验证成功后执行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void HardWareErrorHandler(object sender, object args);
    /// <summary>
    /// 更换加密狗时候激发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void ChangeHardWareHandler(object sender, object args);
    /// <summary>
    /// 加密狗识别对象
    /// </summary>
    public class _GlodSoftDiscern
    {
        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event HardWareSuccHandler HardWareSucc;
        /// <summary>
        /// 加密狗更换的时候激发
        /// </summary>
        public event ChangeHardWareHandler ChangeHardWare;

        /// <summary>
        /// 硬件每次验证成功后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">0,成功,其他失败</param>
        public void OnHardWareSucc(object sender, int args)
        {
            /*switch (args)
            {
                case _GlodSoftDiscern.TRY_ERROR_OVER:
                    Application.Exit();
                    return;
            }*/

            //成功验证后获取信息
            if (HardWareSucc != null)
            {
                this.HardWareSucc(sender, args);
            }
        }

        /// <summary>
        /// 硬件更换时候激发
        /// </summary>
        public void OnChangeHardWare(object sender, object args)
        {
            //成功验证后获取信息

            if (ChangeHardWare != null)
            {
                this.ChangeHardWare(sender, args);
            }
        }
        /// <summary>
        /// 可尝试次数
        /// </summary>
        public const int TRY_USER_COUNT = 3;
        
        /// <summary>
        /// 操作成功
        /// </summary>
        public const int TRY_SUCCESS = 0;

        /// <summary>
        /// 加密狗验证失败
        /// </summary>
        public const int TRY_ERROR = -1;
        /// <summary>
        /// 失败可重新尝试
        /// </summary>
        public const int TRY_ERROR_AGAIN = 1;
        /// <summary>
        /// 已经结束无法重新尝试
        /// </summary>
        public const int TRY_ERROR_OVER = 2;

        /// <summary>
        /// 功能不存在
        /// </summary>
        public const int TRY_ERROR_NOFUNCTION = 3;

        /// <summary>
        /// 获取已经加密的锁号
        /// </summary>
        public string GetEnNum
        {
            get
            {
                //获取当前加密锁号
                //ZiboSoft.Commons.Common.CEncryption.IV_64 = "huayhy12";
                //ZiboSoft.Commons.Common.CEncryption.KEY_64 = "yhyhua12";
                if (this.CurrNo != string.Empty)
                {

                    return this.CurrNo;
                    //return  ZiboSoft.Commons.Common.CEncryption.Encode(this.CurrNo);
                }
                return string.Empty;
            }
        }

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
                if (CurrNo.Trim('\0') != string.Empty) { this.Parent.ClientResult.IsUseHandle = true; }
                else { this.Parent.ClientResult.IsUseHandle = false; }
                //第一次
                if (this.PreNo != null)
                {
                    //不相同的说明更换了加密狗
                    if (PreNo != CurrNo)
                    {
                        if (this.Parent.ClientResult.IsUseHandle)
                        {

                            PreNo = CurrNo;
                            
                            this.Parent.ClientResult.IsChangeHandle = true;
                            OnChangeHardWare(this, value);
                        }
                    }
                    else
                    {
                        this.Parent.ClientResult.IsChangeHandle = false;
                    }
                }
                else { PreNo = CurrNo; this.Parent.ClientResult.IsChangeHandle = true; }

               // PreNo = 
            }
            get
            {
                return m_CurrLivInfo;
            }
        }
        /// <summary>
        /// 上次硬件信息
        /// </summary>
        private string PreNo = null;
        /// <summary>
        /// 当前号
        /// </summary>
        public string CurrNo = null;
        /// <summary>
        /// 
        /// </summary>
        int LIV_APP_CODE = 0x53584a4a;
        /// <summary>
        /// 尝试记录时间
        /// </summary>
        public int TryTime = 20;//默认20分钟记录一次

        /// <summary>
        /// 尝试记录次数
        /// </summary>
        public int TryCount = 3;

        /// <summary>
        /// 默认当前时间
        /// </summary>
        public long SubmitTime;

        public GoldSoftClient Parent = null;

        public _GlodSoftDiscern(GoldSoftClient p_Parent)
        {
            Parent = p_Parent;
            SetTagTime();
            //this.TryInit();
        }


        /// <summary>
        /// 构造函数构造后自动开启线程处理
        /// </summary>
        public _GlodSoftDiscern()
        {
            SetTagTime();
            //this.TryInit();
        }

        private BackgroundWorker Worker = null;

        /// <summary>
        /// 当Disconnect方法被调用暂时停掉线程
        /// </summary>
        bool IsGoGo = true;

        /// <summary>
        /// 尝试开启验证
        /// </summary>
        public void TryInit()
        {
            if (Worker == null)
            {
                Worker = new BackgroundWorker();
                Worker.WorkerSupportsCancellation = true;
                Worker.WorkerReportsProgress = true;
                Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
                Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            }
            Worker.RunWorkerAsync();
        }

        bool ispass = false;

        /// <summary>
        /// 是否接收提交记录数据
        /// </summary>
        public bool IsAppSubmit
        {
            get
            {
                if (DateTime.Now.Ticks >= this.SubmitTime)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 当前时间+时间间隔 的时间戳
        /// </summary>
        public void SetTagTime()
        {
            this.SubmitTime = DateTime.Now.AddMinutes(20).Ticks;
        }

        /// <summary>
        /// 申请一次加密狗验证(仅验证是否是已经初始化的加密狗)
        /// 附带功能验证
        /// </summary>
        public int Completed()
        {
            LivingDog m_LivingDog = new LivingDog();
            try
            {
                int result = m_LivingDog.Grand_OpenDog(LIV_APP_CODE, 0);
                    
                this.CurrLivInfo = m_LivingDog.Grand_GetHardware_info();
                //密码验证
                switch (this.CurrLivInfo.RetCode)
                {
                    case 0://成功继续做
                        //判断加密狗的合法性 (密码验证+数据验证)
                        if (!ispass)
                        {
                            ispass = IsPassValie(m_LivingDog);
                        }
                        if (ispass)
                        {
                            this.Parent.ClientResult.IsOwenr = true;
                            this.Parent.ClientResult.IsPassValie = true;
                            OnHardWareSucc(this, _GlodSoftDiscern.TRY_SUCCESS);
                            //功能合法验证
                            this.ReadHandle(m_LivingDog);
                            return _GlodSoftDiscern.TRY_SUCCESS;
                        }
                        else
                        {
                            this.Parent.ClientResult.IsOwenr = false;
                            this.Parent.ClientResult.IsReadHeandle = false;
                            OnHardWareSucc(this, _GlodSoftDiscern.TRY_SUCCESS);
                            return _GlodSoftDiscern.TRY_ERROR_NOFUNCTION;
                        }
                    default://其他错误关闭系统
                        this.Parent.ClientResult.IsPassValie = false;
                        this.Parent.ClientResult.IsOwenr = false;
                        this.Parent.ClientResult.IsReadHeandle = false;
                        OnHardWareSucc(this, _GlodSoftDiscern.TRY_ERROR);
                        return _GlodSoftDiscern.TRY_ERROR;
                }
            }
            catch
            {
                this.Parent.ClientResult.IsOwenr = false;
                return _GlodSoftDiscern.TRY_ERROR;
            }
            finally
            {
                m_LivingDog.Grand_CloseDog();
            }
        }

        public int Completed(string ip, int port)
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse(ip), 1086);
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            try
            {

                string buffer = sr.ReadLine();
                string[] data = buffer.Split(',');

                if (data.Length < 6) return 3;

                this.Parent.ClientResult.IsPassValie = true;
                this.Parent.ClientResult.IsOwenr = true;
                this.Parent.ClientResult.IsReadHeandle = true;

                this.Parent.ClientResult.Fun = long.Parse(data[0]);
                this.Parent.ClientResult.State = data[1].ToString();
                this.Parent.ClientResult.UseCount = long.Parse(data[2]);
                this.Parent.ClientResult.DateCount = long.Parse(data[3]);
                this.Parent.ClientResult.Time = long.Parse(data[4]);
                this.CurrNo = data[5];
                this.PreNo = this.CurrNo;

                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ns.Close();
                sr.Close();
                client.Close();
            }
            return 3;
        }


        /// <summary>
        /// 功能 以及 合法性验证 
        /// 
        /// </summary>
        /// <param name="p_dog"></param>
        /// <returns></returns>
        public void ReadHandle(LivingDog p_dog)
        {
            //int Result = p_dog.Grand_Passwd(0, "20JJSoft13");
            int Result = p_dog.Grand_Passwd(0, "09JJSoft12");
            
            if (Result == 0)
            {
                byte[] outByte = new byte[512];
                //读取加密狗的数据
                if (p_dog.Grand_Read(2, outByte) == LivingDog.LIV_SUCCESS)
                {
                    string str = System.Text.ASCIIEncoding.Default.GetString(outByte).Trim('\0');
                    int index =str.IndexOf("\0");
                    if (index>0)
                        str = str.Substring(0, index);
                    if (!this.IsEmptyHandle(str))
                    {
                        //读取数据
                        string[] data = str.Split(',');
                        this.Parent.ClientResult.Read(data);
                        
                    }
                    this.Parent.ClientResult.IsReadHeandle = true;
                    //else
                    //{
                    //    //数据读取失败
                    //    this.Parent.ClientResult.IsReadHeandle = false;
                    //}
                }
            }
        }

        /// <summary>
        /// 写入数据(一次完全操作)
        /// </summary>
        /// <param name="dog"></param>
        /// <returns></returns>
        public int WriteHandle(string p_string)
        {
            LivingDog dog = new LivingDog();
            try
            {
                dog.Grand_OpenDog(LIV_APP_CODE, 0);
                //int Result = dog.Grand_Passwd(0, "20JJSoft13");
                int Result = dog.Grand_Passwd(0, "09JJSoft12");

                byte[] oByte = System.Text.ASCIIEncoding.Default.GetBytes(p_string.ToString().Trim());
                //
                if (dog.Grand_Write(2, oByte) == LivingDog.LIV_SUCCESS)
                {
                    return _GlodSoftDiscern.TRY_SUCCESS;
                }
                return _GlodSoftDiscern.TRY_ERROR;
            }
            catch
            {
                return _GlodSoftDiscern.TRY_ERROR;
            }
            finally
            {
                dog.Grand_CloseDog();
            }
        }


        ///// <summary>
        ///// 写入数据(一次完全操作)
        ///// </summary>
        ///// <param name="dog"></param>
        ///// <returns></returns>
        //public int ReReadHandle()
        //{
        //    LivingDog dog = new LivingDog();
        //    try
        //    {
        //        dog.Grand_OpenDog(LIV_APP_CODE, 0);
        //        //int Result = dog.Grand_Passwd(0, "20JJSoft13");
        //        int Result = dog.Grand_Passwd(0, "09JJSoft12");

        //        if (Result == 0)
        //        {
        //            byte[] outByte = new byte[512];
        //            //读取加密狗的数据
        //            if (dog.Grand_Read(2, outByte) == LivingDog.LIV_SUCCESS)
        //            {
        //                string str = System.Text.ASCIIEncoding.Default.GetString(outByte).Trim('\0');
        //                int index = str.IndexOf("\0");
        //                if (index > 0)
        //                    str = str.Substring(0, index);
        //                if (!this.IsEmptyHandle(str))
        //                {
        //                    //读取数据
        //                    string[] data = str.Split(',');
        //                    this.Parent.ClientResult.Read(data);
        //                    this.Parent.ClientResult.IsReadHeandle = true;
        //                }
        //                else
        //                {
        //                    //数据读取失败
        //                    this.Parent.ClientResult.IsReadHeandle = false;
        //                }

        //                return _GlodSoftDiscern.TRY_SUCCESS;
        //            }
        //            return _GlodSoftDiscern.TRY_ERROR;
        //        }
        //    }
        //    catch
        //    {
        //        return _GlodSoftDiscern.TRY_ERROR;
        //    }
        //    finally
        //    {
        //        dog.Grand_CloseDog();
        //    }
        //    return _GlodSoftDiscern.TRY_ERROR;
        //}


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
            if (data.Length >= 5) return false;
            return true;
        }

        

        /// <summary>
        /// 方法调用前保证加密狗已经成功打开（进验证有效性）
        /// </summary>
        /// <returns></returns>
        bool IsPassValie(LivingDog p_dog)
        {
            //1.密码验证
            //2.合法性验证
            //string pwd = "09JJSoft12";
            string pwd = "JJSoft0912";
            //string pwd = "20JJSoft13";
            if (p_dog.Grand_Passwd(1, pwd) == LivingDog.LIV_SUCCESS)
            {
                //功能验证 读取加密狗数据
                byte[] outByte = new byte[50];
                if (p_dog.Grand_Read(1, outByte) == LivingDog.LIV_SUCCESS)
                {
                    //string strs  = System.Text.ASCIIEncoding.Default.GetString(outByte).Trim('\0');
                    string strs = System.Text.ASCIIEncoding.Default.GetString(outByte);
                    //3.领先版  4是专业版 5是旗舰版 6是网络版
                    if (strs[3] == '1' || strs[4] == '1' || strs[5] == '1' || strs[6] == '1') //加密狗有效性验证
                    {
                        //合法加密狗
                        this.Parent.ClientResult.IsPassValie = true;
                        return true;
                    }
                    else
                    {
                        //非法加密狗
                        this.Parent.ClientResult.IsPassValie = false;
                        return false;
                    }
                    
                }

                return true;
            }
            return false;
        }

        /// <summary>
        ///  加密狗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ///不存在指定应用程序
           
                if (IsGoGo)
                {
                    (sender as BackgroundWorker).RunWorkerAsync();
                }
           

            if (e.Result.Equals(_GlodSoftDiscern.TRY_SUCCESS))
            {
                //当加密狗完成一次验证时候激发
                OnHardWareSucc(this, _GlodSoftDiscern.TRY_SUCCESS);
                if (IsGoGo)
                {
                    (sender as BackgroundWorker).RunWorkerAsync();
                }
            }
            else
            {
                if (IsGoGo)
                {
                    (sender as BackgroundWorker).RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// 加密狗验证线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Worker.CancellationPending)
            {
                e.Cancel = true;
            }

            
                //如果存在应用程序则验证 否则不验证
                e.Result = Completed();
        }

    }
}
