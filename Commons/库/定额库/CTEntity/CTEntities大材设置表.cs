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
	///������ñ�ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities������ñ� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity������ñ� m_CEntity������ñ�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities������ñ�()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities������ñ�(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity������ñ� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity������ñ�;
				if (this.Rows.Count > 0)
				{
					m_CEntity������ñ� = new CEntity������ñ�();
					m_CEntity������ñ�.SANDCMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������ñ�.FILED_SANDCMC]);
					m_CEntity������ñ�.HUIZDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������ñ�.FILED_HUIZDW]);
					this.m_index = index;
					return m_CEntity������ñ�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity������ñ�.FILED_SANDCMC] = value.SANDCMC; 
				this.Rows[index][CEntity������ñ�.FILED_HUIZDW] = value.HUIZDW; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity������ñ� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity������ñ�.FILED_SANDCMC] = entity.SANDCMC;
				row[CEntity������ñ�.FILED_HUIZDW] = entity.HUIZDW;
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
			this.Columns.Add(CEntity������ñ�.FILED_SANDCMC, typeof(System.String));
			this.Columns.Add(CEntity������ñ�.FILED_HUIZDW, typeof(System.String));
		}
	}
}
