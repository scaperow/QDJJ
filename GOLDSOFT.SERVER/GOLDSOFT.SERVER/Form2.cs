using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.SERVER
{
    public partial class Form2 : Form
    {
        static string MAC = "";
        static string HardDiskSerialNumber = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ////如果本机的Mac地址或硬盘序列号与指定的机器不相符，则程序退出
            //if (!Utility.GetNetCardMacAddress().Equals(MAC) || !Utility.GetDiskVolumeSerialNumber().Equals(HardDiskSerialNumber))
            //{
            //    this.Close();
            //}
            //else
            //this.Hide();
            Utility.Init();
        }
    }
}
