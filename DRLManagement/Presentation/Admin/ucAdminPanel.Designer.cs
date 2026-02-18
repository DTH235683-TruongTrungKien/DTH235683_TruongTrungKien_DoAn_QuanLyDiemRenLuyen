namespace QLDRL.Forms.Admin
{
    partial class ucAdminPanel
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAdminPanel));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnUser = new Guna.UI2.WinForms.Guna2Button();
            btnBackup = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2Separator3
            // 
            guna2Separator3.FillColor = Color.White;
            guna2Separator3.Location = new Point(132, 17);
            guna2Separator3.Name = "guna2Separator3";
            guna2Separator3.Size = new Size(141, 12);
            guna2Separator3.TabIndex = 12;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(24, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 27);
            lblName.TabIndex = 13;
            lblName.Text = "Admin Panel";
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.White;
            btnUser.BorderColor = Color.White;
            btnUser.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnUser.CheckedState.FillColor = SystemColors.HotTrack;
            btnUser.CustomBorderColor = Color.Transparent;
            btnUser.CustomizableEdges = customizableEdges1;
            btnUser.DisabledState.BorderColor = Color.DarkGray;
            btnUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUser.FillColor = SystemColors.MenuHighlight;
            btnUser.FocusedColor = Color.Transparent;
            btnUser.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.ForeColor = Color.White;
            btnUser.HoverState.FillColor = Color.DodgerBlue;
            btnUser.Image = (Image)resources.GetObject("btnUser.Image");
            btnUser.ImageAlign = HorizontalAlignment.Left;
            btnUser.ImageOffset = new Point(10, 0);
            btnUser.ImageSize = new Size(30, 30);
            btnUser.Location = new Point(2, 52);
            btnUser.Name = "btnUser";
            btnUser.PressedColor = SystemColors.HotTrack;
            btnUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnUser.Size = new Size(300, 63);
            btnUser.TabIndex = 4;
            btnUser.Text = "Người dùng";
            btnUser.TextAlign = HorizontalAlignment.Left;
            btnUser.TextOffset = new Point(20, 0);
            btnUser.Click += btnUser_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.White;
            btnBackup.BorderColor = Color.White;
            btnBackup.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnBackup.CheckedState.FillColor = SystemColors.HotTrack;
            btnBackup.CustomBorderColor = Color.Transparent;
            btnBackup.CustomizableEdges = customizableEdges3;
            btnBackup.DisabledState.BorderColor = Color.DarkGray;
            btnBackup.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBackup.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBackup.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBackup.FillColor = SystemColors.MenuHighlight;
            btnBackup.FocusedColor = Color.Transparent;
            btnBackup.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackup.ForeColor = Color.White;
            btnBackup.HoverState.FillColor = Color.DodgerBlue;
            btnBackup.Image = (Image)resources.GetObject("btnBackup.Image");
            btnBackup.ImageAlign = HorizontalAlignment.Left;
            btnBackup.ImageOffset = new Point(5, 0);
            btnBackup.ImageSize = new Size(40, 40);
            btnBackup.Location = new Point(3, 121);
            btnBackup.Name = "btnBackup";
            btnBackup.PressedColor = SystemColors.HotTrack;
            btnBackup.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnBackup.Size = new Size(300, 63);
            btnBackup.TabIndex = 14;
            btnBackup.Text = "Sao lưu dữ liệu";
            btnBackup.TextAlign = HorizontalAlignment.Left;
            btnBackup.TextOffset = new Point(10, 0);
            btnBackup.Click += btnBackup_Click;
            // 
            // ucAdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            Controls.Add(btnBackup);
            Controls.Add(lblName);
            Controls.Add(guna2Separator3);
            Controls.Add(btnUser);
            Name = "ucAdminPanel";
            Size = new Size(300, 195);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnUser;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2Button btn;
        private Guna.UI2.WinForms.Guna2Button btnBackup;
    }
}
