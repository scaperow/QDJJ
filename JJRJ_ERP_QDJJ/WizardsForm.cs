/*
    新建文件操作处理页面
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
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using ZiboSoft.Commons.Common;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class WizardsForm : CBaseForm
    {
        /// <summary>
        /// 操作配置信息
        /// </summary>
        private _Profession m_Profession = null;

        /// <summary>
        /// 获取操作配置信息
        /// </summary>
        public _Profession Profession
        {
            get
            {
                return this.m_Profession;
            }
        }

        /// <summary>
        /// 获取当前弹出框的父类窗体
        /// </summary>
        private RibbonForm m_Master = null;

        /// <summary>
        /// 获取当前弹出框的父类窗体
        /// </summary>
        public RibbonForm Master
        {
            get
            {
                return this.m_Master;
            }
        }


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

        public WizardsForm(RibbonForm form)
        {
            this.m_Master = form;
            InitializeComponent();
        }

        private void WizardsForm_Load(object sender, EventArgs e)
        {
            //加载flash
            myflash.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\config\\yun.swf";
            myflash.Play();


            LoadData();
        }

        /// <summary>
        /// 加载窗体数据时调用
        /// </summary>
        private void LoadData()
        {
            
            this.buttonEdit1.Text = APP.Application.Global.AppFolder + "工程文件";
            LoadTreeData();
            LoadImageListData();
            LoadHistory();
        }

        /// <summary>
        /// 默认项目文件夹下的可用文件
        /// </summary>
        private void LoadHistory()
        {
            //工程文件
            DirectoryInfo info = ToolKit.GetDirectoryInfo(APP.Application.Global.AppFolder.FullName + "工程文件");
            FileInfo[] infos1 = info.GetFiles("*.JXMX");
            FileInfo[] infos2 = info.GetFiles("*.JGCX");
            FileInfo[] infos3 = info.GetFiles("*.JZBX");
            _HeaderFileInfo list = new _HeaderFileInfo();
            list.AddRange(infos1);
            list.AddRange(infos2);
            list.AddRange(infos3);
            //FileInfo[] file1 = info.GetFiles();
            
            this.bindingSource1.DataSource = list.HeaderArrayList;
            this.gridControl1.DataSource = this.bindingSource1;

            //备份
            DirectoryInfo binfo = ToolKit.GetDirectoryInfo(APP.Application.Global.AppFolder.FullName + "工程文件\\备份文件");
            FileInfo[] binfos1 = binfo.GetFiles("*.JXMX");
            FileInfo[] binfos2 = binfo.GetFiles("*.JGCX");
            FileInfo[] binfos3 = binfo.GetFiles("*.JZBX");

            _HeaderFileInfo blist = new _HeaderFileInfo();
           // ArrayList blist = new ArrayList();
            blist.AddRange(binfos1);
            blist.AddRange(binfos2);
            blist.AddRange(binfos3);
            //FileInfo[] file1 = info.GetFiles();
            this.bindingSource2.DataSource = blist.HeaderArrayList;
            this.gridControl2.DataSource = this.bindingSource2;
        }

        /// <summary>
        /// 加载所有功能模块数据
        /// </summary>
        private void LoadImageListData()
        {
            this.imageListBoxControl1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Features"];
            this.imageListBoxControl1.SelectedIndex = -1;
        }


        /// <summary>
        /// 加载树形控件
        /// </summary>
        private void LoadTreeData()
        {
            //this.treeList1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Wizard"];
        }

        private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageListBoxControl ilist = (sender as ImageListBoxControl);
            if (ilist.SelectedItem != null)
            {

                DataRowView view = ilist.SelectedItem as DataRowView;
                this.textEdit1.Text = view["Remark"].ToString();
                this.simpleButton1.Enabled = true;
            }
            else
            {
                this.textEdit1.Text = string.Empty;
                this.simpleButton1.Enabled = false;
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult r = this.folderBrowserDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                this.buttonEdit1.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }



        /// <summary>
        /// 确定创建新业务(新业务类型 此处仅告诉系统我门要做什么)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.GetSelectItem == null) return;

            string cName = this.GetSelectItem["CmdName"].ToString();
            //这里只创建Profession对象
            if (this.m_Profession == null)
            {
                this.m_Profession = new _Profession();
            }
            this.m_Profession.Files = new _Files();
            this.m_Profession.CommandName = cName;
            //设置工作目录
            APP.Application.Global.WorkFolder = new System.IO.DirectoryInfo(this.buttonEdit1.Text.Trim());
            switch (this.m_Profession.CommandName.Trim())
            {
                case "1"://创建项目的 Profession
                    //APP.Operation.Init(CAppType.PROJECT);
                    //准备加入的元素
                    //APP.BObjects = _BObjects.CreateInstance(EBObjectType.PROJECT);
                    //初始化工作
                    this.m_Profession.Files.ExtName = _Files.ProjectExName;
                    this.m_Profession.Files.DirName = this.buttonEdit1.Text.Trim();
                    this.m_Profession.Files.FileName = textEdit2.Text.Trim();
                    //设置文件属性
                    //APP.General.CurrentProject.Files = files;
                    break;
                case "2"://单项工程
                    //APP.BObjects = _BObjects.CreateInstance(EBObjectType.Engineering);
                    APP.WorkFlows.Init(EWorkFlowType.Engineering);
                    this.m_Profession.Files.ExtName = _Files.EngineeringExName;
                    this.m_Profession.Files.DirName = this.buttonEdit1.Text.Trim();
                    this.m_Profession.Files.FileName = textEdit2.Text.Trim();
                    break;
                case "3"://创建单位工程的Profession
                    //APP.Operation.Init(CAppType.UnitProject);
                    this.m_Profession.Files.ExtName = _Files.CUnitProjectExName;
                    this.m_Profession.Files.DirName = this.buttonEdit1.Text.Trim();
                    this.m_Profession.Files.FileName = textEdit2.Text.Trim();
                    break;
                case "4":
                case "5"://通过XML创建项目
                    APP.WorkFlows.Init(EWorkFlowType.PROJECT); ;
                    this.m_Profession.Files.ExtName = _Files.CUnitProjectExName;
                    this.m_Profession.Files.DirName = this.buttonEdit1.Text.Trim();
                    this.m_Profession.Files.FileName = textEdit2.Text.Trim();
                    break;
            }

            //文件名默认与项目名称同名 此处暂时取消验证
            /*if (this.m_Profession.Files.Verification())
            {
                //如果文件存在 提示
                MessageBox.Show(this, _Prompt.文件已经存在, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //同意提交
                this.DialogResult = DialogResult.OK;
            }*/

            this.DialogResult = DialogResult.OK;
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            this.imageListBoxControl1.SelectedIndex = -1;
            bindingSource1_CurrentChanged(this.bindingSource1, null);
        }

        //失去焦点图片选择区域失效
        private void imageListBoxControl1_Leave(object sender, EventArgs e)
        {
            
        }

        //失去焦点图片选择区域失效
        private void gridView1_LostFocus(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //双击打开对象
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                this.OpenSelect1();
            }
            else
            {
                this.OpenSelect2();
            }
        }


        /// <summary>
        /// 打开已经有的项目对象(此处修改为线程操作)
        /// </summary>
        private void OpenSelect1()
        {
            _HeaderInfo info = this.bindingSource1.Current as _HeaderInfo;
            if (info.HFileInfo != null)
            {
                if (info.HFileInfo.Exists)
                {
                    APP.FileType = "项目工程";
                    //打开指定单位工程逻辑
                    //CResult r = APP.WorkFlows.Operaty.Load(info);
                    this.DialogResult = DialogResult.Cancel;
                    CActionData.Load(info.HFileInfo, this.m_Master as ApplicationForm);
                }
            }
        }

        /// <summary>
        /// 打开已经有的项目对象(此处修改为线程操作)
        /// </summary>
        private void OpenSelect2()
        {
            _HeaderInfo info = this.bindingSource2.Current as _HeaderInfo;
            if (info.HFileInfo != null)
            {
                if (info.HFileInfo.Exists)
                {
                    APP.FileType = "项目工程";
                    //打开指定单位工程逻辑
                    //CResult r = APP.WorkFlows.Operaty.Load(info);
                    this.DialogResult = DialogResult.Cancel;
                    CActionData.Load(info.HFileInfo, this.m_Master as ApplicationForm);
                }
            }
        }


        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "HFileInfo.Extension")
            {
                e.DisplayText = _Files.GetFileRemark(e.Value.ToString());
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                string name = (this.bindingSource1.Current as _HeaderInfo).HFileInfo.Name;
                this.textEdit1.Text = string.Format("双击或者确定后直接打开选中工程: {0}",name);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //打开选中的
            //双击打开对象
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                this.OpenSelect1();
            }
            else
            {
                this.OpenSelect2();
            }
        }

        /// <summary>
        /// 创建新项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Create_Proj_Click(object sender, EventArgs e)
        {
               
            
            //这里只创建Profession对象
            if (this.m_Profession == null)
            {
                this.m_Profession = new _Profession();
            }
            this.m_Profession.Files = new _Files();
            this.m_Profession.CommandName = "1";
            //设置工作目录
            APP.Application.Global.WorkFolder = new System.IO.DirectoryInfo(this.buttonEdit1.Text.Trim());
            this.m_Profession.Files.ExtName = _Files.ProjectExName;
            this.m_Profession.Files.DirName = this.buttonEdit1.Text.Trim();
            this.m_Profession.Files.FileName = textEdit2.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 添加单位工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Create_Unit_Click(object sender, EventArgs e)
        {
            //这里只创建Profession对象
            if (this.m_Profession == null)
            {
                this.m_Profession = new _Profession();
            }
            this.m_Profession.Files = new _Files();
            this.m_Profession.CommandName = "3";
            //设置工作目录
            APP.Application.Global.WorkFolder = new System.IO.DirectoryInfo(this.buttonEdit1.Text.Trim());
            this.m_Profession.Files.ExtName = _Files.CUnitProjectExName;
            this.m_Profession.Files.DirName = this.buttonEdit1.Text.Trim();
            this.m_Profession.Files.FileName = textEdit2.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Open_Click(object sender, EventArgs e)
        {
            //这里只创建Profession对象
            if (this.m_Profession == null)
            {
                this.m_Profession = new _Profession();
            }
            this.m_Profession.Files = new _Files();
            this.m_Profession.CommandName = "6";
            //设置工作目录
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 电子标书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Open_dzbs_Click(object sender, EventArgs e)
        {
            DialogResult r =  this.openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                FileInfo info =  new FileInfo(this.openFileDialog1.FileName);
                if (info != null)
                {
                    if (info.Exists)
                    {
                        //打开指定单位工程逻辑
                        this.DialogResult = DialogResult.Cancel;
                        CActionData.Load(info, this.m_Master as ApplicationForm);
                    }
                }    
            }
        }

    }
}