using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
   public class _IncreaseCostsList:_List
    {
        /// <summary>
        /// 初始化：子目取费集合对象
        /// </summary>
        /// <param name="p_Parent">所属：子目</param>
       public _IncreaseCostsList(_ObjectInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象：子目对象
        /// </summary>
       private _ObjectInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
       public _ObjectInfo Parent
        {
            get { return this.m_Parent; }
        }

        /// <summary>
        /// 将(子目取费)增加到(子目取费集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Add(_IncreaseCostsInfo info)
        {
            base.Add(info);
        }
    }
}
