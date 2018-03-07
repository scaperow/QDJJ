using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 工料机
    /// </summary>
    public partial class SubheadingsQuantityUnit : ABaseForm
    {
        /// <summary>
        /// 当前正在操作的子目
        /// </summary>
        private _Methods_Subheadings m_Methods_Subheadings = null;
        /// <summary>
        /// 当前正在操作的工料机
        /// </summary>
        private _Methods_Quantity m_Methods_Quantity = null;
        /// <summary>
        /// 
        /// </summary>
        private _Methods_YTLBSummary m_Methods_YTLBSummary = null;

        /// <summary>
        /// 构造
        /// </summary>
        public SubheadingsQuantityUnit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="p_Business">当前业务</param>
        /// <param name="p_Activitie">当前单位工程</param>
        /// <param name="p_AParentForm">父级窗体</param>
        public SubheadingsQuantityUnit(_Business p_Business, _UnitProject p_Activitie, ABaseForm p_AParentForm)
        {
            this.CurrentBusiness = p_Business;
            this.Activitie = p_Activitie;
            this.AParentForm = p_AParentForm;
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            m_Methods_Quantity = new _Methods_Quantity(this.Activitie);
            m_Methods_YTLBSummary = new _Methods_YTLBSummary(this.Activitie);
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubheadingsQuantityUnit_Load(object sender, EventArgs e)
        {
            DataRow[] arr1 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("LB='{0}' or LB='{1}'", "主材", "设备"));
            /*2013年6月18日 付强 主材和设备的市场价从库里取，在库里设置为0
            /*foreach (DataRow row in arr1)
            {
                row["DEDJ"] = 0.0;
                row["SCDJ"] = 0.0;
            }*/

            this.gridControl1.DataSource = this.Activitie.StructSource.ModelQuantity.DefaultView;
        }

        /// <summary>
        /// 数据筛选
        /// </summary>
        /// <param name="p_info"></param>
        public void DoFilter(_Entity_SubInfo p_info)
        {
            m_Methods_Subheadings.Current = p_info;
            this.Activitie.StructSource.ModelQuantity.DefaultView.RowFilter = string.Format("ZMID={0} AND SSLB = {1} AND ZCLB='W'", p_info.ID, p_info.SSLB);
            this.gridView1.CollapseAllDetails();
        }

        private void GetPartQuantityUnit()
        {
            APP.UserPriceLibrary.AllQuantityUnit = this.Activitie.StructSource.ModelQuantity;
            APP.UserPriceLibrary.UnName = this.Activitie.Name;
            switch (barEditItem1.EditValue.ToString())
            {
                case "当前单位工程":
                    APP.UserPriceLibrary.Range = 0;
                    break;
                case "当前子目":
                    APP.UserPriceLibrary.Range = 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 范围修改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            this.barEditValue();
        }

        /// <summary>
        /// 数据修改前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv != null)
            {
                ChangeObject = gv.FocusedValue;
            }
        }

        /// <summary>
        /// 数据修改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.CellValueChanged(e);
        }

        /// <summary>
        /// 控制：右键弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            GridControl gv = sender as GridControl;
            BaseHitInfo hi = gv.FocusedView.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                this.GetCurrent();
                //右键显示控制
                if (this.m_Methods_Quantity.Current == null)
                {
                    this.barButtonItem1.Visibility = BarItemVisibility.Always;// BarItemVisibility.Never;
                    this.barSubItem1.Visibility = BarItemVisibility.Always;//BarItemVisibility.Never;
                    this.barButtonItem7.Visibility = BarItemVisibility.Never;
                    this.barSubItem2.Visibility = BarItemVisibility.Never;

                }
                else
                {
                    if (this.m_Methods_Quantity.Current["ZCLB"].Equals("W"))
                    {
                        this.barButtonItem1.Visibility = BarItemVisibility.Always;
                        this.barSubItem1.Visibility = BarItemVisibility.Always;
                        if (this.m_Methods_Quantity.Current["IFKFJ"].Equals(true))
                        {
                            this.barButtonItem7.Visibility = BarItemVisibility.Always;
                            this.barSubItem2.Visibility = BarItemVisibility.Always;
                        }
                        else
                        {
                            this.barButtonItem7.Visibility = BarItemVisibility.Never;
                            this.barSubItem2.Visibility = BarItemVisibility.Never;
                        }
                    }
                    else
                    {
                        this.barButtonItem1.Visibility = BarItemVisibility.Never;
                        this.barSubItem1.Visibility = BarItemVisibility.Never;
                        this.barButtonItem7.Visibility = BarItemVisibility.Always;
                        this.barSubItem2.Visibility = BarItemVisibility.Always;
                    }
                }
                if (this.Activitie == null) return;
                if (this.Activitie.IsLock) popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// 添加工料机按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.GetCurrent();
            InsertQuantityUnit form = new InsertQuantityUnit();
            form.Activitie = this.Activitie;
            if (this.m_Methods_Quantity.Current != null)
            {
                form.BH = this.m_Methods_Quantity.Current["YSBH"].ToString();
            }
            DialogResult r = form.ShowDialog();
            if (r == DialogResult.OK || r == DialogResult.Yes)
            {
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    DataRow new_info = form.GetNewInfo();
                    if (new_info == null) return;
                    switch (r)
                    {
                        //插入
                        case DialogResult.OK:
                            if (m_Methods_Subheadings.CreateGLJ(this.m_Methods_Quantity.Current, new_info))
                            {
                                this.m_Methods_Subheadings.BeginCurrent();

                                calculator.Entities.Add(m_Methods_Subheadings.Current);
                            }
                            else
                            {
                                MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                            }
                            break;
                        //替换
                        case DialogResult.Yes:
                            if (this.m_Methods_Quantity.Current == null)
                            {
                                MsgBox.Alert("请选择一条工料机后替换");
                            }
                            else
                            {
                                if (this.m_Methods_Subheadings.ReplaceGLJ(this.m_Methods_Quantity.Current, new_info))
                                {
                                    this.m_Methods_Subheadings.BeginCurrent();

                                    calculator.Entities.Add(m_Methods_Subheadings.Current);
                                }
                                else
                                {
                                    MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    this.RefreshDataSource();
                }
            }
        }

        /// <summary>
        /// 补充工料机按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.GetCurrent();
            this.GetPartQuantityUnit();

            var form = new InsertRepairQuantityUnit()
            {
                Activitie = this.Activitie,
                LB = e.Item.Caption
            };

            if (this.m_Methods_Quantity.Current != null)
            {
                form.MC = this.m_Methods_Quantity.Current["MC"].ToString();
            }

            if (form.ShowDialog() == DialogResult.OK)
            {
                DataRow newRow = form.New_Row;
                if (newRow == null)
                {
                    return;
                }

                if (m_Methods_Subheadings.CreateGLJ(this.m_Methods_Quantity.Current, newRow))
                {
                    if (form.radioGroup1.SelectedIndex == 0)
                    {
                        APP.RepairQuantityUnit.CreateZMGLJ(newRow);
                    }

                    Calculator.Calculate(CurrentBusiness, Activitie, m_Methods_Subheadings.Current);
                    Activitie.NeedCalculate = true;
                    RefreshDataSource();

                    if (form.IS_SAVE)
                    {
                        //保存补充才机库
                        APP.UserPriceLibrary.Save();
                        APP.RepairQuantityUnit.Save();
                    }
                }
                else
                {
                    MsgBox.Alert(newRow["BH"].ToString() + "已经存在");
                }
            }
        }

        /// <summary>
        /// 增加组成工料机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.GetCurrent();
            this.GetPartQuantityUnit();
            InsertQuantityUnit form = new InsertQuantityUnit();
            form.Activitie = this.Activitie;
            if (this.m_Methods_Quantity.Current != null)
            {
                form.BH = this.m_Methods_Quantity.Current["YSBH"].ToString();
            }
            DialogResult r = form.ShowDialog();
            if (r == DialogResult.OK || r == DialogResult.Yes)
            {
                DataRow new_info = form.GetNewInfo();
                if (new_info == null) return;
                if (new_info["LB"].Equals("配合比") || new_info["LB"].ToString().Contains("台班"))
                {
                    MsgBox.Alert("您不能将该材料添加到组成里! 请重新选择!");
                    return;
                }
                APP.UserPriceLibrary.Range = 1;
                switch (r)
                {
                    //插入
                    case DialogResult.OK:
                        if (this.m_Methods_Quantity.Create(new_info))
                        {
                            Calculator.Calculate(CurrentBusiness, Activitie, m_Methods_Subheadings.Current);
                            Activitie.NeedCalculate = true;
                        }
                        else
                        {
                            MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                        }
                        break;
                    //替换
                    case DialogResult.Yes:
                        if (this.m_Methods_Quantity.Current == null)
                        {
                            MsgBox.Alert("请选择一条工料机后替换");
                        }
                        else
                        {
                            if (this.m_Methods_Quantity.ReplaceGLJ(new_info))
                            {
                                Calculator.Calculate(CurrentBusiness, Activitie, m_Methods_Subheadings.Current);
                                this.Activitie.NeedCalculate = true;
                            }
                            else
                            {
                                MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                            }
                        }
                        break;
                    default:
                        break;
                }
                this.RefreshDataSource();
            }
        }

        /// <summary>
        /// 补充组成工料机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.GetCurrent();
            this.GetPartQuantityUnit();

            var form = new InsertRepairQuantityUnit()
            {
                Activitie = this.Activitie,
                LB = e.Item.Caption
            };

            if (this.m_Methods_Quantity.Current != null)
            {
                form.MC = this.m_Methods_Quantity.Current["MC"].ToString();
            }

            if (form.ShowDialog() == DialogResult.OK)
            {
                APP.UserPriceLibrary.Range = 1;

                var focusedRow = this.gridView1.GetFocusedDataRow() as DataRow;

                if (focusedRow != null)
                {
                    using (var calculator = new Calculator(CurrentBusiness, Activitie))
                    {
                        DataRow newRow = form.GetNewInfo();
                        if (newRow == null)
                        {
                            return;
                        }

                        if (this.m_Methods_Quantity.Create(newRow))
                        {
                            if (form.radioGroup1.SelectedIndex == 1)
                            {
                                APP.RepairQuantityUnit.CreateZMGLJ(newRow);
                            }

                            calculator.Entities.Add(m_Methods_Subheadings.Current);                 
                        }
                        else
                        {
                            MsgBox.Alert(newRow["BH"].ToString() + "已经存在");
                        }
                    }

                    this.RefreshDataSource();
                }
                else
                {
                    MsgBox.Alert("请选择一条工料机!");
                }
            }
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.m_Methods_Quantity.Current != null)
            {
                DialogResult dr = MsgBox.Show("确认删除？", MessageBoxButtons.YesNo);
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    if (dr == DialogResult.Yes)
                    {
                        this.GetCurrent();
                        this.GetPartQuantityUnit();
                        if (this.m_Methods_Quantity.Current["ZCLB"].Equals("W"))
                        {
                            this.m_Methods_Subheadings.Current.XMMC += "//删：" + this.m_Methods_Quantity.Current["MC"].ToString();
                            if (!this.m_Methods_Subheadings.Current.XMBM.Contains("换"))
                            {
                                this.m_Methods_Subheadings.Current.XMBM += "换";
                            }
                            if (this.m_Methods_Subheadings.Current.SSLB == 0)
                            {
                                this.Activitie.StructSource.ModelSubSegments.UpDate(this.m_Methods_Subheadings.Current);
                            }
                            else
                            {
                                this.Activitie.StructSource.ModelMeasures.UpDate(this.m_Methods_Subheadings.Current);
                            }
                            DataRow[] drs = this.m_Methods_Quantity.Current.GetChildRows("工料机-组成");
                            foreach (DataRow item in drs)
                            {
                                item.Delete();
                            }
                            this.m_Methods_Quantity.Current.Delete();
                            this.m_Methods_Subheadings.Begin(null);
                        }
                        else
                        {
                            APP.UserPriceLibrary.Range = 1;
                            this.m_Methods_Quantity.Current.Delete();
                            _Methods_Quantity.CalculateParentSCDJ(this.m_Methods_Quantity.Parent);
                            //this.m_Methods_Subheadings.BatchCalculate();
                        }

                        calculator.Entities.Add(m_Methods_Subheadings.Current);
                    }
                }
                CurrentBusiness.FastCalculate();
            }
        }

        /// <summary>
        /// 获取当前操作的工料机
        /// </summary>
        private void GetCurrent()
        {
            GridView gv = this.gridControl1.FocusedView as GridView;
            if (gv == null)
            {
                this.m_Methods_Quantity.Parent = null;
                this.m_Methods_Quantity.Current = null;
            }
            else
            {
                DataRow dr = gv.GetDataRow(gv.FocusedRowHandle);
                if (dr != null)
                {
                    this.m_Methods_Quantity.Current = dr;
                    if (dr["ZCLB"].Equals("W"))
                    {
                        this.m_Methods_Quantity.Parent = null;
                    }
                    else
                    {
                        this.m_Methods_Quantity.Parent = dr.GetParentRow("工料机-组成");
                    }
                    return;
                }
            }
            this.m_Methods_Quantity.Parent = null;
            this.m_Methods_Quantity.Current = null;
        }

        private void gridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.gridView_FocusedRowChanged(sender, null);
        }

        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView m_GridView = sender as GridView;
            if (m_GridView.FocusedColumn != null)
            {
                DataRow dr = m_GridView.GetDataRow(m_GridView.FocusedRowHandle);
                if (dr != null)
                {
                    switch (m_GridView.FocusedColumn.FieldName)
                    {
                        case "DW":
                        case "MC":
                            if (!dr["YTLB"].Equals(string.Empty))
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                            else
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            break;
                        case "SCDJ":
                            if (dr["IFKFJ"].Equals(true) || dr["LB"].ToString().Contains("%") || dr["YTLB"].Equals(UseType.甲供材料.ToString()) || dr["YTLB"].Equals(UseType.暂定价材料.ToString()) || dr["IFSDSCDJ"].Equals(true))
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                            else
                            {
                                m_GridView.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            break;
                        case "XHL":
                            if (dr["IFSDSL"].Equals(true))
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




        private void BatchCalculate()
        {
            /*BackgroundWorker ObjWorker = new BackgroundWorker();
            /*ObjWorker.WorkerReportsProgress = true;
            ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
            //ObjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ObjWorker_RunWorkerCompleted);
            ObjWorker.RunWorkerAsync();
            ProgressFrom form = new ProgressFrom(ObjWorker);
            form.ShowDialog();*/
            this.ObjWorker_DoWork(null,null);
        }

      

        void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.m_Methods_Subheadings.BatchCalculate();
        }

            

        /// <summary>
        /// 工料机编号替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.GetCurrent();
            this.GetPartQuantityUnit();
            InsertQuantityUnit form = new InsertQuantityUnit();
            form.Activitie = this.Activitie;
            if (this.m_Methods_Quantity.Current != null)
            {
                form.BH = this.m_Methods_Quantity.Current["YSBH"].ToString();
            }
            form.simpleButton3.Visible = false;
            DialogResult r = form.ShowDialog();
            if (r == DialogResult.Yes)
            {
                DataRow new_info = form.GetNewInfo();
                if (new_info == null) return;
                if (this.m_Methods_Subheadings.ReplaceGLJ(this.m_Methods_Quantity.Current, new_info))
                {
                    this.m_Methods_Subheadings.Begin(null);
                }
                else
                {
                    MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                }
                this.RefreshDataSource();
            }
        }

        /// <summary>
        /// 组成工料机编号替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.GetCurrent();
            this.GetPartQuantityUnit();
            InsertQuantityUnit form = new InsertQuantityUnit();
            form.Activitie = this.Activitie;
            if (this.m_Methods_Quantity.Current != null)
            {
                form.BH = this.m_Methods_Quantity.Current["YSBH"].ToString();
            }
            form.simpleButton3.Visible = false;
            DialogResult r = form.ShowDialog();
            if (r == DialogResult.Yes)
            {
                DataRow new_info = form.GetNewInfo();
                if (new_info == null) return;
                APP.UserPriceLibrary.Range = 1;
                if (new_info["LB"].Equals("配合比") || new_info["LB"].ToString().Contains("台班"))
                {
                    MsgBox.Alert("您不能将该材料添加到组成里! 请重新选择!");
                }
                else
                {
                    if (this.m_Methods_Quantity.ReplaceGLJ(new_info))
                    {
                        this.m_Methods_Subheadings.Begin(null);
                    }
                    else
                    {
                        MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                    }
                }
                this.RefreshDataSource();
            }
        }

        #region----------------------公共---------------------------------

        /// <summary>
        /// 当需要自定义特殊修改实现此事件
        /// </summary>
        /// <param name="p_RowObject"></param>
        /// <param name="p_SchemeColor"></param>
        /// <param name="appearance"></param>
        private void gridView1_SetRowColorChange(object p_RowObject, _SchemeColor p_SchemeColor, DevExpress.Utils.AppearanceObject appearance)
        {
            DataRowView info = (p_RowObject as DataRowView);
            if (!info["YSBH"].Equals(info["BH"]) && !info["YSDW"].Equals(info["DW"]) && !info["YSMC"].Equals(info["MC"]))
            {
                //获取特殊样式绑定颜色
                _SpecialStyleInfo style = p_SchemeColor.SpecialStyle.Get("市场单价修改");
                if (style != null)
                {
                    appearance.Font = new Font(appearance.Font.FontFamily, appearance.Font.Size, style.Font);
                    //字体颜色
                    appearance.ForeColor = style.ForeColor.IsEmpty ? appearance.ForeColor : style.ForeColor;
                    //背景颜色
                    appearance.BackColor = style.BColor.IsEmpty ? appearance.BackColor : style.BColor;

                    appearance.BackColor2 = style.BColor2.IsEmpty ? appearance.BackColor2 : style.BColor2;
                }
            }

            if (!info["SCDJ"].Equals(info["DEDJ"]))
            {

                //获取特殊样式绑定颜色
                _SpecialStyleInfo style = p_SchemeColor.SpecialStyle.Get("市场单价修改");
                if (style != null)
                {
                    appearance.Font = new Font(appearance.Font.FontFamily, appearance.Font.Size, style.Font);
                    //字体颜色
                    appearance.ForeColor = style.ForeColor.IsEmpty ? appearance.ForeColor : style.ForeColor;
                    //背景颜色
                    appearance.BackColor = style.BColor.IsEmpty ? appearance.BackColor : style.BColor;

                    appearance.BackColor2 = style.BColor2.IsEmpty ? appearance.BackColor2 : style.BColor2;
                }
            }
        }

        private void gridView1_SetRowCellColorStyle(object sender, GOLDSOFT.QDJJ.CTRL.GridViewEx.CellColorArgs e)
        {
            DataRow info = (e.RowObject as DataRow);
            if (e.Column.FieldName == "SCDJ")
            {
                if (info == null) return;
                if (!info["SCDJ"].Equals(info["DEDJ"]))
                {

                    //获取特殊样式绑定颜色
                    _SpecialStyleInfo style = e.SchemeColor.SpecialStyle.Get("市场单价修改");
                    if (style != null)
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, style.Font);
                        //字体颜色
                        e.Appearance.ForeColor = style.ForeColor.IsEmpty ? e.Appearance.ForeColor : style.ForeColor;
                        //背景颜色
                        e.Appearance.BackColor = style.BColor.IsEmpty ? e.Appearance.BackColor : style.BColor;

                        e.Appearance.BackColor2 = style.BColor2.IsEmpty ? e.Appearance.BackColor2 : style.BColor2;
                    }
                }
            }

        }

        public override void GlobalStyleChange()
        {
            base.GlobalStyleChange();
            this.gridView1.UseSpecialColor = this.gridView2.UseSpecialColor = true;
            //this.gridView2.UseSpecialColor = this.gridView2.UseSpecialColor = true;
            this.gridView1.ModelName = "分部分项";
            this.gridView2.ModelName = "分部分项-子目工料机-2";
            //this.gridView2.ModelName = "分部分项";
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.gridView2.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            //this.gridView1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
           // this.gridView2.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
        }

        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.gridView1.OptionsBehavior.Editable = false;
                this.gridView2.OptionsBehavior.Editable = false;
            }
            else
            {
                this.gridView1.OptionsBehavior.Editable = true;
                this.gridView2.OptionsBehavior.Editable = true;
            }
        }

        public override void RefreshDataSource()
        {
            //this.bindingSource1.ResetBindings(false);
        }

        public override void RevocationRefresh()
        {
            //if (m_info != null)
            //{
            //    this.m_info.OnQuantityUnitChange(this, null);
            //    RefreshDataSource();
            //}
        }

        public override void Locate(object p_Attr)
        {
            //if (this.m_info != null)
            //{
            //    if (p_Attr is _SubheadingsQuantityUnitInfo)
            //    {
            //        this.m_info.SubheadingsQuantityUnitList_BindingSource.Position = this.m_info.SubheadingsQuantityUnitList_BindingSource.IndexOf(p_Attr);
            //    }
            //    if (p_Attr is _QuantityUnitComponentInfo)
            //    {
            //        _QuantityUnitComponentInfo m_zmglj = p_Attr as _QuantityUnitComponentInfo;
            //        m_zmglj.Parent.Parent.SubheadingsQuantityUnitList_BindingSource.Position = m_zmglj.Parent.Parent.SubheadingsQuantityUnitList_BindingSource.IndexOf(m_zmglj.Parent);
            //        gridView1.ExpandMasterRow(m_zmglj.Parent.Parent.SubheadingsQuantityUnitList_BindingSource.IndexOf(m_zmglj.Parent));
            //        m_zmglj.Parent.QuantityUnitComponentList_BindingSource.Position = m_zmglj.Parent.QuantityUnitComponentList_BindingSource.IndexOf(m_zmglj);

            //    }
            //}
        }
        /// <summary>
        /// 提交当前操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowUpdated(_Entity_QuantityUnit infos)
        {
            //if (infos != null)
            //{
            //    this.Activitie.Property.TemporaryCalculate.Calculate();
            //    (this.AParentForm as SubSegmentForm).RefreshDataSource();
            //    this.RefreshDataSource();
            //}
        }
        #endregion -------------------------------------------------------

        private void gridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
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
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if(d.Equals(0m))
                        {
                            e.DisplayText = string.Empty;
                        }
                        break;
                    case "YTLB":
                        if (e.CellValue.Equals(string.Empty))
                        {
                            e.DisplayText = string.Empty;
                        }
                        break;
		            default:
                        break;
	            }
                if (e.Column.FieldName == "SCDJ")
                {
                    GridView m_gv = sender as GridView;
                    if (m_gv == null) return;
                    if (!m_gv.GetRowCellValue(e.RowHandle, "DJC").Equals(0m))
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold);

                    }
                    else
                    {
                        
                        e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
                    }
                }
            }
        }


        #region----------------------撤销---------------------------------

        private object ChangeObject = null;

        /// <summary>
        /// 修改范围
        /// </summary>
        private void barEditValue()
        {
            ModifyAttribute modity = new ModifyAttribute();
            switch (barEditItem1.EditValue.ToString())
            {
                case "当前单位工程":
                    modity.CurrentValue = "当前单位工程";
                    modity.OriginalValue = "当前子目";
                    break;
                case "当前子目":
                    modity.CurrentValue = "当前子目";
                    modity.OriginalValue = "当前单位工程";
                    break;
                default:
                    break;
            }
            modity.ModelName = this.ParentForm.Text;
            Submit(modity);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="e"></param>
        public void CellValueChanged(CellValueChangedEventArgs e)
        {
            this.GetCurrent();
            //if (this.m_Methods_Quantity.Current != null)
            //{
            DataRow[] allRows = this.m_Methods_Quantity.Current.Table.Select("MC='" + this.m_Methods_Quantity.Current["MC"] + "' and DW='" + this.m_Methods_Quantity.Current["DW"] +"'");
            if (barEditItem1.EditValue.ToString().Equals("当前单位工程"))
            {
                for (int i = 0; i < allRows.Length; i++)
                {
                    var row = allRows[i];
                    row["SCDJ"] = decimal.Parse(this.m_Methods_Quantity.Current["SCDJ"].ToString());
                }
            }

            //DataRow[] rows = this.m_Methods_Quantity.Current.Table.Select("MC='" + this.m_Methods_Quantity.Current["MC"] + "' and DW='" + this.m_Methods_Quantity.Current["DW"] + "' and SCDJ=" + this.m_Methods_Quantity.Current["SCDJ"]);
            //    if (rows.Length > 0)
            //    {
            //        string bh = this.m_Methods_Quantity.Current["YSBH"].ToString();
            //        DataRow[] cRows = this.m_Methods_Quantity.Current.Table.Select("YSBH='" + bh + "'");
            //        foreach (DataRow row in cRows)
            //        {
            //            if (row["YSBH"].Equals(bh))
            //            {
            //                GridView gv = this.gridControl1.FocusedView as GridView;
            //                DataRow dr = gv.GetDataRow(gv.FocusedRowHandle);
            //                switch (e.Column.FieldName)
            //                {
            //                    case "MC":
            //                        dr[e.Column.FieldName] = dr["YSMC"];
            //                        row[e.Column.FieldName] = dr["YSMC"];
            //                        break;
            //                    case "DW":
            //                        dr[e.Column.FieldName] = dr["YSDW"];
            //                        row[e.Column.FieldName] = dr["YSDW"];
            //                        break;
            //                    case "SCDJ":
            //                        dr[e.Column.FieldName] = dr["DEDJ"];
            //                        row[e.Column.FieldName] = dr["DEDJ"];
            //                        break;
            //                }
            //            }
            //        }

            //        if (e.Column.FieldName.Equals("BH") || e.Column.FieldName.Equals("MC") || e.Column.FieldName.Equals("DW") || e.Column.FieldName.Equals("SCDJ"))
            //        {
            //            MessageBox.Show("相同数据已经在用户价格库中存在。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //    }
            //}
            this.GetPartQuantityUnit();

            if (barEditItem1.EditValue.ToString().Equals("当前单位工程"))
            {
                var rows = new List<DataRow>();
                foreach (var row in allRows)
                {
                    rows.AddRange(this.Activitie.StructSource.ModelSubSegments.Select("ID='" + row["ZMID"] + "'"));
                }
                GLODSOFT.QDJJ.BUSINESS._Methods.Calculate(this.CurrentBusiness, this.Activitie, rows.ToArray());
            }

            using (var calculator = new Calculator(CurrentBusiness, Activitie))
            {
                switch (e.Column.FieldName)
                {
                    case "MC":
                    case "DW":
                    case "SCDJ":
                        if (this.m_Methods_Quantity.Current != null)
                        {
                            APP.UserPriceLibrary.Update(e.Column.FieldName, this.m_Methods_Quantity.Current[e.Column.FieldName, DataRowVersion.Current], this.m_Methods_Quantity.Current);
                            if (e.Column.FieldName == "SCDJ")
                            {
                                m_Methods_YTLBSummary.RefreshSCDJ(this.m_Methods_Quantity.Current);
                            }
                            //this.BatchCalculate();
                            calculator.Entities.Add(m_Methods_Subheadings.Current);
                        }
                        break;
                    case "XHL":

                        APP.UserPriceLibrary.Update(e.Column.FieldName, this.m_Methods_Quantity.Current[e.Column.FieldName, DataRowVersion.Current], this.m_Methods_Quantity.Current);
                        m_Methods_YTLBSummary.RefreshSCDJ(this.m_Methods_Quantity.Current);
                        if (this.m_Methods_Quantity.Current != null)
                        {
                            this.gridView1.UpdateCurrentRow();
                            if (this.m_Methods_Quantity.Current["ZCLB"].Equals("W"))
                            {
                                _Methods_Quantity.UpdateZCGCL(this.m_Methods_Quantity.Current);
                                //this.m_Methods_Subheadings.Begin();
                            }
                            else
                            {
                                APP.UserPriceLibrary.Range = 1;
                                _Methods_Quantity.CalculateParentSCDJ(this.m_Methods_Quantity.Parent);
                                //this.m_Methods_Subheadings.BatchCalculate();
                            }

                            //this.BatchCalculate();
                            calculator.Entities.Add(m_Methods_Subheadings.Current);
                        }
                        break;


                    default:
                        break;
                }
            }
            this.RefreshDataSource();

            ModifyAttribute modity = new ModifyAttribute();
            modity.CurrentValue = e.Value;
            modity.OriginalValue = ChangeObject;
            modity.ModelName = this.ParentForm.Text;
            Submit(modity);
        }

        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="modity"></param>
        private void Submit(ModifyAttribute modity)
        {
            //this.GetContainer.GetWorkAreas.LogContent.Add(modity);
            //this.GetContainer.ALogForm.Init();
        }
        #endregion
    }
}