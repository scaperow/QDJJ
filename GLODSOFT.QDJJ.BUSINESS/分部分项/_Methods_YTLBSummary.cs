using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.ZBS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_YTLBSummary
    {
        private _UnitProject m_Unit = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary>
        public _UnitProject Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }

        /// <summary>
        /// 当前操作的用途类别
        /// </summary>
        private _Entity_YTLBSummary m_Current = null;
        /// <summary>
        /// 获取或设置：当前操作的用途类别
        /// </summary>
        public _Entity_YTLBSummary Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        public _Methods_YTLBSummary(_UnitProject p_Unit)
        {
            this.m_Unit = p_Unit;
        }

        public _Methods_YTLBSummary(_UnitProject p_Unit, _Entity_YTLBSummary p_Info)
        {
            this.m_Current = p_Info;
            this.m_Unit = p_Unit;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="p_Info">材料信息</param>
        /// <param name="p_Automatic">是否自动绑定</param>
        /// <returns>是否成功</returns>
        public DataRow Insert(DataRow p_Info, bool p_Automatic)
        {
            return Insert(0, p_Info, p_Automatic);
        }

        ///// <summary>
        ///// 插入
        ///// </summary>
        ///// <param name="p_Index">插入位置</param>
        ///// <param name="p_Info">材料信息</param>
        ///// <param name="p_Automatic">是否自动绑定</param>
        ///// <returns>是否成功</returns>
        //public DataRow Insert(int p_Index, _Entity_QuantityUnit p_Info, bool p_Automatic)
        //{
        //    DataRow m_info = this.GetBindingInfo(p_Info.BH.ToString());
        //    if (m_info != null) return m_info;
        //    DataRow new_info = this.Unit.StructSource.ModelYTLBSummary.NewRow();
        //    new_info["BDBH"] = p_Automatic ? p_Info.BH : string.Empty;
        //    new_info["BH"] = p_Info.BH;
        //    new_info["MC"] = p_Info.MC;
        //    new_info["DW"] = p_Info.DW;
        //    new_info["GGXH"] = p_Info.GGXH;
        //    new_info["DEDJ"] = p_Info.DEDJ;
        //    new_info["SCDJ"] = p_Info.SCDJ;
        //    new_info["JSDJ"] = p_Info.JSDJ;
        //    new_info["SLH"] = p_Info.SLH;
        //    new_info["YTLB"] = p_Info.YTLB;
        //    //_Methods_Quantity.SummaryRowCalculate(new_info);
        //    p_Index = p_Index > 0 ? p_Index : 0;
        //    this.Unit.StructSource.ModelYTLBSummary.Rows.InsertAt(new_info, p_Index);
        //    return null;
        //}

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="p_Index">插入位置</param>
        /// <param name="p_Info">材料信息</param>
        /// <param name="p_Automatic">是否自动绑定</param>
        /// <returns>是否成功</returns>
        public DataRow Insert(int p_Index, DataRow p_Info, bool p_Automatic)
        {
            DataRow m_info = this.GetBindingInfo(p_Info["BH"].ToString());
            if (m_info != null) return m_info;
            DataRow new_info = this.Unit.StructSource.ModelYTLBSummary.NewRow();
            new_info["ENID"] = this.m_Unit.PID;
            new_info["UNID"] = this.m_Unit.ID;
            new_info["BDBH"]= p_Automatic ? p_Info["BH"] : string.Empty;
            new_info["BH"] = p_Info["BH"];
            new_info["MC"] = p_Info["MC"];
            new_info["DW"] = p_Info["DW"];
            new_info["GGXH"] = p_Info["GGXH"];
            new_info["DEDJ"] = p_Info["DEDJ"];
            new_info["SCDJ"] = p_Info["SCDJ"];
            new_info["JSDJ"] = p_Info["JSDJ"];
            new_info["GCL"] = 1 ;
            new_info["XHL"] = p_Info["SL"];
            new_info["YTLB"] = p_Info["YTLB"];
            new_info["CTIME"] = DateTime.Now;
            new_info["IFZYCL"] = true;
            if (p_Index == -1) p_Index = 1;
            this.Unit.StructSource.ModelYTLBSummary.Rows.InsertAt(new_info,p_Index);
            return null;
        }

        public DataRow InsertByXML(int p_Index, DataRow p_Info, bool p_Automatic,List<人材机> rcjList)
        {
            DataRow m_info = this.GetBindingInfo(p_Info["BH"].ToString());
            if (m_info != null) return m_info;
            DataRow new_info = this.Unit.StructSource.ModelYTLBSummary.NewRow();
            new_info["ENID"] = p_Info["ENID"];
            new_info["UNID"] = p_Info["UNID"];
            new_info["BDBH"] = p_Automatic ? p_Info["BH"] : string.Empty;
            new_info["BH"] = p_Info["BH"];
            new_info["MC"] = p_Info["MC"];
            new_info["DW"] = p_Info["DW"];
            new_info["GGXH"] = p_Info["GGXH"];

            DataRow[] gljRow = p_Info.Table.Select("BH = '" + p_Info["BH"].ToString() + "'");

            if (gljRow.Length > 0)
            {
                //new_info["DEDJ"] = p_Info["DEDJ"];
                new_info["DEDJ"] = gljRow[0]["DEDJ"];
                new_info["DEHJ"] = gljRow[0]["DEHJ"];
            }
            else
            {
                foreach (人材机 rcj in rcjList)
                {
                    if (rcj.甲供材料关联号.Equals(p_Info["BH"].ToString()) || rcj.评审材料关联号.Equals(p_Info["BH"].ToString()) || rcj.暂估价材料关联号.Equals(p_Info["BH"].ToString()))
                    {
                        if (string.IsNullOrEmpty(rcj.定额价))
                        {
                            new_info["DEDJ"] = "0";
                        }
                        else
                        {
                            new_info["DEDJ"] = rcj.定额价;
                        }
                        break;
                    }
                }

            }
            new_info["SCDJ"] = p_Info["SCDJ"];
            new_info["JSDJ"] = p_Info["JSDJ"];
            new_info["GCL"] = 1;
            new_info["XHL"] = p_Info["SL"];
            new_info["YTLB"] = p_Info["YTLB"];
            new_info["CTIME"] = DateTime.Now;
            new_info["IFZYCL"] = true;
            for (int j = 0; j < rcjList.Count; j++)
            {
                if (new_info["BH"].Equals(rcjList[j].甲供材料关联号) ||
                    new_info["BH"].Equals(rcjList[j].评审材料关联号) ||
                    new_info["BH"].Equals(rcjList[j].暂估价材料关联号))
                {
                    new_info["BDBH"] = rcjList[j].材料号;
                    
                }
            }

            if (string.IsNullOrEmpty(new_info["DEDJ"].ToString()))
            {
                new_info["DEDJ"] = new_info["SCDJ"];
                //new_info["DEHJ"] = Math.Round(ToolKit.ParseDecimal(new_info["SCDJ"].ToString()));

            }

            if (p_Index == -1) p_Index = 1;
            this.Unit.StructSource.ModelYTLBSummary.Rows.InsertAt(new_info, p_Index);
            return new_info;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_info"></param>
        public void Remove(DataRow p_info)
        {
            this.CanceledBinding(p_info);
            p_info.Delete();
        }

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="p_YTLB">原信息</param>
        /// <param name="p_info">新信息</param>
        /// <param name="iszd"></param>
        /// <returns></returns>
        public bool Replace(DataRow p_YTLB, DataRow p_info)
        {
            if (p_YTLB == null) return false;
            if (p_info == null) return false;
            this.CanceledBinding(p_YTLB);
            p_YTLB.BeginEdit();
            p_YTLB["BDBH"] = p_info["BH"];
            p_YTLB["XHL"] = p_info["SL"];
            p_YTLB["DEDJ"] = p_info["DEDJ"];
            p_YTLB["JSDJ"] = p_info["JSDJ"];
            if (p_YTLB["YTLB"].Equals(UseType.甲供材料.ToString()) || p_YTLB["YTLB"].Equals(UseType.暂定价材料.ToString()))
            {
                p_info.BeginEdit();
                p_info["SCDJ"] = p_YTLB["SCDJ"];
                APP.UserPriceLibrary.Update("SCDJ", p_info["SCDJ", DataRowVersion.Current], p_info);
                p_info.EndEdit();
            }
            else
            {
                p_YTLB["SCDJ"] = p_info["SCDJ"];
            }
            p_YTLB.EndEdit();
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", p_info["BH"]));
            foreach (DataRow item in drs)
            {
                item.BeginEdit();
                item["YTLB"] = p_YTLB["YTLB"];
                item.EndEdit();
                string m_NewSubheadings = item["EnID"] + "," + item["UnID"] + "," + item["SSLB"] + "," + item["ZMID"] + "|";
                if (!APP.UserPriceLibrary.SubheadingsInfo.Contains(m_NewSubheadings))
                {
                    APP.UserPriceLibrary.SubheadingsInfo += m_NewSubheadings;
                }
            }
            return true;
        }

        /// <summary>
        /// 取消绑定
        /// </summary>
        /// <param name="p_info"></param>
        public void CanceledBinding(DataRow p_info)
        {
            if (p_info == null) return;
            if (p_info["BDBH"].Equals(string.Empty)) return;
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}'",p_info["BDBH"]));
            foreach (DataRow item in drs)
            {
                item.BeginEdit();
                item["YTLB"] = string.Empty;
                item.EndEdit();
                string m_NewSubheadings = item["EnID"] + "," + item["UnID"] + "," + item["SSLB"] + "," + item["ZMID"] + "|";
                if (!APP.UserPriceLibrary.SubheadingsInfo.Contains(m_NewSubheadings))
                {
                    APP.UserPriceLibrary.SubheadingsInfo += m_NewSubheadings;
                }
            }
            p_info["BDBH"] = string.Empty;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public DataRow GetInfo(string p_BH)
        {
            return this.Unit.StructSource.ModelYTLBSummary.Select(string.Format("BH='{0}'", p_BH)).FirstOrDefault();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public DataRow GetBDBHInfo(string p_BH)
        {
            return this.Unit.StructSource.ModelYTLBSummary.Select(string.Format("BDBH='{0}'", p_BH)).FirstOrDefault();
        }

        /// <summary>
        /// 获取绑定对象
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public DataRow GetBindingInfo(string p_BH)
        {
            return this.Unit.StructSource.ModelYTLBSummary.Select(string.Format("BDBH='{0}' OR BH='{1}'", p_BH, p_BH)).FirstOrDefault();
        }

        public void RefreshSL()
        {
            DataRow[] dts = this.Unit.StructSource.ModelYTLBSummary.Select("BDBH<>''");
            foreach (DataRow item in dts)
            {
                item["GCL"] =1m;
                item["XHL"] = this.Unit.StructSource.ModelQuantity.Compute("SUM(SL)", string.Format("BH='{0}'", item["BDBH"]));
            }
        }

        public void RefreshSCDJ(DataRow p_dr)
        {
            if (p_dr == null) return;
            if (p_dr["YTLB"].Equals(UseType.评标指定材料.ToString()) || p_dr["YTLB"].Equals(UseType.甲定乙供材料.ToString()))
            {
                DataRow dr = this.Unit.StructSource.ModelYTLBSummary.Select(string.Format("BDBH ='{0}'", p_dr["BH"])).FirstOrDefault();
                if (dr != null)
                {
                    if (!dr["SCDJ"].Equals(p_dr["SCDJ"]))
                    {
                        dr["SCDJ"] = p_dr["SCDJ"];
                        if (dr["LB"].Equals("主材") || dr["LB"].Equals("设备"))
                        {
                            dr["DEDJ"] = p_dr["SCDJ"];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 自动绑定
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public void AutoBindingInfo(string p_UseType)
        {
            DataRow[] dts = this.Unit.StructSource.ModelYTLBSummary.Select(string.Format("BDBH='{0}' AND YTLB='{1}'", string.Empty, p_UseType.ToString()));
            foreach (DataRow item in dts)
            {
                DataRow m_info = GetBDBHInfo(item["BH"].ToString());
                if (m_info == null)
                {
                    DataRow[] drsg= this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", item["BH"]));
                    if (drsg.Length > 0)
                    {
                        DataRow m_defanyl = drsg.FirstOrDefault();
                        item.BeginEdit();
                        item["BDBH"] = m_defanyl["BH"];
                        item["GCL"] = 1;
                        item["XHL"] = drsg.Sum(p => Convert.ToDecimal(p["SL"]));
                        item["DEDJ"] = m_defanyl["DEDJ"];
                        if (item["YTLB"].Equals(UseType.甲供材料.ToString()) || item["YTLB"].Equals(UseType.暂定价材料.ToString()))
                        {
                            m_defanyl.BeginEdit();
                            m_defanyl["SCDJ"] = item["SCDJ"];
                            APP.UserPriceLibrary.Update("SCDJ", m_defanyl["SCDJ", DataRowVersion.Current], m_defanyl);
                            m_defanyl.EndEdit();
                        }
                        else
                        {
                            item["SCDJ"] = m_defanyl["SCDJ"];
                        }
                        item.EndEdit();
                        foreach (DataRow items in drsg)
                        {
                            items.BeginEdit();
                            items["YTLB"] = item["YTLB"];
                            items.EndEdit();
                            string m_NewSubheadings = items["EnID"] + "," + items["UnID"] + "," + items["SSLB"] + "," + items["ZMID"] + "|";
                            if (!APP.UserPriceLibrary.SubheadingsInfo.Contains(m_NewSubheadings))
                            {
                                APP.UserPriceLibrary.SubheadingsInfo += m_NewSubheadings;
                            }
                        }
                    }
                }
            }
        }
    }
}
