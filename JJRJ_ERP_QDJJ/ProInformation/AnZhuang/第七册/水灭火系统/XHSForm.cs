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
    public partial class XHSForm : BaseUI
    {
        public XHSForm()
        {
            InitializeComponent();
        }

        private void XHSForm_Load(object sender, EventArgs e)
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
                ArrCheckColl = new string[] { "AZBW", "AZFS", "GGXH" };
                ArrCheckMess = new string[] { "安装部位", "安装方式", "规格、型号" };
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.消火栓;
            this.InfTable.消火栓.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.XHSBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["消火栓"];
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
                    StringBuilder strString = new StringBuilder(" XT='水灭火'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["AZBW"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["AZBW"]));
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

                    #region 管道安装
                    strString = new StringBuilder(" XT='水灭火'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["AZBW"])) ? " and AZBW is null" : string.Format(" and  AZBW = '{0}'", drCurrent["AZBW"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", drCurrent["AZFS"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GGXH"])) ? " and  GGXH is null" : string.Format("  and GGXH = '{0}'", drCurrent["GGXH"]));
                    this.XHSBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.XHSBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        string debh = toString(item["DEBH"]);

                        //根据高度设置的《系数》   修改定额编号

                        StringBuilder str_xs = new StringBuilder(" SYFW='消防' and BTMS='操作部位' ");// (BTMS='操作部位' or BTMS='操作高度')
                        str_xs.Append(string.IsNullOrEmpty(toString(drCurrent["CZGD"])) ? " and GD is null" : string.Format(" and GD = '{0}'", drCurrent["CZGD"]));
                        this.GDSZBindingSource.Filter = str_xs.ToString();
                        foreach (DataRowView gdszItem in this.GDSZBindingSource)
                        {
                            if (gdszItem != null && !string.IsNullOrEmpty(toString(gdszItem["XS"])))
                            {
                                debh = debh + " " + toString(gdszItem["XS"]);
                            }
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
            string strKey = "项目特征,工程内容";
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(toString(drCurrent["AZBW"])))
            {
                strContent += "\r\n" + (++i) + ".水灭火安装部位、类型：" + drCurrent["AZBW"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["AZFS"])))
            {
                strContent += "\r\n" + (++i) + ".安装方式：" + drCurrent["AZFS"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["GGXH"])))
            {
                strContent += "\r\n" + (++i) + ".规格、型号：" + drCurrent["GGXH"];
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
                case "AZBW":

                    this.XHSBindingSource.Filter = " XT='水灭火' and AZBW is not null";
                    //字符串截断并去重复
                    popControl1.DataSource = RemoveRepeat(this.XHSBindingSource, "AZBW");

                    popControl1.ColName = new string[] { "安装部位|AZBW|AZBW" };
                    popControl1.RemoveDefaultColName = new string[] { "AZFS", "GGXH" };
                    popControl1.bind();
                    break;
                case "AZFS":

                    strString = new StringBuilder(" XT='水灭火' and AZFS is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["AZBW"])) ? " and AZBW is null" : string.Format(" and  AZBW = '{0}'", currRow["AZBW"]));
                    this.XHSBindingSource.Filter = strString.ToString();
                    //字符串截断并去重复
                    popControl1.DataSource = RemoveRepeat(this.XHSBindingSource, "AZFS");

                    popControl1.ColName = new string[] { "安装方式|AZFS|AZFS" };
                    popControl1.RemoveDefaultColName = new string[] { "GGXH" };
                    popControl1.bind();
                    break;
                case "GGXH":

                    strString = new StringBuilder(" XT='水灭火' and GGXH is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["AZBW"])) ? " and AZBW is null" : string.Format(" and  AZBW = '{0}'", currRow["AZBW"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["AZFS"])) ? " and AZFS is null" : string.Format(" and  AZFS = '{0}'", currRow["AZFS"]));
                    this.XHSBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(XHSBindingSource, "GGXH");
                    popControl1.ColName = new string[] { "规格、型号|GGXH|GGXH" };
                    //popControl1.RemoveDefaultColName = new string[] { "BWHD" };
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
            StringBuilder strString = new StringBuilder(" XT='水灭火'");
            strString.Append(string.IsNullOrEmpty(toString(drCurrent["AZBW"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["AZBW"]));
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
                checkMess.Add("安装部位");
                CheckColl.Add("AZBW");
                //点击确定清单前   判断必填项  

                StringBuilder strString = new StringBuilder(" XT='水灭火'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["AZBW"])) ? " and AZBW is null" : string.Format(" and  AZBW = '{0}'", currRow["AZBW"]));

                this.XHSBindingSource.Filter = strString.ToString();
                if (0 < XHSBindingSource.Count)
                {
                    strString.Append("  and AZFS is null");
                    this.XHSBindingSource.Filter = strString.ToString();
                    if (1 > XHSBindingSource.Count)
                    {
                        checkMess.Add("安装方式");
                        CheckColl.Add("AZFS");
                    }
                }
                checkMess.Add("规格、型号");
                CheckColl.Add("GGXH");
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}