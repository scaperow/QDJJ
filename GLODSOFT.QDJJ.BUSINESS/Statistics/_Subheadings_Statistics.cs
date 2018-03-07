/*
 为子目处理的统计数据源
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;
using System.Collections;

using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    [Serializable]
    public class _Subheadings_Statistics
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _Subheadings_Statistics(_Entity_SubInfo p_info, _UnitProject p_Unit)
        {
            this.Unit = p_Unit;
            this.Current = p_info;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _Subheadings_Statistics(_UnitProject p_Unit)
        {
            this.Unit = p_Unit;
        }

        private _UnitProject m_Unit = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary>
        public _UnitProject Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }
        private _Entity_SubInfo m_Current = null;
        /// <summary>
        /// 当前操作的对象
        /// </summary>
        public _Entity_SubInfo Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        /// <summary>
        /// 临时子目统计参数表
        /// </summary>
        private ResultValue m_ResultValue;

        /// <summary>
        /// 请求子目统计操作
        /// </summary>
        public void Begin()
        {
            this.CalculateBasicData();
            this.FBegin();

        }

        /// <summary>
        /// 子目取费计算的公共方法
        /// </summary>
        public void FBegin()
        {
            this.CalculateParentTBJE_BDJE();
            this.TransferResults();
        }

        public void Calculate()
        {
            this.CalculateBasicData();
            this.CalculateParentTBJE_BDJE();
            this.TransferResults();
        }

        /// <summary>
        /// 计算临时参数表
        /// </summary>
        public void ParametersTableCalculate()
        {
            this.CalculateBasicData();
        }

        /// <summary>
        /// 计算基础数据
        /// </summary>
        public void CalculateBasicData()
        {
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} AND SSLB={1}", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
            //定额合价统计
            this.DEHJ(drs);
            //市场合价统计
            this.SCHJ(drs);
            //其他统计
            this.Other(drs);
            //计算百分号
            this.JSBFH(drs);
            //价差统计
            this.JCDJ(drs);
            //差价统计
            this.CJDJ(drs);
            //赋值
            this.Assignment();
        }

        /// <summary>
        /// 其他统计
        /// </summary>
        /// <param name="table"></param>
        private void Other(DataRow[] p_drs)
        {
            //工程量
            m_ResultValue.GCL = this.Current.GCL;
            //风险人材机
            m_ResultValue.FXRCJ = p_drs.Where(p => p["IFFX"].Equals(true)).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
            //吊装机械台班
            m_ResultValue.DZJXTB = p_drs.Where(p => p["LB"].Equals("吊装机械台班")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
            //混合机械费价差
            m_ResultValue.HHJXFJC = 0;
            foreach (DataRow item in p_drs)
            {
                if (item["LB"].Equals("机械") && item["DW"].Equals("工日"))
                {
                    if (item["ZCLB"].Equals("W"))
                    {
                        m_ResultValue.HHJXFJC += ToolKit.ParseDecimal(item["DJC"]) * ToolKit.ParseDecimal(item["XHL"]);
                    }
                    else
                    {
                        DataRow dr = item.GetParentRow("工料机-组成");
                        if (dr != null)
                        {
                            m_ResultValue.HHJXFJC += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["DJC"]) * ToolKit.ParseDecimal(item["XHL"]);
                        }
                    }
                }
            }
            //混合机械费单价
            m_ResultValue.HHJXFDJ = m_ResultValue.JXFDJ - (m_ResultValue.HHJXFJC);
        }

        /// <summary>
        /// 价差统计
        /// </summary>
        /// <param name="table"></param>
        private void JCDJ(DataRow[] p_drs)
        {
            m_ResultValue.JCDJ = p_drs.Where(p => !p["DJC"].Equals(0m)).Sum(p => ToolKit.ParseDecimal(p["DJC"]) * ToolKit.ParseDecimal(p["XHL"]));
            //人工费价差单价
            m_ResultValue.RGJCDJ = p_drs.Where(p => !p["DJC"].Equals(0m) && _Constant.rg.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DJC"]) * ToolKit.ParseDecimal(p["XHL"])) + m_ResultValue.HHJXFJC;
            //材料费价差单价
            m_ResultValue.CLJCDJ = p_drs.Where(p => !p["DJC"].Equals(0m) && _Constant.ddcl.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DJC"]) * ToolKit.ParseDecimal(p["XHL"]));
            //机械费价差单价
            m_ResultValue.JXJCDJ = p_drs.Where(p => !p["DJC"].Equals(0m) && _Constant.jx.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DJC"]) * ToolKit.ParseDecimal(p["XHL"])) - m_ResultValue.HHJXFJC;
        }
        /// <summary>
        /// 差价统计
        /// </summary>
        /// <param name="table"></param>
        private void CJDJ(DataRow[] p_drs)
        {
            ////差价单价
            //m_ResultValue.CJDJ = p_drs.Where(p => !p["JSDJC"].Equals(0m)).Sum(p => ToolKit.ParseDecimal(p["JSDJC"]) * ToolKit.ParseDecimal(p["XHL"]));
            ////人工费差价单价
            //m_ResultValue.RGCJDJ = p_drs.Where(p => !p["JSDJC"].Equals(0m) && _Constant.rg.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["JSDJC"]) * ToolKit.ParseDecimal(p["XHL"]));
            ////材料费差价单价
            //m_ResultValue.CLCJDJ = p_drs.Where(p => !p["JSDJC"].Equals(0m) && _Constant.ddcl.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["JSDJC"]) * ToolKit.ParseDecimal(p["XHL"]));
            ////机械费差价单价
            //m_ResultValue.JXCJDJ = p_drs.Where(p => !p["JSDJC"].Equals(0m) && _Constant.jx.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["JSDJC"]) * ToolKit.ParseDecimal(p["XHL"]));
        }

        /// <summary>
        /// 定额合价统计
        /// </summary>
        /// <param name="table"></param>
        private void DEHJ(DataRow[] p_drs)
        {
            //定额人工费单价
            m_ResultValue.DERGFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.rg.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DEHJ"]));
            //定额材料费单价
            m_ResultValue.DECLFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.ddcl.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DEHJ"]));
            //定额机械费单价
            m_ResultValue.DEJXFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.jx.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DEHJ"]));
            //定额主材费单价
            m_ResultValue.DEZCFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.zc.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DEHJ"]));
            //定额设备费单价
            m_ResultValue.DESBFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.sb.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["DEHJ"]));
            //市场直接费单价
            m_ResultValue.DEZJFDJ = Convert.ToDecimal(m_ResultValue.DERGFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.DECLFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.DEJXFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.DESBFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.DEZCFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.FXRCJ.ToString("F2"));
        }

        /// <summary>
        /// 市场合价统计
        /// </summary>
        /// <param name="table"></param>
        private void SCHJ(DataRow[] p_drs)
        {
            m_ResultValue.RGFDJ = 0m;
            m_ResultValue.CLFDJ = 0m;
            m_ResultValue.JXFDJ = 0m;
            if (this.Current.LB.Equals("子目-增加费"))
            {
                DataRow drs = this.Unit.Property.IncreaseCosts.DataSource.Select(string.Format("ParentID = 0 AND Code='{0}'", this.Current.XMBM)).FirstOrDefault();
                if (drs != null)
                {
                    string str = "LB<>'子目-增加费'";
                    if (drs["location"].ToString() == "分部分项")
                    {
                        str = string.Format("PID={0} AND LB<>'子目-增加费'", this.Current.PID);
                    }
                    DataRow[] rgfdj_zmzjf = this.Unit.StructSource.ModelSubSegments.Select(str);
                    foreach (DataRow item in rgfdj_zmzjf)
                    {
                        DataRow rgfdj_Costs = this.Unit.StructSource.ModelIncreaseCosts.Select(string.Format("ZMID={0} AND DH='{1}'", item["ID"], this.Current.XMBM)).FirstOrDefault();
                        if (rgfdj_Costs == null)
                        {
                            m_ResultValue.RGFDJ += 0m;
                            m_ResultValue.RGFDJ += 0m;
                            m_ResultValue.RGFDJ += 0m;
                        }
                        else
                        {
                            m_ResultValue.RGFDJ += ToolKit.ParseDecimal(rgfdj_Costs["RGF"]);
                            m_ResultValue.CLFDJ += ToolKit.ParseDecimal(rgfdj_Costs["CLF"]);
                            m_ResultValue.JXFDJ += ToolKit.ParseDecimal(rgfdj_Costs["JXF"]);
                        }
                    }
                    //定额人工费单价
                    m_ResultValue.DERGFDJ = m_ResultValue.RGFDJ;
                    //定额材料费单价
                    m_ResultValue.DECLFDJ = m_ResultValue.CLFDJ;
                    //定额机械费单价
                    m_ResultValue.DEJXFDJ = m_ResultValue.JXFDJ;
                }
            }
            else
            {
                //市场人工费单价
                m_ResultValue.RGFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.rg.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
                //市场材料费单价
                m_ResultValue.CLFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.ddcl.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
                //市场机械费单价
                m_ResultValue.JXFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.jx.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
            }
            //市场主材费单价
            m_ResultValue.ZCFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.zc.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
            //市场设备费单价
            m_ResultValue.SBFDJ = p_drs.Where(p => p["ZCLB"].Equals("W") && _Constant.sb.Contains("'" + p["LB"] + "'")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"]));
            //市场直接费单价

            m_ResultValue.ZJFDJ = Convert.ToDecimal(m_ResultValue.RGFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.CLFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.JXFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.SBFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.ZCFDJ.ToString("F2")) + Convert.ToDecimal(m_ResultValue.FXRCJ.ToString("F2"));
            //用途类别定额单价、市场单价
            foreach (DataRow item in p_drs)
            {
                switch (item["YTLB"].ToString())
                {
                    case "甲供材料":
                        if (item["ZCLB"].Equals("W"))
                        {
                            m_ResultValue.DEJGCL += ToolKit.ParseDecimal(item["DEHJ"]);
                            m_ResultValue.JGCL += ToolKit.ParseDecimal(item["SCHJ"]);
                        }
                        else
                        {
                            DataRow dr = item.GetParentRow("工料机-组成");
                            if (dr != null)
                            {
                                m_ResultValue.DEJGCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["DEHJ"]);
                                m_ResultValue.JGCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["SCHJ"]);
                            }
                        }
                        break;
                    case "甲定乙供材料":
                        if (item["ZCLB"].Equals("W"))
                        {
                            m_ResultValue.DEYGCL += ToolKit.ParseDecimal(item["DEHJ"]);
                            m_ResultValue.YGCL += ToolKit.ParseDecimal(item["SCHJ"]);
                        }
                        else
                        {
                            DataRow dr = item.GetParentRow("工料机-组成");
                            if (dr != null)
                            {
                                m_ResultValue.DEYGCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["DEHJ"]);
                                m_ResultValue.YGCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["SCHJ"]);
                            }
                        }
                        break;
                    case "评标指定材料":
                        if (item["ZCLB"].Equals("W"))
                        {
                            m_ResultValue.DEPBZDCL += ToolKit.ParseDecimal(item["DEHJ"]);
                            m_ResultValue.PBZDCL += ToolKit.ParseDecimal(item["SCHJ"]);
                        }
                        else
                        {
                            DataRow dr = item.GetParentRow("工料机-组成");
                            if (dr != null)
                            {
                                m_ResultValue.DEPBZDCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["DEHJ"]);
                                m_ResultValue.PBZDCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["SCHJ"]);
                            }
                        }
                        break;
                    case "暂定价材料":
                        if (item["ZCLB"].Equals("W"))
                        {
                            m_ResultValue.DEZDJCL += ToolKit.ParseDecimal(item["DEHJ"]);
                            m_ResultValue.ZDJCL += ToolKit.ParseDecimal(item["SCHJ"]);
                        }
                        else
                        {
                            DataRow dr = item.GetParentRow("工料机-组成");
                            if (dr != null)
                            {
                                m_ResultValue.DEZDJCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["DEHJ"]);
                                m_ResultValue.ZDJCL += ToolKit.ParseDecimal(dr["XHL"]) * ToolKit.ParseDecimal(item["SCHJ"]);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 计算百分号材料合计
        /// </summary>
        /// <param name="p_list"></param>
        private void JSBFH(DataRow[] p_drs)
        {
            m_ResultValue.CLBFHHJ = 0m;
            m_ResultValue.JXBFHHJ = 0m;
            m_ResultValue.RGBFHHJ = 0m;
            decimal DECLBFHHJ = 0m;
            decimal DEJXBFHHJ = 0m;
            decimal DERGBFHHJ = 0m;
            decimal HHJXFDJHJ = 0m;
            DataRow m_TSInfo = p_drs.Where(p => p["YSBH"].Equals("11705") && p["LB"].ToString().Contains("%")).FirstOrDefault();
            if (m_TSInfo != null)
            {
                m_ResultValue.CLBFHHJ += p_drs.Where(p => p["BH"].Equals("10088") || p["BH"].Equals("10087") || p["BH"].Equals("10544")).Sum(p => ToolKit.ParseDecimal(p["SCHJ"])) * 0.01m * ToolKit.ParseDecimal(m_TSInfo["XHL"]);
                DECLBFHHJ += p_drs.Where(p => p["BH"].Equals("10088") || p["BH"].Equals("10087") || p["BH"].Equals("10544")).Sum(p => ToolKit.ParseDecimal(p["DEHJ"])) * 0.01m * ToolKit.ParseDecimal(m_TSInfo["XHL"]);
            }

            IEnumerable<DataRow> bfhlist = p_drs.Where(p => p["LB"].ToString().Contains("%") && !p["YSBH"].Equals("11705"));
            foreach (DataRow item in bfhlist)
            {
                switch (item["LB"].ToString())
                {
                    case "材料%":
                        m_ResultValue.CLBFHHJ += m_ResultValue.CLFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        DECLBFHHJ += m_ResultValue.DECLFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        break;
                    case "机械%":
                        m_ResultValue.JXFDJ += m_ResultValue.JXFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        DEJXBFHHJ += m_ResultValue.DEJXFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        HHJXFDJHJ += m_ResultValue.HHJXFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        break;
                    case "人工%":
                        m_ResultValue.RGFDJ += m_ResultValue.RGFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        DERGBFHHJ += m_ResultValue.DERGFDJ * ToolKit.ParseDecimal(item["XHL"]) * 0.01m;
                        break;
                    default:
                        break;
                }
            }
            m_ResultValue.RGFDJ += m_ResultValue.RGBFHHJ;
            m_ResultValue.CLFDJ += m_ResultValue.CLBFHHJ;
            m_ResultValue.JXFDJ += m_ResultValue.JXBFHHJ;
            m_ResultValue.DERGFDJ += DERGBFHHJ;
            m_ResultValue.DECLFDJ += DECLBFHHJ;
            m_ResultValue.DEJXFDJ += DEJXBFHHJ;
            m_ResultValue.HHJXFDJ += HHJXFDJHJ;
        }

        /// <summary>
        /// 计算 投标金额、标底金额
        /// </summary>
        /// <param name="ifCpTBJE">是否计算投标金额</param>
        public void CalculateParentTBJE_BDJE()
        {
            DataRow[] drs = this.Unit.StructSource.ModelSubheadingsFee.Select(string.Format(" ZMID = {0} and SSLB = {1} ", this.Current.ID, this.Current.SSLB), "JSSX");
            foreach (DataRow row in drs)
            {
                row.BeginEdit();
                DataRow[] rowss = this.Unit.StructSource.ModelVariable.Select(string.Format("ID={0} and type = {1}", this.Current.ID, this.Current.SSLB), "Length DESC");
                string tbjsjc = ToolKit.ExpressionReplace(row["TBJSJC"].ToString(), rowss);
                string bdjsjc = ToolKit.ExpressionReplace(row["BDJSJC"].ToString(), rowss);
                decimal fl = ToolKit.ParseDecimal(row["FL"]);
                //兼容5.6导入
                if (string.IsNullOrEmpty(row["MC"].ToString())) continue;
                //if (row["JSSX"].ToString().Equals("0"))
                //{
                    switch (row["MC"].ToString().Substring(0, 2))
                    {
                        case "人工":
                            row["TBJE"] = (ToolKit.Calculate(tbjsjc)) * fl * 0.01m;
                            row["BDJE"] = (ToolKit.Calculate(bdjsjc)) * fl * 0.01m;
                            break;
                        case "材料":
                            row["TBJE"] = (ToolKit.Calculate(tbjsjc)) * fl * 0.01m;
                            row["BDJE"] = (ToolKit.Calculate(bdjsjc)) * fl * 0.01m;
                            //用途类别材料
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "JGCL", this.m_ResultValue.JGCL * fl * 0.01m, "[子目]甲供材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "YGCL", this.m_ResultValue.YGCL, "[子目]乙供材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "ZDJCL", this.m_ResultValue.ZDJCL * fl * 0.01m, "[子目]暂定材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "PBZDCL", this.m_ResultValue.PBZDCL * fl * 0.01m, "[子目]评标材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEJGCL", this.m_ResultValue.DEJGCL * fl * 0.01m, "[子目]定额甲供材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEYGCL", this.m_ResultValue.DEYGCL * fl * 0.01m, "[子目]定额乙供材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEZDJCL", this.m_ResultValue.DEZDJCL * fl * 0.01m, "[子目]定额暂定材料单价");
                            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEPBZDCL", this.m_ResultValue.DEPBZDCL * fl * 0.01m, "[子目]定评标材料单价");
                            break;
                        case "机械":
                            row["TBJE"] = (ToolKit.Calculate(tbjsjc)) * fl * 0.01m;
                            row["BDJE"] = (ToolKit.Calculate(bdjsjc)) * fl * 0.01m;
                            m_ResultValue.DZJXTB = m_ResultValue.DZJXTB * fl * 0.01m;
                            break;
                        case "管理":
                        case "利润":
                            row["TBJE"] = ToolKit.Calculate(tbjsjc) * fl * 0.01m;
                            row["BDJE"] = ToolKit.Calculate(bdjsjc) * fl * 0.01m;
                            break;
                        case "主材":
                        case "设备":
                        case "风险":
                        case "直接":
                        case "子目":
                        case "合价":
                            row["TBJE"] = ToolKit.Calculate(tbjsjc) * fl * 0.01m;
                            row["BDJE"] = ToolKit.Calculate(bdjsjc) * fl * 0.01m;
                            break;
                    }
                //}
                //else
                //{

                //    switch (row["JSSX"].ToString())
                //    {
                //        case "1"://人工
                //            row["TBJE"] = (ToolKit.Calculate(tbjsjc)) * fl * 0.01m;
                //            row["BDJE"] = (ToolKit.Calculate(bdjsjc)) * fl * 0.01m;
                //            break;
                //        case "2"://材料
                //            row["TBJE"] = (ToolKit.Calculate(tbjsjc)) * fl * 0.01m;
                //            row["BDJE"] = (ToolKit.Calculate(bdjsjc)) * fl * 0.01m;
                //            //用途类别材料
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "JGCL", this.m_ResultValue.JGCL * fl * 0.01m, "[子目]甲供材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "YGCL", this.m_ResultValue.YGCL, "[子目]乙供材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "ZDJCL", this.m_ResultValue.ZDJCL * fl * 0.01m, "[子目]暂定材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "PBZDCL", this.m_ResultValue.PBZDCL * fl * 0.01m, "[子目]评标材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEJGCL", this.m_ResultValue.DEJGCL * fl * 0.01m, "[子目]定额甲供材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEYGCL", this.m_ResultValue.DEYGCL * fl * 0.01m, "[子目]定额乙供材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEZDJCL", this.m_ResultValue.DEZDJCL * fl * 0.01m, "[子目]定额暂定材料单价");
                //            this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "DEPBZDCL", this.m_ResultValue.DEPBZDCL * fl * 0.01m, "[子目]定评标材料单价");
                //            break;
                //        case "3"://机械
                //            row["TBJE"] = (ToolKit.Calculate(tbjsjc)) * fl * 0.01m;
                //            row["BDJE"] = (ToolKit.Calculate(bdjsjc)) * fl * 0.01m;
                //            m_ResultValue.DZJXTB = m_ResultValue.DZJXTB * fl * 0.01m;
                //            break;
                //        case "8"://管理费
                //        case "9"://利润
                //            row["TBJE"] = ToolKit.Calculate(tbjsjc) * fl * 0.01m;
                //            row["BDJE"] = ToolKit.Calculate(bdjsjc) * fl * 0.01m;
                //            break;
                //        case "4"://主材
                //        case "5"://设备
                //        case "6"://风险
                //        case "7"://直接费
                //        case "10"://子目单价
                //        case "11"://合价
                //            row["TBJE"] = ToolKit.Calculate(tbjsjc) * fl * 0.01m;
                //            row["BDJE"] = ToolKit.Calculate(bdjsjc) * fl * 0.01m;
                //            break;
                //    }
                //}
                row.EndEdit();
                this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, "BD_" + row["YYH"].ToString(), row["BDJE"], row["MC"].ToString(), row["FYLB"].ToString(), true);
                this.Unit.StructSource.ModelVariable.Set(this.Current.ID, this.Current.SSLB, row["YYH"].ToString(), row["TBJE"], row["MC"].ToString(), row["FYLB"].ToString(), false);
            }
        }

        /// <summary>
        ///  设置变量值
        /// </summary>
        private void Assignment()
        {
            _VariableSource Variable = this.Unit.StructSource.ModelVariable;
            #region 市场费单价
            Variable.Set(this.Current.ID, this.Current.SSLB, "ZJFDJ", this.m_ResultValue.ZJFDJ, "[子目]直接费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "RGFDJ", this.m_ResultValue.RGFDJ, "[子目]人工费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "CLFDJ", this.m_ResultValue.CLFDJ, "[子目]材料费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "JXFDJ", this.m_ResultValue.JXFDJ, "[子目]机械费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "ZCFDJ", this.m_ResultValue.ZCFDJ, "[子目]主材费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "SBFDJ", this.m_ResultValue.SBFDJ, "[子目]设备费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "JGCL", this.m_ResultValue.JGCL, "[子目]甲供材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "YGCL", this.m_ResultValue.YGCL, "[子目]乙供材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "ZDJCL", this.m_ResultValue.ZDJCL, "[子目]暂定材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "PBZDCL", this.m_ResultValue.PBZDCL, "[子目]评标材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "FXDJ", this.m_ResultValue.FXDJ, true, "[子目]风险单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "GLFDJ", this.m_ResultValue.GLFDJ, true, "[子目]管理费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "LRFDJ", this.m_ResultValue.LRFDJ, true, "[子目]利润单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "GFDJ", this.m_ResultValue.GFDJ, true, "[子目]规费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "SJDJ", this.m_ResultValue.SJDJ, true, "[子目]税金单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "ZMDJ", this.m_ResultValue.ZMDJ, true, "[子目]子目单价");
            #endregion

            #region 定额费单价
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEZJFDJ", this.m_ResultValue.DEZJFDJ, "[子目]定额直接费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DERGFDJ", this.m_ResultValue.DERGFDJ, "[子目]定额人工费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DECLFDJ", this.m_ResultValue.DECLFDJ, "[子目]定额材料费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEJXFDJ", this.m_ResultValue.DEJXFDJ, "[子目]定额机械费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEZCFDJ", this.m_ResultValue.DEZCFDJ, "[子目]定额主材费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DESBFDJ", this.m_ResultValue.DESBFDJ, "[子目]定额设备费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEJGCL", this.m_ResultValue.DEJGCL, "[子目]定额甲供材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEYGCL", this.m_ResultValue.DEYGCL, "[子目]定额乙供材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEZDJCL", this.m_ResultValue.DEZDJCL, "[子目]定额暂定材料单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEPBZDCL", this.m_ResultValue.DEPBZDCL, "[子目]定额评标材料单价");
            //Variable.Set(this.Current.ID, this.Current.SSLB, "DEFXDJ", this.m_ResultValue.DEFXDJ, true);
            //Variable.Set(this.Current.ID, this.Current.SSLB, "DEGLFDJ", this.m_ResultValue.DEGLFDJ, true);
            //Variable.Set(this.Current.ID, this.Current.SSLB, "DELRFDJ", this.m_ResultValue.DELRFDJ, true);
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEGFDJ", this.m_ResultValue.DEGFDJ, true, "[子目]定额规费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DESJDJ", this.m_ResultValue.DESJDJ, true, "[子目]定额税金单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DEZMDJ", this.m_ResultValue.DEZMDJ, true, "[子目]定额子目单价");
            #endregion

            #region 人材机%合计
            Variable.Set(this.Current.ID, this.Current.SSLB, "RGBFHHJ", this.m_ResultValue.RGBFHHJ, true, "[子目]人工%合计");
            Variable.Set(this.Current.ID, this.Current.SSLB, "CLBFHHJ", this.m_ResultValue.CLBFHHJ, true, "[子目]材料%合计");
            Variable.Set(this.Current.ID, this.Current.SSLB, "JXBFHHJ", this.m_ResultValue.JXBFHHJ, true, "[子目]机械%合计");
            #endregion

            #region 价差和差价
            Variable.Set(this.Current.ID, this.Current.SSLB, "JCDJ", this.m_ResultValue.JCDJ, true, "[子目]价差单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "RGJCDJ", this.m_ResultValue.RGJCDJ, true, "[子目]人工费价差单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "CLJCDJ", this.m_ResultValue.CLJCDJ, true, "[子目]材料费价差单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "JXJCDJ", this.m_ResultValue.JXJCDJ, true, "[子目]机械费价差单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "CJDJ", this.m_ResultValue.CJDJ, true, "[子目]差价单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "RGCJDJ", this.m_ResultValue.RGCJDJ, true, "[子目]人工费差价单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "CLCJDJ", this.m_ResultValue.CLCJDJ, true, "[子目]材料费差价单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "JXCJDJ", this.m_ResultValue.JXCJDJ, true, "[子目]机械费差价单价");
            #endregion

            #region 子目参数
            Variable.Set(this.Current.ID, this.Current.SSLB, "JC", this.m_ResultValue.JCDJ, "[子目]价差");
            Variable.Set(this.Current.ID, this.Current.SSLB, "GCL", this.m_ResultValue.GCL, "[子目]工程量");
            Variable.Set(this.Current.ID, this.Current.SSLB, "FXRCJ", this.m_ResultValue.FXRCJ, "[子目]参与风险计算的人材机");
            Variable.Set(this.Current.ID, this.Current.SSLB, "HHJXFDJ", this.m_ResultValue.HHJXFDJ, "[子目]混合机械费单价");
            Variable.Set(this.Current.ID, this.Current.SSLB, "DZJXTB", this.m_ResultValue.DZJXTB, true, "[子目]吊装机械台班");
            #endregion
        }

        /// <summary>
        /// 传递结果
        /// </summary>
        public void TransferResults()
        {
            //定额
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEZJFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "直接费单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DERGFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "人工费单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DECLFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "材料费单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEJXFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "机械费单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEZCFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "主材费单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DESBFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "设备费单价", true));
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEFXDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "风险单价", true));
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEGLFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "管理费单价", true));
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DELRDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "利润单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEZHDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "子目单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEGFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "规费单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DESJDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "税金单价", true));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEJGJEDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "DEJGCL"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEYGJEDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "DEYGCL"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEPBZDDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "DEPBZDCL"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEZGDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "DEZDJCL"));

            //市场
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZJFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "直接费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_RGFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "人工费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_CLFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "材料费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_JXFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "机械费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZCFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "主材费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_SBFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "设备费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FXDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "风险单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_GLFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "管理费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_LRDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "利润单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZHDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "子目单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_GFDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "规费单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_SJDJ, this.Unit.StructSource.ModelVariable.GetDecimalBYFylb(this.Current.ID, this.Current.SSLB, "税金单价"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_JGJEDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "JGCL"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_YGJEDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "YGCL"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_PBZDDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "PBZDCL"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZGDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "ZDJCL"));

            //价差
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXJCDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "JCDJ"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXRGJCDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "RGJCDJ"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXCLJCDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "CLJCDJ"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXJXJCDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "JXJCDJ"));
            //差价
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXCJDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "CJDJ"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXRGCJDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "RGCJDJ"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXCLCJDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "CLCJDJ"));
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXJXCJDJ, this.Unit.StructSource.ModelVariable.GetDecimal(this.Current.ID, this.Current.SSLB, "JXCJDJ"));
        }

        /// <summary>
        /// 临时子目统计参数表
        /// </summary>
        [Serializable]
        public struct ResultValue
        {
            #region 市场费单价
            /// <summary>
            /// 市场直接费单价
            /// </summary>
            public decimal ZJFDJ;
            /// <summary>
            /// 市场人工费单价
            /// </summary>
            public decimal RGFDJ;
            /// <summary>
            /// 市场材料费单价
            /// </summary>
            public decimal CLFDJ;
            /// <summary>
            /// 市场机械费单价
            /// </summary>
            public decimal JXFDJ;
            /// <summary>
            /// 市场主材费单价
            /// </summary>
            public decimal ZCFDJ;
            /// <summary>
            /// 市场设备费单价
            /// </summary>
            public decimal SBFDJ;
            /// <summary>
            /// 市场风险单价
            /// </summary>
            public decimal FXDJ;
            /// <summary>
            /// 市场管理费单价
            /// </summary>
            public decimal GLFDJ;
            /// <summary>
            /// 市场利润单价
            /// </summary>
            public decimal LRFDJ;
            /// <summary>
            /// 市场子目单价
            /// </summary>
            public decimal ZMDJ;
            /// <summary>
            /// 市场规费单价
            /// </summary>
            public decimal GFDJ;
            /// <summary>
            /// 市场税金单价
            /// </summary>
            public decimal SJDJ;
            /// <summary>
            /// 市场甲供材料单价
            /// </summary>
            public decimal JGCL;
            /// <summary>
            /// 市场乙供材料单价
            /// </summary>
            public decimal YGCL;
            /// <summary>
            /// 市场暂定材料单价
            /// </summary>
            public decimal ZDJCL;
            /// <summary>
            /// 市场评标材料单价
            /// </summary>
            public decimal PBZDCL;
            #endregion

            #region 定额费单价
            /// <summary>
            /// 定额直接费单价
            /// </summary>
            public decimal DEZJFDJ;
            /// <summary>
            /// 定额人工费单价
            /// </summary>
            public decimal DERGFDJ;
            /// <summary>
            /// 定额材料费单价
            /// </summary>
            public decimal DECLFDJ;
            /// <summary>
            /// 定额机械费单价
            /// </summary>
            public decimal DEJXFDJ;
            /// <summary>
            /// 定额主材费单价
            /// </summary>
            public decimal DEZCFDJ;
            /// <summary>
            /// 定额设备费单价
            /// </summary>
            public decimal DESBFDJ;
            /// <summary>
            /// 定额风险单价
            /// </summary>
            public decimal DEFXDJ;
            /// <summary>
            /// 定额管理费单价
            /// </summary>
            public decimal DEGLFDJ;
            /// <summary>
            /// 定额利润单价
            /// </summary>
            public decimal DELRFDJ;
            /// <summary>
            /// 定额子目单价
            /// </summary>
            public decimal DEZMDJ;
            /// <summary>
            /// 定额规费单价
            /// </summary>
            public decimal DEGFDJ;
            /// <summary>
            /// 定额税金单价
            /// </summary>
            public decimal DESJDJ;
            /// <summary>
            /// 定额甲供材料单价
            /// </summary>
            public decimal DEJGCL;
            /// <summary>
            /// 定额乙供材料单价
            /// </summary>
            public decimal DEYGCL;
            /// <summary>
            /// 定额暂定材料单价
            /// </summary>
            public decimal DEZDJCL;
            /// <summary>
            /// 定额评标材料单价
            /// </summary>
            public decimal DEPBZDCL;
            #endregion

            #region 人材机%合计
            /// <summary>
            /// 人工%合计
            /// </summary>
            public decimal RGBFHHJ;
            /// <summary>
            /// 材料%合计
            /// </summary>
            public decimal CLBFHHJ;
            /// <summary>
            /// 机械%合计
            /// </summary>
            public decimal JXBFHHJ;
            #endregion

            #region 价差和差价
            /// <summary>
            /// 价差单价
            /// </summary>
            public decimal JCDJ;
            /// <summary>
            /// 人工费价差单价
            /// </summary>
            public decimal RGJCDJ;
            /// <summary>
            /// 材料费价差单价
            /// </summary>
            public decimal CLJCDJ;
            /// <summary>
            /// 机械费价差单价
            /// </summary>
            public decimal JXJCDJ;
            /// <summary>
            /// 差价单价
            /// </summary>
            public decimal CJDJ;
            /// <summary>
            /// 人工费差价单价
            /// </summary>
            public decimal RGCJDJ;
            /// <summary>
            /// 材料费差价单价
            /// </summary>
            public decimal CLCJDJ;
            /// <summary>
            /// 机械费差价单价
            /// </summary>
            public decimal JXCJDJ;
            #endregion

            #region 其他参数
            ///<summary>
            /// 子目工程量
            ///<summary>
            public decimal GCL;
            /// <summary>
            ///参与风险计算的人材机
            /// </summary>
            public decimal FXRCJ;
            /// <summary>
            /// 吊装机械台班
            /// </summary>
            public decimal DZJXTB;
            /// <summary>
            /// 混合机械费价差
            /// </summary>
            public decimal HHJXFJC;
            /// <summary>
            /// 混合机械费单价
            /// </summary>
            public decimal HHJXFDJ;
            /// <summary>
            /// 机械费单价(处人工)
            /// </summary>
            public decimal JXFDJCRG;
            /// <summary>
            /// 机械费单价(含人工)
            /// </summary>
            public decimal JXFDJHRG;
            /// <summary>
            /// 定额机械费单价(含人工)
            /// </summary>
            public decimal DEJXFDJHRG;

            #endregion
        }
    }
}
