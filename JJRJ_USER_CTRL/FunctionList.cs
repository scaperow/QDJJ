using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class FunctionList : BaseControl
    {       

        public int Count
        {
            get
            {
                return this.bindingSource1.Count;
            }
        }

        /// <summary>
        /// 获取或设置当前的类型名称
        /// </summary>
        public string TypeName = string.Empty;
        
        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        private DataTable m_DataSource = null;


        /// <summary>
        /// 获取或设置当前数据的数据源
        /// </summary>
        public DataTable DataSource
        {
            set
            {
                this.m_DataSource = value;
            }
            get
            {
                return this.m_DataSource; 
            }
        }

        public FunctionList()
        {
            InitializeComponent();
        }

        public void DataBind()
        {
            if (this.m_DataSource != null)
            {
                this.bindingSource1.DataSource = this.m_DataSource.Copy();
                if (this.TypeName != string.Empty)
                {
                    this.bindingSource1.Filter = string.Format("Type = '{0}'",this.TypeName);
                }
                this.imageListBoxControl1.DataSource = this.bindingSource1;
            }
        }

        public void DataBind(string p_TypeName)
        {
            if (this.m_DataSource != null)
            {
                this.bindingSource1.DataSource = this.m_DataSource;
                if (p_TypeName != string.Empty)
                {
                    this.bindingSource1.Filter = string.Format("Type = '{0}'", p_TypeName);
                }
                this.imageListBoxControl1.DataSource = this.bindingSource1;
            }
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {

        }
    }
}
