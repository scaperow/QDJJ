namespace GOLDSOFT.QDJJ.UI
{
    partial class SelectFixed
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
            this.fixedLibrary1 = new GOLDSOFT.QDJJ.CTRL.FixedLibrary();
            this.SuspendLayout();
            // 
            // fixedLibrary1
            // 
            this.fixedLibrary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixedLibrary1.Location = new System.Drawing.Point(0, 0);
            this.fixedLibrary1.Name = "fixedLibrary1";
            this.fixedLibrary1.Size = new System.Drawing.Size(414, 517);
            this.fixedLibrary1.TabIndex = 0;
            this.fixedLibrary1.Load += new System.EventHandler(this.SelectGallery_Load);
            // 
            // SelectFixed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 517);
            this.Controls.Add(this.fixedLibrary1);
            this.Name = "SelectFixed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择子目";
            this.ResumeLayout(false);

        }

        #endregion

        private GOLDSOFT.QDJJ.CTRL.FixedLibrary fixedLibrary1;
    }
}