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
    public class _VariableSource:_ObjectSource
    {

        protected _VariableSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ;
        }

        public const string Median = "F2";

        public _VariableSource()
        {
            this.TableName = "变量表";
            Builder();
        }

        public _VariableSource(string p_TableName)
        {
            this.TableName = p_TableName;
            Builder();
        }

         /// <summary>
        /// 构造一个变量表
        /// </summary>
        private void Builder()
        {
            DataColumn dc1 = this.Columns.Add("Key", typeof(string));//属性名称(显示的名称)
            DataColumn dc2 = this.Columns.Add("ID", typeof(object));//属性值
            this.Columns.Add("Value", typeof(decimal));//属性值
            this.Columns.Add("Remark", typeof(string));//(源字段)名称
            this.Columns.Add("Length", typeof(int));//(源字段)名称
            this.Columns.Add("FYLB", typeof(string));//(费用类别)
            DataColumn dc3 = this.Columns.Add("Type",typeof(int));//所属类别 措施 分部 单位工程
            this.Columns.Add("ISDE", typeof(bool));//定额、非定额
            this.Columns.Add("Sort", typeof(int));
            this.Columns.Add("EnID", typeof(int));//所属单项工程编号(单位工程统计后此对象赋值)
            this.PrimaryKey = new DataColumn[] { dc1, dc2, dc3 };
        }



        /// <summary>
        /// 创建子目变量对象
        /// </summary>
        public void Init_ZM(int p_ID,int p_Type)
        {
            #region 市场费单价
            //this.Set(p_ID,p_Type, "ZJFDJ", 0, "[子目]直接费单价");
            //this.Set(p_ID,p_Type,"RGFDJ", 0, "[子目]人工费单价");
            //this.Set(p_ID,p_Type, "CLFDJ", 0, "[子目]材料费单价");
            //this.Set(p_ID, p_Type, "JXFDJ", 0, "[子目]机械费单价");
            //this.Set(p_ID, p_Type, "ZCFDJ", 0, "[子目]主材费单价");
            //this.Set(p_ID, p_Type, "SBFDJ", 0, "[子目]设备费单价");
            //this.Set(p_ID, p_Type, "JGCL", 0, "[子目]甲供材料单价");
            //this.Set(p_ID, p_Type, "YGCL", 0, "[子目]乙供材料单价");
            //this.Set(p_ID, p_Type, "ZDJCL", 0, "[子目]暂定材料单价");
            //this.Set(p_ID, p_Type, "PBZDCL", 0, "[子目]评标材料单价");

            //this.Set(p_ID, p_Type, "FXDJ", 0, "[子目]风险单价", false);
            //this.Set(p_ID, p_Type, "GLFDJ", 0, "[子目]管理费单价", false);
            //this.Set(p_ID,p_Type,"LRFDJ", 0, "[子目]利润单价", false);
            //this.Set(p_ID, p_Type, "GFDJ", 0, "[子目]规费单价", false);
            //this.Set(p_ID, p_Type, "SJDJ", 0, "[子目]税金单价", false);
            //this.Set(p_ID, p_Type, "ZMDJ", 0, "[子目]子目单价", false);


         
            #endregion

            #region 定额费单价
            //this.Set(p_ID, p_Type, "DEZJFDJ", 0, "[子目]定额直接费单价");
            //this.Set(p_ID, p_Type, "DERGFDJ", 0, "[子目]定额人工费单价");
            //this.Set(p_ID, p_Type, "DECLFDJ", 0, "[子目]定额材料费单价");
            //this.Set(p_ID, p_Type, "DEJXFDJ", 0, "[子目]定额机械费单价");
            //this.Set(p_ID, p_Type, "DEZCFDJ", 0, "[子目]定额主材费单价");
            //this.Set(p_ID, p_Type, "DESBFDJ", 0, "[子目]定额设备费单价");
            //this.Set(p_ID, p_Type, "DEJGCL", 0, "[子目]定额甲供材料单价");
            //this.Set(p_ID, p_Type, "DEYGCL", 0, "[子目]定额乙供材料单价");
            //this.Set(p_ID, p_Type, "DEZDJCL", 0, "[子目]定额暂定材料单价");
            //this.Set(p_ID, p_Type, "DEPBZDCL", 0, "[子目]定额评标材料单价");

            //this.Set(p_ID, p_Type, "DEFXDJ", 0, "[子目]定额风险单价", true);
            //this.Set(p_ID, p_Type, "DEGLFDJ", 0, "[子目]定额管理费单价", true);
            //this.Set(p_ID, p_Type, "DELRFDJ", 0, "[子目]定额利润单价", true);
            //this.Set(p_ID, p_Type, "DEGFDJ", 0, "[子目]定额规费单价", true);
            //this.Set(p_ID, p_Type, "DESJDJ", 0, "[子目]定额税金单价", true);
            //this.Set(p_ID, p_Type, "DEZMDJ", 0, "[子目]定额子目单价", true);
            #endregion

            #region 人材机%合计
            //this.Set(p_ID, p_Type, "RGBFHHJ", 0, "[子目]人工%合计", true);
            //this.Set(p_ID, p_Type, "CLBFHHJ", 0, "[子目]材料%合计", true);
            //this.Set(p_ID, p_Type, "JXBFHHJ", 0, "[子目]机械%合计", true);
            #endregion

            #region 价差和差价
            //this.Set(p_ID, p_Type, "JCDJ", 0, "[子目]价差单价", true);
            //this.Set(p_ID, p_Type, "RGJCDJ", 0, "[子目]人工费价差单价", true);
            //this.Set(p_ID, p_Type, "CLJCDJ", 0, "[子目]材料费价差单价", true);
            //this.Set(p_ID, p_Type, "JXJCDJ", 0, "[子目]机械费价差单价", true);
            //this.Set(p_ID, p_Type, "CJDJ", 0, "[子目]差价单价", true);
            //this.Set(p_ID, p_Type, "RGCJDJ", 0, "[子目]人工费差价单价", true);
            //this.Set(p_ID, p_Type, "CLCJDJ", 0, "[子目]材料费差价单价", true);
            //this.Set(p_ID, p_Type, "JXCJDJ", 0, "[子目]机械费差价单价", true);
            #endregion

            #region 子目参数
            //this.Set(p_ID, p_Type, "JC", 0, "[子目]价差");
            //this.Set(p_ID, p_Type, "GCL", 0, "[子目]工程量");
            //this.Set(p_ID, p_Type, "FXRCJ", 0, "[子目]参与风险计算的人材机");
            //this.Set(p_ID, p_Type, "HHJXFDJ", 0, "[子目]混合机械费单价");
            //this.Set(p_ID, p_Type, "DZJXTB", 0, "[子目]吊装机械台班", true);
            #endregion
        }


        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        public void Set(int p_ID,int p_Type,string key, object value)
        {
            //lock (this)
            {
                DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
                if (row == null)
                {
                    row = this.NewRow();
                    row.BeginEdit();
                    row["ID"] = p_ID;
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row["Type"] = p_Type;
                    row["ISDE"] = false;
                    row.EndEdit();
                    this.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["ID"] = p_ID;
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row["Type"] = p_Type;
                    row["ISDE"] = false;
                    row.EndEdit();
                }
            }
        }

       
        /// <summary>
        /// 设置一个变量(项目单位工程中使用统计使用)
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        public void Set(int p_EnID ,int p_ID, int p_Type, string key, object value)
        {
            //lock (this)
            {
                DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
                if (row == null)
                {
                    row = this.NewRow();
                    row.BeginEdit();
                    row["ID"] = p_ID;
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row["Type"] = p_Type;
                    row["ISDE"] = false;
                    row["EnID"] = p_EnID;
                    row.EndEdit();
                    this.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["ID"] = p_ID;
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row["Type"] = p_Type;
                    row["ISDE"] = false;
                    row["EnID"] = p_EnID;
                    row.EndEdit();
                }
            }
        }

        public void Set(int p_ID, int p_Type, string key, object value,bool p_ISDE,string remark)
        {
            //lock (this)
            {
                DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
                if (row == null)
                {
                    row = this.NewRow();
                    row.BeginEdit();
                    row["ID"] = p_ID;
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row["Type"] = p_Type;
                    row["ISDE"] = p_ISDE;
                    row["Remark"] = remark;
                    row.EndEdit();
                    this.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["ID"] = p_ID;
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Length"] = key.Length;
                    row["Type"] = p_Type;
                    row["ISDE"] = p_ISDE;
                    row["Remark"] = remark;
                    row.EndEdit();
                }
            }
        }

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        /// <param name="remark">变量说明</param>
        public void Set(int p_ID,int p_Type,string key, object value, string remark)
        {
            //lock (this)
            {

                DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
                if (row == null)
                {
                    row = this.NewRow();
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    row["ISDE"] = false;
                    row["Type"] = p_Type;
                    row["ID"] = p_ID;
                    row.EndEdit();
                    this.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    row["ISDE"] = false;
                    row["Type"] = p_Type;
                    row["ID"] = p_ID;
                    row.EndEdit();
                }
            }
        }

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        /// <param name="remark">变量说明</param>
        public void Set(int p_EnID,int p_ID, int p_Type, string key, object value, string remark)
        {
            //lock (this)
            {

                DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
                if (row == null)
                {
                    row = this.NewRow();
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    row["ISDE"] = false;
                    row["Type"] = p_Type;
                    row["ID"] = p_ID;
                    row["EnID"] = p_EnID;
                    row.EndEdit();
                    this.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    row["ISDE"] = false;
                    row["Type"] = p_Type;
                    row["ID"] = p_ID;
                    row["EnID"] = p_EnID;
                    row.EndEdit();
                }
            }
        }

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        /// <param name="remark">变量说明</param>
        public void Set(int p_ID,int p_Type,string key, object value, string remark, bool p_ISDE)
        {
            //lock (this)
            {

                DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
                if (row == null)
                {
                    row = this.NewRow();
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    row["ISDE"] = p_ISDE;
                    row["Type"] = p_Type;
                    row["ID"] = p_ID;
                    row.EndEdit();
                    this.Rows.Add(row);
                }
                else
                {
                    row.BeginEdit();
                    row["Key"] = key;
                    row["Value"] = Convert.ToDecimal(value).ToString(Median);
                    row["Remark"] = remark;
                    row["Length"] = key.Length;
                    row["ISDE"] = p_ISDE;
                    row["Type"] = p_Type;
                    row["ID"] = p_ID;
                    row.EndEdit();
                }
            }
        }

        /// <summary>
        /// 设置一个变量
        /// </summary>
        /// <param name="key">变量主键</param>
        /// <param name="value">变量值</param>
        /// <param name="remark">变量说明</param>
        public void Set(int p_ID,int p_Type,string key, object value, string remark, string p_fylb,bool p_ISDE)
        {
            DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
            if (row == null)
            {
                row = this.NewRow();
                row.BeginEdit();
                row["Key"] = key;
                row["Value"] = ToolKit.ParseDecimal(value).ToString(Median);
                row["Remark"] = remark;
                row["FYLB"] = p_fylb;
                row["Length"] = key.Length;
                row["ISDE"] = p_ISDE;
                row["Type"] = p_Type;
                row["ID"] = p_ID;
                row.EndEdit();
                this.Rows.Add(row);
            }
            else
            {
                row.BeginEdit();
                row["Key"] = key;
                row["Value"] = ToolKit.ParseDecimal(value).ToString(Median);
                row["Remark"] = remark;
                row["FYLB"] = p_fylb;
                row["Length"] = key.Length;
                row["ISDE"] = p_ISDE;
                row["Type"] = p_Type;
                row["ID"] = p_ID;
                row.EndEdit();
                
            }
        }


        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public object Get(int p_ID,int p_Type,string key)
        {
            DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
            if (row != null)
            {
                return row["Value"];
            }
            return null;
        }
        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public decimal GetDecimal(int p_ID,int p_Type,string key)
        {
            DataRow row = this.Rows.Find(new object[] { key, p_ID, p_Type });
            if (row != null)
            {
                return ToolKit.ParseDecimal(row["Value"]);
            }
            return 0;
        }

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public decimal GetDecimal(int p_Type, string key)
        {
            DataRow row = this.Rows.Find(new object[] { key, p_Type });
            if (row != null)
            {
                return ToolKit.ParseDecimal(row["Value"]);
            }
            return 0;
        }

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public decimal GetDecimalBYFylb(int p_ID,int p_Type,string key)
        {
            //lock (this)
            {
                DataRow[] row = this.Select(string.Format("FYLB='{0}' and ISDE='{1}' and ID={2} and TYPE ={3}", key, false, p_ID, p_Type));

                if (row.Length == 1)
                {
                    return Convert.ToDecimal(row[0]["Value"].ToString());
                }
                return 0;
            }
        }

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="key">变量值</param>
        /// <returns></returns>
        public decimal GetDecimalBYFylb(int p_ID, int p_Type, string key, bool p_ISDE)
        {
            //lock (this)
            {
                DataRow[] row = this.Select(string.Format("FYLB='{0}' and ISDE='{1}' and ID={2} and TYPE ={3}", key, p_ISDE, p_ID, p_Type));
                if (row.Length == 1)
                {
                    return Convert.ToDecimal(row[0]["Value"].ToString());
                }
                return 0;
            }
        }


        /// <summary>
        /// 为指定单位工程重新设置关系数据(导入单位工程的时候使用)
        /// </summary>
        /// <param name="p_Info"></param>
        public void SetNewFiled(_COBJECTS p_Info)
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
                row["ID"] = p_Info.ID;
                row["EnID"] = p_Info.PID;
                i++;
            }
            view.Sort = string.Empty;
        }

        /// <summary>
        /// 项目中删除调用
        /// </summary>
        /// <param name="p_Info"></param>
        public  override void DeleteData(_COBJECTS p_Info)
        {
            DataRow[] rows = this.Select(string.Format(" ID = {0} ", p_Info.ID));
            foreach (DataRow row in rows)
            {
                this.Rows.Remove(row);
            }
            //this.AcceptChanges();
        }

        /// <summary>
        /// 合并变量表
        /// </summary>
        /// <param name="table"></param>
        public override void MergeData(DataTable table)
        {
            foreach (DataRowView row in table.DefaultView)
            {
                this.UpDate(row);
            }
            //接收所有的数据变更
            this.AcceptChanges();
        }

        public void MergeData(DataTable table, bool p_IsAccpt)
        {
            foreach (DataRowView row in table.DefaultView)
            {
                this.UpDate(row);
            }
            if(p_IsAccpt)
                this.AcceptChanges();
        }

        /// <summary>
        /// 将新的row对象更新到当前列表(项目中使用)
        /// </summary>
        /// <param name="row"></param>
        public virtual void UpDate(DataRowView row)
        {
            try
            {
                //找到当前行
                DataRow r = this.Rows.Find(new object[] { row["Key"], row["ID"], row["Type"] });
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public override void DeleteData(object p_UnID)
        {
            DataRow[] rows = this.Select(string.Format(" ID = {0}", p_UnID));
            foreach (DataRow row in rows)
            {
                this.Rows.Remove(row);
            }
            
        }

        /// <summary>
        /// 创建子目变量对象
        /// </summary>
        public static _VariableSource CreateInstance(int p_EnID,int p_Type)
        {
            _VariableSource UNResultVarable = new _VariableSource();
            #region -----------------------------分部分项最终参数------------------------
            UNResultVarable.Set(p_EnID, p_Type, "FBFXHJ", 0, "[分部分项]分部分项合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXRGFHJ", 0, "[分部分项]分部分项人工费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXCLFHJ", 0, "[分部分项]分部分项材料费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXZCFHJ", 0, "[分部分项]分部分项主材费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXSBFHJ", 0, "[分部分项]分部分项设备费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXJXFHJ", 0, "[分部分项]分部分项机械费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXGLFHJ", 0, "[分部分项]分部分项管理费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXLRHJ", 0, "[分部分项]分部分项利润合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXFXHJ", 0, "[分部分项]分部分项风险合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXZGJEHJ", 0, "[分部分项]分部分项暂估金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXJGJEHJ", 0, "[分部分项]分部分项甲供金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXFBJEHJ", 0, "[分部分项]分部分项分包金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXJBHZHJ", 0, "[分部分项]分部分项局部汇总金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEHJ", 0, "[分部分项]分部分项定额价合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDERGFHJ", 0, "[分部分项]分部分项定额人工费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDECLFHJ", 0, "[分部分项]分部分项定额材料费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEZCFHJ", 0, "[分部分项]分部分项定额主材费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDESBFHJ", 0, "[分部分项]分部分项定额设备费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEJXFHJ", 0, "[分部分项]分部分项定额机械费合计");
            //UNResultVarable.Set(p_EnID, p_Type, "FBFXDEGLFHJ", 0, "[分部分项]分部分项定额管理费合计");
            //UNResultVarable.Set(p_EnID, p_Type, "FBFXDELRHJ", 0, "[分部分项]分部分项定额利润合计");
            //UNResultVarable.Set(p_EnID, p_Type, "FBFXDEFXHJ", 0, "[分部分项]分部分项定额风险合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEZGJEHJ", 0, "[分部分项]分部分项定额暂估金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEJGJEHJ", 0, "[分部分项]分部分项定额甲供金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEFBJEHJ", 0, "[分部分项]分部分项定额分包金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXDEJBHZHJ", 0, "[分部分项]分部分项定额局部汇总金额合计");


            // this.UNResultVarable.Set(p_EnID,p_Type,"HHJXFHJ", 0, "[分部分项]混合机械人工费合价");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXJCHJ", 0, "[分部分项]分部分项价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXRGJCHJ", 0, "[分部分项]分部分项人工费价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXCLJCHJ", 0, "[分部分项]分部分项材料费价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXJXJCHJ", 0, "[分部分项]分部分项机械费价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXCJHJ", 0, "[分部分项]分部分项可能发生的差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXRGCJHJ", 0, "[分部分项]分部分项人工费调增差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXCLCJHJ", 0, "[分部分项]分部分项材料费调增差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXJXCJHJ", 0, "[分部分项]分部分项机械费调增差价合计");

            UNResultVarable.Set(p_EnID, p_Type, "Z[人工].rgf", 0, "[分部分项]定额特项为“人工”的人工费");
            UNResultVarable.Set(p_EnID, p_Type, "Q[ZS].jxf", 0, "[分部分项]清单特项为“ZS”的综合合价");
            UNResultVarable.Set(p_EnID, p_Type, "Z[建筑].rgf", 0, "[分部分项]定额特项为“建筑”的人工费");
            UNResultVarable.Set(p_EnID, p_Type, "Z[安装].rgf", 0, "[分部分项]定额特项为“安装”的人工费");
            UNResultVarable.Set(p_EnID, p_Type, "Z[桩基].clf", 0, "[分部分项]定额特项为“桩基”的材料费");

            UNResultVarable.Set(p_EnID, p_Type, "Z[建筑].jxf", 0, "[分部分项]定额特项为“建筑”的机械费");
            UNResultVarable.Set(p_EnID, p_Type, "Z[机械].xmf", 0, "[分部分项]定额特项为“机械”的综合合价");
            UNResultVarable.Set(p_EnID, p_Type, "Z[桩基].xmf", 0, "[分部分项]定额特项为“桩基”的综合合价");
            UNResultVarable.Set(p_EnID, p_Type, "Z[建筑].xmf", 0, "[分部分项]定额特项为“建筑”的综合合价");
            UNResultVarable.Set(p_EnID, p_Type, "Z[装饰].xmf", 0, "[分部分项]定额特项为“装饰”的综合合价");

            UNResultVarable.Set(p_EnID, p_Type, "Q[JZ].xmf", 0, "[分部分项]清单特项为“JZ”的综合合价");
            UNResultVarable.Set(p_EnID, p_Type, "Q[ZS].jxf", 0, "[分部分项]清单特项为“ZS”的综合合价");

            UNResultVarable.Set(p_EnID, p_Type, "FBFXGFHJ", 0, "[分部分项]分部分项规费合计");
            UNResultVarable.Set(p_EnID, p_Type, "FBFXSJHJ", 0, "[分部分项]分部分项税金合计");

            UNResultVarable.Set(p_EnID, p_Type, "FBFXZJFHJ", 0, "[分部分项]分部分项直接费合价");
            #endregion

            #region -------------------------------措施项目最终参数------------------------
            UNResultVarable.Set(p_EnID, p_Type, "CSXMHJ", 0, "[措施项目]措施项目合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMRGFHJ", 0, "[措施项目]措施项目人工费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMCLFHJ", 0, "[措施项目]措施项目材料费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMZCFHJ", 0, "[措施项目]措施项目主材费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMSBFHJ", 0, "[措施项目]措施项目设备费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMJXFHJ", 0, "[措施项目]措施项目机械费合计");

            UNResultVarable.Set(p_EnID, p_Type, "CSXMGLFHJ", 0, "[措施项目]措施项目管理费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMLRHJ", 0, "[措施项目]措施项目利润合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMFXHJ", 0, "[措施项目]措施项目风险合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMZGJEHJ", 0, "[措施项目]措施项目暂估金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMJGJEHJ", 0, "[措施项目]措施项目甲供金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMFBJEHJ", 0, "[措施项目]措施项目分包金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMJBHZHJ", 0, "[措施项目]措施项目局部汇总金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEHJ", 0, "[措施项目]措施项目定额价合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDERGFHJ", 0, "[措施项目]措施项目定额人工费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDECLFHJ", 0, "[措施项目]措施项目定额材料费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEZCFHJ", 0, "[措施项目]措施项目定额主材费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDESBFHJ", 0, "[措施项目]措施项目定额设备费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEJXFHJ", 0, "[措施项目]措施项目定额机械费合计");

            //UNResultVarable.Set(p_EnID, p_Type, "CSXMDEGLFHJ", 0, "[措施项目]措施项目定额管理费合计");
            //UNResultVarable.Set(p_EnID, p_Type, "CSXMDELRHJ", 0, "[措施项目]措施项目定额利润合计");
            //UNResultVarable.Set(p_EnID, p_Type, "CSXMDEFXHJ", 0, "[措施项目]措施项目定额风险合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEZGJEHJ", 0, "[措施项目]措施项目定额暂估金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEJGJEHJ", 0, "[措施项目]措施项目定额甲供金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEFBJEHJ", 0, "[措施项目]措施项目定额分包金额合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMDEJBHZHJ", 0, "[措施项目]措施项目定额局部汇总金额合计");
            //this.UNResultVarable.Set(p_EnID,p_Type,"CSXMJC"         , 0, "[措施项目]措施项目价差");
            //this.UNResultVarable.Set(p_EnID,p_Type,"CSXMCJ"         , 0, "[措施项目]措施项目差价");

            //this.UNResultVarable.Set(p_EnID,p_Type,"HHJXFHJ", 0, "[措施项目]混合机械人工费合价");
            //this.UNResultVarable.Set(p_EnID,p_Type,"FBFXJCHJ", 0, "[措施项目]分部分项价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMJCHJ", 0, "[措施项目]措施项目价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMRGJCHJ", 0, "[措施项目]措施项目人工费价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMCLJCHJ", 0, "[措施项目]措施项目材料费价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMJXJCHJ", 0, "[措施项目]措施项目机械费价差合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMCJHJ", 0, "[措施项目]措施项目可能发生的差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMRGCJHJ", 0, "[措施项目]措施项目人工费调增差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMCLCJHJ", 0, "[措施项目]措施项目材料费调增差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMJXCJHJ", 0, "[措施项目]措施项目机械费调增差价合计");

            UNResultVarable.Set(p_EnID, p_Type, "CSAQWM", 0, "[措施项目]安全文明施工措施费");
            UNResultVarable.Set(p_EnID, p_Type, "CSWMSG", 0, "[措施项目]安全文明施工费");
            UNResultVarable.Set(p_EnID, p_Type, "CSHJBH", 0, "[措施项目]环境保护费（含排污）");
            UNResultVarable.Set(p_EnID, p_Type, "CSLSSS", 0, "[措施项目]临时设施费");

            UNResultVarable.Set(p_EnID, p_Type, "CSXMGFHJ", 0, "[措施项目]措施项目规费合计");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMSJHJ", 0, "[措施项目]措施项目税金合计");
            UNResultVarable.Set(p_EnID, p_Type, "KCAQWMCSF", 0, "[措施项目]扣除安全文明施工费");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMZJFHJ", 0, "[措施项目]措施项目直接费合价");
            #endregion

            #region -------------------------------其他项目最终参数------------------------
            UNResultVarable.Set(p_EnID, p_Type, "QTXMHJ", 0, "[其他项目]其他项目合计");
            UNResultVarable.Set(p_EnID, p_Type, "QTXMCJHJ", 0, "[其他项目]其他项目差价合价");
            UNResultVarable.Set(p_EnID, p_Type, "QTXMJSCJHJ", 0, "[其他项目]其他项目结算差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "QTXMRGCJHJ", 0, "[其他项目]其他项目人工费调增差价合计");
            UNResultVarable.Set(p_EnID, p_Type, "ZLJE", 0, "[其他项目]暂列金额");
            UNResultVarable.Set(p_EnID, p_Type, "SJBGCJ", 0, "[其他项目]设计变更及材料（主材）差价");
            UNResultVarable.Set(p_EnID, p_Type, "ZYGCZGJ", 0, "[其他项目]专业工程暂估价");
            UNResultVarable.Set(p_EnID, p_Type, "ZCSBZGJ", 0, "[其他项目]主材设备暂估价");
            UNResultVarable.Set(p_EnID, p_Type, "LXFBGCE", 0, "[其他项目]另行分包的专业工程金额");
            UNResultVarable.Set(p_EnID, p_Type, "JRG", 0, "[其他项目]计日工");
            UNResultVarable.Set(p_EnID, p_Type, "JRGRG", 0, "[其他项目]人工");
            UNResultVarable.Set(p_EnID, p_Type, "JRGCL", 0, "[其他项目]材料");
            UNResultVarable.Set(p_EnID, p_Type, "JRGJX", 0, "[其他项目]机械");
            UNResultVarable.Set(p_EnID, p_Type, "ZCBFWF", 0, "[其他项目]总承包服务费");
            UNResultVarable.Set(p_EnID, p_Type, "FBGLFWF", 0, "[其他项目]发包人发包专业工程管理服务费");
            UNResultVarable.Set(p_EnID, p_Type, "FBRBGF", 0, "[其他项目]发包人供应材料、设备保管费");
            UNResultVarable.Set(p_EnID, p_Type, "FSPTJJJ", 0, "[其他项目]副食品调节基金");
            #endregion

            #region -------------------------------汇总分析------------------------
            UNResultVarable.Set(p_EnID, p_Type, "FGCF", 0, "[汇总分析]分部分项工程费");
            UNResultVarable.Set(p_EnID, p_Type, "CSXMF", 0, "[汇总分析]措施项目费");
            UNResultVarable.Set(p_EnID, p_Type, "QTXMF", 0, "[汇总分析]其他项目费");
            UNResultVarable.Set(p_EnID, p_Type, "GF", 0, "[汇总分析]规费");
            UNResultVarable.Set(p_EnID, p_Type, "BHSZJ", 0, "[汇总分析]不含税单位工程造价");
            UNResultVarable.Set(p_EnID, p_Type, "SJ", 0, "[汇总分析]税金");
            UNResultVarable.Set(p_EnID, p_Type, "GCZJ", 0, "[汇总分析]含税单位工程造价");
            UNResultVarable.Set(p_EnID, p_Type, "ZZJ", 0, "[汇总分析]扣除养老保险后含税单位工程造价");
            UNResultVarable.Set(p_EnID, p_Type, "AQWM", 0, "[汇总分析]安全文明施工费");
            #endregion

            return UNResultVarable;
        }
    }
}
