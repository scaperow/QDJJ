using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{

    /// <summary>
    /// 节的对象
    /// </summary>
    /// 
    [Serializable]
   public  class _FestivalInfo:_ObjectInfo
    {
       public override string ToString()
       {
           return this.XMMC;
       }

         private _ChapterInfo m_Parent = null;
          public _ChapterInfo Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
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
          public override _UnitProject Activitie
          {
              get
              {
                  if (this.Parent == null) return null;
                  return this.Parent.Activitie;
              }
          }
          public _FestivalInfo(_ChapterInfo p_Parent)
        {

            this.m_Parent = p_Parent;
            this.Statistics = new _FestivalInfo_Statistics(this);
            m_FixedList = new List<_FFixedListInfo>();
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
                  IEnumerable<_FFixedListInfo> infos = from info in this.Parent.Parent.Parent.ObjectsList.Cast<_ObjectInfo>()
                                                       where info.GetType() == typeof(_FFixedListInfo) && info.PARENTID == this.ID
                                                       select info as _FFixedListInfo;

                  m_FixedList = infos.ToList();
                  return this.m_FixedList;
              }
              set
              {
                  this.m_FixedList = value;
              }
          }
          public _List SubheadingsList
          {
              get 
              {
                  _List mSubheadingsList = new _List();
                  foreach (_FixedListInfo item in FixedList)
                  {
                      mSubheadingsList.AddRange(item.SubheadingsList);
                  }
                  return mSubheadingsList;
              }
          }
        public _FixedListInfo Create(_FixedListInfo info)
        {
            info.Parent = this;
            info.ID = this.Parent.Parent.Parent.ObjectID;
            info.FPARENTID = this.Parent.Parent.Parent.ID;
            info.PPARENTID = this.Parent.Parent.ID;
            info.CPARENTID = this.Parent.ID;
            info.PARENTID = this.ID;
            info.STATUS = false;
            //info.Sort = this.Activitie.Property.SubSegments.GetSortByType(info.GetType()) + 1;
            this.Parent.Parent.Parent.ObjectsList.Add(info);
            info.STATUS = true;
            //int i = 1;
            //foreach (_ObjectInfo item in this.Activitie.Property.SubSegments.ObjectsList)
            //{
            //    if (item as _FixedListInfo!=null)
            //    {
            //        item.XH = i;
            //        i++;
            //    }
            //}
            this.Activitie.BeginEdit(this);
            return info;
           
        }

        public _FixedListInfo Create(_FixedListInfo info,_FixedListInfo Index_info)
        {
            info.Parent = this;
            info.ID = this.Parent.Parent.Parent.ObjectID;
            info.FPARENTID = this.Parent.Parent.Parent.ID;
            info.PPARENTID = this.Parent.Parent.ID;
            info.CPARENTID = this.Parent.ID;
            info.PARENTID = this.ID;
            info.STATUS = false;

           // info.Sort = Index_info.Sort;
            //this.UpDateSort(info.Sort);
            //更新  Index_info.Sort以后的 sort


            this.Parent.Parent.Parent.ObjectsList.Insert(info,Index_info);
            info.STATUS = true;
            //int i = 1;
            //foreach (_ObjectInfo item in this.Activitie.Property.SubSegments.ObjectsList)
            //{
            //    if (item as _FixedListInfo!=null)
            //    {
            //        item.XH = i;
            //        i++;
            //    }
            //}
            this.Activitie.BeginEdit(this);
            return info;

        }
        //private void UpDateSort(long m)
        //{
        //    _ObjectInfo[] infos=(from n in this.FixedList.Cast<_ObjectInfo>()
        //                        where n.Sort>=m orderby n.Sort ascending select n).ToArray(); 
        //    foreach (_FixedListInfo item in infos)
        //    {
        //        item.Sort = item.Sort + 1;
        //    }
        //}

        public  void Begin()
        {
            this.Statistics.Begin();
            this.Parent.Begin();
        }

        /// <summary>
        /// 删除清单
        /// </summary>
        /// <param name="info"></param>
        public void Remove(_FixedListInfo info)
        {
            _SubheadingsInfo[] infos = info.SubheadingsList.Cast<_SubheadingsInfo>().ToArray();
            foreach (_SubheadingsInfo item in infos)
            {
                info.Remove(item);
            }
            this.Parent.Parent.Parent.ObjectsList.Remove(info);
            this.Activitie.BeginEdit(this);
        }
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
            this.Statistics = new _FestivalInfo_Statistics(this);
            foreach (IDataSerializable ids in this.FixedList)
            {
                ids.InSerializable(this);
            }

        }
    }
}
