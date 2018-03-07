using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public interface ICopy
    {

        void Copys();
        void Paste();
        bool IsPaste();
        void Copys(object o);
    }
}
