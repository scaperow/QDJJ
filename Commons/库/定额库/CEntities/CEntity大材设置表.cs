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
		///������ñ�ҵ��ʵ����
		/// </summary>
	public class CEntity������ñ� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "������ñ�";
		/// <summary>
		///
		/// </summary>
		public const string FILED_SANDCMC	=  "SANDCMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_HUIZDW	=  "HUIZDW" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_SANDCMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_HUIZDW	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
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
		///���ݿ��ֶ�����:HUIZDW
		/// </summary>
		public System.String HUIZDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUIZDW,  m_HUIZDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HUIZDW = arg.GetFieldValue<System.String>();
					 return this.m_HUIZDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUIZDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_HUIZDW= value;
				}
			}
		}
		#endregion


	}
}
