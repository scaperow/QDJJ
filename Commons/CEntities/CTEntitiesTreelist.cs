/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��33��13�ա�11ʱ06��57��
��ע:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///TREELISTʵ�弯����
	/// </summary>
	public class CTEntitiesTreelist : CTEntities
	{
        /// <summary>
        ///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
        /// </summary>
        private int m_index = -1;
        /// <summary>
        /// ��Աʵ��(�����ظ�ȡ����)
        /// </summary>
        private CEntityTreelist m_CEntityTreelist;
        /// <summary>
        ///���캯��
        /// </summary>
        public CTEntitiesTreelist()
        {
            this.buliderTable();
        }
        /// <summary>
        /// ��ȡ��ǰ����ָ���е�ʵ�����
        /// </summary>
        /// <param name="index">�������е�����</param>
        /// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
        public CEntityTreelist this[int index]
        {
            get
            {
                //���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
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
        /// ��ǰʵ�弯����׷�ӵ���ʵ��
        /// </summary>
        /// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
        /// <returns>׷�ӵ��е�����(��ǰ)</returns>
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
        /// ����һ���µı�ṹ
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
