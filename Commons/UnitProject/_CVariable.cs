/*
 *  变量为某个类提供相关的键值对的保存容器
 *  其中值为计算获得输入的结果集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _CVariable
    {
        /// <summary>
        /// 提供变量表的基础数据保存
        /// </summary>
        private DataTable m_Table = null;

        public const string Median = "F2";
        /// <summary>
        /// 返回结果数据源
        /// </summary>
        public DataTable DataSource
        {
            get
            {
                return this.m_Table;
            }
            set
            {
                this.m_Table = value;
            }
        }

        /// <summary>
        /// 默认为子目变量
        /// </summary>
        public EVariable VariableType = EVariable.子目变量;

        public _CVariable()
        {
            builder();
            LoadData();
        }

        /// <summary>
        /// 重新加载变量集
        /// </summary>
        private void LoadData()
        {
            
        }

        /// <summary>
        /// 构造一个变量表
        /// </summary>
        private void builder()
        {
            this.m_Table = new DataTable("变量表");
            DataColumn dc = this.m_Table.Columns.Add("Key", typeof(string));//属性名称(显示的名称)
            this.m_Table.Columns.Add("Value", typeof(object));//属性值
            this.m_Table.Columns.Add("Remark", typeof(string));//(源字段)名称
            this.m_Table.Columns.Add("Length", typeof(int));//(源字段)名称
            this.m_Table.Columns.Add("FYLB", typeof(string));//(费用类别)
            this.m_Table.PrimaryKey = new DataColumn[] { dc };
        }

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        public void Set(string key, object value)
        {
            //lock (this.m_Table)
            {
                DataRow row = this.m_Table.Rows.Find(key);
                if (row == null)
                {
                    row = this.m_Table.NewRow();
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row.EndEdit();
                    this.m_Table.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row.EndEdit();
                }
            }
        }

        

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        /// <param name="remark">变量说明</param>
        public void Set(string key, object value, string remark)
        {
            //lock (this.m_Table)
            {

                DataRow row = this.m_Table.Rows.Find(key);
                if (row == null)
                {
                    row = this.m_Table.NewRow();
                    //row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    //row.EndEdit();
                    this.m_Table.Rows.Add(row);
                }
                else
                {
                    //row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    //row.EndEdit();
                }
            }
        }

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        /// <param name="remark">变量说明</param>
        public void Set(string key, object value, string remark,string p_fylb)
        {
            DataRow row = this.m_Table.Rows.Find(key);
            if (row == null)
            {
                row = this.m_Table.NewRow();
                row["Key"] = key;
                row["Value"] = Convert.ToDecimal(value).ToString(Median);
                row["Remark"] = remark;
                row["FYLB"] = p_fylb;
                row["Length"] = key.Length;
                this.m_Table.Rows.Add(row);
            }
            else
            {
                row["Key"] = key;
                row["Value"] = Convert.ToDecimal(value).ToString(Median);
                row["Remark"] = remark;
                row["FYLB"] = p_fylb;
                row["Length"] = key.Length;
            }
        }

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public object Get(string key)
        {
            DataRow row = this.m_Table.Rows.Find(key);
            if (row != null)
            {
                return row["Value"];
            }
            return null;
        }
        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public decimal GetDecimal(string key)
        {
            DataRow row = this.m_Table.Rows.Find(key);
            if (row != null)
            {
                return Convert.ToDecimal(row["Value"]);
            }
            return 0;
        }

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public decimal GetDecimalBYFylb(string key)
        {
            //lock (this.m_Table)
            {
                DataRow[] row = this.m_Table.Select(string.Format("FYLB='{0}'", key));

                if (row.Length == 1)
                {
                    return Convert.ToDecimal(row[0]["Value"].ToString());
                }
                return 0;
            }
        }

        
    }
}
