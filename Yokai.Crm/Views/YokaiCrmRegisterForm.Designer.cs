namespace Yokai.Crm
{
    partial class YokaiCrmRegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YokaiCrmRegisterForm));
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtProductId = new Telerik.WinControls.UI.RadTextBox();
            this.txtProductKey = new Telerik.WinControls.UI.RadTextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.White;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(465, 68);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.Text = "Yokai CRM Activation\r\n";
            this.radPanel1.ThemeName = "VisualStudio2012Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 90);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(72, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Code Produit";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 125);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(78, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Clé de produit";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(99, 89);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(350, 20);
            this.txtProductId.TabIndex = 2;
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(99, 124);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(350, 20);
            this.txtProductKey.TabIndex = 2;
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnActivate.FlatAppearance.BorderSize = 0;
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Location = new System.Drawing.Point(348, 161);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(100, 23);
            this.btnActivate.TabIndex = 3;
            this.btnActivate.Text = "Activer";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // YokaiCrmRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 198);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.txtProductKey);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YokaiCrmRegisterForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activation";
            this.ThemeName = "VisualStudio2012Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YokaiCrmRegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.YokaiCrmRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtProductId;
        private Telerik.WinControls.UI.RadTextBox txtProductKey;
        private System.Windows.Forms.Button btnActivate;
    }
}
