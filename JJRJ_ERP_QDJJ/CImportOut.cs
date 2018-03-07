using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.IO;
using ZiboSoft.Commons.Common;
using System.Collections;
using GOLDSOFT.QDJJ.CTRL;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CImportOut : CBaseForm
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
        /// 导出方式 项目导出 单位工程导出 单项工程导出 其他 默认为项目
        /// </summary>
        private string m_PutType = "项目";

        /// <summary>
        /// 是否另存为的方式(此方式若为true则变更当前操作项目)
        /// </summary>
        public bool IsSaveAs = false;

        /// <summary>
        /// 获取或设置当前导出的数据状态
        /// </summary>
        public string PutType
        {
            get
            {

                return this.m_PutType;
            }
            set
            {
                this.m_PutType = value;
            }
        }

        

        /// <summary>
        ///  要操作的单位工程数据源
        /// </summary>
        private ArrayList m_DataSource = null;

        /// <summary>
        /// 获取或设置的单位工程数据源
        /// </summary>
        public ArrayList DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
                this.txt_Sum.Text = string.Format("共{0}个项目",value.Count);
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
        public CImportOut()
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
            if (!this.IsSaveAs)
            {
                this.textEdit1.Enabled = false;
            }

            switch (this.PutType)
            {
               
                case "单位工程":
                    this.DataInterface = new CUActionData(this.CurrentBusiness);
                    break;
                default://默认为项目导出
                    this.DataInterface = new CPActionData(this.CurrentBusiness);
                    break;
                
            }

            //默认文件名称为项目名称
            this.textEdit1.Text   = (this.m_DataSource[0] as _COBJECTS).Name;

            this.buttonEdit1.Text = APP.Application.Global.AppFolder.FullName + "工程文件\\";


            
 
            //魔人文件路径为应用程序路径
            //this.ctrlAttributes1.IDataSource = (this.m_DataSource[0] as _COBJECTS).Reveal.Attributes;
            //this.ctrlAttributes1.DataBind();

            this.ctrlAttributes1.Invoke(new Action<IAttributes>(this.ctrlAttributes1.DataBind), (this.m_DataSource[0] as _COBJECTS).Reveal.Attributes);

            //MethodInfo method = typeof(CtrlAttributes).GetMethod("DataBind", new Type[] { typeof(IAttributes) });
            //method.Invoke(this.ctrlAttributes1, new object[] { (this.m_DataSource[0] as _COBJECTS).Reveal.Attributes });

            
            //根据对象类型判断如何选择
            switch (this.PutType)
            {
                case "单项工程"://单项工程
                case "单位工程":
                    this.radioOther.Visible = true;
                    this.radioProject.Visible = false;
                    break;
                default://默认为项目
                    this.radioOther.Visible = false;
                    this.radioProject.Visible = true;
                    break;
            }
            //根据导出类型初始化选择
            switch (this.m_OutType)
            {
                case "TBS":
                    this.radioProject.SelectedIndex = 1;
                    this.radioProject.Enabled = false;
                    break;
                case "ZBS":
                    this.radioProject.SelectedIndex = 2;
                    this.radioProject.Enabled = false;
                    break;
                case "BD" :
                    this.radioProject.SelectedIndex = 3;
                    this.radioProject.Enabled = false;
                    break;
                default:
                    this.radioProject.SelectedIndex = 0;
                    break;
            }

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
            //判断当前路径文件是否存在
            _Files file = new _Files();
            //目录名称
            file.DirName = this.buttonEdit1.Text.Trim();
            //扩展名称
            file.FileName = this.textEdit1.Text.Trim();


            //全部当做SaveAs处理
            //保存前计算
            //this.CurrentBusiness.Calculate();

            

            if (this.PutType == "项目")
            {
                ImportForProject(file);
            }
            else
            {
                ImportForOther(file);
            }
        }

        /// <summary>
        /// 项目导出
        /// </summary>
        private void ImportForProject(_Files p_file)
        {
            //当前目录
            string path = this.buttonEdit1.Text.Trim();
            //_Export e = new _Export(this.DataSource);
            switch (this.radioProject.SelectedIndex)
            {
                case 0://导出项目文件 另存为项目
                    Import(p_file);
                    
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
            }
        }

        /// <summary>
        /// 其他对象导出
        /// </summary>
        private void ImportForOther(_Files info)
        {
            switch (this.radioOther.SelectedIndex)
            {
                case 0://导出单位工程/单项工程 文件
                    Import(info);
                    break;
                case 1:

                    break;
                case 2:

                    break;
                default:

                    break;
            }
        }


        /// <summary>
        /// 导出单位工程文件
        /// </summary>
        private void Import(_Files file)
        {

            //判定对象类别（当前处理只能是单项工程或者单位工程）
            switch (this.PutType)
            {
                case "单项工程":
                    file.ExtName = _Files.EngineeringExName;
                    //配置数据操作接口
                    //this.m_DataSource.DataInterFace = CObjectProcess.CreateDataInterface(EBObjectType.Engineering);
                    break;
                case "单位工程":
                    file.ExtName = _Files.CUnitProjectExName;
                    //配置数据操作接口
                    //this.m_DataSource.DataInterFace = CObjectProcess.CreateDataInterface(EBObjectType.UnitProject);
                    break;
                case "项目":
                    file.ExtName = _Files.ProjectExName;
                    //项目数据操作接口
                    //this.m_DataSource.DataInterFace = CObjectProcess.CreateDataInterface(EBObjectType.PROJECT);
                    break;
            }

            FileInfo info = new FileInfo(file.FullName);
            CResult result = null;
            if (IsSaveAs)
            {
                result = this.DataInterface.SaveAs(new FileInfo(file.FullName));
            }
            else
            {
                result = this.DataInterface.OutImport(new FileInfo(file.FullName), DataSource);
            }
            if (!result.Success)
            {
                if (result.Tag != null)
                {
                    
                }
                else
                {
                    MsgBox.Alert(result.ErrorInformation);
                }
            }else
            {
                //如果成功 此处同步 当前操作项目
                if (IsSaveAs)
                {
                    this.CurrentBusiness.Current.Files = file;
                }

                this.DialogResult = DialogResult.OK;
            }
            //this.m_DataSource.DataInterFace.DataSource = this.DataSource;
           /* CResult result = new CResult(false);
            if (info.Exists)
            {
                DialogResult r = MessageBox.Show(_Prompt.文件存在覆盖, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {

                    result.Data = info;
                    this.bWorker_SaveAs.RunWorkerAsync(result);
                    ProgressFrom from = new ProgressFrom(this.bWorker_SaveAs);
                    from.ShowDialog();
                }
            }
            else
            {
                //导出当前对象文件
                result.Data = info;
                this.bWorker_SaveAs.RunWorkerAsync(result);
                ProgressFrom from = new ProgressFrom(this.bWorker_SaveAs);
                from.ShowDialog();
            }*/
            

        }

        /// <summary>
        /// 当前选中为0
        /// </summary>
        private int m_CurrSelected = 0;

        /// <summary>
        /// 下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click(object sender, EventArgs e)
        {
            if(m_CurrSelected < this.m_DataSource.Count-1)
            {
                m_CurrSelected++;
                //默认文件名称为项目名称
                this.textEdit1.Text = (this.m_DataSource[m_CurrSelected] as _COBJECTS).Name;
                //魔人文件路径为应用程序路径
                this.ctrlAttributes1.IDataSource = (this.m_DataSource[m_CurrSelected] as _COBJECTS).Reveal.Attributes;
                this.ctrlAttributes1.DataBind();
            }
        }

        /// <summary>
        /// 上一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Prve_Click(object sender, EventArgs e)
        {
            if (m_CurrSelected > 0)
            {
                m_CurrSelected--;
                //默认文件名称为项目名称
                this.textEdit1.Text = (this.m_DataSource[m_CurrSelected] as _COBJECTS).Name;
                //魔人文件路径为应用程序路径
                this.ctrlAttributes1.IDataSource = (this.m_DataSource[m_CurrSelected] as _COBJECTS).Reveal.Attributes;
                this.ctrlAttributes1.DataBind();
            }
        }


        //#region------------------------------保存线程处理---------------------------
        //private void bWorker_SaveAs_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    CResult result = e.Argument as CResult;
        //    FileInfo info = result.Data as FileInfo;
        //    result = this.m_DataSource.DataInterFace.SaveAs(info);
        //    e.Result = result;
        //}

        //private void bWorker_SaveAs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{

        //}

        //private void bWorker_SaveAs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    CResult result = e.Result as CResult;
        //    if (result.Success)
        //    {
        //        this.DialogResult = DialogResult.OK;
        //    }
        //}
        //#endregion
    }
}