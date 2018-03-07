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
		///定额属性表业务实体类
		/// </summary>
	public class CEntity定额属性表 :	CEntity 
	{
		#region----------------------字段常量定义---------------------------------
		/// <summary>
		///
		/// </summary>
		public const string TABLE_NAME = "定额属性表";
		/// <summary>
		///
		/// </summary>
		public const string FILED_DESX	=  "DESX" ;
		#endregion

		#region----------------------私有成员定义---------------------------------
		/// <summary>
		///
		/// </summary>
		private System.String m_DESX	=	string.Empty	;
		#endregion

		#region----------------------公有成员定义---------------------------------
		/// <summary>
		///获取或设置
		///数据库字段名称:DESX
		/// </summary>
		public System.String DESX
		{
			get
			{
				using (CEventProperty arg = new CEventProperty(FILED_DESX,  m_DESX))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						this.m_DESX = arg.GetFieldValue<System.String>();
					 return this.m_DESX;
				}
			}
			set
			{
				using (CEventProperty arg = new CEventProperty(FILED_DESX,  value ))
				{
					this.OnPropertyGet(this, arg);
					if (arg.IsChangeValue)
						value = arg.GetFieldValue<System.String>();
					this.m_DESX= value;
				}
			}
		}
		#endregion


	}
}
