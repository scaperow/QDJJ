/*
   清单实体对象
 * 包含1.当前清单下的所有子目对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 清单实体对象
    /// </summary>
    [Serializable]
    public class _FixedListInfo : _ObjectInfo
    {

        public _FestivalInfo Parent
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
        public delegate void ZiMuAdd(_ObjectInfo info);
        /// <summary>
        /// 子目添加完成事件
        /// </summary>
        /// 
        private _FestivalInfo m_Parent = null;
        [field: NonSerializedAttribute()]
        public event ZiMuAdd OnZiMuAdded;
   
        //public _FixedListInfo(_FestivalInfo p_Parent)
        //{
        //    this.m_Parent = p_Parent;
        //    this.m_InventoryQuantityUnitSummary = new _List();
        //    this.m_SubheadingsList = new _SubheadingsList(this);
        //    this.m_Statistics = new _FixedList_Statistics(this);

        //}
        public _FixedListInfo()
        {
            this.m_SubheadingsList = new _SubheadingsList(this);
            this.Statistics = new _FixedList_Statistics(this);

        }

        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            if (this is _MFixedListInfo)
            {
                this.Statistics = new _MFixedList_Statistics(this);
            }
            else
            {
                this.Statistics = new _FixedList_Statistics(this);
            }
            
            foreach (IDataSerializable ids in this.SubheadingsList)
            {
                ids.InSerializable(this);
            }

        }

        /// <summary>
        /// 当前清单下所有子目的对象
        /// </summary>
        private _SubheadingsList m_SubheadingsList = null;

        /// <summary>
        /// 获取或设置当前清单下的所有子目集
        /// </summary>
        public _SubheadingsList SubheadingsList
        {
            get { return this.m_SubheadingsList; }
            set { this.m_SubheadingsList = value; }
        }


      
        /// <summary>
        /// 清创建子目
        /// </summary>
        /// <returns>子目对象</returns>
        public _SubheadingsInfo Create()
        {
            _SubheadingsInfo info = new _SubheadingsInfo();
            info.Parent = this;
            info.STATUS = false;
            info.IsCalc = true;
            info.PARENTID = this.ID;
            info.CPARENTID = this.ID;
            info.FPARENTID = this.ID;
            info.PPARENTID = this.ID;

            info.Create();
            this.m_SubheadingsList.Add(info);
            info.STATUS = false;
            info.Subheadings_Statistics.Begin();
            this.Activitie.BeginEdit(this);
            return info;
        }

        /// <summary>
        /// xml创建使用
        /// </summary>
        /// <param name="info"></param>
        public virtual void CreateByXml(_SubheadingsInfo info)
        {

            //info.Activitie = this.Activitie;
            info.STATUS = false;
            info.IsCalc = true;
            //info.ID = this.m_Parent.ObjectID;
            info.PARENTID = this.ID;
            info.CPARENTID = this.ID;
            info.FPARENTID = this.ID;
            info.PPARENTID = this.ID;

            this.m_SubheadingsList.Add(info);

            info.Create();
            if (info.LB == "子目")
            {
                //info.Subheadings_Statistics.Begin();
                //子目添加完成执行的事件
                if (info.IsHs)
                {
                    if (OnZiMuAdded != null)
                    {
                        OnZiMuAdded(info);
                    }
                }

            }
            else
            {
                // info.Begin();
                // this.Parent.DataSource.ResetBindings(false);
            }

            info.STATUS = true;
        }
        /// <summary>
        /// 删除增加费
        /// </summary>
        public virtual void RemoveIncrease()
        {
           
        }

        public int GCLSR()
        { 
            int flag = 0;
                if (this.Activitie != null)
                {
                    if (this.Activitie.Application != null)
                    {
                        flag = ToolKit.ParseInt(this.Activitie.Application.Global.Configuration.Configs["工程量输入方式"]);
                    }
                }
                return flag;
        }
        /// <summary>
        /// 清创建子目
        /// </summary>
        /// <returns>子目对象</returns>
        [ActionAttribute(Command.Create,"子目")]
        public virtual void Create(_SubheadingsInfo info)
        {
            //info.Activitie = this.Activitie;
            info.STATUS = false;
            info.IsCalc = true;
                //info.ID = this.m_Parent.ObjectID;
            info.PARENTID = this.ID;
            info.CPARENTID = this.ID;
            info.FPARENTID = this.ID;
            info.PPARENTID = this.ID;
            int m = GCLSR();
            if (m>0)
            {
                decimal d = _ConvertUnit.Convert(this.DW, info.DW);
                info.HL = d;
            }
           
            //info.Sort = this.Activitie.Property.SubSegments.GetSortByType(info.GetType()) + 1;
            this.m_SubheadingsList.Add(info);
           
                info.Create();
                if (info.LB == "子目")
                {
                    info.Subheadings_Statistics.Begin();
                    //子目添加完成执行的事件
                    if (info.IsHs)
                    {
                        this.OnZiMuAddEvent(info);
                    }

                }
                else
                {
                   info.Begin();
                    // this.Parent.DataSource.ResetBindings(false);
                }
            
                info.STATUS = true;
                this.ActionAttribute("Create", "子目", info, null);
                this.Activitie.BeginEdit(this);

        }

        public virtual void OnZiMuAddEvent(_SubheadingsInfo info)
        {
           
            if (OnZiMuAdded != null)
            {
                OnZiMuAdded(info);
            }
        }
        public virtual void RemoveOnZiMuAddEvent()
        {
            OnZiMuAdded = null;
        }
        public virtual void Create(string m_DEH, int d)
        {
            DataRow[] rows = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy().Select(string.Format("DINGEH='{0}'", m_DEH));
            if (rows.Length > 0)
            {
                _SubheadingsInfo sinfo = new _FSubheadingsInfo();
                this.Activitie.Property.SubSegments.Methods.SetSubheadingsInfo(sinfo, rows[0], this.Activitie.Property.Libraries.FixedLibrary.FullName);
                //view1.BEIZHU = (view1 as _SubheadingsInfo).Parent.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
                sinfo.XMBM += " *" + d + "";
                this.Create(sinfo);
                
            }
        }

        /// <summary>
        /// 清创建子目
        /// </summary>
        /// <returns>子目对象</returns>
        public virtual void Create(_SubheadingsInfo info,_SubheadingsInfo Index_info)
        {

        }



        /// <summary>
        /// 删除所有子目
        /// </summary>
        public void RemoveAll()
        {
            object[] infos = (object[])this.m_SubheadingsList.ToArray();
            foreach (_SubheadingsInfo item in infos)
            {
                this.Remove(item);
            }
            this.Activitie.BeginEdit(this);
        }
        /// <summary>
        /// 删除指定子目
        /// </summary>
        /// <param name="info"></param>
        public virtual void Remove(_SubheadingsInfo info)
        {

            this.m_SubheadingsList.Remove(info);
            this.Activitie.BeginEdit(this);
           // this.Parent.Parent.Parent.Parent.ObjectsList.Remove(info);
        }


        public override int ID
        {
            get { return base.ID; }
            set
            {

                base.ID = value;
                this.m_SubheadingsList.UpDateParentID();
            }
        }

        public override decimal GCL
        {
            get { return base.GCL; }
            set
            {

                base.GCL = value;
                if (this.STATUS)
                {
                    if (!this.SDQD)
                    {
                        bool flag = true;
                        if (this.Activitie != null)
                        {
                            if (this.Activitie.Application != null)
                            {
                                flag = ToolKit.ParseBoolen(this.Activitie.Application.Global.Configuration.Configs["清单工程量设置"]);
                            }
                        }
                        if (this.ISXSHS && flag)
                        this.m_SubheadingsList.UpDateGCL();
                    }
                }
                this.Begin();
            }
        }
        /// <summary>
        /// 不创建子目
        /// </summary>
        /// <param name="value"></param>
        public void SetGCL1(decimal value)
        {
            bool flag = true;
            if (this.Activitie != null)
            {
                if (this.Activitie.Application != null)
                {
                    flag = ToolKit.ParseBoolen(this.Activitie.Application.Global.Configuration.Configs["清单工程量设置"]);
                }
            }
            base.GCL = value;
            if (this.STATUS)
            {
                if (!this.SDQD)
                {
                    if (this.ISXSHS && flag)
                        this.m_SubheadingsList.UpDateGCL();
                }

            }
            this.Begin();
        }
        /// <summary>
        /// 若不触发默认工程量所做的事则调用此方法
        /// </summary>
        public void SetGCL(decimal value)
        {
            base.GCL = value;
        }
        public override decimal ZJTJ
        {
            get { return base.ZJTJ; }
            set
            {
                //base.ZJTJ = value;
                //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
                if (this.STATUS)
                {
                    UpXHL(value);
                }
            }
        }
      
        /// <summary>
        /// 是否分包
        /// </summary>
        public override bool SFFB
        {
            get { return base.SFFB; }
            set
            {
                base.SFFB = value;
                this.Begin();
            }
        }
        /// <summary>
        /// 修改工料机的消耗量
        /// </summary>
        /// <param name="value"></param>
        private void UpXHL(decimal value)
        {
            decimal zhdj = this.ZHDJ;
            if (zhdj == 0)
            {
                zhdj = 1;
            }
            decimal c = value / zhdj;
            _List t = GetAllQuantityUnitNotZC;
            UpChildIsCalc(false);
            foreach (_ObjectQuantityUnitInfo item in t)
            {
                if(!item.LB.Contains('%'))
                item.XHL = item.XHL * c;
            }
            UpChildIsCalc(true);
            //int m = GetInventoryQuantityUnitSummary.Count;
        }

        private void UpChildIsCalc(bool p)
        {
            foreach (_SubheadingsInfo item in this.SubheadingsList)
            {
                item.IsCalc = p;
            }
            if (p)
            {
                foreach (_SubheadingsInfo item in this.SubheadingsList)
                {
                    item.Subheadings_Statistics.Begin();
                }
            }
        }

        /// <summary>
        /// 获取当前(清单)下的所有(工料机)
        /// </summary>
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_SubheadingsInfo info in this.SubheadingsList)
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
                foreach (_SubheadingsInfo info in this.SubheadingsList)
                {
                    list.AddRange(info.GetAllQuantityUnitNotZC);
                }
                return list;
            }
        }

        /// <summary>
        /// 状态：是否产生过变更 true=是、 false = 否
        /// </summary>
        private bool m_IFChange;

        /// <summary>
        /// 状态：是否产生过变更 true=是、 false = 否
        /// </summary>
        public bool IFChange
        {
            get { return m_IFChange; }
            set { m_IFChange = value; }
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

        
        /// <summary>
        /// 清单下面的增加费
        /// </summary>
        public _List IncreaseCostsList
        {
            get
            {

                _List list = new _List();
                IEnumerable<_SubheadingsInfo> infos = from n in this.SubheadingsList.Cast<_SubheadingsInfo>()
                                                      where n.LB == "子目-增加费"
                                                      select n;
                list.AddRange(infos.ToArray());
                return list;


            }

        }
        /// <summary>
        /// 开始计算
        /// </summary>
        public virtual void Begin()
        {
            this.Statistics.Begin();
            if (this.Parent!=null)
            {
                this.Parent.Begin();
            }
           
        }
        public virtual void Del(_SubheadingsInfo info)
        { 
            
        }

        /// <summary>
        /// 直接通知分部分项修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnModelEdited(object sender, object args)
        {
            base.OnModelEdited(sender, args);
            this.Activitie.Property.SubSegments.OnModelEdited(sender, args);
        }

        /// <summary>
        /// 直接通知分部分项动作操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnModelActioin(object sender, object args)
        {
            base.OnModelActioin(sender, args);
            this.Activitie.Property.SubSegments.OnModelActioin(sender, args);
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



        /// <summary>
        /// 设置修改状态
        /// </summary>
        /// <param name="p_EObjectState"></param>
        /// <param name="p_EDirection"></param>
        /*public override void SetModify(EObjectState p_EObjectState, EDirection p_EDirection)
        {
            switch (p_EDirection)
            {
                case EDirection.Self://仅自己
                    this.UseAttribute = p_EObjectState;
                    break;
                case EDirection.UP://向上寻址
                    this.Activitie.Property.SubSegments.SetModify(p_EObjectState, EDirection.Self);
                    this.Activitie.Property.SubSegments.SetModify(p_EObjectState, EDirection.UP);
                    break;
                case EDirection.Down://向下寻址设置
                    foreach (_SubheadingsInfo info in m_SubheadingsList)
                    {
                        (info as _SubheadingsInfo).SetModify(p_EObjectState, EDirection.Self);
                        (info as _SubheadingsInfo).SetModify(p_EObjectState, EDirection.Down);
                    }
                    break;
                case EDirection.TwoWay://双向
                    this.SetModify(p_EObjectState, EDirection.UP);
                    this.SetModify(p_EObjectState, EDirection.Down);
                    break;
            }
        }*/

        /// <summary>
        /// 指定方法被调用需要记录的时候
        /// </summary>
        /// <param name="MethodName">方法名</param>
        /// <param name="p_OtherName">别名</param>
        public override void ActionAttribute(string MethodName, string p_OtherName, object p_Source, object p_TagValue)
        {
            ///Create方法此处收集
            //if (UseAttribute == EObjectState.Appending)
            {
                //找到指定方法操作属性
                ActionAttribute myAttribute = Command.GetMethodAttribute(this, MethodName, p_OtherName);
                if (myAttribute != null)
                {
                    myAttribute.ObjectName = (p_Source as _ObjectInfo).XMMC;
                    myAttribute.ActingOn = "清单.子目";
                    myAttribute.Source = p_Source;
                    myAttribute.TagValue = p_TagValue;
                    this.OnModelActioin(this, myAttribute);
                }
            }
        }
    }
}
