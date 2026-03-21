namespace QLDRL.Presentation.Organizer.Dialogs
{
    partial class ucEventPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEventPreview));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnlEventPreview = new Guna.UI2.WinForms.Guna2Panel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblEventName = new Label();
            lblEndDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStartDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblOrganizationUnit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pbEventThumbnail = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnlEventPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbEventThumbnail).BeginInit();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            // 
            // pnlEventPreview
            // 
            pnlEventPreview.BackColor = Color.White;
            pnlEventPreview.BorderColor = Color.Silver;
            pnlEventPreview.BorderRadius = 10;
            pnlEventPreview.BorderThickness = 2;
            pnlEventPreview.Controls.Add(lblStatus);
            pnlEventPreview.Controls.Add(lblEventName);
            pnlEventPreview.Controls.Add(lblEndDate);
            pnlEventPreview.Controls.Add(lblStartDate);
            pnlEventPreview.Controls.Add(lblOrganizationUnit);
            pnlEventPreview.Controls.Add(guna2HtmlLabel5);
            pnlEventPreview.Controls.Add(guna2HtmlLabel4);
            pnlEventPreview.Controls.Add(guna2HtmlLabel3);
            pnlEventPreview.Controls.Add(pbEventThumbnail);
            pnlEventPreview.CustomBorderColor = Color.Silver;
            pnlEventPreview.CustomizableEdges = customizableEdges3;
            pnlEventPreview.Location = new Point(1, 1);
            pnlEventPreview.Name = "pnlEventPreview";
            pnlEventPreview.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlEventPreview.Size = new Size(1000, 200);
            pnlEventPreview.TabIndex = 14;
            pnlEventPreview.DoubleClick += pnlEventPreview_DoubleClick;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = false;
            lblStatus.BackColor = Color.Gold;
            lblStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(274, 23);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(5);
            lblStatus.Size = new Size(150, 40);
            lblStatus.TabIndex = 23;
            lblStatus.Text = "Đang chờ duyệt";
            lblStatus.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblEventName
            // 
            lblEventName.AutoEllipsis = true;
            lblEventName.AutoSize = true;
            lblEventName.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventName.Location = new Point(431, 23);
            lblEventName.MaximumSize = new Size(570, 65);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new Size(567, 65);
            lblEventName.TabIndex = 22;
            lblEventName.Text = "Tiêu đề sự kiện - Tiêu đề sự kiện - Tiêu đề sự kiện - Tiêu đề sự kiện - Tiêu đề sự kiện - Tiêu đề sự kiện - Tiêu đề sự kiện - ";
            // 
            // lblEndDate
            // 
            lblEndDate.BackColor = Color.Transparent;
            lblEndDate.Font = new Font("Quicksand Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndDate.ForeColor = Color.Black;
            lblEndDate.Location = new Point(714, 141);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(169, 27);
            lblEndDate.TabIndex = 21;
            lblEndDate.Text = "01/01/1999 00:00:00";
            // 
            // lblStartDate
            // 
            lblStartDate.BackColor = Color.Transparent;
            lblStartDate.Font = new Font("Quicksand Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartDate.ForeColor = Color.Black;
            lblStartDate.Location = new Point(348, 142);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(169, 27);
            lblStartDate.TabIndex = 20;
            lblStartDate.Text = "01/01/1999 00:00:00";
            // 
            // lblOrganizationUnit
            // 
            lblOrganizationUnit.BackColor = Color.Transparent;
            lblOrganizationUnit.Font = new Font("Quicksand Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrganizationUnit.ForeColor = Color.Black;
            lblOrganizationUnit.Location = new Point(400, 109);
            lblOrganizationUnit.Name = "lblOrganizationUnit";
            lblOrganizationUnit.Size = new Size(160, 27);
            lblOrganizationUnit.TabIndex = 19;
            lblOrganizationUnit.Text = "Đoàn trường DHAG";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel5.ForeColor = Color.Black;
            guna2HtmlLabel5.Location = new Point(635, 141);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(73, 27);
            guna2HtmlLabel5.TabIndex = 18;
            guna2HtmlLabel5.Text = "Kết thúc:";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = Color.Black;
            guna2HtmlLabel4.Location = new Point(274, 142);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(68, 27);
            guna2HtmlLabel4.TabIndex = 17;
            guna2HtmlLabel4.Text = "Bắt đầu:";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(274, 109);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(120, 27);
            guna2HtmlLabel3.TabIndex = 16;
            guna2HtmlLabel3.Text = "Đơn vị tổ chức:";
            // 
            // pbEventThumbnail
            // 
            pbEventThumbnail.CustomizableEdges = customizableEdges1;
            pbEventThumbnail.Image = (Image)resources.GetObject("pbEventThumbnail.Image");
            pbEventThumbnail.ImageRotate = 0F;
            pbEventThumbnail.Location = new Point(20, 23);
            pbEventThumbnail.Name = "pbEventThumbnail";
            pbEventThumbnail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pbEventThumbnail.Size = new Size(242, 145);
            pbEventThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEventThumbnail.TabIndex = 0;
            pbEventThumbnail.TabStop = false;
            // 
            // guna2Elipse2
            // 
            guna2Elipse2.TargetControl = lblStatus;
            // 
            // ucEventPreview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlEventPreview);
            Name = "ucEventPreview";
            Size = new Size(1002, 250);
            Load += ucEventPreview_Load;
            pnlEventPreview.ResumeLayout(false);
            pnlEventPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbEventThumbnail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnlEventPreview;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOrganizationUnit;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox pbEventThumbnail;
        private Label lblEventName;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
