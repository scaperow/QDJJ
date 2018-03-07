using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using GOLDSOFT.QDJJ.CTRL;
using DevExpress.XtraTab;
using ZiboSoft.Commons.Common;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class MeasuresProjectForm : ABaseForm
    {

        /// <summary>
        /// 获取选项卡中的对象
        /// </summary>
        public BaseForm CurrentTabForm
        {
            get
            {
                return this.xtraTabControl2.SelectedTabPage.Controls[0] as BaseForm;
            }
        }
        public MeasuresProjectForm()
        {
            InitializeComponent();
        }
        private bool IsLoadedControls = false;
        private Container ContainerForm
        {
            get
            {
                switch (this.CurrentBusiness.WorkFlowType)
                {
                    case EWorkFlowType.None:
                        break;
                    case EWorkFlowType.PROJECT:
                        ProjectForm form = this.BusContainer as ProjectForm;
                        if (form == null) return null;
                        CWellComeProject cw = form.ParentForm as CWellComeProject;
                        return cw;
                        break;
                    case EWorkFlowType.Engineering:
                        break;
                    case EWorkFlowType.UnitProject:
                        ProjectForm form1 = this.BusContainer as ProjectForm;
                        return form1;
                        break;
                    default:
                        break;
                }
                return null;

            }
        }
        private GLODSOFT.QDJJ.BUSINESS._Methods Method;
        //private BindingSource m_Source;
        /// <summary>
        /// 措施项目的数据源
        /// </summary>
        //public BindingSource Source
        //{
        //    get { return m_Source; }
        //    set { m_Source = value; }
        //}
        private void MeasuresProjectForm_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        public override void GlobalStyleChange()
        {

            //功能区处理
            this.treeList1.ModelName = "措施项目";
            // this.treeList1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            // this.treeList1.ColumnColor = APP.DataObjects.GColor.ColumnColor;
            //DevExpress.XtraTreeList.Columns.TreeListColumn o = this.treeList1.Columns.ColumnByFieldName("TX");
            // o.OptionsColumn.AllowEdit = true;
            this.treeList1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();

            //选择行
            //this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Red;
            //this.treeList1.Appearance.HideSelectionRow
            //this.treeList1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Red;

            this.treeList1.ParentFieldName = "PID";
            this.treeList1.Expand(2);
        }
        public override void MustInit()
        {
            //此处初始化窗体配色方案
            Refresh();
            base.MustInit();
            // DialogResult r = MessageBox.Show(_Prompt.措施项目重新计算, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (this.Activitie.ObjectState== EObjectState.Modify)
            //{
            _doLoadData();
            //}
            this.bindingSource1.ResetBindings(false);
            this.treeList1.Refresh();
            treeList1_FocusedNodeChanged(this.treeList1, null);
        }

        private void _doLoadData()
        {
            //this.Activitie.Property.Statistics.Begin();
            //this.Activitie.Property.MeasuresProject.Statistics.Calculate();
            //   IEnumerable<_ObjectInfo> infos = from n in this.Source.Cast<_ObjectInfo>()
            //                                    where n as _SubheadingsInfo != null && n.ZJFS == _Constant.公式组价
            //                                    select n;
            //_ObjectInfo[] sinfos=infos.ToArray();
            //foreach (_SubheadingsInfo item in sinfos)
            //{
            //    item.ZBegin();
            //}    
        }
        //刷新此窗体
        public override void Refresh()
        {
            //此处初始化窗体配色方案
            this.treeList1.ModelName = this.Text;
            this.treeList1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();

            foreach (XtraTabPage page in this.xtraTabControl2.TabPages)
            {
                page.Controls[0].Refresh();
            }


            base.Refresh();
        }
        public override void LockActivitie()
        {
            //base.LockActivitie();
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.treeList1.OptionsBehavior.Editable = false;
                //this.xtraTabControl1.Visible = false;
                this.splitContainerControl1.Panel1.Visible = false;
                this.splitContainerControl1.SplitterPosition = 0;

            }
            else
            {
                this.treeList1.OptionsBehavior.Editable = true;
                this.splitContainerControl1.Panel1.Visible = true;
                this.splitContainerControl1.SplitterPosition = 200;
            }
        }
        public override void OnInitForm()
        {
            base.OnInitForm();
            this.ProjectsForm.UnitControls.fixedLibrary1.listBoxControl2.DoubleClick += new EventHandler(listBoxControl2_DoubleClick);
            //this.Activitie.Property.MeasuresProject.ModelEdited += new ModelEditedHandler(MeasuresProject_ModelEdited);
            //this.Activitie.Property.MeasuresProject.ModelActioin += new ModelActioinHandler(MeasuresProject_ModelActioin);
            //  CWellComeProject wcForm = (this.BusContainer as CWellComeProject);

        }

        void wcForm_AfterStatisticaled(object sender, object args)
        {
            _Entity_SubInfo info = new _Entity_SubInfo();
            _ObjectSource.GetObject(info, this.GetCSXMFirst());
            GLODSOFT.QDJJ.BUSINESS._Mothod_Measures method = new _Mothod_Measures(null, this.Activitie, info);
            method.Calculate();
        }

        void MeasuresProject_ModelActioin(object sender, object args)
        {
            ActionAttribute modify = args as ActionAttribute;
            LogContent.Add(modify);
            GetContainer.ALogForm.Init();
        }
        void MeasuresProject_ModelEdited(object sender, object args)
        {
            if (args != null)
            {
                ModifyAttribute modify = args as ModifyAttribute;
                LogContent.Add(modify);
                GetContainer.ALogForm.Init();
            }
        }


        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            this.ProjectsForm.UnitControls.fixedLibrary1.listBoxControl2.DoubleClick -= new EventHandler(listBoxControl2_DoubleClick);
            //this.Activitie.Property.MeasuresProject.ModelEdited -= new ModelEditedHandler(MeasuresProject_ModelEdited);
            //this.Activitie.Property.MeasuresProject.ModelActioin -= new ModelActioinHandler(MeasuresProject_ModelActioin);

        }

        private void init()
        {
            InitPageForm();

            // this.m_Source = new BindingSource();

            /* this.m_Source.DataSource = this.Activitie.StructSource.ModelMeasures.DefaultView;
             this.m_Source.Sort = " Sort asc";
             this.treeList1.DataSource = this.m_Source;*/
            this.Activitie.StructSource.ModelMeasures.DefaultView.Sort = "Sort asc";
            this.treeList1.DataSource = this.Activitie.StructSource.ModelMeasures.DefaultView;
            this.treeList1.Expand(2);
            this.treeList1.Refresh();
            //措施清单数据绑定
            this.bindingSource1.DataSource = APP.Application.Global.DataTamp.MeasuresList.Tables["措施清单"].Copy();
            this.treeList2.DataSource = this.bindingSource1;
            this.treeList2.Expand(2);

            //行改变触发事件
            //this.Source.PositionChanged += new EventHandler(Source_PositionChanged);


            //IEnumerable<_ObjectInfo> infos = from info in this.Activitie.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
            //                                 where info.ZJFS == _Constant.公式组价 && info.LB == "清单"
            //                                 select info;

            //this.Activitie.Property.Statistics.Begin();
            //foreach (_MFixedListInfo item in infos)
            //{
            //    item.Begin();
            //}

        }
        /// <summary>
        /// 行切换时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Source_PositionChanged(object sender, EventArgs e)
        {
            // return;
            TreeListEx bs = sender as TreeListEx;
            if (bs.Current != null)
            {
                DataRowView view = bs.Current as DataRowView;
                if (view != null)
                {
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, view.Row);
                    int id = ToolKit.ParseInt(view["ID"]);
                    DelKong(id); //切换时删除空行
                    if (view.Row.RowState == DataRowState.Detached) return;
                    switch (view["LB"].ToString())
                    {
                        case "清单":
                            InfoType = EInfoType.节点;
                            xtraTabPage7.Text = "清单工料机";
                            AreaQuantityUnit m_AreaQuantityUnit = xtraTabPage7.Controls[0] as AreaQuantityUnit;
                            InventoryGraphAnalysis m_InventoryGraphAnalysis = xtraTabPage8.Controls[0] as InventoryGraphAnalysis;
                            if (m_AreaQuantityUnit != null)
                            {
                                m_AreaQuantityUnit.DoFilter(info);
                            }
                            if (m_InventoryGraphAnalysis != null)
                            {
                                m_InventoryGraphAnalysis.DoFilter(info);
                            }
                            DisplayTabPage(new string[] { "xtraTabPage7", "xtraTabPage8" });
                            this.xtraTabPage6.PageVisible = false;
                            this.xtraTabControl2.SelectedTabPageIndex = jd;
                            break;
                        case "子目-降效":
                        case "子目-增加费":
                        case "子目":
                            InfoType = EInfoType.子目;
                            SubheadingsQuantityUnit s_subheadingsQuantityUnit = xtraTabPage3.Controls[0] as SubheadingsQuantityUnit;
                            SubheadingsFeeForm s_subheadingsFeeForm = xtraTabPage4.Controls[0] as SubheadingsFeeForm;
                            StandardConversionForm s_standardConversionForm = xtraTabPage5.Controls[0] as StandardConversionForm;
                            if (s_subheadingsQuantityUnit != null)
                            {
                                s_subheadingsQuantityUnit.DoFilter(info);
                            }
                            if (s_subheadingsFeeForm != null)
                            {
                                s_subheadingsFeeForm.DoFilter(info);
                            }
                            if (s_standardConversionForm != null)
                            {
                                s_standardConversionForm.DoFilter(info);
                            }
                            DisplayTabPage(new string[] { "xtraTabPage3", "xtraTabPage4", "xtraTabPage5", "xtraTabPage6" });
                            this.xtraTabControl2.SelectedTabPageIndex = zm;
                            break;
                        default:
                            InfoType = EInfoType.节点;
                            if (info.XMBM == "措施项目")
                            {
                                this.SelectFixeds(info, "措施项目工料机");
                            }
                            else
                            {
                                this.SelectFixeds(info, "通用项目工料机");
                            }
                            this.xtraTabPage6.PageVisible = false;
                            this.xtraTabControl2.SelectedTabPageIndex = jd;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 选中清单要做的事
        /// </summary>
        private void SelectFixeds(_Entity_SubInfo info, string p_Name)
        {
            xtraTabPage7.Text = p_Name;
            AreaQuantityUnit m_AreaQuantityUnit = xtraTabPage7.Controls[0] as AreaQuantityUnit;
            InventoryGraphAnalysis m_InventoryGraphAnalysis = xtraTabPage8.Controls[0] as InventoryGraphAnalysis;
            if (m_AreaQuantityUnit != null)
            {
                m_AreaQuantityUnit.DoFilter(info);
            }
            if (m_InventoryGraphAnalysis != null)
            {
                m_InventoryGraphAnalysis.DoFilter(info, true);
            }
            DisplayTabPage(new string[] { "xtraTabPage7", "xtraTabPage8" });
        }

        private void DisplayTabPage(string[] TabNames)
        {
            foreach (XtraTabPage tab in this.xtraTabControl2.TabPages)
            {
                foreach (string tabname in TabNames)
                {
                    if (tab.Name == tabname)
                    {
                        tab.PageVisible = true;
                        if (this.Activitie.ProType.Contains("安装"))
                        {
                            this.xtraTabPage6.PageVisible = true;
                        }
                        else
                        {
                            this.xtraTabPage6.PageVisible = false;
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


        /// <summary>
        /// 删除空行数据
        /// </summary>
        /// <param name="ID"></param>
        public void DelKong(int ID)
        {
            DataRow[] infos = this.Activitie.StructSource.ModelMeasures.Select(string.Format(" XMBM is null and  XMMC is null and id<>{0}", ID));
            for (int i = 0; i < infos.Length; i++)
            {
                try
                {
                    infos[i].Delete();
                    // this.Del(infos[i]);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        private void InitPageForm()
        {
            TabAddForm(new SubheadingsQuantityUnit(this.CurrentBusiness, this.Activitie, this), xtraTabPage3);
            TabAddForm(new SubheadingsFeeForm(this.CurrentBusiness, this.Activitie, this), xtraTabPage4);
            TabAddForm(new StandardConversionForm(this.CurrentBusiness, this.Activitie, this), xtraTabPage5);
            TabAddForm(new IncreaseCostsInfoList(), xtraTabPage6);
            TabAddForm(new AreaQuantityUnit(this.CurrentBusiness, this.Activitie, this, "措施项目-清单工料机"), xtraTabPage7);
            TabAddForm(new InventoryGraphAnalysis(this.CurrentBusiness, this.Activitie, this), xtraTabPage8);
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

        /// <summary>
        /// 子目添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {

            ListBoxControl lc = sender as ListBoxControl;
            DataRowView row = lc.SelectedItem as DataRowView;
            if (row == null) return;
            // DataRowView info = this.Source.Current as DataRowView;
            DataRowView info = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as DataRowView;
            if (info != null)
            {
                int id = 0;
                DataRow pRow = null;
                if (info["LB"].Equals("清单"))
                {
                    id = ToolKit.ParseInt(info["ID"]);
                    pRow = info.Row;
                }
                if (info["LB"].Equals("子目") || info["LB"].Equals("子目-增加费"))
                {
                    id = ToolKit.ParseInt(info["PID"]);
                    pRow = this.Activitie.StructSource.ModelMeasures.GetRowByOther(info);
                }
                if (id > 0)
                {

                    _Entity_SubInfo sinfo = new _Entity_SubInfo();
                    ///【2013.2.28 李波修改，作用处理各种备注来源】
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, row.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName, "ZYLB", 1, info["OLDXMBM"].ToString());
                    //GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, row.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName);
                    _Entity_SubInfo finfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(finfo, pRow);
                    if (finfo.ZJFS == _Constant.公式组价) return;
                    _Methods_Fixed fix = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, finfo);
                    fix.Create(-1, sinfo);
                }
            }
            //ListBoxControl lc = sender as ListBoxControl;
            //DataRowView row = lc.SelectedItem as DataRowView;
            //if (row == null) return;
            //_FixedListInfo info = this.Source.Current as _FixedListInfo;
            //_SubheadingsInfo Index = null;
            //if (info == null)
            //{
            //    _SubheadingsInfo sinfo = this.Source.Current as _SubheadingsInfo;
            //    if (sinfo != null)
            //    {
            //        Index = sinfo;
            //        info = sinfo.Parent;
            //    }
            //}
            //if (info != null)
            //{
            //    _SubheadingsInfo info1 = new _MSubheadingsInfo();

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


            //    if (Index != null) info.Create(info1, Index);
            //    else
            //        info.Create(info1);
            //    this.Source.ResetBindings(false);
            //    FocusedNode(info1.ID);
            //    DevExpress.XtraTreeList.Nodes.TreeListNode node1 = treeList1.FindNodeByKeyID(info1.ID);
            //    if (node1 != null)
            //    {
            //        if (node1.ParentNode != null)
            //        {
            //            node1.ParentNode.Expanded = true;
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 清单双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList2_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode node = treeList2.FocusedNode;
            _Entity_SubInfo info = null;
            int Index = -1;
            DataRowView v = this.treeList1.Current as DataRowView;
            if (v == null) return;
            DataRow r = this.GetCSXMFirst();
            if (r == null) return;
            if (v["PID"].Equals(r["ID"]))
            {
                info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, v.Row);
            }
            else if (v["LB"].Equals("清单"))
            {
                int m = ToolKit.ParseInt(v["XH"]);
                if (m >= 1 & m <= 10) return;
                info = new _Entity_SubInfo();
                DataRow row = this.Activitie.StructSource.ModelMeasures.GetRowByOther(v["PID"].ToString());
                _ObjectSource.GetObject(info, row);
                Index = ToolKit.ParseInt(v["Sort"]);
            }
            else if (v["LB"].ToString().Contains("子目"))
            {
                info = new _Entity_SubInfo();
                DataRow row = this.Activitie.StructSource.ModelMeasures.GetRowByOther(v["PID"].ToString());
                Index = ToolKit.ParseInt(row["Sort"]);
                row = this.Activitie.StructSource.ModelMeasures.GetRowByOther(row["PID"].ToString());
                _ObjectSource.GetObject(info, row);
            }
            else
            {
                MessageBox.Show("请选择通用项目！");
                return;
            }
            if (info != null)
            {
                if (node != null)
                {
                    if (!node.HasChildren)
                    {
                        _Motheds_CommonProj met = new _Motheds_CommonProj(this.CurrentBusiness, this.Activitie, info);
                        _Entity_SubInfo minfo = new _Entity_SubInfo();
                        DataRowView view = treeList2.GetDataRecordByNode(node) as DataRowView;
                        if (view != null)
                        {
                            if (IsExistQD(view["NUMBER"].ToString(), true))
                            {
                                MessageBox.Show("相同编号的清单已存在，不能继续添加。");
                                return;
                            }
                            minfo.LB = "清单";
                            minfo.XMMC = view["Name"].ToString();
                            minfo.XMBM = view["NUMBER"].ToString();
                            minfo.DW = "项";


                            //_Motheds_CommonProj com = new _Motheds_CommonProj(this.CurrentBusiness, this.Activitie, info);
                            //_Entity_SubInfo minfo = new _Entity_SubInfo();
                            //minfo.LB = "清单";
                            //minfo.DW = "项";
                            if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                            {
                                Index = -1;
                                DataRow m_dr = this.Activitie.StructSource.ModelMeasures.Select("LB='清单'", "XH DESC").FirstOrDefault();
                                if (m_dr == null) return;
                                DataRow m_jd = this.Activitie.StructSource.ModelMeasures.GetRowByOther(m_dr["PID"].ToString());
                                if (m_jd == null) return;
                                _Entity_SubInfo minfos = new _Entity_SubInfo();
                                _ObjectSource.GetObject(minfos, m_jd);
                                met.Current = minfos;
                            }
                            //com.Create(Index, minfo);
                            //id = minfo.ID;



                            met.Create(Index, minfo);
                            this.RestXH();
                            this.treeList1.RefreshDataSource();
                            FocusedNode(minfo.ID);
                            DevExpress.XtraTreeList.Nodes.TreeListNode node1 = treeList1.FindNodeByKeyID(minfo.ID);
                            if (node1 != null)
                            {
                                if (node1.ParentNode != null)
                                {
                                    node1.ParentNode.Expanded = true;
                                }
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 弹出Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case _ObjectInfo.FILED_JSJC:
                    e.RepositoryItem = this.RItemButton;
                    break;
                case _ObjectInfo.FILED_FL:
                    e.RepositoryItem = this.RItemButtonEdit1;
                    break;
                case _ObjectInfo.FILED_GCLJSS:
                    e.RepositoryItem = this.repositoryItemButtonEdit1;
                    break;
                case _ObjectInfo.FILED_ZJFS:
                    string lb = e.Node.GetValue(_ObjectInfo.FILED_LB).ToString();
                    if (lb.Contains("子目"))
                    {
                        e.Column.OptionsColumn.ReadOnly = false;
                        e.RepositoryItem = this.RComboBox;
                    }
                    if (lb.Equals("清单"))
                    {
                        e.Column.OptionsColumn.ReadOnly = false;
                        e.RepositoryItem = this.RComboBox;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 计算基础选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RItemButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit bt = sender as DevExpress.XtraEditors.ButtonEdit;
            SelectVariableForm form = new SelectVariableForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Activitie = this.Activitie;
            //this.Activitie.Property.Statistics.Begin();
            form.DataSource = this.Activitie.StructSource.ModelProjVariable;
            form.GetValue = bt.Text;
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    DataRowView info = this.treeList1.Current as DataRowView;
                    if (info != null)
                    {
                        info["JSJC"] = form.GetValue;
                        calculator.Rows.Add(info.Row);
                    }
                    //this.Source.ResetBindings(false);
                }
            }
        }
        //private void GetMet(DataRow r)
        //{
        //    _Entity_SubInfo info = new _Entity_SubInfo();
        //    _ObjectSource.GetObject(info, r);

        //    if (info.PID == 0)
        //    {
        //        this.Method = new _Mothod_Measures(this.CurrentBusiness, this.Activitie, info);
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(info.LB) && info.PID != 0)
        //    {
        //        this.Method = new _Motheds_CommonProj(this.CurrentBusiness, this.Activitie, info);
        //        return;
        //    }

        //    if (info.LB.Equals("清单"))
        //    {
        //        this.Method = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, info);
        //        return;
        //    }
        //    if (info.LB.Contains("子目"))
        //    {
        //        this.Method = new _Mothods_MSubheadings(this.CurrentBusiness, this.Activitie, info);
        //        return;
        //    }

        //}
        /// <summary>
        /// 费率选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit bt = sender as DevExpress.XtraEditors.ButtonEdit;
            SelecCSFL form = new SelecCSFL(bt.Text);
            form.Activitie = this.Activitie;
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {

                DataRowView info = this.treeList1.Current as DataRowView;
                if (info != null)
                {
                    info["FL"] = form.ReturnValue;
                }
            }
            // this.Source.ResetBindings(false);

        }

        /// <summary>
        /// 保存当前汇总分析文件
        /// </summary>
        public void Save()
        {
            //this.saveFileDialog1.InitialDirectory = APP.Application.Global.AppFolder.FullName + "模板文件\\措施项目模板";
            //this.saveFileDialog1.Filter = "措施模板(*.cmbx)|*.cmbx";
            DialogResult result = this.saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _Mothod_Measures met = new _Mothod_Measures(this.CurrentBusiness, this.Activitie, null);
                met.Save(this.saveFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 保存当前汇总分析文件
        /// </summary>
        public void load()
        {
            try
            {
                this.openFileDialog1.InitialDirectory = APP.Application.Global.AppFolder.FullName + "模板文件\\措施项目模板";
                // this.openFileDialog1.Filter = "措施模板(*.cmbx)|*.cmbx";
                DialogResult result = this.openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, this.GetCSXMFirst());
                    _Mothod_Measures met = new _Mothod_Measures(this.CurrentBusiness, this.Activitie, info);
                    met.Load(this.openFileDialog1.FileName);
                    this.treeList1.Expand(2);
                    //this.m_Source = this.Activitie.Property.MeasuresProject.DataSource;
                    //this.treeList1.DataSource = this.Source;
                    //this.treeList1.ExpandAll();
                    //this.Source.PositionChanged -= new EventHandler(Source_PositionChanged);
                    //this.Source.PositionChanged += new EventHandler(Source_PositionChanged);
                    //Source_PositionChanged(this.Source, new EventArgs());
                    //this.Activitie.Property.MeasuresProject.Calculate();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 增加通用项目
        /// </summary>
        public void AddCommonroject()
        {

            _Entity_SubInfo info = new _Entity_SubInfo();
            _ObjectSource.GetObject(info, GetCSXMFirst());
            _Mothod_Measures met = new _Mothod_Measures(this.CurrentBusiness, this.Activitie, info);
            info = new _Entity_SubInfo();
            met.Create(-1, info);
            //this.Source.ResetBindings(false);
        }
        /// <summary>
        /// 清单增加
        /// </summary>
        public void AddFixed()
        {
            int id = 0;
            this.treeList1.FocusedNodeChanged -= new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            //this.Source.PositionChanged -= new EventHandler(Source_PositionChanged);
            _Entity_SubInfo info = null;
            DataRowView v = this.treeList1.Current as DataRowView;
            DataRow r = this.GetCSXMFirst();
            if (v == null) return;
            int Index = -1;
            if (v["PID"].Equals(r["ID"]))
            {
                info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, v.Row);
            }
            if (v["LB"].Equals("清单"))
            {
                int m = ToolKit.ParseInt(v["XH"]);

                if (m >= 1 && m <= 4) return;
                DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select(string.Format("ID={0}", v["PID"]));
                if (rows.Length > 0)
                {
                    info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, rows[0]);
                    Index = ToolKit.ParseInt(v["Sort"]);
                }
            }
            if (v["LB"].ToString().Contains("子目"))
            {
                DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select(string.Format("ID={0}", v["PID"]));
                if (rows.Length > 0)
                {
                    DataRow[] rows1 = this.Activitie.StructSource.ModelMeasures.Select(string.Format("ID={0}", rows[0]["PID"]));
                    if (rows1.Length > 0)
                    {
                        info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info, rows1[0]);
                        Index = ToolKit.ParseInt(rows[0]["Sort"]);
                    }
                }
                //Index = (this.Source.Current as _SubheadingsInfo).Parent as _MFixedListInfo;
                //info = Index.Parent;
            }
            if (info != null)
            {

                _Motheds_CommonProj com = new _Motheds_CommonProj(this.CurrentBusiness, this.Activitie, info);
                _Entity_SubInfo minfo = new _Entity_SubInfo();
                minfo.LB = "清单";
                minfo.DW = "项";
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    Index = -1;
                    DataRow m_dr = this.Activitie.StructSource.ModelMeasures.Select("LB='清单'", "XH DESC").FirstOrDefault();
                    if (m_dr == null) return;
                    DataRow m_jd = this.Activitie.StructSource.ModelMeasures.GetRowByOther(m_dr["PID"].ToString());
                    if (m_jd == null) return;
                    _Entity_SubInfo minfos = new _Entity_SubInfo();
                    _ObjectSource.GetObject(minfos, m_jd);
                    com.Current = minfos;
                }
                com.Create(Index, minfo);
                id = minfo.ID;
            }
            else
            {
                Alert("请选择通用项目");
            }
            this.RestXH();
            // this.Source.PositionChanged += new EventHandler(Source_PositionChanged);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            if (id != 0)
                FocusedNode(id);
        }
        /// <summary>
        /// 增加子目
        /// </summary>
        public void AddSubheadings()
        {
            int id = 0;
            //this.Source.PositionChanged -= new EventHandler(Source_PositionChanged);
            this.treeList1.FocusedNodeChanged -= new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            _Entity_SubInfo info = null;
            int Index = -1;
            DataRowView v = this.treeList1.Current as DataRowView;
            if (v["LB"].Equals("清单"))
            {
                info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, v.Row);
            }
            if (v["LB"].ToString().Contains("子目"))
            {
                DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select(string.Format("ID={0}", v["PID"]));
                if (rows.Length > 0)
                {
                    info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, rows[0]);
                    Index = ToolKit.ParseInt(v["Sort"]);
                }
            }
            if (info != null)
            {
                if (info.ZJFS == _Constant.公式组价) return;
                _Mothods_MFixed fix = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, info);
                _Entity_SubInfo minfo = new _Entity_SubInfo();
                minfo.LB = "子目";
                fix.Create(Index, minfo);
                id = minfo.ID;

            }
            else
            {
                Alert("请选择清单");
            }
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            if (id != 0)
            {
                FocusedNode(id);
            }
        }

        public void Delete()
        {
            if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count || APP.Jzbx_pwd)
            {
                DataRowView v = this.treeList1.Current as DataRowView;
                if (v["XMBM"].Equals("措施项目") || v["XMBM"].Equals("C101"))
                {
                    MsgBox.Show("此节点不允许删除！", MessageBoxButtons.OK);
                }
                else
                {
                    if (v["LB"].Equals("清单"))
                    {
                        int m = ToolKit.ParseInt(v["XH"]);
                        if (m > 4)
                        {
                            this.Del();
                        }
                        else
                        {
                            MsgBox.Show("此节点不允许删除！", MessageBoxButtons.OK);
                        }
                    }
                    else if (v["LB"].ToString().Contains("子目"))
                    {
                        DataRow r = this.Activitie.StructSource.ModelMeasures.GetRowByOther(v["PID"].ToString());
                        int m = ToolKit.ParseInt(r["XH"]);
                        if (m > 4)
                        {
                            this.Del();
                        }
                        else
                        {
                            MsgBox.Show("此节点不允许删除！", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        this.Del();
                    }
                }
            }
        }
        /// <summary>
        /// 删除所选
        /// </summary>
        public void Del()
        {
            using (var calculator = new Calculator(CurrentBusiness, Activitie))
            {
                DialogResult d = MsgBox.Show("确认删除?", MessageBoxButtons.OKCancel);
                if (d != DialogResult.OK) return;
                //TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().ToArray();
                TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).OrderByDescending(p => p.Id).ToArray();
                var moduleMemos = new List<string>();
                for (int i = 0; i < nodes.Length; i++)
                {

                    string bh = nodes[i].GetValue(0).ToString();

                    TreeListNode fnode = nodes[i].PrevNode;
                    if (fnode == null) fnode = nodes[i].NextNode;
                    if (fnode == null) fnode = nodes[i].ParentNode;

                    DataRowView view = this.treeList1.GetDataRecordByNode(nodes[i]) as DataRowView;
                    if (view.Row["TX"].ToString().Contains("模板"))
                    {
                        moduleMemos.Add(view.Row["BEIZHU"].ToString());
                    }
                    //update by fuqiang 2013年7月3日
                    DataView table = this.treeList1.DataSource as DataView;
                    DataRow[] currows = table.Table.Select("XMBM='" + bh + "'");

                    if (view == null) return;
                    if (view["SDQD"].Equals(true)) continue;

                    Del(view);

                    //DataRowView obj = this.treeList1.GetDataRecordByNode(item) as DataRowView;
                    ////if (obj is _ObjectInfo)
                    ////{
                    //    Del(obj);
                    ////}

                    //this.treeList1_FocusedNodeChanged(this.treeList1, null);
                    if (fnode != null)
                    {
                        if (fnode.Expanded && fnode.HasChildren) fnode = fnode.LastNode;
                    }
                    if (fnode != null)
                        this.treeList1.FocusedNode = fnode;

                }

                foreach (var moduleMemo in moduleMemos)
                {
                    var moduleRows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("BEIZHU = '{0}'", moduleMemo));
                    foreach (var moduleRow in moduleRows)
                    {
                        var entity = _Entity_SubInfo.Parse(moduleRow);
                        moduleRow.Delete();
                    }
                }

            }

            FastCalculate();

            //}
        }
        public void Del(DataRowView v)
        {

            //TreeListNode fnode = this.treeList1.FocusedNode.PrevNode;
            //if (fnode == null) fnode = this.treeList1.FocusedNode.ParentNode;

            int pid = ToolKit.ParseInt(v["PID"]);
            if (v != null)
            {
                if (!pid.Equals(0))
                {
                    object o = v["LB"];
                    //this.Source.RemoveCurrent();
                    v.Delete();
                    DataRow r = this.Activitie.StructSource.ModelMeasures.GetRowByOther(pid.ToString());
                    this.Method = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntaceMet(this.CurrentBusiness, this.Activitie, r);
                    this.Method.Begin(null);
                    if (o.Equals("清单"))
                    {
                        _Motheds_CommonProj m = new _Motheds_CommonProj(this.CurrentBusiness, this.Activitie, null);
                        m.SetXH();
                    }
                }
            }
            //if (fnode != null)
            //{
            //    if (fnode.Expanded && fnode.HasChildren) fnode = fnode.LastNode;
            //}
            //if (fnode != null)
            //     this.treeList1.FocusedNode = fnode;
        }
        /// <summary>
        /// 模板到分部
        /// </summary>
        public void MobToFB()
        {
            DialogResult dl = MessageBox.Show("您确认将模板还原到分部分项？", "提示", MessageBoxButtons.YesNo);
            if (dl == DialogResult.No) return;
            DataRow[] rows3 = this.Activitie.StructSource.ModelMeasures.Select(" TX='模板'");
            _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, null);
            _Entity_SubInfo sinfo = new _Entity_SubInfo();
            using (var calculator = new Calculator(CurrentBusiness, Activitie))
            {
                for (int j = 0; j < rows3.Length; j++)
                {
                    DataRow item = rows3[j];
                    _Entity_SubInfo info = null;
                    if (string.IsNullOrEmpty(item["QDBH"].ToString())) continue;
                    DataRow row = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(item["QDBH"].ToString());
                    var beizhu = item["BEIZHU"];
                    if (beizhu == null)
                    {
                        continue;
                    }

                    DataRow[] rows0 = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("QDBH='{0}' and XMBM='{1}' and BEIZHU='{2}'", item["QDBH"], item["XMBM"], beizhu.ToString()));
                    if (row != null)
                    {
                        info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info, row);
                        fix.Current = info;
                    }

                    if (info != null)
                    {
                        if (rows0.Length < 1)
                        {
                            _ObjectSource.GetObject(sinfo, item);
                            fix.Create(-1, sinfo);
                            DataRow[] rows1 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", sinfo.ID, sinfo.SSLB));
                            for (int i = 0; i < rows1.Length; i++)
                            {
                                rows1[i].Delete();
                            }
                        }
                        else
                        {
                            foreach (var subsegmentRow in rows0)
                            {
                                _ObjectSource.GetObject(sinfo, subsegmentRow);
                                AreaQuantityUnit m_AreaQuantityUnit = xtraTabPage7.Controls[0] as AreaQuantityUnit;
                                if (m_AreaQuantityUnit != null)
                                {
                                    m_AreaQuantityUnit.DoFilter(sinfo);

                                }

                                DataRow[] rows = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", item["ID"], item["SSLB"]));
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    rows[i]["QDID"] = sinfo.PID;
                                    rows[i]["ZMID"] = sinfo.ID;
                                    rows[i]["SSLB"] = sinfo.SSLB;
                                }

                                // sinfo.GCL = ToolKit.ParseDecimal(item["GCL"]);
                                // this.Activitie.StructSource.ModelSubSegments.UpDate(sinfo);// 让工程量同步

                                calculator.Rows.Add(subsegmentRow);
                            }
                        }
                    }

                    _Entity_SubInfo entity = new _Entity_SubInfo();
                    _ObjectSource.GetObject(entity, item);
                    item.Delete();
                }
            }
        }
        /// <summary>
        /// 根据项目编码获取子目 
        /// </summary>
        /// <param name="xmbm"></param>
        /// <returns></returns>
        private _SubheadingsInfo getSubinfoByBM(string xmbm)
        {
            _SubheadingsInfo finfo = null;
            IEnumerable<_ObjectInfo> infos = from info in this.Activitie.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                                             where info.XMBM == xmbm
                                             select info;
            if (infos.Count() > 0)
            {
                finfo = infos.First() as _SubheadingsInfo;
            }
            return finfo;
        }
        /// <summary>
        /// 根据ID获取一条清单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private _FixedListInfo getinfoByID(int id)
        {
            _FixedListInfo finfo = null;
            IEnumerable<_ObjectInfo> infos = from info in this.Activitie.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                                             where info.ID == id
                                             select info;
            if (infos.Count() > 0)
            {
                finfo = infos.First() as _FixedListInfo;
            }
            return finfo;
        }

        private void treeList1_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {

            TreeList t = sender as TreeList;
            if (t.FocusedColumn == null) return;
            if (t.FocusedNode == null) return;
            string str = t.FocusedColumn.FieldName;
            if (str == "DW" || str == "JBHZ" || str == "GCL") t.FocusedColumn.OptionsColumn.AllowEdit = true;
            DataRowView v = t.GetDataRecordByNode(t.FocusedNode) as DataRowView;

            int m = ToolKit.ParseInt(v["XH"]);
            if (m >= 1 && m <= 4)
            {
                if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = true;
                if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = true;
            }
            else
            {
                if (v["DZBS"].Equals(true))
                {
                    if (!APP.Jzbx_pwd)
                    {
                        if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = true;
                    }
                    if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = true;

                }
                else
                {
                    if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = true;
                }
            
            }

            #region old code
            /*if (v["LB"].Equals("清单"))
            {
                int m = ToolKit.ParseInt(v["XH"]);
                if (m >= 1 && m <= 4)
                {
                    if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = true;
                }
                else
                {
                    if (v["LB"].Equals("子目组价"))
                    {
                        if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = false;
                        if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = true;
                        if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = true;
                    }
                    if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                }

            }
            else if (v["LB"].ToString().Contains("子目") || v["LB"].ToString().Contains("子措施项"))
            {
                if (v["LB"].Equals("子目组价"))
                {
                    if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = true;
                }
                if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = true;
                if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = true;
                if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = true;
                if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = true;
                if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = true;
            }
            else
            {
                if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["JSJC"] != null) this.treeList1.Columns["JSJC"].OptionsColumn.AllowEdit = false;
                if (this.treeList1.Columns["FL"] != null) this.treeList1.Columns["FL"].OptionsColumn.AllowEdit = false;
            }
            if (v["DZBS"].Equals(true))
            {
                this.treeList1.OptionsBehavior.Editable = v["DZBS"].Equals(true) && APP.Jzbx_pwd;
            }
            else
            {
                this.treeList1.OptionsBehavior.Editable = true;// !v["DZBS"].Equals(true);
            }*/

            #endregion
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            treeList1_FocusedColumnChanged(sender, new FocusedColumnChangedEventArgs(this.treeList1.FocusedColumn, this.treeList1.FocusedColumn));
            Source_PositionChanged(sender, null);
        }
        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // _ObjectInfo info = this.Source.Current as _ObjectInfo;
            switch (e.Item.Caption)
            {
                case "增加通用项目节点":
                    this.AddCommonroject();
                    break;
                case "插入清单":
                    this.AddFixed();
                    break;
                case "插入子目":
                    this.AddSubheadings();
                    break;
                case "删除所选":

                    this.Del();
                    // this.treeList1_FocusedNodeChanged(this.treeList1, null);
                    break;
                case "保存模板":
                    this.Save();
                    break;
                case "套用模板":
                    this.load();
                    break;
                case "复制":
                    //info.Copys();
                    break;
                case "粘贴":
                    //info.Paste();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 弹出右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList gv = sender as TreeList;
            TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (hi.Node == null) return;
                gv.FocusedNode = hi.Node;
                DataRowView info = this.treeList1.GetDataRecordByNode(gv.FocusedNode) as DataRowView;
                if (info == null) return;
                DataRow r = GetCSXMFirst();
                if (r == null) return;
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    this.barButtonItemBCMB.Enabled = false;
                    this.barButtonItemTYMB.Enabled = false;
                }
                else
                {
                    this.barButtonItemBCMB.Enabled = true;
                    this.barButtonItemTYMB.Enabled = true;
                }
                //this.barButtonItemBCMB.Enabled = !this.CurrentBusiness.Current.IsDZBS;
                //this.barButtonItemTYMB.Enabled = !this.CurrentBusiness.Current.IsDZBS;



                if (info["ID"].Equals(r["ID"]))
                {
                    this.barButtonItemDelete.Enabled = false;
                }
                else
                {
                    this.barButtonItemDelete.Enabled = !ToolKit.ParseBoolen(info["DZBS"]);
                }
                if (info["LB"].Equals("清单") || info["LB"].ToString().Contains("子目"))
                {
                    barButtonItem8.Enabled = true;
                    int m = ToolKit.ParseInt(info["XH"]);
                    if (m >= 1 && m <= 10)
                    {

                        this.barButtonItemDelete.Enabled = false;
                    }
                    else
                    {
                        if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count)
                        {
                            this.barButtonItemDelete.Enabled = true;
                        }
                        else
                        {
                            this.barButtonItemDelete.Enabled = false;
                        }
                    }
                }
                else
                {
                    barButtonItem8.Enabled = false;
                }
                if ((info["PID"].Equals(r["ID"]) || info["LB"].Equals("清单") || info["LB"].ToString().Contains("子目")) && !info["XMBM"].Equals("C101"))
                {
                    if (info["LB"].Equals("清单"))
                    {
                        int m = ToolKit.ParseInt(info["XH"]);
                        if (m >= 1 && m <= 4)
                        {
                            this.barButtonItemAddQD.Enabled = false;
                            this.barButtonItemAddZM.Enabled = false;
                            this.barButtonItemDelete.Enabled = false;
                        }
                        else
                        {
                            this.barButtonItemAddQD.Enabled = true;
                            this.barButtonItemAddZM.Enabled = true;
                            if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count || APP.Jzbx_pwd)
                            {
                                this.barButtonItemDelete.Enabled = true;
                            }
                            else
                            {
                                this.barButtonItemDelete.Enabled = false;
                            }
                        }
                    }
                    else if (info["LB"].ToString().Contains("子目"))
                    {
                        DataRow temp = this.Activitie.StructSource.ModelMeasures.GetRowByOther(info["PID"].ToString());
                        int m = ToolKit.ParseInt(temp["XH"]);
                        if (m >= 1 && m <= 4)
                        {
                            this.barButtonItemAddQD.Enabled = false;
                            this.barButtonItemAddZM.Enabled = false;
                            this.barButtonItemDelete.Enabled = false;
                        }
                        else
                        {
                            this.barButtonItemAddQD.Enabled = true;
                            this.barButtonItemAddZM.Enabled = true;
                            if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count)
                            {
                                this.barButtonItemDelete.Enabled = true;
                            }
                            else
                            {
                                this.barButtonItemDelete.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        this.barButtonItemAddQD.Enabled = true;
                        this.barButtonItemAddZM.Enabled = true;
                        if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count)
                        {
                            this.barButtonItemDelete.Enabled = true;
                        }
                        else
                        {
                            this.barButtonItemDelete.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.barButtonItemAddQD.Enabled = false;
                    this.barButtonItemAddZM.Enabled = false;
                    this.barButtonItemDelete.Enabled = false;
                }
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    this.barButtonItemDelete.Enabled = false;
                }
                else
                {
                    this.barButtonItemDelete.Enabled = true;
                }
                if (this.Activitie == null) return;
                if (this.Activitie.IsLock) this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private DataRow GetCSXMFirst()
        {
            DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select("PID=0");
            if (rows.Length > 0) return rows[0];
            else return null;
        }
        /// <summary>
        /// 判断info是否存在于通用项目
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private bool IsTYXM(_ObjectInfo info)
        {
            if (info is _CommonrojectInfo && info.XMBM == "C101")
            {
                return true;
            }
            if (info is _MFixedListInfo)
            {
                if ((info as _MFixedListInfo).Parent.XMBM == "C101")
                {
                    return true;
                }
            }
            if (info is _MSubheadingsInfo || info is _FSubheadingsInfo)
            {
                if (((info as _SubheadingsInfo).Parent as _MFixedListInfo).Parent.XMBM == "C101")
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 根据项目编码 创建清单或子目
        /// </summary>
        /// <param name="xmbm"></param>
        private _Entity_SubInfo CreateByXMBM(string xmbm)
        {
            DataRowView info = this.treeList1.Current as DataRowView;
            if (info == null) return null;
            if (info["LB"].Equals("清单"))
            {
                DataRow[] row = APP.Application.Global.DataTamp.MeasuresList.Tables["措施清单"].Copy().Select(string.Format("NUMBER='{0}'", xmbm));
                if (row.Length > 0)
                {
                    info["XMMC"] = row[0]["Name"].ToString();
                    if (info["BEIZHU"].Equals(string.Empty) && !info["XMBM"].Equals(string.Empty))
                    {
                        info["BEIZHU"] = info["XMBM"] + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                    //minfo.XMBM = view["NUMBER"].ToString();
                }
                else
                {
                    if (info["BEIZHU"].ToString().Equals(string.Empty) && !info["XMBM"].Equals(string.Empty))
                    {
                        info["BEIZHU"] = info["XMBM"] + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        if (info["XMMC"].ToString() == string.Empty) info["XMMC"] = "补充清单"; info["TX"] = "jz";
                        //info.GCL = 1;
                    }
                }

                return null;
            }
            else if (info["LB"].ToString().Contains("子目"))
            {
                _Entity_SubInfo pinfo = null;
                int index = -1;
                DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select(string.Format("ID={0}", info["PID"]));
                if (rows.Length > 0)
                {
                    pinfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(pinfo, rows[0]);
                }
                if (pinfo == null) return null;
                _Mothods_MFixed fix = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, pinfo);
                index = ToolKit.ParseInt(info["Sort"]);
                string temp = xmbm.Split(' ')[0];
                DataRow[] row = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy().Select(string.Format("DINGEH='{0}'", temp));
                string JXDE = "15-1,15-2,15-3,15-4,15-5,15-6,15-7,15-8,15-9,15-10,15-11,15-23,15-24,15-25,15-26,15-27,15-28,15-29,15-30,15-31";
                bool flag = false;
                string[] arr = JXDE.Split(',');
                foreach (string item in arr)
                {
                    if (item == temp)
                    {
                        flag = true;
                        break;
                    }
                }
                if (row.Length > 0 && !flag)
                {
                    info.Row.Delete();
                    _Entity_SubInfo sinfo = new _Entity_SubInfo();
                    ///【2013.2.28 李波修改，作用处理各种备注来源】
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, row[0], this.Activitie.Property.Libraries.FixedLibrary.FullName, "ZYLB", 1, pinfo.OLDXMBM);
                    //GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, row[0], this.Activitie.Property.Libraries.FixedLibrary.FullName);
                    sinfo.XMBM = xmbm;
                    fix.Create(index, sinfo);
                    FocusedNode(sinfo.ID);

                    return sinfo;
                }
                else
                {
                    info.Row.Delete();
                    _Entity_SubInfo sinfo = new _Entity_SubInfo();
                    xmbm = xmbm.Replace("补", "");
                    sinfo.XMBM = "补" + xmbm;
                    sinfo.OLDXMBM = "补" + xmbm;
                    sinfo.XMMC = "补充定额";
                    sinfo.LB = "子目";
                    sinfo.TX = "建筑";
                    sinfo.LibraryName = this.Activitie.Property.Libraries.FixedLibrary.FullName;
                    //  sinfo.GCL = 1m;
                    fix.Create(index, sinfo);
                    FocusedNode(sinfo.ID);

                    return sinfo;
                }
            }

            return null;

            // this.Source_PositionChanged(this.m_Source, null);
            //this.m_Source.ResetBindings(false);
        }
        /// <summary>
        /// 判断是否存在相同编号的 清单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private bool IsExistQD(string xmbm)
        {
            IEnumerable<_ObjectInfo> infos = from n in this.Activitie.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                                             where n.XMBM == xmbm
                                             select n;
            if (infos.Count() > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool IsExistQD(string xmbm, bool isCSQD)
        {
            //    _ObjectInfo[] infos1 = GetTYQD();
            //    IEnumerable<_ObjectInfo> infos = from n in infos1.Cast<_ObjectInfo>()
            //                                     where n.XMBM == xmbm
            //                                     select n;

            //    if (infos.Count() > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            return false;
        }
        /// <summary>
        /// 获取通用项目前四条清单
        /// </summary>
        /// <returns></returns>
        //private _ObjectInfo[] GetTYQD()
        //{
        //    IEnumerable<_ObjectInfo> infos = from n in this.Activitie.Property.MeasuresProject.CommonrojectList[0].MFixedList.Cast<_ObjectInfo>()
        //                                     where n.ISTY
        //                                     select n;
        //    return infos.ToArray();
        //}


        private void repositoryItemTextEdit1_Leave(object sender, EventArgs e)
        {

            TextEdit t = sender as TextEdit;
            string newvalue = string.Empty;
            string oldvale = string.Empty;
            if (t.OldEditValue != null)
            {
                oldvale = t.OldEditValue.ToString();
            }
            if (t.EditValue != null)
            {
                newvalue = t.EditValue.ToString();
            }
            if (oldvale != newvalue)
            {
                CreateByXMBM(ToolKit.ToDBC(newvalue));
            }

        }

        public void RestXH()
        {
            _List list = new _List();
            //int m = 1;
            //RestXH(list, this.treeList1.Nodes, ref m);
            //int i = 1;
            //foreach (_FixedListInfo item in list)
            //{
            //    item.XH = i;
            //    i++;
            //}
            // RestXH(list, this.treeList1.Nodes, ref m);
        }
        private void RestXH(_List list, TreeListNodes nodes, ref  int m)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in nodes)
            {
                DataRowView o = item.TreeList.GetDataRecordByNode(item) as DataRowView;
                if (o["LB"].Equals("清单"))
                {
                    //o.BeginEdit();
                    o["XH"] = m;
                    //o.EndEdit();
                    m++;
                }
                else if (!o["LB"].ToString().Contains("子目"))
                {
                    RestXH(list, item.Nodes, ref m);
                }

            }

        }

        private void treeList1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.ToString() == "\r")
            //{
            //    TreeList t = sender as TreeList;
            //    if (t.FocusedColumn.FieldName != "GCL")
            //    {
            //        TreeListColumn col = t.Columns["GCL"];
            //        if (col != null)
            //        {
            //            if (col.Visible)
            //            {
            //                t.FocusedColumn = col;
            //                t.Focus();
            //            }
            //        }
            //    }
            //}
        }

        private void repositoryItemCalcEdit1_Leave(object sender, EventArgs e)
        {
            this.treeList1_FocusedNodeChanged(this.treeList1, null);
        }
        public void FocusedNode(int id)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = this.treeList1.FindNodeByKeyID(id);
            if (node != null) this.treeList1.FocusedNode = node;
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //CheckEdit ck = sender as CheckEdit;
            //this.treeList1.FocusedNode.SetValue(this.treeList1.FocusedColumn, ck.EditValue);
        }

        private void treeList1_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //ButtonEdit bt = sender as ButtonEdit;
            //PrimitiveFormulaForm form = new PrimitiveFormulaForm();
            //form.Current = this.Source.Current as _ObjectInfo;
            //DialogResult r = form.ShowDialog();
            //if (r == DialogResult.OK)
            //{
            //    bt.Text = form.Result.ToString();
            //    _ObjectInfo drv = this.Source.Current as _ObjectInfo;
            //    if (drv != null)
            //    {
            //        drv.GCLJSS = bt.Text;
            //        this.Source.ResetCurrentItem();
            //    }
            //}
        }
        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.Activitie.EndModfity();
            this.Activitie.BeginEdit(this);

            DataRowView v = this.treeList1.Current as DataRowView;
            if (v != null)
            {
                if (e.Column == null) return;
                string FiledName = e.Column.FieldName;
                switch (FiledName)
                {
                    case "JSJC":
                    case "FL":
                        GLODSOFT.QDJJ.BUSINESS._Methods.Build(this.CurrentBusiness, this.Activitie, _Entity_SubInfo.Parse(v.Row)).BeginCurrent();
                        break;
                    case "GCL":
                        GLODSOFT.QDJJ.BUSINESS._Methods.Build(this.CurrentBusiness, this.Activitie, _Entity_SubInfo.Parse(v.Row)).BeginCurrent();
                        break;

                    case "XMBM":
                        DataRow r = v.Row;
                        if (r.HasVersion(DataRowVersion.Current))
                        {
                            string oldvalue = r["XMBM", DataRowVersion.Current].ToString();
                            string newvalue = r["XMBM"].ToString();
                            if (!oldvalue.Equals(newvalue))
                            {
                                var subInfo = this.CreateByXMBM(ToolKit.ToDBC(newvalue));
                            }
                        }

                        break;
                }

                if (FiledName != "XMBM")
                {
                    ModifyAttribute modity = new ModifyAttribute();
                    modity.CurrentValue = v[e.Column.FieldName];
                    modity.OriginalValue = ChangeObject;
                    modity.ObjectName = e.Column.Caption;
                    modity.ModelName = "措施项目";
                    modity.Source = v.Row;
                    modity.FieldName = e.Column.FieldName;
                    //modity.ActingOn = "清单.子目";
                    ChangeObject = null;
                    this.LogContent.Add(modity);
                    //LogContent.Add(e);
                    GetContainer.ALogForm.Init();

                }

                FastCalculate();
            }
        }

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
        public void SetCell(string ColName)
        {
            //设置焦点列
            this.treeList1.FocusedColumn = this.treeList1.Columns[ColName];
        }
        /// <summary>
        /// 修改的实现
        /// </summary>
        /// <param name="p_attr"></param>
        public void Revocation(ModifyAttribute p_attr)
        {
            //还原属性
            /*Command.ModifyObject(p_attr);
            //定位目标
            CurrentTabForm.RevocationRefresh();
            this.Locate(p_attr);
            //改变后刷新
            this.RefreshDataSource();*/

            _Modify_Method.ModifyEdit_Mea(p_attr, this.CurrentBusiness, this.Activitie);
            LogContent.Remove(p_attr);
            GetContainer.ALogForm.Init();
        }

        /// <summary>
        /// 操作的实现
        /// </summary>
        /// <param name="p_attr"></param>
        public void Revocation(ActionAttribute p_attr)
        {

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
                    // this.Source.Position = this.Source.IndexOf(info1.Parent.Parent);
                    //定位工料机
                    this.CurrentTabForm.Locate(info1);
                    break;
                case "清单.子目.工料机":
                    _SubheadingsQuantityUnitInfo info2 = p_Attr.Source as _SubheadingsQuantityUnitInfo;
                    //  this.Source.Position = this.Source.IndexOf(info2.Parent);
                    //定位工料机
                    this.CurrentTabForm.Locate(info2);
                    break;
                case "清单.子目":
                case "清单":
                    this.Activitie.Property.SubSegments.DataSource.Position = this.Activitie.Property.SubSegments.DataSource.IndexOf(p_Attr.Source);
                    //单元格定位
                    this.SetCell(p_Attr.PropertyName);
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
        object ChangeObject = null;

        private void treeList1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            TreeList tl = sender as TreeList;
            DataRowView v = tl.GetDataRecordByNode(e.Node) as DataRowView;
            ChangeObject = v.Row[e.Column.FieldName];
            // this.Activitie.BeginModfity(this.Source.Current, e.Column.FieldName);
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
                    jd = this.xtraTabControl2.SelectedTabPageIndex;
                    break;
                case EInfoType.清单:
                    qd = this.xtraTabControl2.SelectedTabPageIndex;
                    break;
                case EInfoType.子目:
                    zm = this.xtraTabControl2.SelectedTabPageIndex;
                    break;
                default:
                    break;
            }
        }

        private void treeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            TreeList t = sender as TreeList;
            if (e.Node != null)
            {
                if (e.Column.ColumnType == typeof(decimal) || e.Column.ColumnType == typeof(int) || e.Column.FieldName == "FL")
                {
                    decimal d = ToolKit.ParseDecimal(e.CellValue);
                    //int m = Convert.ToInt32(d);
                    if (d == 0)
                    {
                        e.CellText = "";
                    }
                    //else
                    //{
                    //    e.CellText = e.CellValue.ToString().TrimEnd('0');
                    //}

                }
            }
        }
        private void EnterDown(KeyEventArgs e)
        {
            if (this.treeList1.FocusedColumn == null) return;
            if (this.treeList1.FocusedColumn.FieldName == "XMMC") return;

            if (e.KeyCode == Keys.Enter)
            {
                //this.treeList1.
                this.treeList1.HideEditor();
                int begin = this.treeList1.Columns["XMBM"].VisibleIndex;
                int end = this.treeList1.Columns["GCL"].VisibleIndex;
                if (this.treeList1.FocusedColumn.VisibleIndex >= begin && this.treeList1.FocusedColumn.VisibleIndex < end)
                {
                    //跳转到工程量
                    this.treeList1.FocusedColumn = this.treeList1.Columns["GCL"];
                    this.treeList1.ClickCount = 2;
                    this.treeList1.OptionsBehavior.Editable = true;
                    this.treeList1.ShowEditor();
                }
                else
                {
                    _Entity_SubInfo FoucuseInfo = null;
                    DataRowView v = this.treeList1.Current as DataRowView;

                    if (v != null)
                    {
                        if (v["LB"].ToString().Contains("子目"))
                        {
                            this.AddSubheadings();
                        }
                        if (v.Row.RowState == DataRowState.Detached) return;
                        if (v["LB"].Equals("清单"))
                        {
                            this.AddFixed();
                        }
                    }
                    this.treeList1.FocusedColumn = this.treeList1.Columns.ColumnByFieldName("XMBM");
                    this.treeList1.ClickCount = 2;
                    this.treeList1.OptionsBehavior.Editable = true;
                    this.treeList1.ShowEditor();
                }
            }
        }
        /// <summary>
        /// 组价方式发生改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RComboBox_EditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit edit = sender as ImageComboBoxEdit;
            DataRowView v = this.treeList1.Current as DataRowView;
            //_Method met = null;
            if (v == null) return;
            if (v["LB"].Equals("清单"))
            {
                //if (edit.EditValue.Equals(_Constant.公式组价))
                //{
                //    //公式租价要做的事
                //    DataRow[] ropws = this.Activitie.StructSource.ModelMeasures.Select(string.Format("PID={0}", v["ID"]));
                //    if (ropws.Length > 0)
                //    {
                //        DialogResult d = MsgBox.Show("是否删除当前清单下所有子目？", MessageBoxButtons.OKCancel);
                //        if (d == DialogResult.OK)
                //        {
                //            for (int i = 0; i < ropws.Length; i++)
                //            {
                //                ropws[i].Delete();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    //子目组价 
                //    v["JSJC"] = string.Empty;
                //    v["FL"] = 0;
                //}
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, v.Row);
                info.ZJFS = edit.EditValue.ToString();
                _Mothods_MFixed met = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, info);
                met.Begin(null);
            }
            else
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, v.Row);
                info.ZJFS = edit.EditValue.ToString();
                _Mothods_MSubheadings met = new _Mothods_MSubheadings(this.CurrentBusiness, this.Activitie, info);
                met.Begin(null);
            }
        }

        private void treeList1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.treeList1.FocusedColumn.FieldName == "XMMC") return;
                this.treeList1.CloseEditor();
                this.EnterDown(e);
            }
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            this.EnterDown(e);
        }

        private void RaiseColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.treeList1);
        }

        public void LoadControls()
        {
            if (IsLoadedControls)
            {
                return;
            }

            IsLoadedControls = true;
            this.treeList1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            init();
            treeList1_FocusedNodeChanged(this.treeList1, null);
            if (this.ContainerForm != null)
                ContainerForm.AfterStatisticaled += new AfterStatisticaledHandler(wcForm_AfterStatisticaled);
        }

        public void FastCalculate()
        {
            var ps = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(this.Activitie, this.CurrentBusiness);
            ps.CalculateWithouSubsegment();
        }

        private void ReloadTopNodes()
        {
            var c101 = GetC101Node();
            if (c101 == null)
            {
                return;
            }

            var rowView = treeList1.GetDataRecordByNode(c101) as DataRowView;
            if (rowView == null)
            {
                return;
            }

            var row = rowView.Row;
            if (row["XMMC"] != null && row.Field<string>("XMMC") != "通用项目")
            {
                return;
            }

            ReloadNodes(c101);
        }

        private TreeListNode GetC101Node()
        {
            TreeListNode node = treeList1.Nodes.FirstNode;
            if (node == null)
            {
                return null;
            }

            TreeListNode c101 = node.Nodes.FirstNode;
            if (c101 == null)
            {
                return null;
            }

            return c101;
        }

        public void CalculateWithoutHead()
        {
            var rules = new List<string>();
            rules.AddRange(new string[] {
                "c10102","c10103","c10104"
            });

            List<TreeListNode> nodes = base.GetTargetRows(this.treeList1, GetC101Node(), rules, "XMBM");
            foreach (var node in nodes)
            {
                ReloadNodes(node);
            }
        }

        public void CalculateHeadNode()
        {
            var rules = new List<string>();
            rules.AddRange(new string[]{"c10101"
            });

            List<TreeListNode> nodes = GetTargetRows(this.treeList1, GetC101Node(), rules, "XMBM");
            foreach (var node in nodes)
            {
                ReloadNodes(node);
            }
        }

        /// <summary>
        /// Reload datas
        /// </summary>
        /// <param name="node"></param>
        private void ReloadNodes(TreeListNode node)
        {
            if (node == null)
            {
                return;
            }

            var row = this.treeList1.GetDataRecordByNode(node) as DataRowView;
            if (row == null)
            {
                return;
            }

            for (var i = node.Nodes.Count - 1; i >= 0; i--)
            {
                ReloadNodes(node.Nodes[i]);
            }

            Calculator.Calculate(CurrentBusiness, Activitie, row.Row);
        }
    }
}
