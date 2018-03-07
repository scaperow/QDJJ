using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GoldSoft.CICM.UI;
using GoldSoft.QD_api;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class CustomBAL
    {
        #region  获取用户所有信息
        /// <summary>
        /// 获取用户所有信息
        /// </summary>
        /// <param name="wb_web">连接</param>
        /// <param name="jmLock">锁号</param>
        public static void BDsuoManager(string wb_web, string jmLock)
        {
            //调用远程方法 获取资料
            DataTable dtsuoManager = WebServiceHelper.InvokeMethod<DataTable>(wb_web, "getSuoManagerInfoByJmLock", jmLock);
            CEntitySuomanager cSuoManager = new CEntitySuomanager();
            cSuoManager.ID = long.Parse(dtsuoManager.Rows[0]["ID"].ToString());
            cSuoManager.ADDRESS = dtsuoManager.Rows[0]["ADDRESS"].ToString();
            cSuoManager.AREA = dtsuoManager.Rows[0]["AREA"].ToString();
            cSuoManager.BANK = dtsuoManager.Rows[0]["BANK"].ToString();
            cSuoManager.CITY = dtsuoManager.Rows[0]["CITY"].ToString();
            cSuoManager.CUSTOMERNAME = dtsuoManager.Rows[0]["CUSTOMERNAME"].ToString();
            cSuoManager.CW_REMARK = dtsuoManager.Rows[0]["CW_REMARK"].ToString();
            cSuoManager.CW_SUBMIT = dtsuoManager.Rows[0]["CW_SUBMIT"].ToString();
            cSuoManager.DWXZ = dtsuoManager.Rows[0]["DWXZ"].ToString();
            cSuoManager.ENDTIME = dtsuoManager.Rows[0]["ENDTIME"].ToString();
            cSuoManager.IDCARD = dtsuoManager.Rows[0]["IDCARD"].ToString();
            cSuoManager.INTERLOCK = dtsuoManager.Rows[0]["INTERLOCK"].ToString();
            cSuoManager.ISFIRST = dtsuoManager.Rows[0]["ISFIRST"].ToString();
            cSuoManager.ISGX = dtsuoManager.Rows[0]["ISGX"].ToString();
            cSuoManager.ISPASS = dtsuoManager.Rows[0]["ISPASS"].ToString();
            cSuoManager.ISYZ = dtsuoManager.Rows[0]["ISYZ"].ToString();
            cSuoManager.JMLOCK = dtsuoManager.Rows[0]["JMLOCK"].ToString();
            cSuoManager.KTTIME = dtsuoManager.Rows[0]["KTTIME"].ToString();
            cSuoManager.LY_REMARK = dtsuoManager.Rows[0]["LY_REMARK"].ToString();
            cSuoManager.LY_SUBMIT = dtsuoManager.Rows[0]["LY_SUBMIT"].ToString();
            cSuoManager.MONEY = dtsuoManager.Rows[0]["MONEY"].ToString();
            cSuoManager.MOVETEL = dtsuoManager.Rows[0]["MOVETEL"].ToString();
            cSuoManager.OLDLOCK = dtsuoManager.Rows[0]["OLDLOCK"].ToString();
            cSuoManager.PH = dtsuoManager.Rows[0]["PH"].ToString();
            cSuoManager.POSITION = dtsuoManager.Rows[0]["POSITION"].ToString();
            cSuoManager.POSTCODE = dtsuoManager.Rows[0]["POSTCODE"].ToString();
            cSuoManager.PROFESSION = dtsuoManager.Rows[0]["PROFESSION"].ToString();
            cSuoManager.PROVINCE = dtsuoManager.Rows[0]["PROVINCE"].ToString();
            cSuoManager.QQ = dtsuoManager.Rows[0]["QQ"].ToString();
            cSuoManager.REASON = dtsuoManager.Rows[0]["REASON"].ToString();
            cSuoManager.REMARK = dtsuoManager.Rows[0]["REMARK"].ToString();
            cSuoManager.SERVICE_PERSON = dtsuoManager.Rows[0]["SERVICE_PERSON"].ToString();
            cSuoManager.SEX = dtsuoManager.Rows[0]["SEX"].ToString();
            cSuoManager.SOFT_USE = dtsuoManager.Rows[0]["SOFT_USE"].ToString();
            cSuoManager.SQTIME = dtsuoManager.Rows[0]["SQTIME"].ToString();
            cSuoManager.STATUS = dtsuoManager.Rows[0]["STATUS"].ToString();
            cSuoManager.TEL = dtsuoManager.Rows[0]["TEL"].ToString();
            cSuoManager.USE_COUNT = long.Parse(dtsuoManager.Rows[0]["USE_COUNT"].ToString());
            cSuoManager.USE_TIME = long.Parse(dtsuoManager.Rows[0]["USE_TIME"].ToString());
            cSuoManager.VERSION = dtsuoManager.Rows[0]["VERSION"].ToString();
            cSuoManager.VERSION_SUBMIT = dtsuoManager.Rows[0]["VERSION_SUBMIT"].ToString();
            cSuoManager.XINGZHI = dtsuoManager.Rows[0]["XINGZHI"].ToString();
            cSuoManager.ZCDWNAME = dtsuoManager.Rows[0]["ZCDWNAME"].ToString();

            APP.GXKG = dtsuoManager.Rows[0]["isgx"].ToString().Equals("共享") ? true : false;
            APP.ZGFAKG = dtsuoManager.Rows[0]["cw_submit"].ToString().Equals("共享") ? true : false;
            APP.BCQDKG = dtsuoManager.Rows[0]["ly_submit"].ToString().Equals("共享") ? true : false;
            APP.GoldSoftClient.CurrentCustom = cSuoManager;

            //this.cEntitySuomanagerBindingSource.DataSource = dtsuoManager;
        }

        #endregion

        #region  修改临时表业务
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        public static bool updateBDsuoManager(string wb_web, DataTable dt)
        {
            return WebServiceHelper.InvokeMethod<bool>(wb_web, "insertSuoUpdateLog", dt);
        }
        private static DataTable dt = null;
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static DataTable getTable(CEntitySuomanager info)
        {
            // 获取输入信息
            CustomBAL.createTable();
            DataRow dr = CustomBAL.dt.NewRow();
            dr["id"] = info.ID;
            dr["interlock"] = info.JMLOCK;
            dr["version"] = info.VERSION;
            dr["xingzhi"] = info.XINGZHI;
            dr["oldLock"] = info.OLDLOCK;
            dr["province"] = info.PROVINCE;
            dr["city"] = info.CITY;
            dr["area"] = info.AREA;
            dr["customerName"] = info.CUSTOMERNAME;

            dr["sex"] = info.SEX;

            dr["profession"] = info.PROFESSION;
            dr["position"] = info.POSITION;
            dr["dwxz"] = info.DWXZ;
            dr["zcdwName"] = info.ZCDWNAME;
            dr["idcard"] = info.IDCARD;
            dr["soft_use"] = info.SOFT_USE;
            dr["address"] = info.ADDRESS;
            dr["tel"] = info.TEL;
            dr["moveTel"] = info.MOVETEL;
            dr["postcode"] = info.POSTCODE;
            dr["qq"] = info.QQ;
            dr["money"] = info.MONEY;
            dr["service_person"] = info.SERVICE_PERSON;
            dr["sqTime"] = info.SQTIME;
            dr["ktTime"] = info.KTTIME;
            dr["status"] = "变更";
            dr["endTime"] = info.ENDTIME;
            dr["version_submit"] = info.VERSION_SUBMIT;
            dr["cw_submit"] = info.CW_SUBMIT;
            dr["ly_submit"] = info.LY_SUBMIT;
            dr["use_count"] = info.USE_COUNT;
            dr["use_time"] = info.USE_TIME;
            dr["cw_remark"] = info.CW_REMARK;
            dr["ly_remark"] = info.LY_REMARK;
            dr["PH"] = info.PH;
            dr["bank"] = info.BANK;
            dr["remark"] = info.REMARK;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 创建修改临时表表结构
        /// </summary>
        /// <returns></returns>
        private static void createTable()
        {
            dt = new DataTable();
            dt.TableName = "suoUpdateLog";
            dt.Columns.Add("id", typeof(System.Int64));
            dt.Columns.Add("interlock", typeof(System.Int64));
            dt.Columns.Add("version", typeof(System.String));
            dt.Columns.Add("xingzhi", typeof(System.String));
            dt.Columns.Add("oldLock", typeof(System.String));
            dt.Columns.Add("province", typeof(System.String));
            dt.Columns.Add("city", typeof(System.String));
            dt.Columns.Add("area", typeof(System.String));
            dt.Columns.Add("customerName", typeof(System.String));
            dt.Columns.Add("sex", typeof(System.String));
            dt.Columns.Add("profession", typeof(System.String));
            dt.Columns.Add("position", typeof(System.String));
            dt.Columns.Add("dwxz", typeof(System.String));
            dt.Columns.Add("zcdwName", typeof(System.String));
            dt.Columns.Add("idcard", typeof(System.String));
            dt.Columns.Add("soft_use", typeof(System.String));
            dt.Columns.Add("address", typeof(System.String));
            dt.Columns.Add("tel", typeof(System.String));
            dt.Columns.Add("moveTel", typeof(System.String));
            dt.Columns.Add("postcode", typeof(System.String));
            dt.Columns.Add("qq", typeof(System.String));
            dt.Columns.Add("money", typeof(System.String));
            dt.Columns.Add("service_person", typeof(System.String));
            dt.Columns.Add("sqTime", typeof(System.String));
            dt.Columns.Add("ktTime", typeof(System.String));
            dt.Columns.Add("status", typeof(System.String));
            dt.Columns.Add("endTime", typeof(System.String));
            dt.Columns.Add("version_submit", typeof(System.String));
            dt.Columns.Add("cw_submit", typeof(System.String));
            dt.Columns.Add("ly_submit", typeof(System.String));
            dt.Columns.Add("use_count", typeof(System.String));
            dt.Columns.Add("use_time", typeof(System.String));
            dt.Columns.Add("cw_remark", typeof(System.String));
            dt.Columns.Add("ly_remark", typeof(System.String));
            dt.Columns.Add("PH", typeof(System.String));
            dt.Columns.Add("bank", typeof(System.String));
            dt.Columns.Add("remark", typeof(System.String));
            dt.Columns.Add("jifen", typeof(System.String));
        }
        #endregion

        #region  价格库业务
        /// <summary>
        /// 返回价格库是否通过
        /// </summary>
        /// <param name="wb_web">连接</param>
        /// <param name="jmLock">锁号</param>
        public static void BDsuoManagerExtendInfo(string wb_web, string jmLock)
        {
            //获取引用方式数据
            DataTable dt = WebServiceHelper.InvokeMethod<DataTable>(wb_web, "getSuoManagerExtendInfo", jmLock);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string name = dt.Rows[i]["name"].ToString();
                    string value = dt.Rows[i]["value"].ToString();
                    switch (name)
                    {
                        case "用户材料价格存储与引用方式":
                            if (value == "共享")
                            {
                                APP.GXKG = true;
                            }
                            else
                            {
                                APP.GXKG = false;
                            }
                            break;
                        case "组价方案存储与引用方式":
                            if (value == "共享")
                            {
                                APP.ZGFAKG = true;
                            }
                            else
                            {
                                APP.ZGFAKG = false;
                            }
                            break;
                        case "补充清单，定额，材料与引用方式":
                            if (value == "共享")
                            {
                                APP.BCQDKG = true;
                            }
                            else
                            {
                                APP.BCQDKG = false;
                            }
                            break;
                        default: break;
                    }

                }
            }
        }
        /// <summary>
        /// 修改共享库信息
        /// </summary>
        /// <param name="wb_web"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool updateBDsuoManagerExtendInfo(string wb_web, DataTable dt)
        {
            return WebServiceHelper.InvokeMethod<bool>(wb_web, "updateSuoManagerExtendInfo", dt);
        }


    


        private static DataTable dtExtend = null;
        /// <summary>
        /// 创建一个表suoManagerExtendInFo
        /// </summary>
        /// <returns>dtExtend</returns>
        private static DataTable createExtendTable()
        {
            CustomBAL.dtExtend = new DataTable();
            dtExtend.TableName = "suoManagerExtendInFo";
            dtExtend.Columns.Add("id", typeof(System.Int64));
            dtExtend.Columns.Add("JMLOCK", typeof(System.Int64));
            dtExtend.Columns.Add("suoManagerId", typeof(System.String));
            dtExtend.Columns.Add("name", typeof(System.String));
            dtExtend.Columns.Add("value", typeof(System.String));
            dtExtend.Columns.Add("userId", typeof(System.String));
            dtExtend.Columns.Add("insertTime", typeof(System.String));
            dtExtend.Columns.Add("remark", typeof(System.String));
            return dtExtend;
        }
        public static DataTable getExtendTable(CEntitySuomanager info)
        {
            /**
             DataRow dr = CustomBAL.dt.NewRow();
                             this.rd_y_yhcl.Checked = APP.GXKG;
                this.rd_y_zjfa.Checked = APP.ZGFAKG;
                this.rd_y_bcde.Checked = APP.BCQDKG;
             */

            CustomBAL.createExtendTable();

            string JMLOCK = APP.GoldSoftClient.CurrentCustom.JMLOCK;

            DataRow drExtend = CustomBAL.dtExtend.NewRow();

            drExtend = dtExtend.NewRow();
            drExtend["id"] = "0";
            drExtend["JMLOCK"] = JMLOCK;
            drExtend["suoManagerId"] = "";
            drExtend["name"] = "用户材料价格存储与引用方式";
            if (APP.GXKG)
            {
                drExtend["value"] = "共享";
            }
            else
            {
                drExtend["value"] = "不共享";
            }

            drExtend["userId"] = "0";
            drExtend["insertTime"] = "";
            drExtend["remark"] = "";
            dtExtend.Rows.Add(drExtend);


            drExtend = CustomBAL.dtExtend.NewRow();
            drExtend["id"] = "0";
            drExtend["JMLOCK"] = JMLOCK;
            drExtend["suoManagerId"] = "";
            drExtend["name"] = "组价方案存储与引用方式";
            if (APP.ZGFAKG)
            {
                drExtend["value"] = "共享";
            }
            else
            {
                drExtend["value"] = "不共享";
            }

            drExtend["userId"] = "0";
            drExtend["insertTime"] = "";
            drExtend["remark"] = "";
            dtExtend.Rows.Add(drExtend);



            drExtend = CustomBAL.dtExtend.NewRow();
            drExtend["id"] = "0";
            drExtend["JMLOCK"] = JMLOCK;
            drExtend["suoManagerId"] = "";
            drExtend["name"] = "补充清单，定额，材料与引用方式";
            if (APP.BCQDKG)
            {
                drExtend["value"] = "共享";
            }
            else
            {
                drExtend["value"] = "不共享";
            }

            drExtend["userId"] = "0";
            drExtend["insertTime"] = "";
            drExtend["remark"] = "";
            dtExtend.Rows.Add(drExtend);


            return dtExtend;
        }
        #endregion

        /// <summary>
        /// 获取积分信息
        /// </summary>
        /// <param name="wb_web"></param>
        /// <param name="jmLock"></param>
        /// <returns></returns>
        public static string getJF(string wb_web, string jmLock)
        {
            return WebServiceHelper.InvokeMethod<int>(wb_web, "getJiFen", jmLock).ToString();
        }
    }
}
