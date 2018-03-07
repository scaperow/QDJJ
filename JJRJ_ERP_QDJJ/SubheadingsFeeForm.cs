using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraEditors.Controls;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 分部分项 子目取费
    /// </summary>
    public partial class SubheadingsFeeForm : BaseForm
    {
        /// <summary>
        /// 当前正在操作的子目
        /// </summary>
        private _Methods_Subheadings m_Methods_Subheadings = null;
        public SubheadingsFeeForm()
        {
            InitializeComponent();
        }

        public SubheadingsFeeForm(_Business p_Business, _UnitProject p_Activitie, ABaseForm p_AParentForm)
        {
            this.CurrentBusiness = p_Business;
            this.Activitie = p_Activitie;
            this.AParentForm = p_AParentForm;
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            InitializeComponent();
        }

        private void SubheadingsFeeForm_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = this.Activitie.StructSource.ModelSubheadingsFee.DefaultView;
            //this.graphAnalysis1.DataSource = this.Activitie.StructSource.ModelSubheadingsFee.DefaultView;
            //this.graphAnalysis1.ShowName = "FYLB";
            //this.graphAnalysis1.ValueName = "TBJE";
            this.FillTYLB();
        }

        

        /// <summary>
        /// 根据子目选择
        /// </summary>
        /// <param name="p_info"></param>
        public void DoFilter(_Entity_SubInfo p_info)
        {
            m_Methods_Subheadings.Current = p_info;
            this.Activitie.StructSource.ModelSubheadingsFee.DefaultView.RowFilter = string.Format("ZMID = {0} and SSLB = {1} ", p_info.ID, p_info.SSLB);
            this.FilterControl();
        }

        private void FilterControl()
        {
            this.graphAnalysis1.chartControl1.Series[0].Points.Clear();
            foreach (DataRowView item in this.Activitie.StructSource.ModelSubheadingsFee.DefaultView)
            {
                if (!item["FYLB"].ToString().Equals(string.Empty) && !item["FYLB"].Equals("规费单价") && !item["FYLB"].Equals("税金单价") && !item["FYLB"].Equals("设备费单价"))
                {
                    if (item["FYLB"].Equals("子目单价"))
                    {
                        this.graphAnalysis1.chartControl1.Series[0].Points.Insert(0,new DevExpress.XtraCharts.SeriesPoint("综合单价", ToolKit.ParseDecimal(item["TBJE"])));
                    }
                    else
                    {
                        this.graphAnalysis1.chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(item["FYLB"].ToString(), ToolKit.ParseDecimal(item["TBJE"])));
                    }
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "TBJSJC":
                case "FL":
                case "FYLB":
                    this.m_Methods_Subheadings.Begin(null);
                    if (e.Column.Name == "FYLB")
                    {
                        this.FillTYLB();
                    }
                    this.FilterControl();
                    break;
                default:
                    break;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DataRow view = this.gridView1.GetFocusedDataRow() as DataRow;
            if (view == null) return;
            DataRow[] drs = this.Activitie.StructSource.ModelVariable.Select(string.Format("ID={0} and type={1} and ISDE = 'False'", view["ZMID"], view["SSLB"]));
            if (drs.Length == 0)
            {
                this.m_Methods_Subheadings.ParametersTableCalculate();
            }
            ButtonEdit bt = sender as ButtonEdit;
            SelectVariableForm form = new SelectVariableForm();
            form.Activitie = this.Activitie;
            form.DataSource = this.Activitie.StructSource.ModelVariable;
            form.Filter(ToolKit.ParseInt(view["ZMID"]), ToolKit.ParseInt(view["SSLB"]));
            form.GetValue = bt.Text;
            form.ShowDialog();
            bt.Text = form.GetValue;
        }

        /// <summary>
        /// 费用类别筛选
        /// </summary>
        private void FillTYLB()
        {
            this.repositoryItemComboBox1.Items.Clear();
            this.repositoryItemComboBox1.Items.AddRange(_Constant.FYLB.Split(','));
            foreach (DataRowView item in this.Activitie.StructSource.ModelSubheadingsFee.DefaultView)
            {
                if (!item["FYLB"].Equals(string.Empty) && this.repositoryItemComboBox1.Items.Contains(item["FYLB"].ToString()))
                {
                    this.repositoryItemComboBox1.Items.Remove(item["FYLB"].ToString());
                }
            }
            this.repositoryItemComboBox1.Items.Add(string.Empty);
        }


        private void gridView1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.gridView1_FocusedRowChanged(sender, null);
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView g = sender as GridView;
            if (g.FocusedColumn != null)
            {
                DataRow p_info = this.gridView1.GetFocusedDataRow() as DataRow;
                if (p_info != null)
                {
                    if (g.FocusedColumn.FieldName == "FYLB")
                    {
                        if (p_info["Sort"].Equals(11))
                        {
                            g.FocusedColumn.OptionsColumn.AllowEdit = false;
                        }
                        else
                        {
                            g.FocusedColumn.OptionsColumn.AllowEdit = true;
                        }
                    }
                }
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "FL")
            {
                DataRow ys_info = this.gridView1.GetFocusedDataRow() as DataRow;
                if (ys_info != null)
                {
                    if (ys_info["Sort"].Equals(8) || ys_info["Sort"].Equals(9))
                    {
                        e.RepositoryItem = this.repositoryItemButtonEditFL;
                    }
                }
            }
        }

        private void repositoryItemButtonEditCostSelect_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit bt = sender as ButtonEdit;
            string ftlb = string.Empty;
            DataRow ys_info = this.gridView1.GetFocusedDataRow() as DataRow;
            if (ys_info != null)
            {
                switch (ys_info["Sort"].ToString())
                {
                    case "8":
                        ftlb = "GLFL";
                        break;
                    case "9":
                        ftlb = "LRFL";
                        break;
                    default:
                        break;
                }
            }
            if (ftlb != string.Empty)
            {
                CostSelectForm form = new CostSelectForm();
                form.Xsl = ftlb;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    bt.Text = form.Xz_FL.ToString();
                }
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
					case "BDJE":
                    case "TBJE":
                    case "FL":
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

        public override void LockActivitie()
        {
            //if (this.Activitie == null) return;
            //if (!this.Activitie.IsLock)
            //{
            //    this.gridView1.OptionsBehavior.Editable = false;
                
            //}
            //else
            //{
            //    this.gridView1.OptionsBehavior.Editable = true;
                
            //}
        }
        #region----------------------公共---------------------------------
        public override void Locate(object p_Attr)
        {
            //if (this.m_info != null)
            //{
            //    if (p_Attr is _SubheadingsFeeInfo)
            //    {
            //        this.m_info.SubheadingsQuantityUnitList_BindingSource.Position = this.m_info.SubheadingsQuantityUnitList_BindingSource.IndexOf(p_Attr);
            //    }
            //}
        }
        public override void RefreshDataSource()
        {
            //if (m_info != null)
            //{
            //    this.m_info.SubheadingsFeeList_BindingSource.ResetBindings(false);
            //    this.SubForm.RefreshDataSource();
            //}
        }

        public override void RevocationRefresh()
        {
            //if (m_info != null)
            //{
            //    this.m_info.OnQuantityUnitChange(this, null);
            //    RefreshDataSource();
            //}
        }

        public override void GlobalStyleChange()
        {
            //base.GlobalStyleChange();
            //this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }

        public override void Init()
        {
            //RefreshDataSource();
        }
        #endregion -------------------------------------------------------

    }
}