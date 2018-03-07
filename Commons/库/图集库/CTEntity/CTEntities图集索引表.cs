/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��14��16�ա�04ʱ06��44��
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
	///ͼ��������ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntitiesͼ�������� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityͼ�������� m_CEntityͼ��������;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesͼ��������()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntitiesͼ��������(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityͼ�������� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityͼ��������;
				if (this.Rows.Count > 0)
				{
					m_CEntityͼ�������� = new CEntityͼ��������();
					m_CEntityͼ��������.PARENTID		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ��������.FILED_PARENTID]);
					m_CEntityͼ��������.SYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ��������.FILED_SYBH]);
					m_CEntityͼ��������.MUNR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ��������.FILED_MUNR]);
					this.m_index = index;
					return m_CEntityͼ��������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityͼ��������.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntityͼ��������.FILED_SYBH] = value.SYBH; 
				this.Rows[index][CEntityͼ��������.FILED_MUNR] = value.MUNR; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityͼ�������� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityͼ��������.FILED_PARENTID] = entity.PARENTID;
				row[CEntityͼ��������.FILED_SYBH] = entity.SYBH;
				row[CEntityͼ��������.FILED_MUNR] = entity.MUNR;
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
			this.Columns.Add(CEntityͼ��������.FILED_PARENTID, typeof(System.String));
			this.Columns.Add(CEntityͼ��������.FILED_SYBH, typeof(System.String));
			this.Columns.Add(CEntityͼ��������.FILED_MUNR, typeof(System.String));
		}
	}
}
