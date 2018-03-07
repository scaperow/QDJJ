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
    public partial class FMZZAZForm : BaseUI
    {
        public FMZZAZForm()
        {
            InitializeComponent();
        }

        private void FMZZAZForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.风帽制作安装;
            this.InfTable.风帽制作安装.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.TFKTQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["通风空调确定定额"];
            this.AZQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["安装确定清单"];
            this.GDSZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
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
            //必填性验证
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
                    string strQDWhere = string.Format("MC like '%{0}%'", drCurrent["CZ"]);
                    this.AZQDQDBindingSource.Filter = strQDWhere;
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

                    StringBuilder strString = new StringBuilder(" LB = '风帽'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["CZ"])) ? " and MC is null" : string.Format(" and MC='{0}'", drCurrent["CZ"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["XZ"])) ? " and LX is null" : string.Format(" and LX='{0}'", drCurrent["XZ"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GG"])) ? " and GGXH is null" : string.Format(" and GGXH='{0}'", drCurrent["GG"]));

                    this.TFKTQDDEBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.TFKTQDDEBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        this.GDSZBindingSource.Filter = " SYFW = '通风空调' and BTMS='距楼地面'";
                        DataRowView drvGdsz = GDSZBindingSource.Current as DataRowView;
                        row["DEBH"] = drvGdsz == null ? item["DEBH"] : toString(item["DEBH"]) + " " + toString(drvGdsz["XS"]);
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
            if (!string.IsNullOrEmpty(drCurrent["CZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".风帽材质：" + drCurrent["CZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["XZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".形状：" + drCurrent["XZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格：" + drCurrent["GG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZGD"].ToString()))
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
            StringBuilder strString = null;
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "CZ":
                    this.TFKTQDDEBindingSource.Filter = " LB = '风帽' and MC is not null";
                    popControl1.DataSource = RemoveRepeat(TFKTQDDEBindingSource, "MC");

                    popControl1.ColName = new string[] { "材质|MC|CZ" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "XZ", "GG" };
                    popControl1.bind();
                    break;
                case "XZ":
                    strString = new StringBuilder(" LB = '风帽'");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["CZ"])) ? " and MC is null" : string.Format(" and MC='{0}'", currRow["CZ"]))
                             .Append(" and LX is not null");
                    this.TFKTQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(TFKTQDDEBindingSource, "LX");

                    popControl1.ColName = new string[] { "形状|LX|XZ" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GG" };
                    popControl1.bind();
                    break;
                case "GG":
                    strString = new StringBuilder(" LB = '风帽'");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["CZ"])) ? " and MC is null" : string.Format(" and MC='{0}'", currRow["CZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and LX is null" : string.Format(" and LX='{0}'", currRow["XZ"]))
                             .Append(" and GGXH is not null");
                    this.TFKTQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(TFKTQDDEBindingSource, "GGXH");

                    popControl1.ColName = new string[] { "规格|GGXH|GG" };
                    popControl1.bind();
                    break;
                case "CZGD":
                    this.GDSZBindingSource.Filter = " SYFW = '通风空调' and BTMS='距楼地面' and GD is not null";
                    popControl1.DataSource = RemoveRepeat(GDSZBindingSource, "GD");

                    popControl1.ColName = new string[] { "操作高度|GD|CZGD" };
                    popControl1.bind();
                    break;
            }
        }

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;

            //当可以确定唯一清单时   修正当前行单位
            string strQDWhere = string.Format("MC like '%{0}%'", drCurrent["CZ"]);
            this.AZQDQDBindingSource.Filter = strQDWhere;
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
            StringBuilder strString = null;
            //判断是否已添加数据行
            if (currRow != null)
            {
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                //点击确定清单前   判断必填项
                this.TFKTQDDEBindingSource.Filter = " LB = '风帽'";
                if (0 < TFKTQDDEBindingSource.Count)
                {
                    this.TFKTQDDEBindingSource.Filter = " LB = '风帽' and MC is null";
                    if (1 > TFKTQDDEBindingSource.Count)
                    {
                        checkMess.Add("材质");
                        CheckColl.Add("CZ");
                    }
                }
                strString = new StringBuilder(" LB = '风帽'");

                strString.Append(string.IsNullOrEmpty(toString(currRow["CZ"])) ? " and MC is null" : string.Format(" and MC='{0}'", currRow["CZ"]));
                TFKTQDDEBindingSource.Filter = strString.ToString();
                if (0 < TFKTQDDEBindingSource.Count)
                {
                    strString.Append(" and LX is null");
                    this.TFKTQDDEBindingSource.Filter = strString.ToString();
                    if (1 > TFKTQDDEBindingSource.Count)
                    {
                        checkMess.Add("形状");
                        CheckColl.Add("XZ");
                    }
                }
                strString = new StringBuilder(" LB = '风帽'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["CZ"])) ? " and MC is null" : string.Format(" and MC='{0}'", currRow["CZ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and LX is null" : string.Format(" and LX='{0}'", currRow["XZ"]));
                this.TFKTQDDEBindingSource.Filter = strString.ToString();
                if (0 < TFKTQDDEBindingSource.Count)
                {
                    strString.Append(" and GGXH is null");
                    this.TFKTQDDEBindingSource.Filter = strString.ToString();
                    if (1 > TFKTQDDEBindingSource.Count)
                    {
                        checkMess.Add("规格");
                        CheckColl.Add("GG");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}