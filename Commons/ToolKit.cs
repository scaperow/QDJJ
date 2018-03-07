using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MSScriptControl;
using System.Collections;
using System.Reflection;
using System.Globalization;
using System.CodeDom.Compiler;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ZiboSoft.Commons.Common;
using System.Text.RegularExpressions;
using System.Management;


namespace GOLDSOFT.QDJJ.COMMONS
{
    public class ToolKit
    {
        //private static ScriptControl sc = new ScriptControlClass();
        /// <summary>
        /// 替换表达式
        /// </summary>
        /// <param name="Expression">表达式</param>
        /// <param name="dt">表达式对应值集合</param>
        /// <returns>替换后的表达式</returns>
        public static string ExpressionReplace(string Expression, DataTable dt)
        {
            //lock (dt)
            {
                DataRow[] drs = dt.Select("", "Length DESC");
                foreach (DataRow dr in drs)
                {
                    if (dr != null)
                    {
                        if (dr["Key"] != null && !dr["Key"].Equals(string.Empty))
                        {
                            if (Expression.Contains(dr["Key"].ToString()))
                            {
                                Expression = Expression.Replace(dr["Key"].ToString(), dr["Value"].ToString());
                            }
                        }
                    }
                }

               // System.Text.RegularExpressions.Regex.Replace(Expression, @"^\w+$");

                MatchCollection matchs = Regex.Matches(Expression, @"[a-z]+$?[a-zA-Z0-9]", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
                foreach (Match match in matchs)
                {
                  Expression=  Expression.Replace(match.Value, "0");
                }
                return Expression;
            }
        }

        /// <summary>
        /// 替换表达式
        /// </summary>
        /// <param name="Expression">表达式</param>
        /// <param name="dt">表达式对应值集合</param>
        /// <returns>替换后的表达式</returns>
        public static string ExpressionReplace(string Expression, DataRow[] drs)
        {
            if (Expression.Equals("")) return "0";
            //lock (drs)
            {
                foreach (DataRow dr in drs)
                {
                    if (dr != null)
                    {
                        if (dr["Key"] != null)
                        {
                            if (dr["Key"].ToString()!=string.Empty)
                            if (Expression.Contains(dr["Key"].ToString()))
                            {
                                Expression = Expression.Replace(dr["Key"].ToString(), dr["Value"].ToString());
                            }
                        }
                    }
                }
                MatchCollection matchs = Regex.Matches(Expression, @"[a-z]+$?[a-zA-Z0-9]", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
                foreach (Match match in matchs)
                {
                    Expression = Expression.Replace(match.Value, "0");
                }
                return Expression;
                return Expression;
            }
        }

        /// <summary>
        /// 替换表达式
        /// </summary>
        /// <param name="Expression">表达式</param>
        /// <param name="dt">表达式对应值集合</param>
        /// <returns>替换后的表达式</returns>
        public static string ExpressionReplace(string Expression, string p_Field, DataTable dt)
        {
            DataRow[] drs = dt.Select("", "Length DESC");
            foreach (DataRow dr in drs)
            {
                if (!dr["Key"].Equals(string.Empty) && Expression.Contains(dr["Key"].ToString()))
                {
                    if (dr[p_Field].ToString() != string.Empty)
                    {
                        Expression = Expression.Replace(dr["Key"].ToString(), dr[p_Field].ToString());
                    }
                    else
                    {
                        Expression = Expression.Replace(dr["Key"].ToString(), dr["Key"].ToString());
                    }
                }
            }
            return Expression;
        }

        /// <summary>
        /// 根据计算表达式得到计算结果
        /// </summary>
        /// <param name="value">计算式（比如：1*5+（2-1））</param>
        /// <returns></returns>
        public static decimal Calculate(string value)
        {
            using (DataTable table = new DataTable())
            {
                try
                {
                    return ToolKit.ParseDecimal(table.Compute(value, string.Empty));
                }
                catch
                {
                    return 0m;
                }
            }
            //try
            //{

            //    decimal a = 0m;
            //    sc.Language = "JavaScript";
            //    string str = sc.Eval(value.ToString()).ToString();
            //    decimal.TryParse(str, out a);
            //    return a;
            //}
            //catch (Exception ex)
            //{
            //    return 0;
            //}
        }

        /// <summary>
        /// 数字转换成大写
        /// </summary>
        /// <param name="inti"></param>
        /// <param name="upptype"></param>
        /// <returns></returns>
        public static string NumToCNum(decimal num, bool upptype)
        {
            string str1; //0-9所对应的汉字  
            string str2; //数字位所对应的汉字
            if (upptype)
            {
                str1 = "零壹贰叁肆伍陆柒捌玖"; //0-9所对应的汉字  
                str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字
            }
            else
            {
                str1 = "〇一二三四五六七八九"; //0-9所对应的汉字  
                str2 = "万千百十亿千百十万千百十   "; //数字位所对应的汉字
            }
            string str3 = ""; //从原num值中取出的值  
            string str4 = ""; //数字的字符串形式  
            string str5 = ""; //人民币大写金额形式  
            int i; //循环变量  
            int j; //num的值乘以100的字符串长度  
            string ch1 = ""; //数字的汉语读法  
            string ch2 = ""; //数字位的汉字读法  
            int nzero = 0; //用来计算连续的零值是几个  
            int temp; //从原num值中取出的值  

            num = Math.Round(Math.Abs(num), 2); //将num取绝对值并四舍五入取2位小数  
            str4 = ((long)(num * 100)).ToString(); //将num乘100并转换成字符串形式  
            j = str4.Length; //找出最高位  
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j); //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分  

            //循环取出每一位需要转换的值  
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1); //取出需转换的某一位的值  
                temp = Convert.ToInt32(str3); //转换为数字  
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时  
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位  
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上  
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    if (upptype)
                    {
                        //最后一位（分）为0时，加上“整”  
                        str5 = str5 + '整';
                    }
                }
            }

