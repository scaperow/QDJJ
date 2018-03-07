namespace GOLDSOFT.QDJJ.UI
{
    partial class Container
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
            DevExpress.XtraBars.Alerter.AlertButton alertButton1 = new DevExpress.XtraBars.Alerter.AlertButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Container));
            this.bWorker_Save = new System.ComponentModel.BackgroundWorker();
            this.dManagerObject = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dp_Project = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dp_Function = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dManagerObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dp_Project.SuspendLayout();
            this.dp_Function.SuspendLayout();
            this.SuspendLayout();
            // 
            // bWorker_Save
            // 
            this.bWorker_Save.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorker_Save_DoWork);
            this.bWorker_Save.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWorker_Save_RunWorkerCompleted);
            this.bWorker_Save.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorker_Save_ProgressChanged);
            // 
            // dManagerObject
            // 
            this.dManagerObject.DockingOptions.ShowCaptionImage = true;
            this.dManagerObject.DockingOptions.ShowCloseButton = false;
            this.dManagerObject.Form = this;
            this.dManagerObject.Images = this.imageCollection1;
            this.dManagerObject.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1});
            this.dManagerObject.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "项目清单.png");
            this.imageCollection1.Images.SetKeyName(1, "功能列表.png");
            // 
            // panelContainer1
            // 
            this.panelContainer1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.panelContainer1.Appearance.Options.UseBackColor = true;
            this.panelContainer1.Controls.Add(this.dp_Project);
            this.panelContainer1.Controls.Add(this.dp_Function);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("8d8d82c1-7c54-4afe-ab0d-6df85a7a6969");
            this.panelContainer1.Location = new System.Drawing.Point(483, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(200, 408);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dp_Project
            // 
            this.dp_Project.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.dp_Project.Appearance.Options.UseBackColor = true;
            this.dp_Project.Controls.Add(this.dockPanel1_Container);
            this.dp_Project.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dp_Project.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dp_Project.FloatVertical = true;
            this.dp_Project.ID = new System.Guid("0bec1d52-2064-4963-b690-cd6d31dae7c4");
            this.dp_Project.ImageIndex = 0;
            this.dp_Project.Location = new System.Drawing.Point(0, 0);
            this.dp_Project.Name = "dp_Project";
            this.dp_Project.Options.ShowCloseButton = false;
            this.dp_Project.OriginalSize = new System.Drawing.Size(200, 204);
            this.dp_Project.Size = new System.Drawing.Size(200, 204);
            this.dp_Project.Text = "项目列表";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(194, 176);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dp_Function
            // 
            this.dp_Function.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.dp_Function.Appearance.Options.UseBackColor = true;
            this.dp_Function.Controls.Add(this.dockPanel2_Container);
            this.dp_Function.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dp_Function.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dp_Function.ID = new System.Guid("23d463e3-bbbc-4a5a-8e84-ce3c968ee2cd");
            this.dp_Function.ImageIndex = 1;
            this.dp_Function.Location = new System.Drawing.Point(0, 204);
            this.dp_Function.Name = "dp_Function";
            this.dp_Function.Options.ShowCloseButton = false;
            this.dp_Function.OriginalSize = new System.Drawing.Size(200, 200);
            this.dp_Function.Size = new System.Drawing.Size(200, 204);
            this.dp_Function.Text = "功能区域";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(194, 176);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // alertControl1
            // 
            alertButton1.Name = "alertButton1";
            this.alertControl1.Buttons.Add(alertButton1);
            this.alertControl1.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertControl1_AlertClick);
            this.alertControl1.ButtonClick += new DevExpress.XtraBars.Alerter.AlertButtonClickEventHandler(this.alertControl1_ButtonClick);
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 408);
            this.Controls.Add(this.panelContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Container";
            this.Text = "Container";
            this.Load += new System.EventHandler(this.Container_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dManagerObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dp_Project.ResumeLayout(false);
            this.dp_Function.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bWorker_Save;
        public DevExpress.XtraBars.Docking.DockManager dManagerObject;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        public DevExpress.XtraBars.Docking.DockPanel dp_Function;
        public DevExpress.XtraBars.Docking.DockPanel dp_Project;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        public System.Windows.Forms.Timer timer1;

    }
}