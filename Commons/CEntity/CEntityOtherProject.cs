/****************************************************
*�ϰ������������ʵ����
*��������:2011��43��08�ա�05ʱ11��29��
*��ע:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS
{
		/// <summary>
		///OTHERPROJECTҵ��ʵ����
		/// </summary>
	public class CEntityOtherProject :	CEntity 
	{
		#region----------------------�ֶγ�������---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "OTHERPROJECT";
		/// <summary>
		///
		/// </summary>
		public const string FILED_ID	=  "ID" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_PARENTID	=  "ParentID" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_NUMBER	=  "Number" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_NAME	=  "Name" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_UNIT	=  "Unit" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_QUANTITIES	=  "Quantities" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CALCULATION	=  "Calculation" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_COEFFICIENT	=  "Coefficient" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_UNITPRICE	=  "Unitprice" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_COMBINEDPRICE	=  "Combinedprice" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_REMARK	=  "Remark" ;
		#endregion

		#region----------------------˽�г�Ա����---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.Int32 m_ID;
		/// <summary>
		///
		/// </summary>
		private System.Int32 m_PARENTID;
		/// <summary>
		///
		/// </summary>
		private System.String m_NUMBER	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_NAME	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_UNIT	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_QUANTITIES;
		/// <summary>
		///
		/// </summary>
		private System.String m_CALCULATION	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_COEFFICIENT;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_UNITPRICE;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_COMBINEDPRICE;
		/// <summary>
		///
		/// </summary>
		private System.String m_REMARK	=	string.Empty	;
		#endregion

		#region----------------------���г�Ա����---------------------------------
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:ID
		/// </summary>
		public System.Int32 ID
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ID,  m_ID))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ID = arg.GetFieldValue<System.Int32>();
					 return this.m_ID;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ID,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Int32>();
					this.m_ID= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:PARENTID
		/// </summary>
		public System.Int32 PARENTID
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENTID,  m_PARENTID))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PARENTID = arg.GetFieldValue<System.Int32>();
					 return this.m_PARENTID;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENTID,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Int32>();
					this.m_PARENTID= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:NUMBER
		/// </summary>
		public System.String NUMBER
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_NUMBER,  m_NUMBER))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_NUMBER = arg.GetFieldValue<System.String>();
					 return this.m_NUMBER;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_NUMBER,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_NUMBER= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:NAME
		/// </summary>
		public System.String NAME
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_NAME,  m_NAME))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_NAME = arg.GetFieldValue<System.String>();
					 return this.m_NAME;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_NAME,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_NAME= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:UNIT
		/// </summary>
		public System.String UNIT
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_UNIT,  m_UNIT))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_UNIT = arg.GetFieldValue<System.String>();
					 return this.m_UNIT;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_UNIT,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_UNIT= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:QUANTITIES
		/// </summary>
		public System.Decimal QUANTITIES
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_QUANTITIES,  m_QUANTITIES))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_QUANTITIES = arg.GetFieldValue<System.Decimal>();
					 return this.m_QUANTITIES;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_QUANTITIES,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_QUANTITIES= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:CALCULATION
		/// </summary>
		public System.String CALCULATION
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CALCULATION,  m_CALCULATION))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CALCULATION = arg.GetFieldValue<System.String>();
					 return this.m_CALCULATION;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CALCULATION,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CALCULATION= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:COEFFICIENT
		/// </summary>
		public System.Decimal COEFFICIENT
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_COEFFICIENT,  m_COEFFICIENT))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_COEFFICIENT = arg.GetFieldValue<System.Decimal>();
					 return this.m_COEFFICIENT;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_COEFFICIENT,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_COEFFICIENT= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:UNITPRICE
		/// </summary>
		public System.Decimal UNITPRICE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_UNITPRICE,  m_UNITPRICE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_UNITPRICE = arg.GetFieldValue<System.Decimal>();
					 return this.m_UNITPRICE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_UNITPRICE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_UNITPRICE= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:COMBINEDPRICE
		/// </summary>
		public System.Decimal COMBINEDPRICE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_COMBINEDPRICE,  m_COMBINEDPRICE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_COMBINEDPRICE = arg.GetFieldValue<System.Decimal>();
					 return this.m_COMBINEDPRICE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_COMBINEDPRICE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_COMBINEDPRICE= value;
				}
			}
		}
		/// <summary>
		///��ȡ������
		///���ݿ��ֶ�����:REMARK
		/// </summary>
		public System.String REMARK
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_REMARK,  m_REMARK))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_REMARK = arg.GetFieldValue<System.String>();
					 return this.m_REMARK;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_REMARK,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_REMARK= value;
				}
			}
		}
		#endregion


	}
}
