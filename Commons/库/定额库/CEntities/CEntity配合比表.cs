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
		///��ϱȱ�ҵ��ʵ����
		/// </summary>
	public class CEntity��ϱȱ� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "��ϱȱ�";
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJBH	=  "CAIJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_PHB_CJBH	=  "PHB_CJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_PHB_CJSL	=  "PHB_CJSL" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_PHB_CJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_PHB_CJSL	=	string.Empty	;
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
		///���ݿ��ֶ�����:PHB_CJBH
		/// </summary>
		public System.String PHB_CJBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJBH,  m_PHB_CJBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PHB_CJBH = arg.GetFieldValue<System.String>();
					 return this.m_PHB_CJBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_PHB_CJBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:PHB_CJSL
		/// </summary>
		public System.String PHB_CJSL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJSL,  m_PHB_CJSL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PHB_CJSL = arg.GetFieldValue<System.String>();
					 return this.m_PHB_CJSL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJSL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_PHB_CJSL= value;
				}
			}
		}
		#endregion


	}
}
