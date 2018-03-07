using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class MergerSL : IEqualityComparer<_Entity_QuantityUnit>
    {
        public bool Equals(_Entity_QuantityUnit x, _Entity_QuantityUnit y)
        {
            if (x == null)
            {
                return y == null;
            }
            return x.BH == y.BH;
        }

        public int GetHashCode(_Entity_QuantityUnit obj)
        {
            if (obj == null)
                return 0;
            return obj.BH.GetHashCode();
        }
    }

    public class QDDistinct : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y)
        {
            if (x == null)
            {
                return y == null;
            }
            if (x["XMBM"].ToString().Length < 3) return false;
            return x["OLDXMBM"].Equals(y["OLDXMBM"]);
        }

        public int GetHashCode(DataRow x)
        {
            if (x["XMBM"].ToString().Length < 4)
                return 0;
            return x["OLDXMBM"].GetHashCode();
        }
    }
}
