
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 系统人材机
    /// </summary>
    public partial class SysWoodMachineForm : CBaseForm
    {

        public SysWoodMachineForm()
        {
            InitializeComponent();
            init();
        }
        private string m_BH;

        public string BH
        {
            get { return m_BH; }
            set { m_BH = value; }
        }
        public SysWoodMachineForm(_UnitProject p_CUnitProject)
        {
            InitializeComponent();
            this.Activitie = p_CUnitProject;
            init();
        }

        private void SysWoodMachineForm_Load(object sender, EventArgs e)
        {
            init();
            //gridView1.MakeRowVisible(200, false);
            //gridView1.TopRowIndex = 200;
            SetCurrent();
        }
        public override void GlobalStyleChange()
        {
            //base.GlobalStyleChange();
            //subSegmentListData1.treeList1.ModelName = this.Text;
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.gridView2.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }

        private void init()
        {
            listWoodMachineIndex1.Default = this.Activitie;
            listWoodMachineIndex1.Folder = APP.Application.Global.AppFolder;
            this.listWoodMachineIndex1.textEdit1.EditValueChanged += new EventHandler(textEdit1_EditValueChanged);
            this.listWoodMachineIndex1.treeList1.Click += new EventHandler(treeList1_Click);
            DataTable dt = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"].Copy();
            string str = "CAIJSYBH,CAIJBH";
            if (dt.Columns.Contains("ID"))
            {
                str = "ID," + str;
            }
            this.bindingSource1.DataSource = dt.Select("", str).CopyToDataTable();
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit text = sender as TextEdit;
            if (text.Text.Trim() == string.Empty)
            {
                this.bindingSource1.Filter = string.Empty;
            }
            else
            {
                this.bindingSource1.Filter = string.Format("CAIJBH like '%{0}%' or CAIJMC like '%{0}%'", text.Text.Trim());
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeListNode tn = this.listWoodMachineIndex1.treeList1.FocusedNode;
            if (tn != null)
            {

                this.bindingSource1.Filter = string.Format("CAIJSYBH like '%{0}%'", tn.GetValue("CAIJSYBH").ToString().Trim());
            }
        }

        /// <summary>
        /// 设置默认选中项
        /// </summary>
        /// <param name="BH"></param>
        public void SetCurrent()
        {
            DataTable dt = this.bindingSource1.DataSource as DataTable;
            if (dt != null)
            {

                DataRow dr = dt.Select(string.Format("CAIJBH ='{0}'", this.BH)).FirstOrDefault();
                int i = dt.Rows.IndexOf(dr);
                this.bindingSource1.Position = i;
                if (i - 9 > 1)
                {
                    gridView1.TopRowIndex = i - 9;
                }
                else
                {
                    gridView1.TopRowIndex = i;
                }
            }
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }


        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "CAIJDJ":
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
    }
}
