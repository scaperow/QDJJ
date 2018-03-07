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
    public partial class CPwdForm : CBaseForm
    {
        /// <summary>
        /// 要加密的数据集
        /// </summary>
        private _COBJECTS m_Source = null;

        public bool isJZBX = false;

        /// <summary>
        /// 获取或设置要加密数据集合
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

        public CPwdForm()
        {
            InitializeComponent();
        }

        private void CPwdForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            //窗体名称
            if (m_Source != null)
            {
                string s_t = string.Empty;
                switch (m_Source.ObjectType)
                {
                    case EObjectType.PROJECT:
                        s_t = "项目";
                        break;
                    default:
                        s_t = "工程";
                        break;
                }
                this.Text = string.Format("{0}-配置密码",s_t);
                this.lblName.Text = string.Format("{0}名称：{1}", s_t, m_Source.Name);
                this.lblName.ToolTip = string.Format("{0}名称：{1}", s_t, m_Source.Name);
                //界面初始化
                if (!this.isJZBX)
                {
                    this.txt_YMM.Enabled = true;
                }
                else
                {
                    this.txt_YMM.Enabled = false;
                }
            
            }

            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //确认
            //验证
            if (this.Vali())
            {
                if (this.txt_XMM.Text == string.Empty)
                {
                    this.Source.PassWord = string.Empty;
                }
                else
                {
                    this.Source.PassWord = this.GetStr(this.txt_XMM.Text);
                }
                this.CurrentBusiness.Current.StructSource.ModelProject.UpDate(this.Source);
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool Vali()
        {
            string str1 = string.Empty, str2 = string.Empty, str3 = string.Empty;

            str1 = this.txt_YMM.Text==string.Empty?string.Empty:this.GetStr(this.txt_YMM.Text);
            //if (string.IsNullOrEmpty(this.txt_XMM.Text.Trim()))
            //{
            //    MessageBox.Show(this, "密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.txt_XMM.Focus();
            //    return false;
            //}
            str2 = this.GetStr(this.txt_XMM.Text);
            str3 = this.GetStr(this.txt_QRMM.Text);

            //if (this.m_Source.Property.Setting != null)
            if (!this.isJZBX)
            {
                if (this.m_Source.PassWord != str1)
                {
                    MessageBox.Show(this, "原始密码验证错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_YMM.ResetText();
                    return false;
                }
            }
            else
            {
                this.txt_YMM.Enabled = false;
            }

            if (str2 != str3)
            {
                MessageBox.Show(this, "新密码与确认密码不一致，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_XMM.ResetText();
                this.txt_QRMM.ResetText();
                return false;
            }

            return true;
        }


        private string GetStr(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}