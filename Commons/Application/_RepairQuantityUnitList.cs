using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 补充工料机库集合类
    /// </summary>
    [Serializable]
    public class _RepairQuantityUnitList : _List
    {
        public _RepairQuantityUnitList() { }

        /// <summary>
        /// 初始化：补充工料机库集合类
        /// </summary>
        /// <param name="p_Parent">所属：子目</param>
        public _RepairQuantityUnitList(_GlobalData p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象：子目对象
        /// </summary>
        private _GlobalData m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
        public _GlobalData Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }

        /// <summary>
        /// 将(子目工料机对象)增加到(子目工料机集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Add(_RepairQuantityUnitInfo info)
        {
            base.Add(info);
        }

        /// <summary>
        /// 将(子目工料机对象)增加到(子目工料机集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Remove(bool p_ifxz)
        {
            _RepairQuantityUnitInfo[] u_list = this.Cast<_RepairQuantityUnitInfo>().Where(p => p.IFXZ == p_ifxz).ToArray();
            foreach (_RepairQuantityUnitInfo item in u_list)
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
            _RepairQuantityUnitInfo[] u_list = this.Cast<_RepairQuantityUnitInfo>().Where(p => p.IFXZ == p_ifxz).ToArray();
            foreach (_RepairQuantityUnitInfo item in u_list)
            {
                item.IFXZ = (!p_ifxz);
            }
        }
    }
}
