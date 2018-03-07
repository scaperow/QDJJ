/*
    最终控件使用的对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _CAppearance
    {
        public _CAppearance()
        {
            
        }
        
        /// <summary>
        /// 获取或设置默认样式字节
        /// </summary>
        private byte[] m_Value;

        /// <summary>
        /// 获取或设置默认样式字节
        /// </summary>
        public  byte[] Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = value;
            }
        }

        /// <summary>
        /// 获取当前对象的一个副本
        /// </summary>
        /// <returns></returns>
        public virtual _CAppearance Copy()
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
                return CloneObject as _CAppearance;
            }
        }

    }
}
