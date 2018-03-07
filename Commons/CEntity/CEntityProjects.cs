/****************************************************
*�ϰ������������ʵ����
*��������:2011��57��13�ա�05ʱ06��04��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.ComponentModel;



namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///PROJECTSҵ��ʵ����
    /// </summary>
    [Serializable]
    public class CEntityProjects : CEntity
    {
        #region----------------------�ֶγ�������---------------------------------
        /// <summary>
        ///
        /// </summary>
        public const string TABLE_NAME = "PROJECTS";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PROJECTNAME = "ProjectName";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PROJECTCODE = "ProjectCode";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PASSWORD = "PassWord";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PGCDD = "Pgcdd";
        /// <summary>
        ///
        /// </summary>
        //public const string FILED_PQDGZ = "Pqdgz";
        /// <summary>
        ///
        /// </summary>
        //public const string FILED_PDEGZ = "Pdegz";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PJFCX = "Pjfcx";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_PNSDD = "Pnsdd";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_CREATOR = "Creator";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_EDITOR = "Editor";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_FISTDATETIME = "FistDateTime";
        /// <summary>
        ///
        /// </summary>
        public const string FILED_EDITDATETIME = "EditDateTime";
        #endregion

        #region----------------------˽�г�Ա����---------------------------------
        /// <summary>
        ///
        /// </summary>
        private System.Int64 m_ID;
        /// <summary>
        ///
        /// </summary>
        private System.String m_PROJECTCODE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private System.String m_PROJECTNAME = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_PASSWORD = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_PGCDD = string.Empty;
        /// <summary>
        ///
        /// </summary>
        // private System.String m_PQDGZ = string.Empty;
        /// <summary>
        ///
        /// </summary>
        //private System.String m_PDEGZ = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_PJFCX = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_PNSDD = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_CREATOR = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_EDITOR = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_FISTDATETIME = string.Empty;
        /// <summary>
        ///
        /// </summary>
        private System.String m_EDITDATETIME = string.Empty;
        #endregion

        #region----------------------���г�Ա����---------------------------------
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:ID
        /// </summary>
        public System.Int64 ID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_ID, m_ID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_ID = arg.GetFieldValue<System.Int64>();
                    return this.m_ID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_ID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int64>();
                    this.m_ID = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PROJECTCODE
        /// </summary>
        [CategoryAttribute("��Ŀ"), DescriptionAttribute("��Ŀ���")] 
        public System.String PROJECTCODE
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PROJECTCODE, m_PROJECTCODE))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PROJECTCODE = arg.GetFieldValue<System.String>();
                    return this.m_PROJECTCODE;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PROJECTCODE, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_PROJECTCODE = value;
                }
            }
        }

        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PROJECTCODE
        /// </summary>
        [CategoryAttribute("��Ŀ"), DescriptionAttribute("��Ŀ����")] 
        public System.String PROJECTNAME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PROJECTNAME, m_PROJECTNAME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PROJECTCODE = arg.GetFieldValue<System.String>();
                    return this.m_PROJECTNAME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PROJECTNAME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_PROJECTNAME = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PASSWORD
        /// </summary>
        public System.String PASSWORD
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PASSWORD, m_PASSWORD))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PASSWORD = arg.GetFieldValue<System.String>();
                    return this.m_PASSWORD;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PASSWORD, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_PASSWORD = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PGCDD
        /// </summary>
        public System.String PGCDD
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PGCDD, m_PGCDD))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PGCDD = arg.GetFieldValue<System.String>();
                    return this.m_PGCDD;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PGCDD, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_PGCDD = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PQDGZ
        /// </summary>
        //public System.String PQDGZ
        //{
        //    get
        //    {
        //        using (CEventProperty arg = new CEventProperty(FILED_PQDGZ, m_PQDGZ))
        //        {
        //            this.OnPropertyGet(this, arg);
        //            if (arg.IsChangeValue)
        //                this.m_PQDGZ = arg.GetFieldValue<System.String>();
        //            return this.m_PQDGZ;
        //        }
        //    }
        //    set
        //    {
        //        using (CEventProperty arg = new CEventProperty(FILED_PQDGZ, value))
        //        {
        //            this.OnPropertyGet(this, arg);
        //            if (arg.IsChangeValue)
        //                value = arg.GetFieldValue<System.String>();
        //            this.m_PQDGZ = value;
        //        }
        //    }
        //}
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PDEGZ
        /// </summary>
        //public System.String PDEGZ
        //{
        //    get
        //    {
        //        using (CEventProperty arg = new CEventProperty(FILED_PDEGZ, m_PDEGZ))
        //        {
        //            this.OnPropertyGet(this, arg);
        //            if (arg.IsChangeValue)
        //                this.m_PDEGZ = arg.GetFieldValue<System.String>();
        //            return this.m_PDEGZ;
        //        }
        //    }
        //    set
        //    {
        //        using (CEventProperty arg = new CEventProperty(FILED_PDEGZ, value))
        //        {
        //            this.OnPropertyGet(this, arg);
        //            if (arg.IsChangeValue)
        //                value = arg.GetFieldValue<System.String>();
        //            this.m_PDEGZ = value;
        //        }
        //    }
        //}
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PJFCX
        /// </summary>
        public System.String PJFCX
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PJFCX, m_PJFCX))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PJFCX = arg.GetFieldValue<System.String>();
                    return this.m_PJFCX;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PJFCX, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_PJFCX = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:PNSDD
        /// </summary>
        public System.String PNSDD
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_PNSDD, m_PNSDD))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_PNSDD = arg.GetFieldValue<System.String>();
                    return this.m_PNSDD;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_PNSDD, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_PNSDD = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:CREATOR
        /// </summary>
        public System.String CREATOR
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_CREATOR, m_CREATOR))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_CREATOR = arg.GetFieldValue<System.String>();
                    return this.m_CREATOR;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_CREATOR, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_CREATOR = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:EDITOR
        /// </summary>
        public System.String EDITOR
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_EDITOR, m_EDITOR))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_EDITOR = arg.GetFieldValue<System.String>();
                    return this.m_EDITOR;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_EDITOR, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_EDITOR = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:FISTDATETIME
        /// </summary>
        public System.String FISTDATETIME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_FISTDATETIME, m_FISTDATETIME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_FISTDATETIME = arg.GetFieldValue<System.String>();
                    return this.m_FISTDATETIME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_FISTDATETIME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_FISTDATETIME = value;
                }
            }
        }
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:EDITDATETIME
        /// </summary>
        public System.String EDITDATETIME
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_EDITDATETIME, m_EDITDATETIME))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_EDITDATETIME = arg.GetFieldValue<System.String>();
                    return this.m_EDITDATETIME;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_EDITDATETIME, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_EDITDATETIME = value;
                }
            }
        }
        #endregion
    }
}

