/*
    新创建项目工程操作
 */
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
    public partial class NewProjectsInfo : CBaseForm
    {

        /// <summary>
        /// 要创建的功能对象
        /// </summary>
        private _Profession m_Profession = null;

        /// <summary>
        /// 要创建的功能对象
        /// </summary>
        public _Profession Profession
        {
            get
            {
                return this.m_Profession;
            }
            set
            {
                this.m_Profession = value;
            }
        }
        /// <summary>
        /// 提交当前填写的信息
        /// </summary>
        public bool Commit()
        {
            //提交前验证 
            if (this.basisInformation1.Validating())
            {
                //文件对象验证（默认项目名称就是文件名称）
                this.basisInformation1.Commit();
                this.CurrentBusiness.Current.Files.FileName = this.CurrentBusiness.Current.Name;
                if (this.CurrentBusiness.Current.Files.Verification())
                {
                    MessageBox.Show(this, _Prompt.文件已经存在, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }

        public NewProjectsInfo()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //确认创建项目
            if (this.Commit())
            {
                APP.FileType = "项目工程";
                //APP.WorkFlows.Container.EndCreate();
                this.CurrentBusiness.FristEndCreate();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void NewProjectsInfo_Load(object sender, EventArgs e)
        {

            //创建新建项目操作流
            this.CurrentBusiness = APP.WorkFlows.Init(EWorkFlowType.PROJECT);
            //创建项目对象
            CurrentBusiness.Create();
            //设置项目路径
            this.CurrentBusiness.Current.Files = this.m_Profession.Files;
            //初始化默认数据
            this.basisInformation1.DataSource = CurrentBusiness.Current;
            this.basisInformation1.CurrentBusiness = CurrentBusiness;
        }
    }
}