            if (num == 0)
            {
                if (upptype)
                {
                    str5 = "零元整";
                }
                else
                {
                    str5 = "零";
                }
            }
            return str5;
        }

        /// <summary>  
        /// 转换人民币大小金额  
        /// </summary>  
        /// <param name="num">金额</param>  
        /// <returns>返回大写形式</returns>  
        public static string NumToCNum(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖"; //0-9所对应的汉字  
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字  
            string str3 = ""; //从原num值中取出的值  
            string str4 = ""; //数字的字符串形式  
            string str5 = ""; //人民币大写金额形式  
            int i; //循环变量  
            int j; //num的值乘以100的字符串长度  
            string ch1 = ""; //数字的汉语读法  
            string ch2 = ""; //数字位的汉字读法  
            int nzero = 0; //用来计算连续的零值是几个  
            int temp; //从原num值中取出的值  

            num = Math.Round(Math.Abs(num), 2); //将num取绝对值并四舍五入取2位小数  
            str4 = ((long)(num * 100)).ToString(); //将num乘100并转换成字符串形式  
            j = str4.Length; //找出最高位  
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j); //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分  

            //循环取出每一位需要转换的值  
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1); //取出需转换的某一位的值  
                temp = Convert.ToInt32(str3); //转换为数字  
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时  
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位  
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上  
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”  
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }
        /// <summary>
        ///刷新桌面，调用示例（SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);
        /// </summary>
        /// <param name="wEventId"></param>
        /// <param name="uFlags"></param>
        /// <param name="dwItem1"></param>
        /// <param name="dwItem2"></param>
        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        #region 写入程序相关
        public static void WriteApp(string Path, string IcoPath, string APPkey)
        {
            //设置程序打开路径
            string path = "\"" + Path + "\"" + "\"%1\"";
            RegistryKey root = Registry.ClassesRoot;
            RegistryKey f1 = root.CreateSubKey(APPkey);
            //设置注册表程序打开的项与值,其中SetValue("", path)代表设置默认值
            f1.CreateSubKey("shell").CreateSubKey("Open").CreateSubKey("Command").SetValue("", path);

            //设置程序图标
            string ico = "\"" + IcoPath + "\"";
            f1.CreateSubKey("DefaultIcon").SetValue("", ico);
            //刷新桌面
            ToolKit.SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);
        }
        #endregion

        #region 写入删除关联文件
        public static void WriteRelate(string Name, string APPkey)
        {
            RegistryKey root = Registry.ClassesRoot;
            //设置打开程序
            root.CreateSubKey(Name).SetValue("", APPkey);
            //刷新桌面
            ToolKit.SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);
        }

        public static void DelRelate(string Name)
        {
            RegistryKey root = Registry.ClassesRoot;
            if (root.OpenSubKey(Name) != null)
            {
                root.DeleteSubKeyTree(Name);
            }

            //刷新桌面
            ToolKit.SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);
        }
        #endregion


        /// <summary>
        /// 获取当前对象的一个副本
        /// </summary>
        /// <returns></returns>
        public static object Copy(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                object CloneObject;
                BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                // 反序列化至另一个对象(即创建了一个原对象的深表副本)
                CloneObject = bf.Deserialize(ms);
                // 关闭流
                ms.Close();
                return CloneObject;
            }
        }

        /// <summary>
        /// 计算图元公式
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static double Expression(string expression)
        {
            try
            {
                object instance;
                MethodInfo method;
                //sqrt
                if (expression.ToUpper(CultureInfo.InvariantCulture).IndexOf("RETURN") < 0)
                {
                    expression = "Return " + expression;
                }
                string className = "Expression";
                string methodName = "Compute";
                CompilerParameters p = new CompilerParameters();
                p.GenerateInMemory = true;
                CompilerResults cr = new VBCodeProvider().CompileAssemblyFromSource(p,
                string.Format
                (
                    @"Option Explicit Off
                Option Strict Off
                Imports System, System.Math, Microsoft.VisualBasic
                NotInheritable Class {0}
                Public Function {1} As double
                {2}
                End Function
                End Class",
                    className, methodName, expression
                )
                );
                if (cr.Errors.Count > 0)
                {
                    return 0.0;
                }
                instance = cr.CompiledAssembly.CreateInstance(className);
                method = instance.GetType().GetMethod(methodName);
                double ret = (double)method.Invoke(instance, null);
                if (ret < 0 || ret.ToString() == Double.NaN.ToString())
                {
                    return 0.0;
                }
                return ret;
            }
            catch (Exception)
            {
                 return 0.0;
            }
        }

        /**/
        /// <summary> 
        /// 半角转全角的函数(SBC case) 
        /// </summary> 
        /// <param name=”input”>任意字符串</param> 
        /// <returns>全角字符串</returns> 
        ///<remarks> 
        ///全角空格为12288，半角空格为32 
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248 
        ///</remarks> 
        public static string ToSBC(string input)
        {
            //半角转全角： 
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /**/
        /// <summary> 
        /// 全角转半角的函数(DBC case) 
        /// </summary> 
        /// <param name=”input”>任意字符串</param> 
        /// <returns>半角字符串</returns> 
        ///<remarks> 
        ///全角空格为12288，半角空格为32 
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248 
        ///</remarks> 
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 小数点格式化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static decimal Formart(object o, int p_num)
        {
            return decimal.Parse(ToolKit.ParseDecimal(o).ToString(string.Format("F{0}", p_num)));
        }

        /// <summary>
        /// 获取Decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ParseDecimal(object obj)
        {
            if (obj == null) return 0;

            decimal d = 0;
            decimal.TryParse(obj.ToString(),NumberStyles.Any,null, out d);
            return d;
        }

        /// <summary>
        /// 获取Int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ParseInt(object obj)
        {
            if (obj == null) return 0;

            int d = 0;
            int.TryParse(obj.ToString(), out d);
            return d;
        }

        /// <summary>
        /// 获取Boolen
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ParseBoolen(object obj)
        {
            if (obj == null) return false;

            bool d = false;
            bool.TryParse(obj.ToString(), out d);
            return d;
        }

        public static DirectoryInfo GetDirectoryInfo(string Path)
        {
            DirectoryInfo dir = new DirectoryInfo(Path);
            if (!dir.Exists)
            {
                dir.Create();
            }
            return dir;
        }
        public static string TrimZero(object d)
        {
            string str = d.ToString();
            if (str.IndexOf('.') > -1)
            {
                str = str.TrimEnd('0');
            }
            str = str.TrimEnd('.');
            return str;

        }

        #region 计算机标识

        private static string GetCpu()
        {
            ManagementObjectCollection instances = new ManagementClass("win32_Processor").GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                return obj2.Properties["Processorid"].Value.ToString();
            }
            return null;
        }

        private static string GetDiskVolumeSerialNumber()
        {
            ManagementObject obj2 = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            obj2.Get();
            return obj2.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        private static string GetMac()
        {
            ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            string mac = string.Empty;
            foreach (ManagementObject obj2 in instances)
            {
                if ((bool)obj2["IPEnabled"])
                {
                    mac = obj2["MacAddress"].ToString();
                    obj2.Dispose();
                    return mac;
                }
                obj2.Dispose();

            }
            return "Error";
        }

        public static string GetIndentify()
        {
            string str = GetMac().Replace(":", string.Empty);
            string cpu = GetCpu();
            string diskVolumeSerialNumber = GetDiskVolumeSerialNumber();
            return string.Format("{0}{1}{2}", str, cpu, diskVolumeSerialNumber);
        }
        
        #endregion

    }
}