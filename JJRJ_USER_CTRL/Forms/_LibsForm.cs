using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraEditors.Controls;
using GOLDSOFT.QDJJ.COMMONS.LIB;

namespace GOLDSOFT.QDJJ.CTRL.Forms
{
    public partial class _LibsForm : DevExpress.XtraEditors.XtraForm
    {
        public string Rule = "2009";
        //public string TypeName = "清单库";
        
        /// <summary>
        /// 
        /// </summary>
        private GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData m_Library = null;

        /// <summary>
        /// 获取或设置当前已经选择的库对象
        /// </summary>
        public GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData Library
        {
            get
            {
                return this.m_Library;
            }
            set
            {
                this.m_Library = value;
            }
        }

        /*public _LibsForm()
        {
            InitializeComponent();
        }*/

        public _LibsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建窗体时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _LibsForm_Load(object sender, EventArgs e)
        {
            init();
            this.treeList1.ExpandAll();
            doLoadData();
        }

        private void init()
        {
            //默认的规则
            this.Rule = this.Library.Rule;
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("PID", typeof(int));
            table.Columns.Add("Name", typeof(string));

            DataRow row = null;
            row = table.NewRow();
            row.BeginEdit();
            row["ID"]  = 1;
            row["PID"] = -1;
            row["Name"] = "规则";
            row.EndEdit();
            table.Rows.Add(row);

            if (this.Library.LibType == "清单库")
            {
                row = table.NewRow();
                row.BeginEdit();
                row["ID"] = 2;
                row["PID"] = 1;
                row["Name"] = "2004";
                row.EndEdit();
                table.Rows.Add(row);

                row = table.NewRow();
                row.BeginEdit();
                row["ID"] = 3;
                row["PID"] = 1;
                row["Name"] = "2009";
                row.EndEdit();
                table.Rows.Add(row);
            }
            else
            {
                row = table.NewRow();
                row.BeginEdit();
                row["ID"] = 4;
                row["PID"] = 1;
                row["Name"] = "2006";
                row.EndEdit();
                table.Rows.Add(row);

                row = table.NewRow();
                row.BeginEdit();
                row["ID"] = 5;
                row["PID"] = 1;
                row["Name"] = "2009";
                row.EndEdit();
                table.Rows.Add(row);
            }

            table.AcceptChanges();
            this.treeList1.DataSource = table;
        }

       

        private void doLoadData()
        {
            this.bindingSource1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Libraries"];
            this.bindingSource1.Filter = string.Format("Rule ={0} and LibType ='{1}'", Rule, Library.LibType);
            this.gridControl1.DataSource = this.bindingSource1;
            //this.listBoxControl1.DataSource = this.bindingSource1;
           /* RadioGroupItem[] items = new RadioGroupItem[this.bindingSource1.Count];
            int i = 0;
            foreach (object obj in this.bindingSource1.List)
            {
                DataRowView row = obj as DataRowView;
                if (row != null)
                {
                    items[i] = new RadioGroupItem(row, string.Format("{0}{1}", row["Rule"].ToString(), row["LibName"].ToString()));
                    i++;
                }
            }*/
            
            //this.radioGroup1.Properties.Items.AddRange(items);
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                this.Rule = e.Node.GetValue(0).ToString();
                doLoadData();
            }
            
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "LibName")
            {
                DataRow row = this.gridView1.GetDataRow(e.RowHandle);
                e.DisplayText = string.Format("{0} {1}", row["Rule"], row["LibName"]);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.submit();
        }

        /// <summary>
        /// 最终提交
        /// </summary>
        private void submit()
        {

            DataRowView view = this.bindingSource1.Current as DataRowView;

            if (view != null)
            {
                this.Library.Rule = view["Rule"].ToString();
                this.Library.LibName = view["LibName"].ToString();
                Library.Init(APP.Application.Global.AppFolder);
                
                this.DialogResult = DialogResult.OK;
                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.submit();
        }
    }
}