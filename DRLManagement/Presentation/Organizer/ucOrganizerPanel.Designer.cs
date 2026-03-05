namespace QLDRL.Forms.Manager
{
    partial class ucOrganizerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOrganizerPanel));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEvidence = new Guna.UI2.WinForms.Guna2Button();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            btnEventManage = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // btnEvidence
            // 
            btnEvidence.BackColor = Color.White;
            btnEvidence.BorderColor = Color.White;
            btnEvidence.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnEvidence.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnEvidence.CheckedState.FillColor = SystemColors.HotTrack;
            btnEvidence.CustomBorderColor = Color.Transparent;
            btnEvidence.CustomizableEdges = customizableEdges1;
            btnEvidence.DisabledState.BorderColor = Color.DarkGray;
            btnEvidence.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEvidence.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEvidence.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEvidence.FillColor = SystemColors.MenuHighlight;
            btnEvidence.FocusedColor = Color.Transparent;
            btnEvidence.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEvidence.ForeColor = Color.White;
            btnEvidence.HoverState.FillColor = Color.DodgerBlue;
            btnEvidence.Image = (Image)resources.GetObject("btnEvidence.Image");
            btnEvidence.ImageAlign = HorizontalAlignment.Left;
            btnEvidence.ImageOffset = new Point(10, 0);
            btnEvidence.ImageSize = new Size(30, 30);
            btnEvidence.Location = new Point(0, 129);
            btnEvidence.Name = "btnEvidence";
            btnEvidence.PressedColor = SystemColors.HotTrack;
            btnEvidence.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEvidence.Size = new Size(300, 63);
            btnEvidence.TabIndex = 27;
            btnEvidence.Text = "Minh chứng";
            btnEvidence.TextAlign = HorizontalAlignment.Left;
            btnEvidence.TextOffset = new Point(20, 0);
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(23, 15);
            lblName.Name = "lblName";
            lblName.Size = new Size(106, 27);
            lblName.TabIndex = 24;
            lblName.Text = "Organization";
            // 
            // guna2Separator3
            // 
            guna2Separator3.FillColor = Color.White;
            guna2Separator3.Location = new Point(139, 23);
            guna2Separator3.Name = "guna2Separator3";
            guna2Separator3.Size = new Size(133, 12);
            guna2Separator3.TabIndex = 23;
            // 
            // btnEventManage
            // 
            btnEventManage.BackColor = Color.White;
            btnEventManage.BorderColor = Color.White;
            btnEventManage.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnEventManage.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnEventManage.CheckedState.FillColor = SystemColors.HotTrack;
            btnEventManage.CustomBorderColor = Color.Transparent;
            btnEventManage.CustomizableEdges = customizableEdges3;
            btnEventManage.DisabledState.BorderColor = Color.DarkGray;
            btnEventManage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEventManage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEventManage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEventManage.FillColor = SystemColors.MenuHighlight;
            btnEventManage.FocusedColor = Color.Transparent;
            btnEventManage.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEventManage.ForeColor = Color.White;
            btnEventManage.HoverState.FillColor = Color.DodgerBlue;
            btnEventManage.Image = (Image)resources.GetObject("btnEventManage.Image");
            btnEventManage.ImageAlign = HorizontalAlignment.Left;
            btnEventManage.ImageOffset = new Point(10, 0);
            btnEventManage.ImageSize = new Size(35, 35);
            btnEventManage.Location = new Point(1, 58);
            btnEventManage.Name = "btnEventManage";
            btnEventManage.PressedColor = SystemColors.HotTrack;
            btnEventManage.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEventManage.Size = new Size(300, 63);
            btnEventManage.TabIndex = 22;
            btnEventManage.Text = "Quản lý sự kiện";
            btnEventManage.TextAlign = HorizontalAlignment.Left;
            btnEventManage.TextOffset = new Point(15, 0);
            // 
            // ucOrganizerPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            Controls.Add(btnEvidence);
            Controls.Add(lblName);
            Controls.Add(guna2Separator3);
            Controls.Add(btnEventManage);
            Name = "ucOrganizerPanel";
            Size = new Size(300, 199);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnEvidence;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Button btnEventManage;
    }
}
