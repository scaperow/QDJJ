using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
/********安装增加费************/
namespace GOLDSOFT.QDJJ.BUSINESS
{
    [Serializable]
    public class _Method_IncreaseCosts
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


        private DataTable m_DataSource;
        /// <summary>
        /// 子目增加费的数据源
        /// </summary>

        private bool m_IsInit = true;
        /// <summary>
        /// 标识是否初始化过（添加默认模板）
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }
        public _Method_IncreaseCosts(_UnitProject p_Parent, DataTable p_dt)
        {
            this.m_Parent = p_Parent;
            this.m_DataSource = p_dt;

        }

        /// <summary>
        /// 关联到项目
        /// </summary>
        public void Build(_Business m_Currentbus)
        {
            if (this.m_DataSource.Rows.Count < 1)
            {
                return;
            }

            //增加之前先删除增加费
            DataRow[] subsegments = this.m_Parent.StructSource.ModelSubSegments.Select(" LB='子目-增加费'");
            DataRow[] measures = this.m_Parent.StructSource.ModelMeasures.Select(" LB='子目-增加费'");

            using (var calculator = new Calculator(m_Currentbus, m_Parent))
            {
                for (int i = 0; i < subsegments.Length; i++)
                {
                    var entity = new _Entity_SubInfo();
                    _ObjectSource.GetObject(entity, subsegments[i]);
                    calculator.Entities.Add(entity);
                    subsegments[i].Delete();
                }

                for (int i = 0; i < measures.Length; i++)
                {
                    var entity = new _Entity_SubInfo();
                    _ObjectSource.GetObject(entity, measures[i]);
                    calculator.Entities.Add(entity);
                    measures[i].Delete();
                }
            }

            this.m_Parent.StructSource.ModelIncreaseCosts.Clear();

            DataRow[] checkedRows = this.m_DataSource.Select("Check=True");
            DataRow[] subItems = this.m_Parent.StructSource.ModelSubSegments.Select("LB='子目'");

            using (var calculator = new Calculator(m_Currentbus, Parent))
            {
                foreach (DataRow subItem in subItems)
                {
                    _Entity_SubInfo subInfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(subInfo, subItem);
                    foreach (DataRow row in checkedRows)
                    {
                        //若定额范围在指定范围之内
                        if (GLODSOFT.QDJJ.BUSINESS._Methods.ExistsBH(row["Fixed"].ToString(), subInfo))
                        {
                            DataRow[] rwoss = this.m_Parent.StructSource.ModelIncreaseCosts.Select(string.Format("ZMID={0}", subInfo.ID));
                            if (IsEsixtZJF(rwoss, row["Code"].ToString()))
                            {
                                _Entity_IncreaseCosts info1 = new _Entity_IncreaseCosts();
                                _Method_IncreaseCosts.SetInfo(row, info1);
                                info1.EnID = subInfo.EnID;
                                info1.UnID = subInfo.UnID;
                                info1.ZMID = subInfo.ID;
                                info1.QDID = subInfo.PID;
                                this.m_Parent.StructSource.ModelIncreaseCosts.Add(info1);
                                _Methods_IncreaseInfo minfo = new _Methods_IncreaseInfo(this.Parent, info1);
                                minfo.CurrentBegin(subInfo);//计算当前行
                            }
                        }
                    }
                }

                foreach (DataRow row in checkedRows)
                {
                    Create(m_Currentbus, GetLocation(Convert.ToInt32(row["ParentID"])), row, calculator);
                }
            }
        }

        public static void SetInfo(DataRow row, _Entity_IncreaseCosts info1)
        {
            info1.Name = row["Name"].ToString();
            info1.DH = row["Code"].ToString();
            info1.JSJC = row["Calculation"].ToString();
            if (row["Additional"].ToString() == "|")
            {
                info1.FJJS = "0";
            }
            else { info1.FJJS = row["Additional"].ToString(); }

            info1.XS = Convert.ToDecimal(row["Coefficient"] is DBNull ? 0 : row["Coefficient"]);

            if (row["Artificial"].ToString() == "")
            {
                info1.RGXS = 0m;
            }
            else
                info1.RGXS = Convert.ToDecimal(row["Artificial"]);
            if (row["Material"].ToString() == "")
            {
                info1.CLXS = 0m;
            }
            else
                info1.CLXS = Convert.ToDecimal(row["Material"]);

            if (row["Mechanical"].ToString() == "")
            {
                info1.JXXS = 0m;
            }
            else
                info1.JXXS = Convert.ToDecimal(row["Mechanical"]);

        }
        string str = "";
        private string GetLocation(int id)
        {

            DataRow[] rows = this.m_DataSource.Select(string.Format("ID={0}", id));

            if (rows.Length > 0)
            {
                str = rows[0]["location"].ToString();
                if (str != "")
                {
                    return str;
                }
                GetLocation(Convert.ToInt32(rows[0]["ParentID"]));

            }
            return str;
        }
        private void Create(_Business m_Currentbus, string Name, DataRow row, Calculator calculator)
        {
            if (calculator == null)
            {
                calculator = new Calculator(m_Currentbus, Parent);
            }

            var entities = new List<_Entity_SubInfo>();
            DataRow[] rows = null;
            switch (Name)
            {
                case "分部分项":
                    rows = this.Parent.StructSource.ModelSubSegments.Select("LB='清单'");
                    foreach (DataRow item in rows)
                    {
                        if (Convert.ToInt32(item["ZHHJ"]) == 0)
                        {
                            continue;
                        }

                        _Entity_SubInfo info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info, item);
                        CreateZJF(m_Currentbus, info, row, calculator);
                    }
                    break;
                default:
                    //分部分项的子目增加费添加
                    rows = this.Parent.StructSource.ModelSubSegments.Select("LB='清单'");
                    foreach (DataRow item in rows)
                    {
                        if (Convert.ToInt32(item["ZHHJ"]) == 0 && Name.IndexOf("系统调整") > -1)
                        {
                            continue;
                        }

                        if (item["XMMC"].Equals(Name))
                        {
                            _Entity_SubInfo info = new _Entity_SubInfo();
                            _ObjectSource.GetObject(info, item);
                            CreateZJF(m_Currentbus, info, row, calculator);
                        }
                    }
                    rows = this.Parent.StructSource.ModelMeasures.Select("LB='清单'");
                    foreach (DataRow item in rows)
                    {
                        if (Convert.ToInt32(item["ZHHJ"]) == 0 && Name.IndexOf("系统调整") > -1)
                        {
                            continue;
                        }

                        if (item["XMMC"].Equals(Name))
                        {
                            _Entity_SubInfo info = new _Entity_SubInfo();
                            _ObjectSource.GetObject(info, item);
                            CreateZJF(m_Currentbus, info, row, calculator);
                        }

                    } break;
            }
        }

        private void CreateZJF(_Business m_Currentbus, _Entity_SubInfo item, DataRow row, Calculator calculator)
        {
            if (calculator == null)
            {
                calculator = new Calculator(m_Currentbus, Parent);
            }

            _SubSegmentsSource sorce = null;
            GLODSOFT.QDJJ.BUSINESS._Methods_Fixed fix = null;

            if (item.SSLB == 0)
            {
                sorce = this.Parent.StructSource.ModelSubSegments;
                fix = new _Methods_Fixed(m_Currentbus, this.Parent, item);
            }
            else
            {
                sorce = this.Parent.StructSource.ModelMeasures;
                fix = new _Mothods_MFixed(m_Currentbus, this.Parent, item);
            }

            DataRow[] rows = sorce.Select(string.Format("PID={0} and LB='子目-增加费'", item.ID));
            if (IsEsixt(rows, row["Code"].ToString()))
            {
                List<_Entity_SubInfo> list = new List<_Entity_SubInfo>();
                _Entity_SubInfo info = new _Entity_SubInfo();
                info.OLDXMBM = row["Code"].ToString();
                info.XMBM = row["Code"].ToString();
                info.XMMC = row["Name"].ToString();
                info.LB = "子目-增加费";
                info.GCL = 1;
                list.Add(info);

                fix.Create(list);
                calculator.Entities.Add(info);
            }
            fix.Begin(null);
            calculator.Entities.Add(item);
        }

        private bool IsEsixtZJF(DataRow[] infos, string Code)
        {
            bool flag = true;
            foreach (DataRow item in infos)
            {
                if (item["DH"] != null)
                {
                    if (item["DH"].ToString().ToUpper() == Code.ToUpper())
                    {
                        return false;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 存在False 不存在true
        /// </summary>
        /// <param name="infos"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        private bool IsEsixt(DataRow[] infos, string Code)
        {
            bool flag = true;
            foreach (DataRow item in infos)
            {
                if (item["XMBM"] != null)
                {
                    if (item["XMBM"].ToString().ToUpper() == Code.ToUpper())
                    {
                        return false;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 读取模板数据
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public void Load(string FilePath)
        {

            DataTable dt = CFiles.Deserialize(FilePath) as DataTable;
            if (dt == null)
            {
                dt = (CFiles.Deserialize(FilePath) as DataSet).Tables[0];
            }
            m_DataSource = dt;

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
