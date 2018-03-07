using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _StandardConversionSource:_ObjectSource
    {

        protected _StandardConversionSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "标准换算表";
        }

        public _StandardConversionSource()
        {
            this.TableName = "标准换算表";
            Builder();
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns.Add("QDID", typeof(int));
            this.Columns.Add("ZMID", typeof(int));
            this.Columns.Add("IFXZ", typeof(bool));
            this.Columns.Add("DEH", typeof(string));
            this.Columns.Add("HSLB", typeof(string));
            this.Columns.Add("HSXX", typeof(string));
            this.Columns.Add("DJ_DW", typeof(string));
            this.Columns.Add("JBL_RGXS", typeof(string));
            this.Columns.Add("DEH_CLXS", typeof(string));
            this.Columns.Add("TZL_JXXS", typeof(string));
            this.Columns.Add("ZC", typeof(string));
            this.Columns.Add("SB", typeof(string));
            this.Columns.Add("XHLB", typeof(string));
            this.Columns.Add("FZ", typeof(string));
            this.Columns.Add("THZHC", typeof(string));
            this.Columns.Add("THWZFC", typeof(string));
            this.Columns.Add("HSXI", typeof(string));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 1;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };

        }
    }
}
