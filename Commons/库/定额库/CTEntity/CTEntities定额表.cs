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
	///�����ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities����� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity����� m_CEntity�����;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities�����()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities�����(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity����� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity�����;
				if (this.Rows.Count > 0)
				{
					m_CEntity����� = new CEntity�����();
					m_CEntity�����.DINGESYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGESYBH]);
					m_CEntity�����.TX1		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_TX1]);
					m_CEntity�����.TX2		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_TX2]);
					m_CEntity�����.TX3		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_TX3]);
					m_CEntity�����.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGEH]);
					m_CEntity�����.DINGEMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGEMC]);
					m_CEntity�����.DINGEDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGEDW]);
					m_CEntity�����.DINGEJJ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGEJJ]);
					m_CEntity�����.RENGF		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_RENGF]);
					m_CEntity�����.CAILF		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_CAILF]);
					m_CEntity�����.JIXF		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_JIXF]);
					m_CEntity�����.JIANGX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_JIANGX]);
					m_CEntity�����.DINGESX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGESX]);
					m_CEntity�����.DINGESM		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DINGESM]);
					m_CEntity�����.DECJ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity�����.FILED_DECJ]);
					this.m_index = index;
					return m_CEntity�����;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity�����.FILED_DINGESYBH] = value.DINGESYBH; 
				this.Rows[index][CEntity�����.FILED_TX1] = value.TX1; 
				this.Rows[index][CEntity�����.FILED_TX2] = value.TX2; 
				this.Rows[index][CEntity�����.FILED_TX3] = value.TX3; 
				this.Rows[index][CEntity�����.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity�����.FILED_DINGEMC] = value.DINGEMC; 
				this.Rows[index][CEntity�����.FILED_DINGEDW] = value.DINGEDW; 
				this.Rows[index][CEntity�����.FILED_DINGEJJ] = value.DINGEJJ; 
				this.Rows[index][CEntity�����.FILED_RENGF] = value.RENGF; 
				this.Rows[index][CEntity�����.FILED_CAILF] = value.CAILF; 
				this.Rows[index][CEntity�����.FILED_JIXF] = value.JIXF; 
				this.Rows[index][CEntity�����.FILED_JIANGX] = value.JIANGX; 
				this.Rows[index][CEntity�����.FILED_DINGESX] = value.DINGESX; 
				this.Rows[index][CEntity�����.FILED_DINGESM] = value.DINGESM; 
				this.Rows[index][CEntity�����.FILED_DECJ] = value.DECJ; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity����� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity�����.FILED_DINGESYBH] = entity.DINGESYBH;
				row[CEntity�����.FILED_TX1] = entity.TX1;
				row[CEntity�����.FILED_TX2] = entity.TX2;
				row[CEntity�����.FILED_TX3] = entity.TX3;
				row[CEntity�����.FILED_DINGEH] = entity.DINGEH;
				row[CEntity�����.FILED_DINGEMC] = entity.DINGEMC;
				row[CEntity�����.FILED_DINGEDW] = entity.DINGEDW;
				row[CEntity�����.FILED_DINGEJJ] = entity.DINGEJJ;
				row[CEntity�����.FILED_RENGF] = entity.RENGF;
				row[CEntity�����.FILED_CAILF] = entity.CAILF;
				row[CEntity�����.FILED_JIXF] = entity.JIXF;
				row[CEntity�����.FILED_JIANGX] = entity.JIANGX;
				row[CEntity�����.FILED_DINGESX] = entity.DINGESX;
				row[CEntity�����.FILED_DINGESM] = entity.DINGESM;
				row[CEntity�����.FILED_DECJ] = entity.DECJ;
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
			this.Columns.Add(CEntity�����.FILED_DINGESYBH, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_TX1, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_TX2, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_TX3, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DINGEMC, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DINGEDW, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DINGEJJ, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_RENGF, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_CAILF, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_JIXF, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_JIANGX, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DINGESX, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DINGESM, typeof(System.String));
			this.Columns.Add(CEntity�����.FILED_DECJ, typeof(System.String));
		}
	}
}
