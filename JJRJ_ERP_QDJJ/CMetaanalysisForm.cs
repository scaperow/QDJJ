/*
    此窗体为单位工程 汇总分析
 *  单位工程汇总分析会应用到 项目的单位工程汇总分析中 
 *  此窗体需要参数为单位工程
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CMetaanalysisForm : ABaseForm
    {   /// <summary>
        /// Triger when XMBM field changed
        /// </summary>
        public event EventHandler BeforeOnCellValueChanged;
        /// <summary>
        /// Triger when XMBM field changed
        /// </summary>
        public event EventHandler AfterOnCellValueChanged;

        /// <summary>
        /// 参数表
        /// </summary>
        private DataTable ParamTable = null;

        /// <summary>
        /// 当前窗体所操作的单位工程对象
        /// </summary>
        private _UnitProject m_CUnitProject = null;

        private _Method_Metaanalysis Method = null;

        /// <summary>
        /// 获取或设置当窗体操作的单位工程对象
        /// </summary>
        public _UnitProject UnitProject
        {
            set
            {
                this.m_CUnitProject = value;
            }
            get
            {
                return this.m_CUnitProject;
            }
        }

        public CMetaanalysisForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体第一次加载的时候调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMetaanalysisForm_Load(object sender, EventArgs e)
        {
            Method = new _Method_Metaanalysis(this.m_CUnitProject);
            Method.Calculate();
            this.ParamTable = APP.Application.Global.DataTamp.TempDataSet.Tables["Params_Metaanalysis"].Copy();
            this._doLoadData();
            this.initEvent();

        }

        public override void GlobalStyleChange()
        {
            base.GlobalStyleChange();
            //subSegmentListData1.treeList1.ModelName = this.Text;
            //功能区处理

            this.metaanalysisList1.treeList1.ModelName = "汇总分析";
            this.metaanalysisList1.treeList1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.metaanalysisList1.treeList1.ColumnColor = APP.DataObjects.GColor.ColumnColor;
            this.metaanalysisList1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }

        /// <summary>
        /// 重写刷新窗体的动作
        /// </summary>
        public override void Refresh()
        {
            //this.metaanalysisList1.SchemeColor = APP.Application.Global.Configuration.GColor.GetSchemeColor(this.Text);
            //this.metaanalysisList1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            //base.Refresh();
        }

        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.metaanalysisList1.treeList1.OptionsBehavior.Editable = false;


            }
            else
            {
                this.metaanalysisList1.treeList1.OptionsBehavior.Editable = true;

            }
        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        private void initEvent()
        {
            this.Refresh();
            //this.m_CUnitProject.Property.Metaanalysis.Source.ColumnChanged += new DataColumnChangeEventHandler(Source_ColumnChanged);
            this.m_CUnitProject.StructSource.ModelMetaanalysis.ColumnChanged += new DataColumnChangeEventHandler(Source_ColumnChanged);
            this.metaanalysisList1.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treeList1_CellValueChanged);
            this.metaanalysisList1.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treeList1_CellValueChanging);
            this.metaanalysisList1.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit1_ButtonClick);
            this.metaanalysisList1.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit2_ButtonClick);

            this.metaanalysisList1.BTN_IN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BTN_IN_ItemClick);
            this.metaanalysisList1.BTN_OUT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BTN_OUT_ItemClick);
            this.metaanalysisList1.RasieColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(RasieColumns_ItemClick);
        }



        /// <summary>
        /// 显示隐藏列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RasieColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.metaanalysisList1.treeList1);
        }


        void BTN_OUT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        void BTN_IN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Loads();
        }

        /// <summary>
        /// 特项选择的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //打开参数选取页面
            this.openParams_Metaanalysis();
        }

        void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                (this.metaanalysisList1.treeList1.Current as DataRowView)["Calculation"] = form.GetValue;
                Method.Calculate();
                this.metaanalysisList1.treeList1.RefreshDataSource();
                //this.Source.ResetBindings(false);

            }
        }

        private void openParams_Metaanalysis()
        {
            CParams_Metaanalysis form = new CParams_Metaanalysis();
            //循环去当前的数据特像
            int i = 0;
            string str = string.Empty;
            foreach (DataRowView row in this.UnitProject.StructSource.ModelMetaanalysis.DefaultView)
            {
                if (i != this.UnitProject.StructSource.ModelMetaanalysis.Rows.Count - 1)
                {
                    str += string.Format("'{0}',", row["Feature"].ToString());
                }
                else
                {
                    str += string.Format("'{0}'", row["Feature"].ToString());
                }

            }
            form.DataSource = this.ParamTable;
            form.Filter = str;
            DialogResult r = form.ShowDialog(this);
            if (r == DialogResult.OK)
            {

                //确定了后处理当前编辑
                ChangeObject = this.metaanalysisList1.treeList1.Current["Feature"];
                this.metaanalysisList1.Edit(form.Current);
                ModifyAttribute modity = new ModifyAttribute();
                modity.CurrentValue = this.metaanalysisList1.treeList1.Current["Feature"];
                modity.OriginalValue = ChangeObject;
                modity.ObjectName = "费用代号";
                modity.ModelName = "汇总分析";
                modity.Source = this.metaanalysisList1.treeList1.Current.Row;
                modity.FieldName = "Feature";
                //modity.ActingOn = "清单.子目";
                ChangeObject = null;
                this.LogContent.Add(modity);
                //LogContent.Add(e);
                GetContainer.ALogForm.Init();
            }
        }

        /// <summary>
        /// 列改变时候需要重新计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Source_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {

        }
        object ChangeObject = null;
        void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            TreeList tl = sender as TreeList;
            DataRowView v = tl.GetDataRecordByNode(e.Node) as DataRowView;
            ChangeObject = v.Row[e.Column.FieldName];
        }
        void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (BeforeOnCellValueChanged != null)
            {
                BeforeOnCellValueChanged(this, null);
            }

            switch (e.Column.FieldName)
            {
                case "Calculation"://费率
                case "Coefficient"://计算基础
                case "Feature":
                    //判断特项是否为空
                    if (e.Node["Feature"].ToString() != string.Empty)
                    {

                        Method.Calculate();
                        /*if (this.m_CUnitProject.Property.Metaanalysis.IsEdit)
                        {
                            this.m_CUnitProject.Property.Metaanalysis.Calculate();
                        }*/
                    }
                    break;
            }
            ModifyAttribute modity = new ModifyAttribute();
            modity.CurrentValue = e.Value;
            modity.OriginalValue = ChangeObject;
            modity.ObjectName = e.Column.Caption;
            modity.ModelName = "汇总分析";
            modity.Source = this.metaanalysisList1.treeList1.Current.Row;
            modity.FieldName = e.Column.FieldName;
            //modity.ActingOn = "清单.子目";
            ChangeObject = null;
            this.LogContent.Add(modity);
            //LogContent.Add(e);
            GetContainer.ALogForm.Init();

            if (AfterOnCellValueChanged != null)
            {
                AfterOnCellValueChanged(this, null);
            }
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

            _Modify_Method.ModifyEdit_Metaanalysis(p_attr, this.CurrentBusiness, this.Activitie);
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

        /// <summary>
        /// 是否为根结点
        /// </summary>
        /// <param name="row"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool HaveChl(DataRow row, DataTable table)
        {
            DataRow[] rows = table.Select(string.Format("ParentID = {0}", row["ID"]));
            if (rows.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void doLoadData()
        {
            this.metaanalysisList1.DataSource = this.UnitProject.StructSource.ModelMetaanalysis;
            this.metaanalysisList1.Activitie = this.m_CUnitProject;
            this.metaanalysisList1.CurrentBusiness = this.CurrentBusiness;
            if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
            {
                this.metaanalysisList1.treeList1.OptionsBehavior.Editable = false;
            }
            else 
            {
                this.metaanalysisList1.treeList1.OptionsBehavior.Editable = true;
            }
           // this.metaanalysisList1.treeList1.OptionsBehavior.Editable = !this.CurrentBusiness.Current.IsDZBS;
            this.metaanalysisList1.Bind();

        }

        /// <summary>
        /// 如何初始化
        /// </summary>
        public override void Init()
        {
            //提示重新计算
            //DialogResult r = MsgBox.Show(_Prompt.汇总分析重新计算, MessageBoxButtons.YesNo);
            //if (this.Activitie.ObjectState== EObjectState.Modify)
            {
                _doLoadData();
            }
        }

        private void _doLoadData()
        {
            //每次从新计算
            //this.m_CUnitProject.Property.Statistics.Begin();
            //计算后统计
            //this.m_CUnitProject.Property.Metaanalysis.Calculate();
            this.doLoadData();
        }


        /// <summary>
        /// 添加新项目
        /// </summary>
        public void Add()
        {
            this.metaanalysisList1.Add();
        }

        /// <summary>
        /// 添加子项目
        /// </summary>
        public void AddChd()
        {
            this.metaanalysisList1.AddChd();
        }

        public void Delete()
        {
            this.metaanalysisList1.Delete();
        }

        /// <summary>
        /// 保存当前汇总分析文件
        /// </summary>
        public void Save()
        {
            DialogResult result = this.saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Method.Save(this.saveFileDialog1.FileName);
                //this.m_CUnitProject.Property.Metaanalysis.Save(this.saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 读取模板文件
        /// </summary>
        public void Loads()
        {
            this.openFileDialog1.InitialDirectory = APP.Application.Global.AppFolder.FullName + "模板文件\\汇总分析模板";
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Method.Load(this.openFileDialog1.FileName);
                //this.m_CUnitProject.Property.Metaanalysis.Load(this.openFileDialog1.FileName);
                //读取之后刷新
                doLoadData();
            }
        }

        public void Calculate()
        {
            if (Method != null)
            {
                Method.Calculate();
            }
        }

    }
}