/*
 措施项目集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using ZiboSoft.Commons.Common;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _MeasuresSource : _SubSegmentsSource
    {

        protected _MeasuresSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "措施项目表";
        }

        public _MeasuresSource()
            : base()
        {
            this.TableName = "措施项目表";
           
        }

        public _MeasuresSource(bool IsProj):base(IsProj)
        {
            if (IsProj)
            {
                this.TableName = "措施项目表";
                //ProjBuilder();
            }
        }

        /*
        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("PID", typeof(int));
            this.Columns.Add("PPARENTID", typeof(int));
            this.Columns.Add("CPARENTID", typeof(int));
            this.Columns.Add("FPARENTID", typeof(int));
            this.Columns.Add("XH", typeof(int));
            this.Columns.Add("XMBM", typeof(string));
            this.Columns.Add("OLDXMBM", typeof(string));
            this.Columns.Add("XMMC", typeof(string));
            this.Columns.Add("DW", typeof(string));
            this.Columns.Add("TX", typeof(string));
            this.Columns.Add("LB", typeof(string));
            this.Columns.Add("JCBJ", typeof(bool));
            this.Columns.Add("FHBJ", typeof(bool));
            this.Columns.Add("ZYQD", typeof(bool));
            this.Columns.Add("SDDJ", typeof(bool));
            this.Columns.Add("JBHZ", typeof(bool));
            this.Columns.Add("XMTZ", typeof(string));
            this.Columns.Add("GCLJSS", typeof(string));
            this.Columns.Add("ZJWZ", typeof(string));
            this.Columns.Add("JX", typeof(bool));
            this.Columns.Add("SC", typeof(bool));
            this.Columns.Add("YGLB", typeof(string));
            this.Columns.Add("QFSZ", typeof(string));
            this.Columns.Add("BEIZHU", typeof(string));
            this.Columns.Add("LibraryName", typeof(string));
            this.Columns.Add("LY", typeof(string));
            this.Columns.Add("SDQD", typeof(bool));
            this.Columns.Add("SFFB", typeof(bool));
            this.Columns.Add("HL", typeof(decimal));
            this.Columns.Add("GCL", typeof(decimal));
            this.Columns.Add("ZJTJ", typeof(decimal));
            this.Columns.Add("ZHDJ", typeof(decimal));
            this.Columns.Add("ZHHJ", typeof(decimal));
            this.Columns.Add("ZJFDJ", typeof(decimal));
            this.Columns.Add("RGFDJ", typeof(decimal));
            this.Columns.Add("CLFDJ", typeof(decimal));
            this.Columns.Add("JXFDJ", typeof(decimal));
            this.Columns.Add("ZCFDJ", typeof(decimal));
            this.Columns.Add("SBFDJ", typeof(decimal));
            this.Columns.Add("GLFDJ", typeof(decimal));
            this.Columns.Add("LRDJ", typeof(decimal));
            this.Columns.Add("FXDJ", typeof(decimal));
            this.Columns.Add("GFDJ", typeof(decimal));
            this.Columns.Add("SJDJ", typeof(decimal));
            this.Columns.Add("CJDJ", typeof(decimal));
            this.Columns.Add("JCDJ", typeof(decimal));
            this.Columns.Add("XHL", typeof(decimal));
            this.Columns.Add("ZJFHJ", typeof(decimal));
            this.Columns.Add("RGFHJ", typeof(decimal));
            this.Columns.Add("CLFHJ", typeof(decimal));
            this.Columns.Add("JXFHJ", typeof(decimal));
            this.Columns.Add("ZCFHJ", typeof(decimal));
            this.Columns.Add("SBFHJ", typeof(decimal));
            this.Columns.Add("GLFHJ", typeof(decimal));
            this.Columns.Add("LRHJ", typeof(decimal));
            this.Columns.Add("FXHJ", typeof(decimal));
            this.Columns.Add("GFHJ", typeof(decimal));
            this.Columns.Add("SJHJ", typeof(decimal));
            this.Columns.Add("JCHJ", typeof(decimal));
            this.Columns.Add("CJHJ", typeof(decimal));
            this.Columns.Add("ZGJE", typeof(decimal));
            this.Columns.Add("JGJE", typeof(decimal));
            this.Columns.Add("FBJE", typeof(decimal));
            this.Columns.Add("FL", typeof(decimal));
            this.Columns.Add("DECJ", typeof(string));
            this.Columns.Add("JSJC", typeof(string));
            this.Columns.Add("ZJFS", typeof(string));
            this.Columns.Add("QDBH", typeof(string));
            this.Columns.Add("XMNR", typeof(string));
            this.Columns.Add("XMTZZ", typeof(string));
            this.Columns.Add("TYGS", typeof(string));
            this.Columns.Add("ISTY", typeof(bool));
            this.Columns.Add("PBZD", typeof(decimal));
            this.Columns.Add("YGJE", typeof(decimal));
            this.Columns.Add("STATUS", typeof(bool));
            this.Columns.Add("ZDSC", typeof(bool));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("Deep", typeof(int));
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("EnID", typeof(int));

           
        }*/


        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        /*public  int Add(object p_Info,int p_UnId,int p_EnID)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            string str = string.Empty;
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                str = col.ColumnName;
                if (str == "PID")
                { str = "PARENTID"; }
                PropertyInfo info = tp.GetProperty(str);
                if (info != null)
                {   
                        try
                        {
                            if (str == "PID")
                            {
                                row["PID"] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
                            }
                            else
                            {
                                row[col] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
                            }
                        }
                        catch { }
                    
                }
            }
            if(p_UnId != -1)row["UnID"] = p_UnId;
            if(p_EnID != -1) row["EnID"] = p_EnID;
            row.EndEdit();
            
            this.Rows.Add(row);
            try
            {
                PropertyInfo pi = tp.GetProperty("ID");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch { }
            return ToolKit.ParseInt(row["ID"]);
        }*/

        /// <summary>
        /// 更新的数据
        /// </summary>
        /// <param name="p_Info"></param>
        /// <param name="p_UnId"></param>
        /// <param name="p_EnID"></param>
        /*public override void UpDate(object p_Info)
        {
            
            string KeyName = this.PrimaryKey[0].ColumnName;
            Type tp = p_Info.GetType();
            PropertyInfo info = tp.GetProperty(KeyName);
            DataRow row = this.Rows.Find(Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType));
            if (row != null)
            {
                row.BeginEdit();
                //循环列添加数据对象
                foreach (DataColumn col in this.Columns)
                {
                    info = tp.GetProperty(col.ColumnName);
                    if (info != null)
                    {
                        if (info.Name != KeyName)
                        {
                            try
                            {
                                row[col] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
                            }
                            catch { }
                        }
                    }
                }
                row.EndEdit();
            }
            
        }*/

        /// <summary>
        /// 为指定单位工程重新设置关系数据(导入单位工程的时候使用)
        /// </summary>
        /// <param name="p_ObjectKey"></param>
        /// <param name="p_Info"></param>
        public override void SetNewFiled(ref int p_ObjectKey, _UnitProject p_Info)
        {
            //同步定单位工程的关系数据
            //分部分项处理
            int i = 0;
            DataView view = this.DefaultView;
            view.Sort = "ID asc";
            foreach (DataRowView row in view)
            {
                ///设置为新增的对象
                row.Row.SetAdded();
                row["Key"] = p_ObjectKey + ToolKit.ParseInt(row["ID"]);
                row["PKey"] = p_ObjectKey + ToolKit.ParseInt(row["PID"]);
                row["UnID"] = p_Info.ID;
                row["EnID"] = p_Info.PID;
                if (i == 0)
                {
                    row["PKey"] = p_Info.PKey;
                }
                i++;
            }
            p_ObjectKey = ToolKit.ParseInt(view[view.Count - 1]["Key"]);
            view.Sort = string.Empty;

        }
    }
}
