/*
    用于处理数据存储的数据接口(此类紧限制所有的_object对象)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;
using System.IO;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public interface IDataInterface
    {
       

        
        /// <summary>
        /// 用于实现如何保存对象的方法
        /// </summary>
        /// <returns></returns>
        CResult Save();

        /// <summary>
        /// 对象另存为方式
        /// </summary>
        /// <returns></returns>
        CResult SaveAs(string p_Path);
        CResult SaveAs(FileInfo p_File);
        CResult SaveAs(_Files p_Files);
        /// <summary>
        /// 另存为电子标书
        /// </summary>
        /// <param name="p_File"></param>
        /// <returns></returns>
        CResult SaveAsDZBS(FileInfo p_File);
        /// <summary>
        /// 导出指定的对象
        /// </summary>
        /// <param name="p_Files"></param>
        /// <returns></returns>
        CResult OutImport(System.IO.FileInfo p_Files, ArrayList p_Object);
        /// <summary>
        /// 另存为xml文件
        /// </summary>
        /// <param name="p_path"></param>
        /// <param name="OutType"></param>
        /// <returns></returns>
        CResult SaveXml(string p_path,string OutType);

    }
}
