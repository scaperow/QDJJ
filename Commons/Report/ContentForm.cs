using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public partial class ContentForm : Form
    {
        public string Content
        {
            get { return this.memoEdit1.Text; }
            set { this.memoEdit1.Text = value; }
        }

        public ContentForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 打开数据编辑窗体
        /// </summary>
        /// <param name="value">编辑的数据</param>
        /// <returns></returns>
        public static object EditValue(object value)
        {
            ContentForm form = new ContentForm();
            form.Content = value.ToString();
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                return form.Content;
            }
            else
            {
                return value;
            }
        }
    }
}
