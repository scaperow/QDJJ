/*
 为清单处理的统计数据源
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _FixedList_Statistics:_Statistics
    {

        public _FixedList_Statistics(_ObjectInfo p_Parent):base(p_Parent)
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

          
            //public decimal DEFBJEHJ;

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

            public decimal JCHJ;
            public decimal CJHJ;

            public decimal JGJEHJ;
            public decimal YGJEHJ;
            public decimal PBZDHJ;
            public decimal ZGHJ;

            //public decimal HHJXRGF;
            //public decimal HHJXRGFJC;
            //public decimal DEHHJXRGF;

             public decimal FBFXJCHJ; 
             public decimal  FBFXRGJCHJ;
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
            base.SetValueToView();
        }

        public override void Calculate()
        {
            _FixedListInfo info = this.Parent as _FixedListInfo;
            foreach (_SubheadingsInfo item in info.SubheadingsList)
            {
                item.Statistics.Calculate();
            }
            this.Begin();
        }
        private void SetHJ()
        {

            _FixedListInfo info = this.Parent as _FixedListInfo;
            if (info != null)
            {

                m_ResultValue = new Result();

               
                    foreach (_SubheadingsInfo item in info.SubheadingsList)
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

                        m_ResultValue.JCHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_JCHJ);
                        m_ResultValue.CJHJ += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_CJHJ);
                        //m_ResultValue.HHJXRGF += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_HHJXRGF);
                        //m_ResultValue.HHJXRGFJC += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_HHJXRGFJC);
                        //m_ResultValue.DEHHJXRGF += item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_DEHHJXRGF);
                       
                        m_ResultValue.FBFXCJHJ+= item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXCJHJ);
                         m_ResultValue.FBFXJCHJ+= item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXJCHJ);
                        
                        m_ResultValue.FBFXRGJCHJ+= item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXRGJCHJ);
                        m_ResultValue.FBFXCLJCHJ+= item.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXCLJCHJ);
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

        private void doStatistics()
        {
          
            decimal GCL = this.Parent.GCL;
            if (GCL == 0)
            {
                GCL = 1;
            }
            //计算清单的单价
            if (!this.Parent.SDQD)
            {               
            
            this.ResultVarable.Set(_Statistics.FILED_RGFDJ, m_ResultValue.RGFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_CLFDJ, m_ResultValue.CLFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_JXFDJ, m_ResultValue.JXFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_ZCFDJ, m_ResultValue.ZCFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_SBFDJ, m_ResultValue.SBFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_GLFDJ, m_ResultValue.GLFHJ / GCL);

            this.ResultVarable.Set(_Statistics.FILED_LRDJ, m_ResultValue.LRHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_FXDJ, m_ResultValue.FXHJ / GCL);
           // this.ResultVarable.Set(_Statistics.FILED_ZJFDJ, m_ResultValue.ZJFHJ / GCL);
           // this.ResultVarable.Set(_Statistics.FILED_ZHDJ, m_ResultValue.ZHHJ / GCL);

             //综合单价
            decimal ZHDJ = this.ResultVarable.GetDecimal(_Statistics.FILED_RGFDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_CLFDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_ZCFDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_GLFDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_LRDJ)
                        + this.ResultVarable.GetDecimal(_Statistics.FILED_FXDJ);
                //直接费单价
            decimal ZJFDJ = this.ResultVarable.GetDecimal(_Statistics.FILED_RGFDJ)
                   + this.ResultVarable.GetDecimal(_Statistics.FILED_CLFDJ)
                   + this.ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ)
                   + this.ResultVarable.GetDecimal(_Statistics.FILED_ZCFDJ)
                   + this.ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ);

            this.ResultVarable.Set(_Statistics.FILED_ZJFDJ, ZJFDJ);
            this.ResultVarable.Set(_Statistics.FILED_ZHDJ, ZHDJ);
     
            //this.ResultVarable.Set(_Statistics.FILED_JGJEDJ, m_ResultValue.JGJEHJ / GCL);
            //this.ResultVarable.Set(_Statistics.FILED_YGJEDJ, m_ResultValue.YGJEHJ / GCL);
            //this.ResultVarable.Set(_Statistics.FILED_PBZDDJ, m_ResultValue.PBZDHJ / GCL);
            //this.ResultVarable.Set(_Statistics.FILED_ZGDJ, m_ResultValue.ZGHJ / GCL);

            //计算清单的定额单价
            this.ResultVarable.Set(_Statistics.FILED_DERGFDJ, m_ResultValue.DERGFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DECLFDJ, m_ResultValue.DECLFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEJXFDJ, m_ResultValue.DEJXFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEZCFDJ, m_ResultValue.DEZCFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DESBFDJ, m_ResultValue.DESBFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEGLFDJ, m_ResultValue.DEGLFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DELRDJ, m_ResultValue.DELRHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEFXDJ, m_ResultValue.DEFXHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEZJFDJ, m_ResultValue.DEZJFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEZHDJ, m_ResultValue.DEZHHJ / GCL);


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

            //this.ResultVarable.Set(_Statistics.FILED_DEJGJEDJ, m_ResultValue.DEJGJEHJ / GCL);
            //this.ResultVarable.Set(_Statistics.FILED_DEYGJEDJ, m_ResultValue.DEYGJEHJ / GCL);
            //this.ResultVarable.Set(_Statistics.FILED_DEPBZDDJ, m_ResultValue.DEPBZDHJ / GCL);
            //this.ResultVarable.Set(_Statistics.FILED_DEZGDJ, m_ResultValue.DEZGHJ / GCL);

            this.ResultVarable.Set(_Statistics.FILED_JCDJ, m_ResultValue.JCHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_CJDJ, m_ResultValue.CJHJ / GCL);



            this.ResultVarable.Set(_Statistics.FILED_JGJEHJ, m_ResultValue.JGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_YGJEHJ, m_ResultValue.YGJEHJ);
            this.ResultVarable.Set(_Statistics.FILED_PBZDHJ, m_ResultValue.PBZDHJ);
            this.ResultVarable.Set(_Statistics.FILED_ZGHJ, m_ResultValue.ZGHJ);


            this.ResultVarable.Set(_Statistics.FILED_DEJGJEHJ, m_ResultValue.DEJGJEHJ );
            this.ResultVarable.Set(_Statistics.FILED_DEYGJEHJ, m_ResultValue.DEYGJEHJ );
            this.ResultVarable.Set(_Statistics.FILED_DEPBZDHJ, m_ResultValue.DEPBZDHJ );
            this.ResultVarable.Set(_Statistics.FILED_DEZGHJ, m_ResultValue.DEZGHJ );

            //this.ResultVarable.Set(_Statistics.FILED_HHJXRGF, m_ResultValue.HHJXRGF);
            //this.ResultVarable.Set(_Statistics.FILED_HHJXRGFJC, m_ResultValue.HHJXRGFJC);

            //this.ResultVarable.Set(_Statistics.FILED_DEHHJXRGF, m_ResultValue.DEHHJXRGF);
   

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
            this.ResultVarable.Set(_Statistics.FILED_GFDJ, m_ResultValue.GFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_SJDJ, m_ResultValue.SJHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DEGFDJ, m_ResultValue.DEGFHJ / GCL);
            this.ResultVarable.Set(_Statistics.FILED_DESJDJ, m_ResultValue.DESJHJ / GCL);
            }

       
 


            //根据单价计算合价
            m_ResultValue.RGFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_RGFDJ) * GCL;
            m_ResultValue.CLFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_CLFDJ) * GCL;
            m_ResultValue.JXFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_JXFDJ) * GCL;
            m_ResultValue.ZCFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_ZCFDJ) * GCL;
            m_ResultValue.SBFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_SBFDJ) * GCL;
            m_ResultValue.GLFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_GLFDJ) * GCL;
            m_ResultValue.LRHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_LRDJ) * GCL;
            m_ResultValue.FXHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_FXDJ) * GCL;
            m_ResultValue.ZJFHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_ZJFDJ) * GCL;
            m_ResultValue.ZHHJ = this.ResultVarable.GetDecimal(_Statistics.FILED_ZHDJ) * GCL;

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

           
            //计算分包金额
            if (this.Parent.SFFB)
            {
                this.ResultVarable.Set(_Statistics.FILED_FBJEHJ, this.ResultVarable.GetDecimal(_Statistics.FILED_ZHHJ));
            }
            else
            {
                this.ResultVarable.Set(_Statistics.FILED_FBJEHJ, 0);
            }
            this.Parent.FBJE = this.ResultVarable.GetDecimal(_Statistics.FILED_FBJEHJ);
        }
       
    }
}
