/*
 基础信息表
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _InfomationSource : _ObjectSource
    {
        public _InfomationSource()
            : base()
        {
            this.TableName = "基础表";
            Builder();
        }

        public virtual void Builder()
        {
            this.Columns.Add("Key", typeof(string));
            this.Columns.Add("Value", typeof(string));
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }

        /// <summary>
        /// 根据Key获取值
        /// </summary>
        /// <param name="p_Key"></param>
        /// <returns></returns>
        public object Get(object p_Key)
        {
            DataRow row = this.Rows.Find(p_Key);
            if (row != null)
            {
                return row["Value"];
            }
            return null;
        }

        /// <summary>
        /// 根据Key获取值
        /// </summary>
        /// <param name="p_Key"></param>
        /// <returns></returns>
        public T Get<T>(object p_Key)
        {
            try
            {
                DataRow row = this.Rows.Find(p_Key);
                return (T)Convert.ChangeType(row["Value"], typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 如果存在修改 否则新增一个属性
        /// </summary>
        /// <param name="p_Key"></param>
        /// <param name="p_Value"></param>
        public void Set(object p_Key, object p_Value)
        {
            DataRow row = this.Rows.Find(p_Key);
            if (row != null)
            {
                row.BeginEdit();
                row["Value"] = p_Value;
                row.EndEdit();
            }
            else
            {
                row = this.NewRow();
                row.BeginEdit();
                row["Key"] = p_Key;
                row["Value"] = p_Value;
                row.EndEdit();
                this.Rows.Add(row);
            }
        }
        
    }
}
