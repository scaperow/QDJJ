/*
 单位工程的线程操作(线程处理完毕后最后的结果添加到指定单项工程中)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GOLDSOFT.QDJJ.COMMONS.ZBS;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Threading;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.UI
{
    public class XmlUnitWorker : BackgroundWorker
    {

        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event RunTreadPoolCompleted RunTreadPoolCompleted;

        public 建设项目 js = null;

        /// <summary>
        /// 当选择模块发生变化之后激发
        /// </summary>
        public virtual void onRunTreadPoolCompleted(object sender, object args)
        {
            if (RunTreadPoolCompleted != null)
            {
                this.RunTreadPoolCompleted(sender, args);
            }
        }

        private string _fileType;
        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        public bool isZBS()
        {
            if (_fileType.ToUpper().Equals("ZBS") || _fileType.ToUpper().Equals("JZBX"))
            {
                return true;
            }
            return false;
        }

        private bool m_IsZJF = false;
        /// <summary>
        /// 是否含有子目增加费
        /// </summary>
        public bool IsZJF
        {
            get { return m_IsZJF; }
            set { m_IsZJF = value; }
        }
        private _Engineering m_Engineering = null;
        private 单位工程 m_XmlUnitProject = null;
        private _Business m_Business;
        private _Pr_Business ProjBusiness = null;
        private XmlProjWorker ProjWorker = null;

        //首先处理单位工程依赖项目
        public XmlUnitWorker(_Business p_Business, 单位工程 p_Unit, _Engineering p_Info, XmlProjWorker p_ProjWorker)
        {
            m_XmlUnitProject = p_Unit;
            m_Engineering = p_Info;
            m_Business = p_Business;
            ProjBusiness = p_Business as _Pr_Business;
            ProjWorker = p_ProjWorker;
        }

        /// <summary>
        /// 开始处理单位工程数据
        /// </summary>
        public void Begin()
        {
            //创建单位工程 并且开启线程处理
            _UnitProject up = this.m_Engineering.Create();
            up.Name = m_XmlUnitProject.单位工程名称;
            up.NodeName = m_XmlUnitProject.单位工程名称;
            up.Deep = 2;
            up.JJJC = APP.JJJC;
            //(this.m_Business as _Pr_Business).AddChildByXml(this.m_Engineering, up);
            //开启线程处理
            //准备数据
            SetLibName(up);
            //this.m_Business.InitDataObject(up);
            //this.m_Business.Current.StructSource.ModelProject.Add(up);
            (this.m_Business as _Pr_Business).AddChildByXml(this.m_Engineering, up);

            var statistics = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(up, this.m_Business);
            statistics.Calculate();
            (this.m_Business as _Pr_Business).AddUnit(up);
            up.NeedCalculate = true;
            ThreadPool.SetMaxThreads(100, 100);

            ThreadPool.QueueUserWorkItem(new WaitCallback(this.SetUnitProject), up);
            //ThreadPool.UnsafeQueueUserWorkItem(new WaitCallback(this.SetUnitProject), up);
            //this.SetUnitProject(up);
            //this.RunWorkerAsync(up);
        }

        /// <summary>
        /// 当开始运行线程时候执行
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            _UnitProject up = e.Argument as _UnitProject;
            this.SetUnitProject(up);
            e.Result = up;
        }

        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            base.OnRunWorkerCompleted(e);


            //_UnitProject up = e.Result as _UnitProject;
            //(this.m_Business as _Pr_Business).AddChild(this.m_Engineering, up);
        }


        private void SetUnitProject(object p_Info)
        { 
            _UnitProject up = p_Info as _UnitProject;
            SetUnitProject(up);
        }
        /// <summary>
        /// 单位工程赋值
        /// </summary>
        /// <param name="Engineering"></param>
        /// <param name="UnitProject"></param>
        /// <param name="dx"></param>
        private void SetUnitProject(_UnitProject p_Info)
        {
            try
            {
                //库设置

                SetLibName(p_Info);
                //APP.Methods.Init(p_Info);

                ///基础表参数
                DataTable dt_DE = p_Info.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"];
                DataTable dt_QD = p_Info.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"];
                //_Common.Activitie = UnitProject;//给当前的单位工程赋值



                #region 分部分项对象以及赋值
                //UnitProject.Property.SubSegments = new _SubSegments(UnitProject);//分部分项对象
                SetSubSegments(p_Info, dt_QD, dt_DE);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->分部分项", p_Info.Name));
                #endregion


                #region 措施项目对象以及赋值
                //UnitProject.Property.MeasuresProject = new _MeasuresProject(UnitProject);//措施项目对象
                //p_Info.Property.MeasuresProject.IsInit = false;
                SetMeasuresProject(m_XmlUnitProject.措施项目表, p_Info, m_XmlUnitProject, dt_QD, dt_DE);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->措施项目", p_Info.Name));
                #endregion

                //UnitProject.Property.Metaanalysis = new _Metaanalysis(UnitProject);//单位工程汇总对象
                //p_Info.Property.Metaanalysis.IsInit = false;
                SetMetaanalysis(p_Info, m_XmlUnitProject);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->汇总分析", p_Info.Name));
                SetOtherProject(p_Info, m_XmlUnitProject.其他项目表, m_XmlUnitProject);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目", p_Info.Name));



                //UnitProject.Property.QuantityUnitSummaryList = new _QuantityUnitSummaryList(UnitProject);
                //this.m_Business.Current.StructSource.ModelProject.AppendUnit(p_Info);
                SetJG(p_Info, m_XmlUnitProject);
                p_Info.StructSource.AcceptChanges();
                onRunTreadPoolCompleted(this, p_Info);
            }
            catch (Exception)
            {

                MsgBox.Show(_Prompt.无法识别的打开文件, MessageBoxButtons.OK);
            }

        }
        /// <summary>
        /// 设置甲供材等
        /// </summary>
        /// <param name="p_Info"></param>
        /// <param name="m_XmlUnitProject"></param>
        private void SetJG(_UnitProject p_Info, 单位工程 m_XmlUnitProject)
        {
            _Methods_YTLBSummary m_Methods_YTLBSummary = new _Methods_YTLBSummary(p_Info);
            if (m_XmlUnitProject.需评审的材料表 != null)
            {
                if (m_XmlUnitProject.需评审的材料表.评审材料 != null)
                {
                    for (int i = 0; i < m_XmlUnitProject.需评审的材料表.评审材料.Count; i++)
                    {
                        DataRow m_info = p_Info.StructSource.ModelQuantity.NewRow();
                        m_info["BH"] = m_XmlUnitProject.需评审的材料表.评审材料[i].材料编号;
                        m_info["MC"] = m_XmlUnitProject.需评审的材料表.评审材料[i].名称;
                        m_info["DW"] = m_XmlUnitProject.需评审的材料表.评审材料[i].单位;
                        if (string.IsNullOrEmpty(m_XmlUnitProject.需评审的材料表.评审材料[i].单价))
                            m_info["SCDJ"] = "0";
                        else
                            m_info["SCDJ"] = m_XmlUnitProject.需评审的材料表.评审材料[i].单价;
                        m_info["YTLB"] = UseType.评标指定材料;
                        m_info["ENID"] = p_Info.PID;
                        m_info["UNID"] = p_Info.ID;
                        DataRow r = m_Methods_YTLBSummary.InsertByXML(i, m_info, false, m_XmlUnitProject.人材机库.人才机);

                        ProjBusiness.Insert_Sql_YTLBSummary(r);
                        //this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, lrow["Name"]));
                        ProjBusiness.Update_Sql_QuantityData(m_XmlUnitProject.需评审的材料表.评审材料[i].材料编号, UseType.评标指定材料);
                    }
                }
            }

            if (m_XmlUnitProject.甲供材料或设备表 != null)
            {
                if (m_XmlUnitProject.甲供材料或设备表.甲供材料或设备 != null)
                {
                    for (int i = 0; i < m_XmlUnitProject.甲供材料或设备表.甲供材料或设备.Count; i++)
                    {
                        DataRow m_info = p_Info.StructSource.ModelQuantity.NewRow();
                        m_info["BH"] = m_XmlUnitProject.甲供材料或设备表.甲供材料或设备[i].材料或设备编号;
                        m_info["MC"] = m_XmlUnitProject.甲供材料或设备表.甲供材料或设备[i].名称;
                        m_info["DW"] = m_XmlUnitProject.甲供材料或设备表.甲供材料或设备[i].单位;
                        if (string.IsNullOrEmpty(m_XmlUnitProject.甲供材料或设备表.甲供材料或设备[i].单价))
                            m_info["SCDJ"] = "0";
                        else
                            m_info["SCDJ"] = m_XmlUnitProject.甲供材料或设备表.甲供材料或设备[i].单价;
                        m_info["YTLB"] = UseType.甲供材料;
                        m_info["ENID"] = p_Info.PID;
                        m_info["UNID"] = p_Info.ID;
                        DataRow r = m_Methods_YTLBSummary.InsertByXML(i, m_info, false, m_XmlUnitProject.人材机库.人才机);
                        ProjBusiness.Insert_Sql_YTLBSummary(r);
                        //this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, lrow["Name"]));
                        ProjBusiness.Update_Sql_QuantityData(m_XmlUnitProject.甲供材料或设备表.甲供材料或设备[i].材料或设备编号, UseType.甲供材料);
                    }
                }
            }


            if (m_XmlUnitProject.材料设备暂估价 != null)
            {
                if (m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细 != null)
                {
                    for (int i = 0; i < m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细.Count; i++)
                    {
                        DataRow m_info = p_Info.StructSource.ModelQuantity.NewRow();
                        m_info["BH"] = m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细[i].材料或设备编号;
                        m_info["MC"] = m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细[i].材料名称;
                        m_info["DW"] = m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细[i].计量单位;
                        if (string.IsNullOrEmpty(m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细[i].暂估单价))
                            m_info["SCDJ"] = "0";
                        else
                            m_info["SCDJ"] = m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细[i].暂估单价;
                        m_info["YTLB"] = UseType.暂定价材料;
                        m_info["ENID"] = p_Info.PID;
                        m_info["UNID"] = p_Info.ID;
                        DataRow r = m_Methods_YTLBSummary.InsertByXML(i, m_info, false, m_XmlUnitProject.人材机库.人才机);
                        ProjBusiness.Insert_Sql_YTLBSummary(r);
                        //this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, lrow["Name"]));
                        ProjBusiness.Update_Sql_QuantityData(m_XmlUnitProject.材料设备暂估价.材料设备暂估价明细[i].材料或设备编号, UseType.暂定价材料);
                    }
                }
            }

        }

        private void SetOtherProject(_UnitProject p_un, 其他项目表 qt, 单位工程 m_DWGC)
        {
            if (qt.其他项目清单 == null) return;
            string str = string.Empty;

            //找到第一行的记录
            //DataRow pRow = p_un.StructSource.ModelOtherProject.Rows[0];

            _Method_OtherProject met = new _Method_OtherProject(this.m_Business, p_un);
            //other.Source = APP.Application.Global.DataTamp.LoadOtherProject(other.Parent.PGCDD, out str).Clone();
            //other.Source.PrimaryKey = new DataColumn[] { other.Source.Columns["id"] };
            //DataColumn col = other.Source.Columns["id"];
            //col.AutoIncrement = true;
            //col.AutoIncrementSeed = 1;
            //col.AutoIncrementStep = 1;

            p_un.StructSource.ModelOtherProject.Columns[0].AutoIncrement = true;
            p_un.StructSource.ModelOtherProject.Columns[0].AutoIncrementSeed = 1;
            p_un.StructSource.ModelOtherProject.Columns[0].AutoIncrementStep = 1;
            DataRow row = met.Add();
            row["Name"] = "其他项目";
            row["IsSys"] = true;
            row["PKey"] = 3;
            row["Feature"] = GetOtherXMBM(row["Name"].ToString());
            bool IsLX = false;//标识是否有零星项目

            if (m_DWGC.零星项目表 != null)
            {
                IsLX = true;
            }
            ProjBusiness.Insert_Sql_OtherProject(row);
            this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, row["Name"]));
            foreach (其他项目清单 item in qt.其他项目清单)
            {
                if (item.项目名称 == "人工费调增") continue;
                DataRow crow = met.Add_Child(row);
                crow["PKey"] = row["Key"];
                # region 含有计日工
                if (!IsLX)
                {

                    crow["Name"] = item.项目名称;
                    crow["Quantities"] = 1;
                    //crow["Quantities"] = item.工程数量;
                    //if (!item.序号.Equals("1") && !item.序号.Equals("2") && isZBS())
                    //{
                    //    crow["Coefficient"] = "0";
                    //    crow["Calculation"] = "";
                    //}
                    //else
                    {
                        if (item.项目名称.Equals("副食品调节基金"))
                        {
                            crow["Coefficient"] = 0.5;
                            crow["Calculation"] = "FBFXHJ+KCAQWMCSF";
                        }
                        else
                        {
                            //crow["Coefficient"] = 100;
                            if ((item.费用类型.Contains("暂列金额") && (qt.暂列金额明细表 == null || qt.暂列金额明细表.暂列金额明细.Length <= 0)) ||
                                (item.费用类型.Contains("专业工程暂估") && (qt.专业工程暂估价明细表 == null || qt.专业工程暂估价明细表.专业工程暂估明细.Length <= 0)) ||
                                (item.费用类型.Contains("总承包服务费") && (qt.总承包服务费项目表 == null || qt.总承包服务费项目表.总承包服务费项.Length <= 0)))
                                crow["Calculation"] = item.合价;//item.综合单价;
                            else
                                crow["Calculation"] = item.综合单价;
                        }
                    }
                    crow["IsSys"] = true;
                    crow["Unit"] = item.计量单位;
                    crow["Feature"] = GetOtherXMBM(crow["Name"].ToString());
                    if (item.费用类型.Contains("暂列金额"))
                    {
                        //if (qt.暂列金额明细表 == null) return;
                        if (qt.暂列金额明细表 != null && qt.暂列金额明细表.暂列金额明细 != null)
                        {
                            foreach (暂列金额明细 itemz in qt.暂列金额明细表.暂列金额明细)
                            {
                                DataRow zrow = met.Add_Child(crow);
                                zrow["PKey"] = crow["Key"];
                                zrow["Name"] = itemz.项目名称;
                                zrow["Unit"] = itemz.计量单位;
                                zrow["Quantities"] = 1;
                                //if (!item.序号.Equals("1") && !item.序号.Equals("2") && isZBS())
                                //{
                                //    zrow["Calculation"] = "";
                                //    zrow["Coefficient"] = "0";
                                //}
                                //else
                                {
                                    zrow["Calculation"] = itemz.暂定金额;
                                    zrow["Coefficient"] = 100;
                                }

                                zrow["IsSys"] = false;
                                zrow["Feature"] = GetOtherXMBM(zrow["Name"].ToString());
                                //crow["Quantities"] = 1;
                                // crow["Calculation"] = "";
                                // crow["Coefficient"] = 0;
                                ProjBusiness.Insert_Sql_OtherProject(zrow);
                                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, zrow["Name"]));
                            }
                        }
                    }

                    if (item.费用类型.Contains("专业工程暂估"))
                    {
                        if (qt.专业工程暂估价明细表 != null)
                        {
                            if (qt.专业工程暂估价明细表.专业工程暂估明细 != null)
                            {
                                foreach (专业工程暂估明细 itemz in qt.专业工程暂估价明细表.专业工程暂估明细)
                                {
                                    DataRow zrow = met.Add_Child(crow);
                                    zrow["PKey"] = crow["Key"];
                                    zrow["Name"] = itemz.项目名称;
                                    zrow["Unit"] = itemz.计量单位;
                                    zrow["Quantities"] = 1;
                                    //if (!item.序号.Equals("1") && !item.序号.Equals("2") && isZBS())
                                    //{
                                    //    zrow["Calculation"] = "";
                                    //    zrow["Coefficient"] = "0";
                                    //}
                                    //else
                                    {
                                        zrow["Calculation"] = itemz.暂估单价;
                                        zrow["Coefficient"] = 100;
                                    }
                                    zrow["IsSys"] = false;
                                    zrow["Feature"] = GetOtherXMBM(zrow["Name"].ToString());
                                    // crow["Quantities"] = 1;
                                    //crow["Calculation"] = "";
                                    // crow["Coefficient"] = 0;

                                    ProjBusiness.Insert_Sql_OtherProject(zrow);
                                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, zrow["Name"]));
                                }
                            }
                        }
                    }
                    if (item.费用类型.Contains("总承包服务费"))
                    {
                        if (qt.总承包服务费项目表 != null)
                        {
                            if (qt.总承包服务费项目表.总承包服务费项 != null)
                            {
                                foreach (总承包服务费项 itemz in qt.总承包服务费项目表.总承包服务费项)
                                {
                                    DataRow zrow = met.Add_Child(crow);
                                    zrow["PKey"] = crow["Key"];
                                    zrow["Name"] = itemz.项目名称;
                                    zrow["Unit"] = itemz.计量单位;
                                    zrow["Quantities"] = 1;
                                    //if (!item.序号.Equals("1") && !item.序号.Equals("2") && isZBS())
                                    //{
                                    //    zrow["Calculation"] = "";
                                    //    zrow["Coefficient"] = "0";
                                    //}
                                    //else
                                    {
                                        zrow["Calculation"] = itemz.合价;
                                        zrow["Coefficient"] = 100;
                                    }
                                    zrow["IsSys"] = false;
                                    zrow["Feature"] = GetOtherXMBM(zrow["Name"].ToString());
                                    //crow["Quantities"] = 1;
                                    //crow["Calculation"] = "";
                                    //crow["Coefficient"] = 0;
                                    ProjBusiness.Insert_Sql_OtherProject(zrow);
                                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, zrow["Name"]));
                                }
                            }
                        }
                    }
                    if (item.费用类型.Contains("计日工"))
                    {

                        string[] names = { "人工", "材料", "机械" };
                        bool flag = false;
                        bool flag1 = false;
                        if (qt.计日工表 != null)
                        {
                            if (qt.计日工表.计日工项 != null)
                            {
                                if (qt.计日工表.计日工项.Count < 1)
                                {
                                    flag1 = true;
                                }
                            }
                            else
                            {
                                flag1 = true;
                            }
                        }
                        else
                        {
                            flag1 = true;
                        }
                        //flag = ToolKit.ParseDecimal(item.合价) > 0 && flag1;//此标示表示计日工下面的子项没有材料 但是计日工节点有值
                        foreach (string name in names)
                        {
                            DataRow zrow = met.Add_Child(crow);
                            zrow["PKey"] = crow["Key"];
                            zrow["Name"] = name;

                            zrow["IsSys"] = false;
                            zrow["Unit"] = item.计量单位;
                            //zrow["Calculation"] = item.综合单价;
                            zrow["Feature"] = GetOtherXMBM(zrow["Name"].ToString());
                            //crow["Quantities"] = 1;
                            //crow["Calculation"] = "";
                            //crow["Coefficient"] = 0;
                            zrow["Quantities"] = 1;
                            if (flag1)
                            {
                                //zrow["Quantities"] = 1;
                                //zrow["Unit"] = item.计量单位;
                                if (name.Equals("人工"))
                                {
                                    zrow["Calculation"] = item.合价;
                                    zrow["Coefficient"] = 100;
                                    //zrow["UnitPrice"] = item.合价;
                                }
                                else
                                {
                                    zrow["Calculation"] = "";
                                    zrow["Coefficient"] = 0;

                                }
                                flag1 = false;
                            }
                            //if (!item.序号.Equals("1") && !item.序号.Equals("2") && isZBS())
                            //{
                            //    zrow["Calculation"] = "";
                            //    zrow["Coefficient"] = "0";
                            //}
                            //else
                            {
                                //if (qt.计日工表 != null)
                                //{
                                //    if (qt.计日工表.计日工项 != null)
                                //    {
                                //        if (!flag)
                                //        {
                                //            if (qt.计日工表.计日工项.Count > 0)
                                //            {
                                //                zrow["Calculation"] = item.合价;
                                //                zrow["Coefficient"] = 100;
                                //            }
                                //            else
                                //            {
                                //                zrow["Calculation"] = "";
                                //                zrow["Coefficient"] = 0;
                                //            }
                                //        }
                                //    }
                                //}
                                //flag = false;

                                //if (flag1)
                                //{
                                //    zrow["Calculation"] = item.合价;
                                //    zrow["Coefficient"] = 100;
                                //}
                                //else
                                //{
                                //    zrow["Calculation"] = "";
                                //    zrow["Coefficient"] = 0;
                                //}
                            }
                            if (qt.计日工表 != null)
                            {
                                if (qt.计日工表.计日工项 != null)
                                {
                                    if (qt.计日工表.计日工项.Count > 0)
                                    {
                                        IEnumerable<计日工项> jr = from info in qt.计日工表.计日工项
                                                               where info.类别 == name
                                                               select info;
                                        foreach (计日工项 item2 in jr)
                                        {
                                            计日工项 jrgx = item2;
                                            DataRow zrow1 = met.Add_Child(zrow);
                                            zrow1["PKey"] = zrow["Key"];
                                            zrow1["Name"] = jrgx.名称;
                                            zrow1["Unit"] = jrgx.单位;
                                            if (string.IsNullOrEmpty(jrgx.暂定数量))
                                                zrow1["Quantities"] = 1;
                                            else
                                                zrow1["Quantities"] = jrgx.暂定数量;
                                            //zrow1["Calculation"] = jrgx.综合单价;
                                            //zrow1["Coefficient"] = 100;
                                            //if (!item.序号.Equals("1") && !item.序号.Equals("2") && isZBS())
                                            //{
                                            //    zrow1["Quantities"] = "";
                                            //    zrow1["Calculation"] = "";
                                            //    zrow1["Coefficient"] = "0";
                                            //}
                                            //else
                                            {
                                                zrow1["Quantities"] = jrgx.暂定数量;
                                                zrow1["Calculation"] = jrgx.综合单价;//jrgx.合价;
                                                zrow1["Coefficient"] = 100;
                                            }
                                            zrow1["Feature"] = GetOtherXMBM(zrow1["Name"].ToString());
                                            // zrow["Quantities"] = 1;
                                            // zrow["Calculation"] = "";
                                            //zrow["Coefficient"] = 0;

                                            ProjBusiness.Insert_Sql_OtherProject(zrow1);
                                            this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, zrow1["Name"]));
                                        }
                                    }
                                }
                            }
                            ProjBusiness.Insert_Sql_OtherProject(zrow);
                            this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, zrow["Name"]));
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
                    crow["Calculation"] = item.综合单价;
                    crow["Coefficient"] = 100;
                    crow["Feature"] = GetOtherXMBM(crow["Name"].ToString());
                    if (item.计算基础.Contains("零星工作费"))
                    {
                        if (m_DWGC.零星项目表.零星项目标题 != null)
                        {
                            foreach (零星项目标题 itemz in m_DWGC.零星项目表.零星项目标题)
                            {
                                //DataRow zrow = other.Add_Child(crow);
                                //zrow["Name"] = itemz.名称;
                                ////zrow["Unit"] = itemz.计量单位;
                                //zrow["Quantities"] = "0";
                                foreach (零星项目 iteml in itemz.零星项目)
                                {
                                    DataRow lrow = met.Add_Child(crow);
                                    lrow["PKey"] = crow["Key"];
                                    lrow["Name"] = iteml.名称;
                                    lrow["Unit"] = iteml.单位;
                                    lrow["Quantities"] = iteml.数量;
                                    lrow["Calculation"] = iteml.单价;
                                    lrow["Coefficient"] = 100;
                                    lrow["IsSys"] = false;
                                    lrow["Feature"] = GetOtherXMBM(lrow["Name"].ToString());
                                    //crow["Quantities"] = 1;
                                    // crow["Calculation"] = "";
                                    //crow["Coefficient"] = 0;
                                    ProjBusiness.Insert_Sql_OtherProject(lrow);
                                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, lrow["Name"]));
                                }

                            }
                        }
                    }
                }

                ProjBusiness.Insert_Sql_OtherProject(crow);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->其他项目->{1}", p_un.Name, crow["Name"]));
            }

            //完成之后计算值
            met.Calculate();
        }
        /// <summary>
        /// 获取措施项目的费用代号
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string GetOtherXMBM(string Name)
        {
            DataRow[] rows = APP.Application.Global.DataTamp.TempDataSet.Tables["Params_Other"].Select(string.Format("Name='{0}'", Name));
            if (rows.Length > 0)
            {
                return rows[0]["Code"].ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 汇总分析赋值
        /// </summary>
        /// <param name="m"></param>
        private void SetMetaanalysis(_UnitProject m, 单位工程 m_DWGC)
        {
            if (m_DWGC.单位工程造价汇总表 == null) return;
            if (m_DWGC.单位工程造价汇总表.单位工程费用项 == null) return;
            if (m_DWGC.措施项目表 == null) return;
            if (m_DWGC.措施项目表.措施项目标题 == null) return;
            if (m_DWGC.规费税金清单表 == null) return;
            if (m_DWGC.规费税金清单表.规费税金项 == null) return;
            //m.IsInit = true;
            _Method_Metaanalysis met = new _Method_Metaanalysis(m);
            met.Load(GetMetaanalysisTemplet(m_DWGC));//根据条件载入汇总分析模板

            //循环汇总分析表
            单位工程费用项 ditem = null;
            规费税金项 gitem = null;
            措施项目清单 citem = null;
            List<措施项目清单> list = new List<措施项目清单>();
            foreach (措施项目标题 item1 in m_DWGC.措施项目表.措施项目标题)
            {
                list.AddRange(item1.措施项目清单);
            }
            foreach (DataRow row in m.StructSource.ModelMetaanalysis.Rows)
            {

                decimal d = 0;
                gitem = m_DWGC.规费税金清单表.规费税金项.Where(p => p.费用名称.Contains(row["Name"].ToString())).FirstOrDefault();
                if (gitem != null)
                {
                    row["Coefficient"] = ToolKit.ParseDecimal(gitem.费率);
                    d = ToolKit.ParseDecimal(gitem.金额);
                    row["Price"] = d;
                    //保存汇总分析数据
                    this.ProjBusiness.Insert_Sql_Metaanalysis(row);
                    //保存单位工程变量表
                    this.ProjBusiness.Current.StructSource.ModelProjVariable.Set(m.PID, m.ID, -1, row["Feature"].ToString(), d, row["Remark"].ToString());
                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->汇总分析->{1}", m.Name, row["Name"]));
                    continue;
                }

                ditem = m_DWGC.单位工程造价汇总表.单位工程费用项.Where(p => p.费用名称.Contains(row["Name"].ToString())).FirstOrDefault();

                if (ditem != null)
                {
                    row["Coefficient"] = ToolKit.ParseDecimal(ditem.费率);
                    d = ToolKit.ParseDecimal(ditem.金额);
                    row["Price"] = d;
                    //保存汇总分析数据
                    this.ProjBusiness.Insert_Sql_Metaanalysis(row);
                    //保存单位工程变量表
                    this.ProjBusiness.Current.StructSource.ModelProjVariable.Set(m.PID, m.ID, -1, row["Feature"].ToString(), d, row["Remark"].ToString());
                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->汇总分析->{1}", m.Name, row["Name"]));
                    continue;
                }


                citem = list.Where(p => p.名称.Contains(row["Name"].ToString())).FirstOrDefault();

                if (citem != null)
                {
                    row["Coefficient"] = citem.费率;
                    //保存汇总分析数据
                    this.ProjBusiness.Insert_Sql_Metaanalysis(row);
                    //保存单位工程变量表
                    this.ProjBusiness.Current.StructSource.ModelProjVariable.Set(m.PID, m.ID, -1, row["Feature"].ToString(), d, row["Remark"].ToString());
                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->汇总分析->{1}", m.Name, row["Name"]));
                    continue;
                }
                if (ditem == null && gitem == null && citem == null)
                {
                    this.ProjBusiness.Insert_Sql_Metaanalysis(row);
                    //保存单位工程变量表
                    this.ProjBusiness.Current.StructSource.ModelProjVariable.Set(m.PID, m.ID, -1, row["Feature"].ToString(), d, row["Remark"].ToString());
                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->汇总分析->{1}", m.Name, row["Name"]));
                }


            }


            //foreach (单位工程费用项 item in m_DWGC.单位工程造价汇总表.单位工程费用项)
            //{
            //    IEnumerable<DataRow> rows = from row in m.StructSource.ModelMetaanalysis.AsEnumerable()
            //                                where item.费用名称.Contains(row["Name"].ToString())
            //                                select row;
            //    if (rows.Count() > 0)
            //    {
            //        DataRow row = rows.First();
            //        row["Coefficient"] = item.费率;
            //        row["Price"] = item.金额;
            //        //保存汇总分析数据 添加到参数表中
            //    }
            //}
            //foreach (规费税金项 item in m_DWGC.规费税金清单表.规费税金项)
            //{
            //    IEnumerable<DataRow> rows = from row in m.StructSource.ModelMetaanalysis.AsEnumerable()
            //                                where item.费用名称.Contains(row["Name"].ToString())
            //                                select row;
            //    if (rows.Count() > 0)
            //    {
            //        DataRow row = rows.First();
            //        if (item.费率!="")
            //        row["Coefficient"] = item.费率;
            //        row["Price"] = item.金额;
            //    }
            //}            

            //if (m_DWGC.措施项目表.措施项目标题 == null) return;


            //foreach (措施项目标题 item1 in m_DWGC.措施项目表.措施项目标题)
            //{

            //    foreach (措施项目清单 item in item1.措施项目清单)
            //    {

            //        IEnumerable<DataRow> rows = from row in m.StructSource.ModelMetaanalysis.AsEnumerable()
            //                                    where item.名称.Contains(row["Name"].ToString())
            //                                    select row;
            //        if (rows.Count() > 0)
            //        {
            //            DataRow row = rows.First();
            //            row["Coefficient"] = item.费率;
            //            //  row["Price"] = item.综合合价;
            //        }
            //    }
            //}

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
                                        where info.序号.Contains("1.1")
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
            if (Fbfx > 0 && Qzaq > 0 && Aqxm < 1 && Last.Split('-').Length == 2)
            {
                filename = "2012汇总分析表【扣劳保】.hzfx";
            }
            if (Fbfx > 0 && Qzaq > 0 && Aqxm < 1 && Last.Split('+').Length == 2)
            {
                filename = "2012汇总分析表【不扣劳保】.hzfx";
            }

            filename = APP.Application.Global.AppFolder + "模板文件\\汇总分析模板\\" + filename;
            return filename;


        }

        /// <summary>
        /// 措施项目赋值
        /// </summary>
        /// <param name="MeasuresProject"></param>
        /// <param name="dx"></param>
        private void SetMeasuresProject(措施项目表 dx, _UnitProject m_UnitProject, 单位工程 m_DWGC, DataTable dt_QD, DataTable dt_DE)
        {

            if (dx.措施项目标题 == null) return;
            DataRow pRow = m_UnitProject.StructSource.ModelMeasures.Rows[0];
            DataRow _com = null;
            foreach (措施项目标题 item in dx.措施项目标题)
            {
                //_CommonrojectInfo _com = new _CommonrojectInfo(m);
                _com = m_UnitProject.StructSource.ModelMeasures.NewRow();
                _com.BeginEdit();
                _com["XMMC"] = item.名称;
                if (!string.IsNullOrEmpty(item.项目编码))
                {
                    _com["XMBM"] = item.项目编码;
                }
                else
                {
                    _com["XMBM"] = GetXMBM(item.名称);
                }
                _com["GCL"] = 1m;

                _com["PID"] = pRow["ID"];
                _com["STATUS"] = false;
                _com["EnID"] = pRow["EnID"];
                _com["UnID"] = pRow["UnID"];
                _com["SSLB"] = 1;
                _com["Deep"] = ToolKit.ParseInt(pRow["Deep"]) + 1;
                //this.SetSort(p_Sort, _com);
                _com["Key"] = ++this.m_Business.Current.ObjectKey;
                _com["PKey"] = pRow["Key"];
                _com.EndEdit();
                m_UnitProject.StructSource.ModelMeasures.Rows.Add(_com);
                //m.Create(_com);//通用项目添加到措施项目
                this.ProjBusiness.Insert_Sql_MeasuresData(_com);

                SetMFixed(_com, item, m_UnitProject, m_DWGC, dt_DE);
            }
        }

        /// <summary>
        /// //措施项目清单赋值
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dx"></param>
        private void SetMFixed(DataRow pRow, 措施项目标题 dx, _UnitProject m_UnitProject, 单位工程 m_DWGC, DataTable p_DeTable)
        {

            // _MFixedListInfo Minfo = null;
            DataRow info, Minfo = null;
            foreach (措施项目清单 item in dx.措施项目清单)
            {
                //若是措施项则创建清单否则的话认为是子目并添加到上次的清单里面
                if (item.行类别 == "措施项")
                {
                    //qd = item;
                    //_MFixedListInfo info = new _MFixedListInfo(m);
                    info = m_UnitProject.StructSource.ModelMeasures.NewRow();
                    Minfo = info;
                    info.BeginEdit();
                    info["PID"] = pRow["ID"];
                    info["STATUS"] = false;
                    info["EnID"] = pRow["EnID"];
                    info["UnID"] = pRow["UnID"];
                    info["SSLB"] = 1;
                    info["Deep"] = ToolKit.ParseInt(pRow["Deep"]) + 1;
                    //this.SetSort(p_Sort, _com);
                    info["Key"] = ++this.m_Business.Current.ObjectKey;
                    info["PKey"] = pRow["Key"];
                    //info["XH2"] = ToolKit.ParseInt(item.序号);
                    info["XMMC"] = item.名称;
                    info["LB"] = "清单";
                    info["DW"] = item.单位;
                    info["GCL"] = item.数量;
                    info["JSJC"] = GetFormula(item.计费基础表达式, "措施项目");
                    info["FL"] = ToolKit.ParseDecimal(item.费率);
                    info["LibraryName"] = m_UnitProject.Property.Libraries.ListGallery.FullName;
                    if (!string.IsNullOrEmpty(item.清单编码))
                    {
                        info["XMBM"] = item.清单编码;
                        info["OLDXMBM"] = item.清单编码;
                    }
                    else
                    {
                        info["XMBM"] = GetXMBM(item.名称);
                        info["OLDXMBM"] = GetXMBM(item.名称);
                    }
                    // ToolKit.ParseDecimal(item.费率);
                    info["ZHHJ"] = ToolKit.ParseDecimal(item.综合合价);
                    if (ToolKit.ParseDecimal(item.数量) > 0)
                    {
                        info["ZHDJ"] = ToolKit.ParseDecimal(item.综合合价) / ToolKit.ParseDecimal(item.数量);
                    }

                    // m.CreateByXml(info);
                    if (item.公式组价)
                    {
                        info["ZJFS"] = "公式组价";
                    }
                    else
                    {
                        info["ZJFS"] = "子目组价";
                        info["JSJC"] = "";
                        info["FL"] = 0;
                    }
                    if (item.定额子目 != null)
                    {
                        if (item.定额子目.Count > 0)
                        {
                            SetSubheadings(info, item.定额子目, m_UnitProject, m_DWGC, p_DeTable);
                        }
                    }
                    info["XH"] = ToolKit.ParseInt(item.序号);
                    info["SC"] = true;
                    info.EndEdit();
                    m_UnitProject.StructSource.ModelMeasures.Rows.Add(info);
                    this.ProjBusiness.Insert_Sql_MeasuresData(info);
                }
                else
                {
                    // if (Minfo != null && !item.名称.Contains("安全文明施工"))
                    if (Minfo != null)
                    {
                        info = m_UnitProject.StructSource.ModelMeasures.NewRow();
                        info.BeginEdit();
                        info["XMMC"] = item.名称;
                        if (item.行类别.Equals("子措施项"))
                        {
                            info["LB"] = "子措施项";
                        }
                        else
                        {
                            info["LB"] = "子目";
                        }
                        info["DW"] = item.单位;
                        info["GCL"] = ToolKit.ParseDecimal(item.数量);
                        info["JSJC"] = GetFormula(item.计费基础表达式, "措施项目");
                        info["FL"] = item.费率;// ToolKit.ParseDecimal(item.费率);
                        info["ZHHJ"] = ToolKit.ParseDecimal(item.综合合价);
                        if (ToolKit.ParseDecimal(item.数量) > 0)
                        {
                            info["ZHDJ"] = ToolKit.ParseDecimal(item.综合合价) / ToolKit.ParseDecimal(item.数量);
                        }

                        //info["FL
                        info["XMBM"] = item.序号;
                        info["OLDXMBM"] = item.序号;
                        info["LibraryName"] = m_UnitProject.Property.Libraries.FixedLibrary.FullName;
                        if (item.公式组价)
                        {
                            info["ZJFS"] = "公式组价";
                        }
                        info["PID"] = Minfo["ID"];
                        info["STATUS"] = false;
                        info["EnID"] = Minfo["EnID"];
                        info["UnID"] = Minfo["UnID"];
                        info["SSLB"] = 1;
                        info["Deep"] = ToolKit.ParseInt(Minfo["Deep"]) + 1;
                        //this.SetSort(p_Sort, _com);
                        info["Key"] = ++this.m_Business.Current.ObjectKey;
                        info["PKey"] = Minfo["Key"];
                        info["SC"] = true;
                        info.EndEdit();
                        m_UnitProject.StructSource.ModelMeasures.Rows.Add(info);
                        this.ProjBusiness.Insert_Sql_MeasuresData(info);
                    }
                }
            }
        }
        /// <summary>
        /// 获取措施项目的费用代号
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string GetXMBM(string Name)
        {
            DataRow[] rows = APP.Application.Global.DataTamp.MeasuresList.Tables["措施清单"].Select(string.Format("Name='{0}'", Name));
            if (rows.Length > 0)
            {
                return rows[0]["NUMBER"].ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取系统变量
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        private string GetFormula(string Str, string BW)
        {
            string str = Str;
            DataSet ds = _Common.Application.Global.DataTamp.变量对应表;
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables["系统变量对应表"];
                DataRow[] rows = dt.Select(" 接口变量='" + Str + "'  and 说明='" + BW + "'");
                if (rows.Length > 0)
                {
                    str = rows[0]["系统变量"].ToString();
                }
            }
            return str;
        }
        /// <summary>
        /// 初始化库对象
        /// </summary>
        /// <param name="UnitProject"></param>
        private void SetLibName(_UnitProject UnitProject)
        {

            UnitProject.DEGZ = this.m_Engineering.DEGZ;
            UnitProject.QDGZ = this.m_Engineering.QDGZ;

            //UnitProject.Property.DLibraries.ListGallery.Rule = UnitProject.Property.Basis.QDGZ;
            //UnitProject.Property.DLibraries.FixedLibrary.Rule = UnitProject.Property.Basis.DEGZ;

            if (m_XmlUnitProject.清单专业.Contains("安装"))
            {
                UnitProject.ProType = "【安装专业】";
                UnitProject.QDLibName = "安装清单库";
                UnitProject.DELibName = "安装定额价目表";
            }

            if (m_XmlUnitProject.清单专业.Contains("建筑"))
            {
                UnitProject.ProType = "【建筑装饰专业】";
                UnitProject.QDLibName = "建筑清单库";
                UnitProject.DELibName = "建筑装饰定额价目表";
                UnitProject.TJLibName = "陕标09系列建筑图集";
            }
            if (m_XmlUnitProject.清单专业.Contains("绿化"))
            {
                UnitProject.ProType = "【园林绿化专业】";
                UnitProject.QDLibName = "园林绿化清单库";
                UnitProject.DELibName = "绿化定额价目表";
            }
            if (m_XmlUnitProject.清单专业.Contains("市政"))
            {
                UnitProject.ProType = "【市政建筑专业】";
                UnitProject.QDLibName = "市政清单库";
                UnitProject.DELibName = "市政定额价目表";
            }
            if (!m_XmlUnitProject.定额专业.Contains("专业"))
            {
                UnitProject.ProType = UnitProject.PrfType = "【" + m_XmlUnitProject.定额专业 + "专业】";
            }
            else
            {
                UnitProject.PrfType = "【" + m_XmlUnitProject.定额专业 + "】";
            }

        }
        /// <summary>
        /// 分部分项清单赋值
        /// </summary>
        /// <param name="SubSegment"></param>
        /// <param name="dx"></param>
        private void SetSubSegments(_UnitProject p_Info, DataTable dt_QD, DataTable dt_DE)
        {
            if (m_XmlUnitProject.分部分项表.分部分项清单 == null)
            {
                return;
            }
            DataRow PRow = p_Info.StructSource.ModelSubSegments.Rows[0];
            //暂时不加入章节行
            DataRow row = null;
            //_Entity_SubInfo info = null;
            分部分项清单 item;
            for (int i = 0; i < m_XmlUnitProject.分部分项表.分部分项清单.Length; i++)
            //foreach (分部分项清单 item in m_XmlUnitProject.分部分项表.分部分项清单)
            {
                item = m_XmlUnitProject.分部分项表.分部分项清单[i];
                string ZJWZ = string.Empty;
                string TX = "jz";
                if (dt_QD != null)
                {
                    System.Data.DataRow[] rows = dt_QD.Select(string.Format("QINGDBH='{0}'", item.清单编码.Substring(0, item.清单编码.Length - 3)));
                    if (rows.Length > 0)
                    {
                        ZJWZ = rows[0]["QINGDSYBH"].ToString();
                        TX = rows[0]["TX1"].ToString();
                    }

                }
                if (string.IsNullOrEmpty(ZJWZ))
                {
                    ZJWZ = "999999";
                }
                DataRow prorow = GetproByFixed(PRow, ZJWZ.Substring(0, 2), p_Info);//专业
                DataRow Chaptrow = GetproByFixed(prorow, ZJWZ.Substring(0, 4), p_Info);//章
                DataRow Festrow = GetproByFixed(Chaptrow, ZJWZ.Substring(0, 6), p_Info);//节

                row = p_Info.StructSource.ModelSubSegments.NewRow();
                row.BeginEdit();

                //info = new _Entity_SubInfo();
                row["TX"] = TX;
                row["LibraryName"] = p_Info.QDLibName;
                row["XMBM"] = item.清单编码;
                row["OLDXMBM"] = row["XMBM"].ToString().Substring(0, row["XMBM"].ToString().Length - 3);
                //info.XMMC = item.名称;
                SetQDMC(item, row);

                row["DW"] = item.单位;
                //info.SetGCL(ToolKit.ParseDecimal(item.数量));
                row["LB"] = "清单";
                row["ZHDJ"] = ToolKit.ParseDecimal(item.综合单价);
                row["ZHHJ"] = ToolKit.ParseDecimal(item.综合合价);
                row["RGFDJ"] = ToolKit.ParseDecimal(item.人工费单价);
                row["CLFDJ"] = ToolKit.ParseDecimal(item.材料费单价);
                row["JXFDJ"] = ToolKit.ParseDecimal(item.机械费单价);
                row["ZCFDJ"] = ToolKit.ParseDecimal(item.主材费单价);
                row["SBFDJ"] = ToolKit.ParseDecimal(item.设备费单价);
                row["GLFDJ"] = ToolKit.ParseDecimal(item.管理费单价);
                row["LRDJ"] = ToolKit.ParseDecimal(item.利润单价);
                row["LRDJ"] = ToolKit.ParseDecimal(item.利润单价);
                row["FXDJ"] = ToolKit.ParseDecimal(item.风险单价);
                row["GFDJ"] = ToolKit.ParseDecimal(item.规费单价);
                row["SJDJ"] = ToolKit.ParseDecimal(item.税金单价);
                row["ZYQD"] = ToolKit.ParseDecimal(item.主要清单);
                row["GCL"] = ToolKit.ParseDecimal(item.数量);
                row["ZJWZ"] = ZJWZ;

                //
                row["FPARENTID"] = PRow["ID"];
                //info.PPARENTID = pro.ID;
                //info.CPARENTID = cinfo.ID;
                //info.PID = finfo.ID;
                row["SSLB"] = 0;
                row["EnID"] = this.m_Engineering.ID;
                row["UnID"] = p_Info.ID;
                row["Deep"] = 6;//清单对象深度为5
                row["Sort"] = i + 1;
                row["Key"] = ++this.m_Business.Current.ObjectKey;
                row["PKey"] = PRow["Key"];
                //
                row["SC"] = true;

                row["PPARENTID"] = prorow["ID"];
                row["CPARENTID"] = Chaptrow["ID"];
                row["PID"] = Festrow["ID"];

                ///备注
                string strQDBM = string.Empty;
                if (item.清单编码.Length >= 3)
                    strQDBM = item.清单编码.Substring(0, item.清单编码.Length - 3);
                int intCount = GLODSOFT.QDJJ.BUSINESS._Method_Sub.GetCountByBH(strQDBM, p_Info.StructSource.ModelSubSegments);
                row["BEIZHU"] = GLODSOFT.QDJJ.BUSINESS._Method_Sub.GetQDbeizhu(strQDBM, intCount, "XML");
                row.EndEdit();
                p_Info.StructSource.ModelSubSegments.Rows.Add(row);
                ProjBusiness.Insert_SubData(row);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->清单->{1}", p_Info.Name, row["XMBM"]));

                //Method.Create(-1, info);
                //p_Info.StructSource.ModelSubSegments.Add(info);
                //p_Info.Property.SubSegments.Create(info);//清单创建完毕
                //创建子目
                SetSubheadings(row, item.定额子目, p_Info, this.m_XmlUnitProject, dt_DE);
            }
        }

        public DataRow GetproByFixed(DataRow p_row, string ZJWJ, _UnitProject p_info)
        {
            DataRow pro = null;
            string zjwj = ZJWJ;
            IEnumerable<DataRow> infos = from item in p_info.StructSource.ModelSubSegments.AsEnumerable()
                                         where item["XMBM"].Equals(zjwj)
                                         select item;
            if (infos.Count() > 0)
            {
                pro = infos.First<DataRow>();
                return pro;

            }
            else
            {
                _Entity_SubInfo pinfo = new _Entity_SubInfo();
                DataRow row = GetQDSY(p_info, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.GCL = 0.0m;
                }
                switch (ZJWJ.Length)
                {
                    case 2:
                        pinfo.LB = "分部-专业";
                        if (row == null)
                        {
                            pinfo.XMBM = "99";
                            pinfo.XMMC = "补充专业";
                            pinfo.GCL = 0.0m;
                        }
                        break;
                    case 4:
                        pinfo.LB = "分部-章";
                        if (row == null)
                        {
                            pinfo.XMBM = "9999";
                            pinfo.XMMC = "补充章";
                            pinfo.GCL = 0.0m;
                        }
                        break;
                    case 6:
                        pinfo.LB = "分部-节";
                        if (row == null)
                        {
                            pinfo.XMBM = "999999";
                            pinfo.XMMC = "补充节";
                            pinfo.GCL = 0.0m;
                        }
                        break;
                    default:
                        break;
                }
                int d = ToolKit.ParseInt(p_row["ID"]);
                pinfo.PID = d;
                pinfo.CPARENTID = d;
                pinfo.EnID = ToolKit.ParseInt(p_row["EnID"]);
                pinfo.UnID = ToolKit.ParseInt(p_row["UnID"]);
                pinfo.Deep = ToolKit.ParseInt(p_row["Deep"]) + 1;
                p_info.StructSource.ModelSubSegments.Add(pinfo);
                DataRow r = p_info.StructSource.ModelSubSegments.GetRowByOther(pinfo.ID.ToString());
                ProjBusiness.Insert_SubData(r);
                return r;
            }
        }

        private DataRow GetQDSY(_UnitProject p_info, string QDSY)
        {

            //DataSet ds = _Library.Libraries[LibraryName] as DataSet;
            DataTable dt = p_info.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单索引表"];
            DataRow[] rows = dt.Select(string.Format("QINGDSYBH='{0}'", QDSY));
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else
            {
                return null;
            }

        }

        private void SetQDMC(分部分项清单 P_item, DataRow P_info)
        {
            string XMTZ = P_item.项目特征及工作内容.Replace("[", "【").Replace("]", "】");

            if (!XMTZ.Contains(_Constant.回车符))
            {
                XMTZ = XMTZ.Replace("\n", _Constant.回车符);
            }
            string MC = P_item.名称.Replace("[", "【").Replace("]", "】");
            if (!MC.Contains(_Constant.回车符))
            {
                MC = MC.Replace("\n", _Constant.回车符);
            }
            string Temp = string.Empty;
            string XMMC = string.Empty;
            string XMTZ1 = string.Empty;
            string GCNR = string.Empty;
            string TJNR = string.Empty;
            string XMTZ0 = string.Empty;
            if (!MC.Contains('【'))
            {
                XMMC = MC.Trim();
            }
            else
            {
                XMMC = MC.Substring(0, MC.IndexOf("【"));
            }

            if (XMTZ == null || XMTZ == "")
            {
                if (MC.Contains('【'))
                {
                    Temp = MC.Substring(MC.IndexOf("【"));
                }
            }
            else
            {
                if (MC.Contains(XMTZ))
                {
                    if (MC.Contains("【"))
                        Temp = MC.Substring(MC.IndexOf("【"));
                    else
                        Temp = string.Empty;
                }
                else
                {
                    if (XMTZ.Contains('【'))
                    {
                        //int m = XMTZ.IndexOf("【");
                        //if (m<0)
                        //{
                        //    m = 0; 
                        //}
                        Temp = XMTZ.Substring(XMTZ.IndexOf("【"));
                    }
                    else
                    {
                        Temp = XMTZ;
                    }

                }
            }
            string[] Arr = Temp.Split('【');
            if (Arr.Length == 1)
            {
                if (!XMMC.Contains(_Constant.回车符)) XMMC += _Constant.回车符;
                XMMC = XMMC.TrimEnd() + Temp;
                XMMC = XMMC.TrimEnd();
            }
            else
            {
                foreach (string item in Arr)
                {
                    string str = item.TrimEnd();
                    if (str.Contains("项目特征"))
                    {
                        XMTZ1 = _Constant.回车符 + "【" + str;
                    }
                    if (str.Contains("工程内容") || str.Contains("工作内容"))
                    {
                        GCNR = _Constant.回车符 + "【" + str;
                        GCNR = GCNR.Replace("工作内容", "工程内容");
                    }
                    if (str.Contains("标准图集"))
                    {
                        TJNR = _Constant.回车符 + "【" + str;
                    }
                }
                if (!XMMC.Contains(_Constant.回车符)) XMMC += _Constant.回车符;
                XMTZ0 = XMTZ1 + GCNR + TJNR;
                XMTZ0 = XMTZ0.TrimEnd();
            }
            XMMC = XMMC.TrimEnd() + XMTZ0;
            P_info["XMMC"] = XMMC.TrimEnd();
        }
        #region-------------------------------分部分项中的子项---------------------------------

        /// <summary>
        /// 子目赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="de"></param>
        private void SetSubheadings(DataRow info, List<定额子目> de, _UnitProject m_UnitProject, 单位工程 m_DWGC, DataTable p_DeTable)
        {
            /*GLODSOFT.QDJJ.BUSINESS._Methods Method = null;*/
            _SubSegmentsSource table = null;
            if (info["SSLB"].Equals(0))
            {
                table = m_UnitProject.StructSource.ModelSubSegments;
            }
            else
            {
                table = m_UnitProject.StructSource.ModelMeasures;
            }
            bool flag1 = m_UnitProject.ProType.Contains("安装");
            DataRow sinfo = null;
            定额子目 item;
            for (int i = 0; i < de.Count; i++)
            {
                item = de[i];
                sinfo = table.NewRow();
                sinfo.BeginEdit();
                ///备注
                sinfo["BEIZHU"] = GLODSOFT.QDJJ.BUSINESS._Method_Sub.GetDEbeizhu("XML", i + 1, info["OLDXMBM"].ToString());

                //子目增加费
                if (de[i].人材机含量.Count < 1)
                {
                    m_IsZJF = true && flag1;
                    //sinfo.XMBM = item.定额号;
                    //sinfo.OLDXMBM = item.定额号;
                    //sinfo.XMMC = item.名称;
                    //sinfo.DW = item.单位;
                    //sinfo.ZHDJ = ToolKit.ParseDecimal(item.综合单价);
                    //sinfo.ZHHJ = ToolKit.ParseDecimal(item.综合合价);
                    //sinfo.RGFDJ = ToolKit.ParseDecimal(item.人工费单价);
                    //sinfo.CLFDJ = ToolKit.ParseDecimal(item.材料费单价);
                    //sinfo.JXFDJ = ToolKit.ParseDecimal(item.机械费单价);
                    //sinfo.ZCFDJ = ToolKit.ParseDecimal(item.主材费单价);
                    //sinfo.SBFDJ = ToolKit.ParseDecimal(item.设备费单价);
                    //sinfo.LB = "子目";
                    //sinfo.GLFDJ = ToolKit.ParseDecimal(item.管理费单价);
                    //sinfo.LRDJ = ToolKit.ParseDecimal(item.利润单价);
                    //sinfo.FXDJ = ToolKit.ParseDecimal(item.风险单价);
                    //sinfo.GFDJ = ToolKit.ParseDecimal(item.规费单价);
                    //sinfo.LibraryName = m_UnitProject.Property.Libraries.FixedLibrary.FullName;
                    //sinfo.DECJ = "";

                    //if (info1 != null)
                    //{
                    //    info1.CreateByXml(sinfo as _SubheadingsInfo);
                    //}
                    //else
                    //{
                    //    info2.CreateByXml(sinfo as _MSubheadingsInfo);
                    //}
                    //sinfo.ISXSHS = false;
                    //sinfo.GCL = ToolKit.ParseDecimal(item.数量);
                    //sinfo.ISXSHS = true;




                    //if (ToolKit.ParseDecimal(item.人工费单价)>0)
                    //{
                    //    _SubheadingsQuantityUnitInfo sinfo1 = new _SubheadingsQuantityUnitInfo(sinfo);
                    //    sinfo1.YSBH = "ZJRGF";
                    //    sinfo1.YSMC = "其它人工费";
                    //    sinfo1.LB = "人工";
                    //    sinfo1.YSXHL = ToolKit.ParseDecimal(item.人工费单价);
                    //    sinfo1.STATUS = Status.AreAdd;
                    //    sinfo1.YSDW = "元";
                    //    sinfo1.DEDJ = 1m;
                    //    sinfo1.BH = sinfo1.YSBH;
                    //    sinfo1.MC = sinfo1.YSMC;
                    //    sinfo1.DW = sinfo1.YSDW;
                    //    sinfo1.XHL = sinfo1.YSXHL;
                    //    sinfo1.SCDJ = sinfo1.DEDJ;
                    //    sinfo1.ZCLB = "W";
                    //    sinfo1.GCL = ToolKit.ParseDecimal(item.数量);
                    //    sinfo1.SSKLB = sinfo.LibraryName;
                    //    sinfo1.SSDWGCLB = sinfo.GetSSDWGCLB();
                    //    sinfo1.SSDWGC = sinfo.Activitie.Name;

                    //    sinfo.SubheadingsQuantityUnitList.Add(sinfo1);

                    //}
                    //if (ToolKit.ParseDecimal(item.材料费单价) > 0)
                    //{
                    //    _SubheadingsQuantityUnitInfo sinfo1 = new _SubheadingsQuantityUnitInfo(sinfo);
                    //    sinfo1.YSBH = "ZJCLF";
                    //    sinfo1.YSMC = "其它材料费";
                    //    sinfo1.LB = "材料";
                    //    sinfo1.YSXHL = ToolKit.ParseDecimal(item.材料费单价);

                    //    sinfo1.STATUS = Status.AreAdd;
                    //    sinfo1.YSDW = "元";
                    //    sinfo1.DEDJ = 1m;
                    //    sinfo1.BH = sinfo1.YSBH;
                    //    sinfo1.MC = sinfo1.YSMC;
                    //    sinfo1.DW = sinfo1.YSDW;
                    //    sinfo1.XHL = sinfo1.YSXHL;
                    //    sinfo1.SCDJ = sinfo1.DEDJ;
                    //    sinfo1.ZCLB = "W";
                    //    sinfo1.GCL = ToolKit.ParseDecimal(item.数量);
                    //    sinfo1.SSKLB = sinfo.LibraryName;
                    //    sinfo1.SSDWGCLB = sinfo.GetSSDWGCLB();
                    //    sinfo1.SSDWGC = sinfo.Activitie.Name;

                    //    sinfo.SubheadingsQuantityUnitList.Add(sinfo1);
                    //}
                    //if (ToolKit.ParseDecimal(item.机械费单价) > 0)
                    //{
                    //    _SubheadingsQuantityUnitInfo sinfo1 = new _SubheadingsQuantityUnitInfo(sinfo);
                    //    sinfo1.YSBH = "ZJJXF";
                    //    sinfo1.YSMC = "其它机械费";
                    //    sinfo1.LB = "机械";
                    //    sinfo1.YSXHL = ToolKit.ParseDecimal(item.机械费单价);
                    //    sinfo1.STATUS = Status.AreAdd;
                    //    sinfo1.YSDW = "元";
                    //    sinfo1.DEDJ = 1m;
                    //    sinfo1.BH = sinfo1.YSBH;
                    //    sinfo1.MC = sinfo1.YSMC;
                    //    sinfo1.DW = sinfo1.YSDW;
                    //    sinfo1.XHL = sinfo1.YSXHL;
                    //    sinfo1.SCDJ = sinfo1.DEDJ;
                    //    sinfo1.ZCLB = "W";
                    //    sinfo1.GCL = ToolKit.ParseDecimal(item.数量);
                    //    sinfo1.SSKLB = sinfo.LibraryName;
                    //    sinfo1.SSDWGCLB = sinfo.GetSSDWGCLB();
                    //    sinfo1.SSDWGC = sinfo.Activitie.Name;

                    //    sinfo.SubheadingsQuantityUnitList.Add(sinfo1);
                    //}



                }
                else
                {
                    sinfo["XMBM"] = item.定额号;
                    sinfo["OLDXMBM"] = item.定额号;
                    sinfo["XMMC"] = item.名称;
                    sinfo["DW"] = item.单位;
                    sinfo["ZHDJ"] = item.综合单价;
                    sinfo["ZHHJ"] = item.综合合价;
                    sinfo["RGFDJ"] = item.人工费单价;
                    sinfo["CLFDJ"] = item.材料费单价;
                    sinfo["JXFDJ"] = item.机械费单价;
                    sinfo["ZCFDJ"] = item.主材费单价;
                    sinfo["SBFDJ"] = item.设备费单价;
                    sinfo["LB"] = "子目";
                    sinfo["GLFDJ"] = item.管理费单价;
                    sinfo["LRDJ"] = item.利润单价;
                    sinfo["FXDJ"] = item.风险单价;
                    sinfo["GFDJ"] = item.规费单价;
                    sinfo["LibraryName"] = m_UnitProject.DELibName;
                    sinfo["DECJ"] = "";
                    string DECJ = "";
                    //定额号处理
                    string DEH = sinfo["OLDXMBM"].ToString();
                    if (DEH.Contains(" "))
                    {
                        DEH = DEH.Split(' ')[0];
                    }
                    else
                    {
                        if (DEH.Contains("+"))
                        {
                            DEH = DEH.Split('+')[0];
                        }
                        else
                        {
                            DEH = DEH.Split('*')[0];
                        }
                    }
                    DEH = DEH.Replace("换", "");

                    //
                    sinfo["PID"] = info["ID"];
                    sinfo["CPARENTID"] = info["ID"];
                    sinfo["FPARENTID"] = info["ID"];
                    sinfo["PPARENTID"] = info["ID"];
                    sinfo["SSLB"] = info["SSLB"];
                    sinfo["EnID"] = info["EnID"];
                    sinfo["UnID"] = info["UnID"];
                    sinfo["Deep"] = 6;//子目深度为6
                    sinfo["Sort"] = i + 1;
                    sinfo["Key"] = ++this.m_Business.Current.ObjectKey;
                    sinfo["PKey"] = info["Key"];
                    info["QDBH"] = info["ID"];//设置清单编码 用于措施到模板
                    //
                    info["SC"] = true;
                    sinfo["TX"] = "建筑";
                    DataRow[] rows = p_DeTable.Select(string.Format("DINGEH='{0}'", DEH));
                    if (rows.Length > 0)
                    {
                        sinfo["TX"] = rows[0][CEntity定额表.FILED_TX1];
                        DECJ = rows[0][CEntity定额表.FILED_DECJ].ToString();
                        sinfo["JX"] = rows[0][CEntity定额表.FILED_JIANGX].ToString() == "是" ? true : false;
                    }
                    sinfo["GCL"] = item.数量;
                    sinfo.EndEdit();
                    table.Rows.Add(sinfo);

                    if (info["SSLB"].Equals(0))
                    {
                        this.ProjBusiness.Insert_SubData(sinfo);
                        this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->子目->{1}", m_UnitProject.Name, sinfo["XMBM"]));
                    }
                    else
                    {
                        this.ProjBusiness.Insert_Sql_MeasuresData(sinfo);
                        this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->子目->{1}", m_UnitProject.Name, sinfo["XMBM"]));
                    }



                    //Method.Create(-1, sinfo);


                    //sinfo.ISXSHS = false;
                    //sinfo.ISXSHS = true;
                    //创建人才机
                    bool flag = SetSubheadingsQuantityUnit(sinfo, item, DECJ, m_UnitProject, m_DWGC);
                    sinfo["DECJ"] = DECJ;
                    SetZMQF(sinfo, item, flag, m_UnitProject);
                    //sinfo.Subheadings_Statistics.Begin();
                }
            }

        }

        private void SetZMQF(DataRow info, 定额子目 item1, bool flag, _UnitProject m_UnitProject)
        {

            //  if (this.Unit == null) return;
            //  if (string.IsNullOrEmpty(this.Current.OLDXMBM)) return;
            string m_XMBM = info["OLDXMBM"].ToString();
            _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(m_UnitProject);
            DataRow dr_UnitFee = m_Methods_ParamsSeting.GetUnitFeeInfo(m_XMBM);
            if (dr_UnitFee != null) { info["ZYLB"] = dr_UnitFee["GCLB"].ToString().Replace("【", "").Replace("】", ""); }
            foreach (DataRow item in m_UnitProject.StructSource.ModelPSubheadingsFee.Rows)
            {
                if (string.IsNullOrEmpty(item["YYH"].ToString())) continue;

                DataRow dr = m_UnitProject.StructSource.ModelSubheadingsFee.NewRow();
                dr["EnID"] = info["EnID"];
                dr["UnID"] = info["UnID"];
                dr["SSLB"] = info["SSLB"];
                dr["QDID"] = info["PID"];
                dr["ZMID"] = info["ID"];
                dr["Sort"] = item["Sort"];
                dr["JSSX"] = item["JSSX"];
                dr["YYH"] = item["YYH"];
                dr["MC"] = item["MC"];
                dr["BDS"] = item["BDS"];
                dr["BZ"] = item["BZ"];
                dr["FYLB"] = item["FYLB"];
                if (dr["Sort"].Equals(7) && dr_UnitFee != null)
                {
                    dr["TBJSJC"] = dr_UnitFee["FXFTBJSJC"];
                    dr["BDJSJC"] = dr_UnitFee["FXFBDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(dr_UnitFee["FXTBFL"]);
                }
                else if (dr["Sort"].Equals(8) && dr_UnitFee != null)
                {
                    dr["TBJSJC"] = dr_UnitFee["GLFTBJSJC"];
                    dr["BDJSJC"] = dr_UnitFee["GLFBDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(dr_UnitFee["GLFFL"]);
                }
                else if (dr["Sort"].Equals(9) && dr_UnitFee != null)
                {
                    dr["TBJSJC"] = dr_UnitFee["LRFTBJSJC"];
                    dr["BDJSJC"] = dr_UnitFee["LRFBDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(dr_UnitFee["LRFL"]);
                }
                else
                {
                    switch (item["QFLB"].ToString())
                    {
                        case "0":
                            dr["TBJSJC"] = item["TBJSJC"];
                            break;
                        case "1":
                            dr["TBJSJC"] = item["SCJJC"];
                            break;
                        case "2":
                            dr["TBJSJC"] = item["BDJSJC"];
                            break;
                        default:
                            dr["TBJSJC"] = item["TBJSJC"];
                            break;
                    }
                    dr["BDJSJC"] = item["BDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(item["FL"]);
                }
                switch (dr["FYLB"].ToString())
                {
                    case "直接费单价":

                        dr["TBJE"] = ToolKit.ParseDecimal(ToolKit.ParseDecimal(item1.人工费单价) + ToolKit.ParseDecimal(item1.材料费单价) + ToolKit.ParseDecimal(item1.机械费单价) + ToolKit.ParseDecimal(item1.设备费单价) + ToolKit.ParseDecimal(item1.主材费单价));
                        break;

                    case "管理费单价":
                        dr["TBJSJC"] = this.GetFormula(item1.管理费计费基础, "子目取费");
                        dr["FL"] = ToolKit.ParseDecimal(item1.管理费费率);
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.管理费单价);
                        break;
                    case "利润单价":
                        dr["TBJSJC"] = this.GetFormula(item1.利润计费基础, "子目取费");
                        dr["FL"] = ToolKit.ParseDecimal(item1.利润费率);
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.利润单价);
                        break;
                    case "风险单价":
                        dr["TBJSJC"] = this.GetFormula(item1.风险计费基础, "子目取费");
                        dr["FL"] = ToolKit.ParseDecimal(item1.风险费率);
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.风险单价);
                        break;
                    case "人工费单价":
                        if (flag)
                        {
                            dr["TBJSJC"] = "DERGFDJ";
                        }
                        else
                        {
                            dr["TBJSJC"] = "RGFDJ";
                        }
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.人工费单价);
                        break;
                    case "机械费单价":
                        if (flag)
                        {
                            dr["TBJSJC"] = "HHJXFDJ";
                        }
                        else
                        {
                            dr["TBJSJC"] = "JXFDJ";
                        }
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.机械费单价);
                        break;
                    case "材料费单价":
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.材料费单价);
                        break;
                    case "主材费单价":
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.主材费单价);
                        break;
                    case "设备费单价":
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.设备费单价);
                        break;
                    case "子目单价":
                        dr["TBJE"] = ToolKit.ParseDecimal(item1.综合单价);
                        break;
                    default:
                        dr["TBJE"] = ToolKit.ParseDecimal(ToolKit.ParseDecimal(item1.综合单价) * ToolKit.ParseDecimal(item1.数量));
                        break;
                }
                dr["ID"] = m_UnitProject.StructSource.ModelSubheadingsFee.Rows.Count + 1;
                m_UnitProject.StructSource.ModelSubheadingsFee.Rows.Add(dr);
                this.ProjBusiness.Insert_Sql_SubheadingsFee(dr);
                this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->子目->子目取费", m_UnitProject.Name));
            }

        }

        private _ObjectSubheadingsFee GetZMQFBYLB(string LB, _List list)
        {
            //string str = "";
            IEnumerable<_ObjectSubheadingsFee> lists = from info in list.Cast<_ObjectSubheadingsFee>()
                                                       where info.FYLB == LB
                                                       select info;
            if (lists.Count() > 0)
            {
                _ObjectSubheadingsFee inf = lists.First();
                return inf;
            }

            else
            {
                return null;
            }

        }
        /// 工料机赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="hl"></param>
        private bool SetSubheadingsQuantityUnit(DataRow info, 定额子目 hl, string DECJ, _UnitProject m_UnitProject, 单位工程 m_DWGC)
        {
            string CLH = string.Empty;
            bool flag = false;
            DataTable clTable = null;
            DataRow sinfo = null;
            DataRow qinfo = null;
            DataRow[] clRow = null;
            if (hl.人材机含量 == null) return flag;
            foreach (人材机含量 item in hl.人材机含量)
            {
                sinfo = m_UnitProject.StructSource.ModelQuantity.NewRow();
                //sinfo.STATUS = Status.AreAdd;
                sinfo.BeginEdit();
                sinfo["ZCLB"] = "W";
                sinfo["ZMID"] = info["ID"];
                sinfo["QDID"] = info["PID"];
                sinfo["SSLB"] = info["SSLB"];
                sinfo["EnID"] = info["EnID"];
                sinfo["UnID"] = info["UnID"];
                if (m_DWGC.人材机库 != null && m_DWGC.人材机库.人才机 != null && m_DWGC.人材机库.人才机.Count > 0)
                {
                    人材机 rcj1 = GetRcjByNo(item.材料号, m_DWGC);
                    if (rcj1 != null)
                    {
                        if (string.IsNullOrEmpty(rcj1.单价))
                            CLH = GetCLH(item.材料号, hl.定额库代码);
                        else
                        {

                            if (string.IsNullOrEmpty(rcj1.定额价) && this.js.投标信息表.备注 == null)
                            {
                                CLH = GetCLH(item.材料号, hl.定额库代码);
                            }
                            else
                            {
                                CLH = item.材料号;
                            }

                        }
                    }
                }
                string[] strs = DECJ.Split('|');
                foreach (string str in strs)
                {
                    if (str != "")
                    {
                        if (str.Contains(CLH.Split('_')[0]))
                        {
                            sinfo["YSXHL"] = ToolKit.ParseDecimal(str.Split(',')[1]);//赋值原始消耗量 
                        }
                    }
                }

                //switch (hl.定额库代码)
                //{
                //    case 1:
                //        m_UnitProject.Property.Libraries.FixedLibrary = new _Library._LibraryData("建筑");
                //        break;
                //    case 2:
                //        m_UnitProject.Property.Libraries.FixedLibrary = new _Library._LibraryData("安装");
                //        break;
                //    case 3:
                //        m_UnitProject.Property.Libraries.FixedLibrary = new _Library._LibraryData("市政");
                //        break;
                //    case 4:
                //        m_UnitProject.Property.Libraries.FixedLibrary = new _Library._LibraryData("园林");
                //        break;
                //    case 5:
                //        m_UnitProject.Property.Libraries.FixedLibrary = new _Library._LibraryData("绿化");
                //        break;
                //    default:
                //        m_UnitProject.Property.Libraries.FixedLibrary = new _Library._LibraryData("建筑");
                //        break;

                //} 

                //DataRow[] rcjRows = m_DWGC.人材机库.人才机.Select("材料名 like '综合%'");
                string s = string.Empty;
                IEnumerable<人材机> rcjs = from info1 in m_DWGC.人材机库.人才机
                                        where (info1.材料号 == "10001" || info1.材料号 == "10002" || info1.材料号 == "4001") && (info1.材料名 == "综合工日" || info1.材料名 == "综合人工")
                                        select info1;
                if (rcjs == null && rcjs.Count() <= 0)
                {
                    s = SetRCj(info["LibraryName"].ToString(), CLH, sinfo, m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"]);

                }

                //string  s=  SetRCj(info["LibraryName"].ToString(), CLH, sinfo, m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"]);
                sinfo["BH"] = CLH + s;
                sinfo["XHL"] = ToolKit.ParseDecimal(item.含量);
                // sinfo["YSXHL"] = sinfo["XHL;
                人材机 rcj = GetRcjByNo(item.材料号, m_DWGC);
                //rcj.材料号 = GetCLH(item.材料号, hl.定额库代码);
                if (rcj != null)
                {

                    sinfo["MC"] = rcj.材料名;
                    sinfo["GGXH"] = rcj.规格型号;
                    sinfo["DW"] = rcj.单位;
                    sinfo["SCDJ"] = ToolKit.ParseDecimal(rcj.单价);
                    sinfo["DEDJ"] = ToolKit.ParseDecimal(rcj.单价);
                    sinfo["LB"] = rcj.费用类别;
                    sinfo["IFZYCL"] = rcj.主要材料标志;
                    sinfo["SSDWGC"] = m_UnitProject.Name;
                    sinfo["GCL"] = info["GCL"];

                    //判断是否有原始含量
                    if (item.原始含量 != null)
                    {
                        sinfo["YSXHL"] = item.原始含量;
                    }
                    //判断是否有定额价
                    if (rcj.定额价 != null)
                    {
                        sinfo["DEDJ"] = rcj.定额价;
                        if (sinfo["LB"].Equals("主材"))
                            sinfo["SCDJ"] = rcj.定额价;

                        clTable = m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"];
                        int index = sinfo["BH"].ToString().LastIndexOf("_");
                        if (index > 0)
                        {
                            clRow = clTable.Select("CAIJBH = '" + sinfo["BH"].ToString().Substring(0, index) + "'");
                        }
                        else
                        {
                            clRow = clTable.Select("CAIJBH = '" + sinfo["BH"].ToString() + "'");
                        }
                        if (clRow.Length > 0)
                        {
                            sinfo["LB"] = clRow[0]["CAIJLB"].ToString();
                        }
                    }
                    else
                    {
                        clTable = m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"];
                        int index = sinfo["BH"].ToString().LastIndexOf("_");
                        if (index > 0)
                        {
                            clRow = clTable.Select("CAIJBH = '" + sinfo["BH"].ToString().Substring(0, index) + "'");
                        }
                        else
                        {
                            clRow = clTable.Select("CAIJBH = '" + sinfo["BH"].ToString() + "'");
                        }
                        if (clRow.Length > 0)
                        {
                            sinfo["LB"] = clRow[0]["CAIJLB"].ToString();
                            sinfo["DEDJ"] = clRow[0]["CAIJDJ"].ToString();
                        }
                    }

                    if (sinfo["DEDJ"] == null || string.IsNullOrEmpty(sinfo["DEDJ"].ToString()) || sinfo["DEDJ"].ToString().Equals("0") || sinfo["DEDJ"].ToString().Equals("0.00"))
                    {
                        sinfo["DEDJ"] = sinfo["SCDJ"];
                    }
                    if (sinfo["DW"].ToString().Equals("%") && !rcj.材料名.Contains("降效"))
                    {
                        sinfo["DEDJ"] = 0;
                        sinfo["SCDJ"] = 0;
                    }


                    sinfo.EndEdit();

                    m_UnitProject.StructSource.ModelQuantity.Rows.Add(sinfo);
                    //_Methods_Quantity.RowCalculate(sinfo);
                    this.ProjBusiness.Insert_QuantityData(sinfo);
                    this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->工料机->{1}", m_UnitProject.Name, sinfo["BH"]));
                    if (rcj.人材机含量 != null)//查看是否含有组成
                    {
                        string clNo = string.Empty;
                        foreach (人材机含量 item0 in rcj.人材机含量)
                        {
                            clNo = string.Empty;
                            qinfo = m_UnitProject.StructSource.ModelQuantity.NewRow();
                            clNo = GetCLH(item0.材料号, hl.定额库代码);
                            qinfo["BH"] = clNo;
                            qinfo["XHL"] = item0.含量;
                            qinfo["SSDWGC"] = m_UnitProject.Name;
                            qinfo["GCL"] = ToolKit.ParseDecimal(info["GCL"].ToString()) * ToolKit.ParseDecimal(item.含量);
                            DataTable dt = null;
                            dt = m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["配合比表"];
                            DataRow[] drs_zc = dt.Select(string.Format("PHB_CJBH ='{0}' and CAIJBH='{1}'", qinfo["BH"], CLH.Split('_')[0]));
                            if (drs_zc.Length > 0)
                            {
                                qinfo["YSXHL"] = drs_zc[0]["PHB_CJSL"];//赋值原始消耗量
                            }

                            if (item0.原始含量 != null)
                            {
                                qinfo["YSXHL"] = item0.原始含量;
                            }
                            string s1 = SetRCj(info["LibraryName"].ToString(), clNo, qinfo, m_UnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"]);

                            if (m_XmlUnitProject.三大材 != null && m_XmlUnitProject.三大材.人才机 != null && m_XmlUnitProject.三大材.人才机.Count > 0)
                            {
                                foreach (人材机 item1 in m_XmlUnitProject.三大材.人才机)
                                {
                                    if (item0.材料号.Equals(item1.材料号))
                                    {
                                        人材机 rcj1 = GetRcjByNo(item1.材料号, m_DWGC);
                                        if (rcj1 != null)
                                            qinfo["SCDJ"] = rcj1.单价;
                                    }
                                }
                            }

                            if (m_DWGC.人材机库 != null && m_DWGC.人材机库.人才机 != null && m_DWGC.人材机库.人才机.Count > 0)
                            {
                                人材机 rcj1 = GetRcjByNo(clNo, m_DWGC);
                                if (rcj1 != null)
                                {
                                    if (!string.IsNullOrEmpty(rcj1.单价))
                                        qinfo["SCDJ"] = rcj1.单价;

                                }
                            }

                            qinfo["BH"] = clNo + s1;
                            if (sinfo["LB"].Equals("配合比"))
                            {
                                qinfo["ZCLB"] = "P";
                            }
                            else if (sinfo["LB"].ToString().Contains("台班"))
                            {
                                qinfo["ZCLB"] = "J";
                            }
                            qinfo["PID"] = sinfo["ID"];
                            qinfo["ZMID"] = info["ID"];
                            qinfo["QDID"] = info["PID"];
                            qinfo["SSLB"] = info["SSLB"];
                            qinfo["EnID"] = info["EnID"];
                            qinfo["UnID"] = info["UnID"];

                            m_UnitProject.StructSource.ModelQuantity.Rows.Add(qinfo);
                            //_Methods_Quantity.RowCalculate(qinfo);
                            this.ProjBusiness.Insert_QuantityData(qinfo);
                            this.ProjWorker.ProjWorker.ReportProgress(-1, string.Format("【{0}】->工料机->{1}", m_UnitProject.Name, sinfo["BH"]));
                        }
                    }
                }


                if (ToolKit.ParseDecimal(hl.人工费单价) == 0.00m)
                {
                    flag = true;
                }
                else
                {
                    if (CLH == "10001" || CLH == "4001")
                    {
                        //if (ToolKit.ParseDecimal(item.含量) * 42 == ToolKit.ParseDecimal(hl.人工费单价))

                        if (Math.Abs(ToolKit.ParseDecimal(item.含量) * 42 - ToolKit.ParseDecimal(hl.人工费单价)) <= Convert.ToDecimal(0.01))
                            flag = true;
                    }
                    if (CLH == "10002" || CLH == "4002")
                    {
                        //if (ToolKit.ParseDecimal(item.含量) * 50 == ToolKit.ParseDecimal(hl.人工费单价))
                        if (Math.Abs(ToolKit.ParseDecimal(item.含量) * 50 - ToolKit.ParseDecimal(hl.人工费单价)) <= Convert.ToDecimal(0.01))

                            flag = true;
                    }
                }

            }

            //判断 是否需要否计入价差 若需要返回true
            return flag;
        }

        /// <summary>
        /// 获取材料号
        /// </summary>
        /// <param name="CLH"></param>
        /// <returns></returns>
        private string GetCLH(string CLH, sbyte DEK)
        {
            bool flag = false;
            string str = CLH;
            string Temp = string.Empty;
            if (str.Contains('@'))
            {
                string[] s = str.Split('@');
                str = s[0];
                if (s.Length > 1) Temp = s[1];
            }
            else
            {
                string[] s = str.Split('_');
                str = s[0];
                if (s.Length > 1) Temp = s[1];
            }
            DataSet ds = _Common.Application.Global.DataTamp.变量对应表;
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables["材料对照表"];
                DataRow[] rows = dt.Select(" 接口变量='" + str + "' and 转换类别='" + GETZYLB(DEK) + "'");
                if (rows.Length > 0)
                {
                    str = rows[0]["标准变量"].ToString();
                }
                else
                {
                    DataTable dt1 = ds.Tables["材料对照表"];
                    DataRow[] rows1 = dt.Select(" 接口变量='" + str + "' and 接口代码='0'");
                    if (rows1.Length > 0)
                    {
                        str = rows1[0]["标准变量"].ToString();
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            if (Temp == string.Empty)
            {
                //if (flag)
                //{
                //    return str + "①";
                //}
                //else
                //{
                return str;
                //}
            }
            else
            {
                return str + "_" + Temp;
            }
        }
        private string GETZYLB(sbyte DEK)
        {
            string str = "123456";
            switch (DEK)
            {
                case 1:
                    str = "建筑装饰定额价目表";
                    break;
                case 2:
                    str = "安装定额价目表";
                    break;
                case 3:
                    str = "市政定额价目表";
                    break;
                case 4:
                    str = "园林定额价目表";
                    break;
                case 5:
                    str = "绿化定额价目表";
                    break;
                default:
                    break;
            }
            return str;
        }

        /// <summary>
        /// 工料机某些值从库里面读取
        /// </summary>
        /// <param name="LibraryName"></param>
        /// <param name="No"></param>
        /// <param name="info"></param>
        private string SetRCj(string LibraryName, string No, DataRow info, DataTable p_table)
        {
            string s = string.Empty;
            string str = No.Split('_')[0];
            // _Library.GetLibrary(LibraryName);
            DataTable dt = p_table;
            DataRow[] dr = dt.Select(string.Format("CAIJBH='{0}'", str));
            if (dr != null)
            {
                if (dr.Length > 0)
                {
                    //info["STATUS "] = Status.AreAdd;
                    info["IFSC"] = dr[0]["CAIJSC"].ToString() == "是" ? true : false;
                    info["YSBH"] = dr[0]["CAIJBH"].ToString();
                    info["YSMC"] = dr[0]["CAIJMC"].ToString();
                    info["YSDW"] = dr[0]["CAIJDW"].ToString();
                    //info["YSXHL "] = Convert.ToDecimal(str[1]);

                    info["DEDJ"] = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                    info["BH"] = dr[0]["CAIJBH"].ToString();
                    info["MC"] = dr[0]["CAIJMC"].ToString();
                    info["DW"] = dr[0]["CAIJDW"].ToString();
                    info["IFZYCL"] = dr[0]["CAIJXSJG"].ToString() == "是" ? true : false;
                    info["LB"] = dr[0]["CAIJLB"].ToString();
                    //info["XHL "] = Convert.ToDecimal(str[1]);
                    info["SCDJ"] = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                    info["SDCLB"] = dr[0]["SANDCMC"].ToString();
                    info["SDCXS"] = dr[0]["SANDCXS"].ToString().Length == 0 ? 0m : ToolKit.ParseDecimal(dr[0]["SANDCXS"]);
                    info["SSKLB"] = LibraryName;

                }
                else
                {
                    s = "①";
                }
            }
            else
            {
                s = "①";
            }
            return s;
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

        #endregion
    }
}
