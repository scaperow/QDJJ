/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年37月04日　06时11分27秒
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
	///QUANTITYUNITSUMMARY实体集合类
	/// </summary>
	[Serializable]
    public class CTEntitiesQuantityUnitSummary : DataTable
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntityQuantityUnitSummary m_CEntityQuantityUnitSummary;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntitiesQuantityUnitSummary()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntitiesQuantityUnitSummary(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntityQuantityUnitSummary this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntityQuantityUnitSummary;
				if (this.Rows.Count > 0)
				{
					m_CEntityQuantityUnitSummary = new CEntityQuantityUnitSummary();
					m_CEntityQuantityUnitSummary.ID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_ID]);
					m_CEntityQuantityUnitSummary.XID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_XID]);
					m_CEntityQuantityUnitSummary.DXID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_DXID]);
					m_CEntityQuantityUnitSummary.DWID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_DWID]);
					m_CEntityQuantityUnitSummary.QID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_QID]);
					m_CEntityQuantityUnitSummary.ZID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_ZID]);
					m_CEntityQuantityUnitSummary.ZCID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_ZCID]);
					m_CEntityQuantityUnitSummary.ZCLB		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_ZCLB]);
					m_CEntityQuantityUnitSummary.CJXXID		 = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnitSummary.FILED_CJXXID]);
					m_CEntityQuantityUnitSummary.YSBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_YSBH]);
					m_CEntityQuantityUnitSummary.YSMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_YSMC]);
					m_CEntityQuantityUnitSummary.YSDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_YSDW]);
					m_CEntityQuantityUnitSummary.YSXHL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_YSXHL]);
					m_CEntityQuantityUnitSummary.DEDJ		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_DEDJ]);
					m_CEntityQuantityUnitSummary.DEHJ		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_DEHJ]);
					m_CEntityQuantityUnitSummary.BH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_BH]);
					m_CEntityQuantityUnitSummary.LB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_LB]);
					m_CEntityQuantityUnitSummary.SDCLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SDCLB]);
					m_CEntityQuantityUnitSummary.SDCXS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SDCXS]);
					m_CEntityQuantityUnitSummary.SDCHJ		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SDCHJ]);
					m_CEntityQuantityUnitSummary.MC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_MC]);
					m_CEntityQuantityUnitSummary.GGXH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_GGXH]);
					m_CEntityQuantityUnitSummary.DW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_DW]);
					m_CEntityQuantityUnitSummary.SCDJ		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SCDJ]);
					m_CEntityQuantityUnitSummary.SCHJ		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SCHJ]);
					m_CEntityQuantityUnitSummary.XHL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_XHL]);
					m_CEntityQuantityUnitSummary.SL		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SL]);
					m_CEntityQuantityUnitSummary.SLH		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SLH]);
					m_CEntityQuantityUnitSummary.DJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_DJC]);
					m_CEntityQuantityUnitSummary.HJC		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnitSummary.FILED_HJC]);
					m_CEntityQuantityUnitSummary.IFPB		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFPB]);
					m_CEntityQuantityUnitSummary.IFZG		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFZG]);
					m_CEntityQuantityUnitSummary.IFJG		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFJG]);
					m_CEntityQuantityUnitSummary.IFYG		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFYG]);
					m_CEntityQuantityUnitSummary.IFFX		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFFX]);
					m_CEntityQuantityUnitSummary.IFSDSL		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFSDSL]);
					m_CEntityQuantityUnitSummary.IFSDSCDJ		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFSDSCDJ]);
					m_CEntityQuantityUnitSummary.IFSDGLJ		 = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnitSummary.FILED_IFSDGLJ]);
					m_CEntityQuantityUnitSummary.SSKLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SSKLB]);
					m_CEntityQuantityUnitSummary.SSXMLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SSXMLB]);
					m_CEntityQuantityUnitSummary.SSXM		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_SSXM]);
					m_CEntityQuantityUnitSummary.GLJBZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_GLJBZ]);
					m_CEntityQuantityUnitSummary.GLJID		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnitSummary.FILED_GLJID]);
					this.m_index = index;
					return m_CEntityQuantityUnitSummary;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityQuantityUnitSummary.FILED_ID] = value.ID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_XID] = value.XID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_DXID] = value.DXID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_DWID] = value.DWID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_QID] = value.QID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_ZID] = value.ZID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_ZCID] = value.ZCID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_ZCLB] = value.ZCLB; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_CJXXID] = value.CJXXID; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_YSBH] = value.YSBH; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_YSMC] = value.YSMC; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_YSDW] = value.YSDW; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_YSXHL] = value.YSXHL; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_DEDJ] = value.DEDJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_DEHJ] = value.DEHJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_BH] = value.BH; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_LB] = value.LB; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SDCLB] = value.SDCLB; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SDCXS] = value.SDCXS; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SDCHJ] = value.SDCHJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_MC] = value.MC; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_GGXH] = value.GGXH; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_DW] = value.DW; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SCDJ] = value.SCDJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SCHJ] = value.SCHJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_XHL] = value.XHL; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SL] = value.SL; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SLH] = value.SLH; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_DJC] = value.DJC; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_HJC] = value.HJC; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFPB] = value.IFPB; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFZG] = value.IFZG; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFJG] = value.IFJG; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFYG] = value.IFYG; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFFX] = value.IFFX; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFSDSL] = value.IFSDSL; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFSDSCDJ] = value.IFSDSCDJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_IFSDGLJ] = value.IFSDGLJ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SSKLB] = value.SSKLB; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SSXMLB] = value.SSXMLB; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_SSXM] = value.SSXM; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_GLJBZ] = value.GLJBZ; 
				this.Rows[index][CEntityQuantityUnitSummary.FILED_GLJID] = value.GLJID; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntityQuantityUnitSummary entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityQuantityUnitSummary.FILED_XID] = entity.XID;
				row[CEntityQuantityUnitSummary.FILED_DXID] = entity.DXID;
				row[CEntityQuantityUnitSummary.FILED_DWID] = entity.DWID;
				row[CEntityQuantityUnitSummary.FILED_QID] = entity.QID;
				row[CEntityQuantityUnitSummary.FILED_ZID] = entity.ZID;
				row[CEntityQuantityUnitSummary.FILED_ZCID] = entity.ZCID;
				row[CEntityQuantityUnitSummary.FILED_ZCLB] = entity.ZCLB;
				row[CEntityQuantityUnitSummary.FILED_CJXXID] = entity.CJXXID;
				row[CEntityQuantityUnitSummary.FILED_YSBH] = entity.YSBH;
				row[CEntityQuantityUnitSummary.FILED_YSMC] = entity.YSMC;
				row[CEntityQuantityUnitSummary.FILED_YSDW] = entity.YSDW;
				row[CEntityQuantityUnitSummary.FILED_YSXHL] = entity.YSXHL;
				row[CEntityQuantityUnitSummary.FILED_DEDJ] = entity.DEDJ;
				row[CEntityQuantityUnitSummary.FILED_DEHJ] = entity.DEHJ;
				row[CEntityQuantityUnitSummary.FILED_BH] = entity.BH;
				row[CEntityQuantityUnitSummary.FILED_LB] = entity.LB;
				row[CEntityQuantityUnitSummary.FILED_SDCLB] = entity.SDCLB;
				row[CEntityQuantityUnitSummary.FILED_SDCXS] = entity.SDCXS;
				row[CEntityQuantityUnitSummary.FILED_SDCHJ] = entity.SDCHJ;
				row[CEntityQuantityUnitSummary.FILED_MC] = entity.MC;
				row[CEntityQuantityUnitSummary.FILED_GGXH] = entity.GGXH;
				row[CEntityQuantityUnitSummary.FILED_DW] = entity.DW;
				row[CEntityQuantityUnitSummary.FILED_SCDJ] = entity.SCDJ;
				row[CEntityQuantityUnitSummary.FILED_SCHJ] = entity.SCHJ;
				row[CEntityQuantityUnitSummary.FILED_XHL] = entity.XHL;
				row[CEntityQuantityUnitSummary.FILED_SL] = entity.SL;
				row[CEntityQuantityUnitSummary.FILED_SLH] = entity.SLH;
				row[CEntityQuantityUnitSummary.FILED_DJC] = entity.DJC;
				row[CEntityQuantityUnitSummary.FILED_HJC] = entity.HJC;
				row[CEntityQuantityUnitSummary.FILED_IFPB] = entity.IFPB;
				row[CEntityQuantityUnitSummary.FILED_IFZG] = entity.IFZG;
				row[CEntityQuantityUnitSummary.FILED_IFJG] = entity.IFJG;
				row[CEntityQuantityUnitSummary.FILED_IFYG] = entity.IFYG;
				row[CEntityQuantityUnitSummary.FILED_IFFX] = entity.IFFX;
				row[CEntityQuantityUnitSummary.FILED_IFSDSL] = entity.IFSDSL;
				row[CEntityQuantityUnitSummary.FILED_IFSDSCDJ] = entity.IFSDSCDJ;
				row[CEntityQuantityUnitSummary.FILED_IFSDGLJ] = entity.IFSDGLJ;
				row[CEntityQuantityUnitSummary.FILED_SSKLB] = entity.SSKLB;
				row[CEntityQuantityUnitSummary.FILED_SSXMLB] = entity.SSXMLB;
				row[CEntityQuantityUnitSummary.FILED_SSXM] = entity.SSXM;
				row[CEntityQuantityUnitSummary.FILED_GLJBZ] = entity.GLJBZ;
				row[CEntityQuantityUnitSummary.FILED_GLJID] = entity.GLJID;
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
        /// 
		/// </summary>
		private void buliderTable()
		{
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_ID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_XID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_DXID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_DWID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_QID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_ZID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_ZCID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_ZCLB, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_CJXXID, typeof(System.Int32));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_YSBH, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_YSMC, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_YSDW, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_YSXHL, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_DEDJ, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_DEHJ, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_BH, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_LB, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SDCLB, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SDCXS, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SDCHJ, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_MC, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_GGXH, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_DW, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SCDJ, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SCHJ, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_XHL, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SL, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SLH, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_DJC, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_HJC, typeof(System.Decimal));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFPB, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFZG, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFJG, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFYG, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFFX, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFSDSL, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFSDSCDJ, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_IFSDGLJ, typeof(System.Boolean));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SSKLB, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SSXMLB, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_SSXM, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_GLJBZ, typeof(System.String));
			this.Columns.Add(CEntityQuantityUnitSummary.FILED_GLJID, typeof(System.String));
            //设置自动增长列
            this.Columns[CEntityQuantityUnitSummary.FILED_ID].AutoIncrement = true;
            this.Columns[CEntityQuantityUnitSummary.FILED_ID].AutoIncrementSeed = 1;
            this.Columns[CEntityQuantityUnitSummary.FILED_ID].AutoIncrementStep = 1;
		}
	}
}
