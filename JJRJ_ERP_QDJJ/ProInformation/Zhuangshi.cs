using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using GOLDSOFT.QDJJ.CTRL;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class Zhuangshi : BaseInfo
    {
        public Zhuangshi()
        {
            string Path = APP.Application.Global.AppFolder.FullName + "库文件\\图集库\\陕标09系列建筑图集.tjsx";
            this.ds = GetTJ(Path);
            InitializeComponent();
        }
        public DataRowView CurrRow
        {
            get
            {
                return this.bindingSource1.Current as DataRowView;
            }
        }
        /// <summary>
        /// 图集定额
        /// </summary>
        private DataTable m_TabTJDE;
        /// <summary>
        /// 图集类型
        /// </summary>
        private DataTable m_TabTJLX;
        DataTable m_TJNR;
        private DataTable m_TabTJZF;
        DataSet ds;

        public override object Parm
        {
            get
            {
                return base.Parm;
            }
            set
            {
                this.gridView3.Columns["BEIZHU"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                Fiter(value.ToString());
                IsFK(value.ToString());
            }
        }
        //public Zhuangshi(_UnitProject p_CUnitProject)
        //{
        //   // this.Activitie = p_CUnitProject;
        //    this.ds = this.Activitie.Property.Libraries.AtlasGallery.LibraryDataSet;
        //    InitializeComponent();
        //}
        private DataSet GetTJ(string Path)
        {
            DataSet ds = null;
            ds = GOLDSOFT.QDJJ.COMMONS.CFiles.BinaryDeserializeForLib(Path);
            return ds;
        }
        private void Zhuangshi_Load(object sender, EventArgs e)
        {
            init();
        }
        private void Fiter(string str)
        {
            this.bindingSource1.Filter = string.Format("SYBH = {0}", str);
            this.bindingSourceRe.Filter = string.Format("SYBH = {0}", str);
            this.bindingSource1_PositionChanged(null, null);
        }
        private void IsFK(string str)
        {
            int m = ToolKit.ParseInt(str);
            if ((m >= 28 && m <= 35) || m == 37 ||( m>=70&&m<=76))
            {
                gridColumn9.OptionsColumn.AllowEdit = true;
                gridColumn9.Caption = "缝宽";
            }
            else
            {
                gridColumn9.OptionsColumn.AllowEdit = false;
                gridColumn9.Caption = "厚度";
            }

            if (m >= 28)
            {
                this.gridColumn3.Visible = false;
            }
            else
            {
                this.gridColumn3.Visible = true;
            }

        }
        private void init()
        {
            if (ds == null) return;
            this.m_TabTJDE = this.ds.Tables["图集定额表"].Copy();
            this.m_TabTJLX = this.ds.Tables["图集类型表"].Copy();
            this.m_TJNR = APP.UnInformation.InformationTable.TJTable;
            this.m_TabTJZF = APP.UnInformation.InformationTable.ZFTable;
            //
            this.bindingSource1.DataSource = this.m_TJNR;
            this.bindingSourceRe.DataSource = this.ds.Tables["图集内容清单表"].Copy();//下拉框的绑定
            this.bindingSourceRe.Sort = "ID asc";
            this.repositoryItemLookUpEdit1.DataSource = this.bindingSourceRe;
            this.bindingSource2.DataSource = this.m_TabTJZF;
            this.gridControl3.DataSource = this.bindingSource1;
            this.treeListEx2.DataSource = this.bindingSource2;
            this.gridColumn2.ColumnEdit = repositoryItemComboBox1;
            this.InitEvent();

        }

        private void InitEvent()
        {
            APP.UnInformation.OnCheck -= new _UnInformation.CheckHandler(UnInformation_OnCheck);
            APP.UnInformation.OnCheck += new _UnInformation.CheckHandler(UnInformation_OnCheck);
            this.m_TJNR.ColumnChanged -= new DataColumnChangeEventHandler(m_TJNR_ColumnChanged);
            this.m_TJNR.ColumnChanged += new DataColumnChangeEventHandler(m_TJNR_ColumnChanged);
            this.m_TJNR.RowChanged -= new DataRowChangeEventHandler(m_TJNR_RowChanged);
            this.m_TJNR.RowChanged += new DataRowChangeEventHandler(m_TJNR_RowChanged);
            this.m_TabTJZF.RowChanged -= new DataRowChangeEventHandler(m_TJNR_RowChanged);
            this.m_TabTJZF.RowChanged += new DataRowChangeEventHandler(m_TJNR_RowChanged);
        }

        /// <summary>
        /// 通知改变行状态
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Check"></param>
        private void UnInformation_OnCheck(object Sender, bool Check)
        {
            DataRow r = Sender as DataRow;
            if (r == null) return;
            string tj = r["TJ"].ToString();
            string[] arr = tj.Split(',');
            string ID = arr[arr.Length - 1];

            if (ToolKit.ParseInt(ID) != 0)
            {
                DataRow[] rows = this.m_TJNR.Select(string.Format(" Key={0}", ID));
                if (rows.Length > 0) rows[0]["IsFresh"] = Check;
            }

        }

        private void m_TJNR_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //this.Activitie.BeginEdit(null);
        }


        void m_TJNR_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "LXID")
            {
                bindingSource1_PositionChanged(null, null);
            }
        }
        /// <summary>
        /// 根据选中图集内容筛选定额
        /// </summary>
        /// <param name="view">当前选中的图集内容</param>
        private DataTable FilterDE(DataRowView view)
        {
            DataTable dt = this.m_TabTJDE.Clone();
            foreach (DataRow item in this.m_TabTJDE.Select(string.Format("SYBH='{0}' and TJBH ='{1}'", view["SYBH"], view["TJBH"])))
            {
                DataRow row = dt.NewRow();
                row.ItemArray = item.ItemArray;
                dt.Rows.Add(row);
            }
            if (view["LXID"] != null)
            {
                if (!string.IsNullOrEmpty(view["LXID"].ToString()))
                {
                    foreach (DataRow item in this.m_TabTJLX.Select(string.Format("ID ={0}", view["LXID"])))
                    {
                        DataRow row = dt.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DEDW"] = item["DEDW"];
                        row["GCXS"] = item["GCXS"];
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }
        private void FilterZF(string TJBH)
        {
            if (!string.IsNullOrEmpty(TJBH))
                this.bindingSource2.Filter = string.Format("TJID ={0}", TJBH);
        }
        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            DataRowView view = this.bindingSource1.Current as DataRowView;
            if (view != null)
            {
                this.memoEdit1.Text = "图集名称：" + view["TJMC"] + "\r\n"
                              + "备注：" + view["BZ"].ToString() + "";
                FilterZF(view["Key"].ToString());
                string StrWher = string.Format("QDBH='{0}' and TJ='{1}'", view["QDBH"], view["BeiZhu"]);//GetTJ(view));
                this.InformationForm.Fiter(StrWher);
            }
            else { this.InformationForm.Fiter("1<>1"); this.bindingSource2.Filter = "1<>1"; }
        }

        private void SetRow()
        {

            StringBuilder sb = new StringBuilder();
            DataRowView view = this.bindingSource1.Current as DataRowView;

            string strTJ = "";
            if (string.IsNullOrEmpty(view["BeiZhu"].ToString()))
            {
                strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                view["BeiZhu"] = strTJ;
            }
            else
            {
                strTJ = view["BeiZhu"].ToString();
            }

            DataRow r = APP.UnInformation.QDTable.NewRow();
            DataTable dt = FilterDE(view);
            r["QDBH"] = view["QDBH"];
            r["QDMC"] = view["QDMC"];
            r["DW"] = view["QDDW"];
            r["XS"] = 1;
            decimal d = ToolKit.ParseDecimal(view["GCL"]) * 1;//清单工程量
            r["GCL"] = d;
            //String tj = GetTJ(view);
            r["TJ"] = strTJ;// tj;
            if (view["QDBH"].ToString().Length > 6)
                r["ZJ"] = view["QDBH"].ToString().Substring(0, 6);
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow item in dt.Rows)
            {
                DataRow row = APP.UnInformation.DETable.NewRow();
                row["DEBH"] = item["DEBH"];
                //row["DEMC"] = item["DEMC"];
                if (!string.IsNullOrEmpty(toString(item["HSLX"])))
                {
                    row["DEMC"] = item["DEMC"] + "换：//" + item["HSLX"];
                }
                else
                {
                    row["DEMC"] = item["DEMC"];
                }
                row["DW"] = item["DEDW"];
                row["XS"] = item["GCXS"];
                row["HSQ"] = item["HSQ"];
                row["HSH"] = item["HSH"];
                row["QDBH"] = view["QDBH"];
                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * d;
                row["TJ"] = strTJ;// tj;
                rows.Add(row);
                sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
            }
            //提取做法包含的定额
            DataRow[] rows1 = this.m_TabTJZF.Select(string.Format(" TJID={0}", view["Key"]));
            foreach (DataRow row1 in rows1)
            {
                if (!string.IsNullOrEmpty(row1["LXID"].ToString()))
                {
                    string[] LXIDArr = row1["LXID"].ToString().Split(',');
                    string[] XSArr = row1["XS"].ToString().Split(',');
                    for (int i = 0; i < LXIDArr.Length; i++)
                    // foreach (string str in LXIDArr)
                    {
                        string str = LXIDArr[i];
                        if (!string.IsNullOrEmpty(str))
                        {
                            DataRow[] rows2 = this.ds.Tables["图集类型表"].Select(string.Format(" ID={0}", str));
                            if (rows2.Length > 0)
                            {

                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = rows2[0]["DEBH"];
                                row["DEMC"] = rows2[0]["DEMC"];
                                row["DW"] = rows2[0]["DEDW"];
                                row["XS"] = XSArr[i];
                                //row["HSQ"] = rows2[0]["HSQ"];
                                //row["HSH"] = rows2[0]["HSH"];
                                row["QDBH"] = view["QDBH"];
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * d;
                                row["TJ"] = strTJ;// tj;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                            }
                        }
                    }
                }
            }

            //r["BZ"] = sb.ToString() + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
            if (string.IsNullOrEmpty(r["TJ"].ToString()))
            {
                r["BZ"] = sb.ToString() + strTJ;
                r["TJ"] = strTJ;
            }
            else
            {
                r["BZ"] = sb.ToString() + r["TJ"].ToString();
            }
            this.InformationForm.Add(r, rows);
        }
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetTJ(DataRowView view)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("图集:");
            sb.Append(view["SYBH"] + "," + view["TJBH"] + ",");
            DataRow[] rows = this.m_TabTJZF.Select(string.Format(" TJID={0}", view["Key"]));
            foreach (DataRow row in rows)
            {
                if (row["LXID"] != null)
                    if (row["LXID"].ToString() != string.Empty)
                    {
                        sb.Append(row["LXID"] + ",");
                    }
                //sb.Append(+",");
            }
            sb.Append(view["Key"]);
            return sb.ToString();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRowView view = this.bindingSource1.Current as DataRowView;
            if (view == null) return;
            //this.InformationForm.Remove(view["QDBH"].ToString(), GetTJ(view));
            this.InformationForm.Remove(view["QDBH"].ToString(), view["BeiZhu"].ToString());
            SetRow();
            simpleButton2_Click(sender, e);
        }
        /// <summary>
        /// 刷新工程量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataRowView drCurr = this.bindingSource1.Current as DataRowView;
            if (drCurr == null) return;
            //this.InformationForm.UpdateGCL(drCurr["QDBH"].ToString(), GetTJ(drCurr), ToolKit.ParseDecimal(drCurr["GCL"]));
            this.InformationForm.UpdateGCL(drCurr["QDBH"].ToString(), drCurr["BeiZhu"].ToString(), ToolKit.ParseDecimal(drCurr["GCL"]));
        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit but = sender as DevExpress.XtraEditors.ButtonEdit;

            TJLXSelect form = new TJLXSelect();
            form.Activitie = this.Activitie;
            form.TJBH = but.Text;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Source = this.m_TabTJLX;
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {
                DataRowView view = this.bindingSource1.Current as DataRowView;
                if (view != null)
                {
                    view.BeginEdit();
                    view["LXID"] = form.LXID;
                    view.EndEdit();
                }
            }
        }
        private void gridView3_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            switch (e.Column.FieldName)
            {

                case "TJBH":
                    e.RepositoryItem = this.repositoryItemLookUpEdit1;
                    break;
                case "OP":
                    if (!string.IsNullOrEmpty(e.CellValue.ToString()))
                    {
                        // e.Column.OptionsColumn.ReadOnly = false;
                        e.RepositoryItem = this.repositoryItemButtonEdit2;

                    }
                    else
                    {
                        // e.RepositoryItem = null;
                        //e.Column.OptionsColumn.ReadOnly = true;
                    }
                    break;
                case "BEIZHU":
                    e.RepositoryItem = repositoryItemMemoExEdit1;
                    break;
                default:
                    break;
            }
            //if (e.Column.FieldName == "TJBH") e.RepositoryItem = this.repositoryItemButtonEdit1;

        }
        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            
            switch (e.Column.FieldName)
            {
                case "BW":
                    string val = e.Value.ToString();
                    foreach (string item in this.repositoryItemComboBox1.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.repositoryItemComboBox1.SaveCusotmerValue(val);

                    break;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            string str = TJZF();
            this.InformationForm.SetFixedName("标准图集", str);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.bindingSource1.DataSource as DataTable;
                DataRowView currRow = this.bindingSource1.Current as DataRowView;
                int index = dt.Rows.IndexOf(currRow.Row);

                if (index <= 0)
                    return;
                DataRow newRow = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newRow[i] = currRow[i];
                }
                this.bindingSource1.MovePrevious();
                dt.Rows.RemoveAt(index);
                dt.Rows.InsertAt(newRow, index - 1);

                this.bindingSource1.MovePrevious();

                //重新排列序号
                for (int i = this.bindingSource1.Count; i > 0; i--)
                {
                    (this.bindingSource1[i - 1] as DataRowView)["XH"] = i;
                }
                ///刷新
                //this.bindingSource1.ResetBindings(false);

            }
            catch (Exception)
            { }
            
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.bindingSource1.DataSource as DataTable;
                DataRowView currRow = this.bindingSource1.Current as DataRowView;
                int index = dt.Rows.IndexOf(currRow.Row);

                if (index >= dt.Rows.Count)
                    return;
                DataRow newRow = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newRow[i] = currRow[i];
                }
                dt.Rows.RemoveAt(index);
                dt.Rows.InsertAt(newRow, index + 1);


                this.bindingSource1.MoveNext();
                ///重新排列序号
                for (int i = this.bindingSource1.Count; i > 0; i--)
                {
                    (this.bindingSource1[i - 1] as DataRowView)["XH"] = i;
                }
                ///刷新
                this.bindingSource1.ResetBindings(false);
            }
            catch (Exception)
            { }
        }

        private string TJZF()
        {
            if (this.bindingSource1.Current == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("【标准图集】\r\n");
            if (this.ds == null) return "";
            string str = "";
            if (this.Parm != null)
            {
                str = " SYBH=" + Parm;
                DataRow[] rows1 = this.ds.Tables["图集索引表"].Select(str);
                if (rows1.Length > 0)
                {
                    str = string.Format(" SYBH={0}", rows1[0]["PARENTID"]);
                    DataRow[] rows = this.ds.Tables["图集索引表"].Select(str);
                    if (rows.Length > 0)
                    {
                        if (this.bindingSource1.Current == null)
                        {
                            // sb.Append(rows[0]["MUNR"] + ":" + (this.bindingSource1[0] as DataRowView)["TJBH"] + "\r\n");
                        }
                        else
                        {
                            if (ToolKit.ParseInt(rows[0]["PARENTID"]) == 1)
                                sb.Append(rows[0]["MUNR"].ToString().Split(' ')[0] + ":" + (this.bindingSource1.Current as DataRowView)["TJBH"] );
                            else
                            {
                                DataRow[] rows2 = this.ds.Tables["图集索引表"].Select(string.Format("SYBH={0}", rows[0]["PARENTID"]));
                                if (rows2.Length > 0) { sb.Append(rows2[0]["MUNR"].ToString().Split(' ')[0] + ":" + (this.bindingSource1.Current as DataRowView)["TJBH"]); }
                            }
                        }
                    }
                }
            }
            if (this.gridColumn9.Visible)
            {
                string fk = (this.bindingSource1.Current as DataRowView)["HD"].ToString();
                if (!string.IsNullOrEmpty(fk))
                {
                    sb.Append(" " + this.gridColumn9.Caption +":"+ fk);
                }
                //sb.Append(" "+this.gridColumn9.Caption+":"+(this.bindingSource1.Current as DataRowView)[this.gridColumn9.FieldName]+"mm");
            }
            sb.Append("\r\n");
            int i = 0;

            foreach (DataRowView item in this.bindingSource2)
            {
                if (ToolKit.ParseBoolen(item["Check"]))
                    if (item["ZFMC"].ToString() != "")
                    {
                        i++;
                        sb.Append(i.ToString() + "." + item["ZFMC"] + "\r\n");
                        
                    }

            }
            if (!string.IsNullOrEmpty((this.bindingSource1.Current as DataRowView)["BW"].ToString()))
            {
                string fk = (this.bindingSource1.Current as DataRowView)["BW"].ToString();
                if (!string.IsNullOrEmpty(fk))
                {
                    i++;
                    sb.Append(i.ToString() + ".所在部位：" + fk + "\r\n");
                }
            }
            /*if (gridColumn9.OptionsColumn.AllowEdit)
            {
                
                string fk=(this.bindingSource1.Current as DataRowView)["HD"].ToString();
                if (!string.IsNullOrEmpty(fk))
                {
                    i++;
                    sb.Append( i.ToString() + ".缝宽：" + fk);
                }
              
            }*/
            return sb.ToString();
        }

        /// <summary>
        /// 选择图集号默认给当前行赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView v = this.bindingSource1.Current as DataRowView;
            DataRow[] rows = null;
            //if(string.IsNullOrEmpty(v.Row["SYBH"].ToString()))
            //if (string.IsNullOrEmpty(base.Parm.ToString()))
            //    rows = this.ds.Tables["图集内容清单表"].Select(string.Format("TJBH='{0}'", (sender as DevExpress.XtraEditors.LookUpEdit).Text));
            //else
                rows = this.ds.Tables["图集内容清单表"].Select(string.Format("TJBH='{0}' and SYBH='{1}'", (sender as DevExpress.XtraEditors.LookUpEdit).Text, base.Parm.ToString()));
            if (rows.Length < 1) return;
            //添加做法之前判断是否需要删除
            if (v["TJBH"] != null)
            {
                if (v["TJBH"].ToString() != "")
                {
                    this.DeleteZF(v["Key"].ToString(), v);//删除做法
                }
            }
            v.Row.BeginEdit();
            v.Row.ItemArray = rows[0].ItemArray;
            if (!string.IsNullOrEmpty(v.Row["CLFS"].ToString())) { v.Row["OP"] = "请选择"; }
            v.Row.EndEdit();
            //增加做法
            DataRow[] rows1 = null;
            if (string.IsNullOrEmpty(v.Row["SYBH"].ToString()))
                rows1 = this.ds.Tables["图集做法表"].Select(string.Format("TJBH='{0}'", (sender as DevExpress.XtraEditors.LookUpEdit).Text));
            else
                rows1 = this.ds.Tables["图集做法表"].Select(string.Format("TJBH='{0}'and SYBH={1}", (sender as DevExpress.XtraEditors.LookUpEdit).Text, v.Row["SYBH"].ToString()));
            foreach (DataRow item in rows1)
            {
                DataRow r = this.m_TabTJZF.NewRow();
                r.ItemArray = item.ItemArray;
                r.BeginEdit();
                r["TJID"] = v["Key"];
                if (!string.IsNullOrEmpty(r["BS"].ToString()))
                    r["OP"] = "请选择";
                r.EndEdit();
                this.m_TabTJZF.Rows.Add(r);
            }

            //判断是否需要弹框
            if (v["CLFS"].ToString() == "增加")
            {
                this.AddZF(v);
            }
        }

        private decimal GetXS(DataRow r)
        {

            string str = r["GCXS"].ToString();
            string HD = r["HD1"].ToString();
            //判断是否有厚度
            if (str.Contains("HD"))
            {
                decimal d = ToolKit.ParseDecimal(str.Substring(3));
                if (d == 0) d = 1;
                d = ToolKit.ParseDecimal(HD) / d;
                return d;
            }
            else
            {
                return ToolKit.ParseDecimal(str);
            }

        }
        private void AddZF(DataRowView v)
        {
            // PrviewTJLX form = new PrviewTJLX(this.Activitie, "," + v["TJBH"].ToString() + ",", v["CLFS"].ToString(), v["BS"].ToString());
            PrviewTJLX form = new PrviewTJLX(this.Activitie, "," + v["TJBH"].ToString() + ",", v["CLFS"].ToString());
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {
                if (form.bindingSource1.Current != null)
                {
                    DataRowView view = form.bindingSource1.Current as DataRowView;
                    DataRow r = this.m_TabTJZF.NewRow();
                    r.BeginEdit();
                    r["TJBH"] = v["Key"];
                    r["TJID"] = v["Key"];
                    r["ZFBH"] = this.bindingSource2.Count + 1;
                    r["ZFMC"] = view["BS"] + ":" + view["LXMC"];
                    r["LXID"] = view["ID"];
                    r["XS"] = GetXS(view.Row);
                    r.EndEdit();
                    this.m_TabTJZF.Rows.Add(r);//从类型库取出来并添加为做法
                }
            }
        }
        /// <summary>
        /// 图集内容需要增加做法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            DataRowView v = this.bindingSource1.Current as DataRowView;
            this.AddZF(v);
        }
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRowView view = this.bindingSource2.Current as DataRowView;
            if (!string.IsNullOrEmpty(view["CLFS"].ToString()))
            {
                PrviewTJLX form = new PrviewTJLX(this.Activitie, "," + view["TJBH"].ToString() + ",", view["CLFS"].ToString(), view["BS"].ToString());
                DialogResult dl = form.ShowDialog();
                if (dl == DialogResult.OK)
                {
                    if (form.bindingSource1.Current != null)
                    {
                        DataRowView v = form.bindingSource1.Current as DataRowView;
                        switch (view["CLFS"].ToString().Trim())
                        {
                            case "追加":
                                view.BeginEdit();
                                view["LXID"] += "," + v["ID"];
                                view["ZFMC"] += ";" + v["LXMC"];
                                view["XS"] += "," + GetXS(v.Row);
                                view.EndEdit();
                                break;
                            case "替换":
                                view.BeginEdit();
                                view["LXID"] = "," + v["ID"];
                                view["XS"] = "," + GetXS(v.Row);
                                string Str = view["ZFMC"].ToString();
                                if (Str.IndexOf("替换:") > -1)
                                {
                                    Str = Str.Substring(0, Str.IndexOf("替换:"));
                                    view["ZFMC"] = Str + ";" + v["LXMC"];
                                }
                                else
                                {
                                    view["ZFMC"] += ";" + v["LXMC"];
                                }
                                view.EndEdit();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bindingSource1.AddNew();
            //this.m_TJNR.AcceptChanges();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.bindingSource1.Current == null) return;
            DataRowView v = this.bindingSource1.Current as DataRowView;
            DeleteZF(v["Key"].ToString(), v);
            this.bindingSource1.RemoveCurrent();
            // this.m_TabTJZF.Rows
        }
        /// <summary>
        /// 数据提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataErr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRowView currRow = this.bindingSource1.Current as DataRowView;
                if (currRow == null) return;
                DataErr formDataErr = new DataErr();
                formDataErr.StrFormName = toString(currRow["TJBH"]) + ":" + toString(currRow["TJMC"]);
                StringBuilder strTemp = new StringBuilder();
                foreach (DataColumn item in currRow.DataView.Table.Columns)
                {
                    strTemp.Append("," + item.ColumnName + ":" + currRow[item.ColumnName]);
                }
                formDataErr.StrFormName += "{" + strTemp.ToString().Substring(1, strTemp.ToString().Length - 1) + "}";
                formDataErr.ShowDialog();
            }
            catch { }
        }

        #region 类型转换
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string toString(object obj)
        {
            if (obj == null)
            {
                return string.Empty.Trim();
            }
            else
            {
                return obj.ToString().Trim();
            }
        }
        #endregion

        /// <summary>
        /// 根据图集编号删除图集做法
        /// </summary>
        /// <param name="TJID"></param>
        private void DeleteZF(string TJID, DataRowView view)
        {
            DataRow[] rows1 = this.m_TabTJZF.Select(string.Format("TJID='{0}'", TJID));
            foreach (DataRow item in rows1)
            {
                item.Delete();
            }

            this.InformationForm.Remove(view["QDBH"].ToString(), view["BeiZhu"].ToString());//GetTJ(view));

            //DataRow[] rows2 = APP.UnInformation.QDTable.Select(string.Format("QDBH='{0}'", view["QDBH"]));
            //foreach (DataRow item in rows2)
            //{
            //    item.Delete();
            //}
        }


        private void gridControl3_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridControl gv = sender as GridControl;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gv.FocusedView.CalcHitInfo(e.Location) as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo;
            if (e.Button == MouseButtons.Right)
            {
                if (hi.InRow)
                {
                    this.barButtonItem1.Enabled = true;
                    //this.barButtonItem2.Enabled = true;
                    this.btnDataErr.Enabled = true;
                }
                else
                {
                    this.barButtonItem1.Enabled = false;
                    //this.barButtonItem2.Enabled = false;
                    this.btnDataErr.Enabled = false;
                }
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        //private void gridView3_Click(object sender, EventArgs e)
        //{
        //    MouseEventArgs e1 = e as MouseEventArgs;
        //    if (e1 != null)
        //    {
        //        if (e1.Button == MouseButtons.Right)
        //        {
        //            this.popupMenu1.ShowPopup(Control.MousePosition);
        //        }
        //    }
        //}

        private void treeListEx2_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName == "OP")
            {
                if (!string.IsNullOrEmpty(e.Node.GetValue("OP").ToString()))
                {
                    //e.Column.OptionsColumn.ReadOnly = false;
                    e.RepositoryItem = this.repositoryItemButtonEdit1;

                }
                else
                {
                    // e.RepositoryItem = null;
                    // e.Column.OptionsColumn.ReadOnly = true;
                }
            }

        }
    }
}
