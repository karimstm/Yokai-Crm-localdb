using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;
using DataRow = System.Data.DataRow;
using Yokai.Crm.Report;
using Telerik.Reporting;

namespace Yokai.Crm
{
    public partial class PurchaseOrderForm : Telerik.WinControls.UI.RadForm
    {
        DataTable dt = new DataTable();
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int? _VendorId;
        private int? _ContactId;
        private int? _PersonAdresseId;
        private string _oldIdProduct;
        private int _oldQte;

        public PurchaseOrderForm()
        {
            InitializeComponent();
        }

        private void FillGrid()
        {
            PurchaseOrderGrid.DataSource = PurchaseOrder.GET_PURCHASE_ORDER();
        }

        private void CreateTable()
        {
            dt.Columns.Add("Id Produit");
            dt.Columns.Add("Nom Produit");
            dt.Columns.Add("Prix de Produit");
            dt.Columns.Add("TVA");
            dt.Columns.Add("Quantité de Produit");
            dt.Columns.Add("Total");

            ProductGrid.DataSource = dt;
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

        private void ResizeDGV()
        {
            ProductGrid.Columns[0].Width = 100;
            ProductGrid.Columns[1].Width = 150;
            ProductGrid.Columns[2].Width = 150;
            ProductGrid.Columns[3].Width = 130;
            ProductGrid.Columns[4].Width = 150;
            ProductGrid.Columns[5].Width = 150;
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
                PurchaseOrder.PURCHASEORDER_SELECT_BY_ID(PurchaseOrderGrid.CurrentRow.Cells[0].Value.ToString());
            if (dt == null) return;
            PONumber.Text = dt.Rows[0][0].ToString();
            txtRNumber.Text = dt.Rows[0][5].ToString();
            txtSN.Text = dt.Rows[0][6].ToString();
            dtpAchat.Value = Convert.ToDateTime(dt.Rows[0][7].ToString());
            txtCarrier.Text = dt.Rows[0][9].ToString();
            cmbStatus.SelectedValue = dt.Rows[0][2].ToString();
            txtObject.Text = dt.Rows[0][4].ToString();
            txtVendorNam.Text = dt.Rows[0][16].ToString();
            txtContactName.Text = dt.Rows[0][17].ToString();
            dtpDueDate.Value = Convert.ToDateTime(dt.Rows[0][8].ToString());
            txtCommision.Text = dt.Rows[0][11].ToString();
            txtDuty.Text = dt.Rows[0][10].ToString();
            txtTerms.Text = dt.Rows[0][14].ToString();
            txtDescription.Text = dt.Rows[0][15].ToString();
            txtTotal.Text = dt.Rows[0][13].ToString();
            txtBillingAddress.Text = dt.Rows[0][18].ToString();
            txtBillingCity.Text = dt.Rows[0][19].ToString();
            txtBillingCountry.Text = dt.Rows[0][20].ToString();
            txtBillingZip.Text = dt.Rows[0][21].ToString();
            txtShippingAddress.Text = dt.Rows[0][22].ToString();
            txtShippingCity.Text = dt.Rows[0][23].ToString();
            txtShippingCountry.Text = dt.Rows[0][24].ToString();
            txtShippingZip.Text = dt.Rows[0][25].ToString();

            _PersonAdresseId = !string.IsNullOrEmpty(dt.Rows[0][12].ToString()) ? (int?) (int) dt.Rows[0][12] : null;
            _ContactId = !string.IsNullOrEmpty(dt.Rows[0][3].ToString()) ? (int?) (int) dt.Rows[0][3] : null;
            _VendorId = !string.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? (int?) (int) dt.Rows[0][1] : null;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            FillGrid();
            CreateTable();
            ResizeDGV();
            LoadStatus();
            Enable(false);
            MenuDelete.Click += MenuDelete_Click;
            MenuUpdate.Click += MenuUpdate_Click;
            radMenuPrint.Click += RadMenuPrint_Click;
            radMenuDelete.Click += RadMenuDelete_Click;
            radMenuUpdate.Click += RadMenuUpdate_Click;
            PGridContext.Items.Add(MenuDelete);
            PGridContext.Items.Add(MenuUpdate);
            PurchaseGridContext.Items.Add(radMenuPrint);
        }

        private void RadMenuUpdate_Click(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);

        }

