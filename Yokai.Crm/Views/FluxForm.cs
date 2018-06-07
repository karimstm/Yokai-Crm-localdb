using System;
using System.Windows.Forms;
using Yokai.Crm.Core;

namespace Yokai.Crm
{
    public partial class FluxForm : Telerik.WinControls.UI.RadForm
    {
        private int _id;
        public FluxForm()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMessage.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
                    return;
                await Flux.InsertFlux(txtTitle.Text, txtMessage.Text, DateTime.Now, Program.username);
                MessageBox.Show("Message ajouté avec succès", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Refresh();
                txtMessage.Clear();
                txtTitle.Clear();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void GridFlux_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _id = (int) GridFlux.CurrentRow.Cells[0].Value;
            txtTitle.Text = GridFlux.CurrentRow.Cells[1].Value.ToString();
            txtMessage.Text = GridFlux.CurrentRow.Cells[2].Value.ToString();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMessage.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
                    return;

                await Flux.UpdateFlux(_id, txtTitle.Text, txtMessage.Text, DateTime.Now, Program.username);
                MessageBox.Show("Mis a jour avec succès", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Refresh();
                txtMessage.Clear();
                txtTitle.Clear();
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
                _id = (int)GridFlux.CurrentRow.Cells[0].Value;
                await Flux.DeleteFlux(_id);
                MessageBox.Show("Supprimer avec succès", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Refresh();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void FluxForm_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        public override void Refresh()
        {
            GridFlux.DataSource = Flux.GetFluxByUsername(Program.username);
        }
        
    }
}
