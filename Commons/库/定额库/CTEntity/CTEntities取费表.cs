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
	///ȡ�ѱ�ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntitiesȡ�ѱ� : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityȡ�ѱ� m_CEntityȡ�ѱ�;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesȡ�ѱ�()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntitiesȡ�ѱ�(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityȡ�ѱ� this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityȡ�ѱ�;
				if (this.Rows.Count > 0)
				{
					m_CEntityȡ�ѱ� = new CEntityȡ�ѱ�();
					m_CEntityȡ�ѱ�.GONGCLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_GONGCLB]);
					m_CEntityȡ�ѱ�.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_DINGEH]);
					m_CEntityȡ�ѱ�.GUANLFL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_GUANLFL]);
					m_CEntityȡ�ѱ�.LIRL		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_LIRL]);
					m_CEntityȡ�ѱ�.FXLBD		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_FXLBD]);
					m_CEntityȡ�ѱ�.FXLTB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_FXLTB]);
					m_CEntityȡ�ѱ�.GLBDJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_GLBDJC]);
					m_CEntityȡ�ѱ�.GLTBJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_GLTBJC]);
					m_CEntityȡ�ѱ�.LRBDJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_LRBDJC]);
					m_CEntityȡ�ѱ�.LRTBJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_LRTBJC]);
					m_CEntityȡ�ѱ�.FXBDJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_FXBDJC]);
					m_CEntityȡ�ѱ�.FXTBJC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_FXTBJC]);
					m_CEntityȡ�ѱ�.SFHH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityȡ�ѱ�.FILED_SFHH]);
					this.m_index = index;
					return m_CEntityȡ�ѱ�;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityȡ�ѱ�.FILED_GONGCLB] = value.GONGCLB; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_GUANLFL] = value.GUANLFL; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_LIRL] = value.LIRL; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_FXLBD] = value.FXLBD; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_FXLTB] = value.FXLTB; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_GLBDJC] = value.GLBDJC; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_GLTBJC] = value.GLTBJC; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_LRBDJC] = value.LRBDJC; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_LRTBJC] = value.LRTBJC; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_FXBDJC] = value.FXBDJC; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_FXTBJC] = value.FXTBJC; 
				this.Rows[index][CEntityȡ�ѱ�.FILED_SFHH] = value.SFHH; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityȡ�ѱ� entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityȡ�ѱ�.FILED_GONGCLB] = entity.GONGCLB;
				row[CEntityȡ�ѱ�.FILED_DINGEH] = entity.DINGEH;
				row[CEntityȡ�ѱ�.FILED_GUANLFL] = entity.GUANLFL;
				row[CEntityȡ�ѱ�.FILED_LIRL] = entity.LIRL;
				row[CEntityȡ�ѱ�.FILED_FXLBD] = entity.FXLBD;
				row[CEntityȡ�ѱ�.FILED_FXLTB] = entity.FXLTB;
				row[CEntityȡ�ѱ�.FILED_GLBDJC] = entity.GLBDJC;
				row[CEntityȡ�ѱ�.FILED_GLTBJC] = entity.GLTBJC;
				row[CEntityȡ�ѱ�.FILED_LRBDJC] = entity.LRBDJC;
				row[CEntityȡ�ѱ�.FILED_LRTBJC] = entity.LRTBJC;
				row[CEntityȡ�ѱ�.FILED_FXBDJC] = entity.FXBDJC;
				row[CEntityȡ�ѱ�.FILED_FXTBJC] = entity.FXTBJC;
				row[CEntityȡ�ѱ�.FILED_SFHH] = entity.SFHH;
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
			this.Columns.Add(CEntityȡ�ѱ�.FILED_GONGCLB, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_GUANLFL, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_LIRL, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_FXLBD, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_FXLTB, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_GLBDJC, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_GLTBJC, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_LRBDJC, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_LRTBJC, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_FXBDJC, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_FXTBJC, typeof(System.String));
			this.Columns.Add(CEntityȡ�ѱ�.FILED_SFHH, typeof(System.String));
		}
	}
}
