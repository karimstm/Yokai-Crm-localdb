using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class ProspectForm : Telerik.WinControls.UI.RadForm
    {
        private MainViewModel _main = new MainViewModel(false);
        private EntityState _state = EntityState.Unchanged;
        public ProspectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enable Group controls when click on the <see cref="btnNew"/> button
        /// </summary>
        private void Enable(bool status)
        {
            infoGroup.Enabled = status;
            AddressGroup.Enabled = status;
            DescriptionGroup.Enabled = status;
            txtFirstName.Focus();
        }
        /// <summary>
        /// Get All Source from the Prospct Source class
        /// </summary>
        private void GetSource()
        {
            if (ProspectSource.GetAll() == null)
                return;
            cmbSource.DataSource = ProspectSource.GetAll();
            cmbSource.ValueMember = "ProspectSourceId";
            cmbSource.DisplayMember = "ProspectSourceName";
        }
        /// <summary>
        /// Get All Status from the prosct status class
        /// </summary>
        private void GetStatus()
        {
            if (ProspectStatus.GetAll() == null)
                return;
            cmbStatus.DataSource = ProspectStatus.GetAll();
            cmbStatus.ValueMember = "ProspectStatusId";
            cmbStatus.DisplayMember = "ProspectStatusName";
        }
        private void GetDataInTxtBox()
        {
            DataTable dt = Prospect.GetLeadById(Convert.ToInt32(GridProspect.CurrentRow.Cells[0].Value.ToString()));
            txtID.Text = dt.Rows[0][0].ToString();
            cmbSource.SelectedValue = Convert.ToInt32(dt.Rows[0][1].ToString());
            cmbStatus.SelectedValue = Convert.ToInt32(dt.Rows[0][2].ToString());
            txtFirstName.Text = dt.Rows[0][3].ToString();
            txtLastName.Text = dt.Rows[0][4].ToString();
            txtCompany.Text = dt.Rows[0][5].ToString();
            txtTitle.Text = dt.Rows[0][6].ToString();
            txtemail.Text = dt.Rows[0][7].ToString();
            txtemail2.Text = dt.Rows[0][8].ToString();
            txtPhone.Text = dt.Rows[0][9].ToString();
            txtFax.Text = dt.Rows[0][10].ToString();
            txtMobile.Text = dt.Rows[0][11].ToString();
            txtWebsite.Text = dt.Rows[0][12].ToString();
            txtAnnualRevenu.Text = dt.Rows[0][13].ToString();
            txtnbrEmp.Text = dt.Rows[0][14].ToString();
            txtskype.Text = dt.Rows[0][15].ToString();
            txtStreet.Text = dt.Rows[0][16].ToString();
            txtCity.Text = dt.Rows[0][17].ToString();
            txtState.Text = dt.Rows[0][18].ToString();
            txtZip.Text = dt.Rows[0][19].ToString();
            txtCountry.Text = dt.Rows[0][20].ToString();
            txtDescription.Text = dt.Rows[0][21].ToString();
        }
        public void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }
        private void ProspectForm_Load(object sender, EventArgs e)
        {
            GetSource();
            GetStatus();
            FillGrid();
        }
        /// <summary>
        /// Button Nouveau/New
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
        /// <summary>
        /// Button Enregister/Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            if (_state == EntityState.Added)
            {
                try
                {
                    decimal annualRevenu = 0;
                    if (!int.TryParse(txtnbrEmp.Text, out var noEmployee) &&
                        !decimal.TryParse(txtAnnualRevenu.Text, out annualRevenu))
                    {
                        MessageBox.Show(@"Assurez-vous que tous les champs sont remplis correctement", @"Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    int souceId = (int) cmbSource.SelectedValue;
                    int stateId = (int) cmbStatus.SelectedValue;
                    int result = await Prospect.InsertProspect(txtFirstName.Text, txtLastName.Text, txtCompany.Text,
                        txtTitle.Text, txtemail.Text, txtemail2.Text, txtPhone.Text, txtMobile.Text, txtFax.Text,
                        txtWebsite.Text,
                        annualRevenu, noEmployee, txtskype.Text, txtStreet.Text,
                        txtCity.Text,
                        txtState.Text, txtCountry.Text, txtDescription.Text, txtZip.Text, souceId, stateId);
                    MessageBox.Show(@"Le prospect a été ajouté avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _main.IsBusy = false;
                }

            }
            if (_state == EntityState.Changed)
            {
                try
                {
                    decimal annualRevenu = 0;
                    if (!int.TryParse(txtnbrEmp.Text, out var noEmployee) &&
                        !decimal.TryParse(txtAnnualRevenu.Text, out annualRevenu))
                    {
                        MessageBox.Show(@"Assurez-vous que tous les champs sont remplis correctement", @"Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int souceId = (int)cmbSource.SelectedValue;
                    int stateId = (int)cmbStatus.SelectedValue;
                    int result = await Prospect.UpdateProspect(Convert.ToInt32(txtID.Text), txtFirstName.Text, txtLastName.Text, txtCompany.Text,
                        txtTitle.Text, txtemail.Text, txtemail2.Text, txtPhone.Text, txtMobile.Text, txtFax.Text,
                        txtWebsite.Text, annualRevenu, noEmployee, txtskype.Text, txtStreet.Text, txtCity.Text,
                        txtState.Text, txtCountry.Text, txtDescription.Text, txtZip.Text, souceId, stateId);
                    MessageBox.Show(@"Le prospect a été mettre à jour avec succès", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _main.IsBusy = false;
                }
            }

            FillGrid();
            Enable(false);
        }
        /// <summary>
        /// Fill Rad Gridview with data
        /// </summary>
        private void FillGrid()
        {
            GridProspect.DataSource = Prospect.GetLead();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            if (GridProspect.Rows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner un prospect.", @"message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                _main.IsBusy = false;
                return;
            }
            
            Enable(true);
            GetDataInTxtBox();
            _state = EntityState.Changed;
            _main.IsBusy = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_main.IsBusy) return;
            _main.IsBusy = true;
            _state = EntityState.Deleted;
            if (GridProspect.Rows.Count == 0)
            {
                MessageBox.Show(@"Assurez-vous de sélectionner un prospect.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                _main.IsBusy = false;
                return;
            }
            if (_state == EntityState.Deleted)
            {
                try
                {
                    DialogResult dr = MessageBox.Show(@"Voulez-Vous Vraiment Supprimer Prospect Sélectionné ?", @"message", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int result = await Prospect.DeleteProspect(Convert.ToInt32(GridProspect.SelectedRows[0].Cells[0].Value.ToString()));
                        MessageBox.Show(@"Le prospect a été Supprimer avec succès", @"message", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(@"Annuler le processus", @"message", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    }

                }
                finally
                {
                    _main.IsBusy = false;
                    _state = EntityState.Unchanged;
                }

                FillGrid();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _state = EntityState.Unchanged;
            Enable(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(_main.IsBusy) return;
            _main.IsBusy = true;
            try
            {
                DataTable dt = Prospect.SearchLead(txtSearch.Text);
                if (dt == null)
                {
                    MessageBox.Show("Prospect n'existe pas", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                GridProspect.DataSource = dt;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                GridProspect.DataSource = Prospect.GetLead();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                _main.IsBusy = false;
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

        private void txtemail_Leave(object sender, EventArgs e)
        {
            //Regex emailRegex = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

            //if (!emailRegex.IsMatch(txtemail.Text))
            //{
            //    MessageBox.Show(txtemail.Text + " Non Format Email(EX: example@gmail.com)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtemail.Focus();
            //    txtemail.SelectionStart = 0;
            //    txtemail.SelectionLength = txtemail.TextLength;
            //    return;
            //}
        }

        private void txtemail2_Leave(object sender, EventArgs e)
        {
            //Regex emailRegex = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

            //if (!emailRegex.IsMatch(txtemail2.Text))
            //{
            //    MessageBox.Show(txtemail2.Text + " Non Format Email(EX: example@gmail.com)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtemail2.Focus();
            //    txtemail2.SelectionStart = 0;
            //    txtemail2.SelectionLength = txtemail2.TextLength;
            //    return;
            //}
        }
    }
}
