using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.CTRL.Information
{
    public partial class BasisInformation : BaseControl
    {
        /// <summary>
        /// 当前控件使用者的父数据源
        /// </summary>
        private _COBJECTS m_Parent = null;

        /// <summary>
        /// 当前控件使用者的父数据源
        /// </summary>
        public _COBJECTS ParentObject
        {
            get
            {

                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        /// <summary>
        /// 获取或设置当前数据源
        /// </summary>
        private _COBJECTS m_DataSource = null;

        /// <summary>
        /// 获取或设置当前数据源
        /// </summary>
        public _COBJECTS DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
                if (value != null)
                {
                    //默认项目编号
                    this.txt_xmbh.Text = value.CODE;
                }
            }
        }

        /// <summary>
        /// 初始化数据到数据源
        /// </summary>
        public void DoLoadData(_COBJECTS value)
        {
            if (value == null) return;
            //名称默认为空此处重新输入名称
            //this.txt_xmmc.Text = value.Name;
            this.cbx_degz.Text = value.DEGZ;
            this.cbx_qdgz.Text = value.QDGZ;
            this.cbx_gcdd.Text = value.PGCDD;
            this.rg_jfcx.SelectedIndex = value.PJFCX;
            this.cbx_nsdd.Text = value.PNSDD;
        }

        /// <summary>
        /// 为当前控件效验输入规则
        /// </summary>
        /// <returns></returns>
        public bool Validating()
        {
            if (txt_xmmc.Text.Trim().Equals(string.Empty))
            {
                this.errorProvider1.SetError(txt_xmmc, "请输入项目名称!");
                return false;
            }

            if (txt_xmbh.Text.Trim().Equals(string.Empty))
            {
                this.errorProvider1.SetError(txt_xmbh, "请输入项目编号!");
                return false;
            }

            char[] NoChar = new char[] { '\'', '[', ']', '\\', '/', ';' ,'*','?','%','^'};
            foreach (char ch in NoChar)
            {
                if (txt_xmmc.Text.IndexOf(ch) != -1)
                {
                    this.errorProvider1.SetError(txt_xmmc, "名称不能存在非法字符! ");
                    return false;
                }
            }

            //如果为项目添加 单项工程名不能重复
            if (this.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
            {
                if (this.CurrentBusiness.Current.Property.IsExist(this.txt_xmmc.Text.Trim(), EObjectType.Engineering))
                {
                    this.errorProvider1.SetError(this.txt_xmmc, "单项工程名称已经存在！");
                    return false;
                }
            }

            //根绝当前ParentObject对象判断是否存在子项目
            /*if (this.m_Parent != null)
            {
                CProjects pro = (this.m_Parent as CProjects);
                if (pro != null)
                {
                    if (!pro.Validating(txt_xmbh.Text.Trim()))
                    {
                        this.errorProvider1.SetError(txt_xmbh, "当前工程编号已经在项目中存在，请重新输入编号！");
                        return false;
                    }
                }
                
            }*/


            return true;
        }

        /// <summary>
        /// 提交控件数据到数据源
        /// </summary>
        public void Commit()
        {
            this.m_DataSource.CODE = this.txt_xmbh.Text;
            this.m_DataSource.Name = this.txt_xmmc.Text;
            this.m_DataSource.DEGZ = this.cbx_degz.Text;
            this.m_DataSource.QDGZ = this.cbx_qdgz.Text;
            this.m_DataSource.PGCDD = this.cbx_gcdd.Text;
            this.m_DataSource.PJFCX = this.rg_jfcx.SelectedIndex;
            this.m_DataSource.PNSDD = this.cbx_nsdd.Text;
            this.m_DataSource.NodeName = this.txt_xmmc.Text;

            /*this.m_DataSource.Property.Basis.CODE = this.txt_xmbh.Text;
            this.m_DataSource.Property.Basis.Name = this.txt_xmmc.Text;
            this.m_DataSource.Property.Basis.DEGZ = this.cbx_degz.Text;
            this.m_DataSource.Property.Basis.QDGZ = this.cbx_qdgz.Text;
            this.m_DataSource.Property.Basis.PGCDD = this.cbx_gcdd.Text;
            this.m_DataSource.Property.Basis.PJFCX = this.rg_jfcx.SelectedIndex;
            this.m_DataSource.Property.Basis.PNSDD = this.cbx_nsdd.Text;
            this.m_DataSource.Directory.NodeName = this.txt_xmmc.Text;*/
        }

        public BasisInformation()
        {
            InitializeComponent();
        }
    }
}
