using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
   public class _Modify_Method
    {
       /// <summary>
       /// 分部分项编辑之后的撤销
       /// </summary>
       public static void Edit_Sub(string filedName,_Methods met,DataRow row)
       {

           switch (filedName)
           {
               case _ObjectInfo.FILED_GCL:
                   met.UpGCL();
                   break;
               case "HL":
                   met.UpHL();
                   break;
               case "ZJTJ":
                   met.UpZJTJ();
                   break;
               case _ObjectInfo.FILED_GCLJSS:
                   met.Current.TYGS = string.Empty;
                   row["GCL"] = ToolKit.Calculate(row["GCLJSS"].ToString());
                   _ObjectSource.GetObject(met.Current, row);
                   met.UpGCL();
                   break;
               default:
                   break;
           }
       }

       public static void ModifyEdit_Sub(ModifyAttribute att, _Business bus, _UnitProject unit)
       {
           
           DataRow r = att.Source as DataRow;
           if (r != null)
           {
               if (r["LB"].ToString().Contains("子目") && att.FieldName == "GCL")
               {
                   decimal w = 0m;
                   int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["工程量输入方式"]);
                   if (m > 0)
                   {
                       w = _Methods.GetNumber(r["DW"].ToString());
                   }

                   if (w == 0) w = 1;
                   r["GCL"] = ToolKit.ParseDecimal((ToolKit.ParseDecimal(att.OriginalValue) * w).ToString("F4"));

               }
               else
               {
                   r[att.FieldName] = att.OriginalValue;
               }
               _Entity_SubInfo info = new _Entity_SubInfo();
               _ObjectSource.GetObject(info, att.Source as DataRow);
               GLODSOFT.QDJJ.BUSINESS._Methods met = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(bus, unit, info);
               _Modify_Method.Edit_Sub(att.FieldName, met, r);
           }
       }

       public static void ModifyEdit_Mea(ModifyAttribute att, _Business bus, _UnitProject unit)
       {

           DataRow r = att.Source as DataRow;
           if (r != null)
           {
               if (r["LB"].ToString().Contains("子目") && att.FieldName == "GCL")
               {
                   decimal w = 0m;
                   int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["工程量输入方式"]);
                   if (m > 0)
                   {
                       w = _Methods.GetNumber(r["DW"].ToString());
                   }

                   if (w == 0) w = 1;
                   r["GCL"] = ToolKit.ParseDecimal((ToolKit.ParseDecimal(att.OriginalValue) * w).ToString("F4"));

               }
               else
               {
                   r[att.FieldName] = att.OriginalValue;
               }
               
               GLODSOFT.QDJJ.BUSINESS._Methods met = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntaceMet(bus, unit, r);
               switch (att.FieldName)
               {
                   case "JSJC":
                   case "FL":
                       met.Begin(null);
                       break;
                   case "GCL":
                       met.UpGCL();
                       break;
                   default:
                       break;
               }
           }
       }

       public static void ModifyEdit_Other(ModifyAttribute att, _Business bus, _UnitProject unit)
       {
           DataRow r = att.Source as DataRow;
           if (r != null)
           {
                   r[att.FieldName] = att.OriginalValue;
                   if (att.FieldName == "Feature")
                   {
                       DataTable ParamTable = APP.Application.Global.DataTamp.TempDataSet.Tables["Params_Other"].Copy();
                       DataRow[] rows = ParamTable.Select(string.Format("Code='{0}'", att.OriginalValue));
                       if (rows.Length > 0)
                       {
                           r["Name"] = rows[0]["Name"];
                       }
                   }
                   _Method_OtherProject Method = new _Method_OtherProject(bus, unit);
                   Method.Begin();
           }
       }

       public static void ModifyEdit_Metaanalysis(ModifyAttribute att, _Business bus, _UnitProject unit)
       {
           DataRow r = att.Source as DataRow;
           if (r != null)
           {
               r[att.FieldName] = att.OriginalValue;
               if (att.FieldName == "Feature")
               {
                   DataTable ParamTable = APP.Application.Global.DataTamp.TempDataSet.Tables["Params_Metaanalysis"].Copy();
                   DataRow[] rows = ParamTable.Select(string.Format("Code='{0}'", att.OriginalValue));
                   if (rows.Length > 0)
                   {
                       r["Name"] = rows[0]["Name"];
                   }
               }
               _Method_Metaanalysis Method = new _Method_Metaanalysis(unit);
               Method.Begin(null);
           }
       }
    }
}
