/*
    新建业务引导类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Profession
    {
        /// <summary>
        /// 文件属性对象
        /// </summary>
        private _Files m_Files = null;

        /// <summary>
        /// 获取或设置文件属性对象
        /// </summary>
        public _Files Files
        {
            get
            {
                return this.m_Files;
            }
            set
            {
                this.m_Files = value;
            }
        }

        /// <summary>
        /// 命令名称
        /// </summary>
        private string m_CommandName = string.Empty;

        /// <summary>
        /// 获取或设置命令名称
        /// </summary>
        public string CommandName
        {
            get
            {
                return this.m_CommandName;
            }
            set
            {
                this.m_CommandName = value;
            }
        }
    }
}
