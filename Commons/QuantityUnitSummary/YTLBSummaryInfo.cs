using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 用途类别汇总对象
    /// </summary>
    [Serializable]
    public class YTLBSummaryInfo : _ObjectQuantityUnitInfo
    {
        public YTLBSummaryInfo(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        public YTLBSummaryInfo() { }

        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
        public _UnitProject Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }

        /// <summary>
        /// 绑定编号
        /// </summary>
        public const string FILED_BDBH = "BDBH";
        /// <summary>
        /// 绑定编号
        /// </summary>
        private string m_BDBH = string.Empty;

        /// <summary>
        /// 获取或设置：绑定编号
        /// </summary>
        public string BDBH
        {
            get { return m_BDBH; }
            set { m_BDBH = value; }
        }
        /// <summary>
        /// 市场单价
        /// </summary>
        public override decimal SCDJ
        {
            get { return base.SCDJ; }
            set
            {
                if (this.BDBH != string.Empty)
                {
                    if (this.STATUS == Status.Update)
                    {
                        _ObjectQuantityUnitInfo m_list = this.Parent.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == this.BDBH).FirstOrDefault();
                        if (m_list != null)
                        {
                            m_list.STATUS = Status.Update;
                            m_list.SCDJ = value;
                        }
                        this.STATUS = Status.Normal;
                    }
                }
                base.SCDJ = value;
            }
        }
    }
}
