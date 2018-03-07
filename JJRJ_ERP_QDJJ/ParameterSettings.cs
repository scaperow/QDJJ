using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid.Views.Grid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ParameterSettings : BaseForm
    {
        public ParameterSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParameterSettings_Load(object sender, EventArgs e)
        {
            DataRow[] rows = this.Activitie.StructSource.ModelPSubheadingsFee.Select("YYH=''");
            for (int i = 0; i < rows.Length; i++)
            {
                this.Activitie.StructSource.ModelPSubheadingsFee.Rows.Remove(rows[i]);
            }

            this.Activitie.StructSource.ModelPSubheadingsFee.AcceptChanges();
            this.bindingSourceQF.DataSource = this.Activitie.StructSource.ModelPSubheadingsFee.DefaultView;
            this.bindingSourceGC.DataSource = this.Activitie.StructSource.ModelUnitFee.DefaultView;
            //加载取费设置
            if (this.Activitie.StructSource.ModelPSubheadingsFee.Rows.Count > 0)
            {
                switch (this.Activitie.StructSource.ModelPSubheadingsFee.Rows[0]["QFLB"].ToString())
                {
                    case "0":
                        this.radioGroup1.SelectedIndex = 0;
                        break;
                    case "1":
                        this.radioGroup1.SelectedIndex = 1;
                        break;
                    case "2":
                        this.radioGroup1.SelectedIndex = 2;
                        break;
                    default:
                        this.radioGroup1.SelectedIndex = 0;
                        break;
                }
                this.FillFYLB();
            }
            //加载工程设置
            if (this.Activitie.StructSource.ModelUnitFee.Rows.Count > 0)
            {
                foreach (DataRow item in this.Activitie.StructSource.ModelUnitFee.Rows)
                {
                    this.comboBoxEdit1.Properties.Items.Add(item["GCLB"]);
                }
                //this.comboBoxEdit1.SelectedIndexChanged -= new EventHandler(comboBoxEdit1_SelectedIndexChanged);
                this.comboBoxEdit1.EditValue = this.Activitie.PrfType;
                //this.comboBoxEdit1.SelectedIndexChanged += new EventHandler(comboBoxEdit1_SelectedIndexChanged);
            }
        }

        /// <summary>
        /// 取费设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Activitie.TemplateType = this.radioGroup1.SelectedIndex.ToString();
            foreach (DataRowView item in this.bindingSourceQF)
            {
                item.BeginEdit();
                item["QFLB"] = this.radioGroup1.SelectedIndex.ToString();
                item.EndEdit();
            }
        }
        
        /// <summary>
        /// 工程设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Activitie.ProType = this.comboBoxEdit1.Text;
            bindingSourceGC.Filter = string.Format("GCLB='{0}'", this.Activitie.ProType);
            DataRowView drv = this.bindingSourceGC.Current as DataRowView;
            if (drv == null || drv["DEHFW"].Equals(string.Empty))
            {
                bindingSourceGC.Filter = string.Empty;
            }
            this.bindingSourceGC.ResetBindings(false);
        }

        /// <summary>
        /// 取费修改后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "FYLB")
            {
                this.FillFYLB();
            }
        }

        /// <summary>
        /// 填充用途类别
        /// </summary>
        private void FillFYLB()
        {
            this.repositoryItemComboBox1.Items.Clear();
            this.repositoryItemComboBox1.Items.AddRange(_Constant.FYLB.Split(','));
            foreach (DataRowView item in this.bindingSourceQF)
            {
                if (!item["FYLB"].Equals(string.Empty) && this.repositoryItemComboBox1.Items.Contains(item["FYLB"].ToString()))
                {
                    this.repositoryItemComboBox1.Items.Remove(item["FYLB"].ToString());
                }
            }
            this.repositoryItemComboBox1.Items.Add(string.Empty);
        }

        /// <summary>
        /// 列变更限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            this.gridView1_FocusedRowChanged(sender, null);
        }

        /// <summary>
        /// 行变更限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView g = sender as GridView;
            if (g.FocusedColumn != null)
            {
                DataRowView p_info = this.bindingSourceQF.Current as DataRowView;
                if (p_info != null)
                {
                    if (g.FocusedColumn.FieldName == "FYLB")
                    {
                        if (p_info["Sort"].Equals(11))
                        {
                            g.FocusedColumn.OptionsColumn.AllowEdit = false;
                        }
                        else
                        {
                            g.FocusedColumn.OptionsColumn.AllowEdit = true;
                        }
                    }
                }
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "GLFFL":
                    case "FXFFL":
                    case "LRFFL":
                    case "FL":
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if (d.Equals(0m))
                        {
                            e.DisplayText = string.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 刷新子目的条数
        /// </summary>
        private int m_ZMCount = 0;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Activitie.StructSource.ModelSubheadingsFee.RemoveAll();
            this.Activitie.DataTemp.ZMQFDataTemp.IsChange = true;
            DataRow[] m_FBFXZM = this.Activitie.StructSource.ModelSubSegments.Select("LB='子目' OR LB='子目-降效' OR LB='子目-增加费'");
            DataRow[] m_CSXMZM = this.Activitie.StructSource.ModelMeasures.Select("LB='子目' OR LB='子目-降效' OR LB='子目-增加费'");
            this.m_ZMCount = m_FBFXZM.Length + m_CSXMZM.Length;
            foreach (DataRow item in m_FBFXZM)
            {
                _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(m_Entity_SubInfo, item);
                _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);

                m_Methods_Subheadings.CreateZMQFS();
            }
            foreach (DataRow item in m_CSXMZM)
            {
                _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(m_Entity_SubInfo, item);
                _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);
   
                m_Methods_Subheadings.CreateZMQFS();
            }
            GLODSOFT.QDJJ.BUSINESS._Project_Statistics m_Project_Statistics = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(this.Activitie,this.CurrentBusiness);
            m_Project_Statistics.Calculate();
            MsgBox.Alert(m_ZMCount + "条定额刷新成功");
        }

        //private void BatchCalculate()
        //{
        //    BackgroundWorker ObjWorker = new BackgroundWorker();
        //    ObjWorker.WorkerReportsProgress = true;
        //    ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
        //    ObjWorker.RunWorkerAsync();
        //    ProgressFrom form = new ProgressFrom(ObjWorker);
        //    form.ShowDialog();
        //}

        //void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    this.Activitie.StructSource.ModelSubheadingsFee.Clear();
        //    this.Activitie.DataTemp.ZMQFDataTemp.IsChange = true;
        //    DataRow[] m_FBFXZM = this.Activitie.StructSource.ModelSubSegments.Select("LB='子目' OR LB='子目-降效' OR LB='子目-增加费'");
        //    DataRow[] m_CSXMZM = this.Activitie.StructSource.ModelMeasures.Select("LB='子目' OR LB='子目-降效' OR LB='子目-增加费'");
        //    this.m_ZMCount = m_FBFXZM.Length + m_CSXMZM.Length;
        //    foreach (DataRow item in m_FBFXZM)
        //    {
        //        _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
        //        _ObjectSource.GetObject(m_Entity_SubInfo, item);
        //        _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);
        //        m_Methods_Subheadings.CreateZMQFS();
        //    }
        //    foreach (DataRow item in m_CSXMZM)
        //    {
        //        _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
        //        _ObjectSource.GetObject(m_Entity_SubInfo, item);
        //        _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);
        //        m_Methods_Subheadings.CreateZMQFS();
        //    }
        //    GLODSOFT.QDJJ.BUSINESS._Project_Statistics m_Project_Statistics = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(this.Activitie);
        //    m_Project_Statistics.Calculate();
        //}
    }
}