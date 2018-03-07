using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _IncreaseCostsInfo
    {
        private string m_Name;
        /// <summary>
        /// 增加费名称
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private string m_DH;
        /// <summary>
        /// 代号
        /// </summary>
        public string DH
        {
            get { return m_DH; }
            set { m_DH = value;  }
        }
        private string m_JSJC;
        /// <summary>
        /// 计算基础
        /// </summary>
        public string JSJC
        {
            get { return m_JSJC; }
            set { m_JSJC = value; this.Begin(); }
        }
        private decimal m_FJJS;
        /// <summary>
        /// 附加基数
        /// </summary>
        public decimal FJJS
        {
            get { return m_FJJS; }
            set { m_FJJS = value; this.Begin(); }
        }
        private decimal m_XS;
        /// <summary>
        /// 系数
        /// </summary>
        public decimal XS
        {
            get { return m_XS; }
            set { m_XS = value; this.Begin(); }
        }
        private decimal m_RGXS;
        /// <summary>
        /// 人工系数
        /// </summary>
        public decimal RGXS
        {
            get { return m_RGXS; }
            set { m_RGXS = value; this.Begin(); }
        }
        private decimal m_CLXS;
        /// <summary>
        /// 材料系数
        /// </summary>
        public decimal CLXS
        {
            get { return m_CLXS; }
            set { m_CLXS = value; this.Begin(); }
        }
        private decimal m_JXXS;
        /// <summary>
        /// 机械系数
        /// </summary>
        public decimal JXXS
        {
            get { return m_JXXS; }
            set { m_JXXS = value; this.Begin(); }
        }
        private decimal m_RGF;
        /// <summary>
        /// 人工费
        /// </summary>
        public decimal RGF
        {
            get { return m_RGF; }
            set { m_RGF = value;}
        }
        private decimal m_CLF;
        /// <summary>
        /// 材料费
        /// </summary>
        public decimal CLF
        {
            get { return m_CLF; }
            set { m_CLF = value; }
        }
        private decimal m_JXF;
        /// <summary>
        /// 机械费
        /// </summary>
        public decimal JXF
        {
            get { return m_JXF; }
            set { m_JXF = value; }
        }
        private decimal m_HJ;
        /// <summary>
        /// 合价
        /// </summary>
        public decimal HJ
        {
            get { return m_HJ; }
            set { m_HJ = value; }
        }


        /// <summary>
        /// 所属对象
        /// </summary>
        private _ObjectInfo m_Parent = null;
        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _ObjectInfo Parent
        {
            get { return this.m_Parent; }
            set { this.Parent = value; }
        }
       
        public _IncreaseCostsInfo(_ObjectInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }
        public void SetInfo(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.DH = row["Code"].ToString();
            this.JSJC = row["Calculation"].ToString();
            if (row["Additional"].ToString() == "")
            {
                this.FJJS = 0m;
            }
            else { this.FJJS = decimal.Parse(row["Additional"].ToString()); }
            
            this.XS = Convert.ToDecimal(row["Coefficient"]);

            if (row["Artificial"].ToString()=="")
            {
                this.RGXS = 0m;
            }
            else
            this.RGXS = Convert.ToDecimal(row["Artificial"]);
            if (row["Material"].ToString() == "")
            {
                this.CLXS = 0m;
            }
            else
                this.CLXS = Convert.ToDecimal(row["Material"]);

            if (row["Mechanical"].ToString() == "")
            {
                this.JXXS = 0m;
            }
            else
            this.JXXS =Convert.ToDecimal(row["Mechanical"]);
            
        }
        public void Begin()
        {
            string Dian="F2";
            decimal temp=0m;
            switch (this.JSJC)
            {

                case "rgf":
                    temp = this.Parent.RGFHJ;
                    break;
                case "clf":
                    temp = this.Parent.CLFHJ;
                    break;
                case "jxf":
                    temp = this.Parent.JXFHJ;
                    break;
                default:
                    break;
            }
            temp = temp + this.FJJS;

           // this.HJ
            
           decimal  d = temp * this.XS*0.01m;
           this.RGF = d * this.RGXS * 0.01m;
           this.RGF = ToolKit.ParseDecimal(this.RGF.ToString(Dian));
           this.CLF = d * this.CLXS * 0.01m;
           this.CLF = ToolKit.ParseDecimal(this.CLF.ToString(Dian));
           this.JXF = d * this.JXXS * 0.01m;
           this.JXF = ToolKit.ParseDecimal(this.JXF.ToString(Dian));
           this.HJ = this.RGF + this.CLF + this.JXF;
           this.HJ = ToolKit.ParseDecimal(this.HJ.ToString(Dian));
           //hu  PBegin();
        }
        private _ObjectInfo GetQIncreaseCosts()
        {
            _ObjectInfo info = null;
            _SubheadingsInfo info1 = this.Parent as _SubheadingsInfo;
            _MSubheadingsInfo info2 = this.Parent as _MSubheadingsInfo;
            if (info1 != null)
            {
                foreach (_ObjectInfo item in info1.Parent.IncreaseCostsList)
                {
                    if (item.XMBM == this.DH)
                    {
                        return item;
                    }
                }
            }
            if (info2 != null)
            {
                foreach (_ObjectInfo item in info2.Parent.IncreaseCostsList)
                {
                    if (item.XMBM == this.DH)
                    {
                        return item;
                    }

                }
            }

            return info;
        }
        /// <summary>
        /// 清单的下面的增加费计算
        /// </summary>
        private void PBegin()
        {
            _ObjectInfo info = GetQIncreaseCosts();
            _SubheadingsInfo info1 = info as _SubheadingsInfo;
            _MSubheadingsInfo info2 = info as _MSubheadingsInfo;
            if (info1 != null)
            {
                Result result = GetResult();
                info1.Statistics.ResultVarable.Set(_Statistics.FILED_RGFDJ, result.RGF);
                info1.Statistics.ResultVarable.Set(_Statistics.FILED_CLFDJ, result.CLF);
                info1.Statistics.ResultVarable.Set(_Statistics.FILED_JXFDJ, result.JXF);

                decimal temp = result.JXF + result.CLF + result.RGF;
                info1.Statistics.ResultVarable.Set(_Statistics.FILED_ZJFDJ, temp);
                info1.Statistics.ResultVarable.Set(_Statistics.FILED_ZHDJ, temp);
                info1.Begin();
            }

            if (info2 != null)
            {
                Result result = GetResult();
                info2.Statistics.ResultVarable.Set(_Statistics.FILED_RGFDJ, result.RGF);
                info2.Statistics.ResultVarable.Set(_Statistics.FILED_CLFDJ, result.CLF);
                info2.Statistics.ResultVarable.Set(_Statistics.FILED_JXFDJ, result.JXF);

                decimal temp = result.JXF + result.CLF + result.RGF;
                info2.Statistics.ResultVarable.Set(_Statistics.FILED_ZJFDJ, temp);
                info2.Statistics.ResultVarable.Set(_Statistics.FILED_ZHDJ, temp);
                info2.Begin();
            }        
        }

        public struct Result
        {
            public decimal RGF;
            public decimal CLF;
            public decimal JXF;
        }
        private Result GetResult()
        {
            Result result = new Result();

            _SubheadingsInfo info1 = this.Parent as _SubheadingsInfo;
            _MSubheadingsInfo info2 = this.Parent as _MSubheadingsInfo;
            if (info1!=null)
            {
                foreach (_SubheadingsInfo item in info1.Parent.SubheadingsList)
                {
                    if (item.LB == "子目")
                    {
                        result.CLF += (from n in item.IncreaseCostsList.Cast<_IncreaseCostsInfo>() where n.DH == this.DH select n.CLF).Sum();
                        result.RGF += (from n in item.IncreaseCostsList.Cast<_IncreaseCostsInfo>() where n.DH == this.DH select n.RGF).Sum();
                        result.JXF += (from n in item.IncreaseCostsList.Cast<_IncreaseCostsInfo>() where n.DH == this.DH select n.JXF).Sum();

                    }
                }
            }
            if (info2!=null)
            {
                 foreach (_SubheadingsInfo item in info2.Parent.SubheadingsList)
                {
                    if (item.LB == "子目")
                    {
                        result.CLF += (from n in item.IncreaseCostsList.Cast<_IncreaseCostsInfo>() where n.DH == this.DH select n.CLF).Sum();
                        result.RGF += (from n in item.IncreaseCostsList.Cast<_IncreaseCostsInfo>() where n.DH == this.DH select n.RGF).Sum();
                        result.JXF += (from n in item.IncreaseCostsList.Cast<_IncreaseCostsInfo>() where n.DH == this.DH select n.JXF).Sum();

                    }
                }
            }
            return result;
        }
    }
}
