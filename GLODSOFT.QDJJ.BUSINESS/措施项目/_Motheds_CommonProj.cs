using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Motheds_CommonProj : _Methods
    {
        public _Motheds_CommonProj(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base( m_Currentbus,p_Unit, p_info)
        {

        }
        public override _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info)
        {

            info.PID = this.Current.ID;
            info.STATUS = false;
            info.EnID = this.Current.EnID;
            info.UnID = this.Current.UnID;
            info.SSLB = this.Current.SSLB;
            info.Deep = this.Current.Deep + 1;
            this.SetSort(p_Sort, info);
            info.Key = ++this.CurrentBusiness.Current.ObjectKey;
            info.PKey = this.Current.Key;
            info.GCL = 1;
            this.Unit.StructSource.ModelMeasures.Add(info);
            SetXH();
            return info;
        }
        public void SetXH()
        {
            DataRow[] ros1 = this.Unit.StructSource.ModelMeasures.Select("PID=0", "Sort asc");
            if (ros1.Length > 0)
            {
                DataRow[] ros = this.Unit.StructSource.ModelMeasures.Select(string.Format("PID={0}", ros1[0]["ID"]), "Sort asc");

                int m = 0;
                for (int i = 0; i < ros.Length; i++)
                {
                    DataRow[] rows = this.Unit.StructSource.ModelMeasures.Select(string.Format("PID={0}", ros[i]["ID"]), "Sort asc");
                    for (int j = 0; j < rows.Length; j++)
                    {
                        m++;
                        rows[j]["XH"] = m;
                    }
                }
            }
        }

        public override _Entity_SubInfo Create()
        {
            return base.Create();
        }
        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
           
            foreach (DataRow item in rows)
            { _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Mothods_MFixed met = new _Mothods_MFixed(this.CurrentBusiness, this.Unit, info);
                met.Calculate();
            }
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
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
            //计算子目所属章
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelMeasures.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Mothod_Measures(this.CurrentBusiness,this.Unit, info);
            met.Begin(session);
        }
        public override void BeginCurrent()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
            _Entity_SubInfo info = new _Entity_SubInfo();
            foreach (DataRow item in rows)
            {
                _ObjectSource.GetObject(info, item);
                _Mothods_MFixed met = new _Mothods_MFixed(this.CurrentBusiness, this.Unit, info);
                met.Calculate();
            }
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
        }

    }
}
