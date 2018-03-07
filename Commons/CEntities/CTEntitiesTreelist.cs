/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年33月13日　11时06分57秒
备注:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///TREELIST实体集合类
	/// </summary>
	public class CTEntitiesTreelist : CTEntities
	{
        /// <summary>
        ///记录索引的值(私有成员)默认为-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// 成员实体(避免重复取索引)
        /// </summary>
        private CEntityTreelist m_CEntityTreelist;
        /// <summary>
        ///构造函数
        /// </summary>
        public CTEntitiesTreelist()
        {
            this.buliderTable();
        }
        /// <summary>
        /// 获取当前集合指定行的实体对象
        /// </summary>
        /// <param name="index">集合中行的索引</param>
        /// <returns>相关的实体对象(没有记录则返回空)</returns>
        public CEntityTreelist this[int index]
        {
            get
            {
                //如果前一次执行已经转换过当前索引则直接返回
                if (index == this.m_index) return this.m_CEntityTreelist;
                if (this.Rows.Count > 0)
                {
                    m_CEntityTreelist = new CEntityTreelist();
                    m_CEntityTreelist.KEYFIELDNAME = CDataConvert.ConToValue<System.Int64>(this.Rows[index][CEntityTreelist.FILED_KEYFIELDNAME]);
                    m_CEntityTreelist.PARENTFIELDNAME = CDataConvert.ConToValue<System.Int64>(this.Rows[index][CEntityTreelist.FILED_PARENTFIELDNAME]);
                    m_CEntityTreelist.NODENAME = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTreelist.FILED_NODENAME]);
                    m_CEntityTreelist.REMARK = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTreelist.FILED_REMARK]);
                    m_CEntityTreelist.IMAGEINDEX = CDataConvert.ConToValue<System.Int64>(this.Rows[index][CEntityTreelist.FILED_IMAGEINDEX]);
                    m_CEntityTreelist.COMMANDNAME = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityTreelist.FILED_COMMANDNAME]);
                    this.m_index = index;
                    return m_CEntityTreelist;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntityTreelist.FILED_KEYFIELDNAME] = value.KEYFIELDNAME;
                this.Rows[index][CEntityTreelist.FILED_PARENTFIELDNAME] = value.PARENTFIELDNAME;
                this.Rows[index][CEntityTreelist.FILED_NODENAME] = value.NODENAME;
                this.Rows[index][CEntityTreelist.FILED_REMARK] = value.REMARK;
                this.Rows[index][CEntityTreelist.FILED_IMAGEINDEX] = value.IMAGEINDEX;
                this.Rows[index][CEntityTreelist.FILED_COMMANDNAME] = value.COMMANDNAME;
            }
        }
        /// <summary>
        /// 当前实体集合中追加单个实体
        /// </summary>
        /// <param name="entity">要追加的实体对象</param>
        /// <returns>追加的行的索引(当前)</returns>
        public int AppendEntityInfo(CEntityTreelist entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntityTreelist.FILED_KEYFIELDNAME] = entity.KEYFIELDNAME;
                row[CEntityTreelist.FILED_PARENTFIELDNAME] = entity.PARENTFIELDNAME;
                row[CEntityTreelist.FILED_NODENAME] = entity.NODENAME;
                row[CEntityTreelist.FILED_REMARK] = entity.REMARK;
                row[CEntityTreelist.FILED_IMAGEINDEX] = entity.IMAGEINDEX;
                row[CEntityTreelist.FILED_COMMANDNAME] = entity.COMMANDNAME;
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
            this.TableName = "TreeList";
            this.Columns.Add(CEntityTreelist.FILED_KEYFIELDNAME, typeof(System.Int64));
            this.Columns.Add(CEntityTreelist.FILED_PARENTFIELDNAME, typeof(System.Int64));
            this.Columns.Add(CEntityTreelist.FILED_NODENAME, typeof(System.String));
            this.Columns.Add(CEntityTreelist.FILED_REMARK, typeof(System.String));
            this.Columns.Add(CEntityTreelist.FILED_IMAGEINDEX, typeof(System.Int64));
            this.Columns.Add(CEntityTreelist.FILED_COMMANDNAME, typeof(System.String));
        }
    }
}
