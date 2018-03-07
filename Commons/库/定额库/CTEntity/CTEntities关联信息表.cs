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
	///关联信息表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities关联信息表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity关联信息表 m_CEntity关联信息表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities关联信息表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities关联信息表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity关联信息表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity关联信息表;
				if (this.Rows.Count > 0)
				{
					m_CEntity关联信息表 = new CEntity关联信息表();
					m_CEntity关联信息表.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_DINGEH]);
					m_CEntity关联信息表.GLDEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_GLDEH]);
					m_CEntity关联信息表.DEMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_DEMC]);
					m_CEntity关联信息表.DEDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_DEDW]);
					m_CEntity关联信息表.GLDHSX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_GLDHSX]);
					m_CEntity关联信息表.GCLXS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_GCLXS]);
					m_CEntity关联信息表.TISXX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_TISXX]);
					m_CEntity关联信息表.JISJS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity关联信息表.FILED_JISJS]);
					this.m_index = index;
					return m_CEntity关联信息表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity关联信息表.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity关联信息表.FILED_GLDEH] = value.GLDEH; 
				this.Rows[index][CEntity关联信息表.FILED_DEMC] = value.DEMC; 
				this.Rows[index][CEntity关联信息表.FILED_DEDW] = value.DEDW; 
				this.Rows[index][CEntity关联信息表.FILED_GLDHSX] = value.GLDHSX; 
				this.Rows[index][CEntity关联信息表.FILED_GCLXS] = value.GCLXS; 
				this.Rows[index][CEntity关联信息表.FILED_TISXX] = value.TISXX; 
				this.Rows[index][CEntity关联信息表.FILED_JISJS] = value.JISJS; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity关联信息表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity关联信息表.FILED_DINGEH] = entity.DINGEH;
				row[CEntity关联信息表.FILED_GLDEH] = entity.GLDEH;
				row[CEntity关联信息表.FILED_DEMC] = entity.DEMC;
				row[CEntity关联信息表.FILED_DEDW] = entity.DEDW;
				row[CEntity关联信息表.FILED_GLDHSX] = entity.GLDHSX;
				row[CEntity关联信息表.FILED_GCLXS] = entity.GCLXS;
				row[CEntity关联信息表.FILED_TISXX] = entity.TISXX;
				row[CEntity关联信息表.FILED_JISJS] = entity.JISJS;
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
			this.Columns.Add(CEntity关联信息表.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_GLDEH, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_DEMC, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_DEDW, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_GLDHSX, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_GCLXS, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_TISXX, typeof(System.String));
			this.Columns.Add(CEntity关联信息表.FILED_JISJS, typeof(System.String));
		}
	}
}
