/*
    用于处理数据存储的数据接口
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public interface IDataface
    {
        object DataSource
        {
            get;
            set;
        }
      
        /// <summary>
        /// 读取指定文件的
        /// </summary>
        /// <returns></returns>
        CResult Load();

        /// <summary>
        /// 保存指定文件
        /// </summary>
        /// <returns></returns>
        CResult Save();
    }
}
