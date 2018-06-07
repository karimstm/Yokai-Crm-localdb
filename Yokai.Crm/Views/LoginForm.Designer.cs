namespace Yokai.Crm
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtUser = new Telerik.WinControls.UI.RadTextBox();
            this.txtPsw = new Telerik.WinControls.UI.RadTextBox();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.btnLogin = new Telerik.WinControls.UI.RadButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picturImg = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPsw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(43, 218);
            this.txtUser.Name = "txtUser";
            this.txtUser.NullText = "Nom d\'utilisateur";
            this.txtUser.Size = new System.Drawing.Size(360, 25);
            this.txtUser.TabIndex = 2;
            this.txtUser.ThemeName = "VisualStudio2012Light";
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.Click += new System.EventHandler(this.txtUser_Click);
            // 
            // txtPsw
            // 
            this.txtPsw.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPsw.Location = new System.Drawing.Point(43, 261);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.NullText = "Mot de passe";
            this.txtPsw.PasswordChar = '*';
            this.txtPsw.Size = new System.Drawing.Size(360, 25);
            this.txtPsw.TabIndex = 2;
            this.txtPsw.ThemeName = "VisualStudio2012Light";
            this.txtPsw.Click += new System.EventHandler(this.txtPsw_Click);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.BackColor = System.Drawing.Color.White;
            this.radCheckBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCheckBox1.Location = new System.Drawing.Point(43, 302);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(166, 19);
            this.radCheckBox1.TabIndex = 3;
            this.radCheckBox1.Text = "Afficher Mot de passe";
            this.radCheckBox1.ThemeName = "VisualStudio2012Light";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.White;
            this.radPanel1.Controls.Add(this.radCheckBox1);
            this.radPanel1.Controls.Add(this.btnClose);
            this.radPanel1.Controls.Add(this.pictureBox3);
            this.radPanel1.Controls.Add(this.btnLogin);
            this.radPanel1.Controls.Add(this.picturImg);
            this.radPanel1.Controls.Add(this.pictureBox2);
            this.radPanel1.Controls.Add(this.txtUser);
            this.radPanel1.Controls.Add(this.txtPsw);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(417, 394);
            this.radPanel1.TabIndex = 8;
            this.radPanel1.ThemeName = "VisualStudio2012Light";
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::Yokai.Crm.Properties.Resources.login;
            this.btnLogin.Location = new System.Drawing.Point(151, 338);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(123, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Connexion";
            this.btnLogin.ThemeName = "VisualStudio2012Light";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Yokai.Crm.Properties.Resources.logo_yourac;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(417, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Yokai.Crm.Properties.Resources.swatches;
            this.btnClose.Location = new System.Drawing.Point(280, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Annuler";
            this.btnClose.ThemeName = "VisualStudio2012Light";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Yokai.Crm.Properties.Resources.key;
            this.pictureBox3.Location = new System.Drawing.Point(20, 261);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // picturImg
            // 
            this.picturImg.Image = ((System.Drawing.Image)(resources.GetObject("picturImg.Image")));
            this.picturImg.Location = new System.Drawing.Point(159, 109);
            this.picturImg.Name = "picturImg";
            this.picturImg.Size = new System.Drawing.Size(100, 103);
            this.picturImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturImg.TabIndex = 7;
            this.picturImg.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Yokai.Crm.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(20, 218);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 394);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPsw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadTextBox txtUser;
        private Telerik.WinControls.UI.RadTextBox txtPsw;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadButton btnLogin;
        private Telerik.WinControls.UI.RadButton btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private System.Windows.Forms.PictureBox picturImg;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
    }
}
