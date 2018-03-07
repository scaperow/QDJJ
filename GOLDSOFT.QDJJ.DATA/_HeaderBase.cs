using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GOLDSOFT.QDJJ.DATA
{
    public class _HeaderBase
    {
        /// <summary>
        /// 链接对象
        /// </summary>
        public OleDbConnection Conn;

        public _HeaderBase(string conString)
        {
            if (Conn == null)
            {
                Conn = new OleDbConnection(conString);
            }
        }

        /// <summary>
        /// 获取头数据
        /// </summary>
        /// <returns></returns>
        public _FileHeader Get_FileHeader()
        {
            
                string sql = "select [value] from 变量表 where [key] = 'ZZJ' and [Type] = '-3'";

                object obj = this.ExecuteScalar(sql);

                if (obj != null)
                {
                    _FileHeader info = new _FileHeader();
                    info.Set("总造价", obj);
                    return info;
                }
                else
                {
                    return new _FileHeader();
                }
            
        }

        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="p_Table"></param>
        public void FillDataSet(string sql, DataTable p_Table)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(sql, Conn))
            {
                da.Fill(p_Table);
            }
        }

        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        public object ExecuteScalar(string sql)
        {
            using (OleDbCommand cmd = Conn.CreateCommand())
            {
                this.Conn.Open();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                object obj =cmd.ExecuteScalar();
                this.Conn.Close();
                return obj;
            }
        }
    }
}
