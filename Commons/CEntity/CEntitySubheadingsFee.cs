using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;


namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class CEntitySubheadingsFee : CEntity
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        public const string TABLE_NAME = "子目取费表";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PARENTID = "PARENTID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_XID = "XID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_DID = "DID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_QID = "QID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ZID = "ZID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_YYH = "YYH";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_MC = "MC";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_BDS = "BDS";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_TBJSJC = "TBJSJC";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_BDJSJC = "BDJSJC";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_FL = "FL";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_JSJCJG = "JSJCJG";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_JE = "JE";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_BEIZHU = "BEIZHU";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_ID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_PARENTID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_XID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_DID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_QID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_ZID;
        /// <summary>
        ///
        /// </summary>
        private System.String m_YYH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_MC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_BDS = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_TBJSJC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_BDJSJC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.Decimal m_FL;
        /// <summary>
        ///
        /// </summary>
        private System.Decimal m_JSJCJG;
        /// <summary>
        ///
        /// </summary>
        private System.Decimal m_JE;
        /// <summary>
        ///
        /// </summary>
        private System.String m_BEIZHU = string.Empty;
        #endregion

        #region----------------------公有成员定义---------------------------------
        /// <summary>
        ///获取或设置
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
        ///获取或设置
        ///数据库字段名称:PARENTID
        /// </summary>
        public System.Int32 PARENTID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PARENTID, m_PARENTID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PARENTID = arg.GetFieldValue<System.Int32>();
                    return this.m_PARENTID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PARENTID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_PARENTID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
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
        ///获取或设置
        ///数据库字段名称:DID
        /// </summary>
        public System.Int32 DID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DID, m_DID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DID = arg.GetFieldValue<System.Int32>();
                    return this.m_DID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_DID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
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
        ///获取或设置
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
        ///获取或设置
        ///数据库字段名称:YYH
        /// </summary>
        public System.String YYH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_YYH, m_YYH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_YYH = arg.GetFieldValue<System.String>();
                    return this.m_YYH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_YYH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_YYH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
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
        ///获取或设置
        ///数据库字段名称:BDS
        /// </summary>
        public System.String BDS
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_BDS, m_BDS))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_BDS = arg.GetFieldValue<System.String>();
                    return this.m_BDS;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_BDS, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_BDS = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:TBJSJC
        /// </summary>
        public System.String TBJSJC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_TBJSJC, m_TBJSJC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_TBJSJC = arg.GetFieldValue<System.String>();
                    return this.m_TBJSJC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_TBJSJC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_TBJSJC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:BDJSJC
        /// </summary>
        public System.String BDJSJC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_BDJSJC, m_BDJSJC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_BDJSJC = arg.GetFieldValue<System.String>();
                    return this.m_BDJSJC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_BDJSJC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_BDJSJC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:FL
        /// </summary>
        public System.Decimal FL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_FL, m_FL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_FL = arg.GetFieldValue<System.Decimal>();
                    return this.m_FL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_FL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_FL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:JSJCJG
        /// </summary>
        public System.Decimal JSJCJG
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_JSJCJG, m_JSJCJG))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_JSJCJG = arg.GetFieldValue<System.Decimal>();
                    return this.m_JSJCJG;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_JSJCJG, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_JSJCJG = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:JE
        /// </summary>
        public System.Decimal JE
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_JE, m_JE))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_JE = arg.GetFieldValue<System.Decimal>();
                    return this.m_JE;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_JE, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Decimal>();
                    this.m_JE = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:BEIZHU
        /// </summary>
        public System.String BEIZHU
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_BEIZHU, m_BEIZHU))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_BEIZHU = arg.GetFieldValue<System.String>();
                    return this.m_BEIZHU;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_BEIZHU, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_BEIZHU = value;
                }
            }
        }
        #endregion
    }
}
