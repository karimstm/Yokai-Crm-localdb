namespace Yokai.Crm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.MenuFicher = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuLogin = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuLogout = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuBackup = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuRestor = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuCloseApp = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuConnectionString = new Telerik.WinControls.UI.RadMenuItem();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.FluxGrid = new Telerik.WinControls.UI.RadGridView();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.MenuHelp = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuActivation = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuAbout = new Telerik.WinControls.UI.RadMenuItem();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.CommandBar = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAccountForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnContactForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnVendorForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnLeadForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnOppForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnProductForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnInvoiceForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnCompaignForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnPurchaseOrderForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalesOrderForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnQuoteForm = new Telerik.WinControls.UI.CommandBarButton();
            this.btnUsers = new Telerik.WinControls.UI.CommandBarButton();
            this.btnPriv = new Telerik.WinControls.UI.CommandBarButton();
            this.btnCategory = new Telerik.WinControls.UI.CommandBarButton();
            this.btnManufacturer = new Telerik.WinControls.UI.CommandBarButton();
            this.btnType = new Telerik.WinControls.UI.CommandBarButton();
            this.btnFlux = new Telerik.WinControls.UI.CommandBarButton();
            this.btnStatic = new Telerik.WinControls.UI.CommandBarButton();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            ((System.ComponentModel.ISupportInitialize)(this.FluxGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FluxGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuFicher
            // 
            this.MenuFicher.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuLogin,
            this.MenuLogout,
            this.MenuBackup,
            this.MenuRestor,
            this.MenuCloseApp});
            this.MenuFicher.Name = "MenuFicher";
            this.MenuFicher.Text = "Ficher";
            // 
            // MenuLogin
            // 
            this.MenuLogin.Name = "MenuLogin";
            this.MenuLogin.Text = "Connexion";
            this.MenuLogin.Click += new System.EventHandler(this.MenuLogin_Click);
            // 
            // MenuLogout
            // 
            this.MenuLogout.Enabled = false;
            this.MenuLogout.Name = "MenuLogout";
            this.MenuLogout.Text = "Deconexion";
            this.MenuLogout.Click += new System.EventHandler(this.MenuLogout_Click);
            // 
            // MenuBackup
            // 
            this.MenuBackup.Enabled = false;
            this.MenuBackup.Name = "MenuBackup";
            this.MenuBackup.Text = "Backup";
            this.MenuBackup.Click += new System.EventHandler(this.MenuBackup_Click);
            // 
            // MenuRestor
            // 
            this.MenuRestor.Enabled = false;
            this.MenuRestor.Name = "MenuRestor";
            this.MenuRestor.Text = "Restaurer (Localement seulement)";
            this.MenuRestor.Click += new System.EventHandler(this.MenuRestor_Click);
            // 
            // MenuCloseApp
            // 
            this.MenuCloseApp.Name = "MenuCloseApp";
            this.MenuCloseApp.Text = "Quiter";
            this.MenuCloseApp.Click += new System.EventHandler(this.MenuCloseApp_Click);
            // 
            // MenuSettings
            // 
            this.MenuSettings.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuConnectionString});
            this.MenuSettings.Name = "MenuSettings";
            this.MenuSettings.Text = "Paramètres";
            // 
            // MenuConnectionString
            // 
            this.MenuConnectionString.Name = "MenuConnectionString";
            this.MenuConnectionString.Text = "chaîne de connexion";
            this.MenuConnectionString.Click += new System.EventHandler(this.MenuConnectionString_Click);
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement2.Name = "commandBarRowElement2";
            this.commandBarRowElement2.Text = "";
            this.commandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.UseCompatibleTextRendering = false;
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton1.Image")));
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.UseCompatibleTextRendering = false;
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement3.Name = "commandBarRowElement3";
            // 
            // FluxGrid
            // 
            this.FluxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluxGrid.Location = new System.Drawing.Point(0, 69);
            // 
            // 
            // 
            this.FluxGrid.MasterTemplate.AllowAddNewRow = false;
            this.FluxGrid.MasterTemplate.AllowColumnReorder = false;
            this.FluxGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.FluxGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.FluxGrid.Name = "FluxGrid";
            this.FluxGrid.ReadOnly = true;
            this.FluxGrid.Size = new System.Drawing.Size(1105, 578);
            this.FluxGrid.TabIndex = 2;
            this.FluxGrid.ThemeName = "VisualStudio2012Light";
            this.FluxGrid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.FluxGrid_CellDoubleClick);
            // 
            // radMenu1
            // 
            this.radMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuFicher,
            this.MenuSettings,
            this.MenuFicher,
            this.MenuSettings,
            this.MenuHelp});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1105, 20);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.ThemeName = "VisualStudio2012Light";
            // 
            // MenuHelp
            // 
            this.MenuHelp.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuActivation,
            this.MenuAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Text = "Aide";
            // 
            // MenuActivation
            // 
            this.MenuActivation.Name = "MenuActivation";
            this.MenuActivation.Text = "Activation";
            this.MenuActivation.Click += new System.EventHandler(this.MenuActivation_Click);
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Text = "À propos";
            this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Name = "commandBarRowElement1";
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.CommandBar});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.UseCompatibleTextRendering = false;
            // 
            // CommandBar
            // 
            this.CommandBar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.CommandBar.DisplayName = "Barre de commande";
            this.CommandBar.EnableBorderHighlight = false;
            this.CommandBar.Enabled = true;
            this.CommandBar.EnableDragging = false;
            this.CommandBar.EnableElementShadow = false;
            this.CommandBar.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAccountForm,
            this.btnContactForm,
            this.btnVendorForm,
            this.btnLeadForm,
            this.btnOppForm,
            this.btnProductForm,
            this.btnInvoiceForm,
            this.btnCompaignForm,
            this.btnPurchaseOrderForm,
            this.btnSalesOrderForm,
            this.btnQuoteForm,
            this.btnUsers,
            this.btnPriv,
            this.btnCategory,
            this.btnManufacturer,
            this.btnType,
            this.btnFlux,
            this.btnStatic});
            this.CommandBar.Name = "CommandBar";
            this.CommandBar.Text = "";
            this.CommandBar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.CommandBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.CommandBar.UseCompatibleTextRendering = false;
            // 
            // btnAccountForm
            // 
            this.btnAccountForm.ClipDrawing = false;
            this.btnAccountForm.ClipText = false;
            this.btnAccountForm.CustomFont = "None";
            this.btnAccountForm.CustomFontStyle = System.Drawing.FontStyle.Regular;
            this.btnAccountForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAccountForm.DisplayName = "Comptes";
            this.btnAccountForm.DrawText = true;
            this.btnAccountForm.Image = global::Yokai.Crm.Properties.Resources.flats;
            this.btnAccountForm.Name = "btnAccountForm";
            this.btnAccountForm.Text = "Comptes";
            this.btnAccountForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAccountForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAccountForm.UseCompatibleTextRendering = false;
            this.btnAccountForm.Click += new System.EventHandler(this.btnAccountForm_Click);
            // 
            // btnContactForm
            // 
            this.btnContactForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnContactForm.DisplayName = "Contacts";
            this.btnContactForm.DrawText = true;
            this.btnContactForm.Image = global::Yokai.Crm.Properties.Resources.collaboration;
            this.btnContactForm.Name = "btnContactForm";
            this.btnContactForm.Text = "Contacts";
            this.btnContactForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnContactForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnContactForm.UseCompatibleTextRendering = false;
            this.btnContactForm.Click += new System.EventHandler(this.btnContactForm_Click);
            // 
            // btnVendorForm
            // 
            this.btnVendorForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnVendorForm.DisplayName = "Fournisseurs";
            this.btnVendorForm.DrawText = true;
            this.btnVendorForm.Image = global::Yokai.Crm.Properties.Resources.trucking;
            this.btnVendorForm.Name = "btnVendorForm";
            this.btnVendorForm.Text = "Fournisseurs";
            this.btnVendorForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVendorForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnVendorForm.UseCompatibleTextRendering = false;
            this.btnVendorForm.Click += new System.EventHandler(this.btnVendorForm_Click);
            // 
            // btnLeadForm
            // 
            this.btnLeadForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnLeadForm.DisplayName = "Prospects";
            this.btnLeadForm.DrawText = true;
            this.btnLeadForm.Image = global::Yokai.Crm.Properties.Resources.chatting;
            this.btnLeadForm.Name = "btnLeadForm";
            this.btnLeadForm.Text = "Prospects";
            this.btnLeadForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLeadForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnLeadForm.UseCompatibleTextRendering = false;
            this.btnLeadForm.Click += new System.EventHandler(this.btnLeadForm_Click);
            // 
            // btnOppForm
            // 
            this.btnOppForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnOppForm.DisplayName = "Affaires";
            this.btnOppForm.DrawText = true;
            this.btnOppForm.Image = global::Yokai.Crm.Properties.Resources.office_material;
            this.btnOppForm.Name = "btnOppForm";
            this.btnOppForm.Text = "Affaires";
            this.btnOppForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOppForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnOppForm.UseCompatibleTextRendering = false;
            this.btnOppForm.Click += new System.EventHandler(this.btnOppForm_Click);
            // 
            // btnProductForm
            // 
            this.btnProductForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnProductForm.DisplayName = "Produits";
            this.btnProductForm.DrawText = true;
            this.btnProductForm.Image = global::Yokai.Crm.Properties.Resources.packing;
            this.btnProductForm.Name = "btnProductForm";
            this.btnProductForm.Text = "Produits";
            this.btnProductForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnProductForm.UseCompatibleTextRendering = false;
            this.btnProductForm.Click += new System.EventHandler(this.btnProductForm_Click);
            // 
            // btnInvoiceForm
            // 
            this.btnInvoiceForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnInvoiceForm.DisplayName = "Facture";
            this.btnInvoiceForm.DrawText = true;
            this.btnInvoiceForm.Image = global::Yokai.Crm.Properties.Resources.check_mark;
            this.btnInvoiceForm.Name = "btnInvoiceForm";
            this.btnInvoiceForm.Text = "Facture";
            this.btnInvoiceForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInvoiceForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnInvoiceForm.UseCompatibleTextRendering = false;
            this.btnInvoiceForm.Click += new System.EventHandler(this.btnInvoiceForm_Click);
            // 
            // btnCompaignForm
            // 
            this.btnCompaignForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnCompaignForm.DisplayName = "Campagne";
            this.btnCompaignForm.DrawText = true;
            this.btnCompaignForm.Image = global::Yokai.Crm.Properties.Resources.protest;
            this.btnCompaignForm.Name = "btnCompaignForm";
            this.btnCompaignForm.Text = "Campagne";
            this.btnCompaignForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCompaignForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnCompaignForm.UseCompatibleTextRendering = false;
            this.btnCompaignForm.Click += new System.EventHandler(this.btnCompaignForm_Click);
            // 
            // btnPurchaseOrderForm
            // 
            this.btnPurchaseOrderForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnPurchaseOrderForm.DisplayName = "Bon de Commande";
            this.btnPurchaseOrderForm.DrawText = true;
            this.btnPurchaseOrderForm.Image = global::Yokai.Crm.Properties.Resources.contract;
            this.btnPurchaseOrderForm.Name = "btnPurchaseOrderForm";
            this.btnPurchaseOrderForm.Text = "Bon de Commande";
            this.btnPurchaseOrderForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPurchaseOrderForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnPurchaseOrderForm.ToolTipText = "Bon de Commande";
            this.btnPurchaseOrderForm.UseCompatibleTextRendering = false;
            this.btnPurchaseOrderForm.Click += new System.EventHandler(this.btnPurchaseOrderForm_Click);
            // 
            // btnSalesOrderForm
            // 
            this.btnSalesOrderForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalesOrderForm.DisplayName = "Bon d\'achat";
            this.btnSalesOrderForm.DrawText = true;
            this.btnSalesOrderForm.Image = global::Yokai.Crm.Properties.Resources.check_mark;
            this.btnSalesOrderForm.Name = "btnSalesOrderForm";
            this.btnSalesOrderForm.Text = "Bon d\'achat";
            this.btnSalesOrderForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalesOrderForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalesOrderForm.ToolTipText = "Bon d\'achat";
            this.btnSalesOrderForm.UseCompatibleTextRendering = false;
            this.btnSalesOrderForm.Click += new System.EventHandler(this.btnSalesOrderForm_Click);
            // 
            // btnQuoteForm
            // 
            this.btnQuoteForm.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnQuoteForm.DisplayName = "Devis";
            this.btnQuoteForm.DrawText = true;
            this.btnQuoteForm.Image = global::Yokai.Crm.Properties.Resources.circular_graphic;
            this.btnQuoteForm.Name = "btnQuoteForm";
            this.btnQuoteForm.Text = "Devis";
            this.btnQuoteForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQuoteForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnQuoteForm.UseCompatibleTextRendering = false;
            this.btnQuoteForm.Click += new System.EventHandler(this.btnQuoteForm_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnUsers.DisplayName = "Utilisateurs";
            this.btnUsers.DrawText = true;
            this.btnUsers.Image = global::Yokai.Crm.Properties.Resources.boss;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Text = "Utilisateurs";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsers.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnUsers.UseCompatibleTextRendering = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnPriv
            // 
            this.btnPriv.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnPriv.DisplayName = "Privilèges";
            this.btnPriv.DrawText = true;
            this.btnPriv.Image = global::Yokai.Crm.Properties.Resources.Auth;
            this.btnPriv.Name = "btnPriv";
            this.btnPriv.Text = "Privilèges";
            this.btnPriv.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPriv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPriv.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnPriv.UseCompatibleTextRendering = false;
            this.btnPriv.Click += new System.EventHandler(this.btnPriv_click);
            // 
            // btnCategory
            // 
            this.btnCategory.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnCategory.DisplayName = "Categorie";
            this.btnCategory.DrawText = true;
            this.btnCategory.Image = global::Yokai.Crm.Properties.Resources.offices;
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Text = "Categorie";
            this.btnCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCategory.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnCategory.UseCompatibleTextRendering = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnManufacturer
            // 
            this.btnManufacturer.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnManufacturer.DisplayName = "Fabricant";
            this.btnManufacturer.DrawText = true;
            this.btnManufacturer.Image = global::Yokai.Crm.Properties.Resources.worker;
            this.btnManufacturer.Name = "btnManufacturer";
            this.btnManufacturer.Text = "Fabricant";
            this.btnManufacturer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManufacturer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnManufacturer.UseCompatibleTextRendering = false;
            this.btnManufacturer.Click += new System.EventHandler(this.btnManufacturer_Click);
            // 
            // btnType
            // 
            this.btnType.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnType.DisplayName = "Types";
            this.btnType.DrawText = true;
            this.btnType.Image = global::Yokai.Crm.Properties.Resources.message_types;
            this.btnType.Name = "btnType";
            this.btnType.Text = "Types";
            this.btnType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnType.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnType.UseCompatibleTextRendering = false;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnFlux
            // 
            this.btnFlux.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnFlux.DisplayName = "Flux";
            this.btnFlux.DrawText = true;
            this.btnFlux.Image = global::Yokai.Crm.Properties.Resources.mail;
            this.btnFlux.Name = "btnFlux";
            this.btnFlux.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFlux.Text = "Flux";
            this.btnFlux.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFlux.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnFlux.UseCompatibleTextRendering = false;
            this.btnFlux.Click += new System.EventHandler(this.btnFlux_Click);
            // 
            // btnStatic
            // 
            this.btnStatic.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnStatic.DisplayName = "Tableau de bord";
            this.btnStatic.DrawText = true;
            this.btnStatic.Image = global::Yokai.Crm.Properties.Resources.chart;
            this.btnStatic.Name = "btnStatic";
            this.btnStatic.Text = "Tableau de bord";
            this.btnStatic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStatic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnStatic.UseCompatibleTextRendering = false;
            this.btnStatic.Click += new System.EventHandler(this.btnStatic_Click);
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 20);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(1105, 49);
            this.radCommandBar1.TabIndex = 1;
            this.radCommandBar1.ThemeName = "VisualStudio2012Light";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1105, 647);
            this.Controls.Add(this.FluxGrid);
            this.Controls.Add(this.radCommandBar1);
            this.Controls.Add(this.radMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Relation Client";
            this.ThemeName = "VisualStudio2012Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.FluxGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FluxGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Telerik.WinControls.UI.RadMenuItem MenuFicher;
        private Telerik.WinControls.UI.RadMenuItem MenuLogin;
        private Telerik.WinControls.UI.RadMenuItem MenuLogout;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private Telerik.WinControls.UI.RadMenuItem MenuSettings;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private Telerik.WinControls.UI.RadGridView FluxGrid;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadMenuItem MenuConnectionString;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement CommandBar;
        private Telerik.WinControls.UI.CommandBarButton btnAccountForm;
        private Telerik.WinControls.UI.CommandBarButton btnContactForm;
        private Telerik.WinControls.UI.CommandBarButton btnVendorForm;
        private Telerik.WinControls.UI.CommandBarButton btnLeadForm;
        private Telerik.WinControls.UI.CommandBarButton btnOppForm;
        private Telerik.WinControls.UI.CommandBarButton btnProductForm;
        private Telerik.WinControls.UI.CommandBarButton btnInvoiceForm;
        private Telerik.WinControls.UI.CommandBarButton btnCompaignForm;
        private Telerik.WinControls.UI.CommandBarButton btnPurchaseOrderForm;
        private Telerik.WinControls.UI.CommandBarButton btnSalesOrderForm;
        private Telerik.WinControls.UI.CommandBarButton btnQuoteForm;
        private Telerik.WinControls.UI.CommandBarButton btnUsers;
        private Telerik.WinControls.UI.CommandBarButton btnPriv;
        private Telerik.WinControls.UI.CommandBarButton btnCategory;
        private Telerik.WinControls.UI.CommandBarButton btnManufacturer;
        private Telerik.WinControls.UI.CommandBarButton btnType;
        private Telerik.WinControls.UI.CommandBarButton btnFlux;
        private Telerik.WinControls.UI.CommandBarButton btnStatic;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.RadMenuItem MenuHelp;
        private Telerik.WinControls.UI.RadMenuItem MenuActivation;
        private Telerik.WinControls.UI.RadMenuItem MenuAbout;
        private Telerik.WinControls.UI.RadMenuItem MenuCloseApp;
        private Telerik.WinControls.UI.RadMenuItem MenuBackup;
        private Telerik.WinControls.UI.RadMenuItem MenuRestor;
    }
}
