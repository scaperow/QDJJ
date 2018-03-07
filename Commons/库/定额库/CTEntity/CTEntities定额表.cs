/*****************************************************************
*表示企业集合实体的集合版本
*生成日期:2011年09月16日　04时06分14秒
备注:
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
	///定额表实体集合类
	/// </summary>
	[Serializable]
	public class CTEntities定额表 : CTEntities
	{
		/// <summary>
		///记录索引的值(私有成员)默认为-1
		/// </summary>
		private int m_index = -1;
		/// <summary>
		/// 成员实体(避免重复取索引)
		/// </summary>
		private CEntity定额表 m_CEntity定额表;
		/// <summary>
		///构造函数
		/// </summary>
		public CTEntities定额表()
		{
			this.buliderTable();
		}
		/// <summary>
		///反序列化构造函数
		/// </summary>
		public CTEntities定额表(SerializationInfo info, StreamingContext context):base(info, context)
		{
		}
		/// <summary>
		/// 获取当前集合指定行的实体对象
		/// </summary>
		/// <param name="index">集合中行的索引</param>
		/// <returns>相关的实体对象(没有记录则返回空)</returns>
		public CEntity定额表 this[int index]
		{
			get
			{
				//如果前一次执行已经转换过当前索引则直接返回
				if (index == this.m_index) return this.m_CEntity定额表;
				if (this.Rows.Count > 0)
				{
					m_CEntity定额表 = new CEntity定额表();
					m_CEntity定额表.DINGESYBH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGESYBH]);
					m_CEntity定额表.TX1		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_TX1]);
					m_CEntity定额表.TX2		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_TX2]);
					m_CEntity定额表.TX3		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_TX3]);
					m_CEntity定额表.DINGEH		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGEH]);
					m_CEntity定额表.DINGEMC		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGEMC]);
					m_CEntity定额表.DINGEDW		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGEDW]);
					m_CEntity定额表.DINGEJJ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGEJJ]);
					m_CEntity定额表.RENGF		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_RENGF]);
					m_CEntity定额表.CAILF		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_CAILF]);
					m_CEntity定额表.JIXF		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_JIXF]);
					m_CEntity定额表.JIANGX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_JIANGX]);
					m_CEntity定额表.DINGESX		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGESX]);
					m_CEntity定额表.DINGESM		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DINGESM]);
					m_CEntity定额表.DECJ		 = CDataConvert.ConToValue<System.String>(this.Rows[index][CEntity定额表.FILED_DECJ]);
					this.m_index = index;
					return m_CEntity定额表;
				}
				return null;
			}
			set
			{
				this.Rows[index][CEntity定额表.FILED_DINGESYBH] = value.DINGESYBH; 
				this.Rows[index][CEntity定额表.FILED_TX1] = value.TX1; 
				this.Rows[index][CEntity定额表.FILED_TX2] = value.TX2; 
				this.Rows[index][CEntity定额表.FILED_TX3] = value.TX3; 
				this.Rows[index][CEntity定额表.FILED_DINGEH] = value.DINGEH; 
				this.Rows[index][CEntity定额表.FILED_DINGEMC] = value.DINGEMC; 
				this.Rows[index][CEntity定额表.FILED_DINGEDW] = value.DINGEDW; 
				this.Rows[index][CEntity定额表.FILED_DINGEJJ] = value.DINGEJJ; 
				this.Rows[index][CEntity定额表.FILED_RENGF] = value.RENGF; 
				this.Rows[index][CEntity定额表.FILED_CAILF] = value.CAILF; 
				this.Rows[index][CEntity定额表.FILED_JIXF] = value.JIXF; 
				this.Rows[index][CEntity定额表.FILED_JIANGX] = value.JIANGX; 
				this.Rows[index][CEntity定额表.FILED_DINGESX] = value.DINGESX; 
				this.Rows[index][CEntity定额表.FILED_DINGESM] = value.DINGESM; 
				this.Rows[index][CEntity定额表.FILED_DECJ] = value.DECJ; 
			}
		}
		/// <summary>
		/// 当前实体集合中追加单个实体
		/// </summary>
		/// <param name="entity">要追加的实体对象</param>
		/// <returns>追加的行的索引(当前)</returns>
		public int AppendEntityInfo(CEntity定额表 entity)
		{
			if (this == null || this.Columns.Count == 0)
			{
				this.buliderTable();
			}
			if (entity != null)
			{
				DataRow row = this.NewRow();
				row[CEntity定额表.FILED_DINGESYBH] = entity.DINGESYBH;
				row[CEntity定额表.FILED_TX1] = entity.TX1;
				row[CEntity定额表.FILED_TX2] = entity.TX2;
				row[CEntity定额表.FILED_TX3] = entity.TX3;
				row[CEntity定额表.FILED_DINGEH] = entity.DINGEH;
				row[CEntity定额表.FILED_DINGEMC] = entity.DINGEMC;
				row[CEntity定额表.FILED_DINGEDW] = entity.DINGEDW;
				row[CEntity定额表.FILED_DINGEJJ] = entity.DINGEJJ;
				row[CEntity定额表.FILED_RENGF] = entity.RENGF;
				row[CEntity定额表.FILED_CAILF] = entity.CAILF;
				row[CEntity定额表.FILED_JIXF] = entity.JIXF;
				row[CEntity定额表.FILED_JIANGX] = entity.JIANGX;
				row[CEntity定额表.FILED_DINGESX] = entity.DINGESX;
				row[CEntity定额表.FILED_DINGESM] = entity.DINGESM;
				row[CEntity定额表.FILED_DECJ] = entity.DECJ;
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
			this.Columns.Add(CEntity定额表.FILED_DINGESYBH, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_TX1, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_TX2, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_TX3, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DINGEH, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DINGEMC, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DINGEDW, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DINGEJJ, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_RENGF, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_CAILF, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_JIXF, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_JIANGX, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DINGESX, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DINGESM, typeof(System.String));
			this.Columns.Add(CEntity定额表.FILED_DECJ, typeof(System.String));
		}
	}
}
