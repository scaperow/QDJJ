/*
 投标信息(项目使用仅一行记录)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _TenderInfoSource : _ObjectSource
    {

        public _TenderInfoSource()
            : base()
        {
            this.TableName = "投标信息表";
            this.Builder();
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("TBDW", typeof(string));
            this.Columns.Add("TBDWDBR", typeof(string));
            this.Columns.Add("TBGQ", typeof(string));
            this.Columns.Add("ZLCN", typeof(string));
            this.Columns.Add("BBZJ", typeof(string));
            this.Columns.Add("DBLX", typeof(string));
            this.Columns.Add("JZS", typeof(string));
            this.Columns.Add("JZSH", typeof(string));
            this.Columns.Add("PlaitNo", typeof(string));
            this.Columns.Add("ReviewName", typeof(string));
            this.Columns.Add("PlaitName", typeof(string));
            this.Columns.Add("PlaitDate", typeof(DateTime));
            this.Columns.Add("ReviewDate", typeof(DateTime));
        }
    }
}
