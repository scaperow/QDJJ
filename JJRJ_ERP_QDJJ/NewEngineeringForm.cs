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

namespace GOLDSOFT.QDJJ.UI
{
    public partial class NewEngineeringForm : CBaseForm
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
            get
            {
                return this.m_CurrentBusiness;
            }
            set
            {
                this.m_CurrentBusiness = value;
            }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        private _COBJECTS m_Source = null;

        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        public _COBJECTS Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                //若为项目(默认取项目的对象) 
                this.m_Source = value;
            }
        }

        public NewEngineeringForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            switch (this.CurrentBusiness.WorkFlowType)
            {
                case EWorkFlowType.PROJECT:
                    this.createByProject();
                    break;
                case EWorkFlowType.Engineering:
                    this.createByEngineering();
                    break;
            }

        }

        /// <summary>
        /// 项目创建方式
        /// </summary>
        private void createByProject()
        {
            //当前项目接受添加新的单项工程
            ///提交的数据源
            if (this.basisInformation1.Validating())
            {
                this.basisInformation1.Commit();
                (this.CurrentBusiness as _Pr_Business).Add(this.Source);
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 单项工程创建方式
        /// </summary>
        private void createByEngineering()
        {
            //自己本身就是单项工程
            if (this.basisInformation1.Validating())
            {
                this.basisInformation1.Commit();
                this.CurrentBusiness.Current = this.Source;
                this.CurrentBusiness.EndCreate();
                this.DialogResult = DialogResult.OK;
            }
        }


        /// <summary>
        /// 家在窗体时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewEngineeringForm_Load(object sender, EventArgs e)
        {
            switch (this.CurrentBusiness.WorkFlowType)
            {
                case EWorkFlowType.PROJECT:
                    //this.basisInformation1.ParentObject = this.CurrentBusiness.Current;
                    //记录当前对象的创建序列
                    m_Source = this.CurrentBusiness.Current.Create();
                    //初始化项目的Basic数据
                    this.basisInformation1.DoLoadData(this.CurrentBusiness.Current);
                    this.basisInformation1.CurrentBusiness = this.CurrentBusiness;
                    break;
                case EWorkFlowType.Engineering:
                    this.basisInformation1.ParentObject = this.CurrentBusiness.Current;
                    m_Source = this.CurrentBusiness.Current;
                    break;
            }

            ///设置处理的数据源
            this.basisInformation1.DataSource = m_Source;

        }

    }
}