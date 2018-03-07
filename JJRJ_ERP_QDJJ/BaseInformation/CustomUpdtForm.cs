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

namespace GOLDSOFT.QDJJ.UI.BaseInformation
{
    public partial class CustomUpdtForm : DevExpress.XtraEditors.XtraForm
    {

        private bool IsChange = false;


        /// <summary>
        /// 获取或设置当前用户信息
        /// </summary>
        private CEntitySuomanager m_CurrentCustom = null;
      
        /// <summary>
        /// 获取或设置当前用户信息
        /// </summary>
        public CEntitySuomanager CurrentCustom
        {
            get
            {

                return this.m_CurrentCustom;
            }
            set
            {
                this.m_CurrentCustom = value;
            }
        }

        /// <summary>
        /// 绑定当前对象数据
        /// </summary>
        public void Bind()
        {
            if (m_CurrentCustom == null)
            {

                string jmLock = APP.GoldSoftClient.CurrentCustom.JMLOCK;

                string wb_web = CSystem.GetAppConfig("wb");
                //调用远程方法 获取积分
                this.textEdit4.Text = CustomBAL.getJF(wb_web, jmLock);

                CustomBAL.BDsuoManagerExtendInfo(wb_web, jmLock);
                //BDsuoManagerExtendInfo(wb_web, jmLock);
                this.rd_y_yhcl.Checked = APP.GXKG;
                this.rd_y_zjfa.Checked = APP.ZGFAKG;
                this.rd_y_bcde.Checked = APP.BCQDKG;


                if (APP.GoldSoftClient.CurrentCustom.SOFT_USE=="个人")
                {
                    this.rdo_use_person.Checked = true;
                }
                else
                {
                    this.rdo_use_unit.Checked = true;
                }
                if (APP.GoldSoftClient.CurrentCustom.SEX == "男")
                {
                    this.rd_man.Checked = true;
                }
                else 
                {
                    this.rd_wman.Checked = true;
                }
                this.cEntitySuomanagerBindingSource.DataSource = APP.GoldSoftClient.CurrentCustom;

                this.rdo_use_unit.Enabled = false;
                this.rdo_use_person.Enabled = false;



                if (this.rdo_use_unit.Checked)
                {
                    this.txt_ZCDWNAME.Enabled = false;
                }
                if (this.rdo_use_person.Checked)
                {
                    this.txt_CUSTOMERNAME.Enabled = false;
                    this.txtIdCard.Enabled = false;
                }

            }
        }
        /// <summary>
        /// 绑定引用方式表数据
        /// </summary>
        //private void BDsuoManagerExtendInfo(string wb_web, string jmLock)
        //{
        //    //获取引用方式数据
        //    DataTable dt = WebServiceHelper.InvokeMethod<DataTable>(wb_web, "getSuoManagerExtendInfo", jmLock);
        //    if (dt != null)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string name = dt.Rows[i]["name"].ToString();
        //            string value = dt.Rows[i]["value"].ToString();
        //            switch (name)
        //            {
        //                case "用户材料价格存储与引用方式":
        //                    if (value == "通过")
        //                    {
        //                        this.rd_y_yhcl.Checked = true;
        //                    }
        //                    else
        //                    {
        //                        this.rd_no_yhcl.Checked = true;
        //                    }
        //                    break;
        //                case "组价方案存储与引用方式":
        //                    if (value == "通过")
        //                    {
        //                        this.rd_y_zjfa.Checked = true;
        //                    }
        //                    else
        //                    {
        //                        this.rd_no_zjfa.Checked = true;
        //                    }
        //                    break;
        //                case "补充清单，定额，材料与引用方式":
        //                    if (value == "通过")
        //                    {
        //                        this.rd_y_bcde.Checked = true;
        //                    }
        //                    else
        //                    {
        //                        this.rd_no_bcde.Checked = true;
        //                    }
        //                    break;
        //                default: break;
        //            }

        //        }
        //    }
        //}



        public CustomUpdtForm()
        {
            InitializeComponent();


        }


        public CustomUpdtForm(bool isChange)
        {
            this.IsChange = isChange;
            InitializeComponent();
        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }


        private void CustomInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void simpleButton2_Click1(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void simpleButton2_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }





        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click1(object sender, EventArgs e)
        {

            //获取输入信息
            CEntitySuomanager info = this.cEntitySuomanagerBindingSource.Current as CEntitySuomanager;
            int result = APP.GoldSoftClient.TryUpdateCustomer(info);
            if (result == ResultConst.SERVER_SUCCESS)
            {
                //成功
                MsgBox.Alert("资料已经提交成功等待审核");
                this.Close();
            }
            else
            {
                MsgBox.Alert("提交失败，稍后尝试！");
            }
        }
        //public DataTable dtExtend = null;
        //private DataTable getExtendTable(CEntitySuomanager info)
        //{

