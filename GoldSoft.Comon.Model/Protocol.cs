using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldSoft.Common.Model
{
    public class Protocol
    {
        public bool Error;
        public string Message;
    }

    public class SoftdogProtocol : Protocol
    {
        public string SerialNumber  { get; set; }
        public bool Success { set; get; }
    }
}
