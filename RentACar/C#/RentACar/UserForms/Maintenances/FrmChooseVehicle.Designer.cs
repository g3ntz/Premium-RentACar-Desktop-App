namespace RentACar.UserForms.Maintenances
{
    partial class FrmChooseVehicle
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges14 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges13 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChooseVehicle));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dgVehicles = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.StringVehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transmission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.bunMinimizeIcon = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnExitIcon = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuFormDock1 = new Bunifu.UI.WinForms.BunifuFormDock();
            this.lblTip = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicles)).BeginInit();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dgVehicles
            // 
            this.dgVehicles.AllowCustomTheming = false;
            this.dgVehicles.AllowUserToAddRows = false;
            this.dgVehicles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            this.dgVehicles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVehicles.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgVehicles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgVehicles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgVehicles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgVehicles.ColumnHeadersHeight = 40;
            this.dgVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StringVehicleID,
            this.Make,
            this.Model,
            this.Transmission,
            this.PlateNr});
            this.dgVehicles.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgVehicles.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgVehicles.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgVehicles.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgVehicles.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgVehicles.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgVehicles.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgVehicles.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgVehicles.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgVehicles.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgVehicles.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgVehicles.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgVehicles.CurrentTheme.Name = null;
            this.dgVehicles.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVehicles.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgVehicles.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgVehicles.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgVehicles.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgVehicles.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVehicles.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgVehicles.EnableHeadersVisualStyles = false;
            this.dgVehicles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgVehicles.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgVehicles.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgVehicles.HeaderForeColor = System.Drawing.Color.White;
            this.dgVehicles.Location = new System.Drawing.Point(12, 58);
            this.dgVehicles.Name = "dgVehicles";
            this.dgVehicles.ReadOnly = true;
            this.dgVehicles.RowHeadersVisible = false;
            this.dgVehicles.RowTemplate.Height = 40;
            this.dgVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVehicles.Size = new System.Drawing.Size(776, 342);
            this.dgVehicles.TabIndex = 0;
            this.dgVehicles.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dgVehicles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVehicles_CellClick);
            // 
            // StringVehicleID
            // 
            this.StringVehicleID.DataPropertyName = "StringVehicleID";
            this.StringVehicleID.HeaderText = "ID";
            this.StringVehicleID.Name = "StringVehicleID";
            this.StringVehicleID.ReadOnly = true;
            // 
            // Make
            // 
            this.Make.DataPropertyName = "StringVehicleMake";
            this.Make.HeaderText = "Make";
            this.Make.Name = "Make";
            this.Make.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.DataPropertyName = "StringVehicleModel";
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // Transmission
            // 
            this.Transmission.DataPropertyName = "Transmission";
            this.Transmission.HeaderText = "Transmission";
            this.Transmission.Name = "Transmission";
            this.Transmission.ReadOnly = true;
            // 
            // PlateNr
            // 
            this.PlateNr.DataPropertyName = "PlateNr";
            this.PlateNr.HeaderText = "Plate Nr";
            this.PlateNr.Name = "PlateNr";
            this.PlateNr.ReadOnly = true;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBar.BackgroundImage = global::RentACar.Properties.Resources.top_bar_gradient2;
            this.pnlTopBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTopBar.Controls.Add(this.bunMinimizeIcon);
            this.pnlTopBar.Controls.Add(this.btnExitIcon);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(800, 37);
            this.pnlTopBar.TabIndex = 53;
            // 
            // bunMinimizeIcon
            // 
            this.bunMinimizeIcon.ActiveImage = null;
            this.bunMinimizeIcon.AllowAnimations = true;
            this.bunMinimizeIcon.AllowBuffering = true;
            this.bunMinimizeIcon.AllowToggling = false;
            this.bunMinimizeIcon.AllowZooming = true;
            this.bunMinimizeIcon.AllowZoomingOnFocus = false;
            this.bunMinimizeIcon.BackColor = System.Drawing.Color.Transparent;
            this.bunMinimizeIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunMinimizeIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunMinimizeIcon.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunMinimizeIcon.ErrorImage = null;
            this.bunMinimizeIcon.FadeWhenInactive = false;
            this.bunMinimizeIcon.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bunMinimizeIcon.Image = global::RentACar.Properties.Resources.icons8_horizontal_line_96px;
            this.bunMinimizeIcon.ImageActive = null;
            this.bunMinimizeIcon.ImageLocation = null;
            this.bunMinimizeIcon.ImageMargin = 3;
            this.bunMinimizeIcon.ImageSize = new System.Drawing.Size(30, 24);
            this.bunMinimizeIcon.ImageZoomSize = new System.Drawing.Size(33, 27);
            this.bunMinimizeIcon.InitialImage = null;
            this.bunMinimizeIcon.Location = new System.Drawing.Point(725, 8);
            this.bunMinimizeIcon.Name = "bunMinimizeIcon";
            this.bunMinimizeIcon.Rotation = 0;
            this.bunMinimizeIcon.ShowActiveImage = true;
            this.bunMinimizeIcon.ShowCursorChanges = true;
            this.bunMinimizeIcon.ShowImageBorders = true;
            this.bunMinimizeIcon.ShowSizeMarkers = false;
            this.bunMinimizeIcon.Size = new System.Drawing.Size(33, 27);
            this.bunMinimizeIcon.TabIndex = 9;
            this.bunMinimizeIcon.TabStop = false;
            this.bunMinimizeIcon.ToolTipText = "Minimize";
            this.bunMinimizeIcon.WaitOnLoad = false;
            this.bunMinimizeIcon.Zoom = 3;
            this.bunMinimizeIcon.ZoomSpeed = 10;
            this.bunMinimizeIcon.Click += new System.EventHandler(this.bunMinimizeIcon_Click);
            // 
            // btnExitIcon
            // 
            this.btnExitIcon.ActiveImage = null;
            this.btnExitIcon.AllowAnimations = true;
            this.btnExitIcon.AllowBuffering = true;
            this.btnExitIcon.AllowToggling = false;
            this.btnExitIcon.AllowZooming = true;
            this.btnExitIcon.AllowZoomingOnFocus = false;
            this.btnExitIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExitIcon.BackColor = System.Drawing.Color.Transparent;
            this.btnExitIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExitIcon.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExitIcon.ErrorImage = null;
            this.btnExitIcon.FadeWhenInactive = false;
            this.btnExitIcon.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnExitIcon.Image = global::RentACar.Properties.Resources.icons8_delete_96px;
            this.btnExitIcon.ImageActive = null;
            this.btnExitIcon.ImageLocation = null;
            this.btnExitIcon.ImageMargin = 4;
            this.btnExitIcon.ImageSize = new System.Drawing.Size(23, 23);
            this.btnExitIcon.ImageZoomSize = new System.Drawing.Size(27, 27);
            this.btnExitIcon.InitialImage = null;
            this.btnExitIcon.Location = new System.Drawing.Point(768, 5);
            this.btnExitIcon.Name = "btnExitIcon";
            this.btnExitIcon.Rotation = 0;
            this.btnExitIcon.ShowActiveImage = true;
            this.btnExitIcon.ShowCursorChanges = true;
            this.btnExitIcon.ShowImageBorders = true;
            this.btnExitIcon.ShowSizeMarkers = false;
            this.btnExitIcon.Size = new System.Drawing.Size(27, 27);
            this.btnExitIcon.TabIndex = 9;
            this.btnExitIcon.TabStop = false;
            this.btnExitIcon.ToolTipText = "Exit";
            this.btnExitIcon.WaitOnLoad = false;
            this.btnExitIcon.Zoom = 4;
            this.btnExitIcon.ZoomSpeed = 10;
            this.btnExitIcon.Click += new System.EventHandler(this.btnExitIcon_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowToggling = false;
            this.btnSave.AnimationSpeed = 200;
            this.btnSave.AutoGenerateColors = false;
            this.btnSave.AutoSizeLeftIcon = true;
            this.btnSave.AutoSizeRightIcon = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColor1 = System.Drawing.Color.Indigo;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.ButtonText = "Add";
            this.btnSave.ButtonTextMarginLeft = 0;
            this.btnSave.ColorContrastOnClick = 45;
            this.btnSave.ColorContrastOnHover = 45;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges14.BottomLeft = true;
            borderEdges14.BottomRight = true;
            borderEdges14.TopLeft = true;
            borderEdges14.TopRight = true;
            this.btnSave.CustomizableEdges = borderEdges14;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnSave.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.Enabled = false;
            this.btnSave.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSave.IconMarginLeft = 11;
            this.btnSave.IconPadding = 10;
            this.btnSave.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSave.IconSize = 25;
            this.btnSave.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.IdleBorderRadius = 3;
            this.btnSave.IdleBorderThickness = 1;
            this.btnSave.IdleFillColor = System.Drawing.Color.Indigo;
            this.btnSave.IdleIconLeftImage = null;
            this.btnSave.IdleIconRightImage = null;
            this.btnSave.IndicateFocus = false;
            this.btnSave.Location = new System.Drawing.Point(599, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnDisabledState.BorderColor = System.Drawing.Color.Empty;
            this.btnSave.OnDisabledState.BorderRadius = 3;
            this.btnSave.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnDisabledState.BorderThickness = 1;
            this.btnSave.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.OnDisabledState.IconLeftImage = null;
            this.btnSave.OnDisabledState.IconRightImage = null;
            this.btnSave.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.BorderRadius = 3;
            this.btnSave.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.onHoverState.BorderThickness = 1;
            this.btnSave.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.onHoverState.IconLeftImage = null;
            this.btnSave.onHoverState.IconRightImage = null;
            this.btnSave.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnIdleState.BorderRadius = 3;
            this.btnSave.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnIdleState.BorderThickness = 1;
            this.btnSave.OnIdleState.FillColor = System.Drawing.Color.Indigo;
            this.btnSave.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.OnIdleState.IconLeftImage = null;
            this.btnSave.OnIdleState.IconRightImage = null;
            this.btnSave.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.OnPressedState.BorderRadius = 3;
            this.btnSave.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnPressedState.BorderThickness = 1;
            this.btnSave.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnPressedState.IconLeftImage = null;
            this.btnSave.OnPressedState.IconRightImage = null;
            this.btnSave.Size = new System.Drawing.Size(150, 39);
            this.btnSave.TabIndex = 73;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.TextMarginLeft = 0;
            this.btnSave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSave.UseDefaultRadiusAndThickness = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AllowToggling = false;
            this.btnCancel.AnimationSpeed = 200;
            this.btnCancel.AutoGenerateColors = false;
            this.btnCancel.AutoSizeLeftIcon = true;
            this.btnCancel.AutoSizeRightIcon = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.ButtonTextMarginLeft = 0;
            this.btnCancel.ColorContrastOnClick = 45;
            this.btnCancel.ColorContrastOnHover = 45;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges13.BottomLeft = true;
            borderEdges13.BottomRight = true;
            borderEdges13.TopLeft = true;
            borderEdges13.TopRight = true;
            this.btnCancel.CustomizableEdges = borderEdges13;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnCancel.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCancel.IconMarginLeft = 11;
            this.btnCancel.IconPadding = 10;
            this.btnCancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCancel.IconSize = 25;
            this.btnCancel.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.IdleBorderRadius = 3;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.btnCancel.IdleIconLeftImage = null;
            this.btnCancel.IdleIconRightImage = null;
            this.btnCancel.IndicateFocus = false;
            this.btnCancel.Location = new System.Drawing.Point(414, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnDisabledState.BorderColor = System.Drawing.Color.Empty;
            this.btnCancel.OnDisabledState.BorderRadius = 3;
            this.btnCancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.OnDisabledState.BorderThickness = 1;
            this.btnCancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancel.OnDisabledState.IconLeftImage = null;
            this.btnCancel.OnDisabledState.IconRightImage = null;
            this.btnCancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCancel.onHoverState.BorderRadius = 3;
            this.btnCancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.onHoverState.BorderThickness = 1;
            this.btnCancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.onHoverState.IconLeftImage = null;
            this.btnCancel.onHoverState.IconRightImage = null;
            this.btnCancel.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.OnIdleState.BorderRadius = 3;
            this.btnCancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.OnIdleState.BorderThickness = 1;
            this.btnCancel.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.btnCancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnIdleState.IconLeftImage = null;
            this.btnCancel.OnIdleState.IconRightImage = null;
            this.btnCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCancel.OnPressedState.BorderRadius = 3;
            this.btnCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.OnPressedState.BorderThickness = 1;
            this.btnCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnPressedState.IconLeftImage = null;
            this.btnCancel.OnPressedState.IconRightImage = null;
            this.btnCancel.Size = new System.Drawing.Size(150, 39);
            this.btnCancel.TabIndex = 74;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancel.TextMarginLeft = 0;
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseDefaultRadiusAndThickness = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bunifuFormDock1
            // 
            this.bunifuFormDock1.AllowFormDragging = true;
            this.bunifuFormDock1.AllowFormDropShadow = true;
            this.bunifuFormDock1.AllowFormResizing = false;
            this.bunifuFormDock1.AllowHidingBottomRegion = true;
            this.bunifuFormDock1.AllowOpacityChangesWhileDragging = true;
            this.bunifuFormDock1.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.BottomBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.BottomBorder.ShowBorder = true;
            this.bunifuFormDock1.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.LeftBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.LeftBorder.ShowBorder = true;
            this.bunifuFormDock1.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.RightBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.RightBorder.ShowBorder = true;
            this.bunifuFormDock1.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.TopBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.TopBorder.ShowBorder = true;
            this.bunifuFormDock1.ContainerControl = this;
            this.bunifuFormDock1.DockingIndicatorsColor = System.Drawing.Color.Indigo;
            this.bunifuFormDock1.DockingIndicatorsOpacity = 0.5D;
            this.bunifuFormDock1.DockingOptions.DockAll = false;
            this.bunifuFormDock1.DockingOptions.DockBottomLeft = false;
            this.bunifuFormDock1.DockingOptions.DockBottomRight = false;
            this.bunifuFormDock1.DockingOptions.DockFullScreen = false;
            this.bunifuFormDock1.DockingOptions.DockLeft = false;
            this.bunifuFormDock1.DockingOptions.DockRight = false;
            this.bunifuFormDock1.DockingOptions.DockTopLeft = false;
            this.bunifuFormDock1.DockingOptions.DockTopRight = false;
            this.bunifuFormDock1.FormDraggingOpacity = 0.9D;
            this.bunifuFormDock1.ParentForm = this;
            this.bunifuFormDock1.ShowCursorChanges = true;
            this.bunifuFormDock1.ShowDockingIndicators = true;
            this.bunifuFormDock1.TitleBarOptions.AllowFormDragging = true;
            this.bunifuFormDock1.TitleBarOptions.BunifuFormDock = this.bunifuFormDock1;
            this.bunifuFormDock1.TitleBarOptions.DoubleClickToExpandWindow = true;
            this.bunifuFormDock1.TitleBarOptions.TitleBarControl = this.pnlTopBar;
            this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            // 
            // lblTip
            // 
            this.lblTip.AllowParentOverrides = false;
            this.lblTip.AutoEllipsis = false;
            this.lblTip.CursorType = null;
            this.lblTip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTip.ForeColor = System.Drawing.Color.Black;
            this.lblTip.Location = new System.Drawing.Point(12, 418);
            this.lblTip.Name = "lblTip";
            this.lblTip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTip.Size = new System.Drawing.Size(127, 19);
            this.lblTip.TabIndex = 75;
            this.lblTip.Text = "Tip:Select a Vehicle";
            this.lblTip.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblTip.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // FrmChooseVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.dgVehicles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChooseVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChooseVehicle";
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicles)).EndInit();
            this.pnlTopBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuDataGridView dgVehicles;
        private System.Windows.Forms.Panel pnlTopBar;
        private Bunifu.UI.WinForms.BunifuImageButton bunMinimizeIcon;
        private Bunifu.UI.WinForms.BunifuImageButton btnExitIcon;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCancel;
        private Bunifu.UI.WinForms.BunifuFormDock bunifuFormDock1;
        private Bunifu.UI.WinForms.BunifuLabel lblTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn StringVehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Make;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNr;
    }
}