using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using GOLDSOFT.QDJJ.COMMONS.LIB;

namespace GOLDSOFT.QDJJ.CTRL
{
    /// <summary>
    /// 清单列表
    /// </summary>
    public partial class GalleryGridList : BaseControl
    {


        private object m_dataSource = null;
        /// <summary>
        /// 获取或设置当前控件的数据源
        /// </summary>
        public object DataSource
        {
            get { return this.m_dataSource; }
            set { this.m_dataSource = value; }
        }



     
        public GalleryGridList()
        {
            InitializeComponent();
           // this.gridView1.Columns.AddRange(PostColumn);
        }

        private void GalleryGridList_Load(object sender, EventArgs e)
        {
          //  DataBind();
        }
        public void DataBind()
        {
            this.bindingSource1.DataSource = this.DataSource;
            this.gridControl1.DataSource = this.bindingSource1;
            
        }
    }
}
