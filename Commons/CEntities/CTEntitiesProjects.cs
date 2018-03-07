/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年57月13日　05时06分06秒
备注:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///PROJECTS实体集合类
	/// </summary>
	public class CTEntitiesProjects : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntityProjects m_CEntityProjects;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntitiesProjects()
		{
			this.buliderTable();
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntityProjects this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
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
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
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
		/// 创建一个新的表结构
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
