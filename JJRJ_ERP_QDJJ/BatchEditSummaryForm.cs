using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BatchEditSummaryForm : CBaseForm
    {
        private DataTable m_DataTable = null;

        public DataTable DataSource
        {
            get { return m_DataTable; }
            set { m_DataTable = value; }
        }

        public BatchEditSummaryForm()
        {
            InitializeComponent();
        }

        private void QueryInfoPriceLibaryForm_Load(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = m_DataTable;
            this.textEditXXZ_EditValueChanged(null, null);
            textEditTZZ.Text = "100";
        }

        private void comboBoxEditSXTJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxEditSXTJ.EditValue.ToString())
            {
                case "材机编号":
                    this.textEditXXZ.Enabled = true;
                    break;
                case "材机名称":
                    this.textEditXXZ.Enabled = true;
                    break;
                case "所有人工":
                    this.textEditXXZ.Enabled = false;
                    break;
                case "所有材料":
                    this.textEditXXZ.Enabled = false;
                    break;
                case "所有机械":
                    this.textEditXXZ.Enabled = false;
                    break;
                default:
                    break;
            }
            this.textEditXXZ_EditValueChanged(null, null);
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.m_DataTable.AcceptChanges();
            foreach (DataRowView item in this.bindingSource1)
            {
                if (!item["SCDJ"].Equals(item["XGHSCDJ"]))
                {
                    item.BeginEdit();
                    item["SCDJ"] = item["XGHSCDJ"];
                    item.EndEdit();
                }
            }
            DataTable dt = this.m_DataTable.GetChanges();
            if (dt != null)
            {
                this.BatchCalculate();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BatchCalculate()
        {
            BackgroundWorker ObjWorker = new BackgroundWorker();
            ObjWorker.WorkerReportsProgress = true;
            ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
            ObjWorker.RunWorkerAsync();
            ProgressFrom form = new ProgressFrom(ObjWorker);
            form.ShowDialog();
        }


        void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _Pr_Business m_Pr_Business = this.CurrentBusiness as _Pr_Business;
            if (m_Pr_Business != null)
            {
                m_Pr_Business.Update_Quantity(this.m_DataTable.GetChanges(), "SCDJ");
            }
        }

        private void bWorker_Open_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource1.ResetBindings(false);
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButtonNO_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void textEditXXZ_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxEditSXTJ.EditValue.ToString())
            {
                case "材机编号":
                    this.bindingSource1.Filter = string.Format("YSBH like '%{0}%'", this.textEditXXZ.Text.Trim());
                    break;
                case "材机名称":
                    this.bindingSource1.Filter = string.Format("MC like '%{0}%'", this.textEditXXZ.Text.Trim());
                    break;
                case "所有人工":
                    this.bindingSource1.Filter = string.Format("LB in({0})", _Constant.rg);
                    break;
                case "所有材料":
                    this.bindingSource1.Filter = string.Format("LB in({0})", _Constant.cl);
                    break;
                case "所有机械":
                    this.bindingSource1.Filter = string.Format("LB in({0})", _Constant.jx);
                    break;
                default:
                    break;
            }
        }

        private void textEditTZZ_EditValueChanged(object sender, EventArgs e)
        {
            TZJG();
        }

        private void TZJG()
        {
            switch (this.comboBoxEditTZTJ.EditValue.ToString())
            {
                case "调整市场价":
                    if (this.textEditTZZ.Text.ToString().Length > 0)
                    {
                        foreach (DataRowView item in bindingSource1)
                        {
                            item["XGHSCDJ"] = this.textEditTZZ.Value;
                            if (!item["SCDJ"].Equals(0m))
                            {
                                item["TZXS"] = Convert.ToDecimal(item["XGHSCDJ"]) / Convert.ToDecimal(item["SCDJ"]);
                            }
                        }
                    }

                    break;
                case "调整系数值":
                    if (this.textEditTZZ.Text.ToString().Length > 0)
                    {
                        foreach (DataRowView item in bindingSource1)
                        {
                            item["TZXS"] = this.textEditTZZ.Value * 0.01m;
                            item["XGHSCDJ"] = Convert.ToDecimal(item["TZXS"]) * Convert.ToDecimal(item["SCDJ"]);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView m_info = this.bindingSource1.Current as DataRowView;
            if (m_info != null)
            {
                switch (e.Column.FieldName)
                {
                    case "TZXS":
                        m_info["XGHSCDJ"] = Convert.ToDecimal(m_info["TZXS"]) * Convert.ToDecimal(m_info["SCDJ"]);
                        break;
                    case "XGHSCDJ":
                        if (!m_info["SCDJ"].Equals(0m))
                        {
                            m_info["TZXS"] = Convert.ToDecimal(m_info["XGHSCDJ"]) / Convert.ToDecimal(m_info["SCDJ"]);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void comboBoxEditTZTJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            TZJG();
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DataRow row = gv.GetDataRow(e.RowHandle);
            switch (e.Column.FieldName)
            {
                case "SL":
                    decimal d = ToolKit.ParseDecimal(e.CellValue);
                    if (d.Equals(0m))
                    {
                        e.DisplayText = string.Empty;
                    }
                    break;
                case "SSDWGC":
                    if (row != null)
                    {
                        e.DisplayText = GetFiledValue(row["UnID"].ToString(), "Name").ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        private string GetFiledValue(string p_ID, string p_FiledName)
        {
            DataRow r = this.CurrentBusiness.Current.StructSource.ModelProject.GetRowByOther(p_ID.ToString());
            if (r != null)
            {
                return r[p_FiledName].ToString();
            }
            return string.Empty;
        }
    }
}
