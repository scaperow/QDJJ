using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QueryFixedLibrary : BaseForm
    {

        public QueryFixedLibrary(_UnitProject act)
        {
            this.Activitie = act;
            InitializeComponent();
            fixedLibraryIndex1.Folder = APP.Application.Global.AppFolder;
            fixedLibraryIndex1.Default = this.Activitie;
        }
        private void QueryFixedLibrary_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            
            this.fixedLibraryIndex1.textEdit1.EditValueChanged += new EventHandler(textEdit1_EditValueChanged);
            this.fixedLibraryIndex1.treeList1.Click += new EventHandler(treeList1_Click);
            this.bindingSource1.DataSource = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy();
            this.gridControl1.DataSource = this.bindingSource1;


        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeListNode tn = this.fixedLibraryIndex1.treeList1.FocusedNode;
            if (tn != null)
            {

                //this.bindingSource1.Filter = string.Format("DINGESYBH like '%{0}%'", tn.GetValue("DINGESYBH").ToString().Trim());

                this.bindingSource1.Filter = string.Format("DINGESYBH = {0}", tn.GetValue("DINGESYBH").ToString().Trim());
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit text = sender as TextEdit;
            if (text.Text.Trim() == string.Empty)
            {
                this.bindingSource1.Filter = string.Empty;


            }
            else
            {
                this.bindingSource1.Filter = string.Format("DINGEH like '%{0}%' or DINGEMC like '%{0}%'", text.Text.Trim());
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
