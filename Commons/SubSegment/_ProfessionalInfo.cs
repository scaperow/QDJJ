using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ProfessionalInfo:_ObjectInfo
    {
        private _SubSegments m_Parent = null;

        //private _Statistics m_Statistics = null;
        ///// <summary>
        ///// 获取或设置：分部分项计算结果
        ///// </summary>
        //public _Statistics Statistics
        //{
        //    get { return m_Statistics; }
        //    set { m_Statistics = value; }
        //}
        public _SubSegments Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }
        public _List SubheadingsList
        {
            get
            {
                _List mSubheadingsList = new _List();
                foreach (_ChapterInfo item in ChapterList)
                {
                    mSubheadingsList.AddRange(item.SubheadingsList);
                }
                return mSubheadingsList;
            }
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.Activitie;
            }
        }
        public _ProfessionalInfo(_SubSegments p_Parent)
        {

            this.m_Parent = p_Parent;
            this.Statistics = new _ProfessionalInfo_Statistics(this);
            m_ChapterList = new List<_ChapterInfo>();
            m_FixedList = new List<_FFixedListInfo>();
        }


        /// 获取或设置当前章集合
        /// </summary>
        [NonSerialized]
        private List<_ChapterInfo> m_ChapterList = null;

        /// <summary>
        /// 获取或设置当前章集合
        /// </summary>
        public List<_ChapterInfo> ChapterList
        {
            get
            {
                IEnumerable<_ChapterInfo> infos = from info in this.Parent.ObjectsList.Cast<_ObjectInfo>()
                                                  where info.GetType() == typeof(_ChapterInfo) && info.PARENTID == this.ID
                                                  select info as _ChapterInfo;

                m_ChapterList = infos.ToList();
                return this.m_ChapterList;
            }
            set
            {
                this.m_ChapterList = value;
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
                IEnumerable<_FFixedListInfo> infos = from info in this.Parent.ObjectsList.Cast<_ObjectInfo>()
                                                     where info.GetType() == typeof(_FFixedListInfo) && info.PPARENTID==this.ID
                                                     select info as _FFixedListInfo;

                m_FixedList = infos.ToList();
                return this.m_FixedList;
            }
            set
            {
                this.m_FixedList = value;
            }
        }
        public _ChapterInfo Create( _ChapterInfo info)
        {
            //info.Activitie = this.Activitie;
            info.Parent = this;
            info.ID = this.Parent.ObjectID;
            info.PARENTID = this.ID;
            info.CPARENTID = this.ID;
            info.STATUS = false;
            this.Parent.ObjectsList.Add(info);
            info.STATUS = true;
            this.Activitie.BeginEdit(this);
            return info;
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
        public void Remove(_ChapterInfo info)
        {
            _FestivalInfo[] infos = info.FestivalList.Cast<_FestivalInfo>().ToArray();
            foreach (_FestivalInfo item in infos)
            {
                info.Remove(item);
            }
            this.Parent.ObjectsList.Remove(info);
            this.Activitie.BeginEdit(this);
        }
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_ChapterInfo info in this.ChapterList)
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
                foreach (_ChapterInfo info in this.ChapterList)
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
                return this.Parent.Parent.Reveal.ProSubSegment.Key;
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
                return this.Parent.Parent.Reveal.ProSubSegment.ProName ;
            }
            set { }
        }

        public override ISubSegment IParent
        {
            get
            {
                return this.Parent.Parent.Reveal.ProSubSegment;
            }
        }

        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            this.Statistics = new _ProfessionalInfo_Statistics(this);            
            foreach (IDataSerializable ids in this.ChapterList)
            {
                ids.InSerializable(this);
            }

        }
    }
}
