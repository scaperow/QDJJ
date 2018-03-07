/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��11��16�ա�03ʱ06��53��
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
	///ָ�����ݱ�ʵ�弯����
	/// </summary>
	[Serializable]
    public class CTEntitiesָ�����ݱ� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityָ�����ݱ� m_CEntityָ�����ݱ�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesָ�����ݱ�()
		{
			this.buliderTable();
		}
        /// <summary>
        ///�����л����캯��
        /// </summary>
        public CTEntitiesָ�����ݱ�(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityָ�����ݱ� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityָ�����ݱ�;
				if (this.Rows.Count > 0)
				{
					m_CEntityָ�����ݱ� = new CEntityָ�����ݱ�();
					m_CEntityָ�����ݱ�.QINGDBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityָ�����ݱ�.FILED_QINGDBH]);
					m_CEntityָ�����ݱ�.NEIRBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityָ�����ݱ�.FILED_NEIRBH]);
					m_CEntityָ�����ݱ�.NRMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityָ�����ݱ�.FILED_NRMC]);
					m_CEntityָ�����ݱ�.ZHIYDE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityָ�����ݱ�.FILED_ZHIYDE]);
					this.m_index = index;
					return m_CEntityָ�����ݱ�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityָ�����ݱ�.FILED_QINGDBH] = value.QINGDBH; 
				this.Rows[index][CEntityָ�����ݱ�.FILED_NEIRBH] = value.NEIRBH; 
				this.Rows[index][CEntityָ�����ݱ�.FILED_NRMC] = value.NRMC; 
				this.Rows[index][CEntityָ�����ݱ�.FILED_ZHIYDE] = value.ZHIYDE; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityָ�����ݱ� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityָ�����ݱ�.FILED_QINGDBH] = entity.QINGDBH;
				row[CEntityָ�����ݱ�.FILED_NEIRBH] = entity.NEIRBH;
				row[CEntityָ�����ݱ�.FILED_NRMC] = entity.NRMC;
				row[CEntityָ�����ݱ�.FILED_ZHIYDE] = entity.ZHIYDE;
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
			this.Columns.Add(CEntityָ�����ݱ�.FILED_QINGDBH, typeof(System.String));
			this.Columns.Add(CEntityָ�����ݱ�.FILED_NEIRBH, typeof(System.String));
			this.Columns.Add(CEntityָ�����ݱ�.FILED_NRMC, typeof(System.String));
			this.Columns.Add(CEntityָ�����ݱ�.FILED_ZHIYDE, typeof(System.String));
           // this.Columns.Add("check", typeof(System.Boolean));
		}
	}
}
