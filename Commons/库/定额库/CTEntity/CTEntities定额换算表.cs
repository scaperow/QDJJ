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
	///������ʵ�弯����
	/// </summary>
	[Serializable]
	public class CTEntities������ : CTEntities
	{
		/// <summary>
		///��¼������ֵ(˽�г�Ա)Ĭ��Ϊ-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// ��Աʵ��(�����ظ�ȡ����)
		/// </summary>
		private CEntity������ m_CEntity������;
		/// <summary>
		///���캯��
		/// </summary>
		public CTEntities������()
		{
			this.buliderTable();
		}
		/// <summary>
		///�����л����캯��
		/// </summary>
		public CTEntities������(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// ��ȡ��ǰ����ָ���е�ʵ�����
		/// </summary>
		/// <param name="index">�������е�����</param>
		/// <returns>��ص�ʵ�����(û�м�¼�򷵻ؿ�)</returns>
		public CEntity������ this[int index]
		{
			get
			{
				//���ǰһ��ִ���Ѿ�ת������ǰ������ֱ�ӷ���
				if (index == this.m_index) return this.m_CEntity������;
				if (this.Rows.Count > 0)
				{
					m_CEntity������ = new CEntity������();
					m_CEntity������.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_DINGEH]);
					m_CEntity������.HUANSLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_HUANSLB]);
					m_CEntity������.TISXX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_TISXX]);
					m_CEntity������.HUANSJS_R		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_HUANSJS_R]);
					m_CEntity������.HUANSDEH_C		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_HUANSDEH_C]);
					m_CEntity������.ZENGL_J		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_ZENGL_J]);
					m_CEntity������.ZC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_ZC]);
					m_CEntity������.SB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_SB]);
					m_CEntity������.DJDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_DJDW]);
					m_CEntity������.FZ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_FZ]);
					m_CEntity������.XHLB		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_XHLB]);
					m_CEntity������.THZHC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_THZHC]);
					m_CEntity������.THWZFC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_THWZFC]);
					m_CEntity������.HSXI		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity������.FILED_HSXI]);
					this.m_index = index;
					return m_CEntity������;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity������.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity������.FILED_HUANSLB] = value.HUANSLB; 
				this.Rows[index][CEntity������.FILED_TISXX] = value.TISXX; 
				this.Rows[index][CEntity������.FILED_HUANSJS_R] = value.HUANSJS_R; 
				this.Rows[index][CEntity������.FILED_HUANSDEH_C] = value.HUANSDEH_C; 
				this.Rows[index][CEntity������.FILED_ZENGL_J] = value.ZENGL_J; 
				this.Rows[index][CEntity������.FILED_ZC] = value.ZC; 
				this.Rows[index][CEntity������.FILED_SB] = value.SB; 
				this.Rows[index][CEntity������.FILED_DJDW] = value.DJDW; 
				this.Rows[index][CEntity������.FILED_FZ] = value.FZ; 
				this.Rows[index][CEntity������.FILED_XHLB] = value.XHLB; 
				this.Rows[index][CEntity������.FILED_THZHC] = value.THZHC; 
				this.Rows[index][CEntity������.FILED_THWZFC] = value.THWZFC; 
				this.Rows[index][CEntity������.FILED_HSXI] = value.HSXI; 
			}
		}
		/// <summary>
		/// ��ǰʵ�弯����׷�ӵ���ʵ��
		/// </summary>
		/// <param name="entity">Ҫ׷�ӵ�ʵ�����</param>
		/// <returns>׷�ӵ��е�����(��ǰ)</returns>
		public int AppendEntityInfo(CEntity������ entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity������.FILED_DINGEH] = entity.DINGEH;
				row[CEntity������.FILED_HUANSLB] = entity.HUANSLB;
				row[CEntity������.FILED_TISXX] = entity.TISXX;
				row[CEntity������.FILED_HUANSJS_R] = entity.HUANSJS_R;
				row[CEntity������.FILED_HUANSDEH_C] = entity.HUANSDEH_C;
				row[CEntity������.FILED_ZENGL_J] = entity.ZENGL_J;
				row[CEntity������.FILED_ZC] = entity.ZC;
				row[CEntity������.FILED_SB] = entity.SB;
				row[CEntity������.FILED_DJDW] = entity.DJDW;
				row[CEntity������.FILED_FZ] = entity.FZ;
				row[CEntity������.FILED_XHLB] = entity.XHLB;
				row[CEntity������.FILED_THZHC] = entity.THZHC;
				row[CEntity������.FILED_THWZFC] = entity.THWZFC;
				row[CEntity������.FILED_HSXI] = entity.HSXI;
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
			this.Columns.Add(CEntity������.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_HUANSLB, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_TISXX, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_HUANSJS_R, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_HUANSDEH_C, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_ZENGL_J, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_ZC, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_SB, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_DJDW, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_FZ, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_XHLB, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_THZHC, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_THWZFC, typeof(System.String));
			this.Columns.Add(CEntity������.FILED_HSXI, typeof(System.String));
		}
	}
}
