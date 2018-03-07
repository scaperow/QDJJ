using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _ProjStatistics : _Statistics
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_Parent"></param>
        public _ProjStatistics()
            : base()
        {
            //项目构造不需要任何结果对象
            this.ResultVarable.DataSource.Clear();
        }

        /// <summary>
        /// 指定项目统计结果汇总到当前对象中
        /// </summary>
        /// <param name="info"></param>
        public void Add(_COBJECTS info)
        {
            if (info == null) return;
            DataTable table = info.Property.Statistics.ResultVarable.DataSource;
            if (table == null) return;
            //循环集合为当前对象添加
            string key = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                key = row["Key"].ToString();
                //新加入的值
                decimal ovalue = info.Property.Statistics.ResultVarable.GetDecimal(key);
                //原来的值
                decimal cvalue = this.ResultVarable.GetDecimal(key);
                this.ResultVarable.Set(key, cvalue + ovalue, row["Remark"].ToString());
            }
        }
    }
}
