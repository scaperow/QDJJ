using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Diagnostics;


namespace InstallService
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);


            //System.Diagnostics.Process.Start("notepad.exe");
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);

            Assembly asm = Assembly.GetExecutingAssembly();
            String path = asm.Location.Remove(asm.Location.LastIndexOf("\\"));

            //System.Diagnostics.Process.Start(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe  C:\Program Files\清单计价2013\金建服务\GOLDSOFT.SERVICES.EXE");
            //System.Diagnostics.Process.Start(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe  " + path + @"\金建服务\GOLDSOFT.SERVICES.EXE");

            System.Diagnostics.Process p = new Process();
            p.StartInfo.FileName = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe";
            p.StartInfo.Arguments = path + @"\金建服务\GOLDSOFT.SERVICES.EXE";
            p.StartInfo.UseShellExecute = false; 
            p.StartInfo.CreateNoWindow = false; 
            p.StartInfo.RedirectStandardOutput = true; 
            p.Start();

            //System.Diagnostics.Process.Start("net start 金建软件服务");

            //System.Diagnostics.Process.Start(path + "\\金建服务\\安装.bat");

        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            Assembly asm = Assembly.GetExecutingAssembly();
            String path = asm.Location.Remove(asm.Location.LastIndexOf("\\"));

            //System.Diagnostics.Process.Start("C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727\\InstallUtil.exe ", "-u" + path + "\\金建服务\\GOLDSOFT.SERVICES.EXE");
            //System.Diagnostics.Process.Start("net start 金建软件服务");

            System.Diagnostics.Process p = new Process();
            p.StartInfo.FileName = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe";
            p.StartInfo.Arguments = @"-u " + path + @"\金建服务\GOLDSOFT.SERVICES.EXE";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false ;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start(); 
            //System.Diagnostics.Process.Start(path + "\\金建服务\\卸载.bat");
        }

    }
}
