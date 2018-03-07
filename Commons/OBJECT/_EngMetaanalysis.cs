using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _EngMetaanalysis : _ObjMetaanalysis
    {
        private _Engineering Project
        {
            get
            {
                return this.Parent as _Engineering;
            }
        }

        public _EngMetaanalysis(_COBJECTS p_Info):base(p_Info)
        {

        }

        /// <summary>
        /// 如何填充到指定集合中
        /// </summary>
        /// <param name="p_List"></param>
        public override void Fill(_List p_List)
        {
            //当前父对象中的所有单位工程添加到集合
            foreach (_COBJECTS obj in this.Parent.StrustObject.ObjectList.Values)
            {
                obj.Reveal.ProMetaanalysis.Fill(p_List);
            }
            //然后填充自己
            p_List.Add(this);
        }


        /// <summary>
        /// 分部分项工程费
        /// </summary>
        public override Decimal FGCF
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select  i.Reveal.ProMetaanalysis.FGCF).Sum();*/
               
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.FGCF).Sum();

                
                return infos;
            }
        }

        /// <summary>
        /// 措施项目费
        /// </summary>
        public override Decimal CSXMF
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.CSXMF).Sum();*/

                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.CSXMF).Sum();

                return infos;
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public override Decimal QTXMF
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.QTXMF).Sum();*/
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.QTXMF).Sum();
                return infos;
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public override Decimal GF
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.GF).Sum();*/
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.GF).Sum();
                return infos;
            }
        }

        /// <summary>
        /// 税金
        /// </summary>
        public override Decimal SJ
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.SJ).Sum();*/
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.SJ).Sum();
                return infos; ;
            }
        }

        /// <summary>
        /// 总造价
        /// </summary>
        public override Decimal ZZJ
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.ZZJ).Sum();*/
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.ZZJ).Sum();
                return infos; ;
            }
        }

        /// <summary>
        /// 安全文明施工费
        /// </summary>
        public override Decimal AQWM
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.AQWM).Sum();*/
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.AQWM).Sum();
                return infos; ;
            }
        }

        /// <summary>
        /// 安全文明施工费
        /// </summary>
        public override Decimal LBTC
        {
            get
            {
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_UnitProject>()

                                 select i.Reveal.ProMetaanalysis.LBTC).Sum();*/
                Decimal infos = (from i in this.Project.Parent.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) == this.Parent.ID
                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.LBTC).Sum();
                return infos; ;
            }
        }

        /// <summary>
        /// 工程序号
        /// </summary>
        public override string XH
        {
            get
            {
                return this.Parent.Parent.Sort + "." + this.Parent.Sort;
            }
        }

        public override string JSDW
        {
            get
            {
                return this.Parent.Parent.Property.BasicInformation.BiddingInformation.JSDW;
            }
        }

        public override decimal JZMJ
        {
            get
            {
                return CDataConvert.ConToValue<System.Decimal>(this.Parent.Parent.Property.BasicInformation.BiddingInformation.ZBMJ);
            }
        }
        public override decimal DWZJ
        {
            get
            {
                return ZZJ / JZMJ;
            }
        }

        public override decimal ZZJB
        {
            get
            {
                return ZZJ / this.Parent.Parent.Reveal.ProMetaanalysis.ZZJ * 100; 
            }
        }

        public override string BZ
        {
            get
            {
                return base.BZ;
            }
        }
    }
}
