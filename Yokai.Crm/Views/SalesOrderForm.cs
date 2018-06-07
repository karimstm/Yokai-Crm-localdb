using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;
using Yokai.Crm.Report;

namespace Yokai.Crm
{
    public partial class SalesOrderForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int? _vendorId;
        private int? _contactId;
        private int? _personAdresseId;
        private int? _quoteId;
        private int? _accountId;

        public SalesOrderForm()
        {
            InitializeComponent();
        }

        private void LoadStatus()
        {
            var dt = PurchaseOrder.GetPurchaseStatus();
            cmbStatus.DataSource = dt;
            cmbStatus.DisplayMember = "OrderStatusName";
            cmbStatus.ValueMember = "OrderStatusId";
        }

        private void Enable(bool status)
        {
            MainPanel.Enabled = status;
        }

        private void FillSalesGrid()
        {
            var dt = SalesOrder.GetSalesOrder();
            SalesOrderGrid.DataSource = dt;
        }
        private void SalesOrderForm_Load(object sender, EventArgs e)
        {
            LoadStatus();
            Enable(false);
            FillSalesGrid();
            MenuDelete.Click += MenuDelete_Click;
            MenuUpdate.Click += MenuUpdate_Click;
            radMenuDelete.Click += RadMenuDelete_Click;
            radMenuUpdate.Click += RadMenuUpdate_Click;
            radMenuPrint.Click += RadMenuPrint_Click;
            PGridContext.Items.Add(MenuDelete);
            PGridContext.Items.Add(MenuUpdate);
        }

        private void RadMenuPrint_Click(object sender, EventArgs e)
        {
            CommandPrint_Click(null, null);
        }

