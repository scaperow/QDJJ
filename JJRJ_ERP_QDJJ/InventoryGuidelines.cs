using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using GOLDSOFT.QDJJ.CTRL;
using System.Text.RegularExpressions;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class InventoryGuidelines : BaseForm
    {
       
        public delegate void AddgalleryPoolHandler();
        /// <summary>
        /// 插入清单事件
        /// </summary>
        public event AddgalleryPoolHandler OnaddIgalleryPool = null;
        EventHandler leh = null;
        EventHandler listboxeh = null;


        private object m_CurrQD = null;

        /// <summary>
        /// 当前操作的清单
        /// </summary>
        public object CurrQD
        {
            get { return m_CurrQD; }
            set { m_CurrQD = value; }
        }
 

      public  string QDPath = "";
      public  string DEPath = "";
        _Library _Clb = null;
        
        public InventoryGuidelines(_UnitProject active)
        {
            this.Activitie = active;
            InitializeComponent();
            leh = new EventHandler(ListGallery_Click);
            listboxeh = new EventHandler(ListBox_Click);
            this.listGallery1.listBoxControl1.Click -= new EventHandler(listboxeh);
            this.listGallery1.listBoxControl1.Click += new EventHandler(listboxeh);
            this.listGallery1.treeList1.Click -= new EventHandler(leh);
            this.listGallery1.treeList1.Click += new EventHandler(leh);
            listGallery1.Folder = APP.Application.Global.AppFolder;
            listGallery1.Default = this.Activitie;
            this.listGallery1.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }
        
        private void InventoryGuidelines_Load(object sender, EventArgs e)
        {
            BindTreeList();
        }

        public void BindTreeList()
        {
            this._Clb = CreateLib("");
            DataSet ds = this._Clb.FixedLibrary.LibraryDataSet;
            this.bindingSource1.DataSource = ds.Tables["定额表"].Copy();
            this.comboxTreelist1.DataSource = this.bindingSource1;
            this.bindingSource1.Filter = " 1=1 ";
            this.comboxTreelist1.CheckNodes.Clear();
            if (this.m_CurrQD != null)
            {
                this.listGallery1.textEdit1.Text = (this.m_CurrQD as _Entity_SubInfo).OLDXMBM;
            }
            ListBox_Click(this.listGallery1.listBoxControl1, null);
        }
        public void TreeListResate()
        {
            foreach (TreeListNode item in this.comboxTreelist1.Nodes)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                    comboxTreelist1_AfterCheckNode(comboxTreelist1, new NodeEventArgs(item));
                }

            }
        }
        /// <summary>
        /// 树节点单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListGallery_Click(object sender,EventArgs e)
        {

            TreeList tl = sender as TreeList;
            if (tl.Selection[0]!=null)
            {
                if (tl.Selection[0].Tag != null)
                {
                    DataRow row = tl.Selection[0].Tag as DataRow;
                    string str = CommonData.GetDEBHByQD(row["QINGDBH"].ToString(), this._Clb.ListGallery.LibraryDataSet.Tables["指引内容表"]);
                    Filter(str);
                }
            }
        }
        /// <summary>
        /// ListBox单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_Click(object sender, EventArgs e)
        {
            ListBoxControl tl = sender as ListBoxControl;
            DataRowView row = tl.SelectedItem as DataRowView;
            if (row != null)
            {
                string str = CommonData.GetDEBHByQD(row["QINGDBH"].ToString(), this._Clb.ListGallery.LibraryDataSet.Tables["指引内容表"]);
                Filter(str);
            }

        }
        private void Filter(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                this.bindingSource1.Filter = "DINGEH in (" + str + ")";
            }
            else
            {
                this.bindingSource1.Filter = "1<>1";
            }
            foreach (TreeListNode item in this.comboxTreelist1.Nodes)
            {
                if (item.Checked )
                {
                    item.Checked = false;
                    comboxTreelist1_AfterCheckNode(comboxTreelist1, new NodeEventArgs(item));
                }
                
            }
        }
        private _Library CreateLib(string GalleryName)
        {
            _Library lb = null;
            if (true)
            {
                lb = this.Activitie.Property.Libraries;
            }
            else
            {
                GalleryName = GalleryName.Replace(".qdsx", "");
                lb = new _Library();
                String GalleryLibName = "";
                String GalleryRule = "";
                Regex r = new Regex(@"\d{4}"); // 定义一个Regex对象实例
                Match mc = r.Match(GalleryName);
                if (mc.Success)
                {
                    if (mc.Value != "")
                    {
                        GalleryRule = mc.Value;
                        GalleryLibName = GalleryName.Replace(mc.Value, "");
                    }
                }

                lb.AppFolder = APP.Application.Global.AppFolder;
                lb.ListGallery.LibName = GalleryLibName;
                lb.ListGallery.Rule = GalleryRule;
                lb.FixedLibrary.LibName = GalleryLibName.Replace("清单库", "定额价目表");
                lb.FixedLibrary.Rule = GalleryRule;
                lb.Init(APP.Application);
            }

            QDPath = lb.ListGallery.Rule + lb.ListGallery.LibName;
            DEPath = lb.FixedLibrary.Rule + lb.FixedLibrary.LibName;
            return lb;

        }

        private void comboxTreelist1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (e.Node!=null)
            {
                object obj = this.comboxTreelist1.GetDataRecordByNode(e.Node);
                if (e.Node.Checked)
                {
                    if (!this.comboxTreelist1.CheckNodes.Contains(obj))
                    this.comboxTreelist1.CheckNodes.Add(obj);
                }
                else
                {
                    this.comboxTreelist1.CheckNodes.Remove(obj);
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
            else { this.Close(); }
        }

        private void comboxTreelist1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TreeListHitInfo hi = this.comboxTreelist1.CalcHitInfo(e.Location);
            //if (hi.Node != null)
            //{
            //    DataRowView v = this.comboxTreelist1.Current;
            //    if (v != null)
            //    {
            //        _Entity_SubInfo info1 = this.CurrQD as _Entity_SubInfo;
            //        if (info1 != null)
            //        {
            //            _Entity_SubInfo info = new _Entity_SubInfo();
            //            GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, v.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName);
            //            _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, info1);
            //            fix.Create(-1, info);
            //        }
            //    }
            //}
        }

    }
}


