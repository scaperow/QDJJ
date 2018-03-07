/*
    此类型为非容器类型基础类别
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public abstract class _BusNotContainer:_Business
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _BusNotContainer()
        {
            ///当前业务类别
            this.BusinessType = EBusinessType.NotContainer;
        }

        /// <summary>
        /// 创建一个已经存在的业务对象
        /// </summary>
        /// <param name="p_info">业务数据对象</param>
        public virtual void Create(_COBJECTS  p_info) { }

    }
}
