/*
 用于处理xml类转换成项目jxmx对象的多线程处理方法
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.ZBS;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Data;


namespace GOLDSOFT.QDJJ.UI
{
    public class XmlProjWorker
    {
        public ApplicationForm form = null;

        /// <summary>
        /// 总项目个数
        /// </summary>
        public int Count
        {
            get
            {
                if (this.建设项目 != null)
                {
                    int res = 0;
                    foreach (单项工程 item in m_建设项目.单项工程)
                    {
                        if (item.单位工程 != null)
                            res += item.单位工程.Length;
                    }
                    return res;
                }
                return 0;
            }
        }

        private int UnitCount = 0;
        private int CurCount = 0;

        private _Business m_Business;

        private _Projects m_CProjects;

        private string m_FileName;

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        /// <summary>
        /// 最终处理的项目结果
        /// </summary>
        public _Projects CProjects
        {
            get { return this.m_Business.Current as _Projects; }
            //set { m_CProjects = value; }
        }

        private 建设项目 m_建设项目;
        
        /// <summary>
        /// 反序列化后的类建设项目
        /// </summary>
        public 建设项目 建设项目
        {
            get { return m_建设项目; }
            set { m_建设项目 = value; }
        }

        public XmlProjWorker(_Business p_bus)
        {
            this.m_Business = p_bus;
        }
        private bool m_IsZJF;

        public bool IsZJF
        {
            get { return m_IsZJF; }
            set { m_IsZJF = value; }
        } 
        /// <summary>
        /// 根据文件反序列化为对象
        /// </summary>
        public void Load()
        {
            this.m_建设项目 = GOLDSOFT.QDJJ.COMMONS.CFiles.XmlDeserialize(typeof(建设项目), this.m_FileName) as 建设项目;
        }

        public BackgroundWorker ProjWorker;
        /// <summary>
        /// 开始创建项目对象
        /// </summary>
        public void Begin()
        {
            ProjWorker = new BackgroundWorker();
            ProjWorker.WorkerReportsProgress = true;
            ProjWorker.DoWork += new DoWorkEventHandler(ProjWorker_DoWork);
            ProjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProjWorker_RunWorkerCompleted);
            ProjWorker.RunWorkerAsync();
            XmlUnitProjProgressFrom form = new XmlUnitProjProgressFrom(ProjWorker);
            form.MaxCount = this.Count;
            form.ShowDialog();

        }

        void ProjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_Business.Current.StructSource.ModelInfomation.Set("版本号", APP.Ver);
            this.m_Business.Current.StructSource.ModelInfomation.Set("ObjectKey", this.m_Business.Current.ObjectKey);
            (this.m_Business as _Pr_Business).UpDate_Project();
            (this.m_Business as _Pr_Business).EndData();
            this.form.ActionFace.OpenNewBussinessForm(this.m_Business,true);
            //this.m_Business.FastCalculate();
            if (this.m_IsZJF)
            {
                MsgBox.Alert("请重新选择增加费!");
            }
        }


        /// <summary>
        /// 单位工程排序对象
        /// </summary>
        void ProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //仅读取数据
            this.m_Business.Create();
            this.CProjects.Name = this.CProjects.NodeName = m_建设项目.项目名称;
            this.m_Business.Current.Key = this.m_Business.Current.ObjectKey;
            if (!string.IsNullOrEmpty(this.m_建设项目.招标信息表.计价依据))
            {
                this.CProjects.DEGZ = this.m_建设项目.招标信息表.计价依据.ToString();
                this.CProjects.QDGZ = "2009";
            }
            else
            {
                this.CProjects.DEGZ = "2009";
                this.CProjects.QDGZ = "2009";
            }
            _Files file = new _Files();
            file.ChangeExtName(this.FileName,_Files.ProjectExName);
            //创建一个新的对象
            this.m_Business.Current.Files = file;
            UnitCount = this.Count;

            (this.m_Business as _Pr_Business).CreateFile();
            (this.m_Business as _Pr_Business).BeginData();
            // 还原项目结构表(还原当前项目)
           this.m_Business.Current.StructSource.ModelProject.Add(this.m_Business.Current);

            //(this.m_Business as _Pr_Business).AddUnit(this.m_Business.Current);

            foreach (单项工程 item in m_建设项目.单项工程)
            {
                _Engineering Engineering = this.CProjects.Create() as _Engineering;
                //Engineering.Sort = ++this.CProjects.EnSort;
                Engineering.Name = item.单项工程名称;
                Engineering.NodeName = item.单项工程名称;
                Engineering.Deep = 1;
                SetEngineering(Engineering, item);                
            }


            this.SetZTB();
            //this.m_Business.EndCreate();
            while (true)
            {
                if (Completed)
                {
                    Thread.Sleep(500);
                    break;
                }
            }
        }
      
        /// <summary>
        /// 招标信息赋值
        /// </summary>
        /// <param name="dt"></param>
        private void SetZTB()
        {
            if (this.m_建设项目.招标信息表 != null)
            {
                DataRow info = this.m_Business.Current.StructSource.BiddingInfoSource.NewRow();
                this.m_建设项目.招标信息表 = new 招标信息表();
                info["GCLX"] = this.m_建设项目.招标信息表.工程类型;
                info["JSDW"] = this.m_建设项目.招标信息表.建设单位;
                info["ZBDLR"] = this.m_建设项目.招标信息表.招标代理;
                info["ZBFW"] = this.m_建设项目.招标信息表.招标范围;
                info["ZBMJ"] = this.m_建设项目.招标信息表.总招标面积;
                info["ZBGQ"] = this.m_建设项目.招标信息表.招标工期;
                info["PlaitName"] = this.m_建设项目.招标信息表.编制人员1;
                info["PlaitNo"] = this.m_建设项目.招标信息表.注册号1;
                info["BZDW"] = this.m_建设项目.招标信息表.编制单位;
                info["SJDW"] = this.m_建设项目.招标信息表.设计单位;
                if (!string.IsNullOrEmpty(this.m_建设项目.招标信息表.编制时间))
                info["PlaitDate"] = this.m_建设项目.招标信息表.编制时间;
                info["DBLX"] = this.m_建设项目.招标信息表.招标要求担保类型;
                this.m_Business.Current.StructSource.BiddingInfoSource.Rows.Add(info);
            }
            if (this.m_建设项目.投标信息表 != null)
            {
                DataRow info = this.m_Business.Current.StructSource.TenderInfoSource.NewRow();
                info["TBDWDBR"] = this.m_建设项目.投标信息表.投标人;
                info["TBGQ"] = this.m_建设项目.投标信息表.投标工期;
                info["JZS"] = this.m_建设项目.投标信息表.项目经理或注册建造师;
                info["JZSH"] = this.m_建设项目.投标信息表.项目经理或建造师注册号;
                info["PlaitName"] = this.m_建设项目.投标信息表.编制人员1;
                info["PlaitNo"] = this.m_建设项目.投标信息表.注册号1;
                if (!string.IsNullOrEmpty(this.m_建设项目.投标信息表.编制时间))
                info["PlaitDate"] = this.m_建设项目.投标信息表.编制时间;
                this.m_Business.Current.StructSource.TenderInfoSource.Rows.Add(info);
            }
        }


        //每调用
       /*void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (this.m_Business as _Pr_Business).EndData();
            //更新基础表
            //每次保存对象key
            this.m_Business.Current.StructSource.ModelInfomation.Set("ObjectKey", this.m_Business.Current.ObjectKey);
            (this.m_Business as _Pr_Business).UpDate_ProjInfomation(this.m_Business.Current.StructSource.ModelInfomation);
            this.m_Business.Current.StructSource.AcceptChanges();

            
            this.form.ActionFace.OpenNewBussinessForm(this.m_Business);
        }*/

        bool Completed = false;

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Completed)
                {
                    break;
                }
            }

        }

        /// <summary>
        /// 单项工程赋值
        /// </summary>
        /// <param name="Engineering"></param>
        /// <param name="dx"></param>
        private void SetEngineering(_Engineering Engineering, 单项工程 dx)
        {
            //添加到项目结构表
            (this.m_Business as _Pr_Business).Add(Engineering);
            if (dx.单位工程 == null) return;
            string[] fNames = this.FileName.Split('.');
            if(fNames.Length < 2) 
            {
                MsgBox.Alert("文件类型错误!");
                return;
            }
            foreach (单位工程 item in dx.单位工程)
            {
                XmlUnitWorker unit = new XmlUnitWorker(this.m_Business,item, Engineering,this);

                unit.FileType = fNames[1];
                unit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(unit_RunWorkerCompleted);
                unit.RunTreadPoolCompleted += new RunTreadPoolCompleted(unit_RunTreadPoolCompleted);
                unit.js = this.建设项目;
                unit.Begin();
            }
        }

        /// <summary>
        /// 当一个单位工程完成后调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void unit_RunTreadPoolCompleted(object sender, object args)
        {
            XmlUnitWorker x = sender as XmlUnitWorker;
            ProjWorker.ReportProgress(++CurCount, x);
            
            if (x != null&&!this.m_IsZJF) 
            {
                this.m_IsZJF = x.IsZJF;
            }
            
            if (this.CurCount == this.UnitCount)
            {

                //结束
              //  this.form.ActionFace.OpenNewBussinessForm(this.m_Business);
                Completed = true;
            }
        }
        
        void unit_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            CurCount++;
            if (this.CurCount == this.UnitCount)
            {
                //结束
                this.form.ActionFace.OpenNewBussinessForm(this.m_Business);
            }
        }
    }
}
