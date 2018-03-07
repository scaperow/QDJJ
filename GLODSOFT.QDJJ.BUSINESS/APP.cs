/**********************************************
    全局应用程序函数类(当前应用程序的业务处理)
    包含所有的业务处理
 *********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.DATA;
using System.IO;
using GOLDSOFT.QDJJ.UI.Client;
using GoldSoft.CICM.UI;
using ZiboSoft.Commons.Common;
using System.Data;
using GoldSoft.QD_api;
using GOLDSOFT.QDJJ.COMMONS.ZBS;



namespace GLODSOFT.QDJJ.BUSINESS
{
    public static class APP
    {

        public static int JJJC = 1 ; //1: 调整计价  2:定额计价  3: 市场计价

        public static 建设项目 CurrentJSXM;

        #region------------------------------------保留的对象属性------------------------------------
        public static string FileType = "";

        public static bool SHOW_BZ = false;//工程信息中的备注列是否显示

        private static bool gcxxKH = false;

        public static bool GcxxKH
        {
            get { return APP.gcxxKH; }
            set { APP.gcxxKH = value; }
        }

        public static _Business bus;
        private static bool jzbx_pwd = false;

        public static bool Jzbx_pwd
        {
            get { return APP.jzbx_pwd; }
            set { APP.jzbx_pwd = value; }
        }

        public static bool countDIV = true;

        /// <summary>
        /// 云价格库共享开关
        /// </summary>
        private static bool m_GXKG = false;

        /// <summary>
        /// 获取或设置：云价格库共享开关
        /// </summary>
        public static bool GXKG
        {
            get { return APP.m_GXKG; }
            set { APP.m_GXKG = value; }
        }

        /// <summary>
        /// 组价方案存储与引用方式 共享开关（预留 为实现）
        /// </summary>
        private static bool m_ZGFAKG = false;

        public static bool ZGFAKG
        {
            get { return APP.m_ZGFAKG; }
            set { APP.m_ZGFAKG = value; }
        }
        /// <summary>
        /// 补充清单，定额，材料与引用方式 共享开关 （预留 为实现）
        /// </summary>
        private static bool m_BCQDKG = false;

        public static bool BCQDKG
        {
            get { return APP.m_BCQDKG; }
            set { APP.m_BCQDKG = value; }
        }

        /// <summary>
        /// 当前的应用程序对象
        /// </summary>
        public static _Application Application;
        public const string Ver = "Ver 1.0";
        /// <summary>
        /// 用于处理快速取值的属性操作集合
        /// </summary>
        //public static _General General;

        /// <summary>
        /// 用于处理全局应用程序中需要调用的方法（此方法在应用程序初始化完毕后创建）
        /// </summary>
        public static _Method Methods = null;

        private static _UnInformation m_UnInformation = null;
        /// <summary>
        /// 工程信息
        /// </summary>
        public static _UnInformation UnInformation
        {
            get { return APP.m_UnInformation; }
            set { APP.m_UnInformation = value; }
        }
        /// <summary>
        /// 缓存对象
        /// </summary>
        public static _Cache Cache = null;

        /// <summary>
        /// 创建需要保存的全局数据对象
        /// </summary>
        public static _DataObjects DataObjects = null;

        /// <summary>
        /// 当前工作流的业务对象(此对象在应用程序打开时候自动创建 需要以后在具体业务中重新初始化)
        /// </summary>
        public static _WorkFlows WorkFlows = null;
        /// <summary>
        /// 默认取的机器号
        /// </summary>
        public static string MachineNumber = null;//ZiboSoft.Commons.Common.CApplications.GetMNum();

        /// <summary>
        /// 用户价格库
        /// </summary>
        private static _UserPriceLibrary m_UserPriceLibrary = null;

        /// <summary>
        /// 获取或设置：用户价格库
        /// </summary>
        public static _UserPriceLibrary UserPriceLibrary
        {
            get { return APP.m_UserPriceLibrary; }
            set { APP.m_UserPriceLibrary = value; }
        }
        /// <summary>
        /// 补充人才机
        /// </summary>
        private static _RepairQuantityUnit m_RepairQuantityUnit = null;
        /// <summary>
        /// 获取或设置：补充人才机
        /// </summary>
        public static _RepairQuantityUnit RepairQuantityUnit
        {
            get { return APP.m_RepairQuantityUnit; }
            set { APP.m_RepairQuantityUnit = value; }
        }

        /// <summary>
        /// 云价格库
        /// </summary>
        private static _InformationPriceLibrary m_InformationPriceLibrary = null;

        /// <summary>
        /// 获取或设置：云价格库
        /// </summary>
        public static _InformationPriceLibrary InformationPriceLibrary
        {
            get { return APP.m_InformationPriceLibrary; }
            set { APP.m_InformationPriceLibrary = value; }
        }

        public static GoldSoftClient GoldSoftClient = null;
        #region --------------------初始化应用程序过程----------------------
        /// <summary>
        /// 初始化当前应用程序(为应用程序的前期数据做准备)
        /// </summary>
        public static void Init()
        {

            APP.GoldSoftClient = new GoldSoftClient();
            APP.Application = new _Application();
            //为应用的准备工作流(无论何时当一个新业务开始的时候必须初始化)
            APP.WorkFlows = new _WorkFlows();
            APP.UserPriceLibrary = new _UserPriceLibrary();
            APP.RepairQuantityUnit = new _RepairQuantityUnit();
            APP.InformationPriceLibrary = new _InformationPriceLibrary();
            APP.UnInformation = new _UnInformation();
            APP.MachineNumber = ToolKit.GetIndentify(); 
        }

        /// <summary>
        /// 初始化完成后调用的方法(依赖前期数据的操作
        /// </summary>
        public static void InitCompatle()
        {
            //加载数据对象
            APP.DataObjects = _DataObjects.Load(APP.Application.Global.AppFolder);
            //加载缓存对象
            APP.Cache = new _Cache(APP.Application.Global.AppFolder);
            //先设置数据接口在进行初始化
            APP.Application.GlobalData.Init();
            //全局方法集合(最后调用)
            APP.Methods = new _Method();
            //完成后同步通用层的对象
            _Common.Application = APP.Application;
            //初始化全局数据用户价格库对象集
            string a = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
            APP.UserPriceLibrary.Load();
            APP.RepairQuantityUnit.Load();
            APP.UnInformation.Init();
            APP.InformationPriceLibrary.Load();
        }

        /// <summary>
        /// 当前应用程序关闭调用
        /// </summary>
        public static void Close()
        {
            //if (APP.GoldSoftClient.GlodSoftDiscern.CurrNo == null) return;
            ////保存全局对象
            //APP.UserPriceLibrary.Save();
            //APP.RepairQuantityUnit.Save();
        }
     
     
        #endregion

        #endregion
    }
}
