using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods
    {

        public _ObjectSource GetDataSource
        {
            get
            {
                if (this.Current.SSLB.Equals(1))
                {
                    return this.Unit.StructSource.ModelMeasures;
                }
                else
                {
                    return this.Unit.StructSource.ModelSubSegments;
                }
            }
        }


        private _UnitProject m_Unit = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary>
        public _UnitProject Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }
        private _Entity_SubInfo m_Current = null;
        /// <summary>
        /// 当前操作的对象
        /// </summary>
        public _Entity_SubInfo Current
        {
            get { return m_Current; }
            set { m_Current = value; }
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
        public _Methods()
        {

        }
        public _Methods(_UnitProject p_Unit)
        {
            m_Unit = p_Unit;
        }

        public _Methods(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo m_Current)
        {
            this.m_Unit = p_Unit;
            this.m_Current = m_Current;
            this.m_CurrentBusiness = m_Currentbus;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="p_Sort"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public virtual _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info)
        {
            return info;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="p_Sort"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public virtual _Entity_SubInfo Create()
        {
            return this.Current;
        }
        /// <summary>
        /// 删除子项
        /// </summary>
        /// <param name="info"></param>
        public virtual void RemoveChild(_Entity_SubInfo info)
        {

        }
        /// <summary>
        /// 删除全部子项
        /// </summary>
        /// <param name="info"></param>
        public virtual void RemoveAllChild()
        {

        }
        public virtual void CopyTo(_Entity_SubInfo QD_info)
        {

        }
        /// <summary>
        /// 批量创建
        /// </summary>
        /// <param name="infos"></param>
        public virtual void Create(List<_Entity_SubInfo> infos)
        {

        }


        public static _Methods Build(_Business business, _UnitProject project, _Entity_SubInfo entity)
        {

            if (entity.SSLB == 0)
            {
                switch (entity.LB)
                {
                    case "分部-专业":
                        return new _Methods_Pro(business, project, entity);
                    case "分部-章":
                        return new _Method_Chapt(business, project, entity);
                    case "分部-节":
                        return new _Method_Fest(business, project, entity);
                    case "清单":
                        return new _Methods_Fixed(business, project, entity);
                    case "子目":
                    case "子目-增加费":
                    case "子目-降效":
                        return new _Methods_Subheadings(business, project, entity);
                    default:
                        return new _Method_Sub(business, project, entity);
                }
            }
            else
            {
                if (entity.PID == 0)
                {
                    return new _Mothod_Measures(business, project, entity);
                }

                if (string.IsNullOrEmpty(entity.LB) && entity.PID != 0)
                {
                    return new _Motheds_CommonProj(business, project, entity);
                }

                if (entity.LB.Equals("清单"))
                {
                    return new _Mothods_MFixed(business, project, entity);

                }
                if (entity.LB.Contains("子目"))
                {
                    return new _Mothods_MSubheadings(business, project, entity);

                }

                return new _Mothod_Measures(business, project, entity);
            }
        }

        public static _Methods CreateIntace(_Business m_Currentbus, _UnitProject p_un, _Entity_SubInfo info)
        {
            _Methods m = new _Methods(m_Currentbus, p_un, info);
            switch (info.LB)
            {
                case "分部-专业":
                    m = new _Methods_Pro(m_Currentbus, p_un, info);
                    break;
                case "分部-章":
                    m = new _Method_Chapt(m_Currentbus, p_un, info);
                    break;
                case "分部-节":
                    m = new _Method_Fest(m_Currentbus, p_un, info);
                    break;
                case "清单":
                    m = new _Methods_Fixed(m_Currentbus, p_un, info);
                    break;
                case "子目":
                    m = new _Methods_Subheadings(m_Currentbus, p_un, info);
                    break;
                default:
                    break;
            }
            return m;
        }

        public static _Methods CreateIntaceMet(_Business m_Currentbus, _UnitProject p_un, DataRow r)
        {
            _Entity_SubInfo info = new _Entity_SubInfo();
            _ObjectSource.GetObject(info, r);
            _Methods m = new _Methods(m_Currentbus, p_un, info);
            if (info.PID == 0)
            {
                m = new _Mothod_Measures(m_Currentbus, p_un, info);
                return m;

            }
            if (string.IsNullOrEmpty(info.LB) && info.PID != 0)
            {
                m = new _Motheds_CommonProj(m_Currentbus, p_un, info);
                return m;

            }

            if (info.LB.Equals("清单"))
            {
                m = new _Mothods_MFixed(m_Currentbus, p_un, info);
                return m;

            }
            if (info.LB.Contains("子目"))
            {
                m = new _Mothods_MSubheadings(m_Currentbus, p_un, info);
                return m;

            }
            return m;
        }

        public static _Methods CreateIntaceMet(_Business m_Currentbus, _UnitProject p_un, _Entity_SubInfo info)
        {
            _Methods m = new _Methods(m_Currentbus, p_un, info);
            if (info.PID == 0)
            {
                m = new _Mothod_Measures(m_Currentbus, p_un, info);
                return m;

            }
            if (string.IsNullOrEmpty(info.LB) && info.PID != 0)
            {
                m = new _Motheds_CommonProj(m_Currentbus, p_un, info);
                return m;

            }

            if (info.LB.Equals("清单"))
            {
                m = new _Mothods_MFixed(m_Currentbus, p_un, info);
                return m;

            }
            if (info.LB.Contains("子目"))
            {
                m = new _Mothods_MSubheadings(m_Currentbus, p_un, info);
                return m;

            }
            return m;
        }

        /// <summary>
        /// 通过图集库给子目赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        public static void SetSubheadingsInfoByTJ(_Entity_SubInfo info, DataRow dr, string Libname)
        {
            info.XMBM = dr["DEBH"].ToString();
            info.XMMC = dr["DEMC"].ToString();
            info.OLDXMBM = dr["DEBH"].ToString();
            info.DW = dr["DEDW"].ToString();
            info.LB = "子目";
            info.XMTZ = "";
            info.GCLJSS = "";
            info.HL = 1.00m;
            string dw = dr["DEDW"].ToString().Replace("m2", "").Replace("m3", "");
            if (dw == "")
            {
                dw = "1";
            }
            decimal xs = ToolKit.ParseDecimal(dr["GCXS"]);
            if (xs <= 0)
            {
                xs = 1m;
            }

            decimal c = ToolKit.ParseDecimal(dw) * xs;
            if (c == 0)
            {
                c = 1m;
            }
            info.GCL = 1 / c;
            info.LibraryName = Libname;
            _Library.GetLibrary(Libname);
            DataTable dt = (_Library.Libraries[Libname] as DataSet).Tables["定额表"];
            if (dt != null)
            {
                DataRow[] rows = dt.Select(string.Format("DINGEH='{0}'", info.XMBM));
                if (rows.Length > 0)
                {
                    info.DECJ = rows[0]["DECJ"].ToString();
                    string oldvalue = dr["HSQ"].ToString();
                    string newvalue = dr["HSH"].ToString();
                    if (oldvalue.Length > 0)
                    {
                        info.XMBM = info.XMBM + "换";
                        info.DECJ = info.DECJ.Replace(oldvalue, newvalue);
                    }
                    //
                }
            }
            //info.DECJ = dr["DECJ"].ToString();

        }
        /// <summary>
        /// 通过定额库给定额赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        public static void SetSubheadingsInfo(_Entity_SubInfo info, DataRow dr, string Libname)
        {
            info.XMBM = dr[CEntity定额表.FILED_DINGEH].ToString();
            info.XMMC = dr[CEntity定额表.FILED_DINGEMC].ToString();
            info.OLDXMBM = dr[CEntity定额表.FILED_DINGEH].ToString();
            info.TX = dr[CEntity定额表.FILED_TX1].ToString();
            info.DW = dr[CEntity定额表.FILED_DINGEDW].ToString();
            info.LB = "子目";
            info.XMTZ = "";
            info.GCLJSS = "";
            info.HL = 0.00m;
            info.GCL = 1;

            info.ZHDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_DINGEJJ].ToString());
            info.RGFDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_RENGF].ToString());
            info.CLFDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_CAILF].ToString());
            info.JXFDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_JIXF].ToString());
            info.LibraryName = Libname;
            info.DECJ = dr[CEntity定额表.FILED_DECJ].ToString();
            info.JX = dr[CEntity定额表.FILED_JIANGX].ToString() == "是" ? true : false;
            if (dr[CEntity定额表.FILED_TX1].ToString() == "模板")
            {
                info.SC = false;
            }
            else
            {
                info.SC = true;
            }


        }
        /// <summary>
        /// 通过定额库给定额赋值【2013.2.27 李波重载的，作用处理各种备注来源】
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        /// <param name="strCZBM">操作编码 如：SGSR 手工输入、 CXCK 查询窗口</param>
        /// <param name="intSD">流水码</param>
        /// <param name="strQDBH">所属清单编号</param>
        public static void SetSubheadingsInfo(_Entity_SubInfo info, DataRow dr, string Libname, string strCZBM, int intSD, string strQDBH)
        {
            info.XMBM = dr[CEntity定额表.FILED_DINGEH].ToString();
            info.XMMC = dr[CEntity定额表.FILED_DINGEMC].ToString();
            info.OLDXMBM = dr[CEntity定额表.FILED_DINGEH].ToString();
            info.TX = dr[CEntity定额表.FILED_TX1].ToString();
            info.DW = dr[CEntity定额表.FILED_DINGEDW].ToString();
            info.LB = "子目";
            info.XMTZ = "";
            info.GCLJSS = "";
            info.HL = 0.00m;
            info.GCL = 1;

            info.ZHDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_DINGEJJ].ToString());
            info.RGFDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_RENGF].ToString());
            info.CLFDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_CAILF].ToString());
            info.JXFDJ = ToolKit.ParseDecimal(dr[CEntity定额表.FILED_JIXF].ToString());
            info.LibraryName = Libname;
            info.DECJ = dr[CEntity定额表.FILED_DECJ].ToString();
            info.JX = dr[CEntity定额表.FILED_JIANGX].ToString() == "是" ? true : false;
            if (dr[CEntity定额表.FILED_TX1].ToString() == "模板")
            {
                info.SC = false;
            }
            else
            {
                info.SC = true;
            }
            string strBEIZHU;
            strBEIZHU = GetDEbeizhu(strCZBM, intSD, strQDBH);
            info.BEIZHU = strBEIZHU;
        }
        /// <summary>
        /// 获取定额备注
        /// </summary>
        /// <param name="strCZBM">操作编码 如：SGSR 手工输入、 CXCK 查询窗口</param>
        /// <param name="intSD">流水码</param>
        /// <param name="strQDBH">所属清单编号</param>
        /// <returns></returns>
        public static string GetDEbeizhu(string strCZBM, int intSD, string strQDBH)
        {
            string strBEIZHU;
            ///当前锁号
            string strNo = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
            switch (strCZBM)
            {
                case "SGSR":
                    ///右键点插入定额后手工输入定额。
                    ///当前所属清单基本编号  + D+当前时间+SGSR+加密锁号
                    ///注意清单基本编号不包括清单自动生成的流水码需要测试各专业库中补充清单及用户自行补充的清单及补充的定额，如：陕补001   BC020  B0401
                    strBEIZHU = strQDBH + "D" + DateTime.Now.ToString("yyyyMMddHHmmssff") + strCZBM + strNo;
                    break;
                default:
                    ///通过查询窗口生成的定额。
                    ///标示码规则：标示码规则：当前所属清单基本编号 + D+当前时间+CXCK+当前加密锁号+H+五位流水码
                    ///五位流水码从00001开始，判断标示码包含CXCK的定额流水码不重复。注：通过查询窗口包括：清单指引窗口、定额库查询窗口、图集库查询窗口
                    strBEIZHU = strQDBH + "D" + DateTime.Now.ToString("yyyyMMddHHmmssff") + strCZBM + strNo + "H" + intSD.ToString("D5");
                    break;
            }
            return strBEIZHU;
        }
        /// <summary>
        /// 通过清单库给清单赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        public static void SetFixedInfo(_Entity_SubInfo info, DataRow dr, string Libname, DataTable dt)
        {
            info.XMBM = _Methods.GetQBH(dr[CEntity清单表.FILED_QINGDBH].ToString(), dt);
            info.XMMC = dr[CEntity清单表.FILED_QINGDMC].ToString();
            info.OLDXMBM = dr[CEntity清单表.FILED_QINGDBH].ToString();
            info.DW = dr[CEntity清单表.FILED_QINGDDW].ToString();
            info.TX = dr[CEntity清单表.FILED_TX1].ToString();
            info.LB = "清单";
            info.XMTZ = "";
            info.GCLJSS = "";
            info.HL = 1.00m;
            info.GCL = 1.00m;
            info.ZJWZ = dr[CEntity清单表.FILED_QINGDSYBH].ToString();
            info.LibraryName = Libname;
            info.SC = true;
            ///右键点插入清单后手工输入清单。
            ///标示码规则：清单基本编号  + Q + 当前时间 + SGSR + 加密锁号
            ///注意清单基本编号不包括清单自动生成的流水码需要测试各专业库中补充清单及用户自行补充的清单，如：陕补001   BC020  B0401
            info.BEIZHU = info.OLDXMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmssff") + "SGSR" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo;

        }
        /// <summary>
        /// 通过清单库给清单赋值【2013.2.25 李波重载的，作用处理各种备注来源】
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        /// <param name="dt"></param>
        /// <param name="strCZBM">操作编码 如：SGSR 手工输入、 CXCK 查询窗口</param>
        public static void SetFixedInfo(_Entity_SubInfo info, DataRow dr, string Libname, DataTable dt, string strCZBM)
        {
            info.XMBM = _Methods.GetQBH(dr[CEntity清单表.FILED_QINGDBH].ToString(), dt);
            info.XMMC = dr[CEntity清单表.FILED_QINGDMC].ToString();
            info.OLDXMBM = dr[CEntity清单表.FILED_QINGDBH].ToString();
            info.DW = dr[CEntity清单表.FILED_QINGDDW].ToString();
            info.TX = dr[CEntity清单表.FILED_TX1].ToString();
            info.LB = "清单";
            info.XMTZ = "";
            info.GCLJSS = "";
            info.HL = 1.00m;
            info.GCL = 1.00m;
            info.ZJWZ = dr[CEntity清单表.FILED_QINGDSYBH].ToString();
            info.LibraryName = Libname;
            info.SC = true;
            ///当前清单存在个数
            int intCountByBH = GetCountByBH(info.OLDXMBM, dt);
            string strBEIZHU;
            strBEIZHU = GetQDbeizhu(info.OLDXMBM, intCountByBH, strCZBM);
            info.BEIZHU = strBEIZHU;
        }
        /// <summary>
        /// 获取清单备注
        /// </summary>
        /// <param name="strXMBM"></param>
        /// <param name="dt"></param>
        /// <param name="strCZBM"></param>
        /// <returns></returns>
        public static string GetQDbeizhu(string strXMBM, int intCountByBH, string strCZBM)
        {
            string strBEIZHU;
            ///当前锁号
            string strNo = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
            switch (strCZBM)
            {
                case "SGSR":
                    ///右键点插入清单后手工输入清单。
                    ///标示码规则：清单基本编号  + Q + 当前时间 + SGSR + 加密锁号
                    ///注意清单基本编号不包括清单自动生成的流水码需要测试各专业库中补充清单及用户自行补充的清单，如：陕补001   BC020  B0401
                    strBEIZHU = strXMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmssff") + strCZBM + strNo;
                    break;
                default:
                    ///通过查询窗口生成的清单。
                    ///标示码规则：清单基本编号 + Q + 当前时间+CXCK+当前加密锁号+H+五位流水码
                    ///五位流水码从00001开始，判断标示码包含CXCK的清单流水码不重复
                    strBEIZHU = strXMBM + "Q" + DateTime.Now.ToString("yyyyMMddHHmmssff") + strCZBM + strNo + "H" + (++intCountByBH).ToString("D5");
                    break;
            }
            return strBEIZHU;
        }
        /// <summary>
        /// 统计个数
        /// </summary>
        /// <param name="BH">编号</param>
        /// <param name="dt">数据集</param>
        /// <returns></returns>
        public static int GetCountByBH(string BH, DataTable dt)
        {
            int intCount = 0;
            ////if (dt.Columns.Contains("OLDXMBM"))
            ////    intCount = dt.AsEnumerable().Count<DataRow>( p =>p.RowState!=DataRowState.Deleted&& p["OLDXMBM"].ToString() == BH);


            //if (dt.Columns.Contains("BeiZhu"))
            //{
            //    int index = 0;
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        string beiZhu = item["BeiZhu"].ToString();
            //        index = beiZhu.IndexOf("@");
            //        if (item.RowState != DataRowState.Deleted && !string.IsNullOrEmpty(beiZhu) && index > 0
            //            && beiZhu.Substring(0, index).Equals(BH))



            //        //if (item.RowState != DataRowState.Deleted && !string.IsNullOrEmpty(item["BeiZhu"].ToString()) && item["BeiZhu"].ToString().IndexOf("@") > 0
            //        //    && item["BeiZhu"].ToString().Substring(0, item["BeiZhu"].ToString().IndexOf("@")).Equals(BH))
            //            intCount++;
            //    }
            //}


            //if (dt.Columns.Contains("BeiZhu"))
            //    intCount = dt.AsEnumerable().Count<DataRow>(p => p.RowState != DataRowState.Deleted &&
            //        !string.IsNullOrEmpty(p["BeiZhu"].ToString()) && p["BeiZhu"].ToString().IndexOf("@") > 0 &&
            //        p["BeiZhu"].ToString().Substring(0, p["BeiZhu"].ToString().IndexOf("@")).Equals(BH));

            if (dt.Columns.Contains("BeiZhu"))
                intCount = dt.AsEnumerable().Count<DataRow>(p => p.RowState != DataRowState.Deleted && p["BeiZhu"].ToString().Contains(BH));
            //!string.IsNullOrEmpty(p["BeiZhu"].ToString()) && p["BeiZhu"].ToString().IndexOf("@") > 0 &&
            //p["BeiZhu"].ToString().Substring(0, p["BeiZhu"].ToString().IndexOf("@")).Equals(BH));

            return intCount;
        }

        /// <summary>
        /// 获取编号【基本编号+三位流水码】
        /// </summary>
        /// <param name="BH"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetQBH(string BH, DataTable dt)
        {
            string str = BH;
            DataRow infos = dt.Select(string.Format("OLDXMBM='{0}'", BH), "XMBM DESC", DataViewRowState.CurrentRows).FirstOrDefault();
            if (infos == null)
            {
                str += "001";
            }
            else
            {
                string num = infos["XMBM"].ToString().Replace(BH, "");
                num = (ToolKit.ParseInt(num) + 1).ToString("D3");
                //if (num.Length == 1)
                //{
                //    num = "00" + num;
                //}
                //if (num.Length == 2)
                //{
                //    num = "0" + num;
                //}
                str += num;
            }
            return str;
        }


        public static bool IsInJX()
        {
            //string JXDE = "15-1,15-2,15-3,15-4,15-5,15-6,15-7,15-8,15-9,15-10,15-11,15-23,15-24,15-25,15-26,15-27,15-28,15-29,15-30,15-31";
            //bool flag = false;
            //string[] arr = JXDE.Split(',');
            //string DEH = row["DINGEH"].ToString();
            //foreach (string item in arr)
            //{
            //    if (item == DEH)
            //    {
            //        flag = true;
            //        break;
            //    }
            //}
            return false;
        }
        /// <summary>
        /// 修改工程量
        /// </summary>
        public virtual void UpGCL()
        {

        }

        /// <summary>
        /// 修改直接调价
        /// </summary>
        public virtual void UpZJTJ()
        {

        }
        /// <summary>
        /// 修改含量
        /// </summary>
        public virtual void UpHL()
        {

        }
        public virtual void Calculate()
        {

        }

        public virtual void Begin(List<int> session)
        {

        }
        public virtual void UpdataZMQF(DataRow[] rows)
        {
            _SubheadingsFeeSource info = null;//获取当前单位工程的子目取费
            foreach (DataRow r in rows)
            {
                foreach (DataRow item in info.Rows)
                {
                    if (!string.IsNullOrEmpty(item["TBJSJC"].ToString()))
                    {
                        r["TBJSJC"] = item["TBJSJC"];
                    }
                    if (!string.IsNullOrEmpty(item["BDJSJC"].ToString()))
                    {
                        r["BDJSJC"] = item["BDJSJC"];
                    }
                    if (ToolKit.ParseDecimal(item["FL"]) > 0)
                    {
                        r["FL"] = item["FL"];
                    }
                }
            }


        }
        /// <summary>
        /// 只计算当前
        /// </summary>
        public virtual void BeginCurrent()
        {

        }

        /// <summary>
        /// 只计算子目取费
        /// </summary>
        public virtual void SubheadingsFeeCurrent()
        {

        }
        public void SetSort(int p_Sort, _Entity_SubInfo p_info)
        {

            string Str_where = string.Format("Deep={0}", p_info.Deep);
            if (p_Sort < 0)
            {
                DataRow[] rows0 = this.GetDataSource.Select(Str_where, " Sort desc", DataViewRowState.CurrentRows);
                if (rows0.Length > 0) p_info.Sort = ToolKit.ParseInt(rows0[0]["Sort"]) + 1;
                else { p_info.Sort = 1; }
            }
            else
            {
                p_info.Sort = p_Sort + 1;//赋值排序字段
            }
            //this.GetDataSource.AsEnumerable().Where(p => p["Deep"].Equals(p_info.Deep) && ToolKit.ParseInt(p["Sort"])>=p_info.Sort).Any(s => ToolKit.ParseInt((s["Sort"] = ToolKit.ParseInt(s["Sort"]) + 1)) > 0);
            DataRow[] rows = this.GetDataSource.Select(Str_where + string.Format(" and  Sort>={0}", p_info.Sort), "Sort asc", DataViewRowState.CurrentRows);
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i]["Sort"] = p_info.Sort + i + 1;
            }
        }

        public static bool ExistsBH(string p_DEBH, _Entity_SubInfo info)
        {
            bool flag = false;
            int m = 0;
            string XMBM = info.XMBM.ToUpper();
            p_DEBH = p_DEBH.ToUpper();
            if (XMBM.IndexOf("-") > 0)
            {
                m = XMBM.IndexOf("-");
            }
            string DEH = XMBM.Substring(0, m);
            string[] DEBHArry = p_DEBH.Split(',');
            if (p_DEBH.Contains("-") && p_DEBH.Substring(p_DEBH.IndexOf("-")).Contains(DEH))//含有-并且定额号有可能存在的时候的处理
            {
                string[] ItemArr = p_DEBH.Substring(p_DEBH.IndexOf("-")).Split(',')[0].Split('～');
                int MinNum = Convert.ToInt32(ItemArr[0].Substring(ItemArr[0].IndexOf('-') + 1));
                int MaxNum = Convert.ToInt32(ItemArr[1].Substring(ItemArr[1].IndexOf('-') + 1));
                for (int i = MinNum; i <= MaxNum; i++)
                {
                    if (XMBM == ItemArr[1].Substring(0, ItemArr[1].IndexOf('-') + 1) + i.ToString())
                    {
                        flag = true;
                        break;
                    }
                }

            }
            else
            {
                foreach (string item in DEBHArry)
                {
                    if (!item.Contains("-"))
                    {

                        if (!item.Contains("～"))//若不存在波浪线直接比较
                        {
                            if (item == DEH)
                            {
                                flag = true;
                                break;
                            }
                        }
                        else
                        {
                            string[] ItemArr = item.Split('～');
                            if (ItemArr[0].Contains("B"))
                            {
                                int MinNum = Convert.ToInt32(ItemArr[0].Substring(ItemArr[0].IndexOf('B') + 1));
                                int MaxNum = Convert.ToInt32(ItemArr[1].Substring(ItemArr[1].IndexOf('B') + 1));
                                for (int i = MinNum; i <= MaxNum; i++)
                                {
                                    if (DEH == "B" + i.ToString())
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }


                        }
                    }

                }
            }

            return flag;
        }

        /// <summary>
        /// 获取字符窜中第一个字母前的所有数字
        /// </summary>
        /// <returns></returns>
        public static decimal GetNumber(string info)
        {
            if (info == null) return 0;
            string Str = info;
            Str = System.Text.RegularExpressions.Regex.Match(Str, @"[0-9]\d+(\.\d+)?").Value;
            if (Str == string.Empty)
            {
                return 1m;
            }
            else
            {
                return decimal.Parse(Str);
            }

        }

        public static string Replace(string Textvalue, string Titile)
        {

            string[] Ayy = Textvalue.Split(new string[] { _Constant.回车符 + "【" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in Ayy)
            {
                if (item.Contains(string.Format("{0}】", Titile)))
                {
                    string a = _Constant.回车符 + "【" + item;
                    Textvalue = Textvalue.Replace(a, "");
                }
            }
            return Textvalue;
        }
        public static int FindIndex(string Str, string Titile)
        {
            int index = Str.Length;
            int m = 0;
            for (int i = 0; i < _Constant.XMTZ.Length; i++)
            {
                if (_Constant.XMTZ[i] == Titile)
                { m = i; break; }
            }
            if (m < _Constant.XMTZ.Length - 1)
            {
                for (int i = m + 1; i < _Constant.XMTZ.Length; i++)
                {
                    index = Str.IndexOf(_Constant.XMTZ[i]);
                    if (index > -1)
                    {
                        break;
                    }
                }
                if (index < 0) { index = Str.Length; }
            }
            return index;
        }

        public static string SetTextBox(string Textvalue, string str, string Titile)
        {
            if (Textvalue.Contains(Titile.Trim()))
            {
                Textvalue = _Methods.Replace(Textvalue, Titile.Trim().Replace("【", "").Replace("】", ""));

            }
            else
            {
                Textvalue = Textvalue.Insert(FindIndex(Textvalue, Titile), str);
            }
            return Textvalue;
        }

        public static void Calculate(_Business business, _UnitProject project, params _Entity_SubInfo[] entityes)
        {
            var zhuanye = entityes.Select<_Entity_SubInfo, _Entity_SubInfo>(m => m.LB == "分部-专业" ? m : null).ToList();
            var zhang = entityes.Select<_Entity_SubInfo, _Entity_SubInfo>(m => m.LB == "分部-章" ? m : null).ToList();
            var jie = entityes.Select<_Entity_SubInfo, _Entity_SubInfo>(m => m.LB == "分部-节" ? m : null).ToList();
            var qingdan = entityes.Select<_Entity_SubInfo, _Entity_SubInfo>(m => string.IsNullOrEmpty(m.LB) ? null : (m.LB.StartsWith("清单") ? m : null)).ToList();
            var zimu = entityes.Select<_Entity_SubInfo, _Entity_SubInfo>(m => string.IsNullOrEmpty(m.LB) ? null : (m.LB.StartsWith("子目") ? m : null)).ToList();
            var root = new List<_Entity_SubInfo>();
            var source = project.StructSource;
            var processed = new List<string>();

            processed.Clear();
            foreach (_Entity_SubInfo z in zimu)
            {
                if (z == null)
                {
                    continue;
                }

                if (processed.Contains(z.ID.ToString()))
                {
                    continue;
                }
                else
                {
                    processed.Add(z.ID.ToString());
                }

                var method = Build(business, project, z);
                method.BeginCurrent();

                if (z.SSLB == 0)
                {

                    var rows1 = source.ModelSubSegments.Select("ID = '" + z.FPARENTID + "'");
                    qingdan.AddRange(_Entity_SubInfo.ParseMore(rows1));
                }
                else
                {
                    var rows2 = source.ModelMeasures.Select("ID = '" + z.FPARENTID + "'");
                    qingdan.AddRange(_Entity_SubInfo.ParseMore(rows2));
                }
            }

            processed.Clear();
            foreach (_Entity_SubInfo q in qingdan)
            {
                if (q == null)
                {
                    continue;
                }

                if (processed.Contains(q.ID.ToString()))
                {
                    continue;
                }
                else
                {
                    processed.Add(q.ID.ToString());
                }

                var method = Build(business, project, q);
                method.BeginCurrent();
                //method.Calculate();
                //method.Begin(null);


                if (q.SSLB == 0)
                {

                    var rows1 = source.ModelSubSegments.Select("ID = '" + q.PID + "'");
                    root.AddRange(_Entity_SubInfo.ParseMore(rows1));
                }
                else
                {
                    var rows2 = source.ModelMeasures.Select("ID = '" + q.PID + "'");
                    root.AddRange(_Entity_SubInfo.ParseMore(rows2));
                }
            }

            processed.Clear();
            foreach (_Entity_SubInfo j in jie)
            {
                if (j == null)
                {
                    continue;
                }

                if (processed.Contains(j.ID.ToString()))
                {
                    continue;
                }
                else
                {
                    processed.Add(j.ID.ToString());
                }

                var method = Build(business, project, j);

                method.BeginCurrent();
                //method.Calculate();
                //method.Begin(null);


                if (j.SSLB == 0)
                {
                    var rows1 = source.ModelSubSegments.Select("ID = '" + j.CPARENTID + "'");
                    zhang.AddRange(_Entity_SubInfo.ParseMore(rows1));
                }
                else
                {
                    var rows2 = source.ModelMeasures.Select("ID = '" + j.CPARENTID + "'");
                    zhang.AddRange(_Entity_SubInfo.ParseMore(rows2));
                }
            }

            processed.Clear();
            foreach (_Entity_SubInfo z in zhang)
            {
                if (z == null)
                {
                    continue;
                }

                if (processed.Contains(z.ID.ToString()))
                {
                    continue;
                }
                else
                {
                    processed.Add(z.ID.ToString());
                }

                var method = Build(business, project, z);

                method.BeginCurrent();
                //method.Calculate();
                //method.Begin(null);

                if (z.SSLB == 0)
                {
                    var rows1 = source.ModelSubSegments.Select("ID = '" + z.PPARENTID + "'");
                    zhuanye.AddRange(_Entity_SubInfo.ParseMore(rows1));
                }
                else
                {
                    var rows2 = source.ModelMeasures.Select("ID = '" + z.PPARENTID + "'");
                    zhuanye.AddRange(_Entity_SubInfo.ParseMore(rows2));
                }

            }

            processed.Clear();
            foreach (_Entity_SubInfo z in zhuanye)
            {
                if (z == null)
                {
                    continue;
                }

                if (processed.Contains(z.ID.ToString()))
                {
                    continue;
                }
                else
                {
                    processed.Add(z.ID.ToString());
                }

                var method = Build(business, project, z);
                method.BeginCurrent();

                var rows = source.ModelSubSegments.Select("ID = '" + z.PID + "'");
                root.AddRange(_Entity_SubInfo.ParseMore(rows));

                if (z.SSLB == 0)
                {
                    var rows1 = source.ModelSubSegments.Select("ID = '" + z.PID + "'");
                    root.AddRange(_Entity_SubInfo.ParseMore(rows1));
                }
                else
                {
                    var rows2 = source.ModelMeasures.Select("ID = '" + z.PID + "'");
                    root.AddRange(_Entity_SubInfo.ParseMore(rows2));
                }
            }

            processed.Clear();
            foreach (var r in root)
            {
                if (r == null)
                {
                    continue;
                }

                if (processed.Contains(r.ID.ToString()))
                {
                    continue;
                }
                else
                {
                    processed.Add(r.ID.ToString());
                    var method = Build(business, project, r);
                    method.BeginCurrent();
                    // method.Calculate();
                    method.Begin(null);
                }
            }
        }

        public static void Calculate(_Business business, _UnitProject project, params DataRow[] rows)
        {
            var entities = _Entity_SubInfo.ParseMore(rows);
            Calculate(business, project, entities.ToArray());
        }

        public static void ResetSerializeNumber(_UnitProject project)
        {
            DataRow[] rs1 = project.StructSource.ModelSubSegments.Select("(XH is null  or XH=0) and LB='清单'");
            if (rs1.Length > 0)//条件成立则需要重排
            {
                DataRow[] rows = project.StructSource.ModelSubSegments.Select("LB='清单'", "sort asc");
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i]["XH"] = i + 1;
                }
            }
        }

    }
}
