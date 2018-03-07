namespace GOLDSOFT.QDJJ.UI
{
    partial class BaseMC
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
            this.MCFLbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MCQDQDbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MCQDDEbindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCFLbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCQDQDbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCQDDEbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 440);
            this.Name = "BaseMC";
            this.Text = "BaseMC";
            this.Load += new System.EventHandler(this.BaseMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCFLbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCQDQDbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCQDDEbindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.BindingSource MCFLbindingSource;
        protected System.Windows.Forms.BindingSource MCQDQDbindingSource;
        protected System.Windows.Forms.BindingSource MCQDDEbindingSource;

    }
}