        private void RadMenuUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(null, null);

        }

        private void RadMenuDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);

        }

        private void MenuUpdate_Click(object sender, EventArgs e)
        {
            RefillProductContext();
            CalculTotal();
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            ProductGrid.CurrentRow.Delete();
            CalculTotal();
        }

        void CalculMontant()
        {
            if (!string.IsNullOrWhiteSpace(txtqte.Text)
                && !string.IsNullOrWhiteSpace(txtprix.Text)
                && !string.IsNullOrWhiteSpace(txtid.Text))
            {
                var price = Convert.ToDecimal(txtprix.Text);
                var tva = Convert.ToDecimal(txttva.Text);
                decimal montant = (price * ( 1 + (tva/100))) * Convert.ToInt32(txtqte.Text);
                txtmontant.Text = montant.ToString(CultureInfo.InvariantCulture);

            }
        }

        void CalculTotal()
        {
            if (!string.IsNullOrWhiteSpace(txtid.Text))
            {
                decimal sum = 0;

                for (int i = 0; i <= ProductGrid.Rows.Count - 1; i++)
                {
                    sum += decimal.Parse(ProductGrid.Rows[i].Cells[5].Value.ToString());
                }

                txtTotal.Text = sum.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return;
            }
        }

        void CleatTxtProduct()
        {
            txtid.Clear();
            txtnom.Clear();
            txtprix.Clear();
            txttva.Clear();
            txtqte.Clear();
            txtmontant.Clear();
        }

        private void FillTxtBox()
        {
            DataTable dt =
                SalesOrder.SalesOrderById(SalesOrderGrid.CurrentRow.Cells[0].Value.ToString());
            if (dt == null) return;
            txtOrderNumber.Text = dt.Rows[0][0].ToString();
            txtRNumber.Text = dt.Rows[0][6].ToString();
            txtDevis.Text = dt.Rows[0][9].ToString();
            txtCarrier.Text = dt.Rows[0][10].ToString();
            cmbStatus.SelectedValue = dt.Rows[0][2].ToString();
            txtObject.Text = dt.Rows[0][5].ToString();
            txtVendorNam.Text = dt.Rows[0][17].ToString();
            txtContactName.Text = dt.Rows[0][18].ToString();
            txtAccount.Text = dt.Rows[0][19].ToString();
            dtpDueDate.Value = Convert.ToDateTime(dt.Rows[0][8].ToString());
            txtCommision.Text = dt.Rows[0][12].ToString();
            txtDuty.Text = dt.Rows[0][11].ToString();
            txtTerms.Text = dt.Rows[0][15].ToString();
            txtDescription.Text = dt.Rows[0][16].ToString();
            txtTotal.Text = dt.Rows[0][14].ToString();
            txtBillingAddress.Text = dt.Rows[0][20].ToString();
            txtBillingCity.Text = dt.Rows[0][21].ToString();
            txtBillingCountry.Text = dt.Rows[0][22].ToString();
            txtBillingZip.Text = dt.Rows[0][23].ToString();
            txtShippingAddress.Text = dt.Rows[0][24].ToString();
            txtShippingCity.Text = dt.Rows[0][25].ToString();
            txtShippingCountry.Text = dt.Rows[0][26].ToString();
            txtShippingZip.Text = dt.Rows[0][27].ToString();

            _personAdresseId = !string.IsNullOrEmpty(dt.Rows[0][13].ToString()) ? (int?)(int)dt.Rows[0][13] : null;
            _contactId = !string.IsNullOrEmpty(dt.Rows[0][3].ToString()) ? (int?)(int)dt.Rows[0][3] : null;
            _vendorId = !string.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? (int?)(int)dt.Rows[0][1] : null;
            _accountId = !string.IsNullOrEmpty(dt.Rows[0][4].ToString()) ? (int?)(int)dt.Rows[0][4] : null;
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Vendor.FillGrid(), ArgTable.Vendor);
            frm.ShowDialog();
            txtVendorNam.Text = frm._Name;
            _vendorId = frm._ID;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            txtShippingAddress.Text = txtBillingAddress.Text;
            txtShippingCity.Text = txtBillingCity.Text;
            txtShippingZip.Text = txtBillingZip.Text;
            txtShippingCountry.Text = txtBillingCountry.Text;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Products.GetProducts(), ArgTable.Product);
            frm.ShowDialog();
            txtid.Text = frm._Code;
            txtnom.Text = frm._Name;
            var price = frm._Prix;
            txtprix.Text = price.ToString(CultureInfo.InvariantCulture);
            var tva = frm._TVA;
            txttva.Text = tva.ToString();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            try
            {
                SearchForm frm = new SearchForm(Contact.GetContact(), ArgTable.Contact);
                frm.ShowDialog();
                txtContactName.Text = frm._Name;
                _contactId = frm._ID;
                DialogResult dr = MessageBox.Show(@"Do you want to use contact address?", "Message",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    var dt = PurchaseOrder.GetAddress((int)_contactId);
                    txtBillingAddress.Text = dt.Rows[0]["BillingStreet"].ToString();
                    txtBillingCity.Text = dt.Rows[0]["BillingCity"].ToString();
                    txtBillingCountry.Text = dt.Rows[0]["BillingCountry"].ToString();
                    txtBillingZip.Text = dt.Rows[0]["BillingCode"].ToString();
                    txtShippingAddress.Text = dt.Rows[0]["ShippingStreet"].ToString();
                    txtShippingCity.Text = dt.Rows[0]["ShippingCity"].ToString();
                    txtShippingCountry.Text = dt.Rows[0]["ShippingCoutry"].ToString();
                    txtShippingZip.Text = dt.Rows[0]["ShippingCode"].ToString();
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btnDevis_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Quotes.GetQuotes(), ArgTable.Quote);
            frm.ShowDialog();
            txtDevis.Text = frm._Name;
            _quoteId = frm._ID;

        }

        private void btnCompte_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Core.Account.GetGridAccount(), ArgTable.Account);
            frm.ShowDialog();
            txtAccount.Text = frm._Name;
            _accountId = frm._ID;
        }

        private void ProductGrid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            RefillProductContext();
        }

        private void RefillProductContext()
        {
            if (ProductGrid.Rows.Count != 0)
            {
                txtid.Text = ProductGrid.CurrentRow.Cells[0].Value.ToString();
                txtnom.Text = ProductGrid.CurrentRow.Cells[1].Value.ToString();
                txtprix.Text = ProductGrid.CurrentRow.Cells[2].Value.ToString();
                txttva.Text = ProductGrid.CurrentRow.Cells[3].Value.ToString();
                txtqte.Text = ProductGrid.CurrentRow.Cells[4].Value.ToString();
                txtmontant.Text = ProductGrid.CurrentRow.Cells[5].Value.ToString();
                ProductGrid.Rows.RemoveAt(ProductGrid.CurrentRow.Index);
                txtqte.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(MainPanel.Controls);
            _main.ClearTextBoxes(BillingGroup.Controls);
            _main.ClearTextBoxes(ShippingGroup.Controls);
            //int numRows = ProductGrid.Rows.Count;
            //for (int i = 0; i < numRows; i++)
            //{
            //    int max = ProductGrid.Rows.Count - 1;
            //    ProductGrid.Rows.Remove(ProductGrid.Rows[max]);
            //}
            ProductGrid.Rows.Clear();
            _main.IsBusy = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.IsBusy = false;
        }

        private void txtprix_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprix.Text))
                CalculMontant();
        }

        private void txtqte_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtqte.Text != @"0")
                {
                    for (int i = 0; i <= ProductGrid.Rows.Count - 1; i++)
                    {
                        if (ProductGrid.Rows[i].Cells[0].Value.ToString() == txtid.Text)
                        {
                            MessageBox.Show(@"Cet Produit Existe Déja", @"Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            CleatTxtProduct();
                            btnProduct.Focus();
                            return;
                        }
                    }
                    ProductGrid.Rows.Add(txtid.Text, txtnom.Text, txtprix.Text, txttva.Text, txtqte.Text,
                        txtmontant.Text);
                    CalculTotal();
                    txtid.Text = txtnom.Text = txtprix.Text = txttva.Text = txtqte.Text = txtmontant.Text = "";

                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void txtqte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtqte_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprix.Text) && !string.IsNullOrWhiteSpace(txtqte.Text))
                CalculMontant();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            bool changed = false;
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show(@"assurez-vous d'entrer le code de commande d'achat", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ProductId");
                dt.Columns.Add("UnitPrice");
                dt.Columns.Add("Qte");
                dt.Columns.Add("Total");
                foreach (GridViewRowInfo dr in ProductGrid.Rows)
                {
                    dt.Rows.Add(dr.Cells[0].Value, dr.Cells[2].Value, dr.Cells[4].Value, dr.Cells[5].Value);
                }

                if (_state == EntityState.Added)
                {
                    var result = await SalesOrder.SalesOrderInser(txtOrderNumber.Text, _vendorId,
                        Convert.ToInt32(cmbStatus.SelectedValue), _contactId, _accountId, txtObject.Text, txtRNumber.Text,                       
                        _quoteId, dtpDueDate.Value, txtCarrier.Text, Convert.ToDecimal(txtDuty.Text),
                        Convert.ToDecimal(txtCommision.Text),
                        Convert.ToDecimal(txtTotal.Text), txtTerms.Text, txtDescription.Text, txtBillingAddress.Text,
                        txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt);
                    MessageBox.Show(@"La commande d'achat a été ajoutée avec succès", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                else if (_state == EntityState.Changed)
                {
                    var result = await SalesOrder.SalesOrderUpdate(txtOrderNumber.Text, _vendorId, _personAdresseId,
                        Convert.ToInt32(cmbStatus.SelectedValue), _contactId, _accountId, txtObject.Text, txtRNumber.Text,
                        _quoteId, dtpDueDate.Value, txtCarrier.Text, Convert.ToDecimal(txtDuty.Text),
                        Convert.ToDecimal(txtCommision.Text),
                        Convert.ToDecimal(txtTotal.Text), txtTerms.Text, txtDescription.Text, txtBillingAddress.Text,
                        txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt);
                    MessageBox.Show(@"La commande d'achat a été mis a jour avec succès", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(MainPanel.Controls);
                _main.ClearDateTimePicker(MainPanel.Controls);
                _main.ClearDateTimePicker(BillingGroup.Controls);
                _main.ClearDateTimePicker(ShippingGroup.Controls);
                ProductGrid.Rows.Clear();
                FillSalesGrid();


            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                changed = true;
                MessageBox.Show(@"Le numéro d'identification existe déjà", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (SqlException exsql) when (exsql.Number == 547)
            {
                MessageBox.Show("Vous devez sélectionner un contact ou un nom de compte", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                changed = true;
            }
            finally
            {
                _main.IsBusy = false;
                if (changed == false)
                {
                    _state = EntityState.Unchanged;
                    _contactId = null;
                    _vendorId = null;
                }

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (SalesOrderGrid.Rows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner La commande d'achat.", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            try
            {
                DialogResult dialog = MessageBox.Show(@"Voulez-vous vraiment supprimer ce Commande?", @"Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    int result =
                        await SalesOrder.SalesOrderDelete(SalesOrderGrid.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show(@"La commande d'achat a été supprimé avec succès", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _main.IsBusy = false;
                _state = EntityState.Unchanged;
                FillSalesGrid();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (SalesOrderGrid.Rows.Count == 0)
                {
                    MessageBox.Show(@"Assurez-vous de sélectionner La commande d'achat.", @"Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                _state = EntityState.Changed;
                FillTxtBox();
                radPageView1.SelectedPage = MainPage;
                Enable(true);
                DataTable dt = new DataTable();
                dt = SalesOrder.Get_SalesOrderDetails_Product(txtOrderNumber.Text);
                ProductGrid.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductGrid.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4],
                        dt.Rows[i][5]);

                }

                CalculTotal();
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _main.IsBusy = false;
            }
        }

        private void ProductGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = PGridContext.DropDown;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearchNom.Text))
                {
                    SalesOrderGrid.DataSource = SalesOrder.SearchSalesOrder("Nom", txtSearchNom.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txtSearchId.Text))
                {
                    SalesOrderGrid.DataSource = SalesOrder.SearchSalesOrder("ID", txtSearchId.Text);
                }
                else
                {
                    FillSalesGrid();
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _main.IsBusy = false;
            }
        }

        private void CommandPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportingForm frm = new ReportingForm();
                InstanceReportSource reportSource = new InstanceReportSource();
                reportSource.Parameters.Add(new Telerik.Reporting.Parameter("Id", SalesOrderGrid.CurrentRow.Cells[0].Value.ToString()));
                reportSource.ReportDocument = new SalesOrderReport();
                frm.MainReportViewer.ReportSource = reportSource;
                frm.MainReportViewer.RefreshReport();
                frm.ShowDialog();

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void SalesOrderGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = SaleOrderGridContext.DropDown;
        }

        private void btnClearQuote_Click(object sender, EventArgs e)
        {
            _quoteId = null;
            txtDevis.Text = String.Empty;
        }

        private void btnClearVendor_Click(object sender, EventArgs e)
        {
            _vendorId = null;
            txtVendorNam.Text = String.Empty;

        }

        private void btnClearContact_Click(object sender, EventArgs e)
        {
            _contactId = null;
            txtContactName.Text = String.Empty;

        }

        private void btnClearCompte_Click(object sender, EventArgs e)
        {
            _accountId = null;
            txtAccount.Text = String.Empty;

        }
    }
}
