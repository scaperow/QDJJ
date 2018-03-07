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
	///配合比表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities配合比表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity配合比表 m_CEntity配合比表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities配合比表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities配合比表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity配合比表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity配合比表;
				if (this.Rows.Count > 0)
				{
					m_CEntity配合比表 = new CEntity配合比表();
					m_CEntity配合比表.CAIJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity配合比表.FILED_CAIJBH]);
					m_CEntity配合比表.PHB_CJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity配合比表.FILED_PHB_CJBH]);
					m_CEntity配合比表.PHB_CJSL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity配合比表.FILED_PHB_CJSL]);
					this.m_index = index;
					return m_CEntity配合比表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity配合比表.FILED_CAIJBH] = value.CAIJBH; 
				this.Rows[index][CEntity配合比表.FILED_PHB_CJBH] = value.PHB_CJBH; 
				this.Rows[index][CEntity配合比表.FILED_PHB_CJSL] = value.PHB_CJSL; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity配合比表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity配合比表.FILED_CAIJBH] = entity.CAIJBH;
				row[CEntity配合比表.FILED_PHB_CJBH] = entity.PHB_CJBH;
				row[CEntity配合比表.FILED_PHB_CJSL] = entity.PHB_CJSL;
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
			this.Columns.Add(CEntity配合比表.FILED_CAIJBH, typeof(System.String));
			this.Columns.Add(CEntity配合比表.FILED_PHB_CJBH, typeof(System.String));
			this.Columns.Add(CEntity配合比表.FILED_PHB_CJSL, typeof(System.String));
		}
	}
}
