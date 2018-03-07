/*
 用于处理操作的属性
 *增加 删除 替换
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 修改属性时候提供的记录方法
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Method,       //可应用任何元素
     AllowMultiple = true,                            //允许应用多次
     Inherited = true)]
    public class ActionAttribute : System.Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_ActionName">动作名称</param>
        /// <param name="_ActingOn">作用域</param>
        public ActionAttribute(string p_ActionName,string p_OtherName)
        {
            _ActionName = p_ActionName;            
            _OtherName = p_OtherName;
        }

        /// <summary>
        /// 当前动作名称
        /// </summary>
        private string _ActionName;

        /// <summary>
        /// 作用域
        /// </summary>
        private string _ActingOn;

        /// <summary>
        /// 别名
        /// </summary>
        private string _OtherName;

        /// <summary>
        /// 获取或设置别名
        /// </summary>
        public string OtherName
        {
            get { return this._OtherName; }
            set { this._OtherName = value; }
        }

        /// <summary>
        /// 获取或设置作用域
        /// </summary>
        public string ActingOn
        {
            get { return this._ActingOn; }
            set { this._ActingOn = value; }
        }

        /// <summary>
        /// 获取或设置动作名称
        /// </summary>
        public string ActionName
        {
            get { return this._ActionName; }
            set { this._ActionName = value; }
        }

        /// <summary>
        /// 对象名称
        /// </summary>
        private string _ObjectName;

        /// <summary>
        /// 当前对象名称
        /// </summary>
        public string ObjectName
        {
            get { return this._ObjectName; }
            set { this._ObjectName = value; }
        }

        /// <summary>
        /// 反向命令
        /// </summary>
        public string CommandName
        {
            get
            {
                if (this.ActionName == string.Empty) return string.Empty;
                switch (this.ActionName)
                {
                    case Command.Create:
                        return Command.Delete;
                    case Command.Delete:
                        return Command.Create;
                    case Command.Replace:
                        return Command.Replace;
                    default:
                        return string.Empty;
                }
            }
        }

        private object _Source = null;
        /// <summary>
        /// 当前处理的对象
        /// </summary>
        public object Source
        {
            get
            {
                return this._Source;
            }
            set
            {
                this._Source = value;
            }
        }

        /// <summary>
        /// 替换 排序 所需要的源
        /// </summary>
        private object _TagValue = null;

        public object TagValue
        {
            get
            {
                return this._TagValue;
            }
            set
            {
                _TagValue = value;
            }
        }
        

        /// <summary>
        /// 日志结果
        /// </summary>
        /// <returns></returns>
        public string ToLog()
        {
            return string.Format("操作:{0} 作用域:{1} 对象名称:{2}", _ActionName, _ActingOn, _ObjectName);
        }
    }
}
