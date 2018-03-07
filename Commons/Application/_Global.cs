/*
 此类别包含全局应用程序配置信息
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 全局应用程序配置
    /// </summary>
    public  class _Global
    {

        /// <summary>
        /// 当前应用程序的工作目录
        /// </summary>
        private DirectoryInfo m_AppFolder = null;

        /// <summary>
        /// 当前应用程序的系统配置对象(从文件里获取)
        /// </summary>
        private _Configuration m_Configuration = null;

        /// <summary>
        /// 获取或设置当前系统的配置信息对象
        /// </summary>
        public _Configuration Configuration
        {
            get
            {
                return this.m_Configuration;
            }
            set
            {
                this.m_Configuration = value;
            }
        }

        /// <summary>
        /// 获取或设置当前应用程序的工作目录
        /// </summary>
        public DirectoryInfo AppFolder
        {
            get
            {
                return this.m_AppFolder;
            }
            set
            {
                this.m_AppFolder = value;
                this.DataTamp.AppFolder = value.FullName;
            }
        }


        /// <summary>
        /// 获取或设置当前对象的工作目录
        /// </summary>
        public DirectoryInfo WorkFolder = null;

        /// <summary>
        /// 获取或设置数据模板
        /// </summary>
        public _DataTemp DataTamp = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public _Global()
        {
            //初始化新的模板数据对象
            this.DataTamp = new _DataTemp();
            
        }

        /// <summary>
        /// 若对象需要初始化操作此处实现
        /// </summary>
        public void Init()
        {
            //初始化配置信息
            initConfiguration();
        }

        /// <summary>
        /// 初始化全局配置对象
        /// </summary>
        private void initConfiguration()
        {
            //配置文件是否存在
            //1.不存在，构造一个新的配置文件
            string fn = string.Format("{0}config\\{1}", this.m_AppFolder.FullName, _Configuration.ConfigName);
            this.m_Configuration = _Configuration.CreateInstance(fn, m_AppFolder);    
        }

        public void SaveConfiguration()
        {
            string fn = string.Format("{0}config\\{1}", this.m_AppFolder.FullName, _Configuration.ConfigName);
            this.m_Configuration.Save(fn);
        }
    }
}
