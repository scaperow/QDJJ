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
using System.IO;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class NewProjectWizardForm : CBaseForm
    {

        /// <summary>
        /// 获取选择的项目
        /// </summary>
        public DataRowView GetSelectItem
        {
            get
            {
                if (this.imageListBoxControl1.SelectedItem != null)
                {
                    return (this.imageListBoxControl1.SelectedItem as DataRowView);
                }
                return null;
            }
        }


        public NewProjectWizardForm()
        {
            InitializeComponent();
        }

     
        private void WizardForm_Load(object sender, EventArgs e)
        {
            //窗体加载时候处理
            LoadData();
        }

        /// <summary>
        /// 加载窗体数据时调用
        /// </summary>
        private void LoadData()
        {
            this.comboBoxEdit1.Text = APP.Application.Global.AppFolder + "工程文件";
            LoadTreeData();
            LoadImageListData();

        }

        /// <summary>
        /// 加载所有功能模块数据
        /// </summary>
        private void LoadImageListData()
        {
            this.imageListBoxControl1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Features"]; 
        }


        /// <summary>
        /// 加载树形控件
        /// </summary>
        private void LoadTreeData()
        {
            this.treeList1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Wizard"];   
        }

        private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageListBoxControl ilist = (sender as ImageListBoxControl);
            if (ilist.SelectedItem != null)
            {
                DataRowView view = ilist.SelectedItem as DataRowView;
                this.textEdit1.Text = view["Remark"].ToString();
            //    if (view["CmdName"].ToString() == "5" || view["CmdName"].ToString() == "4")
            //    {
            //        this.textEdit2.Visible = false;
            //        this.buttonEdit1.Visible = true;
            //    }
            //    else
            //    {
            //        this.textEdit2.Visible = true;
            //        this.buttonEdit1.Visible = false;
            //    }
            }
            else
            {
                this.textEdit1.Text = string.Empty;
            }
            
        }

        /// <summary>
        /// 浏览按钮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.comboBoxEdit1.Text = this.folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        /// 提交当前页面数据
        /// </summary>
        public void Commit()
        {   
            //设置工作目录
            _Files files = new _Files();
            APP.Application.Global.WorkFolder = new System.IO.DirectoryInfo(this.comboBoxEdit1.Text.Trim());
            /*switch (APP.BObjects.BObjectType)
            {
                case EBObjectType.PROJECT://创建项目的时候调用
                            //APP.General.CurrentProjectsFiles.DirectoryName = this.textEdit2.Text.Trim();
                            //APP.General.CurrentProjectsFiles.WorkFolder = APP.Application.Global.WorkFolder;
                        files.ExtName  = _Files.ProjectExName;
                        files.DirName  = this.comboBoxEdit1.Text.Trim();
                        files.FileName = textEdit2.Text.Trim();
                        //设置文件属性
                        APP.General.CurrentProject.Files = files;
                     break;
            }*/
        }

        private bool Verification(_Files files)
        {
            FileInfo file = new FileInfo(files.FullName);
            if (file.Exists)
            {
                MessageBox.Show(this, _Prompt.文件已经存在, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    this.folderBrowserDialog1.ShowDialog();
        //    this.buttonEdit1.Text = this.folderBrowserDialog1.SelectedPath;
        //}
    }
}