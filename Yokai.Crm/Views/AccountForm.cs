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
    public partial class Account : Telerik.WinControls.UI.RadForm
    {
        private MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        public Account()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enable or disable the GroupBoxes based on the statut variable
        /// </summary>
        /// <param name="Statut"></param>
        void Enable(bool Statut)
        {
            InfoAccountGB.Enabled = Statut;
            InfoAdressGB.Enabled = Statut;
            txtName.Focus();
        }

        /// <summary>
        /// File <see cref="cmbType"/> with data
        /// </summary>
        private new void GetType()
        {
            cmbType.DataSource = Typees.GetAll();
            cmbType.ValueMember = "TypeeId";
            cmbType.DisplayMember = "TypeName";
        }

        private void FillGrid()
        {
            GridAccount.DataSource = Core.Account.GetGridAccount();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            GetType();
            Enable(false);
            FillGrid();
        }

        /// <summary>
        /// Adding a new account to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;
            Enable(true);
            _state = EntityState.Added;
            _main.IsBusy = false;
        }

        /// <summary>
        /// Save all the changes into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy)
                return;
            _main.IsBusy = true;

            if (string.IsNullOrWhiteSpace(txtNbEmployee.Text))
                txtNbEmployee.Text = "0";
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtBillingStreet.Text) ||
                string.IsNullOrWhiteSpace(txtShippingStreet.Text))
            {
                MessageBox.Show(@"Remplissez tous les champs nécessaires", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _main.IsBusy = false;
                return;
            }
            try
            {
                if (_state == EntityState.Added)
                {

                    int result = await Core.Account.InsertAccount(txtName.Text, txtEmail.Text, txtPhone.Text,
                        txtWebsite.Text, txtFax.Text, Convert.ToInt32(txtNbEmployee.Text),
                        Convert.ToInt32(cmbType.SelectedValue),
                        txtTickerSymbol.Text, txtAssignedTo.Text, txtDescription.Text,
                        txtBillingStreet.Text, txtBillingCity.Text, txtBillingState.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingStreet.Text, txtShippingCity.Text, txtShippingState.Text,
                        TxtShippingZip.Text, txtShippingCountry.Text);
                    MessageBox.Show(@"Le compte a été ajouté avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (_state == EntityState.Changed)
                {
                    int result = await Core.Account.UpdateAccount(Convert.ToInt32(txtAccount.Text), txtName.Text, txtEmail.Text, txtPhone.Text,
                        txtWebsite.Text, txtFax.Text, Convert.ToInt32(txtNbEmployee.Text),
                        Convert.ToInt32(cmbType.SelectedValue),
                        txtTickerSymbol.Text, txtAssignedTo.Text, txtDescription.Text,
                        txtBillingStreet.Text, txtBillingCity.Text, txtBillingState.Text,
                        txtBillingZip.Text,
                        txtBillingCountry.Text, txtShippingStreet.Text, txtShippingCity.Text, txtShippingState.Text,
                        TxtShippingZip.Text, txtShippingCountry.Text);
                    MessageBox.Show(@"Le compte a été mis a jour avec succès", @"message", MessageBoxButtons.OK,
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
            }
            FillGrid();
            Enable(false);
            _main.ClearTextBoxes(InfoAdressGB.Controls);
            _main.ClearTextBoxes(InfoAccountGB.Controls);
            _main.IsBusy = false;
            _state = EntityState.Unchanged;
        }

        /// <summary>
        /// Make sure that the <see cref="txtEmail"/> match the specified pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //Regex emailRegex = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

            //if (!emailRegex.IsMatch(txtEmail.Text))
            //{
            //    MessageBox.Show(txtEmail.Text + " Non Format Email(EX: example@gmail.com)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtEmail.Focus();
            //    txtEmail.SelectionStart = 0;
            //    txtEmail.SelectionLength = txtEmail.TextLength;
            //    return;
            //}
        }

        /// <summary>
        /// Make sure the <see cref="txtNbEmployee"/> accept only the numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNbEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtBillingZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            //{
            //    e.Handled = true;
            //}
        }

        private void TxtShippingZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            //{
            //    e.Handled = true;
            //}
        }

        /// <summary>
        /// Cancel all the changes that has been made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(InfoAdressGB.Controls);
            _main.ClearTextBoxes(InfoAccountGB.Controls);
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            //Regex PhoneRegex = new Regex(@"\d{3}\-\d{3}-\d{4}");

            //if (!PhoneRegex.IsMatch(txtPhone.Text))
            //{
            //    MessageBox.Show(txtPhone.Text + " Non Format Phone(EX: 111-111-1111)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPhone.Focus();
            //    txtPhone.SelectionStart = 0;
            //    txtPhone.SelectionLength = txtPhone.TextLength;
            //    return;
            //}
        }

        private void txtFax_Leave(object sender, EventArgs e)
        {
            //Regex PhoneRegex = new Regex(@"\d{3}\-\d{3}-\d{4}");

            //if (!PhoneRegex.IsMatch(txtFax.Text))
            //{
            //    MessageBox.Show(txtFax.Text + " Non Format Phone(EX: 0625123658)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtFax.Focus();
            //    txtFax.SelectionStart = 0;
            //    txtFax.SelectionLength = txtFax.TextLength;
            //    return;
            //}

        }

        /// <summary>
        /// Check if the website match the pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Get to the Update state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                _state = EntityState.Changed;
                Enable(true);
                GetAccountById();
                pageViewer.SelectedPage = PageInfo;
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

        /// <summary>
        /// Fill all the TextBoxes with the appropriat value
        /// </summary>
        private void GetAccountById()
        {
            var dt = Core.Account.GetAccountsById((int)GridAccount.CurrentRow.Cells[0].Value);
            if (dt == null) return;
            txtAccount.Text = dt.Rows[0][0].ToString();
            txtName.Text = dt.Rows[0][2].ToString();
            txtEmail.Text = dt.Rows[0][3].ToString();
            txtPhone.Text = dt.Rows[0][4].ToString();
            txtFax.Text = dt.Rows[0][6].ToString();
            txtWebsite.Text = dt.Rows[0][5].ToString();
            txtNbEmployee.Text = dt.Rows[0][7].ToString();
            txtTickerSymbol.Text = dt.Rows[0][9].ToString();
            txtAssignedTo.Text = dt.Rows[0][10].ToString();
            cmbType.SelectedValue = Convert.ToInt32(dt.Rows[0][8].ToString());
            txtDescription.Text = dt.Rows[0][11].ToString();
            //This part for addresses.
            txtBillingStreet.Text = dt.Rows[0][12].ToString();
            txtBillingCity.Text = dt.Rows[0][13].ToString();
            txtBillingState.Text = dt.Rows[0][14].ToString();
            txtBillingZip.Text = dt.Rows[0][15].ToString();
            txtBillingCountry.Text = dt.Rows[0][16].ToString();
            txtShippingStreet.Text = dt.Rows[0][17].ToString();
            txtShippingCity.Text = dt.Rows[0][18].ToString();
            txtShippingState.Text = dt.Rows[0][19].ToString();
            TxtShippingZip.Text = dt.Rows[0][20].ToString();
            txtShippingCountry.Text = dt.Rows[0][21].ToString();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (GridAccount.Rows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner un Account.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }
            if (_state == EntityState.Deleted)
            {
                try
                {
                    DialogResult dr = MessageBox.Show(@"Voulez-Vous Vraiment Supprimer Account Sélectionné ?",
                        @"message", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int result =
                            await Core.Account.AccountDelete(
                                Convert.ToInt32(GridAccount.SelectedRows[0].Cells[0].Value.ToString()));
                        MessageBox.Show(@"Account a été Supprimer avec succès", @"message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(@"Annuler le processus", @"message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                }
                catch(Exception)
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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            _state = EntityState.Unchanged;
            Enable(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                DataTable dt = Core.Account.GetSearchAccount(txtSearch.Text);
                if (GridAccount.Rows.Count == 0)
                {
                    MessageBox.Show("Account n'existe pas", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtSearch.Text = "";
                    _main.IsBusy = false;
                    return;
                }

                GridAccount.DataSource = dt;
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
                var dt = Core.Account.GetGridAccount();
                GridAccount.DataSource = dt;
            }
            catch (Exception)
            {
            }
            finally
            {
                _main.IsBusy = false;
            }
        }
    }
}
