using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_ParamsSeting
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

        public _Methods_ParamsSeting(_UnitProject p_Unit)
        {
            this.m_Unit = p_Unit;
        }

        /// <summary>
        /// 创建子目取费 工程取费
        /// </summary>
        public void Init()
        {
            this.Create_YSSubheadingsFee();
            this.Create_UnitFee();
        }


        /// <summary>
        /// 创建：子目取费
        /// </summary>
        private void Create_YSSubheadingsFee()
        {
            this.m_Unit.StructSource.ModelPSubheadingsFee.RemoveAll();
            //this.m_Unit.DataTemp.YSZMQFDataTemp.IsChange = true;
            DataTable dt = this.m_Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["子目取费表"];
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = this.m_Unit.StructSource.ModelPSubheadingsFee.NewRow();
                dr["EnID"] = this.m_Unit.PID;
                dr["UnID"] = this.m_Unit.ID;
                dr["ZMID"] = -1;
                dr["Sort"] = item["ID"];
                dr["JSSX"] = item["PARENTID"];
                dr["YYH"] = item["YYH"].ToString().ToUpper();
                dr["MC"] = item["MC"];
                dr["BDS"] = item["BDS"].ToString().ToUpper();
                if (dt.Columns.Contains("SCJJC"))
                {
                    dr["SCJJC"] = item["SCJJC"].ToString().ToUpper();
                }
                
                dr["TBJSJC"] = item["TBJSJC"].ToString().ToUpper();
                dr["BDJSJC"] = item["BDJSJC"].ToString().ToUpper();
                if (item["FL"].Equals(string.Empty))
                {
                    item["FL"] = 0;
                }
                dr["FL"] = item["FL"];
                dr["FYLB"] = item["FYLB"];
                dr["QFLB"] = this.Unit.TemplateType;
                this.m_Unit.StructSource.ModelPSubheadingsFee.Rows.Add(dr);
            }
            
        }

        /// <summary>
        /// 创建：工程取费
        /// </summary>
        private void Create_UnitFee()
        {
            this.m_Unit.StructSource.ModelUnitFee.RemoveAll();
            this.m_Unit.DataTemp.YSGCQFDataTemp.IsChange = true;
            DataTable dt = this.m_Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["取费表"];
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = this.m_Unit.StructSource.ModelUnitFee.NewRow();
                dr["EnID"] = this.m_Unit.PID;
                dr["UnID"] = this.m_Unit.ID;
                dr["GCLB"] = item["GONGCLB"];
                dr["DEHFW"] = item["DINGEH"];
                dr["GLFFL"] = item["GUANLFL"];
                dr["LRFL"] = item["LIRL"];
                dr["FXBDFL"] = item["FXLBD"];
                dr["GLFTBJSJC"] = item["GLTBJC"].ToString().ToUpper();
                dr["GLFBDJSJC"] = item["GLBDJC"].ToString().ToUpper();
                dr["LRFTBJSJC"] = item["LRTBJC"].ToString().ToUpper();
                dr["LRFBDJSJC"] = item["LRBDJC"].ToString().ToUpper();
                dr["FXFTBJSJC"] = item["FXTBJC"].ToString().ToUpper();
                dr["FXFBDJSJC"] = item["FXBDJC"].ToString().ToUpper();
                dr["IFSFHZ"] = item["SFHH"].ToString() == "是" ? true : false;
                this.m_Unit.StructSource.ModelUnitFee.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 获取：工程取费
        /// </summary>
        public DataRow GetUnitFeeInfo(string value)
        {
            DataRow m_FW = this.Unit.StructSource.ModelUnitFee.Select(string.Format("GCLB='{0}'", this.Unit.ProType)).FirstOrDefault();
            if (m_FW == null || !m_FW["DEHFW"].Equals(string.Empty))
            {
                if (this.Unit.StructSource.ModelUnitFee.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return m_FW;
                }
            }
            else
            {
                if (Contains(value))
                {
                    return Verification(value);
                }
                else
                {
                    return m_FW;
                }
            }
        }

        /// <summary>
        /// 验证定额号是否存在指定范围内（1,2,3）
        /// </summary>
        /// <param name="value">定额号</param>
        /// <returns>存在返回工程取费否则null</returns>
        private DataRow Verification(string value)
        {
            value = value.ToUpper();
            //比对 (～)
            foreach (DataRow item in this.Unit.StructSource.ModelUnitFee.Rows)
            {
                string[] m_DEHFW = item["DEHFW"].ToString().Split(',').Cast<string>().Where(p => p.Contains("～")).ToArray();
                foreach (string DEHFW in m_DEHFW)
                {
                    string[] bm = DEHFW.Split('～');
                    if (bm[0].Substring(0, (bm[0].LastIndexOf("-") + 1)).ToUpper() == value.Substring(0, (value.LastIndexOf("-") + 1)))
                    {
                        int MinNum = Convert.ToInt32(bm[0].Substring(bm[0].LastIndexOf("-") + 1, (bm[0].Length - bm[0].LastIndexOf("-") - 1)));
                        int MaxNum = Convert.ToInt32(bm[1].Substring(bm[1].LastIndexOf("-") + 1, (bm[1].Length - bm[1].LastIndexOf("-") - 1)));
                        int bjNum = Convert.ToInt32(value.Substring(value.LastIndexOf("-") + 1, value.Length - value.LastIndexOf("-") - 1));
                        if (bjNum >= MinNum && bjNum <= MaxNum)
                        {
                            return item;
                        }
                    }
                }
            }
            //比对 (-)
            foreach (DataRow item in this.Unit.StructSource.ModelUnitFee.Rows)
            {
                string[] m_DEHFW = item["DEHFW"].ToString().Split(',').Cast<string>().Where(p => !p.Contains("～") && p.Contains("-")).ToArray();
                foreach (string DEHFW in m_DEHFW)
                {
                    if (value.Contains("-"))
                    {
                        if (DEHFW.ToUpper() == value.Substring(0, (value.LastIndexOf("-"))))
                        {
                            return item;
                        }
                    }
                    else
                    {
                        if (DEHFW.ToUpper() == value)
                        {
                            return item;
                        }
                    }
                }
            }
            //比对 ()
            foreach (DataRow item in this.Unit.StructSource.ModelUnitFee.Rows)
            {
                string[] m_DEHFW = item["DEHFW"].ToString().Split(',').Cast<string>().Where(p => !p.Contains("～") && !p.Contains("-")).ToArray();
                foreach (string DEHFW in m_DEHFW)
                {
                    if (value.Contains("-"))
                    {
                        if (DEHFW.ToUpper() == value.Substring(0, (value.LastIndexOf("-"))))
                        {
                            return item;
                        }
                    }
                    else
                    {
                        if (DEHFW.ToUpper() == value)
                        {
                            return item;
                        }
                    }
                }
            }
            return this.Unit.StructSource.ModelUnitFee.Rows[0];
        }

        /// <summary>
        /// 验证当前打开库中是否存在定额号
        /// </summary>
        /// <param name="value">定额号</param>
        /// <returns>是否存在</returns>
        private bool Contains(string value)
        {
            DataRow dr = this.m_Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Select(string.Format("DINGEH = '{0}'", value)).FirstOrDefault();
            return dr == null ? false : true;
        }
    }
}
