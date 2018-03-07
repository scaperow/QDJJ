using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProjectCheck : ABaseForm
    {
        public ProjectCheck()
        {
            InitializeComponent();
        }
        private DataTable m_Source;

        public DataTable Source
        {
            get { return m_Source; }
            set { m_Source = value; }
        }
        /// <summary>
        /// 清单子目列表
        /// </summary>
        private List<DataRow> o_list;
        /// <summary>
        /// 工料机列表
        /// </summary>
        private List<DataRow> q_list;

        private void ProjectCheck_Load(object sender, EventArgs e)
        {
            this.pictureEdit1.Visible = true;
            GetList();
        }

        public override void MustInit()
        {
            GetList();
            base.MustInit();
        }
        /// <summary>
        /// 检查所触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.pictureEdit1.Visible = false;
            BuildTable();
            foreach (CheckedListBoxItem item in this.checkedListBoxControl1.Items)
            {
                switch (item.CheckState)
                {
                    case CheckState.Checked:
                        SetTable(item.Description);
                        break;
                    case CheckState.Indeterminate:
                        break;
                    case CheckState.Unchecked:
                        break;
                    default:
                        break;
                }
            }
            this.treeListEx1.DataSource = this.m_Source;
            this.treeListEx1.ExpandAll();
            if (this.m_Source.Rows.Count>0)
            {
                this.simpleButton1.Enabled = true;
            }
        }
        private void BuildTable()
        {
           
            m_Source = new DataTable();
            m_Source.Columns.Add("ID",typeof(int));
            m_Source.Columns.Add("ParentID", typeof(int));
            m_Source.Columns.Add("Display", typeof(string));


            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {
                if (checkedListBoxControl1.Items[i].CheckState == CheckState.Checked)
                {
                    DataRow r1 = this.m_Source.NewRow();
                    r1["ID"] = i + 1;
                    r1["ParentID"] = 0;
                    r1["Display"] = checkedListBoxControl1.Items[i].Description;
                    this.m_Source.Rows.Add(r1);
                }
            }
           

           //DataRow r2 = this.m_Source.NewRow();
           //r2["ID"] = 2;
           //r2["ParentID"] = 0;
           //r2["Display"] = "子目单价=0";
           //this.m_Source.Rows.Add(r2);
           //DataRow r3 = this.m_Source.NewRow();
           //r3["ID"] = 3;
           //r3["ParentID"] = 0;
           //r3["Display"] = "人材机消耗量=0";
           //this.m_Source.Rows.Add(r3);

           //DataRow r4 = this.m_Source.NewRow();
           //r4["ID"] = 4;
           //r4["ParentID"] = 0;
           //r4["Display"] = "人材机单价=0";
           //this.m_Source.Rows.Add(r4);

           //DataRow r5 = this.m_Source.NewRow();
           //r5["ID"] = 5;
           //r5["ParentID"] = 0;
           //r5["Display"] = "未组价清单";
           //this.m_Source.Rows.Add(r5);
        }
        int getID { get { return ToolKit.ParseInt(this.m_Source.Compute("Max(ID)", "")) + 1; } }

        /// <summary>
        /// 获取所有的清单子目 和工料机
        /// </summary>
        private void GetList()
        {
            this.o_list =new List<DataRow>();
            this.q_list = new List<DataRow>();

            this.o_list.AddRange(this.Activitie.StructSource.ModelSubSegments.Rows.Cast<DataRow>());
            this.o_list.AddRange(this.Activitie.StructSource.ModelMeasures.Rows.Cast<DataRow>());

            this.q_list.AddRange(this.Activitie.StructSource.ModelQuantity.Rows.Cast<DataRow>());
           // this.q_list.AddRange(this.Activitie.Property.MeasuresProject.GetAllQuantityUnit);

            this.simpleButton1.Enabled = false;
        }

        private void SetTable(string check_str)
        {
            switch (check_str)
            {
                case "子目工程量=0":
                case "子目单价=0":
                    SetSubheadings(check_str);
                    break;
                case "人材机消耗量=0":
                case "人材机单价=0":
                    SetQuantity(check_str);
                    break;
                case "未组价清单":
                    SetFixed();
                    break;
                default:
                    break;
            }
        }

        private void SetSubheadings(string check_str)
        {
            IEnumerable<DataRow> infos=null;
            switch (check_str)
            {
                case "子目工程量=0":
                    infos = from n in this.o_list
                            where ToolKit.ParseDecimal(n["GCL"])==0 && n["LB"].Equals("子目")
                            select n;
                    SetFixedTable(infos, 1,false);
                    break;
                case "子目单价=0":
                    infos = from n in this.o_list
                            where ToolKit.ParseDecimal(n["ZHDJ"])==0 && n["LB"].Equals("子目")
                            select n;
                    SetFixedTable(infos, 2,false);
                    break;
                default:
                    break;
            }
            
           
                 
        }

        private void SetFixedTable(IEnumerable<DataRow> infos, int id,bool flag)
        {
            if (infos == null) return;
            if (flag)
            {
                foreach (DataRow item in infos)
                {
                    DataRow r2 = this.m_Source.NewRow();
                    r2["ID"] = this.getID;
                    r2["ParentID"] = id;
                    r2["Display"] = "[" + item["XMBM"] + "]" + item["XMMC"];
                    this.m_Source.Rows.Add(r2);
                }
            }
            else
            {
                _SubSegmentsSource souce = null;
                foreach (DataRow item in infos)
                {
                    if (item["SSLB"].Equals(0))
                    {
                        souce = this.Activitie.StructSource.ModelSubSegments;
                    }
                    else
                    {
                        souce = this.Activitie.StructSource.ModelMeasures;
                    }
                    DataRow row = souce.GetRowByOther(item["PID"].ToString());
                    DataRow r2 = this.m_Source.NewRow();
                    r2["ID"] = this.getID;
                    r2["ParentID"] = id;
                    if (row != null)
                    {
                        r2["Display"] = "[" + row["XMBM"] + "]" + "[" + item["XMBM"] + "]" + item["XMMC"];
                    }
                    else
                    {
                        r2["Display"] =  "[" + item["XMBM"] + "]" + item["XMMC"];
                    }
                     this.m_Source.Rows.Add(r2);
                }
            }
        }
        private void SetFixed()
        {
            IEnumerable<DataRow> infos = from n in this.o_list
                                             where n["LB"].Equals("清单")
                                             select n;
            IEnumerable<DataRow> infos1 = from n in infos
                                              where HaveSubhending(n)
                                              select n;
            IEnumerable<DataRow> infos2 = from n in infos1
                                          where !(ToolKit.ParseDecimal(n["ZHDJ"]) != 0 && n["ZJFS"].Equals("公式组价"))
                                              select n;

            SetFixedTable(infos2, 5,true);
            
        }
        private bool HaveSubhending(DataRow r)
        {
            IEnumerable<DataRow> infos = from n in this.o_list
                                         where n["PID"].Equals(r["ID"]) && n["SSLB"].Equals(r["SSLB"])
                                         select n;
            if (infos.Count() < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetQuantityTable(IEnumerable<DataRow> infos, int id)
        {
            if (infos == null) return;
            foreach (DataRow item in infos)
            {
                DataRow[] rows = this.m_Source.Select("Display='" + "[" + item["BH"] + "]" + item["MC"] + "' and ParentID="+id+"");
                if (rows.Length < 1)
                {
                    DataRow r2 = this.m_Source.NewRow();
                    r2["ID"] = this.getID;
                    r2["ParentID"] = id;
                    r2["Display"] = "[" + item["BH"] + "]" + item["MC"];
                    this.m_Source.Rows.Add(r2);
                }
            }
        }
        private void SetQuantity(string check_str)
        {
            IEnumerable<DataRow> infos = null;
            switch (check_str)
            {
                case "人材机消耗量=0":
                    infos = from n in this.q_list
                            where  ToolKit.ParseDecimal(n["XHL"])==0
                            select n;
                    SetQuantityTable(infos, 3);
                    break;
                case "人材机单价=0":
                    infos = from n in this.q_list
                            where  ToolKit.ParseDecimal(n["SCDJ"])==0
                            select n;
                    SetQuantityTable(infos, 4);
                    break;
                default:
                    break;
            }
        
        }
        /// <summary>
        /// 生成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "自检报告";
            DialogResult dl = this.saveFileDialog1.ShowDialog();
            if (dl==DialogResult.OK)
            {
                this.treeListEx1.ExportToXls(this.saveFileDialog1.FileName);
            }
        }
    }
}
