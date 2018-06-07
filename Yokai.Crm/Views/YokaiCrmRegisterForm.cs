using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    public partial class YokaiCrmRegisterForm : Telerik.WinControls.UI.RadForm
    {
        public YokaiCrmRegisterForm()
        {
            InitializeComponent();
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            var result = await Task.Run(() => ProductManager.Activate(txtProductId.Text, txtProductKey.Text));
            if (result)
            {
                MessageBox.Show("Vous avez activé votre produit avec succès", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Votre clé de produit n'est pas valide", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void YokaiCrmRegisterForm_Load(object sender, EventArgs e)
        {
            txtProductId.Text = ProductManager.GetProductKey();
        }

        private async void YokaiCrmRegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            var result = await Task.Run(ProductManager.IsActivated);
            if (!result)
            {
                Application.Exit();
            }
            //if (!ProductManager.IsActivated())
            //{
            //    Application.Exit();
            //}
        }
    }
}
