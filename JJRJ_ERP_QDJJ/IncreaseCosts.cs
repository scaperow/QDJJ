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
using GOLDSOFT.QDJJ.BUSINESS;
/*********安装增加费界面**********/
namespace GOLDSOFT.QDJJ.UI
{
    public partial class IncreaseCosts : BaseForm
    {

        public SubSegmentForm SubSegmentForm;
        public IncreaseCosts()
        {
            InitializeComponent();
        }

        private void IncreaseCosts_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            if (this.Activitie.Property.IncreaseCosts.DataSource == null) return;
            if (this.Activitie.Property.IncreaseCosts.DataSource.Rows.Count < 1) return;
           
            this.bindingSource1.DataSource = this.Activitie.Property.IncreaseCosts.DataSource;
            this.treeList1.DataSource = this.bindingSource1;
            this.bindingSource1.Sort = "ID asc";
            this.treeList1.ExpandAll();
            initsubmea();
        }

        private void initsubmea()
        {
            IEnumerable<DataRow> sinfo = from info in this.Activitie.StructSource.ModelSubSegments.AsEnumerable()
                                         where info.RowState != DataRowState.Deleted && !info["LB"].Equals("分部-章") && !info["LB"].Equals("分部-专业") && !info["LB"].Equals("分部-节") && !info["LB"].ToString().Contains("子目")
                                             select info;
            IEnumerable<DataRow> minfo = from info in this.Activitie.StructSource.ModelMeasures.AsEnumerable()
                                         where info.RowState!=DataRowState.Deleted&&!info["LB"].ToString().Contains("子目")
                                             select info;
            this.treeList2.DataSource = sinfo.CopyToDataTable();
            this.treeList3.DataSource = minfo.CopyToDataTable();
            this.treeList3.KeyFieldName = "ID";
            this.treeList3.ParentFieldName = "PID";
            this.treeList2.KeyFieldName = "ID";
            this.treeList2.ParentFieldName = "FPARENTID";
        }
        public void RefreshSubSegment()
        {
            SubSegmentForm.subSegmentListData1.DataBind();
        }
        /// <summary>
        /// 关联到项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _Method_IncreaseCosts met = new _Method_IncreaseCosts(this.Activitie, this.Activitie.Property.IncreaseCosts.DataSource);
            met.Build(this.CurrentBusiness);
            this.RefreshSubSegment();
            Activitie.NeedCalculate = true;
            MsgBox.Show("关联成功！", MessageBoxButtons.OK);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 另存增加费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// 载入增加费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Loads();
        }
        private void Save()
        {
            DialogResult dl = this.saveFileDialog1.ShowDialog();
            if (dl == DialogResult.OK)
            {
                this.Activitie.Property.IncreaseCosts.Save(this.saveFileDialog1.FileName);
                //object o = this.Activitie.IncreaseCosts.DataSource;
            }
        }
        private void Loads()
        {
            DialogResult dl = this.openFileDialog1.ShowDialog();
            if (dl == DialogResult.OK)
            {
                this.Activitie.Property.IncreaseCosts.Load(this.openFileDialog1.FileName);
                this.bindingSource1.DataSource = this.Activitie.Property.IncreaseCosts.DataSource;
                // this.bindingSource1.ResetBindings(false);
            }
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            if (tree.FocusedNode == null) return;
            if (tree.FocusedColumn == null) return;
            switch (tree.FocusedColumn.FieldName)
            {
                case "Check":
                    if (tree.FocusedNode.HasChildren)
                    {
                        this.treeList1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        this.treeList1.OptionsBehavior.Editable = true;
                    }
                    break;
                case "location":
                    if (tree.FocusedNode.ParentNode!=null)
                    {
                        this.treeList1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        this.treeList1.OptionsBehavior.Editable = true;
                    }
                    break;
                default:
                    this.treeList1.OptionsBehavior.Editable = true;
                    break;
            }
        }

        private void treeList1_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            treeList1_FocusedNodeChanged(this.treeList1, null);
        }

        private void treeList2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList gv = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.XtraTreeList.TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
            if (hi.Node != null)
            {
                object o = gv.GetDataRecordByNode(hi.Node);
                DataRowView info = o as DataRowView;
                string str = string.Empty;
                if (info["LB"].Equals("清单"))
                {
                    str = info["XMMC"].ToString();
                }
                else
                {
                    if (info["SSLB"].Equals(0))
                        str = "分部分项";
                }
                if (str!=string.Empty)
                {
                     DataRowView view = this.bindingSource1.Current as DataRowView;
                     if (view != null)
                     {
                         view.BeginEdit();
                         view["location"] = str;
                         view.EndEdit();
                         this.treeList1.HideEditor();
                     }
                }
            }
        }

        private void treeList1_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {

            switch (e.Column.FieldName)
            {
                case "location":
                    e.RepositoryItem = this.repositoryItemPopupContainerEdit1;
                    break;
                case "Fixed":
                    e.RepositoryItem = this.repositoryItemMemoExEdit1;
                    break;
                default:
                    break;
            }

           
        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
           
        }

        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            var editor = sender as DevExpress.XtraEditors.CheckEdit;

            if (editor.Checked)
            {
                var parentID = this.treeList1.FocusedNode.GetValue("ParentID");
                var ID = this.treeList1.FocusedNode.GetValue("ID");
                var rows = this.Activitie.Property.IncreaseCosts.DataSource.Select(string.Format("ParentID = {0} AND Check = true", parentID));
                foreach (DataRow item in rows)
                {
                    item.BeginEdit();
                    item["Check"] = false;
                    item.EndEdit();
                }

                this.repositoryItemCheckEdit1.CheckedChanged -= new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
                editor.Checked = true;
                this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            }
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList gv = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.XtraTreeList.TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (this.Activitie == null) return;
                if (this.bindingSource1.Count>0)
                {
                   // this.popupMenu1.ShowPopup(Control.MousePosition);
                }
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Caption)
            {
                case "新增项目":
                    this.Add();
                    break;
                case "新增子项":
                    this.Add_Child();
                    break;
                case "删除所选":
                    this.Delete();
                    break;
                case "另存增加费文件":
                    this.Save();
                    break;
                case "载入增加费文件":
                    this.Loads();
                    break;
                default:
                    break;
            }
        }
        public void Add()
        {
            DataView dv = this.bindingSource1.List as DataView;
            DataRowView row = dv.AddNew();
            row.BeginEdit();
            row["ID"] = this.Activitie.Property.IncreaseCosts.GetID();
            row["Check"] = false;
            row["ParentID"] = 0;
            row.EndEdit();
        }
        public DataRow Add_Child()
        {
            DataRowView drv = this.bindingSource1.Current as DataRowView;
            if (drv != null)
            {
                DataView dv = this.bindingSource1.List as DataView;
                DataRowView row = dv.AddNew();
                row.BeginEdit();
                row["ID"] = this.Activitie.Property.IncreaseCosts.GetID();
                row["ParentID"] = drv["ID"];
                row["Check"] = false;
                row.EndEdit();
                return row.Row;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <summary>
        /// 删除当前选择项目
        /// </summary>
        public void Delete()
        {
            //删除当前选择项下的所有项目

            DataRowView drv = this.bindingSource1.Current as DataRowView;
            if (drv != null)
            {
                string id = drv["ID"].ToString();
                this.doDelete(drv.Row);
               // this.Activitie.Property.IncreaseCosts.DataSource.AcceptChanges();
            }
        }

        private void doDelete(DataRow row)
        {
            //查找是否拥有子项
            DataRow[] rows = row.Table.Select(string.Format(" ParentID ={0}", row["ID"]));
            if (rows.Length == 0)
            {
                row.Delete();
            }
            else
            {
                foreach (DataRow r in rows)
                {
                    this.doDelete(r);
                }
                row.Delete();

            }
        }

        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {

            if (e.Column.FieldName=="Check")
            {
                //DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo ck = e.EditViewInfo as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
                //ck.State = DevExpress.Utils.Drawing.ObjectState.Disabled;
            }
        }
        
    }
}
