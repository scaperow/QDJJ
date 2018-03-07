using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_IncreaseInfo
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
        private _Entity_IncreaseCosts m_Current = null;
        /// <summary>
        /// 当前操作的对象
        /// </summary>
        public _Entity_IncreaseCosts Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }
        public _Methods_IncreaseInfo(_UnitProject p_un, _Entity_IncreaseCosts p_info)
        {
            this.m_Unit = p_un;
            this.m_Current = p_info;
        }
        /// <summary>
        /// 计算当前行
        /// </summary>
        /// <param name="p_info"></param>
        public void CurrentBegin(_Entity_SubInfo p_info)
        {
            string Dian = "F2";
            decimal temp = 0m;
            switch (this.m_Current.JSJC.ToLower())
            {

                case "rgf":
                    temp = p_info.RGFHJ;
                    break;
                case "clf":
                    temp = p_info.CLFHJ;
                    break;
                case "jxf":
                    temp = p_info.JXFHJ;
                    break;
                default:
                    break;
            }

            this.m_Current.RGF = m_Current.CLF = m_Current.JXF = m_Current.HJ = 0;
            temp = temp + ToolKit.ParseDecimal(this.m_Current.FJJS);
            decimal d = temp * this.m_Current.XS * 0.01m;
            this.m_Current.RGF = d * this.m_Current.RGXS * 0.01m;
            this.m_Current.RGF = ToolKit.ParseDecimal(this.m_Current.RGF.ToString(Dian));
            this.m_Current.CLF = d * this.m_Current.CLXS * 0.01m;
            this.m_Current.CLF = ToolKit.ParseDecimal(this.m_Current.CLF.ToString(Dian));
            this.m_Current.JXF = d * this.m_Current.JXXS * 0.01m;
            this.m_Current.JXF = ToolKit.ParseDecimal(this.m_Current.JXF.ToString(Dian));
            this.m_Current.HJ = this.m_Current.RGF + this.m_Current.CLF + this.m_Current.JXF;
            this.m_Current.HJ = ToolKit.ParseDecimal(this.m_Current.HJ.ToString(Dian));
            this.Unit.StructSource.ModelIncreaseCosts.UpDate(this.Current);//数据更新到table
        }
    }
}
