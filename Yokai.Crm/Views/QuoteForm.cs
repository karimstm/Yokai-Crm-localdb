using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    public partial class QuoteForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int? _ContactId;
        private int? _PersonAdresseId;
        private int? _AccountId;
        private int? _OpportunityId;
        private int? _QuoteId;

        public QuoteForm()
        {
            InitializeComponent();
        }

        private void FillGridQuote()
        {
            var dt = Quotes.GetQuotes();
            GridQuote.DataSource = dt;
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
        private void Enable(bool status)
        {
            MainPanel.Enabled = status;
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
                Quotes.QuoteById(Convert.ToInt32(GridQuote.CurrentRow.Cells[0].Value.ToString()));
            if (dt == null) return;
            txtSubject.Text = dt.Rows[0][3].ToString();
            txtOpp.Text = dt.Rows[0][12].ToString();
            dtpValidUntil.Value = Convert.ToDateTime(dt.Rows[0][7].ToString());
            txtTeam.Text = dt.Rows[0][5].ToString();
            txtStage.Text = dt.Rows[0][4].ToString();
            txtCarrier.Text = dt.Rows[0][6].ToString();
            txtContact.Text = dt.Rows[0][13].ToString();
            txtAccount.Text = dt.Rows[0][14].ToString();
            txtTerms.Text = dt.Rows[0][10].ToString();
            txtDescription.Text = dt.Rows[0][8].ToString();
            txtTotal.Text = dt.Rows[0][9].ToString();
            txtBillingAddress.Text = dt.Rows[0][15].ToString();
            txtBillingCity.Text = dt.Rows[0][16].ToString();
            txtBillingCountry.Text = dt.Rows[0][17].ToString();
            txtBillingZip.Text = dt.Rows[0][18].ToString();
            txtShippingAddress.Text = dt.Rows[0][19].ToString();
            txtShippingCity.Text = dt.Rows[0][20].ToString();
            txtShippingCountry.Text = dt.Rows[0][21].ToString();
            txtShippingZip.Text = dt.Rows[0][22].ToString();

            _PersonAdresseId = !string.IsNullOrEmpty(dt.Rows[0][11].ToString()) ? (int?)(int)dt.Rows[0][11] : null;
            _ContactId = !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? (int?)(int)dt.Rows[0][0] : null;
            _AccountId = !string.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? (int?)(int)dt.Rows[0][1] : null;
            _OpportunityId = !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? (int?)(int)dt.Rows[0][2] : null;
            _QuoteId = (int)GridQuote.CurrentRow.Cells[0].Value;
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
        private void QuoteForm_Load(object sender, EventArgs e)
        {
            FillGridQuote();
            Enable(false);
            MenuDelete.Click += MenuDelete_Click;
            MenuUpdate.Click += MenuUpdate_Click;
            PGridContext.Items.Add(MenuUpdate);
            PGridContext.Items.Add(MenuDelete);
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
        private void btnCompte_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Core.Account.GetGridAccount(), ArgTable.Account);
            frm.ShowDialog();
            txtAccount.Text = frm._Name;
            _AccountId = frm._ID;

        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            try
            {
                SearchForm frm = new SearchForm(Contact.GetContact(), ArgTable.Contact);
                frm.ShowDialog();
                txtContact.Text = frm._Name;
                _ContactId = frm._ID;

                DialogResult dr = MessageBox.Show(@"Do you want to use contact address?", "Message",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    if (_ContactId != null)
                    {
                        var dt = PurchaseOrder.GetAddress((int)_ContactId);
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


            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            bool changed = false;
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
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
                    int result = await Quotes.QuoteInsert(_ContactId, _AccountId, _OpportunityId, txtSubject.Text,
                        txtStage.Text, txtTeam.Text, txtCarrier.Text, Convert.ToDateTime(dtpValidUntil.Value),
                        txtDescription.Text,
                        Convert.ToDecimal(txtTotal.Text), txtTerms.Text, txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text,
                        txtBillingAddress.Text,
                        txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt);
                    MessageBox.Show(@"Devis a été ajoutée avec succès", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                else if (_state == EntityState.Changed)
                {
                    int result = await Quotes.QuoteUpdate(_QuoteId, _ContactId, _AccountId, _OpportunityId, txtSubject.Text,
                        txtStage.Text, txtTeam.Text, txtCarrier.Text, Convert.ToDateTime(dtpValidUntil.Value),
                        _PersonAdresseId, txtDescription.Text,
                        Convert.ToDecimal(txtTotal.Text), txtTerms.Text, txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text,
                        txtBillingAddress.Text,
                        txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt);
                    MessageBox.Show(@"Devis a été mis a jour avec succès", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(MainPanel.Controls);
                _main.ClearDateTimePicker(MainPanel.Controls);
                _main.ClearTextBoxes(BillingGroup.Controls);
                _main.ClearTextBoxes(ShippingGroup.Controls);
                ProductGrid.Rows.Clear();
                FillGridQuote();

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
                    _ContactId = null;
                    _AccountId = null;
                    _OpportunityId = null;
                }

            }

        }

        private void txtprix_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprix.Text))
                CalculMontant();
        }

        private void txtqte_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprix.Text) && !string.IsNullOrWhiteSpace(txtqte.Text))
                CalculMontant();
        }

        private void txtqte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtqte_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtqte.Text != "0")
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

        private void txtprix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.IsBusy = false;
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
            _main.ClearDateTimePicker(dtpValidUntil.Controls);
            ProductGrid.Rows.Clear();
            _main.IsBusy = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (GridQuote.Rows.Count == 0)
                {
                    MessageBox.Show(@"Assurez-vous de sélectionner La Devis.", @"Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                _state = EntityState.Changed;
                FillTxtBox();
                PageViewer.SelectedPage = MainPage;
                Enable(true);
                DataTable dt = new DataTable();
                dt = Quotes.Get_QuoteDetail_Product(Convert.ToInt32(GridQuote.CurrentRow.Cells[0].Value.ToString()));
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

        private void ProductGrid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            RefillProductContext();
        }

        private void ProductGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = PGridContext.DropDown;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (GridQuote.Rows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner La Devis.", @"Message", MessageBoxButtons.OK,
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
                        await Quotes.QuoteDelete(Convert.ToInt32(GridQuote.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show(@"Devis a été supprimé avec succès", @"Message", MessageBoxButtons.OK,
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
                FillGridQuote();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    GridQuote.DataSource = Quotes.QuoteSearch(txtSearch.Text);
                }
                else
                {
                    FillGridQuote();
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

        private void ShippingGroup_Click(object sender, EventArgs e)
        {

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            txtShippingAddress.Text = txtBillingAddress.Text;
            txtShippingCity.Text = txtBillingCity.Text;
            txtShippingZip.Text = txtBillingZip.Text;
            txtShippingCountry.Text = txtBillingCountry.Text;

        }

        private void btnOpp_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Quotes.GetQuotes(), ArgTable.Quote);
            frm.ShowDialog();
            txtOpp.Text = frm._Name;
            _QuoteId = frm._ID;
        }
    }
}
