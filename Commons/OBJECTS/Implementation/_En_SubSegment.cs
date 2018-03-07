using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _En_SubSegment : _ProjectObjectInfo
    {

        public _En_SubSegment(_COBJECTS p_Info)
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
                obj.Reveal.ProSubSegment.PKey = this.Key;
                obj.Reveal.ProSubSegment.Fill(p_list, ref p_seed);
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.ZJFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.ZJFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.RGFHJ).Sum();


                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.RGFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.CLFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.CLFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.JXFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.JXFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.ZCFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.ZCFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.SBFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.SBFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.GLFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.GLFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.LRHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.LRHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.FXHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.FXHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.GFHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.GFHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.SJHJ).Sum();

                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.SJHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.JCHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.JCHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.CJHJ).Sum();
                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.CJHJ).Sum();*/
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
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProSubSegment.ZHHJ).Sum();


                /*Decimal infos = (from i in this.Parent.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProSubSegment.ZHHJ).Sum();*/
                return infos;
            }
            set
            {
                
            }
        }

        #endregion
    }
}
