using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class AtlasGallery : BaseControl
    {
      
        /// <summary>
        /// 当前应用程序目录
        /// </summary>
        public DirectoryInfo Folder = null;

        private DataTable M_Source;
        /// <summary>
        /// 图集索引的数据源
        /// </summary>
        public DataTable Source
        {
            get { return M_Source; }
            set { M_Source = value; }
        }
        public AtlasGallery()
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
           // Loads();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void Loads()
        {
            if (this.M_Source != null)
            {
                //打开操作的清单库
                this.bindingSource1.Filter = string.Format("SFXS={0}", "True");
                this.bindingSource1.DataSource = this.M_Source;
                this.treeList1.DataSource = this.bindingSource1.DataSource;
                this.treeList1.KeyFieldName = "SYBH";
                this.treeList1.ParentFieldName = "PARENTID";
                this.treeList1.Expand(2);
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
        //            string str = this.treeList1.Selection[0].GetValue("SYBH").ToString();
        //            //this.bindingSource2.Filter = string.Format("SYBH = '{0}'", str);
        //        }
        //    }
        //}

        //private void textEdit1_TextChanged(object sender, EventArgs e)
        //{
        //    ////文本改变筛选
        //    //TextEdit text = sender as TextEdit;
        //    //if (text.Text.Trim() == string.Empty)
        //    //{
        //    //    this.bindingSource2.Filter = string.Empty;
        //    //}
        //    //else
        //    //{
        //    //    this.bindingSource2.Filter = string.Format("TJBH like '%{0}%' or TJMC like '%{0}%'", text.Text.Trim());
        //    //}
        //}

       
    }
}
