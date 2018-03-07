/*
 用于处理截面数据动作具体对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.IO;
using ZiboSoft.Commons.Common;
using System.ComponentModel;
using GOLDSOFT.QDJJ.UI.BaseFroms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public class CActionData : IDataInterface
    {
        public static string GetNewFileName(string fileName)
        {
            string str = DateTime.Now.ToString("yyyyMMddhhmmss");
            return string.Format("{0}-{1}", str, fileName);
        }

        private _Business m_Current = null;

        public virtual _Business Current
        {
            get
            {
                return this.m_Current;
            }
            set
            {
                this.m_Current = value;
            }
        }

        public CActionData(_Business p_Business)
        {
            m_Current = p_Business;
        }


        #region IDataInterface 成员
        public virtual ZiboSoft.Commons.Common.CResult Save()
        {
            throw new NotImplementedException();
        }

        public virtual ZiboSoft.Commons.Common.CResult SaveAs(string p_Path)
        {
            throw new NotImplementedException();
        }

        public virtual ZiboSoft.Commons.Common.CResult SaveAs(System.IO.FileInfo p_File)
        {
            throw new NotImplementedException();
        }

        public virtual ZiboSoft.Commons.Common.CResult SaveAs(_Files p_Files)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 另存为xml文件
        /// </summary>
        /// <param name="p_path"></param>
        /// <param name="OutType"></param>
        /// <returns></returns>
        public virtual CResult SaveXml(string p_path, string OutType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 另存为电子标书
        /// </summary>
        /// <param name="p_File"></param>
        /// <returns></returns>
        public virtual CResult SaveAsDZBS(FileInfo p_File)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 导出指定的对象
        /// </summary>
        /// <param name="p_Files"></param>
        /// <param name="p_Object"></param>
        /// <returns></returns>
        public virtual CResult OutImport(System.IO.FileInfo p_Files, ArrayList p_Object) { return null; }

        /// <summary>
        /// 提供静态的文件转对象的方法
        /// </summary>
        /// <param name="p_Info"></param>
        public static CResult Load(FileInfo p_Info)
        {
            CResult result = LoadObjectByFile(p_Info);
            return result;
        }

        public static CResult Load(_Files p_Files)
        {
            FileInfo info = new FileInfo(p_Files.FullName);
            return CActionData.Load(info);
        }

        /// <summary>
        /// 当前业务窗体是否已经打开
        /// </summary>
        /// <param name="p_File"></param>
        /// <param name="p_from"></param>
        /// <returns></returns>
        private static string IsExitFileObject(FileInfo p_File, ApplicationForm p_from)
        {
             //找到所有的子窗体提调用保存
            Container f = null;
            foreach (Form from in p_from.MdiChildren)
            {
                f = from as Container;
                if (f != null)
                {
                    if (f.CurrentBusiness.Current.Files.FullName.Equals(p_File.FullName))
                    {
                        return f.CurrentBusiness.Current.Name;
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 为打开项目文件提供的静态方法
        /// </summary>
        /// <param name="p_Info"></param>
        public static CResult Load(FileInfo p_Info, ApplicationForm from)
        {
            CResult result = new CResult(false);
            //文件不存在直接返回
            if (!p_Info.Exists)
            {
                result.Success = false;
                result.ErrorInformation = "您要打开的文件对象不存在！";
                MsgBox.Alert(result.ErrorInformation);
                return result;
            }
            //存在相同路径的的业务则不打开
            string name = IsExitFileObject(p_Info, from);
            if (name != string.Empty)
            {
                result.Success = false;
                result.ErrorInformation = string.Format("项目-{0} 已经打开！",name);
                MsgBox.Alert(result.ErrorInformation);
                return result;
            }

            _Files files = new _Files();
            files.Init(p_Info.FullName);
            //如果当前业务流是锁定状态不允许创建任何新业务
          
                //创建新业务(要创建的类型根据文件判断)
                switch (files.FileType)
                {
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.单位工程:
                        //此处实现单位工程的打开逻辑
                        CActionData.openUnitProject(files, from);
                        break;
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.单项工程:
                        //此处实现单项工程打开逻辑
                        APP.Application.Global.WorkFolder = p_Info.Directory.Parent;
                        CActionData.openEngineering(files);
                        break;
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.项目文件:
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.电子标书:
                        //此处实现单项工程打开逻辑
                        APP.Application.Global.WorkFolder = p_Info.Directory.Parent;
                        CActionData.openProject(files, from);
                        break;
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.XML文件:
                        //此处实现xml打开逻辑
                        // APP.Application.Global.WorkFolder = new FileInfo(p_FileName).Directory.Parent;
                        CActionData.openProjectByxml(files, from);
                        break;

                }

                /* result.Data = EBObjectType.Auto;
                 result.Success = false;
                 return result;*/
                result.Success = true;
            
            return result;
        }

        #region -----------------------------私有方法------------------------------

        /// <summary>
        /// 打开项目的过程
        /// </summary>
        private static void openProject(_Files p_files, ApplicationForm from)
        {
            //初始化一个新的项目业务
            _Business bus = APP.WorkFlows.Init(EWorkFlowType.PROJECT);
            //打开一个业务文件
            //bus.Open(p_files);
            //打开业务操作窗体
            //from.ActionFace.OpenNewBussinessForm(bus);
           
            object param = new object[] { from, p_files, bus };
            BackgroundWorker ProjWorker = new BackgroundWorker();
            ProjWorker.WorkerReportsProgress = true;
            ProjWorker.DoWork += new DoWorkEventHandler(ProjWorker_DoWork);
            ProjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProjWorker_RunWorkerCompleted);
            ProjWorker.RunWorkerAsync(param);
            ProgressFrom form = new ProgressFrom(ProjWorker);
            form.ShowDialog();
        }

        /// <summary>
        /// 打开单位工程的操作
        /// </summary>
        /// <param name="p_files"></param>
        /// <returns></returns>
        private static void openUnitProject(_Files p_files, ApplicationForm from)
        {
            _Business bus = APP.WorkFlows.Init(EWorkFlowType.UnitProject);
            object param = new object[] { from, p_files, bus };
            BackgroundWorker UnitWorker = new BackgroundWorker();
            UnitWorker.WorkerReportsProgress = true;
            UnitWorker.DoWork += new DoWorkEventHandler(UnitWorker_DoWork);
            UnitWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(UnitWorker_RunWorkerCompleted);
            UnitWorker.RunWorkerAsync(param);
            ProgressFrom form = new ProgressFrom(UnitWorker);
            form.ShowDialog();
        }

        static void UnitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] result = e.Result as object[];
            if (result == null) return;
           ApplicationForm form = result[0] as ApplicationForm;
           _COBJECTS unit = result[1] as _COBJECTS;
           _Business bus = result[2] as _Business;
           bus.Load(unit);

           //效验函数
           if (form.Validation(bus))
           {
               //this.DialogResult = DialogResult.Cancel;
               APP.Cache.HistoryCache.Add(new FileInfo(bus.Current.Files.FullName));
               APP.Cache.HistoryCache.Save();
               //开启业务窗体
               form.ActionFace.OpenNewBussinessForm(bus);
           }
        }

        /// <summary>
        /// 单位工程处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void UnitWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

            BackgroundWorker ProjWorker = sender as BackgroundWorker;
            object[] param = e.Argument as object[];
            ApplicationForm form = param[0] as ApplicationForm;
            _Files file = param[1] as _Files;
            _Business bus = param[2] as _Business;

            using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                //stream.Position = 0;
                GZipStream zip = new GZipStream(stream, CompressionMode.Decompress, true);
                {
                    //zip.Seek(0, SeekOrigin.Begin);
                    BinaryFormatter formater = new BinaryFormatter();
                    _FileHeader header = (_FileHeader)formater.Deserialize(zip);
                    _StructSource ds = (_StructSource)formater.Deserialize(zip);
                    //创建新的单位工程（单位工程业务体）
                    _UnitProject unit = new _UnitProject();
                    unit.Files = file;
                    unit.Ready(ds);
                    //初始化新的临时对象（不参与序列化此对象每次使用需要呗初始化）
                    /*obj.Property.Temporary = new _Temporary();
                    //默认同步临时库对象
                    obj.Property.Temporary.Libraries = obj.Property.DLibraries.Copy();
                    obj.Property.Temporary.Libraries.Init(APP.Application);
                    obj.Application = APP.Application;*/
                    e.Result = new object[] { form, unit, bus };
                }
                zip.Close();


            }
            }
            catch (Exception)
            {

                MsgBox.Show(_Prompt.无法识别的打开文件, MessageBoxButtons.OK);
            }
        }


        #region ------------------项目打开初始化----------------------
        static void ProjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] result = e.Result as object[];
            if (result == null) return;
            ApplicationForm form = result[0] as ApplicationForm;
            _Business bus = result[1] as _Business;
            //效验函数
            //if (form.Validation(bus))
            //{
                //this.DialogResult = DialogResult.Cancel;
                APP.Cache.HistoryCache.Add(new FileInfo(bus.Current.Files.FullName));
                APP.Cache.HistoryCache.Save();
                //开启业务窗体
                form.ActionFace.OpenNewBussinessForm(bus);
           // }
            
        }


        /// <summary>
        /// 打开项目具体操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void ProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _Files file = null;
            try
            {

                BackgroundWorker ProjWorker = sender as BackgroundWorker;
                object[] param = e.Argument as object[];
                ApplicationForm form = param[0] as ApplicationForm;
                file = param[1] as _Files;
                _Business bus = param[2] as _Business;
                //打开一个业务文件
                bus.Open(file);
                //打开业务操作窗体
                e.Result = new object[] { form, bus };
            }
            catch (Exception ex)
            {

                MsgBox.Show(_Prompt.无法识别的打开文件, MessageBoxButtons.OK);
            }
            finally
            {
                if (file != null)
                    file = null;
            }
           /*BackgroundWorker ProjWorker = sender as BackgroundWorker;
           object[] param = e.Argument as object[];
           ApplicationForm form = param[0] as ApplicationForm;
           _Files file = param[1] as _Files;
           _Business bus = param[2] as _Business;
           _Projects proj = null;
           _Engineering en = null;
           using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
           {
               GZipStream zip = new GZipStream(stream, CompressionMode.Decompress, true);
               {
                   BinaryFormatter formater = new BinaryFormatter();
                   long lenth = stream.Length;
                   int percent = 0;
                   while (stream.Position != lenth)
                   {

                       object obj = formater.Deserialize(zip);
                       //zip.Close();
                       if (obj is _Projects)
                       {
                           proj = obj as _Projects;
                           proj.InSerializable(file);
                           ProjWorker.ReportProgress(++percent, proj);
                       }
                       if (proj != null)
                       {
                           if (obj is _Engineering)
                           {
                               en = obj as _Engineering;
                               en.InSerializable(proj);
                               ProjWorker.ReportProgress(++percent, en);
                           }
                           if (obj is _UnitProject)
                           {
                               _UnitProject un = obj as _UnitProject;
                               un.InSerializable(en);
                               ProjWorker.ReportProgress(++percent, un);
                           }
                       }
                   }
               }

           }

           e.Result = new object[] { form, proj, bus };*/
        }
        #endregion



        /// <summary>
        ///  打开单项工程数据对象（此模块暂时取消）
        /// </summary>
        /// <param name="p_files"></param>
        /// <returns></returns>
        private static CResult openEngineering(_Files p_files)
        {
            /*APP.WorkFlows.Init(EWorkFlowType.Engineering);
            CResult result = this.Load(p_files);
            if (result.Success)
            {
                result.Data = EBObjectType.Engineering;
                APP.WorkFlows.Container.Load(result.Value as CEngineering);
            }
            return result;*/
            return null;
        }


        /// <summary>
        /// 为XML准的临时对象
        /// </summary>
        static object[] XmlObject = null;

        /// <summary>
        /// 通过xml创建项目
        /// </summary>
        /// <param name="p_files"></param>
        /// <returns></returns>
        private static CResult openProjectByxml(_Files p_files, ApplicationForm from)
        {
            CResult result = new CResult();
            //初始化一个新的项目业务
            _Business bus = APP.WorkFlows.Init(EWorkFlowType.PROJECT);
            //读取业务文件
            //CResult result = bus.LoadByXml(p_files);

            //准备工作
            XmlProjWorker projWorker = new XmlProjWorker(bus);
            projWorker.FileName = p_files.FullName;
            projWorker.form = from;
            projWorker.Load();
            projWorker.Begin();

            /*_ImportXML xml = new _ImportXML(bus);
            xml.RevertXmlObject += new RevertXmlObject(xml_RevertXmlObject);
            xml.FileName = p_files.FullName;
            BackgroundWorker XmlProjWorker = new BackgroundWorker();
            XmlProjProgressAction form = new XmlProjProgressAction(XmlProjWorker);
            XmlProjWorker.WorkerReportsProgress = true;
            XmlProjWorker.DoWork += new DoWorkEventHandler(XmlProjWorker_DoWork);
            XmlProjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(XmlProjWorker_RunWorkerCompleted);

            XmlObject = new object[2] { XmlProjWorker ,1};
            object param = new object[] { from, p_files, bus, xml, form };
            XmlProjWorker.RunWorkerAsync(param);
            
            form.ShowDialog();*/
            return result;
        }

        static void XmlProjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] result = e.Result as object[];
            ApplicationForm form = result[0] as ApplicationForm;
            _Files file = result[1] as _Files;
            _Business bus = result[2] as _Business;
            FileInfo FileName = new FileInfo(file.FileName);
            //处理文件名
            string NewExists = _Files.ProjectExName;
            string p_filename = FileName.FullName.Replace(FileName.Extension, NewExists);
            file.init(p_filename);
            bus.Current.Files = file;
            //效验函数
            if (form.Validation(bus))
            {
                //this.DialogResult = DialogResult.Cancel;
                //开启业务窗体
                GC.Collect();
                form.ActionFace.OpenNewBussinessForm(bus);
            }

        }

        static void XmlProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker XmlProjWorker = sender as BackgroundWorker;
            object[] param = e.Argument as object[];
            ApplicationForm form = param[0] as ApplicationForm;
            _Files file = param[1] as _Files;
            _Business bus = param[2] as _Business;
            _ImportXML xml = param[3] as _ImportXML;
            XmlProjProgressAction pf = param[4] as XmlProjProgressAction;
            xml.Load();
            object p = new object[] { true, xml.Count };
            XmlProjWorker.ReportProgress(0, p);
            bus.Current = xml.Import();
            e.Result = new object[] { form, file, bus };
        }


        static void xml_RevertXmlObject(object sender, object args)
        {
            _COBJECTS info = args as _COBJECTS;
            BackgroundWorker XmlProjWorker = XmlObject[0] as BackgroundWorker;
            int percent = Convert.ToInt16(XmlObject[1]);
            object param = new object[] { false, info };
            XmlProjWorker.ReportProgress(percent, param);
            XmlObject[1] = ++percent;
        }

        #endregion

        #endregion



        /// <summary>
        /// 用于还原一个数据对象
        /// </summary>
        /// <param name="p_files"></param>
        /// <returns></returns>
        private static CResult LoadObjectByFile(FileInfo p_fileInfo)
        {
            CResult result = new CResult(false);
            object param = new object[] { p_fileInfo, result };
            BackgroundWorker ObjWorker = new BackgroundWorker();
            ObjWorker.WorkerReportsProgress = true;
            ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
            ObjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ObjWorker_RunWorkerCompleted);
            ObjWorker.RunWorkerAsync(param);
            ProgressFrom form = new ProgressFrom(ObjWorker);
            form.ShowDialog();
            return result;
        }

        static void ObjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        static void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker ProjWorker = sender as BackgroundWorker;
            object[] param = e.Argument as object[];
            FileInfo file = param[0] as FileInfo;
            CResult cresult = param[1] as CResult;
            using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                GZipStream zip = new GZipStream(stream, CompressionMode.Decompress);
                {
                    
                    BinaryFormatter formater = new BinaryFormatter();
                    _FileHeader header = (_FileHeader)formater.Deserialize(zip);
                    _StructSource ds = (_StructSource)formater.Deserialize(zip);
                    //创建新的单位工程（单位工程业务体）
                    _UnitProject unit = new _UnitProject();
                    unit.Ready(ds);
                    /*obj.InSerializable(file);

                    //初始化新的临时对象（不参与序列化此对象每次使用需要呗初始化）
                    obj.Property.Temporary = new _Temporary();
                    //默认同步临时库对象
                    obj.Property.Temporary.Libraries = obj.Property.DLibraries.Copy();
                    obj.Property.Temporary.Libraries.Init(APP.Application);*/
                    cresult.Value = unit;
                    cresult.Success = true;
                    e.Result = new object[] { file, cresult };
                }
                zip.Close();
            }
        }

    }
}
