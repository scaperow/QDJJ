namespace GOLDSOFT.QDJJ.UI
{
    partial class ABaseForm
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
            this.functionList1 = new GOLDSOFT.QDJJ.CTRL.FunctionList();
            this.SuspendLayout();
            // 
            // functionList1
            // 
            this.functionList1.Activitie = null;
            this.functionList1.BackColor = System.Drawing.Color.Transparent;
            this.functionList1.CurrentBusiness = null;
            this.functionList1.DataSource = null;
            this.functionList1.Location = new System.Drawing.Point(373, 274);
            this.functionList1.Name = "functionList1";
            this.functionList1.Size = new System.Drawing.Size(48, 55);
            this.functionList1.TabIndex = 1;
            // 
            // ABaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 341);
            this.Controls.Add(this.functionList1);
            this.Name = "ABaseForm";
            this.Text = "ABaseForm";
            this.ResumeLayout(false);

        }

        #endregion

        public GOLDSOFT.QDJJ.CTRL.FunctionList functionList1;

    }
}