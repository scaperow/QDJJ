/*
    样式基础类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _StyleObject
    {
        /// <summary>
        /// 获取或设置默认样式字节
        /// </summary>
        private _CAppearance m_Default;

        /// <summary>
        /// 获取或设置用户定义字节
        /// </summary>
        private _CAppearance m_Custom;

        /// <summary>
        /// 获取或设置用户定义字节
        /// </summary>
        public _CAppearance Custom
        {
            get
            {
                return this.m_Custom;
            }
            set
            {
                this.m_Custom = value;
            }
        }

        /// <summary>
        /// 获取当前使用的样式
        /// </summary>
        public virtual _CAppearance Current
        {
            get
            {
                return this.m_Default;
            }
        }

        /// <summary>
        /// 获取或设置默认样式字节
        /// </summary>
        public virtual _CAppearance Default
        {
            get
            {
                return this.m_Default;
            }
            set
            {
                this.m_Default = value;
            }
        }

        /// <summary>
        /// 写入配置文件内存变量（全局集合中使用）
        /// </summary>
        /// <param name="p_GVA"></param>
        public virtual void Set(DevExpress.Utils.BaseAppearanceCollection p_GVA)
        {
            System.IO.MemoryStream buffer = new System.IO.MemoryStream();
            p_GVA.SaveLayoutToStream(buffer);
            this.Current.Value = buffer.GetBuffer();
            buffer.Close();
        }

        public virtual BaseAppearanceCollection Get() { return null; }

    }
}
