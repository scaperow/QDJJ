using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 专业处理类
    /// </summary>
    /// <param name="p_Unit"></param>
    class _Methods_Pro:_Methods
    {

        public _Methods_Pro(_UnitProject p_Unit)
            : base(p_Unit)
        { 
            
        }

        public _Methods_Pro(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base(m_Currentbus,p_Unit, p_info)
        {

        }
        public override void RemoveAllChild()
        {
            base.RemoveAllChild();
        }
        public override void RemoveChild(_Entity_SubInfo info)
        {
            base.RemoveChild(info);
        }
        public override void Begin(List<int> session)
        {
            if (session != null)
            {
                if (session.Contains(Current.ID))
                {
                    return;
                }
                else
                {
                    session.Add(Current.ID);
                }
            }


            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;

            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();

            //计算子目所属分部
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther("1");
            _ObjectSource.GetObject(info, row);
            met = new _Method_Sub(this.CurrentBusiness,this.Unit, info);
            met.Begin(session);
        }

        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
            
            foreach (DataRow item in rows)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Method_Chapt met = new _Method_Chapt(this.CurrentBusiness, this.Unit, info);
                met.Calculate();
            }
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
        }

        public override void BeginCurrent()
        {
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
        }
        
    }
}
