using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using ZiboSoft.Commons.Common;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class OtherProjectForm : ABaseForm
    {
         GLODSOFT.QDJJ.BUSINESS._Project_Statistics ProjectStaistics ;

        //GLODSOFT.QDJJ.BUSINESS._OtherProject_Statistics Statistics = new GLODSOFT.QDJJ.BUSINESS._OtherProject_Statistics(null);
        public OtherProjectForm(_UnitProject active)
        {
            this.Activitie = active;
            this.ProjectStaistics = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(active,this.CurrentBusiness);
            //this.Statistics.Unit = active;
            InitializeComponent();
        }

        DataTable Parm_Table;
        private bool IsLoadedControls = false;
        private _Method_OtherProject Method = null;
        private Container ContainerForm
        {
            get
            {
                switch (this.CurrentBusiness.WorkFlowType)
                {
                    case EWorkFlowType.None:
                        break;
                    case EWorkFlowType.PROJECT:
                        ProjectForm form = this.BusContainer as ProjectForm;
                        if (form == null) return null;
                        CWellComeProject cw = form.ParentForm as CWellComeProject;
                        return cw;
                        break;
                    case EWorkFlowType.Engineering:
                        break;
                    case EWorkFlowType.UnitProject:
                        ProjectForm form1 = this.BusContainer as ProjectForm;
                        return form1;
                        break;
                    default:
                        break;
                }
                return null;

            }
        }
        private void OtherProjectForm_Load(object sender, EventArgs e)
        {
            LoadControls();
        }
        void wcForm_AfterStatisticaled(object sender, object args)
        {
            Method.Calculate();
        }

        public override void MustInit()
        {
            //此处初始化窗体配色方案

            base.MustInit();
        }

        public override void GlobalStyleChange()
        {
            //base.GlobalStyleChange();
            //subSegmentListData1.treeList1.ModelName = this.Text;
            //功能区处理
            this.treeList1.ModelName = "其他项目";
            this.treeList1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.treeList1.ColumnColor = APP.DataObjects.GColor.ColumnColor;
            this.treeList1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }


        public override void Refresh()
        {
            //此处初始化窗体配色方案
            this.treeList1.ModelName = this.Text;
            this.treeList1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();


            base.Refresh();
        }

        private DataView Source;

        private void init()
        {
            if (!this.Activitie.StructSource.ModelOtherProject.Columns[0].AutoIncrement)
            {
                int m = ToolKit.ParseInt(this.Activitie.StructSource.ModelOtherProject.Compute("Max(ID)", ""));
                Method.SetAutoIncrement(this.Activitie.StructSource.ModelOtherProject, true, m + 1);
            }
            this.woodMachineLibrary1.Default = this.Activitie;
            //Source = this.Activitie.StructSource.ModelOtherProject;
            Source = this.Activitie.StructSource.ModelOtherProject.DefaultView;
            this.woodMachineLibrary1.listBoxControl2.DoubleClick += new EventHandler(listBoxControl2_DoubleClick);
            //this.woodMachineLibrary1.Default = this.Activitie;
            // this.bindingSource1.DataSource = Source;
            this.treeList1.KeyFieldName = "id";
            this.treeList1.ParentFieldName = "ParentID";
            this.treeList1.DataSource = Source;
            this.treeList1.ExpandAll();
            this.Source.Table.ColumnChanged += new DataColumnChangeEventHandler(Source_ColumnChanged);
            Parm_Table = APP.Application.Global.DataTamp.TempDataSet.Tables["Params_Other"].Copy();
            //this.repositoryItemLookUpEdit1.DataSource = Parm_Table.DefaultView;
            //this.groupControl1.Text = "当前模板：【" + this.Activitie.Property.OtherProject.FileName + "】";

        }

        void Source_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            // APP.DataObjects.GColor.ColumnLayout.Set("其他项目", this.treeList1);
            // APP.DataObjects.Save(@"d:\options.cfg");
            switch (e.Column.ColumnName)
            {
                case "Calculation"://费率
                case "Coefficient"://计算基础
                case "Quantities"://计算基础
                case "jsdj":
                    if (!this.HaveChl(e.Row, e.Row.Table))
                    {
                        e.Row.BeginEdit();
                        string str = ToolKit.ExpressionReplace(e.Row["Calculation"].ToString(), this.Activitie.StructSource.ModelProjVariable);
                        decimal d = ToolKit.Calculate(str);
                        d = d * ToolKit.ParseDecimal(e.Row["Coefficient"]) * 0.01M;
                        e.Row["Unitprice"] = d;
                        e.Row["Combinedprice"] = d * ToolKit.ParseDecimal(e.Row["Quantities"]);
                        if (ToolKit.ParseDecimal(e.Row["jsdj"]) > 0)
                        {
                            e.Row["cjdj"] = ToolKit.ParseDecimal(e.Row["jsdj"]) - d;
                            e.Row["cjhj"] = ToolKit.ParseDecimal(e.Row["cjdj"]) * ToolKit.ParseDecimal(e.Row["Quantities"]);
                        }
                        e.Row.EndEdit();
                        //计算父类值
                        Method.SetCurrentParent(e.Row);
                        //this.Activitie.Property.OtherProject.SetCurrentParent(e.Row);
                    }
                    else
                    {
                        Method.SetCurrentParent(e.Row);
                        //this.Activitie.Property.OtherProject.SetCurrentParent(e.Row); 
                    }

                    this.Activitie.NeedCalculate = true;

                    break;
                //case "Combinedprice":

                //    if (e.Row["ParentID"].ToString() == "0")
                //    {
                //        this.Activitie.Property.OtherProject.Begin();
                //    }


            }
        }
        private string GetChdName()
        {
            DataRowView drv = this.treeList1.Current as DataRowView;
            string name = string.Empty;
            if (drv != null)
            {
                int id = ToolKit.ParseInt(drv["ID"]);
                name = drv["Number"].ToString();
                object count = this.Activitie.StructSource.ModelOtherProject.Compute("Count(ID)", string.Format(" ParentID = {0} and UnID = {1} ", id, this.Activitie.ID));
                return string.Format("{0}.{1}", name, (int)count + 1);
            }
            return string.Empty;
        }
        /// <summary>
        /// 是否为根结点
        /// </summary>
        /// <param name="row"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool HaveChl(DataRow row, DataTable table)
        {
            if (!row["ID"].Equals(DBNull.Value))
            {
                DataRow[] rows = table.Select(string.Format("ParentID = {0}", row["ID"]));
                if (rows.Length == 0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Init()
        {


        }
        void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.ListBoxControl lc = sender as DevExpress.XtraEditors.ListBoxControl;
            DataRowView v = lc.SelectedItem as DataRowView;
            DataRowView view = this.treeList1.Current as DataRowView;
            if (view != null)
            {
                if (view["DZBS"].Equals(false))
                {
                    // string xuhao=view["Number"].ToString();
                    //string name = view["Name"].ToString();
                    //if (name == "人工" || name == "材料" || name == "机械")
                    //{
                    view["Calculation"] = "";
                    view["UnitPrice"] = "0";
                    DataRow row = this.Source.Table.NewRow();
                    row["ParentID"] = view["id"];
                    row["Number"] = GetChdName();
                    row["Name"] = v[CEntity材机表.FILED_CAIJMC];
                    row["Unit"] = v[CEntity材机表.FILED_CAIJDW];
                    row["UnID"] = this.Activitie.ID;
                    row["EnID"] = this.Activitie.PID;
                    row["Quantities"] = 1;
                    row["Coefficient"] = 100;
                    row["IsSys"] = false;
                    row["PKey"] = view["Key"];
                    row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
                    this.Source.Table.Rows.Add(row);
                    // }
                }
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            if (tree.FocusedNode == null) return;
            if (tree.FocusedColumn != null)
            {
                string FileName = tree.FocusedColumn.FieldName;
                DataRowView v = tree.GetDataRecordByNode(tree.FocusedNode) as DataRowView;
                if (tree.FocusedNode.HasChildren)
                {
                    if (this.treeList1.Columns["jsdj"] != null) this.treeList1.Columns["jsdj"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["Feature"] != null) this.treeList1.Columns["Feature"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["Name"] != null) this.treeList1.Columns["Name"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["Calculation"] != null) this.treeList1.Columns["Calculation"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["Coefficient"] != null) this.treeList1.Columns["Coefficient"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["Quantities"] != null) this.treeList1.Columns["Quantities"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    if (this.treeList1.Columns["jsdj"] != null) this.treeList1.Columns["jsdj"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["Feature"] != null) this.treeList1.Columns["Feature"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["Name"] != null) this.treeList1.Columns["Name"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["Calculation"] != null) this.treeList1.Columns["Calculation"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["Coefficient"] != null) this.treeList1.Columns["Coefficient"].OptionsColumn.AllowEdit = false;
                    if (v["Unit"].ToString().Equals("项"))
                    {
                        if (this.treeList1.Columns["Quantities"] != null) this.treeList1.Columns["Quantities"].OptionsColumn.AllowEdit = false;
                    }
                    else
                        if (this.treeList1.Columns["Quantities"] != null) this.treeList1.Columns["Quantities"].OptionsColumn.AllowEdit = true;
                }

                if (string.IsNullOrEmpty(tree.FocusedNode.GetValue("Remark").ToString()))
                {
                    if (this.treeList1.Columns["Remark"] != null) this.treeList1.Columns["Remark"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    if (this.treeList1.Columns["Remark"] != null) this.treeList1.Columns["Remark"].OptionsColumn.AllowEdit = true;
                }

                if (Convert.ToBoolean(tree.FocusedNode.GetValue("IsSys")))
                {
                    if (this.treeList1.Columns["Unit"] != null) this.treeList1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    if (this.treeList1.Columns["Unit"] != null) this.treeList1.Columns["Unit"].OptionsColumn.AllowEdit = true;
                }
                if (!APP.Jzbx_pwd)
                    this.treeList1.OptionsBehavior.Editable = !v["DZBS"].Equals(true);
                else
                    this.treeList1.OptionsBehavior.Editable = true;
            }
        }
        private void treeList1_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            treeList1_FocusedNodeChanged(this.treeList1, null);
        }

        private void treeList1_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "Remark":
                    e.RepositoryItem = this.repositoryItemComboBox1;
                    break;
                case "Calculation":
                    e.RepositoryItem = this.repositoryItemButtonEdit1;
                    break;
                case "Unit":
                    e.RepositoryItem = this.ComboBoxDW;
                    break;
                case "Feature"://系统变量选择
                    Filter_Parm();
                    e.RepositoryItem = this.repositoryItemButtonEdit2;
                    break;
                case "Quantities"://系统变量选择

                    e.RepositoryItem = this.repositoryItemCalcEdit1;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 费用代号数据绑定
        /// </summary>
        private void Filter_Parm()
        {

            Parm_Table.DefaultView.RowFilter = string.Format("Code not in ({0})", Filter);
            // this.

        }
        /// <summary>
        /// 费用代号筛选条件
        /// </summary>
        private string Filter
        {
            get
            {
                int i = 0;
                string str = string.Empty;
                foreach (DataRowView row in this.Source)
                {
                    if (i != this.Source.Count - 1)
                    {
                        str += string.Format("'{0}',", row["Feature"].ToString());
                    }
                    else
                    {
                        str += string.Format("'{0}'", row["Feature"].ToString());
                    }

                }
                return str;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit bt = sender as DevExpress.XtraEditors.ButtonEdit;
            SelectVariableForm form = new SelectVariableForm();
            form.Activitie = this.Activitie;
            form.DataSource = this.Activitie.StructSource.ModelProjVariable;
            //this.Activitie.Property.Statistics.Begin();
            //form.DataSource = this.Activitie.Property.Statistics.ResultVarable;
            form.GetValue = bt.Text;
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {
                //bt.Text = form.GetValue;
                (this.treeList1.Current as DataRowView)["Calculation"] = form.GetValue;
                this.treeList1.RefreshDataSource();
                //this.Source.ResetBindings(false);

            }
        }

        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {



            // TreeList t = sender as TreeList;
            // object o = t.DataSource;
            //if (e.Node != null)
            //{
            //    string s = "Quantities, Coefficient,Unitprice,Combinedprice,jsdj,cjdj,cjhj,";
            //    if (s.Contains(e.Column.FieldName+","))
            //    {
            //        decimal d = ZiboSoft.Commons.Common.ToolKit.ParseDecimal(e.Value);
            //        //int m = Convert.ToInt32(d);
            //        if (d <= 0)
            //        {
            //            e.Value = "";
            //        }

            //    }
            //}



            //if (e.Column.FieldName == "Combinedprice" || e.Column.FieldName == "Unitprice")
            //{
            //    decimal d=ToolKit.ParseDecimal(e.Value);
            //    e.Value = d.ToString("F2");
            //}
        }

        /// <summary>
        /// 保存其他项目文件
        /// </summary>
        public void Save()
        {
            DialogResult result = this.saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Method.Save(this.saveFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 保存当前其他项目文件
        /// </summary>
        public void load()
        {
            this.openFileDialog1.InitialDirectory = APP.Application.Global.AppFolder.FullName + "模板文件\\其他项目";
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //this.Activitie.Property.OtherProject.Load(this.openFileDialog1.FileName);
                this.Method.Load(this.openFileDialog1.FileName);
                this.Source.Table.ColumnChanged -= new DataColumnChangeEventHandler(Source_ColumnChanged);
                Source = this.Activitie.StructSource.ModelOtherProject.DefaultView;
                this.treeList1.DataSource = null;
                this.treeList1.DataSource = Source;
                this.Source.Table.ColumnChanged += new DataColumnChangeEventHandler(Source_ColumnChanged);
                this.treeList1.ExpandAll();
                // this.groupControl1.Text = "当前模板：【" + this.Activitie.Property.OtherProject.FileName + "】";
            }
        }
        private string GetName()
        {
            string name = "F";
            object count = this.Activitie.StructSource.ModelOtherProject.Compute("Count(ID)", " ParentID = 0 ");
            return name + ((int)count + 1);
        }

        /// <summary>
        /// 增加项
        /// </summary>

        public void Add()
        {

            DataView dv = this.treeList1.DataSource as DataView;
            DataRowView row = dv.AddNew();
            row.BeginEdit();
            row["Number"] = GetName();
            row["IsSys"] = false;
            row["ParentID"] = 0;
            row["UnID"] = this.Activitie.ID;
            row["EnID"] = this.Activitie.PID;
            row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
            row.EndEdit();
        }
        /// <summary>
        /// 增加子项
        /// </summary>
        public DataRow Add_Child()
        {
            DataRowView drv = this.treeList1.Current as DataRowView;
            if (drv != null)
            {
                if (drv["DZBS"].Equals(false))
                {
                    if (drv["Number"].Equals("F1"))
                    {
                        MsgBox.Show("此节点不允许增加子节点！", MessageBoxButtons.OK);
                        return null;
                    }
                    if(!drv["Number"].Equals("F1.3.1") && !drv["Number"].Equals("F1.3.2") && !drv["Number"].Equals("F1.3.3"))
                    {
                        MsgBox.Show("此节点不允许增加子节点！", MessageBoxButtons.OK);
                        return null;
                    }
                    drv["Calculation"] = "";
                    drv["UnitPrice"] = "0";

                    DataRowView row = this.Source.AddNew();
                    row.BeginEdit();
                    row["Number"] = GetChdName();
                    row["ParentID"] = drv["ID"];
                    row["IsSys"] = false;
                    row["UnID"] = this.Activitie.ID;
                    row["EnID"] = this.Activitie.PID;
                    row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
                    row["PKey"] = drv["Key"];
                    row["Coefficient"] = "100";
                    row.EndEdit();
                    return row.Row;
                }
            }
            return null;
        }

        public DataRow Add_Child(DataRowView drv)
        {

            if (drv != null)
            {
                drv["Calculation"] = "";
                drv["UnitPrice"] = "0";
                DataView dv = this.treeList1.DataSource as DataView;
                DataRowView row = dv.AddNew();
                row.BeginEdit();
                row["Number"] = GetChdName();
                row["ParentID"] = drv["ID"];
                row["IsSys"] = false;
                row["UnID"] = this.Activitie.ID;
                row["EnID"] = this.Activitie.PID;
                row["PKey"] = drv["Key"];
                row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
                row["Coefficient"] = "100";
                row.EndEdit();
                return row.Row;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除项
        /// </summary>
        /// <summary>
        /// 删除当前选择项目
        /// </summary>
        public bool Delete(DataRowView drv)
        {
            //删除当前选择项下的所有项目
            DialogResult d = MsgBox.Show("确认删除?", MessageBoxButtons.OKCancel);
            if (d != DialogResult.OK) return false;
            //DataRowView drv = this.bindingSource1.Current as DataRowView;
            if (drv != null)
            {
                if (Convert.ToBoolean(drv["IsSys"]))
                {
                    MessageBox.Show("此节点不允许删除");
                    return false;
                }
                DataRow r = drv.DataView.Table.NewRow();
                r.ItemArray = drv.Row.ItemArray;
                string id = drv["ID"].ToString();
                this.doDelete(drv.Row);
                Method.SetCurrentParent(r);
            }
            return true;
        }

        public void Delete()
        {
            //if (this.treeList1.FocusedNode == null)
            //{
            //    MsgBox.Show("请选择要删除的节点！", MessageBoxButtons.OK);
            //    return;
            //}
            if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count || APP.Jzbx_pwd)
            {
                TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().ToArray();

                foreach (TreeListNode item in nodes)
                {
                    bool flag = true;
                    TreeListNode fnode = this.treeList1.FocusedNode.PrevNode;
                    if (fnode == null) fnode = this.treeList1.FocusedNode.ParentNode;
                    object obj = this.treeList1.GetDataRecordByNode(item);
                    if (obj is DataRowView)
                    {
                        if ((obj as DataRowView)["Number"].Equals("F1") || (obj as DataRowView)["Number"].Equals("F1.1") || (obj as DataRowView)["Number"].Equals("F1.2") || (obj as DataRowView)["Number"].Equals("F1.3") || (obj as DataRowView)["Number"].Equals("F1.4") || (obj as DataRowView)["Number"].Equals("F1.5"))
                        {
                            MsgBox.Show("此节点不允许删除！", MessageBoxButtons.OK);
                            return;
                        }
                        flag = this.Delete(obj as DataRowView);
                    }
                    if (fnode != null)
                    {
                        if (fnode.Expanded && fnode.HasChildren) fnode = fnode.LastNode;
                    }
                    if (fnode != null)
                    {
                        if (flag)
                            this.treeList1.FocusedNode = fnode;
                    }
                }
            }
        }
        /// <summary>
        /// 提取甲供材
        /// </summary>
        public void LoadJGC()
        {
            //删除当前选择项下的所有项目
            DataRow[] rows1 = this.Activitie.StructSource.ModelYTLBSummary.Select(string.Format("YTLB='{0}' and BDBH<>'{1}'", UseType.甲供材料.ToString(), ""));
            DataRowView drv = this.treeList1.Current as DataRowView;
            if (drv != null)
            {
                if (drv["DZBS"].Equals(false) || APP.Jzbx_pwd)
                {
                    if (drv["Number"].Equals("F1"))
                    {
                        MsgBox.Show("此节点不允许提取甲供材！", MessageBoxButtons.OK);
                        return;
                    }
                    if (drv["beiyong"] != null)
                    {
                        if (!string.IsNullOrEmpty(drv["beiyong"].ToString()))
                        {
                            Alert("此节点本身就是甲供材，不允许提取");
                            return;
                        }
                    }
                    DataRow[] rows = this.Activitie.StructSource.ModelOtherProject.Select(string.Format(" ParentID ={0} and beiyong<>''", drv["ID"]));
                    foreach (DataRow item in rows)
                    {
                        doDelete(item);
                    }
                    foreach (DataRow item in rows1)
                    {
                        DataRow row = Add_Child(drv);
                        row.BeginEdit();
                        row["Name"] = item["MC"];
                        row["Unit"] = item["DW"];
                        row["Quantities"] = item["SLH"];
                        row["Calculation"] = item["SCDJ"];
                        row["Coefficient"] = 100;
                        row["beiyong"] = item["BH"];
                        row["UnID"] = this.Activitie.ID;
                        row["EnID"] = this.Activitie.PID;
                        row["IsSys"] = false;
                        row.EndEdit();
                    }
                }
            }
        }

        /// <summary>
        /// 递归删除指定的编号
        /// </summary>
        /// <param name="p_id"></param>
        private void doDelete(DataRow row)
        {
            string Number = row["Number"].ToString();
            string PID = row["ParentID"].ToString();
            //查找是否拥有子项
            DataRow[] rows = this.Activitie.StructSource.ModelOtherProject.Select(string.Format(" ParentID ={0}", row["ID"]));
            if (rows.Length == 0)
            {
                row.Delete();
                EditName(Number, PID);
            }
            else
            {
                foreach (DataRow r in rows)
                {
                    this.doDelete(r);
                }
                row.Delete();

            }
        }

        private void EditName(string Number, string PID)
        {

            DataRow[] rows = this.Activitie.StructSource.ModelOtherProject.Select(string.Format(" ParentID = {0} ", PID));
            string s = Number;
            if (s.IndexOf('.') < 0) return;
            s = s.Substring(0, s.LastIndexOf('.'));
            for (int i = 0; i < rows.Length; i++)
            {
                if (!Convert.ToBoolean(rows[i]["IsSys"]))
                    rows[i]["Number"] = string.Format("{0}.{1}", s, i + 1);
            }
        }
        private void repositoryItemLookUpEdit1_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit look = sender as DevExpress.XtraEditors.LookUpEdit;
            //DataRowView view = this.bindingSource1.Current as DataRowView;
            //if (view!=null)
            //{
            //    view.Row.BeginEdit();
            //    view.Row["Feature"]=look.Text;
            //    view.Row.EndEdit();
            //}
            if (string.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                Alert("请正确填写费用代码！");
            }
            else
            {
                if (this.Filter.Contains(e.DisplayValue.ToString()))
                {
                    Alert("费用代码已经被使用！");

                }
                else
                {
                    look.EditValue = e.DisplayValue;
                }
            }
        }
        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.treeList1.OptionsBehavior.Editable = false;
                this.splitContainer1.Panel1.Visible = false;
                this.splitContainer1.SplitterDistance = 1;

            }
            else
            {
                this.treeList1.OptionsBehavior.Editable = true;
                this.splitContainer1.Panel1.Visible = true;
                this.splitContainer1.SplitterDistance = 155;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Caption)
            {
                case "增加项":
                    this.Add();
                    break;
                case "增加子项":
                    this.Add_Child();
                    break;
                case "删除所选":
                    this.Delete();

                    break;
                case "保存模板":
                    this.Save();
                    break;
                case "套用模板":
                    this.load();
                    break;
                case "提取甲供材到当前节点":
                    this.LoadJGC();
                    break;
                default:
                    break;
            }
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList gv = sender as TreeList;
            TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                gv.FocusedNode = hi.Node;
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    this.barButtonItemTYMB.Enabled = false;
                    this.barButtonItemBCMB.Enabled = false;
                    this.barButtonItemTQ.Enabled = false;
                    if (gv.FocusedNode.GetValue("Number").Equals("F1"))
                    {
                        this.barButtonItemAddZM.Enabled = false;
                        this.barButtonItemDelete.Enabled = false;
                    }
                    else
                    {
                        if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => p.GetValue("DZBS").Equals(false)).Count() == this.treeList1.Selection.Count || APP.Jzbx_pwd)
                        {
                            this.barButtonItemAddZM.Enabled = true;
                            this.barButtonItemDelete.Enabled = true;
                        }
                        else
                        {
                            this.barButtonItemAddZM.Enabled = false;
                            this.barButtonItemDelete.Enabled = false;
                        }
                    }
                }
                else
                {
                    if (gv.FocusedNode == null)
                    {
                        this.barButtonItemAddZM.Enabled = false;
                        this.barButtonItemDelete.Enabled = false;
                        this.barButtonItemTQ.Enabled = false;

                    }
                    else if (gv.FocusedNode.GetValue("Number").Equals("F1"))
                    {
                        this.barButtonItemAddZM.Enabled = false;
                        this.barButtonItemDelete.Enabled = false;
                        this.barButtonItemTQ.Enabled = false;
                    }
                    else
                    {
                        this.barButtonItemAddZM.Enabled = true;
                        this.barButtonItemDelete.Enabled = true;
                        this.barButtonItemTQ.Enabled = true;
                    }
                }
                if (this.Activitie == null) return;
                if (this.Activitie.IsLock) this.popupMenu1.ShowPopup(Control.MousePosition);
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void treeList1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }

        private void treeList1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            switch (this.treeList1.FocusedColumn.FieldName)
            {
                case "jsdj":
                case "Coefficient":
                    e.ErrorText = "请输入正确的数字值！";
                    break;
                default:
                    break;
            }
        }
        object ChangeObject = null;
        private void treeList1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            TreeList tl = sender as TreeList;
            DataRowView v = tl.GetDataRecordByNode(e.Node) as DataRowView;
            ChangeObject = v.Row[e.Column.FieldName];
        }
        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "Name")
            {
                this.Method.Begin();

            }
            ModifyAttribute modity = new ModifyAttribute();
            modity.CurrentValue = e.Value;
            modity.OriginalValue = ChangeObject;
            modity.ObjectName = e.Column.Caption;
            modity.ModelName = "其他项目";
            modity.Source = this.treeList1.Current.Row;
            modity.FieldName = e.Column.FieldName;
            //modity.ActingOn = "清单.子目";
            ChangeObject = null;
            this.LogContent.Add(modity);
            //LogContent.Add(e);
            GetContainer.ALogForm.Init();

            ProjectStaistics.SetQTXM();
        }
        public override void Revocation()
        {
            Attribute attr = this.LogContent.GetLastAttribute;
            if (attr != null)
            {
                //获取Attr开始撤销动作
                ModifyAttribute ma = attr as ModifyAttribute;
                ActionAttribute aa = attr as ActionAttribute;
                if (ma != null)
                {
                    this.Revocation(ma);
                }
                if (aa != null)
                {
                    this.Revocation(aa);
                }

            }
        }
        /// <summary>
        /// 修改的实现
        /// </summary>
        /// <param name="p_attr"></param>
        public void Revocation(ModifyAttribute p_attr)
        {
            //还原属性
            /*Command.ModifyObject(p_attr);
            //定位目标
            CurrentTabForm.RevocationRefresh();
            this.Locate(p_attr);
            //改变后刷新
            this.RefreshDataSource();*/

            _Modify_Method.ModifyEdit_Other(p_attr, this.CurrentBusiness, this.Activitie);
            LogContent.Remove(p_attr);
            GetContainer.ALogForm.Init();
        }
        /// <summary>
        /// 操作的实现
        /// </summary>
        /// <param name="p_attr"></param>
        public void Revocation(ActionAttribute p_attr)
        {

        }
        private void RaiseColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.treeList1);
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CParams_Metaanalysis f = new CParams_Metaanalysis();
            f.Text = "其他项目参数配置";
            DataTable ParamTable = APP.Application.Global.DataTamp.TempDataSet.Tables["Params_Other"].Copy();
            f.DataSource = ParamTable;
            f.Filter = this.Filter;
            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                DataRowView view = f.Current;
                DataRowView rv = this.treeList1.Current;
                if (rv != null)
                {
                    ChangeObject = rv["Feature"];
                    rv.BeginEdit();
                    rv["Feature"] = view["Code"];
                    rv["Name"] = view["Name"];
                    rv.EndEdit();
                    ModifyAttribute modity = new ModifyAttribute();
                    modity.CurrentValue = rv["Feature"];
                    modity.OriginalValue = ChangeObject;
                    modity.ObjectName = "费用代号";
                    modity.ModelName = "其他项目";
                    modity.Source = this.treeList1.Current.Row;
                    modity.FieldName = "Feature";
                    //modity.ActingOn = "清单.子目";
                    ChangeObject = null;
                    this.LogContent.Add(modity);
                    //LogContent.Add(e);
                    GetContainer.ALogForm.Init();
                }
            }

        }

        public void LoadControls()
        {
            if (IsLoadedControls)
            {
                return;
            }

            IsLoadedControls = true;

            Method = new _Method_OtherProject(this.CurrentBusiness, this.Activitie);
            init();
            if (this.ContainerForm != null)
                ContainerForm.AfterStatisticaled += new AfterStatisticaledHandler(wcForm_AfterStatisticaled);
        }

        /// <summary>
        /// Fast Calcaulate and refresh value to tree
        /// </summary>
        /// <param name="node"></param>
        private void RefreshNodes(TreeListNode node)
        {
            var rowView = this.treeList1.GetDataRecordByNode(node) as DataRowView;
            if (rowView == null)
            {
                return;
            }

            for (var i = node.Nodes.Count - 1; i >= 0; i--)
            {
                RefreshNodes(node.Nodes[i]);
            }

            if (!this.HaveChl(rowView.Row, rowView.Row.Table))
            {
                Calcaulate(rowView.Row);
                Method.SetCurrentParent(rowView.Row);
            }
            else
            {
                Method.SetCurrentParent(rowView.Row);
            }
        }

        private void Calcaulate(DataRow row)
        {
            row.BeginEdit();
            string str = ToolKit.ExpressionReplace(row["Calculation"].ToString(), this.Activitie.StructSource.ModelProjVariable);
            decimal d = ToolKit.Calculate(str);
            d = d * ToolKit.ParseDecimal(row["Coefficient"]) * 0.01M;
            row["Unitprice"] = d;
            row["Combinedprice"] = d * ToolKit.ParseDecimal(row["Quantities"]);
            if (ToolKit.ParseDecimal(row["jsdj"]) > 0)
            {
                row["cjdj"] = ToolKit.ParseDecimal(row["jsdj"]) - d;
                row["cjhj"] = ToolKit.ParseDecimal(row["cjdj"]) * ToolKit.ParseDecimal(row["Quantities"]);
            }
            row.EndEdit();
        }

        public void Calculate()
        {
            RefreshNodes(this.treeList1.Nodes.FirstNode);
            Method.Begin();
        }

        
    }
}
