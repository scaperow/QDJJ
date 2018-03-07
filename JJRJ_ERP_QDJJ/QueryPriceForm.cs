using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QueryPriceForm : BaseForm
    {
        public QueryPriceForm()
        {
            InitializeComponent();
        }

        private void GetPageForm()
        {

            //QueryUserPriceLibraryForm queryUserPriceLibary = new QueryUserPriceLibraryForm();
            //queryUserPriceLibary.TopLevel = false;
            //queryUserPriceLibary.Dock = DockStyle.Fill;
            //queryUserPriceLibary.Show();

            BatchEditSummaryForm queryInformationPrice = new BatchEditSummaryForm();
            queryInformationPrice.TopLevel = false;
            queryInformationPrice.Dock = DockStyle.Fill;
            queryInformationPrice.Show();

            XtraTabPage[] pags = new XtraTabPage[2];
            pags[0] = pageOne;
            pags[1] = pageTwo;

            //pageOne.Controls.Add(queryUserPriceLibary);
            pageTwo.Controls.Add(queryInformationPrice);
            this.TabControl.TabPages.AddRange(pags);
            this.TabControl.SelectedTabPageIndex = 0;
        }

        private void QueryPriceForm_Load(object sender, EventArgs e)
        {
            GetPageForm();
        }
    }
}
