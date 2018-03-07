/****************************************************
*�ϰ������������ʵ����
*��������:2011��34��13�ա�11ʱ06��00��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///TREELISTҵ��ʵ����
    /// </summary>
    public class CEntityTreelist : CEntity
    {
        #region----------------------�ֶγ�������---------------------------------
        /// <summary>
        ///
        /// </summary>
        public const string TABLE_NAME = "TREELIST";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_KEYFIELDNAME = "KeyFieldName";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PARENTFIELDNAME = "ParentFieldName";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_NODENAME = "NodeName";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_REMARK = "remark";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_IMAGEINDEX = "ImageIndex";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_COMMANDNAME = "CommandName";
        #endregion

        #region----------------------˽�г�Ա����---------------------------------
        /// <summary>
        ///
        /// </summary>
        private System.Int64 m_KEYFIELDNAME;
        /// <summary>
        ///
        /// </summary>
        private System.Int64 m_PARENTFIELDNAME;
        /// <summary>
        ///
        /// </summary>
        private System.String m_NODENAME = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_REMARK = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.Int64 m_IMAGEINDEX;
        /// <summary>
        ///
        /// </summary>
        private System.String m_COMMANDNAME = string.Empty;
        #endregion

        #region----------------------���г�Ա����---------------------------------
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:KEYFIELDNAME
        /// </summary>
        public System.Int64 KEYFIELDNAME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_KEYFIELDNAME, m_KEYFIELDNAME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_KEYFIELDNAME = arg.GetFieldValue<System.Int64>();
                    return this.m_KEYFIELDNAME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_KEYFIELDNAME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int64>();
                    this.m_KEYFIELDNAME = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PARENTFIELDNAME
        /// </summary>
        public System.Int64 PARENTFIELDNAME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PARENTFIELDNAME, m_PARENTFIELDNAME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PARENTFIELDNAME = arg.GetFieldValue<System.Int64>();
                    return this.m_PARENTFIELDNAME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PARENTFIELDNAME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int64>();
                    this.m_PARENTFIELDNAME = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:NODENAME
        /// </summary>
        public System.String NODENAME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_NODENAME, m_NODENAME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_NODENAME = arg.GetFieldValue<System.String>();
                    return this.m_NODENAME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_NODENAME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_NODENAME = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:REMARK
        /// </summary>
        public System.String REMARK
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_REMARK, m_REMARK))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_REMARK = arg.GetFieldValue<System.String>();
                    return this.m_REMARK;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_REMARK, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_REMARK = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:IMAGEINDEX
        /// </summary>
        public System.Int64 IMAGEINDEX
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_IMAGEINDEX, m_IMAGEINDEX))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_IMAGEINDEX = arg.GetFieldValue<System.Int64>();
                    return this.m_IMAGEINDEX;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_IMAGEINDEX, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int64>();
                    this.m_IMAGEINDEX = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:COMMANDNAME
        /// </summary>
        public System.String COMMANDNAME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_COMMANDNAME, m_COMMANDNAME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_COMMANDNAME = arg.GetFieldValue<System.String>();
                    return this.m_COMMANDNAME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_COMMANDNAME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_COMMANDNAME = value;
                }
            }
        }
    }
}
		#endregion


