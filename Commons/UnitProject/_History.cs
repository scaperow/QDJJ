/*
    当前单位工程的保存历史对象
 *  1.提供历史保存信息清单
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 单位工程历史清单类
    /// </summary>
    [Serializable]
    public class _History
    {
        /// <summary>
        /// 单位工程历史
        /// </summary>
        public _History()
        {
            this.m_HistoryTable = CommonData.GetHistory("单位工程历史");
        }

        /// <summary>
        /// 历史表格
        /// </summary>
        private DataTable m_HistoryTable = null;

        /// <summary>
        /// 获取或设置当前单位工程的历史清单表格（每次保存时候会给此对象添加记录并且按照记录保存单位工程数据文件）
        /// </summary>
        public DataTable HistoryTable
        {
            get
            {
                return this.m_HistoryTable;
            }
            set
            {
                this.m_HistoryTable = value;
            }
        }

        /// <summary>
        /// 添加新的保存记录对象
        /// </summary>
        public string NewSave(_UnitProject p_info)
        {
            DataRow row = this.m_HistoryTable.NewRow();
            row["Name"]     = p_info.Property.Basis.Name;
            row["Date"]     = DateTime.Now;
            row["FileName"] = p_info.Property.Basis.Name + "-" + DateTime.Now.ToString("yyyyMMdd") + "_" + row["Key"] + _Files.单位工程备份扩展名;
            row["IsUse"] = true;
            this.m_HistoryTable.Rows.Add(row);
            return row["FileName"].ToString();
        }

        /// <summary>
        /// 添加新的保存记录对象
        /// </summary>
        public void NewSaveOfProject(_Projects p_infos)
        {
           /* DataRow row = this.m_HistoryTable.NewRow();
            row["Name"] = p_infos.Name;
            row["Date"] = DateTime.Now;
            row["FileName"] = DateTime.Now + "_" + row["Key"];
            this.m_HistoryTable.Rows.Add(row);*/
        }
    }
}
