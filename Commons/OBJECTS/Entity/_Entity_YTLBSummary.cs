using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_YTLBSummary:_Entity_QuantityUnit
    {
        
        /// <summary>
        /// 自身ID
        /// </summary>		
        private string _BDBH;
        /// <summary>
        /// 自身ID
        /// </summary>
        public virtual string BDBH
        {
            get { return _BDBH; }
            set { _BDBH = value; }
        }
    }
}
