using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using ZiboSoft.Commons.Common;
using System.Net;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI.Class
{
    /// <summary>
    /// 功能:发送邮件
    /// 作者:付强
    /// 日期:2013年6月19日
    /// </summary>
    public static class SendMailUtil
    {


        public static void SendMail(Exception ex)
        {
            try
            {
                SendMail(ex.Message + ex.StackTrace);
            }
            catch (Exception)
            {}

        }
        public static void SendMail(string body)
        {
            string host = CSystem.GetAppConfig("host");
            string from = CSystem.GetAppConfig("from");
            string password = CSystem.GetAppConfig("password");
            string to = CSystem.GetAppConfig("to");
            string cc = CSystem.GetAppConfig("cc");

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;
            smtp.Host = host;
            smtp.Port = 25;
            smtp.UseDefaultCredentials = true;

            smtp.Credentials = new NetworkCredential(from, password);

            MailMessage mail = new MailMessage();
            mail.Priority = MailPriority.High;

            mail.Subject = "清单计价系统异常邮件";
            mail.SubjectEncoding = Encoding.GetEncoding("GB2312");

            mail.From = new MailAddress(from, "清单计价系统异常邮件", Encoding.GetEncoding("GB2312"));                                  
            mail.CC.Add(cc);
            mail.To.Add(to);
            mail.BodyEncoding = Encoding.GetEncoding("GB2312");
            mail.IsBodyHtml = false;
            string jmLock = APP.GoldSoftClient.CurrentCustom.JMLOCK;
            mail.Body = jmLock + "\r\n" + body;

            smtp.Send(mail);
        }
    }
}
