using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _ResultSubheadings_Statictics : _Statistics
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public _ResultSubheadings_Statictics(_Entity_SubInfo p_info, _UnitProject p_Unit)
            : base(p_info, p_Unit)
        {
            //this.m_Parent = p_Parent;
            //this.Create();
        }

        /// <summary>
        /// 开始计算
        /// </summary>
        public  void Begin()
        {
            _Entity_SubInfo info = this.Current;
            if (info.ZJFS == _Constant.公式组价)
            {
                string str = info.JSJC;
                if (string.IsNullOrEmpty(str)) str = "0";
                // this.Activitie.Property.Statistics.Begin();
                str = ToolKit.ExpressionReplace(str, this.Unit.StructSource.ModelProjVariable);
                decimal m = 1m;
                //decimal.TryParse(info.FL, out m);
                m = ToolKit.ParseDecimal(info.FL);
                decimal ZHDJ = ToolKit.Calculate(str) * m  * 0.01m;
                decimal ZHHJ = ZHDJ * info.GCL;

               
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ, ZHHJ);
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_ZHDJ, ZHDJ);
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_CLFHJ, ZHHJ);
                this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_CLFDJ, ZHDJ);
                    //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ, info.ZHHJ / this.Current.GCL);
                

            }
            else
            {
                SetValue();
            }
            

            SetValueToView(); ;

        }

        private  void SetValue()
        {

            decimal GCL = this.Current.GCL;
            _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
            #region //定额价计算
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZHHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZHDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZJFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZJFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGLFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGLFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESBFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESBFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZCFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZCFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJXFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJXFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DECLFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DECLFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DERGFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DERGFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEFXHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEFXDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DELRHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DELRDJ) * GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJGJEHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEJGJEDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEYGJEHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEYGJEDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEPBZDHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEPBZDDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZGHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEZGDJ) * GCL);
            #endregion


            #region //市场价计算
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRDJ) * GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGDJ) * GCL);

            
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGF, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGF) * GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEHHJXRGF, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEHHJXRGF) * GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGFJC, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_HHJXRGFJC) * GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CJDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JCDJ) * GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCDJ)*GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGJCHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGJCDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLJCHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLJCDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXJCHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXJCDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJDJ) * GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGCJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXRGCJDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLCJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCLCJDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXCJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJXCJDJ) * GCL);

            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGFHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DEGFDJ) * GCL);
            this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESJHJ, ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_DESJDJ) * GCL);

            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_GLFDJ, ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_GLFDJ) * GCL);
            //this.Unit.StructSource.ModelResultVariable.Set(this.Current.ID, this.Current.SSLB, _Statistics.FILED_LRDJ, ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_LRDJ) * GCL);


            #endregion
        }

        public virtual void SetValueToView()
        {
            _VariableSource ResultVarable = this.Unit.StructSource.ModelResultVariable;
            #region //赋值到界面
            this.Current.ZHDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ);
            this.Current.ZJFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFDJ);
            this.Current.GLFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFDJ);
            this.Current.SBFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ);
            this.Current.JXFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ);
            this.Current.ZHDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHDJ);
            this.Current.CLFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFDJ);
            this.Current.RGFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFDJ);
            this.Current.FXDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXDJ);
            this.Current.LRDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRDJ);
            this.Current.ZCFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFDJ);
            this.Current.JXFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFDJ);
            this.Current.SBFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFDJ);
            this.Current.JCDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCDJ);
            this.Current.CJDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJDJ);
           

            //合价的赋值
            this.Current.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ);
            this.Current.ZJFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZJFHJ);
            this.Current.GLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GLFHJ);
            this.Current.SBFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ);
            this.Current.JXFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ);
            this.Current.ZHHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZHHJ);
            this.Current.CLFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CLFHJ);
            this.Current.RGFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_RGFHJ);
            this.Current.FXHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FXHJ);
            this.Current.LRHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_LRHJ);

            this.Current.ZCFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZCFHJ);
            this.Current.JXFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JXFHJ);
            this.Current.SBFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SBFHJ);
            this.Current.JCHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXJCHJ);
            this.Current.CJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_FBFXCJHJ);

            this.Current.RGFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXRGJCHJ);
            this.Current.CLFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXCLJCHJ);
            this.Current.JXFJC = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_FBFXJXJCHJ);
           // this.Current.JCHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JCHJ);
           // this.Current.CJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_CJHJ);
            this.Current.ZGJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_ZGHJ);

            this.Current.PBZD = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_PBZDHJ);
            this.Current.JGJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_JGJEHJ);
            this.Current.YGJE = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_YGJEHJ);
         

            this.Current.GFDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFDJ);
            this.Current.GFHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_GFHJ);
            this.Current.SJDJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJDJ);
            this.Current.SJHJ = ResultVarable.GetDecimal(this.Current.ID,this.Current.SSLB,_Statistics.FILED_SJHJ);

            //this.Current.GLFDJ = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_GLFDJ);
            //-this.Current.LRDJ = ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, _Statistics.FILED_LRDJ);

            this.DataSource.UpDate(this.Current);
            #endregion
          
        }
    }
}
