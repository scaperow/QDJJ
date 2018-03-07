using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BatchSetForm : CBaseForm
    {

        private _Methods_Subheadings m_Methods_Subheadings = null;

        private _Methods_YTLBSummary m_Methods_YTLBSummary = null;

        /// <summary>
        /// 批量设置的数据源
        /// </summary>
        private DataTable m_DataSource = null;

        /// <summary>
        /// 材料市场合价总值
        /// </summary>
        private decimal sumSCHJ = 0;

        /// <summary>
        /// 筛选结果集合
        /// </summary>
        private IEnumerable<DataRow> list = null;

        /// <summary>
        /// 可设置集合
        /// </summary>
        private IEnumerable<DataRow> m_SetList = null;

        /// <summary>
        /// 获取或设置：批量设置的数据源
        /// </summary>
        public DataTable DataSource
        {
            get { return m_DataSource; }
            set
            {
                m_DataSource = value;
                this.lblCount.Text = string.Format("人材机总数：{0}条", m_DataSource.Rows.Count.ToString());
            }
        }

        public BatchSetForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchSetForm_Load(object sender, EventArgs e)
        {
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            m_Methods_YTLBSummary = new _Methods_YTLBSummary(this.Activitie);
            //this.radioGroupSZYTLB.SelectedIndex = -1;
        }

        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            switch (this.xtraTabControlSZ.SelectedTabPage.Name)
            {
                case "xtraTabPageDJBL":
                    UpdateDJBL();
                    break;
                case "xtraTabPageSZXX":
                    UpdateSZXX();
                    break;
                case "xtraTabPageQXXX":
                    UpdateQXXX();
                    break;
                default:
                    break;
            }
            this.m_Methods_Subheadings.BatchCalculate();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonNO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 筛选方式切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControlSX_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Filter();
            if (this.xtraTabControlSX.SelectedTabPage.Name == "xtraTabPageZD")
            {
                this.calcEditTJQB.Enabled = true;
                this.calcEditTJCL.Enabled = true;
                this.calcEditTJJX.Enabled = true;
                this.calcEditTJZC.Enabled = true;
                this.calcEditTJSB.Enabled = true;
                this.calcEditTJRG.Enabled = true;
            }
            else
            {
                GZ();
            }
        }

        /// <summary>
        /// 手动筛选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkEditSD_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;
            if (checkEdit.Name == "checkEditQX")
            {
                this.checkEditQX.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditRG.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditCL.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditZC.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditJX.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditSB.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);

                this.checkEditRG.Checked = checkEdit.Checked;
                this.checkEditCL.Checked = checkEdit.Checked;
                this.checkEditZC.Checked = checkEdit.Checked;
                this.checkEditJX.Checked = checkEdit.Checked;
                this.checkEditSB.Checked = checkEdit.Checked;

                this.checkEditQX.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditRG.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditCL.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditZC.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditJX.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
                this.checkEditSB.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
            }
            else
            {
                bool qx = true;
                qx = qx && this.checkEditRG.Checked;
                qx = qx && this.checkEditCL.Checked;
                qx = qx && this.checkEditZC.Checked;
                qx = qx && this.checkEditJX.Checked;
                qx = qx && this.checkEditSB.Checked;
                if (this.checkEditQX.Checked != qx)
                {
                    this.checkEditQX.CheckedChanged -= new EventHandler(checkEditSD_CheckedChanged);
                    this.checkEditQX.Checked = qx;
                    this.checkEditQX.CheckedChanged += new EventHandler(checkEditSD_CheckedChanged);
                }
            }
            Filter();
            GZ();
        }

        private void GZ()
        {
            if (this.checkEditJGCL.Checked || this.checkEditZDJCL.Checked || this.checkEditSDSCJRCJ.Checked)
            {
                this.calcEditTJQB.Enabled = false;
                this.calcEditTJCL.Enabled = false;
                this.calcEditTJJX.Enabled = false;
                this.calcEditTJZC.Enabled = false;
                this.calcEditTJSB.Enabled = false;
                this.calcEditTJRG.Enabled = false;
                this.btnReset.Enabled = false;
            }
            else
            {
                this.calcEditTJQB.Enabled = true;
                this.calcEditTJCL.Enabled = true;
                this.calcEditTJJX.Enabled = true;
                this.calcEditTJZC.Enabled = true;
                this.calcEditTJSB.Enabled = true;
                this.calcEditTJRG.Enabled = true;
                this.btnReset.Enabled = true;
            }
        }

        private void GZ(bool ifsdscdj)
        {
            if (ifsdscdj)
            {
                this.calcEditTJQB.Enabled = false;
                this.calcEditTJCL.Enabled = false;
                this.calcEditTJJX.Enabled = false;
                this.calcEditTJZC.Enabled = false;
                this.calcEditTJSB.Enabled = false;
                this.calcEditTJRG.Enabled = false;
                this.btnReset.Enabled = false;
            }
            else
            {
                this.calcEditTJQB.Enabled = true;
                this.calcEditTJCL.Enabled = true;
                this.calcEditTJJX.Enabled = true;
                this.calcEditTJZC.Enabled = true;
                this.calcEditTJSB.Enabled = true;
                this.calcEditTJRG.Enabled = true;
                this.btnReset.Enabled = true;
            }
        }

        /// <summary>
        /// 自动筛选选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroupZD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblScreening.Text = "符合条件数：0条";
            this.list = null;
            switch (this.radioGroupZD.SelectedIndex)
            {
                case 0:
                    this.textEditWZ.Enabled = true;
                    this.calcEditZJ.Enabled = false;
                    break;
                case 1:
                    this.textEditWZ.Enabled = false;
                    this.calcEditZJ.Enabled = true;
                    break;
                default:
                    break;
            }
            Filter();
        }

        /// <summary>
        /// 自动筛选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calcEditZD_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// 筛选
        /// </summary>
        private void Filter()
        {
            switch (xtraTabControlSX.SelectedTabPage.Name)
            {
                case "xtraTabPageSD":
                    this.list = this.m_DataSource.AsEnumerable().Where(p => this.ManualFilter(p));
                    break;
                case "xtraTabPageZD":
                    if (this.textEditWZ.Enabled && this.textEditWZ.Text != "0" && this.textEditWZ.Text != string.Empty)
                    {
                        this.list = this.m_DataSource.Select("LB='材料'", "SCHJ").Take(int.Parse(this.textEditWZ.Text));
                    }
                    if (this.calcEditZJ.Enabled && this.calcEditZJ.Value > 0)
                    {
                        this.sumSCHJ = ToolKit.ParseDecimal(this.m_DataSource.Compute("Sum(SCHJ)", string.Format("LB in({0})", _Constant.cl)));
                        this.list = this.m_DataSource.AsEnumerable().Where(p => this.AutoFilter(p));
                    }
                    break;
                default:
                    break;
            }
            if (this.list != null)
            {
                this.lblScreening.Text = string.Format("符合条件数：{0}条", this.list.Count().ToString());
                this.xtraTabControlSZ_SelectedPageChanged(null, null);
            }
        }

        private void xtraTabControlSZ_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            int count = 0;
            if (this.list != null)
            {
                switch (this.xtraTabControlSZ.SelectedTabPage.Name)
                {
                    case "xtraTabPageDJBL":
                        this.m_SetList = this.list.Where(p => p["YTLB"].Equals(string.Empty) && p["IFSDSCDJ"].Equals(false));
                        break;
                    case "xtraTabPageSZXX":
                        this.m_SetList = this.list;
                        break;
                    case "xtraTabPageQXXX":
                        this.m_SetList = this.list;
                        break;
                    default:
                        break;
                }
                count = this.m_SetList.Count();
            }
            this.lblCanSet.Text = string.Format("可设置条数：{0}条", count.ToString());
        }

        /// <summary>
        /// 自动筛选
        /// </summary>
        /// <param name="p_info">工料机对象</param>
        /// <returns>是否配对</returns>
        private bool AutoFilter(DataRow p_info)
        {
            bool flag = false;
            flag = _Constant.cl.Contains("'" + p_info["LB"].ToString() + "'") && (ToolKit.ParseDecimal(p_info["SCHJ"]) / sumSCHJ * 100) >= this.calcEditZJ.Value;
            return flag;
        }

        /// <summary>
        /// 手动筛选
        /// </summary>
        /// <param name="p_info">工料机对象</param>
        /// <returns>是否配对</returns>
        private bool ManualFilter(DataRow p_info)
        {
            bool flag = false;
            if (this.checkEditQX.Checked)
            {
                flag = true;
            }
            else
            {
                if (this.checkEditRG.Checked)
                {
                    flag = flag || p_info["LB"].Equals("人工");
                }
                if (this.checkEditZC.Checked)
                {
                    flag = flag || p_info["LB"].Equals("主材");
                }
                if (this.checkEditJX.Checked)
                {
                    flag = flag || p_info["LB"].Equals("机械");
                }
                if (this.checkEditCL.Checked)
                {
                    flag = flag || p_info["LB"].Equals("材料");
                }
                if (this.checkEditSB.Checked)
                {
                    flag = flag || p_info["LB"].Equals("设备");
                }
                if (this.checkEditZWYT.Checked)
                {
                    flag = flag || p_info["YTLB"].Equals(string.Empty);
                }
                if (this.checkEditJGCL.Checked)
                {
                    flag = flag || p_info["YTLB"].Equals(UseType.甲供材料.ToString());
                }
                if (this.checkEditJDYGCL.Checked)
                {
                    flag = flag || p_info["YTLB"].Equals(UseType.甲定乙供材料.ToString());
                }
                if (this.checkEditPBZDCL.Checked)
                {
                    flag = flag || p_info["YTLB"].Equals(UseType.评标指定材料.ToString());
                }
                if (this.checkEditZDJCL.Checked)
                {
                    flag = flag || p_info["YTLB"].Equals(UseType.暂定价材料.ToString());
                }
                if (this.checkEditZYCL.Checked)
                {
                    flag = flag || ToolKit.ParseBoolen(p_info["IFZYCL"]);
                }
                if (this.checkEditJSFXRCJ.Checked)
                {
                    flag = flag || ToolKit.ParseBoolen(p_info["IFFX"]);
                }
                if (this.checkEditCZJCRCJ.Checked)
                {
                    flag = flag || (!p_info["DJC"].Equals(0m));
                }
                if (this.checkEditSDSCJRCJ.Checked)
                {
                    flag = flag || ToolKit.ParseBoolen(p_info["IFSDSCDJ"]);
                }
                if (this.checkEditSC.Checked)
                {
                    flag = flag || ToolKit.ParseBoolen(p_info["IFSC"]);
                }
            }
            return flag;
        }

        /// <summary>
        /// 修改调价比例
        /// </summary>
        private void UpdateDJBL()
        {
            if (this.list != null)
            {
                APP.UserPriceLibrary.UnName = this.Activitie.Name;
                APP.UserPriceLibrary.Range = 0;
                foreach (DataRow item in this.list)
                {
                    DataRow dr = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", item["BH"])).FirstOrDefault();
                    if (dr == null) continue;
                    if (!dr["IFSDSCDJ"].Equals(true))
                    {
                        if (this.calcEditTJQB.Enabled)
                        {
                            if (this.calcEditTJQB.Value > 0)
                            {
                                item.BeginEdit();
                                item["SCDJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * this.calcEditTJQB.Value / 100;
                                APP.UserPriceLibrary.Update("SCDJ", item["SCDJ", DataRowVersion.Current], item);
                                item.EndEdit();
                                m_Methods_YTLBSummary.RefreshSCDJ(item);
                                continue;
                            }
                        }
                        else
                        {
                            if (this.calcEditTJZC.Value > 0 && calcEditTJZC.Enabled)
                            {
                                if (item["LB"].Equals("主材"))
                                {
                                    item.BeginEdit();
                                    item["SCDJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * this.calcEditTJZC.Value / 100;
                                    APP.UserPriceLibrary.Update("SCDJ", item["SCDJ", DataRowVersion.Current], item);
                                    item.EndEdit();
                                    m_Methods_YTLBSummary.RefreshSCDJ(item);
                                    continue;
                                }
                            }
                            if (this.calcEditTJRG.Value > 0 && calcEditTJRG.Enabled)
                            {
                                if (item["LB"].Equals("人工"))
                                {
                                    item.BeginEdit();
                                    item["SCDJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * this.calcEditTJRG.Value / 100;
                                    APP.UserPriceLibrary.Update("SCDJ", item["SCDJ", DataRowVersion.Current], item);
                                    item.EndEdit();
                                    m_Methods_YTLBSummary.RefreshSCDJ(item);
                                    continue;
                                }
                            }
                            if (this.calcEditTJSB.Value > 0 && calcEditTJSB.Enabled)
                            {
                                if (item["LB"].Equals("设备"))
                                {
                                    item.BeginEdit();
                                    item["SCDJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * this.calcEditTJSB.Value / 100;
                                    APP.UserPriceLibrary.Update("SCDJ", item["SCDJ", DataRowVersion.Current], item);
                                    item.EndEdit();
                                    m_Methods_YTLBSummary.RefreshSCDJ(item);
                                    continue;
                                }
                            }
                            if (this.calcEditTJJX.Value > 0 && calcEditTJJX.Enabled)
                            {
                                if (item["LB"].Equals("机械"))
                                {
                                    item.BeginEdit();
                                    item["SCDJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * this.calcEditTJJX.Value / 100;
                                    APP.UserPriceLibrary.Update("SCDJ", item["SCDJ", DataRowVersion.Current], item);
                                    item.EndEdit();
                                    continue;
                                }
                            }
                            if (this.calcEditTJCL.Value > 0 && calcEditTJCL.Enabled)
                            {
                                if (item["LB"].Equals("材料"))
                                {
                                    item.BeginEdit();
                                    item["SCDJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * this.calcEditTJCL.Value / 100;
                                    APP.UserPriceLibrary.Update("SCDJ", item["SCDJ", DataRowVersion.Current], item);
                                    item.EndEdit();
                                    m_Methods_YTLBSummary.RefreshSCDJ(item);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 修改设置选项
        /// </summary>
        private void UpdateSZXX()
        {
            if (this.list != null)
            {
                foreach (DataRow item in this.list)
                {
                    DataRow[] drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", item["BH"]));
                    if (drs.Length == 0) continue;
                    if (this.checkEditSZJSFX.Checked && item["IFFX"].Equals(false))
                    {
                        foreach (DataRow items in drs)
                        {
                            items["IFFX"] = this.checkEditSZJSFX.Checked;
                            this.Activitie.Property.TemporaryCalculate.Add(item);
                        }
                    }
                    if (this.checkEditSZSDSCJ.Checked && item["IFSDSCDJ"].Equals(false))
                    {
                        foreach (DataRow items in drs)
                        {
                            items["IFSDSCDJ"] = this.checkEditSZSDSCJ.Checked;
                        }
                    }
                    if (this.checkEditSZSC.Checked && item["IFSC"].Equals(false))
                    {
                        foreach (DataRow items in drs)
                        {
                            items["IFSC"] = this.checkEditSZSC.Checked;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 修改取消选项
        /// </summary>
        private void UpdateQXXX()
        {
            if (this.list != null)
            {
                foreach (DataRow item in this.list)
                {
                    DataRow[] drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", item["BH"]));
                    if (drs.Length == 0) continue;
                    if (this.checkEditQXJSFX.Checked && item["IFFX"].Equals(true))
                    {
                        foreach (DataRow items in drs)
                        {
                            items["IFFX"] = (!this.checkEditQXJSFX.Checked);
                            this.Activitie.Property.TemporaryCalculate.Add(item);
                        }
                    }
                    if (this.checkEditQXSDSCJ.Checked && item["IFSDSCDJ"].Equals(true))
                    {
                        foreach (DataRow items in drs)
                        {
                            items["IFSDSCDJ"] = (!this.checkEditQXSDSCJ.Checked);
                        }
                    }
                    if (this.checkEditQXSC.Checked && item["IFSC"].Equals(true))
                    {
                        foreach (DataRow items in drs)
                        {
                            items["IFSC"] = (!this.checkEditQXSC.Checked);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 所有下拉框输入不能输入负数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textEditWZ_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        /// <summary>
        /// 当输入时控制调价比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calcEditTJQB_EditValueChanged(object sender, EventArgs e)
        {
            CalcEdit ce = sender as CalcEdit;
            if (ce.Name == "calcEditTJQB")
            {
                if (this.calcEditTJQB.Value == 0)
                {
                    this.calcEditTJZC.Enabled = true;
                    this.calcEditTJSB.Enabled = true;
                    this.calcEditTJCL.Enabled = true;
                    this.calcEditTJRG.Enabled = true;
                    this.calcEditTJJX.Enabled = true;
                }
                else
                {
                    this.calcEditTJZC.Enabled = false;
                    this.calcEditTJSB.Enabled = false;
                    this.calcEditTJCL.Enabled = false;
                    this.calcEditTJRG.Enabled = false;
                    this.calcEditTJJX.Enabled = false;
                }
            }
            else
            {
                if (this.calcEditTJZC.Value == 0 && this.calcEditTJSB.Value == 0 && this.calcEditTJCL.Value == 0 && this.calcEditTJJX.Value == 0 && this.calcEditTJRG.Value == 0)
                {
                    this.calcEditTJQB.Enabled = true;
                }
                else
                {
                    this.calcEditTJQB.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 调价比重设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.calcEditTJQB.Text = "0";
            this.calcEditTJZC.Text = "0";
            this.calcEditTJSB.Text = "0";
            this.calcEditTJCL.Text = "0";
            this.calcEditTJRG.Text = "0";
            this.calcEditTJJX.Text = "0";
        }

        private void textEditWZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')//如果输入的内容不是数字
            {
                e.Handled = true;
                if (Convert.ToInt32(e.KeyChar) == 8)
                {
                    e.Handled = false;
                }
            }
        }

        private void textEditWZ_EditValueChanging_1(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Filter();
        }


    }
}