using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{

    public class MergerSummary : IEqualityComparer<_ObjectQuantityUnitInfo>
    {
        bool IEqualityComparer<_ObjectQuantityUnitInfo>.Equals(_ObjectQuantityUnitInfo x, _ObjectQuantityUnitInfo y)
        {
            x = x as _ObjectQuantityUnitInfo;
            y = y as _ObjectQuantityUnitInfo;
            if (x == null)
            {
                return y == null;
            }
            if (x.BH == y.BH)
            {
                x.SLH += y.SL;
                return true;
            }
            return false;
        }

        int IEqualityComparer<_ObjectQuantityUnitInfo>.GetHashCode(_ObjectQuantityUnitInfo obj)
        {

            obj = obj as _ObjectQuantityUnitInfo;
            if (obj == null)
                return 0;
            obj.SLH = obj.SL;
            return obj.BH.GetHashCode();
        }
        
    }

    public class COMMONS_MergerSummary : IEqualityComparer<DataRow>
    {
        bool IEqualityComparer<DataRow>.Equals(DataRow x, DataRow y)
        {
            if (x == null)
            {
                return y == null;
            }
            if (x["BH"].Equals(y["BH"]))
            {
                x.BeginEdit();
                x["SLH"] = ToolKit.ParseDecimal(x["SLH"]) + ToolKit.ParseDecimal(y["SL"]);
                this.SummaryRowCalculate(x);
                x.EndEdit();
                return true;
            }
            return false;
        }

        int IEqualityComparer<DataRow>.GetHashCode(DataRow obj)
        {
            if (obj == null)
            {
                return 0;
            }
            obj.BeginEdit();
            obj["SLH"] = obj["SL"];
            obj.EndEdit();
            return obj["BH"].GetHashCode();
        }

        /// <summary>
        /// 行计算 数据行
        /// </summary>
        /// <param name="p_info"></param>
        public void SummaryRowCalculate(DataRow p_info)
        {
            p_info["DJC"] = (ToolKit.ParseDecimal(p_info["SCDJ"]) - ToolKit.ParseDecimal(p_info["DEDJ"])).ToString("F2");
            p_info["JSDJC"] = (p_info["JSDJ"].Equals(0m) ? 0m : ToolKit.ParseDecimal(p_info["JSDJ"]) - ToolKit.ParseDecimal(p_info["SCDJ"])).ToString("F2"); ;
            p_info["SLDEHJ"] = (ToolKit.ParseDecimal(p_info["DEDJ"]) * ToolKit.ParseDecimal(p_info["SLH"])).ToString("F2");
            p_info["SLSCHJ"] = (ToolKit.ParseDecimal(p_info["SCDJ"]) * ToolKit.ParseDecimal(p_info["SLH"])).ToString("F2");
            p_info["HJC"] = (ToolKit.ParseDecimal(p_info["DJC"]) * ToolKit.ParseDecimal(p_info["SLH"])).ToString("F2");
            p_info["JSHJC"] = (p_info["JSDJ"].Equals(0m) ? 0m : ToolKit.ParseDecimal(p_info["JSDJC"]) * ToolKit.ParseDecimal(p_info["SLH"])).ToString("F2");
            p_info["SDCHJ"] = (ToolKit.ParseDecimal(p_info["SDCXS"]) * ToolKit.ParseDecimal(p_info["SLH"])).ToString("F2");
            p_info["DEHJ"] = (ToolKit.ParseDecimal(p_info["DEDJ"]) * ToolKit.ParseDecimal(p_info["XHL"]));
            p_info["SCHJ"] = (ToolKit.ParseDecimal(p_info["SCDJ"]) * ToolKit.ParseDecimal(p_info["XHL"]));
        }
    }
}
