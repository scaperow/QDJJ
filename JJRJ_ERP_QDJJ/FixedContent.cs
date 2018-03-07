using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using System.Linq;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class FixedContent : BaseForm
    {
        public FixedContent(_Business p_bus)
        {
            
            this.CurrentBusiness = p_bus;
            InitializeComponent();
        }

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
        public DataTable DataSource = null;
        public DataTable Source = null;
        public string QID;
        private ArrayList m_DEBH;
        private ArrayList AllDE;
        public ArrayList DE
        {

            get { return m_DEBH; }
        }
        private DataTable m_table;//当前清单的定额列表
        private void FixedContent_Load(object sender, EventArgs e)
        {
            if (this.CurrentBusiness.Current.IsDZBS&&!APP.Jzbx_pwd)
            {
                this.simpleButtonSXMC1.Enabled = false;
            }
            else
            {
                this.simpleButtonSXMC1.Enabled = true;
            }
            // DataBind();
        }

        public void DataBind()
        {
            //if (this.DataSource != null)
            //{
            lock (this)
            {
                if (!this.DataSource.Columns.Contains("check"))
                {
                    DataColumn dc = this.DataSource.Columns.Add("check", typeof(System.Boolean));
                    dc.DefaultValue = false;
                    foreach (DataRow item in this.DataSource.Rows)
                    {
                        item["check"] = false;
                    }
                }
                if (!this.DataSource.Columns.Contains("Remark"))
                    this.DataSource.Columns.Add("Remark");

                this.bindingSource1.DataSource = this.DataSource;
                this.gridControl2.DataSource = this.bindingSource1;
                DoFiter(this.m_CurrQD.OLDXMBM);
                //}
                if (this.Source != null)
                {
                    if (!this.Source.Columns.Contains("ID"))
                        this.Source.Columns.Add("ID", typeof(int));
                    if (!this.Source.Columns.Contains("PID"))
                        this.Source.Columns.Add("PID", typeof(int));
                    if (!this.Source.Columns.Contains("XMNR"))
                        this.Source.Columns.Add("XMNR", typeof(string));
                    if (!this.Source.Columns.Contains("LB"))
                        this.Source.Columns.Add("LB", typeof(string));
                    BindDE();
                    this.bindingSource2.DataSource = m_table;
                    this.treeListEx1.DataSource = null;
                    this.treeListEx1.DataSource = this.bindingSource2;
                    this.treeListEx1.CheckNodes.Clear();
                    // SetDefault();
                }
            }
        }
        /// <summary>
        /// 若清单默认
        /// </summary>
        private void SetDefault()
        {
            string XMNR = this.m_CurrQD.XMNR;
            if (!string.IsNullOrEmpty(XMNR))
            {
                string[] Arr = XMNR.Split('|');
                string[] XMArr = Arr[0].Split(',');
                string[] DEAyy = Arr[1].Split(',');
                foreach (string item in XMArr)
                {
                    SetXMNR(item);
                }
                AllDE = new ArrayList();
                getALLNodes();
                foreach (string item in DEAyy)
                {
                    SetDE(item);

                }
            }
           
        }
      
        private void SetXMNR(string str)
        {
           // this.bindingSource1.List.Cast<DataView>()
            //IEnumerable<DataRow> v = from n in (this.bindingSource1.List as DataView).Table.AsEnumerable()
            //                             where n["NEIRBH"].ToString() == str.Split('=')[0]
            //                             select n;
            foreach (DataRowView n in this.bindingSource1.List)
            {
               if( n["NEIRBH"].ToString() == str.Split('=')[0]) n["check"] = str.Split('=')[1];
            }
          
        //    IEnumerable<DataRowView> views=
        //                                   where n["NEIRBH"].
        }
        private void SetDE(string str)
        {
            IEnumerable<TreeListNode> nodes=from n in  this.AllDE.Cast<TreeListNode>()
                                             where  n.GetValue("DINGEH").ToString()==str
                                             select n;
            nodes.First().Checked = true;
        }
        private void getALLNodes()
        {
            getALLNodes(this.treeListEx1.Nodes);
        }
   
        private void getALLNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode item in nodes)
            {
                if (item.HasChildren)
                {
                    getALLNodes(item.Nodes);
                }
                else
                {

                    AllDE.Add(item);
                }
            }
        }

        public void DoFiter(string QID)
        {
            this.bindingSource1.Filter = string.Format(" QINGDBH ='{0}'", QID);
            m_DEBH = new ArrayList();
            foreach (DataRowView view in this.bindingSource1)
            {
                view.BeginEdit();
                view["Remark"] = view["NRMC"];
                view.EndEdit();
            }

        }
        private void getDE()
        {
            m_DEBH.Clear();
            foreach (DataRowView item in this.bindingSource1.List)
            {
                if (ToolKit.ParseBoolen(item["check"]))
                {
                    m_DEBH.Add(item);
                }
            }
        }
        private void GetCheckNodes()
        {
            this.treeListEx1.CheckNodes.Clear();
            getNodes(this.treeListEx1.Nodes);
        }
        private void getNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode item in nodes)
            {
                if (item.HasChildren)
                {
                    getNodes(item.Nodes);
                }
                else
                {
                    if (item.Checked)
                    {
                        DataRowView v = this.treeListEx1.GetDataRecordByNode(item) as DataRowView;
                        if (v != null)
                        {
                            if(v["LB"].Equals("子目"))
                            //if(v)
                            this.treeListEx1.CheckNodes.Add(v);
                        }
                    }
                  
                }
            }
        }
        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            DataRowView dv = this.bindingSource1.Current as DataRowView;
            dv.BeginEdit();
            dv["check"] = ck.Checked;
            dv.EndEdit();
            FilterDE();
        }
        /// <summary>
        /// 定额的筛选
        /// </summary>
        private void FilterDE()
        {
            string StrWhere = string.Empty;
            getDE();
            foreach (DataRowView item in m_DEBH)
            {
                StrWhere += "'" + item["NRMC"] + "',";
            }
            if (StrWhere.Length > 0)
            {
                StrWhere = StrWhere.Substring(0, StrWhere.Length - 1);
                this.m_table.DefaultView.RowFilter = string.Format("DINGEMC in ({0}) or XMNR in ({0})", StrWhere);
            }
            else
            {
                this.m_table.DefaultView.RowFilter = string.Empty;
            }
        }
        /// <summary>
        /// 定额的绑定
        /// </summary>
        private void BindDE()
        {
            m_table = this.Source.Clone();
            int i = 0;
            foreach (DataRowView item in this.bindingSource1)
            {
                DataRow row = m_table.NewRow();
                row["DINGEMC"] = item["NRMC"];
                row["ID"] = i++;
                row["PID"] = -1;
                m_table.Rows.Add(row);
                string ZHIYDE = item["ZHIYDE"].ToString();
                string[] DEAyy = ZHIYDE.Split('|');
                foreach (string de in DEAyy)
                {
                    string[] ee = de.Split(',');
                    if (!string.IsNullOrEmpty(ee[0]))
                    {
                        DataRow[] rows = this.Source.Select(string.Format("DINGEH='{0}'", ee[0]));
                        if (rows.Length > 0)
                        {
                            DataRow row1 = m_table.NewRow();
                            m_table.Rows.Add(row1);
                            row1.ItemArray = rows[0].ItemArray;
                            row1["ID"] = i++;
                            row1["PID"] = row["ID"];
                            row1["XMNR"] = item["NRMC"];
                            row1["LB"] = "子目";
                        }
                    }
                }
            }

        }

        private void treeListEx1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                string LB = e.Node.GetValue(this.treeListColumn5).ToString();
                if (LB != "子目")
                {
                    foreach (TreeListNode item in e.Node.Nodes)
                    {
                        item.Checked = e.Node.Checked;
                        treeListEx1_AfterCheckNode(sender, new DevExpress.XtraTreeList.NodeEventArgs(item));
                    }
                }
                //else
                //{
                //    object obj = this.treeListEx1.GetDataRecordByNode(e.Node);
                //    if (e.Node.Checked)
                //    {
                //        if (!this.treeListEx1.CheckNodes.Contains(obj)) this.treeListEx1.CheckNodes.Add(obj);
                //    }
                //    else
                //    {
                //        this.treeListEx1.CheckNodes.Remove(obj);
                //    }
                //}
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SubSegmentForm pform = this.ParentForm as SubSegmentForm;
            if (pform != null) pform.ChangePositionChanged(false);
            if (this.CurrQD == null) return;
           // DialogResult dl = MessageBox.Show("是否删除原有子目并继续？", "提示", MessageBoxButtons.YesNo);
            DialogResult dl = MsgBox.Show("是：删除重套定额！否：追加选中定额！取消：取消本次操作！", MessageBoxButtons.YesNoCancel);
            if (dl == DialogResult.Yes)
            {
                DataRow[] rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("PID={0}", this.CurrQD.ID));
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Delete();
                }

            } 
            if (dl == DialogResult.Cancel)
            {
                return;
            }
            DataRow r = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(this.CurrQD.ID.ToString());
            _ObjectSource.GetObject(this.CurrQD, r);
            GetCheckNodes();
            string DEH = string.Empty;
            int intSD = 0;
            foreach (DataRowView item in this.treeListEx1.CheckNodes)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, item.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName, "GCNR", ++intSD, this.CurrQD.OLDXMBM);
                //GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, item.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName);
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Activitie,this.CurrQD);
                fix.Create(-1,info);

                DEH += item["DINGEH"].ToString()+",";
            }
          
            if (pform != null) pform.ChangePositionChanged(true);
            //if (DEH.Length > 0) DEH = DEH.Substring(0, DEH.Length - 1);
           
            //getDE();
            //string XMNR = string.Empty;
            //foreach (DataRowView item in this.m_DEBH)
            //{
            //    XMNR += item["NEIRBH"] + "=" + item["check"] + ",";
            //}
            //if (XMNR.Length > 0) XMNR = XMNR.Substring(0, XMNR.Length-1);
            //this.CurrQD.XMNR = XMNR + "|" + DEH;
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

        public override void Refresh()
        {
            this.gridView3.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.treeListEx1.ModelName = this.Text;
            this.treeListEx1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            base.Refresh();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.CurrQD == null) return;
            DataRow r = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(this.CurrQD.ID.ToString());
            string TextValue = r["XMMC"].ToString();
            string Titile = _Constant.回车符+"【工程内容】";

                int i = 1;
                string Str = _Constant.回车符 + "【工程内容】" + _Constant.回车符;
                foreach (DataRowView item in this.bindingSource1)
                {
                    if (item["check"].Equals(true))
                    {
                        if (item["Remark"].ToString() != "")
                        {
                            Str += i.ToString() + "." + item["Remark"] + _Constant.回车符;
                            i++;
                        }
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
                if (item.Contains("项目内容】"))
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
                this.gridView3.OptionsBehavior.Editable = false;
                this.treeListEx1.OptionsBehavior.Editable=false;
                this.simpleButton1.Enabled = false;
                this.simpleButtonSXMC1.Enabled = false;
                this.simpleButton3.Enabled = false;
            }
            else
            {
                this.gridView3.OptionsBehavior.Editable = true;
                this.treeListEx1.OptionsBehavior.Editable = true;
                this.simpleButton1.Enabled = true;
                this.simpleButtonSXMC1.Enabled = true;
                this.simpleButton3.Enabled = true;
            }
        }

    }
}