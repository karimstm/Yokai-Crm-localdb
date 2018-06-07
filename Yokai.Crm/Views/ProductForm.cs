using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.Reporting;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;
using Yokai.Crm.Report;

namespace Yokai.Crm
{
    public partial class ProductForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        EntityState _state = EntityState.Unchanged;
        int? _vendorId;

        public ProductForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fill the grid with data
        /// </summary>
        private void FillGrid()
        {
            ProductGridView.DataSource = Products.GetProducts();
        }

        private void Enable(bool status)
        {
            PageProduct.Enabled = status;
            foreach (Control c in PageProduct.Controls)
            {
                c.Enabled = status;

            }

            PageProduct.Enabled = true;
            txtId.Focus();
        }

        private void GetCategory()
        {
            if (Category.GetCategory() == null)
                return;
            cmbCategory.DataSource = Category.GetCategory();
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DisplayMember = "CategoryName";
        }

        private void GetManufacture()
        {
            if (Manufacturer.GetManufacture() == null)
                return;
            cmbManufacture.DataSource = Manufacturer.GetManufacture();
            cmbManufacture.ValueMember = "ManufacturerId";
            cmbManufacture.DisplayMember = "ManufacturerName";
        }
        
        private void ProductForm_Load(object sender, EventArgs e)
        {
            GetCategory();
            GetManufacture();
            FillGrid();
            Enable(false);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = @"Images Files|*.JPEG; *.JPG; *.PNG; *.BMP; *.GIF";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ImageProduct.Image = Image.FromFile(ofd.FileName);
                    }
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            Enable(true);
            _state = EntityState.Added;
            _main.IsBusy = false;
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Vendor.FillGrid(), ArgTable.Vendor);
            frm.ShowDialog();
            txtNameVendor.Text = frm._Name;
            _vendorId = frm._ID;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            if (string.IsNullOrWhiteSpace(txtId.Text)
                || string.IsNullOrWhiteSpace(txtNamePrd.Text) 
                || string.IsNullOrWhiteSpace(txtQte.Text)
                || string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                MessageBox.Show(@"Assurez-vous que tous les champs nécessaires sont remplis", @"Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }
            
            decimal? Taxes = null;
            decimal? ratetax = null;
            if (decimal.TryParse(txtTax.Text, out var tax))
                Taxes = Convert.ToDecimal(txtTax.Text);
            if (decimal.TryParse(txtRateTax.Text, out var rate))
                ratetax = Convert.ToDecimal(txtRateTax.Text);
            try
            {
                byte[] byteImg;
                using (MemoryStream ms = new MemoryStream())
                {
                    ImageProduct.Image.Save(ms, ImageProduct.Image.RawFormat);
                    byteImg = ms.ToArray();
                }

                if (_state == EntityState.Added)
                {
                    int result = await Products.InsertProduct(txtId.Text, (int?) (cmbCategory.SelectedValue),
                        _vendorId, (int?) cmbManufacture.SelectedValue, txtNamePrd.Text,
                        txtSN.Text, IsActiveCheckBox.Checked, dtpStartCom.Value, dtpEndCom.Value, dtpStartSup.Value,
                        dtpEndSup.Value,
                        Convert.ToDecimal(txtUnitPrice.Text), Taxes, byteImg,
                        txtDescription.Text, Convert.ToInt32(txtQte.Text), ratetax);

                    MessageBox.Show(@"Produit a été ajouté avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (_state == EntityState.Changed)
                {
                    int result = await Products.UpdateProduct(txtId.Text, (int?) (cmbCategory.SelectedValue),
                        _vendorId, (int?) cmbManufacture.SelectedValue, txtNamePrd.Text,
                        txtSN.Text, IsActiveCheckBox.Checked, dtpStartCom.Value, dtpEndCom.Value, dtpStartSup.Value,
                        dtpEndSup.Value,
                        Convert.ToDecimal(txtUnitPrice.Text), Taxes, byteImg,
                        txtDescription.Text, Convert.ToInt32(txtQte.Text), ratetax);

                    MessageBox.Show(@"Produit a été mis a jour avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(PageProduct.Controls);
                checkBoxTVA.CheckState = CheckState.Unchecked;
                btnClear_Click(sender, e);
                _main.ClearDateTimePicker(PageProduct.Controls);
                FillGrid();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show(@"Le numéro d'identification existe déjà", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(@"Date débuts Supérieure à Date finales", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _vendorId = null;
                _main.IsBusy = false;
            }
        }

        private void checkBoxTVA_Validated(object sender, EventArgs e)
        {
            if (checkBoxTVA.CheckState == CheckState.Checked)
            {
                checkBoxTVA.Checked = true;
                txtTax.ReadOnly = false;
            }
            if (checkBoxTVA.CheckState == CheckState.Unchecked)
            {
                checkBoxTVA.Checked = false;
                txtTax.ReadOnly = true;
                txtTax.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(PageProduct.Controls);
            _main.ClearDateTimePicker(PageProduct.Controls);
            checkBoxTVA.CheckState = CheckState.Unchecked;
            btnClear_Click(sender, e);
            _main.IsBusy = false;
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtRateTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }
                
        private void txtQte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (ProductGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Assurez-vous de sélectionner un Produit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                _state = EntityState.Changed;
                FillTextBoxes();
                PPageView.SelectedPage = PageProduct;
                Enable(true);
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

        private void FillTextBoxes()
        {
            DataTable dt = Products.GetProductById(ProductGridView.CurrentRow.Cells[0].Value.ToString());
            if (dt == null) return;
            txtId.Text = dt.Rows[0][0].ToString();
            txtNamePrd.Text = dt.Rows[0][5].ToString();
            txtSN.Text = dt.Rows[0][6].ToString();
            txtNameVendor.Text = dt.Rows[0][3].ToString();
            _vendorId = !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? (int?)(int)dt.Rows[0][2] : null;
            bool isActive = (bool) dt.Rows[0][7];
            IsActiveCheckBox.CheckState = isActive ? CheckState.Checked : CheckState.Unchecked;
            cmbCategory.SelectedValue = dt.Rows[0][1];
            cmbManufacture.SelectedValue = dt.Rows[0][4];
            dtpStartCom.Value = Convert.ToDateTime(dt.Rows[0][8]);
            dtpEndCom.Value = Convert.ToDateTime(dt.Rows[0][9]);
            dtpStartSup.Value = Convert.ToDateTime(dt.Rows[0][10]);
            dtpEndSup.Value = Convert.ToDateTime(dt.Rows[0][11]);
            txtUnitPrice.Text = dt.Rows[0][12].ToString();
            txtTax.Text = dt.Rows[0][13].ToString();
            var isTvaApplied = dt.Rows[0][13].ToString();
            checkBoxTVA.Checked = !string.IsNullOrEmpty(isTvaApplied);
            txtRateTax.Text = dt.Rows[0][17].ToString();
            txtQte.Text = dt.Rows[0][16].ToString();
            txtDescription.Text = dt.Rows[0][15].ToString();
            var ms = new MemoryStream((byte[]) dt.Rows[0][14]);
            ImageProduct.Image = Image.FromStream(ms);

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (ProductGridView.Rows.Count == 0)
            {
                MessageBox.Show("Assurez-vous de sélectionner un Produit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }
            try
            {
                DialogResult dialog = MessageBox.Show("Voulez-vous vraiment supprimer ce produit?", "Message",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    int result = await Products.DeleteProduct(ProductGridView.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show("Ce produit a été supprimé avec succès", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ImageProduct.Image = Properties.Resources.No_Image;
        }

        private void btnClearVendor_Click(object sender, EventArgs e)
        {
            _vendorId = null;
            txtNameVendor.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearchId.Text))
                {
                    ProductGridView.DataSource = Products.SearchProduct("Id", txtSearchId.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txtSearchSN.Text))
                {
                    ProductGridView.DataSource = Products.SearchProduct("Sn", txtSearchSN.Text);
                }
                else
                {
                    FillGrid();
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

        private void radButton7_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                {
                    ProductGridView.DataSource = Products.SearchProduct("Name", txtSearchName.Text);
                }
                else
                {
                    FillGrid();
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
                                
        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtQte_Leave(object sender, EventArgs e)
        {
            if (_state == EntityState.Added || _state == EntityState.Changed)
            {
                if (txtQte.Text == "0")
                {
                    MessageBox.Show("La quantité ne peut pas être zéro", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQte.Focus();
                    txtQte.SelectionStart = 0;
                    txtQte.SelectionLength = txtQte.TextLength;
                    return;
                }

            }
        }

        private void txtUnitPrice_Leave(object sender, EventArgs e)
        {
            if (_state == EntityState.Added || _state == EntityState.Changed)
            {
                if (txtUnitPrice.Text == "0")
                {
                    MessageBox.Show("Le prix unitaire ne peut pas être zéro ou moins.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitPrice.Focus();
                    txtUnitPrice.SelectionStart = 0;
                    txtUnitPrice.SelectionLength = txtUnitPrice.TextLength;
                    return;
                }

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportingForm frm = new ReportingForm();
                InstanceReportSource reportSource = new InstanceReportSource();
                reportSource.Parameters.Add(new Telerik.Reporting.Parameter("Id", ProductGridView.CurrentRow.Cells[0].Value.ToString()));
                reportSource.ReportDocument = new ProductReportDetails();
                frm.MainReportViewer.ReportSource = reportSource;
                frm.MainReportViewer.RefreshReport();
                frm.ShowDialog();

            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
