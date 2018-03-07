/*
 TreeList的模块样式类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DevExpress.Utils;
using System.Runtime.Serialization;
using DevExpress.XtraTreeList;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 模块化树节点配置
    /// </summary>
    [Serializable]
    public class _TreeListModelStyle
    {

        
        private Hashtable m_ModelStyleList = null;

        public Hashtable ModelStyleList
        {
            get
            {
                return this.m_ModelStyleList;
            }
            set
            {
                this.m_ModelStyleList = value;
            }

        }


        /// <summary>
        /// 返回指定模块的层级集合
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public _Layer this[string str]
        {
            get
            {
                if (m_ModelStyleList.ContainsKey(str))
                {
                    return m_ModelStyleList[str] as _Layer;
                }
                if (m_ModelStyleList.ContainsKey("全部模块"))
                {
                    return m_ModelStyleList["全部模块"] as _Layer;
                }
                return null;
            }
        }


        public _TreeListModelStyle():base()
        {
            m_ModelStyleList = new Hashtable();
            m_ModelStyleList.Add("全部模块", new _Layer());
            m_ModelStyleList.Add("汇总分析", new _Layer());
            m_ModelStyleList.Add("分部分项", new _Layer());
            m_ModelStyleList.Add("措施项目", new _Layer());
        }

        /// <summary>
        /// 获取当前对象的一个副本
        /// </summary>
        /// <returns></returns>
        public virtual _TreeListModelStyle Copy()
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
                return CloneObject as _TreeListModelStyle;
            }
        }
    }

    /// <summary>
    /// 模块中的层级(默认构造5层级别)
    /// </summary>
    [Serializable]
    public class _Layer
    {

        private Hashtable m_LayerList = null;

        public Hashtable LayerList
        {
            get
            {
                return this.m_LayerList;
            }
            set
            {
                this.LayerList = value;
            }

        }

        /// <summary>
        /// 每个模块中的全局处理
        /// </summary>
        private _CAppearance m_CAppearance = null;


        /// <summary>
        /// 模块中全局处理
        /// </summary>
        public _CAppearance CAppearance
        {
            get
            {
                return this.m_CAppearance;
            }
            set
            {
                this.m_CAppearance = value;
            }
        }

        

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="p_key"></param>
        /// <returns></returns>
        public _CellStyle this[int p_key]
        {
            get 
            {
                if (this.m_LayerList.ContainsKey(p_key))
                {
                    return this.m_LayerList[p_key] as _CellStyle;
                }
                return null;
            }
        }


        public _Layer()
        {
            m_LayerList = new Hashtable();
            this.m_CAppearance = new _CAppearance();
            for (int i = 0; i < 5; i++)
            {
                this.m_LayerList.Add(i, new _CellStyle());
            }
        }

    }   

}
