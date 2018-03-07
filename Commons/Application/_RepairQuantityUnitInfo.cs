using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 补充工料机库类
    /// </summary>
    [Serializable]
    public class _RepairQuantityUnitInfo : _Entity_QuantityUnit
    {
        public _RepairQuantityUnitInfo() { }

        /// <summary>
        /// 初始化：原始子目取费对象
        /// </summary>
        public _RepairQuantityUnitInfo(_GlobalData p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _GlobalData m_Parent = null;

        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _GlobalData Parent
        {
            get { return this.m_Parent; }
            set { this.Parent = value; }
        }
    }
}
