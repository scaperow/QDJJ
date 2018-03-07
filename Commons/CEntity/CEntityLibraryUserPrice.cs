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
    ///LIBRARYUSERPRICE业务实体类
    /// </summary>
    [Serializable]
    public class CEntityLibraryUserPrice : CEntity
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        ///
        /// </summary>
        public const string TABLE_NAME = "LIBRARYUSERPRICE";
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
        public const string FILED_RID = "RID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PID = "PID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJBH = "Caijbh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJLB = "Caijlb";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJMC = "Caijmc";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJXH = "Caijxh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJDW = "Caijdw";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJDJ = "Caijdj";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJDJH = "Caijdjh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJSJ = "Caijsj";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJSJH = "Caijsjh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJSDJC = "Caijsdjc";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJSHJC = "Caijshjc";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJXHL = "Caijxhl";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJXHLH = "Caijxhlh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJSLH = "Caijslh";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJIFZG = "Caijifzg";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJIFGJ = "Caijifgj";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJIFCJ = "Caijifcj";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJIFSD = "Caijifsd";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CAIJBZ = "Caijbz";
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
        private System.Int32 m_RID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m_PID;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJBH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJLB = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJMC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJXH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJDW = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJDJ = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJDJH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJSJ = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJSJH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJSDJC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJSHJC = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJXHL = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJXHLH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJSLH = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.Boolean m_CAIJIFZG;
        /// <summary>
        ///
        /// </summary>
        private System.Boolean m_CAIJIFGJ;
        /// <summary>
        ///
        /// </summary>
        private System.Boolean m_CAIJIFCJ;
        /// <summary>
        ///
        /// </summary>
        private System.Boolean m_CAIJIFSD;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CAIJBZ = string.Empty;
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
        ///数据库字段名称:RID
        /// </summary>
        public System.Int32 RID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_RID, m_RID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_RID = arg.GetFieldValue<System.Int32>();
                    return this.m_RID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_RID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_RID = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:PID
        /// </summary>
        public System.Int32 PID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PID, m_PID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PID = arg.GetFieldValue<System.Int32>();
                    return this.m_PID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m_PID = value;
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
        ///数据库字段名称:CAIJLB
        /// </summary>
        public System.String CAIJLB
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJLB, m_CAIJLB))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJLB = arg.GetFieldValue<System.String>();
                    return this.m_CAIJLB;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJLB, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJLB = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJMC
        /// </summary>
        public System.String CAIJMC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJMC, m_CAIJMC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJMC = arg.GetFieldValue<System.String>();
                    return this.m_CAIJMC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJMC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJMC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJXH
        /// </summary>
        public System.String CAIJXH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJXH, m_CAIJXH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJXH = arg.GetFieldValue<System.String>();
                    return this.m_CAIJXH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJXH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJXH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJDW
        /// </summary>
        public System.String CAIJDW
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJDW, m_CAIJDW))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJDW = arg.GetFieldValue<System.String>();
                    return this.m_CAIJDW;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJDW, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJDW = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJDJ
        /// </summary>
        public System.String CAIJDJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJDJ, m_CAIJDJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJDJ = arg.GetFieldValue<System.String>();
                    return this.m_CAIJDJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJDJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJDJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJDJH
        /// </summary>
        public System.String CAIJDJH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJDJH, m_CAIJDJH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJDJH = arg.GetFieldValue<System.String>();
                    return this.m_CAIJDJH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJDJH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJDJH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJSJ
        /// </summary>
        public System.String CAIJSJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSJ, m_CAIJSJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJSJ = arg.GetFieldValue<System.String>();
                    return this.m_CAIJSJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJSJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJSJH
        /// </summary>
        public System.String CAIJSJH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSJH, m_CAIJSJH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJSJH = arg.GetFieldValue<System.String>();
                    return this.m_CAIJSJH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSJH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJSJH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJSDJC
        /// </summary>
        public System.String CAIJSDJC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSDJC, m_CAIJSDJC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJSDJC = arg.GetFieldValue<System.String>();
                    return this.m_CAIJSDJC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSDJC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJSDJC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJSHJC
        /// </summary>
        public System.String CAIJSHJC
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSHJC, m_CAIJSHJC))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJSHJC = arg.GetFieldValue<System.String>();
                    return this.m_CAIJSHJC;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSHJC, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJSHJC = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJXHL
        /// </summary>
        public System.String CAIJXHL
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJXHL, m_CAIJXHL))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJXHL = arg.GetFieldValue<System.String>();
                    return this.m_CAIJXHL;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJXHL, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJXHL = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJXHLH
        /// </summary>
        public System.String CAIJXHLH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJXHLH, m_CAIJXHLH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJXHLH = arg.GetFieldValue<System.String>();
                    return this.m_CAIJXHLH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJXHLH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJXHLH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJSLH
        /// </summary>
        public System.String CAIJSLH
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSLH, m_CAIJSLH))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJSLH = arg.GetFieldValue<System.String>();
                    return this.m_CAIJSLH;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJSLH, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJSLH = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJIFZG
        /// </summary>
        public System.Boolean CAIJIFZG
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFZG, m_CAIJIFZG))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJIFZG = arg.GetFieldValue<System.Boolean>();
                    return this.m_CAIJIFZG;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFZG, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_CAIJIFZG = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJIFGJ
        /// </summary>
        public System.Boolean CAIJIFGJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFGJ, m_CAIJIFGJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJIFGJ = arg.GetFieldValue<System.Boolean>();
                    return this.m_CAIJIFGJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFGJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_CAIJIFGJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJIFCJ
        /// </summary>
        public System.Boolean CAIJIFCJ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFCJ, m_CAIJIFCJ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJIFCJ = arg.GetFieldValue<System.Boolean>();
                    return this.m_CAIJIFCJ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFCJ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_CAIJIFCJ = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJIFSD
        /// </summary>
        public System.Boolean CAIJIFSD
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFSD, m_CAIJIFSD))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJIFSD = arg.GetFieldValue<System.Boolean>();
                    return this.m_CAIJIFSD;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJIFSD, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_CAIJIFSD = value;
                }
            }
        }
        /// <summary>
        ///获取或设置
        ///数据库字段名称:CAIJBZ
        /// </summary>
        public System.String CAIJBZ
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJBZ, m_CAIJBZ))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CAIJBZ = arg.GetFieldValue<System.String>();
                    return this.m_CAIJBZ;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CAIJBZ, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CAIJBZ = value;
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
