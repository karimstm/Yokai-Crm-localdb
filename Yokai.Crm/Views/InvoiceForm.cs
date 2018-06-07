using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;
using Yokai.Crm.Report;

namespace Yokai.Crm
{
    public partial class InvoiceForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int? _ContactId;
        private int? _AccountId;
        private int? _PersonAdresseId;
        private string _PurchaseOrderiD;
        private string _SalesOrderId;
        private int _InvoiceId;
        private int _oldQte;
        private string _oldIdProduct;
        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void LoadStatus()
        {
            var dt = PurchaseOrder.GetPurchaseStatus();
            cmbOrderStatus.DataSource = dt;
            cmbOrderStatus.DisplayMember = "OrderStatusName";
            cmbOrderStatus.ValueMember = "OrderStatusId";
        }

        private void Enable(bool status)
        {
            radGroupBox1.Enabled = status;
            radGroupBox2.Enabled = status;
            radGroupBox4.Enabled = status;
            txtTotal.Enabled = status;
            ProductGrid.Enabled = status;
        }

        private void FillInvoiceGrid()
        {
            var dt = Invoice.GetInvoice();
            InvoiceGrid.DataSource = dt;
        }

        private void CalculTotal()
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

        private void CalculMontant()
        {
            if (!string.IsNullOrWhiteSpace(txtqte.Text)
                && !string.IsNullOrWhiteSpace(txtprix.Text)
                && !string.IsNullOrWhiteSpace(txtid.Text))
            {
                var price = Convert.ToDecimal(txtprix.Text);
                var tva = Convert.ToDecimal(txttva.Text);
                decimal montant = (price * ( 1 + (tva/100))) * Convert.ToInt32(txtqte.Text); // prince ( 1 + (tva/100))
                txtmontant.Text = montant.ToString(CultureInfo.InvariantCulture);

            }
        }

        private void FillTxtBox()
        {
            DataTable dt = Invoice.InvoiceById(Convert.ToInt32(InvoiceGrid.CurrentRow.Cells[0].Value.ToString()));
            if (dt == null) return;
            txtObjet.Text = dt.Rows[0][2].ToString();
            dtpInvoiceDate.Value = Convert.ToDateTime(dt.Rows[0][3].ToString());
            dtpInvoiceDate.Value = Convert.ToDateTime(dt.Rows[0][4].ToString());
            txtCommission.Text = dt.Rows[0][5].ToString();
            txtTotal.Text = dt.Rows[0][6].ToString();
            txtexciseduty.Text = dt.Rows[0][7].ToString();
            txtTerms.Text = dt.Rows[0][8].ToString();
            txtDescription.Text = dt.Rows[0][9].ToString();
            cmbOrderStatus.SelectedValue = dt.Rows[0][11];
            txtContact.Text = dt.Rows[0][12].ToString();
            txtAccount.Text = dt.Rows[0][13].ToString();
            txtBillingAddress.Text = dt.Rows[0][14].ToString();
            txtBillingCity.Text = dt.Rows[0][15].ToString();
            txtBillingCountry.Text = dt.Rows[0][16].ToString();
            txtBillingZip.Text = dt.Rows[0][17].ToString();
            txtShippingAddress.Text = dt.Rows[0][18].ToString();
            txtShippingCity.Text = dt.Rows[0][19].ToString();
            txtShippingCountry.Text = dt.Rows[0][20].ToString();
            txtShippingZip.Text = dt.Rows[0][21].ToString();
            txtObjectPurchase.Text = dt.Rows[0][24].ToString();
            txtObjectSalesOrder.Text = dt.Rows[0][25].ToString();

            _PersonAdresseId = !string.IsNullOrEmpty(dt.Rows[0][10].ToString()) ? (int?)(int)dt.Rows[0][10] : null;
            _ContactId = !string.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? (int?)(int)dt.Rows[0][1] : null;
            _AccountId = !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? (int?)(int)dt.Rows[0][0] : null;
            _PurchaseOrderiD = !string.IsNullOrEmpty(dt.Rows[0][22].ToString()) ? dt.Rows[0][22].ToString() : null;
            _SalesOrderId = !string.IsNullOrEmpty(dt.Rows[0][23].ToString()) ? dt.Rows[0][23].ToString() : null;
            _InvoiceId = (int)InvoiceGrid.CurrentRow.Cells[0].Value;


        }

