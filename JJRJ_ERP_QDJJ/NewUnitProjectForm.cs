/*
    单位工程创建界面
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.CTRL;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class NewUnitProjectForm : CBaseForm
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
        /// 默认为容器业务
        /// </summary>
        public bool IsContainer = true;
        /// <summary>
        /// 业务引导对象非容器业务中可能使用到此对象
        /// </summary>
        public _Profession Profession = null;
        /// <summary>
        /// 指定单位工程将会添加到哪个单项工程下若为空则不添加到项目下
        /// </summary>
        private _Engineering m_CEngineering = null;

        /// <summary>
        /// 指定单位工程将会添加到哪个单项工程下若为空则不添加到项目下
        /// </summary>
        public _Engineering Engineering
        {
            get
            {
                return this.m_CEngineering;
            }
            set
            {
                this.m_CEngineering = value;
            }
        }



        /// <summary>
        /// 获取或设置当前正在处理的单位工程对象
        /// </summary>
        private _UnitProject m_UnitProject = null;

        /// <summary>
        /// 获取或设置当前正在处理的单位工程对象
        /// </summary>
        public _UnitProject UnitProject
        {
            get
            {
                if (this.m_UnitProject == null)
                {
                    this.m_UnitProject = new _UnitProject();

                }

                this.m_UnitProject.ProType = this.cmboxProType.Text;

                this.m_UnitProject.QDGZ = this.cbx_qdgz.Text.Trim();
                this.m_UnitProject.DEGZ = this.cbx_degz.Text.Trim();

                this.m_UnitProject.QDLibName = this.cmboxListGallery.Text.Trim();
                this.m_UnitProject.DELibName = this.cmboxFixedLibrary.Text.Trim();
                this.m_UnitProject.TJLibName = this.cmboxAtlasGallery.Text.Trim();
                this.m_UnitProject.PrfType = this.cmboxPrfType.Text.Trim();
                this.m_UnitProject.TemplateType = this.cbx_TemplateType.SelectedIndex.ToString();
                //this.m_UnitProject.BaseData.Remark = this.txt_Remark.Text;

                /*Basis信息*/
                this.m_UnitProject.PGCDD = this.cbx_gcdd.Text;
                this.m_UnitProject.PJFCX = this.rg_jfcx.SelectedIndex;
                this.m_UnitProject.PNSDD = this.cbx_nsdd.Text;
                //项目名称
                this.m_UnitProject.Name = this.txtPrjName.Text.Trim();
                //节点名称默认为项目名称
                this.m_UnitProject.NodeName = this.m_UnitProject.Name;
                //工程编号
                this.m_UnitProject.CODE = this.txtPrjNo.Text.Trim();

                return this.m_UnitProject;
            }
            set
            {
                this.m_UnitProject = value;

            }
        }

        /// <summary>
        /// 获取文件名称
        /// </summary>
        public string GetDisplayName
        {
            get
            {
                return txtPrjName.Text.Trim();
            }
        }

        public NewUnitProjectForm()
        {
            InitializeComponent();
        }

        private void NewUnitProjectForm_Load(object sender, EventArgs e)
        {
            doLoadData();
            initForm();
        }

        /// <summary>
        /// 加载本窗体需要的数据
        /// </summary>
        private void doLoadData()
        {
            //绑定基类的数据
            //当前单位
            if (this.m_CEngineering != null)
            {
                //根据当前单项工程初始化数据
                this.cbx_degz.Text = this.m_CEngineering.DEGZ;
                this.cbx_qdgz.Text = this.m_CEngineering.QDGZ;
                this.cbx_gcdd.Text = this.m_CEngineering.PGCDD;
                this.rg_jfcx.SelectedIndex = this.m_CEngineering.PJFCX;
                this.cbx_nsdd.Text = this.m_CEngineering.PNSDD;
                this.txtPrjNo.Text = this.m_UnitProject.CODE;


            }
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void initForm()
        {

            /*cmboxListGallery.doLoadData("清单库", "*.qdsx");//选择清单库方法
            cmboxAtlasGallery.doLoadData("图集库", "*.tjsx");//选择图集库方法
            cmboxFixedLibrary.doLoadData("定额库", "*.dcsx");//选择定额库方法*/
            cmboxListGallery.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Library"];
            cmboxListGallery.DoFilter("清单库");
            //cmboxListGallery.DataBind();

            cmboxFixedLibrary.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Library"];
            cmboxFixedLibrary.DoFilter("定额库");
            //cmboxFixedLibrary.DataBind();

            cmboxAtlasGallery.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Library"];
            cmboxAtlasGallery.DoFilter("图集库");


            cmboxPrfType.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Professional"];
            cmboxPrfType.DataBind();
        }

        #region 方法
        private bool validating()
        {
            if (this.txtPrjName.Text.Trim().Equals(string.Empty))
            {
                this.errorProvider1.SetError(this.txtPrjName, "工程名称不能为空！");
                return false;
            }

            if (this.txtPrjNo.Text.Trim().Equals(string.Empty))
            {
                this.errorProvider1.SetError(this.txtPrjNo, "工程编号不能为空！");
                return false;
            }

            char[] NoChar = new char[] { '\'', '[', ']', '\\', '/', ';', '*', '?', '%', '^' };
            foreach (char ch in NoChar)
            {
                if (this.txtPrjName.Text.IndexOf(ch) != -1)
                {
                    this.errorProvider1.SetError(this.txtPrjName, "名称不能存在非法字符! ");
                    return false;
                }
            }
            //名称不重复验证(仅限项目操作验证使用)
            if (this.CurrentBusiness != null)
            {
                if (this.CurrentBusiness.Current.Property.IsExist(this.txtPrjNo.Text.Trim(), EObjectType.UnitProject))
                {
                    this.errorProvider1.SetError(this.txtPrjName, "工程编号已经存在！");
                    return false;
                }
            }

            this.errorProvider1.Clear();
            return true;
        }




        #endregion

        /// <summary>
        /// 效验事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxListGallery_TextChanged(object sender, EventArgs e)
        {
            validating();
        }

        private void cmboxListGallery_Validating(object sender, CancelEventArgs e)
        {
            validating();
        }




        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //取消前还原序列

            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 确定（确认添加工程）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //提交钱的验证处理
            if (!this.validating())
            {
                return;
            }
            

            //if (this.MainForm.Text.ToUpper().EndsWith("JGCX") && File.Exists(this.MainForm.Text))
            if(File.Exists(System.Environment.CurrentDirectory + "\\工程文件\\" + this.GetDisplayName+".JGCX"))
            {
                MessageBox.Show("该工程文件名称已经存在,请重新命名!", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断是否存在业务对象是否存在
            if (this.CurrentBusiness == null)
            {
                //不存在则为单独创建模式
                this.doNotContainerClick();
            }
            else
            {
                //隶属模式创建
                this.doContainerClick();

            }

            this.DialogResult = DialogResult.OK;
        }



        /// <summary>
        /// 非容器类型提交
        /// </summary>
        private void doNotContainerClick()
        {
            //创建工作流了单个单位工程
            this.m_CurrentBusiness = APP.WorkFlows.Init(EWorkFlowType.UnitProject);
            _UnitProject info = this.UnitProject;
            (this.m_CurrentBusiness as _Un_Business).Create(info);
            this.m_CurrentBusiness.Current.Files = this.Profession.Files;
            this.m_CurrentBusiness.Current.Files.FileName = info.Name;
            (this.m_CurrentBusiness as _Un_Business).EndCreate();

            //info.Files = this.Profession.Files;
            //info.Files.FileName = info.Property.Basis.Name;
            //APP.WorkFlows.NotContainer.Create(this.UnitProject);


        }

        /// <summary>
        /// 容器业务提交
        /// </summary>
        private void doContainerClick()
        {
            _UnitProject info = null;
            switch (this.CurrentBusiness.WorkFlowType)
            {
                case EWorkFlowType.PROJECT://项目中添加单位工程
                    info = this.UnitProject;
                    (this.CurrentBusiness as _Pr_Business).AddChild(this.Engineering, info);
                    break;
                case EWorkFlowType.Engineering://添加单项工程
                    info = this.UnitProject;
                    info.Property.Basis = this.Engineering.Property.Basis;
                    //名称需要在Basis之后
                    info.Property.Basis.Name = this.txtPrjName.Text.Trim();
                    (this.CurrentBusiness as _En_Business).AddChild(this.Engineering, info);
                    break;
            }
        }


        /// <summary>
        /// 定额库发生选择变化根据内容筛选工程类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxFixedLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            LibCombox lib = sender as LibCombox;
            if (lib.SelectedItem != null)
            {
                this.cmboxProType.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Professional"];
                string str = _LibAction.GetValue(lib.SelectedItem.ToString(), "定额库");
                this.cmboxProType.DoFilter(str);
            }
        }

        //清单库 定额库根据清单的选择自动选择一项
        private void cmboxListGallery_SelectedIndexChanged(object sender, EventArgs e)
        {
            LibCombox lib = sender as LibCombox;
            if (lib.SelectedItem != null)
            {
                string r = ((lib.SelectedItem as CList).value as DataRowView)["Relation"].ToString();
                this.cmboxFixedLibrary.SelectedIndex = Convert.ToInt32(r);
                //不是建筑清单库 图集为空
                if (lib.SelectedIndex != 0)
                {
                    this.cmboxAtlasGallery.Text = string.Empty;
                }
                else
                {
                    this.cmboxAtlasGallery.SelectedIndex = 0;
                }
            }
        }

        private void cmboxProType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LibCombox lib = sender as LibCombox;
            if (lib.SelectedItem != null)
            {
                this.cmboxPrfType.Properties.Items.Clear();
                if (lib.SelectedItem.ToString() == "【安装专业】")
                {
                    this.cmboxPrfType.DataSource.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Professional"];
                    this.cmboxPrfType.DoFilter("安装专业");
                }
                else
                {
                    this.cmboxPrfType.Text = lib.SelectedItem.ToString();
                }
            }
        }

        private void txtPrjNo_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
