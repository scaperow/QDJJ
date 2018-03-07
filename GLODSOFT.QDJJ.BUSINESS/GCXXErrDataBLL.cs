using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GoldSoft.CICM.UI;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class GCXXErrDataBLL
    {
       
        #region  提交清单库 错误信息
        /// <summary>
        /// 提交清单库 错误信息
        /// </summary>
        /// <returns></returns>
        public static bool insertGCXXErr(string wb_web, CEntityGCXXErrData cEntityGCXXErrData)
        {
            DataTable dt = getTab(cEntityGCXXErrData);

            return WebServiceHelper.InvokeMethod<bool>(wb_web, "insertGCXXErr", dt);
        }
        

        private static DataTable getTab(CEntityGCXXErrData cEntityGCXXErrData)
        {
            createTable();

            DataRow dr = GCXXErrDataBLL.dt.NewRow();
            dr["id"] = cEntityGCXXErrData.Id;
            dr["JDName"] = cEntityGCXXErrData.JDName;
            dr["ColContrnts"] = cEntityGCXXErrData.ColContrnts;
            dr["Contents"] = cEntityGCXXErrData.Contents;
            dr["AddTime"] = cEntityGCXXErrData.AddTime;
            dr["ResultsState"] = cEntityGCXXErrData.ResultsState;
            dr["Results"] = cEntityGCXXErrData.Results;
            dr["IsLOCK"] = cEntityGCXXErrData.IsLOCK;
            dr["InterLock"] = cEntityGCXXErrData.InterLock;

            dt.Rows.Add(dr);
            return dt;
            
        }
        private static DataTable dt = null;
        private static void createTable()
        {
            dt = new DataTable();
            dt.TableName = "GCXXErrData";
            dt.Columns.Add("id", typeof(System.Int64));
            dt.Columns.Add("JDName", typeof(System.String));
            dt.Columns.Add("ColContrnts", typeof(System.String));
            dt.Columns.Add("Contents", typeof(System.String));
            dt.Columns.Add("AddTime", typeof(System.String));
            dt.Columns.Add("ResultsState", typeof(System.Int64));
            dt.Columns.Add("Results", typeof(System.String));
            dt.Columns.Add("IsLOCK", typeof(System.Int64));
            dt.Columns.Add("InterLock", typeof(System.String));

        }

        #endregion
    }
}
