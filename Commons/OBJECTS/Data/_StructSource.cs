/*
 * 项目单项工程的结构数据源对象(用于存放当前对象中的所有数据表)
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
    public class _StructSource : DataSet
    {

        #region ------------------------数据表属性---------------------------
        /// <summary>
        /// 获取项目结构表
        /// </summary>
        public _ProjSource ModelProject
        {
            get
            {
                return this.Tables["项目结构表"] as _ProjSource;
            }
            set
            {
                this.Tables.Remove("项目结构表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 分部分项表
        /// </summary>
        public _SubSegmentsSource ModelSubSegments
        {
            get
            {
                return this.Tables["分部分项表"] as _SubSegmentsSource;
            }
            set
            {
                this.Tables.Remove("分部分项表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 工料机
        /// </summary>
        public _QuantitySource ModelQuantity
        {
            get
            {
                return this.Tables["工料机"] as _QuantitySource;
            }
            set
            {
                this.Tables.Remove("工料机");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 措施项目表
        /// </summary>
        public _MeasuresSource ModelMeasures
        {
            get
            {
                return this.Tables["措施项目表"] as _MeasuresSource;
            }
            set
            {
                this.Tables.Remove("措施项目表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 汇总分析
        /// </summary>
        public _MetaanalysisSource ModelMetaanalysis
        {
            get
            {
                return this.Tables["汇总分析表"] as _MetaanalysisSource;
            }
            set
            {
                this.Tables.Remove("汇总分析表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 项目汇总分析表
        /// </summary>
        public _ProjMetaanalysisSource ModelProjMetaanalysis
        {
            get
            {
                return this.Tables["项目汇总分析表"] as _ProjMetaanalysisSource;
            }
            set
            {
                this.Tables.Remove("项目汇总分析表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 子目取费表
        /// </summary>
        public _SubheadingsFeeSource ModelSubheadingsFee
        {
            get
            {
                return this.Tables["子目取费表"] as _SubheadingsFeeSource;
            }
            set
            {
                this.Tables.Remove("子目取费表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 参数子目取费表
        /// </summary>
        public _PSubheadingsFeeSource ModelPSubheadingsFee
        {
            get
            {
                return this.Tables["参数子目取费表"] as _PSubheadingsFeeSource;
            }
            set
            {
                this.Tables.Remove("参数子目取费表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 标准换算表
        /// </summary>
        public _StandardConversionSource ModelStandardConversion
        {
            get
            {
                return this.Tables["标准换算表"] as _StandardConversionSource;
            }
            set
            {
                this.Tables.Remove("标准换算表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 临时变量表(不参与保存)
        /// </summary>
        public _VariableSource ModelVariable
        {
            get
            {
                return this.Tables["临时变量表"] as _VariableSource;
            }
            set
            {
                this.Tables.Remove("临时变量表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 变量表(不参与保存 最终结果)
        /// </summary>
        public _VariableSource ModelResultVariable
        {
            get
            {
                return this.Tables["变量表"] as _VariableSource;
            }
            set
            {
                if (this.Tables.Contains(value.TableName))
                {
                    this.Tables.Remove(value.TableName);

                }
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 项目变量表(不参与保存 最终结果)
        /// </summary>
        public _VariableSource ModelProjVariable
        {
            get
            {
                return this.Tables["项目变量表"] as _VariableSource;
            }
            set
            {

                if (this.Tables.Contains(value.TableName))
                {
                    this.Tables.Remove(value.TableName);

                }
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 安装增加费(不参与保存 最终结果)
        /// </summary>
        public _IncreaseCostsSource ModelIncreaseCosts
        {
            get
            {
                return this.Tables["安装增加费"] as _IncreaseCostsSource;
            }
            set
            {
                this.Tables.Remove("安装增加费");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 用途类别表(不参与保存 最终结果)
        /// </summary>
        public _YTLBSummarySource ModelYTLBSummary
        {
            get
            {
                return this.Tables["用途类别表"] as _YTLBSummarySource;
            }
            set
            {
                this.Tables.Remove("用途类别表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 其他项目表(不参与保存 最终结果)
        /// </summary>
        public _OtherProjectSource ModelOtherProject
        {
            get
            {
                return this.Tables["其他项目表"] as _OtherProjectSource;
            }
            set
            {
                this.Tables.Remove("其他项目表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 工程取费(不参与保存 最终结果)
        /// </summary>
        public _UnitFeeSource ModelUnitFee
        {
            get
            {
                return this.Tables["工程取费"] as _UnitFeeSource;
            }
            set
            {
                this.Tables.Remove("工程取费");
                this.Tables.Add(value);
            }
        }
        /// <summary>
        /// 变量表(不参与保存 最终结果)
        /// </summary>
        public _InfomationSource ModelInfomation
        {
            get
            {
                return this.Tables["基础表"] as _InfomationSource;
            }
            set
            {
                this.Tables.Remove("基础表");
                this.Tables.Add(value);
            }
        }

        /// <summary>
        /// 招标信息表
        /// </summary>
        public _BiddingInfoSource BiddingInfoSource
        {
            get
            {
                return this.Tables["招标信息表"] as _BiddingInfoSource;
            }
            set
            {
                this.Tables.Remove("招标信息表");
                this.Tables.Add(value);
            }
        }

        //
        /// <summary>
        /// 投标信息表
        /// </summary>
        public _TenderInfoSource TenderInfoSource
        {
            get
            {
                return this.Tables["投标信息表"] as _TenderInfoSource;
            }
            set
            {
                this.Tables.Remove("投标信息表");
                this.Tables.Add(value);
            }
        }
        #endregion

        public _StructSource()
        {
            this.DataSetName = "数据表";
        }

        protected _StructSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }


        /// <summary>
        /// 创建项目表结构(当构造一个单位工程 单项工程 项目的时候初始化 数据关系集)
        /// </summary>
        public void ProjBuilder()
        {
            //基础表
            this.Tables.Add(new _InfomationSource());
            //招标信息表
            this.Tables.Add(new _BiddingInfoSource());
            //投标信息表
            this.Tables.Add(new _TenderInfoSource());
            //项目结构表
            this.Tables.Add(new _ProjSource(true));
            //分部分项
            this.Tables.Add(new _SubSegmentsSource(true));
            //措施项目表
            this.Tables.Add(new _MeasuresSource(true));
            //其他项目表
            this.Tables.Add(new _OtherProjectSource(true));
            //项目汇总分析
            this.Tables.Add(new _MetaanalysisSource(true));
            //工料机
            this.Tables.Add(new _QuantitySource(true));
            //项目变量表
            this.Tables.Add(new _VariableSource("项目变量表"));
            //工料机汇总
            this.Tables.Add(new _QuantitySource("工料机汇总"));
            //项目事件处理
            InitProjEvent();

            //组成工料机（和工料机合并成一张表）
            //this.Tables.Add(new _QuantitySource("组成工料机"));
            //建立关系
            //this.BuilderRelations();
        }

        /// <summary>
        /// 创建单位工程表结构
        /// </summary>
        public void UnitjBuilder()
        {
            //基础表
            this.Tables.Add(new _InfomationSource());
            //项目结构表
            this.Tables.Add(new _ProjSource());
            //分部分项表
            this.Tables.Add(new _SubSegmentsSource());
            //措施项目表
            this.Tables.Add(new _MeasuresSource());
            //工料机
            this.Tables.Add(new _QuantitySource());
            //子目取费
            this.Tables.Add(new _SubheadingsFeeSource());
            //标准换算
            this.Tables.Add(new _StandardConversionSource());
            //用途类别
            this.Tables.Add(new _YTLBSummarySource());
            //变量表
            this.Tables.Add(new _VariableSource("临时变量表"));
            //变量表
            this.Tables.Add(new _VariableSource("变量表"));
            //项目变量表
            this.Tables.Add(new _VariableSource("项目变量表"));
            //安装增加费
            this.Tables.Add(new _IncreaseCostsSource());
            //其他项目表
            this.Tables.Add(new _OtherProjectSource());
            //汇总分析
            this.Tables.Add(new _MetaanalysisSource());
            //参数子目取费表
            this.Tables.Add(new _PSubheadingsFeeSource());
            //参数子目取费表
            this.Tables.Add(new _UnitFeeSource());

            InitEvent();
            //建立关系
            this.BuilderRelations();
        }

        /// <summary>
        /// 为数据源初始化事件
        /// </summary>
        private void InitProjEvent()
        {

            this.ModelProject.RowDeleting += new DataRowChangeEventHandler(ModelProject_RowDeleting);
            this.ModelProject.RowChanged += new DataRowChangeEventHandler(ModelProject_RowChanged);
        }

        void ModelProject_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            //删除单位工程/单项工程 的时候同步删除所有当先项目数据源中的所有数据（内存数据源中彻底删除）

        }

        private void DeleteProj(int p_Id, object Deep)
        {

        }


        /// <summary>
        /// 项目结构表发生变化后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModelProject_RowChanged(object sender, DataRowChangeEventArgs e)
        {

        }

        /// <summary>
        /// 为数据源初始化事件
        /// </summary>
        private void InitEvent()
        {
            this.ModelQuantity.RowDeleting += new DataRowChangeEventHandler(ModelQuantity_RowDeleting);
            this.ModelSubSegments.RowDeleting += new DataRowChangeEventHandler(ModelSubSegments_RowDeleting);
            this.ModelSubSegments.RowDeleted += new DataRowChangeEventHandler(ModelSubSegments_RowDeleted);
            this.ModelMeasures.RowDeleting += new DataRowChangeEventHandler(ModelMeasures_RowDeleting);
            //this.ModelQuantity.RowChanged += new DataRowChangeEventHandler(ModelQuantity_RowChanged);
            //this.ModelQuantity.ColumnChanged += new DataColumnChangeEventHandler(ModelQuantity_DataColumnChanged);
        }




        /// <summary>
        /// 创建表关系
        /// </summary>
        public void BuilderRelations()
        {
            //工料机
            this.Relations.Add("工料机-组成", this.ModelQuantity.Columns["ID"], this.ModelQuantity.Columns["PID"]);

            //项目信息表和分部分项表的关系建立
            //this.Relations.Add("项目-分部分项", this.ModelProject.PrimaryKey[0], this.ModelSubSegments.Columns["UnID"]);
            //
            //this.Relations.Add("项目-措施项目", this.ModelProject.PrimaryKey[0], this.ModelMeasures.Columns["UnID"]);
            /*if (this.ModelMetaanalysis != null)
            {
                this.Relations.Add("项目-汇总分析", this.ModelProject.PrimaryKey[0], this.ModelMetaanalysis.Columns["PID"]);
            }*/
        }

        /// <summary>
        /// 创建临时关系表
        /// </summary>
        /// <param name="table"></param>
        public void BuilderRelation(DataTable table, string RelName)
        {
            this.Tables.Add(table);
            //项目信息表和分部分项表的关系建立
            this.Relations.Add(RelName, this.ModelProject.PrimaryKey[0], table.Columns["UnID"]);

        }

        /// <summary>
        /// 删除临时关系表
        /// </summary>
        /// <param name="table"></param>
        /// <param name="RelName"></param>
        public void ReBuiderRelation(DataTable table, string RelName)
        {
            //项目信息表和分部分项表的关系建立
            this.Relations.Remove(RelName);
            this.Tables.Remove(table);
        }

        /// <summary>
        /// 删除临时关系表
        /// </summary>
        /// <param name="table"></param>
        /// <param name="RelName"></param>
        public void ReBuiderRelation()
        {
            //项目信息表和分部分项表的关系建立
            //this.Relations.Remove(RelName);
        }


        /// <summary>
        /// 重新计算的时候清空数据
        /// </summary>
        public void ReLoad(ERevealType p_ERevealType)
        {
            this.Relations.Clear();

            if (p_ERevealType == ERevealType.Default)
            {
                this.ModelMetaanalysis.Clear();
                this.ModelMetaanalysis.IsCompled = true;
                this.ModelSubSegments.Clear();
                this.ModelSubSegments.IsCompled = true;
                this.ModelMeasures.Clear();
                this.ModelMeasures.IsCompled = true;
            }
            if (p_ERevealType == ERevealType.措施项目)
            {
                this.ModelMeasures.Clear();
                this.ModelMeasures.IsCompled = true;
            }
            if (p_ERevealType == ERevealType.分部分项)
            {
                this.ModelMeasures.Clear();
                this.ModelSubSegments.IsCompled = true;
            }
            if (p_ERevealType == ERevealType.汇总分析)
            {
                this.ModelMeasures.Clear();
                this.ModelMetaanalysis.IsCompled = true;
            }
            this.BuilderRelations();

        }


        /// <summary>
        /// 当工料机删除时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModelQuantity_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            DataRow dr = e.Row;
            if (dr["IFKFJ"].Equals(true))
            {
                DataRow[] drs = this.ModelQuantity.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2} AND PID={3}", dr["UnID"], dr["SSLB"], dr["ZMID"], dr["ID"]));
                this.DeleteRows(this.ModelQuantity, drs);
            }
        }

        /// <summary>
        /// 当分部分项删除对的时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModelSubSegments_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            //1.获取分部分项的编号(或者措施项目)
            //2.获取单位工程编号
            //3.删除临时计算表
            //4.删除计算表
            //5.删除子目取费
            //6.删除安装增加费
            //7.删除标准换算
            object ZMID = e.Row["ID"];
            object UnID = e.Row["UnID"];
            object LB = e.Row["LB"];
            object SSLB = e.Row["SSLB"];
            object EnId = e.Row["EnID"];
            //object QdId = e.Row["QDID"];

            DataRow[] rows = null;
            //公共
            rows = this.ModelVariable.Select(string.Format(" type ={0} and ID = {1}", SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
            this.DeleteRows(this.ModelVariable, rows);
            rows = this.ModelResultVariable.Select(string.Format(" type ={0} and ID = {1}", SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
            this.DeleteRows(this.ModelResultVariable, rows);
            switch (LB.ToString())
            {
                case "分部-专业":
                    rows = this.ModelSubSegments.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
                case "分部-章":
                    rows = this.ModelSubSegments.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
                case "分部-节":
                    rows = this.ModelSubSegments.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
                case "清单":
                    //删除所有子目
                    rows = this.ModelSubSegments.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
                case "子目":
                case "子目-降效":
                case "子目-增加费":
                    rows = this.ModelSubheadingsFee.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    rows = this.ModelStandardConversion.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    rows = this.ModelQuantity.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
            }
        }

        void ModelSubSegments_RowDeleted(object sender, DataRowChangeEventArgs e)
        {

        }
        /// <summary>
        /// 措施项目删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModelMeasures_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            object ZMID = e.Row["ID"];
            object UnID = e.Row["UnID"];
            object LB = e.Row["LB"];
            object SSLB = e.Row["SSLB"];
            object EnId = e.Row["EnID"];
            //object QdId = e.Row["QDID"];

            DataRow[] rows = null;
            //公共
            rows = this.ModelVariable.Select(string.Format(" type ={0} and ID = {1}", SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
            this.DeleteRows(this.ModelVariable, rows);
            rows = this.ModelResultVariable.Select(string.Format(" type ={0} and ID = {1}", SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
            this.DeleteRows(this.ModelResultVariable, rows);
            switch (LB.ToString())
            {
                case "":
                    if (!e.Row["PID"].Equals(0))
                    {
                        rows = this.ModelMeasures.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                        this.DeleteRows(rows);
                    }
                    break;
                case "清单":
                    //删除所有子目
                    rows = this.ModelMeasures.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
                case "子目":
                case "子目-降效":
                case "子目-增加费":
                    rows = this.ModelSubheadingsFee.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    rows = this.ModelStandardConversion.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    rows = this.ModelQuantity.Select(string.Format("UnId = {0} and SSLB ={1} and ZMID = {2}", UnID, SSLB, ZMID), string.Empty, DataViewRowState.CurrentRows);
                    this.DeleteRows(rows);
                    break;
            }

        }
        private void DeleteRows(DataTable p_Table, DataRow[] p_Rows)
        {
            for (int i = 0; i < p_Rows.Length; i++)
            {
                p_Table.Rows.Remove(p_Rows[i]);
            }
        }

        private void DeleteRows(DataRow[] p_Rows)
        {
            for (int i = 0; i < p_Rows.Length; i++)
            {
                if (p_Rows[i].RowState == DataRowState.Added)
                    p_Rows[i].Delete();
            }
        }

        /// <summary>
        /// 删除指定单位工程中的数据(当前业务计算使用 删除不包含ID是-1的数据)
        /// </summary>
        /// <param name="info"></param>
        public void ProjClearCalculate(_UnitProject info)
        {
            //工料机
            this.ModelQuantity.DeleteData(info);
            this.ModelSubSegments.DeleteData(info);
            this.ModelMeasures.DeleteData(info);
            this.ModelOtherProject.DeleteData(info);
            //this.ModelProjVariable.DeleteData(info);
        }

        /// <summary>
        /// 删除指定单位工程中的数据
        /// </summary>
        /// <param name="info"></param>
        public void ProjClear(object p_UnID)
        {
            //工料机
            //删除工料机
            if (this.ModelQuantity != null)
                this.ModelQuantity.DeleteData(p_UnID);
            //删除分部分项数据
            if (this.ModelSubSegments != null)
                this.ModelSubSegments.DeleteData(p_UnID);
            //删除措施项目数据
            if (this.ModelMeasures != null)
                this.ModelMeasures.DeleteData(p_UnID);
            //删除其他项目数据
            if (this.ModelOtherProject != null)
                this.ModelOtherProject.DeleteData(p_UnID);
            //删除安装增加费
            if (this.ModelPSubheadingsFee != null)
                this.ModelPSubheadingsFee.DeleteData(p_UnID);
            //删除标准换算
            if (this.ModelStandardConversion != null)
                this.ModelStandardConversion.DeleteData(p_UnID);
            //删除单位工程取费
            if (this.ModelUnitFee != null)
                this.ModelUnitFee.DeleteData(p_UnID);
            //删除安装增加费
            if (this.ModelIncreaseCosts != null)
                this.ModelIncreaseCosts.DeleteData(p_UnID);
            //删除用途类别
            if (this.ModelYTLBSummary != null)
                this.ModelYTLBSummary.DeleteData(p_UnID);
            //删除参数变量
            if (this.ModelVariable != null)
                this.ModelVariable.DeleteData(p_UnID);
            //删除临时变量
            if (this.ModelResultVariable != null)
                this.ModelResultVariable.DeleteData(p_UnID);
            if (this.ModelProjVariable != null)
                this.ModelProjVariable.DeleteData(p_UnID);
        }

        /// <summary>
        /// 项目清空
        /// </summary>
        public void ProjClear()
        {
            this.ModelSubSegments.Clear();
            this.ModelMeasures.Clear();
            this.ModelOtherProject.Clear();
            this.ModelQuantity.Clear();
            this.ModelProjVariable.Clear();
        }

        /// <summary>
        /// 项目清空
        /// </summary>
        public void UnitClear()
        {
            this.ModelProject.Clear();
            this.ModelSubSegments.Clear();
            this.ModelMeasures.Clear();
            this.ModelOtherProject.Clear();
            //this.ModelQuantity.Clear();
            this.ModelProjVariable.Clear();
            this.ModelMetaanalysis.Clear();
            this.ModelSubheadingsFee.Clear();
            this.ModelYTLBSummary.Clear();
            this.ModelUnitFee.Clear();
            this.ModelIncreaseCosts.Clear();
            this.ModelStandardConversion.Clear();
        }


        /// <summary>
        /// 为指定单位工程重新设置关系数据(导入单位工程的时候使用)
        /// </summary>
        /// <param name="p_ObjectKey"></param>
        /// <param name="p_Info"></param>
        public virtual void SetNewFiled(ref int p_ObjectKey, _UnitProject p_Info)
        {
            foreach (_ObjectSource table in p_Info.StructSource.Tables)
            {
                if (!table.TableName.Equals("项目结构表"))
                {
                    try
                    {
                        table.SetNewFiled(ref p_ObjectKey, p_Info);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            //同步定单位工程的关系数据
            //分部分项处理
            /*this.ModelSubSegments.SetNewFiled(ref p_ObjectKey, p_Info);
            //措施项目
            this.ModelMeasures.SetNewFiled(ref p_ObjectKey, p_Info);
            //其他项目
            this.ModelOtherProject.SetNewFiled(ref p_ObjectKey, p_Info);
            //工料机
            this.ModelQuantity.SetNewFiled(ref p_ObjectKey, p_Info);
            //单位工程变量
            this.ModelProjVariable.SetNewFiled(p_Info);*/
            //
        }

        /// <summary>
        /// 合并项目结构数据
        /// </summary>
        public void MergeData()
        {
            //处理如果已经删除了 单项工程 单位工程 无法同步的问题 
            this.ModelSubSegments.ClearRoot();
            this.ModelMeasures.ClearRoot();
            this.ModelOtherProject.ClearRoot();

            DataView table = this.ModelProject.DefaultView;
            if (table != null)
            {
                DataRow NewRow = null;
                foreach (DataRowView row in table)
                {

                    //单位工程不处理
                    if (!row["DEEP"].Equals(2))
                    {
                        //分部分项
                        //DataRow sr = this.ModelSubSegments.Rows.Find(new object[] { -1, row["ID"] });
                        //if (sr == null)
                        {
                            NewRow = this.ModelSubSegments.NewRow();
                            NewRow.BeginEdit();
                            NewRow["ID"] = -1;
                            NewRow["Key"] = row["Key"];
                            NewRow["PKey"] = row["PKey"];
                            NewRow["UnID"] = row["ID"];
                            NewRow["EnID"] = row["ID"];
                            NewRow.EndEdit();
                            this.ModelSubSegments.Rows.Add(NewRow);
                        }
                        //措施项目
                        //DataRow sm = this.ModelMeasures.Rows.Find(new object[] { -1, row["ID"] });
                        //if (sm == null)
                        {
                            NewRow = this.ModelMeasures.NewRow();
                            NewRow.BeginEdit();
                            NewRow["ID"] = -1;
                            NewRow["Key"] = row["Key"];
                            NewRow["PKey"] = row["PKey"];
                            NewRow["UnID"] = row["ID"];
                            NewRow["EnID"] = row["ID"];
                            NewRow.EndEdit();
                            this.ModelMeasures.Add(NewRow);
                        }

                        //其他项目
                        //DataRow om = this.ModelOtherProject.Rows.Find(new object[] { -1, row["id"] });
                        //if (om == null)
                        {
                            NewRow = this.ModelOtherProject.NewRow();
                            NewRow.BeginEdit();
                            NewRow["Number"] = row["Name"];
                            NewRow["Key"] = row["Key"];
                            NewRow["PKey"] = row["PKey"];
                            NewRow["Name"] = row["Name"];
                            NewRow["id"] = -1;
                            NewRow["UnID"] = row["ID"];
                            NewRow["EnID"] = row["ID"];
                            NewRow.EndEdit();
                            this.ModelOtherProject.Add(NewRow);
                        }
                    }
                    else
                    {
                        //DataRow om = this.ModelOtherProject.Rows.Find(new object[] { -1, row["id"] });
                        //if (om == null)
                        //{
                        //    NewRow = this.ModelOtherProject.NewRow();
                        //    NewRow.BeginEdit();
                        //    NewRow["Number"] = row["Name"];
                        //    NewRow["Key"] = row["Key"];
                        //    NewRow["PKey"] = row["PKey"];
                        //    NewRow["Name"] = row["Name"];
                        //    NewRow["id"] = -1;
                        //    NewRow["UnID"] = row["ID"];
                        //    NewRow["EnID"] = row["PID"];
                        //    NewRow.EndEdit();
                        //    this.ModelOtherProject.Add(NewRow);
                        //}
                    }

                }
            }
        }

        /// <summary>
        /// 项目中删除单位工程(项目使用)
        /// </summary>
        /// <param name="p_Info">要删除的单位工程</param>
        public void DeleteUnit(_COBJECTS p_Info)
        {
            //删除项目解表
            if (ModelProject != null)
                this.ModelProject.Delete(p_Info);
            //清空数据对象
            p_Info.StructSource.UnitClear();
            if (ModelSubSegments != null)
                this.ModelSubSegments.DeleteData(p_Info);
            if (ModelMeasures != null)
                this.ModelMeasures.DeleteData(p_Info);
            if (ModelOtherProject != null)
                this.ModelOtherProject.DeleteData(p_Info);
            if (ModelProjVariable != null)
                this.ModelProjVariable.DeleteData(p_Info);
            if (ModelQuantity != null)
                this.ModelQuantity.DeleteData(p_Info);
            if (ModelQuantity != null)
                this.ModelQuantity.DeleteData(p_Info);
            if (ModelMetaanalysis != null)
                this.ModelMetaanalysis.DeleteData(p_Info);
            if (ModelPSubheadingsFee != null)
                this.ModelPSubheadingsFee.DeleteData(p_Info);
            if (ModelProjVariable != null)
                this.ModelProjVariable.DeleteRows("ID", p_Info.ID + "");

        }

        /// <summary>
        /// 项目中删除单位工程(项目使用)
        /// </summary>
        /// <param name="p_Info">要删除的单位工程</param>
        public void DeleteEn(int p_Id)
        {
            //this.ModelProject.DeleteEn(p_Id);

            this.ModelSubSegments.DeleteEn(p_Id);
            this.ModelMeasures.DeleteEn(p_Id);
            this.ModelOtherProject.DeleteEn(p_Id);
            this.ModelProjVariable.DeleteEn(p_Id);
            this.ModelQuantity.DeleteData(p_Id);
            if (this.ModelResultVariable != null)
            {
                this.ModelResultVariable.DeleteData(p_Id);
            }
            /*this.ModelQuantity.DeleteData(p_Info);
            this.ModelProjVariable.DeleteData(p_Info);
            this.ModelMetaanalysis.DeleteData(p_Info);*/
        }



        /// <summary>
        /// 项目调用 统计到单项工程-2 和 项目-3
        /// </summary>
        public void Statistics()
        {
            DataView table = this.ModelProject.DefaultView;
            _VariableSource t1 = null;
            foreach (DataRowView row in table)
            {
                //单项工程统计
                if (row["DEEP"].Equals(1))
                {
                    int EnID = ToolKit.ParseInt(row["ID"]);
                    t1 = _VariableSource.CreateInstance(EnID, -2);

                    foreach (DataRow dr in t1.Rows)
                    {
                        dr["Value"] = this.ModelProjVariable.Compute("sum(Value)", string.Format(" EnID = '{0}' and Key = '{1}' and Type = -1", EnID, dr["Key"]));
                        dr["EnID"] = EnID;
                        dr["ID"] = EnID;
                    }
                    this.ModelProjVariable.MergeData(t1, false);
                }
            }
            t1 = _VariableSource.CreateInstance(-1, -3);
            foreach (DataRow dr in t1.Rows)
            {
                dr["Value"] = this.ModelProjVariable.Compute("sum(Value)", string.Format(" Key = '{0}' and Type = -2", dr["Key"]));
                dr["EnID"] = -1;
                dr["ID"] = 0;
            }
            this.ModelProjVariable.MergeData(t1, false);


        }

        #region ISerializable 成员



        #endregion
    }
}
