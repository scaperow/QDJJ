using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ZiboSoft.Commons.Common;
using System.Text.RegularExpressions;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class InfoGridView : GridView
    {
        public InfoGridView()
        {
            InitializeComponent();
        }
        protected override DevExpress.Utils.AppearanceObject RaiseGetRowStyle(int rowHandle, DevExpress.XtraGrid.Views.Base.GridRowCellState state, DevExpress.Utils.AppearanceObject appearance, out bool highPriority)
        {

            DataRow r = this.GetDataRow(rowHandle);
            if (r != null)
            {
                if (ToolKit.ParseBoolen(r["IsFresh"]))
                {
                    appearance.BackColor = Color.FromArgb(212, 231, 176);
                }
                else { appearance.BackColor = Color.White; }
            }
            else { appearance.BackColor = Color.White; }
            return base.RaiseGetRowStyle(rowHandle, state, appearance, out highPriority);
        }
        protected override void RaiseValidatingEditor(DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.FocusedColumn == null) return;
            if (this.FocusedColumn.ColumnType == typeof(float) || this.FocusedColumn.ColumnType == typeof(int) || this.FocusedColumn.ColumnType == typeof(decimal))
            {
                e.Value = ToolKit.ParseDecimal(e.Value);
            }
            base.RaiseValidatingEditor(e);
        }
    }
}
