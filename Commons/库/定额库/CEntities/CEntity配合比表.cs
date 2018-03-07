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
		///配合比表业务实体类
		/// </summary>
	public class CEntity配合比表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "配合比表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJBH	=  "CAIJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_PHB_CJBH	=  "PHB_CJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_PHB_CJSL	=  "PHB_CJSL" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_PHB_CJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_PHB_CJSL	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:CAIJBH
		/// </summary>
		public System.String CAIJBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJBH,  m_CAIJBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_CAIJBH = arg.GetFieldValue<System.String>();
					 return this.m_CAIJBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_CAIJBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_CAIJBH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:PHB_CJBH
		/// </summary>
		public System.String PHB_CJBH
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJBH,  m_PHB_CJBH))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PHB_CJBH = arg.GetFieldValue<System.String>();
					 return this.m_PHB_CJBH;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJBH,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_PHB_CJBH= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:PHB_CJSL
		/// </summary>
		public System.String PHB_CJSL
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJSL,  m_PHB_CJSL))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PHB_CJSL = arg.GetFieldValue<System.String>();
					 return this.m_PHB_CJSL;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PHB_CJSL,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_PHB_CJSL= value;
				}
			}
		}
		#endregion


	}
}
