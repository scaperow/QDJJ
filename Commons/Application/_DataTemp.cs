/*
 当前项目中使用的数据模板类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _DataTemp
    {
        /// <summary>
        /// 当前项目中使用的模板数据集合
        /// </summary>
        private DataSet m_TempDataSet = new DataSet();

        /// <summary>
        /// 存放系统默认汇分析模板数据
        /// </summary>
        private DataSet m_Metaanalysis = null;
        /// <summary>
        /// 存放系统默认报表格式
        /// </summary>
        private _List m_Reports = null;

        /// <summary>
        /// 获取或设置：系统默认项目报表格式
        /// </summary>
        public _List XMReports
        {
            get
            {
                _List xm = new _List();
                m_Reports.AddRange(m_Reports.Cast<_ObjectReport>().Where(p => p.ReportType == "项目").ToArray());
                return xm;
            }
        }

        /// <summary>
        /// 获取或设置：系统默认单位工程报表格式
        /// </summary>
        public _List DWGCReports
        {
            get
            {
                _List dwgc = new _List();
                m_Reports.AddRange(m_Reports.Cast<_ObjectReport>().Where(p => p.ReportType == "单位工程").ToArray());
                return dwgc;
            }
        }

        /// <summary>
        /// 获取需要的应用程序路径
        /// </summary>
        private string m_AppFolder = string.Empty;

        /// <summary>
        /// 当前工作目录路径
        /// </summary>
        public string AppFolder
        {
            get
            {
                return this.m_AppFolder;
            }
            set
            {
                this.m_AppFolder = value;
                //读取xml结构数据库
                this.Load();
                //读取结构文件
                this.LoadFiles();
                //读取汇总分析模板
                this.LoadMetaanalysis();
                //读取管理费利润
                this.LoadCostSelectList();
                //读取报表格式
                this.LoadReportList();
            }
        }

        private DataSet m_TempList = null;

        public DataSet TempList
        {
            get
            {
                return this.m_TempList;
            }
            set
            {
                this.m_TempList = value;
            }
        }

        /// <summary>
        /// 当前项目中使用的模板数据集合
        /// </summary>
        public DataSet TempDataSet
        {
            get
            {
                return this.m_TempDataSet;
            }
        }

        /// <summary>
        /// 获取系统的汇总分析模板
        /// </summary>
        public DataSet Metaanalysis
        {
            get
            {
                return this.m_Metaanalysis;
            }
        }
        private DataSet m_MeasuresList;
        /// <summary>
        /// 获取措施项目模板
        /// </summary>
        public DataSet MeasuresList
        {
            get { return m_MeasuresList; }
            set { m_MeasuresList = value; }
        }

        private DataSet m_CostSelectList;
        /// <summary>
        /// 获取管理费利润表
        /// </summary>
        public DataSet CostSelectList
        {
            get { return m_CostSelectList; }
            set { m_CostSelectList = value; }
        }


        private DataSet m_变量对应表;
        /// <summary>
        /// 变量对应表
        /// </summary>
        public DataSet 变量对应表
        {
            get { return m_变量对应表; }
            set { m_变量对应表 = value; }
        }


        private DataSet m_工程信息表;
        /// <summary>
        /// 工程信息表
        /// </summary>
        public DataSet 工程信息表
        {
            get
            {
                if (m_工程信息表 == null)
                {
                    return new DataSet();
                }
                return m_工程信息表;
            }
            set { m_工程信息表 = value; }
        }
        private DataSet m_安装专业工程信息表;
        /// <summary>
        /// 安装专业工程信息表
        /// </summary>
        public DataSet 安装专业工程信息表
        {
            get
            {
                if (m_安装专业工程信息表 == null)
                {
                    return new DataSet();
                }
                return m_安装专业工程信息表;
            }
            set { m_安装专业工程信息表 = value; }
        }

        private DataSet m_工程设置;

        public DataSet 工程设置
        {
            get
            {
                return this.m_工程设置;
            }
            set
            {
                this.m_工程设置 = value;
            }
        }

        private DataSet m_工程说明表;
        /// <summary>
        /// 工程说明表
        /// </summary>
        public DataSet 工程说明表
        {
            get 
            {
                if (m_工程说明表 == null)
                {
                    return new DataSet();
                }
                return m_工程说明表; 
            }
            set { m_工程说明表 = value; }
        }
        private DataSet m_自动报价;
        /// <summary>
        /// 自动报价
        /// </summary>
        public DataSet 自动报价
        {
            get { return m_自动报价; }
            set { m_自动报价 = value; }
        }
        /// <summary>
        /// 读取Xml模板数据文件
        /// </summary>
        public void Load()
        {
            string ps = this.AppFolder + "config\\" + "Schema.xml";
            this.m_TempDataSet.ReadXmlSchema(ps);

            foreach (DataTable table in this.m_TempDataSet.Tables)
            {
                string p = this.AppFolder + "config\\" + table.TableName + ".xml";
                table.ReadXml(p);
                if (table.TableName == "ConvertUnit")
                {
                    _ConvertUnit.Source = table;
                }
            }
        }

        /// <summary>
        /// 读取管理费利润表
        /// </summary>
        public void LoadCostSelectList()
        {
            this.m_CostSelectList = new DataSet("管理费利润表");
            string fs0 = this.AppFolder + "库文件\\系统库\\管理费利润表.qtsx";
            this.m_CostSelectList = CFiles.Deserialize(fs0) as DataSet;
            this.m_CostSelectList.AcceptChanges();
        }

        /// <summary>
        /// 读取报表格式
        /// </summary>
        public void LoadReportList()
        {
            /*this.m_Reports = new _List();
            string fs = this.AppFolder + "库文件\\系统库\\报表格式.rf";
            this.m_Reports = CFiles.Deserialize(fs) as _List;*/
        }

        /// <summary>
        /// 读取汇总分析文件
        /// </summary>
        public void LoadMetaanalysis()
        {
            //默认加载四种汇总分析模板2012扣劳保与2012不扣劳保
            this.m_Metaanalysis = new DataSet("汇总分析");
            string fs0 = this.AppFolder + "模板文件\\汇总分析模板\\" + "2012汇总分析表【扣劳保】.hzfx";
            string fs1 = this.AppFolder + "模板文件\\汇总分析模板\\" + "2012汇总分析表【不扣劳保】.hzfx";
            string fs2 = this.AppFolder + "模板文件\\汇总分析模板\\" + "2009汇总分析表【扣劳保】.hzfx";
            string fs3 = this.AppFolder + "模板文件\\汇总分析模板\\" + "2009汇总分析表【不扣劳保】.hzfx";
            DataTable t0 = CFiles.Deserialize(fs0) as DataTable;
            DataTable t1 = CFiles.Deserialize(fs1) as DataTable;
            DataTable t2 = CFiles.Deserialize(fs2) as DataTable;
            DataTable t3 = CFiles.Deserialize(fs3) as DataTable;

            t0.TableName = "2012扣劳保";
            t1.TableName = "2012不扣劳保";
            t2.TableName = "2009扣劳保";
            t3.TableName = "2009不扣劳保";

            this.m_Metaanalysis.Tables.Add(t0);
            this.m_Metaanalysis.Tables.Add(t1);
            this.m_Metaanalysis.Tables.Add(t2);
            this.m_Metaanalysis.Tables.Add(t3);
            this.m_Metaanalysis.AcceptChanges();
            //为模板添加自增长列
            /*foreach (DataTable table in this.m_TempList.Tables)
            {
                table.Columns["ID"].AutoIncrement = true;
                table.Columns["ID"].AutoIncrementSeed = 0;
                table.Columns["ID"].AutoIncrementStep = 1;
            }
            */
        }

        public DataTable LoadOtherProject(string GCDD)
        {
            switch (GCDD)
            {

                case "汉中":
                    string fs0 = this.AppFolder + "模板文件\\其他项目\\" + "其他项目【汉中】.qtsx";
                    DataTable t0 = CFiles.Deserialize(fs0) as DataTable;
                    //FilePath = fs0;
                    return t0;

                default:
                    string fs1 = this.AppFolder + "模板文件\\其他项目\\" + "其他项目【通用】.qtsx";
                    DataTable t1 = CFiles.Deserialize(fs1) as DataTable;
                    //FilePath = fs1;
                    return t1;

            }
        }


        /// <summary>
        /// 读取系统使用的模板文件
        /// </summary>
        public void LoadFiles()
        {

            string fs = this.AppFolder + "config\\" + "模板.qtsx";
            this.m_TempList = CFiles.BinaryDeserializeForLib(fs);
            //为模板添加自增长列
            foreach (DataTable table in this.m_TempList.Tables)
            {
                table.Columns["ID"].AutoIncrement = true;
                table.Columns["ID"].AutoIncrementSeed = 0;
                table.Columns["ID"].AutoIncrementStep = 1;
            }


            //措施项目模板的读取
            this.m_MeasuresList = CFiles.BinaryDeserializeForLib(this.AppFolder + "config\\" + "措施项目模板.qtsx");
            this.m_变量对应表 = CFiles.BinaryDeserializeForLib(this.AppFolder + "config\\" + "变量对应表.qtsx");
            this.m_自动报价 = CFiles.BinaryDeserializeForLib(this.AppFolder + "config\\" + "自动报价.qtsx");
            this.m_工程设置 = CFiles.BinaryDeserializeForLib(this.AppFolder + "config\\" + "工程说明.qtsx");
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _DataTemp()
        {
        }

    }
}
