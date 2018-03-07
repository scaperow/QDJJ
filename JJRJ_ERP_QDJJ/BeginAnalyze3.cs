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

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BeginAnalyze3 : CBaseForm
    {
        public string FABH = "";
        public _Business pInfo;
        public Container _sender;
        public BeginAnalyze3()
        {
            InitializeComponent();


        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("该操作将会扣除您 " + APP.GoldSoftClient.KCJF.ToString() + " 积分！", "金建软件", MessageBoxButtons.OKCancel);
            //if (result == DialogResult.OK)
            //{
            //    string wb_web = CSystem.GetAppConfig("wb");
            //    bool kcResult = false;
                //try
                //{
                    //kcResult = WebServiceHelper.InvokeMethod<bool>(wb_web, "TBKouChuJF", new Object[] { APP.GoldSoftClient.CurrentCustom.JMLOCK, APP.GoldSoftClient.KCJF });
                    //if (kcResult)
                    //{
                    //    int jiFen = WebServiceHelper.InvokeMethod<int>(wb_web, "getJiFenJL", APP.GoldSoftClient.CurrentCustom.JMLOCK);
                    //    WebServiceHelper.InvokeMethod<bool>(wb_web, "TBRecord", new Object[] { pInfo.Current.StructSource.ModelProject.Rows[0]["Name"].ToString(), APP.GoldSoftClient.CurrentCustom.JMLOCK,"",
                    //                                                                    APP.GoldSoftClient.PBBF.ToString(),APP.GoldSoftClient.ZZJ.ToString(),APP.GoldSoftClient.CSXMHJ.ToString(),APP.GoldSoftClient.FBFXHJ.ToString(),
                    //                                                                    APP.GoldSoftClient.SXKZHJ.ToString(),APP.GoldSoftClient.CSXMHJ.ToString(),APP.GoldSoftClient.My_Count.ToString(),
                    //                                                                    APP.GoldSoftClient.Other_Count.ToString(),APP.GoldSoftClient.QuGaoQuDi.ToString(),this.FABH,jiFen.ToString(),APP.GoldSoftClient.KCJF.ToString(),"调标成功",DateTime.Now.ToString()});

                        BeginAnalyze4 begin4 = new BeginAnalyze4();
                        begin4.MdiParent = this.MdiParent;
                        begin4._sender = this._sender;
                        begin4.ShowDialog();
                        this.Close();
                    //}
                    //else
                    //{
                    //    MsgBox.Alert("积分扣除失败，请重试！");
                    //    return;
                    //}
                //}
                //catch (Exception)
                //{
                //    //MsgBox.Alert("网络访问失败！");
                //    //this.Close();
                //    //return;
                //}
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BeginAnalyze3_Load(object sender, EventArgs e)
        {
            this.lblFABH.Text = this.FABH;
        }
    }
}