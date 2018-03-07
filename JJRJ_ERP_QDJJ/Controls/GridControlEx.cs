using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI.Controls
{
    public partial class GridControlEx : GridControl
    {
        public GridControlEx()
        {
            InitializeComponent();
        }

        public void ScrollToRow(int row)
        {
           
            //base.sc
          //(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, row));
        } 
    }
}
