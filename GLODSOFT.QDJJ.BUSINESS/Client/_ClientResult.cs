/*
 * 客户端结果验证实体
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 提供客户端口验证的结果类
    /// </summary>
    public class _ClientResult
    {
        #region --------------------常量-------------------
        /// <summary>
        /// 客户端验证失败
        /// </summary>
        public const int Client_Result_Error = -1;
        /// <summary>
        /// 客户端验证成功
        /// </summary>
        public const int Client_Result_Success = 0;

        /// <summary>
        /// 客户端没有初始化
        /// </summary>
        public const int Client_Result_NoInit = 1;

        #endregion

        /// <summary>
        /// 操作结果默认为失败
        /// </summary>
        public int Result   = _ClientResult.Client_Result_Error;



        #region ------------------公开属性-------------------------
        //网络状态
        //功能函数
        //加密锁号
       
        /// <summary>
        /// 网络服务器是否正常
        /// </summary>
        private bool _IsUseNet = false;
        /// <summary>
        /// 是否已经初始化的加密狗
        /// </summary>
        private bool _IsOwenr = false;

        /// <summary>
        /// 是否正常读取加密狗
        /// </summary>
        private bool _IsReadHeandle = false;

        /// <summary>
        /// 有效性验证(是否有效的加密狗)
        /// </summary>
        private bool _IsPassValie = false;

        /// <summary>
        /// 是否加入网络验证计划
        /// </summary>
        private bool _Custom_IsOwner = false;
        /// <summary>
        /// 客户验证是否第一次登陆系统
        /// </summary>
        private bool _Custom_IsFirst = false;
        /// <summary>
        /// 客户效验是否可用的用户
        /// </summary>
        private bool _Custom_CanUse = false; 

        public long UseCount = 1; //使用次数
        public long DateCount = 1;//时间次数
        public long Time = 0; //时间戳
        public long Fun = 1; //功能号
        public string State = string.Empty;//状态是未开通、挂失、终止、过期

        /// <summary>
        /// 是否加入网络验证计划
        /// </summary>
        public bool Custom_IsOwner
        {
            get
            {
                return _Custom_IsOwner;
            }
            set
            {
                this._Custom_IsOwner = value;
            }
        }

        /// <summary>
        /// 客户是否可用的用户
        /// </summary>
        public bool Custom_CanUse
        {
            get
            {
                return _Custom_CanUse;
            }
            set
            {
                this._Custom_CanUse = value;
            }
        }

        /// <summary>
        /// 客户是否第一次登陆系统
        /// </summary>
        public bool Custom_IsFirst
        {
            get
            {
                return this._Custom_IsFirst;
            }
            set
            {
                _Custom_IsFirst = value;
            }
        }

        /// <summary>
        /// 网络服务器是否正常
        /// </summary>
        public bool IsUseNet
        {
            get
            {
                return this._IsUseNet;
            }
            set
            {
                this._IsUseNet = value;
            }
        }

        /// <summary>
        /// 是否我们的加密狗
        /// </summary>
        public bool IsOwenr
        {
            get
            {
                return this._IsOwenr;
            }
            set
            {
                this._IsOwenr = value;
            }
        }

        /// <summary>
        /// 有效性验证(是否有效的加密狗)
        /// </summary>
        public bool IsPassValie
        {
            get
            {
                return this._IsPassValie;
            }
            set
            {
                this._IsPassValie = value;
            }
        }

        /// <summary>
        /// 是否成功读取了加密狗的数据
        /// </summary>
        public bool IsReadHeandle
        {
            get
            {
                return this._IsReadHeandle;
            }
            set
            {
                this._IsReadHeandle = value;
            }
        }

        /// <summary>
        /// 登录完全验证属性(只读)
        /// </summary>
        public bool IsLoginSucess
        {
            get
            {
                return _IsOwenr && _IsPassValie && _IsReadHeandle;
            }
        }

        /// <summary>
        /// 是否插入加密狗
        /// </summary>
        private bool _IsUseHandle = false;

        /// <summary>
        /// 是否差入加密狗
        /// </summary>
        public bool IsUseHandle
        {
            get
            {
                return this._IsUseHandle;
            }
            set
            {
                this._IsUseHandle = value;
            }
        }

        /// <summary>
        /// 是否更换加密狗
        /// </summary>
        private bool _IsChangeHandle = false;

        /// <summary>
        /// 是否更换加密狗
        /// </summary>
        public bool IsChangeHandle
        {
            get
            {
                return _IsChangeHandle;
            }
            set
            {
                this._IsChangeHandle = value;
            }
        }

        /// <summary>
        /// 获取写入加密狗的数据
        /// </summary>
        /// <returns></returns>
        public string ToHandleString()
        {
            string dataString = string.Format("{0},{1},{2},{3},{4}", this.Fun, this.State, this.UseCount, this.DateCount, DateTime.Now.Ticks);
            return dataString;
        }

        /// <summary>
        /// 读取字符串数据数组
        /// </summary>
        /// <param name="data"></param>
        public void Read(string[] data)
        {
            bool result  = long.TryParse(data[0], out this.Fun);
            if(!result)
                this.Fun = 0;
            
            this.State = data[1].ToString();

            result = long.TryParse(data[2], out this.UseCount);
            if (!result)
                this.UseCount = 0;

            result = long.TryParse(data[3], out this.DateCount);
            if (!result)
                this.DateCount = 0;

            result = long.TryParse(data[4], out this.Time);
            if (!result)
                this.Time = 0;
            this.UseCount = long.Parse(data[2]);
            this.DateCount = long.Parse(data[3]);
            this.Time = long.Parse(data[4]);
        }

        #endregion
    }
}
