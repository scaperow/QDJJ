/*
 其他项目数据源对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _OtherProjectSource : _ObjectSource
    {

        protected _OtherProjectSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.TableName = "其他项目表";
        }

        public _OtherProjectSource()
            : base()
        {
            this.TableName = "其他项目表";
            Builder();
        }

        public _OtherProjectSource(bool IsProj)
            : base()
        {
            if (IsProj)
            {
                this.TableName = "其他项目表";
                ProjBuilder();
            }
        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void Builder()
        {
            this.Columns.Add("id", typeof(int));
            this.Columns.Add("ParentID", typeof(int));
            this.Columns.Add("Number", typeof(string));
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("Unit", typeof(string));
            this.Columns.Add("Quantities", typeof(string));
            this.Columns.Add("Calculation", typeof(string));
            this.Columns.Add("Unitprice", typeof(decimal));
            this.Columns.Add("Combinedprice", typeof(decimal));
            this.Columns.Add("Remark", typeof(string));
            this.Columns.Add("Feature", typeof(string));
            this.Columns.Add("beiyong", typeof(string));
            this.Columns.Add("IsSys", typeof(bool));
            this.Columns.Add("jsdJ", typeof(decimal));
            this.Columns.Add("cjdj", typeof(decimal));
            this.Columns.Add("cjhj", typeof(decimal));
            this.Columns.Add("Coefficient", typeof(decimal));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("DZBS", typeof(bool)).DefaultValue = false;
            /*this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;*/
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };

        }

        /// <summary>
        /// Bulider Table Struct
        /// </summary>		
        public virtual void ProjBuilder()
        {
            this.Columns.Add("id", typeof(int));
            this.Columns.Add("ParentID", typeof(int));
            this.Columns.Add("Number", typeof(string));
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("Unit", typeof(string));
            this.Columns.Add("Quantities", typeof(string));
            this.Columns.Add("Calculation", typeof(string));
            this.Columns.Add("Unitprice", typeof(decimal));
            this.Columns.Add("Combinedprice", typeof(decimal));
            this.Columns.Add("Remark", typeof(string));
            this.Columns.Add("Feature", typeof(string));
            this.Columns.Add("beiyong", typeof(string));
            this.Columns.Add("IsSys", typeof(bool));
            this.Columns.Add("jsdJ", typeof(decimal));
            this.Columns.Add("cjdj", typeof(decimal));
            this.Columns.Add("cjhj", typeof(decimal));
            this.Columns.Add("Coefficient", typeof(decimal));
            this.Columns.Add("EnID", typeof(int));
            this.Columns.Add("UnID", typeof(int));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("DZBS", typeof(bool)).DefaultValue = false;
            this.Columns.Add("Sort", typeof(int));
            /*this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 0;
            this.Columns[0].AutoIncrementStep = 1;*/
            this.PrimaryKey = new DataColumn[] { this.Columns["id"], this.Columns["UnID"] };
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
                if (row["ParentID"].Equals(0))
                {
                    row["Key"] = p_ObjectKey + ToolKit.ParseInt(row["ID"]);
                    row["PKey"] = p_Info.PKey;
                }
                else
                {
                    row["Key"] = p_ObjectKey + ToolKit.ParseInt(row["ID"]);
                    row["PKey"] = p_ObjectKey + ToolKit.ParseInt(row["ParentID"]);
                }
                row["UnID"] = p_Info.ID;
                row["EnID"] = p_Info.PID;
                i++;
            }
            var count = 0;
            if (view.Count > 0)
            {
                count = ToolKit.ParseInt(view[view.Count - 1]["Key"]);
            }

            p_ObjectKey = count;
            view.Sort = string.Empty;
        }

        /// <summary>
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public override void UpDate(DataRowView row)
        {
            //找到当前行
            DataRow r = this.Rows.Find(new object[] { row["ID"], row["UnID"] });
            //开始合并
            if (r != null)
            {
                //替换 除了主键以外的所有字段
                r.BeginEdit();
                r.ItemArray = row.Row.ItemArray;
                r.EndEdit();
                //this.Rows.Remove(r);
                //this.Rows.Add(row.Row.ItemArray);

            }
            else
            {
                //新增
                this.Rows.Add(row.Row.ItemArray);
            }
        }
    }
}
