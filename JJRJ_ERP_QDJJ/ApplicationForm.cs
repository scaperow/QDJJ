using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.UI.Controls;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Drawing;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.CTRL.Forms;
using System.Runtime.InteropServices;
using GOLDSOFT.QDJJ.UI.Client;
using GOLDSOFT.SERVICES.IServicesObject;
using GOLDSOFT.QDJJ.UI.BaseInformation;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using DevExpress.Utils;
using GoldSoft.CICM.UI;
using DevExpress.XtraTreeList.Nodes;
namespace GOLDSOFT.QDJJ.UI
{
    public partial class ApplicationForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        /// <summary>
        /// 默认显示操作日志界面对象
        /// </summary>
        public LogForm ALogForm = new LogForm();
        /// <summary>
        /// 窗体名称
        /// </summary>
        public string formText = string.Empty;
        /// <summary>
        /// 工程信息窗口
        /// </summary>
        public ProInformation from = null;

        #region -------------------------公用属性---------------

        /// <summary>
        /// 当前应用程序的操作对象
        /// </summary>
        public CActionFace ActionFace;

        private bool m_NetworkConn;
        /// <summary>
        /// 网络连接是否畅通
        /// </summary>
        public bool NetworkConn
        {
            get { return m_NetworkConn; }
            set { m_NetworkConn = value; }
        }

        #endregion

        #region --------------------------关于皮肤-----------------------------

