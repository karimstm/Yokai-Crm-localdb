using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class VendorForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        EntityState _state = EntityState.Unchanged;

        public VendorForm()
        {
            InitializeComponent();
        }

        private void Enable(bool state)
        {
            radGBVendor.Enabled = state;
            txtName.Focus();
        }

        private void FillGridVendor()
        {
            VendorGridView.DataSource = Vendor.FillGrid();
        }

        //Remplir TextBox
        private void VendorSelectById()
        {
            DataTable dt = Vendor.VendorSelect(Convert.ToInt32(VendorGridView.CurrentRow.Cells[0].Value.ToString()));
            txtId.Text = dt.Rows[0][0].ToString();
            txtName.Text = dt.Rows[0][1].ToString();
            txtEmail.Text = dt.Rows[0][2].ToString();
            txtPhone.Text = dt.Rows[0][3].ToString();
            txtWebsite.Text = dt.Rows[0][4].ToString();
            txtStreet.Text = dt.Rows[0][5].ToString();
            txtCity.Text = dt.Rows[0][6].ToString();
            txtState.Text = dt.Rows[0][7].ToString();
            txtZipCode.Text = dt.Rows[0][8].ToString();
            txtCountry.Text = dt.Rows[0][9].ToString();
            txtDescription.Text = dt.Rows[0][10].ToString();
        }

        private void VendorForm_Load(object sender, EventArgs e)
        {
            FillGridVendor();
            Enable(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.ClearTextBoxes(radGBVendor.Controls);
            _main.IsBusy = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;

            if (txtName.Text == string.Empty || txtEmail.Text == string.Empty ||
                txtPhone.Text == string.Empty || txtStreet.Text == string.Empty ||
                txtCity.Text == string.Empty || txtZipCode.Text == string.Empty || txtCountry.Text == string.Empty)
            {
                MessageBox.Show(@"Remplissez tous les champs nécessaires", @"Message", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                _main.IsBusy = false;
                return;
            }
            try
            {
                if (_state == EntityState.Added)
                {
                    int result = await Vendor.VendorInsert(txtName.Text, txtEmail.Text,
                    txtPhone.Text, txtWebsite.Text, txtStreet.Text, txtCity.Text,
                    txtState.Text, txtZipCode.Text, txtCountry.Text,
                    txtDescription.Text);
                    MessageBox.Show(@"Fournisseur a été ajouté avec succès", @"message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                }
                else if (_state == EntityState.Changed)
                {
                    int result = await Vendor.VendorUpdate(Convert.ToInt32(txtId.Text),txtName.Text, txtEmail.Text,
                    txtPhone.Text, txtWebsite.Text, txtStreet.Text, txtCity.Text,
                    txtState.Text, txtZipCode.Text, txtCountry.Text,
                    txtDescription.Text);
                    MessageBox.Show(@"Fournisseur a été mis a jour avec succès", @"message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

                FillGridVendor();
                Enable(false);
                _main.ClearTextBoxes(radGBVendor.Controls);
                _state = EntityState.Unchanged;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_main.IsBusy) return;
                _main.IsBusy = true;
                _state = EntityState.Changed;

                if (VendorGridView.Rows.Count == 0)
                {
                    MessageBox.Show(@"Assurez-vous de sélectionner un Vendor.", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                VendorSelectById();
                Enable(true);
                _main.IsBusy = false;

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;
            if (VendorGridView.Rows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner un Vendor.", @"message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }
            if (_state == EntityState.Deleted)
            {
                try
                {
                    DialogResult dr = MessageBox.Show(@"Voulez-Vous Vraiment Supprimer Ce Vendor ?",
                        @"message", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int result = await Vendor.VendorDelete(Convert.ToInt32(VendorGridView.CurrentRow.Cells[0].Value.ToString()));
                        MessageBox.Show(@"Vendor a été Supprimer avec succès", @"message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    }

                    FillGridVendor();
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    _main.IsBusy = false;
                    _state = EntityState.Unchanged;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            Enable(false);
            _state = EntityState.Unchanged;
            _main.ClearTextBoxes(radGBVendor.Controls);
            _main.IsBusy = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;

            try
            {
                DataTable dt = Vendor.SearchVendor(txtSearch.Text);
                if (VendorGridView.Rows.Count == 0)
                {
                    MessageBox.Show(@"Vendor n'existe pas !!", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }

                VendorGridView.DataSource = dt;
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
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                FillGridVendor();
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtWebsite_Leave(object sender, EventArgs e)
        {
            //Regex WebSiteRegex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");

            //if (!WebSiteRegex.IsMatch(txtWebsite.Text))
            //{
            //    MessageBox.Show(txtWebsite.Text + @" Non Format WebSite(EX: http://example.com)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtWebsite.Focus();
            //    txtWebsite.SelectionStart = 0;
            //    txtWebsite.SelectionLength = txtWebsite.TextLength;
            //    return;
            //}
        }
    }
}
