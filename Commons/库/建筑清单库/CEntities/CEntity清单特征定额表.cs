/****************************************************
*紫柏软件代码生成实体类
*生成日期:2011年33月15日　11时06分47秒
*备注:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;


namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
		/// <summary>
		///清单特征定额表业务实体类
		/// </summary>
    public class CEntity清单特征定额表 : CEntity
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "清单特征定额表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_TZBH	=  "TZBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TZZ	=  "TZZ" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TZDEH	=  "TZDEH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DEMC	=  "DEMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DEDW	=  "DEDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_XS	=  "XS" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DECJ	=  "DECJ" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_TZBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TZZ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TZDEH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DEMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DEDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_XS	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DECJ	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:TZBH
		/// </summary>
		public System.String TZBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TZBH,  m_TZBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TZBH = arg.GetFieldValue<System.String>();
					 return this.m_TZBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TZBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TZBH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TZZ
		/// </summary>
		public System.String TZZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TZZ,  m_TZZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TZZ = arg.GetFieldValue<System.String>();
					 return this.m_TZZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TZZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TZZ= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TZDEH
		/// </summary>
		public System.String TZDEH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TZDEH,  m_TZDEH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TZDEH = arg.GetFieldValue<System.String>();
					 return this.m_TZDEH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TZDEH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TZDEH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:DEMC
		/// </summary>
		public System.String DEMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEMC,  m_DEMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DEMC = arg.GetFieldValue<System.String>();
					 return this.m_DEMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DEMC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:DEDW
		/// </summary>
		public System.String DEDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEDW,  m_DEDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DEDW = arg.GetFieldValue<System.String>();
					 return this.m_DEDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DEDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DEDW= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:XS
		/// </summary>
		public System.String XS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_XS,  m_XS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_XS = arg.GetFieldValue<System.String>();
					 return this.m_XS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_XS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_XS= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:DECJ
		/// </summary>
		public System.String DECJ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DECJ,  m_DECJ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DECJ = arg.GetFieldValue<System.String>();
					 return this.m_DECJ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DECJ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DECJ= value;
				}
			}
		}
    }
}
		#endregion


