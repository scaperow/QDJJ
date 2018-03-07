using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 用户价格库集合对象
    /// </summary>
    [Serializable]
    public class _UserPriceLibraryList : _List
    {
        /// <summary>
        /// 空构造
        /// </summary>
        public _UserPriceLibraryList() { }

        /// <summary>
        /// 将(子目工料机对象)增加到(子目工料机集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Remove(string p_BH,string p_SSDWGC)
        {
            //lock (this)
            {
                _UserPriceLibraryInfo[] u_list = this.Cast<_UserPriceLibraryInfo>().Where(p => p.SSDWGC == p_SSDWGC && p.BH == p_BH).ToArray();
                lock (u_list)
                {
                    foreach (_UserPriceLibraryInfo item in u_list)
                    {
                        base.Remove(item);
                    }
                }
            }
        }

        /// <summary>
        /// 将(子目工料机对象)增加到(子目工料机集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Remove(bool p_ifxz)
        {
            _UserPriceLibraryInfo[] u_list = this.Cast<_UserPriceLibraryInfo>().Where(p => p.IFXZ == p_ifxz).ToArray();
            foreach (_UserPriceLibraryInfo item in u_list)
            {
                base.Remove(item);
            }
        }

        /// <summary>
        /// 将(子目工料机对象)增加到(子目工料机集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Refresh(bool p_ifxz)
        {
            _UserPriceLibraryInfo[] u_list = this.Cast<_UserPriceLibraryInfo>().Where(p => p.IFXZ == p_ifxz).ToArray();
            foreach (_UserPriceLibraryInfo item in u_list)
            {
                item.IFXZ = (!p_ifxz);
            }
        }

        public void Update(_ObjectQuantityUnitInfo p_info)
        {
            IEnumerable<_UserPriceLibraryInfo> m_info = this.Cast<_UserPriceLibraryInfo>().Where(p => p.SSDWGC == p_info.SSDWGC && p.BH == p_info.BH);
            foreach (_UserPriceLibraryInfo item in m_info)
            {
                item.MC = p_info.MC;
                item.DW = p_info.DW;
                item.SCDJ = p_info.SCDJ;
            }
        }
    }
}
