/*
 项目数据访问类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GOLDSOFT.QDJJ.DATA.Properties;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data.OleDb;
using ZiboSoft.Commons.Common;
using System.Collections;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace GOLDSOFT.QDJJ.DATA
{

    public partial class _ProjDataBase : _ObjectDataBase, IDisposable
    {

        private Hashtable mTable = null;

        public _ProjDataBase(string conString, Hashtable p_Table)
            : base(conString)
        {
            mTable = p_Table;
        }

        /// <summary>
        /// 为单位工程添加单项工程
        /// </summary>
        /// <param name="p_info">单项工程对象</param>
        public void Add(_COBJECTS p_Info)
        {
            //默认添加当前项目基础数据到数据表
            string sql = "insert into 项目结构表 (Name,QDGZ,DEGZ,CODE,PGCDD,PJFCX,PNSDD,DEEP,NODENAME,PID,[Key],PKey) values (@Name,@QDGZ,@DEGZ,@CODE,@PGCDD,@PJFCX,@PNSDD,1,@Name,@PID,@Key,@PKey);";
            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@Name", OleDbType.VarChar,100),
                new OleDbParameter("@QDGZ", OleDbType.VarChar,4),
                new OleDbParameter("@DEGZ", OleDbType.VarChar,4),
                new OleDbParameter("@CODE", OleDbType.VarChar,50),
                new OleDbParameter("@PGCDD", OleDbType.VarChar,50),
                new OleDbParameter("@PJFCX", OleDbType.VarChar,50),
                new OleDbParameter("@PNSDD", OleDbType.VarChar,50),
                new OleDbParameter("@PID", OleDbType.BigInt,50),
                new OleDbParameter("@Key", OleDbType.BigInt,50),
                new OleDbParameter("@PKey", OleDbType.BigInt,50)

            };

            param[0].Value = p_Info.Name;
            param[1].Value = p_Info.QDGZ;
            param[2].Value = p_Info.DEGZ;
            param[3].Value = p_Info.CODE;
            param[4].Value = p_Info.PGCDD;
            param[5].Value = p_Info.PJFCX;
            param[6].Value = p_Info.PNSDD;
            param[7].Value = this.Current.ID;
            param[8].Value = this.Current.Key;
            param[9].Value = this.Current.PKey;

            using (IDbTransaction p_tran = this.BeginTran())
            {
                this.ExecuteSql(sql, param);
                sql = "select @@Identity";
                object obj = this.ExecuteScalar(sql);
                this.CommitTran();
                p_Info.ID = ToolKit.ParseInt(obj);
            }
        }

        /// <summary>
        /// 为指定的项目添加单位工程
        /// </summary>
        /// <param name="p_parent">所属单项工程</param>
        /// <param name="p_info">所属单位工程</param>
        public void AddChild(_COBJECTS p_parent, _COBJECTS p_Info)
        {
            //默认添加当前项目基础数据到数据表
            string sql = "insert into 项目结构表 (Name,QDGZ,DEGZ,CODE,PGCDD,PJFCX,PNSDD,DEEP,NODENAME,PID) values (@Name,@QDGZ,@DEGZ,@CODE,@PGCDD,@PJFCX,@PNSDD,2,@Name,@PID)";
            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@Name", OleDbType.VarChar,100),
                new OleDbParameter("@QDGZ", OleDbType.VarChar,4),
                new OleDbParameter("@DEGZ", OleDbType.VarChar,4),
                new OleDbParameter("@CODE", OleDbType.VarChar,50),
                new OleDbParameter("@PGCDD", OleDbType.VarChar,50),
                new OleDbParameter("@PJFCX", OleDbType.VarChar,50),
                new OleDbParameter("@PNSDD", OleDbType.VarChar,50),
                new OleDbParameter("@PID", OleDbType.BigInt,50)
            };

            param[0].Value = p_Info.Name;
            param[1].Value = p_Info.QDGZ;
            param[2].Value = p_Info.DEGZ;
            param[3].Value = p_Info.CODE;
            param[4].Value = p_Info.PGCDD;
            param[5].Value = p_Info.PJFCX;
            param[6].Value = p_Info.PNSDD;
            param[7].Value = p_parent.ID;
            using (IDbTransaction p_tran = this.Conn.BeginTransaction())
            {
                this.ExecuteSql(sql, param);
                sql = "select @@Identity from 项目结构表";
                object obj = this.ExecuteScalar(sql);
                this.CommitTran();
                p_Info.ID = ToolKit.ParseInt(obj);
            }
        }

        /// <summary>
        /// （仅在第一次创建项目时候添加此方法）已经创建了数据文件此方法用于创建数据的的时候初始化数据库数据
        /// </summary>
        /// <param name="?"></param>
        public override void Create()
        {
            this.OpenConnection();
            //this.Conn.Open();
            //此对象肯定是项目
            _COBJECTS p_Info = this.Current; ;
            //默认添加当前项目基础数据到数据表
            string sql = "insert into 项目结构表 (Name,QDGZ,DEGZ,CODE,PGCDD,PJFCX,PNSDD,DEEP,NODENAME,PID,JMSH,JQH,ImageIndex,State,[Key],PKey) values (@Name,@QDGZ,@DEGZ,@CODE,@PGCDD,@PJFCX,@PNSDD,@DEEP,@NODENAME,@PID,@JMSH,@JQH,@ImageIndex,@State,@Key,@PKey)";

            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@Name", OleDbType.VarChar,100),
                new OleDbParameter("@QDGZ", OleDbType.VarChar,4),
                new OleDbParameter("@DEGZ", OleDbType.VarChar,4),
                new OleDbParameter("@CODE", OleDbType.VarChar,50),
                new OleDbParameter("@PGCDD", OleDbType.VarChar,50),
                new OleDbParameter("@PJFCX", OleDbType.VarChar,50),
                new OleDbParameter("@PNSDD", OleDbType.VarChar,50),
                new OleDbParameter("@DEEP", OleDbType.Integer),
                new OleDbParameter("@NODENAME", OleDbType.VarChar,100),
                new OleDbParameter("@PID", OleDbType.Integer),
                new OleDbParameter("@JMSH", OleDbType.VarChar),
                new OleDbParameter("@JQH", OleDbType.VarChar),
                 new OleDbParameter("@ImageIndex", OleDbType.Integer),
                new OleDbParameter("@State", OleDbType.VarChar),
                new OleDbParameter("@Key", OleDbType.Integer),
                new OleDbParameter("@PKey", OleDbType.Integer)
            };

            param[0].Value = p_Info.Name;
            param[1].Value = p_Info.QDGZ;
            param[2].Value = p_Info.DEGZ;
            param[3].Value = p_Info.CODE;
            param[4].Value = p_Info.PGCDD;
            param[5].Value = p_Info.PJFCX;
            param[6].Value = p_Info.PNSDD;
            param[7].Value = 0;
            param[8].Value = p_Info.Name;
            param[9].Value = p_Info.PID;
            param[10].Value = p_Info.JMSH;
            param[11].Value = p_Info.JQH;
            param[12].Value = p_Info.ImageIndex;
            param[13].Value = p_Info.State;
            param[14].Value = p_Info.Key;
            param[15].Value = p_Info.PKey;

            using (IDbTransaction tran = this.BeginTran())
            {
                this.ExecuteSql(sql, param);
                //创建基础表
                this.Current.StructSource.ModelInfomation.Set("ObjectKey", this.Current.ObjectKey);
                this.UpDate_ProjInfomation(tran);
                this.Current.StructSource.ModelInfomation.AcceptChanges();
                sql = "select @@Identity from 项目结构表";
                object obj = this.ExecuteScalar(sql);
                //初始化对象结构数据
                //填充数据集
                sql = "select 项目结构表.* from 项目结构表";
                this.FillDataSet(sql, p_Info.StructSource.ModelProject);
                this.Current.ID = ToolKit.ParseInt(obj);

                this.UpDate_BiddingInformation(tran);
                this.UpDate_TenderInformation(tran);
                this.Current.StructSource.BiddingInfoSource.AcceptChanges();
                this.Current.StructSource.TenderInfoSource.AcceptChanges();
                this.CommitTran();
            }
            this.Conn.Close();
            this.CloseConnection();
        }

        public void Save(_UnitProject unit, IDbTransaction tran)
        {

            //更新分部分项
            UpDate_SubData(unit, tran);
            //措施项目表
            UpDate_MeasuresData(unit, tran);
            //其他项目
            UpDate_OtherProject(unit, tran);
            //更新子目取费
            UpDate_SubheadingsFee(unit, tran);
            //更新工料机表
            UpDate_QuantityData(unit, tran);
            //安装增加费
            UpDate_IncreaseCosts(unit, tran);
            //标准换算
            UpDate_StandardConversionSource(unit, tran);
            //用途类别
            UpDate_YTLBSummary(unit, tran);
            //保存汇总分析
            UpDate_Metaanalysis(unit, tran);
            //更新参数子目取费
            UpDate_PSubheadingsFee(unit, tran);
            //更新工程取费
            //UpDate_UnitFree(unit, tran);
            //保存单位工程变量表
            UpDate_Variable(unit, tran);
        }

        /// <summary>
        /// 保存电子标书
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tran"></param>
        public void SaveDZBS(_UnitProject unit, IDbTransaction tran)
        {

            //更新分部分项
            UpDate_SubData_DZBS(unit, tran);
            //措施项目表
            UpDate_MeasuresData_DZBS(unit, tran);
            //其他项目
            UpDate_OtherProject_DZBS(unit, tran);
            //更新子目取费
            UpDate_SubheadingsFee(unit, tran);
            //更新工料机表
            UpDate_QuantityData(unit, tran);
            //安装增加费
            UpDate_IncreaseCosts(unit, tran);
            //标准换算
            UpDate_StandardConversionSource(unit, tran);
            //用途类别
            UpDate_YTLBSummary_DZBS(unit, tran);
            //保存汇总分析
            UpDate_Metaanalysis(unit, tran);
            //更新参数子目取费
            UpDate_PSubheadingsFee(unit, tran);
            //更新工程取费
            //UpDate_UnitFree(unit, tran);
            //保存单位工程变量表
            UpDate_Variable(unit, tran);
        }

        /// <summary>
        /// 保存当前的项目操作(常规保存)
        /// </summary>
        /// <param name="p_Info"></param>
        public override void Save()
        {
            //1.项目数据保存
            //2.活动的单位工程保存
            //开启事务
            //this.IDataBase.BeginTrans();
            //更新项目结构数据
            //保存前打开链接 
            this.OpenConnection();
            using (IDbTransaction tran = this.Conn.BeginTransaction())
            {
                //保存基础信息
                this.UpDate_ProjInfomation(tran);
                //保存招标信息
                this.UpDate_BiddingInformation(tran);
                //保存投标信息
                this.UpDate_TenderInformation(tran);
                this.Save_Proj(tran);
                //保存项目变量表
                //this.Save_ProjVariable(tran);
                foreach (_UnitProject unit in this.mTable.Values)
                {
                    this.Save(unit, tran);
                    unit.StructSource.AcceptChanges();
                    //unit.DataTemp.YSZMQFDataTemp.IsChange
                    //     = unit.DataTemp.YSGCQFDataTemp.IsChange
                    //     = unit.DataTemp.ODataTemp.IsChange
                    //     = unit.DataTemp.MSDataTemp.IsChange
                    //     = unit.DataTemp.ZMQFDataTemp.IsChange
                    //     = unit.DataTemp.MSDataTemp.IsChange
                    //     = unit.DataTemp.MDataTemp.IsChange
                    //     = false;
                }
                //保存项目变量表
                this.Save_ProjVariable(tran);
                //提交
                tran.Commit();
                //提交当前的更改
                this.Current.StructSource.AcceptChanges();


            }
            this.CloseConnection();
        }

        /// <summary>
        /// 保存招投标信息(所属项目)
        /// </summary>
        /// <param name="tran"></param>
        public void UpDate_BiddingInformation(IDbTransaction tran)
        {
            //招标信息
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 招标信息表(");
                strSql.Append("[JSDWDBR],[ZBDLR],[ZBDLDBR],[GCLX],[ZBFW],[ZBMJ],[ZBGQ],[BZDW],[SJDW],[DBLX],[PlaitNo],[ReviewName],[PlaitName],[PlaitDate],[ReviewDate],[JSDW],[BZDWDBR]");
                strSql.Append(") values (");
                strSql.Append("@JSDWDBR,@ZBDLR,@ZBDLDBR,@GCLX,@ZBFW,@ZBMJ,@ZBGQ,@BZDW,@SJDW,@DBLX,@PlaitNo,@ReviewName,@PlaitName,@PlaitDate,@ReviewDate,@JSDW,@BZDWDBR");
                strSql.Append(")");
                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_BiddingInfo) as OleDbCommand;
                da.InsertCommand.Transaction = tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 招标信息表 set ");
                strSql.Append(" [JSDWDBR] = @JSDWDBR , ");
                strSql.Append(" [ZBDLR] = @ZBDLR , ");
                strSql.Append(" [ZBDLDBR] = @ZBDLDBR , ");
                strSql.Append(" [GCLX] = @GCLX , ");
                strSql.Append(" [ZBFW] = @ZBFW , ");
                strSql.Append(" [ZBMJ] = @ZBMJ , ");
                strSql.Append(" [ZBGQ] = @ZBGQ , ");
                strSql.Append(" [BZDW] = @BZDW , ");
                strSql.Append(" [SJDW] = @SJDW , ");
                strSql.Append(" [DBLX] = @DBLX , ");
                strSql.Append(" [PlaitNo] = @PlaitNo , ");
                strSql.Append(" [ReviewName] = @ReviewName , ");
                strSql.Append(" [PlaitName] = @PlaitName , ");
                strSql.Append(" [PlaitDate] = @PlaitDate , ");
                strSql.Append(" [ReviewDate] = @ReviewDate,  ");
                strSql.Append(" [JSDW] = @JSDW , ");
                strSql.Append(" [BZDWDBR] = @BZDWDBR  ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_BiddingInfo) as OleDbCommand;
                da.UpdateCommand.Transaction = tran as OleDbTransaction;
                this.Current.StructSource.BiddingInfoSource.Rows[0].EndEdit();
                DataTable table = this.Current.StructSource.BiddingInfoSource.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.Current.StructSource.ModelInfomation.AcceptChanges();
            }
            //投标信息
        }

        /// <summary>
        /// 保存招投标信息(所属项目)
        /// </summary>
        /// <param name="tran"></param>
        public void UpDate_TenderInformation(IDbTransaction tran)
        {
            //招标信息
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 投标信息表(");
                strSql.Append("[TBDWDBR],[TBGQ],[ZLCN],[BBZJ],[DBLX],[JZS],[JZSH],[PlaitNo],[ReviewName],[PlaitName],[PlaitDate],[ReviewDate],[TBDW]");
                strSql.Append(") values (");
                strSql.Append("@TBDWDBR,@TBGQ,@ZLCN,@BBZJ,@DBLX,@JZS,@JZSH,@PlaitNo,@ReviewName,@PlaitName,@PlaitDate,@ReviewDate,@TBDW");
                strSql.Append(")");
                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_TenderInfo) as OleDbCommand;
                da.InsertCommand.Transaction = tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 投标信息表 set ");
                strSql.Append(" [TBDWDBR] = @TBDWDBR , ");
                strSql.Append(" [TBGQ] = @TBGQ , ");
                strSql.Append(" [ZLCN] = @ZLCN , ");
                strSql.Append(" [BBZJ] = @BBZJ , ");
                strSql.Append(" [DBLX] = @DBLX , ");
                strSql.Append(" [JZS] = @JZS , ");
                strSql.Append(" [JZSH] = @JZSH , ");
                strSql.Append(" [PlaitNo] = @PlaitNo , ");
                strSql.Append(" [ReviewName] = @ReviewName , ");
                strSql.Append(" [PlaitName] = @PlaitName , ");
                strSql.Append(" [PlaitDate] = @PlaitDate , ");
                strSql.Append(" [ReviewDate] = @ReviewDate,  ");
                strSql.Append(" [TBDW] = @TBDW ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_TenderInfo) as OleDbCommand;
                da.UpdateCommand.Transaction = tran as OleDbTransaction;
                this.Current.StructSource.TenderInfoSource.Rows[0].EndEdit();
                DataTable table = this.Current.StructSource.TenderInfoSource.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.Current.StructSource.ModelInfomation.AcceptChanges();
            }
            //投标信息
        }

        /// <summary>
        /// 保存当前的项目操作(另存为项目文件)
        /// </summary>
        /// <param name="p_Info"></param>
        public override void SaveAs()
        {
            //1.项目数据保存
            //2.活动的单位工程保存
            //开启事务
            //this.IDataBase.BeginTrans();
            //更新项目结构数据
            //保存前打开链接 
            this.OpenConnection();
            using (IDbTransaction tran = this.Conn.BeginTransaction())
            {
                this.UpDate_ProjInfomation(tran);
                //保存招标信息
                this.UpDate_BiddingInformation(tran);
                //保存投标信息
                this.UpDate_TenderInformation(tran);
                this.Save_Proj(tran);
                foreach (_UnitProject unit in this.mTable.Values)
                {
                    this.Save(unit, tran);
                    unit.DataTemp.YSZMQFDataTemp.IsChange = false;
                }
                //保存项目变量表
                this.Save_ProjVariable(tran);
                //提交
                tran.Commit();
            }
            this.CloseConnection();
        }

        /// <summary>
        /// 另存为电子标书
        /// </summary>
        public override void SaveAsDZBS()
        {
            //1.项目数据保存
            //2.活动的单位工程保存
            //开启事务
            //this.IDataBase.BeginTrans();
            //更新项目结构数据
            //保存前打开链接 
            this.OpenConnection();
            using (IDbTransaction tran = this.Conn.BeginTransaction())
            {

                this.UpDate_ProjInfomation(tran);
                //保存招标信息
                this.UpDate_BiddingInformation(tran);
                //保存投标信息
                this.UpDate_TenderInformation(tran);
                this.Save_Proj(tran);
                foreach (_UnitProject unit in this.mTable.Values)
                {
                    this.SaveDZBS(unit, tran);


                    unit.DataTemp.YSZMQFDataTemp.IsChange = false;
                }
                //保存项目变量表
                this.Save_ProjVariable(tran);
                //删除所有子目数据(以及关联数据)
                this.Delete_Proj_DZBS(tran);
                //提交
                tran.Commit();
            }
            this.CloseConnection();
        }


        /// <summary>
        /// 另存为电子标书
        /// </summary>
        public override void OutAsDZBS()
        {
            //1.项目数据保存
            //2.活动的单位工程保存
            //开启事务
            //this.IDataBase.BeginTrans();
            //更新项目结构数据
            //保存前打开链接 
            this.OpenConnection();
            using (IDbTransaction tran = this.Conn.BeginTransaction())
            {

                this.UpDate_ProjInfomation(tran);
                //保存招标信息
                this.UpDate_BiddingInformation(tran);
                //保存投标信息
                this.UpDate_TenderInformation(tran);
                this.Save_Proj(tran);
                foreach (_UnitProject unit in this.mTable.Values)
                {
                    this.SaveDZBS(unit, tran);

                    //unit.StructSource.AcceptChanges();
                    //unit.DataTemp.YSZMQFDataTemp.IsChange
                    //= unit.DataTemp.YSGCQFDataTemp.IsChange
                    //= unit.DataTemp.ODataTemp.IsChange
                    //= unit.DataTemp.MSDataTemp.IsChange
                    //= unit.DataTemp.ZMQFDataTemp.IsChange
                    //= unit.DataTemp.MSDataTemp.IsChange
                    //= unit.DataTemp.MDataTemp.IsChange
                    // = false;
                }
                //保存项目变量表
                this.Save_ProjVariable(tran);
                //删除所有子目数据(以及关联数据)
                this.Delete_Proj_OutDZBS(tran);
                //提交
                tran.Commit();
            }
            this.CloseConnection();
        }

        /// <summary>
        /// 保存为电子标书的时候调用
        /// </summary>
        /// <param name="p_tran"></param>
        private void Delete_Proj_DZBS(IDbTransaction p_tran)
        {


            //分部分项表 工料机表 安装增加费 子目取费表 标准换算表 用途类别表 参数子目取费表
            string sql = "delete from 分部分项表 where LB in ('子目','子目-降效','子目-增加费')";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 工料机表";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 安装增加费";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 子目取费表";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 标准换算表";
            this.ExecuteSql(sql, p_tran);
            //sql = "delete from 用途类别表";
            //this.ExecuteSql(sql, p_tran);
        }

        /// <summary>
        /// 保存为电子标书的时候调用
        /// </summary>
        /// <param name="p_tran"></param>
        private void Delete_Proj_OutDZBS(IDbTransaction p_tran)
        {


            //分部分项表 工料机表 安装增加费 子目取费表 标准换算表 用途类别表 参数子目取费表
            string sql = "delete from 分部分项表 where LB in ('子目','子目-降效','子目-增加费')";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 措施项目表 where LB in ('子目','子目-降效','子目-增加费')";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 工料机表";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 安装增加费";
            this.ExecuteSql(sql, p_tran);
            sql = "delete from 子目取费表";
            this.ExecuteSql(sql, p_tran);

            sql = "delete from 参数子目取费表";
            this.ExecuteSql(sql, p_tran);

            sql = "delete from 标准换算表";
            this.ExecuteSql(sql, p_tran);
            //清空JZBX价格有关数据
            sql = "update 项目结构表 set JMSH='',JQH='' where 1=1";
            this.ExecuteSql(sql, p_tran);
            sql = "update 变量表 set [Value] = 0 where 1=1";
            this.ExecuteSql(sql, p_tran);
            sql = "update 分部分项表 set HL=0,ZJTJ=0,ZHDJ=0,ZHHJ=0,ZJFDJ=0,RGFDJ=0,CLFDJ=0,JXFDJ=0,ZCFDJ=0,SBFDJ=0,GLFDJ=0,LRDJ=0,FXDJ=0,GFDJ=0,SJDJ=0,CJDJ=0,JCDJ=0,XHL=0,ZJFHJ=0,RGFHJ=0,CLFHJ=0,JXFHJ=0,ZCFHJ=0,SBFHJ=0,GLFHJ=0,LRHJ=0,FXHJ=0,GFHJ=0,SJHJ=0,JCHJ=0,CJHJ=0,ZGJE=0,JGJE=0,FBJE=0,FL=0,PBZD=0,YGJE=0,RGFJC=0,CLFJC=0,JXFJC=0 WHERE 1=1";
            this.ExecuteSql(sql, p_tran);
            //sql = "update 参数子目取费表 set FL=0 where 1=1";
            //this.ExecuteSql(sql, p_tran);
            sql = "update 措施项目表 set HL=0,ZJTJ=0,ZHDJ=0,ZHHJ=0,ZJFDJ=0,RGFDJ=0,CLFDJ=0,JXFDJ=0,ZCFDJ=0,SBFDJ=0,GLFDJ=0,LRDJ=0,FXDJ=0,GFDJ=0,SJDJ=0,CJDJ=0,JCDJ=0,XHL=0,ZJFHJ=0,RGFHJ=0,CLFHJ=0,JXFHJ=0,ZCFHJ=0,SBFHJ=0,GLFHJ=0,LRHJ=0,FXHJ=0,GFHJ=0,SJHJ=0,JCHJ=0,CJHJ=0,ZGJE=0,JGJE=0,FBJE=0,PBZD=0,YGJE=0,RGFJC=0,CLFJC=0,JXFJC=0 WHERE 1=1";
            this.ExecuteSql(sql, p_tran);
            sql = "update 工程取费 set GLFFL=0,LRFL=0,FXBDFL=0 WHERE 1=1";
            this.ExecuteSql(sql, p_tran);
            sql = "update 汇总分析表 set Price=0 where 1=1";
            this.ExecuteSql(sql, p_tran);
            this.ExecuteSql("DELETE FROM 变量表", p_tran);
            DataTable unTable = null, table = null, childTable = null, ccTable = null;
            sql = "select UnId from 其他项目表 group by UnID";
            unTable = this.FillTable(sql, p_tran);
            foreach (DataRow unRow in unTable.Rows)
            {

                sql = "select * from 其他项目表  where Remark='属于投标人部分' and UnID = " + unRow["UnId"].ToString();
                table = this.FillTable(sql, p_tran);
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (row["Name"].ToString().Equals("副食品调节基金")) continue;
                        sql = "select * from 其他项目表  where ParentID = " + row["ID"].ToString() + " and UnID = " + unRow["UnId"].ToString();

                        childTable = this.FillTable(sql, p_tran);
                        //sql = "update 其他项目表 set Calculation='',Unitprice=0,Combinedprice=0,jsdJ=0,cjdj=0,cjHj=0,Coefficient=0 where ID =";
                        sql = "update 其他项目表 set Unitprice=0,Combinedprice=0,Calculation='',Coefficient=100 where UnID = " + unRow["UnId"].ToString() + " and ID =";
                        this.ExecuteSql(sql + row["ID"].ToString(), p_tran);
                        if (childTable != null)
                        {
                            foreach (DataRow cRow in childTable.Rows)
                            {
                                string sql1 = "select * from 其他项目表  where ParentID = " + cRow["ID"].ToString() + " and UnID = " + unRow["UnId"].ToString(); ;

                                ccTable = this.FillTable(sql1, p_tran);
                                this.ExecuteSql(sql + cRow["ID"].ToString(), p_tran);

                                if (ccTable != null)
                                {
                                    foreach (DataRow ccRow in ccTable.Rows)
                                    {
                                        this.ExecuteSql(sql + ccRow["ID"].ToString(), p_tran);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            sql = "update 其他项目表 set Combinedprice=0 where ParentID = 0";
            this.ExecuteSql(sql, p_tran);
            //sql = "update 用途类别表 set BDBH='',XHL=0,DEDJ=0,DEHJ=0,SCDJ=0,SCHJ=0,DJC=0,JSDJ=0,JSDJC=0,GCL=0,SL=0,JSHJC=0,HJC=0 where 1=1";
            //this.ExecuteSql(sql, p_tran);
            sql = "update 用途类别表 set BDBH='',XHL=0,DEDJ=0,DEHJ=0,SCDJ=0,SCHJ=0,DJC=0,JSDJ=0,JSDJC=0,GCL=0,SL=0,JSHJC=0,HJC=0 where YTLB='评标指定材料'";
            this.ExecuteSql(sql, p_tran);
            sql = "update 用途类别表 set BDBH='',XHL=0,DEDJ=0,DEHJ=0,SCHJ=0,DJC=0,JSDJ=0,JSDJC=0,GCL=0,SL=0,JSHJC=0,HJC=0 where YTLB='评标指定材料'";
            this.ExecuteSql(sql, p_tran);
            sql = "update 用途类别表 set BDBH='',XHL=0,DEDJ=0,DEHJ=0,SCHJ=0,DJC=0,JSDJ=0,JSDJC=0,GCL=0,SL=0,JSHJC=0,HJC=0 where YTLB='暂定价材料' or YTLB='甲供材料'";
            this.ExecuteSql(sql, p_tran);



            sql = "update 措施项目表 set FL=0,JSJC='',ZHDJ=0,ZHHJ=0 where LB = '清单' and ZJFS = '公式组价' and XH > 4";
            this.ExecuteSql(sql, p_tran);

        }
        /// <summary>
        /// 保存变量表
        /// </summary>
        /// <param name="tran"></param>
        private void Save_ProjVariable(IDbTransaction p_tran)
        {


            //默认添加当前项目基础数据到数据表(暂时清空分部分项表重新加入数据)
            string sql = string.Format("delete from 变量表 ");
            this.Current.StructSource.ModelProjVariable.AcceptChanges();
            foreach (DataRow row in this.Current.StructSource.ModelProjVariable.Rows)
            {
                row.SetAdded();
            }

            using (OleDbCommand cmd = this.Conn.CreateCommand() as OleDbCommand)
            {
                cmd.Connection = this.Conn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }

            //先清空项目分部分项数据表 然后添加
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 变量表(");
                strSql.Append("[Key],[Value],[Remark],[Length],[FYLB],[Sort],[Type],[ISDE],[EnID],[ID]");
                strSql.Append(") values (");
                strSql.Append("@Key,@Value,@Remark,@Length,@FYLB,@Sort,@Type,@ISDE,@EnID,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Variable) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                //更新当做插入处理
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Variable) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;
                //保存结果数据
                try
                {
                    da.Update(this.Current.StructSource.ModelProjVariable);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                this.Current.StructSource.ModelProjVariable.AcceptChanges();
            }
        }

        /// <summary>
        /// 保存项目结构信息
        /// </summary>
        private void Save_Proj(IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                StringBuilder strSql = new StringBuilder();

                //strSql.Append("delete from 项目结构表 ");
                ////strSql.Append(" where ID=@ID");
                //OleDbParameter[] parameters = {
                //    //new OleDbParameter("@ID", OleDbType.Integer),
                //    //new OleDbParameter("@DEEP",OleDbType.Integer)
                //};
                ////parameters[0].SourceColumn = "ID";
                ////parameters[1].SourceColumn = "DEEP";
                //da.DeleteCommand = this.CreateCommand(strSql.ToString(), parameters) as OleDbCommand;
                //da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                //da.DeleteCommand.ExecuteNonQuery();
                //da.DeleteCommand = null;

                //strSql = new StringBuilder();

                strSql.Append("update 项目结构表 set ");
                strSql.Append(" [PID] = @PID , ");
                strSql.Append(" [Name] = @Name , ");
                strSql.Append(" [CODE] = @CODE , ");
                strSql.Append(" [QDGZ] = @QDGZ , ");
                strSql.Append(" [DEGZ] = @DEGZ , ");
                strSql.Append(" [PGCDD] = @PGCDD , ");
                strSql.Append(" [PJFCX] = @PJFCX , ");
                strSql.Append(" [PNSDD] = @PNSDD , ");
                strSql.Append(" [CREATOR] = @CREATOR , ");
                strSql.Append(" [EDITOR] = @EDITOR , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [Deep] = @Deep , ");
                strSql.Append(" [NodeName] = @NodeName , ");
                strSql.Append(" [PlaitNo] = @PlaitNo , ");
                strSql.Append(" [ReviewName] = @ReviewName , ");
                strSql.Append(" [PlaitName] = @PlaitName , ");
                strSql.Append(" [ProType] = @ProType , ");
                strSql.Append(" [PrfType] = @PrfType , ");
                strSql.Append(" [Remark] = @Remark , ");
                strSql.Append(" [QDLibName] = @QDLibName , ");
                strSql.Append(" [DELibName] = @DELibName , ");
                strSql.Append(" [TJLibName] = @TJLibName , ");
                strSql.Append(" [FISTDATETIME] = @FISTDATETIME , ");
                strSql.Append(" [EDITDATETIME] = @EDITDATETIME , ");
                strSql.Append(" [PlaitDate] = @PlaitDate , ");
                strSql.Append(" [ReviewDate] = @ReviewDate,  ");
                strSql.Append(" [Key] = @Key,  ");
                strSql.Append(" [PKey] = @PKey,  ");
                strSql.Append(" [PassWord] = @PassWord  ,");
                strSql.Append(" [JMSH] = @JMSH  ,");
                strSql.Append(" [JQH] = @JQH  ,");
                strSql.Append(" [Time] = @Time  ,");
                strSql.Append(" [ImageIndex] = @ImageIndex  ,");
                strSql.Append(" [State] = @State  ");
                strSql.Append(" where ID=@ID ");


                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_UPDATE) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;
                strSql = new StringBuilder();
                strSql.Append("insert into 项目结构表(");
                strSql.Append("[PID],[Name],[CODE],[QDGZ],[DEGZ],[PGCDD],[PJFCX],[PNSDD],[CREATOR],[EDITOR],[Sort],[Deep],[NodeName],[PlaitNo],[ReviewName],[PlaitName],[ProType],[PrfType],[Remark],[QDLibName],[DELibName],[TJLibName],[FISTDATETIME],[EDITDATETIME],[PlaitDate],[ReviewDate],[Key],[PKey],[PassWord],[JMSH],[JQH],[Time],[ImageIndex],[State],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@Name,@CODE,@QDGZ,@DEGZ,@PGCDD,@PJFCX,@PNSDD,@CREATOR,@EDITOR,@Sort,@Deep,@NodeName,@PlaitNo,@ReviewName,@PlaitName,@ProType,@PrfType,@Remark,@QDLibName,@DELibName,@TJLibName,@FISTDATETIME,@EDITDATETIME,@PlaitDate,@ReviewDate,@Key,@PKey,[@PassWord],@JMSH,@JQH,@Time,@ImageIndex,@State,@ID");
                strSql.Append(")");
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_UPDATE) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                strSql = new StringBuilder();
                strSql.Append("delete from 项目结构表 ");
                strSql.Append(" where ID=@ID");
                OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer),
                    new OleDbParameter("@DEEP",OleDbType.Integer)
                };
                parameters[0].SourceColumn = "ID";
                parameters[1].SourceColumn = "DEEP";
                da.DeleteCommand = this.CreateCommand(strSql.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                //确认更新结构表
                //da.RowUpdating += new OleDbRowUpdatingEventHandler(_ProjDataBase_RowUpdating);
                //da.RowUpdated += new OleDbRowUpdatedEventHandler(da_RowUpdated);
                da.RowUpdating += new OleDbRowUpdatingEventHandler(da_RowUpdating);

                DataTable table = this.Current.StructSource.ModelProject.GetChanges();

                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                this.Current.StructSource.ModelProject.AcceptChanges();
                //更新项目数据
                if (this.Current.ObjectState == EObjectState.Modify)
                {
                    //this.UpDateProject(p_tran);
                }

                //(this.IDataBase.UpDateAdapter as OleDbDataAdapter).RowUpdating += new OleDbRowUpdatingEventHandler(_ProjDataBase_RowUpdating);
                //(this.IDataBase.UpDateAdapter as OleDbDataAdapter).RowUpdated += new OleDbRowUpdatedEventHandler(_ProjDataBase_RowUpdated);
                //this.IDataBase.DoUpDate(this.Current.StructSource.ModelProject);
                //save_unit_Data();
            }
        }

        void da_RowUpdating(object sender, OleDbRowUpdatingEventArgs e)
        {
            //如果是删除此处特殊处理
            //1.结构变发生变化的时候 可能是项目 单项工程 单位工程
            //2.暂时主要处理单位工程Deep = 2的项目
            //3.更新单位工程的所有数据集合
            object UnId = e.Command.Parameters[0].Value;
            object DEEP = e.Command.Parameters[1].Value;
            //更新分部分项

            //当前行对象更新状态 (增删改查)
            switch (e.StatementType)
            {
                case StatementType.Delete://新项目删除的时候
                    if (DEEP.Equals(2))
                    {
                        this.Delete_ProjByUnID(UnId, "UnId", e.Command.Transaction);
                    }
                    if (DEEP.Equals(1))
                    {
                        this.Delete_ProjByUnID(UnId, "EnId", e.Command.Transaction);
                    }
                    break;
            }
        }


        /// <summary>
        /// 项目数据更新之后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void da_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {

        }

        /// <summary>
        /// 保存分部分项数据(此方法暂时计算后调用)
        /// </summary>
        /// <param name="p_tran"></param>
        private void Save_SubData(IDbTransaction p_tran)
        {

            if (!this.Current.StructSource.ModelSubSegments.IsCompled) return;

            //默认添加当前项目基础数据到数据表(暂时清空分部分项表重新加入数据)
            string sql = string.Format("delete from 分部分项表");

            using (OleDbCommand cmd = this.Conn.CreateCommand() as OleDbCommand)
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }


            //先清空项目分部分项数据表 然后添加
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 分部分项表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],[ID],RGFJC,CLFJC,JXFJC");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@ID,@RGFJC,@CLFJC,@JXFJC");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                //更新当做插入处理


                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;
                try
                {
                    int count = da.Update(this.Current.StructSource.ModelSubSegments);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

        /// <summary>
        /// 保存分部分项数据(此方法暂时计算后调用)
        /// </summary>
        /// <param name="p_tran"></param>
        private void Save_MeasuresData(IDbTransaction p_tran)
        {

            if (!this.Current.StructSource.ModelSubSegments.IsCompled) return;

            //默认添加当前项目基础数据到数据表(暂时清空分部分项表重新加入数据)
            string sql = string.Format("delete from 措施项目表");

            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }


            //先清空项目分部分项数据表 然后添加
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 措施项目表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[UnID],[Key],[PKey],[Deep],[Sort],[EnID],[ID],RGFJC,CLFJC,JXFJC");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@UnID,@Key,@PKey,@Deep,@Sort,@EnID,@ID,@RGFJC,@CLFJC,@JXFJC");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                //更新当做插入处理
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;
                try
                {
                    int count = da.Update(this.Current.StructSource.ModelMeasures);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

        /// <summary>
        /// 保存分部分项数据(此方法暂时计算后调用)
        /// </summary>
        /// <param name="p_tran"></param>
        private void Save_MetaanalysisData(IDbTransaction p_tran)
        {

            if (!this.Current.StructSource.ModelSubSegments.IsCompled) return;

            //默认添加当前项目基础数据到数据表(暂时清空分部分项表重新加入数据)
            string sql = string.Format("delete from 汇总分析表");

            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }


            //先清空项目分部分项数据表 然后添加
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 汇总分析表(");
                strSql.Append("[Key],[PKey],[FGCF],[CSXMF],[QTXMF],[GF],[SJ],[ZZJ],[AQWM],[LBTC],[JSDW],[JZMJ],[DWZJ],[ZZJB],[BZ],[PID]");
                strSql.Append(") values (");
                strSql.Append("@Key,@PKey,@FGCF,@CSXMF,@QTXMF,@GF,@SJ,@ZZJ,@AQWM,@LBTC,@JSDW,@JZMJ,@DWZJ,@ZZJB,@BZ,@PID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_METAANALYSIS) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                //更新当做插入处理


                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_METAANALYSIS) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;
                try
                {
                    int count = da.Update(this.Current.StructSource.ModelMetaanalysis);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

        /// <summary>
        /// 获取指定单位工程的全部数据对象
        /// </summary>
        /// <param name="p_Info"></param>
        public override void Load(_COBJECTS p_Info)
        {
            if (p_Info.Deep == 0)
            {
                base.Load(p_Info);
                return;
            }

            this.OpenConnection();
            p_Info.StructSource = new _StructSource();
            p_Info.StructSource.UnitjBuilder();

            //开始读取数据

            string sql = string.Format("select * from 项目结构表 where ID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelProject);


            //读取项目分部分项数据
            sql = string.Format("select * from 分部分项表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelSubSegments);
            ////给子目设定专业
            //DataRow[] drs = p_Info.StructSource.ModelSubSegments.Select(string.Format("LB='子目'"));
            //foreach (DataRow item in drs)
            //{

            //    //用LibraryName 截取专业

            //    item["ZYLB"] = GETZYLB(item["LibraryName"].ToString());
            //    p_Info.StructSource.ModelSubSegments.UpDate(item);
            //}


            //措施项目数据
            sql = string.Format("select * from 措施项目表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelMeasures);



            //其他项目数据
            sql = string.Format("select * from 其他项目表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelOtherProject);
            //工料机表
            sql = string.Format("select [ID],[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[SSKLB],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS] from 工料机表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelQuantity);
            //用途类别表
            sql = string.Format("select [ID],[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS],[BDBH],[SSKLB],[DZBS] from 用途类别表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelYTLBSummary);
            //子目取费表
            sql = string.Format("select * from 子目取费表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelSubheadingsFee);
            //参数子目取费表
            sql = string.Format("select * from 参数子目取费表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelPSubheadingsFee);
            //工程取费
            sql = string.Format("select * from 工程取费 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelUnitFee);
            //标准换算表
            sql = string.Format("select * from 标准换算表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelStandardConversion);
            //安装增加费
            sql = string.Format("select * from 安装增加费 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelIncreaseCosts);
            //汇总分析表
            sql = string.Format("select * from 汇总分析表 where UnID = {0}", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelMetaanalysis);
            //单位工程变量
            sql = string.Format("select * from 变量表 where ID = {0} and Type = '-1'", p_Info.ID);
            this.FillDataSet(sql, p_Info.StructSource.ModelProjVariable);


            this.CloseConnection();

            //变量
            /*sql = string.Format("select * from 变量表 where UnID = {0}", p_Info.ID);
            this.Current.Property.Statistics.ResultVarable.DataSource.Clear();
            this.FillDataSet(sql, this.Current.Property.Statistics.ResultVarable.DataSource);
            this.Current.Property.Statistics.IsCompled = false;
            //读取汇总分析数据
            sql = string.Format("select * from 汇总分析表 order by PID", p_Info.ID);
            this.FillDataSet(sql, this.Current.StructSource.ModelMetaanalysis);
            this.Current.StructSource.ModelMetaanalysis.IsCompled = false;*/
        }


        void _ProjDataBase_RowUpdating(object sender, OleDbRowUpdatingEventArgs e)
        {
            IDbTransaction tran = e.Command.Transaction;
            if (e.StatementType == System.Data.StatementType.Delete)
            {
                //删除逻辑直接删除信息
                OleDbParameter param = e.Command.Parameters["@ID"];
                this.DeleteUnitProject(param.Value, tran);
            }
            else
            {
                //提交前先保存单位工程对象
                _UnitProject unit = e.Row["UnitProject"] as _UnitProject;
                if (unit != null)
                {
                    //通知赋值加密锁号
                    this.OnSetKey(unit);
                    //开始保存逻辑 根据更新还是新增状态 保存单位工程
                    if (e.Row.RowState == System.Data.DataRowState.Added)
                    {
                        //序列化并且保存
                        //对象已经提交并且修改
                        if (unit.ObjectState == EObjectState.Created)
                        {
                            unit.ObjectState = EObjectState.UnChange;
                            byte[] bs = GetByteObject(unit);
                            //新增处理
                            AddUnitProject(unit, bs, tran);
                        }
                    }
                    if (e.Row.RowState == System.Data.DataRowState.Modified)
                    {
                        if (unit.ObjectState == EObjectState.Modify)
                        {
                            unit.ObjectState = EObjectState.UnChange;
                            //序列化并且保存
                            byte[] bs = GetByteObject(unit);
                            //新增处理
                            UpDateUnitProject(unit, bs, tran);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 为单位工程添加单项工程到数据库文件
        /// </summary>
        /// <param name="p_info">单项工程对象</param>
        public void AddUnitProject(_UnitProject p_infos, byte[] p_Bytes, IDbTransaction p_tran)
        {
            //默认添加当前项目基础数据到数据表
            string sql = "insert into 单位工程(PID,[OBJECT]) values (@PID,@OBJECT);";
            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@PID", OleDbType.VarChar,100),
                new OleDbParameter("@OBJECT", OleDbType.Binary)
            };
            param[0].Value = p_infos.ID;
            param[1].Value = p_Bytes;
            using (OleDbCommand cmd = Conn.CreateCommand())
            {

                cmd.Parameters.AddRange(param);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }
            //this.IDataBase.ExecuteSql(sql, param);
        }

        /// <summary>
        /// 为单位工程添加单项工程到数据库文件
        /// </summary>
        /// <param name="p_info">单项工程对象</param>
        public void UpDateProject(IDbTransaction p_tran)
        {
            //默认添加当前项目基础数据到数据表
            string sql = "update 单位工程 set [OBJECT] = @OBJECT where PID =@PID;";
            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@OBJECT", OleDbType.Binary),
                new OleDbParameter("@PID", OleDbType.VarChar,100)
            };
            param[1].Value = this.Current.ID;
            param[0].Value = this.GetByteObject(this.Current.Property.BasicInformation); ;

            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {

                cmd.Parameters.AddRange(param);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }

            //this.IDataBase.ExecuteSql(sql, param);
        }

        /// <summary>
        /// 为单位工程添加单项工程到数据库文件
        /// </summary>
        /// <param name="p_info">单项工程对象</param>
        public void UpDateUnitProject(_UnitProject p_infos, byte[] p_Bytes, IDbTransaction p_tran)
        {
            //默认添加当前项目基础数据到数据表
            string sql = "update 单位工程 set [OBJECT] = @OBJECT where PID =@PID;";
            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@OBJECT", OleDbType.Binary),
                new OleDbParameter("@PID", OleDbType.VarChar,100)
            };
            param[1].Value = p_infos.ID;
            param[0].Value = p_Bytes;

            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Parameters.AddRange(param);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }

            //this.IDataBase.ExecuteSql(sql, param);
        }

        public void DeleteUnitProject(object id, IDbTransaction p_tran)
        {
            //默认添加当前项目基础数据到数据表
            string sql = string.Format("delete from 单位工程 where PID ={0}", id);

            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }
        }


        #region --------------------------单位工程操作----------------------------

        /// <summary>
        /// 删除想目标中的所有子表数据
        /// </summary>
        private void Delete_ProjByUnID(object p_ID, string p_ColName, IDbTransaction p_tran)
        {
            //删除分部分项
            OleDbParameter[] parameters = {
                                            new OleDbParameter("@ID", OleDbType.Integer)
                                          };
            parameters[0].Value = p_ID;
            string strSql = string.Empty;

            using (OleDbCommand cmd = this.Conn.CreateCommand() as OleDbCommand)
            {
                cmd.Parameters.AddRange(parameters);
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                strSql = string.Format("delete from 分部分项表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 其他项目表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 措施项目表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 子目取费表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 用途类别表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 标准换算表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 安装增加费 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 工料机表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 汇总分析表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 参数子目取费表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                strSql = string.Format("delete from 工程取费 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                /*strSql = string.Format("delete from 变量表 where {0} = @ID", p_ColName);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();*/
            }
        }

        /// <summary>
        /// 更新分部分项
        /// </summary>
        /// <param name="p_UnID"></param>
        private void UpDate_SubData(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 分部分项表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],RGFJC,CLFJC,JXFJC,DZBS,[ID],[ZYLB]");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@RGFJC,@CLFJC,@JXFJC,@DZBS,@ID,@ZYLB");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 分部分项表 set ");
                //strSql.Append(" [XMMC] = @XMMC  ");
                strSql.Append(" [PID] = @PID , ");
                strSql.Append(" [PPARENTID] = @PPARENTID , ");
                strSql.Append(" [CPARENTID] = @CPARENTID , ");
                strSql.Append(" [FPARENTID] = @FPARENTID , ");
                strSql.Append(" [XH] = @XH , ");
                strSql.Append(" [XMBM] = @XMBM , ");
                strSql.Append(" [OLDXMBM] = @OLDXMBM , ");
                strSql.Append(" [XMMC] = @XMMC , ");
                strSql.Append(" [DW] = @DW , ");
                strSql.Append(" [TX] = @TX , ");
                strSql.Append(" [LB] = @LB , ");
                strSql.Append(" [JCBJ] = @JCBJ , ");
                strSql.Append(" [FHBJ] = @FHBJ , ");
                strSql.Append(" [ZYQD] = @ZYQD , ");
                strSql.Append(" [SDDJ] = @SDDJ , ");
                strSql.Append(" [JBHZ] = @JBHZ , ");
                strSql.Append(" [XMTZ] = @XMTZ , ");
                strSql.Append(" [GCLJSS] = @GCLJSS , ");
                strSql.Append(" [ZJWZ] = @ZJWZ , ");
                strSql.Append(" [JX] = @JX , ");
                strSql.Append(" [SC] = @SC , ");
                strSql.Append(" [YGLB] = @YGLB , ");
                strSql.Append(" [QFSZ] = @QFSZ , ");
                strSql.Append(" [BEIZHU] = @BEIZHU , ");
                strSql.Append(" [LibraryName] = @LibraryName , ");
                strSql.Append(" [LY] = @LY , ");
                strSql.Append(" [SDQD] = @SDQD , ");
                strSql.Append(" [SFFB] = @SFFB , ");
                strSql.Append(" [HL] = @HL , ");
                strSql.Append(" [GCL] = @GCL , ");
                strSql.Append(" [ZJTJ] = @ZJTJ , ");
                strSql.Append(" [ZHDJ] = @ZHDJ , ");
                strSql.Append(" [ZHHJ] = @ZHHJ , ");
                strSql.Append(" [ZJFDJ] = @ZJFDJ , ");
                strSql.Append(" [RGFDJ] = @RGFDJ , ");
                strSql.Append(" [CLFDJ] = @CLFDJ , ");
                strSql.Append(" [JXFDJ] = @JXFDJ , ");
                strSql.Append(" [ZCFDJ] = @ZCFDJ , ");
                strSql.Append(" [SBFDJ] = @SBFDJ , ");
                strSql.Append(" [GLFDJ] = @GLFDJ , ");
                strSql.Append(" [LRDJ] = @LRDJ , ");
                strSql.Append(" [FXDJ] = @FXDJ , ");
                strSql.Append(" [GFDJ] = @GFDJ , ");
                strSql.Append(" [SJDJ] = @SJDJ , ");
                strSql.Append(" [CJDJ] = @CJDJ , ");
                strSql.Append(" [JCDJ] = @JCDJ , ");
                strSql.Append(" [XHL] = @XHL , ");
                strSql.Append(" [ZJFHJ] = @ZJFHJ , ");
                strSql.Append(" [RGFHJ] = @RGFHJ , ");
                strSql.Append(" [CLFHJ] = @CLFHJ , ");
                strSql.Append(" [JXFHJ] = @JXFHJ , ");
                strSql.Append(" [ZCFHJ] = @ZCFHJ , ");
                strSql.Append(" [SBFHJ] = @SBFHJ , ");
                strSql.Append(" [GLFHJ] = @GLFHJ , ");
                strSql.Append(" [LRHJ] = @LRHJ , ");
                strSql.Append(" [FXHJ] = @FXHJ , ");
                strSql.Append(" [GFHJ] = @GFHJ , ");
                strSql.Append(" [SJHJ] = @SJHJ , ");
                strSql.Append(" [JCHJ] = @JCHJ , ");
                strSql.Append(" [CJHJ] = @CJHJ , ");
                strSql.Append(" [ZGJE] = @ZGJE , ");
                strSql.Append(" [JGJE] = @JGJE , ");
                strSql.Append(" [FBJE] = @FBJE , ");
                strSql.Append(" [FL] = @FL , ");
                strSql.Append(" [DECJ] = @DECJ , ");
                strSql.Append(" [JSJC] = @JSJC , ");
                strSql.Append(" [ZJFS] = @ZJFS , ");
                strSql.Append(" [QDBH] = @QDBH , ");
                strSql.Append(" [XMNR] = @XMNR , ");
                strSql.Append(" [XMTZZ] = @XMTZZ , ");
                strSql.Append(" [TYGS] = @TYGS , ");
                strSql.Append(" [ISTY] = @ISTY , ");
                strSql.Append(" [PBZD] = @PBZD , ");
                strSql.Append(" [YGJE] = @YGJE , ");
                strSql.Append(" [STATUS] = @STATUS , ");
                strSql.Append(" [ZDSC] = @ZDSC , ");
                strSql.Append(" [Key] = @Key , ");
                strSql.Append(" [PKey] = @PKey , ");
                strSql.Append(" [Deep] = @Deep , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [SSLB] = @SSLB ,  ");
                // strSql.Append(" [DZBS] = @DZBS ,  ");

                strSql.Append(" [RGFJC] = @RGFJC , ");
                strSql.Append(" [CLFJC] = @CLFJC , ");
                strSql.Append(" [JXFJC] = @JXFJC , ");
                strSql.Append(" [DZBS] = @DZBS,  ");
                strSql.Append(" [ID] = @ID, ");
                strSql.Append(" [ZYLB] = @ZYLB ");
                strSql.Append("   where ID=@ID and UnID=@UnID ");

                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 分部分项表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                //計算含量
                DataRow[] zmRows = p_Unit.StructSource.ModelSubSegments.Select("LB = '子目'");
                DataRow[] qdRows, zmqfRows;
                foreach (DataRow row in zmRows)
                {
                    qdRows = p_Unit.StructSource.ModelSubSegments.Select("ID = " + row["PID"].ToString());
                    row["HL"] = float.Parse(row["GCL"].ToString()) / float.Parse(qdRows[0]["GCL"].ToString());
                    row["SC"] = "True";
                }


                DataRow[] srows = p_Unit.StructSource.ModelSubSegments.Select("LB='清单'", "Deep asc,ID asc");
                int n = 1;
                foreach (DataRow srow in srows)
                {
                    srow["Sort"] = n++;
                }
                srows = p_Unit.StructSource.ModelSubSegments.Select("LB = '子目' or LB = '子目-降效' or LB = '子目-增加费'", "Deep asc,ID asc");
                foreach (DataRow srow in srows)
                {
                    srow["Sort"] = n++;
                }

                DataTable table = p_Unit.StructSource.ModelSubSegments.GetChanges();

                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                p_Unit.StructSource.ModelSubSegments.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新分部分项(电子标书)
        /// </summary>
        /// <param name="p_UnID"></param>
        private void UpDate_SubData_DZBS(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 分部分项表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],[ID],RGFJC,CLFJC,JXFJC,DZBS");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@ID,@RGFJC,@CLFJC,@JXFJC,True");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 分部分项表 set ");
                //strSql.Append(" [XMMC] = @XMMC  ");
                strSql.Append(" [PID] = @PID , ");
                strSql.Append(" [PPARENTID] = @PPARENTID , ");
                strSql.Append(" [CPARENTID] = @CPARENTID , ");
                strSql.Append(" [FPARENTID] = @FPARENTID , ");
                strSql.Append(" [XH] = @XH , ");
                strSql.Append(" [XMBM] = @XMBM , ");
                strSql.Append(" [OLDXMBM] = @OLDXMBM , ");
                strSql.Append(" [XMMC] = @XMMC , ");
                strSql.Append(" [DW] = @DW , ");
                strSql.Append(" [TX] = @TX , ");
                strSql.Append(" [LB] = @LB , ");
                strSql.Append(" [JCBJ] = @JCBJ , ");
                strSql.Append(" [FHBJ] = @FHBJ , ");
                strSql.Append(" [ZYQD] = @ZYQD , ");
                strSql.Append(" [SDDJ] = @SDDJ , ");
                strSql.Append(" [JBHZ] = @JBHZ , ");
                strSql.Append(" [XMTZ] = @XMTZ , ");
                strSql.Append(" [GCLJSS] = @GCLJSS , ");
                strSql.Append(" [ZJWZ] = @ZJWZ , ");
                strSql.Append(" [JX] = @JX , ");
                strSql.Append(" [SC] = @SC , ");
                strSql.Append(" [YGLB] = @YGLB , ");
                strSql.Append(" [QFSZ] = @QFSZ , ");
                strSql.Append(" [BEIZHU] = @BEIZHU , ");
                strSql.Append(" [LibraryName] = @LibraryName , ");
                strSql.Append(" [LY] = @LY , ");
                strSql.Append(" [SDQD] = @SDQD , ");
                strSql.Append(" [SFFB] = @SFFB , ");
                strSql.Append(" [HL] = @HL , ");
                strSql.Append(" [GCL] = @GCL , ");
                strSql.Append(" [ZJTJ] = @ZJTJ , ");
                strSql.Append(" [ZHDJ] = @ZHDJ , ");
                strSql.Append(" [ZHHJ] = @ZHHJ , ");
                strSql.Append(" [ZJFDJ] = @ZJFDJ , ");
                strSql.Append(" [RGFDJ] = @RGFDJ , ");
                strSql.Append(" [CLFDJ] = @CLFDJ , ");
                strSql.Append(" [JXFDJ] = @JXFDJ , ");
                strSql.Append(" [ZCFDJ] = @ZCFDJ , ");
                strSql.Append(" [SBFDJ] = @SBFDJ , ");
                strSql.Append(" [GLFDJ] = @GLFDJ , ");
                strSql.Append(" [LRDJ] = @LRDJ , ");
                strSql.Append(" [FXDJ] = @FXDJ , ");
                strSql.Append(" [GFDJ] = @GFDJ , ");
                strSql.Append(" [SJDJ] = @SJDJ , ");
                strSql.Append(" [CJDJ] = @CJDJ , ");
                strSql.Append(" [JCDJ] = @JCDJ , ");
                strSql.Append(" [XHL] = @XHL , ");
                strSql.Append(" [ZJFHJ] = @ZJFHJ , ");
                strSql.Append(" [RGFHJ] = @RGFHJ , ");
                strSql.Append(" [CLFHJ] = @CLFHJ , ");
                strSql.Append(" [JXFHJ] = @JXFHJ , ");
                strSql.Append(" [ZCFHJ] = @ZCFHJ , ");
                strSql.Append(" [SBFHJ] = @SBFHJ , ");
                strSql.Append(" [GLFHJ] = @GLFHJ , ");
                strSql.Append(" [LRHJ] = @LRHJ , ");
                strSql.Append(" [FXHJ] = @FXHJ , ");
                strSql.Append(" [GFHJ] = @GFHJ , ");
                strSql.Append(" [SJHJ] = @SJHJ , ");
                strSql.Append(" [JCHJ] = @JCHJ , ");
                strSql.Append(" [CJHJ] = @CJHJ , ");
                strSql.Append(" [ZGJE] = @ZGJE , ");
                strSql.Append(" [JGJE] = @JGJE , ");
                strSql.Append(" [FBJE] = @FBJE , ");
                strSql.Append(" [FL] = @FL , ");
                strSql.Append(" [DECJ] = @DECJ , ");
                strSql.Append(" [JSJC] = @JSJC , ");
                strSql.Append(" [ZJFS] = @ZJFS , ");
                strSql.Append(" [QDBH] = @QDBH , ");
                strSql.Append(" [XMNR] = @XMNR , ");
                strSql.Append(" [XMTZZ] = @XMTZZ , ");
                strSql.Append(" [TYGS] = @TYGS , ");
                strSql.Append(" [ISTY] = @ISTY , ");
                strSql.Append(" [PBZD] = @PBZD , ");
                strSql.Append(" [YGJE] = @YGJE , ");
                strSql.Append(" [STATUS] = @STATUS , ");
                strSql.Append(" [ZDSC] = @ZDSC , ");
                strSql.Append(" [Key] = @Key , ");
                strSql.Append(" [PKey] = @PKey , ");
                strSql.Append(" [Deep] = @Deep , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [SSLB] = @SSLB ,  ");
                strSql.Append(" [DZBS] = True ,  ");
                strSql.Append(" [ID] = @ID  ");
                strSql.Append("   where ID=@ID and UnID=@UnID ");

                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 分部分项表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelSubSegments.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.SetDZBS("update 分部分项表 set DZBS=True", p_tran);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_sql"></param>
        /// <param name="p_tran"></param>
        private void SetDZBS(string p_sql, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.CommandText = p_sql;
                cmd.CommandType = CommandType.Text;
                if (p_tran != null)
                    cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新子目取费表
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_SubheadingsFee(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                string sql = string.Format("delete from 子目取费表 where UnID = {0}", p_Unit.ID);
                try
                {
                    ExecuteSql(sql, p_tran);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }


                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 子目取费表(");
                strSql.Append("[EnID],[UnID],[SSLB],[QDID],[ZMID],[Sort],[YYH],[MC],[BDS],[SCJJC],[TBJSJC],[BDJSJC],[FL],[TBJE],[BDJE],[FYLB],[BZ],[STATUS],[JSSX],[ID],[QFLB]");
                strSql.Append(") values (");
                strSql.Append("@EnID,@UnID,@SSLB,@QDID,@ZMID,@Sort,@YYH,@MC,@BDS,@SCJJC,@TBJSJC,@BDJSJC,@FL,@TBJE,@BDJE,@FYLB,@BZ,@STATUS,@JSSX,@ID,@QFLB");
                strSql.Append(")");
                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBFREEDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 子目取费表 set ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [SSLB] = @SSLB , ");
                //strSql.Append(" [QDID] = @QDID , ");
                //strSql.Append(" [ZMID] = @ZMID , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [YYH] = @YYH , ");
                strSql.Append(" [MC] = @MC , ");
                strSql.Append(" [BDS] = @BDS , ");
                strSql.Append(" [SCJJC] = @SCJJC , ");
                strSql.Append(" [TBJSJC] = @TBJSJC , ");
                strSql.Append(" [BDJSJC] = @BDJSJC , ");
                strSql.Append(" [FL] = @FL , ");
                strSql.Append(" [TBJE] = @TBJE , ");
                strSql.Append(" [BDJE] = @BDJE , ");
                strSql.Append(" [FYLB] = @FYLB , ");
                strSql.Append(" [BZ] = @BZ , ");
                strSql.Append(" [STATUS] = @STATUS,  ");
                strSql.Append(" [JSSX] = @JSSX,  ");
                //strSql.Append(" [ID] = @ID,  ");
                strSql.Append(" [QFLB] = @QFLB  ");
                strSql.Append(" where ID=@ID and UnID=@UnID and YYH<>''");
                OleDbParameter[] tempParams = {
						                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                                                new OleDbParameter("@UnID", OleDbType.Integer,4),
                                                new OleDbParameter("@SSLB", OleDbType.Integer,4),
                                                new OleDbParameter("@Sort", OleDbType.Integer,4),
                                                new OleDbParameter("@YYH", OleDbType.VarChar,255),
                                                new OleDbParameter("@MC", OleDbType.VarChar,255),
                                                new OleDbParameter("@BDS", OleDbType.VarChar,255),
                                                new OleDbParameter("@SCJJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@TBJSJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@BDJSJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@FL", OleDbType.Decimal),
                                                new OleDbParameter("@TBJE", OleDbType.Decimal),
                                                new OleDbParameter("@BDJE", OleDbType.Decimal),
                                                new OleDbParameter("@FYLB", OleDbType.VarChar,255),
                                                new OleDbParameter("@BZ", OleDbType.VarChar,255),
                                                new OleDbParameter("@STATUS", OleDbType.Boolean,1),
                                                new OleDbParameter("@JSSX", OleDbType.Integer),
                                                new OleDbParameter("@QFLB", OleDbType.VarChar,255),
                                                new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                tempParams[0].SourceColumn = "EnID";
                tempParams[1].SourceColumn = "UnID";
                tempParams[2].SourceColumn = "SSLB";
                tempParams[3].SourceColumn = "Sort";
                tempParams[4].SourceColumn = "YYH";
                tempParams[5].SourceColumn = "MC";
                tempParams[6].SourceColumn = "BDS";
                tempParams[7].SourceColumn = "SCJJC";
                tempParams[8].SourceColumn = "TBJSJC";
                tempParams[9].SourceColumn = "BDJSJC";
                tempParams[10].SourceColumn = "FL";
                tempParams[11].SourceColumn = "TBJE";
                tempParams[12].SourceColumn = "BDJE";
                tempParams[13].SourceColumn = "FYLB";
                tempParams[14].SourceColumn = "BZ";
                tempParams[15].SourceColumn = "STATUS";
                tempParams[16].SourceColumn = "JSSX";
                tempParams[17].SourceColumn = "QFLB";
                tempParams[18].SourceColumn = "ID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), tempParams) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 子目取费表 where UnID = @UnID and ID= @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;


                DataRow[] zmRows = p_Unit.StructSource.ModelSubSegments.Select("LB = '子目'");
                DataRow[] qdRows;
                DataRow[] zmqfRows, valRows;
                string f1 = "", f2 = "", f3 = "", f4 = "", f5 = "", f6 = "", s1 = "", s2 = "", s3 = "", s4 = "";
                foreach (DataRow row in zmRows)
                {
                    f1 = "0.00"; f2 = "0.00"; f3 = "0.00"; f4 = "0.00"; f5 = "0.00"; f6 = "0.00"; s1 = "0.00"; s2 = "0.00"; s3 = "0.00"; s4 = "0.00";
                    //if (p_Unit.JJJC == 1)
                    //{
                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F1'");
                    valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(valRows[0]["Value"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 1;
                        f1 = valRows[0]["Value"].ToString();
                    }

                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F2'");
                    valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(valRows[0]["Value"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 2;
                        f2 = valRows[0]["Value"].ToString();
                    }

                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F3'");
                    valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(valRows[0]["Value"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 3;
                        f3 = valRows[0]["Value"].ToString();
                    }

                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F4'");
                    valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(valRows[0]["Value"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 4;
                        f4 = valRows[0]["Value"].ToString();

                    }

                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F5'");
                    valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(valRows[0]["Value"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 5;
                        f5 = valRows[0]["Value"].ToString();

                    }


                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = 'F6'");
                    valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(valRows[0]["Value"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 6;
                        f6 = valRows[0]["Value"].ToString();
                        if (string.IsNullOrEmpty(f6)) f6 = "0.00";

                    }

                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '一'");
                    //valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(ToolKit.ParseDecimal(decimal.Parse(f1) + decimal.Parse(f2) + decimal.Parse(f3) + decimal.Parse(f4) + decimal.Parse(f5) + decimal.Parse(f6)), 4);
                        zmqfRows[0]["JSSX"] = 7;
                        s1 = zmqfRows[0]["TBJE"].ToString();
                        if (p_Unit.PrfType.Equals("【人工土石方专业】") || p_Unit.PrfType.Equals("【安装专业】") || p_Unit.PrfType.Equals("【园林绿化专业】") || p_Unit.PrfType.Equals("【市政安装专业】"))
                        {
                            s2 = f1;
                        }
                        else if (p_Unit.PrfType.Equals("【市政建筑安装专业】") || p_Unit.PrfType.Equals("【市政建筑专业】"))
                        {
                            s2 = Convert.ToString(decimal.Parse(f1) + decimal.Parse(f3));
                        }
                        else
                        {
                            s2 = zmqfRows[0]["TBJE"].ToString();
                        }
                    }

                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '二'");
                    //valRows = p_Unit.StructSource.ModelSubSegments.Select("ID = " + row["ID"].ToString());
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = s2;
                        zmqfRows[0]["JSSX"] = 8;
                        //valRows[0]["GLFDJ"] = s2;

                    }
                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '三'");
                    //valRows = p_Unit.StructSource.ModelSubSegments.Select("ID = " + row["ID"].ToString());
                    if (zmqfRows.Length > 0 && valRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(decimal.Parse(s1) + decimal.Parse(s2), 4);
                        zmqfRows[0]["JSSX"] = 9;
                        s3 = zmqfRows[0]["TBJE"].ToString();
                    }
                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '四'");
                    //valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(decimal.Parse(s1) + decimal.Parse(s2) + decimal.Parse(s3), 4);
                        zmqfRows[0]["JSSX"] = 10;
                        s4 = zmqfRows[0]["TBJE"].ToString();
                    }
                    zmqfRows = p_Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["ID"].ToString() + " and YYH = '五'");
                    //valRows = p_Unit.StructSource.ModelVariable.Select("ID = " + row["ID"].ToString() + " and Key ='" + zmqfRows[0]["TBJSJC"].ToString() + "'");
                    if (zmqfRows.Length > 0)
                    {
                        zmqfRows[0]["TBJE"] = Math.Round(decimal.Parse(s4) * decimal.Parse(row["GCL"].ToString()), 4);
                        zmqfRows[0]["JSSX"] = 11;
                    }

                }


                var table = p_Unit.StructSource.ModelSubheadingsFee;
                table.AcceptChanges();
                table.SetRowStateAsNew();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1);
                    }
                }

                p_Unit.StructSource.ModelSubheadingsFee.AcceptChanges();

            }
        }

        /// <summary>
        /// 更新参数子目取费表
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_PSubheadingsFee(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.YSZMQFDataTemp.IsChange)
                {
                    string sql = string.Format("delete from 参数子目取费表 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = sql;
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = p_tran as OleDbTransaction;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }

                    p_Unit.DataTemp.YSZMQFDataTemp.IsChange = false;
                    p_Unit.StructSource.ModelPSubheadingsFee.SetRowStateAsNew();
                }

                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 参数子目取费表(");
                strSql.Append("[EnID],[UnID],[SSLB],[QDID],[ZMID],[Sort],[YYH],[MC],[BDS],[SCJJC],[TBJSJC],[BDJSJC],[FL],[TBJE],[BDJE],[FYLB],[BZ],[STATUS],[JSSX],[ID],[QFLB]");
                strSql.Append(") values (");
                strSql.Append("@EnID,@UnID,@SSLB,@QDID,@ZMID,@Sort,@YYH,@MC,@BDS,@SCJJC,@TBJSJC,@BDJSJC,@FL,@TBJE,@BDJE,@FYLB,@BZ,@STATUS,@JSSX,@ID,@QFLB");
                strSql.Append(")");
                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBFREEDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 参数子目取费表 set ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [SSLB] = @SSLB , ");
                strSql.Append(" [QDID] = @QDID , ");
                strSql.Append(" [ZMID] = @ZMID , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [YYH] = @YYH , ");
                strSql.Append(" [MC] = @MC , ");
                strSql.Append(" [BDS] = @BDS , ");
                strSql.Append(" [SCJJC] = @SCJJC , ");
                strSql.Append(" [TBJSJC] = @TBJSJC , ");
                strSql.Append(" [BDJSJC] = @BDJSJC , ");
                strSql.Append(" [FL] = @FL , ");
                strSql.Append(" [TBJE] = @TBJE , ");
                strSql.Append(" [BDJE] = @BDJE , ");
                strSql.Append(" [FYLB] = @FYLB , ");
                strSql.Append(" [BZ] = @BZ , ");
                strSql.Append(" [STATUS] = @STATUS,  ");
                strSql.Append(" [JSSX] = @JSSX,  ");
                strSql.Append(" [ID] = @ID,  ");
                strSql.Append(" [QFLB] = @QFLB  ");
                strSql.Append(" where ID=@ID and UnID=@UnID ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBFREEDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 参数子目取费表 where UnID = @UnID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelPSubheadingsFee.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                p_Unit.StructSource.ModelPSubheadingsFee.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新工程工料机
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_QuantityData(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 工料机表(");
                strSql.Append("[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[SSKLB],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@EnID,@UnID,@SSLB,@QDID,@ZMID,@YSBH,@YSMC,@YSDW,@YSXHL,@BH,@MC,@DW,@XHL,@LB,@DEDJ,@SCDJ,@JSDJ,@GCL,@IFZYCL,@ZCLB,@GGXH,@SDCLB,@SDCXS,@YTLB,@IFXZ,@IFSC,@IFFX,@IFSDSCDJ,@IFSDSL,@IFKFJ,@SSKLB,@GLJBZ,@CTIME,@SLH,@SLDEHJ,@SLSCHJ,@CJ,@PP,@ZLDJ,@GYS,@CD,@CJBZ,@XGHSCDJ,@TZXS,@ID");
                strSql.Append(")");
                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_QUANTITY) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 工料机表 set ");
                strSql.Append(" [PID] = @PID , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [SSLB] = @SSLB , ");
                strSql.Append(" [QDID] = @QDID , ");
                strSql.Append(" [ZMID] = @ZMID , ");
                strSql.Append(" [YSBH] = @YSBH , ");
                strSql.Append(" [YSMC] = @YSMC , ");
                strSql.Append(" [YSDW] = @YSDW , ");
                strSql.Append(" [YSXHL] = @YSXHL , ");
                strSql.Append(" [BH] = @BH , ");
                strSql.Append(" [MC] = @MC , ");
                strSql.Append(" [DW] = @DW , ");
                strSql.Append(" [XHL] = @XHL , ");
                strSql.Append(" [LB] = @LB , ");
                strSql.Append(" [DEDJ] = @DEDJ , ");
                strSql.Append(" [SCDJ] = @SCDJ , ");
                strSql.Append(" [JSDJ] = @JSDJ , ");
                strSql.Append(" [GCL] = @GCL , ");
                strSql.Append(" [IFZYCL] = @IFZYCL , ");
                strSql.Append(" [ZCLB] = @ZCLB , ");
                strSql.Append(" [GGXH] = @GGXH , ");
                strSql.Append(" [SDCLB] = @SDCLB , ");
                strSql.Append(" [SDCXS] = @SDCXS , ");
                strSql.Append(" [YTLB] = @YTLB , ");
                strSql.Append(" [IFXZ] = @IFXZ , ");
                strSql.Append(" [IFSC] = @IFSC , ");
                strSql.Append(" [IFFX] = @IFFX , ");
                strSql.Append(" [IFSDSCDJ] = @IFSDSCDJ , ");
                strSql.Append(" [IFSDSL] = @IFSDSL , ");
                strSql.Append(" [IFKFJ] = @IFKFJ , ");
                strSql.Append(" [SSKLB] = @SSKLB , ");
                strSql.Append(" [GLJBZ] = @GLJBZ , ");
                strSql.Append(" [CTIME] = @CTIME , ");
                strSql.Append(" [SLH] = @SLH , ");
                strSql.Append(" [SLDEHJ] = @SLDEHJ , ");
                strSql.Append(" [SLSCHJ] = @SLSCHJ , ");
                strSql.Append(" [CJ] = @CJ , ");
                strSql.Append(" [PP] = @PP , ");
                strSql.Append(" [ZLDJ] = @ZLDJ , ");
                strSql.Append(" [GYS] = @GYS , ");
                strSql.Append(" [CD] = @CD , ");
                strSql.Append(" [CJBZ] = @CJBZ , ");
                strSql.Append(" [XGHSCDJ] = @XGHSCDJ , ");
                strSql.Append(" [TZXS] = @TZXS,  ");
                strSql.Append(" [ID] = @ID  ");
                strSql.Append(" where ID=@ID and UnID=@UnID ");


                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_QUANTITY) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                ///删除
                string dstr = "delete from 工料机表 where UnID = @UnID and ID= @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                DataTable table = p_Unit.StructSource.ModelQuantity.GetChanges();
                foreach (DataRow row in p_Unit.StructSource.ModelYTLBSummary.Rows)
                {
                    if (string.IsNullOrEmpty(row["BDBH"].ToString()))
                    {
                        row["BDBH"] = row["SSKLB"];
                        row["SSKLB"] = "";
                    }
                }


                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                p_Unit.StructSource.ModelQuantity.AcceptChanges();
                //删除对应子目的工料机
                foreach (DataRow row in p_Unit.StructSource.ModelQuantity.Rows)
                {
                    DataRow[] qRows = p_Unit.StructSource.ModelMeasures.Select("ID = " + row["ZMID"].ToString());

                    if (qRows == null || qRows.Length <= 0)
                    {
                        DataRow[] qtyRows = p_Unit.StructSource.ModelQuantity.Select("ZMID = " + row["ZMID"].ToString());

                        foreach (DataRow qtyRow in qtyRows)
                        {
                            qtyRow.Delete();
                        }
                        break;
                    }
                }

                table = p_Unit.StructSource.ModelQuantity.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelQuantity.AcceptChanges();
            }
        }


        /// <summary>
        /// 更新措施项目
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_MeasuresData(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.MDataTemp.IsChange)
                {
                    string sql = string.Format("delete from 措施项目表 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = p_tran as OleDbTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    p_Unit.DataTemp.MDataTemp.IsChange = false;
                    p_Unit.StructSource.ModelMeasures.SetRowStateAsNew();
                }



                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 措施项目表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],RGFJC,CLFJC,JXFJC,DZBS,[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@RGFJC,@CLFJC,@JXFJC,@DZBS,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 措施项目表 set ");
                //strSql.Append(" [XMMC] = @XMMC  ");
                strSql.Append(" [PID] = @PID , ");
                strSql.Append(" [PPARENTID] = @PPARENTID , ");
                strSql.Append(" [CPARENTID] = @CPARENTID , ");
                strSql.Append(" [FPARENTID] = @FPARENTID , ");
                strSql.Append(" [XH] = @XH , ");
                strSql.Append(" [XMBM] = @XMBM , ");
                strSql.Append(" [OLDXMBM] = @OLDXMBM , ");
                strSql.Append(" [XMMC] = @XMMC , ");
                strSql.Append(" [DW] = @DW , ");
                strSql.Append(" [TX] = @TX , ");
                strSql.Append(" [LB] = @LB , ");
                strSql.Append(" [JCBJ] = @JCBJ , ");
                strSql.Append(" [FHBJ] = @FHBJ , ");
                strSql.Append(" [ZYQD] = @ZYQD , ");
                strSql.Append(" [SDDJ] = @SDDJ , ");
                strSql.Append(" [JBHZ] = @JBHZ , ");
                strSql.Append(" [XMTZ] = @XMTZ , ");
                strSql.Append(" [GCLJSS] = @GCLJSS , ");
                strSql.Append(" [ZJWZ] = @ZJWZ , ");
                strSql.Append(" [JX] = @JX , ");
                strSql.Append(" [SC] = @SC , ");
                strSql.Append(" [YGLB] = @YGLB , ");
                strSql.Append(" [QFSZ] = @QFSZ , ");
                strSql.Append(" [BEIZHU] = @BEIZHU , ");
                strSql.Append(" [LibraryName] = @LibraryName , ");
                strSql.Append(" [LY] = @LY , ");
                strSql.Append(" [SDQD] = @SDQD , ");
                strSql.Append(" [SFFB] = @SFFB , ");
                strSql.Append(" [HL] = @HL , ");
                strSql.Append(" [GCL] = @GCL , ");
                strSql.Append(" [ZJTJ] = @ZJTJ , ");
                strSql.Append(" [ZHDJ] = @ZHDJ , ");
                strSql.Append(" [ZHHJ] = @ZHHJ , ");
                strSql.Append(" [ZJFDJ] = @ZJFDJ , ");
                strSql.Append(" [RGFDJ] = @RGFDJ , ");
                strSql.Append(" [CLFDJ] = @CLFDJ , ");
                strSql.Append(" [JXFDJ] = @JXFDJ , ");
                strSql.Append(" [ZCFDJ] = @ZCFDJ , ");
                strSql.Append(" [SBFDJ] = @SBFDJ , ");
                strSql.Append(" [GLFDJ] = @GLFDJ , ");
                strSql.Append(" [LRDJ] = @LRDJ , ");
                strSql.Append(" [FXDJ] = @FXDJ , ");
                strSql.Append(" [GFDJ] = @GFDJ , ");
                strSql.Append(" [SJDJ] = @SJDJ , ");
                strSql.Append(" [CJDJ] = @CJDJ , ");
                strSql.Append(" [JCDJ] = @JCDJ , ");
                strSql.Append(" [XHL] = @XHL , ");
                strSql.Append(" [ZJFHJ] = @ZJFHJ , ");
                strSql.Append(" [RGFHJ] = @RGFHJ , ");
                strSql.Append(" [CLFHJ] = @CLFHJ , ");
                strSql.Append(" [JXFHJ] = @JXFHJ , ");
                strSql.Append(" [ZCFHJ] = @ZCFHJ , ");
                strSql.Append(" [SBFHJ] = @SBFHJ , ");
                strSql.Append(" [GLFHJ] = @GLFHJ , ");
                strSql.Append(" [LRHJ] = @LRHJ , ");
                strSql.Append(" [FXHJ] = @FXHJ , ");
                strSql.Append(" [GFHJ] = @GFHJ , ");
                strSql.Append(" [SJHJ] = @SJHJ , ");
                strSql.Append(" [JCHJ] = @JCHJ , ");
                strSql.Append(" [CJHJ] = @CJHJ , ");
                strSql.Append(" [ZGJE] = @ZGJE , ");
                strSql.Append(" [JGJE] = @JGJE , ");
                strSql.Append(" [FBJE] = @FBJE , ");
                strSql.Append(" [FL] = @FL , ");
                strSql.Append(" [DECJ] = @DECJ , ");
                strSql.Append(" [JSJC] = @JSJC , ");
                strSql.Append(" [ZJFS] = @ZJFS , ");
                strSql.Append(" [QDBH] = @QDBH , ");
                strSql.Append(" [XMNR] = @XMNR , ");
                strSql.Append(" [XMTZZ] = @XMTZZ , ");
                strSql.Append(" [TYGS] = @TYGS , ");
                strSql.Append(" [ISTY] = @ISTY , ");
                strSql.Append(" [PBZD] = @PBZD , ");
                strSql.Append(" [YGJE] = @YGJE , ");
                strSql.Append(" [STATUS] = @STATUS , ");
                strSql.Append(" [ZDSC] = @ZDSC , ");
                strSql.Append(" [Key] = @Key , ");
                strSql.Append(" [PKey] = @PKey , ");
                strSql.Append(" [Deep] = @Deep , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [SSLB] = @SSLB ,  ");
                strSql.Append(" [RGFJC] = @RGFJC , ");
                strSql.Append(" [CLFJC] = @CLFJC , ");
                strSql.Append(" [JXFJC] = @JXFJC , ");
                strSql.Append(" [DZBS] = @DZBS,  ");
                strSql.Append(" [ID] = @ID ");
                strSql.Append("   where [ID]=@ID and UnID=@UnID ");


                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 措施项目表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                DataRow[] srows = p_Unit.StructSource.ModelMeasures.Select("LB='清单'", "Sort asc,Deep asc,ID asc");
                int n = 1;
                foreach (DataRow srow in srows)
                {
                    srow["Sort"] = n++;
                }
                srows = p_Unit.StructSource.ModelMeasures.Select("LB = '子目' or LB = '子措施项' or LB = '子目-降效' or LB = '子目-增加费'", "Sort asc,Deep asc,ID asc");
                foreach (DataRow srow in srows)
                {
                    srow["Sort"] = n++;
                }

                DataTable table = p_Unit.StructSource.ModelMeasures.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                        foreach (DataRow row in table.Rows)
                        {
                            Console.WriteLine(row["ID"]);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                DataRow[] zmRows = p_Unit.StructSource.ModelMeasures.Select("LB = '子目' or LB = '子目-降效'");
                foreach (DataRow row in zmRows)
                {
                    row["SC"] = "True";
                }
                DataRow[] rows = p_Unit.StructSource.ModelMeasures.Select("XMBM like '15-%'");
                string zmCGJX = "1,,2,3,4,5,6,7,8,9,10,11,23,24,25,26,27,28,29,30,31";
                foreach (DataRow row in rows)
                {
                    if (zmCGJX.Contains(row["XMBM"].ToString().Substring(3)))
                    {
                        row["LB"] = "子目-降效";
                    }
                }

                p_Unit.StructSource.ModelMeasures.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新措施项目(电子标书)
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_MeasuresData_DZBS(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.MDataTemp.IsChange)
                {
                    string sql = string.Format("delete from 措施项目表 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = p_tran as OleDbTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    p_Unit.DataTemp.MDataTemp.IsChange = false;
                    p_Unit.StructSource.ModelMeasures.SetRowStateAsNew();
                }

                //update by fuqiang 2013-07-04
                string tmpSql = "delete from 措施项目表 where PPARENTID <> 0 and LB = '子目'";
                using (OleDbCommand cmd = this.Conn.CreateCommand())
                {
                    cmd.CommandText = tmpSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = p_tran as OleDbTransaction;
                    cmd.ExecuteNonQuery();
                }

                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 措施项目表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],[ID],RGFJC,CLFJC,JXFJC,DZBS");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@ID,@RGFJC,@CLFJC,@JXFJC,True");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 措施项目表 set ");
                strSql.Append(" [PID] = @PID , ");
                strSql.Append(" [PPARENTID] = @PPARENTID , ");
                strSql.Append(" [CPARENTID] = @CPARENTID , ");
                strSql.Append(" [FPARENTID] = @FPARENTID , ");
                strSql.Append(" [XH] = @XH , ");
                strSql.Append(" [XMBM] = @XMBM , ");
                strSql.Append(" [OLDXMBM] = @OLDXMBM , ");
                strSql.Append(" [XMMC] = @XMMC , ");
                strSql.Append(" [DW] = @DW , ");
                strSql.Append(" [TX] = @TX , ");
                strSql.Append(" [LB] = @LB , ");
                strSql.Append(" [JCBJ] = @JCBJ , ");
                strSql.Append(" [FHBJ] = @FHBJ , ");
                strSql.Append(" [ZYQD] = @ZYQD , ");
                strSql.Append(" [SDDJ] = @SDDJ , ");
                strSql.Append(" [JBHZ] = @JBHZ , ");
                strSql.Append(" [XMTZ] = @XMTZ , ");
                strSql.Append(" [GCLJSS] = @GCLJSS , ");
                strSql.Append(" [ZJWZ] = @ZJWZ , ");
                strSql.Append(" [JX] = @JX , ");
                strSql.Append(" [SC] = @SC , ");
                strSql.Append(" [YGLB] = @YGLB , ");
                strSql.Append(" [QFSZ] = @QFSZ , ");
                strSql.Append(" [BEIZHU] = @BEIZHU , ");
                strSql.Append(" [LibraryName] = @LibraryName , ");
                strSql.Append(" [LY] = @LY , ");
                strSql.Append(" [SDQD] = @SDQD , ");
                strSql.Append(" [SFFB] = @SFFB , ");
                strSql.Append(" [HL] = @HL , ");
                strSql.Append(" [GCL] = @GCL , ");
                strSql.Append(" [ZJTJ] = @ZJTJ , ");
                strSql.Append(" [ZHDJ] = @ZHDJ , ");
                strSql.Append(" [ZHHJ] = @ZHHJ , ");
                strSql.Append(" [ZJFDJ] = @ZJFDJ , ");
                strSql.Append(" [RGFDJ] = @RGFDJ , ");
                strSql.Append(" [CLFDJ] = @CLFDJ , ");
                strSql.Append(" [JXFDJ] = @JXFDJ , ");
                strSql.Append(" [ZCFDJ] = @ZCFDJ , ");
                strSql.Append(" [SBFDJ] = @SBFDJ , ");
                strSql.Append(" [GLFDJ] = @GLFDJ , ");
                strSql.Append(" [LRDJ] = @LRDJ , ");
                strSql.Append(" [FXDJ] = @FXDJ , ");
                strSql.Append(" [GFDJ] = @GFDJ , ");
                strSql.Append(" [SJDJ] = @SJDJ , ");
                strSql.Append(" [CJDJ] = @CJDJ , ");
                strSql.Append(" [JCDJ] = @JCDJ , ");
                strSql.Append(" [XHL] = @XHL , ");
                strSql.Append(" [ZJFHJ] = @ZJFHJ , ");
                strSql.Append(" [RGFHJ] = @RGFHJ , ");
                strSql.Append(" [CLFHJ] = @CLFHJ , ");
                strSql.Append(" [JXFHJ] = @JXFHJ , ");
                strSql.Append(" [ZCFHJ] = @ZCFHJ , ");
                strSql.Append(" [SBFHJ] = @SBFHJ , ");
                strSql.Append(" [GLFHJ] = @GLFHJ , ");
                strSql.Append(" [LRHJ] = @LRHJ , ");
                strSql.Append(" [FXHJ] = @FXHJ , ");
                strSql.Append(" [GFHJ] = @GFHJ , ");
                strSql.Append(" [SJHJ] = @SJHJ , ");
                strSql.Append(" [JCHJ] = @JCHJ , ");
                strSql.Append(" [CJHJ] = @CJHJ , ");
                strSql.Append(" [ZGJE] = @ZGJE , ");
                strSql.Append(" [JGJE] = @JGJE , ");
                strSql.Append(" [FBJE] = @FBJE , ");
                strSql.Append(" [FL] = @FL , ");
                strSql.Append(" [DECJ] = @DECJ , ");
                strSql.Append(" [JSJC] = @JSJC , ");
                strSql.Append(" [ZJFS] = @ZJFS , ");
                strSql.Append(" [QDBH] = @QDBH , ");
                strSql.Append(" [XMNR] = @XMNR , ");
                strSql.Append(" [XMTZZ] = @XMTZZ , ");
                strSql.Append(" [TYGS] = @TYGS , ");
                strSql.Append(" [ISTY] = @ISTY , ");
                strSql.Append(" [PBZD] = @PBZD , ");
                strSql.Append(" [YGJE] = @YGJE , ");
                strSql.Append(" [STATUS] = @STATUS , ");
                strSql.Append(" [ZDSC] = @ZDSC , ");
                strSql.Append(" [Key] = @Key , ");
                strSql.Append(" [PKey] = @PKey , ");
                strSql.Append(" [Deep] = @Deep , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [SSLB] = @SSLB ,  ");
                strSql.Append(" [DZBS] = True ,  ");
                strSql.Append(" [ID] = @ID  ");
                strSql.Append("   where [ID]=@ID and UnID=@UnID ");


                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBDATA) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 措施项目表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelMeasures.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.SetDZBS("update 措施项目表 set DZBS=True", p_tran);

            }
        }

        /// <summary>
        /// 更新安装增加费
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_IncreaseCosts(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 安装增加费(");
                strSql.Append("[UnID],[EnID],[QDID],[ZMID],[Name],[DH],[JSJC],[FJJS],[XS],[RGXS],[CLXS],[JXXS],[RGF],[CLF],[JXF],[HJ],[SSLB]");
                strSql.Append(") values (");
                strSql.Append("@UnID,@EnID,@QDID,@ZMID,@Name,@DH,@JSJC,@FJJS,@XS,@RGXS,@CLXS,@JXXS,@RGF,@CLF,@JXF,@HJ,@SSLB");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Increase) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 安装增加费 set ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [QDID] = @QDID , ");
                strSql.Append(" [ZMID] = @ZMID , ");
                strSql.Append(" [Name] = @Name , ");
                strSql.Append(" [DH] = @DH , ");
                strSql.Append(" [JSJC] = @JSJC , ");
                strSql.Append(" [FJJS] = @FJJS , ");
                strSql.Append(" [XS] = @XS , ");
                strSql.Append(" [RGXS] = @RGXS , ");
                strSql.Append(" [CLXS] = @CLXS , ");
                strSql.Append(" [JXXS] = @JXXS , ");
                strSql.Append(" [RGF] = @RGF , ");
                strSql.Append(" [CLF] = @CLF , ");
                strSql.Append(" [JXF] = @JXF , ");
                strSql.Append(" [HJ] = @HJ , ");
                strSql.Append(" [SSLB] = @SSLB  ");
                strSql.Append(" where ID=@ID and UnID=@UnID ");

                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Increase) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from 安装增加费 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelIncreaseCosts.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelIncreaseCosts.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新标准换算
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_StandardConversionSource(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 标准换算表(");
                strSql.Append("[EnID],[UnID],[SSLB],[QDID],[ZMID],[IFXZ],[DEH],[HSLB],[HSXX],[DJ_DW],[JBL_RGXS],[DEH_CLXS],[TZL_JXXS],[ZC],[SB],[XHLB],[FZ],[THZHC],[THWZFC],[HSXI],[ID]");
                strSql.Append(") values (");
                strSql.Append("@EnID,@UnID,@SSLB,@QDID,@ZMID,@IFXZ,@DEH,@HSLB,@HSXX,@DJ_DW,@JBL_RGXS,@DEH_CLXS,@TZL_JXXS,@ZC,@SB,@XHLB,@FZ,@THZHC,@THWZFC,@HSXI,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_StandardConversion) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 标准换算表 set ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [SSLB] = @SSLB , ");
                strSql.Append(" [QDID] = @QDID , ");
                strSql.Append(" [ZMID] = @ZMID , ");
                strSql.Append(" [IFXZ] = @IFXZ , ");
                strSql.Append(" [DEH] = @DEH , ");
                strSql.Append(" [HSLB] = @HSLB , ");
                strSql.Append(" [HSXX] = @HSXX , ");
                strSql.Append(" [DJ_DW] = @DJ_DW , ");
                strSql.Append(" [JBL_RGXS] = @JBL_RGXS , ");
                strSql.Append(" [DEH_CLXS] = @DEH_CLXS , ");
                strSql.Append(" [TZL_JXXS] = @TZL_JXXS , ");
                strSql.Append(" [ZC] = @ZC , ");
                strSql.Append(" [SB] = @SB , ");
                strSql.Append(" [XHLB] = @XHLB , ");
                strSql.Append(" [FZ] = @FZ , ");
                strSql.Append(" [THZHC] = @THZHC , ");
                strSql.Append(" [THWZFC] = @THWZFC , ");
                strSql.Append(" [HSXI] = @HSXI  ");
                strSql.Append(" where ID=@ID and UnID=@UnID ");

                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_StandardConversion) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = "delete from  标准换算表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelStandardConversion.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelStandardConversion.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新用途类别
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_YTLBSummary(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 用途类别表(");
                strSql.Append("[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS],[BDBH],[SSKLB],[DZBS],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@EnID,@UnID,@SSLB,@QDID,@ZMID,@YSBH,@YSMC,@YSDW,@YSXHL,@BH,@MC,@DW,@XHL,@LB,@DEDJ,@SCDJ,@JSDJ,@GCL,@IFZYCL,@ZCLB,@GGXH,@SDCLB,@SDCXS,@YTLB,@IFXZ,@IFSC,@IFFX,@IFSDSCDJ,@IFSDSL,@IFKFJ,@GLJBZ,@CTIME,@SLH,@SLDEHJ,@SLSCHJ,@CJ,@PP,@ZLDJ,@GYS,@CD,@CJBZ,@XGHSCDJ,@TZXS,@BDBH,@SSKLB,@DZBS,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_YTLBSummary) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 用途类别表 set ");
                strSql.Append("[PID]=@PID,");
                strSql.Append("[EnID]=@EnID,");
                strSql.Append("[UnID]=@UnID,");
                strSql.Append("[SSLB]=@SSLB,");
                strSql.Append("[QDID]=@QDID,");
                strSql.Append("[ZMID]=@ZMID,");
                strSql.Append("[YSBH]=@YSBH,");
                strSql.Append("[YSMC]=@YSMC,");
                strSql.Append("[YSDW]=@YSDW,");
                strSql.Append("[YSXHL]=@YSXHL,");
                strSql.Append("[BH]=@BH,");
                strSql.Append("[MC]=@MC,");
                strSql.Append("[DW]=@DW,");
                strSql.Append("[XHL]=@XHL,");
                strSql.Append("[LB]=@LB,");
                strSql.Append("[DEDJ]=@DEDJ,");
                strSql.Append("[SCDJ]=@SCDJ,");
                strSql.Append("[JSDJ]=@JSDJ,");
                strSql.Append("[GCL]=@GCL,");
                strSql.Append("[IFZYCL]=@IFZYCL,");
                strSql.Append("[ZCLB]=@ZCLB,");
                strSql.Append("[GGXH]=@GGXH,");
                strSql.Append("[SDCLB]=@SDCLB,");
                strSql.Append("[SDCXS]=@SDCXS,");
                strSql.Append("[YTLB]=@YTLB,");
                strSql.Append("[IFXZ]=@IFXZ,");
                strSql.Append("[IFSC]=@IFSC,");
                strSql.Append("[IFFX]=@IFFX,");
                strSql.Append("[IFSDSCDJ]=@IFSDSCDJ,");
                strSql.Append("[IFSDSL]=@IFSDSL,");
                strSql.Append("[IFKFJ]=@IFKFJ,");
                strSql.Append("[GLJBZ]=@GLJBZ,");
                strSql.Append("[CTIME]=@CTIME,");
                strSql.Append("[SLH]=@SLH,");
                strSql.Append("[SLDEHJ]=@SLDEHJ,");
                strSql.Append("[SLSCHJ]=@SLSCHJ,");
                strSql.Append("[CJ]=@CJ,");
                strSql.Append("[PP]=@PP,");
                strSql.Append("[ZLDJ]=@ZLDJ,");
                strSql.Append("[GYS]=@GYS,");
                strSql.Append("[CD]=@CD,");
                strSql.Append("[CJBZ]=@CJBZ,");
                strSql.Append("[XGHSCDJ]=@XGHSCDJ,");
                strSql.Append("[TZXS]=@TZXS,");
                strSql.Append("[BDBH]=@BDBH,");
                strSql.Append("[SSKLB]=@SSKLB,");
                strSql.Append("[DZBS]=@DZBS");
                strSql.Append(" where ID=@ID and UnID=@UnID ");
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_YTLBSummary) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除

                ///删除
                string dstr = "delete from  用途类别表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelYTLBSummary.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelYTLBSummary.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新用途类别(电子标书)
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_YTLBSummary_DZBS(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 用途类别表(");
                strSql.Append("[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS],[BDBH],[SSKLB],[DZBS],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@EnID,@UnID,@SSLB,@QDID,@ZMID,@YSBH,@YSMC,@YSDW,@YSXHL,@BH,@MC,@DW,@XHL,@LB,@DEDJ,@SCDJ,@JSDJ,@GCL,@IFZYCL,@ZCLB,@GGXH,@SDCLB,@SDCXS,@YTLB,@IFXZ,@IFSC,@IFFX,@IFSDSCDJ,@IFSDSL,@IFKFJ,@GLJBZ,@CTIME,@SLH,@SLDEHJ,@SLSCHJ,@CJ,@PP,@ZLDJ,@GYS,@CD,@CJBZ,@XGHSCDJ,@TZXS,@BDBH,@SSKLB,@DZBS,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_YTLBSummary) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 用途类别表 set ");
                strSql.Append("[PID]=@PID,");
                strSql.Append("[EnID]=@EnID,");
                strSql.Append("[UnID]=@UnID,");
                strSql.Append("[SSLB]=@SSLB,");
                strSql.Append("[QDID]=@QDID,");
                strSql.Append("[ZMID]=@ZMID,");
                strSql.Append("[YSBH]=@YSBH,");
                strSql.Append("[YSMC]=@YSMC,");
                strSql.Append("[YSDW]=@YSDW,");
                strSql.Append("[YSXHL]=@YSXHL,");
                strSql.Append("[BH]=@BH,");
                strSql.Append("[MC]=@MC,");
                strSql.Append("[DW]=@DW,");
                strSql.Append("[XHL]=@XHL,");
                strSql.Append("[LB]=@LB,");
                strSql.Append("[DEDJ]=@DEDJ,");
                strSql.Append("[SCDJ]=@SCDJ,");
                strSql.Append("[JSDJ]=@JSDJ,");
                strSql.Append("[GCL]=@GCL,");
                strSql.Append("[IFZYCL]=@IFZYCL,");
                strSql.Append("[ZCLB]=@ZCLB,");
                strSql.Append("[GGXH]=@GGXH,");
                strSql.Append("[SDCLB]=@SDCLB,");
                strSql.Append("[SDCXS]=@SDCXS,");
                strSql.Append("[YTLB]=@YTLB,");
                strSql.Append("[IFXZ]=@IFXZ,");
                strSql.Append("[IFSC]=@IFSC,");
                strSql.Append("[IFFX]=@IFFX,");
                strSql.Append("[IFSDSCDJ]=@IFSDSCDJ,");
                strSql.Append("[IFSDSL]=@IFSDSL,");
                strSql.Append("[IFKFJ]=@IFKFJ,");
                strSql.Append("[GLJBZ]=@GLJBZ,");
                strSql.Append("[CTIME]=@CTIME,");
                strSql.Append("[SLH]=@SLH,");
                strSql.Append("[SLDEHJ]=@SLDEHJ,");
                strSql.Append("[SLSCHJ]=@SLSCHJ,");
                strSql.Append("[CJ]=@CJ,");
                strSql.Append("[PP]=@PP,");
                strSql.Append("[ZLDJ]=@ZLDJ,");
                strSql.Append("[GYS]=@GYS,");
                strSql.Append("[CD]=@CD,");
                strSql.Append("[CJBZ]=@CJBZ,");
                strSql.Append("[XGHSCDJ]=@XGHSCDJ,");
                strSql.Append("[TZXS]=@TZXS,");
                strSql.Append("[BDBH]=@BDBH,");
                strSql.Append("[SSKLB]=@SSKLB,");
                strSql.Append("[DZBS]=@DZBS");
                strSql.Append(" where ID=@ID and UnID=@UnID ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_YTLBSummary) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除

                ///删除
                string dstr = "delete from  用途类别表 where UnID = @UnID and [ID] = @ID";
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@UnID", OleDbType.Integer),
                                                    new OleDbParameter("@ID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "ID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable ytlbTable = p_Unit.StructSource.ModelYTLBSummary.Copy();
                foreach (DataRow row in p_Unit.StructSource.ModelYTLBSummary.Rows)
                {
                    row["BDBH"] = "";
                }

                DataTable table = p_Unit.StructSource.ModelYTLBSummary.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.SetDZBS("update 用途类别表 set DZBS= True", p_tran);


                p_Unit.StructSource.ModelYTLBSummary.Rows.Clear();
                DataRow newRow;
                foreach (DataRow row in ytlbTable.Rows)
                {
                    newRow = p_Unit.StructSource.ModelYTLBSummary.NewRow();
                    newRow.BeginEdit();
                    newRow.ItemArray = row.ItemArray;
                    newRow.EndEdit();
                    p_Unit.StructSource.ModelYTLBSummary.Rows.Add(newRow);
                }
                p_Unit.StructSource.ModelYTLBSummary.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新汇总分析
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_Metaanalysis(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.MSDataTemp.IsChange)
                {
                    string sql = string.Format("delete from 汇总分析表 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = p_tran as OleDbTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    p_Unit.StructSource.ModelMetaanalysis.SetRowStateAsNew();
                    p_Unit.DataTemp.MSDataTemp.IsChange = false;
                }


                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 汇总分析表(");
                strSql.Append("[ParentID],[Number],[Feature],[Name],[Calculation],[Coefficient],[Remark],[Price],[EnID],[UnID],[ID]");
                strSql.Append(") values (");
                strSql.Append("@ParentID,@Number,@Feature,@Name,@Calculation,@Coefficient,@Remark,@Price,@EnID,@UnID,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Metaanalysis) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 汇总分析表 set ");
                strSql.Append(" [ParentID] = @ParentID , ");
                strSql.Append(" [Number] = @Number , ");
                strSql.Append(" [Feature] = @Feature , ");
                strSql.Append(" [Name] = @Name , ");
                strSql.Append(" [Calculation] = @Calculation , ");
                strSql.Append(" [Coefficient] = @Coefficient , ");
                strSql.Append(" [Remark] = @Remark , ");
                strSql.Append(" [Price] = @Price , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [ID] = @ID ");
                strSql.Append(" where ID=@ID and UnID=@UnID ");
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Metaanalysis) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = string.Format("delete from 汇总分析表 where [ID] = @ID and UnID =@UnID");
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@ID", OleDbType.Integer),
                                                    new OleDbParameter("@UnID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "ID";
                parameters[1].SourceColumn = "UnID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Unit.StructSource.ModelMetaanalysis.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelMetaanalysis.AcceptChanges();
            }
        }

        /// <summary>
        /// 其他项目
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_OtherProject(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.ODataTemp.IsChange)
                {
                    string sql = string.Format("delete from 其他项目表 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = p_tran as OleDbTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    p_Unit.StructSource.ModelOtherProject.SetRowStateAsNew();
                    p_Unit.DataTemp.ODataTemp.IsChange = false;
                }


                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 其他项目表(");
                strSql.Append("[ParentID],[Number],[Name],[Unit],[Quantities],[Calculation],[Unitprice],[Combinedprice],[Remark],[Feature],[beiyong],[IsSys],[jsdJ],[cjdj],[cjhj],[Coefficient],[EnID],[UnID],[Key],[PKey],[DZBS],[id]");
                strSql.Append(") values (");
                strSql.Append("@ParentID,@Number,@Name,@Unit,@Quantities,@Calculation,@Unitprice,@Combinedprice,@Remark,@Feature,@beiyong,@IsSys,@jsdJ,@cjdj,@cjhj,@Coefficient,@EnID,@UnID,@Key,@PKey,@DZBS,@id");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_OtherProject) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 其他项目表 set ");
                strSql.Append(" [ParentID] = @ParentID , ");
                strSql.Append(" [Number] = @Number , ");
                strSql.Append(" [Name] = @Name , ");
                strSql.Append(" [Unit] = @Unit , ");
                strSql.Append(" [Quantities] = @Quantities , ");
                strSql.Append(" [Calculation] = @Calculation , ");
                strSql.Append(" [Unitprice] = @Unitprice , ");
                strSql.Append(" [Combinedprice] = @Combinedprice , ");
                strSql.Append(" [Remark] = @Remark , ");
                strSql.Append(" [Feature] = @Feature , ");
                strSql.Append(" [beiyong] = @beiyong , ");
                strSql.Append(" [IsSys] = @IsSys , ");
                strSql.Append(" [jsdJ] = @jsdJ , ");
                strSql.Append(" [cjdj] = @cjdj , ");
                strSql.Append(" [cjhj] = @cjhj , ");
                strSql.Append(" [Coefficient] = @Coefficient , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [Key] = @Key  ,");
                strSql.Append(" [PKey] = @PKey , ");
                strSql.Append(" [DZBS] = @DZBS,  ");
                strSql.Append(" [id] = @id  ");
                strSql.Append(" where id=@id and UnID=@UnID ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_OtherProject) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = string.Format("delete from 其他项目表 where [ID] = @ID and UnID =@UnID");
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@ID", OleDbType.Integer),
                                                    new OleDbParameter("@UnID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "ID";
                parameters[1].SourceColumn = "UnID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                DataTable table = p_Unit.StructSource.ModelOtherProject;
                if (table != null)
                {
                    DataRow[] rows = table.Select("ParentID = 1");
                    foreach (DataRow row in rows)
                    {
                        Console.WriteLine("Current Value:" + row["Remark"]+"---"+row["UnID"]); 
                        if (row["Number"].ToString().Equals("F1.1") || row["Number"].ToString().Equals("F1.2"))
                        {
                            row["Remark"] = "属于招标人部分";
                        }
                        else
                        {
                            row["Remark"] = "属于投标人部分";
                        }
                        Console.WriteLine("Changed Value:" + row["Remark"] + "---" + row["UnID"]); 
                    }
                    rows = table.Select("Calculation = '0' or Calculation = '0.00'");
                    foreach (DataRow row in rows)
                    {
                        row["Calculation"] = "";
                    }

                    if (table != null)
                    {
                        try
                        {
                            int count = da.Update(table);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }


                p_Unit.StructSource.ModelOtherProject.AcceptChanges();
                foreach (DataRow row in p_Unit.StructSource.ModelOtherProject.Rows)
                {
                    Console.WriteLine("Full scan Value:" + row["Remark"] + "---" + row["UnID"]); 
                }

            }
        }

        /// <summary>
        /// 其他项目
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_OtherProject_DZBS(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.ODataTemp.IsChange)
                {
                    string sql = string.Format("delete from 其他项目表 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = p_tran as OleDbTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    p_Unit.StructSource.ModelOtherProject.SetRowStateAsNew();
                    p_Unit.DataTemp.ODataTemp.IsChange = false;
                }



                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 其他项目表(");
                strSql.Append("[ParentID],[Number],[Name],[Unit],[Quantities],[Calculation],[Unitprice],[Combinedprice],[Remark],[Feature],[beiyong],[IsSys],[jsdJ],[cjdj],[cjhj],[Coefficient],[EnID],[UnID],[Key],[PKey],[DZBS],[id]");
                strSql.Append(") values (");
                strSql.Append("@ParentID,@Number,@Name,@Unit,@Quantities,@Calculation,@Unitprice,@Combinedprice,@Remark,@Feature,@beiyong,@IsSys,@jsdJ,@cjdj,@cjhj,@Coefficient,@EnID,@UnID,@Key,@PKey,True,@id");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_OtherProject) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 其他项目表 set ");
                strSql.Append(" [ParentID] = @ParentID , ");
                strSql.Append(" [Number] = @Number , ");
                strSql.Append(" [Name] = @Name , ");
                strSql.Append(" [Unit] = @Unit , ");
                strSql.Append(" [Quantities] = @Quantities , ");
                strSql.Append(" [Calculation] = @Calculation , ");
                strSql.Append(" [Unitprice] = @Unitprice , ");
                strSql.Append(" [Combinedprice] = @Combinedprice , ");
                strSql.Append(" [Remark] = @Remark , ");
                strSql.Append(" [Feature] = @Feature , ");
                strSql.Append(" [beiyong] = @beiyong , ");
                strSql.Append(" [IsSys] = @IsSys , ");
                strSql.Append(" [jsdJ] = @jsdJ , ");
                strSql.Append(" [cjdj] = @cjdj , ");
                strSql.Append(" [cjhj] = @cjhj , ");
                strSql.Append(" [Coefficient] = @Coefficient , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [Key] = @Key  ,");
                strSql.Append(" [PKey] = @PKey , ");
                strSql.Append(" [DZBS] = True,  ");
                strSql.Append(" [id] = @id  ");
                strSql.Append(" where id=@id and UnID=@UnID ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_OtherProject) as OleDbCommand; ;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = string.Format("delete from 其他项目表 where [ID] = @ID and UnID =@UnID");
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@ID", OleDbType.Integer),
                                                    new OleDbParameter("@UnID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "ID";
                parameters[1].SourceColumn = "UnID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                DataTable table = p_Unit.StructSource.ModelOtherProject.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                this.SetDZBS("update 其他项目表 set DZBS=True where Remark='属于招标人部分' or ParentID in(select id from 其他项目表 where Remark = '属于招标人部分')", p_tran);
            }
        }

        /// <summary>
        /// 工程取费
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_UnitFree(_UnitProject p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //如果更换了模板 此处处理全模板替换
                if (p_Unit.DataTemp.YSGCQFDataTemp.IsChange)
                {
                    string sql = string.Format("delete from 工程取费 where UnID = {0}", p_Unit.ID);

                    using (OleDbCommand cmd = this.Conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = p_tran as OleDbTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    p_Unit.StructSource.ModelUnitFee.SetRowStateAsNew();
                    p_Unit.DataTemp.YSGCQFDataTemp.IsChange = false;
                }

                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 工程取费(");
                strSql.Append("[EnID],[UnID],[GCLB],[DEHFW],[GLFFL],[LRFL],[FXTBFL],[FXBDFL],[GLFTBJSJC],[GLFBDJSJC],[LRFTBJSJC],[LRFBDJSJC],[FXFTBJSJC],[FXFBDJSJC],[IFSFHZ],[ID]");
                strSql.Append(") values (");
                strSql.Append("@EnID,@UnID,@GCLB,@DEHFW,@GLFFL,@LRFL,@FXTBFL,@FXBDFL,@GLFTBJSJC,@GLFBDJSJC,@LRFTBJSJC,@LRFBDJSJC,@FXFTBJSJC,@FXFBDJSJC,@IFSFHZ,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_UnitFree) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 工程取费 set ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [UnID] = @UnID , ");
                strSql.Append(" [GCLB] = @GCLB , ");
                strSql.Append(" [DEHFW] = @DEHFW , ");
                strSql.Append(" [GLFFL] = @GLFFL , ");
                strSql.Append(" [LRFL] = @LRFL , ");
                strSql.Append(" [FXTBFL] = @FXTBFL , ");
                strSql.Append(" [FXBDFL] = @FXBDFL , ");
                strSql.Append(" [GLFTBJSJC] = @GLFTBJSJC , ");
                strSql.Append(" [GLFBDJSJC] = @GLFBDJSJC , ");
                strSql.Append(" [LRFTBJSJC] = @LRFTBJSJC , ");
                strSql.Append(" [LRFBDJSJC] = @LRFBDJSJC , ");
                strSql.Append(" [FXFTBJSJC] = @FXFTBJSJC , ");
                strSql.Append(" [FXFBDJSJC] = @FXFBDJSJC , ");
                strSql.Append(" [IFSFHZ] = @IFSFHZ , ");
                strSql.Append(" [ID] = @ID  ");
                strSql.Append(" where ID=@ID and UnID=@UnID ");

                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_UnitFree) as OleDbCommand; ;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = string.Format("delete from 工程取费 where [ID] = @ID and UnID =@UnID");
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@ID", OleDbType.Integer),
                                                    new OleDbParameter("@UnID", OleDbType.Integer)
                                              };
                parameters[0].SourceColumn = "ID";
                parameters[1].SourceColumn = "UnID";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                DataTable table = p_Unit.StructSource.ModelUnitFee.GetChanges();
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelUnitFee.AcceptChanges();
            }
        }

        /// <summary>
        /// 单位工程变量
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        private void UpDate_Variable(_COBJECTS p_Unit, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 变量表(");
                strSql.Append("[Key],[Value],[Remark],[Length],[FYLB],[Sort],[Type],[ISDE],[EnID],[ID]");
                strSql.Append(") values (");
                strSql.Append("@Key,@Value,@Remark,@Length,@FYLB,@Sort,@Type,@ISDE,@EnID,@ID");
                strSql.Append(")");

                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Variable) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                strSql = new StringBuilder();
                strSql.Append("update 变量表 set ");
                strSql.Append(" [Key] = @Key , ");
                strSql.Append(" [Value] = @Value , ");
                strSql.Append(" [Remark] = @Remark , ");
                strSql.Append(" [Length] = @Length , ");
                strSql.Append(" [FYLB] = @FYLB , ");
                strSql.Append(" [Sort] = @Sort , ");
                strSql.Append(" [Type] = @Type , ");
                strSql.Append(" [ISDE] = @ISDE , ");
                strSql.Append(" [EnID] = @EnID , ");
                strSql.Append(" [ID] = @ID ");
                strSql.Append(" where [ID]=@ID and [Key]=@Key and [Type]=@Type   ");


                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_Variable) as OleDbCommand; ;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;

                ///删除
                string dstr = string.Format("delete from 变量表 where [ID] = @ID and [Key]=@Key and [Type]=@Type");
                OleDbParameter[] parameters = {
                                                    new OleDbParameter("@ID", OleDbType.Integer),
                                                    new OleDbParameter("@Key", OleDbType.VarChar),
                                                    new OleDbParameter("@Type", OleDbType.VarChar),
                                              };
                parameters[0].SourceColumn = "ID";
                parameters[1].SourceColumn = "Key";
                parameters[2].SourceColumn = "Type";
                da.DeleteCommand = this.CreateCommand(dstr.ToString(), parameters) as OleDbCommand;
                da.DeleteCommand.Transaction = p_tran as OleDbTransaction;

                DataTable table = p_Unit.StructSource.ModelProjVariable.GetChanges();

                da.ContinueUpdateOnError = true;
                if (table != null)
                {
                    try
                    {
                        int count = da.Update(table);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                p_Unit.StructSource.ModelProjVariable.AcceptChanges();
            }
        }

        #endregion

        #region -----------------------导入xml文件的时候调用的方法-----------------------

        public void BeginSave()
        {

        }

        /// <summary>
        /// 保存指定的单位工程数据
        /// </summary>
        /// <param name="unit"></param>
        public void SaveUnitXml(_UnitProject unit, IDbTransaction tran)
        {
            //this.OpenConnection();
            //using (IDbTransaction tran = this.Conn.BeginTransaction())
            {

                this.Save(unit, tran);

                unit.DataTemp.YSZMQFDataTemp.IsChange = false;
                //tran.Commit();
                //this.CloseConnection();
            }
        }

        /// <summary>
        /// 保存项目
        /// </summary>
        public void SaveProjXml(IDbTransaction p_Tran)
        {

            {
                this.UpDate_ProjInfomation(p_Tran);
                this.Save_Proj(p_Tran);
                //保存项目变量表
                this.Save_ProjVariable(p_Tran);
            }
        }

        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 释放当前资源
        /// </summary>
        public void Dispose()
        {

            this.Close();
            this.mTable = null;
            this.Conn = null;
            System.GC.Collect();
        }

        #endregion
    }
}
