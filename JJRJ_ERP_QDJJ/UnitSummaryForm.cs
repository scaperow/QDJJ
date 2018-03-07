using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using GLODSOFT.QDJJ.BUSINESS;
using System.IO;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid.Views.Base;
using System.Reflection;
using DevExpress.XtraRichEdit.API.Word;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;
using System.Security.AccessControl;


namespace GOLDSOFT.QDJJ.UI
{
    public partial class UnitSummaryForm : ABaseForm
    {
        private DataSetHelper m_DataSetHelper = new DataSetHelper();
        private _Methods_Quantity m_Methods_Quantity = null;
        private _Methods_YTLBSummary m_Methods_YTLBSummary = null;
        private _Methods_Subheadings m_Methods_Subheadings = null;

        /// <summary>
        /// 设计器支持所需的方法
        /// </summary>
        public UnitSummaryForm()
        {
            InitializeComponent();
        }

        public UnitSummaryForm(_UnitProject p_CUnitProject, _Business p_Business)
        {
            this.Activitie = p_CUnitProject;
            this.CurrentBusiness = p_Business;
            m_Methods_Quantity = new _Methods_Quantity(this.Activitie);
            m_Methods_YTLBSummary = new _Methods_YTLBSummary(this.Activitie);
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            InitializeComponent();
        }

        public override void Init()
        {
            APP.GoldSoftClient.GlodSoftNetWork.Completed();
            if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals(string.Empty) && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals("-1"))
            {
                ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
                //APP.GXKG = m_WebService.GetSharingWwitch(APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
            }
            else
            {
                APP.GXKG = false;
            }

            APP.UserPriceLibrary.AllQuantityUnit = this.Activitie.StructSource.ModelQuantity;
            APP.UserPriceLibrary.UnName = this.Activitie.Name;
            APP.UserPriceLibrary.Range = 0;
            this.quantityUnitTypeTreeList1.DataSource = APP.UserPriceLibrary.AllQuantityUnit.Select(string.Empty, string.Empty, DataViewRowState.CurrentRows).AsEnumerable();
            this.treeList1_Click(null, null);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnitSummaryForm_Load(object sender, EventArgs e)
        {
            if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
            {
                repositoryItemComboBox1.Items.Remove(UseType.甲供材料.ToString());
                repositoryItemComboBox1.Items.Remove(UseType.暂定价材料.ToString());
            }
            else
            {
                if (!repositoryItemComboBox1.Items.Contains(UseType.甲供材料.ToString()))
                {
                    repositoryItemComboBox1.Items.Add(UseType.甲供材料.ToString());
                }
                if (!repositoryItemComboBox1.Items.Contains(UseType.暂定价材料.ToString()))
                {
                    repositoryItemComboBox1.Items.Add(UseType.暂定价材料.ToString());
                }
            }
            this.gridControlYTLB.DataSource = this.Activitie.StructSource.ModelYTLBSummary.DefaultView;
            this.Activitie.StructSource.ModelYTLBSummary.DefaultView.Sort = "BH";
            this.quantityUnitTypeTreeList1.treeList1.Click += new EventHandler(treeList1_Click);
            this.quantityUnitTypeTreeList1.treeList1.SetFocusedNode(this.quantityUnitTypeTreeList1.treeList1.Nodes[0].FirstNode);
            this.Init();
        }

        #region----------------------公用方法---------------------------------
        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "SL":
                    case "XHL":
                    case "YSXHL":
                    case "SCDJ":
                    case "SCHJ":
                    case "DEDJ":
                    case "DEHJ":
                    case "SDCXS":
                    case "SDCHJ":
                    case "DJC":
                    case "HJC":
                    case "JSDJ":
                    case "JSDJC":
                    case "JSHJC":
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

        private void treeListSDC_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "SLH":
                    case "SCHJ":
                    case "DEHJ":
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if (d.Equals(0m))
                        {
                            e.CellText = string.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 系统配色
        /// </summary>
        public override void GlobalStyleChange()
        {
            base.GlobalStyleChange();
            this.bandedGridViewGLJ.UseSpecialColor = true;
            this.bandedGridViewGLJ.ModelName = "工料机汇总-01";
            this.bandedGridViewGLJ.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.bandedGridViewGLJ.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.bandedGridViewGLJ.ColumnColor = APP.DataObjects.GColor.ColumnColor;

            this.bandedGridViewYTLB.UseSpecialColor = true;
            this.bandedGridViewYTLB.ModelName = "工料机汇总-02";
            this.bandedGridViewYTLB.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.bandedGridViewYTLB.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.bandedGridViewYTLB.ColumnColor = APP.DataObjects.GColor.ColumnColor;

            this.treeListSDC.ModelName = "工料机汇总-03";
            this.treeListSDC.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.treeListSDC.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.treeListSDC.ColumnColor = APP.DataObjects.GColor.ColumnColor;


            /*this.bandedGridViewBDGLJ.UseSpecialColor = true;
            this.bandedGridViewBDGLJ.ModelName = "工料机汇总-02";
            this.bandedGridViewBDGLJ.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.bandedGridViewBDGLJ.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.bandedGridViewBDGLJ.ColumnColor = APP.DataObjects.GColor.ColumnColor;*/



            // this.gridViewYHJGKFX.ModelName = "工料机汇总-02";
            // this.gridViewXXJGKFX.ModelName = "工料机汇总-03";
            // this.bandedGridViewGLJ.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            // this.gridViewYHJGKFX.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            // this.gridViewXXJGKFX.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            // DevExpress.Data.ColumnSortOrder s = this.bandedGridColumn2.SortOrder;
            //// this.bandedGridViewGLJ.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            // this.bandedGridColumn2.SortOrder = s;
            // this.gridViewYHJGKFX.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            // this.gridViewXXJGKFX.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
        }

        /// <summary>
        /// 显示控制
        /// </summary>
        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.gridViewXXJGKFX.OptionsBehavior.Editable = false;
                this.gridViewYHJGKFX.OptionsBehavior.Editable = false;
                this.bandedGridViewGLJ.OptionsBehavior.Editable = false;
                this.bandedGridViewYTLB.OptionsBehavior.Editable = false;
                this.barButtonItemDRJG.Enabled = false;
                this.barButtonItemPLSZ.Enabled = false;
                this.barButtonItemZDBD.Enabled = false;
            }
            else
            {
                this.gridViewXXJGKFX.OptionsBehavior.Editable = true;
                this.gridViewYHJGKFX.OptionsBehavior.Editable = true;
                this.bandedGridViewGLJ.OptionsBehavior.Editable = true;
                this.bandedGridViewYTLB.OptionsBehavior.Editable = true;
                this.barButtonItemDRJG.Enabled = true;
                this.barButtonItemPLSZ.Enabled = true;
                this.barButtonItemZDBD.Enabled = true;
            }
        }

