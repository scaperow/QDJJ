/*
 投标信息类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _TenderInformation : _InformationData
    {
        /// <summary>
        /// 投标单位
        /// </summary>
        private string m_TBDW = string.Empty;

        /// <summary>
        /// 投标单位代表人
        /// </summary>
        private string m_TBDWDBR = string.Empty;

        /// <summary>
        /// 投标工期
        /// </summary>
        private string m_TBGQ = string.Empty;

        /// <summary>
        /// 质量承诺
        /// </summary>
        private string m_ZLCN = string.Empty;

        /// <summary>
        /// 标保证金
        /// </summary>
        private string m_BBZJ = string.Empty;

        /// <summary>
        /// 担保类型
        /// </summary>
        private string m_DBLX = string.Empty;

        /// <summary>
        /// 建造师
        /// </summary>
        private string m_JZS = string.Empty;

        /// <summary>
        /// 建造师号
        /// </summary>
        private string m_JZSH = string.Empty;


        /// <summary>
        /// 投标单位
        /// </summary>
        public string TBDW
        {
            get
            {
                return this.m_TBDW;
            }
            set
            {
                this.m_TBDW = value;
            }
        }

        /// <summary>
        /// 投标单位代表人
        /// </summary>
        public string TBDWDBR
        {
            get
            {
                return this.m_TBDWDBR;
            }
            set
            {
                this.m_TBDWDBR = value;
            }
        }

        /// <summary>
        /// 投标工期
        /// </summary>
        public string TBGQ
        {
            get
            {
                return this.m_TBGQ;
            }
            set
            {
                this.m_TBGQ = value;
            }
        }   

        /// <summary>
        /// 质量承诺
        /// </summary>
        public string ZLCN
        {
            get
            {
                return this.m_ZLCN;
            }
            set
            {
                this.m_ZLCN = value;
            }
        }

        /// <summary>
        /// 标保证金
        /// </summary>
        public string BBZJ
        {
            get { return this.m_BBZJ;}
            set { this.m_BBZJ = value; }
        }

        /// <summary>
        /// 担保类型
        /// </summary>
        public string DBLX
        {
            get { return this.m_DBLX; }
            set { this.m_DBLX = value; }
        }

        /// <summary>
        /// 建造师
        /// </summary>
        public string JZS
        {
            get { return this.m_JZS; }
            set { this.m_JZS = value; }
        }

        /// <summary>
        /// 建造师号
        /// </summary>
        public string JZSH
        {
            get {  return this.m_JZSH ; }
            set { this.m_JZSH = value; }
        }
    }
}
