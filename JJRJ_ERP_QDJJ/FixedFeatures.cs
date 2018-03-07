using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using GOLDSOFT.QDJJ.UI.Controls;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class FixedFeatures : BaseForm
    {
        public FixedFeatures(_Business p_bus)
        {
            this.CurrentBusiness = p_bus;
            InitializeComponent();
        }
        public DataTable DataSource = null;
        private ArrayList m_DEBH;
        private _Entity_SubInfo m_CurrQD = null;
        /// <summary>
        /// 当前操作的清单
        /// </summary>
        public _Entity_SubInfo CurrQD
        {
            get { return m_CurrQD; }
            set
            {

                m_CurrQD = value;

            }


        }
        public ArrayList DE
        {
            get { return m_DEBH; }
        }
        private void FixedFeatures_Load(object sender, EventArgs e)
        {
            if (this.CurrentBusiness.Current.IsDZBS&&!APP.Jzbx_pwd)
            {
                this.simpleButtonSXMC1.Enabled = false;
                this.simpleButtonSXMC2.Enabled = true; //update by fuqiang 2013年7月5日
            }
            else
            {
                this.simpleButtonSXMC1.Enabled = true;
                this.simpleButtonSXMC2.Enabled = true;
            }
            // DataBind();
        }

        /*public override void Refresh()
        {
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.treeListEx1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            base.Refresh();
        }*/

        public override void GlobalStyleChange()
        {
            base.GlobalStyleChange();
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.treeListEx1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }
        public void DataBind()
        {
            //if (this.DataSource != null)
            {
                if (!this.DataSource.Columns.Contains("xmtz"))
                    this.DataSource.Columns.Add("xmtz", typeof(ComboBoxSoucer));
                if (!this.DataSource.Columns.Contains("Remark"))
                    this.DataSource.Columns.Add("Remark", typeof(string));
                this.bindingSource1.DataSource = this.DataSource;
                this.gridControl1.DataSource = this.bindingSource1;
                DoFiter(this.CurrQD.OLDXMBM);
                BindDE();
                //SetDefalut();
            }
        }
        public void DoFiter(string QID)
        {
            this.bindingSource1.Filter = string.Format(" QINGDBH ='{0}'", QID);
            m_DEBH = new ArrayList();
            this.checkEdit1.Checked = false;
        }


        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            if (e.Column.Caption == "特征值")
            {
                RepositoryItemComboBoxEx RepositoryItemEx = e.RepositoryItem as RepositoryItemComboBoxEx;
                if (RepositoryItemEx == null)
                {
                    DataRowView drv = this.bindingSource1.Current as DataRowView;
                    RepositoryItemComboBoxEx repositoryItemComboBoxEx = new RepositoryItemComboBoxEx(drv["TEZZ"].ToString(), this.Activitie.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单特征定额表"].Copy());
                    repositoryItemComboBoxEx.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    e.RepositoryItem = repositoryItemComboBoxEx;

                }


            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "特征值")
            {
                SendKeys.Send("{ENTER}");
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "特征值")
            {
                ComboBoxSoucer soucer = e.Value as ComboBoxSoucer;
                DataRowView drv = this.bindingSource1.Current as DataRowView;
                if (soucer.DEBH != null)
                {

                    if (soucer.DEBH["TZDEH"] != null)
                    {
                        if (!string.IsNullOrEmpty(soucer.DEBH["TZDEH"].ToString()))
                        {

                            if (!DE.Contains(drv))
                            {

                                DE.Add(drv);
                            }

                        }
                        soucer.DEBH["TZMC"] = drv["TEZMC"] + ":" + soucer.TZname;
                    }
                }
                drv.BeginEdit();
                drv["Remark"] = soucer.TZname;
                drv.EndEdit();

            }
            BindDE();

        }

        private void SetDefalut()
        {
            string XMTZZ = this.m_CurrQD.XMTZZ;
            if (!string.IsNullOrEmpty(XMTZZ))
            {
                string[] Arr = XMTZZ.Split('|');
                string[] TZArr = Arr[0].Split(',');
                string[] DEAyy = Arr[1].Split(',');
                DataTable dt = this.Activitie.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单特征定额表"].Copy();
                if (!dt.Columns.Contains("TZMC"))
                {
                    dt.Columns.Add("TZMC");
                }
                for (int i = 0; i < TZArr.Length; i++)
                {
                    DataRowView v = this.bindingSource1[i] as DataRowView;
                    ComboBoxSoucer cm = new ComboBoxSoucer();
                    cm.TZname = TZArr[i];
                    //cm.DEBH="1-1";
                    v["xmtz"] = cm;
                    if (TZArr[i] != "")
                    {

                        string TZZ = v["TEZZ"].ToString();
                        string[] ArrTZZ = TZZ.Split('|');
                        string deh = string.Empty;

                        for (int j = 0; j < ArrTZZ.Length; j++)
                        {
                            if (ArrTZZ[j].Contains(TZArr[i]))
                            {
                                deh = ArrTZZ[j].Split(',')[1];
                                break;
                            }
                        }

                        DataRow[] rows = dt.Select(string.Format("TZDEH='{0}' and TZZ='{1}'", deh, TZArr[i]));
                        if (rows.Length > 0)
                        {
                            cm.DEBH = rows[0];

                            if (cm.DEBH["TZDEH"] != null)
                            {
                                if (!string.IsNullOrEmpty(cm.DEBH["TZDEH"].ToString()))
                                {

                                    if (!DE.Contains(v))
                                    {

                                        DE.Add(v);
                                    }

                                }
                                cm.DEBH["TZMC"] = v["TEZMC"] + ":" + cm.TZname;
                            }
                        }
                    }


                }
                BindDE();
                foreach (var item in DEAyy)
                {
                    foreach (TreeListNode node in this.treeListEx1.Nodes)
                    {
                        if (node.GetValue("TZDEH").ToString() == item)
                        {
                            node.Checked = true;
                        }
                    }
                }


            }

        }
        /// <summary>
        /// 定额数据绑定
        /// </summary>
        private void BindDE()
        {
            DataTable table = null;
            foreach (DataRowView item in this.m_DEBH)
            {
                ComboBoxSoucer source = item["xmtz"] as ComboBoxSoucer;
                if (source != null)
                {
                    if (source.DEBH != null)
                    {
                        if (table == null)
                        {
                            table = source.DEBH.Table.Clone();
                            if (!table.Columns.Contains("ID"))
                            {
                                DataColumn col = table.Columns.Add("ID", typeof(int));
                                col.AutoIncrement = true;
                                col.AutoIncrementSeed = 1;
                                col.AutoIncrementStep = 1;
                            }
                        }
                        DataRow row = table.NewRow();
                        row.ItemArray = source.DEBH.ItemArray;
                        table.Rows.Add(row);
                    }
                }
            }
            this.treeListEx1.CheckNodes.Clear();
            treeListEx1.DataSource = null;
            treeListEx1.DataSource = table;
            treeListEx1.ExpandAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListEx1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                object obje = this.treeListEx1.GetDataRecordByNode(e.Node);
                if (e.Node.Checked)
                {
                    if (!this.treeListEx1.CheckNodes.Contains(obje))
                        this.treeListEx1.CheckNodes.Add(obje);
                }
                else
                {
                    this.treeListEx1.CheckNodes.Remove(obje);
                }
            }
        }



        /// <summary>
        /// 刷新定额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.CurrQD == null) return;

            SubSegmentForm pform = this.ParentForm as SubSegmentForm;
            if (pform != null) pform.ChangePositionChanged(false);
            DialogResult dr = MsgBox.Show("是：删除重套定额！否：追加选中定额！取消：取消本次操作！", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                //this.CurrQD.RemoveAll();
                //删除所有子目
                DataRow[] rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("PID={0}", this.CurrQD.ID));
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Delete();
                }

            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            DataRow r = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(this.CurrQD.ID.ToString());
            _ObjectSource.GetObject(this.CurrQD, r);
            string DEH = string.Empty;
            int intSD = 0;
            foreach (TreeListNode item1 in this.treeListEx1.Nodes)
            {
                if (!item1.Checked) continue;

                DataRowView item = this.treeListEx1.GetDataRecordByNode(item1) as DataRowView;
                _Entity_SubInfo info = new _Entity_SubInfo();
                DataTable dt = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"];
                if (dt == null) return;
                string xmbm = item["TZDEH"].ToString();
                string temp = xmbm.Split(' ')[0];
                temp = temp.Replace("换", "");
                DataRow[] rows = dt.Select(string.Format(" DINGEH='{0}'", temp));
                if (rows == null) return;
                if (rows.Length < 1) return;
                GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, rows[0], this.Activitie.Property.Libraries.FixedLibrary.FullName, "XMTZ", ++intSD, this.CurrQD.OLDXMBM);
                //GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, rows[0], this.Activitie.Property.Libraries.FixedLibrary.FullName);
                info.XMBM = xmbm;
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, this.CurrQD);
                fix.Create(-1, info);
                DEH += item["TZDEH"].ToString() + ",";
            }
            if (pform != null) pform.ChangePositionChanged(true);
            //if (DEH.Length > 0) DEH = DEH.Substring(0, DEH.Length - 1);
            //string XMNR = string.Empty;
            //foreach (DataRowView item in this.bindingSource1)
            //{
            //    if (item["xmtz"] is ComboBoxSoucer)
            //    {
            //        XMNR += (item["xmtz"] as ComboBoxSoucer).TZname + ",";

            //    }
            //    else
            //    {
            //    XMNR += ""+ ",";
            //    }

            //}
            //if (XMNR.Length > 0) XMNR = XMNR.Substring(0, XMNR.Length - 1);
            //this.CurrQD.XMTZZ = XMNR + "|" + DEH;
            // RefreshSubSegment();
        }
        /// <summary>
        /// 分部分项的刷新
        /// </summary>
        private void RefreshSubSegment()
        {
            SubSegmentForm form = this.ParentForm as SubSegmentForm;
            if (form != null)
            {
                form.subSegmentListData1.DataBind();
                if (this.CurrQD != null)
                    form.subSegmentListData1.FocusedNode(this.CurrQD.ID);
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit editer = sender as DevExpress.XtraEditors.CheckEdit;
            foreach (TreeListNode item in this.treeListEx1.Nodes)
            {
                item.Checked = editer.Checked;
                treeListEx1_AfterCheckNode(editer, new DevExpress.XtraTreeList.NodeEventArgs(item));
                // item.CheckState = CheckState.Checked;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.CurrQD == null) return;
            DataRow r = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(this.CurrQD.ID.ToString());
            string TextValue = r["XMMC"].ToString();
            string Titile = _Constant.回车符 + "【项目特征】";
            int i = 1;
            string Str = _Constant.回车符 + "【项目特征】" + _Constant.回车符;
            foreach (DataRowView item in this.bindingSource1)
            {
                if (item["Remark"].ToString() != "")
                {
                    Str += i.ToString() + "." + item["TEZMC"] + ":" + item["Remark"] + _Constant.回车符;
                    i++;
                }
            }
            Str = Str.TrimEnd();
            string Result = GLODSOFT.QDJJ.BUSINESS._Methods.SetTextBox(TextValue, Str, Titile);
            r.BeginEdit();
            r["XMMC"] = Result;
            r.EndEdit();
            SubSegmentForm form = this.ParentForm as SubSegmentForm;
            if (form != null) form.subSegmentListData1.treeList1.Refresh();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string str = this.CurrQD.XMMC;
            string[] Ayy = str.Split('【');
            foreach (string item in Ayy)
            {
                if (item.Contains("项目特征】"))
                {
                    string a = "【" + item;
                    str = str.Replace(a, "");
                }
            }
            this.CurrQD.XMMC = str;
        }

        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.gridView1.OptionsBehavior.Editable = false;
                this.treeListEx1.OptionsBehavior.Editable = false;
                this.simpleButtonSXMC2.Enabled = false;
                this.simpleButtonSXMC1.Enabled = false;
                this.simpleButtonQXSX.Enabled = false;
                this.checkEdit1.Enabled = false;
            }
            else
            {
                this.gridView1.OptionsBehavior.Editable = true;
                this.treeListEx1.OptionsBehavior.Editable = true;
                this.simpleButtonSXMC2.Enabled = true;
                this.simpleButtonSXMC1.Enabled = true;
                this.simpleButtonQXSX.Enabled = true;
                this.checkEdit1.Enabled = true;
            }
        }
    }
}
