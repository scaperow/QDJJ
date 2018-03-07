/****************************************************
*紫柏软件代码生成实体类
*生成日期:2011年13月16日　04时06分23秒
*备注:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
		/// <summary>
		///取费表业务实体类
		/// </summary>
	public class CEntity取费表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "取费表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_GONGCLB	=  "GONGCLB" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEH	=  "DINGEH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GUANLFL	=  "GUANLFL" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_LIRL	=  "LIRL" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FXLBD	=  "FXLBD" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FXLTB	=  "FXLTB" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GLBDJC	=  "GLBDJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_GLTBJC	=  "GLTBJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_LRBDJC	=  "LRBDJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_LRTBJC	=  "LRTBJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FXBDJC	=  "FXBDJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FXTBJC	=  "FXTBJC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_SFHH	=  "SFHH" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_GONGCLB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GUANLFL	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_LIRL	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FXLBD	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FXLTB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GLBDJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_GLTBJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_LRBDJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_LRTBJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FXBDJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FXTBJC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_SFHH	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:GONGCLB
		/// </summary>
		public System.String GONGCLB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GONGCLB,  m_GONGCLB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GONGCLB = arg.GetFieldValue<System.String>();
					 return this.m_GONGCLB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GONGCLB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GONGCLB= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:DINGEH
		/// </summary>
		public System.String DINGEH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEH,  m_DINGEH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DINGEH = arg.GetFieldValue<System.String>();
					 return this.m_DINGEH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DINGEH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DINGEH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:GUANLFL
		/// </summary>
		public System.String GUANLFL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GUANLFL,  m_GUANLFL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GUANLFL = arg.GetFieldValue<System.String>();
					 return this.m_GUANLFL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GUANLFL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GUANLFL= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:LIRL
		/// </summary>
		public System.String LIRL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LIRL,  m_LIRL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LIRL = arg.GetFieldValue<System.String>();
					 return this.m_LIRL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LIRL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_LIRL= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:FXLBD
		/// </summary>
		public System.String FXLBD
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXLBD,  m_FXLBD))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FXLBD = arg.GetFieldValue<System.String>();
					 return this.m_FXLBD;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXLBD,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FXLBD= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:FXLTB
		/// </summary>
		public System.String FXLTB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXLTB,  m_FXLTB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FXLTB = arg.GetFieldValue<System.String>();
					 return this.m_FXLTB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXLTB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FXLTB= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:GLBDJC
		/// </summary>
		public System.String GLBDJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLBDJC,  m_GLBDJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GLBDJC = arg.GetFieldValue<System.String>();
					 return this.m_GLBDJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLBDJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GLBDJC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:GLTBJC
		/// </summary>
		public System.String GLTBJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLTBJC,  m_GLTBJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_GLTBJC = arg.GetFieldValue<System.String>();
					 return this.m_GLTBJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_GLTBJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_GLTBJC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:LRBDJC
		/// </summary>
		public System.String LRBDJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRBDJC,  m_LRBDJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LRBDJC = arg.GetFieldValue<System.String>();
					 return this.m_LRBDJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRBDJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_LRBDJC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:LRTBJC
		/// </summary>
		public System.String LRTBJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRTBJC,  m_LRTBJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_LRTBJC = arg.GetFieldValue<System.String>();
					 return this.m_LRTBJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_LRTBJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_LRTBJC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:FXBDJC
		/// </summary>
		public System.String FXBDJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXBDJC,  m_FXBDJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FXBDJC = arg.GetFieldValue<System.String>();
					 return this.m_FXBDJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXBDJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FXBDJC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:FXTBJC
		/// </summary>
		public System.String FXTBJC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXTBJC,  m_FXTBJC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FXTBJC = arg.GetFieldValue<System.String>();
					 return this.m_FXTBJC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FXTBJC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FXTBJC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:SFHH
		/// </summary>
		public System.String SFHH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SFHH,  m_SFHH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SFHH = arg.GetFieldValue<System.String>();
					 return this.m_SFHH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SFHH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SFHH= value;
				}
			}
		}
		#endregion


	}
}
