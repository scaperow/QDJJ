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
		///加密系数表业务实体类
		/// </summary>
	public class CEntity加密系数表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "加密系数表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_CAIJBH	=  "CAIJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_JMXS	=  "JMXS" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_CAIJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_JMXS	=	string.Empty	;
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
		///数据库字段名称:JMXS
		/// </summary>
		public System.String JMXS
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_JMXS,  m_JMXS))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_JMXS = arg.GetFieldValue<System.String>();
					 return this.m_JMXS;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_JMXS,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_JMXS= value;
				}
			}
		}
		#endregion


	}
}
