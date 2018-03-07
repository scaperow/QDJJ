using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 工程取费集合对象
    /// </summary>
    [Serializable]
    public class _UnitFeeList:_List
    {
                 /// <summary>
        /// 初始化：原始工程取费集合对象
        /// </summary>
        public _UnitFeeList(_ParameterSettings p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _ParameterSettings m_Parent = null;

        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _ParameterSettings Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }

        /// <summary>
        /// 将(原始工程取费对象)增加到(原始工程取费集合对象)的结尾处
        /// </summary>
        /// <param name="info">原始工程取费集合对象</param>
        public void Add(_UnitFeeInfo info)
        {
            base.Add(info);
        }
    }
}
