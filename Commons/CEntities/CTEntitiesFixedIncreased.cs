/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年43月08日　05时11分33秒
备注:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;
namespace  GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///FIXEDINCREASED实体集合类
	/// </summary>
	[Serializable]
    public class CTEntitiesFixedIncreased : DataTable
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntityFixedIncreased m_CEntityFixedIncreased;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntitiesFixedIncreased()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntitiesFixedIncreased(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntityFixedIncreased this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntityFixedIncreased;
				if (this.Rows.Count > 0)
				{
					m_CEntityFixedIncreased = new CEntityFixedIncreased();
					m_CEntityFixedIncreased.ID		 = ToolKit.ParseInt(this.Rows[index][CEntityFixedIncreased.FILED_ID]);
					m_CEntityFixedIncreased.PARENTID		 = ToolKit.ParseInt(this.Rows[index][CEntityFixedIncreased.FILED_PARENTID]);
					m_CEntityFixedIncreased.NAME		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_NAME]);
					m_CEntityFixedIncreased.ISCHECK		 = ToolKit.ParseBoolen(this.Rows[index][CEntityFixedIncreased.FILED_ISCHECK]);
					m_CEntityFixedIncreased.CODE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_CODE]);
					m_CEntityFixedIncreased.LOCATION		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_LOCATION]);
					m_CEntityFixedIncreased.GROUP		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_GROUP]);
					m_CEntityFixedIncreased.FIXED		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_FIXED]);
					m_CEntityFixedIncreased.CALCULATION		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_CALCULATION]);
					m_CEntityFixedIncreased.ADDITIONAL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityFixedIncreased.FILED_ADDITIONAL]);
					m_CEntityFixedIncreased.COEFFICIENT		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityFixedIncreased.FILED_COEFFICIENT]);
					m_CEntityFixedIncreased.ARTIFICIAL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityFixedIncreased.FILED_ARTIFICIAL]);
					m_CEntityFixedIncreased.MATERIAL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityFixedIncreased.FILED_MATERIAL]);
					m_CEntityFixedIncreased.MECHANICAL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityFixedIncreased.FILED_MECHANICAL]);
					m_CEntityFixedIncreased.EXPERTISE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_EXPERTISE]);
					m_CEntityFixedIncreased.REMARK		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityFixedIncreased.FILED_REMARK]);
					this.m_index = index;
					return m_CEntityFixedIncreased;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityFixedIncreased.FILED_ID] = value.ID; 
				this.Rows[index][CEntityFixedIncreased.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntityFixedIncreased.FILED_NAME] = value.NAME; 
				this.Rows[index][CEntityFixedIncreased.FILED_ISCHECK] = value.ISCHECK; 
				this.Rows[index][CEntityFixedIncreased.FILED_CODE] = value.CODE; 
				this.Rows[index][CEntityFixedIncreased.FILED_LOCATION] = value.LOCATION; 
				this.Rows[index][CEntityFixedIncreased.FILED_GROUP] = value.GROUP; 
				this.Rows[index][CEntityFixedIncreased.FILED_FIXED] = value.FIXED; 
				this.Rows[index][CEntityFixedIncreased.FILED_CALCULATION] = value.CALCULATION; 
				this.Rows[index][CEntityFixedIncreased.FILED_ADDITIONAL] = value.ADDITIONAL; 
				this.Rows[index][CEntityFixedIncreased.FILED_COEFFICIENT] = value.COEFFICIENT; 
				this.Rows[index][CEntityFixedIncreased.FILED_ARTIFICIAL] = value.ARTIFICIAL; 
				this.Rows[index][CEntityFixedIncreased.FILED_MATERIAL] = value.MATERIAL; 
				this.Rows[index][CEntityFixedIncreased.FILED_MECHANICAL] = value.MECHANICAL; 
				this.Rows[index][CEntityFixedIncreased.FILED_EXPERTISE] = value.EXPERTISE; 
				this.Rows[index][CEntityFixedIncreased.FILED_REMARK] = value.REMARK; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntityFixedIncreased entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityFixedIncreased.FILED_ID] = entity.ID;
				row[CEntityFixedIncreased.FILED_PARENTID] = entity.PARENTID;
				row[CEntityFixedIncreased.FILED_NAME] = entity.NAME;
				row[CEntityFixedIncreased.FILED_ISCHECK] = entity.ISCHECK;
				row[CEntityFixedIncreased.FILED_CODE] = entity.CODE;
				row[CEntityFixedIncreased.FILED_LOCATION] = entity.LOCATION;
				row[CEntityFixedIncreased.FILED_GROUP] = entity.GROUP;
				row[CEntityFixedIncreased.FILED_FIXED] = entity.FIXED;
				row[CEntityFixedIncreased.FILED_CALCULATION] = entity.CALCULATION;
				row[CEntityFixedIncreased.FILED_ADDITIONAL] = entity.ADDITIONAL;
				row[CEntityFixedIncreased.FILED_COEFFICIENT] = entity.COEFFICIENT;
				row[CEntityFixedIncreased.FILED_ARTIFICIAL] = entity.ARTIFICIAL;
				row[CEntityFixedIncreased.FILED_MATERIAL] = entity.MATERIAL;
				row[CEntityFixedIncreased.FILED_MECHANICAL] = entity.MECHANICAL;
				row[CEntityFixedIncreased.FILED_EXPERTISE] = entity.EXPERTISE;
				row[CEntityFixedIncreased.FILED_REMARK] = entity.REMARK;
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
			this.Columns.Add(CEntityFixedIncreased.FILED_ID, typeof(System.Int32));
			this.Columns.Add(CEntityFixedIncreased.FILED_PARENTID, typeof(System.Int32));
			this.Columns.Add(CEntityFixedIncreased.FILED_NAME, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_ISCHECK, typeof(System.Boolean));
			this.Columns.Add(CEntityFixedIncreased.FILED_CODE, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_LOCATION, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_GROUP, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_FIXED, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_CALCULATION, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_ADDITIONAL, typeof(System.Decimal));
			this.Columns.Add(CEntityFixedIncreased.FILED_COEFFICIENT, typeof(System.Decimal));
			this.Columns.Add(CEntityFixedIncreased.FILED_ARTIFICIAL, typeof(System.Decimal));
			this.Columns.Add(CEntityFixedIncreased.FILED_MATERIAL, typeof(System.Decimal));
			this.Columns.Add(CEntityFixedIncreased.FILED_MECHANICAL, typeof(System.Decimal));
			this.Columns.Add(CEntityFixedIncreased.FILED_EXPERTISE, typeof(System.String));
			this.Columns.Add(CEntityFixedIncreased.FILED_REMARK, typeof(System.String));
		}
	}
}
