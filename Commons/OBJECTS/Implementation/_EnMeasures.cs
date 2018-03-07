/*
    项目中措施项目的实现类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _EnMeasures : _ProjectObjectInfo
    {
        public _EnMeasures(_COBJECTS p_Info)
            : base(p_Info)
        {
   
        }

        /// <summary>
        /// 填充分部分项统计数据(单项工程添加)
        /// </summary>
        /// <param name="p_list"></param>
        public override void Fill(_List p_list, ref int p_seed)
        {
            this.Key = p_seed++;
            p_list.Add(this);
            foreach (_COBJECTS obj in this.Parent.StrustObject.ObjectList.Values)
            {
                obj.Reveal.ProMeasures.PKey = this.Key;
                obj.Reveal.ProMeasures.Fill(p_list, ref p_seed);
            }
        }

        public override string LB
        {
            get
            {
                return "单项工程";
            }
            set
            {

            }
        }


        #region ---------------------计算类统计-----------------
        /// <summary>
        /// 直接费合价
        /// </summary>
        public override decimal ZJFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.ZJFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.ZJFHJ).Sum();*/
                return infos;
            }
            set { }

        }
        /// <summary>
        /// 人工费合价
        /// </summary>
        public override decimal RGFHJ
        {
            get
            {

                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.RGFHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.RGFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 材料费合价
        /// </summary>
        public override decimal CLFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.CLFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.CLFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 机械费合价
        /// </summary>
        public override decimal JXFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.JXFHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.JXFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 主材费合价
        /// </summary>
        public override decimal ZCFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.ZCFHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.ZCFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 设备费合价
        /// </summary>
        public override decimal SBFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.SBFHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.SBFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 管理费合价
        /// </summary>
        public override decimal GLFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.GLFHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.GLFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 利润合价
        /// </summary>
        public override decimal LRHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.LRHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.LRHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 风险合价
        /// </summary>
        public override decimal FXHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.FXHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.FXHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 规费合价
        /// </summary>
        public override decimal GFHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.GFHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.GFHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 税金合价
        /// </summary>
        public override decimal SJHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.SJHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.SJHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 价差合计
        /// </summary>
        public override decimal JCHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.JCHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.JCHJ).Sum();*/
                return infos;
            }
            set { }
        }
        /// <summary>
        /// 差价合计
        /// </summary>
        public override decimal CJHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.CJHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.CJHJ).Sum();*/
                return infos;
            }
            set { }
        }

        public override decimal ZHHJ
        {
            get
            {
                Decimal infos = (from i in this.Parent.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMeasures.ZHHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMeasures.ZHHJ).Sum();*/
                return infos;
            }
            set
            {

            }
        }

        #endregion
    }
}
