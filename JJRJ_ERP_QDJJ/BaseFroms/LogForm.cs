using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class LogForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event SetLogContentHandler SetLogContent;

        /// <summary>
        /// 统计完成后激发
        /// </summary>
        public virtual void OnSetLogContent(object sender, object args)
        {
            if (SetLogContent != null)
            {
                this.SetLogContent(sender, args);
            }
        }
        /// <summary>
        /// 获取或设置日志对象
        /// </summary>
        private LogContent m_LogContent = null;

        /// <summary>
        /// 获取或设置日志对象
        /// </summary>
        public LogContent LogContent
        {
            get
            {
                return this.m_LogContent;
            }
            set
            {
                this.m_LogContent = value;
            }
        }

        public string SetContents
        {
            set 
            {
                this.memoEdit1.Text = value;
            }
        }

        public LogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化当前对象
        /// </summary>
        public void Init()
        {
            if (this.m_LogContent != null)
            {
                OnSetLogContent(this, this.m_LogContent);
                this.SetContents = this.m_LogContent.LogString;
            }
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}