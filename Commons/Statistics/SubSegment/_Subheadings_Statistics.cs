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
using MSScriptControl;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 作废 
    /// </summary>
    [Serializable]
    public class _Subheadings_Statisticss
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _Subheadings_Statisticss(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
            this.Create();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _Subheadings_Statisticss(_Entity_SubInfo p_info)
        {
            //this.m_Parent = p_Parent;
            this.Create();
        }

        /// <summary>
        /// 当前对象所属对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 用于处理统计后的变量结果集
        /// </summary>
        private _CVariable m_Variable = null;
        /// <summary>
        /// 用于处理统计后的变量结果集
        /// </summary>
        private _CVariable m_DEVariable = null;

        /// <summary>
        /// 临时子目统计参数表
        /// </summary>
        private ResultValue m_ResultValue;



        /// <summary>
        /// 获取当前对象的所属对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        /// <summary>
        /// 获取或设置：显示参数集合
        /// </summary>
        public _CVariable Variable
        {
            get { return this.m_Variable; }
            set { this.m_Variable = value; }
        }

        /// <summary>
        /// 获取或设置：不显示参数集合
        /// </summary>
        public _CVariable DEVariable
        {
            get { return this.m_DEVariable; }
            set { this.m_DEVariable = value; }
        }

        /// <summary>
        /// 创建子目变量对象
        /// </summary>
        private void Create()
        {
            this.Variable = new _CVariable();
            this.DEVariable = new _CVariable();
            #region 市场费单价
            this.Variable.Set("ZJFDJ", 0, "[子目]直接费单价");
            this.Variable.Set("RGFDJ", 0, "[子目]人工费单价");
            this.Variable.Set("CLFDJ", 0, "[子目]材料费单价");
            this.Variable.Set("JXFDJ", 0, "[子目]机械费单价");
            this.Variable.Set("ZCFDJ", 0, "[子目]主材费单价");
            this.Variable.Set("SBFDJ", 0, "[子目]设备费单价");
            this.Variable.Set("JGCL", 0, "[子目]甲供材料单价");
            this.Variable.Set("YGCL", 0, "[子目]乙供材料单价");
            this.Variable.Set("ZDJCL", 0, "[子目]暂定材料单价");
            this.Variable.Set("PBZDCL", 0, "[子目]评标材料单价");
            
            this.DEVariable.Set("FXDJ", 0, "[子目]风险单价");
            this.DEVariable.Set("GLFDJ", 0, "[子目]管理费单价");
            this.DEVariable.Set("LRFDJ", 0, "[子目]利润单价");
            this.DEVariable.Set("GFDJ", 0, "[子目]规费单价");
            this.DEVariable.Set("SJDJ", 0, "[子目]税金单价");
            this.DEVariable.Set("ZMDJ", 0, "[子目]子目单价");
            #endregion

            #region 定额费单价
            this.Variable.Set("DEZJFDJ", 0, "[子目]定额直接费单价");
            this.Variable.Set("DERGFDJ", 0, "[子目]定额人工费单价");
            this.Variable.Set("DECLFDJ", 0, "[子目]定额材料费单价");
            this.Variable.Set("DEJXFDJ", 0, "[子目]定额机械费单价");
            this.Variable.Set("DEZCFDJ", 0, "[子目]定额主材费单价");
            this.Variable.Set("DESBFDJ", 0, "[子目]定额设备费单价");
            this.Variable.Set("DEJGCL", 0, "[子目]定额甲供材料单价");
            this.Variable.Set("DEYGCL", 0, "[子目]定额乙供材料单价");
            this.Variable.Set("DEZDJCL", 0, "[子目]定额暂定材料单价");
            this.Variable.Set("DEPBZDCL", 0, "[子目]定额评标材料单价");
            this.DEVariable.Set("DEFXDJ", 0, "[子目]定额风险单价");
            this.DEVariable.Set("DEGLFDJ", 0, "[子目]定额管理费单价");
            this.DEVariable.Set("DELRFDJ", 0, "[子目]定额利润单价");
            this.DEVariable.Set("DEGFDJ", 0, "[子目]定额规费单价");
            this.DEVariable.Set("DESJDJ", 0, "[子目]定额税金单价");
            this.DEVariable.Set("DEZMDJ", 0, "[子目]定额子目单价");
            #endregion

            #region 人材机%合计
            this.DEVariable.Set("RGBFHHJ", 0, "[子目]人工%合计");
            this.DEVariable.Set("CLBFHHJ", 0, "[子目]材料%合计");
            this.DEVariable.Set("JXBFHHJ", 0, "[子目]机械%合计");
            #endregion

            #region 价差和差价
            this.DEVariable.Set("JCDJ", 0, "[子目]价差单价");
            this.DEVariable.Set("RGJCDJ", 0, "[子目]人工费价差单价");
            this.DEVariable.Set("CLJCDJ", 0, "[子目]材料费价差单价");
            this.DEVariable.Set("JXJCDJ", 0, "[子目]机械费价差单价");
            this.DEVariable.Set("CJDJ", 0, "[子目]差价单价");
            this.DEVariable.Set("RGCJDJ", 0, "[子目]人工费差价单价");
            this.DEVariable.Set("CLCJDJ", 0, "[子目]材料费差价单价");
            this.DEVariable.Set("JXCJDJ", 0, "[子目]机械费差价单价");
            #endregion

            #region 子目参数
            this.Variable.Set("JC", 0, "[子目]价差");
            this.Variable.Set("GCL", 0, "[子目]工程量");
            this.Variable.Set("FXRCJ", 0, "[子目]参与风险计算的人材机");
            this.Variable.Set("HHJXFDJ", 0, "[子目]混合机械费单价");
            this.DEVariable.Set("DZJXTB", 0, "[子目]吊装机械台班");
            #endregion
        }

        /// <summary>
        ///  设置变量值
        /// </summary>
        private void Assignment()
        {
            #region 市场费单价
            this.Variable.Set("ZJFDJ", this.m_ResultValue.ZJFDJ);
            this.Variable.Set("RGFDJ", this.m_ResultValue.RGFDJ);
            this.Variable.Set("CLFDJ", this.m_ResultValue.CLFDJ);
            this.Variable.Set("JXFDJ", this.m_ResultValue.JXFDJ);
            this.Variable.Set("ZCFDJ", this.m_ResultValue.ZCFDJ);
            this.Variable.Set("SBFDJ", this.m_ResultValue.SBFDJ);
            this.Variable.Set("JGCL", this.m_ResultValue.JGCL);
            this.Variable.Set("YGCL", this.m_ResultValue.YGCL);
            this.Variable.Set("ZDJCL", this.m_ResultValue.ZDJCL);
            this.Variable.Set("PBZDCL", this.m_ResultValue.PBZDCL);
            this.DEVariable.Set("FXDJ", this.m_ResultValue.FXDJ);
            this.DEVariable.Set("GLFDJ", this.m_ResultValue.GLFDJ);
            this.DEVariable.Set("LRFDJ", this.m_ResultValue.LRFDJ);
            this.DEVariable.Set("GFDJ", this.m_ResultValue.GFDJ);
            this.DEVariable.Set("SJDJ", this.m_ResultValue.SJDJ);
            this.DEVariable.Set("ZMDJ", this.m_ResultValue.ZMDJ);
            #endregion

            #region 定额费单价
            this.Variable.Set("DEZJFDJ", this.m_ResultValue.DEZJFDJ);
            this.Variable.Set("DERGFDJ", this.m_ResultValue.DERGFDJ);
            this.Variable.Set("DECLFDJ", this.m_ResultValue.DECLFDJ);
            this.Variable.Set("DEJXFDJ", this.m_ResultValue.DEJXFDJ);
            this.Variable.Set("DEZCFDJ", this.m_ResultValue.DEZCFDJ);
            this.Variable.Set("DESBFDJ", this.m_ResultValue.DESBFDJ);
            this.Variable.Set("DEJGCL", this.m_ResultValue.DEJGCL);
            this.Variable.Set("DEYGCL", this.m_ResultValue.DEYGCL);
            this.Variable.Set("DEZDJCL", this.m_ResultValue.DEZDJCL);
            this.Variable.Set("DEPBZDCL", this.m_ResultValue.DEPBZDCL);
            this.DEVariable.Set("DEFXDJ", this.m_ResultValue.DEFXDJ);
            this.DEVariable.Set("DEGLFDJ", this.m_ResultValue.DEGLFDJ);
            this.DEVariable.Set("DELRFDJ", this.m_ResultValue.DELRFDJ);
            this.DEVariable.Set("DEGFDJ", this.m_ResultValue.DEGFDJ);
            this.DEVariable.Set("DESJDJ", this.m_ResultValue.DESJDJ);
            this.DEVariable.Set("DEZMDJ", this.m_ResultValue.DEZMDJ);
            #endregion

            #region 人材机%合计
            this.DEVariable.Set("RGBFHHJ", this.m_ResultValue.RGBFHHJ);
            this.DEVariable.Set("CLBFHHJ", this.m_ResultValue.CLBFHHJ);
            this.DEVariable.Set("JXBFHHJ", this.m_ResultValue.JXBFHHJ);
            #endregion

            #region 价差和差价
            this.DEVariable.Set("JCDJ", this.m_ResultValue.JCDJ);
            this.DEVariable.Set("RGJCDJ", this.m_ResultValue.RGJCDJ);
            this.DEVariable.Set("CLJCDJ", this.m_ResultValue.CLJCDJ);
            this.DEVariable.Set("JXJCDJ", this.m_ResultValue.JXJCDJ);
            this.DEVariable.Set("CJDJ", this.m_ResultValue.CJDJ);
            this.DEVariable.Set("RGCJDJ", this.m_ResultValue.RGCJDJ);
            this.DEVariable.Set("CLCJDJ", this.m_ResultValue.CLCJDJ);
            this.DEVariable.Set("JXCJDJ", this.m_ResultValue.JXCJDJ);
            #endregion

            #region 子目参数
            this.Variable.Set("JC", this.m_ResultValue.JCDJ);
            this.Variable.Set("GCL", this.m_ResultValue.GCL);
            this.Variable.Set("FXRCJ", this.m_ResultValue.FXRCJ);
            this.Variable.Set("HHJXFDJ", this.m_ResultValue.HHJXFDJ);
            this.DEVariable.Set("DZJXTB", this.m_ResultValue.DZJXTB);
            #endregion
        }

        /// <summary>
        /// 请求子目统计操作
        /// </summary>
        public void Begin()
        {
            this.CalculateBasicData(this.Parent.SubheadingsQuantityUnitList);
            FBegin();
        }

        /// <summary>
        /// 子目取费计算的公共方法
        /// </summary>
        public void FBegin()
        {
            CalculateParentTBJE_BDJE();
            TransferResults();
            this.Parent.Begin();
        }

        public void Calculate()
        {
            this.CalculateBasicData(this.Parent.SubheadingsQuantityUnitList);
            CalculateParentTBJE_BDJE();
            TransferResults();
        }

        /// <summary>
        /// 计算基础数据
        /// </summary>
        public void CalculateBasicData(_SubheadingsQuantityUnitList list)
        {
            //定额合价统计
            this.DEHJ(list);
            //市场合价统计
            this.SCHJ(list);
            //其他统计
            this.Other(list);
            //计算百分号
            this.JSBFH(list);
            //价差统计
            this.JCDJ(list);
            //差价统计
            this.CJDJ(list);
            //赋值
            this.Assignment();
        }

        /// <summary>
        /// 其他统计
        /// </summary>
        /// <param name="table"></param>
        private void Other(_SubheadingsQuantityUnitList list)
        {
            //工程量
            m_ResultValue.GCL = this.Parent.GCL;
            //风险人材机
            m_ResultValue.FXRCJ = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.IFFX == true).Sum(p => p.SCDJ * p.XHL);
            //吊装机械台班
            m_ResultValue.DZJXTB = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.LB == "吊装机械台班").Sum(p => p.SCDJ * p.XHL);
            //机械费单价(含人工)  - 2012.11.7 修改
            m_ResultValue.DEJXFDJHRG = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.LB == "机械" && p.DW == "工日").Sum(p => p.GetType() == typeof(_QuantityUnitComponentInfo) ? p.DEDJ * p.XHL * (p as _QuantityUnitComponentInfo).Parent.XHL : p.DEDJ * p.XHL);
            //定额机械费单价(含人工 )  - 2012.11.7 修改
            m_ResultValue.JXFDJHRG = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.LB == "机械" && p.DW == "工日").Sum(p => p.GetType() == typeof(_QuantityUnitComponentInfo) ? p.SCDJ * p.XHL * (p as _QuantityUnitComponentInfo).Parent.XHL : p.SCDJ * p.XHL);
            //混合机械费价差
            m_ResultValue.HHJXFJC = m_ResultValue.JXFDJHRG - m_ResultValue.DEJXFDJHRG;
            //混合机械费单价
            m_ResultValue.HHJXFDJ = m_ResultValue.JXFDJ - m_ResultValue.JXFDJHRG + m_ResultValue.DEJXFDJHRG;

        }

        /// <summary>
        /// 价差统计
        /// </summary>
        /// <param name="table"></param>
        private void JCDJ(_SubheadingsQuantityUnitList list)
        {
            //价差单价
            m_ResultValue.JCDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.DJC != 0).Sum(p => p.DJC * p.XHL);
            //人工费价差单价
            m_ResultValue.RGJCDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.DJC != 0 && _Constant.rg.Contains("'" + p.LB + "'")).Sum(p => p.DJC * p.XHL) + m_ResultValue.HHJXFJC;
            //材料费价差单价
            m_ResultValue.CLJCDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.DJC != 0 && _Constant.cl.Contains("'" + p.LB + "'")).Sum(p => p.DJC * p.XHL);
            //机械费价差单价
            m_ResultValue.JXJCDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.DJC != 0 && _Constant.jx.Contains("'" + p.LB + "'")).Sum(p => p.DJC * p.XHL) - m_ResultValue.HHJXFJC;
        }

        /// <summary>
        /// 差价统计
        /// </summary>
        /// <param name="table"></param>
        private void CJDJ(_SubheadingsQuantityUnitList list)
        {
            //差价单价
            m_ResultValue.CJDJ = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.JSDJC != 0).Sum(p => p.JSDJC * p.XHL);
            //人工费差价单价
            m_ResultValue.RGCJDJ = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.JSDJC != 0 && _Constant.rg.Contains("'" + p.LB + "'")).Sum(p => p.JSDJC * p.XHL);
            //材料费差价单价
            m_ResultValue.CLCJDJ = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.JSDJC != 0 && _Constant.cl.Contains("'" + p.LB + "'")).Sum(p => p.JSDJC * p.XHL);
            //机械费差价单价
            m_ResultValue.JXCJDJ = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.JSDJC != 0 && _Constant.jx.Contains("'" + p.LB + "'")).Sum(p => p.JSDJC * p.XHL);
        }

        /// <summary>
        /// 定额合价统计
        /// </summary>
        /// <param name="table"></param>
        private void DEHJ(_SubheadingsQuantityUnitList list)
        {
            //定额人工费单价
            m_ResultValue.DERGFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.rg.Contains("'" + p.LB + "'")).Sum(p => p.DEDJ * p.XHL);
            //定额材料费单价
            m_ResultValue.DECLFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.cl.Contains("'" + p.LB + "'")).Sum(p => p.DEDJ * p.XHL);
            //定额机械费单价
            m_ResultValue.DEJXFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.jx.Contains("'" + p.LB + "'")).Sum(p => p.DEDJ * p.XHL);
            //定额主材费单价
            m_ResultValue.DEZCFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.zc.Contains("'" + p.LB + "'")).Sum(p => p.DEDJ * p.XHL);
            //定额设备费单价
            m_ResultValue.DESBFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.sb.Contains("'" + p.LB + "'")).Sum(p => p.DEDJ * p.XHL);
            //市场直接费单价
            m_ResultValue.DEZJFDJ = m_ResultValue.DERGFDJ + m_ResultValue.DECLFDJ + m_ResultValue.DEJXFDJ + m_ResultValue.DESBFDJ + m_ResultValue.DEZCFDJ + m_ResultValue.FXRCJ;
            //定额甲供材料
            m_ResultValue.DEJGCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.甲供材料.ToString()).Sum(p => p.DEDJ * p.XHL);
            //定额乙供材料
            m_ResultValue.DEYGCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.甲定乙供材料.ToString()).Sum(p => p.DEDJ * p.XHL);
            //定额评标指定材料
            m_ResultValue.DEPBZDCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.评标指定材料.ToString()).Sum(p => p.DEDJ * p.XHL);
            //定额暂定价材料
            m_ResultValue.DEZDJCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.暂定价材料.ToString()).Sum(p => p.DEDJ * p.XHL);

            
        }

        /// <summary>
        /// 市场合价统计
        /// </summary>
        /// <param name="table"></param>
        private void SCHJ(_SubheadingsQuantityUnitList list)
        {
            if (list.Parent.LB == "子目-增加费")
            {
                if (list.Parent.Activitie.Property.IncreaseCosts.DataSource != null)
                {
                    DataRow drs = list.Parent.Activitie.Property.IncreaseCosts.DataSource.Select(string.Format("ParentID = 0 AND Code='{0}'", this.Parent.XMBM)).FirstOrDefault();
                    if (drs != null)
                    {

                        if (drs["location"].ToString() == "分部分项" )
                        {
                            //市场人工费单价
                            m_ResultValue.RGFDJ = list.Parent.Parent.SubheadingsList.Cast<_SubheadingsInfo>().Where(p => p.LB != "子目-增加费").Sum(p => p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM) == null ? 0 : p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM).RGF);
                            //市场材料费单价
                            m_ResultValue.CLFDJ = list.Parent.Parent.SubheadingsList.Cast<_SubheadingsInfo>().Where(p => p.LB != "子目-增加费").Sum(p => p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM) == null ? 0 : p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM).CLF);
                            //市场机械费单价
                            m_ResultValue.JXFDJ = list.Parent.Parent.SubheadingsList.Cast<_SubheadingsInfo>().Where(p => p.LB != "子目-增加费").Sum(p => p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM) == null ? 0 : p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM).JXF);
                        }
                        else
                        {
                            //市场人工费单价
                            m_ResultValue.RGFDJ = list.Parent.Activitie.Property.SubSegments.SubheadingsList.Cast<_SubheadingsInfo>().Where(p => p.LB != "子目-增加费").Sum(p => p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM) == null ? 0 : p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM).RGF);
                            //市场材料费单价
                            m_ResultValue.CLFDJ = list.Parent.Activitie.Property.SubSegments.SubheadingsList.Cast<_SubheadingsInfo>().Where(p => p.LB != "子目-增加费").Sum(p => p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM) == null ? 0 : p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM).CLF);
                            //市场机械费单价
                            m_ResultValue.JXFDJ = list.Parent.Activitie.Property.SubSegments.SubheadingsList.Cast<_SubheadingsInfo>().Where(p => p.LB != "子目-增加费").Sum(p => p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM) == null ? 0 : p.IncreaseCostsList.Cast<_IncreaseCostsInfo>().FirstOrDefault(ps => ps.DH == this.Parent.XMBM).JXF);
                        }
                        //定额人工费单价
                        m_ResultValue.DERGFDJ = m_ResultValue.RGFDJ;
                        //定额材料费单价
                        m_ResultValue.DECLFDJ = m_ResultValue.CLFDJ;
                        //定额机械费单价
                        m_ResultValue.DEJXFDJ = m_ResultValue.JXFDJ;
                    }
                }
            }
            else
            {
                //市场人工费单价
                m_ResultValue.RGFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.rg.Contains("'" + p.LB + "'")).Sum(p => p.SCDJ * p.XHL);
                //市场材料费单价
                m_ResultValue.CLFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.cl.Contains("'" + p.LB + "'")).Sum(p => p.SCDJ * p.XHL);
                //市场机械费单价
                m_ResultValue.JXFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.jx.Contains("'" + p.LB + "'")).Sum(p => p.SCDJ * p.XHL);
            }
            //市场主材费单价
            m_ResultValue.ZCFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.zc.Contains("'" + p.LB + "'")).Sum(p => p.SCDJ * p.XHL);
            //市场设备费单价
            m_ResultValue.SBFDJ = list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => _Constant.sb.Contains("'" + p.LB + "'")).Sum(p => p.SCDJ * p.XHL);
            //市场直接费单价
            m_ResultValue.ZJFDJ = m_ResultValue.RGFDJ + m_ResultValue.CLFDJ + m_ResultValue.JXFDJ + m_ResultValue.SBFDJ + m_ResultValue.ZCFDJ + m_ResultValue.FXRCJ;
            //市场甲供材料
            m_ResultValue.JGCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.甲供材料.ToString()).Sum(p => p.SCDJ * p.XHL);
            //市场乙供材料
            m_ResultValue.YGCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.甲定乙供材料.ToString()).Sum(p => p.SCDJ * p.XHL);
            //市场评标指定材料
            m_ResultValue.PBZDCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.评标指定材料.ToString()).Sum(p => p.SCDJ * p.XHL);
            //市场暂定价材料
            m_ResultValue.ZDJCL = list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.YTLB == UseType.暂定价材料.ToString()).Sum(p => p.SCDJ * p.XHL);
        }

        /// <summary>
        /// 计算百分号材料合计
        /// </summary>
        /// <param name="p_list"></param>
        private void JSBFH(_SubheadingsQuantityUnitList p_list)
        {
            m_ResultValue.CLBFHHJ = 0m;
            m_ResultValue.JXBFHHJ = 0m;
            m_ResultValue.RGBFHHJ = 0m;
            _SubheadingsQuantityUnitInfo m_TSInfo = p_list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.YSBH == "11705" && p.LB.Contains("%")).FirstOrDefault();
            if (m_TSInfo != null)
            {
                m_ResultValue.CLBFHHJ += p_list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.BH == "10088" || p.BH == "10087" || p.BH == "10544").Sum(p => p.SCDJ * p.XHL) / 100 * m_TSInfo.XHL;
            }

            IEnumerable<_SubheadingsQuantityUnitInfo> bfhlist = p_list.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.LB.Contains("%") && p.YSBH != "11705");
            foreach (_SubheadingsQuantityUnitInfo item in bfhlist)
            {
                switch (item.LB)
                {
                    case "材料%":
                        m_ResultValue.CLBFHHJ += (p_list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.LB == "材料").Sum(p => p.GetType() == typeof(_QuantityUnitComponentInfo) ? p.SCHJ * (p as _QuantityUnitComponentInfo).Parent.XHL : p.SCHJ) / 100 * item.XHL);
                        break;
                    case "机械%":
                        m_ResultValue.JXBFHHJ += (p_list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.LB == "机械").Sum(p => p.GetType() == typeof(_QuantityUnitComponentInfo) ? p.SCHJ * (p as _QuantityUnitComponentInfo).Parent.XHL : p.SCHJ) / 100 * item.XHL);
                        break;
                    case "人工%":
                        m_ResultValue.RGBFHHJ += (p_list.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.LB == "人工").Sum(p => p.GetType() == typeof(_QuantityUnitComponentInfo) ? p.SCHJ * (p as _QuantityUnitComponentInfo).Parent.XHL : p.SCHJ) / 100 * item.XHL);
                        break;
                    default:
                        break;
                }
            }
            m_ResultValue.RGFDJ += m_ResultValue.RGBFHHJ;
            m_ResultValue.CLFDJ += m_ResultValue.CLBFHHJ;
            m_ResultValue.JXFDJ += m_ResultValue.JXBFHHJ;
            m_ResultValue.HHJXFDJ += m_ResultValue.JXBFHHJ;

        }

        /// <summary>
        /// 计算 投标金额、标底金额
        /// </summary>
        /// <param name="ifCpTBJE">是否计算投标金额</param>
        public void CalculateParentTBJE_BDJE()
        {
            IEnumerable<_SubheadingsFeeInfo> list = this.Parent.SubheadingsFeeList.Cast<_SubheadingsFeeInfo>().OrderBy(p => p.ID);
            

            foreach (_SubheadingsFeeInfo item in list)
            {
                string tbjsjc = ToolKit.ExpressionReplace(item.TBJSJC, this.Variable.DataSource);
                string bdjsjc = ToolKit.ExpressionReplace(item.BDJSJC, this.Variable.DataSource);
                switch (item.ID)
                {
                    case 1://人工
                        item.TBJE = (ToolKit.Calculate(tbjsjc)) * item.FL * 0.01m;
                        item.BDJE = (ToolKit.Calculate(bdjsjc)) * item.FL * 0.01m;
                        break;
                    case 2://材料
                        item.TBJE = (ToolKit.Calculate(tbjsjc)) * item.FL * 0.01m;
                        item.BDJE = (ToolKit.Calculate(bdjsjc)) * item.FL * 0.01m;
                        //用途类别材料
                        m_ResultValue.JGCL = m_ResultValue.JGCL * item.FL * 0.01m;
                        m_ResultValue.YGCL = m_ResultValue.YGCL * item.FL * 0.01m;
                        m_ResultValue.PBZDCL = m_ResultValue.PBZDCL * item.FL * 0.01m;
                        m_ResultValue.ZDJCL = m_ResultValue.ZDJCL * item.FL * 0.01m;
                        m_ResultValue.DEJGCL = m_ResultValue.DEJGCL * item.FL * 0.01m;
                        m_ResultValue.DEYGCL = m_ResultValue.DEYGCL * item.FL * 0.01m;
                        m_ResultValue.DEPBZDCL = m_ResultValue.DEPBZDCL * item.FL * 0.01m;
                        m_ResultValue.DEZDJCL = m_ResultValue.DEZDJCL * item.FL * 0.01m;
                        break;
                    case 3://机械
                        item.TBJE = (ToolKit.Calculate(tbjsjc)) * item.FL * 0.01m;
                        item.BDJE = (ToolKit.Calculate(bdjsjc)) * item.FL * 0.01m;
                        //
                        m_ResultValue.DZJXTB = m_ResultValue.DZJXTB * item.FL * 0.01m;
                        break;
                    case 4://主材
                    case 5://设备
                    case 6://风险
                    case 7://直接费
                    case 8://管理费
                    case 9://利润
                    case 10://子目单价
                    case 11://合价
                        item.TBJE = ToolKit.Calculate(tbjsjc) * item.FL * 0.01m;
                        item.BDJE = ToolKit.Calculate(bdjsjc) * item.FL * 0.01m;
                        break;
                }
                this.DEVariable.Set(item.YYH,item.BDJE, item.MC, item.FYLB);
                this.Variable.Set(item.YYH, item.TBJE, item.MC, item.FYLB);
            }
        }

        /// <summary>
        /// 传递结果
        /// </summary>
        public void TransferResults()
        {
            //定额
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZJFDJ, this.DEVariable.GetDecimalBYFylb("直接费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DERGFDJ, this.DEVariable.GetDecimalBYFylb("人工费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DECLFDJ, this.DEVariable.GetDecimalBYFylb("材料费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEJXFDJ, this.DEVariable.GetDecimalBYFylb("机械费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZCFDJ, this.DEVariable.GetDecimalBYFylb("主材费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DESBFDJ, this.DEVariable.GetDecimalBYFylb("设备费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEFXDJ, this.DEVariable.GetDecimalBYFylb("风险单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEGLFDJ, this.DEVariable.GetDecimalBYFylb("管理费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DELRDJ, this.DEVariable.GetDecimalBYFylb("利润单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZHDJ, this.DEVariable.GetDecimalBYFylb("子目单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEGFDJ, this.DEVariable.GetDecimalBYFylb("规费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DESJDJ, this.DEVariable.GetDecimalBYFylb("税金单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEJGJEDJ, this.Variable.GetDecimal("DEJGCL"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEYGJEDJ, this.Variable.GetDecimal("DEYGCL"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEPBZDDJ, this.Variable.GetDecimal("DEPBZDCL"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZGDJ, this.Variable.GetDecimal("DEZDJCL"));

            //市场
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZJFDJ, this.Variable.GetDecimalBYFylb("直接费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_RGFDJ, this.Variable.GetDecimalBYFylb("人工费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_CLFDJ, this.Variable.GetDecimalBYFylb("材料费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_JXFDJ, this.Variable.GetDecimalBYFylb("机械费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZCFDJ, this.Variable.GetDecimalBYFylb("主材费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_SBFDJ, this.Variable.GetDecimalBYFylb("设备费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FXDJ, this.Variable.GetDecimalBYFylb("风险单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_GLFDJ, this.Variable.GetDecimalBYFylb("管理费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_LRDJ, this.Variable.GetDecimalBYFylb("利润单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZHDJ, this.Variable.GetDecimalBYFylb("子目单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_GFDJ, this.Variable.GetDecimalBYFylb("规费单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_SJDJ, this.Variable.GetDecimalBYFylb("税金单价"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_JGJEDJ, this.Variable.GetDecimal("JGCL"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_YGJEDJ, this.Variable.GetDecimal("YGCL"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_PBZDDJ, this.Variable.GetDecimal("PBZDCL"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZGDJ, this.Variable.GetDecimal("ZDJCL"));

            //价差
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXJCDJ, this.DEVariable.GetDecimal("JCDJ"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXRGJCDJ, this.DEVariable.GetDecimal("RGJCDJ"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXCLJCDJ, this.DEVariable.GetDecimal("CLJCDJ"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXJXJCDJ, this.DEVariable.GetDecimal("JXJCDJ"));
            //差价
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXCJDJ, this.DEVariable.GetDecimal("CJDJ"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXRGCJDJ, this.DEVariable.GetDecimal("RGCJDJ"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXCLCJDJ, this.DEVariable.GetDecimal("CLCJDJ"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FBFXJXCJDJ, this.DEVariable.GetDecimal("JXCJDJ"));
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
