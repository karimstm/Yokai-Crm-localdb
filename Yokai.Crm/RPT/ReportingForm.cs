using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Yokai.Crm.Report;

namespace Yokai.Crm
{
    public partial class ReportingForm : Telerik.WinControls.UI.RadForm
    {
        //InstanceReportSource source
        public ReportingForm()
        {
            InitializeComponent();
            //_source = source;
        }

        private void ReportingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
