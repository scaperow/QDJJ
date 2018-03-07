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
	///�������Ա�ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities�������Ա� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity�������Ա� m_CEntity�������Ա�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities�������Ա�()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities�������Ա�(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity�������Ա� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity�������Ա�;
				if (this.Rows.Count > 0)
				{
					m_CEntity�������Ա� = new CEntity�������Ա�();
					m_CEntity�������Ա�.DESX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�������Ա�.FILED_DESX]);
					this.m_index = index;
					return m_CEntity�������Ա�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity�������Ա�.FILED_DESX] = value.DESX; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity�������Ա� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity�������Ա�.FILED_DESX] = entity.DESX;
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
			this.Columns.Add(CEntity�������Ա�.FILED_DESX, typeof(System.String));
		}
	}
}
