using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 原始子目取费集合对象
    /// </summary>
    [Serializable]
    public class _YSSubheadingsFeeList : _List
    {

         /// <summary>
        /// 初始化：原始子目取费集合对象
        /// </summary>
        public _YSSubheadingsFeeList(_ParameterSettings p_Parent)
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
        /// 将(原始子目取费对象)增加到(原始子目取费集合对象)的结尾处
        /// </summary>
        /// <param name="info">原始子目取费对象</param>
        public void Add(_YSSubheadingsFeeInfo info)
        {
            base.Add(info);
        }
    }
}
