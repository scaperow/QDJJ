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
    public class _MetaanalysisSource : _ObjectSource
    {
        protected _MetaanalysisSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "汇总分析表";
        }

        public _MetaanalysisSource()
            : base()
        {
            this.TableName = "汇总分析表";

            Builder();
        }

        public _MetaanalysisSource(bool IsProj)
            : base()
        {
            if (IsProj)
            {
                this.TableName = "汇总分析表";
                ProjBuilder();
            }
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("ParentID", typeof(int));
            this.Columns.Add("Number", typeof(string));
            this.Columns.Add("Feature", typeof(string));
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("Calculation", typeof(string));
            this.Columns.Add("Coefficient", typeof(decimal));
            this.Columns.Add("Remark", typeof(string));
            this.Columns.Add("Price", typeof(decimal));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void ProjBuilder()
        {
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("ParentID", typeof(int));
            this.Columns.Add("Number", typeof(string));
            this.Columns.Add("Feature", typeof(string));
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("Calculation", typeof(string));
            this.Columns.Add("Coefficient", typeof(decimal));
            this.Columns.Add("Remark", typeof(string));
            this.Columns.Add("Price", typeof(decimal));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns["ID"], this.Columns["UnID"] };
        }


        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public void Add(object p_Info, int p_PID)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            string str = string.Empty;
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                str = col.ColumnName;
                PropertyInfo info = tp.GetProperty(str);
                if (info != null)
                {
                    try
                    {
                        row[col] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            row["PID"] = p_PID;
            row.EndEdit();
            this.Rows.Add(row);
            /*try
            {
                PropertyInfo pi = tp.GetProperty("ID");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch { }
            return ToolKit.ParseInt(row["ID"]);*/
        }

        /// <summary>
        /// 项目中使用，合并指定单位工程中的数据(两个表结构要完全相同)
        /// </summary>
        /// <param name="table"></param>
        public override void MergeData(DataTable table)
        {
            foreach (DataRowView row in table.DefaultView)
            {
                //if (!row["Key"].Equals(0))
                {
                    this.UpDate(row);
                }
            }
            //接收所有的数据变更
            this.AcceptChanges();
        }

    }
}
