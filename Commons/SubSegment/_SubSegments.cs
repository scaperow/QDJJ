/*
   分部分项实体
   此对象包喊清单集合对象
   通用方法集合对象
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 分部分项对象
    /// </summary>
    [Serializable]
    public class _SubSegments : _ObjectInfo
    {


        /// <summary>
        /// 当前工料机的使用状态默认为 EObjectState.UnChange
        /// </summary>
        [NonSerialized]
        private EObjectState m_UseQuantityUnit = EObjectState.UnChange;

        /// <summary>
        /// 当前模块属性发生变化时候激发此事件
        /// </summary>
        public virtual EObjectState UseQuantityUnit
        {
            get
            {
                return this.m_UseQuantityUnit;
            }
            set
            {
                this.m_UseQuantityUnit = value;
            }
        }

        private bool m_IsZDSC;
        /// <summary>
        /// 若通过工程信息生成了清单 则进入分部分项需刷新数据
        /// </summary>
        public bool IsZDSC
        {
            get { return m_IsZDSC; }
            set { m_IsZDSC = value; }
        }

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
        /// 当前分部分项所属于的父级对象
        /// </summary>
        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取当前分部分项的父级对象
        /// </summary>
        public _UnitProject Parent
        {
            get
            {
                return this.m_Parent;
            }
            set { this.m_Parent = value; }
        }

        /// <summary>
        /// 当前分部分项的所有数据集合
        /// </summary>
        
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



        /// <summary>
        /// 为分部分项处理的方法对象
        /// </summary>
        private _Methods m_Methods = null;

        /// <summary>
        /// 为分部分项处理的方法对象
        /// </summary>
        public _Methods Methods
        {
            get
            {
                return this.m_Methods;
            }
        }



        /// <summary>
        /// 标识是否刷新
        /// </summary>
        private bool m_Refesh = true;

        /// <summary>
        /// 标识是否刷新
        /// </summary>
        public bool Refesh
        {
            get
            {
                return this.m_Refesh;
            }
            set
            {
                this.m_Refesh=value;
            }
        }


        //private _Statistics m_Statistics = null;
        ///// <summary>
        ///// 获取或设置：分部分项计算结果
        ///// </summary>
        //public _Statistics Statistics
        //{
        //    get { return m_Statistics; }
        //    set { m_Statistics = value; }
        //}


        /// <summary>
        /// 分部分项构造函数
        /// </summary>
        /// <param name="p_Parent">所属于单位工程</param>
        public _SubSegments(_UnitProject p_Parent)
        {
            //当前父类
            this.m_Parent = p_Parent;
            //this.Activitie = p_Parent;
            //用于处理分部分项方法集
            this.m_Methods = new _Methods(this);
            //返回所有的对象集合
            this.m_ObjectsList = new _List();
            //清单集合
            //this.m_FixedList = new _FixedsList(this);
            m_BindingSource = new BindingSource();
            //计算类
            Statistics = new _SubSegment_Statistics(this);
            m_FixedList = new List<_FFixedListInfo>();
            m_ProfessionalList = new List<_ProfessionalInfo>();
            //第一次创建分部分项的时候需要初始化当前对象
            init();
            //测试
            //_FixedListInfo info = new _FixedListInfo();
            //this.m_FixedList.Add(info);

        }
        public void RemoveParent()
        {
            this.m_Parent = null;
        }
        public void SetParent(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.ID = this.ObjectID;
            this.XMBM = "单位工程";
            this.GCL = 0.0m;
            this.Sort = 1;
            this.m_ObjectsList.Add(this);


        }

        /// 获取或设置当前章集合
        /// </summary>
        [NonSerialized]
        private List<_ProfessionalInfo> m_ProfessionalList = null;

        /// <summary>
        /// 获取或设置当前章集合
        /// </summary>
        public List<_ProfessionalInfo> ProfessionalList
        {
            get
            {
                IEnumerable<_ProfessionalInfo> infos = from info in this.ObjectsList.Cast<_ObjectInfo>()
                                                       where info.GetType() == typeof(_ProfessionalInfo) && info.PARENTID == this.ID
                                                       select info as _ProfessionalInfo;

                m_ProfessionalList = infos.ToList();
                return this.m_ProfessionalList;
            }
            set
            {
                this.m_ProfessionalList = value;
            }
        }


        /// <summary>
        /// 清单对象
        /// </summary>
        [NonSerialized]
        private List<_FFixedListInfo> m_FixedList = null;

        /// <summary>
        /// 获取或设置当前清单集合类
        /// </summary>
        public List<_FFixedListInfo> FixedList
        {
            get
            {
                IEnumerable<_FFixedListInfo> infos = from info in this.ObjectsList.Cast<_ObjectInfo>()
                                                     where info.GetType() == typeof(_FFixedListInfo)
                                                     select info as _FFixedListInfo;

                m_FixedList = infos.ToList();
                return this.m_FixedList;
            }
            set
            {
                this.m_FixedList = value;
            }
        }

        /// <summary>
        /// 当前清单子目的列表类型(默认为Default)
        /// </summary>
        private EListType m_ListType = EListType.Default;

        /// <summary>
        /// 获取或设置当前清单子目的列表类型
        /// </summary>
        public EListType ListType
        {
            get { return m_ListType; }

            set { m_ListType = value; }

        }

        [NonSerialized]
        private BindingSource m_BindingSource = null;

        public BindingSource DataSource
        {
            get
            {
                //ChangeSource();
                return this.m_BindingSource;
            }
        }

        /// <summary>
        /// 返回清单数据对象集合
        /// </summary>
        /// 

        public void ChangeSource()
        {
            //m_BindingSource = new BindingSource();
            if (m_BindingSource == null)
            {
                m_BindingSource = new BindingSource();
            }
            //m_BindingSource.Clear();
            IEnumerable<_ObjectInfo> infos;
            switch (this.m_ListType)
            {
                case EListType.Default:

                    infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
                            where info.GetType() != typeof(_ProfessionalInfo)
                            && info.GetType() != typeof(_ChapterInfo)
                            && info.GetType() != typeof(_FestivalInfo)
                            //orderby info.Sort ascending
                            select info;
                    m_BindingSource.DataSource = infos.ToArray();
                    break;
                case EListType.Professional:
                    infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
                            where info.GetType() != typeof(_ChapterInfo)
                            && info.GetType() != typeof(_FestivalInfo)
                           // orderby info.Sort ascending
                            select info;
                    m_BindingSource.DataSource = infos.ToArray();
                    break;
                case EListType.Chapter:
                    infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
                            where info.GetType() != typeof(_FestivalInfo)
                            //orderby info.Sort ascending
                            select info;
                    m_BindingSource.DataSource = infos.ToArray();
                    break;
                case EListType.Festival:
                    infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
                            where 1 == 1
                            //orderby info.Sort ascending
                            select info;
                    m_BindingSource.DataSource = null;
                    m_BindingSource.DataSource = infos.ToArray();
                    break;
            }
           // RestXH();
        }


        public void RestXH()
        {
            IEnumerable<_ObjectInfo> infos = null;
            List<_ObjectInfo> infolist = null;
            int m = 1;
            switch (this.m_ListType)
            {
                case EListType.Default:
                    infos = from info in this.DataSource.Cast<_ObjectInfo>()
                            where info is _FFixedListInfo
                            select info;

                    infolist = infos.ToList();
                    break;
                case EListType.Professional:
                    infos = from info in DataSource.Cast<_ObjectInfo>()
                            where SetXH(info, ref m, typeof(_ProfessionalInfo))
                            select info;

                    break;
                case EListType.Chapter:
                    infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
                            where SetXH(info, ref m, typeof(_ChapterInfo))

                            select info;

                    break;
                case EListType.Festival:
                    infos = from info in DataSource.Cast<_ObjectInfo>()
                            where SetXH(info, ref m, typeof(_FestivalInfo))
                            select info;

                    break;
            }
            infos.ToList();

        }
       ///// <summary>
       ///// 重排流水号
       ///// </summary>
       // public void RestLSH()
       // {
       //     IEnumerable<_ObjectInfo> infos = (from n in this.FixedList.Cast<_ObjectInfo>()
       //                                       where 1 == 1
       //                                       select n).Distinct(new QDDistinct());
       //     _ObjectInfo[] arr = infos.ToArray();
       //     foreach (_ObjectInfo item in arr)
       //     {
       //         IEnumerable<_ObjectInfo> info = from n in this.FixedList.Cast<_ObjectInfo>()
       //                                         where n.OLDXMBM == item.OLDXMBM
       //                                           select n;
       //         _ObjectInfo[] arr1 = info.ToArray();
       //         int m =0;
       //         for (int i = 0; i < arr1.Length; i++)
       //         {
       //             m = i + 1;
       //             if (m.ToString().Length == 1)
       //                 arr1[i].XMBM = arr1[i].OLDXMBM + "00"+m.ToString();
       //             else  if (m.ToString().Length == 2)
       //                  arr1[i].XMBM = arr1[i].OLDXMBM + "0" + m.ToString();
       //             else 
       //                 arr1[i].XMBM = arr1[i].OLDXMBM + m.ToString();

       //         }
       //     }
       // }

       /* public void RestXH()
        {
            IEnumerable<_ObjectInfo> infos = null;
            int m = 1;
            switch (this.m_ListType)
            {
                case EListType.Default:
                    infos = from info in this.DataSource.Cast<_ObjectInfo>()
                            where SetXH(info,ref m, typeof(_SubSegments))
                            select info;
                   
                    break;
                case EListType.Professional:
                    infos = from info in DataSource.Cast<_ObjectInfo>()
                                                     where SetXH(info,ref m, typeof(_ProfessionalInfo))
                                                      select info;

                    break;
                case EListType.Chapter:
                    infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
                            where SetXH(info,ref m,typeof(_ChapterInfo))
                             
                            select info;
                  
                    break;
                case EListType.Festival:
                    infos = from info in DataSource.Cast<_ObjectInfo>()
                                                      where SetXH(info,ref m,typeof(_FestivalInfo))
                                                      select info;
                   
                    break;
            }
            infos.ToList();
            
        }*/
        private bool SetXH(_ObjectInfo info,ref int m ,Type type)
        {
            List<_FFixedListInfo> list = null;
            if(info.GetType().Name == type.Name)
            {
                switch (type.Name)
                {
                    case "_ProfessionalInfo":
                        list = (info as _ProfessionalInfo).FixedList;
                        break;
                    case "_ChapterInfo":
                        list = (info as _ChapterInfo).FixedList;
                        break;
                    case "_FestivalInfo":
                        list = (info as _FestivalInfo).FixedList;
                        break;
                    case "_SubSegments":
                        list = (info as _SubSegments).FixedList;
                        break;
                    default:
                        break;
                }
            }
            if (list == null) return true;
            foreach (_ObjectInfo item in list)
            {
                item.XH = m;
                m++;
            }
           return true;
        }

        public void SetXH()
        {
            int i = 0;
            foreach (_ObjectInfo item in this.FixedList)
            {
                i++;
                item.XH = i;
            }
        }
        /// <summary>
        /// 为分部分项创建清单对象
        /// </summary>
        /// <returns>清单对象</returns>
        [ActionAttribute(Command.Create, "清单")]
        public _FixedListInfo Create(_FixedListInfo info)
        {
            _ProfessionalInfo pro = this.Methods.GetproByFixed(info);
            _ChapterInfo cinfo = this.Methods.GetproByFixed(info, pro);
            _FestivalInfo finfo = this.Methods.GetproByFixed(info, cinfo);
            finfo.Create(info);
            this.ActionAttribute("Create", "清单", info,null);
            this.Activitie.BeginEdit(this);
            return info;
        }

        //public long GetSortByType(Type t)
        //{
        //    IEnumerable<_ObjectInfo> infos = from info in m_ObjectsList.Cast<_ObjectInfo>()
        //                                   where info.GetType() == t
        //                                   orderby info.Sort descending
        //                                   select info;
        //   if (infos.Count() > 0) return infos.First().Sort; else { return 0; }
        //}

        public _List SubheadingsList
        {
            get
            {
                _List mSubheadingsList = new _List();
                foreach (_ProfessionalInfo item in ProfessionalList)
                {
                    mSubheadingsList.AddRange(item.SubheadingsList);
                }
                return mSubheadingsList;
            }
        }

        /// <summary>
        /// 为分部分项创建清单对象
        /// </summary>
        /// <returns>清单对象</returns>
        [ActionAttribute(Command.Create, "清单")]
        public _FixedListInfo Create(_FixedListInfo info,_FixedListInfo Index_info)
        {
            _ProfessionalInfo pro = this.Methods.GetproByFixed(info);
            _ChapterInfo cinfo = this.Methods.GetproByFixed(info, pro);
            _FestivalInfo finfo = this.Methods.GetproByFixed(info, cinfo);
            finfo.Create(info,Index_info);
            this.ActionAttribute("Create", "清单", info, Index_info);
            this.Activitie.BeginEdit(this);
            return info;
        }



        public _ProfessionalInfo Create(_ProfessionalInfo info)
        {
            //info.Activitie = this.Activitie;
            info.Parent = this;
            info.ID = this.ObjectID;
            info.PARENTID = this.ID;
            info.PPARENTID = this.ID;
            info.CPARENTID = this.ID;
            info.STATUS = false;
            this.ObjectsList.Add(info);
            info.STATUS = true;
            return info;
        }
        public override _UnitProject Activitie
        {
            get
            {
                return this.Parent;
            }
        }

        /// <summary>
        /// 删除所有清单
        /// </summary>
        public void RemoveAll()
        {

            foreach (_ProfessionalInfo item in this.ProfessionalList)
            {
                Remove(item);
            }
            this.Activitie.BeginEdit(this);
        }
        ///// <summary>
        ///// 删除指定清单
        ///// </summary>
        ///// <param name="info"></param>
        //public void Remove(_FixedListInfo info)
        //{
        //    info.RemoveAll();//先删除清单下面存在的子目
        //    //this.m_FixedList.Remove(info);
        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="info"></param>
        public void Remove(_ProfessionalInfo info)
        {
            foreach (_ChapterInfo item in info.ChapterList)
            {
                info.Remove(item);
            }
            this.ObjectsList.Remove(info);
            this.Activitie.BeginEdit(this);
        }

        /// <summary>
        /// 获取当前(分部分项)下的所有(工料机)
        /// </summary>
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_FixedListInfo info in this.FixedList)
                {
                    list.AddRange(info.GetAllQuantityUnit);
                }
                return list;
            }
        }

        /// <summary>
        /// 获取当前(清单)下的所有(工料机)不包含组成
        /// </summary>
        public _List GetAllQuantityUnitNotZC
        {
            get
            {
                _List list = new _List();
                foreach (_FixedListInfo info in this.FixedList)
                {
                    list.AddRange(info.GetAllQuantityUnitNotZC);
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

        public void Begin()
        {

            this.Statistics.Begin();

            /*if (this.Refesh)
            {
                Refersh(); 
            }*/
        }

        public void Refersh()
        {
            if ( this.DataSource==null)
            {
                return;
            }
            this.DataSource.ResetBindings(false);//分部分项计算完 刷新 
        }
        public override ISubSegment IParent
        {
            get
            {
                return this.Parent.Reveal.ProSubSegment;
            }
        }

        public override void OutSerializable()
        {

        }

        

        /*public override void SetModify(EObjectState p_EObjectState, EDirection p_EDirection)
        {
            //分部分项向下级设置 此处直接设置到清单
            switch(p_EDirection)
            {
                case EDirection.Self:
                    this.UseAttribute = p_EObjectState;
                    break;
                case EDirection.Down:
                    foreach (_FFixedListInfo info in FixedList)
                    {
                        info.SetModify(p_EObjectState, EDirection.Self);
                        info.SetModify(p_EObjectState, p_EDirection);
                    }
                    break;
            }
                
        }*/

        public override void InSerializable(object e)
        {
            this.Statistics = new _SubSegment_Statistics(this);
            //对象默认状态设置为未改变
            foreach (IDataSerializable ids in this.ProfessionalList)
            {
                ids.InSerializable(this);
            }

        }

        /// <summary>
        /// 指定方法被调用需要记录的时候
        /// </summary>
        /// <param name="MethodName">方法名</param>
        /// <param name="p_OtherName">别名</param>
        public  override void ActionAttribute(string MethodName, string p_OtherName, object p_Source,object p_TagValue)
        {
            ///Create方法此处收集
            //if (UseAttribute == EObjectState.Appending)
            {
                //找到指定方法操作属性
                ActionAttribute myAttribute = Command.GetMethodAttribute(this, MethodName, p_OtherName);
                if (myAttribute != null)
                {
                    myAttribute.ObjectName = (p_Source as _ObjectInfo).XMMC;
                    myAttribute.ActingOn = "清单";
                    myAttribute.Source = p_Source;
                    myAttribute.Source = p_TagValue;
                    this.OnModelActioin(this, myAttribute);
                }
            }
        }

        /// <summary>
        /// 开始编辑当前工料机对象
        /// </summary>
        /*public override void BeginModify()
        {
            if (this.UseAttribute == EObjectState.UnChange)
            {
                //通知当前对象改变
                this.SetModify(EObjectState.Modify, EDirection.Self);
            }
        }*/

        /// <summary>
        /// 结束编辑当前工料机对象
        /// </summary>
        /*public override void EndModify()
        {
            if (this.UseAttribute == EObjectState.Modifing || this.UseAttribute == EObjectState.Modify)
            {
                this.SetModify(EObjectState.UnChange, EDirection.Self);
            }
        }*/


    }
}
