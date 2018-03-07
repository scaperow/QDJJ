/*
 为清单处理的统计数据源
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    [Serializable]
    public class _FixedList_Statistics:_Statistics
    {

        public _FixedList_Statistics(_Entity_SubInfo p_info, _UnitProject p_Unit)
            : base(p_info, p_Unit)
        {
          
        }
        private Result m_ResultValue;

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

        public  void Begin(DataRow[] rows)
        {
            SetHJ(rows);
            Statistics();
            SetValueToView();
        }

        //public override void Calculate()
        //{
        //    /*_Entity_SubInfo info = this.Current;
        //    foreach (_SubheadingsInfo item in info.SubheadingsList)
        //    {
        //        item.Statistics.Calculate();
        //    }*/
        //    this.Begin();
        //}
        private void SetHJ(DataRow[] rows)
        {

            _Entity_SubInfo info = this.Current;
            if (info != null)
            {

                m_ResultValue = new Result();
                
                _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
                if (info.ZJFS == _Constant.公式组价)
                {
                    string str = info.JSJC;
                    if (string.IsNullOrEmpty(str)) str = "0";
                    // this.Parent.Parent.Parent.Property.Statistics.Begin();
                    str = ToolKit.ExpressionReplace(str, this.Unit.StructSource.ModelProjVariable);
                    decimal m = info.FL;
                    //decimal.TryParse(info.FL, out m);
                    decimal ZHDJ = ToolKit.Calculate(str) * m * 0.01m;
                    decimal ZHHJ = ZHDJ * info.GCL;
                    m_ResultValue.ZHHJ = ZHHJ;
                    m_ResultValue.CLFHJ = ZHHJ;
                    // m_ResultValue.zhd = ZHHJ;
                }
                else
                {
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
                        }
                    }
                
               
            }


        }

        private void Statistics()
        {
            _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
            decimal GCL = this.Current.GCL;
            if (GCL == 0)
            {
                GCL = 1;
            }
            //计算清单的单价
            if (!this.Current.SDDJ)
            {               
            
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFDJ, m_ResultValue.RGFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFDJ, m_ResultValue.CLFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ, m_ResultValue.JXFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFDJ, m_ResultValue.ZCFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ, m_ResultValue.SBFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFDJ, m_ResultValue.GLFHJ / GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRDJ, m_ResultValue.LRHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXDJ, m_ResultValue.FXHJ / GCL);
           // this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFDJ, m_ResultValue.ZJFHJ / GCL);
           // this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ, m_ResultValue.ZHHJ / GCL);

             //综合单价

            //if (this.Current.ZJFS == _Constant.公式组价)
            //{
            //    this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZJFDJ, m_ResultValue.ZJFHJ / GCL);
            //    this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZHDJ, m_ResultValue.ZHHJ / GCL);
            //}
            //else
            //{
                decimal ZHDJ = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_RGFDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_CLFDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_JXFDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZCFDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_SBFDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_GLFDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_LRDJ)
                            + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FXDJ);
                //直接费单价
                decimal ZJFDJ = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_RGFDJ)
                       + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_CLFDJ)
                       + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_JXFDJ)
                       + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZCFDJ)
                       + ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_SBFDJ);
               // if (ZHDJ == 0)
                //{
                   // this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZJFDJ, m_ResultValue.ZJFHJ / GCL);
                    //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZHDJ, m_ResultValue.ZHHJ / GCL);
               // }
                //else
                //{
                    this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZJFDJ, ZJFDJ);
                    this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZHDJ, ZHDJ);
                //}
            //}
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEDJ, m_ResultValue.JGJEHJ / GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEDJ, m_ResultValue.YGJEHJ / GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDDJ, m_ResultValue.PBZDHJ / GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGDJ, m_ResultValue.ZGHJ / GCL);

            //计算清单的定额单价
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DERGFDJ, m_ResultValue.DERGFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DECLFDJ, m_ResultValue.DECLFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJXFDJ, m_ResultValue.DEJXFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZCFDJ, m_ResultValue.DEZCFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESBFDJ, m_ResultValue.DESBFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGLFDJ, m_ResultValue.DEGLFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DELRDJ, m_ResultValue.DELRHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEFXDJ, m_ResultValue.DEFXHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZJFDJ, m_ResultValue.DEZJFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZHDJ, m_ResultValue.DEZHHJ / GCL);


            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DERGFHJ, m_ResultValue.DERGFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DECLFHJ, m_ResultValue.DECLFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJXFHJ, m_ResultValue.DEJXFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZCFHJ, m_ResultValue.DEZCFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESBFHJ, m_ResultValue.DESBFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGLFHJ, m_ResultValue.DEGLFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DELRHJ, m_ResultValue.DELRHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEFXHJ, m_ResultValue.DEFXHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZJFHJ, m_ResultValue.DEZJFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZHHJ, m_ResultValue.DEZHHJ);

            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJGJEDJ, m_ResultValue.DEJGJEHJ / GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEYGJEDJ, m_ResultValue.DEYGJEHJ / GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEPBZDDJ, m_ResultValue.DEPBZDHJ / GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZGDJ, m_ResultValue.DEZGHJ / GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JCDJ, m_ResultValue.JCHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CJDJ, m_ResultValue.CJHJ / GCL);



            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEHJ, m_ResultValue.JGJEHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEHJ, m_ResultValue.YGJEHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDHJ, m_ResultValue.PBZDHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGHJ, m_ResultValue.ZGHJ);


            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJGJEHJ, m_ResultValue.DEJGJEHJ );
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEYGJEHJ, m_ResultValue.DEYGJEHJ );
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEPBZDHJ, m_ResultValue.DEPBZDHJ );
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZGHJ, m_ResultValue.DEZGHJ );

            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGF, m_ResultValue.HHJXRGF);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGFJC, m_ResultValue.HHJXRGFJC);

            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEHHJXRGF, m_ResultValue.DEHHJXRGF);
   

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJHJ, m_ResultValue.FBFXCJHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCHJ, m_ResultValue.FBFXJCHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGJCHJ, m_ResultValue.FBFXRGJCHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLJCHJ, m_ResultValue.FBFXCLJCHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXJCHJ, m_ResultValue.FBFXJXJCHJ);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGCJHJ, m_ResultValue.FBFXRGCJHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLCJHJ, m_ResultValue.FBFXCLCJHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXCJHJ, m_ResultValue.FBFXJXCJHJ);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFHJ, m_ResultValue.GFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJHJ, m_ResultValue.SJHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGFHJ, m_ResultValue.DEGFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESJHJ, m_ResultValue.DESJHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFDJ, m_ResultValue.GFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJDJ, m_ResultValue.SJHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGFDJ, m_ResultValue.DEGFHJ / GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESJDJ, m_ResultValue.DESJHJ / GCL);
            }

       
 


            //根据单价计算合价
            m_ResultValue.RGFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFDJ) * GCL;
            m_ResultValue.CLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFDJ) * GCL;
            m_ResultValue.JXFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ) * GCL;
            m_ResultValue.ZCFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFDJ) * GCL;
            m_ResultValue.SBFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ) * GCL;
            m_ResultValue.GLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFDJ) * GCL;
            m_ResultValue.LRHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRDJ) * GCL;
            m_ResultValue.FXHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXDJ) * GCL;
            m_ResultValue.ZJFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFDJ) * GCL;
            m_ResultValue.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ) * GCL;

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFHJ, m_ResultValue.RGFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFHJ, m_ResultValue.CLFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ, m_ResultValue.JXFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFHJ, m_ResultValue.ZCFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ, m_ResultValue.SBFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFHJ, m_ResultValue.GLFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRHJ, m_ResultValue.LRHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXHJ, m_ResultValue.FXHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFHJ, m_ResultValue.ZJFHJ);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ, m_ResultValue.ZHHJ);

           
            //计算分包金额
            if (this.Current.SFFB)
            {
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBJEHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ));
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEFBJEHJ, ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEZHHJ));
            }
            else
            {
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBJEHJ, 0);
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_DEFBJEHJ, 0);
            }
            this.Current.FBJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBJEHJ);
            }


        public override void SetValueToView()
        {
            base.SetValueToView();
            this.DataSource.UpDate(this.Current);
        }
    }
}
