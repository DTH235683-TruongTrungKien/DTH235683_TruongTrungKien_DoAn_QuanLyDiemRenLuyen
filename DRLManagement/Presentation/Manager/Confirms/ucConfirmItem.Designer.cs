namespace QLDRL.Presentation.Manager.Confirms
{
    partial class ucConfirmItem
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlEventPreview = new Guna.UI2.WinForms.Guna2Panel();
            lblSemester = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnViewDetail = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStudent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblOrganizationUnit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnlEventPreview.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEventPreview
            // 
            pnlEventPreview.BackColor = Color.White;
            pnlEventPreview.BorderColor = Color.Silver;
            pnlEventPreview.BorderRadius = 10;
            pnlEventPreview.BorderThickness = 2;
            pnlEventPreview.Controls.Add(lblSemester);
            pnlEventPreview.Controls.Add(btnViewDetail);
            pnlEventPreview.Controls.Add(guna2HtmlLabel1);
            pnlEventPreview.Controls.Add(lblStudent);
            pnlEventPreview.Controls.Add(lblStatus);
            pnlEventPreview.Controls.Add(lblOrganizationUnit);
            pnlEventPreview.CustomBorderColor = Color.Silver;
            pnlEventPreview.CustomizableEdges = customizableEdges3;
            pnlEventPreview.Location = new Point(0, 0);
            pnlEventPreview.Name = "pnlEventPreview";
            pnlEventPreview.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlEventPreview.Size = new Size(1000, 121);
            pnlEventPreview.TabIndex = 17;
            // 
            // lblSemester
            // 
            lblSemester.BackColor = Color.Transparent;
            lblSemester.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSemester.ForeColor = Color.Black;
            lblSemester.Location = new Point(297, 60);
            lblSemester.MaximumSize = new Size(450, 50);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(441, 27);
            lblSemester.TabIndex = 27;
            lblSemester.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            // 
            // btnViewDetail
            // 
            btnViewDetail.BorderRadius = 5;
            btnViewDetail.CustomizableEdges = customizableEdges1;
            btnViewDetail.DisabledState.BorderColor = Color.DarkGray;
            btnViewDetail.DisabledState.CustomBorderColor = Color.DarkGray;
            btnViewDetail.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnViewDetail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnViewDetail.FillColor = SystemColors.MenuHighlight;
            btnViewDetail.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewDetail.ForeColor = Color.White;
            btnViewDetail.Location = new Point(806, 37);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnViewDetail.Size = new Size(155, 50);
            btnViewDetail.TabIndex = 26;
            btnViewDetail.Text = "Xem chi tiết";
            btnViewDetail.Click += btnViewDetail_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Quicksand Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(210, 27);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(81, 27);
            guna2HtmlLabel1.TabIndex = 25;
            guna2HtmlLabel1.Text = "Sinh viên:";
            // 
            // lblStudent
            // 
            lblStudent.BackColor = Color.Transparent;
            lblStudent.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudent.ForeColor = Color.Black;
            lblStudent.Location = new Point(297, 27);
            lblStudent.MaximumSize = new Size(550, 25);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(141, 25);
            lblStudent.TabIndex = 24;
            lblStudent.Text = "Tên - MSSV - Lớp";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = false;
            lblStatus.BackColor = Color.Gold;
            lblStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(17, 37);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(5);
            lblStatus.Size = new Size(170, 50);
            lblStatus.TabIndex = 23;
            lblStatus.Text = "Đang chờ duyệt";
            lblStatus.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblOrganizationUnit
            // 
            lblOrganizationUnit.BackColor = Color.Transparent;
            lblOrganizationUnit.Font = new Font("Quicksand Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrganizationUnit.ForeColor = Color.Black;
            lblOrganizationUnit.Location = new Point(210, 60);
            lblOrganizationUnit.Name = "lblOrganizationUnit";
            lblOrganizationUnit.Size = new Size(65, 27);
            lblOrganizationUnit.TabIndex = 19;
            lblOrganizationUnit.Text = "Học kỳ:";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            // 
            // guna2Elipse2
            // 
            guna2Elipse2.TargetControl = lblStatus;
            // 
            // ucConfirmItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlEventPreview);
            Name = "ucConfirmItem";
            Size = new Size(1002, 152);
            Load += ucConfirmItem_Load;
            pnlEventPreview.ResumeLayout(false);
            pnlEventPreview.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlEventPreview;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSemester;
        private Guna.UI2.WinForms.Guna2Button btnViewDetail;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStudent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOrganizationUnit;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}
