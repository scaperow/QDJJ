using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MSScriptControl;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 子目基础结果类
    /// </summary>
    [Serializable]
    public class _MSubheadings_Statistics
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _MSubheadings_Statistics(_MSubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
            //准备子目变量
            this.m_Variable = new _CVariable();
            this.m_DEVariable = new _CVariable();
            this.builder();
        }

        /// <summary>
        /// 子目统计预处理的结构体
        /// </summary>
        [Serializable]
        public struct ResultValue
        {
            //直接费单价
            public decimal ZJFDJ;
            //人工费单价
            public decimal RGFDJ;
            //材料费单价
            public decimal CLFDJ;
            //机械费单价
            public decimal JXFDJ;
            //主材费单价
            public decimal ZCFDJ;
            //设备费单价
            public decimal SBFDJ;
            //定额直接费单价
            public decimal DEZJFDJ;
            //定额人工费单价
            public decimal DERGFDJ;
            //定额材料费
            public decimal DECLFDJ;
            //定额主材费单价
            public decimal DEZCFDJ;
            //定额设备费单价
            public decimal DESBFDJ;
            //定额机械费单价
            public decimal DEJXFDJ;
            //价差
            public decimal JC;
            //工程量
            public decimal GCL;
            //参与风险的人才机
            public decimal FXRCJ;
            //吊装机械台班
            public decimal DZJXTB;
            //甲供材料
            public decimal JGCL;
            //乙供材料
            public decimal YGCL;
            //评标指定材料
            public decimal PBZDCL;
            //暂定价材料
            public decimal ZDJCL;
            //定额甲供材料
            public decimal DEJGCL;
            //定额乙供材料
            public decimal DEYGCL;
            //定额评标指定材料
            public decimal DEPBZDCL;
            //定额暂定价材料
            public decimal DEZDJCL;
            //人工%合计
            public decimal RGBFHHJ;
            //材料%合计
            public decimal CLBFHHJ;
            //机械%合计
            public decimal JXBFHHJ;

        }

        private string m_Prefix = "DE";

        /// <summary>
        /// 当前对象所属对象
        /// </summary>
        private _MSubheadingsInfo m_Parent = null;

        /// <summary>
        /// 需要统计的工料机表
        /// </summary>
        private DataTable m_DataTable = null;

        /// <summary>
        /// 计算结果集合
        /// </summary>
        private _CVariable m_ResultVarable = null;

        /// <summary>
        /// 用于处理统计后的变量结果集
        /// </summary>
        private _CVariable m_Variable = null;

        /// <summary>
        /// 用于处理统计后的变量结果集
        /// </summary>
        private _CVariable m_DEVariable = null;

        private ResultValue m_ResultValue;

        public ResultValue ResultValues
        {
            get { return m_ResultValue; }
            set { m_ResultValue = value; }
        }

        private ResultValue m_BaseResultValue;
        /// <summary>
        /// 基础数据计算结果
        /// </summary>
        public ResultValue BaseResultValue
        {
            get { return m_BaseResultValue; }
            set { m_BaseResultValue = value; }
        }

        /// <summary>
        /// 获取当前对象的所属对象
        /// </summary>
        public _MSubheadingsInfo Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        /// <summary>
        /// 获取或设置当前统计的数据源
        /// </summary>
        public DataTable Source
        {
            get { return this.m_DataTable; }
            set { this.m_DataTable = value; }
        }

        /// <summary>
        /// 获取或设置当前清单或子目的变量对象
        /// </summary>
        public _CVariable Variable
        {
            get { return this.m_Variable; }
            set { this.m_Variable = value; }
        }

        /// <summary>
        /// 获取或设置当前清单或子目的变量对象
        /// </summary>
        public _CVariable DEVariable
        {
            get { return this.m_DEVariable; }
            set { this.m_DEVariable = value; }
        }


        /// <summary>
        /// 创建子目变量对象
        /// </summary>
        private void builder()
        {
            this.Variable.Set("ZJFDJ", 0, "[子目]直接费单价");
            this.Variable.Set("RGFDJ", 0, "[子目]人工费单价");
            this.Variable.Set("CLFDJ", 0, "[子目]材料费单价");
            this.Variable.Set("JXFDJ", 0, "[子目]机械费单价");
            this.Variable.Set("ZCFDJ", 0, "[子目]主材费单价");
            this.Variable.Set("SBFDJ", 0, "[子目]设备费单价");
            this.Variable.Set("DEZJFDJ", 0, "[子目]定额直接费单价");
            this.Variable.Set("DERGFDJ", 0, "[子目]定额人工费单价");
            this.Variable.Set("DECLFDJ", 0, "[子目]定额材料费单价");
            this.Variable.Set("DEJXFDJ", 0, "[子目]定额机械费单价");
            this.Variable.Set("DEZCFDJ", 0, "[子目]定额主材费单价");
            this.Variable.Set("DESBFDJ", 0, "[子目]定额设备费单价");
            this.Variable.Set("JC", 0, "[子目]价差");
            this.Variable.Set("GCL", 0, "[子目]工程量");
            this.Variable.Set("FXRCJ", 0, "[子目]参与风险的人材机");
        }

        /// <summary>
        /// 请求子目统计操作
        /// </summary>
        public void Begin()
        {
            this.CalculateBasicData(this.Parent.SubheadingsQuantityUnitList);
            this.Parent.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
            FBegin();
        }

        /// <summary>
        ///  设置变量值
        /// </summary>
        private void setVariable()
        {
            this.Variable.Set("ZJFDJ", this.m_BaseResultValue.ZCFDJ);
            this.Variable.Set("RGFDJ", this.m_BaseResultValue.RGFDJ);
            this.Variable.Set("CLFDJ", this.m_BaseResultValue.CLFDJ);
            this.Variable.Set("JXFDJ", this.m_BaseResultValue.JXFDJ);
            this.Variable.Set("ZCFDJ", this.m_BaseResultValue.ZCFDJ);
            this.Variable.Set("SBFDJ", this.m_BaseResultValue.SBFDJ);
            this.Variable.Set("DEZJFDJ", this.m_BaseResultValue.DEZCFDJ);
            this.Variable.Set("DERGFDJ", this.m_BaseResultValue.DERGFDJ);
            this.Variable.Set("DECLFDJ", this.m_BaseResultValue.DECLFDJ);
            this.Variable.Set("DEJXFDJ", this.m_BaseResultValue.DEJXFDJ);
            this.Variable.Set("DEZCFDJ", this.m_BaseResultValue.DEZCFDJ);
            this.Variable.Set("DESBFDJ", this.m_BaseResultValue.DESBFDJ);
            this.Variable.Set("JC", this.m_BaseResultValue.JC);
            this.Variable.Set("GCL", this.m_BaseResultValue.GCL);
            this.Variable.Set("FXRCJ", this.m_BaseResultValue.FXRCJ);
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
            //赋值
            this.setVariable();
        }

        /// <summary>
        /// 其他统计
        /// </summary>
        /// <param name="table"></param>
        private void Other(_SubheadingsQuantityUnitList list)
        {
            //工程量
            m_BaseResultValue.GCL = this.Parent.GCL;
            //价差和
            m_BaseResultValue.JC = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                select info.DJC).Sum();
            //风险人材机
            m_BaseResultValue.FXRCJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                   where info.IFFX == true
                                   select info.SCHJ).Sum();
            //吊装机械台班
            m_BaseResultValue.DZJXTB = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                    where info.LB == "吊装机械台班"
                                    select info.SCHJ).Sum();
        }

        /// <summary>
        /// 定额合价统计
        /// </summary>
        /// <param name="table"></param>
        private void DEHJ(_SubheadingsQuantityUnitList list)
        {
            //定额人工费单价
            m_BaseResultValue.DERGFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                     where _Constant.rg.Contains("'" + info.LB + "'")
                                     select info.DEHJ).Sum();
            //定额材料费单价
            m_BaseResultValue.DECLFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                     where _Constant.cl.Contains("'" + info.LB + "'")
                                     select info.DEHJ).Sum();
            //定额机械费单价
            m_BaseResultValue.DEJXFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                     where _Constant.jx.Contains("'" + info.LB + "'")
                                     select info.DEHJ).Sum();
            //定额主材费单价
            m_BaseResultValue.DEZCFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                     where _Constant.zc.Contains("'" + info.LB + "'")
                                     select info.DEHJ).Sum();
            //定额设备费单价
            m_BaseResultValue.DESBFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                     where _Constant.sb.Contains("'" + info.LB + "'")
                                     select info.DEHJ).Sum();

            //定额甲供材料
            m_BaseResultValue.DEJGCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                        where info.YTLB == UseType.甲供材料.ToString()
                                    select info.DEHJ).Sum();
            //定额乙供材料
            m_BaseResultValue.DEYGCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                        where info.YTLB == UseType.甲定乙供材料.ToString()
                                    select info.DEHJ).Sum();
            //定额评标指定材料
            m_BaseResultValue.DEPBZDCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                          where info.YTLB == UseType.评标指定材料.ToString()
                                      select info.DEHJ).Sum();
            //定额暂定价材料
            m_BaseResultValue.DEZDJCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                         where info.YTLB == UseType.暂定价材料.ToString()
                                     select info.DEHJ).Sum();
        }

        /// <summary>
        /// 市场合价统计
        /// </summary>
        /// <param name="table"></param>
        private void SCHJ(_SubheadingsQuantityUnitList list)
        {

            //市场人工费单价
            m_BaseResultValue.RGFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                   where _Constant.rg.Contains("'" + info.LB + "'")
                                   select info.SCHJ).Sum();
            //市场材料费单价
            m_BaseResultValue.CLFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                   where _Constant.cl.Contains("'" + info.LB + "'")
                                   select info.SCHJ).Sum();
            //市场机械费单价
            m_BaseResultValue.JXFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                   where _Constant.jx.Contains("'" + info.LB + "'")
                                   select info.SCHJ).Sum();
            //市场主材费单价
            m_BaseResultValue.ZCFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                   where _Constant.zc.Contains("'" + info.LB + "'")
                                   select info.SCHJ).Sum();
            //市场设备费单价
            m_BaseResultValue.SBFDJ = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                   where _Constant.sb.Contains("'" + info.LB + "'")
                                   select info.SCHJ).Sum();

            //市场甲供材料
            m_BaseResultValue.JGCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                      where info.YTLB == UseType.甲供材料.ToString()
                                  select info.SCHJ).Sum();
            //市场乙供材料
            m_BaseResultValue.YGCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                      where info.YTLB == UseType.甲定乙供材料.ToString()
                                  select info.SCHJ).Sum();
            //市场评标指定材料
            m_BaseResultValue.PBZDCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                        where info.YTLB == UseType.评标指定材料.ToString()
                                    select info.SCHJ).Sum();
            //市场暂定价材料
            m_BaseResultValue.ZDJCL = (from info in list.Cast<_SubheadingsQuantityUnitInfo>()
                                       where info.YTLB == UseType.暂定价材料.ToString()
                                   select info.SCHJ).Sum();
        }

        /// <summary>
        /// 计算百分号材料合计
        /// </summary>
        /// <param name="p_list"></param>
        private void JSBFH(_SubheadingsQuantityUnitList p_list)
        {
            m_BaseResultValue.CLBFHHJ = 0m;
            m_BaseResultValue.JXBFHHJ = 0m;
            m_BaseResultValue.RGBFHHJ = 0m;
            IEnumerable<_SubheadingsQuantityUnitInfo> list = p_list.Cast<_SubheadingsQuantityUnitInfo>();
            IEnumerable<_SubheadingsQuantityUnitInfo> tslist = list.Where(p => p.YSBH == "11705");
            if (tslist.Count() == 1)
            {
                IEnumerable<_SubheadingsQuantityUnitInfo> tslists = list.Where(p => p.BH == "10088" || p.BH == "10087" || p.BH == "10544");
                decimal mcbfb = 0;
                foreach (_SubheadingsQuantityUnitInfo item in tslists)
                {
                    mcbfb += item.SCHJ;
                }
                _SubheadingsQuantityUnitInfo tsinfo = tslist.First();
                m_BaseResultValue.CLBFHHJ = mcbfb / 100 * tsinfo.XHL;
            }

            IEnumerable<_SubheadingsQuantityUnitInfo> bfhlist = list.Where(p => p.LB.Contains("%") && p.YSBH != "11705");
            foreach (_SubheadingsQuantityUnitInfo item in bfhlist)
            {
                switch (item.LB)
                {
                    case "材料%":
                        m_BaseResultValue.CLBFHHJ = list.Where(p => p.LB == "材料").Sum(p => p.SCHJ) / 100 * item.XHL;
                        break;
                    case "机械%":
                        m_BaseResultValue.JXBFHHJ = list.Where(p => p.LB == "机械").Sum(p => p.SCHJ) / 100 * item.XHL;
                        break;
                    case "人工%":
                        m_BaseResultValue.RGBFHHJ = list.Where(p => p.LB == "人工").Sum(p => p.SCHJ) / 100 * item.XHL;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 计算 投标金额、标底金额
        /// </summary>
        /// <param name="ifCpTBJE">是否计算投标金额</param>
        public void CalculateParentTBJE_BDJE()
        {
            IEnumerable<_SubheadingsFeeInfo> list = from info in this.Parent.SubheadingsFeeList.Cast<_SubheadingsFeeInfo>()
                                                     orderby info.ID
                                                     select info;

            foreach (_SubheadingsFeeInfo item in list)
            {
                string tbjsjc = ToolKit.ExpressionReplace(item.TBJSJC, this.Variable.DataSource);
                string bdjsjc = ToolKit.ExpressionReplace(item.BDJSJC, this.Variable.DataSource);
                switch (item.ID)
                {
                    case 1:
                        item.TBJE = (ToolKit.Calculate(tbjsjc) + m_BaseResultValue.RGBFHHJ) * item.FL * 0.01m;
                        item.BDJE = (ToolKit.Calculate(bdjsjc) + m_BaseResultValue.RGBFHHJ) * item.FL * 0.01m;
                        break;
                    case 2:
                        item.TBJE = (ToolKit.Calculate(tbjsjc) + m_BaseResultValue.CLBFHHJ) * item.FL * 0.01m;
                        item.BDJE = (ToolKit.Calculate(bdjsjc) + m_BaseResultValue.CLBFHHJ) * item.FL * 0.01m;
                        break;
                    case 3:
                        item.TBJE = (ToolKit.Calculate(tbjsjc) + m_BaseResultValue.JXBFHHJ) * item.FL * 0.01m;
                        item.BDJE = (ToolKit.Calculate(bdjsjc) + m_BaseResultValue.JXBFHHJ) * item.FL * 0.01m;
                        break;
                    default:
                        item.TBJE = ToolKit.Calculate(tbjsjc) * item.FL * 0.01m;
                        item.BDJE = ToolKit.Calculate(bdjsjc) * item.FL * 0.01m;
                        break;
                }
                this.Variable.Set(item.YYH, item.TBJE, item.MC);
                this.DEVariable.Set(item.YYH, item.BDJE, item.MC);
                //其他条件计算
                if (item.ID == 2)
                {
                    m_ResultValue.JGCL = m_BaseResultValue.JGCL * item.FL;
                    m_ResultValue.YGCL = m_BaseResultValue.YGCL * item.FL;
                    m_ResultValue.PBZDCL = m_BaseResultValue.PBZDCL * item.FL;
                    m_ResultValue.ZDJCL = m_BaseResultValue.ZDJCL * item.FL;

                    m_ResultValue.DEJGCL = m_BaseResultValue.DEJGCL * item.FL;
                    m_ResultValue.DEYGCL = m_BaseResultValue.DEYGCL * item.FL;
                    m_ResultValue.DEPBZDCL = m_BaseResultValue.DEPBZDCL * item.FL;
                    m_ResultValue.DEZDJCL = m_BaseResultValue.DEZDJCL * item.FL;
                }
                if (item.ID == 3)
                {
                    m_ResultValue.DZJXTB = m_BaseResultValue.DZJXTB * item.FL;
                }
            }
        }

        private decimal Calculate(string CalculationInfo)
        {
            try
            {
                ScriptControl sc = new ScriptControlClass();
                sc.Language = "JavaScript";
                string str = sc.Eval(CalculationInfo).ToString();
                return Convert.ToDecimal(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 传递结果
        /// </summary>
        public void TransferResults()
        {
            //定额
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZJFDJ, this.DEVariable.GetDecimal("一"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DERGFDJ, this.DEVariable.GetDecimal("F1"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DECLFDJ, this.DEVariable.GetDecimal("F2"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEJXFDJ, this.DEVariable.GetDecimal("F3"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZCFDJ, this.DEVariable.GetDecimal("F4"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DESBFDJ, this.DEVariable.GetDecimal("F5"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEFXDJ, this.DEVariable.GetDecimal("F6"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEGLFDJ, this.DEVariable.GetDecimal("二"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DELRDJ, this.DEVariable.GetDecimal("三"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZHDJ, this.DEVariable.GetDecimal("四"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEJGJEDJ, this.m_ResultValue.DEJGCL);
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEYGJEDJ, this.m_ResultValue.DEYGCL);
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEPBZDDJ, this.m_ResultValue.DEPBZDCL);
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_DEZGDJ, this.m_ResultValue.DEZDJCL);

            //市场
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZJFDJ, this.Variable.GetDecimal("一"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_RGFDJ, this.Variable.GetDecimal("F1"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_CLFDJ, this.Variable.GetDecimal("F2"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_JXFDJ, this.Variable.GetDecimal("F3"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZCFDJ, this.Variable.GetDecimal("F4"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_SBFDJ, this.Variable.GetDecimal("F5"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_FXDJ, this.Variable.GetDecimal("F6"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_GLFDJ, this.Variable.GetDecimal("二"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_LRDJ, this.Variable.GetDecimal("三"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZHDJ, this.Variable.GetDecimal("四"));
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_JGJEDJ, this.m_ResultValue.JGCL);
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_YGJEDJ, this.m_ResultValue.YGCL);
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_PBZDDJ, this.m_ResultValue.PBZDCL);
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_ZGDJ, this.m_ResultValue.ZDJCL);

            //其他
            this.Parent.Statistics.ResultVarable.Set(_Statistics.FILED_JCDJ, this.Variable.GetDecimal("JC"));

        }

        /// <summary>
        /// 子目取费计算的公共方法
        /// </summary>
        public void FBegin()
        {
            CalculateParentTBJE_BDJE();
            TransferResults();
            this.Parent.SubheadingsFeeList_BindingSource.ResetBindings(false);
            this.Parent.Begin();
        }
    }
}
