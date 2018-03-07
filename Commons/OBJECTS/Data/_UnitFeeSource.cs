using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UnitFeeSource : _ObjectSource
    {
        protected _UnitFeeSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "工程取费";
        }

        public _UnitFeeSource()
            : base()
        {
            this.TableName = "工程取费";
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
            this.Columns.Add("GCLB", typeof(string));
            this.Columns.Add("DEHFW", typeof(string));
            this.Columns.Add("GLFFL", typeof(decimal));
            this.Columns.Add("LRFL", typeof(decimal));
            this.Columns.Add("FXTBFL", typeof(decimal));
            this.Columns.Add("FXBDFL", typeof(decimal));
            this.Columns.Add("GLFTBJSJC", typeof(string));
            this.Columns.Add("GLFBDJSJC", typeof(string));
            this.Columns.Add("LRFTBJSJC", typeof(string));
            this.Columns.Add("LRFBDJSJC", typeof(string));
            this.Columns.Add("FXFTBJSJC", typeof(string));
            this.Columns.Add("FXFBDJSJC", typeof(string));
            this.Columns.Add("IFSFHZ", typeof(bool));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }
    }
}
