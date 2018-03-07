using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.UI
{

    /// <summary>
    /// 功能:确保本程序只能有一个实例在运行
    /// 作者:付强
    /// 日期:2013年6月14日
    /// </summary>
    public static class SingleInstance
    {
        private const int WS_SHOWNORMAL = -1;

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private static string runFlagFullName = null;

        private static Mutex mutex = null;


        static SingleInstance()
        { 
        }

        public static void CheckRunning()
        {
            int count = 0;
            Process currentProcess = Process.GetCurrentProcess();

            string currentFileName = currentProcess.MainModule.FileName;

            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            //string[] strExists;
            //string[] strCurrent = currentProcess.ProcessName.Split('.');

            foreach (Process process in processes)
            {
                //strExists = process.ProcessName.Split('.');

                //if(strExists[0].Equals(strCurrent[0]))
                if (process.ProcessName.Equals(currentProcess.ProcessName))
                {
                    count++;
                }
            }
            if (count > 1)
            {
                //DialogResult result;
                MessageBox.Show("程序已经运行！", "金建软件提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach(Process process in processes)
                {
                    process.Kill();
                }
            }

        }


        /// <summary>
        /// 获取应用程序进程实例,如果没有匹配进程，返回Null
        /// </summary>
        /// <returns></returns>
        public static Process GetRunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();

            string currentFileName = currentProcess.MainModule.FileName;

            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);

            foreach (Process process in processes)
            {
                if (process.MainModule.FileName.Equals(currentFileName))
                {
                    if (process.Id != currentProcess.Id)
                        return process;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取应用程序句柄，设置应用程序前台运行，并返回bool值
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);

            return SetForegroundWindow(instance.MainWindowHandle);
        }

        /// <summary>
        /// 获取窗口句柄，设置应用程序前台运行，并返回bool值，重载方法
        /// </summary>
        /// <returns></returns>
        public static bool HandleRunningInstance()
        {
            Process p = GetRunningInstance();

            if (p != null)
            {
                HandleRunningInstance(p);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取窗口句柄，设置应用程序前台运行，并返回bool值，重载方法
        /// </summary>
        /// <returns></returns>
        public static bool CreateMutex()
        {
            return CreateMutex(Assembly.GetEntryAssembly().FullName);
        }

        /// <summary>
        /// 创建应用程序进程Mutex
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CreateMutex(string name)
        {
            bool result = false;
            mutex = new Mutex(true,name, out result);
            return result;
        }

        /// <summary>
        /// 释放Mutex
        /// </summary>
        public static void ReleaseMutex()
        {
            if (mutex != null)
            {
                mutex.Close();
            }
        }

        /// <summary>
        /// 初始化程序运行标志，设置成功，返回true，已经设置返回false，设置失败将抛出异常
        /// </summary>
        /// <returns></returns>
        public static bool InitRunFlag()
        {
            if (File.Exists(RunFlag))
            {
                return false;
            }

            using (FileStream fs = new FileStream(RunFlag, FileMode.Create))
            {
                
            }
            return true;
        }

        /// <summary>
        /// 释放初始化程序运行标志，如果释放失败将抛出异常
        /// </summary>
        public static void DisposeRunFlag()
        {
            if (File.Exists(RunFlag))
            {
                File.Delete(RunFlag);
            }
        }

        /// <summary>
        /// 获取或设置程序运行标志，必须符合Windows文件命名规范
        /// 实现生成临时文件为依据，如果修改成设置注册表，那就不需要符合文件命名规范
        /// </summary>
        public static string RunFlag
        {
            get 
            {
                if (runFlagFullName == null)
                {
                    string assemblyFullName = Assembly.GetEntryAssembly().FullName;

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                    runFlagFullName = Path.Combine(path, assemblyFullName);

                }

                return runFlagFullName;
            }

            set
            {
                runFlagFullName = value;
            }
        }


    }
}
