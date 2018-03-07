using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.CTRL
{
    /// <summary>
    ///清单树形结构
    /// </summary>
    public partial class GalleryTreeList : BaseControl
    {
     

        private object m_dataSource=null;
        private string m_ColumnFieldName = null;
        private string m_ColumnParentFieldName = null;
        private string m_ColumnKeyFieldName = null;
        private DataTable m_NodedataSource = null;

        /// <summary>
        /// 获取或设置当前控件的KeyFieldName
        /// </summary>
        public string ColumnKeyFieldName
        {
            get { return this.m_ColumnKeyFieldName; }
            set { this.m_ColumnKeyFieldName = value; }
        }

        /// <summary>
        /// 获取或设置当前控件的数据源
        /// </summary>
        public object DataSource
        {
            get { return this.m_dataSource; }
            set { this.m_dataSource = value; }
        }

        /// <summary>
        /// 获取或设置当前控件的数据源
        /// </summary>
        public DataTable NodeDataSource
        {
            get { return this.m_NodedataSource; }
            set { this.m_NodedataSource = value; }
        }
        /// <summary>
        /// 获取或设置当前控件显示列的字段名称
        /// </summary>
        public string ColumnFieldName
        {
            get { return this.m_ColumnFieldName; }
            set { this.m_ColumnFieldName = value; }
        }
        /// <summary>
        /// 获取或设置当前控件显示列的父级字段名称
        /// </summary>
        public string ColumnParentFieldName
        {
            get { return this.m_ColumnParentFieldName; }
            set { this.m_ColumnParentFieldName = value; }
        }
        
       
        public GalleryTreeList()
        {
            InitializeComponent();
           
        }

        private void GalleryTreeList_Load(object sender, EventArgs e)
        {
           // DataBind();
        }
        /// <summary>
        /// 绑定树方法
        /// </summary>
        public void DataBind()
        {
            treeList1.ClearNodes();
            this.treeListColumn1.FieldName = ColumnFieldName;
            this.treeList1.KeyFieldName = ColumnKeyFieldName;
            this.treeList1.ParentFieldName = ColumnParentFieldName;
            this.bindingSource1.DataSource = this.DataSource;
            this.treeList1.DataSource = null;
            this.treeList1.DataSource = this.bindingSource1.DataSource;
           
            //treeList1.EndInit();
           // this.treeList1.RefreshDataSource();
           
        }
       
        private void CreateNodes(TreeListNode node)
        {

            if (!node.HasChildren )
                {
                    if (node.Tag==null)
                    {

                    node.Tag = 1;
                    treeList1.BeginInit();

                    DataRow[] dr = this.NodeDataSource.Select(" QINGDSYBH= '" + node.GetValue("QINGDSYBH") + "'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                    //this.treeList1.BeginUnboundLoad();
                    TreeListNode chilNode = treeList1.AppendNode(dr[i]["QINGDBH"], node);
                     chilNode.SetValue(this.treeListColumn1,"" + dr[i]["QINGDBH"] + "|" + dr[i]["QINGDMC"] + "");
                     chilNode.Tag = dr[i];
                    // this.treeList1.EndUnboundLoad();
                    }
                    treeList1.EndInit();

                    }
                }

        }
        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
           
        }

        private void treeList1_GetPreviewText(object sender, DevExpress.XtraTreeList.GetPreviewTextEventArgs e)
        {
            CreateNodes(e.Node); 
        }

      

      

      


    
    }
}
