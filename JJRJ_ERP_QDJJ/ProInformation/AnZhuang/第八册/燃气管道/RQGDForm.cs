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
using DevExpress.XtraGrid;
using ZiboSoft.Commons.Common;
using System.Text.RegularExpressions;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class RQGDForm : BaseUI
    {
        public RQGDForm()
        {
            InitializeComponent();
        }

        private void RQGDForm_Load(object sender, EventArgs e)
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
                ArrCheckColl = new string[] { "AZBW", "CZ", "LJFS", "GG" };
                ArrCheckMess = new string[] { "安装部位", "材质", "连接方式", "规格" };
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.燃气管道;
            this.InfTable.燃气管道.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QDGDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["确定管道定额"];
            this.TGGGFWBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["套管规格范围"];
            this.GCZJZHBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["公称直径转换"];
            this.FFSYCXBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["防腐刷油_除锈"];

            this.BWJRGCBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["保温绝热工程"];
            this.BWJRGCBindingSource.DataSource = SplitDataFW(BWJRGCBindingSource, "SBZJ", "MaxSBZJ", "MinSBZJ", '～');

            this.QTGPSQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["其他给排水确定定额"];
            this.GPSQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["给排水确定清单"];
            this.GDSZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
            this.GDXDCXBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["管道消毒冲洗"];
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
                    string strQDWhere = string.Format("CZ like '%,{0},%'", toString(drCurrent["CZ"]));
                    this.GPSQDQDBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.GPSQDQDBindingSource.Count)
                    {
                        DataRowView view = this.GPSQDQDBindingSource[0] as DataRowView;
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
                    this.GPSQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    #region 管道消毒冲洗

                    //获取规格对应的公称直径
                    GCZJZHBindingSource.Filter = string.Format(" YSGG = '{0}'", drCurrent["GG"]);
                    DataRowView drvGczj = GCZJZHBindingSource.Current as DataRowView;
                    decimal gczj = drvGczj == null ? -1 : decimal.Parse(toString(drvGczj["GCZJ"]));
                    decimal jszj = drvGczj == null ? 0 : decimal.Parse(toString(drvGczj["JSZJ"]));

                    if ("管道间、管廊内".Equals(toString(drCurrent["CZBW"])))
                    {
                        if (gczj != -1)
                        {
                            GDXDCXBindingSource.Filter = "FL like '%,管道压力试验,%' ";
                            foreach (DataRowView item in GDXDCXBindingSource)
                            {
                                //根据公称直径所在规格型号范围获取定额
                                if (!string.IsNullOrEmpty(toString(item["GGXH"])))
                                {
                                    string[] ggxh = toString(item["GGXH"]).Split('～');
                                    if (ggxh.Length == 2
                                        && ToolKit.ParseDecimal(ggxh[0]) <= ToolKit.ParseDecimal(gczj)
                                        && ToolKit.ParseDecimal(ggxh[1]) >= ToolKit.ParseDecimal(gczj))
                                    {
                                        DataRow row = APP.UnInformation.DETable.NewRow();
                                        row["DEBH"] = item["DEBH"];
                                        row["DEMC"] = item["DEMC"];
                                        row["DW"] = item["DEDW"];
                                        if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                                            row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                                        else
                                            row["XS"] = item["GCLXS"];
                                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                        row["QDBH"] = dr["QDBH"];
                                        row["TJ"] = strTJ;
                                        row["WZLX"] = WZLX.分部分项;
                                        rows.Add(row);
                                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 确定管道定额

                    string strDEWhere = string.Format("AZBW like '%,{0},%' and SSJZ like '%,燃气,%' and CZ like '%,{1},%' and LJFS='{2}' and GG like '%,{3},%'"
                                                        , drCurrent["AZBW"], drCurrent["CZ"], drCurrent["LJFS"], drCurrent["GG"]);

                    this.QDGDDEBindingSource.Filter = strDEWhere;
                    DataRowView drv = QDGDDEBindingSource.Current as DataRowView;

                    foreach (DataRowView item in this.QDGDDEBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        string debh = toString(item["DEBH"]);

                        //根据高度设置的《系数》   修改定额编号
                        this.GDSZBindingSource.Filter = string.Format("SYFW='给排水' and GD ='{0}' or GD ='{1}'", drCurrent["CZBW"], drCurrent["CZGD"]);
                        foreach (DataRowView gdszItem in this.GDSZBindingSource)
                        {
                            if (gdszItem != null && !string.IsNullOrEmpty(toString(gdszItem["XS"])))
                            {
                                if (!debh.Contains(' '))
                                    debh = debh + " " + toString(gdszItem["XS"]);
                                else
                                    debh = debh + toString(gdszItem["XS"]).Substring(1, toString(gdszItem["XS"]).Length - 1);
                            }
                        }
                        row["DEBH"] = debh;
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["ZCMCTH"] = toString(item["CZ"]) + toString(item["GG"]);
                        if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                            row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        else
                            row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    #region 其他给排水确定定额
                    if (gczj != -1)
                    {
                        this.QTGPSQDDEBindingSource.Filter = string.Format("TGCZ ='{0}'",drCurrent["TGCZ"]);
                        foreach (DataRowView item in QTGPSQDDEBindingSource)
                        {

                            
                            //根据公称直径所在规格范围获取定额
                            if (!string.IsNullOrEmpty(toString(item["GGFW"])))
                            {
                                string[] ggfw = toString(item["GGFW"]).Split('～');
                                if (ggfw.Length == 2
                                    && ToolKit.ParseDecimal(ggfw[0]) <= ToolKit.ParseDecimal(gczj)
                                    && ToolKit.ParseDecimal(ggfw[1]) >= ToolKit.ParseDecimal(gczj))
                                {
                                    DataRow row = APP.UnInformation.DETable.NewRow();
                                    row["DEBH"] = item["DEBH"];
                                    row["DEMC"] = item["DEMC"];
                                    row["DW"] = item["DEDW"];
                                    if ("G".Equals(toString(item["GCLXS"])))
                                    {
                                        row["GCL"] = drCurrent["TGGS"];
                                        row["XS"] = ToolKit.ParseDecimal(ToolKit.ParseDecimal(drCurrent["TGGS"].ToString()) / ToolKit.ParseDecimal(dr["GCL"]));
                                    }
                                    else if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                                    {
                                        row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                    }
                                    else
                                    {
                                        row["XS"] = item["GCLXS"];
                                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                    }
                                    row["QDBH"] = dr["QDBH"];
                                    row["TJ"] = strTJ;
                                    row["WZLX"] = WZLX.分部分项;
                                    rows.Add(row);
                                    sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                                }
                            }
                        }
                    }
                    #endregion

                    #region 防腐刷油、除锈
                    FFSYCXBindingSource.Filter = string.Format("FL = '除锈工程' and BW ='管道' and LX='{0}'", drCurrent["CX"]);
                    foreach (DataRowView item in this.FFSYCXBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                            row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        else
                            row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }
                    FFSYCXBindingSource.Filter = string.Format("FL = '防腐刷油工程' and (BW ='管道刷油' or BW ='管道刷油') and LX='{0}'", drCurrent["BWQFFSYYQ"]);
                    foreach (DataRowView item in this.FFSYCXBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        if (!string.IsNullOrEmpty(toString(item["BWQXS"])) && (toString(item["BWQXS"]).Contains('Φ') || toString(item["BWQXS"]).Contains("HD")))
                            row["XS"] = Math.Round(ToolKit.Calculate(toString(item["BWQXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        else
                            row["XS"] = item["BWQXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }
                    FFSYCXBindingSource.Filter = string.Format("FL = '防腐刷油工程' and (BW ='管道刷油' or BW ='管道刷油')  and LX='{0}'", drCurrent["BWHFFSYYQ"]);
                    foreach (DataRowView item in this.FFSYCXBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        if (!string.IsNullOrEmpty(toString(item["BWHXS"])) && (toString(item["BWHXS"]).Contains('Φ') || toString(item["BWHXS"]).Contains("HD")))
                            row["XS"] = Math.Round(ToolKit.Calculate(toString(item["BWHXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        else
                            row["XS"] = item["BWHXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    #region 保温绝热工程

                    StringBuilder strString = new StringBuilder(" BWLB ='保温层' and BWFL ='管道' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["BWJRCLZL"])) ? " and JRCL is null" : string.Format(" and  JRCL = '{0}'", drCurrent["BWJRCLZL"]));

                    strString.Append(" and (( SBZJ is null and JRHD is null)");
                    strString.Append(" or ( JRHD is null ")
                             .Append(jszj == -1 ? " and  MaxSBZJ is null" : string.Format(" and  MaxSBZJ>={0}", jszj))
                             .Append(jszj == -1 ? "  and MinSBZJ is null" : string.Format(" and MinSBZJ<={0})", jszj));
                    strString.Append(" or ( SBZJ is null and JRHD is not null)");

                    strString.Append(jszj == -1 ? " or (MaxSBZJ is null" : string.Format(" or (MaxSBZJ>={0}", jszj))
                             .Append(jszj == -1 ? "  and MinSBZJ is null" : string.Format(" and MinSBZJ<={0}))", jszj));


                    this.BWJRGCBindingSource.Filter = strString.ToString();
                    foreach (DataRowView item in this.BWJRGCBindingSource)
                    {
                        if (!string.IsNullOrEmpty(toString(item["JRHD"])))
                        {
                            string[] ggfw = toString(item["JRHD"]).Split('～');
                            if (ggfw.Length == 2
                                && ToolKit.ParseDecimal(ggfw[0]) <= ToolKit.ParseDecimal(drCurrent["BWHD"])
                                && ToolKit.ParseDecimal(ggfw[1]) >= ToolKit.ParseDecimal(drCurrent["BWHD"]))
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                                    row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                                else
                                    row["XS"] = item["GCLXS"];
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                row["WZLX"] = WZLX.分部分项;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                            }
                        }
                        else
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                                row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                            else
                                row["XS"] = item["GCLXS"];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                        }
                    }
                    this.BWJRGCBindingSource.Filter = string.Format("BWLB='防潮层、保护层' and BWFL='管道' and JRCL='{0}'"
                                                                    , drCurrent["FCCBHCCL"]);
                    foreach (DataRowView item in this.BWJRGCBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                            row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        else
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
            string strKey =  "项目特征,工程内容" ;
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(toString(drCurrent["AZBW"])))
            {
                strContent += "\r\n" + (++i) + ".安装部位：" + drCurrent["AZBW"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZ"])))
            {
                strContent += "\r\n" + (++i) + ".材质：" + drCurrent["CZ"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["GG"])))
            {
                strContent += "\r\n" + (++i) + ".规格：" + drCurrent["GG"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["LJFS"])))
            {
                strContent += "\r\n" + (++i) + ".连接形式：" + drCurrent["LJFS"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZBW"])))
            {
                strContent += "\r\n" + (++i) + ".操作部位：" + drCurrent["CZBW"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZGD"])))
            {
                strContent += "\r\n" + (++i) + ".操作高度：" + drCurrent["CZGD"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["TGCZ"])))
            {
                strContent += "\r\n" + (++i) + ".套管材质：" + drCurrent["TGCZ"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CX"])))
            {
                strContent += "\r\n" + (++i) + ".管道除锈：" + drCurrent["CX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWQFFSYYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温前防腐、刷油要求：" + drCurrent["BWQFFSYYQ"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["BWJRCLZL"])))
            {
                strContent += "\r\n" + (++i) + ".保温绝热材料种类：" + drCurrent["BWJRCLZL"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["BWHD"])))
            {
                strContent += "\r\n" + (++i) + ".保温厚度：" + drCurrent["BWHD"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["FCCBHCCL"])))
            {
                strContent += "\r\n" + (++i) + ".防潮层、保护层：" + drCurrent["FCCBHCCL"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["BWHFFSYYQ"])))
            {
                strContent += "\r\n" + (++i) + ".保温后防腐、刷油要求：" + drCurrent["BWHFFSYYQ"];
            }
            int ii = 0;
            strContent += "\r\n" + "【工程内容】";
            strContent += "\r\n" + (++ii) + ".管道、管件及弯管的制作安装";
            strContent += "\r\n" + (++ii) + ".套管的制作安装";
            if (!string.IsNullOrEmpty(toString(drCurrent["CZ"]))&&
                (toString(drCurrent["CZ"]).Equals("采暖") 
                || toString(drCurrent["CZ"]).Equals("给水")))
            {
                strContent += "\r\n" + (++ii) + ".管道消毒、冲洗";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZ"])) 
                && !string.IsNullOrEmpty(toString(drCurrent["AZBW"]))
                && !string.IsNullOrEmpty(toString(drCurrent["CZBW"]))
                && (toString(drCurrent["CZ"]).Equals("采暖")
                || toString(drCurrent["CZ"]).Equals("给水")
                || toString(drCurrent["AZBW"]).Equals("埋地")
                || toString(drCurrent["CZBW"]).Equals("管道间")
                || toString(drCurrent["CZBW"]).Equals("管廊内")))
            {
                strContent += "\r\n" + (++ii) + ".管道水压及泄漏试验";
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
            this.repositoryItemSpinEdit1.MaxValue = 999999999999;
            this.repositoryItemSpinEdit1.MinValue = 0;

            switch (e.Column.FieldName)
            {
                case "AZBW":

                    DataTable dt = new DataTable();
                    dt.Columns.Add("AZBW", typeof(string));
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    dr1["AZBW"] = "室外";
                    dr2["AZBW"] = "室内";
                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);
                    popControl1.DataSource = dt;

                    popControl1.ColName = new string[] { "安装部位|AZBW|AZBW" };
                    popControl1.RemoveDefaultColName = new string[] { "CZ", "LJFS", "GG" };
                    popControl1.bind();
                    break;
                case "CZ":

                    this.QDGDDEBindingSource.Filter = string.Format("AZBW like '%,{0},%' and SSJZ like '%,燃气,%'", currRow["AZBW"]);
                    popControl1.DataSource = RemoveRepeat(strToTable(QDGDDEBindingSource, "CZ", ','), "CZ");

                    popControl1.ColName = new string[] { "材质|CZ|CZ" };
                    popControl1.RemoveDefaultColName = new string[] { "LJFS", "GG" };
                    popControl1.bind();
                    break;
                case "LJFS":

                    this.QDGDDEBindingSource.Filter = string.Format("AZBW like '%,{0},%' and SSJZ like '%,燃气,%' and CZ like '%,{1},%'", currRow["AZBW"], currRow["CZ"]);
                    popControl1.DataSource = RemoveRepeat(QDGDDEBindingSource, "LJFS");

                    popControl1.ColName = new string[] { "连接方式|LJFS|LJFS" };
                    popControl1.RemoveDefaultColName = new string[] { "GG" };
                    popControl1.bind();
                    break;
                case "GG":
                    this.QDGDDEBindingSource.Filter = string.Format("AZBW like '%,{0},%' and SSJZ like '%,燃气,%' and CZ like '%,{1},%' and LJFS='{2}'"
                                                        , currRow["AZBW"], currRow["CZ"], currRow["LJFS"]);

                    popControl1.DataSource = RemoveRepeat(strToTable(QDGDDEBindingSource,"GG",','), "GG");
                    popControl1.ColName = new string[] { "规格|GG|GG" };
                    popControl1.RemoveDefaultColName = new string[] { "TGCZ", "BWHD" };
                    popControl1.bind();
                    break;
                case "CZBW":
                    this.GDSZBindingSource.Filter = string.Format("SYFW ='给排水' and BTMS ='操作部位'");
                    popControl1.DataSource = RemoveRepeat(this.GDSZBindingSource, "GD");
                    popControl1.ColName = new string[] { "操作部位|GD|CZBW" };
                    popControl1.bind();
                    break;
                case "CZGD":
                    this.GDSZBindingSource.Filter = string.Format("SYFW ='给排水' and BTMS ='操作高度'");
                    popControl1.DataSource = RemoveRepeat(this.GDSZBindingSource, "GD");
                    popControl1.ColName = new string[] { "操作高度|GD|CZGD" };
                    popControl1.bind();
                    break;
                case "TGCZ":

                    //获取公称直径  即下方使用的 规格范围-GGFW
                    this.GCZJZHBindingSource.Filter = string.Format("YSGG='{0}'",currRow["GG"]);
                    DataRowView drv = GCZJZHBindingSource.Current as DataRowView;
                    string gczj = toString(drv == null ? null : drv["GCZJ"]);


                    //获取TGCZ
                    TGGGFWBindingSource.Filter="";
                    string tgcz = "";
                    foreach(DataRowView item in TGGGFWBindingSource)
                    {
                        if (!string.IsNullOrEmpty(toString(item["GGFW"])))
                        {
                            string[] ggfw = toString(item["GGFW"]).Split('～');
                            if (ggfw.Length == 2
                                && ToolKit.ParseDecimal(ggfw[0]) <= ToolKit.ParseDecimal(gczj)
                                && ToolKit.ParseDecimal(ggfw[1]) >= ToolKit.ParseDecimal(gczj))
                            {
                                tgcz += toString(item["TGCZ"]);
                            }
                        }
                    }
                    //绑定控件
                    popControl1.DataSource = strToTable(tgcz, "TGCZ");

                    popControl1.ColName = new string[] { "套管材质|TGCZ|TGCZ" };
                    popControl1.bind();
                    break;
                case "CX":
                    popControl1.DataSource = null;
                    if ("焊接钢管".Equals(currRow["CZ"]) || "无缝钢管".Equals(currRow["CZ"]))
                    {
                        this.FFSYCXBindingSource.Filter = string.Format("FL ='除锈工程' and BW ='管道'");
                        popControl1.DataSource = RemoveRepeat(this.FFSYCXBindingSource, "LX");
                        popControl1.ColName = new string[] { "除锈|LX|CX" };
                        popControl1.bind();
                    }
                    break;
                case "BWQFFSYYQ":
                    popControl1.DataSource = null;
                    if ("焊接钢管".Equals(currRow["CZ"]) || "无缝钢管".Equals(currRow["CZ"]))
                    {
                        this.FFSYCXBindingSource.Filter = string.Format("FL ='防腐刷油工程' and (BW ='管道刷油' or BW ='管道防腐')");
                        popControl1.DataSource = RemoveRepeat(this.FFSYCXBindingSource, "LX");
                        popControl1.ColName = new string[] { "保温前防腐刷油要求|LX|BWQFFSYYQ" };
                        popControl1.bind();
                        break;
                    }
                    break;
                case "BWJRCLZL":
                    this.BWJRGCBindingSource.Filter = string.Format("FL ='保温绝热工程' and BWLB ='保温层' and BWFL='管道'");
                    popControl1.DataSource = RemoveRepeat(this.BWJRGCBindingSource, "JRCL");
                    popControl1.ColName = new string[] { "保温绝热材料种类|JRCL|BWJRCLZL" };
                    popControl1.bind();
                    break;
                case "BWHD":
                    //获取计算直径  即设备直径
                    this.GCZJZHBindingSource.Filter = string.Format("YSGG = '{0}'", currRow["GG"]);
                    DataRowView sjzj = GCZJZHBindingSource.Current as DataRowView;
                    decimal sbzj = sjzj == null ? -1 : ToolKit.ParseDecimal(sjzj["JSZJ"]);

                    this.BWJRGCBindingSource.Filter = string.Format("FL='保温绝热工程' and BWLB ='保温层' and BWFL ='管道' and JRCL='{0}' and ((MaxSBZJ>={1} and MinSBZJ<={1} ) or SBZJ is null)", currRow["BWJRCLZL"], sbzj);

                    //获取保温厚度范围
                    decimal minValue = 0;
                    decimal maxValue = 0;
                    int i = 0;
                    foreach (DataRowView item in BWJRGCBindingSource)
                    {
                        if (item != null && item["JRHD"] != null)
                        {
                            string[] jrhd = toString(item["JRHD"]).Split('～');
                            if (jrhd.Length == 2)
                            {
                                if (i == 0)
                                {
                                    minValue = decimal.Parse(jrhd[0]);
                                    maxValue = decimal.Parse(jrhd[1]);
                                    i++;
                                }
                                if (decimal.Parse(jrhd[0]) <= minValue)
                                    minValue = decimal.Parse(jrhd[0]);
                                if (decimal.Parse(jrhd[1]) >= maxValue)
                                    maxValue = decimal.Parse(jrhd[1]);
                            }
                        }
                    }
                    this.repositoryItemSpinEdit1.MaxValue = maxValue;
                    this.repositoryItemSpinEdit1.MinValue = minValue;
                    break;
                case "FCCBHCCL":
                    this.BWJRGCBindingSource.Filter = string.Format("FL ='保温绝热工程' and BWLB ='防潮层、保护层' and BWFL='管道'");
                    popControl1.DataSource = RemoveRepeat(this.BWJRGCBindingSource, "JRCL");
                    popControl1.ColName = new string[] { "防潮层保护层材料|JRCL|FCCBHCCL" };
                    popControl1.bind();
                    break;
                case "BWHFFSYYQ":
                    if ("焊接钢管".Equals(currRow["CZ"]) || "无缝钢管".Equals(currRow["CZ"]))
                    {
                        this.FFSYCXBindingSource.Filter = string.Format("FL ='防腐刷油工程' and (BW ='管道刷油' or BW ='管道防腐')");
                        popControl1.DataSource = RemoveRepeat(this.FFSYCXBindingSource, "LX");
                        popControl1.ColName = new string[] { "保温后防腐刷油要求|LX|BWHFFSYYQ" };
                        popControl1.bind();
                    }
                    break;
            }
        }

        
        #region 下拉值选择后触发事件
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;

            if (!toString(drCurrent["CZ"]).Equals("焊接钢管")
                && !toString(drCurrent["CZ"]).Equals("无缝钢管")
                )
            {
                drCurrent["CX"] = "";
                drCurrent["BWQFFSYYQ"] = "";
                drCurrent["BWHFFSYYQ"] = "";
                this.gridView1.Columns["CX"].OptionsColumn.AllowEdit = false;
                this.gridView1.Columns["BWQFFSYYQ"].OptionsColumn.AllowEdit = false;
                this.gridView1.Columns["BWHFFSYYQ"].OptionsColumn.AllowEdit = false;
            }
            else
            {
                this.gridView1.Columns["CX"].OptionsColumn.AllowEdit = true;
                this.gridView1.Columns["BWQFFSYYQ"].OptionsColumn.AllowEdit = true;
                this.gridView1.Columns["BWHFFSYYQ"].OptionsColumn.AllowEdit = true; 
            }

            //当可以确定唯一清单时   修正当前行单位
            string strQDWhere = string.Format("CZ  like '%,{0},%'", toString(drCurrent["CZ"]));
            this.GPSQDQDBindingSource.Filter = strQDWhere;
            if (0 < GPSQDQDBindingSource.Count)
            {
                DataRowView view = this.GPSQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        #endregion
    }
}