using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class SelectGallery : BaseForm
    {
        public SelectGallery()
        {
            InitializeComponent();
        }
        private BaseForm p_form;

        public BaseForm P_form
        {
            get { return p_form; }
            set { p_form = value; }
        }
        private void SelectGallery_Load(object sender, EventArgs e)
        {
            SubSegmentForm form = P_form as SubSegmentForm;
            if (form != null)
            {
                //初始化清单
                this.listGallery1.Folder = APP.Application.Global.AppFolder;
                this.listGallery1.Default = this.Activitie;
                //为清单控件添加双击事件
                this.listGallery1.treeList1.DoubleClick += new EventHandler(form.treeList1_DoubleClick);
                this.listGallery1.listBoxControl1.DoubleClick += new EventHandler(form.listBoxControl1_DoubleClick);
            }
        }

       
    }
}
