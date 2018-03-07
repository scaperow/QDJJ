/*
 清单，子目对象的基础类别
 * 此处定义 清单或者子目的所有基础字段的定义
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public abstract class _ObjectInfo : _BaseObject, ICloneable, ISubSegment, IDataSerializable
    {

       


        /// <summary>
        /// 子目最终结果
        /// </summary>
        [NonSerialized]
        private _Statistics m_Statistics = null;

        /// <summary>
        /// 获取或设置：子目最终结果
        /// </summary>
        public virtual _Statistics Statistics
        {
            get { return m_Statistics; }
            set { m_Statistics = value; }
        }


        #region----------------------字段常量定义---------------------------------
        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "CENTITYSUBSEGMENT";
        /// <summary>
        ///ID
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        ///父ID
        /// </summary>
        public const string FILED_PARENID = "PARENTID";


        /// <summary>
        ///ID
        /// </summary>
        public const string FILED_PPARENTID = "PPARENTID";
   
        public const string FILED_FPARENID = "FPARENTID";

        public const string FILED_CPARENID = "CPARENTID";



        /// <summary>
        ///序号
        /// </summary>
        public const string FILED_XH = "XH";
        /// <summary>
        ///项目编码
        /// </summary>
        public const string FILED_XMBM = "XMBM";
        /// <summary>
        ///原始项目编码
        /// </summary>
        public const string FILED_OLDXMBM = "OLDXMBM";
        /// <summary>
        ///项目名称
        /// </summary>
        public const string FILED_XMMC = "XMMC";
        /// <summary>
        ///单位
        /// </summary>
        public const string FILED_DW = "DW";
        /// <summary>
        ///特项
        /// </summary>
        public const string FILED_TX = "TX";
        /// <summary>
        ///类别
        /// </summary>
        public const string FILED_LB = "LB";
        /// <summary>
        ///检查标记
        /// </summary>
        public const string FILED_JCBJ = "JCBJ";
        /// <summary>
        ///复核标记
        /// </summary>
        public const string FILED_FHBJ = "FHBJ";
        /// <summary>
        ///主要清单
        /// </summary>
        public const string FILED_ZYQD = "ZYQD";
        /// <summary>
        ///项目特征
        /// </summary>
        public const string FILED_XMTZ = "XMTZ";
        /// <summary>
        ///锁定单价
        /// </summary>
        public const string FILED_SDDJ = "SDDJ";
        /// <summary>
        ///工程量计算式
        /// </summary>
        public const string FILED_GCLJSS = "GCLJSS";
        /// <summary>
        ///含量
        /// </summary>
        public const string FILED_HL = "HL";
        /// <summary>
        ///工程量
        /// </summary>
        public const string FILED_GCL = "GCL";
        /// <summary>
        ///直接调价
        /// </summary>
        public const string FILED_ZJTJ = "ZJTJ";
        /// <summary>
        ///综合单价
        /// </summary>
        public const string FILED_ZHDJ = "ZHDJ";
        /// <summary>
        ///综合合价
        /// </summary>
        public const string FILED_ZHHJ = "ZHHJ";
        /// <summary>
        ///直接费单价
        /// </summary>
        public const string FILED_ZJFDJ = "ZJFDJ";
        /// <summary>
        ///人工费单价
        /// </summary>
        public const string FILED_RGFDJ = "RGFDJ";
        /// <summary>
        ///材料费单价
        /// </summary>
        public const string FILED_CLFDJ = "CLFDJ";
        /// <summary>
        ///机械费单价
        /// </summary>
        public const string FILED_JXFDJ = "JXFDJ";
        /// <summary>
        ///主材费单价
        /// </summary>
        public const string FILED_ZCFDJ = "ZCFDJ";
        /// <summary>
        ///设备费单价
        /// </summary>
        public const string FILED_SBFDJ = "SBFDJ";
        /// <summary>
        ///管理费单价
        /// </summary>
        public const string FILED_GLFDJ = "GLFDJ";
        /// <summary>
        ///利润单价
        /// </summary>
        public const string FILED_LRDJ = "LRDJ";
        /// <summary>
        ///风险单价
        /// </summary>
        public const string FILED_FXDJ = "FXDJ";
        /// <summary>
        ///规费单价
        /// </summary>
        public const string FILED_GFDJ = "GFDJ";
        /// <summary>
        ///税金单价
        /// </summary>
        public const string FILED_SJDJ = "SJDJ";
        /// <summary>
        ///直接费合价
        /// </summary>
        public const string FILED_ZJFHJ = "ZJFHJ";
        /// <summary>
        ///人工费合价
        /// </summary>
        public const string FILED_RGFHJ = "RGFHJ";
        /// <summary>
        ///材料费合价
        /// </summary>
        public const string FILED_CLFHJ = "CLFHJ";
        /// <summary>
        ///机械费合价
        /// </summary>
        public const string FILED_JXFHJ = "JXFHJ";
        /// <summary>
        ///主材费合价
        /// </summary>
        public const string FILED_ZCFHJ = "ZCFHJ";
        /// <summary>
        ///设备费合价
        /// </summary>
        public const string FILED_SBFHJ = "SBFHJ";
        /// <summary>
        ///管理费合价
        /// </summary>
        public const string FILED_GLFHJ = "GLFHJ";
        /// <summary>
        ///利润合价
        /// </summary>
        public const string FILED_LRHJ = "LRHJ";
        /// <summary>
        ///风险合价
        /// </summary>
        public const string FILED_FXHJ = "FXHJ";
        /// <summary>
        ///规费合价
        /// </summary>
        public const string FILED_GFHJ = "GFHJ";
        /// <summary>
        ///税金合价
        /// </summary>
        public const string FILED_SJHJ = "SJHJ";
        /// <summary>
        ///价差合计
        /// </summary>
        public const string FILED_JCHJ = "JCHJ";
        /// <summary>
        ///差价合计
        /// </summary>
        public const string FILED_CJHJ = "CJHJ";
        /// <summary>
        ///暂估金额
        /// </summary>
        public const string FILED_ZGJE = "ZGJE";
        /// <summary>
        ///甲供金额
        /// </summary>
        public const string FILED_JGJE = "JGJE";
        /// <summary>
        ///是否分包
        /// </summary>
        public const string FILED_SFFB = "SFFB";
        /// <summary>
        ///分包金额
        /// </summary>
        public const string FILED_FBJE = "FBJE";
        /// <summary>
        ///局部汇总
        /// </summary>
        public const string FILED_JBHZ = "JBHZ";
        /// <summary>
        ///章节位置
        /// </summary>
        public const string FILED_ZJWZ = "ZJWZ";
        /// <summary>
        ///降效
        /// </summary>
        public const string FILED_JX = "JX";
        /// <summary>
        ///檐高类别
        /// </summary>
        public const string FILED_YGLB = "YGLB";
        /// <summary>
        ///输出
        /// </summary>
        public const string FILED_SC = "SC";
        /// <summary>
        ///取费设置
        /// </summary>
        public const string FILED_QFSZ = "QFSZ";
        /// <summary>
        ///备注
        /// </summary>
        public const string FILED_BEIZHU = "BEIZHU";

        /// <summary>
        ///库名称
        /// </summary>
        public const string FILED_LibraRYNAME = "LIBRARYNAMe";


        public const string FILED_DECJ = "DECJ";
        /// <summary>
        ///锁定清单
        /// </summary>
        public const string FILED_SDQD = "SDQD";
        public const string FILED_LY = "LY";

        public const string FILED_JSJC = "JSJC";
        public const string FILED_FL = "FL";

        public const string FILED_ZJFS = "ZJFS";

        public const string FILED_ZDSC = "ZDSC";
        public const string FILED_ZYLB = "ZYLB";

     
        #endregion

        //#region -----------------------基础属性----------------------
        ///// <summary>
        ///// 原始主键
        ///// </summary>
        //private int m_Key = -1;
        ///// <summary>
        ///// 父级类别主键
        ///// </summary>
        //private int m_ParentKey;
        
        ///// <summary>
        ///// 获取或设计原始主键
        ///// </summary>
        //public int Key { get { return this.m_Key; } set { this.m_Key = value; } }
        
        ///// <summary>
        ///// 获取或设置原始父级类别
        ///// </summary>
        //public int ParentKey { get { return this.m_ParentKey; } set { this.m_ParentKey = value; } }

        //#endregion

        #region ---------------------------私有变量-----------------------------
        private int m_ID;
        private int m_PARENTID;

        private int m_PPARENTID;
        private int m_CPARENTID;
        private int m_FPARENTID;
        private string m_XMBM = string.Empty;
        private string m_OLDXMBM = string.Empty;
        private string m_XMMC = string.Empty;
        private string m_DW = string.Empty;
        private string m_TX = string.Empty;
        private string m_LB = string.Empty;
        private bool m_JCBJ;
        private bool m_FHBJ;
        private bool m_ZYQD;
        private string m_XMTZ = string.Empty;
        private bool m_SDDJ;
        private string m_GCLJSS = string.Empty;
        private bool m_JBHZ=true;
        private string m_ZJWZ = string.Empty;
        private bool m_JX;
        private string m_YGLB = string.Empty;
        private bool m_SC=true;
        private string m_QFSZ = string.Empty;
        private string m_BEIZHU = string.Empty;
        private string m_LibraryName = string.Empty;
        private string m_LY = string.Empty;
        private string m_DECJ = string.Empty;
        private bool m_SDQD;
        private bool m_SFFB;
        private decimal m_HL;
        private decimal m_GCL=1m;
        private decimal m_ZJTJ;
        private decimal m_ZHDJ;
        private decimal m_ZHHJ;
        private decimal m_ZJFDJ;
        private decimal m_RGFDJ;
        private decimal m_CLFDJ;
        private decimal m_JXFDJ;
        private decimal m_ZCFDJ;
        private decimal m_SBFDJ;
        private decimal m_GLFDJ;
        private decimal m_LRDJ;
        private decimal m_FXDJ;
        private decimal m_GFDJ;
        private decimal m_SJDJ;
        private decimal m_ZJFHJ;
        private decimal m_RGFHJ;
        private decimal m_CLFHJ;
        private decimal m_JXFHJ;
        private decimal m_ZCFHJ;
        private decimal m_SBFHJ;
        private decimal m_GLFHJ;
        private decimal m_LRHJ;
        private decimal m_FXHJ;
        private decimal m_GFHJ;
        private decimal m_SJHJ;
        private decimal m_JCHJ;
        private decimal m_CJHJ;
        private decimal m_ZGJE;
        private decimal m_JGJE;
        private decimal m_FBJE;
        private decimal m_XHL;
        private decimal m_YGJE;
        private decimal m_PBZD;
        private decimal m_JCDJ;
        private decimal m_CJDJ;
        private bool m_ISTY;
        private string m_XMNR;
        private string m_XMTZZ;
        private string m_TYGS = string.Empty;
        private bool m_ZDSC;
        private bool m_ISXSHS = true;
        private long m_Sort;

        private string m_ZYLB=string.Empty;
        
        /// <summary>
        /// 图元公式
        /// </summary>
        public string TYGS
        {
            get { return m_TYGS; }
            set { m_TYGS = value; }
        }
       
        /// <summary>
        /// 标识是否通用项目的前四项
        /// </summary>
        public bool ISTY
        {
            get { return m_ISTY; }
            set { m_ISTY = value; }
        }
        /// <summary>
        /// 评标指定金额
        /// </summary>
        public decimal PBZD
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_PBZDHJ); }
            set { m_PBZD = value; }
        }

        /// <summary>
        /// 乙供金额
        /// </summary>
        public decimal YGJE
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_YGJEHJ); }
            set { m_YGJE = value; }
        }

        private int m_XH;
        /// <summary>
        /// 状态
        /// </summary>
        private bool m_STATUS = false;

        public bool STATUS
        {
            get { return m_STATUS; }
            set { m_STATUS = value; }
        }
        /// <summary>
        /// 自动生成
        /// </summary>
        public bool ZDSC
        {
            get { return m_ZDSC; }
            set { m_ZDSC = value; }
        }
        private string m_TJNR=string.Empty;
        /// <summary>
        /// 【标准图集】
        /// </summary>
        public string TJNR
        {
            get { return m_TJNR; }
            set { m_TJNR = value; }
        }
        private string m_XMTZ1 = string.Empty;

        /// <summary>
        /// 【项目特征】
        /// </summary>
        public string XMTZ1
        {
            get { return m_XMTZ1; }
            set { m_XMTZ1 = value; }
        }
        private string m_GCNR = string.Empty;
        /// <summary>
        /// 【工程内容】
        /// </summary>
        public string GCNR
        {
            get { return m_GCNR; }
            set { m_GCNR = value; }
        }

        #endregion

        #region --------------------------通用业务属性--------------------------
        public virtual long Sort
        {
            get
            {
                return this.m_Sort;
            }
            set { this.m_Sort = value; }
        }
        public virtual ISubSegment IParent { get { return null; } }
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID
        {
            get { return m_ID; }
            set { m_ID = value;  }
        }
        /// <summary>
        /// 父级ID （专业章节全部显示的时候）
        /// </summary>
        public int PARENTID
        {
            get { return m_PARENTID; }
            set { m_PARENTID = value; }
        }

        /// <summary>
        /// 专业的时候fuid
        /// </summary>
        public int PPARENTID
        {
            get { return m_PPARENTID; }
            set { m_PPARENTID = value; }
        }
        /// <summary>
        /// 在章的时候使用父级ID
        /// </summary>
        public int CPARENTID
        {
            get { return m_CPARENTID; }
            set { m_CPARENTID = value;  }
        }
       
        /// <summary>
        /// 不显示任何章节时的父id
        /// </summary>
        public int FPARENTID
        {
            get { return m_FPARENTID; }
            set { m_FPARENTID = value; }
        }
        /// <summary>
        /// 序   号
        /// </summary>
        public int XH
        {
            get { return m_XH; }
            set { m_XH = value; }
        }
        /// <summary>
        /// 项目编码
        /// </summary>
        public virtual  string XMBM
        {
            get { return m_XMBM; }
            set { m_XMBM = value; }
        }
        /// <summary>
        /// 原始项目编码
        /// </summary>
        public string OLDXMBM
        {
            get { return m_OLDXMBM; }
            set { m_OLDXMBM = value; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        [ModifyAttribute("XMMC", "XMMC", "项目名称")]
        public string XMMC
        {
            get { return m_XMMC+this.m_XMTZ; }
            set { 
                this.ModifyAttribute("XMMC", value, m_XMMC);
                if (value.Contains('【'))
                {
                    this.m_XMTZ = value.Substring(value.IndexOf("【"));
                    m_XMMC = value.Substring(0, value.IndexOf("【"));
                }
                else
                {
                    m_XMMC = value;
                }
                
            }
        }
        public string XMMC1
        {
            get { return m_XMMC ; }
        }
        public string DMC
        {
            get { return string.Format("{0} |{1}", m_XMBM,m_XMMC); }
            //set { m_XMMC = value; }
        }

        /// <summary>
        /// 单   位
        /// </summary>
        [ModifyAttribute("DW", "DW", "单位")]
        public string DW
        {
            get { return m_DW; }
            set {
                this.ModifyAttribute("DW", value, m_DW);
                    m_DW = value; 
                }
        }
        /// <summary>
        /// 特   项
        /// </summary>
        public string TX
        {
            get { return m_TX; }
            set { m_TX = value; }
        }
        /// <summary>
        /// 类   别
        /// </summary>
        public string LB
        {
            get { return m_LB; }
            set { m_LB = value; }
        }
        /// <summary>
        /// 检查标记
        /// </summary>
        [ModifyAttribute("JCBJ", "JCBJ", "检查标记")]
        public bool JCBJ
        {
            get { return m_JCBJ; }
            set { this.ModifyAttribute("JCBJ", value, m_JCBJ); ;m_JCBJ = value; }
        }
        /// <summary>
        /// 复核标记
        /// </summary>
        [ModifyAttribute("FHBJ", "FHBJ", "复核标记")]
        public bool FHBJ
        {
            get { return m_FHBJ; }
            set { this.ModifyAttribute("FHBJ", value, m_FHBJ); m_FHBJ = value; }
        }
        /// <summary>
        /// 主要清单
        /// </summary>
        [ModifyAttribute("ZYQD", "ZYQD", "主要清单")]
        public bool ZYQD
        {
            get { return m_ZYQD; }
            set { this.ModifyAttribute("ZYQD", value, m_ZYQD); m_ZYQD = value; }
        }
        /// <summary>
        /// 项目特征
        /// </summary>
        [ModifyAttribute("XMTZ", "XMTZ", "主要清单")]
        public string XMTZ
        {
            get { return m_XMTZ; }
            set { this.ModifyAttribute("XMTZ", value, m_XMTZ); m_XMTZ = value; }
        }
        /// <summary>
        /// 锁定单价
        /// </summary>
        [ModifyAttribute("SDDJ", "SDDJ", "锁定单价")]
        public bool SDDJ
        {
            get { return m_SDDJ; }
            set { this.ModifyAttribute("SDDJ", value, m_SDDJ); m_SDDJ = value; }
        }
        /// <summary>
        /// 工程量计算式
        /// </summary>
        [ModifyAttribute("GCLJSS", "GCLJSS", "工程量计算式")]
        public virtual string GCLJSS
        {
            get { return m_GCLJSS; }
            set {

                this.ModifyAttribute("GCLJSS", value, m_GCLJSS);
                m_GCLJSS = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this.GCL =ToolKit.ParseDecimal (ToolKit.Expression(value));//工程量计算式 发生改变  改变当前的 工程量
                }
            }
        }


        /// <summary>
        /// 局部汇总
        /// </summary>
        [ModifyAttribute("JBHZ", "JBHZ", "局部汇总")]
        public virtual bool JBHZ
        {
            get { return m_JBHZ; }
            set { this.ModifyAttribute("JBHZ", value, m_JBHZ); m_JBHZ = value; }
        }
        /// <summary>
        /// 章节位置
        /// </summary>
        public string ZJWZ
        {
            get { return m_ZJWZ; }
            set { m_ZJWZ = value; }
        }
        /// <summary>
        /// 降效
        /// </summary>
        [ModifyAttribute("JX", "JX", "降效")]
        public bool JX
        {
            get { return m_JX; }
            set { this.ModifyAttribute("JX", value, m_JX); m_JX = value; }
        }
        /// <summary>
        /// 檐高类别
        /// </summary>
        public string YGLB
        {
            get { return m_YGLB; }
            set { m_YGLB = value; }
        }
        /// <summary>
        /// 输出
        /// </summary>
        [ModifyAttribute("SC", "SC", "输出")]
        public bool SC
        {
            get { return m_SC; }
            set {
                this.ModifyAttribute("SC", value, m_SC); m_SC = value; 
                }
        }
        /// <summary>
        /// 取费设置
        /// </summary>
        public string QFSZ
        {
            get { return m_QFSZ; }
            set { m_QFSZ = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [ModifyAttribute("BEIZHU", "BEIZHU", "备注")]
        public string BEIZHU
        {
            get { return m_BEIZHU; }
            set { this.ModifyAttribute("BEIZHU", value, m_BEIZHU); m_BEIZHU = value; }
        }
        /// <summary>
        /// 来源的库
        /// </summary>
        public string LibraryName
        {
            get { return m_LibraryName; }
            set { m_LibraryName = value; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string LY
        {
            get { return m_LY; }
            set { m_LY = value; }
        }
        /// <summary>
        /// 锁定清单
        /// </summary>
        [ModifyAttribute("SDQD", "SDQD", "锁定清单")]
        public bool SDQD
        {
            get { return m_SDQD; }
            set { this.ModifyAttribute("SDQD", value, m_SDQD); m_SDQD = value; }
        }
        /// <summary>
        /// 是否分包
        /// </summary>
        [ModifyAttribute("SFFB", "SFFB", "是否分包")]
        public virtual bool SFFB
        {
            get { return m_SFFB; }
            set { this.ModifyAttribute("SFFB", value, m_SFFB); m_SFFB = value; }
        }
        /// <summary>
        /// 含量
        /// </summary>
        [ModifyAttribute("HL", "HL", "含量")]
        public  virtual decimal HL
        {
            get { return m_HL; }
            set { this.ModifyAttribute("HL", value, m_HL); m_HL = value; }
        }
        /// <summary>
        /// 工程量
        /// </summary>
        [ModifyAttribute("GCL", "GCL", "工程量")]
        public virtual decimal GCL
        {
            get { return m_GCL; }
            set { this.ModifyAttribute("GCL", value, m_GCL); m_GCL = value; }
        }
        /// <summary>
        /// 直接调价
        /// </summary>
        [ModifyAttribute("ZJTJ", "ZJTJ", "直接调价")]
        public virtual decimal ZJTJ
        {
            get { return m_ZJTJ; }
            set { this.ModifyAttribute("ZJTJ", value, m_ZJTJ); m_ZJTJ = value; }
        }
        /// <summary>
        /// 综合单价
        /// </summary>
        public virtual decimal ZHDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZHDJ); }
            set { m_ZHDJ = value; }
        }
        /// <summary>
        /// 综合合价
        /// </summary>
        public virtual decimal ZHHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ); }
            set { m_ZHHJ = value; }
        }
        /// <summary>
        /// 直接费单价
        /// </summary>
        public virtual decimal ZJFDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZJFDJ); }
            set { m_ZJFDJ = value; }
        }
        /// <summary>
        /// 人工费单价
        /// </summary>
        public virtual decimal RGFDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_RGFDJ); }
            set { m_RGFDJ = value; }
        }
        /// <summary>
        /// 材料费单价
        /// </summary>
        public virtual decimal CLFDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_CLFDJ); }
            set { m_CLFDJ = value; }
        }
        /// <summary>
        /// 机械费单价
        /// </summary>
        public virtual decimal JXFDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ); }
            set { m_JXFDJ = value; }
        }
        /// <summary>
        /// 主材费单价
        /// </summary>
        public virtual decimal ZCFDJ
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZCFDJ); }
            set { m_ZCFDJ = value; }
        }
        /// <summary>
        /// 设备费单价
        /// </summary>
        public virtual decimal SBFDJ
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ); }
            set { m_SBFDJ = value; }
        }
        /// <summary>
        /// 管理费单价
        /// </summary>
        public virtual  decimal GLFDJ
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_GLFDJ); }
            set { m_GLFDJ = value; }
        }
        /// <summary>
        /// 利润单价
        /// </summary>
        public virtual decimal LRDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_LRDJ); }
            set { m_LRDJ = value; }
        }
        /// <summary>
        /// 风险单价
        /// </summary>
        public virtual decimal FXDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FXDJ); }
            set { m_FXDJ = value; }
        }


        /// <summary>
        /// 规费单价
        /// </summary>
        public virtual decimal GFDJ
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_GFDJ); }
            set { m_GFDJ = value; }
        }
        /// <summary>
        /// 税金单价
        /// </summary>
        public virtual decimal SJDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_SJDJ); }
            set { m_SJDJ = value; }
        }
        /// <summary>
        /// 差价单价
        /// </summary>
        public virtual decimal CJDJ
        {
             get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_CJDJ); }
            set { m_CJDJ = value; }
        }
        /// <summary>
        /// 价差单价
        /// </summary>
        public virtual decimal JCDJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JCDJ); }
            set { m_JCDJ = value; }
        }

        /// <summary>
        /// 定额材机
        /// </summary>
        public virtual string DECJ
        {
            get { return m_DECJ; }
            set { m_DECJ = value; }
        }

        /// <summary>
        /// 界面显示的清单序号
        /// </summary>
        public string FXH
        {
            get {
                if (this.XH==0)return "";
                return this.XH.ToString(); }
            set
            {
                int m = 0;
                int.TryParse(value, out m);
                this.XH = m;
            }
        }
        /// <summary>
        /// 消耗量
        /// </summary>        
        public decimal XHL
        {
            get { return m_XHL; }
            set { m_XHL = value; }
        }
        #endregion

        #region ---------------------------计算类属性--------------------------
        /// <summary>
        /// 直接费合价
        /// </summary>
        public virtual decimal ZJFHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZJFHJ); }
            set { m_ZJFHJ = value; }
        }
        /// <summary>
        /// 人工费合价
        /// </summary>
        public virtual decimal RGFHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_RGFHJ); }
            set { m_RGFHJ = value; }
        }
        /// <summary>
        /// 材料费合价
        /// </summary>
        public virtual decimal CLFHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_CLFHJ); }
            set { m_CLFHJ = value; }
        }
        /// <summary>
        /// 机械费合价
        /// </summary>
        public virtual decimal JXFHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JXFHJ); }
            set { m_JXFHJ = value; }
        }
        /// <summary>
        /// 主材费合价
        /// </summary>
        public virtual decimal ZCFHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZCFHJ); }
            set { m_ZCFHJ = value; }
        }
        /// <summary>
        /// 设备费合价
        /// </summary>
        public virtual decimal SBFHJ
        {
             get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_SBFHJ); }
            set { m_SBFHJ = value; }
        }
        /// <summary>
        /// 管理费合价
        /// </summary>
        public virtual decimal GLFHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_GLFHJ); }
            set { m_GLFHJ = value; }
        }
        /// <summary>
        /// 利润合价
        /// </summary>
        public virtual  decimal LRHJ
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_LRHJ); }
            set { m_LRHJ = value; }
        }
        /// <summary>
        /// 风险合价
        /// </summary>
        public virtual decimal FXHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FXHJ); }
            set { m_FXHJ = value; }
        }
        /// <summary>
        /// 规费合价
        /// </summary>
        public virtual decimal GFHJ
        {
             get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_GFHJ); }
            set { m_GFHJ = value; }
        }
        /// <summary>
        /// 税金合价
        /// </summary>
        public virtual decimal SJHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_SJHJ); }
            set { m_SJHJ = value; }
        }
        /// <summary>
        /// 价差合计
        /// </summary>
        public virtual decimal JCHJ
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXJCHJ); }
            set { m_JCHJ = value; }
        }
        /// <summary>
        /// 差价合计
        /// </summary>
        public virtual decimal CJHJ
        {
            get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXCJHJ); }
            set { m_CJHJ = value; }
        }
        /// <summary>
        /// 暂估金额
        /// </summary>
        public virtual  decimal ZGJE
        {
           get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZGHJ); }
            set { 
                m_ZGJE = value;
               
            }
        }
        /// <summary>
        /// 甲供金额
        /// </summary>
        public virtual decimal JGJE
        {
             get { return this.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JGJEHJ); }
            set {
                m_JGJE = value;
               
            }
        }

        /// <summary>
        /// 分包金额
        /// </summary>
        public virtual decimal FBJE
        {
          get { return this.m_FBJE; }
            set {

                m_FBJE = value;
               
            }
        }


        private string m_JSJC;
        /// <summary>
        /// 计算基础
        /// </summary>
        public virtual string JSJC
        {
            get { return m_JSJC; }
            set { m_JSJC = value; }
        }
        private string m_FL;
        /// <summary>
        /// 费率
        /// </summary>
        public virtual string FL
        {
            get { return m_FL; }
            set { m_FL = value; }
        }

        private string m_ZJFS;
        /// <summary>
        /// 组价方式
        /// </summary>
        public virtual string ZJFS
        {
            get { return m_ZJFS; }
            set { m_ZJFS = value; }
        }


        private string m_QDBH;
        /// <summary>
        /// 获取或设置：清单编号
        /// </summary>
        public string QDBH
        {
            get { return m_QDBH; }
            set
            {
                m_QDBH = value;

            }
        }
        /// <summary>
        /// 项目内容
        /// </summary>
        public string XMNR
        {
            get { return m_XMNR; }
            set { m_XMNR = value; }
        }

       /// <summary>
       /// 项目特征值
       /// </summary>
        public string XMTZZ
        {
            get { return m_XMTZZ; }
            set { m_XMTZZ = value; }
        }

        [NonSerialized]
        private long m_Key, m_PKey;
        public virtual long Key
        {
            get
            {
                return this.m_Key;
            }
            set
            {
                this.m_Key = value;
            }
        }

        public virtual long PKey
        {
            get
            {
                return this.m_PKey;
            }
            set
            {
                this.m_PKey = value;
            }
        }

        public virtual string ProName
        {
            get
            {
                return "分部分项基础对象";
            }
            set { }
        }
        /// <summary>
        /// 是否用系数换算
        /// </summary>
        public bool ISXSHS
        {
            get { return m_ISXSHS; }
            set { m_ISXSHS = value; }
        }


        /// <summary>
        /// 专业类别
        /// </summary>
        public string ZYLB
        {
            get { return m_ZYLB; }
            set { m_ZYLB = value; }
        }
        #endregion
       


        #region ICloneable 成员

        public object Clone()
        {
            return (_ObjectInfo)Activator.CreateInstance(this.GetType()); 
        }
        public virtual object Copy()
        {
            using (MemoryStream ms = new MemoryStream())
            {

                object CloneObject;
                BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                // 反序列化至另一个对象(即创建了一个原对象的深表副本)
                CloneObject = bf.Deserialize(ms);
                // 关闭流
                ms.Flush();
                ms.Close();
                return CloneObject;
            }
        }

        public virtual void Remove(_ObjectInfo info)
        { 
            
        }
        #endregion

        #region IDataSerializable 成员

        public virtual void OutSerializable()
        {
            
        }

        public virtual void InSerializable(object e)
        {
            
        }

        /// <summary>
        /// 当前模块发生变化时候激发
        /// </summary>
        /// 
        [field: NonSerializedAttribute()]
        public event ModelEditedHandler ModelEdited;

        /// <summary>
        /// 编辑之后（增加 删除 单位工程 单项工程）
        /// </summary>
        public virtual void OnModelEdited(object sender, object args)
        {
            if (ModelEdited != null)
            {
                this.ModelEdited(sender, args);
            }
        }
        [field: NonSerializedAttribute()]
        public event ModelActioinHandler ModelActioin;
        /// <summary>
        /// 编辑动作（增加 删除）
        /// </summary>
        public virtual void OnModelActioin(object sender, object args)
        {
            if (ModelActioin != null)
            {
                this.ModelActioin(sender, args);
            }
        }

        /// <summary>
        /// 开始编辑当前工料机对象
        /// </summary>
        /*public virtual void BeginModify()
        {
            //通知当前对象改变
            
        }*/

        /// <summary>
        /// 结束编辑当前工料机对象
        /// </summary>
        /*public virtual void EndModify()
        {
            //通知当前对象改变
        }*/

        /// <summary>
        /// 设置上下级对象状态
        /// </summary>
        /// <param name="p_EObjectState"></param>
        /*public virtual void SetModify(EObjectState p_EObjectState, EDirection p_EDirection)
        {
            
            
        }*/

        /// <summary>
        /// 指定方法被调用需要记录的时候
        /// </summary>
        /// <param name="MethodName">方法名</param>
        /// <param name="p_OtherName">别名</param>
        public virtual void ActionAttribute(string MethodName, string p_OtherName, object p_Source, object p_TagValue)
        {
            ///Create方法此处收集
            //if (UseAttribute == EObjectState.Appending)
            {
                //找到指定方法操作属性
                ActionAttribute myAttribute = Command.GetMethodAttribute(this, MethodName, p_OtherName);
                if (myAttribute != null)
                {
                    myAttribute.ObjectName = (p_Source as _ObjectInfo).XMMC;
                    myAttribute.Source = p_Source;
                    myAttribute.TagValue = p_TagValue;
                    this.OnModelActioin(this, myAttribute);
                }
            }
        }

        /// <summary>
        /// 指定属性需要记录对象时候调用
        /// </summary>
        /// <param name="value"></param>
        public virtual void ModifyAttribute(string PropertyName, object value, object OriginalValue)
        {
            //单位工程为空或者单位工程没有调用BeginModify方法不会发出请求操作
            
            if (this.Activitie == null) return;
            if (this.Activitie.ModfitingObject == null) return;
            if (this.Activitie.ModfitingObject.Current == null) return;
            if (this.Activitie.ModfitingObject.FiledName != string.Empty)
            {
                if (this.Activitie.ModfitingObject.FiledName != PropertyName) return;
            }
            if (this == this.Activitie.ModfitingObject.Current)
            {

                Type tp = this.GetType();
                MemberInfo info = tp.GetProperty(PropertyName);
                ModifyAttribute myAttribute = Attribute.GetCustomAttribute(info, typeof(ModifyAttribute)) as ModifyAttribute;
                if (myAttribute != null)
                {
                    myAttribute.CurrentValue = value;
                    myAttribute.OriginalValue = OriginalValue;
                    myAttribute.ObjectName = this.XMMC;
                    myAttribute.Source = this;
                    myAttribute.ActingOn = "清单.子目";
                    //是否通知
                    //正在编辑的对象和当前对象是一个实例则返回
                    this.OnModelEdited(this, myAttribute);
                }
            }
        }

        #endregion
    }
}
