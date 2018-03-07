using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _ProjectsReport : _Report
    {
        

        /// <summary>
        /// 报表数据
        /// </summary>
        private DataSet m_ReportSource = null;

        /// <summary>
        /// 获取或设置：报表数据
        /// </summary>
        public DataSet ReportSource
        {
            get { return m_ReportSource; }
            set { m_ReportSource = value; }
        }

        /// <summary>
        /// 绑定报表数据
        /// </summary>
        /// <returns></returns>
        public override ArrayList BindingSource()
        {
            if (this.ReportStencil.Count > 0)
            {
                this.LoadReportSource();
                this.ReportResult = new ArrayList();
                NodeReport newxm = new NodeReport();
                int i = 1;
                newxm.ID = i++;
                newxm.PID = -1;
                newxm.ReportName = this.StructSource.ModelProject.Rows[0]["Name"].ToString();
                this.ReportResult.Add(newxm);
                _ObjectReport[] m_ObjectReport = this.ReportStencil.Cast<_ObjectReport>().Where(p => p.ReportType == "项目报表").ToArray();
                foreach (_ObjectReport item in m_ObjectReport)
                {
                    item.ID = i++;
                    item.PID = 1;
                    item.XMMC = this.StructSource.ModelProject.Rows[0]["Name"].ToString();
                    DataTable dt = this.ReportSource.Tables[item.Method];
                    if (dt != null)
                    {
                        item.DataSource = dt;
                    }
                    this.ReportResult.Add(item);
                }

                DataRow[] drs = this.StructSource.ModelProject.Select("DEEP=2", "ID");
                _UnitProjectReport m_UnitProjectReport =null;
                foreach (DataRow item in drs)
                {
                    _UnitProject info = item["UnitProject"] as _UnitProject;
                    if (info == null)
                    {
                        info = new _UnitProject();
                        _ObjectSource.GetObject(info, item);
                        this.CurrBusiness.Load(info);
                    }
                    m_UnitProjectReport = new _UnitProjectReport();
                    m_UnitProjectReport.UnID = info.ActiviteId != 0 ? info.ActiviteId : info.ID;//Convert.ToInt32(item["ID"]);
                    m_UnitProjectReport.StructSource = info.StructSource;
                    m_UnitProjectReport.ReportStencil = this.ReportStencil.Copy() as _List;
                    m_UnitProjectReport.BindingSource();
                    if (m_UnitProjectReport.ReportResult != null)
                    {
                        _ObjectReport m_dw = m_UnitProjectReport.ReportResult.Cast<_ObjectReport>().Where(p => p is NodeReport).FirstOrDefault();
                        if (m_dw != null)
                        {
                            m_dw.ID = i++;
                            m_dw.PID = 1;
                            this.ReportResult.Add(m_dw);
                            foreach (_ObjectReport item_dw in m_UnitProjectReport.ReportResult)
                            {
                                this.TKBB_UnitProject(item_dw);
                                if (!(item_dw is NodeReport))
                                {
                                    item_dw.ID = i++;
                                    item_dw.PID = m_dw.ID;
                                    this.ReportResult.Add(item_dw);
                                }
                            }
                        }
                    }
                }
            }
            return this.ReportResult;
        }

        /// <summary>
        /// 加载报表数据
        /// </summary>
        public void LoadReportSource()
        {
            try
            {
                this.CreateDataSet();
                this.GCXMZZJB();
                this.DXGCZJHZB();
                this.HZFXB();
                this.GCXMZJMXB();
                this.DXGCBJHZB();
                this.TBBJHZB();
                this.TKBB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建报表结构
        /// </summary>
        private void CreateDataSet()
        {
            if (this.ReportSource != null)
            {
                this.ReportSource.Clear();
                return;
            }
            this.ReportSource = new DataSet();
            //1.工程项目总造价表
            DataTable dt1 = new DataTable("GCXMZZJB");
            dt1.Columns.Add("XH");//序号
            dt1.Columns.Add("XMBM");//项目编码
            dt1.Columns.Add("XMMC");//项目名称
            dt1.Columns.Add("GCZZJ");//工程总造价
            this.ReportSource.Tables.Add(dt1);
            //2.单项工程造价汇总表				
            DataTable dt2 = new DataTable("DXGCZJHZB");
            dt2.Columns.Add("XH");//序号
            dt2.Columns.Add("XMBM");//项目编码
            dt2.Columns.Add("XMMC");//项目名称
            dt2.Columns.Add("GCZZJ");//工程总造价
            this.ReportSource.Tables.Add(dt2);
            //3.汇总分析表				
            DataTable dt3 = new DataTable("HZFXB");
            dt3.Columns.Add("XH");//序号
            dt3.Columns.Add("XMBM");//项目编码
            dt3.Columns.Add("XMMC");//项目名称
            dt3.Columns.Add("ZYMC");//专业名称
            dt3.Columns.Add("JSDW");//建设单位
            dt3.Columns.Add("GCZZJ");//工程总造价
            dt3.Columns.Add("JZMJ");//建筑面积
            dt3.Columns.Add("DWZJ");//单位造价
            dt3.Columns.Add("BZ");//备注
            this.ReportSource.Tables.Add(dt3);
            //4.工程项目造价明细表				
            DataTable dt4 = new DataTable("GCXMZJMXB");
            dt4.Columns.Add("XH");//序号
            dt4.Columns.Add("XMBM");//项目编码
            dt4.Columns.Add("XMMC");//项目名称
            dt4.Columns.Add("FBFXGCF");//分部分项工程费
            dt4.Columns.Add("CSXMF");//措施项目费
            dt4.Columns.Add("QTXMF");//其他项目费
            dt4.Columns.Add("GF");//规费
            dt4.Columns.Add("SJ");//税金
            dt4.Columns.Add("AQJWMSGF");//安全及文明施工费
            dt4.Columns.Add("GCZZJ");//工程总造价
            dt4.Columns.Add("JZMJ");//建筑面积
            dt4.Columns.Add("DWZJ");//单位造价
            dt4.Columns.Add("ZZJB");//占总价比%
            this.ReportSource.Tables.Add(dt4);
            //5.单项工程报价汇总表				
            DataTable dt5 = new DataTable("DXGCBJHZB");
            dt5.Columns.Add("XH");//序号
            dt5.Columns.Add("XMBM");//项目编码
            dt5.Columns.Add("XMMC");//项目名称
            dt5.Columns.Add("FBFXGCF");//分部分项工程费
            dt5.Columns.Add("CSXMF");//措施项目费
            dt5.Columns.Add("QTXMF");//其他项目费
            dt5.Columns.Add("GCZZJ");//工程总造价
            this.ReportSource.Tables.Add(dt5);
            //6.投标报价汇总表				
            DataTable dt6 = new DataTable("TBBJHZB");
            dt6.Columns.Add("XH");
            dt6.Columns.Add("XMMC");
            dt6.Columns.Add("DW");
            dt6.Columns.Add("GCBJ");
            dt6.Columns.Add("BZ");
            this.ReportSource.Tables.Add(dt6);
            //7.填空报表数据（所有填空报表）
            DataTable dt7 = new DataTable("TKBB");
            dt7.Columns.Add("GCMC");//工程名称
            dt7.Columns.Add("XXZZJ");//总造价(小写)
            dt7.Columns.Add("DXZZJ");//总造价(大写)
            dt7.Columns.Add("BZDW");//编制单位
            dt7.Columns.Add("FDHSQRBZ");//法定代表人或其授权人(编制)
            dt7.Columns.Add("JSDW");//建设单位
            dt7.Columns.Add("FDHSQRJS");//法定代表人或其授权人(建设)
            dt7.Columns.Add("ZBDLR");//招标代理人
            dt7.Columns.Add("FDHSQRZB");//法定代表人或其授权人(招标)
            dt7.Columns.Add("TBDW");//投标人
            dt7.Columns.Add("FDHSQRTB");//法定代表人或其授权人(投标)
            dt7.Columns.Add("ZBBZR");//招标编制人
            dt7.Columns.Add("ZBBZRQY"); //招标编制日期(年)
            dt7.Columns.Add("ZBBZRQM");//招标编制日期(月)
            dt7.Columns.Add("ZBBZRQD");//招标编制日期(日)
            dt7.Columns.Add("ZBFHR");//招标复核人
            dt7.Columns.Add("ZBFHRQY");//招标复核日期(年)
            dt7.Columns.Add("ZBFHRQM");//招标复核日期(月)
            dt7.Columns.Add("ZBFHRQD");//招标复核日期(日)
            dt7.Columns.Add("TBBZR");//投标编制人
            dt7.Columns.Add("TBBZRQY"); //投标编制日期(年)
            dt7.Columns.Add("TBBZRQM");//投标编制日期(月)
            dt7.Columns.Add("TBBZRQD");//投标编制日期(日)
            this.ReportSource.Tables.Add(dt7);
           
        }

        #region 项目管理所有报表数据
        /// <summary>
        /// 1.项目汇总表
        /// </summary>
        public void GCXMZZJB()
        {
            if (this.ReportSource.Tables.Contains("GCXMZZJB"))
            {
                DataTable dt = this.ReportSource.Tables["GCXMZZJB"];
                decimal hj = 0m;
                DataRow[] drs = this.StructSource.ModelProject.Select("DEEP<> 2", "ID");
                foreach (DataRow item in drs)
                {
                    DataRow row = dt.NewRow();
                    int m_ID = ToolKit.ParseInt(item["ID"]);
                    row["XH"] = item["CODE"];
                    row["XMBM"] = item["CODE"];
                    row["XMMC"] = item["Name"];
                    switch (item["DEEP"].ToString())
                    {
                        case "0":
                            hj = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ");
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ");
                            break;
                        case "1":
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "ZZJ");
                            break;
                        default:
                            break;
                    }
                    dt.Rows.Add(row);
                }
                //合计小写
                dt.Rows.Add(dt.NewRow());
                DataRow rowhj = dt.NewRow();
                rowhj["XH"] = string.Empty;
                rowhj["XMBM"] = string.Empty;
                rowhj["XMMC"] = "合计";
                rowhj["GCZZJ"] = hj;
                dt.Rows.Add(rowhj);
                //合计大写
                DataRow rowhjdx = dt.NewRow();
                rowhjdx["XH"] = string.Empty;
                rowhjdx["XMBM"] = string.Empty;
                rowhjdx["XMMC"] = string.Empty;
                rowhjdx["GCZZJ"] = "大写:" + ToolKit.NumToCNum(hj, true);
                dt.Rows.Add(rowhjdx);
            }
        }
        /// <summary>
        /// 2.单项工程造价汇总表				
        /// </summary>
        public void DXGCZJHZB()
        {
            if (this.ReportSource.Tables.Contains("DXGCZJHZB"))
            {
                DataTable dt = this.ReportSource.Tables["DXGCZJHZB"];
                DataRow[] drs = this.StructSource.ModelProject.Select("DEEP<> 0", "CODE");
                foreach (DataRow item in drs)
                {
                    int m_ID = ToolKit.ParseInt(item["ID"]);
                    DataRow row = dt.NewRow();
                    row["XH"] = item["CODE"];
                    row["XMBM"] = item["CODE"];
                    row["XMMC"] = item["Name"];
                    switch (item["DEEP"].ToString())
                    {
                        case "1":
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "ZZJ");
                            break;
                        case "2":
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "ZZJ");
                            break;
                        default:
                            break;
                    }
                    dt.Rows.Add(row);
                }
                dt.Rows.Add(dt.NewRow());
                DataRow rowhj = dt.NewRow();
                rowhj["XH"] = string.Empty;
                rowhj["XMBM"] = string.Empty;
                rowhj["XMMC"] = "合计";
                rowhj["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ");
                dt.Rows.Add(rowhj);
            }
        }
        /// <summary>
        /// 3.汇总分析表
        /// </summary>
        public void HZFXB()
        {
            if (this.ReportSource.Tables.Contains("HZFXB"))
            {
                DataTable dt = this.ReportSource.Tables["HZFXB"];
                DataRow[] drs = this.StructSource.ModelProject.Select(string.Empty, "CODE");
                foreach (DataRow item in drs)
                {
                    DataRow row = dt.NewRow();
                    int m_ID = ToolKit.ParseInt(item["ID"]);
                    row["XH"] = item["ID"];
                    row["XMBM"] = item["CODE"];
                    row["XMMC"] = item["Name"];
                    row["ZYMC"] = item["ProType"];
                    row["JSDW"] = item["JSDW"];
                    if (this.StructSource.BiddingInfoSource != null && this.StructSource.BiddingInfoSource.Rows.Count == 1)
                    {
                        DataRow dr = this.StructSource.BiddingInfoSource.Rows[0];
                        row["JZMJ"] = this.Formart(dr["ZBMJ"], 2);
                    }
                    row["DWZJ"] = this.Formart(item["DWZJ"], 2);
                    row["BZ"] = item["BZ"];
                    switch (item["DEEP"].ToString())
                    {
                        case "0":
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ");
                            break;
                        case "1":
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "ZZJ");
                            break;
                        case "2":
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "ZZJ");
                            break;
                        default:
                            break;
                    }
                    dt.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// 4.工程项目造价明细表				
        /// </summary>
        public void GCXMZJMXB()
        {
            if (this.ReportSource.Tables.Contains("GCXMZJMXB"))
            {
                DataTable dt = this.ReportSource.Tables["GCXMZJMXB"];
                DataRow[] drs = this.StructSource.ModelProject.Select(string.Empty, "CODE");
                decimal jzmj = 0m;
                if (this.StructSource.BiddingInfoSource != null && this.StructSource.BiddingInfoSource.Rows.Count == 1)
                {
                    DataRow dr = this.StructSource.BiddingInfoSource.Rows[0];
                    jzmj = this.Formart(dr["ZBMJ"], 2);
                }
                foreach (DataRow item in drs)
                {
                    DataRow row = dt.NewRow();
                    int m_ID = ToolKit.ParseInt(item["ID"]);
                    row["XH"] = item["CODE"];
                    row["XMBM"] = item["CODE"];
                    row["XMMC"] = item["Name"];
                    switch (item["DEEP"].ToString())
                    {
                        case "0":
                            row["FBFXGCF"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "FGCF");
                            row["CSXMF"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "CSXMF");
                            row["QTXMF"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "QTXMF");
                            row["GF"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "GF");
                            row["SJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "SJ");
                            row["AQJWMSGF"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "AQWM");
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ");
                            row["JZMJ"] = jzmj;//this.StructSource.ModelProjVariable.GetDecimal(0, -3, "JZMJ");
                            row["DWZJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "DWZJ");
                            row["ZZJB"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJB");
                            break;
                        case "1":
                            row["FBFXGCF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "FGCF");
                            row["CSXMF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "CSXMF");
                            row["QTXMF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "QTXMF");
                            row["GF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "GF");
                            row["SJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "SJ");
                            row["AQJWMSGF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "AQWM");
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "ZZJ");
                            row["JZMJ"] = jzmj; //this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "JZMJ");
                            row["DWZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "DWZJ");
                            row["ZZJB"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -2, "ZZJB");
                            break;
                        case "2":
                            row["FBFXGCF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "FGCF");
                            row["CSXMF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "CSXMF");
                            row["QTXMF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "QTXMF");
                            row["GF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "GF");
                            row["SJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "SJ");
                            row["AQJWMSGF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "AQWM");
                            row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "ZZJ");
                            row["JZMJ"] = jzmj; //this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "JZMJ");
                            row["DWZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "DWZJ");
                            row["ZZJB"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "ZZJB");
                            break;
                        default:
                            break;
                    }
                    dt.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// 5.单项工程报价汇总表				
        /// </summary>
        public void DXGCBJHZB()
        {
            if (this.ReportSource.Tables.Contains("DXGCBJHZB"))
            {
                DataTable dt = this.ReportSource.Tables["DXGCBJHZB"];
                DataRow[] drs = this.StructSource.ModelProject.Select("DEEP=2", string.Empty);
                foreach (DataRow item in drs)
                {
                    DataRow row = dt.NewRow();
                    int m_ID = ToolKit.ParseInt(item["ID"]);
                    row["XH"] = item["CODE"];
                    row["XMBM"] = item["CODE"];
                    row["XMMC"] = item["Name"];
                    row["FBFXGCF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "FGCF");
                    row["CSXMF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "CSXMF");
                    row["QTXMF"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "QTXMF");
                    row["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(m_ID, -1, "ZZJ");
                    dt.Rows.Add(row);
                }
                dt.Rows.Add(dt.NewRow());
                DataRow rowhj = dt.NewRow();
                rowhj["XH"] = "合计：";
                rowhj["XMBM"] = string.Empty;
                rowhj["XMMC"] = ToolKit.NumToCNum(this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ"), true); 
                rowhj["FBFXGCF"] = string.Empty;
                rowhj["CSXMF"] = string.Empty;
                rowhj["QTXMF"] = string.Empty;
                rowhj["GCZZJ"] = this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ");
                dt.Rows.Add(rowhj);
            }
        }

        /// <summary>
        /// 6.投标报价汇总表			
        /// </summary>
        public void TBBJHZB()
        {
            if (this.ReportSource.Tables.Contains("TBBJHZB"))
            {
                DataTable dt = this.ReportSource.Tables["TBBJHZB"];
                DataRow dr = this.StructSource.ModelProject.GetRowByOther("1");
                if (dr != null)
                {
                    this.FZTBBJHZB(dt, "一", "分部分项工程费", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "FGCF").ToString());
                    this.FZTBBJHZB(dt, "二", "措施项目费", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "CSXMF").ToString());
                    this.FZTBBJHZB(dt, "三", "其它项目费", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "QTXMF").ToString());
                    this.FZTBBJHZB(dt, "四", "规费", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "GF").ToString());
                    this.FZTBBJHZB(dt, "五", "税金", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "SJ").ToString());
                    this.FZTBBJHZB(dt, "六", "安装文明施工项目费", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "AQWM").ToString());
                    this.FZTBBJHZB(dt, "七", "投标价合计", this.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ").ToString());
                }
            }
        }

        /// <summary>
        /// 7.填空报表数据（所有填空报表）
        /// </summary>
        public void TKBB()
        {
            if (this.ReportSource.Tables.Contains("TKBB"))
            {
                DataTable dt = this.ReportSource.Tables["TKBB"];
                DataRow row = dt.NewRow();
                DataTable sds = this.StructSource.BiddingInfoSource;
                row["GCMC"] = this.StructSource.ModelProject.Rows[0]["Name"];//工程名称
                decimal m_zzj = ToolKit.ParseDecimal(this.StructSource.ModelProjVariable.Get(0, -3, "ZZJ"));
                if (m_zzj.Equals(0m))
                {
                    row["XXZZJ"] = "￥0.00";//总造价(小写)
                    row["DXZZJ"] = "无";//总造价(大写)
                }
                else
                {
                    row["XXZZJ"] = "￥" + m_zzj.ToString("N2");//总造价(小写)
                    row["DXZZJ"] = ToolKit.NumToCNum(CDataConvert.ConToValue<System.Decimal>(m_zzj.ToString("N2")), true);//总造价(大写)
                }
                if (this.StructSource.BiddingInfoSource != null && this.StructSource.BiddingInfoSource.Rows.Count ==1)
                {
                    DataRow m_BiddingInfo = this.StructSource.BiddingInfoSource.Rows[0];
                    row["JSDW"] = m_BiddingInfo["JSDW"];//建设单位
                    row["FDHSQRJS"] = m_BiddingInfo["JSDWDBR"];//法定代表人或其授权人(建设)
                    row["BZDW"] = m_BiddingInfo["BZDW"];//编制单位
                    row["FDHSQRBZ"] = m_BiddingInfo["BZDWDBR"];//法定代表人或其授权人(编制)
                    row["ZBDLR"] = m_BiddingInfo["ZBDLR"];//招标代理人
                    row["FDHSQRZB"] = m_BiddingInfo["ZBDLDBR"];//法定代表人或其授权人(招标)
                    row["ZBBZR"] = m_BiddingInfo["PlaitName"];//招标编制人
                    row["ZBFHR"] = m_BiddingInfo["ReviewName"];//招标复核人
                    if (m_BiddingInfo["PlaitDate"] is DateTime)
                    {
                        DateTime zbbzrq = Convert.ToDateTime(m_BiddingInfo["PlaitDate"]);
                        row["ZBBZRQY"] = zbbzrq.Year.ToString();//招标编制日期(年)
                        row["ZBBZRQM"] = zbbzrq.Month.ToString();//招标编制日期(月)
                        row["ZBBZRQD"] = zbbzrq.Day.ToString();//招标编制日期(日)
                    }
                    if (m_BiddingInfo["ReviewDate"] is DateTime)
                    {
                        DateTime zbfhrq = Convert.ToDateTime(m_BiddingInfo["ReviewDate"]);
                        row["ZBFHRQY"] = zbfhrq.Year.ToString();//招标复核日期(年)
                        row["ZBFHRQM"] = zbfhrq.Month.ToString();//招标复核日期(月)
                        row["ZBFHRQD"] = zbfhrq.Day.ToString();//招标复核日期(日)
                    }
                }
                if (this.StructSource.TenderInfoSource != null && this.StructSource.TenderInfoSource.Rows.Count == 1)
                {
                    DataRow m_TenderInfo = this.StructSource.TenderInfoSource.Rows[0];
                    row["TBDW"] = m_TenderInfo["TBDW"];//投标人
                    row["FDHSQRTB"] = m_TenderInfo["TBDWDBR"];//法定代表人或其授权人(投标)
                    row["TBBZR"] = m_TenderInfo["PlaitName"];//投标编制人
                    if (m_TenderInfo["PlaitDate"] is DateTime)
                    {
                        DateTime tbbzrq = Convert.ToDateTime(m_TenderInfo["PlaitDate"]);
                        row["TBBZRQY"] = tbbzrq.Year.ToString();//投标编制日期(年)
                        row["TBBZRQM"] = tbbzrq.Month.ToString();//投标编制日期(月)
                        row["TBBZRQD"] = tbbzrq.Day.ToString();//投标编制日期(日)
                    }
                }
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 单位工程填空报表
        /// </summary>
        /// <param name="p_ObjectReport"></param>
        private void TKBB_UnitProject(_ObjectReport p_ObjectReport)
        {
            DataRow dr_TKBB = null;
            if (this.ReportSource.Tables.Contains("TKBB"))
            {
                DataTable dt = this.ReportSource.Tables["TKBB"] as DataTable;
                if (dt != null && dt.Rows.Count == 1)
                {
                    dr_TKBB = dt.Rows[0];
                }
            }
            if (dr_TKBB == null) return;
            if (dr_TKBB != null && p_ObjectReport.Method.Equals("TKBB"))
            {
                DataTable dt = p_ObjectReport.DataSource as DataTable;
                if (dt != null && dt.Rows.Count == 1)
                {
                    dt.Rows[0]["BZDW"] = dr_TKBB["BZDW"];
                    dt.Rows[0]["FDHSQRBZ"] = dr_TKBB["FDHSQRBZ"];
                    dt.Rows[0]["JSDW"] = dr_TKBB["JSDW"];
                    dt.Rows[0]["FDHSQRJS"] = dr_TKBB["FDHSQRJS"];
                    dt.Rows[0]["ZBDLR"] = dr_TKBB["ZBDLR"];
                    dt.Rows[0]["FDHSQRZB"] = dr_TKBB["FDHSQRZB"];
                    dt.Rows[0]["TBDW"] = dr_TKBB["TBDW"];
                    dt.Rows[0]["FDHSQRTB"] = dr_TKBB["FDHSQRTB"];
                    dt.Rows[0]["TBBZR"] = dr_TKBB["TBBZR"];
                    dt.Rows[0]["TBBZRQY"] = dr_TKBB["TBBZRQY"];
                    dt.Rows[0]["TBBZRQM"] = dr_TKBB["TBBZRQM"];
                    dt.Rows[0]["TBBZRQD"] = dr_TKBB["TBBZRQD"];
                }
            }
        }

        /// <summary>
        /// 6.投标报价汇总表(辅助)
        /// </summary>
        /// <param name="p_dt"></param>
        /// <param name="p_XH"></param>
        /// <param name="p_MC"></param>
        /// <param name="p_GCBJ"></param>
        private void FZTBBJHZB(DataTable p_dt, string p_XH, string p_MC, string p_GCBJ)
        {
            DataRow row = p_dt.NewRow();
            row["XH"] = p_XH;
            row["XMMC"] = p_MC;
            row["DW"] = "元";
            row["GCBJ"] = p_GCBJ;
            row["BZ"] = string.Empty;
            p_dt.Rows.Add(row);
        }
        #endregion
    }
}
