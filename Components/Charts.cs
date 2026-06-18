using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WOWAuctionApi_Net10
{
    public partial class Charts : ComponentBase
    {
        public List<Realm> ShownRealms = new List<Realm>();
        public string ChartFilter = "";

        public Charts()
        {
            InitializeComponent();
        }

        public void SetUpCharts()
        {
            SetUpChart(chartTotalAuctions, $"Top {sc.Config.ChartTotalAuctions} Realms - Total Items On The Auction House", SeriesChartType.Column);
            SetUpChart(chartTopSearches, $"Top {sc.Config.ChartSearchHits} Realms - Search Hits For This Search", SeriesChartType.Column);
            SetUpChart(chartTotalValue, $"Top {sc.Config.ChartMarketValue} Realms - Total Region Market Value For This Search", SeriesChartType.Column);
        }

        private void SetUpChart(Chart chart1, String title, SeriesChartType chartType = SeriesChartType.Pie)
        {

            Color mainText;
            if (sc.UIOptions.ColorMode == SystemColorMode.Dark)
            {
                mainText = Color.White;
            }
            else
            {
                mainText = Color.Black;
            }
            chart1.Titles.Add(title);
            chart1.Titles[0].ForeColor = mainText;
            chart1.Titles[0].Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular);
            chart1.Titles[0].Docking = Docking.Top;


            chart1.Series.Clear();
            chart1.Legends.Clear();

            Series taSeries = new Series();
            taSeries.Name = "Series 1";
            taSeries.IsXValueIndexed = true;
            taSeries.ChartType = chartType;
            taSeries.IsValueShownAsLabel = true;
            taSeries.LabelForeColor = mainText;
            taSeries.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular);


            if (chartType == SeriesChartType.Doughnut)
            {
                chart1.Legends.Add("");
                chart1.Legends[0].Alignment = StringAlignment.Near;
                chart1.Legends[0].Docking = Docking.Right;
                chart1.Legends[0].BackColor = Color.Transparent;
                chart1.Legends[0].ForeColor = mainText;
                chart1.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular);
            }
            else if (chartType == SeriesChartType.Bar)
            {
                taSeries.Color = Color.IndianRed;
            }
            else
            {
                taSeries.Color = Color.CornflowerBlue;
            }

            chart1.Series.Add(taSeries);
            chart1.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.BorderSkin.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BorderColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = mainText;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = mainText;
            chart1.Visible = false;
        }

        public void RenderCharts()
        {
            ShownRealms.Clear();

            //Render Top X Total Value
            RenderChart(sc.Lists.RealmSearchCount, (int)sc.Config.ChartMarketValue, chartTotalValue);

            //Render Top X Search Hit Realms
            RenderChart(sc.Lists.RealmSearchCount, (int)sc.Config.ChartSearchHits, chartTopSearches);

            //Render Top X Total Auctions
            RenderChart(sc.Lists.TotalAuctionsCount, (int)sc.Config.ChartTotalAuctions, chartTotalAuctions);
        }

        private void RenderChart(List<RealmCount> originalList, int realmCount, Chart chartToRender)
        {
            chartToRender.Visible = true;
            chartToRender.Series[0].Points.Clear();
            List<RealmCount> sortedList;

            sortedList = originalList
                .OrderByDescending(p => chartToRender.Name == "chartTotalValue" ? p.TotalValue : p.Count)
                .Take(realmCount)
                .ToList();

            
            int count = 0;
            foreach (var realmInfo in sortedList)
            {

                count++;
                if (count > realmCount) { break; }
                int newPoint = chartToRender.Series[0].Points.AddXY(realmInfo.Realm.RealmName,
                    chartToRender.Name == "chartTotalValue" ? realmInfo.TotalValue / 10000 : realmInfo.Count);
                chartToRender.Series[0].Points[newPoint].Color = UIHelper.StringToColor(realmInfo.Realm.BackColor);

                if (ChartFilter == chartToRender.Name)
                {
                    ShownRealms.Add(realmInfo.Realm); 
                }
            }
        }

    }
}
