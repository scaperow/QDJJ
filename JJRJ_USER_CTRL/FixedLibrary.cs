/*
 定额库控件
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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using GOLDSOFT.QDJJ.CTRL.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class FixedLibrary : BaseControl
    {

        /// <summary>
        /// 当前应用程序目录
        /// </summary>
        public DirectoryInfo Folder = null;

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

        private bool m_Ischange=true;

        public bool IsChange
        {
            get { return m_Ischange; }
            set { m_Ischange = value; }
        }
        public FixedLibrary()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            //打开当前定额库
            Loads();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Loads();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void Loads()
        {
            if (this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet != null)
            {
                //this.bindingSource1.DataSource = _LibAction.GetAllListGallery(this.m_CUnitProject.CurrentListGallery);
                this.buttonEdit1.Text = this.m_CUnitProject.Property.Libraries.FixedLibrary.FullName;
                //打开操作的清单库
                this.bindingSource1.DataSource = this.m_CUnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额索引表"].Copy();
                this.bindingSource1.Sort = "DINGESYBH asc";
                this.treeList1.DataSource = this.bindingSource1.DataSource;

                DataTable table = this.m_CUnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy();
                table.Columns.Add("DISPLAY", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    row.BeginEdit();
                    row["DISPLAY"] = string.Format("【{0}】{1}【{2}】", row["DINGEH"], row["DINGEMC"], row["DINGEDW"]);
                    row.EndEdit();
                }
                table.DefaultView.Sort = " TX2 asc";
               
                this.bindingSource2.DataSource = table.DefaultView;
                this.listBoxControl2.DataSource = this.bindingSource2;
                this.treeList1.Expand(1);
                if (!this.m_Ischange)
                {
                    this.buttonEdit1.Properties.Buttons[0].Visible = false;
                    simpleButton2.Visible = false;
                }

            }
            
        }
        //private int GetNum(DataRow r)
        //{
        //    string d = r["DINGEH"].ToString();
        //    int m = d.IndexOf('-') > 0 ? d.IndexOf('-') : d.Length;
        //    return m;
        //}
        //private int GetNum1(DataRow r)
        //{
        //    string d = r["DINGEH"].ToString();
        //    int m = d.IndexOf('-') > 0 ? d.IndexOf('-') + 1 : 0;
        //    return m;
        //}
 
        private void treeList1_Click(object sender, EventArgs e)
        {
            //根据选择的目录筛选子目

            if (this.treeList1.Selection[0] != null)
            {
                //如果选中且没有儿子
                if (!this.treeList1.Selection[0].HasChildren)
                {
                    //获取选中的ID
                    string str = this.treeList1.Selection[0].GetValue("DINGESYBH").ToString();
                    this.bindingSource2.Filter = string.Format("DINGESYBH = '{0}'", str);
                }
                else
                {
                    if (this.treeList1.Selection[0].Level > 0)
                    {
                        string str = this.treeList1.Selection[0].GetValue("DINGESYBH").ToString();
                        DataTable dt = this.m_CUnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额索引表"];
                        DataRow[] rows = dt.Select(string.Format("PARENTID='{0}'", str));
                        string filter = string.Empty;
                        for (int i = 0; i < rows.Length; i++)
                        {
                            filter += "'" + rows[i]["DINGESYBH"] + "',";
                        }
                        if (filter != string.Empty)
                        {
                            filter = filter.TrimEnd(",".ToCharArray());
                            filter = "(" + filter + ")";
                            this.bindingSource2.Filter = string.Format("DINGESYBH in {0}", filter);
                        }
                    }
                    else
                    {
                        this.bindingSource2.Filter = string.Empty; 
                    }
                }
            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            //文本改变筛选
            TextEdit text = sender as TextEdit;
            if (text.Text.Trim() == string.Empty)
            {
                this.bindingSource2.Filter = string.Empty;
            }
            else
            {
                try
                {
                    this.bindingSource2.Filter = string.Format("DINGEH like '%{0}%' or DINGEMC like '%{0}%'", text.Text.Trim());
                }
                catch (Exception e1)
                {
                    throw e1;
                }
            }
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList t = sender as TreeList;
            TreeListHitInfo n = t.CalcHitInfo(e.Location);
            if (n.Node != null)
            {
                if (n.Node.HasChildren)
                {
                    n.Node.Expanded = !n.Node.Expanded;
                }
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //点击打开定额库切换
            _LibsForm form = new _LibsForm();
            //设置当前默认规则
            form.Library = this.m_CUnitProject.Property.Libraries.FixedLibrary;
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                Loads();
                this.m_CUnitProject.Property.Libraries.OnLibraryChange(form.Library);
                _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting (this.m_CUnitProject);
                m_Methods_ParamsSeting.Init();
                DataRow[] m_MRGCQF = this.m_CUnitProject.StructSource.ModelUnitFee.Select("DEHFW=''");
                if (m_MRGCQF.Length > 0)
                {
                    this.m_CUnitProject.ProType = m_MRGCQF[0]["GCLB"].ToString();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.m_CUnitProject.Property.Libraries.FixedLibrary = this.m_CUnitProject.Property.DLibraries.FixedLibrary.Copy();
            this.m_CUnitProject.Property.Libraries.FixedLibrary.Init(APP.Application.Global.AppFolder);
            //还原默认库
            this.Loads();
            this.m_CUnitProject.Property.Libraries.OnLibraryChange(this.m_CUnitProject.Property.Libraries.FixedLibrary);
        }
    }
}
