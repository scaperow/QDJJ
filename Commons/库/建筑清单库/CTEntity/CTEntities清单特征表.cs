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
	///清单特征表实体集合类
	/// </summary>
	[Serializable]
    public class CTEntities清单特征表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity清单特征表 m_CEntity清单特征表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities清单特征表()
		{
			this.buliderTable();
		}
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntities清单特征表(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity清单特征表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity清单特征表;
				if (this.Rows.Count > 0)
				{
					m_CEntity清单特征表 = new CEntity清单特征表();
					m_CEntity清单特征表.QINGDBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征表.FILED_QINGDBH]);
					m_CEntity清单特征表.TEZBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征表.FILED_TEZBH]);
					m_CEntity清单特征表.TEZMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征表.FILED_TEZMC]);
					m_CEntity清单特征表.TEZDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征表.FILED_TEZDW]);
					m_CEntity清单特征表.TEZZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单特征表.FILED_TEZZ]);
					this.m_index = index;
					return m_CEntity清单特征表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity清单特征表.FILED_QINGDBH] = value.QINGDBH; 
				this.Rows[index][CEntity清单特征表.FILED_TEZBH] = value.TEZBH; 
				this.Rows[index][CEntity清单特征表.FILED_TEZMC] = value.TEZMC; 
				this.Rows[index][CEntity清单特征表.FILED_TEZDW] = value.TEZDW; 
				this.Rows[index][CEntity清单特征表.FILED_TEZZ] = value.TEZZ; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity清单特征表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity清单特征表.FILED_QINGDBH] = entity.QINGDBH;
				row[CEntity清单特征表.FILED_TEZBH] = entity.TEZBH;
				row[CEntity清单特征表.FILED_TEZMC] = entity.TEZMC;
				row[CEntity清单特征表.FILED_TEZDW] = entity.TEZDW;
				row[CEntity清单特征表.FILED_TEZZ] = entity.TEZZ;
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
			this.Columns.Add(CEntity清单特征表.FILED_QINGDBH, typeof(System.String));
			this.Columns.Add(CEntity清单特征表.FILED_TEZBH, typeof(System.String));
			this.Columns.Add(CEntity清单特征表.FILED_TEZMC, typeof(System.String));
			this.Columns.Add(CEntity清单特征表.FILED_TEZDW, typeof(System.String));
			this.Columns.Add(CEntity清单特征表.FILED_TEZZ, typeof(System.String));
		}
	}
}
