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
		///����ϵ����ҵ��ʵ����
		/// </summary>
	public class CEntity����ϵ���� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "����ϵ����";
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJBH	=  "CAIJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JMXS	=  "JMXS" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JMXS	=	string.Empty	;
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
		///���ݿ��ֶ�����:JMXS
		/// </summary>
		public System.String JMXS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JMXS,  m_JMXS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JMXS = arg.GetFieldValue<System.String>();
					 return this.m_JMXS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JMXS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JMXS= value;
				}
			}
		}
		#endregion


	}
}
