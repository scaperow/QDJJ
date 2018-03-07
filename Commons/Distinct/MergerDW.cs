using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class MergerDW : IEqualityComparer<_Entity_QuantityUnit>
    {
        public bool Equals(_Entity_QuantityUnit x, _Entity_QuantityUnit y)
        {
            if (x == null)
                return y == null;
            return x.DW == y.DW;
        }

        public int GetHashCode(_Entity_QuantityUnit obj)
        {
            if (obj == null)
                return 0;
            return obj.DW.GetHashCode();
        }
    }
}