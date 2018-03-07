/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年11月16日　03时06分53秒
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
	///清单特征定额表实体集合类
	/// </summary>
	[Serializable]
    public class CTEntities清单特征定额表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity清单特征定额表 m_CEntity清单特征定额表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities清单特征定额表()
		{
			this.buliderTable();
		}
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntities清单特征定额表(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity清单特征定额表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity清单特征定额表;
				if (this.Rows.Count > 0)
				{
					m_CEntity清单特征定额表 = new CEntity清单特征定额表();
					m_CEntity清单特征定额表.TZBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_TZBH]);
					m_CEntity清单特征定额表.TZZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_TZZ]);
					m_CEntity清单特征定额表.TZDEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_TZDEH]);
					m_CEntity清单特征定额表.DEMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_DEMC]);
					m_CEntity清单特征定额表.DEDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_DEDW]);
					m_CEntity清单特征定额表.XS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_XS]);
					m_CEntity清单特征定额表.DECJ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征定额表.FILED_DECJ]);
					this.m_index = index;
					return m_CEntity清单特征定额表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity清单特征定额表.FILED_TZBH] = value.TZBH; 
				this.Rows[index][CEntity清单特征定额表.FILED_TZZ] = value.TZZ; 
				this.Rows[index][CEntity清单特征定额表.FILED_TZDEH] = value.TZDEH; 
				this.Rows[index][CEntity清单特征定额表.FILED_DEMC] = value.DEMC; 
				this.Rows[index][CEntity清单特征定额表.FILED_DEDW] = value.DEDW; 
				this.Rows[index][CEntity清单特征定额表.FILED_XS] = value.XS; 
				this.Rows[index][CEntity清单特征定额表.FILED_DECJ] = value.DECJ; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity清单特征定额表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity清单特征定额表.FILED_TZBH] = entity.TZBH;
				row[CEntity清单特征定额表.FILED_TZZ] = entity.TZZ;
				row[CEntity清单特征定额表.FILED_TZDEH] = entity.TZDEH;
				row[CEntity清单特征定额表.FILED_DEMC] = entity.DEMC;
				row[CEntity清单特征定额表.FILED_DEDW] = entity.DEDW;
				row[CEntity清单特征定额表.FILED_XS] = entity.XS;
				row[CEntity清单特征定额表.FILED_DECJ] = entity.DECJ;
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
			this.Columns.Add(CEntity清单特征定额表.FILED_TZBH, typeof(System.String));
			this.Columns.Add(CEntity清单特征定额表.FILED_TZZ, typeof(System.String));
			this.Columns.Add(CEntity清单特征定额表.FILED_TZDEH, typeof(System.String));
			this.Columns.Add(CEntity清单特征定额表.FILED_DEMC, typeof(System.String));
			this.Columns.Add(CEntity清单特征定额表.FILED_DEDW, typeof(System.String));
			this.Columns.Add(CEntity清单特征定额表.FILED_XS, typeof(System.String));
			this.Columns.Add(CEntity清单特征定额表.FILED_DECJ, typeof(System.String));
		}
	}
}
