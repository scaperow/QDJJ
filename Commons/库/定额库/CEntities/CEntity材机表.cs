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
		///�Ļ���ҵ��ʵ����
		/// </summary>
	public class CEntity�Ļ��� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "�Ļ���";
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJBH	=  "CAIJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJSYBH	=  "CAIJSYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJMC	=  "CAIJMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJDW	=  "CAIJDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJDJ	=  "CAIJDJ" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJLB	=  "CAIJLB" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJSC	=  "CAIJSC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJJC	=  "CAIJJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJXSJG	=  "CAIJXSJG" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_SANDCMC	=  "SANDCMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_SANDCXS	=  "SANDCXS" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJSYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJDJ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJLB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJSC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJXSJG	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_SANDCMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_SANDCXS	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJBH
		/// </summary>
		public System.String CAIJBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJBH,  m_CAIJBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJBH = arg.GetFieldValue<System.String>();
					 return this.m_CAIJBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJSYBH
		/// </summary>
		public System.String CAIJSYBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJSYBH,  m_CAIJSYBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJSYBH = arg.GetFieldValue<System.String>();
					 return this.m_CAIJSYBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJSYBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJSYBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJMC
		/// </summary>
		public System.String CAIJMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJMC,  m_CAIJMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJMC = arg.GetFieldValue<System.String>();
					 return this.m_CAIJMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJDW
		/// </summary>
		public System.String CAIJDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJDW,  m_CAIJDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJDW = arg.GetFieldValue<System.String>();
					 return this.m_CAIJDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJDW= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJDJ
		/// </summary>
		public System.String CAIJDJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJDJ,  m_CAIJDJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJDJ = arg.GetFieldValue<System.String>();
					 return this.m_CAIJDJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJDJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJDJ= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJLB
		/// </summary>
		public System.String CAIJLB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJLB,  m_CAIJLB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJLB = arg.GetFieldValue<System.String>();
					 return this.m_CAIJLB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJLB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJLB= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJSC
		/// </summary>
		public System.String CAIJSC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJSC,  m_CAIJSC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJSC = arg.GetFieldValue<System.String>();
					 return this.m_CAIJSC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJSC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJSC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJJC
		/// </summary>
		public System.String CAIJJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJJC,  m_CAIJJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJJC = arg.GetFieldValue<System.String>();
					 return this.m_CAIJJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJJC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CAIJXSJG
		/// </summary>
		public System.String CAIJXSJG
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJXSJG,  m_CAIJXSJG))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJXSJG = arg.GetFieldValue<System.String>();
					 return this.m_CAIJXSJG;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJXSJG,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJXSJG= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:SANDCMC
		/// </summary>
		public System.String SANDCMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SANDCMC,  m_SANDCMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SANDCMC = arg.GetFieldValue<System.String>();
					 return this.m_SANDCMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SANDCMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SANDCMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:SANDCXS
		/// </summary>
		public System.String SANDCXS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SANDCXS,  m_SANDCXS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SANDCXS = arg.GetFieldValue<System.String>();
					 return this.m_SANDCXS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SANDCXS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SANDCXS= value;
				}
			}
		}
		#endregion


	}
}
