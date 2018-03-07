using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _IncreaseCostsSource:_ObjectSource
    {
        protected _IncreaseCostsSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            
        }

        public _IncreaseCostsSource()
            : base()
        {
            this.TableName = "安装增加费";
            Builder();
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("QDID", typeof(int));
            this.Columns.Add("ZMID", typeof(int));
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("DH", typeof(string));
            this.Columns.Add("JSJC", typeof(string));
            this.Columns.Add("FJJS", typeof(string));
            this.Columns.Add("XS", typeof(decimal));
            this.Columns.Add("RGXS", typeof(decimal));
            this.Columns.Add("CLXS", typeof(decimal));
            this.Columns.Add("JXXS", typeof(decimal));
            this.Columns.Add("RGF", typeof(decimal));
            this.Columns.Add("CLF", typeof(decimal));
            this.Columns.Add("JXF", typeof(decimal));
            this.Columns.Add("HJ", typeof(decimal));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };

        }
    }
}
