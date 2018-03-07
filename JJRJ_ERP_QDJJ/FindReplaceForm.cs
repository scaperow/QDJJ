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
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class FindReplaceForm : BaseForm
    {
        public FindReplaceForm()
        {
            InitializeComponent();

        }
        public SubSegmentForm sform = null;


        private void FindReplaceForm_Load(object sender, EventArgs e)
        {
            Init();
        }
        private IEnumerable<_ObjectInfo> Source;

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void Init()
        {
            DataTable dt = this.Activitie.StructSource.ModelSubSegments.Copy();
            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            dt.AcceptChanges();
            this.bindingSource1.DataSource = dt;
            this.treeListEx1.DataSource = this.bindingSource1;
            this.bindingSource1.Filter = " LB ='清单' or  LB='子目'";
            this.checkEdit4_CheckedChanged(null, null);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {

        }


        /// <summary>
        /// 查找全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Fiter(this.textEdit1.Text.Trim());
        }

        private void Fiter(string KeyWords)
        {
            string fitler = string.Format("(XMMC like '%{0}%' or XMBM like '%{0}%')", KeyWords);

            if (!string.IsNullOrEmpty(KeyWords))
            {
                this.bindingSource1.Filter = fitler + " and  LB='子目' or LB='清单'";
                if (this.checkEdit1.Checked)
                {

                    this.bindingSource1.Filter = fitler + " and   LB='清单'";
                }
                else if (this.checkEdit2.Checked)
                {
                    this.bindingSource1.Filter = fitler + " and   LB='子目'";
                }
            }
            else
            {
                this.bindingSource1.Filter = "LB='子目' or LB='清单'";
            }

        }
        /// <summary>
        /// 查找下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void simpleButton2_Click(object sender, EventArgs e)
        //{
        //    if (this.bindingSource1.Count - 1 == this.bindingSource1.Position)
        //    {
        //        this.bindingSource1.Position = 0;
        //    }
        //    else
        //    {
        //        MoveNext();
        //    }

        //    //DataRowView drv = new DataRowView();

        //}

        //private void MoveNext()
        //{
        //    while (true)
        //    {
        //        string text ="";
        //        if (this.xtraTabControl2.SelectedTabPage.Text == "查找")
        //        {
        //            text = this.textEdit1.Text.Trim();
        //        }
        //        else
        //        {
        //            text = this.textEdit2.Text.Trim();
        //        }

        //        this.bindingSource1.MoveNext();
        //        if (this.bindingSource1.Current == null) return;
        //        DataRowView drv = this.bindingSource1.Current as DataRowView;

        //        bool flag = false;
        //        if (this.checkEdit4.Checked && !this.checkEdit3.Checked)
        //            {
        //                flag = getWhere(drv.Row, text) && drv["LB"].Equals("清单");
        //            }
        //        else if (!this.checkEdit4.Checked && this.checkEdit3.Checked)
        //        {
        //            flag = getWhere(drv.Row, text) && drv["LB"].ToString().Contains("子目"); 
        //        }
        //        else
        //        {
        //            flag = getWhere(drv.Row, text);
        //        }


        //      //  if (flag || this.bindingSource1.Position == this.bindingSource1.Count - 1) { return; }
        //        if ((!flag) && this.bindingSource1.Position == this.bindingSource1.Count-1)
        //        {
        //            this.bindingSource1.Position = 0; return;
        //        } 

        //        if (flag) { return; }
        //    }
        //}

        ///// <summary>
        ///// 替换
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void simpleButton7_Click(object sender, EventArgs e)
        //{
        //    if (this.bindingSource1.Current == null) return;
        //    if (string.IsNullOrEmpty(this.textEdit2.Text) || string.IsNullOrEmpty(this.textEdit3.Text))
        //    {
        //        Alert("请输入关键字");
        //        return;
        //    }
        //    DataRowView drv = this.bindingSource1.Current as DataRowView;

        //    drv["XMMC"] = drv["XMMC"].ToString().Replace(this.textEdit2.Text, this.textEdit3.Text);
        //    MoveNext();
        //    this.bindingSource1.ResetBindings(false);
        //    //drv["xmmc"] = drv["xmmc"].ToString().Replace(this.textEdit2.Text, this.textEdit3.Text);
        //}
        /// <summary>
        /// 全部替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton8_Click_1(object sender, EventArgs e)
        {
            //this.bindingSource1.SuspendBinding();
            if (string.IsNullOrEmpty(this.textEdit2.Text) || string.IsNullOrEmpty(this.textEdit3.Text))
            {
                Alert("请输入关键字");
                return;
            }

            foreach (DataRowView item in this.bindingSource1)
            {
                DataRow drv = item.Row;
                if (this.checkEdit4.Checked)
                {
                    if (drv["LB"].Equals("清单"))
                    {
                        drv.BeginEdit();
                        drv["XMMC"] = drv["XMMC"].ToString().Replace(this.textEdit2.Text, this.textEdit3.Text);

                        drv.EndEdit();

                        this.bindingSource1.Filter = this.bindingSource1.Filter + string.Format("or ID={0}", drv["ID"]);
                    }
                }
                if (this.checkEdit3.Checked)
                {
                    if (drv["LB"].ToString().Contains("子目"))
                    {
                        drv.BeginEdit();
                        drv["XMMC"] = drv["XMMC"].ToString().Replace(this.textEdit2.Text, this.textEdit3.Text);
                        drv.EndEdit();
                        // this.bindingSource1.EndEdit();
                        this.bindingSource1.Filter = this.bindingSource1.Filter + string.Format("or ID={0}", drv["ID"]);
                    }
                }
            }
            //for (int i = 0; i < this.bindingSource1.Count; i++)
            //{
            //    if (this.checkEdit4.Checked)
            //    {
            //        DataRowView drv = this.bindingSource1[i] as DataRowView;
            //        if (drv["LB"].Equals("清单"))
            //        {
            //            drv.BeginEdit();
            //            drv["XMMC"] = drv["XMMC"].ToString().Replace(this.textEdit2.Text, this.textEdit3.Text);
            //            drv.BeginEdit();
            //            this.bindingSource1.Filter = this.bindingSource1.Filter + string.Format("or ID={0}", drv["ID"]);
            //        }
            //    }
            //    if (this.checkEdit3.Checked)
            //    {
            //        DataRowView drv = this.bindingSource1[i] as DataRowView;
            //        if (drv["LB"].ToString().Contains("子目"))
            //        {
            //            drv.BeginEdit();
            //            drv["XMMC"] = drv["XMMC"].ToString().Replace(this.textEdit2.Text, this.textEdit3.Text);
            //            drv.BeginEdit();
            //            this.bindingSource1.Filter = this.bindingSource1.Filter + string.Format("or ID={0}", drv["ID"]);
            //        }
            //    }
            //}
            this.bindingSource1.ResetBindings(false);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //this.Activitie.SubSegment.CTEntitySubSegment = this.m_DataSource;
            this.Close();
        }
        private void checkEdit1_Click(object sender, EventArgs e)
        {
            CheckEdit edite = sender as CheckEdit;
            foreach (Control item in xtraTabPage5.Controls)
            {
                if (item is CheckEdit && !item.Equals(edite))
                {
                    if ((item as CheckEdit).Text.Equals(edite.Text))
                    {
                        (item as CheckEdit).Checked = !edite.Checked;
                    }
                    else
                    {
                        (item as CheckEdit).Checked = edite.Checked;
                    }
                }
            }
            foreach (Control item in xtraTabPage4.Controls)
            {
                if (item is CheckEdit && !item.Equals(edite))
                {
                    if ((item as CheckEdit).Text.Equals(edite.Text))
                    {
                        (item as CheckEdit).Checked = !edite.Checked;
                    }
                    else
                    {
                        (item as CheckEdit).Checked = edite.Checked;
                    }
                }
            }

        }
        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            if (e.Column.FieldName == "XMMC")
            {
                if (e.Value != null)
                    e.Value = e.Value.ToString().Split('【')[0];
            }
        }


        private void textEdit1_KeyUp(object sender, KeyEventArgs e)
        {

            TextEdit t = sender as TextEdit;
            this.textEdit2.Text = t.Text;
        }

        private void textEdit2_KeyUp(object sender, KeyEventArgs e)
        {
            TextEdit t = sender as TextEdit;
            this.textEdit1.Text = t.Text;
        }

        private void FindReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = this.bindingSource1.DataSource as DataTable;
            if (dt != null)
            {
                DataTable ChangeTable = dt.GetChanges();
                if (ChangeTable != null)
                {
                    this.Activitie.StructSource.ModelSubSegments.Merge(ChangeTable, false);
                }
            }
        }

        private void treeListEx1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            DevExpress.XtraTreeList.TreeList tl = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.XtraTreeList.TreeListHitInfo tinfo = tl.CalcHitInfo(e.Location);
            if (tinfo.Node != null)
            {
                sform.subSegmentListData1.FocusedNode(ToolKit.ParseInt(tinfo.Node.GetValue("ID")));
            }
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit4.Checked)
            {
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    simpleButton8.Enabled = false;
                }
                else 
                {
                    simpleButton8.Enabled = true;
                }
                //simpleButton8.Enabled = !this.CurrentBusiness.Current.IsDZBS;
            }
            else
            {
                simpleButton8.Enabled = true;
            }
        }

    }
}
