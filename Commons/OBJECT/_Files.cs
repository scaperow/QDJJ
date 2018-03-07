/*
   用于配置当前对象的文件配置属性(此对象在每次需要对文件进行处理的时候进行实例化)
   此对象不参与文件的保存序列化     
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 将要保存或者读取的文件名称
    /// </summary>
    public class _Files
    {

        #region ------------扩展名常量------------------
        /// <summary>
        /// 项目文件的扩展名称
        /// </summary>
        public const string ProjectExName = ".JXMX";

        /// <summary>
        /// 电子标书
        /// </summary>
        public const string Proj_DZBS = ".JZBX";

        /// <summary>
        /// 单项工程的扩展名称
        /// </summary>
        public const string EngineeringExName = ".JDXX";
        /// <summary>
        /// 单位工程的扩展名称
        /// </summary>
        public const string CUnitProjectExName = ".JGCX";

        /// <summary>
        /// 用户价格库扩展名
        /// </summary>
        public const string 用户价格库扩展名 = ".UPL";

        /// <summary>
        /// 补充材机库扩展名
        /// </summary>
        public const string 补充材机库扩展名 = ".BCL";
        /// <summary>
        /// 云价格库扩展名
        /// </summary>
        public const string 信息价格库扩展名 = ".IPL";
        /// <summary>
        /// 报表格式
        /// </summary>
        public const string 报表格式扩展名 = ".RF";

        /// <summary>
        /// 用户规则库扩展名
        /// </summary>
        public const string 用户规则库扩展名 = ".URX";
        /// <summary>
        /// 单位工程备份扩展名
        /// </summary>
        public const string 单位工程备份扩展名 = ".BAK";
        /// <summary>
        /// 工程信息文件
        /// </summary>
        public const string 工程信息文件 = ".GCXX";
        /// <summary>
        /// 工程信息文件
        /// </summary>
        public const string 调标文件 = ".TBX";



        public const string 招标文件扩展名1 = ".ZBS";
        public const string 招标文件扩展名2 = ".ZBS2";
        public const string 投标文件扩展名1 = ".TBS";
        public const string 投标文件扩展名2 = ".TBS2";
        public const string 标底文件扩展名1 = ".BD";
        public const string 标底文件扩展名2 = ".BD2";

        #endregion

        /// <summary>
        /// 根据扩展名称获取文件类型
        /// </summary>
        /// <param name="p_ExName"></param>
        public static string GetFileRemark(string p_ExName)
        {
            switch(p_ExName)
            {
                case CUnitProjectExName:
                    return "单位工程文件(jgcx)";
                case ProjectExName:
                    return "项目管理文件(jxmx)";
                case Proj_DZBS:
                    return "电子标书(jzbx)";
                default:
                    return "未知文件";
            }
        }
        
        /// <summary>
        /// 当前文件的目录名
        /// </summary>
        private string m_DirName = string.Empty;

        /// <summary>
        /// 当前文件的文件名称
        /// </summary>
        private string m_FileName = string.Empty;

        /// <summary>
        /// 当前文件的扩展名称
        /// </summary>
        private string m_ExtName  = string.Empty;

        /// <summary>
        /// 获取或设置当前文件对象(如果文件对象不为空则FullName按照FileInfo获取)
        /// </summary>
        private FileInfo m_File = null;

        /// <summary>
        /// 获取或设置当前文件对象(如果文件对象不为空则FullName按照FileInfo获取)
        /// </summary>
        public FileInfo File
        {
            get
            {
                return this.m_File;
            }
            set
            {
                this.m_File = value;
            }
        }

        /// <summary>
        /// 获取或设置当前对象的目录名称
        /// </summary>
        public string DirName
        {
            get
            {
                return this.m_DirName;
            }
            set
            {
                this.m_DirName = value;
            }
        }

        /// <summary>
        /// 获取或设置当前对象的文件名称
        /// </summary>
        public string FileName
        {
            get
            {
                return this.m_FileName;
            }
            set
            {
                this.m_FileName = value;
            }
        }

        /// <summary>
        /// 获取或设置当前对象的扩展名称
        /// </summary>
        public string ExtName
        {
            get
            {
                return this.m_ExtName;
            }
            set
            {
                this.m_ExtName = value;
            }
        }

        /// <summary>
        /// 获取当前对象的完全路径名称
        /// </summary>
        public string FullName
        {
            get
            {
                if (this.m_File != null)
                {
                    return this.m_File.FullName;
                }
                return string.Format("{0}\\{1}{2}", this.m_DirName, this.m_FileName, this.ExtName);
                
            }
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        private bool m_Exists = false;

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        public bool Exists
        {
            get
            {
                return this.m_Exists;
            }
        }

        /// <summary>
        /// 文件存在效验(没有经过Init方法的时候验证判断)
        /// </summary>
        /// <param name="files">文件对象</param>
        /// <returns></returns>
        public bool Verification()
        {
            FileInfo file = new FileInfo(this.FullName);
            if (file.Exists)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 当前文件的类型
        /// </summary>
        private string m_FileType = string.Empty;

        /// <summary>
        /// 当前文件的类型
        /// </summary>
        public string FileType
        {
            get
            {
                return this.m_FileType;
            }
            set
            {
                this.m_FileType = value;
            }
        }

        /// <summary>
        /// 用实际文件初始化当前对象
        /// </summary>
        /// <param name="p_fileName"></param>
        public void Init(string p_fileName)
        {
            //获取文件对象
            FileInfo info = new FileInfo(p_fileName);
            this.m_Exists = info.Exists;
            if (this.m_Exists)
            {
                //如果文件存在
                this.m_ExtName = info.Extension;
                this.m_FileName = info.Name;
                this.m_DirName = info.DirectoryName;
                this.File = info;
                //设置文件的类型
                switch (this.ExtName.ToUpper())
                {
                    case _Files.CUnitProjectExName:
                        this.m_FileType = CFileType.单位工程;
                        break;
                    case _Files.EngineeringExName:
                        this.m_FileType = CFileType.单项工程;
                        break;
                    case _Files.ProjectExName:
                        this.m_FileType = CFileType.项目文件;
                        break;
                    case _Files.Proj_DZBS:
                        this.m_FileType = CFileType.电子标书;
                        break;
                    case _Files.调标文件:
                        this.m_FileType = CFileType.调标文件;
                        break;
                    case _Files.单位工程备份扩展名:
                        this.m_FileType = CFileType.单位工程;
                        break;
                    case _Files.招标文件扩展名1:
                    case _Files.招标文件扩展名2:
                    case _Files.投标文件扩展名1:
                    case _Files.投标文件扩展名2:
                    case _Files.标底文件扩展名1:
                    case _Files.标底文件扩展名2:
                        this.m_FileType = CFileType.XML文件;
                        break;
                    case _Files.工程信息文件:
                        this.m_FileType = CFileType.工程信息文件;
                        break;
                    default:
                        this.m_FileType = CFileType.未知文件;
                        break;
                }
            }
        }

        /// <summary>
        /// 用实路径初始化当前对象
        /// </summary>
        /// <param name="p_fileName"></param>
        public void init(string p_fileName)
        {
            //获取文件对象
            FileInfo info = new FileInfo(p_fileName);
            this.m_Exists = info.Exists;
            
                //如果文件存在
                this.m_ExtName = info.Extension;
                this.m_FileName = info.Name;
                this.m_DirName = info.DirectoryName;
                this.File = info;
                //设置文件的类型
                switch (this.ExtName.ToUpper())
                {
                    case _Files.CUnitProjectExName:
                        this.m_FileType = CFileType.单位工程;
                        break;
                    case _Files.EngineeringExName:
                        this.m_FileType = CFileType.单项工程;
                        break;
                    case _Files.ProjectExName:
                        this.m_FileType = CFileType.项目文件;
                        break;
                    case _Files.Proj_DZBS:
                        this.m_FileType = CFileType.电子标书;
                        break;
                    case _Files.调标文件:
                        this.m_FileType = CFileType.调标文件;
                        break;
                    case _Files.单位工程备份扩展名:
                        this.m_FileType = CFileType.单位工程;
                        break;
                    case _Files.招标文件扩展名1:
                    case _Files.招标文件扩展名2:
                    case _Files.投标文件扩展名1:
                    case _Files.投标文件扩展名2:
                    case _Files.标底文件扩展名1:
                    case _Files.标底文件扩展名2:
                        this.m_FileType = CFileType.XML文件;
                        break;
                    default:
                        this.m_FileType = CFileType.未知文件;
                        break;
                
            }
        }

        /// <summary>
        /// 用实路径初始化当前对象
        /// </summary>
        /// <param name="p_fileName"></param>
        public void ChangeExtName(string p_FileName,string p_NewName)
        {
            //获取文件对象
            FileInfo info = new FileInfo(p_FileName);
            this.init(p_FileName.Replace(info.Extension, p_NewName));
        }

        /// <summary>
        /// 文件类型
        /// </summary>
        public class CFileType
        {
            public const string 项目文件 = "项目工程";
            public const string 单位工程 = "单位工程";
            public const string 单项工程 = "单项工程";
            public const string 未知文件 = "未知文件";
            public const string XML文件 = "XML文件";
            public const string 电子标书 = "电子标书";
            public const string 工程信息文件 = "工程信息文件";
            public const string 调标文件 = "调标文件";
        }

    }
}
