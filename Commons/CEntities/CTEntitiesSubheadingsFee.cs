using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class CTEntitiesSubheadingsFee : DataTable
    {
        public readonly string JE = string.Format("{0} * {1} * 0.01", CEntitySubheadingsFee.FILED_JSJCJG, CEntitySubheadingsFee.FILED_FL);

        /// <summary>
        ///记录索引的值(私有成员)默认为-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// 成员实体(避免重复取索引)
        /// </summary>
        private CEntitySubheadingsFee m_CEntitySubheadingsFee;
        /// <summary>
        ///构造函数
        /// </summary>
        public CTEntitiesSubheadingsFee()
        {
            this.buliderTable();
        }
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntitiesSubheadingsFee(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// 获取当前集合指定行的实体对象
        /// </summary>
        /// <param name="index">集合中行的索引</param>
        /// <returns>相关的实体对象(没有记录则返回空)</returns>
        public CEntitySubheadingsFee this[int index]
        {
            get
            {
                //如果前一次执行已经转换过当前索引则直接返回
                if (index == this.m_index) return this.m_CEntitySubheadingsFee;
                if (this.Rows.Count > 0)
                {
                    m_CEntitySubheadingsFee = new CEntitySubheadingsFee();
                    m_CEntitySubheadingsFee.ID = ToolKit.ParseInt(this.Rows[index][CEntitySubheadingsFee.FILED_ID]);
                    m_CEntitySubheadingsFee.PARENTID = ToolKit.ParseInt(this.Rows[index][CEntitySubheadingsFee.FILED_PARENTID]);
                    m_CEntitySubheadingsFee.XID = ToolKit.ParseInt(this.Rows[index][CEntitySubheadingsFee.FILED_XID]);
                    m_CEntitySubheadingsFee.DID = ToolKit.ParseInt(this.Rows[index][CEntitySubheadingsFee.FILED_DID]);
                    m_CEntitySubheadingsFee.QID = ToolKit.ParseInt(this.Rows[index][CEntitySubheadingsFee.FILED_QID]);
                    m_CEntitySubheadingsFee.ZID = ToolKit.ParseInt(this.Rows[index][CEntitySubheadingsFee.FILED_ZID]);
                    m_CEntitySubheadingsFee.YYH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntitySubheadingsFee.FILED_YYH]);
                    m_CEntitySubheadingsFee.MC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntitySubheadingsFee.FILED_MC]);
                    m_CEntitySubheadingsFee.BDS = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntitySubheadingsFee.FILED_BDS]);
                    m_CEntitySubheadingsFee.TBJSJC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntitySubheadingsFee.FILED_TBJSJC]);
                    m_CEntitySubheadingsFee.BDJSJC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntitySubheadingsFee.FILED_BDJSJC]);
                    m_CEntitySubheadingsFee.FL = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntitySubheadingsFee.FILED_FL]);
                    m_CEntitySubheadingsFee.JSJCJG = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntitySubheadingsFee.FILED_JSJCJG]);
                    m_CEntitySubheadingsFee.JE = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntitySubheadingsFee.FILED_JE]);
                    m_CEntitySubheadingsFee.BEIZHU = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntitySubheadingsFee.FILED_BEIZHU]);
                    this.m_index = index;
                    return m_CEntitySubheadingsFee;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntitySubheadingsFee.FILED_ID] = value.ID;
                this.Rows[index][CEntitySubheadingsFee.FILED_PARENTID] = value.PARENTID;
                this.Rows[index][CEntitySubheadingsFee.FILED_XID] = value.XID;
                this.Rows[index][CEntitySubheadingsFee.FILED_DID] = value.DID;
                this.Rows[index][CEntitySubheadingsFee.FILED_QID] = value.QID;
                this.Rows[index][CEntitySubheadingsFee.FILED_ZID] = value.ZID;
                this.Rows[index][CEntitySubheadingsFee.FILED_YYH] = value.YYH;
                this.Rows[index][CEntitySubheadingsFee.FILED_MC] = value.MC;
                this.Rows[index][CEntitySubheadingsFee.FILED_BDS] = value.BDS;
                this.Rows[index][CEntitySubheadingsFee.FILED_TBJSJC] = value.TBJSJC;
                this.Rows[index][CEntitySubheadingsFee.FILED_BDJSJC] = value.BDJSJC;
                this.Rows[index][CEntitySubheadingsFee.FILED_FL] = value.FL;
                this.Rows[index][CEntitySubheadingsFee.FILED_JSJCJG] = value.JSJCJG;
                this.Rows[index][CEntitySubheadingsFee.FILED_JE] = value.JE;
                this.Rows[index][CEntitySubheadingsFee.FILED_BEIZHU] = value.BEIZHU;
            }
        }
        /// <summary>
        /// 当前实体集合中追加单个实体
        /// </summary>
        /// <param name="entity">要追加的实体对象</param>
        /// <returns>追加的行的索引(当前)</returns>
        public int AppendEntityInfo(CEntitySubheadingsFee entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntitySubheadingsFee.FILED_ID] = entity.ID;
                row[CEntitySubheadingsFee.FILED_PARENTID] = entity.PARENTID;
                row[CEntitySubheadingsFee.FILED_XID] = entity.XID;
                row[CEntitySubheadingsFee.FILED_DID] = entity.DID;
                row[CEntitySubheadingsFee.FILED_QID] = entity.QID;
                row[CEntitySubheadingsFee.FILED_ZID] = entity.ZID;
                row[CEntitySubheadingsFee.FILED_YYH] = entity.YYH;
                row[CEntitySubheadingsFee.FILED_MC] = entity.MC;
                row[CEntitySubheadingsFee.FILED_BDS] = entity.BDS;
                row[CEntitySubheadingsFee.FILED_TBJSJC] = entity.TBJSJC;
                row[CEntitySubheadingsFee.FILED_BDJSJC] = entity.BDJSJC;
                row[CEntitySubheadingsFee.FILED_FL] = entity.FL;
                row[CEntitySubheadingsFee.FILED_JSJCJG] = entity.JSJCJG;
                //row[CEntitySubheadingsFee.FILED_JE] = entity.JE;
                row[CEntitySubheadingsFee.FILED_BEIZHU] = entity.BEIZHU;
                this.Rows.Add(row);
                return Convert.ToInt32(row[CEntitySubheadingsFee.FILED_ID]);
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
            this.Columns.Add(CEntitySubheadingsFee.FILED_ID, typeof(System.Int32));
            this.Columns.Add(CEntitySubheadingsFee.FILED_PARENTID, typeof(System.Int32));
            this.Columns.Add(CEntitySubheadingsFee.FILED_XID, typeof(System.Int32));
            this.Columns.Add(CEntitySubheadingsFee.FILED_DID, typeof(System.Int32));
            this.Columns.Add(CEntitySubheadingsFee.FILED_QID, typeof(System.Int32));
            this.Columns.Add(CEntitySubheadingsFee.FILED_ZID, typeof(System.Int32));
            this.Columns.Add(CEntitySubheadingsFee.FILED_YYH, typeof(System.String));
            this.Columns.Add(CEntitySubheadingsFee.FILED_MC, typeof(System.String));
            this.Columns.Add(CEntitySubheadingsFee.FILED_BDS, typeof(System.String));
            this.Columns.Add(CEntitySubheadingsFee.FILED_TBJSJC, typeof(System.String));
            this.Columns.Add(CEntitySubheadingsFee.FILED_BDJSJC, typeof(System.String));
            this.Columns.Add(CEntitySubheadingsFee.FILED_FL, typeof(System.Decimal));
            this.Columns.Add(CEntitySubheadingsFee.FILED_JSJCJG, typeof(System.Decimal));
            this.Columns.Add(CEntitySubheadingsFee.FILED_JE, typeof(System.Decimal));
            this.Columns.Add(CEntitySubheadingsFee.FILED_BEIZHU, typeof(System.String));
            //行计算
            //this.Columns[CEntitySubheadingsFee.FILED_JE].Expression = JE;
            ////设置自动增长列
            //this.Columns[CEntitySubheadingsFee.FILED_ID].AutoIncrement = true;
            //this.Columns[CEntitySubheadingsFee.FILED_ID].AutoIncrementSeed = 1;
            //this.Columns[CEntitySubheadingsFee.FILED_ID].AutoIncrementStep = 1;
        }
    }
}
