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
		///图集表业务实体类
		/// </summary>
	public class CEntity图集表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "图集表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_SYBH	=  "SYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TX1	=  "TX1" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TX2	=  "TX2" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJBH	=  "TJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJMC	=  "TJMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_DW	=  "DW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_BZ	=  "BZ" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_SYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TX1	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TX2	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TJMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_DW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_BZ	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:SYBH
		/// </summary>
		public System.String SYBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SYBH,  m_SYBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SYBH = arg.GetFieldValue<System.String>();
					 return this.m_SYBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SYBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SYBH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TX1
		/// </summary>
		public System.String TX1
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX1,  m_TX1))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TX1 = arg.GetFieldValue<System.String>();
					 return this.m_TX1;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX1,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TX1= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TX2
		/// </summary>
		public System.String TX2
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX2,  m_TX2))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TX2 = arg.GetFieldValue<System.String>();
					 return this.m_TX2;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TX2,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TX2= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TJBH
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
		///获取或设置
		///数据库字段名称:TJMC
		/// </summary>
		public System.String TJMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJMC,  m_TJMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TJMC = arg.GetFieldValue<System.String>();
					 return this.m_TJMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TJMC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:DW
		/// </summary>
		public System.String DW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DW,  m_DW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DW = arg.GetFieldValue<System.String>();
					 return this.m_DW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DW= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:BZ
		/// </summary>
		public System.String BZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_BZ,  m_BZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_BZ = arg.GetFieldValue<System.String>();
					 return this.m_BZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_BZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_BZ= value;
				}
			}
		}
		#endregion


	}
}
