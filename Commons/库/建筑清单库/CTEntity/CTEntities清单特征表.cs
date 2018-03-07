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
	///�嵥������ʵ�弯����
	/// </summary>
	[Serializable]
    public class CTEntities�嵥������ : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity�嵥������ m_CEntity�嵥������;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities�嵥������()
		{
			this.buliderTable();
		}
        /// <summary>
        ///�����л����캯��
        /// </summary>
        public CTEntities�嵥������(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity�嵥������ this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity�嵥������;
				if (this.Rows.Count > 0)
				{
					m_CEntity�嵥������ = new CEntity�嵥������();
					m_CEntity�嵥������.QINGDBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_QINGDBH]);
					m_CEntity�嵥������.TEZBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_TEZBH]);
					m_CEntity�嵥������.TEZMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_TEZMC]);
					m_CEntity�嵥������.TEZDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_TEZDW]);
					m_CEntity�嵥������.TEZZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_TEZZ]);
					this.m_index = index;
					return m_CEntity�嵥������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity�嵥������.FILED_QINGDBH] = value.QINGDBH; 
				this.Rows[index][CEntity�嵥������.FILED_TEZBH] = value.TEZBH; 
				this.Rows[index][CEntity�嵥������.FILED_TEZMC] = value.TEZMC; 
				this.Rows[index][CEntity�嵥������.FILED_TEZDW] = value.TEZDW; 
				this.Rows[index][CEntity�嵥������.FILED_TEZZ] = value.TEZZ; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity�嵥������ entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity�嵥������.FILED_QINGDBH] = entity.QINGDBH;
				row[CEntity�嵥������.FILED_TEZBH] = entity.TEZBH;
				row[CEntity�嵥������.FILED_TEZMC] = entity.TEZMC;
				row[CEntity�嵥������.FILED_TEZDW] = entity.TEZDW;
				row[CEntity�嵥������.FILED_TEZZ] = entity.TEZZ;
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
			this.Columns.Add(CEntity�嵥������.FILED_QINGDBH, typeof(System.String));
			this.Columns.Add(CEntity�嵥������.FILED_TEZBH, typeof(System.String));
			this.Columns.Add(CEntity�嵥������.FILED_TEZMC, typeof(System.String));
			this.Columns.Add(CEntity�嵥������.FILED_TEZDW, typeof(System.String));
			this.Columns.Add(CEntity�嵥������.FILED_TEZZ, typeof(System.String));
		}
	}
}
