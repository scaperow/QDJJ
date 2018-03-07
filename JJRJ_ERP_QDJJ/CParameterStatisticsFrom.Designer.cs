namespace GOLDSOFT.QDJJ.UI
{
    partial class CParameterStatisticsFrom
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.projectTrees1 = new GOLDSOFT.QDJJ.CTRL.ProjectTrees();
            this.variableList1 = new GOLDSOFT.QDJJ.CTRL.VariableList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.projectTrees1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.variableList1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(648, 470);
            this.splitContainerControl1.SplitterPosition = 192;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // projectTrees1
            // 
            this.projectTrees1.Activitie = null;
            this.projectTrees1.CurrBusiness = null;
            this.projectTrees1.CurrentBusiness = null;
            this.projectTrees1.DataSource = null;
            this.projectTrees1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTrees1.isRight = true;
            this.projectTrees1.Location = new System.Drawing.Point(0, 0);
            this.projectTrees1.Name = "projectTrees1";
            this.projectTrees1.ProjectName = "项目解决方案";
            this.projectTrees1.Size = new System.Drawing.Size(192, 470);
            this.projectTrees1.TabIndex = 0;
            // 
            // variableList1
            // 
            this.variableList1.Activitie = null;
            this.variableList1.CurrentBusiness = null;
            this.variableList1.DataSource = null;
            this.variableList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableList1.Location = new System.Drawing.Point(0, 0);
            this.variableList1.Name = "variableList1";
            this.variableList1.Size = new System.Drawing.Size(450, 470);
            this.variableList1.TabIndex = 0;
            // 
            // CParameterStatisticsFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 470);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "CParameterStatisticsFrom";
            this.Tag = "参数统计";
            this.Text = "参数统计";
            this.Load += new System.EventHandler(this.CParameterStatisticsFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private GOLDSOFT.QDJJ.CTRL.ProjectTrees projectTrees1;
        private GOLDSOFT.QDJJ.CTRL.VariableList variableList1;
    }
}
