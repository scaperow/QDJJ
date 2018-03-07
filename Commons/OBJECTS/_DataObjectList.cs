/*
 用于存放数据对象的集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _DataObjectList
    {
        
        public _DataObjectList()
        {
            this.m_ObjectList = new Hashtable();
        }

        private Hashtable m_ObjectList = null;

        /// <summary>
        /// 获取数据对象的集合HashTable
        /// </summary>
        public Hashtable ObjectList
        {
            get
            {
                return this.m_ObjectList;
            }
        }

        /// <summary>
        /// 添加数据集合对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(object key, object value)
        {
            if (this.m_ObjectList.ContainsKey(key))
            {
                this.m_ObjectList[key] = value;
            }
            else
            {
                this.m_ObjectList.Add(key, value);
            }
        }

        /// <summary>
        /// 获取挡墙集合中指定的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (this.m_ObjectList.ContainsKey(key))
            {
                return this.m_ObjectList[key];
            }
            return null;
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key,object value)
        {
            if (this.m_ObjectList.ContainsKey(key))
            {
                this.m_ObjectList[key] = value;
            }
            else
            {
                this.m_ObjectList.Add(key, value);
            }
            
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(long key, object value)
        {
            if (this.m_ObjectList.ContainsKey(key))
            {
                this.m_ObjectList[key] = value;
            }
            else
            {
                this.m_ObjectList.Add(key, value);
            }

        }

        /// <summary>
        /// 删除指定的对象
        /// </summary>
        /// <param name="m_key"></param>
        public void Remove(long m_key)
        {
            this.m_ObjectList.Remove(m_key);
        }

        /// <summary>
        /// 获取对象的副本
        /// </summary>
        /// <returns></returns>
        public virtual object Copy()
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
                return CloneObject;
            }
        }
    }
}
