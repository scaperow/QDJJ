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
		///�������Ա�ҵ��ʵ����
		/// </summary>
	public class CEntity�������Ա� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "�������Ա�";
		/// <summary>
		///
		/// </summary>
		public const string FILED_DESX	=  "DESX" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_DESX	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:DESX
		/// </summary>
		public System.String DESX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DESX,  m_DESX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DESX = arg.GetFieldValue<System.String>();
					 return this.m_DESX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DESX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DESX= value;
				}
			}
		}
		#endregion


	}
}
