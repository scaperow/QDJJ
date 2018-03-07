using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CBaseUnitProInfo : ABaseForm
    {

        /// <summary>
        /// 单位工程对象
        /// </summary>
        private _UnitProject m_UnitProject = null;
        /// <summary>
        /// 获取或设置当前单位工程
        /// </summary>
        public _UnitProject UnitProject
        {
            get
            {
                return m_UnitProject;
            }
            set
            {
                this.m_UnitProject = value;
                this.publicInformation1.CurrentBusiness = this.CurrentBusiness;
                this.publicInformation1.UnitProject = m_UnitProject;
            }
        }

        
        public CBaseUnitProInfo()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.publicInformation1.Commit();
            //if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
            {
                //提交值
                this.CurrentBusiness.Current.StructSource.ModelProject.UpDate(this.UnitProject);
            }
        }


    }
}