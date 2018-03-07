using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
/*****措施项目********/
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _MeasuresProject : _ObjectInfo
    {
        /// <summary>
        /// 对象编号（每次获取此值会自动增长）
        /// </summary>
        private int m_ObjectID = 1;

        /// <summary>
        /// 获取对象编号
        /// </summary>
        public int ObjectID
        {
            get
            {
                return ++m_ObjectID;
            }
        }
        /// <summary>
        /// 当前措施项目的所有数据集合
        /// </summary>
        /// 
        private _List m_ObjectsList = null;

        public _List ObjectsList
        {
            get
            {
                return this.m_ObjectsList;
            }
            set
            {
                this.m_ObjectsList = value;
            }
        }
        public _List SubheadingsList
        {
            get
            {
                _List mSubheadingsList = new _List();
                foreach (_CommonrojectInfo item in CommonrojectList)
                {
                    mSubheadingsList.AddRange(item.SubheadingsList);
                }
                return mSubheadingsList;
            }
        }

        /// <summary>
        /// 当前分部分项所属于的父级对象
        /// </summary>
        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取当前措施项目的父级对象
        /// </summary>
        public _UnitProject Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        private bool m_IsInit = true;
        /// <summary>
        /// 标识是否初始化过（添加默认模板）
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }
      
        /// <summary>
        /// 措施项目的构造 父类为单位工程
        /// </summary>
        /// <param name="p_Parent"></param>
        public _MeasuresProject(_UnitProject p_Parent)
        {
            //当前父类
            this.m_Parent = p_Parent;
            //this.Activitie = p_Parent;
            m_ObjectsList = new _List();
            //当前措施项目下的所有通用项目集合
            this.Statistics = new _Measures_Statistics(this);
            init();
            //Load();
        }

        public void Calculate()
        {
            this.IsResetBindings = false;
            this.Activitie.Property.Statistics.Begin();
            this.Activitie.Property.MeasuresProject.Statistics.Calculate();
            //IEnumerable<_ObjectInfo> infos = from n in this.ObjectsList.Cast<_ObjectInfo>()
            //                                 where n as _SubheadingsInfo != null && n.ZJFS == _Constant.公式组价
            //                                 select n;

            //_ObjectInfo[] sinfos = infos.ToArray();
            //foreach (_SubheadingsInfo item in sinfos)
            //{
            //    item.ZBegin();
            //}
            this.IsResetBindings = true;
        }

        /// <summary>
        /// 当前措施项目下的清单集合
        /// </summary>
        public List<_MFixedListInfo> MFixedList
        {
            get
            {
                List<_MFixedListInfo> list = new List<_MFixedListInfo>();
                IEnumerable<_ObjectInfo> infos = from info in this.ObjectsList.Cast<_ObjectInfo>()
                                                 where info.GetType() == typeof(_MFixedListInfo)
                                                 select info;
                list = infos.Cast<_MFixedListInfo>().ToList();
                return list;

            }

        }
        public List<_CommonrojectInfo> CommonrojectList
        {
            get
            {
                List<_CommonrojectInfo> list = new List<_CommonrojectInfo>();
                IEnumerable<_ObjectInfo> infos = from info in this.ObjectsList.Cast<_ObjectInfo>()
                                                 where info.GetType() == typeof(_CommonrojectInfo)
                                                 select info;
                list = infos.Cast<_CommonrojectInfo>().ToList();
                return list;

            }

        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.ID = this.ObjectID;
            this.GCL = 0.0m;
            this.XMBM = "措施项目";
            this.JSJC = "";
            this.FL = "";
            this.m_ObjectsList.Add(this);

        }

        /// <summary>
        /// 初始化时默认套用某模板
        /// </summary>
        public void Load()
        {
            if (this.IsInit)
            {
                string str = this.Parent.ProType;
                DataTable dt = _Common.Application.Global.DataTamp.MeasuresList.Tables[Tname(str)];
                LoadTable(dt);
                this.m_IsInit = false;
            }

        }

        /// <summary>
        /// 重排流水号
        /// </summary>
        public void RestLSH()
        {
            //IEnumerable<_ObjectInfo> infos = (from n in this.MFixedList.Cast<_ObjectInfo>()
            //                                  where 1 == 1
            //                                  select n).Distinct(new QDDistinct());
            //_ObjectInfo[] arr = infos.ToArray();
            //foreach (_ObjectInfo item in arr)
            //{
            //    IEnumerable<_ObjectInfo> info = from n in this.MFixedList.Cast<_ObjectInfo>()
            //                                    where n.XMBM.Substring(0, n.XMBM.Length - 3) == item.XMBM.Substring(0, item.XMBM.Length - 3)
            //                                    select n;
            //    _ObjectInfo[] arr1 = info.ToArray();
            //    int m = 0;
            //    for (int i = 0; i < arr1.Length; i++)
            //    {
            //        m = i + 1;
            //        if (m.ToString().Length == 1)
            //            arr1[i].XMBM = arr1[i].OLDXMBM + "00" + m.ToString();
            //        else if (m.ToString().Length == 2)
            //            arr1[i].XMBM = arr1[i].OLDXMBM + "0" + m.ToString();
            //        else
            //            arr1[i].XMBM = arr1[i].OLDXMBM + m.ToString();

            //    }
            //}
        }

        private DataTable GetTableByThis()
        {
            DataTable dt = _Common.Application.Global.DataTamp.MeasuresList.Tables[Tname(this.Parent.ProType)];
            DataTable table = dt.Clone();
            
            return table;
        }
        private void LoadTable(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            DataRow[] crows = dt.Select("ParentID=1");//父级编号为1的为通用项目
            int xh = 1;
            for (int i = 0; i < crows.Length; i++)
            {
                _CommonrojectInfo info = new _CommonrojectInfo();
                
                info.JSJC = "";
                info.FL = "";
                info.GCL = 0m;
                info.XMMC = crows[i]["Name"].ToString();
                info.XMBM = crows[i]["Codes"].ToString();
                info.OLDXMBM = crows[i]["Codes"].ToString();
                //通用项目添加到集合
                this.Create(info);
                DataRow[] rows = dt.Select("ParentID=" + crows[i]["ID"] + "");//父级编号为为通用项目ID的项为清单
                int m = 1;
                for (int j = 0; j < rows.Length; j++)
                {
                    _MFixedListInfo minfo = new _MFixedListInfo();
                   
                    minfo.XMMC = rows[j]["Name"].ToString();
                    minfo.LB = rows[j]["Type"].ToString();
                    minfo.GCL = 1m;
                    minfo.JSJC = rows[j]["Calculation"].ToString();
                    minfo.FL = rows[j]["Rate"].ToString();
                    minfo.DW = rows[j]["Unit"].ToString();
                    minfo.XMBM = rows[j]["Codes"].ToString();
                    minfo.OLDXMBM = rows[j]["Codes"].ToString();
                    minfo.XH = xh++;
                    if (rows[j]["Remark"].ToString().Contains("通用项目"))
                    {
                        minfo.XH2 = int.Parse(rows[j]["Remark"].ToString().Replace("通用项目", ""));
                    }
                    if (i == 0 && m < 5)
                    {
                        minfo.ISTY = true;
                    }
                    m++;
                    info.Create(minfo);
                    DataRow[] srows = dt.Select("ParentID=" + rows[j]["ID"] + "");//父级编号为为清单ID的项为子目
                    for (int k = 0; k < srows.Length; k++)
                    {
                        _MSubheadingsInfo sinfo = new _MSubheadingsInfo();
                        
                        sinfo.XMMC = srows[k]["Name"].ToString();
                        sinfo.LB = srows[k]["Type"].ToString();
                        sinfo.JSJC = srows[k]["Calculation"].ToString();
                        sinfo.FL = srows[k]["Rate"].ToString();
                        sinfo.DW = srows[k]["Unit"].ToString();
                        sinfo.LibraryName = this.Parent.Property.DLibraries.FixedLibrary.FullName;
                        sinfo.GCL = 1m;
                        sinfo.XMBM = srows[k]["Codes"].ToString();
                        sinfo.OLDXMBM = srows[k]["Codes"].ToString();
                        minfo.Create(sinfo);
                    }
                }

            }
        }


        private DataTable M_MeasuresFL;
        /// <summary>
        /// 措施项目费率
        /// </summary>
        public DataTable MeasuresFL
        {
            get
            {
                M_MeasuresFL = _Common.Application.Global.DataTamp.MeasuresList.Tables["措施项目费率"].Copy();
                return M_MeasuresFL;
            }

        }
        public void RemoveParent()
        {
            this.m_Parent = null;
        }
        public void SetParent(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
        }
        private string Tname(string str)
        {

            string Tname = "";
            int value = -1;
            value = str.IndexOf("安装专业");
            if (value > -1) Tname = "【安装专业】措施模板";
            value = str.IndexOf("机械土石方专业");
            if (value > -1) Tname = "【机械土石方专业】措施模板";
            value = str.IndexOf("建筑装饰专业");
            if (value > -1) Tname = "【建筑装饰专业】措施模板";
            value = str.IndexOf("人工土石方专业");
            if (value > -1) Tname = "【人工土石方专业】措施模板";
            value = str.IndexOf("市政安装专业");
            if (value > -1) Tname = "【市政安装专业】措施模板";
            value = str.IndexOf("市政建筑安装专业");
            if (value > -1) Tname = "【市政建筑安装专业】措施模板";
            value = str.IndexOf("市政建筑专业");
            if (value > -1) Tname = "【市政建筑专业】措施模板";
            value = str.IndexOf("一般土建专业");
            if (value > -1) Tname = "【一般土建专业】措施模板";
            value = str.IndexOf("园林绿化专业");
            if (value > -1) Tname = "【园林绿化专业】措施模板";
            value = str.IndexOf("桩基专业");
            if (value > -1) Tname = "【桩基专业】措施模板";
            value = str.IndexOf("装饰装修专业");
            if (value > -1) Tname = "【装饰装修专业】措施模板";
            return Tname;


        }

        [NonSerialized]
        private BindingSource m_BindingSource = null;
        /// <summary>
        /// 措施项目的数据源
        /// </summary>
        public BindingSource DataSource
        {
            get
            {
                if (m_BindingSource != null)
                {
                    return this.m_BindingSource;
                }
                else
                {
                    m_BindingSource = new BindingSource();
                    m_BindingSource.DataSource = m_ObjectsList;
                    return m_BindingSource;
                }

            }
        }
      

        /* private string m_JSJC;
         /// <summary>
         /// 计算基础
         /// </summary>
         public string JSJC
         {
             get { return m_JSJC; }
             set { m_JSJC = value; }
         }
         private string m_FL;
         /// <summary>
         /// 费率
         /// </summary>
         public string FL
         {
             get { return m_FL; }
             set { m_FL = value; }
         }*/
        public void Create(_CommonrojectInfo info)
        {
            //info.Activitie = this.Activitie;
            info.Parent = this;
            info.ID = this.ObjectID;
            info.PARENTID = this.ID;
            info.STATUS = false;
            info.Parent = this;
            this.m_ObjectsList.Add(info);
            info.STATUS = true;


        }
        public override _UnitProject Activitie
        {
            get
            {
                return this.Parent;
            }
        }
        /// <summary>
        /// 删除通用项目
        /// </summary>
        /// <param name="info"></param>
        public void Del(_CommonrojectInfo info)
        {
            _FixedListInfo[] infos = info.MFixedList.Cast<_FixedListInfo>().ToArray();
            foreach (_FixedListInfo item in infos)
            {
                info.Del(item as _MFixedListInfo);
                this.m_ObjectsList.Remove(item);
            }
            this.m_ObjectsList.Remove(info);
        }

        public bool IsResetBindings = true;

        /// <summary>
        /// 开始计算
        /// </summary>
        public void Begin()
        {
           this.Statistics.Begin();
            //this.DataSource.DataMember = "ID";
            //this.DataSource.EndEdit();
           if (IsResetBindings)
           {
               this.DataSource.ResetBindings(false);
           }
        }


        public List<_CommonrojectInfo> _CommonrojectList
        {
            get
            {
                IEnumerable<_CommonrojectInfo> infos = from info in this.ObjectsList.Cast<_ObjectInfo>()
                                                       where info.GetType() == typeof(_CommonrojectInfo) && info.PARENTID == this.ID
                                                       select info as _CommonrojectInfo;

               // m_ProfessionalList = infos.ToList();
                return infos.ToList(); ;
            }
        }
        public _List GetAllQuantityUnitNotZC
        {
            get
            {
                _List list = new _List();
                foreach (_ObjectInfo info in this.m_ObjectsList)
                {
                    _MFixedListInfo item = info as _MFixedListInfo;
                    if (item != null)
                    {
                        list.AddRange(item.GetAllQuantityUnitNotZC);

                    }

                }
                return list;
            }
        }

        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_ObjectInfo info in this.m_ObjectsList)
                {
                    _MFixedListInfo item = info as _MFixedListInfo;
                    if (item!=null)
                    {
                        list.AddRange(item.GetAllQuantityUnit);
                        
                    }
                    
                }
                return list;
            }
        }

        /// <summary>
        /// 获取当前(分部分项)下的所有(工料机汇总信息)
        /// </summary>
        public object GetQuantityUnitSummary
        {
            get
            {
                return this.GetAllQuantityUnitNotZC.Cast<_ObjectQuantityUnitInfo>().Distinct(new MergerSummary());
            }
        }




        #region -------------------------------重新基类接口实现---------------------------
        public override long PKey
        {
            get
            {
                return this.Parent.Reveal.ProMeasures.Key;
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
                return this.Parent.Reveal.ProMeasures.ProName;
            }
            set { }
        }
        public override ISubSegment IParent
        {
            get
            {
                return this.Parent.Reveal.ProMeasures;
            }
        }
        #endregion

        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            this.Statistics = new _Measures_Statistics(this);
            foreach (IDataSerializable ids in this.CommonrojectList)
            {
                ids.InSerializable(this);
            }

        }
    }
}
