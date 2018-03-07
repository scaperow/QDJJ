/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年09月16日　04时06分14秒
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
    ///材机表实体集合类
    /// </summary>
    [Serializable]
    public class CTEntities材机表 : CTEntities
    {
        /// <summary>
        ///记录索引的值(私有成员)默认为-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// 成员实体(避免重复取索引)
        /// </summary>
        private CEntity材机表 m_CEntity材机表;
        /// <summary>
        ///构造函数
        /// </summary>
        public CTEntities材机表()
        {
            this.buliderTable();
        }
        /// <summary>
        ///反序列化构造函数
        /// </summary>
        public CTEntities材机表(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// 获取当前集合指定行的实体对象
        /// </summary>
        /// <param name="index">集合中行的索引</param>
        /// <returns>相关的实体对象(没有记录则返回空)</returns>
        public CEntity材机表 this[int index]
        {
            get
            {
                //如果前一次执行已经转换过当前索引则直接返回
                if (index == this.m_index) return this.m_CEntity材机表;
                if (this.Rows.Count > 0)
                {
                    m_CEntity材机表 = new CEntity材机表();
                    m_CEntity材机表.CAIJBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJBH]);
                    m_CEntity材机表.CAIJSYBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJSYBH]);
                    m_CEntity材机表.CAIJMC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJMC]);
                    m_CEntity材机表.CAIJDW = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJDW]);
                    m_CEntity材机表.CAIJDJ = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJDJ]);
                    m_CEntity材机表.CAIJLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJLB]);
                    m_CEntity材机表.CAIJSC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJSC]);
                    m_CEntity材机表.CAIJJC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJJC]);
                    m_CEntity材机表.CAIJXSJG = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_CAIJXSJG]);
                    m_CEntity材机表.SANDCMC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_SANDCMC]);
                    m_CEntity材机表.SANDCXS = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity材机表.FILED_SANDCXS]);
                    this.m_index = index;
                    return m_CEntity材机表;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntity材机表.FILED_CAIJBH] = value.CAIJBH;
                this.Rows[index][CEntity材机表.FILED_CAIJSYBH] = value.CAIJSYBH;
                this.Rows[index][CEntity材机表.FILED_CAIJMC] = value.CAIJMC;
                this.Rows[index][CEntity材机表.FILED_CAIJDW] = value.CAIJDW;
                this.Rows[index][CEntity材机表.FILED_CAIJDJ] = value.CAIJDJ;
                this.Rows[index][CEntity材机表.FILED_CAIJLB] = value.CAIJLB;
                this.Rows[index][CEntity材机表.FILED_CAIJSC] = value.CAIJSC;
                this.Rows[index][CEntity材机表.FILED_CAIJJC] = value.CAIJJC;
                this.Rows[index][CEntity材机表.FILED_CAIJXSJG] = value.CAIJXSJG;
                this.Rows[index][CEntity材机表.FILED_SANDCMC] = value.SANDCMC;
                this.Rows[index][CEntity材机表.FILED_SANDCXS] = value.SANDCXS;
            }
        }
        /// <summary>
        /// 当前实体集合中追加单个实体
        /// </summary>
        /// <param name="entity">要追加的实体对象</param>
        /// <returns>追加的行的索引(当前)</returns>
        public int AppendEntityInfo(CEntity材机表 entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntity材机表.FILED_CAIJBH] = entity.CAIJBH;
                row[CEntity材机表.FILED_CAIJSYBH] = entity.CAIJSYBH;
                row[CEntity材机表.FILED_CAIJMC] = entity.CAIJMC;
                row[CEntity材机表.FILED_CAIJDW] = entity.CAIJDW;
                row[CEntity材机表.FILED_CAIJDJ] = entity.CAIJDJ;
                row[CEntity材机表.FILED_CAIJLB] = entity.CAIJLB;
                row[CEntity材机表.FILED_CAIJSC] = entity.CAIJSC;
                row[CEntity材机表.FILED_CAIJJC] = entity.CAIJJC;
                row[CEntity材机表.FILED_CAIJXSJG] = entity.CAIJXSJG;
                row[CEntity材机表.FILED_SANDCMC] = entity.SANDCMC;
                row[CEntity材机表.FILED_SANDCXS] = entity.SANDCXS;
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
            this.Columns.Add(CEntity材机表.FILED_CAIJBH, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJSYBH, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJMC, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJDW, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJDJ, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJLB, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJSC, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJJC, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_CAIJXSJG, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_SANDCMC, typeof(System.String));
            this.Columns.Add(CEntity材机表.FILED_SANDCXS, typeof(System.String));
        }
    }
}
