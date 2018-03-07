using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class MHForm : BaseUI
    {
        public MHForm()
        {
            InitializeComponent();
        }
        public MHForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void MHForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "抹灰分类", "砂浆种类" };
                this.ArrCheckColl = new string[] { "MHFL", "SJZL" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.MHQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["抹灰确定定额"];
            this.QZMQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["墙柱面确定清单"];
            this.SJHDTZbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砂浆厚度调整"];
            this.bindingSource1.DataSource = InfTable.MH;///抹灰
            this.InfTable.MH.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//抹灰
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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null)
            {
                return;
            }
            base.btnScreenQDBH_Click(sender, e);
            this.MHQDDEbindingSource.Filter = "MHFL='" + currRow["MHFL"] + "' AND SJZL='" + currRow["SJZL"] + "' and QTLX is not null";
            if (MHQDDEbindingSource.Count > 0)
            {
                CheckNull("QTLX", "墙体类型");
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
                    #region 确定清单
                    string strQDWhere = string.Format("QZMLB = '{0}' and FL like '%,{1},%'", "抹灰", toString(drCurrent["MHFL"]));
                    this.QZMQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.QZMQDQDbindingSource.Count)
                    {
                        DataRowView view = this.QZMQDQDbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(dr["XS"]) * ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["WZLX"] = WZLX.分部分项;
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 抹灰确定定额
                    this.MHQDDEbindingSource.Filter = string.Format("(MHFL is null or MHFL = '{0}') and (SJZL is null or SJZL='{1}') and (QTLX is null or QTLX ='{2}') and (SJPHB is null or SJPHB ='{3}')"
                        , toString(drCurrent["MHFL"])
                        , toString(drCurrent["SJZL"])
                        , toString(drCurrent["QTLX"])
                        , toString(drCurrent["SJPHB"]));
                    foreach (DataRowView item in this.MHQDDEbindingSource)
                    {
                        /// 默认定额
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
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLXS"], "", ""));

                        ////厚度更改以后
                        int intDefaultHD = ToolKit.ParseInt(item["HD"]);//默认厚度
                        int intSJHD = ToolKit.ParseInt(drCurrent["SJHD"]);//实际厚度【修改后】
                        if (intDefaultHD != 0 && intSJHD != 0 && intDefaultHD != intSJHD)
                        {
                            this.SJHDTZbindingSource.Filter = "SJZL='" + drCurrent["SJZL"] + "'";
                            foreach (DataRowView item2 in SJHDTZbindingSource)
                            {
                                DataRow row2 = APP.UnInformation.DETable.NewRow();
                                row2["DEBH"] = item2["DEBH"];
                                row2["DEMC"] = item2["DEMC"];
                                row2["DW"] = item2["DEDW"];
                                if (toString(item2["GCLXS"]) == "(S-H)*0.01")
                                {
                                    row2["XS"] = (intSJHD - intDefaultHD) * ToolKit.ParseDecimal(item["GCLXS"]);
                                }
                                else
                                {
                                    row2["XS"] = item2["GCLXS"];
                                }
                                row2["GCL"] = ToolKit.ParseDecimal(row2["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row2["QDBH"] = dr["QDBH"];
                                row2["TJ"] = strTJ;
                                row2["WZLX"] = WZLX.分部分项;
                                rows.Add(row2);

                                sb.Append(string.Format("{0},{1},{2},{3}|", item2["DEBH"], row2["XS"], "", ""));
                            }
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
            if (!string.IsNullOrEmpty(drCurrent["MHFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".抹灰分类：" + drCurrent["MHFL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SJZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".砂浆种类、厚度：" + drCurrent["SJZL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SJHD"].ToString()))
            {
                strContent += "　厚" + drCurrent["SJHD"] + "mm";
            }
            if (!string.IsNullOrEmpty(drCurrent["QTLX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙体类型：" + drCurrent["QTLX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SJPHB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".砂浆配合比：" + drCurrent["SJPHB"];
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

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "MHFL":
                    this.QZMQDQDbindingSource.Filter = " QZMLB = '抹灰'";
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FL");
                    dt.Columns.Add("ID");
                    dt.Columns["ID"].AutoIncrementSeed = 1;
                    dt.Columns["ID"].AutoIncrementStep = 1;
                    foreach (DataRowView item in this.QZMQDQDbindingSource)
                    {
                        dt.Rows.Add(toString(item["FL"]).Replace(",", ""));
                    }
                    popControl1.DataSource = dt;

                    popControl1.ColName = new string[] { "抹灰分类|FL|MHFL" };
                    popControl1.RemoveDefaultColName = new string[] { "SJZL", "QTLX", "SJHD", "SJPHB" };
                    popControl1.bind();
                    break;
                case "SJZL":
                    this.MHQDDEbindingSource.Filter = "MHFL='" + currRow["MHFL"] + "' and SJZL is not null";
                    popControl1.DataSource = (this.MHQDDEbindingSource.DataSource as DataTable).DefaultView.ToTable(true, "SJZL");
                    popControl1.ColName = new string[] { "砂浆种类|SJZL|SJZL" };

                    popControl1.RemoveDefaultColName = new string[] { "QTLX", "SJHD", "SJPHB" };
                    popControl1.bind();
                    break;
                case "QTLX":
                    this.MHQDDEbindingSource.Filter = "MHFL='" + currRow["MHFL"] + "' and SJZL='" + currRow["SJZL"] + "' and QTLX is not null";
                    popControl1.DataSource = (this.MHQDDEbindingSource.DataSource as DataTable).DefaultView.ToTable(true, "QTLX");
                    popControl1.ColName = new string[] { "墙体类型|QTLX|QTLX" };
                    popControl1.bind();
                    break;
                case "SJPHB":
                    popControl1.DataSource = this.MHQDDEbindingSource;
                    this.MHQDDEbindingSource.Filter = "MHFL='" + currRow["MHFL"] + "' and SJZL='" + currRow["SJZL"] + "' and (QTLX is null or QTLX='" + currRow["QTLX"] + "') and SJPHB is not null";
                    popControl1.ColName = new string[] { "砂浆配合比|SJPHB|SJPHB" };
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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }

            switch (this.gridView1.FocusedColumn.FieldName)
            {
                case "MHFL":///单位修改
                    this.QZMQDQDbindingSource.Filter = " QZMLB = '抹灰' and FL like '%," + currRow["MHFL"] + ",%'";
                    if (QZMQDQDbindingSource.Count == 1)
                    {
                        currRow["DW"] = (this.QZMQDQDbindingSource.Current as DataRowView)["QDDW"];
                    }
                    break;
                case "QTLX":
                case "SJZL":
                    ///抹灰厚度 默认值
                    this.MHQDDEbindingSource.Filter = "MHFL='" + currRow["MHFL"] + "' and SJZL='" + currRow["SJZL"] + "' and (QTLX is null or QTLX='" + currRow["QTLX"] + "') and HD is not null";
                    foreach (DataRowView item in this.MHQDDEbindingSource)
                    {
                        currRow["SJHD"] = item["HD"];
                    }
                    ///自动填充 砂浆配合比
                    this.MHQDDEbindingSource.Filter = "MHFL='" + currRow["MHFL"] + "' and SJZL='" + currRow["SJZL"] + "' and (QTLX is null or QTLX='" + currRow["QTLX"] + "')";
                    if (MHQDDEbindingSource.Count == 1)
                    {
                        currRow["SJPHB"] = (this.MHQDDEbindingSource.Current as DataRowView)["SJPHB"];
                    }
                    if (toString(currRow["SJZL"]) == "09j新标准")
                    {
                        this.gridView1.Columns.ColumnByFieldName("SJHD").OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        this.gridView1.Columns.ColumnByFieldName("SJHD").OptionsColumn.AllowEdit = true;
                    }
                    break;
            }
        }
    }
}
