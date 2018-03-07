using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ZNXTForm : BaseUI
    {
        public ZNXTForm()
        {
            InitializeComponent();
        } 

        private void ZNXTForm_Load(object sender, EventArgs e)
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
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.智能系统;
            this.InfTable.智能系统.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.ZNXTQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["智能系统确定定额"];
            this.AZQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["安装确定清单"];
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
            checkeArr();
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
                StringBuilder strString = null;
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
                    strString = new StringBuilder(" ZY='智能系统'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["SBFL"])) ? " and MC is null" : string.Format(" and MC like '%,{0},%'", drCurrent["SBFL"]));
                    this.AZQDQDBindingSource.Filter = strString.ToString();
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.AZQDQDBindingSource.Count)
                    {
                        DataRowView view = this.AZQDQDBindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    this.AZQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    #region 电气确定定额
                    strString = new StringBuilder();
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["XTFL"])) ? "  LB is null" : string.Format(" LB = '{0}'", drCurrent["XTFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["SBFL"])) ? " and FL is null" : string.Format(" and FL = '{0}'", drCurrent["SBFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GGMC"])) ? " and MC is null" : string.Format(" and MC = '{0}'", drCurrent["GGMC"]));

                    this.ZNXTQDDEBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.ZNXTQDDEBindingSource)
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
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
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
            if (!string.IsNullOrEmpty(drCurrent["XTFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".智能系统分类：" + drCurrent["XTFL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SBFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".设备分类：" + drCurrent["SBFL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GGMC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格、名称：" + drCurrent["GGMC"];
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
            StringBuilder strString = null;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "XTFL":

                    this.ZNXTQDDEBindingSource.Filter = " LB is not null";
                    popControl1.DataSource = RemoveRepeat(ZNXTQDDEBindingSource, "LB");

                    popControl1.ColName = new string[] { "系统分类|LB|XTFL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "SBFL", "GGMC" };
                    popControl1.bind();
                    break;
                case "SBFL":

                    strString = new StringBuilder();
                    strString.Append(string.IsNullOrEmpty(toString(currRow["XTFL"])) ? " LB is null" : string.Format(" LB = '{0}'", currRow["XTFL"]))
                             .Append(" and FL is not null");
                    this.ZNXTQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(ZNXTQDDEBindingSource, "FL");

                    popControl1.ColName = new string[] { "设备分类|FL|SBFL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GGMC" };
                    popControl1.bind();
                    break;
                case "GGMC":

                    strString = new StringBuilder();
                    strString.Append(string.IsNullOrEmpty(toString(currRow["XTFL"])) ? "  LB is null" : string.Format(" LB = '{0}'", currRow["XTFL"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["SBFL"])) ? " and FL is null" : string.Format(" and FL = '{0}'", currRow["SBFL"]))
                             .Append(" and MC is not null");
                    this.ZNXTQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(ZNXTQDDEBindingSource, "MC");

                    popControl1.ColName = new string[] { "综合布线型号|MC|GGMC" };
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
                    foreach (string item in this.SZBWrepositoryItemPopupContainerEdit.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemPopupContainerEdit.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;

            //当可以确定唯一清单时   修正当前行单位
            StringBuilder strString = new StringBuilder(" ZY='智能系统'");
            strString.Append(string.IsNullOrEmpty(toString(drCurrent["SBFL"])) ? " and MC is null" : string.Format(" and MC like '%,{0},%'", drCurrent["SBFL"]));
            this.AZQDQDBindingSource.Filter = strString.ToString();
            if (0 < AZQDQDBindingSource.Count)
            {
                DataRowView view = this.AZQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        //必填项验证
        private void checkeArr()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //判断是否已添加数据行
            if (currRow != null)
            {
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                //点击确定清单前   判断必填项  

                this.ZNXTQDDEBindingSource.Filter = "";
                if (0 < ZNXTQDDEBindingSource.Count)
                {
                    this.ZNXTQDDEBindingSource.Filter = " LB is null";
                    if (1 > ZNXTQDDEBindingSource.Count)
                    {
                        checkMess.Add("系统分类");
                        CheckColl.Add("XTFL");
                    }
                }
                StringBuilder strString = new StringBuilder();
                strString.Append(string.IsNullOrEmpty(toString(currRow["XTFL"])) ? " LB is null" : string.Format(" LB = '{0}'", currRow["XTFL"]));

                this.ZNXTQDDEBindingSource.Filter = strString.ToString();
                if (0 < ZNXTQDDEBindingSource.Count)
                {
                    strString.Append(" and FL is null");
                    this.ZNXTQDDEBindingSource.Filter = strString.ToString();
                    if (1 > ZNXTQDDEBindingSource.Count)
                    {
                        checkMess.Add("设备分类");
                        CheckColl.Add("SBFL");
                    }
                }

                strString = new StringBuilder();
                strString.Append(string.IsNullOrEmpty(toString(currRow["XTFL"])) ? "  LB is null" : string.Format(" LB = '{0}'", currRow["XTFL"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["SBFL"])) ? " and FL is null" : string.Format(" and FL = '{0}'", currRow["SBFL"]));
                this.ZNXTQDDEBindingSource.Filter = strString.ToString();
                if (0 < ZNXTQDDEBindingSource.Count)
                {
                    strString.Append(" and MC is null");
                    this.ZNXTQDDEBindingSource.Filter = strString.ToString();
                    if (1 > ZNXTQDDEBindingSource.Count)
                    {
                        checkMess.Add("规格、名称");
                        CheckColl.Add("GGMC");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}