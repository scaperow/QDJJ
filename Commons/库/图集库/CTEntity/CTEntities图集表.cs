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
	///图集表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities图集表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity图集表 m_CEntity图集表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities图集表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities图集表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity图集表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity图集表;
				if (this.Rows.Count > 0)
				{
					m_CEntity图集表 = new CEntity图集表();
					m_CEntity图集表.SYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_SYBH]);
					m_CEntity图集表.TX1		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_TX1]);
					m_CEntity图集表.TX2		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_TX2]);
					m_CEntity图集表.TJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_TJBH]);
					m_CEntity图集表.TJMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_TJMC]);
					m_CEntity图集表.DW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_DW]);
					m_CEntity图集表.BZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity图集表.FILED_BZ]);
					this.m_index = index;
					return m_CEntity图集表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity图集表.FILED_SYBH] = value.SYBH; 
				this.Rows[index][CEntity图集表.FILED_TX1] = value.TX1; 
				this.Rows[index][CEntity图集表.FILED_TX2] = value.TX2; 
				this.Rows[index][CEntity图集表.FILED_TJBH] = value.TJBH; 
				this.Rows[index][CEntity图集表.FILED_TJMC] = value.TJMC; 
				this.Rows[index][CEntity图集表.FILED_DW] = value.DW; 
				this.Rows[index][CEntity图集表.FILED_BZ] = value.BZ; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity图集表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity图集表.FILED_SYBH] = entity.SYBH;
				row[CEntity图集表.FILED_TX1] = entity.TX1;
				row[CEntity图集表.FILED_TX2] = entity.TX2;
				row[CEntity图集表.FILED_TJBH] = entity.TJBH;
				row[CEntity图集表.FILED_TJMC] = entity.TJMC;
				row[CEntity图集表.FILED_DW] = entity.DW;
				row[CEntity图集表.FILED_BZ] = entity.BZ;
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
			this.Columns.Add(CEntity图集表.FILED_SYBH, typeof(System.String));
			this.Columns.Add(CEntity图集表.FILED_TX1, typeof(System.String));
			this.Columns.Add(CEntity图集表.FILED_TX2, typeof(System.String));
			this.Columns.Add(CEntity图集表.FILED_TJBH, typeof(System.String));
			this.Columns.Add(CEntity图集表.FILED_TJMC, typeof(System.String));
			this.Columns.Add(CEntity图集表.FILED_DW, typeof(System.String));
			this.Columns.Add(CEntity图集表.FILED_BZ, typeof(System.String));
		}
	}
}
