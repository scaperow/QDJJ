using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_StandardConversion
    {
        private _UnitProject m_Unit = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary>
        public _UnitProject Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }
        /// <summary>
        /// 当前操作的工料机
        /// </summary>
        private DataRow m_Current = null;
        /// <summary>
        /// 获取或设置：当前操作的工料机
        /// </summary>
        public DataRow Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        public _Methods_StandardConversion(_UnitProject p_Unit)
        {
            this.m_Unit = p_Unit;
        }

        public void CalculateXHL()
        {
            if (this.Current == null) return;
            if (this.Current["XHLB"].Equals("3"))
            {
                UpdateXHL(this.Current["DJ_DW"].ToString());
            }
            else
            {
                UpdateXHL(this.Current["JBL_RGXS"].ToString(), _Constant.rg);
                UpdateXHL(this.Current["DEH_CLXS"].ToString(), _Constant.cl);
                UpdateXHL(this.Current["TZL_JXXS"].ToString(), _Constant.jx);
            }
        }

        /// <summary>
        /// 修改消耗量
        /// </summary>
        /// <param name="p_XS">系数</param>
        /// <param name="p_LB">类别</param>
        private void UpdateXHL(string p_XS, string p_LB)
        {
            if (p_XS != string.Empty)
            {
                DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} AND SSLB={1} AND ZCLB='W' AND IFSDSL='False'  AND LB IN({2})", this.Current["ZMID"].ToString(),this.Current["SSLB"].ToString(),p_LB));
                foreach (DataRow item in drs)
                {
                    if (!item["LB"].ToString().Contains("%"))
                    {
                        item.BeginEdit();
                        item["XHL"] = this.Current["IFXZ"].Equals(true) ? (ToolKit.ParseDecimal(item["XHL"]) * Convert.ToDecimal(p_XS)) : (ToolKit.ParseDecimal(item["XHL"]) / Convert.ToDecimal(p_XS));
                        item.EndEdit();
                        if (item["IFKFJ"].Equals(true))
                        {
                            _Methods_Quantity.UpdateZCGCL(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 修改消耗量
        /// </summary>
        /// <param name="p_XS">系数</param>
        private void UpdateXHL(string p_XS)
        {
            if (p_XS != string.Empty)
            {
                DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} AND SSLB={1} AND ZCLB='W' AND IFSDSL='False'", this.Current["ZMID"].ToString(), this.Current["SSLB"].ToString()));
                foreach (DataRow item in drs)
                {
                    if (!item["LB"].ToString().Contains("%"))
                    {
                        item.BeginEdit();
                        item["XHL"] = this.Current["IFXZ"].Equals(true) ? (ToolKit.ParseDecimal(item["XHL"]) * Convert.ToDecimal(p_XS)) : (ToolKit.ParseDecimal(item["XHL"]) / Convert.ToDecimal(p_XS));
                        item.EndEdit();
                        if (item["IFKFJ"].Equals(true))
                        {
                            _Methods_Quantity.UpdateZCGCL(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 手动计算公式
        /// </summary>
        /// <param name="p_XS">系数</param>
        /// <param name="p_LB">类别</param>
        /// <param name="p_AS">True：乘除、False：加减</param>
        public void UpdateXHL(string p_ZMID, string p_SSLB, decimal p_XS, string p_LB, bool p_AS)
        {
            if (p_XS != 0)
            {
                DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} AND SSLB={1} AND ZCLB='W' AND IFSDSL='False' AND LB IN({2})", p_ZMID, p_SSLB, p_LB));
                foreach (DataRow item in drs)
                {
                    if (!item["LB"].ToString().Contains("%"))
                    {
                        item.BeginEdit();
                        item["XHL"] = p_AS ? (ToolKit.ParseDecimal(item["XHL"]) * p_XS) : (ToolKit.ParseDecimal(item["XHL"]) + p_XS);
                        item.EndEdit();
                        if (item["IFKFJ"].Equals(true))
                        {
                            _Methods_Quantity.UpdateZCGCL(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 手动计算公式
        /// </summary>
        /// <param name="p_XS">系数</param>
        /// <param name="p_AS">True：乘除、False：加减</param>
        public void UpdateXHL(string p_ZMID,string p_SSLB,decimal p_XS, bool p_AS)
        {
            if (p_XS != 0)
            {
                DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} AND SSLB={1} AND ZCLB='W' AND IFSDSL='False'", p_ZMID, p_SSLB));
                foreach (DataRow item in drs)
                {
                    if (!item["LB"].ToString().Contains("%"))
                    {
                        item.BeginEdit();
                        item["XHL"] = p_AS ? (ToolKit.ParseDecimal(item["XHL"]) * p_XS) : (ToolKit.ParseDecimal(item["XHL"]) + p_XS);
                        item.EndEdit();
                        if (item["IFKFJ"].Equals(true))
                        {
                            _Methods_Quantity.UpdateZCGCL(item);
                        }
                    }
                }
            }
        }
    }
}
