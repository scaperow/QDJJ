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
	///子目取费表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities子目取费表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity子目取费表 m_CEntity子目取费表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities子目取费表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities子目取费表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity子目取费表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity子目取费表;
				if (this.Rows.Count > 0)
				{
					m_CEntity子目取费表 = new CEntity子目取费表();
					m_CEntity子目取费表.YYH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_YYH]);
					m_CEntity子目取费表.MC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_MC]);
					m_CEntity子目取费表.BDS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_BDS]);
					m_CEntity子目取费表.TBJSJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_TBJSJC]);
					m_CEntity子目取费表.BDJSJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_BDJSJC]);
					m_CEntity子目取费表.FL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_FL]);
					m_CEntity子目取费表.JE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_JE]);
					m_CEntity子目取费表.BEIZHU		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity子目取费表.FILED_BEIZHU]);
					this.m_index = index;
					return m_CEntity子目取费表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity子目取费表.FILED_YYH] = value.YYH; 
				this.Rows[index][CEntity子目取费表.FILED_MC] = value.MC; 
				this.Rows[index][CEntity子目取费表.FILED_BDS] = value.BDS; 
				this.Rows[index][CEntity子目取费表.FILED_TBJSJC] = value.TBJSJC; 
				this.Rows[index][CEntity子目取费表.FILED_BDJSJC] = value.BDJSJC; 
				this.Rows[index][CEntity子目取费表.FILED_FL] = value.FL; 
				this.Rows[index][CEntity子目取费表.FILED_JE] = value.JE; 
				this.Rows[index][CEntity子目取费表.FILED_BEIZHU] = value.BEIZHU; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity子目取费表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity子目取费表.FILED_YYH] = entity.YYH;
				row[CEntity子目取费表.FILED_MC] = entity.MC;
				row[CEntity子目取费表.FILED_BDS] = entity.BDS;
				row[CEntity子目取费表.FILED_TBJSJC] = entity.TBJSJC;
				row[CEntity子目取费表.FILED_BDJSJC] = entity.BDJSJC;
				row[CEntity子目取费表.FILED_FL] = entity.FL;
				row[CEntity子目取费表.FILED_JE] = entity.JE;
				row[CEntity子目取费表.FILED_BEIZHU] = entity.BEIZHU;
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
			this.Columns.Add(CEntity子目取费表.FILED_YYH, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_MC, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_BDS, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_TBJSJC, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_BDJSJC, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_FL, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_JE, typeof(System.String));
			this.Columns.Add(CEntity子目取费表.FILED_BEIZHU, typeof(System.String));
		}
	}
}
