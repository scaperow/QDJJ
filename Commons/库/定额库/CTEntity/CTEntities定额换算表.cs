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
	///定额换算表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities定额换算表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity定额换算表 m_CEntity定额换算表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities定额换算表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities定额换算表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity定额换算表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity定额换算表;
				if (this.Rows.Count > 0)
				{
					m_CEntity定额换算表 = new CEntity定额换算表();
					m_CEntity定额换算表.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_DINGEH]);
					m_CEntity定额换算表.HUANSLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_HUANSLB]);
					m_CEntity定额换算表.TISXX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_TISXX]);
					m_CEntity定额换算表.HUANSJS_R		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_HUANSJS_R]);
					m_CEntity定额换算表.HUANSDEH_C		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_HUANSDEH_C]);
					m_CEntity定额换算表.ZENGL_J		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_ZENGL_J]);
					m_CEntity定额换算表.ZC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_ZC]);
					m_CEntity定额换算表.SB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_SB]);
					m_CEntity定额换算表.DJDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_DJDW]);
					m_CEntity定额换算表.FZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_FZ]);
					m_CEntity定额换算表.XHLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_XHLB]);
					m_CEntity定额换算表.THZHC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_THZHC]);
					m_CEntity定额换算表.THWZFC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_THWZFC]);
					m_CEntity定额换算表.HSXI		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额换算表.FILED_HSXI]);
					this.m_index = index;
					return m_CEntity定额换算表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity定额换算表.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity定额换算表.FILED_HUANSLB] = value.HUANSLB; 
				this.Rows[index][CEntity定额换算表.FILED_TISXX] = value.TISXX; 
				this.Rows[index][CEntity定额换算表.FILED_HUANSJS_R] = value.HUANSJS_R; 
				this.Rows[index][CEntity定额换算表.FILED_HUANSDEH_C] = value.HUANSDEH_C; 
				this.Rows[index][CEntity定额换算表.FILED_ZENGL_J] = value.ZENGL_J; 
				this.Rows[index][CEntity定额换算表.FILED_ZC] = value.ZC; 
				this.Rows[index][CEntity定额换算表.FILED_SB] = value.SB; 
				this.Rows[index][CEntity定额换算表.FILED_DJDW] = value.DJDW; 
				this.Rows[index][CEntity定额换算表.FILED_FZ] = value.FZ; 
				this.Rows[index][CEntity定额换算表.FILED_XHLB] = value.XHLB; 
				this.Rows[index][CEntity定额换算表.FILED_THZHC] = value.THZHC; 
				this.Rows[index][CEntity定额换算表.FILED_THWZFC] = value.THWZFC; 
				this.Rows[index][CEntity定额换算表.FILED_HSXI] = value.HSXI; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity定额换算表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity定额换算表.FILED_DINGEH] = entity.DINGEH;
				row[CEntity定额换算表.FILED_HUANSLB] = entity.HUANSLB;
				row[CEntity定额换算表.FILED_TISXX] = entity.TISXX;
				row[CEntity定额换算表.FILED_HUANSJS_R] = entity.HUANSJS_R;
				row[CEntity定额换算表.FILED_HUANSDEH_C] = entity.HUANSDEH_C;
				row[CEntity定额换算表.FILED_ZENGL_J] = entity.ZENGL_J;
				row[CEntity定额换算表.FILED_ZC] = entity.ZC;
				row[CEntity定额换算表.FILED_SB] = entity.SB;
				row[CEntity定额换算表.FILED_DJDW] = entity.DJDW;
				row[CEntity定额换算表.FILED_FZ] = entity.FZ;
				row[CEntity定额换算表.FILED_XHLB] = entity.XHLB;
				row[CEntity定额换算表.FILED_THZHC] = entity.THZHC;
				row[CEntity定额换算表.FILED_THWZFC] = entity.THWZFC;
				row[CEntity定额换算表.FILED_HSXI] = entity.HSXI;
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
			this.Columns.Add(CEntity定额换算表.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_HUANSLB, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_TISXX, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_HUANSJS_R, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_HUANSDEH_C, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_ZENGL_J, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_ZC, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_SB, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_DJDW, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_FZ, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_XHLB, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_THZHC, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_THWZFC, typeof(System.String));
			this.Columns.Add(CEntity定额换算表.FILED_HSXI, typeof(System.String));
		}
	}
}
