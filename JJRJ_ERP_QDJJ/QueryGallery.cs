using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QueryGallery : BaseForm
    {
       
        public QueryGallery(_UnitProject act)
        {
            this.Activitie = act;
            InitializeComponent();
            listGalleryIndex1.Folder = APP.Application.Global.AppFolder;
            listGalleryIndex1.Default = this.Activitie;
        }
        private object m_CurrQD = null;

        /// <summary>
        /// 当前操作的清单
        /// </summary>
        public object CurrQD
        {
            get { return m_CurrQD; }
            set { m_CurrQD = value; }
        }
   
        private void QueryGallery_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
           
            this.listGalleryIndex1.textEdit1.EditValueChanged += new EventHandler(textEdit1_EditValueChanged);
            this.listGalleryIndex1.treeList1.Click += new EventHandler(treeList1_Click);
            this.galleryGridList1.DataSource = this.Activitie.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"].Copy();
            this.galleryGridList1.DataBind();


        }

     
         private  void treeList1_Click(object sender, EventArgs e)
        {

            TreeListNode tn = this.listGalleryIndex1.treeList1.FocusedNode;
            if (tn!=null)
            {

                this.galleryGridList1.bindingSource1.Filter = string.Format("QINGDSYBH like '%{0}%'", tn.GetValue("QINGDSYBH").ToString().Trim());
            }
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {//查询框输入后自动查询
            TextEdit text = sender as TextEdit;
            if (text.Text.Trim() == string.Empty)
            {
                this.galleryGridList1.bindingSource1.Filter = string.Empty;


            }
            else
            {
                this.galleryGridList1.bindingSource1.Filter = string.Format("QINGDBH like '%{0}%' or QINGDMC like '%{0}%'", text.Text.Trim());
            }
        
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
            else { this.Close(); }
        }

       
    }
}