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
    public partial class GJLJForm : BaseUI
    {
        public GJLJForm()
        {
            InitializeComponent();
        }

        private void GJLJForm_Load(object sender, EventArgs e)
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
                ArrCheckColl = new string[] { "FL", "CZ", "LJFS", "GJ" };
                ArrCheckMess = new string[] { "分类", "材质", "连接方式", "管径（mm）" };
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.管件连接;
            this.InfTable.管件连接.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.GYGDQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["工业管道确定定额"];
            this.GCZJZHBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["公称直径转换"];
            this.FFSYCXBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["防腐刷油_除锈"];

            this.BWJRGCBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["保温绝热工程"];
            this.BWJRGCBindingSource.DataSource = SplitDataFW(BWJRGCBindingSource, "SBZJ", "MaxSBZJ", "MinSBZJ", '～');

            this.GDQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["管道确定清单"];
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
                    StringBuilder strString = new StringBuilder();
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["FL"])) ? " FL is null" : string.Format("FL like '%,{0},%'", drCurrent["FL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["CZ"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["CZ"]));

                    this.GDQDQDBindingSource.Filter = strString.ToString();
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.GDQDQDBindingSource.Count)
                    {
                        DataRowView view = this.GDQDQDBindingSource[0] as DataRowView;
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
                    this.GDQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    //获取规格对应的公称直径
                    //GCZJZHBindingSource.Filter = string.Format(" YSGG = '{0}'", drCurrent["GJ"]);
                    //DataRowView drvGczj = GCZJZHBindingSource.Current as DataRowView;
                    //decimal gczj = drvGczj == null ? -1 : decimal.Parse(toString(drvGczj["GCZJ"]));
                    //decimal jszj = drvGczj == null ? 0 : decimal.Parse(toString(drvGczj["JSZJ"]));

                    #region 保温绝热工程
                        strString = new StringBuilder(" BWLB ='保温层' and BWFL ='一般设备' ");
                        strString.Append(string.IsNullOrEmpty(toString(drCurrent["BWJRCLZL"])) ? " and JRCL is null" : string.Format(" and  JRCL = '{0}'", drCurrent["BWJRCLZL"]));
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
                                    //if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                                    //    row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                                    //else
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
                        strString = new StringBuilder(" BWLB ='防潮层、保护层' and BWFL ='一般设备' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["FCCBHCCL"])) ? " and JRCL is null" : string.Format(" and  JRCL = '{0}'", drCurrent["FCCBHCCL"]));
                    this.BWJRGCBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.BWJRGCBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        //if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                        //    row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        //else
                            row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }

                    #endregion

                    #region 工业管道确定定额
                    strString = new StringBuilder(" LB='管件连接' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["FL"])) ? " and  FL is null" : string.Format(" and  FL = '{0}'", drCurrent["FL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["CZ"])) ? " and  CZ is null" : string.Format("  and CZ = '{0}'", drCurrent["CZ"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["LJFS"])) ? " and  LJFS is null" : string.Format(" and  LJFS like '%,{0},%'", drCurrent["LJFS"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GJ"])) ? " and  GJ is null" : string.Format("  and GJ = '{0}'", drCurrent["GJ"]));
                    GYGDQDDEBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.GYGDQDDEBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        //if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                        //    row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                        //else
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

                    string[] ffsycx_filter = new string[3];
                    string[] bw_gclxs = new string[] { "GCLXS", "BWQXS", "BWHXS" };
                    strString = new StringBuilder(" FL='除锈工程' and BW='设备'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["CX"])) ? " and  LX is null" : string.Format(" and  LX = '{0}'", drCurrent["CX"]));
                    ffsycx_filter[0] = strString.ToString();


                    strString = new StringBuilder(" FL='防腐刷油工程' and (BW='设备防腐' or BW='设备刷油')");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["BWQFFSYYQ"])) ? " and  LX is null" : string.Format(" and  LX = '{0}'", drCurrent["BWQFFSYYQ"]));
                    ffsycx_filter[1] = strString.ToString();

                    strString = new StringBuilder(" FL='防腐刷油工程' and (BW='设备防腐' or BW='设备刷油')");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["BWHFFSYYQ"])) ? " and  LX is null" : string.Format(" and  LX = '{0}'", drCurrent["BWHFFSYYQ"]));
                    ffsycx_filter[2] = strString.ToString();

                    for (int i = 0; i < ffsycx_filter.Length; i++)
                    {
                        this.FFSYCXBindingSource.Filter = ffsycx_filter[i];
                        foreach (DataRowView item in FFSYCXBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            //if ("G".Equals(toString(item["GCLXS"])))
                            //    row["XS"] = drCurrent["TGGS"];
                            //else if (!string.IsNullOrEmpty(toString(item["GCLXS"])) && (toString(item["GCLXS"]).Contains('Φ') || toString(item["GCLXS"]).Contains("HD")))
                            //    row["XS"] = Math.Round(ToolKit.Calculate(toString(item["GCLXS"]).Replace("Φ", toString(jszj)).Replace("HD", toString(drCurrent["BWHD"]))), 6);
                            //else
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
            if (!string.IsNullOrEmpty(toString(drCurrent["FL"])))
            {
                strContent += "\r\n" + (++i) + ".管件连接分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CZ"])))
            {
                strContent += "\r\n" + (++i) + ".材质：" + drCurrent["CZ"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["LJFS"])))
            {
                strContent += "\r\n" + (++i) + ".连接形式：" + drCurrent["LJFS"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["GJ"])))
            {
                strContent += "\r\n" + (++i) + ".管径 （mm）：" + drCurrent["GJ"];
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["CX"])))
            {
                strContent += "\r\n" + (++i) + ".除锈：" + drCurrent["CX"];
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
                case "FL":
                    strString = new StringBuilder(" LB='管件连接' and FL is not null");
                    GYGDQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(GYGDQDDEBindingSource, "FL", ','), "FL");

                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    popControl1.RemoveDefaultColName = new string[] { "CZ", "LJFS", "GJ", "BWHD" };
                    popControl1.bind();
                    break;
                case "CZ":

                    strString = new StringBuilder(" LB='管件连接' and CZ is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["FL"])) ? " and FL is null" : string.Format(" and FL = '{0}'", currRow["FL"]));
                    GYGDQDDEBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(strToTable(GYGDQDDEBindingSource, "CZ", ','), "CZ");

                    popControl1.ColName = new string[] { "材质|CZ|CZ" };
                    popControl1.RemoveDefaultColName = new string[] {  "LJFS", "GJ", "BWHD" };
                    popControl1.bind();
                    break;
                case "LJFS":

                    strString = new StringBuilder(" LB='管件连接' and LJFS is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["FL"])) ? " and FL is null" : string.Format(" and  FL = '{0}'", currRow["FL"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["CZ"])) ? " and  CZ is null" : string.Format("  and CZ = '{0}'", currRow["CZ"]));
                    GYGDQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(GYGDQDDEBindingSource, "LJFS", ','), "LJFS");

                    popControl1.ColName = new string[] { "连接方式|LJFS|LJFS" };
                    popControl1.RemoveDefaultColName = new string[] { "GJ", "BWHD" };
                    popControl1.bind();
                    break;
                case "GJ":

                    strString = new StringBuilder(" LB='管件连接' and GJ is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["FL"])) ? " and  FL is null" : string.Format(" and  FL = '{0}'", currRow["FL"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["CZ"])) ? " and  CZ is null" : string.Format("  and CZ = '{0}'", currRow["CZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["LJFS"])) ? " and  LJFS is null" : string.Format(" and  LJFS like '%,{0},%'", currRow["LJFS"]));
                    GYGDQDDEBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(strToTable(GYGDQDDEBindingSource, "GJ", ','), "GJ");
                    popControl1.ColName = new string[] { "管径（mm）|GJ|GJ" };
                    popControl1.RemoveDefaultColName = new string[] { "BWHD" };
                    popControl1.bind();
                    break;
                case "CX":
                    this.FFSYCXBindingSource.Filter = string.Format("FL ='除锈工程' and BW ='设备' and LX is not null");
                    popControl1.DataSource = RemoveRepeat(FFSYCXBindingSource, "LX");
                    popControl1.ColName = new string[] { "除锈|LX|CX" };
                    popControl1.bind();
                    break;
                case "BWQFFSYYQ":
                    this.FFSYCXBindingSource.Filter = string.Format("FL ='防腐刷油工程' and (BW ='设备刷油' or BW ='设备防腐') and LX is not null");
                    popControl1.DataSource = RemoveRepeat(FFSYCXBindingSource, "LX");
                    popControl1.ColName = new string[] { "保温前防腐刷油要求|LX|BWQFFSYYQ" };
                    popControl1.bind();
                    break;
                case "BWJRCLZL":
                    this.BWJRGCBindingSource.Filter = string.Format("FL ='保温绝热工程' and BWLB ='保温层' and BWFL='一般设备' and JRCL is not null");
                    popControl1.DataSource = RemoveRepeat(strToTable(BWJRGCBindingSource, "JRCL", ','), "JRCL");
                    popControl1.ColName = new string[] { "保温绝热材料种类|JRCL|BWJRCLZL" };
                    popControl1.bind();
                    break;
                case "BWHD":
                    //获取计算直径  即设备直径
                    this.GCZJZHBindingSource.Filter = string.Format("YSGG = '{0}'", currRow["GJ"]);
                    DataRowView sjzj = GCZJZHBindingSource.Current as DataRowView;
                    decimal sbzj = sjzj == null ? -1 : ToolKit.ParseDecimal(sjzj["JSZJ"]);

                    strString = new StringBuilder("FL='保温绝热工程' and BWLB ='保温层' and BWFL ='一般设备' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["BWJRCLZL"])) ? " and JRCL is null" : string.Format(" and JRCL ='{0}'", currRow["BWJRCLZL"]));

                    this.BWJRGCBindingSource.Filter = strString.ToString();
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
                    repositoryItemSpinEdit1.MaxValue = maxValue;
                    repositoryItemSpinEdit1.MinValue = minValue;
                    break;
                case "FCCBHCCL":
                    this.BWJRGCBindingSource.Filter = string.Format("FL ='保温绝热工程' and BWLB ='防潮层、保护层' and BWFL='一般设备' and JRCL is not null");
                    popControl1.DataSource = RemoveRepeat(strToTable(BWJRGCBindingSource, "JRCL", ','), "JRCL");
                    popControl1.ColName = new string[] { "防潮层保护层材料|JRCL|FCCBHCCL" };
                    popControl1.bind();
                    break;
                case "BWHFFSYYQ":
                    this.FFSYCXBindingSource.Filter = string.Format("FL ='防腐刷油工程' and (BW ='设备刷油' or BW ='设备防腐') and LX is not null");
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
            StringBuilder strString = new StringBuilder();
            strString.Append(string.IsNullOrEmpty(toString(drCurrent["FL"])) ? " FL is null" : string.Format("FL like '%,{0},%'", drCurrent["FL"]))
                     .Append(string.IsNullOrEmpty(toString(drCurrent["CZ"])) ? " and CZ is null" : string.Format(" and CZ like '%,{0},%'", drCurrent["CZ"]));

            this.GDQDQDBindingSource.Filter = strString.ToString();
            if (0 < GDQDQDBindingSource.Count)
            {
                DataRowView view = this.GDQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        #endregion
    }
}