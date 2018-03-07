using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class EntrtyComparer : IEqualityComparer<DataRow>
    {
        #region IEqualityComparer<ISubSegment> 成员

        public bool Equals(DataRow x, DataRow y)
        {
           
            if (x == null)
                return y == null;
            return x["OLDXMBM"].Equals(y["OLDXMBM"]);
        }

        public int GetHashCode(DataRow obj)
        {
            if (obj == null)
                return 0;
            return obj["OLDXMBM"].GetHashCode();

        }

        #endregion
    }
}
