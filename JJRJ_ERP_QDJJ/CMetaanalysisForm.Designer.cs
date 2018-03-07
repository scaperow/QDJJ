namespace GOLDSOFT.QDJJ.UI
{
    partial class CMetaanalysisForm
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
            this.metaanalysisList1 = new GOLDSOFT.QDJJ.CTRL.MetaanalysisList();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // metaanalysisList1
            // 
            this.metaanalysisList1.Activitie = null;
            this.metaanalysisList1.BackColor = System.Drawing.Color.Transparent;
            this.metaanalysisList1.CurrentBusiness = null;
            this.metaanalysisList1.DataSource = null;
            this.metaanalysisList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaanalysisList1.Location = new System.Drawing.Point(0, 0);
            this.metaanalysisList1.Name = "metaanalysisList1";
            this.metaanalysisList1.SchemeColor = null;
            this.metaanalysisList1.Size = new System.Drawing.Size(671, 356);
            this.metaanalysisList1.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "hzfx";
            this.saveFileDialog1.Filter = "汇总分析文件|*.hzfx";
            this.saveFileDialog1.InitialDirectory = "模板文件\\汇总分析模板";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "hzfx";
            this.openFileDialog1.Filter = "汇总分析文件|*.hzfx";
            this.openFileDialog1.InitialDirectory = "模板文件\\汇总分析模板";
            // 
            // CMetaanalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 356);
            this.Controls.Add(this.metaanalysisList1);
            this.Name = "CMetaanalysisForm";
            this.Tag = "汇总分析";
            this.Text = "汇总分析";
            this.Load += new System.EventHandler(this.CMetaanalysisForm_Load);
            this.Controls.SetChildIndex(this.functionList1, 0);
            this.Controls.SetChildIndex(this.metaanalysisList1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private GOLDSOFT.QDJJ.CTRL.MetaanalysisList metaanalysisList1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}