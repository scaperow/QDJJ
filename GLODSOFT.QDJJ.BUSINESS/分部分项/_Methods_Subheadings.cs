using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;
using ZiboSoft.Commons.Common;
using System.Threading;
using GOLDSOFT.QDJJ.BUSINESS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_Subheadings : _Methods
    {

        public _Methods_Subheadings(_UnitProject p_Unit)
            : base(p_Unit)
        {

        }
        public _Methods_Subheadings(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base(m_Currentbus, p_Unit, p_info)
        {

        }
        /// <summary>
        /// Copy当前子目到指定清单之下
        /// </summary>
        /// <param name="QD_info"></param>
        public override void CopyTo(_Entity_SubInfo QD_info)
        {
            DataRow[] rowsGLJ = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}  and ZCLB='W'", this.Current.ID, this.Current.SSLB));
            DataRow[] rowsZMQF = this.Unit.StructSource.ModelSubheadingsFee.Select(string.Format("ZMID={0} and SSLB={1}", this.Current.ID, this.Current.SSLB));
            DataRow[] rowsBZHS = this.Unit.StructSource.ModelStandardConversion.Select(string.Format("ZMID={0} and SSLB={1}", this.Current.ID, this.Current.SSLB));
            DataRow[] rowsZJF = this.Unit.StructSource.ModelIncreaseCosts.Select(string.Format("ZMID={0} and SSLB={1}", this.Current.ID, this.Current.SSLB));
            DataRow[] rowsBL = this.Unit.StructSource.ModelVariable.Select(string.Format("ID={0} and Type={1}", this.Current.ID, this.Current.SSLB));
            this.Current.PID = QD_info.ID;
            this.Current.Key = ++this.CurrentBusiness.Current.ObjectKey;
            this.Current.PKey = ToolKit.ParseInt(QD_info.Key);
            this.Current.CPARENTID = this.Current.PID;
            this.Current.FPARENTID = this.Current.PID;
            this.Current.PPARENTID = this.Current.PID;

            int intCount = this.Unit.StructSource.ModelSubSegments.Select(string.Format(" Pid={0} ", QD_info.ID)).Count();
            this.Current.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("YJFZ", ++intCount, QD_info.OLDXMBM);
            //sinfo.SSLB = this.Current.SSLB;
            //sinfo.EnID = this.Current.EnID;
            // sinfo.UnID = this.Current.UnID;

            this.Unit.StructSource.ModelSubSegments.Add(this.Current);
            foreach (DataRow item in rowsGLJ)
            {
                DataRow[] rowsZC = this.Unit.StructSource.ModelQuantity.Select(string.Format("PID={0} and SSLB={1}", item["ID"], this.Current.SSLB));

                DataRow r_glj = this.Unit.StructSource.ModelQuantity.Add(item);
                r_glj["ZMID"] = this.Current.ID;
                r_glj["QDID"] = QD_info.ID;
                foreach (DataRow row in rowsZC)
                {

                    DataRow phb = this.Unit.StructSource.ModelQuantity.Add(row);
                    phb["ZMID"] = this.Current.ID;
                    phb["QDID"] = QD_info.ID;
                    phb["PID"] = r_glj["ID"];
                }
            }
            foreach (DataRow item in rowsZMQF)
            {

                DataRow r_glj = this.Unit.StructSource.ModelSubheadingsFee.Add(item);
                r_glj["ZMID"] = this.Current.ID;
                r_glj["QDID"] = QD_info.ID;

            }
            foreach (DataRow item in rowsBZHS)
            {
                DataRow r_glj = this.Unit.StructSource.ModelSubheadingsFee.Add(item);
                r_glj["ZMID"] = this.Current.ID;
                r_glj["QDID"] = QD_info.ID;

            }
            foreach (DataRow item in rowsZJF)
            {
                DataRow r_glj = this.Unit.StructSource.ModelSubheadingsFee.Add(item);
                r_glj["ZMID"] = this.Current.ID;
                r_glj["QDID"] = QD_info.ID;
            }
            foreach (DataRow item in rowsBL)
            {
                DataRow r = this.Unit.StructSource.ModelVariable.NewRow();
                r.ItemArray = item.ItemArray;
                r["ID"] = this.Current.ID;
                this.Unit.StructSource.ModelVariable.Rows.Add(r);

            }
            BeginCurrent();

        }
        /// <summary>
        /// 删除子目及以下
        /// </summary>
        public override void RemoveAllChild()
        {
            DataRow[] rows = this.Unit.StructSource.ModelSubSegments.Select(string.Format("ID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Delete();
            }
            //删除工料机
            DataRow[] rows1 = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
            for (int i = 0; i < rows1.Length; i++)
            {
                rows1[i].Delete();
            }
        }
        /// <summary>
        /// 创建工料机（根据定额材机）
        /// </summary>
        public virtual void CreateGLJ()
        {
            DataTable dt = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"];

            if (!string.IsNullOrEmpty(this.Current.DECJ))
            {
                string[] strs = this.Current.DECJ.Split('|');
                CEntityQuantityUnit[] infos = new CEntityQuantityUnit[strs.Length - 1];
                for (int i = 0; i < strs.Length - 1; i++)
                {
                    string[] str = strs[i].Split(',');
                    DataRow[] dr = dt.Select(string.Format("CAIJBH ='{0}'", str[0].ToString()));
                    if (dr != null)
                    {
                        if (dr.Length < 1)
                        {
                            continue;
                        }
                        DataRow info = this.Unit.StructSource.ModelQuantity.NewRow();
                        info["YSBH"] = dr[0]["CAIJBH"];
                        info["YSMC"] = dr[0]["CAIJMC"];
                        info["YSDW"] = dr[0]["CAIJDW"];
                        info["YSXHL"] = ToolKit.ParseDecimal(str[1]);
                        info["BH"] = dr[0]["CAIJBH"];
                        info["MC"] = dr[0]["CAIJMC"];
                        info["DW"] = dr[0]["CAIJDW"];
                        info["LB"] = dr[0]["CAIJLB"];
                        info["XHL"] = str.Length == 4 && !info["LB"].ToString().Contains("%") ? ToolKit.ParseDecimal(str[3]) : ToolKit.ParseDecimal(str[1]);
                        info["DEDJ"] = ToolKit.ParseDecimal(dr[0]["CAIJDJ"]);
                        info["ZCLB"] = "W";
                        info["SDCLB"] = dr[0]["SANDCMC"];
                        info["SDCXS"] = ToolKit.ParseDecimal(dr[0]["SANDCXS"]);
                        info["GCL"] = this.Current.GCL;
                        info["SSKLB"] = this.Current.LibraryName;
                        DataRow row = this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}'", info["BH"])).FirstOrDefault();
                        if (row == null)
                        {
                            info["IFSC"] = dr[0]["CAIJSC"].Equals("是") ? true : false;
                            info["IFZYCL"] = dr[0]["CAIJXSJG"].Equals("是") ? true : false;
                            if (str[2] != string.Empty)
                            {
                                info["SCDJ"] = ToolKit.ParseDecimal(str[2]);
                            }
                            else
                            {
                                info["SCDJ"] = info["DEDJ"];
                            }
                        }
                        else
                        {
                            info["IFSC"] = row["IFSC"];
                            info["IFFX"] = row["IFFX"];
                            info["IFSDSCDJ"] = row["IFSDSCDJ"];
                            info["IFZYCL"] = row["IFZYCL"];
                            info["YTLB"] = row["YTLB"];
                            info["SCDJ"] = row["SCDJ"];
                            info["DEDJ"] = row["DEDJ"];
                            info["JSDJ"] = row["JSDJ"];
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
                        info["UnID"] = this.Current.UnID;
                        info["EnID"] = this.Current.EnID;
                        info["ZMID"] = this.Current.ID;
                        info["QDID"] = this.Current.PID;
                        info["SSLB"] = this.Current.SSLB;
                        info["PID"] = DBNull.Value;
                        if (info["LB"].Equals("配合比") || info["LB"].ToString().Contains("台班"))
                        {
                            info["IFKFJ"] = true;
                        }
                        info["CTIME"] = DateTime.Now;
                        this.Unit.StructSource.ModelQuantity.Rows.Add(info);
                        if (info["IFKFJ"].Equals(true))
                        {
                            //此处需要调用 当前工料机的行计算
                            _Methods_Quantity met = new _Methods_Quantity(this.Unit);
                            met.Parent = info;
                            met.Create();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 创建工料机
        /// </summary>
        /// <param name="p_info"></param>
        /// <returns></returns>
        public bool CreateGLJ(DataRow p_Current, DataRow p_info)
        {
            if (p_info == null) return false;
            if (this.Contains(p_info)) return false;
            DataRow info = this.Unit.StructSource.ModelQuantity.NewRow();
            info["EnID"] = this.Unit.PID;
            info["UnID"] = this.Unit.ID;
            info["ZMID"] = this.Current.ID;
            info["QDID"] = this.Current.PID;
            info["SSLB"] = this.Current.SSLB;
            info["PID"] = DBNull.Value;
            info["SSKLB"] = this.Current.LibraryName;
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
            info["ZCLB"] = "W";
            info["SDCLB"] = p_info["SDCLB"];
            info["SDCXS"] = p_info["SDCXS"];
            info["GCL"] = this.Current.GCL;
            if (info["LB"].Equals("主材") || info["LB"].Equals("设备"))
            {
                info["DEDJ"] = p_info["SCDJ"];
            }
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
            if (info["LB"].Equals("配合比") || info["LB"].ToString().Contains("台班"))
            {
                info["IFKFJ"] = true;
            }
            info["CTIME"] = DateTime.Now;
            this.Unit.StructSource.ModelQuantity.Rows.InsertAt(info, this.GetIndex(p_Current));
            if (info["IFKFJ"].Equals(true))
            {
                //此处需要调用 当前工料机的行计算
                _Methods_Quantity met = new _Methods_Quantity(this.Unit);
                met.Parent = info;
                met.Create();
            }
            this.Current.XMMC += "//增：" + info["MC"];
            if (!this.Current.XMBM.Contains("换"))
            {
                this.Current.XMBM += "换";
            }
            if (this.Current.SSLB == 0)
            {
                this.Unit.StructSource.ModelSubSegments.UpDate(this.Current);
            }
            else
            {
                this.Unit.StructSource.ModelMeasures.UpDate(this.Current);
            }
            return true;
        }
        public bool CreateGLJ(DataRow p_info)
        {
            if (p_info == null) return false;
            if (this.Contains(p_info)) return false;
            DataRow info = this.Unit.StructSource.ModelQuantity.NewRow();
            info["EnID"] = this.Unit.PID;
            info["UnID"] = this.Unit.ID;
            info["ZMID"] = this.Current.ID;
            info["QDID"] = this.Current.PID;
            info["SSLB"] = this.Current.SSLB;
            info["PID"] = DBNull.Value;
            info["SSKLB"] = this.Current.LibraryName;
            info["YSBH"] = p_info["YSBH"];
            info["YSMC"] = p_info["YSMC"];
            info["YSDW"] = p_info["YSDW"];
            info["YSXHL"] = p_info["YSXHL"]; ;
            info["DEDJ"] = p_info["DEDJ"];
            info["BH"] = p_info["BH"];
            info["MC"] = p_info["MC"];
            info["DW"] = p_info["DW"];
            info["XHL"] = p_info["XHL"]; ;
            info["SCDJ"] = p_info["SCDJ"];
            info["LB"] = p_info["LB"];
            info["ZCLB"] = "W";
            info["SDCLB"] = p_info["SDCLB"];
            info["SDCXS"] = p_info["SDCXS"];
            info["GCL"] = this.Current.GCL;
            if (info["LB"].Equals("主材") || info["LB"].Equals("设备"))
            {
                info["DEDJ"] = p_info["SCDJ"];
            }
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
            if (info["LB"].Equals("配合比") || info["LB"].ToString().Contains("台班"))
            {
                info["IFKFJ"] = true;
            }
            info["CTIME"] = DateTime.Now;
            this.Unit.StructSource.ModelQuantity.Rows.InsertAt(info, 0);
            if (info["IFKFJ"].Equals(true))
            {
                //此处需要调用 当前工料机的行计算
                _Methods_Quantity met = new _Methods_Quantity(this.Unit);
                met.Parent = info;
                met.Create();
            }
            this.Current.XMMC += "//增：" + info["MC"];
            if (!this.Current.XMBM.Contains("换"))
            {
                this.Current.XMBM += "换";
            }
            if (this.Current.SSLB == 0)
            {
                this.Unit.StructSource.ModelSubSegments.UpDate(this.Current);
            }
            else
            {
                this.Unit.StructSource.ModelMeasures.UpDate(this.Current);
            }
            return true;
        }

        /// <summary>
        /// 替换工料机
        /// </summary>
        /// <param name="p_ysinfo"></param>
        /// <param name="p_info"></param>
        /// <returns></returns>
        public bool ReplaceGLJ(DataRow p_ysinfo, DataRow p_info)
        {
            if (p_ysinfo == null || p_info == null) return false;
            if (this.Contains(p_info)) return false;
            string ysmc = p_ysinfo["MC"].ToString();
            p_ysinfo.BeginEdit();
            p_ysinfo["EnID"] = this.Unit.PID;
            p_ysinfo["UnID"] = this.Unit.ID;
            p_ysinfo["ZMID"] = this.Current.ID;
            p_ysinfo["QDID"] = this.Current.PID;
            p_ysinfo["SSLB"] = this.Current.SSLB;
            p_ysinfo["SSKLB"] = this.Current.LibraryName;
            p_ysinfo["YSBH"] = p_info["YSBH"];
            p_ysinfo["YSMC"] = p_info["YSMC"];
            p_ysinfo["YSDW"] = p_info["YSDW"];
            p_ysinfo["DEDJ"] = p_info["DEDJ"];
            p_ysinfo["BH"] = p_info["BH"];
            p_ysinfo["MC"] = p_info["MC"];
            p_ysinfo["DW"] = p_info["DW"];
            p_ysinfo["SCDJ"] = p_info["SCDJ"];
            p_ysinfo["LB"] = p_info["LB"];
            p_ysinfo["ZCLB"] = "W";
            p_ysinfo["SDCLB"] = p_info["SDCLB"];
            p_ysinfo["SDCXS"] = p_info["SDCXS"];
            p_ysinfo["GCL"] = this.Current.GCL;
            if (p_ysinfo["LB"].Equals("主材") || p_ysinfo["LB"].Equals("设备"))
            {
                p_ysinfo["DEDJ"] = p_info["SCDJ"];
            }
            p_ysinfo["IFSC"] = p_info["IFSC"];
            p_ysinfo["IFFX"] = p_info["IFFX"];
            p_ysinfo["IFSDSCDJ"] = p_info["IFSDSCDJ"];
            p_ysinfo["IFZYCL"] = p_info["IFZYCL"];
            p_ysinfo["YTLB"] = p_info["YTLB"];
            p_ysinfo["JSDJ"] = p_info["JSDJ"];
            p_ysinfo["CJ"] = p_info["CJ"];
            p_ysinfo["PP"] = p_info["PP"];
            p_ysinfo["ZLDJ"] = p_info["ZLDJ"];
            p_ysinfo["GYS"] = p_info["GYS"];
            p_ysinfo["CD"] = p_info["CD"];
            p_ysinfo["CJBZ"] = p_info["CJBZ"];
            if (p_ysinfo["LB"].Equals("配合比") || p_ysinfo["LB"].ToString().Contains("台班"))
            {
                p_ysinfo["IFKFJ"] = true;
            }
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("UnID={0} AND SSLB={1} AND ZMID={2} AND PID={3}", this.Current.UnID, this.Current.SSLB, this.Current.ID, p_ysinfo["ID"]));
            foreach (DataRow item in drs)
            {
                item.Delete();
            }
            p_ysinfo.EndEdit();
            if (p_ysinfo["IFKFJ"].Equals(true))
            {
                //此处需要调用 当前工料机的行计算
                _Methods_Quantity met = new _Methods_Quantity(this.Unit);
                met.Parent = p_ysinfo;
                met.Create();
            }
            this.Current.XMMC += "//换：" + ysmc + "," + p_ysinfo["MC"];
            if (!this.Current.XMBM.Contains("换"))
            {
                this.Current.XMBM += "换";
            }
            if (this.Current.SSLB == 0)
            {
                this.Unit.StructSource.ModelSubSegments.UpDate(this.Current);
            }
            else
            {
                this.Unit.StructSource.ModelMeasures.UpDate(this.Current);
            }
            return true;
        }

        /// <summary>
        /// 获取工料机插入位置
        /// </summary>
        /// <returns></returns>
        private int GetIndex(DataRow p_Current)
        {
            if (p_Current == null) return 0;
            int index = this.Unit.StructSource.ModelQuantity.Rows.IndexOf(p_Current);
            if (index == -1)
            {
                return 0;
            }
            return index + 1;
        }


        /// <summary>
        /// 创建：子目工料机、标准换算、子目取费、子目基础结果集
        /// </summary>
        public override _Entity_SubInfo Create()
        {
            if (this.Current.LB == "子目" || this.Current.LB == "子目-降效" || this.Current.LB == "子目-增加费")
            {
                if (!string.IsNullOrEmpty(this.Current.DECJ))
                {
                    this.CreateZMGLJ();
                }
                CreateBZHS();
                CreateZMQFS();
            }
            return this.Current;
        }


        /// <summary>
        /// 创建：子目工料机
        /// </summary>
        private void CreateZMGLJ()
        {
            if (!string.IsNullOrEmpty(this.Current.XMBM))
            {
                string whxmbm = this.Current.XMBM.Replace("换", "");
                string[] m_FirstArr = whxmbm.Split(' ');
                if (m_FirstArr.Length == 1)
                {
                    CreateGLJ();
                }
                else
                {
                    for (int i = 1; i < m_FirstArr.Length; i++)
                    {
                        string[] sjhd = m_FirstArr[i].Split('*');

                        switch (sjhd[0].ToUpper())
                        {
                            case "":
                                Preparation(sjhd[0], ToolKit.Calculate("1" + m_FirstArr[i]));
                                break;
                            case "R":
                            case "C":
                            case "J":
                                Preparation(sjhd[0], ToolKit.Calculate(m_FirstArr[i].Replace(sjhd[0], "1")));
                                break;
                            default:
                                string deh = string.Empty;
                                if (sjhd[0].StartsWith("+") || sjhd[0].StartsWith("-"))
                                {
                                    deh = sjhd[0].Substring(1, sjhd[0].Length - 1);
                                    Preparation(sjhd[0].Substring(0, 1), deh, ToolKit.Calculate(m_FirstArr[i].Replace(sjhd[0], "1")));
                                }
                                break;
                        }
                    }
                    CreateGLJ();
                }
            }
        }

        /// <summary>
        /// 单个定额号的处理 比如4-1 *2*2*2*2 R*2
        /// </summary>
        /// <param name="ysde"></param>
        /// <param name="rcl"></param>
        /// <param name="s"></param>
        private void Preparation(string p_RCJType, decimal p_Num)
        {
            if (this.Current.DECJ == null) return;
            string[] strs = this.Current.DECJ.Split('|');
            string m_XDECJ = string.Empty;
            foreach (string item in strs)
            {
                if (item.Trim() != string.Empty)
                {
                    string[] items = item.Split(',');
                    string m_bh = items[0].ToString();
                    decimal m_xhl = items.Length == 4 ? ToolKit.ParseDecimal(items[3]) : ToolKit.ParseDecimal(items[1]);
                    switch (p_RCJType.ToUpper())
                    {
                        case "R":
                            DataRow rdr = GetRCJ(m_bh);
                            if (rdr != null)
                            {
                                if (_Constant.rg.Contains("'" + rdr["CAIJLB"].ToString() + "'"))
                                {
                                    m_xhl = m_xhl * p_Num;
                                }
                            }
                            break;
                        case "C":
                            DataRow rdc = GetRCJ(m_bh);
                            if (rdc != null)
                            {
                                if (_Constant.cl.Contains("'" + rdc["CAIJLB"].ToString() + "'"))
                                {
                                    m_xhl = m_xhl * p_Num;
                                }
                            }
                            break;
                        case "J":
                            DataRow rdj = GetRCJ(m_bh);
                            if (rdj != null)
                            {
                                if (_Constant.jx.Contains("'" + rdj["CAIJLB"].ToString() + "'"))
                                {
                                    m_xhl = m_xhl * p_Num;
                                }
                            }
                            break;
                        default:
                            m_xhl = m_xhl * p_Num;
                            break;
                    }
                    m_XDECJ += items[0] + "," + items[1] + "," + items[2] + "," + m_xhl + "|";
                }
            }
            this.Current.DECJ = m_XDECJ;
        }

        /// <summary>
        /// 带定额号
        /// </summary>
        /// <param name="ysde"></param>
        /// <param name="ysf"></param>
        /// <param name="deh"></param>
        /// <param name="s"></param>
        private void Preparation(string p_Symbol, string p_DEH, decimal p_Num)
        {
            DataRow dr = GetDE(p_DEH);
            if (dr != null)
            {
                string[] m_DECJ = dr["DECJ"].ToString().Split('|');
                foreach (string item in m_DECJ)
                {
                    if (item.Trim() != string.Empty)
                    {
                        string[] items = item.Split(',');
                        string m_bh = items[0].ToString();
                        decimal m_xhl = items.Length == 4 ? ToolKit.ParseDecimal(items[3]) : ToolKit.ParseDecimal(items[1]);
                        m_xhl = m_xhl * p_Num;
                        if (this.Current.DECJ.Contains(m_bh))
                        {
                            string strk = this.Current.DECJ.Substring(this.Current.DECJ.IndexOf(m_bh), this.Current.DECJ.Length - this.Current.DECJ.IndexOf(m_bh));
                            string y_item = strk.Substring(0, strk.IndexOf('|'));
                            string[] y_items = y_item.Split(',');
                            decimal y_xhl = y_items.Length == 4 ? ToolKit.ParseDecimal(y_items[3]) : ToolKit.ParseDecimal(y_items[1]);
                            if (p_Symbol == "+")
                            {
                                m_xhl = y_xhl + m_xhl;
                            }
                            else
                            {
                                m_xhl = y_xhl - m_xhl;
                            }
                            this.Current.DECJ = this.Current.DECJ.Replace(y_item, items[0] + "," + items[1] + "," + items[2] + "," + m_xhl);
                        }
                        else
                        {
                            if (p_Symbol == "+")
                            {
                                this.Current.DECJ += items[0] + "," + items[1] + "," + items[2] + "," + m_xhl + "|";
                            }
                            else
                            {
                                this.Current.DECJ += items[0] + "," + items[1] + "," + items[2] + "," + (0 - m_xhl) + "|";
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取人材机
        /// </summary>
        /// <param name="p_bh">人材机编号</param>
        /// <returns></returns>
        private DataRow GetRCJ(string p_bh)
        {
            DataTable dt = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"];
            DataRow[] dr = dt.Select(string.Format("CAIJBH ='{0}'", p_bh));
            if (dr != null)
            {
                if (dr.Length == 1)
                {
                    return dr[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 获取定额材机
        /// </summary>
        /// <param name="p_DEH">定额号</param>
        /// <returns></returns>
        private DataRow GetDE(string p_DEH)
        {
            DataTable dt = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"];
            DataRow[] dr = dt.Select(string.Format("DINGEH='{0}'", p_DEH));
            if (dr != null)
            {
                if (dr.Length == 1)
                {
                    return dr[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 移除子目取费
        /// </summary>
        public void RemoveFeeOfSubheading()
        {
            var deleteRows = this.Unit.StructSource.ModelSubheadingsFee.Select(string.Format("EnID = {0} AND UnID = {1} AND ZMID = {2}", this.Current.EnID, this.Current.UnID, this.Current.ID));
            if (deleteRows != null)
            {
                for (var i = 0; i < deleteRows.Length; i++)
                {
                    var item = deleteRows[i];
                    item.Delete();
                }
            }
            this.Unit.StructSource.ModelSubheadingsFee.AcceptChanges();
        }

        /// <summary>
        /// 创建：子目取费
        /// </summary>
        public virtual void CreateZMQFS()
        {
            if (this.Unit == null) return;
            if (string.IsNullOrEmpty(this.Current.OLDXMBM)) return;
            string m_XMBM = this.Current.OLDXMBM;
            _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(this.Unit);
            DataRow dr_UnitFee = m_Methods_ParamsSeting.GetUnitFeeInfo(m_XMBM);
            if (dr_UnitFee != null)
            {
                this.Current.ZYLB = dr_UnitFee["GCLB"].ToString().Replace("【", "").Replace("】", "");
                //this.RemoveFeeOfSubheading();
            }



            foreach (DataRowView view in this.Unit.StructSource.ModelPSubheadingsFee.DefaultView)
            {
                DataRow item = view.Row;

                if (item["YYH"] == null || string.IsNullOrEmpty(item["YYH"].ToString()))
                {
                    continue;
                }
                DataRow dr = this.Unit.StructSource.ModelSubheadingsFee.NewRow();
                dr["EnID"] = this.Current.EnID;
                dr["UnID"] = this.Current.UnID;
                dr["SSLB"] = this.Current.SSLB;
                dr["QDID"] = this.Current.PID;
                dr["ZMID"] = this.Current.ID;
                dr["Sort"] = item["Sort"];
                dr["JSSX"] = item["JSSX"];
                dr["YYH"] = item["YYH"];
                dr["MC"] = item["MC"];
                dr["BDS"] = item["BDS"];
                dr["BZ"] = item["BZ"];
                dr["FYLB"] = item["FYLB"];
                if (dr["Sort"].Equals(7) && dr_UnitFee != null)
                {
                    dr["TBJSJC"] = dr_UnitFee["FXFTBJSJC"];
                    dr["BDJSJC"] = dr_UnitFee["FXFBDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(dr_UnitFee["FXTBFL"]);
                }
                else if (dr["Sort"].Equals(8) && dr_UnitFee != null)
                {
                    dr["TBJSJC"] = dr_UnitFee["GLFTBJSJC"];
                    dr["BDJSJC"] = dr_UnitFee["GLFBDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(dr_UnitFee["GLFFL"]);
                }
                else if (dr["Sort"].Equals(9) && dr_UnitFee != null)
                {
                    dr["TBJSJC"] = dr_UnitFee["LRFTBJSJC"];
                    dr["BDJSJC"] = dr_UnitFee["LRFBDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(dr_UnitFee["LRFL"]);
                }
                else
                {
                    switch (item["QFLB"].ToString())
                    {
                        case "0":
                            dr["TBJSJC"] = item["TBJSJC"];
                            break;
                        case "1":
                            dr["TBJSJC"] = item["SCJJC"];
                            break;
                        case "2":
                            dr["TBJSJC"] = item["BDJSJC"];
                            break;
                        default:
                            dr["TBJSJC"] = item["TBJSJC"];
                            break;
                    }
                    dr["BDJSJC"] = item["BDJSJC"];
                    dr["FL"] = ToolKit.ParseDecimal(item["FL"]);
                }
                this.Unit.StructSource.ModelSubheadingsFee.Rows.Add(dr);
                this.Unit.StructSource.ModelSubheadingsFee.AcceptChanges();
            }
        }

        /// <summary>
        /// 修改：子目取费
        /// </summary>
        public void UpdateZMQFS(_YSSubheadingsFeeList list)
        {
            /*foreach (_YSSubheadingsFeeInfo item in list)
            {
                _SubheadingsFeeInfo info = (from n in this.m_SubheadingsFeeList.Cast<_SubheadingsFeeInfo>()
                                            where n.YYH == item.YYH
                                            select n).First();
                if (!string.IsNullOrEmpty(item.TBJSJC))
                {
                    info.TBJSJC = item.TBJSJC;
                }
                if (!string.IsNullOrEmpty(item.BDJSJC))
                {
                    info.BDJSJC = item.BDJSJC;
                }
                if (item.FL > 0)
                {
                    info.FL = item.FL;
                }
            }*/
        }

        /// <summary>
        /// 创建：标准换算
        /// </summary>
        /// <param name="info"></param>
        public void CreateBZHS()
        {
            if (string.IsNullOrEmpty(this.Current.XMBM)) return;
            DataTable dt = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额换算表"];
            if (dt == null) return;
            DataRow[] drs = dt.Select(string.Format("DINGEH = '{0}'", this.Current.XMBM));
            foreach (DataRow item in drs)
            {
                DataRow dr = this.Unit.StructSource.ModelStandardConversion.NewRow();
                dr["EnID"] = this.Current.EnID;
                dr["UnID"] = this.Current.UnID;
                dr["SSLB"] = this.Current.SSLB;
                dr["QDID"] = this.Current.PID;
                dr["ZMID"] = this.Current.ID;
                dr["IFXZ"] = false;
                dr["DEH"] = item["DINGEH"];
                dr["HSLB"] = item["HUANSLB"];
                dr["HSXX"] = item["TISXX"];
                dr["DJ_DW"] = item["DJDW"];
                dr["JBL_RGXS"] = item["HUANSJS_R"];
                dr["DEH_CLXS"] = item["HUANSDEH_C"];
                dr["TZL_JXXS"] = item["ZENGL_J"];
                dr["ZC"] = item["ZC"];
                dr["SB"] = item["SB"];
                dr["XHLB"] = item["XHLB"];
                if (dr["XHLB"].Equals("3"))
                {
                    dr["JBL_RGXS"] = dr["DJ_DW"];
                    dr["DEH_CLXS"] = dr["DJ_DW"];
                    dr["TZL_JXXS"] = dr["DJ_DW"];
                }
                dr["FZ"] = item["FZ"];
                dr["THZHC"] = item["THZHC"];
                dr["THWZFC"] = item["THWZFC"];
                dr["HSXI"] = item["HSXI"];
                this.Unit.StructSource.ModelStandardConversion.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 验证：是否存在此工料机
        /// </summary>
        /// <param name="p_info">工料机</param>
        /// <returns>是否</returns>
        private bool Contains(DataRow p_info)
        {
            bool result = false;
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("BH='{0}' and SCDJ='{1}'", p_info["BH"], p_info["SCDJ"]));
            if (drs.Length > 0)
            {
                int count = drs.Where(p => p["SSLB"].Equals(this.Current.SSLB) && p["QDID"].Equals(this.Current.PID) && p["ZMID"].Equals(this.Current.ID) && p["PID"].Equals(DBNull.Value)).Count();
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
        /// 子目计算
        /// </summary>
        public override void Calculate()
        {
            this.BeginCurrent();
        }

        /// <summary>
        /// 计算子目
        /// </summary>
        public override void Begin(List<int> session)
        {
            if (session != null)
            {
                if (session.Contains(Current.ID))
                {
                    return;
                }
                else
                {
                    session.Add(Current.ID);
                }
            }

            //工料机计算(没经过子目取费)
            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;

            if (Current.LB != "子目-增加费")
            {
                _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
                stat.Begin();
                //计算子目经过子目取费
                _ResultSubheadings_Statictics sta = new _ResultSubheadings_Statictics(this.Current, this.Unit);
                sta.DataSource = this.GetDataSource;
                sta.Begin();
            }

            //计算子目所属清单
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther(this.Current.PID.ToString());
            var fix = _Entity_SubInfo.Parse(row);
            //var increase = new _Methods_IncreaseInfo(Current, new _Entity_IncreaseCosts());
            _ObjectSource.GetObject(info, row);
            met = new _Methods_Fixed(this.CurrentBusiness, this.Unit, info);
            met.Begin(session);

        }

        public override void BeginCurrent()
        {
            //lock (this.Unit.StructSource.ModelVariable)
            //{
            //    lock (this.Unit.StructSource.ModelResultVariable)
            //    {
            //        lock (this.Unit.StructSource.ModelSubSegments)
            //        {
            _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
            stat.Begin();

            //计算子目经过子目取费
            _ResultSubheadings_Statictics sta = new _ResultSubheadings_Statictics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 计算当前子目的参数表（临时参数表）
        /// </summary>
        public void ParametersTableCalculate()
        {
            _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
            stat.ParametersTableCalculate();
        }

        /// <summary>
        /// 批量计算子目
        /// </summary>
        public void BatchCalculate()
        {
            _Entity_SubInfo m_info = null;
            string[] m_SubheadingsInfos = APP.UserPriceLibrary.SubheadingsInfo.Split('|');
            foreach (string item in m_SubheadingsInfos)
            {
                if (item != string.Empty)
                {
                    DataRow m_SubheadingsInfo = null;
                    string[] m_infos = item.Split(',');
                    switch (m_infos[2])
                    {
                        case "0":
                            m_SubheadingsInfo = this.Unit.StructSource.ModelSubSegments.GetRowByOther(m_infos[3]);
                            break;
                        case "1":
                            m_SubheadingsInfo = this.Unit.StructSource.ModelMeasures.GetRowByOther(m_infos[3]);
                            break;
                        default:
                            break;
                    }

                    GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntaceMet(this.CurrentBusiness, this.Unit, m_SubheadingsInfo).Begin(null);

                    if (m_SubheadingsInfo != null)
                    {
                        m_info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(m_info, m_SubheadingsInfo);
                        this.Current = m_info;
                        this.Begin(null);
                    }
                }
            }
            APP.UserPriceLibrary.SubheadingsInfo = string.Empty;
        }


        /// <summary>
        /// 子目取费计算
        /// </summary>
        public override void SubheadingsFeeCurrent()
        {
            //工料机计算(没经过子目取费)
            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;
            _Subheadings_Statistics stat = new _Subheadings_Statistics(this.Current, this.Unit);
            stat.FBegin();
            //计算子目经过子目取费
            _ResultSubheadings_Statictics sta = new _ResultSubheadings_Statictics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
            //计算子目所属清单
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Methods_Fixed(this.CurrentBusiness, this.Unit, info);
            met.Begin(null);
        }

        public override void UpGCL()
        {
            decimal GCL = this.Current.GCL;
            DataRow r = (this.GetDataSource as _SubSegmentsSource).GetRowByOther(this.Current.PID.ToString());
            if (r != null)
            {
                decimal d = ToolKit.ParseDecimal(r["GCL"]);
                if (d != 0)
                {
                    decimal w = 0m;
                    int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["工程量输入方式"]);
                    if (m > 0)
                    {
                        w = _Methods.GetNumber(this.Current.DW);
                    }

                    if (w == 0) w = 1;
                    this.Current.GCL = ToolKit.ParseDecimal((this.Current.GCL / w).ToString("F4"));
                    this.Current.HL = ToolKit.ParseDecimal((this.Current.GCL / d).ToString("F6"));
                    this.GetDataSource.UpDate(this.Current);
                }
                this.UpZMGLJGCL();
                if (this.Current.QDBH != null)
                {
                    DataRow[] rows = this.Unit.StructSource.ModelMeasures.Select(string.Format("QDBH={0} and XMBM='{1}' and BEIZHU='{2}'", this.Current.QDBH, this.Current.XMBM, this.Current.BEIZHU));
                    _Mothods_MSubheadings met = new _Mothods_MSubheadings(this.CurrentBusiness, this.Unit, null);
                    foreach (DataRow item in rows)
                    {
                        _Entity_SubInfo info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info, item);
                        info.GCL = GCL;
                        met.Current = info;
                        met.UpGCL();
                    }
                }
            }
            this.Begin(null);
        }

        /// <summary>
        /// 修改子目工料机工程量
        /// </summary>
        public void UpZMGLJGCL()
        {
            DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W'", this.Current.SSLB, this.Current.ID));
            foreach (DataRow item in drs)
            {
                if (item["IFSDSL"].Equals(true))
                {
                    item["XHL"] = Convert.ToDecimal(item["SL"]) / Convert.ToDecimal(this.Current.GCL);
                }
                item["GCL"] = this.Current.GCL;
                if (item["ZCLB"].Equals("W"))
                {
                    _Methods_Quantity.UpdateZCGCL(item);
                }
            }
        }

        public override void UpHL()
        {
            DataRow r = (this.GetDataSource as _SubSegmentsSource).GetRowByOther(this.Current.PID.ToString());
            if (r != null)
            {
                decimal d = ToolKit.ParseDecimal(r["GCL"]);
                this.Current.GCL = ToolKit.ParseDecimal((this.Current.HL * d).ToString("F4"));
                this.UpZMGLJGCL();
            }
            this.Begin(null);
        }
        public override void UpZJTJ()
        {
            if (!this.Current.SDDJ)
            {
                decimal zhdj = this.Current.ZHDJ;
                if (zhdj == 0) zhdj = 1;
                decimal c = this.Current.ZJTJ / zhdj;
                DataRow[] rows = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and ZCLB='W' and IFSDSL=False", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
                if (rows.Length < 1)
                {
                    this.CreateSubByCurrent();
                    // rows = this.Unit.StructSource.ModelQuantity.Select(string.Format("QDID={0} and SSLB={1} and ZCLB='W' and IFSDSL=False", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
                }
                else
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (!rows[i]["LB"].ToString().Contains('%'))
                            rows[i]["XHL"] = ToolKit.ParseDecimal(rows[i]["XHL"]) * c;
                        _Methods_Quantity.RowCalculateAndParentSCDJ(rows[i]);
                    }
                }
                this.Begin(null);
            }
            DataRow r = (this.GetDataSource as _SubSegmentsSource).GetRowByOther(this.Current.ID.ToString());
            if (r != null) r["ZJTJ"] = 0;
        }

        private void CreateSubByCurrent()
        {
            _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(this.Unit);
            DataRow dr_UnitFee = m_Methods_ParamsSeting.GetUnitFeeInfo(this.Current.OLDXMBM);

            decimal gLF = ToolKit.ParseDecimal(dr_UnitFee["GLFFL"]) * 0.01m;
            decimal LR = ToolKit.ParseDecimal(dr_UnitFee["LRFL"]) * 0.01m;
            decimal xhl = this.Current.ZJTJ / (1 + gLF + LR + gLF * LR);
            DataRow r = this.Unit.StructSource.ModelQuantity.NewRow();
            r["YSBH"] = APP.RepairQuantityUnit.GetRepairBH(this.Unit, "材料");
            r["YSMC"] = this.Current.XMMC;
            r["YSDW"] = this.Current.DW;
            r["YSXHL"] = xhl;
            r["DEDJ"] = 1;
            r["BH"] = r["YSBH"];
            r["MC"] = this.Current.XMMC;
            r["DW"] = this.Current.DW;
            r["XHL"] = xhl;
            r["SCDJ"] = 1;
            r["LB"] = "材料";
            r["ZCLB"] = "W";
            r["SDCLB"] = string.Empty;
            r["SDCXS"] = 0;
            r["IFSC"] = true;
            r["IFFX"] = false;
            r["IFSDSCDJ"] = false;
            r["IFZYCL"] = true;
            r["YTLB"] = string.Empty;
            this.CreateGLJ(r);
        }
        public DataRow this[string GLJBH]
        {
            get
            {
                DataRow[] rows = this.Unit.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and BH='{2}'", this.Current.ID, this.Current.SSLB, GLJBH), "", DataViewRowState.CurrentRows);
                if (rows.Length > 0) return rows[0];
                return null;
            }
        }
    }
}
