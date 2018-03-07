/*
 清单库控件
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.CTRL.Forms;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class ListGallery : BaseControl
    {
        /// <summary>
        /// 当前应用程序目录
        /// </summary>
        public DirectoryInfo Folder = null;



        /// <summary>
        /// 清单数据集合
        /// </summary>
        public DataTable DataSource = null;

        private _UnitProject m_CUnitProject = null;
        /// <summary>
        /// 默认的清单库文件名称
        /// </summary>
        public _UnitProject Default
        {
            set
            {
                m_CUnitProject = value;
                this.Loads();
            }
        }
        private bool m_Ischange = true;

        public bool IsChange
        {
            get { return m_Ischange; }
            set { m_Ischange = value; }
        }
        public ListGallery()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            //打开当前清单库
            Loads();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Loads();
        }
        public void Loads()
        {
            if (this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet != null)
            {
                this.buttonEdit1.Text = this.m_CUnitProject.Property.Libraries.ListGallery.FullName;
                //this.bindingSource1.DataSource = _LibAction.GetAllListGallery(this.m_CUnitProject.CurrentListGallery);

                //打开操作的清单库
                this.bindingSource1.DataSource = this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单索引表"].Copy();
                this.treeList1.DataSource = this.bindingSource1;
                this.treeList1.KeyFieldName = "QINGDSYBH";
                this.treeList1.ParentFieldName = "PARENTID";
                //打开查询清单库
                DataTable table = this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"].Copy();
                table.Columns.Add("DISPLAY", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    row.BeginEdit();
                    row["DISPLAY"] = string.Format("【{0}】 {1} 【{2}】", row["QINGDBH"], row["QINGDMC"],row["QINGDDW"]);
                    row.EndEdit();
                }
                //为table添加显示列
               
                this.bindingSource2.DataSource = table;
                this.bindingSource2.Sort = "QINGDBH asc";
                this.listBoxControl1.DataSource = this.bindingSource2.DataSource;
                this.treeList1.Expand(1);
                if (!this.m_Ischange)
                {
                    this.buttonEdit1.Properties.Buttons[0].Visible = false;
                    this.buttonEdit1.Width = this.textEdit1.Width;
                    simpleButton2.Visible = false;
                }
            }
        }

        /// <summary>
        /// 打开清单库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            _LibsForm form = new _LibsForm();
            //设置当前默认规则
            form.Library = this.m_CUnitProject.Property.Libraries.ListGallery;
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                Loads();
                this.m_CUnitProject.Property.Libraries.OnLibraryChange(form.Library);
            }
        }

        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            //if (!e.Node.HasChildren && e.Node.Tag == null)
            //{

            //    DataTable table = this.m_CUnitProject.Libraries.ListGallery.LibraryDataSet.Tables["清单表"].Copy();

            //    DataRow[] dr = table.Select(" QINGDSYBH= '" + e.Node.GetValue("QINGDSYBH") + "'");
            //    for (int i = 0; i < dr.Length; i++)
            //    {
            //        TreeListNode chilNode = treeList1.AppendNode(null, e.Node.Id);
            //        chilNode.Tag = dr[i];
            //        chilNode.SetValue(this.treeListColumn1, "" + string.Format("【{0}】 {1}", dr[i]["QINGDBH"], dr[i]["QINGDMC"]));
            //    }

            //}
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            //查询框输入后自动查询
            TextEdit text = sender as TextEdit;
            if (text.Text.Trim() == string.Empty)
            {
                this.bindingSource2.Filter = string.Empty;
                this.xtraTabControl1.SelectedTabPageIndex = 0;

            }
            else
            {

                try
                {
                    this.bindingSource2.Filter = string.Format("QINGDBH like '%{0}%' or QINGDMC like '%{0}%'", text.Text.Trim());
                }
                catch (Exception e1)
                {

                    throw e1;
                }
                
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //只要此文本框输入则切换至查询结果窗体中
            this.xtraTabControl1.SelectedTabPageIndex = 1;
            //如果按下则list成为选择焦点
            if (e.KeyCode == Keys.Down)
            {
                this.listBoxControl1.Focus();
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {

            if (this.treeList1.Selection[0] != null)
            {
                //如果选中且没有儿子
                //if (!this.treeList1.Selection[0].HasChildren)
                {
                    //获取选中的ID
                    string str = this.treeList1.Selection[0].GetValue("QINGDSYBH").ToString();
                    this.bindingSource2.Filter = string.Format("QINGDSYBH like '%{0}%'", str);
                }
            }
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList t = sender as TreeList;
            TreeListHitInfo n = t.CalcHitInfo(e.Location);
            if (n.Node!=null)
            {
                if (n.Node.HasChildren)
                {
                    n.Node.Expanded = !n.Node.Expanded;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.m_CUnitProject.Property.Libraries.ListGallery = this.m_CUnitProject.Property.DLibraries.ListGallery.Copy();
            this.m_CUnitProject.Property.Libraries.ListGallery.Init(APP.Application.Global.AppFolder);
            //还原默认库
            this.Loads();
            this.m_CUnitProject.Property.Libraries.OnLibraryChange(this.m_CUnitProject.Property.Libraries.ListGallery);
        }

    }
}
