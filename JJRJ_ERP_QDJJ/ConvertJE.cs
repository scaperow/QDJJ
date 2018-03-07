using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ConvertJE : CBaseForm
    {
        public ConvertJE()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit1.Text))
            {
                MessageBox.Show("提示", "请输入数字");
                return;
            }
            string je = ToolKit.NumToCNum(ToolKit.ParseDecimal(this.textEdit1.Text));
            this.txt_xmmc.Text = je;
        }

       
    }
}
