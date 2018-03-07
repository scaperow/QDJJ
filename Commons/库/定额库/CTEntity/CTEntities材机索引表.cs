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
	///�Ļ�������ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities�Ļ������� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity�Ļ������� m_CEntity�Ļ�������;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities�Ļ�������()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities�Ļ�������(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity�Ļ������� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity�Ļ�������;
				if (this.Rows.Count > 0)
				{
					m_CEntity�Ļ������� = new CEntity�Ļ�������();
					m_CEntity�Ļ�������.PARENTID		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ�������.FILED_PARENTID]);
					m_CEntity�Ļ�������.CAIJSYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ�������.FILED_CAIJSYBH]);
					m_CEntity�Ļ�������.MULNR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�Ļ�������.FILED_MULNR]);
					this.m_index = index;
					return m_CEntity�Ļ�������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity�Ļ�������.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntity�Ļ�������.FILED_CAIJSYBH] = value.CAIJSYBH; 
				this.Rows[index][CEntity�Ļ�������.FILED_MULNR] = value.MULNR; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity�Ļ������� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity�Ļ�������.FILED_PARENTID] = entity.PARENTID;
				row[CEntity�Ļ�������.FILED_CAIJSYBH] = entity.CAIJSYBH;
				row[CEntity�Ļ�������.FILED_MULNR] = entity.MULNR;
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
			this.Columns.Add(CEntity�Ļ�������.FILED_PARENTID, typeof(System.String));
			this.Columns.Add(CEntity�Ļ�������.FILED_CAIJSYBH, typeof(System.String));
			this.Columns.Add(CEntity�Ļ�������.FILED_MULNR, typeof(System.String));
		}
	}
}
