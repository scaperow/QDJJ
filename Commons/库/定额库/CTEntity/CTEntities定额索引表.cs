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
	///����������ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities���������� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity���������� m_CEntity����������;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities����������()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities����������(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity���������� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity����������;
				if (this.Rows.Count > 0)
				{
					m_CEntity���������� = new CEntity����������();
					m_CEntity����������.PARENTID		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity����������.FILED_PARENTID]);
					m_CEntity����������.DINGESYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity����������.FILED_DINGESYBH]);
					m_CEntity����������.MULNR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity����������.FILED_MULNR]);
					this.m_index = index;
					return m_CEntity����������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity����������.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntity����������.FILED_DINGESYBH] = value.DINGESYBH; 
				this.Rows[index][CEntity����������.FILED_MULNR] = value.MULNR; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity���������� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity����������.FILED_PARENTID] = entity.PARENTID;
				row[CEntity����������.FILED_DINGESYBH] = entity.DINGESYBH;
				row[CEntity����������.FILED_MULNR] = entity.MULNR;
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
			this.Columns.Add(CEntity����������.FILED_PARENTID, typeof(System.String));
			this.Columns.Add(CEntity����������.FILED_DINGESYBH, typeof(System.String));
			this.Columns.Add(CEntity����������.FILED_MULNR, typeof(System.String));
		}
	}
}
