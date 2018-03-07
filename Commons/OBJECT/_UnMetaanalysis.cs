using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UnMetaanalysis : _ObjMetaanalysis
    {
        private _UnitProject Project
        {
            get
            {
                return this.Parent as _UnitProject;
            }
        }

        public _UnMetaanalysis(_COBJECTS p_Info)
            : base(p_Info)
        { }

        /// <summary>
        /// 如何填充到指定集合中
        /// </summary>
        /// <param name="p_List"></param>
        public override void Fill(_List p_List)
        {
            this.Project.Property.Metaanalysis.Init();
            this.Project.Property.Metaanalysis.Calculate();
            //将自己加入到集合中
            p_List.Add(this);
        }

        /// <summary>
        /// 专业
        /// </summary>
        public override string PrfType
        {
            get
            {
                return this.Project.PrfType;
            }
        }

        /// <summary>
        /// 分部分项工程费
        /// </summary>
        public override Decimal FGCF
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("FGCF");
            }
        }

        /// <summary>
        /// 措施项目费
        /// </summary>
        public override Decimal CSXMF
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("CSXMF");
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public override Decimal QTXMF
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("QTXMF");
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public override Decimal GF
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("GF");
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public override Decimal SJ
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("SJ");
            }
        }

        /// <summary>
        /// 总造价
        /// </summary>
        public override Decimal ZZJ
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("ZZJ");
            }
        }

        /// <summary>
        /// 安全文明施工费
        /// </summary>
        public override Decimal AQWM
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("AQWM");
            }
        }

        /// <summary>
        /// 劳保费用
        /// </summary>
        public virtual decimal LBTC
        {
            get
            {
                return this.Project.Property.Statistics.ResultVarable.GetDecimal("LBTC");
            }
        }

        /// <summary>
        /// 工程序号
        /// </summary>
        public override string XH
        {
            get
            {
                return this.Parent.Parent.Parent.Sort + "." + this.Parent.Parent.Sort + "." + this.Parent.Sort;
            }
        }

        public override string JSDW
        {
            get
            {
                return this.Parent.Parent.Parent.Property.BasicInformation.BiddingInformation.JSDW;
            }
        }

        public override decimal JZMJ
        {
            get
            {
                return CDataConvert.ConToValue<System.Decimal>(this.Parent.Parent.Parent.Property.BasicInformation.BiddingInformation.ZBMJ);
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
                return ZZJ / this.Parent.Parent.Parent.Reveal.ProMetaanalysis.ZZJ * 100; 
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
