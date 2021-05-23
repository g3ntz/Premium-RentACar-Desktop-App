namespace RentACar.UserControls
{
    partial class MaintenanceStates
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceStates));
            this.bunifuLabel11 = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.bunifuLabel10 = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel11
            // 
            this.bunifuLabel11.AllowParentOverrides = false;
            this.bunifuLabel11.AutoEllipsis = false;
            this.bunifuLabel11.CursorType = null;
            this.bunifuLabel11.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuLabel11.Location = new System.Drawing.Point(38, 3);
            this.bunifuLabel11.Name = "bunifuLabel11";
            this.bunifuLabel11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel11.Size = new System.Drawing.Size(40, 17);
            this.bunifuLabel11.TabIndex = 35;
            this.bunifuLabel11.Text = "Closed";
            this.bunifuLabel11.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel11.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::RentACar.Properties.Resources.greenCircle;
            this.pictureBox7.Location = new System.Drawing.Point(7, 8);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(10, 10);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 34;
            this.pictureBox7.TabStop = false;
            // 
            // bunifuLabel10
            // 
            this.bunifuLabel10.AllowParentOverrides = false;
            this.bunifuLabel10.AutoEllipsis = false;
            this.bunifuLabel10.CursorType = null;
            this.bunifuLabel10.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuLabel10.Location = new System.Drawing.Point(140, 3);
            this.bunifuLabel10.Name = "bunifuLabel10";
            this.bunifuLabel10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel10.Size = new System.Drawing.Size(32, 17);
            this.bunifuLabel10.TabIndex = 37;
            this.bunifuLabel10.Text = "Open";
            this.bunifuLabel10.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel10.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::RentACar.Properties.Resources.redCircle;
            this.pictureBox6.Location = new System.Drawing.Point(106, 8);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(10, 10);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 36;
            this.pictureBox6.TabStop = false;
            // 
            // MaintenanceStates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuLabel10);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.bunifuLabel11);
            this.Controls.Add(this.pictureBox7);
            this.Name = "MaintenanceStates";
            this.Size = new System.Drawing.Size(184, 27);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel11;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel10;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}
