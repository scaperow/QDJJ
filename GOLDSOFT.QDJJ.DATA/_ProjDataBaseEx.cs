/*
 项目下的独立数据操作(事务由业务访问对象开启)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.DATA
{
    /// <summary>
    /// 项目数据访问的扩展函数
    /// </summary>
    public partial class _ProjDataBase
    {
        /// <summary>
        /// 插入分部分项
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_SubData(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_SUBDATA_Value(p_row));
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 分部分项表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],RGFJC,CLFJC,JXFJC,[DZBS],[ID],[ZYLB]");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@RGFJC,@CLFJC,@JXFJC,@DZBS,@ID,@ZYLB");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
                
            }
        }

        /// <summary>
        /// 插入工料机表
        /// </summary>
        /// <param name="p_row"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_QuantityData(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_QUANTITY_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 工料机表(");
                strSql.Append("[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[SSKLB],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@EnID,@UnID,@SSLB,@QDID,@ZMID,@YSBH,@YSMC,@YSDW,@YSXHL,@BH,@MC,@DW,@XHL,@LB,@DEDJ,@SCDJ,@JSDJ,@GCL,@IFZYCL,@ZCLB,@GGXH,@SDCLB,@SDCXS,@YTLB,@IFXZ,@IFSC,@IFFX,@IFSDSCDJ,@IFSDSL,@IFKFJ,@SSKLB,@GLJBZ,@CTIME,@SLH,@SLDEHJ,@SLSCHJ,@CJ,@PP,@ZLDJ,@GYS,@CD,@CJBZ,@XGHSCDJ,@TZXS,@ID");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update_Sql_QuantityData(string BH, UseType type, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append(string.Format("update 工料机表 set YTLB='{0}'where BH='{1}'", type, BH));
               
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新用途类别
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_YTLBSummary(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_YTLBSummary_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 用途类别表(");
                strSql.Append("[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS],[BDBH],[SSKLB],[DZBS],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@EnID,@UnID,@SSLB,@QDID,@ZMID,@YSBH,@YSMC,@YSDW,@YSXHL,@BH,@MC,@DW,@XHL,@LB,@DEDJ,@SCDJ,@JSDJ,@GCL,@IFZYCL,@ZCLB,@GGXH,@SDCLB,@SDCXS,@YTLB,@IFXZ,@IFSC,@IFFX,@IFSDSCDJ,@IFSDSL,@IFKFJ,@GLJBZ,@CTIME,@SLH,@SLDEHJ,@SLSCHJ,@CJ,@PP,@ZLDJ,@GYS,@CD,@CJBZ,@XGHSCDJ,@TZXS,@BDBH,@SSKLB,@DZBS,@ID");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 插入措施项目
        /// </summary>
        /// <param name="p_row"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_MeasuresData(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_SUBDATA_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 措施项目表(");
                strSql.Append("[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB],RGFJC,CLFJC,JXFJC,[DZBS],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@PPARENTID,@CPARENTID,@FPARENTID,@XH,@XMBM,@OLDXMBM,@XMMC,@DW,@TX,@LB,@JCBJ,@FHBJ,@ZYQD,@SDDJ,@JBHZ,@XMTZ,@GCLJSS,@ZJWZ,@JX,@SC,@YGLB,@QFSZ,@BEIZHU,@LibraryName,@LY,@SDQD,@SFFB,@HL,@GCL,@ZJTJ,@ZHDJ,@ZHHJ,@ZJFDJ,@RGFDJ,@CLFDJ,@JXFDJ,@ZCFDJ,@SBFDJ,@GLFDJ,@LRDJ,@FXDJ,@GFDJ,@SJDJ,@CJDJ,@JCDJ,@XHL,@ZJFHJ,@RGFHJ,@CLFHJ,@JXFHJ,@ZCFHJ,@SBFHJ,@GLFHJ,@LRHJ,@FXHJ,@GFHJ,@SJHJ,@JCHJ,@CJHJ,@ZGJE,@JGJE,@FBJE,@FL,@DECJ,@JSJC,@ZJFS,@QDBH,@XMNR,@XMTZZ,@TYGS,@ISTY,@PBZD,@YGJE,@STATUS,@ZDSC,@Key,@PKey,@Deep,@Sort,@UnID,@EnID,@SSLB,@RGFJC,@CLFJC,@JXFJC,@DZBS,@ID");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 插入汇总分析
        /// </summary>
        /// <param name="p_Table"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_Metaanalysis(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_Metaanalysis_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 汇总分析表(");
                strSql.Append("[ParentID],[Number],[Feature],[Name],[Calculation],[Coefficient],[Remark],[Price],[EnID],[UnID],[ID]");
                strSql.Append(") values (");
                strSql.Append("@ParentID,@Number,@Feature,@Name,@Calculation,@Coefficient,@Remark,@Price,@EnID,@UnID,@ID");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 工程取费
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_UnitFree(DataTable p_Table, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
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
                DataTable table = p_Table.GetChanges();
                if (table != null)
                {
                    int count = da.Update(table);
                }
                p_Table.AcceptChanges();
            }
        }

        /// <summary>
        /// 工程取费
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_PSubheadingsFee(DataTable p_Table, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 参数子目取费表(");
                strSql.Append("[EnID],[UnID],[SSLB],[QDID],[ZMID],[Sort],[YYH],[MC],[BDS],[SCJJC],[TBJSJC],[BDJSJC],[FL],[TBJE],[BDJE],[FYLB],[BZ],[STATUS],[JSSX],[ID]");
                strSql.Append(") values (");
                strSql.Append("@EnID,@UnID,@SSLB,@QDID,@ZMID,@Sort,@YYH,@MC,@BDS,@SCJJC,@TBJSJC,@BDJSJC,@FL,@TBJE,@BDJE,@FYLB,@BZ,@STATUS,@JSSX,@ID");
                strSql.Append(")");
                //插入记录
                da.InsertCommand = this.CreateCommand(strSql.ToString(), PARAMS_PROJ_SUBFREEDATA) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                DataTable table = p_Table.GetChanges();
                if (table != null)
                {
                    int count = da.Update(table);
                }
                p_Table.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新子目取费表
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_SubheadingsFee(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_SUBFREEDATA_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 子目取费表(");
                strSql.Append("[EnID],[UnID],[SSLB],[QDID],[ZMID],[Sort],[YYH],[MC],[BDS],[SCJJC],[TBJSJC],[BDJSJC],[FL],[TBJE],[BDJE],[FYLB],[BZ],[STATUS],[JSSX],[ID],[QFLB]");
                strSql.Append(") values (");
                strSql.Append("@EnID,@UnID,@SSLB,@QDID,@ZMID,@Sort,@YYH,@MC,@BDS,@SCJJC,@TBJSJC,@BDJSJC,@FL,@TBJE,@BDJE,@FYLB,@BZ,@STATUS,@JSSX,@ID,@QFLB");
                strSql.Append(")"); 
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }

        }

         /// <summary>
        /// 其他项目
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_OtherProject(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_OtherProject_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 其他项目表(");
                strSql.Append("[ParentID],[Number],[Name],[Unit],[Quantities],[Calculation],[Unitprice],[Combinedprice],[Remark],[Feature],[beiyong],[IsSys],[jsdJ],[cjdj],[cjhj],[Coefficient],[EnID],[UnID],[Key],[PKey],[DZBS],[id]");
                strSql.Append(") values (");
                strSql.Append("@ParentID,@Number,@Name,@Unit,@Quantities,@Calculation,@Unitprice,@Combinedprice,@Remark,@Feature,@beiyong,@IsSys,@jsdJ,@cjdj,@cjhj,@Coefficient,@EnID,@UnID,@Key,@PKey,@DZBS,@id");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// 保存基础信息（1条记录）
        /// </summary>
        /// <param name="p_tran"></param>
        public virtual void Insert_ProjInfomation(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {
                OleDbParameter[] iparameters = {
                                                    new OleDbParameter("@Key", OleDbType.VarChar),
                                                    new OleDbParameter("@Value", OleDbType.VarChar),
                                              };
                iparameters[0].Value = p_row["Key"];
                iparameters[1].Value = p_row["Value"];
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(iparameters);
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 基础表 ([Key],[Value]) values (@Key,@Value)");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 保存基础信息
        /// </summary>
        /// <param name="p_tran"></param>
        public virtual void UpDate_ProjInfomation(DataTable p_Table,IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                OleDbParameter[] iparameters = {
                                                    new OleDbParameter("@Key", OleDbType.VarChar),
                                                    new OleDbParameter("@Value", OleDbType.VarChar),
                                              };
                iparameters[0].SourceColumn = "Key";
                iparameters[1].SourceColumn = "Value";
                OleDbParameter[] uparameters = {
                                                    new OleDbParameter("@Key", OleDbType.VarChar),
                                                    new OleDbParameter("@Value", OleDbType.VarChar),
                                              };
                uparameters[0].SourceColumn = "Key";
                uparameters[1].SourceColumn = "Value";


                //新增
                string sql = "insert into 基础表 ([Key],[Value]) values (@Key,@Value)";

                //插入记录
                da.InsertCommand = this.CreateCommand(sql, iparameters) as OleDbCommand;
                da.InsertCommand.Transaction = p_tran as OleDbTransaction;
                #region -------------UpDate SQl ---------------
                sql = "update 基础表 set [key] = @Key,[Value] = @Value where [key] = @Key";

                //string ups = " update 分部分项表 set [XMMC] = @XMMC  where ID=@ID and UnID=@UnID";
                #endregion -------------UpDate SQl ---------------
                //更新记录
                da.UpdateCommand = this.CreateCommand(sql, uparameters) as OleDbCommand;
                da.UpdateCommand.Transaction = p_tran as OleDbTransaction;
                ///删除
                string dstr = "delete from 基础表 where Key = @Key";
                OleDbParameter[] dp = {
                                                    new OleDbParameter("@Key", OleDbType.Integer)
                                              };
                dp[0].SourceColumn = "Key";
                da.DeleteCommand = this.CreateCommand(dstr, dp) as OleDbCommand;
                DataTable table = p_Table.GetChanges();
                if (table != null)
                {
                    int count = da.Update(table);
                }
                //this.Current.StructSource.ModelInfomation.AcceptChanges();
            }
        }
        public virtual void UpDate_Project(IDbTransaction p_tran)
        {
            this.UpDate_ProjInfomation(p_tran);
            //保存招标信息
            this.UpDate_BiddingInformation(p_tran);
            //保存投标信息
            this.UpDate_TenderInformation(p_tran);
            this.Save_Proj(p_tran);
        }
        /// <summary>
        /// 保存基础信息（1条记录）
        /// </summary>
        /// <param name="p_tran"></param>
        public virtual void Insert_Project(DataRow p_row, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand())
            {              
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.Parameters.AddRange(PARAMS_PROJ_UPDATE_Value(p_row));
                //新增
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into 项目结构表(");
                strSql.Append("[PID],[Name],[CODE],[QDGZ],[DEGZ],[PGCDD],[PJFCX],[PNSDD],[CREATOR],[EDITOR],[Sort],[Deep],[NodeName],[PlaitNo],[ReviewName],[PlaitName],[ProType],[PrfType],[Remark],[QDLibName],[DELibName],[TJLibName],[FISTDATETIME],[EDITDATETIME],[PlaitDate],[ReviewDate],[Key],[PKey],[IndexImage],[State],[ID]");
                strSql.Append(") values (");
                strSql.Append("@PID,@Name,@CODE,@QDGZ,@DEGZ,@PGCDD,@PJFCX,@PNSDD,@CREATOR,@EDITOR,@Sort,@Deep,@NodeName,@PlaitNo,@ReviewName,@PlaitName,@ProType,@PrfType,@Remark,@QDLibName,@DELibName,@TJLibName,@FISTDATETIME,@EDITDATETIME,@PlaitDate,@ReviewDate,@Key,@PKey,@ImageIndex,@State,@ID");
                strSql.Append(")");
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
