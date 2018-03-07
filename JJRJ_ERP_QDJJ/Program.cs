using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.UI.BaseInformation;
using GOLDSOFT.QDJJ.UI.Client;
using System.Diagnostics;
using GOLDSOFT.QDJJ.UI.Class;
using System.Net.Sockets;

namespace GOLDSOFT.QDJJ.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //try
            //{
                CheckRunning();

                appRun(args);
            //}
            //catch (SocketException ex)
            //{

            //    if (ex.ErrorCode == 10061)
            //    {
            //        MessageBox.Show("金建服务未启动，程序将退出！", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
            //    else
            //    {
            //        try
            //        {
            //            SendMailUtil.SendMail(ex);
            //        }
            //        catch { }
            //        MessageBox.Show("连接服务器失败，服务器不可用！", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    //MessageBox.Show(ex.Message + "---" + ex.StackTrace.ToString());

            //}
            //catch (Exception ex)
            //{
            //    try
            //    {
            //        SendMailUtil.SendMail(ex);
            //    }
            //    catch { }
            //    MessageBox.Show("操作出现异常，请联系管理人员,程序将退出。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    throw ex;

            //    //Application.Exit();
            //}
            //finally {
            //    //string processName = "GoldSoftHost";
            //    //Process[] processes = Process.GetProcessesByName(processName);
            //    //foreach (Process process in processes)
            //    //{
            //    //    if (process.ProcessName.Equals(processName))
            //    //        process.Kill();
            //    //}
            //}
        }

        static void appRun(string[] args)
        {
            //DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();

            if (!DevExpress.Skins.SkinManager.AllowFormSkins)
                DevExpress.Skins.SkinManager.EnableFormSkins();

            // DevExpress.Skins.SkinManager.DefaultSkinName = "iMaginary";
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            //Control.CheckForIllegalCrossThreadCalls = false;
            Application.ThreadExit += new EventHandler(Application_ThreadExit);

            //启动服务
            Process pro = Process.Start(string.Format("{0}service\\GoldSoftHost.exe", AppDomain.CurrentDomain.BaseDirectory));
            loginForm form = new loginForm();

            //开启验证逻辑
            if (form.ShowDialog() == DialogResult.OK)
            {
                //如果存在路径则直接打开
                ApplicationForm appForm = null;
                if (args.Length > 0)
                {

                    FileInfo info = new FileInfo(args[0].ToString());
                    appForm = new ApplicationForm(info);
                }
                else
                {
                    appForm = new ApplicationForm();
                }
                // DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("iMaginary");

                //try
                //{
                    Application.Run(appForm);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("操作出现异常，请联系管理人员,程序将退出。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    Application.Exit();
                //}
            }
            //Application.Exit();        
        }
        static void Application_ThreadExit(object sender, EventArgs e)
        {
            string processName = "GoldSoftHost";
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                if (process.ProcessName.Equals(processName))
                    process.Kill();
            }
        }

       
        /// <summary>
        /// 数据加载操作
        /// </summary>
        /*static bool Enter()
        {
            APP.Init();
            //开始验证数据
            //添加事件            
            //设置全局工作目录
            APP.Application.Global.AppFolder = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            APP.Application.Global.Init();
            APP.InitCompatle();
            //成功初始化开始其他进程
            return doSecurity();
        }

        static bool doSecurity()
        {
            if (APP.GoldSoftClient.Login() == 0)
            {
                return true;
            }
            else
            {
                MsgBox.Alert(APP.GoldSoftClient.ErrorInfmation);
                return false;
            }
        }*/

        /// <summary>
        /// 功能:确保本程序只能有一个实例在运行
        /// 作者:付强
        /// 日期:2013年6月14日
        /// </summary>
        static void CheckRunning()
        {
            return;
            int count = 0;
            Process currentProcess = Process.GetCurrentProcess();

            string currentFileName = currentProcess.MainModule.FileName;

            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);

            foreach (Process process in processes)
            {
                if (process.ProcessName.Equals(currentProcess.ProcessName))
                    count++;
            }
            if (count > 1)
            {
                MessageBox.Show("程序已经运行！", "金建软件提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                currentProcess.Kill();
            }

        }

    }
}
