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
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QZForm : BaseUI
    {
        public QZForm()
        {
            InitializeComponent();
        }
        public QZForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void QZForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "墙体类型" };
                this.ArrCheckColl = new string[] { "QTLX" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.QTLXbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["墙体类型"];
            this.QTHDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["墙体厚度"];
            this.ZPZbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砖品种及规格"];
            this.SZBWbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["所在部位"];
            this.SJBHLYQbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砂浆拌合料要求"];
            this.SJQDDJbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砂浆强度等级"];
            this.SJQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砂浆确定清单"];
            this.SJQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砂浆确定定额"];
            this.SJDECLMRDZBbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["砂浆定额材料默认对照表"];
            this.bindingSource1.DataSource = InfTable.Masonry;///砌筑
            this.InfTable.Masonry.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//砌筑
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
            if (null == currRow) return;
            base.btnScreenQDBH_Click(sender, e);
            DataTable dtTemp = this.GetZPZTable(currRow);
            if (dtTemp!=null && dtTemp.Rows.Count > 0)
            {
                this.CheckNull("ZPZ", "砖品种、规格");
            }
            this.QTHDbindingSource.Filter = " ZMC like '%," + currRow["ZPZ"] + ",%'";
            if (this.QTHDbindingSource.Count > 0)
            {
                this.CheckNull("QTHD", "墙体厚度");
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
                    string strQDWhere = string.Format("QTLXMC like '%,{0},%' and (ZMC is null or ZMC like '%,{1},%')", drCurrent["QTLX"], drCurrent["ZPZ"]);
                    this.SJQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.SJQDQDbindingSource.Count)
                    {
                        DataRowView view = this.SJQDQDbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = 1;
                        dr["GCL"] = 1 * CDataConvert.ConToValue<float>(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        drCurrent["DW"] = view["QDDW"];
                        if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 砂浆确定定额
                    this.SJQDDEbindingSource.Filter = string.Format("QTLXMC like '%,{0},%' and (QHD is null or QHD like '%,{1},%') and (ZMC is null or ZMC = '{2}')", drCurrent["QTLX"], drCurrent["QTHD"], drCurrent["ZPZ"]);
                    foreach (DataRowView item in this.SJQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        this.SJDECLMRDZBbindingSource.Filter = string.Format("DEBH='{0}'", item["DEBH"]);
                        if (SJDECLMRDZBbindingSource.Count > 0)
                        {
                            ///若换算前或换算后的  材机编号  不存在 就不做替换处理
                            DataRowView drViewHSQ = SJDECLMRDZBbindingSource[0] as DataRowView;

                            DataRowView drViewHSH = null;
                            this.SJQDDJbindingSource.Filter = string.Format(" SJMC = '{0}'", drCurrent["SJDJQD"]);
                            if (SJQDDJbindingSource.Count > 0)
                            {
                                drViewHSH = SJQDDJbindingSource[0] as DataRowView;
                            }
                            if (null != drViewHSQ && null != drViewHSH
                                && !string.IsNullOrEmpty(CDataConvert.ConToValue<string>(drViewHSQ["CJMC"].ToString()))
                                && !string.IsNullOrEmpty(CDataConvert.ConToValue<string>(drViewHSH["SJBH"].ToString()))
                                && !string.IsNullOrEmpty(CDataConvert.ConToValue<string>(drCurrent["SJDJQD"]))
                                && drViewHSQ["CJMC"].ToString() != drCurrent["SJDJQD"].ToString())
                            {
                                row["DEMC"] = item["DEMC"] + "//换：" + drCurrent["SJDJQD"].ToString();
                                row["HSQ"] = drViewHSQ["CJBH"];// item["HSQ"];//换算前
                                row["HSH"] = drViewHSH["SJBH"];//item["HSH"];//换算后 
                            }
                            else
                            {
                                row["DEMC"] = item["DEMC"];
                            }
                        }
                        else
                        {
                            row["DEMC"] = item["DEMC"];
                        }
                        row["DW"] = item["DEDW"];
                        if ("/(HD/1000)*0.01" == toString(item["GCLXS"]) && CDataConvert.ConToValue<float>(drCurrent["QTHD"]) != 0)
                        {
                            row["XS"] = (1 / (CDataConvert.ConToValue<float>(drCurrent["QTHD"]) / 1000)) * 0.01;
                        }
                        else
                        {
                            row["XS"] = item["GCLXS"];
                        }
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], row["HSQ"], row["HSH"]));
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
                    this.SJQDDJbindingSource.Filter = string.Empty;
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
            if (!string.IsNullOrEmpty(drCurrent["QTQBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["QTLX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙体类型：" + drCurrent["QTLX"] + "　" + drCurrent["QTQBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZPZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".砖品种、规格：" + drCurrent["ZPZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["QTHD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙体厚度：" + drCurrent["QTHD"] + "mm";
            }
            if (!string.IsNullOrEmpty(drCurrent["SJDJQD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".砂浆强度等级：" + drCurrent["SJDJQD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SJBHLYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".砂浆拌合料要求：" + drCurrent["SJBHLYQ"];
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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "QTLX":
                    popControl1.DataSource = this.QTLXbindingSource;
                    popControl1.ColName = new string[] { "墙体类型|QTLXMC|QTLX" };
                    popControl1.RemoveDefaultColName = new string[] { "ZPZ", "QTHD" };
                    popControl1.bind();
                    break;
                case "ZPZ":
                    popControl1.DataSource = GetZPZTable(currRow); //获取砖品种、规格表
                    popControl1.ColName = new string[] { "砖品种、规格|ZMC|ZPZ" };
                    popControl1.RemoveDefaultColName = new string[] { "QTHD" };
                    popControl1.bind();
                    break;
                case "QTHD":
                    this.QTHDbindingSource.Filter = " ZMC like '%," + currRow["ZPZ"] + ",%'";
                    popControl1.DataSource = this.QTHDbindingSource;
                    popControl1.ColName = new string[] { "墙体厚度（mm）|QTHD|QTHD" };
                    popControl1.bind();
                    break;
                case "SJBHLYQ":
                    popControl1.DataSource = this.SJBHLYQbindingSource;
                    popControl1.ColName = new string[] { "砂浆拌合料要求|BHLMC|SJBHLYQ" };
                    popControl1.bind();
                    break;
                case "SJDJQD":
                    popControl1.DataSource = this.SJQDDJbindingSource;
                    popControl1.ColName = new string[] { "砂浆强度等级|SJMC|SJDJQD" };
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
        /// <summary>
        /// 获取砖品种、规格表
        /// </summary>
        /// <param name="currRow"></param>
        /// <returns></returns>
        private DataTable GetZPZTable(DataRowView currRow)
        {
            this.SJQDQDbindingSource.Filter = "QTLXMC like '%," + currRow["QTLX"] + ",%'";
            DataTable dtTemp = new DataTable();
            foreach (DataRowView item in SJQDQDbindingSource)
            {
                this.strToTable(dtTemp, toString(item["ZMC"]), "ZMC");
            }
            return this.RemoveRepeat(dtTemp, "ZMC");
        }

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();


            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            string strQDWhere = string.Format("QTLXMC like '%,{0},%' and (ZMC is null or ZMC like '%,{1},%')", drCurrent["QTLX"], drCurrent["ZPZ"]);
            this.SJQDQDbindingSource.Filter = strQDWhere;
            if (0 < this.SJQDQDbindingSource.Count)
            {
                DataRowView view = this.SJQDQDbindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
    }

}