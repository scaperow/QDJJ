using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class TJLXSelect : BaseForm
    {
        public TJLXSelect()
        {
            InitializeComponent();
            
        }
        private DataTable m_Source;
        private string m_TJBH;
        private object m_LXID;

        public object LXID
        {
            get { return m_LXID; }
            set { m_LXID = value; }
        }
        public string TJBH
        {
            get { return m_TJBH; }
            set { m_TJBH = value; }
        }
        public DataTable Source
        {
            get { return m_Source; }
            set { m_Source = value; }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.m_LXID = (this.bindingSource1.Current as DataRowView)["ID"];
            this.DialogResult = DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void TJLXSelect_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            this.bindingSource1.DataSource = this.Source;
            this.bindingSource1.Filter = string.Format("TJBH like '%{0}%'", "," + this.m_TJBH + ",");
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "TJBH")
            {
                e.DisplayText = e.CellValue.ToString().Trim(',');
            }
        }

    }
}
