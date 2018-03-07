using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Collections;
using DevExpress.XtraPrinting;
using System.ServiceProcess;
using GOLDSOFT.QDJJ.COMMONS;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.ApplicationClass;
using System.Reflection;
namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class ReportControl : XtraUserControl
    {
        public object m_reportData;
        public XtraReport m_report;
        public ReportControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 单一报表绑定
        /// </summary>
        /// 
        /// <param name="p_Report"></param>
        public void SetDataSource(XtraReport p_Report)
        {
            this.m_report = p_Report;
            this.printControl1.PrintingSystem.ClearContent();
            p_Report.PrintingSystem = this.printControl1.PrintingSystem;
            p_Report.CreateDocument();
        }

        /// <summary>
        /// 批量报表绑定
        /// </summary>
        /// <param name="p_Report"></param>
        public void SetDataSources(XtraReport p_Report)
        {
            this.m_report = p_Report;
            p_Report.CreateDocument();
            DevExpress.XtraPrinting.Page[] page = p_Report.Pages.ToArray();
            this.printControl1.PrintingSystem.Pages.AddRange(page);

        }

        private bool ServiceIsExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        private void printPreviewBarItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ServiceIsExisted("Spooler"))
                {
                    ServiceController service = new ServiceController("Spooler");
                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        DialogResult dr = MessageBox.Show("服务未启动，是否开启", "提示信息", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            service.Start();
                            this.printingSystem1.PrintDlg();
                        }
                    }
                    else
                    {
                        this.printingSystem1.PrintDlg();
                    }
                }
                else
                {
                    MessageBox.Show("找不到服务", "提示信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息");
            }
        }
        /// <summary>
        /// 功能:响应导出Excel文件事件
        /// 作者:付强
        /// 日期:2013年7月9日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreviewBarCheckItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = this.m_reportData.ToString();

            if (e.Item.Name.Equals(this.printPreviewBarCheckItem13.Name))
            {
                sfd.Filter = "Excel 2003文件(*.xls)|*.xls";
            }
            else
            {
                sfd.Filter = "Excel 2007文件(*.xlsx)|*.xlsx";
            }
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString();
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                try
                {
                    TableReport tReport = this.m_reportData as TableReport;
                    if (tReport != null)
                    {
                        ExportExcel(localFilePath, tReport);
                    }
                    else
                    {
                        if (localFilePath.EndsWith(".xls"))
                            this.m_report.ExportToXls(localFilePath);
                        else
                            this.m_report.ExportToXlsx(localFilePath);

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("发生未知异常，请重试", "金建软件");
                }

                /*PageReport pReport = this.m_reportData as PageReport;
                if (pReport != null)
                {
                    ExportExcel(localFilePath, pReport);
                }

                ExplainReport eReport = this.m_reportData as ExplainReport;
                if (eReport != null)
                {
                    ExportExcel(localFilePath, eReport);
                }*/

            }
        }

        /// <summary>
        /// 功能:导出Excel表格
        /// 作者:付强
        /// 日期:2013年7月9日
        /// </summary>
        /// <param name="fileName">要保存的文件路径及名称</param>
        /// <param name="reportSource">数据源</param>
        private void ExportExcel(string fileName, TableReport reportSource)
        {
            Microsoft.Office.Interop.Excel._Application xlsApp = new ApplicationClass();
            if (xlsApp == null) return;
            Workbook xlsBook = xlsApp.Workbooks.Add(true);
            Worksheet xlSheet = (Worksheet)xlsBook.Worksheets[1];

            xlSheet.Cells[1, 1] = reportSource.ReportName;
            Range range = xlSheet.get_Range(xlsApp.Cells[1, 1], xlsApp.Cells[1, reportSource.ReportFields.Length]);
            range.MergeCells = true;
            range.Font.Size = 24;
            range.Font.Bold = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            if (!string.IsNullOrEmpty(reportSource.XMMC))
            {
                xlSheet.Cells[2, 1] = "项目名称:" + reportSource.XMMC;
                range = xlSheet.get_Range(xlsApp.Cells[2, 1], xlsApp.Cells[2, 2]);
                range.MergeCells = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            }
            if (!string.IsNullOrEmpty(reportSource.ZYMC))
            {
                xlSheet.Cells[2, 3] = "专业名称:" + reportSource.ZYMC;

                range = xlSheet.get_Range(xlsApp.Cells[2, 3], xlsApp.Cells[2, reportSource.ReportFields.Length]);
                range.MergeCells = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;
            }


            System.Data.DataTable dt = reportSource.DataSource as System.Data.DataTable;

            int rowSpan = 3, colSpan = 0, position = 0;
            string band = "";

            for (int i = 0; i < reportSource.ReportFields.Length; i++)
            {
                FieldReport item = reportSource.ReportFields[i];
                if (item.Bands.Equals(string.Empty))
                {
                    //xlSheet.Cells[rowSpan + 1, i + 1] = item.Caption;
                    range = xlSheet.get_Range(xlsApp.Cells[rowSpan, i + 1], xlsApp.Cells[rowSpan + 1, i + 1]);
                    range.Borders.LineStyle = XlLineStyle.xlContinuous;
                    range.MergeCells = true;
                    xlSheet.Cells[rowSpan, i + 1] = item.Caption;
                    range.Font.Bold = true;
                    range.Borders.LineStyle = XlLineStyle.xlContinuous;
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    range.ColumnWidth = item.RowWidth / 15; 

                    position += 1;
                    colSpan = 0;
                }
                else
                {
                    if (!band.Equals(item.Bands))
                    {
                        position += colSpan;
                        colSpan = 0;
                    }

                    //xlSheet.Cells[rowSpan, i + 1] = item.Bands;
                    range = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[rowSpan, i + 1];
                    range.Font.Bold = true;
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    range = xlSheet.get_Range(xlsApp.Cells[rowSpan, position + 1], xlsApp.Cells[rowSpan, position + 1 + colSpan]);
                    range.MergeCells = true;
                    xlSheet.Cells[rowSpan, position + 1] = item.Bands;

                    range.Borders.LineStyle = XlLineStyle.xlContinuous;
                    range.EntireColumn.AutoFit();
                    xlSheet.Cells[rowSpan + 1, i + 1] = item.Caption;
                    range = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[rowSpan + 1, i + 1];
                    range.Font.Bold = true;
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    range.Borders.LineStyle = XlLineStyle.xlContinuous;
                    range.ColumnWidth = item.RowWidth / 15;

                    colSpan++;
                    band = item.Bands;
                }
            }

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                if (reportSource.ReportFields.Length >= dt.Columns.Count)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName.Equals("XMBM"))
                        {
                            xlSheet.Cells[r + 5, i + 1] = "'" + dt.Rows[r][i].ToString();

                        }
                        else
                        {
                            xlSheet.Cells[r + 5, i + 1] = dt.Rows[r][i].ToString();
                        }
                        range = xlSheet.get_Range(xlsApp.Cells[r + 5, i + 1], xlsApp.Cells[r + 5, i + 1]);
                        range.Borders.LineStyle = XlLineStyle.xlContinuous;
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Columns.Count - (dt.Columns.Count - reportSource.ReportFields.Length); i++)
                    {
                        xlSheet.Cells[r + 5, i + 1] = dt.Rows[r][i].ToString();
                        range = xlSheet.get_Range(xlsApp.Cells[r + 5, i + 1], xlsApp.Cells[r + 5, i + 1]);
                        range.Borders.LineStyle = XlLineStyle.xlContinuous;
                    }
                }
            }
            xlsBook.Saved = true;
            xlsBook.SaveCopyAs(fileName);
        }
        /// <summary>
        /// 功能:导出Excel非表格
        /// 作者:付强
        /// 日期:2013年7月9日
        /// </summary>
        /// <param name="fileName">要保存的文件路径及名称</param>
        /// <param name="reportSource">数据源</param>
        private void ExportExcel(string fileName, PageReport reportSource)
        {
            Microsoft.Office.Interop.Excel._Application xlsApp = new ApplicationClass();
            if (xlsApp == null) return;
            Workbook xlsBook = xlsApp.Workbooks.Add(true);
            Worksheet xlSheet = (Worksheet)xlsBook.Worksheets[1];

            xlSheet.Cells[1, 1] = reportSource.ReportName;
            Range range = xlSheet.get_Range(xlsApp.Cells[1, 1], xlsApp.Cells[1, 11]);
            range.MergeCells = true;
            range.Font.Size = 24;
            range.Font.Bold = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            for (int i = 0; i < reportSource.RowReports.Length; i++)
            {
                RowReport item = reportSource.RowReports[i] as RowReport;
                if (!string.IsNullOrEmpty(item.Field))
                {
                    xlSheet.Cells[(i + 1) * 2, 1] = reportSource.RowReports[i].ToString();
                    range = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[i + 2, 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                    range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    range.Borders.LineStyle = XlLineStyle.xlLineStyleNone;

                    range = xlSheet.get_Range(xlsApp.Cells[(i + 1) * 2, 1], xlsApp.Cells[(i + 2) * 2 - 1, 1]);
                    range.MergeCells = true;

                    range = xlSheet.get_Range(xlsApp.Cells[i + 2, 2], xlsApp.Cells[i + 2, 11]);
                    range.MergeCells = true;
                    range.Font.Underline = true;

                    range = xlSheet.get_Range(xlsApp.Cells[(i + 1) * 2, 2], xlsApp.Cells[(i + 2) * 2 - 1, 11]);
                    range.MergeCells = true;
                    range.Font.Underline = true;

                    if (!string.IsNullOrEmpty(item.RightContent))
                    {
                        xlSheet.Cells[(i + 1) * 2, 12] = item.RightContent;

                        range = xlSheet.get_Range(xlsApp.Cells[(i + 1) * 2, 12], xlsApp.Cells[(i + 2) * 2 - 1, 13]);
                        range.HorizontalAlignment = item.ContentAlignment;
                    }
                }

            }

            xlsBook.Saved = true;
            xlsBook.SaveCopyAs(fileName);

        }

        private void ExportExcel(string fileName, ExplainReport reportSource)
        {

        }

    }
}
