using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Text.RegularExpressions;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Methods
    {

        private _SubSegments m_Parent = null;

        public _SubSegments Parent
        {
            get
            {
                return this.m_Parent;
            }
        }
        public _Methods(_SubSegments p_Parent)
        {
            this.m_Parent = p_Parent;
        }

      
        /// <summary>
        /// 通过定额库给定额赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        public void SetSubheadingsInfo(_ObjectInfo info,DataRow dr,string Libname)
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
        /// 从指引内容表获取定额编号
        /// </summary>
        /// <param name="QDBh"></param>
        /// <param name="ZYNRdt"></param>
        /// <returns></returns>
        public  string GetDEBHByQD(string QDBh, DataTable ZYNRdt)
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

        public void SetSubheadingsInfoByTZ(_ObjectInfo info, DataRow dr, string Libname)
        {
            info.XMBM = dr[CEntity清单特征定额表.FILED_TZDEH].ToString();
            info.XMMC = dr[CEntity清单特征定额表.FILED_DEMC].ToString();
            info.OLDXMBM = dr[CEntity清单特征定额表.FILED_TZDEH].ToString();
            //info.TX = dr[CEntity清单特征定额表.FILED_TX1].ToString();
            info.DW = dr[CEntity清单特征定额表.FILED_DEDW].ToString();
            info.LB = "子目";
            info.XMTZ = "";
            info.GCLJSS = "";
            info.HL = 1.00m;
            info.GCL = 1;
            info.LibraryName = Libname;
            info.DECJ = dr[CEntity清单特征定额表.FILED_DECJ].ToString();
           
        }

        /// <summary>
        /// 通过图集库给子目赋值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dr"></param>
        /// <param name="Libname"></param>
        public void SetSubheadingsInfoByTJ(_Entity_SubInfo info, DataRow dr, string Libname)
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
            if (dw=="")
            {
                dw = "1";
            }
            decimal xs = ToolKit.ParseDecimal(dr["GCXS"]);
            if (xs<=0)
            {
                xs = 1m;
            }

            decimal  c=ToolKit.ParseDecimal(dw) * xs;
            if (c==0)
	        {
		         c=1m;
	        }
            info.GCL = 1 / c;
            info.LibraryName = Libname;
            _Library.GetLibrary(Libname);
            DataTable dt = (_Library.Libraries[Libname] as DataSet).Tables["定额表"];
            if (dt!=null)
            {
                DataRow[] rows = dt.Select(string.Format("DINGEH='{0}'",info.XMBM));
                if (rows.Length>0)
                {
                    info.DECJ = rows[0]["DECJ"].ToString();
                    string oldvalue=dr["HSQ"].ToString();
                    string  newvalue=dr["HSH"].ToString();
                    if (oldvalue.Length>0)
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
        /// 判断当前子目编号是否在一个范围之内
        /// </summary>
        /// <param name="p_DEBH">定额范围比如（16,B4,B16,15,14-1～14-10,15-1～15-22,b1～b500）</param>
        /// <returns></returns>
        public static bool ExistsBH(string p_DEBH ,_ObjectInfo info)
        {
            bool flag = false;
            int m = 0;
            if (info.XMBM.IndexOf("-")>0)
            {
                m = info.XMBM.IndexOf("-");
            }
            string DEH = info.XMBM.Substring(0,m);
            string[] DEBHArry = p_DEBH.Split(',');
            if (p_DEBH.Contains("-") && p_DEBH.Substring(p_DEBH.IndexOf("-")).Contains(DEH))//含有-并且定额号有可能存在的时候的处理
            {
                string[] ItemArr = p_DEBH.Substring(p_DEBH.IndexOf("-")).Split(',')[0].Split('～');
                int MinNum = Convert.ToInt32(ItemArr[0].Substring(ItemArr[0].IndexOf('-') + 1));
                int MaxNum = Convert.ToInt32(ItemArr[1].Substring(ItemArr[1].IndexOf('-') + 1));
                for (int i = MinNum; i <= MaxNum; i++)
                {
                    if (info.XMBM == ItemArr[1].Substring(0, ItemArr[1].IndexOf('-') + 1) + i.ToString())
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
                            if (ItemArr[0].Contains("b"))
                            {
                                int MinNum = Convert.ToInt32(ItemArr[0].Substring(ItemArr[0].IndexOf('b') + 1));
                                int MaxNum = Convert.ToInt32(ItemArr[1].Substring(ItemArr[1].IndexOf('b') + 1));
                                for (int i = MinNum; i <= MaxNum; i++)
                                {
                                    if (DEH == "b" + i.ToString())
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
        /// 根据清单获取专业
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public _ProfessionalInfo GetproByFixed(_FixedListInfo info)
        {
            _ProfessionalInfo pro = null;
            if (info.ZJWZ=="")
            {
                info.ZJWZ = "999999";
            }
            string zjwj = info.ZJWZ.Substring(0, 2);
            IEnumerable<_ObjectInfo> infos = from item in this.Parent.ObjectsList.Cast<_ObjectInfo>()
                                             where item.XMBM == zjwj
                                             select item;
            if (infos.Count() > 0)
            {
                pro = infos.First<_ObjectInfo>() as _ProfessionalInfo;

            }
            if (pro != null)
            {
                return pro;
            }
            else
            {
                _ProfessionalInfo pinfo = new _ProfessionalInfo(this.Parent);
                DataRow row = GetQDSY(info.LibraryName, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.LB = "分部-专业";
                    pinfo.GCL = 0.0m;
                   // pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                else
                {
                    pinfo.XMBM = "99";
                    pinfo.XMMC = "补充专业";
                    pinfo.LB = "分部-专业";
                    pinfo.GCL = 0.0m;
                   // pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                this.Parent.Create(pinfo);
                return pinfo;
            }
        }
        /// <summary>
        /// 获取章
        /// </summary>
        /// <param name="info"></param>
        /// <param name="p_pro"></param>
        /// <returns></returns>
        public _ChapterInfo GetproByFixed(_FixedListInfo info,_ProfessionalInfo p_pro)
        {
            _ChapterInfo pro = null;
            string zjwj = info.ZJWZ.Substring(0, 4);
            IEnumerable<_ObjectInfo> infos = from item in this.Parent.ObjectsList.Cast<_ObjectInfo>()
                                             where item.XMBM == zjwj
                                             select item;
            if (infos.Count() > 0)
            {
                pro = infos.First<_ObjectInfo>() as _ChapterInfo;

            }
            if (pro != null)
            {
                return pro;
            }
            else
            {
                _ChapterInfo pinfo = new _ChapterInfo(p_pro);
                DataRow row = GetQDSY(info.LibraryName, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.LB = "分部-章";
                    pinfo.GCL = 0.0m;
                    //pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                else
                {
                    pinfo.XMBM = "9999";
                    pinfo.XMMC = "补充章";
                    pinfo.LB = "分部-章";
                    pinfo.GCL = 0.0m;
                   // pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                p_pro.Create(pinfo);
                return pinfo;
            }
        }
        /// <summary>
        /// 获取节
        /// </summary>
        /// <param name="info"></param>
        /// <param name="p_pro"></param>
        /// <returns></returns>
        public _FestivalInfo GetproByFixed(_FixedListInfo info, _ChapterInfo p_pro)
        {
            _FestivalInfo pro = null;
            string zjwj = info.ZJWZ.Substring(0, 6);
            IEnumerable<_ObjectInfo> infos = from item in this.Parent.ObjectsList.Cast<_ObjectInfo>()
                                             where item.XMBM == zjwj
                                             select item;
            if (infos.Count() > 0)
            {
                pro = infos.First<_ObjectInfo>() as _FestivalInfo;

            }
            if (pro != null)
            {
                return pro;
            }
            else
            {
                _FestivalInfo pinfo = new _FestivalInfo(p_pro);
                DataRow row = GetQDSY(info.LibraryName, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.LB = "分部-节";
                    pinfo.GCL = 0.0m;
                    //pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                else
                {
                    pinfo.XMBM = "999999";
                    pinfo.XMMC = "补充节";
                    pinfo.LB = "分部-节";
                    pinfo.GCL = 0.0m;
                    //pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                p_pro.Create(pinfo);
                return pinfo;
            }
        }

        private DataRow GetQDSY(string LibraryName, string QDSY)
        {
            _Library.GetLibrary(LibraryName);
            DataSet ds = _Library.Libraries[LibraryName] as DataSet;
            DataTable dt = ds.Tables["清单索引表"];
            DataRow[] rows = dt.Select(string.Format("QINGDSYBH='{0}'", QDSY));
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else
            {
                return null;
            }

        }
    }
}