        //Update Product Grid
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
                _oldQte = Convert.ToInt32(txtqte.Text);
                _oldIdProduct = txtid.Text;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.ClearTextBoxes(radGroupBox1.Controls);
            _main.ClearTextBoxes(radGroupBox2.Controls);
            _main.ClearTextBoxes(radGroupBox4.Controls);
            _main.ClearTextBoxes(MainPanel.Controls);
            _main.ClearDateTimePicker(dtpInvoiceDate.Controls);
            _main.ClearDateTimePicker(dtpInvoiceDueDate.Controls);
            ProductGrid.Rows.Clear();
            _main.IsBusy = false;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            FillInvoiceGrid();
            LoadStatus();
            Enable(false);
            EditContext.Click += EditContext_Click;
            SupprimerContext.Click += SupprimerContext_Click;
            UpdateMenuItem.Click += UpdateMenuItem_Click;
            DeleteMenuItem.Click += DeleteMenuItem_Click;
            PrintContext.Click += PrintContext_Click;
        }

        private void PrintContext_Click(object sender, EventArgs e)
        {
            try
            {
                ReportingForm frm = new ReportingForm();
                InstanceReportSource reportSource = new InstanceReportSource();
                reportSource.Parameters.Add(new Telerik.Reporting.Parameter("Id", (Int32)InvoiceGrid.CurrentRow.Cells[0].Value));
                reportSource.ReportDocument = new ReportInvoice();
                frm.MainReportViewer.ReportSource = reportSource;
                frm.MainReportViewer.RefreshReport();
                frm.ShowDialog();

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProductGrid.CurrentRow.Delete();
                decimal sum = 0;

                for (int i = 0; i <= ProductGrid.Rows.Count - 1; i++)
                {
                    sum += decimal.Parse(ProductGrid.Rows[i].Cells[5].Value.ToString());
                }

                txtTotal.Text = sum.ToString(CultureInfo.InvariantCulture);

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void UpdateMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RefillProductContext();
                CalculTotal();

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void SupprimerContext_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);
        }

        private void EditContext_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(null, null);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            bool _changed = false;
            if (string.IsNullOrWhiteSpace(txtObjet.Text) || string.IsNullOrWhiteSpace(txtexciseduty.Text) ||
                string.IsNullOrWhiteSpace(txtCommission.Text) || (string.IsNullOrWhiteSpace(txtContact.Text) || string.IsNullOrWhiteSpace(txtAccount.Text)))
            {
                MessageBox.Show(@"Remplissez tous les champs nécessaires", @"Message", MessageBoxButtons.OK,
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
                    var result = await Invoice.InvoiceInsert(_AccountId, _ContactId, txtObjet.Text,
                        Convert.ToDateTime(dtpInvoiceDate.Value), Convert.ToDateTime(dtpInvoiceDueDate.Value),
                        Convert.ToDecimal(txtCommission.Text), Convert.ToDecimal(txtTotal.Text),
                        Convert.ToDecimal(txtexciseduty.Text), txtTerms.Text, txtDescription.Text,
                        (int) cmbOrderStatus.SelectedValue,
                        txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text,
                        txtBillingAddress.Text,
                        txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt, _PurchaseOrderiD, _SalesOrderId);
                    MessageBox.Show(@"Facture a été ajoutée avec succès", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                }
                else if (_state == EntityState.Changed)
                {
                    var result = await Invoice.InvoiceUpdate(_InvoiceId, _AccountId, _ContactId, txtObjet.Text,
                        Convert.ToDateTime(dtpInvoiceDate.Value), Convert.ToDateTime(dtpInvoiceDueDate.Value),
                        Convert.ToDecimal(txtCommission.Text), Convert.ToDecimal(txtTotal.Text),
                        Convert.ToDecimal(txtexciseduty.Text), txtTerms.Text, txtDescription.Text,
                        _PersonAdresseId, (int)cmbOrderStatus.SelectedValue,
                        txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text,
                        txtBillingAddress.Text,
                        txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt, _PurchaseOrderiD, _SalesOrderId);
                    MessageBox.Show(@"Facture a été mis a jour avec succès", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }

                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(radGroupBox1.Controls);
                _main.ClearTextBoxes(radGroupBox2.Controls);
                _main.ClearTextBoxes(radGroupBox4.Controls);
                _main.ClearDateTimePicker(dtpInvoiceDate.Controls);
                _main.ClearDateTimePicker(dtpInvoiceDueDate.Controls);
                txtTotal.Clear();
                ProductGrid.Rows.Clear();
                _PurchaseOrderiD = null;
                _SalesOrderId = null;
                FillInvoiceGrid();

            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(@"Date débuts Supérieure à Date finales", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            catch (Exception)
            {
                _changed = true;
            }
            finally
            {
                _main.IsBusy = false;
                if (_changed == false)
                {
                    _state = EntityState.Unchanged;
                    _ContactId = null;
                    _AccountId = null;
                }
            }
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            try
            {
                SearchForm frm = new SearchForm(Contact.GetContact(), ArgTable.Contact);
                frm.ShowDialog();
                txtContact.Text = frm._Name;
                _ContactId = frm._ID;
                DialogResult dr = MessageBox.Show(@"Do you want to use contact address?", @"Message",
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
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btnCompte_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Core.Account.GetGridAccount(), ArgTable.Account);
            frm.ShowDialog();
            txtAccount.Text = frm._Name;
            _AccountId = frm._ID;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Products.GetProducts(), ArgTable.Product);
            frm.ShowDialog();
            txtid.Text = frm._Code;
            txtnom.Text = frm._Name;
            var price = frm._Prix;
            txtprix.Text = price.ToString(CultureInfo.InvariantCulture);
            decimal? tva = frm?._TVA;
            txttva.Text = tva.ToString();
        }

        private void txtqte_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtqte.Text != "0")
                {
                    int num = (int)Invoice.VERIFY_QTE(txtid.Text);
                    if (Convert.ToInt32(txtqte.Text) > num && _state == EntityState.Added || (Convert.ToInt32(txtqte.Text) > (_oldIdProduct != txtid.Text ? _oldQte = 0 : _oldQte) + num && _state == EntityState.Changed))
                    {
                        MessageBox.Show(@"La quantité du produit : " + txtnom.Text + " est supérieure à la quantité dans le magasin", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        //txtid.Text = txtnom.Text = txtprix.Text = txttva.Text = txtqte.Text = txtmontant.Text = "";
                        btnProduct.Focus();

                        return;
                    }


                    for (int i = 0; i <= ProductGrid.Rows.Count - 1; i++)
                    {
                        if (ProductGrid.Rows[i].Cells[0].Value.ToString() == txtid.Text)
                        {
                            MessageBox.Show(@"Cet Produit Existe Déja", "Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            txtid.Text = txtnom.Text = txtprix.Text = txttva.Text = txtqte.Text = txtmontant.Text = "";
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

        private void txtprix_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprix.Text))
                CalculMontant();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            txtShippingAddress.Text = txtBillingAddress.Text;
            txtShippingCity.Text = txtBillingCity.Text;
            txtShippingZip.Text = txtBillingZip.Text;
            txtShippingCountry.Text = txtBillingCountry.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (InvoiceGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Assurez-vous de sélectionner Facture.", "Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                _state = EntityState.Changed;
                FillTxtBox();
                MainPageView.SelectedPage = MainPanel;
                Enable(true);
                DataTable dt = new DataTable();
                dt = Invoice.InvoiceDetails_Product(Convert.ToInt32(InvoiceGrid.CurrentRow.Cells[0].Value.ToString()));
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(radGroupBox1.Controls);
            _main.ClearTextBoxes(radGroupBox2.Controls);
            _main.ClearTextBoxes(radGroupBox4.Controls);
            _main.ClearTextBoxes(MainPanel.Controls);
            _main.ClearDateTimePicker(dtpInvoiceDate.Controls);
            _main.ClearDateTimePicker(dtpInvoiceDueDate.Controls);
            ProductGrid.Rows.Clear();
            _main.IsBusy = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (InvoiceGrid.Rows.Count == 0)
            {
                MessageBox.Show("Assurez-vous de sélectionner La Facture.", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            try
            {
                DialogResult dialog = MessageBox.Show("Voulez-vous vraiment supprimer ce Facture?", "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    int result =
                        await Invoice.InvoiceDelete(Convert.ToInt32(InvoiceGrid.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("La Facture a été supprimé avec succès", "Message", MessageBoxButtons.OK,
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
                FillInvoiceGrid();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            radColor.Text = DateTime.Now.ToString();
            radColor.Text = "";

            int x = DateTime.Now.Second;
            x = x % 10;
            switch (x)
            {
                case 0:
                {
                    radColor.BackColor = Color.LightSkyBlue; break;
                }
                case 1:
                {
                    radColor.BackColor = Color.SkyBlue; break;
                }
                case 2:
                {
                    radColor.BackColor = Color.DeepSkyBlue; break;
                }
                case 3:
                {
                    radColor.BackColor = Color.LightBlue; break;
                }
                case 4:
                {
                    radColor.BackColor = Color.DarkTurquoise; break;
                }
                case 5:
                {
                    radColor.BackColor = Color.DarkTurquoise; break;
                }
                case 6:
                {
                    radColor.BackColor = Color.PaleTurquoise; break;
                }
                case 7:
                {
                    radColor.BackColor = Color.Aqua; break;
                }
                case 8:
                {
                    radColor.BackColor = Color.MediumTurquoise; break;
                }
                case 9:
                {
                    radColor.BackColor = Color.LightSeaGreen;
                    break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            InvoiceGrid.DataSource = Invoice.SearchInvoice(txtSearch.Text);

        }

        private void InvoiceGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = InvoiceGridContext.DropDown;
        }

        private void ProductGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = PGridContext.DropDown;
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            var dt = Invoice.GetInvoiceByDates(startDate.Value, endDate.Value);
            InvoiceGrid.DataSource = dt;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(PurchaseOrder.GET_PURCHASE_ORDER(), ArgTable.PurchaseOrder);
            frm.ShowDialog();
            txtObjectSalesOrder.Text = frm._Name;
            _PurchaseOrderiD = frm._Code;

        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(SalesOrder.GetSalesOrder(), ArgTable.SalesOrder);
            frm.ShowDialog();
            txtObjectPurchase.Text = frm._Name;
            _SalesOrderId = frm._Code;

        }

        private void InvoiceGrid_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_Click(null, null);
        }

        private void btnClearContact_Click(object sender, EventArgs e)
        {
            _ContactId = null;
            txtContact.Text = string.Empty;

        }

        private void btnClearCompte_Click(object sender, EventArgs e)
        {
            _AccountId = null;
            txtAccount.Text = string.Empty;

        }

        private void btnClearPurchase_Click(object sender, EventArgs e)
        {
            _PurchaseOrderiD = null;
            txtObjectSalesOrder.Text = string.Empty;

        }

        private void btnClearSalesOrder_Click(object sender, EventArgs e)
        {
            _SalesOrderId = null;
            txtObjectPurchase.Text = string.Empty;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportingForm frm = new ReportingForm();
                InstanceReportSource reportSource = new InstanceReportSource();
                reportSource.Parameters.Add(new Parameter("startDate", Convert.ToDateTime(startDate.Value)));
                reportSource.Parameters.Add(new Parameter("endDate", Convert.ToDateTime(endDate.Value)));
                reportSource.ReportDocument = new ReportInvoiceTowDate();
                frm.MainReportViewer.ReportSource = reportSource;
                frm.MainReportViewer.RefreshReport();
                frm.ShowDialog();

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintContext_Click(null, null);

        }
    }
}
