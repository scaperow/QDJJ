using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

/*
 * 开发人员：Hisen
 * 时间：2008年11月24日
 * 功能：将数据导出Excel 
 * 
 */
namespace GOLDSOFT.QDJJ.UI
{
    public class ExcelExport
    {
        private ExcelExport()
        { }
        private static ExcelExport _instance = null;

        public static ExcelExport Instance
        {
            get
            {
                if (_instance == null) _instance = new ExcelExport();
                return _instance;
            }
        }

        /// <summary>
        /// DataTable直接导出Excel,此方法会把DataTable的数据用Excel打开,再自己手动去保存到确切的位置
        /// </summary>
        /// <param name="dt">要导出Excel的DataTable</param>
        /// <returns></returns>
        public bool DoExport(System.Data.DataTable dt)
        {
            Application app = new ApplicationClass();
            if (app == null)
            {
                throw new Exception("Excel无法启动");
            }
            app.Visible = true;
            Workbooks wbs = app.Workbooks;
            Workbook wb = wbs.Add(Missing.Value);
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            int cnt = dt.Rows.Count;
            int columncnt = dt.Columns.Count;

            // *****************获取数据********************
            object[,] objData = new Object[cnt + 1, columncnt];  // 创建缓存数据
            // 获取列标题
            for (int i = 0; i < columncnt; i++)
            {
                objData[0, i] = dt.Columns[i].ColumnName;
            }
            // 获取具体数据
            for (int i = 0; i < cnt; i++)
            {
                System.Data.DataRow dr = dt.Rows[i];
                for (int j = 0; j < columncnt; j++)
                {
                    objData[i + 1, j] = dr[j];
                }
            }

            //********************* 写入Excel******************
            Range r = ws.get_Range(app.Cells[1, 1], app.Cells[cnt + 1, columncnt]);
            r.NumberFormat = "@";
            //r = r.get_Resize(cnt+1, columncnt);
            r.Value2 = objData;
            r.EntireColumn.AutoFit();

            app = null;
            return true;
        }

        /// <summary>
        /// DataTable通过流导出Excel
        /// </summary>
        /// <param name="ds">数据源DataSet</param>
        /// <param name="columns">DataTable中列对应的列名(可以是中文),若为null则取DataTable中的字段名</param>
        /// <param name="fileName">保存文件名(例如：a.xls)</param>
        /// <returns></returns>
        public bool StreamExport(System.Data.DataTable dt, string[] columns, string fileName, System.Web.UI.Page pages)
        {
            if (dt.Rows.Count > 65535) //总行数大于Excel的行数 
            {
                throw new Exception("预导出的数据总行数大于excel的行数");
            }
            if (string.IsNullOrEmpty(fileName)) return false;

            StringBuilder content = new StringBuilder();
            StringBuilder strtitle = new StringBuilder();
            content.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>");
            content.Append("<head><title></title><meta http-equiv='Content-Type' content=\"text/html; charset=gb2312\">");
            //注意：[if gte mso 9]到[endif]之间的代码，用于显示Excel的网格线，若不想显示Excel的网格线，可以去掉此代码
            content.Append("<!--[if gte mso 9]>");
            content.Append("<xml>");
            content.Append(" <x:ExcelWorkbook>");
            content.Append("  <x:ExcelWorksheets>");
            content.Append("   <x:ExcelWorksheet>");
            content.Append("    <x:Name>Sheet1</x:Name>");
            content.Append("    <x:WorksheetOptions>");
            content.Append("      <x:Print>");
            content.Append("       <x:ValidPrinterInfo />");
            content.Append("      </x:Print>");
            content.Append("    </x:WorksheetOptions>");
            content.Append("   </x:ExcelWorksheet>");
            content.Append("  </x:ExcelWorksheets>");
            content.Append("</x:ExcelWorkbook>");
            content.Append("</xml>");
            content.Append("<![endif]-->");
            content.Append("</head><body><table style='border-collapse:collapse;table-layout:fixed;'><tr>");

            if (columns != null)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    if (columns[i] != null && columns[i] != "")
                    {
                        content.Append("<td><b>" + columns[i] + "</b></td>");
                    }
                    else
                    {
                        content.Append("<td><b>" + dt.Columns[i].ColumnName + "</b></td>");
                    }
                }
            }
            else
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    content.Append("<td><b>" + dt.Columns[j].ColumnName + "</b></td>");
                }
            }
            content.Append("</tr>\n");

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                content.Append("<tr>");
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    object obj = dt.Rows[j][k];
                    Type type = obj.GetType();
                    if (type.Name == "Int32" || type.Name == "Single" || type.Name == "Double" || type.Name == "Decimal")
                    {
                        double d = obj == DBNull.Value ? 0.0d : Convert.ToDouble(obj);
                        if (type.Name == "Int32" || (d - Math.Truncate(d) == 0))
                            content.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0'>{0}</td>", obj);
                        else
                            content.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0.00'>{0}</td>", obj);
                    }
                    else
                        content.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td>", obj);
                }
                content.Append("</tr>\n");
            }
            content.Append("</table></body></html>");
            content.Replace("&nbsp;", "");
            pages.Response.Clear();
            pages.Response.Buffer = true;
            pages.Response.ContentType = "application/ms-excel";  //"application/ms-excel";
            pages.Response.Charset = "UTF-8";
            pages.Response.ContentEncoding = System.Text.Encoding.UTF7;
            fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
            pages.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            pages.Response.Write(content.ToString());
            //pages.Response.End();  //注意，若使用此代码结束响应可能会出现“由于代码已经过优化或者本机框架位于调用堆栈之上,无法计算表达式的值。”的异常。
            HttpContext.Current.ApplicationInstance.CompleteRequest(); //用此行代码代替上一行代码，则不会出现上面所说的异常。
            return true;
        }

        /// <summary>
        /// 直接由GridView导出Excel
        /// </summary>
        /// <param name="ctl">控件(一般是GridView)</param>
        /// <param name="FileName">导出的文件名</param>
        /// <param name="removeIndexs">要移除的列的索引数组(因为有时我们并不希望把GridView中的所有列全部导出)</param>
        /// <param name="pages"></param>
        public void ControlToExcel(System.Web.UI.WebControls.GridView ctl, string FileName, string[] removeIndexs, System.Web.UI.Page pages)
        {
            if (removeIndexs != null)
            {
                foreach (string index in removeIndexs)
                {
                    ctl.Columns[int.Parse(index)].Visible = false;
                }
            }
            pages.Response.Charset = "UTF-8";
            pages.Response.ContentEncoding = System.Text.Encoding.UTF7;
            pages.Response.ContentType = "application/ms-excel";
            FileName = System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8);
            pages.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName);
            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            pages.Response.Write(tw.ToString());
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}