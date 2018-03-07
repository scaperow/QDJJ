/*公共信息控件*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class PublicInformation : BaseControl
    {

        /// <summary>
        /// 单位工程对象
        /// </summary>
        private _UnitProject m_UnitProject = null;

        /// <summary>
        /// 获取或设置当前空间的单位工程
        /// </summary>
        public _UnitProject UnitProject
        {
            get
            {
                if (this.m_UnitProject != null)
                {
                    this.m_UnitProject.Name = this.txtPrjName.Text.Trim();
                    this.m_UnitProject.PlaitNo = this.txtplaitNo.Text.Trim();
                    this.m_UnitProject.CODE = this.txtPrjNo.Text.Trim();
                    this.m_UnitProject.ReviewDate = this.ReviewDate.DateTime;
                    this.m_UnitProject.PlaitDate = this.plaitDate.DateTime;
                    this.m_UnitProject.PlaitName = this.plaitName.Text.Trim();
                    this.m_UnitProject.ReviewName = this.txtReviewName.Text.Trim();
                    this.m_UnitProject.QDGZ = this.cbx_listRule.Text.Trim();
                    this.m_UnitProject.DEGZ = this.cbx_fixRule.Text.Trim();
                    this.m_UnitProject.QDLibName = this.cmboxListGallery.Text.Trim();
                    this.m_UnitProject.DELibName = this.cmboxFixedLibrary.Text.Trim();
                    this.m_UnitProject.TJLibName = this.cmboxAtlasGallery.Text.Trim();
                    this.m_UnitProject.PrfType = this.cmboxPrfType.Text.Trim();
                    this.m_UnitProject.Remark = this.txt_Remark.Text;
                    
                }
                
                return this.m_UnitProject;
            }
            set
            {
                if (value != null)
                {
                    this.m_UnitProject = value;
                }
            }
        }

        /// <summary>
        /// 绑定数据到控件
        /// </summary>
        public void DataBind()
        {
            //如果当前也为为项目业务绑定之前用DataRow值替换
            if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
            {
                this.CurrentBusiness.Current.StructSource.ModelProject.Synchronous(this.m_UnitProject);
            }
            

            this.txtPrjName.Text        = this.m_UnitProject.Name;
            this.txtPrjNo.Text          = this.m_UnitProject.CODE;
            this.ReviewDate.DateTime    = this.m_UnitProject.ReviewDate;
            this.plaitDate.DateTime     = this.m_UnitProject.PlaitDate;
            this.plaitName.Text         = this.m_UnitProject.PlaitName;
            this.txtplaitNo.Text        = this.m_UnitProject.PlaitNo;
            this.txtReviewName.Text     = this.m_UnitProject.ReviewName;
            this.cbx_listRule.Text      = this.m_UnitProject.Property.Libraries.ListGallery.Rule;
            this.cbx_fixRule.Text       = this.m_UnitProject.Property.Libraries.FixedLibrary.Rule;

            this.cmboxListGallery.Text  = this.m_UnitProject.Property.Libraries.ListGallery.LibName;
            this.cmboxFixedLibrary.Text = this.m_UnitProject.Property.Libraries.FixedLibrary.LibName;

            this.cmboxAtlasGallery.Text = this.m_UnitProject.Property.Libraries.AtlasGallery.LibName;
            this.cmboxPrfType.Text      = this.m_UnitProject.PrfType;
            this.cmboxProType.Text      = this.m_UnitProject.ProType;
            this.txtPrjName.Text        = this.m_UnitProject.Name;

            this.cbx_nsdd.Text          = this.m_UnitProject.PNSDD;
            this.rg_jfcx.SelectedIndex  = this.m_UnitProject.PJFCX;
            this.cbx_gcdd.Text          = this.m_UnitProject.PGCDD;
            this.txt_Remark.Text        = this.m_UnitProject.Remark;

        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void initForm()
        {
            /*cmboxListGallery.doLoadData("清单库", "*.qdsx");//选择清单库方法
            cmboxAtlasGallery.doLoadData("图集库", "*.tjsx");//选择图集库方法
            cmboxFixedLibrary.doLoadData("定额库", "*.dcsx");//选择定额库方法*/
            if (APP.Application != null)
            {
                cmboxListGallery.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Library"];
                cmboxListGallery.DoFilter("清单库");
                cmboxListGallery.DataBind();

                cmboxFixedLibrary.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Library"];
                cmboxFixedLibrary.DoFilter("定额库");
                cmboxFixedLibrary.DataBind();

                cmboxPrfType.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Professional"];
                cmboxPrfType.DataBind();

                this.DataBind();

                //加事件
                if (this.CurrentBusiness.Current.IsDZBS)
                {
                    this.txtPrjName.Enabled = false;
                    this.txtPrjNo.Enabled = false;
                    this.txtplaitNo.Enabled = false;
                    this.txtReviewName.Enabled = false;
                    this.plaitDate.Enabled = false;
                    this.txt_Remark.Enabled = false;
                    this.ReviewDate.Enabled = false;
                    this.plaitName.Enabled = false;
                }
                else
                {
                    this.txtPrjName.Enabled = true;
                    this.txtPrjNo.Enabled = true;
                    this.txtplaitNo.Enabled = true;
                    this.txtReviewName.Enabled = true;
                    this.plaitDate.Enabled = true;
                    this.txt_Remark.Enabled = true;
                    this.ReviewDate.Enabled = true;
                    this.plaitName.Enabled = true;
                }


                this.txtPrjName.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.txtPrjNo.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.txtplaitNo.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.txtReviewName.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.plaitDate.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.txt_Remark.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.ReviewDate.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
                this.plaitName.EditValueChanged += new System.EventHandler(this.txt_Remark_EditValueChanged);
            }
        }

        /// <summary>
        /// 提交本次修改
        /// </summary>
        public void Commit()
        {
            this.m_UnitProject = this.UnitProject;
        }

        public PublicInformation()
        {
            InitializeComponent();
        }

        private void PublicInformation_Load(object sender, EventArgs e)
        {
            this.initForm();
        }

        private void txt_Remark_EditValueChanged(object sender, EventArgs e)
        {
            this.Commit();
            //if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
            {
                //提交值
                this.CurrentBusiness.Current.StructSource.ModelProject.UpDate(this.UnitProject);
            }
        }
    }
}
