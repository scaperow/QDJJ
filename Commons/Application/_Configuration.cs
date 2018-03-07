/*
 * 配置信息(系统的配置信息存储类)
 * 设置默认配置信息，每次用户改变此对象时候重新替换此config文件
 * 单位工程的配置信息
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 应用软件的配置对象
    /// </summary>
    [Serializable]
    public class _Configuration
    {
        /// <summary>
        /// 默认的配置文件名称
        /// </summary>
        public const string ConfigName = "config.cfg";
        /// <summary>
        /// 文件的保存路径
        /// </summary>
        public string ConfigPath = string.Empty;

        public  delegate void ConfigSaveHandler();
        [field: NonSerializedAttribute()]
        public event ConfigSaveHandler ConfigSave;
        /// <summary>
        /// 目录名称
        /// </summary>
        public DirectoryInfo AppFolder = null;

        /// <summary>
        /// 获取或设置
        /// </summary>
        public static _Configuration CreateInstance(string p_FileName,DirectoryInfo p_AppFolder)
        {
            _Configuration cfg = null;
            FileInfo info = new FileInfo(p_FileName);
            if (info.Exists)
            {
                //存对象文件
                try
                {
                    cfg = CFiles.Deserialize(p_FileName) as _Configuration;
                }
                catch(Exception ex)
                {
                    cfg = new _Configuration();
                }
                
            }
            else
            {
                cfg = new _Configuration();
                cfg.AppFolder = p_AppFolder;
            }
            cfg.ConfigPath = p_FileName;
            return cfg;
        }
        private void OnConfigSave()
        {
            if (this.ConfigSave != null) this.ConfigSave();
        }

        /// <summary>
        /// 保存当前配置信息
        /// </summary>
        public void Save(string p_FileName)
        {
            CFiles.BinarySerialize(this, p_FileName);
            this.OnConfigSave();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _Configuration()
        {
            //全局配置信息(使用全局配置 )
            m_Configs = new Hashtable();
            //初始化配置信息
            this.m_Configs.Add("工程量输入方式", 0);//0 自然单位 1按定额步距
            this.m_Configs.Add("清单工程量设置", true);//0 否 1是
            this.m_Configs.Add("标准换算", true);//
            this.m_Configs.Add("配合比换算", true);
            this.m_Configs.Add("石灰换算", true);
            this.m_Configs.Add("砂浆换算", true);
            this.m_Configs.Add("自动保存时间",20);
            this.m_Configs.Add("名称显示方式", 0);
        }

        #region -------------------配置信息实体对象----------------------

        /// <summary>
        /// 详细配置列表
        /// </summary>
        private Hashtable m_Configs = null;

        /// <summary>
        /// 详细配置列表
        /// </summary>
        public Hashtable Configs
        {
            get
            {
                return this.m_Configs;
            }
            set
            {
                this.m_Configs = value;
            }
        }

        /// <summary>
        /// 获取指定配置信息
        /// </summary>
        /// <param name="p_Name"></param>
        /// <returns></returns>
        public object Get(string p_Name)
        {
            return this.m_Configs[p_Name];
        }
        
        /// <summary>
        /// 每次保存时候单位工程临时备份文件目录
        /// </summary>
        public string Path_Temporary_UnitProject = "工程文件\\备份文件\\";
        /// <summary>
        /// 是否开启临时备份功能
        /// </summary>
        public bool Bool_Temporary_UnitProject = true;

        #endregion

    }
}
