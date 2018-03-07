using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public  class _CopyList:_List//,IComparable<CopType>
    {
        private CopType M_Ctype;
        /// <summary>
        /// 当前集合放的是清单还是子母
        /// </summary>
        public CopType Ctype
        {
            get { return this.M_Ctype;}
            set{this.M_Ctype=value;}
        }

        //#region IComparable<CopType> 成员

        //public int CompareTo(CopType other)
        //{
        //    if (this.Ctype.ToString().Equals(other.ToString()).Equals("清单") || this.Ctype.ToString().Equals(other.ToString()).Equals("子目"))
        //    {
        //        return 0;
        //    }
        //    else if (this.Ctype.ToString().Equals("清单") && other.ToString().Equals("子目"))
        //    {
        //        return 1;
        //    }
        //    return -1;
        //    //else if (this.Ctype.ToString().Equals("子目") && other.ToString().Equals("清单"))
        //    //{
        //    //    return -1;
        //    //}

        //}

        //#endregion
    }
    public enum CopType
    { 
        清单,子目,
    }
}
