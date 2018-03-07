using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UnitSummary
    {
        public _UnitSummary()
        {

        }

        private CTEntitiesQuantityUnitSummary m_Source;
        private UnitSummaryStruct m_Struct;

       /// <summary>
       /// 当前返回的汇总信息
       /// </summary>
        public CTEntitiesQuantityUnitSummary Source
        {
           // set { this.m_Source = value; }
            get { return m_Source; }
        }
       
        public _UnitSummary(UnitSummaryStruct Ustruct)
        {
            m_Source = new CTEntitiesQuantityUnitSummary();
            this.m_Struct = Ustruct;
            switch (Ustruct.SummaryType)
            {
                case UnitSummaryType.清单:
                    QDSummary();
                    //清单的汇总
                    break;
                case UnitSummaryType.单位工程:
                    UnitSummary();
                    //单位工程汇总
                    break;
                case UnitSummaryType.工料机汇总:
                    QuantityUnitSummary();
                    //工料机汇总
                    break;
                case UnitSummaryType.分解配合比:
                    DecompositionMix();
                    //分解配合比
                    break;
                case UnitSummaryType.分解机械台班:
                    JiXieTaiBan();
                    //分解机械台班
                    break;
                default:
                    break;
            }
        }


        private void QDSummary()
        {
            DataRow[] rows = m_Struct.p_Source.Select(string.Format("QID={0}", this.m_Struct.id));
            getSumary(rows);
        }

        private void UnitSummary()
        {
            DataRow[] rows = m_Struct.p_Source.Select(string.Format("SSXMLB='{0}'", "分部分项"));
            getSumary(rows);
        }


        /// <summary>
        /// 工料机汇总
        /// </summary>
        private void QuantityUnitSummary()
        {
            DataRow[] rows = m_Struct.p_Source.Select(string.Format("LB='{0}'", "工料机汇总"));
            getSumary(rows);
        }


        /// <summary>
        /// 分解配合比
        /// </summary>
        private void DecompositionMix()
        {
            //DataRow[] rows = m_Struct.jx_Source.Select(string.Format("LB='P'"));
            //getSumary(rows);
            
        }


        /// <summary>
        /// 分解机械台班
        /// </summary>
        private void JiXieTaiBan()
        {
            //DataRow[] rows = m_Struct.jx_Source.Select(string.Format("LB='{0}'", "分解机械台班"));
            //getSumary(rows);
        }


        private void getSumary(DataRow[] rows)
        {
           foreach (DataRow row in rows)
           {
          
                string caijbh = row.Field<String>("BH");
                DataRow row0 = null;
                //若同工料编号的没有汇总则添加
               bool flag = IsExist(caijbh, out row0);
               if (flag)
               {
                   CEntityQuantityUnitSummary info = new CEntityQuantityUnitSummary();
                   info.ID = row.Field<Int32>("ID");
                   info.ZCID = row.Field<Int32>("ZCID");//组成编号
                   //info.ZCLB = row.Field<String>("ZCLB");//组成类别
                   info.CJXXID = row.Field<Int32>("CJXXID");//厂家信息编号
                   info.DEDJ = row.Field<Decimal>("DEDJ");//定额单价
                   info.DEHJ = row.Field<Decimal>("DEHJ");//定额合价
                   info.BH = caijbh;//工料机编号
                   info.LB = row.Field<String>("LB");//类别
                   info.SDCLB = row.Field<String>("SDCLB");//三大材类别
                   info.SDCXS = row.Field<String>("SDCXS");//三大材系数
                   info.SDCHJ  =row.Field<Decimal>("SDCHJ");//三大材和价
                   info.MC = row.Field<String>("MC");//名称
                   info.GGXH = row.Field<String>("GGXH");//规格及型号
                   info.DW = row.Field<String>("DW");//单位
                   info.SCHJ = row.Field<Decimal>("SCHJ");//市场合价
                   info.SCDJ = row.Field<Decimal>("SCDJ");//市场单价
                   info.XHL = row.Field<Decimal>("XHL");//消耗量
                   info.SLH = row.Field<Decimal>("SLH");//数量和
                   info.DJC = row.Field<String>("DJC");//单价差
                   info.HJC = row.Field<Decimal>("HJC");//和价差
                   info.IFPB = row.Field<Boolean>("IFPB");//是否评标
                   info.IFZG = row.Field<Boolean>("IFZG");//是否暂定
                   info.IFJG = row.Field<Boolean>("IFJG");//是否甲供
                   info.IFYG = row.Field<Boolean>("IFYG");//是否乙供
                   info.IFFX = row.Field<Boolean>("IFFX");//是否风险
                   info.IFSDSCDJ = row.Field<Boolean>("IFSDSCDJ");//是否锁定市场价
                   info.SSXM =row.Field<String>("SSXM");//所属项目
                   info.SSXMLB = row.Field<String>("SSXMLB");//所属项目类别
                   info.GLJBZ  =row.Field<String>("GLJBZ");//工料机备注
                   info.GLJID =row.Field<String>("ZJCS");//增加次数
                  // info.MC = row.Field<String>("Caijysmc");
                   //info赋值并添加到结果集中
                   this.m_Source.AppendEntityInfo(info);
               }
               else
               {
                   row0["SLH"] = Convert.ToDecimal(row0["SLH"]) + Convert.ToDecimal(row["Caijxhlh"]);
                   row0["SCDJ"] = Convert.ToDecimal(row0["SCDJ"]) + Convert.ToDecimal(row["SCDJ"]) * Convert.ToDecimal(row["XHL"]);
                   //其他需要累加的 
               }
            }
        }
      

        private bool IsExist(string BH, out DataRow row)
        {
            bool flag = true;
           DataRow[] rows= this.m_Source.Select(string.Format("BH='{0}'", BH));
           if (rows != null)
           {
               if (rows.Length > 0)
               {
                   row = rows[0];
                   flag = false;
               }
               else
               {
                   row = null;
               }
           }
           else
           {
               row = null;
           }
            return flag;
        }
    }


    public struct UnitSummaryStruct
    {
        public UnitSummaryType SummaryType;
        public CTEntitiesQuantityUnit p_Source;
        public ArrayList jx_Source;
        public int id;
    }

    public enum UnitSummaryType
    {
       清单, 单位工程, 工料机汇总,分解配合比,分解机械台班,工料机
    }

}



