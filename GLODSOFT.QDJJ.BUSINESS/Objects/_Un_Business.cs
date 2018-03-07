/*
    单位工程的具体业务类型(非容器类型)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.DATA;
using System.IO;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Un_Business:_BusNotContainer
    {
        public _Un_Business()
            : base()
        {

            //当前工作流类型为项目
            this.WorkFlowType = EWorkFlowType.UnitProject;            
        }

        /// <summary>
        /// 确认创建一个已经存在单位工程数据对象
        /// </summary>
        /// <param name="p_info"></param>
        public override void Create(_COBJECTS p_info)
        {
            this.Current = p_info;
            base.Create(p_info);
            this.InitDataObject(p_info);
            this.Current.StructSource.ModelProject.Add(p_info);
           
        }

        public override void EndCreate()
        {
            base.EndCreate();
            this.doLoadData();
        }

        /// <summary>
        /// 为新的单位工程初始化数据
        /// </summary>
        private void doLoadData()
        {
            _Entity_SubInfo info;
            //分部分项数据
            info = new _Entity_SubInfo();
            info.XMBM = "单位工程";
            info.UnID = this.Current.ID;
            info.EnID = this.Current.PID;
            info.Deep = 3;
            info.SSLB = 0;
            this.Current.StructSource.ModelSubSegments.Add(info);
            //措施项目数据
            info = new _Entity_SubInfo();
            info.UnID = this.Current.ID;
            info.EnID = this.Current.PID;
            info.XMBM = "措施项目";
            info.Deep = 3;
            info.SSLB = 1;
            this.Current.StructSource.ModelMeasures.Add(info);

            _UnitProject unit = this.Current as _UnitProject;
            //初始化措施项目
            _Mothod_Measures met = new _Mothod_Measures(this,unit, info);
            met.Load();
            //初始化汇总分析
            _Method_Metaanalysis hmet = new _Method_Metaanalysis(unit);
            hmet.Init();
            //其他项目-模板
            _Method_OtherProject omet = new _Method_OtherProject(this,unit);
            omet.Init();

            //this.Current.Property.Report.LoadReport(APP.Cache.BaseReport);

        }

        /// <summary>
        /// 从文件加载到当前项目中
        /// </summary>
        /// <param name="p_files">要加载的文件对象</param>
        public override CResult Load(_Files p_files)
        {
            CResult result = new CResult(false);
            try
            {
                _UnitProject cu = CFiles.BinaryDeserialize(p_files.FullName) as _UnitProject;
                this.Current = cu;
                cu.Files = p_files;
                //初始化数据对象
                this.InitDataObject(this.Current);
                result.Success = true;
                return result;
            }
            catch
            {
                result.Success = false;
                result.ErrorInformation = _Prompt.打开文件出错;
                return result;
            }
        }

        public override void Load(_COBJECTS p_info)
        {
            base.Load(p_info);
            this.Current = p_info;
            
            //TODO:打开单位工程无统计数据
            int objkey = this.Current.ObjectKey;
            p_info.StructSource.SetNewFiled(ref objkey, p_info as _UnitProject);

            //初始化数据对象
            this.InitDataObject(this.Current);
        }

        /// <summary>
        /// 初始化单位工程
        /// </summary>
        /// <param name="p_info"></param>
        public override void InitDataObject(GOLDSOFT.QDJJ.COMMONS._COBJECTS p_Info)
        {
            //初始化属性
            p_Info.Property.DLibraries.FixedLibrary.Rule = p_Info.DEGZ;
            p_Info.Property.DLibraries.FixedLibrary.LibName = p_Info.DELibName;
            p_Info.Property.DLibraries.AtlasGallery.LibName = p_Info.TJLibName;
            p_Info.Property.DLibraries.ListGallery.Rule = p_Info.QDGZ;
            p_Info.Property.DLibraries.ListGallery.LibName = p_Info.QDLibName;
            //_Library
            //初始化库
            p_Info.Property.DLibraries.Init(APP.Application);
            //初始化新的临时对象（不参与序列化此对象每次使用需要呗初始化）
            p_Info.Property.Temporary = new _Temporary();
            //默认同步临时库对象
            p_Info.Property.Temporary.Libraries = p_Info.Property.DLibraries.Copy();
            p_Info.Property.Temporary.Libraries.Init(APP.Application);
            p_Info.Property.IncreaseCosts.init();//初始化子目取费
            _UnitProject m_UnitProject = p_Info as _UnitProject;
            if (m_UnitProject != null)
            {
                if (m_UnitProject.StructSource.ModelUnitFee.Rows.Count == 0 || m_UnitProject.StructSource.ModelPSubheadingsFee.Rows.Count == 0)
                {
                    _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(m_UnitProject);
                    m_Methods_ParamsSeting.Init();
                    DataRow[] m_MRGCQF = m_UnitProject.StructSource.ModelUnitFee.Select(string.Format("GCLB='{0}'", m_UnitProject.ProType));
                    if (m_MRGCQF.Length > 0)
                    {
                        m_UnitProject.ProType = m_MRGCQF[0]["GCLB"].ToString();
                    }
                }
            }
        }


        /// <summary>
        /// 计算汇总当前项目数据
        /// </summary>
        public override void Calculate()
        {
            //计算数据
            _Project_Statistics sta = null;
            //循环计算
            {
               // if (this.Current.IsCalculated)
                {
                    sta = new _Project_Statistics(this.Current as _UnitProject,this);
                    //计算，合并新的数据集合
                    sta.Calculate();
                }
            }
        }

        public override void FastCalculate()
        {
            if (this.Current.NeedCalculate)
            {
               
                var statistics = new _Project_Statistics(this.Current as _UnitProject,this);
                statistics.CalculateWithouSubsegment();

                this.Current.NeedCalculate = false;
               
            }
        }
    }
}
