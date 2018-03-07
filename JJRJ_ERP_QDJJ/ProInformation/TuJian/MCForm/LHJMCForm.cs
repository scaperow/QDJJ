using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class LHJMCForm : BaseMC
    {
        public LHJMCForm()
        {
            InitializeComponent();
        }

        public LHJMCForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void LHJMCForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "门窗分类", "洞宽", "洞高"};
                this.ArrCheckColl = new string[] { "LHJMCFL", "DK", "DG" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
   
            this.MCFJbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗附件"];
            this.SCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["窗纱确定定额"];
            MCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗确定定额"];
            this.bindingSource1.DataSource = InfTable.LHJMC;///铝合金门窗
            this.InfTable.LHJMC.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//铝合金门窗
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
                    string strQDWhere = string.Format(" MCLB='铝合金门窗' ");
                    DataRow dr = GetMCQD(strQDWhere, strTJ, ToolKit.ParseDecimal(drCurrent["SWGCL"]));

                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 门窗确定定额   确定定额

                    #endregion


                    #region 门窗  确定定额
                    this.MCQDDEbindingSource.Filter = string.Format("MCLB='铝合金门窗' and MCFL like '%,{0},%'",drCurrent["LHJMCFL"]);
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
                                row["XS"]=item["GCLXS"];
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
                    this.MCFJbindingSource.Filter = string.Format("FJMC='{0}'", drCurrent["LHJMCWJFJ"]);
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


                    //清空筛选条件
                    MCFJbindingSource.Filter = "";
                    #endregion

                    #region 门窗附件2   确定定额
                    if (drCurrent.Row.Table.Columns.Contains("LHJMCWJFJ2"))
                    {
                        this.MCFJbindingSource.Filter = string.Format("FJMC='{0}'", drCurrent["LHJMCWJFJ2"]);
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


                        //清空筛选条件
                        MCFJbindingSource.Filter = "";
                    }
                    #endregion

                    #region 窗纱  确定定额
                    this.SCQDDEbindingSource.Filter = string.Format("MCLB ='铝合金门窗' and MCFL='{0}'", drCurrent["LHJCS"]);
                    foreach (DataRowView item in this.SCQDDEbindingSource)
                    {
                        if (!string.IsNullOrEmpty(item["DEBH"].ToString()))
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            decimal gclxs = subDivide(item["GCLSX"]);
                            if (gclxs != -1)
                            {
                                row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                            }
                            else
                            {
                                row["XS"] = item["GCLSX"];
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
            if (!string.IsNullOrEmpty(drCurrent["LHJMCBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["LHJMCFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".铝合金门窗分类：" + drCurrent["LHJMCFL"] + "　" + drCurrent["LHJMCBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DK"].ToString()) && !string.IsNullOrEmpty(drCurrent["DG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".铝合金门窗尺寸：" + drCurrent["DK"] + "*" + drCurrent["DG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["LHJMCWJFJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".铝合金五金附件：" + drCurrent["LHJMCWJFJ"];
            }
            if (drCurrent.Row.Table.Columns.Contains("LHJMCWJFJ2") && !string.IsNullOrEmpty(drCurrent["LHJMCWJFJ2"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".铝合金五金附件2：" + drCurrent["LHJMCWJFJ2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["LHJCS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".铝合金窗纱：" + drCurrent["LHJCS"];
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
                case "LHJMCFL":
                    popControl1.DataSource = this.MCFLbindingSource;
                    this.MCFLbindingSource.Filter = " MCLB = '铝合金门窗'and MCFL is not null";
                    popControl1.ColName = new string[] { "门窗分类|MCFL|LHJMCFL" };
                    popControl1.bind();
                    break;
                case "LHJMCWJFJ":
                    popControl1.DataSource = this.MCFJbindingSource;
                    popControl1.ColName = new string[] { "五金附件|FJMC|LHJMCWJFJ" };
                    popControl1.bind();
                    break;
                case "LHJMCWJFJ2":
                    popControl1.DataSource = this.MCFJbindingSource;
                    popControl1.ColName = new string[] { "五金附件|FJMC|LHJMCWJFJ2" };
                    popControl1.bind();
                    break;
                case "LHJCS":
                    popControl1.DataSource = this.SCQDDEbindingSource;
                    this.SCQDDEbindingSource.Filter = " MCLB='铝合金门窗' and MCFL is not null ";
                    popControl1.ColName = new string[] { "铝合金窗纱|MCFL|LHJCS" };
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
    }
}
