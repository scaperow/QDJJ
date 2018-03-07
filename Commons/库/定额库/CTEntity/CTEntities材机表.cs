/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��09��16�ա�04ʱ06��14��
��ע:
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
    ///�Ļ���ʵ�弯����
    /// </summary>
    [Serializable]
    public class CTEntities�Ļ��� : CTEntities
    {
        /// <summary>
        ///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// ��Աʵ��(�����ظ�ȡ����)
        /// </summary>
        private CEntity�Ļ��� m_CEntity�Ļ���;
        /// <summary>
        ///���캯��
        /// </summary>
        public CTEntities�Ļ���()
        {
            this.buliderTable();
        }
        /// <summary>
        ///�����л����캯��
        /// </summary>
        public CTEntities�Ļ���(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// ��ȡ��ǰ����ָ���е�ʵ�����
        /// </summary>
        /// <param name="index">�������е�����</param>
        /// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
        public CEntity�Ļ��� this[int index]
        {
            get
            {
                //���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
                if (index == this.m_index) return this.m_CEntity�Ļ���;
                if (this.Rows.Count > 0)
                {
                    m_CEntity�Ļ��� = new CEntity�Ļ���();
                    m_CEntity�Ļ���.CAIJBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJBH]);
                    m_CEntity�Ļ���.CAIJSYBH = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJSYBH]);
                    m_CEntity�Ļ���.CAIJMC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJMC]);
                    m_CEntity�Ļ���.CAIJDW = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJDW]);
                    m_CEntity�Ļ���.CAIJDJ = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJDJ]);
                    m_CEntity�Ļ���.CAIJLB = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJLB]);
                    m_CEntity�Ļ���.CAIJSC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJSC]);
                    m_CEntity�Ļ���.CAIJJC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJJC]);
                    m_CEntity�Ļ���.CAIJXSJG = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_CAIJXSJG]);
                    m_CEntity�Ļ���.SANDCMC = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_SANDCMC]);
                    m_CEntity�Ļ���.SANDCXS = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ���.FILED_SANDCXS]);
                    this.m_index = index;
                    return m_CEntity�Ļ���;
                }
                return null;
            }
            set
            {
                this.Rows[index][CEntity�Ļ���.FILED_CAIJBH] = value.CAIJBH;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJSYBH] = value.CAIJSYBH;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJMC] = value.CAIJMC;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJDW] = value.CAIJDW;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJDJ] = value.CAIJDJ;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJLB] = value.CAIJLB;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJSC] = value.CAIJSC;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJJC] = value.CAIJJC;
                this.Rows[index][CEntity�Ļ���.FILED_CAIJXSJG] = value.CAIJXSJG;
                this.Rows[index][CEntity�Ļ���.FILED_SANDCMC] = value.SANDCMC;
                this.Rows[index][CEntity�Ļ���.FILED_SANDCXS] = value.SANDCXS;
            }
        }
        /// <summary>
        /// ��ǰʵ�弯����׷�ӵ���ʵ��
        /// </summary>
        /// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
        /// <returns>׷�ӵ��е�����(��ǰ)</returns>
        public int AppendEntityInfo(CEntity�Ļ��� entity)
        {
            if (this == null || this.Columns.Count == 0)
            {
                this.buliderTable();
            }
            if (entity != null)
            {
                DataRow row = this.NewRow();
                row[CEntity�Ļ���.FILED_CAIJBH] = entity.CAIJBH;
                row[CEntity�Ļ���.FILED_CAIJSYBH] = entity.CAIJSYBH;
                row[CEntity�Ļ���.FILED_CAIJMC] = entity.CAIJMC;
                row[CEntity�Ļ���.FILED_CAIJDW] = entity.CAIJDW;
                row[CEntity�Ļ���.FILED_CAIJDJ] = entity.CAIJDJ;
                row[CEntity�Ļ���.FILED_CAIJLB] = entity.CAIJLB;
                row[CEntity�Ļ���.FILED_CAIJSC] = entity.CAIJSC;
                row[CEntity�Ļ���.FILED_CAIJJC] = entity.CAIJJC;
                row[CEntity�Ļ���.FILED_CAIJXSJG] = entity.CAIJXSJG;
                row[CEntity�Ļ���.FILED_SANDCMC] = entity.SANDCMC;
                row[CEntity�Ļ���.FILED_SANDCXS] = entity.SANDCXS;
                this.Rows.Add(row);
                return this.Rows.Count;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// ����һ���µı�ṹ
        /// </summary>
        private void buliderTable()
        {
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJBH, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJSYBH, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJMC, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJDW, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJDJ, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJLB, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJSC, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJJC, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_CAIJXSJG, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_SANDCMC, typeof(System.String));
            this.Columns.Add(CEntity�Ļ���.FILED_SANDCXS, typeof(System.String));
        }
    }
}
