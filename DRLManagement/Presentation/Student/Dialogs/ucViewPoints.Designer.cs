namespace QLDRL.Presentation.Student.Dialogs
{
    partial class ucViewPoints
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnRemoveRole = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Quicksand SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel5.ForeColor = Color.Gray;
            guna2HtmlLabel5.Location = new Point(27, 35);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(294, 32);
            guna2HtmlLabel5.TabIndex = 4;
            guna2HtmlLabel5.Text = "Học kỳ 2 - Năm học 2025-2026";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Quicksand SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Gray;
            guna2HtmlLabel1.Location = new Point(626, 35);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(25, 32);
            guna2HtmlLabel1.TabIndex = 5;
            guna2HtmlLabel1.Text = "75";
            // 
            // btnRemoveRole
            // 
            btnRemoveRole.BorderRadius = 5;
            btnRemoveRole.CustomizableEdges = customizableEdges1;
            btnRemoveRole.DisabledState.BorderColor = Color.DarkGray;
            btnRemoveRole.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRemoveRole.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRemoveRole.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRemoveRole.FillColor = SystemColors.MenuHighlight;
            btnRemoveRole.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveRole.ForeColor = Color.White;
            btnRemoveRole.Location = new Point(676, 26);
            btnRemoveRole.Name = "btnRemoveRole";
            btnRemoveRole.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRemoveRole.Size = new Size(94, 50);
            btnRemoveRole.TabIndex = 31;
            btnRemoveRole.Text = "Xem";
            // 
            // ucViewPoints
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRemoveRole);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2HtmlLabel5);
            Name = "ucViewPoints";
            Size = new Size(800, 100);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnRemoveRole;
    }
}
