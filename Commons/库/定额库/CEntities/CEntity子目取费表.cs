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
		///��Ŀȡ�ѱ�ҵ��ʵ����
		/// </summary>
	public class CEntity��Ŀȡ�ѱ� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "��Ŀȡ�ѱ�";
		/// <summary>
		///
		/// </summary>
		public const string FILED_YYH	=  "YYH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MC	=  "MC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_BDS	=  "BDS" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TBJSJC	=  "TBJSJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_BDJSJC	=  "BDJSJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FL	=  "FL" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JE	=  "JE" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_BEIZHU	=  "BEIZHU" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_YYH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_MC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_BDS	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TBJSJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_BDJSJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FL	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JE	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_BEIZHU	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:YYH
		/// </summary>
		public System.String YYH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_YYH,  m_YYH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_YYH = arg.GetFieldValue<System.String>();
					 return this.m_YYH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_YYH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_YYH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:MC
		/// </summary>
		public System.String MC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MC,  m_MC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MC = arg.GetFieldValue<System.String>();
					 return this.m_MC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_MC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:BDS
		/// </summary>
		public System.String BDS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_BDS,  m_BDS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_BDS = arg.GetFieldValue<System.String>();
					 return this.m_BDS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_BDS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_BDS= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TBJSJC
		/// </summary>
		public System.String TBJSJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TBJSJC,  m_TBJSJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TBJSJC = arg.GetFieldValue<System.String>();
					 return this.m_TBJSJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TBJSJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TBJSJC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:BDJSJC
		/// </summary>
		public System.String BDJSJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_BDJSJC,  m_BDJSJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_BDJSJC = arg.GetFieldValue<System.String>();
					 return this.m_BDJSJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_BDJSJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_BDJSJC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:FL
		/// </summary>
		public System.String FL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FL,  m_FL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FL = arg.GetFieldValue<System.String>();
					 return this.m_FL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FL= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:JE
		/// </summary>
		public System.String JE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JE,  m_JE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JE = arg.GetFieldValue<System.String>();
					 return this.m_JE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JE= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:BEIZHU
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
		#endregion


	}
}
