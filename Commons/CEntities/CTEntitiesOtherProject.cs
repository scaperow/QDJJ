/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��43��08�ա�05ʱ11��33��
��ע:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;
namespace  GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///OTHERPROJECTʵ�弯����
	/// </summary>
	[Serializable]
    public class CTEntitiesOtherProject : DataTable
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityOtherProject m_CEntityOtherProject;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesOtherProject()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntitiesOtherProject(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityOtherProject this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityOtherProject;
				if (this.Rows.Count > 0)
				{
					m_CEntityOtherProject = new CEntityOtherProject();
					m_CEntityOtherProject.ID		 = ToolKit.ParseInt(this.Rows[index][CEntityOtherProject.FILED_ID]);
					m_CEntityOtherProject.PARENTID		 = ToolKit.ParseInt(this.Rows[index][CEntityOtherProject.FILED_PARENTID]);
					m_CEntityOtherProject.NUMBER		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_NUMBER]);
					m_CEntityOtherProject.NAME		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_NAME]);
					m_CEntityOtherProject.UNIT		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_UNIT]);
					m_CEntityOtherProject.QUANTITIES		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_QUANTITIES]);
					m_CEntityOtherProject.CALCULATION		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_CALCULATION]);
					m_CEntityOtherProject.COEFFICIENT		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_COEFFICIENT]);
					m_CEntityOtherProject.UNITPRICE		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_UNITPRICE]);
					m_CEntityOtherProject.COMBINEDPRICE		 = CDataConvert.ConToValue<System.Decimal>(this.Rows[index][CEntityOtherProject.FILED_COMBINEDPRICE]);
					m_CEntityOtherProject.REMARK		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityOtherProject.FILED_REMARK]);
					this.m_index = index;
					return m_CEntityOtherProject;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityOtherProject.FILED_ID] = value.ID; 
				this.Rows[index][CEntityOtherProject.FILED_PARENTID] = value.PARENTID; 
				this.Rows[index][CEntityOtherProject.FILED_NUMBER] = value.NUMBER; 
				this.Rows[index][CEntityOtherProject.FILED_NAME] = value.NAME; 
				this.Rows[index][CEntityOtherProject.FILED_UNIT] = value.UNIT; 
				this.Rows[index][CEntityOtherProject.FILED_QUANTITIES] = value.QUANTITIES; 
				this.Rows[index][CEntityOtherProject.FILED_CALCULATION] = value.CALCULATION; 
				this.Rows[index][CEntityOtherProject.FILED_COEFFICIENT] = value.COEFFICIENT; 
				this.Rows[index][CEntityOtherProject.FILED_UNITPRICE] = value.UNITPRICE; 
				this.Rows[index][CEntityOtherProject.FILED_COMBINEDPRICE] = value.COMBINEDPRICE; 
				this.Rows[index][CEntityOtherProject.FILED_REMARK] = value.REMARK; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityOtherProject entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityOtherProject.FILED_ID] = entity.ID;
				row[CEntityOtherProject.FILED_PARENTID] = entity.PARENTID;
				row[CEntityOtherProject.FILED_NUMBER] = entity.NUMBER;
				row[CEntityOtherProject.FILED_NAME] = entity.NAME;
				row[CEntityOtherProject.FILED_UNIT] = entity.UNIT;
				row[CEntityOtherProject.FILED_QUANTITIES] = entity.QUANTITIES;
				row[CEntityOtherProject.FILED_CALCULATION] = entity.CALCULATION;
				row[CEntityOtherProject.FILED_COEFFICIENT] = entity.COEFFICIENT;
				row[CEntityOtherProject.FILED_UNITPRICE] = entity.UNITPRICE;
				row[CEntityOtherProject.FILED_COMBINEDPRICE] = entity.COMBINEDPRICE;
				row[CEntityOtherProject.FILED_REMARK] = entity.REMARK;
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
			this.Columns.Add(CEntityOtherProject.FILED_ID, typeof(System.Int32));
			this.Columns.Add(CEntityOtherProject.FILED_PARENTID, typeof(System.Int32));
			this.Columns.Add(CEntityOtherProject.FILED_NUMBER, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_NAME, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_UNIT, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_QUANTITIES, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_CALCULATION, typeof(System.String));
			this.Columns.Add(CEntityOtherProject.FILED_COEFFICIENT, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_UNITPRICE, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_COMBINEDPRICE, typeof(System.Decimal));
			this.Columns.Add(CEntityOtherProject.FILED_REMARK, typeof(System.String));
		}
	}
}
