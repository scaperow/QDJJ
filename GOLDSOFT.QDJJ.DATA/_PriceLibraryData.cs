using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using System.Data;
using System.IO;

namespace GOLDSOFT.QDJJ.DATA
{
    public class _PriceLibraryData : IDataface
    {
        private _UserPriceLibrary m_PriceLibrary = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public  _PriceLibraryData()
        {

        }

        #region IDataface 成员

        /// <summary>
        /// 获取或设置点钱的数据源对象
        /// </summary>
        public object DataSource
        {
            get
            {
                return this.m_PriceLibrary;
            }
            set
            {
                this.m_PriceLibrary = value as _UserPriceLibrary;
            }
        }

        #endregion

        #region IDataface 成员

        /// <summary>
        /// 读取用户价格库数据
        /// </summary>
        /// <returns></returns>
        public ZiboSoft.Commons.Common.CResult Load()
        {
            _Files files = new _Files();
            files.ExtName = _Files.用户价格库扩展名;
            files.DirName = string.Format("{0}库文件\\系统库",this.m_PriceLibrary.Parent.Parent.Global.AppFolder.FullName);
            files.FileName = "用户价格库";
            CResult result = new CResult(false);
            try
            {
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {//文件存在的时候读取
                    m_PriceLibrary.UserPriceLibraryList = CFiles.Deserialize(files.FullName) as _UserPriceLibraryList;
                }
                result.Success = true;
                return result;
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.ErrorInformation = ex.Message;
                return result;
            }
        }

        #endregion

        #region IDataface 成员

        /// <summary>
        /// 保存当前的数据
        /// </summary>
        /// <returns></returns>
        public CResult Save()
        {
            _Files files = new _Files();
            files.ExtName = _Files.用户价格库扩展名;
            files.DirName = string.Format("{0}库文件\\系统库", this.m_PriceLibrary.Parent.Parent.Global.AppFolder.FullName);
            files.FileName = "用户价格库";
            CResult result = new CResult(false);
            
            try
            {
                CFiles.BinarySerialize(m_PriceLibrary.UserPriceLibraryList, files.FullName); 
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorInformation = ex.Message;
                return result;
            }
        }

        #endregion
    }
}
