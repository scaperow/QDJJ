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
	///OTHERPROJECT实体集合类
	/// </summary>
	[Serializable]
    public class CTEntitiesOtherProject : DataTable
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntityOtherProject m_CEntityOtherProject;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntitiesOtherProject()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntitiesOtherProject(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntityOtherProject this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntityOtherProject;
				if (this.Rows.Count > 0)
				{
					m_CEntityOtherProject = new CEntityOtherProject();
					m_CEntityOtherProject.ID		 = ToolKit.ParseInt(this.Rows[index][CEntityOtherProject.FILED_ID]);
					m_CEntityOtherProject.PARENTID		 = ToolKit.ParseInt(this.Rows[index][CEntityOtherProject.FILED_PARENTID]);
					m_CEntityOtherProject.NUMBER		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_NUMBER]);
					m_CEntityOtherProject.NAME		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_NAME]);
					m_CEntityOtherProject.UNIT		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_UNIT]);
					m_CEntityOtherProject.QUANTITIES		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_QUANTITIES]);
					m_CEntityOtherProject.CALCULATION		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_CALCULATION]);
					m_CEntityOtherProject.COEFFICIENT		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_COEFFICIENT]);
					m_CEntityOtherProject.UNITPRICE		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_UNITPRICE]);
					m_CEntityOtherProject.COMBINEDPRICE		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_COMBINEDPRICE]);
					m_CEntityOtherProject.REMARK		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_REMARK]);
					this.m_index = index;
					return m_CEntityOtherProject;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityOtherProject.FILED_ID] = value.ID; 
				this.Rows[index][CEntityOtherProject.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntityOtherProject.FILED_NUMBER] = value.NUMBER; 
				this.Rows[index][CEntityOtherProject.FILED_NAME] = value.NAME; 
				this.Rows[index][CEntityOtherProject.FILED_UNIT] = value.UNIT; 
				this.Rows[index][CEntityOtherProject.FILED_QUANTITIES] = value.QUANTITIES; 
				this.Rows[index][CEntityOtherProject.FILED_CALCULATION] = value.CALCULATION; 
				this.Rows[index][CEntityOtherProject.FILED_COEFFICIENT] = value.COEFFICIENT; 
				this.Rows[index][CEntityOtherProject.FILED_UNITPRICE] = value.UNITPRICE; 
				this.Rows[index][CEntityOtherProject.FILED_COMBINEDPRICE] = value.COMBINEDPRICE; 
				this.Rows[index][CEntityOtherProject.FILED_REMARK] = value.REMARK; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntityOtherProject entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityOtherProject.FILED_ID] = entity.ID;
				row[CEntityOtherProject.FILED_PARENTID] = entity.PARENTID;
				row[CEntityOtherProject.FILED_NUMBER] = entity.NUMBER;
				row[CEntityOtherProject.FILED_NAME] = entity.NAME;
				row[CEntityOtherProject.FILED_UNIT] = entity.UNIT;
				row[CEntityOtherProject.FILED_QUANTITIES] = entity.QUANTITIES;
				row[CEntityOtherProject.FILED_CALCULATION] = entity.CALCULATION;
				row[CEntityOtherProject.FILED_COEFFICIENT] = entity.COEFFICIENT;
				row[CEntityOtherProject.FILED_UNITPRICE] = entity.UNITPRICE;
				row[CEntityOtherProject.FILED_COMBINEDPRICE] = entity.COMBINEDPRICE;
				row[CEntityOtherProject.FILED_REMARK] = entity.REMARK;
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
			this.Columns.Add(CEntityOtherProject.FILED_ID, typeof(System.Int32));
			this.Columns.Add(CEntityOtherProject.FILED_PARENTID, typeof(System.Int32));
			this.Columns.Add(CEntityOtherProject.FILED_NUMBER, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_NAME, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_UNIT, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_QUANTITIES, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_CALCULATION, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_COEFFICIENT, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_UNITPRICE, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_COMBINEDPRICE, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_REMARK, typeof(System.String));
		}
	}
}