        //    string JMLOCK = APP.GoldSoftClient.CurrentCustom.JMLOCK;

        //    DataRow drExtend = null;

        //    drExtend = dtExtend.NewRow();
        //    drExtend["id"] = "0";
        //    drExtend["JMLOCK"] = JMLOCK;
        //    drExtend["suoManagerId"] = "";
        //    drExtend["name"] = "补充清单，定额，材料与引用方式";
        //    if (this.rd_y_bcde.Checked)
        //    {
        //        drExtend["value"] = "共享";
        //    }
        //    else
        //    {
        //        drExtend["value"] = "不共享";
        //    }

        //    drExtend["userId"] = "0";
        //    drExtend["insertTime"] = "";
        //    drExtend["remark"] = "";
        //    dtExtend.Rows.Add(drExtend);


        //    drExtend = dtExtend.NewRow();
        //    drExtend["id"] = "0";
        //    drExtend["JMLOCK"] = JMLOCK;
        //    drExtend["suoManagerId"] = "";
        //    drExtend["name"] = "组价方案存储与引用方式";
        //    if (this.rd_y_zjfa.Checked)
        //    {
        //        drExtend["value"] = "共享";
        //    }
        //    else
        //    {
        //        drExtend["value"] = "不共享";
        //    }

        //    drExtend["userId"] = "0";
        //    drExtend["insertTime"] = "";
        //    drExtend["remark"] = "";
        //    dtExtend.Rows.Add(drExtend);


        //    drExtend = dtExtend.NewRow();
        //    drExtend["id"] = "0";
        //    drExtend["JMLOCK"] = JMLOCK;
        //    drExtend["suoManagerId"] = "";
        //    drExtend["name"] = "用户材料价格存储与引用方式";
        //    if (this.rd_y_yhcl.Checked)
        //    {
        //        drExtend["value"] = "共享";
        //    }
        //    else
        //    {
        //        drExtend["value"] = "不共享";
        //    }

        //    drExtend["userId"] = "0";
        //    drExtend["insertTime"] = "";
        //    drExtend["remark"] = "";
        //    dtExtend.Rows.Add(drExtend);


        //    return dtExtend;
        //}
        ///// <summary>
        ///// 创建一个表suoManagerExtendInFo
        ///// </summary>
        ///// <returns>dtExtend</returns>
        //private DataTable createExtendTable()
        //{
        //    dtExtend = new DataTable();
        //    dtExtend.TableName = "suoManagerExtendInFo";
        //    dtExtend.Columns.Add("id", typeof(System.Int64));
        //    dtExtend.Columns.Add("JMLOCK", typeof(System.Int64));
        //    dtExtend.Columns.Add("suoManagerId", typeof(System.String));
        //    dtExtend.Columns.Add("name", typeof(System.String));
        //    dtExtend.Columns.Add("value", typeof(System.String));
        //    dtExtend.Columns.Add("userId", typeof(System.String));
        //    dtExtend.Columns.Add("insertTime", typeof(System.String));
        //    dtExtend.Columns.Add("remark", typeof(System.String));
        //    return dtExtend;
        //}



        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click2(object sender, EventArgs e)
        {



            //建立表结构
           //createTable();
            CEntitySuomanager info = this.cEntitySuomanagerBindingSource.Current as CEntitySuomanager;
            //处理单选按钮事件
            if (this.rd_man.Checked)
            {
                info.SEX = "男";
            }
            else
            {
                info.SEX = "女";
            }

            if (this.rd_y_bcde.Checked)
            {
                APP.BCQDKG = true;
            }
            else
            {
                APP.BCQDKG = false;
            }
            if (this.rd_y_yhcl.Checked)
            {
                APP.GXKG = true;
            }
            else
            {
                APP.GXKG = false;
            }
            if (this.rd_y_zjfa.Checked)
            {
                APP.ZGFAKG = true;
            }
            else
            {
                APP.ZGFAKG = false; ;
            }

            //获取DataTable信息(修改信息 用户临时表)
            DataTable dt = CustomBAL.getTable(info);
            //DataTable dt = getTable(info);

          //获取用户共享表
            DataTable dtExtend = CustomBAL.getExtendTable(info);

            /**
            8-14
            createExtendTable();
            DataTable dtExtend = getExtendTable(info);
             */


            bool sigesuoManager = false;
            bool sigesuoManagerExtend = false;
            if (dt != null && dtExtend != null)
            {
                string wb_web = CSystem.GetAppConfig("wb");


                sigesuoManager = CustomBAL.updateBDsuoManager(wb_web, dt);
                sigesuoManagerExtend = CustomBAL.updateBDsuoManagerExtendInfo(wb_web, dtExtend);
                if (sigesuoManager == true && sigesuoManagerExtend == true)
                {
                    //成功
                    MsgBox.Alert("资料已经提交成功等待审核");
                    this.Close();
                }
                else
                {
                    MsgBox.Alert("提交失败，稍后尝试！");
                }

            }
            else
            {
                MsgBox.Alert("提交失败，稍后尝试！");
            }

        }
        //public DataTable dt = null;
        //private DataTable getTable(CEntitySuomanager info)
        //{
        //    // 获取输入信息

