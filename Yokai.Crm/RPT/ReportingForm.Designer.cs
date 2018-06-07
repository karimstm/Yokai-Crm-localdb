namespace Yokai.Crm
{
    partial class ReportingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.MainReportViewer = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MainReportViewer
            // 
            this.MainReportViewer.AccessibilityKeyMap = null;
            this.MainReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainReportViewer.Location = new System.Drawing.Point(0, 0);
            this.MainReportViewer.Name = "MainReportViewer";
            this.MainReportViewer.Size = new System.Drawing.Size(821, 729);
            this.MainReportViewer.TabIndex = 0;
            this.MainReportViewer.ViewMode = Telerik.ReportViewer.WinForms.ViewMode.PrintPreview;
            // 
            // ReportingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 729);
            this.Controls.Add(this.MainReportViewer);
            this.Name = "ReportingForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportingForm";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.ReportingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        public Telerik.ReportViewer.WinForms.ReportViewer MainReportViewer;
    }
}
