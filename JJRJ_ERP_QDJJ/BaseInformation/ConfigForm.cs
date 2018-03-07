using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ConfigForm : BaseForm
    {
        /// <summary>
        /// 配置文件对象类
        /// </summary>
        private _Configuration m_Configuration = null;

        /// <summary>
        /// 获取或设置文件对象类
        /// </summary>
        public _Configuration Configuration
        {
            get
            {
                return this.m_Configuration;
            }
            set
            {
                this.m_Configuration = value;
            }
        }

        public void Bind()
        {
            if (this.m_Configuration != null)
            {
                radioGroup1.SelectedIndex = ToolKit.ParseInt(this.m_Configuration.Configs["工程量输入方式"]);
                radioGroup2.SelectedIndex = ToolKit.ParseInt(this.m_Configuration.Configs["名称显示方式"]);
                checkEdit1.Checked = ToolKit.ParseBoolen(this.m_Configuration.Configs["清单工程量设置"]);
                checkEdit2.Checked = ToolKit.ParseBoolen(this.m_Configuration.Configs["标准换算"]);
                checkEdit3.Checked = ToolKit.ParseBoolen(this.m_Configuration.Configs["石灰换算"]);
                checkEdit4.Checked = ToolKit.ParseBoolen(this.m_Configuration.Configs["配合比换算"]);
                checkEdit5.Checked = ToolKit.ParseBoolen(this.m_Configuration.Configs["砂浆换算"]);
                txt_Time.Text = CDataConvert.ConToValue<string>(this.m_Configuration.Configs["自动保存时间"]);
            }
        }

        /// <summary>
        /// 提交数据源
        /// </summary>
        public void Commit()
        {
            this.m_Configuration.Configs["自动保存时间"] = txt_Time.Text;
            APP.Application.Global.SaveConfiguration();
        }

        public ConfigForm()
        {
            InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chk = sender as CheckEdit;
            this.m_Configuration.Configs[chk.Tag.ToString()] = chk.Checked;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_Configuration.Configs[this.radioGroup1.Tag.ToString()] = this.radioGroup1.SelectedIndex;
            
        }
        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_Configuration.Configs[this.radioGroup2.Tag.ToString()] = this.radioGroup2.SelectedIndex;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Commit();
            this.DialogResult = DialogResult.OK;
        }

       
    }
}