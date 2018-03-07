/*
 用于最终展示在界面的集合对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Directory:IDirectory
    {
        /// <summary>
        /// 不公开的构造函数
        /// </summary>
        _Directory()
        { 
        }

        public _Directory(_COBJECTS p_Info)
        {
            this.m_Parent = p_Info;
        }

        /// <summary>
        /// 当前基础类别的父类别(若为顶级类别此属性为null)
        /// </summary>
        private _COBJECTS m_Parent = null;
        /// <summary>
        /// 获取当前基础父类别
        /// </summary>
        public _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }


        private long m_Key = -1;
        private long m_PKey;
        private string m_NodeName = string.Empty;
        private int m_ImageIndex;
        private int m_Deep;
        private long m_Sort;
        public long Key { get { return this.m_Key; } set { this.m_Key = value; } }
        public long PKey { get { return this.m_PKey; } set { this.m_PKey = value; } }
        public string NodeName { get { return this.m_NodeName; } set { this.m_NodeName = value; } }
        public int ImageIndex { get { return this.m_ImageIndex; } set { this.m_ImageIndex = value; } }
        public int Deep { get { return this.m_Deep; } set { this.m_Deep = value; } }
        public long Sort { get { return this.m_Sort; } set { this.m_Sort = value; } }

        /// <summary>
        /// 获取当前对象的一个副本
        /// </summary>
        /// <param name="p_Info">获取的副本必须重新设置所属数据对象</param>
        /// <returns></returns>
        public _Directory Copy(_COBJECTS p_Info)
        {
            _Directory info = new _Directory(p_Info);
            info.m_Key  = this.m_Key;
            info.m_PKey = this.m_PKey;
            info.m_NodeName = p_Info.Property.Name;
            info.m_ImageIndex = this.m_ImageIndex;
            info.m_Deep = this.m_Deep;
            info.m_Sort = this.m_Sort;
            return info;
        }
    }
}
