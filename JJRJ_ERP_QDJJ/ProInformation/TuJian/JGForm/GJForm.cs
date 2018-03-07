using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class GJForm : BaseBindingSource
    {

        public GJForm()
        {
            InitializeComponent();
        }
        public GJForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void GJForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "钢筋名称" };
                this.ArrCheckColl = new string[] { "GJMC" };
                EveryDataSource();//绑定数据源
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 绑定数据源
        private void EveryDataSource()
        {
            JGGJMCbindingSource.Filter = "JGSYID='7'";//筛选基类数据源中的  钢筋名称
            JMXZbindingSource.Filter = "JGSYID='7'";//筛选基类数据源中的  类别
        }
        private void OnlyOneDataSource()
        {
            this.JTXSbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["接头形式"];
            this.JTZMbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["确定接头子目"];
            this.bindingSource1.DataSource = InfTable.Rebar;///钢筋
            this.InfTable.Rebar.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//钢筋
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
            DataRowView CurrRow = this.bindingSource1.Current as DataRowView;
            if (null == CurrRow) return;
            base.btnScreenQDBH_Click(sender, e);

            if (!string.IsNullOrEmpty(toString(CurrRow["JTXS"])))
            {
                this.JTZMbindingSource.Filter = "JGGJMC='" + CurrRow["GJMC"] + "' and JTMC='" + CurrRow["JTXS"] + "'";
                DataTable dtTemp = new DataTable();
                foreach (DataRowView item in JTZMbindingSource)
                {
                    this.strToTable(dtTemp, toString(item["GJMC"]), "GJMC");
                }

                if (this.RemoveRepeat(dtTemp, "GJMC").Rows.Count > 0)
                {
                    this.CheckNull("LB", "类别");
                }
            }
            else
            {
                this.JMXZbindingSource.Filter = "JGSYID=7";
                if (this.JMXZbindingSource.Count > 0)
                {
                    this.CheckNull("LB", "类别");
                }
            }
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
                    string strQDWhere = " JGFL='钢筋' and JGLBMC like '%," + drCurrent["GJMC"] + ",%'";
                    DataRow dr = this.GetQD(strQDWhere, strTJ, CDataConvert.ConToValue<float>(drCurrent["SWGCL"]));//返回清单
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 模板子目
                    this.MBZMbindingSource.Filter = string.Format("JGMC='{0}' and JMXZMC like '%,{1},%'", "钢筋", drCurrent["LB"]);
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


                    #region 接头子目
                    //接头子目的查询条件
                    if (drCurrent.Row.Table.Columns.Contains("JTGS"))
                    {
                        string strWhereJTZM = string.Format("JGGJMC='{0}' and JTMC='{1}' and (GJMC is null or GJMC like '%,{2},%')", drCurrent["GJMC"], drCurrent["JTXS"], drCurrent["LB"]);
                        this.JTZMbindingSource.Filter = strWhereJTZM;
                        foreach (DataRowView item in this.JTZMbindingSource)
                        {
                            if (string.IsNullOrEmpty(toString(item["DEBH"])))
                            {
                                continue;
                            }
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DW"];
                            row["XS"] = item["GCLXS"];
                            if (item["JTMC"].ToString().Contains("接头") || item["JTMC"].ToString().Contains("内植"))
                            {
                                int index = item["DW"].ToString().IndexOf("个");
                                if(index <=0)
                                    index = item["DW"].ToString().IndexOf("根");
                                row["GCL"] = ToolKit.ParseDecimal(drCurrent["JTGS"].ToString()) / ToolKit.ParseDecimal(item["DW"].ToString().Substring(0, index));
                            }
                            else
                                row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                            if (decimal.Parse(row["XS"].ToString()) <= 0 && decimal.Parse(dr["GCL"].ToString()) > 0)
                                row["XS"] = Math.Round(decimal.Parse(row["GCL"].ToString()) / decimal.Parse(dr["GCL"].ToString()),6);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }
                    #endregion
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
            if (!string.IsNullOrEmpty(drCurrent["LB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".钢筋种类、规格：" + drCurrent["LB"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JTXS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".接头形式：" + drCurrent["JTXS"];
            }
            if (drCurrent.Row.Table.Columns.Contains("JTGS"))
            {

                if (!string.IsNullOrEmpty(drCurrent["JTGS"].ToString()))
                {
                    strContent += "\r\n" + (++i) + ".接头个数：" + drCurrent["JTGS"] + "个";
                }
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
            SetPopBar(sender as GridControl, e);
        }
        #endregion
        #endregion


        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView CurrRow = this.bindingSource1.Current as DataRowView;
            if (CurrRow == null) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "GJMC":
                    this.JGGJMCbindingSource.Filter = "JGSYID='7'";
                    popControl1.DataSource = this.JGGJMCbindingSource;
                    popControl1.ColName = new string[] { "钢筋名称|JGGJMC|GJMC" };
                    popControl1.RemoveDefaultColName = new string[] { "JTXS", "LB" };
                    popControl1.bind();
                    break;
                case "JTXS":
                    this.JTZMbindingSource.Filter = "JGGJMC='" + CurrRow["GJMC"] + "'";
                    popControl1.DataSource = (this.JTZMbindingSource.List as DataView).ToTable(true, "JTMC");
                    popControl1.ColName = new string[] { "接头形式|JTMC|JTXS" };
                    popControl1.RemoveDefaultColName = new string[] { "LB" };
                    popControl1.bind();
                    break;
                case "LB":
                    if (!string.IsNullOrEmpty(toString(CurrRow["JTXS"])))
                    {
                        this.JTZMbindingSource.Filter = "JGGJMC='" + CurrRow["GJMC"] + "' and JTMC='" + CurrRow["JTXS"] + "'";
                        DataTable dtTemp = new DataTable();
                        foreach (DataRowView item in JTZMbindingSource)
                        {
                            this.strToTable(dtTemp, toString(item["GJMC"]), "GJMC");
                        }
                        popControl1.DataSource = this.RemoveRepeat(dtTemp, "GJMC");
                        popControl1.ColName = new string[] { "类别|GJMC|LB" };
                    }
                    else
                    {
                        this.JMXZbindingSource.Filter = "JGSYID=7";
                        popControl1.DataSource = this.JMXZbindingSource;
                        popControl1.ColName = new string[] { "类别|JMXZ|LB" };
                    }
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
                    foreach (string item in this.SZBWrepositoryItemComboBox1.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemComboBox1.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            //if (this.gridView1.FocusedColumn.FieldName == "JTXS")
            //{
            //    if (toString(currRow["JTXS"]) == "内植钢筋")
            //    {
            //        currRow["DW"] = "根";
            //    }
            //    else
            //    {
            //        currRow["DW"] = "T";
            //    }
            //}
        }
    }

}