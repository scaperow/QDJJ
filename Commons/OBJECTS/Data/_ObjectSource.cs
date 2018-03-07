/*
    数据表基础类别
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
    public class _ObjectSource : DataTable
    {


        /// <summary>   
        /// 获取DataTable前几条数据   
        /// </summary>   
        /// <param name="TopItem">前N条数据</param>   
        /// <param name="oDT">源DataTable</param>   
        /// <returns></returns>   
        public static DataTable DtSelectTop(int TopItem, DataTable oDT)
        {
            if (oDT.Rows.Count < TopItem) return oDT;

            DataTable NewTable = oDT.Clone();
            DataRow[] rows = oDT.Select("1=1");
            for (int i = 0; i < TopItem; i++)
            {
                NewTable.ImportRow((DataRow)rows[i]);
            }
            return NewTable;
        }

        /// <summary>
        /// 是否需要完成本次的保存(默认为false 每次计算后此属性为true)
        /// 暂时解决保存问题
        /// </summary>
        public bool IsCompled = false;

        protected _ObjectSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        public void RemoveAll()
        {
            for (var i=0;i<Rows.Count;i++)
            {
                Rows[i].Delete();
            }
        }

        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// 需要指定一个DataTable
        /// </summary>
        /// <param name="p_Info"></param>
        public static int Add(object p_Info, DataTable p_Table)
        {
            DataRow row = p_Table.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in p_Table.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (info.Name != "ID")
                    {
                        row[col] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
                    }
                }
            }
            row.EndEdit();
            p_Table.Rows.Add(row);
            PropertyInfo pi = tp.GetProperty("ID");
            if (pi != null)
                pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            return ToolKit.ParseInt(row["ID"]);
        }
        /// <summary>
        /// 根据DataRow还原指定对象的值
        /// </summary>
        /// <param name="p_obj"></param>
        /// <param name="row"></param>
        public static void GetObject(object p_obj, DataRow row)
        {
            if (row == null || p_obj == null) return;
            Type tp = p_obj.GetType();
            foreach (DataColumn col in row.Table.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (row[col.ColumnName] != System.DBNull.Value)
                        info.SetValue(p_obj, row[col.ColumnName], null);
                }
            }
        }

        /// <summary>
        /// 根据DataRowView还原指定对象的值
        /// </summary>
        /// <param name="p_obj"></param>
        /// <param name="row"></param>
        public static void GetObject(object p_obj, DataRowView row)
        {
            if (row == null || p_obj == null) return;
            Type tp = p_obj.GetType();
            foreach (DataColumn col in row.Row.Table.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (row[col.ColumnName] != System.DBNull.Value)
                        info.SetValue(p_obj, row[col.ColumnName], null);
                }
            }

        }
        /// <summary>
        /// 如果单位工程是项目中取得此处同步基础属性的值
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void Synchronous(_COBJECTS p_Info)
        {
            DataRow row = this.Rows.Find(p_Info.ID);
            if (row != null)
            {
                _ObjectSource.GetObject(p_Info, row);
            }
        }
        /// <summary>
        /// 基础类数据对象
        /// </summary>
        public _ObjectSource()
            : base()
        {
        }

        public int AddData(object p_Info)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (info.Name != "ID")
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
            }
            row.EndEdit();
            this.Rows.Add(row);

            try
            {
                PropertyInfo pi = tp.GetProperty("ActiviteId");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ToolKit.ParseInt(row["ID"]);
        }


        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual int Add(object p_Info)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (info.Name != "ID")
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
            }
            row.EndEdit();
            this.Rows.Add(row);

            try
            {
                PropertyInfo pi = tp.GetProperty("ID");
                if (pi != null)
                    pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
            }
            catch (Exception e)
            {
                throw e;
            }
            return ToolKit.ParseInt(row["ID"]);
        }

        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual int AddNotInt(object p_Info)
        {
            DataRow row = this.NewRow();
            Type tp = p_Info.GetType();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
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
            }
            row.EndEdit();
            this.Rows.Add(row);
            return ToolKit.ParseInt(row["ID"]);
        }

        ///// <summary>
        ///// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        ///// </summary>
        ///// <param name="p_Info"></param>
        //public virtual int AddForUnit(object p_Info)
        //{
        //    DataRow row = this.NewRow();
        //    Type tp = p_Info.GetType();
        //    row.BeginEdit();
        //    //循环列添加数据对象
        //    foreach (DataColumn col in this.Columns)
        //    {
        //        PropertyInfo info = tp.GetProperty(col.ColumnName);
        //        if (info != null)
        //        {
        //            if (info.Name != "ID")
        //            {
        //                try
        //                {
        //                    row[col] = Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType);
        //                }
        //                catch { }
        //            }
        //        }
        //    }
        //    row.EndEdit();
        //    this.Rows.Add(row);
        //    /*try
        //    {
        //        PropertyInfo pi = tp.GetProperty("ID");
        //        if (pi != null)
        //            pi.SetValue(p_Info, ToolKit.ParseInt(row["ID"]), null);
        //    }
        //    catch { }*/
        //    return ToolKit.ParseInt(row["ID"]);
        //}

        /// <summary>
        /// 指定对象添加到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual DataRow Add(DataRow p_row)
        {
            DataRow row = this.NewRow();
            row.BeginEdit();
            //循环列添加数据对象
            foreach (DataColumn col in this.Columns)
            {
                if (p_row.Table.Columns.Contains(col.ColumnName))
                {
                    row[col] = p_row[col.ColumnName];
                }
            }
            row.EndEdit();
            this.Rows.Add(row);
            return row;
        }
        public virtual void Delete(int p_id)
        {

            DataRow row = this.Rows.Find(p_id);
            if (row != null)
            {
                row.Delete();
            }
        }
        public virtual void Delete(object p_Info)
        {
            if (this.PrimaryKey.Length > 0)
            {
                string KeyName = this.PrimaryKey[0].ColumnName;
                Type tp = p_Info.GetType();
                PropertyInfo info = tp.GetProperty(KeyName);
                DataRow row = this.Rows.Find(Convert.ChangeType(info.GetValue(p_Info, null), info.PropertyType));
                if (row != null)
                {
                    row.Delete();
                }
            }
            else
            {
                throw new NotImplementedException("当前DataTable没有主键");
            }
        }

        /// <summary>
        /// 指定对象修改到当前数据源对象中(如果对象名称与类名称相互对应此方法可用)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void UpDate(object p_Info)
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
                                catch (Exception e)
                                {
                                    throw e;
                                }
                            }
                        }
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
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public virtual void UpDate(DataRow row)
        {
            try
            {
                //找到当前行
                DataRow r = this.Rows.Find(new object[] { row["ID"], row["UnID"] });
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public virtual void UpDate(DataRowView row)
        {
            try
            {
                DataRow r = this.Rows.Find(new object[] { row["ID"], row["UnID"] });

                if (r != null)
                {
                    //替换 除了主键以外的所有字段
                    r.BeginEdit();
                    r.ItemArray = row.Row.ItemArray;
                    r.EndEdit();

                }
                else
                {
                    this.Rows.Add(row.Row.ItemArray);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public virtual void Delete(DataRow row)
        {
            //找到当前行
            DataRow r = this.Rows.Find(new object[] { row["ID"], row["UnID"] });
            //开始合并
            if (r != null)
            {
                //删除
                r.Delete();
            }
        }

        /// <summary>
        /// 删除指定单位工程下的数据
        /// </summary>
        /// <param name="UnID"></param>
        public virtual void DeleteForUnID(object UnID)
        {
            DataRow[] rows = this.Select(string.Format(" UnID = {0}", string.Empty));
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    this.Rows.Remove(row);
                }
            }

        }

        /// <summary>
        /// 项目中使用，合并指定单位工程中的数据(两个表结构要完全相同)
        /// </summary>
        /// <param name="table"></param>
        public virtual void MergeData(DataTable table)
        {
            foreach (DataRowView row in table.DefaultView)
            {
                if (!row["Key"].Equals(0))
                {
                    this.UpDate(row);
                }
            }
            //接收所有的数据变更
            this.AcceptChanges();
        }

        public virtual void AutomaticMerge(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    var exists = this.Rows.Find(new object[] { row["ID"], row["UnID"] });

                    switch (row.RowState)
                    {
                        case DataRowState.Unchanged:
                        case DataRowState.Detached:
                        case DataRowState.Modified:
                        case DataRowState.Added:
                            if (exists == null)
                            {
                                exists = this.NewRow();
                            }

                            exists.BeginEdit();
                            exists.ItemArray = row.ItemArray;
                            exists.EndEdit();
                            break;

                        case DataRowState.Deleted:
                            if (exists != null)
                            {
                                this.Rows.Remove(exists);
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public virtual void SetRowStateAsNew()
        {
            this.AcceptChanges();

            foreach (DataRow row in Rows)
            {
                row.SetAdded();
            }
        }

        /// <summary>
        /// 跟换单位工程关系
        /// </summary>
        /// <param name="p_ObjectKey"></param>
        /// <param name="p_Info"></param>
        public virtual void SetNewFiled(ref int p_ObjectKey, _UnitProject p_Info)
        {


            try
            {


                //同步定单位工程的关系数据
                //分部分项处理
                //int i = 0;
                DataView view = this.DefaultView;

                /*
                 * 田楠
                 * 获取当前打开表名字
                 * 如果是{项目变量表}
                 * 则更换ID
                 * **/
                string tableName = view.Table.TableName.ToString();
                if (tableName == "项目变量表")
                {
                    view.Sort = "ID asc";
                    foreach (DataRowView row in view)
                    {

                        row["ID"] = p_Info.ID;

                    }
                    view.Sort = string.Empty;
                }

                if (view.Table.Columns.Contains("UnID") && view.Table.Columns.Contains("EnID"))
                {
                    view.Sort = "ID asc";
                    foreach (DataRowView row in view)
                    {
                        ///设置为新增的对象
                        row.Row.SetAdded();
                        //row["Key"] = p_ObjectKey + ToolKit.ParseInt(row["ID"]);
                        //row["PKey"] = p_ObjectKey + ToolKit.ParseInt(row["ParentID"]);
                        row["UnID"] = p_Info.ID;
                        row["EnID"] = p_Info.PID;
                        //if (i == 0)
                        //{
                        //    row["PKey"] = p_Info.Key;
                        //}
                        //i++;
                    }
                    //p_ObjectKey = ToolKit.ParseInt(view[view.Count - 1]["Key"]);
                    view.Sort = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 删除当前单位工程数据(删除后自动提交)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void DeleteData(_COBJECTS p_Info)
        {
            DataRow[] rows = this.Select(string.Format(" UnID = {0} and ID <> -1", p_Info.ID));
            foreach (DataRow row in rows)
            {
                this.Rows.Remove(row);
            }
            this.AcceptChanges();
        }

        public void DeleteRows(string key, string value)
        {
            var rows = this.Select(string.Format("{0} = {1}", key, value));
            foreach (var row in rows)
            {
                this.Rows.Remove(row);
            }

            AcceptChanges();
        }

        /// <summary>
        /// 删除当前单位工程数据(删除后自动提交)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void DeleteData(object p_UnID)
        {
            DataRow[] rows = this.Select(string.Format(" UnID = {0} and ID <> -1", p_UnID));
            foreach (DataRow row in rows)
            {
                row.Delete();
            }

        }

        /// <summary>
        /// 项目使用删除单项工程数据
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void DeleteEn(object p_UnID)
        {
            DataRow[] rows = this.Select(string.Format(" EnID = {0} ", p_UnID));
            //if (this.TableName.Equals("项目变量表") || this.TableName.Equals("项目结构表"))
            //{
            //    rows = this.Select(string.Format(" ID = {0} ", p_UnID));
            //}
            //else
            //{
            //    rows = this.Select(string.Format(" UnID = {0} ", p_UnID));
            //}


            foreach (DataRow row in rows)
            {
                this.Rows.Remove(row);
            }
            this.AcceptChanges();
        }

        /// <summary>
        /// 删除编号是-1的数据
        /// </summary>
        public virtual void ClearRoot()
        {
            DataRow[] rows = this.Select(string.Format(" ID = {0} ", -1));
            foreach (DataRow row in rows)
            {
                this.Rows.Remove(row);
            }
            this.AcceptChanges();
        }

        ///// <summary>
        ///// 删除指定单位工程下的数据
        ///// </summary>
        ///// <param name="UnID"></param>
        //public virtual void DeleteForUnID(object UnID)
        //{
        //    DataRow[] rows = this.Select(string.Format(" UnID = {0}", string.Empty));
        //    if (rows != null && rows.Length > 0)
        //    {
        //        foreach (DataRow row in rows)
        //        {
        //            this.Rows.Remove(row);
        //        }
        //    }
        //}

        public void SetPrimaryKey(params string[] columnNames)
        {
            var columns = new List<DataColumn>();

            foreach (var name in columnNames)
            {
                if (this.Columns.Contains(name))
                {
                    columns.Add(this.Columns[name]);
                }
            }

            this.PrimaryKey = columns.ToArray();
        }
    }
}
