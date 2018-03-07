using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ProMetaanalysis : _ObjMetaanalysis
    {
        private _Projects Project
        {
            get
            {
                return this.Parent as _Projects;
            }
        }

        public _ProMetaanalysis(_COBJECTS p_Info)
            : base(p_Info)
        {
 
        }

        /// <summary>
        ///  如何填充
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
                /*
                Decimal infos = (from i in this.Project.CObjectList.Values.Cast<CUnitProject>()

                                               select i.Statistics.ResultVarable.GetDecimal("FGCF")).Sum();
                return infos;*/

                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable() where Convert.ToInt32(i["PID"]) > 1

                                 select (i["UnitProject"] as _UnitProject).Reveal.ProMetaanalysis.FGCF).Sum();


                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.FGCF).Sum();*/
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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.CSXMF).Sum();*/

                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.QTXMF).Sum();*/
                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.GF).Sum();*/

                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.SJ).Sum();*/

                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.ZZJ).Sum();*/
                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.AQWM).Sum();*/
                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                /*Decimal infos = (from i in this.Project.StrustObject.ObjectList.Values.Cast<_Engineering>()

                                 select i.Reveal.ProMetaanalysis.LBTC).Sum();*/

                Decimal infos = (from i in this.Project.StructSource.ModelProject.AsEnumerable()
                                 where Convert.ToInt32(i["PID"]) > 1

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
                return this.Parent.Sort.ToString();
            }
        }

        public override string JSDW
        {
            get
            {
                return this.Parent.Property.BasicInformation.BiddingInformation.JSDW;
            }
        }

        public override decimal JZMJ
        {
            get
            {
                return CDataConvert.ConToValue<System.Decimal>(this.Parent.Property.BasicInformation.BiddingInformation.ZBMJ);
            }
        }

        public override decimal DWZJ
        {
            get
            {
                return ZZJ / CDataConvert.ConToValue<System.Decimal>(this.Parent.Property.BasicInformation.BiddingInformation.ZBMJ);
            }
        }

        public override decimal ZZJB
        {
            get
            {
                return base.ZZJB;
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
