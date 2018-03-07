/*****************************************************************
*��ʾ��ҵ����ʵ��ļ��ϰ汾
*��������:2011��04��25�ա�03ʱ10��15��
��ע:
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.Serialization;
namespace GOLDSOFT.QDJJ.COMMONS
{
	/// <summary>
	///STANDARDCONVERSIONʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntitiesStandardConversion : 	CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntityStandardConversion m_CEntityStandardConversion;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntitiesStandardConversion()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntitiesStandardConversion(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntityStandardConversion this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntityStandardConversion;
				if (this.Rows.Count > 0)
				{
					m_CEntityStandardConversion = new CEntityStandardConversion();
					m_CEntityStandardConversion.ID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_ID]);
					m_CEntityStandardConversion.XID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_XID]);
					m_CEntityStandardConversion.DID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_DID]);
					m_CEntityStandardConversion.QID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_QID]);
					m_CEntityStandardConversion.ZID		 = ToolKit.ParseInt(this.Rows[index][CEntityStandardConversion.FILED_ZID]);
                    m_CEntityStandardConversion.IFXZ = ToolKit.ParseBoolen(this.Rows[index][CEntityStandardConversion.FILED_IFXZ]);
                    m_CEntityStandardConversion.IFHS = ToolKit.ParseBoolen(this.Rows[index][CEntityStandardConversion.FILED_IFHS]);
					m_CEntityStandardConversion.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_DINGEH]);
					m_CEntityStandardConversion.HUANSLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HUANSLB]);
					m_CEntityStandardConversion.TISXX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_TISXX]);
					m_CEntityStandardConversion.HUANSJS_R		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HUANSJS_R]);
					m_CEntityStandardConversion.HUANSDEH_C		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HUANSDEH_C]);
					m_CEntityStandardConversion.ZENGL_J		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_ZENGL_J]);
					m_CEntityStandardConversion.ZC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_ZC]);
					m_CEntityStandardConversion.SB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_SB]);
					m_CEntityStandardConversion.DJDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_DJDW]);
					m_CEntityStandardConversion.FZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_FZ]);
					m_CEntityStandardConversion.XHLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_XHLB]);
					m_CEntityStandardConversion.THZHC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_THZHC]);
					m_CEntityStandardConversion.THWZFC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_THWZFC]);
					m_CEntityStandardConversion.HSXI		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntityStandardConversion.FILED_HSXI]);
					this.m_index = index;
					return m_CEntityStandardConversion;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntityStandardConversion.FILED_ID] = value.ID; 
				this.Rows[index][CEntityStandardConversion.FILED_XID] = value.XID; 
				this.Rows[index][CEntityStandardConversion.FILED_DID] = value.DID; 
				this.Rows[index][CEntityStandardConversion.FILED_QID] = value.QID; 
				this.Rows[index][CEntityStandardConversion.FILED_ZID] = value.ZID;
                this.Rows[index][CEntityStandardConversion.FILED_IFXZ] = value.IFXZ; 
                this.Rows[index][CEntityStandardConversion.FILED_IFHS] = value.IFHS; 
				this.Rows[index][CEntityStandardConversion.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntityStandardConversion.FILED_HUANSLB] = value.HUANSLB; 
				this.Rows[index][CEntityStandardConversion.FILED_TISXX] = value.TISXX; 
				this.Rows[index][CEntityStandardConversion.FILED_HUANSJS_R] = value.HUANSJS_R; 
				this.Rows[index][CEntityStandardConversion.FILED_HUANSDEH_C] = value.HUANSDEH_C; 
				this.Rows[index][CEntityStandardConversion.FILED_ZENGL_J] = value.ZENGL_J; 
				this.Rows[index][CEntityStandardConversion.FILED_ZC] = value.ZC; 
				this.Rows[index][CEntityStandardConversion.FILED_SB] = value.SB; 
				this.Rows[index][CEntityStandardConversion.FILED_DJDW] = value.DJDW; 
				this.Rows[index][CEntityStandardConversion.FILED_FZ] = value.FZ; 
				this.Rows[index][CEntityStandardConversion.FILED_XHLB] = value.XHLB; 
				this.Rows[index][CEntityStandardConversion.FILED_THZHC] = value.THZHC; 
				this.Rows[index][CEntityStandardConversion.FILED_THWZFC] = value.THWZFC; 
				this.Rows[index][CEntityStandardConversion.FILED_HSXI] = value.HSXI; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntityStandardConversion entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntityStandardConversion.FILED_XID] = entity.XID;
				row[CEntityStandardConversion.FILED_DID] = entity.DID;
				row[CEntityStandardConversion.FILED_QID] = entity.QID;
				row[CEntityStandardConversion.FILED_ZID] = entity.ZID;
                row[CEntityStandardConversion.FILED_IFXZ] = entity.IFXZ;
                row[CEntityStandardConversion.FILED_IFHS] = entity.IFHS;
				row[CEntityStandardConversion.FILED_DINGEH] = entity.DINGEH;
				row[CEntityStandardConversion.FILED_HUANSLB] = entity.HUANSLB;
				row[CEntityStandardConversion.FILED_TISXX] = entity.TISXX;
				row[CEntityStandardConversion.FILED_HUANSJS_R] = entity.HUANSJS_R;
				row[CEntityStandardConversion.FILED_HUANSDEH_C] = entity.HUANSDEH_C;
				row[CEntityStandardConversion.FILED_ZENGL_J] = entity.ZENGL_J;
				row[CEntityStandardConversion.FILED_ZC] = entity.ZC;
				row[CEntityStandardConversion.FILED_SB] = entity.SB;
				row[CEntityStandardConversion.FILED_DJDW] = entity.DJDW;
				row[CEntityStandardConversion.FILED_FZ] = entity.FZ;
				row[CEntityStandardConversion.FILED_XHLB] = entity.XHLB;
				row[CEntityStandardConversion.FILED_THZHC] = entity.THZHC;
				row[CEntityStandardConversion.FILED_THWZFC] = entity.THWZFC;
				row[CEntityStandardConversion.FILED_HSXI] = entity.HSXI;
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
			this.Columns.Add(CEntityStandardConversion.FILED_ID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_XID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_DID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_QID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_ZID, typeof(System.Int32));
			this.Columns.Add(CEntityStandardConversion.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HUANSLB, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_TISXX, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HUANSJS_R, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HUANSDEH_C, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_ZENGL_J, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_ZC, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_SB, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_DJDW, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_FZ, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_XHLB, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_THZHC, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_THWZFC, typeof(System.String));
			this.Columns.Add(CEntityStandardConversion.FILED_HSXI, typeof(System.String));
            this.Columns.Add(CEntityStandardConversion.FILED_IFHS, typeof(System.Boolean));
            this.Columns.Add(CEntityStandardConversion.FILED_IFXZ, typeof(System.Boolean));

            //�����Զ�������
            this.Columns[CEntityStandardConversion.FILED_ID].AutoIncrement = true;
            this.Columns[CEntityStandardConversion.FILED_ID].AutoIncrementSeed = 1;
            this.Columns[CEntityStandardConversion.FILED_ID].AutoIncrementStep = 1;
		}
	}
}
