using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net.Sockets;

namespace GOLDSOFT.SERVER
{
    public partial class Form1 : Form
    {
        static string MAC = "";
        static string HardDiskSerialNumber = "";
        DogInfo dogInfo;
        Server server;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////如果本机的Mac地址或硬盘序列号与指定的机器不相符，则程序退出
            //if (!Utility.GetNetCardMacAddress().Equals(MAC) || !Utility.GetDiskID().Equals(HardDiskSerialNumber))
            //{
            //    this.Close();
            //}
            //else
            //this.Hide();
                //Utility.Init();
            this.btnDisConnect.Enabled = false;
            this.Hide();
            if (!ReadDogInfo())
                return;
            if (dogInfo == null) return;
            //Console.WriteLine("加密狗信息读取成功!");

            //string diskId = Utility.GetDiskID();
            //MessageBox.Show(diskId);
            server = new Server(dogInfo);
            server.start();

        }

        bool ReadDogInfo()
        {
            dogInfo = new DogInfo();
            int result = dogInfo.getDogInfo();
            if (result != 0)
            {
                return false;
            }

            return true;
        }

        private void menuExit_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }


        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            foreach (DictionaryEntry ip in server.map)
            {
                if(!listBox1.Items.Contains(ip.Key))
                    listBox1.Items.Add("客户端:" + ip.Key + " 已连接");

            }

            this.Show();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            string ip = this.listBox1.SelectedItem.ToString();
            int startIndex = ip.IndexOf(":");
            int count = ip.LastIndexOf(" ") - startIndex;
            string newip = ip.Substring(startIndex+1, count -1);
            ((TcpClient)this.server.map[newip]).Close();
            server.map.Remove(newip);
            listBox1.Items.Remove(ip);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                btnDisConnect.Enabled = true;
            else
                btnDisConnect.Enabled = false;
        }

    }
}
