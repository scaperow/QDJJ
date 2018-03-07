using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**通用项目***/
namespace GOLDSOFT.QDJJ.COMMONS
{

    /// <summary>
    /// 通用项目
    /// </summary>
    [Serializable]
    public class _CommonrojectInfo : _ObjectInfo
    {
        private _MeasuresProject m_Parent = null;
        /// <summary>
        /// 父类对象（措施项目）
        /// </summary>
        public _MeasuresProject Parent
        {
            get
            {
                return this.m_Parent;
            }
            set { m_Parent = value; }
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.Activitie;
            }
        }
        public _List SubheadingsList
        {
            get
            {
                _List mSubheadingsList = new _List();
                foreach (_FixedListInfo item in MFixedList)
                {
                    mSubheadingsList.AddRange(item.SubheadingsList);
                }
                return mSubheadingsList;
            }
        }
        /// <summary>
        /// 当前通用项目下的清单集合
        /// </summary>
        public List<_MFixedListInfo> MFixedList
        {
            get
            {
                List<_MFixedListInfo> list = new List<_MFixedListInfo>();
                IEnumerable<_ObjectInfo> infos = from info in this.Parent.ObjectsList.Cast<_ObjectInfo>()
                                                 where info.PARENTID == this.ID
                                                 select info;
                list = infos.Cast<_MFixedListInfo>().ToList();
                return list;

            }

        }
        public _CommonrojectInfo(_MeasuresProject p_Parent)
        {
            this.GCL = 0.0m;
            this.m_Parent = p_Parent;
            this.Statistics = new _CommonrojectInfo_Statistics(this);
        }
        public _CommonrojectInfo()
        {
            this.GCL = 0.0m;
            this.Statistics = new _CommonrojectInfo_Statistics(this);
        }
      






        /// <summary>
        /// 通用项目创建清单
        /// </summary>
        /// <param name="info"></param>
        public void Create(_FixedListInfo info)
        {
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            // info.IsCalc = true;
            info.ID = this.m_Parent.ObjectID;
            info.PARENTID = this.ID;
            (info as _MFixedListInfo).Parent = this;
            info.STATUS = true;

            info.ZJFS = _Constant.子目组价;
            if (!string.IsNullOrEmpty(info.JSJC))
            {
                info.ZJFS = _Constant.公式组价;
            }


            if (info.XMBM != "" && info.BEIZHU == "")
            {
                if (!string.IsNullOrEmpty(info.OLDXMBM))
                {
                    info.BEIZHU = info.OLDXMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    info.BEIZHU = info.XMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }

            this.Parent.ObjectsList.Add(info);
            int i = 1;
            foreach (_ObjectInfo item in this.Activitie.Property.MeasuresProject.ObjectsList)
            {
                if (item as _FixedListInfo != null)
                {
                    item.XH = i;
                    i++;
                }
            }
        }


        /// <summary>
        /// 通用项目创建清单
        /// </summary>
        /// <param name="info"></param>
        public void CreateByXml(_FixedListInfo info)
        {
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            // info.IsCalc = true;
            info.ID = this.m_Parent.ObjectID;
            info.PARENTID = this.ID;
            (info as _MFixedListInfo).Parent = this;
            info.STATUS = true;

            info.ZJFS = _Constant.子目组价;
            if (!string.IsNullOrEmpty(info.JSJC))
            {
                info.ZJFS = _Constant.公式组价;
            }


            if (info.XMBM != "" && info.BEIZHU == "")
            {
                if (!string.IsNullOrEmpty(info.OLDXMBM))
                {
                    info.BEIZHU = info.OLDXMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    info.BEIZHU = info.XMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }

            this.Parent.ObjectsList.Add(info);
            
        }
        /// <summary>
        /// 通用项目创建清单
        /// </summary>
        /// <param name="info"></param>
        public void Create(_FixedListInfo info, _FixedListInfo index_info)
        {
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            // info.IsCalc = true;
            info.ID = this.m_Parent.ObjectID;
            info.PARENTID = this.ID;
            (info as _MFixedListInfo).Parent = this;
            info.STATUS = true;

            info.ZJFS = _Constant.子目组价;
            if (!string.IsNullOrEmpty(info.JSJC))
            {
                info.ZJFS = _Constant.公式组价;
            }

            if (info.XMBM != "" && info.BEIZHU == "")
            {
                if (!string.IsNullOrEmpty(info.OLDXMBM))
                {
                    info.BEIZHU = info.OLDXMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    info.BEIZHU = info.XMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }

            this.Parent.ObjectsList.Insert(info, index_info);
            int i = 1;
            foreach (_ObjectInfo item in this.Activitie.Property.MeasuresProject.ObjectsList)
            {
                if (item as _FixedListInfo != null)
                {
                    item.XH = i;
                    i++;
                }
            }
        }

        /// <summary>
        /// 通用项目删除清单
        /// </summary>
        /// <param name="info"></param>
        public void Del(_MFixedListInfo info)
        {

            _SubheadingsInfo[] infos = info.SubheadingsList.Cast<_SubheadingsInfo>().ToArray();
            foreach (_SubheadingsInfo item in infos)
            {
                info.Remove(item);
               // this.Parent.ObjectsList.Remove(item);
            }
            this.Parent.ObjectsList.Remove(info);
        }

        /// <summary>
        /// 开始计算
        /// </summary>
        public void Begin()
        {

            this.Statistics.Begin();
            this.Parent.Begin();
        }
        public _List GetAllQuantityUnitNotZC
        {
            get
            {
                _List list = new _List();
                foreach (_MFixedListInfo info in this.MFixedList)
                {
                    list.AddRange(info.GetAllQuantityUnitNotZC);
                }
                return list;
            }
        }
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_MFixedListInfo info in this.MFixedList)
                {
                    // list.Add(info);
                    list.AddRange(info.GetAllQuantityUnit);
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
                return this.Parent.Parent.Reveal.ProMeasures.Key;
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
        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            this.Statistics = new _CommonrojectInfo_Statistics(this);
            foreach (IDataSerializable ids in this.MFixedList)
            {
                ids.InSerializable(this);
            }

        }


    }
}
