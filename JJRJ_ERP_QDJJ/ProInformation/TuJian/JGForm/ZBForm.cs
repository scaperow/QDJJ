using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;
using System.Web.UI.WebControls;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ZBForm : BaseBindingSource
    {
        public ZBForm()
        {
            InitializeComponent();
        }
        public ZBForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void ZBForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();
        }
        public override object Parm
        {
            get
            {
                return base.Parm;
            }
            set
            {
                                this.gridView1.Columns["BZ"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                this.ArrCheckMess = new string[] { "类别", "截面形状", "混凝土拌合料要求", "混凝土强度等级" };
                this.ArrCheckColl = new string[] { "LB", "JMXZ", "HNTBHLYQ", "HNTQDDJ" };
                EveryDataSource();///筛选数据源
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 筛选、绑定数据源
        private void EveryDataSource()
        {
            this.JMCCbindingSource.Filter = "JGSYID='1'";//截面尺寸
            this.JMXZbindingSource.Filter = "JGSYID='1'";//截面形状
        }
        private void OnlyOneDataSource()
        {
            this.ZJHZCbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["直径或周长"];
            this.bindingSource1.DataSource = InfTable.Pillar;///柱表
            this.InfTable.Pillar.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//柱表
        }
        #endregion

        #region 操作
        #region 确认清单编号
        /// <summary>
        /// 焦点行发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView sender1 = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            gridView1_FocusedColumnChanged(sender, new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs(null, sender1.FocusedColumn));///;触发焦点列改变事件
            if (null == this.bindingSource1.Current) return;
            ScreenWDBH(false);///添加筛选清单
        }

        #region 焦点列改变
        /// <summary>
        /// 焦点列改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            DataRowView dtCurr = this.bindingSource1.Current as DataRowView;
            if (null == dtCurr) { return; }
            switch (e.FocusedColumn.FieldName)
            {
                case "LYCBC":
                case "YCBC":
                    if (dtCurr["JMXZ"].ToString() == "矩形")
                    {
                        this.gridView1.OptionsBehavior.Editable = true;
                    }
                    else
                    {
                        this.gridView1.OptionsBehavior.Editable = false;
                    }
                    break;
                case "ZJHZC":
                    if (dtCurr["JMXZ"].ToString() == "圆形" || dtCurr["JMXZ"].ToString() == "矩形")
                    {
                        this.gridView1.OptionsBehavior.Editable = true;
                    }
                    else
                    {
                        this.gridView1.OptionsBehavior.Editable = false;
                    }
                    break;
                default:
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 确认清单编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnScreenQDBH_Click(object sender, EventArgs e)
        {
            if (null == this.bindingSource1.Current) return;
            base.btnScreenQDBH_Click(sender, e);
            if (this.CheckResult)
            {
                return;
            }
            else
            {
                DataRowView drCurr = this.bindingSource1.Current as DataRowView;
                if (drCurr["JMXZ"].ToString() == "矩形" && string.IsNullOrEmpty(drCurr["ZJHZC"].ToString()))
                {
                    if (drCurr["LB"].ToString().Equals("框架柱") && (string.IsNullOrEmpty(drCurr["YCBC"].ToString()) || string.IsNullOrEmpty(drCurr["LYCBC"].ToString())))
                    {
                        MsgBox.Alert("请输入 两侧边长 或者 直径或周长");
                        return;
                    }
                }
            }
            ScreenWDBH(true);///添加筛选清单
            btnRefreshQDMC_Click(sender, e);
        }
        #region 添加筛选清单
        /// <summary>
        /// 添加筛选清单
        /// </summary>
        /// <param name="isAdd">是否添加</param>
        private void ScreenWDBH(bool isAdd)
        {
            try
            {
                if (null == this.bindingSource1.Current)
                {
                    this.InformationForm.Fiter(" 1<>1 ");
                    return;
                }
                DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
                //string strTJ = string.Format("{0}[{1}]", drCurrent["FormMC"], drCurrent["ID"]);//条件  清单、子目标识
                string strTJ = "";
                if (string.IsNullOrEmpty(drCurrent["BZ"].ToString()))
                {
                    strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    drCurrent["BZ"] = strTJ;
                }
                else
                {
                    strTJ = drCurrent["BZ"].ToString();
                }
                if (isAdd)
                {
                    string strQDWhere = " JGFL='柱' and JGLBMC like '%," + drCurrent["LB"] + "%' and (JMXZ is null or JMXZ like '%," + drCurrent["JMXZ"] + "%')";
                    DataRow dr = this.GetQD(strQDWhere, strTJ, CDataConvert.ConToValue<float>(drCurrent["SWGCL"]));//返回清单
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 模板子目
                    string strMBZMwhere = string.Format("JGMC='{0}' and (JMXZMC is null or JMXZMC like'%,{1},%') and JGGJMC like '%,{2},%'", "柱", drCurrent["JMXZ"], drCurrent["LB"]);
                    #region 截面形状为柱形时的 筛选条件
                    if (drCurrent["JMXZ"].ToString() == "矩形")
                    {
                        int strZJHZC = 0;
                        if (string.IsNullOrEmpty(drCurrent["ZJHZC"].ToString()))
                        {
                            strZJHZC = (ToolKit.ParseInt(drCurrent["YCBC"]) + ToolKit.ParseInt(drCurrent["LYCBC"])) * 2;
                        }
                        else
                        {
                            switch (drCurrent["ZJHZC"].ToString())
                            {
                                case ">1800":
                                    strZJHZC = 1801;
                                    break;
                                case "<=1800":
                                    strZJHZC = 1800;
                                    break;
                                default:
                                    strZJHZC = ToolKit.ParseInt(drCurrent["ZJHZC"]);
                                    break;
                            }
                        }
                        if (strZJHZC > 1800)
                        {
                            strMBZMwhere = strMBZMwhere + " and (JSGZ is null or JSGZ='>1800mm')";
                        }
                        else
                        {
                            strMBZMwhere = strMBZMwhere + " and (JSGZ is null or JSGZ='<=1800mm')";
                        }
                    }
                    #endregion

                    this.MBZMbindingSource.Filter = strMBZMwhere;
                    foreach (DataRowView item in this.MBZMbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    #region 《混凝土要求及确定子目》
                    this.HNTYQbindingSource.Filter = string.Format("BHLYQ='{0}'", drCurrent["HNTBHLYQ"]);
                    foreach (DataRowView item in this.HNTYQbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DW"] = item["DW"];
                        row["XS"] = item["GCLXS"];

                        DataRowView rowViewHSH = null;
                        this.HNTQDbindingSource.Filter = string.Format(" QDDJ = '{0}' and BHLYQ='{1}'", drCurrent["HNTQDDJ"], drCurrent["HNTBHLYQ"]);
                        if (HNTQDbindingSource.Count > 0)
                        {
                            rowViewHSH = HNTQDbindingSource[0] as DataRowView;
                        }

                        if (null != rowViewHSH && !string.IsNullOrEmpty(CDataConvert.ConToValue<string>(rowViewHSH["CJBH"])) && item["MRCJ"].ToString() != rowViewHSH["CJBH"].ToString())
                        {
                            ///若换算前或换算后的  材机编号  不存在 就不做替换处理
                            row["DEMC"] = item["DEMC"] + "//换：" + rowViewHSH["CJMC"] + "；";
                            row["HSQ"] = item["MRCJ"];// item["HSQ"];//换算前
                            row["HSH"] = rowViewHSH["CJBH"];//item["HSH"];//换算后 
                        }
                        else
                        {
                            row["DEMC"] = item["DEMC"];
                        }
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], row["HSQ"], row["HSH"]));
                    }

                    #endregion

                    #region 《结构分类及确定超高子目》
                    double strGD = 0;
                    //if ("3.6米以上" == drCurrent["ZGD"].ToString() || (double.TryParse(drCurrent["ZGD"].ToString(), out strGD) && strGD > 3.6))
                    if ((double.TryParse(drCurrent["ZGD"].ToString(), out strGD) && strGD > 3.6))
                    {
                        //this.JGFLbindingSource.Filter = string.Format("JGFL='{0}' and GD='{1}'", "柱", "3.6米以上");
                        this.JGFLbindingSource.Filter = string.Format("JGFL='{0}' and GD like '%,{1},%'", "柱", strGD);
                        foreach (DataRowView item in this.JGFLbindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            row["XS"] = item["GCLXS"];
                            row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }
                    #endregion

                    this.HNTYQbindingSource.Filter = "";//重置  混凝土拌合料要求  的筛选条件
                    LookUpEditSelectChage(CDataConvert.ConToValue<string>(drCurrent["HNTBHLYQ"]));
                    //dr["BZ"] = sb.ToString() + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    if (string.IsNullOrEmpty(dr["TJ"].ToString()))
                    {
                        dr["BZ"] = sb.ToString() + strTJ;
                        dr["TJ"] = strTJ;
                    }
                    else
                    {
                        dr["BZ"] = sb.ToString() + dr["TJ"].ToString();
                    }
                    this.InformationForm.Remove(strTJ);
                    this.InformationForm.Add(dr, rows);
                }
                else
                {
                    //this.InformationForm.Fiter(string.Format("TJ='{0}[{1}]'", drCurrent["FormMC"], drCurrent["ID"]));///添加筛选清单
                    this.InformationForm.Fiter(string.Format("TJ='{0}'", strTJ));///添加筛选清单
                }
            }
            catch (Exception ex)
            {
                DebugErr(ex.Message);
            }
        }
        #endregion

        #endregion

        #region 刷新清单名称
        /// <summary>
        /// 刷新清单名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnRefreshQDMC_Click(object sender, EventArgs e)
        {
            if (null == this.bindingSource1.Current) return;
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            string strKey = "项目特征";
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(drCurrent["ZBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["LB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".柱编号：" + drCurrent["LB"] + "　" + drCurrent["ZBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JMXZ"].ToString()))
            {
                strContent += "　" + drCurrent["JMXZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZGD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".柱高度：" + drCurrent["ZGD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["YCBC"].ToString()) && !string.IsNullOrEmpty(drCurrent["LYCBC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".柱截面尺寸：" + drCurrent["YCBC"] + "*" + drCurrent["LYCBC"] + "(" + drCurrent["ZJHZC"] + ")";
            }
            else if (!string.IsNullOrEmpty(drCurrent["ZJHZC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".柱截面尺寸：" + drCurrent["ZJHZC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["HNTQDDJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".混凝土强度等级：" + drCurrent["HNTQDDJ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["HNTBHLYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".混凝土拌合料要求：" + drCurrent["HNTBHLYQ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".部位：" + drCurrent["SZBW"];
            }
            this.InformationForm.SetFixedName(strKey, strContent);
        }
        #endregion

        #region 鼠标点击【右键处理】
        /// <summary>
        /// 鼠标点击【右键处理】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlEx1_MouseUp(object sender, MouseEventArgs e)
        {
            SetPopBar(sender as DevExpress.XtraGrid.GridControl, e);
        }
        #endregion

        #endregion

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView CurrRow = this.bindingSource1.Current as DataRowView;
            if (CurrRow == null) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            popControl1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            switch (e.Column.FieldName)
            {
                case "LB":
                    this.JGGJMCbindingSource.Filter = "JGSYID='1'";
                    popControl1.DataSource = this.JGGJMCbindingSource;
                    popControl1.ColName = new string[] { "类别|JGGJMC|LB" };
                    popControl1.RemoveDefaultColName = new string[] { "JMXZ" };
                    popControl1.bind();
                    break;
                case "JMXZ":
                    this.QDbindingSource.Filter = "JGFL='柱' and (JGLBMC is null or JGLBMC like '%," + CurrRow["LB"] + ",%')";
                    DataTable dtItem = new DataTable();
                    foreach (DataRowView item in QDbindingSource)
                    {
                        this.strToTable(dtItem, toString(item["JMXZ"]), "JMXZ");
                    }
                    popControl1.DataSource = this.RemoveRepeat(dtItem, "JMXZ");
                    popControl1.ColName = new string[] { "截面形状|JMXZ|JMXZ" };
                    popControl1.RemoveDefaultColName = new string[] { "YCBC", "LYCBC", "ZJHZC" };
                    popControl1.bind();
                    break;
                case "YCBC":
                    this.JMCCbindingSource.Filter = "JGSYID='1'";
                    popControl1.DataSource = this.JMCCbindingSource;
                    popControl1.ColName = new string[] { "一侧边长|JMCC|YCBC" };
                    popControl1.bind();
                    break;
                case "LYCBC":
                    this.JMCCbindingSource.Filter = "JGSYID='1'";
                    popControl1.DataSource = this.JMCCbindingSource;
                    popControl1.ColName = new string[] { "另一侧边长|JMCC|LYCBC" };
                    popControl1.bind();
                    break;
                case "ZJHZC":
                    this.ZJHZCbindingSource.Filter = "JGSYID='1'";
                    popControl1.DataSource = this.ZJHZCbindingSource;
                    popControl1.ColName = new string[] { "直径或周长|ZJHZC|ZJHZC" };
                    popControl1.RemoveDefaultColName = new string[] { "YCBC", "LYCBC" };
                    popControl1.bind();
                    break;
                case "ZGD":
                    popControl1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    popControl1.DataSource = this.CGSDbindingSource;
                    popControl1.ColName = new string[] { "柱高度|CGSD|ZGD" };
                    popControl1.bind();
                    break;
                case "HNTBHLYQ":
                    popControl1.DataSource = this.HNTYQbindingSource;
                    popControl1.ColName = new string[] { "混凝土拌合料要求|BHLYQ|HNTBHLYQ" };
                    popControl1.RemoveDefaultColName = new string[] { "HNTQDDJ" };
                    popControl1.bind();
                    break;
                case "HNTQDDJ":
                    DataRowView currRow = this.bindingSource1.Current as DataRowView;
                    if (null == currRow) { return; }
                    LookUpEditSelectChage(CDataConvert.ConToValue<string>(currRow["HNTBHLYQ"]).Trim());
                    popControl1.DataSource = this.HNTQDbindingSource;
                    popControl1.ColName = new string[] { "混凝土强度等级|QDDJ|HNTQDDJ" };
                    popControl1.bind();
                    break;
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "SZBW":
                    string val = e.Value.ToString();
                    foreach (string item in this.SZBWrepositoryItemComboBox.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemComboBox.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();

            decimal ycbc = 0;
            decimal lycbc = 0;
            switch (this.gridView1.FocusedColumn.FieldName)
            {
                case "YCBC":
                case "LYCBC":
                    ycbc = ToolKit.ParseDecimal(currRow["YCBC"]);//一侧边长
                    lycbc = ToolKit.ParseDecimal(currRow["LYCBC"]);//另一侧边长
                    if (0 != ycbc && 0 != lycbc)
                    {
                        decimal zc = 2 * (ycbc + lycbc);
                        if (zc > 1800)
                        {
                            currRow["ZJHZC"] = ">1800";
                        }
                        else
                        {
                            currRow["ZJHZC"] = "<=1800";
                        }

                    }
                    break;
            }
        }
    }
}