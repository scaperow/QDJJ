using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CurrentUnit : BaseForm
    {
        /// <summary>
        /// 当前工程材机
        /// </summary>
        private object m_DataSource = null;

        /// <summary>
        /// 获取或设置：当前工程材机
        /// </summary>
        public object DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }

        public CurrentUnit()
        {
            InitializeComponent();
        }

        private void CurrentUnit_Load(object sender, EventArgs e)
        {
            this.gridControlBDGLJ.DataSource = this.DataSource;
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "SL":
                    case "DJC":
                    case "HJC":
                    case "SCHJ":
                    case "DEHJ":
                    case "DEDJ":
                    case "SCDJ":
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if (d.Equals(0m))
                        {
                            e.DisplayText = string.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}