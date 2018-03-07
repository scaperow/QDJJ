using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _MFixedListInfo : _FixedListInfo
    {

        private _CommonrojectInfo m_Parent = null;
        /// <summary>
        /// 当前对象的父级（通用项目）
        /// </summary>
        public _CommonrojectInfo Parent
        {
            get
            {
                return this.m_Parent;
            }
            set { m_Parent = value; }
        }


        public override bool JBHZ
        {
            get { return base.JBHZ; }
            set { base.JBHZ = value; this.Parent.Begin();}
        }

        private int m_XH2;
        /// <summary>
        /// 用于数据导出时的位置编号
        /// </summary>
        public int XH2
        {
            get { return m_XH2; }
            set { m_XH2 = value; }
        }

        public _MFixedListInfo(_CommonrojectInfo p_Parent)
            : base()
        {
            this.m_Parent = p_Parent;
            this.Statistics = new _MFixedList_Statistics(this);
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.Activitie;
            }
        }

        public _MFixedListInfo()
            : base()
        {
            this.Statistics = new _MFixedList_Statistics(this);

        }

        public override void RemoveIncrease()
        {

           _SubheadingsInfo[] arr=this.IncreaseCostsList.Cast<_SubheadingsInfo>().ToArray();
           foreach (_SubheadingsInfo item in arr)
            {
                this.Activitie.Property.MeasuresProject.ObjectsList.Remove(item);
                this.SubheadingsList.Remove(item);
            }
            
        }
        public override void Create(string m_DEH, int d)
        {
            DataRow[] rows = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy().Select(string.Format("DINGEH='{0}'", m_DEH));
            if (rows.Length > 0)
            {
                _SubheadingsInfo sinfo = new _SubheadingsInfo();
                this.Activitie.Property.SubSegments.Methods.SetSubheadingsInfo(sinfo, rows[0], this.Activitie.Property.Libraries.FixedLibrary.FullName);
                //view1.BEIZHU = (view1 as _SubheadingsInfo).Parent.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                this.Create(sinfo);
                sinfo.XMBM += "*" + d + "";
            }
        }
   
        public override void Create(_SubheadingsInfo info)
        {
            if (this.XMBM == "" && this.XMMC == "") return;
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            info.ID = this.m_Parent.Parent.ObjectID;
            info.PARENTID = this.ID;
            info.Parent = this;
            info.STATUS = true;
            info.ZJFS = _Constant.子目组价;
            if (!string.IsNullOrEmpty(info.JSJC))
            {
                info.ZJFS = _Constant.公式组价;
            }
            if (info.XMBM != "" && info.BEIZHU == "")
            {
                if (!string.IsNullOrEmpty(this.OLDXMBM))
                {
                    info.BEIZHU = this.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    info.BEIZHU = this.XMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }

            this.SubheadingsList.Add(info);
            this.Parent.Parent.ObjectsList.Add(info);
            info.Create();
            info.Subheadings_Statistics.Begin();
            info.IsCalc = true;
        }

        public override void CreateByXml(_SubheadingsInfo info)
        {
            if (this.XMBM == "" && this.XMMC == "") return;
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            info.ID = this.m_Parent.Parent.ObjectID;
            info.PARENTID = this.ID;
            info.Parent = this;
            info.STATUS = true;
            info.ZJFS = _Constant.子目组价;
            if (!string.IsNullOrEmpty(info.JSJC))
            {
                info.ZJFS = _Constant.公式组价;
            }
            if (info.XMBM != "" && info.BEIZHU == "")
            {
                if (!string.IsNullOrEmpty(this.OLDXMBM))
                {
                    info.BEIZHU = this.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    info.BEIZHU = this.XMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }

            this.SubheadingsList.Add(info);
            this.Parent.Parent.ObjectsList.Add(info);
            info.Create();
            info.IsCalc = true;
        }

        public override void Create(_SubheadingsInfo info,_SubheadingsInfo index_info)
        {
            if (this.XMBM == "" && this.XMMC == "") return;
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            info.ID = this.m_Parent.Parent.ObjectID;
            info.PARENTID = this.ID;
            info.Parent = this;
            info.STATUS = true;
            info.ZJFS = _Constant.子目组价;
            if (!string.IsNullOrEmpty(info.JSJC))
            {
                info.ZJFS = _Constant.公式组价;
            }
            if (info.XMBM != "" && info.BEIZHU == "")
            {
                if (!string.IsNullOrEmpty(this.OLDXMBM))
                {
                    info.BEIZHU = this.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    info.BEIZHU = this.XMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }

            this.SubheadingsList.Add(info);
            this.Parent.Parent.ObjectsList.Insert(info, index_info);
            info.Create();
            info.Subheadings_Statistics.Begin();
            info.IsCalc = true;
        }
        public override decimal ZJTJ
        {
            get { return base.ZJTJ; }
            set
            {

                AddZm();//若该清单下没有子目则添加子目
                base.ZJTJ = value;
                //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
            }
        }

        public override decimal GCL
        {
            get { return base.GCL; }
            set
            {

                AddZm();//若该清单下没有子目则添加子目
                base.GCL = value;
                //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
            }
        }
       
        private void AddZm()
        {
            if (this.Parent == null) return;
            //if (this.Activitie == null) return;
            if (this.SubheadingsList.Count < 1)
            {

                _SubheadingsInfo info = new _MSubheadingsInfo();
                info.XMBM = "补" + this.XMBM.Replace("补","");
                info.OLDXMBM = this.XMBM.Replace("补", "");
                info.XMMC = "补充定额";
                info.GCL = 1m;
                info.SC = true;
                info.LB = "子目";
                info.DW = this.DW;
                info.TX = this.Activitie.ProType.Replace("【", "").Replace("】", "").Substring(0, 2);
                info.LibraryName = this.Activitie.Property.Libraries.FixedLibrary.FullName;
                this.Create(info);
                this.Activitie.Property.MeasuresProject.DataSource.ResetBindings(false);
                // this.Activitie.Property.SubSegments.DataSource.ResetBindings(false);
            }

        }
        public override void Begin()
        {

            if (this.Statistics as _MFixedList_Statistics == null)
            {
                this.Statistics = new _MFixedList_Statistics(this);
            }
            this.Statistics.Begin();
            if(this.m_Parent!=null)
            this.m_Parent.Begin();
            //base.Begin();
        }
        /// <summary>
        /// 计算基础发生改变的时候要做的事
        /// </summary>
        public override string JSJC
        {
            get { return base.JSJC; }
            set
            {

                base.JSJC = value;
                if (this.STATUS)
                {
                    this.Begin();
                }

            }
        }
        /// <summary>
        /// 费率发生改变的时候要做的事
        /// </summary>
        public override string FL
        {
            get { return base.FL; }
            set
            {

                base.FL = value;
                if (this.STATUS)
                {
                    this.Begin();
                }

            }
        }




        public override string ZJFS
        {
            get { return base.ZJFS; }
            set
            {

                base.ZJFS = value;
                if (this.STATUS)
                {
                    this.Begin();
                }

            }
        }
        /// <summary>
        /// 直接组价计算
        /// </summary>
        public void ZBegin()
        {
            string str = this.JSJC;
            if (string.IsNullOrEmpty(str)) str = "0";
            this.Parent.Parent.Parent.Property.Statistics.Begin();
            str = ToolKit.ExpressionReplace(str, this.Parent.Parent.Parent.Property.Statistics.ResultVarable.DataSource);
            decimal m = 1m;
            decimal.TryParse(this.FL, out m);
            this.ZHHJ = ToolKit.Calculate(str) * m * this.GCL * 0.01m;
            this.Begin();
        }
        public override void Remove(_SubheadingsInfo info)
        {
            base.Remove(info);
            this.Parent.Parent.ObjectsList.Remove(info);
            this.Begin();
        }

        /// <summary>
        /// 直接通知分部分项修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnModelEdited(object sender, object args)
        {
            base.OnModelEdited(sender, args);
            this.Activitie.Property.MeasuresProject.OnModelEdited(sender, args);
        }

        /// <summary>
        /// 直接通知分部分项动作操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnModelActioin(object sender, object args)
        {
            base.OnModelActioin(sender, args);
            this.Activitie.Property.MeasuresProject.OnModelActioin(sender, args);
        }
        #region -------------------------------重新基类接口实现---------------------------
        public override long PKey
        {
            get
            {
                return this.Parent.Key;
            }
            set
            {
                //this.m_PKey = value;
            }
        }

        public override string ProName
        {
            get
            {
                return this.Parent.ProName;
            }
            set { }
        }
        public override ISubSegment IParent
        {
            get
            {
                return this.Parent;
            }
        }
        #endregion


        public override void Copys()
        {
            _CommonrojectInfo p = this.Parent;
            this.Parent = null;
            Clipboard.SetDataObject(this);
            this.Parent = p;
            //return base.Copy();
        }
        public override void Copys(object o)
        {

            Clipboard.SetDataObject(o);

        }
        public override void Paste()
        {
            IDataObject o = Clipboard.GetDataObject();

            _CopyList obj = o.GetData(typeof(_CopyList)) as _CopyList;
            if (obj == null) return;
            switch (obj.Ctype)
            {
                case CopType.清单:
                    foreach (_FixedListInfo info in obj)
                    {
                        info.InSerializable(null);
                        this.Activitie.Property.SubSegments.Create(info);
                        object[] items = info.SubheadingsList.ToArray();
                        info.SubheadingsList.Clear();
                        foreach (_SubheadingsInfo item in items)
                        {
                            info.Create(item);
                        }
                    }

                    break;
                case CopType.子目:
                    foreach (_SubheadingsInfo sinfo in obj)
                    {
                        sinfo.InSerializable(null);
                        this.Create(sinfo);
                    }

                    break;
                default:
                    break;
            }

            Clipboard.Clear();
        }
        
    }
}
