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
	///定额索引表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities定额索引表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity定额索引表 m_CEntity定额索引表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities定额索引表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities定额索引表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity定额索引表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity定额索引表;
				if (this.Rows.Count > 0)
				{
					m_CEntity定额索引表 = new CEntity定额索引表();
					m_CEntity定额索引表.PARENTID		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额索引表.FILED_PARENTID]);
					m_CEntity定额索引表.DINGESYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额索引表.FILED_DINGESYBH]);
					m_CEntity定额索引表.MULNR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额索引表.FILED_MULNR]);
					this.m_index = index;
					return m_CEntity定额索引表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity定额索引表.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntity定额索引表.FILED_DINGESYBH] = value.DINGESYBH; 
				this.Rows[index][CEntity定额索引表.FILED_MULNR] = value.MULNR; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity定额索引表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity定额索引表.FILED_PARENTID] = entity.PARENTID;
				row[CEntity定额索引表.FILED_DINGESYBH] = entity.DINGESYBH;
				row[CEntity定额索引表.FILED_MULNR] = entity.MULNR;
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
			this.Columns.Add(CEntity定额索引表.FILED_PARENTID, typeof(System.String));
			this.Columns.Add(CEntity定额索引表.FILED_DINGESYBH, typeof(System.String));
			this.Columns.Add(CEntity定额索引表.FILED_MULNR, typeof(System.String));
		}
	}
}
