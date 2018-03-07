/*
 * 为工作流提供的操作函数集
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Operaty
    {
        /// <summary>
        /// 当前的工作流对象
        /// </summary>
        private _WorkFlows m_WorkFlows = null;

        public _Operaty(_WorkFlows p_w)
        {
            this.m_WorkFlows = p_w;
        }

        /// <summary>
        /// 根据路径文件仅仅加载一个文件对象(此方式不包含业务对象)
        /// </summary>
        /// <param name="p_File"></param>
        /// <returns></returns>
        public CResult LoadOnlyObject(_Files p_File)
        {
            FileInfo info = new FileInfo(p_File.FullName);
            return this.LoadOnlyObject(info);
        }

        /// <summary>
        /// 根据路径文件仅仅加载一个文件对象(此方式不包含业务对象)
        /// </summary>
        /// <param name="p_path"></param>
        /// <returns></returns>
        public CResult LoadOnlyObject(string  p_path)
        {
            FileInfo info = new FileInfo(p_path);
            return this.LoadOnlyObject(info);
        }
        /// <summary>
        /// 根据路径文件仅仅加载一个文件对象(此方式不包含业务对象)
        /// </summary>
        /// <param name="p_File">文件对象</param>
        /// <returns></returns>
        public CResult LoadOnlyObject(FileInfo p_File)
        {
            
            CResult result = new CResult(false);
            //文件不存在直接返回
            if (!p_File.Exists) return result;
            result.Value = CFiles.Deserialize(p_File.FullName);
            result.Success = true;
            return result;
        }       
    }
}
