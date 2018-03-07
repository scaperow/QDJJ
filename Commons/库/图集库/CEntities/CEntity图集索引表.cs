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
		///图集索引表业务实体类
		/// </summary>
	public class CEntity图集索引表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "图集索引表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_PARENTID	=  "PARENTID" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_SYBH	=  "SYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MUNR	=  "MUNR" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_PARENTID	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_SYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_MUNR	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:PARENTID
		/// </summary>
		public System.String PARENTID
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENTID,  m_PARENTID))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_PARENTID = arg.GetFieldValue<System.String>();
					 return this.m_PARENTID;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_PARENTID,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_PARENTID= value;
				}
			}
		}
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
		///数据库字段名称:MUNR
		/// </summary>
		public System.String MUNR
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MUNR,  m_MUNR))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MUNR = arg.GetFieldValue<System.String>();
					 return this.m_MUNR;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MUNR,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_MUNR= value;
				}
			}
		}
		#endregion


	}
}
