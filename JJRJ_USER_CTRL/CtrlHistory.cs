using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class CtrlHistory : BaseControl
    {
        /// <summary>
        /// 获取当前选中的副本路径
        /// </summary>
        public string Current
        {
            get
            {
                if (this.bindingSource1.Current != null)
                {
                    return (this.bindingSource1.Current as DataRowView)["FileName"].ToString();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取或设置历史清单
        /// </summary>
        private _History m_History = null;

        /// <summary>
        /// 获取或设置当前控件的数据源
        /// </summary>
        public _History DataSource
        {
            get
            {
                return this.m_History;
            }
            set
            {
                this.m_History = value;
            }
        }

        /// <summary>
        /// 为当前控件进行绑定操作
        /// </summary>
        public void DataBind()
        {
            this.bindingSource1.DataSource = this.m_History.HistoryTable;
            this.gridControl1.DataSource = this.bindingSource1;
        }

        public CtrlHistory()
        {
            InitializeComponent();
        }
    }
}
