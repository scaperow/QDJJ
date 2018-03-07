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

namespace GOLDSOFT.QDJJ.UI
{
    public partial class MeasuresSelectForm : BaseForm
    {
        public MeasuresSelectForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 选择清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRowView  v=this.bindingSource1.Current as DataRowView;
            if (v != null)
            {
                if (v["LB"].Equals("清单"))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void MeasuresSelectForm_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            this.bindingSource1.DataSource = this.Activitie.StructSource.ModelMeasures.Copy();
            this.treeList1.DataSource = this.bindingSource1; 
            this.treeList1.KeyFieldName = "ID";
            this.treeList1.ParentFieldName = "PID";
            this.treeList1.ExpandAll();
        }

        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level >= 3)
                {
                    e.Node.Visible = false;
                    // foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in e.Node.Nodes)
                    //{
                    //    item.Visible = false;
                    //}
                }
            }
        }
    }
}
