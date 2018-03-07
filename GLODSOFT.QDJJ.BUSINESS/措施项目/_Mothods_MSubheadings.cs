using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Mothods_MSubheadings : _Methods_Subheadings
    {
        public _Mothods_MSubheadings(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
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

            //工料机计算(没经过子目取费)
            /*_Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;


            _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
            stat.DataSource = this.GetDataSource;
            stat.Begin();
            //计算子目经过子目取费
            _ResultSubheadings_Statictics sta = new _ResultSubheadings_Statictics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();

            //计算子目所属清单
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Methods_Fixed(this.Unit, info);
            met.Begin();*/
            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;

            _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
            stat.Begin();
             //计算子目经过子目取费
            _ResultSubheadings_Statictics sta = new _ResultSubheadings_Statictics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();

            //计算子目所属清单
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelMeasures.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Mothods_MFixed(this.CurrentBusiness,this.Unit, info);
            met.Begin(session);

        }
        public override void Calculate()
        {
            this.BeginCurrent();
        }
        public override void UpGCL()
        {
            DataRow r = (this.GetDataSource as _SubSegmentsSource).GetRowByOther(this.Current.PID.ToString());
            if (r != null)
            {
                decimal d = ToolKit.ParseDecimal(r["GCL"]);
                if (d != 0)
                {
                    decimal w = 0m;
                    int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["工程量输入方式"]);
                    if (m > 0)
                    {
                        w = _Methods.GetNumber(this.Current.DW);
                    }
                    if (w == 0) w = 1;
                    this.Current.GCL = ToolKit.ParseDecimal((this.Current.GCL / w).ToString("F4"));
                    this.Current.HL = ToolKit.ParseDecimal((this.Current.GCL / d).ToString("F6"));
                    this.GetDataSource.UpDate(this.Current);
                }
                this.UpZMGLJGCL();
            }
            this.Begin(null);
        }
        public override void BeginCurrent()
        {
            _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
            stat.Begin();
            //计算子目经过子目取费
            _ResultSubheadings_Statictics sta = new _ResultSubheadings_Statictics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
        }
    }
}
