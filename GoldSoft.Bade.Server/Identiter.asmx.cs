using GoldSoft.Identiter.Common;
using GoldSoft.Identiter.Core;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Server
{
    /// <summary>
    /// Identity 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Identiter : System.Web.Services.WebService
    {
        public static ILog Log = LogManager.GetLogger("Identiter");
        public string Check(string args)
        {

            var message = "服务器错误";
            object result;

            if (string.IsNullOrEmpty(args))
            {
                message = "参数不正确";
                goto error;
            }


            Excel[] list = null;
            try
            {
                list = JsonConvert.DeserializeObject<Excel[]>(args);
            }
            catch (Exception e)
            {
                Log.Error(e);
                goto error;
            }

            if (list == null)
            {
                message = "数据不正确";
                goto error;
            }

            var identity = new Identity(new RulesAdapter(Server.MapPath("~/rule.accdb")));
            var results = identity.IdentityQuotaOnly(ProfessionalEnum.Decoration, list);
            var relations = new List<string>();
            if (results != null && results.Length > 0)
            {
                var success = results.Where(m => m.State == IdentityResultStateEnum.Success);
                foreach (var item in success)
                {
                    relations.Add(item.Relation);
                }
            }

            result = relations.ToArray();

            return JsonConvert.SerializeObject(new { Result = result, Message = message, Error = false });
        error:
            return JsonConvert.SerializeObject(new
            {
                Error = true,
                Message = message
            });
        }
    }
}
