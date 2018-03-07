using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ZiboSoft.Commons.Common;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
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
        public _RepairQuantityUnit(_GlobalData p_Parent)
        {
            this.m_Parent = p_Parent;
            this.m_RepairQuantityUnitList = new _RepairQuantityUnitList();
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _GlobalData m_Parent = null;

        /// <summary>
        /// 获取或设置：所属对象
        /// </summary>
        public _GlobalData Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        /// <summary>
        /// 补充工料机库的数据访问接口(接口预留程序)
        /// </summary>
        private IDataface m_IDataface = null;

        /// <summary>
        /// 获取或设置：补充工料机库的数据访问接口
        /// </summary>
        public IDataface Dataface
        {
            get { return this.m_IDataface; }
            set { this.m_IDataface = value; }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns></returns>
        public CResult Load()
        {
            this.Dataface.DataSource = this;
            return this.Dataface.Load();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <returns></returns>
        public CResult Save()
        {
            return this.Dataface.Save();
        }

        /// <summary>
        /// 补充工料机集合
        /// </summary>
        private _RepairQuantityUnitList m_RepairQuantityUnitList = null;

        /// <summary>
        /// 获取或设置：补充工料机集合
        /// </summary>
        public _RepairQuantityUnitList RepairQuantityUnitList
        {
            get { return m_RepairQuantityUnitList; }
            set { m_RepairQuantityUnitList = value; }
        }

        [NonSerialized]
        private BindingSource m_RepairQuantityUnitList_BindingSource = null;

        public BindingSource RepairQuantityUnitList_BindingSource
        {
            get
            {
                if (this.m_RepairQuantityUnitList_BindingSource == null)
                {
                    this.m_RepairQuantityUnitList_BindingSource = new BindingSource();
                }
                this.m_RepairQuantityUnitList_BindingSource.DataSource = this.m_RepairQuantityUnitList;
                return this.m_RepairQuantityUnitList_BindingSource;
            }
        }

        /// <summary>
        /// 添加补充人才机
        /// </summary>
        /// <param name="new_info"></param>
        public void CreateZMGLJ(DataRow new_info)
        {
            _RepairQuantityUnitInfo info = new _RepairQuantityUnitInfo();
            info.ID = this.RepairQuantityUnitList.Count + 1;
            info.YSBH = new_info["YSBH"].ToString();
            info.YSMC = new_info["YSMC"].ToString();
            info.YSDW = new_info["YSDW"].ToString();
            info.YSXHL = ToolKit.ParseDecimal(new_info["YSXHL"]);
            info.DEDJ = ToolKit.ParseDecimal(new_info["DEDJ"]);
            info.BH = new_info["BH"].ToString();
            info.MC = new_info["MC"].ToString();
            info.DW = new_info["DW"].ToString();
            info.LB = new_info["LB"].ToString();
            info.IFZYCL = ToolKit.ParseBoolen(new_info["IFZYCL"]);
            info.SL = ToolKit.ParseDecimal(new_info["SL"]);
            info.XHL = ToolKit.ParseDecimal(new_info["YSXHL"]);
            info.SCDJ = ToolKit.ParseDecimal(new_info["SCDJ"]);
            info.GGXH = new_info["GGXH"].ToString();
            info.SSDWGC = new_info["SSDWGC"].ToString();
            info.CTIME = DateTime.Now;
            this.m_RepairQuantityUnitList.Add(info);
        }

        /// <summary>
        /// 移除被选择信息
        /// </summary>
        public void Remove()
        {
            IEnumerable<_Entity_QuantityUnit> list = from info in this.m_RepairQuantityUnitList_BindingSource.Cast<_Entity_QuantityUnit>()
                                                        where info.IFXZ == true
                                                        select info;
            foreach (_Entity_QuantityUnit item in list)
            {
                this.m_RepairQuantityUnitList_BindingSource.Remove(item);
            }
            this.m_RepairQuantityUnitList_BindingSource.ResetBindings(false);
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

        public string GetRepairBH()
        {
            _RepairQuantityUnitInfo[] list = this.RepairQuantityUnitList.Cast<_RepairQuantityUnitInfo>().OrderBy(p => p.ID).ToArray();
            if (list.Count() == 0) return ("BC0001");
            for (int i = 0, j = 1; j < this.RepairQuantityUnitList.Count; i++, j++)
            {
                if ((list[j].ID - list[i].ID) > 1)
                {
                    return ("BC" + (list[i].ID + 1).ToString("0000"));
                }
            }

            if (list.First().ID == 1)
            {
                return ("BC" + (list.Last().ID + 1).ToString("0000"));
            }
            else
            {
                return ("BC0001");
            }
        }

        public string GetRepairBH(_UnitProject p_CUnitProject, string p_LB)
        {
            DataRow[] list = p_CUnitProject.StructSource.ModelQuantity.Select(string.Format("BH like '%补充{0}%'", p_LB), "BH");
            if (list.Count() == 0) return ("补充" + p_LB + "0001");
            for (int i = 0, j = 1; j < list.Count(); i++, j++)
            {
                int info_i = ToolKit.ParseInt(list[i]["BH"].ToString().Substring(4));
                int info_j = ToolKit.ParseInt(list[j]["BH"].ToString().Substring(4));
                if ((info_j - info_i) > 1)
                {
                     return ("补充" + p_LB + (info_i + 1).ToString("0000"));
                }
            }

            int info_b = ToolKit.ParseInt(list.First()["BH"].ToString().Substring(4));
            if (info_b == 1)
            {
                return ("补充" + p_LB + (ToolKit.ParseInt(list.Last()["BH"].ToString().Substring(4)) + 1).ToString("0000"));
            }
            else
            {
                return ("补充" + p_LB + "0001");
            }
        }
    }
}
