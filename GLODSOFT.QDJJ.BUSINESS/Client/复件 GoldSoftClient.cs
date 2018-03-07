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
        public const int MaxCount      = 50;
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

                   

                    //int a = FixListObject.Login();
                    //ChannelServices.UnregisterChannel(channel);
                }
                catch (Exception)
                {
                    //throw;
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
            this.m_GlodSoftNetWork.Completed();

            string serverIp = CSystem.GetAppConfig("serverip");
            if (string.IsNullOrEmpty(serverIp))
            {
                //加密锁验证
                this.GlodSoftDiscern.Completed();
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
                            //this.ClientResult.Custom_IsOwner = false;
                            //return ResultConst.SERVER_CUSTOM_NO_INIT;
                        }

                        if (r == ResultConst.SERVER_SUCCESS)
                        { //执行成功
                            
                            this.CurrentCustom = info;

                            //加载 用户价格库开关
                            string jmLock = APP.GoldSoftClient.CurrentCustom.JMLOCK;

                            //绑定锁引用方式
                            //string wb_web = CSystem.GetAppConfig("wb");

                            //CustomBAL.BDsuoManager(wb_web, jmLock);
                           // CustomBAL.BDsuoManagerExtendInfo(wb_web, jmLock);

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
            catch(Exception ex) 
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
                        }else
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
                        int r = this.FixListObject.AWayLogin(this.GlodSoftDiscern.CurrNo,ref info);
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

    }
}
