/*
 * 用于处理功能区的函数操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.CTRL;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using System.ComponentModel;
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.UI
{

    public class CActionFunction : IDisposable
    {

        public _Business Business;
        public _UnitProject Project;

        public CActionFunction(_Business business, _UnitProject project)
        {
            this.Business = business;
            this.Project = project;
        }


        #region 分部分项部分
        public void DoColumns(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            SelectSubsegmenColumn form = new SelectSubsegmenColumn();
            form.Activitie = obj.Activitie;
            form.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            form.Control = obj.subSegmentListData1.treeList1;

            DialogResult r = form.ShowDialog(obj);
            if (r == DialogResult.OK)
            {
                if (obj != null)
                {

                    // obj.subSegmentListData1.ChangeColums();
                }

            }
        }
        public void CopySingle(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                DataRowView v = obj.subSegmentListData1.treeList1.Current;
                if (v == null) { MsgBox.Show("没有选择子目！", MessageBoxButtons.OK); return; }
                if (v["LB"].ToString().Contains("子目"))
                {
                    FiexdCheck ck = new FiexdCheck();
                    ck.Activitie = obj.Activitie;
                    ck.CurrentBusiness = obj.CurrentBusiness;
                    ck.StrCZBM = "FZZT";
                    ck.ArrDE.Add(obj.subSegmentListData1.treeList1.Current);
                    ck.Show(obj);
                }
                else
                {
                    { MsgBox.Show("没有选择子目！", MessageBoxButtons.OK); return; }
                }
            }

        }
        public void CopyMore(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                FiexdCheck ck = new FiexdCheck();
                ck.Activitie = obj.Activitie;
                ck.CurrentBusiness = obj.CurrentBusiness;
                ck.StrCZBM = "KFZ";
                // bool flag = false;
                foreach (TreeListNode item in obj.subSegmentListData1.treeList1.Selection)
                {
                    DataRowView v = obj.subSegmentListData1.treeList1.GetDataRecordByNode(item) as DataRowView;
                    if (v != null)
                    {
                        if (v["LB"].ToString().Contains("子目"))
                        {
                            ck.ArrDE.Add(v);
                        }
                        else
                        {
                            MsgBox.Show("请不要选择非子目！", MessageBoxButtons.OK); return;
                        }
                    }
                }

                ck.Show(obj);
            }
        }

        public void FiexdUp(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                obj.UpOrDownFiexd(true);
            }
        }

        public void FiexdDown(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                obj.UpOrDownFiexd(false);
            }
        }
        _Method_Sub_ImportExcel m = null;
        string FileName = string.Empty;
        public void ImportEXcel(object sender, object e)
        {
            Container form1 = sender as Container;
            if (!form1.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
                if (obj != null)
                {
                    OpenFileDialog f = new OpenFileDialog();
                    f.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
                    DialogResult d = f.ShowDialog();
                    if (d == DialogResult.OK)
                    {
                        FileName = f.FileName;
                        m = new _Method_Sub_ImportExcel(obj.CurrentBusiness, obj.Activitie);
                        DialogResult dl = MsgBox.Show("是否清空之前的分部分项数据？", MessageBoxButtons.YesNo);
                        if (dl == DialogResult.Yes)
                        {
                            m.ClerSub();
                        }
                        BackgroundWorker AFormInitWorker = new BackgroundWorker();
                        AFormInitWorker.WorkerReportsProgress = false;
                        AFormInitWorker.DoWork += new DoWorkEventHandler(AFormInitWorker_DoWork);
                        AFormInitWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AFormInitWorker_RunWorkerCompleted);
                        AFormInitWorker.RunWorkerAsync();
                        ProgressFrom form = new ProgressFrom(AFormInitWorker);
                        form.ShowDialog();

                    }
                }
            }
        }

        void AFormInitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MsgBox.Show("导入成功！", MessageBoxButtons.OK);
        }

        void AFormInitWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            m.Import(FileName);
        }
        /// <summary>
        /// 查询窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void QueryForm(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {

                DataRowView v = obj.subSegmentListData1.treeList1.Current as DataRowView;
                if (v != null)
                {
                    QueryForm form = new QueryForm(obj);
                    form.Activitie = obj.Activitie;
                    form.CurrentBusiness = obj.CurrentBusiness;
                    form.Sform = obj;
                    switch (v["LB"].ToString())
                    {
                        case "子目录":

                            _Entity_SubInfo info = new _Entity_SubInfo();
                            DataRow row = obj.Activitie.StructSource.ModelSubSegments.GetRowByOther(v["ID"].ToString());
                            _ObjectSource.GetObject(info, row);
                            form.CurrQD = info;
                            break;
                        case "清单":
                            _Entity_SubInfo info2 = new _Entity_SubInfo();
                            DataRow row2 = obj.Activitie.StructSource.ModelSubSegments.GetRowByOther(v["ID"].ToString());
                            _ObjectSource.GetObject(info2, row2);
                            form.CurrQD = info2;
                            break;
                        default:
                            _Entity_SubInfo info1 = new _Entity_SubInfo();
                            DataRow row1 = obj.Activitie.StructSource.ModelSubSegments.GetRowByOther(v["PID"].ToString());
                            _ObjectSource.GetObject(info1, row1);
                            form.CurrQD = info1;
                            break;
                    }
                    form.Show(obj);
                }
            }

        }
        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ParameterSettings(object sender, object e)
        {
            Container form1 = sender as Container;
            ParameterSettings form = new ParameterSettings();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Activitie = form1.Activitie;
            form.Show(form1);

        }
        /// <summary>
        /// 序号重排
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Listguidelines(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                obj.subSegmentListData1.RestXH();
                obj.subSegmentListData1.DataBind();

            }
        }



        public void FindReplace(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            FindReplaceForm form = new FindReplaceForm();
            form.sform = obj;
            form.Activitie = obj.Activitie;
            // form.Fitler = obj.subSegmentListData1.Source.Filter;
            // obj.subSegmentListData1.treeList1.BeginUnboundLoad();
            form.Show(form1);
            //if (r == DialogResult.OK)
            {
                // obj.BindSubSegmentList();
                //obj.subSegmentListData1.treeList1.EndUnboundLoad();
                // obj.subSegmentListData1.treeList1.Refresh();
                //obj.subSegmentListData1.Source.ResetBindings(true);
                //obj.subSegmentListData1.DataBind();
            }
            // obj.subSegmentListData1.Source.Filter = form.Fitler;
            //obj.subSegmentListData1.treeList1.EndUnboundLoad();
        }
        /// <summary>
        /// 整理到节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToFestival(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            obj.subSegmentListData1.DataBind(EListType.Festival);

            obj.subSegmentListData1.treeList1.Expand(3);
        }
        /// <summary>
        /// 整理到章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToChapter(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            obj.subSegmentListData1.DataBind(EListType.Chapter);

            obj.subSegmentListData1.treeList1.Expand(2);
        }
        /// <summary>
        /// 整理到专业
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToPro(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            //obj.Activitie.Property.SubSegments.ListType = EListType.Professional;
            //obj.Activitie.Property.SubSegments.ChangeSource();
            obj.subSegmentListData1.DataBind(EListType.Professional);
            //obj.subSegmentListData1.treeList1.Expand(1);
            obj.subSegmentListData1.treeList1.Expand(1);
        }
        /// <summary>
        /// 撤销整理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToDefault(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            // obj.subSegmentListData1.Columns = APP.DataObjects.Columns;
            //obj.subSegmentListData1.ChangeColums();
            //obj.Activitie.Property.SubSegments.ListType = EListType.Default;
            obj.subSegmentListData1.DataBind(EListType.Default);
            obj.subSegmentListData1.treeList1.Expand(1);
        }
        /// <summary>
        /// 子目增加费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IncreaseCosts(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (!obj.Activitie.ProType.Contains("安装"))
            {
                return;
            }
            IncreaseCosts inf = new IncreaseCosts();
            inf.SubSegmentForm = obj;
            inf.Activitie = obj.Activitie;
            inf.CurrentBusiness = obj.CurrentBusiness;
            inf.ShowDialog();
        }
        /// <summary>
        /// 超高降效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EfficiencyForm(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            EfficiencyForm form = new EfficiencyForm();
            form.Activitie = obj.Activitie;
            form.CurrentBusiness = obj.CurrentBusiness;
            DialogResult dl = form.ShowDialog();

        }
        /// <summary>
        /// 模板到措施
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MobToMeasures(object sender, object e)
        {
            /// </summary>
            Container form1 = sender as Container;
            // Container form1 = (e as object[])[0] as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            MobToMeasures form = new MobToMeasures();
            form.Activitie = obj.Activitie;
            form.CurrentBusiness = obj.CurrentBusiness;
            form.Show(obj);

        }
        /// <summary>
        /// 自动报价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AutomatedQuotation(object sender, object e)
        {
            Container form1 = sender as Container;
            // Container form1 = (e as object[])[0] as Container;
            // SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            _Methods_AutomatedQuotation met = new _Methods_AutomatedQuotation(form1.Activitie);
            met.Refersh();
        }
        # endregion

        /// <summary>
        /// 批量选择与设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnBotchSelection(object sender, object e)
        {
            //BotchSelectionAndSet  frmBotchSelection = new BotchSelectionAndSet();
            //frmBotchSelection.Show();
        }

        public void checkDecompositionMix(object sender, object e)
        {

        }

        /// <summary>
        /// 复制组价到其他清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CopyToQD(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {

                DataRowView info = obj.subSegmentListData1.treeList1.Current as DataRowView;
                if (info != null)
                { _Entity_SubInfo _eninfo = new _Entity_SubInfo();
                        _ObjectSource.GetObject(_eninfo, info.Row);
                    if (info["LB"].Equals("清单"))
                    {
                        //obj.subSegmentListData1.Source.SuspendBinding();
                        CopyToQD ct = new CopyToQD();
                        ct.Activitie = obj.Activitie;
                        ct.CurrentBusiness = obj.CurrentBusiness;
                       
                        ct.Info = _eninfo;
                        ct.Show(form1);
                        //obj.subSegmentListData1.Source.ResumeBinding();
                        //if (dl == DialogResult.OK)
                        //{
                        //    obj.subSegmentListData1.DataBind();
                        //}
                    }

                    GLODSOFT.QDJJ.BUSINESS._Methods calculateMethod = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Business, this.Project, _eninfo);
                    calculateMethod.Begin(null);
                }

            }

        }

        /// <summary>
        /// 提取其他清单组价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CopyFromQD(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                DataRowView info = obj.subSegmentListData1.treeList1.Current as DataRowView;
                if (info != null)
                {
                    _Entity_SubInfo _eninfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(_eninfo, info.Row);
                    if (info["LB"].Equals("清单"))
                    {
                        CopyFromQD ct = new CopyFromQD();
                        ct.Activitie = obj.Activitie;
                        ct.Info = _eninfo;
                        ct.CurrentBusiness = obj.CurrentBusiness;
                        ct.Show(form1);
                        //DialogResult dl = ct.ShowDialog();
                        //if (dl == DialogResult.OK)
                        //{
                        //    obj.subSegmentListData1.DataBind();
                        //}
                    }

                    GLODSOFT.QDJJ.BUSINESS._Methods calculateMethod = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Business, this.Project, _eninfo);
                    calculateMethod.Begin(null);
                }
            }

        }

        /// <summary>
        /// 调整工程量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ImproveGCL(object sender, object e)
        {
            //object[] o = e as object[];
            //Container form1 = o[0] as Container;
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                ImproveGCL form = new ImproveGCL();
                form.Activitie = obj.Activitie;
                form.CurrentBusiness = obj.CurrentBusiness;
                form.pform = obj;
                DialogResult dl = form.ShowDialog();
                //if (dl == DialogResult.OK)
                //{
                //    obj.subSegmentListData1.DataBind();
                //}
            }
        }

        public void ImproveXHL(object sender, object e)
        {
            //object[] o = e as object[];
            //Container form1 = o[0] as Container;
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                ImproveXHL form = new ImproveXHL();
                form.Activitie = obj.Activitie;
                form.CurrentBusiness = obj.CurrentBusiness;
                form.pform = obj;
                DialogResult dl = form.ShowDialog();
                //if (dl == DialogResult.OK)
                //{
                //    obj.subSegmentListData1.DataBind();
                //}
            }
        }
        #region ---------------------汇总分析------------------------
        /// <summary>
        /// 添加汇总分析清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CMetaanalysisForm_Add(object sender, object e)
        {
            Container form = sender as Container;
            if (!form.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                CMetaanalysisForm f = form.GetWorkAreas as CMetaanalysisForm;
                f.Add();
            }
        }

        /// <summary>
        /// 添加汇总分析子清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CMetaanalysisForm_AddCHD(object sender, object e)
        {
            Container form = sender as Container;
            if (!form.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                CMetaanalysisForm f = form.GetWorkAreas as CMetaanalysisForm;
                f.AddChd();
            }
        }

        /// <summary>
        /// 添加汇总分析子清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CMetaanalysisForm_Delete(object sender, object e)
        {
            Container form = sender as Container;
            if (!form.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                CMetaanalysisForm f = form.GetWorkAreas as CMetaanalysisForm;
                f.Delete();
            }
        }

        /// <summary>
        /// 添加汇总分析子清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CMetaanalysisForm_Save(object sender, object e)
        {
            Container form = sender as Container;
            if (!form.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                CMetaanalysisForm f = form.GetWorkAreas as CMetaanalysisForm;
                f.Save();
            }
        }

        /// <summary>
        /// 添加汇总分析子清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CMetaanalysisForm_Load(object sender, object e)
        {
            Container form = sender as Container;
            CMetaanalysisForm f = form.GetWorkAreas as CMetaanalysisForm;
            f.Loads();
        }

        #endregion

        public void QuickPrice(object sender, object e)
        {
            Container form1 = sender as Container;
            SubSegmentForm obj = form1.GetWorkAreas as SubSegmentForm;
            if (obj != null)
            {
                QuickPrice qform = new QuickPrice();
                qform.Activitie = obj.Activitie;
                qform.CurrentBusiness = obj.CurrentBusiness;
                qform.sform = obj;
                qform.ShowDialog();
                //obj.RefreshDataSource();
                // obj.subSegmentListData1_OnChildRefresh();
            }
        }

        #region------------------------------项目中的操作-------------------------

        /// <summary>
        /// 项目分部分项数据筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pro_SubSegment_Data_Filter(object sender, object e)
        {
            Container form1 = sender as Container;
            ProSubSegmentForm pf = form1.GetWorkAreas as ProSubSegmentForm;
            CPro_Sub_Data_Filter from = new CPro_Sub_Data_Filter();
            from.CurrentBusiness = pf.CurrentBusiness;
            from.DataSource = pf.DataSource;
            DialogResult r = from.ShowDialog();
            if (r == DialogResult.OK)
            {
                pf.Bind(from.Result);
            }
        }

        /// <summary>
        /// 项目分部分项显示隐藏列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pro_Sub_Columns(object sender, object e)
        {
            Container form1 = sender as Container;
            ProSubSegmentForm obj = form1.GetWorkAreas as ProSubSegmentForm;
            SelectSubsegmenColumn form = new SelectSubsegmenColumn();
            form.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            form.Control = obj.treeListEx1;
            DialogResult r = form.ShowDialog(obj);
            if (r == DialogResult.OK)
            { }
        }

        /// <summary>
        /// 项目措施项目数据筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pro_MeasuresFrom_Data_Filter(object sender, object e)
        {
            Container form1 = sender as Container;
            ProMeasuresFrom pf = form1.GetWorkAreas as ProMeasuresFrom;
            CPro_Sub_Data_Filter from = new CPro_Sub_Data_Filter();
            from.CurrentBusiness = pf.CurrentBusiness;
            from.DataSource = pf.DataSource;
            DialogResult r = from.ShowDialog();
            if (r == DialogResult.OK)
            {
                pf.Bind(from.Result);
            }
        }

        public void ProjectAdjust(object sender, object e)
        {
            Container form1 = sender as Container;
            ProSubSegmentForm pf = form1.GetWorkAreas as ProSubSegmentForm;
            ProjectAdjust from = new ProjectAdjust();
            from.CurrentBusiness = pf.CurrentBusiness;
            //from.DataSource = pf.DataSource;
            DialogResult r = from.ShowDialog();
            if (r == DialogResult.OK)
            {
                // pf.Bind(from.Result);
            }
        }


        /// <summary>
        /// 项目汇总分析显示隐藏列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pro_Measures_Columns(object sender, object e)
        {
            Container form1 = sender as Container;
            ProMeasuresFrom obj = form1.GetWorkAreas as ProMeasuresFrom;
            SelectSubsegmenColumn form = new SelectSubsegmenColumn();
            form.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            form.Control = obj.treeListEx1;
            DialogResult r = form.ShowDialog(obj);
            if (r == DialogResult.OK)
            { }
        }
        /// <summary>
        /// 其他项目的列隐藏显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pro_Other_Columns(object sender, object e)
        {
            Container form1 = sender as Container;
            ProOtherForm obj = form1.GetWorkAreas as ProOtherForm;
            SelectSubsegmenColumn form = new SelectSubsegmenColumn();
            form.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            form.Control = obj.treeListEx1;
            DialogResult r = form.ShowDialog(obj);
            if (r == DialogResult.OK)
            { }
        }

        public void Pro_HZFX_REST(object sender, object e)
        {
            Container form1 = sender as Container;
            HuiZongProjectForm form = form1.GetWorkAreas as HuiZongProjectForm;
            form.DoLoadData();
        }

        #endregion

        #region  其他项目
        public void Other_Save(object sender, object e)
        {
            Container form1 = sender as Container;
            if (!form1.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                OtherProjectForm form = form1.GetWorkAreas as OtherProjectForm;
                form.Save();
            }
        }

        public void Other_Load(object sender, object e)
        {
            Container form1 = sender as Container;
            if (!form1.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                OtherProjectForm form = form1.GetWorkAreas as OtherProjectForm;
                form.load();
            }
        }
        /// <summary>
        /// 其他项目增加项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Other_Add(object sender, object e)
        {
            Container form1 = sender as Container;
            OtherProjectForm form = form1.GetWorkAreas as OtherProjectForm;
            form.Add();
        }
        /// <summary>
        /// 其他项目增加子项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Other_AddChild(object sender, object e)
        {
            Container form1 = sender as Container;
            OtherProjectForm form = form1.GetWorkAreas as OtherProjectForm;
            form.Add_Child();
        }
        /// <summary>
        /// 其他项目 删除项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Other_Del(object sender, object e)
        {
            Container form1 = sender as Container;
            OtherProjectForm form = form1.GetWorkAreas as OtherProjectForm;
            form.Delete();
        }

        public void LoadJGC(object sender, object e)
        {
            Container form1 = sender as Container;
            OtherProjectForm form = form1.GetWorkAreas as OtherProjectForm;

            form.LoadJGC();
        }

        #endregion


        #region ---------------------------通用方法-------------------------

        /// <summary>
        /// 刷新指定模块的数据 项目管理的数据刷新使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Com_RestData(object sender, object e)
        {
            CWellComeProject form1 = sender as CWellComeProject;
            if (form1 != null)
            {
                form1.AfterStatisticaled += new AfterStatisticaledHandler(form1_AfterStatisticaled);
                ABaseForm form = form1.GetWorkAreas as ABaseForm;
                //汇总分析
                if (form is HuiZongProjectForm)
                {
                    form1.InitProjectData(ERevealType.汇总分析);
                }
                //措施项目
                if (form is ProMeasuresFrom)
                {

                    form1.InitProjectData(ERevealType.措施项目);
                }
                //分部分项
                if (form is ProSubSegmentForm)
                {
                    form1.InitProjectData(ERevealType.分部分项);
                }
                //form.Init();
            }


        }

        void form1_AfterStatisticaled(object sender, object args)
        {
            CWellComeProject form1 = sender as CWellComeProject;
            form1.AfterStatisticaled -= new AfterStatisticaledHandler(form1_AfterStatisticaled);
            ABaseForm form = form1.GetWorkAreas as ABaseForm;
            form.Init();
        }

        #endregion

        #region


        public void Measures_ChangeCol(object sender, object e)
        {
            Container form1 = sender as Container;
            MeasuresProjectForm obj = form1.GetWorkAreas as MeasuresProjectForm;
            SelectSubsegmenColumn form = new SelectSubsegmenColumn();
            form.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            form.Control = obj.treeList1;
            DialogResult r = form.ShowDialog(obj);
            if (r == DialogResult.OK)
            { }
        }

        /// <summary>
        /// 增加通用项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Measures_AddCommonroject(object sender, object e)
        {
            Container form1 = sender as Container;
            MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;

            form.AddCommonroject();
        }
        /// <summary>
        /// 增加清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Measures_AddFixed(object sender, object e)
        {
            Container form1 = sender as Container;
            MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;
            form.AddFixed();
        }
        /// <summary>
        /// 增加子目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Measures_AddSubheadings(object sender, object e)
        {
            Container form1 = sender as Container;
            MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;
            form.AddSubheadings();
        }
        /// <summary>
        /// 删除所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Measures_Del(object sender, object e)
        {
            Container form1 = sender as Container;
            MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;
            form.Delete();
        }

        public void Measures_Save(object sender, object e)
        {
            Container form1 = sender as Container;
            if (!form1.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;
                form.Save();
            }
        }

        public void Measures_Load(object sender, object e)
        {
            Container form1 = sender as Container;
            if (!form1.CurrentBusiness.Current.IsDZBS || APP.Jzbx_pwd)
            {
                MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;
                form.load();
            }
        }
        /// <summary>
        /// 模板到分部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MobToFB(object sender, object e)
        {
            Container form1 = sender as Container;
            MeasuresProjectForm form = form1.GetWorkAreas as MeasuresProjectForm;
            form.MobToFB();
        }
        #endregion

        #region --------------------------工程信息-----------------------
        /// <summary>
        /// 工程设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Com_ProSettings(object sender, object e)
        {
            Container form1 = sender as Container;
            ProInformation obj = form1.GetWorkAreas as ProInformation;
            if (obj != null)
            {
                ProSetting proSettingsForm = new ProSetting();
                proSettingsForm.Activitie = obj.Activitie;
                proSettingsForm.ShowDialog();
            }
        }
        /// <summary>
        /// 预览所有清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Com_ProData2SubSegments(object sender, object e)
        {
            Container form1 = sender as Container;
            ProInformation obj = form1.GetWorkAreas as ProInformation;
            if (obj != null)
            {
                obj.PreviewQD();
            }
        }
        /// <summary>
        /// 导出Excel【此功能下个版本出】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Com_ProData2Excel(object sender, object e)
        {

        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {

        }

        #endregion
    }
}
