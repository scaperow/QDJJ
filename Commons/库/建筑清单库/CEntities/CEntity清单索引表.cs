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
		///清单索引表业务实体类
		/// </summary>
    public class CEntity清单索引表 : CEntity
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "清单索引表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_PARENTID	=  "PARENTID" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_QINGDSYBH	=  "QINGDSYBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_MULNR	=  "MULNR" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_PARENTID	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_QINGDSYBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_MULNR	=	string.Empty	;
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
		/// <summary>
		///获取或设置
		///数据库字段名称:MULNR
		/// </summary>
		public System.String MULNR
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_MULNR,  m_MULNR))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_MULNR = arg.GetFieldValue<System.String>();
					 return this.m_MULNR;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_MULNR,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_MULNR= value;
				}
			}
		}
    }
}
		#endregion


