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
		///�����ҵ��ʵ����
		/// </summary>
	public class CEntity����� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "�����";
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGESYBH	=  "DINGESYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TX1	=  "TX1" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TX2	=  "TX2" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TX3	=  "TX3" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEH	=  "DINGEH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEMC	=  "DINGEMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEDW	=  "DINGEDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEJJ	=  "DINGEJJ" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_RENGF	=  "RENGF" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAILF	=  "CAILF" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JIXF	=  "JIXF" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JIANGX	=  "JIANGX" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGESX	=  "DINGESX" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGESM	=  "DINGESM" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DECJ	=  "DECJ" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGESYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TX1	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TX2	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TX3	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEJJ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_RENGF	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAILF	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JIXF	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JIANGX	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGESX	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGESM	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DECJ	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DINGESYBH
		/// </summary>
		public System.String DINGESYBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGESYBH,  m_DINGESYBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGESYBH = arg.GetFieldValue<System.String>();
					 return this.m_DINGESYBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGESYBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGESYBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TX1
		/// </summary>
		public System.String TX1
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX1,  m_TX1))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TX1 = arg.GetFieldValue<System.String>();
					 return this.m_TX1;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX1,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TX1= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TX2
		/// </summary>
		public System.String TX2
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX2,  m_TX2))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TX2 = arg.GetFieldValue<System.String>();
					 return this.m_TX2;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX2,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TX2= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TX3
		/// </summary>
		public System.String TX3
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX3,  m_TX3))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TX3 = arg.GetFieldValue<System.String>();
					 return this.m_TX3;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX3,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TX3= value;
				}
			}
		}
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
		///���ݿ��ֶ�����:DINGEMC
		/// </summary>
		public System.String DINGEMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEMC,  m_DINGEMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGEMC = arg.GetFieldValue<System.String>();
					 return this.m_DINGEMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGEMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DINGEDW
		/// </summary>
		public System.String DINGEDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEDW,  m_DINGEDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGEDW = arg.GetFieldValue<System.String>();
					 return this.m_DINGEDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGEDW= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DINGEJJ
		/// </summary>
		public System.String DINGEJJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEJJ,  m_DINGEJJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGEJJ = arg.GetFieldValue<System.String>();
					 return this.m_DINGEJJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEJJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGEJJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:RENGF
		/// </summary>
		public System.String RENGF
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_RENGF,  m_RENGF))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_RENGF = arg.GetFieldValue<System.String>();
					 return this.m_RENGF;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_RENGF,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_RENGF= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAILF
		/// </summary>
		public System.String CAILF
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAILF,  m_CAILF))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAILF = arg.GetFieldValue<System.String>();
					 return this.m_CAILF;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAILF,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAILF= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:JIXF
		/// </summary>
		public System.String JIXF
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JIXF,  m_JIXF))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JIXF = arg.GetFieldValue<System.String>();
					 return this.m_JIXF;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JIXF,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JIXF= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:JIANGX
		/// </summary>
		public System.String JIANGX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JIANGX,  m_JIANGX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JIANGX = arg.GetFieldValue<System.String>();
					 return this.m_JIANGX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JIANGX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JIANGX= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DINGESX
		/// </summary>
		public System.String DINGESX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGESX,  m_DINGESX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGESX = arg.GetFieldValue<System.String>();
					 return this.m_DINGESX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGESX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGESX= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DINGESM
		/// </summary>
		public System.String DINGESM
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGESM,  m_DINGESM))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGESM = arg.GetFieldValue<System.String>();
					 return this.m_DINGESM;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGESM,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGESM= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DECJ
		/// </summary>
		public System.String DECJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DECJ,  m_DECJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DECJ = arg.GetFieldValue<System.String>();
					 return this.m_DECJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DECJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DECJ= value;
				}
			}
		}
		#endregion


	}
}
