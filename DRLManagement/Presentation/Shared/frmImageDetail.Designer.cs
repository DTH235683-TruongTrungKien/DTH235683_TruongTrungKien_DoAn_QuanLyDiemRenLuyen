namespace QLDRL.Presentation.Shared
{
    partial class frmImageDetail
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageDetail));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            pbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.Transparent;
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.Controls.Add(btnClose);
            customizableEdges2.BottomLeft = false;
            customizableEdges2.BottomRight = false;
            guna2Panel3.CustomizableEdges = customizableEdges2;
            guna2Panel3.FillColor = SystemColors.MenuHighlight;
            guna2Panel3.ForeColor = SystemColors.MenuHighlight;
            guna2Panel3.Location = new Point(0, 0);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2Panel3.Size = new Size(1000, 57);
            guna2Panel3.TabIndex = 56;
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
            btnClose.Location = new Point(943, 6);
            btnClose.Name = "btnClose";
            btnClose.PressedState.ImageSize = new Size(40, 40);
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnClose.Size = new Size(45, 45);
            btnClose.TabIndex = 57;
            btnClose.Click += btnClose_Click;
            // 
            // pbImage
            // 
            pbImage.CustomizableEdges = customizableEdges4;
            pbImage.ImageRotate = 0F;
            pbImage.Location = new Point(0, 57);
            pbImage.Name = "pbImage";
            pbImage.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pbImage.Size = new Size(1000, 543);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.TabIndex = 57;
            pbImage.TabStop = false;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // frmImageDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(pbImage);
            Controls.Add(guna2Panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmImageDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmImageDetail";
            Load += frmImageDetail_Load;
            guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}