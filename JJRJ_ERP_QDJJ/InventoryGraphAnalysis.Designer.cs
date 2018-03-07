namespace GOLDSOFT.QDJJ.CTRL
{
    partial class InventoryGraphAnalysis
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
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.graphAnalysis1 = new GOLDSOFT.QDJJ.CTRL.GraphAnalysis();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.graphAnalysis1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(742, 266);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // graphAnalysis1
            // 
            this.graphAnalysis1.BackColor = System.Drawing.Color.Transparent;
            this.graphAnalysis1.DataSource = null;
            this.graphAnalysis1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.graphAnalysis1.Name = "graphAnalysis1";
            this.graphAnalysis1.ShowName = null;
            this.graphAnalysis1.Size = new System.Drawing.Size(742, 266);
            this.graphAnalysis1.TabIndex = 0;
            this.graphAnalysis1.ValueName = "";
            // 
            // InventoryGraphAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 266);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "InventoryGraphAnalysis";
            this.Text = "InventoryGraphAnalysis";
            this.Load += new System.EventHandler(this.InventoryGraphAnalysis_Load);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private GraphAnalysis graphAnalysis1;



    }
}