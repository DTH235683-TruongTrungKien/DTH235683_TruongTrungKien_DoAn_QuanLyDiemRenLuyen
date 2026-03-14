namespace QLDRL.Presentation.Student.Dialogs
{
    partial class ucPreviewPoints
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblSemesterName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTotalScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnViewPoint = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // lblSemesterName
            // 
            lblSemesterName.BackColor = Color.WhiteSmoke;
            lblSemesterName.Font = new Font("Quicksand SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSemesterName.ForeColor = Color.Gray;
            lblSemesterName.Location = new Point(27, 35);
            lblSemesterName.Name = "lblSemesterName";
            lblSemesterName.Size = new Size(294, 32);
            lblSemesterName.TabIndex = 4;
            lblSemesterName.Text = "Học kỳ 2 - Năm học 2025-2026";
            // 
            // lblTotalScore
            // 
            lblTotalScore.BackColor = Color.WhiteSmoke;
            lblTotalScore.Font = new Font("Quicksand SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalScore.ForeColor = Color.Gray;
            lblTotalScore.Location = new Point(626, 35);
            lblTotalScore.Name = "lblTotalScore";
            lblTotalScore.Size = new Size(25, 32);
            lblTotalScore.TabIndex = 5;
            lblTotalScore.Text = "75";
            // 
            // btnViewPoint
            // 
            btnViewPoint.BorderRadius = 5;
            btnViewPoint.CustomizableEdges = customizableEdges1;
            btnViewPoint.DisabledState.BorderColor = Color.DarkGray;
            btnViewPoint.DisabledState.CustomBorderColor = Color.DarkGray;
            btnViewPoint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnViewPoint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnViewPoint.FillColor = SystemColors.MenuHighlight;
            btnViewPoint.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewPoint.ForeColor = Color.White;
            btnViewPoint.Location = new Point(676, 26);
            btnViewPoint.Name = "btnViewPoint";
            btnViewPoint.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnViewPoint.Size = new Size(94, 50);
            btnViewPoint.TabIndex = 31;
            btnViewPoint.Text = "Xem";
            btnViewPoint.Click += btnViewPoint_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.WhiteSmoke;
            guna2Panel1.BorderColor = Color.Silver;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(800, 100);
            guna2Panel1.TabIndex = 32;
            // 
            // ucPreviewPoints
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnViewPoint);
            Controls.Add(lblTotalScore);
            Controls.Add(lblSemesterName);
            Controls.Add(guna2Panel1);
            Name = "ucPreviewPoints";
            Size = new Size(800, 130);
            Load += ucPreviewPoints_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblSemesterName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalScore;
        private Guna.UI2.WinForms.Guna2Button btnViewPoint;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
