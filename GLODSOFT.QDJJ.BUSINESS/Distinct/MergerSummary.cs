using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class MergerSummarys : IEqualityComparer<DataRow>
    {
        bool IEqualityComparer<DataRow>.Equals(DataRow x, DataRow y)
        {
            if (x == null)
            {
                return y == null;
            }
            if (x["BH"].Equals(y["BH"]))
            {
                x["SLH"] = ToolKit.ParseDecimal(x["SLH"]) + ToolKit.ParseDecimal(y["SL"]);
                //_Methods_Quantity.SummaryRowCalculate(x);
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
            obj["SLH"] = obj["SL"];
            //_Methods_Quantity.SummaryRowCalculate(obj);
            return obj["BH"].GetHashCode();
        }
    }

    public class ProjectSummary : IEqualityComparer<DataRow>
    {
        bool IEqualityComparer<DataRow>.Equals(DataRow x, DataRow y)
        {
            if (x == null)
            {
                return y == null;
            }
            if (x["BH"].Equals(y["BH"]) && x["MC"].Equals(y["MC"]) && x["DW"].Equals(y["DW"]) && x["SCDJ"].Equals(y["SCDJ"]) && x["IFSDSCDJ"].Equals(y["IFSDSCDJ"]) && x["YTLB"].Equals(y["YTLB"]) && x["LB"].Equals(y["LB"]))
            {
                x["SLH"] = ToolKit.ParseDecimal(x["SLH"]) + ToolKit.ParseDecimal(y["SL"]);
                //_Methods_Quantity.SummaryRowCalculate(x);
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
            obj["SLH"] = obj["SL"];
            //_Methods_Quantity.SummaryRowCalculate(obj);
            return obj["BH"].GetHashCode();
        }
    }
    
}
