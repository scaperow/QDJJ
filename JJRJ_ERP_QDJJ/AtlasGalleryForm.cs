using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.CTRL;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using ZiboSoft.Commons.Common;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class AtlasGalleryForm : BaseForm
    {
        /// <summary>
        /// 图集定额
        /// </summary>
        private DataTable m_TabTJDE;
        /// <summary>
        /// 图集类型
        /// </summary>
        private DataTable m_TabTJLX;
        DataTable m_TJNR;
        private DataSet ds;
        /// <summary>
        /// 带参数构造  
        /// </summary>
        /// <param name="act">单位工程</param>
        public AtlasGalleryForm(_UnitProject act)
        {
            this.Activitie = act;
            this.ds = this.Activitie.Property.Libraries.AtlasGallery.LibraryDataSet;
            InitializeComponent();
            this.atlasGallery1.buttonEdit1.Text = this.Activitie.Property.Libraries.AtlasGallery.FullName;
            this.gridView3.OptionsBehavior.Editable = true;
        }


        public AtlasGalleryForm()
        {
            //this.Activitie = act;
            string Path = APP.Application.Global.AppFolder.FullName + "库文件\\图集库\\陕标09系列建筑图集.tjsx";
            this.ds = GetTJ(Path);
            InitializeComponent();
            FileInfo info = new FileInfo(Path);
            this.atlasGallery1.buttonEdit1.Text = info.Name;
            this.gridView3.OptionsBehavior.Editable = false;

        }
        private DataSet GetTJ(string Path)
        {
            DataSet ds = null;
            ds=  GOLDSOFT.QDJJ.COMMONS.CFiles.BinaryDeserializeForLib(Path);
            return ds;
        }


        private void AtlasGalleryForm_Load(object sender, EventArgs e)
        {
            init();
        }

       
        private void init()
        {
           
            if (this.ds!=null)
            {
                BindSource();
            }
            this.atlasGallery1.treeList1.Click += new EventHandler(treeList1_Click);
            this.atlasGallery1.textEdit1.EditValueChanged += new EventHandler(textEdit1_EditValueChanged);
            this.atlasGallery1.btn_open.Click += new EventHandler(simpleButton3_Click);
            //this.atlasGallery1.buttonEdit1.Text= this.Activitie.Property.Libraries.AtlasGallery.FullName;
        }

      
        /// <summary>
        /// 所有的控件数据绑定
        /// </summary>
        private void BindSource()
        {
            this.m_TabTJDE = this.ds.Tables["图集定额表"].Copy();
            this.m_TabTJLX = this.ds.Tables["图集类型表"].Copy();
            this.m_TJNR = this.ds.Tables["图集内容清单表"].Copy();
            if (!this.m_TJNR.Columns.Contains("LX")) this.m_TJNR.Columns.Add("LX");
            this.bindingSource3.DataSource = this.ds.Tables["图集做法表"].Copy();
            this.atlasGallery1.Source = this.ds.Tables["图集索引表"];
            this.m_TJNR.ColumnChanged -= new DataColumnChangeEventHandler(m_TJNR_ColumnChanged);
            this.m_TJNR.ColumnChanged += new DataColumnChangeEventHandler(m_TJNR_ColumnChanged);
            this.treeListEx2.DataSource = this.bindingSource3;
            this.bindingSource1.DataSource = this.m_TJNR;
            this.gridControl3.DataSource = this.bindingSource1;
            
            this.atlasGallery1.Loads();
            
        }
        void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit t = sender as TextEdit;
            string str = t.EditValue.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                this.bindingSource1.Filter = string.Format("TJBH like '%{0}%' or TJMC like '%{0}%'", str);
            }
            else
            {
                this.bindingSource1.Filter = ""; 
            }

            bindingSource1_PositionChanged(null, null);
        }

        void m_TJNR_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "LX")
            {
                bindingSource1_PositionChanged(null, null);

            }
            
        }

   
        /// <summary>
        /// 图集索引树点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.TreeList t = sender as DevExpress.XtraTreeList.TreeList;
           if (t.Selection[0] != null)
           {
               //如果选中且没有儿子
               if (!t.Selection[0].HasChildren)
               {
                   string str = t.Selection[0].GetValue("SYBH").ToString();
                   this.bindingSource1.Filter = string.Format("SYBH = '{0}'", str);
                   bindingSource1_PositionChanged(null, null);

               }
           }
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            DataRowView view = this.bindingSource1.Current as DataRowView;
            if (view!=null)
            {
                this.memoEdit1.Text = "图集名称：" + view["TJMC"] + _Constant.回车符
                              + "备注：" + view["BZ"].ToString() + "";
                FilterDE(view);
                FilterZF(view["TJBH"].ToString());
                foreach (TreeListNode item in this.treeListEx1.Nodes)
                {
                    item.Checked = true;
                    treeListEx1_AfterCheckNode(this.treeListEx1, new DevExpress.XtraTreeList.NodeEventArgs(item));

                }
                foreach (TreeListNode item in this.treeListEx2.Nodes)
                {
                    item.Checked = true;
                    treeListEx1_AfterCheckNode(this.treeListEx2, new DevExpress.XtraTreeList.NodeEventArgs(item));

                }
            }
        }
        /// <summary>
        /// 根据选中图集内容筛选定额
        /// </summary>
        /// <param name="view">当前选中的图集内容</param>
        private void FilterDE(DataRowView view)
        {
            DataTable dt = this.m_TabTJDE.Clone();
            foreach (DataRow item in this.m_TabTJDE.Select(string.Format("TJBH ='{0}'", view["TJBH"])))
            {
                DataRow row = dt.NewRow();
                row.ItemArray = item.ItemArray;
                dt.Rows.Add(row);
            }
            int m = dt.Rows.Count;
            if (view["LX"]!=null)
            {
                if (!string.IsNullOrEmpty(view["LX"].ToString()))
                {
                    string[] LX = view["LX"].ToString().Split(',');
                    foreach (string str in LX)
                    {
                        if (str != "")
                        {
                            foreach (DataRow item in this.m_TabTJLX.Select(string.Format("ID ={0}", str)))
                            {
                                m++;
                                DataRow row = dt.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DEDW"] = item["DEDW"];
                                row["GCXS"] = item["GCXS"];
                                row["ID"] = m;
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            this.treeListEx1.DataSource = dt;
            this.treeListEx1.CheckNodes.Clear();
        }

        private void FilterZF(string TJBH)
        {
            this.bindingSource3.Filter = string.Format("TJBH ='{0}'", TJBH);
            foreach (TreeListNode item in this.treeListEx2.Nodes)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                }
                
            }
            this.treeListEx2.CheckNodes.Clear();
        }
        /// <summary>
        /// 获取选择的定额或做法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListEx1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeListEx t = sender as TreeListEx;
            if (e.Node!=null)
            {
                object obj = t.GetDataRecordByNode(e.Node);
                if (e.Node.Checked)
                {
                    if (!t.CheckNodes.Contains(obj))
                    {
                        t.CheckNodes.Add(obj);
                    }
                }
                else
                {
                    t.CheckNodes.Remove(obj);
                }
            }
        }
        private void gridView3_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "TJBH":
                        e.RepositoryItem = this.repositoryItemButtonEdit1;
                    break;
                default:
                    break;
            }
        }
        private bool IsShow(object obj)
        {
            bool flag = false;
            if (obj==null)
            {
                return false;
            }
            DataRow[] rows = this.m_TabTJLX.Select(string.Format("TJBH like '%{0}%'", ","+obj+","));
            if (rows.Length>0)
            {
                flag = true;
            }
            return flag;
        }

        private void gridView3_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (this.Activitie == null) return;
            if (this.gridView3.FocusedColumn.FieldName == "TJBH")
            {
                if (!IsShow(this.gridView3.FocusedValue))
                {
                    this.gridView3.OptionsBehavior.Editable = false;
                }
                else
                {
                    this.gridView3.OptionsBehavior.Editable = true;
                }
            }
            else
            {
                this.gridView3.OptionsBehavior.Editable = true;
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView3_FocusedColumnChanged(null, null);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            QueryForm pform = this.ParentForm as QueryForm;
            if (pform == null) return;
            if (pform.CurrQD == null) return;
            _Entity_SubInfo info1 = new _Entity_SubInfo();
            DataRow row = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(pform.CurrQD.ID.ToString());
            if (row == null) return;
            _ObjectSource.GetObject(info1, row);
            pform.CurrQD = info1;


            foreach (TreeListNode node in this.treeListEx1.Nodes)
            {
                treeListEx1_AfterCheckNode(this.treeListEx1, new DevExpress.XtraTreeList.NodeEventArgs(node));

            }

            foreach (DataRowView item in this.treeListEx1.CheckNodes)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();

                GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfoByTJ(info, item.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName);

                DataRow[] rows = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Select("DINGEH='" + info.OLDXMBM + "'");
                if (rows.Length > 0)
                {
                    info.JX = rows[0]["JIANGX"].Equals("是") ? true : false;
                    info.TX = rows[0]["TX1"].ToString();
                }
                // info.IsHs = false;
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, pform.CurrQD);
                fix.Create(-1, info);
            }

            pform.BindData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            QueryForm pform = this.ParentForm as QueryForm;
            if (pform == null) return;
            if (pform.CurrQD == null) return;
            _Entity_SubInfo info = new _Entity_SubInfo();
            DataRow row = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(pform.CurrQD.ID.ToString());
            if (row == null) return;
            _ObjectSource.GetObject(info, row);
            pform.CurrQD = info;
            DataRow r = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(pform.CurrQD.ID.ToString());
            string TextValue = r["XMMC"].ToString();
            string Titile = _Constant.回车符 + "【标准图集】";
            string TJNR = _Constant.回车符 + "【标准图集】" + _Constant.回车符;
            DataRowView view = this.bindingSource1.Current as DataRowView;
            if (view == null) return;
            DataRow[] rows1 = this.ds.Tables["图集索引表"].Copy().Select(string.Format("SYBH={0}", view["SYBH"]));
            if (rows1.Length > 0)
            {
                DataRow[] rows = this.ds.Tables["图集索引表"].Copy().Select(string.Format("SYBH={0}", rows1[0]["PARENTID"]));
                if (rows.Length > 0)
                {
                    if (ToolKit.ParseInt(rows[0]["PARENTID"]) == 1)
                        TJNR += rows[0]["MUNR"] + ":" + rows1[0]["MUNR"] + ":" + (this.bindingSource1.Current as DataRowView)["TJBH"] + _Constant.回车符;
                    else
                    {
                        DataRow[] rows2 = this.ds.Tables["图集索引表"].Select(string.Format("SYBH={0}", rows[0]["PARENTID"]));
                        if (rows2.Length > 0) { TJNR += (rows2[0]["MUNR"] + ":" + rows[0]["MUNR"] + ":" + rows1[0]["MUNR"] + ":" + (this.bindingSource1.Current as DataRowView)["TJBH"] + _Constant.回车符); }
                    }
                }
            }
            int i = 1;
            string Str = "";

            foreach (TreeListNode node in this.treeListEx2.Nodes)
            {
                treeListEx1_AfterCheckNode(this.treeListEx2, new DevExpress.XtraTreeList.NodeEventArgs(node));

            }

            foreach (DataRowView item in this.treeListEx2.CheckNodes)
            {
                if (item["ZFMC"].ToString() != "")
                {
                    Str += i.ToString() + "." + item["ZFMC"] + _Constant.回车符;
                    i++;
                }
            }
            Str = Str.TrimEnd();
            TJNR += Str;
            string Result = GLODSOFT.QDJJ.BUSINESS._Methods.SetTextBox(TextValue, TJNR, Titile);
            r.BeginEdit();
            r["XMMC"] = Result;
            r.EndEdit();
            SubSegmentForm form = pform.Sform;
            if (form != null) form.subSegmentListData1.treeList1.Refresh();
           
        }
       

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit but = sender as DevExpress.XtraEditors.ButtonEdit;

            TJLXSelect form = new TJLXSelect();
            form.Activitie = this.Activitie;
            form.TJBH = but.Text;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Source = this.m_TabTJLX;
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {
                DataRowView view = this.bindingSource1.Current as DataRowView;
                if (view != null)
                {
                    view.BeginEdit();
                    view["LX"]+= ","+form.LXID;
                    view.EndEdit();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = APP.Application.Global.AppFolder.FullName + "库文件\\图集库";
           DialogResult dl= this.openFileDialog1.ShowDialog();
           if (dl==DialogResult.OK)
           {
               try
               {
                   DataSet ds = GOLDSOFT.QDJJ.COMMONS.CFiles.BinaryDeserializeForLib(this.openFileDialog1.FileName);
                   if (ds != null)
                   {
                       this.ds = ds;
                       BindSource();
                   }
                   else
                   {
                       MsgBox.Alert("请选择正确的图集库文件！");
                   }
               }
               catch (Exception)
               {


                   MsgBox.Alert("请选择正确的图集库文件！");
               }
            

           }
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
            else { this.Close(); }
        }

        private void treeListEx2_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName == "ZFMC")
                e.RepositoryItem = this.repositoryItemMemoExEdit1;
        }
    }
}
