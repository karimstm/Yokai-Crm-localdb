using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Yokai.Crm.Logic;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class SearchForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private DataTable _dt;
        public string _Name;
        public int? _ID;
        public string _Code;
        public decimal _Prix;
        public decimal? _TVA;
        public ArgTable CurrentTable;
        public SearchForm(DataTable dt, ArgTable table)
        {
            InitializeComponent();
            _dt = dt;
            CurrentTable = table;
        }

        private void GetSource()
        {
            if (ProspectSource.GetAll() == null)
                return;
            CmbSource2.DataSource = ProspectSource.GetAll();
            CmbSource2.ValueMember = "ProspectSourceId";
            CmbSource2.DisplayMember = "ProspectSourceName";
        }
        private void GetStatus()
        {
            if (ProspectStatus.GetAll() == null)
                return;
            CmbStatus2.DataSource = ProspectStatus.GetAll();
            CmbStatus2.ValueMember = "ProspectStatusId";
            CmbStatus2.DisplayMember = "ProspectStatusName";

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            GetSource();
            GetStatus();
            SearchView.DataSource = _dt;
            if (CurrentTable == ArgTable.Account)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;
            }
            if (CurrentTable == ArgTable.Vendor)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;
            }
            if (CurrentTable == ArgTable.Product)
            {
                radGroupBox1.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;
            }
            if (CurrentTable == ArgTable.Contact)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox1.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;
            }
            if (CurrentTable == ArgTable.Quote)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;
            }
            if (CurrentTable == ArgTable.Compagne)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;

            }
            if (CurrentTable == ArgTable.SalesOrder)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox1.Enabled = false;
                radGroupBox8.Enabled = false;
                radGroupBox9.Enabled = false;

            }
            if (CurrentTable == ArgTable.PurchaseOrder)
            {
                radGroupBox2.Enabled = false;
                radGroupBox3.Enabled = false;
                radGroupBox4.Enabled = false;
                radGroupBox5.Enabled = false;
                radGroupBox6.Enabled = false;
                radGroupBox7.Enabled = false;
                radGroupBox1.Enabled = false;

            }

        }

        private void SearchView_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (CurrentTable == ArgTable.Account)
                {
                    _ID = (int)SearchView.CurrentRow.Cells[0].Value;
                    _Name = SearchView.CurrentRow.Cells[1].Value.ToString();
                }
                if (CurrentTable == ArgTable.Vendor)
                {
                    _ID = Convert.ToInt32(SearchView.CurrentRow.Cells[0].Value.ToString());
                    _Name = SearchView.CurrentRow.Cells[1].Value.ToString();
                }

                if (CurrentTable == ArgTable.Product)
                {
                    _Code = SearchView.CurrentRow.Cells[0].Value.ToString();
                    _Name = SearchView.CurrentRow.Cells[4].Value.ToString();
                    _Prix = decimal.Parse(SearchView.CurrentRow.Cells[8].Value.ToString());
                    _TVA = string.IsNullOrEmpty(SearchView.CurrentRow.Cells[7].Value.ToString()) ? 0 : (decimal)(SearchView.CurrentRow.Cells[7].Value);

                }
                if (CurrentTable == ArgTable.Contact)
                {
                    _ID = Convert.ToInt32(SearchView.CurrentRow.Cells[0].Value.ToString());
                    _Name = SearchView.CurrentRow.Cells[1].Value.ToString() + ' ' +
                           SearchView.CurrentRow.Cells[2].Value.ToString();
                }
                if (CurrentTable == ArgTable.Quote)
                {
                    _ID = (int)SearchView.CurrentRow.Cells[0].Value;
                    _Name = SearchView.CurrentRow.Cells[3].Value.ToString();
                }

                if (CurrentTable == ArgTable.Compagne)
                {
                    _ID = (int)SearchView.CurrentRow.Cells[0].Value;
                    _Name = SearchView.CurrentRow.Cells[1].Value.ToString();
                }
                if (CurrentTable == ArgTable.PurchaseOrder)
                {
                    _Code = SearchView.CurrentRow.Cells[0].Value.ToString();
                    _Name = SearchView.CurrentRow.Cells[1].Value.ToString();
                }
                if (CurrentTable == ArgTable.SalesOrder)
                {
                    _Code = SearchView.CurrentRow.Cells[0].Value.ToString();
                    _Name = SearchView.CurrentRow.Cells[5].Value.ToString();
                }
                this.Close();
            }
            catch (Exception)
            {

                //
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (CurrentTable == ArgTable.Account)
            {
                var dt = Core.Account.GetSearchAccount(txtSearch.Text);
                SearchView.DataSource = dt;
            }
            if (CurrentTable == ArgTable.Quote)
            {
                var dt = Core.Quotes.QuoteSearch(txtSearch.Text);
                SearchView.DataSource = dt;
            }
            if (CurrentTable == ArgTable.Compagne)
            {
                SearchView.DataSource = Campaign.GetSearchedCampaign(txtSearch.Text);
            }
            if (CurrentTable == ArgTable.Vendor)
            {
                SearchView.DataSource = Vendor.SearchVendor(txtSearch.Text);
            }


        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (CurrentTable == ArgTable.Account)
            {
                var dt = Core.Account.GetGridAccount();
                SearchView.DataSource = dt;
            }
            if (CurrentTable == ArgTable.Quote)
            {
                var dt = Core.Quotes.GetQuotes();
                SearchView.DataSource = dt;
            }
            if (CurrentTable == ArgTable.Compagne)
            {
                var dt = Core.Campaign.GetCampaigns();
                SearchView.DataSource = dt;
            }
            if (CurrentTable == ArgTable.Vendor)
            {
                var dt = Vendor.FillGrid();
                SearchView.DataSource = dt;
            }

        }

        private void btnSearchCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchId.Text))
            {
                SearchView.DataSource = Products.SearchProduct("Id", txtSearchId.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtSearchSN.Text))
            {
                SearchView.DataSource = Products.SearchProduct("Sn", txtSearchSN.Text);
            }
            else
            {
                var dt = Products.GetProducts();
                SearchView.DataSource = dt;
            }

        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
            {
                SearchView.DataSource = Products.SearchProduct("Name", txtSearchName.Text);
            }
            else
            {
                var dt = Products.GetProducts();
                SearchView.DataSource = dt;
            }

        }

        private void btnSearchSourceStatu_Click(object sender, EventArgs e)
        {
            DataTable dt = Contact.SearchByStautSource((int)CmbSource2.SelectedValue, (int)CmbStatus2.SelectedValue);

            if (CmbSource2.Text != string.Empty || CmbStatus2.Text != string.Empty)
            {
                SearchView.DataSource = dt;
            }
            else
            {
                var dt1 = Contact.GetContact();
                SearchView.DataSource = dt1;
            }

        }

        private void btnSearchContacId_Click(object sender, EventArgs e)
        {
            DataTable dt = Contact.SearchByContactId(txtId2.Text);

            if (txtId2.Text != string.Empty)
            {
                SearchView.DataSource = dt;
            }
            else
            {
                var dt1 = Contact.GetContact();
                SearchView.DataSource = dt1;

            }

        }

        private void btnSearchNamComp_Click(object sender, EventArgs e)
        {
            DataTable dt = Contact.SearchByName(txtFirstName2.Text, txtLastName2.Text);

            if (txtFirstName2.Text != string.Empty || txtLastName2.Text != string.Empty)
            {
                SearchView.DataSource = dt;
            }
            else
            {
                var dt1 = Contact.GetContact();
                SearchView.DataSource = dt1;

            }

        }

        private void btnSearchCommand_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchNom.Text))
            {
                SearchView.DataSource = SalesOrder.SearchSalesOrder("Nom", txtSearchNom.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtSearchCmdId.Text))
            {
                SearchView.DataSource = SalesOrder.SearchSalesOrder("ID", txtSearchCmdId.Text);
            }
            else
            {
                //Reload Grid
                var dt = SalesOrder.GetSalesOrder();
                SearchView.DataSource = dt;
            }

        }

        private void btnReloadCon_Click(object sender, EventArgs e)
        {
            //Reload Grid
            var dt = Contact.GetContact();
            SearchView.DataSource = dt;

        }

        private void btnReloadCont_Click(object sender, EventArgs e)
        {
            //Reload Grid
            btnReloadCon_Click(null, null);
        }

        private void btnReloadConta_Click(object sender, EventArgs e)
        {
            //Reload Grid
            btnReloadCon_Click(null, null);
        }

        private void btnSearchCom_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNumCom.Text))
            {
                SearchView.DataSource = PurchaseOrder.SearchPurchaseOrder("Id", txtNumCom.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtNumDem.Text))
            {
                SearchView.DataSource = PurchaseOrder.SearchPurchaseOrder("Serie", txtNumDem.Text);
            }
            else
            {
                return;
            }

        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            SearchView.DataSource = PurchaseOrder.SearchPurchaseOrderByDate(Convert.ToDateTime(dtpDateAchat.Value),
                Convert.ToDateTime(dtpDateEche.Value));

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            SearchView.DataSource = PurchaseOrder.GET_PURCHASE_ORDER();

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radButton2_Click(null, null);
        }
    }
}
