using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class PrimitiveFormula : BaseControl
    {
        private DataTable dt = null;

        private DataRowView drv = null;

        public DataRowView Drv
        {
            get { return drv; }
            set 
            { 
                drv = value;
                LoadCreate();
            }
        }

        public PrimitiveFormula()
        {
            InitializeComponent();
        }

        private void PrimitiveFormula_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void LoadCreate()
        {
            if (this.drv != null)
            {
                this.CreateDataTable();
                string m_Parameter = drv["Parameter"].ToString();
                string[] s_Parameter = m_Parameter.Split(',');
                foreach (string item in s_Parameter)
                {
                    string[] cs = item.Split(':');
                    DataRow n_dr = dt.NewRow();
                    if (cs.Length == 2)
                    {
                        n_dr["FH"] = cs[0].ToString();
                        n_dr["MC"] = item;
                    }
                    else
                    {
                        n_dr["FH"] = item;
                        n_dr["MC"] = item;
                    }
                    this.dt.Rows.Add(n_dr);
                }
                this.bindingSource1.DataSource = this.dt;
            }
        }

        private void CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("FH", typeof(string));//符号
            dt.Columns.Add("MC", typeof(string));//名称
            dt.Columns.Add("SZ", typeof(string));//数值
        }
    }
}
