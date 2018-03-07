namespace GOLDSOFT.QDJJ.CTRL
{
    partial class FunctionList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionList));
            this.imageListBoxControl1 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListBoxControl1
            // 
            this.imageListBoxControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.imageListBoxControl1.Appearance.Options.UseBackColor = true;
            this.imageListBoxControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imageListBoxControl1.BackgroundImage")));
            this.imageListBoxControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxControl1.ImageIndexMember = "ImageMember";
            this.imageListBoxControl1.ImageList = this.imageCollection1;
            this.imageListBoxControl1.ItemHeight = 24;
            this.imageListBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.imageListBoxControl1.Name = "imageListBoxControl1";
            this.imageListBoxControl1.Size = new System.Drawing.Size(142, 250);
            this.imageListBoxControl1.TabIndex = 0;
            this.imageListBoxControl1.ValueMember = "ValueMember";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "arrow.png");
            this.imageCollection1.Images.SetKeyName(1, "arrow1.png");
            // 
            // bindingSource1
            // 
            this.bindingSource1.PositionChanged += new System.EventHandler(this.bindingSource1_PositionChanged);
            // 
            // FunctionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageListBoxControl1);
            this.Name = "FunctionList";
            this.Size = new System.Drawing.Size(142, 250);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.BindingSource bindingSource1;
        public DevExpress.XtraEditors.ImageListBoxControl imageListBoxControl1;
    }
}
