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
using DevExpress.XtraBars.Ribbon;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CBaseForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 父窗体对象
        /// </summary>
        public RibbonForm MdiParent = null;
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
        public _UnitProject Activitie
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
        /// 是否作为窗体集成(默认为是)
        /// </summary>
        public bool isBotton
        {
            set
            {
                this.panelControl1.Visible = value;
            }
            get
            {
                return this.panelControl1.Visible;
            }
        }

        public CBaseForm()
        {
            InitializeComponent();
            initForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            //统一为更换皮肤
            //APP.DataObjects.GColor.GlobalStyleChange += new GlobalStyleChangeHandler(GlobalStyleChange);
            //第一次加载窗体的时候调用
            //this.GlobalStyleChange();
        }

        /// <summary>
        /// 样式改变后激发的事件(每个需要用到的控件样式的地方重写此方法并且第一次加载的时候调用)
        /// </summary>
        public virtual void GlobalStyleChange(){}

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void initForm()
        {

        }
    }
}