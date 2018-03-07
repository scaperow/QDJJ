/*
 用于处理子目 单项 单位 项目统计标准类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Statistics
    {
        public bool IsCompled = false;

        #region-------------字段常量定义------------------------

        /// <summary>
        /// 综合单价
        /// </summary>
        public const string FILED_ZHDJ = "ZHDJ";
        /// <summary>
        /// 直接费单价
        /// </summary>
        public const string FILED_ZJFDJ = "ZJFDJ";
        /// <summary>
        /// 人工费单价
        /// </summary>
        public const string FILED_RGFDJ = "RGFDJ";
        /// <summary>
        /// 材料费单价
        /// </summary>
        public const string FILED_CLFDJ = "CLFDJ";
        /// <summary>
        /// 主材费单价
        /// </summary>
        public const string FILED_ZCFDJ = "ZCFDJ";
        /// <summary>
        /// 设备费单价
        /// </summary>
        public const string FILED_SBFDJ = "SBFDJ";
        /// <summary>
        /// 机械费单价
        /// </summary>
        public const string FILED_JXFDJ = "JXFDJ";
        /// <summary>
        /// 管理费单价
        /// </summary>
        public const string FILED_GLFDJ = "GLFDJ";
        /// <summary>
        /// 利润单价
        /// </summary>
        public const string FILED_LRDJ = "LRDJ";
        /// <summary>
        /// 风险单价
        /// </summary>
        public const string FILED_FXDJ = "FXDJ";
        /// <summary>
        /// 规费单价
        /// </summary>
        public const string FILED_GFDJ = "GFDJ";
        /// <summary>
        /// 税金单价
        /// </summary>
        public const string FILED_SJDJ = "SJDJ";


        /// <summary>
        /// 综合和价
        /// </summary>
        public const string FILED_ZHHJ = "ZHHJ";
        /// <summary>
        /// 直接费合价
        /// </summary>
        public const string FILED_ZJFHJ = "ZJFHJ";
        /// <summary>
        /// 人工费合价
        /// </summary>
        public const string FILED_RGFHJ = "RGFHJ";
        /// <summary>
        /// 材料费合价
        /// </summary>
        public const string FILED_CLFHJ = "CLFHJ";
        /// <summary>
        /// 主材费合价
        /// </summary>
        public const string FILED_ZCFHJ = "ZCFHJ";
        /// <summary>
        /// 设备费合价
        /// </summary>
        public const string FILED_SBFHJ = "SBFHJ";
        /// <summary>
        /// 机械费合价
        /// </summary>
        public const string FILED_JXFHJ = "JXFHJ";
        /// <summary>
        /// 管理费合价
        /// </summary>
        public const string FILED_GLFHJ = "GLFHJ";
        /// <summary>
        /// 利润合价
        /// </summary>
        public const string FILED_LRHJ = "LRHJ";
        /// <summary>
        /// 风险合价
        /// </summary>
        public const string FILED_FXHJ = "FXHJ";
        /// <summary>
        /// 规费合价
        /// </summary>
        public const string FILED_GFHJ = "GFHJ";
        /// <summary>
        /// 税金合价
        /// </summary>
        public const string FILED_SJHJ = "SJHJ";


        /// <summary>
        /// 定额综合单价
        /// </summary>
        public const string FILED_DEZHDJ = "DEZHDJ";
        /// <summary>
        /// 定额直接费单价
        /// </summary>
        public const string FILED_DEZJFDJ = "DEZJFDJ";
        /// <summary>
        /// 定额人工费单价
        /// </summary>
        public const string FILED_DERGFDJ = "DERGFDJ";
        /// <summary>
        /// 定额材料费单价
        /// </summary>
        public const string FILED_DECLFDJ = "DECLFDJ";
        /// <summary>
        /// 定额主材费单价
        /// </summary>
        public const string FILED_DEZCFDJ = "DEZCFDJ";
        /// <summary>
        /// 定额设备费单价
        /// </summary>
        public const string FILED_DESBFDJ = "DESBFDJ";
        /// <summary>
        /// 定额机械费单价
        /// </summary>
        public const string FILED_DEJXFDJ = "DEJXFDJ";
        /// <summary>
        /// 定额管理费单价
        /// </summary>
        public const string FILED_DEGLFDJ = "DEGLFDJ";
        /// <summary>
        /// 定额利润单价
        /// </summary>
        public const string FILED_DELRDJ = "DELRDJ";
        /// <summary>
        /// 定额风险单价
        /// </summary>
        public const string FILED_DEFXDJ = "DEFXDJ";
        /// <summary>
        /// 定额规费单价
        /// </summary>
        public const string FILED_DEGFDJ = "DEGFDJ";
        /// <summary>
        /// 定额税金单价
        /// </summary>
        public const string FILED_DESJDJ = "DESJDJ";


        /// <summary>
        /// 定额综合合价
        /// </summary>
        public const string FILED_DEZHHJ = "DEZHHJ";
        /// <summary>
        /// 定额直接费合价
        /// </summary>
        public const string FILED_DEZJFHJ = "DEZJFHJ";
        /// <summary>
        /// 定额人工费合价
        /// </summary>
        public const string FILED_DERGFHJ = "DERGFHJ";
        /// <summary>
        /// 定额材料费合价
        /// </summary>
        public const string FILED_DECLFHJ = "DECLFHJ";
        /// <summary>
        /// 定额主材费合价
        /// </summary>
        public const string FILED_DEZCFHJ = "DEZCFHJ";
        /// <summary>
        /// 定额设备费合价
        /// </summary>
        public const string FILED_DESBFHJ = "DESBFHJ";
        /// <summary>
        /// 定额机械费合价
        /// </summary>
        public const string FILED_DEJXFHJ = "DEJXFHJ";
        /// <summary>
        /// 定额管理费合价
        /// </summary>
        public const string FILED_DEGLFHJ = "DEGLFHJ";
        /// <summary>
        /// 定额利润合价
        /// </summary>
        public const string FILED_DELRHJ = "DELRHJ";
        /// <summary>
        /// 定额风险合价
        /// </summary>
        public const string FILED_DEFXHJ = "DEFXHJ";
        /// <summary>
        /// 定额规费合价
        /// </summary>
        public const string FILED_DEGFHJ = "DEGFHJ";
        /// <summary>
        /// 定额税金合价
        /// </summary>
        public const string FILED_DESJHJ = "DESJHJ";


        /// <summary>
        /// 价差
        /// </summary>
        public const string FILED_JCDJ = "JCDJ";
        /// <summary>
        /// 差价
        /// </summary>
        public const string FILED_CJDJ = "CJDJ";
        /// <summary>
        /// 价差合价
        /// </summary>
        public const string FILED_JCHJ = "JCHJ";
        /// <summary>
        /// 差价合价
        /// </summary>
        public const string FILED_CJHJ = "CJHJ";
        ///// <summary>
        ///// 混合机械人工费
        ///// </summary>
        //public const string FILED_HHJXRGF = "HHJXRGF";
        ///// <summary>
        ///// 定额混合机械人工费
        ///// </summary>
        //public const string FILED_DEHHJXRGF = "DEHHJXRGF";
        ///// <summary>
        ///// 混合机械人工费价差
        ///// </summary>
        //public const string FILED_HHJXRGFJC = "HHJXRGFJC";

        /// <summary>
        /// 甲供金额单价
        /// </summary>
        public const string FILED_JGJEDJ = "JGJEDJ";

        /// <summary>
        /// 乙供金额单价
        /// </summary>
        public const string FILED_YGJEDJ = "YGJEDJ";
        /// <summary>
        /// 评标指定单价
        /// </summary>
        public const string FILED_PBZDDJ = "PBZDDJ";
        /// <summary>
        /// 暂估单价
        /// </summary>
        public const string FILED_ZGDJ = "ZGDJ";
        /// <summary>
        /// 分包金额单价
        /// </summary>
        public const string FILED_FBJEDJ = "FBJEDJ";

        /// <summary>
        /// 甲供金额合价
        /// </summary>
        public const string FILED_JGJEHJ = "JGJEHJ";

        /// <summary>
        /// 乙供金额合价
        /// </summary>
        public const string FILED_YGJEHJ = "YGJEHJ";
        /// <summary>
        /// 评标指定合价
        /// </summary>
        public const string FILED_PBZDHJ = "PBZDHJ";
        /// <summary>
        /// 暂估合价
        /// </summary>
        public const string FILED_ZGHJ = "ZGHJ";
        /// <summary>
        /// 分包金额合价
        /// </summary>
        public const string FILED_FBJEHJ = "FBJEHJ";


        /// <summary>
        /// 定额甲供金额单价
        /// </summary>
        public const string FILED_DEJGJEDJ = "DEJGJEDJ";

        /// <summary>
        /// 定额乙供金额单价
        /// </summary>
        public const string FILED_DEYGJEDJ = "DEYGJEDJ";
        /// <summary>
        /// 定额评标指定单价
        /// </summary>
        public const string FILED_DEPBZDDJ = "DEPBZDDJ";
        /// <summary>
        /// 定额暂估单价
        /// </summary>
        public const string FILED_DEZGDJ = "DEZGDJ";
        /// <summary>
        /// 定额分包金额单价
        /// </summary>
        public const string FILED_DEFBJEDJ = "DEFBJEDJ";

        /// <summary>
        /// 定额甲供金额合价
        /// </summary>
        public const string FILED_DEJGJEHJ = "DEJGJEHJ";

        /// <summary>
        /// 定额乙供金额合价
        /// </summary>
        public const string FILED_DEYGJEHJ = "DEYGJEHJ";
        /// <summary>
        /// 定额评标指定合价
        /// </summary>
        public const string FILED_DEPBZDHJ = "DEPBZDHJ";
        /// <summary>
        /// 定额暂估合价
        /// </summary>
        public const string FILED_DEZGHJ = "DEZGHJ";
        /// <summary>
        /// 定额分包金额合价
        /// </summary>
        public const string FILED_DEFBJEHJ = "DEFBJEHJ";

        /// <summary>
        /// 分部分项价差单价
        /// </summary>
        public const string FILED_FBFXJCDJ = "FBFXJCDJ";
        /// <summary>
        /// 分部分项人工费价差单价
        /// </summary>
        public const string FILED_FBFXRGJCDJ = "FBFXRGJCDJ";
        /// <summary>
        /// 分部分项材料费价差单价
        /// </summary>
        public const string FILED_FBFXCLJCDJ = "FBFXCLJCDJ";
        /// <summary>
        /// 分部分项机械费价差单价
        /// </summary>
        public const string FILED_FBFXJXJCDJ = "FBFXJXJCDJ";
        /// <summary>
        /// 分部分项差价单价
        /// </summary>
        public const string FILED_FBFXCJDJ = "FBFXCJDJ";
        /// <summary>
        /// 分部分项人工费差价单价
        /// </summary>
        public const string FILED_FBFXRGCJDJ = "FBFXRGCJDJ";
        /// <summary>
        /// 分部分项材料费差价单价
        /// </summary>
        public const string FILED_FBFXCLCJDJ = "FBFXCLCJDJ";
        /// <summary>
        /// 分部分项机械费差价单价
        /// </summary>
        public const string FILED_FBFXJXCJDJ = "FBFXJXCJDJ";

        /// <summary>
        /// 分部分项价差合价
        /// </summary>
        public const string FILED_FBFXJCHJ = "FBFXJCHJ";
        /// <summary>
        /// 分部分项人工费价差合价
        /// </summary>
        public const string FILED_FBFXRGJCHJ = "FBFXRGJCHJ";
        /// <summary>
        /// 分部分项材料费价差合价
        /// </summary>
        public const string FILED_FBFXCLJCHJ = "FBFXCLJCHJ";
        /// <summary>
        /// 分部分项机械费价差合价
        /// </summary>
        public const string FILED_FBFXJXJCHJ = "FBFXJXJCHJ";
        /// <summary>
        /// 分部分项差价合价
        /// </summary>
        public const string FILED_FBFXCJHJ = "FBFXCJHJ";
        /// <summary>
        /// 分部分项人工费差价合价
        /// </summary>
        public const string FILED_FBFXRGCJHJ = "FBFXRGCJHJ";
        /// <summary>
        /// 分部分项材料费差价合价
        /// </summary>
        public const string FILED_FBFXCLCJHJ = "FBFXCLCJHJ";
        /// <summary>
        /// 分部分项机械费差价合价
        /// </summary>
        public const string FILED_FBFXJXCJHJ = "FBFXJXCJHJ";

        /// <summary>
        /// 措施项目价差单价
        /// </summary>
        public const string FILED_CSXMJCDJ = "CSXMJCDJ";
        /// <summary>
        /// 措施项目人工费价差单价
        /// </summary>
        public const string FILED_CSXMRGJCDJ = "CSXMRGJCDJ";
        /// <summary>
        /// 措施项目材料费价差单价
        /// </summary>
        public const string FILED_CSXMCLJCDJ = "CSXMCLJCDJ";
        /// <summary>
        /// 措施项目机械费价差单价
        /// </summary>
        public const string FILED_CSXMJXJCDJ = "CSXMJXJCDJ";
        /// <summary>
        /// 措施项目差价单价
        /// </summary>
        public const string FILED_CSXMCJDJ = "CSXMCJDJ";
        /// <summary>
        /// 措施项目人工费差价单价
        /// </summary>
        public const string FILED_CSXMRGCJDJ = "CSXMRGCJDJ";
        /// <summary>
        /// 措施项目材料费差价单价
        /// </summary>
        public const string FILED_CSXMCLCJDJ = "CSXMCLCJDJ";
        /// <summary>
        /// 措施项目机械费差价单价
        /// </summary>
        public const string FILED_CSXMJXCJDJ = "CSXMJXCJDJ";

        /// <summary>
        /// 措施项目价差合价
        /// </summary>
        public const string FILED_CSXMJCHJ = "CSXMJCHJ";
        /// <summary>
        /// 措施项目人工费价差合价
        /// </summary>
        public const string FILED_CSXMRGJCHJ = "CSXMRGJCHJ";
        /// <summary>
        /// 措施项目材料费价差合价
        /// </summary>
        public const string FILED_CSXMCLJCHJ = "CSXMCLJCHJ";
        /// <summary>
        /// 措施项目机械费价差合价
        /// </summary>
        public const string FILED_CSXMJXJCHJ = "CSXMJXJCHJ";
        /// <summary>
        /// 措施项目差价合价
        /// </summary>
        public const string FILED_CSXMCJHJ = "CSXMCJHJ";
        /// <summary>
        /// 措施项目人工费差价合价
        /// </summary>
        public const string FILED_CSXMRGCJHJ = "CSXMRGCJHJ";
        /// <summary>
        /// 措施项目材料费差价合价
        /// </summary>
        public const string FILED_CSXMCLCJHJ = "CSXMCLCJHJ";
        /// <summary>
        /// 措施项目机械费差价合价
        /// </summary>
        public const string FILED_CSXMJXCJHJ = "CSXMJXCJHJ";

        #endregion
        private _ObjectInfo m_Parent;

        public virtual _ObjectInfo Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        /// <summary>
        /// 计算结果集合
        /// </summary>
        private _CVariable m_ResultVarable = null;

        /// <summary>
        /// 计算结果集合
        /// </summary>
        public _CVariable ResultVarable
        {
            get
            {
                return this.m_ResultVarable;
            }
            set
            {
                this.m_ResultVarable = value;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public _Statistics(_ObjectInfo p_Parent)
        {
            this.m_Parent = p_Parent;
            m_ResultVarable = new _CVariable();
            builder();
        }

        /// <summary>
        /// 空构造函数
        /// </summary>
        public _Statistics()
        {
            m_ResultVarable = new _CVariable();
            builder();
        }
        /// <summary>
        /// 创建结果集变量
        /// </summary>
        private void builder()
        {

            #region  市场价计算的变量定义
            //市场单价的定义
            this.ResultVarable.Set("ZHDJ", 0, "综合单价");
            this.ResultVarable.Set("ZJFDJ", 0, "直接费单价");
            this.ResultVarable.Set("RGFDJ", 0, "人工费单价");
            this.ResultVarable.Set("CLFDJ", 0, "材料费单价");
            this.ResultVarable.Set("ZCFDJ", 0, "主材费单价");
            this.ResultVarable.Set("SBFDJ", 0, "设备费单价");
            this.ResultVarable.Set("JXFDJ", 0, "机械费单价");
            this.ResultVarable.Set("GLFDJ", 0, "管理费单价");
            this.ResultVarable.Set("LRDJ", 0, "利润单价");
            this.ResultVarable.Set("FXDJ", 0, "风险单价");

            this.ResultVarable.Set("JGJEDJ", 0, "甲供金额单价");
            this.ResultVarable.Set("YGJEDJ", 0, "乙供金额单价");
            this.ResultVarable.Set("PBZDDJ", 0, "评标指定单价");
            this.ResultVarable.Set("ZGDJ", 0, "暂估单价");
            this.ResultVarable.Set("FBJEDJ", 0, "分包金额单价");

            //市场合价的定义
            this.ResultVarable.Set("ZHHJ", 0, "综合合价");
            this.ResultVarable.Set("ZJFHJ", 0, "直接费合价");
            this.ResultVarable.Set("RGFHJ", 0, "人工费合价");
            this.ResultVarable.Set("CLFHJ", 0, "材料费合价");
            this.ResultVarable.Set("ZCFHJ", 0, "主材费合价");
            this.ResultVarable.Set("SBFHJ", 0, "设备费合价");
            this.ResultVarable.Set("JXFHJ", 0, "机械费合价");
            this.ResultVarable.Set("GLFHJ", 0, "管理费合价");
            this.ResultVarable.Set("LRHJ", 0, "利润合价");
            this.ResultVarable.Set("FXHJ", 0, "风险合价");

            this.ResultVarable.Set("JGJEHJ", 0, "甲供金额合价");
            this.ResultVarable.Set("YGJEHJ", 0, "乙供金额合价");
            this.ResultVarable.Set("PBZDHJ", 0, "评标指定合价");
            this.ResultVarable.Set("ZGHJ", 0, "暂估合价");
            this.ResultVarable.Set("FBJEHJ", 0, "分包金额合价");
            #endregion


            #region  定额价计算的变量定义

            //定额单价的定义
            this.ResultVarable.Set("DEZHDJ", 0, "定额综合单价");
            this.ResultVarable.Set("DEZJFDJ", 0, "定额直接费单价");
            this.ResultVarable.Set("DERGFDJ", 0, "定额人工费单价");
            this.ResultVarable.Set("DECLFDJ", 0, "定额材料费单价");
            this.ResultVarable.Set("DEZCFDJ", 0, "定额主材费单价");
            this.ResultVarable.Set("DESBFDJ", 0, "定额设备费单价");
            this.ResultVarable.Set("DEJXFDJ", 0, "定额机械费单价");
            this.ResultVarable.Set("DEGLFDJ", 0, "定额管理费单价");
            this.ResultVarable.Set("DELRDJ", 0, "定额利润单价");
            this.ResultVarable.Set("DEFXDJ", 0, "定额风险单价");

            this.ResultVarable.Set("DEJGJEDJ", 0, "定额甲供金额单价");
            this.ResultVarable.Set("DEYGJEDJ", 0, "定额乙供金额单价");
            this.ResultVarable.Set("DEPBZDDJ", 0, "定额评标指定单价");
            this.ResultVarable.Set("DEZGDJ", 0, "定额暂估单价");
            this.ResultVarable.Set("DEFBJEDJ", 0, "定额分包金额单价");

            //定额和价的定义
            this.ResultVarable.Set("DEZHHJ", 0, "定额综合合价");
            this.ResultVarable.Set("DEZJFHJ", 0, "定额直接费合价");
            this.ResultVarable.Set("DERGFHJ", 0, "定额人工费合价");
            this.ResultVarable.Set("DECLFHJ", 0, "定额材料费合价");
            this.ResultVarable.Set("DEZCFHJ", 0, "定额主材费合价");
            this.ResultVarable.Set("DESBFHJ", 0, "定额设备费合价");
            this.ResultVarable.Set("DEJXFHJ", 0, "定额机械费合价");
            this.ResultVarable.Set("DEGLFHJ", 0, "定额管理费合价");
            this.ResultVarable.Set("DELRHJ", 0, "定额利润合价");
            this.ResultVarable.Set("DEFXHJ", 0, "定额风险合价");

            this.ResultVarable.Set("DEJGJEHJ", 0, "定额甲供金额合价");
            this.ResultVarable.Set("DEYGJEHJ", 0, "定额乙供金额合价");
            this.ResultVarable.Set("DEPBZDHJ", 0, "定额评标指定合价");
            this.ResultVarable.Set("DEZGHJ", 0, "定额暂估合价");
            this.ResultVarable.Set("DEFBJEHJ", 0, "定额分包金额合价");

            #endregion


            #region  价差计算的变量定义
            //单价
            this.ResultVarable.Set("JCDJ", 0, "价差");
            this.ResultVarable.Set("CJDJ", 0, "差价");
            //合价
            this.ResultVarable.Set("JCHJ", 0, "价差合价");
            this.ResultVarable.Set("CJHJ", 0, "差价合价");
            #endregion


        }

        private  void SetValue()
        {

            decimal GCL = this.Parent.GCL;

            #region //定额价计算
            this.ResultVarable.Set(_Statistics.FILED_DEZHHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEZHDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEZJFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEZJFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEGLFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEGLFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DESBFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DESBFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEZCFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEZCFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEJXFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEJXFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DECLFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DECLFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DERGFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DERGFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEFXHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEFXDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DELRHJ, ResultVarable.GetDecimal(_Statistics.FILED_DELRDJ) * GCL);

            this.ResultVarable.Set(_Statistics.FILED_DEJGJEHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEJGJEDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEYGJEHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEYGJEDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEPBZDHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEPBZDDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEZGHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEZGDJ) * GCL);
            #endregion


            #region //市场价计算
            this.ResultVarable.Set(_Statistics.FILED_ZHHJ, ResultVarable.GetDecimal(_Statistics.FILED_ZHDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_ZJFHJ, ResultVarable.GetDecimal(_Statistics.FILED_ZJFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_GLFHJ, ResultVarable.GetDecimal(_Statistics.FILED_GLFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_SBFHJ, ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_ZCFHJ, ResultVarable.GetDecimal(_Statistics.FILED_ZCFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_JXFHJ, ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_CLFHJ, ResultVarable.GetDecimal(_Statistics.FILED_CLFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_RGFHJ, ResultVarable.GetDecimal(_Statistics.FILED_RGFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FXHJ, ResultVarable.GetDecimal(_Statistics.FILED_FXDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_LRHJ, ResultVarable.GetDecimal(_Statistics.FILED_LRDJ) * GCL);

            this.ResultVarable.Set(_Statistics.FILED_JGJEHJ, ResultVarable.GetDecimal(_Statistics.FILED_JGJEDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_YGJEHJ, ResultVarable.GetDecimal(_Statistics.FILED_YGJEDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_PBZDHJ, ResultVarable.GetDecimal(_Statistics.FILED_PBZDDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_ZGHJ, ResultVarable.GetDecimal(_Statistics.FILED_ZGDJ) * GCL);

            
            //this.ResultVarable.Set(_Statistics.FILED_HHJXRGF, ResultVarable.GetDecimal(_Statistics.FILED_HHJXRGF) * GCL);
            //this.ResultVarable.Set(_Statistics.FILED_DEHHJXRGF, ResultVarable.GetDecimal(_Statistics.FILED_DEHHJXRGF) * GCL);
            //this.ResultVarable.Set(_Statistics.FILED_HHJXRGFJC, ResultVarable.GetDecimal(_Statistics.FILED_HHJXRGFJC) * GCL);

            this.ResultVarable.Set(_Statistics.FILED_FBFXCJHJ, ResultVarable.GetDecimal(_Statistics.FILED_CJDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXJCHJ, ResultVarable.GetDecimal(_Statistics.FILED_JCDJ) * GCL);

            this.ResultVarable.Set(_Statistics.FILED_FBFXJCHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXJCDJ)*GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXRGJCHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXRGJCDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXCLJCHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXCLJCDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXJXJCHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXJXJCDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXCJHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXCJDJ) * GCL);

            this.ResultVarable.Set(_Statistics.FILED_FBFXRGCJHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXRGCJDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXCLCJHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXCLCJDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_FBFXJXCJHJ, ResultVarable.GetDecimal(_Statistics.FILED_FBFXJXCJDJ) * GCL);

            this.ResultVarable.Set(_Statistics.FILED_GFHJ, ResultVarable.GetDecimal(_Statistics.FILED_GFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_SJHJ, ResultVarable.GetDecimal(_Statistics.FILED_SJDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEGFHJ, ResultVarable.GetDecimal(_Statistics.FILED_DEGFDJ) * GCL);
            this.ResultVarable.Set(_Statistics.FILED_DESJHJ, ResultVarable.GetDecimal(_Statistics.FILED_DESJDJ) * GCL);

        }
        public virtual void Begin()
        {
            _SubheadingsInfo info = this.Parent as _SubheadingsInfo;
            if (info.ZJFS == _Constant.公式组价)
            {
                string str = info.JSJC;
                if (string.IsNullOrEmpty(str)) str = "0";
                // this.Activitie.Property.Statistics.Begin();
                str = ToolKit.ExpressionReplace(str, info.Activitie.Property.Statistics.ResultVarable.DataSource);
                decimal m = 1m;
                decimal.TryParse(info.FL, out m);
                decimal ZHHJ = ToolKit.Calculate(str) * m * info.GCL * 0.01m;

                this.ResultVarable.Set(_Statistics.FILED_ZHHJ, ZHHJ);
                if (this.Parent.GCL != 0m)
                {
                    this.ResultVarable.Set(_Statistics.FILED_ZHDJ, info.ZHHJ / this.Parent.GCL);
                }

            }
            else
            {
                SetValue();
            }
            #endregion

            SetValueToView(); ;

        }
        public virtual void Calculate()
        {
           // this.Begin();
        }

        public  virtual void SetValueToView()
        {/*
            #region //赋值到界面
            this.Parent.ZHDJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHDJ);
            this.Parent.ZJFDJ = ResultVarable.GetDecimal(_Statistics.FILED_ZJFDJ);
            this.Parent.GLFDJ = ResultVarable.GetDecimal(_Statistics.FILED_GLFDJ);
            this.Parent.SBFDJ = ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ);
            this.Parent.JXFDJ = ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ);
            this.Parent.ZHDJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHDJ);
            this.Parent.CLFDJ = ResultVarable.GetDecimal(_Statistics.FILED_CLFDJ);
            this.Parent.RGFDJ = ResultVarable.GetDecimal(_Statistics.FILED_RGFDJ);
            this.Parent.FXDJ = ResultVarable.GetDecimal(_Statistics.FILED_FXDJ);
            this.Parent.LRDJ = ResultVarable.GetDecimal(_Statistics.FILED_LRDJ);
            this.Parent.ZCFDJ = ResultVarable.GetDecimal(_Statistics.FILED_ZCFDJ);
            this.Parent.JXFDJ = ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ);
            this.Parent.SBFDJ = ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ);
            this.Parent.JCDJ = ResultVarable.GetDecimal(_Statistics.FILED_FBFXJCDJ);
            this.Parent.CJDJ = ResultVarable.GetDecimal(_Statistics.FILED_FBFXCJDJ);

            //合价的赋值
            this.Parent.ZHHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ);
            this.Parent.ZJFHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZJFHJ);
            this.Parent.GLFHJ = ResultVarable.GetDecimal(_Statistics.FILED_GLFHJ);
            this.Parent.SBFHJ = ResultVarable.GetDecimal(_Statistics.FILED_SBFHJ);
            this.Parent.JXFHJ = ResultVarable.GetDecimal(_Statistics.FILED_JXFHJ);
            this.Parent.ZHHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ);
            this.Parent.CLFHJ = ResultVarable.GetDecimal(_Statistics.FILED_CLFHJ);
            this.Parent.RGFHJ = ResultVarable.GetDecimal(_Statistics.FILED_RGFHJ);
            this.Parent.FXHJ = ResultVarable.GetDecimal(_Statistics.FILED_FXHJ);
            this.Parent.LRHJ = ResultVarable.GetDecimal(_Statistics.FILED_LRHJ);

            this.Parent.ZCFHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZCFHJ);
            this.Parent.JXFHJ = ResultVarable.GetDecimal(_Statistics.FILED_JXFHJ);
            this.Parent.SBFHJ = ResultVarable.GetDecimal(_Statistics.FILED_SBFHJ);
            this.Parent.JCHJ = ResultVarable.GetDecimal(_Statistics.FILED_FBFXJCHJ);
            this.Parent.CJHJ = ResultVarable.GetDecimal(_Statistics.FILED_FBFXCJHJ);


           // this.Parent.JCHJ = ResultVarable.GetDecimal(_Statistics.FILED_JCHJ);
           // this.Parent.CJHJ = ResultVarable.GetDecimal(_Statistics.FILED_CJHJ);
            this.Parent.ZGJE = ResultVarable.GetDecimal(_Statistics.FILED_ZGHJ);

            this.Parent.PBZD = ResultVarable.GetDecimal(_Statistics.FILED_PBZDHJ);
            this.Parent.JGJE = ResultVarable.GetDecimal(_Statistics.FILED_JGJEHJ);
            this.Parent.YGJE = ResultVarable.GetDecimal(_Statistics.FILED_YGJEHJ);
         

            this.Parent.GFDJ = ResultVarable.GetDecimal(_Statistics.FILED_GFDJ);
            this.Parent.GFHJ = ResultVarable.GetDecimal(_Statistics.FILED_GFHJ);
            this.Parent.SJDJ = ResultVarable.GetDecimal(_Statistics.FILED_SJDJ);
            this.Parent.SJHJ = ResultVarable.GetDecimal(_Statistics.FILED_SJHJ);


            #endregion
          */
        }

    }
}
