/*
 用于提供界面活动窗体的类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.UI
{
    public class ActiveWindow
    {
        /// <summary>
        /// 获取当前应用程序的主工作窗体
        /// </summary>
        private static ApplicationForm _AppForm = null;

        /// <summary>
        /// 获取当前应用程序的主工作窗体(全局可用)
        /// </summary>
        public static ApplicationForm AppForm
        {
            get
            {
                return ActiveWindow._AppForm;
            }
            set
            {
                ActiveWindow._AppForm = value;
            }
        }

        /// <summary>
        /// 获取或设置当前活动的业务容器
        /// </summary>
        private static Container _ActiveContainer = null;

        /// <summary>
        /// 获取或设置当前活动的业务容器
        /// </summary>
        public static Container ActiveContainer
        {
            get
            {
                return ActiveWindow._ActiveContainer;
            }
            set
            {
                ActiveWindow._ActiveContainer = value;
            }
        }

        /// <summary>
        /// 活动的单位工程窗体(项目/单位工程可用)
        /// </summary>
        private static ProjectForm _ActiveProjectForm = null;

        /// <summary>
        /// 活动的单位工程窗体(项目/单位工程可用)
        /// </summary>
        public static ProjectForm ActiveProjectForm
        {
            get
            {
                return _ActiveProjectForm;
            }
            set
            {
                _ActiveProjectForm = value;
                
            }
        }

        /// <summary>
        /// 当前正在操作的ABaseForm
        /// </summary>
        private static ABaseForm _CurrentABaseForm = null;

        /// <summary>
        /// 当前操作的ABaseForm
        /// </summary>
        public static ABaseForm CurrentABaseForm
        {
            get
            {
                return _CurrentABaseForm;
            }
            set
            {
                _CurrentABaseForm = value;
            }
        }
    }
}
