/*
 * 头文件，的预留接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _FileHeader
    {
        //暂时只有项目金额
        private Hashtable m_HeaderTable = null;

        public _FileHeader()
        {
            this.m_HeaderTable = new Hashtable();
            //默认总造价为0
            this.m_HeaderTable.Add("总造价", 0);
        }

        /// <summary>
        /// 设置头文件信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(object key, object value)
        {
            if (this.m_HeaderTable.ContainsKey(key))
            {
                this.m_HeaderTable[key] = value;
            }
            else
            {
                this.m_HeaderTable.Add(key, value);
            }
        }

        /// <summary>
        /// 获取头文件信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(object key)
        {
            if (this.m_HeaderTable.ContainsKey(key))
            {
                return this.m_HeaderTable[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取总造价
        /// </summary>
        public string GetZZJ
        {
            get
            {
                return this.Get("总造价").ToString();
            }
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileLength{get;set;}
    }
}
