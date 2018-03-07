using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _UnitProjectReport : _Report
    {
        private DataTable m_Summary = null;

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
                DataRow dt_dw = this.StructSource.ModelProject.GetRowByOther(this.UnID.ToString());
                if (dt_dw != null)
                {
                    this.LoadReportSource();
                    this.ReportResult = new ArrayList();
                    NodeReport newxm = new NodeReport();
                    newxm.ID = 1;
                    newxm.PID = -1;
                    newxm.ReportName = dt_dw["Name"].ToString();
                    this.ReportResult.Add(newxm);
                    int i = newxm.ID;
                    _ObjectReport[] m_ObjectReport = this.ReportStencil.Cast<_ObjectReport>().Where(p => p.ReportType == "单位报表").ToArray();
                    foreach (_ObjectReport item in m_ObjectReport)
                    {
                        item.ID = ++i;
                        item.PID = newxm.ID;
                        item.XMMC = dt_dw["Name"].ToString();
                        item.ZYMC = dt_dw["PrfType"].ToString();
                        DataTable dt = this.ReportSource.Tables[item.Method];
                        if (dt != null)
                        {
                            item.DataSource = dt;
                        }
                        this.ReportResult.Add(item);
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
           
                this.UnID = int.Parse(this.StructSource.ModelProjVariable.Rows[0]["ID"].ToString());
                this.m_Summary = m_DataSetHelper.SelectGroupByInto(this.StructSource.ModelQuantity.TableName, this.StructSource.ModelQuantity, _Constant.gljzd, string.Format("UnID={0}", this.UnID), _Constant.hbtjzd);
                //this.m_Summary.Columns["SCHJ"].Expression = "SCDJ * SL";
                //this.m_Summary.Columns["DEHJ"].Expression = "DEDJ * SL";
                this.TKBB();
                this.DWGCZJHZB();
                this.DWGCZJHZBXX();
                this.FBFXGCLQD();
                this.CSXMQD();
                this.QTXMQD();
                this.JRG();
                this.ZCBFWF();
                this.GFSJXMQD();
                this.GCLQDZHDJFXB();
                this.ZYCLJG();
                this.FBFXGCLZHDJFXB();
                this.CSXMZHDJFXB();
                this.JGSBSLDJMXB();
                this.CLSBZGDJMXB();
                this.SDC();
                this.PBZDCLJGB();
                this.ZCSBB();
                this.ZLJGMXB();
                this.ZYGCZGJMXB();
                this.GFSJXMQDHJ();
            }
            catch (Exception e)
            {
                throw e;
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
            //1.单位工程造价汇总表
            DataTable dt1 = new DataTable("DWGCZJHZB");
            dt1.Columns.Add("XH");
            dt1.Columns.Add("DWGCMC");
            dt1.Columns.Add("ZJ");
            this.ReportSource.Tables.Add(dt1);
            //2.单位工程造价汇总表（详细）
            DataTable dt2 = new DataTable("DWGCZJHZBXX");
            dt2.Columns.Add("XH");
            dt2.Columns.Add("DWGCMC");
            dt2.Columns.Add("ZJ");
            this.ReportSource.Tables.Add(dt2);
            //3.分部分项工程量清单（计价表,清单表）
            DataTable dt3 = new DataTable("FBFXGCLQD");
            dt3.Columns.Add("XH");
            dt3.Columns.Add("XMBM");
            dt3.Columns.Add("XMMC");
            dt3.Columns.Add("JLDW");
            dt3.Columns.Add("GCSL");
            dt3.Columns.Add("ZHDJ");
            dt3.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt3);
            //4.措施项目清单（计价表,清单表）
            DataTable dt4 = new DataTable("CSXMQD");
            dt4.Columns.Add("XH");
            dt4.Columns.Add("XMMC");
            dt4.Columns.Add("JLDW");
            dt4.Columns.Add("GCSL");
            dt4.Columns.Add("ZHDJ");
            dt4.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt4);
            //5.其他项目清单（计价表,清单表）
            DataTable dt5 = new DataTable("QTXMQD");
            dt5.Columns.Add("XH");
            dt5.Columns.Add("XMMC");
            dt5.Columns.Add("JLDW");
            dt5.Columns.Add("GCSL");
            dt5.Columns.Add("ZHDJ");
            dt5.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt5);
            //6.计日工（计价表,清单表）
            DataTable dt6 = new DataTable("JRG");
            dt6.Columns.Add("XH");
            dt6.Columns.Add("XMMC");
            dt6.Columns.Add("DW");
            dt6.Columns.Add("ZDSL");
            dt6.Columns.Add("ZHDJ");
            dt6.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt6);
            //7.总承包服务费（计价表,清单表）
            DataTable dt7 = new DataTable("ZCBFWF");
            dt7.Columns.Add("XH");
            dt7.Columns.Add("XMMC");
            dt7.Columns.Add("DW");
            dt7.Columns.Add("GCSL");
            dt7.Columns.Add("ZHDJ");
            dt7.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt7);
            //8.规费、税金项目清单计价表
            DataTable dt8 = new DataTable("GFSJXMQD");
            dt8.Columns.Add("XH");
            dt8.Columns.Add("XMMC");
            dt8.Columns.Add("JSJC");
            dt8.Columns.Add("FL");
            dt8.Columns.Add("JLDW");
            dt8.Columns.Add("SL");
            dt8.Columns.Add("ZHDJ");
            dt8.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt8);
            //9.工程量清单综合单价分析表
            DataTable dt9 = new DataTable("GCLQDZHDJFXB");
            dt9.Columns.Add("XH");
            dt9.Columns.Add("XMBM");
            dt9.Columns.Add("XMMC");
            dt9.Columns.Add("JLDW");
            dt9.Columns.Add("ZJYJ");
            dt9.Columns.Add("RGF");
            dt9.Columns.Add("CLF");
            dt9.Columns.Add("JXF");
            dt9.Columns.Add("ZCF");
            dt9.Columns.Add("SBF");
            dt9.Columns.Add("FX");
            dt9.Columns.Add("GLF");
            dt9.Columns.Add("LR");
            dt9.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt9);
            //10.主要材料价格表
            DataTable dt10 = new DataTable("ZYCLJG");
            dt10.Columns.Add("XH");
            dt10.Columns.Add("CLBM");
            dt10.Columns.Add("CLMC");
            dt10.Columns.Add("DW");
            dt10.Columns.Add("SL");
            dt10.Columns.Add("DJ");
            dt10.Columns.Add("HJ");
            dt10.Columns.Add("BZ");
            this.ReportSource.Tables.Add(dt10);
            //11.分部分项工程量综合单价分析表一
            DataTable dt11 = new DataTable("FBFXGCLZHDJFXB");
            dt11.Columns.Add("XH");
            dt11.Columns.Add("XMBM");
            dt11.Columns.Add("XMMC");
            dt11.Columns.Add("JLDW");
            dt11.Columns.Add("GCSL");
            dt11.Columns.Add("LB");
            dt11.Columns.Add("GCNR");
            dt11.Columns.Add("RGF");
            dt11.Columns.Add("CLF");
            dt11.Columns.Add("JXF");
            dt11.Columns.Add("ZCF");
            dt11.Columns.Add("SBF");
            dt11.Columns.Add("FX");
            dt11.Columns.Add("GLF");
            dt11.Columns.Add("LR");
            dt11.Columns.Add("ZHDJ");
            this.ReportSource.Tables.Add(dt11);
            //12.措施项目费(综合单价)分析表
            DataTable dt12 = new DataTable("CSXMZHDJFXB");
            dt12.Columns.Add("XH");
            dt12.Columns.Add("XMBM");
            dt12.Columns.Add("XMMC");
            dt12.Columns.Add("JLDW");
            dt12.Columns.Add("RGF");
            dt12.Columns.Add("CLF");
            dt12.Columns.Add("JXF");
            dt12.Columns.Add("FX");
            dt12.Columns.Add("GLF");
            dt12.Columns.Add("LR");
            dt12.Columns.Add("ZHDJ");
            this.ReportSource.Tables.Add(dt12);
            //13.甲供材料、设备数量及单价明细表（计价表,清单表）
            DataTable dt13 = new DataTable("JGSBSLDJMXB");
            dt13.Columns.Add("XH");
            dt13.Columns.Add("CLBM");
            dt13.Columns.Add("CLMC");
            dt13.Columns.Add("DW");
            dt13.Columns.Add("SL");
            dt13.Columns.Add("DJ");
            dt13.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt13);
            //14.材料、设备暂估单价明细表（计价表,清单表）
            DataTable dt14 = new DataTable("CLSBZGDJMXB");
            dt14.Columns.Add("XH");
            dt14.Columns.Add("CLBM");
            dt14.Columns.Add("CLMC");
            dt14.Columns.Add("DW");
            dt14.Columns.Add("ZGDJ");
            dt14.Columns.Add("ZGHJ");
            this.ReportSource.Tables.Add(dt14);
            //15.三材表
            DataTable dt15 = new DataTable("SDC");
            dt15.Columns.Add("CLBM");
            dt15.Columns.Add("CLMC");
            dt15.Columns.Add("DW");
            dt15.Columns.Add("XHL");
            dt15.Columns.Add("DJ");
            dt15.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt15);
            //16.评标指定材料价格表
            DataTable dt16 = new DataTable("PBZDCLJGB");
            dt16.Columns.Add("XH");
            dt16.Columns.Add("CLBM");
            dt16.Columns.Add("CLMC");
            dt16.Columns.Add("DW");
            dt16.Columns.Add("XHL");
            dt16.Columns.Add("DJ");
            dt16.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt16);
            //17.主材、设备表
            DataTable dt17 = new DataTable("ZCSBB");
            dt17.Columns.Add("XH");
            dt17.Columns.Add("CLBM");
            dt17.Columns.Add("CLMC");
            dt17.Columns.Add("DW");
            dt17.Columns.Add("XHL");
            dt17.Columns.Add("DJ");
            dt17.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt17);
            //18.暂列金额明细表
            DataTable dt18 = new DataTable("ZLJGMXB");
            dt18.Columns.Add("XH");
            dt18.Columns.Add("XMMC");
            dt18.Columns.Add("JLDW");
            dt18.Columns.Add("ZDJE");
            this.ReportSource.Tables.Add(dt18);
            //19.专业工程暂估价明细表
            DataTable dt19 = new DataTable("ZYGCZGJMXB");
            dt19.Columns.Add("XH");
            dt19.Columns.Add("XMMC");
            dt19.Columns.Add("JLDW");
            dt19.Columns.Add("ZGDJ");
            this.ReportSource.Tables.Add(dt19);
            //20.规费、税金项目清单计价表(清单)
            DataTable dt20 = new DataTable("GFSJXMQDHJ");
            dt20.Columns.Add("XH");
            dt20.Columns.Add("XMMC");
            dt20.Columns.Add("JSJC");
            dt20.Columns.Add("FL");
            dt20.Columns.Add("JLDW");
            dt20.Columns.Add("SL");
            dt20.Columns.Add("ZHDJ");
            dt20.Columns.Add("HJ");
            this.ReportSource.Tables.Add(dt20);
            //21.填空报表数据（所有填空报表）
            DataTable dt21 = new DataTable("TKBB");
            dt21.Columns.Add("GCMC");//工程名称
            dt21.Columns.Add("XXZZJ");//总造价(小写)
            dt21.Columns.Add("DXZZJ");//总造价(大写)
            dt21.Columns.Add("BZDW");//编制单位
            dt21.Columns.Add("FDHSQRBZ");//法定代表人或其授权人(编制)
            dt21.Columns.Add("JSDW");//建设单位
            dt21.Columns.Add("FDHSQRJS");//法定代表人或其授权人(建设)
            dt21.Columns.Add("ZBDLR");//招标代理人
            dt21.Columns.Add("FDHSQRZB");//法定代表人或其授权人(招标)
            dt21.Columns.Add("TBDW");//投标人
            dt21.Columns.Add("FDHSQRTB");//法定代表人或其授权人(投标)
            dt21.Columns.Add("ZBBZR");//招标编制人
            dt21.Columns.Add("ZBBZRQY"); //招标编制日期(年)
            dt21.Columns.Add("ZBBZRQM");//招标编制日期(月)
            dt21.Columns.Add("ZBBZRQD");//招标编制日期(日)
            dt21.Columns.Add("ZBFHR");//招标复核人
            dt21.Columns.Add("ZBFHRQY");//招标复核日期(年)
            dt21.Columns.Add("ZBFHRQM");//招标复核日期(月)
            dt21.Columns.Add("ZBFHRQD");//招标复核日期(日)
            dt21.Columns.Add("TBBZR");//投标编制人
            dt21.Columns.Add("TBBZRQY"); //投标编制日期(年)
            dt21.Columns.Add("TBBZRQM");//投标编制日期(月)
            dt21.Columns.Add("TBBZRQD");//投标编制日期(日)
            this.ReportSource.Tables.Add(dt21);
        }


        #region 单位工程报表数据
        /// <summary>
        /// 1.单位工程造价汇总表
        /// </summary>
        private void DWGCZJHZB()
        {
            if (this.ReportSource.Tables.Contains("DWGCZJHZB"))
            {
                DataTable dt = this.ReportSource.Tables["DWGCZJHZB"];
                decimal hj = 0m;
                this.AddRowDWGCZJHZB(dt, "FGCF", "1", "分部分项工程费", ref hj);
                this.AddRowDWGCZJHZB(dt, "CSXMF", "2", "措施项目费", ref hj);
                this.AddRowDWGCZJHZB(dt, "QTXMF", "3", "其他项目费", ref hj);
                this.AddRowDWGCZJHZB(dt, "GF", "4", "规费", ref hj);
                this.AddRowDWGCZJHZB(dt, "SJ", "5", "税金", ref hj);
                //合计
                DataRow rowhj = dt.NewRow();
                rowhj["XH"] = string.Empty;
                rowhj["DWGCMC"] = "合计";
                rowhj["ZJ"] = hj;
                dt.Rows.Add(rowhj);
            }
        }
        /// <summary>
        /// 2.单位工程造价汇总表（详细）
        /// </summary>
        public void DWGCZJHZBXX()
        {
            if (this.ReportSource.Tables.Contains("DWGCZJHZBXX"))
            {
                DataTable dt = this.ReportSource.Tables["DWGCZJHZBXX"];
                DataRow[] drs = base.StructSource.ModelMetaanalysis.Select(string.Format("UnID={0}", this.UnID), "Number", DataViewRowState.CurrentRows);
                foreach (DataRow r in drs)
                {
                    DataRow row = dt.NewRow();
                    row["XH"] = r["Number"];
                    row["DWGCMC"] = r["NAME"];
                    row["ZJ"] = this.Formart(r["Price"]);
                    dt.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// 3.分部分项工程量清单（计价表,清单表）
        /// </summary>
        private void FBFXGCLQD()
        {
            if (this.ReportSource.Tables.Contains("FBFXGCLQD"))
            {
                DataTable dt = this.ReportSource.Tables["FBFXGCLQD"];
                DataRow[] drs = base.StructSource.ModelSubSegments.Select(string.Format("LB='清单' AND UnID={0}", this.UnID), "XH", DataViewRowState.CurrentRows);
                foreach (DataRow item in drs)
                {
                    if (item["SC"].Equals(true))
                    {
                        DataRow row = dt.NewRow();
                        row["XH"] = item["XH"];
                        row["XMBM"] = item["XMBM"];
                        row["XMMC"] = item["XMMC"];
                        row["JLDW"] = item["DW"];
                        row["GCSL"] = this.Formart(item["GCL"], 4);
                        row["ZHDJ"] = this.Formart(item["ZHDJ"]);
                        row["HJ"] = this.Formart(item["ZHHJ"]);
                        dt.Rows.Add(row);
                    }
                }
            }
        }
        /// <summary>
        /// 4.措施项目清单（计价表,清单表）
        /// </summary>
        public void CSXMQD()
        {
            if (this.ReportSource.Tables.Contains("CSXMQD"))
            {
                DataTable dt = this.ReportSource.Tables["CSXMQD"];
                DataRow[] drs = base.StructSource.ModelMeasures.Select(string.Format("LB='清单' AND UnID={0}", this.UnID), "XH", DataViewRowState.CurrentRows);
                foreach (DataRow item in drs)
                {
                    if (item["SC"].Equals(true))
                    {
                        DataRow row = dt.NewRow();
                        row["XH"] = item["XH"];
                        //row["XMBM"] = item["XMBM"];
                        row["XMMC"] = item["XMMC"];
                        row["JLDW"] = item["DW"];
                        row["GCSL"] = this.Formart(item["GCL"], 4);
                        row["ZHDJ"] = this.Formart(item["ZHDJ"]);
                        row["HJ"] = this.Formart(item["ZHHJ"]);
                        dt.Rows.Add(row);
                    }
                }
            }
        }
        /// <summary>
        /// 5.其他项目清单（计价表,清单表）
        /// </summary>
        public void QTXMQD()
        {
            if (this.ReportSource.Tables.Contains("QTXMQD"))
            {
                DataTable dt = this.ReportSource.Tables["QTXMQD"];
                DataRow[] drs = base.StructSource.ModelOtherProject.Select(string.Format("UnID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows);
                foreach (DataRow r in drs)
                {
                    DataRow row = dt.NewRow();
                    row["XH"] = r["Number"];
                    row["XMMC"] = r["Name"];
                    row["JLDW"] = r["Unit"];
                    row["GCSL"] = this.Formart(r["Quantities"], 4);
                    row["ZHDJ"] = this.Formart(r["Unitprice"]);
                    row["HJ"] = this.Formart(r["Combinedprice"]);
                    dt.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// 6.计日工（计价表,清单表）
        /// </summary>
        public void JRG()
        {
            if (this.ReportSource.Tables.Contains("JRG"))
            {
                DataTable dt = this.ReportSource.Tables["JRG"];
                this.AddRowJRGJCB(dt, "Feature='JRGRG'", "一", "人工", "项");
                this.AddRowJRGJCB(dt, "Feature='JRGCL'", "二", "材料", "项");
                this.AddRowJRGJCB(dt, "Feature='JRGJX'", "三", "机械", "项");
                //其它
                DataRow dr_JRG = base.StructSource.ModelOtherProject.Select(string.Format("Feature='JRG' AND UnID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
                if (dr_JRG != null)
                {
                    DataRow[] dr_JRGQT = base.StructSource.ModelOtherProject.Select(string.Format("ParentID='{0}' AND UnID={1}", dr_JRG["ID"], this.UnID), string.Empty, DataViewRowState.CurrentRows);
                    int i = 3;
                    foreach (DataRow item in dr_JRGQT)
                    {
                        if (item["Feature"].ToString() != "JRGRG" && item["Feature"].ToString() != "JRGCL" && item["Feature"].ToString() != "JRGJX")
                        {
                            i++;
                            string m_Condition = string.Format("ID='{0}'", item["ID"].ToString());
                            this.AddRowJRGJCB(dt, m_Condition, ToolKit.NumToCNum(i, false), item["Name"].ToString(), item["Unit"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 7.总承包服务费（计价表,清单表）
        /// </summary>
        public void ZCBFWF()
        {
            if (this.ReportSource.Tables.Contains("ZCBFWF"))
            {
                DataTable dt = this.ReportSource.Tables["ZCBFWF"];
                decimal m_hj = 0m;
                this.AddRowZCBFWFJJB(dt, "Feature='ZCBFWF'", "一", "总承包服务费", "项", ref m_hj);
                this.AddRowZCBFWFJJB(dt, "Feature='FBGLFWF'", "1", "发包人发包专业工程管理服务费", "项", ref m_hj);
                this.AddRowZCBFWFJJB(dt, "Feature='FBRBGF'", "2", "发包人供应材料、设备保管费", "项", ref m_hj);
                //其它
                DataRow dr_QT = base.StructSource.ModelOtherProject.Select(string.Format("Feature='ZCBFWF' AND UnID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
                if (dr_QT != null)
                {
                    DataRow[] drqt = base.StructSource.ModelOtherProject.Select(string.Format("ParentID= '{0}'  AND UnID={1}", dr_QT["ID"], this.UnID), string.Empty, DataViewRowState.CurrentRows);
                    int i = 2;
                    foreach (DataRow item in drqt)
                    {
                        if (item["Feature"].ToString() != "FBGLFWF" && item["Feature"].ToString() != "FBRBGF")
                        {
                            i++;
                            DataRow rowqt = dt.NewRow();
                            rowqt["XH"] = i;
                            rowqt["XMMC"] = item["Name"];
                            rowqt["DW"] = item["Unit"];
                            rowqt["GCSL"] = this.Formart(item["Quantities"], 4);
                            rowqt["ZHDJ"] = this.Formart(item["Unitprice"]);
                            decimal m_HJ = this.Formart(item["Combinedprice"]);
                            rowqt["HJ"] = m_HJ;
                            m_hj += m_HJ;
                            dt.Rows.Add(rowqt);
                        }
                    }
                }
                ////合计
                //DataRow rowhj = dt.NewRow();
                //rowhj["XH"] = string.Empty;
                //rowhj["XMMC"] = "合计";
                //rowhj["DW"] = string.Empty;
                //rowhj["GCSL"] = string.Empty;
                //rowhj["ZHDJ"] = string.Empty;
                //rowhj["HJ"] = m_hj;
                //dt.Rows.Add(rowhj);
            }
        }
        /// <summary>
        /// 8.规费、税金项目清单计价表
        /// </summary>
        public void GFSJXMQD()
        {
            if (this.ReportSource.Tables.Contains("GFSJXMQD"))
            {
                DataTable dt = this.ReportSource.Tables["GFSJXMQD"];
                //规费
                decimal gfhj = 0m;
                this.AddRowZJXMQDJJB(dt, "GF", "一", "规费", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "SHBZ", "1", "社会保障费", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "LBTC", "1.1", "养老保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "SYBX", "1.2", "失业保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "YILBX", "1.3", "医疗保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "GSBX", "1.4", "工伤保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "CJBX", "1.5", "残疾人就业保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "NGBX", "1.6", "女工生育保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "ZFJJ", "2", "住房公积金", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "SHBX", "3", "危险作业意外伤害保险", ref gfhj);
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                DataRow rowgf = dt.NewRow();
                rowgf["XH"] = string.Empty;
                rowgf["XMMC"] = "规费合计";
                rowgf["JLDW"] = string.Empty;
                rowgf["SL"] = string.Empty;
                rowgf["JSJC"] = string.Empty;
                rowgf["FL"] = string.Empty;
                rowgf["ZHDJ"] = string.Empty;
                rowgf["HJ"] = gfhj;
                dt.Rows.Add(rowgf);

                //安全文明施工费
                decimal aqwmhj = 0m;
                this.AddRowZJXMQDJJB(dt, "AQWM", "二", "安全文明施工费：", ref aqwmhj);
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                DataRow rowaqwm = dt.NewRow();
                rowaqwm["XH"] = string.Empty;
                rowaqwm["XMMC"] = "安全文明施工措施费合计";
                rowaqwm["JSJC"] = string.Empty;
                rowaqwm["FL"] = string.Empty;
                rowaqwm["JLDW"] = string.Empty;
                rowaqwm["SL"] = string.Empty;
                rowaqwm["ZHDJ"] = string.Empty;
                rowaqwm["HJ"] = aqwmhj;
                dt.Rows.Add(rowaqwm);

                //税金
                decimal sjhj = 0m;
                this.AddRowZJXMQDJJB(dt, "SJ", "三", "税金：", ref sjhj);
                this.AddRowZJXMQDJJB(dt, string.Empty, "1", "营业税", ref sjhj);
                this.AddRowZJXMQDJJB(dt, string.Empty, "2", "城市维护建设税", ref sjhj);
                this.AddRowZJXMQDJJB(dt, string.Empty, "3", "教育费附加", ref sjhj);
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                DataRow rowsj = dt.NewRow();
                rowsj["XH"] = string.Empty;
                rowsj["XMMC"] = "税金合计";
                rowsj["JSJC"] = string.Empty;
                rowsj["FL"] = string.Empty;
                rowsj["JLDW"] = string.Empty;
                rowsj["SL"] = string.Empty;
                rowsj["ZHDJ"] = string.Empty;
                rowsj["HJ"] = sjhj.ToString("F2");
                dt.Rows.Add(rowsj);
            }
        }
        /// <summary>
        /// 9.工程量清单综合单价分析表
        /// </summary>
        public void GCLQDZHDJFXB()
        {
            if (this.ReportSource.Tables.Contains("GCLQDZHDJFXB"))
            {
                DataTable dt = this.ReportSource.Tables["GCLQDZHDJFXB"];
                DataRow[] qd_drs = base.StructSource.ModelSubSegments.Select(string.Format("LB='清单' AND UnID={0}", this.UnID), "XH", DataViewRowState.CurrentRows);
                foreach (DataRow info in qd_drs)
                {
                    if (info["SC"].Equals(true))
                    {
                        DataRow row = dt.NewRow();
                        row["XH"] = info["XH"];
                        row["XMBM"] = info["XMBM"];
                        row["XMMC"] = info["XMMC"];
                        row["JLDW"] = info["DW"];
                        DataRow[] zm_drs = base.StructSource.ModelSubSegments.Select(string.Format("LB='子目' AND PID={0} AND UnID={1} AND SC='True'", info["ID"].ToString(), this.UnID), string.Empty, DataViewRowState.CurrentRows);
                        foreach (DataRow item in zm_drs)
                        {
                            row["ZJYJ"] += (item["XMBM"].ToString() + "\n");
                        }
                        row["RGF"] = this.Formart(info["RGFDJ"]);
                        row["CLF"] = this.Formart(info["CLFDJ"]);
                        row["JXF"] = this.Formart(info["JXFDJ"]);
                        row["ZCF"] = this.Formart(info["ZCFDJ"]);
                        row["SBF"] = this.Formart(info["SBFDJ"]);
                        row["FX"] = this.Formart(info["FXDJ"]);
                        row["GLF"] = this.Formart(info["GLFDJ"]);
                        row["LR"] = this.Formart(info["LRDJ"]);
                        row["HJ"] = this.Formart(info["ZJFDJ"]);
                        dt.Rows.Add(row);
                    }
                }
            }
        }
        /// <summary>
        /// 10.主要材料价格表
        /// </summary>
        public void ZYCLJG()
        {
            if (this.ReportSource.Tables.Contains("ZYCLJG"))
            {
                DataTable dt = this.ReportSource.Tables["ZYCLJG"];
                DataRow[] drs = this.m_Summary.Select("(LB='材料' OR LB='主材' OR LB='设备') AND IFSC='True'");
                int i = 0;
                foreach (DataRow info in drs)
                {
                    i++;
                    DataRow row = dt.NewRow();
                    row["XH"] = i;
                    row["CLBM"] = info["BH"];
                    row["CLMC"] = info["MC"];
                    row["DW"] = info["DW"];
                    row["SL"] = this.Formart(info["SL"], 4);
                    row["DJ"] = this.Formart(info["SCDJ"]);
                    row["HJ"] = this.Formart(ToolKit.ParseDecimal(info["SCDJ"]) * ToolKit.ParseDecimal(info["SL"]));
                    row["BZ"] = info["GLJBZ"];
                    dt.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// 11.分部分项工程量综合单价分析表一
        /// </summary>
        public void FBFXGCLZHDJFXB()
        {
            if (this.ReportSource.Tables.Contains("FBFXGCLZHDJFXB"))
            {
                DataTable dt = this.ReportSource.Tables["FBFXGCLZHDJFXB"];
                DataRow[] qd_drs = base.StructSource.ModelSubSegments.Select(string.Format("LB='清单' AND SC='True' AND UnID={0} ", this.UnID), "XH", DataViewRowState.CurrentRows);
                foreach (DataRow info in qd_drs)
                {
                    this.AddRowFBFXGCLZHDJFXBY(dt, info);
                    DataRow[] zm_drs = base.StructSource.ModelSubSegments.Select(string.Format("LB='子目' AND SC='True' AND PID={0}  AND UnID={1}", info["ID"], this.UnID), string.Empty, DataViewRowState.CurrentRows);
                    foreach (DataRow item in zm_drs)
                    {
                        this.AddRowFBFXGCLZHDJFXBY(dt, item);
                    }
                }
            }
        }
        /// <summary>
        /// 12.措施项目费(综合单价)分析表
        /// </summary>
        public void CSXMZHDJFXB()
        {
            if (this.ReportSource.Tables.Contains("CSXMZHDJFXB"))
            {
                DataTable dt = this.ReportSource.Tables["CSXMZHDJFXB"];
                DataRow[] qd_drs = base.StructSource.ModelMeasures.Select(string.Format("LB='清单' AND SC='True' AND UnID={0}", this.UnID), "XH", DataViewRowState.CurrentRows);
                foreach (DataRow info in qd_drs)
                {
                    this.AddRowCSXMFZHDJFXB(dt, info);
                    DataRow[] zm_drs = base.StructSource.ModelMeasures.Select(string.Format("LB='子目' AND SC='True' AND PID={0}  AND UnID={1}", info["ID"], this.UnID), string.Empty, DataViewRowState.CurrentRows);
                    foreach (DataRow item in zm_drs)
                    {
                        this.AddRowCSXMFZHDJFXB(dt, item);
                    }
                }
            }
        }
        /// <summary>
        /// 13.甲供材料、设备数量及单价明细表（计价表,清单表）
        /// </summary>
        public void JGSBSLDJMXB()
        {
            if (this.ReportSource.Tables.Contains("JGSBSLDJMXB"))
            {
                DataTable dt = this.ReportSource.Tables["JGSBSLDJMXB"];
                DataRow[] jgcl = this.m_Summary.Select("YTLB='甲供材料'", "BH");
                int i = 0;
                foreach (DataRow info in jgcl)
                {
                    i++;
                    DataRow row = dt.NewRow();
                    row["XH"] = i;
                    row["CLBM"] = info["BH"];
                    row["CLMC"] = info["MC"];
                    row["DW"] = info["DW"];
                    row["SL"] = this.Formart(info["SL"], 4);
                    row["DJ"] = this.Formart(info["SCDJ"]);
                    row["HJ"] = this.Formart(ToolKit.ParseDecimal(info["SCDJ"]) * ToolKit.ParseDecimal(info["SL"]));
                    dt.Rows.Add(row);
                }
            }
        }
        ///<summary>
        /// 14.材料、设备暂估单价明细表（计价表,清单表）
        ///</summary>
        public void CLSBZGDJMXB()
        {
            if (this.ReportSource.Tables.Contains("CLSBZGDJMXB"))
            {
                DataTable dt = this.ReportSource.Tables["CLSBZGDJMXB"];
                IEnumerable<DataRow> zdcl = this.m_Summary.Select("YTLB='暂定价材料'", "BH");
                int i = 0;
                foreach (DataRow info in zdcl)
                {
                    i++;
                    DataRow row = dt.NewRow();
                    row["XH"] = i;
                    row["CLBM"] = info["BH"];
                    row["CLMC"] = info["MC"];
                    row["DW"] = info["DW"];
                    row["ZGDJ"] = this.Formart(info["SCDJ"]);
                    row["ZGHJ"] = this.Formart(ToolKit.ParseDecimal(info["SCDJ"]) * ToolKit.ParseDecimal(info["SL"]));
                    dt.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// 15.三材表
        /// </summary>
        public void SDC()
        {
            if (this.ReportSource.Tables.Contains("SDC"))
            {
                _Methods_Quantity m_Methods_Quantity = new _Methods_Quantity();
                DataTable dt = this.ReportSource.Tables["SDC"];
                DataTable dtsdc = m_Methods_Quantity.GetSDC(this.m_Summary);
                this.AddRowSDC(dt, dtsdc, "-1");
            }
        }
        /// <summary>
        /// 16.评标指定材料价格表
        /// </summary>
        public void PBZDCLJGB()
        {
            if (this.ReportSource.Tables.Contains("PBZDCLJGB"))
            {
                DataTable dt = this.ReportSource.Tables["PBZDCLJGB"];
                DataRow[] jgcl = this.m_Summary.Select("YTLB='评标指定材料'", "BH");
                int i = 0;
                foreach (DataRow info in jgcl)
                {
                    i++;
                    DataRow row = dt.NewRow();
                    row["XH"] = i;
                    row["CLBM"] = info["BH"];
                    row["CLMC"] = info["MC"];
                    row["DW"] = info["DW"];
                    row["XHL"] = this.Formart(info["SL"], 4);
                    row["DJ"] = this.Formart(info["SCDJ"]);
                    row["HJ"] = this.Formart(ToolKit.ParseDecimal(info["SCDJ"]) * ToolKit.ParseDecimal(info["SL"]));
                    dt.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// 17.主材、设备表
        /// </summary>
        public void ZCSBB()
        {
            if (this.ReportSource.Tables.Contains("ZCSBB"))
            {
                DataTable dt = this.ReportSource.Tables["ZCSBB"];
                DataRow[] jgcl = this.m_Summary.Select("LB='主材' OR LB='设备'", "BH");
                int i = 0;
                foreach (DataRow info in jgcl)
                {
                    i++;
                    DataRow row = dt.NewRow();
                    row["XH"] = i;
                    row["CLBM"] = info["BH"];
                    row["CLMC"] = info["MC"];
                    row["DW"] = info["DW"];
                    row["XHL"] = this.Formart(info["SL"], 4);
                    row["DJ"] = this.Formart(info["SCDJ"]);
                    row["HJ"] = this.Formart(ToolKit.ParseDecimal(info["SCDJ"]) * ToolKit.ParseDecimal(info["SL"]));
                    dt.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// 18.暂列金额明细表
        /// </summary>
        public void ZLJGMXB()
        {
            if (this.ReportSource.Tables.Contains("ZLJGMXB"))
            {
                DataTable dt = this.ReportSource.Tables["ZLJGMXB"];
                DataRow rowzl = base.StructSource.ModelOtherProject.Select(string.Format("Feature='ZLJE' AND UnID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
                DataRow row = dt.NewRow();
                row["XH"] = "一";
                row["XMMC"] = "暂列金额";
                row["JLDW"] = "项";
                row["ZDJE"] = string.Empty;
                dt.Rows.Add(row);
                if (rowzl != null)
                {
                    row["JLDW"] = rowzl["Unit"];
                    row["ZDJE"] = this.Formart(rowzl["Combinedprice"]);
                    AddRowZLJGMXB(dt, rowzl["ID"].ToString(), 0);
                }
            }
        }
        /// <summary>
        /// 19.专业工程暂估价明细表
        /// </summary>
        public void ZYGCZGJMXB()
        {
            if (this.ReportSource.Tables.Contains("ZYGCZGJMXB"))
            {
                DataTable dt = this.ReportSource.Tables["ZYGCZGJMXB"];
                DataRow rowzl = base.StructSource.ModelOtherProject.Select(string.Format("Feature='ZYGCZGJ' AND UnID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
                DataRow row = dt.NewRow();
                row["XH"] = "一";
                row["XMMC"] = "专业工程暂估价";
                row["JLDW"] = "项";
                row["ZGDJ"] = string.Empty;
                dt.Rows.Add(row);
                if (rowzl != null)
                {
                    row["JLDW"] = rowzl["Unit"];
                    row["ZGDJ"] = this.Formart(rowzl["Combinedprice"]);
                    AddRowZYGCZGJMXB(dt, rowzl["ID"].ToString(), 0);
                }
            }
        }
        /// <summary>
        /// 20.规费、税金项目清单计价表（清单）
        /// </summary>
        public void GFSJXMQDHJ()
        {
            if (this.ReportSource.Tables.Contains("GFSJXMQDHJ"))
            {
                DataTable dt = this.ReportSource.Tables["GFSJXMQDHJ"];
                //规费
                decimal gfhj = 0m;
                this.AddRowZJXMQDJJB(dt, "GF", "一", "规费", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "SHBZ", "1", "社会保障费", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "LBTC", "1.1", "养老保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "SYBX", "1.2", "失业保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "YILBX", "1.3", "医疗保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "GSBX", "1.4", "工伤保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "CJBX", "1.5", "残疾人就业保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "NGBX", "1.6", "女工生育保险", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "ZFJJ", "2", "住房公积金", ref gfhj);
                this.AddRowZJXMQDJJB(dt, "SHBX", "3", "危险作业意外伤害保险", ref gfhj);
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());

                //安全文明施工费
                decimal aqwmhj = 0m;
                this.AddRowZJXMQDJJB(dt, "AQWM", "二", "安全文明施工费：", ref aqwmhj);
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());

                //税金
                decimal sjhj = 0m;
                this.AddRowZJXMQDJJB(dt, "SJ", "三", "税金：", ref sjhj);
                this.AddRowZJXMQDJJB(dt, string.Empty, "1", "营业税", ref sjhj);
                this.AddRowZJXMQDJJB(dt, string.Empty, "2", "城市维护建设税", ref sjhj);
                this.AddRowZJXMQDJJB(dt, string.Empty, "3", "教育费附加", ref sjhj);
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
            }
        }
        /// <summary>
        /// 21.填空报表数据（所有填空报表）
        /// </summary>
        public void TKBB()
        {
            if (this.ReportSource.Tables.Contains("TKBB"))
            {
                if (this.StructSource.ModelProject.Rows.Count > 0)
                {
                    DataTable dt = this.ReportSource.Tables["TKBB"];
                    DataRow dr_dw = this.StructSource.ModelProject.Select(string.Format("ID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
                    if (dr_dw != null)
                    {
                        DataRow row = dt.NewRow();
                        row["GCMC"] = dr_dw["Name"];
                        DataRow dr = base.StructSource.ModelMetaanalysis.Select(string.Format("Feature='ZZJ' AND UnID={0}", this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
                        if (dr != null)
                        {
                            if (dr["Price"].ToString().Trim() != string.Empty)
                            {
                                decimal m_zzj = ToolKit.ParseDecimal(dr["Price"]);
                                row["XXZZJ"] = "￥" + m_zzj.ToString("N2");
                                row["DXZZJ"] = ToolKit.NumToCNum(ToolKit.ParseDecimal(m_zzj.ToString("N2")), true);
                            }
                        }
                        else
                        {
                            row["XXZZJ"] = "￥0.00";
                            row["DXZZJ"] = "无";
                        }

                        row["ZBBZR"] = dr_dw["PlaitName"];//招标编制人
                        row["ZBFHR"] = dr_dw["ReviewName"];//招标复核人
                        if (dr_dw["PlaitDate"] is DateTime)
                        {
                            DateTime zbbzrq = Convert.ToDateTime(dr_dw["PlaitDate"]);
                            row["ZBBZRQY"] = zbbzrq.Year.ToString();//招标编制日期(年)
                            row["ZBBZRQM"] = zbbzrq.Month.ToString();//招标编制日期(月)
                            row["ZBBZRQD"] = zbbzrq.Day.ToString();//招标编制日期(日)
                        }
                        if (dr_dw["ReviewDate"] is DateTime)
                        {
                            DateTime zbfhrq = Convert.ToDateTime(dr_dw["ReviewDate"]);
                            row["ZBFHRQY"] = zbfhrq.Year.ToString();//招标复核日期(年)
                            row["ZBFHRQM"] = zbfhrq.Month.ToString();//招标复核日期(月)
                            row["ZBFHRQD"] = zbfhrq.Day.ToString();//招标复核日期(日)
                        }

                        dt.Rows.Add(row);
                    }
                }
            }
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 单位工程造价汇总表 增加行
        /// </summary>
        /// <param name="p_dt">数据集合</param>
        /// <param name="p_Feature">绑定字段</param>
        /// <param name="p_XH">序号</param>
        /// <param name="p_DWGCMC">名称</param>
        /// <param name="p_hj">合计</param>
        private void AddRowDWGCZJHZB(DataTable p_dt, string p_Feature, string p_XH, string p_DWGCMC, ref decimal p_hj)
        {
            DataRow dr = base.StructSource.ModelMetaanalysis.Select(string.Format("Feature='{0}' AND UnID={1}", p_Feature, this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
            DataRow row = p_dt.NewRow();
            row["XH"] = p_XH;
            row["DWGCMC"] = p_DWGCMC;
            row["ZJ"] = string.Empty;
            if (dr != null)
            {
                decimal m_hj = this.Formart(dr["Price"]);
                row["ZJ"] = m_hj;
                p_hj += m_hj;
            }
            p_dt.Rows.Add(row);
        }
        /// <summary>
        /// 计日工计价表 增加行
        /// </summary>
        /// <param name="p_dt">数据集合</param>
        /// <param name="p_Condition">查询条件</param>
        /// <param name="p_XH">序号</param>
        /// <param name="p_XMMC">名称</param>
        /// <param name="p_DW">单位</param>
        private void AddRowJRGJCB(DataTable p_dt, string p_Condition, string p_XH, string p_XMMC, string p_DW)
        {
            DataRow dr = base.StructSource.ModelOtherProject.Select(string.Format("{0} AND UnID={1}", p_Condition, this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
            DataRow row = p_dt.NewRow();
            row["XH"] = p_XH;
            row["XMMC"] = p_XMMC;
            row["DW"] = p_DW;
            row["ZDSL"] = string.Empty;
            row["ZHDJ"] = string.Empty;
            row["HJ"] = string.Empty;
            if (dr != null)
            {
                row["DW"] = dr["Unit"];
                row["ZDSL"] = this.Formart(dr["Quantities"], 4);
                row["ZHDJ"] = this.Formart(dr["Unitprice"]);
                row["HJ"] = this.Formart(dr["Combinedprice"]);
            }
            p_dt.Rows.Add(row);
            if (dr != null)
            {
                this.AddRowJRGJCBZX(p_dt, dr["ID"].ToString(), 0);
            }
        }
        /// <summary>
        /// 递归插入计日工计价表子项
        /// </summary>
        /// <param name="p_dt">集合</param>
        /// <param name="p_ParentID">父ID</param>
        /// <param name="p_cs">层数</param>
        private void AddRowJRGJCBZX(DataTable p_dt, string p_ParentID, int p_i)
        {
            DataRow[] drrgs = base.StructSource.ModelOtherProject.Select(string.Format("ParentID= '{0}' AND UnID={1}", p_ParentID, this.UnID), string.Empty, DataViewRowState.CurrentRows);
            int i = p_i;
            foreach (DataRow item in drrgs)
            {
                i++;
                DataRow row = p_dt.NewRow();
                row["XH"] = i;
                row["XMMC"] = item["Name"];
                row["DW"] = item["Unit"];
                row["ZDSL"] = item["Quantities"];
                row["ZHDJ"] = this.Formart(item["Unitprice"]);
                row["HJ"] = this.Formart(item["Combinedprice"]);
                p_dt.Rows.Add(row);
                this.AddRowJRGJCBZX(p_dt, item["ID"].ToString(), i);
            }
        }
        /// <summary>
        /// 总承包服务费计价表 增加行
        /// </summary>
        /// <param name="p_dt"></param>
        /// <param name="p_Condition"></param>
        /// <param name="p_XH"></param>
        /// <param name="p_XMMC"></param>
        /// <param name="p_dw"></param>
        private void AddRowZCBFWFJJB(DataTable p_dt, string p_Condition, string p_XH, string p_XMMC, string p_DW, ref decimal p_HJ)
        {
            //发包人供应材料、设备保管费
            DataRow dr = base.StructSource.ModelOtherProject.Select(string.Format("{0} AND UnID={1}", p_Condition, this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
            DataRow row = p_dt.NewRow();
            row["XH"] = p_XH;
            row["XMMC"] = p_XMMC;
            row["DW"] = p_DW;
            row["GCSL"] = string.Empty;
            row["ZHDJ"] = string.Empty;
            row["HJ"] = string.Empty;
            if (dr != null)
            {
                row["DW"] = dr["Unit"];
                row["GCSL"] = this.Formart(dr["Quantities"], 4);
                row["ZHDJ"] = this.Formart(dr["Unitprice"]);
                decimal m_HJ = this.Formart(dr["Combinedprice"]);
                row["HJ"] = m_HJ;
                p_HJ += m_HJ;
            }
            p_dt.Rows.Add(row);
        }
        /// <summary>
        /// 增加规费、税金项目清单计价表
        /// </summary>
        /// <param name="p_dt">数据集合</param>
        /// <param name="p_Feature">绑定字段</param>
        /// <param name="p_xh">序号</param>
        /// <param name="p_xmmc">名称</param>
        /// <param name="p_hj">合价</param>
        private void AddRowZJXMQDJJB(DataTable p_dt, string p_Feature, string p_xh, string p_xmmc, ref decimal p_hj)
        {
            DataRow dr = null;
            if (p_Feature != string.Empty)
            {
                dr = base.StructSource.ModelMetaanalysis.Select(string.Format("Feature='{0}' AND UnID={1}", p_Feature, this.UnID), string.Empty, DataViewRowState.CurrentRows).FirstOrDefault();
            }
            DataRow row = p_dt.NewRow();
            row["XH"] = p_xh;
            row["XMMC"] = p_xmmc;
            row["JSJC"] = string.Empty;
            row["FL"] = string.Empty;
            row["JLDW"] = string.Empty;
            row["SL"] = string.Empty;
            row["ZHDJ"] = string.Empty;
            row["HJ"] = string.Empty;
            if (dr != null)
            {
                row["JSJC"] = dr["Calculation"];
                row["FL"] = this.Formart(dr["Coefficient"]);
                decimal m_hj = this.Formart(dr["Price"]);
                row["HJ"] = m_hj;
                p_hj += m_hj;
            }
            p_dt.Rows.Add(row);
        }
        /// <summary>
        /// 分部分项工程量综合单价分析表一(增加行)
        /// </summary>
        /// <param name="p_dt">数据集合</param>
        /// <param name="p_info">对象</param>
        private void AddRowFBFXGCLZHDJFXBY(DataTable p_dt, DataRow p_info)
        {
            DataRow row = p_dt.NewRow();
            row["XH"] = p_info["XH"].Equals(0) ? string.Empty : p_info["XH"].ToString();
            row["XMBM"] = p_info["XMBM"];
            row["XMMC"] = p_info["XMMC"];
            row["JLDW"] = p_info["DW"];
            row["GCSL"] = this.Formart(p_info["GCL"], 4);
            row["LB"] = p_info["LB"];
            row["GCNR"] = string.Empty;
            row["RGF"] = this.Formart(p_info["RGFDJ"]);
            row["CLF"] = this.Formart(p_info["CLFDJ"]);
            row["JXF"] = this.Formart(p_info["JXFDJ"]);
            row["ZCF"] = this.Formart(p_info["ZCFDJ"]);
            row["SBF"] = this.Formart(p_info["SBFDJ"]);
            row["FX"] = this.Formart(p_info["FXDJ"]);
            row["GLF"] = this.Formart(p_info["GLFDJ"]);
            row["LR"] = this.Formart(p_info["LRDJ"]);
            row["ZHDJ"] = this.Formart(p_info["ZHDJ"]);
            p_dt.Rows.Add(row);
        }
        /// <summary>
        /// 措施项目费(综合单价)分析表(增加行)
        /// </summary>
        /// <param name="p_dt">数据集合</param>
        /// <param name="p_info">对象</param>
        private void AddRowCSXMFZHDJFXB(DataTable p_dt, DataRow p_info)
        {
            DataRow row = p_dt.NewRow();
            row["XH"] = p_info["XH"].Equals(0) ? string.Empty : p_info["XH"].ToString();
            row["XMBM"] = p_info["XMBM"];
            row["XMMC"] = p_info["XMMC"];
            row["JLDW"] = p_info["DW"];
            row["RGF"] = this.Formart(p_info["RGFDJ"]);
            row["CLF"] = this.Formart(p_info["CLFDJ"]);
            row["JXF"] = this.Formart(p_info["JXFDJ"]);
            row["FX"] = this.Formart(p_info["FXDJ"]);
            row["GLF"] = this.Formart(p_info["GLFDJ"]);
            row["LR"] = this.Formart(p_info["LRDJ"]);
            row["ZHDJ"] = this.Formart(p_info["ZHDJ"]);
            p_dt.Rows.Add(row);
        }
        /// <summary>
        /// 三大材 增加行
        /// </summary>
        /// <param name="p_dt"></param>
        /// <param name="p_sdcdt"></param>
        /// <param name="p_ID"></param>
        private void AddRowSDC(DataTable p_dt, DataTable p_sdcdt, string p_ID)
        {
            int i = 0;
            DataRow[] drs = p_sdcdt.Select(string.Format("ParentID='{0}'", p_ID), "ID");
            foreach (DataRow item in drs)
            {
                i++;
                DataRow row = p_dt.NewRow();
                row["CLBM"] = item["BH"];
                row["CLMC"] = item["MC"];
                row["DW"] = item["DW"];
                row["XHL"] = this.Formart(item["SLH"], 4);
                row["DJ"] = this.Formart(item["SCDJ"]);
                row["HJ"] = this.Formart(item["SCHJ"]);
                p_dt.Rows.Add(row);
                this.AddRowSDC(p_dt, p_sdcdt, item["ID"].ToString());
            }
        }
        /// <summary>
        /// 递归插入暂列金额明细表子项
        /// </summary>
        /// <param name="p_dt">集合</param>
        /// <param name="p_ParentID">父ID</param>
        /// <param name="p_cs">层数</param>
        private void AddRowZLJGMXB(DataTable p_dt, string p_ParentID, int p_i)
        {
            DataRow[] drrgs = base.StructSource.ModelOtherProject.Select(string.Format("ParentID= '{0}' AND UnID={1}", p_ParentID, this.UnID), string.Empty, DataViewRowState.CurrentRows);
            int i = p_i;
            foreach (DataRow item in drrgs)
            {
                i++;
                DataRow row = p_dt.NewRow();
                row["XH"] = i;
                row["XMMC"] = item["Name"];
                row["JLDW"] = item["Unit"];
                row["ZDJE"] = this.Formart(item["Combinedprice"]);
                p_dt.Rows.Add(row);
                this.AddRowZLJGMXB(p_dt, item["ID"].ToString(), i);
            }
        }
        /// <summary>
        /// 递归插入专业工程暂估价明细表子项
        /// </summary>
        /// <param name="p_dt">集合</param>
        /// <param name="p_ParentID">父ID</param>
        /// <param name="p_cs">层数</param>
        private void AddRowZYGCZGJMXB(DataTable p_dt, string p_ParentID, int p_i)
        {
            DataRow[] drrgs = base.StructSource.ModelOtherProject.Select(string.Format("ParentID= '{0}' AND UnID={1}", p_ParentID, this.UnID), string.Empty, DataViewRowState.CurrentRows);
            int i = p_i;
            foreach (DataRow item in drrgs)
            {
                i++;
                DataRow row = p_dt.NewRow();
                row["XH"] = i;
                row["XMMC"] = item["Name"];
                row["JLDW"] = item["Unit"];
                row["ZGDJ"] = this.Formart(item["Combinedprice"]);
                p_dt.Rows.Add(row);
                this.AddRowZYGCZGJMXB(p_dt, item["ID"].ToString(), i);
            }
        }
        #endregion
    }
}
