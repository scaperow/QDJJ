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
	///��Ŀȡ�ѱ�ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities��Ŀȡ�ѱ� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity��Ŀȡ�ѱ� m_CEntity��Ŀȡ�ѱ�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities��Ŀȡ�ѱ�()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities��Ŀȡ�ѱ�(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity��Ŀȡ�ѱ� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity��Ŀȡ�ѱ�;
				if (this.Rows.Count > 0)
				{
					m_CEntity��Ŀȡ�ѱ� = new CEntity��Ŀȡ�ѱ�();
					m_CEntity��Ŀȡ�ѱ�.YYH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_YYH]);
					m_CEntity��Ŀȡ�ѱ�.MC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_MC]);
					m_CEntity��Ŀȡ�ѱ�.BDS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_BDS]);
					m_CEntity��Ŀȡ�ѱ�.TBJSJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_TBJSJC]);
					m_CEntity��Ŀȡ�ѱ�.BDJSJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_BDJSJC]);
					m_CEntity��Ŀȡ�ѱ�.FL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_FL]);
					m_CEntity��Ŀȡ�ѱ�.JE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_JE]);
					m_CEntity��Ŀȡ�ѱ�.BEIZHU		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_BEIZHU]);
					this.m_index = index;
					return m_CEntity��Ŀȡ�ѱ�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_YYH] = value.YYH; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_MC] = value.MC; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_BDS] = value.BDS; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_TBJSJC] = value.TBJSJC; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_BDJSJC] = value.BDJSJC; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_FL] = value.FL; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_JE] = value.JE; 
				this.Rows[index][CEntity��Ŀȡ�ѱ�.FILED_BEIZHU] = value.BEIZHU; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity��Ŀȡ�ѱ� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity��Ŀȡ�ѱ�.FILED_YYH] = entity.YYH;
				row[CEntity��Ŀȡ�ѱ�.FILED_MC] = entity.MC;
				row[CEntity��Ŀȡ�ѱ�.FILED_BDS] = entity.BDS;
				row[CEntity��Ŀȡ�ѱ�.FILED_TBJSJC] = entity.TBJSJC;
				row[CEntity��Ŀȡ�ѱ�.FILED_BDJSJC] = entity.BDJSJC;
				row[CEntity��Ŀȡ�ѱ�.FILED_FL] = entity.FL;
				row[CEntity��Ŀȡ�ѱ�.FILED_JE] = entity.JE;
				row[CEntity��Ŀȡ�ѱ�.FILED_BEIZHU] = entity.BEIZHU;
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
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_YYH, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_MC, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_BDS, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_TBJSJC, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_BDJSJC, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_FL, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_JE, typeof(System.String));
			this.Columns.Add(CEntity��Ŀȡ�ѱ�.FILED_BEIZHU, typeof(System.String));
		}
	}
}
