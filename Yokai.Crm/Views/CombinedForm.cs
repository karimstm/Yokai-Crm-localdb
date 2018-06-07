using System;
using System.Windows.Forms;
using Yokai.Crm.Core;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    public partial class CombinedForm : Telerik.WinControls.UI.RadForm
    {
        private ArgTable _form;
        private bool _update;
        private int _id;
        public CombinedForm(ArgTable FormName)
        {
            InitializeComponent();
            _form = FormName;
            switch (_form)
            {
                case ArgTable.Category:
                    mainLabel.Text = "Nom de catégorie";
                    this.Name = "Gestion des catégories";
                    break;
                case ArgTable.Manufacturer:
                    mainLabel.Text = "Nom du fabricant";
                    this.Name = "Gestion des fabricants";
                    break;
                case ArgTable.Type:
                    mainLabel.Text = "Nom de Type";
                    this.Name = "Gestion des Types";
                    break;
            }
        }

        private void CombinedForm_Load(object sender, EventArgs e)
        {
            LoadForms();
        }

        private void LoadForms()
        {
            try
            {
                switch (_form)
                {
                    case ArgTable.Category:
                        mainGridView.DataSource = Category.GetCategory();
                        break;
                    case ArgTable.Manufacturer:
                        mainGridView.DataSource = Manufacturer.GetManufacture();
                        break;
                    case ArgTable.Type:
                        mainGridView.DataSource = Typees.GetAll();
                        break;
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vous devez remplir le champ de nom.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (_update)
                {
                    switch (_form)
                    {
                        case ArgTable.Category:
                            await Category.UpdateCategory(_id, txtName.Name);
                            break;
                        case ArgTable.Manufacturer:
                            await Manufacturer.UpdateManufacturer(_id, txtName.Name);
                            break;
                        case ArgTable.Type:
                            await Typees.UpdateType(_id, txtName.Name);
                            break;
                    }

                    _update = false;
                    MessageBox.Show("L'élément a été mis a jour avec succès.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    switch (_form)
                    {
                        case ArgTable.Category:
                            await Category.InsertCategory(txtName.Text);
                            break;
                        case ArgTable.Manufacturer:
                            await Manufacturer.InsertManufacturer(txtName.Text);
                            break;
                        case ArgTable.Type:
                            await Typees.InsertType(txtName.Text);
                            break;
                    }

                    MessageBox.Show("L'élément a été ajouté avec succès.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            LoadForms();
        }

        private void mainGridView_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _update = true;
            _id = (int)mainGridView.CurrentRow.Cells[0].Value;
            txtName.Text = mainGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            _id = (int)mainGridView.CurrentRow.Cells[0].Value;
            try
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer cet élément?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_form == ArgTable.Category)
                        await Category.DeleteCategory(_id);
                    else if (_form == ArgTable.Manufacturer)
                    {
                        await Manufacturer.DeleteManufacturer(_id);
                    }
                    else if (_form == ArgTable.Type)
                    {
                        await Typees.DeleteType(_id);
                    }

                    MessageBox.Show("Cet élément a été supprimé avec succès.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    LoadForms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