        /// <summary>
        /// 筛选控制器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_Click(object sender, EventArgs e)
        {
            if (this.Activitie == null) return;
            TreeListNode tn = this.quantityUnitTypeTreeList1.treeList1.FocusedNode;
            if (tn != null)
            {
                if (tn.GetValue("ValueMember").ToString().Trim() == "全部人材机")
                {
                    this.barCheckItemFJPHB.Enabled = true;
                    this.barCheckItemFJJXTB.Enabled = true;
                }
                else
                {
                    this.barCheckItemFJPHB.Enabled = false;
                    this.barCheckItemFJJXTB.Enabled = false;
                }
                switch (tn.GetValue("ValueMember").ToString().Trim())
                {
                    case "甲供材料":
                    case "暂定价材料":
                        this.bandedGridColumnYTLBSCDJ.OptionsColumn.AllowEdit = true;
                        if (this.Activitie.IsLock) this.EnabledYTLB();
                        this.Activitie.StructSource.ModelYTLBSummary.DefaultView.RowFilter = string.Format("YTLB='{0}'", this.GetTNYTLB().ToString());
                        this.m_Methods_YTLBSummary.RefreshSL();
                        this.gridControlYTLB.BringToFront();
                        this.bandedGridViewYTLB.SelectRow(0);
                        break;
                    case "甲定乙供材料":
                    case "评标指定材料":
                        this.bandedGridColumnYTLBSCDJ.OptionsColumn.AllowEdit = false;
                        if (this.Activitie.IsLock) this.EnabledYTLB();
                        this.Activitie.StructSource.ModelYTLBSummary.DefaultView.RowFilter = string.Format("YTLB='{0}'", this.GetTNYTLB().ToString());
                        this.m_Methods_YTLBSummary.RefreshSL();
                        this.gridControlYTLB.BringToFront();
                        this.bandedGridViewYTLB.SelectRow(0);
                        break;
                    case "三大材汇总":
                        if (this.Activitie.IsLock) this.EnabledSDC();
                        DataTable sdc_dt = m_DataSetHelper.SelectGroupByInto(this.Activitie.StructSource.ModelQuantity.TableName, this.Activitie.StructSource.ModelQuantity, _Constant.gljzd, "", _Constant.hbtjzd);
                        this.treeListSDC.DataSource = this.m_Methods_Quantity.GetSDC(sdc_dt);
                        this.treeListSDC.ExpandAll();
                        this.treeListSDC.BringToFront();
                        break;
                    default:
                        if (this.Activitie.IsLock) this.EnabledGLJ();
                        this.gridControlGLJ.DataSource = this.DecompositionFilter(this.quantityUnitTypeTreeList1.DataSource).DefaultView;
                        this.splitContainerControl2.BringToFront();
                        break;
                }
            }
        }

        /// <summary>
        /// 工料机汇总分解过滤
        /// </summary>
        /// <param name="p_list"></param>
        /// <returns></returns>
        private DataTable DecompositionFilter(IEnumerable<DataRow> p_list)
        {
            if (p_list.Count() == 0) return new DataTable();
            DataTable p_dt = p_list.CopyToDataTable();
            if (this.barCheckItemFJPHB.Checked && this.barCheckItemFJJXTB.Checked)
            {
                p_dt = m_DataSetHelper.SelectGroupByInto(p_dt.TableName, p_dt, _Constant.gljzd, "", _Constant.hbtjzd);
            }
            if (!this.barCheckItemFJPHB.Checked && !this.barCheckItemFJJXTB.Checked)
            {
                p_dt = m_DataSetHelper.SelectGroupByInto(p_dt.TableName, p_dt, _Constant.gljzd, "ZCLB='W'", _Constant.hbtjzd);
            }
            if (this.barCheckItemFJPHB.Checked && !this.barCheckItemFJJXTB.Checked)
            {
                p_dt = m_DataSetHelper.SelectGroupByInto(p_dt.TableName, p_dt, _Constant.gljzd, "ZCLB='W' or ZCLB='P'", _Constant.hbtjzd);
            }
            if (!this.barCheckItemFJPHB.Checked && this.barCheckItemFJJXTB.Checked)
            {
                p_dt = m_DataSetHelper.SelectGroupByInto(p_dt.TableName, p_dt, _Constant.gljzd, "ZCLB='W' or ZCLB='J'", _Constant.hbtjzd);
            }
            p_dt.Columns["SCHJ"].Expression = "SCDJ * SL";
            p_dt.Columns["DEHJ"].Expression = "DEDJ * SL";
            p_dt.Columns["HJC"].Expression = "SCHJ-DEHJ";
            return p_dt;
        }
        #endregion

