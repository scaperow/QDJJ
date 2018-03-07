/*
 单为工程基本信息类 基本信息
 * 包含 招标信息 投标信息 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _BasicInformation
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _BasicInformation()
        {
            //投标
            this.m_BiddingInformation = new _BiddingInformation();
            //招标
            this.m_TenderInformation = new _TenderInformation();
        }

        /// <summary>
        /// 投标信息
        /// </summary>
        private _TenderInformation m_TenderInformation = null;

        /// <summary>
        /// 招标信息
        /// </summary>
        private _BiddingInformation m_BiddingInformation = null;

        /// <summary>
        /// 投标信息
        /// </summary>
        public _TenderInformation TenderInformation
        {
            get 
            {
                return this.m_TenderInformation;
            }
            set
            {
                this.m_TenderInformation = value;
            }
        }

        /// <summary>
        /// 招标信息
        /// </summary>
        public _BiddingInformation BiddingInformation
        {
            get { return this.m_BiddingInformation; }
            set { this.m_BiddingInformation = value; }
        }
    }
}
