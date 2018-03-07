/*
 分部分项 章 节 统一实现方式 需要统计类型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    [Serializable]
   public  class _SubSegment_Statistics:_Statistics
    {

        public _SubSegment_Statistics(_Entity_SubInfo p_info, _UnitProject p_Unit)
            : base(p_info, p_Unit)
        {
          
        }
        private  Result m_ResultValue;

        public Result ResultValue
        {
          get { return m_ResultValue; }
          set { m_ResultValue = value; }
        }


        [Serializable]
        public struct Result
        {
            public decimal DEZHHJ;
            public decimal DEZJFHJ;
            public decimal DERGFHJ;
            public decimal DECLFHJ;
            public decimal DEZCFHJ;
            public decimal DESBFHJ;
            public decimal DEJXFHJ;
            public decimal DEGLFHJ;
            public decimal DELRHJ;
            public decimal DEFXHJ;

            public decimal DEJGJEHJ;
            public decimal DEYGJEHJ;
            public decimal DEPBZDHJ;
            public decimal DEZGHJ;
            public decimal DEFBJEHJ;

            public decimal ZHHJ;
            public decimal ZJFHJ;
            public decimal RGFHJ;
            public decimal CLFHJ;
            public decimal ZCFHJ;
            public decimal SBFHJ;
            public decimal JXFHJ;
            public decimal GLFHJ;
            public decimal LRHJ;
            public decimal FXHJ;

            public decimal JGJEHJ;
            public decimal YGJEHJ;
            public decimal PBZDHJ;
            public decimal ZGHJ;
            public decimal FBJEHJ;

            public decimal JCHJ;
            public decimal CJHJ;

            //public decimal HHJXRGF;
            //public decimal HHJXRGFJC;
            //public decimal DEHHJXRGF;


            public decimal FBFXJCHJ;
            public decimal FBFXRGJCHJ;
            public decimal FBFXCLJCHJ;
            public decimal FBFXJXJCHJ;
            public decimal FBFXCJHJ;
            public decimal FBFXRGCJHJ;
            public decimal FBFXCLCJHJ;
            public decimal FBFXJXCJHJ;


            public decimal DEGFHJ;
            public decimal GFHJ;
            public decimal DESJHJ;
            public decimal SJHJ;

        }

        public void Begin()
        {
       
            //_Methods.ResetSerializeNumber(this.Unit);

            SetHJ();
            Statistics();
            SetValueToView();
            //base.SetValueToView();
        }

        //public override void Calculate()
        //{
        //    /*_SubSegments info = this.Parent as _SubSegments;
        //    foreach (_ProfessionalInfo item in info.ProfessionalList)
        //    {
        //        item.Statistics.Calculate();
        //    }
        //    this.Begin();*/
        //}

        /// <summary>
        /// 设置合计变量 3节 2章  1专业 0分部
        /// </summary>
        /// <param name="p_type"></param>
        private void SetHJ()
        {
            //统计当前对象
            _Entity_SubInfo info = this.Current;
            if (info != null)
            {
                m_ResultValue = new Result();
                //查询当前对象下的一级子对象
                //DataRow[] rows = this.DataSource.Select(string.Format(" UNID = {0} and PID = {1}", this.Unit.ID, this.Current.ID), "", DataViewRowState.CurrentRows);
                DataRow[] rows = this.DataSource.Select(string.Format(" UNID = {0} and PID = {1}", this.Current.UnID, this.Current.ID), "", DataViewRowState.CurrentRows);
                _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
                foreach (DataRow row in rows)
                {
                    int id = ToolKit.ParseInt(row["ID"]);
                    //所有的合价累计
                    m_ResultValue.DEZHHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEZHHJ);
                    m_ResultValue.DEZJFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEZJFHJ);
                    m_ResultValue.DERGFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DERGFHJ);
                    m_ResultValue.DECLFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DECLFHJ);
                    m_ResultValue.DEZCFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEZCFHJ);
                    m_ResultValue.DESBFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DESBFHJ);
                    m_ResultValue.DEJXFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEJXFHJ);
                    m_ResultValue.DEGLFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEGLFHJ);
                    m_ResultValue.DELRHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DELRHJ);
                    m_ResultValue.DEFXHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEFXHJ);

                    m_ResultValue.DEJGJEHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEJGJEHJ);
                    m_ResultValue.DEYGJEHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEYGJEHJ);
                    m_ResultValue.DEPBZDHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEPBZDHJ);
                    m_ResultValue.DEZGHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEZGHJ);

                    m_ResultValue.ZHHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_ZHHJ);
                    m_ResultValue.ZJFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_ZJFHJ);
                    m_ResultValue.RGFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_RGFHJ);
                    m_ResultValue.CLFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_CLFHJ);
                    m_ResultValue.ZCFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_ZCFHJ);
                    m_ResultValue.SBFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_SBFHJ);
                    m_ResultValue.JXFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_JXFHJ);
                    m_ResultValue.GLFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_GLFHJ);
                    m_ResultValue.LRHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_LRHJ);
                    m_ResultValue.FXHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FXHJ);


                    m_ResultValue.JGJEHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_JGJEHJ);
                    m_ResultValue.YGJEHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_YGJEHJ);
                    m_ResultValue.PBZDHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_PBZDHJ);
                    m_ResultValue.ZGHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_ZGHJ);

                    m_ResultValue.JCHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_JCHJ);
                    m_ResultValue.CJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_CJHJ);
                    //m_ResultValue.HHJXRGF += ResultVarable.GetDecimal(id,this.Current.SSLB,_Statistics.FILED_HHJXRGF);
                    //m_ResultValue.HHJXRGFJC += ResultVarable.GetDecimal(id,this.Current.SSLB,_Statistics.FILED_HHJXRGFJC);
                    //m_ResultValue.DEHHJXRGF += ResultVarable.GetDecimal(id,this.Current.SSLB,_Statistics.FILED_DEHHJXRGF);

                    m_ResultValue.FBFXCJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXCJHJ);
                    m_ResultValue.FBFXJCHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXJCHJ);

                    m_ResultValue.FBFXRGJCHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXRGJCHJ);
                    m_ResultValue.FBFXCLJCHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXCLJCHJ);
                    m_ResultValue.FBFXJXJCHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXJXJCHJ);

                    m_ResultValue.FBFXRGCJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXRGCJHJ);
                    m_ResultValue.FBFXCLCJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXCLCJHJ);
                    m_ResultValue.FBFXJXCJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBFXJXCJHJ);

                    m_ResultValue.DEGFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEGFHJ);
                    m_ResultValue.GFHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_GFHJ);
                    m_ResultValue.DESJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DESJHJ);
                    m_ResultValue.SJHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_SJHJ);
                    m_ResultValue.FBJEHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_FBJEHJ);
                    m_ResultValue.DEFBJEHJ += ResultVarable.GetDecimal(id, this.Current.SSLB, _Statistics.FILED_DEFBJEHJ);
                }
            }


        }

        private void Statistics()
        {
            _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
            //计算分部分项的市场和价
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFHJ, m_ResultValue.RGFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFHJ, m_ResultValue.CLFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ, m_ResultValue.JXFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFHJ, m_ResultValue.ZCFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ, m_ResultValue.SBFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFHJ, m_ResultValue.GLFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRHJ, m_ResultValue.LRHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXHJ, m_ResultValue.FXHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFHJ, m_ResultValue.ZJFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ, m_ResultValue.ZHHJ);


            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEHJ, m_ResultValue.JGJEHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEHJ, m_ResultValue.YGJEHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDHJ, m_ResultValue.PBZDHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGHJ, m_ResultValue.ZGHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBJEHJ, m_ResultValue.FBJEHJ);

            //分部分项的定额和价
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DERGFHJ, m_ResultValue.DERGFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DECLFHJ, m_ResultValue.DECLFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJXFHJ, m_ResultValue.DEJXFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZCFHJ, m_ResultValue.DEZCFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESBFHJ, m_ResultValue.DESBFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGLFHJ, m_ResultValue.DEGLFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DELRHJ, m_ResultValue.DELRHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEFXHJ, m_ResultValue.DEFXHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZJFHJ, m_ResultValue.DEZJFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZHHJ, m_ResultValue.DEZHHJ);

            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJGJEHJ, m_ResultValue.DEJGJEHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEYGJEHJ, m_ResultValue.DEYGJEHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEPBZDHJ, m_ResultValue.DEPBZDHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZGHJ, m_ResultValue.DEZGHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEFBJEHJ, m_ResultValue.DEFBJEHJ);


            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JCHJ, m_ResultValue.JCHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CJHJ, m_ResultValue.CJHJ);


            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEHJ, m_ResultValue.JGJEHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEHJ, m_ResultValue.YGJEHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDHJ, m_ResultValue.PBZDHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGHJ, m_ResultValue.ZGHJ);
            //this.ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGF, m_ResultValue.HHJXRGF);
            //this.ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEHHJXRGF, m_ResultValue.DEHHJXRGF);
            //this.ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGFJC, m_ResultValue.HHJXRGFJC);

            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJHJ, m_ResultValue.FBFXCJHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCHJ, m_ResultValue.FBFXJCHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGJCHJ, m_ResultValue.FBFXRGJCHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLJCHJ, m_ResultValue.FBFXCLJCHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXJCHJ, m_ResultValue.FBFXJXJCHJ);

            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGCJHJ, m_ResultValue.FBFXRGCJHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLCJHJ, m_ResultValue.FBFXCLCJHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXCJHJ, m_ResultValue.FBFXJXCJHJ);

            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFHJ, m_ResultValue.GFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJHJ, m_ResultValue.SJHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGFHJ, m_ResultValue.DEGFHJ);
            ResultVarable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESJHJ, m_ResultValue.DESJHJ);


            //给界面赋值 在分部分项只给合价赋值
           // this.Parent.ZHHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ);
            /*this.Parent.ZJFHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZJFHJ);
            this.Parent.GLFHJ = ResultVarable.GetDecimal(_Statistics.FILED_GLFHJ);
            this.Parent.SBFHJ = ResultVarable.GetDecimal(_Statistics.FILED_SBFHJ);
            this.Parent.ZCFHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZCFHJ);
            this.Parent.JXFHJ = ResultVarable.GetDecimal(_Statistics.FILED_JXFHJ);
            this.Parent.CLFHJ = ResultVarable.GetDecimal(_Statistics.FILED_CLFHJ);
            this.Parent.RGFHJ = ResultVarable.GetDecimal(_Statistics.FILED_RGFHJ);
            this.Parent.FXHJ = ResultVarable.GetDecimal(_Statistics.FILED_FXHJ);
            this.Parent.LRHJ = ResultVarable.GetDecimal(_Statistics.FILED_LRHJ);
            this.Parent.FBJE = ResultVarable.GetDecimal(_Statistics.FILED_FBJEHJ);
            this.Parent.JCHJ = ResultVarable.GetDecimal(_Statistics.FILED_JCHJ);
            this.Parent.CJHJ = ResultVarable.GetDecimal(_Statistics.FILED_CJHJ);
            this.Parent.ZHHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ);
            this.Parent.GFHJ = ResultVarable.GetDecimal(_Statistics.FILED_GFHJ);
            this.Parent.SJHJ = ResultVarable.GetDecimal(_Statistics.FILED_SJHJ);*/

        }

        public override void SetValueToView()
        {
            _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
            this.Current.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ);
            this.Current.ZJFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFHJ);
            this.Current.GLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFHJ);
            this.Current.SBFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ);
            this.Current.ZCFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFHJ);
            this.Current.JXFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ);
            this.Current.CLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFHJ);
            this.Current.RGFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFHJ);
            this.Current.FXHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXHJ);
            this.Current.LRHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRHJ);
            this.Current.FBJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBJEHJ);
            this.Current.JCHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JCHJ);
            this.Current.CJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CJHJ);
            this.Current.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ);
            this.Current.GFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFHJ);
            this.Current.SJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJHJ);


            this.Current.RGFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXRGJCHJ);
            this.Current.CLFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXCLJCHJ);
            this.Current.JXFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXJXJCHJ);
           
            this.Current.ZGJE = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZGHJ);
            this.Current.PBZD = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_PBZDHJ);
            this.Current.JGJE = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_JGJEHJ);
            this.Current.YGJE = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_YGJEHJ);
            this.DataSource.UpDate(this.Current);
        }
       
    }

    
}
