using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using Microsoft.Win32;
using GOLDSOFT.QDJJ.COMMONS;


namespace GOLDSOFT.QDJJ.UI
{
    [RunInstaller(true)]
    public partial class JJRJInstaller : Installer
    {
        ServiceInstall m_ServiceInstall = new ServiceInstall();

        string[] Extensions = {".jxmx",".jgcx",".zbs",".tbs",".bd" };
        public JJRJInstaller()
        {
            InitializeComponent();
        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
        protected override void OnCommitted(IDictionary savedState)
        {
           
            string path= this.Context.Parameters["targetdir"];
            for (int i = 0; i < Extensions.Length; i++)
            {
                RegistryAPP app = new RegistryAPP();
                app.APPKey = "QDJJ" + Extensions[i].ToUpper();
                app.DefaultIcon = path + (i + 1) + ".ico";
                app.AppPath = path + "JJRJ_ERP_QDJJ.exe";
                app.Extension = Extensions[i];
                Regist(app);
            }

            m_ServiceInstall.InstallService(savedState, path + "GOLDSOFT.SERVICES.exe");
            base.OnCommitted(savedState);
        }
        protected override void OnBeforeRollback(IDictionary savedState)
        {
            base.OnBeforeRollback(savedState);
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            string path = this.Context.Parameters["targetdir"];
            for (int i = 0; i < Extensions.Length; i++)
            {
                RegistryAPP app = new RegistryAPP();
                app.APPKey = "QDJJ" + Extensions[i].ToUpper();
                app.DefaultIcon = path + (i+1) + ".ico";
                app.AppPath = path + "JJRJ_ERP_QDJJ.exe";
                app.Extension = Extensions[i];
                URegist(app);
            }
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            //卸载之前 先卸载服务；
            string path = this.Context.Parameters["targetdir"];
            m_ServiceInstall.UnInstallService(path + "GOLDSOFT.SERVICES.exe");
            base.OnBeforeUninstall(savedState);
        }

        private void Regist(RegistryAPP app)
        {
            ToolKit.WriteApp(app.AppPath, app.DefaultIcon, app.APPKey);
            ToolKit.WriteRelate(app.Extension, app.APPKey);
        }
        private void URegist(RegistryAPP app)
        {
            ToolKit.DelRelate(app.APPKey);
            ToolKit.DelRelate(app.Extension);
        }
    }
    struct RegistryAPP
    {
      public  string APPKey;//应用程序的键值
      public string DefaultIcon;//默认文件的图标
      public string AppPath;//应用程序的路径
      public string Extension;//关联文件的后缀名
    }
}
