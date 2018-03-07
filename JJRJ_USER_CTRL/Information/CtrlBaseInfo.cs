/*
 * 仅用于投标信息
 */
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
    public partial class CtrlBaseInfo : BaseControl
    {
       

        ///// 当前控件的投标信息
        ///// </summary>
        //private _InformationData m_InformationData = null;

        ///// <summary>
        ///// 当前控件投标信息
        ///// </summary>
        //public _InformationData informationData
        //{
        //    set
        //    {
        //        if (value != null)
        //        {

        //            if (value.PlaitDate == new DateTime(1, 1, 1))
        //            {
        //                this.txt_PlaitDate.DateTime = DateTime.Now;
        //            }
        //            else
        //            {
        //                this.txt_PlaitDate.DateTime = value.PlaitDate;
        //            }
        //            if (value.ReviewDate == new DateTime(1, 1, 1))
        //            {
        //                this.txt_ReviewDate.DateTime = DateTime.Now;
        //            }
        //            else
        //            {
        //                this.txt_ReviewDate.DateTime = value.ReviewDate;
        //            }

        //            this.txt_PlaitName.Text = value.PlaitName;
        //            this.txt_PlaitNo.Text = value.PlaitNo;
        //            this.txt_ReviewName.Text = value.ReviewName;
        //            this.m_InformationData = value;
        //        }

        //    }
        //    get
        //    {
        //        if (this.m_InformationData != null)
        //        {
        //            m_InformationData.PlaitDate = this.txt_PlaitDate.DateTime;
        //            m_InformationData.PlaitName = this.txt_PlaitName.Text;
        //            m_InformationData.PlaitNo = this.txt_PlaitNo.Text;
        //            m_InformationData.ReviewDate = this.txt_ReviewDate.DateTime;
        //            m_InformationData.ReviewName = this.txt_ReviewName.Text;
        //        }
        //        return m_InformationData;
        //    }
        //}

        ///// <summary>
        ///// 提交本次修改
        ///// </summary>
        //public void Commit()
        //{
        //    if (m_InformationData != null)
        //    {
        //        m_InformationData.PlaitDate = this.txt_PlaitDate.DateTime;
        //        m_InformationData.PlaitName = this.txt_PlaitName.Text;
        //        m_InformationData.PlaitNo = this.txt_PlaitNo.Text;
        //        m_InformationData.ReviewDate = this.txt_ReviewDate.DateTime;
        //        m_InformationData.ReviewName = this.txt_ReviewName.Text;
        //    }
        //}


        public CtrlBaseInfo()
        {
            InitializeComponent();
        }

    }
}
