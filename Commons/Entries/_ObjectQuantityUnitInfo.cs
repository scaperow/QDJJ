using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using ZiboSoft.Commons.Common;
using System.Reflection;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 工料机基类
    /// </summary>
    [Serializable]
    public class _ObjectQuantityUnitInfo : _BaseObject
    {
        
        #region 构造
        /// <summary>
        /// 创建新的工料机
        /// </summary>
        public _ObjectQuantityUnitInfo() { }

        public _UserPriceLibrary UserPriceLibrary
        {
            get { return null; } // this.Activitie.Application.UserPriceLibrary; }
        }

        #endregion

        #region----------------------字段常量定义---------------------------------
        /// <summary>
        /// 编号
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        /// 父级编号
        /// </summary>
        public const string FILED_PID = "PID";
        /// <summary>
        /// 原始工料机编号
        /// </summary>
        public const string FILED_YSBH = "YSBH";
        /// <summary>
        /// 原始名称
        /// </summary>
        public const string FILED_YSMC = "YSMC";
        /// <summary>
        /// 原始单位
        /// </summary>
        public const string FILED_YSDW = "YSDW";
        /// <summary>
        /// 原始消耗量
        /// </summary>
        public const string FILED_YSXHL = "YSXHL";
        /// <summary>
        /// 工料机编号
        /// </summary>
        public const string FILED_BH = "BH";
        /// <summary>
        /// 名称
        /// </summary>
        public const string FILED_MC = "MC";
        /// <summary>
        /// 单位
        /// </summary>
        public const string FILED_DW = "DW";
        /// <summary>
        /// 定额单价
        /// </summary>
        public const string FILED_DEDJ = "DEDJ";
        /// <summary>
        /// 定额合价
        /// </summary>
        public const string FILED_DEHJ = "DEHJ";
        /// <summary>
        /// 市场单价
        /// </summary>
        public const string FILED_SCDJ = "SCDJ";
        /// <summary>
        /// 市场合价
        /// </summary>
        public const string FILED_SCHJ = "SCHJ";
        /// <summary>
        /// 单价差
        /// </summary>
        public const string FILED_DJC = "DJC";
        /// <summary>
        /// 结算单价
        /// </summary>
        public const string FILED_JSDJ = "JSDJ";
        /// <summary>
        /// 结算单价差
        /// </summary>
        public const string FILED_JSDJC = "JSDJC";
        /// <summary>
        /// 消耗量
        /// </summary>
        public const string FILED_XHL = "XHL";
        /// <summary>
        /// 数量
        /// </summary>
        public const string FILED_SL = "SL";
        /// <summary>
        /// 工程量 
        /// </summary>
        public const string FILED_GCL = "GCL";
        /// <summary>
        /// 类别
        /// </summary>
        public const string FILED_LB = "LB";
        /// <summary>
        /// 是否主要材料
        /// </summary>
        public const string FILED_IFZYCL = "IFZYCL";
        /// <summary>
        /// 组成类别
        /// </summary>
        public const string FILED_ZCLB = "ZCLB";
        /// <summary>
        /// 规格及型号
        /// </summary>
        public const string FILED_GGXH = "GGXH";
        /// <summary>
        /// 三大材类别
        /// </summary>
        public const string FILED_SDCLB = "SDCLB";
        /// <summary>
        /// 三大材系数
        /// </summary>
        public const string FILED_SDCXS = "SDCXS";
        /// <summary>
        /// 用途类别
        /// </summary>
        public const string FILED_YTLB = "YTLB";
        /// <summary>
        /// 是否选择
        /// </summary>
        public const string FILED_IFXZ = "IFXZ";
        /// <summary>
        /// 是否输出
        /// </summary>
        public const string FILED_IFSC = "IFSC";
        /// <summary>
        /// 是否风险
        /// </summary>
        public const string FILED_IFFX = "IFFX";
        /// <summary>
        /// 是否锁定市场单价
        /// </summary>
        public const string FILED_IFSDSCDJ = "IFSDSCDJ";
        /// <summary>
        /// 是否锁定数量
        /// </summary>
        public const string FILED_IFSDSL = "IFSDSL";
        /// <summary>
        /// 是否可分解
        /// </summary>
        public const string FILED_IFKFJ = "IFKFJ";
        /// <summary>
        /// 所属库类别
        /// </summary>
        public const string FILED_SSKLB = "SSKLB";
        /// <summary>
        /// 所属单位工程类别
        /// </summary>
        public const string FILED_SSDWGCLB = "SSDWGCLB";
        ///  <summary>
        /// 所属单位工程
        /// </summary>
        public const string FILED_SSDWGC = "SSDWGC";
        /// <summary>
        /// 工料机备注
        /// </summary>
        public const string FILED_GLJBZ = "GLJBZ";
        /// <summary>
        /// 创建时间
        /// </summary>
        public const string FILED_CTIME = "CTIME";
        /// <summary>
        /// 状态
        /// </summary>
        public const string FILED_STATUS = "STATUS";

        /// <summary>
        /// 数量合
        /// </summary>
        public const string FILED_SLH = "SLH";
        /// <summary>
        /// 定额合价
        /// </summary>
        public const string FILED_SLDEHJ = "SLDEHJ";
        /// <summary>
        /// 市场合价
        /// </summary>
        public const string FILED_SLSCHJ = "SLSCHJ";
        /// <summary>
        /// 结算合价差
        /// </summary>
        public const string FILED_JSHJC = "JSHJC";
        /// <summary>
        /// 合价差
        /// </summary>
        public const string FILED_HJC = "HJC";
        /// <summary>
        /// 三大材和价
        /// </summary>
        public const string FILED_SDCHJ = "SDCHJ";
        /// <summary>
        /// 厂家
        /// </summary>
        public const string FILED_CJ = "CJ";
        /// <summary>
        /// 品牌
        /// </summary>
        public const string FILED_PP = "PP";
        /// <summary>
        /// 质量等级
        /// </summary>
        public const string FILED_ZLDJ = "ZLDJ";
        /// <summary>
        /// 供应商
        /// </summary>
        public const string FILED_GYS = "GYS";
        /// <summary>
        /// 产地
        /// </summary>
        public const string FILED_CD = "CD";
        /// <summary>
        /// 厂家备注
        /// </summary>
        public const string FILED_CJBZ = "CJBZ";
        /// <summary>
        /// 修改后市场单价
        /// </summary>
        public const string FILED_XGHSCDJ = "XGHSCDJ";
        /// <summary>
        /// 调整系数
        /// </summary>
        public const string FILED_TZXS = "TZXS";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        /// 编号
        /// </summary>
        private int m_ID;
        /// <summary>
        /// 父级编号
        /// </summary>
        private int m_PID;
        ///  <summary>
        ///原始工料机编号
        /// </summary>
        private string m_YSBH = string.Empty;
        /// <summary>
        /// 原始名称
        /// </summary>
        private string m_YSMC = string.Empty;
        /// <summary>
        /// 原始单位
        /// </summary>
        private string m_YSDW = string.Empty;
        /// <summary>
        /// 原始消耗量
        /// </summary>
        private decimal m_YSXHL;
        /// <summary>
        /// 工料机编号
        /// </summary>
        private string m_BH = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        private string m_MC = string.Empty;
        /// <summary>
        /// 单位
        /// </summary>
        private string m_DW = string.Empty;
        /// <summary>
        /// 市场单价
        /// </summary>
        private decimal m_SCDJ;
        /// <summary>
        /// 市场合价
        /// </summary>
        private decimal m_SCHJ;
        /// <summary>
        /// 定额单价
        /// </summary>
        private decimal m_DEDJ;
        /// <summary>
        /// 定额合价
        /// </summary>
        private decimal m_DEHJ;
        /// <summary>
        /// 单价差
        /// </summary>
        private decimal m_DJC;
        /// <summary>
        /// 结算单价
        /// </summary>
        private decimal m_JSDJ;
        /// <summary>
        /// 结算单价差
        /// </summary>
        private decimal m_JSDJC;
        /// <summary>
        /// 消耗量
        /// </summary>
        private decimal m_XHL;
        /// <summary>
        /// 数量
        /// </summary>
        private decimal m_SL;
        /// <summary>
        /// 工程量
        /// </summary>
        private decimal m_GCL;
        /// <summary>
        /// 类别
        /// </summary>
        private string m_LB = string.Empty;
        /// <summary>
        /// 是否主要材料
        /// </summary>
        private bool m_IFZYCL;
        /// <summary>
        /// 组成类别
        /// </summary>
        private string m_ZCLB = string.Empty;
        /// <summary>
        /// 规格及型号
        /// </summary>
        private string m_GGXH = string.Empty;
        /// <summary>
        /// 三大材类别
        /// </summary>
        private string m_SDCLB = string.Empty;
        /// <summary>
        /// 三大材系数
        /// </summary>
        private decimal m_SDCXS;
        /// <summary>
        /// 用途类别
        /// </summary>
        private string m_YTLB = string.Empty;
        /// <summary>
        /// 是否选择
        /// </summary>
        private bool m_IFXZ;
        /// <summary>
        /// 是否输出
        /// </summary>
        private bool m_IFSC;
        /// <summary>
        /// 是否风险
        /// </summary>
        private bool m_IFFX;
        /// <summary>
        /// 是否锁定市场单价
        /// </summary>
        private bool m_IFSDSCDJ;
        /// <summary>
        /// 是否锁定数量
        /// </summary>
        private bool m_IFSDSL;
        /// <summary>
        /// 是否可分解
        /// </summary>
        private bool m_IFKFJ;
        /// <summary>
        /// 所属库类别
        /// </summary>
        private string m_SSKLB = string.Empty;
        /// <summary>
        /// 所属单位工程类别
        /// </summary>
        private string m_SSDWGCLB = string.Empty;
        /// <summary>
        /// 所属单位工程
        /// </summary>
        private string m_SSDWGC = string.Empty;
        /// <summary>
        /// 工料机备注
        /// </summary>
        private string m_GLJBZ = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime m_CTIME = DateTime.Now;
        /// <summary>
        /// 对象状态
        /// </summary>
        private Status m_STATUS = Status.Normal;


        /// <summary>
        /// 数量合
        /// </summary>
        private decimal m_SLH;
        /// <summary>
        /// 定额合价
        /// </summary>
        private decimal m_SLDEHJ;
        /// <summary>
        /// 市场合价
        /// </summary>
        private decimal m_SLSCHJ;
        /// <summary>
        /// 结算合价差
        /// </summary>
        private decimal m_JSHJC;
        /// <summary>
        /// 合价差
        /// </summary>
        private decimal m_HJC;
        /// <summary>
        /// 三大材和价
        /// </summary>
        private decimal m_SDCHJ;
        /// <summary>
        /// 厂家
        /// </summary>
        private string m_CJ = string.Empty;
        /// <summary>
        /// 品牌
        /// </summary>
        private string m_PP = string.Empty;
        /// <summary>
        /// 质量等级
        /// </summary>
        private string m_ZLDJ = string.Empty;
        /// <summary>
        /// 供应商
        /// </summary>
        private string m_GYS = string.Empty;
        /// <summary>
        /// 产地
        /// </summary>
        private string m_CD = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        private string m_CJBZ = string.Empty;
        /// <summary>
        /// 修改后市场单价
        /// </summary>
        private decimal m_XGHSCDJ;
        /// <summary>
        /// 调整系数
        /// </summary>
        private decimal m_TZXS;
        #endregion

        #region----------------------公有成员定义---------------------------------
        /// <summary>
        /// 获取或设置：编号
        /// </summary>
        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        /// <summary>
        /// 获取或设置：父级编号
        /// </summary>
        public int PID
        {
            get { return m_PID; }
            set { m_PID = value; }
        }
        /// <summary>
        /// 获取或设置：原始工料机编号
        /// </summary>
        public string YSBH
        {
            get { return m_YSBH; }
            set { m_YSBH = value; }
        }
        /// <summary>
        /// 获取或设置：原始名称
        /// </summary>
        public string YSMC
        {
            get { return m_YSMC; }
            set { m_YSMC = value; }
        }
        /// <summary>
        /// 获取或设置：原始单位
        /// </summary>
        public string YSDW
        {
            get { return m_YSDW; }
            set { m_YSDW = value; }
        }
        /// <summary>
        /// 获取或设置：原始消耗量
        /// </summary>
        public decimal YSXHL
        {
            get { return m_YSXHL; }
            set { m_YSXHL = value; }
        }
        /// <summary>
        /// 获取或设置：工料机编号
        /// </summary>
        public string BH
        {
            get { return m_BH; }
            set { m_BH = value; }
        }
        /// <summary>
        /// 获取或设置：名称
        /// </summary>
        [Modify("MC", "MC", "名称")]
        public virtual string MC
        {
            get { return m_MC; }
            set
            { //通知属性修改(每次都通知)
                this.ModifyAttribute("MC", value, m_MC); 
                m_MC = value;
            }
        }
        /// <summary>
        /// 获取或设置：单位
        /// </summary>
        [Modify("DW", "DW", "单位")]
        public virtual string DW
        {
            get { return m_DW; }
            set {
                    //通知属性修改
                    this.ModifyAttribute("DW", value, m_DW);
                    m_DW = value; 
                }
        }
        /// <summary>
        /// 获取或设置：定额单价
        /// </summary>
        public decimal DEDJ
        {
            get { return m_DEDJ; }
            set
            {
                m_DEDJ = value;
                CalculateDEHJ();
            }
        }
        /// <summary>
        /// 获取或设置：定额和价
        /// </summary>
        public virtual decimal DEHJ
        {
            get { return m_DEHJ; }
            set { m_DEHJ = value; }
        }
        /// <summary>
        /// 获取或设置：市场单价
        /// </summary>
        [Modify("SCDJ", "SCDJ", "市场单价")]
        public virtual decimal SCDJ
        {
            get { return m_SCDJ; }
            set
            {
                //通知属性修改
                this.ModifyAttribute("SCDJ", value, m_SCDJ);
                m_SCDJ = CDataConvert.ConToValue<System.Decimal>(value.ToString("N2"));
                CalculateDJC();
                CalculateJSDJC();
                CalculateSDCHJ();
                CalculateSCHJ();
                CalculateSLSCHJ();
            }
        }
        /// <summary>
        /// 获取或设置：市场和价
        /// </summary>
        public virtual decimal SCHJ
        {
            get { return m_SCHJ; }
            set { m_SCHJ = value; }
        }
        /// <summary>
        /// 获取或设置：单价差
        /// </summary>
        public virtual decimal DJC
        {
            get { return m_DJC; }
            set 
            { 
                m_DJC = value;
                CalculateHJC();
            }
        }
        /// <summary>
        /// 获取或设置：结算单价
        /// </summary>
        public virtual decimal JSDJ
        {
            get { return m_JSDJ; }
            set 
            { 
                m_JSDJ = value;
                CalculateJSDJC();
            }
        }
        /// <summary>
        /// 获取或设置：结算单价差
        /// </summary>
        public decimal JSDJC
        {
            get { return m_JSDJC; }
            set 
            {
                m_JSDJC = value;
                CalculateJSHJC();
            }
        }
        /// <summary>
        /// 获取或设置：消耗量
        /// </summary>
        [ModifyAttribute("XHL", "XHL", "消耗量")]
        public virtual decimal XHL
        {
            get { return m_XHL; }
            set
            {
                this.ModifyAttribute("XHL", value, m_XHL);
                m_XHL = CDataConvert.ConToValue<System.Decimal>(value.ToString("F4"));
                CalculateSL();
                CalculateDEHJ();
                CalculateSCHJ();
            }
        }
        /// <summary>
        /// 获取或设置：数量
        /// </summary>
        public virtual decimal SL
        {
            get { return m_SL; }
            set 
            {
                m_SL = CDataConvert.ConToValue<System.Decimal>(value.ToString("F4"));
                m_SLH = value;
            }
        }
        /// <summary>
        /// 获取或设置：工程量
        /// </summary>
        public virtual decimal GCL
        {
            get { return m_GCL; }
            set
            {
                m_GCL = value;
                if (this.IFSDSL)
                {
                    CalculateXHLBySD();
                }
                else
                {
                    CalculateSL();
                }
            }
        }
        /// <summary>
        /// 获取或设置：类别
        /// </summary>
        public string LB
        {
            get { return m_LB; }
            set { m_LB = value; }
        }
        /// <summary>
        /// 获取或设置：是否主要材料
        /// </summary>
        public virtual bool IFZYCL
        {
            get { return m_IFZYCL; }
            set { m_IFZYCL = value; }
        }
        /// <summary>
        /// 获取或设置：组成类别
        /// </summary>
        public string ZCLB
        {
            get { return m_ZCLB; }
            set { m_ZCLB = value; }
        }
        /// <summary>
        /// 获取或设置：规格及型号
        /// </summary>
        [Modify("GGXH","GGXH","规格及型号")]
        public virtual string GGXH
        {
            get { return m_GGXH; }
            set {
                    this.ModifyAttribute("GGXH", value, m_GGXH);
                    m_GGXH = value; 
                }
        }
        /// <summary>
        /// 获取或设置：三大材类别
        /// </summary>
        public string SDCLB
        {
            get { return m_SDCLB; }
            set { m_SDCLB = value; }
        }
        /// <summary>
        /// 获取或设置：三大材系数
        /// </summary>
        public decimal SDCXS
        {
            get { return m_SDCXS; }
            set { m_SDCXS = value; }
        }
        /// <summary>
        /// 获取或设置：用途类别
        /// </summary>
        public virtual string YTLB
        {
            get { return m_YTLB; }
            set { m_YTLB = value; }
        }
        /// <summary>
        /// 获取或设置：是否选择
        /// </summary>
        public bool IFXZ
        {
            get { return m_IFXZ; }
            set { m_IFXZ = value; }
        }
        /// <summary>
        /// 获取或设置：是否输出
        /// </summary>
        public virtual bool IFSC
        {
            get { return m_IFSC; }
            set { m_IFSC = value; }
        }
        /// <summary>
        /// 获取或设置：是否风险
        /// </summary>
        public virtual bool IFFX
        {
            get { return m_IFFX; }
            set { m_IFFX = value; }
        }
        /// <summary>
        /// 获取或设置：是否锁定市场单价
        /// </summary>
        public virtual bool IFSDSCDJ
        {
            get { return m_IFSDSCDJ; }
            set  {m_IFSDSCDJ = value;  }
        }
        /// <summary>
        /// 获取或设置：是否锁定数量
        /// </summary>
        public virtual bool IFSDSL
        {
            get { return m_IFSDSL; }
            set { m_IFSDSL = value; }
        }
        /// <summary>
        /// 获取或设置：是否可分解
        /// </summary>
        public bool IFKFJ
        {
            get { return m_IFKFJ; }
            set { m_IFKFJ = value; }
        }
        /// <summary>
        /// 获取或设置：所属库类型
        /// </summary>
        public string SSKLB
        {
            get { return m_SSKLB; }
            set { m_SSKLB = value; }
        }
        /// <summary>
        /// 获取或设置：所属单位工程类别
        /// </summary>
        public string SSDWGCLB
        {
            get { return m_SSDWGCLB; }
            set { m_SSDWGCLB = value; }
        }
        /// <summary>
        /// 获取或设置：所属单位工程
        /// </summary>
        public string SSDWGC
        {
            get { return m_SSDWGC; }
            set { m_SSDWGC = value; }
        }
        /// <summary>
        /// 获取或设置：工料机备注
        /// </summary>
        [ModifyAttribute("GLJBZ", "GLJBZ", "工料机备注")]
        public virtual string GLJBZ
        {
            get { return m_GLJBZ; }
            set {
                    this.ModifyAttribute("GLJBZ", value, m_GLJBZ);
                    m_GLJBZ = value; 
                }
        }
        /// <summary>
        /// 获取或设置：创建时间
        /// </summary>
        public DateTime CTIME
        {
            get { return m_CTIME; }
            set { m_CTIME = value; }
        }
        /// <summary>
        /// 获取或设置：对象状态
        /// </summary>
        public virtual Status STATUS
        {
            get { return m_STATUS; }
            set { m_STATUS = value; }
        }

        /// <summary>
        /// 获取或设置：数量合
        /// </summary>
        public virtual decimal SLH
        {
            get { return m_SLH; }
            set 
            { 
                m_SLH = value;
                CalculateSLDEHJ();
                CalculateSLSCHJ();
                CalculateHJC();
                CalculateJSHJC();
                CalculateSDCHJ();
            }
        }
        /// <summary>
        /// 获取或设置：定额和价
        /// </summary>
        public virtual decimal SLDEHJ
        {
            get { return m_SLDEHJ; }
            set { m_SLDEHJ = value; }
        }
        /// <summary>
        /// 获取或设置：市场和价
        /// </summary>
        public virtual decimal SLSCHJ
        {
            get { return m_SLSCHJ; }
            set { m_SLSCHJ = value; }
        }
        /// <summary>
        /// 获取或设置：合价差
        /// </summary>
        public virtual decimal HJC
        {
            get { return m_HJC; }
            set { m_HJC = value; }
        }
        /// <summary>
        /// 获取或设置：结算合价差
        /// </summary>
        public decimal JSHJC
        {
            get { return m_JSHJC; }
            set { m_JSHJC = value; }
        }
        /// <summary>
        /// 获取或设置：三大材和价
        /// </summary>
        public decimal SDCHJ
        {
            get { return m_SDCHJ; }
            set { m_SDCHJ = value; }
        }
        /// <summary>
        /// 获取或设置：厂家
        /// </summary>
        public virtual string CJ
        {
            get { return m_CJ; }
            set { m_CJ = value; }
        }
        /// <summary>
        /// 获取或设置：品牌
        /// </summary>
        public virtual string PP
        {
            get { return m_PP; }
            set { m_PP = value; }
        }
        /// <summary>
        /// 获取或设置：质量等级
        /// </summary>
        public virtual string ZLDJ
        {
            get { return m_ZLDJ; }
            set { m_ZLDJ = value; }
        }
        /// <summary>
        /// 获取或设置：供应商
        /// </summary>
        public virtual string GYS
        {
            get { return m_GYS; }
            set { m_GYS = value; }
        }
        /// <summary>
        /// 获取或设置：产地
        /// </summary>
        public virtual string CD
        {
            get { return m_CD; }
            set { m_CD = value; }
        }
        /// <summary>
        /// 获取或设置：备注
        /// </summary>
        public virtual string CJBZ
        {
            get { return m_CJBZ; }
            set { m_CJBZ = value; }
        }
        /// <summary>
        /// 获取或设置：修改后市场单价
        /// </summary>
        public decimal XGHSCDJ
        {
            get { return m_XGHSCDJ; }
            set
            {
                m_XGHSCDJ = CDataConvert.ConToValue<System.Decimal>(value.ToString("N3"));
            }
        }
        /// <summary>
        /// 获取或设置：调整系数
        /// </summary>
        public decimal TZXS
        {
            get { return m_TZXS; }
            set { m_TZXS = value; }
        }

        /// <summary>
        /// 计算锁定后的 消耗量
        /// </summary>
        private void CalculateXHLBySD()
        {
            XHL = SL / GCL;
        }

        /// <summary>
        /// 计算定额和价
        /// </summary>
        public virtual void CalculateDEHJ()
        {
            DEHJ = (DEDJ * XHL);
        }
        /// <summary>
        /// 计算市场和价
        /// </summary>
        public virtual void CalculateSCHJ()
        {
            SCHJ = (SCDJ * XHL);
        }
        /// <summary>
        /// 计算市场和价（数量合）
        /// </summary>
        public virtual void CalculateSLSCHJ()
        {
            SLSCHJ = (SCDJ * SLH);
        }
        /// <summary>
        /// 计算定额和价（数量合）
        /// </summary>
        public virtual void CalculateSLDEHJ()
        {
            SLDEHJ = (DEDJ * SLH);
        }
        /// <summary>
        /// 计算数量
        /// </summary>
        public virtual void CalculateSL()
        {
            SL = (XHL * GCL);
        }
        /// <summary>
        /// 计算单价差
        /// </summary>
        public virtual void CalculateDJC()
        {
            DJC = (SCDJ - DEDJ);
        }
        /// <summary>
        /// 计算合价差
        /// </summary>
        public virtual void CalculateHJC()
        {
            HJC = (DJC * SLH);
        }
        /// <summary>
        /// 计算结算单价差
        /// </summary>
        public virtual void CalculateJSDJC()
        {
            if (JSDJ == 0)
            {
                JSDJC = 0;
            }
            else
            {
                JSDJC = (JSDJ - SCDJ);
            }
        }
        /// <summary>
        /// 计算结算合价差
        /// </summary>
        public virtual void CalculateJSHJC()
        {
            if (JSDJ == 0)
            {
                JSHJC = 0;
            }
            else
            {
                JSHJC = (JSDJC * SLH);
            }
        }
        /// <summary>
        /// 计算三大材合价
        /// </summary>
        public virtual void CalculateSDCHJ()
        {
            if (SDCLB != string.Empty)
            {
                SDCHJ = SCDJ * SLH;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns>新的对象根据需要在转型</returns>
        public object Copy()
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
                ms.Close();
                return CloneObject;
            }
        }
        #endregion


        /// <summary>
        /// 当前模块发生变化时候激发
        /// </summary>
        public event ModelEditedHandler ModelEdited;
        /// <summary>
        /// 编辑之后（仅修改）
        /// </summary>
        public virtual void OnModelEdited(object sender, object args)
        {
            if (ModelEdited != null)
            {
                this.ModelEdited(sender, args);
            }
            
        }

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


        #region ----------------------------------编辑操属性-----------------------------
        /// <summary>
        /// 通知当前对象即将发生修改变化
        /// </summary>
       /* public virtual void BeginModify()
        {
            
        }*/

        /// <summary>
        /// 通知当前对象即结束发生修改变化
        /// </summary>
        /*public virtual void EndModify()
        {
            
        }*/

        /// <summary>
        /// 设置上下级对象状态
        /// </summary>
        /// <param name="p_EObjectState"></param>
        /*public virtual void SetModify(EObjectState p_EObjectState, EDirection p_EDirection)
        {
 
        }*/
        /// <summary>
        /// 指定属性需要记录对象时候调用
        /// </summary>
        /// <param name="value"></param>
        public virtual void ModifyAttribute(string PropertyName, object value, object OriginalValue)
        {

        }

        /// <summary>
        /// 指定方法被调用需要记录的时候
        /// </summary>
        /// <param name="MethodName">方法名</param>
        /// <param name="p_OtherName">别名</param>
        public virtual void ActionAttribute(string MethodName,string p_OtherName,object p_Source,object p_TagValue)
        {

        }

        #endregion ----------------------------------编辑操属性-----------------------------
    }
}