        #region----------------------工料机方法---------------------------------
        /// <summary>
        /// 工料机提交时验证是否合法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridViewGLJ_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (this.bandedGridViewGLJ.FocusedColumn == null) return;
            if (this.bandedGridViewGLJ.FocusedColumn.FieldName == "YTLB")
            {
                DataRow m_Current = this.bandedGridViewGLJ.GetFocusedDataRow();
                if (m_Current != null)
                {
                    if (!e.Value.Equals(string.Empty))
                    {
                        DataRow m_YTLB = m_Methods_YTLBSummary.GetBindingInfo(m_Current["BH"].ToString());
                        if (m_YTLB != null)
                        {
                            e.ErrorText = "【" + m_Current["BH"].ToString() + "】已存在【" + m_YTLB["YTLB"].ToString() + "】 \n请清理后在设置\n请按Esc恢复";
                            e.Valid = false;
                        }
                    }
                }
            }
            //e.Valid = true;
        }

        /// <summary>
        /// 获取当前操作的工料机
        /// </summary>
        private void GetCurrent()
        {
            DataRow dr = this.bandedGridViewGLJ.GetFocusedDataRow();
            if (dr != null)
            {
                this.m_Methods_Quantity.Current = dr;
            }
        }

        /// <summary>
        /// 工料机修改后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridViewGLJ_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataRow dr = this.bandedGridViewGLJ.GetFocusedDataRow();
            if (dr == null) return;
            this.bandedGridViewGLJ.UpdateCurrentRow();
            this.NewMethod();
            switch (e.Column.FieldName)
            {
                case "MC":
                case "DW":
                case "SCDJ":
                    APP.UserPriceLibrary.Update(e.Column.FieldName, dr[e.Column.FieldName, DataRowVersion.Current], dr);
                    if (e.Column.FieldName == "SCDJ")
                    {
                        m_Methods_YTLBSummary.RefreshSCDJ(dr);
                    }
                    this.m_Methods_Subheadings.BatchCalculate();
                    int m_TopRowIndex = this.bandedGridViewGLJ.TopRowIndex;
                    int index = this.bandedGridViewGLJ.FocusedRowHandle;
                    this.treeList1_Click(null, null);
                    this.bandedGridViewGLJ.TopRowIndex = m_TopRowIndex;
                    this.bandedGridViewGLJ.FocusedRowHandle = index;
                    break;
                case "YTLB":
                    if (e.Value.Equals(string.Empty)) return;

                    DataRow[] drs_YTLB = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", dr["BH"]));
                    foreach (DataRow item in drs_YTLB)
                    {
                        item.BeginEdit();
                        item[e.Column.FieldName] = e.Value;
                        item.EndEdit();
                        string m_NewSubheadings = item["EnID"] + "," + item["UnID"] + "," + item["SSLB"] + "," + item["ZMID"] + "|";
                        if (!APP.UserPriceLibrary.SubheadingsInfo.Contains(m_NewSubheadings))
                        {
                            APP.UserPriceLibrary.SubheadingsInfo += m_NewSubheadings;
                        }
                    }
                    this.m_Methods_YTLBSummary.Insert(drs_YTLB.FirstOrDefault(), true);
                    this.m_Methods_Subheadings.BatchCalculate();
                    break;
                case "DJC":
                    DataRow[] drs_DJC = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", dr["BH"]));
                    foreach (DataRow item in drs_DJC)
                    {
                        item.BeginEdit();
                        item[e.Column.FieldName] = e.Value;
                        item.EndEdit();
                        string m_NewSubheadings = item["EnID"] + "," + item["UnID"] + "," + item["SSLB"] + "," + item["ZMID"] + "|";
                        if (!APP.UserPriceLibrary.SubheadingsInfo.Contains(m_NewSubheadings))
                        {
                            APP.UserPriceLibrary.SubheadingsInfo += m_NewSubheadings;
                        }
                    }
                    this.m_Methods_Subheadings.BatchCalculate();
                    break;
                default:
                    DataRow[] drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", dr["BH"]));
                    foreach (DataRow item in drs)
                    {
                        item.BeginEdit();
                        item[e.Column.FieldName] = e.Value;
                        item.EndEdit();
                    }
                    break;
            }
        }

        private void NewMethod()
        {
            APP.UserPriceLibrary.AllQuantityUnit = this.Activitie.StructSource.ModelQuantity;
            APP.UserPriceLibrary.UnName = this.Activitie.Name;
            APP.UserPriceLibrary.Range = 0;
        }
        /// <summary>
        /// 锁定工料机列编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.gridView_FocusedRowChanged(sender, null);
        }
        /// <summary>
        /// 锁定工料机行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.GetCurrent();
            this.FocusedRowChanged();
            GridView m_GridView = sender as GridView;
            if (m_GridView.FocusedColumn != null)
            {
                if (this.m_Methods_Quantity.Current != null)
                {
                    switch (m_GridView.FocusedColumn.FieldName)
                    {
                        case "DW":
                        case "MC":
                            if (!this.m_Methods_Quantity.Current["YTLB"].Equals(string.Empty))
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                            else
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            break;
                        case "SCDJ":
                            if (this.m_Methods_Quantity.Current["IFKFJ"].Equals(true) || this.m_Methods_Quantity.Current["LB"].ToString().Contains("%") || this.m_Methods_Quantity.Current["IFSDSCDJ"].Equals(true) || this.m_Methods_Quantity.Current["YTLB"].Equals(UseType.甲供材料.ToString()) || this.m_Methods_Quantity.Current["YTLB"].Equals(UseType.暂定价材料.ToString()))
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                            else
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            break;
                        case "YTLB":
                            if (!this.m_Methods_Quantity.Current["YTLB"].Equals(string.Empty) || this.m_Methods_Quantity.Current["IFKFJ"].Equals(true) || (!this.m_Methods_Quantity.Current["LB"].Equals("材料") && !this.m_Methods_Quantity.Current["LB"].Equals("设备") && !this.m_Methods_Quantity.Current["LB"].Equals("主材")))
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                            else
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            break;
                        case "IFFX":
                            if (this.m_Methods_Quantity.Current["IFKFJ"].Equals(true) || _Constant.IFJSFX.Contains("'" + this.m_Methods_Quantity.Current["LB"].ToString() + "'"))
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                            else
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region----------------------用户价格库方法---------------------------------

        private void FocusedRowChanged()
        {
            if (this.m_Methods_Quantity.Current != null)
            {
                if (this.m_Methods_Quantity.Current["LB"].Equals("材料") || this.m_Methods_Quantity.Current["LB"].Equals("主材") || this.m_Methods_Quantity.Current["LB"].Equals("设备"))
                {
                    this.splitContainerControl2.PanelVisibility = SplitPanelVisibility.Both;
                    DataRow[] yh_list = APP.UserPriceLibrary.UserPriceLibrarySource.Select(string.Format("YSBH='{0}'", this.m_Methods_Quantity.Current["YSBH"]));
                    if (yh_list.Count() != 0)
                    {
                        this.gridControlYHJGKFX.DataSource = yh_list.CopyToDataTable();
                        this.pieChart1.DataSource = this.gridControlYHJGKFX.DataSource;
                        this.pieChart1.ShowName = "SSDWGC";
                        this.pieChart1.ValueName = "SCDJ";
                    }
                    else
                    {
                        this.gridControlYHJGKFX.DataSource = null;
                        this.pieChart1.DataSource = null;
                        this.pieChart1.ShowName = "";
                        this.pieChart1.ValueName = "";
                    }

                    APP.GoldSoftClient.GlodSoftNetWork.Completed();
                    if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals(string.Empty) && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals("-1") && APP.GXKG)
                    {
                        DataRow[] xx_list = APP.InformationPriceLibrary.InformationPriceLibrarySource.Select(string.Format("BH='{0}'", this.m_Methods_Quantity.Current["YSBH"]));
                        if (xx_list.Count() != 0)
                        {
                            this.gridControlXXJGKFX.DataSource = xx_list.CopyToDataTable();
                            this.pieChart2.DataSource = this.gridControlXXJGKFX.DataSource;
                            this.pieChart2.ShowName = "DJ";
                            this.pieChart2.ValueName = "DJ";
                        }
                        else
                        {
                            this.gridControlXXJGKFX.DataSource = null;
                            this.pieChart2.DataSource = null;
                            this.pieChart2.ShowName = "";
                            this.pieChart2.ValueName = "";
                        }
                    }
                    else
                    {
                        APP.GXKG = false;
                        this.gridControlXXJGKFX.DataSource = null;
                        this.pieChart2.DataSource = null;
                        this.pieChart2.ShowName = "";
                        this.pieChart2.ValueName = "";
                    }
                }
                else
                {
                    this.splitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1;
                }
            }
            else
            {
                this.splitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1;
            }
        }
        /// <summary>
        /// 用户价格库-双击替换-工料机选中行（价格）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewYHJGKFX_DoubleClick(object sender, EventArgs e)
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock) return;
            DataRow drv = this.bandedGridViewGLJ.GetFocusedDataRow();
            if (drv == null) return;
            DataRowView u_info = this.gridViewYHJGKFX.GetFocusedRow() as DataRowView;
            if (drv != null && u_info != null)
            {
                if (drv["BH"].Equals(u_info["BH"]))
                {
                    DataRow dr = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", drv["BH"])).FirstOrDefault();
                    if (dr != null)
                    {
                        if (!dr["SCDJ"].Equals(u_info["SCDJ"]))
                        {
                            NewMethod();
                            int index = this.bandedGridViewGLJ.FocusedRowHandle;
                            dr.BeginEdit();
                            dr["SCDJ"] = u_info["SCDJ"];
                            APP.UserPriceLibrary.Update("SCDJ", dr["SCDJ", DataRowVersion.Current], dr);
                            dr.BeginEdit();
                            this.m_Methods_Subheadings.BatchCalculate();
                            this.treeList1_Click(null, null);
                            this.bandedGridViewGLJ.FocusedRowHandle = index;
                        }
                    }
                }
            }
        }
        #endregion

        #region----------------------云价格库方法---------------------------------
        /// <summary>
        /// 云价格库-双击替换-工料机选中行（价格）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewXXJGKFX_DoubleClick(object sender, EventArgs e)
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock) return;
            DataRow drv = this.bandedGridViewGLJ.GetFocusedDataRow();
            if (drv == null) return;
            DataRowView u_info = this.gridViewXXJGKFX.GetFocusedRow() as DataRowView;
            if (drv != null && u_info != null)
            {
                if (drv["BH"].Equals(u_info["BH"]))
                {
                    DataRow dr = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", drv["BH"])).FirstOrDefault();
                    if (dr != null)
                    {
                        if (!dr["SCDJ"].Equals(u_info["DJ"]))
                        {
                            NewMethod();
                            int index = this.bandedGridViewGLJ.FocusedRowHandle;
                            dr.BeginEdit();
                            dr["SCDJ"] = u_info["DJ"];
                            APP.UserPriceLibrary.Update("SCDJ", dr["SCDJ", DataRowVersion.Current], dr);
                            dr.BeginEdit();
                            this.m_Methods_Subheadings.BatchCalculate();
                            this.treeList1_Click(null, null);
                            this.bandedGridViewGLJ.FocusedRowHandle = index;
                        }
                    }
                }
            }
        }
        #endregion

        #region----------------------用途类别方法---------------------------------
        private void bandedGridViewYTLB_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.bandedGridViewYTLB_FocusedColumnChanged(sender, null);
        }

        private void bandedGridViewYTLB_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            DataRowView drv = this.bandedGridViewYTLB.GetFocusedRow() as DataRowView;
            if (drv != null)
            {
                //if (drv["DZBS"].Equals(true) && !APP.Jzbx_pwd)
                //{
                //    this.bandedGridViewYTLB.OptionsBehavior.Editable = false;
                //}
                //else
                //{
                //    this.bandedGridViewYTLB.OptionsBehavior.Editable = true;
                //}
                this.bandedGridViewYTLB.OptionsBehavior.Editable = true;

                //this.bandedGridViewYTLB.OptionsBehavior.Editable = !drv["DZBS"].Equals(true);
            }
        }
        /// <summary>
        /// 用途类别修改后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridViewYTLB_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "SCDJ":
                    DataRow drv = this.bandedGridViewYTLB.GetFocusedDataRow();
                    if (drv != null)
                    {
                        if (!drv["BDBH"].Equals(string.Empty))
                        {
                            DataRow dr = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", drv["BDBH"])).FirstOrDefault();
                            if (dr != null)
                            {
                                NewMethod();
                                dr.BeginEdit();
                                dr[e.Column.FieldName] = e.Value;
                                APP.UserPriceLibrary.Update("SCDJ", dr[e.Column.FieldName, DataRowVersion.Current], dr);
                                dr.EndEdit();
                                this.m_Methods_Subheadings.BatchCalculate();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 双击绑定材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRow drv = this.bandedGridViewBDGLJ.GetFocusedDataRow();
            if (drv != null)
            {
                DataRow m_YTLBSummaryInfo = this.bandedGridViewYTLB.GetFocusedDataRow();
                if (m_YTLBSummaryInfo != null)
                {
                    this.m_Methods_YTLBSummary.Replace(m_YTLBSummaryInfo, drv);
                    this.bandedGridViewYTLB.HideEditor();
                    this.m_Methods_Subheadings.BatchCalculate();
                }
            }
        }

        /// <summary>
        /// 绑定编号事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridViewYTLB_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "BDBH")
            {
                this.gridControlBDGLJ.DataSource = m_DataSetHelper.SelectGroupByInto(this.Activitie.StructSource.ModelQuantity.TableName, this.Activitie.StructSource.ModelQuantity, _Constant.gljzd, string.Format("YTLB='{0}' AND LB='材料'", string.Empty), _Constant.hbtjzd);
            }
        }
        /// <summary>
        /// 用途类别右键出发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridViewYTLB_MouseUp(object sender, MouseEventArgs e)
        {
            GridView gc = sender as GridView;
            GridHitInfo info = gc.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    switch (GetTNYTLB().ToString())
                    {
                        case "甲供材料":
                        case "暂定价材料":
                            this.bbiExtraction.Enabled = false;
                            this.bbiManualAdd.Enabled = false;
                            this.bbiDelete.Enabled = false;
                            this.bbiCancelBinding.Enabled = false;
                            break;
                        case "甲定乙供材料":
                        case "评标指定材料":
                            this.bbiExtraction.Enabled = true;
                            this.bbiManualAdd.Enabled = true;
                            this.bbiCancelBinding.Enabled = true;
                            this.bbiDelete.Enabled = true;
                            foreach (int item in gc.GetSelectedRows())
                            {
                                DataRowView drv = gc.GetRow(item) as DataRowView;
                                if (drv != null)
                                {
                                    if (drv["DZBS"].Equals(true))
                                    {
                                        this.bbiDelete.Enabled = false;
                                        break;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        /// <summary>
        /// 用途类别右键处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemYJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "bbiExtraction": //提取材料
                    InsertQuantityUnitSummary i_form = new InsertQuantityUnitSummary();
                    i_form.DataSource = m_DataSetHelper.SelectGroupByInto(this.Activitie.StructSource.ModelQuantity.TableName, this.Activitie.StructSource.ModelQuantity, _Constant.gljzd, string.Format("YTLB='{0}' AND (LB='材料'  OR LB='主材'  OR LB='设备')", string.Empty), _Constant.hbtjzd);
                    i_form.Activitie = this.Activitie;
                    i_form.simpleButton1.Enabled = false;
                    DialogResult i_r = i_form.ShowDialog();
                    if (i_r == DialogResult.OK)
                    {
                        DataRow new_info = i_form.GetNewInfo();
                        if (new_info["LB"].Equals("材料"))
                        {
                            new_info["YTLB"] = GetTNYTLB().ToString();
                            DataRow ys = this.m_Methods_YTLBSummary.Insert(0, new_info, false);
                            if (ys == null)
                            {
                                treeList1_Click(null, null);
                                this.Activitie.BeginEdit(this);
                            }
                            else
                            {
                                MsgBox.Alert(new_info["BH"].ToString() + "-已存在【" + ys["YTLB"].ToString() + "】");
                            }
                        }
                        else
                        {
                            MsgBox.Alert("只允许添加材料");
                        }
                    }
                    break;
                case "bbiManualAdd"://手动增加
                    InsertYTLBSummaryForm form = new InsertYTLBSummaryForm(this.CurrentBusiness, this.Activitie);
                    DialogResult r = form.ShowDialog();
                    if (r == DialogResult.OK)
                    {
                        DataRow new_info = form.GetInfo;
                        new_info["YTLB"] = GetTNYTLB().ToString();
                        DataRow sys = this.m_Methods_YTLBSummary.Insert(0, new_info, false);
                        if (sys == null)
                        {
                            //treeList1_Click(null, null);
                            //this.Activitie.BeginEdit(this);
                        }
                        else
                        {
                            MsgBox.Alert(new_info["BH"].ToString() + "-已存在【" + sys["YTLB"].ToString() + "】");
                        }
                        break;
                    }
                    break;
                case "bbiDelete"://删除当前所选
                    DialogResult dr = MsgBox.Show("确认删除？", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ArrayList m_ArrayList = new ArrayList();
                        foreach (int index in this.bandedGridViewYTLB.GetSelectedRows())
                        {
                            DataRowView item = bandedGridViewYTLB.GetRow(index) as DataRowView;
                            if (item != null)
                            {
                                m_ArrayList.Add(item);
                            }
                        }
                        foreach (DataRowView item in m_ArrayList)
                        {
                            this.m_Methods_YTLBSummary.Remove(item.Row);
                        }
                        m_ArrayList = null;
                        this.m_Methods_Subheadings.BatchCalculate();
                        //this.Activitie.BeginEdit(this);
                    }
                    break;
                case "bbiCancelBinding"://取消当前所选绑定
                    DialogResult drs = MsgBox.Show("确认取消绑定吗？", MessageBoxButtons.YesNo);
                    if (drs == DialogResult.Yes)
                    {
                        foreach (int index in this.bandedGridViewYTLB.GetSelectedRows())
                        {
                            DataRowView item = bandedGridViewYTLB.GetRow(index) as DataRowView;
                            if (item != null)
                            {
                                this.m_Methods_YTLBSummary.CanceledBinding(item.Row);
                            }
                        }
                        this.m_Methods_Subheadings.BatchCalculate();
                        //this.Activitie.BeginEdit(this);
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 获取当前筛选类别
        /// </summary>
        /// <param name="tn"></param>
        /// <returns></returns>
        private string GetTNYTLB()
        {
            TreeListNode tn = this.quantityUnitTypeTreeList1.treeList1.FocusedNode;
            string rytln = string.Empty;
            switch (tn.GetValue("ValueMember").ToString().Trim())
            {
                case "甲供材料":
                    rytln = UseType.甲供材料.ToString();
                    break;
                case "甲定乙供材料":
                    rytln = UseType.甲定乙供材料.ToString();
                    break;
                case "评标指定材料":
                    rytln = UseType.评标指定材料.ToString();
                    break;
                case "暂定价材料":
                    rytln = UseType.暂定价材料.ToString();
                    break;
                default:
                    break;
            }
            return rytln;
        }

        #endregion

        #region----------------------按钮方法---------------------------------
        /// <summary>
        /// 按钮功能控制
        /// </summary>
        private void EnabledGLJ()
        {
            this.bar1.Visible = true;
            this.barButtonItemPLSZ.Visibility = BarItemVisibility.Always;
            this.barButtonItemJGCX.Visibility = BarItemVisibility.Always;
            this.barButtonItemZDBD.Visibility = BarItemVisibility.Never;
        }

        /// <summary>
        /// 按钮功能控制
        /// </summary>
        private void EnabledYTLB()
        {
            this.bar1.Visible = true;
            this.barButtonItemPLSZ.Visibility = BarItemVisibility.Never;
            this.barButtonItemJGCX.Visibility = BarItemVisibility.Never;
            this.barButtonItemZDBD.Visibility = BarItemVisibility.Always;
        }

        /// <summary>
        /// 按钮功能控制
        /// </summary>
        private void EnabledSDC()
        {
            this.bar1.Visible = false;
        }

        /// <summary>
        /// 分解按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barCheckItemFJ_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarCheckItem ce = sender as BarCheckItem;
            if (ce.Checked)
            {
                DialogResult dl = MsgBox.Show("您确定要-" + ce.Caption + "吗？", MessageBoxButtons.YesNo);
                if (dl == DialogResult.Yes)
                {
                    this.gridControlGLJ.DataSource = this.DecompositionFilter(this.quantityUnitTypeTreeList1.DataSource);
                }
                else
                {
                    ce.Checked = false;
                }
            }
            else
            {
                this.gridControlGLJ.DataSource = this.DecompositionFilter(this.quantityUnitTypeTreeList1.DataSource);
            }
        }

        /// <summary>
        /// 材机反差
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCJFC_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListNode tn = this.quantityUnitTypeTreeList1.treeList1.FocusedNode;
            if (tn == null) return;
            PeggingForm form = new PeggingForm();
            form.Activitie = this.Activitie;
            switch (tn.GetValue("ValueMember").ToString().Trim())
            {
                case "甲供材料":
                case "甲定乙供材料":
                case "评标指定材料":
                case "暂定价材料":
                    form.Current = this.bandedGridViewYTLB.GetFocusedDataRow();
                    break;
                default:
                    form.Current = this.bandedGridViewGLJ.GetFocusedDataRow();
                    break;
            }
            DialogResult r = form.ShowDialog();
            switch (r)
            {
                case DialogResult.OK:
                    this.ProjectsForm.barButtonItem5_ItemClick(this.ProjectsForm.barButtonItem5, new DevExpress.XtraBars.ItemClickEventArgs(this.ProjectsForm.barButtonItem5, this.ProjectsForm.barButtonItem5.Links[0]));
                    this.ProjectsForm.barButtonItem5.PerformClick();
                    SubSegmentForm form1 = this.ProjectsForm.GetWorkAreas as SubSegmentForm;
                    if (form1 != null) form1.subSegmentListData1.FocusedNode(form.GetID);
                    break;
                case DialogResult.Yes:
                    this.ProjectsForm.barButtonItem5_ItemClick(this.ProjectsForm.barButtonItem6, new DevExpress.XtraBars.ItemClickEventArgs(this.ProjectsForm.barButtonItem6, this.ProjectsForm.barButtonItem6.Links[0]));
                    this.ProjectsForm.barButtonItem6.PerformClick();
                    MeasuresProjectForm form2 = this.ProjectsForm.GetWorkAreas as MeasuresProjectForm;
                    if (form2 != null) form2.FocusedNode(form.GetID);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemPLSZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            BatchSetForm form = new BatchSetForm();
            form.Activitie = this.Activitie;
            DataView dt = this.gridControlGLJ.DataSource as DataView;
            if (dt != null && dt.Count > 0)
            {
                DataRow[] drs = dt.Table.Select("LB='人工' or LB ='材料' or LB ='机械' or LB ='主材' or LB ='设备'");
                if (drs.Length > 0)
                {
                    NewMethod();
                    form.DataSource = drs.CopyToDataTable();
                    DialogResult r = form.ShowDialog();
                    if (r == DialogResult.OK)
                    {
                        int index = this.bandedGridViewGLJ.FocusedRowHandle;
                        this.treeList1_Click(null, null);
                        this.bandedGridViewGLJ.FocusedRowHandle = index;
                    }
                }
            }
        }

        /// <summary>
        /// 自动绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemZDBD_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewMethod();
            this.m_Methods_YTLBSummary.AutoBindingInfo(GetTNYTLB());
            this.m_Methods_Subheadings.BatchCalculate();
            this.Activitie.BeginEdit(this);
        }

        /// <summary>
        /// 价格查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemJGCX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.GetCurrent();
            this.bandedGridViewGLJ.UpdateCurrentRow();
            if (this.m_Methods_Quantity.Current == null) return;
            if (this.m_Methods_Quantity.Current["IFSDSCDJ"].Equals(true) || !this.m_Methods_Quantity.Current["YTLB"].Equals(string.Empty))
            {
                MsgBox.Alert("当前材料价格不允许变更");
                return;
            }

            if (this.m_Methods_Quantity.Current["LB"].Equals("人工") || this.m_Methods_Quantity.Current["LB"].Equals("材料") || this.m_Methods_Quantity.Current["LB"].Equals("设备") || this.m_Methods_Quantity.Current["LB"].Equals("机械") || this.m_Methods_Quantity.Current["LB"].Equals("主材"))
            {
                NewMethod();
                PriceSettingForm form = new PriceSettingForm();
                form.Activitie = this.Activitie;
                form.Current = this.m_Methods_Quantity.Current;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    int index = this.bandedGridViewGLJ.FocusedRowHandle;
                    this.treeList1_Click(null, null);
                    this.bandedGridViewGLJ.FocusedRowHandle = index;
                    this.m_Methods_Subheadings.BatchCalculate();
                }
            }
        }

        /// <summary>
        /// 导入价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDRJG_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.openFileDialogDR.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(this.openFileDialogDR.FileName);
                if (!file.Exists)
                {
                    throw new Exception("文件不存在");
                }
                string extension = file.Extension;
                string strConn = "";
                switch (extension)
                {
                    case ".xls":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.openFileDialogDR.FileName + "; Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                        break;
                    case ".xlsx":
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.openFileDialogDR.FileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                        break;
                    default:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.openFileDialogDR.FileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                        break;
                }
                DataTable dt = new DataTable();
                OleDbConnection oleConn = new OleDbConnection(strConn);
                try
                {
                    oleConn.Open();
                    //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等
                    DataTable dtSheetName = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                    string strSql = "SELECT * FROM [" + dtSheetName.TableName + "]";
                    OleDbCommand oleCom = new OleDbCommand(strSql, oleConn);
                    using (OleDbDataReader rdr = oleCom.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
                catch (Exception)
                {
                    MsgBox.Alert("文件被占用请重试");
                    return;
                }

                if (dt.Columns.Contains("材料编号") && dt.Columns.Contains("材料名称") && dt.Columns.Contains("材料市场价"))
                {
                    NewMethod();
                    TreeListNode tn = this.quantityUnitTypeTreeList1.treeList1.FocusedNode;
                    switch (tn.GetValue("ValueMember").ToString().Trim())
                    {
                        case "甲供材料":
                        case "暂定价材料":
                        case "甲定乙供材料":
                        case "评标指定材料":
                            bool ifcfytlb = false;
                            int indexytlb = this.bandedGridViewGLJ.FocusedRowHandle;
                            DataView ytlbdt = this.gridControlYTLB.DataSource as DataView;
                            if (ytlbdt != null)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    DataRow ytlbdr = ytlbdt.Table.Select(string.Format("(BDBH='{0}' OR BH='{0}') AND YTLB='{1}' AND SCDJ <> {2}", dr["材料编号"], tn.GetValue("ValueMember").ToString(), ToolKit.ParseDecimal(dr["材料市场价"]))).FirstOrDefault();
                                    if (ytlbdr != null)
                                    {
                                        ytlbdr["SCDJ"] = ToolKit.ParseDecimal(dr["材料市场价"]);
                                        if (!ytlbdr["BDBH"].Equals(string.Empty))
                                        {
                                            DataRow gljdrs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}' AND SCDJ <> {1}", dr["材料编号"], ToolKit.ParseDecimal(dr["材料市场价"]))).FirstOrDefault();
                                            if (gljdrs != null)
                                            {
                                                gljdrs.BeginEdit();
                                                gljdrs["SCDJ"] = ToolKit.ParseDecimal(dr["材料市场价"]);
                                                APP.UserPriceLibrary.Update("SCDJ", gljdrs["SCDJ", DataRowVersion.Current], gljdrs);
                                                gljdrs.EndEdit();
                                                ifcfytlb = true;
                                            }
                                        }
                                    }
                                }
                                if (ifcfytlb)
                                {
                                    this.treeList1_Click(null, null);
                                    this.bandedGridViewGLJ.FocusedRowHandle = indexytlb;
                                    this.m_Methods_Subheadings.BatchCalculate();
                                }
                            }
                            break;
                        default:
                            bool ifcfglj = false;
                            int indexglj = this.bandedGridViewGLJ.FocusedRowHandle;
                            DataView gljdt = this.gridControlGLJ.DataSource as DataView;
                            if (gljdt != null)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    DataRow gljdrs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("IFSDSCDJ='False' AND YTLB='{0}' AND BH='{1}' AND SCDJ <> {2} ", string.Empty, dr["材料编号"], ToolKit.ParseDecimal(dr["材料市场价"]))).FirstOrDefault();
                                    if (gljdrs != null)
                                    {
                                        gljdrs.BeginEdit();
                                        gljdrs["SCDJ"] = ToolKit.ParseDecimal(dr["材料市场价"]);
                                        APP.UserPriceLibrary.Update("SCDJ", gljdrs["SCDJ", DataRowVersion.Current], gljdrs);
                                        gljdrs.EndEdit();
                                        ifcfglj = true;
                                    }
                                }
                                if (ifcfglj)
                                {
                                    this.treeList1_Click(null, null);
                                    this.bandedGridViewGLJ.FocusedRowHandle = indexglj;
                                    this.m_Methods_Subheadings.BatchCalculate();
                                }
                            }
                            break;
                    }
                }
                else
                {
                    MsgBox.Alert("请导入正确格式的内容");
                }
            }
        }

        /// <summary>
        /// 导出价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDCJG_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.saveFileDialogDC.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "导出价格";
            if (saveFileDialogDC.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(this.saveFileDialogDC.FileName))
                {
                    try
                    {
                        File.Delete(this.saveFileDialogDC.FileName);
                    }
                    catch (Exception)
                    {
                        MsgBox.Alert("文件被占用请重试");
                        return;
                    }
                }
                //File.Create(this.saveFileDialogDC.FileName);

                string strConn = string.Empty;

                switch (this.saveFileDialogDC.FilterIndex)
                {
                    case 1:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.saveFileDialogDC.FileName + ";Extended Properties=Excel 8.0;";
                        break;
                    case 2:
                        //strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=;Extended properties='Excel 12.0 xml';Data Source=" + this.saveFileDialogDC.FileName;

                        strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.saveFileDialogDC.FileName + ";Extended Properties='Excel 12.0 Xml;'";
                        break;
                    default:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.saveFileDialogDC.FileName + ";Extended Properties=Excel 8.0;";
                        break;
                }
                string sqlCreate = @"CREATE TABLE [tables] ([材料编号] VarChar, [材料名称] VarChar, [材料市场价] VarChar)";

                OleDbConnection cn = new OleDbConnection(strConn);
                OleDbCommand cmd = new OleDbCommand(sqlCreate, cn);
                cn.Open();
                cmd.ExecuteNonQuery();


                DataRow[] list = null;
                TreeListNode tn = this.quantityUnitTypeTreeList1.treeList1.FocusedNode;
                switch (tn.GetValue("ValueMember").ToString().Trim())
                {
                    case "甲供材料":
                    case "甲定乙供材料":
                    case "评标指定材料":
                    case "暂定价材料":
                        DataView ytlbdt = this.gridControlYTLB.DataSource as DataView;
                        if (ytlbdt != null)
                        {
                            list = ytlbdt.Table.Select(string.Format("YTLB='{0}' AND SCDJ <> DEDJ", tn.GetValue("ValueMember").ToString())).ToArray();
                        }
                        break;
                    default:
                        DataView gljdt = this.gridControlGLJ.DataSource as DataView;
                        if (gljdt != null)
                        {
                            list = gljdt.Table.Select("SCDJ <> DEDJ").ToArray();
                        }
                        break;
                }
                if (list == null) return;
                foreach (DataRow item in list)
                {
                    string queryString = string.Format("INSERT INTO [tables] ([材料编号], [材料名称], [材料市场价]) VALUES ('{0}', '{1}', '{2}')", item["BH"].ToString(), item["MC"].ToString(), item["SCDJ"].ToString());
                    cmd.CommandText = queryString;
                    cmd.ExecuteNonQuery();
                }

                cmd.Dispose();
                cn.Close();
            }
        }
        #endregion

        private void bandedGridViewGLJ_SetRowColorChange(object p_RowObject, _SchemeColor p_SchemeColor, DevExpress.Utils.AppearanceObject appearance)
        {
            DataRowView info = (p_RowObject as DataRowView);
            if (info != null)
            {
                if (info["YSBH"].Equals(info["BH"]) && info["YSDW"].Equals(info["DW"]) && info["YSMC"].Equals(info["MC"]) && !info["SCDJ"].Equals(info["DEDJ"]))
                {
                    //获取特殊样式绑定颜色
                    _SpecialStyleInfo style = p_SchemeColor.SpecialStyle.Get("市场单价修改");
                    if (style != null)
                    {
                        appearance.Font = new System.Drawing.Font(appearance.Font.FontFamily, appearance.Font.Size, style.Font);
                        //字体颜色
                        appearance.ForeColor = style.ForeColor.IsEmpty ? appearance.ForeColor : style.ForeColor;
                        //背景颜色
                        appearance.BackColor = style.BColor.IsEmpty ? appearance.BackColor : style.BColor;

                        appearance.BackColor2 = style.BColor2.IsEmpty ? appearance.BackColor2 : style.BColor2;
                    }
                }
            }
        }

        private void bandedGridViewGLJ_SetRowCellColorStyle(object sender, GOLDSOFT.QDJJ.CTRL.BandedGridViewEx.CellColorArgs e)
        {
            DataRowView info = (e.RowObject as DataRowView);
            if (info != null)
            {
                if (e.Column.FieldName == "SCDJ")
                {
                    if (!info["SCDJ"].Equals(info["DEDJ"]))
                    {

                        //获取特殊样式绑定颜色
                        _SpecialStyleInfo style = e.SchemeColor.SpecialStyle.Get("市场单价修改");
                        if (style != null)
                        {
                            e.Appearance.Font = new System.Drawing.Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, style.Font);
                            //字体颜色
                            e.Appearance.ForeColor = style.ForeColor.IsEmpty ? e.Appearance.ForeColor : style.ForeColor;
                            //背景颜色
                            e.Appearance.BackColor = style.BColor.IsEmpty ? e.Appearance.BackColor : style.BColor;

                            e.Appearance.BackColor2 = style.BColor2.IsEmpty ? e.Appearance.BackColor2 : style.BColor2;
                        }
                    }
                }
            }
        }

        private void Raisecolumns_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DisplayColumns(this.bandedGridViewGLJ);
        }

        private void bandedGridViewGLJ_MouseUp(object sender, MouseEventArgs e)
        {
            GridView gc = sender as GridView;
            GridHitInfo info = gc.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                this.popupMenu2.ShowPopup(Control.MousePosition);
            }
        }

        private void ReiseColumns_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DisplayColumns(this.bandedGridViewYTLB);
        }



    }
}