using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public interface IDataSerializable
    {
        void OutSerializable();

        void InSerializable(object e);
    }
}
