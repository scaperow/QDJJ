using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using System.IO;

namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 用户价格库
    /// </summary>
    public class _UserPriceLibrary
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _UserPriceLibrary()
        {
            this.m_UserPriceLibrarySource = new _UserPriceLibrarySource();
        }

        /// <summary>
        /// 用户价格库
        /// </summary>
        private _UserPriceLibrarySource m_UserPriceLibrarySource = null;

        /// <summary>
        /// 获取或设置：用户价格库
        /// </summary>
        public _UserPriceLibrarySource UserPriceLibrarySource
        {
            get { return m_UserPriceLibrarySource; }
            set { m_UserPriceLibrarySource = value; }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            try
            {
                string m_Path = string.Format("{0}库文件\\用户价格库\\{1}", APP.Application.Global.AppFolder.FullName,APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
                ToolKit.GetDirectoryInfo(m_Path);
                _Files files = new _Files();
                files.ExtName = _Files.用户价格库扩展名;
                files.DirName = m_Path;
                files.FileName = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {
                    //文件存在的时候读取
                    _UserPriceLibrarySource cs = CFiles.Deserialize(files.FullName) as _UserPriceLibrarySource;
                    if (cs != null)
                    {
                        
                        this.m_UserPriceLibrarySource = cs;
                    }
                }
                else
                {
                    this.m_UserPriceLibrarySource = new _UserPriceLibrarySource();
                    CFiles.BinarySerialize(this.m_UserPriceLibrarySource, files.FullName);
                }
            }
            catch (Exception e)
            {
                throw e;
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
                files.ExtName = _Files.用户价格库扩展名;
                files.DirName = m_Path;
                files.FileName = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
                CFiles.BinarySerialize(this.m_UserPriceLibrarySource, files.FullName);
                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// 发生改动的子目数据
        /// </summary>
        private string m_SubheadingsInfo = string.Empty;

        /// <summary>
        /// 获取或设置：发生改动的子目数据
        /// 格式：单项ID,单位ID,所属类别,子目ID|单项ID,单位ID,所属类别,子目ID|。。。
        /// </summary>
        public string SubheadingsInfo
        {
            get { return m_SubheadingsInfo; }
            set { m_SubheadingsInfo = value; }
        }

        /// <summary>
        /// 所有工料机
        /// </summary>
        private DataTable m_AllQuantityUnit = null;

        /// <summary>
        /// 获取或设置：所有工料机
        /// </summary>
        public DataTable AllQuantityUnit
        {
            get { return m_AllQuantityUnit; }
            set { m_AllQuantityUnit = value; }
        }

        /// <summary>
        /// 修改范围
        /// </summary>
        private int m_Range;

        /// <summary>
        /// 获取或设置：修改范围
        /// </summary>
        public int Range
        {
            get { return m_Range; }
            set { m_Range = value; }
        }
        /// <summary>
        /// 单位工程名称
        /// </summary>
        private string m_UnName = string.Empty;
        /// <summary>
        /// 获取或设置：单位工程名称
        /// </summary>
        public string UnName
        {
            get { return m_UnName; }
            set { m_UnName = value; }
        }

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="p_UnName">单位工程名称</param>
        /// <param name="this.Range">修改范围</param>
        /// <param name="p_FieldName">修改字段</param>
        /// <param name="p_BeforeValue">修改前的值</param>
        /// <param name="p_Info">工料机</param>
        public void Update(string p_FieldName, object p_BeforeValue, DataRow p_Info)
        {
            if (this.AllQuantityUnit == null || p_Info == null) return;
            switch (p_FieldName)//根据不同的字段名称处理不同
            {
                case "MC":
                    UpdateMC(p_FieldName, p_BeforeValue, p_Info);
                    break;
                case "DW":
                    UpdateDW(p_FieldName, p_BeforeValue, p_Info);
                    break;
                case "SCDJ":
                    if (p_Info["SCDJ"].Equals(DBNull.Value))
                    {
                        p_Info["SCDJ"] = 0;
                    }
                    UpdateSCDJ(p_FieldName, p_BeforeValue, p_Info);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 修改名称
        /// </summary>
        /// <param name="p_Info"></param>
        private void UpdateMC(string p_FieldName, object p_BeforeValue, DataRow p_Info)
        {
            DataRow m_Repeat = this.m_AllQuantityUnit.Select(string.Format("ID<>{0} AND YSBH='{1}' AND MC='{2}' AND DW='{3}' AND SCDJ='{4}'", p_Info["ID"], p_Info["YSBH"], p_Info["MC"], p_Info["DW"], p_Info["SCDJ"])).FirstOrDefault();
            if (m_Repeat == null)
            {
                int m_count = this.m_AllQuantityUnit.Select(string.Format("BH='{0}' AND SCDJ <> '{1}'", p_Info["YSBH"], p_Info["SCDJ"])).Count();
                if (p_Info["MC"].Equals(p_Info["YSMC"]) && p_Info["DW"].Equals(p_Info["YSDW"]) && m_count == 0 )
                {
                    this.EditPart(p_FieldName, p_BeforeValue, p_Info, p_Info["YSBH"].ToString());
                }
                else
                {
                    bool m_Result = false;
                    switch (this.Range)
                    {
                        case 0:
                            if (p_Info["BH"].Equals(p_Info["YSBH"])) m_Result = true;
                            break;
                        case 1:
                            int allcount = this.m_AllQuantityUnit.Select(string.Format("BH='{0}'", p_Info["BH"])).Count();
                            int partcount = this.m_AllQuantityUnit.Select(string.Format("SSLB={0} AND ZMID='{1}' AND BH='{2}'", p_Info["SSLB"], p_Info["ZMID"], p_Info["BH"])).Count();
                            if (allcount == partcount)
                            {
                                if (p_Info["BH"].Equals(p_Info["YSBH"]))
                                {
                                    m_Result = true;
                                }
                            }
                            else
                            {
                                m_Result = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (m_Result)
                    {
                        this.EditPart(p_FieldName, p_BeforeValue, p_Info, this.GetBH(p_Info));
                    }
                    else
                    {
                        this.EditPart(p_FieldName, p_BeforeValue, p_Info, p_Info["BH"].ToString());
                    }
                }
            }
            else
            {
                this.EditPart(p_FieldName, p_BeforeValue, p_Info, m_Repeat["BH"].ToString());
            }
        }

        /// <summary>
        /// 修改单位
        /// </summary>
        /// <param name="p_Info"></param>
        private void UpdateDW(string p_FieldName, object p_BeforeValue, DataRow p_Info)
        {
            DataRow m_Repeat = this.m_AllQuantityUnit.Select(string.Format("ID<>{0} AND YSBH='{1}' AND MC='{2}' AND DW='{3}' AND SCDJ='{4}'", p_Info["ID"], p_Info["YSBH"], p_Info["MC"], p_Info["DW"], p_Info["SCDJ"])).FirstOrDefault();
            if (m_Repeat == null)
            {
                int m_count = this.m_AllQuantityUnit.Select(string.Format("BH='{0}' AND SCDJ <> '{1}'", p_Info["YSBH"], p_Info["SCDJ"])).Count();
                if (p_Info["MC"].Equals(p_Info["YSMC"]) && p_Info["DW"].Equals(p_Info["YSDW"]) && m_count == 0)
                {
                    this.EditPart(p_FieldName, p_BeforeValue, p_Info, p_Info["YSBH"].ToString());
                }
                else
                {
                    bool m_Result = false;
                    switch (this.Range)
                    {
                        case 0:
                            if (p_Info["BH"].Equals(p_Info["YSBH"])) m_Result = true;
                            break;
                        case 1:
                            int allcount = this.m_AllQuantityUnit.Select(string.Format("BH='{0}'", p_Info["BH"])).Count();
                            int partcount = this.m_AllQuantityUnit.Select(string.Format("SSLB={0} AND ZMID='{1}' AND BH='{2}'", p_Info["SSLB"], p_Info["ZMID"], p_Info["BH"])).Count();
                            if (allcount == partcount)
                            {
                                if (p_Info["BH"].Equals(p_Info["YSBH"]))
                                {
                                    m_Result = true;
                                }
                            }
                            else
                            {
                                m_Result = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (m_Result)
                    {
                        this.EditPart(p_FieldName, p_BeforeValue, p_Info, this.GetBH(p_Info));
                    }
                    else
                    {
                        this.EditPart(p_FieldName, p_BeforeValue, p_Info, p_Info["BH"].ToString());
                    }
                }
            }
            else
            {
                this.EditPart(p_FieldName, p_BeforeValue, p_Info, m_Repeat["BH"].ToString());
            }
        }

        /// <summary>
        /// 修改市场单价
        /// </summary>
        /// <param name="p_Info"></param>
        private void UpdateSCDJ(string p_FieldName, object p_BeforeValue, DataRow p_Info)
        {
            DataRow m_Repeat = this.m_AllQuantityUnit.Select(string.Format("ID<>{0} AND YSBH='{1}' AND MC='{2}' AND DW='{3}' AND SCDJ='{4}'", p_Info["ID"], p_Info["YSBH"], p_Info["MC"], p_Info["DW"], p_Info["SCDJ"])).FirstOrDefault();
            if (m_Repeat == null)
            {
                int m_count = this.m_AllQuantityUnit.Select(string.Format("BH='{0}' AND SCDJ <> '{1}'", p_Info["YSBH"], p_Info["SCDJ"])).Count();
                if (p_Info["MC"].Equals(p_Info["YSMC"]) && p_Info["DW"].Equals(p_Info["YSDW"]) && m_count == 0)
                {
                    this.EditPart(p_FieldName, p_BeforeValue, p_Info, p_Info["YSBH"].ToString());
                }
                else
                {
                    bool m_Result = false;
                    switch (this.Range)
                    {
                        case 0:

                            break;
                        case 1:
                            int allcount = this.m_AllQuantityUnit.Select(string.Format("BH='{0}'", p_Info["BH"])).Count();
                            int partcount = this.m_AllQuantityUnit.Select(string.Format("SSLB={0} AND ZMID='{1}' AND BH='{2}'", p_Info["SSLB"], p_Info["ZMID"], p_Info["BH"])).Count();
                            if (allcount != partcount) m_Result = true;
                            break;
                        default:
                            break;
                    }
                    if (m_Result)
                    {
                        this.EditPart(p_FieldName, p_BeforeValue, p_Info, this.GetBH(p_Info));
                    }
                    else
                    {
                        this.EditPart(p_FieldName, p_BeforeValue, p_Info, p_Info["BH"].ToString());
                    }
                }
            }
            else
            {
                this.EditPart(p_FieldName, p_BeforeValue, p_Info, m_Repeat["BH"].ToString());
            }
        }

        /// <summary>
        /// 修改所在范围所有相同材料
        /// </summary>
        /// <param name="p_Info">材料</param>
        /// <param name="p_BH">编号</param>
        private void EditPart(string p_FieldName, object p_BeforeValue, DataRow p_Info, string p_BH)
        {
            this.UpdateUserPriceLibrary(p_Info, p_BH);
            string str = string.Empty;
            switch (this.Range)
            {
                case 0:
                    str = string.Format("BH='{0}'", p_Info["BH"]);
                    break;
                case 1:
                    str = string.Format("SSLB={0} AND ZMID='{1}' AND BH='{2}'", p_Info["SSLB"], p_Info["ZMID"], p_Info["BH"]);
                    break;
                default:
                    break;
            }
            DataRow[] p_Same = this.m_AllQuantityUnit.Select(str);
            foreach (DataRow item in p_Same)
            {
                item.BeginEdit();
                item["BH"] = p_BH;
                switch (p_FieldName)
                {
                    case "MC":
                        item["MC"] = p_Info["MC"];
                        item.EndEdit();
                        break;
                    case "DW":
                        item["DW"] = p_Info["DW"];
                        item.EndEdit();
                        break;
                    case "SCDJ":
                        item["SCDJ"] = p_Info["SCDJ"];
                        if (item["LB"].Equals("主材") || item["LB"].Equals("设备")) item["DEDJ"] = p_Info["SCDJ"];
                        item.EndEdit();
                        string m_NewSubheadings = item["EnID"] + "," + item["UnID"] + "," + item["SSLB"] + "," + item["ZMID"] + "|";
                        if (!this.SubheadingsInfo.Contains(m_NewSubheadings))
                        {
                            this.SubheadingsInfo += m_NewSubheadings;
                        }
                        _Methods_Quantity.RowCalculateAndParentSCDJ(item);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 获取新编号
        /// </summary>
        /// <param name="p_Info">材料</param>
        /// <returns></returns>
        private string GetBH(DataRow p_Info)
        {
            string m_BH = string.Empty;
            int i = 1;//用来记录编号
            //统计全部人材机中的当前修改对象原始编号条数 作为循环次数
            DataRow[] a_list = this.AllQuantityUnit.Select(string.Format("YSBH='{0}'", p_Info["YSBH"]));
            foreach (DataRow item in a_list)
            {
                //手动生成（1000_i）查询条件
                m_BH = p_Info["YSBH"].ToString() + "_" + i;
                int count = this.AllQuantityUnit.Select(string.Format("BH='{0}'", m_BH)).Count();
                if (count == 0) break;
                i++;
            }
            return m_BH.ToString();
        }

        /// <summary>
        /// 更新用户价格库
        /// </summary>
        /// <param name="p_Info">材料</param>
        /// <param name="p_BH">编号</param>
        private void UpdateUserPriceLibrary(DataRow p_Info, string p_BH)
        {
            if (this.UserPriceLibrarySource == null) return;
            if (p_Info["LB"].Equals("材料") || p_Info["LB"].Equals("主材") || p_Info["LB"].Equals("设备"))
            {
                DataRow dr = this.UserPriceLibrarySource.Select(string.Format("BH='{0}' AND SSDWGC='{1}'", p_BH, this.UnName)).FirstOrDefault();
                if (dr == null)
                {
                    DataRow newinfo = this.UserPriceLibrarySource.NewRow();
                    newinfo["YSBH"] = p_Info["YSBH"];
                    newinfo["YSDW"] = p_Info["YSDW"];
                    newinfo["YSMC"] = p_Info["YSMC"];
                    newinfo["SCDJ"] = p_Info["SCDJ"];
                    newinfo["BH"] = p_BH;
                    newinfo["MC"] = p_Info["MC"];
                    newinfo["DW"] = p_Info["DW"];
                    newinfo["DEDJ"] = p_Info["DEDJ"];
                    newinfo["LB"] = p_Info["LB"];
                    newinfo["SSDWGC"] = this.UnName;
                    newinfo["CTIME"] = DateTime.Now;
                    newinfo["CurrNo"] = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
                    newinfo["Status"] = "add";
                    this.UserPriceLibrarySource.Rows.Add(newinfo);
                }
                else
                {
                    dr.BeginEdit();
                    dr["YSBH"] = p_Info["YSBH"];
                    dr["YSDW"] = p_Info["YSDW"];
                    dr["YSMC"] = p_Info["YSMC"];
                    dr["SCDJ"] = p_Info["SCDJ"];
                    dr["BH"] = p_BH;
                    dr["MC"] = p_Info["MC"];
                    dr["DW"] = p_Info["DW"];
                    dr["DEDJ"] = p_Info["DEDJ"];
                    dr["LB"] = p_Info["LB"];
                    dr["SSDWGC"] = this.UnName;
                    dr["CTIME"] = DateTime.Now;
                    if (!dr["ID"].Equals(DBNull.Value))
                    {
                        dr["Status"] = "update";
                    }
                    dr.EndEdit();
                }
            }
        }
    }
}