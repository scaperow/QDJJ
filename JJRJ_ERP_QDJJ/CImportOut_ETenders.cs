/*
 电子标书的保存逻辑
 保存为电子标书的逻辑擦操作
 */
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
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CImportOut_ETenders : CBaseForm
    {
        /// <summary>
        /// 初始化导出类型
        /// </summary>
        private string m_OutType = string.Empty;

        /// <summary>
        /// TBS,ZBS,BD 之一
        /// </summary>
        public string OutType
        {
            get
            {
                return this.m_OutType;
            }
            set
            {
                this.m_OutType = value;
            }
        }

        /// <summary>
        ///  要操作的单位工程数据源
        /// </summary>
        private _COBJECTS m_DataSource = null;

        /// <summary>
        /// 获取或设置的单位工程数据源
        /// </summary>
        public _COBJECTS DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                //根据类型选择数据接口
                if (value != null)
                {
                    switch (value.ObjectType)
                    {
                        case EObjectType.PROJECT:
                                this.DataInterface = new CPActionData(this.CurrentBusiness);
                                break;
                        case EObjectType.UnitProject:
                                this.DataInterface = new CUActionData(this.CurrentBusiness);
                                break;
                        default:

                                break;
                    }
                }
                this.m_DataSource = value; 
            }
        }

        /// <summary>
        /// 如何处理数据操作
        /// </summary>
        private IDataInterface DataInterface = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_CUnitProject"></param>
        public CImportOut_ETenders()
        {
            InitializeComponent();
            
        }


        private void CImportOut_Load(object sender, EventArgs e)
        {
            //初始化窗体
            initForm();
        }

        private void initForm()
        {
            
            //根据要到处的对象名称写标题
            if (this.m_DataSource.ObjectType == EObjectType.UnitProject)
            {
                this.Text = "单位工程导出";
            }
            if (this.m_DataSource.ObjectType == EObjectType.PROJECT)
            {
                this.Text = "项目导出";
            }

            //默认文件名称为项目名称
            this.textEdit1.Text   = this.m_DataSource.Name;
            this.buttonEdit1.Text = APP.Application.Global.AppFolder.FullName + "工程文件\\";
 
            //魔人文件路径为应用程序路径
            this.ctrlAttributes1.IDataSource = this.m_DataSource.Reveal.Attributes;
            this.ctrlAttributes1.DataBind();
            //重新设置为电子标书类型
            

        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //点击按钮选择目录
            DialogResult r = this.folderBrowserDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                this.buttonEdit1.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string yp = this.CurrentBusiness.Current.PassWord;
            if (OutType == "JZBX")
            {
                CPwdForm form = new CPwdForm();
                form.CurrentBusiness = this.CurrentBusiness;
                form.Source = this.CurrentBusiness.Current;
                form.isJZBX = true;
                DialogResult result =  form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //全部当做SaveAs处理

                    _Files file = new _Files();
                    //目录名称
                    file.DirName = this.buttonEdit1.Text.Trim();
                    file.ExtName = _Files.Proj_DZBS;
                    file.FileName = this.textEdit1.Text.Trim();

                    if (this.DataSource.ObjectType == EObjectType.PROJECT)
                    {

                        //开始到处逻辑业务
                        FileInfo info = new FileInfo(file.FullName);
          
                        this.DataInterface.SaveAsDZBS(info);
                        if (OutType == "JZBX")
                        {
                            this.CurrentBusiness.Current.PassWord = yp;
                        }
                        //(this.CurrentBusiness as _Pr_Business).SaveAsDZBS(info);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

     
        /// <summary>
        /// 项目导出(仅电子标书)
        /// </summary>
        private void ImportForProject(_Files p_file)
        {
            //当前目录
            string path = this.buttonEdit1.Text.Trim();
            
            //_Export e = new _Export(this.DataSource);
            /*switch (this.radioProject.SelectedIndex)
            {
                case 0://导出项目文件 另存为项目
                    Import(p_file);
                    this.DialogResult = DialogResult.OK;
                    break;
                case 1://TBS
                    //e.ExportTBS(path);
                    this.DataInterface.SaveXml(path, "TBS");
                    this.DialogResult = DialogResult.OK;
                    break;
                case 2://ZBS
                    //e.ExportZBS(path);
                    this.DataInterface.SaveXml(path, "ZBS");
                    this.DialogResult = DialogResult.OK;
                    break;
                case 3://BD
                    //e.ExportBD(path);
                    this.DataInterface.SaveXml(path, "BD");
                    this.DialogResult = DialogResult.OK;
                    break;
                default:

                    break;
            }*/
        }


        


        #region------------------------------保存线程处理---------------------------
        private void bWorker_SaveAs_DoWork(object sender, DoWorkEventArgs e)
        {
            CResult result = e.Argument as CResult;
            FileInfo info = result.Data as FileInfo;
            result = this.m_DataSource.DataInterFace.SaveAs(info);
            e.Result = result;
        }

        private void bWorker_SaveAs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bWorker_SaveAs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CResult result = e.Result as CResult;
            if (result.Success)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}