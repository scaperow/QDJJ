using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS.Interface
{
  public  interface IUserRule
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
      /// <summary>
      /// 添加对象
      /// </summary>
      /// <param name="QID">清单编号</param>
      /// <param name="unitProject">当前单位工程对象</param>
      /// <returns></returns>
        CResult Add(int QID, _UnitProject unitProject);

        /// <summary>
        /// 对象添加到单位工程
        /// </summary>
        /// <param name="QID">清单编号</param>
        /// <param name="unitProject">当前单位工程对象</param>
        /// <returns></returns>
        CResult AddUn(int QID, _UnitProject unitProject);
      /// <summary>
      /// 删除用户规则的清单及其子目
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
        CResult Del(int QID);
      /// <summary>
      /// 检查清单是否存在
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
        bool IsExistQD(object obj ,out int QID);
    }
}
