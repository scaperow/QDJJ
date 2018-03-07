using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class PartProjectForm : CBaseForm
    {
        public PartProjectForm()
        {
            InitializeComponent();
        }

        private void PartProjectForm_Load(object sender, EventArgs e)
        {

            treeList1.ExpandAll();

           // treeList1.AppendNode("建筑工程",0);
        }

      
        
    }
}