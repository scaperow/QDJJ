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

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QBForm : BaseBindingSource
    {
        public QBForm()
        {
            InitializeComponent();
        }
        public QBForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void QBForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
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
                this.ArrCheckMess = new string[] { "类别", "直行、弧形", "混凝土拌合料要求", "混凝土强度等级" };
                this.ArrCheckColl = new string[] { "LB", "ZXHX", "HNTBHLYQ", "HNTQDDJ" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 筛选、绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.Wall;///墙表
            this.InfTable.Wall.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//墙表
        }
        #endregion


        #region 操作
        #region 确认清单编号
        /// <summary>
        /// 选择发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ScreenWDBH(false);///添加筛选清单
        }
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
                    string strQDWhere = " JGFL='墙' and JGLBMC like '%," + drCurrent["LB"] + "%' and (JMXZ is null or JMXZ like '%," + drCurrent["ZXHX"] + "%')";
                    DataRow dr = this.GetQD(strQDWhere, strTJ, CDataConvert.ConToValue<float>(drCurrent["SWGCL"]));//返回清单
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 模板子目
                    string strWhere = string.Format("JGMC='{0}' and JMXZMC like '%,{1},%'", "墙", drCurrent["ZXHX"]);

                    #region 截面形状为柱形时的 筛选条件
                    int strZJHZC = 0;
                    switch (drCurrent["QHD"].ToString())
                    {
                        case "<=200mm":
                            strZJHZC = 200;
                            break;
                        case ">200mm,<=300mm":
                            strZJHZC = 201;
                            break;
                        case ">300mm":
                            strZJHZC = 301;
                            break;
                        default:
                            strZJHZC = ToolKit.ParseInt(drCurrent["QHD"]);
                            break;
                    }

                    if (strZJHZC > 300)
                    {
                        strWhere = strWhere + " and (JSGZ is null or JSGZ='>300mm')";
                    }
                    else if (strZJHZC > 200)
                    {
                        strWhere = strWhere + " and (JSGZ is null or JSGZ='>200mm,<=300mm')";
                    }
                    else
                    {
                        strWhere = strWhere + " and (JSGZ is null or JSGZ='<=200mm')";
                    }

                    #endregion

                    this.MBZMbindingSource.Filter = strWhere;
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
                    //this.JGFLbindingSource.Filter = string.Format("JGFL='{0}' and GD='{1}'", "墙", drCurrent["QGD"]);
                    this.JGFLbindingSource.Filter = string.Format("JGFL='{0}' and GD like '%,{1},%'", "墙", drCurrent["QGD"]);


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
            if (!string.IsNullOrEmpty(drCurrent["QBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["LB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙编号：" + drCurrent["LB"] + "　" + drCurrent["QBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZXHX"].ToString()))
            {
                strContent += "　" + drCurrent["ZXHX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["QGD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙高：" + drCurrent["QGD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["QHD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙厚度：" + drCurrent["QHD"];
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

        /// <summary>
        /// 录入墙厚度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QHDrepositoryItemComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
                {
                    e.Handled = true;
                }
            }
        }
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
                    this.JGGJMCbindingSource.Filter = "JGSYID='3'";
                    popControl1.DataSource = this.JGGJMCbindingSource;
                    popControl1.ColName = new string[] { "类别|JGGJMC|LB" };
                    popControl1.bind();
                    break;
                case "ZXHX":
                    this.QDbindingSource.Filter = "JGFL='墙' and (JGLBMC is null or JGLBMC like '%," + CurrRow["LB"] + ",%')";
                    DataTable dtItem = new DataTable();
                    foreach (DataRowView item in QDbindingSource)
                    {
                        this.strToTable(dtItem, toString(item["JMXZ"]), "JMXZ");
                    }
                    popControl1.DataSource = this.RemoveRepeat(dtItem, "JMXZ");
                    popControl1.ColName = new string[] { "直行、弧形|JMXZ|ZXHX" };
                    popControl1.bind();
                    break;
                case "QHD":
                    popControl1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    this.JMCCbindingSource.Filter = "JGSYID='3'";
                    popControl1.DataSource = this.JMCCbindingSource;
                    popControl1.ColName = new string[] { "墙厚度（mm）|JMCC|QHD" };
                    popControl1.bind();
                    break;
                case "QGD":
                    popControl1.DataSource = this.CGSDbindingSource;
                    popControl1.ColName = new string[] { "墙高度（m）|CGSD|QGD" };
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
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
        }
    }
}