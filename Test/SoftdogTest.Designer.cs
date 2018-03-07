namespace Test
{
    partial class SoftdogTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonValidateHardware = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonValidateHardware
            // 
            this.ButtonValidateHardware.Location = new System.Drawing.Point(13, 13);
            this.ButtonValidateHardware.Name = "ButtonValidateHardware";
            this.ButtonValidateHardware.Size = new System.Drawing.Size(134, 23);
            this.ButtonValidateHardware.TabIndex = 0;
            this.ButtonValidateHardware.Text = "ValidateHardware";
            this.ButtonValidateHardware.UseVisualStyleBackColor = true;
            this.ButtonValidateHardware.Click += new System.EventHandler(this.ButtonValidateHardware_Click);
            // 
            // SoftdogTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ButtonValidateHardware);
            this.Name = "SoftdogTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonValidateHardware;
    }
}

