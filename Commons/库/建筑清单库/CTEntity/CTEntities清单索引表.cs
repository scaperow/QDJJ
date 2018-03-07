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
					m_CEntity�嵥������.PARENTID		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_PARENTID]);
					m_CEntity�嵥������.QINGDSYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_QINGDSYBH]);
					m_CEntity�嵥������.MULNR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�嵥������.FILED_MULNR]);
					this.m_index = index;
					return m_CEntity�嵥������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity�嵥������.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntity�嵥������.FILED_QINGDSYBH] = value.QINGDSYBH; 
				this.Rows[index][CEntity�嵥������.FILED_MULNR] = value.MULNR; 
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
				row[CEntity�嵥������.FILED_PARENTID] = entity.PARENTID;
				row[CEntity�嵥������.FILED_QINGDSYBH] = entity.QINGDSYBH;
				row[CEntity�嵥������.FILED_MULNR] = entity.MULNR;
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
			this.Columns.Add(CEntity�嵥������.FILED_PARENTID, typeof(System.String));
			this.Columns.Add(CEntity�嵥������.FILED_QINGDSYBH, typeof(System.String));
			this.Columns.Add(CEntity�嵥������.FILED_MULNR, typeof(System.String));
		}
	}
}
