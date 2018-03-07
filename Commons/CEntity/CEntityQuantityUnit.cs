using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///工料机实体类
    /// </summary>
    [Serializable]
    public class CEntityQuantityUnit : CEntity
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "QUANTITYUNIT";
        /// <summary>
        ///编号
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        ///项目编号
        /// </summary>
        public const string FILED_XID = "XID";
        /// <summary>
        ///单项工程编号
        /// </summary>
        public const string FILED_DXID = "DXID";
        /// <summary>
        ///单位工程编号
        /// </summary>
        public const string FILED_DWID = "DWID";
        /// <summary>
        ///清单编号
        /// </summary>
        public const string FILED_QID = "QID";
        /// <summary>
        ///子目编号
        /// </summary>
        public const string FILED_ZID = "ZID";
        /// <summary>
        ///组成编号
        /// </summary>
        public const string FILED_ZCID = "ZCID";
        /// <summary>
        ///组成类别
        /// </summary>
        public const string FILED_ZCLB = "ZCLB";
        /// <summary>
        ///厂家信息编号
        /// </summary>
        public const string FILED_CJXXID = "CJXXID";
        /// <summary>
        ///原始工料机编号
        /// </summary>
        public const string FILED_YSBH = "YSBH";
        /// <summary>
        ///原始名称
        /// </summary>
        public const string FILED_YSMC = "YSMC";
        /// <summary>
        ///原始单位
        /// </summary>
        public const string FILED_YSDW = "YSDW";
        /// <summary>
        ///原始消耗量
        /// </summary>
        public const string FILED_YSXHL = "YSXHL";
        /// <summary>
        ///定额单价
        /// </summary>
        public const string FILED_DEDJ = "DEDJ";
        /// <summary>
        ///定额合价
        /// </summary>
        public const string FILED_DEHJ = "DEHJ";
        /// <summary>
        ///工料机编号
        /// </summary>
        public const string FILED_BH = "BH";
        /// <summary>
        ///类别
        /// </summary>
        public const string FILED_LB = "LB";
        /// <summary>
        ///三大材类别
        /// </summary>
        public const string FILED_SDCLB = "SDCLB";
        /// <summary>
        ///三大材系数
        /// </summary>
        public const string FILED_SDCXS = "SDCXS";
        /// <summary>
        ///三大材和价
        /// </summary>
        public const string FILED_SDCHJ = "SDCHJ";
        /// <summary>
        ///名称
        /// </summary>
        public const string FILED_MC = "MC";
        /// <summary>
        ///规格及型号
        /// </summary>
        public const string FILED_GGXH = "GGXH";
        /// <summary>
        ///单位
        /// </summary>
        public const string FILED_DW = "DW";
        /// <summary>
        ///市场单价
        /// </summary>
        public const string FILED_SCDJ = "SCDJ";
        /// <summary>
        ///市场合价
        /// </summary>
        public const string FILED_SCHJ = "SCHJ";
        /// <summary>
        ///消耗量
        /// </summary>
        public const string FILED_XHL = "XHL";
        /// <summary>
        ///工程量 
        /// </summary>
        public const string FILED_GCL = "GCL";
        /// <summary>
        /// 价差
        /// </summary>
        public const string FILED_JC = "JC";
        /// <summary>
        ///数量
        /// </summary>
        public const string FILED_SL = "SL";
        /// <summary>
        ///是否评标
        /// </summary>
        public const string FILED_IFPB = "IFPB";
        /// <summary>
        ///是否暂定
        /// </summary>
        public const string FILED_IFZG = "IFZG";
        /// <summary>
        ///是否甲供
        /// </summary>
        public const string FILED_IFJG = "IFJG";
        /// <summary>
        ///是否乙供
        /// </summary>
        public const string FILED_IFYG = "IFYG";
        /// <summary>
        ///是否风险
        /// </summary>
        public const string FILED_IFFX = "IFFX";
        /// <summary>
        ///是否锁定数量
        /// </summary>
        public const string FILED_IFSDSL = "IFSDSL";
        /// <summary>
        ///是否锁定市场价
        /// </summary>
        public const string FILED_IFSDSCDJ = "IFSDSCDJ";
        /// <summary>
        ///是否锁定工料机
        /// </summary>
        public const string FILED_IFSDGLJ = "IFSDGLJ";
        /// <summary>
        ///是否锁定消耗量
        /// </summary>
        public const string FILED_IFSDXHL = "IFSDXHL";
        /// <summary>
        ///所属库类别
        /// </summary>
        public const string FILED_SSKLB = "SSKLB";
        /// <summary>
        ///所属项目类别
        /// </summary>
        public const string FILED_SSXMLB = "SSXMLB";
        /// <summary>
        ///所属项目
        /// </summary>
        public const string FILED_SSXM = "SSXM";
        /// <summary>
        ///工料机备注
        /// </summary>
        public const string FILED_GLJBZ = "GLJBZ";
        /// <summary>
        ///增加次数
        /// </summary>
        public const string FILED_ZJCS = "ZJCS";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        ///编号
        /// </summary>
        private System.Int32 m_ID;
        /// <summary>
        ///项目编号
        /// </summary>
        private System.Int32 m_XID;
        /// <summary>
        ///单项工程编号
        /// </summary>
        private System.Int32 m_DXID;
        /// <summary>
        ///单位工程编号
        /// </summary>
        private System.Int32 m_DWID;
        /// <summary>
        ///清单编号
        /// </summary>
        private System.Int32 m_QID;
        /// <summary>
        ///子目编号
        /// </summary>
        private System.Int32 m_ZID;
        /// <summary>
        ///组成编号
        /// </summary>
        private System.Int32 m_ZCID;
        /// <summary>
        ///组成类别
        /// </summary>
        private System.String m_ZCLB;
        /// <summary>
        ///厂家信息编号
        /// </summary>
        private System.Int32 m_CJXXID;
        /// <summary>
        ///原始工料机编号
        /// </summary>
        private System.String m_YSBH = string.Empty;
        /// <summary>
        ///原始名称
        /// </summary>
        private System.String m_YSMC = string.Empty;
        /// <summary>
        ///原始单位
        /// </summary>
        private System.String m_YSDW = string.Empty;
        /// <summary>
        ///原始消耗量
        /// </summary>
        private System.Decimal m_YSXHL;
        /// <summary>
        ///定额单价
        /// </summary>
        private System.Decimal m_DEDJ;
        /// <summary>
        ///定额合价
        /// </summary>
        private System.Decimal m_DEHJ;
        /// <summary>
        ///工料机编号
        /// </summary>
        private System.String m_BH = string.Empty;
        /// <summary>
        ///类别
        /// </summary>
        private System.String m_LB = string.Empty;
        /// <summary>
        ///三大材类别
        /// </summary>
        private System.String m_SDCLB = string.Empty;
        /// <summary>
        ///三大材系数
        /// </summary>
        private System.Decimal m_SDCXS;
        /// <summary>
        ///三大材和价
        /// </summary>
        private System.Decimal m_SDCHJ;
        /// <summary>
        ///名称
        /// </summary>
        private System.String m_MC = string.Empty;
        /// <summary>
        ///规格及型号
        /// </summary>
        private System.String m_GGXH = string.Empty;
        /// <summary>
        ///单位
        /// </summary>
        private System.String m_DW = string.Empty;
        /// <summary>
        ///市场单价
        /// </summary>
        private System.Decimal m_SCDJ;
        /// <summary>
        ///市场合价
        /// </summary>
        private System.Decimal m_SCHJ;
        /// <summary>
        ///消耗量
        /// </summary>
        private System.Decimal m_XHL;
        /// <summary>
        ///工程量
        /// </summary>
        private System.Decimal m_GCL;
        /// <summary>
        /// 价差
        /// </summary>
        private System.Decimal m_JC;
        /// <summary>
        ///数量
        /// </summary>
        private System.Decimal m_SL;
        /// <summary>
        ///是否评标
        /// </summary>
        private System.Boolean m_IFPB;
        /// <summary>
        ///是否暂定
        /// </summary>
        private System.Boolean m_IFZG;
        /// <summary>
        ///是否甲供
        /// </summary>
        private System.Boolean m_IFJG;
        /// <summary>
        ///是否乙供
        /// </summary>
        private System.Boolean m_IFYG;
        /// <summary>
        ///是否风险
        /// </summary>
        private System.Boolean m_IFFX;
        /// <summary>
        ///是否锁定数量
        /// </summary>
        private System.Boolean m_IFSDSL;
        /// <summary>
        ///是否锁定市场价
        /// </summary>
        private System.Boolean m_IFSDSCDJ;
        /// <summary>
        ///是否锁定工料机
        /// </summary>
        private System.Boolean m_IFSDGLJ;
        /// <summary>
        ///是否锁定消耗量
        /// </summary>
        private System.Boolean m_IFSDXHL;
        /// <summary>
        ///所属库类别
        /// </summary>
        private System.String m_SSKLB = string.Empty;
        /// <summary>
        ///所属项目类别
        /// </summary>
        private System.String m_SSXMLB = string.Empty;
        /// <summary>
        ///所属项目
        /// </summary>
        private System.String m_SSXM = string.Empty;
        /// <summary>
        ///工料机备注
        /// </summary>
        private System.String m_GLJBZ = string.Empty;
        /// <summary>
        ///增加次数
        /// </summary>
        private System.String m_ZJCS = string.Empty;
        #endregion

        #region----------------------公有成员定义---------------------------------
        /// <summary>
        ///获取或设置:编号
        ///数据库字段名称:ID
        /// </summary>
        public System.Int32 ID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ID, m_ID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ID = arg.GetFieldValue<System.Int32>();
                    return this.m_ID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_ID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:项目编号
        ///数据库字段名称:XID
        /// </summary>
        public System.Int32 XID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_XID, m_XID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_XID = arg.GetFieldValue<System.Int32>();
                    return this.m_XID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_XID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_XID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:单项工程编号
        ///数据库字段名称:DXID
        /// </summary>
        public System.Int32 DXID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DXID, m_DXID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DXID = arg.GetFieldValue<System.Int32>();
                    return this.m_DXID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DXID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_DXID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:单位工程编号
        ///数据库字段名称:DWID
        /// </summary>
        public System.Int32 DWID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DWID, m_DWID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DWID = arg.GetFieldValue<System.Int32>();
                    return this.m_DWID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DWID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_DWID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:清单编号
        ///数据库字段名称:QID
        /// </summary>
        public System.Int32 QID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_QID, m_QID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_QID = arg.GetFieldValue<System.Int32>();
                    return this.m_QID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_QID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_QID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:子目编号
        ///数据库字段名称:ZID
        /// </summary>
        public System.Int32 ZID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZID, m_ZID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ZID = arg.GetFieldValue<System.Int32>();
                    return this.m_ZID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_ZID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:组成编号
        ///数据库字段名称:ZCID
        /// </summary>
        public System.Int32 ZCID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZCID, m_ZCID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ZCID = arg.GetFieldValue<System.Int32>();
                    return this.m_ZCID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZCID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_ZCID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:组成类别
        ///数据库字段名称:ZCLB
        /// </summary>
        public System.String ZCLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZCLB, m_ZCLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ZCLB = arg.GetFieldValue<System.String>();
                    return this.m_ZCLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZCLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_ZCLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:厂家信息编号
        ///数据库字段名称:CJXXID
        /// </summary>
        public System.Int32 CJXXID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CJXXID, m_CJXXID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CJXXID = arg.GetFieldValue<System.Int32>();
                    return this.m_CJXXID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CJXXID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_CJXXID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:原始工料机编号
        ///数据库字段名称:YSBH
        /// </summary>
        public System.String YSBH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSBH, m_YSBH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_YSBH = arg.GetFieldValue<System.String>();
                    return this.m_YSBH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSBH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_YSBH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:原始名称
        ///数据库字段名称:YSMC
        /// </summary>
        public System.String YSMC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSMC, m_YSMC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_YSMC = arg.GetFieldValue<System.String>();
                    return this.m_YSMC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSMC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_YSMC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:原始单位
        ///数据库字段名称:YSDW
        /// </summary>
        public System.String YSDW
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSDW, m_YSDW))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_YSDW = arg.GetFieldValue<System.String>();
                    return this.m_YSDW;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSDW, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_YSDW = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:原始消耗量
        ///数据库字段名称:YSXHL
        /// </summary>
        public System.Decimal YSXHL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSXHL, m_YSXHL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_YSXHL = arg.GetFieldValue<System.Decimal>();
                    return this.m_YSXHL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_YSXHL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_YSXHL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:定额单价
        ///数据库字段名称:DEDJ
        /// </summary>
        public System.Decimal DEDJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DEDJ, m_DEDJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DEDJ = arg.GetFieldValue<System.Decimal>();
                    return this.m_DEDJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DEDJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_DEDJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:定额合价
        ///数据库字段名称:DEHJ
        /// </summary>
        public System.Decimal DEHJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DEHJ, m_DEHJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DEHJ = arg.GetFieldValue<System.Decimal>();
                    return this.m_DEHJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DEHJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_DEHJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:工料机编号
        ///数据库字段名称:BH
        /// </summary>
        public System.String BH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_BH, m_BH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_BH = arg.GetFieldValue<System.String>();
                    return this.m_BH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_BH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_BH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:类别
        ///数据库字段名称:LB
        /// </summary>
        public System.String LB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_LB, m_LB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_LB = arg.GetFieldValue<System.String>();
                    return this.m_LB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_LB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_LB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:三大材类别
        ///数据库字段名称:SDCLB
        /// </summary>
        public System.String SDCLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDCLB, m_SDCLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SDCLB = arg.GetFieldValue<System.String>();
                    return this.m_SDCLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDCLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_SDCLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:三大材系数
        ///数据库字段名称:SDCXS
        /// </summary>
        public System.Decimal SDCXS
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDCXS, m_SDCXS))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SDCXS = arg.GetFieldValue<System.Decimal>();
                    return this.m_SDCXS;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDCXS, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_SDCXS = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:三大材和价
        ///数据库字段名称:SDCHJ
        /// </summary>
        public System.Decimal SDCHJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDCHJ, m_SDCHJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SDCHJ = arg.GetFieldValue<System.Decimal>();
                    return this.m_SDCHJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDCHJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_SDCHJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:名称
        ///数据库字段名称:MC
        /// </summary>
        public System.String MC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_MC, m_MC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_MC = arg.GetFieldValue<System.String>();
                    return this.m_MC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_MC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_MC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:规格及型
        ///数据库字段名称:GGXH
        /// </summary>
        public System.String GGXH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_GGXH, m_GGXH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_GGXH = arg.GetFieldValue<System.String>();
                    return this.m_GGXH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_GGXH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_GGXH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:单位
        ///数据库字段名称:DW
        /// </summary>
        public System.String DW
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DW, m_DW))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DW = arg.GetFieldValue<System.String>();
                    return this.m_DW;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DW, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_DW = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:市场单价
        ///数据库字段名称:SCDJ
        /// </summary>
        public System.Decimal SCDJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SCDJ, m_SCDJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SCDJ = arg.GetFieldValue<System.Decimal>();
                    return this.m_SCDJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SCDJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_SCDJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:市场合价
        ///数据库字段名称:SCHJ
        /// </summary>
        public System.Decimal SCHJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SCHJ, m_SCHJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SCHJ = arg.GetFieldValue<System.Decimal>();
                    return this.m_SCHJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SCHJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_SCHJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:消耗量
        ///数据库字段名称:XHL
        /// </summary>
        public System.Decimal XHL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_XHL, m_XHL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_XHL = arg.GetFieldValue<System.Decimal>();
                    return this.m_XHL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_XHL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_XHL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:工程量
        ///数据库字段名称:GCL
        /// </summary>
        public System.Decimal GCL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_GCL, m_GCL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_GCL = arg.GetFieldValue<System.Decimal>();
                    return this.m_GCL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_GCL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_GCL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:价差
        ///数据库字段名称:JC
        /// </summary>
        public System.Decimal JC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_JC, m_JC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_JC = arg.GetFieldValue<System.Decimal>();
                    return this.m_JC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_JC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_JC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:数量
        ///数据库字段名称:SL
        /// </summary>
        public System.Decimal SL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SL, m_SL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SL = arg.GetFieldValue<System.Decimal>();
                    return this.m_SL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_SL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否评标
        ///数据库字段名称:IFPB
        /// </summary>
        public System.Boolean IFPB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFPB, m_IFPB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFPB = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFPB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFPB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFPB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否暂定
        ///数据库字段名称:IFZG
        /// </summary>
        public System.Boolean IFZG
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFZG, m_IFZG))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFZG = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFZG;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFZG, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFZG = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否甲供
        ///数据库字段名称:IFJG
        /// </summary>
        public System.Boolean IFJG
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFJG, m_IFJG))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFJG = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFJG;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFJG, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFJG = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否乙供
        ///数据库字段名称:IFYG
        /// </summary>
        public System.Boolean IFYG
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFYG, m_IFYG))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFYG = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFYG;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFYG, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFYG = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否风险
        ///数据库字段名称:IFFX
        /// </summary>
        public System.Boolean IFFX
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFFX, m_IFFX))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFFX = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFFX;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFFX, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFFX = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否锁定数量
        ///数据库字段名称:IFSDSL
        /// </summary>
        public System.Boolean IFSDSL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDSL, m_IFSDSL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFSDSL = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFSDSL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDSL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFSDSL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否锁定市场价
        ///数据库字段名称:IFSDSCDJ
        /// </summary>
        public System.Boolean IFSDSCDJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDSCDJ, m_IFSDSCDJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFSDSCDJ = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFSDSCDJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDSCDJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFSDSCDJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否锁定工料机
        ///数据库字段名称:IFSDGLJ
        /// </summary>
        public System.Boolean IFSDGLJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDGLJ, m_IFSDGLJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFSDGLJ = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFSDGLJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDGLJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFSDGLJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:是否锁定消耗量
        ///数据库字段名称:IFSDXHL
        /// </summary>
        public System.Boolean IFSDXHL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDXHL, m_IFSDXHL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFSDXHL = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFSDXHL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFSDXHL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFSDXHL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:所属库类别
        ///数据库字段名称:SSKLB
        /// </summary>
        public System.String SSKLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SSKLB, m_SSKLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SSKLB = arg.GetFieldValue<System.String>();
                    return this.m_SSKLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SSKLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_SSKLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:所属项目类别
        ///数据库字段名称:SSXMLB
        /// </summary>
        public System.String SSXMLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SSXMLB, m_SSXMLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SSXMLB = arg.GetFieldValue<System.String>();
                    return this.m_SSXMLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SSXMLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_SSXMLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:所属项目
        ///数据库字段名称:SSXM
        /// </summary>
        public System.String SSXM
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SSXM, m_SSXM))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SSXM = arg.GetFieldValue<System.String>();
                    return this.m_SSXM;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SSXM, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_SSXM = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:工料机备注
        ///数据库字段名称:GLJBZ
        /// </summary>
        public System.String GLJBZ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_GLJBZ, m_GLJBZ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_GLJBZ = arg.GetFieldValue<System.String>();
                    return this.m_GLJBZ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_GLJBZ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_GLJBZ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置:工料机备注
        ///数据库字段名称:GLJBZ
        /// </summary>
        public System.String ZJCS
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZJCS, m_ZJCS))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ZJCS = arg.GetFieldValue<System.String>();
                    return this.m_ZJCS;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZJCS, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_ZJCS = value;
                }
            }
        }
        #endregion
    }
}
