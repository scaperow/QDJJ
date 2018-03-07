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
		///清单表业务实体类
		/// </summary>
    public class CEntity清单表 : CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "清单表";
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
		public const string FILED_QINGDBH	=  "QINGDBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_QINGDMC	=  "QINGDMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_QINGDDW	=  "QINGDDW" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JISGZ	=  "JISGZ" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_QINGDSYBH	=  "QINGDSYBH" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
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
		private System.String m_QINGDBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_QINGDMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_QINGDDW	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JISGZ	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_QINGDSYBH	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
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
		///数据库字段名称:QINGDBH
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
		///获取或设置
		///数据库字段名称:QINGDMC
		/// </summary>
		public System.String QINGDMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDMC,  m_QINGDMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_QINGDMC = arg.GetFieldValue<System.String>();
					 return this.m_QINGDMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_QINGDMC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:QINGDDW
		/// </summary>
		public System.String QINGDDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDDW,  m_QINGDDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_QINGDDW = arg.GetFieldValue<System.String>();
					 return this.m_QINGDDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_QINGDDW= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:JISGZ
		/// </summary>
		public System.String JISGZ
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JISGZ,  m_JISGZ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JISGZ = arg.GetFieldValue<System.String>();
					 return this.m_JISGZ;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JISGZ,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JISGZ= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:QINGDSYBH
		/// </summary>
		public System.String QINGDSYBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDSYBH,  m_QINGDSYBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_QINGDSYBH = arg.GetFieldValue<System.String>();
					 return this.m_QINGDSYBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_QINGDSYBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_QINGDSYBH= value;
				}
			}
		}
    }
}
		#endregion


