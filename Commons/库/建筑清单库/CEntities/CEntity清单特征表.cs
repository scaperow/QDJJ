/****************************************************
*�ϰ������������ʵ����
*��������:2011��33��15�ա�11ʱ06��47��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
		/// <summary>
		///�嵥������ҵ��ʵ����
		/// </summary>
    public class CEntity�嵥������ : CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "�嵥������";
		/// <summary>
		///
		/// </summary>
		public const string FILED_QINGDBH	=  "QINGDBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TEZBH	=  "TEZBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TEZMC	=  "TEZMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TEZDW	=  "TEZDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TEZZ	=  "TEZZ" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_QINGDBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TEZBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TEZMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TEZDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TEZZ	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:QINGDBH
		/// </summary>
		public System.String QINGDBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDBH,  m_QINGDBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_QINGDBH = arg.GetFieldValue<System.String>();
					 return this.m_QINGDBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_QINGDBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TEZBH
		/// </summary>
		public System.String TEZBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZBH,  m_TEZBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TEZBH = arg.GetFieldValue<System.String>();
					 return this.m_TEZBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TEZBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TEZMC
		/// </summary>
		public System.String TEZMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZMC,  m_TEZMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TEZMC = arg.GetFieldValue<System.String>();
					 return this.m_TEZMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TEZMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TEZDW
		/// </summary>
		public System.String TEZDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZDW,  m_TEZDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TEZDW = arg.GetFieldValue<System.String>();
					 return this.m_TEZDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TEZDW= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TEZZ
		/// </summary>
		public System.String TEZZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZZ,  m_TEZZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TEZZ = arg.GetFieldValue<System.String>();
					 return this.m_TEZZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TEZZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TEZZ= value;
				}
			}
		}
    }
}
		#endregion


