/*
 *  用户价格库操作类
 *  此类中包含用户价格库的操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 用户价格库操作类
    /// </summary>
    [Serializable]
    public class _UserPriceLibrary
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _UserPriceLibrary(_GlobalData p_Parent)
        {
            this.m_Parent = p_Parent;
            this.m_UserPriceLibraryList = new _UserPriceLibraryList();
        }

        /// <summary>
        /// 当前活动的单位工程对象
        /// </summary>
        private _UnitProject m_Activitie = null;

        /// <summary>
        /// 获取或设置：当前活动的单位工程对象
        /// </summary>
        public _UnitProject Activitie
        {
            get
            {
                return this.m_Activitie;
            }
            set
            {
                this.m_Activitie = value;
            }
        }

        /// <summary>
        /// 用户价格库的数据访问接口(接口预留程序)
        /// </summary>
        private IDataface m_IDataface = null;

        /// <summary>
        /// 获取或设置：用户价格库的数据访问接口
        /// </summary>
        public IDataface Dataface
        {
            get { return this.m_IDataface; }
            set { this.m_IDataface = value; }
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
        /// 所有工料机
        /// </summary>
        private IEnumerable<DataRow> m_AllQuantityUnit = null;

        /// <summary>
        /// 获取或设置：所有工料机
        /// </summary>
        public IEnumerable<DataRow> AllQuantityUnit
        {
            get
            {
                m_AllQuantityUnit = m_Activitie.StructSource.ModelQuantity.AsEnumerable();
                return m_AllQuantityUnit;
            }
            set { m_AllQuantityUnit = value; }
        }

        /// <summary>
        /// 所选择范围工料机
        /// </summary>
        private IEnumerable<DataRow> m_PartQuantityUnit = null;

        /// <summary>
        /// 获取或设置：所选择范围工料机
        /// </summary>
        public IEnumerable<DataRow> PartQuantityUnit
        {
            get
            {
                if (m_PartQuantityUnit == null)
                {
                    m_PartQuantityUnit = m_Activitie.StructSource.ModelQuantity.AsEnumerable();
                }
                return m_PartQuantityUnit;
            }
            set { m_PartQuantityUnit = value; }
        }

        /// <summary>
        /// 用户价格库集合对象
        /// </summary>
        private _UserPriceLibraryList m_UserPriceLibraryList = null;

        /// <summary>
        /// 获取或设置：用户价格库集合对象
        /// </summary>
        public _UserPriceLibraryList UserPriceLibraryList
        {
            get { return m_UserPriceLibraryList; }
            set { m_UserPriceLibraryList = value; }
        }

        /// <summary>
        /// 当前修改的字段
        /// </summary>
        private string fieldName = string.Empty;

        /// <summary>
        /// 获取或设置：当前修改的字段
        /// </summary>
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        //private 

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_Original">修改后的值</param>
        /// <param name="p_FieldName">当前修改字段名称</param>
        public void Update(DataRow p_Info, string p_FieldName)
        {
            this.FieldName = p_FieldName;
            switch (p_FieldName)//根据不同的字段名称处理不同
            {
                case "MC":
                    UpdateMC(p_Info);
                    break;
                case "DW":
                    UpdateDW(p_Info);
                    break;
                case "SCDJ":
                    UpdateSCDJ(p_Info);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 修改名称处理方法（MC）
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_After">修改后的值</param>
        private void UpdateMC(DataRow p_Info)
        {
            //查询当前对象修改后的值是否重复
            IEnumerable<DataRow> cf_list = this.AllQuantityUnit.Where(p => p["YSBH"].Equals(p_Info["YSBH"]) && p["MC", DataRowVersion.Current].Equals(p_Info["MC", DataRowVersion.Proposed]) && p["DW"].Equals(p_Info["DW"]) && p["SCDJ"].Equals(p_Info["SCDJ"]));
            //查询所有工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> a_list = this.AllQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //查询所选范围工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> p_list = this.PartQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //查询是否有重复数据
            if (cf_list.Count() == 0)
            {
                //只有自身时 检查是否是恢复原始值 别且全部工料机与所选工料机条数相同时进入
                if (p_Info["MC", DataRowVersion.Proposed].Equals(p_Info["YSMC"]) && p_Info["DW"].Equals(p_Info["YSDW"]) && p_Info["SCDJ"].Equals(p_Info["DEDJ"]) && a_list.Count() == p_list.Count())
                {
                    //执行范围修改  设置原始编号
                    this.EditPart(p_Info, p_Info["YSBH"].ToString());
                }
                else
                {
                    //检查是否需要修改用户价格  全部工料机与所选工料机条数相同时并且用户价格库中存在修改前的数据进入
                    if (a_list.Count() == p_list.Count() && !p_Info["BH"].Equals(p_Info["YSBH"]))
                    {
                        //插入新的用户价格 指定编号
                        this.Insert(p_Info, p_Info["BH"].ToString());
                    }
                    else
                    {
                        //插入新的用户价格 生成新编号
                        this.Insert(p_Info, string.Empty);
                    }
                }
            }
            else
            {
                //当前重复数据中排除自身以后 就是重复的信息（重复就提取重用 不做其他处理）
                DataRow cf_Info = cf_list.FirstOrDefault();
                //执行范围修改  设置重复的编号
                if (cf_Info != null)
                {
                    this.EditPart(p_Info, cf_Info["BH"].ToString());
                }
            }
        }

        /// <summary>
        /// 修改单位处理方法（DW）
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_Original">修改前的值</param>
        private void UpdateDW(DataRow p_Info)
        {
            //查询当前对象修改后的值是否重复
            IEnumerable<DataRow> cf_list = this.AllQuantityUnit.Where(p => p["YSBH"].Equals(p_Info["YSBH"]) && p["MC"].Equals(p_Info["MC"]) && p["DW", DataRowVersion.Current].Equals(p_Info["DW", DataRowVersion.Proposed]) && p["SCDJ"].Equals(p_Info["SCDJ"]));
            //查询所有工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> a_list = this.AllQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //查询所选范围工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> p_list = this.PartQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //全部工料机与所选工料机条数相同时 需要删除当前用户价格信息
            //查询是否有重复数据
            if (cf_list.Count() == 0)
            {
                //只有自身时 检查是否是恢复原始值 别且全部工料机与所选工料机条数相同时进入
                if (p_Info["MC"].Equals(p_Info["YSMC"]) && p_Info["DW", DataRowVersion.Proposed].Equals(p_Info["YSDW"]) && p_Info["SCDJ"].Equals(p_Info["DEDJ"]) && a_list.Count() == p_list.Count())
                {
                    //执行范围修改  设置原始编号
                    this.EditPart(p_Info, p_Info["YSBH"].ToString());
                }
                else
                {
                    //检查是否需要修改用户价格  全部工料机与所选工料机条数相同时并且用户价格库中存在修改前的数据进入
                    if (a_list.Count() == p_list.Count() && !p_Info["BH"].Equals(p_Info["YSBH"]))
                    {
                        //插入新的用户价格 指定编号
                        this.Insert(p_Info, p_Info["BH"].ToString());
                    }
                    else
                    {
                        //插入新的用户价格 生成新编号
                        this.Insert(p_Info, string.Empty);
                    }
                }
            }
            else
            {
                //当前重复数据中排除自身以后 就是重复的信息（重复就提取重用 不做其他处理）
                DataRow cf_Info = cf_list.FirstOrDefault();
                //执行范围修改  设置重复的编号
                if (cf_Info != null)
                {
                    this.EditPart(p_Info, cf_Info["BH"].ToString());
                }
            }
        }

        /// <summary>
        /// 修改市场单价处理方法（SCDJ）
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_Original">修改前的值</param>
        private void UpdateSCDJ(DataRow p_Info)
        {
            //查询当前修改对象的值是否重复
            IEnumerable<DataRow> cf_list = this.AllQuantityUnit.Where(p => p["YSBH"].Equals(p_Info["YSBH"]) && p["MC"].Equals(p_Info["MC"]) && p["DW"].Equals(p_Info["DW"]) && p["SCDJ", DataRowVersion.Current].Equals(p_Info["SCDJ", DataRowVersion.Proposed]));
            //查询所有工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> a_list = this.AllQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //查询所选范围工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> p_list = this.PartQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //2条记录算重复（其中一条是自身）
            if (cf_list.Count() == 0)
            {
                //只有自身时 检查是否是恢复原始值 别且全部工料机与所选工料机条数相同时进入
                if (p_Info["MC"].Equals(p_Info["YSMC"]) && p_Info["DW"].Equals(p_Info["YSDW"]) && p_Info["SCDJ", DataRowVersion.Proposed].Equals(p_Info["DEDJ"]) && a_list.Count() == p_list.Count() && !p_Info["IFKFJ"].Equals(true))
                {
                    //执行范围修改  设置原始编号
                    this.EditPart(p_Info, p_Info["YSBH"].ToString());
                }
                else
                {
                    //检查是否需要修改用户价格  全部工料机与所选工料机条数相同时并且用户价格库中存在修改前的数据进入
                    if (a_list.Count() == p_list.Count())
                    {
                        //插入新的用户价格 指定编号
                        this.Insert(p_Info, p_Info["BH"].ToString());
                    }
                    else
                    {
                        //插入新的用户价格 生成新编号
                        this.Insert(p_Info, string.Empty);
                    }
                }
            }
            else
            {
                //当前重复数据中排除自身以后 就是重复的信息（重复就提取重用 不做其他处理）
                DataRow cf_Info = cf_list.FirstOrDefault();
                //执行范围修改  设置重复的编号
                if (cf_Info != null)
                {
                    this.EditPart(p_Info, cf_Info["BH"].ToString());
                }
            }
        }

        /// <summary>
        /// 修改市场单价处理方法（SCDJ）
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_Original">修改前的值</param>
        private void UpdateZCSCDJ(DataRow p_Info)
        {
            //查询当前修改对象的值是否重复
            IEnumerable<DataRow> cf_list = this.AllQuantityUnit.Where(p => p["YSBH"].Equals(p_Info["YSBH"]) && p["MC"].Equals(p_Info["MC"]) && p["DW"].Equals(p_Info["DW"]) && p["SCDJ", DataRowVersion.Current].Equals(p_Info["SCDJ", DataRowVersion.Proposed]));
            //查询所有工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> a_list = this.AllQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //查询所选范围工料机中的相同编号的当前修改对象条数
            IEnumerable<DataRow> p_list = this.PartQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"]));
            //2条记录算重复（其中一条是自身）
            if (cf_list.Count() == 0)
            {
                if (a_list.Count() == p_list.Count())
                {
                    //插入新的用户价格 指定编号
                    this.Insert(p_Info, p_Info["BH"].ToString());
                }
                else
                {
                    //插入新的用户价格 生成新编号
                    this.Insert(p_Info, string.Empty);
                }
            }
            else
            {
                //当前重复数据中排除自身以后 就是重复的信息（重复就提取重用 不做其他处理）
                DataRow cf_Info = cf_list.FirstOrDefault();
                //执行范围修改  设置重复的编号
                if (cf_Info != null)
                {
                    this.EditPart(p_Info, cf_Info["BH"].ToString());
                }
            }
        }

        /// <summary>
        /// 获取新编号（例如：10001_1）
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <returns>新编号</returns>
        private string GetNumber(DataRow p_Info)
        {
            int i = 1;//用来记录编号
            //统计全部人材机中的当前修改对象原始编号条数 作为循环次数
            IEnumerable<DataRow> a_list = this.AllQuantityUnit.Where(p => p["YSBH"].Equals(p_Info["YSBH"]));
            foreach (DataRow item in a_list)
            {
                //手动生成（1000_i）查询条件
                IEnumerable<DataRow> list = this.AllQuantityUnit.Where(p => p["BH"].Equals(p_Info["YSBH"].ToString() + "_" + i));
                if (list.Count() == 0)
                {
                    //如果不存在 跳出循环提取 i 值作为编号后缀
                    break;
                }
                i++;
                //否则继续寻找
            }
            return (p_Info["YSBH"].ToString() + "_" + i).ToString();
        }

        /// <summary>
        /// 插入一条新的用户价格
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_BH">指定编号：如果是 string.Empty 则获取新编号 否则是指定编号</param>
        public void Insert(DataRow p_Info, string p_BH)
        {
            _UserPriceLibraryInfo newinfo = new _UserPriceLibraryInfo();
            newinfo.YSBH = p_Info["YSBH"].ToString();
            newinfo.YSDW = p_Info["YSDW"].ToString();
            newinfo.YSMC = p_Info["YSMC"].ToString();
            newinfo.YSXHL = ToolKit.ParseDecimal(p_Info["YSXHL"]);
            newinfo.ZCLB = p_Info["ZCLB"].ToString();
            newinfo.BH = p_BH == string.Empty ? GetNumber(p_Info) : p_BH; //如果是 string.Empty 则获取新编号 否则是指定编号
            newinfo.DEDJ = ToolKit.ParseDecimal(p_Info["DEDJ"]);

            newinfo.LB = p_Info["LB"].ToString();
            newinfo.MC = this.FieldName == "MC" ? p_Info["MC", DataRowVersion.Proposed].ToString() : p_Info["MC"].ToString();
            newinfo.DW = this.FieldName == "DW" ? p_Info["DW", DataRowVersion.Proposed].ToString() : p_Info["DW"].ToString();
            newinfo.XHL = ToolKit.ParseDecimal(p_Info["XHL"]);
            newinfo.SCDJ = this.FieldName == "SCDJ" ? ToolKit.ParseDecimal(p_Info["SCDJ", DataRowVersion.Proposed]) : ToolKit.ParseDecimal(p_Info["SCDJ"]);
            newinfo.SL = ToolKit.ParseDecimal(p_Info["SL"]);
            newinfo.GGXH = p_Info["GGXH"].ToString();
            newinfo.SSDWGC = this.Activitie.Name;
            //newinfo.SSKLB = p_Info["SSKLB"].ToString();
            newinfo.SSLB = ToolKit.ParseInt(p_Info["SSLB"]);
            this.m_UserPriceLibraryList.Add(newinfo);
            //执行范围修改  设置新的编号
            EditPart(p_Info, newinfo.BH);
        }

        /// <summary>
        /// 修改所选范围内的人材机
        /// </summary>
        /// <param name="p_Info">当前修改对象</param>
        /// <param name="p_BH">指定修改编号</param>
        private void EditPart(DataRow p_Info, string p_BH)
        {
            //只有在所选范围内有数据时进入
            if (m_PartQuantityUnit != null)
            {
                //提取所选范围内 当前修改对象相同编号的数据
                DataRow[] p_list = this.PartQuantityUnit.Where(p => p["BH"].Equals(p_Info["BH"])).ToArray();
                foreach (DataRow item in p_list)
                {
                    //当前查询出来的工料机需要重新设置状态
                    item["BH"] = p_BH;
                    switch (this.FieldName)
                    {
                        case "MC":
                            if (!item["MC"].Equals(p_Info["MC", DataRowVersion.Proposed]))
                            {
                                item["MC"] = p_Info["MC", DataRowVersion.Proposed];
                            }
                            break;
                        case "DW":
                            if (!item["DW"].Equals(p_Info["DW", DataRowVersion.Proposed]))
                            {
                                item["DW"] = p_Info["DW", DataRowVersion.Proposed];
                            }
                            break;
                        case "SCDJ":
                            if (!item["SCDJ"].Equals(p_Info["SCDJ", DataRowVersion.Proposed]))
                            {
                                item["SCDJ"] = p_Info["SCDJ", DataRowVersion.Proposed];
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="p_Info"></param>
        public void Add(DataRow p_Info)
        {
            _UserPriceLibraryInfo newinfo = new _UserPriceLibraryInfo();
            newinfo.YSBH = p_Info["YSBH"].ToString();
            newinfo.YSDW = p_Info["YSDW"].ToString();
            newinfo.YSMC = p_Info["YSMC"].ToString();
            newinfo.YSXHL = ToolKit.ParseDecimal(p_Info["YSXHL"]);
            newinfo.ZCLB = p_Info["ZCLB"].ToString();
            newinfo.BH = p_Info["BH"].ToString();
            newinfo.DEDJ = ToolKit.ParseDecimal(p_Info["DEDJ"]);
            newinfo.DW = p_Info["DW"].ToString();
            newinfo.LB = p_Info["LB"].ToString();
            newinfo.MC = p_Info["MC"].ToString();
            newinfo.XHL = ToolKit.ParseDecimal(p_Info["XHL"]);
            newinfo.SCDJ = ToolKit.ParseDecimal(p_Info["SCDJ"]);
            newinfo.SL = ToolKit.ParseDecimal(p_Info["SL"]);
            newinfo.SSDWGC = this.Activitie.Name;
            newinfo.SSKLB = p_Info["SSKLB"].ToString();
            newinfo.SSLB = ToolKit.ParseInt(p_Info["SSLB"]);
            this.m_UserPriceLibraryList.Add(newinfo);
        }

        public decimal GetSCDJ(string p_BH, string p_SSDWGC)
        {
            IEnumerable<_UserPriceLibraryInfo> list = this.m_UserPriceLibraryList.Cast<_UserPriceLibraryInfo>().Where(p => p.SSDWGC == p_SSDWGC && p.BH == p_BH);
            return list.Count() == 0m ? 0m : list.First().SCDJ;
        }
    }
}