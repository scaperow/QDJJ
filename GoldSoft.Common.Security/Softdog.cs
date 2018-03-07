using GoldSoft.Common.Model;
using JJSOFT.LIVING;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GoldSoft.Common.Security
{
    public class Softdog
    {
        private const int DogCode = 0x53584a4a;
        //public static object Start()
        //{
        //    var message = "";
        //    var location = string.Format("{0}service\\GoldSoftHost.exe", AppDomain.CurrentDomain.BaseDirectory);
        //    if (Running() == false)
        //    {
        //        if (!File.Exists(location))
        //        {
        //            message = "找不到系统文件";
        //            goto error;
        //        }

        //        Process.Start(location);
        //    }
        //    return new
        //    {
        //        Error = false
        //    };

        //error:
        //    return new
        //    {
        //        Error = true,
        //        Message = message
        //    };
        //}
        //public static bool IsRunning()
        //{
        //    var processName = "GoldSoftHost";
        //    var processes = Process.GetProcessesByName(processName);
        //    foreach (var process in processes)
        //    {
        //        if (process.ProcessName.Equals(processName))
        //            return true;
        //    }

        //    return false;
        //}
        public static bool Clear()
        {
            var processName = "GoldSoftHost";
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                if (process.ProcessName.Equals(processName))
                    process.Kill();
            }

            return true;
        }
        public static SoftdogProtocol ValidateLocal()
        {
            var message = "验证不通过";
            var result = new SoftdogProtocol();
            var pwd = "JJSoft0912";
            var driver = new LivingDog();
            var hardware = default(LivingDog.LIV_hardware_info);
            var status = 0;

            try
            {
                status = driver.Grand_OpenDog(DogCode, 0);
                hardware = driver.Grand_GetHardware_info();
                switch (hardware.RetCode)
                {
                    case 0:
                        if (driver.Grand_Passwd(1, pwd) == LivingDog.LIV_SUCCESS)
                        {
                            byte[] outByte = new byte[50];
                            if (driver.Grand_Read(1, outByte) == LivingDog.LIV_SUCCESS)
                            {
                                string strs = System.Text.ASCIIEncoding.Default.GetString(outByte);
                                //3.领先版  4是专业版 5是旗舰版 6是网络版
                                if (strs[3] == '1' || strs[4] == '1' || strs[5] == '1' || strs[6] == '1') //加密狗有效性验证
                                {
                                    goto success;
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            finally
            {
                driver.Grand_CloseDog();
            }

            result.Error = true;
            result.Message = message;
            return result;

        success:
            result.Success = true;
            result.SerialNumber = Encoding.Default.GetString(hardware.serialNumber);
            result.Error = false;
            return result;
        }
        
    }
}
