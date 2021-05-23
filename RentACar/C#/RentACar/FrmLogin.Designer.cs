namespace RentACar
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.bunMinimizeIcon = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunExitIcon = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblLogin = new Bunifu.UI.WinForms.BunifuLabel();
            this.cbRole = new Bunifu.UI.WinForms.BunifuDropdown();
            this.btnExit = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtPassword = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtUsername = new Bunifu.UI.WinForms.BunifuTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblParagraph = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblWelcomeBack = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunSeperator = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuFormDock1 = new Bunifu.UI.WinForms.BunifuFormDock();
            this.pnlTopBar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlTopBar;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBar.BackgroundImage = global::RentACar.Properties.Resources.top_bar_gradient3;
            this.pnlTopBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTopBar.Controls.Add(this.bunMinimizeIcon);
            this.pnlTopBar.Controls.Add(this.bunExitIcon);
            this.pnlTopBar.Controls.Add(this.lblLogin);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(721, 37);
            this.pnlTopBar.TabIndex = 11;
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
            this.bunMinimizeIcon.ImageSize = new System.Drawing.Size(34, 24);
            this.bunMinimizeIcon.ImageZoomSize = new System.Drawing.Size(37, 27);
            this.bunMinimizeIcon.InitialImage = null;
            this.bunMinimizeIcon.Location = new System.Drawing.Point(645, 9);
            this.bunMinimizeIcon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunMinimizeIcon.Name = "bunMinimizeIcon";
            this.bunMinimizeIcon.Rotation = 0;
            this.bunMinimizeIcon.ShowActiveImage = true;
            this.bunMinimizeIcon.ShowCursorChanges = true;
            this.bunMinimizeIcon.ShowImageBorders = true;
            this.bunMinimizeIcon.ShowSizeMarkers = false;
            this.bunMinimizeIcon.Size = new System.Drawing.Size(37, 27);
            this.bunMinimizeIcon.TabIndex = 9;
            this.bunMinimizeIcon.TabStop = false;
            this.bunMinimizeIcon.ToolTipText = "Minimize";
            this.bunMinimizeIcon.WaitOnLoad = false;
            this.bunMinimizeIcon.Zoom = 3;
            this.bunMinimizeIcon.ZoomSpeed = 10;
            this.bunMinimizeIcon.Click += new System.EventHandler(this.bunMinimizeIcon_Click);
            // 
            // bunExitIcon
            // 
            this.bunExitIcon.ActiveImage = null;
            this.bunExitIcon.AllowAnimations = true;
            this.bunExitIcon.AllowBuffering = true;
            this.bunExitIcon.AllowToggling = false;
            this.bunExitIcon.AllowZooming = true;
            this.bunExitIcon.AllowZoomingOnFocus = false;
            this.bunExitIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bunExitIcon.BackColor = System.Drawing.Color.Transparent;
            this.bunExitIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunExitIcon.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunExitIcon.ErrorImage = null;
            this.bunExitIcon.FadeWhenInactive = false;
            this.bunExitIcon.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bunExitIcon.Image = global::RentACar.Properties.Resources.icons8_delete_96px;
            this.bunExitIcon.ImageActive = null;
            this.bunExitIcon.ImageLocation = null;
            this.bunExitIcon.ImageMargin = 4;
            this.bunExitIcon.ImageSize = new System.Drawing.Size(23, 23);
            this.bunExitIcon.ImageZoomSize = new System.Drawing.Size(27, 27);
            this.bunExitIcon.InitialImage = null;
            this.bunExitIcon.Location = new System.Drawing.Point(689, 6);
            this.bunExitIcon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunExitIcon.Name = "bunExitIcon";
            this.bunExitIcon.Rotation = 0;
            this.bunExitIcon.ShowActiveImage = true;
            this.bunExitIcon.ShowCursorChanges = true;
            this.bunExitIcon.ShowImageBorders = true;
            this.bunExitIcon.ShowSizeMarkers = false;
            this.bunExitIcon.Size = new System.Drawing.Size(27, 27);
            this.bunExitIcon.TabIndex = 9;
            this.bunExitIcon.TabStop = false;
            this.bunExitIcon.ToolTipText = "Exit";
            this.bunExitIcon.WaitOnLoad = false;
            this.bunExitIcon.Zoom = 4;
            this.bunExitIcon.ZoomSpeed = 10;
            this.bunExitIcon.Click += new System.EventHandler(this.bunExitIcon_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AllowParentOverrides = false;
            this.lblLogin.AutoEllipsis = false;
            this.lblLogin.CursorType = null;
            this.lblLogin.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(321, 4);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLogin.Size = new System.Drawing.Size(52, 26);
            this.lblLogin.TabIndex = 11;
            this.lblLogin.TabStop = false;
            this.lblLogin.Text = "Login";
            this.lblLogin.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.lblLogin.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cbRole
            // 
            this.cbRole.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cbRole.BackColor = System.Drawing.SystemColors.Control;
            this.cbRole.BackgroundColor = System.Drawing.Color.White;
            this.cbRole.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.cbRole.BorderRadius = 8;
            this.cbRole.Color = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.cbRole.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cbRole.DisabledBackColor = System.Drawing.SystemColors.GrayText;
            this.cbRole.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbRole.DisabledColor = System.Drawing.SystemColors.GrayText;
            this.cbRole.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cbRole.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRole.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cbRole.DropDownHeight = 115;
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbRole.FillDropDown = true;
            this.cbRole.FillIndicator = false;
            this.cbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRole.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRole.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Icon = null;
            this.cbRole.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbRole.IndicatorColor = System.Drawing.Color.DarkSlateGray;
            this.cbRole.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbRole.IntegralHeight = false;
            this.cbRole.ItemBackColor = System.Drawing.Color.White;
            this.cbRole.ItemBorderColor = System.Drawing.Color.White;
            this.cbRole.ItemForeColor = System.Drawing.Color.Black;
            this.cbRole.ItemHeight = 26;
            this.cbRole.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cbRole.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cbRole.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.cbRole.ItemTopMargin = 3;
            this.cbRole.Location = new System.Drawing.Point(389, 226);
            this.cbRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(282, 32);
            this.cbRole.TabIndex = 2;
            this.cbRole.Text = "Role";
            this.cbRole.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbRole.TextLeftMargin = 5;
            // 
            // btnExit
            // 
            this.btnExit.AllowToggling = false;
            this.btnExit.AnimationSpeed = 200;
            this.btnExit.AutoGenerateColors = false;
            this.btnExit.AutoSizeLeftIcon = true;
            this.btnExit.AutoSizeRightIcon = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExit.ButtonText = "Exit";
            this.btnExit.ButtonTextMarginLeft = 0;
            this.btnExit.ColorContrastOnClick = 45;
            this.btnExit.ColorContrastOnHover = 45;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnExit.CustomizableEdges = borderEdges1;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnExit.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExit.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnExit.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnExit.IconMarginLeft = 11;
            this.btnExit.IconPadding = 10;
            this.btnExit.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnExit.IconSize = 25;
            this.btnExit.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnExit.IdleBorderRadius = 25;
            this.btnExit.IdleBorderThickness = 1;
            this.btnExit.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.btnExit.IdleIconLeftImage = null;
            this.btnExit.IdleIconRightImage = null;
            this.btnExit.IndicateFocus = false;
            this.btnExit.Location = new System.Drawing.Point(355, 314);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.OnDisabledState.BorderColor = System.Drawing.Color.Empty;
            this.btnExit.OnDisabledState.BorderRadius = 25;
            this.btnExit.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExit.OnDisabledState.BorderThickness = 1;
            this.btnExit.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExit.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnExit.OnDisabledState.IconLeftImage = null;
            this.btnExit.OnDisabledState.IconRightImage = null;
            this.btnExit.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnExit.onHoverState.BorderRadius = 25;
            this.btnExit.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExit.onHoverState.BorderThickness = 1;
            this.btnExit.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnExit.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnExit.onHoverState.IconLeftImage = null;
            this.btnExit.onHoverState.IconRightImage = null;
            this.btnExit.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnExit.OnIdleState.BorderRadius = 25;
            this.btnExit.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExit.OnIdleState.BorderThickness = 1;
            this.btnExit.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.btnExit.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnExit.OnIdleState.IconLeftImage = null;
            this.btnExit.OnIdleState.IconRightImage = null;
            this.btnExit.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnExit.OnPressedState.BorderRadius = 25;
            this.btnExit.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExit.OnPressedState.BorderThickness = 1;
            this.btnExit.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnExit.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnExit.OnPressedState.IconLeftImage = null;
            this.btnExit.OnPressedState.IconRightImage = null;
            this.btnExit.Size = new System.Drawing.Size(161, 46);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExit.TextMarginLeft = 0;
            this.btnExit.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnExit.UseDefaultRadiusAndThickness = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AllowToggling = false;
            this.btnLogin.AnimationSpeed = 200;
            this.btnLogin.AutoGenerateColors = false;
            this.btnLogin.AutoSizeLeftIcon = true;
            this.btnLogin.AutoSizeRightIcon = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.ButtonText = "Login";
            this.btnLogin.ButtonTextMarginLeft = 0;
            this.btnLogin.ColorContrastOnClick = 45;
            this.btnLogin.ColorContrastOnHover = 45;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnLogin.CustomizableEdges = borderEdges2;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnLogin.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnLogin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogin.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogin.IconMarginLeft = 11;
            this.btnLogin.IconPadding = 10;
            this.btnLogin.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogin.IconSize = 25;
            this.btnLogin.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLogin.IdleBorderRadius = 25;
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnLogin.IdleIconLeftImage = null;
            this.btnLogin.IdleIconRightImage = null;
            this.btnLogin.IndicateFocus = false;
            this.btnLogin.Location = new System.Drawing.Point(536, 314);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnDisabledState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.OnDisabledState.BorderRadius = 25;
            this.btnLogin.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnDisabledState.BorderThickness = 1;
            this.btnLogin.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.OnDisabledState.IconLeftImage = null;
            this.btnLogin.OnDisabledState.IconRightImage = null;
            this.btnLogin.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnLogin.onHoverState.BorderRadius = 25;
            this.btnLogin.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.onHoverState.BorderThickness = 1;
            this.btnLogin.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnLogin.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.onHoverState.IconLeftImage = null;
            this.btnLogin.onHoverState.IconRightImage = null;
            this.btnLogin.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLogin.OnIdleState.BorderRadius = 25;
            this.btnLogin.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnIdleState.BorderThickness = 1;
            this.btnLogin.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.btnLogin.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogin.OnIdleState.IconLeftImage = null;
            this.btnLogin.OnIdleState.IconRightImage = null;
            this.btnLogin.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLogin.OnPressedState.BorderRadius = 25;
            this.btnLogin.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnPressedState.BorderThickness = 1;
            this.btnLogin.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLogin.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.OnPressedState.IconLeftImage = null;
            this.btnLogin.OnPressedState.IconRightImage = null;
            this.btnLogin.Size = new System.Drawing.Size(161, 46);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.TextMarginLeft = 0;
            this.btnLogin.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogin.UseDefaultRadiusAndThickness = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsReturn = false;
            this.txtPassword.AcceptsTab = false;
            this.txtPassword.AnimationSpeed = 200;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPassword.BackgroundImage")));
            this.txtPassword.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtPassword.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtPassword.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.txtPassword.BorderRadius = 20;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.DefaultText = "";
            this.txtPassword.FillColor = System.Drawing.Color.White;
            this.txtPassword.HideSelection = true;
            this.txtPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPassword.IconLeft")));
            this.txtPassword.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.IconPadding = 10;
            this.txtPassword.IconRight = null;
            this.txtPassword.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(389, 148);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPassword.Modified = false;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            stateProperties1.BorderColor = System.Drawing.Color.Indigo;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPassword.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPassword.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.Empty;
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPassword.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPassword.OnIdleState = stateProperties4;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.MidnightBlue;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.ReadOnly = false;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(282, 51);
            this.txtPassword.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.TextMarginBottom = 0;
            this.txtPassword.TextMarginLeft = 3;
            this.txtPassword.TextMarginTop = 0;
            this.txtPassword.TextPlaceholder = "Password";
            this.txtPassword.UseSystemPasswordChar = false;
            this.txtPassword.WordWrap = true;
            // 
            // txtUsername
            // 
            this.txtUsername.AcceptsReturn = false;
            this.txtUsername.AcceptsTab = false;
            this.txtUsername.AnimationSpeed = 200;
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUsername.BackgroundImage")));
            this.txtUsername.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtUsername.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtUsername.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtUsername.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            this.txtUsername.BorderRadius = 20;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.DefaultText = "";
            this.txtUsername.FillColor = System.Drawing.Color.White;
            this.txtUsername.HideSelection = true;
            this.txtUsername.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtUsername.IconLeft")));
            this.txtUsername.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.IconPadding = 13;
            this.txtUsername.IconRight = null;
            this.txtUsername.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(389, 73);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtUsername.Modified = false;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            stateProperties5.BorderColor = System.Drawing.Color.Indigo;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUsername.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.Empty;
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUsername.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.Empty;
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUsername.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(84)))), ((int)(((byte)(109)))));
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUsername.OnIdleState = stateProperties8;
            this.txtUsername.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.MidnightBlue;
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.ReadOnly = false;
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(282, 51);
            this.txtUsername.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.TextMarginBottom = 0;
            this.txtUsername.TextMarginLeft = 3;
            this.txtUsername.TextMarginTop = 0;
            this.txtUsername.TextPlaceholder = "Username";
            this.txtUsername.UseSystemPasswordChar = false;
            this.txtUsername.WordWrap = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 391);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lblParagraph);
            this.panel4.Controls.Add(this.lblWelcomeBack);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(324, 391);
            this.panel4.TabIndex = 0;
            // 
            // lblParagraph
            // 
            this.lblParagraph.AllowParentOverrides = false;
            this.lblParagraph.AutoEllipsis = false;
            this.lblParagraph.CursorType = null;
            this.lblParagraph.Font = new System.Drawing.Font("Gadugi", 15.75F);
            this.lblParagraph.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblParagraph.Location = new System.Drawing.Point(42, 189);
            this.lblParagraph.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblParagraph.Name = "lblParagraph";
            this.lblParagraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblParagraph.Size = new System.Drawing.Size(251, 50);
            this.lblParagraph.TabIndex = 9;
            this.lblParagraph.TabStop = false;
            this.lblParagraph.Text = "Please type your Username<br> and Password to begin. ";
            this.lblParagraph.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblParagraph.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblWelcomeBack
            // 
            this.lblWelcomeBack.AllowParentOverrides = false;
            this.lblWelcomeBack.AutoEllipsis = false;
            this.lblWelcomeBack.CursorType = null;
            this.lblWelcomeBack.Font = new System.Drawing.Font("Kristen ITC", 21.75F);
            this.lblWelcomeBack.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeBack.Location = new System.Drawing.Point(61, 35);
            this.lblWelcomeBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblWelcomeBack.Name = "lblWelcomeBack";
            this.lblWelcomeBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWelcomeBack.Size = new System.Drawing.Size(206, 40);
            this.lblWelcomeBack.TabIndex = 9;
            this.lblWelcomeBack.TabStop = false;
            this.lblWelcomeBack.Text = "Welcome Back";
            this.lblWelcomeBack.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblWelcomeBack.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunSeperator
            // 
            this.bunSeperator.BackColor = System.Drawing.Color.Transparent;
            this.bunSeperator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunSeperator.BackgroundImage")));
            this.bunSeperator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunSeperator.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunSeperator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(79)))), ((int)(((byte)(86)))));
            this.bunSeperator.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunSeperator.LineThickness = 11;
            this.bunSeperator.Location = new System.Drawing.Point(321, 37);
            this.bunSeperator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunSeperator.Name = "bunSeperator";
            this.bunSeperator.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
            this.bunSeperator.Size = new System.Drawing.Size(15, 391);
            this.bunSeperator.TabIndex = 11;
            this.bunSeperator.TabStop = false;
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
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(721, 428);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bunSeperator);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnlTopBar;
        private Bunifu.UI.WinForms.BunifuLabel lblLogin;
        private Bunifu.UI.WinForms.BunifuSeparator bunSeperator;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.UI.WinForms.BunifuImageButton bunExitIcon;
        private Bunifu.UI.WinForms.BunifuImageButton bunMinimizeIcon;
        private Bunifu.UI.WinForms.BunifuTextBox txtPassword;
        private Bunifu.UI.WinForms.BunifuTextBox txtUsername;
        private Bunifu.UI.WinForms.BunifuLabel lblParagraph;
        private Bunifu.UI.WinForms.BunifuLabel lblWelcomeBack;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogin;
        private Bunifu.UI.WinForms.BunifuDropdown cbRole;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnExit;
        private Bunifu.UI.WinForms.BunifuFormDock bunifuFormDock1;
    }
}