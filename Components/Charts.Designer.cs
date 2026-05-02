namespace WOWAuctionApi_Net10
{
    partial class Charts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartTotalValue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTopSearches = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTotalAuctions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartTotalValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTopSearches).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTotalAuctions).BeginInit();
            SuspendLayout();
            // 
            // chartTotalValue
            // 
            chartTotalValue.BackColor = SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            chartTotalValue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTotalValue.Legends.Add(legend1);
            chartTotalValue.Location = new Point(0, 2);
            chartTotalValue.Name = "chartTotalValue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartTotalValue.Series.Add(series1);
            chartTotalValue.Size = new Size(1100, 480);
            chartTotalValue.TabIndex = 137;
            chartTotalValue.Text = "chart1";
            chartTotalValue.Visible = false;
            // 
            // chartTopSearches
            // 
            chartTopSearches.BackColor = SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            chartTopSearches.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartTopSearches.Legends.Add(legend2);
            chartTopSearches.Location = new Point(0, 501);
            chartTopSearches.Name = "chartTopSearches";
            chartTopSearches.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTopSearches.Series.Add(series2);
            chartTopSearches.Size = new Size(1100, 480);
            chartTopSearches.TabIndex = 136;
            chartTopSearches.Text = "chart2";
            chartTopSearches.Visible = false;
            // 
            // chartTotalAuctions
            // 
            chartTotalAuctions.BackColor = SystemColors.Control;
            chartArea3.Name = "ChartArea1";
            chartTotalAuctions.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartTotalAuctions.Legends.Add(legend3);
            chartTotalAuctions.Location = new Point(0, 1009);
            chartTotalAuctions.Name = "chartTotalAuctions";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartTotalAuctions.Series.Add(series3);
            chartTotalAuctions.Size = new Size(1100, 480);
            chartTotalAuctions.TabIndex = 135;
            chartTotalAuctions.Tag = "";
            chartTotalAuctions.Text = "chart1";
            chartTotalAuctions.Visible = false;
            // 
            // Charts
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(chartTotalValue);
            Controls.Add(chartTopSearches);
            Controls.Add(chartTotalAuctions);
            Name = "Charts";
            Size = new Size(1100, 1490);
            ((System.ComponentModel.ISupportInitialize)chartTotalValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTopSearches).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTotalAuctions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSearches;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalAuctions;
    }
}
