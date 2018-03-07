using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class MMCForm : BaseMC
    {
        public MMCForm()
        {
            InitializeComponent();
        }
        public MMCForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void MMCForm_Load(object sender, EventArgs e)
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
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.MCLXbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗类型"];
            this.YSJLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["木门窗运输"];
            this.YQPZbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["木门窗油漆"];
            this.MMCYSDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["运输距离确定定额"];
            this.MCFJbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗附件"];
            this.MMCYQDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["木门窗油漆确定定额"];

            this.bindingSource1.DataSource = InfTable.MMC;///木门窗
            this.InfTable.MMC.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//木门窗
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
            //必填项验证
            checkeArr();

            if (null == this.bindingSource1.Current) return;
            base.btnScreenQDBH_Click(sender, e);
            if (this.CheckResult)
            {
                return;
            }
            ScreenWDBH(true);
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
                    #region 确定清单
                    string strQDWhere = string.Format(" MCLB='木门窗' and  MCFL like '%,{0},%' ", drCurrent["MMCFL"]);
                    DataRow dr = GetMCQD(strQDWhere, strTJ, ToolKit.ParseDecimal(drCurrent["SWGCL"]));

                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 木门窗运输 确定定额
                    this.MMCYSDEbindingSource.Filter = string.Format("FL='木门窗' and YJ = '{0}'", drCurrent["MMCYSJL"]);
                    foreach (DataRowView item in this.MMCYSDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        decimal gclxs = subDivide(item["GCLXS"]);
                        if (gclxs != -1)
                        {
                            row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                        }
                        else
                        {
                            row["XS"] = item["GCLXS"];
                        }
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }

                    #endregion

                    #region 门窗确定定额   确定定额
                    MCQDDEbindingSource.Filter = string.Format("MCLB='木门窗' and MCFL like '%,{0},%' and (MCLX is null or MCLX ='{1}' ) ", drCurrent["MMCFL"], drCurrent["MMCLX"]);
                    foreach (DataRowView item in this.MCQDDEbindingSource)
                    {
                        if (!string.IsNullOrEmpty(item["DEBH"].ToString()))
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            decimal gclxs = subDivide(item["GCLXS"]);
                            if (gclxs != -1)
                            {
                                row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                            }
                            else
                            {
                                row["XS"] = item["GCLXS"];
                            }
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }
                    #endregion

                    #region 门窗附件   确定定额
                    this.MCFJbindingSource.Filter = string.Format(" FJMC='{0}'", drCurrent["MCWJFJ"]);
                    foreach (DataRowView item in this.MCFJbindingSource)
                    {
                        if (!string.IsNullOrEmpty(item["DEBH"].ToString()))
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            decimal gclxs = subDivide(item["GCLXS"]);
                            if (gclxs != -1)
                            {
                                if (item["FJMC"] != null && (item["FJMC"].ToString()).Equals("门轨"))
                                    row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) / gclxs;
                                else
                                    row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                            }
                            else
                            {
                                row["XS"] = item["GCLXS"];
                            }
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }

                    #endregion

                    #region 门窗附件2   确定定额
                    if (drCurrent.Row.Table.Columns.Contains("MCWJFJ2"))
                    {
                        this.MCFJbindingSource.Filter = string.Format(" FJMC='{0}'", drCurrent["MCWJFJ2"]);
                        foreach (DataRowView item in this.MCFJbindingSource)
                        {
                            if (!string.IsNullOrEmpty(item["DEBH"].ToString()))
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                decimal gclxs = subDivide(item["GCLXS"]);
                                if (gclxs != -1)
                                {
                                    if (item["FJMC"] != null && (item["FJMC"].ToString()).Equals("门轨"))
                                        row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) / gclxs;
                                    else
                                        row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                                }
                                else
                                {
                                    row["XS"] = item["GCLXS"];
                                }
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                            }
                        }
                    }
                    #endregion

                    #region 木门窗油漆  确定定额
                    this.MMCYQDEbindingSource.Filter = string.Format("MCFL like '%,{0},%' and MCYQ='{1}'", drCurrent["MMCFL"], drCurrent["MMCYQPZ"]);
                    foreach (DataRowView item in this.MMCYQDEbindingSource)
                    {
                        if (!string.IsNullOrEmpty(item["DEBH"].ToString()))
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            decimal gclxs = subDivide(item["GCLXS"]);
                            if (gclxs != -1)
                            {
                                row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                            }
                            else
                            {
                                row["XS"] = item["GCLXS"];
                            }
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }
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
                    #endregion

                    #endregion
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
            if (!string.IsNullOrEmpty(drCurrent["MMCBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["MMCFL"].ToString()) || !string.IsNullOrEmpty(drCurrent["MMCLX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".木门窗分类：" + drCurrent["MMCFL"] + "　" + drCurrent["MMCLX"] + "　" + drCurrent["MMCBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DK"].ToString()) && !string.IsNullOrEmpty(drCurrent["DG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".木门窗尺寸：" + drCurrent["DK"] + "*" + drCurrent["DG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["MCWJFJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".五金附件：" + drCurrent["MCWJFJ"];
            }
            if (drCurrent.Row.Table.Columns.Contains("MCWJFJ2") && !string.IsNullOrEmpty(drCurrent["MCWJFJ2"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".五金附件2：" + drCurrent["MCWJFJ2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["MMCYSJL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".运输距离：" + drCurrent["MMCYSJL"] + "km";
            }
            if (!string.IsNullOrEmpty(drCurrent["MMCYQPZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".油漆品种：" + drCurrent["MMCYQPZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".所在部位：" + drCurrent["SZBW"];
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
            SetPopBar(sender as GridControl, e);
        }
        #endregion

        #endregion

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "MMCFL":
                    popControl1.DataSource = this.MCFLbindingSource;
                    this.MCFLbindingSource.Filter = " MCLB = '木门窗'";
                    popControl1.ColName = new string[] { "木门窗分类|MCFL|MMCFL" };
                    popControl1.RemoveDefaultColName = new string[] { "MMCLX" };
                    popControl1.bind();
                    break;
                case "MMCLX":
                    popControl1.DataSource = this.MCLXbindingSource;
                    this.MCLXbindingSource.Filter = string.Format("  MCLB = '木门窗' and ( MCFL is null or MCFL ='{0}') and MCLX is not null", toString(currRow["MMCFL"]));
                    popControl1.ColName = new string[] { "木门窗类型|MCLX|MMCLX" };
                    popControl1.bind();
                    break;
                case "MCWJFJ":
                    //清空查询记录
                    MCFJbindingSource.Filter = "";
                    popControl1.DataSource = this.MCFJbindingSource;
                    popControl1.ColName = new string[] { "门窗五金附件|FJMC|MCWJFJ" };
                    popControl1.bind();
                    break;
                case "MCWJFJ2":
                    //清空查询记录
                    MCFJbindingSource.Filter = "";
                    popControl1.DataSource = this.MCFJbindingSource;
                    popControl1.ColName = new string[] { "门窗五金附件|FJMC|MCWJFJ2" };
                    popControl1.bind();
                    break;
                case "MMCYSJL":
                    popControl1.DataSource = this.MMCYSDEbindingSource;
                    MMCYSDEbindingSource.Filter = "FL='木门窗' and YJ is not null";
                    popControl1.ColName = new string[] { "木门窗运输距离(km)|YJ|MMCYSJL" };
                    popControl1.bind();
                    break;
                case "MMCYQPZ":
                    popControl1.DataSource = this.YQPZbindingSource;
                    this.YQPZbindingSource.Filter = "YQPZ is not null";
                    popControl1.ColName = new string[] { "木门窗油漆|YQPZ|MMCYQPZ" };
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
        private void checkeArr()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //判断是否已添加数据行
            if (currRow != null)
            {
                //点击确定清单前   判断必填项
                this.MCLXbindingSource.Filter = string.Format("  MCLB = '木门窗' and ( MCFL is null or MCFL ='{0}') and MCLX is not null", toString(currRow["MMCFL"]));
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                checkMess.Add("木门窗分类");
                CheckColl.Add("MMCFL");
                checkMess.Add("洞宽");
                CheckColl.Add("DK");
                checkMess.Add("洞高");
                CheckColl.Add("DG");


                if (0 < MCLXbindingSource.Count)
                {
                    checkMess.Add("木门窗类型");
                    CheckColl.Add("MMCLX");
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}