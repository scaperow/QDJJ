using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UserPriceLibrarySource : DataTable
    {
        protected _UserPriceLibrarySource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public _UserPriceLibrarySource()
        {
            this.TableName = "YHJGK";
            Builder();
        }

        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("XZ", typeof(bool)).DefaultValue = false;
            this.Columns.Add("YSBH", typeof(string));
            this.Columns.Add("YSMC", typeof(string));
            this.Columns.Add("YSDW", typeof(string));
            this.Columns.Add("BH", typeof(string));
            this.Columns.Add("MC", typeof(string));
            this.Columns.Add("DW", typeof(string));
            this.Columns.Add("LB", typeof(string));
            this.Columns.Add("DEDJ", typeof(decimal));
            this.Columns.Add("SCDJ", typeof(decimal));
            this.Columns.Add("SSDWGC", typeof(string));
            this.Columns.Add("CTIME", typeof(DateTime));
            this.Columns.Add("CurrNo", typeof(string));
            this.Columns.Add("Status", typeof(string));
            
            //this.Columns[0].AutoIncrement = true;
            //this.Columns[0].AutoIncrementSeed = 0;
            //this.Columns[0].AutoIncrementStep = 1;
            //this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }
    }
}
