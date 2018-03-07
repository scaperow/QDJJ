using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///���ϻ�ʵ����
    /// </summary>
    [Serializable]
    public class CEntityQuantityUnit : CEntity
    {
        #region----------------------�ֶγ�������---------------------------------
        /// <summary>
        ///����
        /// </summary>
        public const string TABLE_NAME = "QUANTITYUNIT";
        /// <summary>
        ///���
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        ///��Ŀ���
        /// </summary>
        public const string FILED_XID = "XID";
        /// <summary>
        ///����̱��
        /// </summary>
        public const string FILED_DXID = "DXID";
        /// <summary>
        ///��λ���̱��
        /// </summary>
        public const string FILED_DWID = "DWID";
        /// <summary>
        ///�嵥���
        /// </summary>
        public const string FILED_QID = "QID";
        /// <summary>
        ///��Ŀ���
        /// </summary>
        public const string FILED_ZID = "ZID";
        /// <summary>
        ///��ɱ��
        /// </summary>
        public const string FILED_ZCID = "ZCID";
        /// <summary>
        ///������
        /// </summary>
        public const string FILED_ZCLB = "ZCLB";
        /// <summary>
        ///������Ϣ���
        /// </summary>
        public const string FILED_CJXXID = "CJXXID";
        /// <summary>
        ///ԭʼ���ϻ����
        /// </summary>
        public const string FILED_YSBH = "YSBH";
        /// <summary>
        ///ԭʼ����
        /// </summary>
        public const string FILED_YSMC = "YSMC";
        /// <summary>
        ///ԭʼ��λ
        /// </summary>
        public const string FILED_YSDW = "YSDW";
        /// <summary>
        ///ԭʼ������
        /// </summary>
        public const string FILED_YSXHL = "YSXHL";
        /// <summary>
        ///�����
        /// </summary>
        public const string FILED_DEDJ = "DEDJ";
        /// <summary>
        ///����ϼ�
        /// </summary>
        public const string FILED_DEHJ = "DEHJ";
        /// <summary>
        ///���ϻ����
        /// </summary>
        public const string FILED_BH = "BH";
        /// <summary>
        ///���
        /// </summary>
        public const string FILED_LB = "LB";
        /// <summary>
        ///��������
        /// </summary>
        public const string FILED_SDCLB = "SDCLB";
        /// <summary>
        ///�����ϵ��
        /// </summary>
        public const string FILED_SDCXS = "SDCXS";
        /// <summary>
        ///����ĺͼ�
        /// </summary>
        public const string FILED_SDCHJ = "SDCHJ";
        /// <summary>
        ///����
        /// </summary>
        public const string FILED_MC = "MC";
        /// <summary>
        ///����ͺ�
        /// </summary>
        public const string FILED_GGXH = "GGXH";
        /// <summary>
        ///��λ
        /// </summary>
        public const string FILED_DW = "DW";
        /// <summary>
        ///�г�����
        /// </summary>
        public const string FILED_SCDJ = "SCDJ";
        /// <summary>
        ///�г��ϼ�
        /// </summary>
        public const string FILED_SCHJ = "SCHJ";
        /// <summary>
        ///������
        /// </summary>
        public const string FILED_XHL = "XHL";
        /// <summary>
        ///������ 
        /// </summary>
        public const string FILED_GCL = "GCL";
        /// <summary>
        /// �۲�
        /// </summary>
        public const string FILED_JC = "JC";
        /// <summary>
        ///����
        /// </summary>
        public const string FILED_SL = "SL";
        /// <summary>
        ///�Ƿ�����
        /// </summary>
        public const string FILED_IFPB = "IFPB";
        /// <summary>
        ///�Ƿ��ݶ�
        /// </summary>
        public const string FILED_IFZG = "IFZG";
        /// <summary>
        ///�Ƿ�׹�
        /// </summary>
        public const string FILED_IFJG = "IFJG";
        /// <summary>
        ///�Ƿ��ҹ�
        /// </summary>
        public const string FILED_IFYG = "IFYG";
        /// <summary>
        ///�Ƿ����
        /// </summary>
        public const string FILED_IFFX = "IFFX";
        /// <summary>
        ///�Ƿ���������
        /// </summary>
        public const string FILED_IFSDSL = "IFSDSL";
        /// <summary>
        ///�Ƿ������г���
        /// </summary>
        public const string FILED_IFSDSCDJ = "IFSDSCDJ";
        /// <summary>
        ///�Ƿ��������ϻ�
        /// </summary>
        public const string FILED_IFSDGLJ = "IFSDGLJ";
        /// <summary>
        ///�Ƿ�����������
        /// </summary>
        public const string FILED_IFSDXHL = "IFSDXHL";
        /// <summary>
        ///���������
        /// </summary>
        public const string FILED_SSKLB = "SSKLB";
        /// <summary>
        ///������Ŀ���
        /// </summary>
        public const string FILED_SSXMLB = "SSXMLB";
        /// <summary>
        ///������Ŀ
        /// </summary>
        public const string FILED_SSXM = "SSXM";
        /// <summary>
        ///���ϻ���ע
        /// </summary>
        public const string FILED_GLJBZ = "GLJBZ";
        /// <summary>
        ///���Ӵ���
        /// </summary>
        public const string FILED_ZJCS = "ZJCS";
        #endregion

        #region----------------------˽�г�Ա����---------------------------------
        /// <summary>
        ///���
        /// </summary>
        private System.Int32 m_ID;
        /// <summary>
        ///��Ŀ���
        /// </summary>
        private System.Int32 m_XID;
        /// <summary>
        ///����̱��
        /// </summary>
        private System.Int32 m_DXID;
        /// <summary>
        ///��λ���̱��
        /// </summary>
        private System.Int32 m_DWID;
        /// <summary>
        ///�嵥���
        /// </summary>
        private System.Int32 m_QID;
        /// <summary>
        ///��Ŀ���
        /// </summary>
        private System.Int32 m_ZID;
        /// <summary>
        ///��ɱ��
        /// </summary>
        private System.Int32 m_ZCID;
        /// <summary>
        ///������
        /// </summary>
        private System.String m_ZCLB;
        /// <summary>
        ///������Ϣ���
        /// </summary>
        private System.Int32 m_CJXXID;
        /// <summary>
        ///ԭʼ���ϻ����
        /// </summary>
        private System.String m_YSBH = string.Empty;
        /// <summary>
        ///ԭʼ����
        /// </summary>
        private System.String m_YSMC = string.Empty;
        /// <summary>
        ///ԭʼ��λ
        /// </summary>
        private System.String m_YSDW = string.Empty;
        /// <summary>
        ///ԭʼ������
        /// </summary>
        private System.Decimal m_YSXHL;
        /// <summary>
        ///�����
        /// </summary>
        private System.Decimal m_DEDJ;
        /// <summary>
        ///����ϼ�
        /// </summary>
        private System.Decimal m_DEHJ;
        /// <summary>
        ///���ϻ����
        /// </summary>
        private System.String m_BH = string.Empty;
        /// <summary>
        ///���
        /// </summary>
        private System.String m_LB = string.Empty;
        /// <summary>
        ///��������
        /// </summary>
        private System.String m_SDCLB = string.Empty;
        /// <summary>
        ///�����ϵ��
        /// </summary>
        private System.Decimal m_SDCXS;
        /// <summary>
        ///����ĺͼ�
        /// </summary>
        private System.Decimal m_SDCHJ;
        /// <summary>
        ///����
        /// </summary>
        private System.String m_MC = string.Empty;
        /// <summary>
        ///����ͺ�
        /// </summary>
        private System.String m_GGXH = string.Empty;
        /// <summary>
        ///��λ
        /// </summary>
        private System.String m_DW = string.Empty;
        /// <summary>
        ///�г�����
        /// </summary>
        private System.Decimal m_SCDJ;
        /// <summary>
        ///�г��ϼ�
        /// </summary>
        private System.Decimal m_SCHJ;
        /// <summary>
        ///������
        /// </summary>
        private System.Decimal m_XHL;
        /// <summary>
        ///������
        /// </summary>
        private System.Decimal m_GCL;
        /// <summary>
        /// �۲�
        /// </summary>
        private System.Decimal m_JC;
        /// <summary>
        ///����
        /// </summary>
        private System.Decimal m_SL;
        /// <summary>
        ///�Ƿ�����
        /// </summary>
        private System.Boolean m_IFPB;
        /// <summary>
        ///�Ƿ��ݶ�
        /// </summary>
        private System.Boolean m_IFZG;
        /// <summary>
        ///�Ƿ�׹�
        /// </summary>
        private System.Boolean m_IFJG;
        /// <summary>
        ///�Ƿ��ҹ�
        /// </summary>
        private System.Boolean m_IFYG;
        /// <summary>
        ///�Ƿ����
        /// </summary>
        private System.Boolean m_IFFX;
        /// <summary>
        ///�Ƿ���������
        /// </summary>
        private System.Boolean m_IFSDSL;
        /// <summary>
        ///�Ƿ������г���
        /// </summary>
        private System.Boolean m_IFSDSCDJ;
        /// <summary>
        ///�Ƿ��������ϻ�
        /// </summary>
        private System.Boolean m_IFSDGLJ;
        /// <summary>
        ///�Ƿ�����������
        /// </summary>
        private System.Boolean m_IFSDXHL;
        /// <summary>
        ///���������
        /// </summary>
        private System.String m_SSKLB = string.Empty;
        /// <summary>
        ///������Ŀ���
        /// </summary>
        private System.String m_SSXMLB = string.Empty;
        /// <summary>
        ///������Ŀ
        /// </summary>
        private System.String m_SSXM = string.Empty;
        /// <summary>
        ///���ϻ���ע
        /// </summary>
        private System.String m_GLJBZ = string.Empty;
        /// <summary>
        ///���Ӵ���
        /// </summary>
        private System.String m_ZJCS = string.Empty;
        #endregion

        #region----------------------���г�Ա����---------------------------------
        /// <summary>
        ///��ȡ������:���
        ///���ݿ��ֶ�����:ID
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
        ///��ȡ������:��Ŀ���
        ///���ݿ��ֶ�����:XID
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
        ///��ȡ������:����̱��
        ///���ݿ��ֶ�����:DXID
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
        ///��ȡ������:��λ���̱��
        ///���ݿ��ֶ�����:DWID
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
        ///��ȡ������:�嵥���
        ///���ݿ��ֶ�����:QID
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
        ///��ȡ������:��Ŀ���
        ///���ݿ��ֶ�����:ZID
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
        ///��ȡ������:��ɱ��
        ///���ݿ��ֶ�����:ZCID
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
        ///��ȡ������:������
        ///���ݿ��ֶ�����:ZCLB
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
        ///��ȡ������:������Ϣ���
        ///���ݿ��ֶ�����:CJXXID
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
        ///��ȡ������:ԭʼ���ϻ����
        ///���ݿ��ֶ�����:YSBH
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
        ///��ȡ������:ԭʼ����
        ///���ݿ��ֶ�����:YSMC
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
        ///��ȡ������:ԭʼ��λ
        ///���ݿ��ֶ�����:YSDW
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
        ///��ȡ������:ԭʼ������
        ///���ݿ��ֶ�����:YSXHL
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
        ///��ȡ������:�����
        ///���ݿ��ֶ�����:DEDJ
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
        ///��ȡ������:����ϼ�
        ///���ݿ��ֶ�����:DEHJ
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
        ///��ȡ������:���ϻ����
        ///���ݿ��ֶ�����:BH
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
        ///��ȡ������:���
        ///���ݿ��ֶ�����:LB
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
        ///��ȡ������:��������
        ///���ݿ��ֶ�����:SDCLB
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
        ///��ȡ������:�����ϵ��
        ///���ݿ��ֶ�����:SDCXS
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
        ///��ȡ������:����ĺͼ�
        ///���ݿ��ֶ�����:SDCHJ
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
        ///��ȡ������:����
        ///���ݿ��ֶ�����:MC
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
        ///��ȡ������:�����
        ///���ݿ��ֶ�����:GGXH
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
        ///��ȡ������:��λ
        ///���ݿ��ֶ�����:DW
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
        ///��ȡ������:�г�����
        ///���ݿ��ֶ�����:SCDJ
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
        ///��ȡ������:�г��ϼ�
        ///���ݿ��ֶ�����:SCHJ
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
        ///��ȡ������:������
        ///���ݿ��ֶ�����:XHL
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
        ///��ȡ������:������
        ///���ݿ��ֶ�����:GCL
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
        ///��ȡ������:�۲�
        ///���ݿ��ֶ�����:JC
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
        ///��ȡ������:����
        ///���ݿ��ֶ�����:SL
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
        ///��ȡ������:�Ƿ�����
        ///���ݿ��ֶ�����:IFPB
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
        ///��ȡ������:�Ƿ��ݶ�
        ///���ݿ��ֶ�����:IFZG
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
        ///��ȡ������:�Ƿ�׹�
        ///���ݿ��ֶ�����:IFJG
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
        ///��ȡ������:�Ƿ��ҹ�
        ///���ݿ��ֶ�����:IFYG
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
        ///��ȡ������:�Ƿ����
        ///���ݿ��ֶ�����:IFFX
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
        ///��ȡ������:�Ƿ���������
        ///���ݿ��ֶ�����:IFSDSL
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
        ///��ȡ������:�Ƿ������г���
        ///���ݿ��ֶ�����:IFSDSCDJ
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
        ///��ȡ������:�Ƿ��������ϻ�
        ///���ݿ��ֶ�����:IFSDGLJ
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
        ///��ȡ������:�Ƿ�����������
        ///���ݿ��ֶ�����:IFSDXHL
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
        ///��ȡ������:���������
        ///���ݿ��ֶ�����:SSKLB
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
        ///��ȡ������:������Ŀ���
        ///���ݿ��ֶ�����:SSXMLB
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
        ///��ȡ������:������Ŀ
        ///���ݿ��ֶ�����:SSXM
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
        ///��ȡ������:���ϻ���ע
        ///���ݿ��ֶ�����:GLJBZ
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
        ///��ȡ������:���ϻ���ע
        ///���ݿ��ֶ�����:GLJBZ
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
