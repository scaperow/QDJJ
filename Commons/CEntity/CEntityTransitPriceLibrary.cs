/****************************************************
*紫柏软件代码生成实体类
*生成日期:2011年01月26日　12时09分23秒
*备注:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///DELETELIBRARYUSERPRICE业务实体类
    /// </summary>
    [Serializable]
    public class CEntityTransitPriceLibrary : CEntity
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        public const string TABLE_NAME = "DELETELIBRARYUSERPRICE";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJBH = "Caijbh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_LIBRARYTYPE = "LibraryType";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_SOURCE = "Source";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ADDTYPE = "AddType";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ADDCOUNT = "AddCount";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_ID;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJBH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_LIBRARYTYPE = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_SOURCE = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_ADDTYPE = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_ADDCOUNT = string.Empty;
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
        ///数据库字段名称:CAIJBH
        /// </summary>
        public System.String CAIJBH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJBH, m_CAIJBH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJBH = arg.GetFieldValue<System.String>();
                    return this.m_CAIJBH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJBH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJBH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:LIBRARYTYPE
        /// </summary>
        public System.String LIBRARYTYPE
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_LIBRARYTYPE, m_LIBRARYTYPE))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_LIBRARYTYPE = arg.GetFieldValue<System.String>();
                    return this.m_LIBRARYTYPE;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_LIBRARYTYPE, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_LIBRARYTYPE = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:SOURCE
        /// </summary>
        public System.String SOURCE
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SOURCE, m_SOURCE))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SOURCE = arg.GetFieldValue<System.String>();
                    return this.m_SOURCE;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SOURCE, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_SOURCE = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:ADDTYPE
        /// </summary>
        public System.String ADDTYPE
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ADDTYPE, m_ADDTYPE))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ADDTYPE = arg.GetFieldValue<System.String>();
                    return this.m_ADDTYPE;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ADDTYPE, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_ADDTYPE = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:ADDCOUNT
        /// </summary>
        public System.String ADDCOUNT
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ADDCOUNT, m_ADDCOUNT))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ADDCOUNT = arg.GetFieldValue<System.String>();
                    return this.m_ADDCOUNT;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ADDCOUNT, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_ADDCOUNT = value;
                }
            }
        }
        #endregion


    }
}
