using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.CTRL.Forms;
/*
 材机库
 */
namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class WoodMachineLibrary : BaseControl
    {
     
        /// <summary>
        /// 当前应用程序目录
        /// </summary>
        public DirectoryInfo Folder = null;

        private _UnitProject m_CUnitProject = null;
        /// <summary>
        /// 默认的单位工程
        /// </summary>
        public _UnitProject Default
        {
            set
            {

               // this.buttonEdit1.Text = value.Property.Libraries.FixedLibrary.FullName;
                m_CUnitProject = value;
                this.Loads();
            }
        }

        public WoodMachineLibrary()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public void Loads()
        {
            if (this.m_CUnitProject == null) return;
            if (this.m_CUnitProject.Property.Libraries.ListGallery.LibraryDataSet != null)
            {
                //this.bindingSource1.DataSource = _LibAction.GetAllListGallery(this.m_CUnitProject.CurrentListGallery);
                //this.buttonEdit1.Text = this.m_CUnitProject.Property.Libraries.FixedLibrary.FullName;
                //打开操作的材机库
                this.bindingSource1.DataSource = this.m_CUnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机索引表"].Copy();
                this.treeList1.DataSource = this.bindingSource1.DataSource;
                DataTable table = this.m_CUnitProject.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"].Copy();
                this.bindingSource2.DataSource = table;
                this.listBoxControl2.DataSource = this.bindingSource2;
                this.treeList1.Expand(2);
            }
        }
        private void btn_open_Click(object sender, EventArgs e)
        {
            //打开当前定额库
            Loads();
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            //根据选择的目录筛选子目

            if (this.treeList1.Selection[0] != null)
            {
                //如果选中且没有儿子
                if (!this.treeList1.Selection[0].HasChildren)
                {
                    //获取选中的ID
                    string str = this.treeList1.Selection[0].GetValue("CAIJSYBH").ToString();
                    this.bindingSource2.Filter = string.Format("CAIJSYBH = '{0}'", str);
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
                this.bindingSource2.Filter = string.Format("CAIJBH like '%{0}%' or CAIJMC like '%{0}%'", text.Text.Trim());
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
            }
        }

    }
}
