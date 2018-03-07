/*
 每次保存的时候记录的信息对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _SaveInfo
    {
        /// <summary>
        /// 加密锁号
        /// </summary>
        private string m_LockNum = null;

        /// <summary>
        /// 获取或设置加密锁号
        /// </summary>
        public string LockNum
        {
            get
            {
                return this.m_LockNum;
            }
            set
            {
                this.m_LockNum = value;
            }
        }

        /// <summary>
        /// 编辑时间
        /// </summary>
        private DateTime m_EditTime;

        /// <summary>
        /// 获取或设置编辑时间
        /// </summary>
        public DateTime EditTime
        {
            get
            {
                return this.m_EditTime;
            }
            set
            {
                this.m_EditTime = value;
            }
        }

        /// <summary>
        /// 类型(只有第一次创建的时候类型为-1)
        /// </summary>
        private int m_Type = 0;

        /// <summary>
        /// 获取或设置类型(只有第一次创建的时候类型为 -1)
        /// </summary>
        public int Type 
        {
            get { return m_Type; }
            set { this.m_Type = value; }
        }
    }
}
