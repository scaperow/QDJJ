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
    public partial class TenderInformation : BaseControl
    {
        /// <summary>
        /// 当前控件的单位工程
        /// </summary>
        private _Projects m_CProjects = null;

        /// <summary>
        /// 获取或设置当前单位工程
        /// </summary>
        public _Projects Projects
        {
            get
            {
                return this.m_CProjects;
            }
            set
            {
                if (value != null)
                {
                    this.m_CProjects = value;
                    //this.tenderInformation = value.Property.BasicInformation.TenderInformation;
                    this.tenderInfoSourceBindingSource.DataSource = value.StructSource.TenderInfoSource;
                    
                }
            }
        }
        
        ///// <summary>
        ///// 当前控件的投标信息
        ///// </summary>
        //private _TenderInformation m_TenderInformation = null;

        ///// <summary>
        ///// 当前控件投标信息
        ///// </summary>
        //private _TenderInformation tenderInformation
        //{
        //    set
        //    {
        //        this.txt_BBZJ.Text  = value.BBZJ;
        //        this.txt_DBLX.Text  = value.DBLX;
        //        this.txt_DBR.Text   = value.TBDWDBR;
        //        this.txt_JZS.Text   = value.JZS;
        //        this.txt_JZSH.Text  = value.JZSH;
        //        this.txt_TBDW.Text  = value.TBDW;
        //        this.txt_TBGQ.Text  = value.TBGQ;
        //        this.txt_ZLCN.Text  = value.ZLCN;
        //        this.m_TenderInformation = value;
        //    }
        //    get
        //    {
        //        m_TenderInformation.BBZJ    = this.txt_BBZJ.Text;
        //        m_TenderInformation.DBLX    =this.txt_DBLX.Text;
        //        m_TenderInformation.TBDWDBR = this.txt_DBR.Text; 
        //        m_TenderInformation.JZS     = this.txt_JZS.Text;
        //        m_TenderInformation.JZSH    =this.txt_JZSH.Text;
        //        m_TenderInformation.TBDW    =this.txt_TBDW.Text;
        //        m_TenderInformation.TBGQ    =this.txt_TBGQ.Text;
        //        m_TenderInformation.ZLCN    =this.txt_ZLCN.Text;
        //        return m_TenderInformation;
        //    }
        //}

        ///// <summary>
        ///// 提交本次修改
        ///// </summary>
        //public void Commit()
        //{
        //    this.m_CProjects.Property.BasicInformation.TenderInformation = this.tenderInformation;
        //}

        public TenderInformation()
        {
            InitializeComponent();
        }
    }
}
