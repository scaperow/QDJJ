/*
    用于处理当前应用程序的公共缓存对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Cache
    {
        public DirectoryInfo AppFolder = null;

        /// <summary>
        /// 临时保存需要备份的文件(项目保存使用的数据)
        /// </summary>
        private ArrayList m_Cache_Bak_Object = null;

        /// <summary>
        /// 应用程序的报表原始数据
        /// </summary>
        private _List m_BaseReport = null;

        /// <summary>
        /// 应用程序的报表原始数据
        /// </summary>
        public _List BaseReport
        {
            get
            {
                return this.m_BaseReport;
            }
            set
            {
                this.m_BaseReport = value;
            }
        }

        /// <summary>
        /// 获取或设置临时保存需要备份的文件(项目保存使用的数据)
        /// 关闭项目或单项工程文件时候需要清空此对象
        /// </summary>
        public ArrayList Cache_Bak_Object
        {
            get
            {
                return this.m_Cache_Bak_Object;
            }
            set
            {
                this.m_Cache_Bak_Object = value;
            }
        }


        /// <summary>
        /// 保存操作历史数据
        /// </summary>
        private _HistoryCache m_HistoryCache = null;

        /// <summary>
        /// 获取或设置历史数据
        /// </summary>
        public _HistoryCache HistoryCache
        {
            get
            {
                return this.m_HistoryCache;
            }
            set
            {
                this.m_HistoryCache = value;
            }
        }

        /*public _Cache()
        {
            m_Cache_Bak_Object = new ArrayList();
            m_BaseReport = new ArrayList();
        }*/

        public _Cache(DirectoryInfo p_AppFolder)
        {
            m_Cache_Bak_Object = new ArrayList();
            this.Init(p_AppFolder);
        }

        /// <summary>
        /// 1.检测并且初始化目录文件
        /// 2.初始化各个缓存对象
        /// </summary>
        /// <param name="p_AppFolder">应用程序目录</param>
        public void Init(DirectoryInfo p_AppFolder)
        {
            this.AppFolder = p_AppFolder;
            //1.检测目录是否存在
            string dirName = p_AppFolder.FullName + "Cache";
            DirectoryInfo info = ToolKit.GetDirectoryInfo(dirName);
            this.m_HistoryCache = _HistoryCache.CreateInstance(info);
            this.m_BaseReport = ExtractReport();
        }


        /// <summary>
        /// 提取报表
        /// </summary>
        /// <returns></returns>
        private _List ExtractReport()
        {
            _Files files = new _Files();
            files.ExtName = _Files.报表格式扩展名;
            files.DirName = string.Format("{0}库文件\\系统库", AppFolder.FullName);
            files.FileName = "报表格式";
            try
            {
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {
                    //文件存在的时候读取
                    this.m_BaseReport = new _List();
                    object ywj = CFiles.Deserialize(files.FullName);
                    ArrayList dsd = ywj as ArrayList;
                    if (dsd != null)
                    {
                        this.m_BaseReport.AddRange(dsd.ToArray());
                        if (this.m_BaseReport.Count <= 0)
                        {
                            this.m_BaseReport = null;
                        }
                    }
                }
                return this.m_BaseReport;
            }
            catch (Exception ex)
            {
                this.m_BaseReport = null;
                return this.m_BaseReport;
            }
        }
    }
}
