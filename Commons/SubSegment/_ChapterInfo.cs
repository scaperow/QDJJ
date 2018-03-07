using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 章的对象
    /// </summary>
    /// 
    [Serializable]
    public class _ChapterInfo : _ObjectInfo
    {

        public override string ToString()
        {
            return this.XMMC;
        }
        private _ProfessionalInfo m_Parent = null;
          public _ProfessionalInfo Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }
          public _List SubheadingsList
          {
              get
              {
                  _List mSubheadingsList = new _List();
                  foreach (_FestivalInfo item in FestivalList)
                  {
                      mSubheadingsList.AddRange(item.SubheadingsList);
                  }
                  return mSubheadingsList;
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
          public _ChapterInfo(_ProfessionalInfo p_Parent)
        {

            this.m_Parent = p_Parent;
            this.m_FixedList = new List<_FFixedListInfo>();
            this.m_FestivalList = new List<_FestivalInfo>();
            this.Statistics = new _ChapterInfo_Statistics(this);

        }

          /// 获取或设置当前节类
          /// </summary>
          [NonSerialized]
          private List<_FestivalInfo> m_FestivalList = null;

          /// <summary>
          /// 获取或设置当前节类
          /// </summary>
          public List<_FestivalInfo> FestivalList
          {
              get
              {
                  IEnumerable<_FestivalInfo> infos = from info in this.Parent.Parent.ObjectsList.Cast<_ObjectInfo>()
                                                     where info.GetType() == typeof(_FestivalInfo) && info.PARENTID == this.ID
                                                     select info as _FestivalInfo;

                  m_FestivalList = infos.ToList();
                  return this.m_FestivalList;
              }
              set
              {
                  this.m_FestivalList = value;
              }
          }

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
                  IEnumerable<_FFixedListInfo> infos = from info in this.Parent.Parent.ObjectsList.Cast<_ObjectInfo>()
                                                       where info.GetType() == typeof(_FFixedListInfo) && info.CPARENTID == this.ID
                                                       select info as _FFixedListInfo;

                  m_FixedList = infos.ToList();
                  return this.m_FixedList;
              }
              set
              {
                  this.m_FixedList = value;
              }
          }
        public _FestivalInfo Create(_FestivalInfo info)
        {
            //info.Activitie = this.Activitie;
            info.Parent = this;
            info.ID = this.Parent.Parent.ObjectID;
            info.PARENTID = this.ID;
            info.CPARENTID = this.ID;
            info.STATUS = false;
            this.Parent.Parent.ObjectsList.Add(info);
            info.STATUS = true;
            this.Activitie.BeginEdit(this);
            return info;
           
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.Activitie;
            }
        }
        public void Begin()
        {
            this.Statistics.Begin();
            this.Parent.Begin();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="info"></param>
        public void Remove(_FestivalInfo info)
        {
            _FixedListInfo[] infos = info.FixedList.Cast<_FixedListInfo>().ToArray();
            foreach (_FixedListInfo item in infos)
            {
                info.Remove(item);
            }
            this.Parent.Parent.ObjectsList.Remove(info);
            this.Activitie.BeginEdit(this);
        }
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_FestivalInfo info in this.FestivalList)
                {
                    list.AddRange(info.GetAllQuantityUnit);
                }
                return list;
            }
        }
        public _List GetAllQuantityUnitNotZC
        {
            get
            {
                _List list = new _List();
                foreach (_FestivalInfo info in this.FestivalList)
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
        /*public override long PKey
        {
            get
            {
                return this.Parent.Key;
            }
            set
            {
                //this.m_PKey = value;
            }
        }*/

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


        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            this.Statistics = new _ChapterInfo_Statistics(this);
            foreach (IDataSerializable ids in this.FestivalList)
            {
                ids.InSerializable(this);
            }

        }
    }
}
