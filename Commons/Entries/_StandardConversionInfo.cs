using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 标准换算对象
    /// </summary>
    [Serializable]
    public class _StandardConversionInfo : _ObjectStandardConversionInfo
    {
        /// <summary>
        /// 初始化：标准换算对象
        /// </summary>
        /// <param name="p_Parent">所属：子目</param>
        public _StandardConversionInfo(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
            
        }
      
        /// <summary>
        /// 所属对象：子目对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return this.m_Parent; }
        }

        #region----------------------计算方法定义---------------------------------
        /// <summary>
        /// 是否选择
        /// </summary>
        public override bool IFXZ
        {
            get { return base.IFXZ; }
            set { base.IFXZ = value; }
        }
        
        public void CalculateXHL()
        {
            if (XHLB == "3")
            {
                UpdateXHL(base.DJ_DW);
            }
            else
            {
                UpdateXHL(base.JBL_RGXS, _Constant.rg);
                UpdateXHL(base.DEH_CLXS, _Constant.cl);
                UpdateXHL(base.TZL_JXXS, _Constant.jx);
            }
        }

        private void UpdateXHL(string xs, string lb)
        {
            if (xs != string.Empty)
            {
                IEnumerable<_SubheadingsQuantityUnitInfo> list = from info in this.Parent.SubheadingsQuantityUnitList.Cast<_SubheadingsQuantityUnitInfo>()
                                                                 where lb.Contains("'" + info.LB + "'")
                                                                 select info;
                foreach (_ObjectQuantityUnitInfo info in list)
                {
                    if (!info.LB.Contains("%"))
                    {
                        info.XHL = base.IFXZ ? (info.XHL * Convert.ToDecimal(xs)) : (info.XHL / Convert.ToDecimal(xs));
                    }
                }
            }
        }

        private void UpdateXHL(string xs)
        {
            if (xs != string.Empty)
            {
                foreach (_ObjectQuantityUnitInfo info in this.Parent.SubheadingsQuantityUnitList)
                {
                    if (!info.LB.Contains("%"))
                    {
                        info.XHL = base.IFXZ ? (info.XHL * Convert.ToDecimal(xs)) : (info.XHL / Convert.ToDecimal(xs));
                    }
                }
            }
        }
        #endregion
    }
}
