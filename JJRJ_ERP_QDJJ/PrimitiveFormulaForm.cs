using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using System.Reflection;
using System.Globalization;
using System.CodeDom.Compiler;
using Microsoft.VisualBasic;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class PrimitiveFormulaForm : CBaseForm
    {
        /// <summary>
        /// 是否计算
        /// </summary>
        private bool isCalculation = false;

        /// <summary>
        /// 计算结果
        /// </summary>
        private string m_Result = string.Empty;

        /// <summary>
        /// 获取：计算结果
        /// </summary>
        public string Result
        {
            get { return m_Result; }
        }

        /// <summary>
        /// 计算公式
        /// </summary>
        private string m_Formula = string.Empty;

        /// <summary>
        /// 获取或设置：图元公式
        /// </summary>
        private string TYGS
        {
            get
            {
                string m_TYGS = this.cmboxPrivmitiveName.SelectedIndex.ToString() + "," + this.imgLstBxControl.SelectedIndex.ToString() + "-";
                foreach (DataRow item in this.dt.Rows)
                {
                    m_TYGS += item["MC"].ToString();
                    m_TYGS += "," + item["SZ"].ToString() + "|";
                }
                return m_TYGS;
            }
            set
            {

                string[] m_TYGS = value.Split('-');
                if (m_TYGS.Length == 2)
                {
                    string[] m_index = m_TYGS[0].Split(',');
                    if (m_index.Length == 2)
                    {
                        this.cmboxPrivmitiveName.SelectedIndex = Convert.ToInt32(m_index[0]);
                        this.imgLstBxControl.SelectedIndex = Convert.ToInt32(m_index[1]);
                        string[] row = m_TYGS[1].Split('|');
                        if (this.dt.Rows.Count == row.Length - 1)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] coll = row[i].Split(',');
                                DataRow[] dr = dt.Select(string.Format("MC='{0}'", coll[0]));
                                if (dr.Length == 1)
                                {
                                    dr[0][2] = coll[1];
                                }
                            }
                            DataRowView drv = this.bindingSource2.Current as DataRowView;
                            if (drv != null)
                            {
                                Translation();
                            }
                        }
                    }
                }
            }
        }

        private DataRow m_Current = null;

        /// <summary>
        /// 获取或设置：当前选中行
        /// </summary>
        public DataRow Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        /// <summary>
        /// 当前操作图元公式
        /// </summary>
        private DataTable dt = null;

        public PrimitiveFormulaForm()
        {
            InitializeComponent();
        }

        private void PrimitiveFormulaForm_Load(object sender, EventArgs e)
        {
            this.CreateDataTable();
            this.cmboxPrivitiveNameBing();
            this.gridControl1.DataSource = this.bindingSource2;
            this.cmboxPrivmitiveName_SelectedIndexChanged(null, null);
            if (this.Current != null && !this.Current["TYGS"].Equals(string.Empty))
            {
                this.TYGS = this.Current["TYGS"].ToString();
            }
        }

        /// <summary>
        /// 加载图元公式
        /// </summary>
        private void cmboxPrivitiveNameBing()
        {
            this.bindingSource1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["PrimitiveFormula"];
            this.imgLstBxControl.DataSource = this.bindingSource1;
        }

        /// <summary>
        /// 筛选图元公式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxPrivmitiveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = string.Format("TypeName = '{0}'", this.cmboxPrivmitiveName.EditValue.ToString());
        }

        /// <summary>
        /// 选择图元公式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgLstBxControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                LoadCreate(this.bindingSource1.Current as DataRowView);
            }
        }

        /// <summary>
        /// 修改值时触发替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SZ")
            {
                DataRowView drv = this.bindingSource2.Current as DataRowView;
                if (drv != null)
                {
                    Translation();
                }
            }
        }

        /// <summary>
        /// 提取公式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.isCalculation)
            {
                this.m_Result = this.m_Formula;
                this.Current["TYGS"] = TYGS;
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 提取结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonFormula_Click(object sender, EventArgs e)
        {
            if (this.isCalculation)
            {
                this.Current["TYGS"] = TYGS;
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 处理当前选中的图元公式数据
        /// </summary>
        /// <param name="drv"></param>
        private void LoadCreate(DataRowView drv)
        {
            if (drv != null)
            {
                this.dt.Clear();
                string m_Parameter = drv["Parameter"].ToString();
                string[] s_Parameter = m_Parameter.Split(',');
                foreach (string item in s_Parameter)
                {
                    string[] cs = item.Split(':');
                    DataRow n_dr = dt.NewRow();
                    if (cs.Length == 2)
                    {
                        n_dr["FH"] = cs[0].ToString();
                        n_dr["MC"] = item;
                    }
                    else
                    {
                        n_dr["FH"] = item;
                        n_dr["MC"] = item;
                    }
                    this.dt.Rows.Add(n_dr);
                }
                this.bindingSource2.DataSource = this.dt;
                this.memoEdit1.Text = drv["Formula"].ToString();
                this.memoEdit2.Text = drv["Formula"].ToString()+"=0.0000";
            }
        }

        /// <summary>
        /// 创建图元公式参数显示结构
        /// </summary>
        private void CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("FH", typeof(string));//符号
            dt.Columns.Add("MC", typeof(string));//名称
            dt.Columns.Add("SZ", typeof(decimal));//数值
        }

        /// <summary>
        /// 动态替换公式中指定的符号
        /// </summary>
        private void Translation()
        {
            this.m_Formula = this.memoEdit1.Text.Trim();
            int jscs = 0;
            foreach (DataRow item in this.dt.Rows)
            {
                if (item["SZ"].ToString().Length > 0)
                {
                    this.m_Formula = m_Formula.Replace(item["FH"].ToString(), item["SZ"].ToString());
                    jscs++;
                }
            }
            this.memoEdit2.Text = m_Formula;
            this.m_Result = ToolKit.Expression(m_Formula).ToString("F4").ToString();
            this.memoEdit2.Text = m_Formula + " = " + this.m_Result;
            this.isCalculation = jscs == this.dt.Rows.Count;
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            decimal not = 0m;
            if (!decimal.TryParse(e.Value.ToString(), out not) && e.Value.ToString() != string.Empty)
            {
                e.ErrorText = "请正确输入数字或按Esc重设";
                e.Valid = false;
            }
        }

        private void imgLstBxControl_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
           // e.Item
        }
    }
}
