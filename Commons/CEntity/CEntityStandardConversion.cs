/****************************************************
*紫柏软件代码生成实体类
*生成日期:2011年04月25日　03时10分00秒
*备注:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///STANDARDCONVERSION业务实体类
    /// </summary>
    [Serializable]
    public class CEntityStandardConversion : CEntity
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        public const string TABLE_NAME = "STANDARDCONVERSION";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ID = "ID";
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
        public const string FILED_IFXZ = "IFXZ";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_IFHS = "IFHS";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_DINGEH = "DINGEH";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_HUANSLB = "HUANSLB";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_TISXX = "TISXX";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_HUANSJS_R = "HUANSJS_R";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_HUANSDEH_C = "HUANSDEH_C";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ZENGL_J = "ZENGL_J";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ZC = "ZC";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_SB = "SB";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_DJDW = "DJDW";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_FZ = "FZ";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_XHLB = "XHLB";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_THZHC = "THZHC";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_THWZFC = "THWZFC";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_HSXI = "HSXI";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_ID;
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
        private System.Boolean m_IFXZ;
        /// <summary>
        ///
        /// </summary>
        private System.Boolean m_IFHS;
        /// <summary>
        ///
        /// </summary>
        private System.String m_DINGEH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_HUANSLB = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_TISXX = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_HUANSJS_R = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_HUANSDEH_C = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_ZENGL_J = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_ZC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_SB = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_DJDW = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_FZ = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_XHLB = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_THZHC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_THWZFC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_HSXI = string.Empty;
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
        ///数据库字段名称:IFXZ
        /// </summary>
        public System.Boolean IFXZ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFXZ, m_IFXZ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFXZ = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFXZ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFXZ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFXZ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:IFHS
        /// </summary>
        public System.Boolean IFHS
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFHS, m_IFHS))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IFHS = arg.GetFieldValue<System.Boolean>();
                    return this.m_IFHS;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IFHS, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_IFHS = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:DINGEH
        /// </summary>
        public System.String DINGEH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DINGEH, m_DINGEH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DINGEH = arg.GetFieldValue<System.String>();
                    return this.m_DINGEH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DINGEH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_DINGEH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:HUANSLB
        /// </summary>
        public System.String HUANSLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_HUANSLB, m_HUANSLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_HUANSLB = arg.GetFieldValue<System.String>();
                    return this.m_HUANSLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_HUANSLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_HUANSLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:TISXX
        /// </summary>
        public System.String TISXX
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_TISXX, m_TISXX))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_TISXX = arg.GetFieldValue<System.String>();
                    return this.m_TISXX;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_TISXX, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_TISXX = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:HUANSJS_R
        /// </summary>
        public System.String HUANSJS_R
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_HUANSJS_R, m_HUANSJS_R))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_HUANSJS_R = arg.GetFieldValue<System.String>();
                    return this.m_HUANSJS_R;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_HUANSJS_R, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_HUANSJS_R = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:HUANSDEH_C
        /// </summary>
        public System.String HUANSDEH_C
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_HUANSDEH_C, m_HUANSDEH_C))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_HUANSDEH_C = arg.GetFieldValue<System.String>();
                    return this.m_HUANSDEH_C;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_HUANSDEH_C, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_HUANSDEH_C = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:ZENGL_J
        /// </summary>
        public System.String ZENGL_J
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZENGL_J, m_ZENGL_J))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ZENGL_J = arg.GetFieldValue<System.String>();
                    return this.m_ZENGL_J;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZENGL_J, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_ZENGL_J = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:ZC
        /// </summary>
        public System.String ZC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZC, m_ZC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ZC = arg.GetFieldValue<System.String>();
                    return this.m_ZC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ZC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_ZC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:SB
        /// </summary>
        public System.String SB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SB, m_SB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SB = arg.GetFieldValue<System.String>();
                    return this.m_SB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_SB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:DJDW
        /// </summary>
        public System.String DJDW
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_DJDW, m_DJDW))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_DJDW = arg.GetFieldValue<System.String>();
                    return this.m_DJDW;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_DJDW, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_DJDW = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:FZ
        /// </summary>
        public System.String FZ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_FZ, m_FZ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_FZ = arg.GetFieldValue<System.String>();
                    return this.m_FZ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_FZ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_FZ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:XHLB
        /// </summary>
        public System.String XHLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_XHLB, m_XHLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_XHLB = arg.GetFieldValue<System.String>();
                    return this.m_XHLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_XHLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_XHLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:THZHC
        /// </summary>
        public System.String THZHC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_THZHC, m_THZHC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_THZHC = arg.GetFieldValue<System.String>();
                    return this.m_THZHC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_THZHC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_THZHC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:THWZFC
        /// </summary>
        public System.String THWZFC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_THWZFC, m_THWZFC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_THWZFC = arg.GetFieldValue<System.String>();
                    return this.m_THWZFC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_THWZFC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_THWZFC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:HSXI
        /// </summary>
        public System.String HSXI
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_HSXI, m_HSXI))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_HSXI = arg.GetFieldValue<System.String>();
                    return this.m_HSXI;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_HSXI, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_HSXI = value;
                }
            }
        }
        #endregion


    }
}
