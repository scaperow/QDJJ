using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using ZiboSoft.Commons.Common;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ProjMetaanalysisSource : _ObjectSource
    {
        protected _ProjMetaanalysisSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "项目汇总分析表";
        }

        public _ProjMetaanalysisSource()
            : base()
        {
            this.TableName = "项目汇总分析表";
            Builder();
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("PID", typeof(int));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("FGCF", typeof(decimal));
            this.Columns.Add("CSXMF", typeof(decimal));
            this.Columns.Add("QTXMF", typeof(decimal));
            this.Columns.Add("GF", typeof(decimal));
            this.Columns.Add("SJ", typeof(decimal));
            this.Columns.Add("ZZJ", typeof(decimal));
            this.Columns.Add("AQWM", typeof(decimal));
            this.Columns.Add("LBTC", typeof(decimal));
            this.Columns.Add("JSDW", typeof(string));
            this.Columns.Add("JZMJ", typeof(int));
            this.Columns.Add("DWZJ", typeof(decimal));
            this.Columns.Add("ZZJB", typeof(decimal));
            this.Columns.Add("BZ", typeof(string));
            this.Columns.Add("EnID", typeof(string));
            this.Columns.Add("UnID", typeof(string));
        }


        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public void Add(object p_Info, int p_PID)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            string str = string.Empty;
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                str = col.ColumnName;
                PropertyInfo info = tp.GetProperty(str);
                if (info != null)
                {
                    try
                    {
                        row[col] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
                    }
                    catch(Exception e) {
                        throw e;
                    }
                }
            }
            row["PID"] = p_PID;
            row.EndEdit();
            this.Rows.Add(row);
            /*try
            {
                PropertyInfo pi = tp.GetProperty("ID");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch { }
            return ToolKit.ParseInt(row["ID"]);*/
        }

    }
}
