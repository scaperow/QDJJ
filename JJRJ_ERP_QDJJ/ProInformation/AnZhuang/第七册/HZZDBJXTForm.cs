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
    public partial class HZZDBJXTForm : BaseUI
    {
        public HZZDBJXTForm()
        {
            InitializeComponent();
        }

        private void HZZDBJXTForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.火灾自动报警系统;
            this.InfTable.火灾自动报警系统.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.HZZDBJBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["火灾自动报警"];
            this.GDSZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
            this.XFQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["消防确定清单"];
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
                    StringBuilder strString = new StringBuilder(" XT='自动报警'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["MC"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["MC"]));
                    this.XFQDQDBindingSource.Filter = strString.ToString();
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.XFQDQDBindingSource.Count)
                    {
                        DataRowView view = this.XFQDQDBindingSource[0] as DataRowView;
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
                    this.XFQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    strString = new StringBuilder(" XT='火灾自动报警'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", drCurrent["MC"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", drCurrent["DXZZXZ"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", drCurrent["AZFS"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["LX"])) ? " and LX is null" : string.Format(" and  LX = '{0}'", drCurrent["LX"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["KZDSL"])) ? " and KZD is null" : string.Format(" and  KZD = '{0}'", drCurrent["KZDSL"]));
                    this.HZZDBJBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.HZZDBJBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        string debh = toString(item["DEBH"]);

                        //根据高度设置的《系数》   修改定额编号

                        StringBuilder str_xs = new StringBuilder(" SYFW='消防' ");// 
                        str_xs.Append(string.IsNullOrEmpty(toString(drCurrent["CZGD"])) ? " and BTMS='操作高度' and GD is null" : string.Format(" and (BTMS='操作高度' or BTMS='操作部位') and GD = '{0}'", drCurrent["CZGD"]));
                        this.GDSZBindingSource.Filter = str_xs.ToString();
                        foreach (DataRowView gdszItem in this.GDSZBindingSource)
                        {
                            debh = debh + " " + toString(gdszItem["XS"]);
                        }
                        row["DEBH"] = debh;
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
            if (!string.IsNullOrEmpty(toString(drCurrent["MC"])))
            {
                strContent += "\r\n" + (++i) + ".火灾自动报警名称：" + drCurrent["MC"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["DXZZXZ"])))
            {
                strContent += "\r\n" + (++i) + ".多线制、总线制：" + drCurrent["DXZZXZ"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["AZFS"])))
            {
                strContent += "\r\n" + (++i) + ".安装方式：" + drCurrent["AZFS"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["LX"])))
            {
                strContent += "\r\n" + (++i) + ".类型：" + drCurrent["LX"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["KZDSL"])))
            {
                strContent += "\r\n" + (++i) + ".控制点数量：" + drCurrent["KZDSL"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZGD"])))
            {
                strContent += "\r\n" + (++i) + ".操作高度：" + drCurrent["CZGD"];
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
            StringBuilder strString = null;

            switch (e.Column.FieldName)
            {
                case "MC":

                    this.HZZDBJBindingSource.Filter = " XT='火灾自动报警' and MC is not null";
                    //字符串截断并去重复
                    popControl1.DataSource = RemoveRepeat(HZZDBJBindingSource, "MC");

                    popControl1.ColName = new string[] { "名称|MC|MC" };
                    popControl1.RemoveDefaultColName = new string[] { "DXZZXZ", "AZFS", "LX", "KZDSL" };
                    popControl1.bind();
                    break;
                case "DXZZXZ":

                    strString = new StringBuilder(" XT='火灾自动报警' and XZ is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]));

                    HZZDBJBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(HZZDBJBindingSource, "XZ");

                    popControl1.ColName = new string[] { "多线制、总线制|XZ|DXZZXZ" };
                    popControl1.RemoveDefaultColName = new string[] {"AZFS", "LX", "KZDSL" };
                    popControl1.bind();
                    break;
                case "AZFS":

                    strString = new StringBuilder(" XT='火灾自动报警' and AZFS is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", currRow["DXZZXZ"]));

                    HZZDBJBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(HZZDBJBindingSource, "AZFS");

                    popControl1.ColName = new string[] { "安装方式|AZFS|AZFS" };
                    popControl1.RemoveDefaultColName = new string[] { "LX", "KZDSL" };
                    popControl1.bind();
                    break;
                case "LX":

                    strString = new StringBuilder(" XT='火灾自动报警' and LX is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", currRow["DXZZXZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", currRow["AZFS"]));

                    HZZDBJBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(HZZDBJBindingSource, "LX");

                    popControl1.ColName = new string[] { "类型|LX|LX" };
                    popControl1.RemoveDefaultColName = new string[] { "KZDSL" };
                    popControl1.bind();
                    break;
                case "KZDSL":

                    strString = new StringBuilder(" XT='火灾自动报警' and KZD is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", currRow["DXZZXZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", currRow["AZFS"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["LX"])) ? " and LX is null" : string.Format(" and  LX = '{0}'", currRow["LX"]));

                    HZZDBJBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(HZZDBJBindingSource, "KZD");

                    popControl1.ColName = new string[] { "控制点数量|KZD|KZDSL" };
                    popControl1.bind();
                    break;
                case "CZGD":
                    this.GDSZBindingSource.Filter = string.Format("SYFW ='消防' and BTMS ='操作高度'");
                    popControl1.DataSource = RemoveRepeat(GDSZBindingSource, "GD");
                    popControl1.ColName = new string[] { "操作高度|GD|CZGD" };
                    popControl1.bind();
                    break;
            }
        }


        #region 下拉值选择后触发事件
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;


            //当可以确定唯一清单时   修正当前行单位
            StringBuilder strString = new StringBuilder(" XT='自动报警'");
            strString.Append(string.IsNullOrEmpty(toString(drCurrent["MC"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["MC"]));
            this.XFQDQDBindingSource.Filter = strString.ToString();
            if (0 < XFQDQDBindingSource.Count)
            {
                DataRowView view = this.XFQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        #endregion
        //必填项验证
        private void checkeArr()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //判断是否已添加数据行
            if (currRow != null)
            {
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                checkMess.Add("名称");
                CheckColl.Add("MC");
                //点击确定清单前   判断必填项 

                StringBuilder strString = new StringBuilder(" XT='火灾自动报警'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]));

                HZZDBJBindingSource.Filter = strString.ToString();
                if (0 < HZZDBJBindingSource.Count)
                {
                    strString.Append(" and XZ is null");
                    this.HZZDBJBindingSource.Filter = strString.ToString();
                    if (1 > HZZDBJBindingSource.Count)
                    {
                        checkMess.Add("多线制、总线制");
                        CheckColl.Add("DXZZXZ");
                    }
                }
                strString = new StringBuilder(" XT='火灾自动报警'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", currRow["DXZZXZ"]));

                HZZDBJBindingSource.Filter = strString.ToString();
                if (0 < HZZDBJBindingSource.Count)
                {
                    strString.Append(" and AZFS is null");
                    this.HZZDBJBindingSource.Filter = strString.ToString();
                    if (1 > HZZDBJBindingSource.Count)
                    {
                        checkMess.Add("安装方式");
                        CheckColl.Add("AZFS");
                    }
                }
                strString = new StringBuilder(" XT='火灾自动报警'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", currRow["DXZZXZ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", currRow["AZFS"]));

                HZZDBJBindingSource.Filter = strString.ToString();
                if (0 < HZZDBJBindingSource.Count)
                {
                    strString.Append(" and LX is null");
                    this.HZZDBJBindingSource.Filter = strString.ToString();
                    if (1 > HZZDBJBindingSource.Count)
                    {
                        checkMess.Add("类型");
                        CheckColl.Add("LX");
                    }
                }
                strString = new StringBuilder(" XT='火灾自动报警'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["MC"])) ? " and MC is null" : string.Format(" and  MC = '{0}'", currRow["MC"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["DXZZXZ"])) ? " and XZ is null" : string.Format(" and  XZ = '{0}'", currRow["DXZZXZ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", currRow["AZFS"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["LX"])) ? " and LX is null" : string.Format(" and  LX = '{0}'", currRow["LX"]));

                HZZDBJBindingSource.Filter = strString.ToString();
                if (0 < HZZDBJBindingSource.Count)
                {
                    strString.Append(" and KZD is null");
                    this.HZZDBJBindingSource.Filter = strString.ToString();
                    if (1 > HZZDBJBindingSource.Count)
                    {
                        checkMess.Add("控制点数量");
                        CheckColl.Add("KZDSL");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}