using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
   public class _Statistics
    {


       /// <summary>
       /// 数据源
       /// </summary>
       public _ObjectSource DataSource = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary>
        public _UnitProject Unit;
        /// <summary>
        /// 当前操作的对象
        /// </summary>
        public _Entity_SubInfo Current;
        public BUSINESS._Business Business;
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
        public _Statistics(_Entity_SubInfo p_info,_UnitProject p_Unit)
       {
           this.Current = p_info;
           this.Unit = p_Unit;
       }
        public _Statistics(_UnitProject p_Parent)
        {
        }

        public virtual void SetValueToView()
        {
            
            _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;

            #region //赋值到界面
            this.Current.ZHDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ);
            this.Current.ZJFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFDJ);
            this.Current.GLFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFDJ);
            this.Current.SBFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ);
            this.Current.JXFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ);
            this.Current.ZHDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ);
            this.Current.CLFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFDJ);
            this.Current.RGFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFDJ);
            this.Current.FXDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXDJ);
            this.Current.LRDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRDJ);
            this.Current.ZCFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFDJ);
            this.Current.JXFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ);
            this.Current.SBFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ);
            this.Current.JCDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCDJ);
            this.Current.CJDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJDJ);

            //合价的赋值
            this.Current.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ);
            this.Current.ZJFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFHJ);
            this.Current.GLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFHJ);
            this.Current.SBFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ);
            this.Current.JXFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ);
            this.Current.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ);
            this.Current.CLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFHJ);
            this.Current.RGFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFHJ);
            this.Current.FXHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXHJ);
            this.Current.LRHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRHJ);

            this.Current.ZCFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFHJ);
            this.Current.JXFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ);
            this.Current.SBFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ);
            this.Current.JCHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCHJ);
            this.Current.CJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJHJ);

            this.Current.RGFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXRGJCHJ);
            this.Current.CLFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXCLJCHJ);
            this.Current.JXFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXJXJCHJ);

           // this.Current.JCHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JCHJ);
           // this.Current.CJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CJHJ);
            this.Current.ZGJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGHJ);

            this.Current.PBZD = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDHJ);
            this.Current.JGJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEHJ);
            this.Current.YGJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEHJ);
         

            this.Current.GFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFDJ);
            this.Current.GFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFHJ);
            this.Current.SJDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJDJ);
            this.Current.SJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJHJ);


            #endregion
          
        }
    }
}
