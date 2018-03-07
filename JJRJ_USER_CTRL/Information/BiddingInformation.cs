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
    public partial class BiddingInformation : BaseControl
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
                    //this.biddingInformation = value.Property.BasicInformation.BiddingInformation;
                    this.biddingInfoSourceBindingSource.DataSource = value.StructSource.BiddingInfoSource;
                }
            }
        }

        /// <summary>
        /// 当前控件的投标信息
        /// </summary>
        //private _BiddingInformation m_BiddingInformation = null;

        /// <summary>
        /// 当前控件投标信息
        /// </summary>
        //private _BiddingInformation biddingInformation
        //{
        //    set
        //    {
        //        this.txt_DBR.Text = value.DBR;
        //        this.txt_JSDW.Text = value.JSDW;
        //        this.txt_JSDWDBR.Text = value.JSDWDBR;
        //        this.txt_ZBDLR.Text = value.ZBDLR;

        //        this.txt_GCLX.Text = value.GCLX;
        //        this.txt_ZBFW.Text = value.ZBFW;
        //        this.txt_ZBMJ.Text = value.ZBMJ;
        //        this.txt_ZBGQ.Text = value.ZBGQ;
        //        this.txt_BZDW.Text = value.BZDW;
        //        this.txt_SJDW.Text = value.SJDW;
        //        this.txt_DBLX.Text = value.DBLX;
        //        this.ctrlBaseInfo1.informationData = value;
        //        this.m_BiddingInformation = value;
        //    }
        //    get
        //    {
        //        m_BiddingInformation.DBR = this.txt_DBR.Text;
        //        m_BiddingInformation.JSDW = this.txt_JSDW.Text;
        //        m_BiddingInformation.JSDWDBR = this.txt_JSDWDBR.Text;
        //        m_BiddingInformation.ZBDLR = this.txt_ZBDLR.Text;

        //        m_BiddingInformation.GCLX = this.txt_GCLX.Text;
        //        m_BiddingInformation.ZBFW = this.txt_ZBFW.Text;
        //        m_BiddingInformation.ZBMJ = this.txt_ZBMJ.Text;
        //        m_BiddingInformation.ZBGQ = this.txt_ZBGQ.Text;
        //        m_BiddingInformation.BZDW = this.txt_BZDW.Text;
        //        m_BiddingInformation.SJDW = this.txt_SJDW.Text;
        //        m_BiddingInformation.DBLX = this.txt_DBLX.Text;
        //        return m_BiddingInformation;
        //    }
        //}

        /// <summary>
        /// 提交本次修改
        /// </summary>
        public void Commit()
        {
            //this.ctrlBaseInfo1.Commit();
            //this.m_CProjects.Property.BasicInformation.BiddingInformation = this.biddingInformation;
        }


        public BiddingInformation()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //this.Projects.StructSource.BiddingInfoSource.UpDate(biddingInfoSourceBindingSource.Current);
            //this.biddingInfoSourceBindingSource.EndEdit();
            //this.m_CProjects.Property.BasicInformation.BiddingInformation. = this.Projects.StructSource.BiddingInfoSource;
            //this.biddingInfoSourceBindingSource.ResetBindings(false);
        }
    }
}
