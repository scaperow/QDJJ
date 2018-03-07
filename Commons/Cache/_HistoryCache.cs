/*
    历史缓存仅记录前10条操作过的历史记录
    此对象若为空
 *  系统历史文件 history.cfg 文件保存 fileInfo 对象
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _HistoryCache
    {

        /// <summary>
        /// 当前缓存文件名称
        /// </summary>
        private const string FileName = "history.cfg";

        private Hashtable m_HistoryList = null;

        private string SaveName = string.Empty;


        /// <summary>
        /// 获取或设置历史列表
        /// </summary>
        public Hashtable HistoryList
        {
            get
            {
                return this.m_HistoryList;
            }
            set
            {
                this.m_HistoryList = value;
            }
        }

        /// <summary>
        /// 返回排序后的集合
        /// </summary>
        public FileInfo[] List
        {
            get
            {
                IEnumerable<FileInfo> infos = from i in this.m_HistoryList.Values.Cast<FileInfo>()
                                              orderby i.LastAccessTime descending
                                              select i;
                return infos.ToArray();
            }
        }

        public _HistoryCache()
        {
            this.m_HistoryList = new Hashtable();
        }

        /// <summary>
        /// 添加新的对象到集合缓存中(每次保存和打开文件时候调用)
        /// </summary>
        public void Add(FileInfo info)
        {
            setDelete();

            //若文件对象已经存在则删除同名的文件
            if (this.m_HistoryList.Contains(info.Name))
            {
                this.m_HistoryList.Remove(info.Name);
            }
            
            //添加到缓存中
            this.m_HistoryList.Add(info.Name, info);
            //每次添加后保存
            this.Save();
        }

        /// <summary>
        /// 保留指定条目数据
        /// </summary>
        private void setDelete()
        {
            int MaxCount = 9;

            if (this.m_HistoryList.Count > MaxCount)
            {

                IEnumerable<FileInfo> infos = from i in this.m_HistoryList.Values.Cast<FileInfo>()
                                              orderby i.LastAccessTime ascending
                                              select i;
                //删除超出范围的对象
                FileInfo[] infs = infos.ToArray();
                //删除执行条数
                int count = this.m_HistoryList.Count - MaxCount;
                for (int i = 0; i < count; i++)
                {
                    this.m_HistoryList.Remove(infs[i].Name);
                }
            }
        }


        /// <summary>
        /// 若读取配置文件失败返回新的配置文件
        /// </summary>
        /// <returns></returns>
        public static _HistoryCache CreateInstance(DirectoryInfo p_CacheFolder)
        {
            //若读取文件成功则直接返回否则返回空对象
            try
            {

                string filename = p_CacheFolder.FullName +"\\"+ _HistoryCache.FileName;
                _HistoryCache info = CFiles.Deserialize(filename) as _HistoryCache;
                if (info == null)
                {
                    info = new _HistoryCache();                    
                }
                info.SaveName = filename;
                return info;
            }
            catch 
            {
                _HistoryCache info = new _HistoryCache();
                info.SaveName = p_CacheFolder.FullName +"\\"+ _HistoryCache.FileName;
                return info;
            }

        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public void Save()
        {
            //保存当前缓存对象
            CFiles.BinarySerialize(this, this.SaveName);
        }
    }
}
