using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 原始子目取费对象
    /// </summary>
    [Serializable]
    public class _YSSubheadingsFeeInfo : _ObjectSubheadingsFee
    {
        /// <summary>
        /// 初始化：原始子目取费对象
        /// </summary>
        public _YSSubheadingsFeeInfo(_ParameterSettings p_Parent)
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
            set { this.Parent = value; }
        }
    }
}
