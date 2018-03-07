using System;
using System.Collections;
using System.Text;

namespace Business
{
   public  class OtherClass //程序相关的静态方法
    {
       public static  string GetId(string nodeStr) //获取括号内的字符串
       {
           int left = nodeStr.LastIndexOf('[') + 1;
           int right = nodeStr.LastIndexOf(']');
           return nodeStr.Substring(left, right - left);
       }
       public static string less0(string StrItem) //将金额为0.000的置为空
       {
           if (StrItem == "0.000"||StrItem=="0.0000") return "";
           return StrItem;
       }
       public static string resetString(string jmsh, string jqh, string timeStr)  //这是一个按老版要求重新组合加密信息的函数，不用仔细看
       {
           ArrayList jmshAL = new ArrayList();
           ArrayList jqhAL = new ArrayList();
           ArrayList timeAL = new ArrayList();
           string cStr = "";
           string iStr = "";
           for (int i = 0; i < jmsh.Length; i++)
           {
               iStr = jmsh.Substring(i, 1);
               if (iStr == ",")
               {
                   jmshAL.Add(cStr);
                   cStr = "";
               }
               else
               {
                   cStr += iStr;
               }
           }
           jmshAL.Add(cStr);
           cStr = "";

           for (int i = 0; i < jqh.Length; i++)
           {
               iStr = jqh.Substring(i, 1);
               if (iStr == ",")
               {
                   jqhAL.Add(cStr);
                   cStr = "";
               }
               else
               {
                   cStr += iStr;
               }
           }
           jqhAL.Add(cStr);
           cStr = "";
           for (int i = 0; i < timeStr.Length; i++)
           {
               iStr = timeStr.Substring(i, 1);
               if (iStr == ",")
               {
                   timeAL.Add(cStr);
                   cStr = "";
               }
               else
               {
                   cStr += iStr;
               }
           }
           timeAL.Add(cStr);
           cStr = "";
           for (int i = 0; i < jmshAL.Count; i++)
           {
               cStr += "(" + jmshAL[i].ToString() + ")|{" + jqhAL[i].ToString() + "}|" + timeAL[0].ToString() + ";";              
           }
           return cStr;
       }


    }
}
