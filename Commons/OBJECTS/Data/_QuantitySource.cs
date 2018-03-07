using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _QuantitySource : _ObjectSource
    {

        protected _QuantitySource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "工料机";
        }

        public _QuantitySource()
            : base()
        {
            this.TableName = "工料机";
            Builder();
        }

        public _QuantitySource(string p_TableName)
            : base()
        {
            this.TableName = p_TableName;
            Builder();
        }


        public _QuantitySource(bool IsProj)
            : base()
        {
            if (IsProj)
            {
                this.TableName = "工料机";
                ProjBuilder();
            }
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void ProjBuilder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("PID", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns.Add("QDID", typeof(int));
            this.Columns.Add("ZMID", typeof(int));
            this.Columns.Add("YSBH", typeof(string));
            this.Columns.Add("YSMC", typeof(string));
            this.Columns.Add("YSDW", typeof(string));
            this.Columns.Add("YSXHL", typeof(decimal));
            this.Columns.Add("BH", typeof(string));
            this.Columns.Add("MC", typeof(string));
            this.Columns.Add("DW", typeof(string));
            this.Columns.Add("XHL", typeof(decimal));
            this.Columns.Add("LB", typeof(string));
            this.Columns.Add("DEDJ", typeof(decimal));
            this.Columns.Add("DEHJ", typeof(decimal), "DEDJ*XHL");
            this.Columns.Add("SCDJ", typeof(decimal));
            this.Columns.Add("SCHJ", typeof(decimal), "SCDJ*XHL");
            this.Columns.Add("DJC", typeof(decimal), "SCDJ-DEDJ");
            this.Columns.Add("JSDJ", typeof(decimal));
            this.Columns.Add("JSDJC", typeof(decimal), "JSDJ-SCDJ");
            this.Columns.Add("GCL", typeof(decimal));
            this.Columns.Add("SL", typeof(decimal), "XHL*GCL");
            this.Columns.Add("IFZYCL", typeof(bool));
            this.Columns.Add("ZCLB", typeof(string));
            this.Columns.Add("GGXH", typeof(string));
            this.Columns.Add("SDCLB", typeof(string));
            this.Columns.Add("SDCXS", typeof(decimal));
            this.Columns.Add("YTLB", typeof(string));
            this.Columns.Add("IFXZ", typeof(bool));
            this.Columns.Add("IFSC", typeof(bool));
            this.Columns.Add("IFFX", typeof(bool));
            this.Columns.Add("IFSDSCDJ", typeof(bool));
            this.Columns.Add("IFSDSL", typeof(bool));
            this.Columns.Add("IFKFJ", typeof(bool));
            this.Columns.Add("SSDWGC", typeof(string));
            this.Columns.Add("GLJBZ", typeof(string));
            this.Columns.Add("CTIME", typeof(DateTime));
            this.Columns.Add("SLH", typeof(decimal));
            this.Columns.Add("SLDEHJ", typeof(decimal));
            this.Columns.Add("SLSCHJ", typeof(decimal));
            this.Columns.Add("JSHJC", typeof(decimal), "JSDJC*SL");
            this.Columns.Add("HJC", typeof(decimal), "DJC*SL");
            this.Columns.Add("SDCHJ", typeof(decimal), "SDCXS*SL*SCDJ");
            this.Columns.Add("CJ", typeof(string));
            this.Columns.Add("PP", typeof(string));
            this.Columns.Add("ZLDJ", typeof(string));
            this.Columns.Add("GYS", typeof(string));
            this.Columns.Add("CD", typeof(string));
            this.Columns.Add("CJBZ", typeof(string));
            this.Columns.Add("XGHSCDJ", typeof(decimal));
            this.Columns.Add("TZXS", typeof(decimal));
            this.Columns.Add("SSKLB", typeof(string));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0], this.Columns["UnID"] };
        }


        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("PID", typeof(int));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("SSLB", typeof(int));
            this.Columns.Add("QDID", typeof(int));
            this.Columns.Add("ZMID", typeof(int));
            this.Columns.Add("YSBH", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("YSMC", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("YSDW", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("YSXHL", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("BH", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("MC", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("DW", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("XHL", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("LB", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("DEDJ", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("DEHJ", typeof(decimal), "DEDJ*XHL");
            this.Columns.Add("SCDJ", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("SCHJ", typeof(decimal), "SCDJ*XHL");
            this.Columns.Add("DJC", typeof(decimal), "SCDJ-DEDJ");
            this.Columns.Add("JSDJ", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("JSDJC", typeof(decimal), "JSDJ-SCDJ");
            this.Columns.Add("GCL", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("SL", typeof(decimal), "XHL*GCL");
            this.Columns.Add("IFZYCL", typeof(bool)).DefaultValue = false;
            this.Columns.Add("ZCLB", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("GGXH", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("SDCLB", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("SDCXS", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("YTLB", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("IFXZ", typeof(bool)).DefaultValue = false;
            this.Columns.Add("IFSC", typeof(bool)).DefaultValue = false;
            this.Columns.Add("IFFX", typeof(bool)).DefaultValue = false;
            this.Columns.Add("IFSDSCDJ", typeof(bool)).DefaultValue = false;
            this.Columns.Add("IFSDSL", typeof(bool)).DefaultValue = false;
            this.Columns.Add("IFKFJ", typeof(bool)).DefaultValue = false;
            this.Columns.Add("SSDWGC", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("GLJBZ", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("CTIME", typeof(DateTime));
            this.Columns.Add("SLH", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("SLDEHJ", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("SLSCHJ", typeof(decimal)).DefaultValue = 0m;
            this.Columns.Add("JSHJC", typeof(decimal), "JSDJC*SL");
            this.Columns.Add("HJC", typeof(decimal), "DJC*SL");
            this.Columns.Add("SDCHJ", typeof(decimal), "SDCXS*SL*SCDJ");
            this.Columns.Add("CJ", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("PP", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("ZLDJ", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("GYS", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("CD", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("CJBZ", typeof(string)).DefaultValue = string.Empty;
            this.Columns.Add("XGHSCDJ", typeof(decimal));
            this.Columns.Add("TZXS", typeof(decimal));
            this.Columns.Add("SSKLB", typeof(string)).DefaultValue = string.Empty;
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }

        /// <summary>
        /// 指定对象修改到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public override void UpDate(object p_Info)
        {
            if (this.PrimaryKey.Length > 0)
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
                                catch(Exception e) {
                                    throw e;
                                }
                            }
                        }
                    }
                    if (row["ZCLB"].Equals("W"))
                    {
                        row["PID"] = DBNull.Value;
                    }
                    row.EndEdit();
                }
            }
            else
            {
                throw new NotImplementedException("当前DataTable没有主键");
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

            return this.Rows.Find(row["ID"]);
        }

        /// <summary>
        /// 查询指定DataRow中的当前父节点Row对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public DataRow GetRowByOther(DataRowView row)
        {
            if (row == null) return null;

            return this.Rows.Find(row["ID"]);
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


        /// <summary>
        /// 项目中使用，合并指定单位工程中的数据(两个表结构要完全相同)
        /// </summary>
        /// <param name="table"></param>
        public virtual void MergeData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    //删除原来表中的数据
                    //this.Delete(row);
                }
                else
                {
                    this.UpDate(row);
                }
            }
            //接收所有的数据变更
            this.AcceptChanges();
        }
        public override DataRow Add(DataRow p_row)
        {
            DataRow row = this.NewRow();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                if (p_row.Table.Columns.Contains(col.ColumnName) && col.ColumnName!="ID")
                {
                    row[col] = p_row[col.ColumnName];
                }
            }
            row.EndEdit();
            this.Rows.Add(row);
            return row;
        }
    }
}
