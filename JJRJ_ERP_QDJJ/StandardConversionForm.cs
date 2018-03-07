using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 分部分项 标准换算
    /// </summary>
    public partial class StandardConversionForm : BaseForm
    {
        /// <summary>
        /// 当前正在操作的子目
        /// </summary>
        private _Methods_Subheadings m_Methods_Subheadings = null;
        private _Methods_StandardConversion m_Methods_StandardConversion = null;
        
        /// <summary>
        /// 修改过的基础计算对象
        /// </summary>
        private _List m_GetList = new _List();
        private bool m_IFHS = false;
        public StandardConversionForm()
        {
            InitializeComponent();

            this.textEdit1.TextChanged += textEdit1_TextChanged;
            this.textEdit2.TextChanged += textEdit1_TextChanged;
            this.textEdit3.TextChanged += textEdit1_TextChanged;
            this.textEdit4.TextChanged += textEdit1_TextChanged;
        }

        void textEdit1_TextChanged(object sender, EventArgs e)
        {
            var edit = sender as TextEdit;
            if (edit == null)
            {
                return;
            }

            if (edit.Text.Trim() == "0")
            {
                edit.Text = "1";
                edit.SelectionStart = 1;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="p_Business">当前业务</param>
        /// <param name="p_Activitie">当前单位工程</param>
        /// <param name="p_AParentForm">父级窗体</param>
        public StandardConversionForm(_Business p_Business, _UnitProject p_Activitie, ABaseForm p_AParentForm)
        {
            this.CurrentBusiness = p_Business;
            this.Activitie = p_Activitie;
            this.AParentForm = p_AParentForm;
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            m_Methods_StandardConversion = new _Methods_StandardConversion(this.Activitie);
            InitializeComponent();
        }

        /// <summary>
        /// 根据清单子目选择
        /// </summary>
        /// <param name="q_id">子目编号</param>
        public void DoFilter(_Entity_SubInfo p_info)
        {
            this.m_IFHS = false;
            this.m_Methods_Subheadings.Current = p_info;
            this.gridControl1.DataSource = null;
            DataRow[] drs = this.Activitie.StructSource.ModelStandardConversion.Select(string.Format("HSLB='1' AND ZMID={0} AND SSLB={1}", this.m_Methods_Subheadings.Current.ID, this.m_Methods_Subheadings.Current.SSLB));
            if (drs.Length > 0)
            {
                this.gridControl1.DataSource = drs.CopyToDataTable();
            }
            this.StandardConversionInfo();
            this.radioButton1.Checked = true;
        }

        /// <summary>
        /// 加载特殊换算
        /// </summary>
        public void StandardConversionInfo()
        {
            DataRow dr = this.Activitie.StructSource.ModelStandardConversion.Select(string.Format("HSLB='0' AND ZMID={0} AND SSLB={1}", this.m_Methods_Subheadings.Current.ID, this.m_Methods_Subheadings.Current.SSLB)).FirstOrDefault();
            if (dr == null)
            {
                this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            }
            else
            {
                this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                this.txtSJZ.Text = dr["JBL_RGXS"].ToString();
                this.lblHSXX.Text = dr["HSXX"].ToString();
                this.lblJBL.Text = dr["JBL_RGXS"].ToString();
                this.lblDEH.Text = dr["DEH_CLXS"].ToString();
                this.lblTZL.Text = dr["TZL_JXXS"].ToString();
                this.lblDW1.Text = "(" + dr["DJ_DW"].ToString() + ")";
                this.lblDW2.Text = "(" + dr["DJ_DW"].ToString() + ")";
            }
        }

        public override void Init()
        {
            //RevocationRefresh();
        }

        public override void RefreshDataSource()
        {
            //if (m_info != null)
            //{
            //    this.m_info.OnQuantityUnitChange(this, null);
            //    RevocationRefresh();
            //}
        }

        public override void RevocationRefresh()
        {
            //if (m_info != null)
            //{
            //    this.m_info.StandardConversionList_BindingSource.ResetBindings(false);
            //    this.m_info.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
            //    this.m_info.SubheadingsFeeList_BindingSource.ResetBindings(false);
            //    SubForm.RefreshDataSource(); 
            //}
        }

        /// <summary>
        /// 取消计算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.CCReset();
            }
            else
            {
                this.JJReset();
            }
            this.DoFilter(this.m_Methods_Subheadings.Current);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 确定计算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.BasisCalculate();
            this.ManualCalculate();
            this.SpecialCalculate();
            if (this.m_IFHS)
            {
                this.m_IFHS = false;
                this.m_Methods_Subheadings.BeginCurrent();
                Calculator.Calculate(CurrentBusiness, Activitie, m_Methods_Subheadings.Current);
                Activitie.NeedCalculate = true;
            }
            this.DialogResult = DialogResult.OK;
        }
         
        /// <summary>
        /// 切换到算法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                //切换到乘除
                this.CCReset();
            }
            else
            {
                //切换到加减
                this.JJReset();
            }
        }

        void NumberText_LostFocus(object sender, System.EventArgs e)
        {
            var editor = sender as TextEdit;
            if (editor == null)
            {
                return;
            }

            var text = editor.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            double number = 0;
            if (double.TryParse(text, out number))
            {
                if (number == 0)
                {
                    editor.Text = "1";
                }
            }
        }

        /// <summary>
        /// 手动计算
        /// </summary>
        private void ManualCalculate()
        {
            //乘除计算
            if (this.radioButton1.Checked)
            {
                if (Convert.ToDecimal(this.textEdit1.Text.Trim()) != 1)
                {
                    this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit1.Text), true);
                    this.m_Methods_Subheadings.Current.XMMC +="//改：单价*" + this.textEdit1.Text.Trim();
                    this.m_IFHS = true;
                }
                else
                {
                    if (Convert.ToDecimal(this.textEdit2.Text.Trim()) != 1)
                    {
                        this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit2.Text.Trim()), _Constant.rg, true);
                        this.m_Methods_Subheadings.Current.XMMC +="//改：人工*" + this.textEdit2.Text.Trim();
                        this.m_IFHS = true;
                    }
                    if (Convert.ToDecimal(this.textEdit3.Text.Trim()) != 1)
                    {
                        this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit3.Text.Trim()), _Constant.cl, true);
                        this.m_Methods_Subheadings.Current.XMMC +="//改：材料*" + this.textEdit3.Text.Trim();
                        this.m_IFHS = true;
                    }
                    if (Convert.ToDecimal(this.textEdit4.Text.Trim()) != 1)
                    {
                        this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit4.Text.Trim()), _Constant.jx, true);
                        this.m_Methods_Subheadings.Current.XMMC +="//改：机械*" + this.textEdit4.Text.Trim();
                        this.m_IFHS = true;
                    }
                }
                this.CCReset();
            }
            //加减计算
            else
            {
                if (Convert.ToDecimal(this.textEdit1.Text.Trim()) != 0)
                {
                    this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(),Convert.ToDecimal(this.textEdit1.Text.Trim()), false);
                    this.m_Methods_Subheadings.Current.XMMC +="//改：单价+" + this.textEdit1.Text.Trim();
                    this.m_IFHS = true;
                }
                else
                {
                    if (Convert.ToDecimal(this.textEdit2.Text.Trim()) != 0)
                    {
                        this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit2.Text.Trim()), _Constant.rg, false);
                        this.m_Methods_Subheadings.Current.XMMC += "//改：人工+" + this.textEdit2.Text.Trim();
                        this.m_IFHS = true;
                    }
                    if (Convert.ToDecimal(this.textEdit3.Text.Trim()) != 0)
                    {
                        this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit3.Text.Trim()), _Constant.cl, false);
                        this.m_Methods_Subheadings.Current.XMMC +="//改：材料+" + this.textEdit3.Text.Trim();
                        this.m_IFHS = true;
                    }
                    if (Convert.ToDecimal(this.textEdit4.Text.Trim()) != 0)
                    {
                        this.m_Methods_StandardConversion.UpdateXHL(this.m_Methods_Subheadings.Current.ID.ToString(), this.m_Methods_Subheadings.Current.SSLB.ToString(), Convert.ToDecimal(this.textEdit4.Text.Trim()), _Constant.jx, false);
                        this.m_Methods_Subheadings.Current.XMMC +="//改：机械+" + this.textEdit4.Text.Trim();
                        this.m_IFHS = true;
                    }
                }
                this.JJReset();
            }
        }

        /// <summary>
        /// 基础计算
        /// </summary>
        private void BasisCalculate()
        {
            DataTable dt = this.gridControl1.DataSource as DataTable;
            if (dt == null) return;
            DataTable dts = dt.GetChanges();
            if (dts == null) return;
            foreach (DataRow item in dts.Rows)
            {
                DataRow dr = this.Activitie.StructSource.ModelStandardConversion.Select(string.Format("HSLB='1' AND ZMID={0} AND SSLB={1} AND ID={2}", this.m_Methods_Subheadings.Current.ID, this.m_Methods_Subheadings.Current.SSLB, item["ID"])).FirstOrDefault();
                if (dr != null)
                {
                    dr["IFXZ"] = item["IFXZ"];
                    m_Methods_StandardConversion.Current = item;
                    m_Methods_StandardConversion.CalculateXHL();
                    if (item["IFXZ"].Equals(true))
                    {
                        this.m_Methods_Subheadings.Current.XMMC += "//改：" + item["THWZFC"].ToString();
                    }
                    else
                    {
                        this.m_Methods_Subheadings.Current.XMMC = this.m_Methods_Subheadings.Current.XMMC.Replace("//改：" + item["THWZFC"].ToString(), string.Empty);
                    }
                    this.m_IFHS = true;
                }
            }
            dt.AcceptChanges();
        }


        /// <summary>
        /// 特殊计算
        /// </summary>
        private void SpecialCalculate()
        {
            if (this.splitContainerControl1.PanelVisibility == SplitPanelVisibility.Both)
            {
                string m_deh = this.lblDEH.Text;//定额号
                decimal m_tzl = Convert.ToDecimal(this.lblTZL.Text);//调整量
                decimal m_jbl = Convert.ToDecimal(this.lblJBL.Text);//基本量
                decimal m_sjz = Convert.ToDecimal(this.txtSJZ.Text);//实际值
                if (m_sjz != m_jbl)
                {
                    int xs = Math.Abs((int)((m_sjz - m_jbl) / m_tzl));//（实际值-基本量） = 正整数倍数
                    decimal b = Math.Abs((m_sjz - m_jbl));//（实际值-基本量）= 差数
                    decimal c = (xs * m_tzl);//（基本量*调整量） = 实际差数
                    decimal d = b - c;//（实际差数-差数）= 余数
                    if (d > 0 && d < m_jbl)//余数在调整量之间时进位 
                    {
                        xs = xs + 1;
                    }
                    _SubSegmentsSource m_SubSegmentsSource = null;
                    if (this.m_Methods_Subheadings.Current.SSLB == 0)
                    {
                        m_SubSegmentsSource = this.Activitie.StructSource.ModelSubSegments;
                    }
                    else
                    {
                        m_SubSegmentsSource = this.Activitie.StructSource.ModelMeasures;
                    }
                    DataRow dr = m_SubSegmentsSource.GetRowByOther(this.m_Methods_Subheadings.Current.PID.ToString());
                    if (dr != null)
                    {
                        _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                        _ObjectSource.GetObject(m_Entity_SubInfo,dr);
                        _Methods_Fixed m_Methods_Fixed = null;
                        if (m_Entity_SubInfo.SSLB.Equals(0))
                        {
                            m_Methods_Fixed = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);
                        }
                        else
                        {
                            m_Methods_Fixed = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);
                        }
                        DataRow de_dr = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Select(string.Format("DINGEH='{0}'", m_deh)).FirstOrDefault();
                        if (de_dr != null)
                        {
                            _Entity_SubInfo m_ZM_Entity_SubInfo = new _Entity_SubInfo();
                            GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(m_ZM_Entity_SubInfo, de_dr, this.Activitie.Property.Libraries.FixedLibrary.FullName);
                            m_ZM_Entity_SubInfo.XMBM += " *" + xs + "";

                            m_Methods_Fixed.Create(this.m_Methods_Subheadings.Current.Sort, m_ZM_Entity_SubInfo);
                            this.m_IFHS = true;
                        }
                    }

                    //SubSegmentForm m_ParentForm =  this.AParentForm  as SubSegmentForm;
                    //if (m_ParentForm != null)
                    //{
                    //    m_ParentForm.BindSubSegmentList();
                    //}
                    this.m_IFHS = true;
                }
            }
        }

        /// <summary>
        /// 乘除重置
        /// </summary>
        private void CCReset()
        {
            this.textEdit1.Text = "1";
            this.textEdit2.Text = "1";
            this.textEdit3.Text = "1";
            this.textEdit4.Text = "1";
        }

        /// <summary>
        /// 加减重置
        /// </summary>
        private void JJReset()
        {
            this.textEdit1.Text = "1";
            this.textEdit2.Text = "1";
            this.textEdit3.Text = "1";
            this.textEdit4.Text = "1";
        }

        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.gridView1.OptionsBehavior.Editable = false;
                this.simpleButton1.Enabled = false;
            }
            else
            {
                this.gridView1.OptionsBehavior.Editable = true;
                this.simpleButton1.Enabled = true;
            }
        }

        public override void GlobalStyleChange()
        {
            //base.GlobalStyleChange();
            //this.automaticConversionControl1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }
    }
}