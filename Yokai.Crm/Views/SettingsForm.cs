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

namespace Yokai.Crm
{
    public partial class SettingsForm : Telerik.WinControls.UI.RadForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connectionString =
                $"Data Source = {txtServer.Text}; Initial Catalog = {cmbDatabase.Text}; User ID = {txtUsername.Text}; Password = {txtPassword.Text}";
            try
            {
                sqlHelper helper = new sqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show(@"Test de connexion réussi", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString =
                $"Data Source = {txtServer.Text}; Initial Catalog = MASTER; User ID = {txtUsername.Text}; Password = {txtPassword.Text}";

            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand(@"USE MASTER; SELECT [name] as DbName FROM master.dbo.sysdatabases", cn) { CommandType = CommandType.Text };
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    cmbDatabase.ValueMember = "DbName";
                    cmbDatabase.DisplayMember = "DbName";
                    cmbDatabase.DataSource = dt;
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show(@"L'application ne peut pas se connecter au serveur", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString =
                $"Data Source = {txtServer.Text}; Initial Catalog = {cmbDatabase.SelectedValue}; User ID = {txtUsername.Text}; Password = {txtPassword.Text}";
            try
            {
                sqlHelper helper = new sqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSettings setting = new AppSettings();
                    setting.SaveConnectionString("cn", StringCipher.Encrypt(connectionString, "moutik"));
                    MessageBox.Show(@"Votre chaîne de connexion a été enregistrée avec succès", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"L'application ne peut pas se connecter au serveur", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
