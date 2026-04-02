namespace QLDRL.Presentation.Organizer.EventManagement
{
    partial class frmEvidenceList
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvidenceList));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            flpEvidences = new FlowLayoutPanel();
            guna2Panel1.SuspendLayout();
            guna2Panel3.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.WhiteSmoke;
            guna2Panel1.BorderColor = Color.DarkGray;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(guna2Panel3);
            guna2Panel1.Controls.Add(flpEvidences);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1171, 719);
            guna2Panel1.TabIndex = 20;
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.Transparent;
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.Controls.Add(btnExit);
            guna2Panel3.Controls.Add(btnClose);
            customizableEdges3.BottomLeft = false;
            customizableEdges3.BottomRight = false;
            guna2Panel3.CustomizableEdges = customizableEdges3;
            guna2Panel3.FillColor = SystemColors.MenuHighlight;
            guna2Panel3.ForeColor = SystemColors.MenuHighlight;
            guna2Panel3.Location = new Point(0, 0);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel3.Size = new Size(1171, 57);
            guna2Panel3.TabIndex = 56;
            // 
            // btnExit
            // 
            btnExit.CheckedState.ImageSize = new Size(40, 40);
            btnExit.Cursor = Cursors.Hand;
            btnExit.HoverState.ImageSize = new Size(45, 45);
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageOffset = new Point(0, 0);
            btnExit.ImageRotate = 0F;
            btnExit.ImageSize = new Size(40, 40);
            btnExit.Location = new Point(1120, 6);
            btnExit.Name = "btnExit";
            btnExit.PressedState.ImageSize = new Size(40, 40);
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnExit.Size = new Size(45, 45);
            btnExit.TabIndex = 57;
            btnExit.Click += btnExit_Click;
            // 
            // btnClose
            // 
            btnClose.CheckedState.ImageSize = new Size(40, 40);
            btnClose.Cursor = Cursors.Hand;
            btnClose.HoverState.ImageSize = new Size(45, 45);
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageOffset = new Point(0, 0);
            btnClose.ImageRotate = 0F;
            btnClose.ImageSize = new Size(40, 40);
            btnClose.Location = new Point(1420, 7);
            btnClose.Name = "btnClose";
            btnClose.PressedState.ImageSize = new Size(40, 40);
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClose.Size = new Size(45, 45);
            btnClose.TabIndex = 56;
            // 
            // flpEvidences
            // 
            flpEvidences.AutoScroll = true;
            flpEvidences.Location = new Point(88, 130);
            flpEvidences.Name = "flpEvidences";
            flpEvidences.Size = new Size(1080, 509);
            flpEvidences.TabIndex = 13;
            // 
            // frmEvidenceList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 720);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmEvidenceList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEvidenceList";
            Load += frmEvidenceList_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FlowLayoutPanel flpEvidences;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
    }
}