        //    DataRow dr = dt.NewRow();
        //    dr["id"] = info.ID;
        //    dr["interlock"] = info.JMLOCK;
        //    dr["version"] = info.VERSION;
        //    dr["xingzhi"] = info.XINGZHI;
        //    dr["oldLock"] = info.OLDLOCK;
        //    dr["province"] = info.PROVINCE;
        //    dr["city"] = info.CITY;
        //    dr["area"] = info.AREA;
        //    dr["customerName"] = info.CUSTOMERNAME;
        //    if (this.rd_man.Checked)
        //    {
        //        dr["sex"] = "男";
        //    }
        //    else
        //    {
        //        dr["sex"] = "女";
        //    }
        //    dr["profession"] = info.PROFESSION;
        //    dr["position"] = info.POSITION;
        //    dr["dwxz"] = info.DWXZ;
        //    dr["zcdwName"] = info.ZCDWNAME;
        //    dr["idcard"] = info.IDCARD;
        //    dr["soft_use"] = info.SOFT_USE;
        //    dr["address"] = info.ADDRESS;
        //    dr["tel"] = info.TEL;
        //    dr["moveTel"] = info.MOVETEL;
        //    dr["postcode"] = info.POSTCODE;
        //    dr["qq"] = info.QQ;
        //    dr["money"] = info.MONEY;
        //    dr["service_person"] = info.SERVICE_PERSON;
        //    dr["sqTime"] = info.SQTIME;
        //    dr["ktTime"] = info.KTTIME;
        //    dr["status"] = "变更";
        //    dr["endTime"] = info.ENDTIME;
        //    dr["version_submit"] = info.VERSION_SUBMIT;
        //    dr["cw_submit"] = info.CW_SUBMIT;
        //    dr["ly_submit"] = info.LY_SUBMIT;
        //    dr["use_count"] = info.USE_COUNT;
        //    dr["use_time"] = info.USE_TIME;
        //    dr["cw_remark"] = info.CW_REMARK;
        //    dr["ly_remark"] = info.LY_REMARK;
        //    dr["PH"] = info.PH;
        //    dr["bank"] = info.BANK;
        //    dr["remark"] = info.REMARK;
        //    dt.Rows.Add(dr);
        //    return dt;
        //}



        ///// <summary>
        ///// 创建表结构
        ///// </summary>
        ///// <returns></returns>
        //private void createTable()
        //{
        //    dt = new DataTable();
        //    dt.TableName = "suoUpdateLog";
        //    dt.Columns.Add("id", typeof(System.Int64));
        //    dt.Columns.Add("interlock", typeof(System.Int64));
        //    dt.Columns.Add("version", typeof(System.String));
        //    dt.Columns.Add("xingzhi", typeof(System.String));
        //    dt.Columns.Add("oldLock", typeof(System.String));
        //    dt.Columns.Add("province", typeof(System.String));
        //    dt.Columns.Add("city", typeof(System.String));
        //    dt.Columns.Add("area", typeof(System.String));
        //    dt.Columns.Add("customerName", typeof(System.String));
        //    dt.Columns.Add("sex", typeof(System.String));
        //    dt.Columns.Add("profession", typeof(System.String));
        //    dt.Columns.Add("position", typeof(System.String));
        //    dt.Columns.Add("dwxz", typeof(System.String));
        //    dt.Columns.Add("zcdwName", typeof(System.String));
        //    dt.Columns.Add("idcard", typeof(System.String));
        //    dt.Columns.Add("soft_use", typeof(System.String));
        //    dt.Columns.Add("address", typeof(System.String));
        //    dt.Columns.Add("tel", typeof(System.String));
        //    dt.Columns.Add("moveTel", typeof(System.String));
        //    dt.Columns.Add("postcode", typeof(System.String));
        //    dt.Columns.Add("qq", typeof(System.String));
        //    dt.Columns.Add("money", typeof(System.String));
        //    dt.Columns.Add("service_person", typeof(System.String));
        //    dt.Columns.Add("sqTime", typeof(System.String));
        //    dt.Columns.Add("ktTime", typeof(System.String));
        //    dt.Columns.Add("status", typeof(System.String));
        //    dt.Columns.Add("endTime", typeof(System.String));
        //    dt.Columns.Add("version_submit", typeof(System.String));
        //    dt.Columns.Add("cw_submit", typeof(System.String));
        //    dt.Columns.Add("ly_submit", typeof(System.String));
        //    dt.Columns.Add("use_count", typeof(System.String));
        //    dt.Columns.Add("use_time", typeof(System.String));
        //    dt.Columns.Add("cw_remark", typeof(System.String));
        //    dt.Columns.Add("ly_remark", typeof(System.String));
        //    dt.Columns.Add("PH", typeof(System.String));
        //    dt.Columns.Add("bank", typeof(System.String));
        //    dt.Columns.Add("remark", typeof(System.String));
        //    dt.Columns.Add("jifen", typeof(System.String));
        //}

