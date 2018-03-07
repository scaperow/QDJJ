using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Business
{
    /// <summary>
    /// 从数据库中安全获取数据，即当数据库中的数据为NULL时，保证读取不发生异常。
    /// </summary>
    public class GetSafeData
    {
        #region DataRow

        /// <summary>
        /// 从一个DataRow中，安全得到列colname中的值：值为字符串类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.String.Empty</returns>
        public static string ValidateDataRow_S(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return row[colname].ToString();
            else
                return System.String.Empty;
        }

        /// <summary>
        /// 从一个DataRow中，安全得到列colname中的值：值为整数类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Int32.MinValue</returns>
        public static int ValidateDataRow_N(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToInt32(row[colname]);
            else
                return System.Int32.MinValue;
        }

        /// <summary>
        /// 从一个DataRow中，安全得到列colname中的值：值为浮点数类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Double.MinValue</returns>
        public static double ValidateDataRow_F(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToDouble(row[colname]);
            else
                return 0;
        }

        public static decimal D_validateDataRow(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToDecimal(row[colname]);
            else
                return System.Decimal.MinValue;
        }
        public static double ValidateDataRow_0(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToDouble(row[colname]);
            else
                return 0;
        }

        /// <summary>
        /// 从一个DataRow中，安全得到列colname中的值：值为时间类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.DateTime.MinValue;</returns>
        public static DateTime ValidateDataRow_T(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToDateTime(row[colname]);
            else
                return System.DateTime.MinValue;
        }
        #endregion DataRow

    }
    public class ValiDateData
    {
        /// <summary>
        /// 判断项目是否被调用
        /// </summary>
        /// <param name="itemL">项目集合</param>
        /// <param name="itemS">项目名称</param>
        /// <returns></returns>
        public static bool itemVali(ArrayList itemL, string itemS)
        {
            foreach (string s in itemL)
            {
                if (s == itemS) return true;
            }
            return false;
        }
    }
}
