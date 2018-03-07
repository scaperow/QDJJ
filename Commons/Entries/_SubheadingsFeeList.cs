using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 子目取费集合对象
    /// </summary>
    [Serializable]
    public class _SubheadingsFeeList : _List
    {
        /// <summary>
        /// 初始化：子目取费集合对象
        /// </summary>
        public _SubheadingsFeeList(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return this.m_Parent; }
            set { this.Parent = value; }
        }

        /// <summary>
        /// 将(子目取费对象)增加到(子目取费集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目取费对象</param>
        public void Add(_SubheadingsFeeInfo info)
        {
            base.Add(info);
        }
    }
}
