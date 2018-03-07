using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class VariableList : BaseControl
    {
        //private bool m_isDisplayValue = false;

        /// <summary>
        /// 是否显示值列
        /// </summary>
        public bool IsDisplayValue
        {
            set
            {
                this.gridColumn3.Visible = value;
            }
        }

        /// <summary>
        /// 获取当前选中的项 
        /// </summary>
        public DataRowView Current
        {
            get
            {
                return this.bindingSource1.Current as DataRowView;
            }
        }

        /// <summary>
        /// 双击事件处理函数
        /// </summary>
        public event EventHandler DoubleClick 
        {
            add
            {
                this.gridControl1.DoubleClick  +=new EventHandler(value);
            }
            remove
            {
                this.gridControl1.DoubleClick -= new EventHandler(value);
            }
        }

        /// <summary>
        /// 获取或设置
        /// </summary>
        private object m_DataSource = null;

        /// <summary>
        /// 获取或设置可变数据源
        /// </summary>
        public object DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
            }
        }

        public VariableList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用于绑定数据源(-1 -2 -3)
        /// 单位工程 单项工程 项目(按照条件筛选)
        /// </summary>
        public void DataBind(int p_id,int type)
        {
            string filter = string.Empty;
            if (type == -3)
            {
                //项目筛选
                filter = string.Format(" type ={0}",type);
            }
            if (type == -2)
            {
                //项目筛选
                filter = string.Format("EnID = {0} and type ={1}", p_id, type);
            }
            if (type == -1)
            {
                //项目筛选
                filter = string.Format("ID = {0} and type ={1}", p_id, type);
            }
            
            this.bindingSource1.DataSource = this.m_DataSource;
            this.bindingSource1.Filter = filter;
            this.gridControl1.DataSource = this.bindingSource1;
            
        }

        public void DataBind()
        {

            this.bindingSource1.DataSource = this.m_DataSource;
            this.gridControl1.DataSource = this.bindingSource1;

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName == "Value")
            {
                decimal m_value = ToolKit.ParseDecimal(e.CellValue);
                e.DisplayText = m_value.Equals(0m) ? string.Empty : m_value.ToString("############0.##");
            }
        }

    }
}
