using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using System.Web.Security;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CValidationPWD : BaseForm
    {
        /// <summary>
        /// 要验证的数据集
        /// </summary>
        private _COBJECTS m_Source = null;

        /// <summary>
        /// 获取或设置要验证的数据集
        /// </summary>
        public _COBJECTS Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                this.m_Source = value;
            }
        }

        public CValidationPWD()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //输入密码后验证
            //输入密码与当前密码是否相同
            //if (this.txt_YMM.Text != string.Empty)
            //{
                string str = this.GetStr(this.txt_YMM.Text.Trim());
                if (str.Equals(this.m_Source.PassWord) || this.txt_YMM.Text.Trim().Equals(this.m_Source.PassWord))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this, "密码验证错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_YMM.ResetText();
                }
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private string GetStr(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
        }
    }
}