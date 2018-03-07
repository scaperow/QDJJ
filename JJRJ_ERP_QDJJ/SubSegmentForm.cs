using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using System.Reflection;
using System.Threading;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraBars.Docking;
using GOLDSOFT.QDJJ.CTRL;
using DevExpress.XtraTreeList;
using System.Collections;
using System.Linq;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class SubSegmentForm : ABaseForm
    {
        /// <summary>
        /// 获取选项卡中的对象
        /// </summary>
        public BaseForm CurrentTabForm
        {
            get
            {
                return this.xtraTabControl1.SelectedTabPage.Controls[0] as BaseForm;
            }
        }
        public delegate void FixedChangeHandler(_Entity_SubInfo sender);
        public event FixedChangeHandler FixedChange;

        /// <summary>
        /// 操作日志窗体
        /// </summary>
        public SubSegmentForm()
        {
            InitializeComponent();
        }
        private void OnFixedChange(_Entity_SubInfo sender)
        {
            if (this.FixedChange != null)
            {
                this.FixedChange(sender);
            }

        }
        public override void LockUnit()
        {
            base.LockUnit();
            this.subSegmentListData1.treeList1.OptionsBehavior.Editable = false;       
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.subSegmentListData1.treeList1.OptionsBehavior.Editable = true; 
        }
         private void SubSegmentForm_Load(object sender, EventArgs e)
        {
            //初始化窗体的时候加载            

            BindSubSegmentList();
            initForm();
            //Pan2Add(new SubheadingsQuantityUnit());
            treeList1_FocusedNodeChanged(this.subSegmentListData1.treeList1, null);
            this.subSegmentListData1.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit1_ButtonClick);
            this.subSegmentListData1.CheckEdit1.CheckStateChanged += new EventHandler(CheckEdit1_CheckStateChanged);
            if (this.Activitie.ProType.Contains("安装"))
            {
                this.xtraTabPage4.PageVisible = true;
            }
            else
            {
                this.xtraTabPage4.PageVisible = false;
            }

             
        }

         

        public void CheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            TreeListEx t = this.subSegmentListData1.treeList1;
            DataRowView v = t.Current as DataRowView;
            if (v == null) return;
            CheckEdit ck = sender as CheckEdit;
            _Entity_SubInfo info = new _Entity_SubInfo();

            switch (t.FocusedColumn.FieldName)
            {
                case "SFFB":
                case "SDDJ":
                case "SDQD":
                    if (t.FocusedColumn.FieldName.Equals("SDDJ") && !ck.Checked)
                    {
                        DialogResult d = MsgBox.Show("【锁定单价】解除后将会重新计算单价，您是否继续？", MessageBoxButtons.OKCancel);
                       if (d == DialogResult.OK)
                       {
                           v.BeginEdit();
                           v[t.FocusedColumn.FieldName] = ck.Checked;
                           v.EndEdit();
                           this.Activitie.StructSource.ModelSubSegments.GetRowByOther(v["ID"].ToString());
                           _ObjectSource.GetObject(info, v.Row);
                           GLODSOFT.QDJJ.BUSINESS._Methods met = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.CurrentBusiness, this.Activitie, info);
                           met.Begin(null);
                       }
                       else
                       {
                           ck.Checked = true;
                       }
                    }
                    else
                    {
                        v.BeginEdit();
                        v[t.FocusedColumn.FieldName] = ck.Checked;
                        v.EndEdit();
                        this.Activitie.StructSource.ModelSubSegments.GetRowByOther(v["ID"].ToString());
                        _ObjectSource.GetObject(info, v.Row);
                        Calculator.Calculate(CurrentBusiness, Activitie, info);
                    }
                    break;
                default:
                    break;
            }
        }


        void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRowView v = this.subSegmentListData1.treeList1.Current as DataRowView;
            if (v != null)
            {
                switch (v["LB"].ToString())
                {
                    case "清单":
                        QueryForm form = new QueryForm(this);
                        form.Activitie = this.Activitie;
                        form.CurrentBusiness = this.CurrentBusiness;
                        form.Sform = this;
                        _Entity_SubInfo info = new _Entity_SubInfo();
                        DataRow row = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(v["ID"].ToString());
                        _ObjectSource.GetObject(info, row);
                        form.CurrQD = info;
                        form.Show(this);
                        break;
                    default:
                        break;
                }
            }
        }

        public override void Init()
        {
            if (this.IsReloadForm)
            {
                BindSubSegmentList();
                initForm();
            }
            /*if (this.Activitie.Property.SubSegments.IsZDSC)
            {
                BindSubSegmentList();
                this.Activitie.Property.SubSegments.IsZDSC = false;
            }*/
            treeList1_FocusedNodeChanged(this.subSegmentListData1.treeList1, null);
        }

        public override void MustInit()
        {
            //此处初始化窗体配色方案
            Refresh();
            base.MustInit();
            treeList1_FocusedNodeChanged(this.subSegmentListData1.treeList1, null);
        }


        public override void OnInitForm()
        {
            base.OnInitForm();
            this.AddEvent();
        }

        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            this.RemoveEvent();
        }

        private void AddEvent()
        {
            //为清单控件添加双击事件
            this.ProjectsForm.UnitControls.listGallery1.treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            this.ProjectsForm.UnitControls.listGallery1.listBoxControl1.DoubleClick += new EventHandler(listBoxControl1_DoubleClick);
            //初始化定额
            APP.Application.Global.Configuration.ConfigSave += new _Configuration.ConfigSaveHandler(Configuration_ConfigSave);
            this.ProjectsForm.UnitControls.fixedLibrary1.listBoxControl2.DoubleClick += new EventHandler(listBoxControl2_DoubleClick);
            //this.Activitie.Property.SubSegments.ModelEdited += new ModelEditedHandler(SubSegments_ModelEdited);
            //this.Activitie.Property.SubSegments.ModelActioin += new ModelActioinHandler(SubSegments_ModelActioin);

            this.subSegmentListData1.ResieColumns.ItemClick +=new ItemClickEventHandler(ResieColumns_ItemClick);
            this.subSegmentListData1.barfind.ItemClick += new ItemClickEventHandler(barfind_ItemClick);

            this.subSegmentListData1.EditAttributed += new SubSegmentListData.EditAttributedHandler(subSegmentListData1_EditAttributed);
            
        }

       
        void ResieColumns_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DisplayColumns(this.subSegmentListData1.treeList1);
        }

        void Configuration_ConfigSave()
        {
            this.subSegmentListData1.ChangeRepositoryItem();
        }

        private void RemoveEvent()
        {
            //为清单控件添加双击事件
            this.ProjectsForm.UnitControls.listGallery1.treeList1.DoubleClick -= new EventHandler(treeList1_DoubleClick);
            this.ProjectsForm.UnitControls.listGallery1.listBoxControl1.DoubleClick -= new EventHandler(listBoxControl1_DoubleClick);
            //初始化定额
            APP.Application.Global.Configuration.ConfigSave += new _Configuration.ConfigSaveHandler(Configuration_ConfigSave);
            this.ProjectsForm.UnitControls.fixedLibrary1.listBoxControl2.DoubleClick -= new EventHandler(listBoxControl2_DoubleClick);
            //this.Activitie.Property.SubSegments.ModelEdited -= new ModelEditedHandler(SubSegments_ModelEdited);
            //this.Activitie.Property.SubSegments.ModelActioin -= new ModelActioinHandler(SubSegments_ModelActioin);
            this.subSegmentListData1.ResieColumns.ItemClick -= new ItemClickEventHandler(ResieColumns_ItemClick);
            this.subSegmentListData1.barfind.ItemClick -= new ItemClickEventHandler(barfind_ItemClick);

            this.subSegmentListData1.EditAttributed -=new SubSegmentListData.EditAttributedHandler(subSegmentListData1_EditAttributed);
        }

        void barfind_ItemClick(object sender, ItemClickEventArgs e)
        {
            FindReplaceForm form = new FindReplaceForm();
            form.sform = this;
            form.Activitie = this.Activitie;
            form.CurrentBusiness = this.CurrentBusiness;
            // form.Fitler = obj.subSegmentListData1.Source.Filter;
            // obj.subSegmentListData1.treeList1.BeginUnboundLoad();
            form.Show(this);
        }

        /// <summary>
        /// 初始化窗体
        /// </summary> 
        private void initForm()
        {


            subSegmentListData1.OnChildRefresh += new SubSegmentListData.ChildRefresh(subSegmentListData1_OnChildRefresh);
            subSegmentListData1.RItemButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(RItemButtonEdit_ButtonClick);
            //子目工料机
            this.subSegmentListData1.treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            //this.subSegmentListData1.Source.PositionChanged += new EventHandler(bindingSource1_PositionChanged);
            InitPageForm();
        }

       public void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListEx bs = sender as TreeListEx;
            //if (bs.Current == -1) return;
            if (bs.Current != null)
            {
                DataRowView view = bs.Current as DataRowView;
                if (view != null)
                {
                    int _id = ToolKit.ParseInt(view["ID"]);
                    this.subSegmentListData1.DelKong(_id);
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    if (view.Row.RowState == DataRowState.Detached) return;
                    _ObjectSource.GetObject(info, view.Row);
                    switch (view["LB"].ToString())
                    {
                        case "清单":
                            InfoType = EInfoType.清单;
                            SelectFixed(info);
                            this.xtraTabControl1.SelectedTabPageIndex = qd;
                            this.OnFixedChange(info);
                            break;
                        case "子目-降效":
                        case "子目-增加费":
                        case "子目":
                            InfoType = EInfoType.子目;
                            SubheadingsQuantityUnit subheadingsQuantityUnit = xtraTabPage1.Controls[0] as SubheadingsQuantityUnit;
                            SubheadingsFeeForm subheadingsFeeForm = xtraTabPage2.Controls[0] as SubheadingsFeeForm;
                            StandardConversionForm standardConversionForm = xtraTabPage3.Controls[0] as StandardConversionForm;
                            IncreaseCostsInfoList increaseCostsInfoList = xtraTabPage4.Controls[0] as IncreaseCostsInfoList;
                            if (subheadingsQuantityUnit != null)
                            {
                                subheadingsQuantityUnit.DoFilter(info);
                            }
                            if (subheadingsFeeForm != null)
                            {
                                subheadingsFeeForm.DoFilter(info);
                            }
                            if (standardConversionForm != null)
                            {
                                standardConversionForm.DoFilter(info);
                            }
                            if (increaseCostsInfoList != null)
                            {
                                increaseCostsInfoList.DoFilter(info);
                            }
                            DisplayTabPage(new string[] { "xtraTabPage1", "xtraTabPage2", "xtraTabPage3", "xtraTabPage4" });
                            this.xtraTabControl1.SelectedTabPageIndex = zm;
                            break;
                        default:
                            InfoType = EInfoType.节点;
                            SelectFixeds(info);
                            this.xtraTabControl1.SelectedTabPageIndex = jd;
                            break;
                    }
                }
            }
        }

        public void subSegmentListData1_OnChildRefresh()
        {
            bindingSource1_PositionChanged(this.subSegmentListData1.treeList1, null);
        }

        public void ChangePositionChanged(bool flage)
        {
            if (flage)
            {
                this.subSegmentListData1.treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            }
            else
            {
                this.subSegmentListData1.treeList1.FocusedNodeChanged -= new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            }

        }
        public override void GlobalStyleChange()
        {
            base.GlobalStyleChange();
            subSegmentListData1.treeList1.ModelName = this.Text;
            //功能区处理
            string KeyName = subSegmentListData1.treeList1.KeyFieldName;
            string PName = subSegmentListData1.treeList1.ParentFieldName;
            subSegmentListData1.treeList1.ModelName = "分部分项";
            //APP.DataObjects.GColor.ColumnLayout.Set("分部分项");
            //APP.DataObjects.GColor.ColumnLayout.Get("分部分项",)
            //subSegmentListData1.treeList1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            //subSegmentListData1.treeList1.ColumnColor = APP.DataObjects.GColor.ColumnColor;
            //DevExpress.XtraTreeList.Columns.TreeListColumn o = subSegmentListData1.treeList1.Columns.ColumnByFieldName("TX");
            //o.OptionsColumn.AllowEdit = true;
            subSegmentListData1.treeList1.KeyFieldName = KeyName;
            subSegmentListData1.treeList1.ParentFieldName = PName;//防止新打开项目PID错误
            this.subSegmentListData1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }

        //刷新此窗体6
        /*public override void Refresh()
        {
            //此处初始化窗体配色方案
           subSegmentListData1.treeList1.ModelName = this.Text;
           this.subSegmentListData1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();

            foreach (XtraTabPage page in this.xtraTabControl1.TabPages)
            {
                page.Controls[0].Refresh();
            }
            base.Refresh();
            
        }*/

        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.subSegmentListData1.treeList1.OptionsBehavior.Editable = false;

            }
            else
            {
                this.subSegmentListData1.treeList1.OptionsBehavior.Editable = true;

            }

        }
        void RItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit bt = sender as ButtonEdit;
            PrimitiveFormulaForm form = new PrimitiveFormulaForm();
            DataRowView drv = this.subSegmentListData1.treeList1.Current as DataRowView;
            if (drv != null)
            {
                form.Current = drv.Row;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    bt.Text = form.Result;
                    drv["GCLJSS"] = bt.Text;
                    decimal d = ToolKit.ParseDecimal(ToolKit.Expression(bt.Text));
                    drv["GCL"] = d;
                    if (drv["SSLB"].Equals(0))
                    {
                        this.Activitie.StructSource.ModelSubSegments.UpDate(drv.Row);
                    }
                    else
                    {
                        this.Activitie.StructSource.ModelMeasures.UpDate(drv.Row);
                    }
                }
            }
        }

        /// <summary>
        /// 主数据源表上下滚动时候激发改变
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        public void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// 选中清单要做的事
        /// </summary>
        private void SelectFixeds(_Entity_SubInfo info)
        {
            if (info.LB == null)
            {
                xtraTabPage5.Text = "分部分项工料机";
            }
            else
            {
                xtraTabPage5.Text = info.LB;
            }
            AreaQuantityUnit inventoryQuantityUnit = xtraTabPage5.Controls[0] as AreaQuantityUnit;
            InventoryGraphAnalysis inventoryGraphAnalysis = xtraTabPage6.Controls[0] as InventoryGraphAnalysis;
            if (inventoryQuantityUnit != null)
            {
                inventoryQuantityUnit.DoFilter(info);
            }
            if (inventoryGraphAnalysis != null)
            {
                inventoryGraphAnalysis.DoFilter(info,false);
            }
            DisplayTabPage(new string[] { "xtraTabPage5", "xtraTabPage6" });
        }

        /// <summary>
        /// 选中清单要做的事
        /// </summary>
        private void SelectFixed(_Entity_SubInfo info)
        {
            xtraTabPage5.Text = "清单工料机";
            AreaQuantityUnit inventoryQuantityUnit = xtraTabPage5.Controls[0] as AreaQuantityUnit;
            InventoryGraphAnalysis inventoryGraphAnalysis = xtraTabPage6.Controls[0] as InventoryGraphAnalysis;
            FixedFeatures ff = xtraTabPage7.Controls[0] as FixedFeatures;
            FixedContent fc = xtraTabPage8.Controls[0] as FixedContent;
            if (inventoryQuantityUnit != null)
            {
                inventoryQuantityUnit.DoFilter(info);
            }
            if (inventoryGraphAnalysis != null)
            {
                inventoryGraphAnalysis.DoFilter(info);
            }
            ff.DataSource = this.Activitie.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单特征表"].Copy();
            ff.CurrQD = info;
            ff.DataBind();
            fc.DataSource = this.Activitie.Property.Libraries.ListGallery.LibraryDataSet.Tables["指引内容表"].Copy();
            fc.Source = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy();
            fc.CurrQD = info;
            fc.DataBind();
            DisplayTabPage(new string[] { "xtraTabPage5", "xtraTabPage6", "xtraTabPage7", "xtraTabPage8" });
        }

        private void DisplayTabPage(string[] TabNames)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (XtraTabPage tab in this.xtraTabControl1.TabPages)
            {
                foreach (string tabname in TabNames)
                {
                    if (tab.Name == tabname)
                    {
                        tab.PageVisible = true;
                        if (this.Activitie.ProType.Contains("安装"))
                        {
                            this.xtraTabPage4.PageVisible = true;
                        }
                        else
                        {
                            this.xtraTabPage4.PageVisible = false;
                        }
                        break;
                    }
                    else
                    {
                        tab.PageVisible = false;
                    }
                }
            }
        }

        private void InitPageForm()
        {
            TabAddForm(new SubheadingsQuantityUnit(this.CurrentBusiness, this.Activitie, this), xtraTabPage1);
            TabAddForm(new SubheadingsFeeForm(this.CurrentBusiness, this.Activitie, this), xtraTabPage2);
            TabAddForm(new StandardConversionForm(this.CurrentBusiness, this.Activitie, this), xtraTabPage3);
            TabAddForm(new IncreaseCostsInfoList(), xtraTabPage4);
            TabAddForm(new AreaQuantityUnit(this.CurrentBusiness, this.Activitie, this, "分部分项-清单工料机"), xtraTabPage5);
            TabAddForm(new InventoryGraphAnalysis(this.CurrentBusiness, this.Activitie, this), xtraTabPage6);
            TabAddForm(new FixedFeatures(this.CurrentBusiness), xtraTabPage7);
            TabAddForm(new FixedContent(this.CurrentBusiness), xtraTabPage8);
        }

        /// <summary>
        /// 选项卡添加方法
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        private void TabAddForm(BaseForm form, XtraTabPage page)
        {
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Activitie = this.Activitie;
            page.Controls.Add(form);
        }

        public void BindSubSegmentList()
        {
            //subSegmentListData1.Columns = APP.DataObjects.Columns;
            //subSegmentListData1.ChangeColums();
            subSegmentListData1.DataSource = this.Activitie;
            subSegmentListData1.CurrentBusiness = this.CurrentBusiness;
            subSegmentListData1.DataBind();
        }



        private void xtraTabControl1_DoubleClick(object sender, EventArgs e)
        {
            /*CMagnifier form = new CMagnifier();
            form.Name = (sender as DevExpress.XtraTab.XtraTabControl).Text;
            form.Value = (sender as DevExpress.XtraTab.XtraTabControl).Controls[0];
            form.ShowDialog();*/
        }


        #region -------------------清单库与定额库的事件处理-----------------------

        /// <summary>
        /// 初始化清单库的双击事件
        /// </summary>
        /// <param name="sender">清单树</param>
        /// <param name="e">激发参数</param>
        public void treeList1_DoubleClick(object sender, EventArgs e)
        {
            //如果操作区为分部分项
            //SubSegmentForm from = (MainForm.GetWorkAreas as SubSegmentForm);

            //_ObjectInfo o = this.subSegmentListData1.Source.Current as _ObjectInfo;
            //TreeList tl = sender as TreeList;
            //if (tl.Selection[0] == null) return;
            //if (tl.Selection[0].Tag != null)
            //{
            //    DataRow row = tl.Selection[0].Tag as DataRow;
            //    _FixedListInfo info = new _FFixedListInfo();
            //    //this.Activitie.Property.SubSegments.Methods.SetFixedInfo(info, row, this.Activitie.Property.Libraries.ListGallery.FullName);
            //    this.subSegmentListData1.Q_Inset(info);
            //    this.Activitie.Property.SubSegments.DataSource.ResetBindings(false);
            //    this.subSegmentListData1.DataBind();
            //    this.subSegmentListData1.FocusedNode(info.ID);
            //}

        }

        /// <summary>
        /// 清单库查询的添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            if (!this.CurrentBusiness.Current.IsDZBS||APP.Jzbx_pwd)
            {
                DataRow row1 = this.Activitie.StructSource.ModelSubSegments.GetRowByOther("1");
                _Entity_SubInfo info1 = new _Entity_SubInfo();
                _ObjectSource.GetObject(info1, row1);
                _Method_Sub met = new _Method_Sub(this.CurrentBusiness, this.Activitie, info1);
                ListBoxControl lc = sender as ListBoxControl;
                if (lc.SelectedItem == null) return;
                if (lc.SelectedItem != null)
                {
                    DataRowView row = lc.SelectedItem as DataRowView;
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    ///【2013.2.26 李波更改，作用处理各种备注来源】
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetFixedInfo(info, row.Row, this.Activitie.Property.Libraries.ListGallery.FullName, this.Activitie.StructSource.ModelSubSegments, "ZYLB");
                    this.subSegmentListData1.Q_Inset(info);
                    this.subSegmentListData1.FocusedNode(info.ID);
                }
            }
            /*_ObjectInfo o = this.subSegmentListData1.Source.Current as _ObjectInfo;
            ListBoxControl lc = sender as ListBoxControl;
            if (lc.SelectedItem == null) return;
            if (lc.SelectedItem != null)
            {
                DataRowView row = lc.SelectedItem as DataRowView;
                _FixedListInfo info = new _FFixedListInfo();
                this.Activitie.Property.SubSegments.Methods.SetFixedInfo(info, row.Row, this.Activitie.Property.Libraries.ListGallery.FullName);
                this.subSegmentListData1.Q_Inset(info);
                this.Activitie.Property.SubSegments.DataSource.ResetBindings(false);
                this.subSegmentListData1.DataBind();
                this.subSegmentListData1.FocusedNode(info.ID);
            }*/

        }

        /// <summary>
        /// 双击定额库listbox控件激发的时间
        /// </summary>
        /// <param name="sender">listbox</param>
        /// <param name="e">事件源</param>
        public void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {
            ListBoxControl lc = sender as ListBoxControl;
            DataRowView row = lc.SelectedItem as DataRowView;
            if (row == null) return;
            //DataRowView info = this.subSegmentListData1.Source.Current as DataRowView;
            DataRowView info = this.subSegmentListData1.treeList1.GetDataRecordByNode(this.subSegmentListData1.treeList1.FocusedNode) as DataRowView;
            if (info != null)
            {
                //int id =0;
                //DataRow pRow = null;
                //if (info["LB"].Equals("清单"))
                //{
                //    id = ToolKit.ParseInt(info["ID"]);
                //    pRow = info.Row;
                //}
                //if (info["LB"].Equals("子目") || info["LB"].Equals("子目-增加费"))
                //{
                //    id = ToolKit.ParseInt(info["PID"]);
                //    pRow = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(info);
                //}
                //if (id > 0)
                //{
                //for (int i = 0; i < 1000; i++)
                {
                   
                    _Entity_SubInfo sinfo = new _Entity_SubInfo();
                    ///【2013.2.27 李波更改，作用处理各种备注来源】
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, row.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName, "ZYLB", 1, this.subSegmentListData1.GetQDBM());
                    this.subSegmentListData1.Z_Inset(sinfo);
                    this.subSegmentListData1.FocusedNode(sinfo.ID);
                    //if (i == 500) break;
                }
                // }
            }
            //此处必须选择一个清单
            //if (info != null)
            //{
            //    _SubheadingsInfo info1 = new _FSubheadingsInfo();
            //    info.RemoveOnZiMuAddEvent();
            //    info.OnZiMuAdded += new _FixedListInfo.ZiMuAdd(info_OnZiMuAdded);
            //    string JXDE = "15-1,15-2,15-3,15-4,15-5,15-6,15-7,15-8,15-9,15-10,15-11,15-23,15-24,15-25,15-26,15-27,15-28,15-29,15-30,15-31";
            //    bool flag = false;
            //    string[] arr = JXDE.Split(',');
            //    string DEH = row["DINGEH"].ToString();
            //    foreach (string item in arr)
            //    {
            //        if (item == DEH)
            //        {
            //            flag = true;
            //            break;
            //        }
            //    }
            //    if (flag)
            //    {
            //        info1.LB = "子目";
            //        info1.XMBM = "补" + DEH;
            //        info1.OLDXMBM = "补" + DEH;
            //        info1.XMMC = "补充定额";
            //        info1.SC = true;
            //        info1.LibraryName = this.Activitie.Property.Libraries.FixedLibrary.FullName;
            //    }
            //    else
            //    {
            //        this.Activitie.Property.SubSegments.Methods.SetSubheadingsInfo(info1, row.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName);
            //    }
            //     this.subSegmentListData1.Z_Inset(info1, info);//创建子目
            //    this.subSegmentListData1.DataBind();
            //    this.subSegmentListData1.FocusedNode(info1.ID);
            //}
        }

        public void info_OnZiMuAdded(_Entity_SubInfo info)
        {

            //子目添加完成要执行的事件
            _Entity_SubInfo Sinfo = info;
            _Methods_Subheadings met = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, info);
            DataRow[] rows = this.Activitie.StructSource.ModelStandardConversion.Select(string.Format("ZMID={0} and SSLB={1}", Sinfo.ID, Sinfo.SSLB), "", DataViewRowState.CurrentRows);
            if (rows.Length > 0)
            {
                bool bzhs = ToolKit.ParseBoolen(APP.Application.Global.Configuration.Configs["标准换算"]);
                if (bzhs)//是否弹出标准换算
                {
                    StandardConversionForm Sform = new StandardConversionForm(this.CurrentBusiness, this.Activitie, this);
                    Sform.DoFilter(Sinfo);
                    Sform.ShowDialog();
                }
            }

            bool PHB = ToolKit.ParseBoolen(APP.Application.Global.Configuration.Configs["配合比换算"]);
            if (PHB)//是否弹配合比换算
            {
                string str = string.Empty;
                for (int i = 1; i < 185; i++)
                {
                    str += string.Format("'P-{0}',", i);
                }
                DataRow[] 配合比 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and BH in({2})", Sinfo.ID, Sinfo.SSLB, _Constant.配合比定额范围), "", DataViewRowState.CurrentRows);
                _Entity_QuantityUnit info1 = new _Entity_QuantityUnit();
                foreach (DataRow row in 配合比)
                {
                    _ObjectSource.GetObject(info1, row);
                    SysWoodMachineForm form = new SysWoodMachineForm(this.Activitie);
                    form.BH = info1.YSBH;
                    string bh = info1.YSBH;
                    decimal d = 1;
                    if (info1.YSXHL != 0)
                    {
                        d = info1.XHL / info1.YSXHL;
                    }
                    DialogResult dl = form.ShowDialog();
                    if (dl == DialogResult.OK)
                    {
                        DataRowView dr = form.bindingSource1.Current as DataRowView;
                        info1.YSBH = dr["CAIJBH"].ToString();
                        info1.YSMC = dr["CAIJMC"].ToString();
                        info1.YSDW = dr["CAIJDW"].ToString();
                        info1.DEDJ = ToolKit.ParseDecimal(dr["CAIJDJ"]);
                        info1.BH = dr["CAIJBH"].ToString();
                        info1.MC = dr["CAIJMC"].ToString();
                        info1.DW = dr["CAIJDW"].ToString();
                        info1.LB = dr["CAIJLB"].ToString();
                        info1.XHL = info1.YSXHL*d;
                        info1.SCDJ = ToolKit.ParseDecimal(dr["CAIJDJ"]);
                        info1.SDCLB = dr["SANDCMC"].ToString();
                        info1.SDCXS = dr["SANDCXS"].ToString().Length == 0 ? 0m : Convert.ToDecimal(dr["SANDCXS"]);
                        info1.GCL = Sinfo.GCL;
                        info1.SSKLB = Sinfo.LibraryName;
                        if (info1.YSBH != bh)
                        {
                            info.XMMC += "//换：" + info1.YSMC;
                            if (!info.XMBM.Contains("换"))
                            {
                                info.XMBM += "换";
                            }
                        }

                        //DataRow[] drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("UnID={0} AND SSLB={1} AND ZMID={2} AND PID={3}", this.Current.UnID, this.Current.SSLB, this.Current.ID, p_ysinfo["ID"]));
                        //foreach (DataRow item in drs)
                        //{
                        //    item.Delete();
                        //}

                        _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
                        m_Methods_Subheadings.Current = info;
                        _Methods_Quantity m_Methods_Quantity = new _Methods_Quantity(this.Activitie);

                        DataRow[] rows1 = m_Methods_Quantity.Unit.StructSource.ModelQuantity.Select("BH='" + form.BH + "' and ID =" + info1.ID);
                        m_Methods_Quantity.Current = rows1[0];
                        if (m_Methods_Subheadings.ReplaceGLJ(rows1[0], this.GetNewInfo(info1.YSBH, info1.ID)))
                        {
                            m_Methods_Subheadings.Begin(null);
                        }
                        else
                        {
                            MsgBox.Alert(info1.YSBH.ToString() + "已经存在");
                        }


                        ////this.GetCurrent();
                        ////this.GetPartQuantityUnit();
                        //InsertQuantityUnit form1 = new InsertQuantityUnit();
                        //form1.Activitie = this.Activitie;
                        //if (m_Methods_Quantity.Current != null)
                        //{
                        //    form1.BH = m_Methods_Quantity.Current["YSBH"].ToString();
                        //}
                        ////form.simpleButton3.Visible = false;
                        ////DialogResult r = form.ShowDialog();
                        ////if (r == DialogResult.Yes)
                        ////{
                        //DataRow new_info = form1.GetNewInfo();
                        //if (new_info == null) return;
                        //if (m_Methods_Subheadings.ReplaceGLJ(m_Methods_Quantity.Current, new_info))
                        //{
                        //    m_Methods_Subheadings.Begin();
                        //}
                        //else
                        //{
                        //    MsgBox.Alert(new_info["BH"].ToString() + "已经存在");
                        //}
                        ////this.RefreshDataSource();
                        ////}

                        this.Activitie.StructSource.ModelQuantity.UpDate(info1);

                    }
                }
            }

            bool SHZH = ToolKit.ParseBoolen(APP.Application.Global.Configuration.Configs["石灰换算"]);
            if (SHZH)//是否弹石灰换算
            {
                DataRow[] 石灰转换 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and BH in ({2})", Sinfo.ID, Sinfo.SSLB, _Constant.石灰转换定额范围), "", DataViewRowState.CurrentRows);
                _Entity_QuantityUnit item = new _Entity_QuantityUnit();
                foreach (DataRow row in 石灰转换)
                {
                    ShaJiangZhuanHuanForm form = new ShaJiangZhuanHuanForm();
                    form.SetInfo("石灰转换", _Constant.石灰转换说明);
                    DialogResult dl = form.ShowDialog();
                    if (dl == DialogResult.OK && form.checkEdit1.Checked)
                    {
                        _ObjectSource.GetObject(item, row);
                        DataRow info1 = met["10900"];
                        DataRow info2 = met["10001"];
                        DataRow info3 = met["11610"];
                        if (info1 == null)
                        {
                            info1 = met["10901"];
                        }

                        GOLDSOFT.QDJJ.COMMONS.LIB._Library.GetLibrary(Sinfo.LibraryName);
                        DataTable dt = (GOLDSOFT.QDJJ.COMMONS.LIB._Library.Libraries[Sinfo.LibraryName] as DataSet).Tables["材机表"];

                        DataRow[] dr = dt.Select(string.Format("CAIJBH ='{0}'", "10905"));
                        if (dr.Length > 0)
                        {
                            decimal xhl = ToolKit.ParseDecimal(info1["XHL"]);
                            string dw = info1["DW"].ToString();
                            info1["YSBH"] = dr[0]["CAIJBH"].ToString();
                            info1["YSMC"] = dr[0]["CAIJMC"].ToString();
                            info1["YSDW"] = dr[0]["CAIJDW"].ToString();
                            info1["DW"] = dr[0]["CAIJDW"].ToString();
                            info1["YSXHL"] = _ConvertUnit.Convert("吨", info1["DW"].ToString()) * xhl * 1.3m;
                            info1["DEDJ"] = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                            info1["BH"] = dr[0]["CAIJBH"].ToString();
                            info1["MC"] = dr[0]["CAIJMC"].ToString();

                            info1["LB"] = dr[0]["CAIJLB"].ToString();
                            info1["XHL"] = _ConvertUnit.Convert("吨", info1["DW"].ToString()) * xhl * 1.3m;
                            info1["SCDJ"] = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                            info1["SDCLB"] = dr[0]["SANDCMC"].ToString();
                            info1["SDCXS"] = dr[0]["SANDCXS"].ToString().Length == 0 ? 0m : Convert.ToDecimal(dr[0]["SANDCXS"]);
                            info1["GCL"] = Sinfo.GCL;
                            info1["SSKLB"] = Sinfo.LibraryName;
                            decimal d = _ConvertUnit.Convert(dw, "吨");
                            if (info2 == null)
                            {
                                //info2 = Sinfo["10002"];
                            }
                            info2["XHL"] = ToolKit.ParseDecimal(info2["XHL"]) - (xhl * d) * 0.478m;
                            if (info3 != null)
                            {
                                info3["XHL"] = ToolKit.ParseDecimal(info3["XHL"]) - (xhl * d) * 0.043m;
                            }
                        }
                    }
                }
            }
            bool SJZH = ToolKit.ParseBoolen(APP.Application.Global.Configuration.Configs["砂浆换算"]);
            if (SJZH)//是否弹石灰换算
            {
                APP.UserPriceLibrary.AllQuantityUnit = this.Activitie.StructSource.ModelQuantity;
                APP.UserPriceLibrary.UnName = this.Activitie.Name;
                APP.UserPriceLibrary.Range = 1;
                DataRow[] 砌筑工程 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and BH in({2})", Sinfo.ID, Sinfo.SSLB, _Constant.砌筑工程定额范围), "", DataViewRowState.CurrentRows);
                foreach (DataRow item in 砌筑工程)
                {
                    //砌筑工程
                    ShaJiangZhuanHuanForm form = new ShaJiangZhuanHuanForm();
                    form.SetInfo("砌筑工程", _Constant.砌筑工程说明);
                    DialogResult dl = form.ShowDialog();
                    if (dl == DialogResult.OK && form.checkEdit1.Checked)
                    {
                        DataRow info1 = met[item["BH"].ToString()];
                        DataRow info2 = met["10001"];
                        DataRow info3 = met["J06016"];
                        if (info2 == null)
                        {
                            info2 = met["10002"];
                        }
                        if (info2 != null)
                        {
                            if (info1 != null)
                            {
                                info1.BeginEdit();
                                info1["MC"] = info1["MC"] + "(预拌砂浆)";
                                APP.UserPriceLibrary.Update("MC", info1["MC", DataRowVersion.Current], info1);
                                info1.EndEdit();
                                decimal d = _ConvertUnit.Convert(info1["DW"].ToString(), "立方米");
                                info2["XHL"] = ToolKit.ParseDecimal(info2["XHL"]) - (0.69m * ToolKit.ParseDecimal(info1["XHL"]) * d);
                            }
                        }
                        if (info3 != null)
                        {
                            info3["XHL"] = 0m;
                        }
                    }
                }

               /* DataRow[] 抹灰工程 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and BH in({2})", Sinfo.ID, Sinfo.SSLB, _Constant.抹灰工程定额范围), "", DataViewRowState.CurrentRows);
                foreach (DataRow item in 抹灰工程)
                {
                    //抹灰工程
                    ShaJiangZhuanHuanForm form = new ShaJiangZhuanHuanForm();
                    form.SetInfo("抹灰工程", _Constant.抹灰工程说明);
                    DialogResult dl = form.ShowDialog();
                    if (dl == DialogResult.OK && form.checkEdit1.Checked)
                    {
                        DataRow info1 = met[item["BH"].ToString()];
                        DataRow info2 = met["10001"];
                        DataRow info3 = met["J06016"];
                        if (info2 == null)
                        {
                            info2 = met["10002"];
                        }
                        if (info2 != null)
                        {
                            if (info1 != null)
                            {
                                info1.BeginEdit();
                                info1["MC"] = info1["MC"] + "(预拌砂浆)";
                                APP.UserPriceLibrary.Update("MC", info1["MC", DataRowVersion.Current], info1);
                                info1.EndEdit();
                                decimal d = _ConvertUnit.Convert(info1["DW"].ToString(), "立方米");
                                info2["XHL"] = ToolKit.ParseDecimal(info2["XHL"]) - (ToolKit.ParseDecimal(info1["XHL"]) * 1.1m * d);
                            }

                        }
                        if (info3 != null)
                        {
                            info3["XHL"] = 0m;

                        }
                    }
                }*/


            }

        }
        /// <summary>
        /// 获取要植入的信息
        /// </summary>
        public DataRow GetNewInfo(string newBH,int id)
        {
            DataRow new_info = null;
            //SysWoodMachineForm sysWoodMachineForm = this.xtraTabControl1.SelectedTabPage.Controls[0] as SysWoodMachineForm;
            //DataRowView drv = sysWoodMachineForm.bindingSource1.Current as DataRowView;
            SysWoodMachineForm form = new SysWoodMachineForm(this.Activitie);
            DataRowView drv = form.bindingSource1.Current as DataRowView;

            DataRow[] drs = drv.Row.Table.Select("CAIJBH='" + newBH + "'");
            if (drs != null && drs.Length > 0)
            {
                new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
                new_info["IFSC"] = drs[0]["CAIJSC"].Equals("是") ? true : false;
                new_info["YSBH"] = drs[0]["CAIJBH"];
                new_info["YSMC"] = drs[0]["CAIJMC"];
                new_info["YSDW"] = drs[0]["CAIJDW"];
                new_info["DEDJ"] = ToolKit.ParseDecimal(drs[0]["CAIJDJ"]);
                new_info["BH"] = drs[0]["CAIJBH"];
                new_info["MC"] = drs[0]["CAIJMC"];
                new_info["DW"] = drs[0]["CAIJDW"];
                new_info["IFZYCL"] = drs[0]["CAIJXSJG"].Equals("是") ? true : false;
                new_info["LB"] = drs[0]["CAIJLB"];
                new_info["SCDJ"] = ToolKit.ParseDecimal(drs[0]["CAIJDJ"]);
                new_info["SDCLB"] = drs[0]["SANDCMC"];
                new_info["SDCXS"] = ToolKit.ParseDecimal(drs[0]["SANDCXS"]);
            }
  
            return new_info;
        }


        public void ShowSelectGallery()
        {
            SelectGallery sg = new SelectGallery();
            sg.P_form = this;
            //sg.Parent = this;
            sg.ShowDialog();
        }
        /// <summary>
        /// 弹出子目选择窗体
        /// </summary>
        public void ShowSelectFixed()
        {
            SelectFixed sg = new SelectFixed();
            sg.P_form = this;
            //sg.Parent = this;
            sg.ShowDialog();
        }

        public override void RefreshDataSource()
        {
            this.subSegmentListData1.RefreshDataSource();
        }
        #endregion





        /// <summary>
        /// 当模块发生变时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void SubSegments_ModelEdited(object sender, object args)
        {
            //
            if (args != null)
            {
                ModifyAttribute modify = args as ModifyAttribute;
                LogContent.Add(modify);
                GetContainer.ALogForm.Init();
            }
        }

        void SubSegments_ModelActioin(object sender, object args)
        {
            ActionAttribute modify = args as ActionAttribute;
            LogContent.Add(modify);
            //ALogForm.SetContents = LogContent.LogString;
            GetContainer.ALogForm.Init();
        }

        /// <summary>
        /// 编辑后的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void subSegmentListData1_EditAttributed(object sender, ModifyAttribute e)
        {
            LogContent.Add(e);
            GetContainer.ALogForm.Init();
        }


        /// <summary>
        /// 撤销到上一个步骤一个步骤的操作
        /// </summary>
        public override void Revocation()
        {
            Attribute attr = this.LogContent.GetLastAttribute;
            if (attr != null)
            {
                //获取Attr开始撤销动作
                ModifyAttribute ma = attr as ModifyAttribute;
                ActionAttribute aa = attr as ActionAttribute;
                if (ma != null)
                {
                    this.Revocation(ma);
                }
                if (aa != null)
                {
                    this.Revocation(aa);
                }

            }
        }


        /// <summary>
        /// 修改的实现
        /// </summary>
        /// <param name="p_attr"></param>
        public void Revocation(ModifyAttribute p_attr)
        {


            _Modify_Method.ModifyEdit_Sub(p_attr, this.CurrentBusiness, this.Activitie);
            LogContent.Remove(p_attr);
            GetContainer.ALogForm.Init();
            //还原属性
            //Command.ModifyObject(p_attr);
            //定位目标
            //CurrentTabForm.RevocationRefresh();
           // this.Locate(p_attr);
            //改变后刷新
            //this.RefreshDataSource();
        }

        /// <summary>
        /// 操作的实现
        /// </summary>
        /// <param name="p_attr"></param>
        public void Revocation(ActionAttribute p_attr)
        {
            //反向还原
            //还原属性
            Command.ActionObject(p_attr);
            //定位目标
            //CurrentTabForm.RevocationRefresh();
            //this.Locate(p_attr);
            //改变后刷新
            //this.RefreshDataSource();
        }

        /// <summary>
        /// 定位当前撤销操作
        /// </summary>
        /// <param name="p_Attr">撤销属性</param>
        public void Locate(ModifyAttribute p_Attr)
        {

            //判断当前修改对象的类型
            switch (p_Attr.ActingOn)
            {
                case "清单.子目.工料机.组成":
                    _QuantityUnitComponentInfo info1 = p_Attr.Source as _QuantityUnitComponentInfo;
                    this.Activitie.Property.SubSegments.DataSource.Position = this.Activitie.Property.SubSegments.DataSource.IndexOf(info1.Parent.Parent);
                    //定位工料机
                    this.CurrentTabForm.Locate(info1);
                    break;
                case "清单.子目.工料机":
                    _SubheadingsQuantityUnitInfo info2 = p_Attr.Source as _SubheadingsQuantityUnitInfo;
                    this.Activitie.Property.SubSegments.DataSource.Position = this.Activitie.Property.SubSegments.DataSource.IndexOf(info2.Parent);
                    //定位工料机
                    this.CurrentTabForm.Locate(info2);
                    break;
                case "清单.子目":
                case "清单":
                    this.Activitie.Property.SubSegments.DataSource.Position = this.Activitie.Property.SubSegments.DataSource.IndexOf(p_Attr.Source);
                    //单元格定位
                    this.subSegmentListData1.SetCell(p_Attr.PropertyName);
                    break;
            }
        }

        /// <summary>
        /// 定位当前撤销操作
        /// </summary>
        /// <param name="p_Attr">撤销属性</param>
        public void Locate(ActionAttribute p_Attr)
        {

        }
        private EInfoType InfoType = EInfoType.节点;
        private int jd = 4;
        private int qd = 4;
        private int zm = 0;

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            switch (InfoType)
            {
                case EInfoType.节点:
                    jd = this.xtraTabControl1.SelectedTabPageIndex;
                    break;
                case EInfoType.清单:
                    qd = this.xtraTabControl1.SelectedTabPageIndex;
                    break;
                case EInfoType.子目:
                    zm = this.xtraTabControl1.SelectedTabPageIndex;
                    break;
                default:
                    break;
            }
        }
        public void UpOrDownFiexd(bool IsUp)
        {
            DataRowView v = this.subSegmentListData1.treeList1.Current;
            if (v["LB"].Equals(null)) return;
            
            DataRow[] rows=null;
            if (IsUp)//上移
            {
                if (v["LB"].Equals("清单") && !this.CurrentBusiness.Current.IsDZBS) 
                {
                    rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format(" Sort<{0} and LB='清单'", v["Sort"]), "Sort desc");
                }
                else if (v["LB"].ToString().Contains("子目"))
                {
                    rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format(" Sort<{0} and PID={1}", v["Sort"], v["PID"]), "Sort desc");
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (v["LB"].Equals("清单") && !this.CurrentBusiness.Current.IsDZBS)
                {
                    rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format(" Sort>{0} and LB='清单'", v["Sort"]), "Sort asc");
                }
                else if (v["LB"].ToString().Contains("子目"))
                {
                    rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format(" Sort>{0} and PID={1}", v["Sort"], v["PID"]), "Sort asc");
                }
                else
                {
                    return;
                }
            }
            if (rows != null)
            {
                if (rows.Length > 0)
                {
                    int currSort = ToolKit.ParseInt(v["Sort"]);
                    v.BeginEdit();
                    v["Sort"] = rows[0]["Sort"];
                    v.EndEdit();
                    rows[0].BeginEdit();
                    rows[0]["Sort"] = currSort;
                    rows[0].EndEdit();
                }
            }
            this.subSegmentListData1.treeList1.RefreshDataSource();
        }
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    APP.DataObjects.GColor.ColumnLayout.Set("分部分项", this.subSegmentListData1.treeList1);
        //    APP.DataObjects.Save(@"d:\options.cfg");
        //}


    }
}