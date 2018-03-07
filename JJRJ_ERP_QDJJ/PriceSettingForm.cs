using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class PriceSettingForm : CBaseForm
    {
        private DataRow m_Current = null;

        public DataRow Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }
        
        public PriceSettingForm()
        {
            InitializeComponent();
        }

        private void PriceSettingForm_Load(object sender, EventArgs e)
        {
            if (this.Activitie == null) return;
            initUserPriceLibrarySetting();
            initepairQuantityUnitSetting();
            initInformationSetting();
        }

        /// <summary>
        /// 用户价格库
        /// </summary>
        private void initUserPriceLibrarySetting()
        {
            UserPriceLibrarySettingForm form = new UserPriceLibrarySettingForm();
            form.Activitie = Activitie;
            form.Current = this.Current;
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            xtraTabPage1.Controls.Add(form);
        }

        /// <summary>
        /// 补充材机库
        /// </summary>
        private void initepairQuantityUnitSetting()
        {
            RepairQuantityUnitSettingForm form = new RepairQuantityUnitSettingForm();
            form.Activitie = Activitie;
            form.Current = this.Current;
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            xtraTabPage2.Controls.Add(form);
        }

        /// <summary>
        /// 云价格库
        /// </summary>
        private void initInformationSetting()
        {
            InformationSettingForm form = new InformationSettingForm();
            form.Activitie = Activitie;
            form.Current = this.Current;
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            xtraTabPage3.Controls.Add(form);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            bool isCalculate = false;
            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    UserPriceLibrarySettingForm u_form = this.xtraTabControl1.SelectedTabPage.Controls[0] as UserPriceLibrarySettingForm;
                    isCalculate = u_form.UpdateInfo();
                    break;
                case 1:
                    RepairQuantityUnitSettingForm r_form = this.xtraTabControl1.SelectedTabPage.Controls[0] as RepairQuantityUnitSettingForm;
                    isCalculate = r_form.UpdateInfo();
                    break;
                case 2:
                    InformationSettingForm i_form = this.xtraTabControl1.SelectedTabPage.Controls[0] as InformationSettingForm;
                    isCalculate = i_form.UpdateInfo();
                    break;
                default:
                    break;
            }
            if (isCalculate)
            {
                this.DialogResult = DialogResult.OK;
                this.Activitie.BeginEdit(this);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}