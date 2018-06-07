using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class UsersForm : Telerik.WinControls.UI.RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        private string _password;
        public UsersForm()
        {
            InitializeComponent();
            FillGrid();
        }

        private void FillTextBox()
        {
            DataTable dt = Users.SelecteUserById(UserGrid.CurrentRow.Cells[0].Value.ToString());
            txtUsername.Text = dt.Rows[0][0].ToString();
            txtFullname.Text = dt.Rows[0][1].ToString();
            txtEmail.Text = dt.Rows[0][2].ToString();
            _password = dt.Rows[0][3].ToString();
            cmbPermession.SelectedValue = dt.Rows[0][4];
        }

        private void FillGrid()
        {
            DataTable dt = Users.GetUsers();
            UserGrid.DataSource = dt;
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control c in GroupInfo.Controls)
            {
                if (c is RadTextBox || c is RadDropDownList)
                {
                    if (c.Text == "")
                    {
                        MessageBox.Show(@"Veuillez remplir tous les champs nécessaires", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            try
            {

                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    MessageBox.Show(@"Le mot de passe ne correspond pas", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasswordConfirm.Clear();
                    txtPasswordConfirm.Focus();
                    return;
                }


                await Users.InsertUser(txtUsername.Text, txtFullname.Text, txtEmail.Text, Encrypte(txtPassword.Text), Convert.ToInt32(cmbPermession.SelectedValue));
                MessageBox.Show(@"L'utilisateur a été ajouté avec succès.", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid();
                Clear();
                Enable(false);
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show(@"Cet Utilisateur Existe Déja", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception)
            {
                // ignored
            }
        }


        public static string Encrypte(string password)
        {
            SHA512Managed sha512 = new SHA512Managed();
            byte[] hash = Encoding.UTF8.GetBytes(password);
            hash = sha512.ComputeHash(hash);
            StringBuilder sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        private void Clear()
        {
            _main.ClearTextBoxes(GroupInfo.Controls);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty)
            {
                _password = Encrypte(txtPassword.Text);
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show(@"Le mot de passe ne correspond pas", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordConfirm.Clear();
                txtPasswordConfirm.Focus();
                return;

            }
            try
            {
                foreach (Control c in GroupInfo.Controls)
                {
                    if (c is RadTextBox || c is RadDropDownList)
                    {
                        if (c == txtPassword || c == txtPasswordConfirm)
                        {
                            continue;
                        }
                        if (c.Text == "")
                        {
                            MessageBox.Show(@"Veuillez remplir tous les champs nécessaires", @"Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                }

                var result = await Users.UpdateUser(txtUsername.Text, txtFullname.Text, txtEmail.Text,
                    _password, Convert.ToInt32(cmbPermession.SelectedValue));
                MessageBox.Show(@"L'utilisateur a été mis à jour avec succès.", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                FillGrid();
                Clear();
                Enable(false);

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserGrid.Rows.Count > 0)
                {
                    if (MessageBox.Show(@"Voulez-vous vraiment supprimer Cet Utilisateur ?", @"Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await Users.DeleteUser(UserGrid.CurrentRow.Cells[0].Value.ToString());
                        MessageBox.Show(@"Utilisateur Supprimer avec success !", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillGrid();
                    }
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
        }
        /// <summary>
        /// Enable or disable the GroupBoxes based on the statut variable
        /// </summary>
        /// <param name="statut"></param>
        void Enable(bool statut)
        {
            GroupInfo.Enabled = statut;
            txtUsername.Focus();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            cmbPermession.ValueMember = "idPermission";
            cmbPermession.DisplayMember = "PermLabel";
            cmbPermession.DataSource = Users.GetPermission();
            ItemUpdate.Click += ItemUpdate_Click;
            ItemDelete.Click += ItemDelete_Click;
            Enable(false);
            
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);
            FillGrid();
        }

        private void ItemUpdate_Click(object sender, EventArgs e)
        {
            UserGrid_CellDoubleClick(null, null);
            FillGrid();
        }

        private void UserGrid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            FillTextBox();
            Enable(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == string.Empty)
            {
                MessageBox.Show(@"Remplir le champ de Rechercher", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsearch.Focus();
                return;
            }

            if (UserGrid.Rows.Count == 0)
            {
                MessageBox.Show(@"Utilisateur n'existe pas", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = Users.UserSearch(txtsearch.Text);
                UserGrid.DataSource = dt;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void UserGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu = UsersContext.DropDown;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Enable(true);
            Clear();
            txtUsername.Focus();

        }
    }
}
