/****************************************************
*紫柏软件代码生成实体类
*生成日期:2011年14月16日　04时06分27秒
*备注:
****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;



namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
		/// <summary>
		///图集做法定额表业务实体类
		/// </summary>
	public class CEntity图集做法定额表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "图集做法定额表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZFBH	=  "ZFBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZFDEH	=  "ZFDEH" ;
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
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJH	=  "TJH" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_ZFBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZFDEH	=	string.Empty	;
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
		/// <summary>
		///
		/// </summary>
		private System.String m_TJH	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:ZFBH
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
		///获取或设置
		///数据库字段名称:ZFDEH
		/// </summary>
		public System.String ZFDEH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFDEH,  m_ZFDEH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZFDEH = arg.GetFieldValue<System.String>();
					 return this.m_ZFDEH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFDEH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZFDEH= value;
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
		/// <summary>
		///获取或设置
		///数据库字段名称:TJH
		/// </summary>
		public System.String TJH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJH,  m_TJH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TJH = arg.GetFieldValue<System.String>();
					 return this.m_TJH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TJH= value;
				}
			}
		}
		#endregion


	}
}
