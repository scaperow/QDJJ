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
	///����ϵ����ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities����ϵ���� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity����ϵ���� m_CEntity����ϵ����;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities����ϵ����()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities����ϵ����(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity����ϵ���� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity����ϵ����;
				if (this.Rows.Count > 0)
				{
					m_CEntity����ϵ���� = new CEntity����ϵ����();
					m_CEntity����ϵ����.CAIJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity����ϵ����.FILED_CAIJBH]);
					m_CEntity����ϵ����.JMXS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity����ϵ����.FILED_JMXS]);
					this.m_index = index;
					return m_CEntity����ϵ����;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity����ϵ����.FILED_CAIJBH] = value.CAIJBH; 
				this.Rows[index][CEntity����ϵ����.FILED_JMXS] = value.JMXS; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity����ϵ���� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity����ϵ����.FILED_CAIJBH] = entity.CAIJBH;
				row[CEntity����ϵ����.FILED_JMXS] = entity.JMXS;
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
			this.Columns.Add(CEntity����ϵ����.FILED_CAIJBH, typeof(System.String));
			this.Columns.Add(CEntity����ϵ����.FILED_JMXS, typeof(System.String));
		}
	}
}
