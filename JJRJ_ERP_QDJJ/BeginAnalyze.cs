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
using System.Collections;
using DevExpress.XtraBars.Ribbon;
using Bidserver;
using Newtonsoft.Json;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BeginAnalyze : CBaseForm
    {
        private float limitPrice;
        private float cuoShi;
        private float qgqd;

        public _Business pInfo;
        public ArrayList DataSource;
        public Container _sender;

        public BeginAnalyze()
        {
            InitializeComponent();

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Record(int cost, string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                var wb_web = CSystem.GetAppConfig("wb");

                //WebServiceHelper.InvokeMethod<bool>(wb_web, "TBRecord", new Object[] { 
                //    pInfo.Current.StructSource.ModelProject.Rows[0]["Name"].ToString(), 
                //    APP.GoldSoftClient.CurrentCustom.JMLOCK,"",     
                //    APP.GoldSoftClient.PBBF.ToString(),
                //    APP.GoldSoftClient.ZZJ.ToString(),
                //    APP.GoldSoftClient.CSXMHJ.ToString(),
                //    APP.GoldSoftClient.FBFXHJ.ToString(),             
                //    APP.GoldSoftClient.SXKZHJ.ToString(),
                //    APP.GoldSoftClient.CSXMHJ.ToString(),
                //    APP.GoldSoftClient.My_Count.ToString(),                       
                //    APP.GoldSoftClient.Other_Count.ToString(),
                //    APP.GoldSoftClient.QuGaoQuDi.ToString(),
                //    "",
                //    cost.ToString(),
                //    APP.GoldSoftClient.KCJF.ToString(),
                //    reason,
                //    DateTime.Now.ToString()});
                //MsgBox.Alert(reason);
                MessageBox.Show(reason);
            }
        }

        private bool Validate(int cost, out Dictionary<string, object> result)
        {
            result = new Dictionary<string, object>();
            if (cost < 0)
            {
                return false;
            }

            if (this.txtLimitPrice.Text.Trim() == "")
            {
                MsgBox.Alert("上限控制价不能为空!");
                this.txtLimitPrice.Focus();
                return false;
            }

            decimal limitPrice = 0;
            decimal.TryParse(this.txtLimitPrice.Text.Trim(), out limitPrice);

            var rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='ZZJ' and ID = 0");
            decimal totalProjectFee = 0;
            if (rows.Length > 0)
            {
                totalProjectFee = decimal.Parse(rows[0]["value"].ToString());
            }

            rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='CSXMF' and ID = 0");
            decimal totalMeasureFee = 0;
            if (rows.Length > 0)
            {
                totalMeasureFee = decimal.Parse(rows[0]["value"].ToString());
            }

            decimal totalSubsegmentFee = 0;
            rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='FBFXHJ' and ID = 0");
            if (rows.Length > 0)
            {
                totalSubsegmentFee = decimal.Parse(rows[0]["value"].ToString());
            }

            rows = this.pInfo.Current.StructSource.ModelSubSegments.Select("LB='清单'");
            var quotaCount = rows.Length;

            var lockNumber = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;

            var args = new
            {
                limitPrice = limitPrice,
                totalProjectFee = totalProjectFee,
                totalMeasureFee = totalMeasureFee,
                quotaCount = quotaCount,
                lockNumber = lockNumber,
                totalSubsegmentFee = totalSubsegmentFee,
                publish = APP.GoldSoftClient.Invite_Publish,
                mines = APP.GoldSoftClient.My_Count
            };


            Bid bid = new Bid();

            result = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(bid.Check(JsonConvert.SerializeObject(args))));
            if (result == null)
            {
                MessageBox.Show("服务器出现错误");
                return false;
            }

            var error = result["error"] + "";
            if (string.IsNullOrEmpty(error) == false)
            {
                Record(cost, error);
                return false;
            }

            APP.GoldSoftClient.KCJF = int.Parse(result["cost"] + "");
            APP.GoldSoftClient.ZZJ = totalProjectFee;
            APP.GoldSoftClient.FBFXHJ = totalSubsegmentFee;
            APP.GoldSoftClient.CSXMHJ = totalMeasureFee;
            APP.GoldSoftClient.QDZJ_TB = quotaCount;


            return true;

            //rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='ZZJ' and ID = 0");
            //if (rows.Length <= 0)
            //{
            //    Record(cost, "总造价为0，项目文件不符合调标要求！");
            //    return false;
            //}


            //rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='FBFXHJ' and ID = 0");
            //if (rows.Length > 0)
            //{

            //}


            //if (decimal.Parse(this.txtLimitPrice.Text.Trim()) < APP.GoldSoftClient.ZZJ)
            //{
            //    Record(cost, "上限控制价不能小于总造价!");
            //    this.txtLimitPrice.Focus();
            //    return false;
            //}

            //rows = this.pInfo.Current.StructSource.ModelProjVariable.Select("Key='CSXMF' and ID = 0");
            ////rows = this.pInfo.Current.StructSource.ModelProjMetaanalysis.Select("");
            //if (rows.Length <= 0)
            //{
            //    Record(cost, "措施项目合计为0，项目文件不符合调标要求！");
            //    return false;
            //}


            //decimal xs = Math.Abs(decimal.Parse(APP.GoldSoftClient.QDJJTB.Tables["TBKZ"].Rows[0]["CSFBL"].ToString()));
            //if (APP.GoldSoftClient.CSXMHJ <= (APP.GoldSoftClient.ZZJ * xs))//TBKZ
            //{

            //    Record(cost, "措施项目合计必须大于总造价乘以 " + xs.ToString() + "， 项目文件不符合调标要求！");
            //    return false;
            //}


            //rows = this.pInfo.Current.StructSource.ModelSubSegments.Select("LB='清单'");
            //int qdsl = int.Parse(APP.GoldSoftClient.QDJJTB.Tables["TBKZ"].Rows[0]["QDSL"].ToString());
            //if (rows.Length < qdsl)
            //{
            //    Record(cost, "单位工程至少包含 " + qdsl.ToString() + " 清单个数不符合调标要求!");
            //    return false;
            //}


            //if (APP.GoldSoftClient.QDJJTB.Tables["TBKZ"].Rows[0]["KZSH"].ToString().Contains(APP.GoldSoftClient.GlodSoftDiscern.CurrNo))
            //{
            //    Record(cost, "当前锁号没有权限进行调标操作！");
            //    this.Close();
            //    return false;
            //}



            return true;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string wb_web = CSystem.GetAppConfig("wb");
            APP.GoldSoftClient.PBBF = this.rdoZH.Checked ? "综合评估法" : "合理低价法";

            int cost = 0;

            try
            {
                cost = WebServiceHelper.InvokeMethod<int>(wb_web, "getJiFenJL", APP.GoldSoftClient.CurrentCustom.JMLOCK);
            }
            catch
            {
                MsgBox.Alert("获取积分时出现错误，请重试");
                return;
            }

            Dictionary<string, object> result = null;
            if (Validate(cost, out result))
            {
                BeginAnalyze1 begin1 = new BeginAnalyze1(result);
                begin1.MdiParent = this.MdiParent;
                begin1.pInfo = this.pInfo;
                begin1.DataSource = this.DataSource;
                begin1._sender = this._sender;
                begin1.ShowDialog();
                if (this.rdoZH.Checked)
                    APP.GoldSoftClient.TBMethod = false;
                else
                    APP.GoldSoftClient.TBMethod = true;

                this.Close();
            }
        }

        private void BeginAnalyze_Load(object sender, EventArgs e)
        {
            if (!APP.GoldSoftClient.Invite_Publish)
            {
                this.txtOtherCount.Text = "0";
                this.txtMyCount.Text = APP.GoldSoftClient.My_Count.ToString();
            }
            else
            {
                this.txtOtherCount.Text = APP.GoldSoftClient.Other_Count.ToString();
                this.txtMyCount.Text = APP.GoldSoftClient.My_Count.ToString();
            }
        }

        private void txtLimitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLimitPrice_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.txtLimitPrice.Text.Trim(), out limitPrice))
            {
                this.txtLimitPrice.Text = "";
                this.txtLimitPrice.Focus();
            }
            else
            {
                APP.GoldSoftClient.LimitedPrice = limitPrice;
            }
        }

        private void txtCuoShi_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.txtCuoShi.Text.Trim(), out cuoShi))
            {
                this.txtCuoShi.Text = "";
                this.txtCuoShi.Focus();
            }
            else
            {
                APP.GoldSoftClient.LimitedCuoShi = cuoShi;
            }
        }

        private void txtQGQD_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.txtQGQD.Text.Trim(), out qgqd))
            {
                this.txtQGQD.Text = "";
                this.txtQGQD.Focus();
            }
            else
            {
                APP.GoldSoftClient.QuGaoQuDi = qgqd;
            }

        }
        private void rdoLow_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}