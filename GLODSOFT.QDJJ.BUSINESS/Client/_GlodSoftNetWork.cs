/*
 金建网络应用程序
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Net;
using GSoft.Communications;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

using ZiboSoft.Commons.Common;
using GoldSoft.QD_api;
namespace GOLDSOFT.QDJJ.UI.Client
{
    /// <summary>
    /// 金建软件网络验证应用程序
    /// </summary>
    public class _GlodSoftNetWork
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        //public const string Address = "192.168.1.115";
        public const string Address = "117.34.66.251";
         /// <summary>
        /// 操作成功
        /// </summary>
        public const int TRY_SUCCESS = 0;
        /// <summary>
        /// 无法连接互联网
        /// </summary>
        public const int TRY_NOTINTENT = 1;
        /// <summary>
        /// ping不通指定地址
        /// </summary>
        public const int TRY_NOTPING = 2;
        /// <summary>
        /// 当前服务没有开启
        /// </summary>
        public const int TRY_SERVER_ERROR = 3;

        /// <summary>
        /// IIS端口主机关闭
        /// </summary>
        public const int TRY_SERVER_DOWN = 4;
        /// <summary>
        /// 金建客户端应用程序
        /// </summary>
        public GoldSoftClient Parent = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_Parent"></param>
        public _GlodSoftNetWork(GoldSoftClient p_Parent)
        {
            Parent = p_Parent;
        }


        /// <summary>
        /// 申请一次网络信息验证
        /// </summary>
        public int Completed()
        {
            //检查网络是否可用
            int iNetStatus = MyInternetCon(Address);

           switch (iNetStatus)
           {
               case 3://网络状态ok
               case 2://网络状态ok
                   //TryCommunication();
                   this.Parent.ClientResult.IsUseNet = true;
                   return _GlodSoftNetWork.TRY_SUCCESS;
               case 1:
                   this.Parent.ClientResult.IsUseNet = false;
                   return _GlodSoftNetWork.TRY_NOTINTENT;
               case 4://ping不通
               case 5://ping不通
                   this.Parent.ClientResult.IsUseNet = false;
                   return _GlodSoftNetWork.TRY_NOTPING;
           }
           
            //开始通信

            //获取通信数据
            return iNetStatus;
        }

        

        

        #region ----------------------------------网络测试---------------------------------
        /// <summary>
        /// 开始网络连接连接测试
        /// </summary>
        private int MyInternetCon(string p_Address)
        {
            return GetInternetConStatus.GetNetConStatus(p_Address);
            
            /*if (iNetStatus == 1)
            {
                //lblNetStatus.Text = "网络未连接";
            }
            else if (iNetStatus == 2)
            {
                //lblNetStatus.Text = "采用调治解调器上网";
            }
            else if (iNetStatus == 3)
            {
                //lblNetStatus.Text = "采用网卡上网";
            }
            else if (iNetStatus == 4)
            {
                //lblNetStatus.Text = "采用调治解调器上网,但是联不通指定网络";
            }
            else if (iNetStatus == 5)
            {
                //lblNetStatus.Text = "采用网卡上网,但是联不通指定网络";
            }*/
        }

        #endregion

    }


    public class GetInternetConStatus
    {
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(
        ref   int dwFlag,
        int dwReserved
        );

        /// <summary>
        /// 判断网络的连接状态
        /// </summary>
        /// <returns>
        /// 网络状态(1-->未联网;2-->采用调治解调器上网;3-->采用网卡上网)
        ///</returns>
        public static int GetNetConStatus(string strNetAddress)
        {
            int iNetStatus = 0;
            System.Int32 dwFlag = new int();
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {  
                //没有能连上互联网
                iNetStatus = 1;
            }
            else if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
            {
                //采用调治解调器上网,需要进一步判断能否登录具体网站
                if (PingNetAddress(strNetAddress))
                {
                    //可以ping通给定的网址,网络OK
                    iNetStatus = 2;
                }
                else
                {
                    //不可以ping通给定的网址,网络不OK
                    iNetStatus = 4;
                }
            }
            
            else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
            {
                //采用网卡上网,需要进一步判断能否登录具体网站
                if (PingNetAddress(strNetAddress))
                {
                    //可以ping通给定的网址,网络OK
                    iNetStatus = 3;
                }
                else
                {
                    //不可以ping通给定的网址,网络不OK
                    iNetStatus = 5;
                }
            }

            return iNetStatus;
        }

        /// <summary>
        /// ping 具体的网址看能否ping通
        /// </summary>
        /// <param name="strNetAdd"></param>
        /// <returns></returns>
        private static bool PingNetAddress(string strNetAdd)
        {
            bool Flage = false;
            Ping ping = new Ping();
            try
            {
                PingReply pr = ping.Send(strNetAdd, 3000);
                if (pr.Status == IPStatus.TimedOut)
                {
                    Flage = false;
                }
                if (pr.Status == IPStatus.Success)
                {
                    Flage = true;
                }
                else
                {
                    Flage = false;
                }
            }
            catch
            {
                Flage = false;
            }
            return Flage;
        }

    }
}




