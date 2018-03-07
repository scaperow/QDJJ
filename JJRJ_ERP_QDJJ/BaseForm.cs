using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.CTRL;
using System.Reflection;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 父级窗体
        /// </summary>
        private Form m_AParentForm = null;
        /// <summary>
        /// 获取或设置：父级窗体
        /// </summary>
        public Form AParentForm
        {
            get { return m_AParentForm; }
            set { m_AParentForm = value; }
        }
        /// <summary>
        /// 创建的业务对象
        /// </summary>
        private _Business m_CurrentBusiness = null;

        /// <summary>
        /// 当前正在处理的
        /// </summary>
        public _Business CurrentBusiness
        {
            get
            {
                
                return this.m_CurrentBusiness;
            }
            set
            {
                this.m_CurrentBusiness = value;
            }
        }

        private _UnitProject m_Activitie = null;

        /// <summary>
        /// 获取当前活动的单位工程对象
        /// </summary>
        public  _UnitProject Activitie
        {
            get
            {
                return this.m_Activitie;
            }
            set
            {
                this.m_Activitie = value;
            }
        }


        /// <summary>
        /// 当前模块页面的主窗体页面
        /// </summary>
        private ApplicationForm m_TopLevelForm = null;

        /// <summary>
        /// 获取或设置顶级窗体
        /// </summary>
        public ApplicationForm TopLevelForm
        {
            get
            {
                return this.m_TopLevelForm;
            }
            set
            {
                this.m_TopLevelForm = value;
            }
        }

        /// <summary>
        /// 获取或设置当前的项目工作窗体
        /// </summary>
        private ProjectForm m_ProjectsForm = null;

        /// <summary>
        /// 获取或设置当前的项目工作窗体
        /// </summary>
        public ProjectForm ProjectsForm
        {
            get
            {
                return this.m_ProjectsForm;
            }
            set
            {
                this.m_ProjectsForm = value;
            }
        }


        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否从新加载窗体
        /// </summary>
        public bool IsReloadForm = false;

        /// <summary>
        /// 如果子出窗体每次打开后需要初始化重写此方法实现
        /// </summary>
        public virtual void  Init()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (APP.DataObjects != null)
            {
                APP.DataObjects.GColor.GlobalStyleChange += new GlobalStyleChangeHandler(GlobalStyleChange);
            }
            GlobalStyleChange();
        }

        /// <summary>
        /// 样式改变后激发的事件(每个需要用到的控件样式的地方重写此方法并且第一次加载的时候调用)
        /// </summary>
        public virtual void GlobalStyleChange() { }


        #region -------------------提示框-------------------

        /// <summary>
        /// 提示框只有提示的
        /// </summary>
        /// <param name="str"></param>
        public virtual void Alert(string str)
        {
            MessageBox.Show(str,"提示",MessageBoxButtons.OK);
        }

        #endregion

        /// <summary>
        /// 必须初始化执行的代码 每个窗体
        /// </summary>
        public virtual void MustInit()
        {
            //this.IsReloadForm =  this.Activitie.isReload;
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

                    // af.Listguidelines(af, this);
                    Type objectType = af.GetType();
                    MethodInfo o_Methods = objectType.GetMethod(action);
                    if (o_Methods != null)
                    {
                        object[] args = new object[2];
                        args[0] = this.m_TopLevelForm;
                        args[1] = this.m_Activitie;
                       o_Methods.Invoke(af, args);

                        //af.Measures_Del(af, args);
                        //af.IncreaseCosts(MainForm, APP.General.CurrentProject);
                        //执行指定的方法
                    }
                    else
                    {
                        MsgBox.Alert("对不起,此功能不存在请联系系统维护人员！");
                    }

                }
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //if (this.Activitie == null) return;
            //if (!this.Activitie.IsLock)
            //{
            //    this.Enabled = false;
            //}
            //else
            //{
            //    this.Enabled = true;
            //}
        }
        public override void Refresh()
        {
            LockActivitie();
            base.Refresh();
        }
         /// <summary>
         /// 单位工程的锁定
         /// </summary>
        public  virtual  void LockActivitie()
        {
           
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public virtual void RefreshDataSource(){}

        /// <summary>
        /// 撤消后的刷新
        /// </summary>
        public virtual void RevocationRefresh() { }
        /// <summary>
        /// 为撤销准备的定位操作
        /// </summary>
        /// <param name="p_Attr"></param>
        public virtual void Locate(object p_Attr){}

        /// <summary>
        /// 显示隐藏列统一实现
        /// </summary>
        public virtual void DisplayColumns(object p_CurrCtrl)
        {
           
            SelectSubsegmenColumn form = new SelectSubsegmenColumn();
            form.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            form.Control = p_CurrCtrl;
            DialogResult r = form.ShowDialog(this);
            if (r == DialogResult.OK)
            {

            }
        }

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
    }
}