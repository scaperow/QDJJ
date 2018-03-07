using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public class ServiceInstall
    {
        public ServiceInstall()
        {

        }

        public void InstallService(IDictionary stateSaver, string filepath)
        {
           a: try
            {
                ServiceController service = new ServiceController("金建软件服务");
                if (!ServiceIsExisted("金建软件服务"))
                {
                    //Install Service
                    AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
                    myAssemblyInstaller.UseNewContext = true;
                    myAssemblyInstaller.Path = filepath;
                    myAssemblyInstaller.Install(stateSaver);
                    myAssemblyInstaller.Commit(stateSaver);
                    myAssemblyInstaller.Dispose();
                    //--Start Service
                    service.Start();
                }
                else
                {
                    UnInstallService(filepath);
                    goto a;
                        
                    //if (service.Status != ServiceControllerStatus.Running && service.Status != System.ServiceProcess.ServiceControllerStatus.StartPending)
                    //{
                    //    service.Start();
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception("installServiceError\n" + ex.Message);
            }
        }
        //二、卸载windows服务：
        public void UnInstallService(string filepath)
        {
            try
            {
                if (ServiceIsExisted("金建软件服务"))
                {
                    //UnInstall Service
                    AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
                    myAssemblyInstaller.UseNewContext = true;
                    myAssemblyInstaller.Path = filepath;
                    myAssemblyInstaller.Uninstall(null);
                    myAssemblyInstaller.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("unInstallServiceError\n" + ex.Message);
            }
        }
        //三、判断window服务是否存在：
        public bool ServiceIsExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        //四、启动服务：
        public void StartService(string serviceName)
        {
            if (ServiceIsExisted(serviceName))
            {
                System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
                if (service.Status != System.ServiceProcess.ServiceControllerStatus.Running && service.Status != System.ServiceProcess.ServiceControllerStatus.StartPending)
                {
                    service.Start();
                    for (int i = 0; i < 60; i++)
                    {
                        service.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                        {
                            break;
                        }
                        if (i == 59)
                        {
                            // throw new Exception(startServiceError.Replace("$s$", serviceName));
                        }
                    }
                }
            }
        }
        //五、停止服务：
        public void StopService(string serviceName)
        {
            if (ServiceIsExisted(serviceName))
            {
                System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
                if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    service.Stop();
                    for (int i = 0; i < 60; i++)
                    {
                        service.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        if (service.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                        {
                            break;
                        }
                        if (i == 59)
                        {
                            //throw new Exception(StopServiceError.Replace("$s$", serviceName));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 判断服务是否开启
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public bool ServiceIsStarted(string serviceName)
        {
            ServiceController cs = new ServiceController();
            cs.MachineName = "localhost "; //主机名称
            cs.ServiceName = serviceName; //服务名称
            cs.Refresh();
            if (cs.Status == ServiceControllerStatus.Running)
            {
                //判断已经运行
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
