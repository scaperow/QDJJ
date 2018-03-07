using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils;
using System.Drawing;
using System.Windows.Forms;
namespace GOLDSOFT.QDJJ.UI
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup7 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup8 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem2 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.BTN_APP_NEW = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_APP_OPEN = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_APP_SAVE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_APP_SAVEAS = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_APP_CLOSE = new DevExpress.XtraBars.BarButtonItem();
            this.pccAppMenu = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pcAppMenuFileLabels = new DevExpress.XtraEditors.PanelControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_TOOLS_CALC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem21 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem24 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem26 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.BBI_ImportIn = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_ImportOut = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem28 = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_APP_SAVEALL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem30 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem34 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem36 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem37 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem38 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem40 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem41 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem42 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem43 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem44 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem45 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem49 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem55 = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_SYS_COLOR = new DevExpress.XtraBars.BarButtonItem();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.BTN_SET_PRO_PWD = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_SET_UN_PWD = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_Win_Default = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_Win_SP = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_Win_FL = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_Win_Cas = new DevExpress.XtraBars.BarButtonItem();
            this.MdiList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
            this.Bar_Sub_ListLib = new DevExpress.XtraBars.BarButtonItem();
            this.Bar_Sub_FixLib = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_Fun_Js = new DevExpress.XtraBars.BarButtonItem();
            this.Btn_Fun_Log = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_NET_MyInfo = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_SET_CONFIG = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem31 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem32 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem33 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem35 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem46 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem47 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem48 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem50 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem51 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem52 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem53 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem54 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem56 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem57 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem58 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem59 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem60 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem61 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem62 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem8 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem9 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem10 = new DevExpress.XtraBars.BarStaticItem();
            this.bar_txt_gczj = new DevExpress.XtraBars.BarStaticItem();
            this.bar_txt_csxmf = new DevExpress.XtraBars.BarStaticItem();
            this.bar_txt_qds = new DevExpress.XtraBars.BarStaticItem();
            this.bar_txt_zms = new DevExpress.XtraBars.BarStaticItem();
            this.bar_txt_cjs = new DevExpress.XtraBars.BarStaticItem();
            this.BTN_APP_NEW_Project = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_APP_NEW_Unit = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.btnupdateInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnzbOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnzbInvite = new DevExpress.XtraBars.BarButtonItem();
            this.btnzbPublish = new DevExpress.XtraBars.BarButtonItem();
            this.btnzbCount = new DevExpress.XtraBars.BarButtonItem();
            this.btnzbMyCount = new DevExpress.XtraBars.BarButtonItem();
            this.btnzbBeginAnalyze = new DevExpress.XtraBars.BarButtonItem();
            this.btnqjFlag = new DevExpress.XtraBars.BarButtonItem();
            this.btnqjApplyCurrent = new DevExpress.XtraBars.BarCheckItem();
            this.btnqjApplyNot = new DevExpress.XtraBars.BarCheckItem();
            this.btnqjApplyAll = new DevExpress.XtraBars.BarCheckItem();
            this.btnqjApplyBegin = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.JZBX_PWD = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barCheckItemInvite = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barCheckItemPublish = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageGroup19 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barCount1 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount2 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount3 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount4 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount5 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount6 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount7 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount8 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount9 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount10 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount11 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount12 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount13 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount14 = new DevExpress.XtraBars.BarCheckItem();
            this.barCount15 = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageGroup20 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barMyCount3 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount4 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount5 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount6 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount7 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount8 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount9 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount10 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount11 = new DevExpress.XtraBars.BarCheckItem();
            this.barMyCount12 = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageGroup21 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage8 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup22 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup23 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup24 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup25 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup26 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage6 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem29 = new DevExpress.XtraBars.BarButtonItem();
            this.DefaultSBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.UnitSBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ProjSBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.pmAppMain = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.idNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.barButtonItem39 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccAppMenu)).BeginInit();
            this.pccAppMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcAppMenuFileLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationIcon = global::GOLDSOFT.QDJJ.UI.Properties.Resources._123;
            this.ribbon.BackColor = System.Drawing.Color.White;
            this.ribbon.Images = this.imageCollection1;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BTN_APP_NEW,
            this.BTN_APP_OPEN,
            this.BTN_APP_CLOSE,
            this.BTN_APP_SAVE,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.barButtonItem12,
            this.barButtonItem13,
            this.barButtonItem14,
            this.BTN_TOOLS_CALC,
            this.barButtonItem16,
            this.barButtonItem17,
            this.barButtonItem18,
            this.barButtonItem19,
            this.barButtonItem20,
            this.barButtonItem21,
            this.barButtonItem22,
            this.barButtonItem23,
            this.barButtonItem24,
            this.barButtonItem25,
            this.barButtonItem26,
            this.barButtonItem27,
            this.barEditItem1,
            this.barCheckItem1,
            this.barSubItem1,
            this.BBI_ImportIn,
            this.BBI_ImportOut,
            this.barCheckItem2,
            this.barButtonItem28,
            this.BTN_APP_SAVEALL,
            this.BTN_APP_SAVEAS,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem30,
            this.barButtonItem34,
            this.barButtonItem36,
            this.barButtonItem37,
            this.barButtonItem38,
            this.barButtonItem40,
            this.barButtonItem41,
            this.barButtonItem42,
            this.barButtonItem43,
            this.barButtonItem44,
            this.barButtonItem45,
            this.barButtonItem49,
            this.barButtonItem55,
            this.BTN_SYS_COLOR,
            this.rgbiSkins,
            this.BTN_SET_PRO_PWD,
            this.BTN_SET_UN_PWD,
            this.BTN_Win_Default,
            this.BTN_Win_SP,
            this.BTN_Win_FL,
            this.BTN_Win_Cas,
            this.MdiList,
            this.barStaticItem1,
            this.barStaticItem5,
            this.barStaticItem6,
            this.Bar_Sub_ListLib,
            this.Bar_Sub_FixLib,
            this.BTN_Fun_Js,
            this.Btn_Fun_Log,
            this.BTN_NET_MyInfo,
            this.BTN_SET_CONFIG,
            this.barButtonItem5,
            this.barButtonGroup1,
            this.barButtonItem15,
            this.barButtonItem31,
            this.barButtonItem32,
            this.barButtonItem33,
            this.barButtonItem35,
            this.barButtonItem46,
            this.barButtonItem47,
            this.barButtonItem48,
            this.barButtonItem50,
            this.barButtonItem51,
            this.barButtonItem52,
            this.barButtonItem53,
            this.barButtonItem54,
            this.barButtonItem56,
            this.barButtonItem57,
            this.barButtonItem58,
            this.barButtonItem59,
            this.barButtonItem60,
            this.barButtonItem61,
            this.barButtonItem62,
            this.barStaticItem4,
            this.barStaticItem3,
            this.barStaticItem7,
            this.barStaticItem8,
            this.barStaticItem9,
            this.barStaticItem10,
            this.bar_txt_gczj,
            this.bar_txt_csxmf,
            this.bar_txt_qds,
            this.bar_txt_zms,
            this.bar_txt_cjs,
            this.BTN_APP_NEW_Project,
            this.BTN_APP_NEW_Unit,
            this.barEditItem2,
            this.btnupdateInfo,
            this.btnzbOpen,
            this.btnzbInvite,
            this.btnzbPublish,
            this.btnzbCount,
            this.btnzbMyCount,
            this.btnzbBeginAnalyze,
            this.btnqjFlag,
            this.btnqjApplyCurrent,
            this.btnqjApplyNot,
            this.btnqjApplyAll,
            this.btnqjApplyBegin});
            this.ribbon.LargeImages = this.imageCollection1;
            resources.ApplyResources(this.ribbon, "ribbon");
            this.ribbon.MaxItemId = 164;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage7,
            //this.ribbonPage8,
            this.ribbonPage3,
            this.ribbonPage6});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemProgressBar1});
            this.ribbon.SelectedPage = this.ribbonPage8;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.StatusBar = this.ProjSBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_APP_NEW);
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_APP_OPEN);
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_APP_SAVE);
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_APP_CLOSE);
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_SET_CONFIG);
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_Fun_Js);
            this.ribbon.Toolbar.ItemLinks.Add(this.BTN_NET_MyInfo);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.BottomPaneControlContainer = null;
            this.applicationMenu1.ItemLinks.Add(this.BTN_APP_NEW);
            this.applicationMenu1.ItemLinks.Add(this.BTN_APP_OPEN);
            this.applicationMenu1.ItemLinks.Add(this.BTN_APP_SAVE, true);
            this.applicationMenu1.ItemLinks.Add(this.BTN_APP_SAVEAS);
            this.applicationMenu1.ItemLinks.Add(this.BTN_APP_CLOSE, true);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            this.applicationMenu1.RightPaneControlContainer = this.pccAppMenu;
            this.applicationMenu1.ShowRightPane = true;
            this.applicationMenu1.Popup += new System.EventHandler(this.applicationMenu1_Popup);
            // 
            // BTN_APP_NEW
            // 
            resources.ApplyResources(this.BTN_APP_NEW, "BTN_APP_NEW");
            this.BTN_APP_NEW.Id = 1;
            this.BTN_APP_NEW.ImageIndex = 17;
            this.BTN_APP_NEW.LargeImageIndex = 17;
            this.BTN_APP_NEW.Name = "BTN_APP_NEW";
            this.BTN_APP_NEW.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_NEW_ItemClick);
            // 
            // BTN_APP_OPEN
            // 
            resources.ApplyResources(this.BTN_APP_OPEN, "BTN_APP_OPEN");
            this.BTN_APP_OPEN.Id = 2;
            this.BTN_APP_OPEN.ImageIndex = 2;
            this.BTN_APP_OPEN.LargeImageIndex = 2;
            this.BTN_APP_OPEN.Name = "BTN_APP_OPEN";
            this.BTN_APP_OPEN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_OPEN_ItemClick);
            // 
            // BTN_APP_SAVE
            // 
            resources.ApplyResources(this.BTN_APP_SAVE, "BTN_APP_SAVE");
            this.BTN_APP_SAVE.Id = 8;
            this.BTN_APP_SAVE.ImageIndex = 0;
            this.BTN_APP_SAVE.LargeImageIndex = 0;
            this.BTN_APP_SAVE.Name = "BTN_APP_SAVE";
            this.BTN_APP_SAVE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_SAVE_ItemClick);
            // 
            // BTN_APP_SAVEAS
            // 
            resources.ApplyResources(this.BTN_APP_SAVEAS, "BTN_APP_SAVEAS");
            this.BTN_APP_SAVEAS.Id = 44;
            this.BTN_APP_SAVEAS.ImageIndex = 14;
            this.BTN_APP_SAVEAS.LargeImageIndex = 14;
            this.BTN_APP_SAVEAS.Name = "BTN_APP_SAVEAS";
            this.BTN_APP_SAVEAS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_SAVEAS_ItemClick);
            // 
            // BTN_APP_CLOSE
            // 
            resources.ApplyResources(this.BTN_APP_CLOSE, "BTN_APP_CLOSE");
            this.BTN_APP_CLOSE.Id = 3;
            this.BTN_APP_CLOSE.ImageIndex = 12;
            this.BTN_APP_CLOSE.LargeImageIndex = 12;
            this.BTN_APP_CLOSE.Name = "BTN_APP_CLOSE";
            this.BTN_APP_CLOSE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_CLOSE_ItemClick);
            // 
            // pccAppMenu
            // 
            this.pccAppMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pccAppMenu.Controls.Add(this.labelControl1);
            this.pccAppMenu.Controls.Add(this.pcAppMenuFileLabels);
            resources.ApplyResources(this.pccAppMenu, "pccAppMenu");
            this.pccAppMenu.Name = "pccAppMenu";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Name = "labelControl1";
            // 
            // pcAppMenuFileLabels
            // 
            resources.ApplyResources(this.pcAppMenuFileLabels, "pcAppMenuFileLabels");
            this.pcAppMenuFileLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcAppMenuFileLabels.Name = "pcAppMenuFileLabels";
            // 
            // imageCollection1
            // 
            resources.ApplyResources(this.imageCollection1, "imageCollection1");
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\保存编辑.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\操作日志.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\打开.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\单位工程1.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\单项工程.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\导出BD.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\导出JZBX.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\导出TBS.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\导出ZBS.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\导出工程文件.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\导入工程文件.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\工程配置.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\关闭工程.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\计算.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\另存为.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\设置工程密码.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\设置项目密码.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\向导.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\新工程.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxm\\新项目.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\采暖热源.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\电气设备.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\给排水雨水.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\工程设置.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\工程说明.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\工业管道.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\火灾自动报警系统.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\机械设备.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\建筑装饰.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\泡沫灭火系统.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\气体灭火系统.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\燃气管道.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\水灭火系统.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\通风空调工程.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\消火栓.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\智能综合.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gcxx\\综合布线.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\版本.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\操作手册.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\常见问题解答.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\定额帮助.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\更新信息价.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\价格维护.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\清单帮助.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\锁信息.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\我们的资料.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\层叠布局.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\分列布局.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\计算器.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\默认布局.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\配色方案.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\人民币大小写转换.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\水平布局.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\特殊字符1.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\图集查询.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\xtgj\\图元公式.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\edit_user.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\img\\gybz\\identity.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\清单库.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\定额库.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\工程总造价.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\措施项目费.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\清单数.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\子目数.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\人才机数.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\锁.png"));

            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\identity.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\措施项目费.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\buisness.png"));
            this.imageCollection1.Images.Add(Image.FromFile("Resources\\Imgs\\职能综合.png"));

            this.imageCollection1.Images.SetKeyName(0, "保存编辑.png");
            this.imageCollection1.Images.SetKeyName(1, "操作日志.png");
            this.imageCollection1.Images.SetKeyName(2, "打开.png");
            this.imageCollection1.Images.SetKeyName(3, "单位工程1.png");
            this.imageCollection1.Images.SetKeyName(4, "单项工程.png");
            this.imageCollection1.Images.SetKeyName(5, "导出BD.png");
            this.imageCollection1.Images.SetKeyName(6, "导出JZBX.png");
            this.imageCollection1.Images.SetKeyName(7, "导出TBS.png");
            this.imageCollection1.Images.SetKeyName(8, "导出ZBS.png");
            this.imageCollection1.Images.SetKeyName(9, "导出工程文件.png");
            this.imageCollection1.Images.SetKeyName(10, "导入工程文件.png");
            this.imageCollection1.Images.SetKeyName(11, "工程配置.png");
            this.imageCollection1.Images.SetKeyName(12, "关闭工程.png");
            this.imageCollection1.Images.SetKeyName(13, "计算.png");
            this.imageCollection1.Images.SetKeyName(14, "另存为.png");
            this.imageCollection1.Images.SetKeyName(15, "设置工程密码.png");
            this.imageCollection1.Images.SetKeyName(16, "设置项目密码.png");
            this.imageCollection1.Images.SetKeyName(17, "向导.png");
            this.imageCollection1.Images.SetKeyName(18, "新工程.png");
            this.imageCollection1.Images.SetKeyName(19, "新项目.png");
            this.imageCollection1.Images.SetKeyName(20, "采暖热源.png");
            this.imageCollection1.Images.SetKeyName(21, "电气设备.png");
            this.imageCollection1.Images.SetKeyName(22, "给排水雨水.png");
            this.imageCollection1.Images.SetKeyName(23, "工程设置.png");
            this.imageCollection1.Images.SetKeyName(24, "工程说明.png");
            this.imageCollection1.Images.SetKeyName(25, "工业管道.png");
            this.imageCollection1.Images.SetKeyName(26, "火灾自动报警系统.png");
            this.imageCollection1.Images.SetKeyName(27, "机械设备.png");
            this.imageCollection1.Images.SetKeyName(28, "建筑装饰.png");
            this.imageCollection1.Images.SetKeyName(29, "泡沫灭火系统.png");
            this.imageCollection1.Images.SetKeyName(30, "气体灭火系统.png");
            this.imageCollection1.Images.SetKeyName(31, "燃气管道.png");
            this.imageCollection1.Images.SetKeyName(32, "水灭火系统.png");
            this.imageCollection1.Images.SetKeyName(33, "通风空调工程.png");
            this.imageCollection1.Images.SetKeyName(34, "消火栓.png");
            this.imageCollection1.Images.SetKeyName(35, "智能综合.png");
            this.imageCollection1.Images.SetKeyName(36, "综合布线.png");
            this.imageCollection1.Images.SetKeyName(37, "版本.png");
            this.imageCollection1.Images.SetKeyName(38, "操作手册.png");
            this.imageCollection1.Images.SetKeyName(39, "常见问题解答.png");
            this.imageCollection1.Images.SetKeyName(40, "定额帮助.png");
            this.imageCollection1.Images.SetKeyName(41, "更新信息价.png");
            this.imageCollection1.Images.SetKeyName(42, "价格维护.png");
            this.imageCollection1.Images.SetKeyName(43, "清单帮助.png");
            this.imageCollection1.Images.SetKeyName(44, "锁信息.png");
            this.imageCollection1.Images.SetKeyName(45, "我们的资料.png");
            this.imageCollection1.Images.SetKeyName(46, "层叠布局.png");
            this.imageCollection1.Images.SetKeyName(47, "分列布局.png");
            this.imageCollection1.Images.SetKeyName(48, "计算器.png");
            this.imageCollection1.Images.SetKeyName(49, "默认布局.png");
            this.imageCollection1.Images.SetKeyName(50, "配色方案.png");
            this.imageCollection1.Images.SetKeyName(51, "人民币大小写转换.png");
            this.imageCollection1.Images.SetKeyName(52, "水平布局.png");
            this.imageCollection1.Images.SetKeyName(53, "特殊字符1.png");
            this.imageCollection1.Images.SetKeyName(54, "图集查询.png");
            this.imageCollection1.Images.SetKeyName(55, "图元公式.png");
            this.imageCollection1.Images.SetKeyName(56, "edit_user.png");
            this.imageCollection1.Images.SetKeyName(57, "identity.png");
            this.imageCollection1.Images.SetKeyName(58, "清单库.png");
            this.imageCollection1.Images.SetKeyName(59, "定额库.png");
            this.imageCollection1.Images.SetKeyName(60, "工程总造价.png");
            this.imageCollection1.Images.SetKeyName(61, "措施项目费.png");
            this.imageCollection1.Images.SetKeyName(62, "清单数.png");
            this.imageCollection1.Images.SetKeyName(63, "子目数.png");
            this.imageCollection1.Images.SetKeyName(64, "人才机数.png");
            this.imageCollection1.Images.SetKeyName(65, "锁.png");
            this.imageCollection1.Images.SetKeyName(66, "identity.png");
            this.imageCollection1.Images.SetKeyName(67, "措施项目费.png");
            this.imageCollection1.Images.SetKeyName(68, "职能综合.png");
            // 
            // barButtonItem6
            // 
            resources.ApplyResources(this.barButtonItem6, "barButtonItem6");
            this.barButtonItem6.Id = 9;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            resources.ApplyResources(this.barButtonItem7, "barButtonItem7");
            this.barButtonItem7.Id = 10;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            resources.ApplyResources(this.barButtonItem8, "barButtonItem8");
            this.barButtonItem8.Id = 11;
            this.barButtonItem8.ImageIndex = 10;
            this.barButtonItem8.LargeImageIndex = 10;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem9
            // 
            resources.ApplyResources(this.barButtonItem9, "barButtonItem9");
            this.barButtonItem9.Id = 12;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            resources.ApplyResources(this.barButtonItem10, "barButtonItem10");
            this.barButtonItem10.Id = 13;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // barButtonItem11
            // 
            resources.ApplyResources(this.barButtonItem11, "barButtonItem11");
            this.barButtonItem11.Id = 14;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barButtonItem12
            // 
            resources.ApplyResources(this.barButtonItem12, "barButtonItem12");
            this.barButtonItem12.Id = 15;
            this.barButtonItem12.ImageIndex = 8;
            this.barButtonItem12.LargeImageIndex = 8;
            this.barButtonItem12.Name = "barButtonItem12";
            this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem12_ItemClick);
            // 
            // barButtonItem13
            // 
            resources.ApplyResources(this.barButtonItem13, "barButtonItem13");
            this.barButtonItem13.Id = 16;
            this.barButtonItem13.ImageIndex = 7;
            this.barButtonItem13.LargeImageIndex = 7;
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // barButtonItem14
            // 
            resources.ApplyResources(this.barButtonItem14, "barButtonItem14");
            this.barButtonItem14.Id = 17;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // BTN_TOOLS_CALC
            // 
            resources.ApplyResources(this.BTN_TOOLS_CALC, "BTN_TOOLS_CALC");
            this.BTN_TOOLS_CALC.Id = 18;
            this.BTN_TOOLS_CALC.ImageIndex = 48;
            this.BTN_TOOLS_CALC.LargeImageIndex = 48;
            this.BTN_TOOLS_CALC.Name = "BTN_TOOLS_CALC";
            this.BTN_TOOLS_CALC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_TOOLS_CALC_ItemClick);
            // 
            // barButtonItem16
            // 
            resources.ApplyResources(this.barButtonItem16, "barButtonItem16");
            this.barButtonItem16.Id = 19;
            this.barButtonItem16.ImageIndex = 51;
            this.barButtonItem16.LargeImageIndex = 51;
            this.barButtonItem16.Name = "barButtonItem16";
            this.barButtonItem16.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem16_ItemClick);
            // 
            // barButtonItem17
            // 
            resources.ApplyResources(this.barButtonItem17, "barButtonItem17");
            this.barButtonItem17.Id = 20;
            this.barButtonItem17.Name = "barButtonItem17";
            // 
            // barButtonItem18
            // 
            resources.ApplyResources(this.barButtonItem18, "barButtonItem18");
            this.barButtonItem18.Id = 21;
            this.barButtonItem18.Name = "barButtonItem18";
            // 
            // barButtonItem19
            // 
            resources.ApplyResources(this.barButtonItem19, "barButtonItem19");
            this.barButtonItem19.Id = 23;
            this.barButtonItem19.Name = "barButtonItem19";
            // 
            // barButtonItem20
            // 
            resources.ApplyResources(this.barButtonItem20, "barButtonItem20");
            this.barButtonItem20.Id = 24;
            this.barButtonItem20.Name = "barButtonItem20";
            // 
            // barButtonItem21
            // 
            resources.ApplyResources(this.barButtonItem21, "barButtonItem21");
            this.barButtonItem21.Id = 25;
            this.barButtonItem21.Name = "barButtonItem21";
            // 
            // barButtonItem22
            // 
            resources.ApplyResources(this.barButtonItem22, "barButtonItem22");
            this.barButtonItem22.Id = 26;
            this.barButtonItem22.Name = "barButtonItem22";
            // 
            // barButtonItem23
            // 
            resources.ApplyResources(this.barButtonItem23, "barButtonItem23");
            this.barButtonItem23.Id = 27;
            this.barButtonItem23.Name = "barButtonItem23";
            // 
            // barButtonItem24
            // 
            resources.ApplyResources(this.barButtonItem24, "barButtonItem24");
            this.barButtonItem24.Id = 28;
            this.barButtonItem24.Name = "barButtonItem24";
            // 
            // barButtonItem25
            // 
            resources.ApplyResources(this.barButtonItem25, "barButtonItem25");
            this.barButtonItem25.Id = 29;
            this.barButtonItem25.Name = "barButtonItem25";
            // 
            // barButtonItem26
            // 
            resources.ApplyResources(this.barButtonItem26, "barButtonItem26");
            this.barButtonItem26.Id = 30;
            this.barButtonItem26.Name = "barButtonItem26";
            // 
            // barButtonItem27
            // 
            resources.ApplyResources(this.barButtonItem27, "barButtonItem27");
            this.barButtonItem27.Id = 31;
            this.barButtonItem27.Name = "barButtonItem27";
            // 
            // barEditItem1
            // 
            resources.ApplyResources(this.barEditItem1, "barEditItem1");
            this.barEditItem1.Edit = this.repositoryItemComboBox1;
            this.barEditItem1.Id = 34;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemComboBox1
            // 
            resources.ApplyResources(this.repositoryItemComboBox1, "repositoryItemComboBox1");
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barCheckItem1
            // 
            resources.ApplyResources(this.barCheckItem1, "barCheckItem1");
            this.barCheckItem1.Id = 36;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barSubItem1
            // 
            resources.ApplyResources(this.barSubItem1, "barSubItem1");
            this.barSubItem1.Id = 37;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // BBI_ImportIn
            // 
            resources.ApplyResources(this.BBI_ImportIn, "BBI_ImportIn");
            this.BBI_ImportIn.Id = 38;
            this.BBI_ImportIn.ImageIndex = 14;
            this.BBI_ImportIn.LargeImageIndex = 14;
            this.BBI_ImportIn.Name = "BBI_ImportIn";
            // 
            // BBI_ImportOut
            // 
            resources.ApplyResources(this.BBI_ImportOut, "BBI_ImportOut");
            this.BBI_ImportOut.Id = 39;
            this.BBI_ImportOut.ImageIndex = 15;
            this.BBI_ImportOut.LargeImageIndex = 15;
            this.BBI_ImportOut.Name = "BBI_ImportOut";
            // 
            // barCheckItem2
            // 
            resources.ApplyResources(this.barCheckItem2, "barCheckItem2");
            this.barCheckItem2.Checked = true;
            this.barCheckItem2.Id = 41;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // barButtonItem28
            // 
            resources.ApplyResources(this.barButtonItem28, "barButtonItem28");
            this.barButtonItem28.Id = 42;
            this.barButtonItem28.ImageIndex = 5;
            this.barButtonItem28.LargeImageIndex = 5;
            this.barButtonItem28.Name = "barButtonItem28";
            this.barButtonItem28.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem28_ItemClick);
            // 
            // BTN_APP_SAVEALL
            // 
            resources.ApplyResources(this.BTN_APP_SAVEALL, "BTN_APP_SAVEALL");
            this.BTN_APP_SAVEALL.Id = 43;
            this.BTN_APP_SAVEALL.Name = "BTN_APP_SAVEALL";
            this.BTN_APP_SAVEALL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.BTN_APP_SAVEALL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_SAVEALL_ItemClick);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 45;
            this.barButtonItem1.ImageIndex = 38;
            this.barButtonItem1.LargeImageIndex = 38;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 46;
            this.barButtonItem2.ImageIndex = 43;
            this.barButtonItem2.LargeImageIndex = 43;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick_1);
            // 
            // barButtonItem3
            // 
            resources.ApplyResources(this.barButtonItem3, "barButtonItem3");
            this.barButtonItem3.Id = 47;
            this.barButtonItem3.ImageIndex = 40;
            this.barButtonItem3.LargeImageIndex = 40;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDE_ItemClick);
            // 
            // barButtonItem30
            // 
            resources.ApplyResources(this.barButtonItem30, "barButtonItem30");
            this.barButtonItem30.Id = 50;
            this.barButtonItem30.ImageIndex = 39;
            this.barButtonItem30.LargeImageIndex = 39;
            this.barButtonItem30.Name = "barButtonItem30";
            this.barButtonItem30.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem30_ItemClick);
            // 
            // barButtonItem34
            // 
            resources.ApplyResources(this.barButtonItem34, "barButtonItem34");
            this.barButtonItem34.Id = 54;
            this.barButtonItem34.ImageIndex = 41;
            this.barButtonItem34.LargeImageIndex = 41;
            this.barButtonItem34.Name = "barButtonItem34";
            this.barButtonItem34.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem34_ItemClick);
            // 
            // barButtonItem36
            // 
            resources.ApplyResources(this.barButtonItem36, "barButtonItem36");
            this.barButtonItem36.Id = 56;
            this.barButtonItem36.ImageIndex = 44;
            this.barButtonItem36.LargeImageIndex = 44;
            this.barButtonItem36.Name = "barButtonItem36";
            this.barButtonItem36.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem36_ItemClick);
            // 
            // barButtonItem37
            // 
            resources.ApplyResources(this.barButtonItem37, "barButtonItem37");
            this.barButtonItem37.Id = 57;
            this.barButtonItem37.Name = "barButtonItem37";
            // 
            // barButtonItem38
            // 
            resources.ApplyResources(this.barButtonItem38, "barButtonItem38");
            this.barButtonItem38.Id = 58;
            this.barButtonItem38.Name = "barButtonItem38";
            // 
            // barButtonItem40
            // 
            resources.ApplyResources(this.barButtonItem40, "barButtonItem40");
            this.barButtonItem40.Id = 59;
            this.barButtonItem40.Name = "barButtonItem40";
            // 
            // barButtonItem41
            // 
            resources.ApplyResources(this.barButtonItem41, "barButtonItem41");
            this.barButtonItem41.Id = 60;
            this.barButtonItem41.Name = "barButtonItem41";
            // 
            // barButtonItem42
            // 
            resources.ApplyResources(this.barButtonItem42, "barButtonItem42");
            this.barButtonItem42.Id = 61;
            this.barButtonItem42.Name = "barButtonItem42";
            // 
            // barButtonItem43
            // 
            resources.ApplyResources(this.barButtonItem43, "barButtonItem43");
            this.barButtonItem43.Id = 62;
            this.barButtonItem43.Name = "barButtonItem43";
            // 
            // barButtonItem44
            // 
            resources.ApplyResources(this.barButtonItem44, "barButtonItem44");
            this.barButtonItem44.Id = 63;
            this.barButtonItem44.Name = "barButtonItem44";
            // 
            // barButtonItem45
            // 
            resources.ApplyResources(this.barButtonItem45, "barButtonItem45");
            this.barButtonItem45.Id = 64;
            this.barButtonItem45.ImageIndex = 55;
            this.barButtonItem45.LargeImageIndex = 55;
            this.barButtonItem45.Name = "barButtonItem45";
            this.barButtonItem45.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem45_ItemClick);
            // 
            // barButtonItem49
            // 
            resources.ApplyResources(this.barButtonItem49, "barButtonItem49");
            this.barButtonItem49.Id = 68;
            this.barButtonItem49.ImageIndex = 54;
            this.barButtonItem49.LargeImageIndex = 54;
            this.barButtonItem49.Name = "barButtonItem49";
            this.barButtonItem49.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem49_ItemClick);
            // 
            // barButtonItem55
            // 
            resources.ApplyResources(this.barButtonItem55, "barButtonItem55");
            this.barButtonItem55.Id = 74;
            this.barButtonItem55.Name = "barButtonItem55";
            // 
            // BTN_SYS_COLOR
            // 
            resources.ApplyResources(this.BTN_SYS_COLOR, "BTN_SYS_COLOR");
            this.BTN_SYS_COLOR.Id = 75;
            this.BTN_SYS_COLOR.ImageIndex = 50;
            this.BTN_SYS_COLOR.LargeImageIndex = 50;
            this.BTN_SYS_COLOR.Name = "BTN_SYS_COLOR";
            this.BTN_SYS_COLOR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_SYS_COLOR_ItemClick);
            // 
            // rgbiSkins
            // 
            resources.ApplyResources(this.rgbiSkins, "rgbiSkins");
            // 
            // 
            // 
            this.rgbiSkins.Gallery.AllowHoverImages = true;
            this.rgbiSkins.Gallery.ColumnCount = 4;
            this.rgbiSkins.Gallery.FixedHoverImageSize = false;
            resources.ApplyResources(galleryItemGroup7, "galleryItemGroup7");
            resources.ApplyResources(galleryItemGroup8, "galleryItemGroup8");
            this.rgbiSkins.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup7,
            galleryItemGroup8});
            this.rgbiSkins.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            this.rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            this.rgbiSkins.Gallery.RowCount = 4;
            this.rgbiSkins.Gallery.InitDropDownGallery += new DevExpress.XtraBars.Ribbon.InplaceGalleryEventHandler(this.rgbiSkins_Gallery_InitDropDownGallery);
            this.rgbiSkins.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbiSkins_Gallery_ItemClick);
            this.rgbiSkins.Id = 76;
            this.rgbiSkins.Name = "rgbiSkins";
            // 
            // BTN_SET_PRO_PWD
            // 
            //resources.ApplyResources(this.BTN_SET_PRO_PWD, "BTN_SET_PRO_PWD");
            //this.BTN_SET_PRO_PWD.Id = 77;
            //this.BTN_SET_PRO_PWD.ImageIndex = 16;
            //this.BTN_SET_PRO_PWD.LargeImageIndex = 16;
            //this.BTN_SET_PRO_PWD.Name = "BTN_SET_PRO_PWD";
            //this.BTN_SET_PRO_PWD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_SET_PRO_PWD_ItemClick);
            // 
            // BTN_SET_UN_PWD
            // 
            resources.ApplyResources(this.BTN_SET_UN_PWD, "BTN_SET_UN_PWD");
            this.BTN_SET_UN_PWD.Id = 78;
            this.BTN_SET_UN_PWD.ImageIndex = 15;
            this.BTN_SET_UN_PWD.LargeImageIndex = 15;
            this.BTN_SET_UN_PWD.Name = "BTN_SET_UN_PWD";
            this.BTN_SET_UN_PWD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_SET_UN_PWD_ItemClick);
            // 
            // BTN_Win_Default
            // 
            resources.ApplyResources(this.BTN_Win_Default, "BTN_Win_Default");
            this.BTN_Win_Default.Id = 79;
            this.BTN_Win_Default.ImageIndex = 49;
            this.BTN_Win_Default.LargeImageIndex = 49;
            this.BTN_Win_Default.Name = "BTN_Win_Default";
            this.BTN_Win_Default.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_Win_Default_ItemClick);
            // 
            // BTN_Win_SP
            // 
            resources.ApplyResources(this.BTN_Win_SP, "BTN_Win_SP");
            this.BTN_Win_SP.Id = 80;
            this.BTN_Win_SP.ImageIndex = 52;
            this.BTN_Win_SP.LargeImageIndex = 52;
            this.BTN_Win_SP.Name = "BTN_Win_SP";
            this.BTN_Win_SP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_Win_SP_ItemClick);
            // 
            // BTN_Win_FL
            // 
            resources.ApplyResources(this.BTN_Win_FL, "BTN_Win_FL");
            this.BTN_Win_FL.Id = 81;
            this.BTN_Win_FL.ImageIndex = 47;
            this.BTN_Win_FL.LargeImageIndex = 47;
            this.BTN_Win_FL.Name = "BTN_Win_FL";
            this.BTN_Win_FL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_Win_FL_ItemClick);
            // 
            // BTN_Win_Cas
            // 
            resources.ApplyResources(this.BTN_Win_Cas, "BTN_Win_Cas");
            this.BTN_Win_Cas.Id = 83;
            this.BTN_Win_Cas.ImageIndex = 46;
            this.BTN_Win_Cas.LargeImageIndex = 46;
            this.BTN_Win_Cas.Name = "BTN_Win_Cas";
            this.BTN_Win_Cas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_Win_Cas_ItemClick);
            // 
            // MdiList
            // 
            resources.ApplyResources(this.MdiList, "MdiList");
            this.MdiList.Id = 94;
            this.MdiList.Name = "MdiList";
            this.MdiList.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.barMdiChildrenListItem1_ListItemClick);
            this.MdiList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMdiChildrenListItem1_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 95;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem5.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.barStaticItem5, "barStaticItem5");
            this.barStaticItem5.Id = 102;
            this.barStaticItem5.ImageIndex = 58;
            this.barStaticItem5.Name = "barStaticItem5";
            this.barStaticItem5.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem6
            // 
            this.barStaticItem6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem6.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.barStaticItem6, "barStaticItem6");
            this.barStaticItem6.Id = 103;
            this.barStaticItem6.ImageIndex = 59;
            this.barStaticItem6.Name = "barStaticItem6";
            this.barStaticItem6.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // Bar_Sub_ListLib
            // 
            resources.ApplyResources(this.Bar_Sub_ListLib, "Bar_Sub_ListLib");
            this.Bar_Sub_ListLib.Id = 104;
            this.Bar_Sub_ListLib.Name = "Bar_Sub_ListLib";
            this.Bar_Sub_ListLib.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_Sub_ListLib_ItemClick);
            // 
            // Bar_Sub_FixLib
            // 
            resources.ApplyResources(this.Bar_Sub_FixLib, "Bar_Sub_FixLib");
            this.Bar_Sub_FixLib.Id = 105;
            this.Bar_Sub_FixLib.Name = "Bar_Sub_FixLib";
            this.Bar_Sub_FixLib.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_Sub_FixLib_ItemClick);
            // 
            // BTN_Fun_Js
            // 
            resources.ApplyResources(this.BTN_Fun_Js, "BTN_Fun_Js");
            this.BTN_Fun_Js.Id = 108;
            this.BTN_Fun_Js.ImageIndex = 13;
            this.BTN_Fun_Js.LargeImageIndex = 13;
            this.BTN_Fun_Js.Name = "BTN_Fun_Js";
            this.BTN_Fun_Js.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_Fun_Js_ItemClick);
            // 
            // Btn_Fun_Log
            // 
            resources.ApplyResources(this.Btn_Fun_Log, "Btn_Fun_Log");
            this.Btn_Fun_Log.Id = 110;
            this.Btn_Fun_Log.ImageIndex = 1;
            this.Btn_Fun_Log.LargeImageIndex = 1;
            this.Btn_Fun_Log.Name = "Btn_Fun_Log";
            this.Btn_Fun_Log.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Btn_Fun_Log_ItemClick);
            // 
            // BTN_NET_MyInfo
            // 
            resources.ApplyResources(this.BTN_NET_MyInfo, "BTN_NET_MyInfo");
            this.BTN_NET_MyInfo.Id = 112;
            this.BTN_NET_MyInfo.ImageIndex = 56;
            this.BTN_NET_MyInfo.ImageIndexDisabled = 38;
            this.BTN_NET_MyInfo.LargeImageIndex = 56;
            this.BTN_NET_MyInfo.Name = "BTN_NET_MyInfo";
            this.BTN_NET_MyInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_NET_MyInfo_ItemClick);
            // 
            // BTN_SET_CONFIG
            // 
            resources.ApplyResources(this.BTN_SET_CONFIG, "BTN_SET_CONFIG");
            this.BTN_SET_CONFIG.Id = 113;
            this.BTN_SET_CONFIG.ImageIndex = 11;
            this.BTN_SET_CONFIG.LargeImageIndex = 11;
            this.BTN_SET_CONFIG.Name = "BTN_SET_CONFIG";
            this.BTN_SET_CONFIG.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_SET_CONFIG_ItemClick);
            // 
            // barButtonItem5
            // 
            resources.ApplyResources(this.barButtonItem5, "barButtonItem5");
            this.barButtonItem5.Id = 120;
            this.barButtonItem5.ImageIndex = 53;
            this.barButtonItem5.LargeImageIndex = 53;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick);
            // 
            // barButtonGroup1
            // 
            resources.ApplyResources(this.barButtonGroup1, "barButtonGroup1");
            this.barButtonGroup1.Id = 122;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonItem15
            // 
            resources.ApplyResources(this.barButtonItem15, "barButtonItem15");
            this.barButtonItem15.Id = 125;
            this.barButtonItem15.ImageIndex = 2;
            this.barButtonItem15.LargeImageIndex = 2;
            this.barButtonItem15.Name = "barButtonItem15";
            this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem15_ItemClick);
            // 
            // barButtonItem31
            // 
            resources.ApplyResources(this.barButtonItem31, "barButtonItem31");
            this.barButtonItem31.Id = 126;
            this.barButtonItem31.ImageIndex = 24;
            this.barButtonItem31.LargeImageIndex = 24;
            this.barButtonItem31.Name = "barButtonItem31";
            this.barButtonItem31.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem31_ItemClick);
            // 
            // barButtonItem32
            // 
            resources.ApplyResources(this.barButtonItem32, "barButtonItem32");
            this.barButtonItem32.Id = 127;
            this.barButtonItem32.ImageIndex = 23;
            this.barButtonItem32.LargeImageIndex = 23;
            this.barButtonItem32.Name = "barButtonItem32";
            this.barButtonItem32.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem32_ItemClick);
            // 
            // barButtonItem33
            // 
            resources.ApplyResources(this.barButtonItem33, "barButtonItem33");
            this.barButtonItem33.Id = 128;
            this.barButtonItem33.ImageIndex = 6;
            this.barButtonItem33.LargeImageIndex = 6;
            this.barButtonItem33.Name = "barButtonItem33";
            this.barButtonItem33.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem33_ItemClick);
            // 
            // barButtonItem35
            // 
            this.barButtonItem35.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem35, "barButtonItem35");
            this.barButtonItem35.GroupIndex = 1;
            this.barButtonItem35.Id = 129;
            this.barButtonItem35.ImageIndex = 28;
            this.barButtonItem35.LargeImageIndex = 28;
            this.barButtonItem35.Name = "barButtonItem35";
            this.barButtonItem35.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem46
            // 
            this.barButtonItem46.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem46, "barButtonItem46");
            this.barButtonItem46.GroupIndex = 1;
            this.barButtonItem46.Id = 130;
            this.barButtonItem46.ImageIndex = 22;
            this.barButtonItem46.LargeImageIndex = 22;
            this.barButtonItem46.Name = "barButtonItem46";
            this.barButtonItem46.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem47
            // 
            this.barButtonItem47.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem47, "barButtonItem47");
            this.barButtonItem47.GroupIndex = 1;
            this.barButtonItem47.Id = 131;
            this.barButtonItem47.ImageIndex = 20;
            this.barButtonItem47.LargeImageIndex = 20;
            this.barButtonItem47.Name = "barButtonItem47";
            this.barButtonItem47.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem48
            // 
            this.barButtonItem48.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem48, "barButtonItem48");
            this.barButtonItem48.GroupIndex = 1;
            this.barButtonItem48.Id = 132;
            this.barButtonItem48.ImageIndex = 31;
            this.barButtonItem48.LargeImageIndex = 31;
            this.barButtonItem48.Name = "barButtonItem48";
            this.barButtonItem48.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem50
            // 
            this.barButtonItem50.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem50, "barButtonItem50");
            this.barButtonItem50.GroupIndex = 1;
            this.barButtonItem50.Id = 133;
            this.barButtonItem50.ImageIndex = 32;
            this.barButtonItem50.LargeImageIndex = 32;
            this.barButtonItem50.Name = "barButtonItem50";
            this.barButtonItem50.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem51
            // 
            this.barButtonItem51.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem51, "barButtonItem51");
            this.barButtonItem51.GroupIndex = 1;
            this.barButtonItem51.Id = 134;
            this.barButtonItem51.ImageIndex = 30;
            this.barButtonItem51.LargeImageIndex = 30;
            this.barButtonItem51.Name = "barButtonItem51";
            this.barButtonItem51.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem52
            // 
            this.barButtonItem52.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem52, "barButtonItem52");
            this.barButtonItem52.GroupIndex = 1;
            this.barButtonItem52.Id = 135;
            this.barButtonItem52.ImageIndex = 29;
            this.barButtonItem52.LargeImageIndex = 29;
            this.barButtonItem52.Name = "barButtonItem52";
            this.barButtonItem52.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem53
            // 
            this.barButtonItem53.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem53, "barButtonItem53");
            this.barButtonItem53.GroupIndex = 1;
            this.barButtonItem53.Id = 136;
            this.barButtonItem53.ImageIndex = 26;
            this.barButtonItem53.LargeImageIndex = 26;
            this.barButtonItem53.Name = "barButtonItem53";
            this.barButtonItem53.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem54
            // 
            this.barButtonItem54.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem54, "barButtonItem54");
            this.barButtonItem54.GroupIndex = 1;
            this.barButtonItem54.Id = 137;
            this.barButtonItem54.ImageIndex = 33;
            this.barButtonItem54.LargeImageIndex = 33;
            this.barButtonItem54.Name = "barButtonItem54";
            this.barButtonItem54.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem56
            // 
            this.barButtonItem56.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem56, "barButtonItem56");
            this.barButtonItem56.GroupIndex = 1;
            this.barButtonItem56.Id = 138;
            this.barButtonItem56.ImageIndex = 21;
            this.barButtonItem56.LargeImageIndex = 21;
            this.barButtonItem56.Name = "barButtonItem56";
            this.barButtonItem56.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem57
            // 
            this.barButtonItem57.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem57, "barButtonItem57");
            this.barButtonItem57.GroupIndex = 1;
            this.barButtonItem57.Id = 139;
            this.barButtonItem57.ImageIndex = 35;
            this.barButtonItem57.LargeImageIndex = 35;
            this.barButtonItem57.Name = "barButtonItem57";
            this.barButtonItem57.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem58
            // 
            resources.ApplyResources(this.barButtonItem58, "barButtonItem58");
            this.barButtonItem58.Id = 140;
            this.barButtonItem58.ImageIndex = 42;
            this.barButtonItem58.LargeImageIndex = 42;
            this.barButtonItem58.Name = "barButtonItem58";
            this.barButtonItem58.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem58_ItemClick);
            // 
            // barButtonItem59
            // 
            this.barButtonItem59.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem59, "barButtonItem59");
            this.barButtonItem59.GroupIndex = 1;
            this.barButtonItem59.Id = 141;
            this.barButtonItem59.ImageIndex = 25;
            this.barButtonItem59.LargeImageIndex = 25;
            this.barButtonItem59.Name = "barButtonItem59";
            this.barButtonItem59.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem60
            // 
            this.barButtonItem60.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem60, "barButtonItem60");
            this.barButtonItem60.GroupIndex = 1;
            this.barButtonItem60.Id = 142;
            this.barButtonItem60.ImageIndex = 34;
            this.barButtonItem60.LargeImageIndex = 34;
            this.barButtonItem60.Name = "barButtonItem60";
            this.barButtonItem60.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem35_ItemClick_1);
            // 
            // barButtonItem61
            // 
            this.barButtonItem61.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem61, "barButtonItem61");
            this.barButtonItem61.GroupIndex = 1;
            this.barButtonItem61.Id = 143;
            this.barButtonItem61.ImageIndex = 62;
            this.barButtonItem61.LargeImageIndex = 62;
            this.barButtonItem61.Name = "barButtonItem61";
            this.barButtonItem61.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem62
            // 
            this.barButtonItem62.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.barButtonItem62, "barButtonItem62");
            this.barButtonItem62.GroupIndex = 1;
            this.barButtonItem62.Id = 144;
            this.barButtonItem62.ImageIndex = 60;
            this.barButtonItem62.LargeImageIndex = 60;
            this.barButtonItem62.Name = "barButtonItem62";
            this.barButtonItem62.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barStaticItem4
            // 
            resources.ApplyResources(this.barStaticItem4, "barStaticItem4");
            this.barStaticItem4.Id = 146;
            this.barStaticItem4.Name = "barStaticItem4";
            this.barStaticItem4.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            resources.ApplyResources(this.barStaticItem3, "barStaticItem3");
            this.barStaticItem3.Id = 147;
            this.barStaticItem3.ImageIndex = 60;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem7
            // 
            resources.ApplyResources(this.barStaticItem7, "barStaticItem7");
            this.barStaticItem7.Id = 149;
            this.barStaticItem7.ImageIndex = 61;
            this.barStaticItem7.Name = "barStaticItem7";
            this.barStaticItem7.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem8
            // 
            resources.ApplyResources(this.barStaticItem8, "barStaticItem8");
            this.barStaticItem8.Id = 151;
            this.barStaticItem8.ImageIndex = 62;
            this.barStaticItem8.Name = "barStaticItem8";
            this.barStaticItem8.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem9
            // 
            resources.ApplyResources(this.barStaticItem9, "barStaticItem9");
            this.barStaticItem9.Id = 152;
            this.barStaticItem9.ImageIndex = 63;
            this.barStaticItem9.Name = "barStaticItem9";
            this.barStaticItem9.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem10
            // 
            resources.ApplyResources(this.barStaticItem10, "barStaticItem10");
            this.barStaticItem10.Id = 153;
            this.barStaticItem10.ImageIndex = 64;
            this.barStaticItem10.Name = "barStaticItem10";
            this.barStaticItem10.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar_txt_gczj
            // 
            resources.ApplyResources(this.bar_txt_gczj, "bar_txt_gczj");
            this.bar_txt_gczj.Id = 154;
            this.bar_txt_gczj.Name = "bar_txt_gczj";
            this.bar_txt_gczj.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar_txt_csxmf
            // 
            resources.ApplyResources(this.bar_txt_csxmf, "bar_txt_csxmf");
            this.bar_txt_csxmf.Id = 155;
            this.bar_txt_csxmf.Name = "bar_txt_csxmf";
            this.bar_txt_csxmf.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar_txt_qds
            // 
            resources.ApplyResources(this.bar_txt_qds, "bar_txt_qds");
            this.bar_txt_qds.Id = 156;
            this.bar_txt_qds.Name = "bar_txt_qds";
            this.bar_txt_qds.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar_txt_zms
            // 
            resources.ApplyResources(this.bar_txt_zms, "bar_txt_zms");
            this.bar_txt_zms.Id = 157;
            this.bar_txt_zms.Name = "bar_txt_zms";
            this.bar_txt_zms.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar_txt_cjs
            // 
            resources.ApplyResources(this.bar_txt_cjs, "bar_txt_cjs");
            this.bar_txt_cjs.Id = 158;
            this.bar_txt_cjs.Name = "bar_txt_cjs";
            this.bar_txt_cjs.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BTN_APP_NEW_Project
            // 
            resources.ApplyResources(this.BTN_APP_NEW_Project, "BTN_APP_NEW_Project");
            this.BTN_APP_NEW_Project.Id = 159;
            this.BTN_APP_NEW_Project.ImageIndex = 19;
            this.BTN_APP_NEW_Project.LargeImageIndex = 19;
            this.BTN_APP_NEW_Project.Name = "BTN_APP_NEW_Project";
            this.BTN_APP_NEW_Project.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_NEW_Project_ItemClick);
            // 
            // BTN_APP_NEW_Unit
            // 
            resources.ApplyResources(this.BTN_APP_NEW_Unit, "BTN_APP_NEW_Unit");
            this.BTN_APP_NEW_Unit.Id = 160;
            this.BTN_APP_NEW_Unit.ImageIndex = 18;
            this.BTN_APP_NEW_Unit.LargeImageIndex = 18;
            this.BTN_APP_NEW_Unit.Name = "BTN_APP_NEW_Unit";
            this.BTN_APP_NEW_Unit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_APP_NEW_Unit_ItemClick);
            // 
            // barEditItem2
            // 
            this.barEditItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barEditItem2, "barEditItem2");
            this.barEditItem2.Edit = this.repositoryItemProgressBar1;
            this.barEditItem2.Id = 161;
            this.barEditItem2.Name = "barEditItem2";
            resources.ApplyResources(toolTipTitleItem3, "toolTipTitleItem3");
            toolTipItem2.LeftIndent = 6;
            resources.ApplyResources(toolTipItem2, "toolTipItem2");
            toolTipTitleItem4.LeftIndent = 6;
            resources.ApplyResources(toolTipTitleItem4, "toolTipTitleItem4");
            superToolTip2.Items.Add(toolTipTitleItem3);
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipSeparatorItem2);
            superToolTip2.Items.Add(toolTipTitleItem4);
            superToolTip2.MaxWidth = 400;
            this.barEditItem2.SuperTip = superToolTip2;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ShowTitle = true;
            // 
            // btnupdateInfo
            // 
            resources.ApplyResources(this.btnupdateInfo, "btnupdateInfo");
            this.btnupdateInfo.Id = 163;
            this.btnupdateInfo.ImageIndex = 45;
            this.btnupdateInfo.LargeImageIndex = 45;
            this.btnupdateInfo.Name = "btnupdateInfo";
            this.btnupdateInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnupdateInfo_ItemClick);
            // 
            // btnzbOpen
            // 
            resources.ApplyResources(this.btnzbOpen, "btnzbOpen");
            this.btnzbOpen.Id = 164;
            this.btnzbOpen.ImageIndex = 2;
            this.btnzbOpen.LargeImageIndex = 2;
            this.btnzbOpen.Name = "btnzbOpen";
            this.btnzbOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnzbOpen_ItemClick);
            // 
            // btnzbInvite
            // 
            resources.ApplyResources(this.btnzbInvite, "btnzbInvite");
            this.btnzbInvite.Id = 173;
            this.btnzbInvite.ImageIndex = 66;
            this.btnzbInvite.LargeImageIndex = 66;
            this.btnzbInvite.Name = "btnzbInvite";
            // 
            // btnzbPublish
            // 
            resources.ApplyResources(this.btnzbPublish, "btnzbPublish");
            this.btnzbPublish.Id = 170;
            this.btnzbPublish.ImageIndex = 67;
            this.btnzbPublish.LargeImageIndex = 67;
            this.btnzbPublish.Name = "btnzbPublish";
            // 
            // btnzbCount
            // 
            resources.ApplyResources(this.btnzbCount, "btnzbCount");
            this.btnzbCount.Id = 171;
            this.btnzbCount.ImageIndex = 45;
            this.btnzbCount.LargeImageIndex = 45;
            this.btnzbCount.Name = "btnzbCount";
            // 
            // btnzbMyCount
            // 
            resources.ApplyResources(this.btnzbMyCount, "btnzbMyCount");
            this.btnzbMyCount.Id = 172;
            this.btnzbMyCount.ImageIndex = 45;
            this.btnzbMyCount.LargeImageIndex = 45;
            this.btnzbMyCount.Name = "btnzbMyCount";
            // 
            // btnzbBeginAnalyze
            // 
            resources.ApplyResources(this.btnzbBeginAnalyze, "btnzbBeginAnalyze");
            this.btnzbBeginAnalyze.Id = 169;
            this.btnzbBeginAnalyze.ImageIndex = 68;
            this.btnzbBeginAnalyze.LargeImageIndex = 68;
            this.btnzbBeginAnalyze.Name = "btnzbBeginAnalyze";
            this.btnzbBeginAnalyze.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnzbBeginAnalyze_ItemClick);
            // 
            // btnqjFlag
            // 
            resources.ApplyResources(this.btnqjFlag, "btnqjFlag");
            this.btnqjFlag.Id = 169;
            this.btnqjFlag.ImageIndex = 50;
            this.btnqjFlag.LargeImageIndex = 50;
            this.btnqjFlag.Name = "btnqjFlag";
            this.btnqjFlag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqjFlag_ItemClick);
            // 
            // btnqjApplyCurrent
            // 
            resources.ApplyResources(this.btnqjApplyCurrent, "btnqjApplyCurrent");
            this.btnqjApplyCurrent.Id = 169;
            this.btnqjApplyCurrent.ImageIndex = 46;
            this.btnqjApplyCurrent.LargeImageIndex = 46;
            this.btnqjApplyCurrent.Name = "btnqjApplyCurrent";
            this.btnqjApplyCurrent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqjApplyCurrent_ItemClick);
            // 
            // btnqjApplyNot
            // 
            resources.ApplyResources(this.btnqjApplyNot, "btnqjApplyNot");
            this.btnqjApplyNot.Id = 169;
            this.btnqjApplyNot.ImageIndex = 46;
            this.btnqjApplyNot.LargeImageIndex = 46;
            this.btnqjApplyNot.Name = "btnqjApplyNot";
            this.btnqjApplyNot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqjApplyNot_ItemClick);
            // 
            // btnqjApplyAll
            // 
            resources.ApplyResources(this.btnqjApplyAll, "btnqjApplyAll");
            this.btnqjApplyAll.Id = 169;
            this.btnqjApplyAll.ImageIndex = 46;
            this.btnqjApplyAll.LargeImageIndex = 46;
            this.btnqjApplyAll.Name = "btnqjApplyAll";
            this.btnqjApplyAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqjApplyAll_ItemClick);
            // 
            // btnqjApplyBegin
            // 
            resources.ApplyResources(this.btnqjApplyBegin, "btnqjApplyBegin");
            this.btnqjApplyBegin.Id = 169;
            this.btnqjApplyBegin.ImageIndex = 68;
            this.btnqjApplyBegin.LargeImageIndex = 68;
            this.btnqjApplyBegin.Name = "btnqjApplyBegin";
            this.btnqjApplyBegin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqjApplyBegin_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup4,
            this.ribbonPageGroup10,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_NEW);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_NEW_Project);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_NEW_Unit);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_OPEN);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_CLOSE);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_SAVE, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_SAVEALL);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_APP_SAVEAS);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem12);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem13);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem28);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem33);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup4, "ribbonPageGroup4");
            // 
            // ribbonPageGroup10
            // 
            //this.ribbonPageGroup10.ItemLinks.Add(this.BTN_SET_PRO_PWD);
            this.ribbonPageGroup10.ItemLinks.Add(this.BTN_SET_UN_PWD);
            this.ribbonPageGroup10.ItemLinks.Add(this.JZBX_PWD);
            this.ribbonPageGroup10.ItemLinks.Add(this.BTN_SET_CONFIG);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup10, "ribbonPageGroup10");
            // 
            // JZBX_PWD
            // 
            resources.ApplyResources(this.JZBX_PWD, "JZBX_PWD");
            this.JZBX_PWD.Id = 166;
            this.JZBX_PWD.ImageIndex = 16;
            this.JZBX_PWD.LargeImageIndex = 16;
            this.JZBX_PWD.Name = "JZBX_PWD";
            this.JZBX_PWD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.JZBX_PWD_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BTN_Fun_Js);
            this.ribbonPageGroup2.ItemLinks.Add(this.Btn_Fun_Log);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup2, "ribbonPageGroup2");
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7,
            this.ribbonPageGroup11});
            this.ribbonPage2.Name = "ribbonPage2";
            resources.ApplyResources(this.ribbonPage2, "ribbonPage2");
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem15);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem35, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem46);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem47);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem48);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem59);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem50);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem51);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem52);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem60);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem53);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem54);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem56);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem57);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem61);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem62);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            resources.ApplyResources(this.ribbonPageGroup7, "ribbonPageGroup7");
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem31);
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem32);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            resources.ApplyResources(this.ribbonPageGroup11, "ribbonPageGroup11");
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup16,
            this.ribbonPageGroup17,
            this.ribbonPageGroup18,
            this.ribbonPageGroup19,
            this.ribbonPageGroup20,
            this.ribbonPageGroup21});
            this.ribbonPage7.Name = "ribbonPage7";
            resources.ApplyResources(this.ribbonPage7, "ribbonPage7");
            // 
            // ribbonPageGroup16
            // 
            this.ribbonPageGroup16.ItemLinks.Add(this.btnzbOpen);
            this.ribbonPageGroup16.Name = "ribbonPageGroup16";
            // 
            // ribbonPageGroup17
            // 
            this.ribbonPageGroup17.ItemLinks.Add(this.barCheckItemInvite);
            this.ribbonPageGroup17.Name = "ribbonPageGroup17";
            // 
            // barCheckItemInvite
            // 
            resources.ApplyResources(this.barCheckItemInvite, "barCheckItemInvite");
            this.barCheckItemInvite.Id = 36;
            this.barCheckItemInvite.ImageIndex = 66;
            this.barCheckItemInvite.LargeImageIndex = 66;
            this.barCheckItemInvite.Name = "barCheckItemInvite";
            this.barCheckItemInvite.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemInvite_CheckedChanged);
            // 
            // ribbonPageGroup18
            // 
            this.ribbonPageGroup18.ItemLinks.Add(this.barCheckItemPublish);
            this.ribbonPageGroup18.Name = "ribbonPageGroup18";
            // 
            // barCheckItemPublish
            // 
            resources.ApplyResources(this.barCheckItemPublish, "barCheckItemPublish");
            this.barCheckItemPublish.Id = 36;
            this.barCheckItemPublish.ImageIndex = 67;
            this.barCheckItemPublish.LargeImageIndex = 67;
            this.barCheckItemPublish.Name = "barCheckItemPublish";
            this.barCheckItemPublish.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemPublish_CheckedChanged);
            // 
            // ribbonPageGroup19
            // 
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount1);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount2);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount3);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount4);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount5);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount6);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount7);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount8);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount9);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount10);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount11);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount12);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount13);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount14);
            this.ribbonPageGroup19.ItemLinks.Add(this.barCount15);
            this.ribbonPageGroup19.Name = "ribbonPageGroup19";
            this.ribbonPageGroup19.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup19, "ribbonPageGroup19");
            // 
            // barCount1
            // 
            resources.ApplyResources(this.barCount1, "barCount1");
            this.barCount1.Id = 36;
            this.barCount1.Name = "barCount1";
            this.barCount1.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount1_CheckedChanged);
            // 
            // barCount2
            // 
            resources.ApplyResources(this.barCount2, "barCount2");
            this.barCount2.Id = 36;
            this.barCount2.Name = "barCount2";
            this.barCount2.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount2_CheckedChanged);
            // 
            // barCount3
            // 
            resources.ApplyResources(this.barCount3, "barCount3");
            this.barCount3.Id = 36;
            this.barCount3.Name = "barCount3";
            this.barCount3.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount3_CheckedChanged);
            // 
            // barCount4
            // 
            resources.ApplyResources(this.barCount4, "barCount4");
            this.barCount4.Id = 36;
            this.barCount4.Name = "barCount4";
            this.barCount4.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount4_CheckedChanged);
            // 
            // barCount5
            // 
            resources.ApplyResources(this.barCount5, "barCount5");
            this.barCount5.Id = 36;
            this.barCount5.Name = "barCount5";
            this.barCount5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barCount5.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount5_CheckedChanged);
            // 
            // barCount6
            // 
            resources.ApplyResources(this.barCount6, "barCount6");
            this.barCount6.Id = 36;
            this.barCount6.Name = "barCount6";
            this.barCount6.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount6_CheckedChanged);
            // 
            // barCount7
            // 
            resources.ApplyResources(this.barCount7, "barCount7");
            this.barCount7.Id = 36;
            this.barCount7.Name = "barCount7";
            this.barCount7.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount7_CheckedChanged);
            // 
            // barCount8
            // 
            resources.ApplyResources(this.barCount8, "barCount8");
            this.barCount8.Id = 36;
            this.barCount8.Name = "barCount8";
            this.barCount8.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount8_CheckedChanged);
            // 
            // barCount9
            // 
            resources.ApplyResources(this.barCount9, "barCount9");
            this.barCount9.Id = 36;
            this.barCount9.Name = "barCount9";
            this.barCount9.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount9_CheckedChanged);
            // 
            // barCount10
            // 
            resources.ApplyResources(this.barCount10, "barCount10");
            this.barCount10.Id = 36;
            this.barCount10.Name = "barCount10";
            this.barCount10.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount10_CheckedChanged);
            // 
            // barCount11
            // 
            resources.ApplyResources(this.barCount11, "barCount11");
            this.barCount11.Id = 36;
            this.barCount11.Name = "barCount11";
            this.barCount11.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount11_CheckedChanged);
            // 
            // barCount12
            // 
            resources.ApplyResources(this.barCount12, "barCount12");
            this.barCount12.Id = 36;
            this.barCount12.Name = "barCount12";
            this.barCount12.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount12_CheckedChanged);
            // 
            // barCount13
            // 
            resources.ApplyResources(this.barCount13, "barCount13");
            this.barCount13.Id = 36;
            this.barCount13.Name = "barCount13";
            this.barCount13.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount13_CheckedChanged);
            // 
            // barCount14
            // 
            resources.ApplyResources(this.barCount14, "barCount14");
            this.barCount14.Id = 36;
            this.barCount14.Name = "barCount14";
            this.barCount14.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount14_CheckedChanged);
            // 
            // barCount15
            // 
            resources.ApplyResources(this.barCount15, "barCount15");
            this.barCount15.Id = 36;
            this.barCount15.Name = "barCount15";
            this.barCount15.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCount15_CheckedChanged);
            // 
            // ribbonPageGroup20
            // 
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount3);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount4);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount5);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount6);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount7);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount8);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount9);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount10);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount11);
            this.ribbonPageGroup20.ItemLinks.Add(this.barMyCount12);
            this.ribbonPageGroup20.Name = "ribbonPageGroup20";
            this.ribbonPageGroup20.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup20, "ribbonPageGroup20");
            // 
            // barMyCount3
            // 
            resources.ApplyResources(this.barMyCount3, "barMyCount3");
            this.barMyCount3.Id = 36;
            this.barMyCount3.Name = "barMyCount3";
            this.barMyCount3.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount3_CheckedChanged);
            // 
            // barMyCount4
            // 
            resources.ApplyResources(this.barMyCount4, "barMyCount4");
            this.barMyCount4.Id = 36;
            this.barMyCount4.Name = "barMyCount4";
            this.barMyCount4.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount4_CheckedChanged);
            // 
            // barMyCount5
            // 
            resources.ApplyResources(this.barMyCount5, "barMyCount5");
            this.barMyCount5.Id = 36;
            this.barMyCount5.Name = "barMyCount5";
            this.barMyCount5.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount5_CheckedChanged);
            // 
            // barMyCount6
            // 
            resources.ApplyResources(this.barMyCount6, "barMyCount6");
            this.barMyCount6.Id = 36;
            this.barMyCount6.Name = "barMyCount6";
            this.barMyCount6.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount6_CheckedChanged);
            // 
            // barMyCount7
            // 
            resources.ApplyResources(this.barMyCount7, "barMyCount7");
            this.barMyCount7.Id = 36;
            this.barMyCount7.Name = "barMyCount7";
            this.barMyCount7.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount7_CheckedChanged);
            // 
            // barMyCount8
            // 
            resources.ApplyResources(this.barMyCount8, "barMyCount8");
            this.barMyCount8.Id = 36;
            this.barMyCount8.Name = "barMyCount8";
            this.barMyCount8.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount8_CheckedChanged);
            // 
            // barMyCount9
            // 
            resources.ApplyResources(this.barMyCount9, "barMyCount9");
            this.barMyCount9.Id = 36;
            this.barMyCount9.Name = "barMyCount9";
            this.barMyCount9.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount9_CheckedChanged);
            // 
            // barMyCount10
            // 
            resources.ApplyResources(this.barMyCount10, "barMyCount10");
            this.barMyCount10.Id = 36;
            this.barMyCount10.Name = "barMyCount10";
            this.barMyCount10.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount10_CheckedChanged);
            // 
            // barMyCount11
            // 
            resources.ApplyResources(this.barMyCount11, "barMyCount11");
            this.barMyCount11.Id = 36;
            this.barMyCount11.Name = "barMyCount11";
            this.barMyCount11.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount11_CheckedChanged);
            // 
            // barMyCount12
            // 
            resources.ApplyResources(this.barMyCount12, "barMyCount12");
            this.barMyCount12.Id = 36;
            this.barMyCount12.Name = "barMyCount12";
            this.barMyCount12.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyCount12_CheckedChanged);
            // 
            // ribbonPageGroup21
            // 
            this.ribbonPageGroup21.ItemLinks.Add(this.btnzbBeginAnalyze);
            this.ribbonPageGroup21.Name = "ribbonPageGroup21";
            // 
            // ribbonPage8
            // 
            this.ribbonPage8.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup22,
            this.ribbonPageGroup23,
            this.ribbonPageGroup24,
            this.ribbonPageGroup25,
            this.ribbonPageGroup26});
            this.ribbonPage8.Name = "ribbonPage8";
            resources.ApplyResources(this.ribbonPage8, "ribbonPage8");
            // 
            // ribbonPageGroup22
            // 
            this.ribbonPageGroup22.ItemLinks.Add(this.btnqjFlag);
            this.ribbonPageGroup22.Name = "ribbonPageGroup22";
            // 
            // ribbonPageGroup23
            // 
            this.ribbonPageGroup23.ItemLinks.Add(this.btnqjApplyCurrent);
            this.ribbonPageGroup23.Name = "ribbonPageGroup23";
            // 
            // ribbonPageGroup24
            // 
            this.ribbonPageGroup24.ItemLinks.Add(this.btnqjApplyNot);
            this.ribbonPageGroup24.Name = "ribbonPageGroup24";
            // 
            // ribbonPageGroup25
            // 
            this.ribbonPageGroup25.ItemLinks.Add(this.btnqjApplyAll);
            this.ribbonPageGroup25.Name = "ribbonPageGroup25";
            // 
            // ribbonPageGroup26
            // 
            this.ribbonPageGroup26.ItemLinks.Add(this.btnqjApplyBegin);
            this.ribbonPageGroup26.Name = "ribbonPageGroup26";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup13,
            this.ribbonPageGroup15,
            this.ribbonPageGroup8});
            this.ribbonPage3.Name = "ribbonPage3";
            resources.ApplyResources(this.ribbonPage3, "ribbonPage3");
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.BTN_TOOLS_CALC, true);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem16);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem45);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem49);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup6, "ribbonPageGroup6");
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.ItemLinks.Add(this.BTN_SYS_COLOR);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            this.ribbonPageGroup13.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup13, "ribbonPageGroup13");
            // 
            // ribbonPageGroup15
            // 
            this.ribbonPageGroup15.ItemLinks.Add(this.BTN_Win_Default);
            this.ribbonPageGroup15.ItemLinks.Add(this.BTN_Win_SP);
            this.ribbonPageGroup15.ItemLinks.Add(this.BTN_Win_FL);
            this.ribbonPageGroup15.ItemLinks.Add(this.BTN_Win_Cas);
            this.ribbonPageGroup15.Name = "ribbonPageGroup15";
            this.ribbonPageGroup15.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup15, "ribbonPageGroup15");
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.rgbiSkins);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup8, "ribbonPageGroup8");
            // 
            // ribbonPage6
            // 
            this.ribbonPage6.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup9,
            this.ribbonPageGroup5,
            this.ribbonPageGroup14,
            this.ribbonPageGroup12});
            this.ribbonPage6.Name = "ribbonPage6";
            resources.ApplyResources(this.ribbonPage6, "ribbonPage6");
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem30, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup3, "ribbonPageGroup3");
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem36, true);
            this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem34, true);
            this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem58);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup9, "ribbonPageGroup9");
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.BTN_NET_MyInfo);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            resources.ApplyResources(this.ribbonPageGroup5, "ribbonPageGroup5");
            // 
            // ribbonPageGroup14
            // 
            this.ribbonPageGroup14.ItemLinks.Add(this.btnupdateInfo);
            this.ribbonPageGroup14.Name = "ribbonPageGroup14";
            resources.ApplyResources(this.ribbonPageGroup14, "ribbonPageGroup14");
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem29, true);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup12, "ribbonPageGroup12");
            // 
            // barButtonItem29
            // 
            resources.ApplyResources(this.barButtonItem29, "barButtonItem29");
            this.barButtonItem29.Id = 49;
            this.barButtonItem29.ImageIndex = 37;
            this.barButtonItem29.LargeImageIndex = 37;
            this.barButtonItem29.Name = "barButtonItem29";
            this.barButtonItem29.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem29_ItemClick);
            // 
            // DefaultSBar
            // 
            this.DefaultSBar.ItemLinks.Add(this.barStaticItem1);
            this.DefaultSBar.ItemLinks.Add(this.MdiList);
            this.DefaultSBar.ItemLinks.Add(this.barEditItem2);
            resources.ApplyResources(this.DefaultSBar, "DefaultSBar");
            this.DefaultSBar.Name = "DefaultSBar";
            this.DefaultSBar.Ribbon = this.ribbon;
            // 
            // UnitSBar
            // 
            this.UnitSBar.ItemLinks.Add(this.barStaticItem5, true);
            this.UnitSBar.ItemLinks.Add(this.Bar_Sub_ListLib);
            this.UnitSBar.ItemLinks.Add(this.barStaticItem6);
            this.UnitSBar.ItemLinks.Add(this.Bar_Sub_FixLib);
            this.UnitSBar.ItemLinks.Add(this.barStaticItem3, true);
            this.UnitSBar.ItemLinks.Add(this.bar_txt_gczj);
            this.UnitSBar.ItemLinks.Add(this.barStaticItem7);
            this.UnitSBar.ItemLinks.Add(this.bar_txt_csxmf);
            this.UnitSBar.ItemLinks.Add(this.barStaticItem8, true);
            this.UnitSBar.ItemLinks.Add(this.bar_txt_qds);
            this.UnitSBar.ItemLinks.Add(this.barStaticItem9);
            this.UnitSBar.ItemLinks.Add(this.bar_txt_zms);
            this.UnitSBar.ItemLinks.Add(this.barStaticItem10);
            this.UnitSBar.ItemLinks.Add(this.bar_txt_cjs);
            resources.ApplyResources(this.UnitSBar, "UnitSBar");
            this.UnitSBar.Name = "UnitSBar";
            this.UnitSBar.Ribbon = this.ribbon;
            // 
            // ProjSBar
            // 
            this.ProjSBar.ItemLinks.Add(this.barStaticItem4);
            resources.ApplyResources(this.ProjSBar, "ProjSBar");
            this.ProjSBar.Name = "ProjSBar";
            this.ProjSBar.Ribbon = this.ribbon;
            // 
            // imageCollection3
            // 
            this.imageCollection3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection3.ImageStream")));
            // 
            // pmAppMain
            // 
            this.pmAppMain.BottomPaneControlContainer = null;
            this.pmAppMain.Name = "pmAppMain";
            this.pmAppMain.Ribbon = this.ribbon;
            this.pmAppMain.RightPaneControlContainer = null;
            this.pmAppMain.ShowRightPane = true;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            // 
            // idNew
            // 
            this.idNew.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.idNew, "idNew");
            this.idNew.CategoryGuid = new System.Guid("4b511317-d784-42ba-b4ed-0d2a746d6c1f");
            this.idNew.Id = 0;
            this.idNew.ImageIndex = 6;
            this.idNew.LargeImageIndex = 0;
            this.idNew.Name = "idNew";
            // 
            // barButtonItem4
            // 
            resources.ApplyResources(this.barButtonItem4, "barButtonItem4");
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar3, "bar3");
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.InitialDirectory = "工程文件";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowReadOnly = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.Images = this.imageCollection2;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.SelectedPageChanged += new System.EventHandler(this.xtraTabbedMdiManager1_SelectedPageChanged);
            // 
            // barButtonItem39
            // 
            resources.ApplyResources(this.barButtonItem39, "barButtonItem39");
            this.barButtonItem39.Id = 58;
            this.barButtonItem39.Name = "barButtonItem39";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem2.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.barStaticItem2, "barStaticItem2");
            this.barStaticItem2.Id = 95;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // ApplicationForm
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pccAppMenu);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.ProjSBar);
            this.Controls.Add(this.UnitSBar);
            this.Controls.Add(this.DefaultSBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "ApplicationForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.DefaultSBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainRibbonForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainRibbonForm_FormClosed);
            this.MdiChildActivate += new System.EventHandler(this.ApplicationForm_MdiChildActivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainRibbonForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccAppMenu)).EndInit();
            this.pccAppMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcAppMenuFileLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu pmAppMain;
        private DevExpress.XtraBars.BarButtonItem idNew;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_NEW;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection3;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_OPEN;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_CLOSE;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_SAVE;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem BTN_TOOLS_CALC;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        private DevExpress.XtraBars.BarButtonItem barButtonItem20;
        private DevExpress.XtraBars.BarButtonItem barButtonItem21;
        private DevExpress.XtraBars.BarButtonItem barButtonItem22;
        private DevExpress.XtraBars.BarButtonItem barButtonItem23;
        private DevExpress.XtraBars.BarButtonItem barButtonItem24;
        private DevExpress.XtraBars.BarButtonItem barButtonItem25;
        private DevExpress.XtraBars.BarButtonItem barButtonItem26;
        private DevExpress.XtraBars.BarButtonItem barButtonItem27;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.Bar bar3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;

        private DevExpress.XtraBars.BarCheckItem barCheckItemInvite;
        private DevExpress.XtraBars.BarCheckItem barCheckItemPublish;

        private DevExpress.XtraBars.BarCheckItem barCount1;
        private DevExpress.XtraBars.BarCheckItem barCount2;
        private DevExpress.XtraBars.BarCheckItem barCount3;
        private DevExpress.XtraBars.BarCheckItem barCount4;
        private DevExpress.XtraBars.BarCheckItem barCount5;
        private DevExpress.XtraBars.BarCheckItem barCount6;
        private DevExpress.XtraBars.BarCheckItem barCount7;
        private DevExpress.XtraBars.BarCheckItem barCount8;
        private DevExpress.XtraBars.BarCheckItem barCount9;
        private DevExpress.XtraBars.BarCheckItem barCount10;
        private DevExpress.XtraBars.BarCheckItem barCount11;
        private DevExpress.XtraBars.BarCheckItem barCount12;
        private DevExpress.XtraBars.BarCheckItem barCount13;
        private DevExpress.XtraBars.BarCheckItem barCount14;
        private DevExpress.XtraBars.BarCheckItem barCount15;

        //private DevExpress.XtraBars.BarCheckItem barMyCount1;
        //private DevExpress.XtraBars.BarCheckItem barMyCount2;
        private DevExpress.XtraBars.BarCheckItem barMyCount3;
        private DevExpress.XtraBars.BarCheckItem barMyCount4;
        private DevExpress.XtraBars.BarCheckItem barMyCount5;
        private DevExpress.XtraBars.BarCheckItem barMyCount6;
        private DevExpress.XtraBars.BarCheckItem barMyCount7;
        private DevExpress.XtraBars.BarCheckItem barMyCount8;
        private DevExpress.XtraBars.BarCheckItem barMyCount9;
        private DevExpress.XtraBars.BarCheckItem barMyCount10;
        private DevExpress.XtraBars.BarCheckItem barMyCount11;
        private DevExpress.XtraBars.BarCheckItem barMyCount12;


        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem BBI_ImportIn;
        private DevExpress.XtraBars.BarButtonItem BBI_ImportOut;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem28;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_SAVEALL;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_SAVEAS;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem29;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.BarButtonItem barButtonItem30;
        private DevExpress.XtraBars.BarButtonItem barButtonItem34;
        private DevExpress.XtraBars.BarButtonItem barButtonItem36;
        private DevExpress.XtraBars.BarButtonItem barButtonItem37;
        private DevExpress.XtraBars.BarButtonItem barButtonItem38;
        private DevExpress.XtraBars.BarButtonItem barButtonItem40;
        private DevExpress.XtraBars.BarButtonItem barButtonItem41;
        private DevExpress.XtraBars.BarButtonItem barButtonItem42;
        private DevExpress.XtraBars.BarButtonItem barButtonItem43;
        private DevExpress.XtraBars.BarButtonItem barButtonItem44;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.BarButtonItem barButtonItem39;
        private DevExpress.XtraBars.BarButtonItem barButtonItem45;
        private DevExpress.XtraBars.BarButtonItem barButtonItem49;
        private DevExpress.XtraBars.BarButtonItem barButtonItem55;
        private DevExpress.XtraBars.BarButtonItem BTN_SYS_COLOR;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbiSkins;
        private DevExpress.XtraBars.BarButtonItem BTN_SET_PRO_PWD;
        private DevExpress.XtraBars.BarButtonItem BTN_SET_UN_PWD;
        private DevExpress.XtraBars.BarButtonItem JZBX_PWD;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup15;
        private DevExpress.XtraBars.BarButtonItem BTN_Win_Default;
        private DevExpress.XtraBars.BarButtonItem BTN_Win_SP;
        private DevExpress.XtraBars.BarButtonItem BTN_Win_FL;
        private DevExpress.XtraBars.BarButtonItem BTN_Win_Cas;
        private DevExpress.XtraBars.PopupControlContainer pccAppMenu;
        private DevExpress.XtraEditors.PanelControl pcAppMenuFileLabels;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar DefaultSBar;
        private DevExpress.XtraBars.BarMdiChildrenListItem MdiList;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem6;
        private DevExpress.XtraBars.BarButtonItem Bar_Sub_ListLib;
        private DevExpress.XtraBars.BarButtonItem Bar_Sub_FixLib;
        private DevExpress.XtraBars.BarButtonItem BTN_Fun_Js;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarButtonItem Btn_Fun_Log;
        //public DevExpress.XtraBars.BarButtonItem Btn_Fun_Rec;
        private System.Windows.Forms.Timer timer2;
        private DevExpress.XtraBars.BarButtonItem BTN_NET_MyInfo;
        private RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem BTN_SET_CONFIG;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private RibbonPage ribbonPage2;
        private RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem barButtonItem31;
        private DevExpress.XtraBars.BarButtonItem barButtonItem32;
        private DevExpress.XtraBars.BarButtonItem barButtonItem33;
        private DevExpress.XtraBars.BarButtonItem barButtonItem35;
        private RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem46;
        private DevExpress.XtraBars.BarButtonItem barButtonItem47;
        private DevExpress.XtraBars.BarButtonItem barButtonItem48;
        private DevExpress.XtraBars.BarButtonItem barButtonItem50;
        private DevExpress.XtraBars.BarButtonItem barButtonItem51;
        private DevExpress.XtraBars.BarButtonItem barButtonItem52;
        private DevExpress.XtraBars.BarButtonItem barButtonItem53;
        private DevExpress.XtraBars.BarButtonItem barButtonItem54;
        private DevExpress.XtraBars.BarButtonItem barButtonItem56;
        private DevExpress.XtraBars.BarButtonItem barButtonItem57;
        private DevExpress.XtraBars.BarButtonItem barButtonItem58;
        private DevExpress.XtraBars.BarButtonItem barButtonItem59;
        private DevExpress.XtraBars.BarButtonItem barButtonItem60;
        private DevExpress.XtraBars.BarButtonItem barButtonItem61;
        private DevExpress.XtraBars.BarButtonItem barButtonItem62;
        private RibbonStatusBar ProjSBar;
        private RibbonStatusBar UnitSBar;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem7;
        private DevExpress.XtraBars.BarStaticItem barStaticItem8;
        private DevExpress.XtraBars.BarStaticItem barStaticItem9;
        private DevExpress.XtraBars.BarStaticItem barStaticItem10;
        private DevExpress.XtraBars.BarStaticItem bar_txt_gczj;
        private DevExpress.XtraBars.BarStaticItem bar_txt_csxmf;
        private DevExpress.XtraBars.BarStaticItem bar_txt_qds;
        private DevExpress.XtraBars.BarStaticItem bar_txt_zms;
        private DevExpress.XtraBars.BarStaticItem bar_txt_cjs;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_NEW_Project;
        private DevExpress.XtraBars.BarButtonItem BTN_APP_NEW_Unit;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private RibbonPageGroup ribbonPageGroup14;
        private RibbonPageGroup ribbonPageGroup16;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup17;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup18;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup19;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup20;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup21;
        private DevExpress.XtraBars.BarButtonItem btnupdateInfo;
        private DevExpress.XtraBars.BarButtonItem btnzbOpen;
        private DevExpress.XtraBars.BarButtonItem btnzbInvite;
        private DevExpress.XtraBars.BarButtonItem btnzbPublish;
        private DevExpress.XtraBars.BarButtonItem btnzbCount;
        private DevExpress.XtraBars.BarButtonItem btnzbMyCount;
        private DevExpress.XtraBars.BarButtonItem btnzbBeginAnalyze;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup22;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup23;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup24;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup25;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup26;
        private DevExpress.XtraBars.BarButtonItem btnqjFlag;
        private DevExpress.XtraBars.BarCheckItem btnqjApplyCurrent;
        private DevExpress.XtraBars.BarCheckItem btnqjApplyNot;
        private DevExpress.XtraBars.BarCheckItem btnqjApplyAll;
        private DevExpress.XtraBars.BarButtonItem btnqjApplyBegin;

    }
}