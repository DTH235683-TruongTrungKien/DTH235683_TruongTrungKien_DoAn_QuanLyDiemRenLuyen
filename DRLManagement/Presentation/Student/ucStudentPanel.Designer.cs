namespace QLDRL.Forms.Student
{
    partial class ucStudentPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStudentPanel));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEvent = new Guna.UI2.WinForms.Guna2Button();
            btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            btnPoints = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // btnEvent
            // 
            btnEvent.BackColor = Color.White;
            btnEvent.BorderColor = Color.White;
            btnEvent.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnEvent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnEvent.CheckedState.FillColor = SystemColors.HotTrack;
            btnEvent.CustomBorderColor = Color.Transparent;
            btnEvent.CustomizableEdges = customizableEdges1;
            btnEvent.DisabledState.BorderColor = Color.DarkGray;
            btnEvent.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEvent.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEvent.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEvent.FillColor = SystemColors.MenuHighlight;
            btnEvent.FocusedColor = Color.Transparent;
            btnEvent.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEvent.ForeColor = Color.White;
            btnEvent.HoverState.FillColor = Color.DodgerBlue;
            btnEvent.Image = (Image)resources.GetObject("btnEvent.Image");
            btnEvent.ImageAlign = HorizontalAlignment.Left;
            btnEvent.ImageOffset = new Point(10, 0);
            btnEvent.ImageSize = new Size(35, 35);
            btnEvent.Location = new Point(-1, 126);
            btnEvent.Name = "btnEvent";
            btnEvent.PressedColor = SystemColors.HotTrack;
            btnEvent.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEvent.Size = new Size(300, 63);
            btnEvent.TabIndex = 28;
            btnEvent.Text = "Sự kiện";
            btnEvent.TextAlign = HorizontalAlignment.Left;
            btnEvent.TextOffset = new Point(15, 0);
            btnEvent.Click += btnEvent_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.BorderColor = Color.White;
            btnConfirm.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnConfirm.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnConfirm.CheckedState.FillColor = SystemColors.HotTrack;
            btnConfirm.CustomBorderColor = Color.Transparent;
            btnConfirm.CustomizableEdges = customizableEdges3;
            btnConfirm.DisabledState.BorderColor = Color.DarkGray;
            btnConfirm.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirm.FillColor = SystemColors.MenuHighlight;
            btnConfirm.FocusedColor = Color.Transparent;
            btnConfirm.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.HoverState.FillColor = Color.DodgerBlue;
            btnConfirm.Image = (Image)resources.GetObject("btnConfirm.Image");
            btnConfirm.ImageAlign = HorizontalAlignment.Left;
            btnConfirm.ImageOffset = new Point(10, 0);
            btnConfirm.ImageSize = new Size(30, 30);
            btnConfirm.Location = new Point(-1, 198);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.PressedColor = SystemColors.HotTrack;
            btnConfirm.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnConfirm.Size = new Size(300, 63);
            btnConfirm.TabIndex = 26;
            btnConfirm.Text = "Xác nhận điểm";
            btnConfirm.TextAlign = HorizontalAlignment.Left;
            btnConfirm.TextOffset = new Point(20, 0);
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(22, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(102, 27);
            lblName.TabIndex = 25;
            lblName.Text = "Student Hub";
            // 
            // guna2Separator3
            // 
            guna2Separator3.FillColor = Color.White;
            guna2Separator3.Location = new Point(138, 20);
            guna2Separator3.Name = "guna2Separator3";
            guna2Separator3.Size = new Size(133, 12);
            guna2Separator3.TabIndex = 24;
            // 
            // btnPoints
            // 
            btnPoints.BackColor = Color.White;
            btnPoints.BorderColor = Color.White;
            btnPoints.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnPoints.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnPoints.CheckedState.FillColor = SystemColors.HotTrack;
            btnPoints.CustomBorderColor = Color.Transparent;
            btnPoints.CustomizableEdges = customizableEdges5;
            btnPoints.DisabledState.BorderColor = Color.DarkGray;
            btnPoints.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPoints.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPoints.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPoints.FillColor = SystemColors.MenuHighlight;
            btnPoints.FocusedColor = Color.Transparent;
            btnPoints.Font = new Font("Quicksand", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPoints.ForeColor = Color.White;
            btnPoints.HoverState.FillColor = Color.DodgerBlue;
            btnPoints.Image = (Image)resources.GetObject("btnPoints.Image");
            btnPoints.ImageAlign = HorizontalAlignment.Left;
            btnPoints.ImageOffset = new Point(10, 0);
            btnPoints.ImageSize = new Size(30, 30);
            btnPoints.Location = new Point(0, 55);
            btnPoints.Name = "btnPoints";
            btnPoints.PressedColor = SystemColors.HotTrack;
            btnPoints.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPoints.Size = new Size(300, 63);
            btnPoints.TabIndex = 23;
            btnPoints.Text = "Điểm rèn luyện";
            btnPoints.TextAlign = HorizontalAlignment.Left;
            btnPoints.TextOffset = new Point(20, 0);
            btnPoints.Click += btnPoints_Click;
            // 
            // ucStudentPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            Controls.Add(btnEvent);
            Controls.Add(btnConfirm);
            Controls.Add(lblName);
            Controls.Add(guna2Separator3);
            Controls.Add(btnPoints);
            Name = "ucStudentPanel";
            Size = new Size(300, 270);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnEvent;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Button btnPoints;
    }
}