        private void rgbiSkins_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
            //每次更换皮肤的时候调用更换配色方案
            APP.DataObjects.GColor.CurrSkinName = e.Item.Caption;
            //更换完成后变成默认皮肤
            //只保留一套皮肤此处不在保存皮肤设置
            APP.DataObjects.Save();
            APP.DataObjects.GColor.OnGlobalStyleChange();
            //RefreshWorkArea();
        }


        private void rgbiSkins_Gallery_InitDropDownGallery(object sender, InplaceGalleryEventArgs e)
        {
            e.PopupGallery.CreateFrom(rgbiSkins.Gallery);
            e.PopupGallery.AllowFilter = false;
            e.PopupGallery.ShowItemText = false;
            e.PopupGallery.ShowGroupCaption = false;
            e.PopupGallery.AllowHoverImages = false;
            foreach (GalleryItemGroup galleryGroup in e.PopupGallery.Groups)
                foreach (GalleryItem item in galleryGroup.Items)
                    item.Image = item.HoverImage;
            e.PopupGallery.ColumnCount = 2;
            e.PopupGallery.ImageSize = new Size(70, 36);
        }

        /// <summary>
        /// 暂时使用默认记录所有的皮肤样式
        /// </summary>
        public string[] SkinString;

        void InitSkinGallery()
        {
            SimpleButton imageButton = new SimpleButton();
            string[] str = new string[SkinManager.Default.Skins.Count];
            int i = 0;
            //初始化皮肤控件，并初始化当前配色方案
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                imageButton.LookAndFeel.SetSkinStyle(cnt.SkinName);
                GalleryItem gItem = new GalleryItem();
                int groupIndex = 0;
                if (cnt.SkinName.IndexOf("Office") > -1) groupIndex = 1;
                rgbiSkins.Gallery.Groups[groupIndex].Items.Add(gItem);
                gItem.Caption = cnt.SkinName;

                gItem.Image = GetSkinImage(imageButton, 32, 17, 2);
                gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5);
                gItem.Caption = cnt.SkinName;
                //gItem.Hint = cnt.SkinName;

                rgbiSkins.Gallery.Groups[1].Visible = false;
                str[i] = cnt.SkinName;
                i++;
            }
            SkinString = str;
            ///初始化皮肤配置对象(设计时候使用以后此文件不在创建实例)
            //APP.DataObjects.GColor = new GlobalStyle();
            //APP.DataObjects.GColor.Init(str);
            //APP.DataObjects.GColor.SkinName = SkinManager.Default.Skins[0].SkinName;
        }

        Bitmap GetSkinImage(SimpleButton button, int width, int height, int indent)
        {
            Bitmap image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                StyleObjectInfoArgs info = new StyleObjectInfoArgs(new GraphicsCache(g));
                info.Bounds = new Rectangle(0, 0, width, height);
                button.LookAndFeel.Painter.GroupPanel.DrawObject(info);
                button.LookAndFeel.Painter.Border.DrawObject(info);
                info.Bounds = new Rectangle(indent, indent, width - indent * 2, height - indent * 2);
                button.LookAndFeel.Painter.Button.DrawObject(info);
            }
            return image;
        }

        #endregion

        public ApplicationForm()
        {
            InitializeComponent();
            ///设置主工作区域
            ActiveWindow.AppForm = this;
            //初始化使用事件
            initFormEvent();
        }

        /* public ApplicationForm(CSecurity p_Security)
         {
             InitializeComponent();

             this.Security = p_Security;

             //初始化使用事件
             initFormEvent();
         }*/

        private FileInfo DefaultFileInfo = null;

        public ApplicationForm(FileInfo p_Info)
        {
            DefaultFileInfo = p_Info;
            InitializeComponent();
            //初始化使用事件
            initFormEvent();
        }

        /// <summary>
        /// 初始化控件的事件
        /// </summary>
        private void initFormEvent()
        {

            //APP.GoldSoftClient.GlodSoftDiscern.HardWareSucc += new GOLDSOFT.QDJJ.UI.Client.HardWareSuccHandler(GlodSoftDiscern_HardWareSucc);
            //APP.GoldSoftClient.GlodSoftDiscern.TryInit();
            //APP.GoldSoftClient.ClientCompleted += new ClientCompletedHandler(GoldSoftClient_ClientCompleted);
            this.LoadImg();
            this.timer2.Start();
            this.ALogForm.SetLogContent += new SetLogContentHandler(ALogForm_SetLogContent);
            //barButtonItem34 是否共享 

            //开启安全处理
            //this.backgroundWorker1.RunWorkerAsync();
        }

        /*void GoldSoftClient_ClientCompleted(object sender, ClientArgs e)
        {
            if (e.Result != GoldSoftClient.CLIENT_SUCCESS)
            {
                DialogResult result = MsgBox.Show(string.Format("对不起，加密狗工作异常请检查。是否重试？\r\n 重试剩余次数: {0}"), MessageBoxButtons.YesNo);
                Application.Exit();
            }
        }*/

        #region ---------------标识验证--------------------
        /// <summary>
        /// 完成一次验证后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /*void GlodSoftDiscern_HardWareSucc(object sender, int args,ref bool Cancel)
        {
            //还可以尝试
            if (args == _GlodSoftDiscern.TRY_ERROR_AGAIN)
            {
                DialogResult result =  MsgBox.Show(string.Format("对不起，加密狗工作异常请检查。是否重试？\r\n 重试剩余次数: {0}",APP.GoldSoftClient.GlodSoftDiscern.TryCount), MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            //直接关闭
            if (args == _GlodSoftDiscern.TRY_ERROR_OVER)
            {
                Application.Exit();
            }
        }*/

        #endregion

        void ALogForm_SetLogContent(object sender, object args)
        {
            LogContent log = args as LogContent;
            if (log.Count == 0)
            {
                //this.Btn_Fun_Rec.Enabled = false;
            }
            else
            {
                //this.Btn_Fun_Rec.Enabled = true; 
            }
        }



        /// <summary>
        /// 新建项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            //打开引导页面
            //this.ShowWizards();
            this.ActionFace.ShowWizards();
        }



        /// <summary>
        /// 第一次加载的时候执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainRibbonForm_Load(object sender, EventArgs e)
        {
            this.init();
            this.LoadImg();

            //"金建清单计价软件 2013 专业版"

            switch (APP.GoldSoftClient.ClientResult.Fun)
            {
                case 1:
                    this.Text = "金建清单计价软件 2013 专业版";
                    break;
                case 2:
                    this.Text = "金建清单计价软件 2013 旗舰版";
                    break;
                case 3:
                    this.Text = "金建清单计价软件 2013 网络版";
                    break;
                default:
                    this.Text = "金建清单计价软件 2013 领先版";
                    break;
            }
            this.formText = this.Text;

            //判断版本使用功能
            InitFunction(APP.GoldSoftClient.ClientResult);

            if (DefaultFileInfo != null)
            {
                //自动开qi 
                if (DefaultFileInfo.Exists)
                {
                    CActionData.Load(DefaultFileInfo, this);
                }

            }

            //this.timer1.Start();
        }


        /// <summary>
        /// 初始化功能
        /// </summary>
        /// <param name="cResult"></param>
        public void InitFunction(_ClientResult cResult)
        {
            //状态处理 
            bool bIsUseState = false;

            if (!cResult.Custom_IsOwner)
            {

            }
            //状态处理(如果需要逻辑处理请改为函数判断)
            switch (cResult.State)
            {
                case "正常":
                case "临时":
                case "-1"://刚刚初始化的
                    bIsUseState = true;
                    break;
                default:
                    bIsUseState = false;
                    break;
            }


            if (cResult.IsLoginSucess && bIsUseState)
            {
                //失败(失败 所有功能不可用)
                foreach (BarItem bm in this.Ribbon.Items)
                {
                    //if (bm.Name != this.Btn_Fun_Rec.Name)
                    bm.Enabled = true;
                }

                //功能性处理成功 (然后处理功能函数)
                switch (cResult.Fun)
                {
                    case 0: //领先版

                        this.ribbonPage2.Visible = false;
                        barButtonItem34.Visibility = BarItemVisibility.Never;
                        break;
                    case 1:
                        this.ribbonPage2.Visible = true;
                        barButtonItem34.Visibility = BarItemVisibility.Always;
                        break;
                    case 2:
                        break;
                    case 3:
                        this.ribbonPage2.Visible = true;
                        barButtonItem34.Visibility = BarItemVisibility.Always;
                        break;
                }

                SetWorkBar();
            }
            else
            {
                this.ribbonPage2.Visible = true;
                barButtonItem34.Visibility = BarItemVisibility.Always;
                //失败(失败 所有功能不可用)
                foreach (BarItem bm in this.Ribbon.Items)
                {
                    ///if (bm.Name != this.Btn_Fun_Rec.Name)
                    bm.Enabled = false;
                }

            }
        }

        #region WebBrowser
        #region WebBrowser的UserAgent设置
        private static string defaultUserAgent = null;
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        const int URLMON_OPTION_USERAGENT = 0x10000001;

        /// <summary>
        /// 在默认的UserAgent后面加一部分
        /// </summary>
        public static void AppendUserAgent(string appendUserAgent)
        {
            if (string.IsNullOrEmpty(defaultUserAgent))
                defaultUserAgent = GetDefaultUserAgent();
            string ua = defaultUserAgent + ";" + appendUserAgent;
            ChangeUserAgent(ua);
        }
        /// <summary>
        /// 修改UserAgent
        /// </summary>
        public static void ChangeUserAgent(string userAgent)
        {

            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, userAgent, userAgent.Length, 0);
        }
        /// <summary>
        /// 一个很BT的获取IE默认UserAgent的方法
        /// </summary>
        private static string GetDefaultUserAgent()
        {
            WebBrowser wb = new WebBrowser();
            wb.Navigate("about:blank");
            while (wb.IsBusy) Application.DoEvents();
            object window = wb.Document.Window.DomWindow;
            Type wt = window.GetType();
            object navigator = wt.InvokeMember("navigator", BindingFlags.GetProperty,
                null, window, new object[] { });
            Type nt = navigator.GetType();
            object userAgent = nt.InvokeMember("userAgent", BindingFlags.GetProperty,
                null, navigator, new object[] { });
            return userAgent.ToString();
        }
        #endregion

        private bool isHave = false;
        private void LoadImg()
        {
            if (APP.GoldSoftClient.ClientResult.IsUseNet)
            {
                this.webBrowser1.Url = new Uri("http://117.34.66.251/jjrj/index.aspx");
                //this.webBrowser1.Url = new Uri("http://192.168.1.200:9001/jjrj/index.aspx");
                //this.webBrowser1.Url = new Uri("http://localhost:16430/jjrj/index.aspx");

                //AppendUserAgent("JJRJ;" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
                AppendUserAgent("Ver:" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ";JJRJ;" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo);

                this.webBrowser1.ScrollBarsEnabled = true;
            }
            else
            {
                this.webBrowser1.Url = new Uri(APP.Cache.AppFolder + "qdjj_bg/index.html");
                this.webBrowser1.ScrollBarsEnabled = false;
            }
        }
        #endregion

        private void init()
        {
            ActionFace = new CActionFace(this);
            loadFeel();
            //设置当前默认皮肤
            if (APP.DataObjects.GColor.SkinName != string.Empty)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(APP.DataObjects.GColor.CurrSkinName);
            }
            //this.pictureEdit1.SendToBack();
        }


        #region --------------------------RightPanl菜单-----------------------
        /// <summary>
        /// 初始化右菜单
        /// </summary>
        private void initRightPanl()
        {
            pcAppMenuFileLabels.Controls.Clear();
            //降序排列缓存中的对象平且生成控件集合
            FileInfo[] infos = APP.Cache.HistoryCache.List;
            //倒着添加
            for (int i = infos.Length - 1; i >= 0; i--)
            {
                //循环添加控件
                this.insertElement(infos[i], i);
            }
        }

        private void insertElement(FileInfo info, int p_xh)
        {
            AppMenuFileLabel ml = new AppMenuFileLabel();
            pcAppMenuFileLabels.Controls.Add(ml);
            ml.Caption = string.Format("&{0}. {1}", p_xh + 1, info.Name);
            //ml.Checked = checkedLabel;
            ml.AutoHeight = true;
            ml.Dock = DockStyle.Top;
            ml.ToolTip = info.FullName;
            //ml.Image = imgUncheked;
            //ml.SelectedImage = imgChecked;
            ml.LabelClick += new EventHandler(ml_LabelClick);
            ml.Tag = info.FullName;
            ml.Visible = true;

        }

        void ml_LabelClick(object sender, EventArgs e)
        {
            //直接打开当前文件
            //打开选中的
            this.applicationMenu1.HidePopup();
            //改变开启方法
            FileInfo info = new FileInfo((sender as AppMenuFileLabel).Tag.ToString());
            if (info != null)
            {
                if (info.Exists)
                {
                    CActionData.Load(info, this);
                }
            }

        }

        /// <summary>
        /// 弹出菜单时候执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applicationMenu1_Popup(object sender, EventArgs e)
        {
            initRightPanl();
        }
        #endregion


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.OpenProject();

        }

        /// <summary>
        /// 应用程序关闭的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainRibbonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!e.Cancel)
                {

                    DialogResult r = MsgBox.Show(_Prompt.系统关闭确认, MessageBoxButtons.OKCancel);
                    if (r == DialogResult.OK)
                    {
                        Container form = this.ActiveMdiChild as Container;
                        if (form != null)
                        {
                            form.CurrentBusiness.FastCalculate();
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }




        private void MainRibbonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            APP.Jzbx_pwd = false;
            //关闭系统
            APP.Close();
        }

        /// <summary>
        /// 显示联系我们
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            ContactUsForm contactUsForm = new ContactUsForm();

            contactUsForm.Show();
        }

        /// <summary>
        /// 导出电子标书(仅适用于项目)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            //只有项目才可以导出电子标书
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                if (form.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
                {
                    //form.CurrentBusiness.FastCalculate();
                    //电子标书窗体
                    CImportOut_ETenders f = new CImportOut_ETenders();
                    f.CurrentBusiness = form.CurrentBusiness;
                    f.DataSource = form.CurrentBusiness.Current;
                    f.OutType = "JZBX";
                    f.ShowDialog();
                }
            }
        }
        /// <summary>
        /// 导出ZBS数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                form.CurrentBusiness.FastCalculate();
                if (form.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
                {
                    CImportOut f = new CImportOut();
                    ArrayList list = new ArrayList();
                    list.Add(form.CurrentBusiness.Current);
                    f.CurrentBusiness = form.CurrentBusiness;
                    f.DataSource = list;
                    f.OutType = "ZBS";
                    f.ShowDialog();
                }
            }
        }
        /// <summary>
        /// 导出TBS数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                //form.CurrentBusiness.Calculate();
                //form.Calculate();
                // ABaseForm f = form.GetWorkAreas;
                // if (f != null) f.RefreshDataSource();
                form.CurrentBusiness.FastCalculate();
                if (form.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
                {
                    ArrayList list = new ArrayList();
                    list.Add(form.CurrentBusiness.Current);
                    CImportOut f = new CImportOut();
                    f.CurrentBusiness = form.CurrentBusiness;
                    f.DataSource = list;
                    f.OutType = "TBS";
                    f.ShowDialog();
                }
            }

        }
        /// <summary>
        /// 导出BD数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;

            if (form != null)
            {
                form.CurrentBusiness.FastCalculate();
                if (form.CurrentBusiness.WorkFlowType == EWorkFlowType.PROJECT)
                {
                    ArrayList list = new ArrayList();
                    list.Add(form.CurrentBusiness.Current);
                    CImportOut f = new CImportOut();
                    f.CurrentBusiness = form.CurrentBusiness;
                    f.DataSource = list;
                    f.OutType = "BD";
                    f.ShowDialog();
                }
            }
        }
        /// <summary>
        /// 导入ZBS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                form.CurrentBusiness.FastCalculate();
            }
            this.ActionFace.ShowOpenAction();
        }
        /// <summary>
        /// 导入TBS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


        #region --------------------------------线程处理-------------------------------

        //int RCount = 3;

        /// <summary>
        /// 开启线程工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                int resCode = this.Security.Verification.CheckUse();
                switch (resCode)
                {
                    case JJRJ.GrandDogClass.Verification.CVerification.ERROR_CHECK_NOERROR: //没有错误
                        //APP.WorkFlows.LockNum = this.Security.Verification.Info.CurrentNumber.ToString();
                        _Common.LockNum = this.Security.Verification.Info.CurrentNumber.ToString();
                        RCount = 3;
                        break;
                    default://其他错误关闭系统
                        return;
                }
            }
        }*/

        /// <summary>
        /// 线程结束后工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string str = string.Format(_Prompt.加密狗验证失败 + "\n重新尝试次数:{0}",this.RCount);
            DialogResult r = MessageBox.Show(this,str ,"警告", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            switch (r)
            {
                case  DialogResult.Retry:
                    if (this.RCount == 1) Application.Exit();
                    RCount--;
                    this.backgroundWorker1.RunWorkerAsync();
                    break;
                default:
                    Application.Exit();
                    break;
            }
            
        }*/

        #endregion

        /// <summary>
        /// 成为活动窗体的时候调用此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationForm_MdiChildActivate(object sender, EventArgs e)
        {
            DoMdiChildActivate();
            /*Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                //this.Text = string.Format("{0}-{1}", this.Text, form.CurrentBusiness.Current.Files.FullName);
                
            }*/

        }




        /// <summary>
        /// 新建项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_NEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            //打开引导页面
            //this.ShowWizards();
            this.ActionFace.ShowWizards();
        }

        /// <summary>
        /// 打开项目时候的事件(打开文件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_OPEN_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ActionFace.ShowOpenAction();
        }

        /// <summary>
        /// 关闭工程/项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_CLOSE_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (APP.GcxxKH)
            {
                if (from != null)
                    from.Close();
                APP.GcxxKH = false;
            }

            //主要处理点击关闭按钮后关闭当前项目
            Container form = this.ActiveMdiChild as Container;

            if (form != null)
            {
                //关闭前保存提示是否保存项目
                //DialogResult r = MsgBox.Show(_Prompt.项目关闭前保存提示, MessageBoxButtons.YesNo);
                //if (r == DialogResult.Yes)
                {
                    //保存当前活动项目
                    //form.Save();
                }
                APP.Jzbx_pwd = false;
                form.Close();
            }



        }

        /// <summary>
        /// 保存当前活动业务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //当前活动的业务窗体Bar_Sub_ListLib
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                //form.Activitie.Property.Libraries.ListGallery.FullName = this.Bar_Sub_ListLib.Caption;
                //form.Activitie.Property.Libraries.FixedLibrary.FullName = this.Bar_Sub_FixLib.Caption;
                try
                {
                    form.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，请重新保存!", "金建软件");
                }
            }
        }

        private string getStr(string p)
        {
            if (p != "无")
            {
                string Name = p.Substring(4);
                return Name.Substring(0, Name.IndexOf("."));
            }
            return p;
        }




        /// <summary>
        /// 当前业务另存为（与导出功能相同）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_SAVEAS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //当前活动的业务窗体
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                form.CurrentBusiness.FastCalculate();
                string tp = string.Empty;
                if (form.CurrentBusiness.Current.ObjectType == EObjectType.UnitProject)
                {
                    tp = "单位工程";
                }
                else
                {
                    tp = "项目";
                }
                ArrayList list = new ArrayList();
                list.Add(form.CurrentBusiness.Current);
                CImportOut f = new CImportOut();
                f.CurrentBusiness = form.CurrentBusiness;
                f.DataSource = list;
                f.PutType = tp;
                f.IsSaveAs = true;
                f.ShowDialog();
                //另存之后同步名称
                this.Text = form.CurrentBusiness.Current.Files.FullName;
            }
        }

        /// <summary>
        /// 配色方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_SYS_COLOR_ItemClick(object sender, ItemClickEventArgs e)
        {
            CFormColor form = new CFormColor();
            form.GColor = APP.DataObjects.GColor.UseColor;
            form.AppForm = this;

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                //改变通知
                APP.DataObjects.GColor.OnGlobalStyleChange();
                APP.DataObjects.Save();
                //RefreshWorkArea();
            }
        }

        /// <summary>
        /// 加载皮肤配置
        /// </summary>
        private void loadFeel()
        {
            InitSkinGallery();
        }

        /// <summary>
        /// 配置项目密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_SET_PRO_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container f = this.ActiveMdiChild as Container;

            if (f != null)
            {
                CPwdForm form = new CPwdForm();
                form.CurrentBusiness = f.CurrentBusiness;
                form.Source = f.CurrentBusiness.Current;
                form.ShowDialog();
            }
        }
        /// <summary>
        /// 配置项目密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JZBX_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {


            /*
             * 点击后 判断石头锁定
             * if(锁定)
             * 解锁--放开权限
             * 
             * 电子标书导入后，分部分项需要控制的地方
             * （不能对清单进行任何操作。块复制、粘贴不能操作清单，工程信息不能刷新清单，
             * 不能用EXCEL导入清单。清单库、插入清单、删除清单、重排清单号、替换（清单）、
             * 整理到章节专业、撤销整理等功能用密码控制不能使用，删除所选只针对清单
             * （是不是应该为删除所选只针对定额））
             * 
             * 措施项目需要控制的地方。
             * （不能删除清单，插入清单要放到最后）
             * 
             * 其他项目需要控制的地方。
             * （属于招标人部分不能有任何操作，属于投标人部分可以计价）
             * 
             * 工料机汇总需要控制的地方。
             * （甲供材、暂定材料、评标指定材料、甲定材料不能删除和修改，可以添加后面两个）
             * 
             * 汇总分析需要控制的地方。 
             * （除了套用模板别的功能都不能用）
             * **/

            if (!this.barButtonItem33.Enabled)
            {
                if (APP.Jzbx_pwd == false)
                {
                    if (APP.bus != null && this.Validation(APP.bus))
                    {
                        MsgBox.Alert("程序已经解锁！");
                        APP.Jzbx_pwd = true;
                        ////主要处理点击关闭按钮后关闭当前项目
                        //Container form = this.ActiveMdiChild as Container;
                        //if (form != null)
                        //{
                        //    form.Close();
                        //}
                        //APP.Cache.HistoryCache.Add(new FileInfo(APP.bus.Current.Files.FullName));
                        //APP.Cache.HistoryCache.Save();
                        //this.ActionFace.OpenNewBussinessForm(APP.bus);
                    }
                }
                else
                {
                    MsgBox.Alert("程序已经加锁！");

                    APP.Jzbx_pwd = false;
                    return;
                }
            }

            CValidationPWD form = new CValidationPWD();
            Container f = this.ActiveMdiChild as Container;
            form.Source = f.CurrentBusiness.Current;
            DialogResult r = form.ShowDialog();
            if (r == DialogResult.OK)
            {
                //验证通过
                APP.Jzbx_pwd = true;
                //MessageBox.Show("验证通过，");

            }

            //CValidationPWD form = new CValidationPWD();
            //Container f = this.ActiveMdiChild as Container;
            //form.Source = f.CurrentBusiness.Current;
            //DialogResult r = form.ShowDialog();
            //if (r == DialogResult.OK)
            //{
            //    //验证通过
            //    APP.Jzbx_pwd = true;
            //    //MessageBox.Show("验证通过，");

            //}


        }

        /// <summary>
        /// 设置工程密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_SET_UN_PWD_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container f = this.ActiveMdiChild as Container;

            if (f != null)
            {
                _COBJECTS obj = f.Activitie;
                if (obj != null)
                {
                    CPwdForm form = new CPwdForm();
                    form.CurrentBusiness = f.CurrentBusiness;
                    form.Source = obj;
                    form.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 打开计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_TOOLS_CALC_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe ");
        }

        /// <summary>
        /// 默认布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Win_Default_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = this;
            //this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// 水平布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Win_SP_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = null;
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// 分列布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Win_FL_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = null;
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void BTN_Win_Cas_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = null;
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void BTN_Win_Arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = null;
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                this.webBrowser1.Visible = true;
            }
            else
            {
                this.webBrowser1.Visible = false;
            }
        }


        /* private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
             DevExpress.XtraEditors.ComboBoxEdit edit = sender as DevExpress.XtraEditors.ComboBoxEdit;
             if (edit.EditValue != null)
                 this.defaultLookAndFeel1.LookAndFeel.SkinName = edit.EditValue.ToString();
         }*/



        private void barMdiChildrenListItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }

        private void barMdiChildrenListItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        #region ------------------------下方动作条--------------------------

        /// <summary>
        /// 根据当前业务设置
        /// </summary>
        /// <param name="p_Bus"></param>
        public void DoMdiChildChange()
        {
            //当前模块名称
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                //定额库 清单库配置
                if (form.Activitie != null)
                {
                    Bar_Sub_ListLib.Caption = form.Activitie.Property.Libraries.ListGallery.FullName;
                    Bar_Sub_FixLib.Caption = form.Activitie.Property.Libraries.FixedLibrary.FullName;
                }
                else
                {
                    Bar_Sub_ListLib.Caption = Bar_Sub_FixLib.Caption = "无";
                }
            }
        }

        /// <summary>
        /// 设置当前业务动作条(每次更换具体操作区域对象时候调用)
        /// </summary>
        public void SetWorkBar()
        {
            Container form = this.ActiveMdiChild as Container;

            if (form == null)
            {
                this.ProjSBar.Visible = false;
                this.UnitSBar.Visible = false;
                this.DefaultSBar.Visible = true;
            }
            else
            {

                if (ActiveWindow.CurrentABaseForm != null)
                {
                    if (ActiveWindow.CurrentABaseForm.ProjectsForm != null)
                    {

                        //单位工程

                        this.SetUnitSBarValue(ActiveWindow.CurrentABaseForm.ProjectsForm.Activitie);
                        this.UnitSBar.Visible = true;
                        this.ProjSBar.Visible = false;
                        this.DefaultSBar.Visible = false;

                        //控制可用的工作区域
                        if (ActiveWindow.CurrentABaseForm.ProjectsForm.CurrentBusiness.Current.ObjectType == EObjectType.PROJECT)
                        {
                            SetUseBtnForType(2);
                        }
                        else
                        {
                            SetUseBtnForType(1);
                        }

                    }
                    else
                    {
                        //项目
                        //控制可用的工作区域

                        this.ProjSBar.Visible = true;
                        this.UnitSBar.Visible = false;
                        this.DefaultSBar.Visible = false;


                        SetUseBtnForType(2);
                    }
                }
                else
                {
                    this.ProjSBar.Visible = false;
                    this.UnitSBar.Visible = false;
                    this.DefaultSBar.Visible = true;
                    SetUseBtnForType(0);
                }
            }
        }

        /// <summary>
        /// 根据类型控制可使用的功能区域
        /// 0 没有操作 1单位工程 2单项工程
        /// </summary>
        public void SetUseBtnForType(int m_type)
        {
            //this.JZBX_PWD.Enabled = false;
            switch (m_type)
            {
                case 1://单位工程
                    barButtonItem12.Enabled = barButtonItem13.Enabled = barButtonItem28.Enabled = barButtonItem33.Enabled = BTN_SET_PRO_PWD.Enabled = false;
                    this.JZBX_PWD.Enabled = false;
                    break;
                case 2://单项工程
                    if (ActiveWindow.CurrentABaseForm.CurrentBusiness != null && !ActiveWindow.CurrentABaseForm.CurrentBusiness.Current.IsDZBS)
                    {
                        barButtonItem12.Enabled = barButtonItem13.Enabled = barButtonItem28.Enabled = barButtonItem33.Enabled = BTN_SET_PRO_PWD.Enabled = true;
                        this.JZBX_PWD.Enabled = false;
                    }
                    else
                    {
                        if (APP.Jzbx_pwd)
                        {
                            barButtonItem12.Enabled = barButtonItem13.Enabled = barButtonItem28.Enabled = BTN_SET_PRO_PWD.Enabled = true;
                            this.barButtonItem33.Enabled = false;
                        }
                        else
                        {
                            barButtonItem12.Enabled = barButtonItem13.Enabled = barButtonItem28.Enabled = true;
                            barButtonItem33.Enabled = false;
                            this.JZBX_PWD.Enabled = true;
                        }


                    }
                    break;
                default://默认
                    barButtonItem12.Enabled = barButtonItem13.Enabled = barButtonItem28.Enabled = barButtonItem33.Enabled = BTN_SET_PRO_PWD.Enabled = true;
                    this.JZBX_PWD.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetUnitSBarValue(_UnitProject p_Info)
        {
            bar_txt_gczj.Caption = p_Info.StatusInfo.当前工程总造价.ToString();
            bar_txt_csxmf.Caption = p_Info.StatusInfo.措施项目费.ToString();
            bar_txt_qds.Caption = p_Info.StatusInfo.清单个数.ToString();
            bar_txt_cjs.Caption = p_Info.StatusInfo.工料机数.ToString();
            bar_txt_zms.Caption = p_Info.StatusInfo.子目个数.ToString();
        }

        /// <summary>
        /// 当某个业务成为活动窗体时候
        /// </summary>
        private void DoMdiChildActivate()
        {
            Container form = this.ActiveMdiChild as Container;
            ///更换业务的时候属性赋值
            ActiveWindow.ActiveContainer = form;
            if (form != null)
            {
                this.Text = form.CurrentBusiness.Current.Files.FullName;
                form.OnModelChange(this, form.GetWorkAreas);
                //当前模块名称
                MdiList.Caption = form.Text;
                string sType = string.Empty;
                //模块类型
                switch (form.CurrentBusiness.WorkFlowType)
                {
                    case EWorkFlowType.PROJECT:
                        sType = "项目管理";
                        break;
                    case EWorkFlowType.UnitProject:
                        sType = "单位工程";
                        break;
                    default:

                        break;
                }

                //定额库 清单库配置
                if (form.Activitie != null)
                {
                    Bar_Sub_ListLib.Caption = form.Activitie.Property.Libraries.ListGallery.FullName;
                    Bar_Sub_FixLib.Caption = form.Activitie.Property.Libraries.FixedLibrary.FullName;

                    string ListLib = this.Bar_Sub_ListLib.Caption.ToString();
                    string FixLib = this.Bar_Sub_FixLib.Caption.ToString();
                    if (ListLib != "无")
                    {

                        getStr(this.Bar_Sub_ListLib.Caption.ToString());
                    }
                    if (FixLib != "无")
                    {
                        getStr(this.Bar_Sub_ListLib.Caption.ToString());
                    }
                    //更改库类型的时候  数据库也更改

                }
                else
                {
                    Bar_Sub_ListLib.Caption = Bar_Sub_FixLib.Caption = "无";
                }
            }
            else
            {
                //this.Text = "金建清单计价软件 2013 抢先版";
                this.Text = this.formText;
                MdiList.Caption = string.Empty;
                SetWorkBar();
            }
        }

        /// <summary>
        /// 清单库更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bar_Sub_ListLib_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                if (form.Activitie != null)
                {
                    _LibsForm f = new _LibsForm();
                    //设置当前默认规则
                    f.Library = form.Activitie.Property.Libraries.ListGallery;
                    DialogResult result = f.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        form.Activitie.Property.Libraries.OnLibraryChange(f.Library);
                    }
                }
            }
        }

        /// <summary>
        /// 定额库更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bar_Sub_FixLib_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                if (form.Activitie != null)
                {
                    _LibsForm f = new _LibsForm();
                    //设置当前默认规则
                    f.Library = form.Activitie.Property.Libraries.FixedLibrary;
                    DialogResult result = f.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        form.Activitie.Property.Libraries.OnLibraryChange(f.Library);
                        _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(form.Activitie);
                        m_Methods_ParamsSeting.Init();
                        DataRow[] m_MRGCQF = form.Activitie.StructSource.ModelUnitFee.Select("DEHFW=''");
                        if (m_MRGCQF.Length > 0)
                        {
                            form.Activitie.ProType = m_MRGCQF[0]["GCLB"].ToString();
                        }
                    }
                }
            }
        }


        #endregion

        private void BTN_Fun_Js_ItemClick(object sender, ItemClickEventArgs e)
        {
            //计算统计当前 项目 单位工程数据
            Container form = this.ActiveMdiChild as Container;

            if (form != null)
            {
                form.Calculate();
                ABaseForm f = form.GetWorkAreas;
                if (f != null) f.RefreshDataSource();
            }
        }
        /// <summary>
        /// 大小写转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConvertJE je = new ConvertJE();
            je.ShowDialog();
        }

        /// <summary>
        /// 图元公式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrimitiveFormulaForm form = new PrimitiveFormulaForm();
            form.panelControl1.Visible = false;
            form.Show();
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            AtlasGalleryForm form = new AtlasGalleryForm();
            form.simpleButton1.Enabled = false;
            form.simpleButton2.Enabled = false;

            form.ShowDialog();
        }





        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {

                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            ClearMemory();
        }

        #endregion

        private void Btn_Fun_Log_ItemClick(object sender, ItemClickEventArgs e)
        {
            //打开操作日志
            Container f = this.ActiveMdiChild as Container;
            if (f != null)
            {
                _COBJECTS obj = f.Activitie;
                if (obj != null)
                {
                    f.ALogForm.Show();
                    /*CPwdForm form = new CPwdForm();
                    form.CurrentBusiness = f.CurrentBusiness;
                    form.Source = obj;*/

                }
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Fun_Rec_ItemClick(object sender, ItemClickEventArgs e)
        {
            //打开操作日志
            Container f = this.ActiveMdiChild as Container;
            if (f != null)
            {
                _COBJECTS obj = f.Activitie;
                if (obj != null)
                {
                    f.Revocation();
                    /*CPwdForm form = new CPwdForm();
                    form.CurrentBusiness = f.CurrentBusiness;
                    form.Source = obj;*/

                }
            }
        }



        /// <summary>
        /// 加密狗验证处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            //逻辑变更
            //1.一直扫描加密狗
            //2.如果找到加密狗获取加密狗数据初始化
            //3.否则功能处理
            //4.如果扫描超过20分钟 需要重新调用ALogin
            //5.积分为负数 不能用
            if (APP.GoldSoftClient != null && APP.GoldSoftClient.CurrentCustom != null)
            {
                string wb_web = CSystem.GetAppConfig("wb");
                int jifen = WebServiceHelper.InvokeMethod<int>(wb_web, "getJiFenJL", APP.GoldSoftClient.CurrentCustom.JMLOCK);

                if (jifen < 0)
                {
                    MsgBox.Alert("由于您的积分为负数，软件不能使用！请先购买积分！");
                    System.Environment.Exit(0);
                }

            }

            this.timer2.Stop();

            APP.GoldSoftClient.FirstLogin();

            if (!APP.GoldSoftClient.Can_Use_System)
                System.Environment.Exit(0);


            if (APP.GoldSoftClient.ClientResult.IsLoginSucess)
            {
                APP.GoldSoftClient.GlodSoftDiscern.TryCount = 2;
                //如果更换了加密狗 或者 没有加密狗的情况
                if (APP.GoldSoftClient.ClientResult.IsChangeHandle)
                {
                    //重新处理登陆逻辑
                    int result = APP.GoldSoftClient.Login();

                    if (result == ResultConst.SERVER_CUSTOM_NO_INIT && !APP.GoldSoftClient.ClientResult.Custom_IsOwner)
                        System.Environment.Exit(0);

                    //重新记录时间
                    APP.GoldSoftClient.GlodSoftDiscern.SetTagTime();
                    //
                    this.LoadImg();


                }
                //验证加密狗是否需要提交
                if (APP.GoldSoftClient.GlodSoftDiscern.IsAppSubmit)
                {
                    //提交写入数据
                    APP.GoldSoftClient.ALogin();
                    APP.GoldSoftClient.GlodSoftDiscern.SetTagTime();
                }
                if (APP.GoldSoftClient.ClientResult.Custom_CanUse)
                {
                    SetOffLineTime();
                }
                this.InitFunction(APP.GoldSoftClient.ClientResult);
                ////弹出提示
                //if (!APP.GoldSoftClient.ClientResult.Custom_CanUse && APP.countDIV)
                //{
                //    string str = string.Format("{0}", APP.GoldSoftClient.CurrentCustom.REASON);
                //    string sname = string.Format("用户 {0}", APP.GoldSoftClient.CurrentCustom.CUSTOMERNAME);
                //    this.alertControl1.Show(this, sname, str);
                //    APP.countDIV = false;
                //}
            }
            else
            {
                this.InitFunction(APP.GoldSoftClient.ClientResult);
                HandleError();
            }

           // this.timer2.Start();

        }

        /// <summary>
        /// 硬件错误
        /// </summary>
        public void HandleError()
        {
            //没有找到加密狗的情况如果是加密狗
            //如果当前有打开的工程 此处处理
            if (this.MdiChildren.Length > 0)
            {
                if (APP.GoldSoftClient.GlodSoftDiscern.TryCount > 0)
                {
                    string str = string.Format("对不起，加密狗工作异常请检查是否连接正常!\n 重试次数：{0}", APP.GoldSoftClient.GlodSoftDiscern.TryCount);
                    DialogResult result = MsgBox.Show(str, MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        //重新验证
                        APP.GoldSoftClient.GlodSoftDiscern.TryCount--;
                        return;
                    }
                }

                //提示操作重新插入加密锁否则退出到地图界面
                foreach (Container from in this.MdiChildren)
                {
                    //from.IsAppClose = true;
                    //from.Close();
                }

            }
        }

        /// <summary>
        /// 设置剩余时间
        /// </summary>
        private void SetOffLineTime()
        {
            //计算次数
            decimal a = (1 - decimal.Parse(APP.GoldSoftClient.ClientResult.UseCount.ToString()) / decimal.Parse(GoldSoftClient.MaxCount.ToString())) * 100;
            decimal b = (1 - decimal.Parse(APP.GoldSoftClient.ClientResult.DateCount.ToString()) / decimal.Parse(GoldSoftClient.MaxTimeCount.ToString())) * 100;
            //计算时间次数
            if (a == b || a < b)
            {
                repositoryItemProgressBar1.Maximum = GoldSoftClient.MaxCount;
                //repositoryItemProgressBar1 = GoldSoftClient.MaxCount - APP.GoldSoftClient.ClientResult.UseCount;
                this.barEditItem2.EditValue = GoldSoftClient.MaxCount - APP.GoldSoftClient.ClientResult.UseCount;
            }
            else
            {
                repositoryItemProgressBar1.Maximum = GoldSoftClient.MaxTimeCount;
                this.barEditItem2.EditValue = GoldSoftClient.MaxTimeCount - APP.GoldSoftClient.ClientResult.DateCount;
            }

            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            args.Title.Text = "离线剩余";
            args.Contents.Text = string.Format("已经使用次数: {0} 次   ，可使用次数 {1} 次 \r\n ", APP.GoldSoftClient.ClientResult.UseCount, GoldSoftClient.MaxCount);
            args.Contents.Text += string.Format("已经使用时间约: {0} 分钟 ，已经使用约   {1} 分钟 ", APP.GoldSoftClient.ClientResult.DateCount * 20, GoldSoftClient.MaxTimeCount * 20);
            args.Footer.Text = "亲，根据您的时间，请及时进行网络验证，我们会帮您积分哦！";
            this.barEditItem2.SuperTip.Setup(args);
        }

        /// <summary>
        /// 我的信息
        /// </summary>
        /// <param name="sender">我的资料</param>
        /// <param name="e"></param>
        private void BTN_NET_MyInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (APP.GoldSoftClient.ClientResult.IsUseNet)
            {
                CustomUpdtForm form = new CustomUpdtForm(true);
                form.simpleButton1.Visible = false;
                form.simpleButton2.Visible = false;
                form.txt_ADDRESS.Enabled = false;
                form.txt_CUSTOMERNAME.Enabled = false;
                form.txt_POSTCODE.Enabled = false;
                form.txt_PROFESSION.Enabled = false;
                form.txt_QQ.Enabled = false;
                form.txt_TEL.Enabled = false;
                form.txt_ZCDWNAME.Enabled = false;
                form.txtXingZhi.Enabled = false;
                form.txtMovTel.Enabled = false;
                form.textEdit3.Enabled = false;
                form.textEdit6.Enabled = false;

                form.cbx_AREA.Enabled = false;
                form.cbx_CITY.Enabled = false;
                form.cbx_PROVINCE.Enabled = false;

                form.rd_man.Enabled = false;
                form.rd_wman.Enabled = false;

                form.rd_y_bcde.Enabled = false;
                form.rd_no_bcde.Enabled = false;

                form.rd_y_yhcl.Enabled = false;
                form.rd_no_yhcl.Enabled = false;

                form.rd_y_zjfa.Enabled = false;
                form.rd_no_zjfa.Enabled = false;

                form.rdo_use_person.Enabled = false;
                form.rdo_use_unit.Enabled = false;

                form.ShowDialog(this);
            }

        }
        /// <summary>
        /// 资料修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnupdateInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (APP.GoldSoftClient.ClientResult.IsUseNet)
            {
                CustomUpdtForm form = new CustomUpdtForm(true);
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_SAVEALL_ItemClick(object sender, ItemClickEventArgs e)
        {
            //找到所有的子窗体提调用保存
            Container f = null;
            try
            {
                foreach (Form from in this.MdiChildren)
                {
                    f = from as Container;
                    if (f != null)
                    {
                        f.Save();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败，请重新保存!", "金建软件");
            }
        }

        private void BTN_SET_CONFIG_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConfigForm form = new ConfigForm();
            form.Configuration = APP.Application.Global.Configuration;
            form.Bind();
            DialogResult result = form.ShowDialog();

        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            SpecialString form = new SpecialString();
            form.Show();
        }


        /// <summary>
        /// 工程设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                ProSetting m_ProSetting = new ProSetting();
                m_ProSetting.Activitie = form.Activitie;
                m_ProSetting.CurrentBusiness = form.CurrentBusiness;
                m_ProSetting.ShowDialog();
            }
        }

        /// <summary>
        /// 工程说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProExplain from = new ProExplain();
            if (APP.Application.Global.DataTamp.工程说明表 == null || APP.Application.Global.DataTamp.工程说明表.Tables.Count < 1)
                APP.Application.Global.DataTamp.工程说明表 = APP.GoldSoftClient.GetServiceData("工程说明");
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                from.Activitie = form.Activitie;
                from.CurrentBusiness = form.CurrentBusiness;
            }
            from.ShowDialog();
        }

        /// <summary>
        /// 打开工程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (APP.GcxxKH)
            {
                MsgBox.Alert("工程信息窗口已经打开");
                return;
            }
            from = new ProInformation(false);//InformationType
            Container form = this.ActiveMdiChild as Container;

            if (form == null || form.Activitie == null)
            {
                MsgBox.Alert("请先新建或打开一个单位工程！");
                return;
            }

            this.openFileDialog1.Title = "打开工程信息文件";
            this.openFileDialog1.Filter = "工程信息(*.GCXX)|*.GCXX";
            this.openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = "";
                path += Path.GetDirectoryName(this.openFileDialog1.FileName) + "\\";//得到路径
                path += Path.GetFileName(this.openFileDialog1.FileName);//得到文件名
                if (File.Exists(path))
                {
                    _UnInformation obj = (_UnInformation)GOLDSOFT.QDJJ.COMMONS.CFiles.Deserialize(path);
                    if (obj != null)
                    {
                        APP.UnInformation = obj;
                        //ProInformation from = new ProInformation(false);//InformationType
                        //Container form = this.ActiveMdiChild as Container;

                        if (form != null)
                        {
                            from.Activitie = form.Activitie;
                            from.CurrentBusiness = form.CurrentBusiness;
                        }
                        APP.GcxxKH = true;
                        from.Show();
                    }
                }

            }
        }
        /// <summary>
        /// 新建工程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem35_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (APP.GcxxKH)
            {
                MsgBox.Alert("当前已有打开的工程信息窗口，请关闭后在进行其他操作！");
            }
            else
            {
                //from = new ProInformation(true);

                //Container form = this.ActiveMdiChild as Container;

                switch (e.Item.Caption)
                {
                    case "建筑装饰":
                        APP.UnInformation.InformationType = InformationType.建筑装饰;
                        break;
                    case "给排雨水":
                        APP.UnInformation.InformationType = InformationType.给排水雨水;
                        break;
                    case "采暖热源":
                        APP.UnInformation.InformationType = InformationType.采暖热源;
                        break;
                    case "燃气管道":
                        APP.UnInformation.InformationType = InformationType.燃气管道;
                        break;
                    case "工业管道":
                        APP.UnInformation.InformationType = InformationType.工业管道;
                        break;
                    case "水灭火":
                        APP.UnInformation.InformationType = InformationType.水灭火;
                        break;
                    case "气体灭火":
                        APP.UnInformation.InformationType = InformationType.气体灭火;
                        break;
                    case "泡沫灭火":
                        APP.UnInformation.InformationType = InformationType.泡沫灭火;
                        break;
                    case "消火栓":
                        APP.UnInformation.InformationType = InformationType.消火栓;
                        break;
                    case "火灾报警":
                        APP.UnInformation.InformationType = InformationType.火灾报警;
                        break;
                    case "通风空调":
                        APP.UnInformation.InformationType = InformationType.通风空调;
                        break;
                    case "电气设备":
                        APP.UnInformation.InformationType = InformationType.电气设备;
                        break;
                    case "智能综合":
                        APP.UnInformation.InformationType = InformationType.智能综合;
                        break;
                }
                from = new ProInformation(true);
                Container form = this.ActiveMdiChild as Container;
                if (form == null || form.Activitie == null)
                {
                    MsgBox.Alert("请先新建或打开一个单位工程！");
                    return;
                }

                if (form != null)
                {
                    from.Activitie = form.Activitie;
                    from.CurrentBusiness = form.CurrentBusiness;
                }
                APP.GcxxKH = true;
                from.Show();
                //DialogResult diares = from.ShowDialog();
                //if (diares == DialogResult.Cancel)
                //{
                //    barButtonItem61.PerformClick();
                //}
            }






        }

        /// <summary>
        /// 价格维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            ManagementQuantityUnit m_ProSetting = new ManagementQuantityUnit();
            m_ProSetting.ShowDialog();
        }

        /// <summary>
        /// 新项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_NEW_Project_ItemClick(object sender, ItemClickEventArgs e)
        {

            _Profession m_Pro = new _Profession();

            m_Pro.Files = new _Files();
            m_Pro.CommandName = "1";
            //设置工作目录
            APP.Application.Global.WorkFolder = new System.IO.DirectoryInfo(APP.Application.Global.AppFolder + "工程文件");
            m_Pro.Files.ExtName = _Files.ProjectExName;
            m_Pro.Files.DirName = APP.Application.Global.WorkFolder.FullName;
            //m_Pro.Files.FileName = textEdit2.Text.Trim();

            this.ActionFace.ShowNewAction(m_Pro);
        }

        /// <summary>
        /// 新工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_APP_NEW_Unit_ItemClick(object sender, ItemClickEventArgs e)
        {
            _Profession m_Pro = new _Profession();

            m_Pro.Files = new _Files();
            m_Pro.CommandName = "3";
            //设置工作目录
            APP.Application.Global.WorkFolder = new System.IO.DirectoryInfo(APP.Application.Global.AppFolder + "工程文件");
            m_Pro.Files.ExtName = _Files.CUnitProjectExName;
            m_Pro.Files.DirName = APP.Application.Global.WorkFolder.FullName;
            //m_Pro.Files.FileName = textEdit2.Text.Trim();

            this.ActionFace.ShowNewAction(m_Pro);
        }
        /// <summary>
        /// 操作手册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //this.Start("操作手册.doc");
            switch (APP.GoldSoftClient.ClientResult.Fun)
            {
                case 1:
                    this.Start("清单计价2013专业版操作说明.doc");
                    break;
                case 2:
                    this.Start("清单计价2013旗舰版操作说明.doc");
                    break;
                case 3:
                    this.Start("清单计价2013专业版操作说明.doc");
                    break;
                default:
                    this.Start("清单计价2013领先版操作说明.doc");
                    break;
            }
        }
        /// <summary>
        /// 清单帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            this.Start("清单帮助.doc");
        }
        /// <summary>
        /// 定额帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDE_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Start("定额帮助.chm");

        }
        /// <summary>
        /// 常见问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Start("常见问题解答.doc");
        }
        private void Start(string path)
        {
            string dir = APP.Application.Global.AppFolder + "帮助文档\\";
            path = dir + path;
            if (!File.Exists(path))
            {
                MsgBox.Show("文件不存在", MessageBoxButtons.OK);
                return;
            }
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = path;

            Process.Start(info);

        }

        /// <summary>
        /// 更新云价格库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (APP.GXKG)
            {
                InformationSelect m_InformationSelect = new InformationSelect();
                m_InformationSelect.Show();
            }
            else
            {
                MsgBox.Alert("请您先到修改资料中，共享用户材料价格存储与引用方式！");
            }

        }
        /// <summary>
        ///查看版本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            BBMessageForm bbMessager = new BBMessageForm();
            bbMessager.Show();
        }

        private void barCheckItemInvite_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (barCheckItemInvite.Checked)
            {
                barCheckItemPublish.Checked = false;
                this.ribbonPageGroup19.Visible = false;
                APP.GoldSoftClient.Invite_Publish = false;//邀请招标
            }
        }

        private void barCheckItemPublish_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (barCheckItemPublish.Checked)
            {
                barCheckItemInvite.Checked = false;
                this.ribbonPageGroup19.Visible = true;
                APP.GoldSoftClient.Invite_Publish = true;//公开招标
            }
        }

        private void barCount1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount1.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 1;

            }
        }

        private void barCount2_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount2.Checked)
            {
                this.barCount1.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 2;

            }
        }

        private void barCount3_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount3.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount1.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 3;

            }
        }

        private void barCount4_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount4.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount1.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 4;

            }
        }

        private void barCount5_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount5.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount1.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 5;

            }
        }

        private void barCount6_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount6.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount1.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 6;

            }
        }

        private void barCount7_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount7.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount1.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 7;

            }
        }

        private void barCount8_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount8.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount1.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 8;

            }
        }

        private void barCount9_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (this.barCount9.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount1.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 9;

            }
        }
        private void barCount10_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount10.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount1.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 10;

            }
        }

        private void barCount11_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount11.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount1.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 11;

            }
        }

        private void barCount12_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount12.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount1.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 12;

            }
        }

        private void barCount13_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount13.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount1.Checked = false;
                this.barCount14.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 13;

            }
        }

        private void barCount14_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount14.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount1.Checked = false;
                this.barCount15.Checked = false;
                APP.GoldSoftClient.Other_Count = 14;

            }
        }

        private void barCount15_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barCount15.Checked)
            {
                this.barCount2.Checked = false;
                this.barCount3.Checked = false;
                this.barCount4.Checked = false;
                this.barCount5.Checked = false;
                this.barCount6.Checked = false;
                this.barCount7.Checked = false;
                this.barCount8.Checked = false;
                this.barCount9.Checked = false;
                this.barCount10.Checked = false;
                this.barCount11.Checked = false;
                this.barCount12.Checked = false;
                this.barCount13.Checked = false;
                this.barCount14.Checked = false;
                this.barCount1.Checked = false;
                APP.GoldSoftClient.Other_Count = 15;

            }
        }
        //private void barMyCount1_CheckedChanged(object sender, ItemClickEventArgs e)
        //{
        //    if (this.barMyCount1.Checked)
        //    {
        //        this.barMyCount2.Checked = false;
        //        this.barMyCount3.Checked = false;
        //        this.barMyCount4.Checked = false;
        //        this.barMyCount5.Checked = false;
        //        this.barMyCount6.Checked = false;
        //        this.barMyCount7.Checked = false;
        //        this.barMyCount8.Checked = false;
        //        this.barMyCount9.Checked = false;
        //        this.barMyCount10.Checked = false;
        //        this.barMyCount11.Checked = false;
        //        this.barMyCount12.Checked = false;

        //    }
        //}

        //private void barMyCount2_CheckedChanged(object sender, ItemClickEventArgs e)
        //{
        //    if (this.barMyCount2.Checked)
        //    {
        //        this.barMyCount1.Checked = false;
        //        this.barMyCount3.Checked = false;
        //        this.barMyCount4.Checked = false;
        //        this.barMyCount5.Checked = false;
        //        this.barMyCount6.Checked = false;
        //        this.barMyCount7.Checked = false;
        //        this.barMyCount8.Checked = false;
        //        this.barMyCount9.Checked = false;
        //        this.barMyCount10.Checked = false;
        //        this.barMyCount11.Checked = false;
        //        this.barMyCount12.Checked = false;

        //    }
        //}

        private void barMyCount3_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount3.Checked)
            {
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 3;

            }
        }

        private void barMyCount4_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount4.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 4;
            }
        }

        private void barMyCount5_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount5.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 5;
            }
        }

        private void barMyCount6_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount6.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 6;
            }
        }

        private void barMyCount7_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount7.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 7;
            }
        }

        private void barMyCount8_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount8.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 8;
            }
        }

        private void barMyCount9_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount9.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 9;
            }
        }

        private void barMyCount10_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount10.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount11.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 10;
            }
        }

        private void barMyCount11_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount11.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount12.Checked = false;
                APP.GoldSoftClient.My_Count = 11;
            }
        }

        private void barMyCount12_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (this.barMyCount12.Checked)
            {
                this.barMyCount3.Checked = false;
                this.barMyCount4.Checked = false;
                this.barMyCount5.Checked = false;
                this.barMyCount6.Checked = false;
                this.barMyCount7.Checked = false;
                this.barMyCount8.Checked = false;
                this.barMyCount9.Checked = false;
                this.barMyCount10.Checked = false;
                this.barMyCount11.Checked = false;
                APP.GoldSoftClient.My_Count = 12;
            }
        }

        private void btnzbBeginAnalyze_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form == null || form.CurrentBusiness == null || form.CurrentBusiness.Current == null)
            {
                MsgBox.Alert("请先打开一个至少包含一个单位工程的项目文件!");
                return;
            }
            SubSegmentForm obj = form.GetWorkAreas as SubSegmentForm;

            if (obj == null || obj.Activitie == null)
            {
                MsgBox.Alert("请先打开一个单位工程文件！");
                return;
            }

            BeginAnalyze begin = new BeginAnalyze();
            begin.MdiParent = this;
            begin._sender = form;
            begin.pInfo = form.CurrentBusiness;
            ArrayList list = new ArrayList();
            APP.GoldSoftClient.curBusiness = form.CurrentBusiness;
            list.Add(form.CurrentBusiness.Current);
            begin.DataSource = list;
            begin.ShowDialog();
        }

        private void btnzbOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form == null || form.CurrentBusiness == null || form.CurrentBusiness.Current == null)
            {
                MsgBox.Alert("请先打开一个至少包含一个单位工程的项目文件!");
                return;
            }
            SubSegmentForm obj = form.GetWorkAreas as SubSegmentForm;

            if (obj == null || obj.Activitie == null)
            {
                MsgBox.Alert("请先打开一个单位工程文件！");
                return;
            }
            this.ActionFace.OpenTBBS();
            if (APP.GoldSoftClient.TB_RESULT != null && APP.GoldSoftClient.TB_RESULT.Rows.Count > 0)
            {
                BeginAnalyze4 begin4 = new BeginAnalyze4();
                begin4.MdiParent = this;
                begin4._sender = form;
                begin4.ShowDialog();
            }
        }

        private void barCheckItemInvite_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barCheckItemPublish_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnqjApplyBegin_ItemClick(object sender, ItemClickEventArgs e)
        {
            MsgBox.Alert("该功能正在开发中，敬请期待！");
        }

        private void btnqjFlag_ItemClick(object sender, ItemClickEventArgs e)
        {
            Container form = this.ActiveMdiChild as Container;
            if (form == null || form.CurrentBusiness == null || form.CurrentBusiness.Current == null)
            {
                MsgBox.Alert("请先打开一个至少包含一个单位工程的项目文件!");
                return;
            }
            SubSegmentForm obj = form.GetWorkAreas as SubSegmentForm;

            if (obj == null || obj.Activitie == null)
            {
                MsgBox.Alert("请先打开一个单位工程文件！");
                return;
            }

            //TODO标识开始

            //TODO Step1 先检查备注，如果没有则按规则添加
            //检查备注，如果为空或不符合规则，则重新生成备注
            string strTJ = "";
            DataRow[] rowZM, rowGLJ;
            StringBuilder sb = new StringBuilder();
            int qdID = 0;
            bool returnFlag = false;
            for (int i = 0; i < obj.Activitie.StructSource.ModelSubSegments.Rows.Count; i++)
            {
                if (obj.Activitie.StructSource.ModelSubSegments.Rows[i]["LB"].ToString().Equals("清单") &&
                    obj.Activitie.StructSource.ModelSubSegments.Rows[i]["BEIZHU"].ToString().IndexOf("@") <= 0)
                {
                    sb.Remove(0, sb.Length);
                    strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    qdID = int.Parse(obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ID"].ToString());
                    //该清单的子目
                    rowZM = obj.Activitie.StructSource.ModelSubSegments.Select("PID = " + qdID);
                    foreach (DataRow zm in rowZM)
                    {
                        if (!zm["XMBM"].ToString().Contains("换"))
                            sb.Append(string.Format("{0},{1},{2},{3}|", zm["XMBM"], zm["GCL"], "", ""));
                        else
                        {
                            rowGLJ = obj.Activitie.StructSource.ModelQuantity.Select("QDID = " + qdID.ToString() + " and ZMID = " + zm["ID"].ToString());

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
                        obj.Activitie.StructSource.ModelSubSegments.Rows[i]["BEIZHU"] = sb.ToString() + strTJ + "@" + obj.Activitie.StructSource.ModelSubSegments.Rows[i]["BEIZHU"].ToString();

                    //在此处同时开始旗舰标识
                    if (applayFlag == 1) //应用到当前清单
                    {
                        // TreeListNode[] nodes = this.treeList1.Selection.Cast<TreeListNode>().OrderByDescending(p => p.Level).OrderByDescending(p => p.Id).ToArray();
                        ////foreach (TreeListNode item in nodes)
                        ////{
                        // for (int m = 0; m < nodes.Length; m++)
                        // {
                        //     string bh = nodes[m].GetValue(0).ToString();
                        // }

                    }
                    else if (applayFlag == 2) //应用到未组价清单
                    {
                    }
                    else if (applayFlag == 3) //应用到所有清单
                    {

                    }

                }
            }

            //TODO Step2 开始标识


        }
        int applayFlag = -1;//1:Current 2:Not   3:All
        private void btnqjApplyCurrent_ItemClick(object sender, ItemClickEventArgs e)
        {
            applayFlag = 1;
            btnqjApplyNot.Checked = false;
            btnqjApplyAll.Checked = false;
        }

        private void btnqjApplyNot_ItemClick(object sender, ItemClickEventArgs e)
        {
            applayFlag = 2;
            btnqjApplyCurrent.Checked = false;
            btnqjApplyAll.Checked = false;
        }

        private void btnqjApplyAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            applayFlag = 3;
            btnqjApplyCurrent.Checked = false;
            btnqjApplyNot.Checked = false;
        }
    }
}