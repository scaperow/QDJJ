using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.DATA
{
    public class _RepairQuantityUnitData : IDataface
    {
        private _RepairQuantityUnit m_RepairQuantityUnit = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public _RepairQuantityUnitData()
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
                return this.m_RepairQuantityUnit;
            }
            set
            {
                this.m_RepairQuantityUnit = value as _RepairQuantityUnit;
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
            files.ExtName = _Files.补充材机库扩展名;
            files.DirName = string.Format("{0}库文件\\系统库",this.m_RepairQuantityUnit.Parent.Parent.Global.AppFolder.FullName);
            files.FileName = "补充材机库";
            CResult result = new CResult(false);
            try
            {
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {//文件存在的时候读取
                    m_RepairQuantityUnit.RepairQuantityUnitList = CFiles.Deserialize(files.FullName) as _RepairQuantityUnitList;
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
            files.ExtName = _Files.补充材机库扩展名;
            files.DirName = string.Format("{0}库文件\\系统库", this.m_RepairQuantityUnit.Parent.Parent.Global.AppFolder.FullName);
            files.FileName = "补充材机库";
            CResult result = new CResult(false);
            
            try
            {
                CFiles.BinarySerialize(m_RepairQuantityUnit.RepairQuantityUnitList, files.FullName); 
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
