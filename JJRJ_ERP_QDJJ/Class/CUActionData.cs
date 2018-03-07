using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GOLDSOFT.QDJJ.UI.BaseFroms;
using ZiboSoft.Commons.Common;
using System.IO.Compression;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Security.AccessControl;

namespace GOLDSOFT.QDJJ.UI
{
    public class CUActionData : CActionData, IDataInterface
    {
        private bool IsSave = false;

        public CUActionData(_Business p_info)
            : base(p_info)
        { }


        #region IDataInterface 成员


        public override CResult Save()
        {
            //如果开启了保存历史功能
            IsSave = true;
            FileInfo file = new FileInfo(this.Current.Current.Files.FullName);
            //如果开启了保存历史功能
            CResult result = new CResult();
            this.Current.SetKeyNo();//保存加密锁号
            this.Current.Current.StructSource.ModelProject.UpDate(this.Current.Current);
            //每次保存后的状态设置为已经改变
            this.Current.Current.Property.SetObjectState(EObjectState.UnChange);
            this.BinarySerialize(file.FullName, this.Current.Current);
            APP.GoldSoftClient.SaveProeject(this.Current.Current.Name);
            result.Success = true;
            result.CurrOperateType = EOperateType.Insert;
            return result;

        }

        public override CResult SaveAs(string p_Path)
        {
            FileInfo info = new FileInfo(p_Path);
            return this.SaveAs(info);
        }

        public override CResult SaveAs(System.IO.FileInfo p_File)
        {
            //如果开启了保存历史功能
            CResult result = new CResult();
            FileInfo file = new FileInfo(p_File.FullName);
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

            this.Current.SetKeyNo();//保存加密锁号
            this.Current.Current.StructSource.ModelProject.UpDate(this.Current.Current);
            //每次保存后的状态设置为已经改变
            this.Current.Current.Property.SetObjectState(EObjectState.UnChange);
            this.BinarySerialize(p_File.FullName, this.Current.Current);
            APP.GoldSoftClient.SaveProeject(this.Current.Current.Name);
            //另存之后设置另存后的项目为当前操作项目
            result.Success = true;
            result.CurrOperateType = EOperateType.Insert;
            return result;
        }

        /// <summary>
        /// 导出指定的对象
        /// </summary>
        /// <param name="p_Files"></param>
        /// <param name="p_Object"></param>
        /// <returns></returns>
        public override CResult OutImport(System.IO.FileInfo p_File, ArrayList p_Object)
        {
            //如果开启了保存历史功能
            CResult result = new CResult();
            FileInfo file = new FileInfo(p_File.FullName);
            foreach (_COBJECTS info in p_Object)
            {
                info.IsDZBS = this.Current.Current.IsDZBS;
                if (info.IsDZBS)
                {
                    info.StructSource.ModelInfomation.Set("文件类型", "电子标书");
                }
                else 
                {
                    info.StructSource.ModelInfomation.Set("文件类型", "单位工程");
                }
                
                //_COBJECTS p = p_Object.Parent;
                //p_Object.Parent = null;
                //每次保存后的状态设置为已经改变
                int id = info.ID;
                this.Current.SetKeyNo();//保存加密锁号
                info.StructSource.ModelProject.UpDate(p_Object);
                info.ID = id;
            }
            this.BinarySerialize(file.Directory.FullName, p_Object);            
            //p_Object.Parent = p;
            result.Success = true;
            result.CurrOperateType = EOperateType.Insert;
            return result;
        }


        public override CResult SaveAs(_Files p_Files)
        {
            FileInfo info = new FileInfo(p_Files.FullName);
            return this.SaveAs(info);
        }

        /// <summary>
        /// 另存为xml文件(仅当前项目)
        /// </summary>
        /// <param name="p_path"></param>
        /// <param name="OutType"></param>
        /// <returns></returns>
        public override CResult SaveXml(string p_path, string p_OutType)
        {
            throw new NotImplementedException();
        }

