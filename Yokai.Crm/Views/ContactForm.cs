using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    public partial class ContactForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int? _vendorId;
        private int? _accounId;

        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get All Source from the Prospect Source class
        /// </summary>
        private void GetSource()
        {
            if (ProspectSource.GetAll() == null)
                return;
            CmbSource.DataSource = ProspectSource.GetAll();
            CmbSource.ValueMember = "ProspectSourceId";
            CmbSource.DisplayMember = "ProspectSourceName";
            CmbSource2.DataSource = ProspectSource.GetAll();
            CmbSource2.ValueMember = "ProspectSourceId";
            CmbSource2.DisplayMember = "ProspectSourceName";
        }
        /// <summary>
        /// Get All Status from the prospect status class
        /// </summary>
        private void GetStatus()
        {
            if (ProspectStatus.GetAll() == null)
                return;
            CmbStatus.DataSource = ProspectStatus.GetAll();
            CmbStatus.ValueMember = "ProspectStatusId";
            CmbStatus.DisplayMember = "ProspectStatusName";
            CmbStatus2.DataSource = ProspectStatus.GetAll();
            CmbStatus2.ValueMember = "ProspectStatusId";
            CmbStatus2.DisplayMember = "ProspectStatusName";

        }
        /// <summary>
        /// Enable or disable the groupBoxes
        /// </summary>
        /// <param name="status"></param>
        private void Enable(bool status)
        {
            infoGroup.Enabled = status;
            AddressGroup.Enabled = status;
            txtFirstName.Focus();
        }

        /// <summary>
        /// Fill Rad Gridview with data
        /// </summary>
        private void FillGrid()
        {
            ContactView.DataSource = Contact.GetContact();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            GetSource();
            GetStatus();
            FillGrid();
            Enable(false);

        }

        /// <summary>
        /// Trying to add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            Enable(true);
            _state = EntityState.Added;
            _main.IsBusy = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_main.IsBusy) return;
                _main.IsBusy = true;
                if (ContactView.Rows.Count == 0)
                {
                    MessageBox.Show(@"Assurez-vous de sélectionner un prospect.", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                GetAccountById();
                Enable(true);
                _state = EntityState.Changed;
                _main.IsBusy = false;

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtBillingStreet.Text) ||
                string.IsNullOrWhiteSpace(txtShippingStreet.Text))
            {
                MessageBox.Show(@"Remplissez tous les champs nécessaires", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _main.IsBusy = false;
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtAccount.Text))
                    _accounId = null;
                if (string.IsNullOrWhiteSpace(txtVendor.Text))
                    _vendorId = null;

                if (_state == EntityState.Added)
                {
                    int result = await Contact.ContactInsert(_accounId, txtFirstName.Text, txtLastName.Text,
                        (int) CmbSource.SelectedValue, (int) CmbStatus.SelectedValue,
                        txtDepartement.Text, txtEmail.Text, txtPhone.Text, txtTitle.Text, txtMobile.Text,
                        txtHomePhone.Text, txtFax.Text, DTPDateOfBirth.Value, txtSkype.Text,
                        _vendorId, txtDescription.Text, txtBillingStreet.Text, txtBillingCity.Text,
                        txtBillingState.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingStreet.Text, txtShippingCity.Text, txtShippingState.Text,
                        TxtShippingZip.Text, txtShippingCountry.Text);
                    MessageBox.Show(@"Contacte a été ajouté avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (_state == EntityState.Changed)
                {

                    int result = await Contact.ContactUpdate(Convert.ToInt32(txtId.Text), _accounId, txtFirstName.Text,
                        txtLastName.Text, (int) CmbSource.SelectedValue, (int) CmbStatus.SelectedValue,
                        txtDepartement.Text, txtEmail.Text, txtPhone.Text, txtTitle.Text, txtMobile.Text,
                        txtHomePhone.Text, txtFax.Text, DTPDateOfBirth.Value, txtSkype.Text,
                        _vendorId, txtDescription.Text, txtBillingStreet.Text, txtBillingCity.Text,
                        txtBillingState.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingStreet.Text, txtShippingCity.Text, txtShippingState.Text,
                        TxtShippingZip.Text, txtShippingCountry.Text);
                    MessageBox.Show(@"Contacte a été mis a jour avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                FillGrid();
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _main.IsBusy = false;
                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(infoGroup.Controls);
                _main.ClearTextBoxes(AddressGroup.Controls);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(infoGroup.Controls);
            _main.ClearTextBoxes(AddressGroup.Controls);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(Core.Account.GetGridAccount(), ArgTable.Account);
            search.ShowDialog();
            txtAccount.Text = search._Name;
            _accounId = search._ID;
        }

        /// <summary>
        /// Fill all the TextBoxes with the appropriat value
        /// </summary>
        private void GetAccountById()
        {
            DataTable dt = Contact.GetContactById((int) ContactView.CurrentRow.Cells[0].Value);
            if (dt == null) return;
            txtDescription.Text = dt.Rows[0][17].ToString();
            CmbSource.SelectedValue = (int) dt.Rows[0][5];
            CmbStatus.SelectedValue = (int) dt.Rows[0][6];
            DTPDateOfBirth.Value = Convert.ToDateTime(dt.Rows[0][14].ToString());
            txtMobile.Text = dt.Rows[0][11].ToString();
            txtPhone.Text = dt.Rows[0][9].ToString();
            txtEmail.Text = dt.Rows[0][8].ToString();
            txtAccount.Text = dt.Rows[0][18].ToString();
            txtFirstName.Text = dt.Rows[0][3].ToString();
            txtLastName.Text = dt.Rows[0][4].ToString();
            txtSkype.Text = dt.Rows[0][15].ToString();
            txtVendor.Text = dt.Rows[0][29].ToString();
            txtTitle.Text = dt.Rows[0][10].ToString();
            txtDepartement.Text = dt.Rows[0][7].ToString();
            txtFax.Text = dt.Rows[0][13].ToString();
            txtHomePhone.Text = dt.Rows[0][12].ToString();
            txtId.Text = dt.Rows[0][0].ToString();
            //This part for addresses.
            txtBillingStreet.Text = dt.Rows[0][19].ToString();
            txtBillingCity.Text = dt.Rows[0][20].ToString();
            txtBillingState.Text = dt.Rows[0][21].ToString();
            txtBillingZip.Text = dt.Rows[0][22].ToString();
            txtBillingCountry.Text = dt.Rows[0][23].ToString();
            txtShippingStreet.Text = dt.Rows[0][24].ToString();
            txtShippingCity.Text = dt.Rows[0][25].ToString();
            txtShippingState.Text = dt.Rows[0][26].ToString();
            TxtShippingZip.Text = dt.Rows[0][27].ToString();
            txtShippingCountry.Text = dt.Rows[0][28].ToString();

            _accounId = !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? (int?) (int) dt.Rows[0][2] : null;
            _vendorId = !string.IsNullOrEmpty(dt.Rows[0][16].ToString()) ? (int?) (int) dt.Rows[0][16] : null;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (ContactView.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner un Contact.", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            if (_state == EntityState.Deleted)
            {
                try
                {
                    DialogResult dr = MessageBox.Show(@"Voulez-Vous Vraiment Supprimer Ce Contact?",
                        @"message", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int result =
                            await Contact.DeleteContact(
                                Convert.ToInt32(ContactView.SelectedRows[0].Cells[0].Value.ToString()));
                        MessageBox.Show(@"Contact a été Supprimer avec succès", @"message", MessageBoxButtons.OK,
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
                }

                FillGrid();
            }
        }
        /// <summary>
        /// Copy Billing address to the shipping one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            txtShippingStreet.Text = txtBillingStreet.Text;
            txtShippingCity.Text = txtBillingCity.Text;
            TxtShippingZip.Text = txtBillingZip.Text;
            txtShippingState.Text = txtBillingState.Text;
            txtShippingCountry.Text = txtBillingCountry.Text;
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Vendor.FillGrid(), ArgTable.Vendor);
            frm.ShowDialog();
            txtVendor.Text = frm._Name;
            _vendorId = frm._ID;
        }

        private void btnSearchSourceStatu_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;
            try
            {
                DataTable dt = Contact.SearchByStautSource((int)CmbSource2.SelectedValue, (int)CmbStatus2.SelectedValue);

                if (ContactView.Rows.Count == 0)
                {
                    MessageBox.Show("Contact n'existe pas", @"Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    _main.IsBusy = false;
                    return;
                }
                if (CmbSource2.Text != string.Empty || CmbStatus2.Text != string.Empty)
                {
                    ContactView.DataSource = dt;
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;

            try
            {
                var dt = Contact.GetContact();
                ContactView.DataSource = dt;
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

        private void btnSearchSkipId_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;
            try
            {
                DataTable dt = Contact.SearchBySkipId(txtSkype2.Text);

                if (ContactView.Rows.Count == 0)
                {
                    MessageBox.Show("Contact n'existe pas", @"Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                if (txtSkype2.Text == string.Empty)
                {
                    MessageBox.Show("Remplir le champ nécessaire", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                if (txtSkype2.Text != string.Empty)
                {
                    ContactView.DataSource = dt;
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

        private void btnSearchNamComp_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;
            try
            {
                DataTable dt = Contact.SearchByName(txtFirstName2.Text, txtLastName2.Text);

                if (ContactView.Rows.Count == 0)
                {
                    MessageBox.Show("Contact n'existe pas", @"Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                if (txtFirstName2.Text == string.Empty || txtFirstName2.Text == string.Empty)
                {
                    MessageBox.Show(@"Remplissez les champs nécessaires", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                if (txtFirstName2.Text != string.Empty || txtLastName2.Text != string.Empty)
                {
                    ContactView.DataSource = dt;
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

        private void btnSearchContacId_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;
            try
            {
                DataTable dt = Contact.SearchByContactId(txtId2.Text);

                if (ContactView.Rows.Count == 0)
                {
                    MessageBox.Show("Contact n'existe pas", @"Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                if (txtId2.Text == string.Empty)
                {
                    MessageBox.Show("Remplir le champ nécessaire", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }
                if (txtId2.Text != string.Empty)
                {
                    ContactView.DataSource = dt;
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

        private void txtId2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void btnClearVendor_Click(object sender, EventArgs e)
        {
            txtVendor.Text = string.Empty;
            _vendorId = null;
        }
    }
}
