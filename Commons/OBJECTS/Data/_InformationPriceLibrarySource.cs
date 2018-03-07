using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS.OBJECTS
{
    [Serializable]
    public class _InformationPriceLibrarySource : DataTable
    {
        /// <summary>
		///反序列化构造函数
		/// </summary>
        public _InformationPriceLibrarySource(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}

        public _InformationPriceLibrarySource()
            : base()
        {
            this.TableName = "2013-01-01 00:00:00";
            Builder();
        }

        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("BH", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("MC", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("DW", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("LB", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("DJ", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("BZ", typeof(string)).DefaultValue = 0m;
            this.Columns.Add("Status", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("UpdateTime", typeof(DateTime));
        }
    }
}
