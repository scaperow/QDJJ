/*
 当前数据对象的标记类(主要用来处理对象实体序号 排序序号)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 用于处理对象标识
    /// </summary>
    [Serializable]
    public class _Sign
    {
        /// <summary>
        /// 唯一标识不重复的Key对象
        /// </summary>
        private long m_MasterKey = 0, m_Un_Key = 0, m_En_Key = 0;

        /// <summary>
        /// 单位工程的顺序统计
        /// </summary>
        public virtual long Next_Un_Key
        {
            get
            {
                return this.m_Un_Key + 1;
            }
        }

        /// <summary>
        /// 单位工程的顺序统计
        /// </summary>
        public virtual long Next_En_Key
        {
            get
            {
                return this.m_En_Key + 1;
            }
        }

        /// <summary>
        /// 单位工程的顺序统计
        /// </summary>
        public virtual long Curr_Un_Key
        {
            get
            {
                return this.m_Un_Key;
            }
            set
            {
                this.m_Un_Key = value;
            }
        }

        /// <summary>
        /// 单位工程的顺序统计
        /// </summary>
        public virtual long Curr_En_Key
        {
            get
            {
                return this.m_En_Key;
            }
            set
            {
                this.m_En_Key = value;
            }
        }


        /// <summary>
        /// 获取新的数据对象标识(确保对象唯一性)
        /// </summary>
        public virtual long NextKey
        {
            get
            {
                return this.m_MasterKey + 1;
            }
        }

        /// <summary>
        /// 获取当前的Key对象
        /// </summary>
        public virtual long CurrKey
        {
            get
            {
                return this.m_MasterKey;
            }
            set
            {
                this.m_MasterKey = value;
            }
        }

        /// <summary>
        /// 获取当前对象的副本
        /// </summary>
        /// <returns>对象的副本</returns>
        public _Sign Copy()
        {
            _Sign info       = new _Sign();
            info.CurrKey     = this.CurrKey;
            info.Curr_En_Key = this.Curr_En_Key;
            info.Curr_Un_Key = this.Curr_Un_Key;
            return info;
        }

    }
}
