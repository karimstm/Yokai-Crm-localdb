using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    public partial class OpportunityForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int? _contactId;
        private int? _accountId;
        private int? _compagneId;
        private int _opportunityid;

        public OpportunityForm()
        {
            InitializeComponent();
        }

        private void GetSource()
        {
            if (ProspectSource.GetAll() == null)
                return;
            cmbSource.DataSource = ProspectSource.GetAll();
            cmbSource.ValueMember = "ProspectSourceId";
            cmbSource.DisplayMember = "ProspectSourceName";
        }

        private void FillGridAffaire()
        {
            MainGrid.DataSource = Opportunity.GetOpportunity();
        }

        private void Enable(bool status)
        {
            InfoGroup.Enabled = status;
            txtDescription.Enabled = status;
        }

        private void FillTxtBox()
        {
            var dt = Opportunity.OpportunitySelectById(Convert.ToInt32(MainGrid.CurrentRow.Cells[0].Value));
            if (dt == null)
                return;
            txtName.Text = dt.Rows[0][0].ToString();
            cmbSource.SelectedValue = dt.Rows[0][3].ToString();
            txtTotal.Text = dt.Rows[0][4].ToString();
            dtp.Value = Convert.ToDateTime(dt.Rows[0][5].ToString());
            cmbStatus.Text = dt.Rows[0][6].ToString();
            txtPropa.Text = Convert.ToInt32(dt.Rows[0][7]).ToString();
            txtDescription.Text = dt.Rows[0][8].ToString();
            cmbType.Text = dt.Rows[0][9].ToString();
            txtNextStep.Text = dt.Rows[0][10].ToString();
            txtExpected.Text = dt.Rows[0][11].ToString();
            txtContact.Text = dt.Rows[0][13].ToString();
            txtAccount.Text = dt.Rows[0][14].ToString();
            txtCampagne.Text = dt.Rows[0][15].ToString();

            _contactId = !string.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? (int?) (int) dt.Rows[0][1] : null;
            _accountId = !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? (int?) (int) dt.Rows[0][2] : null;
            _compagneId = !string.IsNullOrEmpty(dt.Rows[0][12].ToString()) ? (int?) (int) dt.Rows[0][12] : null;
            _opportunityid = (int) MainGrid.CurrentRow.Cells[0].Value;
        }

        private void OpportunityForm_Load(object sender, EventArgs e)
        {
            Enable(false);
            GetSource();
            FillGridAffaire();
        }

        private void btnCompte_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Core.Account.GetGridAccount(), ArgTable.Account);
            frm.ShowDialog();
            txtAccount.Text = frm._Name;
            _accountId = frm._ID;
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Contact.GetContact(), ArgTable.Contact);
            frm.ShowDialog();
            txtContact.Text = frm._Name;
            _contactId = frm._ID;

        }

        private void btnCampagne_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(Campaign.GetCampaigns(), ArgTable.Compagne);
            frm.ShowDialog();
            txtCampagne.Text = frm._Name;
            _compagneId = frm._ID;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            bool _changed = false;
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPropa.Text) ||
                string.IsNullOrWhiteSpace(txtTotal.Text) || string.IsNullOrWhiteSpace(txtExpected.Text))
            {
                MessageBox.Show("Remplissez tous les champs nécessaires", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            try
            {
                if (_state == EntityState.Added)
                {
                    var result = await Opportunity.OpprtunityInsert(txtName.Text, _contactId, _accountId,
                        (int) cmbSource.SelectedValue, Convert.ToDecimal(txtTotal.Text),
                        Convert.ToDateTime(dtp.Value), cmbStatus.Text, Convert.ToInt32(txtPropa.Text),
                        txtDescription.Text, cmbType.Text, txtNextStep.Text, Convert.ToDecimal(txtExpected.Text),
                        _compagneId);
                    MessageBox.Show(@"Affaire a été ajoutée avec succès", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                }
                else if (_state == EntityState.Changed)
                {
                    var result = await Opportunity.OpprtunityUpdate(_opportunityid, txtName.Text, _contactId,
                        _accountId,
                        (int) cmbSource.SelectedValue, Convert.ToDecimal(txtTotal.Text),
                        Convert.ToDateTime(dtp.Value), cmbStatus.Text, Convert.ToInt32(txtPropa.Text),
                        txtDescription.Text, cmbType.Text, txtNextStep.Text, Convert.ToDecimal(txtExpected.Text),
                        _compagneId);
                    MessageBox.Show(@"Affaire a été mis a jour avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }

                _state = EntityState.Unchanged;
                Enable(false);
                _main.ClearTextBoxes(InfoGroup.Controls);
                _main.ClearTextBoxes(MainPanel.Controls);
                _main.ClearDateTimePicker(dtp.Controls);
                FillGridAffaire();

            }
            catch (SqlException exsql) when (exsql.Number == 547)
            {
                MessageBox.Show("Vous devez sélectionner un contact ou un nom de compte", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _main.IsBusy = false;
                if (_changed == false)
                {
                    _state = EntityState.Unchanged;
                    _contactId = null;
                    _accountId = null;
                    _compagneId = null;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.ClearTextBoxes(InfoGroup.Controls);
            _main.ClearTextBoxes(MainPanel.Controls);
            _main.ClearDateTimePicker(InfoGroup.Controls);
            _main.IsBusy = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(InfoGroup.Controls);
            _main.ClearTextBoxes(MainPanel.Controls);
            _main.ClearDateTimePicker(InfoGroup.Controls);
            _main.IsBusy = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                if (MainGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Assurez-vous de sélectionner Affaire.", "Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                _state = EntityState.Changed;
                FillTxtBox();
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;

            if (MainGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner une Affaire.", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }

            if (_state == EntityState.Deleted)
            {
                try
                {
                    DialogResult dr = MessageBox.Show(@"Voulez-Vous Vraiment Supprimer une Affaire?",
                        @"message", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int result =
                            await Opportunity.OpportunityDelete(
                                Convert.ToInt32(MainGrid.SelectedRows[0].Cells[0].Value.ToString()));
                        MessageBox.Show(@"Affaire a été Supprimer avec succès", @"message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    FillGridAffaire();

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;

            try
            {
                DataTable dt = Opportunity.OpportunitySearch(txtSearch.Text);
                if (MainGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Affaire n'existe pas !!", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }

                MainGrid.DataSource = dt;
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
                FillGridAffaire();
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtPropa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtExpected_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }
    }
}
