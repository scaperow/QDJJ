using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _InventorySummary
    {

        private int m_key;

        /// <summary>
        /// 当前子目或清单的key
        /// </summary>
        public int Key
        {
            get
            {
                return this.m_key;
            }
            set
            {
                this.m_key = value;
               //QDSummary();
            }
        }
        /// <summary>
        /// 工料机对象
        /// </summary>
        [NonSerialized]
        private DataTable m_DataTable = null;
        /// <summary>
        /// 工料机对象
        /// </summary>
        public DataTable Mdata
        {
            get { return m_DataTable; }
            set { m_DataTable = value; }
        }
        private CTEntitiesQuantityUnitSummary m_Source;
        public CTEntitiesQuantityUnitSummary Source
        {
            get { return m_Source; }
        }
        public _InventorySummary()
        {
           

        }
        private void QDSummary()
        {
            m_Source = new CTEntitiesQuantityUnitSummary();
            DataRow[] rows = m_DataTable.Select(string.Format("QID={0}", m_key));
            getSumary(rows);
        }
        private void getSumary(DataRow[] rows)
        {

            foreach (DataRow row in rows)
            {

                string caijbh = row.Field<String>("BH");
                DataRow row0 = null;
                //若同工料编号的没有汇总则添加
                bool flag = IsExist(caijbh, out row0);
                if (flag)
                {
                    CEntityQuantityUnitSummary info = new CEntityQuantityUnitSummary();
                    info.BH = caijbh;
                    info.MC = row.Field<String>("YSMC");
                    //info赋值并添加到结果集中
                    this.m_Source.AppendEntityInfo(info);
                }
                else
                {
                    row0["SLH"] = Convert.ToDecimal(row0["SLH"]) + Convert.ToDecimal(row["YSXHL"]);
                    //其他需要累加的 
                }

            }

        }
        private bool IsExist(string BH, out DataRow row)
        {
            bool flag = true;
            DataRow[] rows = this.m_Source.Select(string.Format("BH='{0}'", BH));
            if (rows != null)
            {
                if (rows.Length > 0)
                {
                    row = rows[0];
                    flag = false;
                }
                else
                {
                    row = null;
                }
            }
            else
            {
                row = null;
            }
            return flag;
        }
    }
}
