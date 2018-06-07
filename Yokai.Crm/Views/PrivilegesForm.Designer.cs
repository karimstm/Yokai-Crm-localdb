namespace Yokai.Crm
{
    partial class PrivilegesForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivilegesForm));
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.GridPrev = new Telerik.WinControls.UI.RadGridView();
            this.btnAuth = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUsers = new Telerik.WinControls.UI.RadListControl();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrev.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPrev
            // 
            this.GridPrev.Location = new System.Drawing.Point(236, 37);
            // 
            // 
            // 
            this.GridPrev.MasterTemplate.AllowAddNewRow = false;
            this.GridPrev.MasterTemplate.AllowColumnReorder = false;
            this.GridPrev.MasterTemplate.AllowDragToGroup = false;
            this.GridPrev.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.GridPrev.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridPrev.Name = "GridPrev";
            this.GridPrev.Size = new System.Drawing.Size(466, 347);
            this.GridPrev.TabIndex = 0;
            this.GridPrev.ThemeName = "VisualStudio2012Light";
            // 
            // btnAuth
            // 
            this.btnAuth.Image = global::Yokai.Crm.Properties.Resources.Auth;
            this.btnAuth.Location = new System.Drawing.Point(236, 392);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(211, 33);
            this.btnAuth.TabIndex = 2;
            this.btnAuth.Text = "Accorder des Priviléges";
            this.btnAuth.ThemeName = "Office2010Blue";
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Yokai.Crm.Properties.Resources.swatches;
            this.btnCancel.Location = new System.Drawing.Point(453, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.ThemeName = "Office2010Blue";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Les Utilisateur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Les Priviléges :";
            // 
            // lbUsers
            // 
            this.lbUsers.Location = new System.Drawing.Point(3, 37);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(227, 347);
            this.lbUsers.TabIndex = 4;
            this.lbUsers.ThemeName = "VisualStudio2012Light";
            this.lbUsers.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // PrivilegesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 438);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.GridPrev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrivilegesForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorisation";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.PrivilegesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrev.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private Telerik.WinControls.UI.RadGridView GridPrev;
        private Telerik.WinControls.UI.RadButton btnAuth;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadListControl lbUsers;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
    }
}
