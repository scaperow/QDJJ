using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars;

using GOLDSOFT.QDJJ.UI.Controls;
using ZiboSoft.Commons.Common;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using GOLDSOFT.QDJJ.CTRL;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace GOLDSOFT.QDJJ.UI
{
    public partial class QueryForm : BaseForm
    {
        /// <summary>
        /// 清单索引
        /// </summary>
        /// 
        InventoryGuidelines iform = null;

        /// <summary>
        /// 定额库
        /// </summary>
        QueryFixedLibrary qf = null;
        /// <summary>
        /// 清单库
        /// </summary>
        QueryGallery qg = null;

        /// <summary>
        /// 图集库
        /// </summary>
        AtlasGalleryForm ag = null;

        /// <summary>
        ///
        /// </summary>
        private _Entity_SubInfo m_CurrQD = null;

        public SubSegmentForm Sform;
        /// <summary>
        /// 当前操作的清单
        /// </summary>
        public _Entity_SubInfo CurrQD
        {
            get { return m_CurrQD; }
            set
            {
                m_CurrQD = value;

            }
        }
        private IEnumerable<_ObjectInfo> m_DataSource = null;

        public IEnumerable<_ObjectInfo> DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }
        public QueryForm(SubSegmentForm Sform)
        {
            this.Sform = Sform;
            this.Sform.FixedChange += new SubSegmentForm.FixedChangeHandler(Sform_FixedChange);
            InitializeComponent();
        }
        private void QueryForm_Load(object sender, EventArgs e)
        {
            //init();
            LoadPage("清单索引");
        }
        /// <summary>
        /// 选项卡添加form
        /// </summary>
        private void init()
        {



        }
        /// <summary>
        /// 从清单索引插入到清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.CurrQD == null) return;
            if (iform.comboxTreelist1.CheckNodes.Count < 1)
            {
                this.Alert("请选择定额号");
                return;
            }
            IEnumerable<DataRowView> views = iform.comboxTreelist1.CheckNodes.Cast<DataRowView>().OrderBy(p => p["DINGEH"].ToString());
            ArrayList a = new ArrayList();
            a.AddRange(views.ToList());
            int intStart = 0;
            foreach (DataRowView item in a)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                ///【2013.2.27 李波更改，作用处理各种备注来源】
                GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, item.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName, "CXCK", ++intStart, this.CurrQD.OLDXMBM);
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, this.CurrQD);
                fix.Create(-1, info);
            }
            this.ExpandNode();
            //BindData();
            //this.bindingSource5.ResetBindings(false);

            iform.TreeListResate();
        }


        private void OpenForm(BaseForm form, XtraTabPage xt)
        {
            form.Activitie = this.Activitie;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            //设置为非顶级控件
            form.TopLevel = false;
            //显示窗体
            form.Visible = true;
            xt.Controls.Add(form);

        }


        public void BindData()
        {
            //Sform.subSegmentListData1.DataBind();
            if (this.CurrQD != null)
                Sform.subSegmentListData1.FocusedNode(this.CurrQD.ID);
        }

        public void ExpandNode()
        {
            //Sform.subSegmentListData1.DataBind();
            if (this.CurrQD != null)
                Sform.subSegmentListData1.ExpandNode(this.CurrQD.ID);
        }



        /// <summary>
        /// 插入定额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sButtonOK_Click1(object sender, EventArgs e)
        {
            if (this.CurrQD == null) return;
            DataRowView view = qf.bindingSource1.Current as DataRowView;

            if (view != null)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                ///【2013.2.27 李波更改，作用处理各种备注来源】
                GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, view.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName, "CXCK", 1, this.CurrQD.OLDXMBM);
                // Sform.subSegmentListData1.Z_Inset(info);
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, this.CurrQD);
                fix.Create(-1, info);
                this.ExpandNode();
                //Sform.subSegmentListData1.FocusedNode(info.ID);
                this.BindData();
            }


        }
        /// <summary>
        /// 插入清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sButtonOK_Click(object sender, EventArgs e)
        {

            DataRowView view = qg.galleryGridList1.bindingSource1.Current as DataRowView;

            if (view != null)
            {
                if (this.CurrQD != null)
                {
                    if (string.IsNullOrEmpty(this.CurrQD.XMBM) && string.IsNullOrEmpty(this.CurrQD.XMMC))
                    {
                        DataRow row = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(this.CurrQD.ID.ToString());
                        if (row != null)
                            row.Delete();
                    }
                }
                _Entity_SubInfo info = new _Entity_SubInfo();
                ///【2013.2.26 李波更改，作用处理各种备注来源】
                GLODSOFT.QDJJ.BUSINESS._Methods.SetFixedInfo(info, view.Row, this.Activitie.Property.Libraries.ListGallery.FullName, this.Activitie.StructSource.ModelSubSegments, "CXCK");
                _Method_Sub met = _Method_Sub.GetSub(this.CurrentBusiness, this.Activitie);
                //当前操作的清单为null
                int m = this.CurrQD.Sort;
                met.Create(m, info);
                Sform.subSegmentListData1.FocusedNode(info.ID);
                //this.BindData();
                //this.CurrQD = info;





            }

            // throw new NotImplementedException();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem item = sender as BarEditItem;
            _Entity_SubInfo info = item.EditValue as _Entity_SubInfo;
            if (info != null)
            {
                this.CurrQD = info;
                this.BindData();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            LoadPage(e.Page.Name);
        }

        private void LoadPage(string PageName)
        {
            switch (PageName)
            {
                case "定额库":
                    if (qf == null)
                    {
                        qf = new QueryFixedLibrary(this.Activitie);
                        qf.CurrentBusiness = this.CurrentBusiness;
                        OpenForm(qf, this.定额库);
                        qf.sButtonOK.Click -= new EventHandler(sButtonOK_Click1);
                        qf.sButtonOK.Click += new EventHandler(sButtonOK_Click1);
                        qf.gridView1.DoubleClick -= new EventHandler(gridView1_DoubleClick);
                        qf.gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
                    }
                    break;
                case "清单索引":

                    if (iform == null)
                    {
                        iform = new InventoryGuidelines(this.Activitie);
                        iform.CurrentBusiness = this.CurrentBusiness;
                        iform.CurrQD = this.m_CurrQD;
                        iform.sButtonOK.Click -= new EventHandler(simpleButton1_Click);
                        iform.sButtonOK.Click += new EventHandler(simpleButton1_Click);
                        OpenForm(iform, this.清单索引);
                    }
                    break;

                case "清单库":
                    if (qg == null)
                    {
                        qg = new QueryGallery(this.Activitie);
                        qg.CurrentBusiness = this.CurrentBusiness;
                        OpenForm(qg, this.清单库);
                        qg.sButtonOK.Click -= new EventHandler(sButtonOK_Click);
                        qg.sButtonOK.Click += new EventHandler(sButtonOK_Click);
                        qg.galleryGridList1.gridView1.DoubleClick -= new EventHandler(gridView2_DoubleClick);
                        qg.galleryGridList1.gridView1.DoubleClick += new EventHandler(gridView2_DoubleClick);
                        if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                        {

                            qg.sButtonOK.Enabled = false;
                            qg.galleryGridList1.gridView1.DoubleClick -= new EventHandler(gridView2_DoubleClick);

                        }



                    }
                    break;

                case "图集库":
                    if (ag == null)
                    {
                        ag = new AtlasGalleryForm(this.Activitie);
                        ag.CurrentBusiness = this.CurrentBusiness;
                        OpenForm(ag, this.图集库);
                        if (this.CurrentBusiness.Current.IsDZBS && APP.Jzbx_pwd)
                        {
                            ag.simpleButton2.Enabled = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        //清单
        void gridView2_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs e1 = e as DevExpress.Utils.DXMouseEventArgs;
            GridView t = sender as GridView;
            GridHitInfo hi = t.CalcHitInfo(e1.Location);

            if (hi.InRow)
            {
                sButtonOK_Click(null, null);
            }
        }
        //定额
        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs e1 = e as DevExpress.Utils.DXMouseEventArgs;
            GridView t = sender as GridView;
            GridHitInfo hi = t.CalcHitInfo(e1.Location);
            if (hi.InRow)
            {
                sButtonOK_Click1(null, null);
            }
        }
        void Sform_FixedChange(_Entity_SubInfo sender)
        {
            this.m_CurrQD = sender;
            if (iform != null)
            {
                iform.CurrQD = sender;
                iform.BindTreeList();
            }

        }

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Sform.FixedChange -= new SubSegmentForm.FixedChangeHandler(Sform_FixedChange);
        }
    }

}