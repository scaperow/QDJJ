/*
 *   项目管理数据操作此处修改操作方式
 *   项目操作时候此窗体开始工作
 *  
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using GOLDSOFT.QDJJ.UI.Controls;
using DevExpress.XtraBars;
using GOLDSOFT.QDJJ.UI.BaseFroms;
using DevExpress.XtraBars.Docking;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.UI.Class;
using System.Reflection;
namespace GOLDSOFT.QDJJ.UI
{
    public partial class CWellComeProject : Container
    {
        /// <summary>
        /// 获取操作容器(项目中为正在操作的是单位工程还是项目)
        /// </summary>
        public override Container GetWorkContent
        {
            get
            {
                //如果操作的是单位工程
                XtraTabControlEx xtrl = this.WorkPanel.Controls[0] as XtraTabControlEx;
                if (xtrl != null)
                {
                    if (xtrl.SelectedTabPage == null) return null;
                    return (xtrl.SelectedTabPage.Controls[0] as Container) as ProjectForm;
                }
                else
                {
                    return this;
                }
            }
        }

        /// <summary>
        /// 返回当前树选择的单位工程
        /// </summary>
        public _COBJECTS ThreeActivitie
        {
            get
            {
                return this.ProjControls.projectTrees1.SelectItem;
            }
        }

        /// <summary>
        /// 获取项目中正在处理的单位工程
        /// </summary>
        public override _UnitProject Activitie
        {
            get
            {
                if (this.xtraTabControl1.SelectedTabPage == null) return null;
                return this.xtraTabControl1.SelectedTabPage.UnitProject;
            }
        }

        /// <summary>
        /// 获取当前的业务对象中的项目对象
        /// </summary>
        public _Projects Projects
        {
            get
            {
                return this.CurrentBusiness.Current as _Projects;

            }
        }

        /// <summary>
        /// 获取当前工作区域
        /// </summary>
        public override ABaseForm GetWorkAreas
        {
            get
            {
                XtraTabControlEx xtrl = this.WorkPanel.Controls[0] as XtraTabControlEx;
                if (xtrl != null)
                {
                    if (xtrl.SelectedTabPage == null) return null;
                    return (xtrl.SelectedTabPage.Controls[0] as Container).GetWorkAreas as ABaseForm;
                }
                else
                {
                    return this.WorkPanel.Controls[0] as ABaseForm;
                }
            }
        }




        /// <summary>
        /// 获取当前工作区域
        /// </summary>
        public ProjectForm GetProjectForm
        {
            get
            {
                XtraTabControlEx xtrl = this.WorkPanel.Controls[0] as XtraTabControlEx;
                if (xtrl != null)
                {
                    if (xtrl.SelectedTabPage == null) return null;
                    return (xtrl.SelectedTabPage.Controls[0] as Container) as ProjectForm;
                }
                return null;
            }
        }

        //存放已经打开操作的Form集合 (为了第二次打开时候不用从新加载数据)
        private Hashtable FormList = null;

        public CWellComeProject()
        {
            InitializeComponent();
        }


        /// 初始化控件的事件
        /// </summary>
        private void initFormEvent()
        {
            this.ProjControls.projectTrees1.CurrBusiness = this.CurrentBusiness;
            //初始化默认事件
            this.ProjControls.projectTrees1.InitEvent();
            //初始化样式
            this.ProjControls.projectTrees1.UseBar(GOLDSOFT.QDJJ.CTRL.ProjectTrees.EStyleType.Style1);
            //新单项工程调用事件
            this.ProjControls.projectTrees1.Event_New_Engineering.ItemClick += new ItemClickEventHandler(Event_New_Engineering_ItemClick);
            //新单位工程调用事件
            this.ProjControls.projectTrees1.Event_New_UnitProject.ItemClick += new ItemClickEventHandler(Event_New_UnitProject_ItemClick);
            //打开单位工程/单项工程 处理事件
            this.ProjControls.projectTrees1.treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            //切换打开单位工程事件
            this.ProjControls.projectTrees1.bindingSource1.PositionChanged += new EventHandler(bindingSource1_PositionChanged);
            //批量添加事件
            this.ProjControls.projectTrees1.Event_Batch_ADD.ItemClick += new ItemClickEventHandler(Event_Batch_ADD_ItemClick);
            //导入项目事件处理
            this.ProjControls.projectTrees1.Event_Import_IN.ItemClick += new ItemClickEventHandler(Event_Import_IN_ItemClick);
            //导入项目事件处理
            this.ProjControls.projectTrees1.Event_RImport_IN.ItemClick += new ItemClickEventHandler(Event_Import_IN_ItemClick);
            //导出项目事件处理
            this.ProjControls.projectTrees1.Event_Import_OUT.ItemClick += new ItemClickEventHandler(Event_Import_OUT_ItemClick);
            this.ProjControls.projectTrees1.Event_PImport_OUT.ItemClick += new ItemClickEventHandler(Event_PImport_OUT_ItemClick);
            //删除事件节点事件
            this.ProjControls.projectTrees1.Event_Remove.ItemClick += new ItemClickEventHandler(Event_Remove_ItemClick);
            //项目设置密码事件
            this.ProjControls.projectTrees1.BTN_PRO_PWD.ItemClick += new ItemClickEventHandler(BTN_PRO_PWD_ItemClick);
            //工程设置密码事件
            this.ProjControls.projectTrees1.BTN_UN_PWD.ItemClick += new ItemClickEventHandler(BTN_UN_PWD_ItemClick);
            //锁定/解除锁定
            this.ProjControls.projectTrees1.Event_Lock.ItemClick += new ItemClickEventHandler(Event_Lock_ItemClick);
            //删除单位工程选项卡的时候
            this.xtraTabControl1.ControlRemoved += new ControlEventHandler(xtraTabControl1_ControlRemoved);
            //新增单位工程选项卡的时候激发
            this.xtraTabControl1.ControlAdded += new ControlEventHandler(xtraTabControl1_ControlAdded);
            //工作区增加时候
            this.WorkPanel.ControlAdded += new ControlEventHandler(WorkPanel_ControlAdded);
            //工作区被去除时候
            this.WorkPanel.ControlRemoved += new ControlEventHandler(WorkPanel_ControlRemoved);
            //项目统计
            //this.ProjControls.projectTrees1.BTN_PRO_TJ.ItemClick += new ItemClickEventHandler(BTN_PRO_TJ_ItemClick);
            /*
            //初始化默认事件
            this.ProjControl.projectTrees1.InitEvent();
            //初始化样式
            this.ProjControl.projectTrees1.UseBar(GOLDSOFT.QDJJ.CTRL.ProjectTrees.EStyleType.Style1);
            //新单项工程调用事件
            this.ProjControl.projectTrees1.Event_New_Engineering.ItemClick += new ItemClickEventHandler(Event_New_Engineering_ItemClick);
            //新单位工程调用事件
            this.ProjControl.projectTrees1.Event_New_UnitProject.ItemClick += new ItemClickEventHandler(Event_New_UnitProject_ItemClick);
            //打开单位工程/单项工程 处理事件
            this.ProjControl.projectTrees1.treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            //切换打开单位工程事件
            //this.ProjControl.projectTrees1.bindingSource1.PositionChanged += new EventHandler(bindingSource1_PositionChanged);
            //批量添加事件
            this.ProjControl.projectTrees1.Event_Batch_ADD.ItemClick += new ItemClickEventHandler(Event_Batch_ADD_ItemClick);
            //导入项目事件处理
            this.ProjControl.projectTrees1.Event_Import_IN.ItemClick += new ItemClickEventHandler(Event_Import_IN_ItemClick);
            //导出项目事件处理
            this.ProjControl.projectTrees1.Event_Import_OUT.ItemClick += new ItemClickEventHandler(Event_Import_OUT_ItemClick);
            //删除事件节点事件
            this.ProjControl.projectTrees1.Event_Remove.ItemClick += new ItemClickEventHandler(Event_Remove_ItemClick);
            //项目设置密码事件
            this.ProjControl.projectTrees1.BTN_PRO_PWD.ItemClick += new ItemClickEventHandler(BTN_PRO_PWD_ItemClick);
            //工程设置密码事件
            this.ProjControl.projectTrees1.BTN_UN_PWD.ItemClick += new ItemClickEventHandler(BTN_UN_PWD_ItemClick);
            */
        }



        void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        /// <summary>
        /// 锁定/解除锁定（当前项目）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_Lock_ItemClick(object sender, ItemClickEventArgs e)
        {
            //获取当前对象
            _COBJECTS info = this.CurrentBusiness.Current;
            //锁定/解锁
            if (info.State.Equals("0"))
            {
                info.State = "1";
                info.ImageIndex = 3;
                this.ProjControls.projectTrees1.Lock(false);
            }
            else
            {
                info.State = "0";
                info.ImageIndex = 0;
                this.ProjControls.projectTrees1.Lock(true);
            }
            this.CurrentBusiness.Current.StructSource.ModelProject.UpDate(info);
        }

        void xtraTabControl1_ControlRemoved(object sender, ControlEventArgs e)
        {
            XtraTabControlEx tab = sender as XtraTabControlEx;
            if (tab.TabPages.Count <= 0)
            {
                this.ProjControls.projectTrees1.treeList1.FocusedNode = this.ProjControls.projectTrees1.treeList1.Nodes[0];
                this.treeList1_DoubleClick(this.ProjControls.projectTrees1.treeList1, null);
            }
        }



        void WorkPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            XtraTabControlEx xtc = e.Control as XtraTabControlEx;
            if (xtc != null)
            {
                this.bar2.Visible = true;

            }

            ABaseForm form = (e.Control as ABaseForm);
            if (form != null)
            {
                form.OnRemoveForm();
            }
        }

        void Libraries_LibraryChange(GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData p_Library)
        {
            this.MainForm.DoMdiChildChange();
        }


        void WorkPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            //项目操作区与添加进来的

            this.OnModelChange(this, this.GetWorkAreas);
            XtraTabControlEx xtc = e.Control as XtraTabControlEx;
            if (xtc != null)
            {
                this.bar2.Visible = false;

            }

            ABaseForm form = (e.Control as ABaseForm);
            if (form != null)
            {

                form.OnInitForm();
                ActiveWindow.CurrentABaseForm = form;
            }

        }

        /// <summary>
        /// 单位工程密码设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BTN_UN_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {
            CPwdForm form = new CPwdForm();
            form.CurrentBusiness = this.CurrentBusiness;
            form.Source = this.ProjControls.projectTrees1.SelectItem;
            form.ShowDialog();
        }

        /// <summary>
        /// 项目密码设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BTN_PRO_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {

            CPwdForm form = new CPwdForm();
            form.CurrentBusiness = this.CurrentBusiness;
            form.Source = this.CurrentBusiness.Current;
            form.ShowDialog();
        }

        /// <summary>
        /// 删除单位工程调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_Remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult r = MsgBox.Show(_Prompt.删除项目, MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
            {
                return;
            }

            if (this.ProjControls.projectTrees1.CurrBusiness != null)
            {

                DataRowView view = this.ProjControls.projectTrees1.bindingSource1.Current as DataRowView;
                this.xtraTabControl1.Remove(view["ID"]);
                (this.CurrentBusiness as _BusContainer).Remove(view);
                (this.CurrentBusiness as _Pr_Business).Current.NeedCalculate = true;



                _COBJECTS pInfo = this.ProjControls.projectTrees1.SelectItem;

                if (pInfo != null)
                {
                    //this.xtraTabControl1
                    //当先像是单位工程直接执行删除方法
                    //若为单项工程则循环判断 单项工程下的单位工程打开过的都删除
                    _COBJECTS info = this.ProjControls.projectTrees1.SelectItem;

                    switch (info.ObjectType)
                    {
                        case EObjectType.Engineering://单项
                            this.RemoveEngineering(this.CurrentBusiness.Current, info);
                            break;
                        case EObjectType.UnitProject://单位工程
                            this.RemoveUnitProject(info.Parent, info);
                            break;
                    }
                }

                doAction(DefaultAction);
            }
        }

        /// <summary>
        /// 删除单位工程
        /// </summary>
        /// <param name="p_PInfo">父类</param>
        /// <param name="p_info">当前</param>
        private void RemoveUnitProject(_COBJECTS p_PInfo, _COBJECTS p_info)
        {
            _UnitProject cp = p_info as _UnitProject;
            //删除选项卡
            this.xtraTabControl1.Remove(cp);
            //this.ProjControl.projectTrees1.treeList1.BeginUnboundLoad();
            //(this.ProjControls.projectTrees1.CurrBusiness as _BusContainer).Remove(this.ProjControls.projectTrees1.bindingSource1.Current as DataRowView);
            //this.ProjControl.projectTrees1.treeList1.EndUnboundLoad();            
        }

        /// <summary>
        /// 删除单项工程
        /// </summary>
        /// <param name="p_PInfo">父类</param>
        /// <param name="p_info">当前</param>
        private void RemoveEngineering(_COBJECTS p_PInfo, _COBJECTS p_info)
        {

            _Engineering infos = p_info as _Engineering;
            //删除选项卡
            this.xtraTabControl1.Remove(infos);

            //this.ProjControl.projectTrees1.treeList1.BeginUnboundLoad();            
            //(this.ProjControls.projectTrees1.CurrBusiness as _BusContainer).Remove(p_PInfo, p_info);

            //foreach()
            //{}

            //(this.ProjControls.projectTrees1.CurrBusiness as _BusContainer).Remove(p_info as DataRowView);
            this.ProjControls.projectTrees1.bindingSource1.EndEdit();
            //this.ProjControl.projectTrees1.treeList1.EndUnboundLoad();
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            //根据选择判断
            DataRowView row = this.ProjControls.projectTrees1.bindingSource1.Current as DataRowView;
            if (row != null)
            {
                int deep = ToolKit.ParseInt(row["DEEP"]);
                if (deep == 0)
                {
                    this.ProjControls.projectTrees1.Event_Import_IN.Enabled = false;
                }
                else
                {
                    if (this.CurrentBusiness.Current.State == "0")
                    {
                        this.ProjControls.projectTrees1.Event_Import_IN.Enabled = true;

                    }
                }

                if (deep == 1 || deep == 0)
                {
                    this.ProjControls.projectTrees1.Event_Import_OUT.Enabled = false;
                }
                else
                {
                    this.ProjControls.projectTrees1.Event_Import_OUT.Enabled = true;
                }
            }
        }




        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //创建当前的操作为分部分项的处理页面并且将页面保存到处理区域
            string str = e.Item.Tag.ToString();
            DefaultAction = str;
            this.doAction(str);
        }


        /// <summary>
        /// 窗体加载的时候执行此代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CWellComeProject_Load(object sender, EventArgs e)
        {
            this.DataInterface = new CPActionData(this.CurrentBusiness);
            FormList = new Hashtable();
            this.initFormEvent();
            this.init();

            this.Text = this.CurrentBusiness.Current.Name;
            //第一次打开初始化窗体

            //

            //初始化清单树
            this.initList();

            //开启保存提示
            if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
            {
                this.timer1.Start();
            }

            this.CurrentBusiness.FastCalculate();
            InitProjectData(ERevealType.Default);
        }

        public void DefaultFunction()
        {
            if (this.FormList.Count == 0)
            {

                barButtonItem1.PerformClick();
            }
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void init()
        {
            //添加项目清单
            this.ProjControls.projectTrees1.Visible = true;
            this.ProjControls.projectTrees1.Dock = DockStyle.Fill;
            this.dp_Project.ControlContainer.Controls.Add(this.ProjControls.projectTrees1);
            this.DefaultFunction();
        }

        private string DefaultAction = "汇总分析";
        /// <summary>
        /// 要执行那个窗体
        /// </summary>
        /// <param name="p_key"></param>
        private void doAction(string p_key)
        {
            try
            {
                ABaseForm from = null;

                if (FormList.Contains(p_key))
                {
                    _Pr_Business b = this.CurrentBusiness as _Pr_Business;
                    var calculate = b.Current.NeedCalculate;

                    foreach (_UnitProject info in b.ObjectList.Values)
                    {
                        if (info.NeedCalculate)
                        {
                            calculate = true;
                            break;
                        }
                    }


                    if (calculate)
                    {
                        b.FastCalculate();
                    }

                    from = this.FormList[p_key] as ABaseForm;
                    from.MustInit();
                    //第二次加载的时候每次执行
                    from.Init();
                }
                else
                {
                    switch (p_key)
                    {
                        case "项目信息":
                            from = new CBasicInformation();
                            (from as CBasicInformation).Projects = Projects;
                            break;
                        case "汇总分析":
                            from = new HuiZongProjectForm();
                            from.CurrentBusiness = this.CurrentBusiness;
                            break;
                        case "分部分项"://项目分部分项统计
                            from = new ProSubSegmentForm();
                            from.CurrentBusiness = this.CurrentBusiness;
                            break;
                        case "措施项目":
                            from = new ProMeasuresFrom();
                            from.CurrentBusiness = this.CurrentBusiness;
                            break;
                        case "工料机汇总":
                            from = new ProjectSummaryForm();
                            from.CurrentBusiness = this.CurrentBusiness;
                            break;
                        case "参数统计":
                            from = new CParameterStatisticsFrom();
                            from.CurrentBusiness = this.CurrentBusiness;
                            break;
                        case "其他项目":
                            from = new ProOtherForm();
                            from.CurrentBusiness = this.CurrentBusiness;
                            break;
                        case "项目报表":
                            from = new ProReportForm();
                            from.CurrentBusiness = this.CurrentBusiness;
                            from.Activitie = this.Activitie;
                            break;

                    }
                    if (from == null) return;
                    from.MustInit();
                    from.FormBorderStyle = FormBorderStyle.None;
                    from.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
                    //设置为非顶级控件
                    from.TopLevel = false;
                    //显示窗体
                    from.Visible = true;
                    from.BusContainer = this;
                    if (!this.FormList.Contains(p_key))
                        this.FormList.Add(p_key, from);
                    if (p_key == DefaultAction)
                    {
                        InitProjectData(ERevealType.Default);
                    }
                    //加载当前项目操作窗体的功能列表
                }

                //添加之前保存当时的界面配置
                this.WorkPanel.Controls.Clear();
                this.WorkPanel.Controls.Add(from);
                this.OnModelChange(this, from);
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                //MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        /// <summary>
        /// 打开单位工程浏览
        /// </summary>
        private void ViewUnitProject()
        {

            //添加之前保存当时的界面配置
            this.WorkPanel.Controls.Clear();
            //添加单位工程浏览
            this.WorkPanel.Controls.Add(this.xtraTabControl1);


        }

        /// <summary>
        /// 初始化清单树
        /// </summary>
        public void initList()
        {


            //this.ProjControls.projectTrees1.CurrBusiness = this.CurrentBusiness;
            //this.ProjControls.projectTrees1.DataSource = this.CurrentBusiness.Current;
            this.ProjControls.projectTrees1.CurrBusiness = null;
            this.ProjControls.projectTrees1.DataSource = null;

            this.ProjControls.projectTrees1.Invoke(new Action<_Business>(this.ProjControls.projectTrees1.DataBind), new object[] { this.CurrentBusiness });


            //this.ProjControls.projectTrees1.DataBind();
            this.ProjControls.projectTrees1.treeList1.RefreshDataSource();
            this.ProjControls.projectTrees1.treeList1.ExpandAll();

            //获取锁状态
            string state = this.CurrentBusiness.Current.State.ToString();
            if (state.Equals("1"))
            {

                this.ProjControls.projectTrees1.Lock(false);
            }

        }


        #region ----------------------项目操作-----------------------
        /// <summary>
        /// 导出事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_Import_OUT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //找到选中的单位工程或者单项工程对象
            ArrayList list = this.ProjControls.projectTrees1.SelectItems;
            //删除不是单位工程的项目
            if (list.Count > 0)
            {
                CImportOut form = new CImportOut();
                form.CurrentBusiness = this.CurrentBusiness;
                form.DataSource = list;
                form.PutType = "单位工程";
                form.ShowDialog();
            }
        }

        /// <summary>
        /// 导出项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_PImport_OUT_ItemClick(object sender, ItemClickEventArgs e)
        {

            //找到选中的单位工程或者单项工程对象
            ArrayList list = new ArrayList();
            list.Add(this.CurrentBusiness.Current);
            //删除不是单位工程的项目
            if (list.Count > 0)
            {
                CImportOut form = new CImportOut();
                form.CurrentBusiness = this.CurrentBusiness;
                form.DataSource = list;
                form.ShowDialog();
            }
        }

        /// <summary>
        /// 导入事件处理
        /// </summary>
        /// <param name="sender">激发事件源</param>
        /// <param name="e"></param>
        void Event_Import_IN_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                CImportIn form = new CImportIn();
                //当前正在处理的业务对象
                form.CurrentBusiness = this.CurrentBusiness;
                //要将对象导入到指定的数据源对象中
                form.Source = this.ProjControls.projectTrees1.SelectItem;
                DialogResult result = form.ShowDialog();

                //替换导入成功
                if (result == DialogResult.Yes)
                {
                    //成功后需要重新刷新选项卡(如果选项卡存在，如果已经打开需要重新刷新选项卡)
                    _UnitProject up = form.ReplaceObject as _UnitProject;
                    if (up != null)
                    {
                        this.xtraTabControl1.Replace(this, up, form.Source.ID);
                    }

                    doAction(DefaultAction);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        /// <summary>
        /// 项目列表批量添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_Batch_ADD_ItemClick(object sender, ItemClickEventArgs e)
        {

            //此处实现批量添加逻辑

            {
                BatchsForm form = new BatchsForm();
                form.CurrentBusiness = this.CurrentBusiness;
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.initList();
                }
            }

        }


        /// <summary>
        /// 添加单项工程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_New_Engineering_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewEngineeringForm from = new NewEngineeringForm();
            from.CurrentBusiness = this.CurrentBusiness;
            DialogResult r = from.ShowDialog();
            if (r == DialogResult.OK)
            {
                //添加成功重新刷新清单
                this.initList();
            }

        }
        /// <summary>
        /// 为当前项目添加单位工程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_New_UnitProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            //根据操作类别判断如何添加单位工程(
            //1.项目操作下的单位工程添加(必须存在选择单项工程) 
            //2.单项工程下单位工程直接添加
            //1.获取节点的深度

            //判断当前树的结构类型（单位 or 单项）

            switch (this.ProjControls.projectTrees1.DataType)
            {
                case "_Projects"://单位工程
                    this.doTreeAddProject();
                    break;
                case "_Engineering"://单项工程
                    //默认取当前数据对象
                    this.doTreeAddEngineering();
                    break;
            }

        }




        /// <summary>
        /// 单项类型添加(暂时去掉)
        /// </summary>
        private void doTreeAddEngineering()
        {
            /*int level = this.ProjControl.projectTrees1.treeList1.Selection[0].Level;
            int key = -1;
            switch (level)
            {
                case 0:
                    key = Convert.ToInt32(this.ProjControl.projectTrees1.treeList1.Selection[0].GetValue("Key"));
                    break;
                case 1:
                    key = Convert.ToInt32(this.ProjControl.projectTrees1.treeList1.Selection[0].ParentNode.GetValue("Key"));
                    break;
            }
            //如果找到key获取
            if (key != -1)
            {
                CEngineering ce = APP.General.CurrentCEngineering;
                CUnitProject cu = ce.Create();
                NewUnitProjectForm form = new NewUnitProjectForm();
                form.Engineering = ce;
                form.UnitProject = cu;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    this.initList();
                }
            }*/
        }

        //项目类型添加
        private void doTreeAddProject()
        {
            _COBJECTS infos = this.ProjControls.projectTrees1.SelectItem;
            if (infos != null)
            {
                NewUnitProjectForm form = null;
                if (infos.ObjectType == EObjectType.PROJECT)
                {
                    return;
                }

                if (infos.ObjectType == EObjectType.Engineering)
                {
                    _Engineering ce = infos as _Engineering;
                    _UnitProject cu = ce.Create() as _UnitProject;
                    form = new NewUnitProjectForm();
                    form.CurrentBusiness = this.CurrentBusiness;
                    form.Engineering = ce;
                    form.UnitProject = cu;
                }

                if (infos.ObjectType == EObjectType.UnitProject)
                {
                    _Engineering ce = infos.Parent as _Engineering;
                    _UnitProject cu = ce.Create() as _UnitProject;
                    form = new NewUnitProjectForm();
                    form.CurrentBusiness = this.CurrentBusiness;
                    form.Engineering = ce;
                    form.UnitProject = cu;
                }

                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    this.initList();
                }
            }
        }

        #endregion




        /// <summary>
        /// 双击清单列表打开单项工程/单位工程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                BackgroundWorker OpenUnitWorker = new BackgroundWorker();
                OpenUnitWorker.WorkerReportsProgress = false;
                OpenUnitWorker.DoWork += new DoWorkEventHandler(OpenUnitWorker_DoWork);
                OpenUnitWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OpenUnitWorker_RunWorkerCompleted);
                OpenUnitWorker.RunWorkerAsync();
                ProgressFrom form = new ProgressFrom(OpenUnitWorker);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }
        /// <summary>
        /// 打开进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenUnitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _COBJECTS info = e.Result as _COBJECTS;
            _UnitProject unit = info as _UnitProject;
            _Projects pro = info as _Projects;
            if (pro != null)
            {
                //打开项目控制
                //this.WorkPanel
                this.doAction(DefaultAction);
                return;
            }

            if (info != null)
            {
               // Debug.Show(unit.StructSource, "");
                this.OpenByUnitProject(unit);

            }
        }
        /// <summary>
        /// 打开进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenUnitWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _COBJECTS p_Unit = this.ProjControls.projectTrees1.SelectItem as _COBJECTS;
         
            if (p_Unit != null && !string.IsNullOrEmpty(p_Unit.PassWord))
            {
                CPwdForm form = new CPwdForm();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.CurrentBusiness = this.CurrentBusiness;
                form.Source = this.CurrentBusiness.Current;
                form.isJZBX = false;
                DialogResult result = form.ShowDialog();

                if (result != DialogResult.OK)
                {
                    e.Result = p_Unit;
                }

            }


            //获取数据源
            /*if (info != null)
            {
                APP.Methods.Init(info);
            }*/

            if (p_Unit == null || p_Unit.StructSource == null)
            {
                return;
            }

            DataRow[] zmRows = p_Unit.StructSource.ModelMeasures.Select("LB = '子目' or LB = '子目-降效'");
            foreach (DataRow row in zmRows)
            {
                row["SC"] = "True";
            }
            DataRow[] rows = p_Unit.StructSource.ModelMeasures.Select("XMBM like '15-%'");
            string zmCGJX = "1,,2,3,4,5,6,7,8,9,10,11,23,24,25,26,27,28,29,30,31";
            foreach (DataRow row in rows)
            {
                if (zmCGJX.Contains(row["XMBM"].ToString().Substring(3)))
                {
                    row["LB"] = "子目-降效";
                }
            }


            zmRows = p_Unit.StructSource.ModelSubSegments.Select("LB = '子目'");
            DataRow[] qdRows;
            DataRow[] zmqfRows, valRows;
            string f1 = "", f2 = "", f3 = "", f4 = "", f5 = "", f6 = "", s1 = "", s2 = "", s3 = "", s4 = "";
            foreach (DataRow row in zmRows)
            {
                f1 = ""; f2 = ""; f3 = ""; f4 = ""; f5 = ""; f6 = ""; s1 = ""; s2 = ""; s3 = ""; s4 = "";
                if (APP.JJJC == 1)
                {
                    if (p_Unit.StructSource.ModelSubheadingsFee != null)
                    {
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F1'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 1;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F2'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 2;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F3'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 3;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F4'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 4;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F5'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 5;
                        }


                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F6'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 6;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '一'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 7;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '二'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 8;
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '三'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 9;
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '四'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 10;
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '五'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 11;
                        }
                    }
                }
                else if (APP.JJJC == 2)
                {
                    if (p_Unit.StructSource.ModelSubheadingsFee != null)
                    {
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F1'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 1;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F2'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 2;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F3'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 3;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F4'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 4;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F5'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 5;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F6'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 6;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }


                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '一'");
                        if (zmqfRows.Length > 0)
                        {
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                            zmqfRows[0]["JSSX"] = 7;
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '二'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 8;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '三'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 9;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '四'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 10;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '五'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 11;
                            //zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDJSJC"];
                        }
                    }

                }
                else if (APP.JJJC == 3)
                {
                    if (p_Unit.StructSource.ModelSubheadingsFee != null)
                    {
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F1'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 1;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"].ToString() + "DJ";
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F2'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 2;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"].ToString() + "DJ";
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F3'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 3;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"].ToString() + "DJ";
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F4'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 4;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"].ToString() + "DJ";
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F5'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 5;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"].ToString() + "DJ";
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F6'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 6;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"].ToString() + "RCJ";
                        }


                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '一'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 7;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"];
                        }

                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '二'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 8;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '三'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 9;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '四'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 10;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"];
                        }
                        zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '五'");
                        if (zmqfRows.Length > 0)
                        {
                            zmqfRows[0]["JSSX"] = 11;
                            zmqfRows[0]["TBJSJC"] = zmqfRows[0]["BDS"];
                        }
                    }
                }

            }

            e.Result = p_Unit;

        }

        /// <summary>
        /// 根据单位工程打开
        /// </summary>
        /// <param name="p_UnitProject"></param>
        private void OpenByUnitProject(_UnitProject p_UnitProject)
        {
            try
            {
                _UnitProject info = p_UnitProject;
                if (info != null)
                {
                    //如果不存在则需要进行密码控制
                    if (!this.xtraTabControl1.IsExist(info))
                    {
                        //通过验证
                        if (!this.Validation(info))
                        {
                            return;
                        }

                        //使用前初始化对象   
                        //info.Init(APP.Application);
                        //APP.Methods.Init(info);
                    }
                    //创建操作窗体
                    this.xtraTabControl1.CreateNewUnitProject(this, info);
                    this.ViewUnitProject();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        private void bWorker_Open_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bWorker_Open_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


        }

        /// <summary>
        /// 每当一个单位工程选项卡关闭的时候此方法被调用(仅处理项目中活动单位工程的关闭操作)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {

            this.xtraTabControl1.TabPages.Remove((e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs).Page as XtraTabPageEx);
        }

        /// <summary>
        /// 根据单位工程编号查询并且打开单位工程()
        /// </summary>
        public void FindObjectForm(_UnitProject p_UnitProject)
        {
            //根据单位工程编号查询并且打开单位工程
            //1.找到单位工程
            //2.打开单位工程
            //3.定位指定模块
        }

        /// <summary>
        /// 切换单位工程的时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabPageEx xtp = (e.Page as XtraTabPageEx);
            if (xtp != null)
            {
                ActiveWindow.ActiveProjectForm = xtp.GetProjectForm;
                this.OnModelChange(this.MainForm, xtp.GetProjectForm.GetWorkAreas);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        /// <summary>
        /// 用于记录修改前的状态
        /// </summary>
        public object m_DockVisibility = null;

        public override void OnModelChange(object sender, object args)
        {

            ApplicationForm AppForm = sender as ApplicationForm;
            if (AppForm != null)
            {
                if (this.GetWorkAreas.LogContent.Count == 0)
                {
                    //AppForm.Btn_Fun_Rec.Enabled = false;
                }
                else
                {
                    // AppForm.Btn_Fun_Rec.Enabled = true;
                }
                AppForm.DoMdiChildChange();
            }

            ABaseForm form = args as ABaseForm;

            if (form != null)
            {
                this.UseFunction(form);

                //操作日志处理
                if (this.ALogForm != null)
                {
                    this.ALogForm.LogContent = form.LogContent;
                    this.ALogForm.Init();
                }

                //添加功能区

            }

            base.OnModelChange(sender, args);
        }

        /// <summary>
        /// 应用于OnModelChange功能区的过程
        /// </summary>
        /// <param name="form"></param>
        private void UseFunction(ABaseForm form)
        {
            if (this.GetProjectForm != null)
            {
                this.GetProjectForm.dp_Function.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            }
            form.functionList1.Visible = true;
            form.functionList1.Dock = DockStyle.Fill;
            this.dp_Function.ControlContainer.Controls.Clear();
            //如果发现form.functionList1 没有操作则不显示this.dp_Function
            if (form.functionList1.Count == 0)
            {
                ///如果没有操作栏目此处不显示功能区
                ///记录当前状态

                if (this.dp_Function.Visibility.Equals(DevExpress.XtraBars.Docking.DockVisibility.Hidden))
                {
                    m_DockVisibility = this.dp_Function.Visibility;
                    this.dp_Function.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                }
                this.dp_Function.ControlContainer.Controls.Add(form.functionList1);
            }
            else
            {
                if (m_DockVisibility != null)
                {
                    this.dp_Function.Visibility = CDataConvert.ConToValue<DockVisibility>(m_DockVisibility);
                    m_DockVisibility = null;
                }
                this.dp_Function.ControlContainer.Controls.Add(form.functionList1);
            }
        }

        #region -------------------统计项目数据的方法--------------------------

        /// <summary>
        /// 处理统计初始化项目数据线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bWorker_Init_DoWork(object sender, DoWorkEventArgs e)
        {
            //重新计算
            /*  object[] param = e.Argument as object[];
              _Projects infos = param[0] as _Projects;*/
            //计算当前操作的单位工程对象
            //保存当前打开的单位工程对象
            this.CurrentBusiness.Calculate();

            /*
            #region -----------------------------进度条-------------------------------
            //1.循环单位工程加入指定列表
            object[] param = e.Argument as object[];
            _Projects infos = param[0] as _Projects;
            infos.InSerializable(infos.Files);
            ERevealType ert = (ERevealType)param[1];
            _List hList = infos.Reveal.Get(ERevealType.汇总分析);
            _List sList = infos.Reveal.Get(ERevealType.分部分项);
            _List cList = infos.Reveal.Get(ERevealType.措施项目);
            _List hzList = infos.Reveal.Get(ERevealType.项目工料机汇总);

            infos.StructSource.ReLoad(ert);
            //重新记录参数

            //循环
            int i = 0, seed = 0, s_seed = 0, b_seed = 0, hzid = 0, bb = infos.Property.Report.ReportList.Count + 1;
            //措施项目-项目处理
            if (ert == ERevealType.Default || ert == ERevealType.措施项目)
            {
                
                infos.Reveal.ProMeasures.Key = seed++;
                infos.Reveal.ProMeasures.PKey = -1;
                //cList.Add(infos.Reveal.ProMeasures);
                infos.StructSource.ModelMeasures.Add(infos.Reveal.ProMeasures);
            }
            //分部分项-项目处理
            if (ert == ERevealType.Default || ert == ERevealType.分部分项)
            {
                infos.Reveal.ProSubSegment.Key = s_seed++;
                infos.Reveal.ProSubSegment.PKey = -1;
                //sList.Add(infos.Reveal.ProSubSegment);
                infos.StructSource.ModelSubSegments.Add(infos.Reveal.ProSubSegment);
            }
            //项目工料机汇总-项目处理
            int qid = hzid;
            if (ert == ERevealType.Default || ert == ERevealType.项目工料机汇总)
            {

                _ObjectQuantityUnitInfo asd = new _ObjectQuantityUnitInfo();
                asd.ID = ++hzid;
                asd.PID = qid;
                asd.SSDWGC = infos.Name;
                asd.LB = "整个项目";
                hzList.Add(asd);
                qid = asd.ID;
            }
            //创建项目显示报表集合
            infos.Property.Report.ReportListDataSource = new ArrayList();

            //查询出来所有的单项工程
             * DataRow[] EnRows = infos.StructSource.ModelProject.Select("PID = 1");
            //循环单项工程
            foreach (DataRow row in EnRows)
            {
                _Engineering einfo = this.CurrentBusiness.Current.Create() as _Engineering;
                einfo.InSerializable(infos);
                _ObjectSource.GetObject(einfo,row);
                //措施项目-单项处理
                if (ert == ERevealType.Default || ert == ERevealType.措施项目)
                {
                    einfo.Reveal.ProMeasures.PKey = infos.Reveal.ProMeasures.Key;
                    einfo.Reveal.ProMeasures.Key = seed++;
                    //cList.Add(einfo.Reveal.ProMeasures);
                    infos.StructSource.ModelMeasures.Add(einfo.Reveal.ProMeasures,-1,einfo.ID);
                }
                //分部分项-单项处理
                if (ert == ERevealType.Default || ert == ERevealType.分部分项)
                {
                    einfo.Reveal.ProSubSegment.Key = s_seed++;
                    einfo.Reveal.ProSubSegment.PKey = infos.Reveal.ProSubSegment.Key;
                    //sList.Add(einfo.Reveal.ProSubSegment);
                    infos.StructSource.ModelSubSegments.Add(einfo.Reveal.ProSubSegment,-1,einfo.ID);
                }
                //项目工料机汇总-单项工程处理
                int xid = hzid;
                if (ert == ERevealType.Default || ert == ERevealType.项目工料机汇总)
                {

                    _ObjectQuantityUnitInfo asd = new _ObjectQuantityUnitInfo();
                    asd.ID = ++hzid;
                    asd.PID = qid;
                    asd.SSDWGC = einfo.Name;
                    asd.LB = "单项工程";
                    hzList.Add(asd);
                    xid = asd.ID;
                }
                
                //找出单位工程
                DataRow[] UnRows = infos.StructSource.ModelProject.Select(string.Format("PID = {0}", einfo.ID));
                _UnitProject pinfo = null; 
                foreach (DataRow r in UnRows)
                {
                    
                    pinfo = r["UnitProject"] as _UnitProject;
                    if (pinfo == null)
                    {
                        //反序列化
                        pinfo = (this.CurrentBusiness as _Pr_Business).GetObject(r["OBJECT"]) as _UnitProject;
                        pinfo.InSerializable(einfo);
                        APP.Methods.Init(pinfo);
                        //回写到表中
                        infos.StructSource.ModelProject.AppendUnit(pinfo);
                    }
                    else
                    {
                       //pinfo.InSerializable(einfo);
                        //APP.Methods.Init(pinfo);
                    }

                    //措施项目-单位工程处理
                    if (ert == ERevealType.Default || ert == ERevealType.措施项目)
                    {
                        pinfo.Property.MeasuresProject.Load();
                        pinfo.Property.MeasuresProject.Calculate();
                        pinfo.Reveal.ProMeasures.PKey = einfo.Reveal.ProMeasures.Key;
                        pinfo.Reveal.ProMeasures.Key = seed++;
                        //cList.Add(pinfo.Reveal.ProMeasures);
                        infos.StructSource.ModelMeasures.Add(pinfo.Reveal.ProMeasures, pinfo.ID, einfo.ID);
                        //分部分项操作
                        foreach (ISubSegment sub in pinfo.Property.MeasuresProject.ObjectsList)
                        {
                            if (!(sub is _MeasuresProject))
                            {
                                sub.Key = seed++;
                                cList.Add(sub);
                                infos.StructSource.ModelMeasures.Add(sub, pinfo.ID, einfo.ID);
                            }
                        }
                    }
                    //分部分项-单位工程处理
                    if (ert == ERevealType.Default || ert == ERevealType.分部分项)
                    {
                        long key = s_seed++;
                        long pkey = einfo.Reveal.ProSubSegment.Key;
                        pinfo.Reveal.ProSubSegment.PKey = pkey;
                        pinfo.Reveal.ProSubSegment.Key = key;
                        sList.Add(pinfo.Reveal.ProSubSegment);
                        infos.StructSource.ModelSubSegments.Add(pinfo.Reveal.ProSubSegment,pinfo.ID,einfo.ID);
                        //分部分项操作
                        foreach (ISubSegment sub in pinfo.Property.SubSegments.ObjectsList)
                        {
                            if (!(sub is _SubSegments))
                            {
                                sub.Key  = s_seed++;
                                sub.PKey = pinfo.Reveal.ProSubSegment.Key;
                                sList.Add(sub);
                                infos.StructSource.ModelSubSegments.Add(sub,pinfo.ID,einfo.ID);
                            }
                        }
                    }
                    //汇总分析-单位工程处理
                    if (ert == ERevealType.Default || ert == ERevealType.汇总分析)
                    {
                        pinfo.Property.MeasuresProject.Load();
                        pinfo.Property.MeasuresProject.Calculate();
                        pinfo.Property.OtherProject.init();
                        pinfo.Property.Metaanalysis.Init();
                        pinfo.Property.Statistics.Begin();
                        pinfo.Property.Metaanalysis.Calculate();
                        //hList.Add(pinfo.Reveal.ProMetaanalysis);
                        infos.StructSource.ModelMetaanalysis.Add(pinfo.Reveal.ProMetaanalysis, pinfo.ID);
                        this.CurrentBusiness.Current.Property.Statistics.IsCompled = true;
                    }
                    //项目工料机汇总-单位工程处理
                    int wid = hzid;
                    if (ert == ERevealType.Default || ert == ERevealType.项目工料机汇总)
                    {
                        _ObjectQuantityUnitInfo asd = new _ObjectQuantityUnitInfo();
                        asd.ID = ++hzid;
                        asd.PID = xid;
                        asd.SSDWGC = pinfo.Name;
                        asd.LB = "单位工程";
                        hzList.Add(asd);
                        _ObjectQuantityUnitInfo[] m_sdw = pinfo.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Distinct(new MergerSummary()).ToArray();
                        foreach (_ObjectQuantityUnitInfo item in m_sdw)
                        {
                            item.ID = ++hzid;
                            item.PID = asd.ID;
                            hzList.Add(item);
                        }
                    }                    

                    
                    //加载单位报表
                    pinfo.Property.Report.LoadDataSource(ref bb);
                    infos.Property.Report.ReportListDataSource.AddRange(pinfo.Property.Report.ReportListDataSource.ToArray());
                    //统计信息 (为单项工程统计)
                    (einfo.Property.Statistics as _ProjStatistics).Add(pinfo);
                    infos.StructSource.ModelProject.AppendUnit(einfo);



                    i++;
                    this.bWorker_Init.ReportProgress(i);
                }


                //汇总分析-单项工程处理
                if (ert == ERevealType.Default || ert == ERevealType.汇总分析)
                {
                    //hList.Add(einfo.Reveal.ProMetaanalysis);
                    infos.StructSource.ModelMetaanalysis.Add(einfo.Reveal.ProMetaanalysis, einfo.ID);
                }

                //统计信息(为单项工程统计)
                (infos.Property.Statistics as _ProjStatistics).Add(einfo);
                i++;
                this.bWorker_Init.ReportProgress(i);
            }

            //汇总分析-项目处理
            i++;
            if (ert == ERevealType.Default || ert == ERevealType.汇总分析)
            {
                //hList.Add(infos.Reveal.ProMetaanalysis);
                infos.StructSource.ModelMetaanalysis.Add(infos.Reveal.ProMetaanalysis, infos.ID);
            }
            this.bWorker_Init.ReportProgress(i);

            //项目报表
            infos.Property.Report.LoadDataSource();

            barButtonItem2.Enabled = barButtonItem3.Enabled = true;


            #endregion*/
        }

        private void bWorker_Init_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.OnAfterStatisticaled(this, null);
        }

        /// <summary>
        /// 重新加载项目数据
        /// </summary>
        public void InitProjectData(ERevealType p_ERevealType)
        {
            //this.CurrentBusiness.Calculate();
            _Projects info = this.CurrentBusiness.Current as _Projects;
            if (info != null)
            {

                if (info.Reveal == null)
                {
                    info.Reveal = new _Reveal(info);
                }
                bWorker_Init_DoWork(null, null);
                this.OnAfterStatisticaled(this, null);
                /*info.Reveal.Init(p_ERevealType);
                object[] param = new object[2] { info, p_ERevealType };   
                this.bWorker_Init.RunWorkerAsync(param);*/
                /*ProgressAction form = new ProgressAction(this.bWorker_Init);
                form.progressBarControl1.Properties.Maximum = info.StructSource.ModelProject.Rows.Count;
                form.ShowDialog();*/

                /*ProgressFrom form = new ProgressFrom(this.bWorker_Init);
                form.ShowDialog();*/

            }
        }

        void BTN_PRO_TJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.OnBeforeStatistical(this, null);
            InitProjectData(ERevealType.Default);

        }

        #endregion

        /// <summary>
        /// 项目计算方法
        /// </summary>
        public override void Calculate()
        {
            try
            {
                base.Calculate();
                //是否统计过
                //if (this.IsCalculate)
                /*{
                    DialogResult r = MsgBox.Show(_Prompt.项目重新计算, MessageBoxButtons.YesNo);
                    if (r == DialogResult.No)
                    {
                        return;
                    }
                }*/

                this.OnBeforeStatistical(this, null);
                InitProjectData(ERevealType.Default);
                ActiveWindow.AppForm.SetWorkBar();
                this.IsCalculate = true;
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        /// <summary>
        /// 重写撤销方法
        /// </summary>
        public override void Revocation()
        {
            //调用当前Afrom的撤销
            ABaseForm from = GetWorkAreas;
            if (from != null)
            {
                from.Revocation();
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        public override void Save()
        {
            try
            {
             
                this.CurrentBusiness.FastCalculate();
                this.OnBeforeSave(this, null);
                //保存前 取消所有绑定操作
                this.DataInterface.Save();
                this.OnAfterSave(this, null);
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                MessageBox.Show("保存失败，请重新保存!", "金建软件");
            }
        }

        public override void BClose()
        {
            //关闭当前业务对象 释放不在使用的资源
            this.CurrentBusiness.Close();
            this.CurrentBusiness = null;
            FormList = null;
        }
    }
}