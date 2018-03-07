/*
    客户信息提交窗体
 *  两种模式 首次应用 变更申请
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GoldSoft.QD_api;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.UI.Client;
using GOLDSOFT.SERVICES.IServicesObject;
using GoldSoft.CICM.UI;
using ZiboSoft.Commons.Common;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using Bidserver;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BeginAnalyze2 : CBaseForm
    {
        decimal A1 = 1.0m; //<=0.01
        decimal A2 = 3.0m; // > 0.01 and <= 0.03
        decimal A3 = 5.0m; // >0.03 and <= 0.05
        decimal A4 = 10.0m; // >0.05 and <= 0.08
        decimal A5 = 15.0m; // >0.08 and <= 0.95
        decimal B = 0.0m; // >0.08 and <= 0.95
        decimal MaxA = 15.0m;
        decimal C1 = 1.0m;  // >0.8
        decimal C2 = 3.0m;  // >0.5 and <=0.8
        decimal C3 = 5.0m;  // >0.3 and <=0.5
        decimal C4 = 8.0m;  // >0.1 and <=0.3
        decimal C5 = 8.0m;  // >0.1 and <=0.3
        decimal MinC = 1.0m;
        public _Business pInfo;
        public ArrayList DataSource;
        public Container _sender;

        //private decimal A1 = 1.0m; //<=0.01
        //private decimal A2 = 3.0m; // > 0.01 and <= 0.03
        //private decimal A3 = 5.0m; // >0.03 and <= 0.05
        //private decimal A4 = 10.0m; // >0.05 and <= 0.08
        //private decimal A5 = 15.0m; // >0.08 and <= 0.95
        //private decimal B = 0.0m; // >0.08 and <= 0.95
        //private decimal MaxA = 15.0m;
        //private decimal C1 = 1.0m;  // >0.8
        //private decimal C2 = 3.0m;  // >0.5 and <=0.8
        //private decimal C3 = 5.0m;  // >0.3 and <=0.5
        //private decimal C4 = 8.0m;  // >0.1 and <=0.3
        //private decimal C5 = 8.0m;  // >0.1 and <=0.3
        //private decimal MinC = 1.0m;


        private int AXH = 0;
        private int BXH = 0;
        private int CXH = 0;

        private int TBJS = 0;

        public BeginAnalyze2()
        {
            InitializeComponent();
            //TODO:数据库中的%号应该统一设置为全角的%
            init();
        }
        void init()
        {
            //if (APP.GoldSoftClient.QDJJTB.Tables["QUHFB"] == null && APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows.Count <= 0)
            //{
            //    MsgBox.Alert("数据库表 QUHFB 设置有误!");
            //    return;
            //}
            //string[] tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["A1"].ToString().Split('～');
            //string[] dataArr;
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //A1 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["A2"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //A2 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["A3"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //A3 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["A4"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //A4 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["A5"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //A5 = decimal.Parse(dataArr[0]) / 100.0m;
            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["B"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //if(!string.IsNullOrEmpty(dataArr[0]))
            //    B = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["C1"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //C1 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["C2"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //C2 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["C3"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //C3 = decimal.Parse(dataArr[0]) / 100.0m;

            //tmpArr = APP.GoldSoftClient.QDJJTB.Tables["QUHFB"].Rows[0]["C4"].ToString().Split('～');
            //if (tmpArr.Length > 1)
            //    dataArr = tmpArr[1].Split('％');
            //else
            //    dataArr = tmpArr[0].Split('％');
            //C4 = decimal.Parse(dataArr[0]) / 100.0m;
            //C5 = decimal.Parse((tmpArr[0].Split('％'))[0]) / 100.0m;

            //MaxA = A1;
            //MaxA = MaxA >= A2 ? MaxA : A2;
            //MaxA = MaxA >= A3 ? MaxA : A3;
            //MaxA = MaxA >= A4 ? MaxA : A4;
            //MaxA = MaxA >= A5 ? MaxA : A5;

            //MinC = C1;
            //MinC = MinC < C2 ? MinC : C2;
            //MinC = MinC < C3 ? MinC : C3;
            //MinC = MinC < C4 ? MinC : C4;
            //MinC = MinC < C5 ? MinC : C5;


        }
        BeginAnalyze3 begin3 = new BeginAnalyze3();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            begin3.MdiParent = this.MdiParent;
            begin3._sender = this._sender;
            //int qdzs = APP.GoldSoftClient.A1_COUNT + APP.GoldSoftClient.A2_COUNT + APP.GoldSoftClient.A3_COUNT + APP.GoldSoftClient.A4_COUNT + APP.GoldSoftClient.A5_COUNT + APP.GoldSoftClient.B_COUNT +
            //            APP.GoldSoftClient.C1_COUNT + APP.GoldSoftClient.C2_COUNT + APP.GoldSoftClient.C3_COUNT + APP.GoldSoftClient.C4_COUNT;
            //if (!APP.GoldSoftClient.Invite_Publish)
            //    begin3.FABH = qdzs.ToString() + "," + APP.GoldSoftClient.CurrentCustom.JMLOCK + "," + APP.GoldSoftClient.XS_TableName;
            //else
            //    begin3.FABH = qdzs.ToString() + "," + APP.GoldSoftClient.CurrentCustom.JMLOCK + "|" +
            //        APP.GoldSoftClient.A1_COUNT.ToString() + "," + APP.GoldSoftClient.A1_BL.ToString() + "," + A1 + "|" +
            //        APP.GoldSoftClient.A2_COUNT.ToString() + "," + APP.GoldSoftClient.A2_BL.ToString() + "," + A2 + "|" +
            //        APP.GoldSoftClient.A3_COUNT.ToString() + "," + APP.GoldSoftClient.A3_BL.ToString() + "," + A3 + "|" +
            //        APP.GoldSoftClient.A4_COUNT.ToString() + "," + APP.GoldSoftClient.A4_BL.ToString() + "," + A4 + "|" +
            //        APP.GoldSoftClient.A5_COUNT.ToString() + "," + APP.GoldSoftClient.A5_BL.ToString() + "," + A5 + "|" +
            //        APP.GoldSoftClient.B_COUNT.ToString() + "," + APP.GoldSoftClient.B_BL.ToString() + "," + B + "|" +
            //        APP.GoldSoftClient.C4_COUNT.ToString() + "," + APP.GoldSoftClient.C4_BL.ToString() + "," + C1 + "|" +
            //        APP.GoldSoftClient.C3_COUNT.ToString() + "," + APP.GoldSoftClient.C3_BL.ToString() + "," + C2 + "|" +
            //        APP.GoldSoftClient.C2_COUNT.ToString() + "," + APP.GoldSoftClient.C2_BL.ToString() + "," + C3 + "|" +
            //        APP.GoldSoftClient.C1_COUNT.ToString() + "," + APP.GoldSoftClient.C1_BL.ToString() + "," + C4 + "|" +
            //        (APP.GoldSoftClient.A1_COUNT + APP.GoldSoftClient.A2_COUNT + APP.GoldSoftClient.A3_COUNT + APP.GoldSoftClient.A4_COUNT + APP.GoldSoftClient.A5_COUNT).ToString() + "," +
            //        (APP.GoldSoftClient.A1_BL + APP.GoldSoftClient.A2_BL + APP.GoldSoftClient.A3_BL + APP.GoldSoftClient.A4_BL + APP.GoldSoftClient.A5_BL).ToString() + "|" +
            //        APP.GoldSoftClient.B_COUNT.ToString() + "," + APP.GoldSoftClient.B_BL.ToString() + "|" +
            //        (APP.GoldSoftClient.C1_COUNT + APP.GoldSoftClient.C2_COUNT + APP.GoldSoftClient.C3_COUNT + APP.GoldSoftClient.C4_COUNT).ToString() + "," +
            //        (APP.GoldSoftClient.C1_BL + APP.GoldSoftClient.C2_BL + APP.GoldSoftClient.C3_BL + APP.GoldSoftClient.C4_BL).ToString();

            begin3.pInfo = this.pInfo;
            begin3.ShowDialog();
            this.Close();
        }

        Bid BidAgent = new Bid();

        private void BeginAnalyze2_Load(object sender, EventArgs e)
        {
            //System.Data.DataTable data = getTableData();

            //if (data == null)
            //{
            //    return;
            //}
            if (APP.GoldSoftClient.Invite_Publish)
            {
                APP.GoldSoftClient.TBJS = APP.GoldSoftClient.My_Count;
            }
            else
            {
                APP.GoldSoftClient.TBJS = APP.GoldSoftClient.My_Count - 1;
            }

            ApplicationForm pForm = this.MdiParent as ApplicationForm;
            Container form = pForm.ActiveMdiChild as Container;
            SubSegmentForm obj = form.GetWorkAreas as SubSegmentForm;


            this.Enabled = false;
            ThreadPool.QueueUserWorkItem(delegate
            {
                var map = new Dictionary<string, object>();

                map["lockID"] = APP.GoldSoftClient.CurrentCustom.JMLOCK;
                map["owners"] = APP.GoldSoftClient.TBJS;//Owners = int.Parse(map["owners"] + "");
                map["mines"] = APP.GoldSoftClient.My_Count;//Mines = int.Parse(map["mines"] + "");
                map["others"] = APP.GoldSoftClient.Other_Count;  //Others = int.Parse(map["others"] + "");
                map["totalMeasureFee"] = APP.GoldSoftClient.CSXMHJ;   //TotalMeasureFee = int.Parse(map["totalMeasureFee"] + "");
                map["totalProjectFee"] = APP.GoldSoftClient.ZZJ;    //TotalProjectFee = int.Parse(map["totalProjectFee"] + "");
                map["totalSubsegmentFee"] = APP.GoldSoftClient.FBFXHJ;     //TotalSubsegmentFee = int.Parse(map["totalSubsegmentFee"] + "");

                var projectStructTable = new System.Data.DataTable();
                var subsgemtntsTable = new System.Data.DataTable();
                foreach (DataColumn column in this.pInfo.Current.StructSource.ModelProject.Columns)
                {
                    projectStructTable.Columns.Add(column.ColumnName);
                }
                foreach (DataRow row in this.pInfo.Current.StructSource.ModelProject.Rows)
                {
                    projectStructTable.ImportRow(row);
                }

                foreach (DataColumn column in this.pInfo.Current.StructSource.ModelSubSegments.Columns)
                {
                    subsgemtntsTable.Columns.Add(column.ColumnName);
                }
                foreach (DataRow row in this.pInfo.Current.StructSource.ModelSubSegments.Rows)
                {
                    subsgemtntsTable.ImportRow(row);
                }

                map["projectStruct"] = JsonConvert.SerializeObject(projectStructTable, new DataTableConverter());  //ProjectStruct = map["projectStruct"] as DataTable;
                map["subsegments"] = JsonConvert.SerializeObject(subsgemtntsTable, new DataTableConverter());  //Subsegments = map["subsegments"] as DataTable;

                var args = JsonConvert.SerializeObject(map);
                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(BidAgent.Analyze(args)));
                var message = "";
                if (result == null)
                {
                    message = "服务器异常";
                    goto error;
                }
                else
                {
                    if (string.IsNullOrEmpty(result["error"] + "") == false)
                    {
                        message = result["error"] + "";
                        goto error;
                    }

                    APP.GoldSoftClient.XS_TableName = result["coefficient"] + "";
                    APP.GoldSoftClient.TB_RESULT = JsonConvert.DeserializeObject<System.Data.DataTable>(result["source"] + "");
                    begin3.FABH = result["id"] + "";
                    SaveExcel(APP.Cache.AppFolder + "工程文件\\备份文件\\" + obj.Activitie.Name + ".xls");
                }

                this.Invoke(new MethodInvoker(delegate
                {
                    this.Enabled = true;
                }));

                return;

            error:
                this.Invoke(new MethodInvoker(delegate
                {
                    MessageBox.Show(message);
                    this.Close();
                }));

            });
            //this.ExportExcel(APP.Cache.AppFolder + "工程文件\\备份文件\\" + obj.Activitie.Name + ".xls", data);

        }

        private void SaveExcel(string fileName)
        {
            Microsoft.Office.Interop.Excel._Application xlsApp = new ApplicationClass();
            if (xlsApp == null) return;
            Workbook xlsBook = xlsApp.Workbooks.Add(true);
            Worksheet xlSheet = (Worksheet)xlsBook.Worksheets[1];

            //Excel头

            xlSheet.Cells[1, 1] = "清单序号";
            xlSheet.Cells[1, 2] = "工程名称";
            xlSheet.Cells[1, 3] = "工程ID";
            xlSheet.Cells[1, 4] = "工程编号";
            xlSheet.Cells[1, 5] = "项目名称";
            xlSheet.Cells[1, 6] = "计量单位";
            xlSheet.Cells[1, 7] = "工程数量";
            xlSheet.Cells[1, 8] = "单价金额";
            xlSheet.Cells[1, 9] = "合价金额";

            for (int i = 0; i < APP.GoldSoftClient.TBJS; i++)
            {
                if (!APP.GoldSoftClient.Invite_Publish)
                    xlSheet.Cells[1, i + 10] = "第 " + (i + 2).ToString() + " 家";
                else
                    xlSheet.Cells[1, i + 10] = "第 " + (i + 1).ToString() + " 家";
            }

            float dj = 0.0f;
            int j;
            //if (APP.GoldSoftClient.SPACE_QY_COUNT >= int.Parse(APP.GoldSoftClient.QDJJTB.Tables["TBKZ"].Rows[0]["KBQUSL"].ToString()))
            //{
            //    MsgBox.Alert("空白区域大于设定值，不能调标！");
            //    return;
            //}
            //dv.Sort = "ZHHJ ASC";

            //数据
            for (int i = 0; i < APP.GoldSoftClient.TB_RESULT.DefaultView.Count; i++)
            {
                xlSheet.Cells[i + 2, 1] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["OLDXH"];
                xlSheet.Cells[i + 2, 2] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["GCMC"];
                xlSheet.Cells[i + 2, 3] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["GCID"];
                xlSheet.Cells[i + 2, 4] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["GCBH"];
                xlSheet.Cells[i + 2, 5] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["XMMC"];
                xlSheet.Cells[i + 2, 6] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["DW"];
                xlSheet.Cells[i + 2, 7] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["GCL"];
                xlSheet.Cells[i + 2, 8] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["ZHDJ"];
                xlSheet.Cells[i + 2, 9] = APP.GoldSoftClient.TB_RESULT.DefaultView[i]["ZHHJ"];

                for (int n = 0; n < APP.GoldSoftClient.TBJS; n++)
                {
                    xlSheet.Cells[i + 2, 10 + n] = APP.GoldSoftClient.TB_RESULT.DefaultView[i][10 + n - 1];
                }
            }

            xlsBook.Saved = true;
            xlsBook.SaveCopyAs(fileName);
        }

        /// <summary>
        /// 功能:导出Excel表格
        /// 作者:付强
        /// 日期:2013年7月9日
        /// </summary>
        /// <param name="fileName">要保存的文件路径及名称</param>
        /// <param name="reportSource">数据源</param>
        private void ExportExcel(string fileName, System.Data.DataTable tbJS)
        {
            Microsoft.Office.Interop.Excel._Application xlsApp = new ApplicationClass();
            if (xlsApp == null) return;
            Workbook xlsBook = xlsApp.Workbooks.Add(true);
            Worksheet xlSheet = (Worksheet)xlsBook.Worksheets[1];

            //Excel头

            xlSheet.Cells[1, 1] = "清单序号";
            xlSheet.Cells[1, 2] = "工程名称";
            xlSheet.Cells[1, 3] = "工程ID";
            xlSheet.Cells[1, 4] = "工程编号";
            xlSheet.Cells[1, 5] = "项目名称";
            xlSheet.Cells[1, 6] = "计量单位";
            xlSheet.Cells[1, 7] = "工程数量";
            xlSheet.Cells[1, 8] = "单价金额";
            xlSheet.Cells[1, 9] = "合价金额";

            for (int i = 0; i < APP.GoldSoftClient.TBJS; i++)
            {
                if (!APP.GoldSoftClient.Invite_Publish)
                    xlSheet.Cells[1, i + 10] = "第 " + (i + 2).ToString() + " 家";
                else
                    xlSheet.Cells[1, i + 10] = "第 " + (i + 1).ToString() + " 家";
            }

            float dj = 0.0f;
            int j;

            DataView dv = null;
            if (!APP.GoldSoftClient.Invite_Publish)
                dv = this.transformData(tbJS).DefaultView;
            else
                dv = this.transformDataPublish().DefaultView;

            APP.GoldSoftClient.TB_RESULT = dv.Table;
            if (APP.GoldSoftClient.SPACE_QY_COUNT >= int.Parse(APP.GoldSoftClient.QDJJTB.Tables["TBKZ"].Rows[0]["KBQUSL"].ToString()))
            {
                MsgBox.Alert("空白区域大于设定值，不能调标！");
                return;
            }
            if (dv == null) return;
            //dv.Sort = "ZHHJ ASC";

            //数据
            for (int i = 0; i < dv.Count; i++)
            {
                xlSheet.Cells[i + 2, 1] = dv[i]["OLDXH"];
                xlSheet.Cells[i + 2, 2] = dv[i]["GCMC"];
                xlSheet.Cells[i + 2, 3] = dv[i]["GCID"];
                xlSheet.Cells[i + 2, 4] = dv[i]["GCBH"];
                xlSheet.Cells[i + 2, 5] = dv[i]["XMMC"];
                xlSheet.Cells[i + 2, 6] = dv[i]["DW"];
                xlSheet.Cells[i + 2, 7] = dv[i]["GCL"];
                xlSheet.Cells[i + 2, 8] = dv[i]["ZHDJ"];
                xlSheet.Cells[i + 2, 9] = dv[i]["ZHHJ"];

                for (int n = 0; n < APP.GoldSoftClient.TBJS; n++)
                {
                    xlSheet.Cells[i + 2, 10 + n] = dv[i][10 + n - 1];
                }
            }

            xlsBook.Saved = true;
            xlsBook.SaveCopyAs(fileName);
        }

        private System.Data.DataTable transformData(System.Data.DataTable tbJS)
        {
            DataView dv = pInfo.Current.StructSource.ModelSubSegments.DefaultView;
            dv.Sort = "ZHHJ ASC";

            System.Data.DataTable temp = new System.Data.DataTable();
            temp.Columns.Add(new DataColumn("OLDXH"));
            temp.Columns.Add(new DataColumn("GCMC"));
            temp.Columns.Add(new DataColumn("GCID"));
            temp.Columns.Add(new DataColumn("GCBH"));
            temp.Columns.Add(new DataColumn("XMMC"));
            temp.Columns.Add(new DataColumn("DW"));
            temp.Columns.Add(new DataColumn("GCL"));
            temp.Columns.Add(new DataColumn("ZHDJ"));
            temp.Columns.Add(new DataColumn("ZHHJ"));
            for (int i = 0; i < APP.GoldSoftClient.My_Count - 1; i++)
            {
                temp.Columns.Add(new DataColumn("第 " + (i + 2).ToString() + " 家"));
            }

            DataRow newRow;
            float dj = 0.0f;
            int j = 0;
            APP.GoldSoftClient.A1_COUNT = 0;
            APP.GoldSoftClient.A2_COUNT = 0;
            APP.GoldSoftClient.A3_COUNT = 0;
            APP.GoldSoftClient.A4_COUNT = 0;
            APP.GoldSoftClient.A5_COUNT = 0;
            APP.GoldSoftClient.B_COUNT = 0;
            APP.GoldSoftClient.C1_COUNT = 0;
            APP.GoldSoftClient.C2_COUNT = 0;
            APP.GoldSoftClient.C3_COUNT = 0;
            APP.GoldSoftClient.C4_COUNT = 0;

            string gcmc = "", gcbh = "";
            DataRow[] gcRows;
            for (int i = 0; i < dv.Count; i++)
            {
                gcmc = "";
                gcbh = "";
                gcRows = pInfo.Current.StructSource.ModelProject.Select("ID = " + dv[i]["UnID"].ToString());
                if (gcRows.Length > 0)
                {
                    gcmc = gcRows[0]["Name"].ToString();
                    gcbh = gcRows[0]["Code"].ToString();
                }

                if (dv[i]["LB"].ToString().Equals("清单"))
                {
                    newRow = temp.NewRow();

                    newRow[0] = dv[i]["XH"];
                    newRow[1] = gcmc;
                    newRow[2] = dv[i]["UnID"];
                    newRow[3] = gcbh;
                    newRow[4] = dv[i]["XMMC"];
                    newRow[5] = dv[i]["DW"];
                    newRow[6] = dv[i]["GCL"];
                    newRow[7] = dv[i]["ZHDJ"];
                    newRow[8] = dv[i]["ZHHJ"];

                    dj = float.Parse(dv[i]["ZHDJ"].ToString());
                    for (int n = 0; n < APP.GoldSoftClient.My_Count - 1; n++)
                    {
                        object rate = tbJS.Rows[j][n + 1];
                        if (rate == null || rate.ToString() == "")
                        {
                            if (j > 0)
                            {
                                //（上一条的原合价金额 + 本条的原合价金额 -上一条计算后的合价金额）÷本条的工程数量
                                try
                                {
                                    newRow[9 + n] = (float.Parse(temp.Rows[temp.Rows.Count - 1]["ZHHJ"].ToString()) + float.Parse(dv[i]["ZHHJ"].ToString()) -
                                            (float.Parse(temp.Rows[temp.Rows.Count - 1][9 + n].ToString())) * float.Parse(temp.Rows[temp.Rows.Count - 1]["GCL"].ToString())) / float.Parse(dv[i]["GCL"].ToString());
                                }
                                catch (Exception)
                                {
                                    newRow[9 + n] = 0;//数据有误
                                }

                            }
                        }
                        else if (APP.GoldSoftClient.My_Count == 3 && rate.ToString().Equals("A"))
                        {
                            //（上三条的原合价金额 + 本条的原合价金额 -上三条计算后的合价金额）÷本条的工程数量
                            try
                            {
                                if (float.Parse(dv[i]["GCL"].ToString()) == 0.0f)
                                    newRow[9 + n] = 0.0f;
                                else
                                    newRow[9 + n] = (float.Parse(temp.Rows[temp.Rows.Count - 1]["ZHHJ"].ToString()) + float.Parse(temp.Rows[temp.Rows.Count - 2]["ZHHJ"].ToString()) +
                                                    float.Parse(temp.Rows[temp.Rows.Count - 3]["ZHHJ"].ToString()) + float.Parse(dv[i]["ZHHJ"].ToString()) -
                                                    float.Parse(temp.Rows[temp.Rows.Count - 1][n + 9].ToString()) * float.Parse(temp.Rows[temp.Rows.Count - 1][6].ToString()) -
                                                    float.Parse(temp.Rows[temp.Rows.Count - 2][n + 9].ToString()) * float.Parse(temp.Rows[temp.Rows.Count - 2][6].ToString()) -
                                                    float.Parse(temp.Rows[temp.Rows.Count - 3][n + 9].ToString()) * float.Parse(temp.Rows[temp.Rows.Count - 3][6].ToString())) / float.Parse(dv[i]["GCL"].ToString());
                            }
                            catch (Exception)
                            {
                                newRow[9 + n] = 0;//数据有误
                            }
                        }
                        else
                            try
                            {
                                newRow[9 + n] = dj * float.Parse(tbJS.Rows[j][n + 1].ToString());
                            }
                            catch (Exception)
                            {
                                newRow[9 + n] = 0;//数据有误
                            }
                    }
                    if (j < tbJS.Rows.Count - 1)
                        j++;
                    else
                        j = 0;

                    temp.Rows.Add(newRow);
                    APP.GoldSoftClient.A1_COUNT++;
                }
            }

            return temp;
        }

        private System.Data.DataTable transformDataPublish()
        {
            DataView dv = this.getInviteData().DefaultView;
            dv.Sort = "ZHHJ ASC";

            System.Data.DataTable temp = new System.Data.DataTable();
            temp.Columns.Add(new DataColumn("OLDXH"));
            temp.Columns.Add(new DataColumn("GCMC"));
            temp.Columns.Add(new DataColumn("GCID"));
            temp.Columns.Add(new DataColumn("GCBH"));
            temp.Columns.Add(new DataColumn("XMMC"));
            temp.Columns.Add(new DataColumn("DW"));
            temp.Columns.Add(new DataColumn("GCL"));
            temp.Columns.Add(new DataColumn("ZHDJ"));
            temp.Columns.Add(new DataColumn("ZHHJ"));

            for (int i = 0; i < APP.GoldSoftClient.My_Count; i++)
            {
                temp.Columns.Add(new DataColumn("第 " + (i + 1).ToString() + " 家"));
            }

            DataRow newRow;
            float dj = 0.0f;
            int j = 0;
            string gcmc = "", gcbh = "";
            DataRow[] gcRows;
            for (int i = 0; i < dv.Count; i++)
            {
                gcmc = "";
                gcbh = "";
                gcRows = pInfo.Current.StructSource.ModelProject.Select("ID = " + dv[i]["GCBH"].ToString());
                if (gcRows.Length > 0)
                {
                    gcmc = gcRows[0]["Name"].ToString();
                    gcbh = gcRows[0]["Code"].ToString();
                }

                //if (dv[i]["LB"].ToString().Equals("清单"))
                //{
                newRow = temp.NewRow();

                newRow[0] = dv[i]["OLDXH"];
                newRow[1] = gcmc;
                newRow[2] = dv[i]["GCBH"];
                newRow[3] = gcbh;
                newRow[4] = dv[i]["XMMC"];
                newRow[5] = dv[i]["DW"];
                newRow[6] = dv[i]["GCL"];
                newRow[7] = dv[i]["ZHDJ"];
                newRow[8] = dv[i]["ZHHJ"];

                dj = float.Parse(dv[i]["ZHDJ"].ToString());
                for (int n = 0; n < APP.GoldSoftClient.My_Count; n++)
                {

                    newRow[9 + n] = dv[i][27 + n];
                }

                if (j < APP.GoldSoftClient.My_Count)
                    j++;
                else
                    j = 0;
                temp.Rows.Add(newRow);
                //}
            }

            return temp;
        }


        private System.Data.DataTable getInviteData()
        {
            DataView dv = pInfo.Current.StructSource.ModelSubSegments.DefaultView;
            dv.Sort = "ZHHJ ASC";

            System.Data.DataTable temp = new System.Data.DataTable();
            temp.Columns.Add(new DataColumn("XH"));
            temp.Columns.Add(new DataColumn("XMBM"));
            temp.Columns.Add(new DataColumn("XMMC"));
            temp.Columns.Add(new DataColumn("DW"));
            temp.Columns.Add(new DataColumn("GCL"));
            temp.Columns.Add(new DataColumn("ZHDJ"));
            temp.Columns.Add(new DataColumn("ZHHJ"));
            temp.Columns.Add(new DataColumn("DTBL"));
            temp.Columns.Add(new DataColumn("BLLJ"));
            temp.Columns.Add(new DataColumn("QDGS1"));
            temp.Columns.Add(new DataColumn("QDGS2"));
            temp.Columns.Add(new DataColumn("QDGS3"));
            temp.Columns.Add(new DataColumn("QDGS4"));
            temp.Columns.Add(new DataColumn("QDGS5"));
            temp.Columns.Add(new DataColumn("DGZJGS1"));
            temp.Columns.Add(new DataColumn("DGZJBL1"));
            temp.Columns.Add(new DataColumn("DGZJGS2"));
            temp.Columns.Add(new DataColumn("DGZJBL2"));
            temp.Columns.Add(new DataColumn("DGZJGS3"));
            temp.Columns.Add(new DataColumn("DGZJBL3"));
            temp.Columns.Add(new DataColumn("DGZJGS4"));
            temp.Columns.Add(new DataColumn("DGZJBL4"));
            temp.Columns.Add(new DataColumn("QTGS"));
            temp.Columns.Add(new DataColumn("QTBL"));
            temp.Columns.Add(new DataColumn("QY"));
            temp.Columns.Add(new DataColumn("OLDXH"));
            temp.Columns.Add(new DataColumn("GCBH"));

            //for (int i = 0; i < APP.GoldSoftClient.My_Count - 1; i++)
            for (int i = 0; i < APP.GoldSoftClient.TBJS; i++)
            {
                temp.Columns.Add(new DataColumn("第 " + (i + 1).ToString() + " 家"));
            }


            DataRow newRow;
            decimal qdhj = 0.0m, hj = 0.0m, fbfxhj = 0.0m;
            AXH = 0;
            BXH = 0;
            CXH = 0;
            DataRow[] rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='FBFXHJ' and ID = 0");
            if (rows.Length <= 0)
            {
                MsgBox.Alert("分部分项为0,项目文件不符合调标要求!");
                return null;
                this.Close();
            }

            fbfxhj = decimal.Parse(rows[0]["value"].ToString());

            string tmpStr = "";
            int index = 0;
            APP.GoldSoftClient.A1_COUNT = 0;
            APP.GoldSoftClient.A2_COUNT = 0;
            APP.GoldSoftClient.A3_COUNT = 0;
            APP.GoldSoftClient.A4_COUNT = 0;
            APP.GoldSoftClient.A5_COUNT = 0;
            APP.GoldSoftClient.B_COUNT = 0;
            APP.GoldSoftClient.C1_COUNT = 0;
            APP.GoldSoftClient.C2_COUNT = 0;
            APP.GoldSoftClient.C3_COUNT = 0;
            APP.GoldSoftClient.C4_COUNT = 0;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["LB"].ToString().Equals("清单"))
                {
                    newRow = temp.NewRow();
                    qdhj = decimal.Parse(dv[i]["ZHHJ"].ToString());

                    newRow[0] = i + 2;
                    newRow[1] = dv[i]["XMBM"];
                    newRow[2] = dv[i]["XMMC"];
                    newRow[3] = dv[i]["DW"];
                    newRow[4] = dv[i]["GCL"];
                    newRow[5] = decimal.Parse(dv[i]["ZHDJ"].ToString());
                    newRow[6] = dv[i]["ZHHJ"];
                    newRow[7] = qdhj / APP.GoldSoftClient.ZZJ;//fbfxhj;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                    if (index <= 0)
                        newRow[8] = newRow[7];
                    else
                        newRow[8] = decimal.Parse(temp.Rows[index - 1][8].ToString()) + decimal.Parse(newRow[7].ToString());
                    newRow[25] = dv[i]["XH"];
                    newRow[26] = dv[i]["UnID"];
                    tmpStr = getQY(decimal.Parse(newRow[7].ToString()), decimal.Parse(newRow[8].ToString()));
                    if (tmpStr == "")
                    {
                        MsgBox.Alert("数据有误!");
                        return null;
                    }

                    string[] tmpArr = tmpStr.Split(',');

                    if (tmpArr[0].StartsWith("A"))
                    {
                        if (tmpArr[0].Substring(1, 1).Equals("1"))
                        {
                            newRow[9] = tmpArr[1];
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.A1_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("2"))
                        {
                            newRow[9] = 0;
                            newRow[10] = tmpArr[1];
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.A2_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("3"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = tmpArr[1];
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.A3_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("4"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = tmpArr[1];
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.A4_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("5"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = tmpArr[1];
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.A5_COUNT++;
                        }
                    }
                    else if (tmpArr[0].StartsWith("B"))
                    {
                        newRow[9] = 0;
                        newRow[10] = 0;
                        newRow[11] = 0;
                        newRow[12] = 0;
                        newRow[13] = 0;
                        newRow[14] = 0;
                        newRow[15] = 0;
                        newRow[16] = 0;
                        newRow[17] = 0;
                        newRow[18] = 0;
                        newRow[19] = 0;
                        newRow[20] = 0;
                        newRow[21] = 0;
                        newRow[22] = tmpArr[1];
                        if (i <= 0)
                            newRow[23] = newRow[7];
                        else
                            newRow[23] = decimal.Parse(temp.Rows[index - 1][23].ToString()) + decimal.Parse(newRow[7].ToString());
                        newRow[24] = tmpArr[0];
                        APP.GoldSoftClient.B_COUNT++;
                    }
                    else if (tmpArr[0].StartsWith("C"))
                    {
                        if (tmpArr[0].Substring(1, 1).Equals("1"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = tmpArr[1];
                            newRow[15] = qdhj / fbfxhj;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.C1_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("2"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = tmpArr[1];
                            newRow[17] = qdhj / fbfxhj;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.C2_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("3"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = tmpArr[1];
                            newRow[19] = qdhj / fbfxhj;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            newRow[20] = 0;
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.C3_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("4"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = tmpArr[1];
                            newRow[21] = qdhj / fbfxhj;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[0];
                            APP.GoldSoftClient.C4_COUNT++;
                        }
                        else if (tmpArr[0].Substring(1, 1).Equals("5"))
                        {
                            newRow[9] = 0;
                            newRow[10] = 0;
                            newRow[11] = 0;
                            newRow[12] = 0;
                            newRow[13] = 0;
                            newRow[14] = 0;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = 0;
                            newRow[19] = 0;
                            newRow[20] = tmpArr[0];
                            newRow[21] = 0;
                            newRow[22] = 0;
                            newRow[23] = 0;
                            newRow[24] = tmpArr[1];
                        }
                    }
                    //for (int m = 0; m < APP.GoldSoftClient.My_Count - 1; m++)
                    for (int m = 0; m < APP.GoldSoftClient.TBJS; m++)
                    {
                        newRow[27 + m] = 0;
                    }

                    temp.Rows.Add(newRow);
                    index++;
                }
            }
            //
            DataSet ds = APP.GoldSoftClient.QDJJTB;// this.getQDJJTB();

            float C1Sum = 0.0f, C2Sum = 0.0f, C3Sum = 0.0f, C4Sum = 0.0f;
            string cqy = "";
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                cqy = temp.Rows[i]["QY"].ToString();

                if (cqy.Equals("C1"))
                {
                    C1Sum += float.Parse(temp.Rows[i]["ZHHJ"].ToString());
                }
                if (cqy.Equals("C2"))
                {
                    C2Sum += float.Parse(temp.Rows[i]["ZHHJ"].ToString());
                }
                if (cqy.Equals("C3"))
                {
                    C3Sum += float.Parse(temp.Rows[i]["ZHHJ"].ToString());
                }
                if (cqy.Equals("C4"))
                {
                    C4Sum += float.Parse(temp.Rows[i]["ZHHJ"].ToString());
                }
            }

            float rate = 0.0f, xs = 0.0f, finaRate = 0.0f;
            float stepRate = (float)(APP.GoldSoftClient.CSXMHJ / APP.GoldSoftClient.ZZJ);
            bool isC3C4 = true;

            System.Data.DataTable dt = ds.Tables["CSXSB"];

            if (stepRate >= 0.01f && stepRate < 0.10f)
            {
                rate = float.Parse(dt.Rows[0]["CS0110"].ToString());
                xs = float.Parse(dt.Rows[1]["CS0110"].ToString());
            }
            else if (stepRate >= 0.10f && stepRate < 0.15f)
            {
                rate = float.Parse(dt.Rows[0]["CS1015"].ToString());
                xs = float.Parse(dt.Rows[1]["CS1015"].ToString());
            }
            else if (stepRate >= 0.15f && stepRate < 0.20f)
            {
                rate = float.Parse(dt.Rows[0]["CS1520"].ToString());
                xs = float.Parse(dt.Rows[1]["CS1520"].ToString());
            }
            else if (stepRate >= 0.20f && stepRate < 0.25f)
            {
                rate = float.Parse(dt.Rows[0]["CS2025"].ToString());
                xs = float.Parse(dt.Rows[1]["CS2025"].ToString());
            }
            else if (stepRate >= 0.25f && stepRate < 0.30f)
            {
                rate = float.Parse(dt.Rows[0]["CS2530"].ToString());
                xs = float.Parse(dt.Rows[1]["CS2530"].ToString());
            }
            else if (stepRate >= 0.30f && stepRate < 0.35f)
            {
                rate = float.Parse(dt.Rows[0]["CS3035"].ToString());
                xs = float.Parse(dt.Rows[1]["CS3035"].ToString());
            }
            else if (stepRate >= 0.35f && stepRate < 0.40f)
            {
                rate = float.Parse(dt.Rows[0]["CS3540"].ToString());
                xs = float.Parse(dt.Rows[1]["CS3540"].ToString());
            }
            else if (stepRate >= 0.40f && stepRate < 0.45f)
            {
                rate = float.Parse(dt.Rows[0]["CS4045"].ToString());
                xs = float.Parse(dt.Rows[1]["CS4045"].ToString());
            }
            rate -= 1;


            float cshjAdd = float.Parse(APP.GoldSoftClient.CSXMHJ.ToString()) * rate;

            if ((C4Sum + C3Sum) / 2 > cshjAdd)
            {
                finaRate = (C1Sum + C2Sum - cshjAdd) / (C1Sum + C2Sum) * xs;
                isC3C4 = false;
            }
            else if ((C1Sum + C2Sum) / 2 < cshjAdd)
            {
                finaRate = (C1Sum + C2Sum + C3Sum + C4Sum - cshjAdd) / (C1Sum + C2Sum + C3Sum + C4Sum) * xs;
                isC3C4 = true;
            }


            int bZhiCount = 0, suiJiCount = 0, zibCount = 0;
            string qy = "", lastQY = "";
            float dzr, wzr, R, K1, K2, K3, K4;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                qy = temp.Rows[i]["QY"].ToString();

                if (qy == null || qy.Trim().Equals(""))
                    APP.GoldSoftClient.SPACE_QY_COUNT++;
                else if (qy.Equals("A1"))
                {
                    //APP.GoldSoftClient.A1_COUNT++;
                    APP.GoldSoftClient.A1_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("A2"))
                {
                    //APP.GoldSoftClient.A2_COUNT++;
                    APP.GoldSoftClient.A2_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("A3"))
                {
                    //APP.GoldSoftClient.A3_COUNT++;
                    APP.GoldSoftClient.A3_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("A4"))
                {
                    //APP.GoldSoftClient.A4_COUNT++;
                    APP.GoldSoftClient.A4_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("A5"))
                {
                    //APP.GoldSoftClient.A5_COUNT++;
                    APP.GoldSoftClient.A5_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("B"))
                {
                    //APP.GoldSoftClient.B_COUNT++;
                    APP.GoldSoftClient.B_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("C1"))
                {
                    //APP.GoldSoftClient.C1_COUNT++;
                    APP.GoldSoftClient.C1_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("C2"))
                {
                    //APP.GoldSoftClient.C2_COUNT++;
                    APP.GoldSoftClient.C2_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("C3"))
                {
                    //APP.GoldSoftClient.C3_COUNT++;
                    APP.GoldSoftClient.C3_BL += float.Parse(temp.Rows[i][7].ToString());
                }
                else if (qy.Equals("C4"))
                {
                    //APP.GoldSoftClient.C4_COUNT++;
                    APP.GoldSoftClient.C4_BL += float.Parse(temp.Rows[i][7].ToString());
                }

                string wz = ds.Tables["QUYUZI"].Rows[0][qy].ToString();
                if (wz == null || wz.Equals("")) continue;


                //float dzr = float.Parse(ds.Tables["ZIB"].Rows[0][wz].ToString());
                //float wzr = float.Parse(ds.Tables["ZIB"].Rows[0]["WZR" + wz.Substring(3)].ToString());
                //float R = (wzr * (APP.GoldSoftClient.Other_Count + APP.GoldSoftClient.My_Count - 2) - (APP.GoldSoftClient.Other_Count - 1) * dzr - wzr) / (APP.GoldSoftClient.My_Count - 2);

                //float K1 = (R * (APP.GoldSoftClient.My_Count - 2) - wzr * 2f) / (APP.GoldSoftClient.My_Count - 2 - 2);
                //float K2 = (R * (APP.GoldSoftClient.My_Count - 2) - wzr * 0.9f) / (APP.GoldSoftClient.My_Count - 2 - 1);
                //float K3 = (R * (APP.GoldSoftClient.My_Count - 2) - wzr * 1.5f) / (APP.GoldSoftClient.My_Count - 2 - 1);
                //float K4 = R * 1.01f;
                if (!lastQY.Equals(qy))
                {
                    zibCount = 0;
                }
                if (zibCount >= ds.Tables["ZIB"].Rows.Count) zibCount = 0;
                dzr = float.Parse(ds.Tables["ZIB"].Rows[zibCount][wz].ToString());
                wzr = float.Parse(ds.Tables["ZIB"].Rows[zibCount]["WZR" + wz.Substring(3)].ToString());
                R = (wzr * (APP.GoldSoftClient.Other_Count + APP.GoldSoftClient.My_Count - 2) - (APP.GoldSoftClient.Other_Count - 1) * dzr - wzr) / (APP.GoldSoftClient.My_Count - 2);

                K1 = (R * (APP.GoldSoftClient.My_Count - 2) - wzr * 2f) / (APP.GoldSoftClient.My_Count - 2 - 2);
                K2 = (R * (APP.GoldSoftClient.My_Count - 2) - wzr * 0.9f) / (APP.GoldSoftClient.My_Count - 2 - 1);
                K3 = (R * (APP.GoldSoftClient.My_Count - 2) - wzr * 1.5f) / (APP.GoldSoftClient.My_Count - 2 - 1);


                //AZHI 一条
                DataRow[] rowA = ds.Tables["AZHI"].Select("WF like '%" + APP.GoldSoftClient.My_Count + "%'");
                //BZHI 可能多条
                DataRow[] rowB = ds.Tables["BZHI"].Select("WF like '%" + APP.GoldSoftClient.My_Count + "%'");
                DataRow[] rowK = null;
                if (APP.GoldSoftClient.Other_Count + APP.GoldSoftClient.My_Count > 5)
                {
                    rowK = ds.Tables["KZB"].Select("TJ like '%DF+WF>D%' and  QY like '%" + qy + "%' and WF = " + APP.GoldSoftClient.My_Count + " and DF = " + APP.GoldSoftClient.Other_Count);
                    K4 = R * 1.01f;
                }
                else
                {
                    rowK = ds.Tables["KZB"].Select("TJ like '%DF+WF<D%' and  QY like '%" + qy + "%' and WF = " + APP.GoldSoftClient.My_Count + " and DF = " + APP.GoldSoftClient.Other_Count);
                    K4 = R * 1.05f;
                }

                if (rowA.Length <= 0) continue;
                if (rowB.Length <= 0) continue;
                if (rowK.Length <= 0) continue;
                if (ds.Tables["SHUIJ"].Rows.Count <= 0) continue;


                float zhdj = float.Parse(temp.Rows[i]["ZHDJ"].ToString());
                float aRate = 0.0f, bRate = 0.0f, kRate = 0.0f, sjRate = 0.0f;
                //for(int n = 0; n < APP.GoldSoftClient.My_Count -1; n++)
                for (int n = 0; n < APP.GoldSoftClient.TBJS; n++)
                {


                    //A值取法 +3表示第一家不用算
                    if (rowA[0][2 + n].ToString().Equals("WZ"))
                        aRate = wzr;
                    else if (rowA[0][2 + n].ToString().Equals("K1"))
                        aRate = K1;
                    else if (rowA[0][2 + n].ToString().Equals("K2"))
                        aRate = K2;
                    else if (rowA[0][2 + n].ToString().Equals("K3"))
                        aRate = K3;
                    else if (rowA[0][2 + n].ToString().Equals("K4"))
                        aRate = K4;


                    if (suiJiCount == 0)
                    {
                        lastQY = qy;
                        bZhiCount = 0;
                    }
                    else if (!lastQY.Equals(qy))
                    {
                        suiJiCount = 0;
                    }
                    //if (suiJiCount > ds.Tables["SHUIJ"].Rows.Count -1)
                    //    suiJiCount = 0;

                    if (bZhiCount > rowB.Length - 1)
                        bZhiCount = 0;
                    try
                    {
                        bRate = float.Parse(rowB[bZhiCount][2 + n].ToString());//+3表示第一家不用算
                        kRate = float.Parse(rowK[0]["K"].ToString());
                        sjRate = float.Parse(ds.Tables["SHUIJ"].Rows[suiJiCount][1 + n].ToString());//+2表示第一家不用算

                        if (qy.StartsWith("C"))
                            if (!isC3C4 && (qy.Equals("C3") || qy.Equals("C4")))
                                temp.Rows[i][27 + n] = zhdj * aRate * bRate * kRate * sjRate;
                            else
                                temp.Rows[i][27 + n] = zhdj * aRate * bRate * kRate * sjRate * finaRate;
                        else
                            temp.Rows[i][27 + n] = zhdj * aRate * bRate * kRate * sjRate;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                suiJiCount++;
                bZhiCount++;
                zibCount++;

            }
            //B区
            float BSum = 0.0f, bQYRate = 0.0f;
            float[] ACSum = new float[APP.GoldSoftClient.TBJS];
            //int m = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                qy = temp.Rows[i]["QY"].ToString();
                if (qy.Equals("B"))
                {
                    BSum += float.Parse(temp.Rows[i]["ZHHJ"].ToString());
                }
                for (int n = 0; n < APP.GoldSoftClient.TBJS; n++)
                {
                    if (qy.StartsWith("A") || qy.StartsWith("C"))
                    {
                        ACSum[n] += float.Parse(temp.Rows[i][27 + n].ToString()) * float.Parse(temp.Rows[i]["GCL"].ToString());
                    }
                }
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {

                for (int n = 0; n < APP.GoldSoftClient.TBJS; n++)
                {
                    bQYRate = (float.Parse(APP.GoldSoftClient.ZZJ.ToString()) - (cshjAdd + float.Parse(APP.GoldSoftClient.CSXMHJ.ToString())) - (ACSum[n])) / BSum;
                    if (temp.Rows[i]["QY"].ToString().Equals("B"))
                    {
                        temp.Rows[i][27 + n] = float.Parse(temp.Rows[i]["ZHDJ"].ToString()) * bQYRate * float.Parse(ds.Tables["BQXSB"].Rows[0][1 + n].ToString());
                    }
                }

            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bl">单条比例</param>
        /// <returns></returns>
        private string getQY(decimal dgbl, decimal hjbl)
        {
            if (hjbl <= MaxA)
            {
                if (hjbl <= A1)
                    return "A1," + (++AXH);
                else if (hjbl > A1 && hjbl <= A2)
                    return "A2," + (++AXH);
                else if (hjbl > A2 && hjbl <= A3)
                    return "A3," + (++AXH);
                else if (hjbl > A3 && hjbl <= A4)
                    return "A4," + (++AXH);
                else if (hjbl > A4 && hjbl <= A5)
                    return "A5," + (++AXH);
            }
            else if (dgbl >= MinC)
            {
                if (dgbl > C1)
                    return "C1," + (++CXH);
                else if (dgbl > C3 && dgbl <= C2)
                    return "C2," + (++CXH);
                else if (dgbl > C4 && dgbl < C3)
                    return "C3," + (++CXH);
                else if (dgbl > C5 && dgbl < C4)
                    return "C4," + (++CXH);
            }
            else
                return "B," + (++BXH);

            return "";
        }

        private System.Data.DataTable getTableData()
        {
            string tableName = "";
            if (APP.GoldSoftClient.QDJJTB != null && APP.GoldSoftClient.QDJJTB.Tables.Count > 0)
            {
                DataRow[] rows = APP.GoldSoftClient.QDJJTB.Tables["TBCSB"].Select("TBJS like '" + APP.GoldSoftClient.My_Count.ToString() + "'");
                if (rows.Length > 0)
                {
                    tableName = rows[0]["TABLENAME"].ToString();
                    APP.GoldSoftClient.XS_TableName = tableName;
                    return APP.GoldSoftClient.QDJJTB.Tables[tableName];
                }
                else
                {
                    MsgBox.Alert("数据有误！请调整调标数据库 表 TBCSB！");
                    return null;
                }
            }
            else
            {
                MsgBox.Alert("获取服务器数据失败,请重试！");
                return null;
            }
        }
    }
}