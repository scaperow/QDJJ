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
	///清单表实体集合类
	/// </summary>
	[Serializable]
    public class CTEntities清单表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity清单表 m_CEntity清单表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities清单表()
		{
			this.buliderTable();
		}
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntities清单表(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            
        }
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity清单表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity清单表;
				if (this.Rows.Count > 0)
				{
					m_CEntity清单表 = new CEntity清单表();
					m_CEntity清单表.TX1		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_TX1]);
					m_CEntity清单表.TX2		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_TX2]);
					m_CEntity清单表.QINGDBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_QINGDBH]);
					m_CEntity清单表.QINGDMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_QINGDMC]);
					m_CEntity清单表.QINGDDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_QINGDDW]);
					m_CEntity清单表.JISGZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_JISGZ]);
					m_CEntity清单表.QINGDSYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity清单表.FILED_QINGDSYBH]);
					this.m_index = index;
					return m_CEntity清单表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity清单表.FILED_TX1] = value.TX1; 
				this.Rows[index][CEntity清单表.FILED_TX2] = value.TX2; 
				this.Rows[index][CEntity清单表.FILED_QINGDBH] = value.QINGDBH; 
				this.Rows[index][CEntity清单表.FILED_QINGDMC] = value.QINGDMC; 
				this.Rows[index][CEntity清单表.FILED_QINGDDW] = value.QINGDDW; 
				this.Rows[index][CEntity清单表.FILED_JISGZ] = value.JISGZ; 
				this.Rows[index][CEntity清单表.FILED_QINGDSYBH] = value.QINGDSYBH; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity清单表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity清单表.FILED_TX1] = entity.TX1;
				row[CEntity清单表.FILED_TX2] = entity.TX2;
				row[CEntity清单表.FILED_QINGDBH] = entity.QINGDBH;
				row[CEntity清单表.FILED_QINGDMC] = entity.QINGDMC;
				row[CEntity清单表.FILED_QINGDDW] = entity.QINGDDW;
				row[CEntity清单表.FILED_JISGZ] = entity.JISGZ;
				row[CEntity清单表.FILED_QINGDSYBH] = entity.QINGDSYBH;
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
			this.Columns.Add(CEntity清单表.FILED_TX1, typeof(System.String));
			this.Columns.Add(CEntity清单表.FILED_TX2, typeof(System.String));
			this.Columns.Add(CEntity清单表.FILED_QINGDBH, typeof(System.String));
			this.Columns.Add(CEntity清单表.FILED_QINGDMC, typeof(System.String));
			this.Columns.Add(CEntity清单表.FILED_QINGDDW, typeof(System.String));
			this.Columns.Add(CEntity清单表.FILED_JISGZ, typeof(System.String));
			this.Columns.Add(CEntity清单表.FILED_QINGDSYBH, typeof(System.String));
		}
	}
}
