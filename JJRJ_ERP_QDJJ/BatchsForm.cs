using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraEditors.Repository;
using System.Linq;
using DevExpress.XtraTreeList;
using ZiboSoft.Commons.Common;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BatchsForm : BaseForm
    {



        //private _Sign OldSign = null;

        /// <summary>
        /// 初始化的时候此对象复制
        /// </summary>
        DataTable CurrentSource = null;

        Hashtable DelTable = new Hashtable();

        /// <summary>
        /// 此对象仅根据选择树节点的时候调用 若节点选择是项目则返回空
        /// </summary>
        private _Engineering CurrEn = null;

        /// <summary>
        /// 业务对象原始数据集
        /// </summary>
        //private _List m_list = null;

        /// <summary>
        /// 获取当前窗体返回的数据
        /// </summary>
        public _Directory[] DataSource
        {
            get
            {
                return this.projectTrees1.bindingSource1.Cast<_Directory>().ToArray();
            }           
        }

        public BatchsForm()
        {
            InitializeComponent();
        }

        int EnSort, UnSoft,ObjectKey;
        private void BatchsForm_Load(object sender, EventArgs e)
        {
            //窗体加载的时候调用

           EnSort = (this.CurrentBusiness.Current as _Projects).EnSort;
           UnSoft = (this.CurrentBusiness.Current as _Projects).UnSort;
           ObjectKey = this.CurrentBusiness.Current.ObjectKey;
           doLoadData();
        }

        /// <summary>
        /// 加载需要的数据对象
        /// </summary>
        private void doLoadData()
        {
            //记录当前的标识号码(当撤销的时候需要还原标识)
            
            //初始化事件
            doInitEvent();
            //加载模板
            loadTempLate();
            //初始化树数据
            initData();
           
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        private void doInitEvent()
        {

            //树结构切换的时候要知道添加到哪个单位工程下
            this.projectTrees1.bindingSource1.PositionChanged += new EventHandler(bindingSource1_PositionChanged);

            //双击移除
            //this.projectTrees1.treeList1.MouseDoubleClick += new MouseEventHandler(projectTrees1_MouseDoubleClick);

            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.projectTrees1.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treeList1_CellValueChanged);
            this.projectTrees1.treeList1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(treeList1_ValidatingEditor);
            this.projectTrees1.treeList1.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(treeList1_FilterNode);
         }

        /// <summary>
        /// 当前树饿筛选过滤条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList1_FilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            int i = 0; i++;
            TreeList list = (sender as TreeList);
            _Directory  info =list.GetDataRecordByNode(e.Node) as _Directory;
            if (info != null)
            {
                if (info.Parent.ObjectState == EObjectState.Delete)
                {
                    e.Node.Visible = false;
                }
                e.Handled = true;
            }
        }


        /// <summary>
        /// 当树结构变更选项的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            //获取选择项
            _COBJECTS info = this.projectTrees1.SelectNotEntity;
            if (info != null)
            {
                this.InitEn(info);
                //配置是否可编辑(不是项目都允许编辑)
                this.projectTrees1.treeList1.Columns[0].OptionsColumn.AllowEdit = info.ObjectType == EObjectType.PROJECT?false:true;
            }
        }

        /// <summary>
        /// 获取并绑定指定的项目对象
        /// </summary>
        private void InitEn(_COBJECTS p_Info)
        {
            //1.弱类型是单项工程
            //2.若为单位工程
            switch (p_Info.ObjectType)
            {
                case EObjectType.Engineering:
                    this.CurrEn = p_Info as _Engineering;
                    break;
                case EObjectType.UnitProject:
                    this.CurrEn = p_Info.Parent as _Engineering;
                    break;
                default:
                    this.lbl_EnName.Text = "请选择单项工程";
                    this.CurrEn = null;
                    return;
            }
            //绑定并且设置当前单项工程对象
            this.lbl_EnName.Text = this.CurrEn.Name;
        }

        /// <summary>
        /// 获取当先选择行对象
        /// </summary>
        /// <returns></returns>
        public DataRowView[] Selections
        {
            get
            {
                //获取选中的个数
                int[] count = this.gridView1.GetSelectedRows();
                DataRowView[] rows = new DataRowView[count.Length];
                for (int i = 0; i < count.Length; i++)
                {
                    rows[i] = this.gridView1.GetRow(count[i]) as DataRowView;
                }
                return rows;
            }
        }

        /// <summary>
        /// 为指定的单位工程配置有关信息
        /// </summary>
        /// <param name="up"></param>
        void SetUnitProject(_UnitProject p_info,DataRowView row)
        {

            /*
                ProType  措施项目
                PGCDD 其他项目
                PJFCX 汇总分析
             */

            //此方法需要初始化所有单项工程信息
            //名称处理
            _Engineering info = this.CurrEn;
            //规则与库处理
            p_info.QDLibName = row["ListBased"].ToString().Trim();
            p_info.DELibName = row["FixedBased"].ToString().Trim();
            //p_info.QDGZ = this.CurrEn.QDGZ;
            //p_info.DEGZ = this.CurrEn.DEGZ;
            //图库
            p_info.TJLibName = row["AtlasBased"].ToString().Trim();
            //专业类别
            p_info.PrfType = row["PrjType"].ToString().Trim();
            //关于默认模板
            p_info.ProType = row["ProType"].ToString().Trim();
            //p_info.PGCDD = this.CurrEn.PGCDD;
            //p_info.PJFCX = this.CurrEn.PJFCX;
            
            //继承的单项工程属性
            //p_info.Property.Basis = info.Property.Basis.Copy() as _CBasis;
            //重新获取名称
            p_info.Name = row["Name"].ToString();
            p_info.NodeName = p_info.Name;
            p_info.Sort = ++this.UnSoft;
            p_info.CODE = info.CODE + p_info.Sort.ToString().PadLeft(3, '0');
            p_info.TemplateType = "0";//
            p_info.Key = ++this.ObjectKey;
            p_info.PKey = info.Key;
            //APP.Methods.Init(p_info);
        }
           
        /// <summary>
        /// 初始化树原始结构数据
        /// </summary>
        private void initData()
        {
            //this.m_list = new _List();
            //this.CurrentBusiness.Current.Property.Fill(this.m_list);
            this.projectTrees1.CurrBusiness = this.CurrentBusiness;
            CurrentSource = this.CurrentBusiness.Current.StructSource.ModelProject.Copy();
            CurrentSource.AcceptChanges();
            this.projectTrees1.DataBind(CurrentSource);

            this.projectTrees1.treeList1.ExpandAll();
            
           
        }


        /// <summary>
        /// 加载模板数据
        /// </summary>
        private void loadTempLate()
        {
            this.bindingSource1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["UnitProject"];
            this.gridControl1.DataSource = this.bindingSource1;
        }


        /// <summary>
        /// 添加一个新的单项工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
             //添加单项工程到列表
             if(this.txt_Name.Text == string.Empty) return;
             //项目名称
             string sNewName = this.txt_Name.Text;
             //验证此名称是否存在(在项目中 此单项工程是否存在)
             if(!this.isExist(sNewName,EObjectType.Engineering))
             {
                 //创建单项工程
                 _Engineering en = this.CurrentBusiness.Current.Create() as _Engineering;
                 en.Name = en.NodeName = sNewName;
                 //加入单项工程
                 //this.projectTrees1.bindingSource1.Add(en.Directory);
                 
                 //this.projectTrees1.DataBind(CurrentSource);
                 
                 en.Sort = ++this.EnSort;
                 en.Key = ++this.ObjectKey;
                 en.PKey = this.CurrentBusiness.Current.Key;
                 en.CODE = this.CurrentBusiness.Current.CODE + en.Sort.ToString().PadLeft(2, '0');
                 _ObjectSource.Add(en, this.CurrentSource);
                 this.AppendUnit(en);
                 
                 this.projectTrees1.bindingSource1.ResetBindings(true);
                 //可编辑
                 this.projectTrees1.repositoryItemTextEdit1 = new RepositoryItemTextEdit();
                 this.projectTrees1.repositoryItemTextEdit1.NullText = "请输入名称";
                 this.txt_Name.ResetText();
                 this.ExaCurr();
             }
             else
             {
                 MessageBox.Show(string.Format("您要添加的单项工程[{0}]已经存在，请修改名称后尝试！", sNewName), "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                 this.txt_Name.Focus();
                 this.txt_Name.SelectAll();
             }
        }

        /// <summary>
        /// 指定对象
        /// </summary>
        /// <param name="p_Name">1单项工程 2单位工程</param>
        /// <returns></returns>
        private bool isExist(string p_Name,EObjectType p_Type)
        {
            //1.判断对象在当前的DataSource中是否存在
            //int type = p_Type == EObjectType.UnitProject ? 2 : p_Type == EObjectType.Engineering ? 1 : 0;

           // return this.projectTrees1.bindingSource1.Cast<_Directory>().Count(info => info.NodeName == p_Name && info.Deep == type) > 0 ? true : false;       
            return false;
        }

        /// <summary>
        /// 添加选中的项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (this.CurrEn != null)
            {
                
                //将当前双击的模板添加到当前项目中(仅生成单位工程对象集合和临时清单            
                //文件名称 项目名称 + 
                foreach(DataRowView row in this.Selections)
                {
                    //获取当前选中对象集合
                    _UnitProject info = this.CurrEn.Create();
                    this.SetUnitProject(info, row);
                    //this.projectTrees1.bindingSource1.Add(info.Directory);
                    _ObjectSource.Add(info, this.CurrentSource);
                    this.AppendUnit(info);
                }
                this.ExaCurr();
            }
        }

        private void btn_selectAll_Click(object sender, EventArgs e)
        {
            if (this.CurrEn != null)
            {
                
                //将当前双击的模板添加到当前项目中(仅生成单位工程对象集合和临时清单            
                //文件名称 项目名称 + 
                foreach (DataRowView row in this.bindingSource1)
                {
                    //获取当前选中对象集合
                    _UnitProject info = this.CurrEn.Create();
                    this.SetUnitProject(info, row);
                    //this.projectTrees1.bindingSource1.Add(info.Directory);
                    _ObjectSource.Add(info, this.CurrentSource);
                    this.AppendUnit(info);
                }
                this.ExaCurr();
            }
        }

        /// <summary>
        /// 列表双击的时候添加单位工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //将当前双击的模板添加到当前项目中(仅生成单位工程对象集合和临时清单            
            //文件名称 项目名称 + 
            if (this.bindingSource1.Current != null)
            {
                if (this.CurrEn != null)
                {
                    //获取当前选中对象集合
                    _UnitProject info = this.CurrEn.Create();
                    this.SetUnitProject(info, this.bindingSource1.Current as DataRowView);
                    //this.projectTrees1.bindingSource1.Add(info.Directory);
                    _ObjectSource.Add(info, this.CurrentSource);
                    this.AppendUnit(info);
                    this.ExaCurr();
                }
            }
        }

        /// <summary>
        /// 展开单项工程节点
        /// </summary>
        private void ExaCurr()
        {
            //如果是1 则展开 
            if (this.projectTrees1.treeList1.FocusedNode.Level < 2)
            {
                this.projectTrees1.treeList1.FocusedNode.ExpandAll();
            }
        }

        /// <summary>
        /// 给当前数据行追加单位工程对象
        /// </summary>
        /// <param name="p_Info"></param>
        public virtual void AppendUnit(_COBJECTS p_Info)
        {
            DataRow row = this.CurrentSource.Rows.Find(p_Info.ID);
            row["UnitProject"] = p_Info;
        }

        /// <summary>
        /// 效验事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value.ToString() == string.Empty)
            {
                e.Valid = false;
                e.ErrorText = "输入名称不能为空!";
            }

            /* 不在验证重名
            //当前选中的对象
            _COBJECTS info = this.projectTrees1.SelectItem;

            //将要修改的名称等于源名称不在进行验证
            if (e.Value.ToString() != info.Property.Name)
            {
                //验证是否重名
                if (this.isExist(e.Value.ToString(), info.ObjectType))
                {
                    e.Valid = false;
                    e.ErrorText = string.Format("单项工程名称[{0}]已经存在项目中，请修改后继续操作！", e.Value.ToString());
                }
            }
            */
        }

        /// <summary>
        /// 单元格编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

            DataRowView info = this.projectTrees1.treeList1.GetDataRecordByNode(e.Node) as DataRowView;
            if (info != null)
            {
                info["Name"]= e.Value.ToString();
                info["NodeName"] = e.Value.ToString();
                //info.StructSource.ModelProject.UpDate(info);
                //this.CurrentBusiness.Current.StructSource.ModelProject.UpDate(info);
                _UnitProject unit = info["UnitProject"] as _UnitProject;
                if (unit != null)
                {
                    unit.Name = unit.NodeName = e.Value.ToString();
                    info["UnitProject"] = unit;
                }
            }
            

            ///如果是已经存在的数据
            /*if (this.projectTrees1.SelectItem.ObjectState == EObjectState.UnChange)
            {
                //当前对象设置为修改状态
                this.projectTrees1.SelectItem.ObjectState = EObjectState.Modify;
            }
            this.projectTrees1.SelectItem.Property.Name = e.Value.ToString();*/
        }

        /// <summary>
        /// 删除选中的对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //删除选中的对象包含 单位工程 单项工程
            //此处删除可能包含以前已经存在的数据
            _COBJECTS info = this.projectTrees1.SelectNotEntity;
            if (info is _Projects) return;
            //this.projectTrees1.bindingSource1.Remove(this.bindingSource1.Current);
            //如果删除的是单项工程
            this.Remove(this.projectTrees1.bindingSource1.Current as DataRowView);
            //删除后
            //this.projectTrees1.bindingSource1.RemoveCurrent();
            /*if (info.ObjectType != EObjectType.PROJECT)
            {
                //如果是以前存在的项目
                switch (info.ObjectState)
                {
                    case EObjectState.UnChange:
                    case EObjectState.Created:
                    case EObjectState.Modify:
                    case EObjectState.Undefined:
                        info.ObjectState = EObjectState.Delete;
                        break;
                    default:
                        this.projectTrees1.bindingSource1.Remove(info.Directory);
                        break;
                }
            }
            this.projectTrees1.treeList1.FilterNodes();*/
        }


        private void Remove(DataRowView p_View)
        {
            //如果当前有子行
            //如果深度是2 直接删除 如果深度是1 删除所有子节点
            int deep = ToolKit.ParseInt(p_View["DEEP"]);
            if (deep == 1)
            {
                int id = ToolKit.ParseInt(p_View["ID"]);
                //单项删除
                DataRow[] rows = CurrentSource.Select(string.Format("PID = {0}", id));
                if (rows != null)
                {
                    foreach (DataRow r in rows)
                    {
                        switch (r.RowState)
                        {
                            case DataRowState.Added://新增的数据直接删除
                                r.Delete();
                                break;
                            case DataRowState.Modified:
                            case DataRowState.Unchanged:
                                //添加到删除对象清单
                                _COBJECTS info = new _COBJECTS();
                                _ObjectSource.GetObject(info,r);
                                DelTable.Add(info.ID, info);
                                r.Delete();
                                break;
                        }
                    }
                }
            }
            
                //处理删除单项工程
                switch (p_View.Row.RowState)
                {
                    case DataRowState.Added:
                        p_View.Delete();
                        break;
                    case DataRowState.Modified:
                    case DataRowState.Unchanged:
                        //添加到删除对象清单
                        _COBJECTS info = new _COBJECTS();
                        _ObjectSource.GetObject(info, p_View);
                        DelTable.Add(info.ID, info);
                        p_View.Delete();
                        break;
                }

                p_View.Delete();
                CurrEn = null;
        }

        /// <summary>
        /// 最终确定提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            (this.CurrentBusiness.Current as _Projects).EnSort = EnSort;
            (this.CurrentBusiness.Current as _Projects).UnSort = UnSoft;
            this.CurrentBusiness.Current.ObjectKey = this.ObjectKey;
            (this.CurrentBusiness as _Pr_Business).BatchAdd(this.CurrentSource, this.DelTable);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 放弃提交数据(取消)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //所有之前的状态为delete的节点全部还原为删除撤销(以前有的对象删除才会调用此方法)
            //撤销当前业务基数

            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //启用筛选所有节点
            
            this.projectTrees1.treeList1.FilterNodes();
        }
    }
}