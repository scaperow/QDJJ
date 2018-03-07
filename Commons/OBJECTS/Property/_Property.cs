/*
    当前数据对象的属性集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Windows.Forms;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 当前数据对象的属性集合
    /// </summary>
    [Serializable]
    public class _Property
    {
        /// <summary>
        /// 当前基础类别的父类别(若为顶级类别此属性为null)
        /// </summary>
        private _COBJECTS m_Parent = null;
        /// <summary>
        /// 获取当前基础父类别
        /// </summary>
        public virtual _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        /// <summary>
        /// 临时操作对象数据
        /// </summary>
        [NonSerialized]
        private _Temporary m_Temporary = null;

        /// <summary>
        /// 获取或设置临时操作数据对象
        /// </summary>
        public _Temporary Temporary
        {
            get
            {
                if (m_Temporary == null)
                {
                    this.m_Temporary = new _Temporary();
                    this.Libraries = this.Parent.Property.DLibraries.Copy();
                }
                return this.m_Temporary;
            }
            set
            {
                this.m_Temporary = value;
            }
        }

        public _Property(_COBJECTS p_Info)
        {
            this.m_Parent = p_Info;
        }

        #region-------------------------------------公共属性----------------------------

        /// <summary>
        /// 同步名称
        /// </summary>
        public virtual string Name
        {
            get
            {
                return this.Basis.Name;
            }
            set
            {
                this.Basis.Name = this.Parent.Directory.NodeName = value;
            }
        }

        /// <summary>
        /// 同步项目编码(非单位工程)
        /// </summary>
        public virtual string Code
        {
            get
            {
                return this.Basis.CODE;
            }
            set
            {
                this.Basis.CODE = value;
            }
        }

        /// <summary>
        ///【公共属性】获取基础信息对象
        /// </summary>
        public virtual _CBasis Basis
        {
            get
            {
                return this.Parent.DataObject.Get("基础信息") as _CBasis;
            }
            set
            {
                this.Parent.DataObject.Set("基础信息", value);
            }
        }

        /// <summary>
        ///【公共属性】获取保存信息对象(如果保存信息不存在返回 一个新的实例)
        /// </summary>
        public virtual _SaveInfoList SaveInfoList
        {
            get
            {
                _SaveInfoList info = this.Parent.DataObject.Get("保存信息") as _SaveInfoList;
                if (info == null)
                {
                    info = new _SaveInfoList();
                }
                else
                {
                    info = this.Parent.DataObject.Get("保存信息") as _SaveInfoList;
                }

                return info;
            }
            set
            {
                this.Parent.DataObject.Set("保存信息", value);
            }
        }

        /// <summary>
        ///【公共属性】获取配置信息对象
        /// </summary>
        public virtual _Setting Setting
        {
            get
            {
                return this.Parent.DataObject.Get("配置信息") as _Setting;
            }
            set
            {
                this.Parent.DataObject.Set("配置信息", value);
            }
        }
        /*
        /// <summary>
        ///【公共属性】获取配置信息对象
        /// </summary>
        public virtual _ObjMetaanalysis ObjMetaanalysis
        {
            get
            {
                return this.Parent.DataObject.Get("通用汇总分析") as _ObjMetaanalysis;
            }
            set
            {
                this.Parent.DataObject.Set("通用汇总分析", value);
            }
        }*/

        /// <summary>
        /// 当前业务对象中是否存指定名称的业务对象(默认查找当前对象的字典中的所有对象包括:单项工程,单位工程)
        /// </summary>
        /// <param name="p_Name">名称</param>
        /// <param name="p_TypeName">类型名称0,1,2可多选</param>
        /// <returns>是否存在</returns>
        public virtual bool IsExist(string p_Code, EObjectType p_ObjectType)
        {
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                if (p_ObjectType == EObjectType.Engineering)
                {
                    if (item.Property.Basis.CODE == p_Code)
                    {
                        return true;
                    }
                }
                if (p_ObjectType == EObjectType.UnitProject)
                {
                    if (item.Property.IsExist(p_Code, p_ObjectType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion


        #region -----------------------------------项目属性-----------------------------
        /// <summary>
        /// 【项目属性】获取项目的基本信息
        /// </summary>
        public virtual _BasicInformation BasicInformation
        {
            get
            {
                return this.Parent.DataObject.Get("项目信息") as _BasicInformation;
            }
            set
            {
                this.Parent.DataObject.Set("项目信息", value);
            }
        }

        ///// <summary>
        ///// 【项目属性】获取项目的基本信息
        ///// </summary>
        //public virtual _Export Export
        //{
        //    get
        //    {
        //        return this.Parent.DataObject.Get("导入导出") as _Export;
        //    }
        //    set
        //    {
        //        this.Parent.DataObject.Set("导入导出", value);
        //    }
        //}


        /// <summary>
        /// 获取项目工料机汇总
        /// </summary>
        public virtual _List GetProjectSummary
        {
            get
            {
                _List list = new _List();
                foreach (_Engineering item in this.Parent.StrustObject.ObjectList.Values)
                {
                    foreach (_UnitProject items in item.StrustObject.ObjectList.Values)
                    {
                        list.AddRange(items.Property.QuantityUnitSummary.ToArray());
                    }
                }
                return list;
            }
        }


        #endregion

        #region ----------------------------------工程属性-------------------------------
        /// <summary>
        /// 【工程属性】基本数据
        /// </summary>
        public virtual CBaseData BaseData
        {
            get
            {
                return this.Parent.DataObject.Get("基本数据") as CBaseData;
            }
            set
            {
                this.Parent.DataObject.Set("基本数据", value);
            }
        }

        /// <summary>
        /// 【工程属性】库对象 应用(返回默认库对象 若修改后则为修改后的库对象)
        /// </summary>
        public virtual _Library Libraries
        {
            get
            {
               // return null;
                return this.Temporary.Libraries;
            }
            set
            {
                this.Temporary.Libraries = value;
            }
        }

        /// <summary>
        /// 【工程属性】库对象 默认
        /// </summary>
        public virtual _Library DLibraries
        {
            get
            {
                return this.Parent.DataObject.Get("库对象") as _Library;
            }
            set
            {
                this.Parent.DataObject.Set("库对象", value);
            }
        }


        /// <summary>
        /// 【工程属性】分部分项
        /// </summary>
        public virtual _SubSegments SubSegments
        {
            get
            {
                return this.Parent.DataObject.Get("分部分项") as _SubSegments;
            }
            set
            {
                this.Parent.DataObject.Set("分部分项", value);
            }
        }
        // /// <summary>
        ///// 【工程属性】工程信息
        ///// </summary>
        //public virtual _UnInformation UnInformation
        //{
        //    get
        //    {
        //        return this.Parent.DataObject.Get("工程信息") as _UnInformation;
        //    }
        //    set
        //    {
        //        this.Parent.DataObject.Set("工程信息", value);
        //    }
        //}
        /// <summary>
        /// 【工程属性】汇总分析
        /// </summary>
        public virtual _Metaanalysis Metaanalysis
        {
            get
            {
                return this.Parent.DataObject.Get("汇总分析") as _Metaanalysis;
            }
            set
            {
                this.Parent.DataObject.Set("汇总分析", value);
            }

        }

        /// <summary>
        /// 【工程属性】其他项目
        /// </summary>
        public virtual _OtherProject OtherProject
        {
            get
            {
                return this.Parent.DataObject.Get("其他项目") as _OtherProject;
            }
            set
            {
                this.Parent.DataObject.Set("其他项目", value);
            }
        }



        /// <summary>
        /// 【工程属性】工料机汇总
        /// </summary>
        public virtual _List QuantityUnitSummary
        {
            get
            {
                return this.Parent.NonSeriObject.Get("工料机汇总") as _List;
            }
            set
            {
                this.Parent.NonSeriObject.Set("工料机汇总", value);
            }
        }

        /// <summary>
        /// 【工程属性】工程统计
        /// </summary>
        public virtual _Statistics Statistics
        {
            get
            {
                return this.Parent.NonSeriObject.Get("工程统计") as _Statistics;
            }
            set
            {
                this.Parent.NonSeriObject.Set("工程统计", value);
            }
        }

        /// <summary>
        /// 【工程属性】子目增加费
        /// </summary>
        public virtual _IncreaseCosts IncreaseCosts
        {
            get
            {
                return this.Parent.NonSeriObject.Get("子目增加费") as _IncreaseCosts;
            }
            set
            {
                this.Parent.NonSeriObject.Set("子目增加费", value);
            }
        }

        /// <summary>
        /// 【工程属性】用途类别汇总
        /// </summary>
        public virtual YTLBSummaryList YTLBSummaryList
        {
            get
            {
                return this.Parent.DataObject.Get("用途类别汇总") as YTLBSummaryList;
            }
            set
            {
                this.Parent.DataObject.Set("用途类别汇总", value);
            }
        }

        /// <summary>
        /// 【工程属性】措施项目
        /// </summary>
        public virtual _MeasuresProject MeasuresProject
        {
            get
            {
                return this.Parent.DataObject.Get("措施项目") as _MeasuresProject;
            }
            set
            {
                this.Parent.DataObject.Set("措施项目", value);
            }
        }

        /// <summary>
        /// 【工程属性】措施项目
        /// </summary>
        public virtual _ParameterSettings ParameterSettings
        {
            get
            {
                return this.Parent.DataObject.Get("参数设置") as _ParameterSettings;
            }
            set
            {
                this.Parent.DataObject.Set("参数设置", value);
            }
        }

        /// <summary>
        /// 【工程属性】子目临时计算
        /// </summary>
        public virtual TemporaryCalculate TemporaryCalculate
        {
            get
            {
                return this.Parent.NonSeriObject.Get("子目临时计算") as TemporaryCalculate;
            }
            set
            {
                this.Parent.NonSeriObject.Set("子目临时计算", value);
            }
        }

        /// <summary>
        /// 【工程属性】工程历史
        /// </summary>
        public virtual _History History
        {
            get
            {
                return this.Parent.DataObject.Get("工程历史") as _History;
            }
            set
            {
                this.Parent.DataObject.Set("工程历史", value);
            }
        }



        /// <summary>
        /// 【工程属性】单位工程下的所有子目工料机
        /// </summary>
        public virtual _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                list.AddRange(this.SubSegments.GetAllQuantityUnit);
                list.AddRange(this.MeasuresProject.GetAllQuantityUnit);
                return list;
            }
        }

        /// <summary>
        /// 用途类别汇总BindingSource
        /// </summary>
        [NonSerialized]
        private BindingSource m_YTLBSummaryList_BindingSource = new BindingSource();

        /// <summary>
        /// 【工程属性】获取：用途类别汇总BindingSource
        /// </summary>
        public BindingSource YTLBSummaryList_BindingSource
        {
            get
            {
                if (this.m_YTLBSummaryList_BindingSource == null)
                {
                    this.m_YTLBSummaryList_BindingSource = new BindingSource();
                }
                this.m_YTLBSummaryList_BindingSource.DataSource = this.YTLBSummaryList;
                return this.m_YTLBSummaryList_BindingSource;
            }
        }

        /// <summary>
        /// 单位工程下的所有子目工料机
        /// </summary>
        public virtual _List GetAllQuantityUnitNotZC
        {
            get
            {
                _List list = new _List();

                list.AddRange(this.SubSegments.GetAllQuantityUnitNotZC);
                list.AddRange(this.MeasuresProject.GetAllQuantityUnitNotZC);
                return list;
            }
        }

        /// <summary>
        /// 保存措施项目
        /// </summary>
        /// <param name="path"></param>
        public void MeasuresProjectSave(string path)
        {
            //SetTYQD();
            _UnitProject u = this.MeasuresProject.Parent;
            this.MeasuresProject.Parent = null;
            CFiles.BinarySerialize(this.MeasuresProject, path);
            this.MeasuresProject.Parent = u;
        }
        private void SetTYQD()
        {
            IEnumerable<_ObjectInfo> infos = from n in this.MeasuresProject.CommonrojectList[0].MFixedList.Cast<_ObjectInfo>()
                                            where 1==1
                                             select n;
            _ObjectInfo[] s =infos.ToArray();
            for (int i = 0; i < 4; i++)
            {
                s[i].ISTY = true;
            }

        }

        /// <summary>
        ///从指定文件初始化数据集
        /// </summary>
        public void MeasuresProjectLoad(string Path)
        {
            if (this.MeasuresProject != null)
            {
                object obj = CFiles.Deserialize(Path);
                this.MeasuresProject = null;
                this.MeasuresProject = obj as _MeasuresProject;
                this.MeasuresProject.Parent = this.Parent as _UnitProject;
                this.MeasuresProject.InSerializable(this.Parent);
                
            }
        }

        /// <summary>
        /// 创建三大材
        /// </summary>
        /// <returns></returns>
        private DataTable CreateSDC()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("BH", typeof(string));
            dt.Columns.Add("MC", typeof(string));
            dt.Columns.Add("DW", typeof(string));
            dt.Columns.Add("SLH", typeof(decimal));
            dt.Columns.Add("SCDJ", typeof(decimal));
            dt.Columns.Add("SCHJ", typeof(decimal));
            dt.Columns.Add("SDCSLH", typeof(decimal));
            DataRow drgc = dt.NewRow();
            drgc["ID"] = 1;
            drgc["ParentID"] = -1;
            drgc["MC"] = "钢材";
            drgc["DW"] = "吨";
            drgc["SLH"] = 0m;
            dt.Rows.Add(drgc);
            DataRow drmc = dt.NewRow();
            drmc["ID"] = 2;
            drmc["ParentID"] = -1;
            drmc["MC"] = "木材";
            drmc["DW"] = "立方米";
            drmc["SLH"] = 0m;
            dt.Rows.Add(drmc);
            DataRow drsn = dt.NewRow();
            drsn["ID"] = 3;
            drsn["ParentID"] = -1;
            drsn["MC"] = "水泥";
            drsn["DW"] = "吨";
            drsn["SLH"] = 0m;
            dt.Rows.Add(drsn);
            return dt;
        }

        /// <summary>
        /// 获取三大材
        /// </summary>
        /// <returns></returns>
        public DataTable GetSDC(IEnumerable<_ObjectQuantityUnitInfo> p_Summary)
        {
            DataTable m_dt = this.CreateSDC();
            IEnumerable<_ObjectQuantityUnitInfo> sdc_list = p_Summary.Where(p => p.SDCLB != "");
            foreach (_ObjectQuantityUnitInfo item in sdc_list)
            {
                DataRow dr = m_dt.NewRow();
                switch (item.SDCLB)
                {
                    case "钢材":
                        dr["ParentID"] = 1;
                        break;
                    case "木材":
                        dr["ParentID"] = 2;
                        break;
                    case "水泥":
                        dr["ParentID"] = 3;
                        break;
                    default:
                        break;
                }
                dr["ID"] = (m_dt.Rows.Count + 1);
                dr["BH"] = item.BH;
                dr["MC"] = item.MC;
                dr["DW"] = item.DW;
                dr["SLH"] = item.SL;
                dr["SCDJ"] = item.SCDJ;
                dr["SCHJ"] = item.SCHJ;
                if (item.SDCXS > 0)
                {
                    dr["SDCSLH"] = item.SL * item.SDCXS;
                }
                m_dt.Rows.Add(dr);
            }
            m_dt.Select("ID=1")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 1");
            m_dt.Select("ID=2")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 2");
            m_dt.Select("ID=3")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 3");
            return m_dt;
        }

        /// <summary>
        /// 获取三大材
        /// </summary>
        /// <returns></returns>
        public DataTable GetSDC(IEnumerable<DataRow> p_Summary)
        {
            DataTable m_dt = this.CreateSDC();
            IEnumerable<DataRow> sdc_list = p_Summary.Where(p => !p["SDCLB"].Equals(string.Empty));
            foreach (DataRow item in sdc_list)
            {
                DataRow dr = m_dt.NewRow();
                switch (item["SDCLB"].ToString())
                {
                    case "钢材":
                        dr["ParentID"] = 1;
                        break;
                    case "木材":
                        dr["ParentID"] = 2;
                        break;
                    case "水泥":
                        dr["ParentID"] = 3;
                        break;
                    default:
                        break;
                }
                dr["ID"] = (m_dt.Rows.Count + 1);
                dr["BH"] = item["BH"];
                dr["MC"] = item["MC"];
                dr["DW"] = item["DW"];
                dr["SLH"] = item["SL"];
                dr["SCDJ"] = item["SCDJ"];
                dr["SCHJ"] = item["SCHJ"];
                dr["SDCSLH"] = ToolKit.ParseDecimal(item["SL"]) * ToolKit.ParseDecimal(item["SDCXS"]);
                m_dt.Rows.Add(dr);
            }
            m_dt.Select("ID=1")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 1");
            m_dt.Select("ID=2")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 2");
            m_dt.Select("ID=3")[0]["SLH"] = m_dt.Compute("Sum(SDCSLH)", "ParentID = 3");
            return m_dt;
        }

        /// <summary>
        /// 是否重复
        /// </summary>
        /// <returns></returns>
        public bool RepeatInfo(_ObjectQuantityUnitInfo p_Info ,out _ObjectQuantityUnitInfo m_Info)
        {
            IEnumerable<_ObjectQuantityUnitInfo> list = this.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == p_Info.BH);
            if (list.Count() == 0)
            {
                m_Info = null;
                return true;
            }
            else
            {
                m_Info = list.FirstOrDefault();
                if (m_Info.MC == p_Info.MC && m_Info.DW == p_Info.DW && m_Info.SCDJ == p_Info.SCDJ)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 是否重复
        /// </summary>
        /// <returns></returns>
        public bool RepeatInfo(_ObjectQuantityUnitInfo p_Info)
        {
            IEnumerable<_ObjectQuantityUnitInfo> list = this.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == p_Info.BH);
            if (list.Count() == 0)
            {
                return true;
            }
            else
            {
                _ObjectQuantityUnitInfo m_Info = list.FirstOrDefault();
                if (m_Info.MC == p_Info.MC && m_Info.DW == p_Info.DW && m_Info.SCDJ == p_Info.SCDJ)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual _List SubheadingsList
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region ----------------------------------子类扩展属性-------------------------------

        /// <summary>
        /// 填充项目树结构
        /// </summary>
        /// <param name="p_List"></param>
        public virtual void Fill(_List p_List)
        {
            p_List.Add(this.Parent.Directory);
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                item.Property.Fill(p_List);
            }
        }

        /// <summary>
        /// 设置当前OBJECTS的状态
        /// </summary>
        /// <param name="p_State"></param>
        public virtual void SetObjectState(EObjectState p_State)
        {
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                item.Property.SetObjectState(p_State);
            }
        }

        /// <summary>
        /// 对象中状态为p_State1修改为p_State2
        /// </summary>
        /// <param name="p_State1"></param>
        /// <param name="p_State2"></param>
        public virtual void ChangeObjectState(EObjectState p_State1, EObjectState p_State2)
        {
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                item.Property.ChangeObjectState(p_State1, p_State2);
            }
        }

        #endregion
    }
}
