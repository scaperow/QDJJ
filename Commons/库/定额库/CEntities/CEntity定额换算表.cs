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
		///定额换算表业务实体类
		/// </summary>
	public class CEntity定额换算表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "定额换算表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_DINGEH	=  "DINGEH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_HUANSLB	=  "HUANSLB" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TISXX	=  "TISXX" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_HUANSJS_R	=  "HUANSJS_R" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_HUANSDEH_C	=  "HUANSDEH_C" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZENGL_J	=  "ZENGL_J" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZC	=  "ZC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_SB	=  "SB" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DJDW	=  "DJDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_FZ	=  "FZ" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_XHLB	=  "XHLB" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_THZHC	=  "THZHC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_THWZFC	=  "THWZFC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_HSXI	=  "HSXI" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_DINGEH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_HUANSLB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TISXX	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_HUANSJS_R	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_HUANSDEH_C	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZENGL_J	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_SB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DJDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_FZ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_XHLB	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_THZHC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_THWZFC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_HSXI	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
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
		///数据库字段名称:HUANSLB
		/// </summary>
		public System.String HUANSLB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUANSLB,  m_HUANSLB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HUANSLB = arg.GetFieldValue<System.String>();
					 return this.m_HUANSLB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUANSLB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_HUANSLB= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TISXX
		/// </summary>
		public System.String TISXX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TISXX,  m_TISXX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TISXX = arg.GetFieldValue<System.String>();
					 return this.m_TISXX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TISXX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TISXX= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:HUANSJS_R
		/// </summary>
		public System.String HUANSJS_R
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUANSJS_R,  m_HUANSJS_R))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HUANSJS_R = arg.GetFieldValue<System.String>();
					 return this.m_HUANSJS_R;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUANSJS_R,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_HUANSJS_R= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:HUANSDEH_C
		/// </summary>
		public System.String HUANSDEH_C
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUANSDEH_C,  m_HUANSDEH_C))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HUANSDEH_C = arg.GetFieldValue<System.String>();
					 return this.m_HUANSDEH_C;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUANSDEH_C,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_HUANSDEH_C= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:ZENGL_J
		/// </summary>
		public System.String ZENGL_J
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZENGL_J,  m_ZENGL_J))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZENGL_J = arg.GetFieldValue<System.String>();
					 return this.m_ZENGL_J;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZENGL_J,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZENGL_J= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:ZC
		/// </summary>
		public System.String ZC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZC,  m_ZC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZC = arg.GetFieldValue<System.String>();
					 return this.m_ZC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:SB
		/// </summary>
		public System.String SB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SB,  m_SB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SB = arg.GetFieldValue<System.String>();
					 return this.m_SB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SB= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:DJDW
		/// </summary>
		public System.String DJDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DJDW,  m_DJDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DJDW = arg.GetFieldValue<System.String>();
					 return this.m_DJDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DJDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DJDW= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:FZ
		/// </summary>
		public System.String FZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_FZ,  m_FZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_FZ = arg.GetFieldValue<System.String>();
					 return this.m_FZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_FZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_FZ= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:XHLB
		/// </summary>
		public System.String XHLB
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_XHLB,  m_XHLB))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_XHLB = arg.GetFieldValue<System.String>();
					 return this.m_XHLB;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_XHLB,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_XHLB= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:THZHC
		/// </summary>
		public System.String THZHC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_THZHC,  m_THZHC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_THZHC = arg.GetFieldValue<System.String>();
					 return this.m_THZHC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_THZHC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_THZHC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:THWZFC
		/// </summary>
		public System.String THWZFC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_THWZFC,  m_THWZFC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_THWZFC = arg.GetFieldValue<System.String>();
					 return this.m_THWZFC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_THWZFC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_THWZFC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:HSXI
		/// </summary>
		public System.String HSXI
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HSXI,  m_HSXI))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HSXI = arg.GetFieldValue<System.String>();
					 return this.m_HSXI;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HSXI,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_HSXI= value;
				}
			}
		}
		#endregion


	}
}
