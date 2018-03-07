using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_Infomation
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

        private _Business m_CurrentBusiness = null;
        /// <summary>
        /// 当前操作的对象业务
        /// </summary>
        public _Business CurrentBusiness
        {
            get { return m_CurrentBusiness; }
            set { m_CurrentBusiness = value; }
        }
        private _UnInformation _UnInfo;
        private _Method_Sub method_Sub;
        private _Methods_Fixed methods_Fixed;
        DataTable dt = null;
        private decimal RGDJ = 0m;
        private decimal QTJXDJ = 0m;
        private decimal DZJXDJ = 0m;
        private decimal JXDJ = 0m;
        public _Methods_Infomation(_UnitProject p_Unit, _Business p_bus)
        {
            m_Unit = p_Unit;
            this._UnInfo = APP.UnInformation;
            this.m_CurrentBusiness = p_bus;
            method_Sub = _Method_Sub.GetSub(this.m_CurrentBusiness, this.m_Unit);
            methods_Fixed = new _Methods_Fixed(this.m_CurrentBusiness, this.m_Unit, null);
            dt = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"].Copy();
            if (!dt.Columns.Contains("fl"))
            {
                dt.Columns.Add("fl", typeof(double));
            }
            if (!dt.Columns.Contains("SCDJ"))
            {
                dt.Columns.Add("SCDJ", typeof(double));
            }
            if (dt.PrimaryKey.Length == 0)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns["CAIJBH"] };
            }
        }
        /// <summary>
        /// 创建所有清单到分部分项
        /// </summary>
        /// <param name="Is_TH">是否替换</param>
        public void CreatAll(bool Is_TH)
        {
            foreach (DataRow r in this._UnInfo.QDTable.Rows)
            {
                if (ToolKit.ParseBoolen(r["Check"]))
                {
                    Creat(r, Is_TH);
                }
            }
        }
        /// <summary>
        /// 根据某一行插入清单到分部分项
        /// </summary>
        /// <param name="Is_th">是否替换</param>
        public void Creat(DataRow row, bool Is_th)
        {
            _Entity_SubInfo info = new _Entity_SubInfo();
            //info.ISXSHS = false;
            if (!row["WZLX"].Equals("措施项目"))
            {
                //标示码规则：
                //定额号，工程量系数，换算前编号，换算后编号｜定额号，工程量系数，换算前编号，换算后编号｜定额号，工程量系数，换算前编号，换算后编号｜) +当前时间+G+首次加密锁号+G + @ +
                //清单基本编号 + Q+当前时间+GCXX+当前加密锁号+H+五位流水码五位流水码从00001开始，判断标示码包含GCXX的清单流水码不重复

                //int intCountQD = GLODSOFT.QDJJ.BUSINESS._Methods.GetCountByBH(row["QDBH"].ToString(), this.m_Unit.StructSource.ModelSubSegments);
                int intCountQD = 0;
                if (row.Table.Columns.Contains("BZ"))
                {
                    //string beiZhu = row["BZ"].ToString();
                    string beiZhu = row["TJ"].ToString();
                    intCountQD = GLODSOFT.QDJJ.BUSINESS._Methods.GetCountByBH(beiZhu, this.m_Unit.StructSource.ModelSubSegments);
                }
                string strBEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetQDbeizhu(row["QDBH"].ToString(), intCountQD, "GCXX");
                if (row.Table.Columns.Contains("BZ") && !string.IsNullOrEmpty(row["BZ"].ToString()))
                {
                    string beiZhu = row["BZ"].ToString();
                    strBEIZHU = beiZhu + "@" + strBEIZHU;
                }
                SetQD(row, info, strBEIZHU);
                //if (Is_th)//此处为替换
                if(intCountQD > 0)
                {
                    int m = -1;
                    //DataRow Einfo = Exists(row["QDBH"].ToString());
                    //DataRow Einfo = Exists(row["BZ"].ToString());
                    DataRow Einfo = Exists(row["TJ"].ToString());
                    if (Einfo != null)
                    {
                        m = ToolKit.ParseInt(Einfo["Sort"]);
                        Einfo.Delete();

                    }
                    info.ZDSC = true;
                    this.method_Sub.Create(m, info);
                }
                else
                {
                    info.ZDSC = true;
                    this.method_Sub.Create(-1, info);
                }
            }
            string StrWher = string.Format("QDBH='{0}' and TJ='{1}' and Check='{2}' ", row["QDBH"], row["TJ"], "True");
            DataRow[] rows = this._UnInfo.DETable.Select(StrWher);
            int intSD_ZM = 0;
            foreach (DataRow item in rows)
            {
                // 标示码规则：当前所属清单基本编号 +D+当前时间+GCXX+当前加密锁号+H+五位流水码五位流水码从00001开始，判断标示码包含GCXX的定额流水码不重复
                string strBEIZHU_ZM = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCXX", ++intSD_ZM, row["QDBH"].ToString());
                CreateZM(item, info, Is_th, strBEIZHU_ZM);
            }
            // info.ISXSHS = true;
            //清单刷新完成 则把默认打钩取消掉 是否刷新到分部分项打钩
            row.BeginEdit();
            row["Check"] = false;
            row["IsFresh"] = true;
            this._UnInfo.EventCheck(row, true);
            row.EndEdit();
            //实现逻辑

        }
        /// <summary>
        /// 刷新到措施项目
        /// </summary>
        /// <param name="row"></param>
        /// <param name="info"></param>
        /// <param name="Is_th"></param>
        /// <param name="strBEIZHU"></param>
        public void CreateCSZM(DataRow[] ZMRows, bool Is_th)
        {
            foreach (DataRow row in ZMRows)
            {
                APP.UserPriceLibrary.AllQuantityUnit = this.Unit.StructSource.ModelQuantity;
                APP.UserPriceLibrary.UnName = this.Unit.Name;
                APP.UserPriceLibrary.Range = 1;

                _Entity_SubInfo sinfo = new _Entity_SubInfo();
                SetZM(row, sinfo, "");
                if (_Constant.超高定额号.IndexOf("'" + sinfo.OLDXMBM + "'") != -1)
                {
                    try
                    {
                        ChangeDECJ(sinfo);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //根据位置找清单
                DataRow[] rows = this.Unit.StructSource.ModelMeasures.Select("XMBM='" + row["WZ"] + "'", "id desc");
                if (rows.Length > 0)
                {
                    _Entity_SubInfo info1 = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info1, rows[0]);
                    DataRow[] rowsDE = this.Unit.StructSource.ModelMeasures.Select(string.Format(" ZDSC=True and XMBM='{0}' and PID='{1}'", row["DEBH"], info1.ID), "id desc");
                    int m_Sort = -1;
                    if (Is_th && rowsDE.Length > 0)
                    {
                        m_Sort = ToolKit.ParseInt(rowsDE[0]["Sort"]);
                        rowsDE[0].Delete();
                    }
                    this.methods_Fixed = new _Mothods_MFixed(this.CurrentBusiness, this.Unit, info1);
                    sinfo.ZDSC = true;
                    this.methods_Fixed.Create(m_Sort, sinfo);
                }
            }
        }

        private void CreateZM(DataRow row, _Entity_SubInfo info, bool Is_th, string strBEIZHU)
        {
            APP.UserPriceLibrary.AllQuantityUnit = this.Unit.StructSource.ModelQuantity;
            APP.UserPriceLibrary.UnName = this.Unit.Name;
            APP.UserPriceLibrary.Range = 1;

            _Entity_SubInfo sinfo = new _Entity_SubInfo();
            //sinfo.ISXSHS = false;
            SetZM(row, sinfo, strBEIZHU);
            //info.Create(sinfo);
            if (row["WZLX"].Equals("措施项目"))
            {
                if (_Constant.超高定额号.IndexOf("'" + sinfo.OLDXMBM + "'") != -1)
                {
                    ChangeDECJ(sinfo);
                }
                //根据位置找清单
                DataRow[] rows = this.Unit.StructSource.ModelMeasures.Select("XMBM='" + row["WZ"] + "'", "id desc");
                if (rows.Length > 0)
                {
                    _Entity_SubInfo info1 = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info1, rows[0]);
                    DataRow[] rowsDE = this.Unit.StructSource.ModelMeasures.Select(string.Format(" ZDSC=True and XMBM='{0}' and PID='{1}'", row["DEBH"], info1.ID), "id desc");
                    int m_Sort = -1;
                    if (Is_th && rowsDE.Length > 0)
                    {
                        m_Sort = ToolKit.ParseInt(rowsDE[0]["Sort"]);
                        rowsDE[0].Delete();
                    }
                    this.methods_Fixed = new _Mothods_MFixed(this.CurrentBusiness, this.Unit, info1);
                    sinfo.ZDSC = true;
                    this.methods_Fixed.Create(m_Sort, sinfo);
                }
            }
            else
            {
                this.methods_Fixed.Current = info;
                this.methods_Fixed.CreateByGCXX(-1, sinfo);
            }
            if (!string.IsNullOrEmpty(row["ZCMCTH"].ToString()))
            {
                DataRow[] drs = this.Unit.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND LB='主材'", sinfo.SSLB, sinfo.ID));
                foreach (DataRow item in drs)
                {
                    item.BeginEdit();
                    item["MC"] = row["ZCMCTH"];
                    APP.UserPriceLibrary.Update("MC", item["MC", DataRowVersion.Current], item);
                    item.EndEdit();
                }
            }
            
        }
        public DataRow ExistsThis(string QDBH, string TJ)
        {
            DataRow[] rows = this._UnInfo.QDTable.Select(string.Format("QDBH='{0}' and TJ='{1}'", QDBH, TJ));
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else
            {
                return null;
            }
        }
        public DataRow ExistsByQDBH(string QDBH)
        {
            DataRow[] rows = this._UnInfo.QDTable.Select(string.Format("QDBH='{0}'", QDBH));
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else
            {
                return null;
            }
        }
        public DataRow Exists(string QDBH)
        {
            //IEnumerable<DataRow> infos = from n in this.m_Unit.StructSource.ModelSubSegments.AsEnumerable()
            //                             where ToolKit.ParseBoolen(n["ZDSC"]) && n["OLDXMBM"].Equals(QDBH)
            //                             orderby n["XMBM"] descending
            //                             select n;

            //IEnumerable<DataRow> infos = from n in this.m_Unit.StructSource.ModelSubSegments.AsEnumerable()
            //                             where ToolKit.ParseBoolen(n["ZDSC"]) && n["BeiZhu"].ToString().Substring(0, n["BeiZhu"].ToString().IndexOf("@")).Equals(QDBH)
            //                             orderby n["XMBM"] descending
            //                             select n;

            IEnumerable<DataRow> infos = from n in this.m_Unit.StructSource.ModelSubSegments.AsEnumerable()
                                         where ToolKit.ParseBoolen(n["ZDSC"]) && n["BeiZhu"].ToString().Contains(QDBH)
                                         orderby n["XMBM"] descending
                                         select n;

            try
            {
                if (infos.Count() > 0)
                {
                    return infos.First() as DataRow;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }

        }
        private string GetQDSY(string QDBH)
        {
            DataTable table = this.m_Unit.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"];
            DataRow[] rows = table.Select(string.Format("QINGDBH='{0}'", QDBH));
            if (rows.Length > 0) return rows[0]["QINGDSYBH"].ToString();
            else return "999999";
        }
        private void SetQD(DataRow row, _Entity_SubInfo info, string strBEIZHU)
        {

            string XMMC = row["QDMC"].ToString();
            info.XMBM = GLODSOFT.QDJJ.BUSINESS._Methods.GetQBH(row["QDBH"].ToString(), this.m_Unit.StructSource.ModelSubSegments);
            info.XMMC = XMMC;
            info.OLDXMBM = row["QDBH"].ToString();
            info.DW = row["DW"].ToString();
            info.ZJWZ = row["ZJ"].ToString();
            info.ZJWZ = GetQDSY(row["QDBH"].ToString());
            info.LB = "清单";
            //info.XMTZ = info.XMTZ1 + info.GCNR + info.TJNR;
            info.GCLJSS = "";
            info.HL = 1.00m;
            info.GCL = ToolKit.ParseDecimal(row["GCL"]);
            info.ZJWZ = GetQDSY(info.OLDXMBM);
            info.LibraryName = this.m_Unit.Property.Libraries.ListGallery.FullName;
            info.SC = true;
            info.ZDSC = true;
            info.BEIZHU = strBEIZHU;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="info"></param>
        private void SetZM(DataRow row, _Entity_SubInfo info, string strBEIZHU)
        {
            info.XMBM = row["DEBH"].ToString();
            info.XMMC = row["DEMC"].ToString();
            info.OLDXMBM = row["DEBH"].ToString();
            info.DW = row["DW"].ToString();
            info.LB = "子目";
            info.XMTZ = "";
            info.GCLJSS = "";
            //info.HL = 1.00m;
            //update by fuqiang 2013-8-19
            if(row.Table.Columns.Contains("XS"))
                info.HL = ToolKit.ParseDecimal(row["XS"]);
            else
                info.HL = 1.00m;
            info.SC = true;
            if (row.Table.Columns.Contains("GCL"))
                info.GCL = ToolKit.ParseDecimal(row["GCL"]);
            else
                info.GCL = 1;
            info.LibraryName = this.m_Unit.Property.Libraries.FixedLibrary.FullName;
            info.BEIZHU = strBEIZHU;
            DataTable dt = this.m_Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"];
            if (dt != null)
            {
                info.XMBM = info.XMBM.Replace("　", " ");
                string[] temp = info.XMBM.Split(' ');
                DataRow[] rows = dt.Select(string.Format("DINGEH='{0}'", temp[0]));
                if (rows.Length > 0)
                {
                    info.JX = rows[0]["JIANGX"].ToString() == "是" ? true : false;
                    info.TX = rows[0]["TX1"].ToString();
                    info.DECJ = rows[0]["DECJ"].ToString();
                    if (row.Table.Columns.Contains("HSQ") && row.Table.Columns.Contains("HSH"))
                    {
                        string oldvalue = row["HSQ"].ToString();
                        string newvalue = row["HSH"].ToString();
                        if (oldvalue.Length > 0)
                        {
                            info.XMBM = info.XMBM + "换";
                            info.DECJ = info.DECJ.Replace(oldvalue, newvalue);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 修改定额材机
        /// </summary>
        /// <param name="view"></param>
        private void ChangeDECJ(_Entity_SubInfo sinfo)
        {
            if (sinfo != null)
            {
                InitDJ();
                GetSCDJ(sinfo.DECJ);
                string _caj = sinfo.DECJ.ToString();
                string Str = "";
                string[] _CaiBh = _caj.Split('|');
                for (int i = 0; i < _CaiBh.Length; i++)
                {
                    DataRow row = dt.Rows.Find(_CaiBh[i].Split(',')[0]);
                    if (row != null)
                    {
                        decimal d = ToolKit.ParseDecimal(row["fl"]) * 0.01m;
                        Str += _CaiBh[i].Split(',')[0] + "," + d + "," + row["SCDJ"].ToString() + "|";
                    }
                }
                if (!string.IsNullOrEmpty(Str))
                {
                    sinfo.DECJ = Str;
                }
            }
        }

        decimal SetDJ(string str)
        {
            DataRow[] rows0 = this.Unit.StructSource.ModelSubSegments.Select(string.Format("LB = '子目' and  JX='True'"));
            DataRow[] rows1 = this.Unit.StructSource.ModelMeasures.Select(string.Format("LB = '子目' and  JX='True'"));
            List<DataRow> r_list = new List<DataRow>();
            r_list.AddRange(rows0);
            r_list.AddRange(rows1);
            decimal d = 0m;
            foreach (var item0 in r_list)
            {
                DataRow[] rows = this.Unit.StructSource.ModelQuantity.Select(string.Format("LB in ({0}) and  ZMID={1} and ZCLB='W'", str, item0["ID"]));
                foreach (DataRow item in rows)
                {
                    d += ToolKit.ParseDecimal(item["SCHJ"]);
                }
            }
            return d;
        }
        private void InitDJ()
        {
            string Rg = "'人工','其他人工费'";
            string DZ = "'吊装机械','吊装机械台班'";
            string QT = "'机械','其他机械费','机械台班'";
            // string JX = "'机械','其他机械费','机械台班'";
            this.RGDJ = SetDJ(Rg);
            this.DZJXDJ = SetDJ(DZ);
            this.QTJXDJ = SetDJ(QT);
            this.JXDJ = this.DZJXDJ + this.QTJXDJ;
        }


        private void GetSCDJ(string decj)
        {
            string dian = "F4";
            string[] _CaiBh = decj.Split('|');
            string Fiter = "";
            for (int i = 0; i < _CaiBh.Length; i++)
            {
                DataRow row = dt.Rows.Find(_CaiBh[i].Split(',')[0]);
                if (row != null)
                {
                    row["fl"] = _CaiBh[i].Split(',')[1];
                    Fiter += "'" + _CaiBh[i].Split(',')[0] + "',";
                }
            }
            if (Fiter.Length > 0)
            {
                Fiter = Fiter.Substring(0, Fiter.Length - 1);
            }
            DataRow[] rows = this.dt.Select(string.Format("CAIJBH in ({0})", Fiter));
            foreach (DataRow item in rows)
            {
                switch (item["CAIJMC"].ToString())
                {
                    case "人工降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.RGDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    case "吊装机械降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.DZJXDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    case "其他机械降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.QTJXDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    case "机械降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.JXDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
