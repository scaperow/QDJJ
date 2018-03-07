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
	///������Ϣ��ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities������Ϣ�� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity������Ϣ�� m_CEntity������Ϣ��;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities������Ϣ��()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities������Ϣ��(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity������Ϣ�� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity������Ϣ��;
				if (this.Rows.Count > 0)
				{
					m_CEntity������Ϣ�� = new CEntity������Ϣ��();
					m_CEntity������Ϣ��.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_DINGEH]);
					m_CEntity������Ϣ��.GLDEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_GLDEH]);
					m_CEntity������Ϣ��.DEMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_DEMC]);
					m_CEntity������Ϣ��.DEDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_DEDW]);
					m_CEntity������Ϣ��.GLDHSX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_GLDHSX]);
					m_CEntity������Ϣ��.GCLXS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_GCLXS]);
					m_CEntity������Ϣ��.TISXX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_TISXX]);
					m_CEntity������Ϣ��.JISJS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������Ϣ��.FILED_JISJS]);
					this.m_index = index;
					return m_CEntity������Ϣ��;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity������Ϣ��.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity������Ϣ��.FILED_GLDEH] = value.GLDEH; 
				this.Rows[index][CEntity������Ϣ��.FILED_DEMC] = value.DEMC; 
				this.Rows[index][CEntity������Ϣ��.FILED_DEDW] = value.DEDW; 
				this.Rows[index][CEntity������Ϣ��.FILED_GLDHSX] = value.GLDHSX; 
				this.Rows[index][CEntity������Ϣ��.FILED_GCLXS] = value.GCLXS; 
				this.Rows[index][CEntity������Ϣ��.FILED_TISXX] = value.TISXX; 
				this.Rows[index][CEntity������Ϣ��.FILED_JISJS] = value.JISJS; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity������Ϣ�� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity������Ϣ��.FILED_DINGEH] = entity.DINGEH;
				row[CEntity������Ϣ��.FILED_GLDEH] = entity.GLDEH;
				row[CEntity������Ϣ��.FILED_DEMC] = entity.DEMC;
				row[CEntity������Ϣ��.FILED_DEDW] = entity.DEDW;
				row[CEntity������Ϣ��.FILED_GLDHSX] = entity.GLDHSX;
				row[CEntity������Ϣ��.FILED_GCLXS] = entity.GCLXS;
				row[CEntity������Ϣ��.FILED_TISXX] = entity.TISXX;
				row[CEntity������Ϣ��.FILED_JISJS] = entity.JISJS;
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
			this.Columns.Add(CEntity������Ϣ��.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_GLDEH, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_DEMC, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_DEDW, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_GLDHSX, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_GCLXS, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_TISXX, typeof(System.String));
			this.Columns.Add(CEntity������Ϣ��.FILED_JISJS, typeof(System.String));
		}
	}
}
