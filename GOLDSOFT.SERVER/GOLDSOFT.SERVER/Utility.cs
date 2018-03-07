using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Management;
using System.Net;
using System.Collections;
using System.Runtime.InteropServices;

namespace GOLDSOFT.SERVER
{
    internal class Utility
    {
        internal static DogInfo dogInfo;
 
        public static void Init()
        {
            //Console.WriteLine("开始读取加密狗信息...");
            if (!ReadDogInfo())
                return;
            if (dogInfo == null) return;
            //Console.WriteLine("加密狗信息读取成功!");

            //Console.WriteLine("开始启动清单计价2013网络版服务端...");
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = null;
            OperatingSystem os = Environment.OSVersion;
            int port = 1086;//端口
            int capacity = 10;//最大链接数量

            if (os.Version.Major == 6) //win7
                ipa = ipe.AddressList[1];
            else
                ipa = ipe.AddressList[0];

            TcpListener listener = new TcpListener(IPAddress.Parse(ipa.ToString()), port);

            listener.Start();
            //Console.WriteLine("清单计价2013网络版服务端启动成功!");

            //Console.WriteLine("mac地址是 " + GetNetCardMacAddress());

            //Console.WriteLine("硬盘序号是 " + GetDiskVolumeSerialNumber());


            Hashtable map = new Hashtable();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream ns = client.GetStream();

                string remoteIp = GetRemoteIP(client);
                if (map.Count >= capacity)
                {
                    //Console.WriteLine("服务器连接数已满，不能处理客户端 " + remoteIp + "的请求。服务器最大支持 " + capacity + " 个客户端！");
                    ns.Write(Encoding.UTF8.GetBytes("-1"), 0, 2);
                    ns.Close();
                    client.Close();
                    continue;
                }

                if (!map.Contains(remoteIp))
                {
                    map.Add(remoteIp, "");
                }


                byte[] info = Encoding.UTF8.GetBytes(dogInfo.Information);

                try
                {
                    ns.Write(info, 0, info.Length);
                    ns.Close();
                    client.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("向客户端 " + remoteIp + " 发送数据时发生错误: " + ex.Message);
                    ns.Close();
                    client.Close();
                }
            }
        }


        internal static bool ReadDogInfo()
        {
            dogInfo = new DogInfo();
            int result = dogInfo.getDogInfo();
            if (result != 0)
            {
                //Console.WriteLine("读取加密狗失败！");
                return false;
            }

            return true;
        }

        static Socket GetSocket(TcpClient cln)
        {
            return cln.Client;
        }

        static string GetRemoteIP(TcpClient cln)
        {
            string ip = GetSocket(cln).RemoteEndPoint.ToString().Split(':')[0];
            return ip;
        }

        static int GetRemotePort(TcpClient cln)
        {
            string temp = GetSocket(cln).RemoteEndPoint.ToString().Split(':')[1];
            int port = Convert.ToInt32(temp);
            return port;
        }


        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetNetCardMacAddress()
        {
            ManagementClass mc;
            ManagementObjectCollection moc;
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            moc = mc.GetInstances();
            string str = "";
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                    str = mo["MacAddress"].ToString();

            }
            return str;
        }

        /// <summary>
        /// C盘序列号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementObject disk;
            disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }


        [DllImport("DiskID32.dll")]
        public static extern long DiskID32(ref byte DiskModel, ref byte DiskID);

        public static string GetDiskID()
        {

            byte[] DiskModel = new byte[31];
            byte[] DiskID = new byte[31];
            int i;
            string Model = "";
            string ID = "";

            if (DiskID32(ref DiskModel[0], ref DiskID[0]) != 1)
            {

                for (i = 0; i < 31; i++)
                {

                    if (Convert.ToChar(DiskID[i]) != Convert.ToChar(0))
                    {
                        ID = ID + Convert.ToChar(DiskID[i]);
                    }
                }
                ID = ID.Trim();
            }
            else
            {
                Console.WriteLine("获取硬盘序列号出错");
            }
            return ID;
        }


    }
}
