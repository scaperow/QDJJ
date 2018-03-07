/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年04月25日　03时10分15秒
备注:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;
namespace GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///STANDARDCONVERSION实体集合类
	/// </summary>
	[Serializable]
	public class CTEntitiesStandardConversion : 	CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntityStandardConversion m_CEntityStandardConversion;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntitiesStandardConversion()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntitiesStandardConversion(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntityStandardConversion this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntityStandardConversion;
				if (this.Rows.Count > 0)
				{
					m_CEntityStandardConversion = new CEntityStandardConversion();
					m_CEntityStandardConversion.ID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_ID]);
					m_CEntityStandardConversion.XID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_XID]);
					m_CEntityStandardConversion.DID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_DID]);
					m_CEntityStandardConversion.QID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_QID]);
					m_CEntityStandardConversion.ZID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_ZID]);
                    m_CEntityStandardConversion.IFXZ = ToolKit.ParseBoolen(this.Rows[index][CEntityStandardConversion.FILED_IFXZ]);
                    m_CEntityStandardConversion.IFHS = ToolKit.ParseBoolen(this.Rows[index][CEntityStandardConversion.FILED_IFHS]);
					m_CEntityStandardConversion.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_DINGEH]);
					m_CEntityStandardConversion.HUANSLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HUANSLB]);
					m_CEntityStandardConversion.TISXX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_TISXX]);
					m_CEntityStandardConversion.HUANSJS_R		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HUANSJS_R]);
					m_CEntityStandardConversion.HUANSDEH_C		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HUANSDEH_C]);
					m_CEntityStandardConversion.ZENGL_J		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_ZENGL_J]);
					m_CEntityStandardConversion.ZC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_ZC]);
					m_CEntityStandardConversion.SB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_SB]);
					m_CEntityStandardConversion.DJDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_DJDW]);
					m_CEntityStandardConversion.FZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_FZ]);
					m_CEntityStandardConversion.XHLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_XHLB]);
					m_CEntityStandardConversion.THZHC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_THZHC]);
					m_CEntityStandardConversion.THWZFC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_THWZFC]);
					m_CEntityStandardConversion.HSXI		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HSXI]);
					this.m_index = index;
					return m_CEntityStandardConversion;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityStandardConversion.FILED_ID] = value.ID; 
				this.Rows[index][CEntityStandardConversion.FILED_XID] = value.XID; 
				this.Rows[index][CEntityStandardConversion.FILED_DID] = value.DID; 
				this.Rows[index][CEntityStandardConversion.FILED_QID] = value.QID; 
				this.Rows[index][CEntityStandardConversion.FILED_ZID] = value.ZID;
                this.Rows[index][CEntityStandardConversion.FILED_IFXZ] = value.IFXZ; 
                this.Rows[index][CEntityStandardConversion.FILED_IFHS] = value.IFHS; 
				this.Rows[index][CEntityStandardConversion.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntityStandardConversion.FILED_HUANSLB] = value.HUANSLB; 
				this.Rows[index][CEntityStandardConversion.FILED_TISXX] = value.TISXX; 
				this.Rows[index][CEntityStandardConversion.FILED_HUANSJS_R] = value.HUANSJS_R; 
				this.Rows[index][CEntityStandardConversion.FILED_HUANSDEH_C] = value.HUANSDEH_C; 
				this.Rows[index][CEntityStandardConversion.FILED_ZENGL_J] = value.ZENGL_J; 
				this.Rows[index][CEntityStandardConversion.FILED_ZC] = value.ZC; 
				this.Rows[index][CEntityStandardConversion.FILED_SB] = value.SB; 
				this.Rows[index][CEntityStandardConversion.FILED_DJDW] = value.DJDW; 
				this.Rows[index][CEntityStandardConversion.FILED_FZ] = value.FZ; 
				this.Rows[index][CEntityStandardConversion.FILED_XHLB] = value.XHLB; 
				this.Rows[index][CEntityStandardConversion.FILED_THZHC] = value.THZHC; 
				this.Rows[index][CEntityStandardConversion.FILED_THWZFC] = value.THWZFC; 
				this.Rows[index][CEntityStandardConversion.FILED_HSXI] = value.HSXI; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntityStandardConversion entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityStandardConversion.FILED_XID] = entity.XID;
				row[CEntityStandardConversion.FILED_DID] = entity.DID;
				row[CEntityStandardConversion.FILED_QID] = entity.QID;
				row[CEntityStandardConversion.FILED_ZID] = entity.ZID;
                row[CEntityStandardConversion.FILED_IFXZ] = entity.IFXZ;
                row[CEntityStandardConversion.FILED_IFHS] = entity.IFHS;
				row[CEntityStandardConversion.FILED_DINGEH] = entity.DINGEH;
				row[CEntityStandardConversion.FILED_HUANSLB] = entity.HUANSLB;
				row[CEntityStandardConversion.FILED_TISXX] = entity.TISXX;
				row[CEntityStandardConversion.FILED_HUANSJS_R] = entity.HUANSJS_R;
				row[CEntityStandardConversion.FILED_HUANSDEH_C] = entity.HUANSDEH_C;
				row[CEntityStandardConversion.FILED_ZENGL_J] = entity.ZENGL_J;
				row[CEntityStandardConversion.FILED_ZC] = entity.ZC;
				row[CEntityStandardConversion.FILED_SB] = entity.SB;
				row[CEntityStandardConversion.FILED_DJDW] = entity.DJDW;
				row[CEntityStandardConversion.FILED_FZ] = entity.FZ;
				row[CEntityStandardConversion.FILED_XHLB] = entity.XHLB;
				row[CEntityStandardConversion.FILED_THZHC] = entity.THZHC;
				row[CEntityStandardConversion.FILED_THWZFC] = entity.THWZFC;
				row[CEntityStandardConversion.FILED_HSXI] = entity.HSXI;
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
			this.Columns.Add(CEntityStandardConversion.FILED_ID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_XID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_DID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_QID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_ZID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HUANSLB, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_TISXX, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HUANSJS_R, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HUANSDEH_C, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_ZENGL_J, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_ZC, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_SB, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_DJDW, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_FZ, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_XHLB, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_THZHC, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_THWZFC, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HSXI, typeof(System.String));
            this.Columns.Add(CEntityStandardConversion.FILED_IFHS, typeof(System.Boolean));
            this.Columns.Add(CEntityStandardConversion.FILED_IFXZ, typeof(System.Boolean));

            //设置自动增长列
            this.Columns[CEntityStandardConversion.FILED_ID].AutoIncrement = true;
            this.Columns[CEntityStandardConversion.FILED_ID].AutoIncrementSeed = 1;
            this.Columns[CEntityStandardConversion.FILED_ID].AutoIncrementStep = 1;
		}
	}
}
