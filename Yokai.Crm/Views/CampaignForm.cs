using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;
using System.Data.SqlClient;

namespace Yokai.Crm
{
    public partial class CampaignForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        private int _id;

        public CampaignForm()
        {
            InitializeComponent();
        }

        private void Enable(bool status)
        {
            foreach (RadControl c in MainGroup.Controls)
            {
                if (!(c is RadButton))
                    c.Enabled = status;
            }
        }

        private void GetCampaigns()
        {
            DataTable dt = Campaign.GetCampaigns();
            MainGrid.DataSource = dt;
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Unchanged;
            Enable(false);
            _main.ClearTextBoxes(MainGroup.Controls);
            GetCampaigns();
            _main.IsBusy = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Added;
            Enable(true);
            _main.ClearTextBoxes(MainGroup.Controls);
            _main.IsBusy = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show(@"Vous devez remplir tous les champs nécessaires.", @"Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _main.IsBusy = false;
                    return;
                }

                if (_state == EntityState.Added)
                {
                    int result = await Campaign.InsertCampaign(txtName.Text, cmbType.Text,
                        cmbStatus.Text,
                        dtpStart.Value, dtpFin.Value, Convert.ToDecimal(txtExprectedRevenu.Text),
                        Convert.ToDecimal(txtBudgetedCost.Text),
                        Convert.ToDecimal(txtActualCost.Text), Convert.ToDecimal(txtExpectedResponse.Text),
                        (int) txtNumberSent.Value, txtDescription.Text);
                    MessageBox.Show(@"La campagne a été ajoutée avec succès.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                }
                else if (_state == EntityState.Changed)
                {
                    int result = await Campaign.UpdateCampaign(_id, txtName.Text, cmbType.Text,
                        cmbStatus.Text,
                        dtpStart.Value, dtpFin.Value, Convert.ToDecimal(txtExprectedRevenu.Text),
                        Convert.ToDecimal(txtBudgetedCost.Text),
                        Convert.ToDecimal(txtActualCost.Text), Convert.ToDecimal(txtExpectedResponse.Text),
                        (int) txtNumberSent.Value, txtDescription.Text);
                    MessageBox.Show(@"La campagne a été mis a jour avec succès.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                }
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
                _main.IsBusy = false;
                _state = EntityState.Unchanged;
                _main.ClearTextBoxes(MainGroup.Controls);
                GetCampaigns();
            }
        }

        private void txtActualCose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void CampaignForm_Load(object sender, EventArgs e)
        {
            Enable(false);
            GetCampaigns();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Changed;
            Enable(true);
            try
            {
                _main.ClearTextBoxes(MainGroup.Controls);
                _id = (int) MainGrid.CurrentRow.Cells[0].Value;
                var dt = Campaign.GetCampaignById(_id);
                txtName.Text = dt.Rows[0][1].ToString();
                cmbType.Text = dt.Rows[0][2].ToString();
                cmbStatus.Text = dt.Rows[0][3].ToString();
                dtpStart.Value = (DateTime)dt.Rows[0][4];
                dtpFin.Value = (DateTime)dt.Rows[0][5];
                txtExprectedRevenu.Text = dt.Rows[0][6].ToString();
                txtBudgetedCost.Text = dt.Rows[0][7].ToString();
                txtActualCost.Text = dt.Rows[0][8].ToString();
                txtExpectedResponse.Text = dt.Rows[0][9].ToString();
                txtNumberSent.Value = Convert.ToInt32(dt.Rows[0][10].ToString());
                txtDescription.Text = dt.Rows[0][11].ToString();
            }
            catch (Exception)
            {
                // ignored
            }
            _main.IsBusy = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                DialogResult result =  MessageBox.Show(@"Voulez-vous vraiment supprimer cette campagne?", @"Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    _id = (int)MainGrid.CurrentRow.Cells[0].Value;
                    var delete = Campaign.DeleteCampaign(_id);
                    MessageBox.Show(@"La campagne est supprimée avec succès", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            GetCampaigns();
            _main.IsBusy = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MainGrid.DataSource = Campaign.GetSearchedCampaign(txtSearch.Text);
        }
    }
}
