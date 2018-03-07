using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class ComboxTreelist : BaseControl
    {

        private object m_RootSource = null;
        private DataTable m_NodedataSource = null;
        private string m_FiterStr = null;
        private ArrayList m_CheckNodes;
       // public TreeListNode RootNode;
        /// <summary>
        /// 获取或当前控件的数据源
        /// </summary>
        public ArrayList CheckNodes
        {
            get { return this.m_CheckNodes; }
            set { this.m_CheckNodes = value; }
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
        /// 获取或设置当前控件的RootName
        /// </summary>
        public object RootSource
        {
            get { return this.m_RootSource; }
            set { this.m_RootSource = value; }
        }

       
        public string FiterStr
        {
            get { return this.m_FiterStr; }
            set { this.m_FiterStr = value; }
        }
        /// <summary>
        /// 带有选择框的树形结构
        /// </summary>
        public ComboxTreelist()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 绑定树方法
        /// </summary>
        public void DataBind()
        {
            string StrWhere = " 1<>1";
            if (this.FiterStr != "")
            {
                StrWhere = " DINGEH in (" + this.FiterStr + ")";
            }
            this.bindingSource1.DataSource = this.NodeDataSource;
            this.bindingSource1.Filter = StrWhere;
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.ExpandAll();
            m_CheckNodes = new ArrayList();
        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
                
                this.m_CheckNodes.Add(e.Node);
        }

        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            e.Node.Tag = this.treeList1.GetDataRecordByNode(e.Node);
        }
    }
}
