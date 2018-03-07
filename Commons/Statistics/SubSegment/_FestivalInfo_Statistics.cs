using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _FestivalInfo_Statistics : _Statistics
    {
        public _FestivalInfo_Statistics(_ObjectInfo p_Parent)
            : base(p_Parent)
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
        public override void Begin()
        {
            SetHJ();
            doStatistics();
           // base.SetValueToView();
        }
        public override void Calculate()
        {
            _FestivalInfo info = this.Parent as _FestivalInfo;
            foreach (_FixedListInfo item in info.FixedList)
            {
                item.Statistics.Calculate();
            }
            this.Begin();
        }


        private void SetHJ()
        {

            _FestivalInfo info = this.Parent as _FestivalInfo;
            if (info != null)
            {
                m_ResultValue = new Result();

                foreach (_FixedListInfo item in info.FixedList)
                {
                    if (item.JBHZ)
                    {
                        //所有的合价累计
                        m_ResultValue.DEZHHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEZHHJ);
                        m_ResultValue.DEZJFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEZJFHJ);
                        m_ResultValue.DERGFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DERGFHJ);
                        m_ResultValue.DECLFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DECLFHJ);
                        m_ResultValue.DEZCFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEZCFHJ);
                        m_ResultValue.DESBFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DESBFHJ);
                        m_ResultValue.DEJXFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEJXFHJ);
                        m_ResultValue.DEGLFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEGLFHJ);
                        m_ResultValue.DELRHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DELRHJ);
                        m_ResultValue.DEFXHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEFXHJ);

                        m_ResultValue.DEJGJEHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEJGJEHJ);
                        m_ResultValue.DEYGJEHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEYGJEHJ);
                        m_ResultValue.DEPBZDHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEPBZDHJ);
                        m_ResultValue.DEZGHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEZGHJ);
                        m_ResultValue.DEFBJEHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEFBJEHJ);


                        m_ResultValue.ZHHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ);
                        m_ResultValue.ZJFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZJFHJ);
                        m_ResultValue.RGFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_RGFHJ);
                        m_ResultValue.CLFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_CLFHJ);
                        m_ResultValue.ZCFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZCFHJ);
                        m_ResultValue.SBFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_SBFHJ);
                        m_ResultValue.JXFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JXFHJ);
                        m_ResultValue.GLFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_GLFHJ);
                        m_ResultValue.LRHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_LRHJ);
                        m_ResultValue.FXHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FXHJ);

                        m_ResultValue.JGJEHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JGJEHJ);
                        m_ResultValue.YGJEHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_YGJEHJ);
                        m_ResultValue.PBZDHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_PBZDHJ);
                        m_ResultValue.ZGHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_ZGHJ);
                        m_ResultValue.FBJEHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBJEHJ);


                        m_ResultValue.JCHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JCHJ);
                        m_ResultValue.CJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_CJHJ);

                        //m_ResultValue.HHJXRGF += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_HHJXRGF);
                        //m_ResultValue.HHJXRGFJC += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_HHJXRGFJC);
                        //m_ResultValue.DEHHJXRGF += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEHHJXRGF);

                        m_ResultValue.FBFXCJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXCJHJ);
                        m_ResultValue.FBFXJCHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXJCHJ);
                        m_ResultValue.FBFXRGJCHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXRGJCHJ);
                        m_ResultValue.FBFXCLJCHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXCLJCHJ);
                        m_ResultValue.FBFXJXJCHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXJXJCHJ);

                        m_ResultValue.FBFXRGCJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXRGCJHJ);
                        m_ResultValue.FBFXCLCJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXCLCJHJ);
                        m_ResultValue.FBFXJXCJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXJXCJHJ);

                        m_ResultValue.DEGFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEGFHJ);
                        m_ResultValue.GFHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_GFHJ);
                        m_ResultValue.DESJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DESJHJ);
                        m_ResultValue.SJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_SJHJ);
                    }
                }
            }


        }

        private void doStatistics()
        {
            //计算分部分项的市场和价
            this.ResultVarable.Set(_Statistics.FILED_RGFHJ, m_ResultValue.RGFHJ);
            this.ResultVarable.Set(_Statistics.FILED_CLFHJ, m_ResultValue.CLFHJ);
            this.ResultVarable.Set(_Statistics.FILED_JXFHJ, m_ResultValue.JXFHJ);
            this.ResultVarable.Set(_Statistics.FILED_ZCFHJ, m_ResultValue.ZCFHJ);
            this.ResultVarable.Set(_Statistics.FILED_SBFHJ, m_ResultValue.SBFHJ);
            this.ResultVarable.Set(_Statistics.FILED_GLFHJ, m_ResultValue.GLFHJ);
            this.ResultVarable.Set(_Statistics.FILED_LRHJ, m_ResultValue.LRHJ);
            this.ResultVarable.Set(_Statistics.FILED_FXHJ, m_ResultValue.FXHJ);
            this.ResultVarable.Set(_Statistics.FILED_ZJFHJ, m_ResultValue.ZJFHJ);
            this.ResultVarable.Set(_Statistics.FILED_ZHHJ, m_ResultValue.ZHHJ);


            this.ResultVarable.Set(_Statistics.FILED_JGJEHJ, m_ResultValue.JGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_YGJEHJ, m_ResultValue.YGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_PBZDHJ, m_ResultValue.PBZDHJ);
            this.ResultVarable.Set(_Statistics.FILED_ZGHJ, m_ResultValue.ZGHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBJEHJ, m_ResultValue.FBJEHJ);

            //计算分部分项的定额和价
            this.ResultVarable.Set(_Statistics.FILED_DERGFHJ, m_ResultValue.DERGFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DECLFHJ, m_ResultValue.DECLFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEJXFHJ, m_ResultValue.DEJXFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEZCFHJ, m_ResultValue.DEZCFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DESBFHJ, m_ResultValue.DESBFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEGLFHJ, m_ResultValue.DEGLFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DELRHJ, m_ResultValue.DELRHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEFXHJ, m_ResultValue.DEFXHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEZJFHJ, m_ResultValue.DEZJFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEZHHJ, m_ResultValue.DEZHHJ);

            this.ResultVarable.Set(_Statistics.FILED_DEJGJEHJ, m_ResultValue.DEJGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEYGJEHJ, m_ResultValue.DEYGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEPBZDHJ, m_ResultValue.DEPBZDHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEZGHJ, m_ResultValue.DEZGHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEFBJEHJ, m_ResultValue.DEFBJEHJ);


            this.ResultVarable.Set(_Statistics.FILED_JCHJ, m_ResultValue.JCHJ);
            this.ResultVarable.Set(_Statistics.FILED_CJHJ, m_ResultValue.CJHJ);


            this.ResultVarable.Set(_Statistics.FILED_JGJEHJ, m_ResultValue.JGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_YGJEHJ, m_ResultValue.YGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_PBZDHJ, m_ResultValue.PBZDHJ);
            this.ResultVarable.Set(_Statistics.FILED_ZGHJ, m_ResultValue.ZGHJ);

            //this.ResultVarable.Set(_Statistics.FILED_HHJXRGF, m_ResultValue.HHJXRGF);
            //this.ResultVarable.Set(_Statistics.FILED_HHJXRGFJC, m_ResultValue.HHJXRGFJC);

            this.ResultVarable.Set(_Statistics.FILED_FBFXCJHJ, m_ResultValue.FBFXCJHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBFXJCHJ, m_ResultValue.FBFXJCHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBFXRGJCHJ, m_ResultValue.FBFXRGJCHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBFXCLJCHJ, m_ResultValue.FBFXCLJCHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBFXJXJCHJ, m_ResultValue.FBFXJXJCHJ);

            this.ResultVarable.Set(_Statistics.FILED_FBFXRGCJHJ, m_ResultValue.FBFXRGCJHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBFXCLCJHJ, m_ResultValue.FBFXCLCJHJ);
            this.ResultVarable.Set(_Statistics.FILED_FBFXJXCJHJ, m_ResultValue.FBFXJXCJHJ);


            this.ResultVarable.Set(_Statistics.FILED_GFHJ, m_ResultValue.GFHJ);
            this.ResultVarable.Set(_Statistics.FILED_SJHJ, m_ResultValue.SJHJ);
            this.ResultVarable.Set(_Statistics.FILED_DEGFHJ, m_ResultValue.DEGFHJ);
            this.ResultVarable.Set(_Statistics.FILED_DESJHJ, m_ResultValue.DESJHJ);
            //给界面赋值 在分部分项只给合价赋值
           // this.Parent.ZHHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ);
            this.Parent.ZJFHJ = ResultVarable.GetDecimal(_Statistics.FILED_ZJFHJ);
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
            this.Parent.SJHJ = ResultVarable.GetDecimal(_Statistics.FILED_SJHJ);
        }
    }
}
