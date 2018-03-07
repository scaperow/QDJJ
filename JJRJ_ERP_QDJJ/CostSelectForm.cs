using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraReports.Design;
using DevExpress.XtraTab;
using GOLDSOFT.QDJJ.UI.Controls;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CostSelectForm : CBaseForm
    {
        private string xsl = string.Empty;

        /// <summary>
        /// 显示咧
        /// </summary>
        public string Xsl
        {
            get { return xsl; }
            set 
            { 
                xsl = value;
                switch (xsl)
                {
                    case "GLFL":
                        this.Text = "管理费";
                        break;
                    case "LRFL":
                        this.Text = "利润费";
                        break;
                    default:
                        break;
                }
            }
        }


        public CostSelectForm()
        {
            InitializeComponent();
        }

        private decimal xz_FL= 0m;

        public decimal Xz_FL
        {
            get { return xz_FL; }
            set { xz_FL = value; }
        }


        private void CostSelectForm_Load(object sender, EventArgs e)
        {
            DataSet ds = APP.Application.Global.DataTamp.CostSelectList;
            foreach (DataTable item in ds.Tables)
            {
                XtraTabPageCostSelectEx t = new XtraTabPageCostSelectEx(item, this.Xsl);
                this.xtraTabControl1.TabPages.Add(t);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraTabPageCostSelectEx tpcs = this.xtraTabControl1.SelectedTabPage as XtraTabPageCostSelectEx;
            if (tpcs != null)
            {
                DataRowView dr = tpcs.Current() as DataRowView;
                if (dr != null)
                {
                    switch (this.Xsl)
                    {
                        case "GLFL":
                            this.xz_FL = ToolKit.ParseDecimal(dr["GLFL"]);
                            break;
                        case "LRFL":
                            this.xz_FL = ToolKit.ParseDecimal(dr["LRFL"]);
                            break;
                        default:
                            break;
                    }   
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}