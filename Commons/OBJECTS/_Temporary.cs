/*
 用于数据对象的临时操作数据
 此对象不参与任何序列化
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Temporary
    {

        public _Temporary()
        {
 
        }

        /// <summary>
        /// 当前操作的库对象
        /// </summary>
        [NonSerialized]
        private _Library m_Libraries = null;

        /// <summary>
        /// 获取临时对象-【工程属性】库对象
        /// </summary>
        public _Library Libraries
        {
            get
            {
                return this.m_Libraries;
            }
            set
            {
                this.m_Libraries = value;
            }
        }
    }
}
