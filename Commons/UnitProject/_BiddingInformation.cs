/*
    招标信息
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _BiddingInformation : _InformationData
    {
        /// <summary>
        /// 建设单位
        /// </summary>
        private string m_JSDW = string.Empty;
        /// <summary>
        /// 建设单位法定代表人
        /// </summary>
        private string m_JSDWDBR = string.Empty;
        /// <summary>
        /// 招标代理人
        /// </summary>
        private string m_ZBDLR = string.Empty;
        /// <summary>
        /// 法定代表人
        /// </summary>
        private string m_DBR = string.Empty;

        /// <summary>
        /// 工程类型
        /// </summary>
        private string m_GCLX = string.Empty;
        /// <summary>
        /// 招标范围
        /// </summary>
        private string m_ZBFW = string.Empty;
        /// <summary>
        /// 招标面积
        /// </summary>
        private string m_ZBMJ = string.Empty;
        
        /// <summary>
        /// 招标工期
        /// </summary>
        private string m_ZBGQ = string.Empty;
        /// <summary>
        /// 编制单位
        /// </summary>
        private string m_BZDW = string.Empty;
       
        /// <summary>
        /// 设计单位
        /// </summary>
        private string m_SJDW = string.Empty;
        /// <summary>
        /// 担保类型
        /// </summary>
        private string m_DBLX = string.Empty;
        /// <summary>
        /// 建设单位
        /// </summary>
        public string JSDW
        {
            get
            {
                return this.m_JSDW;
            }
            set
            {
                this.m_JSDW = value;
            }
        }
        /// <summary>
        /// 建设单位法定代表人
        /// </summary>
        public string JSDWDBR
        {
            get
            {
                return this.m_JSDWDBR;
            }
            set
            {
                this.m_JSDWDBR = value;
            }

        }

        /// <summary>
        /// 招标代理人
        /// </summary>
        public string ZBDLR
        {
            get
            {
                return this.m_ZBDLR;
            }
            set
            {
                this.m_ZBDLR = value;
            }
        }
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string DBR
        {
            get
            {
                return this.m_DBR;
            }
            set
            {
                this.m_DBR = value;
            }
        }
        /// <summary>
        /// 工程类型
        /// </summary>
        public string GCLX
        {
            get { return m_GCLX; }
            set { m_GCLX = value; }
        }
        /// <summary>
        /// 招标范围
        /// </summary>
        public string ZBFW
        {
            get { return m_ZBFW; }
            set { m_ZBFW = value; }
        }
        /// <summary>
        /// 招标面积
        /// </summary>
        public string ZBMJ
        {
            get { return m_ZBMJ; }
            set { m_ZBMJ = value; }
        }
        /// <summary>
        /// 招标工期
        /// </summary>
        public string ZBGQ
        {
            get { return m_ZBGQ; }
            set { m_ZBGQ = value; }
        }
        /// <summary>
        /// 编制单位
        /// </summary>
        public string BZDW
        {
            get { return m_BZDW; }
            set { m_BZDW = value; }
        }
        /// <summary>
        /// 设计单位
        /// </summary>
        public string SJDW
        {
            get { return m_SJDW; }
            set { m_SJDW = value; }
        }
        /// <summary>
        /// 担保类型
        /// </summary>
        public string DBLX
        {
            get { return m_DBLX; }
            set { m_DBLX = value; }
        }
    }
}
