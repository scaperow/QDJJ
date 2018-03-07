/*
 *   业务对象的窗体基础类别
 *   继承此窗体
 *   //次容器可能是项目也可能是单位工程
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
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.CTRL;
using System.Reflection;
using ZiboSoft.Commons.Common;
using System.IO;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 隶属于应用程序的MDI业务
    /// </summary>
    public partial class Container : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// 发生在统计之前
        /// </summary>
        public event BeforeStatisticalHandler BeforeStatistical;
        /// <summary>
        /// 发生在统计之后
        /// </summary>
        public event AfterStatisticaledHandler AfterStatisticaled;
        /// <summary>
        /// 发生在保存之前
        /// </summary>
        public event BeforeSaveHandler BeforeSave;
        /// <summary>
        /// 发生在保存之后
        /// </summary>
        public event AfterSaveHandler AfterSave;

        /// <summary>
        /// 发生在保存之后
        /// </summary>
        public virtual void OnAfterSave(object sender, object args)
        {
            if (AfterSave != null)
            {
                this.AfterSave(sender, args);
            }

        }
        /// <summary>
        /// 发生在保存之前
        /// </summary>
        public virtual void OnBeforeSave(object sender, object args)
        {
            if (BeforeSave != null)
            {
                this.BeforeSave(sender, args);
            }

        }
        /// <summary>
        /// 统计完成后激发
        /// </summary>
        public virtual void OnAfterStatisticaled(object sender, object args)
        {
            if (AfterStatisticaled != null)
            {
                this.AfterStatisticaled(sender, args);
            }
        }

        /// <summary>
        /// 统计完成后
        /// </summary>
        public virtual void OnBeforeStatistical(object sender, object args)
        {
            if (BeforeStatistical != null)
            {
                this.BeforeStatistical(sender, args);
            }
        }
        /// <summary>
        /// 获取当前时间
        /// </summary>
        private DateTime CurrDate = DateTime.Now;

        /// <summary>
        /// 是否计算过
        /// </summary>
        public bool IsCalculate = false;

        /// <summary>
        /// 如何处理数据操作
        /// </summary>
        public IDataInterface DataInterface = null;

        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event ModelChangeHandler ModelChange;

        /// <summary>
        /// 当选择模块发生变化之后激发
        /// </summary>
        public virtual void OnModelChange(object sender, object args)
        {
            if (ModelChange != null)
            {
                this.ModelChange(sender, args);
                ABaseForm form = args as ABaseForm;
                this.FixedVisble(form);
                this.SetCurrForm(form);
            }
        }

        private void SetCurrForm(ABaseForm form)
        {
            ActiveWindow.CurrentABaseForm = form;
            ActiveWindow.AppForm.SetWorkBar();
        }

        /// <summary>
        /// 清单库的显示与隐藏
        /// </summary>
        /// <param name="form"></param>
        private void FixedVisble(ABaseForm form)
        {
            if (form != null)
            {
                if (form.Tag.Equals("分部分项"))
                {
                    /*if (form.ProjectsForm.dp_QD.Visibility != DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
                        form.ProjectsForm.dp_QD.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;*/
                    if (form.CurrentBusiness.Current.IsDZBS&&!APP.Jzbx_pwd)
                    {
                        form.ProjectsForm.dp_DE.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                        if (form.ProjectsForm.dp_QD.Visibility != DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
                            form.ProjectsForm.dp_QD.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                    }
                    else
                    {
                        form.ProjectsForm.dp_QD.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                        if (form.ProjectsForm.dp_DE.Visibility != DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
                            form.ProjectsForm.dp_DE.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                    }

                }
                else if (form.Tag.Equals("措施项目"))
                {
                    form.ProjectsForm.dp_DE.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                    form.ProjectsForm.dp_QD.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                }
                else
                {
                    if (form.ProjectsForm != null)
                    {
                        form.ProjectsForm.dp_DE.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        form.ProjectsForm.dp_QD.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                    }
                }
            }
           
        }

        /// <summary>
        /// 用于统计当前业务数据(子类实现各自计算方法)
        /// </summary>
        public virtual void Calculate()
        {
            
        }


        /// <summary>
        /// 默认显示操作日志界面对象
        /// </summary>
        public LogForm ALogForm
        {
            get
            {
                if (MainForm == null) return null;
                return this.MainForm.ALogForm;
            }
        }
        

        /// <summary>
        /// 获取或设置当前容器正在操作的单位工程对象
        /// </summary>
        public virtual _UnitProject Activitie
        {
            get;
            set;
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


        public virtual Container GetWorkContent
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前的工作区域对象
        /// </summary>
        public virtual ABaseForm GetWorkAreas
        {
            get
            {
                return null;
            }
        }

        private ApplicationForm _mainForm = null;

        /// <summary>
        /// 获取顶级窗体控件
        /// </summary>
        public ApplicationForm MainForm
        {
            get
            {
                if (this.TopLevelControl != null)
                {
                    return this.TopLevelControl as ApplicationForm;
                }
                else
                {
                    return _mainForm;
                }
            }
            set
            {
                _mainForm = null;
            }
        }

        public Container()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体容器加载的时候执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Container_Load(object sender, EventArgs e)
        {
            //this.dp_Project.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            //如果当前业务是项目 此处直接开始
            //this.timer1.Start();
        }

        /// <summary>
        /// 另存为操作
        /// </summary>
        public virtual void SaveAs()
        {
            //业务保存方法调用
            
        }

        /// <summary>
        /// 开启密码效验窗体
        /// </summary>
        /// <returns></returns>
        public virtual bool Validation(_COBJECTS p_info)
        {
            //如果为null或者为空验证通过
            if (p_info.PassWord != string.Empty)
            {
                CValidationPWD form = new CValidationPWD();
                form.Source = p_info;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //验证通过
                    return true;
                }
                return false;
            }
            return true;
        }
       

        #region---------用于保存当前业务的线程操作-----------------------

        /// <summary>
        /// 保存当前业务窗体的操作
        /// </summary>
        public virtual void Save()
        {

            //保存前调用计算
            //this.CurrentBusiness.Calculate();
            //保存前 取消所有绑定操作
            this.DataInterface.Save();
        }

        private void bWorker_Save_DoWork(object sender, DoWorkEventArgs e)
        {
            //this.CurrentBusiness.Save();
            
        }

        private void bWorker_Save_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bWorker_Save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
        }
        /// <summary>
        /// 撤销
        /// </summary>
        public virtual void Revocation()
        {
 
        }
        #endregion

        public bool IsAppClose = false;
        #region  ------在窗口关闭之前保存项目------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //直接关闭
            if (IsAppClose)
            {
                e.Cancel = false;
                return;
            }

            //关闭前保存提示是否保存项目
            //当前窗体用户发起
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string spr = string.Format("是否保存计价工程文件【{0}】修改？",this.CurrentBusiness.Current.Name);

                DialogResult r = MsgBox.Show(spr, MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    //保存当前活动项目
                    this.Save();
                    e.Cancel = false;
                }
                else if(r == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                MsgBox.Alert(string.Format("当前工程-{0} 正在使用中，请先关闭后尝试！",this.CurrentBusiness.Current.Name));
                e.Cancel = true;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //关闭之后释放资源
            this.BClose();
            base.OnFormClosed(e);
        }
       #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            //取当前时间
            DateTime cur = DateTime.Now;
            long idt = CDataConvert.ConToValue<long>(APP.Application.Global.Configuration.Get("自动保存时间"));
            if (idt > 0)
            {
                DateTime time = this.CurrDate.AddMinutes(idt);
                if (time <= cur)
                {
                    //提醒保存操作
                    this.alertControl1.Show(this, "提示", string.Format("您已有{0}分钟没有保存项目，请及时保存数据！", idt));
                    this.CurrDate = DateTime.Now;
                    
                }
            }
            this.timer1.Start();
        }

        private void alertControl1_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {
            
        }

        private void alertControl1_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            e.AlertForm.Close();
            this.Save();
        }

        /// <summary>
        /// 当前容器业务关闭的时候调用的方法
        /// </summary>
        public virtual void BClose()
        {
            //关闭当前业务
        }
    }
}