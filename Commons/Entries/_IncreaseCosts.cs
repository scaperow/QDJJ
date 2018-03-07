using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
/********安装增加费************/
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _IncreaseCosts:_BaseObject
    {

        /// <summary>
        /// 当前分部分项所属于的父级对象
        /// </summary>
        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取当前措施项目的父级对象
        /// </summary>
        public _UnitProject Parent
        {
            get
            {
                return this.m_Parent;
            }
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent;
            }
        }

        private DataTable m_DataSource;
        /// <summary>
        /// 子目增加费的数据源
        /// </summary>
        public DataTable DataSource
        {
            get { return m_DataSource; }
            //set { m_DataSource = value; }
        }
        private bool m_IsInit = true;
        /// <summary>
        /// 标识是否初始化过（添加默认模板）
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }
        public _IncreaseCosts(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
            //this.Activitie = p_Parent;
           
        }
        public  void init()
        {
            if (this.IsInit)
            {
                if (this.m_Parent.ProType.Contains("安装专业"))
                {
                    string fs = _Common.Application.Global.AppFolder + "库文件\\子目增加费\\" + getFileName(this.m_Parent.PrfType);
                    DataSet ds = CFiles.BinaryDeserializeForLib(fs);
                    if (ds.Tables.Count > 0)
                    {
                        this.m_DataSource = ds.Tables[0].Copy();
                        if (!this.m_DataSource.Columns.Contains("Check"))
                        {
                            this.m_DataSource.Columns.Add("Check", typeof(bool));
                            for (int i = 0; i < this.m_DataSource.Rows.Count; i++)
                            {
                                if (this.m_DataSource.Rows[i]["IsCheck"].ToString() == "1")
                                {
                                    this.m_DataSource.Rows[i]["Check"] = true;
                                }
                                else { this.m_DataSource.Rows[i]["Check"] = false; }

                            }

                        }
                        this.m_IsInit = false;
                    }
                   
                }
                else { this.m_DataSource = new DataTable(); }
            }
        }
        private string getFileName(string str)
        {
            string Tname = "";
            int value = -1;
           // value = str.IndexOf("安装增加费不分专业");
           // if (value > -1) Tname = "安装增加费不分专业.zjfx";
            value = str.IndexOf("机械设备安装");
            if (value > -1) Tname = "第一册机械设备安装工程.zjfx";
            value = str.IndexOf("电气设备安装");
            if (value > -1) Tname = "第二册电气设备安装工程.zjfx";
            value = str.IndexOf("热力设备安装");
            if (value > -1) Tname = "第三册热力设备安装工程.zjfx";
            value = str.IndexOf("炉窑砌筑");
            if (value > -1) Tname = "第四册炉窑砌筑工程.zjfx";
            value = str.IndexOf("静置设备与工艺金属结构制作");
            if (value > -1) Tname = "第五册静置设备与工艺金属结构制作安装工程.zjfx";
            value = str.IndexOf("工业管道");
            if (value > -1) Tname = "第六册工业管道工程.zjfx";
            value = str.IndexOf("消防设备安装");
            if (value > -1) Tname = "第七册消防设备安装工程.zjfx";
            value = str.IndexOf("给排水采暖燃气");
            if (value > -1) Tname = "第八册给排水采暖燃气工程.zjfx";
            value = str.IndexOf("空调工程");
            if (value > -1) Tname = "第九册通风 空调工程.zjfx";
            value = str.IndexOf("自动化控制仪表");
            if (value > -1) Tname = "第十册自动化控制仪表安装工程.zjfx";
            value = str.IndexOf("建筑智能化系统设备安装");
            if (value > -1) Tname = "第十二册建筑智能化系统设备安装工程.zjfx";
            value = str.IndexOf("长距离输送管道");
            if (value > -1) Tname = "第十三册长距离输送管道工程.zjfx";
            value = str.IndexOf("防腐蚀");
            if (value > -1) Tname = "第十四册刷油 防腐蚀 绝热工程.zjfx";
            if (Tname=="")
            {
                Tname = "安装增加费不分专业.zjfx";
            }
            return Tname;
        }
      
        /// <summary>
        /// 读取模板数据
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public void Load(string FilePath)
        {

            DataTable dt = CFiles.Deserialize(FilePath) as DataTable;
            if (dt==null)
            {
                dt=(CFiles.Deserialize(FilePath) as DataSet).Tables[0];
            }
            m_DataSource =dt ;

            if (!this.m_DataSource.Columns.Contains("Check"))
            {
                this.m_DataSource.Columns.Add("Check", typeof(bool));
                for (int i = 0; i < this.m_DataSource.Rows.Count; i++)
                {
                    if (this.m_DataSource.Rows[i]["IsCheck"].ToString() == "1")
                    {
                        this.m_DataSource.Rows[i]["Check"] = true;
                    }
                    else { this.m_DataSource.Rows[i]["Check"] = false; }

                }

            }
         
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="FilePath"></param>
        public void Save(string FilePath)
        {
            CFiles.BinarySerialize(m_DataSource, FilePath);
        }
        public int GetID()
        {
            DataRow row = this.m_DataSource.Rows[this.m_DataSource.Rows.Count - 1];
            return (ToolKit.ParseInt(row["ID"]) + 1);
        }
    }
}
