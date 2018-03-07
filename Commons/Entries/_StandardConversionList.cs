using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 标准换算集合对象
    /// </summary>
    [Serializable]
    public class _StandardConversionList : _List
    {
        /// <summary>
        /// 初始化：标准换算集合对象
        /// </summary>
        /// <param name="p_Parent">所属：子目</param>
        public _StandardConversionList(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象：子目对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return this.m_Parent; }
        }

        private _StandardConversionInfo m_StandardConversionInfo = null;

        public _StandardConversionInfo StandardConversionInfo
        {
            get { return m_StandardConversionInfo; }
            set { m_StandardConversionInfo = value; }
        }


        /// <summary>
        /// 将(标准换算对象)增加到(标准换算集合对象)的结尾处
        /// </summary>
        /// <param name="info">标准换算对象</param>
        public void Add(_StandardConversionInfo info)
        {
            base.Add(info);
        }
    }
}
