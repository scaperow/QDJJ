/*
 为当前编辑的对象做比较存储
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _CModfitingObject
    {
        /// <summary>
        /// 当前的对象
        /// </summary>
        public object Current;

        public string FiledName = null;

        public void Init()
        {
            this.Current = null;
            this.FiledName = string.Empty;
        }
    }
}
