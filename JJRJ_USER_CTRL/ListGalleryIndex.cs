using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class ListGalleryIndex : BaseControl
    { /// <summary>
        /// 当前应用程序目录
        /// </summary>
        public DirectoryInfo Folder = null;

 

        /// <summary>
        /// 清单数据集合
        /// </summary>
        public DataTable DataSource = null;

        private _UnitProject m_CUnitProject = null;
        
        /// <summary>
        /// 默认的清单库文件名称
        /// </summary>
        public _UnitProject Default
        {
            set
            {

                this.buttonEdit1.Text = value.Property.Libraries.ListGallery.FullName;
                m_CUnitProject = value;
            }
        }

        public ListGalleryIndex()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            //打开当前清单库
            Loads();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Loads();
        }
        private void Loads()
        {
            if (this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet != null)
            {
                this.bindingSource1.DataSource = this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单索引表"].Copy();
                this.treeList1.DataSource = this.bindingSource1.DataSource;
                this.treeList1.Expand(1);
                this.buttonEdit1.Properties.Buttons[0].Visible = false;

            }
        }
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //打开事件
        }

       

        //private void textEdit1_TextChanged(object sender, EventArgs e)
        //{
        //    //查询框输入后自动查询
        //    TextEdit text = sender as TextEdit;
        //    if (text.Text.Trim() == string.Empty)
        //    {
        //        this.bindingSource2.Filter = string.Empty;


        //    }
        //    else
        //    {
        //        this.bindingSource2.Filter = string.Format("QINGDBH like '%{0}%' or QINGDMC like '%{0}%'", text.Text.Trim());
        //    }
        //}

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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

      

        

    }
}
