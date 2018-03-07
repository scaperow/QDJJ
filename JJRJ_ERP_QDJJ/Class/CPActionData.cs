/*
 项目的数据操作类别
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using GOLDSOFT.QDJJ.UI.BaseFroms;
using System.Xml;
using System.Xml.Serialization;
using System.IO.Compression;
using System.Collections;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.UI
{
    public class CPActionData : CActionData, IDataInterface
    {
        public CPActionData(_Business p_info)
            : base(p_info)
        { }

        #region IDataInterface 成员
        public override CResult Save()
        {
            CResult result = new CResult(false);
            BackgroundWorker sWorker = new BackgroundWorker();
            sWorker.WorkerReportsProgress = false;
            sWorker.DoWork += new DoWorkEventHandler(sWorker_DoWork);
            sWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sWorker_RunWorkerCompleted);
            //object param = new object[] { result };
            sWorker.RunWorkerAsync(result);
            ProgressFrom form = new ProgressFrom(sWorker);
            form.ShowDialog();

            //如果开启了保存历史功能
            /*FileInfo file = new FileInfo(this.Current.Current.Files.FullName);
            CResult result = new CResult(false);
            this.Current.Save();
            result.Success = true;*/
            return result;

        }

        /// <summary>
        /// 保存完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileInfo file = new FileInfo(this.Current.Current.Files.FullName);
            if (file.Exists)
            {
                (this.Current as _Pr_Business).ReadyUseFile();
                //项目如果保存成功 改写文件头


                string path = GetNewFileName(file.Name);
                string dir = APP.Cache.AppFolder + "工程文件\\备份文件\\";
                DirectoryInfo info = ToolKit.GetDirectoryInfo(dir);
                path = APP.Cache.AppFolder + "工程文件\\备份文件\\" + path;
                File.Copy(file.FullName, path, true);
            }

        }


        /// <summary>
        /// 保存工作流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //如果开启了保存历史功能
            CResult result = e.Argument as CResult;
            FileInfo file = new FileInfo(this.Current.Current.Files.FullName);
            this.Current.Save();
            ///保存数据
            APP.GoldSoftClient.SaveProeject(this.Current.Current.Name);
            result.Success = true;
            e.Result = result;
        }

        public override CResult SaveAs(string p_Path)
        {
            FileInfo info = new FileInfo(p_Path);
            return this.SaveAs(info);
        }

        /// <summary>
        /// 另存为
        /// </summary>
        /// <param name="p_File"></param>
        /// <returns></returns>
        public override CResult SaveAs(System.IO.FileInfo p_File)
        {
            //释放文件资源准备工作
            (this.Current as _Pr_Business).ReadyUseFile();

            CResult result = new CResult();
            //保存当前项目 //先保存当前在Copy一份数据
            FileInfo info = new FileInfo(this.Current.Current.Files.FullName);
            //相等路径是正在操作的路径
            if (p_File.FullName != info.FullName)
            {
                ///如果文件存在提示 判断提示
                if (p_File.Exists)
                {
                    DialogResult dr = MsgBox.Show("文件已经存在，是否替换？", System.Windows.Forms.MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        result.Tag = 1;//通知是用户自己选择的no
                        result.Success = false;
                        return result;
                    }
                }
                bool isNewFile = false;
                //如果原始文件还没有保存 此处创建文件对象 否则Copy文件
                if (!info.Exists)
                {
                    //重新设置文件路径
                    this.Current.Current.Files.init(p_File.FullName);
                    //创建文件对象
                    (this.Current as _Pr_Business).SaveAndCreate();
                    isNewFile = true;

                    (this.Current as _Pr_Business).SaveAs(p_File);
                    if (isNewFile)
                    {
                        (this.Current as _Pr_Business).SavedAndCreated();
                    }
                }
                else
                {
                    File.Copy(info.FullName, p_File.FullName, true);
                    isNewFile = false;
                }

                result.Success = true;
                return result;

            }
            else
            {
                result.ErrorInformation = "不能替换当前已经打开的文件，请选择其他路径";
                result.Success = false;
                return result;
            }
            /*this.Current.Save();
            
            return result;*/
        }

        /// <summary>
        /// 另存为电子标书
        /// </summary>
        /// <param name="p_File"></param>
        /// <returns></returns>
        public override CResult SaveAsDZBS(FileInfo p_File)
        {
            CResult result = new CResult();
            BackgroundWorker sWorkerDZBS = new BackgroundWorker();
            sWorkerDZBS.WorkerReportsProgress = false;
            sWorkerDZBS.DoWork += new DoWorkEventHandler(sWorkerDZBS_DoWork);
            sWorkerDZBS.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sWorkerDZBS_RunWorkerCompleted);
            //object param = new object[] { result };
            sWorkerDZBS.RunWorkerAsync(p_File);
            ProgressFrom form = new ProgressFrom(sWorkerDZBS);
            form.ShowDialog();


            return result;
        }

        void sWorkerDZBS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MsgBox.Show("导出成功!", MessageBoxButtons.OK);
        }

        void sWorkerDZBS_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo p_File = e.Argument as FileInfo;
            //保存当前项目 //先保存当前在Copy一份数据
            this.Current.Save();
            FileInfo info = new FileInfo(this.Current.Current.Files.FullName);
            (this.Current as _Pr_Business).ReadyUseFile();
            File.Copy(info.FullName, p_File.FullName, true);
            (this.Current as _Pr_Business).SaveAsDZBS(p_File);
        }


        public override CResult OutImport(FileInfo p_Files, ArrayList p_Object)
        {
            if (this.Current.Current.IsDZBS)
            {
                foreach (_COBJECTS item in p_Object)
                {
                    item.IsDZBS = true;
                }
            }
            return this.SaveAs(p_Files);
        }

        public override CResult SaveAs(_Files p_Files)
        {
            FileInfo info = new FileInfo(p_Files.FullName);
            return this.SaveAs(info);
        }

        string p_OutType = string.Empty;
        /// <summary>
        /// 另存为xml文件
        /// </summary>
        /// <param name="p_path"></param>
        /// <param name="OutType"></param>
        /// <returns></returns>
        public override CResult SaveXml(string p_path, string p_OutType)
        {
            CResult result = new CResult();
            result.Success = true;
            this.p_OutType = p_OutType;

            BackgroundWorker sWorkerDZBS = new BackgroundWorker();
            sWorkerDZBS.WorkerReportsProgress = false;
            sWorkerDZBS.DoWork += new DoWorkEventHandler(sWorkerDZBS_DoWork1);
            sWorkerDZBS.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sWorkerDZBS_RunWorkerCompleted);
            //object param = new object[] { result };
            sWorkerDZBS.RunWorkerAsync(p_path);
            ProgressFrom form = new ProgressFrom(sWorkerDZBS);
            form.ShowDialog();

            return result;
        }
        void sWorkerDZBS_DoWork1(object sender, DoWorkEventArgs e)
        {
            string p_path = e.Argument as string;
            //保存当前项目 //先保存当前在Copy一份数据
            _Export ex = new _Export(this.Current);
            //根据导出类型初始化选择
            switch (p_OutType)
            {
                case "TBS":
                    ex.ExportTBS(p_path);
                    break;
                case "ZBS":
                    ex.ExportZBS(p_path);
                    break;
                case "BD":
                    ex.ExportBD(p_path);
                    break;
                default:
                    break;
            }
        }


        /// <summary>   
        /// 二进制序列化对象   
        /// </summary>   
        /// <param name="obj"></param>   
        private void BinarySerialize(string path, _COBJECTS obj)
        {
            BackgroundWorker bWorker = new BackgroundWorker();
            bWorker.WorkerReportsProgress = true;
            bWorker.DoWork += new DoWorkEventHandler(bWorker_DoWork);
            object param = new object[] { path, obj };
            bWorker.RunWorkerAsync(param);
            ProjProgressAction form = new ProjProgressAction(bWorker);
            //form.progressBarControl1.Properties.Maximum = this.Current.UnitCount;
            form.ShowDialog();
        }



        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bWorker = sender as BackgroundWorker;
            object[] param = e.Argument as object[];
            _Projects proj = param[1] as _Projects;
            string path = param[0].ToString();
            int percent = 0;
            BinaryFormatter formater = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                GZipStream zip = new GZipStream(stream, CompressionMode.Compress);
                {
                    bWorker.ReportProgress(++percent, proj);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        //using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                        {

                            /*GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
                            //BinaryFormatter formater = new BinaryFormatter();
                            proj.OutSerializable();
                            formater.Serialize(zip, proj);
                            byte[] buffer = ms.ToArray();
                            zip.Write(buffer, 0, buffer.Length);
                            
                            stream.Write(
                            zip.Close();
                            stream.Close();*/

                            //GZipStream zip = new GZipStream(stream, CompressionMode.Compress,true);
                            //BinaryFormatter formater = new BinaryFormatter();
                            proj.OutSerializable();
                            formater.Serialize(ms, proj);
                            byte[] buffer = ms.ToArray();
                            zip.Write(buffer, 0, buffer.Length);
                            //zip.Close();
                            //stream.Close();
                            ms.Dispose();
                        }
                    }

                    //循环单项
                    foreach (_Engineering info in proj.StrustObject.ObjectList.Values)
                    {
                        bWorker.ReportProgress(++percent, info);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            //using (FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                            {

                                //BinaryFormatter formater = new BinaryFormatter();
                                /*info.OutSerializable();
                                formater.Serialize(stream, info);
                                bWorker.ReportProgress(++percent, info);*/

                                //GZipStream zip = new GZipStream(stream, CompressionMode.Compress, true);
                                formater.Serialize(ms, info);
                                byte[] buffer = ms.ToArray();
                                zip.Write(buffer, 0, buffer.Length);
                                //zip.Close();
                                //stream.Close();
                            }
                            ms.Dispose();
                        }


                        foreach (_UnitProject up in info.StrustObject.ObjectList.Values)
                        {

                            bWorker.ReportProgress(++percent, up);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                //using (FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                                {
                                    //BinaryFormatter formater = new BinaryFormatter();
                                    /*up.OutSerializable();
                                    formater.Serialize(stream, up);
                                    bWorker.ReportProgress(++percent, up);*/

                                    //GZipStream zip = new GZipStream(stream, CompressionMode.Compress, true);
                                    formater.Serialize(ms, up);
                                    byte[] buffer = ms.ToArray();
                                    zip.Write(buffer, 0, buffer.Length);
                                    //
                                    //zip.Close();
                                    //stream.Close();
                                }
                                ms.Dispose();
                            }

                        }
                    }
                    /*byte[] buffer = ms.ToArray();
                    zip.Write(buffer, 0, buffer.Length);
                    ms.Close();*/
                }
                zip.Dispose();
                stream.Dispose();
                GC.Collect();
            }

        }

        #endregion
    }
}
