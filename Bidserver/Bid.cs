using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bidserver
{
    public class Bid
    {
        int A1_COUNT = 0;
        int A2_COUNT = 0;
        int A3_COUNT = 0;
        int A4_COUNT = 0;
        int A5_COUNT = 0;
        int B_COUNT = 0;
        int C1_COUNT = 0;
        int C2_COUNT = 0;
        int C3_COUNT = 0;
        int C4_COUNT = 0;
        public float A1_BL = 0.0f;
        public float A2_BL = 0.0f;
        public float A3_BL = 0.0f;
        public float A4_BL = 0.0f;
        public float A5_BL = 0.0f;
        public float B_BL = 0.0f;
        public float C1_BL = 0.0f;
        public float C2_BL = 0.0f;
        public float C3_BL = 0.0f;
        public float C4_BL = 0.0f;
        decimal A1 = 1.0m; //<=0.01
        decimal A2 = 3.0m; // > 0.01 and <= 0.03
        decimal A3 = 5.0m; // >0.03 and <= 0.05
        decimal A4 = 10.0m; // >0.05 and <= 0.08
        decimal A5 = 15.0m; // >0.08 and <= 0.95
        decimal C1 = 1.0m;  // >0.8
        decimal C2 = 3.0m;  // >0.5 and <=0.8
        decimal C3 = 5.0m;  // >0.3 and <=0.5
        decimal C4 = 8.0m;  // >0.1 and <=0.3
        decimal C5 = 8.0m;  // >0.1 and <=0.3
        int AXH = 0;
        int BXH = 0;
        int CXH = 0;
        decimal B = 0.0m; // >0.08 and <= 0.95
        decimal MaxA = 15.0m;
        decimal MinC = 1.0m;
        int SPACE_QY_COUNT = 0;
        decimal TotalMeasureFee, TotalProjectFee, TotalSubsegmentFee;
        int Owners, Mines, Others;
        bool Publish;
        DataTable ProjectStruct;
        DataTable Coefficient;
        DataTable Subsegments;
        string LockID;
        string LockNumber;

        public object Check(string args)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(args);
            var rule = SQL.GetTable(System.Data.CommandType.Text, "SELECT TOP 1 * FROM TBKZ", null)[0].Rows[0];
            decimal limitPrice = decimal.Parse(data["limitPrice"] + "");
            decimal totalProjectFee = decimal.Parse(data["totalProjectFee"] + "");
            decimal totalSubsegmentFee = decimal.Parse(data["totalSubsegmentFee"] + "");
            decimal totalMeasureFee = decimal.Parse(data["totalMeasureFee"] + "");
            decimal quotaCount = decimal.Parse(data["quotaCount"] + "");
            int mines = int.Parse(data["mines"] + "");
            string lockNumber = data["lockNumber"] + "";
            bool publish = bool.Parse(data["publish"] + "");
            var costToPay = 0;

            if (limitPrice <= 0)
            {
                return new
                {
                    error = "总造价为0，项目文件不符合调标要求！"
                };
            }

            if (limitPrice < totalProjectFee)
            {
                return new
                 {
                     error = "总造价小与上限金额，项目文件不符合调标要求！"
                 };
            }

            if (totalMeasureFee <= 0)
            {
                return new
                {
                    error = "措施项目合计为0，项目文件不符合调标要求！"
                };
            }

            /*
            var xs = Math.Abs(decimal.Parse(rule["CSFBL"] + ""));
            if (totalMeasureFee <= (totalProjectFee * xs))
            {
                return new
               {
                   error = "措施项目合计必须大于总造价乘以 " + xs + "， 项目文件不符合调标要求！"
               };
            }

            var quotaFilter = Math.Abs(decimal.Parse(rule["QDSL"] + ""));
            if (quotaCount < quotaFilter)
            {
                return new
                {
                    error = "单位工程至少包含 " + quotaFilter + " 清单个数不符合调标要求!"
                };
            }

            var lockNumbers = rule["KZSH"] + "";
            if (lockNumbers.Contains(lockNumber) == false)
            {
                return new
                {
                    error = "当前锁号没有权限进行调标操作！"
                };
            }

            //计算要扣除的积分
            if (publish)//JFJJB表
            {

                xs = Math.Abs(decimal.Parse(SQL.ExecuteScalar(System.Data.CommandType.Text, "select top 1 GKZB FROM JFJJB") + ""));
                costToPay = (Int32)(quotaCount * mineNumber * xs);//TODO 系数要从数据表中取;
            }
            else
            {
                xs = Math.Abs(decimal.Parse(SQL.ExecuteScalar(System.Data.CommandType.Text, "select top 1 YQZB FROM JFJJB") + ""));
                costToPay = (Int32)(quotaCount * mineNumber * xs);//TODO 系数要从数据表中取;
            }
             * */

            return new
            {
                error = "",
                cost = costToPay
            };

            //if (APP.GoldSoftClient.QDJJTB.Tables["TBKZ"].Rows[0]["KZSH"].ToString().Contains(APP.GoldSoftClient.GlodSoftDiscern.CurrNo))
            //{
            //    Record(cost, "当前锁号没有权限进行调标操作！");
            //    this.Close();
            //    return false;
            //}
        }

        public object Analyze(string args)
        {
            var message = "";
            var excel = new DataTable();
            var source = new DataTable();
            var map = JsonConvert.DeserializeObject<Dictionary<string, object>>(args);
            if (map == null)
            {
                message = "上传的数据不正确";
                goto error;
            }
            LockID = map["lockID"] + "";
            Owners = int.Parse(map["owners"] + "");
            Mines = int.Parse(map["mines"] + "");
            Others = int.Parse(map["others"] + "");
            TotalMeasureFee = decimal.Parse(map["totalMeasureFee"] + "");
            TotalProjectFee = decimal.Parse(map["totalProjectFee"] + "");
            TotalSubsegmentFee = decimal.Parse(map["totalSubsegmentFee"] + "");
            ProjectStruct = JsonConvert.DeserializeObject<DataTable>(map["projectStruct"] + "");
            Subsegments = JsonConvert.DeserializeObject<DataTable>(map["subsegments"] + "");

            InitializeParameter();

            if (GetCoefficientTable(out message, out Coefficient) == false)
            {
                goto error;
            }

            if (Generat(out message, out excel, out source) == false)
            {
                goto error;
            }

            PayCost();

            return new
            {
                coefficient = Coefficient.TableName,
                excel = JsonConvert.SerializeObject(excel),
                source = JsonConvert.SerializeObject(source),
                id = BuildAnaliyzeID(Coefficient.TableName),
                error = message
            };

        error:
            return new
            {
                error = message
            };
        }

        private void PayCost()
        {
            var x = 0e;
            var costToPay = 0;
            var rows = Subsegments.Select("LB='清单'");
            var quotaCount = rows.Length;

            //扣除积分
            if (Publish)
            {
                var xs = Math.Abs(decimal.Parse(SQL.ExecuteScalar(System.Data.CommandType.Text, "select top 1 GKZB FROM JFJJB") + ""));
                costToPay = (Int32)(quotaCount * Mines * xs);//TODO 系数要从数据表中取;
            }
            else
            {
                var xs = Math.Abs(decimal.Parse(SQL.ExecuteScalar(System.Data.CommandType.Text, "select top 1 YQZB FROM JFJJB") + ""));
                costToPay = (Int32)(quotaCount * Mines * xs);//TODO 系数要从数据表中取;
            }

        }

        private string BuildAnaliyzeID(string coefficient)
        {
            var count = A1_COUNT + A2_COUNT + A3_COUNT + A4_COUNT + A5_COUNT + B_COUNT + C1_COUNT + C2_COUNT + C3_COUNT + C4_COUNT;
            var result = "";
            if (Publish)
            {
                result = count + "," + LockID + "," + coefficient;
            }
            else
            {
                result = count + "," + count + "|" +
                      A1_COUNT + "," + A1_BL + "," + A1 + "|" +
                      A2_COUNT + "," + A2_BL + "," + A2 + "|" +
                     A3_COUNT + "" + A3_BL + "," + A3 + "|" +
                     A4_COUNT + "," + A4_BL + "," + A4 + "|" +
                      A5_COUNT + "," + A5_BL + "," + A5 + "|" +
                     B_COUNT + "," + B_BL + "," + B + "|" +
                     C4_COUNT + "," + C4_BL + "," + C1 + "|" +
                     C3_COUNT + "," + C3_BL + "," + C2 + "|" +
                    C2_COUNT + "," + C2_BL + "," + C3 + "|" +
                      C1_COUNT + "," + C1_BL + "," + C4 + "|" +
                      (A1_COUNT + A2_COUNT + A3_COUNT + A4_COUNT + A5_COUNT).ToString() + "," +
                      (A1_BL + A2_BL + A3_BL + A4_BL + A5_BL).ToString() + "|" +
                      B_COUNT + "," + B_BL + "|" +
                      (C1_COUNT + C2_COUNT + C3_COUNT + C4_COUNT) + "," +
                      (C1_BL + C2_BL + C3_BL + C4_BL);
            }

            return result;
        }

        private void InitializeParameter()
        {
            var rule = SQL.GetTable(System.Data.CommandType.Text, "SELECT TOP 1 * FROM QUHFB", null)[0].Rows[0];

            string[] tmpArr = (rule["A1"] + "").Split('～');
            string[] dataArr;
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');

            A1 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["A2"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            A2 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["A3"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            A3 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["A4"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            A4 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["A5"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            A5 = decimal.Parse(dataArr[0]) / 100.0m;
            tmpArr = (rule["B"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            if (!string.IsNullOrEmpty(dataArr[0]))
                B = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["C1"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            C1 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["C2"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            C2 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["C3"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            C3 = decimal.Parse(dataArr[0]) / 100.0m;

            tmpArr = (rule["C4"] + "").Split('～');
            if (tmpArr.Length > 1)
                dataArr = tmpArr[1].Split('％');
            else
                dataArr = tmpArr[0].Split('％');
            C4 = decimal.Parse(dataArr[0]) / 100.0m;
            C5 = decimal.Parse((tmpArr[0].Split('％'))[0]) / 100.0m;

            MaxA = A1;
            MaxA = MaxA >= A2 ? MaxA : A2;
            MaxA = MaxA >= A3 ? MaxA : A3;
            MaxA = MaxA >= A4 ? MaxA : A4;
            MaxA = MaxA >= A5 ? MaxA : A5;

            MinC = C1;
            MinC = MinC < C2 ? MinC : C2;
            MinC = MinC < C3 ? MinC : C3;
            MinC = MinC < C4 ? MinC : C4;
            MinC = MinC < C5 ? MinC : C5;
        }

        private bool GetCoefficientTable(out string message, out DataTable result)
        {
            message = "";
            result = null;

            var sql = "SELECT TOP 1 TABLENAME FROM TBCSB WHERE TBJS LIKE '" + Owners + "'";
            var scalar = SQL.ExecuteScalar(CommandType.Text, sql) + "";
            if (string.IsNullOrEmpty(scalar))
            {
                message = "数据有误,请调整调标数据库 表 TBCSB";
                return false;
            }

            var tables = SQL.GetTable(CommandType.Text, "SELECT * FROM " + scalar, null);
            if (tables.Count == 0)
            {
                return false;
            }

            result = tables[0];
            return true;
        }

        private bool ProcessInviteData(out string message, out DataTable result)
        {
            Subsegments.DefaultView.Sort = "ZHHJ ASC";
            message = "";

            var table = new System.Data.DataTable();
            table.Columns.Add(new DataColumn("XH"));
            table.Columns.Add(new DataColumn("XMBM"));
            table.Columns.Add(new DataColumn("XMMC"));
            table.Columns.Add(new DataColumn("DW"));
            table.Columns.Add(new DataColumn("GCL"));
            table.Columns.Add(new DataColumn("ZHDJ"));
            table.Columns.Add(new DataColumn("ZHHJ"));
            table.Columns.Add(new DataColumn("DTBL"));
            table.Columns.Add(new DataColumn("BLLJ"));
            table.Columns.Add(new DataColumn("QDGS1"));
            table.Columns.Add(new DataColumn("QDGS2"));
            table.Columns.Add(new DataColumn("QDGS3"));
            table.Columns.Add(new DataColumn("QDGS4"));
            table.Columns.Add(new DataColumn("QDGS5"));
            table.Columns.Add(new DataColumn("DGZJGS1"));
            table.Columns.Add(new DataColumn("DGZJBL1"));
            table.Columns.Add(new DataColumn("DGZJGS2"));
            table.Columns.Add(new DataColumn("DGZJBL2"));
            table.Columns.Add(new DataColumn("DGZJGS3"));
            table.Columns.Add(new DataColumn("DGZJBL3"));
            table.Columns.Add(new DataColumn("DGZJGS4"));
            table.Columns.Add(new DataColumn("DGZJBL4"));
            table.Columns.Add(new DataColumn("QTGS"));
            table.Columns.Add(new DataColumn("QTBL"));
            table.Columns.Add(new DataColumn("QY"));
            table.Columns.Add(new DataColumn("OLDXH"));
            table.Columns.Add(new DataColumn("GCBH"));
            result = table;

            for (int i = 0; i < Owners; i++)
            {
                table.Columns.Add(new DataColumn("第 " + (i + 1).ToString() + " 家"));
            }

            var totalFee = 0.0m;
            var index = 0;

            AXH = 0;
            BXH = 0;
            CXH = 0;
            A1_COUNT = 0;
            A2_COUNT = 0;
            A3_COUNT = 0;
            A4_COUNT = 0;
            A5_COUNT = 0;
            B_COUNT = 0;
            C1_COUNT = 0;
            C2_COUNT = 0;
            C3_COUNT = 0;
            C4_COUNT = 0;

            for (int i = 0; i < Subsegments.DefaultView.Count; i++)
            {
                if (Subsegments.DefaultView[i]["LB"] + "" == "清单")
                {
                    var row = table.NewRow();
                    totalFee = decimal.Parse(Subsegments.DefaultView[i]["ZHHJ"].ToString());

                    row[0] = i + 2;
                    row[1] = Subsegments.DefaultView[i]["XMBM"];
                    row[2] = Subsegments.DefaultView[i]["XMMC"];
                    row[3] = Subsegments.DefaultView[i]["DW"];
                    row[4] = Subsegments.DefaultView[i]["GCL"];
                    row[5] = decimal.Parse(Subsegments.DefaultView[i]["ZHDJ"].ToString());
                    row[6] = Subsegments.DefaultView[i]["ZHHJ"];
                    row[7] = totalFee / TotalProjectFee;
                    if (index <= 0)
                        row[8] = row[7];
                    else
                        row[8] = decimal.Parse(table.Rows[index - 1][8].ToString()) + decimal.Parse(row[7].ToString());
                    row[25] = Subsegments.DefaultView[i]["XH"];
                    row[26] = Subsegments.DefaultView[i]["UnID"];
                    var QY = GetQY(decimal.Parse(row[7].ToString()), decimal.Parse(row[8].ToString()));
                    if (QY == "")
                    {
                        message = "数据有误!";
                        return false;
                    }

                    string[] QYS = QY.Split(',');

                    if (QYS[0].StartsWith("A"))
                    {
                        if (QYS[0].Substring(1, 1).Equals("1"))
                        {
                            row[9] = QYS[1];
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            A1_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("2"))
                        {
                            row[9] = 0;
                            row[10] = QYS[1];
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            A2_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("3"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = QYS[1];
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            A3_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("4"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = QYS[1];
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            A4_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("5"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = QYS[1];
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            A5_COUNT++;
                        }
                    }
                    else if (QYS[0].StartsWith("B"))
                    {
                        row[9] = 0;
                        row[10] = 0;
                        row[11] = 0;
                        row[12] = 0;
                        row[13] = 0;
                        row[14] = 0;
                        row[15] = 0;
                        row[16] = 0;
                        row[17] = 0;
                        row[18] = 0;
                        row[19] = 0;
                        row[20] = 0;
                        row[21] = 0;
                        row[22] = QYS[1];
                        if (i <= 0)
                            row[23] = row[7];
                        else
                            row[23] = decimal.Parse(table.Rows[index - 1][23].ToString()) + decimal.Parse(row[7].ToString());
                        row[24] = QYS[0];
                        B_COUNT++;
                    }
                    else if (QYS[0].StartsWith("C"))
                    {
                        if (QYS[0].Substring(1, 1).Equals("1"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = QYS[1];
                            row[15] = totalFee / TotalSubsegmentFee;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            C1_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("2"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = QYS[1];
                            row[17] = totalFee / TotalSubsegmentFee;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            C2_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("3"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = QYS[1];
                            row[19] = totalFee / TotalSubsegmentFee;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            row[20] = 0;
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            C3_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("4"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = QYS[1];
                            row[21] = totalFee / TotalSubsegmentFee;// float.Parse(dv[dv.Count - 1]["ZHHJ"].ToString()) * 100;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[0];
                            C4_COUNT++;
                        }
                        else if (QYS[0].Substring(1, 1).Equals("5"))
                        {
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            row[14] = 0;
                            row[15] = 0;
                            row[16] = 0;
                            row[17] = 0;
                            row[18] = 0;
                            row[19] = 0;
                            row[20] = QYS[0];
                            row[21] = 0;
                            row[22] = 0;
                            row[23] = 0;
                            row[24] = QYS[1];
                        }
                    }

                    for (int m = 0; m < Owners; m++)
                    {
                        row[27 + m] = 0;
                    }

                    table.Rows.Add(row);
                    index++;
                }
            }
            //
            //DataSet ds = APP.GoldSoftClient.QDJJTB;// this.getQDJJTB();

            float C1Sum = 0.0f, C2Sum = 0.0f, C3Sum = 0.0f, C4Sum = 0.0f;
            string cqy = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cqy = table.Rows[i]["QY"].ToString();

                if (cqy.Equals("C1"))
                {
                    C1Sum += float.Parse(table.Rows[i]["ZHHJ"].ToString());
                }
                if (cqy.Equals("C2"))
                {
                    C2Sum += float.Parse(table.Rows[i]["ZHHJ"].ToString());
                }
                if (cqy.Equals("C3"))
                {
                    C3Sum += float.Parse(table.Rows[i]["ZHHJ"].ToString());
                }
                if (cqy.Equals("C4"))
                {
                    C4Sum += float.Parse(table.Rows[i]["ZHHJ"].ToString());
                }
            }

            float rate = 0.0f, xs = 0.0f, finaRate = 0.0f;
            float stepRate = (float)(TotalMeasureFee / TotalProjectFee);
            bool isC3C4 = true;
            var dataset = SQL.ExecuteDataSet(CommandType.Text, "SELECT * FROM CSXSB;SELECT * FROM QUYUZI;SELECT * FROM ZIB;SELECT * FROM AZHI;SELECT * FROM BZHI;SELECT * FROM KZB;SELECT * FROM SHUIJ;SELECT * FROM BQXSB;SELECT TOP 1 FROM TBKZ");
            dataset.Tables[0].TableName = "CSXSB";
            dataset.Tables[1].TableName = "QUYUZI";
            dataset.Tables[2].TableName = "ZIB";
            dataset.Tables[3].TableName = "AZHI";
            dataset.Tables[4].TableName = "BZHI";
            dataset.Tables[5].TableName = "KZB";
            dataset.Tables[6].TableName = "SHUIJ";
            dataset.Tables[7].TableName = "BQXSB";
            dataset.Tables[8].TableName = "TBKZ";

            var CSXSSB = dataset.Tables["CSXSB"];
            // var CSXSSB = SQL.GetTable(CommandType.Text, "select * from CSXSB", null)[0];
            if (stepRate >= 0.01f && stepRate < 0.10f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS0110"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS0110"].ToString());
            }
            else if (stepRate >= 0.10f && stepRate < 0.15f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS1015"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS1015"].ToString());
            }
            else if (stepRate >= 0.15f && stepRate < 0.20f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS1520"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS1520"].ToString());
            }
            else if (stepRate >= 0.20f && stepRate < 0.25f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS2025"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS2025"].ToString());
            }
            else if (stepRate >= 0.25f && stepRate < 0.30f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS2530"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS2530"].ToString());
            }
            else if (stepRate >= 0.30f && stepRate < 0.35f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS3035"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS3035"].ToString());
            }
            else if (stepRate >= 0.35f && stepRate < 0.40f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS3540"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS3540"].ToString());
            }
            else if (stepRate >= 0.40f && stepRate < 0.45f)
            {
                rate = float.Parse(CSXSSB.Rows[0]["CS4045"].ToString());
                xs = float.Parse(CSXSSB.Rows[1]["CS4045"].ToString());
            }
            rate -= 1;


            float cshjAdd = float.Parse(TotalMeasureFee + "") * rate;

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
            var spaceCountLimit = int.Parse(dataset.Tables["TBKZ"].Rows[0]["KBQUSL"].ToString());
            for (int i = 0; i < table.Rows.Count; i++)
            {
                qy = table.Rows[i]["QY"].ToString();

                if (qy == null || qy.Trim().Equals(""))
                {
                    SPACE_QY_COUNT++;

                    if (SPACE_QY_COUNT >= spaceCountLimit)
                    {
                        message = "空白区域大于设定值，不能调标！";
                        return false;
                    }
                }

                else if (qy.Equals("A1"))
                {
                    A1_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("A2"))
                {
                    A2_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("A3"))
                {
                    A3_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("A4"))
                {
                    A4_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("A5"))
                {
                    A5_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("B"))
                {
                    B_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("C1"))
                {
                    C1_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("C2"))
                {
                    C2_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("C3"))
                {
                    C3_BL += float.Parse(table.Rows[i][7].ToString());
                }
                else if (qy.Equals("C4"))
                {
                    C4_BL += float.Parse(table.Rows[i][7].ToString());
                }

                string wz = dataset.Tables["QUYUZI"].Rows[0][qy].ToString();

                if (wz == null || wz.Equals(""))
                {
                    continue;
                }

                if (!lastQY.Equals(qy))
                {
                    zibCount = 0;
                }
                if (zibCount >= dataset.Tables["ZIB"].Rows.Count) zibCount = 0;
                dzr = float.Parse(dataset.Tables["ZIB"].Rows[zibCount][wz].ToString());
                wzr = float.Parse(dataset.Tables["ZIB"].Rows[zibCount]["WZR" + wz.Substring(3)].ToString());
                R = (wzr * (Others + Mines - 2) - (Others - 1) * dzr - wzr) / (Mines - 2);

                K1 = (R * (Mines - 2) - wzr * 2f) / (Mines - 2 - 2);
                K2 = (R * (Mines - 2) - wzr * 0.9f) / (Mines - 2 - 1);
                K3 = (R * (Mines - 2) - wzr * 1.5f) / (Mines - 2 - 1);


                //AZHI 一条
                DataRow[] rowA = dataset.Tables["AZHI"].Select("WF like '%" + Mines + "%'");
                //BZHI 可能多条
                DataRow[] rowB = dataset.Tables["BZHI"].Select("WF like '%" + Mines + "%'");
                DataRow[] rowK = null;
                if (Others + Mines > 5)
                {
                    rowK = dataset.Tables["KZB"].Select("TJ like '%DF+WF>D%' and  QY like '%" + qy + "%' and WF = " + Mines + " and DF = " + Others);
                    K4 = R * 1.01f;
                }
                else
                {
                    rowK = dataset.Tables["KZB"].Select("TJ like '%DF+WF<D%' and  QY like '%" + qy + "%' and WF = " + Mines + " and DF = " + Others);
                    K4 = R * 1.05f;
                }

                if (rowA.Length <= 0) continue;
                if (rowB.Length <= 0) continue;
                if (rowK.Length <= 0) continue;
                if (dataset.Tables["SHUIJ"].Rows.Count <= 0) continue;


                float zhdj = float.Parse(table.Rows[i]["ZHDJ"].ToString());
                float aRate = 0.0f, bRate = 0.0f, kRate = 0.0f, sjRate = 0.0f;
                //for(int n = 0; n < APP.GoldSoftClient.My_Count -1; n++)
                for (int n = 0; n < Owners; n++)
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
                    //if (suiJiCount > dataset.Tables["SHUIJ"].Rows.Count -1)
                    //    suiJiCount = 0;

                    if (bZhiCount > rowB.Length - 1)
                        bZhiCount = 0;
                    try
                    {
                        bRate = float.Parse(rowB[bZhiCount][2 + n].ToString());//+3表示第一家不用算
                        kRate = float.Parse(rowK[0]["K"].ToString());
                        sjRate = float.Parse(dataset.Tables["SHUIJ"].Rows[suiJiCount][1 + n].ToString());//+2表示第一家不用算

                        if (qy.StartsWith("C"))
                            if (!isC3C4 && (qy.Equals("C3") || qy.Equals("C4")))
                                table.Rows[i][27 + n] = zhdj * aRate * bRate * kRate * sjRate;
                            else
                                table.Rows[i][27 + n] = zhdj * aRate * bRate * kRate * sjRate * finaRate;
                        else
                            table.Rows[i][27 + n] = zhdj * aRate * bRate * kRate * sjRate;
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
            float[] ACSum = new float[Owners];
            //int m = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                qy = table.Rows[i]["QY"].ToString();
                if (qy.Equals("B"))
                {
                    BSum += float.Parse(table.Rows[i]["ZHHJ"].ToString());
                }
                for (int n = 0; n < Owners; n++)
                {
                    if (qy.StartsWith("A") || qy.StartsWith("C"))
                    {
                        ACSum[n] += float.Parse(table.Rows[i][27 + n].ToString()) * float.Parse(table.Rows[i]["GCL"].ToString());
                    }
                }
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {

                for (int n = 0; n < Owners; n++)
                {
                    bQYRate = (float.Parse(TotalProjectFee + "") - (cshjAdd + float.Parse(TotalMeasureFee + "")) - (ACSum[n])) / BSum;
                    if (table.Rows[i]["QY"].ToString().Equals("B"))
                    {
                        table.Rows[i][27 + n] = float.Parse(table.Rows[i]["ZHDJ"] + "") * bQYRate * float.Parse(dataset.Tables["BQXSB"].Rows[0][1 + n] + "");
                    }
                }
            }

            return true;
        }

        private bool CalculateInvite(out string message, out DataTable result)
        {
            DataTable table = null;
            message = "";
            result = null;

            if (ProcessInviteData(out message, out table))
            {
                table.DefaultView.Sort = "ZHHJ ASC";

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

                for (int i = 0; i < Mines; i++)
                {
                    temp.Columns.Add(new DataColumn("第 " + (i + 1).ToString() + " 家"));
                }

                DataRow newRow;
                float dj = 0.0f;
                int j = 0;
                string gcmc = "", gcbh = "";
                DataRow[] gcRows;
                for (int i = 0; i < table.DefaultView.Count; i++)
                {
                    gcmc = "";
                    gcbh = "";
                    gcRows = ProjectStruct.Select("ID = '" + table.DefaultView[i]["GCBH"].ToString() + "'");
                    if (gcRows.Length > 0)
                    {
                        gcmc = gcRows[0]["Name"].ToString();
                        gcbh = gcRows[0]["Code"].ToString();
                    }

                    newRow = temp.NewRow();

                    newRow[0] = table.DefaultView[i]["OLDXH"];
                    newRow[1] = gcmc;
                    newRow[2] = table.DefaultView[i]["GCBH"];
                    newRow[3] = gcbh;
                    newRow[4] = table.DefaultView[i]["XMMC"];
                    newRow[5] = table.DefaultView[i]["DW"];
                    newRow[6] = table.DefaultView[i]["GCL"];
                    newRow[7] = table.DefaultView[i]["ZHDJ"];
                    newRow[8] = table.DefaultView[i]["ZHHJ"];

                    dj = float.Parse(table.DefaultView[i]["ZHDJ"].ToString());
                    for (int n = 0; n < Owners; n++)
                    {
                        newRow[9 + n] = table.DefaultView[i][27 + n];
                    }

                    if (j < Mines)
                        j++;
                    else
                        j = 0;

                    temp.Rows.Add(newRow);
                }

                result = temp;

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CalculatePublish(out string message, out DataTable result)
        {
            Subsegments.DefaultView.Sort = "ZHHJ ASC";
            message = "";
            result = null;

            var table = new System.Data.DataTable();
            table.Columns.Add(new DataColumn("OLDXH"));
            table.Columns.Add(new DataColumn("GCMC"));
            table.Columns.Add(new DataColumn("GCID"));
            table.Columns.Add(new DataColumn("GCBH"));
            table.Columns.Add(new DataColumn("XMMC"));
            table.Columns.Add(new DataColumn("DW"));
            table.Columns.Add(new DataColumn("GCL"));
            table.Columns.Add(new DataColumn("ZHDJ"));
            table.Columns.Add(new DataColumn("ZHHJ"));
            for (int i = 0; i < Owners - 1; i++)
            {
                table.Columns.Add(new DataColumn("第 " + (i + 2).ToString() + " 家"));
            }

            float unitPrice = 0.0f;
            int j = 0;
            var totalUnitPrice = 0.0f;


            for (int i = 0; i < Subsegments.DefaultView.Count; i++)
            {
                var projectName = "";
                var projectCode = "";
                var projectRows = ProjectStruct.Select("ID = " + Subsegments.DefaultView[i]["UnID"].ToString());

                if (projectRows.Length > 0)
                {
                    projectName = projectRows[0]["Name"].ToString();
                    projectCode = projectRows[0]["Code"].ToString();
                }

                var subsegment = Subsegments.DefaultView[i];

                if (subsegment["LB"] + "" == "清单")
                {
                    var row = table.NewRow();

                    row[0] = subsegment["XH"];
                    row[1] = projectName;
                    row[2] = subsegment["UnID"];
                    row[3] = projectCode;
                    row[4] = subsegment["XMMC"];
                    row[5] = subsegment["DW"];
                    row[6] = subsegment["GCL"];
                    row[7] = subsegment["ZHDJ"];
                    row[8] = subsegment["ZHHJ"];

                    totalUnitPrice = float.Parse(subsegment["ZHDJ"].ToString());
                    for (int n = 0; n < Owners - 1; n++)
                    {
                        object rate = Coefficient.Rows[j][n + 1];
                        if (rate == null || rate.ToString() == "")
                        {
                            if (j > 0)
                            {
                                //（上一条的原合价金额 + 本条的原合价金额 -上一条计算后的合价金额）÷本条的工程数量
                                try
                                {
                                    row[9 + n] = (float.Parse(table.Rows[table.Rows.Count - 1]["ZHHJ"].ToString()) + float.Parse(subsegment["ZHHJ"].ToString()) -
                                            (float.Parse(table.Rows[table.Rows.Count - 1][9 + n].ToString())) * float.Parse(table.Rows[table.Rows.Count - 1]["GCL"].ToString())) / float.Parse(Subsegments.DefaultView[i]["GCL"].ToString());
                                }
                                catch (Exception)
                                {
                                    row[9 + n] = 0;//数据有误
                                }

                            }
                        }
                        else if (Owners == 3 && rate.ToString().Equals("A"))
                        {
                            //（上三条的原合价金额 + 本条的原合价金额 -上三条计算后的合价金额）÷本条的工程数量
                            try
                            {
                                if (float.Parse(Subsegments.DefaultView[i]["GCL"].ToString()) == 0.0f)
                                    row[9 + n] = 0.0f;
                                else
                                    row[9 + n] = (float.Parse(table.Rows[table.Rows.Count - 1]["ZHHJ"].ToString()) + float.Parse(table.Rows[table.Rows.Count - 2]["ZHHJ"].ToString()) +
                                                    float.Parse(table.Rows[table.Rows.Count - 3]["ZHHJ"].ToString()) + float.Parse(subsegment["ZHHJ"].ToString()) -
                                                    float.Parse(table.Rows[table.Rows.Count - 1][n + 9].ToString()) * float.Parse(table.Rows[table.Rows.Count - 1][6].ToString()) -
                                                    float.Parse(table.Rows[table.Rows.Count - 2][n + 9].ToString()) * float.Parse(table.Rows[table.Rows.Count - 2][6].ToString()) -
                                                    float.Parse(table.Rows[table.Rows.Count - 3][n + 9].ToString()) * float.Parse(table.Rows[table.Rows.Count - 3][6].ToString())) / float.Parse(subsegment["GCL"].ToString());
                            }
                            catch (Exception)
                            {
                                row[9 + n] = 0;//数据有误
                            }
                        }
                        else
                            try
                            {
                                row[9 + n] = totalUnitPrice * float.Parse(Coefficient.Rows[j][n + 1].ToString());
                            }
                            catch (Exception)
                            {
                                row[9 + n] = 0;//数据有误
                            }
                    }
                    if (j < Coefficient.Rows.Count - 1)
                        j++;
                    else
                        j = 0;

                    table.Rows.Add(row);
                    A1_COUNT++;
                }
            }
            result = table;
            return true;
        }

        private bool Generat(out string message, out DataTable excel, out DataTable source)
        {
            excel = new DataTable()
            {
                TableName = ""
            };
            source = new DataTable();
            message = "";

            excel.Columns.AddRange(new DataColumn[]
            { 
                new DataColumn("清单序号"),
                new DataColumn("工程ID"),
                new DataColumn("工程编号"),
                new DataColumn("项目名称"),
                new DataColumn("计量单位"),
                new DataColumn("工程数量"),
                new DataColumn("单价金额"),
                new DataColumn("合价金额")
            });

            for (int i = 0; i < Owners; i++)
            {
                if (Publish)
                {
                    excel.Columns.Add("第 " + (i + 2).ToString() + " 家");
                }
                else
                {
                    excel.Columns.Add("第 " + (i + 1).ToString() + " 家");
                }
            }


            if (Publish)
            {
                CalculatePublish(out message, out source);
            }
            else
            {
                CalculateInvite(out message, out source);
            }

            return true;
        }

        private string GetQY(decimal dgbl, decimal hjbl)
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
    }
}
