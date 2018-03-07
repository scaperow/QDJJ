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
using Microsoft.Office.Interop.Excel;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BeginAnalyze1 : CBaseForm
    {
        public _Business pInfo;
        public ArrayList DataSource;
        public Container _sender;
        public Dictionary<string, object> CheckResult;
        public BeginAnalyze1(Dictionary<string,object> checkResult)
        {
            InitializeComponent();
            CheckResult = checkResult;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var mineCost = 0;
            this.lblName.Text = APP.GoldSoftClient.CurrentCustom.CUSTOMERNAME;
            string wb_web = CSystem.GetAppConfig("wb");
            try
            {
                mineCost = WebServiceHelper.InvokeMethod<int>(wb_web, "getJiFenJL", APP.GoldSoftClient.CurrentCustom.JMLOCK);
            }
            catch (Exception)
            {
                MsgBox.Alert("获取积分失败，请重试");
                return;
            }

            if (mineCost < APP.GoldSoftClient.KCJF)
            {
                //MsgBox.Alert("您的积分不够，不能进行调标操作！请购买积分后，再试！");
                MessageBox.Show("您的积分不够，不能进行调标操作！请购买积分后，再试！");
                this.Close();
                return;
            }

            BeginAnalyze2 begin2 = new BeginAnalyze2();
            begin2.MdiParent = this.MdiParent;
            begin2.pInfo = this.pInfo;
            begin2.DataSource = this.DataSource;
            begin2._sender = this._sender;
            begin2.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// 功能:导出Excel表格
        /// 作者:付强
        /// 日期:2013年7月9日
        /// </summary>
        /// <param name="fileName">要保存的文件路径及名称</param>
        /// <param name="reportSource">数据源</param>
        //private void ExportExcel(string fileName)
        //{
        //    Microsoft.Office.Interop.Excel._Application xlsApp = new ApplicationClass();
        //    if (xlsApp == null) return;
        //    Workbook xlsBook = xlsApp.Workbooks.Add(true);
        //    Worksheet xlSheet = (Worksheet)xlsBook.Worksheets[1];

        //    //Excel头

        //    xlSheet.Cells[1, 1] = "序号";
        //    xlSheet.Cells[1, 2] = "项目编码";
        //    xlSheet.Cells[1, 3] = "项目名称";
        //    xlSheet.Cells[1, 4] = "计量单位";
        //    xlSheet.Cells[1, 5] = "工程数量";
        //    xlSheet.Cells[1, 6] = "单价";
        //    xlSheet.Cells[1, 7] = "合价";
        //    xlSheet.Cells[1, 8] = "单条清单占造价比例";
        //    xlSheet.Cells[1, 9] = "清单累计占造价比例";
        //    xlSheet.Cells[1, 10] = "小于1％清单个数";
        //    xlSheet.Cells[1, 11] = "1％～2％清单个数";
        //    xlSheet.Cells[1, 12] = "2％～4％清单个数";
        //    xlSheet.Cells[1, 13] = "4％～10％清单个数";
        //    xlSheet.Cells[1, 14] = "10％～14％清单个数";
        //    xlSheet.Cells[1, 15] = "单个造价1％～1.5％总个数";
        //    xlSheet.Cells[1, 16] = "单个造价在1％～1.5％占总价比例";
        //    xlSheet.Cells[1, 17] = "单个造价大于1.5％～2％总个数";
        //    xlSheet.Cells[1, 18] = "单个造价在1.5％～2％占总价比例";
        //    xlSheet.Cells[1, 19] = "单个造价大于2％～4%总个数";
        //    xlSheet.Cells[1, 20] = "单个造价在2％～4％占总价比例";
        //    xlSheet.Cells[1, 21] = "单个造价大于4％总个数";
        //    xlSheet.Cells[1, 22] = "单个造价大于4％占总价比例";
        //    xlSheet.Cells[1, 23] = "其他区域个数";
        //    xlSheet.Cells[1, 24] = "其他区域占造价比例";
        //    xlSheet.Cells[1, 25] = "区值";
        //    xlSheet.Cells[1, 26] = "原清单序号";
        //    xlSheet.Cells[1, 27] = "工程ID";

        //    DataView dv = this.transformData().DefaultView;
        //    if (dv == null) return;
        //    dv.Sort = "ZHHJ ASC";

        //    //数据
        //    for (int i = 0; i < dv.Table.Rows.Count; i++)
        //    {
        //        xlSheet.Cells[i + 2, 1] = i + 1;
        //        xlSheet.Cells[i + 2, 2] = dv.Table.Rows[i]["XMBM"];
        //        xlSheet.Cells[i + 2, 3] = dv.Table.Rows[i]["XMMC"];
        //        xlSheet.Cells[i + 2, 4] = dv.Table.Rows[i]["DW"];
        //        xlSheet.Cells[i + 2, 5] = dv.Table.Rows[i]["GCL"];
        //        xlSheet.Cells[i + 2, 6] = dv.Table.Rows[i]["ZHDJ"];
        //        xlSheet.Cells[i + 2, 7] = dv.Table.Rows[i]["ZHHJ"];
        //        xlSheet.Cells[i + 2, 8] = dv.Table.Rows[i]["DTBL"];
        //        xlSheet.Cells[i + 2, 9] = dv.Table.Rows[i]["BLLJ"];
        //        xlSheet.Cells[i + 2, 10] = dv.Table.Rows[i]["QDGS1"];
        //        xlSheet.Cells[i + 2, 11] = dv.Table.Rows[i]["QDGS2"];
        //        xlSheet.Cells[i + 2, 12] = dv.Table.Rows[i]["QDGS3"];
        //        xlSheet.Cells[i + 2, 13] = dv.Table.Rows[i]["QDGS4"];
        //        xlSheet.Cells[i + 2, 14] = dv.Table.Rows[i]["QDGS5"];
        //        xlSheet.Cells[i + 2, 15] = dv.Table.Rows[i]["DGZJGS1"];
        //        xlSheet.Cells[i + 2, 16] = dv.Table.Rows[i]["DGZJBL1"];
        //        xlSheet.Cells[i + 2, 17] = dv.Table.Rows[i]["DGZJGS2"];
        //        xlSheet.Cells[i + 2, 18] = dv.Table.Rows[i]["DGZJBL2"];
        //        xlSheet.Cells[i + 2, 19] = dv.Table.Rows[i]["DGZJGS3"];
        //        xlSheet.Cells[i + 2, 20] = dv.Table.Rows[i]["DGZJBL3"];
        //        xlSheet.Cells[i + 2, 21] = dv.Table.Rows[i]["DGZJGS4"];
        //        xlSheet.Cells[i + 2, 22] = dv.Table.Rows[i]["DGZJBL4"];
        //        xlSheet.Cells[i + 2, 23] = dv.Table.Rows[i]["QTGS"];
        //        xlSheet.Cells[i + 2, 24] = dv.Table.Rows[i]["QTBL"];
        //        xlSheet.Cells[i + 2, 25] = dv.Table.Rows[i]["QY"];
        //        xlSheet.Cells[i + 2, 26] = dv.Table.Rows[i]["OLDXH"];
        //        xlSheet.Cells[i + 2, 27] = dv.Table.Rows[i]["GCBH"];

        //    }
           
        //    xlsBook.Saved = true;
        //    xlsBook.SaveCopyAs(fileName);
        //}

        //private System.Data.DataTable transformData()
        //{
        //    DataView dv = pInfo.Current.StructSource.ModelSubSegments.DefaultView;
        //    dv.Sort = "ZHHJ ASC";

        //    System.Data.DataTable temp = new System.Data.DataTable();
        //    temp.Columns.Add(new DataColumn("XH"));
        //    temp.Columns.Add(new DataColumn("XMBM"));
        //    temp.Columns.Add(new DataColumn("XMMC"));
        //    temp.Columns.Add(new DataColumn("DW"));
        //    temp.Columns.Add(new DataColumn("GCL"));
        //    temp.Columns.Add(new DataColumn("ZHDJ"));
        //    temp.Columns.Add(new DataColumn("ZHHJ"));
        //    temp.Columns.Add(new DataColumn("DTBL"));
        //    temp.Columns.Add(new DataColumn("BLLJ"));
        //    temp.Columns.Add(new DataColumn("QDGS1"));
        //    temp.Columns.Add(new DataColumn("QDGS2"));
        //    temp.Columns.Add(new DataColumn("QDGS3"));
        //    temp.Columns.Add(new DataColumn("QDGS4"));
        //    temp.Columns.Add(new DataColumn("QDGS5"));
        //    temp.Columns.Add(new DataColumn("DGZJGS1"));
        //    temp.Columns.Add(new DataColumn("DGZJBL1"));
        //    temp.Columns.Add(new DataColumn("DGZJGS2"));
        //    temp.Columns.Add(new DataColumn("DGZJBL2"));
        //    temp.Columns.Add(new DataColumn("DGZJGS3"));
        //    temp.Columns.Add(new DataColumn("DGZJBL3"));
        //    temp.Columns.Add(new DataColumn("DGZJGS4"));
        //    temp.Columns.Add(new DataColumn("DGZJBL4"));
        //    temp.Columns.Add(new DataColumn("QTGS"));
        //    temp.Columns.Add(new DataColumn("QTBL"));
        //    temp.Columns.Add(new DataColumn("QY"));
        //    temp.Columns.Add(new DataColumn("OLDXH"));
        //    temp.Columns.Add(new DataColumn("GCBH"));


        //    DataRow newRow;
        //    float qdhj = 0.0f, hj = 0.0f, fbfxhj = 0.0f;
        //    DataRow[] rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='FBFXHJ' and ID = 0");
        //    if (rows.Length <= 0)
        //    {
        //        MsgBox.Alert("分部分项合计为0！项目文件不符合调标要求！");
        //        this.Close();
        //        return null;
        //    }

        //    fbfxhj = float.Parse(rows[0]["value"].ToString());            

        //    string tmpStr = "";
        //    int index = 0;

        //    for (int i = 0; i < dv.Count; i++)
        //    {
        //        if (dv[i]["LB"].ToString().Equals("清单"))
        //        {
        //            newRow = temp.NewRow();
        //            qdhj = float.Parse(dv[i]["ZHHJ"].ToString());

        //            newRow[0] = i + 2;
        //            newRow[1] = dv[i]["XMBM"];
        //            newRow[2] = dv[i]["XMMC"];
        //            newRow[3] = dv[i]["DW"];
        //            newRow[4] = dv[i]["GCL"];
        //            newRow[5] = dv[i]["ZHDJ"];
        //            newRow[6] = dv[i]["ZHHJ"];
        //            newRow[7] = qdhj / fbfxhj * 100;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
        //            if (index <= 0)
        //                newRow[8] = newRow[7];
        //            else
        //                newRow[8] = float.Parse(temp.Rows[index - 1][8].ToString()) + float.Parse(newRow[7].ToString());
        //            newRow[25] = dv[i]["XH"];
        //            newRow[26] = dv[i]["UnID"];
        //            tmpStr = getQY(float.Parse(newRow[7].ToString()), float.Parse(newRow[8].ToString()));
        //            if (tmpStr == "")
        //            {
        //                MsgBox.Alert("数据有误!");
        //                return null;
        //            }

        //            string[] tmpArr = tmpStr.Split(',');

        //            if (tmpArr[0].StartsWith("A"))
        //            {
        //                if (tmpArr[0].Substring(1, 1).Equals("1"))
        //                {
        //                    newRow[9] = tmpArr[1];
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.A1_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("2"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = tmpArr[1];
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.A2_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("3"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = tmpArr[1];
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.A3_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("4"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = tmpArr[1];
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.A4_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("5"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = tmpArr[1];
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.A5_COUNT++;
        //                }

        //            }
        //            else if (tmpArr[0].StartsWith("B"))
        //            {
        //                newRow[9] = 0;
        //                newRow[10] = 0;
        //                newRow[11] = 0;
        //                newRow[12] = 0;
        //                newRow[13] = 0;
        //                newRow[14] = 0;
        //                newRow[15] = 0;
        //                newRow[16] = 0;
        //                newRow[17] = 0;
        //                newRow[18] = 0;
        //                newRow[19] = 0;
        //                newRow[20] = 0;
        //                newRow[21] = 0;
        //                newRow[22] = tmpArr[1];
        //                if(i <= 0)
        //                    newRow[23] = newRow[7];
        //                else
        //                    newRow[23] = float.Parse(temp.Rows[index - 1][23].ToString()) + float.Parse(newRow[7].ToString());
        //                newRow[24] = tmpArr[0];
        //                APP.GoldSoftClient.B_COUNT++;
        //            }
        //            else if(tmpArr[0].StartsWith("C"))
        //            {
        //                if (tmpArr[0].Substring(1, 1).Equals("1"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = tmpArr[1];
        //                    newRow[15] = qdhj / fbfxhj * 100;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.C1_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("2"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = tmpArr[1];
        //                    newRow[17] = qdhj / fbfxhj * 100;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.C2_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("3"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = tmpArr[1];
        //                    newRow[19] = qdhj / fbfxhj * 100;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
        //                    newRow[20] = 0;
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.C3_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("4"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = tmpArr[1];
        //                    newRow[21] = qdhj / fbfxhj * 100;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[0];
        //                    APP.GoldSoftClient.C4_COUNT++;
        //                }
        //                else if (tmpArr[0].Substring(1, 1).Equals("5"))
        //                {
        //                    newRow[9] = 0;
        //                    newRow[10] = 0;
        //                    newRow[11] = 0;
        //                    newRow[12] = 0;
        //                    newRow[13] = 0;
        //                    newRow[14] = 0;
        //                    newRow[15] = 0;
        //                    newRow[16] = 0;
        //                    newRow[17] = 0;
        //                    newRow[18] = 0;
        //                    newRow[19] = 0;
        //                    newRow[20] = tmpArr[0];
        //                    newRow[21] = 0;
        //                    newRow[22] = 0;
        //                    newRow[23] = 0;
        //                    newRow[24] = tmpArr[1];
        //                }
        //            }
        //            temp.Rows.Add(newRow);
        //            index++;
        //        }
        //    }
        //    return temp;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bl">单条比例</param>
        /// <returns></returns>
        //private string getQY(float dgbl,float hjbl)
        //{
        //    if (hjbl <= MaxA)
        //    {
        //        if (hjbl <= A1)
        //            return "A1," + (++AXH);
        //        else if (hjbl > A1 && hjbl <= A2)
        //            return "A2," + (++AXH);
        //        else if (hjbl > A2 && hjbl <= A3)
        //            return "A3," + (++AXH);
        //        else if (hjbl > A3 && hjbl <= A4)
        //            return "A4," + (++AXH);
        //        else if (hjbl > A4 && hjbl <= A5)
        //            return "A5," + (++AXH);
        //    }
        //    else if (dgbl >= MinC)
        //    {
        //        if (dgbl > C1 && dgbl <= C2)
        //            return "C1," + (++CXH);
        //        else if (dgbl > C2 && dgbl <= C3)
        //            return "C2," + (++CXH);
        //        else if (dgbl > C3 && dgbl < C4)
        //            return "C3," + (++CXH);
        //        else if (dgbl > C4)
        //            return "C4," + (++CXH);
        //    }
        //    else
        //        return "B," + (++BXH);

        //    return "";

        //}

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}