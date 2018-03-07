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
		///图集内容表业务实体类
		/// </summary>
	public class CEntity图集内容表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "图集内容表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJBH	=  "TJBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZFBH	=  "ZFBH" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_ZFMC	=  "ZFMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_TJDE	=  "TJDE" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_TJBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZFBH	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_ZFMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_TJDE	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
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
		///数据库字段名称:ZFMC
		/// </summary>
		public System.String ZFMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFMC,  m_ZFMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_ZFMC = arg.GetFieldValue<System.String>();
					 return this.m_ZFMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_ZFMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_ZFMC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:TJDE
		/// </summary>
		public System.String TJDE
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJDE,  m_TJDE))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_TJDE = arg.GetFieldValue<System.String>();
					 return this.m_TJDE;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_TJDE,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_TJDE= value;
				}
			}
		}
		#endregion


	}
}
