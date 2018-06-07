using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    public partial class MainForm : RadForm
    {
        MainViewModel _main = new MainViewModel(false);
        public static bool _check = false;
        public static int _idPre = 0;
        public static string _username;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAccountForm_Click(object sender, EventArgs e)
        {
            new Account().ShowDialog();
        }

        private void btnContactForm_Click(object sender, EventArgs e)
        {
            new ContactForm().ShowDialog();
        }

        private void btnVendorForm_Click(object sender, EventArgs e)
        {
            new VendorForm().ShowDialog();
        }

        private void btnLeadForm_Click(object sender, EventArgs e)
        {
            new ProspectForm().ShowDialog();
        }

        private void btnOppForm_Click(object sender, EventArgs e)
        {
            new OpportunityForm().ShowDialog();
        }

        private void btnProductForm_Click(object sender, EventArgs e)
        {
            new ProductForm().ShowDialog();
        }

        private void btnInvoiceForm_Click(object sender, EventArgs e)
        {
            new InvoiceForm().ShowDialog();
        }

        private void btnCompaignForm_Click(object sender, EventArgs e)
        {
            new CampaignForm().ShowDialog();
        }

        private void btnPurchaseOrderForm_Click(object sender, EventArgs e)
        {
            new PurchaseOrderForm().ShowDialog();
        }

        private void btnSalesOrderForm_Click(object sender, EventArgs e)
        {
            new SalesOrderForm().ShowDialog();
        }

        private void btnQuoteForm_Click(object sender, EventArgs e)
        {
            new QuoteForm().ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new UsersForm().ShowDialog();
        }

        private void btnPriv_click(object sender, EventArgs e)
        {
            new PrivilegesForm().ShowDialog();
        }

        private void MenuLogin_Click(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog();
            if (_check == false)
            {
                //radCommandBar1.Enabled = false;

                IsUnlocked(false);
            }
            else if (_check)
            {
                if (_idPre == 1)
                {

                    IsUnlocked(true);
                    MenuBackup.Enabled = true;
                    MenuRestor.Enabled = true;
                    MenuLogin.Enabled = false;
                    MenuLogout.Enabled = true;
                    FluxGrid.DataSource = Flux.GetFlux();
                }

                else if (_idPre == 2)
                {
                    try
                    {
                        IsUnlocked(true);

                        DataTable dt = Users.GetPrivilege(_username);
                        if (dt.Rows[0][0].ToString() == "False" || dt.Rows[0][0].ToString() == string.Empty)
                            btnLeadForm.Enabled = false;
                        if (dt.Rows[1][0].ToString() == "False" || dt.Rows[1][0].ToString() == string.Empty)
                            btnAccountForm.Enabled = false;
                        if (dt.Rows[2][0].ToString() == "False" || dt.Rows[2][0].ToString() == string.Empty)
                            btnContactForm.Enabled = false;
                        if (dt.Rows[3][0].ToString() == "False" || dt.Rows[3][0].ToString() == string.Empty)
                            btnCompaignForm.Enabled = false;
                        if (dt.Rows[4][0].ToString() == "False" || dt.Rows[4][0].ToString() == string.Empty)
                            btnPurchaseOrderForm.Enabled = false;
                        if (dt.Rows[5][0].ToString() == "False" || dt.Rows[5][0].ToString() == string.Empty)
                            btnSalesOrderForm.Enabled = false;
                        if (dt.Rows[6][0].ToString() == "False" || dt.Rows[6][0].ToString() == string.Empty)
                            btnOppForm.Enabled = false;
                        if (dt.Rows[7][0].ToString() == "False" || dt.Rows[7][0].ToString() == string.Empty)
                            btnInvoiceForm.Enabled = false;
                        if (dt.Rows[8][0].ToString() == "False" || dt.Rows[8][0].ToString() == string.Empty)
                            btnProductForm.Enabled = false;
                        if (dt.Rows[9][0].ToString() == "False" || dt.Rows[9][0].ToString() == string.Empty)
                            btnQuoteForm.Enabled = false;
                        if (dt.Rows[10][0].ToString() == "False" || dt.Rows[10][0].ToString() == string.Empty)
                            btnPriv.Enabled = false;
                        if (dt.Rows[11][0].ToString() == "False" || dt.Rows[11][0].ToString() == string.Empty)
                            btnUsers.Enabled = false;
                        if (dt.Rows[12][0].ToString() == "False" || dt.Rows[12][0].ToString() == string.Empty)
                            btnVendorForm.Enabled = false;
                        if (dt.Rows[13][0].ToString() == "False" || dt.Rows[13][0].ToString() == string.Empty)
                            btnCategory.Enabled = false;
                        if (dt.Rows[14][0].ToString() == "False" || dt.Rows[14][0].ToString() == string.Empty)
                            btnManufacturer.Enabled = false;
                        if (dt.Rows[15][0].ToString() == "False" || dt.Rows[15][0].ToString() == string.Empty)
                            btnType.Enabled = false;
                        if (dt.Rows[16][0].ToString() == "False" || dt.Rows[16][0].ToString() == string.Empty)
                            btnFlux.Enabled = false;
                        if (dt.Rows[17][0].ToString() == "False" || dt.Rows[17][0].ToString() == string.Empty)
                            btnStatic.Enabled = false;
                        //commandBarStripElement1.Enabled = true;//
                        MenuBackup.Enabled = false;
                        MenuRestor.Enabled = false;
                        MenuLogin.Enabled = false;
                        MenuLogout.Enabled = true;
                        FluxGrid.DataSource = Flux.GetFlux();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else if (_idPre == 0)
                {
                    IsUnlocked(false);
                    //radCommandBar1.Enabled = false;
                    MenuBackup.Enabled = false;
                    MenuRestor.Enabled = false;
                    MenuLogout.Enabled = false;
                    MenuLogin.Enabled = true;
                    _username = null;
                    _idPre = 0;
                    _check = false;

                }
            }
        }
        //Login
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if(_check)
                FluxGrid.DataSource = Flux.GetFlux();
        }

        private void MenuLogout_Click(object sender, EventArgs e)
        {
            IsUnlocked(false);
            MenuLogout.Enabled = false;
            MenuLogin.Enabled = true;
            MenuBackup.Enabled = false;
            MenuRestor.Enabled = false;
            _username = null;
            _idPre = 0;
            _check = false;
            Program.username = null;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            new CombinedForm(ArgTable.Category).ShowDialog();
        }

        private void btnManufacturer_Click(object sender, EventArgs e)
        {
            new CombinedForm(ArgTable.Manufacturer).ShowDialog();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            new CombinedForm(ArgTable.Type).ShowDialog();
        }

        private void IsUnlocked(bool state)
        {
            foreach (var c in CommandBar.Items)
            {
                if (c is CommandBarButton)
                    c.Enabled = state;
            }

            FluxGrid.DataSource = null;
            FluxGrid.Enabled = state;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IsUnlocked(false);
        }

        private void btnFlux_Click(object sender, EventArgs e)
        {
            new FluxForm().ShowDialog();
        }

        private void FluxGrid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                FluxDisplay frm = new FluxDisplay();
                frm.TextDisplay.Text = FluxGrid.CurrentRow.Cells[2].Value.ToString();
                frm.ShowDialog();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            new DashboardForm().ShowDialog();
        }

        private void MenuConnectionString_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void MenuActivation_Click(object sender, EventArgs e)
        {
            new YokaiCrmRegisterForm().ShowDialog();
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {

            var result = await Task.Run(ProductManager.IsActivated);
            if (!result)
            {
                new YokaiCrmRegisterForm().ShowDialog();
            }
        }

        private void MenuCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void MenuBackup_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new System.Windows.Forms.FolderBrowserDialog();
                var result = dlg.ShowDialog();

                if (result.ToString() == "OK")
                {
                    var dbfileName = Path.Combine(Directory.GetCurrentDirectory(), "CRM_BD.mdf");
                    var backupConn = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString };
                    await backupConn.OpenAsync();

                    var backupcomm = backupConn.CreateCommand();
                    var backupdb = $@"BACKUP DATABASE ""{dbfileName}"" TO DISK='{Path.Combine(dlg.SelectedPath, "CRM_BD.bak")}'";
                    var backupcreatecomm = new SqlCommand(backupdb, backupConn);
                    await backupcreatecomm.ExecuteNonQueryAsync();
                    backupConn.Close();

                    MessageBox.Show($"Sauvegarde terminée avec succès", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.Contains("Operating system error") ? "Please chose a public folder." : ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //    string path =
            //        $"CRM_BD-{DateTime.Now.ToShortDateString().Replace('/', '-')}{DateTime.Now.ToShortTimeString().Replace(':', '-')}.bak";
            //    var result = await DbSettings.Backup(path);
            //    MessageBox.Show("Sauvegarde terminée avec succès.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void MenuRestor_Click(object sender, EventArgs e)
        {
            //using (var backupConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            //{
            //    backupConn.Dispose();
            //}

            try
            {

                var dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\";
                dlg.Filter = "Database file (*.bak)|*.bak";
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (var con = new SqlConnection())
                    {
                        //con.Dispose();
                        con.ConnectionString = con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=Master;Integrated Security=True;Connect Timeout=30;"; ;
                        con.Open();
                        var dbfileName = Path.Combine(Directory.GetCurrentDirectory(), "CRM_BD.mdf");
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandText = $@"ALTER DATABASE ""{dbfileName}""
                                        SET SINGLE_USER
                                        WITH ROLLBACK IMMEDIATE;
                                        RESTORE DATABASE ""{dbfileName}"" FROM DISK='{dlg.FileName}'
                                                                                        WITH REPLACE";

                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                    MessageBox.Show($"La sauvegarde de la base de données a été restauréee", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
