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
    public partial class CustomInfoForm : DevExpress.XtraEditors.XtraForm
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
                this.textEdit2.Text = System.DateTime.Now.ToString();
                string jmLock = APP.GoldSoftClient.CurrentCustom.JMLOCK;
                //调用远程方法 获取积分
                string wb_web = CSystem.GetAppConfig("wb");
                this.textEdit4.Text = CustomBAL.getJF(wb_web, jmLock);
                this.cEntitySuomanagerBindingSource.DataSource = APP.GoldSoftClient.CurrentCustom;
            }
        }

        public CustomInfoForm()
        {
            InitializeComponent();
        }

        public CustomInfoForm(bool isChange)
        {
            this.IsChange = isChange;
            InitializeComponent();
        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
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



        public DataTable dt = null;
        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CUSTOMERNAME.Text.Trim()))
            {
                MessageBox.Show("姓名不能为空", "金建软件");
                txt_CUSTOMERNAME.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textEdit1.Text.Trim()))
            {
                MessageBox.Show("锁号不能为空", "金建软件");
                textEdit1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                MessageBox.Show("注册日期不能为空", "金建软件");
                textEdit2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_ZCDWNAME.Text.Trim()))
            {
                MessageBox.Show("单位名称不能围为空", "金建软件");
                txt_ZCDWNAME.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textEdit3.Text.Trim()))
            {
                MessageBox.Show("单位性质不能围为空", "金建软件");
                textEdit3.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_TEL.Text.Trim()) && string.IsNullOrEmpty(txtMovTel.Text.Trim()))
            {
                MessageBox.Show("电话或手机必须填一个", "金建软件");
                txtMovTel.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textEdit6.Text.Trim()))
            {
                MessageBox.Show("职务不能为空", "金建软件");
                textEdit6.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_PROFESSION.Text.Trim()))
            {
                MessageBox.Show("预算专业不能为空", "金建软件");
                txt_PROFESSION.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtIdCard.Text.Trim()))
            {
                MessageBox.Show("身份证号不能为空", "金建软件");
                txtIdCard.Focus();
                return;
            }


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

      


        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click2(object sender, EventArgs e)
        {

            //建立表结构
            createTable();
            //调用借口方法
            //ServiceReference1.WebSuoSoapClient my_webservice = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
            //获取DataTable信息
            DataTable dt = getTable();
            if (dt != null)
            {
                string wb_web = CSystem.GetAppConfig("wb");

                bool sige = CustomBAL.updateBDsuoManager(wb_web, dt);
                if (sige)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改不成功");
                }

            }
            else
            {
                MessageBox.Show("表为空");
            }



            /////获取输入信息
            //CEntitySuomanager info = this.cEntitySuomanagerBindingSource.Current as CEntitySuomanager;
            //info.ISFIRST = "1";
            //int result = APP.GoldSoftClient.TryUpdateCustomer(info);
            //if (result == ResultConst.SERVER_SUCCESS)
            //{
            //    //成功
            //    MsgBox.Alert("资料已经提交成功等待审核");
            //}
            //else
            //{
            //    MsgBox.Alert("提交失败，稍后尝试！");
            //}
        }
        private DataTable getTable()
        {
            // 获取输入信息
            CEntitySuomanager info = this.cEntitySuomanagerBindingSource.Current as CEntitySuomanager;
            DataRow dr = dt.NewRow();
            dr["interlock"] = info.INTERLOCK;
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
            dr["status"] = info.STATUS;
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
        /// 创建表结构
        /// </summary>
        /// <returns></returns>
        private void createTable()
        {
            dt = new DataTable();
            dt.TableName = "suoUpdateLog";
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
        }

        private void CustomInfoForm_Load(object sender, EventArgs e)
        {
            //加载窗体的时候调用的函数类型
            if (this.IsChange)
            {
                //修改状态
                this.simpleButton1.Click += new EventHandler(simpleButton1_Click2);
                simpleButton2.Click +=new EventHandler(simpleButton2_Click2);
            }
            else
            {
                this.simpleButton1.Click += new EventHandler(simpleButton1_Click1);
                simpleButton2.Click += new EventHandler(simpleButton2_Click1);
            }
            
 
            //读取行政区域数据
            LoadAreaData();
            this.Bind();
            (this.cEntitySuomanagerBindingSource.Current as CEntitySuomanager).PROVINCE = "610000";
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


            DataView CView = getPdt("city").DefaultView;
            DataView PView = getPdt("province").DefaultView;
            DataView AView = getPdt("area").DefaultView;
            this.cbx_PROVINCE.Properties.DataSource = PView;
            this.cbx_PROVINCE.Properties.DisplayMember = "名称";
            this.cbx_PROVINCE.Properties.ValueMember = "编号";
            //this.cbx_PROVINCE.SelectedText = this.cbx_PROVINCE.Properties.GetDataSourceValue("province", 0).ToString();
            //provinceID
            object obj = this.cbx_PROVINCE.Properties.GetDataSourceValue("编号", 26);
            if (obj != null)
            {
                this.cbx_PROVINCE.EditValue = obj;
            }
        }

        private DataTable getPdt(string tableName)
        {
            DataTable dt = ds.Tables[tableName];
            DataTable pdt = createPDT(tableName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = pdt.NewRow();
                if (tableName.Equals("province"))
                {
                    dr["编号"] = dt.Rows[i]["provinceID"];
                    dr["名称"] = dt.Rows[i]["province"];
                }
                else if (tableName.Equals("city"))
                {
                    dr["编号"] = dt.Rows[i]["cityID"];
                    dr["名称"] = dt.Rows[i]["city"];
                    dr["父编号"] = dt.Rows[i]["father"];
                }
                else
                {
                    dr["编号"] = dt.Rows[i]["areaID"];
                    dr["名称"] = dt.Rows[i]["area"];
                    dr["父编号"] = dt.Rows[i]["father"];
                }



                pdt.Rows.Add(dr);
            }
            return pdt;
        }

        private DataTable createPDT(string tableName)
        {
            DataTable dt = new DataTable();
            if (tableName.Equals("province"))
            {
                dt.Columns.Add("编号", typeof(System.Int64));
                dt.Columns.Add("名称", typeof(System.String));
            }
            else if (tableName.Equals("city"))
            {
                dt.Columns.Add("编号", typeof(System.Int64));
                dt.Columns.Add("名称", typeof(System.String));
                dt.Columns.Add("父编号", typeof(System.Int64));
            }
            else 
            {
                dt.Columns.Add("编号", typeof(System.Int64));
                dt.Columns.Add("名称", typeof(System.String));
                dt.Columns.Add("父编号", typeof(System.Int64));
            }
            return dt;
        }

        private void cbx_PROVINCE_EditValueChanged(object sender, EventArgs e)
        {
            DataView CView = getPdt("city").DefaultView;
            CView.RowFilter = string.Format(" 父编号 = {0} ", this.cbx_PROVINCE.GetColumnValue("编号"));
            this.cbx_CITY.Properties.DataSource = CView;
            this.cbx_CITY.Properties.DisplayMember = "名称";
            this.cbx_CITY.Properties.ValueMember = "编号";
            //this.cbx_CITY.SelectedText = this.cbx_CITY.Properties.GetDataSourceValue("city", 0).ToString();
            object obj = this.cbx_CITY.Properties.GetDataSourceValue("编号", 0);
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
            DataView CView = getPdt("area").DefaultView;
            CView.RowFilter = string.Format(" 父编号 = {0} ", this.cbx_CITY.GetColumnValue("编号"));
            this.cbx_AREA.Properties.DataSource = CView;
            this.cbx_AREA.Properties.DisplayMember = "名称";
            this.cbx_AREA.Properties.ValueMember = "编号";
            object obj = this.cbx_AREA.Properties.GetDataSourceValue("编号", 0).ToString();
            if (obj != null)
            {
                this.cbx_AREA.EditValue = obj;
            }  
        }

        private void txt_ADDRESS_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void txt_CUSTOMERNAME_EditValueChanged(object sender, EventArgs e)
        {

        }
        
    }
}