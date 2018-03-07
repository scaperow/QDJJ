/*
 通用基本数据
 使用 招标 投标 单位工程(需要相同的对象集合)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _InformationData
    {
        //编制人资格证号
        private string m_PlaitNo = string.Empty;
        //复核人
        private string m_ReviewName = string.Empty;
        //编制人
        private string m_PlaitName = string.Empty;
        //编制日期
        private DateTime m_PlaitDate;
        //复核日期
        private DateTime m_ReviewDate;

        /// <summary>
        /// 获取或设置 编制人资格证号
        /// </summary>
        public string PlaitNo
        {
            get { return this.m_PlaitNo; }
            set { this.m_PlaitNo = value; }
        }

        /// <summary>
        /// 获取或设置 复核人
        /// </summary>
        public string ReviewName
        {
            get { return this.m_ReviewName; }
            set { this.m_ReviewName = value; }
        }

        /// <summary>
        /// 获取或设置 编制人
        /// </summary>
        public string PlaitName
        {
            get { return this.m_PlaitName; }
            set { this.m_PlaitName = value; }
        }

        /// <summary>
        /// 获取或设置 编制日期
        /// </summary>
        public DateTime PlaitDate
        {
            get { return this.m_PlaitDate; }
            set { this.m_PlaitDate = value; }
        }

        /// <summary>
        /// 获取或设置 复核日期
        /// </summary>
        public DateTime ReviewDate
        {
            get { return this.m_ReviewDate; }
            set { this.m_ReviewDate = value; }
        }
    }
}
