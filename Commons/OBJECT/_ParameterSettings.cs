using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ParameterSettings
    {
        public _ParameterSettings(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
            this.m_YSSubheadingsFeeList = new _YSSubheadingsFeeList(this);
            this.m_YSUnitFeeList = new _UnitFeeList(this);
            this.m_UnitFeeList = new _UnitFeeList(this);
        }

        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
        public _UnitProject Parent
        {
            get { return this.m_Parent; }
        }

        /// <summary>
        /// 是否加载过子目取费集合对象
        /// </summary>
        private bool ifSubheadingsFeeLoad = false;

        /// <summary>
        /// 子目取费集合对象
        /// </summary>
        private _YSSubheadingsFeeList m_YSSubheadingsFeeList = null;

        /// <summary>
        /// 工程取费集合对象
        /// </summary>
        private _UnitFeeList m_YSUnitFeeList = null;

        /// <summary>
        /// 获取或设置：工程取费集合对象
        /// </summary>
        public _UnitFeeList YSUnitFeeList
        {
            get { return m_YSUnitFeeList; }
            set { m_YSUnitFeeList = value; }
        }

        /// <summary>
        /// 工程取费集合对象
        /// </summary>
        private _UnitFeeList m_UnitFeeList = null;

        /// <summary>
        /// 获取或设置：工程取费集合对象
        /// </summary>
        public _UnitFeeList UnitFeeList
        {
            get { return m_UnitFeeList; }
            set { m_UnitFeeList = value; }
        }

        /// <summary>
        /// 获取或设置：子目取费集合对象
        /// </summary>
        public _YSSubheadingsFeeList YSSubheadingsFeeList
        {
            get { return m_YSSubheadingsFeeList; }
            set { m_YSSubheadingsFeeList = value; }
        }

        /// <summary>
        /// 创建：子目取费、工程取费
        /// </summary>
        public void Create()
        {
            if (!ifSubheadingsFeeLoad)
            {
                Create_YSSubheadingsFee();
                Create_UnitFee();
                LoadUnitFeeList();
                ifSubheadingsFeeLoad = true;
            }
        }

        /// <summary>
        /// 创建：子目取费
        /// </summary>
        private void Create_YSSubheadingsFee()
        {
            DataTable dt = this.Parent.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["子目取费表"];
            foreach (DataRow dr in dt.Rows)
            {
                _YSSubheadingsFeeInfo info = new _YSSubheadingsFeeInfo(this);
                info.ID = GetID(dr["YYH"].ToString().ToUpper());
                info.YYH = dr["YYH"].ToString().ToUpper();
                info.MC = dr["MC"].ToString();
                info.BDS = dr["BDS"].ToString().ToUpper();
                info.TBJSJC = dr["TBJSJC"].ToString().ToUpper();
                info.BDJSJC = dr["BDJSJC"].ToString().ToUpper();
                if (dr["FL"].ToString() == string.Empty)
                {
                    dr["FL"] = 0;
                }
                info.FL = Convert.ToDecimal(dr["FL"]);
                info.FYLB = dr["FYLB"].ToString();
                info.BZ = dr["BEIZHU"].ToString();
                this.m_YSSubheadingsFeeList.Add(info);
            }
        }

        /// <summary>
        /// 创建：工程取费
        /// </summary>
        private void Create_UnitFee()
        {
            DataTable dt = this.Parent.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["取费表"];
            foreach (DataRow dr in dt.Rows)
            {
                _UnitFeeInfo info = new _UnitFeeInfo(this);
                info.GCLB = dr["GONGCLB"].ToString();
                info.DEHFW = dr["DINGEH"].ToString();
                info.GLFFL = Convert.ToDecimal(dr["GUANLFL"]);
                info.LRFL = Convert.ToDecimal(dr["LIRL"]);
                //info.FXTBFL = Convert.ToDecimal(dr["FXLTB"]);
                info.FXBDFL = Convert.ToDecimal(dr["FXLBD"]);
                info.GLFTBJSJC = dr["GLTBJC"].ToString().ToUpper();
                info.GLFBDJSJC = dr["GLBDJC"].ToString().ToUpper();
                info.LRFTBJSJC = dr["LRTBJC"].ToString().ToUpper();
                info.LRFBDJSJC = dr["LRBDJC"].ToString().ToUpper();
                info.FXFTBJSJC = dr["FXTBJC"].ToString().ToUpper();
                info.FXFBDJSJC = dr["FXBDJC"].ToString().ToUpper();
                info.IFSFHZ = dr["SFHH"].ToString() == "是" ? true : false;
                this.m_YSUnitFeeList.Add(info);
            }
        }

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="YYH"></param>
        /// <returns></returns>
        private int GetID(string YYH)
        {
            int id = -1;
            string[] yyhs = { "F1", "F2", "F3", "F4", "F5", "F6", "一", "二", "三", "四", "五" };
            int[] ids = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            for (int i = 0; i < yyhs.Length; i++)
            {
                if (yyhs[i] == YYH)
                {
                    id = ids[i];
                    break;
                }
            }
            return id;
        }

        /// <summary>
        /// 加载工程取费
        /// </summary>
        /// <param name="PrfType">专业类别</param>
        public void LoadUnitFeeList()
        {
            this.m_UnitFeeList.Clear();
            IEnumerable<_UnitFeeInfo> list = from info in this.m_YSUnitFeeList.Cast<_UnitFeeInfo>()
                                             where info.GCLB == this.Parent.Property.BaseData.PrfType
                                             select info;

            if (list.Count() == 0)
            {
                this.m_UnitFeeList.AddRange(this.m_YSUnitFeeList.ToArray());
            }
            else
            {
                foreach (_UnitFeeInfo item in list)
                {
                    if (item.IFSFHZ)
                    {
                        this.m_UnitFeeList.AddRange(this.m_YSUnitFeeList.ToArray());
                    }
                    else
                    {
                        this.m_UnitFeeList.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// 获取：工程取费
        /// </summary>
        public _UnitFeeInfo GetUnitFeeInfo(string value)
        {
            _UnitFeeInfo m_UnitFeeInfo = null;
            if (this.m_UnitFeeList.Count == 1)
            {
                m_UnitFeeInfo = this.m_UnitFeeList[0] as _UnitFeeInfo;
            }
            else
            {
                if (IFCZK(value))
                {
                    m_UnitFeeInfo = Verification(value);
                }
                else 
                {
                    m_UnitFeeInfo = this.m_UnitFeeList[0] as _UnitFeeInfo;
                }
            }
            return m_UnitFeeInfo;
        }

        /// <summary>
        /// 验证定额号是否存在指定范围内（1,2,3）
        /// </summary>
        /// <param name="value">定额号</param>
        /// <returns>存在返回工程取费否则null</returns>
        private _UnitFeeInfo Verification(string value)
        {
            value = value.ToUpper();
            //比对 (～)
            foreach (_UnitFeeInfo info in this.m_UnitFeeList)
            {
                string[] dehfws = info.DEHFW.Split(',').Cast<string>().Where(p => p.Contains("～")).ToArray();
                foreach (string item in dehfws)
                {
                    string[] bm = item.Split('～');
                    if (bm[0].Substring(0, (bm[0].LastIndexOf("-") + 1)).ToUpper() == value.Substring(0, (value.LastIndexOf("-") + 1)))
                    {
                        int MinNum = Convert.ToInt32(bm[0].Substring(bm[0].LastIndexOf("-") + 1, (bm[0].Length - bm[0].LastIndexOf("-") - 1)));
                        int MaxNum = Convert.ToInt32(bm[1].Substring(bm[1].LastIndexOf("-") + 1, (bm[1].Length - bm[1].LastIndexOf("-") - 1)));
                        int bjNum = Convert.ToInt32(value.Substring(value.LastIndexOf("-") + 1, value.Length - value.LastIndexOf("-") - 1));
                        if (bjNum >= MinNum && bjNum <= MaxNum)
                        {
                            return info;
                        }
                    }
                }
            }
            //比对 (-)
            foreach (_UnitFeeInfo info in this.m_UnitFeeList)
            {
                string[] dehfws = info.DEHFW.Split(',').Cast<string>().Where(p => !p.Contains("～") && p.Contains("-")).ToArray();
                foreach (string item in dehfws)
                {
                    if (value.Contains("-"))
                    {
                        if (item.ToUpper() == value.Substring(0, (value.LastIndexOf("-"))))
                        {
                            return info;
                        }
                    }
                    else
                    {
                        if (item.ToUpper() == value)
                        {
                            return info;
                        }
                    }
                }
            }
            //比对 ()
            foreach (_UnitFeeInfo info in this.m_UnitFeeList)
            {
                string[] dehfws = info.DEHFW.Split(',').Cast<string>().Where(p => !p.Contains("～") && !p.Contains("-")).ToArray();
                foreach (string item in dehfws)
                {
                    if (value.Contains("-"))
                    {
                        if (item.ToUpper() == value.Substring(0, (value.LastIndexOf("-"))))
                        {
                            return info;
                        }
                    }
                    else
                    {
                        if (item.ToUpper() == value)
                        {
                            return info;
                        }
                    }
                }
            }
            return this.m_UnitFeeList[0] as _UnitFeeInfo;
        }

        /// <summary>
        /// 验证当前打开库中是否存在定额号
        /// </summary>
        /// <param name="value">定额号</param>
        /// <returns>是否存在</returns>
        private bool IFCZK(string value)
        {
            DataTable dt = this.Parent.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"];
            DataRow[] drs = dt.Select(string.Format("DINGEH = '{0}'", value));
            return drs.Length == 1 ? true : false;
        }
       

    }
}
