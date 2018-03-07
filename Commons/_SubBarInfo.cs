/*
    应用程序主界面的信息类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _SubBarInfo
    {
        /// <summary>
        /// 业务名称
        /// </summary>
        private string m_BusName = string.Empty;
        /// <summary>
        /// 业务类型
        /// </summary>
        private string m_BusType = string.Empty;
        /// <summary>
        /// 模块名称
        /// </summary>
        private string m_ModelName = string.Empty;
        /// <summary>
        /// 清单库名称
        /// </summary>
        private string m_ListLibName = "无";
        /// <summary>
        /// 定额库
        /// </summary>
        private string m_FixLibName = "无";

        /// <summary>
        /// 定额库名称
        /// </summary>
        public string FixLibName
        {
            get
            {
                return this.m_FixLibName;
            }
            set
            {
                this.m_FixLibName = value;
            }
        }
        /// <summary>
        /// 清单库名称
        /// </summary>
        public string ListLibName
        {
            get
            {
                return this.m_ListLibName;
            }
            set
            {
                this.m_ListLibName = value;
            }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }
            set
            {
                this.m_ModelName = value;
            }
        }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusType
        {
            get
            {
                return this.m_BusType;
            }
            set
            {
                this.m_BusType = value;
            }
        }

        /// <summary>
        /// 获取或设置业务名称
        /// </summary>
        public string BusName
        {
            get
            {
                return this.m_BusName;
            }
            set
            {
                this.m_BusName = value;
            }
        }

        
    }
}
