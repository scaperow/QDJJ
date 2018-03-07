/*
 * 用于处理APP函数会发的通用静态数据接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Common
    {
        /// <summary>
        /// 加密锁好
        /// </summary>
        public static string LockNum = string.Empty;

        private static _Application m_Application = null;

        private static _UnitProject m_Activitie = null;


        /// <summary>
        /// 当前业务工作界面这个在处理的
        /// </summary>
        private static _COBJECTS m_Current = null;


        /// <summary>
        /// 当前业务工作界面这个在处理的
        /// </summary>
        public static _COBJECTS Current
        {
            get
            {
                return _Common.m_Current;
            }
            set
            {
                _Common.m_Current = value;
            }
        }

        /// <summary>
        /// 获取或设置当前活动的单位工程
        /// </summary>
        public static _UnitProject Activitie
        {
            get 
            {
                return _Common.m_Activitie;
            }
            set
            {
                _Common.m_Activitie = value;
            }
        }
      

        /// <summary>
        /// 获取或设置当APP的应用程序对象
        /// </summary>
        public static _Application Application
        {
            get
            {
                return _Common.m_Application;
            }
            set
            {
                _Common.m_Application = value;
            }

        }
    }
}
