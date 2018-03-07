using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class BaseControl : UserControl
    {
        /// <summary>
        /// 创建的业务对象
        /// </summary>
        private _Business m_CurrentBusiness = null;

        /// <summary>
        /// 当前正在处理的
        /// </summary>
        public _Business CurrentBusiness
        {
            get { return this.m_CurrentBusiness; }
            set { this.m_CurrentBusiness = value; }
        }

        private _UnitProject m_Activitie = null;

        /// <summary>
        /// 获取当前活动的单位工程对象
        /// </summary>
        public _UnitProject Activitie
        {
            get { return this.m_Activitie; }
            set { this.m_Activitie = value; }
        }

        public BaseControl()
        {
            InitializeComponent();
        }
    }
}
