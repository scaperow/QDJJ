/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年01月26日　12时09分47秒
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
    ///TransitPriceLibrary实体集合类
    /// </summary>
    [Serializable]
    public class CTEntitiesTransitPriceLibrary : DataTable
    {
        /// <summary>
        ///记录索引的值(私有成员)默认为-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// 成员实体(避免重复取索引)
        /// </summary>
        private CEntityTransitPriceLibrary m_CEntityTransitPriceLibrary;
        /// <summary>
        ///构造函数
        /// </summary>
        public CTEntitiesTransitPriceLibrary()
        {
            this.buliderTable();
        }
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntitiesTransitPriceLibrary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// 获取当前集合指定行的实体对象
        /// </summary>
        /// <param name="index">集合中行的索引</param>
        /// <returns>相关的实体对象(没有记录则返回空)</returns>
        public CEntityTransitPriceLibrary this[int index]
        {
            get
            {
                //如果前一次执行已经转换过当前索引则直接返回
                if (index == this.m_index) return this.m_CEntityTransitPriceLibrary;
                if (this.Rows.Count > 0)
                {
                    m_CEntityTransitPriceLibrary = new CEntityTransitPriceLibrary();
                    m_CEntityTransitPriceLibrary.ID = ToolKit.ParseInt(this.Rows[index][CEntityTransitPriceLibrary.FILED_ID]);
                    m_CEntityTransitPriceLibrary.CAIJBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTransitPriceLibrary.FILED_CAIJBH]);
                    m_CEntityTransitPriceLibrary.LIBRARYTYPE = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTransitPriceLibrary.FILED_LIBRARYTYPE]);
                    m_CEntityTransitPriceLibrary.SOURCE = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTransitPriceLibrary.FILED_SOURCE]);
                    m_CEntityTransitPriceLibrary.ADDTYPE = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTransitPriceLibrary.FILED_ADDTYPE]);
                    m_CEntityTransitPriceLibrary.ADDCOUNT = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTransitPriceLibrary.FILED_ADDCOUNT]);
                    this.m_index = index;
                    return m_CEntityTransitPriceLibrary;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntityTransitPriceLibrary.FILED_ID] = value.ID;
                this.Rows[index][CEntityTransitPriceLibrary.FILED_CAIJBH] = value.CAIJBH;
                this.Rows[index][CEntityTransitPriceLibrary.FILED_LIBRARYTYPE] = value.LIBRARYTYPE;
                this.Rows[index][CEntityTransitPriceLibrary.FILED_SOURCE] = value.SOURCE;
                this.Rows[index][CEntityTransitPriceLibrary.FILED_ADDTYPE] = value.ADDTYPE;
                this.Rows[index][CEntityTransitPriceLibrary.FILED_ADDCOUNT] = value.ADDCOUNT;
            }
        }
        /// <summary>
        /// 当前实体集合中追加单个实体
        /// </summary>
        /// <param name="entity">要追加的实体对象</param>
        /// <returns>追加的行的索引(当前)</returns>
        public int AppendEntityInfo(CEntityTransitPriceLibrary entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntityTransitPriceLibrary.FILED_ID] = entity.ID;
                row[CEntityTransitPriceLibrary.FILED_CAIJBH] = entity.CAIJBH;
                row[CEntityTransitPriceLibrary.FILED_LIBRARYTYPE] = entity.LIBRARYTYPE;
                row[CEntityTransitPriceLibrary.FILED_SOURCE] = entity.SOURCE;
                row[CEntityTransitPriceLibrary.FILED_ADDTYPE] = entity.ADDTYPE;
                row[CEntityTransitPriceLibrary.FILED_ADDCOUNT] = entity.ADDCOUNT;
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
            this.Columns.Add(CEntityTransitPriceLibrary.FILED_ID, typeof(System.Int32));
            this.Columns.Add(CEntityTransitPriceLibrary.FILED_CAIJBH, typeof(System.String));
            this.Columns.Add(CEntityTransitPriceLibrary.FILED_LIBRARYTYPE, typeof(System.String));
            this.Columns.Add(CEntityTransitPriceLibrary.FILED_SOURCE, typeof(System.String));
            this.Columns.Add(CEntityTransitPriceLibrary.FILED_ADDTYPE, typeof(System.String));
            this.Columns.Add(CEntityTransitPriceLibrary.FILED_ADDCOUNT, typeof(System.String));
        }
    }
}
