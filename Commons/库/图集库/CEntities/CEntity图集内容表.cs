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
		///ͼ�����ݱ�ҵ��ʵ����
		/// </summary>
	public class CEntityͼ�����ݱ� :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "ͼ�����ݱ�";
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJBH	=  "TJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZFBH	=  "ZFBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZFMC	=  "ZFMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJDE	=  "TJDE" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_TJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZFBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZFMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TJDE	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TJBH
		/// </summary>
		public System.String TJBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJBH,  m_TJBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TJBH = arg.GetFieldValue<System.String>();
					 return this.m_TJBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TJBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:ZFBH
		/// </summary>
		public System.String ZFBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFBH,  m_ZFBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZFBH = arg.GetFieldValue<System.String>();
					 return this.m_ZFBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZFBH= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:ZFMC
		/// </summary>
		public System.String ZFMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFMC,  m_ZFMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZFMC = arg.GetFieldValue<System.String>();
					 return this.m_ZFMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZFMC= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:TJDE
		/// </summary>
		public System.String TJDE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJDE,  m_TJDE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TJDE = arg.GetFieldValue<System.String>();
					 return this.m_TJDE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJDE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TJDE= value;
				}
			}
		}
		#endregion


	}
}
