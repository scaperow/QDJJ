using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*******砂浆转换**********/
namespace GOLDSOFT.QDJJ.UI
{
    public partial class ShaJiangZhuanHuanForm : BaseForm
    {
        public ShaJiangZhuanHuanForm()
        {
            InitializeComponent();
        }
        public void SetInfo(string CheckText,string Remark)
        {
            this.checkEdit1.Text = CheckText;
            this.memoEdit1.Text = Remark;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
