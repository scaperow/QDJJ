using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList;
/**措施项目费率***/
namespace GOLDSOFT.QDJJ.UI
{
    public partial class SelecCSFL : BaseForm
    {
        public SelecCSFL()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">初始化窗体的默认选择值</param>
        public SelecCSFL(string value)
        {
            m_ReturnValue = value;
            InitializeComponent();
        }

        private string m_ReturnValue;
        /// <summary>
        /// 最终的选择值
        /// </summary>
        public string ReturnValue
        {
            get { return m_ReturnValue; }
            set { m_ReturnValue = value; }
        }


        private void SelecCSFL_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            this.treeList1.DataSource = APP.Application.Global.DataTamp.MeasuresList.Tables["2004措施项目费率"].Copy();
            this.treeList1.ExpandAll();
            this.treeList2.DataSource = APP.Application.Global.DataTamp.MeasuresList.Tables["2006措施项目费率"].Copy();
            this.treeList2.ExpandAll();
            this.treeList3.DataSource = APP.Application.Global.DataTamp.MeasuresList.Tables["2009措施项目费率"].Copy();
            this.treeList3.ExpandAll();
            SelectPage();
        }
        /// <summary>
        /// 默认选择的选项卡
        /// </summary>
        private void SelectPage()
        {
            switch (this.Activitie.Property.Basis.QDGZ)
            {
                case"2009":
                    this.xtraTabControl1.SelectedTabPageIndex = 2;
                    break;
                case "2006":
                    this.xtraTabControl1.SelectedTabPageIndex = 1;
                    break;
                case "2004":
                    this.xtraTabControl1.SelectedTabPageIndex = 0;
                    break;
                default:
                    break;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string value = e.Node.GetValue("Rate").ToString();
            if (!string.IsNullOrEmpty(value))
            {
                this.simpleButton1.Enabled = true;
                this.m_ReturnValue = value;
            }
            else
            {
                this.simpleButton1.Enabled = false;
            }
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList tl = sender as TreeList;
            TreeListHitInfo info = tl.CalcHitInfo(e.Location);
            if (info.Node!=null)
            {
                //DataRowView view = tl.GetDataRecordByNode(info.Node) as DataRowView;
                string value = info.Node.GetValue("Rate").ToString();
                 if (!string.IsNullOrEmpty(value))
                 {
                     this.DialogResult = DialogResult.OK;
                 }
                
            }
        }

       

      
    }
}
