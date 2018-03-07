using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.Management;
using System.IO;

namespace GOLDSOFT.SERVER
{
    public class Server
    {
        private TcpListener listener;
        private Thread listenThread;
        int port = 1086;//端口
        int capacity = 10;//最大链接数量
        public Hashtable map = new Hashtable();
        //public string remoteIP = string.Empty;
        DogInfo dogInfo = null;
        public Server(DogInfo dogInfo)
        {
            this.dogInfo = dogInfo;
        }

        public void start()
        {
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = null;
            OperatingSystem os = Environment.OSVersion;


            if (os.Version.Major == 6) //win7
                ipa = ipe.AddressList[1];
            else
                ipa = ipe.AddressList[0];

            this.listener = new TcpListener(ipa, port);

            this.listenThread = new Thread(new ThreadStart(ListenForClient));
            this.listenThread.Start();
        
        
        }
        private void EndRecive()
        { 
            
        }

        private void Disconnect()
        {
            
        }
        

        private void ListenForClient()
        {
            this.listener.Start();
    
            while (true)
            {
                TcpClient client = this.listener.AcceptTcpClient();
                //client.Client.BeginReceive += Recive;
                //client.Client. += Disconnect;

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

                try
                {
                    int c=1;
                    byte[] bytes = new byte[1024];
                    while(c>0)
                    {
                        c = client.Client.BeginReceive(bytes,0,1024, SocketFlags.None, EndRecive, new object());
                    }

                    //StreamReader sr = new StreamReader(ns);
                    //string buffer = sr.ReadLine();
                    if (c<=0)
                    {
                        if (map.Contains(remoteIp))
                        {
                            map.Remove(remoteIp);
                        }
                        ns.Close();
                        client.Close();
                    }

                }
                catch (Exception)
                {
                    if (map.Contains(remoteIp))
                    {
                        map.Remove(remoteIp);
                    }
                    ns.Close();
                    client.Close();
                }

                if (!map.Contains(remoteIp))
                {
                    map.Add(remoteIp, client);
                }


                byte[] info = Encoding.UTF8.GetBytes(dogInfo.Information);

                try
                {


                        ns.Write(info, 0, info.Length);
                        ns.Close();
                        client.Close();
                }
                catch (IOException ex)
                {
                    map.Remove(remoteIp);
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

        private bool ReadDogInfo()
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

        private Socket GetSocket(TcpClient cln)
        {
            return cln.Client;
        }

        private string GetRemoteIP(TcpClient cln)
        {
            string ip = GetSocket(cln).RemoteEndPoint.ToString().Split(':')[0];
            return ip;
        }

        private int GetRemotePort(TcpClient cln)
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

    }
}
