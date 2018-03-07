using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_Quantity
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
        /// 当前操作的工料机
        /// </summary>
        private DataRow m_Current = null;
        /// <summary>
        /// 获取或设置：当前操作的工料机
        /// </summary>
        public DataRow Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }
        /// <summary>
        /// 当前工料机父级
        /// </summary>
        private DataRow m_Parent = null;
        /// <summary>
        /// 获取或设置：当前工料机父级
        /// </summary>
        public DataRow Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        public _Methods_Quantity() { }

        public _Methods_Quantity(_UnitProject p_Unit)
        {
            this.m_Unit = p_Unit;
        }

        public _Methods_Quantity(_UnitProject p_Unit, DataRow p_Info)
        {
            this.m_Current = p_Info;
            this.m_Unit = p_Unit;
        }

        public _Methods_Quantity(_UnitProject p_Unit, DataRow p_Parent, DataRow p_Info)
        {
            this.m_Unit = p_Unit;
            this.m_Parent = p_Parent;
            this.m_Current = p_Info;
        }

        /// <summary>
        /// 创建工料机组成
        /// </summary>
        /// <returns>工料机组成对象</returns>
        public void Create()
        {
            DataRow[] drs_zc = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["配合比表"].Select(string.Format("CAIJBH ='{0}'", this.Parent["YSBH"].ToString()));
            foreach (DataRow dr in drs_zc)
            {
                DataRow[] dr_zc = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"].Select(string.Format("CAIJBH ='{0}'", dr["PHB_CJBH"]));
                if (dr_zc != null)
                {
                    DataRow info = this.Unit.StructSource.ModelQuantity.NewRow();
                    info["YSBH"] = dr_zc[0]["CAIJBH"];
                    info["YSMC"] = dr_zc[0]["CAIJMC"];
                    info["YSDW"] = dr_zc[0]["CAIJDW"];
                    info["YSXHL"] = ToolKit.ParseDecimal(dr["PHB_CJSL"]);
                    info["BH"] = dr_zc[0]["CAIJBH"];
                    info["MC"] = dr_zc[0]["CAIJMC"];
                    info["DW"] = dr_zc[0]["CAIJDW"];
                    info["XHL"] = ToolKit.ParseDecimal(dr["PHB_CJSL"]);
                    info["DEDJ"] = ToolKit.ParseDecimal(dr_zc[0]["CAIJDJ"]);
                    info["LB"] = dr_zc[0]["CAIJLB"];
                    if (this.Parent["LB"].Equals("配合比"))
                    {
                        info["ZCLB"] = "P";
                    }
                    else if (this.Parent["LB"].ToString().Contains("台班"))
                    {
                        info["ZCLB"] = "J";
                    }
                    info["SDCLB"] = dr_zc[0]["SANDCMC"];
                    info["SDCXS"] = ToolKit.ParseDecimal(dr_zc[0]["SANDCXS"]);
                    info["GCL"] = this.Parent["SL"];
                    info["SSKLB"] = this.Parent["SSKLB"];
                    DataRow row = this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", info["BH"].ToString())).FirstOrDefault();
                    if (row == null)
                    {
                        info["IFSC"] = dr_zc[0]["CAIJSC"].Equals("是") ? true : false;
                        info["IFZYCL"] = dr_zc[0]["CAIJXSJG"].Equals("是") ? true : false;
                        info["IFFX"] = false;
                        info["IFSDSCDJ"] = false;

                        info["YTLB"] = string.Empty;
                        info["JSDJ"] = 0m;
                        info["CJ"] = string.Empty;
                        info["PP"] = string.Empty;
                        info["ZLDJ"] = string.Empty;
                        info["GYS"] = string.Empty;
                        info["CD"] = string.Empty;
                        info["CJBZ"] = string.Empty;
                        info["SCDJ"] = info["DEDJ"];
                    }
                    else
                    {
                        info["IFSC"] = ToolKit.ParseBoolen(row["IFSC"]);
                        info["IFFX"] = ToolKit.ParseBoolen(row["IFFX"]);
                        info["IFSDSCDJ"] = ToolKit.ParseBoolen(row["IFSDSCDJ"]);
                        info["IFZYCL"] = ToolKit.ParseBoolen(row["IFZYCL"]);
                        info["YTLB"] = row["YTLB"];
                        info["SCDJ"] = ToolKit.ParseDecimal(row["SCDJ"]);
                        info["JSDJ"] = ToolKit.ParseDecimal(row["JSDJ"]);
                        info["CJ"] = row["CJ"];
                        info["PP"] = row["PP"];
                        info["ZLDJ"] = row["ZLDJ"];
                        info["GYS"] = row["GYS"];
                        info["CD"] = row["CD"];
                        info["CJBZ"] = row["CJBZ"];
                    }
                    if (info["LB"].Equals("主材") || info["LB"].Equals("设备"))
                    {
                        info["DEDJ"] = info["SCDJ"];
                    }
                    info["EnID"] = this.Parent["EnID"];
                    info["UnID"] = this.Parent["UnID"];
                    info["ZMID"] = this.Parent["ZMID"];
                    info["QDID"] = this.Parent["QDID"];
                    info["PID"] = this.Parent["ID"];
                    info["SSLB"] = this.Parent["SSLB"];
                    info["CTIME"] = DateTime.Now;
                    this.Unit.StructSource.ModelQuantity.Rows.Add(info);

                }
            }
            if (this.Parent["IFKFJ"].Equals(true))
            {
                this.CalculateParentSCDJ();
            }
        }

        /// <summary>
        /// 创建：子目工料机创建组成
        /// </summary>
        public bool Create(DataRow p_info)
        {
            if (this.Parent == null || p_info == null) return false;
            if (this.Contains(p_info)) return false;
            DataRow info = this.Unit.StructSource.ModelQuantity.NewRow();
            info["EnID"] = this.Parent["EnID"];
            info["UnID"] = this.Parent["UnID"];
            info["QDID"] = this.Parent["QDID"];
            info["ZMID"] = this.Parent["ZMID"];
            info["SSLB"] = this.Parent["SSLB"];
            info["SSKLB"] = this.Parent["SSKLB"];
            info["PID"] = this.Parent["ID"];
            info["YSBH"] = p_info["YSBH"];
            info["YSMC"] = p_info["YSMC"];
            info["YSDW"] = p_info["YSDW"];
            info["YSXHL"] = 1m;
            info["DEDJ"] = p_info["DEDJ"];
            info["BH"] = p_info["BH"];
            info["MC"] = p_info["MC"];
            info["DW"] = p_info["DW"];
            info["XHL"] = 1m;
            info["SCDJ"] = p_info["SCDJ"];
            info["LB"] = p_info["LB"];
            if (this.Parent["LB"].Equals("配合比"))
            {
                info["ZCLB"] = "P";
            }
            else if (this.Parent["LB"].ToString().Contains("台班"))
            {
                info["ZCLB"] = "J";
            }
            info["SDCLB"] = p_info["SDCLB"];
            info["SDCXS"] = p_info["SDCXS"];
            info["GCL"] = this.Parent["SL"];
            if(info["LB"].Equals("主材") || info["LB"].Equals("设备"))
            {
                info["DEDJ"] = p_info["SCDJ"];
            }
            info["SCDJ"] = p_info["SCDJ"];
            info["IFSC"] = p_info["IFSC"];
            info["IFFX"] = p_info["IFFX"];
            info["IFSDSCDJ"] = p_info["IFSDSCDJ"];
            info["IFZYCL"] = p_info["IFZYCL"];
            info["YTLB"] = p_info["YTLB"];
            info["JSDJ"] = p_info["JSDJ"];
            info["CJ"] = p_info["CJ"];
            info["PP"] = p_info["PP"];
            info["ZLDJ"] = p_info["ZLDJ"];
            info["GYS"] = p_info["GYS"];
            info["CD"] = p_info["CD"];
            info["CJBZ"] = p_info["CJBZ"];
            info["CTIME"] = DateTime.Now;
            this.Unit.StructSource.ModelQuantity.Rows.InsertAt(info, this.GetIndex());
            if (this.Parent != null)
            {
                _Methods_Quantity.CalculateParentSCDJ(this.Parent);
            }
            return true;
        }

        /// <summary>
        /// 替换工料机
        /// </summary>
        /// <param name="p_ysinfo"></param>
        /// <param name="p_info"></param>
        /// <returns></returns>
        public bool ReplaceGLJ(DataRow p_info)
        {
            if (this.Parent == null || this.Current == null || p_info == null) return false;
            if (this.Contains(p_info)) return false;
            this.Current.BeginEdit();
            this.Current["EnID"] = this.Current["EnID"];
            this.Current["UnID"] = this.Current["UnID"];
            this.Current["QDID"] = this.Current["QDID"];
            this.Current["ZMID"] = this.Current["ZMID"];
            this.Current["PID"] = this.Current["PID"];
            this.Current["SSLB"] = this.Current["SSLB"];
            this.Current["SSKLB"] = this.Current["SSKLB"];
            this.Current["YSBH"] = p_info["YSBH"];
            this.Current["YSMC"] = p_info["YSMC"];
            this.Current["YSDW"] = p_info["YSDW"];
            //this.Current["YSXHL"] = 1m;
            this.Current["DEDJ"] = p_info["DEDJ"];
            this.Current["BH"] = p_info["BH"];
            this.Current["MC"] = p_info["MC"];
            this.Current["DW"] = p_info["DW"];
            //this.Current["XHL"] = 1m;
            this.Current["SCDJ"] = p_info["SCDJ"];
            this.Current["LB"] = p_info["LB"];
            this.Current["ZCLB"] = this.Current["ZCLB"];
            this.Current["SDCLB"] = p_info["SDCLB"];
            this.Current["SDCXS"] = p_info["SDCXS"];
            this.Current["GCL"] = this.Current["SL"];
            if (this.Current["LB"].Equals("主材") || this.Current["LB"].Equals("设备"))
            {
                this.Current["DEDJ"] = p_info["SCDJ"];
            }
            this.Current["SCDJ"] = p_info["SCDJ"];
            this.Current["IFSC"] = p_info["IFSC"];
            this.Current["IFFX"] = p_info["IFFX"];
            this.Current["IFSDSCDJ"] = p_info["IFSDSCDJ"];
            this.Current["IFZYCL"] = p_info["IFZYCL"];
            this.Current["YTLB"] = p_info["YTLB"];
            this.Current["JSDJ"] = p_info["JSDJ"];
            this.Current["CJ"] = p_info["CJ"];
            this.Current["PP"] = p_info["PP"];
            this.Current["ZLDJ"] = p_info["ZLDJ"];
            this.Current["GYS"] = p_info["GYS"];
            this.Current["CD"] = p_info["CD"];
            this.Current["CJBZ"] = p_info["CJBZ"];
            this.Current.EndEdit();
            if (this.Parent != null)
            {
                _Methods_Quantity.CalculateParentSCDJ(this.Parent);
            }
            return true;
        }

        /// <summary>
        /// 获取插入位置
        /// </summary>
        /// <returns></returns>
        private int GetIndex()
        {
            if (this.Current == null) return 0;
            if (this.Current["ZCLB"].Equals("W")) return 0;
            int index = this.Unit.StructSource.ModelQuantity.Rows.IndexOf(this.Current);
            if (index == -1)
            {
                return 0;
            }
            return index + 1;
        }

        /// <summary>
        /// 验证：是否存在此工料机
        /// </summary>
        /// <param name="p_info">工料机</param>
        /// <returns>是否</returns>
        private bool Contains(DataRow p_info)
        {
            bool result = false;
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", p_info["BH"]));
            if (drs.Length > 0)
            {
                int count = drs.Where(p => p["SSLB"].Equals(this.Parent["SSLB"]) && p["QDID"].Equals(this.Parent["QDID"]) && p["ZMID"].Equals(this.Parent["ZMID"]) && p["PID"].Equals(this.Parent["ID"])).Count();
                if (count == 0)
                {
                    DataRow dr = drs.FirstOrDefault();
                    p_info.BeginEdit();
                    p_info["IFSC"] = dr["IFSC"];
                    p_info["IFFX"] = dr["IFFX"];
                    p_info["IFSDSCDJ"] = dr["IFSDSCDJ"];
                    p_info["IFZYCL"] = dr["IFZYCL"];
                    p_info["YTLB"] = dr["YTLB"];
                    p_info["SCDJ"] = dr["SCDJ"];
                    p_info["JSDJ"] = dr["JSDJ"];
                    p_info["SDCLB"] = dr["SDCLB"];
                    p_info["SDCXS"] = dr["SDCXS"];
                    p_info["CJ"] = dr["CJ"];
                    p_info["PP"] = dr["PP"];
                    p_info["ZLDJ"] = dr["ZLDJ"];
                    p_info["GYS"] = dr["GYS"];
                    p_info["CD"] = dr["CD"];
                    p_info["CJBZ"] = dr["CJBZ"];
                    p_info.EndEdit();
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 创建三大材
        /// </summary>
        /// <returns></returns>
        private DataTable CreateSDC()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("BH", typeof(string));
            dt.Columns.Add("MC", typeof(string));
            dt.Columns.Add("DW", typeof(string));
            dt.Columns.Add("SLH", typeof(decimal));
            dt.Columns.Add("SCDJ", typeof(decimal));
            dt.Columns.Add("SCHJ", typeof(decimal));
            dt.Columns.Add("SDCSLH", typeof(decimal));
            DataRow drgc = dt.NewRow();
            drgc["ID"] = 1;
            drgc["ParentID"] = -1;
            drgc["MC"] = "钢材";
            drgc["DW"] = "吨";
            drgc["SLH"] = 0m;
            dt.Rows.Add(drgc);
            DataRow drmc = dt.NewRow();
            drmc["ID"] = 2;
            drmc["ParentID"] = -1;
            drmc["MC"] = "木材";
            drmc["DW"] = "立方米";
            drmc["SLH"] = 0m;
            dt.Rows.Add(drmc);
            DataRow drsn = dt.NewRow();
            drsn["ID"] = 3;
            drsn["ParentID"] = -1;
            drsn["MC"] = "水泥";
            drsn["DW"] = "吨";
            drsn["SLH"] = 0m;
            dt.Rows.Add(drsn);
            return dt;
        }

        /// <summary>
        /// 获取三大材
        /// </summary>
        /// <returns></returns>
        public DataTable GetSDC(DataTable dt)
        {
            DataTable m_dt = this.CreateSDC();
            DataRow[] drs = dt.Select(string.Format("SDCLB <> '{0}'", string.Empty));
            foreach (DataRow item in drs)
            {
                DataRow dr = m_dt.NewRow();
                switch (item["SDCLB"].ToString())
                {
                    case "钢材":
                        dr["ParentID"] = 1;
                        break;
                    case "木材":
                        dr["ParentID"] = 2;
                        break;
                    case "水泥":
                        dr["ParentID"] = 3;
                        break;
                    default:
                        break;
                }
                dr["ID"] = (m_dt.Rows.Count + 1);
                dr["BH"] = item["BH"];
                dr["MC"] = item["MC"];
                dr["DW"] = item["DW"];
                dr["SLH"] = item["SL"];
                dr["SCDJ"] = item["SCDJ"];
                dr["SCHJ"] = ToolKit.ParseDecimal(item["SCDJ"]) * ToolKit.ParseDecimal(item["SL"]);
                if (!item["SDCXS"].Equals(0M))
                {
                    dr["SDCSLH"] = ToolKit.ParseDecimal(item["SL"]) * ToolKit.ParseDecimal(item["SDCXS"]);
                }
                m_dt.Rows.Add(dr);
            }
            m_dt.Select("ID=1")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 1");
            m_dt.Select("ID=2")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 2");
            m_dt.Select("ID=3")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 3");
            return m_dt;
        }

        /// <summary>
        /// 计算父级市场单价
        /// </summary>
        /// <param name="p_Info">材料</param>
        /// <param name="p_UnName">当前单位工程名称</param>
        public static void CalculateParentSCDJ(DataRow p_Info)
        {
            DataRow[] m_ChildRows = p_Info.GetChildRows("工料机-组成");
            object m_scdj = p_Info["SCDJ"];
            p_Info.BeginEdit();
            p_Info["DEDJ"] = m_ChildRows.Sum(p => ToolKit.ParseDecimal(p["DEHJ"])).ToString("0.00");
            p_Info["SCDJ"] = m_ChildRows.Sum(p => ToolKit.ParseDecimal(p["SCHJ"])).ToString("0.00");
            p_Info.EndEdit();
            APP.UserPriceLibrary.Update("SCDJ", m_scdj, p_Info);
        }

        /// <summary>
        /// 计算父级市场单价
        /// </summary>
        /// <param name="p_Status"></param>
        public void CalculateParentSCDJ()
        {
            this.Parent.BeginEdit();
            this.Parent["DEDJ"] = ToolKit.Formart(this.Unit.StructSource.ModelQuantity.Compute("Sum(DEHJ)", string.Format("PID={0}", this.Parent["ID"])), 2);
            this.Parent["SCDJ"] = ToolKit.Formart(this.Unit.StructSource.ModelQuantity.Compute("Sum(SCHJ)", string.Format("PID={0}", this.Parent["ID"])), 2);
            this.Parent.EndEdit();
        }

        /// <summary>
        /// 行计算及父级市场价
        /// </summary>
        /// <param name="p_Activitie"></param>
        /// <param name="p_info"></param>
        public static void RowCalculateAndParentSCDJ(DataRow p_info)
        {
            DataRow p_dr = p_info.GetParentRow("工料机-组成");
            if (p_dr != null)
            {
                _Methods_Quantity.CalculateParentSCDJ(p_dr);
            }
        }

        /// <summary>
        /// 修改组成工程量
        /// </summary>
        /// <param name="p_DataRow"></param>
        public static void UpdateZCGCL(DataRow p_DataRow)
        {
            DataRow[] drs = p_DataRow.GetChildRows("工料机-组成");
            foreach (DataRow item in drs)
            {
                item.BeginEdit();
                item["GCL"] = p_DataRow["SL"];
                item.EndEdit();
            }
        }
    }
}
