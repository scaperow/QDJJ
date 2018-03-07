/*
 * 此对象实例应用程序中只有1份
 * 此对象包含当前应用程序的版本信息对象
 * 1.此应用程序程序运行后自动创建
 * 2.对加密狗的识别工作处理入口
 * 3.对网络身份验证的识别工作入口
 * 4.对网络信息收取数据提供方法
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoldSoft.QD_api;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using GOLDSOFT.SERVICES.IServicesObject;
using System.ComponentModel;
using System.Threading;
using GLODSOFT.QDJJ.BUSINESS;
using System.IO;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GoldSoft.CICM.UI;
using System.Data.SqlClient;

namespace GOLDSOFT.QDJJ.UI.Client
{

    /// <summary>
    /// 客户端完成验证激发事件(无论成功或失败)
    /// </summary>
    /// <param name="sender">事件激发源对象</param>
    /// <param name="ClientArgs">客户端参数</param>
    public delegate void ClientCompletedHandler(object sender, ClientArgs e);

    public class ClientArgs
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message = string.Empty;
        /// <summary>
        /// 当前操作结果
        /// </summary>
        public int Result;
    }

    /// <summary>
    /// 当前客户端应用程序
    /// </summary>
    public class GoldSoftClient
    {

        #region ------------------------常量-------------------------
        /// <summary>
        /// 最大使用次数
        /// </summary>
        public const int MaxCount = 50;
        /// <summary>
        /// 最大使用时间次数
        /// </summary>
        public const int MaxTimeCount = 45;
        #endregion

        /// <summary>
        /// 是否完成首次验证
        /// </summary>
        public bool IsFirstClient = false;

        /// <summary>
        /// (当前验证逻辑的操作结果)操作结果 （默认为客户端错误）
        /// </summary>
        public _ClientResult ClientResult;

        #region 调标平台
        /// <summary>
        /// 能否使用系统
        /// </summary>
        public bool Can_Use_System = true;
        /// <summary>
        /// 公开招标还是邀请招标 false为邀请招标
        /// </summary>
        public bool Invite_Publish = false;
        /// <summary>
        /// 调标家数
        /// </summary>
        public int TBJS = 0;
        /// <summary>
        /// 对方家数
        /// </summary>
        public int Other_Count = 0;
        /// <summary>
        /// 我方家数
        /// </summary>
        public int My_Count = 0;
        /// <summary>
        /// 上限控制价
        /// </summary>
        public float LimitedPrice;
        /// <summary>
        /// 措施上限
        /// </summary>
        public float LimitedCuoShi;
        /// <summary>
        /// 去高去低
        /// </summary>
        public float QuGaoQuDi;
        /// <summary>
        /// 调标方法 false 综合评估法  true 低价法
        /// </summary>
        public bool TBMethod;
        /// <summary>
        /// 每次调标的清单总数
        /// </summary>
        public int QDZJ_TB = 0;
        /// <summary>
        /// 措施项目合价
        /// </summary>
        public decimal CSXMHJ = 0.0m;
        /// <summary>
        /// 总造价
        /// </summary>
        public decimal ZZJ = 0;
        /// <summary>
        /// 本次扣除积分
        /// </summary>
        public int KCJF = 0;
        /// <summary>
        /// 调标
        /// </summary>
        public DataSet QDJJTB
        {
            get
            {
                string wb_web = CSystem.GetAppConfig("wb");
                return WebServiceHelper.InvokeMethod<DataSet>(wb_web, "getQDJJ_TB");
                //return this.getQDJJTB(); 
            }
        }
        /// <summary>
        /// 自动报价
        /// </summary>
        public DataSet ZDBJ
        {
            get
            {
                string wb_web = CSystem.GetAppConfig("wb");
                return WebServiceHelper.InvokeMethod<DataSet>(wb_web, "getZDBJ");
            }
        }
        /// <summary>
        /// 评标办法
        /// </summary>
        public string PBBF = "";
        /// <summary>
        /// 分部分项合计
        /// </summary>
        public decimal FBFXHJ = 0.0m;
        /// <summary>
        /// 上限控制
        /// </summary>
        public decimal SXKZHJ = 0.0m;
        /// <summary>
        /// 措施上限
        /// </summary>
        public decimal CSSXHJ = 0.0m;
        /// <summary>
        /// 空白区域清单个数
        /// </summary>
        public int SPACE_QY_COUNT = 0;
        /// <summary>
        /// 清单总数
        /// </summary>
        public int QD_COUNT = 0;
        /// <summary>
        /// A1区清单总数
        /// </summary>
        public int A1_COUNT = 0;
        /// <summary>
        /// A1区所占比例
        /// </summary>
        public float A1_BL = 0.0f;
        /// <summary>
        /// A1A值
        /// </summary>
        public float A1_A = 0.0f;
        /// <summary>
        /// A2区清单总数
        /// </summary>
        public int A2_COUNT = 0;
        /// <summary>
        /// A2区所占比例
        /// </summary>
        public float A2_BL = 0.0f;
        /// <summary>
        /// A2A值
        /// </summary>
        public float A2_A = 0.0f;
        /// <summary>
        /// A3区清单总数
        /// </summary>
        public int A3_COUNT = 0;
        /// <summary>
        /// A3区所占比例
        /// </summary>
        public float A3_BL = 0.0f;
        /// <summary>
        /// A3A值
        /// </summary>
        public float A3_A = 0.0f;
        /// <summary>
        /// A4区清单总数
        /// </summary>
        public int A4_COUNT = 0;
        /// <summary>
        /// A4区所占比例
        /// </summary>
        public float A4_BL = 0.0f;
        /// <summary>
        /// A4A值
        /// </summary>
        public float A4_A = 0.0f;
        /// <summary>
        /// A5区清单总数
        /// </summary>
        public int A5_COUNT = 0;
        /// <summary>
        /// A5区所占比例
        /// </summary>
        public float A5_BL = 0.0f;
        /// <summary>
        /// A5A值
        /// </summary>
        public float A5_A = 0.0f;
        /// <summary>
        /// B区清单总数
        /// </summary>
        public int B_COUNT = 0;
        /// <summary>
        /// B区所占比例
        /// </summary>
        public float B_BL = 0.0f;
        /// <summary>
        /// BA值
        /// </summary>
        public float B_A = 0.0f;
        /// <summary>
        /// C1区清单总数
        /// </summary>
        public int C1_COUNT = 0;
        /// <summary>
        /// C1区所占比例
        /// </summary>
        public float C1_BL = 0.0f;
        /// <summary>
        /// C1A值
        /// </summary>
        public float C1_A = 0.0f;
        /// <summary>
        /// C2区清单总数
        /// </summary>
        public int C2_COUNT = 0;
        /// <summary>
        /// C2区所占比例
        /// </summary>
        public float C2_BL = 0.0f;
        /// <summary>
        /// C2A值
        /// </summary>
        public float C2_A = 0.0f;
        /// <summary>
        /// C3区清单总数
        /// </summary>
        public int C3_COUNT = 0;
        /// <summary>
        /// C3区所占比例
        /// </summary>
        public float C3_BL = 0.0f;
        /// <summary>
        /// C3A值
        /// </summary>
        public float C3_A = 0.0f;
        /// <summary>
        /// C4区清单总数
        /// </summary>
        public int C4_COUNT = 0;
        /// <summary>
        /// C4区所占比例
        /// </summary>
        public float C4_BL = 0.0f;
        /// <summary>
        /// C4A值
        /// </summary>
        public float C4_A = 0.0f;
        /// <summary>
        /// 系数表名
        /// </summary>
        public string XS_TableName = "";
        /// <summary>
        /// 调标结果数据表
        /// </summary>
        public DataTable TB_RESULT = null;

        public _Business curBusiness = null;


        public DataTable TBJLTable
        {
            get
            {
                DataTable temp = new DataTable();
                temp.Columns.Add(new DataColumn("XMMC"));
                temp.Columns.Add(new DataColumn("JIMSH"));
                temp.Columns.Add(new DataColumn("ZCDW"));
                temp.Columns.Add(new DataColumn("PBBF"));
                temp.Columns.Add(new DataColumn("ZZJ"));
                temp.Columns.Add(new DataColumn("CSXMF"));
                temp.Columns.Add(new DataColumn("FBFX"));
                temp.Columns.Add(new DataColumn("KZJ"));
                temp.Columns.Add(new DataColumn("CSSX"));
                temp.Columns.Add(new DataColumn("TBJS"));
                temp.Columns.Add(new DataColumn("DFJS"));
                temp.Columns.Add(new DataColumn("QGQD"));
                temp.Columns.Add(new DataColumn("FA"));
                temp.Columns.Add(new DataColumn("QJF"));
                temp.Columns.Add(new DataColumn("KCJF"));
                temp.Columns.Add(new DataColumn("SBYY"));
                temp.Columns.Add(new DataColumn("CZSJ"));
                return temp;
            }
        }
        #endregion

        public string ErrorInfmation = string.Empty;
        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event ClientCompletedHandler ClientCompleted;

        /// <summary>
        /// 每次完成一个模块验证都会激发的时间无论成功失败
        /// </summary>
        public void OnClientCompleted(object sender, ClientArgs e)
        {
            //成功验证后获取信息

            if (ClientCompleted != null)
            {
                this.ClientCompleted(sender, e);
            }
        }

        /// <summary>
        /// 当前可用次数
        /// </summary>
        public int TryCount = 3;

        /// <summary>
        /// 获取或设置当前用户信息
        /// </summary>
        private CEntitySuomanager m_CurrentCustom = null;

        /// <summary>
        /// 获取或设置当前用户信息
        /// </summary>
        public CEntitySuomanager CurrentCustom
        {
            get
            {
                return this.m_CurrentCustom;
            }
            set
            {
                this.m_CurrentCustom = value;
            }
        }
        /// <summary>
        /// 基础效验类
        /// </summary>
        private _GlodSoftDiscern m_GlodSoftDiscern = null;

        /// <summary>
        /// 基础效验信息
        /// </summary>
        public _GlodSoftDiscern GlodSoftDiscern
        {
            get
            {
                return this.m_GlodSoftDiscern;
            }
            set
            {
                this.GlodSoftDiscern = value;
            }
        }

        /// <summary>
        /// 网络识别 
        /// </summary>
        private _GlodSoftNetWork m_GlodSoftNetWork = null;

        /// <summary>
        /// 获取或设置网络识别
        /// </summary>
        public _GlodSoftNetWork GlodSoftNetWork
        {
            get
            {
                return this.m_GlodSoftNetWork;
            }
            set
            {
                this.m_GlodSoftNetWork = value;
            }
        }

        /// <summary>
        /// 构造后自动开启线程处理
        /// </summary>
        public GoldSoftClient()
        {
            this.m_GlodSoftDiscern = new _GlodSoftDiscern(this);
            this.m_GlodSoftNetWork = new _GlodSoftNetWork(this);
            ClientResult = new _ClientResult();
            CreateInstance();
        }

        public IFixListObject FixListObject = null;

        public void CreateInstance()
        {
            if (FixListObject == null)
            {
                try
                {
                    TcpClientChannel channel = new TcpClientChannel();
                    ChannelServices.RegisterChannel(channel, false);
                    FixListObject = (IFixListObject)Activator.GetObject(typeof(IFixListObject), "tcp://127.0.0.1:6957/IFixListObject");
                    //FixListObject = (IFixListObject)Activator.GetObject(typeof(IFixListObject), "tcp://127.0.0.1:6957/IFixListObject");


                    CEntitySuomanager info = null;
                    int r = this.FixListObject.Login(this.GlodSoftDiscern.CurrNo, ref info);

                    //int a = FixListObject.Login();
                    //ChannelServices.UnregisterChannel(channel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// 向服务提交保存数据
        /// </summary>
        /// <returns></returns>
        public void SaveProeject(string p_ProjectName)
        {
            try
            {
                if (this.FixListObject != null)
                {
                    //无论何时此方法调用 异常忽略
                    this.FixListObject.SaveProeject(this.GlodSoftDiscern.CurrNo, p_ProjectName);
                }

            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 每次打开软件的时候调用(首次调用)
        /// 返回可用的功能号信息
        /// 返回结果函数
        /// </summary>
        /// <returns></returns>
        public void FirstLogin()
        {
            //网络验证
            int netStatus = this.m_GlodSoftNetWork.Completed();

            string serverIp = CSystem.GetAppConfig("serverip");
            if (string.IsNullOrEmpty(serverIp))
            {
                //加密锁验证
                this.GlodSoftDiscern.Completed();

                //if (this.ClientResult.IsUseNet)
                //{
                //    string wb_web = CSystem.GetAppConfig("wb");
                //    DataTable dtsuoManager = WebServiceHelper.InvokeMethod<DataTable>(wb_web, "getSuoManagerInfoByJmLock", APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
                //    if (dtsuoManager.Rows.Count <= 0)
                //        this.Can_Use_System = false;
                //}


            }
            else
            {
                if (this.GlodSoftDiscern.Completed(serverIp, 1086) != 0)
                {
                    throw new Exception("服务器不可用!");
                }
            }

            //功能性验证
            this.StandCompleted();
            //加密狗验证
            //this.GlodSoftDiscern.Completed();

        }

        /// <summary>
        /// 常规验证 在网络验证与硬件验证之后 (以后要添加验证逻辑请补充)
        /// </summary>
        public void StandCompleted()
        {
            //加密狗是否拥有正常的状态
        }

        /// <summary>
        /// 客户信息验证（发生在Login之后 必须正常）
        /// </summary>
        public void CustomCompleted()
        {
            //加密狗是否拥有正常的状态
            //1.空客户信息(开通后首次验证)
            //2.客户使用权限验证
            //是否第一次登陆
            if (this.CurrentCustom.ISFIRST.Trim().Equals("0"))
            {
                //当前客户是首次
                this.ClientResult.Custom_IsFirst = true;
            }
            else { this.ClientResult.Custom_IsFirst = false; }
            if (this.CurrentCustom.STATUS.Trim().Equals("未开通"))
            {
                //如果是未开通状态，则视为升级的客户
                //if (!this.ClientResult.Custom_IsFirst)
                //{
                //    APP.GoldSoftClient.ClientResult.IsChangeHandle = true;
                //}
                this.ClientResult.Custom_IsFirst = true;
            }

            //是否可用
            if (this.CurrentCustom.ISPASS.Trim().Equals("0"))
            {
                ///失败原因
                this.ClientResult.Custom_CanUse = true;
            }
            else { this.ClientResult.Custom_CanUse = false; }
        }

        /// <summary>
        /// 登录系统(首次登陆调用)
        /// 1.判断加密狗是否正常工作
        /// 2.判断网络是否正常工作
        /// </summary>
        /// <returns></returns>
        public int Login()
        {
            ///是否使用离线逻辑(默认为True)
            bool bIsOffline = true;
            try
            {
                //逻辑变更 
                //0.判断能否直接使用
                //1.判断是否联网状态
                //2 如果是联网状态 获取同步用户数据
                //3.验证登录使用逻辑
                if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess)
                {

                    //有网络且完全通过
                    if (this.FixListObject != null)
                    {
                        //调用网络数据同步逻辑

                        CEntitySuomanager info = null;

                        int r = this.FixListObject.Login(this.GlodSoftDiscern.CurrNo, ref info);


                        //没有用户数据
                        if (r == ResultConst.SERVER_CUSTOM_NO_INIT)
                        {
                            //非法的加密锁
                            this.ClientResult.Custom_IsOwner = false;
                            this.Can_Use_System = false;
                            return ResultConst.SERVER_CUSTOM_NO_INIT;

                        }

                        if (r == ResultConst.SERVER_SUCCESS)
                        { //执行成功
                            this.Can_Use_System = true;
                            this.CurrentCustom = info;

                            string wb_web = CSystem.GetAppConfig("wb");
                            //TODO:判斷積分問題
                            //int jifen = WebServiceHelper.InvokeMethod<int>(wb_web, "getJiFenJL", APP.GoldSoftClient.CurrentCustom.JMLOCK);

                            //if (jifen < 0)
                            //{
                            //    return -11;
                            //    //MsgBox.Alert("由于您的积分为负数，软件不能使用！请先购买积分！");
                            //    //Application.Exit();
                            //}

                            //加载 用户价格库开关
                            string jmLock = APP.GoldSoftClient.CurrentCustom.JMLOCK;

                            //绑定锁引用方式
                            //string wb_web = CSystem.GetAppConfig("wb");

                            CustomBAL.BDsuoManager(wb_web, jmLock);
                            CustomBAL.BDsuoManagerExtendInfo(wb_web, jmLock);

                            this.ErrorInfmation = this.FixListObject.GetErrorInfmation;
                            this.ClientResult.Result = _ClientResult.Client_Result_Success;
                            //同步更新数据 清理
                            this.ClientResult.State = this.CurrentCustom.STATUS;
                            this.ClientResult.Fun = ToolKit.ParseInt(this.CurrentCustom.VERSION_SUBMIT);
                            //此处进行客户信息验证
                            this.CustomCompleted();


                            info.USE_COUNT = this.ClientResult.UseCount;
                            info.USE_TIME = this.ClientResult.DateCount;
                            //同步数据
                            bIsOffline = !this.FixListObject.setSuoCountAndTime(info);
                            if (!bIsOffline)
                            {
                                this.ClientResult.UseCount = 0;
                                this.ClientResult.DateCount = 0;
                                //重写
                                this.GlodSoftDiscern.WriteHandle(this.ClientResult.ToHandleString());
                                bIsOffline = false;
                            }
                        }
                        else
                        {
                            bIsOffline = true;
                        }
                    }
                }
                if (bIsOffline)
                {

                    this.ClientResult.UseCount += 1;
                    //进行一次离线记录
                    this.GlodSoftDiscern.WriteHandle(this.ClientResult.ToHandleString());
                    APP.GoldSoftClient.ClientResult.Custom_CanUse = true;
                }

                return ResultConst.SERVER_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ErrorInfmation = ex.Message;
                return ResultConst.SERVER_SERVER_ERROR;
            }
        }

        /// <summary>
        /// 登录系统(首次登陆调用)
        /// 1.判断加密狗是否正常工作
        /// 2.判断网络是否正常工作
        /// </summary>
        /// <returns></returns>
        public int ALogin()
        {
            ///是否使用离线逻辑(默认为True)
            bool bIsOffline = true;
            try
            {
                //逻辑变更 
                //0.判断能否直接使用
                //1.判断是否联网状态
                //2 如果是联网状态 获取同步用户数据
                //3.验证登录使用逻辑
                if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess)
                {
                    //有网络且完全通过
                    if (this.FixListObject != null)
                    {
                        //调用网络数据同步逻辑
                        CEntitySuomanager info = null;
                        int r = this.FixListObject.Login(this.GlodSoftDiscern.CurrNo, ref info);
                        //没有用户数据
                        if (r == ResultConst.SERVER_CUSTOM_NO_INIT)
                        {
                            //非法的加密锁
                            //bIsOffline = true; 
                            //return ResultConst.SERVER_CUSTOM_NO_INIT;
                        }

                        if (r == ResultConst.SERVER_SUCCESS)
                        {
                            this.CurrentCustom = info;
                            this.ErrorInfmation = this.FixListObject.GetErrorInfmation;
                            this.ClientResult.Result = _ClientResult.Client_Result_Success;
                            //同步更新数据 清理
                            //不再处理使用次数
                            //this.ClientResult.UseCount += this.CurrentCustom.USE_COUNT;
                            //this.ClientResult.DateCount += 1;
                            this.ClientResult.State = this.CurrentCustom.STATUS;
                            this.ClientResult.Fun = long.Parse(this.CurrentCustom.VERSION_SUBMIT);

                            this.CustomCompleted();

                            //同步数据
                            info.USE_COUNT = this.ClientResult.UseCount;
                            info.USE_TIME = this.ClientResult.DateCount;
                            bIsOffline = !this.FixListObject.setSuoCountAndTime(info);

                            if (!bIsOffline)
                            {
                                this.ClientResult.UseCount = 0;
                                this.ClientResult.DateCount = 0;
                                //重写
                                this.GlodSoftDiscern.WriteHandle(this.ClientResult.ToHandleString());
                                //this.FixListObject.TryUpDate(ref info);
                                bIsOffline = false;
                            }
                        }
                        else
                        {
                            bIsOffline = true;
                        }
                    }

                }

                if (bIsOffline)
                {
                    this.ClientResult.DateCount += 1;
                    //进行一次离线记录
                    this.GlodSoftDiscern.WriteHandle(this.ClientResult.ToHandleString());
                }

                return ResultConst.SERVER_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ErrorInfmation = ex.Message;
                return ResultConst.SERVER_ERROR;
            }
        }



        /*public int Login()
        {
            try
            {
                //逻辑变更 
                //1.判断是否联网状态
                //2 如果是联网状态 获取同步用户数据
                //3.验证登录使用逻辑
                if (this.FixListObject != null)
                {
                    //判断加密狗是否正常工作
                    int result = this.GlodSoftDiscern.Completed();
                    if (_GlodSoftDiscern.TRY_SUCCESS == result)
                    {
                        //本地加密狗验证
                        CEntitySuomanager info = null;
                        int r = this.FixListObject.Login(this.GlodSoftDiscern.CurrNo, ref info);
                        this.CurrentCustom = info;
                        this.ErrorInfmation = this.FixListObject.GetErrorInfmation;
                        this.ClientResult.Result = _ClientResult.Client_Result_Success;

                        return r;
                    }
                    else if (_GlodSoftDiscern.TRY_ERROR_NOFUNCTION == result)
                    {
                        this.ErrorInfmation = "没有此功能，请联系售后人员。";
                        int nor = ResultConst.SERVER_ERROR;
                        this.ClientResult.Result = _ClientResult.Client_Result_Error;
                        return nor;
                    }
                    else
                    {
                        this.ErrorInfmation = "没有找到加密狗！";
                        int nor = ResultConst.SERVER_ERROR;
                        this.ClientResult.Result = _ClientResult.Client_Result_Error;
                        return nor;
                    }

                }
                return -1;
            }
            catch (Exception ex)
            {
                this.ErrorInfmation = "服务没有找到";
                return ResultConst.SERVER_ERROR;
            }
        }*/

        /// <summary>
        /// 常规验证(当前类中 循环调用)
        /// </summary>
        /// <returns></returns>
        public int AWayLogin()
        {
            try
            {
                if (this.FixListObject != null)
                {

                    if (_GlodSoftDiscern.TRY_SUCCESS == this.GlodSoftDiscern.Completed())
                    {
                        //本地加密狗验证
                        CEntitySuomanager info = null;
                        int r = this.FixListObject.AWayLogin(this.GlodSoftDiscern.CurrNo, ref info);
                        APP.GoldSoftClient.m_CurrentCustom = info;
                        this.ErrorInfmation = this.FixListObject.GetErrorInfmation;
                        return r;
                    }
                    else
                    {
                        this.ErrorInfmation = "没有找到加密狗！";
                        int nor = ResultConst.SERVER_ERROR;
                        return nor;
                    }

                }
                return -1;
            }
            catch
            {
                this.ErrorInfmation = "服务没有找到";
                return ResultConst.SERVER_ERROR;
            }
        }

        /// <summary>
        /// 提交当前用户信息
        /// </summary>
        /// <returns></returns>
        public int TryUpdateCustomer(CEntitySuomanager p_Info)
        {
            try
            {
                if (this.FixListObject != null)
                {

                    string str = this.FixListObject.TryUpDate(ref p_Info);

                    if (str != "-1" && str != "-2")
                    {
                        this.CurrentCustom = p_Info;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                //出现异常提示服务端口通信失败
                //return _GlodSoftNetWork.TRY_SERVER_ERROR;
                return 1;
            }
        }

        /// <summary>
        /// 获取服务器数据
        /// </summary>
        /// <param name="Keys">服务器上数据库【QDJJ_Infomation】中表【ZY_Table】的【Keys】字段</param>
        /// <returns>服务器上数据库【QDJJ_Infomation】中的数据</returns>
        public DataSet GetServiceData(string Keys)
        {
            try
            {
                if (this.FixListObject != null)
                {
                    return this.FixListObject.get_GC_Information(Keys);
                }
                return new DataSet();
            }
            catch (Exception ex)
            {
                //出现异常提示服务端口通信失败
                //return _GlodSoftNetWork.TRY_SERVER_ERROR;
                return null;
            }
        }


        //public DataSet getQDJJTB()
        //{
        //    DataSet ds = new DataSet();

        //    string wb_web = CSystem.GetAppConfig("wb");
        //    APP.GoldSoftClient.QDJJTB = WebServiceHelper.InvokeMethod<DataSet>(wb_web, "getQDJJ_TB");

        //    //SqlConnection conn = new SqlConnection("Data Source=117.34.66.251,32143;Initial Catalog=QDJJ_TB;User ID=sa;Password=jjrj-13689209960;Max Pool Size = 512;");
        //    //try
        //    //{

        //    //    conn.Open();
        //    //    SqlCommand cmd = new SqlCommand("select * from AZHI", conn);
        //    //    SqlDataAdapter da = new SqlDataAdapter(cmd);

        //    //    da.Fill(ds, "AZHI");

        //    //    cmd.CommandText = "select * from BQXSB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "BQXSB");

        //    //    cmd.CommandText = "select * from BZHI";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "BZHI");

        //    //    cmd.CommandText = "select * from CSXSB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "CSXSB");

        //    //    cmd.CommandText = "select * from JFJJB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "JFJJB");

        //    //    cmd.CommandText = "select * from KZB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "KZB");

        //    //    cmd.CommandText = "select * from QSAZHI";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QSAZHI");

        //    //    cmd.CommandText = "select * from QSBZHI";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QSBZHI");

        //    //    cmd.CommandText = "select * from QUHFB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QUHFB");

        //    //    cmd.CommandText = "select * from QUYUZI";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QUYUZI");

        //    //    cmd.CommandText = "select * from QWTB10";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB10");

        //    //    cmd.CommandText = "select * from QWTB11";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB11");

        //    //    cmd.CommandText = "select * from QWTB12";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB12");

        //    //    cmd.CommandText = "select * from QWTB13";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB13");

        //    //    cmd.CommandText = "select * from QWTB14";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB14");

        //    //    cmd.CommandText = "select * from QWTB15";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB15");

        //    //    cmd.CommandText = "select * from QWTB3";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB3");

        //    //    cmd.CommandText = "select * from QWTB4";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB4");

        //    //    cmd.CommandText = "select * from QWTB5";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB5");

        //    //    cmd.CommandText = "select * from QWTB6";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB6");

        //    //    cmd.CommandText = "select * from QWTB7";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB7");

        //    //    cmd.CommandText = "select * from QWTB8";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB8");

        //    //    cmd.CommandText = "select * from QWTB9";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "QWTB9");

        //    //    cmd.CommandText = "select * from SHUIJ";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "SHUIJ");

        //    //    cmd.CommandText = "select * from TBCSB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "TBCSB");

        //    //    cmd.CommandText = "select * from TBJLB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "TBJLB");

        //    //    cmd.CommandText = "select * from TBKZ";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "TBKZ");

        //    //    cmd.CommandText = "select * from TBKZJLB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "TBKZJLB");

        //    //    cmd.CommandText = "select * from ZIB";
        //    //    da.SelectCommand = cmd;
        //    //    da.Fill(ds, "ZIB");
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    conn.Close();
        //    //    throw;
        //    //}

        //    return ds;
        //}

    }
}
