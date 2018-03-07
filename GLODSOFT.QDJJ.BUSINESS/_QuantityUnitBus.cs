using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _QuantityUnitBus
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="drv">修改之前行信息</param>
        ///// <param name="fieldName">修改的字段</param>
        ///// <param name="value">修改后的值</param>
        ///// <param name="range">修改范围</param>
        ///// <returns></returns>
        //public string GetName(DataTable dt, DataRowView drv, string fieldName, string value, int range)
        //{
        //    string BH = string.Empty;
        //    string sql = string.Empty;
        //    string sqls = string.Format("BH='{0}' AND MC = '{1}' AND DW = '{2}' AND  SCDJ = '{3}' ",
        //        drv["BH"].ToString(),
        //        fieldName == "MC" ? value : drv["MC"].ToString(),
        //        fieldName == "DW" ? value : drv["DW"].ToString(),
        //        fieldName == "SCDJ" ? value : drv["SCDJ"].ToString());
        //    switch (range)
        //    {
        //        case 1:
        //            sqls = string.Format("DWID = '{0}' AND {1}",
        //                drv["DWID"].ToString(), sqls);
        //            break;
        //        case 2:
        //            sqls = string.Format("DWID = '{0}' AND QID='{1}' AND {2}",
        //                drv["DWID"].ToString(), drv["QID"].ToString(), sqls);
        //            break;
        //        case 3:
        //            sqls = string.Format("DWID = '{0}' AND QID = '{1}' AND ZID = '{2}' AND {3}",
        //                drv["DWID"].ToString(), drv["QID"].ToString(), drv["ZID"].ToString(), sqls);
        //            break;
        //        default:
        //            break;
        //    }
        //    //查询修改前 工料机当前范围条数
        //    DataRow[] dtdrs = dt.Select(sqls);

        //    if (drv["MC"].Equals(drv["YSMC"]) && drv["DW"].Equals(drv["YSDW"]) && drv["SCDJ"].Equals(drv["DEDJ"]))
        //    {
        //        BH = drv["YSBH"].ToString();
        //    }
        //    else
        //    {
        //        sql = string.Format("YSBH = '{0}' AND MC = '{1}' AND DW = '{2}' AND  SCDJ = '{3}' ",
        //            drv["YSBH"].ToString(),
        //            drv["MC"].ToString(),
        //            drv["DW"].ToString(),
        //            drv["SCDJ"].ToString());
        //        //查询修改后 用户价格库中的条数
        //        DataRow[] userPriceLibrarydrs = APP.Application.GlobalData.UserPriceLibrary.CTUserPriceLibrary.Select(sql);
        //        if (userPriceLibrarydrs.Length == 1)
        //        {
        //            BH = userPriceLibrarydrs[0]["BH"].ToString();
        //        }
        //        else
        //        {
        //            sql = string.Format("BH = '{0}' AND DWID = '{1}' AND MC = '{2}' AND DW = '{3}' AND  SCDJ = '{4}' ",
        //                drv["BH"].ToString(), drv["DWID"].ToString(),
        //                fieldName == "MC" ? value : drv["MC"].ToString(),
        //                fieldName == "DW" ? value : drv["DW"].ToString(),
        //                fieldName == "SCDJ" ? value : drv["SCDJ"].ToString());
        //            //查询修改前 工料机中的条数
        //            DataRow[] dtdrss = dt.Select(sqls);
        //            //查询修改前 用户价格库中的条数
        //            DataRow[] UserPriceLibraryUpdrs = APP.Application.GlobalData.UserPriceLibrary.CTUserPriceLibrary.Select(sql);

        //            if ((dtdrss.Length - dtdrs.Length) == 0 && UserPriceLibraryUpdrs.Length == 1)
        //            {
        //                if (APP.Application.GlobalData.UserPriceLibrary.Switchs)
        //                {
        //                    UserPriceLibraryUpdrs[0][fieldName] = drv[fieldName].ToString();
        //                }
        //                BH = drv["BH"].ToString();
        //            }
        //            else
        //            {
        //                if (APP.Application.GlobalData.UserPriceLibrary.Switchs)
        //                {
        //                    BH = APP.Application.GlobalData.UserPriceLibrary.Insert(GetCEntityQuantityUnit(drv.Row), fieldName, range);
        //                }
        //            }
        //        }
        //    }
        //    foreach (DataRow dr in dtdrs)
        //    {
        //        dr["BH"] = BH == string.Empty ? drv["BH"].ToString() : BH;
        //        dr[fieldName] = drv[fieldName].ToString();
        //    }
        //    drv["BH"] = BH == string.Empty ? drv["BH"].ToString() : BH;
        //    return BH;
        //}

        ///// <summary>
        ///// 当前实体集合中追加单个实体
        ///// </summary>
        ///// <param name="entity">要追加的实体对象</param>
        ///// <returns>追加的行的索引(当前)</returns>
        //public CEntityQuantityUnit GetCEntityQuantityUnit(DataRow row)
        //{
        //    CEntityQuantityUnit m_CEntitySubheadings = new CEntityQuantityUnit();
        //    m_CEntitySubheadings.ID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_ID]);
        //    m_CEntitySubheadings.XID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_XID]);
        //    m_CEntitySubheadings.DXID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_DXID]);
        //    m_CEntitySubheadings.DWID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_DWID]);
        //    m_CEntitySubheadings.QID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_QID]);
        //    m_CEntitySubheadings.ZID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_ZID]);
        //    m_CEntitySubheadings.ZCID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_ZCID]);
        //    m_CEntitySubheadings.ZCLB = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_ZCLB]);
        //    m_CEntitySubheadings.CJXXID = ToolKit.ParseInt(row[CEntityQuantityUnit.FILED_CJXXID]);
        //    m_CEntitySubheadings.YSBH = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_YSBH]);
        //    m_CEntitySubheadings.YSMC = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_YSMC]);
        //    m_CEntitySubheadings.YSDW = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_YSDW]);
        //    m_CEntitySubheadings.YSXHL = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_YSXHL]);
        //    m_CEntitySubheadings.DEDJ = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_DEDJ]);
        //    m_CEntitySubheadings.DEHJ = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_DEHJ]);
        //    m_CEntitySubheadings.BH = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_BH]);
        //    m_CEntitySubheadings.LB = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_LB]);
        //    m_CEntitySubheadings.SDCLB = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_SDCLB]);
        //    m_CEntitySubheadings.SDCXS = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_SDCXS]);
        //    m_CEntitySubheadings.SDCHJ = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_SDCHJ]);
        //    m_CEntitySubheadings.MC = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_MC]);
        //    m_CEntitySubheadings.GGXH = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_GGXH]);
        //    m_CEntitySubheadings.DW = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_DW]);
        //    m_CEntitySubheadings.SCDJ = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_SCDJ]);
        //    m_CEntitySubheadings.SCHJ = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_SCHJ]);
        //    m_CEntitySubheadings.XHL = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_XHL]);
        //    m_CEntitySubheadings.SL = CDataConvert.ConToValue<System.Decimal>(row[CEntityQuantityUnit.FILED_SL]);
        //    m_CEntitySubheadings.IFPB = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFPB]);
        //    m_CEntitySubheadings.IFZG = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFZG]);
        //    m_CEntitySubheadings.IFJG = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFJG]);
        //    m_CEntitySubheadings.IFYG = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFYG]);
        //    m_CEntitySubheadings.IFFX = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFFX]);
        //    m_CEntitySubheadings.IFSDSL = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFSDSL]);
        //    m_CEntitySubheadings.IFSDSCDJ = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFSDSCDJ]);
        //    m_CEntitySubheadings.IFSDGLJ = ToolKit.ParseBoolen(row[CEntityQuantityUnit.FILED_IFSDGLJ]);
        //    m_CEntitySubheadings.SSKLB = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_SSKLB]);
        //    m_CEntitySubheadings.SSXMLB = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_SSXMLB]);
        //    m_CEntitySubheadings.SSXM = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_SSXM]);
        //    m_CEntitySubheadings.GLJBZ = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_GLJBZ]);
        //    m_CEntitySubheadings.ZJCS = CDataConvert.ConToValue<System.String>(row[CEntityQuantityUnit.FILED_ZJCS]);
        //    return m_CEntitySubheadings;
        //}
    }
}
