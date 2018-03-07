using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;
using System.Windows.Forms;
using System.IO;

namespace GLODSOFT.QDJJ.BUSINESS
{
/// <summary>
    /// 补充工料机库类操作类
    /// </summary>
    [Serializable]
    public class _RepairQuantityUnit
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _RepairQuantityUnit()
        {
            this.m_RepairQuantitySource = new _RepairQuantitySource();
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            try
            {
                string m_Path = string.Format("{0}库文件\\用户价格库\\{1}", APP.Application.Global.AppFolder.FullName, APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
                ToolKit.GetDirectoryInfo(m_Path);
                _Files files = new _Files();
                files.ExtName = _Files.补充材机库扩展名;
                files.DirName = m_Path;
                files.FileName = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {//文件存在的时候读取
                    _RepairQuantitySource cs = CFiles.Deserialize(files.FullName) as _RepairQuantitySource;
                    if (cs != null)
                    {
                        this.m_RepairQuantitySource = cs;
                    }
                }
                else
                {
                    this.m_RepairQuantitySource = new _RepairQuantitySource();
                    CFiles.BinarySerialize(this.m_RepairQuantitySource, files.FullName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            try
            {
                string m_Path = string.Format("{0}库文件\\用户价格库\\{1}", APP.Application.Global.AppFolder.FullName, APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
                ToolKit.GetDirectoryInfo(m_Path);
                _Files files = new _Files();
                files.ExtName = _Files.补充材机库扩展名;
                files.DirName = m_Path;
                files.FileName = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
                CFiles.BinarySerialize(this.m_RepairQuantitySource, files.FullName);
                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// 补充工料机集合
        /// </summary>
        private _RepairQuantitySource m_RepairQuantitySource = null;

        /// <summary>
        /// 获取或设置：补充工料机集合
        /// </summary>
        public _RepairQuantitySource RepairQuantitySource
        {
            get { return m_RepairQuantitySource; }
            set { m_RepairQuantitySource = value; }
        }

        /// <summary>
        /// 添加补充人才机
        /// </summary>
        /// <param name="new_info"></param>
        public void CreateZMGLJ(DataRow new_info)
        {
            DataRow info = this.RepairQuantitySource.NewRow();
            info["YSBH"] = new_info["YSBH"];
            info["YSMC"] = new_info["YSMC"];
            info["YSDW"] = new_info["YSDW"];
            info["DEDJ"] = new_info["DEDJ"];
            info["BH"] = new_info["BH"];
            info["MC"] = new_info["MC"];
            info["DW"] = new_info["DW"];
            info["LB"] = new_info["LB"];
            info["SCDJ"] = new_info["SCDJ"];
            info["SSDWGC"] = new_info["SSDWGC"];
            info["CTIME"] = DateTime.Now;
            info["CurrNo"] = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
            info["Status"] = "add";
            this.m_RepairQuantitySource.Rows.Add(info);
        }

        /// <summary>
        /// 移除被选择信息
        /// </summary>
        public void Remove()
        {
            DataRow[] drs = RepairQuantitySource.Select("XZ='True'");
            foreach (DataRow item in drs)
            {
                item.Delete();
            }
        }

        /// <summary>
        /// 过滤名称中的特殊字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetMC(string value)
        {
            string mc = value;
            if (mc != string.Empty)
            {
                mc = value.Replace("、", ",").Replace("安装", "").Remove(0, value.IndexOf(',') + 1);
            }
            return mc;
        }

        public bool BH_Exist(_UnitProject p_CUnitProject,string bh, bool isSaved)
        {
            if (isSaved)
            {
                DataRow dr = this.RepairQuantitySource.Select(string.Format("BH='{0}'", bh)).FirstOrDefault();
                if (dr == null)
                    return true;
            }
            else
            {
                DataRow dr = p_CUnitProject.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", bh)).FirstOrDefault();
                if (dr == null)
                    return true;
            }
            return false;
        }

        public bool Data_Exist(_UnitProject p_CUnitProject, string mc, string dw, string scdj, bool isSaved)
        {
            if (isSaved)
            {
                DataRow dr = this.RepairQuantitySource.Select("MC='" + mc + "' and DW='" + dw + "' and SCDJ=" + scdj).FirstOrDefault();
                if (dr == null)
                    return true;
            }
            else
            {
                DataRow dr = p_CUnitProject.StructSource.ModelQuantity.Select("MC='" + mc + "' and DW='" + dw + "' and SCDJ=" + scdj).FirstOrDefault();
                if (dr == null)
                    return true;
            }
            return false;
        }

        public string GetRepairBH(_UnitProject p_CUnitProject)
        {
            if (p_CUnitProject.StructSource.ModelQuantity == null) return "BC0001";
            string m_BH = string.Empty;
            for (int i = 1; i < p_CUnitProject.StructSource.ModelQuantity.Rows.Count + 2; i++)
            {
                m_BH = "BC" + i.ToString("0000");
                DataRow dr = p_CUnitProject.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", m_BH)).FirstOrDefault();
                if (dr == null)
                {
                    return m_BH;
                }
            }
            return "BC0001";
        }

        public string GetRepairBH()
        {
            if (this.RepairQuantitySource == null) return "BC0001";
            string m_BH = string.Empty;
            for (int i = 1; i < this.RepairQuantitySource.Rows.Count+2; i++)
            {
                m_BH = "BC" + i.ToString("0000");
                DataRow dr = this.RepairQuantitySource.Select(string.Format("BH='{0}'", m_BH)).FirstOrDefault();
                if (dr == null)
                {
                    return m_BH;
                }
            }
            return "BC0001";
        }

        public string GetRepairBH(_UnitProject p_CUnitProject, string p_LB)
        {
            DataRow[] list = p_CUnitProject.StructSource.ModelQuantity.Select(string.Format("BH like '%BC{0}%'", this.GetLB(p_LB)), "BH");
            if (list.Count() == 0) return ("BC" + this.GetLB(p_LB) + "0001");
            for (int i = 0, j = 1; j < list.Count(); i++, j++)
            {
                int info_i = ToolKit.ParseInt(list[i]["BH"].ToString().Substring(4));
                int info_j = ToolKit.ParseInt(list[j]["BH"].ToString().Substring(4));
                if ((info_j - info_i) > 1)
                {
                    return ("BC" + this.GetLB(p_LB) + (info_i + 1).ToString("0000"));
                }
            }

            int info_b = ToolKit.ParseInt(list.First()["BH"].ToString().Substring(4));
            if (info_b == 1)
            {
                return ("BC" + this.GetLB(p_LB) + (ToolKit.ParseInt(list.Last()["BH"].ToString().Substring(4)) + 1).ToString("0000"));
            }
            else
            {
                return ("BC" + this.GetLB(p_LB) + "0001");
            }
        }

        private string GetLB(string p_LB)
        {
            string m_LB = string.Empty;
            switch (p_LB)
            {
                case "主材":
                    m_LB = "ZC";
                    break;
                case "材料":
                    m_LB = "CL";
                    break;
                case "人工":
                    m_LB = "RG";
                    break;
                case "机械":
                    m_LB = "JX";
                    break;
                case "设备":
                    m_LB = "SB";
                    break;
                default:
                    break;
            }
            return m_LB;
        }
    }
}
