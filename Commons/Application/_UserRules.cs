using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS.Interface;
using System.IO;

namespace GOLDSOFT.QDJJ.COMMONS.Application
{
    [Serializable]
    /// <summary>
    /// 当前用户规则库
    /// </summary>
    public class _UserRules
    { /// <summary>
        /// 对象编号（每次获取此值会自动增长）
        /// </summary>
        private int m_ObjectID = 1;

        /// <summary>
        /// 获取对象编号
        /// </summary>
        public int ObjectID
        {
            get
            {
                return ++m_ObjectID;
            }
        }

        private _List m_DataSource = null;

        /// <summary>
        /// 获取或设置当前对象的数据源
        /// </summary>
        public _List DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
            }

        }
        /// <summary>
        /// 当前对象上级对象
        /// </summary>
        private _GlobalData m_Parent = null;

        /// <summary>
        /// 获取当前对象的所属对象
        /// </summary>
        public _GlobalData Parent
        {
            get
            {
                return this.m_Parent;
            }
        }


           /// <summary>
        /// 空构造函数
        /// </summary>
        public _UserRules(_GlobalData p_Parent)
        {
            this.m_Parent = p_Parent;
           
        }

        /// <summary>
        /// 初始化用户规则库(每次初始化都会从用户价格库中获取数据)
        /// </summary>
        public void Init()
        {
            
           this.m_DataSource =new _List();
           Load();
        }
        public void Load()
        {
            _Files files = new _Files();
            files.ExtName = _Files.用户规则库扩展名;
            files.DirName = string.Format("{0}库文件\\系统库", this.Parent.Parent.Global.AppFolder.FullName);
            files.FileName = "用户规则库";
            CResult result = new CResult(false);
            try
            {
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {//文件存在的时候读取
                    this.m_DataSource =( CFiles.Deserialize(files.FullName) as _UserRules).m_DataSource;
                }

                result.Success = true;
              
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorInformation = ex.Message;
               
            }
        }
        public void Save()
        {
            _Files files = new _Files();
            files.ExtName = _Files.用户规则库扩展名;
            files.DirName = string.Format("{0}库文件\\系统库", this.Parent.Parent.Global.AppFolder.FullName);
            files.FileName = "用户规则库";
            CResult result = new CResult(false);
            try
            {
                CFiles.BinarySerialize(this, files.FullName);
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorInformation = ex.Message;

            }
        }
 
       
       
        /// <summary>
        /// 添加用户规则
        /// </summary>
        /// <param name="QID"></param>
        /// <param name="unitProject"></param>
        /// <returns></returns>
        public void Add(_ObjectInfo p_info)
        {

                //要每个字段都赋值
            _FixedListInfo info = p_info.Copy() as _FixedListInfo;
                info.ID = ObjectID;
                this.DataSource.Add(info);
          
        }
        /// <summary>
        /// 从用户规则添加到单位工程
        /// </summary>
        /// <param name="QID"></param>
        /// <param name="unitProject"></param>
        /// <returns></returns>
        public void AddUn(_ObjectInfo p_info, _UnitProject unitProject)
        {
            _FixedListInfo info = p_info.Copy() as _FixedListInfo;
            unitProject.Property.SubSegments.Create(info);
        }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="QID"></param>
        /// <returns></returns>
        public bool IsExistQD(_ObjectInfo p_info)
        {
           // return this.m_IDataface.IsExistQD(obj, out QID);

            bool flag = false;
            IEnumerable<_ObjectInfo> list = from info in this.m_DataSource.Cast<_ObjectInfo>()
                                            where info.OLDXMBM == p_info.OLDXMBM && info.XMMC == info.XMMC && info.LY == p_info.LY && info.LibraryName == p_info.LibraryName
                                            select info;
            if (list.Count()>0)
            {
     
                flag = true;
            }
                
            return flag;
        }
        /// <summary>
        /// 删除用户规则
        /// </summary>
        /// <param name="QID"></param>
        /// <returns></returns>
        public void Del(_ObjectInfo p_info)
        {
            //this.m_DataSource.Remove(p_info);

            foreach (_ObjectInfo info in this.m_DataSource)
            {
                if (info.OLDXMBM == p_info.OLDXMBM && info.XMMC == info.XMMC && info.LY == p_info.LY && info.LibraryName == p_info.LibraryName)
                {
                    this.m_DataSource.Remove(info);
                    break;
                }
            }
           // return this.m_IDataface.Del(QID);
        }
    }
}
