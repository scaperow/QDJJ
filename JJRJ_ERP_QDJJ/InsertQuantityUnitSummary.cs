using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class InsertQuantityUnitSummary : CBaseForm
    {
        private DataRow new_info = null;

        private string m_BH = null;

        public string BH
        {
            get { return m_BH; }
            set { m_BH = value; }
        }

        /// <summary>
        /// 当前工程材机
        /// </summary>
        private object m_DataSource = null;

        /// <summary>
        /// 获取或设置：当前工程材机
        /// </summary>
        public object DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }

        public InsertQuantityUnitSummary()
        {
            InitializeComponent();
        }

        private void InsertQuantityUnitSummary_Load(object sender, EventArgs e)
        {
            initSysWoodMachineForm();
            initRepairQuantityUnit();
            initUserQuantityUnit();
            initCurrentUnit();
        }



        /// <summary>
        /// 替换确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// 插入确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 当前工程材机
        /// </summary>
        private void initCurrentUnit()
        {
            CurrentUnit form = new CurrentUnit();
            form.Activitie = this.Activitie;
            form.DataSource = this.DataSource;
            form.Text = "当前工程材机";
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage1.Controls.Add(form);
        }

        /// <summary>
        /// 系统材机库
        /// </summary>
        private void initSysWoodMachineForm()
        {
            SysWoodMachineForm form = new SysWoodMachineForm(this.Activitie);
            form.BH = this.m_BH;
            form.panelControl1.Visible = false;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage2.Controls.Add(form);
        }

        /// <summary>
        /// 用户材机库
        /// </summary>
        private void initUserQuantityUnit()
        {
            UserQuantityUnitSelect form = new UserQuantityUnitSelect();
            form.Activitie = this.Activitie;
            form.Text = "用户材机库";
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage3.Controls.Add(form);
        }

        /// <summary>
        /// 补充材机库
        /// </summary>
        private void initRepairQuantityUnit()
        {
            RepairQuantityUnitSelect form = new RepairQuantityUnitSelect();
            form.Activitie = this.Activitie;
            form.Text = "补充材机库";
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage4.Controls.Add(form);
        }

        /// <summary>
        /// 获取要植入的信息
        /// </summary>
        public DataRow GetNewInfo()
        {
            switch (this.xtraTabControl1.SelectedTabPage.Text)
            {
                case "当前工程材机":
                    CurrentUnit m_CurrentUnitSelect = this.xtraTabControl1.SelectedTabPage.Controls[0] as CurrentUnit;
                    DataRow m_CurrentUnit = m_CurrentUnitSelect.bandedGridViewBDGLJ.GetFocusedDataRow();
                    if (m_CurrentUnit != null)
                    {
                        this.new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
                        this.new_info["YSBH"] = m_CurrentUnit["YSBH"];
                        this.new_info["YSMC"] = m_CurrentUnit["YSMC"];
                        this.new_info["YSDW"] = m_CurrentUnit["YSDW"];
                        this.new_info["DEDJ"] = m_CurrentUnit["DEDJ"];
                        this.new_info["BH"] = m_CurrentUnit["BH"];
                        this.new_info["MC"] = m_CurrentUnit["MC"];
                        this.new_info["DW"] = m_CurrentUnit["DW"];
                        this.new_info["LB"] = m_CurrentUnit["LB"];
                        this.new_info["SCDJ"] = m_CurrentUnit["SCDJ"];
                    }
                    break;
                case "系统材机库":
                    SysWoodMachineForm sysWoodMachineForm = this.xtraTabControl1.SelectedTabPage.Controls[0] as SysWoodMachineForm;
                    DataRowView drv = sysWoodMachineForm.bindingSource1.Current as DataRowView;
                    if (drv != null)
                    {
                        this.new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
                        this.new_info["IFSC"] = drv.Row["CAIJSC"].Equals("是") ? true : false;
                        this.new_info["YSBH"] = drv.Row["CAIJBH"];
                        this.new_info["YSMC"] = drv.Row["CAIJMC"];
                        this.new_info["YSDW"] = drv.Row["CAIJDW"];
                        this.new_info["DEDJ"] = ToolKit.ParseDecimal(drv.Row["CAIJDJ"]);
                        this.new_info["BH"] = drv.Row["CAIJBH"];
                        this.new_info["MC"] = drv.Row["CAIJMC"];
                        this.new_info["DW"] = drv.Row["CAIJDW"];
                        this.new_info["IFZYCL"] = drv.Row["CAIJXSJG"].Equals("是") ? true : false;
                        this.new_info["LB"] = drv.Row["CAIJLB"];
                        this.new_info["SCDJ"] = ToolKit.ParseDecimal(drv.Row["CAIJDJ"]);
                        this.new_info["SDCLB"] = drv.Row["SANDCMC"];
                        this.new_info["SDCXS"] = ToolKit.ParseDecimal(drv.Row["SANDCXS"]);
                    }
                    break;
                case "用户价格库"://"用户材机库":
                    UserQuantityUnitSelect userQuantityUnitSelect = this.xtraTabControl1.SelectedTabPage.Controls[0] as UserQuantityUnitSelect;
                    DataRowView m_UserQuantityUnit = userQuantityUnitSelect.bindingSource1.Current as DataRowView;
                    if (m_UserQuantityUnit != null)
                    {
                        this.new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
                        this.new_info["YSBH"] = m_UserQuantityUnit["YSBH"];
                        this.new_info["YSMC"] = m_UserQuantityUnit["YSMC"];
                        this.new_info["YSDW"] = m_UserQuantityUnit["YSDW"];
                        this.new_info["DEDJ"] = m_UserQuantityUnit["DEDJ"];
                        this.new_info["BH"] = m_UserQuantityUnit["BH"];
                        this.new_info["MC"] = m_UserQuantityUnit["MC"];
                        this.new_info["DW"] = m_UserQuantityUnit["DW"];
                        this.new_info["LB"] = m_UserQuantityUnit["LB"];
                        this.new_info["SCDJ"] = m_UserQuantityUnit["SCDJ"];
                    }
                    break;
                case "补充材机库":
                    RepairQuantityUnitSelect repairQuantityUnitSelect = this.xtraTabControl1.SelectedTabPage.Controls[0] as RepairQuantityUnitSelect;
                    DataRowView m_RepairQuantityUnit = repairQuantityUnitSelect.bindingSource1.Current as DataRowView;
                    if (m_RepairQuantityUnit != null)
                    {
                        this.new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
                        this.new_info["YSBH"] = m_RepairQuantityUnit["YSBH"];
                        this.new_info["YSMC"] = m_RepairQuantityUnit["YSMC"];
                        this.new_info["YSDW"] = m_RepairQuantityUnit["YSDW"];
                        this.new_info["DEDJ"] = m_RepairQuantityUnit["DEDJ"];
                        this.new_info["BH"] = m_RepairQuantityUnit["BH"];
                        this.new_info["MC"] = m_RepairQuantityUnit["MC"];
                        this.new_info["DW"] = m_RepairQuantityUnit["DW"];
                        this.new_info["LB"] = m_RepairQuantityUnit["LB"];
                        this.new_info["SCDJ"] = m_RepairQuantityUnit["SCDJ"];
                    }
                    break;
                default:
                    break;
            }
            return this.new_info;
        }
    }
}