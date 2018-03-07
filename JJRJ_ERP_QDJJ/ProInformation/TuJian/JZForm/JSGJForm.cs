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
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class JSGJForm : BaseUI
    {
        public JSGJForm()
        {
            InitializeComponent();
        }
        public JSGJForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void JSGJForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();
        }
        public override object Parm
        {
            //验证必填项
            get
            {
                return base.Parm;
            }
            set
            {
                                this.gridView1.Columns["BZ"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                this.ArrCheckMess = new string[] { "构件分类" };
                this.ArrCheckColl = new string[] { "GJFL" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.JSGJ;
            this.InfTable.JSGJ.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.JSGJFLBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["金属构件分类"];
            this.YSJLQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["运输距离确定定额"];
            this.CXQDDEindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["除锈确定定额"];
            this.YQQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["油漆确定定额"];
            this.JSGJQDDEindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["金属构件确定定额"];
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
                    //（室外工程清单）
                    string strQDWhere = string.Format("GJFL = '{0}'", toString(drCurrent["GJFL"]));
                    this.JSGJFLBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.JSGJFLBindingSource.Count)
                    {
                        DataRowView view = this.JSGJFLBindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = CDataConvert.ConToValue<float>(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }

                    }
                    this.JSGJFLBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();


                    //金属构件确定定额

                    this.JSGJQDDEindingSource.Filter = string.Format(" GJFL = '{0}'", drCurrent["GJFL"]);
                    foreach (DataRowView item in this.JSGJQDDEindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }

                    //除锈确定定额

                    //运输距离确定定额
                    if (drCurrent["CX"] != null && !string.IsNullOrEmpty(toString(drCurrent["CX"])))
                    {
                        this.CXQDDEindingSource.Filter = string.Format("FL = '金属构件' and CXLB = '{0}'", drCurrent["CX"]);
                        foreach (DataRowView item in this.CXQDDEindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            row["XS"] = item["GCLXS"];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }

                    //运输距离确定定额
                    if (drCurrent["JSGJYJ"] != null && !string.IsNullOrEmpty(toString(drCurrent["JSGJYJ"])))
                    {
                        this.YSJLQDDEBindingSource.Filter = string.Format("FL='金属构件' and YJ='{0}'", drCurrent["JSGJYJ"]);
                        foreach (DataRowView item in this.YSJLQDDEBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            row["XS"] = item["GCLXS"];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }

                    //油漆确定定额
                    if (drCurrent["YQPZSQBS1"] != null && !string.IsNullOrEmpty(toString(drCurrent["YQPZSQBS1"])))
                    {
                        YQQDDEBindingSource.Filter = string.Format("FL1='金属面' and FL2=',其他金属面,' and YQPZ = '{0}'", drCurrent["YQPZSQBS1"]);
                        foreach (DataRowView item in this.YQQDDEBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            row["XS"] = item["GCLXS"];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                        }
                    }
                    if (drCurrent["YQPZSQBS2"] != null && !string.IsNullOrEmpty(toString(drCurrent["YQPZSQBS2"])))
                    {
                        YQQDDEBindingSource.Filter = string.Format("FL1='金属面' and FL2=',其他金属面,' and YQPZ = '{0}'", drCurrent["YQPZSQBS2"]);
                        foreach (DataRowView item in this.YQQDDEBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            row["XS"] = item["GCLXS"];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
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
            if (!string.IsNullOrEmpty(drCurrent["GJBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["GJFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".构件分类：" + drCurrent["GJFL"] + "　" + drCurrent["GJBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".除锈：" + drCurrent["CX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JSGJYJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".构件运距：" + drCurrent["JSGJYJ"] + "km";
            }
            if (!string.IsNullOrEmpty(drCurrent["YQPZSQBS1"].ToString()) || !string.IsNullOrEmpty(drCurrent["YQPZSQBS2"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".油漆品种、刷漆遍数：" + drCurrent["YQPZSQBS1"] + "　" + drCurrent["YQPZSQBS2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".所在部位：" + drCurrent["SZBW"];
            }
            this.InformationForm.SetFixedName(strKey, strContent);
        }
        #endregion


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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "GJFL":

                    JSGJFLBindingSource.Filter = "";
                    popControl1.DataSource = this.JSGJFLBindingSource;

                    popControl1.ColName = new string[] { "构件分类|GJFL|GJFL" };
                    popControl1.bind();
                    break;
                case "CX":

                    this.CXQDDEindingSource.Filter = " FL = '金属构件' ";
                    popControl1.DataSource = this.CXQDDEindingSource;

                    popControl1.ColName = new string[] { "除锈|CXLB|CX" };
                    popControl1.bind();
                    break;
                case "JSGJYJ":

                    this.YSJLQDDEBindingSource.Filter = "FL = '金属构件'";
                    popControl1.DataSource = this.YSJLQDDEBindingSource;

                    popControl1.ColName = new string[] { "金属构件运距|YJ|JSGJYJ" };
                    popControl1.bind();
                    break;
                case "YQPZSQBS1":

                    this.YQQDDEBindingSource.Filter = " FL1='金属面' and FL2=',其他金属面,' ";
                    popControl1.DataSource = this.YQQDDEBindingSource;
                    popControl1.ColName = new string[] { "油漆品种、刷漆遍数1|YQPZ|YQPZSQBS1" };
                    popControl1.bind();
                    break;
                case "YQPZSQBS2":

                    this.YQQDDEBindingSource.Filter = " FL1='金属面' and FL2=',其他金属面,' ";
                    popControl1.DataSource = this.YQQDDEBindingSource;
                    popControl1.ColName = new string[] { "油漆品种、刷漆遍数2|YQPZ|YQPZSQBS2" };
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
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
        }
    }
}
