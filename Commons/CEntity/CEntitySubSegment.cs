/****************************************************
*�ϰ������������ʵ����
*��������:2011��27��12�ա�11ʱ08��52��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;


namespace GOLDSOFT.QDJJ.COMMONS
{
		/// <summary>
		///CUNITPROJECTҵ��ʵ����
		/// </summary>
        /// 
    [Serializable]
    public class CEntitySubSegment : CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///����
		/// </summary>
        public const string TABLE_NAME = "CEntitySubSegment";
		/// <summary>
		///ID
		/// </summary>
		public const string FILED_ID	=  "ID" ;
		/// <summary>
		///��ID
		/// </summary>
		public const string FILED_PARENID	=  "ParenID" ;
		/// <summary>
		///���
		/// </summary>
		public const string FILED_XH	=  "xh" ;
		/// <summary>
		///��Ŀ����
		/// </summary>
		public const string FILED_XMBM	=  "xmbm" ;
        /// <summary>
        ///ԭʼ��Ŀ����
        /// </summary>
        public const string FILED_OLDXMBM = "oldxmbm";
		/// <summary>
		///��Ŀ����
		/// </summary>
		public const string FILED_XMMC	=  "xmmc" ;
		/// <summary>
		///��λ
		/// </summary>
		public const string FILED_DW	=  "dw" ;
		/// <summary>
		///����
		/// </summary>
		public const string FILED_TX	=  "tx" ;
		/// <summary>
		///���
		/// </summary>
		public const string FILED_LB	=  "lb" ;
		/// <summary>
		///�����
		/// </summary>
		public const string FILED_JCBJ	=  "jcbj" ;
		/// <summary>
		///���˱��
		/// </summary>
		public const string FILED_FHBJ	=  "fhbj" ;
		/// <summary>
		///��Ҫ�嵥
		/// </summary>
		public const string FILED_ZYQD	=  "zyqd" ;
		/// <summary>
		///��Ŀ����
		/// </summary>
		public const string FILED_XMTZ	=  "xmtz" ;
		/// <summary>
		///��������
		/// </summary>
		public const string FILED_SDDJ	=  "sddj" ;
		/// <summary>
		///����������ʽ
		/// </summary>
		public const string FILED_GCLJSS	=  "gcljss" ;
		/// <summary>
		///����
		/// </summary>
		public const string FILED_HL	=  "hl" ;
		/// <summary>
		///������
		/// </summary>
		public const string FILED_GCL	=  "gcl" ;
		/// <summary>
        ///ֱ�ӵ���
		/// </summary>
		public const string FILED_ZJTJ	=  "zjtj" ;
		/// <summary>
		///�ۺϵ���
		/// </summary>
		public const string FILED_ZHDJ	=  "zhdj" ;
		/// <summary>
		///�ۺϺϼ�
		/// </summary>
		public const string FILED_ZHHJ	=  "zhhj" ;
		/// <summary>
        ///ֱ�ӷѵ���
		/// </summary>
		public const string FILED_ZJFDJ	=  "zjfdj" ;
		/// <summary>
		///�˹��ѵ���
		/// </summary>
		public const string FILED_RGFDJ	=  "rgfdj" ;
		/// <summary>
		///���Ϸѵ���
		/// </summary>
		public const string FILED_CLFDJ	=  "clfdj" ;
		/// <summary>
        ///��е�ѵ���
		/// </summary>
		public const string FILED_JXFDJ	=  "jxfdj" ;
		/// <summary>
		///���ķѵ���
		/// </summary>
		public const string FILED_ZCFDJ	=  "zcfdj" ;
		/// <summary>
		///�豸�ѵ���
		/// </summary>
		public const string FILED_SBFDJ	=  "sbfdj" ;
		/// <summary>
		///����ѵ���
		/// </summary>
		public const string FILED_GLFDJ	=  "glfdj" ;
		/// <summary>
		///���󵥼�
		/// </summary>
		public const string FILED_LRDJ	=  "lrdj" ;
		/// <summary>
		///���յ���
		/// </summary>
		public const string FILED_FXDJ	=  "fxdj" ;
		/// <summary>
		///��ѵ���
		/// </summary>
		public const string FILED_GFDJ	=  "gfdj" ;
		/// <summary>
        ///˰�𵥼�
		/// </summary>
		public const string FILED_SJDJ	=  "sjdj" ;
		/// <summary>
        ///ֱ�ӷѺϼ�
		/// </summary>
		public const string FILED_ZJFHJ	=  "zjfhj" ;
		/// <summary>
		///�˹��Ѻϼ�
		/// </summary>
		public const string FILED_RGFHJ	=  "rgfhj" ;
		/// <summary>
		///���ϷѺϼ�
		/// </summary>
		public const string FILED_CLFHJ	=  "clfhj" ;
		/// <summary>
		///��е�Ѻϼ�
		/// </summary>
		public const string FILED_JXFHJ	=  "jxfhj" ;
		/// <summary>
		///���ķѺϼ�
		/// </summary>
		public const string FILED_ZCFHJ	=  "zcfhj" ;
		/// <summary>
		///�豸�Ѻϼ�
		/// </summary>
		public const string FILED_SBFHJ	=  "sbfhj" ;
		/// <summary>
		///����Ѻϼ�
		/// </summary>
		public const string FILED_GLFHJ	=  "glfhj" ;
		/// <summary>
		///����ϼ�
		/// </summary>
		public const string FILED_LRHJ	=  "lrhj" ;
		/// <summary>
		///���պϼ�
		/// </summary>
		public const string FILED_FXHJ	=  "fxhj" ;
		/// <summary>
		///��Ѻϼ�
		/// </summary>
		public const string FILED_GFHJ	=  "gfhj" ;
		/// <summary>
		///˰��ϼ�
		/// </summary>
		public const string FILED_SJHJ	=  "sjhj" ;
		/// <summary>
        ///�۲�ϼ�
		/// </summary>
		public const string FILED_JCHJ	=  "jchj" ;
		/// <summary>
		///��ۺϼ�
		/// </summary>
		public const string FILED_CJHJ	=  "cjhj" ;
		/// <summary>
        ///�ݹ����
		/// </summary>
		public const string FILED_ZGJE	=  "zgje" ;
		/// <summary>
        ///�׹����
		/// </summary>
		public const string FILED_JGJE	=  "jgje" ;
		/// <summary>
        ///�Ƿ�ְ�
		/// </summary>
		public const string FILED_SFFB	=  "sffb" ;
		/// <summary>
		///�ְ����
		/// </summary>
		public const string FILED_FBJE	=  "fbje" ;
		/// <summary>
        ///�ֲ�����
		/// </summary>
		public const string FILED_JBHZ	=  "jbhz" ;
		/// <summary>
        ///�½�λ��
		/// </summary>
		public const string FILED_ZJWZ	=  "zjwz" ;
		/// <summary>
        ///��Ч
		/// </summary>
		public const string FILED_JX	=  "jx" ;
		/// <summary>
        ///�ܸ����
		/// </summary>
		public const string FILED_YGLB	=  "yglb" ;
		/// <summary>
		///���
		/// </summary>
		public const string FILED_SC	=  "sc" ;
		/// <summary>
        ///ȡ������
		/// </summary>
		public const string FILED_QFSZ	=  "qfsz" ;
		/// <summary>
        ///��ע
		/// </summary>
		public const string FILED_BEIZHU	=  "beizhu" ;

        /// <summary>
        ///������
        /// </summary>
        public const string FILED_LibraryName = "LibraryName";


        public const string FILED_DECJ = "decj";
        /// <summary>
        ///�����嵥
        /// </summary>
        public const string FILED_SDQD = "sdqd";
        public const string FILED_LY = "ly";

        /// <summary>
        ///������
        /// </summary>
        public const string FILED_TAG = "Tag";
        public const string FILED__ID = "_ID";
        /// <summary>
        ///��ID
        /// </summary>
        public const string FILED__PARENID = "_ParenID";
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.Int32 m_ID;
		/// <summary>
		///
		/// </summary>
		private System.Int32 m_PARENID;
		/// <summary>
		///
		/// </summary>
		private System.Int32 m_XH;
		/// <summary>
		///
		/// </summary>
		private System.String m_XMBM	=	string.Empty	;
        /// <summary>
        ///
        /// </summary>
        private System.String m_OLDXMBM = string.Empty;
		/// <summary>
		///
		/// </summary>
		private System.String m_XMMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TX	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_LB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
        private System.Boolean m_JCBJ ;
		/// <summary>
		///
		/// </summary>
        private System.Boolean m_FHBJ ;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_ZYQD;
		/// <summary>
		///
		/// </summary>
		private System.String m_XMTZ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_SDDJ;
		/// <summary>
		///
		/// </summary>
		private System.String m_GCLJSS	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_HL;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_GCL;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZJTJ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZHDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZHHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZJFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_RGFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_CLFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_JXFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZCFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_SBFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_GLFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_LRDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_FXDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_GFDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_SJDJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZJFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_RGFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_CLFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_JXFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZCFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_SBFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_GLFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_LRHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_FXHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_GFHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_SJHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_JCHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_CJHJ;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ZGJE;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_JGJE;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_SFFB;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_FBJE;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_JBHZ;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZJWZ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_JX;
		/// <summary>
		///
		/// </summary>
		private System.String m_YGLB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_SC;
		/// <summary>
		///
		/// </summary>
		private System.String m_QFSZ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_BEIZHU	=	string.Empty	;
        /// <summary>
        /// ������
        /// </summary>
        private System.String m_LibraryName = string.Empty;
        private System.String m_LY = string.Empty;
        private System.Boolean m_SDQD;
        //private _CRowTagObject m_Tag;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m__ID;
        /// <summary>
        ///
        /// </summary>
        private System.Int32 m__PARENID;

        /// <summary>
        /// ����Ļ�
        /// </summary>
        private System.String m_DECJ = string.Empty;
		#endregion

		#region----------------------���г�Ա����---------------------------------




        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:�����嵥
        /// </summary>
        public System.Boolean SDQD
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDQD, m_SDQD))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_SDQD = arg.GetFieldValue<System.Boolean>();
                    return this.m_SDQD;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_SDQD, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
                    this.m_SDQD = value;
                }
            }
        }





        /// <summary>
        ///��ȡ������
        ///��Ŷ���
        /// </summary>
        //public _CRowTagObject Tag
        //{
        //    get
        //    {
        //        using (CEventProperty arg = new CEventProperty(FILED_TAG, m_Tag))
        //        {
        //            this.OnPropertyGet(this, arg);
        //            if (arg.IsChangeValue)
        //                this.m_Tag = arg.GetFieldValue<_CRowTagObject>();
        //            return this.m_Tag;
        //        }
        //    }
        //    set
        //    {
        //        using (CEventProperty arg = new CEventProperty(FILED_TAG, value))
        //        {
        //            this.OnPropertyGet(this, arg);
        //            if (arg.IsChangeValue)
        //                value = arg.GetFieldValue<_CRowTagObject>();
        //            this.m_Tag = value;
        //        }
        //    }
        //}







		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:ID
		/// </summary>
		public System.Int32 ID
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ID,  m_ID))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ID = arg.GetFieldValue<System.Int32>();
					 return this.m_ID;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ID,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Int32>();
					this.m_ID= value;
				}
			}
		}


        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:QDPath
        /// </summary>
        public System.String LibraryName
        {
            get
            {
                return this.m_LibraryName;
            }
            set
            {
                this.m_LibraryName = value;
            }
        }


		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:PARENID
		/// </summary>
		public System.Int32 PARENID
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENID,  m_PARENID))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PARENID = arg.GetFieldValue<System.Int32>();
					 return this.m_PARENID;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENID,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Int32>();
					this.m_PARENID= value;
				}
			}
		}


        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:ID
        /// </summary>
        public System.Int32 _ID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED__ID, m__ID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m__ID = arg.GetFieldValue<System.Int32>();
                    return this.m__ID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED__ID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m__ID = value;
                }
            }
        }

        public System.Int32 _PARENID
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED__PARENID, m__PARENID))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m__PARENID = arg.GetFieldValue<System.Int32>();
                    return this.m__PARENID;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED__PARENID, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Int32>();
                    this.m__PARENID = value;
                }
            }
        }
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��   ��
		/// </summary>
		public System.Int32 XH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_XH,  m_XH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_XH = arg.GetFieldValue<System.Int32>();
					 return this.m_XH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_XH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Int32>();
					this.m_XH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��Ŀ����
		/// </summary>
		public System.String XMBM
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_XMBM,  m_XMBM))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_XMBM = arg.GetFieldValue<System.String>();
					 return this.m_XMBM;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_XMBM,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_XMBM= value;
				}
			}
		}
        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:��Ŀ����
        /// </summary>
        public System.String OLDXMBM
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_OLDXMBM, m_OLDXMBM))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_OLDXMBM = arg.GetFieldValue<System.String>();
                    return this.m_OLDXMBM;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_OLDXMBM, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_OLDXMBM = value;
                }
            }
        }
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��Ŀ����
		/// </summary>
		public System.String XMMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_XMMC,  m_XMMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_XMMC = arg.GetFieldValue<System.String>();
					 return this.m_XMMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_XMMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_XMMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��   λ
		/// </summary>
		public System.String DW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DW,  m_DW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DW = arg.GetFieldValue<System.String>();
					 return this.m_DW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DW= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��   ��
		/// </summary>
		public System.String TX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX,  m_TX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TX = arg.GetFieldValue<System.String>();
					 return this.m_TX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TX= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��   ��
		/// </summary>
		public System.String LB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LB,  m_LB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LB = arg.GetFieldValue<System.String>();
					 return this.m_LB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_LB= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�����
		/// </summary>
		public System.Boolean JCBJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JCBJ,  m_JCBJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
                        this.m_JCBJ = arg.GetFieldValue<System.Boolean>();
					 return this.m_JCBJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JCBJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
					this.m_JCBJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���˱��
		/// </summary>
		public System.Boolean FHBJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FHBJ,  m_FHBJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
                        this.m_FHBJ = arg.GetFieldValue<System.Boolean>();
					 return this.m_FHBJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FHBJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.Boolean>();
					this.m_FHBJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��Ҫ�嵥
		/// </summary>
		public System.Boolean ZYQD
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZYQD,  m_ZYQD))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZYQD = arg.GetFieldValue<System.Boolean>();
					 return this.m_ZYQD;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZYQD,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_ZYQD= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��Ŀ����
		/// </summary>
		public System.String XMTZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_XMTZ,  m_XMTZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_XMTZ = arg.GetFieldValue<System.String>();
					 return this.m_XMTZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_XMTZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_XMTZ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��������
		/// </summary>
		public System.Boolean SDDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SDDJ,  m_SDDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SDDJ = arg.GetFieldValue<System.Boolean>();
					 return this.m_SDDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SDDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_SDDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:����������ʽ
		/// </summary>
		public System.String GCLJSS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GCLJSS,  m_GCLJSS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GCLJSS = arg.GetFieldValue<System.String>();
					 return this.m_GCLJSS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GCLJSS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GCLJSS= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��   ��
		/// </summary>
		public System.Decimal HL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HL,  m_HL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HL = arg.GetFieldValue<System.Decimal>();
					 return this.m_HL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_HL= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:������
		/// </summary>
		public System.Decimal GCL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GCL,  m_GCL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GCL = arg.GetFieldValue<System.Decimal>();
					 return this.m_GCL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GCL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_GCL= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:ֱ�ӵ���
		/// </summary>
		public System.String ZJTJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJTJ,  m_ZJTJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZJTJ = arg.GetFieldValue<System.String>();
					 return this.m_ZJTJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJTJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZJTJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�ۺϵ���
		/// </summary>
		public System.Decimal ZHDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZHDJ,  m_ZHDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZHDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZHDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZHDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZHDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�ۺϺϼ�
		/// </summary>
		public System.Decimal ZHHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZHHJ,  m_ZHHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZHHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZHHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZHHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZHHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:ֱ�ӷѵ���
		/// </summary>
		public System.Decimal ZJFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJFDJ,  m_ZJFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZJFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZJFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZJFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�˹��ѵ���
		/// </summary>
		public System.Decimal RGFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_RGFDJ,  m_RGFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_RGFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_RGFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_RGFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_RGFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���Ϸѵ���
		/// </summary>
		public System.Decimal CLFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CLFDJ,  m_CLFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CLFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_CLFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CLFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_CLFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��е�ѵ���
		/// </summary>
		public System.Decimal JXFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JXFDJ,  m_JXFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JXFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_JXFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JXFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_JXFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���ķѵ���
		/// </summary>
		public System.Decimal ZCFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZCFDJ,  m_ZCFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZCFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZCFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZCFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZCFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�豸�ѵ���
		/// </summary>
		public System.Decimal SBFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SBFDJ,  m_SBFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SBFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_SBFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SBFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_SBFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:����ѵ���
		/// </summary>
		public System.Decimal GLFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLFDJ,  m_GLFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GLFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_GLFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_GLFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���󵥼�
		/// </summary>
		public System.Decimal LRDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRDJ,  m_LRDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LRDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_LRDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_LRDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���յ���
		/// </summary>
		public System.Decimal FXDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXDJ,  m_FXDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FXDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_FXDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_FXDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��ѵ���
		/// </summary>
		public System.Decimal GFDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GFDJ,  m_GFDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GFDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_GFDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GFDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_GFDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:˰�𵥼�
		/// </summary>
		public System.Decimal SJDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SJDJ,  m_SJDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SJDJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_SJDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SJDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_SJDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:ֱ�ӷѺϼ�
		/// </summary>
		public System.Decimal ZJFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJFHJ,  m_ZJFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZJFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZJFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZJFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�˹��Ѻϼ�
		/// </summary>
		public System.Decimal RGFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_RGFHJ,  m_RGFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_RGFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_RGFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_RGFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_RGFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���ϷѺϼ�
		/// </summary>
		public System.Decimal CLFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CLFHJ,  m_CLFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CLFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_CLFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CLFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_CLFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��е�Ѻϼ�
		/// </summary>
		public System.Decimal JXFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JXFHJ,  m_JXFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JXFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_JXFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JXFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_JXFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���ķѺϼ�
		/// </summary>
		public System.Decimal ZCFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZCFHJ,  m_ZCFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZCFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZCFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZCFHJ,  value))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZCFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�豸�Ѻϼ�
		/// </summary>
		public System.Decimal SBFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SBFHJ,  m_SBFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SBFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_SBFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SBFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_SBFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:����Ѻϼ�
		/// </summary>
		public System.Decimal GLFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLFHJ,  m_GLFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GLFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_GLFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_GLFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:����ϼ�
		/// </summary>
		public System.Decimal LRHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRHJ,  m_LRHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LRHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_LRHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_LRHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���պϼ�
		/// </summary>
		public System.Decimal FXHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXHJ,  m_FXHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FXHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_FXHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_FXHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��Ѻϼ�
		/// </summary>
		public System.Decimal GFHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GFHJ,  m_GFHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GFHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_GFHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GFHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_GFHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:˰��ϼ�
		/// </summary>
		public System.Decimal SJHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SJHJ,  m_SJHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SJHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_SJHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SJHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_SJHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�۲�ϼ�
		/// </summary>
		public System.Decimal JCHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JCHJ,  m_JCHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JCHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_JCHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JCHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_JCHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��ۺϼ�
		/// </summary>
		public System.Decimal CJHJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CJHJ,  m_CJHJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CJHJ = arg.GetFieldValue<System.Decimal>();
					 return this.m_CJHJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CJHJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_CJHJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�ݹ����
		/// </summary>
		public System.Decimal ZGJE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZGJE,  m_ZGJE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZGJE = arg.GetFieldValue<System.Decimal>();
					 return this.m_ZGJE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZGJE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ZGJE= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�׹����
		/// </summary>
		public System.Decimal JGJE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JGJE,  m_JGJE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JGJE = arg.GetFieldValue<System.Decimal>();
					 return this.m_JGJE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JGJE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_JGJE= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�Ƿ�ְ�
		/// </summary>
		public System.Boolean SFFB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SFFB,  m_SFFB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SFFB = arg.GetFieldValue<System.Boolean>();
					 return this.m_SFFB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SFFB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_SFFB= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�ְ����
		/// </summary>
		public System.Decimal FBJE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FBJE,  m_FBJE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FBJE = arg.GetFieldValue<System.Decimal>();
					 return this.m_FBJE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FBJE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_FBJE= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�ֲ�����
		/// </summary>
		public System.Boolean JBHZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JBHZ,  m_JBHZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JBHZ = arg.GetFieldValue<System.Boolean>();
					 return this.m_JBHZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JBHZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_JBHZ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�½�λ��
		/// </summary>
		public System.String ZJWZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJWZ,  m_ZJWZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZJWZ = arg.GetFieldValue<System.String>();
					 return this.m_ZJWZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZJWZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZJWZ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��Ч
		/// </summary>
		public System.Boolean JX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JX,  m_JX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JX = arg.GetFieldValue<System.Boolean>();
					 return this.m_JX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_JX= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:�ܸ����
		/// </summary>
		public System.String YGLB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_YGLB,  m_YGLB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_YGLB = arg.GetFieldValue<System.String>();
					 return this.m_YGLB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_YGLB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_YGLB= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:���
		/// </summary>
		public System.Boolean SC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SC,  m_SC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SC = arg.GetFieldValue<System.Boolean>();
					 return this.m_SC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_SC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:ȡ������
		/// </summary>
		public System.String QFSZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_QFSZ,  m_QFSZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_QFSZ = arg.GetFieldValue<System.String>();
					 return this.m_QFSZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_QFSZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_QFSZ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
        ///���ݿ��ֶ�����:��ע
		/// </summary>
		public System.String BEIZHU
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_BEIZHU,  m_BEIZHU))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_BEIZHU = arg.GetFieldValue<System.String>();
					 return this.m_BEIZHU;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_BEIZHU,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_BEIZHU= value;
				}
			}
		}


        /// <summary>
        ///��ȡ������
        ///���ݿ��ֶ�����:��ע
        /// </summary>
        public System.String LY
        {
            get
            {
                using (CEventProperty arg = new CEventProperty(FILED_LY, m_LY))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        this.m_LY = arg.GetFieldValue<System.String>();
                    return this.m_LY;
                }
            }
            set
            {
                using (CEventProperty arg = new CEventProperty(FILED_LY, value))
                {
                    this.OnPropertyGet(this, arg);
                    if (arg.IsChangeValue)
                        value = arg.GetFieldValue<System.String>();
                    this.m_LY = value;
                }
            }
        }

        /// <summary>
        /// ��ȡ�����õ�ǰ�Ķ���Ļ��ַ���
        /// </summary>
        public string DECJ
        {
            get
            {
                return this.m_DECJ;
            }
            set
            {
                this.m_DECJ = value;
            }
        }
		#endregion


	}
}
