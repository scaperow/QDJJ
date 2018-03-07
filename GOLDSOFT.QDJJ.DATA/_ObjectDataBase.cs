/*
   实际操作对象基础类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Factory.DataBaseFactory;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using GOLDSOFT.QDJJ.DATA.Properties;
using System.Data.OleDb;
using ZiboSoft.Commons.Common;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace GOLDSOFT.QDJJ.DATA
{
    public class _ObjectDataBase 
    {

        public OleDbTransaction MyTran = null;
        /// <summary>
        /// 通知单位工程赋值加密锁号等信息
        /// </summary>
        /// <param name="sender"></param>
        public delegate void OnSetKeyHandler(_COBJECTS sender);
        /// <summary>
        /// 通知单位工程赋值加密锁号等信息
        /// </summary>
        /// <param name="sender"></param>
        public event OnSetKeyHandler SetKey;
        /// <summary>
        /// 通知单位工程赋值加密锁号等信息
        /// </summary>
        /// <param name="sender"></param>
        public void OnSetKey(_COBJECTS sender)
        {
            if (this.SetKey != null) this.SetKey(sender);
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public OleDbTransaction BeginTran()
        {
            this.MyTran = this.Conn.BeginTransaction();
            return MyTran;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTran()
        {
            if (this.MyTran != null)
            {
                this.MyTran.Commit();
                this.MyTran = null;
            }
        }

        /// <summary>
        /// 回滚事件
        /// </summary>
        public void RollBackTran()
        {
            if (this.MyTran != null)
            {
                this.MyTran.Rollback();
                this.MyTran = null;
            }
        }

        /// <summary>
        /// 链接对象
        /// </summary>
        public OleDbConnection Conn;

        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnString = string.Empty;

        /// <summary>
        /// 开启链接
        /// </summary>
        public void OpenConnection()
        {
            if (this.Conn.State == ConnectionState.Closed)
            {
                this.Conn.Open();
            }
            //Conn = new OleDbConnection(ConnString);
            //this.Conn.Open();
        }

        /// <summary>
        /// 开启链接
        /// </summary>
        public void CloseConnection()
        {
            if(this.Conn.State != ConnectionState.Closed)
                this.Conn.Close();
            
        }

        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="p_Table"></param>
        public void FillDataSet(string sql,DataTable p_Table)
        {
            try
            {
                if (p_Table == null) p_Table = new DataTable();
                if (p_Table.Rows.Count > 0)
                {
                    string strWhere = sql.Substring(sql.ToLower().IndexOf(" where ") + 7);
                    DataRow[] rows = p_Table.Select(strWhere);
                    foreach (DataRow row in rows)
                    {
                        p_Table.Rows.Remove(row);
                    }
                }
                using (OleDbDataAdapter da = new OleDbDataAdapter(sql, Conn))
                {
                    if (this.MyTran != null)
                    {
                        da.SelectCommand.Transaction = this.MyTran;
                    }
                    da.Fill(p_Table);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

        }

        public DataTable FillTable(string sql, IDbTransaction p_tran)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(sql, Conn))
            {
                DataSet ds = new DataSet();
                OleDbCommand cmd = this.Conn.CreateCommand() as OleDbCommand;
                cmd.Connection = this.Conn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Dispose();

                if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
                else
                    return null;
            }

        }

        /// <summary>
        /// 保存为电子标书的时候调用
        /// </summary>
        /// <param name="p_tran"></param>
        public void ExecuteSql(string sql, IDbTransaction p_tran)
        {
            using (OleDbCommand cmd = this.Conn.CreateCommand() as OleDbCommand)
            {
                cmd.Connection = this.Conn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = p_tran as OleDbTransaction;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行一条Sql语句(不带事务)
        /// </summary>
        /// <param name="sql"></param>
        public void ExecuteSql(string sql,OleDbParameter[] p_Params)
        {
            using (OleDbCommand cmd = Conn.CreateCommand())
            {
                if (p_Params != null)
                {
                    if (p_Params.Length > 0)
                    {
                        cmd.Parameters.AddRange(p_Params);
                    }
                }
                if (this.MyTran != null)
                {
                    cmd.Transaction = MyTran;
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        public object ExecuteScalar(string sql)
        {
            using (OleDbCommand cmd = Conn.CreateCommand())
            {
                if (this.MyTran != null)
                {
                    cmd.Transaction = MyTran;
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 创建Command命令
        /// </summary>
        /// <param name="?"></param>
        public OleDbCommand CreateCommand(string sql,OleDbParameter[] p_Params)
        {
            OleDbCommand cmd = Conn.CreateCommand();
            if (this.MyTran != null)
            {
                cmd.Transaction = MyTran;
            }
            if (p_Params != null)
            {
                if (p_Params.Length > 0)
                {
                    cmd.Parameters.AddRange(p_Params);
                }
            }
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        

        public _ObjectDataBase(string conString)
        {
            ConnString = conString;
            if (Conn == null)
            {
                Conn = new OleDbConnection(ConnString);
            }
            try
            {
                Conn.Open();

            }
            catch (Exception ex)
            {
                if (Conn.State != ConnectionState.Closed)
                    Conn.Close();
                throw ex;
            }
        }
       
        /// <summary>
        /// 原始字节数
        /// </summary>
        public static byte[] GetOriginalByte
        {
            get
            {
                byte[] bb = new byte[16];
                int i =0;
                foreach (byte b in Resources.项目文件)
                {
                    if (i > 15) break;
                    bb[i] = b;
                    i++;
                }
                return bb;

            }
        }

        /// <summary>
        /// 创建文件对象(静态方法)
        /// </summary>
        public static void CreateFile(_COBJECTS p_Info)
        {
            ToolKit.GetDirectoryInfo(p_Info.Files.DirName);
            using (FileStream stream = new FileStream(p_Info.Files.FullName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                stream.Write(Resources.项目文件, 0, Resources.项目文件.Length);
                stream.Close();
            }
        }

        /// <summary>
        /// 创建文件对象(静态方法)
        /// </summary>
        public static void CreateFile(System.IO.FileInfo p_File)
        {
            ToolKit.GetDirectoryInfo(p_File.DirectoryName);
            using (FileStream stream = new FileStream(p_File.FullName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                stream.Write(Resources.项目文件, 0, Resources.项目文件.Length);
                stream.Close();
            }
        }

        /// <summary>
        /// 新的数据文件（此对象仅在打开 新建时候有值）
        /// </summary>
        private _COBJECTS m_Current = null;

        public _COBJECTS Current
        {
            get
            {
                return this.m_Current;
            }
        }


        /// <summary>
        /// 打开资源
        /// </summary>
        public virtual void Open(_COBJECTS p_Info)
        {
            this.m_Current = p_Info;
           //打开的时候还原数据库对象
            /*using (FileStream stream = new FileStream(this.Current.Files.FullName, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                
                stream.Write(_ObjectDataBase.GetOriginalByte, 0, 16);
                //stream.Write(Resources.项目文件, 16, Resources.项目文件.Length - 16);
                stream.Close();
            }*/
        }

        /// <summary>
        /// 关闭资源
        /// </summary>
        public virtual void Close()
        {
            if (this.Conn != null)
            {
                //this.Conn = null;
                this.MyTran = null;
                this.Conn.Dispose();
                System.GC.SuppressFinalize(this.Conn);
                System.GC.SuppressFinalize(this);
                System.GC.Collect();
            }
            
            

            //ABC:if (IsUse(this.Current.Files.FullName))
            //{
                //重写文件
                /*using (FileStream stream = new FileStream(this.Current.Files.FullName, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    byte[] b = Encoding.Default.GetBytes("清单计价 Ver 1.0");
                    stream.Write(b, 0, 16);
                    stream.Close();
                }*/
            //}
            //else
            //{
            //    goto ABC;
            //}
        }

        [DllImport("kernel32.dll")]  
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);  
        [DllImport("kernel32.dll")]  
        public static extern bool CloseHandle(IntPtr hObject);  
        public const int OF_READWRITE = 2;  
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);  
        
        static public bool IsUse(string p_FileName)  
        {  
            //文件如果不存在直接返回true
            FileInfo file = new FileInfo(p_FileName);
            if(!file.Exists) return true;

            string vFileName = p_FileName;  
            IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);  
            if (vHandle == HFILE_ERROR)  
            {  
                
                return false;  
            }  
            CloseHandle(vHandle);

            return true;
        }
        /// <summary>
        /// 此方法被重写
        /// （仅在第一次创建项目时候添加此方法）已经创建了数据文件此方法用于创建数据的的时候初始化数据库数据
        /// </summary>
        /// <param name="?"></param>
        public virtual void Create()
        {
            this.OpenConnection();
            //this.Conn.Open();
            //此对象肯定是项目
            _COBJECTS p_Info = this.m_Current; ;
            //默认添加当前项目基础数据到数据表
            string sql = "insert into 项目结构表 (Name,QDGZ,DEGZ,CODE,PGCDD,PJFCX,PNSDD,DEEP,NODENAME,PID,JMSH,JQH,[Time],[Key],PKey) values (@Name,@QDGZ,@DEGZ,@CODE,@PGCDD,@PJFCX,@PNSDD,@DEEP,@NODENAME,@PID,@JMSH,@JQH,@Time,@Key,@PKey)";

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
                new OleDbParameter("@Time", OleDbType.VarChar),
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
            param[12].Value = p_Info.Time;
            param[13].Value = p_Info.Key;
            param[14].Value = p_Info.PKey;

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
                this.m_Current.ID = ToolKit.ParseInt(obj);
                this.CommitTran();
            }
            this.Conn.Close();
            this.CloseConnection();
        }


        /// <summary>
        /// 创建项目的时候自动创建一条项目信息
        /// </summary>
        private void createProjInformation()
        {
            //默认添加当前项目基础数据到数据表
            string sql = "insert into 单位工程(PID,[OBJECT]) values (@PID,@OBJECT);";
            OleDbParameter[] param = new OleDbParameter[]
            {
                new OleDbParameter("@PID", OleDbType.VarChar,100),
                new OleDbParameter("@OBJECT", OleDbType.Binary)
            };
            param[0].Value = this.Current.ID;
            param[1].Value = this.GetByteObject(this.Current.Property.BasicInformation);
            using (OleDbCommand cmd = this.CreateCommand(sql,param))
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            
            //this.IDataBase.ExecuteSql(sql, param);
        }

        public virtual void Load(_COBJECTS p_Info, bool p_IsLoadProj)
        {
            string sql = string.Empty;
            this.OpenConnection();
            //项目需要初始化数据的时候此处添加
            //1.获取项目结构对象
            if (p_IsLoadProj)
            {
                try
                {

                    sql = "select 项目结构表.*,单位工程.[OBJECT] from 项目结构表 left join 单位工程 on 项目结构表.ID = 单位工程.PID  order by 项目结构表.ID asc";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(sql, this.Conn))
                    {
                        da.FillSchema(p_Info.StructSource.ModelProject, SchemaType.Source);
                        da.Fill(p_Info.StructSource.ModelProject);
                        //this.IDataBase.FillDataSet(sql, p_Info.StructSource.ModelProject);
                    }


                    //还原项目对象(第0行肯定为项目数据)             
                    sql = " select (select Max(Sort) from 项目结构表 where deep = 2) as UnSort,(select Max(Sort) from 项目结构表 where deep = 1) as EnSort";
                    sql = "select Max(dt.Sort) as UnSort,Max(dt1.Sort) as EnSort from (select Sort from 项目结构表 where deep = 2) dt,(select Sort from 项目结构表 where deep = 1) dt1";
                    DataTable table = new DataTable();
                    this.FillDataSet(sql, table);
                    //如果需要加载数据库数据时候操作此处添加
                    _ObjectSource.GetObject(p_Info, p_Info.StructSource.ModelProject.Rows[0]);
                    (p_Info as _Projects).UnSort = ToolKit.ParseInt(table.Rows[0]["UnSort"]);
                    (p_Info as _Projects).EnSort = ToolKit.ParseInt(table.Rows[0]["EnSort"]);
                    this.m_Current = p_Info;
                    //还原招投标对象
                    /*if (this.Current.StructSource.ModelProject.Rows[0]["OBJECT"] != null)
                    {
                        byte[] bs = this.Current.StructSource.ModelProject.Rows[0]["OBJECT"] as byte[];
                        _BasicInformation bf = this.GetObjectByte(bs) as _BasicInformation;
                        if (bf != null)
                        {
                            this.Current.Property.BasicInformation = bf;
                        }
                    }*/

                         //基础信息表
                    sql = "select * from 基础表";
                    this.FillDataSet(sql, this.Current.StructSource.ModelInfomation);
                    if (this.UseInfomation())
                    { 

                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            this.LoadOther();
            this.m_Current.ObjectState = EObjectState.UnChange;
            this.CloseConnection();
        }

        /// <summary>
        /// 保存基础信息
        /// </summary>
        /// <param name="p_tran"></param>
        public virtual void UpDate_ProjInfomation(IDbTransaction p_tran)
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
                DataTable table = this.Current.StructSource.ModelInfomation;
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
                this.Current.StructSource.ModelInfomation.AcceptChanges();
            }
        }

        

        /// <summary>
        /// 读取项目数据(项目 ， ([独立]单位工程)
        /// 此方法仅用于读取基础数据(打开的时候调用)
        /// </summary>
        public virtual void Load(_COBJECTS p_Info)
        {

            this.Load(p_Info, true);
        }

        /// <summary>
        /// 读取其他数据()
        /// </summary>
        public virtual void LoadOther()
        {
            //判断是否电子标书


            string sql = string.Empty;
            {
                this.Current.StructSource.ProjClear();
                //读取招标信息
                sql = " select * from 招标信息表";
                this.FillDataSet(sql, this.Current.StructSource.BiddingInfoSource);
                //读取投标信息
                sql = " select * from 投标信息表";
                this.FillDataSet(sql, this.Current.StructSource.TenderInfoSource);
                //读取项目分部分项数据
                //sql = " select * from (select iif(isnull(分部分项表.[Key]),项目结构表.[Key],分部分项表.[Key]) as [MKey] ,iif(isnull(分部分项表.[PKey]),项目结构表.[PKey],分部分项表.[PKey]) as [MPKey],分部分项表.* from 项目结构表 left join 分部分项表 on 项目结构表.ID = 分部分项表.UnID) as T where T.MKey <> 0";
                sql = " select -1 as [ID],[PID],0 as [PPARENTID],0 as [CPARENTID],0 as [FPARENTID],0 as [XH],'' as [XMBM],'' as [OLDXMBM],'' as [XMMC],'' as [DW],'' as [TX],'' as [LB],false as [JCBJ],false as [FHBJ],false as [ZYQD],false as [SDDJ],false as [JBHZ],'' as [XMTZ],'' as [GCLJSS],'' as [ZJWZ],false as [JX],false as [SC],'' as [YGLB],'' as [QFSZ],'' as [BEIZHU],'' as [LibraryName],'' as [LY],false as [SDQD],false as [SFFB],0 as [HL],0 as [GCL],0 as [ZJTJ],0 as [ZHDJ],0 as [ZHHJ],0 as [ZJFDJ],0 as [RGFDJ],0 as [CLFDJ],0 as [JXFDJ],0 as [ZCFDJ],0 as [SBFDJ],0 as [GLFDJ],0 as [LRDJ],0 as [FXDJ],0 as [GFDJ],0 as [SJDJ],0 as [CJDJ],0 as [JCDJ],0 as [XHL],0 as [ZJFHJ],0 as [RGFHJ],0 as [CLFHJ],0 as [JXFHJ],0 as [ZCFHJ],0 as [SBFHJ],0 as [GLFHJ],0 as [LRHJ],0 as [FXHJ],0 as [GFHJ],0 as [SJHJ],0 as [JCHJ],0 as [CJHJ],0 as [ZGJE],0 as [JGJE],0 as [FBJE],0 as [FL],'' as [DECJ],'' as [JSJC],'' as [ZJFS],'' as [QDBH],'' as [XMNR],'' as [XMTZZ],'' as [TYGS],false as [ISTY],0 as [PBZD],0 as [YGJE],false as [STATUS],false as [ZDSC],[Key],[PKey],[Deep],[Sort],项目结构表.[ID] as [UnID],0 as [EnID],0 as [SSLB] from 项目结构表 where 项目结构表.DEEP < 2  union select [ID],[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],[Sort],[UnID],[EnID],[SSLB] from 分部分项表 where [Key] <> 0 ";
                this.FillDataSet(sql, this.Current.StructSource.ModelSubSegments);
                DataRow[] rows = this.Current.StructSource.ModelSubSegments.Select("LB='清单'","sort asc");
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row=rows[i];
                    row["BEIZHU"] = row["OLDXMBM"] + "Q" + DateTime.Now.ToString() + "JZBX" + "加密锁号" + "H" + i.ToString("000001");
                }


                //读取项目措施项目
                //sql = " select * from (select iif(isnull(措施项目表.[Key]),项目结构表.[Key],措施项目表.[Key]) as [MKey] ,iif(isnull(措施项目表.[PKey]),项目结构表.[PKey],措施项目表.[PKey]) as [MPKey],措施项目表.* from 项目结构表 left join 措施项目表 on 项目结构表.ID = 措施项目表.UnID) as T where T.MKey <> 0";
                sql = " select -1 as [ID],[PID],0 as [PPARENTID],0 as [CPARENTID],0 as [FPARENTID],0 as [XH],'' as [XMBM],'' as [OLDXMBM],'' as [XMMC],'' as [DW],'' as [TX],'' as [LB],false as [JCBJ],false as [FHBJ],false as [ZYQD],false as [SDDJ],false as [JBHZ],'' as [XMTZ],'' as [GCLJSS],'' as [ZJWZ],false as [JX],false as [SC],'' as [YGLB],'' as [QFSZ],'' as [BEIZHU],'' as [LibraryName],'' as [LY],false as [SDQD],false as [SFFB],0 as [HL],0 as [GCL],0 as [ZJTJ],0 as [ZHDJ],0 as [ZHHJ],0 as [ZJFDJ],0 as [RGFDJ],0 as [CLFDJ],0 as [JXFDJ],0 as [ZCFDJ],0 as [SBFDJ],0 as [GLFDJ],0 as [LRDJ],0 as [FXDJ],0 as [GFDJ],0 as [SJDJ],0 as [CJDJ],0 as [JCDJ],0 as [XHL],0 as [ZJFHJ],0 as [RGFHJ],0 as [CLFHJ],0 as [JXFHJ],0 as [ZCFHJ],0 as [SBFHJ],0 as [GLFHJ],0 as [LRHJ],0 as [FXHJ],0 as [GFHJ],0 as [SJHJ],0 as [JCHJ],0 as [CJHJ],0 as [ZGJE],0 as [JGJE],0 as [FBJE],0 as [FL],'' as [DECJ],'' as [JSJC],'' as [ZJFS],'' as [QDBH],'' as [XMNR],'' as [XMTZZ],'' as [TYGS],false as [ISTY],0 as [PBZD],0 as [YGJE],false as [STATUS],false as [ZDSC],[Key],[PKey],[Deep],[Sort],项目结构表.[ID] as [UnID],0 as [EnID],0 as [SSLB] from 项目结构表 where 项目结构表.DEEP < 2  union select [ID],[PID],[PPARENTID],[CPARENTID],[FPARENTID],[XH],[XMBM],[OLDXMBM],[XMMC],[DW],[TX],[LB],[JCBJ],[FHBJ],[ZYQD],[SDDJ],[JBHZ],[XMTZ],[GCLJSS],[ZJWZ],[JX],[SC],[YGLB],[QFSZ],[BEIZHU],[LibraryName],[LY],[SDQD],[SFFB],[HL],[GCL],[ZJTJ],[ZHDJ],[ZHHJ],[ZJFDJ],[RGFDJ],[CLFDJ],[JXFDJ],[ZCFDJ],[SBFDJ],[GLFDJ],[LRDJ],[FXDJ],[GFDJ],[SJDJ],[CJDJ],[JCDJ],[XHL],[ZJFHJ],[RGFHJ],[CLFHJ],[JXFHJ],[ZCFHJ],[SBFHJ],[GLFHJ],[LRHJ],[FXHJ],[GFHJ],[SJHJ],[JCHJ],[CJHJ],[ZGJE],[JGJE],[FBJE],[FL],[DECJ],[JSJC],[ZJFS],[QDBH],[XMNR],[XMTZZ],[TYGS],[ISTY],[PBZD],[YGJE],[STATUS],[ZDSC],[Key],[PKey],[Deep],0 as [Sort],[UnID],[EnID],[SSLB] from 措施项目表 where [Key] <> 0 ";
                this.FillDataSet(sql, this.Current.StructSource.ModelMeasures);
                //其他项目
                sql = " select -1 as [ID],-1 as [ParentID],'' as [Number],项目结构表.[Name] as [Name],'' as [Unit],0 as [Quantities],'' as [Calculation],0 as [Unitprice], 0 as [Combinedprice],'' as [Remark], 0 as [Feature],'' as [beiyong], false as  [IsSys], 0 as [Coefficient],项目结构表.[ID] as [UnID],项目结构表.[Key] as [Key],项目结构表.[PKey] as [PKey] ,false as [DZBS],[Sort] from 项目结构表 where [DEEP] <> 2 union select  [ID],[ParentID],[Number],[Name],[Unit],[Quantities],[Calculation],[Unitprice],[Combinedprice],[Remark],[Feature],[beiyong],[IsSys],[Coefficient],[UnID],[Key],[PKey],[DZBS],0 as [Sort] from 其他项目表";
                this.FillDataSet(sql, this.Current.StructSource.ModelOtherProject);
                //工料机（ 所有工料机 ）
                sql = " select [ID],[PID],[EnID],[UnID],[SSLB],[QDID],[ZMID],[YSBH],[YSMC],[YSDW],[YSXHL],[BH],[MC],[DW],[XHL],[LB],[DEDJ],[SCDJ],[JSDJ],[GCL],[IFZYCL],[ZCLB],[GGXH],[SDCLB],[SDCXS],[YTLB],[IFXZ],[IFSC],[IFFX],[IFSDSCDJ],[IFSDSL],[IFKFJ],[SSKLB],[GLJBZ],[CTIME],[SLH],[SLDEHJ],[SLSCHJ],[CJ],[PP],[ZLDJ],[GYS],[CD],[CJBZ],[XGHSCDJ],[TZXS] from 工料机表";
                this.FillDataSet(sql, this.Current.StructSource.ModelQuantity);
                //取参数设置变量
                sql = " select * from 变量表";
                //DataTable table = new DataTable();//this.Current.StructSource.ModelProjVariable
                this.FillDataSet(sql, this.Current.StructSource.ModelProjVariable);
                //汇总分析表
                sql = "select  * from 汇总分析表";
                this.FillDataSet(sql, this.Current.StructSource.ModelMetaanalysis);
            }

            //措施项目数据
            /*sql = "select * from 措施项目表";
            this.FillDataSet(sql, this.Current.StructSource.ModelMeasures);
            this.Current.StructSource.ModelMeasures.IsCompled = false;
            //变量
            sql = "select * from 变量表";
            this.Current.Property.Statistics.ResultVarable.DataSource.Clear();
            this.FillDataSet(sql, this.Current.Property.Statistics.ResultVarable.DataSource);
            this.Current.Property.Statistics.IsCompled = false;
            //读取汇总分析数据
            sql = "select * from 汇总分析表 order by PID";
            this.FillDataSet(sql, this.Current.StructSource.ModelMetaanalysis);
            this.Current.StructSource.ModelMetaanalysis.IsCompled = false;*/
            
        }

        /// <summary>
        /// 读取基础信息判断基础条件是否正确
        /// </summary>
        /// <returns></returns>
        public bool UseInfomation()
        {
            this.Current.ObjectKey = this.Current.StructSource.ModelInfomation.Get<int>("ObjectKey");
            //检查数据类型
            string fileTypeName = this.Current.StructSource.ModelInfomation.Get<string>("文件类型");
            switch (fileTypeName)
            {
                case "电子标书":
                    this.Current.IsDZBS = true;
                    break;
                default://默认都是项目文件
                    this.Current.IsDZBS = false;
                    break;
            }
            return true;
        }

        /// <summary>
        /// 保存当前对象到数据源
        /// 保存项目数据 保存(独立单位工程数据)
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void Save()
        {
            //保存时候此处更新数据
            //1.更新项目数据
        }

        /// <summary>
        /// 另存为(普通保存)        
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void SaveAs()
        {
            //保存时候此处更新数据
            //1.更新项目数据
        }

        public virtual void SaveAsDZBS()
        { }
        public virtual void OutAsDZBS()
        { }
        /// <summary>
        /// 压缩对象
        /// </summary>
        /// <param name="p_info"></param>
        /// <returns></returns>
        public virtual byte[] GetByteObject(object p_info)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                using (MemoryStream m = new MemoryStream())
                {

                    BinaryFormatter formater = new BinaryFormatter();
                    formater.Serialize(m, p_info);
                    byte[] buffer = m.ToArray();

                    GZipStream zip = new GZipStream(ms, CompressionMode.Compress);
                    zip.Write(buffer, 0, buffer.Length);
                    zip.Close();
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// 根据字节获取对象
        /// </summary>
        /// <param name="p_bytes"></param>
        /// <returns></returns>
        public virtual object GetObjectByte(byte[] p_bytes)
        {

            /*using (MemoryStream ms = new MemoryStream(p_bytes))
            {

                GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
                BinaryFormatter formater = new BinaryFormatter();
                object obj = formater.Deserialize(zip);
                zip.Close();
                return obj;
            }*/
            return null;
        }
    }
}
