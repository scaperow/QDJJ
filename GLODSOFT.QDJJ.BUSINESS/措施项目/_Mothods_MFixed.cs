using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Mothods_MFixed:_Methods_Fixed
    {
        public _Mothods_MFixed(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base(m_Currentbus,p_Unit, p_info)
        {

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

            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin(this.Unit.StructSource.ModelMeasures.Select("PID = " + this.Current.ID));

            //计算子目所属节
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelMeasures.GetRowByOther(this.Current.PID.ToString());
            if (row == null) return;
            _ObjectSource.GetObject(info, row);
            met = new _Motheds_CommonProj(this.CurrentBusiness, this.Unit, info);
            met.Begin(session);
        }
        public override void Create(List<_Entity_SubInfo> infos)
        {
            foreach (_Entity_SubInfo item in infos)
            {
                this.Create(-1, item);
            }
            this.Begin(null);
        }
        public override _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info)
        {
            info.PID = this.Current.ID;
            info.SSLB = 1;
            info.EnID = this.Current.EnID;
            info.UnID = this.Current.UnID;
            info.Deep = 6;//子目深度为6
            this.SetSort(p_Sort, info);
            info.Key = ++this.CurrentBusiness.Current.ObjectKey;
            info.PKey = this.Current.Key;
            this.Unit.StructSource.ModelMeasures.Add(info);
            //创建子目参数表
            this.Unit.StructSource.ModelVariable.Init_ZM(info.ID, 1);
            //添加工料机
            _Mothods_MSubheadings mSub = new _Mothods_MSubheadings(this.CurrentBusiness,this.Unit, info);
            mSub.Create();
            mSub.Begin(null);//子目计算
            return info;
        }
       
        public override void UpGCL()
        {
            bool flag = ToolKit.ParseBoolen(APP.Application.Global.Configuration.Configs["清单工程量设置"]);
            if (flag)
            {
                DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0} and SSLB={1}", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
                _Mothods_MSubheadings met = new _Mothods_MSubheadings(this.CurrentBusiness, this.Unit, null);
                foreach (DataRow row in rows)
                {
                    row["GCL"] = (ToolKit.ParseDecimal(row["HL"]) * this.Current.GCL).ToString("F4");
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, row);
                    met.Current = info;
                    met.UpZMGLJGCL();
                    met.BeginCurrent();//计算子目当前数据
                }
            }
            this.Begin(null);
        }
        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
            foreach (DataRow item in rows)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Mothods_MSubheadings met = new _Mothods_MSubheadings(this.CurrentBusiness, this.Unit, info);
                met.Calculate();
            }
            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin(GetDataSource.Select("PID = '" + Current.ID + "'"));
        }
        public override void BeginCurrent()
        {
            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin(GetDataSource.Select("PID = '" + Current.ID + "' AND LB <> '子目-增加费'"));

            if (BeginExtension())
            {
                sta.Begin(GetDataSource.Select("PID = '" + Current.ID + "'"));
            }
        }

        public bool BeginExtension()
        {
            //计算子目增加费
            var rows = this.GetDataSource.Select("LB = '子目-增加费' AND PID = '+" + Current.ID + "'");
            foreach (var row in rows)
            {
                var entity = _Entity_SubInfo.Parse(row);
                var increaseRows = this.Unit.StructSource.ModelIncreaseCosts.Select("DH = '" + row["XMBM"] + "' AND QDID = '" + Current.ID + "'");

                if (increaseRows != null && increaseRows.Length > 0)
                {
                    var increaseRow = increaseRows[0];
                    var increase = new _Entity_IncreaseCosts()
                    {
                        EnID = Current.EnID,
                        UnID = Current.UnID,
                        ZMID = Current.ID,
                        QDID = Current.PID
                    };

                    _ObjectSource.GetObject(increase, increaseRow);
                    _Methods_IncreaseInfo increaseMethod = new _Methods_IncreaseInfo(Unit, increase);
                    increaseMethod.CurrentBegin(Current);
                }

                var subStatictics = new _Subheadings_Statistics(entity, this.Unit);
                subStatictics.Begin();

                //计算子目经过子目取费
                _ResultSubheadings_Statictics resultStatictics = new _ResultSubheadings_Statictics(entity, this.Unit)
                {
                    DataSource = this.GetDataSource
                };
                resultStatictics.Begin();
            }

            return rows != null && rows.Length > 0;
        }
    }
}
