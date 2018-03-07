using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class YZGJForm : BaseUI
    {
        public YZGJForm()
        {
            InitializeComponent();
        }
        public YZGJForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }


        private void YZGJForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "类别", "运距", "混凝土强度等级" };
                this.ArrCheckColl = new string[] { "LB", "YJ", "HNTQDDJ" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.YZGJLBbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["预制构件类别"];
            this.YZGJTJHDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["预制构件体积厚度"];
            this.YZGJYSQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["预制构件运输确定定额"];
            this.YZGJHNTQDDJbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["预制构件混凝土强度等级"];
            this.AZMBQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["安装模板确定定额"];
            this.ZJGFQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["座浆灌缝确定定额"];

            this.bindingSource1.DataSource = InfTable.YZGJ;///预制构件
            this.InfTable.YZGJ.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//预制构件
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
            DataRowView datarow = this.bindingSource1.Current as DataRowView;
            if (null == datarow) return;

            #region 必填项
            this.YZGJTJHDbindingSource.Filter = "GJLB='" + toString(datarow["LB"]) + "'";
            if (this.YZGJTJHDbindingSource.Count > 0)
            {
                if (this.ArrCheckMess.Length == 3)
                {
                    List<string> list = this.ArrCheckMess.ToList();
                    list.Add("体积、厚度");
                    this.ArrCheckMess = list.ToArray();

                    list = this.ArrCheckColl.ToList();
                    list.Add("TJHD");
                    this.ArrCheckColl = list.ToArray();
                }
            }
            else
            {
                if (this.ArrCheckMess.Length == 4)
                {
                    List<string> list = this.ArrCheckMess.ToList();
                    list.Remove("体积、厚度");
                    this.ArrCheckMess = list.ToArray();

                    list = this.ArrCheckColl.ToList();
                    list.Remove("TJHD");
                    this.ArrCheckColl = list.ToArray();
                }

            }
            #endregion

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
                    this.YZGJLBbindingSource.Filter = string.Format("GJLB = '{0}'", toString(drCurrent["LB"]));
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.YZGJLBbindingSource.Count)
                    {
                        DataRowView view = this.YZGJLBbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = CDataConvert.ConToValue<float>(dr["XS"]) * CDataConvert.ConToValue<float>(drCurrent["SWGCL"]);
                        dr["WZLX"] = WZLX.分部分项;
                        dr["TJ"] = strTJ;
                        if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 预制构件混凝土强度等级
                    this.YZGJHNTQDDJbindingSource.Filter = string.Format("QDDJ = '{0}'", toString(drCurrent["HNTQDDJ"]));
                    foreach (DataRowView item in this.YZGJHNTQDDJbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        if (!string.IsNullOrEmpty(toString(item["CJMC"])))
                        {
                            row["DEMC"] = item["DEMC"] + "换：//" + item["CJMC"];
                        }
                        else
                        {
                            row["DEMC"] = item["DEMC"];
                        }
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["HSQ"] = item["HSQ"];
                        row["HSH"] = item["HSH"];
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], row["HSQ"], row["HSH"]));
                    }
                    #endregion

                    #region 安装模版确定定额
                    this.AZMBQDDEbindingSource.Filter = string.Format("GJLB like '%,{0},%' and (TJHD is null or TJHD='{1}')", toString(drCurrent["LB"]), toString(drCurrent["TJHD"]));
                    foreach (DataRowView item in this.AZMBQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    #region 座浆灌缝确定定额
                    this.ZJGFQDDEbindingSource.Filter = string.Format("GJLB like '%,{0},%' and (TJHD is null or TJHD like '%,{1},%')", toString(drCurrent["LB"]), toString(drCurrent["TJHD"]));
                    foreach (DataRowView item in this.ZJGFQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    #region 预制构件运输确定定额
                    this.YZGJYSQDDEbindingSource.Filter = string.Format("GJLB like '%,{0},%' and YJ = '{1}'", toString(drCurrent["LB"]), toString(drCurrent["YJ"]));
                    foreach (DataRowView item in this.YZGJYSQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }
                    #endregion
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
            if (!string.IsNullOrEmpty(drCurrent["YZGJBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["LB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".预制构件分类：" + drCurrent["LB"] + "　" + drCurrent["YZGJBH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["TJHD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".体积、厚度：" + drCurrent["TJHD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["YJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".运输距离：" + drCurrent["YJ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["HNTQDDJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".混凝土强度等级：" + drCurrent["HNTQDDJ"];
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
                case "LB":
                    popControl1.DataSource = this.YZGJLBbindingSource;
                    this.YZGJLBbindingSource.Filter = "";
                    popControl1.ColName = new string[] { "预制构件类别|GJLB|LB" };
                    popControl1.RemoveDefaultColName = new string[] { "TJHD", "YJ" };
                    popControl1.bind();
                    break;
                case "TJHD":
                    popControl1.DataSource = this.YZGJTJHDbindingSource;
                    this.YZGJTJHDbindingSource.Filter = "GJLB='" + currRow["LB"] + "'";
                    popControl1.ColName = new string[] { "体积、厚度|TJHD|TJHD" };
                    popControl1.bind();
                    break;
                case "YJ":
                    popControl1.DataSource = this.YZGJYSQDDEbindingSource;
                    this.YZGJYSQDDEbindingSource.Filter = "GJLB like '%," + currRow["LB"] + ",%'";
                    popControl1.ColName = new string[] { "运距|YJ|YJ" };
                    popControl1.bind();
                    break;
                case "HNTQDDJ":
                    popControl1.DataSource = this.YZGJHNTQDDJbindingSource;
                    this.YZGJHNTQDDJbindingSource.Filter = "";
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
