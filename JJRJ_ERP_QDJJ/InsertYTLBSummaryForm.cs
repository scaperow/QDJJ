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
    public partial class InsertYTLBSummaryForm : CBaseForm
    {
        private _Methods_YTLBSummary m_Methods_YTLBSummary = null;

        private UseType ytlb = UseType.甲供材料;

        public UseType YTLB
        {
            get { return ytlb; }
            set { ytlb = value; }
        }
        private DataRow m_info = null;

        public DataRow GetInfo
        {
            get { return m_info; }
        }


        public InsertYTLBSummaryForm(_Business p_Business, _UnitProject p_Activitie)
        {
            this.CurrentBusiness = p_Business;
            this.Activitie = p_Activitie;
            m_Methods_YTLBSummary = new _Methods_YTLBSummary(p_Activitie);
            InitializeComponent();
        }

        public InsertYTLBSummaryForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            m_info = this.Activitie.StructSource.ModelQuantity.NewRow();
            m_info["BH"] = this.textEditBH.Text.Trim();
            m_info["MC"] = this.textEditMC.Text.Trim();
            m_info["DW"] = this.textEditDW.Text.Trim();
            m_info["SCDJ"] = this.calcEditSCDJ.Value;
            m_info["YTLB"] = ytlb.ToString();
            if (m_info["BH"].Equals(string.Empty))
            {
                MsgBox.Alert("请输入编号");
            }
            else
            {
                if (m_Methods_YTLBSummary.GetBindingInfo(m_info["BH"].ToString()) == null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MsgBox.Alert("【" + m_info["BH"].ToString() + "已存在】");
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}