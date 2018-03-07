/*
    当前单位工程的分部分项表数据
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
    /// <summary>
    /// 分部分项的数据对象
    /// </summary>
    [Serializable]
    public class _SubSegmentsSource : _ObjectSource
    {


        protected _SubSegmentsSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        public _SubSegmentsSource()
            : base()
        {
            this.TableName = "分部分项表";
            Builder();
        }

        public _SubSegmentsSource(bool IsProj)
            : base()
        {
            if (IsProj)
            {
                this.TableName = "分部分项表";
                ProjBuilder();
            }
        }

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
            DataColumn JCBJ = this.Columns.Add("JCBJ", typeof(bool));
            JCBJ.DefaultValue = false;
            DataColumn FHBJ = this.Columns.Add("FHBJ", typeof(bool));
            FHBJ.DefaultValue = false;
            DataColumn ZYQD = this.Columns.Add("ZYQD", typeof(bool));
            ZYQD.DefaultValue = false;
            DataColumn SDDJ = this.Columns.Add("SDDJ", typeof(bool));
            SDDJ.DefaultValue = false;
            DataColumn JBHZ = this.Columns.Add("JBHZ", typeof(bool));
            JBHZ.DefaultValue = false;
            this.Columns.Add("XMTZ", typeof(string));
            this.Columns.Add("GCLJSS", typeof(string));
            this.Columns.Add("ZJWZ", typeof(string));
            DataColumn JX = this.Columns.Add("JX", typeof(bool));
            JX.DefaultValue = false;
            DataColumn SC = this.Columns.Add("SC", typeof(bool));
            SC.DefaultValue = false;
            this.Columns.Add("YGLB", typeof(string));
            this.Columns.Add("QFSZ", typeof(string));
            this.Columns.Add("BEIZHU", typeof(string));
            this.Columns.Add("LibraryName", typeof(string));
            this.Columns.Add("LY", typeof(string));
            this.Columns.Add("SDQD", typeof(bool));
            DataColumn SFFB = this.Columns.Add("SFFB", typeof(bool));
            SFFB.DefaultValue = false;
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
            DataColumn ISTY = this.Columns.Add("ISTY", typeof(bool));
            ISTY.DefaultValue = false;
            this.Columns.Add("PBZD", typeof(decimal));
            this.Columns.Add("YGJE", typeof(decimal));
            DataColumn STATUS = this.Columns.Add("STATUS", typeof(bool));
            STATUS.DefaultValue = false;
            DataColumn ZDSC = this.Columns.Add("ZDSC", typeof(bool));
            ZDSC.DefaultValue = false;
            this.Columns.Add("ZYLB", typeof(string));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("Deep", typeof(int));
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns.Add("RGFJC", typeof(decimal));
            this.Columns.Add("CLFJC", typeof(decimal));
            this.Columns.Add("JXFJC", typeof(decimal));
            this.Columns.Add("DZBS", typeof(bool)).DefaultValue = false;
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 1;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void ProjBuilder()
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
            this.Columns.Add("ZYLB", typeof(string));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("Deep", typeof(int));
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns.Add("RGFJC", typeof(decimal));
            this.Columns.Add("CLFJC", typeof(decimal));
            this.Columns.Add("JXFJC", typeof(decimal));
            this.Columns.Add("DZBS", typeof(bool)).DefaultValue = false;
            /*this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 1;
            this.Columns[0].AutoIncrementStep = 1;*/
            this.PrimaryKey = new DataColumn[] { this.Columns["ID"], this.Columns["UnID"] };
        }


    

        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public int Add(object p_Info, int p_UnId, int p_EnID)
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
                    catch(Exception e) {
                        throw e;
                    }

                }
            }
            if (p_UnId != -1) row["UnID"] = p_UnId;
            if (p_EnID != -1) row["EnID"] = p_EnID;
            row.EndEdit();

            this.Rows.Add(row);
            try
            {
                PropertyInfo pi = tp.GetProperty("ID");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch(Exception e) {
                throw e;
            }
            return ToolKit.ParseInt(row["ID"]);
        }

        /// <summary>
        /// 更新的数据
        /// </summary>
        /// <param name="p_Info"></param>
        /// <param name="p_UnId"></param>
        /// <param name="p_EnID"></param>
        public override void UpDate(object p_Info)
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
                            catch(Exception e ) {
                                throw e;
                            }
                        }
                    }
                }
                row.EndEdit();
            }

        }

        /// <summary>
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public override void UpDate(DataRow row)
        {
            //找到当前行
            DataRow r = this.Rows.Find(new object[] { row["ID"] });
            //开始合并
            if (r != null)
            {
                //替换
                r.BeginEdit();
                r.ItemArray = row.ItemArray;
                r.EndEdit();
            }
            else
            {
                //新增
                this.Rows.Add(row.ItemArray);
            }
        }

        /// <summary>
        /// 查询指定DataRow中的当前父节点Row对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public DataRow GetRowByOther(DataRow row)
        {
            if (row == null) return null;

            return this.Rows.Find(row["PID"]);
        }

        /// <summary>
        /// 查询指定DataRow中的当前父节点Row对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public DataRow GetRowByOther(DataRowView row)
        {
            if (row == null) return null;

            return this.Rows.Find(row["PID"]);
        }

        /// <summary>
        /// 查询指定DataRow中的当前父节点Row对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public DataRow GetRowByOther(string p_ID)
        {
            return this.Rows.Find(p_ID);
        }

        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {

            base.OnRowDeleting(e);
        }

        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);

        }

        /// <summary>
        /// 合并数据
        /// </summary>
        /// <param name="p_UnID"></param>
        /// <param name="table"></param>
        public void MergeData(DataTable table, DataTable p_ProjTable)
        {
            //合并前如果有新增的项目数据源添加进去(不包含单位工程节点)
            foreach (DataRow row in p_ProjTable.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    DataRow r = this.NewRow();
                    this.Rows.Add(r);
                }
            }

            foreach (DataRowView row in table.DefaultView)
            {
                if (!row["Key"].Equals(0))
                {
                    this.UpDate(row);
                }
            }
            //接收所有的数据变更
           //this.AcceptChanges();
        }


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
                if (row["LB"].Equals("分部-章") || row["LB"].Equals("分部-节") || row["LB"].Equals("分部-专业"))
                { }
                else
                {
                    row["Key"] = p_ObjectKey + ToolKit.ParseInt(row["ID"]);
                    row["PKey"] = p_ObjectKey + ToolKit.ParseInt(row["FPARENTID"]);
                }
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