        #region -------------批量导出单位工程------------------
        /// <summary>   
        /// 二进制序列化对象   
        /// </summary>   
        /// <param name="obj"></param>   
        public void BinarySerialize(string path, ArrayList obj)
        {
            BackgroundWorker PLWorker = new BackgroundWorker();
            PLWorker.WorkerReportsProgress = false;
            PLWorker.DoWork += new DoWorkEventHandler(PLWorker_DoWork);
            PLWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(PLWorker_RunWorkerCompleted);
            object param = new object[] { path, obj };
            PLWorker.RunWorkerAsync(param);
            ProgressFrom form = new ProgressFrom(PLWorker);
            form.ShowDialog();
        }

        /// <summary>
        /// 批量完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PLWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        /// <summary>
        /// 批量开始工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PLWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bWorker = sender as BackgroundWorker;
            object[] param = e.Argument as object[];
            ArrayList obj = param[1] as ArrayList;
            string path = param[0].ToString();
            FileInfo fi;
            GZipStream zip;
            string ph;
            BinaryFormatter formater;
            DataSet ds;
            _FileHeader header;
            byte[] buffer;
            foreach (_COBJECTS info in obj)
            {

                ph = string.Format("{0}\\{1}.JGCX", path, info.Name);
                fi = new FileInfo(ph);
                if (fi.Exists)
                {
                    ph = string.Format("{0}\\复件 {1}.JGCX", path, info.Name);
                }

                using (FileStream stream = new FileStream(ph, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        zip = new GZipStream(stream, CompressionMode.Compress);
                        formater = new BinaryFormatter();
                        //info.StructSource.AcceptChanges();
                        ds = info.StructSource.Copy();
                        ds.AcceptChanges();

                        header = new _FileHeader();
                        header.Set("总造价", info.StatusInfo.当前工程总造价.ToString());
                        formater.Serialize(ms, header);

                        formater.Serialize(ms, ds);
                        buffer = ms.ToArray();
                        zip.Write(buffer, 0, buffer.Length);
                        zip.Close();
                    }
                }
            }
            e.Result = path;
        }



        #endregion


        /// <summary>   
        /// 二进制序列化对象   
        /// </summary>   
        /// <param name="obj"></param>   
        public void BinarySerialize(string path, _COBJECTS obj)
        {
            BackgroundWorker bWorker = new BackgroundWorker();
            bWorker.WorkerReportsProgress = false;
            bWorker.DoWork += new DoWorkEventHandler(bWorker_DoWork);
            bWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bWorker_RunWorkerCompleted); ;
            object param = new object[] { path, obj };
            bWorker.RunWorkerAsync(param);
            ProgressFrom form = new ProgressFrom(bWorker);
            form.ShowDialog();
        }

        /// <summary>
        /// 保存完毕激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //每次保存的时候自动备份一个文件(修改日期格式文件名)
            if (IsSave)
            {
                FileInfo file = new FileInfo(e.Result.ToString());
                if (file.Exists)
                {
                    string path = GetNewFileName(file.Name);
                    string dir = APP.Cache.AppFolder + "工程文件\\备份文件\\";
                    DirectoryInfo info = ToolKit.GetDirectoryInfo(dir);
                    path = APP.Cache.AppFolder + "工程文件\\备份文件\\" + path;
                    File.Copy(file.FullName, path, true);
                }
                IsSave = false;
            }
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bWorker = sender as BackgroundWorker;
            object[] param = e.Argument as object[];
            _COBJECTS obj = param[1] as _COBJECTS;
            string path = param[0].ToString();
            ToolKit.GetDirectoryInfo(path.Substring(0, path.LastIndexOf("\\") ));
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    GZipStream zip = new GZipStream(stream, CompressionMode.Compress);
                    BinaryFormatter formater = new BinaryFormatter();
                    obj.StructSource.AcceptChanges();
                    _FileHeader header = new _FileHeader();
                    header.Set("总造价", obj.StatusInfo.当前工程总造价.ToString());
                    formater.Serialize(ms, header);
                    formater.Serialize(ms, obj.StructSource);
                    byte[] buffer = ms.ToArray();
                    zip.Write(buffer, 0, buffer.Length);
                    zip.Close();
                    e.Result = path;
                }
            }
        }

        #endregion
    }
}
