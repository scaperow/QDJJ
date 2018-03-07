/****************************************************
*紫柏软件代码生成实体类
*生成日期:2011年43月08日　05时11分29秒
*备注:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS
{
		/// <summary>
		///FIXEDINCREASED业务实体类
		/// </summary>
	public class CEntityFixedIncreased :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "FIXEDINCREASED";
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
		public const string FILED_NAME	=  "Name" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ISCHECK	=  "IsCheck" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CODE	=  "Code" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_LOCATION	=  "location" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GROUP	=  "Group" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FIXED	=  "Fixed" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_CALCULATION	=  "Calculation" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ADDITIONAL	=  "Additional" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_COEFFICIENT	=  "Coefficient" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ARTIFICIAL	=  "Artificial" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MATERIAL	=  "Material" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MECHANICAL	=  "Mechanical" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_EXPERTISE	=  "Expertise" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_REMARK	=  "Remark" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
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
		private System.String m_NAME	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Boolean m_ISCHECK;
		/// <summary>
		///
		/// </summary>
		private System.String m_CODE	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_LOCATION	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GROUP	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FIXED	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_CALCULATION	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ADDITIONAL;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_COEFFICIENT;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_ARTIFICIAL;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_MATERIAL;
		/// <summary>
		///
		/// </summary>
		private System.Decimal m_MECHANICAL;
		/// <summary>
		///
		/// </summary>
		private System.String m_EXPERTISE	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_REMARK	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:ID
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
		///获取或设置
		///数据库字段名称:PARENTID
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
		///获取或设置
		///数据库字段名称:NAME
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
		///获取或设置
		///数据库字段名称:ISCHECK
		/// </summary>
		public System.Boolean ISCHECK
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ISCHECK,  m_ISCHECK))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ISCHECK = arg.GetFieldValue<System.Boolean>();
					 return this.m_ISCHECK;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ISCHECK,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Boolean>();
					this.m_ISCHECK= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:CODE
		/// </summary>
		public System.String CODE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CODE,  m_CODE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CODE = arg.GetFieldValue<System.String>();
					 return this.m_CODE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CODE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CODE= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:LOCATION
		/// </summary>
		public System.String LOCATION
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LOCATION,  m_LOCATION))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LOCATION = arg.GetFieldValue<System.String>();
					 return this.m_LOCATION;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LOCATION,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_LOCATION= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:GROUP
		/// </summary>
		public System.String GROUP
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GROUP,  m_GROUP))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GROUP = arg.GetFieldValue<System.String>();
					 return this.m_GROUP;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GROUP,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GROUP= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:FIXED
		/// </summary>
		public System.String FIXED
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FIXED,  m_FIXED))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FIXED = arg.GetFieldValue<System.String>();
					 return this.m_FIXED;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FIXED,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FIXED= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:CALCULATION
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
		///获取或设置
		///数据库字段名称:ADDITIONAL
		/// </summary>
		public System.Decimal ADDITIONAL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ADDITIONAL,  m_ADDITIONAL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ADDITIONAL = arg.GetFieldValue<System.Decimal>();
					 return this.m_ADDITIONAL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ADDITIONAL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ADDITIONAL= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:COEFFICIENT
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
		///获取或设置
		///数据库字段名称:ARTIFICIAL
		/// </summary>
		public System.Decimal ARTIFICIAL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ARTIFICIAL,  m_ARTIFICIAL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ARTIFICIAL = arg.GetFieldValue<System.Decimal>();
					 return this.m_ARTIFICIAL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ARTIFICIAL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_ARTIFICIAL= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:MATERIAL
		/// </summary>
		public System.Decimal MATERIAL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MATERIAL,  m_MATERIAL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MATERIAL = arg.GetFieldValue<System.Decimal>();
					 return this.m_MATERIAL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MATERIAL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_MATERIAL= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:MECHANICAL
		/// </summary>
		public System.Decimal MECHANICAL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MECHANICAL,  m_MECHANICAL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MECHANICAL = arg.GetFieldValue<System.Decimal>();
					 return this.m_MECHANICAL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MECHANICAL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.Decimal>();
					this.m_MECHANICAL= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:EXPERTISE
		/// </summary>
		public System.String EXPERTISE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_EXPERTISE,  m_EXPERTISE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_EXPERTISE = arg.GetFieldValue<System.String>();
					 return this.m_EXPERTISE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_EXPERTISE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_EXPERTISE= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:REMARK
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
