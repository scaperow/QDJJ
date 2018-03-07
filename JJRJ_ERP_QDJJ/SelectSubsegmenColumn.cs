/*
 变更列隐藏显示方法
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraGrid.Columns;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.Data;
using GOLDSOFT.QDJJ.CTRL;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class SelectSubsegmenColumn : BaseForm
    {

        /// <summary>
        /// 当前树的列字段配置
        /// </summary>
        private _ColumnLayout m_ColumnLayout = null;

        /// <summary>
        /// 当前树的列字段配置
        /// </summary>
        public _ColumnLayout ColumnLayout
        {
            get
            {
                return this.m_ColumnLayout;
            }
            set
            {
                this.m_ColumnLayout = value;
                
            }
        }

        /// <summary>
        /// 获取要控制的控件(TreeList 或者 GridView)
        /// </summary>
        private object m_Control = null;

        /// <summary>
        /// 获取要控制的控件(TreeList 或者 GridView)
        /// </summary>
        public object Control
        {
            get
            {
                return this.m_Control;
            }
            set
            {
                this.m_Control = value;
                
            }
        }

        /// <summary>
        /// 隐藏显示列
        /// </summary>
        public SelectSubsegmenColumn()
        {
            InitializeComponent();
        }

        private void SelectSubsegmenColumn_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private int Count = 0;
        private string TypeName = string.Empty;
        private void DataBind()
        {
            //修改为Grid控制

            //this.checkedListBoxControl1.DataSource = APP.DataObjects.Columns.Columns;

            if (this.m_Control != null)
            {
                TreeList tl = this.m_Control as TreeList;
                GridView gv = this.m_Control as GridView;
                BandedGridViewEx bgv = this.m_Control as BandedGridViewEx;
                if (tl != null)
                {
                    this.gridControl1.DataSource = tl.Columns;
                    Count = tl.Columns.Count;
                    TypeName = "TreeList";
                    /*foreach (TreeListColumn col in tl.Columns)
                    {
                        CheckedListBoxItem item = new CheckedListBoxItem();
                        if (col.Visible)
                        {
                            item.CheckState = CheckState.Checked;
                        }
                        item.Description = col.Caption;
                        item.Value = col;
                        this.checkedListBoxControl1.Items.Add(item);
                    }*/
                }

                if (gv != null)
                {
                    this.gridControl1.DataSource = gv.Columns;
                    Count = gv.Columns.Count;
                    TypeName = "GridView";
                    /*foreach (GridColumn col in gv.Columns)
                    {
                        CheckedListBoxItem item = new CheckedListBoxItem();
                        if (col.Visible)
                        {
                            item.CheckState = CheckState.Checked;
                        }
                        item.Description = col.Caption;
                        item.Value = col;
                        this.checkedListBoxControl1.Items.Add(item);
                    }*/
                }
                if (bgv != null)
                {
                    this.gridControl1.DataSource = bgv.Columns;
                    Count = bgv.Columns.Count;
                    TypeName = "BandedGridView";
                    /*foreach (GridColumn col in gv.Columns)
                    {
                        CheckedListBoxItem item = new CheckedListBoxItem();
                        if (col.Visible)
                        {
                            item.CheckState = CheckState.Checked;
                        }
                        item.Description = col.Caption;
                        item.Value = col;
                        this.checkedListBoxControl1.Items.Add(item);
                    }*/

                    //如果是双表头模式 不允许设置显示隐藏列 和锁顶列
                    this.GvEdit.Columns["UnBFixed"].Visible = this.GvEdit.Columns["Visible"].Visible = false;
                }
            }

        }



        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(this.checkedListBoxControl1.SelectedItem != null)
            {
                CheckedListBoxItem item = (this.checkedListBoxControl1.SelectedItem as CheckedListBoxItem);
                TreeListColumn col = item.Value as TreeListColumn;
                GridColumn col1 = item.Value as GridColumn;
                if (col != null)
                {
                    this.textEdit1.Text = col.Caption;
                    switch (col.Fixed)
                    {
                        case DevExpress.XtraTreeList.Columns.FixedStyle.Left:
                            this.radioGroup1.SelectedIndex = 1;
                            break;
                        case DevExpress.XtraTreeList.Columns.FixedStyle.Right:
                            this.radioGroup1.SelectedIndex = 2;
                            break;
                        default:
                            this.radioGroup1.SelectedIndex = 0;
                            break;

                    }                    
                }
                if (col1 != null)
                {
                    this.textEdit1.Text = col1.Caption;
                    switch (col1.Fixed)
                    {
                        case DevExpress.XtraGrid.Columns.FixedStyle.Left:
                            this.radioGroup1.SelectedIndex = 1;
                            break;
                        case DevExpress.XtraGrid.Columns.FixedStyle.Right:
                            this.radioGroup1.SelectedIndex = 2;
                            break;
                        default:
                            this.radioGroup1.SelectedIndex = 0;
                            break;

                    }
                }
            }*/
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //清空APP
            /*APP.DataObjects.Columns.Columns.Clear();
            //checkedlist的项还原给APP
            foreach (CheckedListBoxItem item in this.checkedListBoxControl1.Items)
            {
                APP.DataObjects.Columns.Columns.Add(item.Value);
            }
            */
            
            //关闭窗体刷新上一个节点
            //保存配置

            TreeListEx tl = this.m_Control as TreeListEx;
            GridViewEx gv = this.m_Control as GridViewEx;
            BandedGridViewEx bgv = this.m_Control as BandedGridViewEx;
            if (tl != null) this.SaveColorTreeEx(tl);
            if (gv != null) this.SaveColorGridEx(gv);
            if (bgv != null) this.SaveColorGridEx(bgv);
            
            APP.DataObjects.Save();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 保存树Ex列颜色方案
        /// </summary>
        /// <param name="p_Tree"></param>
        private void SaveColorTreeEx(TreeListEx p_Tree)
        {
            //若不存在
            if (APP.DataObjects.GColor.ColumnColor == null)
            {
                APP.DataObjects.GColor.ColumnColor = new _ColumnColor();
            }
            //初始化模块(不存在则新增)
            APP.DataObjects.GColor.ColumnColor.Init(p_Tree.ModelName);

            //若是第一次使用列配色
            //APP.DataObjects.GColor.ColumnColor.Set(p_Tree.ModelName,);
            foreach (TreeListColumn col in p_Tree.Columns)
            {
                _CellStyle stype = new _CellStyle();
                stype.BColor = col.AppearanceCell.BackColor;
                //保存颜色
                APP.DataObjects.GColor.ColumnColor[p_Tree.ModelName].Set(col.FieldName, stype);
            }

            p_Tree.ColumnColor = APP.DataObjects.GColor.ColumnColor;
            p_Tree.Refresh();
        }

        /// <summary>
        /// 保存表格列Ex颜色方案
        /// </summary>
        /// <param name="p_GridEx"></param>
        private void SaveColorGridEx(GridViewEx p_Grid)
        {
            //若不存在
            if (APP.DataObjects.GColor.ColumnColor == null)
            {
                APP.DataObjects.GColor.ColumnColor = new _ColumnColor();
            }
            //初始化模块(不存在则新增)
            APP.DataObjects.GColor.ColumnColor.Init(p_Grid.ModelName);

            //若是第一次使用列配色
            //APP.DataObjects.GColor.ColumnColor.Set(p_Tree.ModelName,);
            foreach (GridColumn col in p_Grid.Columns)
            {
                _CellStyle stype = new _CellStyle();
                stype.BColor = col.AppearanceCell.BackColor;
                //保存颜色
                APP.DataObjects.GColor.ColumnColor[p_Grid.ModelName].Set(col.FieldName, stype);
            }
        }

        /// <summary>
        /// 保存表格列Ex颜色方案
        /// </summary>
        /// <param name="p_GridEx"></param>
        private void SaveColorGridEx(BandedGridViewEx p_Grid)
        {
            //若不存在
            if (APP.DataObjects.GColor.ColumnColor == null)
            {
                APP.DataObjects.GColor.ColumnColor = new _ColumnColor();
            }
            //初始化模块(不存在则新增)
            APP.DataObjects.GColor.ColumnColor.Init(p_Grid.ModelName);

            //若是第一次使用列配色
            //APP.DataObjects.GColor.ColumnColor.Set(p_Tree.ModelName,);
            foreach (BandedGridColumn col in p_Grid.Columns)
            {
                _CellStyle stype = new _CellStyle();
                stype.BColor = col.AppearanceCell.BackColor;
                //保存颜色
                APP.DataObjects.GColor.ColumnColor[p_Grid.ModelName].Set(col.FieldName, stype);
            }
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
           /* CheckedListBoxItem item = (this.checkedListBoxControl1.SelectedItem as CheckedListBoxItem);
            TreeListColumn col = item.Value as TreeListColumn;
            GridColumn col1 = item.Value as GridColumn;
            if (col != null)
            {
                if (e.State == CheckState.Checked)
                {

                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }
            if (col1 != null)
            {
                if (e.State == CheckState.Checked)
                {
                    col1.Visible = true;
                }
                else
                {
                    col1.Visible = false;
                }
            }*/
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //改变的时候
            /*CheckedListBoxItem item = this.checkedListBoxControl1.SelectedItem as CheckedListBoxItem;             
            if (item != null)
            {
                TreeListColumn col = item.Value as TreeListColumn;
                GridColumn col1 = item.Value as GridColumn;
                if (col != null)
                {

                    switch (this.radioGroup1.SelectedIndex)
                    {
                        case 1:
                            col.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                            break;
                        case 2:
                            col.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Right;
                            break;
                        default:
                            col.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.None;
                            break;

                    }
                }
                if (col1 != null)
                {
                    switch (this.radioGroup1.SelectedIndex)
                    {
                        case 1:
                            col1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                            break;
                        case 2:
                            col1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
                            break;
                        default:
                            col1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                            break;

                    }
                }
            }*/
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            GridView gv = sender as GridView;
            if (e.Column.FieldName == "Fixed")
            {
                //e.DisplayText = (e.Value.Equals(1) ? true : false).ToString();

                //gv.SetRowCellValue(e.RowHandle, e.Column, (e.Value.Equals(1) ? true : false));
            }
        }

        private void repositoryItemCheckEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView gv = sender as GridView;
            if (e.Column.FieldName == "UnBFixed")
            {
                TreeListColumn col = gv.GetRow(e.RowHandle) as TreeListColumn;
                if (col != null)
                {
                    e.Value = (col.Fixed == DevExpress.XtraTreeList.Columns.FixedStyle.Left ? true : false);
                    return;
                }
                GridColumn gcol = gv.GetRow(e.RowHandle) as GridColumn;
                if(gcol != null)
                {
                    e.Value = (gcol.Fixed == DevExpress.XtraGrid.Columns.FixedStyle.Left ? true : false);
                    return;
                }
            }
            
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //时间改变
            //1.自己之上的全部设置为true
            SetFixedColumns(this.GvEdit.FocusedRowHandle);
        }


        private void SetFixedColumns(int RowHandle)
        {
            //循环所有列知道当前调教
            if (this.TypeName == "GridView")
            {
                SetFixedGColumn(RowHandle);
            }
            else if (this.TypeName == "TreeList")
            {
                SetFixedTColumn(RowHandle);
            }
            else
            {
                SetFixedBColumn(RowHandle);
            }

            this.GvEdit.RefreshData();
        }

        private void SetFixedTColumn(int RowHandle)
        {
            
            TreeListColumn info  = null;
            info = this.GvEdit.GetRow(RowHandle) as TreeListColumn;
            if (info.Visible)
            {
                info.Fixed = info.Fixed == DevExpress.XtraTreeList.Columns.FixedStyle.None ? DevExpress.XtraTreeList.Columns.FixedStyle.Left : DevExpress.XtraTreeList.Columns.FixedStyle.None;
            }
            else
            {
                info.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.None;
            }
            for (int i = 0; i < this.Count; i++)
            {
                info = this.GvEdit.GetRow(i) as TreeListColumn;

                if (info != null)
                {
                    if (i < RowHandle)
                    {

                        if (info.Visible)
                        {
                            info.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                        }
                        else
                        {
                            info.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.None;
                        }
                    }
                    else if (i == RowHandle)
                    {
                        continue;
                    }else
                    {
                        info.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.None;
                    }
                }
            }
            
        }

        private void SetFixedGColumn(int RowHandle)
        {

            GridColumn info = null;
            
            info = this.GvEdit.GetRow(0) as GridColumn;
            info.Fixed = info.Fixed == DevExpress.XtraGrid.Columns.FixedStyle.None ? DevExpress.XtraGrid.Columns.FixedStyle.Left : DevExpress.XtraGrid.Columns.FixedStyle.None;
            
            for (int i = 0; i < this.Count; i++)
            {
                info = this.GvEdit.GetRow(i) as GridColumn;

                if (info != null)
                {
                    if (i <= RowHandle && RowHandle > 0)
                    {

                        if (info.Visible)
                        {
                            info.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        }
                        else
                        {
                            info.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                        }
                    } 
                    else if (i == RowHandle)
                    {
                        continue;
                    }else
                    
                    {
                        info.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                    }
                }
            }
        }

        private void SetFixedBColumn(int RowHandle)
        {

            GridColumn info = null;

            info = this.GvEdit.GetRow(0) as GridColumn;
            info.Fixed = info.Fixed == DevExpress.XtraGrid.Columns.FixedStyle.None ? DevExpress.XtraGrid.Columns.FixedStyle.Left : DevExpress.XtraGrid.Columns.FixedStyle.None;

            for (int i = 0; i < this.Count; i++)
            {
                info = this.GvEdit.GetRow(i) as GridColumn;

                if (info != null)
                {
                    if (i <= RowHandle && RowHandle > 0)
                    {

                        if (info.Visible)
                        {
                            info.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        }
                        else
                        {
                            info.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                        }
                    }
                    else if (i == RowHandle)
                    {
                        continue;
                    }
                    else
                    {
                        info.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                    }
                }
            }
        }

        /// <summary>
        /// 显示不显示更换时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemCheckEdit2_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chk = sender as CheckEdit;
           
            TreeListColumn col = this.GvEdit.GetRow(this.GvEdit.FocusedRowHandle) as TreeListColumn;
            if (col != null)
            {
                col.Visible = chk.Checked;
                if (col.Visible) col.VisibleIndex = this.GvEdit.FocusedRowHandle;
                return;
            }
            GridColumn gcol = this.GvEdit.GetRow(this.GvEdit.FocusedRowHandle) as GridColumn;
            if (gcol != null)
            {
                col.Visible = chk.Checked;
                if (col.Visible) col.VisibleIndex = this.GvEdit.FocusedRowHandle;
                return;
            }
            
            this.GvEdit.UpdateCurrentRow();
        }
    }
}