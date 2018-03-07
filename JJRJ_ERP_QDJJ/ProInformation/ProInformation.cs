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
using GOLDSOFT.QDJJ.CTRL;
using System.Collections;
using ZiboSoft.Commons.Common;
using System.Reflection;
using System.IO;
using GOLDSOFT.QDJJ.UI.Class;
using System.Security.AccessControl;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProInformation : ABaseForm
    {
        private _UnInformation m_Information;
        private BaseInfo Basefrom = null;
        /// <summary>
        /// 当前单位工程的工程信息
        /// </summary>
        public _UnInformation Information
        {
            get { return m_Information; }
            set { m_Information = value; }
        }
        /// <summary>
        /// 参数设置的panne
        /// </summary>
        private PanelControl SettingPanel = null;

        #region 构造函数
        public ProInformation(bool IsNew)
        {
            if (IsNew)
            {
                this.m_Information = APP.UnInformation;
                this.m_Information.InformationTable = new _InformationTable();//重新构造Form表
                this.m_Information.BuildTable();//重新构造清单定额表
            }
            switch (APP.UnInformation.InformationType)
            {
                case InformationType.建筑装饰:
                    if (APP.Application.Global.DataTamp.工程信息表 == null || APP.Application.Global.DataTamp.工程信息表.Tables.Count < 1)
                        APP.Application.Global.DataTamp.工程信息表 = APP.GoldSoftClient.GetServiceData("土建");
                    if (IsNew)
                        APP.UnInformation.TreeTable = APP.Application.Global.DataTamp.工程信息表.Tables["TJ_节点显示"];
                    break;
                case InformationType.给排水雨水:
                case InformationType.采暖热源:
                case InformationType.燃气管道:
                case InformationType.工业管道:
                case InformationType.水灭火:
                case InformationType.气体灭火:
                case InformationType.泡沫灭火:
                case InformationType.消火栓:
                case InformationType.火灾报警:
                case InformationType.通风空调:
                case InformationType.电气设备:
                case InformationType.智能综合:
                    if (APP.Application.Global.DataTamp.安装专业工程信息表 == null || APP.Application.Global.DataTamp.安装专业工程信息表.Tables.Count < 1)
                        APP.Application.Global.DataTamp.安装专业工程信息表 = APP.GoldSoftClient.GetServiceData("安装");
                    if (IsNew)
                    {
                        DataTable dtTemp = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["AZ_节点显示"];
                        int TemplateID = -1;
                        try
                        {
                            TemplateID = Convert.ToInt32(this.m_Information.InformationType);
                            dtTemp.DefaultView.RowFilter = string.Format("TemplateID like '%,{0},%'", TemplateID.ToString());
                            APP.UnInformation.TreeTable = dtTemp.DefaultView.ToTable();
                        }
                        catch { }
                    }
                    break;
            }
            this.m_Information = APP.UnInformation;

            InitializeComponent();
        }
        #endregion

        private DataTable LeftTree = null;

        private void ProInformation_Load(object sender, EventArgs e)
        {
            if (this.CurrentBusiness != null && this.CurrentBusiness.Current != null)
            {
                if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                {
                    this.simpleButton1.Enabled = false;
                    this.simpleButton2.Enabled = false;
                }
                else 
                {
                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                }
                //this.simpleButton1.Enabled = !this.CurrentBusiness.Current.IsDZBS;
                //this.simpleButton2.Enabled = !this.CurrentBusiness.Current.IsDZBS;
            }
            Init();

        }
        private void Init()
        {
            this.BuildData();
            treeListEx1.OptionsView.ShowColumns = false;//隐藏头部标题
            treeListEx1.OptionsView.ShowIndicator = false;//隐藏左侧边框
            treeListEx1.DataSource = LeftTree;
            treeListEx1.KeyFieldName = "Id";
            treeListEx1.ParentFieldName = "Pid";
            treeListEx1.Expand(2);//展开的层级
            this.QDSource.DataSource = APP.UnInformation.QDTable;
            this.QDtreeList.DataSource = this.QDSource;
            this.DESource.DataSource = APP.UnInformation.DETable;
            this.DEtreeList.DataSource = this.DESource;
            this.SettingPanel = new PanelControl();

        }


        /// <summary>
        /// 构建树节点数据结构
        /// </summary>
        private void Build()
        {
            //this.LeftTree = new DataTable();
            //this.LeftTree.Columns.Add("Id", typeof(int));
            //this.LeftTree.Columns.Add("Name");
            //this.LeftTree.Columns.Add("Pid", typeof(int));
            //this.LeftTree.Columns.Add("FormName");
            //this.LeftTree.Columns.Add("PARENTID", typeof(int));
            //this.LeftTree.Columns.Add("SYBH", typeof(int));
            //this.LeftTree.Columns.Add("MUNR");
            //this.LeftTree.Columns.Add("SFXS", typeof(bool));
        }


        #region 构建树节点数据
        /// <summary>
        /// 构建树节点
        /// </summary>
        private void BuildData()
        {
            this.Build();
            this.LeftTree = APP.UnInformation.TreeTable;

            if (!APP.UnInformation.QDTable.Columns.Contains("BZ"))
                APP.UnInformation.QDTable.Columns.Add("BZ");

            //  DataTable dt1 = APP.Application.Global.DataTamp.TempDataSet.Tables["ProInformationTree"];

            //int m = dt1.Rows.Count;
            //foreach (DataRow item in dt1.Rows)
            //{
            //    DataRow r = this.LeftTree.NewRow();
            //    r["Id"] = item["Id"];
            //    r["Name"] = item["Name"];
            //    r["Pid"] = item["Pid"];
            //    r["FormName"] = item["FormName"];
            //    r["PARENTID"] = -1;
            //    r["SYBH"] = -1;
            //    r["SFXS"] = true;
            //    this.LeftTree.Rows.Add(r);
            //}
            //if (this.Activitie == null) return;
            //if (this.Activitie.Property.Libraries.AtlasGallery.LibraryDataSet == null) return;
            //DataTable dt2 = this.Activitie.Property.Libraries.AtlasGallery.LibraryDataSet.Tables["图集索引表"];

            //foreach (DataRow item in dt2.Rows)
            //{
            //    DataRow r = this.LeftTree.NewRow();

            //    int id = ToolKit.ParseInt(item["SYBH"]);
            //    int PID = ToolKit.ParseInt(item["PARENTID"]);
            //    r["Id"] = id + m;
            //    r["Name"] = item["MUNR"];
            //    if (PID != 0)
            //    {
            //        r["Pid"] = PID + m;
            //    }
            //    else { r["Pid"] = 020105; }

            //    r["FormName"] = "图集";
            //    r["PARENTID"] = item["PARENTID"];
            //    r["SYBH"] = item["SYBH"];
            //    r["MUNR"] = item["MUNR"];
            //    r["SFXS"] = item["SFXS"];
            //    this.LeftTree.Rows.Add(r);
            //}
            //筛选要显示的节点
            // this.LeftTree.DefaultView.RowFilter = string.Format("SFXS={0}", "True");

        }
        #endregion
        private Hashtable FormList = new Hashtable();

        private void treeListEx1_Click(object sender, EventArgs e)
        {
            TreeListEx t = sender as TreeListEx;
            MouseEventArgs e1 = e as MouseEventArgs;
            if (e1.Button == MouseButtons.Left)
            {
                if (t.Selection[0] != null && !string.IsNullOrEmpty(t.Selection[0].GetValue("FormName").ToString()))
                {
                    doAction(t.Selection[0].GetValue("FormName").ToString(), t.Selection[0].GetValue("SYBH"), t.Selection[0].GetValue("节点名称").ToString(), ToolKit.ParseInt(t.Selection[0].GetValue("ID")));
                    splitContainerControl2.Visible = true;
                }
            }
        }

        #region 根据节点创建窗体
        /// <summary>
        /// 初始化加载  筛选条件  窗体
        /// </summary>
        /// <param name="strFormName">窗体名称</param>
        /// <param name="str_Param">窗体参数</param>
        /// <param name="strName">窗体名称【中文】</param>
        /// <param name="KeyID">节点编号</param>
        private void doAction(string strFormName, object str_Param, string strName, int KeyID)
        {
            string p_key = strFormName;
            if (strFormName != "Zhuangshi")
            {
                p_key += KeyID.ToString();
            }

            if (FormList.Contains(p_key))
            {
                Basefrom = this.FormList[p_key] as BaseInfo;
            }
            else
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Object obj = asm.CreateInstance(string.Format("GOLDSOFT.QDJJ.UI.{0}", strFormName), true);
                Basefrom = obj as BaseInfo;

                if (Basefrom == null) return;
                Basefrom.KeyID = KeyID;
                Basefrom.InformationForm = this;
                Basefrom.SourceChange -= new BaseInfo.SourceChangeHanld(from_SourceChange);
                Basefrom.SourceChange += new BaseInfo.SourceChangeHanld(from_SourceChange);
                Basefrom.CurrentBusiness = this.CurrentBusiness;
                Basefrom.Activitie = this.Activitie;
                Basefrom.FormBorderStyle = FormBorderStyle.None;
                Basefrom.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
                //设置为非顶级控件
                Basefrom.TopLevel = false;
                //显示窗体
                Basefrom.Visible = true;
                this.FormList.Add(p_key, Basefrom);
            }
            if (this.splitContainerControl1.Panel2.Contains(this.SettingPanel))
            {
                this.splitContainerControl1.Panel2.Controls.Remove(this.SettingPanel);
            }
            this.splitContainerControl1.Panel2.Controls.Add(this.Mainpanel);
            if (strFormName == "Zhuangshi")
            {
                Basefrom.Parm = str_Param;
            }
            else
            {
                Basefrom.Parm = strName;
            }

            this.splitContainerControl2.Panel1.Controls.Clear();
            this.splitContainerControl2.Panel1.Controls.Add(Basefrom);


        }

        private void ShowSettingForm(string strFormName, object str_Param)
        {
            string p_key = strFormName;
            BaseInfo from = null;
            if (FormList.Contains(p_key))
            {
                from = this.FormList[p_key] as BaseInfo;
            }
            else
            {
                from = new ProSetting();
                from.InformationForm = this;
                from.Activitie = this.Activitie;
                from.FormBorderStyle = FormBorderStyle.None;
                from.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
                //设置为非顶级控件
                from.TopLevel = false;
                //显示窗体
                from.Visible = true;
            }

            if (this.splitContainerControl1.Panel2.Controls.Contains(this.Mainpanel))
            {

                this.splitContainerControl1.Panel2.Controls.Remove(this.Mainpanel);
            }
            this.SettingPanel.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel2.Controls.Add(this.SettingPanel);
            this.SettingPanel.Controls.Clear();
            this.SettingPanel.Controls.Add(from);

        }
        #endregion

        void from_SourceChange(object obj, DataRow args, List<DataRow> r)
        {

            bool flag = ToolKit.ParseBoolen(obj);
            if (flag)
            {
                #region 移除原数据项
                this.QDSource.Filter = string.Format("TJ='{0}'", args["TJ"]);
                if (this.QDSource.Count > 0)
                {
                    DataRowView row = QDSource.Current as DataRowView;
                    DataRow[] rowList = APP.UnInformation.DETable.Select("QDBH='" + row.Row["QDBH"] + "'");
                    foreach (DataRow item in rowList)
                    {
                        APP.UnInformation.DETable.Rows.Remove(item);
                    }
                    APP.UnInformation.QDTable.Rows.Remove(row.Row);
                }
                #endregion

                this.QDSource.Filter = string.Format("QDBH='{0}' and TJ='{1}'", args["QDBH"], args["TJ"]);
                if (this.QDSource.Count < 1)
                {
                    APP.UnInformation.QDTable.Rows.Add(args);
                    foreach (DataRow item in r)
                    {
                        APP.UnInformation.DETable.Rows.Add(item);
                    }
                }
            }
            this.QDSource.Filter = string.Format("QDBH='{0}' and TJ='{1}'", args["QDBH"], args["TJ"]);
            this.DESource.Filter = string.Format("QDBH='{0}' and TJ='{1}'", args["QDBH"], args["TJ"]);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="p_QDBH"></param>
        /// <param name="p_TJ"></param>
        public void Remove(string p_QDBH, string p_TJ)
        {
            string StrWher = string.Format("QDBH='{0}' and TJ='{1}'", p_QDBH, p_TJ);
            DataRow[] rowList = APP.UnInformation.DETable.Select(StrWher);
            foreach (DataRow item in rowList)
            {
                APP.UnInformation.DETable.Rows.Remove(item);
            }
            DataRow[] rowList1 = APP.UnInformation.QDTable.Select(StrWher);
            foreach (DataRow item in rowList1)
            {
                APP.UnInformation.QDTable.Rows.Remove(item);
            }
            this.Fiter(StrWher);
        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="p_TJ"></param>
        public void Remove(string p_TJ)
        {
            string StrWher = string.Format("TJ='{0}'", p_TJ);
            DataRow[] rowList = APP.UnInformation.DETable.Select(StrWher);
            foreach (DataRow item in rowList)
            {
                APP.UnInformation.DETable.Rows.Remove(item);
            }
            DataRow[] rowList1 = APP.UnInformation.QDTable.Select(StrWher);
            foreach (DataRow item in rowList1)
            {
                APP.UnInformation.QDTable.Rows.Remove(item);
            }
            this.Fiter(StrWher);
        }
        /// <summary>
        /// 更新工程量
        /// </summary>
        /// <param name="p_QDBH">清单编号[可以不用输清单编号为NULL]</param>
        /// <param name="p_TJ">条件</param>
        /// <param name="SWGCL">新实物工程量</param>
        public void UpdateGCL(string p_QDBH, string p_TJ, decimal SWGCL)
        {
            string StrWher;
            if (string.IsNullOrEmpty(p_QDBH))
            {
                StrWher = string.Format(" TJ='{0}' and ( XS is not null or (XS is null and GCL is null))", p_TJ);
            }
            else
            {
                StrWher = string.Format("QDBH='{0}' and TJ='{1}' and ( XS is not null or (XS is null and GCL is null))", p_QDBH, p_TJ);
            }

            this.Fiter(StrWher);

            foreach (DataRowView itemQD in this.QDSource)
            {
                itemQD["GCL"] = ToolKit.ParseDecimal(itemQD["XS"]) * SWGCL;
                foreach (DataRowView itemDE in this.DESource)
                {
                    itemDE["GCL"] = ToolKit.ParseDecimal(itemDE["XS"]) * ToolKit.ParseDecimal(itemQD["GCL"]);
                }
            }
            if (string.IsNullOrEmpty(p_QDBH))
            {
                StrWher = string.Format(" TJ='{0}' ", p_TJ);
            }
            else
            {
                StrWher = string.Format("QDBH='{0}' and TJ='{1}' ", p_QDBH, p_TJ);
            }
            this.Fiter(StrWher);
            this.QDtreeList.Refresh();
            this.DEtreeList.Refresh();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="args">清单</param>
        /// <param name="r">定额</param>
        public void Add(DataRow args, List<DataRow> r)
        {
            string StrWher = string.Format("QDBH='{0}' and TJ='{1}'", args["QDBH"], args["TJ"]);
            if (null != args && !string.IsNullOrEmpty(args["QDBH"].ToString()))
            {
                //string[] arrStrTemp = CDataConvert.ConToValue<string>(args["GCL"]).Split('.');//临时数组
                /////处理 清单  工程量
                //if (arrStrTemp.Length == 2)
                //{
                //    if (arrStrTemp[1].Length > 5)
                //    {
                //        args["GCL"] = CDataConvert.ConToValue<float>(CDataConvert.ConToValue<float>(args["GCL"]).ToString("f4"));
                //    }
                //}
                APP.UnInformation.QDTable.Rows.Add(args);
                foreach (DataRow item in r)
                {
                    ///处理 定额  工程量系数
                    //arrStrTemp = CDataConvert.ConToValue<string>(item["XS"]).Split('.');
                    //if (arrStrTemp.Length == 2)
                    //{
                    //    if (arrStrTemp[1].Length > 5)
                    //    {
                    //        item["XS"] = CDataConvert.ConToValue<float>(CDataConvert.ConToValue<float>(item["XS"]).ToString("f5"));
                    //    }
                    //}
                    /////处理 定额  工程量
                    //arrStrTemp = CDataConvert.ConToValue<string>(item["GCL"]).Split('.');
                    //if (arrStrTemp.Length == 2)
                    //{
                    //    if (arrStrTemp[1].Length > 4)
                    //    {
                    //        item["GCL"] = CDataConvert.ConToValue<float>(CDataConvert.ConToValue<float>(item["GCL"]).ToString("f4"));
                    //    }
                    //}

                    APP.UnInformation.DETable.Rows.Add(item);
                }
            }
            this.Fiter(StrWher);
        }

        /// <summary>
        /// 根据条件筛选
        /// </summary>
        public void Fiter(string p_Fiter)
        {
            this.QDSource.Filter = p_Fiter;
            this.DESource.Filter = p_Fiter;
        }

        #region 给清单的项目名称赋值特性
        /// <summary>
        /// 给清单的项目编码赋值 调用示例： this.InformationForm.SetFixedName("标准图集", Content);
        /// </summary>
        /// <param name="Titile">类似 标准图集 </param>
        /// <param name="Content">类似【标准图集】：1.xxx</param>
        public void SetFixedName(string Titile, string Content)
        {
            DataRowView v = this.QDSource.Current as DataRowView;
            if (v == null) return;
            string str = v["QDMC"].ToString();
            string[] titleList = Titile.Split(',');
            for (int i = 0; i < titleList.Length; i++)
            {
                if (str.Contains(string.Format("【{0}】", titleList[i]))) //如果存在 则是删除操作
                {
                    string[] Ayy = str.Split('【');
                    foreach (string item in Ayy)
                    {
                        if (item.Contains(string.Format("{0}】", titleList[i])))
                        {
                            string a = "【" + item;
                            str = str.Replace(a, "");
                            str = str.Replace(_Constant.回车符, "");
                            string xx = item;
                        }
                    }
                }
                else if (i == titleList.Length - 1) { str += _Constant.回车符 + Content; }
            }
            v.BeginEdit();
            v["QDMC"] = str;
            v.EndEdit();
            this.QDtreeList.Refresh();
        }
        #endregion
        /// <summary>
        /// 清单选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            SetDEAllCheck(!edit.Checked);

        }

        /// <summary>
        /// 子目全部打钩或取消
        /// </summary>
        /// <param name="b"></param>
        private void SetDEAllCheck(bool b)
        {
            foreach (DataRowView item in this.DESource)
            {
                item.BeginEdit();
                item["Check"] = b;
                item.EndEdit();
            }
        }
        /// <summary>
        /// 定额选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemCheckEdit2_Click(object sender, EventArgs e)
        {


        }
        /// <summary>
        /// 清单预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PreviewQD();
        }
        /// <summary>
        /// 清单预览
        /// </summary>
        public void PreviewQD()
        {
            this.QDtreeList.BeginUnboundLoad();
            this.DEtreeList.BeginUnboundLoad();
            string fiter = this.QDSource.Filter;
            Preview p = new Preview(this.Activitie, this.CurrentBusiness);
            p.ShowDialog();
            this.Fiter(fiter);
            this.QDtreeList.EndUnboundLoad();
            this.DEtreeList.EndUnboundLoad();
        }
        /// <summary>
        /// 刷新数据到分部分项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //BackgroundWorker OpenUnitWorker = new BackgroundWorker();
                //OpenUnitWorker.WorkerReportsProgress = false;
                //OpenUnitWorker.DoWork += new DoWorkEventHandler(OpenUnitWorker_DoWork);
                //OpenUnitWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OpenUnitWorker_RunWorkerCompleted);
                //OpenUnitWorker.RunWorkerAsync();
                //ProgressFrom form = new ProgressFrom(OpenUnitWorker);
                //form.ShowDialog();
                doOpen();
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                //MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 打开进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void OpenUnitWorker_DoWork(object sender, DoWorkEventArgs e)
        void doOpen()
        {
            try
            {
                if (this.Activitie == null || this.CurrentBusiness == null)
                {
                    MsgBox.Alert("请打开单位工程再刷新数据！");
                    return;
                }
                _Methods_Infomation infomation = new _Methods_Infomation(this.Activitie, this.CurrentBusiness);
                DataRowView v = this.QDSource.Current as DataRowView;
                if (v == null)
                {
                    MsgBox.Alert("当前没有清单！");
                    return;
                }
                if (ToolKit.ParseBoolen(v["Check"]))
                {
                    //DataRow Einfo = infomation.Exists(v["QDBH"].ToString());
                    DataRow Einfo = null;
                    if (v.DataView.Table.Columns.Contains("BZ"))
                        //Einfo = infomation.Exists(v["BZ"].ToString());
                        Einfo = infomation.Exists(v["TJ"].ToString());
                    if (Einfo != null)
                    {
                        //DialogResult dl = MsgBox.Show("清单已存在是否替换？", MessageBoxButtons.YesNoCancel);
                        //switch (dl)
                        //{
                        //   case DialogResult.Cancel:
                        //       return;
                        //    case DialogResult.Yes:
                                string qdbh = v["QDBH"].ToString();
                                infomation.Creat(v.Row, true);
                                MsgBox.Alert("替换清单" + qdbh + "成功！");
                        //        break;
                        //    case DialogResult.No:
                        //        infomation.Creat(v.Row, false);
                        //        MsgBox.Alert("追加清单" + v["QDBH"].ToString() + "成功！");
                        //        break;
                        //}
                    }
                    else
                    {
                        bool Is_TH = false;
                        bool Is_CZ = false;
                        DataRow[] rowsNewDE = APP.UnInformation.DETable.Select(string.Format("TJ='{0}' and WZLX='措施项目'", v.Row["TJ"]));
                        foreach (DataRow item in rowsNewDE)
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
                            }
                        }
                        infomation.Creat(v.Row, Is_TH);
                        MsgBox.Alert("添加清单" + v["QDBH"].ToString() + "成功！");
                    }
                }
                else
                {
                    MsgBox.Alert("当前清单没有选中！");
                }

                //AlertForm form = new AlertForm();
                //form.Text = "自动生成分部分项";
                //form.Content.Text = "当清单数据已经自动生成过（不含手动添加的数据）,\"追加\"则直接新增一条新的清单;\"替换\"只替换自动生成的清单编码中编码最大的一条清单;\"取消\"则取消当前操作";
                //DialogResult d = form.ShowDialog();
                //if (d == DialogResult.Yes)
                //{
                //    this.Activitie.Property.SubSegments.IsZDSC = true;
                //    this.m_Information.CreatAll(true);
                //}
                //if (d == DialogResult.No)
                //{
                //    this.Activitie.Property.SubSegments.IsZDSC = true;
                //    this.m_Information.CreatAll(false);
                //}

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 打开进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenUnitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        } 

        /// <summary>
        /// 导出全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveFile()
        {
            this.SavePath.Title = "另存为工程信息文件";
            this.SavePath.Filter = "工程信息(*.GCXX)|*.GCXX";
            this.SavePath.FileName = "";
            if (this.SavePath.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(this.SavePath.FileName);
                string filepath = this.SavePath.FileName;
                GOLDSOFT.QDJJ.COMMONS.CFiles.BinarySerialize(APP.UnInformation, filepath);
            }
        }
        /// <summary>
        /// 自动备份工程信息
        /// </summary>
        private void BackupGCXX()
        {
            string filePath = Application.StartupPath + "\\工程文件\\备份文件\\";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileName = string.Format("{0}{1}", filePath, DateTime.Now.ToString("yyyyMMddHHmmss") + ".GCXX");
            GOLDSOFT.QDJJ.COMMONS.CFiles.BinarySerialize(APP.UnInformation, fileName);
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult s = MsgBox.Show("工程信息即将关闭，请问是否保存？", MessageBoxButtons.YesNoCancel);
            switch (s)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
                case DialogResult.Yes:
                    BackupGCXX();
                    SaveFile();
                    APP.GcxxKH = false;
                    break;
                case DialogResult.No:
                    BackupGCXX();
                    APP.GcxxKH = false;
                    break;
            }
        }
        /// <summary>
        /// 清单工程量系数更改以后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ///实物工程量
            BaseUI BaseUIForm = null;
            Zhuangshi ZhuangshiForm = null;
            if (Basefrom is BaseUI)
            {
                BaseUIForm = Basefrom as BaseUI;
            }
            else if (Basefrom is Zhuangshi)
            {
                ZhuangshiForm = Basefrom as Zhuangshi;
            }

            decimal deSWGCL = 0;
            if (BaseUIForm != null)
            {
                try
                {
                    deSWGCL = ToolKit.ParseDecimal(BaseUIForm.CurrRow["SWGCL"]);
                }
                catch (Exception)
                { }
            }
            else if (ZhuangshiForm != null)
            {
                try
                {

                    deSWGCL = ToolKit.ParseDecimal(ZhuangshiForm.CurrRow["GCL"]);
                }
                catch (Exception)
                { }
            }

            DataRowView currRow = this.QDSource.Current as DataRowView;
            if (currRow == null) return;
            DevExpress.XtraEditors.SpinEdit decSpinEdit = (sender as DevExpress.XtraEditors.SpinEdit);
            currRow["GCL"] = deSWGCL * ToolKit.ParseDecimal(decSpinEdit.EditValue);
            foreach (DataRowView item in this.DESource)
            {
                item["GCL"] = ToolKit.ParseDecimal(item["XS"]) * ToolKit.ParseDecimal(currRow["GCL"]);
            }
            this.QDtreeList.Refresh();
            this.DEtreeList.Refresh();
        }
        /// <summary>
        /// 定额工程量系数更改以后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemSpinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView QDcurrRow = this.QDSource.Current as DataRowView;
            DataRowView DEcurrRow = this.DESource.Current as DataRowView;
            if (QDcurrRow == null || DEcurrRow == null) return;
            DevExpress.XtraEditors.SpinEdit decSpinEdit = (sender as DevExpress.XtraEditors.SpinEdit);
            DEcurrRow["GCL"] = ToolKit.ParseDecimal(decSpinEdit.EditValue) * ToolKit.ParseDecimal(QDcurrRow["GCL"]);
            this.DEtreeList.Refresh();
        }
    }
}
