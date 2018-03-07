/*
 *  项目业务 继承容器业务
 *  项目修改可以同时多个项目共同工作
 *  1.两种业务状态 需要访问数据库资源 需要访问文件资源
 *  访问文件资源之前需要释放数据库链接
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.DATA;
using System.IO;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;


namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 单位工程的业务对象
    /// </summary>
    public partial class _Pr_Business : _BusContainer
    {
        public Hashtable ObjectList;

        /// <summary>
        /// 添加到活动单位工程集合中
        /// </summary>
        /// <param name="p_Info"></param>
        public void AddUnit(_COBJECTS p_Info)
        {
            if (!this.ObjectList.ContainsKey(p_Info.ID))
            {
                this.ObjectList.Add(p_Info.ID, p_Info);
            }
            else
            {
                this.ObjectList[p_Info.ID] = p_Info;
            }


        }
        /// 添加到活动单位工程集合中
        /// </summary>
        /// <param name="p_Info"></param>
        private void DelUnit(DataRow row)
        {
            if (this.ObjectList.ContainsKey(row["ID"]))
            {
                this.ObjectList.Remove(row["ID"]);
            }
        }

        private _ProjDataBase ProjDataBase
        {
            get
            {
                return this.DataBase as _ProjDataBase;
            }
        }

        public _Pr_Business()
            : base()
        {

            //当前工作流类型为项目
            this.WorkFlowType = EWorkFlowType.PROJECT;
            ObjectList = new Hashtable();
        }



        /// <summary>
        /// 为项目(容器)做初始化准备工作
        /// </summary>
        public override void Init()
        {
            base.Init();
        }

        /// <summary>
        /// 创建一个新的项目(对象状态修改为 创建)
        /// </summary>
        public override void Create()
        {
            //设置当前对象为项目
            this.Current = new _Projects();
            //版本号
            this.Current.StructSource.ModelInfomation.Set("版本号", APP.Ver);
            //文件类型
            this.Current.StructSource.ModelInfomation.Set("文件类型", "项目文件");
            //招标信息
            DataRow zrow = this.Current.StructSource.BiddingInfoSource.NewRow();
            //添加招标信息
            this.Current.StructSource.BiddingInfoSource.Rows.Add(zrow);
            //投标信息
            DataRow trow = this.Current.StructSource.TenderInfoSource.NewRow();
            //添加招标信息
            this.Current.StructSource.TenderInfoSource.Rows.Add(trow);
            //第一次创建的时候赋值
            this.SetKeyNo();
        }

        /// <summary>
        /// 首次创建项目完成后不在调用此方法，导入逻辑的时候此方法继续调用
        /// 结束创建新的项目(对象状态修改为 结束创建)
        /// </summary>
        public override void EndCreate()
        {
            //修改为不在直接创建文件 
            //APP.Methods.Init(this.Current);
            _ObjectDataBase.CreateFile(this.Current);
            this.Current.Key = this.Current.ObjectKey;
            this.OpenDataBase();
            //开启数据库操作
            this.ProjDataBase.Create();
            //开始初始化项目数据
        }

        /// <summary>
        /// 保存并且穿件
        /// </summary>
        public void SaveAndCreate()
        {
            _ObjectDataBase.CreateFile(this.Current);
        }

        /// <summary>
        /// 保存完毕后要做的事情(提供此方法用于直接创建项目然后另存为)
        /// </summary>
        public void SavedAndCreated()
        {
            ///提交数据表
            this.Current.StructSource.AcceptChanges();
            foreach (_UnitProject unit in this.ObjectList.Values)
            {
                ///单位工程提交
                unit.StructSource.AcceptChanges();
            }
        }

        /// <summary>
        /// 首次创建 不产生项目文件 首次保存的时候产生项目文件
        /// </summary>
        public override void FristEndCreate()
        {
            //修改为不在直接创建文件             
            this.Current.Key = this.Current.ObjectKey;
            this.Current.StructSource.ModelProject.Add(this.Current);
        }


        /// <summary>
        /// 开启一次数据库链接操作
        /// </summary>
        public override void OpenDataBase()
        {
            if (DataBase == null)
            {
                DataBase = new _ProjDataBase(string.Format(_DataBase.AccessConnString, this.Current.Files.FullName), this.ObjectList);
            }
            DataBase.Open(this.Current);
        }


        /// <summary>
        /// 关闭当前数据库链接
        /// </summary>
        public override void CloseDataBase()
        {
            if (DataBase != null)
            {
                DataBase = null;
                DataBase.Close();
            }
        }

        /// <summary>
        /// 为当前项目添加子项目(添加实体对象单项工程)
        /// </summary>
        /// <param name="p_info"></param>
        public override void Add(_COBJECTS p_info)
        {
            //准备排序索引
            //this.Current.StrustObject.Add(p_info.Directory.Key, p_info);
            //p_info.ObjectState = EObjectState.Created;
            p_info.Sort = (this.Current as _Projects).EnSort++;
            p_info.PKey = this.Current.Key;
            p_info.Key = ++this.Current.ObjectKey;
            this.Current.StructSource.ModelProject.Add(p_info);
            this.onListChange();
            //this.ProjDataBase.Add(p_info);
        }

        /// <summary>
        /// 添加单位工程(添加实体对象单位工程)
        /// </summary>
        /// <param name="p_parent"></param>
        /// <param name="p_info"></param>
        public override void AddChild(_COBJECTS p_parent, _COBJECTS p_info)
        {
            //设置排序
            //初始化对象
            //APP.Methods.Init(p_info);
            p_info.Parent = p_parent;
            //新添加单位工程状态设置为创建结束
            p_info.PID = p_parent.ID;
            p_info.Sort = ++(this.Current as _Projects).UnSort;
            p_info.Key = ++this.Current.ObjectKey;
            p_info.PKey = p_parent.Key;
            //APP.Methods.Init(p_info);
            this.Current.StructSource.ModelProject.Add(p_info);
            this.Current.StructSource.ModelProject.AppendUnit(p_info);
            this.InitDataObject(p_info);
            doLoadData(p_info);
            p_info.StructSource.ModelProject.AddNotInt(p_info);
            p_info.ObjectState = EObjectState.Created;
            this.ObjectList.Add(p_info.ID, p_info);
            //添加单位工程后为此单位工程初始化新数据
            //分部分项操作
            /* _SObjectInfo sub = new _SObjectInfo(p_info as _UnitProject);
             sub.XMBM = "单位工程";
             p_info.StructSource.ModelSubSegments.Add(sub);*/
            this.onListChange();
            //this.ProjDataBase.AddChild(p_parent, p_info);
        }

        public void AddChildByXml(_COBJECTS p_parent, _COBJECTS p_info)
        {
            //设置排序
            //初始化对象
            //APP.Methods.Init(p_info);
            p_info.Parent = p_parent;
            //新添加单位工程状态设置为创建结束
            p_info.PID = p_parent.ID;
            p_info.Sort = ++(this.Current as _Projects).UnSort;
            p_info.Key = ++this.Current.ObjectKey;
            p_info.PKey = p_parent.Key;
            //  this.m_ObjectList.Add(p_info.ID, p_info);
            //APP.Methods.Init(p_info);
            this.Current.StructSource.ModelProject.Add(p_info);
            //this.Current.StructSource.ModelProject.AppendUnit(p_info);
            this.InitDataObject(p_info);
            doLoadDataXml(p_info);
            p_info.StructSource.ModelProject.AddNotInt(p_info);
            p_info.ObjectState = EObjectState.Created;
            //this.m_ObjectList.Add(p_info.ID, p_info);
            this.onListChange();

        }
        private void doLoadDataXml(_COBJECTS p_info)
        {
            _Entity_SubInfo info;
            //分部分项数据
            info = new _Entity_SubInfo();
            info.XMBM = "单位工程";
            info.UnID = p_info.ID;
            info.EnID = p_info.PID;
            info.Deep = 2;
            info.SSLB = 0;
            info.Key = ++this.Current.ObjectKey;
            info.PKey = p_info.PKey;
            p_info.StructSource.ModelSubSegments.Add(info);
            this.Insert_SubData(p_info.StructSource.ModelSubSegments.Rows[0]);
            //措施项目数据
            info = new _Entity_SubInfo();
            info.UnID = p_info.ID;
            info.EnID = p_info.PID;
            info.XMBM = "措施项目";
            info.Deep = 3;
            info.SSLB = 1;
            info.Key = ++this.Current.ObjectKey;
            info.PKey = p_info.PKey;
            p_info.StructSource.ModelMeasures.Add(info);
            this.Insert_Sql_MeasuresData(p_info.StructSource.ModelMeasures.Rows[0]);

            //工程取费
            this.Insert_Sql_UnitFree(p_info.StructSource.ModelUnitFee);
            //参数子目取费
            this.Insert_Sql_PSubheadingsFee(p_info.StructSource.ModelPSubheadingsFee);

        }
        /// <summary>
        /// 为新的单位工程初始化数据
        /// </summary>
        private void doLoadData(_COBJECTS p_info)
        {
            _Entity_SubInfo info;
            //分部分项数据
            info = new _Entity_SubInfo();
            info.XMBM = "单位工程";
            info.UnID = p_info.ID;
            info.EnID = p_info.PID;
            info.Deep = 2;
            info.SSLB = 0;
            info.Key = ++this.Current.ObjectKey;
            info.PKey = p_info.PKey;
            p_info.StructSource.ModelSubSegments.Add(info);
            //措施项目数据
            info = new _Entity_SubInfo();
            info.UnID = p_info.ID;
            info.EnID = p_info.PID;
            info.XMBM = "措施项目";
            info.Deep = 3;
            info.SSLB = 1;
            info.Key = ++this.Current.ObjectKey;
            info.PKey = p_info.PKey;
            p_info.StructSource.ModelMeasures.Add(info);

            _UnitProject unit = p_info as _UnitProject;
            _Mothod_Measures met = new _Mothod_Measures(this, unit, info);
            met.Load();
            //初始化汇总分析
            _Method_Metaanalysis hmet = new _Method_Metaanalysis(unit);
            hmet.Init();
            //其他项目-模板
            _Method_OtherProject omet = new _Method_OtherProject(this, unit);
            omet.Init();
        }
        /// <summary>
        /// 初始化单位工程
        /// </summary>
        /// <param name="p_info"></param>
        public override void InitDataObject(GOLDSOFT.QDJJ.COMMONS._COBJECTS p_Info)
        {

            //初始化属性
            p_Info.Property.DLibraries.FixedLibrary.Rule = p_Info.DEGZ;
            p_Info.Property.DLibraries.FixedLibrary.LibName = p_Info.DELibName;
            p_Info.Property.DLibraries.AtlasGallery.LibName = p_Info.TJLibName;
            p_Info.Property.DLibraries.ListGallery.Rule = p_Info.QDGZ;
            p_Info.Property.DLibraries.ListGallery.LibName = p_Info.QDLibName;
            //_Library
            //初始化库
            p_Info.Property.DLibraries.Init(APP.Application);
            //初始化新的临时对象（不参与序列化此对象每次使用需要呗初始化）
            p_Info.Property.Temporary = new _Temporary();
            //默认同步临时库对象
            p_Info.Property.Temporary.Libraries = p_Info.Property.DLibraries.Copy();
            p_Info.Property.Temporary.Libraries.Init(APP.Application);
            p_Info.Property.IncreaseCosts.init();//初始化子目取费
            _UnitProject m_UnitProject = p_Info as _UnitProject;
            if (m_UnitProject != null)
            {
                if (m_UnitProject.StructSource.ModelUnitFee.Rows.Count == 0 || m_UnitProject.StructSource.ModelPSubheadingsFee.Rows.Count == 0)
                {
                    _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(m_UnitProject);
                    m_Methods_ParamsSeting.Init();
                    DataRow[] m_MRGCQF = m_UnitProject.StructSource.ModelUnitFee.Select(string.Format("GCLB='{0}'", m_UnitProject.ProType));
                    if (m_MRGCQF.Length == 0)
                    {
                        m_UnitProject.ProType = m_UnitProject.StructSource.ModelUnitFee.Rows[0]["GCLB"].ToString();
                    }
                }
            }
        }

        ////public  void AddChildXml(_COBJECTS p_parent, _COBJECTS p_info)
        //{
        //    //设置排序
        //    //初始化对象
        //    //APP.Methods.Init(p_info);
        //    p_info.Parent = p_parent;
        //    //新添加单位工程状态设置为创建结束
        //    p_info.PID = p_parent.ID;
        //    p_info.Sort = ++(this.Current as _Projects).UnSort;
        //   // APP.Methods.Init(p_info);
        //    this.Current.StructSource.ModelProject.Add(p_info);
        //    this.Current.StructSource.ModelProject.AppendUnit(p_info);
        //    this.m_ObjectList.Add(p_info.ID, p_info);
        //    p_info.ObjectState = EObjectState.Created;
        //    //添加单位工程后为此单位工程初始化新数据
        //    //分部分项操作
        //    /* _SObjectInfo sub = new _SObjectInfo(p_info as _UnitProject);
        //     sub.XMBM = "单位工程";
        //     p_info.StructSource.ModelSubSegments.Add(sub);*/
        //    this.onListChange();
        //    //this.ProjDataBase.AddChild(p_parent, p_info);
        //}




        /// <summary>
        /// 为指定的单项工程批量添加单位工程（此处允许添加单项工程）
        /// </summary>
        /// <param name="table">单位工程集合</param>
        public new void BatchAdd(DataTable p_Source, Hashtable p_Table)
        {
            _COBJECTS info = null;
            DataView view = p_Source.DefaultView;
            int deep = -1;
            foreach (DataRowView row in view)
            {
                switch (row.Row.RowState)
                {
                    case DataRowState.Modified:
                        deep = ToolKit.ParseInt(row["DEEP"]);
                        //同步数据
                        info = new _COBJECTS();
                        if (deep == 1)
                        {
                            _ObjectSource.GetObject(info, row);
                            this.Current.StructSource.ModelProject.UpDate(info);
                        }
                        if (deep == 2)
                        {
                            _ObjectSource.GetObject(info, row);
                            this.Current.StructSource.ModelProject.UpDate(info);
                        }
                        break;
                    case DataRowState.Added:
                        deep = ToolKit.ParseInt(row["DEEP"]);
                        if (deep == 1)
                        {
                            this.Current.StructSource.ModelProject.AddNotInt(row["UnitProject"]);
                        }
                        if (deep == 2)
                        {
                            info = row["UnitProject"] as _COBJECTS;
                            this.InitDataObject(info);
                            this.doLoadData(info);
                            this.Current.StructSource.ModelProject.AddNotInt(info);
                            info.StructSource.ModelProject.AddNotInt(info);
                            this.Current.StructSource.ModelProject.AppendUnit(info);
                            //新增对象添加到objectList中
                            info.ObjectState = EObjectState.Created;
                            this.ObjectList.Add(info.ID, info);
                        }
                        break;
                }
            }
            //处理删除逻辑
            foreach (_COBJECTS inf in p_Table.Values)
            {
                this.Current.StructSource.ModelProject.Delete(inf.ID);
                //如果是单位工程 删除掉
                this.ObjectList.Remove(inf.ID);
            }
            this.onListChange();
        }


        public override void Remove(DataRowView p_Row)
        {
            //删除指定的行对象
            //如果当前有子行
            //如果深度是2 直接删除 如果深度是1 删除所有子节点
            //如果要删除的对象在操作集合中已经存在则删除掉
            int deep = ToolKit.ParseInt(p_Row["DEEP"]);
            if (deep == 1)
            {
                int id = ToolKit.ParseInt(p_Row["ID"]);
                //删除单项工程下的单位工程
                DataRow[] rows = this.Current.StructSource.ModelProject.Select(string.Format("PID = {0}", id));
                if (rows != null)
                {
                    foreach (DataRow r in rows)
                    {
                        if (r.RowState != DataRowState.Deleted)
                        {
                            this.DelUnit(r);
                            this.Current.StructSource.ProjClear(r["ID"]);
                            r.Delete();
                        }
                    }
                    //清除单项工程数据
                    this.Current.StructSource.DeleteEn(id);
                }
            }
            ////如果只剩下根结点 则删除
            //DataRow[] punRows = this.Current.StructSource.ModelProject.Select("ID = " + p_Row["ID"].ToString());
            //if (punRows.Length > 0)
            //{
            //    DataRow row = this.Current.StructSource.ModelProject.Rows[1];

            //    int id = ToolKit.ParseInt(row["ID"]);
            //    this.DelUnit(row);
            //    this.Current.StructSource.ProjClear(row["ID"]);
            //    row.Delete();
            //}

            if (p_Row.Row.RowState != DataRowState.Deleted)
            {
                this.DelUnit(p_Row.Row);
                this.Current.StructSource.ProjClear(p_Row.Row["ID"]);
                p_Row.Delete();

                //this.Current.StructSource.ModelProject.AcceptChanges();
            }
        }

        /// <summary>
        /// 当前数据替换源数据（目前替换只针对单位工程）
        /// </summary>
        /// <param name="p_source">源数据</param>
        /// <param name="p_curr">当前数据</param>
        public override _COBJECTS Replace(_COBJECTS p_source, _COBJECTS p_curr)
        {
            p_curr.ID = p_source.ID;
            p_curr.Parent = p_source.Parent;
            p_curr.PID = p_source.PID;
            p_curr.Key = p_source.Key;
            p_curr.PKey = p_source.PKey;
            p_curr.Sort = p_source.Sort;
            p_curr.Deep = 2;
            p_curr.NodeName = p_curr.Name = p_source.Name;
            p_curr.CODE = p_source.CODE;

            this.Current.StructSource.DeleteUnit(p_source);
            this.ObjectList.Remove(p_source.ID);
            this.Current.StructSource.ProjClear(p_source.ID);
            this.Current.StructSource.ModelProject.Add(p_curr);

            //获取到新的单位工程对象
            int unitID = p_curr.ID;
            p_curr.StructSource.SetNewFiled(ref unitID, p_curr as _UnitProject);

            this.InitDataObject(p_curr);
            this.Current.ObjectKey = unitID;
            this.Current.StructSource.ModelProject.AppendUnit(p_curr);
            this.ObjectList.Add(p_curr.ID, p_curr);
            p_curr.StructSource.AcceptChanges();
            foreach (DataRow row in p_curr.StructSource.ModelProjVariable.Rows)
            {
                row["ID"] = p_curr.ID;
                row.AcceptChanges();
                Current.StructSource.ModelProjVariable.Rows.Add(row.ItemArray);
            }

            p_curr.StructSource.ModelMeasures.SetRowStateAsNew();
            p_curr.StructSource.ModelSubSegments.SetRowStateAsNew();
            p_curr.StructSource.ModelOtherProject.SetRowStateAsNew();
            p_curr.StructSource.ModelQuantity.SetRowStateAsNew();
            p_curr.StructSource.ModelIncreaseCosts.SetRowStateAsNew();
            p_curr.StructSource.ModelStandardConversion.SetRowStateAsNew();
            p_curr.StructSource.ModelYTLBSummary.SetRowStateAsNew();
            p_curr.StructSource.ModelMetaanalysis.SetRowStateAsNew();
            p_curr.StructSource.ModelPSubheadingsFee.SetRowStateAsNew();
            p_curr.StructSource.ModelSubheadingsFee.SetRowStateAsNew();
            p_curr.StructSource.ModelInfomation.SetRowStateAsNew();

            this.AddUnit(p_curr);
            p_curr.NeedCalculate = true;

            return p_curr;
        }

        public int GenerateNewID()
        {
            return this.Current.StructSource.ModelProject.AsEnumerable().Max(row => row.Field<int>("ID"));
        }

        private void RebindID(int unID, int enID, _COBJECTS source)
        {
            foreach (DataTable table in source.StructSource.Tables)
            {
                var containsunID = table.Columns.Contains("UnID");
                var containsenID = table.Columns.Contains("EnID");

                if (containsunID && containsenID)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (containsunID)
                        {
                            row["UnID"] = unID;
                        }

                        if (containsenID)
                        {
                            row["EnID"] = enID;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导入逻辑变更
        /// 只处理单位工程导入此处为单位工程集合导入到指定单项工程中
        /// </summary>
        /// <param name="p_source">单项工程</param>
        /// <param name="p_current">单位工程集合ArrayList</param>
        public override void ImportIn(_COBJECTS p_source, ArrayList p_currList)
        {
            try
            {
                //重新设置所有表的UnID EnID

                foreach (object o_obj in p_currList)
                {
                    _COBJECTS obj = o_obj as _COBJECTS;
                    obj.Parent = p_source;
                    //初始化数据
                    //this.AddChild(p_source, obj);
                    this.AddNewUnitProject(p_source, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟指定的单项工程编号下添加单位工程数据(项目导入操作使用)
        /// </summary>
        /// <param name="p_EnID">单项工程编号</param>
        /// <param name="p_Source"></param>
        public void AddNewUnitProject(_COBJECTS p_Info, _COBJECTS p_UnInfo)
        {
            //添加项目表关系
            //_UnitProject info = new _UnitProject();
            //_ObjectSource.GetObject(info, p_UnInfo.StructSource.ModelProject.Rows[0]);

            p_UnInfo.PID = p_Info.ID;
            p_UnInfo.Key = ++this.Current.ObjectKey;
            p_UnInfo.PKey = p_Info.Key;
            p_UnInfo.Sort = ++(this.Current as _Projects).UnSort;
            p_UnInfo.Deep = 2;
            p_UnInfo.CODE = p_Info.CODE + p_UnInfo.Sort.ToString().PadLeft(3, '0');
            //追加后的项目编号
            this.SetKeyNo(p_UnInfo);

            p_UnInfo.ID = this.Current.StructSource.ModelProject.Add(p_UnInfo);
            if (p_UnInfo.StructSource.ModelProject.Rows.Count == 1)
                p_UnInfo.StructSource.ModelProject.Rows[0]["ID"] = p_UnInfo.ID;
            //获取到新的单位工程对象
            int objkey = this.Current.ObjectKey;
            p_UnInfo.StructSource.SetNewFiled(ref objkey, p_UnInfo as _UnitProject);
            this.Current.ObjectKey = objkey;
            this.Current.StructSource.ModelProject.AppendUnit(p_UnInfo);
            this.InitDataObject(p_UnInfo);
            this.ObjectList.Add(p_UnInfo.ID, p_UnInfo);
            p_UnInfo.StructSource.AcceptChanges();
            if (this.Current.StructSource.ModelProjVariable == null)
            {
                this.Current.StructSource.ModelProjVariable = new _VariableSource("变量表");
            }

            p_UnInfo.StructSource.ModelProjVariable.AcceptChanges();
            foreach (DataRow row in p_UnInfo.StructSource.ModelProjVariable.Rows)
            {
                row["ID"] = p_UnInfo.ID;
                row.AcceptChanges();
                Current.StructSource.ModelProjVariable.Rows.Add(row.ItemArray);
            }

            p_UnInfo.StructSource.ModelMeasures.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelSubSegments.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelOtherProject.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelQuantity.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelIncreaseCosts.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelStandardConversion.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelYTLBSummary.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelMetaanalysis.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelPSubheadingsFee.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelSubheadingsFee.SetRowStateAsNew();
            p_UnInfo.StructSource.ModelInfomation.SetRowStateAsNew();
            p_UnInfo.NeedCalculate = true;

        }


        /// <summary>
        /// 将当前的单项工程导入到源数据中(此方法暂时停用)
        /// </summary>
        /// <param name="p_source"></param>
        /// <param name="p_current"></param>
        private void importEn(_COBJECTS p_source, _COBJECTS p_current)
        {
            /*
            p_current.CDirectories.ParentFieldName = p_source.CDirectories.Key;
            p_current.CDirectories.ImageIndex = 1;
            p_current.CDirectories.TypeName = 操作类型.单项工程;
            p_source.CDirectories.AcceptChanges(p_current.CDirectories);
            p_source.CObjectList.Add(p_current.CDirectories.Key, p_current);

            //下属所有的单位工程添加到项目中
            Hashtable table = new Hashtable();
            foreach (_COBJECT obj in p_current.CObjectList.Values)
            {
                obj.CDirectories.ParentFieldName = p_current.CDirectories.Key;
                p_source.CDirectories.AcceptChanges(obj.CDirectories);
                table.Add(obj.CDirectories.Key, obj);
            }
            p_current.CObjectList = table;*/
        }

        /// <summary>
        /// 加载获取对象数据
        /// </summary>
        /// <param name="p_info"></param>
        public override void Load(_COBJECTS p_info)
        {
            //base.Load(p_info);
            //this.Current = p_info;
            //初始化数据对象
            //this.InitDataObject(this.Current);
            //读取数据
            this.OpenDataBase();
            this.DataBase.Load(p_info);
            this.InitDataObject(p_info);
            this.AddUnit(p_info);
            //this.Close(true);
        }

        /// <summary>
        /// 加载已经存在项目中的单位工程(保证一次链接完成，p_OnlyOneConn为true不关闭现有的业务链接)
        /// </summary>
        /// <param name="p_info"></param>
        /// <param name="p_OnlyOneConn"></param>
        public override void Load(_COBJECTS p_info, bool p_OnlyOneConn)
        {
            this.OpenDataBase();
            this.DataBase.Load(p_info);
            this.InitDataObject(p_info);
            //if (!p_OnlyOneConn)
            //{
            //    this.Close(true);
            //}
        }


        /// <summary>
        /// 当前业务打开一个项目操作
        /// </summary>
        public override CResult Open(_Files p_Files)
        {
            //创建偶一个新的项目对象
            this.Current = new _Projects();
            this.Current.Files = p_Files;
            //读取数据
            this.OpenDataBase();
            this.DataBase.Load(this.Current);
            //this.Current.InSerializable(p_Files);
            APP.Methods.Init(this.Current);
            return null;
        }

        public override void SetKeyNo()
        {
            base.SetKeyNo();
            foreach (_UnitProject unit in this.ObjectList.Values)
            {
                this.SetKeyNo(unit);
                this.Current.StructSource.ModelProject.UpDate(unit);
            }
        }

        /// <summary>
        /// 保存当前项目业务
        /// </summary>
        /// <returns></returns>
        public override CResult Save()
        {
            //var formatter = new BinaryFormatter();


            //if (File.Exists(@"e:/a.txt"))
            //{
            //    //  ObjectList = formatter.Deserialize(File.Open(@"e:/a.txt", FileMode.Open)) as Hashtable;

            //    var a = formatter.Deserialize(File.Open(@"e:/a.txt", FileMode.Open)) as _StructSource;
            //}
            //else
            //{
            //    var stream = File.Create(@"e:/a.txt");

            //    foreach (var unit in ObjectList.Values)
            //    {
            //        var u = unit as _UnitProject;
            //        var set = u.StructSource ;
            //        formatter.Serialize(stream, set);

            //        stream.Flush();
            //        stream.Close();
            //        break;
            //    }

            //}


            //return base.Save();
            //
            //this.Close(true);
            //项目文件是否已经存在不存在创建
            FileInfo file = new FileInfo(this.Current.Files.FullName);
            if (!file.Exists)
            {
                _ObjectDataBase.CreateFile(this.Current);
            }

            //保存之前计算
            //this.Calculate();
            //每次保存对象key
            this.Current.StructSource.ModelInfomation.Set("ObjectKey", this.Current.ObjectKey);
            //保存前调用
            this.SetKeyNo();
            this.OpenDataBase();
            //通知单位工程赋值加密锁
            this.DataBase.SetKey += new _ObjectDataBase.OnSetKeyHandler(DataBase_SetKey);
            ///开启数据
            this.ProjDataBase.Save();
            this.DataBase.SetKey -= new _ObjectDataBase.OnSetKeyHandler(DataBase_SetKey);
            this.Close();
            return base.Save();
        }

        /*public void Save(_UnitProject p_Info)
        {
            this.OpenDataBase();
            //通知单位工程赋值加密锁
            this.DataBase.SetKey += new _ObjectDataBase.OnSetKeyHandler(DataBase_SetKey);
            ///开启数据
            this.ProjDataBase.Save(p_Info);
            this.DataBase.SetKey -= new _ObjectDataBase.OnSetKeyHandler(DataBase_SetKey);
        }*/

        void DataBase_SetKey(_COBJECTS sender)
        {
            this.SetKeyNo(sender);
        }


        /// <summary>
        /// 获取对象根据字节
        /// </summary>
        /// <param name="p_Info"></param>
        /// <returns></returns>
        public _COBJECTS GetObject(object p_Info)
        {
            byte[] bs = p_Info as byte[];
            if (bs != null)
            {
                //获取的对象需要同步DataRow数据
                _COBJECTS info = this.ProjDataBase.GetObjectByte(bs) as _COBJECTS;
                return info;
            }
            return null;
        }

        


        public override void FastCalculate()
        {
            try
            {

                //合并数据项目结构数据
                this.Current.StructSource.MergeData();
                //计算数据
                _Project_Statistics sta = null;
                //循环计算
                foreach (_UnitProject info in this.ObjectList.Values)
                {
                    if (info.NeedCalculate)
                    {
                        sta = new _Project_Statistics(info, this);
                        sta.CalculateWithouSubsegment();

                        //删除当前单位工程下数据
                        DataTable table = null;
                        //分部分项表
                        table = info.StructSource.ModelSubSegments;
                        if (table != null)
                            this.Current.StructSource.ModelSubSegments.MergeData(table);
                        //措施项目表
                        table = info.StructSource.ModelMeasures;
                        if (table != null)
                            this.Current.StructSource.ModelMeasures.MergeData(table);
                        //其他项目表
                        table = info.StructSource.ModelOtherProject;
                        if (table != null)
                            this.Current.StructSource.ModelOtherProject.MergeData(table);
                        //工料机
                        table = info.StructSource.ModelQuantity;
                        if (table != null)
                            this.Current.StructSource.ModelQuantity.MergeData(table);

                        //汇总分析表
                        table = info.StructSource.ModelMetaanalysis;
                        if (table != null)
                            this.Current.StructSource.ModelMetaanalysis.MergeData(table);

                        //计算结果表
                        table = info.StructSource.ModelProjVariable;
                        if (table != null)
                            this.Current.StructSource.ModelProjVariable.MergeData(table);

                        info.NeedCalculate = false;
                    }
                }

                //参数累加计算
                this.Current.StructSource.Statistics();
                //保存数据
                //this.Save();
                //重新读取当前项目数据
                //this.Load();

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// 计算汇总当前项目数据
        /// </summary>
        public override void Calculate()
        {

            //合并数据项目结构数据
            this.Current.StructSource.MergeData();
            //计算数据
            _Project_Statistics sta = null;
            //循环计算
            foreach (_UnitProject info in this.ObjectList.Values)
            {

                var projectStatistics = new _Project_Statistics(info, this);
                //计算，合并新的数据集合
                projectStatistics.Calculate();

                //删除当前单位工程下数据
                //this.Current.StructSource.ProjClearCalculate(info);
                DataTable table = null;
                //分部分项表
                table = info.StructSource.ModelSubSegments.GetChanges();
                if (table != null)
                {
                    this.Current.StructSource.ModelSubSegments.MergeData(table);
                }
                //措施项目表
                table = info.StructSource.ModelMeasures.GetChanges();
                if (table != null)
                    this.Current.StructSource.ModelMeasures.MergeData(table);
                //其他项目表
                table = info.StructSource.ModelOtherProject.GetChanges();
                if (table != null)
                    this.Current.StructSource.ModelOtherProject.MergeData(table);
                //工料机
                table = info.StructSource.ModelQuantity.GetChanges();
                if (table != null)
                    this.Current.StructSource.ModelQuantity.MergeData(table);
                //计算结果表
                table = info.StructSource.ModelProjVariable.GetChanges();
                if (table != null)
                    this.Current.StructSource.ModelProjVariable.MergeData(table);
                //汇总分析表
                table = info.StructSource.ModelMetaanalysis.GetChanges();
                if (table != null)
                    this.Current.StructSource.ModelMetaanalysis.MergeData(table);

            }
            //参数累加计算
            this.Current.StructSource.Statistics();
            //保存数据
            //this.Save();
            //重新读取当前项目数据
            //this.Load();

        }

        /// <summary>
        /// 计算汇总当前项目数据
        /// </summary>
        public void CalculateForXml()
        {

            //合并数据项目结构数据
            //this.Current.StructSource.MergeData();
            //计算数据
            this.BeginData();
            this.ProjDataBase.MyTran = this.DBTran as System.Data.OleDb.OleDbTransaction;


            _Project_Statistics sta = null;
            //循环项目结构表进行计算
            this.BeginData();
            foreach (_UnitProject info in this.ObjectList.Values)
            {
                if (info.Deep == 2)
                {
                    info.JJJC = APP.JJJC;
                    this.LoadForXml(info);
                    this.ProjDataBase.MyTran = this.DBTran as System.Data.OleDb.OleDbTransaction;
                    sta = new _Project_Statistics(info, this);
                    //计算，合并新的数据集合
                    sta.Calculate();
                    this.ProjDataBase.Save(info, this.ProjDataBase.MyTran);
                }
            }
            
            //foreach (DataRow row in this.Current.StructSource.ModelProject.Rows)
            //{
            //    if (row["DEEP"].Equals(2))
            //    {
            //        info = new _UnitProject();
            //        info.JJJC = APP.JJJC;
            //        _ObjectSource.GetObject(info, row);
            //        //还原单位工程并且计算
            //        this.LoadForXml(info);
            //        this.BeginData();
            //        this.ProjDataBase.MyTran = this.DBTran as System.Data.OleDb.OleDbTransaction;
            //        sta = new _Project_Statistics(info, this);
            //        //计算，合并新的数据集合
            //        sta.Calculate();
            //        //row["UnitProject"] = info;
            //        this.ProjDataBase.Save(info, this.ProjDataBase.MyTran);
            //    }
            //}

            this.EndData();
            this.ProjDataBase.MyTran = null;
            //参数累加计算
            //this.Current.StructSource.Statistics();
            //保存数据
            //this.Save();
            //重新读取当前项目数据
            //this.Load();
        }

        /// <summary>
        /// 加载获取对象数据
        /// </summary>
        /// <param name="p_info"></param>
        public void LoadForXml(_COBJECTS p_info)
        {
            //base.Load(p_info);
            //this.Current = p_info;
            //初始化数据对象
            //this.InitDataObject(this.Current);
            //读取数据
            // this.OpenDataBase();
            this.ProjDataBase.MyTran = this.DBTran as System.Data.OleDb.OleDbTransaction;
            this.DataBase.Load(p_info);
            this.InitDataObject(p_info);
            //this.Close(true);
        }



        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            //读取数据
            this.OpenDataBase();
            //重新读取项目
            this.DataBase.Load(this.Current, false);
            //this.Close(true);
        }


        /// <summary>
        /// 关闭当前业务的时候调用
        /// </summary>
        public override void Close()
        {
            this.DBTran = null;

            if (this.DataBase != null)
            {
                this.DataBase.Close();
                this.DataBase = null;
            }
            //释放当前业务资源
            //m_ObjectList = null;
            System.GC.Collect();
        }

        /// <summary>
        /// 如果需要对文件进行操作调用此方法用于释放文件资源
        /// </summary>
        public void ReadyUseFile()
        {
        ABC:
            if (_ObjectDataBase.IsUse(this.Current.Files.FullName))
            {
                return;
            }
            else
            {
                this.DBTran = null;

                if (this.DataBase != null)
                {
                    this.DataBase.Close();
                    this.DataBase = null;
                }
                System.GC.Collect();
                //Thread.Sleep(500);
                goto ABC;
            }
        }

        /// <summary>
        /// 关闭当前业务的时候调用
        /// </summary>
        //public  void Close(bool p_flag)
        //{
        //    ABC:if (_ObjectDataBase.IsUse(this.Current.Files.FullName))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        this.DBTran = null;

        //        if (this.DataBase != null)
        //        {
        //            this.DataBase.Close();
        //            this.DataBase = null;
        //        }
        //        System.GC.Collect();
        //        //Thread.Sleep(500);
        //        goto ABC;
        //    }
        //}
    }
}
