/*
 * 通用数据源函数
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Text.RegularExpressions;
using DevExpress.XtraTreeList.Columns;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class CommonData
    {
        /// <summary>
        /// 获取当前历史对象表格集合
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetHistory(string str)
        {
            DataTable table = new DataTable(str);
            DataColumn dc = table.Columns.Add("Key", typeof(int));//唯一表示
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("FileName", typeof(string));
            table.Columns.Add("IsUse", typeof(bool)).DefaultValue = true;
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;
            //ID列设置为主键
            table.PrimaryKey = new DataColumn[] { dc };
            return table;
        }


        /// <summary>
        /// 返回ImageList控件使用的数据源结构
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetImageList(string str)
        {
            DataTable table = new DataTable(str);
            table.Columns.Add("ImageMember", typeof(int));
            table.Columns.Add("ValueMember", typeof(string));
            table.Columns.Add("Remark", typeof(string));
            return table;
        }

        /// <summary>
        /// 创建项目清单数据列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetDirectoryList(string str)
        {
            DataTable table = new DataTable(str);
            DataColumn dc = table.Columns.Add("Key", typeof(int));//唯一表示
            table.Columns.Add("KeyFieldName", typeof(int));
            table.Columns.Add("ParentFieldName", typeof(int));
            table.Columns.Add("NodeName", typeof(string));
            table.Columns.Add("ImageIndex", typeof(int));
            table.Columns.Add("Path", typeof(string));
            table.Columns.Add("TypeName", typeof(string));
            table.Columns.Add("Sort", typeof(int)).DefaultValue = 0;
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;
            //ID列设置为主键
            table.PrimaryKey = new DataColumn[] { dc };
            return table;
        }

        /// <summary>
        /// 创建空的属性清单数据列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetAttributeList(string str)
        {
            DataTable table = new DataTable(str);
            DataColumn dc = table.Columns.Add("Key", typeof(int));//唯一表示            
            table.Columns.Add("ParentFieldName", typeof(int));
            table.Columns.Add("AttName", typeof(string));//属性名称
            table.Columns.Add("AttValue", typeof(string));//属性名称
            table.Columns.Add("ImageIndex", typeof(string));
            table.Columns.Add("Remark", typeof(string));//属性说明
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;
            return table;
        }


        /// <summary>
        /// 从DataRow获取分部分项的清单实例
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="QDpath"></param>
        /// <param name="DEpath"></param>
        /// <returns></returns>
        //public static CEntitySubSegment GetCEntitySubSegmentByRow(DataRow dr, int id, string Libname)
        //{
        //    CEntitySubSegment m_CEntitySubSegment = new CEntitySubSegment();
        //    m_CEntitySubSegment.ID = id;
        //    m_CEntitySubSegment.PARENID = -1;
        //    m_CEntitySubSegment.XMBM = dr[CEntity清单表.FILED_QINGDBH].ToString();
        //    m_CEntitySubSegment.XMMC = dr[CEntity清单表.FILED_QINGDMC].ToString();
        //    m_CEntitySubSegment.DW = dr[CEntity清单表.FILED_QINGDDW].ToString();
        //    m_CEntitySubSegment.TX = dr[CEntity清单表.FILED_TX1].ToString();
        //    m_CEntitySubSegment.LB = "清单";
        //    // m_CEntitySubSegment.JCBJ = "";
        //    //m_CEntitySubSegment.FHBJ = "";
        //    //m_CEntitySubSegment.ZYQD = ;
        //    m_CEntitySubSegment.XMTZ = "";
        //    //m_CEntitySubSegment.SDDJ =;
        //    m_CEntitySubSegment.GCLJSS = "";
        //    m_CEntitySubSegment.HL = 0.00M;
        //    m_CEntitySubSegment.ZJWZ = dr[CEntity清单表.FILED_QINGDSYBH].ToString();
        //    m_CEntitySubSegment.LibraryName = Libname;
        //    // m_CEntitySubSegment.Tag = new _CRowTagObject(ESubSegmentType.清单);

        //    //  m_CEntitySubSegment.Tag = new _CRowTagObject(ESubSegmentType.清单);
        //    /*  m_CEntitySubSegment.GCL = ;
        //      m_CEntitySubSegment.ZJTJ = ;
        //      m_CEntitySubSegment.ZHDJ = ;
        //      m_CEntitySubSegment.ZHHJ = ;
        //      m_CEntitySubSegment.ZJFDJ = ;
        //      m_CEntitySubSegment.RGFDJ = ;
        //      m_CEntitySubSegment.CLFDJ = ;
        //      m_CEntitySubSegment.JXFDJ = ;
        //      m_CEntitySubSegment.ZCFDJ = ;
        //      m_CEntitySubSegment.SBFDJ = ;
        //      m_CEntitySubSegment.GLFDJ = ;
        //      m_CEntitySubSegment.LRDJ = ;
        //      m_CEntitySubSegment.FXDJ = ;
        //      m_CEntitySubSegment.GFDJ = ;
        //      m_CEntitySubSegment.SJDJ = ;
        //      m_CEntitySubSegment.ZJFHJ =;
        //      m_CEntitySubSegment.RGFHJ =;
        //      m_CEntitySubSegment.CLFHJ =;
        //      m_CEntitySubSegment.JXFHJ =;
        //      m_CEntitySubSegment.ZCFHJ =;
        //      m_CEntitySubSegment.SBFHJ =;
        //      m_CEntitySubSegment.GLFHJ =;
        //      m_CEntitySubSegment.LRHJ = ;
        //      m_CEntitySubSegment.FXHJ = ;
        //      m_CEntitySubSegment.GFHJ = ;
        //      m_CEntitySubSegment.SJHJ = ;
        //      m_CEntitySubSegment.JCHJ = ;
        //      m_CEntitySubSegment.CJHJ = ;
        //      m_CEntitySubSegment.ZGJE = ;
        //      m_CEntitySubSegment.JGJE = ;
        //      m_CEntitySubSegment.SFFB = ;
        //      m_CEntitySubSegment.FBJE = ;
        //      m_CEntitySubSegment.JBHZ = ;
              
        //      m_CEntitySubSegment.JX = ;
        //      m_CEntitySubSegment.YGLB = ;
        //      m_CEntitySubSegment.SC = ;
        //      m_CEntitySubSegment.QFSZ = ;*/
        //    /*m_CEntitySubSegment.QDPath = QDpath;
        //    m_CEntitySubSegment.DEPath = DEpath;*/

        //    return m_CEntitySubSegment;

        //}

        /// <summary>
        /// 从指引内容表获取定额编号
        /// </summary>
        /// <param name="QDBh"></param>
        /// <param name="ZYNRdt"></param>
        /// <returns></returns>
        public static string GetDEBHByQD(string QDBh, DataTable ZYNRdt)
        {
            string Str = "";
            string ReturnStr = "";
            DataRow[] dr = ZYNRdt.Select(string.Format(" QINGDBH='{0}'", QDBh));
            for (int i = 0; i < dr.Length; i++)
            {

                Str += dr[i]["ZHIYDE"].ToString();
                //取出的数据类似1-1,0,|1-2,0,|1-3,0,|1-4,0,|，需进一步转换
            }

            Regex r = new Regex(@"(\d{1,})-(\d{1,})"); // 定义一个Regex对象实例
            MatchCollection mc = r.Matches(Str);
            for (int i = 0; i < mc.Count; i++)
            {
                if (!string.IsNullOrEmpty(mc[i].Value))
                {
                    ReturnStr += "'" + mc[i].Value + "',";
                }
            }
            if (ReturnStr.Length > 0)
            {
                ReturnStr = ReturnStr.Substring(0, ReturnStr.Length - 1);
            }
            return ReturnStr;
        }

        /// <summary>
        /// 根据清单特征获取子目
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="PID"></param>
        /// <param name="QDpath"></param>
        /// <param name="DEpath"></param>
        /// <returns></returns>
        //public static CEntitySubSegment GetCEntitySubSegmentByTZRow(DataRow dr, int id, int PID, string Libname)
        //{

        //    CEntitySubSegment m_CEntitySubSegment = new CEntitySubSegment();
        //    m_CEntitySubSegment.ID = id;
        //    m_CEntitySubSegment.PARENID = PID;
        //    m_CEntitySubSegment.XMBM = dr[CEntity清单特征定额表.FILED_TZDEH].ToString();
        //    m_CEntitySubSegment.XMMC = dr[CEntity清单特征定额表.FILED_DEMC].ToString();
        //    m_CEntitySubSegment.TX = "";
        //    m_CEntitySubSegment.DW = dr[CEntity清单特征定额表.FILED_DEDW].ToString();
        //    m_CEntitySubSegment.LB = "子目";
        //    //m_CEntitySubSegment.JCBJ = "";
        //    // m_CEntitySubSegment.FHBJ = "";
        //    //m_CEntitySubSegment.ZYQD = ;
        //    m_CEntitySubSegment.XMTZ = "";
        //    //m_CEntitySubSegment.SDDJ =;
        //    m_CEntitySubSegment.GCLJSS = "";
        //    m_CEntitySubSegment.HL = 1.00M;
        //    m_CEntitySubSegment.GCL = 1;
        //    m_CEntitySubSegment.ZJTJ = "";
        //    m_CEntitySubSegment.ZHDJ = 0;
        //    m_CEntitySubSegment.RGFDJ = 0;
        //    m_CEntitySubSegment.CLFDJ = 0;
        //    m_CEntitySubSegment.JXFDJ = 0;
        //    m_CEntitySubSegment.LibraryName = Libname;
        //    m_CEntitySubSegment.DECJ = dr[CEntity清单特征定额表.FILED_DECJ].ToString();
        //    /*  m_CEntitySubSegment.ZHHJ = ;
        //     m_CEntitySubSegment.ZJFDJ = ;
        //     m_CEntitySubSegment.ZCFDJ = ;
        //     m_CEntitySubSegment.SBFDJ = ;
        //     m_CEntitySubSegment.GLFDJ = ;
        //     m_CEntitySubSegment.LRDJ = ;
        //     m_CEntitySubSegment.FXDJ = ;
        //     m_CEntitySubSegment.GFDJ = ;
        //     m_CEntitySubSegment.SJDJ = ;
        //     m_CEntitySubSegment.ZJFHJ =;
        //     m_CEntitySubSegment.RGFHJ =;
        //     m_CEntitySubSegment.CLFHJ =;
        //     m_CEntitySubSegment.JXFHJ =;
        //     m_CEntitySubSegment.ZCFHJ =;
        //     m_CEntitySubSegment.SBFHJ =;
        //     m_CEntitySubSegment.GLFHJ =;
        //     m_CEntitySubSegment.LRHJ = ;
        //     m_CEntitySubSegment.FXHJ = ;
        //     m_CEntitySubSegment.GFHJ = ;
        //     m_CEntitySubSegment.SJHJ = ;
        //     m_CEntitySubSegment.JCHJ = ;
        //     m_CEntitySubSegment.CJHJ = ;
        //     m_CEntitySubSegment.ZGJE = ;
        //     m_CEntitySubSegment.JGJE = ;
        //     m_CEntitySubSegment.SFFB = ;
        //     m_CEntitySubSegment.FBJE = ;
        //     m_CEntitySubSegment.JBHZ = ;
        //     m_CEntitySubSegment.ZJWZ = ;
        //     m_CEntitySubSegment.JX = ;
        //     m_CEntitySubSegment.YGLB = ;
        //     m_CEntitySubSegment.SC = ;
        //     m_CEntitySubSegment.QFSZ = ;*/
        //    //  m_CEntitySubSegment.Tag = new _CRowTagObject(ESubSegmentType.子目,m_CEntitySubSegment);

        //    return m_CEntitySubSegment;
        //}


        /// <summary>
        ///  从DataRow获取分部分项的子目实例
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="PID"></param>
        /// <param name="QDpath"></param>
        /// <param name="DEpath"></param>
        /// <returns></returns>
        //public static CEntitySubSegment GetCEntitySubSegmentByRow(DataRow dr, int id, int PID, string Libname)
        //{

        //    CEntitySubSegment m_CEntitySubSegment = new CEntitySubSegment();
        //    m_CEntitySubSegment.ID = id;
        //    m_CEntitySubSegment.PARENID = PID;
        //    m_CEntitySubSegment.XMBM = dr[CEntity定额表.FILED_DINGEH].ToString();
        //    m_CEntitySubSegment.XMMC = dr[CEntity定额表.FILED_DINGEMC].ToString();
        //    m_CEntitySubSegment.TX = dr[CEntity定额表.FILED_TX1].ToString();
        //    m_CEntitySubSegment.DW = dr[CEntity定额表.FILED_DINGEDW].ToString();
        //    m_CEntitySubSegment.LB = "子目";
        //    // m_CEntitySubSegment.JCBJ = "";
        //    //m_CEntitySubSegment.FHBJ = "";
        //    //m_CEntitySubSegment.ZYQD = ;
        //    m_CEntitySubSegment.XMTZ = "";
        //    //m_CEntitySubSegment.SDDJ =;
        //    m_CEntitySubSegment.GCLJSS = "";
        //    m_CEntitySubSegment.HL = 1.00M;
        //    m_CEntitySubSegment.GCL = 1;
        //    m_CEntitySubSegment.ZJTJ = "";
        //    m_CEntitySubSegment.ZHDJ = Convert.ToDecimal(dr[CEntity定额表.FILED_DINGEJJ].ToString());
        //    m_CEntitySubSegment.RGFDJ = Convert.ToDecimal(dr[CEntity定额表.FILED_RENGF].ToString());
        //    m_CEntitySubSegment.CLFDJ = Convert.ToDecimal(dr[CEntity定额表.FILED_CAILF].ToString());
        //    m_CEntitySubSegment.JXFDJ = Convert.ToDecimal(dr[CEntity定额表.FILED_JIXF].ToString());
        //    m_CEntitySubSegment.LibraryName = Libname;
        //    m_CEntitySubSegment.DECJ = dr[CEntity定额表.FILED_DECJ].ToString();
        //    /*  m_CEntitySubSegment.ZHHJ = ;
        //     m_CEntitySubSegment.ZJFDJ = ;
        //     m_CEntitySubSegment.ZCFDJ = ;
        //     m_CEntitySubSegment.SBFDJ = ;
        //     m_CEntitySubSegment.GLFDJ = ;
        //     m_CEntitySubSegment.LRDJ = ;
        //     m_CEntitySubSegment.FXDJ = ;
        //     m_CEntitySubSegment.GFDJ = ;
        //     m_CEntitySubSegment.SJDJ = ;
        //     m_CEntitySubSegment.ZJFHJ =;
        //     m_CEntitySubSegment.RGFHJ =;
        //     m_CEntitySubSegment.CLFHJ =;
        //     m_CEntitySubSegment.JXFHJ =;
        //     m_CEntitySubSegment.ZCFHJ =;
        //     m_CEntitySubSegment.SBFHJ =;
        //     m_CEntitySubSegment.GLFHJ =;
        //     m_CEntitySubSegment.LRHJ = ;
        //     m_CEntitySubSegment.FXHJ = ;
        //     m_CEntitySubSegment.GFHJ = ;
        //     m_CEntitySubSegment.SJHJ = ;
        //     m_CEntitySubSegment.JCHJ = ;
        //     m_CEntitySubSegment.CJHJ = ;
        //     m_CEntitySubSegment.ZGJE = ;
        //     m_CEntitySubSegment.JGJE = ;
        //     m_CEntitySubSegment.SFFB = ;
        //     m_CEntitySubSegment.FBJE = ;
        //     m_CEntitySubSegment.JBHZ = ;
        //     m_CEntitySubSegment.ZJWZ = ;
        //     m_CEntitySubSegment.JX = ;
        //     m_CEntitySubSegment.YGLB = ;
        //     m_CEntitySubSegment.SC = ;
        //     m_CEntitySubSegment.QFSZ = ;*/
        //    //m_CEntitySubSegment.BEIZHU = "";
        //    // m_CEntitySubSegment.Tag = new _CRowTagObject(ESubSegmentType.子目);
        //    return m_CEntitySubSegment;

        //}


        /// <summary>
        /// 设置列的默认编辑状态
        /// </summary>
        /// <param name="col"></param>
        public static void OptionsCol(TreeListColumn col)
        {
            switch (col.FieldName)
            {
                case _ObjectInfo.FILED_XMMC:
                    break;
                case _ObjectInfo.FILED_XMTZ:
                    break;
                case _ObjectInfo.FILED_BEIZHU:
                    break;
                case _ObjectInfo.FILED_HL:
                    break;
                case _ObjectInfo.FILED_GCL:
                    break;
                case _ObjectInfo.FILED_ZJTJ:
                    break;
                case _ObjectInfo.FILED_GCLJSS:
                    break;
                case _ObjectInfo.FILED_JCBJ:
                    break;
                case _ObjectInfo.FILED_FHBJ:
                    break;
                case _ObjectInfo.FILED_ZYQD:
                    break;
                case _ObjectInfo.FILED_SDDJ:
                    break;
                case _ObjectInfo.FILED_SFFB:
                    break;

                case _ObjectInfo.FILED_JBHZ:
                    break;
                case _ObjectInfo.FILED_JX:
                    break;
                case _ObjectInfo.FILED_SC:
                    break;
                case _ObjectInfo.FILED_XMBM:
                    break;
                default:
                    col.OptionsColumn.AllowEdit = false;
                    break;
            }
        }

        /// <summary>
        /// 根据计算表达式得到计算结果
        /// </summary>
        /// <param name="CalculationInfo">计算式（比如：1*5+（2-1））</param>
        /// <returns></returns>
        public static int Calculation(string CalculationInfo)
        {
            try
            {
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControlClass();
                sc.Language = "JavaScript";
                string str = sc.Eval(CalculationInfo).ToString();//1+12+3
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 重载获取清单实例
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="Libname"></param>
        /// <param name="p_Table"></param>
        /// <returns></returns>
        //public static CEntitySubSegment GetCEntitySubSegmentByRow(DataRow dr, int id, string Libname, DataTable p_Table)
        //{
        //    CEntitySubSegment info = CommonData.GetCEntitySubSegmentByRow(dr, id, Libname);
        //    _CRowTagObject rto = new _CRowTagObject(ESubSegmentType.清单, info);
        //    //rto.Source = p_Table;
        //    info.Tag = rto;
        //    // rto.InventorySummary.Mdata = p_Table;
        //    return info;
        //}


        //public static CEntitySubSegment GetCEntitySubSegmentByTZRow(DataRow dr, int id, int PID, string Libname, DataTable p_Table)
        //{
        //    CEntitySubSegment info = CommonData.GetCEntitySubSegmentByTZRow(dr, id, PID, Libname);
        //    _CRowTagObject rto = new _CRowTagObject(ESubSegmentType.子目, info);
        //    //rto.Source = p_Table;
        //    info.Tag = rto;
        //    return info;
        //}

        /// <summary>
        /// 重载获取子目实例
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="PID"></param>
        /// <param name="Libname"></param>
        /// <param name="p_Table"></param>
        /// <returns></returns>
        //public static CEntitySubSegment GetCEntitySubSegmentByRow(DataRow dr, int id, int PID, string Libname, DataTable p_Table)
        //{
        //    CEntitySubSegment info = CommonData.GetCEntitySubSegmentByRow(dr, id, PID, Libname);
        //    _CRowTagObject rto = new _CRowTagObject(ESubSegmentType.子目, info);
        //    //rto.Source = p_Table;
        //    //要统计的子目编号
        //    //rto.Statistics.Key = info.ID;
        //    info.Tag = rto;

        //    return info;
        //}

        /// <summary>
        /// 初始化树深度
        /// </summary>
        /// <param name="table"></param>
        public static void InitTreeTable(DataTable table)
        {
            //添加深度.是否拥有子节点
            //深度从0开始计算
            if (!table.Columns.Contains("Depth"))
            {
                table.Columns.Add("Depth", typeof(int)).DefaultValue = 0;//深度
            }
            if (!table.Columns.Contains("HasChildren"))
            {
                table.Columns.Add("HasChildren", typeof(int)).DefaultValue = 0;//是否有孩子 0 有 1无
            }

            //初始化值
            foreach (DataRow row in table.Rows)
            {
                //深度
                string str = row["Number"].ToString();
                int dep = str.Split('.').Length;
                int hc = 0;
                //是否有孩子
                DataRow[] rows = table.Select(string.Format("ParentID = {0}", row["ID"]));
                if (rows.Length != 0)
                {
                    hc = 1;
                }

                row.BeginEdit();
                row["Depth"] = dep;
                row["HasChildren"] = hc;
                row.EndEdit();
            }

        }

        /// <summary>
        /// 获取分部分项树的列集合
        /// </summary>
        /// <returns></returns>
        public static TreeListColumn[] GetColumns_Segment()
        {
           TreeListColumn[] cols = new TreeListColumn[41];

            cols[0] = GetTreeCol("序号", CEntitySubSegment.FILED_XH, CEntitySubSegment.FILED_XH);
            cols[1] = GetTreeCol("项目编码", CEntitySubSegment.FILED_XMBM, CEntitySubSegment.FILED_XMBM);
            cols[2] = GetTreeCol("项目名称", CEntitySubSegment.FILED_XMMC, CEntitySubSegment.FILED_XMMC);
            cols[3] = GetTreeCol("单   位", CEntitySubSegment.FILED_DW, CEntitySubSegment.FILED_DW);
            cols[4] = GetTreeCol("特   项", CEntitySubSegment.FILED_TX, CEntitySubSegment.FILED_TX);
            cols[5] = GetTreeCol("类   别", CEntitySubSegment.FILED_LB, CEntitySubSegment.FILED_LB);
            cols[6] = GetTreeCol("检查标记", CEntitySubSegment.FILED_JCBJ, CEntitySubSegment.FILED_JCBJ,false);
            cols[7] = GetTreeCol("复核标记", CEntitySubSegment.FILED_FHBJ, CEntitySubSegment.FILED_FHBJ, false);
            cols[8] = GetTreeCol("主要清单", CEntitySubSegment.FILED_ZYQD, CEntitySubSegment.FILED_ZYQD, false);
            cols[9] = GetTreeCol("项目特征", CEntitySubSegment.FILED_XMTZ, CEntitySubSegment.FILED_XMTZ, false);
            cols[10] = GetTreeCol("锁定单价", CEntitySubSegment.FILED_SDDJ, CEntitySubSegment.FILED_SDDJ, false);
            cols[11] = GetTreeCol("工程量计算式", CEntitySubSegment.FILED_GCLJSS, CEntitySubSegment.FILED_GCLJSS, false);
            cols[12] = GetTreeCol("含   量", CEntitySubSegment.FILED_HL, CEntitySubSegment.FILED_HL, false);
            cols[13] = GetTreeCol("工程量", CEntitySubSegment.FILED_GCL, CEntitySubSegment.FILED_GCL);
            cols[14] = GetTreeCol("直接调价", CEntitySubSegment.FILED_ZJTJ, CEntitySubSegment.FILED_ZJTJ, "金额", false);
            cols[15] = GetTreeCol("综合单价", CEntitySubSegment.FILED_ZHDJ, CEntitySubSegment.FILED_ZHDJ, "金额", true);
            cols[16] = GetTreeCol("综合合价", CEntitySubSegment.FILED_ZHHJ, CEntitySubSegment.FILED_ZHHJ, "金额", true);
            cols[17] = GetTreeCol("直接费单价", CEntitySubSegment.FILED_ZJFDJ, CEntitySubSegment.FILED_ZJFDJ, "金额", false);
            cols[18] = GetTreeCol("人工费单价", CEntitySubSegment.FILED_RGFDJ, CEntitySubSegment.FILED_RGFDJ, "金额", false);
            cols[19] = GetTreeCol("材料费单价", CEntitySubSegment.FILED_CLFDJ, CEntitySubSegment.FILED_CLFDJ, "金额", false);
            cols[20] = GetTreeCol("机械费单价", CEntitySubSegment.FILED_JXFDJ, CEntitySubSegment.FILED_JXFDJ, "金额", false);
            cols[21] = GetTreeCol("主材费单价", CEntitySubSegment.FILED_ZCFDJ, CEntitySubSegment.FILED_ZCFDJ, "金额", false);
            cols[22] = GetTreeCol("设备费单价", CEntitySubSegment.FILED_SBFDJ, CEntitySubSegment.FILED_SBFDJ, "金额", false);
            cols[23] = GetTreeCol("管理费单价", CEntitySubSegment.FILED_GLFDJ, CEntitySubSegment.FILED_GLFDJ, "金额", false);
            cols[24] = GetTreeCol("利润单价", CEntitySubSegment.FILED_LRDJ, CEntitySubSegment.FILED_LRDJ, "金额", false);
            cols[25] = GetTreeCol("风险单价", CEntitySubSegment.FILED_FXDJ, CEntitySubSegment.FILED_FXDJ, "金额", false);
            cols[26] = GetTreeCol("直接费合价", CEntitySubSegment.FILED_ZJFHJ, CEntitySubSegment.FILED_ZJFHJ, "金额", false);
            cols[27] = GetTreeCol("人工费合价", CEntitySubSegment.FILED_RGFHJ, CEntitySubSegment.FILED_RGFHJ, "金额", false);
            cols[28] = GetTreeCol("材料费合价", CEntitySubSegment.FILED_CLFHJ, CEntitySubSegment.FILED_CLFHJ, "金额", false);
            cols[29] = GetTreeCol("机械费合价", CEntitySubSegment.FILED_JXFHJ, CEntitySubSegment.FILED_JXFHJ, "金额", false);
            cols[30] = GetTreeCol("主材费合价", CEntitySubSegment.FILED_ZCFHJ, CEntitySubSegment.FILED_ZCFHJ, "金额", false);
            cols[31] = GetTreeCol("设备费合价", CEntitySubSegment.FILED_SBFHJ, CEntitySubSegment.FILED_SBFHJ, "金额", false);
            cols[32] = GetTreeCol("管理费合价", CEntitySubSegment.FILED_GLFHJ, CEntitySubSegment.FILED_GLFHJ, "金额", false);
            cols[33] = GetTreeCol("利润合价", CEntitySubSegment.FILED_LRHJ, CEntitySubSegment.FILED_LRHJ, "金额", false);
            cols[34] = GetTreeCol("风险合价", CEntitySubSegment.FILED_FXHJ, CEntitySubSegment.FILED_FXHJ, "金额", false);
            cols[35] = GetTreeCol("价差合计", CEntitySubSegment.FILED_JCHJ, CEntitySubSegment.FILED_JCHJ, "金额", false);
            cols[36] = GetTreeCol("差价合计", CEntitySubSegment.FILED_CJHJ, CEntitySubSegment.FILED_CJHJ, "金额", false);
            cols[37] = GetTreeCol("暂估金额", CEntitySubSegment.FILED_ZGJE, CEntitySubSegment.FILED_ZGJE, "金额", false);
            cols[38] = GetTreeCol("甲供金额", CEntitySubSegment.FILED_JGJE, CEntitySubSegment.FILED_JGJE, "金额", false);
            cols[39] = GetTreeCol("是否分包", CEntitySubSegment.FILED_SFFB, CEntitySubSegment.FILED_SFFB,false);
            cols[40] = GetTreeCol("分包金额", CEntitySubSegment.FILED_FBJE, CEntitySubSegment.FILED_FBJE, "金额", false);
            //cols[41] = GetTreeCol("局部汇总", CEntitySubSegment.FILED_JBHZ, CEntitySubSegment.FILED_JBHZ);
            return cols;
        }

        /// <summary>
        /// 创建列
        /// </summary>
        /// <param name="Caption"></param>
        /// <param name="FieldName"></param>
        /// <param name="ColName"></param>
        /// <returns></returns>
        private static TreeListColumn GetTreeCol(string Caption, string FieldName, string ColName)
        {
            return GetTreeCol(Caption, FieldName, ColName, true);
        }

        private static TreeListColumn GetTreeCol(string Caption, string FieldName, string ColName,bool p_Visable)
        {

            TreeListColumn TreeColumn = new TreeListColumn();
            TreeColumn.Caption = Caption;
            TreeColumn.FieldName = FieldName.ToUpper();
            TreeColumn.Name = ColName;
            TreeColumn.VisibleIndex = 1;
            TreeColumn.Visible = p_Visable;
            
            //TreeColumn.Width = 100;
            TreeColumn.MinWidth = 100;
            return TreeColumn;
        }

        /// <summary>
        /// 创建列
        /// </summary>
        /// <param name="Caption"></param>
        /// <param name="FieldName"></param>
        /// <param name="ColName"></param>
        /// <returns></returns>
        private static TreeListColumn GetTreeCol(string Caption, string FieldName, string ColName, string type, bool p_Visable)
        {
            TreeListColumn TreeColumn = new TreeListColumn();
            TreeColumn.Caption = Caption;
            TreeColumn.FieldName = FieldName.ToUpper();
            TreeColumn.Name = ColName;
            TreeColumn.VisibleIndex = 1;
            TreeColumn.Visible = p_Visable;
           
            //TreeColumn.Width = 100;
            TreeColumn.MinWidth = 100;
            TreeColumn.Format.FormatString = "0.00";
            TreeColumn.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            return TreeColumn;

        }
    }
}
