using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;
namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    ///工料机实体集合类
    /// </summary>
    [Serializable]
    public class CTEntitiesQuantityUnit : DataTable
    {
        #region----------------------行计算公式---------------------------------
        /// <summary>
        /// 定额和价公式
        /// </summary>
        public readonly string DEHJ = string.Format("{0} * {1}", CEntityQuantityUnit.FILED_DEDJ, CEntityQuantityUnit.FILED_YSXHL);
        /// <summary>
        /// 市场和价公式
        /// </summary>
        public readonly string SCHJ = string.Format("{0} * {1}", CEntityQuantityUnit.FILED_SCDJ, CEntityQuantityUnit.FILED_XHL);
        /// <summary>
        /// 数量公式
        /// </summary>
        public readonly string SL = string.Format("{0} * {1}", CEntityQuantityUnit.FILED_XHL, CEntityQuantityUnit.FILED_GCL);
        /// <summary>
        /// 价差公式
        /// </summary>
        public readonly string JC = string.Format("({0} - {1}) * {2}", CEntityQuantityUnit.FILED_SCDJ, CEntityQuantityUnit.FILED_DEDJ, CEntityQuantityUnit.FILED_XHL);
        #endregion

        /// <summary>
        ///记录索引的值(私有成员)默认为-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// 成员实体(避免重复取索引)
        /// </summary>
        private CEntityQuantityUnit m_CEntityQuantityUnit;
        /// <summary>
        ///构造函数
        /// </summary>
        public CTEntitiesQuantityUnit()
        {
            this.buliderTable();
        }

        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntitiesQuantityUnit(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }



        /// <summary>
        /// 获取当前集合指定行的实体对象
        /// </summary>
        /// <param name="index">集合中行的索引</param>
        /// <returns>相关的实体对象(没有记录则返回空)</returns>
        public CEntityQuantityUnit this[int index]
        {
            get
            {
                //如果前一次执行已经转换过当前索引则直接返回
                if (index == this.m_index) return this.m_CEntityQuantityUnit;
                if (this.Rows.Count > 0)
                {
                    m_CEntityQuantityUnit = new CEntityQuantityUnit();
                    m_CEntityQuantityUnit.ID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_ID]);
                    m_CEntityQuantityUnit.XID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_XID]);
                    m_CEntityQuantityUnit.DXID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_DXID]);
                    m_CEntityQuantityUnit.DWID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_DWID]);
                    m_CEntityQuantityUnit.QID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_QID]);
                    m_CEntityQuantityUnit.ZID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_ZID]);
                    m_CEntityQuantityUnit.ZCID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_ZCID]);
                    m_CEntityQuantityUnit.ZCLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_ZCLB]);
                    m_CEntityQuantityUnit.CJXXID = ToolKit.ParseInt(this.Rows[index][CEntityQuantityUnit.FILED_CJXXID]);
                    m_CEntityQuantityUnit.YSBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_YSBH]);
                    m_CEntityQuantityUnit.YSMC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_YSMC]);
                    m_CEntityQuantityUnit.YSDW = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_YSDW]);
                    m_CEntityQuantityUnit.YSXHL = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_YSXHL]);
                    m_CEntityQuantityUnit.DEDJ = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_DEDJ]);
                    m_CEntityQuantityUnit.DEHJ = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_DEHJ]);
                    m_CEntityQuantityUnit.BH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_BH]);
                    m_CEntityQuantityUnit.LB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_LB]);
                    m_CEntityQuantityUnit.SDCLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_SDCLB]);
                    m_CEntityQuantityUnit.SDCXS = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_SDCXS]);
                    m_CEntityQuantityUnit.SDCHJ = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_SDCHJ]);
                    m_CEntityQuantityUnit.MC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_MC]);
                    m_CEntityQuantityUnit.GGXH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_GGXH]);
                    m_CEntityQuantityUnit.DW = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_DW]);
                    m_CEntityQuantityUnit.SCDJ = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_SCDJ]);
                    m_CEntityQuantityUnit.SCHJ = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_SCHJ]);
                    m_CEntityQuantityUnit.XHL = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_XHL]);
                    m_CEntityQuantityUnit.GCL = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_GCL]);
                    m_CEntityQuantityUnit.JC = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_SL]);
                    m_CEntityQuantityUnit.SL = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityQuantityUnit.FILED_JC]);
                    m_CEntityQuantityUnit.IFPB = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFPB]);
                    m_CEntityQuantityUnit.IFZG = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFZG]);
                    m_CEntityQuantityUnit.IFJG = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFJG]);
                    m_CEntityQuantityUnit.IFYG = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFYG]);
                    m_CEntityQuantityUnit.IFFX = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFFX]);
                    m_CEntityQuantityUnit.IFSDSL = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFSDSL]);
                    m_CEntityQuantityUnit.IFSDSCDJ = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFSDSCDJ]);
                    m_CEntityQuantityUnit.IFSDGLJ = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFSDGLJ]);
                    m_CEntityQuantityUnit.IFSDXHL = ToolKit.ParseBoolen(this.Rows[index][CEntityQuantityUnit.FILED_IFSDXHL]);
                    m_CEntityQuantityUnit.SSKLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_SSKLB]);
                    m_CEntityQuantityUnit.SSXMLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_SSXMLB]);
                    m_CEntityQuantityUnit.SSXM = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_SSXM]);
                    m_CEntityQuantityUnit.GLJBZ = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_GLJBZ]);
                    m_CEntityQuantityUnit.ZJCS = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityQuantityUnit.FILED_ZJCS]);
                    this.m_index = index;
                    return m_CEntityQuantityUnit;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntityQuantityUnit.FILED_ID] = value.ID;
                this.Rows[index][CEntityQuantityUnit.FILED_XID] = value.XID;
                this.Rows[index][CEntityQuantityUnit.FILED_DXID] = value.DXID;
                this.Rows[index][CEntityQuantityUnit.FILED_DWID] = value.DWID;
                this.Rows[index][CEntityQuantityUnit.FILED_QID] = value.QID;
                this.Rows[index][CEntityQuantityUnit.FILED_ZID] = value.ZID;
                this.Rows[index][CEntityQuantityUnit.FILED_ZCID] = value.ZCID;
                this.Rows[index][CEntityQuantityUnit.FILED_ZCLB] = value.ZCLB;
                this.Rows[index][CEntityQuantityUnit.FILED_CJXXID] = value.CJXXID;
                this.Rows[index][CEntityQuantityUnit.FILED_YSBH] = value.YSBH;
                this.Rows[index][CEntityQuantityUnit.FILED_YSMC] = value.YSMC;
                this.Rows[index][CEntityQuantityUnit.FILED_YSDW] = value.YSDW;
                this.Rows[index][CEntityQuantityUnit.FILED_YSXHL] = value.YSXHL;
                this.Rows[index][CEntityQuantityUnit.FILED_DEDJ] = value.DEDJ;
                this.Rows[index][CEntityQuantityUnit.FILED_DEHJ] = value.DEHJ;
                this.Rows[index][CEntityQuantityUnit.FILED_BH] = value.BH;
                this.Rows[index][CEntityQuantityUnit.FILED_LB] = value.LB;
                this.Rows[index][CEntityQuantityUnit.FILED_SDCLB] = value.SDCLB;
                this.Rows[index][CEntityQuantityUnit.FILED_SDCXS] = value.SDCXS;
                this.Rows[index][CEntityQuantityUnit.FILED_SDCHJ] = value.SDCHJ;
                this.Rows[index][CEntityQuantityUnit.FILED_MC] = value.MC;
                this.Rows[index][CEntityQuantityUnit.FILED_GGXH] = value.GGXH;
                this.Rows[index][CEntityQuantityUnit.FILED_DW] = value.DW;
                this.Rows[index][CEntityQuantityUnit.FILED_SCDJ] = value.SCDJ;
                this.Rows[index][CEntityQuantityUnit.FILED_SCHJ] = value.SCHJ;
                this.Rows[index][CEntityQuantityUnit.FILED_XHL] = value.XHL;
                this.Rows[index][CEntityQuantityUnit.FILED_GCL] = value.GCL;
                this.Rows[index][CEntityQuantityUnit.FILED_JC] = value.JC;
                this.Rows[index][CEntityQuantityUnit.FILED_SL] = value.SL;
                this.Rows[index][CEntityQuantityUnit.FILED_IFPB] = value.IFPB;
                this.Rows[index][CEntityQuantityUnit.FILED_IFZG] = value.IFZG;
                this.Rows[index][CEntityQuantityUnit.FILED_IFJG] = value.IFJG;
                this.Rows[index][CEntityQuantityUnit.FILED_IFYG] = value.IFYG;
                this.Rows[index][CEntityQuantityUnit.FILED_IFFX] = value.IFFX;
                this.Rows[index][CEntityQuantityUnit.FILED_IFSDSL] = value.IFSDSL;
                this.Rows[index][CEntityQuantityUnit.FILED_IFSDSCDJ] = value.IFSDSCDJ;
                this.Rows[index][CEntityQuantityUnit.FILED_IFSDGLJ] = value.IFSDGLJ;
                this.Rows[index][CEntityQuantityUnit.FILED_IFSDXHL] = value.IFSDXHL;
                this.Rows[index][CEntityQuantityUnit.FILED_SSKLB] = value.SSKLB;
                this.Rows[index][CEntityQuantityUnit.FILED_SSXMLB] = value.SSXMLB;
                this.Rows[index][CEntityQuantityUnit.FILED_SSXM] = value.SSXM;
                this.Rows[index][CEntityQuantityUnit.FILED_GLJBZ] = value.GLJBZ;
                this.Rows[index][CEntityQuantityUnit.FILED_ZJCS] = value.ZJCS;
            }
        }
        /// <summary>
        /// 当前实体集合中追加单个实体
        /// </summary>
        /// <param name="entity">要追加的实体对象</param>
        /// <returns>追加的行的索引(当前)</returns>
        public int AppendEntityInfo(CEntityQuantityUnit entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntityQuantityUnit.FILED_XID] = entity.XID;
                row[CEntityQuantityUnit.FILED_DXID] = entity.DXID;
                row[CEntityQuantityUnit.FILED_DWID] = entity.DWID;
                row[CEntityQuantityUnit.FILED_QID] = entity.QID;
                row[CEntityQuantityUnit.FILED_ZID] = entity.ZID;
                row[CEntityQuantityUnit.FILED_ZCID] = entity.ZCID;
                row[CEntityQuantityUnit.FILED_ZCLB] = entity.ZCLB;
                row[CEntityQuantityUnit.FILED_CJXXID] = entity.CJXXID;
                row[CEntityQuantityUnit.FILED_YSBH] = entity.YSBH;
                row[CEntityQuantityUnit.FILED_YSMC] = entity.YSMC;
                row[CEntityQuantityUnit.FILED_YSDW] = entity.YSDW;
                row[CEntityQuantityUnit.FILED_YSXHL] = entity.YSXHL;
                row[CEntityQuantityUnit.FILED_DEDJ] = entity.DEDJ;
                row[CEntityQuantityUnit.FILED_BH] = entity.BH;
                row[CEntityQuantityUnit.FILED_LB] = entity.LB;
                row[CEntityQuantityUnit.FILED_SDCLB] = entity.SDCLB;
                row[CEntityQuantityUnit.FILED_SDCXS] = entity.SDCXS;
                row[CEntityQuantityUnit.FILED_SDCHJ] = entity.SDCHJ;
                row[CEntityQuantityUnit.FILED_MC] = entity.MC;
                row[CEntityQuantityUnit.FILED_GGXH] = entity.GGXH;
                row[CEntityQuantityUnit.FILED_DW] = entity.DW;
                row[CEntityQuantityUnit.FILED_SCDJ] = entity.SCDJ;
                row[CEntityQuantityUnit.FILED_XHL] = entity.XHL;
                row[CEntityQuantityUnit.FILED_GCL] = entity.GCL;
                row[CEntityQuantityUnit.FILED_IFPB] = entity.IFPB;
                row[CEntityQuantityUnit.FILED_IFZG] = entity.IFZG;
                row[CEntityQuantityUnit.FILED_IFJG] = entity.IFJG;
                row[CEntityQuantityUnit.FILED_IFYG] = entity.IFYG;
                row[CEntityQuantityUnit.FILED_IFFX] = entity.IFFX;
                row[CEntityQuantityUnit.FILED_IFSDSL] = entity.IFSDSL;
                row[CEntityQuantityUnit.FILED_IFSDSCDJ] = entity.IFSDSCDJ;
                row[CEntityQuantityUnit.FILED_IFSDGLJ] = entity.IFSDGLJ;
                row[CEntityQuantityUnit.FILED_IFSDXHL] = entity.IFSDXHL;
                row[CEntityQuantityUnit.FILED_SSKLB] = entity.SSKLB;
                row[CEntityQuantityUnit.FILED_SSXMLB] = entity.SSXMLB;
                row[CEntityQuantityUnit.FILED_SSXM] = entity.SSXM;
                row[CEntityQuantityUnit.FILED_GLJBZ] = entity.GLJBZ;
                row[CEntityQuantityUnit.FILED_ZJCS] = entity.ZJCS;
                //自增长列
                //row[CEntityQuantityUnit.FILED_ID] = entity.ID;
                //需要计算赋值列
                //row[CEntityQuantityUnit.FILED_DEHJ] = entity.DEHJ;
                //row[CEntityQuantityUnit.FILED_SCHJ] = entity.SCHJ;
                //row[CEntityQuantityUnit.FILED_JC] = entity.JC;
                //row[CEntityQuantityUnit.FILED_SL] = entity.SL;
                this.Rows.Add(row);
                return Convert.ToInt32(row[CEntityQuantityUnit.FILED_ID]);
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
            this.Columns.Add(CEntityQuantityUnit.FILED_ID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_XID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_DXID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_DWID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_QID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_ZID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_ZCID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_ZCLB, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_CJXXID, typeof(System.Int32));
            this.Columns.Add(CEntityQuantityUnit.FILED_YSBH, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_YSMC, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_YSDW, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_YSXHL, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_DEDJ, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_DEHJ, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_BH, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_LB, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_SDCLB, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_SDCXS, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_SDCHJ, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_MC, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_GGXH, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_DW, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_SCDJ, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_SCHJ, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_XHL, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_GCL, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_JC, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_SL, typeof(System.Decimal));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFPB, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFZG, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFJG, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFYG, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFFX, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFSDSL, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFSDSCDJ, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFSDGLJ, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_IFSDXHL, typeof(System.Boolean));
            this.Columns.Add(CEntityQuantityUnit.FILED_SSKLB, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_SSXMLB, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_SSXM, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_GLJBZ, typeof(System.String));
            this.Columns.Add(CEntityQuantityUnit.FILED_ZJCS, typeof(System.String));
            //行计算
            this.Columns[CEntityQuantityUnit.FILED_DEHJ].Expression = DEHJ;
            this.Columns[CEntityQuantityUnit.FILED_SCHJ].Expression = SCHJ;
            this.Columns[CEntityQuantityUnit.FILED_SL].Expression = SL;
            this.Columns[CEntityQuantityUnit.FILED_JC].Expression = JC;
            //设置自动增长列
            this.Columns[CEntityQuantityUnit.FILED_ID].AutoIncrement = true;
            this.Columns[CEntityQuantityUnit.FILED_ID].AutoIncrementSeed = 1;
            this.Columns[CEntityQuantityUnit.FILED_ID].AutoIncrementStep = 1;
        }
    }
}
