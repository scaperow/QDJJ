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
		///大材设置表业务实体类
		/// </summary>
	public class CEntity大材设置表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "大材设置表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_SANDCMC	=  "SANDCMC" ;
		/// <summary>
		///
		/// </summary>
		public const string FILED_HUIZDW	=  "HUIZDW" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_SANDCMC	=	string.Empty	;
		/// <summary>
		///
		/// </summary>
		private System.String m_HUIZDW	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:SANDCMC
		/// </summary>
		public System.String SANDCMC
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_SANDCMC,  m_SANDCMC))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_SANDCMC = arg.GetFieldValue<System.String>();
					 return this.m_SANDCMC;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_SANDCMC,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_SANDCMC= value;
				}
			}
		}
		/// <summary>
		///获取或设置
		///数据库字段名称:HUIZDW
		/// </summary>
		public System.String HUIZDW
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUIZDW,  m_HUIZDW))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_HUIZDW = arg.GetFieldValue<System.String>();
					 return this.m_HUIZDW;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_HUIZDW,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_HUIZDW= value;
				}
			}
		}
		#endregion


	}
}
