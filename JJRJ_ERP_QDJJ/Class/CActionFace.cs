/*
    用于处理界面操作集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace GOLDSOFT.QDJJ.UI
{
    public class CActionFace
    {
        /// <summary>
        /// 父窗体对象
        /// </summary>
        public RibbonForm MdiParent = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent"></param>
        public CActionFace(RibbonForm parent)
        {
            this.MdiParent = parent;
        }



        /// <summary>
        /// 打开引导页面
        /// </summary>
        public void ShowWizards()
        {
            WizardsForm form = new WizardsForm(this.MdiParent);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                //确定引导函数获取引导页面属性配置 根据配置信息转入相对应的操作环节
                this.ShowNewAction(form.Profession);
            }
        }

        /// <summary>
        /// 打开对应的业务类型（方法）
        /// </summary>
        /// <param name="pro"></param>
        public void ShowNewAction(_Profession pro)
        {
            switch (pro.CommandName.Trim())
            {
                case "1": //项目工程操作
                    APP.FileType = "项目工程";
                    this.NewProjects(pro);
                    break;
                case "2"://单项工程操作
                    //this.NewEngineering(pro);
                    break;
                case "3"://单位工程
                    this.NewUnitProject(pro);
                    break;
                case "4"://XML数据导入
                case "5":
                    ShowOpenAction();
                    //this.NewProjectsByXML();
                    break;
                case "6"://打开文件对话框
                    ShowOpenAction();
                    break;
            }
        }
        string XmlFilePath = string.Empty;
        /// <summary>
        /// 打开文件（通用处理函数）
        /// </summary>
        public void ShowOpenAction()
        {
            NewProjeByXml form = new NewProjeByXml();
            form.Master = this.MdiParent;
            DialogResult result = form.ShowDialog();
            //处理XML业务
            if (result == DialogResult.OK)
            {
                FileInfo info = new FileInfo(form.buttonEdit1.Text);
                CActionData.Load(info, this.MdiParent as ApplicationForm);
            }
            //处理普通Objects业务
            if (result == DialogResult.Yes)
            {   //
                this.OpenNewBussinessForm(form.CurrentBusiness);
            }
        }

        public void OpenTBBS()
        {
            OpenTBBS form = new OpenTBBS();
            form.Master = this.MdiParent;
            DialogResult result = form.ShowDialog();
            //处理XML业务
            if (result == DialogResult.OK)
            {
                //FileInfo info = new FileInfo(form.buttonEdit1.Text);
                //CActionData.Load(info, this.MdiParent as ApplicationForm);
                DataTable table = this.GetTable(form.buttonEdit1.Text);
                if (table == null)
                    return;
                //APP.GoldSoftClient.TB_RESULT = table.Copy();
                this.getTBResult(table);
            }
            //处理普通Objects业务
            if (result == DialogResult.Yes)
            {   //
                //this.OpenNewBussinessForm(form.CurrentBusiness);
            }
        }
        private DataTable GetTable(string fileName)
        {
            if (!File.Exists(fileName))
            {
                MsgBox.Alert("TBX文件不存在！");
                return null;
            }
            else
            {
                //int index = fileName.LastIndexOf("\\");
                try
                {
                    File.Copy(fileName, fileName.Substring(0, fileName.LastIndexOf('.')) + ".xls", true);
                }
                catch (Exception)
                {
                    MsgBox.Alert("文件或被占用,请重试！");
                    return null;
                }
            }
            FileInfo file = new FileInfo(fileName);
            fileName = fileName.Substring(0, fileName.LastIndexOf('.')) + ".xls";
            string extension = ".xls";

            string strConn = "";
            switch (extension)
            {
                case ".xls":
                //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + "; Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                //break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            DataTable table = new DataTable();
            OleDbConnection oleConn = new OleDbConnection(strConn);
            try
            {
                oleConn.Open();
                //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等
                DataTable dtSheetName = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string strSql = "SELECT * FROM [" + dtSheetName.Rows[0]["TABLE_NAME"] + "]";
                OleDbCommand oleCom = new OleDbCommand(strSql, oleConn);
                using (OleDbDataReader rdr = oleCom.ExecuteReader())
                {
                    table.Load(rdr);
                }
            }
            catch (Exception)
            {
                MsgBox.Alert("文件被占用请重试");
                return null;
            }
            finally
            {
                if (oleConn.State == ConnectionState.Open)
                {
                    oleConn.Close();
                }
            }
            return table;
        }

        private void getTBResult(DataTable tb)
        {
            DataView dv = tb.DefaultView;
            dv.Sort = "合价金额 ASC";


            System.Data.DataTable temp = new System.Data.DataTable();
            temp.Columns.Add(new DataColumn("OLDXH"));
            temp.Columns.Add(new DataColumn("GCMC"));
            temp.Columns.Add(new DataColumn("GCID"));
            temp.Columns.Add(new DataColumn("GCBH"));
            temp.Columns.Add(new DataColumn("XMMC"));
            temp.Columns.Add(new DataColumn("DW"));
            temp.Columns.Add(new DataColumn("GCL"));
            temp.Columns.Add(new DataColumn("ZHDJ"));
            temp.Columns.Add(new DataColumn("ZHHJ"));

            for (int i = 9; i < dv.Table.Columns.Count; i++)
            {
                if(!APP.GoldSoftClient.Invite_Publish)
                    temp.Columns.Add(new DataColumn("第 " + (i - 9 + 2).ToString() + " 家"));
                else
                    temp.Columns.Add(new DataColumn("第 " + (i - 9 + 1).ToString() + " 家"));
            }

            DataRow newRow;
            for (int i = 0; i < dv.Count; i++)
            {
                newRow = temp.NewRow();

                newRow[0] = dv[i]["清单序号"];
                newRow[1] = dv[i]["工程名称"];
                newRow[2] = dv[i]["工程ID"];
                newRow[3] = dv[i]["工程编号"];
                newRow[4] = dv[i]["项目名称"];
                newRow[5] = dv[i]["计量单位"];
                newRow[6] = dv[i]["工程数量"];
                newRow[7] = dv[i]["单价金额"];
                newRow[8] = dv[i]["合价金额"];

                for (int n = 9; n < dv.Table.Columns.Count; n++)
                {

                    newRow[n] = dv[i][n];
                }

                temp.Rows.Add(newRow);
            }

            APP.GoldSoftClient.TB_RESULT = temp;
        }

        public void ImportTBData(DataTable tbData, string columnNam)
        {

        }


        #region -------------------------界面操作实现方法(新建类)------------------------



        /// <summary>
        /// 创建新的项目向导(直接处理项目操作)
        /// </summary>
        private void NewProjects(_Profession pro)
        {
            ///初始化项目工作流(返回工作流对象)    
            NewProjectsInfo form = new NewProjectsInfo();
            form.Profession = pro;
            DialogResult result = form.ShowDialog(this.MdiParent);
            if (result == DialogResult.OK)
            {
                //新项目操作界面
                this.OpenNewBussinessForm(form.CurrentBusiness);
            }
        }

        /// <summary>
        /// 创建新的单位工程向导（非集合容器业务直接创建）
        /// </summary>
        /// <param name="pro"></param>
        private void NewUnitProject(_Profession pro)
        {
            //单位工程的创建不限类别操作

            NewUnitProjectForm f = new NewUnitProjectForm();
            f.IsContainer = false;
            f.Profession = pro;
            DialogResult result = f.ShowDialog(this.MdiParent);
            if (result == DialogResult.OK)
            {
                this.OpenNewBussinessForm(f.CurrentBusiness);
            }
        }

        /// <summary>
        /// 开启一个新的业务操作窗口(可能是项目或者是单项工程)
        /// </summary>
        /// <param name="p_bus"></param>
        public void OpenNewBussinessForm(_Business p_bus)
        {
            switch (p_bus.WorkFlowType)
            {
                case EWorkFlowType.PROJECT://开启项目业务
                    this.openProjects(p_bus, false);
                    break;
                case EWorkFlowType.UnitProject://开启新的单位工程业务
                    this.openUnitProjects(p_bus);
                    break;
            }
        }

        /// <summary>
        /// 开启一个新的业务操作窗口(可能是项目或者是单项工程)
        /// </summary>
        /// <param name="p_bus"></param>
        public void OpenNewBussinessForm(_Business p_bus, bool ISTBS)
        {
            switch (p_bus.WorkFlowType)
            {
                case EWorkFlowType.PROJECT://开启项目业务
                    this.openProjects(p_bus, ISTBS);
                    break;
                case EWorkFlowType.UnitProject://开启新的单位工程业务
                    this.openUnitProjects(p_bus);
                    break;
            }

        }

        /// <summary>
        /// 开启一个业务操作(项目管理)
        /// </summary>
        private void openProjects(_Business p_bus, bool ISTBS)
        {
            //项目窗体创建
            CWellComeProject form = new CWellComeProject();
            form.ModelChange += new ModelChangeHandler(form_ModelChange);
            //业务对象
            form.CurrentBusiness = p_bus;
            //指定项目对象
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            //设置为非顶级控件
            form.TopLevel = false;
            //显示窗体
            form.Visible = true;
            //超创建项目
            form.MdiParent = MdiParent;
            if (ISTBS)
            {
                // DialogResult d= MsgBox.Show("导入成功，是否计算所有项目？", MessageBoxButtons.OKCancel);
                // if(d==DialogResult.OK)
                BackgroundWorker ProjWorker = new BackgroundWorker();
                ProjWorker.WorkerReportsProgress = true;
                ProjWorker.DoWork += new DoWorkEventHandler(ProjWorker_DoWork);
                ProjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProjWorker_RunWorkerCompleted);
                ProjWorker.RunWorkerAsync(p_bus);
                ProgressFrom p = new ProgressFrom(ProjWorker);
                p.ShowDialog();
                //(p_bus as _Pr_Business).CalculateForXml();
            }
        }

        void ProjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                (e.Argument as _Pr_Business).CalculateForXml();
                // throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 当模块发生变化时候激发
        /// </summary>
        void form_ModelChange(object sendr, object args)
        {

        }

        /// <summary>
        /// 开启一个新业务操作(单位工程)
        /// </summary>
        /// <param name="p_bus"></param>
        private void openUnitProjects(_Business p_bus)
        {
            //项目窗体创建
            ProjectForm form = new ProjectForm();
            form.ModelChange += new ModelChangeHandler(form_ModelChange);
            //业务对象
            form.CurrentBusiness = p_bus;
            //指定项目对象
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            //设置为非顶级控件
            form.TopLevel = false;
            //显示窗体
            form.Visible = true;
            //超创建项目
            form.MdiParent = MdiParent;
        }




        #endregion

        #region -------------------------界面操作实现方法(常规操作类)------------------------

        #endregion
    }
}
