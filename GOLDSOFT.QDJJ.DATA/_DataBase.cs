/*
 * 数据连接基础类别此方法仅提供操作虚函数
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Factory.DataBaseFactory;

namespace GOLDSOFT.QDJJ.DATA
{
    public abstract class _DataBase : IDisposable
    {


        /// <summary>
        /// Access连接串
        /// </summary>
        public const string AccessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password = huayhy_goldsoft;Persist Security Info=False;Mode=ReadWrite|Share Deny None";

        /// <summary>
        /// 连接字符串
        /// </summary>
        private string m_connString = "";

        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IDataBase m_DataBase;

        /// <summary>
        /// 获取或设置连接字符串
        /// </summary>
        public string ConnString
        {
            get
            {
                return this.m_connString;
            }
            set
            {
                this.m_connString = value;
            }
        }
        /// <summary>
        /// 获取数据访问接口
        /// </summary>
        public IDataBase IDataBase
        {
            get
            {
                return this.m_DataBase;
            }
            set
            {
                this.m_DataBase = value;
            }
        }

        /// <summary>
        /// 构造一个数据库连接
        /// </summary>
        public _DataBase(string connString)
        {
           this.m_connString = connString;
        }

        /// <summary>
        /// 测试当前的连接是否正常
        /// </summary>
        /// <returns>true/false</returns>
        public virtual bool TestConnection()
        {
            return this.m_DataBase.TestConnection();
        }


        #region IDisposable 成员

        public void Dispose()
        {
            //this.Dispose();
        }

        #endregion
    }
}
