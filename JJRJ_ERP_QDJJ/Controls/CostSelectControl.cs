using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.UI.Controls
{
    public partial class CostSelectControl : UserControl
    {
        public CostSelectControl(string p_xsl)
        {
            InitializeComponent();
            switch (p_xsl)
            {
                case "GLFL":
                    this.GLFL.Visible = true;
                    break;
                case "LRFL":
                    this.LRFL.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void CostSelectControl_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = this.bindingSource1;
        }
    }
}
