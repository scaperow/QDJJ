using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QuantityUnitSelect : BaseForm
    {
        public QuantityUnitSelect()
        {
            InitializeComponent();
        }

        private void QuantityUnitSelect_Load(object sender, EventArgs e)
        {
            initSysWoodMachineForm();
            initCurrWoodMachine();
            initRepairQuantityUnit();
            initUserQuantityUnit();
        }

        /// <summary>
        /// 系统材机库
        /// </summary>
        private void initSysWoodMachineForm()
        {
            SysWoodMachineForm form = new SysWoodMachineForm();
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            xtraTabPage1.Controls.Add(form);
        }

        /// <summary>
        /// 当前材机库
        /// </summary>
        private void initCurrWoodMachine()
        {
            CurrWoodMachine form = new CurrWoodMachine();
            form.Text = "当前材机库";
            form.DataSource = (from info in this.Activitie.Property.SubSegments.GetAllQuantityUnit.Cast<_Entity_QuantityUnit>()
                              where info.DEDJ != info.SCDJ
                              select info).Distinct(new MergerSL()).ToArray();
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
            form.Text = "补充材机库";
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage4.Controls.Add(form);
        }
    }
}