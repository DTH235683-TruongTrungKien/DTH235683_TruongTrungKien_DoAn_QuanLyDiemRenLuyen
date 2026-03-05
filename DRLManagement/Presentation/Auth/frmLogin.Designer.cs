namespace QLDRL.Forms.Auth
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gbLogin = new Guna.UI2.WinForms.Guna2GroupBox();
            btnShowHidePassword = new Guna.UI2.WinForms.Guna2Button();
            btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lbEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            gbLogin.SuspendLayout();
            SuspendLayout();
            // 
            // gbLogin
            // 
            gbLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbLogin.BackColor = Color.Transparent;
            gbLogin.BorderColor = Color.Transparent;
            gbLogin.BorderRadius = 10;
            gbLogin.Controls.Add(btnShowHidePassword);
            gbLogin.Controls.Add(btnConfirm);
            gbLogin.Controls.Add(guna2HtmlLabel1);
            gbLogin.Controls.Add(txtPassword);
            gbLogin.Controls.Add(txtEmail);
            gbLogin.Controls.Add(lbEmail);
            gbLogin.CustomBorderColor = Color.RoyalBlue;
            gbLogin.CustomizableEdges = customizableEdges29;
            gbLogin.FillColor = Color.Lavender;
            gbLogin.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbLogin.ForeColor = Color.White;
            gbLogin.Location = new Point(416, 258);
            gbLogin.Name = "gbLogin";
            gbLogin.ShadowDecoration.CustomizableEdges = customizableEdges30;
            gbLogin.Size = new Size(375, 250);
            gbLogin.TabIndex = 0;
            gbLogin.Text = "Đăng nhập";
            // 
            // btnShowHidePassword
            // 
            btnShowHidePassword.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnShowHidePassword.CheckedState.FillColor = Color.White;
            btnShowHidePassword.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            btnShowHidePassword.Cursor = Cursors.Hand;
            btnShowHidePassword.CustomizableEdges = customizableEdges21;
            btnShowHidePassword.DisabledState.BorderColor = Color.DarkGray;
            btnShowHidePassword.DisabledState.CustomBorderColor = Color.DarkGray;
            btnShowHidePassword.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnShowHidePassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnShowHidePassword.FillColor = Color.White;
            btnShowHidePassword.Font = new Font("Segoe UI", 9F);
            btnShowHidePassword.ForeColor = Color.White;
            btnShowHidePassword.HoverState.CustomBorderColor = Color.White;
            btnShowHidePassword.HoverState.FillColor = Color.White;
            btnShowHidePassword.Image = (Image)resources.GetObject("btnShowHidePassword.Image");
            btnShowHidePassword.ImageSize = new Size(25, 25);
            btnShowHidePassword.Location = new Point(293, 130);
            btnShowHidePassword.Name = "btnShowHidePassword";
            btnShowHidePassword.PressedColor = Color.Transparent;
            btnShowHidePassword.PressedDepth = 0;
            btnShowHidePassword.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnShowHidePassword.Size = new Size(44, 27);
            btnShowHidePassword.TabIndex = 5;
            btnShowHidePassword.Click += btnShowHidePassword_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.None;
            btnConfirm.BorderRadius = 5;
            btnConfirm.CustomizableEdges = customizableEdges23;
            btnConfirm.DisabledState.BorderColor = Color.DarkGray;
            btnConfirm.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirm.Font = new Font("Quicksand Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(121, 185);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnConfirm.Size = new Size(131, 45);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.Click += btnConfirm_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Quicksand", 10F);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(32, 126);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(80, 27);
            guna2HtmlLabel1.TabIndex = 4;
            guna2HtmlLabel1.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.BorderRadius = 5;
            txtPassword.CustomizableEdges = customizableEdges25;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(121, 127);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges26;
            txtPassword.Size = new Size(217, 32);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 5;
            txtEmail.CustomizableEdges = customizableEdges27;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(121, 71);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges28;
            txtEmail.Size = new Size(217, 32);
            txtEmail.TabIndex = 1;
            // 
            // lbEmail
            // 
            lbEmail.BackColor = Color.Transparent;
            lbEmail.Font = new Font("Quicksand", 10F);
            lbEmail.ForeColor = Color.Black;
            lbEmail.Location = new Point(32, 71);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(50, 27);
            lbEmail.TabIndex = 0;
            lbEmail.Text = "Email: ";
            // 
            // frmLogin
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1182, 753);
            Controls.Add(gbLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Quản lý điểm rèn luyện sinh viên";
            gbLogin.ResumeLayout(false);
            gbLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2GroupBox gbLogin;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbEmail;
        private Guna.UI2.WinForms.Guna2Button btnShowHidePassword;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}