using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Telerik.ReportViewer.WinForms;
using Telerik.WinControls;
using Yokai.Crm.Core;
using Yokai.Crm.Properties;

namespace Yokai.Crm
{
    public partial class LoginForm : Telerik.WinControls.UI.RadForm
    {
        List<Image> img = new List<Image>();
        Bitmap[] loc = new Bitmap[25];
        private string _Password;

        public LoginForm()
        {
            InitializeComponent();
            loc[0] = Properties.Resources.textbox_user_1;
            loc[1] = Properties.Resources.textbox_user_2;
            loc[2] = Properties.Resources.textbox_user_3;
            loc[3] = Properties.Resources.textbox_user_4;
            loc[4] = Properties.Resources.textbox_user_5;
            loc[5] = Properties.Resources.textbox_user_6;
            loc[6] = Properties.Resources.textbox_user_7;
            loc[7] = Properties.Resources.textbox_user_8;
            loc[8] = Properties.Resources.textbox_user_9;
            loc[9] = Properties.Resources.textbox_user_10;
            loc[10] = Properties.Resources.textbox_user_11;
            loc[11] = Properties.Resources.textbox_user_12;
            loc[12] = Properties.Resources.textbox_user_13;
            loc[13] = Properties.Resources.textbox_user_14;
            loc[14] = Properties.Resources.textbox_user_15;
            loc[15] = Properties.Resources.textbox_user_16;
            loc[16] = Properties.Resources.textbox_user_17;
            loc[17] = Properties.Resources.textbox_user_18;
            loc[18] = Properties.Resources.textbox_user_19;
            loc[19] = Properties.Resources.textbox_user_20;
            loc[20] = Properties.Resources.textbox_user_21;
            loc[21] = Properties.Resources.textbox_user_22;
            loc[22] = Properties.Resources.textbox_user_23;
            loc[23] = Properties.Resources.textbox_user_24;
            Display();
        }

        private void Display()
        {
            for (int i = 0; i < 23; i++)
            {
                Image bt = new Bitmap(loc[i]);
                img.Add(bt);
            }
            img.Add(Properties.Resources.textbox_user_24);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Changes
            if (txtUser.Text == string.Empty || txtPsw.Text == string.Empty)
            {
                MessageBox.Show("Tous les champs sont obligatoires", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Password = UsersForm.Encrypte(txtPsw.Text);

            try
            {
                DataTable dt = Login.usp_login(txtUser.Text, _Password);
                if (dt.Rows.Count > 0)
                {
                    MainForm._check = true;
                    MainForm._username = txtUser.Text;
                    Program.username = txtUser.Text;
                    MainForm._idPre = Convert.ToInt32(dt.Rows[0][4].ToString());
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Le nom d'utilisateur ou le mot de passe est incorrect", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de se connecter au serveur, veuillez configurer la chaîne de connexion.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (radCheckBox1.Checked == true)
            {
                txtPsw.PasswordChar = '\0';
                radCheckBox1.Text = "Cacher Password";
            }
            else
            {
                txtPsw.PasswordChar = '*';
                radCheckBox1.Text = "Afficher Password";

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPsw.GotFocus += TxtPsw_GotFocus;
        }

        private void TxtPsw_GotFocus(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(Properties.Resources.textbox_password);
            picturImg.Image = bit;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text.Length > 0 && txtUser.Text.Length <= 15)
                {
                    picturImg.Image = img[txtUser.Text.Length - 1];
                    picturImg.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (txtUser.Text.Length <= 0)
                {
                    picturImg.Image = Properties.Resources.debut;
                }
                else
                {
                    picturImg.Image = img[22];
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text.Length > 0)
                {
                    picturImg.Image = img[txtUser.Text.Length - 1];
                }
                else
                {
                    picturImg.Image = Properties.Resources.debut;
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void txtPsw_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(Properties.Resources.textbox_password);
            picturImg.Image = bit;
        }
    }
}
