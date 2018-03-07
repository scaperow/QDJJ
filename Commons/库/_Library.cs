/*
    应用程序使用的库集合
    包含清单库 定额库 图库集
 * 一个标准清单库 = 清单规则+库名称
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
    [Serializable]
    public class _Library
    {
        /// <summary>
        /// 哭发生变化时候激发
        /// </summary>
        [field: NonSerialized]
        public event LibraryChangeHandler LibraryChange;

        /// <summary>
        /// 当全局样式发生变化时调用
        /// </summary>
        public void OnLibraryChange(GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData p_Library)
        {
            if (this.LibraryChange != null)
            {
                this.LibraryChange(p_Library);
            }
        }


        /// <summary>
        /// 获取指定全名称的库数据对象
        /// </summary>
        /// <param name="p_FullName">库全名称</param>
        /// <returns>库数据对象</returns>
        public static GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData GetLibrary(string p_FullName)
        {
            

            GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData lib = new GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData();
            if (string.IsNullOrEmpty(p_FullName)) return lib;
            string[] strs = p_FullName.Split('.');

            lib.Rule = strs[0].Substring(0, 4);
            //string s_type = p_FullName.PadRight();;
            lib.LibName = strs[0].Substring(4, strs[0].Length - 4);
            switch (strs[1])
            {
                case "qdsx":
                    lib.LibType = "清单库";
                    break;
                case "dcsx":
                    lib.LibType = "定额库";
                    break;
            }
            lib.Init(_Common.Application.Global.AppFolder);
            return lib;

        }



        /// <summary>
        /// 库对象构造函数
        /// </summary>
        public _Library()
        {
            this.m_ListGallery  = new _LibraryData(库类型.清单库);
            this.m_FixedLibrary = new _LibraryData(库类型.定额库);
            this.m_AtlasGallery = new _LibraryData(库类型.图库集);
        }

        /// <summary>
        /// 当前应用程序的工作目录
        /// </summary>
        private DirectoryInfo m_AppFolder = null;

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
            }
        }

        /// <summary>
        /// 用于缓存所有的库数据集
        /// </summary>
        public static Hashtable Libraries
        {
            get
            {
                return _LibraryData.Libraries;
            }
        }

        /// <summary>
        /// 清单结构体
        /// </summary>		
        public struct 库类型
        {
            public const string 清单库 = "清单库";
            public const string 定额库 = "定额库";
            public const string 图库集 = "图库集";
        }

        /// <summary>
        /// 清单库数据
        /// </summary>
        private  _LibraryData m_ListGallery = null;

        /// <summary>
        /// 定额规则
        /// </summary>
        private _LibraryData m_FixedLibrary = null;

        /// <summary>
        /// 获取或设置当前单位工程的图库
        /// </summary>
        private _LibraryData m_AtlasGallery = null;

        /// <summary>
        /// 获取或设置当前单位工程的图库
        /// </summary>
        public _LibraryData AtlasGallery
        {
            get
            {
                return this.m_AtlasGallery;
            }
            set
            {
                this.m_AtlasGallery = value;
            }
        }

        /// <summary>
        /// 获取或设置清单库
        /// </summary>
        public _LibraryData ListGallery
        {
            get 
            {
                return this.m_ListGallery;
            }
            set
            {
                
                this.m_ListGallery = value;
            }
        }

        /// <summary>
        /// 获取或设置定额库
        /// </summary>
        public _LibraryData FixedLibrary
        {
            get
            {
                return this.m_FixedLibrary;
            }
            set
            {
                
                this.m_FixedLibrary = value;
            }
        }


        /// <summary>
        /// 初始化清单数据
        /// </summary>
        public void Init(_Application p_App)
        {
            this.m_AppFolder = p_App.Global.AppFolder;
            this.m_ListGallery.Init(p_App.Global.AppFolder);
            this.m_FixedLibrary.Init(p_App.Global.AppFolder);
            this.m_AtlasGallery.Init(p_App.Global.AppFolder);
        }

        /// <summary>
        /// 获取当前库对象的副本
        /// </summary>
        /// <returns></returns>
        public virtual _Library Copy()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                object CloneObject;
                BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                // 反序列化至另一个对象(即创建了一个原对象的深表副本)
                CloneObject = bf.Deserialize(ms);
                // 关闭流
                ms.Close();
                return CloneObject as _Library;
            }
        }

        /// <summary>
        /// 库结构
        /// </summary>
        [Serializable]
        public class _LibraryData
        {
            [NonSerialized]
            public static Hashtable Libraries = new Hashtable();

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="p_libType"></param>
            public _LibraryData(string p_libType)
            {
                this.m_LibType = p_libType;
            }

            public _LibraryData()
            {
 
            }

            /// <summary>
            /// 当前库的标识
            /// </summary>
            private string m_ID = string.Empty;

            /// <summary>
            /// 库的规则
            /// </summary>
            private string m_Rule = string.Empty;

            /// <summary>
            /// 库名称
            /// </summary>
            private string m_LibName = string.Empty;

            /// <summary>
            /// 当前库类型
            /// </summary>
            private string m_LibType = 库类型.清单库;

            /// <summary>
            /// 库原始数据
            /// </summary>
            [NonSerialized]
            private DataSet m_LibraryDataSet = null;

            /// <summary>
            /// 获取或设置原始库数据
            /// </summary>
            public DataSet LibraryDataSet
            {
                get
                {
                    return this.m_LibraryDataSet;
                }
                set
                {
                    this.m_LibraryDataSet = value;
                }
            }

            /// <summary>
            /// 返回当前库的标识(默认为当前库的全名称不可更改)
            /// </summary>
            public string ID 
            {
                get
                {
                    return this.m_ID;
                }
            }

            /// <summary>
            /// 获取或设置库规则
            /// </summary>
            public string Rule
            {
                get
                {
                    return this.m_Rule;
                }
                set 
                {
                    this.m_Rule = value;
                }
            }

            /// <summary>
            /// 获取或设置库名称
            /// </summary>
            public string LibName
            {
                get
                {
                    return this.m_LibName;
                }
                set
                {
                    this.m_LibName = value;
                }
            }

            /// <summary>
            /// 获取库类型
            /// </summary>
            public string LibType
            {
                get
                {
                    return this.m_LibType;
                }
                set
                {
                    this.m_LibType = value;
                }
            }


            /// <summary>
            /// 当前库的全文件名称
            /// </summary>
            public string FullName
            {
                get 
                {
                    string n = string.Empty;
                    switch (this.m_LibType)
                    {
                        case 库类型.清单库:
                            n = "qdsx";
                            break;
                        case 库类型.定额库:
                            n = "dcsx";
                            break;
                        case 库类型.图库集:
                            n = "tjsx";
                            return string.Format("{0}.{1}", this.m_LibName, n);
                    }

                    return string.Format("{0}{1}.{2}", this.m_Rule, this.m_LibName, n);
                }
            }

            /// <summary>
            /// 为库结构数据初始化
            /// </summary>
            public void Init(DirectoryInfo p_AppFolder)
            {
                //lock (_LibraryData.Libraries)
                {

                    //加载清单库文件(如果已经存在缓存直接取出)
                    this.m_ID = this.FullName;

                    if (_LibraryData.Libraries.Contains(this.m_ID))
                    {
                        this.m_LibraryDataSet = _LibraryData.Libraries[this.m_ID] as DataSet;
                    }
                    else
                    {
                        string n = string.Empty;
                        switch (this.m_LibType)
                        {
                            case 库类型.清单库:
                                n = "清单库";
                                break;
                            case 库类型.定额库:
                                n = "定额库";
                                break;
                            case 库类型.图库集:
                                n = "图集库";
                                break;
                        }
                        string ph = string.Format("{0}库文件\\{2}\\{1}", p_AppFolder.FullName, this.FullName, n);
                        this.m_LibraryDataSet = _LibAction.Load(ph);

                        _LibraryData.Libraries.Add(this.m_ID, this.m_LibraryDataSet);
                    }
                }
            
            }

            /// <summary>
            /// 获取当前库对象的副本
            /// </summary>
            /// <returns></returns>
            public virtual _LibraryData Copy()
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    object CloneObject;
                    BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                    bf.Serialize(ms, this);
                    ms.Seek(0, SeekOrigin.Begin);
                    // 反序列化至另一个对象(即创建了一个原对象的深表副本)
                    CloneObject = bf.Deserialize(ms);
                    // 关闭流
                    ms.Close();
                    return CloneObject as _LibraryData;
                }
            }
        }
    }
}
