
/***********报表显示*************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.UI;
using DevExpress.XtraReports.UI;
using System.Collections;
using GLODSOFT.QDJJ.BUSINESS;
using System.Reflection;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using GOLDSOFT.QDJJ.CTRL;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 报表界面
    /// </summary>
    public partial class ReportForm : ABaseForm
    {


        private GLODSOFT.QDJJ.BUSINESS._Report m_Report = null;
        /// <summary>
        /// 清单报表集合
        /// </summary>
        private ArrayList m_ArrayList_qd = new ArrayList();
        /// <summary>
        /// 计价报表集合
        /// </summary>
        private ArrayList m_ArrayList_jj = new ArrayList();
        /// <summary>
        /// 当前焦点树
        /// </summary>
        private TreeListEx m_TreeListFocused = null;

        public ReportForm()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            this.treeList1.FocusedNode = null;
            this.treeList2.FocusedNode = null;
            if (this.Activitie != null)
            {
                
                this.FillInfo();
                if (m_Report.ReportResult == null) return;
                m_ArrayList_qd.Clear();
                m_ArrayList_jj.Clear();
                m_ArrayList_qd.AddRange(m_Report.ReportResult.Cast<_ObjectReport>().Where(p => p.UnitReportType == "计价报表").OrderBy(p => p.ID).ToArray());
                m_ArrayList_jj.AddRange(m_Report.ReportResult.Cast<_ObjectReport>().Where(p => p.UnitReportType == "清单报表").OrderBy(p => p.ID).ToArray());
                this.treeList1.DataSource = null;
                this.treeList2.DataSource = null;
                this.treeList1.DataSource = m_ArrayList_qd;
                this.treeList1.ExpandAll();
                this.treeList2.DataSource = m_ArrayList_jj;
                this.treeList2.ExpandAll();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportForm_Load(object sender, EventArgs e)
        {
            m_Report = new GLODSOFT.QDJJ.BUSINESS._UnitProjectReport();
            m_Report.ReportStencil = APP.Cache.BaseReport.Copy() as _List;
            this.m_TreeListFocused = this.treeList1;
            this.Init();

        }

        private void FillInfo()
        {
            BackgroundWorker ObjWorker = new BackgroundWorker();
            ObjWorker.WorkerReportsProgress = true;
            ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
            ObjWorker.RunWorkerAsync();
            ProgressFrom form = new ProgressFrom(ObjWorker);
            form.ShowDialog();
        }


        void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int acId = 0;
            if (this.Activitie.StructSource.ModelProject.Rows.Count == 0)
            {
                this.Activitie.StructSource.ModelProject.Add(this.Activitie);
                this.Activitie.StructSource.ModelProject.UpDate(this.Activitie);
            }
            else
            {
                this.Activitie.StructSource.ModelProject.Clear();
                //acId = this.Activitie.StructSource.ModelProject.Add(this.Activitie);
                //this.Activitie.StructSource.ModelProject.UpDate(this.Activitie);
                acId = this.Activitie.StructSource.ModelProject.AddData(this.Activitie);
                this.Activitie.StructSource.ModelProject.UpDateData(this.Activitie, acId);
            }
            m_Report.UnID = acId;// this.Activitie.ID;
            m_Report.StructSource = this.Activitie.StructSource;
            m_Report.BindingSource();
        }

        void HuiZongProjectForm_DoStatistical(object sender, object args)
        {
            Init();
        }

        /// <summary>
        /// 属性设置修改后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertyGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            this.treeList1.RefreshDataSource();
            this.treeList2.RefreshDataSource();
            this.reportControl1.SetDataSource(new GenerateReport(this.propertyGridControl1.SelectedObject as _ObjectReport));
            this.reportControl1.m_reportData = this.propertyGridControl1.SelectedObject;

        }

        /// <summary>
        /// 批量预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.reportControl1.printControl1.PrintingSystem.ClearContent();
            if (this.xtraTabControl1.SelectedTabPage.Text == "清单报表")
            {
                this.TreeListChecked(this.treeList1, this.treeList1.Nodes);
            }
            else
            {
                this.TreeListChecked(this.treeList2, this.treeList2.Nodes);
            }
        }

        /// <summary>
        /// 报表列表切换行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListEx m_TreeList = sender as TreeListEx;
            if (m_TreeList != null)
            {
                _ObjectReport bs = m_TreeList.GetDataRecordByNode(m_TreeList.FocusedNode) as _ObjectReport;
                if (bs != null)
                {
                    if (bs.GetType().Name == "NodeReport")
                    {
                        this.reportControl1.pictureEdit1.Visible = true;
                        this.propertyGridControl1.AutoGenerateRows = true;
                        this.propertyGridControl1.SelectedObject = null;
                        this.reportControl1.printControl1.PrintingSystem.ClearContent();
                        
                    }
                    else
                    {
                        this.reportControl1.pictureEdit1.Visible = false;
                        this.propertyGridControl1.AutoGenerateRows = true;
                        this.propertyGridControl1.SelectedObject = bs;
                        this.reportControl1.SetDataSource(new GenerateReport(this.propertyGridControl1.SelectedObject as _ObjectReport));
                        this.reportControl1.m_reportData = this.propertyGridControl1.SelectedObject;
                    }
                }
            }
        }

        /// <summary>
        /// 递归批量预览
        /// </summary>
        /// <param name="p_TreeList"></param>
        /// <param name="p_nodes"></param>
        private void TreeListChecked(TreeListEx p_TreeList, TreeListNodes p_nodes)
        {
            foreach (TreeListNode item in p_nodes)
            {
                if (item.Checked)
                {
                    _ObjectReport m_ob = p_TreeList.GetDataRecordByNode(item) as _ObjectReport;
                    if (m_ob.GetType() != typeof(NodeReport))
                    {
                        this.reportControl1.SetDataSources(new GenerateReport(m_ob));
                        this.reportControl1.m_reportData = this.propertyGridControl1.SelectedObject;

                    }
                }
                this.TreeListChecked(p_TreeList, item.Nodes);
            }
        }

        /// <summary>
        /// 检查上节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        /// <summary>
        /// 检查下节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// <summary>
        /// 设置子节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 设置父节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        /// <summary>
        /// 上移动当前项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_Up_ItemClick(object sender, ItemClickEventArgs e)
        {

            //只能同级移动(交换两个排序规则)
            TreeListNode curr = this.m_TreeListFocused.Selection[0];
            if (curr == null) return;
            TreeListNode pre = curr.PrevNode;
            if (pre == null) return;
            if (curr.Level != pre.Level) return;

            _ObjectReport p_ObjectReport = this.m_TreeListFocused.GetDataRecordByNode(curr) as _ObjectReport;
            if (p_ObjectReport == null || p_ObjectReport.GetType() == typeof(NodeReport)) return;
            _ObjectReport p_ObjectReportMove = this.m_TreeListFocused.GetDataRecordByNode(pre) as _ObjectReport;
            bool b = pre.Expanded;
            bool b1 = curr.Expanded;
            this.Exchange(p_ObjectReport, p_ObjectReportMove);

            this.m_TreeListFocused.FocusedNode = this.m_TreeListFocused.FindNodeByKeyID(p_ObjectReport.ID);
            this.m_TreeListFocused.FocusedNode.Expanded = b1;
            this.m_TreeListFocused.FindNodeByKeyID(p_ObjectReportMove.ID).Expanded = b;
        }

        /// <summary>
        /// 下移动当前项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_Down_ItemClick(object sender, ItemClickEventArgs e)
        {
            //只能同级移动(交换两个排序规则)
            TreeListNode curr = this.m_TreeListFocused.Selection[0];
            if (curr == null) return;
            TreeListNode next = curr.NextNode;
            if (next == null) return;
            if (curr.Level != next.Level) return;
            _ObjectReport p_ObjectReport = this.m_TreeListFocused.GetDataRecordByNode(curr) as _ObjectReport;
            if (p_ObjectReport == null || p_ObjectReport.GetType() == typeof(NodeReport)) return;
            _ObjectReport objMove = this.m_TreeListFocused.GetDataRecordByNode(next) as _ObjectReport;
            bool b = next.Expanded;
            bool b1 = curr.Expanded;
            this.Exchange(p_ObjectReport, objMove);
            this.m_TreeListFocused.FocusedNode = this.m_TreeListFocused.FindNodeByKeyID(p_ObjectReport.ID);
            this.m_TreeListFocused.FocusedNode.Expanded = b1;
            this.m_TreeListFocused.FindNodeByKeyID(objMove.ID).Expanded = b;
        }

        /// <summary>
        /// 对象交换位置
        /// </summary>
        /// <param name="p_obj">源对象</param>
        /// <param name="p_objMove">交换位置对象</param>
        private void Exchange(_ObjectReport p_obj, _ObjectReport p_objMove)
        {
            int sort = p_obj.ID;
            p_obj.ID = p_objMove.ID;
            p_objMove.ID = sort;
            Refreshs();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void Refreshs()
        {
            ArrayList restlist_qd = new ArrayList();
            ArrayList restlist_jj = new ArrayList();
            restlist_qd.AddRange(this.m_ArrayList_qd.Cast<_ObjectReport>().OrderBy(p => p.ID).ToArray());
            restlist_jj.AddRange(this.m_ArrayList_jj.Cast<_ObjectReport>().OrderBy(p => p.ID).ToArray());
            this.m_ArrayList_qd.Clear();
            this.m_ArrayList_jj.Clear();
            this.m_ArrayList_qd.AddRange(restlist_qd.ToArray());
            this.m_ArrayList_jj.AddRange(restlist_jj.ToArray());
            this.treeList1.ExpandAll();
            this.treeList2.ExpandAll();
        }

        /// <summary>
        /// 切换当前选择的树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Text == "清单报表")
            {
                m_TreeListFocused = this.treeList1;
            }
            else
            {
                m_TreeListFocused = this.treeList2;
            }
            this.treeList_FocusedNodeChanged(m_TreeListFocused, null);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.openFileDialog1.Title = "导入报表格式";
            this.openFileDialog1.Filter = "报表格式(*.RF)|*.RF";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.FileName = "报表格式";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = "";
                path += System.IO.Path.GetDirectoryName(this.openFileDialog1.FileName) + "\\";//得到路径
                path += System.IO.Path.GetFileName(this.openFileDialog1.FileName);//得到文件名
                object m_object = this.BinaryDeserialize(path);
                if (m_object != null)
                {
                    ArrayList m_ArrayList = m_object as ArrayList;
                    if (m_ArrayList != null)
                    {
                        _List m_List = new _List();
                        m_List.AddRange(m_ArrayList.ToArray());
                        this.m_Report.ReportStencil = m_List;
                        this.Init();
                    }
                }
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.saveFileDialog1.Title = "导出报表格式";
            this.saveFileDialog1.Filter = "报表格式(*.RF)|*.RF";
            this.saveFileDialog1.FileName = "报表格式";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(this.saveFileDialog1.FileName);
                string filepath = saveFileDialog1.FileName;
                ArrayList m_ArrayList = new ArrayList();
                m_ArrayList.AddRange(this.m_Report.ReportStencil.ToArray());
                this.BinarySerialize(m_ArrayList, filepath);
            }
        }


        /// <summary>    
        /// 二进制序列化对象    
        /// </summary>    
        /// <param name="obj"></param>    
        public void BinarySerialize(object obj, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(stream, obj);
            }
        }

        /// <summary>    
        /// 二进制反序列化    
        /// </summary>    
        /// <param name="fileName"></param>    
        public object BinaryDeserialize(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formater = new BinaryFormatter();
                return formater.Deserialize(stream);
            }
        }
    }
}
