/*
    此类中定义了应用程序中使用的全部方法(全局函数)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.DATA;
using System.IO;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Method
    {  
        /// <summary>
        ///公开的为CObject对象使用前调用的初始化对象(此前所有初始化数据对象的地方统一在此处调用) 
        /// </summary>
        /// <param name="p_obj">业务对象</param>
        public void Init(_COBJECTS p_Info)
        {
            if (p_Info is _UnitProject)
            {
                _UnitProject info = p_Info as _UnitProject;
                this.Init(info);
                return;
            }

            if (p_Info is _Projects)
            {
                _Projects info = p_Info as _Projects;
                this.Init(info);
                return;
            }
            if (p_Info is _Engineering)
            {
                _Engineering info = p_Info as _Engineering;
                this.Init(info);
                return;
            }
        }

        /// <summary>
        ///公开的为单位对象使用前调用的初始化对象(此前所有初始化数据对象的地方统一在此处调用) 
        /// </summary>
        /// <param name="p_obj">业务对象</param>
        public void Init(_UnitProject p_Info)
        {
            //p_Info.Application = APP.Application;
            //if (p_Info.Property == null) p_Info.Property = new _Un_Property(p_Info);
            //初始化库信息
            //p_Info.Property.DLibraries.Init(APP.Application);

            #region --------------不参与序列化的操作--------------------
            //初始化新的临时对象（不参与序列化此对象每次使用需要呗初始化）
            p_Info.Property.Temporary = new _Temporary();
            //默认同步临时库对象
            p_Info.Property.Temporary.Libraries = p_Info.Property.DLibraries.Copy();
            p_Info.Property.Temporary.Libraries.Init(APP.Application);
            #endregion
            //初始化参数信息
            //p_Info.Property.ParameterSettings.Create();
            //初始化措施项目
            //p_Info.Property.MeasuresProject.Load();
            //初始化子目增加费
            //p_Info.Property.IncreaseCosts.init();
            //初始化其他项目
            //p_Info.Property.OtherProject.init();
            //初始化汇总分析
            //p_Info.Property.Metaanalysis.Init();
            //工程信息
            //p_Info.Property.UnInformation.Init();
            //初始化报表对象
            //p_Info.Property.Report.LoadReport(APP.Cache.BaseReport);
        }

        /// <summary>
        ///公开的为CObject对象使用前调用的初始化对象(此前所有初始化数据对象的地方统一在此处调用) 
        /// </summary>
        /// <param name="p_obj">业务对象</param>
        public void Init(_Projects p_Info)
        {
            p_Info.Application = APP.Application;
            //初始化报表对象
            //p_Info.Property.Report.LoadReport(APP.Cache.BaseReport);
        }

        /// <summary>
        ///公开的为CObject对象使用前调用的初始化对象(此前所有初始化数据对象的地方统一在此处调用) 
        /// </summary>
        /// <param name="p_obj">业务对象</param>
        public void Init(_Engineering p_Info)
        {
            p_Info.Application = APP.Application;
        }
    }
}
