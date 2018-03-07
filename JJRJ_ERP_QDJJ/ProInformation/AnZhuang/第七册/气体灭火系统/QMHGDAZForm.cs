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
    public partial class QMHGDAZForm : BaseUI
    {
        public QMHGDAZForm()
        {
            InitializeComponent();
        }

        private void QMHGDAZForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.气灭火管道安装;
            this.InfTable.气灭火管道安装.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.GCZJZHBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["公称直径转换"];
            this.FFSYCXBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["防腐刷油_除锈"];

            this.BWJRGCBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["保温绝热工程"];
            this.BWJRGCBindingSource.DataSource = SplitDataFW(BWJRGCBindingSource, "SBZJ", "MaxSBZJ", "MinSBZJ", '～');

            this.GDAZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["管道安装"];
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
                    StringBuilder strString = new StringBuilder(" XT='气体灭火'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["CZLX"])) ? " and  CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["CZLX"]));
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
                    //获取规格对应的公称直径
                    GCZJZHBindingSource.Filter = string.Format(" YSGG = '{0}'", drCurrent["GGXH"]);
                    DataRowView drvGczj = GCZJZHBindingSource.Current as DataRowView;
                    decimal gczj = drvGczj == null ? -1 : decimal.Parse(toString(drvGczj["GCZJ"]));
                    decimal jszj = drvGczj == null ? -1 : decimal.Parse(toString(drvGczj["JSZJ"]));

                    #region 管道安装
                    strString = new StringBuilder(" XT='气体灭火' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["CZLX"])) ? " and  CZLX is null" : string.Format(" and  CZLX like '%,{0},%'", drCurrent["CZLX"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["LJFS"])) ? " and  LJFS is null" : string.Format("  and LJFS = '{0}'", drCurrent["LJFS"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GGXH"])) ? " and  GGXH is null" : string.Format("  and GGXH = '{0}'", drCurrent["GGXH"]));
                    this.GDAZBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.GDAZBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        string debh = toString(item["DEBH"]);

                        //根据高度设置的《系数》   修改定额编号

                        StringBuilder str_xs = new StringBuilder(" SYFW='消防' ");// (BTMS='操作部位' or BTMS='操作高度')
                        str_xs.Append(string.IsNullOrEmpty(toString(drCurrent["CZGD"])) ? " and (BTMS='操作高度' or BTMS='操作部位') and GD is null" : string.Format(" and (BTMS='操作高度' or BTMS='操作部位') and GD = '{0}'", drCurrent["CZGD"]));
                        this.GDSZBindingSource.Filter = str_xs.ToString();
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

                    #region 保温绝热工程
                    if (gczj != -1)
                    {
                        strString = new StringBuilder(" BWLB ='保温层' and BWFL ='管道' ");
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
                    }
                    strString = new StringBuilder(" BWLB ='防潮层、保护层' and BWFL ='管道' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["FCCBHCCL"])) ? " and JRCL is null" : string.Format(" and  JRCL = '{0}'", drCurrent["FCCBHCCL"]));
                    this.BWJRGCBindingSource.Filter = strString.ToString();

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

                    #region 防腐刷油、除锈

                    string[] ffsycx_filter = new string[2];
                    string[] bw_gclxs = new string[] { "BWQXS", "BWHXS" };

                    strString = new StringBuilder(" FL='防腐刷油工程' and (BW='管道防腐' or BW='管道刷油')");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["BWQFFSYYQ"])) ? " and  LX is null" : string.Format(" and  LX = '{0}'", drCurrent["BWQFFSYYQ"]));
                    ffsycx_filter[0] = strString.ToString();

                    strString = new StringBuilder(" FL='防腐刷油工程' and (BW='管道防腐' or BW='管道刷油')");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["BWHFFSYYQ"])) ? " and  LX is null" : string.Format(" and  LX = '{0}'", drCurrent["BWHFFSYYQ"]));
                    ffsycx_filter[1] = strString.ToString();

                    for (int i = 0; i < ffsycx_filter.Length; i++)
                    {
                        this.FFSYCXBindingSource.Filter = ffsycx_filter[i];
                        foreach (DataRowView item in FFSYCXBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            if (!string.IsNullOrEmpty(toString(item[bw_gclxs[i]])) && (toString(item[bw_gclxs[i]]).Contains('Φ') || toString(item[bw_gclxs[i]]).Contains("HD")))
                                row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                            else
                                row["XS"] = item[bw_gclxs[i]];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                        }
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
            if (!string.IsNullOrEmpty(toString(drCurrent["CZLX"])))
            {
                strContent += "\r\n" + (++i) + ".材质类型：" + drCurrent["CZLX"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["LJFS"])))
            {
                strContent += "\r\n" + (++i) + ".连接形式：" + drCurrent["LJFS"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["GGXH"])))
            {
                strContent += "\r\n" + (++i) + ".规格、型号：" + drCurrent["GGXH"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZGD"])))
            {
                strContent += "\r\n" + (++i) + ".操作高度：" + drCurrent["CZGD"];
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
                case "CZLX":

                    this.GDAZBindingSource.Filter = " XT='气体灭火' and CZLX is not null";
                    //字符串截断并去重复
                    popControl1.DataSource = RemoveRepeat(strToTable(this.GDAZBindingSource, "CZLX", ','), "CZLX");

                    popControl1.ColName = new string[] { "材质类型|CZLX|CZLX" };
                    popControl1.RemoveDefaultColName = new string[] { "LJFS", "GGXH", "BWHD" };
                    popControl1.bind();
                    break;
                case "LJFS":

                    strString = new StringBuilder(" XT='气体灭火' and LJFS is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["CZLX"])) ? " and CZLX is null" : string.Format(" and  CZLX like '%,{0},%'", currRow["CZLX"]));

                    GDAZBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(GDAZBindingSource, "LJFS");

                    popControl1.ColName = new string[] { "连接方式|LJFS|LJFS" };
                    popControl1.RemoveDefaultColName = new string[] {  "GGXH", "BWHD" };
                    popControl1.bind();
                    break;
                case "GGXH":

                    strString = new StringBuilder(" XT='气体灭火' and GGXH is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["CZLX"])) ? " and CZLX is null" : string.Format(" and  CZLX like '%,{0},%'", currRow["CZLX"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["LJFS"])) ? " and LJFS is null" : string.Format(" and  LJFS = '{0}'", currRow["LJFS"]));
                    this.GDAZBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(GDAZBindingSource, "GGXH");
                    popControl1.ColName = new string[] { "规格、型号|GGXH|GGXH" };
                    popControl1.RemoveDefaultColName = new string[] { "BWHD" };
                    popControl1.bind();
                    break;
                case "CZGD":
                    this.GDSZBindingSource.Filter = string.Format("SYFW ='消防' and BTMS ='操作高度'");
                    popControl1.DataSource = RemoveRepeat(GDSZBindingSource, "GD");
                    popControl1.ColName = new string[] { "操作高度|GD|CZGD" };
                    popControl1.bind();
                    break;
                case "BWQFFSYYQ":
                    this.FFSYCXBindingSource.Filter = string.Format("FL ='防腐刷油工程' and (BW ='管道刷油' or BW ='管道防腐') and LX is not null");
                    popControl1.DataSource = RemoveRepeat(FFSYCXBindingSource, "LX");
                    popControl1.ColName = new string[] { "保温前防腐刷油要求|LX|BWQFFSYYQ" };
                    popControl1.bind();
                    break;
                case "BWJRCLZL":
                    this.BWJRGCBindingSource.Filter = string.Format("FL ='保温绝热工程' and BWLB ='保温层' and BWFL='管道' and JRCL is not null");
                    popControl1.DataSource = RemoveRepeat(BWJRGCBindingSource, "JRCL");
                    popControl1.ColName = new string[] { "保温绝热材料种类|JRCL|BWJRCLZL" };
                    popControl1.bind();
                    break;
                case "BWHD":
                    //获取计算直径  即设备直径
                    this.GCZJZHBindingSource.Filter = string.Format("YSGG = '{0}'", currRow["GGXH"]);
                    DataRowView sjzj = GCZJZHBindingSource.Current as DataRowView;
                    decimal sbzj = sjzj == null ? -1 : ToolKit.ParseDecimal(sjzj["JSZJ"]);

                    strString = new StringBuilder("FL='保温绝热工程' and BWLB ='保温层' and BWFL ='管道' and JRHD is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["BWJRCLZL"])) ? "  and JRCL is null" : string.Format(" and JRCL ='{0}'", currRow["BWJRCLZL"]))
                             .Append(sbzj == -1 ? " and  MaxSBZJ is null" : string.Format(" and  MaxSBZJ>={0}", sbzj))
                             .Append(sbzj == -1 ? "  and MinSBZJ is null" : string.Format(" and MinSBZJ<={0}", sbzj));

                    this.BWJRGCBindingSource.Filter = strString.ToString();
                    //获取保温厚度范围
                    decimal minValue = -1;
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
                    repositoryItemSpinEdit1.MaxValue = maxValue;
                    repositoryItemSpinEdit1.MinValue = minValue;
                    break;
                case "FCCBHCCL":
                    this.BWJRGCBindingSource.Filter = string.Format("FL ='保温绝热工程' and BWLB ='防潮层、保护层' and BWFL='管道' and JRCL is not null");
                    popControl1.DataSource = RemoveRepeat(BWJRGCBindingSource, "JRCL");
                    popControl1.ColName = new string[] { "防潮层保护层材料|JRCL|FCCBHCCL" };
                    popControl1.bind();
                    break;
                case "BWHFFSYYQ":
                    this.FFSYCXBindingSource.Filter = string.Format("FL ='防腐刷油工程' and (BW ='管道刷油' or BW ='管道防腐') and LX is not null");
                    popControl1.DataSource = RemoveRepeat(FFSYCXBindingSource, "LX");
                    popControl1.ColName = new string[] { "保温后防腐刷油要求|LX|BWHFFSYYQ" };
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
            StringBuilder strString = new StringBuilder(" XT='气体灭火'");
            strString.Append(string.IsNullOrEmpty(toString(drCurrent["CZLX"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["CZLX"]));
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
                checkMess.Add("材质类型");
                CheckColl.Add("CZLX");
                //点击确定清单前   判断必填项  

                StringBuilder
                    strString = new StringBuilder(" XT='气体灭火'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["CZLX"])) ? " and CZLX is null" : string.Format(" and  CZLX like '%,{0},%'", currRow["CZLX"]));

                this.GDAZBindingSource.Filter = strString.ToString();
                if (0 < GDAZBindingSource.Count)
                {
                    strString.Append("  and LJFS is null");
                    this.GDAZBindingSource.Filter = strString.ToString();
                    if (1 > GDAZBindingSource.Count)
                    {
                        checkMess.Add("连接方式");
                        CheckColl.Add("LJFS");
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