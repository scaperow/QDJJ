/****************************************************
*�ϰ������������ʵ����
*��������:2011��14��16�ա�04ʱ06��27��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
		/// <summary>
		///ͼ��������ҵ��ʵ����
		/// </summary>
	public class CEntityͼ�������� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "ͼ��������";
		/// <summary>
		///
		/// </summary>
		public const string FILED_PARENTID	=  "PARENTID" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_SYBH	=  "SYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MUNR	=  "MUNR" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_PARENTID	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_SYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_MUNR	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:PARENTID
		/// </summary>
		public System.String PARENTID
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENTID,  m_PARENTID))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PARENTID = arg.GetFieldValue<System.String>();
					 return this.m_PARENTID;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENTID,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_PARENTID= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:SYBH
		/// </summary>
		public System.String SYBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SYBH,  m_SYBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SYBH = arg.GetFieldValue<System.String>();
					 return this.m_SYBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SYBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SYBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:MUNR
		/// </summary>
		public System.String MUNR
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MUNR,  m_MUNR))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MUNR = arg.GetFieldValue<System.String>();
					 return this.m_MUNR;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MUNR,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_MUNR= value;
				}
			}
		}
		#endregion


	}
}
