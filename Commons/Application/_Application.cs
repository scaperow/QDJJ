/*
 * 当前应用程序处理实体类(数据类) 仅包含数据处理对象
 * 1.当前应用程序的基本处理信息(全局)
 * 2.当前业务的处理数据(唯一)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 当前应用程序
    /// </summary>
    public class _Application
    {
        /// <summary>
        /// 当前应用程序的全局配置信息(基本配置信息)
        /// </summary>
        public  _Global Global = null;

        /// <summary>
        /// 当前应用程序的全局数据对象
        /// </summary>
        public _GlobalData GlobalData = null;

        /// <summary>
        /// 当前应用程序的全局缓存对象
        /// </summary>
        public _Cache Cache = null;
      
        /// 构造一个全新的应用程序
        /// </summary>
        public _Application()
        {
            //构造新的全局配置
            //this.Cache = new _Cache();
            this.Global = new _Global();
            this.GlobalData = new _GlobalData(this);
           
        }
    }
}
