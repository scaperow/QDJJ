/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年09月16日　04时06分14秒
备注:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;
namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
	/// <summary>
	///取费表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities取费表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity取费表 m_CEntity取费表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities取费表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities取费表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity取费表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity取费表;
				if (this.Rows.Count > 0)
				{
					m_CEntity取费表 = new CEntity取费表();
					m_CEntity取费表.GONGCLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_GONGCLB]);
					m_CEntity取费表.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_DINGEH]);
					m_CEntity取费表.GUANLFL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_GUANLFL]);
					m_CEntity取费表.LIRL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_LIRL]);
					m_CEntity取费表.FXLBD		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_FXLBD]);
					m_CEntity取费表.FXLTB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_FXLTB]);
					m_CEntity取费表.GLBDJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_GLBDJC]);
					m_CEntity取费表.GLTBJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_GLTBJC]);
					m_CEntity取费表.LRBDJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_LRBDJC]);
					m_CEntity取费表.LRTBJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_LRTBJC]);
					m_CEntity取费表.FXBDJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_FXBDJC]);
					m_CEntity取费表.FXTBJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_FXTBJC]);
					m_CEntity取费表.SFHH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity取费表.FILED_SFHH]);
					this.m_index = index;
					return m_CEntity取费表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity取费表.FILED_GONGCLB] = value.GONGCLB; 
				this.Rows[index][CEntity取费表.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity取费表.FILED_GUANLFL] = value.GUANLFL; 
				this.Rows[index][CEntity取费表.FILED_LIRL] = value.LIRL; 
				this.Rows[index][CEntity取费表.FILED_FXLBD] = value.FXLBD; 
				this.Rows[index][CEntity取费表.FILED_FXLTB] = value.FXLTB; 
				this.Rows[index][CEntity取费表.FILED_GLBDJC] = value.GLBDJC; 
				this.Rows[index][CEntity取费表.FILED_GLTBJC] = value.GLTBJC; 
				this.Rows[index][CEntity取费表.FILED_LRBDJC] = value.LRBDJC; 
				this.Rows[index][CEntity取费表.FILED_LRTBJC] = value.LRTBJC; 
				this.Rows[index][CEntity取费表.FILED_FXBDJC] = value.FXBDJC; 
				this.Rows[index][CEntity取费表.FILED_FXTBJC] = value.FXTBJC; 
				this.Rows[index][CEntity取费表.FILED_SFHH] = value.SFHH; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity取费表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity取费表.FILED_GONGCLB] = entity.GONGCLB;
				row[CEntity取费表.FILED_DINGEH] = entity.DINGEH;
				row[CEntity取费表.FILED_GUANLFL] = entity.GUANLFL;
				row[CEntity取费表.FILED_LIRL] = entity.LIRL;
				row[CEntity取费表.FILED_FXLBD] = entity.FXLBD;
				row[CEntity取费表.FILED_FXLTB] = entity.FXLTB;
				row[CEntity取费表.FILED_GLBDJC] = entity.GLBDJC;
				row[CEntity取费表.FILED_GLTBJC] = entity.GLTBJC;
				row[CEntity取费表.FILED_LRBDJC] = entity.LRBDJC;
				row[CEntity取费表.FILED_LRTBJC] = entity.LRTBJC;
				row[CEntity取费表.FILED_FXBDJC] = entity.FXBDJC;
				row[CEntity取费表.FILED_FXTBJC] = entity.FXTBJC;
				row[CEntity取费表.FILED_SFHH] = entity.SFHH;
				this.Rows.Add(row);
				return this.Rows.Count;
			}
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// 创建一个新的表结构
		/// </summary>
		private void buliderTable()
		{
			this.Columns.Add(CEntity取费表.FILED_GONGCLB, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_GUANLFL, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_LIRL, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_FXLBD, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_FXLTB, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_GLBDJC, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_GLTBJC, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_LRBDJC, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_LRTBJC, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_FXBDJC, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_FXTBJC, typeof(System.String));
			this.Columns.Add(CEntity取费表.FILED_SFHH, typeof(System.String));
		}
	}
}
