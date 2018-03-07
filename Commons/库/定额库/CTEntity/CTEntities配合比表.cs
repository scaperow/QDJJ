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
	///��ϱȱ�ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities��ϱȱ� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity��ϱȱ� m_CEntity��ϱȱ�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities��ϱȱ�()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities��ϱȱ�(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity��ϱȱ� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity��ϱȱ�;
				if (this.Rows.Count > 0)
				{
					m_CEntity��ϱȱ� = new CEntity��ϱȱ�();
					m_CEntity��ϱȱ�.CAIJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��ϱȱ�.FILED_CAIJBH]);
					m_CEntity��ϱȱ�.PHB_CJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��ϱȱ�.FILED_PHB_CJBH]);
					m_CEntity��ϱȱ�.PHB_CJSL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��ϱȱ�.FILED_PHB_CJSL]);
					this.m_index = index;
					return m_CEntity��ϱȱ�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity��ϱȱ�.FILED_CAIJBH] = value.CAIJBH; 
				this.Rows[index][CEntity��ϱȱ�.FILED_PHB_CJBH] = value.PHB_CJBH; 
				this.Rows[index][CEntity��ϱȱ�.FILED_PHB_CJSL] = value.PHB_CJSL; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity��ϱȱ� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity��ϱȱ�.FILED_CAIJBH] = entity.CAIJBH;
				row[CEntity��ϱȱ�.FILED_PHB_CJBH] = entity.PHB_CJBH;
				row[CEntity��ϱȱ�.FILED_PHB_CJSL] = entity.PHB_CJSL;
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
			this.Columns.Add(CEntity��ϱȱ�.FILED_CAIJBH, typeof(System.String));
			this.Columns.Add(CEntity��ϱȱ�.FILED_PHB_CJBH, typeof(System.String));
			this.Columns.Add(CEntity��ϱȱ�.FILED_PHB_CJSL, typeof(System.String));
		}
	}
}
