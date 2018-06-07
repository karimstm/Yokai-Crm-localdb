using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class DashboardForm : Telerik.WinControls.UI.RadForm
    {
        Color[] barColors = new Color[9]{
            Color.FromArgb(255, 135, 135),
            Color.FromArgb(255, 171, 215),
            Color.FromArgb(165, 146, 247),
            Color.FromArgb(69, 176, 247),
            Color.FromArgb(35, 236, 255),
            Color.FromArgb(81, 253, 199),
            Color.FromArgb(124, 237, 138),
            Color.FromArgb(198, 237, 124),
            Color.FromArgb(255, 152, 126)
        };

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardPages_SelectedPageChanged(object sender, EventArgs e)
        {
                if (DashboardPages.SelectedPage == LeadDashboard)
                {
                    LoadCharts(FirstChart, "NumberOfLeads", "ProspectSourceName", Statistic.LeadBySource(), "Origin du Prospect");
                    LoadCharts(SecondChart, "NumberofProspect", "ProspectStatusName", Statistic.LeadByStatus(), "Statut du Prospect");

                }
                else if (DashboardPages.SelectedPage == ContactDashboard)
                {
                    SalesForAccountGrid.DataSource = Statistic.SalesForAccount();
                }
                else if (DashboardPages.SelectedPage == AffaireDashboard)
                {
                    FunnelChart(ChartEtapes, "Sales", "SalesStage", Statistic.GetBySaleStage(), " ");
                    LoadCharts(ChartProbability, "NumberOfProbability", "Probability", Statistic.GetByProbability(), "Probability");
                    LoadCharts(ChartType, "NumberOfTypee", "Typee", Statistic.GetByType(), "Type");
                }
                else if (DashboardPages.SelectedPage == ProduitDashboard)
                {
                    LoadCharts(ChartProduct, "NumberOfProduct", "CategoryName", Statistic.GetByCategorie(), "Catégorie de Produit");
                }
                else if (DashboardPages.SelectedPage == campagneDashboard)
                {
                    LoadCharts(CompaignFirstChart, "NumberofCampaign", "CampaignName", Statistic.GetCampainsNumber(), "Nom de la Campagne");
                }
                else if (DashboardPages.SelectedPage == Dashboardinventaire)
                {
                    PieChart(PurchaseChartForVendor, "NumberOfPurchase", "VendorName", Statistic.GetNumberOfPurchaseVendor(), "Nom du Fournisseur");
                    LoadCharts(SaleOrderChart, "NumberOfSaleOrder", "AccountName", Statistic.GetNumberOfSaleOrder(), "Nom du Compte");
                    FunnelChart(PurchseChart, "NumberOfPurchase", "FullName", Statistic.GetNumberOfPurchaseOrder(), "");
                    PieChart(ChartStatus, "NumberOfPurchase", "OrderStatusName", Statistic.GetNumberOfStatus(), "");
                    FunnelChart(InvoiceChart, "NumberOfInvoice", "AccountName", Statistic.GetNumberOfInvoice(), "");
                    FunnelChart(InvoiceStatusChart, "NumberOfInvoice", "OrderStatusName", Statistic.GetNumberOfStatusInvoice(), "");

                }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

                LoadCharts(FirstChart, "NumberOfLeads", "ProspectSourceName", Statistic.LeadBySource(), "Origin du Prospect");
                LoadCharts(SecondChart, "NumberofProspect", "ProspectStatusName", Statistic.LeadByStatus(), "Statut du Prospect");
        }


        private void DashboardPages_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            
 
        }

        private void LoadCharts(RadChartView chart ,string _y, string _x, DataTable _source, string axesTitle)
        {
            chart.Series.Clear();

            ChartSeries barSeries = new BarSeries(_y, _x);
            barSeries.Name = "Q1";
            barSeries.ShowLabels = true;
            barSeries.BorderBottomWidth = 0;
            
            DataTable dt = _source;
            foreach (DataRow item in dt.Rows)
            {
                barSeries.DataPoints.Add(new CategoricalDataPoint((int) item[_y],
                    item[_x].ToString()));
            }

            chart.Series.Add(barSeries);
            int count = 0;
            foreach (var child in chart.Series[0].Children)
            {
                if (count > barColors.Length - 1)
                    count = 0;
                //child.ForeColor = barColors[count];
                child.BackColor = barColors[count];
                child.BorderColor = Color.Transparent;
                count++;
            }

            chart.Axes[0].LabelFitMode = AxisLabelFitMode.Rotate;
            chart.Axes[0].LabelRotationAngle = 290;
            chart.Axes[1].ShowLabels = false;
            chart.Axes[0].Title = axesTitle;
            //chart.Series[0].BorderBoxStyle = BorderBoxStyle.SingleBorder;


        }
        private void FunnelChart(RadChartView chart, string _y, string _x, DataTable _source, string axesTitle)
        {
            chart.Series.Clear();

            FunnelSeries funnelSeries = new FunnelSeries(_y, _x);
            funnelSeries.ShowLabels = true;
            chart.ShowLegend = true;

            DataTable dt = _source;
            foreach (DataRow item in dt.Rows)
            {
               funnelSeries.DataPoints.Add(new FunnelDataPoint(Convert.ToDouble(item[_y]),
                    item[_x].ToString()));
            }

            chart.Series.Add(funnelSeries);
            int count = 0;
            foreach (var child in chart.Series[0].Children)
            {
                if (count > barColors.Length - 1)
                    count = 0;
                child.BackColor = barColors[count];
                child.BorderColor = Color.Transparent;
                count++;
            }

        }
        private void PieChart(RadChartView chart, string _y, string _x, DataTable _source, string axesTitle)
        {
            chart.Series.Clear();

            PieSeries series = new PieSeries(_y, _x);
            series.ShowLabels = true;
            chart.ShowLegend = true;
            
            DataTable dt = _source;
            foreach (DataRow item in dt.Rows)
            {
                series.DataPoints.Add(new PieDataPoint(Convert.ToDouble(item[_y]),
                    item[_x].ToString()));
            }

            chart.Series.Add(series);
            int count = 0;
            foreach (var child in chart.Series[0].Children)
            {
                if (count > barColors.Length - 1)
                    count = 0;
                child.BackColor = barColors[count];
                child.BorderColor = Color.Transparent;
                count++;
            }

        }

    }
}
