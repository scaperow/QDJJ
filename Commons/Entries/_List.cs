/*
    所有集合的基础类别 从ArrayList继承
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
    public class _List:ArrayList
    {
        public virtual object this[string Name]
        {
            get
            {
                foreach (object obj in this)
                {
                    if (obj.ToString() == Name)
                    {
                        return obj;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="o">所要插入的对象</param>
        /// <param name="o_index">所根据的对象</param>
       public virtual  void Insert(object o,object o_index)
       {
           if (this.IndexOf(o_index) < 0) base.Add(o);
           else
           base.Insert(this.IndexOf(o_index)+1, o);
       }

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
