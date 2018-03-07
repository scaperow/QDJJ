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

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProExplain : BaseUI
    {
        #region 字段、属性
        private DataTable dtProItems = null;
        /// <summary>
        /// 筛选项Table
        /// </summary>
        public DataTable DtProItems
        {
            get { return dtProItems; }
            set { dtProItems = value; }
        }
        private DataTable dtDE = null;
        /// <summary>
        /// 定额Table
        /// </summary>
        public DataTable DtDE
        {
            get { return dtDE; }
            set { dtDE = value; }
        }
        /// <summary>
        /// 当前行
        /// </summary>
        public DataRowView CurrRow
        {
            get { return this.bindingSource1.Current as DataRowView; }
        }
        #endregion

        public ProExplain()
        {
            InitializeComponent();
        }
        private void ProExplain_Load(object sender, EventArgs e)
        {
            buildTable();
            this.bindingSource1.DataSource = this.dtProItems;
            this.gridControlEx1.DataSource = this.bindingSource1;
            this.gridControlEx2.DataSource = this.bindingSourceDE;
            this.bindingSource1.AddNew();
        }

        /// <summary>
        /// 确定定额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQDDE_Click(object sender, EventArgs e)
        {
            DataView dvTemp = null;
            string strWhere = "";
            string strCS = null;

            DelDE();

            #region 外脚手架
            //外脚手架
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["外脚手架"].DefaultView;
            dvTemp.RowFilter = "";
            strWhere = string.Format(" YG ='{0}'", this.GetFWBySZ(CurrRow["YG"], BHTYPE.全部包含, dvTemp.ToTable(), "YG"));
            AddDE(dvTemp, strWhere);
            #endregion

            #region 里脚手架
            //里脚手架
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["里脚手架"].DefaultView;
            dvTemp.RowFilter = "";
            strWhere = "";
            AddDE(dvTemp, strWhere);
            #endregion

            #region 起重机
            //起重机
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["起重机"].DefaultView;
            dvTemp.RowFilter = "";
            strWhere = string.Format("JGLX ='{0}' and GCLX like '%,{1},%' and SGFF = '{2}'", CurrRow["JGLX"], CurrRow["GCLX"], CurrRow["SGFF"]);

            strCS = this.GetFWBySZ(CurrRow["CS"], BHTYPE.全部包含, dvTemp.ToTable(), "CS");
            if (string.IsNullOrEmpty(strCS))
            {
                strWhere += string.Format(" and YG='{0}'", this.GetFWBySZ(CurrRow["YG"], BHTYPE.全部包含, dvTemp.ToTable(), "YG"));
            }
            else
            {
                strWhere += string.Format(" and CS='{0}'", strCS);
            }

            AddDE(dvTemp, strWhere);
            #endregion

            #region 垂直运输
            //垂直运输
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["垂直运输"].DefaultView;
            dvTemp.RowFilter = "";
            string strYG = this.GetFWBySZ(CurrRow["YG"], BHTYPE.全部包含, dvTemp.ToTable(), "YG");
            string strYSGD = this.GetFWBySZ(CurrRow["CZYSGD"], BHTYPE.全部包含, dvTemp.ToTable(), "YSGD");
            strWhere = string.Format("YG ='{0}' and (CS is null or CS ='{1}') and (YSGD is null or YSGD = '{2}')", strYG, CurrRow["CS"], strYSGD);
            AddDE(dvTemp, strWhere);
            #endregion

            #region 超高降效
            //超高降效
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["超高降效"].DefaultView;
            dvTemp.RowFilter = "";
            strCS = this.GetFWBySZ(CurrRow["CS"], BHTYPE.全部包含, dvTemp.ToTable(), "CS");
            if (string.IsNullOrEmpty(strCS))
            {
                strWhere = string.Format(" YG='{0}'", this.GetFWBySZ(CurrRow["YG"], BHTYPE.全部包含, dvTemp.ToTable(), "YG"));
            }
            else
            {
                strWhere = string.Format(" CS='{0}'", strCS);
            }
            AddDE(dvTemp, strWhere);
            #endregion

            #region 超高加压
            //超高加压
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["超高加压"].DefaultView;
            dvTemp.RowFilter = "";
            strCS = this.GetFWBySZ(CurrRow["CS"], BHTYPE.全部包含, dvTemp.ToTable(), "CS");
            if (string.IsNullOrEmpty(strCS))
            {
                strWhere = string.Format(" YG='{0}'", this.GetFWBySZ(CurrRow["YG"], BHTYPE.全部包含, dvTemp.ToTable(), "YG"));
            }
            else
            {
                strWhere = string.Format(" CS='{0}'", strCS);
            }
            AddDE(dvTemp, strWhere);
            #endregion

            #region 安拆费
            //安拆费
            dvTemp = APP.Application.Global.DataTamp.工程说明表.Tables["安拆费"].DefaultView;
            dvTemp.RowFilter = "";
            strCS = this.GetFWBySZ(CurrRow["CS"], BHTYPE.全部包含, dvTemp.ToTable(), "CS");
            if (string.IsNullOrEmpty(strCS))
            {
                strWhere = string.Format(" YG is null or YG='{0}'", this.GetFWBySZ(CurrRow["YG"], BHTYPE.全部包含, dvTemp.ToTable(), "YG"));
            }
            else
            {
                strWhere = string.Format(" CS is null or CS='{0}'", strCS);
            }
            AddDE(dvTemp, strWhere);
            #endregion

            this.bindingSourceDE.DataSource = this.dtDE;
        }

        /// <summary>
        /// 添加定额
        /// </summary>
        /// <param name="dvTemp"></param>
        /// <param name="strWhere"></param>
        private void AddDE(DataView dvTemp, string strWhere)
        {
            dvTemp.RowFilter = strWhere;
            foreach (DataRowView item in dvTemp)
            {
                DataRow row = this.dtDE.NewRow();
                row["DEBH"] = item["DEBH"];
                row["DEMC"] = item["DEMC"];
                if (item.DataView.Table.Columns.Contains("DW"))
                {
                    row["DW"] = item["DW"];
                }
                row["CSQD"] = item["CSQD"];
                if (dvTemp.Table.Columns.Contains("WZ"))
                {
                    row["WZ"] = item["WZ"];
                }
                row["TJ"] = string.Format("【{0}】{1}", CurrRow["FormMC"], CurrRow["ID"]);
                this.dtDE.Rows.Add(row);
            }
        }
        /// <summary>
        /// 移除定额
        /// </summary>
        private void DelDE()
        {
            this.bindingSourceDE.Filter = string.Format("TJ='{0}'", string.Format("【{0}】{1}", CurrRow["FormMC"], CurrRow["ID"]));
            foreach (DataRowView item in bindingSourceDE)
            {
                bindingSourceDE.Remove(item);
            }
        }

        /// <summary>
        /// 刷新到措施项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Activitie == null || this.CurrentBusiness == null)
            {
                MsgBox.Alert("请打开单位工程再刷新数据！");
                return;
            }
            if (this.dtDE.Rows.Count > 0)
            {
                bool Is_TH = false;
                bool Is_CZ = false;
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    foreach (DataRow item in this.dtDE.Rows)
                    {
                        if (Is_CZ)
                        {
                            break;
                        }
                        //根据位置找清单
                        DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select("XMBM='" + item["WZ"] + "'", "id desc");
                        if (rows.Length > 0)
                        {
                            _Entity_SubInfo info1 = new _Entity_SubInfo();
                            _ObjectSource.GetObject(info1, rows[0]);
                            DataRow[] rowsDE = this.Activitie.StructSource.ModelMeasures.Select(string.Format(" ZDSC=True and XMBM='{0}' and PID='{1}'", item["DEBH"], info1.ID), "id desc");
                            if (rowsDE.Length > 0)
                            {
                                DialogResult dl = MsgBox.Show("措施定额已存在是否替换？", MessageBoxButtons.YesNoCancel);
                                switch (dl)
                                {
                                    case DialogResult.Cancel:
                                        return;
                                    case DialogResult.Yes:
                                        Is_TH = true;
                                        break;
                                    case DialogResult.No:
                                        Is_TH = false;
                                        break;
                                }
                                Is_CZ = true;
                            }

                            calculator.Rows.Add(item);
                        }
                    }
                }
                _Methods_Infomation infomation = new _Methods_Infomation(this.Activitie, this.CurrentBusiness);
                try
                {
                    infomation.CreateCSZM(this.dtDE.Select(), Is_TH);
                    MsgBox.Alert("添加成功！");
                }
                catch (Exception)
                {
                    MsgBox.Alert("您选择的定额库不正确！");
                }
            }
            else
            {
                MsgBox.Alert("请先确定措施定额！");
            }
        }
        /// <summary>
        /// 取消关闭Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化Table
        /// </summary>
        private void buildTable()
        {
            ///筛选项Table
            this.dtProItems = new DataTable();
            this.dtProItems.Columns.Add("ID");//编号
            this.dtProItems.Columns["ID"].AutoIncrement = true;
            this.dtProItems.Columns["ID"].AutoIncrementSeed = 1;
            this.dtProItems.Columns["ID"].AutoIncrementStep = 1;
            this.dtProItems.Columns["ID"].ReadOnly = true;
            this.dtProItems.Columns.Add("XH");//序号
            this.dtProItems.Columns.Add("JGLX");//结构类型
            this.dtProItems.Columns.Add("GCLX");//工程类型
            this.dtProItems.Columns.Add("SGFF");//施工方法
            this.dtProItems.Columns.Add("YG");//檐高（M）
            this.dtProItems.Columns.Add("CS");//层数
            this.dtProItems.Columns.Add("CZYSGD");//垂直运输高度
            this.dtProItems.Columns.Add("FormMC");//窗体名称
            this.dtProItems.Columns["FormMC"].DefaultValue = " 土建：工程说明";
            this.dtProItems.Columns.Add("IsFresh", typeof(bool));///是否刷新
            ///定额Table
            this.dtDE = new DataTable();
            this.dtDE.Columns.Add("ID");//编号
            this.dtDE.Columns["ID"].AutoIncrement = true;
            this.dtDE.Columns["ID"].AutoIncrementSeed = 1;
            this.dtDE.Columns["ID"].AutoIncrementStep = 1;
            this.dtDE.Columns["ID"].ReadOnly = true;
            this.dtDE.Columns.Add("DEBH");//定额号
            this.dtDE.Columns.Add("DEMC");//定额名称
            this.dtDE.Columns.Add("DW");//定额单位
            this.dtDE.Columns.Add("GCL");//工程量
            this.dtDE.Columns["GCL"].DefaultValue = 1;
            this.dtDE.Columns.Add("CSQD");//位置【措施清单名称】
            this.dtDE.Columns.Add("WZ");//位置【措施清单号】
            this.dtDE.Columns.Add("TJ");//条件
            this.dtDE.Columns.Add("IsFresh", typeof(bool));///是否刷新
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (CurrRow == null) return;
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "JGLX":
                    this.popControl1.DataSource = APP.Application.Global.DataTamp.工程说明表.Tables["结构类型"];
                    this.popControl1.ColName = new string[] { "结构类型|JGLX|JGLX" };
                    this.popControl1.bind();
                    break;
                case "GCLX":
                    this.popControl1.DataSource = APP.Application.Global.DataTamp.工程说明表.Tables["工程类型"];
                    this.popControl1.ColName = new string[] { "工程类型|GCLX|GCLX" };
                    this.popControl1.bind();
                    break;
                case "SGFF":
                    this.popControl1.DataSource = APP.Application.Global.DataTamp.工程说明表.Tables["施工方法"];
                    this.popControl1.ColName = new string[] { "施工方法|SGFF|SGFF" };
                    this.popControl1.bind();
                    break;
                case "YG":
                    this.repositoryItemSpinEdit1.MinValue = 0.1M;
                    this.repositoryItemSpinEdit1.MaxValue = 160M;
                    break;
                case "CS":
                    this.repositoryItemSpinEdit1.MinValue = 1M;
                    this.repositoryItemSpinEdit1.MaxValue = 46M;
                    break;
                case "CZYSGD":
                    this.repositoryItemSpinEdit1.MinValue = 0.1M;
                    this.repositoryItemSpinEdit1.MaxValue = 160M;
                    break;
            }
        }

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
        }
    }
}