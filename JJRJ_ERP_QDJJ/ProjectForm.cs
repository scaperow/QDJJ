/*
 *   当前为单位工程主操作界面
 *   单位工程存在两种创建方式直接创建或者存在项目中
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraBars;
using GLODSOFT.QDJJ.BUSINESS;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraBars.Docking;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProjectForm : Container
    {

        public string DefaultAction = "分部分项";
        /// <summary>
        /// Store previous variables in this dictionary, Use on ModelProjectVariable_ColumnChanged event
        /// </summary>
        Dictionary<string, decimal> ProjectVariables = new Dictionary<string, decimal>();
        private MeasuresProjectForm MeasuresForm = null;
        private OtherProjectForm OtherProject = null;
        private SubSegmentForm SubsegmentForm = null;
        private CMetaanalysisForm MetaanalysisForm = null;
        public static ProjectForm Current;
        private _UnitProject m_Activitie = null;

        protected override void OnActivated(EventArgs e)
        {
            Current = this;
        }

        /// <summary>
        /// 获取当前活动的单位工程对象
        /// </summary>
        public override _UnitProject Activitie
        {
            get
            {
                switch (this.CurrentBusiness.WorkFlowType) //独立开启
                {
                    case EWorkFlowType.UnitProject:
                        return this.CurrentBusiness.Current as _UnitProject;
                        
                    case EWorkFlowType.PROJECT:
                        return this.m_Activitie;
                        
                    default:

                        return null;
                }
            }
            set
            {
                this.Text = value.Name;
                m_Activitie = value;
            }
        }

        /// <summary>
        /// 锁定单位工程 项目中调用
        /// </summary>
        public void LockUnit()
        {
            //循环调用已经打开过的窗体锁定方法
            foreach (ABaseForm form in this.FormList.Values)
            {
                form.LockUnit();
            }
        }

        /// <summary>
        /// 接触锁定单位工程 项目中调用
        /// </summary>
        public void UnLockUnit()
        {
            //循环调用已经打开过的窗体锁定方法
            foreach (ABaseForm form in this.FormList.Values)
            {
                form.LockUnit();
            }
        }
        /// <summary>
        /// 当前单位工程如果嵌套项目中使用的项目窗体对象
        /// </summary>
        public CWellComeProject Parent_Projects;


        /// <summary>
        /// 获取当前操作所属的选项卡对象
        /// </summary>
        public XtraTabPageEx TabPage
        {
            get
            {
                return this.Parent as XtraTabPageEx;
            }
        }

        /// <summary>
        /// 获取当前单位工程的工作区域
        /// </summary>
        public override ABaseForm GetWorkAreas
        {
            get
            {
                return this.WorkPanel.Controls[0] as ABaseForm;
            }
        }

        public BackgroundWorker BWorker_Calculate = null;
       
     
        //存放已经打开操作的Form集合 (为了第二次打开时候不用从新加载数据)
        private Hashtable FormList = null;

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            this.DataInterface = new CUActionData(this.CurrentBusiness);
            ///单位工程不需要项目工具条
            this.dManagerObject.RemovePanel(this.dp_Project);
            this.init();
            //第一次打开初始化窗体
            FormList = new Hashtable();
            //若清单规则不为建筑库 则隐藏显示
            //默认打开分部分项
            this.DefaultFunction();
            BWorker_Calculate = new BackgroundWorker();
            BWorker_Calculate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BWorker_Calculate_RunWorkerCompleted);
            BWorker_Calculate.DoWork += new DoWorkEventHandler(BWorker_Calculate_DoWork);
            // Instance MeasureForm and OtherProject Form.
            this.InstanceForm();

            // Trigger when field has changed.
            this.Activitie.StructSource.ModelProjVariable.RowChanged += ModelProjVariable_RowChanged;
            //this.Activitie.StructSource.ModelOtherProject.RowChanged += ModelProjVariable_RowChanged;
            this.ProjectVariables.Add("FBFXHJ", 0);
            this.ProjectVariables.Add("CSXMHJ", 0);
            this.ProjectVariables.Add("FBFXRGCJHJ", 0);
            this.ProjectVariables.Add("CSXMRGCJHJ", 0);
            this.ProjectVariables.Add("QTXMHJ", 0);

           // this.TimeToFastCalculate = new System.Threading.Timer(delegate { TimeToCalculate(); }, null, 100, 100);

            //开启保存提示
            if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.UnitProject)
            {
                this.timer1.Start();
            }

        }

        private void init()
        {
            this.Text = this.CurrentBusiness.Current.Name;
            //初始化单位工程控件对象
            this.UnitControls.Init(this.Activitie);

            //初始化清单 定额
            this.UnitControls.listGallery1.Visible = true;
            this.UnitControls.fixedLibrary1.Visible = true;
            this.UnitControls.listGallery1.Dock = DockStyle.Fill;
            this.UnitControls.fixedLibrary1.Dock = DockStyle.Fill;

            this.dp_QD.ControlContainer.Controls.Clear();
            this.dp_DE.ControlContainer.Controls.Clear();

            this.dp_QD.ControlContainer.Controls.Add(this.UnitControls.listGallery1);
            this.dp_DE.ControlContainer.Controls.Add(this.UnitControls.fixedLibrary1);
            this.Activitie.Property.Libraries.LibraryChange += new LibraryChangeHandler(Libraries_LibraryChange);
        }

        /// <summary>
        /// 更改定额库的时候激发
        /// </summary>
        /// <param name="p_Library"></param>
        void Libraries_LibraryChange(GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData p_Library)
        {

            //if (p_Library.LibType == "清单库")
            //{
            //    this.m_Activitie.QDLibName = p_Library.LibName;
            //}
            //else 
            //{
            //    this.m_Activitie.DELibName = p_Library.LibName;
            //}
            
            this.UnitControls.Init(this.Activitie);
            
            //更新主界面定额库
            if(this.MainForm != null)
            this.MainForm.DoMdiChildChange();
            
        }

        /// <summary>
        /// 分部分项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //创建当前的操作为分部分项的处理页面并且将页面保存到处理区域
            string str = e.Item.Tag.ToString();
            DefaultAction = str;
            this.doAction(str);
        }

        /// <summary>
        /// 要执行那个窗体
        /// </summary>
        /// <param name="p_key"></param>
        private void doAction(string p_key)
        {
            ABaseForm from = null;

            this.CurrentBusiness.FastCalculate();

            if (FormList.Contains(p_key))
            {
                from = this.FormList[p_key] as ABaseForm;
                from.MustInit();
                //第二次加载的时候每次执行
                from.Init();              
            }
            else
            {
                switch (p_key)
                {
                    case "分部分项":
                        from = new SubSegmentForm();
                        SubsegmentForm = from as SubSegmentForm;
                        break;
                    //case "工程信息":
                    //    from = new  ProInformation();
                       // break;
                    case "基本信息":
                        from = new CBaseUnitProInfo();
                        from.CurrentBusiness = this.CurrentBusiness;
                        (from as CBaseUnitProInfo).UnitProject = this.Activitie;
                        break;
                    case "工料机汇总":
                        from = new UnitSummaryForm(this.Activitie, this.CurrentBusiness);
                        break;
                    case "汇总分析":
                        from = new CMetaanalysisForm();
                        //设置当前的单位工程
                        this.MetaanalysisForm = from as CMetaanalysisForm;
                        this.MetaanalysisForm.UnitProject = this.Activitie;
                        break;
                    case "其他项目":
                        from = new OtherProjectForm(this.Activitie);
                        break;
                    case "措施项目":
                        from = new MeasuresProjectForm();
                        break;
                    case "工程历史":
                        from = new CHistoryForm();
                        break;
                    case "报表":
                        from = new ReportForm();
                        break;
                    //case "参数设置":
                    //    from = new ParameterSettings();
                        break;
                    case "单位工程自检":
                        from = new ProjectCheck();
                        break;
                }

                if (from == null) return;
                from.CurrentBusiness = this.CurrentBusiness;
                from.Activitie = this.Activitie;
                from.BusContainer = this;
                from.TopLevelForm = this.MainForm;
                from.FormBorderStyle = FormBorderStyle.None;
                from.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
                //设置为非顶级控件
                from.TopLevel = false;
                //显示窗体
                from.Visible = true;
                this.FormList.Add(p_key,from);
            }

            //添加之前保存当时的界面配置
            this.WorkPanel.Controls.Clear();
            this.WorkPanel.Controls.Add(from);

            if (Parent_Projects != null)
            {
                Parent_Projects.OnModelChange(this, from);
            }
            else
            {                
                this.OnModelChange(this, from);
            }
        }

        public void DefaultFunction()
        {
            if (this.FormList.Count == 0)
            {
                barButtonItem5.PerformClick();
            }
        }

        /// <summary>
        /// 当工作区域添加窗体的时候调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            ABaseForm form = (e.Control as ABaseForm);
            if (form != null)
            {
                form.OnInitForm();
            }
            
        }

        /// <summary>
        /// 当工作区域删除窗体的时候调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            ABaseForm form = (e.Control as ABaseForm);
            if (form != null)
            {
                form.OnRemoveForm();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
       

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
                    //AppForm.Btn_Fun_Rec.Enabled = true;
                }
            }
            //添加功能区
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
                form.functionList1.Visible = true;
                form.functionList1.Dock = DockStyle.Fill;
                this.dp_Function.ControlContainer.Controls.Clear();
                this.dp_Function.ControlContainer.Controls.Add(form.functionList1);
                
                
            }
            base.OnModelChange(sender, args);
        }

        /// <summary>
        /// 用于记录修改前的状态
        /// </summary>
        public object m_DockVisibility = null;
        /// <summary>
        /// 应用于OnModelChange功能区的过程
        /// </summary>
        /// <param name="form"></param>
        private void UseFunction(ABaseForm form)
        {
           
            //this.dp_Function.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            
            form.functionList1.Visible = true;
            form.functionList1.Dock = DockStyle.Fill;
            this.dp_Function.ControlContainer.Controls.Clear();
            //如果发现form.functionList1 没有操作则不显示this.dp_Function
            if (form.functionList1.Count == 0)
            {
                ///如果没有操作栏目此处不显示功能区
                ///记录当前状态
                if (this.dp_Function.Visibility != DockVisibility.Hidden)
                    m_DockVisibility = this.dp_Function.Visibility;
                this.dp_Function.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
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

        public override void Save()
        {
            base.Save();
        }

        public override void Calculate()
        {
            base.Calculate();
            //是否统计过
            //if (this.IsCalculate)
            /*{
                DialogResult r = MsgBox.Show(_Prompt.工程重新计算, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    return;
                }
            }*/
            this.OnBeforeStatistical(this, null);

            _Projects info = this.CurrentBusiness.Current as _Projects;
            if (info != null)
            {

                if (info.Reveal == null)
                {
                    info.Reveal = new _Reveal(info);
                }
            }

            this.CurrentBusiness.Calculate();
            this.OnAfterStatisticaled(this, null);
            ActiveWindow.AppForm.SetWorkBar();
            this.IsCalculate = true;

            /*this.BWorker_Calculate.RunWorkerAsync();
            ProgressFrom form = new ProgressFrom(this.BWorker_Calculate);
            form.ShowDialog();*/
            
            /*this.CurrentBusiness.Current.Property.SubSegments.Statistics.Calculate();
            this.CurrentBusiness.Current.Property.MeasuresProject.Load();
            this.CurrentBusiness.Current.Property.MeasuresProject.Calculate();
            this.CurrentBusiness.Current.Property.OtherProject.init();
            this.CurrentBusiness.Current.Property.Metaanalysis.Init();
            this.CurrentBusiness.Current.Property.Statistics.Begin();
            this.CurrentBusiness.Current.Property.Metaanalysis.Calculate();
            this.CurrentBusiness.Current.Property.Report.LoadDataSource();
            this.IsCalculate = true;*/
        }

        void BWorker_Calculate_DoWork(object sender, DoWorkEventArgs e)
        {
            this.CurrentBusiness.Calculate();
        }

        void BWorker_Calculate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.OnAfterStatisticaled(this, null);
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

        private void InstanceForm()
        {
            MeasuresForm = new MeasuresProjectForm()
            {
                CurrentBusiness = this.CurrentBusiness,
                Activitie = this.Activitie,
                BusContainer = this,
                TopLevelForm = this.MainForm,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                //设置为非顶级控
                TopLevel = false,
                //显示窗体
                Visible = true
            };

            FormList["措施项目"] = MeasuresForm;
            MeasuresForm.LoadControls();

            OtherProject = new OtherProjectForm(this.Activitie)
            {
                CurrentBusiness = this.CurrentBusiness,
                Activitie = this.Activitie,
                BusContainer = this,
                TopLevelForm = this.MainForm,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                //设置为非顶级控
                TopLevel = false,
                //显示窗体
                Visible = true
            };

            FormList["其他项目"] = OtherProject;
            OtherProject.LoadControls();
        }

        void ModelProjVariable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Detached)
            {
                Activitie.NeedCalculate = true;
                return;
            }

            var key = e.Row.Field<string>("Key");
            var value = e.Row.Field<decimal>("Value");

            if (ProjectVariables.ContainsKey(key))
            {
                if (ProjectVariables[key] != value)
                {
                    ProjectVariables[key] = value;

                    Activitie.NeedCalculate= true;

                    return;
                }
            }
        }
    }

}