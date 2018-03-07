/*
 *   项目结构表 (单独单位工程此表只有一条数据)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using ZiboSoft.Commons.Common;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ProjSource : _ObjectSource
    {

        protected _ProjSource(SerializationInfo info, StreamingContext context)
             : base(info, context)
        {
            
        }

        public _ProjSource():base()
        {
            this.TableName = "项目结构表";
            Builder();
        }

        public _ProjSource(bool IsProj)
            : base()
        {
            if (IsProj)
            {
                this.TableName = "项目结构表";
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
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("CODE", typeof(string));
            this.Columns.Add("QDGZ", typeof(string));
            this.Columns.Add("DEGZ", typeof(string));
            this.Columns.Add("PGCDD", typeof(string));
            this.Columns.Add("PJFCX", typeof(int));
            this.Columns.Add("PNSDD", typeof(string));
            this.Columns.Add("CREATOR", typeof(string));
            this.Columns.Add("EDITOR", typeof(string));
            this.Columns.Add("FISTDATETIME", typeof(DateTime));
            this.Columns.Add("EDITDATETIME", typeof(DateTime));
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("Deep", typeof(int));
            this.Columns.Add("NodeName", typeof(string));
            this.Columns.Add("PlaitNo", typeof(string));
            this.Columns.Add("ReviewName", typeof(string));
            this.Columns.Add("PlaitName", typeof(string));
            this.Columns.Add("PlaitDate", typeof(DateTime));
            this.Columns.Add("ReviewDate", typeof(DateTime));
            this.Columns.Add("ProType", typeof(string));
            this.Columns.Add("PrfType", typeof(string));
            this.Columns.Add("Remark", typeof(string));
            this.Columns.Add("QDLibName", typeof(string));
            this.Columns.Add("DELibName", typeof(string));
            this.Columns.Add("TJLibName", typeof(string));
            this.Columns.Add("JMSH", typeof(string));
            this.Columns.Add("JQH", typeof(string));
            this.Columns.Add("OBJECT",typeof(byte[]));
            this.Columns.Add("UnitProject", typeof(object));
            this.Columns.Add("JSDW", typeof(string));//建设单位
            this.Columns.Add("JZMJ", typeof(decimal));//建筑面积
            this.Columns.Add("DWZJ", typeof(decimal));//单位造价
            this.Columns.Add("ZZJB", typeof(decimal));//占总价比（%）
            this.Columns.Add("BZ", typeof(string));//备注
            this.Columns.Add("PassWord",typeof(string));//加密密码
            this.Columns.Add("Time", typeof(string));//加密密码
            this.Columns.Add("ImageIndex", typeof(int));//图片索引
            this.Columns.Add("State", typeof(string));//状态
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
            this.Columns.Add("Name", typeof(string));
            this.Columns.Add("CODE", typeof(string));
            this.Columns.Add("QDGZ", typeof(string));
            this.Columns.Add("DEGZ", typeof(string));
            this.Columns.Add("PGCDD", typeof(string));
            this.Columns.Add("PJFCX", typeof(int));
            this.Columns.Add("PNSDD", typeof(string));
            this.Columns.Add("CREATOR", typeof(string));
            this.Columns.Add("EDITOR", typeof(string));
            this.Columns.Add("FISTDATETIME", typeof(DateTime));
            this.Columns.Add("EDITDATETIME", typeof(DateTime));
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("Deep", typeof(int));
            this.Columns.Add("NodeName", typeof(string));
            this.Columns.Add("PlaitNo", typeof(string));
            this.Columns.Add("ReviewName", typeof(string));
            this.Columns.Add("PlaitName", typeof(string));
            this.Columns.Add("PlaitDate", typeof(DateTime));
            this.Columns.Add("ReviewDate", typeof(DateTime));
            this.Columns.Add("ProType", typeof(string));
            this.Columns.Add("PrfType", typeof(string));
            this.Columns.Add("Remark", typeof(string));
            this.Columns.Add("QDLibName", typeof(string));
            this.Columns.Add("DELibName", typeof(string));
            this.Columns.Add("TJLibName", typeof(string));
            this.Columns.Add("JMSH", typeof(string));
            this.Columns.Add("JQH", typeof(string));
            this.Columns.Add("Key", typeof(int));
            this.Columns.Add("PKey", typeof(int));
            this.Columns.Add("OBJECT", typeof(byte[]));
            this.Columns.Add("UnitProject", typeof(object));
            this.Columns.Add("JSDW", typeof(string));//建设单位
            this.Columns.Add("JZMJ", typeof(decimal));//建筑面积
            this.Columns.Add("DWZJ", typeof(decimal));//单位造价
            this.Columns.Add("ZZJB", typeof(decimal));//占总价比（%）
            this.Columns.Add("BZ", typeof(string));//备注
            this.Columns.Add("PassWord", typeof(string));//加密密码
            this.Columns.Add("Time", typeof(string));//加密密码
            this.Columns.Add("ImageIndex", typeof(int));//图片索引
            this.Columns.Add("State",typeof(string));//状态
            this.Columns[0].AutoIncrement = true;
            this.Columns[0].AutoIncrementSeed = 1;
            this.Columns[0].AutoIncrementStep = 1;
            this.PrimaryKey = new DataColumn[] { this.Columns[0] };
        }



        /// <summary>
        /// 给当前数据行追加单位工程对象
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void AppendUnit(_COBJECTS  p_Info)
        {
            DataRow row = this.Rows.Find(p_Info.ID);
            //DataRowState rs = row.RowState;
            
            row["UnitProject"] = p_Info;
            
            /*if (rs == DataRowState.Unchanged)
            {
                row.AcceptChanges();
            }*/
        }

        public void UpDateData(object p_Info, int activitieId)
        {
            _COBJECTS obj = p_Info as _COBJECTS;
            if (obj != null)
            {
                DataRow row = this.Rows.Find(activitieId);
                Type tp = p_Info.GetType();
                if (row != null)
                {
                    row.BeginEdit();
                    //循环列添加数据对象
                    foreach (DataColumn col in this.Columns)
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
                }
            }
        }


        public override void UpDate(object p_Info)
        {
            _COBJECTS obj =  p_Info as _COBJECTS;
            if (obj != null)
            {
                DataRow row = this.Rows.Find(obj.ID);
                Type tp = p_Info.GetType();
                if (row != null)
                {
                    row.BeginEdit();
                    //循环列添加数据对象
                    foreach (DataColumn col in this.Columns)
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
                }
            }
        }

        /// <summary>
        /// 修改指定行状态为编辑
        /// </summary>
        /// <param name="p_ID"></param>
        public void SetModifty(int p_ID)
        {
            DataRow row = this.Rows.Find(p_ID);
            if (row != null)
            {
                if (row.RowState == DataRowState.Unchanged)
                {
                    row.SetModified();
                }
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

            return this.Rows.Find(row["UnID"]);
        }

        /// <summary>
        /// 查询指定DataRow中的当前父节点Row对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public DataRow GetRowByOther(DataRowView row)
        {
            if (row == null) return null;

            return this.Rows.Find(row["UnID"]);
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

        /*public _ProjSource CopyA()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                object CloneObject;
                BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                // 反序列化至另一个对象(即创建了一个原对象的深表副本)
                CloneObject = bf.Deserialize(ms);
                // 关闭流
                ms.Close();
                return CloneObject as _ProjSource;
            }
        }*/
        /// <summary>
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public override void UpDate(DataRowView row)
        {
            //找到当前行
            DataRow r = this.Rows.Find(new object[] { row["ID"] });
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
