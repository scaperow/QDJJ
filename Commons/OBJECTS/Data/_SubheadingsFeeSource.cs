/*
    子目取费表
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _SubheadingsFeeSource : _PSubheadingsFeeSource
    {

        protected _SubheadingsFeeSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "子目取费表";
        }

        public _SubheadingsFeeSource()
        {
            this.TableName = "子目取费表";
            //Builder();
        }
    }
}
