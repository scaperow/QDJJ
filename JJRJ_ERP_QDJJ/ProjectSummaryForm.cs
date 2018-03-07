using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.Data.OleDb;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using System.Collections;
using DevExpress.XtraBars;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProjectSummaryForm : ABaseForm
    {
        private DataSetHelper m_DataSetHelper = new DataSetHelper();

        private DataTable m_DataTable = new DataTable();

        public ProjectSummaryForm()
        {
            InitializeComponent();
        }

        private void ProjectSummaryForm_Load(object sender, EventArgs e)
        {
            this.bindingSourceJD.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["WoodMachineIndex"];
            this.bindingSourceJD.Filter = "ValueMember <> '分部分项人材机' AND ValueMember <> '措施项目人材机' AND ValueMember <> '存在结算价差人材机'";
            this.treeListJD.ExpandAll();
            this.Init();
            //update by fuqiang 2013年7月5日
            this.barButtonItem3.Visibility = BarItemVisibility.Never;
        }

        /// <summary>
        /// 如果子出窗体每次打开后需要初始化重写此方法实现
        /// </summary>
        public override void Init()
        {
            this.gridControlGLJ.DataSource = null;
            if (this.CurrentBusiness.Current.StructSource.ModelQuantity.Rows.Count > 0)
            {
                this.m_DataTable = m_DataSetHelper.SelectGroupByInto(this.CurrentBusiness.Current.StructSource.ModelQuantity.TableName, this.CurrentBusiness.Current.StructSource.ModelQuantity, _Constant.gljzd, string.Empty, _Constant.hbtjzd + ",IFSDSCDJ,YTLB,LB");
                this.m_DataTable.Columns["SCHJ"].Expression = "SCDJ * SL";
                this.m_DataTable.Columns["DEHJ"].Expression = "DEDJ * SL";
                this.m_DataTable.AcceptChanges();
                this.gridControlGLJ.DataSource = m_DataTable.DefaultView;
                this.treeListJD.SetFocusedNode(this.treeListJD.Nodes[0].FirstNode);
            }
        }

        /// <summary>
        /// 节点筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListJD_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (this.m_DataTable == null) return;
            if (this.m_DataTable.Rows.Count == 0) return;
            switch (e.Node.GetValue("ValueMember").ToString().Trim())
            {
                case "自主报价":
                    this.m_DataTable.DefaultView.RowFilter = "1=1";
                    break;
                case "全部人材机":
                    this.m_DataTable.DefaultView.RowFilter = "1=1";
                    break;
                case "全部人工":
                    this.m_DataTable.DefaultView.RowFilter = string.Format("LB in ({0})", _Constant.rg);
                    break;
                case "全部材料":
                    this.m_DataTable.DefaultView.RowFilter = string.Format("LB in ({0})", _Constant.cl);
                    break;
                case "主要材料":
                    this.m_DataTable.DefaultView.RowFilter = "LB='材料' OR LB='主材' OR LB='设备'";
                    break;
                case "配合比材料":
                    this.m_DataTable.DefaultView.RowFilter = "LB='配合比'";
                    break;
                case "全部机械":
                    this.m_DataTable.DefaultView.RowFilter = string.Format("LB in ({0})", _Constant.jx);
                    break;
                case "可分解机械台班":
                    this.m_DataTable.DefaultView.RowFilter = "LB like '%台班%'";
                    break;
                case "不可分解机械":
                    this.m_DataTable.DefaultView.RowFilter = "LB='机械' OR LB='吊装机械'";
                    break;
                case "主材":
                    this.m_DataTable.DefaultView.RowFilter = "LB='主材'";
                    break;
                case "设备":
                    this.m_DataTable.DefaultView.RowFilter = "LB='设备'";
                    break;
                case "锁定市场价人材机":
                    this.m_DataTable.DefaultView.RowFilter = "IFSDSCDJ='True'";
                    break;
                case "计算风险人材机":
                    this.m_DataTable.DefaultView.RowFilter = "IFFX='True'";
                    break;
                case "存在价差人材机":
                    this.m_DataTable.DefaultView.RowFilter = "DJC<>0";
                    break;
                case "补充人材机":
                    this.m_DataTable.DefaultView.RowFilter = "BH Like '补%' OR BH Like 'BC%'";
                    break;
                case "甲供材料":
                    this.m_DataTable.DefaultView.RowFilter = "YTLB='甲供材料'";
                    break;
                case "甲定乙供材料":
                    this.m_DataTable.DefaultView.RowFilter = "YTLB='甲定乙供材料'";
                    break;
                case "评标指定材料":
                    this.m_DataTable.DefaultView.RowFilter = "YTLB='评标指定材料'";
                    break;
                case "暂定价材料":
                    this.m_DataTable.DefaultView.RowFilter = "YTLB='暂定价材料'";
                    break;
                case "三大材汇总":
                    this.m_DataTable.DefaultView.RowFilter = "SDCLB<>''";
                    break;
                default:
                    this.m_DataTable.DefaultView.RowFilter = "1=2";
                    break;
            }
        }

        /// <summary>
        /// 批量设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_DataTable == null || m_DataTable.Columns.Count <= 0) return;
            BatchEditSummaryForm form = new BatchEditSummaryForm();
            form.CurrentBusiness = this.CurrentBusiness;
            DataRow[] drs = this.m_DataTable.Select("LB not like '%台班%' and LB not like '%配合比%' and LB not like '%[%]%' and YTLB <> '甲供材料' and YTLB <> '暂定价材料'");
            if (drs.Length > 0)
            {
                form.DataSource = drs.CopyToDataTable();
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //(this.CurrentBusiness as _Pr_Business).Load();
                    (this.CurrentBusiness as _Pr_Business).Calculate();
                    this.Init();
                }
            }
        }

        /// <summary>
        /// 导出价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                string strConn = string.Empty;
                switch (this.saveFileDialogDC.FilterIndex)
                {
                    case 1:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.saveFileDialogDC.FileName + ";Extended Properties=Excel 8.0;";
                        break;
                    case 2:
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.saveFileDialogDC.FileName + ";Extended Properties=Excel 12.0;";
                        break;
                    default:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.saveFileDialogDC.FileName + ";Extended Properties=Excel 8.0;";
                        break;
                }
                OleDbConnection cn = new OleDbConnection(strConn);
                string sqlCreate = @"CREATE TABLE [tables] ([材料编号] VarChar, [材料名称] VarChar, [材料市场价] VarChar)";
                OleDbCommand cmd = new OleDbCommand(sqlCreate, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                foreach (DataRowView item in this.m_DataTable.DefaultView)
                {
                    if (!item["SCDJ"].Equals(item["DEDJ"]))
                    {
                        string queryString = string.Format("INSERT INTO [tables] ([材料编号], [材料名称], [材料市场价]) VALUES ('{0}', '{1}', '{2}')", item["BH"], item["MC"], item["SCDJ"]);
                        cmd.CommandText = queryString;
                        cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();
            }
        }

        /// <summary>
        /// 统计之后
        /// </summary>
        public void ProjectSummaryForm_DoStatistical(object sender, object args)
        {
            this.Init();
        }

        private void BatchCalculate()
        {
            BackgroundWorker ObjWorker = new BackgroundWorker();
            ObjWorker.WorkerReportsProgress = true;
            ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
            ObjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ObjWorker_RunWorkerCompleted);
            ObjWorker.RunWorkerAsync();
            ProgressFrom form = new ProgressFrom(ObjWorker);
            form.ShowDialog();
           
        }

        void ObjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Init();
        }


        void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (m_DataTable == null) return;
            DataTable dt = this.m_DataTable.GetChanges();
            if (dt != null)
            {
                _Pr_Business m_Pr_Business = this.CurrentBusiness as _Pr_Business;
                if (m_Pr_Business != null)
                {
                    m_Pr_Business.Update_Quantity(dt, "SCDJ");
                    //(this.CurrentBusiness as _Pr_Business).Load();
                    (this.CurrentBusiness as _Pr_Business).Calculate();
                }
            }
        }

        private void bandedGridViewGLJ_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            this.bandedGridViewGLJ_FocusedRowChanged(sender, null);
        }

        private void bandedGridViewGLJ_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView m_GridView = sender as GridView;
            if (m_GridView.FocusedColumn != null)
            {
                DataRow drv = this.bandedGridViewGLJ.GetFocusedDataRow() as DataRow;
                if (drv != null)
                {
                    switch (m_GridView.FocusedColumn.FieldName)
                    {
                        case "SCDJ":
                            if (this.barButtonItem3.Caption == "开始编辑" || drv["IFKFJ"].Equals(true) || drv["LB"].ToString().Contains("%") || drv["IFSDSCDJ"].Equals(true) || drv["YTLB"].Equals(UseType.甲供材料.ToString()) || drv["YTLB"].Equals(UseType.暂定价材料.ToString()))
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

        /// <summary>
        /// 全局配色方案改变时候
        /// </summary>
        public override void GlobalStyleChange()
        {
            this.bandedGridViewGLJ.ModelName = "项目_工料机汇总";
            this.bandedGridViewGLJ.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.bandedGridViewGLJ.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnInitForm()
        {
            base.OnInitForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.AfterStatisticaled += new AfterStatisticaledHandler(ProjectSummaryForm_DoStatistical);
        }


        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.AfterStatisticaled -= new AfterStatisticaledHandler(ProjectSummaryForm_DoStatistical);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_DataTable == null) return;
            if (this.barButtonItem3.Caption == "开始编辑")
            {
                this.barButtonItem4.Visibility = BarItemVisibility.Always;
                this.barButtonItem3.Caption = "保存编辑";
                this.barButtonItem3.ImageIndex = 3;
                this.bandedGridColumn8.OptionsColumn.AllowEdit = true;
            }
            else
            {
                this.barButtonItem3.Caption = "编辑中..";
                this.barButtonItem3.ImageIndex = 4;
                this.barButtonItem4.Visibility = BarItemVisibility.Never;
                this.bandedGridColumn8.OptionsColumn.AllowEdit = false;
                this.BatchCalculate();
                this.barButtonItem3.Caption = "开始编辑";
                this.barButtonItem3.ImageIndex = 5;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_DataTable == null) return;
            this.barButtonItem4.Visibility = BarItemVisibility.Never;
            this.bandedGridColumn8.OptionsColumn.AllowEdit = false;
            this.barButtonItem3.Caption = "开始编辑";
            this.m_DataTable.RejectChanges();
        }

        private void bandedGridViewGLJ_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.bandedGridViewGLJ.UpdateCurrentRow();
        }

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
    }
}