/*
 招标信息(项目使用仅一行记录)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _BiddingInfoSource : _ObjectSource
    {

        public _BiddingInfoSource()
            : base()
        {
            this.TableName = "招标信息表";
            Builder();
        }


        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("JSDW", typeof(string));
            this.Columns.Add("JSDWDBR", typeof(string));
            this.Columns.Add("ZBDLR", typeof(string));
            this.Columns.Add("ZBDLDBR", typeof(string));
            this.Columns.Add("GCLX", typeof(string));
            this.Columns.Add("ZBFW", typeof(string));
            this.Columns.Add("ZBMJ", typeof(string));
            this.Columns.Add("ZBGQ", typeof(string));
            this.Columns.Add("BZDW", typeof(string));
            this.Columns.Add("BZDWDBR", typeof(string));
            this.Columns.Add("SJDW", typeof(string));
            this.Columns.Add("DBLX", typeof(string));
            this.Columns.Add("PlaitNo", typeof(string));
            this.Columns.Add("ReviewName", typeof(string));
            this.Columns.Add("PlaitName", typeof(string));
            this.Columns.Add("PlaitDate", typeof(DateTime));
            this.Columns.Add("ReviewDate", typeof(DateTime));
        }
    }
}
