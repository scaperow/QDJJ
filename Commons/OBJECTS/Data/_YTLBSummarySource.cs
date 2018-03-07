using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _YTLBSummarySource:_ObjectSource
    {
        protected _YTLBSummarySource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ;
        }

        public _YTLBSummarySource()
        {
            this.TableName = "用途类别表";
            Builder();
        }

            /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("PID", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns.Add("QDID", typeof(int));
            this.Columns.Add("ZMID", typeof(int));
            this.Columns.Add("YSBH", typeof(string));
            this.Columns.Add("YSMC", typeof(string));
            this.Columns.Add("YSDW", typeof(string));
            this.Columns.Add("YSXHL", typeof(decimal));
            this.Columns.Add("BH", typeof(string));
            this.Columns.Add("MC", typeof(string));
            this.Columns.Add("DW", typeof(string));
            this.Columns.Add("XHL", typeof(decimal));
            this.Columns.Add("LB", typeof(string));
            this.Columns.Add("DEDJ", typeof(decimal));
            this.Columns.Add("DEHJ", typeof(decimal), "DEDJ*XHL");
            this.Columns.Add("SCDJ", typeof(decimal));
            this.Columns.Add("SCHJ", typeof(decimal), "SCDJ*XHL");
            this.Columns.Add("DJC", typeof(decimal), "SCDJ-DEDJ");
            this.Columns.Add("JSDJ", typeof(decimal));
            this.Columns.Add("JSDJC", typeof(decimal), "JSDJ-SCDJ");
            this.Columns.Add("GCL", typeof(decimal));
            this.Columns.Add("SL", typeof(decimal), "XHL*GCL");
            this.Columns.Add("IFZYCL", typeof(bool));
            this.Columns.Add("ZCLB", typeof(string));
            this.Columns.Add("GGXH", typeof(string));
            this.Columns.Add("SDCLB", typeof(string));
            this.Columns.Add("SDCXS", typeof(decimal));
            this.Columns.Add("YTLB", typeof(string));
            this.Columns.Add("IFXZ", typeof(bool));
            this.Columns.Add("IFSC", typeof(bool));
            this.Columns.Add("IFFX", typeof(bool));
            this.Columns.Add("IFSDSCDJ", typeof(bool));
            this.Columns.Add("IFSDSL", typeof(bool));
            this.Columns.Add("IFKFJ", typeof(bool));
            this.Columns.Add("SSDWGC", typeof(string));
            this.Columns.Add("GLJBZ", typeof(string));
            this.Columns.Add("CTIME", typeof(DateTime));
            this.Columns.Add("SLH", typeof(decimal));
            this.Columns.Add("SLDEHJ", typeof(decimal));
            this.Columns.Add("SLSCHJ", typeof(decimal));
            this.Columns.Add("JSHJC", typeof(decimal), "JSDJC*SL");
            this.Columns.Add("HJC", typeof(decimal), "DJC*SL");
            this.Columns.Add("SDCHJ", typeof(decimal), "SDCXS*SCDJ*SL");
            this.Columns.Add("CJ", typeof(string));
            this.Columns.Add("PP", typeof(string));
            this.Columns.Add("ZLDJ", typeof(string));
            this.Columns.Add("GYS", typeof(string));
            this.Columns.Add("CD", typeof(string));
            this.Columns.Add("CJBZ", typeof(string));
            this.Columns.Add("XGHSCDJ", typeof(decimal));
            this.Columns.Add("TZXS", typeof(decimal));
            this.Columns.Add("BDBH", typeof(string));
            this.Columns.Add("SSKLB", typeof(string));
            this.Columns.Add("DZBS", typeof(bool)).DefaultValue = false;
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        
        }

        public int Add(object p_Info, int p_pos)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (info.Name != "ID")
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
            }
            row.EndEdit();
            this.Rows.InsertAt(row, p_pos);
            try
            {
                PropertyInfo pi = tp.GetProperty("ID");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch(Exception e) {
                throw e;
            }
            return ToolKit.ParseInt(row["ID"]);
        }
    }
}
