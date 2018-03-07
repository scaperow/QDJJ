/*
    所有模块窗体的基础类别
 */
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
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using GOLDSOFT.QDJJ.CTRL;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ABaseForm : BaseForm
    {

        /// <summary>
        /// 界面需要进度条初始化的时候激发(此事件发生在OnLoad之后)
        /// </summary>
        public event WorkerInitHandler WorkerInit;
        /// <summary>
        /// 统计完成后激发
        /// </summary>
        public virtual void OnWorkerInit(object sender, object args)
        {
            if (WorkerInit != null)
            {
                BackgroundWorker AFormInitWorker = new BackgroundWorker();
                AFormInitWorker.WorkerReportsProgress = false;
                AFormInitWorker.DoWork +=new DoWorkEventHandler(AFormInitWorker_DoWork);
                AFormInitWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(AFormInitWorker_RunWorkerCompleted);
                AFormInitWorker.RunWorkerAsync();
                ProgressFrom form = new ProgressFrom(AFormInitWorker);
                form.ShowDialog();
                
            }
        }
        void  AFormInitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
 	        
        }
        void  AFormInitWorker_DoWork(object sender, DoWorkEventArgs e)
        {
 	        
        }
       

        /// <summary>
        /// 每个页面默认都拥有一个 LogContent 对象
        /// </summary>
        private LogContent m_LogContent = new LogContent();

        /// <summary>
        /// 用于存放修改日志信息属性对象
        /// </summary>
        public LogContent LogContent
        {
            get
            {
                return this.m_LogContent;
            }
        }

        /// <summary>
        /// 用于处理功能区时间的参数
        /// </summary>
        private object p_Params = null;
        /// <summary>
        /// 用于处理功能区时间的参数
        /// </summary>
        public object Params
        {
            get
            {
                return this.p_Params;
            }
            set
            {
                this.p_Params = value;
            }
        }

        /// <summary>
        /// 根据业务类型获取容器
        /// </summary>
        public Container GetContainer
        {
            get
            {
                if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
                {
                    return this.ParentForm.ParentForm as Container;
                }
                else if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.UnitProject)
                {
                    return this.ParentForm as Container;
                }
                return null;
            }
        }

        private Container m_BusContainer = null;

        public Container BusContainer
        {
            get
            {
                return this.m_BusContainer;
            }
            set
            {
                if (value is ProjectForm)
                {
                    this.ProjectsForm = value as ProjectForm;
                }
                this.m_BusContainer = value;
            }
        }
        public ABaseForm()
        {
            InitializeComponent();
            this.functionList1.Visible = false;
        }

        /// <summary>
        /// 窗体加载时候激发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitFunctionCtrl();
            OnWorkerInit(this,e);
            //统一添加动作条

        }

        /// <summary>
        /// 重写此方法用于开始页面自动添加动作条
        /// </summary>
        public virtual void PLoadData()
        {

        }

        
        /// <summary>
        /// 当前模块如何初始化控件(初始化功能窗体控件数据)
        /// </summary>
        public virtual void InitFunctionCtrl()
        {
            if (APP.Application == null) return;

            this.functionList1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["FunctionList"];
            this.functionList1.imageListBoxControl1.DoubleClick += new EventHandler(imageListBoxControl1_DoubleClick);
            if (this.Tag!=null)
            {
                this.functionList1.TypeName = this.Tag.ToString(); 
            }
            this.functionList1.DataBind();
        }


        public virtual void RefreshDataSource(){}

        /// <summary>
        /// 此方法在当前窗体被添加到工作区的时候自动调用
        /// </summary>
        public virtual void OnInitForm()
        {

        }

        /// <summary>
        /// 此方法在窗体呗移除工作区时候调用
        /// </summary>
        public virtual void OnRemoveForm()
        {
 
        }

        /// <summary>
        /// 处理增加的属性日志
        /// </summary>
        public virtual void AddAttribute()
        {
 
        }

        /// <summary>
        /// 处理编辑的属性日志
        /// </summary>
        public virtual void EditAttribute()
        {
            
        }

        /// <summary>
        /// 撤销当前数据
        /// </summary>
        public virtual void Revocation()
        {
            
        }
        /// <summary>
        /// 锁定
        /// </summary>
        public virtual void LockUnit()
        { 

        }

        /// <summary>
        /// 解除锁定
        /// </summary>
        public virtual void UnLockUnit()
        { 

        }

        #region  ------添加每个模块应用操作栏的初始化工作------
        /// <summary>
        /// 功能按钮的双机事件处理
        /// </summary>
        /// <param name="sender"></param>`
        /// <param name="e"></param>
        void imageListBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            ImageListBoxControl ilist = (sender as ImageListBoxControl);
            DataRowView view = ilist.SelectedItem as DataRowView;
            if (view != null)
            {
                string action = view["CmdName"].ToString();

                using (CActionFunction af = new CActionFunction(this.CurrentBusiness, this.Activitie))
                {
                    switch (action)
                    {
                        case "ImportEXcel":
                            af.ImportEXcel(this.BusContainer, p_Params);
                            return;
                        default:
                            Type objectType = af.GetType();
                            MethodInfo o_Methods = objectType.GetMethod(action);

                            if (o_Methods != null)
                            {
                                object[] args = new object[2];
                                args[0] = this.BusContainer;//主窗体
                                args[1] = p_Params;//
                                o_Methods.Invoke(af, args);

                               
                                //af.MobToFB(this.BusContainer, args);
                                //af.IncreaseCosts(MainForm, APP.General.CurrentProject);
                                //执行指定的方法
                            }
                            else
                            {
                                MessageBox.Show("对不起,此功能不存在请联系系统维护人员！");
                            }
                          return;
                    }
                    // af.Listguidelines(af, this);
                   

                }
            }
        }
        #endregion        

        public List<TreeListNode> GetTargetRows(TreeListEx tree, TreeListNode parent, List<string> rules, string field)
        {
            var result = new List<TreeListNode>();
            if (parent == null || parent.HasChildren == false)
            {
                return result;
            }


            DataRowView rowView;
            DataRow row;
            foreach (TreeListNode node in parent.Nodes)
            {
                if (rules.Count == 0)
                {
                    break;
                }

                rowView = tree.GetDataRecordByNode(node) as DataRowView;
                if (rowView == null)
                {
                    continue;
                }

                row = rowView.Row;
                if (row[field] == null)
                {
                    continue;
                }

                if (rules.Contains(row.Field<string>(field).ToLower()))
                {
                    rules.Remove(row.Field<string>(field));
                    result.Add(node);
                }
            }
            return result;
        }
    }
}