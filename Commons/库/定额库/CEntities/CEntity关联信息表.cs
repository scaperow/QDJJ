/****************************************************
*�ϰ������������ʵ����
*��������:2011��13��16�ա�04ʱ06��23��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
		/// <summary>
		///������Ϣ��ҵ��ʵ����
		/// </summary>
	public class CEntity������Ϣ�� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "������Ϣ��";
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEH	=  "DINGEH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GLDEH	=  "GLDEH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DEMC	=  "DEMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DEDW	=  "DEDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GLDHSX	=  "GLDHSX" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GCLXS	=  "GCLXS" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TISXX	=  "TISXX" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JISJS	=  "JISJS" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GLDEH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DEMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DEDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GLDHSX	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GCLXS	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TISXX	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JISJS	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DINGEH
		/// </summary>
		public System.String DINGEH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEH,  m_DINGEH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGEH = arg.GetFieldValue<System.String>();
					 return this.m_DINGEH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGEH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:GLDEH
		/// </summary>
		public System.String GLDEH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLDEH,  m_GLDEH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GLDEH = arg.GetFieldValue<System.String>();
					 return this.m_GLDEH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLDEH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GLDEH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DEMC
		/// </summary>
		public System.String DEMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEMC,  m_DEMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DEMC = arg.GetFieldValue<System.String>();
					 return this.m_DEMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DEMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DEDW
		/// </summary>
		public System.String DEDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEDW,  m_DEDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DEDW = arg.GetFieldValue<System.String>();
					 return this.m_DEDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DEDW= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:GLDHSX
		/// </summary>
		public System.String GLDHSX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLDHSX,  m_GLDHSX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GLDHSX = arg.GetFieldValue<System.String>();
					 return this.m_GLDHSX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLDHSX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GLDHSX= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:GCLXS
		/// </summary>
		public System.String GCLXS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GCLXS,  m_GCLXS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GCLXS = arg.GetFieldValue<System.String>();
					 return this.m_GCLXS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GCLXS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GCLXS= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TISXX
		/// </summary>
		public System.String TISXX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TISXX,  m_TISXX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TISXX = arg.GetFieldValue<System.String>();
					 return this.m_TISXX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TISXX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TISXX= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:JISJS
		/// </summary>
		public System.String JISJS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JISJS,  m_JISJS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JISJS = arg.GetFieldValue<System.String>();
					 return this.m_JISJS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JISJS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JISJS= value;
				}
			}
		}
		#endregion


	}
}
