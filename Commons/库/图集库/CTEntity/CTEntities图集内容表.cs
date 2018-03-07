/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年14月16日　04时06分44秒
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
	///图集内容表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities图集内容表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity图集内容表 m_CEntity图集内容表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities图集内容表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities图集内容表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity图集内容表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity图集内容表;
				if (this.Rows.Count > 0)
				{
					m_CEntity图集内容表 = new CEntity图集内容表();
					m_CEntity图集内容表.TJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集内容表.FILED_TJBH]);
					m_CEntity图集内容表.ZFBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集内容表.FILED_ZFBH]);
					m_CEntity图集内容表.ZFMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集内容表.FILED_ZFMC]);
					m_CEntity图集内容表.TJDE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集内容表.FILED_TJDE]);
					this.m_index = index;
					return m_CEntity图集内容表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity图集内容表.FILED_TJBH] = value.TJBH; 
				this.Rows[index][CEntity图集内容表.FILED_ZFBH] = value.ZFBH; 
				this.Rows[index][CEntity图集内容表.FILED_ZFMC] = value.ZFMC; 
				this.Rows[index][CEntity图集内容表.FILED_TJDE] = value.TJDE; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity图集内容表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity图集内容表.FILED_TJBH] = entity.TJBH;
				row[CEntity图集内容表.FILED_ZFBH] = entity.ZFBH;
				row[CEntity图集内容表.FILED_ZFMC] = entity.ZFMC;
				row[CEntity图集内容表.FILED_TJDE] = entity.TJDE;
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
			this.Columns.Add(CEntity图集内容表.FILED_TJBH, typeof(System.String));
			this.Columns.Add(CEntity图集内容表.FILED_ZFBH, typeof(System.String));
			this.Columns.Add(CEntity图集内容表.FILED_ZFMC, typeof(System.String));
			this.Columns.Add(CEntity图集内容表.FILED_TJDE, typeof(System.String));
		}
	}
}
