using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.UI.Client;
using System.Threading;
using System.Diagnostics;
using GOLDSOFT.QDJJ.UI.BaseInformation;
using GOLDSOFT.SERVICES.IServicesObject;
using System.IO;
using ZiboSoft.Commons.Common;
using GoldSoft.CICM.UI;
//using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        ///  客户端程序
        /// </summary>
        

        private int ResCode = -1;
        
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            APP.Init();

            //首先加密狗验证读取加密狗信息
            APP.GoldSoftClient.FirstLogin();
            if (APP.GoldSoftClient.ClientResult.IsLoginSucess)
            {
                switch (APP.GoldSoftClient.ClientResult.Fun)
                {
                    case 1:
                        myflash.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\config\\专业版.swf";
                        break;
                    case 2:
                        myflash.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\config\\旗舰版.swf";
                        break;
                    case 3:
                        myflash.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\config\\网络版.swf";
                        break;
                    default:
                        myflash.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\config\\领先版.swf";
                        break;
                }
            }
            else
            {
                myflash.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\config\\领先版.swf";
            }
            myflash.Play();

            //this.BackgroundImage = GOLDSOFT.QDJJ.UI.Properties.Resources.登陆2;
            //this.BackgroundImage = GOLDSOFT.QDJJ.UI.Properties.Resources.登陆_旗舰版3;
            //系统入口程序(数据加载 全局应用程序配置)
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //doLoadData();
            this.timer1.Stop();
            if (doLoadData())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 数据加载操作
        /// </summary>
        private bool doLoadData()
        {

            //开始验证数据
            //添加事件            
            //设置全局工作目录
            APP.Application.Global.AppFolder = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            APP.Application.Global.Init();
            APP.InitCompatle();
            //功能修改，判断加密狗是否工作正常，并且通过验证，无论成功与否 都进入到主界面
            doSecurity();
            return true;
        }

        /// <summary>
        ///  仅仅验证，无论成功失败都进入到主操作区域页面
        /// </summary>
        /// <returns></returns>
        private bool doSecurity()
        {
            
            //用户登录逻辑
            int result = APP.GoldSoftClient.Login();
            if (result == -11)
            {
                MsgBox.Alert("由于您的积分为负数，软件不能使用！请先购买积分！");
                Application.Exit();
            }
            //找不到服务 或者服务异常 直接关闭系统
            if (result == ResultConst.SERVER_SERVER_ERROR)
            {
                Application.Exit();
            }

            if (APP.GoldSoftClient.ClientResult.Custom_IsFirst)
            {
                //第一次数据调用
                CustomInfoForm form = new CustomInfoForm();
                form.ShowDialog();
                return false;
            }
            return true;

            //if (result == ResultConst.SERVER_SUCCESS)
            //{
            //    APP.GoldSoftClient.IsFirstClient = true;
            //    return true;
            //}
            //else if (result == ResultConst.SERVER_CUSTOM_FIRST_INIT)
            //{
            //    APP.GoldSoftClient.ClientResult.Result = _ClientResult.Client_Result_NoInit;
            //    //第一次数据调用
            //    CustomInfoForm form = new CustomInfoForm();
            //    form.ShowDialog();
            //    APP.GoldSoftClient.IsFirstClient = false; 
            //    return false;
            //}
            //else
            //{
            //    APP.GoldSoftClient.IsFirstClient = false;
            //    //MsgBox.Alert(APP.GoldSoftClient.ErrorInfmation);
            //    return false;
            //}
            
        }
    }
}