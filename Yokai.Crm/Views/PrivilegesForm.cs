using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;
using Telerik.WinControls;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class PrivilegesForm : Telerik.WinControls.UI.RadForm
    {
        public PrivilegesForm()
        {
            InitializeComponent();
            DataTable dt = Users.GetUsers();
            lbUsers.DataSource = dt;
            lbUsers.DisplayMember = "Nom d'utilisateur";
            lbUsers.ValueMember = "Nom d'utilisateur";
            lbUsers_SelectedIndexChanged(null, null);

        }

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            string userName = lbUsers.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("username");
            dt.Columns.Add("idScreen");
            dt.Columns.Add("Prev");

            try
            {
                for (int i = 0; i < GridPrev.Rows.Count; i++)
                {
                    int idScreen = Convert.ToInt32(GridPrev.Rows[i].Cells[0].Value.ToString());
                    Boolean show = GridPrev.Rows[i].Cells[2].Value.Equals(true || false);
                    dt.Rows.Add(userName, idScreen, show);
                }

                await Users.usp_UpatePriv(dt);
                MessageBox.Show("Les Préviléges ont été mis à jour avec succés !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void PrivilegesForm_Load(object sender, EventArgs e)
        {
            
        }

        private void lbUsers_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                DataTable dt = Users.GetPrivileges(lbUsers.SelectedValue.ToString());
                GridPrev.DataSource = dt;
                GridPrev.Columns[0].IsVisible = false;

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
