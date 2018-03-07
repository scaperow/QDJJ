using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS.OBJECTS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _InformationPriceLibrary
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public _InformationPriceLibrary()
        {
            this.m_InformationPriceLibrarySource = new _InformationPriceLibrarySource();
        }

        /// <summary>
        /// 信息价格库
        /// </summary>
        private _InformationPriceLibrarySource m_InformationPriceLibrarySource = null;

        /// <summary>
        /// 获取或设置：信息价格库
        /// </summary>
        public _InformationPriceLibrarySource InformationPriceLibrarySource
        {
            get { return m_InformationPriceLibrarySource; }
            set { m_InformationPriceLibrarySource = value; }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            try
            {
                string m_Path = string.Format("{0}库文件\\信息价格库\\", APP.Application.Global.AppFolder.FullName);
                ToolKit.GetDirectoryInfo(m_Path);
                _Files files = new _Files();
                files.ExtName = _Files.信息价格库扩展名;
                files.DirName = m_Path;
                files.FileName = "信息价格库";
                FileInfo info = new FileInfo(files.FullName);
                if (info.Exists)
                {
                    //文件存在的时候读取
                    _InformationPriceLibrarySource cs = CFiles.Deserialize(files.FullName) as _InformationPriceLibrarySource;
                    if (cs != null)
                    {
                        this.m_InformationPriceLibrarySource = cs;
                    }
                }
                else
                {
                    this.m_InformationPriceLibrarySource = new _InformationPriceLibrarySource();
                    CFiles.BinarySerialize(this.m_InformationPriceLibrarySource, files.FullName);
                }
            }
            catch (Exception e)
            {
                throw e;
                return;
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            try
            {
                string m_Path = string.Format("{0}库文件\\信息价格库\\", APP.Application.Global.AppFolder.FullName);
                ToolKit.GetDirectoryInfo(m_Path);
                _Files files = new _Files();
                files.ExtName = _Files.信息价格库扩展名;
                files.DirName = m_Path;
                files.FileName = "信息价格库";
                CFiles.BinarySerialize(this.m_InformationPriceLibrarySource, files.FullName);
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 更新信息价格库
        /// </summary>
        /// <param name="p_DataTable"></param>
        public void UpdateData(DataTable p_DataTable)
        {
            if (p_DataTable.Rows.Count > 0)
            {
                DataRow edit = p_DataTable.Select(string.Empty, "UpdateTime DESC").FirstOrDefault();
                if (edit != null)
                {
                    this.InformationPriceLibrarySource.TableName = edit["UpdateTime"].ToString();
                }
                foreach (DataRow item in p_DataTable.Rows)
                {
                    switch (item["Status"].ToString())
                    {
                        case "add":
                            AddRow(item);
                            break;
                        case "update":
                            UpdateRow(item);
                            break;
                        case "delete":
                            DeleteRow(item);
                            break;
                        default:
                            break;
                    }
                }
                this.Save();
            }
        }

        /// <summary>
        /// 增加行
        /// </summary>
        /// <param name="p_DataRow"></param>
        private void UpdateRow(DataRow p_DataRow)
        {
            if (p_DataRow == null) return;
            DataRow m_DataRow = this.InformationPriceLibrarySource.Select(string.Format("ID ={0}", p_DataRow["ID"])).FirstOrDefault();
            if (m_DataRow != null)
            {
                m_DataRow["BH"] = p_DataRow["BH"];
                m_DataRow["MC"] = p_DataRow["MC"];
                m_DataRow["DW"] = p_DataRow["DW"];
                m_DataRow["LB"] = p_DataRow["LB"];
                m_DataRow["DJ"] = p_DataRow["DJ"];
                m_DataRow["BZ"] = p_DataRow["BZ"];
                m_DataRow["Status"] = p_DataRow["Status"];
                m_DataRow["UpdateTime"] = p_DataRow["UpdateTime"];
            }
        }

        /// <summary>
        /// 修改行
        /// </summary>
        /// <param name="p_DataRow"></param>
        private void AddRow(DataRow p_DataRow)
        {
            if (p_DataRow == null) return;
            DataRow m_DataRow = this.InformationPriceLibrarySource.NewRow();
            m_DataRow["BH"] = p_DataRow["BH"];
            m_DataRow["MC"] = p_DataRow["MC"];
            m_DataRow["DW"] = p_DataRow["DW"];
            m_DataRow["LB"] = p_DataRow["LB"];
            m_DataRow["DJ"] = p_DataRow["DJ"];
            m_DataRow["BZ"] = p_DataRow["BZ"];
            m_DataRow["Status"] = p_DataRow["Status"];
            m_DataRow["UpdateTime"] = p_DataRow["UpdateTime"];
            this.InformationPriceLibrarySource.Rows.Add(m_DataRow);
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="p_DataRow"></param>
        private void DeleteRow(DataRow p_DataRow)
        {
            if (p_DataRow == null) return;
            DataRow m_DataRow = this.InformationPriceLibrarySource.Select(string.Format("ID ={0}", p_DataRow["ID"])).FirstOrDefault();
            if (m_DataRow != null)
            {
                this.InformationPriceLibrarySource.Rows.Remove(m_DataRow);
            }
        }
    }
}
