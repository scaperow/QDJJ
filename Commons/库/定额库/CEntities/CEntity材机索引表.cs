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
		///�Ļ�������ҵ��ʵ����
		/// </summary>
	public class CEntity�Ļ������� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "�Ļ�������";
		/// <summary>
		///
		/// </summary>
		public const string FILED_PARENTID	=  "PARENTID" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJSYBH	=  "CAIJSYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MULNR	=  "MULNR" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_PARENTID	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJSYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_MULNR	=	string.Empty	;
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
		///���ݿ��ֶ�����:MULNR
		/// </summary>
		public System.String MULNR
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MULNR,  m_MULNR))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MULNR = arg.GetFieldValue<System.String>();
					 return this.m_MULNR;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MULNR,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_MULNR= value;
				}
			}
		}
		#endregion


	}
}
