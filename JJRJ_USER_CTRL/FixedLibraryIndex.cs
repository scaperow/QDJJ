using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class FixedLibraryIndex : BaseControl
    {
        
        /// <summary>
        /// 当前应用程序目录
        /// </summary>
        public DirectoryInfo Folder = null;

        private _UnitProject m_CUnitProject = null;
        /// <summary>
        /// 默认的清单库文件名称
        /// </summary>
        public _UnitProject Default
        {
            set
            {

                this.buttonEdit1.Text = value.Property.Libraries.FixedLibrary.FullName;
                m_CUnitProject = value;
            }
        }

        public FixedLibraryIndex()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            //打开当前定额库
            Loads();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Loads();
        }
         /// <summary>
        /// 加载数据
        /// </summary>
        private void Loads()
        {
            if (this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet != null)
            {

                this.bindingSource1.DataSource = this.m_CUnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额索引表"].Copy();
                this.treeList1.DataSource = this.bindingSource1;
                this.bindingSource1.Sort = "DINGESYBH asc";
                this.treeList1.Expand(1);
                this.buttonEdit1.Properties.Buttons[0].Visible = false;
            }
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList t = sender as TreeList;
            TreeListHitInfo n = t.CalcHitInfo(e.Location);
            if (n.Node != null)
            {
                if (n.Node.HasChildren)
                {
                    n.Node.Expanded = !n.Node.Expanded;
                }
            }
        }

        //private void treeList1_Click(object sender, EventArgs e)
        //{
        //    //根据选择的目录筛选子目

        //    if (this.treeList1.Selection[0] != null)
        //    {
        //        //如果选中且没有儿子
        //        if (!this.treeList1.Selection[0].HasChildren)
        //        {
        //            //获取选中的ID
        //            string str = this.treeList1.Selection[0].GetValue("DINGESYBH").ToString();
        //            this.bindingSource2.Filter = string.Format("DINGESYBH = '{0}'", str);
        //        }
        //    }
        //}

        //private void textEdit1_TextChanged(object sender, EventArgs e)
        //{
        //    //文本改变筛选
        //    TextEdit text = sender as TextEdit;
        //    if (text.Text.Trim() == string.Empty)
        //    {
        //        this.bindingSource2.Filter = string.Empty;
        //    }
        //    else
        //    {
        //        this.bindingSource2.Filter = string.Format("DINGEH like '%{0}%' or DINGEMC like '%{0}%'", text.Text.Trim());
        //    }
        //}
    }
}
