namespace GOLDSOFT.QDJJ.CTRL
{
    partial class PieChart
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel3 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions3 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PiePointOptions piePointOptions4 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView3 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel4 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView4 = new DevExpress.XtraCharts.PieSeriesView();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView4)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.BackColor = System.Drawing.Color.Transparent;
            this.chartControl1.BorderOptions.Color = System.Drawing.Color.Transparent;
            this.chartControl1.BorderOptions.Visible = false;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.LeftOutside;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            pieSeriesLabel3.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            pieSeriesLabel3.LineVisible = true;
            pieSeriesLabel3.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            series2.Label = pieSeriesLabel3;
            piePointOptions3.PointView = DevExpress.XtraCharts.PointView.Argument;
            series2.LegendPointOptions = piePointOptions3;
            series2.Name = "Series";
            piePointOptions4.PercentOptions.ValueAsPercent = false;
            series2.PointOptions = piePointOptions4;
            series2.SynchronizePointOptions = false;
            pieSeriesView3.RuntimeExploding = false;
            series2.View = pieSeriesView3;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            pieSeriesLabel4.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = pieSeriesLabel4;
            pieSeriesView4.RuntimeExploding = false;
            this.chartControl1.SeriesTemplate.View = pieSeriesView4;
            this.chartControl1.Size = new System.Drawing.Size(317, 221);
            this.chartControl1.TabIndex = 2;
            // 
            // PieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chartControl1);
            this.Name = "PieChart";
            this.Size = new System.Drawing.Size(317, 221);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}
