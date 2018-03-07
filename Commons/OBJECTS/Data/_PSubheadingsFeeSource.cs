using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _PSubheadingsFeeSource : _ObjectSource
    {
        protected _PSubheadingsFeeSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "参数子目取费表";
        }

        public _PSubheadingsFeeSource()
        {
            this.TableName = "参数子目取费表";
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
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("JSSX", typeof(int));
            this.Columns.Add("YYH", typeof(string));
            this.Columns.Add("MC", typeof(string));
            this.Columns.Add("BDS", typeof(string));
            this.Columns.Add("SCJJC", typeof(string));
            this.Columns.Add("TBJSJC", typeof(string));
            this.Columns.Add("BDJSJC", typeof(string));
            this.Columns.Add("FL", typeof(decimal));
            this.Columns.Add("TBJE", typeof(decimal));
            this.Columns.Add("BDJE", typeof(decimal));
            this.Columns.Add("FYLB", typeof(string));
            this.Columns.Add("QFLB", typeof(string));
            this.Columns.Add("BZ", typeof(string));
            this.Columns.Add("STATUS", typeof(bool));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
           // this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }
    }
}
