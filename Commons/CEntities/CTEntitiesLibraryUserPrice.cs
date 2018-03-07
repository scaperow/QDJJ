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
    ///LIBRARYUSERPRICE实体集合类
    /// </summary>
    [Serializable]
    public class CTEntitiesLibraryUserPrice : DataTable
    {
        /// <summary>
        ///记录索引的值(私有成员)默认为-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// 成员实体(避免重复取索引)
        /// </summary>
        private CEntityLibraryUserPrice m_CEntityLibraryUserPrice;
        /// <summary>
        ///构造函数
        /// </summary>
        public CTEntitiesLibraryUserPrice()
        {
            this.buliderTable();
        }
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntitiesLibraryUserPrice(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// 获取当前集合指定行的实体对象
        /// </summary>
        /// <param name="index">集合中行的索引</param>
        /// <returns>相关的实体对象(没有记录则返回空)</returns>
        public CEntityLibraryUserPrice this[int index]
        {
            get
            {
                //如果前一次执行已经转换过当前索引则直接返回
                if (index == this.m_index) return this.m_CEntityLibraryUserPrice;
                if (this.Rows.Count > 0)
                {
                    m_CEntityLibraryUserPrice = new CEntityLibraryUserPrice();
                    m_CEntityLibraryUserPrice.ID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_ID]);
                    m_CEntityLibraryUserPrice.XID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_XID]);
                    m_CEntityLibraryUserPrice.DID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_DID]);
                    m_CEntityLibraryUserPrice.QID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_QID]);
                    m_CEntityLibraryUserPrice.ZID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_ZID]);
                    m_CEntityLibraryUserPrice.RID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_RID]);
                    m_CEntityLibraryUserPrice.PID = ToolKit.ParseInt(this.Rows[index][CEntityLibraryUserPrice.FILED_PID]);
                    m_CEntityLibraryUserPrice.CAIJBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJBH]);
                    m_CEntityLibraryUserPrice.CAIJLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJLB]);
                    m_CEntityLibraryUserPrice.CAIJMC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJMC]);
                    m_CEntityLibraryUserPrice.CAIJXH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJXH]);
                    m_CEntityLibraryUserPrice.CAIJDW = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJDW]);
                    m_CEntityLibraryUserPrice.CAIJDJ = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJDJ]);
                    m_CEntityLibraryUserPrice.CAIJDJH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJDJH]);
                    m_CEntityLibraryUserPrice.CAIJSJ = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSJ]);
                    m_CEntityLibraryUserPrice.CAIJSJH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSJH]);
                    m_CEntityLibraryUserPrice.CAIJSDJC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSDJC]);
                    m_CEntityLibraryUserPrice.CAIJSHJC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSHJC]);
                    m_CEntityLibraryUserPrice.CAIJXHL = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJXHL]);
                    m_CEntityLibraryUserPrice.CAIJXHLH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJXHLH]);
                    m_CEntityLibraryUserPrice.CAIJSLH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSLH]);
                    m_CEntityLibraryUserPrice.CAIJIFZG = ToolKit.ParseBoolen(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFZG]);
                    m_CEntityLibraryUserPrice.CAIJIFGJ = ToolKit.ParseBoolen(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFGJ]);
                    m_CEntityLibraryUserPrice.CAIJIFCJ = ToolKit.ParseBoolen(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFCJ]);
                    m_CEntityLibraryUserPrice.CAIJIFSD = ToolKit.ParseBoolen(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFSD]);
                    m_CEntityLibraryUserPrice.CAIJBZ = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJBZ]);
                    m_CEntityLibraryUserPrice.LIBRARYTYPE = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_LIBRARYTYPE]);
                    m_CEntityLibraryUserPrice.SOURCE = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_SOURCE]);
                    m_CEntityLibraryUserPrice.ADDTYPE = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_ADDTYPE]);
                    m_CEntityLibraryUserPrice.ADDCOUNT = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityLibraryUserPrice.FILED_ADDCOUNT]);
                    this.m_index = index;
                    return m_CEntityLibraryUserPrice;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntityLibraryUserPrice.FILED_ID] = value.ID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_XID] = value.XID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_DID] = value.DID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_QID] = value.QID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_ZID] = value.ZID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_RID] = value.RID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_PID] = value.PID;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJBH] = value.CAIJBH;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJLB] = value.CAIJLB;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJMC] = value.CAIJMC;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJXH] = value.CAIJXH;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJDW] = value.CAIJDW;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJDJ] = value.CAIJDJ;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJDJH] = value.CAIJDJH;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSJ] = value.CAIJSJ;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSJH] = value.CAIJSJH;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSDJC] = value.CAIJSDJC;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSHJC] = value.CAIJSHJC;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJXHL] = value.CAIJXHL;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJXHLH] = value.CAIJXHLH;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJSLH] = value.CAIJSLH;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFZG] = value.CAIJIFZG;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFGJ] = value.CAIJIFGJ;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFCJ] = value.CAIJIFCJ;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJIFSD] = value.CAIJIFSD;
                this.Rows[index][CEntityLibraryUserPrice.FILED_CAIJBZ] = value.CAIJBZ;
                this.Rows[index][CEntityLibraryUserPrice.FILED_LIBRARYTYPE] = value.LIBRARYTYPE;
                this.Rows[index][CEntityLibraryUserPrice.FILED_SOURCE] = value.SOURCE;
                this.Rows[index][CEntityLibraryUserPrice.FILED_ADDTYPE] = value.ADDTYPE;
                this.Rows[index][CEntityLibraryUserPrice.FILED_ADDCOUNT] = value.ADDCOUNT;
            }
        }
        /// <summary>
        /// 当前实体集合中追加单个实体
        /// </summary>
        /// <param name="entity">要追加的实体对象</param>
        /// <returns>追加的行的索引(当前)</returns>
        public int AppendEntityInfo(CEntityLibraryUserPrice entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntityLibraryUserPrice.FILED_ID] = entity.ID;
                row[CEntityLibraryUserPrice.FILED_XID] = entity.XID;
                row[CEntityLibraryUserPrice.FILED_DID] = entity.DID;
                row[CEntityLibraryUserPrice.FILED_QID] = entity.QID;
                row[CEntityLibraryUserPrice.FILED_ZID] = entity.ZID;
                row[CEntityLibraryUserPrice.FILED_RID] = entity.RID;
                row[CEntityLibraryUserPrice.FILED_PID] = entity.PID;
                row[CEntityLibraryUserPrice.FILED_CAIJBH] = entity.CAIJBH;
                row[CEntityLibraryUserPrice.FILED_CAIJLB] = entity.CAIJLB;
                row[CEntityLibraryUserPrice.FILED_CAIJMC] = entity.CAIJMC;
                row[CEntityLibraryUserPrice.FILED_CAIJXH] = entity.CAIJXH;
                row[CEntityLibraryUserPrice.FILED_CAIJDW] = entity.CAIJDW;
                row[CEntityLibraryUserPrice.FILED_CAIJDJ] = entity.CAIJDJ;
                row[CEntityLibraryUserPrice.FILED_CAIJDJH] = entity.CAIJDJH;
                row[CEntityLibraryUserPrice.FILED_CAIJSJ] = entity.CAIJSJ;
                row[CEntityLibraryUserPrice.FILED_CAIJSJH] = entity.CAIJSJH;
                row[CEntityLibraryUserPrice.FILED_CAIJSDJC] = entity.CAIJSDJC;
                row[CEntityLibraryUserPrice.FILED_CAIJSHJC] = entity.CAIJSHJC;
                row[CEntityLibraryUserPrice.FILED_CAIJXHL] = entity.CAIJXHL;
                row[CEntityLibraryUserPrice.FILED_CAIJXHLH] = entity.CAIJXHLH;
                row[CEntityLibraryUserPrice.FILED_CAIJSLH] = entity.CAIJSLH;
                row[CEntityLibraryUserPrice.FILED_CAIJIFZG] = entity.CAIJIFZG;
                row[CEntityLibraryUserPrice.FILED_CAIJIFGJ] = entity.CAIJIFGJ;
                row[CEntityLibraryUserPrice.FILED_CAIJIFCJ] = entity.CAIJIFCJ;
                row[CEntityLibraryUserPrice.FILED_CAIJIFSD] = entity.CAIJIFSD;
                row[CEntityLibraryUserPrice.FILED_CAIJBZ] = entity.CAIJBZ;
                row[CEntityLibraryUserPrice.FILED_LIBRARYTYPE] = entity.LIBRARYTYPE;
                row[CEntityLibraryUserPrice.FILED_SOURCE] = entity.SOURCE;
                row[CEntityLibraryUserPrice.FILED_ADDTYPE] = entity.ADDTYPE;
                row[CEntityLibraryUserPrice.FILED_ADDCOUNT] = entity.ADDCOUNT;
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
            this.Columns.Add(CEntityLibraryUserPrice.FILED_ID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_XID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_DID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_QID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_ZID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_RID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_PID, typeof(System.Int32));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJBH, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJLB, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJMC, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJXH, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJDW, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJDJ, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJDJH, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJSJ, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJSJH, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJSDJC, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJSHJC, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJXHL, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJXHLH, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJSLH, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJIFZG, typeof(System.Boolean));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJIFGJ, typeof(System.Boolean));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJIFCJ, typeof(System.Boolean));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJIFSD, typeof(System.Boolean));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_CAIJBZ, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_LIBRARYTYPE, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_SOURCE, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_ADDTYPE, typeof(System.String));
            this.Columns.Add(CEntityLibraryUserPrice.FILED_ADDCOUNT, typeof(System.String));
        }
    }
}
