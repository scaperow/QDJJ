/*
    对库文件进行操作的方法集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS.LIB
{
    public class _LibAction
    {
        /// <summary>
        /// 清单结构体
        /// </summary>		
        public struct 清单库
        {
            /// <summary>
            /// Oracle链接对象名称
            /// </summary>			
            public const string 园林绿化清单库 = "园林绿化清单库";
            /// <summary>
            /// SqlServer链接对象名称
            /// </summary>
            public const string 市政清单库 = "市政清单库";
            /// <summary>
            /// OlEDB链接对象名称
            /// </summary>
            public const string 建筑清单库 = "建筑清单库";
            /// <summary>
            /// MySql链接对象名称
            /// </summary>
            public const string 安装清单库 = "安装清单库";

            
        }

        /// <summary>
        /// 定额结构体
        /// </summary>		
        public struct 定额库
        {
            /// <summary>
            /// 园林定额价目表
            /// </summary>			
            public const string 园林定额价目表 = "园林定额价目表";
            /// <summary>
            /// 市政定额价目表
            /// </summary>
            public const string 市政定额价目表 = "市政定额价目表";
            /// <summary>
            /// 绿化定额价目表
            /// </summary>
            public const string 绿化定额价目表 = "绿化定额价目表";
            /// <summary>
            /// 建筑装饰定额价目表
            /// </summary>
            public const string 建筑装饰定额价目表 = "建筑装饰定额价目表";
            /// <summary>
            /// 
            /// </summary>
            public const string 安装定额价目表 = "安装定额价目表";
        } 


        public DataSet Libs = null;

        public _LibAction(string _path)
        {
            Libs = CFiles.BinaryDeserializeForLib(_path) as DataSet;
        }

        /// <summary>
        /// 加载清单文件
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public static DataSet Load(string _path)
        {
            if (System.IO.File.Exists(_path))
                return CFiles.BinaryDeserializeForLib(_path) as DataSet;
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据字符串返回专业名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetValue(string str,string LibName)
        {
            switch (LibName)
            {
                case "清单库":

                    break;
                default:
                    int value = -1;
                    value = str.IndexOf(_LibAction.定额库.建筑装饰定额价目表);
                    if (value >= 0) return _LibAction.定额库.建筑装饰定额价目表;
                    value = str.IndexOf(_LibAction.定额库.绿化定额价目表);
                    if (value >= 0) return _LibAction.定额库.绿化定额价目表;
                    value = str.IndexOf(_LibAction.定额库.市政定额价目表);
                    if (value >= 0) return _LibAction.定额库.市政定额价目表;
                    value = str.IndexOf(_LibAction.定额库.园林定额价目表);
                    if (value >= 0) return _LibAction.定额库.园林定额价目表;
                    value = str.IndexOf(_LibAction.定额库.安装定额价目表);
                    if (value >= 0) return _LibAction.定额库.安装定额价目表;
                    break;
            }
            return string.Empty;
        }

        /// <summary>
        /// 返回清单列表包含清单明细
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataTable GetAllListGallery (DataSet ds)
        {
            DataTable table = ds.Tables["清单索引表"].Copy();
            foreach (DataRow row in ds.Tables["清单表"].Rows)
            {
                DataRow r = table.NewRow();
                //清单索引编号
                r["PARENTID"] = row["QINGDSYBH"];
                r["QINGDSYBH"] = row["QINGDBH"];
                r["MULNR"] = row["QINGDMC"];
                table.Rows.Add(r);
            }
            return table;
        }
    }
}