        private void RadMenuDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);

        }

        private void RadMenuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportingForm frm = new ReportingForm();
                InstanceReportSource reportSource = new InstanceReportSource();
                reportSource.Parameters.Add(new Parameter("Id", PurchaseOrderGrid.CurrentRow.Cells[0].Value.ToString()));
                reportSource.ReportDocument = new ReportPurchaseOrder();
                frm.MainReportViewer.ReportSource = reportSource;
                frm.MainReportViewer.RefreshReport();
                frm.ShowDialog();

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void MenuUpdate_Click(object sender, EventArgs e)
        {
            ProductGrid_DoubleClick(sender, e);
            CalculTotal();
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            ProductGrid.CurrentRow.Delete();
            CalculTotal();
            ProductGrid.Refresh();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Vendor.FillGrid(), ArgTable.Vendor);
            frm.ShowDialog();
            txtVendorNam.Text = frm._Name;
            _VendorId = frm._ID;
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            try
            {
                SearchForm frm = new SearchForm(Contact.GetContact(), ArgTable.Contact);
                frm.ShowDialog();
                txtContactName.Text = frm._Name;
                _ContactId = frm._ID;
                DialogResult dr = MessageBox.Show(@"Do you want to use contact address?", "Message",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
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
            catch (Exception)
            {
                // ignored
            }
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

        private void txtqte_TextChanged(object sender, EventArgs e)
        {
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
                            MessageBox.Show("Cet Produit Existe Déja", "Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            CleatTxtProduct();
                            btnProduct.Focus();
                            return;
                        }
                    }

                    DataRow dr = dt.NewRow();
                    dr[0] = txtid.Text;
                    dr[1] = txtnom.Text;
                    dr[2] = txtprix.Text;
                    dr[3] = txttva.Text;
                    dr[4] = txtqte.Text;
                    dr[5] = txtmontant.Text;

                    dt.Rows.Add(dr);
                    ProductGrid.DataSource = dt;
                    CalculTotal();
                    txtid.Text = txtnom.Text = txtprix.Text = txttva.Text = txtqte.Text = txtmontant.Text = "";
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void txtprix_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprix.Text))
                CalculMontant();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.IsBusy = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            bool _changed = false;
            if (string.IsNullOrWhiteSpace(PONumber.Text))
            {
                MessageBox.Show("assurez-vous d'entrer le code de commande d'achat", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            try
            {
                if (_state == EntityState.Added)
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

                    var result = await PurchaseOrder.PurchaseOrderInser(PONumber.Text, _VendorId,
                        Convert.ToInt32(cmbStatus.SelectedValue), _ContactId, txtObject.Text, txtRNumber.Text,
                        txtSN.Text,
                        dtpAchat.Value, dtpDueDate.Value, txtCarrier.Text, Convert.ToDecimal(txtDuty.Text),
                        Convert.ToDecimal(txtCommision.Text),
                        Convert.ToDecimal(txtTotal.Text), txtTerms.Text, txtDescription.Text, txtBillingAddress.Text,
                        txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt);
                    MessageBox.Show("La commande d'achat a été ajoutée avec succès", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                }
                else if (_state == EntityState.Changed)
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

                    var result = await PurchaseOrder.PurchaseOrderUpdate(PONumber.Text, _VendorId,
                        Convert.ToInt32(cmbStatus.SelectedValue), _ContactId, txtObject.Text, txtRNumber.Text,
                        txtSN.Text,
                        dtpAchat.Value, dtpDueDate.Value, txtCarrier.Text, Convert.ToDecimal(txtDuty.Text),
                        Convert.ToDecimal(txtCommision.Text),
                        Convert.ToDecimal(txtTotal.Text), txtTerms.Text, txtDescription.Text, txtBillingAddress.Text,
                        txtBillingCity.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingAddress.Text, txtShippingCity.Text,
                        txtShippingZip.Text, txtShippingCountry.Text, dt);
                    MessageBox.Show("La commande d'achat a été mis a jour avec succès", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(MainPanel.Controls);
                _main.ClearDateTimePicker(MainPanel.Controls);
                _main.ClearDateTimePicker(BillingGroup.Controls);
                _main.ClearDateTimePicker(BillingGroup.Controls);
                int numRows = ProductGrid.Rows.Count;
                for (int i = 0; i < numRows; i++)
                {
                    int max = ProductGrid.Rows.Count - 1;
                    ProductGrid.Rows.Remove(ProductGrid.Rows[max]);
                }
                FillGrid();

            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                _changed = true;
                MessageBox.Show("Le numéro d'identification existe déjà", @"Message", MessageBoxButtons.OK,
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
                    _VendorId = null;
                }

            }

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            txtShippingAddress.Text = txtBillingAddress.Text;
            txtShippingCity.Text = txtBillingCity.Text;
            txtShippingZip.Text = txtBillingZip.Text;
            txtShippingCountry.Text = txtBillingCountry.Text;
        }

        private void ProductGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = PGridContext.DropDown;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (PurchaseOrderGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Assurez-vous de sélectionner La commande d'achat.", "Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                _state = EntityState.Changed;
                FillTxtBox();
                PPageView.SelectedPage = PurchaseOrderPage;
                Enable(true);
                DataTable dt = new DataTable();
                dt = PurchaseOrder.Get_PurchaseOrderDetails_Product(PONumber.Text);
                int numRows = ProductGrid.Rows.Count;
                for (int i = 0; i < numRows; i++)
                {
                    int max = ProductGrid.Rows.Count - 1;
                    ProductGrid.Rows.Remove(ProductGrid.Rows[max]);
                }
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

        private void ProductGrid_DoubleClick(object sender, EventArgs e)
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (PurchaseOrderGrid.Rows.Count == 0)
            {
                MessageBox.Show("Assurez-vous de sélectionner La commande d'achat.", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            try
            {
                DialogResult dialog = MessageBox.Show("Voulez-vous vraiment supprimer La commande d'achat?", "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    int result =
                        await PurchaseOrder.PurchaseOrderDelete(PurchaseOrderGrid.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show("La commande d'achat a été supprimé avec succès", "Message", MessageBoxButtons.OK,
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
                FillGrid();
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
            _main.ClearDateTimePicker(MainPanel.Controls);
            _main.ClearDateTimePicker(MainPanel.Controls);
            _main.ClearDateTimePicker(MainPanel.Controls);
            int numRows = ProductGrid.Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                int max = ProductGrid.Rows.Count - 1;
                ProductGrid.Rows.Remove(ProductGrid.Rows[max]);
            }
            _main.IsBusy = false;
        }

        private void PurchaseOrderGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = PurchaseGridContext.DropDown;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadMenuPrint_Click(null, null);
        }

        private void btnClearVendor_Click(object sender, EventArgs e)
        {
            _VendorId = null;
            txtVendorNam.Text = string.Empty;
        }

        private void btnClearContact_Click(object sender, EventArgs e)
        {
            _ContactId = null;
            txtContactName.Text = string.Empty;

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

        private void btnReloadCon_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchCom_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {

                if (!string.IsNullOrWhiteSpace(txtNumCom.Text))
                {
                    PurchaseOrderGrid.DataSource = PurchaseOrder.SearchPurchaseOrder("Id", txtNumCom.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txtNumDem.Text))
                {
                    PurchaseOrderGrid.DataSource = PurchaseOrder.SearchPurchaseOrder("Serie", txtNumDem.Text);
                }
                else
                {
                    return;
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

        private void btnReloadCon_Click_1(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                PurchaseOrderGrid.DataSource = PurchaseOrder.SearchPurchaseOrderByDate(Convert.ToDateTime(dtpDateAchat.Value),
                    Convert.ToDateTime(dtpDateEche.Value));

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

        private void btnReload_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
