﻿namespace GOLDSOFT.QDJJ.UI
{
    partial class SelectGallery
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
            this.listGallery1 = new GOLDSOFT.QDJJ.CTRL.ListGallery();
            this.SuspendLayout();
            // 
            // listGallery1
            // 
            this.listGallery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGallery1.Location = new System.Drawing.Point(0, 0);
            this.listGallery1.Name = "listGallery1";
            this.listGallery1.Size = new System.Drawing.Size(416, 625);
            this.listGallery1.TabIndex = 0;
            // 
            // SelectGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 625);
            this.Controls.Add(this.listGallery1);
            this.Name = "SelectGallery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清单选择";
            this.Load += new System.EventHandler(this.SelectGallery_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GOLDSOFT.QDJJ.CTRL.ListGallery listGallery1;
    }
}