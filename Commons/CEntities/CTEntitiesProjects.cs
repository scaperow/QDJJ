/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��57��13�ա�05ʱ06��06��
��ע:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///PROJECTSʵ�弯����
	/// </summary>
	public class CTEntitiesProjects : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityProjects m_CEntityProjects;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesProjects()
		{
			this.buliderTable();
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityProjects this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityProjects;
				if (this.Rows.Count > 0)
				{
					m_CEntityProjects = new CEntityProjects();
					m_CEntityProjects.ID		 = CDataConvert.ConToValue<System.Int64>(this.Rows[index][CEntityProjects.FILED_ID]);
					m_CEntityProjects.PROJECTCODE		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PROJECTCODE]);
					m_CEntityProjects.PASSWORD		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PASSWORD]);
					m_CEntityProjects.PGCDD		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PGCDD]);
					//m_CEntityProjects.PQDGZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PQDGZ]);
					//m_CEntityProjects.PDEGZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PDEGZ]);
					m_CEntityProjects.PJFCX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PJFCX]);
					m_CEntityProjects.PNSDD		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PNSDD]);
					m_CEntityProjects.CREATOR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_CREATOR]);
					m_CEntityProjects.EDITOR		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_EDITOR]);
					m_CEntityProjects.FISTDATETIME		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_FISTDATETIME]);
					m_CEntityProjects.EDITDATETIME		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_EDITDATETIME]);
                    m_CEntityProjects.PROJECTNAME = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityProjects.FILED_PROJECTNAME]);
					this.m_index = index;
					return m_CEntityProjects;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityProjects.FILED_ID] = value.ID; 
				this.Rows[index][CEntityProjects.FILED_PROJECTCODE] = value.PROJECTCODE; 
				this.Rows[index][CEntityProjects.FILED_PASSWORD] = value.PASSWORD; 
				this.Rows[index][CEntityProjects.FILED_PGCDD] = value.PGCDD; 
				//this.Rows[index][CEntityProjects.FILED_PQDGZ] = value.PQDGZ; 
				//this.Rows[index][CEntityProjects.FILED_PDEGZ] = value.PDEGZ; 
				this.Rows[index][CEntityProjects.FILED_PJFCX] = value.PJFCX; 
				this.Rows[index][CEntityProjects.FILED_PNSDD] = value.PNSDD; 
				this.Rows[index][CEntityProjects.FILED_CREATOR] = value.CREATOR; 
				this.Rows[index][CEntityProjects.FILED_EDITOR] = value.EDITOR; 
				this.Rows[index][CEntityProjects.FILED_FISTDATETIME] = value.FISTDATETIME; 
				this.Rows[index][CEntityProjects.FILED_EDITDATETIME] = value.EDITDATETIME;
                this.Rows[index][CEntityProjects.FILED_PROJECTNAME] = value.PROJECTNAME; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityProjects entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityProjects.FILED_ID] = entity.ID;
				row[CEntityProjects.FILED_PROJECTCODE] = entity.PROJECTCODE;
				row[CEntityProjects.FILED_PASSWORD] = entity.PASSWORD;
				row[CEntityProjects.FILED_PGCDD] = entity.PGCDD;
				//row[CEntityProjects.FILED_PQDGZ] = entity.PQDGZ;
				//row[CEntityProjects.FILED_PDEGZ] = entity.PDEGZ;
				row[CEntityProjects.FILED_PJFCX] = entity.PJFCX;
				row[CEntityProjects.FILED_PNSDD] = entity.PNSDD;
				row[CEntityProjects.FILED_CREATOR] = entity.CREATOR;
				row[CEntityProjects.FILED_EDITOR] = entity.EDITOR;
				row[CEntityProjects.FILED_FISTDATETIME] = entity.FISTDATETIME;
				row[CEntityProjects.FILED_EDITDATETIME] = entity.EDITDATETIME;
                row[CEntityProjects.FILED_PROJECTNAME] = entity.PROJECTNAME;
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
			this.Columns.Add(CEntityProjects.FILED_ID, typeof(System.Int64));
			this.Columns.Add(CEntityProjects.FILED_PROJECTCODE, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_PASSWORD, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_PGCDD, typeof(System.String));
			//this.Columns.Add(CEntityProjects.FILED_PQDGZ, typeof(System.String));
			//this.Columns.Add(CEntityProjects.FILED_PDEGZ, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_PJFCX, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_PNSDD, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_CREATOR, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_EDITOR, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_FISTDATETIME, typeof(System.String));
			this.Columns.Add(CEntityProjects.FILED_EDITDATETIME, typeof(System.String));
            this.Columns.Add(CEntityProjects.FILED_PROJECTNAME, typeof(System.String));
		}
	}
}
