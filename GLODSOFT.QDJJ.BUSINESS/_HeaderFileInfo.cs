using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _HeaderFileInfo
    {
        public ArrayList HeaderArrayList = new ArrayList();

        /// <summary>
        /// 只有单位工程才有总造价 项目无法读取总造价
        /// </summary>
        /// <param name="value"></param>
        public void AddRange(FileInfo[] value)
        {
            foreach (FileInfo info in value)
            {
                _HeaderInfo hinfo = new _HeaderInfo();
                if (info.Extension == ".JGCX")
                {
                    hinfo.HFileInfo = info;
                    hinfo.FileHeader = _HeaderFileInfo.OnlyReadHeader(info);
                }
                else 
                {
                    hinfo.HFileInfo = info;
                }
                /*if (info.Extension == ".JXMX")
                {
                    hinfo.HFileInfo = info;
                    hinfo.FileHeader = _Pr_Business.OnlyReadHeader(info);
                }*/
                if (hinfo.FileHeader == null)
                    hinfo.FileHeader = new _FileHeader();
                hinfo.FileHeader.FileLength = Math.Round(decimal.Parse(info.Length.ToString()) / 1024.00m / 1024.00m, 2).ToString() + "M";

                this.HeaderArrayList.Add(hinfo);
            }
            
        }

        /// <summary>
        /// 读取数据的头文件对象
        /// </summary>
        /// <param name="p_FileInfo"></param>
        /// <returns></returns>
        static _FileHeader OnlyReadHeader(FileInfo p_FileInfo)
        {
            using (FileStream stream = new FileStream(p_FileInfo.FullName, FileMode.Open, FileAccess.Read))
            {
                GZipStream zip = new GZipStream(stream, CompressionMode.Decompress);
                {

                    BinaryFormatter formater = new BinaryFormatter();
                    _FileHeader header = null;
                    try
                    {
                         header = (_FileHeader)formater.Deserialize(zip);
                       
                    }
                    catch (Exception)
                    {

                        header = null;
                    }
                    finally
                    {
                        zip.Close();
                       
                    }
                    return header;
                }
            }
        }
    }

    public class _HeaderInfo
    {
        /// <summary>
        /// 文件对象
        /// </summary>
        private FileInfo m_FileInfo = null;

        private _FileHeader m_FileHeader = null;

        
        /// <summary>
        /// 文件对象
        /// </summary>
        public FileInfo HFileInfo
        {
            get
            {
                
                return this.m_FileInfo;
            }
            set
            {
                this.m_FileInfo = value;
            }
        }

        /// <summary>
        /// 文件头对象
        /// </summary>
        public _FileHeader FileHeader
        {
            get
            {
                return this.m_FileHeader;
            }
            set
            {
                this.m_FileHeader = value;
            }
        }

        
    } 
}
