/*
    扩展项目的业务逻辑(包含数据访问对象)
 *  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.DATA;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using System.Collections;
using System.IO;
using System.Data.OleDb;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public partial class _Pr_Business
    {
        /// <summary>
        /// 一次数据业务的事务处理
        /// </summary>
        private IDbTransaction DBTran = null;

        #region --------------------处理导入xml逻辑---------------------

        /// <summary>
        /// 保存单位工程(导入xml文件使用)
        /// </summary>
        /// <param name="p_Info"></param>
        /// <returns></returns>
        public CResult SaveUnitFormXml(_UnitProject p_Info)
        {
            CResult result = new CResult(false);
            //this.OpenDataBase();
            //通知单位工程赋值加密锁
            this.DataBase.SetKey += new _ObjectDataBase.OnSetKeyHandler(DataBase_SetKey);
            //保存单位工程数据
            this.ProjDataBase.SaveUnitXml(p_Info, DBTran);
            //保存项目数据

            this.DataBase.SetKey -= new _ObjectDataBase.OnSetKeyHandler(DataBase_SetKey);
            result.Success = true;
            return result;
        }

        /// <summary>
        /// 保存单位工程(导入xml文件使用)
        /// </summary>
        /// <param name="p_Info"></param>
        /// <returns></returns>
        public CResult SaveProjFormXml()
        {
            //开启事务
            CResult result = new CResult(false);
            this.Current.Key = this.Current.ObjectKey;
            //开启数据库操作
            this.ProjDataBase.SaveProjXml(DBTran);
            //开始初始化项目数据
            return result;
        }

        /// <summary>
        /// 创建文件（创建项目文件）
        /// </summary>
        /// <returns></returns>
        public CResult CreateFile()
        {
            CResult result = new CResult(false);
            _ObjectDataBase.CreateFile(this.Current);
            result.Success = true;
            return result;

        }

        /// <summary>
        /// 准备开启一次数据库业务
        /// </summary>
        public IDbTransaction BeginData()
        {
            if (this.DataBase != null)
            {
                this.DataBase.Close();
                this.DataBase = null;
            }
            //开启链接
            this.OpenDataBase();
            //完整的事务处理
            DBTran = this.DataBase.Conn.BeginTransaction();
            return DBTran;
        }

        /// <summary>
        /// 准备开启一次数据库业务
        /// </summary>
        public IDbTransaction BeginData(bool flag)
        {
            if (this.DataBase != null)
            {
                this.DataBase.Close();
                this.DataBase = null;
            }
            //开启链接
            this.OpenDataBase();
            //完整的事务处理
            if (this.DataBase.Conn.State != ConnectionState.Open)
                this.DataBase.Conn.Open();
            DBTran = this.DataBase.Conn.BeginTransaction();
            this.ProjDataBase.MyTran = this.DBTran as System.Data.OleDb.OleDbTransaction;
            return DBTran;
        }

        /// <summary>
        /// 结束一次数据库操作业务
        /// </summary>
        public void EndData()
        {
            if (DBTran != null && DBTran.Connection != null)
            {
                DBTran.Commit();
            }
        }

        #endregion

        /// <summary>
        /// 加载获取对象数据
        /// </summary>
        /// <param name="p_info"></param>
        public virtual void ProjectSummaryLoad(_COBJECTS p_info)
        {
            this.OpenDataBase();
            this.DataBase.Load(p_info);
            this.InitDataObject(p_info);
        }

        public void Update_Quantity(DataRow p_DataRow, string p_FieldName)
        {
            string m_ID = string.Empty;
            foreach (_UnitProject item in this.ObjectList.Values)
            {
                DataRow dr = item.StructSource.ModelQuantity.Select(string.Format("BH='{0}' AND MC='{1}' AND DW='{2}' AND SCDJ={3} AND YTLB='{4}' AND LB='{5}' AND IFSDSCDJ='{6}'", p_DataRow["BH"], p_DataRow["MC"], p_DataRow["DW"], p_DataRow["SCDJ", DataRowVersion.Current], p_DataRow["YTLB"], p_DataRow["LB"], p_DataRow["IFSDSCDJ"])).FirstOrDefault();
                if (dr != null)
                {
                    _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(item);
                    APP.UserPriceLibrary.AllQuantityUnit = item.StructSource.ModelQuantity;
                    APP.UserPriceLibrary.UnName = item.Name;
                    APP.UserPriceLibrary.Range = 0;
                    APP.UserPriceLibrary.Update(p_FieldName, p_DataRow[p_FieldName, DataRowVersion.Proposed], p_DataRow);
                    m_Methods_Subheadings.BatchCalculate();
                    m_ID += item.ID + ",";
                }
            }
            if (m_ID != string.Empty)
            {
                m_ID = m_ID.Substring(0, m_ID.Length - 1);
            }
            else
            {
                m_ID = "-1";
            }
            DataRow[] drs = this.Current.StructSource.ModelProject.Select(string.Format("Deep=2 AND ID not in({0})", m_ID));
            foreach (DataRow item in drs)
            {
                DataRow dr = this.Current.StructSource.ModelQuantity.Select(string.Format("BH='{0}' AND MC='{1}' AND DW='{2}' AND SCDJ={3} AND YTLB='{4}' AND LB='{5}' AND IFSDSCDJ='{6}' AND UnID={7}", p_DataRow["BH"], p_DataRow["MC"], p_DataRow["DW"], p_DataRow["SCDJ", DataRowVersion.Current], p_DataRow["YTLB"], p_DataRow["LB"], p_DataRow["IFSDSCDJ"], item["ID"])).FirstOrDefault();
                if (dr != null)
                {
                    using (_UnitProject m_UnitProject = new _UnitProject())
                    {
                        _ObjectSource.GetObject(m_UnitProject, item);
                        this.ProjectSummaryLoad(m_UnitProject);
                        if (dr != null)
                        {
                            _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(m_UnitProject);
                            APP.UserPriceLibrary.AllQuantityUnit = m_UnitProject.StructSource.ModelQuantity;
                            APP.UserPriceLibrary.UnName = m_UnitProject.Name;
                            APP.UserPriceLibrary.Range = 0;
                            APP.UserPriceLibrary.Update(p_FieldName, p_DataRow[p_FieldName, DataRowVersion.Proposed], p_DataRow);
                            m_Methods_Subheadings.BatchCalculate();
                            this.SaveUnitFormXml(m_UnitProject);
                        }
                    }
                }
            }
        }

        public void Update_Quantity(DataTable p_DataTable, string p_FieldName)
        {
            if (p_DataTable == null) return;
            string m_ID = "-10";
            foreach (_UnitProject item in this.ObjectList.Values)
            {
                _Methods_Subheadings m_Methods_Subheadings = null;
                foreach (DataRow glj_item in p_DataTable.Rows)
                {
                    if (glj_item.HasVersion(DataRowVersion.Original))
                    {
                        DataRow dr = item.StructSource.ModelQuantity.Select(string.Format("BH='{0}' AND MC='{1}' AND DW='{2}' AND SCDJ={3} AND YTLB='{4}' AND LB='{5}' AND IFSDSCDJ='{6}'", glj_item["BH"], glj_item["MC"], glj_item["DW"], glj_item["SCDJ", DataRowVersion.Original], glj_item["YTLB"], glj_item["LB"], glj_item["IFSDSCDJ"])).FirstOrDefault();
                        if (dr != null)
                        {
                            if (m_Methods_Subheadings == null) m_Methods_Subheadings = new _Methods_Subheadings(item);
                            APP.UserPriceLibrary.AllQuantityUnit = item.StructSource.ModelQuantity;
                            APP.UserPriceLibrary.UnName = item.Name;
                            APP.UserPriceLibrary.Range = 0;
                            dr.BeginEdit();
                            dr[p_FieldName] = glj_item[p_FieldName];
                            APP.UserPriceLibrary.Update(p_FieldName, dr[p_FieldName, DataRowVersion.Current], dr);
                            dr.EndEdit();
                            if (p_FieldName.Equals("SCDJ"))
                            {
                                _Methods_YTLBSummary m_Methods_YTLBSummary = new _Methods_YTLBSummary(item);
                                m_Methods_YTLBSummary.RefreshSCDJ(glj_item);
                            }
                            m_ID += item.ID + ",";
                        }
                    }
                }
                if (m_Methods_Subheadings != null) m_Methods_Subheadings.BatchCalculate();
            }
            if (m_ID != string.Empty)
            {
                m_ID = m_ID.Substring(0, m_ID.Length - 1);
                DataRow[] drs = this.Current.StructSource.ModelProject.Select(string.Format("Deep=2 AND ID not in({0})", m_ID));
                foreach (DataRow item in drs)
                {
                    using (_UnitProject m_UnitProject = new _UnitProject())
                    {
                        _Methods_Subheadings m_Methods_Subheadings = null;
                        bool m_load = true;
                        foreach (DataRow glj_item in p_DataTable.Rows)
                        {
                            if (glj_item.HasVersion(DataRowVersion.Original))
                            {
                                DataRow dr = this.Current.StructSource.ModelQuantity.Select(string.Format("BH='{0}' AND MC='{1}' AND DW='{2}' AND SCDJ={3} AND YTLB='{4}' AND LB='{5}' AND IFSDSCDJ='{6}' AND UnID={7}", glj_item["BH"], glj_item["MC"], glj_item["DW"], glj_item["SCDJ", DataRowVersion.Original], glj_item["YTLB"], glj_item["LB"], glj_item["IFSDSCDJ"], item["ID"])).FirstOrDefault();
                                if (dr != null)
                                {
                                    if (m_load)
                                    {
                                        _ObjectSource.GetObject(m_UnitProject, item);
                                        this.ProjectSummaryLoad(m_UnitProject);
                                        m_Methods_Subheadings = new _Methods_Subheadings(m_UnitProject);
                                        m_load = false;
                                    }
                                    APP.UserPriceLibrary.AllQuantityUnit = m_UnitProject.StructSource.ModelQuantity;
                                    APP.UserPriceLibrary.UnName = m_UnitProject.Name;
                                    APP.UserPriceLibrary.Range = 0;
                                    dr.BeginEdit();
                                    dr[p_FieldName] = glj_item[p_FieldName];
                                    APP.UserPriceLibrary.Update(p_FieldName, dr[p_FieldName, DataRowVersion.Current], dr);
                                    dr.EndEdit();
                                    if (p_FieldName.Equals("SCDJ"))
                                    {
                                        _Methods_YTLBSummary m_Methods_YTLBSummary = new _Methods_YTLBSummary(m_UnitProject);
                                        m_Methods_YTLBSummary.RefreshSCDJ(glj_item);
                                    }
                                }
                            }
                        }
                        if (m_Methods_Subheadings != null)
                        {
                            m_Methods_Subheadings.BatchCalculate();
                            this.SaveUnitFormXml(m_UnitProject);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 插入分部分项数据
        /// </summary>
        /// <param name="p_row"></param>
        /// <param name="p_tran"></param>
        public void Insert_SubData(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_SubData(p_row, DBTran);
        }

        /// <summary>
        /// 插入措施项目
        /// </summary>
        /// <param name="p_row"></param>
        public void Insert_Sql_MeasuresData(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_MeasuresData(p_row, DBTran);
        }

        /// <summary>
        /// 插入一条工料机
        /// </summary>
        /// <param name="p_row"></param>
        public void Insert_QuantityData(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_QuantityData(p_row, DBTran);
        }
        public void Update_Sql_QuantityData(string BH, UseType type)
        {
            this.ProjDataBase.Update_Sql_QuantityData(BH, type, DBTran);
        }
        public void Insert_Sql_YTLBSummary(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_YTLBSummary(p_row, DBTran);
        }
        /// <summary>
        /// 插入汇总分析
        /// </summary>
        /// <param name="p_Table"></param>
        public void Insert_Sql_Metaanalysis(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_Metaanalysis(p_row, DBTran);
        }

        /// <summary>
        /// 更新工程取费
        /// </summary>
        /// <param name="p_Table"></param>
        public void Insert_Sql_UnitFree(DataTable p_Table)
        {
            this.ProjDataBase.Insert_Sql_UnitFree(p_Table, DBTran);
        }


        /// <summary>
        /// 其他项目
        /// </summary>
        /// <param name="p_Unit"></param>
        /// <param name="p_tran"></param>
        public void Insert_Sql_OtherProject(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_OtherProject(p_row, DBTran);
        }

        /// <summary>
        /// 子目取费
        /// </summary>
        /// <param name="p_row"></param>
        public void Insert_Sql_SubheadingsFee(DataRow p_row)
        {
            this.ProjDataBase.Insert_Sql_SubheadingsFee(p_row, DBTran);
        }

        /// <summary>
        /// 子目取费
        /// </summary>
        /// <param name="p_row"></param>
        public void Insert_Sql_PSubheadingsFee(DataTable p_Table)
        {
            this.ProjDataBase.Insert_Sql_PSubheadingsFee(p_Table, DBTran);
        }

        /// <summary>
        /// 更新基础信息表
        /// </summary>
        /// <param name="p_Table"></param>
        public virtual void UpDate_ProjInfomation(DataTable p_Table)
        {
            this.ProjDataBase.UpDate_ProjInfomation(p_Table, DBTran);
        }
        public virtual void UpDate_Project()
        {
            this.ProjDataBase.UpDate_Project(DBTran);
        }

        #region --------------------数据另存为---------------------

        /// <summary>
        /// 另存为业务逻辑(当前项目另存为数据文件)
        /// </summary>
        /// <param name="p_File"></param>
        public void SaveAs(System.IO.FileInfo p_File)
        {
            //创建数据文件
            //创建新的数据访问对象
            this.SetKeyNo();
            using (_ProjDataBase db = new _ProjDataBase(string.Format(_DataBase.AccessConnString, p_File.FullName), this.ObjectList))
            {
                db.Open(this.Current);
                //调用保存逻辑
                db.SaveAs();
            }
        }

        /// <summary>
        /// 另存电子标书逻辑(当前项目另存为数据文件)
        /// </summary>
        /// <param name="p_File"></param>
        public void SaveAsDZBS(System.IO.FileInfo p_File)
        {
            //1.添加类型为 电子标书
            //2.删除所有子目数据

            //this.Current.StructSource.ModelInfomation.Set("版本号", "Ver 1.0");

            //创建数据文件
            //创建新的数据访问对象
            using (_ProjDataBase db = new _ProjDataBase(string.Format(_DataBase.AccessConnString, p_File.FullName), this.ObjectList))
            {
                //创建新的项目文件
                //this.CreateFile();
                //文件类型
                this.Current.StructSource.ModelInfomation.Set("文件类型", "电子标书");
                db.Open(this.Current);
                //调用保存逻辑

                if (APP.FileType.Equals("项目工程"))
                {
                    db.OutAsDZBS();
                }
                else
                {
                    db.SaveAsDZBS();
                }

            }
        }

        /*/// <summary>
        /// 项目配置信息
        /// </summary>
        /// <param name="tran"></param>
        private void SaveEx_ProjInfomation(IDbTransaction tran)
        {
            foreach (DataRow row in this.Current.StructSource.ModelInfomation.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    this.ProjDataBase.Insert_ProjInfomation(row, tran);
                }
            }
        }

        /// <summary>
        /// 项目结构表数据
        /// </summary>
        /// <param name="tran"></param>
        private void SaveEx_Project(IDbTransaction tran)
        {
            foreach (DataRow row in this.Current.StructSource.ModelProject.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    this.ProjDataBase.Insert_Project(row, tran);
                }
            }
        }*/

        #endregion

        /// <summary>
        /// 提供一套静态方法此处获取头文件对象
        /// </summary>
        /// <param name="p_FileInfo"></param>
        /// <returns></returns>
        public static _FileHeader OnlyReadHeader(FileInfo p_FileInfo)
        {
            _HeaderBase db = new _HeaderBase(string.Format(_DataBase.AccessConnString, p_FileInfo.FullName));
            _FileHeader fh = db.Get_FileHeader();
            db.Conn = null;
            db = null;
            System.GC.Collect();
            return fh;

        }
    }
}
