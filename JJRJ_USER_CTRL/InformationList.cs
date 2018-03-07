/*
 工程信息中使用的用户控件
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class InformationList : BaseControl
    {
        /// <summary>
        /// 新节点的名称
        /// </summary>
        public string GetNewName
        {
            get
            {
                //获取当前有效节点的个数
                int level = this.treeList1.Selection[0].Level;
                string name = string.Empty;
                if (level == 1)
                {
                    name = this.treeList1.Selection[0].GetValue("Name").ToString();;
                    return string.Format("{0}{1}", name, this.treeList1.Selection[0].Nodes.Count + 1);
                    
                }
                if (level == 2)
                {
                    name = this.treeList1.Selection[0].ParentNode.GetValue("Name").ToString(); ;
                    return string.Format("{0}{1}", name, this.treeList1.Selection[0].ParentNode.Nodes.Count + 1);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取有效选择Key值
        /// </summary>
        public int GetCurrKey
        {
            get
            {
                int level = this.treeList1.Selection[0].Level;
                if (level == 1)
                {
                    return this.treeList1.Selection[0].Id;
                }
                if (level == 2)
                {
                    return this.treeList1.Selection[0].ParentNode.Id;
                }
                return -1;
            }
        }


        public object DataSource
        {
            set
            {
                this.bindingSource1.DataSource = value;
            }

            get
            {
                return this.bindingSource1.DataSource;
            }
        }

        public void DataBind()
        {
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.Nodes[0].Expanded = true;
                //this.treeList1.ExpandAll(); ;
            
            
        }

        public InformationList()
        {
            InitializeComponent();
        }

        private void treeList1_CreateCustomNode(object sender, DevExpress.XtraTreeList.CreateCustomNodeEventArgs e)
        {
            if (e.Owner.TreeList.Selection[0] != null)
            {
                if (e.Owner.TreeList.Selection[0].Level == 1)
                {
                    e.Owner.TreeList.Selection[0].ExpandAll();
                }
                if (e.Owner.TreeList.Selection[0].Level == 2)
                {
                    e.Owner.TreeList.Selection[0].ParentNode.ExpandAll();
                }
            }
        }

    }
}