        private void CustomInfoForm_Load(object sender, EventArgs e)
        {
            //加载窗体的时候调用的函数类型
            if (this.IsChange)
            {
                //修改状态
                this.simpleButton1.Click += new EventHandler(simpleButton1_Click2);
                simpleButton2.Click += new EventHandler(simpleButton2_Click2);
            }
            else
            {
                this.simpleButton1.Click += new EventHandler(simpleButton1_Click1);
                simpleButton2.Click += new EventHandler(simpleButton2_Click1);
            }

            //读取行政区域数据
            LoadAreaData();
            this.Bind();
            //(this.cEntitySuomanagerBindingSource.Current as CEntitySuomanager).PROVINCE = "610000";
            this.cEntitySuomanagerBindingSource.ResetCurrentItem();
        }

        DataSet ds = null;
        /// <summary>
        /// 读取汇总分析文件
        /// </summary>
        public void LoadAreaData()
        {

            //默认加载两种汇总分析模板2012扣劳保与2012不扣劳保
            string f = APP.Application.Global.AppFolder + "config\\area.are";
            ds = GOLDSOFT.QDJJ.COMMONS.CFiles.Deserialize(f) as DataSet;
            DataView CView = ds.Tables["city"].DefaultView;
            DataView PView = ds.Tables["province"].DefaultView;
            DataView AView = ds.Tables["area"].DefaultView;
            this.cbx_PROVINCE.Properties.DataSource = PView;
            this.cbx_PROVINCE.Properties.DisplayMember = "province";
            this.cbx_PROVINCE.Properties.ValueMember = "provinceID";
            //this.cbx_PROVINCE.SelectedText = this.cbx_PROVINCE.Properties.GetDataSourceValue("province", 0).ToString();
            //provinceID
            object obj = this.cbx_PROVINCE.Properties.GetDataSourceValue("provinceID", 26);
            if (obj != null)
            {
                this.cbx_PROVINCE.EditValue = obj;
            }
        }

        private void cbx_PROVINCE_EditValueChanged(object sender, EventArgs e)
        {
            DataView CView = ds.Tables["city"].DefaultView;
            CView.RowFilter = string.Format(" father = {0} ", this.cbx_PROVINCE.GetColumnValue("provinceID"));
            this.cbx_CITY.Properties.DataSource = CView;
            this.cbx_CITY.Properties.DisplayMember = "city";
            this.cbx_CITY.Properties.ValueMember = "cityID";
            //this.cbx_CITY.SelectedText = this.cbx_CITY.Properties.GetDataSourceValue("city", 0).ToString();
            object obj = this.cbx_CITY.Properties.GetDataSourceValue("cityID", 0);
            if (obj != null)
            {
                this.cbx_CITY.EditValue = obj;
            }
            else
            {
                this.cbx_AREA.Properties.DataSource = null;
            }
        }

        private void cbx_CITY_EditValueChanged(object sender, EventArgs e)
        {
            DataView CView = ds.Tables["area"].DefaultView;
            CView.RowFilter = string.Format(" father = {0} ", this.cbx_CITY.GetColumnValue("cityID"));
            this.cbx_AREA.Properties.DataSource = CView;
            this.cbx_AREA.Properties.DisplayMember = "area";
            this.cbx_AREA.Properties.ValueMember = "areaID";
            object obj = this.cbx_AREA.Properties.GetDataSourceValue("areaID", 0).ToString();
            if (obj != null)
            {
                this.cbx_AREA.EditValue = obj;
            }
        }



        private void labelControl6_Click(object sender, EventArgs e)
        {

        }



    }
}