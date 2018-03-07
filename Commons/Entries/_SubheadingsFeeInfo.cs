using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 子目取费对象
    /// </summary>
    [Serializable]
    public class _SubheadingsFeeInfo : _ObjectSubheadingsFee
    {
        /// <summary>
        /// 初始化：子目取费对象
        /// </summary>
        public _SubheadingsFeeInfo(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return this.m_Parent; }
            set { this.Parent = value; }
        }

        #region----------------------计算方法定义---------------------------------
        /// <summary>
        /// 获取或设置：投标计算基础
        /// </summary>
        public override string TBJSJC
        {
            get { return base.TBJSJC; }
            set
            {
                base.TBJSJC = value;
                if (!base.STATUS)
                {
                    this.Parent.Subheadings_Statistics.FBegin();
                }
            }
        }
        /// <summary>
        /// 获取或设置：费率
        /// </summary>
        public override decimal FL
        {
            get { return base.FL; }
            set
            {
                base.FL = value;
                if (!base.STATUS)
                {
                    this.Parent.Subheadings_Statistics.FBegin();
                }
            }
        }

        /// <summary>
        /// 获取或设置：费用类别
        /// </summary>
        public override string FYLB
        {
            get { return base.FYLB; }
            set
            {
                base.FYLB = value;
                if (!base.STATUS)
                {
                    this.Parent.Subheadings_Statistics.FBegin();
                }
            }
        }
        #endregion
    }
}
