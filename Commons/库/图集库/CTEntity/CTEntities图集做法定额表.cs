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
	///ͼ�����������ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntitiesͼ����������� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityͼ����������� m_CEntityͼ�����������;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesͼ�����������()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntitiesͼ�����������(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityͼ����������� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityͼ�����������;
				if (this.Rows.Count > 0)
				{
					m_CEntityͼ����������� = new CEntityͼ�����������();
					m_CEntityͼ�����������.ZFBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_ZFBH]);
					m_CEntityͼ�����������.ZFDEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_ZFDEH]);
					m_CEntityͼ�����������.DEMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_DEMC]);
					m_CEntityͼ�����������.DEDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_DEDW]);
					m_CEntityͼ�����������.XS		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_XS]);
					m_CEntityͼ�����������.DECJ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_DECJ]);
					m_CEntityͼ�����������.TJH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����������.FILED_TJH]);
					this.m_index = index;
					return m_CEntityͼ�����������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityͼ�����������.FILED_ZFBH] = value.ZFBH; 
				this.Rows[index][CEntityͼ�����������.FILED_ZFDEH] = value.ZFDEH; 
				this.Rows[index][CEntityͼ�����������.FILED_DEMC] = value.DEMC; 
				this.Rows[index][CEntityͼ�����������.FILED_DEDW] = value.DEDW; 
				this.Rows[index][CEntityͼ�����������.FILED_XS] = value.XS; 
				this.Rows[index][CEntityͼ�����������.FILED_DECJ] = value.DECJ; 
				this.Rows[index][CEntityͼ�����������.FILED_TJH] = value.TJH; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityͼ����������� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityͼ�����������.FILED_ZFBH] = entity.ZFBH;
				row[CEntityͼ�����������.FILED_ZFDEH] = entity.ZFDEH;
				row[CEntityͼ�����������.FILED_DEMC] = entity.DEMC;
				row[CEntityͼ�����������.FILED_DEDW] = entity.DEDW;
				row[CEntityͼ�����������.FILED_XS] = entity.XS;
				row[CEntityͼ�����������.FILED_DECJ] = entity.DECJ;
				row[CEntityͼ�����������.FILED_TJH] = entity.TJH;
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
			this.Columns.Add(CEntityͼ�����������.FILED_ZFBH, typeof(System.String));
			this.Columns.Add(CEntityͼ�����������.FILED_ZFDEH, typeof(System.String));
			this.Columns.Add(CEntityͼ�����������.FILED_DEMC, typeof(System.String));
			this.Columns.Add(CEntityͼ�����������.FILED_DEDW, typeof(System.String));
			this.Columns.Add(CEntityͼ�����������.FILED_XS, typeof(System.String));
			this.Columns.Add(CEntityͼ�����������.FILED_DECJ, typeof(System.String));
			this.Columns.Add(CEntityͼ�����������.FILED_TJH, typeof(System.String));
		}
	}
}
