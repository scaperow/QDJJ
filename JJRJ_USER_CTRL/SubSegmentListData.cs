using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using DevExpress.Utils;
using System.Reflection;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using System.Collections;
using GOLDSOFT.QDJJ.CTRL.Forms;
namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class SubSegmentListData : BaseControl
    {


        public delegate void ChildRefresh();

        /// <summary>
        /// 委托-当编辑后处理日志的委托
        /// </summary>
        public delegate void EditAttributedHandler(object sender, ModifyAttribute e);

        /// <summary>
        /// 事件当发生编辑后的事件处理函数
        /// </summary>
        public event EditAttributedHandler EditAttributed;

        /// <summary>
        /// 当前模块发生编辑后的处理
        /// </summary>
        public void OnEditAttributed(ModifyAttribute e)
        {
            if (EditAttributed != null)
            {
                this.EditAttributed(this, e);
            }
        }

        /// <summary>
        /// 工料机的刷新
        /// </summary>
        public event ChildRefresh OnChildRefresh;
        private _CopyList copylist;

        private TreeListNode[] selectNodes;
        /// <summary>
        /// 获取或设置配色方案
        /// </summary>
        public _SchemeColor SchemeColor
        {
            get
            {
                return this.treeList1.SchemeColor;
            }
            set
            {
                this.treeList1.SchemeColor = value;

            }
        }
        //private int m_XH;
        ///// <summary>
        ///// 清单要显示的序号
        ///// </summary>
        //public int XH
        //{
        //    get { return m_XH; }
        //    set { m_XH = value; }
        //}
        /// <summary>
        /// 当前要处理的列
        /// </summary>
        private _Columns m_Columns = null;

        /// <summary>
        /// 获取或设置列队向
        /// </summary>
        public _Columns Columns
        {
            get
            {

                return this.m_Columns;
            }
            set
            {
                this.m_Columns = value;
            }
        }
        private _UnitProject m_DataSource = null;
        /// <summary>
        /// 默认的清单库文件名称
        /// </summary>
        public _UnitProject DataSource
        {
            set
            {
                this.m_DataSource = value;
            }
            get
            {
                return this.m_DataSource;
            }

        }
        private _Business m_Currentbus = null;
        /// <summary>
        /// 默认的业务
        /// </summary>
        public _Business Currentbus
        {
            get
            {
                return this.CurrentBusiness;
            }

        }

        /*  public BindingSource Source
          {
              get
              {
                 // return this.treeList1.DataSource as BindingSource;
                  return new BindingSource();
              }
          }*/
        public SubSegmentListData()
        {
            InitializeComponent();
            //
            //this.treeList1.Columns.AddRange(PostColumn);

        }


        private void SubSegmentListData_Load(object sender, EventArgs e)
        {
            //控件加载的时候申请分部分项数据操作接口申请转换操作
            this.repositoryItemCalcEdit2.DisplayFormat.FormatType = FormatType.Numeric;
            this.repositoryItemCalcEdit2.DisplayFormat.FormatString = "############0.######";
            this.repositoryItemCalcEdit2.EditMask = "############0.######"; //格式化 最大 千亿、保留4位小数
            // this.Expand("展开到清单");

        }
        public EListType m_EListType;
        /// <summary>
        /// 
        /// </summary>
        public EListType EListType
        {
            get { return m_EListType; }
            set { m_EListType = value; }
        }
        public void DataBind()
        {
            if (this.DataSource != null)
            {
                //this.m_DataSource.Property.SubSegments.ChangeSource();
                //this.treeList1.KeyFieldName = this.ColumnKeyFieldName;
                //this.treeList1.ParentFieldName = this.ColumnParentFieldName;
                //this.m_XH = 1;
                this.m_EListType = EListType.Default;
                switch (m_EListType)
                {
                    case EListType.Default:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = _ObjectInfo.FILED_FPARENID;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = "LB not in ('分部-章','分部-节','分部-专业') or LB is null";
                        break;
                    case EListType.Chapter:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = _ObjectInfo.FILED_CPARENID;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = "LB not in ('分部-节') or LB is null";
                        break;

                    case EListType.Professional:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = _ObjectInfo.FILED_PPARENTID;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = "LB not in ('分部-章','分部-节') or LB is null";
                        break;
                    default:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = "PID";
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = string.Empty;
                        break;

                }

                //数据绑定方法
                //根据接口类型不同执行不同的转换操作

                //this.bindingSource1 =this.m_DataSource.SubSegments.DataSource;

                //this.treeList1.DataSource = this.m_DataSource.Property.SubSegments.DataSource;
                // this.treeList1.ExpandAll();
                //this.DataSource.Property.SubSegments.DataSource.ResetBindings(false);
                /*this.bindingSource1.DataSource = this.m_DataSource.StructSource.ModelSubSegments.DefaultView;
                this.treeList1.DataSource = this.bindingSource1;
                this.bindingSource1.Sort = "Sort";*/
                this.m_DataSource.StructSource.ModelSubSegments.DefaultView.Sort = "Sort";
                this.treeList1.DataSource = this.m_DataSource.StructSource.ModelSubSegments.DefaultView;
                this.Expand("展开到清单");
            }
        }

        public void DataBind(EListType p_EListType)
        {
            this.m_EListType = p_EListType;
            if (this.DataSource != null)
            {
                //this.m_DataSource.Property.SubSegments.ChangeSource();
                //this.treeList1.KeyFieldName = this.ColumnKeyFieldName;
                //this.treeList1.ParentFieldName = this.ColumnParentFieldName;
                //this.m_XH = 1;
                switch (p_EListType)
                {
                    case EListType.Default:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = _ObjectInfo.FILED_FPARENID;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = "LB not in ('分部-章','分部-节','分部-专业') or LB is null";
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.Sort = "Sort";
                        break;
                    case EListType.Chapter:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = _ObjectInfo.FILED_CPARENID;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = "LB not in ('分部-节') or LB is null";
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.Sort = "XMBM asc,Sort asc ";
                        break;

                    case EListType.Professional:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = _ObjectInfo.FILED_PPARENTID;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = "LB not in ('分部-章','分部-节') or LB is null";
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.Sort = "XMBM asc,Sort asc";
                        break;
                    default:
                        this.treeList1.KeyFieldName = _ObjectInfo.FILED_ID;
                        this.treeList1.ParentFieldName = "PID";
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.RowFilter = string.Empty;
                        this.m_DataSource.StructSource.ModelSubSegments.DefaultView.Sort = "XMBM asc,Sort asc";
                        break;
                }
            }
        }
        //添加序号列
        private void treeList1_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tmpTree = sender as DevExpress.XtraTreeList.TreeList;
            if (tmpTree.IsUnboundMode)
            {

                DevExpress.Utils.Drawing.IndicatorObjectInfoArgs args = e.ObjectArgs as DevExpress.Utils.Drawing.IndicatorObjectInfoArgs;
                if (args != null)
                {
                    string str = e.Node.GetValue(CEntitySubSegment.FILED_LB).ToString();
                    if (args.DisplayText == string.Empty)
                    {
                        args.DisplayText = e.Node.GetValue(CEntitySubSegment.FILED_XH).ToString();
                    }

                    /*int rowNum = tmpTree.GetVisibleIndexByNode(e.Node) + 1;
                    args.DisplayText = rowNum.ToString();*/
                }
                e.ImageIndex = -1;

            }
        }
        private void treeList1_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {

            switch (e.Column.FieldName)
            {
                case _ObjectInfo.FILED_XMMC:
                    int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["名称显示方式"]);
                    if (m == 1)
                    {
                        e.RepositoryItem = this.RItemMemoExEdit;
                        // e.Column.ColumnEdit = null;
                    }
                    else
                    {
                        //e.Column.ColumnEdit = this.repositoryItemMemoEdit1;
                    }


                    break;
                case _ObjectInfo.FILED_XMTZ:

                    //e.RepositoryItem = this.RItemMemoExEdit;
                    break;
                case _ObjectInfo.FILED_BEIZHU:
                    e.RepositoryItem = this.RItemMemoExEdit;
                    break;


                //case _ObjectInfo.FILED_ZJTJ:
                //    e.RepositoryItem = this.RItemCalcEdit;
                //break;
                case _ObjectInfo.FILED_GCLJSS:
                    e.RepositoryItem = this.RItemButtonEdit;
                    break;
                case _ObjectInfo.FILED_XMBM:
                    DataRowView v = this.treeList1.Current as DataRowView;
                    if (v["LB"].Equals("清单"))
                    {
                        e.RepositoryItem = this.repositoryItemButtonEdit1;
                    }

                    //if (v["LB"].ToString().Contains("子目"))
                    //{
                    //    e.RepositoryItem = this.repositoryItemPopupContainerEdit1;
                    //    //_FSubheadingsInfo sinfo = this.Source.Current as _FSubheadingsInfo;
                    //    //if (sinfo != null)
                    //    //{
                    //    //    BindLook((this.Source.Current as _ObjectInfo).LibraryName);
                    //    //    FilterLook(getFilter(sinfo.Parent.LibraryName, sinfo.Parent.OLDXMBM));
                    //    //}
                    //}     
                    //repositoryItemComboBox1.ed
                    break;

                // case _ObjectInfo.FILED_GCL:
                // e.RepositoryItem.AppearanceFocused.TextOptions.HAlignment = HorzAlignment.Center;
                //e.RepositoryItem.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                //  break;
                default:
                    // e.Column.OptionsColumn.AllowEdit = false;
                    break;
            }

        }
        public void ChangeRepositoryItem()
        {
            int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["名称显示方式"]);
            if (m == 1)
            {
                treeListColumn2.ColumnEdit = null;
                this.treeList1.Refresh();
            }
            else
            {
                treeListColumn2.ColumnEdit = this.repositoryItemMemoEdit1;
                this.treeList1.Refresh();
            }
        }



        private void treeList1_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {


        }
        private void RItemLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.LookUpEdit look = sender as DevExpress.XtraEditors.LookUpEdit;
            //DataRowView view = look.GetSelectedDataRow() as DataRowView;
            //_ObjectInfo view1 = this.treeList1.Current as _ObjectInfo;
            //if (view1 != null)
            //{


            //    if (view1.LB == "清单")
            //    {
            //      //_FixedListInfo info = view1 as _FixedListInfo;
            //       // this.DataSource.Property.SubSegments.Methods.SetFixedInfo(info, view.Row, this.m_DataSource.Property.Libraries.ListGallery.FullName);
            //        //this.m_DataSource.Property.SubSegments.DataSource.ResetBindings(false);
            //        //this.m_DataSource.SubSegment.FixedList.Add();
            //    }
            //    if (view1.LB == "子目")
            //     {
            //         //_SubheadingsInfo info = view1 as _SubheadingsInfo;
            //         //this.DataSource.Property.SubSegments.Methods.SetSubheadingsInfo(info, view.Row, this.m_DataSource.Property.Libraries.FixedLibrary.FullName);
            //         //info.Create();
            //    }


            //}
        }
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            treeList1_FocusedColumnChanged(sender, new FocusedColumnChangedEventArgs(this.treeList1.FocusedColumn, this.treeList1.FocusedColumn));
        }
        public bool IsKong(int ID)
        {
            DataRow[] infos1 = this.m_DataSource.StructSource.ModelSubSegments.Select(string.Format("ID={0}", ID));
            if (infos1.Length > 0)
            {
                DataRow infos = infos1[0];
                if ((infos["XMBM"].Equals(DBNull.Value) || infos["XMBM"].Equals(string.Empty)) && (infos["XMMC"].Equals(DBNull.Value) || infos["XMMC"].Equals(string.Empty)))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 删除空行数据
        /// </summary>
        /// <param name="ID"></param>
        public void DelKong(int ID)
        {
            DataRow[] infos = this.m_DataSource.StructSource.ModelSubSegments.Select(string.Format(" XMBM is null and  XMMC is null and id<>{0}", ID));
            for (int i = 0; i < infos.Length; i++)
            {
                try
                {

                    if (infos[i]["LB"].Equals("清单"))
                    {
                        _Entity_SubInfo info2 = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info2, infos[i]);
                        GLODSOFT.QDJJ.BUSINESS._Methods mets = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Currentbus, this.DataSource, info2);
                        mets.RemoveAllChild();
                    }
                    else
                    {
                        infos[i].Delete();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
        private void treeList1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {

            TreeListEx t = sender as TreeListEx;
            if (t.FocusedNode == null) return;
            if (t.FocusedNode.GetValue("LB") == null) return;
            // 
            string str = t.FocusedNode.GetValue("LB").ToString();

            switch (str)
            {
                case "子目":
                    if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SDDJ"] != null) this.treeList1.Columns["SDDJ"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["HL"] != null) this.treeList1.Columns["HL"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["TX"] != null) this.treeList1.Columns["TX"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["GCLJSS"] != null) this.treeList1.Columns["GCLJSS"].OptionsColumn.AllowEdit = true;
                    if (this.treeList1.Columns["ZJTJ"] != null) this.treeList1.Columns["ZJTJ"].OptionsColumn.AllowEdit = true;
                    break;
                case "清单":
                    if (this.CurrentBusiness.Current.IsDZBS && e.Column != null && !APP.Jzbx_pwd)
                    {
                        switch (e.Column.FieldName)
                        {
                            case "FHBJ":
                            case "JCBJ":
                                e.Column.OptionsColumn.AllowEdit = true;
                                break;
                            default:
                                e.Column.OptionsColumn.AllowEdit = false;
                                break;
                        }
                    }
                    else
                    {
                        if (t.FocusedNode.GetValue("SDQD").Equals(true))
                        {
                            if (this.treeList1.Columns["SDDJ"] != null) this.treeList1.Columns["SDDJ"].OptionsColumn.AllowEdit = false;
                            //this.treeList1.OptionsBehavior.Editable = false;
                            if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["HL"] != null) this.treeList1.Columns["HL"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["TX"] != null) this.treeList1.Columns["TX"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["GCLJSS"] != null) this.treeList1.Columns["GCLJSS"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["ZJTJ"] != null) this.treeList1.Columns["ZJTJ"].OptionsColumn.AllowEdit = false;
                        }
                        else
                        {
                            if (this.treeList1.Columns["SDDJ"] != null) this.treeList1.Columns["SDDJ"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["HL"] != null) this.treeList1.Columns["HL"].OptionsColumn.AllowEdit = false;
                            if (this.treeList1.Columns["TX"] != null) this.treeList1.Columns["TX"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["GCLJSS"] != null) this.treeList1.Columns["GCLJSS"].OptionsColumn.AllowEdit = true;
                            if (this.treeList1.Columns["ZJTJ"] != null) this.treeList1.Columns["ZJTJ"].OptionsColumn.AllowEdit = true;
                        }
                    }
                    break;
                default:
                    if (this.treeList1.Columns["XMMC"] != null) this.treeList1.Columns["XMMC"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["XMBM"] != null) this.treeList1.Columns["XMBM"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["JX"] != null) this.treeList1.Columns["JX"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["JBHZ"] != null) this.treeList1.Columns["JBHZ"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SFFB"] != null) this.treeList1.Columns["SFFB"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SDQD"] != null) this.treeList1.Columns["SDQD"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["GCL"] != null) this.treeList1.Columns["GCL"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["HL"] != null) this.treeList1.Columns["HL"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["TX"] != null) this.treeList1.Columns["TX"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["DW"] != null) this.treeList1.Columns["DW"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["GCLJSS"] != null) this.treeList1.Columns["GCLJSS"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["ZJTJ"] != null) this.treeList1.Columns["ZJTJ"].OptionsColumn.AllowEdit = false;
                    if (this.treeList1.Columns["SDDJ"] != null) this.treeList1.Columns["SDDJ"].OptionsColumn.AllowEdit = false;
                    break;
            }

        }


        DataView view;
        private void BindLook(string LibraryName)
        {
            if (string.IsNullOrEmpty(LibraryName)) return;

            _Library.GetLibrary(LibraryName);
            DataSet ds = _Library.Libraries[LibraryName] as DataSet;
            DataTable table = ds.Tables["定额表"].Copy();
            if (!table.Columns.Contains("DISPLAY"))
            {
                table.Columns.Add("DISPLAY", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                row.BeginEdit();
                row["DISPLAY"] = string.Format("【{0}】{1}", row["DINGEH"], row["DINGEMC"]);
                row.EndEdit();
            }
            view = table.DefaultView;
            this.gridControl1.DataSource = view;
        }
        private string getFilter(string LibraryName, string QDBH)
        {
            string str = "";
            _Library.GetLibrary(LibraryName);

            DataSet ds = _Library.Libraries[LibraryName] as DataSet;
            if (ds == null) return "";
            DataTable table = ds.Tables["指引内容表"].Copy();
            DataRow[] rows = table.Select(string.Format("QINGDBH = '{0}'", QDBH));
            this.gridView1.Columns[0].Caption = "";
            foreach (DataRow item in rows)
            {
                str += rows[0]["ZHIYDE"].ToString();
                this.gridView1.Columns[0].Caption += rows[0]["NRMC"].ToString();
            }
            return str;
        }
        private void FilterLook(string filter)
        {
            string Filter = "";
            string[] arr = filter.Split('|');
            foreach (string item in arr)
            {
                string[] items = item.Split(',');
                foreach (string item1 in items)
                {
                    if (!string.IsNullOrEmpty(item1))
                    {
                        Filter += "'" + item1 + "',";
                    }
                }
            }
            if (!string.IsNullOrEmpty(Filter))
            {
                Filter = Filter.Substring(0, Filter.Length - 1);
                if (view != null)
                    view.RowFilter = string.Format("DINGEH in ({0})", Filter);
            }
            else { view.RowFilter = "1<>1"; }
        }
        //private void RItemLookUpEdit_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    DevExpress.XtraEditors.LookUpEdit look = sender as DevExpress.XtraEditors.LookUpEdit;
        //    AddByTree(look.Text);
        //}

        private void Delete(DataRow v)
        {
            _Entity_SubInfo info2 = new _Entity_SubInfo();
            string id = v["PID"].ToString();

            DataRow row = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(id);

            if (v["LB"].Equals("清单"))
            {
                _Entity_SubInfo info3 = new _Entity_SubInfo();
                _ObjectSource.GetObject(info3, v);
                GLODSOFT.QDJJ.BUSINESS._Methods mets = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Currentbus, this.DataSource, info3);
                mets.RemoveAllChild();
            }
            else
            {
                if (row != null)
                {
                    _ObjectSource.GetObject(info2, row);
                    v.Delete();
                    GLODSOFT.QDJJ.BUSINESS._Methods met = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Currentbus, this.DataSource, info2);
                    met.Begin(null);
                }
            }
        }
        private void AddByTree(string xmbm)
        {
            DataRowView v = this.treeList1.Current as DataRowView;
            _Entity_SubInfo view1 = new _Entity_SubInfo();
            _ObjectSource.GetObject(view1, v.Row);

            _Entity_SubInfo FoucuseInfo = null;
            string xmmc = xmbm;
            if (view1.LB == "清单")
            {
                DataRow[] rows = this.m_DataSource.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"].Copy().Select(string.Format("QINGDBH='{0}'", xmmc));
                if (rows.Length > 0)
                {
                    ///【2013.2.26 李波更改，作用处理各种备注来源】
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetFixedInfo(view1, rows[0], this.m_DataSource.Property.Libraries.ListGallery.FullName, this.m_DataSource.StructSource.ModelSubSegments, "SGSR");
                    //GLODSOFT.QDJJ.BUSINESS._Methods.SetFixedInfo(view1, rows[0], this.m_DataSource.Property.Libraries.ListGallery.FullName, this.m_DataSource.StructSource.ModelSubSegments);
                    //  this.m_DataSource.StructSource.ModelSubSegments.UpDate(view1);
                    int index = ToolKit.ParseInt(v["Sort"]);
                    Delete(v.Row);

                    Q_Inset(view1, index);
                    FoucuseInfo = view1;

                }
                else
                {
                    _Entity_SubInfo info = view1 as _Entity_SubInfo;
                    DialogResult r = MessageBox.Show("清单不存在是否删除？", "提示", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        Delete(v.Row);
                    }
                    else
                    {
                        //若不删除 则新添加为补充清单
                        _Entity_SubInfo info1 = new _Entity_SubInfo();
                        info1.LB = view1.LB;
                        info1.ZJWZ = "999999";
                        info1.XMBM = GLODSOFT.QDJJ.BUSINESS._Methods.GetQBH("补" + xmmc, this.DataSource.StructSource.ModelSubSegments);
                        info1.OLDXMBM = "补" + xmmc;
                        info1.XMMC = "补充清单";
                        info1.TX = "jz";
                        info1.GCL = 1;
                        info1.SC = true;
                        if (string.IsNullOrEmpty(info1.BEIZHU) && !string.IsNullOrEmpty(info1.XMBM))
                        {
                            info1.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetQDbeizhu(info1.OLDXMBM, 0, "SGSR");
                        }
                        info.LibraryName = this.m_DataSource.Property.Libraries.ListGallery.FullName;
                        Q_Inset(info1);
                        FoucuseInfo = info1;
                        Delete(v.Row);

                    }
                }
                // this.DataBind();

                if (FoucuseInfo != null) FocusedNode(FoucuseInfo.ID);
                return;
            }
            if (view1.LB == "子目")
            {
                string temp = xmmc.Split(' ')[0];
                DataRow[] rows = this.m_DataSource.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy().Select(string.Format("DINGEH='{0}'", temp));
                string JXDE = "15-1,15-2,15-3,15-4,15-5,15-6,15-7,15-8,15-9,15-10,15-11,15-23,15-24,15-25,15-26,15-27,15-28,15-29,15-30,15-31";
                bool flag = false;
                string[] arr = JXDE.Split(',');
                foreach (string item in arr)
                {
                    if (item == temp)
                    {
                        flag = true;
                        break;
                    }
                }
                if (rows.Length > 0 && !flag)
                {
                    //_SubheadingsInfo info1 = this.Source.Current as _SubheadingsInfo;
                    //if (info1 == null) return;
                    //_FixedListInfo pinfo = info1.Parent;
                    //pinfo.OnZiMuAdded -= new _FixedListInfo.ZiMuAdd(pinfo_OnZiMuAdded);

                    //_SubheadingsInfo sinfo = new _FSubheadingsInfo();
                    //pinfo.RemoveOnZiMuAddEvent();
                    //pinfo.OnZiMuAdded += new _FixedListInfo.ZiMuAdd(pinfo_OnZiMuAdded);
                    _Entity_SubInfo sinfo = new _Entity_SubInfo();
                    ///【2013.2.27 李波更改，作用处理各种备注来源】
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, rows[0], this.m_DataSource.Property.Libraries.FixedLibrary.FullName, "SGSR", 1, GetQDBM());
                    //GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, rows[0], this.m_DataSource.Property.Libraries.FixedLibrary.FullName);
                    sinfo.XMBM = xmmc;
                    //pinfo.Create(sinfo, this.Source[this.Source.Position - 1] as _SubheadingsInfo);
                    string pid = v["PID"].ToString();
                    int index = ToolKit.ParseInt(v["Sort"]);

                    FoucuseInfo = sinfo;
                    Z_Inset(pid, sinfo, index);
                    DataRow row = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(pid);
                    if (row != null)
                    {
                        sinfo.GCL = ToolKit.ParseDecimal(row["GCL"]);
                    }
                    else
                    {
                        sinfo.GCL = 1;
                    }
                    _Methods_Subheadings met = new _Methods_Subheadings(this.Currentbus, this.DataSource, sinfo);
                    met.UpHL();
                    met.Begin(null);
                    Delete(v.Row);

                }
                else
                {
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    info.LB = view1.LB;
                    xmmc = xmmc.Replace("补", "");
                    info.XMBM = "补" + xmmc;
                    info.OLDXMBM = "补" + xmmc;
                    info.XMMC = "补充定额";
                    info.TX = "建筑";
                    info.SC = true;
                    info.LibraryName = this.m_DataSource.Property.Libraries.FixedLibrary.FullName;
                    if (string.IsNullOrEmpty(info.BEIZHU) && !string.IsNullOrEmpty(info.XMBM))
                    {
                        info.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("SGSR", 0, GetQDBM());
                    }
                    Z_Inset(info);
                    FoucuseInfo = info;
                    Delete(v.Row);
                }
                // this.DataBind();
                if (FoucuseInfo != null) FocusedNode(FoucuseInfo.ID);
                if (OnChildRefresh != null)
                {
                    OnChildRefresh();
                }

                return;
            }
        }

        public string GetQDBM()
        {
            string s = string.Empty;
            DataRowView v = this.treeList1.Current;
            if (v != null)
            {
                if (v["LB"].Equals("清单"))
                {
                    return v["OLDXMBM"].ToString();
                }
                if (v["LB"].Equals("子目"))
                {
                    DataRow r = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(v["PID"].ToString());
                    if (r != null)
                    {
                        return r["OLDXMBM"].ToString();
                    }
                }
            }
            return s;
        }
        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            TreeList tl = sender as TreeList;
            DataRowView v = tl.GetDataRecordByNode(e.Node) as DataRowView;
            if (v == null) return;
            _Entity_SubInfo info = new _Entity_SubInfo();
            this.DataSource.StructSource.ModelSubSegments.GetRowByOther(v["ID"].ToString());
            _ObjectSource.GetObject(info, v.Row);
            GLODSOFT.QDJJ.BUSINESS._Methods met = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Currentbus, this.DataSource, info);
            if (e.Column.FieldName == "XMBM")
            {
                //if (info.LB.Contains("子目"))
                {
                    DataRow r = v.Row;
                    if (r.HasVersion(DataRowVersion.Current))
                    {
                        string oldvalue = r["XMBM", DataRowVersion.Current].ToString();
                        string newvalue = r["XMBM"].ToString();
                        if (!oldvalue.Equals(newvalue)) this.AddByTree(ToolKit.ToDBC(newvalue));
                    }

                }
            }
            else
            {
                _Modify_Method.Edit_Sub(e.Column.FieldName, met, v.Row);
                ModifyAttribute modity = new ModifyAttribute();
                modity.CurrentValue = v[e.Column.FieldName];
                modity.OriginalValue = ChangeObject;
                modity.ObjectName = e.Column.Caption;
                modity.ModelName = "分部分项";
                modity.Source = v.Row;
                modity.FieldName = e.Column.FieldName;
                //modity.ActingOn = "清单.子目";
                ChangeObject = null;
                this.OnEditAttributed(modity);
                if (this.OnChildRefresh != null) this.OnChildRefresh();
            }
            this.m_DataSource.EndModfity();
            //info.Activitie.BeginEdit(this);

        }

        object ChangeObject = null;

        private void treeList1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {

            TreeList tl = sender as TreeList;
            _ObjectInfo info = tl.GetDataRecordByNode(e.Node) as _ObjectInfo;

            //通知单位工程修改
            this.m_DataSource.BeginModfity(info, e.Column.FieldName);

            if (e.Column.ColumnType == typeof(bool))
            {
                //SendKeys.Send("{ENTER}");此处会导致 添加新行
            }
            DataRowView v = tl.GetDataRecordByNode(e.Node) as DataRowView;
            ChangeObject = v.Row[e.Column.FieldName];
        }
        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {

            TreeList tl = sender as TreeList;
            TreeListHitInfo tinfo = tl.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Right)
            {
                if (tinfo.Node != null)
                {
                    tl.FocusedNode = tinfo.Node;
                    DataRowView info = this.treeList1.GetDataRecordByNode(tl.FocusedNode) as DataRowView;
                    if (info["XMBM"].Equals("单位工程"))
                    {
                        this.barButtonItemAddQD.Enabled = true;
                        this.barButtonItemAddZM.Enabled = false;
                        this.btnDataErr.Enabled = false;
                        this.barButtonItemDelete.Enabled = false;
                        this.barButtonItemCopy.Enabled = false;
                        this.barButtonItemStick.Enabled = false;
                        if (this.Currentbus.Current.IsDZBS && !APP.Jzbx_pwd)
                        {
                            this.barSubItemZLD.Enabled = false;
                        }
                        else
                        {
                            this.barSubItemZLD.Enabled = true;
                        }
                        //this.barSubItemZLD.Enabled = !this.Currentbus.Current.IsDZBS;

                    }
                    else if (info["LB"].Equals("分部-专业") || info["LB"].Equals("分部-章") || info["LB"].Equals("分部-节"))
                    {
                        this.barButtonItemAddQD.Enabled = true;
                        this.barButtonItemAddZM.Enabled = false;
                        this.btnDataErr.Enabled = false;
                        //this.barButtonItemDelete.Enabled = !this.Currentbus.Current.IsDZBS;
                        this.barButtonItemCopy.Enabled = false;
                        this.barButtonItemStick.Enabled = false;
                        //this.barSubItemZLD.Enabled = !this.Currentbus.Current.IsDZBS;

                        if (this.Currentbus.Current.IsDZBS && !APP.Jzbx_pwd)
                        {
                            this.barButtonItemDelete.Enabled = false;
                            this.barSubItemZLD.Enabled = false;
                        }
                        else
                        {
                            this.barButtonItemDelete.Enabled = true;
                            this.barSubItemZLD.Enabled = true;
                        }
                    }
                    else if (info["LB"].Equals("清单"))
                    {
                        //this.barButtonItemAddQD.Enabled = !this.Currentbus.Current.IsDZBS;
                        this.barButtonItemAddZM.Enabled = true;
                        this.btnDataErr.Enabled = true;

                        //this.barButtonItemDelete.Enabled = !this.Currentbus.Current.IsDZBS;
                        //this.barButtonItemCopy.Enabled = !this.Currentbus.Current.IsDZBS;
                        //this.barSubItemZLD.Enabled = !this.Currentbus.Current.IsDZBS;
                        if (this.Currentbus.Current.IsDZBS && !APP.Jzbx_pwd)
                        {
                            this.barButtonItemAddQD.Enabled = false;
                            this.barButtonItemDelete.Enabled = false;
                            this.barButtonItemCopy.Enabled = false;
                            this.barSubItemZLD.Enabled = false;
                            this.barButtonItem4.Enabled = false;
                            this.barButtonItemStick.Enabled = false;
                            this.barButtonItem13.Enabled = false;
                            this.barButtonItem19.Enabled = false;
                        }
                        else
                        {
                            this.barButtonItemAddQD.Enabled = true;
                            this.barButtonItemDelete.Enabled = true;
                            this.barButtonItemCopy.Enabled = true;
                            this.barSubItemZLD.Enabled = true;
                            this.barButtonItem4.Enabled = true;
                            this.barButtonItemStick.Enabled = true;
                            this.barButtonItem13.Enabled = true;
                            this.barButtonItem19.Enabled = true;
                            if (this.copylist != null)
                            {
                                this.barButtonItemStick.Enabled = true;
                            }
                            else
                            {
                                this.barButtonItemStick.Enabled = false;
                            }
                        }


                    }
                    else
                    {
                        if (this.Currentbus.Current.IsDZBS && !APP.Jzbx_pwd)
                        {
                            this.barButtonItemAddQD.Enabled = false;
                            this.barSubItemZLD.Enabled = false;
                        }
                        else
                        {
                            this.barButtonItemAddQD.Enabled = true;
                            this.barSubItemZLD.Enabled = true;
                        }

                        //this.barButtonItemAddQD.Enabled = !this.Currentbus.Current.IsDZBS;
                        this.barButtonItemAddZM.Enabled = true;
                        this.btnDataErr.Enabled = true;

                        //this.barSubItemZLD.Enabled = !this.Currentbus.Current.IsDZBS;

                        if (this.treeList1.Selection.Cast<TreeListNode>().Where(p => (p.Selected && p.GetValue("LB").ToString().Contains("子目"))).Count() == this.treeList1.Selection.Count)
                        {
                            this.barButtonItemDelete.Enabled = true;
                            this.barButtonItemCopy.Enabled = true;
                        }
                        else
                        {
                            if (this.Currentbus.Current.IsDZBS && !APP.Jzbx_pwd)
                            {
                                this.barButtonItemDelete.Enabled = false;
                                this.barButtonItemCopy.Enabled = false;
                            }
                            else 
                            {
                                this.barButtonItemDelete.Enabled = true;
                                this.barButtonItemCopy.Enabled = true;
                            }

                            //this.barButtonItemDelete.Enabled = !this.Currentbus.Current.IsDZBS;
                            //this.barButtonItemCopy.Enabled = !this.Currentbus.Current.IsDZBS;
                        }
                        if (this.copylist != null)
                        {
                            this.barButtonItemStick.Enabled = true;
                        }
                        else
                        {
                            this.barButtonItemStick.Enabled = false;
                        }
                    }
                }
                SetZhankai();
                this.popupMenu_up.ShowPopup(Control.MousePosition);
            }
        }


        private void SetZhankai()
        {
            switch (this.m_EListType)
            {
                case EListType.Default:
                    this.barButtonItem5.Enabled = false; //专业
                    this.barButtonItem9.Enabled = false;//章
                    this.barButtonItem10.Enabled = false;//节
                    this.barButtonItem11.Enabled = true;//清单
                    this.barButtonItem12.Enabled = true;//子目
                    break;
                case EListType.Professional:
                    this.barButtonItem5.Enabled = true; //专业
                    this.barButtonItem9.Enabled = false;//章
                    this.barButtonItem10.Enabled = false;//节
                    this.barButtonItem11.Enabled = true;//清单
                    this.barButtonItem12.Enabled = true;//子目
                    break;
                case EListType.Chapter:
                    this.barButtonItem5.Enabled = true; //专业
                    this.barButtonItem9.Enabled = true;//章
                    this.barButtonItem10.Enabled = false;//节
                    this.barButtonItem11.Enabled = true;//清单
                    this.barButtonItem12.Enabled = true;//子目
                    break;
                case EListType.Festival:
                    this.barButtonItem5.Enabled = true; //专业
                    this.barButtonItem9.Enabled = true;//章
                    this.barButtonItem10.Enabled = true;//节
                    this.barButtonItem11.Enabled = true;//清单
                    this.barButtonItem12.Enabled = true;//子目
                    break;
                default:
                    break;
            }
        }
        private bool IsCopy()
        {
            /* if (this.treeList1.Selection.Count > 0)
             {
                 foreach (TreeListNode item in this.treeList1.Selection)
                 {
                     if (this.treeList1.Selection[0].Level != item.Level)
                     {
                         return false;
                     }
                 }
                 return true;
             }*/
            DataRowView o = this.treeList1.Current;
            if (o["LB"].Equals("清单"))
            {

                return true;
            }
            if (o["LB"].ToString().Contains("子目"))
            {
                return true;
            }

            return false;
        }
        private void SetCopyValue()
        {
            copylist = new _CopyList();

            //DataRowView o = this.treeList1.Current;
            //selectNodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).ToArray();

            TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).ToArray();
            foreach (TreeListNode node in nodes)
            {
                DataRowView o = this.treeList1.GetDataRecordByNode(node) as DataRowView;

                if (o != null)
                {
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, o.Row);
                    copylist.Add(info);
                }
            }
        }
        private void Paste()
        {
            //TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).ToArray();
            TreeListNode node = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).First();//  .ToArray();

            using (var calculator = new Calculator(CurrentBusiness, DataSource))
            {
                if (node != null)
                {
                    DataRowView o = this.treeList1.GetDataRecordByNode(node) as DataRowView;

                    if (o != null)
                    {
                        _Entity_SubInfo info = null;
                        if (o["LB"].Equals("清单"))
                        {
                            info = new _Entity_SubInfo();
                            _ObjectSource.GetObject(info, o.Row);
                        }
                        if (o["LB"].ToString().Contains("子目"))
                        {
                            info = new _Entity_SubInfo();
                            DataRow row = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(o["PID"].ToString());
                            _ObjectSource.GetObject(info, row);
                        }

                        GLODSOFT.QDJJ.BUSINESS._Methods met = null;
                        copylist.Sort(new SortObj());
                        calculator.Entities.Add(info);

                        foreach (_Entity_SubInfo item in copylist)
                        {
                            switch (item.LB)
                            {
                                case "清单":
                                    met = new _Methods_Fixed(this.CurrentBusiness, this.DataSource, item);
                                    met.CopyTo(info);
                                    break;
                                case "子目":
                                    if (info != null)
                                    {
                                        met = new _Methods_Subheadings(this.CurrentBusiness, this.DataSource, item);
                                        met.CopyTo(info);
                                    }
                                    break;
                                default:
                                    break;
                            }

                            calculator.Entities.Add(item);
                        }     
                    }
                }

                RestLSH();
                this.RestXH();

                this.treeList1.RefreshDataSource();
            }

        }

        /// <summary>
        /// 数据提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnDataErr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                StringBuilder strTemp = new StringBuilder();
                TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).ToArray();
                foreach (TreeListNode node in nodes)
                {
                    DataRowView o = this.treeList1.GetDataRecordByNode(node) as DataRowView;

                    if (o != null)
                    {
                        strTemp.Append(toString(o["XMMC"]) + ",");
                    }
                }

                //DataRowView currRow = this.bindingSource1.Current as DataRowView;
                if (string.IsNullOrEmpty(strTemp.ToString())) return;
                DataErr formDataErr = new DataErr();
                formDataErr.StrFormName = "分部分项";
                
                formDataErr.StrColNameVal += "{" + strTemp.ToString().Substring(1, strTemp.ToString().Length - 1) + "}";
                formDataErr.ShowDialog();
            }
            catch (Exception e1){
                throw e1;
            }
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
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_Entity_SubInfo info = this.DataSource.Property.SubSegments.DataSource.Current as _Entity_SubInfo;
            _Entity_SubInfo FoucuseInfo = null;
            switch (e.Item.Caption)
            {
                case "删除所选":
                    // info.pa
                    DialogResult d = MessageBox.Show("确认删除？", "提示", MessageBoxButtons.OKCancel);
                    if (d == DialogResult.OK)
                    {

                        using (var calculator = new Calculator(CurrentBusiness, DataSource))
                        {
                            var moduleMemos = new List<string>();
                            int ID = 0;
                            TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).OrderByDescending(p => p.Id).ToArray();
                            //foreach (TreeListNode item in nodes)
                            //{

                            for (int i = 0; i < nodes.Length; i++)
                            {
                                string bh = nodes[i].GetValue(0).ToString();

                            TreeListNode fnode = nodes[i].PrevNode;// item.PrevNode;
                            if (fnode == null) fnode = nodes[i].ParentNode;// item.ParentNode;
                            DataRowView view = this.treeList1.GetDataRecordByNode(nodes[i]) as DataRowView;

                            //update by fuqiang 2013年6月27日
                            DataView table = this.treeList1.DataSource as DataView;
                            DataRow[] currows = table.Table.Select("XMBM='" + bh + "'");

                            if (view == null) return;
                            if (view["SDQD"].Equals(true)) continue;
                            if (view != null)

                            //if (currows == null || currows.Length <= 0) return;
                            //foreach (DataRow dr in currows)
                            //{
                            //    if (dr["SDQD"].Equals(true)) continue;
                            //if (dr != null)
                            {

                                _Entity_SubInfo info1 = new _Entity_SubInfo();
                                //string id = view["PID"].ToString();
                                string id = view["id"].ToString();
                                //string id = dr["id"].ToString();
                                DataRow row = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(id);
								_ObjectSource.GetObject(info1, row);
                                calculator.Entities.Add(info1);

                                DataRow[] gljRows = this.DataSource.StructSource.ModelQuantity.Select("ZMID = " + id);
                                DataRow[] scRows = this.DataSource.StructSource.ModelStandardConversion.Select("ZMID = " + id);
                                DataRow[] zmqfRows = this.DataSource.StructSource.ModelSubheadingsFee.Select("ZMID = " + id);
                                DataRow[] cszmqfRows = this.DataSource.StructSource.ModelPSubheadingsFee.Select("ZMID = " + id);
                                if (row != null)
                                {
                                    _ObjectSource.GetObject(info1, row);
                                    if (view["LB"].Equals("清单"))
                                    //if (dr["LB"].Equals("清单"))
                                    {
                                        _Entity_SubInfo info2 = new _Entity_SubInfo();
                                        _ObjectSource.GetObject(info2, view.Row);

                                            var moduleRows = DataSource.StructSource.ModelSubSegments.Select(string.Format(" PID = '{0}' AND TX LIKE '模板'", info2.ID));
                                            if (moduleRows != null && moduleRows.Length > 0)
                                            {
                                                foreach (DataRow moduleRow in moduleRows)
                                                {
                                                    moduleMemos.Add(moduleRow["XH"].ToString());
                                                }
                                            }
                                        GLODSOFT.QDJJ.BUSINESS._Methods mets = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.Currentbus, this.DataSource, info2);
                                        mets.RemoveAllChild();
                                        view.Delete();

                                    }
                                    else
                                    {
	                                    if (view.Row["TX"].ToString().Contains("模板"))
	                                    {
	                                    	moduleMemos.Add(view.Row["BEIZHU"].ToString());
	                                    }
	                                    view.Delete();
                                        foreach (DataRow glj in gljRows)
                                        {
                                            glj.Delete();
                                        }
                                        foreach (DataRow sc in scRows)
                                        {
                                            sc.Delete();
                                        }
                                        foreach (DataRow zmqf in zmqfRows)
                                        {
                                            zmqf.Delete();
                                        }
                                        foreach (DataRow cszmqf in cszmqfRows)
                                        {
                                            cszmqf.Delete();
                                        }

                                        //currow.Delete();
                                        //dr.Delete();
                                    }

                                        if (this.ParentForm != null)
                                        {
                                            Type objectType = this.ParentForm.GetType();
                                            if (objectType.Name == "SubSegmentForm")
                                            {
                                                MethodInfo o_Methods = objectType.GetMethod("treeList1_FocusedNodeChanged");
                                                o_Methods.Invoke(this.ParentForm, new object[] { this.treeList1, null });
                                            }
                                        }
                                    }

                                //}
                            }
                            if (fnode != null)
                            {
                                if (fnode.Expanded && fnode.HasChildren) fnode = fnode.LastNode;
                            }
                            if (fnode != null)
                                this.treeList1.FocusedNode = fnode;
                            }

                            foreach (var moduleMemo in moduleMemos)
                            {
                                var moduleRows = DataSource.StructSource.ModelMeasures.Select(string.Format("BEIZHU = '{0}'", moduleMemo));
                                foreach (var moduleRow in moduleRows)
                                {
                                    var entity = _Entity_SubInfo.Parse(moduleRow);
                                    calculator.Entities.Add(entity);
                                    moduleRow.Delete();
                                }
                            }
                        }
                    }
                    break;
                case "插入清单":
                    FoucuseInfo = this.CreateKongQD();
                    break;
                case "插入子目":
                    FoucuseInfo = this.CreateKongZM();
                    break;
                case "重排清单流水号":
                    RestLSH();
                    this.RestXH();
                    this.treeList1.RefreshDataSource();
                    break;

                case "清单排序":
                    Paixu();
                    RestLSH();
                    this.RestXH();
                    //info.Paste();
                    //this.DataBind();
                    break;
                case "复制":
                    SetCopyValue();
                    //info.Copys(this.copylist);
                    //this.DataBind();
                    break;
                case "粘贴":
                    this.Paste();
                    //this.DataBind();
                    break;

                case "展开到专业":
                case "展开到章":
                case "展开到节":
                case "展开到清单":
                case "展开到子目":
                    Expand(e.Item.Caption);
                    break;
                default:
                    break;
            }
            //this.DataSource.Property.SubSegments.ChangeSource();
            //this.DataSource.Property.SubSegments.DataSource.ResetBindings(false);
            if (FoucuseInfo != null) FocusedNode(FoucuseInfo.ID);

        }
        private void Paixu()
        {
            DataRow[] infos = this.DataSource.StructSource.ModelSubSegments.Select("LB='清单'", "OLDXMBM asc", DataViewRowState.CurrentRows);
            int j = 1;
            for (int i = 0; i < infos.Length; i++)
            {
                infos[i]["Sort"] = j;
                j++;
            }
            // this.treeList1.RefreshDataSource();
            // this.m_DataSource.StructSource.ModelSubSegments.DefaultView.Sort = "Sort asc";
            // this.treeList1.DataSource = null;
            // this.treeList1.DataSource = this.m_DataSource.StructSource.ModelSubSegments.DefaultView;

        }
        private void Expand(string Name)
        {

            switch (Name)
            {
                case "展开到专业":
                    this.treeList1.CollapseAll();
                    this.treeList1.Expand(1);
                    break;
                case "展开到章":
                    this.treeList1.CollapseAll();
                    this.treeList1.Expand(2);
                    break;
                case "展开到节":
                    this.treeList1.CollapseAll();
                    this.treeList1.Expand(3);
                    break;
                case "展开到清单":
                    switch (this.m_EListType)
                    {
                        case EListType.Default:
                            this.treeList1.CollapseAll();
                            this.treeList1.Expand(1);
                            break;
                        case EListType.Professional:
                            this.treeList1.CollapseAll();
                            this.treeList1.Expand(2);
                            break;
                        case EListType.Chapter:
                            this.treeList1.CollapseAll();
                            this.treeList1.Expand(3);
                            break;
                        case EListType.Festival:
                            this.treeList1.CollapseAll();
                            this.treeList1.Expand(4);
                            break;
                        default:
                            break;
                    }
                    break;

                case "展开到子目":
                    this.treeList1.ExpandAll();
                    break;
                default:
                    break;
            }

        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DataRow row = gv.GetFocusedDataRow();
            this.treeList1.HideEditor();
            DevExpress.XtraEditors.Popup.PopupContainerForm form = this.gridControl1.Parent.Parent as DevExpress.XtraEditors.Popup.PopupContainerForm;
            if (row == null) return;
            repositoryItemPopupContainerEdit1_QueryResultValue(form.OwnerEdit, new QueryResultValueEventArgs(row["DINGEH"]));
            // this.repositoryItemPopupContainerEdit1.Dispose();
            //DevExpress.XtraTreeList.TreeList gv = sender as DevExpress.XtraTreeList.TreeList;
            //DevExpress.XtraTreeList.TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
        }
        private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            //DevExpress.XtraEditors.PopupContainerEdit edit = sender as DevExpress.XtraEditors.PopupContainerEdit;
            //this.treeList1.FocusedNode.SetValue(this.treeList1.FocusedColumn, edit.EditValue);

            //string OldValue = "";
            //if (edit.OldEditValue!=null)
            //{
            //    OldValue = edit.OldEditValue.ToString();
            //}
            //string NewValue = "";

            //if (e.Value!=null)
            //{
            //    NewValue=e.Value.ToString();
            //}
            //if (OldValue!=NewValue)
            //{

            //    this.AddByTree(ToolKit.ToDBC(e.Value.ToString()));
            //}
            //return;

        }
        private void repositoryItemPopupContainerEdit1_Leave(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.PopupContainerEdit edit = sender as DevExpress.XtraEditors.PopupContainerEdit;
            repositoryItemPopupContainerEdit1_QueryResultValue(edit, new QueryResultValueEventArgs(edit.EditValue));
        }
        //private void repositoryItemButtonEdit1_Leave(object sender, EventArgs e)
        //{
        //    DevExpress.XtraEditors.ButtonEdit edit = sender as DevExpress.XtraEditors.ButtonEdit;
        //    string OldValue = "";
        //    if (edit.OldEditValue != null)
        //    {
        //        OldValue = edit.OldEditValue.ToString();
        //    }
        //    string NewValue = "";
        //    if (edit.EditValue != null)
        //    {
        //        NewValue = edit.EditValue.ToString();
        //    }
        //    if (OldValue != NewValue)
        //    {
        //        this.AddByTree(NewValue);
        //    }
        //}
        private void RItemButtonEdit_Leave(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = sender as DevExpress.XtraEditors.ButtonEdit;
            string Newvalue = "";
            string OldValue = "";
            if (edit.OldEditValue != null)
            {
                OldValue = edit.OldEditValue.ToString();
            }
            if (edit.EditValue != null)
            {
                Newvalue = edit.EditValue.ToString();
            }
            if (Newvalue != OldValue)
            {
                //edit.EditValue= ToolKit.Calculate(Newvalue);
                //  _ObjectInfo info = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as _ObjectInfo;
                //if (info!=null)
                //{
                //    info.GCLJSS = ToolKit.Calculate(Newvalue).ToString();
                //}

                this.bindingSource2.ResetBindings(false);
            }

        }

        /// <summary>
        /// 重排流水号
        /// </summary>
        public void RestLSH()
        {
            IEnumerable<DataRow> infos = this.DataSource.StructSource.ModelSubSegments.Select("LB='清单'", string.Empty, DataViewRowState.CurrentRows).Distinct(new QDDistinct());
            DataRow[] arr = infos.ToArray();
            foreach (DataRow item in arr)
            {
                //IEnumerable<DataRow> info = from n in this.DataSource.StructSource.ModelSubSegments.AsEnumerable()
                //                            where n["OLDXMBM"].Equals(item["OLDXMBM"])
                //                            orderby item["Sort"] ascending
                //                            select n;
                //DataRow[] arr1 = info.ToArray();
                DataRow[] arr1 = this.DataSource.StructSource.ModelSubSegments.Select(string.Format("OLDXMBM='{0}'", item["OLDXMBM"]), " Sort Asc", DataViewRowState.CurrentRows);
                int m = 0;
                for (int i = 0; i < arr1.Length; i++)
                {
                    m = i + 1;
                    arr1[i]["XMBM"] = arr1[i]["OLDXMBM"] + m.ToString().PadLeft(3, '0');
                    //if (m.ToString().Length == 1)
                    //    arr1[i].XMBM = arr1[i].OLDXMBM + "00" + m.ToString();
                    //else if (m.ToString().Length == 2)
                    //    arr1[i].XMBM = arr1[i].OLDXMBM + "0" + m.ToString();
                    //else
                    //    arr1[i].XMBM = arr1[i].OLDXMBM + m.ToString();

                }
            }
        }
        public void RestXH()
        {
            _List list = new _List();
            int m = 1;
            RestXH(list, this.treeList1.Nodes, ref m);//重排序号
            // this.DataSource.StructSource.ModelSubSegments.Select(
        }

        private void RestXH(_List list, TreeListNodes nodes, ref  int m)
        {
            IEnumerable<TreeListNode> ns = nodes.Cast<TreeListNode>();
            TreeListNode[] nss = ns.ToArray();
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in nss)
            {
                DataRowView o = item.TreeList.GetDataRecordByNode(item) as DataRowView;
                if (o["LB"].Equals("清单"))
                {
                    //o.BeginEdit();
                    o["XH"] = m;
                    //o.EndEdit();
                    m++;
                }
                else if (!o["LB"].ToString().Contains("子目"))
                {
                    RestXH(list, item.Nodes, ref m);
                }

            }

        }
        private void repositoryItemCalcEdit1_Leave(object sender, EventArgs e)
        {
            if (this.OnChildRefresh != null)
            {
                this.OnChildRefresh();
            }

        }
        /// <summary>
        /// 处理选中行
        /// </summary>
        /// <param name="id"></param>
        public void FocusedNode(int id)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = this.treeList1.FindNodeByKeyID(id);
            if (node != null) this.treeList1.FocusedNode = node;
        }
        /// <summary>
        /// 分部分项清单插入
        /// </summary>
        /// <param name="infof"></param>
        public void Q_Inset(_Entity_SubInfo infof)
        {

            //DataRowView view = this.Source.Current as DataRowView;
            DataRowView view = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as DataRowView;
            _Method_Sub met = _Method_Sub.GetSub(this.Currentbus, this.DataSource);
            if (view["LB"].Equals("清单"))
            {
                ChangePositionChanged(false);
                met.Create(ToolKit.ParseInt(view["Sort"]), infof);
                ChangePositionChanged(true);
            }
            else if (view["LB"].ToString().Contains("子目"))
            {
                DataRow[] rows = this.DataSource.StructSource.ModelSubSegments.Select(string.Format("ID={0}", view["PID"]));
                if (rows.Length > 0) { ChangePositionChanged(false); met.Create(ToolKit.ParseInt(rows[0]["Sort"]), infof); ChangePositionChanged(true); }
                else { ChangePositionChanged(false); met.Create(-1, infof); ChangePositionChanged(true); }
            }
            else { ChangePositionChanged(false); met.Create(-1, infof); ChangePositionChanged(true); }


        }

        public void Q_Inset(_Entity_SubInfo infof, int sort)
        {


            _Method_Sub met = _Method_Sub.GetSub(this.Currentbus, this.DataSource);

            ChangePositionChanged(false);
            met.Create(sort, infof);
            ChangePositionChanged(true);



        }
        /// <summary>
        /// 分部分项子目插入
        /// </summary>
        /// <param name="sinfo1"></param>
        /// <param name="pinfo"></param>
        public void Z_Inset(_Entity_SubInfo sinfo1)
        {
            // DataRowView view = this.Source.Current as DataRowView;
            DataRowView view = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as DataRowView;
            if (view["LB"].ToString().Contains("子目"))
            {
                _Entity_SubInfo Pinfo = new _Entity_SubInfo();
                DataRow row = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(view["PID"].ToString());
                _ObjectSource.GetObject(Pinfo, row);
                _Methods_Fixed fix = new _Methods_Fixed(this.Currentbus, this.DataSource, Pinfo);
                fix.OnZiMuAdded += new _Methods_Fixed.ZiMuAdd(fix_OnZiMuAdded);

                ChangePositionChanged(false);
                fix.Create(ToolKit.ParseInt(view["Sort"]), sinfo1);
                ChangePositionChanged(true);
                ExpandNode(fix.Current.ID);

            } if (view["LB"].Equals("清单"))
            {
                _Entity_SubInfo Pinfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(Pinfo, view.Row);
                _Methods_Fixed fix = new _Methods_Fixed(this.Currentbus, this.DataSource, Pinfo);
                fix.OnZiMuAdded += new _Methods_Fixed.ZiMuAdd(fix_OnZiMuAdded);
                ChangePositionChanged(false);
                fix.Create(-1, sinfo1);
                ChangePositionChanged(true);
                ExpandNode(fix.Current.ID);
            }


        }
        /// <summary>
        /// 插入子目展开清单
        /// </summary>
        /// <param name="id"></param>
        public void ExpandNode(object id)
        {
            TreeListNode node = this.treeList1.FindNodeByKeyID(id);
            if (node != null)
            {
                if (!node.Expanded) node.Expanded = true;
            }
        }
        public void Z_Inset(string pid, _Entity_SubInfo sinfo1, int index)
        {
            _Entity_SubInfo Pinfo = new _Entity_SubInfo();
            DataRow row = this.DataSource.StructSource.ModelSubSegments.GetRowByOther(pid);
            _ObjectSource.GetObject(Pinfo, row);
            _Methods_Fixed fix = new _Methods_Fixed(this.Currentbus, this.DataSource, Pinfo);
            fix.OnZiMuAdded += new _Methods_Fixed.ZiMuAdd(fix_OnZiMuAdded);
            fix.Create(index, sinfo1);
            ExpandNode(fix.Current.ID);
        }
        private void ChangePositionChanged(bool flag)
        {
            if (flag)
            {
                this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            }
            else
            {
                this.treeList1.FocusedNodeChanged -= new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            }
            if (this.ParentForm != null)
            {
                Type objectType = this.ParentForm.GetType();
                if (objectType.Name == "SubSegmentForm")
                {
                    MethodInfo o_Methods = objectType.GetMethod("ChangePositionChanged");
                    o_Methods.Invoke(this.ParentForm, new object[] { flag });
                }
            }
        }

        void fix_OnZiMuAdded(_Entity_SubInfo info)
        {
            if (this.ParentForm != null)
            {
                Type objectType = this.ParentForm.GetType();
                if (objectType.Name == "SubSegmentForm")
                {
                    MethodInfo o_Methods = objectType.GetMethod("info_OnZiMuAdded");
                    o_Methods.Invoke(this.ParentForm, new object[] { info });
                }
            }
        }



        /// <summary>
        /// 当激发特殊配色时候此事件启用特殊配色的自定义方式(主要除了类别之外的)
        /// </summary>
        /// <param name="p_RowObject"></param>
        /// <param name="p_SchemeColor"></param>
        /// <param name="appearance"></param>
        private void treeList1_SetRowColorChange(object p_RowObject, _SchemeColor p_SchemeColor, AppearanceObject appearance)
        {
            //若出现一下3个字段特殊处理效果
            DataRowView info = (p_RowObject as DataRowView);
            if (info != null)
            {

                    /*this.addInfo("锁定清单", TYPE_SUBSEGMENT, "SDQD");
                    this.addInfo("锁定单价", TYPE_SUBSEGMENT, "SDDJ");
                    this.addInfo("分包", TYPE_SUBSEGMENT, "SFFB");
                    this.addInfo("甲供", TYPE_SUBSEGMENT, "-1");
                    this.addInfo("暂定", TYPE_SUBSEGMENT, "-1");
                    this.addInfo("检查标识", TYPE_SUBSEGMENT, "JCBJ");
                    this.addInfo("复核标识", TYPE_SUBSEGMENT, "FHBJ");*/

                    //复合标记
                    if (bool.Parse(info["FHBJ"].ToString()))
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "复核标识");
                        return;
                    }

                    //复合标记
                    if (bool.Parse(info["JCBJ"].ToString()))
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "检查标识");
                        return;
                    }

                    if (decimal.Parse(info["ZGJE"].ToString()) > 0)
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "暂定");
                        return;
                    }

                    if (decimal.Parse(info["JGJE"].ToString()) > 0)
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "甲供");
                        return;
                    }

                    if (decimal.Parse(info["FBJE"].ToString()) > 0)
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "分包");
                        return;
                    }

                    if (bool.Parse(info["SDDJ"].ToString()))
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "锁定单价");
                        return;
                    }

                    if (bool.Parse(info["SDQD"].ToString()))
                    {
                        SetColumnsColor(p_SchemeColor, appearance, "锁定清单");
                        return;
                    }

                if (info["TX"].Equals("模板"))
                {
                    SetColumnsColor(p_SchemeColor, appearance, "模板");
                    return;
                }
            }
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="p_SchemeColor"></param>
        /// <param name="appearance"></param>
        /// <param name="Name"></param>
        private void SetColumnsColor(_SchemeColor p_SchemeColor, AppearanceObject appearance, string Name)
        {
            _SpecialStyleInfo style = p_SchemeColor.SpecialStyle.Get(Name);
            if (style != null)
            {
                appearance.Font = new Font(appearance.Font.FontFamily, appearance.Font.Size, style.Font);
                //字体颜色
                appearance.ForeColor = style.ForeColor;
                //背景颜色
                appearance.BackColor = style.BColor;
                //扩展色
                //appearance.BackColor2 = style.BColor2;
            }
        }

        public void SetCell(string ColName)
        {
            //设置焦点列
            this.treeList1.FocusedColumn = this.treeList1.Columns[ColName];
        }

        public void RefreshDataSource()
        {
            this.treeList1.RefreshDataSource();
            //this.Source.ResetCurrentItem();
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            this.EnterDown(e);
        }

        private void EnterDown(KeyEventArgs e)
        {
            if (this.treeList1.FocusedColumn == null) return;
            if (this.treeList1.FocusedColumn.FieldName == "XMMC") return;

            if (e.KeyCode == Keys.Enter)
            {
                //this.treeList1.
                this.treeList1.HideEditor();
                int begin = this.treeList1.Columns["XMBM"].VisibleIndex;
                int end = this.treeList1.Columns["GCL"].VisibleIndex;
                if (this.treeList1.FocusedColumn.VisibleIndex >= begin && this.treeList1.FocusedColumn.VisibleIndex < end)
                {
                    //跳转到工程量
                    this.treeList1.FocusedColumn = this.treeList1.Columns["GCL"];
                    this.treeList1.ClickCount = 2;
                    this.treeList1.OptionsBehavior.Editable = true;
                    this.treeList1.ShowEditor();
                }
                else
                {
                    _Entity_SubInfo FoucuseInfo = null;
                    DataRowView v = this.treeList1.Current as DataRowView;
                    if (v != null)
                    {
                        if (v["LB"].ToString().Contains("子目"))
                        {
                            FoucuseInfo = CreateKongZM();
                        }
                        if (v["LB"].Equals("清单"))
                        {
                            FoucuseInfo = CreateKongQD();
                        }
                    }
                    this.treeList1.FocusedColumn = this.treeList1.Columns.ColumnByFieldName("XMBM");

                    if (FoucuseInfo != null) this.FocusedNode(FoucuseInfo.ID);
                    this.treeList1.ClickCount = 2;
                    this.treeList1.OptionsBehavior.Editable = true;
                    this.treeList1.ShowEditor();
                }
            }
        }


        private _Entity_SubInfo CreateKongQD()
        {
            _Entity_SubInfo infof = new _Entity_SubInfo();
            infof.ZJWZ = "999999";
            infof.LB = "清单";
            infof.LibraryName = this.DataSource.Property.Libraries.ListGallery.FullName;
            this.Q_Inset(infof);
            return infof;
        }
        private _Entity_SubInfo CreateKongZM()
        {

            int id = 0;
            DataRowView v = this.treeList1.Current as DataRowView;
            if (v != null)
            {
                if (v["LB"].Equals("清单")) { id = int.Parse(v["ID"].ToString()); }
                if (v["LB"].ToString().Contains("子目")) { id = int.Parse(v["PID"].ToString()); }
            }
            if (id > 0)
            {
                _Entity_SubInfo sinfo1 = new _Entity_SubInfo();
                // sinfo1.IsHs = false;
                sinfo1.LibraryName = this.DataSource.Property.Libraries.FixedLibrary.FullName;
                sinfo1.LB = "子目";
                Z_Inset(sinfo1);
                //pinfo.Create(sinfo1);
                return sinfo1;
            }
            return null;
        }
        private void treeList1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.treeList1.FocusedColumn.FieldName == "XMMC") return;
                this.treeList1.CloseEditor();

                this.EnterDown(e);
            }
        }

        private void treeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            TreeList t = sender as TreeList;
            if (e.Node != null)
            {
                if (e.Column.ColumnType == typeof(decimal) || e.Column.ColumnType == typeof(int))
                {
                    decimal d = ToolKit.ParseDecimal(e.CellValue);
                    //int m = Convert.ToInt32(d);
                    if (d == 0)
                    {
                        e.CellText = "";
                    }
                    //else
                    //{
                    //    e.CellText = e.CellValue.ToString().TrimEnd('0');
                    //}

                }
            }
        }
        /// <summary>
        /// 整理到专业
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DataBind(EListType.Professional);
            //obj.subSegmentListData1.treeList1.Expand(1);
            this.treeList1.Expand(1);
        }
        /// <summary>
        /// 整理到章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DataBind(EListType.Chapter);
            //obj.subSegmentListData1.treeList1.Expand(1);
            this.treeList1.Expand(2);
        }
        /// <summary>
        /// 整理到节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DataBind(EListType.Festival);
            //obj.subSegmentListData1.treeList1.Expand(1);
            this.treeList1.Expand(3);
        }
        /// <summary>
        /// 撤销整理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DataBind(EListType.Default);
            this.treeList1.Expand(1);
        }

    }

    class SortObj : System.Collections.IComparer
    {
        //public int Compare(_Entity_SubInfo x, _Entity_SubInfo y)
        //{
        //    if (x.LB.Equals(y.LB).Equals("清单") || x.LB.Equals(y.LB).Equals("子目"))
        //    {
        //        return 0;
        //    }
        //    else if(x.LB.Equals("清单") && y.LB.Equals("子目")) 
        //    {
        //        return 1;
        //    }
        //    return -1;
        //}

        #region IComparer 成员

        public int Compare(object x, object y)
        {
            _Entity_SubInfo a = x as _Entity_SubInfo;
            _Entity_SubInfo b = y as _Entity_SubInfo;

            if (a.LB.Equals("清单") && b.LB.Equals("清单") || a.LB.Equals("子目") && b.LB.Equals("子目")) 
            {
                return 0;
            }
            else if (a.LB.Equals("清单") && !b.LB.Equals("清单"))
            {
                return -1;
            }

            return 1;

            //if (a.LB.Equals(b.LB).Equals("清单") || a.LB.Equals(b.LB).Equals("子目"))
            //{
            //    return 0;
            //}
            //else if (a.LB.Equals("清单") && b.LB.Equals("子目"))
            //{
            //    return 1;
            //}
            //return -1;
        }

        #endregion
    }
}
