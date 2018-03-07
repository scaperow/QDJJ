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
		///指引内容表业务实体类
		/// </summary>
	public class CEntity指引内容表 :CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "指引内容表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_QINGDBH	=  "QINGDBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_NEIRBH	=  "NEIRBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_NRMC	=  "NRMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZHIYDE	=  "ZHIYDE" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_QINGDBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_NEIRBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_NRMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZHIYDE	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
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
		///数据库字段名称:NEIRBH
		/// </summary>
		public System.String NEIRBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_NEIRBH,  m_NEIRBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_NEIRBH = arg.GetFieldValue<System.String>();
					 return this.m_NEIRBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_NEIRBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_NEIRBH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:NRMC
		/// </summary>
		public System.String NRMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_NRMC,  m_NRMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_NRMC = arg.GetFieldValue<System.String>();
					 return this.m_NRMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_NRMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_NRMC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:ZHIYDE
		/// </summary>
		public System.String ZHIYDE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZHIYDE,  m_ZHIYDE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZHIYDE = arg.GetFieldValue<System.String>();
					 return this.m_ZHIYDE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZHIYDE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZHIYDE= value;
				}
			}
		}
    }
}
		#endregion


