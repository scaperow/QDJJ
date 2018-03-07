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
	///ͼ�����ݱ�ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntitiesͼ�����ݱ� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityͼ�����ݱ� m_CEntityͼ�����ݱ�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesͼ�����ݱ�()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntitiesͼ�����ݱ�(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityͼ�����ݱ� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityͼ�����ݱ�;
				if (this.Rows.Count > 0)
				{
					m_CEntityͼ�����ݱ� = new CEntityͼ�����ݱ�();
					m_CEntityͼ�����ݱ�.TJBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����ݱ�.FILED_TJBH]);
					m_CEntityͼ�����ݱ�.ZFBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����ݱ�.FILED_ZFBH]);
					m_CEntityͼ�����ݱ�.ZFMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����ݱ�.FILED_ZFMC]);
					m_CEntityͼ�����ݱ�.TJDE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityͼ�����ݱ�.FILED_TJDE]);
					this.m_index = index;
					return m_CEntityͼ�����ݱ�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityͼ�����ݱ�.FILED_TJBH] = value.TJBH; 
				this.Rows[index][CEntityͼ�����ݱ�.FILED_ZFBH] = value.ZFBH; 
				this.Rows[index][CEntityͼ�����ݱ�.FILED_ZFMC] = value.ZFMC; 
				this.Rows[index][CEntityͼ�����ݱ�.FILED_TJDE] = value.TJDE; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityͼ�����ݱ� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityͼ�����ݱ�.FILED_TJBH] = entity.TJBH;
				row[CEntityͼ�����ݱ�.FILED_ZFBH] = entity.ZFBH;
				row[CEntityͼ�����ݱ�.FILED_ZFMC] = entity.ZFMC;
				row[CEntityͼ�����ݱ�.FILED_TJDE] = entity.TJDE;
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
			this.Columns.Add(CEntityͼ�����ݱ�.FILED_TJBH, typeof(System.String));
			this.Columns.Add(CEntityͼ�����ݱ�.FILED_ZFBH, typeof(System.String));
			this.Columns.Add(CEntityͼ�����ݱ�.FILED_ZFMC, typeof(System.String));
			this.Columns.Add(CEntityͼ�����ݱ�.FILED_TJDE, typeof(System.String));
		}
	}
}
