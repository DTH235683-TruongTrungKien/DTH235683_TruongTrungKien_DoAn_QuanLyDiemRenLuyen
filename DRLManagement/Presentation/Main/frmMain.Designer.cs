namespace QLDRL.Forms.Main
{
    partial class frmMain
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            btnSetting = new Guna.UI2.WinForms.Guna2Button();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            btnAccount = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.MenuHighlight;
            pnlMenu.Controls.Add(btnSetting);
            pnlMenu.Controls.Add(lblName);
            pnlMenu.Controls.Add(guna2Separator3);
            pnlMenu.Controls.Add(btnAccount);
            pnlMenu.Controls.Add(btnLogout);
            pnlMenu.Controls.Add(lblUsername);
            pnlMenu.Controls.Add(guna2CirclePictureBox1);
            pnlMenu.Controls.Add(guna2Separator2);
            pnlMenu.CustomizableEdges = customizableEdges8;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.ShadowDecoration.CustomizableEdges = customizableEdges9;
            pnlMenu.Size = new Size(296, 953);
            pnlMenu.TabIndex = 0;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = Color.White;
            btnSetting.BorderColor = Color.White;
            btnSetting.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnSetting.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnSetting.CheckedState.FillColor = SystemColors.HotTrack;
            btnSetting.CustomBorderColor = Color.Transparent;
            btnSetting.CustomizableEdges = customizableEdges1;
            btnSetting.DisabledState.BorderColor = Color.DarkGray;
            btnSetting.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSetting.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSetting.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSetting.FillColor = SystemColors.MenuHighlight;
            btnSetting.FocusedColor = Color.Transparent;
            btnSetting.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSetting.ForeColor = Color.White;
            btnSetting.HoverState.FillColor = Color.DodgerBlue;
            btnSetting.Image = (Image)resources.GetObject("btnSetting.Image");
            btnSetting.ImageAlign = HorizontalAlignment.Left;
            btnSetting.ImageOffset = new Point(10, 0);
            btnSetting.ImageSize = new Size(30, 30);
            btnSetting.Location = new Point(-1, 183);
            btnSetting.Name = "btnSetting";
            btnSetting.PressedColor = SystemColors.HotTrack;
            btnSetting.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSetting.Size = new Size(300, 63);
            btnSetting.TabIndex = 28;
            btnSetting.Text = "Cài đặt";
            btnSetting.TextAlign = HorizontalAlignment.Left;
            btnSetting.TextOffset = new Point(20, 0);
            btnSetting.Click += btnSetting_Click;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(21, 76);
            lblName.Name = "lblName";
            lblName.Size = new Size(66, 27);
            lblName.TabIndex = 27;
            lblName.Text = "General";
            // 
            // guna2Separator3
            // 
            guna2Separator3.FillColor = Color.White;
            guna2Separator3.Location = new Point(93, 84);
            guna2Separator3.Name = "guna2Separator3";
            guna2Separator3.Size = new Size(177, 12);
            guna2Separator3.TabIndex = 26;
            // 
            // btnAccount
            // 
            btnAccount.BackColor = Color.White;
            btnAccount.BorderColor = Color.White;
            btnAccount.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnAccount.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnAccount.CheckedState.FillColor = SystemColors.HotTrack;
            btnAccount.CustomBorderColor = Color.Transparent;
            btnAccount.CustomizableEdges = customizableEdges3;
            btnAccount.DisabledState.BorderColor = Color.DarkGray;
            btnAccount.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAccount.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAccount.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAccount.FillColor = SystemColors.MenuHighlight;
            btnAccount.FocusedColor = Color.Transparent;
            btnAccount.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAccount.ForeColor = Color.White;
            btnAccount.HoverState.FillColor = Color.DodgerBlue;
            btnAccount.Image = (Image)resources.GetObject("btnAccount.Image");
            btnAccount.ImageAlign = HorizontalAlignment.Left;
            btnAccount.ImageOffset = new Point(10, 0);
            btnAccount.ImageSize = new Size(30, 30);
            btnAccount.Location = new Point(-1, 119);
            btnAccount.Name = "btnAccount";
            btnAccount.PressedColor = SystemColors.HotTrack;
            btnAccount.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAccount.Size = new Size(300, 63);
            btnAccount.TabIndex = 25;
            btnAccount.Text = "Tài khoản";
            btnAccount.TextAlign = HorizontalAlignment.Left;
            btnAccount.TextOffset = new Point(20, 0);
            btnAccount.Click += btnAccount_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.BorderColor = Color.White;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.CustomBorderColor = Color.Transparent;
            btnLogout.CustomizableEdges = customizableEdges5;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = SystemColors.MenuHighlight;
            btnLogout.FocusedColor = Color.Transparent;
            btnLogout.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.HoverState.BorderColor = SystemColors.MenuHighlight;
            btnLogout.HoverState.FillColor = SystemColors.MenuHighlight;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.ImageAlign = HorizontalAlignment.Left;
            btnLogout.ImageOffset = new Point(10, 5);
            btnLogout.ImageSize = new Size(30, 30);
            btnLogout.Location = new Point(12, 896);
            btnLogout.Name = "btnLogout";
            btnLogout.PressedColor = Color.Transparent;
            btnLogout.PressedDepth = 0;
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogout.Size = new Size(175, 45);
            btnLogout.TabIndex = 24;
            btnLogout.Text = "Đăng xuất";
            btnLogout.TextAlign = HorizontalAlignment.Left;
            btnLogout.TextOffset = new Point(20, 0);
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUsername
            // 
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Quicksand Bold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(77, 17);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(151, 36);
            lblUsername.TabIndex = 10;
            lblUsername.Text = "CustomName";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(12, 12);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(50, 50);
            guna2CirclePictureBox1.TabIndex = 9;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2Separator2
            // 
            guna2Separator2.FillColor = Color.White;
            guna2Separator2.Location = new Point(22, 878);
            guna2Separator2.Name = "guna2Separator2";
            guna2Separator2.Size = new Size(250, 12);
            guna2Separator2.TabIndex = 2;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // pnlContent
            // 
            pnlContent.CustomizableEdges = customizableEdges10;
            pnlContent.Location = new Point(296, 1);
            pnlContent.Name = "pnlContent";
            pnlContent.ShadowDecoration.CustomizableEdges = customizableEdges11;
            pnlContent.Size = new Size(1289, 952);
            pnlContent.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 953);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "&";
            Load += frmMain_Load;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnSetting;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Button btnAccount;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
    }
}