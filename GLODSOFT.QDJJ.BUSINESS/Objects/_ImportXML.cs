using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.ZBS;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Threading;
/*************zbs，bd 等文件的导入处理**************/
namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _ImportXML
    {
        /// <summary>
        /// 总项目个数
        /// </summary>
        public int Count 
        {
            get
            {
                if (this.建设项目 != null)
                {
                    int res = 0;
                    foreach (单项工程 item in m_建设项目.单项工程)
                    {
                        if (item.单位工程!=null)
                        res += item.单位工程.Length+1;
                    }
                    return res;
                }
                return 0;
            }
        }

        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event RevertXmlObject RevertXmlObject;

        /// <summary>
        /// 当选择模块发生变化之后激发
        /// </summary>
        public virtual void OnRevertXmlObject(object sender, object args)
        {
            if (RevertXmlObject != null)
            {
                this.RevertXmlObject(sender, args);
            }
        }

        public _ImportXML()
        {

        }
        private _Business m_Business;
        public _ImportXML(_Business bus)
        {
            this.m_Business = bus;


        }
        private string m_FileName;
        private 建设项目 m_建设项目;
        /// <summary>
        /// 反序列化后的类建设项目
        /// </summary>
        public 建设项目 建设项目
        {
            get { return m_建设项目; }
            set { m_建设项目 = value; }
        }
        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

      
        private _Projects m_CProjects;
        /// <summary>
        /// 正在操作的 项目
        /// </summary>
        public _Projects CProjects
        {
            get { return m_CProjects; }
            set { m_CProjects = value; }
        }
        public _Projects Import()
        {
           
            this.m_Business.Create();
            this.m_CProjects = this.m_Business.Current as _Projects;
            this.m_CProjects.Property.Name = m_建设项目.项目名称;
            this.m_Business.EndCreate();
            //APP.WorkFlows.Container.EndCreate();
            foreach (单项工程 item in m_建设项目.单项工程)
            {
                
                _Engineering Engineering = this.m_CProjects.Create() as _Engineering;
                SetEngineering(Engineering, item);
            }
            //  this.m_Business.EndCreate();
            return this.m_CProjects;
            // return null;
        }

       // public delegate void ParameterizedThreadStart(_Engineering e,_UnitProject u,单位工程 d);

        /// <summary>
        /// 单项工程赋值
        /// </summary>
        /// <param name="Engineering"></param>
        /// <param name="dx"></param>
        private void SetEngineering(_Engineering Engineering, 单项工程 dx)
        {
            Engineering.Property.Name = dx.单项工程名称;
            OnRevertXmlObject(this, Engineering);
            // APP.WorkFlows.Container.AddChild(this.m_CProjects, Engineering);
            (this.m_Business as _Pr_Business).Add(Engineering);
            if (dx.单位工程 == null) return;
            foreach (单位工程 item in dx.单位工程)
            {
                
                _UnitProject UnitProject = Engineering.Create();
                SetInfo info = new SetInfo();
                info.Engineering = Engineering;
                info.UnitProject = UnitProject;
                info.dw = item;
                //StartThread(info);
                SetUnitProject(Engineering, UnitProject, item);
            }
        }

        private void StartThread(SetInfo info)
        {
            _UnitProject UnitProject = info.UnitProject;
            单位工程 item = info.dw;
            _Engineering Engineering = info.Engineering;
            UnitProject.Property.Basis.Name = item.单位工程名称;
            UnitProject.Directory.NodeName = item.单位工程名称;
            UnitProject.Property.Basis.DEGZ = this.m_建设项目.招标信息表.计价依据.ToString();
            UnitProject.Property.Basis.QDGZ = this.m_建设项目.招标信息表.计价依据.ToString();

            SetLibName(UnitProject, item);
            (this.m_Business as _Pr_Business).AddChild(Engineering, UnitProject);
            //UnitProject.Init(APP.Application);
            APP.Methods.Init(UnitProject);
            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SetUnitProject), info);
        }

        struct SetInfo
        {
            public _Engineering Engineering;
            public 单位工程 dw;
            public _UnitProject UnitProject;
        }  

     
        private void SetLibName(_UnitProject UnitProject, 单位工程 dx)
        {
            UnitProject.Property.DLibraries.ListGallery.Rule = UnitProject.Property.Basis.QDGZ;
            UnitProject.Property.DLibraries.FixedLibrary.Rule = UnitProject.Property.Basis.DEGZ;

            if (dx.清单专业.Contains("安装"))
            {
                UnitProject.Property.DLibraries.ListGallery.LibName = "安装清单库";
                UnitProject.Property.DLibraries.FixedLibrary.LibName = "安装定额价目表";
            }

            if (dx.清单专业.Contains("建筑"))
            {
                UnitProject.Property.DLibraries.ListGallery.LibName = "建筑清单库";
                UnitProject.Property.DLibraries.FixedLibrary.LibName = "建筑装饰定额价目表";
            }
            if (dx.清单专业.Contains("绿化"))
            {
                UnitProject.Property.DLibraries.ListGallery.LibName = "园林绿化清单库";
                UnitProject.Property.DLibraries.FixedLibrary.LibName = "绿化定额价目表";
            }
            if (dx.清单专业.Contains("市政"))
            {
                UnitProject.Property.DLibraries.ListGallery.LibName = "市政清单库";
                UnitProject.Property.DLibraries.FixedLibrary.LibName = "市政定额价目表";
            }

        }


        private void SetUnitProject(object o)
        {
            SetInfo info = (SetInfo)o;
            _Engineering Engineering=info.Engineering;
            _UnitProject UnitProject=info.UnitProject; 
            单位工程 dx=info.dw;

            SetOtherProject(UnitProject.Property.OtherProject, dx.其他项目表,dx);

            _Common.Activitie = UnitProject;//给当前的单位工程赋值



            #region 分部分项对象以及赋值
            //UnitProject.Property.SubSegments = new _SubSegments(UnitProject);//分部分项对象
            SetSubSegments(UnitProject.Property.SubSegments, dx.分部分项表,UnitProject,dx);
            #endregion


            #region 措施项目对象以及赋值
            //UnitProject.Property.MeasuresProject = new _MeasuresProject(UnitProject);//措施项目对象
            //UnitProject.Property.MeasuresProject.IsInit = false;
            SetMeasuresProject(UnitProject.Property.MeasuresProject, dx.措施项目表,UnitProject,dx);
            #endregion

            //UnitProject.Property.Metaanalysis = new _Metaanalysis(UnitProject);//单位工程汇总对象
            //UnitProject.Property.Metaanalysis.IsInit = false;
            SetMetaanalysis(UnitProject.Property.Metaanalysis,dx);


            // UnitProject.Property.QuantityUnitSummaryList = new _QuantityUnitSummaryList(UnitProject);



        }

        /// <summary>
        /// 单位工程赋值
        /// </summary>
        /// <param name="Engineering"></param>
        /// <param name="UnitProject"></param>
        /// <param name="dx"></param>
        private void SetUnitProject(_Engineering Engineering, _UnitProject UnitProject, 单位工程 dx)
        {
            //this.m_DWGC = dx;
            //m_UnitProject = UnitProject;
            UnitProject.Property.Basis.Name = dx.单位工程名称;
            //通知正在处理的单位工程
            OnRevertXmlObject(this, UnitProject);
            UnitProject.Directory.NodeName = dx.单位工程名称;
            UnitProject.Property.Basis.DEGZ = this.m_建设项目.招标信息表.计价依据.ToString();
            UnitProject.Property.Basis.QDGZ = this.m_建设项目.招标信息表.计价依据.ToString();

            SetLibName(UnitProject, dx);
            //APP.WorkFlows.Container.AddChild(Engineering, UnitProject);
            (this.m_Business as _Pr_Business).AddChild(Engineering, UnitProject);
            //UnitProject.Property.OtherProject = new _OtherProject(UnitProject);//其他项目对象
            //UnitProject.Property.OtherProject.IsInit = false;
            //UnitProject.Init(APP.Application);
            APP.Methods.Init(UnitProject);
            SetOtherProject(UnitProject.Property.OtherProject, dx.其他项目表,dx);

            _Common.Activitie = UnitProject;//给当前的单位工程赋值



            #region 分部分项对象以及赋值
            //UnitProject.Property.SubSegments = new _SubSegments(UnitProject);//分部分项对象
            SetSubSegments(UnitProject.Property.SubSegments, dx.分部分项表, UnitProject, dx);
            #endregion


            #region 措施项目对象以及赋值
            //UnitProject.Property.MeasuresProject = new _MeasuresProject(UnitProject);//措施项目对象
            //UnitProject.Property.MeasuresProject.IsInit = false;
            SetMeasuresProject(UnitProject.Property.MeasuresProject, dx.措施项目表, UnitProject,dx);
            #endregion

            //UnitProject.Property.Metaanalysis = new _Metaanalysis(UnitProject);//单位工程汇总对象
            //UnitProject.Property.Metaanalysis.IsInit = false;
            SetMetaanalysis(UnitProject.Property.Metaanalysis,dx);


            // UnitProject.Property.QuantityUnitSummaryList = new _QuantityUnitSummaryList(UnitProject);



        }
        /// <summary>
        /// 汇总分析赋值
        /// </summary>
        /// <param name="m"></param>
        private void SetMetaanalysis(_Metaanalysis m,单位工程 m_DWGC)
        {
            if (m_DWGC.单位工程造价汇总表.单位工程费用项 == null) return;
            m.IsInit = true;
            m.Load(GetMetaanalysisTemplet(m_DWGC));//根据条件载入汇总分析模板
            foreach (单位工程费用项 item in m_DWGC.单位工程造价汇总表.单位工程费用项)
            {
                IEnumerable<DataRow> rows = from row in m.Source.AsEnumerable()
                                            where item.费用名称.Contains(row["Name"].ToString())
                                            select row;
                if (rows.Count() > 0)
                {
                    DataRow row = rows.First();
                    row["Coefficient"] = item.费率;
                    // row["Price"] = item.金额;
                }
            }
            foreach (规费税金项 item in m_DWGC.规费税金清单表.规费税金项)
            {
                IEnumerable<DataRow> rows = from row in m.Source.AsEnumerable()
                                            where item.费用名称.Contains(row["Name"].ToString())
                                            select row;
                if (rows.Count() > 0)
                {
                    DataRow row = rows.First();
                    row["Coefficient"] = item.费率;
                    // row["Price"] = item.金额;
                }
            }

            foreach (措施项目标题 item1 in m_DWGC.措施项目表.措施项目标题)
            {

                foreach (措施项目清单 item in item1.措施项目清单)
                {

                    IEnumerable<DataRow> rows = from row in m.Source.AsEnumerable()
                                                where item.名称.Contains(row["Name"].ToString())
                                                select row;
                    if (rows.Count() > 0)
                    {
                        DataRow row = rows.First();
                        row["Coefficient"] = item.费率;
                        //  row["Price"] = item.综合合价;
                    }
                }
            }

        }
        /// <summary>
        /// 根据条件获取汇总分析模板
        /// </summary>
        /// <returns></returns>
        private string GetMetaanalysisTemplet(单位工程 m_DWGC)
        {

            string filename = "2012汇总分析表【不扣劳保】.hzfx";

            IEnumerable<单位工程费用项> qzaq = from info in m_DWGC.单位工程造价汇总表.单位工程费用项
                                        where info.费用名称.Contains("其中：安全文明施工措施费")
                                        select info;
            IEnumerable<单位工程费用项> aqxm = from info in m_DWGC.单位工程造价汇总表.单位工程费用项
                                        where info.费用名称.Contains("安全文明施工措施项目费")
                                        select info;

            IEnumerable<单位工程费用项> fbfx = from info in m_DWGC.单位工程造价汇总表.单位工程费用项
                                        where info.序号.Contains("F1.")
                                        select info;
            单位工程费用项 last = m_DWGC.单位工程造价汇总表.单位工程费用项[m_DWGC.单位工程造价汇总表.单位工程费用项.Length - 1];

            int Qzaq = qzaq.Count();
            int Aqxm = aqxm.Count();
            int Fbfx = fbfx.Count();
            string Last = last.取费基数;
            if (Qzaq < 0 && Aqxm < 0 && Last.Split('-').Length == 3)
            {
                filename = "2004汇总分析表【扣劳保和定额测定费】.hzfx";
            }
            if (Qzaq < 1 && Aqxm < 1 && Last.Split('-').Length == 2)
            {
                filename = "2004汇总分析表【只扣劳保】.hzfx";
            }

            if (Qzaq < 1 && Aqxm < 1 && Last.Split('+').Length == 2)
            {
                filename = "2004汇总分析表【不扣劳保和定额测定费】.hzfx";
            }

            if (Qzaq < 1 && Aqxm > 0 && Last.Split('+').Length == 2)
            {
                filename = "2006汇总分析表(232号文件)【不扣劳保和定额测定费】.hzfx";
            }

            if (Qzaq < 1 && Aqxm > 0 && Last.Split('-').Length == 2)
            {
                filename = "2006汇总分析表(232号文件)【只扣劳保】.hzfx";
            }

            if (Qzaq < 1 && Aqxm > 0 && Last.Split('-').Length == 3)
            {
                filename = "2006汇总分析表(232号文件)【扣劳保和定额测定费】.hzfx";
            }

            if (Fbfx < 1 && Qzaq > 0 && Aqxm < 1 && Last.Split('-').Length == 2)
            {
                filename = "2009汇总分析表【扣劳保】.hzfx";
            }
            if (Fbfx < 1 && Qzaq > 0 && Aqxm < 1 && Last.Split('+').Length == 2)
            {
                filename = "2009汇总分析表【不扣劳保】.hzfx";
            }
            if (Qzaq > 0 && Aqxm < 1 && Last.Split('-').Length == 2)
            {
                filename = "2012汇总分析表【扣劳保】.hzfx";
            }
            if (Qzaq > 0 && Aqxm < 1 && Last.Split('+').Length == 2)
            {
                filename = "2012汇总分析表【不扣劳保】.hzfx";
            }

            filename = APP.Application.Global.AppFolder + "模板文件\\汇总分析模板\\" + filename;
            return filename;


        }

        /// <summary>
        /// 其他项目赋值
        /// </summary>
        /// <param name="other"></param>
        /// <param name="qt"></param>

        private void SetOtherProject(_OtherProject other, 其他项目表 qt,单位工程 m_DWGC)
        {
            if (qt.其他项目清单 == null) return;
            string str = string.Empty;

            //other.Source = APP.Application.Global.DataTamp.LoadOtherProject(other.Parent.Property.Basis.PGCDD, out str).Clone();
            other.Source.PrimaryKey = new DataColumn[] { other.Source.Columns["id"] };
            DataColumn col = other.Source.Columns["id"];
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            col.AutoIncrementStep = 1;
            DataRow row = other.Add();
            row["Name"] = "其他项目";
            row["IsSys"] = true;
            bool IsLX = false;//标识是否有零星项目

            if (m_DWGC.零星项目表 != null)
            {
                IsLX = true;
            }
            foreach (其他项目清单 item in qt.其他项目清单)
            {
                DataRow crow = other.Add_Child(row);



                # region 含有计日工
                if (!IsLX)
                {

                    crow["Name"] = item.项目名称;
                    crow["Unit"] = item.计量单位;
                    crow["Quantities"] = item.工程数量;
                    crow["IsSys"] = true;
                    if (item.费用类型.Contains("暂列金额"))
                    {
                        if (qt.暂列金额明细表.暂列金额明细!=null)
                        {
                            
                       
                        foreach (暂列金额明细 itemz in qt.暂列金额明细表.暂列金额明细)
                        {
                            DataRow zrow = other.Add_Child(crow);
                            zrow["Name"] = itemz.项目名称;
                            zrow["Unit"] = itemz.计量单位;
                            zrow["Quantities"] = "0";
                            zrow["IsSys"] = false;
                        }
                        }
                    }

                    if (item.费用类型.Contains("专业工程暂估"))
                    {
                        if (qt.专业工程暂估价明细表.专业工程暂估明细!=null)
                        {
                            
                    
                        foreach (专业工程暂估明细 itemz in qt.专业工程暂估价明细表.专业工程暂估明细)
                        {
                            DataRow zrow = other.Add_Child(crow);
                            zrow["Name"] = itemz.项目名称;
                            zrow["Unit"] = itemz.计量单位;
                            zrow["Quantities"] = "0";
                            zrow["IsSys"] = false;
                        }
                        }
                    }

                    if (item.费用类型.Contains("总承包服务费"))
                    {
                        if (qt.总承包服务费项目表.总承包服务费项 != null)
                        {
                            foreach (总承包服务费项 itemz in qt.总承包服务费项目表.总承包服务费项)
                            {
                                DataRow zrow = other.Add_Child(crow);
                                zrow["Name"] = itemz.项目名称;
                                zrow["Unit"] = itemz.计量单位;
                                zrow["Quantities"] = "0";
                                zrow["IsSys"] = false;
                            }
                        }
                    
                    }
                    if (item.费用类型.Contains("计日工"))
                    {
                        string[] names = { "人工", "材料", "机械" };
                        foreach (string name in names)
                        {
                            DataRow zrow = other.Add_Child(crow);
                            zrow["Name"] = name;
                            zrow["Quantities"] = "0";
                            zrow["IsSys"] = false;
                            if (qt.计日工表.计日工项 != null)
                            {


                                if (qt.计日工表.计日工项.Count > 0)
                                {
                                    IEnumerable<计日工项> jr = from info in qt.计日工表.计日工项
                                                           where info.类别 == name
                                                           select info;
                                    if (jr.Count() > 0)
                                    {
                                        计日工项 jrgx = jr.First();
                                        DataRow zrow1 = other.Add_Child(zrow);
                                        zrow1["Name"] = jrgx.名称;
                                        zrow["Unit"] = jrgx.单位;
                                        zrow1["Quantities"] = jrgx.暂定数量;
                                    }
                                }
                            }
                        }
                    }

                }

                # endregion
                else
                {

                    crow["Name"] = item.名称;
                    crow["Unit"] = item.单位;
                    crow["Quantities"] = item.工程量;
                    crow["IsSys"] = true;
                    if (item.计算基础.Contains("零星工作费"))
                    {
                        if (m_DWGC.零星项目表.零星项目标题!=null)
                        {
                        foreach (零星项目标题 itemz in m_DWGC.零星项目表.零星项目标题)
                        {
                            //DataRow zrow = other.Add_Child(crow);
                            //zrow["Name"] = itemz.名称;
                            ////zrow["Unit"] = itemz.计量单位;
                            //zrow["Quantities"] = "0";
                            foreach (零星项目 iteml in itemz.零星项目)
                            {
                                DataRow lrow = other.Add_Child(crow);
                                lrow["Name"] = iteml.名称;
                                lrow["Unit"] = iteml.单位;
                                lrow["Quantities"] = iteml.数量;
                                lrow["IsSys"] = false;
                            }
                        }}
                    }
                }
            }


                }

        /// <summary>
        /// 措施项目赋值
        /// </summary>
        /// <param name="MeasuresProject"></param>
        /// <param name="dx"></param>
        private void SetMeasuresProject(_MeasuresProject m, 措施项目表 dx, _UnitProject m_UnitProject, 单位工程 m_DWGC)
        {
            if (dx.措施项目标题 == null) return;

            foreach (措施项目标题 item in dx.措施项目标题)
            {
                _CommonrojectInfo _com = new _CommonrojectInfo(m);
                _com.XMBM = item.名称;
                _com.GCL = 1m;
                m.Create(_com);//通用项目添加到措施项目
                SetMFixed(_com, item, m_UnitProject, m_DWGC);
            }
        }

        /// <summary>
        /// //措施项目清单赋值
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dx"></param>
        private void SetMFixed(_CommonrojectInfo m, 措施项目标题 dx, _UnitProject m_UnitProject, 单位工程 m_DWGC)
        {

            _MFixedListInfo Minfo = null;
            foreach (措施项目清单 item in dx.措施项目清单)
            {
                //若是措施项则创建清单否则的话认为是子目并添加到上次的清单里面
                if (item.行类别 == "措施项")
                {
                    //qd = item;
                    _MFixedListInfo info = new _MFixedListInfo(m);
                    Minfo = info;
                    info.XH2 = ToolKit.ParseInt(item.序号);
                    info.XMMC = item.名称;
                    info.LB = "清单";
                    info.DW = item.单位;
                    info.SetGCL(ToolKit.ParseDecimal(item.数量));
                    info.JSJC = GetFormula(item.计费基础表达式);
                    info.FL = item.费率;
                    info.LibraryName = m_UnitProject.Property.Libraries.ListGallery.FullName;

                    // ToolKit.ParseDecimal(item.费率);
                    // info.ZHHJ = ToolKit.ParseDecimal(item.综合合价);
                    if (item.公式组价)
                    {
                        info.ZJFS = "直接组价";
                    }
                    m.Create(info);
                    if (item.定额子目 != null)
                    {
                        if (item.定额子目.Count > 0)
                        {
                            SetSubheadings(info, item.定额子目, m_UnitProject,m_DWGC);
                        }
                    }

                }
                else
                {
                    if (Minfo != null && !item.名称.Contains("安全文明施工"))
                    {
                        _MSubheadingsInfo info = new _MSubheadingsInfo();
                        info.XMMC = item.名称;
                        info.LB = "子目";
                        info.DW = item.单位;
                        info.GCL = ToolKit.ParseDecimal(item.数量);
                        info.JSJC = GetFormula(item.计费基础表达式);
                        info.FL = item.费率;// ToolKit.ParseDecimal(item.费率);
                        info.LibraryName = m_UnitProject.Property.Libraries.FixedLibrary.FullName;
                        if (item.公式组价)
                        {
                            info.ZJFS = "直接组价";
                        }
                        Minfo.Create(info);

                    }
                }
            }
        }

        /// <summary>
        /// 分部分项清单赋值
        /// </summary>
        /// <param name="SubSegment"></param>
        /// <param name="dx"></param>
        private void SetSubSegments(_SubSegments SubSegment, 分部分项表 dx, _UnitProject m_UnitProject, 单位工程 m_DWGC)
        {
            if (dx.分部分项清单 == null)
            {
                return;
            }

            foreach (分部分项清单 item in dx.分部分项清单)
            {
                _FixedListInfo info = new _FFixedListInfo();
                info.LibraryName = SubSegment.Parent.Property.Libraries.ListGallery.FullName;

                info.XMBM = item.清单编码;
                info.OLDXMBM = info.XMBM.Substring(0, info.XMBM.Length - 3);
                info.XMMC = item.名称;
                info.DW = item.单位;
                info.SetGCL( ToolKit.ParseDecimal(item.数量));
                info.LB = "清单";
                info.ZHDJ = ToolKit.ParseDecimal(item.综合单价);
                info.ZHHJ = ToolKit.ParseDecimal(item.综合合价);
                info.RGFDJ = ToolKit.ParseDecimal(item.人工费单价);
                info.CLFDJ = ToolKit.ParseDecimal(item.材料费单价);
                info.JXFDJ = ToolKit.ParseDecimal(item.机械费单价);
                info.ZCFDJ = ToolKit.ParseDecimal(item.主材费单价);
                info.SBFDJ = ToolKit.ParseDecimal(item.设备费单价);
                info.GLFDJ = ToolKit.ParseDecimal(item.管理费单价);
                info.LRDJ = ToolKit.ParseDecimal(item.利润单价);
                info.LRDJ = ToolKit.ParseDecimal(item.利润单价);
                info.FXDJ = ToolKit.ParseDecimal(item.风险单价);
                info.GFDJ = ToolKit.ParseDecimal(item.规费单价);
                info.SJDJ = ToolKit.ParseDecimal(item.税金单价);
                info.ZYQD = item.主要清单;
                info.ZJWZ = "";
                System.Data.DataTable dt = SubSegment.Parent.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"];
                if (dt != null)
                {
                    System.Data.DataRow[] rows = dt.Select(string.Format("QINGDBH='{0}'", info.OLDXMBM));
                    if (rows.Length > 0)
                    {
                        info.ZJWZ = rows[0]["QINGDSYBH"].ToString();
                    }
                    if (string.IsNullOrEmpty(info.ZJWZ))
                    {
                        info.ZJWZ = "999999";
                    }
                }
                SubSegment.Create(info);//清单创建完毕
               
                SetSubheadings(info, item.定额子目, m_UnitProject,m_DWGC);


            }
        }
        /// <summary>
        /// 子目赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="de"></param>
        private void SetSubheadings(_ObjectInfo info, List<定额子目> de, _UnitProject m_UnitProject, 单位工程 m_DWGC)
        {
           
                _FixedListInfo info1 = info as _FixedListInfo;
                _MFixedListInfo info2 = info as _MFixedListInfo;
                foreach (定额子目 item in de)
                {
                    _ObjectInfo sinfo;

                    if (info1 != null)
                    {
                        sinfo = new _SubheadingsInfo();
                    }
                    else
                    {
                        sinfo = new _MSubheadingsInfo();
                    }


                    sinfo.XMBM = item.定额号;
                    sinfo.OLDXMBM = item.定额号;
                    sinfo.XMMC = item.名称;
                    sinfo.DW = item.单位;
                    sinfo.GCL = ToolKit.ParseDecimal(item.数量);
                    sinfo.ZHDJ = ToolKit.ParseDecimal(item.综合单价);
                    sinfo.ZHHJ = ToolKit.ParseDecimal(item.综合合价);
                    sinfo.RGFDJ = ToolKit.ParseDecimal(item.人工费单价);
                    sinfo.CLFDJ = ToolKit.ParseDecimal(item.材料费单价);
                    sinfo.JXFDJ = ToolKit.ParseDecimal(item.机械费单价);
                    sinfo.ZCFDJ = ToolKit.ParseDecimal(item.主材费单价);
                    sinfo.SBFDJ = ToolKit.ParseDecimal(item.设备费单价);
                    sinfo.LB = "子目";
                    sinfo.GLFDJ = ToolKit.ParseDecimal(item.管理费单价);
                    sinfo.LRDJ = ToolKit.ParseDecimal(item.利润单价);
                    sinfo.FXDJ = ToolKit.ParseDecimal(item.风险单价);
                    sinfo.GFDJ = ToolKit.ParseDecimal(item.规费单价);
                    sinfo.LibraryName = m_UnitProject.Property.Libraries.FixedLibrary.FullName;
                    sinfo.DECJ = "";
                    string DECJ = "";
                    DataTable dt = m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy();
                    DataRow[] rows = dt.Select(string.Format("DINGEH='{0}'", sinfo.OLDXMBM));
                    if (rows.Length > 0)
                    {
                        DECJ = rows[0][CEntity定额表.FILED_DECJ].ToString();
                    }



                    if (info1 != null)
                    {
                        info1.Create(sinfo as _SubheadingsInfo);
                    }
                    else
                    {
                        info2.Create(sinfo as _MSubheadingsInfo);
                    }
                    SetSubheadingsQuantityUnit(sinfo, item.人材机含量, DECJ, m_UnitProject, m_DWGC);
                    sinfo.DECJ = DECJ;
                    //对子目取费赋值
                }
            
        }


        /// <summary>
        /// 工料机赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="hl"></param>
        private void SetSubheadingsQuantityUnit(_ObjectInfo info, List<人材机含量> hl, string DECJ, _UnitProject m_UnitProject, 单位工程 m_DWGC)
        {

            _SubheadingsInfo info1 = info as _SubheadingsInfo;
            _MSubheadingsInfo info2 = info as _MSubheadingsInfo;
            foreach (人材机含量 item in hl)
            {
                _ObjectQuantityUnitInfo sinfo;
                if (info1 != null)
                {
                    sinfo = new _SubheadingsQuantityUnitInfo(info1);

                }
                else
                {
                    sinfo = new _SubheadingsQuantityUnitInfo(info2);
                }


                string[] strs = DECJ.Split('|');
                foreach (string str in strs)
                {
                    if (str.Contains(item.材料号))
                    {
                        sinfo.YSXHL = ToolKit.ParseDecimal(str.Split(',')[1]);//赋值原始消耗量 
                    }
                }
                SetRCj(info.LibraryName, item.材料号, sinfo);
                sinfo.BH = item.材料号;
                sinfo.XHL = ToolKit.ParseDecimal(item.含量);
                人材机 rcj = GetRcjByNo(item.材料号, m_DWGC);
                if (rcj != null)
                {
                    sinfo.MC = rcj.材料名;
                    sinfo.GGXH = rcj.规格型号;
                    sinfo.DW = rcj.单位;
                    sinfo.SCDJ = ToolKit.ParseDecimal(rcj.单价);
                    sinfo.LB = rcj.费用类别;
                    sinfo.IFZYCL = rcj.主要材料标志;
                    sinfo.SSDWGC = m_UnitProject.Property.Basis.Name;
                    sinfo.GCL = info.GCL;
                    if (rcj.人材机含量 != null)//查看是否含有组成
                    {
                        foreach (人材机含量 item0 in rcj.人材机含量)
                        {
                            _ObjectQuantityUnitInfo qinfo;
                            if (info1 != null)
                            {
                                qinfo = new _QuantityUnitComponentInfo(sinfo as _SubheadingsQuantityUnitInfo);
                            }
                            else
                            {
                                qinfo = new _QuantityUnitComponentInfo(sinfo as _SubheadingsQuantityUnitInfo);
                            }

                            SetRCj(info.LibraryName, item0.材料号, qinfo);
                            DataTable dt = null;
                            if (!string.IsNullOrEmpty(qinfo.SSKLB))
                            {
                                 dt = (_Library.Libraries[qinfo.SSKLB] as DataSet).Tables["配合比表"];
                            }
                          
                            if (dt==null)
                            {
                                dt = m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["配合比表"].Copy();
                            }
                            DataRow[] drs_zc = dt.Select(string.Format("PHB_CJBH ='{0}' and CAIJBH='{1}'", item0.材料号, item.材料号));
                            if (drs_zc.Length > 0)
                            {
                                qinfo.YSXHL = ToolKit.ParseDecimal(drs_zc[0]["PHB_CJSL"]);//赋值原始消耗量
                            }
                            qinfo.BH = item0.材料号;
                            qinfo.XHL = ToolKit.ParseDecimal(item0.含量);
                            qinfo.SSDWGC = m_UnitProject.Property.Basis.Name;
                            qinfo.GCL = info.GCL;
                            if (info1 != null)
                            {
                                (sinfo as _SubheadingsQuantityUnitInfo).QuantityUnitComponentList.Add(qinfo);//配合比添加到工料机
                            }
                            else
                            {
                                (sinfo as _SubheadingsQuantityUnitInfo).QuantityUnitComponentList.Add(qinfo);//配合比添加到工料机
                            }
                        }
                    }
                }

                if (info1 != null)
                {
                    info1.SubheadingsQuantityUnitList.Add(sinfo);//工料机添加到子目列表
                }
                else
                {
                    info2.SubheadingsQuantityUnitList.Add(sinfo);//工料机添加到子目列表
                }


            }


        }
        /// <summary>
        /// 工料机某些值从库里面读取
        /// </summary>
        /// <param name="LibraryName"></param>
        /// <param name="No"></param>
        /// <param name="info"></param>
        private void SetRCj(string LibraryName, string No, _ObjectQuantityUnitInfo info)
        {
            _Library.GetLibrary(LibraryName);
            DataTable dt = (_Library.Libraries[LibraryName] as DataSet).Tables["材机表"];
            DataRow[] dr = dt.Select(string.Format("CAIJBH ='{0}'", No));
            if (dr != null)
            {
                if (dr.Length > 0)
                {
                    info.IFSC = dr[0]["CAIJSC"].ToString() == "是" ? true : false;
                    info.YSBH = dr[0]["CAIJBH"].ToString();
                    info.YSMC = dr[0]["CAIJMC"].ToString();
                    info.YSDW = dr[0]["CAIJDW"].ToString();
                    //info.YSXHL = Convert.ToDecimal(str[1]);

                    info.DEDJ = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                    info.BH = dr[0]["CAIJBH"].ToString();
                    info.MC = dr[0]["CAIJMC"].ToString();
                    info.DW = dr[0]["CAIJDW"].ToString();
                    info.IFZYCL = dr[0]["CAIJXSJG"].ToString() == "是" ? true : false;
                    info.LB = dr[0]["CAIJLB"].ToString();
                    //info.XHL = Convert.ToDecimal(str[1]);
                    info.SCDJ = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                    info.SDCLB = dr[0]["SANDCMC"].ToString();
                    info.SDCXS = dr[0]["SANDCXS"].ToString().Length == 0 ? 0m : ToolKit.ParseDecimal(dr[0]["SANDCXS"]);

                    info.SSKLB = LibraryName;
                    info.SSDWGCLB = "分部分项";

                    //info.Create();


                }
            }
            //this.m_SubheadingsQuantityUnitList.Add(info);
            //return row;

        }

        /// <summary>
        /// 根据编号得到人材机对象
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        private 人材机 GetRcjByNo(string No, 单位工程 m_DWGC)
        {
            人材机 rcj = null;

            if (m_DWGC.人材机库.人才机 != null)
            {
                IEnumerable<人材机> rcjs = from info in m_DWGC.人材机库.人才机
                                        where info.材料号 == No
                                        select info;
                if (rcjs.Count() > 0)
                {
                    rcj = rcjs.First();
                }

            }

            return rcj;
        }


        /// <summary>
        /// 获取系统变量
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        private string GetFormula(string Str)
        {
            string str = Str;
            DataSet ds = _Common.Application.Global.DataTamp.变量对应表;
            if (ds.Tables.Count > 0)
            {

                DataTable dt = ds.Tables[0];
                DataRow[] rows = dt.Select(" 接口变量='" + Str + "'");
                if (rows.Length > 0)
                {
                    str = rows[0]["系统变量"].ToString();
                }

            }
            return str;
        }
        /// <summary>
        /// 根据文件反序列化为对象
        /// </summary>
        public void Load()
        {
            this.m_建设项目 = CFiles.XmlDeserialize(typeof(建设项目), this.m_FileName) as 建设项目;
        }
    }
}
