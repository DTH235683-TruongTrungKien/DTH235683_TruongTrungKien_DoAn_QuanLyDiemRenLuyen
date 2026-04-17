namespace QLDRL.Presentation.Admin.DataBackup
{
    partial class ucBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBackup));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnBackup = new Guna.UI2.WinForms.Guna2Button();
            btnRestore = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(517, 29);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(278, 51);
            guna2HtmlLabel7.TabIndex = 13;
            guna2HtmlLabel7.Text = "SAO LƯU DỮ LIỆU";
            // 
            // btnBackup
            // 
            btnBackup.BorderColor = Color.DarkGray;
            btnBackup.BorderRadius = 10;
            btnBackup.BorderThickness = 2;
            btnBackup.CustomizableEdges = customizableEdges1;
            btnBackup.DisabledState.BorderColor = Color.DarkGray;
            btnBackup.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBackup.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBackup.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBackup.FillColor = Color.White;
            btnBackup.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.ForeColor = Color.Gray;
            btnBackup.Image = (Image)resources.GetObject("btnBackup.Image");
            btnBackup.ImageOffset = new Point(0, -50);
            btnBackup.ImageSize = new Size(200, 200);
            btnBackup.Location = new Point(207, 159);
            btnBackup.Name = "btnBackup";
            btnBackup.PressedColor = Color.Gray;
            btnBackup.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBackup.Size = new Size(400, 600);
            btnBackup.TabIndex = 21;
            btnBackup.Text = "SAO LƯU";
            btnBackup.TextAlign = HorizontalAlignment.Left;
            btnBackup.TextOffset = new Point(110, 50);
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.BorderColor = Color.DarkGray;
            btnRestore.BorderRadius = 10;
            btnRestore.BorderThickness = 2;
            btnRestore.CustomizableEdges = customizableEdges3;
            btnRestore.DisabledState.BorderColor = Color.DarkGray;
            btnRestore.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRestore.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRestore.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRestore.FillColor = Color.White;
            btnRestore.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestore.ForeColor = Color.Gray;
            btnRestore.Image = (Image)resources.GetObject("btnRestore.Image");
            btnRestore.ImageOffset = new Point(0, -50);
            btnRestore.ImageSize = new Size(200, 200);
            btnRestore.Location = new Point(695, 159);
            btnRestore.Name = "btnRestore";
            btnRestore.PressedColor = Color.Gray;
            btnRestore.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRestore.Size = new Size(400, 600);
            btnRestore.TabIndex = 22;
            btnRestore.Text = "KHÔI PHỤC";
            btnRestore.TextAlign = HorizontalAlignment.Left;
            btnRestore.TextOffset = new Point(90, 50);
            btnRestore.Click += btnRestore_Click;
            // 
            // ucBackup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRestore);
            Controls.Add(btnBackup);
            Controls.Add(guna2HtmlLabel7);
            Name = "ucBackup";
            Size = new Size(1300, 950);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Button btnBackup;
        private Guna.UI2.WinForms.Guna2Button btnRestore;
    }
}
