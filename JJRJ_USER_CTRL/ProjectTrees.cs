/*
    项目列表清单
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraBars;
using System.Collections;
using GLODSOFT.QDJJ.BUSINESS;
using System.Linq;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.CTRL
{

    public partial class ProjectTrees : BaseControl
    {

        /// <summary>
        /// 获取当前选中的数据对象
        /// </summary>
        public _COBJECTS SelectNotEntity
        {
            get
            {
                if (this.bindingSource1.Current != null)
                {
                    DataRowView view = this.bindingSource1.Current as DataRowView;
                    int deep = ToolKit.ParseInt(view["DEEP"]);
                    //根据深度创建对象
                    if (deep == 0)
                    {
                        return this.m_CurrBusiness.Current;
                    }
                    if (deep == 1)
                    {
                        _COBJECTS info = this.m_CurrBusiness.Current.Create();
                        _ObjectSource.GetObject(info, view);
                        return info;
                    }
                    if (deep == 2)
                    {
                        _Engineering en = this.m_CurrBusiness.Current.Create() as _Engineering;
                        _ObjectSource.GetObject(en, this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.ParentNode) as DataRowView);
                        _COBJECTS unit = en.Create();
                        _ObjectSource.GetObject(unit, view);
                        unit.Parent = en;
                        return unit;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取当前选中的所有单位工程（获取选中的所有单位工程数组集合）
        /// </summary>
        public ArrayList SelectItems
        {
            get
            {
                if (this.treeList1.Selection.Count > 0)
                {
                    ArrayList list = new ArrayList();

                    foreach (TreeListNode node in this.treeList1.Selection)
                    {
                        //DataRowView row = this.bindingSource1.Current as DataRowView;
                        //_UnitProject info = row["UnitProject"] as _UnitProject;
                        //if (info != null) return info;
                        if (node.Level == 2)
                        {
                            DataRowView view = this.treeList1.GetDataRecordByNode(node) as DataRowView;
                            _UnitProject info = view["UnitProject"] as _UnitProject;
                            if (info != null)
                            {
                                list.Add(info);
                            }
                            else
                            {
                                //还原单位工程对象并且保存
                                _UnitProject unit = new _UnitProject();
                                _ObjectSource.GetObject(unit, view);
                                this.CurrBusiness.Load(unit, true);
                                DataRowView obj = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.ParentNode) as DataRowView;
                                _Engineering en = new _Engineering();
                                en.Parent = this.m_DataSource;
                                _ObjectSource.GetObject(en, obj);
                                unit.Parent = en;
                                list.Add(unit);
                                //this.CurrBusiness.Current.StructSource.ModelProject.AppendUnit(unit);
                            }
                        }
                        //设置Parent属性

                    }
                    return list;
                }
                return null;
            }
        }

        /// <summary>
        /// 获取当前选中的数据对象
        /// </summary>
        public _COBJECTS SelectItem
        {
            get
            {
                if (this.bindingSource1.Current != null)
                {
                    //根据深度创建对象
                    if (this.treeList1.FocusedNode.Level == 0)
                    {
                        return this.m_DataSource;
                    }
                    if (this.treeList1.FocusedNode.Level == 1)
                    {
                        DataRowView row = this.bindingSource1.Current as DataRowView;
                        _COBJECTS einfo = row["UnitProject"] as _COBJECTS;
                        if (einfo == null)
                        {
                            einfo = this.m_DataSource.Create();
                            _ObjectSource.GetObject(einfo, this.bindingSource1.Current as DataRowView);
                            einfo.Parent = this.m_DataSource;
                        }

                        return einfo;
                    }
                    if (this.treeList1.FocusedNode.Level == 2)
                    {
                        DataRowView row = this.bindingSource1.Current as DataRowView;
                        _UnitProject info = row["UnitProject"] as _UnitProject;
                        if (info != null) return info;
                        //还原单位工程对象并且保存
                        _UnitProject unit = new _UnitProject();
                        _ObjectSource.GetObject(unit, row);
                        //(this.CurrBusiness as _Pr_Business).CalculateForXml();
                        this.CurrBusiness.Load(unit);

                        //_Engineering Engineering = new _Projects().Create() as _Engineering;
                        ////Engineering.Sort = ++this.CProjects.EnSort;
                        //Engineering.Name = unit.Name;// item.单项工程名称;
                        //Engineering.NodeName = unit.Name; //item.单项工程名称;
                        //Engineering.Deep = 1;
                        //SetEngineering(Engineering, item);

                        //检查备注，如果为空或不符合规则，则重新生成备注
                        string strTJ = "";
                        DataRow[] rowZM, rowGLJ;
                        StringBuilder sb = new StringBuilder();
                        int qdID = 0;
                        bool returnFlag = false;
                        for (int i = 0; i < unit.StructSource.ModelSubSegments.Rows.Count; i++)
                        {
                            if (unit.StructSource.ModelSubSegments.Rows[i]["LB"].ToString().Equals("清单") &&
                                unit.StructSource.ModelSubSegments.Rows[i]["BEIZHU"].ToString().IndexOf("@") <= 0)
                            {
                                sb.Remove(0, sb.Length);
                                strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                                qdID = int.Parse(unit.StructSource.ModelSubSegments.Rows[i]["ID"].ToString());
                                //该清单的子目
                                rowZM = unit.StructSource.ModelSubSegments.Select("PID = " + qdID);
                                foreach (DataRow zm in rowZM)
                                {
                                    if (!zm["XMBM"].ToString().Contains("换"))
                                        sb.Append(string.Format("{0},{1},{2},{3}|", zm["XMBM"], zm["GCL"], "", ""));
                                    else
                                    {
                                        rowGLJ = unit.StructSource.ModelQuantity.Select("QDID = " + qdID.ToString() + " and ZMID = " + zm["ID"].ToString());

                                        foreach (DataRow glj in rowGLJ)
                                        {
                                            if (zm["XMMC"].ToString().Contains(glj["MC"].ToString()))
                                            {
                                                sb.Append(string.Format("{0},{1},{2},{3}|", zm["XMBM"], zm["GCL"], glj["YSBH"].ToString(), glj["BH"].ToString()));
                                                returnFlag = true;
                                                break;
                                            }
                                        }

                                    }
                                    if (returnFlag)
                                    {
                                        returnFlag = false;
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(sb.ToString()))
                                    unit.StructSource.ModelSubSegments.Rows[i]["BEIZHU"] = sb.ToString() + strTJ + "@" + unit.StructSource.ModelSubSegments.Rows[i]["BEIZHU"].ToString();
                            }
                        }

                        /*
                        DataRow[] zmRows = unit.StructSource.ModelSubSegments.Select("LB = '子目'");
                        DataRow[] cszmRows = unit.StructSource.ModelMeasures.Select("LB = '子目' or LB = '子目-降效'");
                        DataRow[] zmqfRows;
                        string f1 = "0.00", f2 = "0.00", f3 = "0.00", f4 = "0.00", f5 = "0.00", f6 = "0.00", s2 = "0.00", s3 = "0.00",yi = "0.00";
                        foreach (DataRow row1 in cszmRows)
                        {
                            f1 = "0.00"; f2 = "0.00"; f3 = "0.00"; f4 = "0.00"; f5 = "0.00"; f6 = "0.00"; s2 = "0.00"; s3 = "0.00"; yi = "0.00";
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f1'");

                            if (zmqfRows.Length > 0)
                            {
                                f1 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f2'");

                            if (zmqfRows.Length > 0)
                            {
                                f2 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f3'");

                            if (zmqfRows.Length > 0)
                            {
                                f3 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f4'");

                            if (zmqfRows.Length > 0)
                            {
                                f4 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f5'");

                            if (zmqfRows.Length > 0)
                            {
                                f5 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f6'");

                            if (zmqfRows.Length > 0)
                            {
                                f6 = zmqfRows[0]["TBJE"].ToString();
                            }

                            yi = (ToolKit.ParseDecimal(f1) + ToolKit.ParseDecimal(f2) + ToolKit.ParseDecimal(f3) + ToolKit.ParseDecimal(f4) + ToolKit.ParseDecimal(f5) + ToolKit.ParseDecimal(f6)).ToString();

                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '二'");

                            if (zmqfRows.Length > 0)
                            {
                                row1["GLFDJ"] = zmqfRows[0]["TBJE"].ToString();
                                s2 = row1["GLFDJ"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '三'");

                            if (zmqfRows.Length > 0)
                            {
                                row1["LRDJ"] = zmqfRows[0]["TBJE"].ToString();
                                s3 = row1["LRDJ"].ToString();
                            }

                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '四'");

                            if (zmqfRows.Length > 0)
                            {
                                //row1["ZHDJ"] = ToolKit.ParseDecimal(f1) + ToolKit.ParseDecimal(f2)+ ToolKit.ParseDecimal(f3)+ ToolKit.ParseDecimal(f4)+ ToolKit.ParseDecimal(f5)+ ToolKit.ParseDecimal(f6)+ ToolKit.ParseDecimal(s2)+ ToolKit.ParseDecimal(s3);  //zmqfRows[0]["TBJE"].ToString();
                                row1["ZHDJ"] = ToolKit.ParseDecimal(yi) + +ToolKit.ParseDecimal(s2) + ToolKit.ParseDecimal(s3);
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '五'");

                            if (zmqfRows.Length > 0)
                            {
                                row1["ZHHJ"] = zmqfRows[0]["TBJE"].ToString();
                            }
                        
                        }

                        
                        foreach (DataRow row1 in zmRows)
                        {
                            f1 = "0.00"; f2 = "0.00"; f3 = "0.00"; f4 = "0.00"; f5 = "0.00"; f6 = "0.00"; s2 = "0.00"; s3 = "0.00"; yi = "0.00"; 
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f1'");

                            if (zmqfRows.Length > 0)
                            {
                                f1 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f2'");

                            if (zmqfRows.Length > 0)
                            {
                                f2 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f3'");

                            if (zmqfRows.Length > 0)
                            {
                                f3 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f4'");

                            if (zmqfRows.Length > 0)
                            {
                                f4 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f5'");

                            if (zmqfRows.Length > 0)
                            {
                                f5 = zmqfRows[0]["TBJE"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = 'f6'");

                            if (zmqfRows.Length > 0)
                            {
                                f6 = zmqfRows[0]["TBJE"].ToString();
                            }

                            yi = (ToolKit.ParseDecimal(f1) + ToolKit.ParseDecimal(f2)+ ToolKit.ParseDecimal(f3)+ ToolKit.ParseDecimal(f4)+ ToolKit.ParseDecimal(f5)+ ToolKit.ParseDecimal(f6)).ToString();

                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '二'");

                            if (zmqfRows.Length > 0)
                            {
                                row1["GLFDJ"] = zmqfRows[0]["TBJE"].ToString();
                                s2 = row1["GLFDJ"].ToString();
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '三'");

                            if (zmqfRows.Length > 0)
                            {
                                row1["LRDJ"] = zmqfRows[0]["TBJE"].ToString();
                                s3 = row1["LRDJ"].ToString();
                            }
                            
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '四'");

                            if (zmqfRows.Length > 0)
                            {
                                //row1["ZHDJ"] = ToolKit.ParseDecimal(f1) + ToolKit.ParseDecimal(f2)+ ToolKit.ParseDecimal(f3)+ ToolKit.ParseDecimal(f4)+ ToolKit.ParseDecimal(f5)+ ToolKit.ParseDecimal(f6)+ ToolKit.ParseDecimal(s2)+ ToolKit.ParseDecimal(s3);  //zmqfRows[0]["TBJE"].ToString();
                                row1["ZHDJ"] = ToolKit.ParseDecimal(yi) + + ToolKit.ParseDecimal(s2)+ ToolKit.ParseDecimal(s3);
                            }
                            zmqfRows = unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row1["ID"].ToString() + " and YYH = '五'");

                            if (zmqfRows.Length > 0)
                            {
                                row1["ZHHJ"] = zmqfRows[0]["TBJE"].ToString();
                            }

                        }

                        DataRow[] qdRows = unit.StructSource.ModelSubSegments.Select("LB = '清单'");
                        decimal qdglf = 0m, qdlr = 0m,zmglf = 0, zmlr = 0;
                        foreach (DataRow qdRow in qdRows)
                        {
                            qdglf = 0m; qdlr = 0m; 
                            zmRows = unit.StructSource.ModelSubSegments.Select("LB = '子目' and PID = " + qdRow["ID"].ToString());
                            foreach (DataRow zmRow in zmRows)
                            {
                                zmglf = 0; zmlr = 0;

                                zmglf = ToolKit.ParseDecimal(zmRow["GLFDJ"].ToString()) * ToolKit.ParseDecimal(zmRow["GCL"].ToString());
                                zmlr = ToolKit.ParseDecimal(zmRow["LRDJ"].ToString()) * ToolKit.ParseDecimal(zmRow["GCL"].ToString());
                                zmRow["GLFHJ"] = zmglf;
                                zmRow["LRHJ"] = zmlr;
                                qdglf += zmglf;
                                qdlr += zmlr;
                            }

                            qdRow["GLFHJ"] = qdglf;
                            qdRow["LRHJ"] = qdlr;
                            qdRow["GLFDJ"] = qdglf / ToolKit.ParseDecimal(qdRow["GCL"].ToString());
                            qdRow["LRDJ"] = qdlr / ToolKit.ParseDecimal(qdRow["GCL"].ToString());
                            qdRow["ZHDJ"] = ToolKit.ParseDecimal(qdRow["RGFDJ"].ToString()) + ToolKit.ParseDecimal(qdRow["CLFDJ"].ToString()) + ToolKit.ParseDecimal(qdRow["JXFDJ"].ToString()) + ToolKit.ParseDecimal(qdRow["ZCFDJ"].ToString()) + ToolKit.ParseDecimal(qdRow["SBFDJ"].ToString()) + ToolKit.ParseDecimal(qdglf) + ToolKit.ParseDecimal(qdlr);
                            qdRow["ZHHJ"] = ToolKit.ParseDecimal(qdRow["ZHDJ"].ToString()) * ToolKit.ParseDecimal(qdRow["GCL"].ToString());


                        }

                        //措施项目的管理费和利润
                        decimal qdglf = 0m, qdlr = 0m,zmglf = 0, zmlr = 0;
                        DataRow[] qdRows = unit.StructSource.ModelMeasures.Select("LB = '清单'");
                        qdglf = 0m; qdlr = 0m; zmglf = 0; zmlr = 0;
                        foreach (DataRow qdRow in qdRows)
                        {
                            qdglf = 0m; qdlr = 0m;
                            zmRows = unit.StructSource.ModelMeasures.Select("(LB = '子目' or LB = '子目-降效' or LB = '子措施项') and PID = " + qdRow["ID"].ToString());
                            foreach (DataRow zmRow in zmRows)
                            {
                                zmglf = 0; zmlr = 0;

                                zmglf = ToolKit.ParseDecimal(zmRow["GLFDJ"].ToString()) * ToolKit.ParseDecimal(zmRow["GCL"].ToString());
                                zmlr = ToolKit.ParseDecimal(zmRow["LRDJ"].ToString()) * ToolKit.ParseDecimal(zmRow["GCL"].ToString());
                                zmRow["GLFHJ"] = zmglf;
                                zmRow["LRHJ"] = zmlr;
                                qdglf += zmglf;
                                qdlr += zmlr;
                            }

                            qdRow["GLFHJ"] = qdglf;
                            qdRow["LRHJ"] = qdlr;
                            qdRow["GLFDJ"] = qdglf / ToolKit.ParseDecimal(qdRow["GCL"].ToString());
                            qdRow["LRDJ"] = qdlr / ToolKit.ParseDecimal(qdRow["GCL"].ToString());
                            qdRow["ZHDJ"] = ToolKit.ParseDecimal(qdRow["ZHDJ"].ToString()) + ToolKit.ParseDecimal(qdglf) + ToolKit.ParseDecimal(qdlr);
                            qdRow["ZHHJ"] = ToolKit.ParseDecimal(qdRow["ZHDJ"].ToString()) * ToolKit.ParseDecimal(qdRow["GCL"].ToString());
                        }*/


                        DataTable measures = unit.StructSource.ModelMeasures.Copy();
                        DataRow[] sortRow = measures.Select("", "XMBM asc, XH asc");
                        unit.StructSource.ModelMeasures.Clear();

                        foreach (DataRow row1 in sortRow)
                        {
                            unit.StructSource.ModelMeasures.ImportRow(row1);
                        }

                        DataTable subheading = unit.StructSource.ModelSubheadingsFee.Copy();
                        sortRow = subheading.Select("", "ZMID asc, Sort asc");
                        unit.StructSource.ModelSubheadingsFee.Clear();

                        foreach (DataRow row1 in sortRow)
                        {
                            unit.StructSource.ModelSubheadingsFee.ImportRow(row1);
                        }


                        DataRowView obj = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.ParentNode) as DataRowView;
                        _Engineering en = new _Engineering();
                        en.Parent = this.m_DataSource;
                        _ObjectSource.GetObject(en, obj);
                        unit.Parent = en;
                        this.CurrBusiness.Current.StructSource.ModelProject.AppendUnit(unit);
                        //设置Parent属性

                        return unit;

                        /*_COBJECTS en = this.m_DataSource.Create();
                        //_ObjectSource.GetObject(en, this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.ParentNode) as DataRowView);
                        //_COBJECTS unit = (this.CurrBusiness as _Pr_Business).GetObject(row["OBJECT"]);
                        //创建新的单位工程对象
                        
                        this.CurrBusiness.Current.StructSource.ModelProject.AppendUnit(unit);
                        unit.Parent = en;
                        return unit;*/
                    }
                }
                return null;
            }
        }
        public _Projects CurrSelectUnitProject { get; set; }
        public _COBJECTS SelectParent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public enum EBindType
        {
            全部 = -1,
            项目和单项工程 = 0,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EStyleType
        {
            Default = 0,
            Style1 = 1
        }

        /// <summary>
        /// 是否开启右键菜单
        /// </summary>
        private bool use_right = false;

        /// <summary>
        /// 获取或设置当前业务对象
        /// </summary>
        private _Business m_CurrBusiness = null;

        /// <summary>
        /// 获取或设置当前业务对象
        /// </summary>
        public _Business CurrBusiness
        {
            get
            {
                return this.m_CurrBusiness;
            }
            set
            {
                this.m_CurrBusiness = value;

            }
        }

        /// <summary>
        /// 获取或设置当前控件的数据源
        /// </summary>
        private _COBJECTS m_DataSource = null;

        /// <summary>
        /// 获取或设置当前对象的数据源
        /// </summary>
        public _COBJECTS DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
            }
        }
        /// <summary>
        /// 使用工具栏样式
        /// </summary>
        /// <param name="p_StyleType"></param>
        public void UseBar(EStyleType p_StyleType)
        {
            switch (p_StyleType)
            {
                case EStyleType.Style1:
                    this.bar1.Visible = true;
                    this.use_right = true;
                    break;
                default://禁用按钮与右见菜单
                    this.bar1.Visible = false;
                    this.use_right = false;
                    break;
            }
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        public void InitEvent()
        {
            //TreeList
            this.treeList1.CustomNodeCellEditForEditing += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.treeList1_CustomNodeCellEditForEditing);
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.treeList1_GetNodeDisplayValue);
            this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            this.treeList1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.treeList1_ValidatingEditor);
        }


        /// <summary>
        /// 返回当前数据源类型
        /// </summary>
        public string DataType
        {
            get
            {
                string str = this.m_DataSource.GetType().Name;
                return str;
            }
        }

        /// <summary>
        /// 是否使用右键事件
        /// </summary>
        private Boolean m_isRight = true;

        /// <summary>
        /// 是否使用右键事件
        /// </summary>
        public Boolean isRight
        {
            get
            {
                return this.m_isRight;
            }
            set
            {
                this.m_isRight = value;
            }
        }

        /// <summary>
        /// 获取或设置当前解决方案名称
        /// </summary>
        private string m_projectName = "项目解决方案";

        /// <summary>
        /// 获取或设置当前解决方案名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                return this.m_projectName;
            }
            set
            {
                this.m_projectName = value;
            }
        }

        public ProjectTrees()
        {
            InitializeComponent();
        }

        //加载控件时候激发
        private void ProjectTrees_Load(object sender, EventArgs e)
        {
            this.treeList1.ExpandAll();

        }


        private void ProjectTrees_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!this.use_right) return;

                TreeListHitInfo hi = this.treeList1.CalcHitInfo(new Point(e.X, e.Y));
                if (hi.Node == null) return;
                if (hi.Node != null) this.treeList1.FocusedNode = hi.Node;
                if (m_isRight == true)
                {


                    int level = hi.Node.Level;

                    if (level == 0 && !this.CurrBusiness.Current.IsDZBS)
                    {
                        this.pop_Pr.ShowPopup(this.treeList1.PointToScreen(new Point(e.X, e.Y)));
                        return;
                    }

                    if (level == 1 && !this.CurrBusiness.Current.IsDZBS)
                    {
                        this.pop_En.ShowPopup(this.treeList1.PointToScreen(new Point(e.X, e.Y)));
                        return;
                    }
                    //根据选择项不同弹出不同的菜单
                    if (level == 2)
                    {
                        this.Event_New_UnitProject.Enabled = !this.CurrBusiness.Current.IsDZBS;         // 新建单位工程
                        this.Event_Batch_ADD.Enabled = !this.CurrBusiness.Current.IsDZBS;               // 批量添加工程
                        this.Event_Import_OUT.Enabled = true;	                                        // 导出工程
                        this.Event_RImport_IN.Enabled = true;	                                        // 导入替换工程
                        this.Event_ReName.Enabled = !this.CurrBusiness.Current.IsDZBS;	                // 重命名
                        this.Event_Remove.Enabled = !this.CurrBusiness.Current.IsDZBS;	                // 删除项
                        this.BTN_PRO_PWD.Enabled = !this.CurrBusiness.Current.IsDZBS;                   // 设置项目密码
                        this.BTN_UN_PWD.Enabled = !this.CurrBusiness.Current.IsDZBS;                    // 设置工程密码
                        this.Pop_Un.ShowPopup(this.treeList1.PointToScreen(new Point(e.X, e.Y)));
                    }
                }
            }
        }






        /// <summary>
        /// 删除选定的项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_Remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            //删除当前选中的对象

        }

        /// <summary>
        ///  重命名操作 重新命名当前节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_ReName_ItemClick(object sender, ItemClickEventArgs e)
        {
            //可编辑
            this.treeListColumn1.OptionsColumn.AllowEdit = true;
            //设置为焦点
            this.treeList1.SetFocusedNode(this.treeList1.Selection[0]);
            this.treeList1.ShowEditor();

        }


        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            /*if (e.Node == null) return;
            _COBJECT obj = this.GetObjectByNode(e.Node);
            if (obj != null) SetLockItem(obj.IsLock);*/
        }

        /// <summary>
        /// 显示值得时候调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {
            //如何显示节点名称
            /*if (e.Node.Level == 2)
            {
                // 001-项目名称
                if (e.Node["Sort"] != null)
                {
                    string sort = e.Node["Sort"].ToString().PadLeft(3, '0');
                    string name = e.Node["NodeName"].ToString();
                    e.Value = string.Format("{0}-{1}", sort, name);
                }
            }*/
        }

        private void treeList1_CustomNodeCellEditForEditing(object sender, GetCustomNodeCellEditEventArgs e)
        {
            //开启编辑 
            e.RepositoryItem = this.repositoryItemTextEdit1;

        }

        void RepositoryItem_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            //e.DisplayText = this.SelectItem.Property.Name;
        }

        private void repositoryItemTextEdit1_Enter(object sender, EventArgs e)
        {
            /*TextEdit edit = sender as TextEdit;
            edit.Text = this.SelectItem.Property.Name;*/
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            _COBJECTS info = this.SelectItem;
            if (info != null)
            {
                info.Name = e.Value.ToString();
                info.NodeName = e.Value.ToString();
                //info.StructSource.ModelProject.UpDate(info);
                this.CurrBusiness.Current.StructSource.ModelProject.UpDate(info);
            }
        }

        private void treeList1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value.ToString() == string.Empty)
            {
                e.Valid = false;
                e.ErrorText = "输入名称不能为空!";
            }

            //不在验证名称重复
            /*if (e.Value.ToString() != this.SelectItem.Property.Name)
            {
                if (this.DataSource.Property.IsExist(e.Value.ToString(), this.SelectItem.ObjectType))
                {
                    e.Valid = false;
                    e.ErrorText = "输入名称已经存在!";
                }
            }*/
        }


        /// <summary>
        /// 绑定当前项目树
        /// </summary>
        public void DataBind(_Business business)
        {
            //current.Clone(
            //_List list = new _List();
            //this.DataSource.Property.Fill(list);
            //this.bindingSource1.DataSource = list.Cast<_Directory>().OrderBy(info=>info.Sort);
            //this.treeList1.DataSource = this.bindingSource1;

            this.m_CurrBusiness = business;
            this.m_DataSource = business.Current;

            if (business.Current.IsDZBS && !APP.Jzbx_pwd)
            {
                this.Event_Import.Enabled = false;
                this.Event_New.Enabled = false;
                this.Event_Up.Enabled = false;
                this.Event_Down.Enabled = false;
                this.Event_Lock.Enabled = false;
            }
            this.bindingSource1.DataSource = this.m_DataSource.StructSource.ModelProject;
            this.bindingSource1.Sort = "Sort,Deep";
            this.treeList1.DataSource = this.bindingSource1;
        }

        /// <summary>
        /// 绑定当前项目树
        /// </summary>
        public void DataBind()
        {
            /*_List list = new _List();
            this.DataSource.Property.Fill(list);
            this.bindingSource1.DataSource = list.Cast<_Directory>().OrderBy(info=>info.Sort);
            this.treeList1.DataSource = this.bindingSource1;*/
            if (this.CurrBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
            {
                this.Event_Import.Enabled = false;
                this.Event_New.Enabled = false;
                this.Event_Up.Enabled = false;
                this.Event_Down.Enabled = false;
                this.Event_Lock.Enabled = false;
            }
            this.bindingSource1.DataSource = this.m_DataSource.StructSource.ModelProject;
            this.bindingSource1.Sort = "Sort,Deep";
            this.treeList1.DataSource = this.bindingSource1;
        }

        /// <summary>
        /// 外来数据绑定
        /// </summary>
        /// <param name="p_list"></param>
        public void DataBind(DataTable p_list)
        {
            this.bindingSource1.DataSource = p_list;
            this.treeList1.DataSource = this.bindingSource1;
            this.bindingSource1.AllowNew = true;
        }


        /// <summary>
        /// 上移动当前项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_Up_ItemClick(object sender, ItemClickEventArgs e)
        {

            //只能同级移动(交换两个排序规则)
            TreeListNode curr = this.treeList1.Selection[0];
            if (curr == null) return;
            TreeListNode pre = this.getNextNode(curr, false);
            if (pre == null) return;
            if (curr.Level != pre.Level) return;

            DataRowView obj = this.treeList1.GetDataRecordByNode(curr) as DataRowView;
            if (obj == null) return;
            DataRowView objMove = this.treeList1.GetDataRecordByNode(pre) as DataRowView;
            bool b = pre.Expanded;
            bool b1 = curr.Expanded;
            this.ObjectMove(obj, objMove);
            pre.Selected = true;
            this.treeList1.FocusedNode = pre;
            this.treeList1.FocusedNode.Expanded = b1;
            this.treeList1.FindNodeByKeyID(objMove["ID"]).Expanded = b;
            this.bindingSource1.Sort = "Sort,Deep";
            this.bindingSource1.ResetBindings(false);

        }

        private TreeListNode getNextNode(TreeListNode p_Node, bool flag)
        {
            if (p_Node.ParentNode == null) return null;
            int idx = p_Node.ParentNode.Nodes.IndexOf(p_Node);
            if (flag)
            {
                idx++;
            }
            else
            {
                idx--;
            }
            if (idx >= p_Node.ParentNode.Nodes.Count || idx < 0) return null;
            TreeListNode node = p_Node.ParentNode.Nodes[idx];
            return node;
        }

        /// <summary>
        /// 下移动当前项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_Down_ItemClick(object sender, ItemClickEventArgs e)
        {
            //只能同级移动(交换两个排序规则)
            TreeListNode curr = this.treeList1.Selection[0];
            if (curr == null) return;
            TreeListNode next = this.getNextNode(curr, true);
            if (next == null) return;
            if (curr.Level != next.Level) return;
            DataRowView obj = this.treeList1.GetDataRecordByNode(curr) as DataRowView;
            if (obj == null) return;
            DataRowView objMove = this.treeList1.GetDataRecordByNode(next) as DataRowView;
            bool b = next.Expanded;
            bool b1 = curr.Expanded;
            this.ObjectMove(obj, objMove);
            next.Selected = true;
            this.treeList1.FocusedNode = next;
            this.treeList1.FocusedNode.Expanded = b1;
            this.treeList1.FindNodeByKeyID(objMove["ID"]).Expanded = b;
            this.bindingSource1.Sort = "Sort,Deep";
            this.bindingSource1.ResetBindings(false);
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Up)
                {
                    Event_Up.PerformClick();
                    e.Handled = true;

                }
                if (e.KeyCode == Keys.Down)
                {
                    Event_Down.PerformClick();
                    //只能同级移动(交换两个排序规则)
                    /*this.treeList1.FocusedNode = this.treeList1.FindNodeByKeyID(obj["ID"]);
                    this.treeList1.FocusedNode.Expanded = b1;
                    this.treeList1.FindNodeByKeyID(objMove["ID"]).Expanded = b;*/
                    e.Handled = true;
                }
            }
        }


        /// <summary>
        /// 将p_obj对象与p_objMove对象交换位置
        /// </summary>
        /// <param name="p_obj">源对象</param>
        /// <param name="p_objMove">交换位置对象</param>
        private void ObjectMove(DataRowView p_obj, DataRowView p_objMove)
        {

            if (!p_obj["DEEP"].Equals(p_objMove["DEEP"])) return;
            long sort = CDataConvert.ConToValue<long>(p_obj["Sort"]);

            p_obj.Row.BeginEdit();
            p_obj["Sort"] = p_objMove["Sort"];
            p_obj.Row.EndEdit();
            p_objMove.Row.BeginEdit();
            p_objMove["Sort"] = sort;
            p_objMove.Row.EndEdit();
            if (p_obj["DEEP"].Equals(2))
            {
                _UnitProject m_UnitProject_Y = p_obj["UnitProject"] as _UnitProject;
                if (m_UnitProject_Y != null)
                {
                    m_UnitProject_Y.Sort = ToolKit.ParseInt(p_obj["Sort"]);
                }
                _UnitProject m_UnitProject_M = p_objMove["UnitProject"] as _UnitProject;
                if (m_UnitProject_M != null)
                {
                    m_UnitProject_M.Sort = ToolKit.ParseInt(p_objMove["Sort"]);
                }
            }
            //this.m_DataSource.StructSource.ModelProject.UpDate(p_obj);
            //this.m_DataSource.StructSource.ModelProject.UpDate(p_objMove);
            this.treeList1.Refresh();
        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            //this.bindingSource1.Sort = "Sort asc";
        }

        private void Event_Lock_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*TreeListNode curr = this.treeList1.Selection[0];
            if (curr == null) return;
            _COBJECT obj = this.GetObjectByNode(curr);
            if (obj != null)
            {
                if (obj.IsLock)
                {
                    obj.IsLock = false;
                   
                }
                else
                {
                    obj.IsLock = true;
                }
                SetLockItem(obj.IsLock);
                this.ParentForm.ParentForm.Refresh();
            }*/
        }
        /// <summary>
        /// 设置按钮的文字
        /// </summary>
        /// <param name="flag"></param>
        private void SetLockItem(bool flag)
        {
            if (!flag) this.Event_Lock.Caption = "解锁";
            else this.Event_Lock.Caption = "锁";
        }

        /// <summary>
        /// 设置项目密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_PRO_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        /// <summary>
        /// 设置工程密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_UN_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        public void Lock(bool p_CanUse)
        {

            //锁定项目的时候调用的功能锁定
            this.Event_Batch_ADD.Enabled = p_CanUse;
            this.Event_Down.Enabled = p_CanUse;
            this.Event_New.Enabled = p_CanUse;
            this.Event_Remove.Enabled = p_CanUse;
            this.Event_Up.Enabled = p_CanUse;
            this.Event_New_Engineering.Enabled = p_CanUse;
            this.Event_New_UnitProject.Enabled = p_CanUse;
            this.BTN_PRO_PWD.Enabled = p_CanUse;
            this.BTN_UN_PWD.Enabled = p_CanUse;
            this.Event_ReName.Enabled = p_CanUse;
            this.Event_Import_IN.Enabled = p_CanUse;

        }


    }
}
