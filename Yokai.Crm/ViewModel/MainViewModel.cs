using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Yokai.Crm.Logic;

namespace Yokai.Crm
{
    class MainViewModel
    {
        private bool _isBusy;

        public MainViewModel(bool isBusy)
        {
            _isBusy = isBusy;
        }
        public bool IsBusy
        {
            get => _isBusy;
            set => _isBusy = value;
        }

        /// <summary>
        /// Clear all textboxes in the pageInfo
        /// </summary>
        public void ClearTextBoxes(Control.ControlCollection collection)
        {
            foreach (Control c in collection)
            {
                if (c is RadTextBox box)
                {
                    box.Text = "";
                }
            }
        }
        /// <summary>
        /// Clear all DateTimePicker in the pageInfo
        /// </summary>
        public void ClearDateTimePicker(Control.ControlCollection collection)
        {
            foreach (Control c in collection)
            {
                if (c is RadDateTimePicker box)
                {
                    box.ResetText();
                }
            }
        }
    }
}
