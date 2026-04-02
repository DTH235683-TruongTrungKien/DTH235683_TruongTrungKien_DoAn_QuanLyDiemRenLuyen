namespace QLDRL.Presentation.Student
{
    partial class ucEvents
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnSearch = new Guna.UI2.WinForms.Guna2Button();
            txtSearchBar = new Guna.UI2.WinForms.Guna2TextBox();
            flpEvents = new FlowLayoutPanel();
            btnRegisteredEvents = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(491, 32);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(326, 51);
            guna2HtmlLabel7.TabIndex = 18;
            guna2HtmlLabel7.Text = "DANH SÁCH SỰ KIỆN";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.WhiteSmoke;
            guna2Panel1.BorderColor = Color.DarkGray;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(btnSearch);
            guna2Panel1.Controls.Add(txtSearchBar);
            guna2Panel1.Controls.Add(flpEvents);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(65, 108);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1171, 720);
            guna2Panel1.TabIndex = 19;
            // 
            // btnSearch
            // 
            btnSearch.BorderRadius = 5;
            btnSearch.CustomizableEdges = customizableEdges1;
            btnSearch.DisabledState.BorderColor = Color.DarkGray;
            btnSearch.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSearch.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSearch.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSearch.FillColor = SystemColors.MenuHighlight;
            btnSearch.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(884, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSearch.Size = new Size(131, 50);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderThickness = 2;
            txtSearchBar.CustomizableEdges = customizableEdges3;
            txtSearchBar.DefaultText = "";
            txtSearchBar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchBar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchBar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBar.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBar.Location = new Point(157, 40);
            txtSearchBar.Margin = new Padding(4, 9, 4, 9);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm...";
            txtSearchBar.SelectedText = "";
            txtSearchBar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearchBar.Size = new Size(720, 50);
            txtSearchBar.TabIndex = 14;
            txtSearchBar.KeyDown += txtSearchBar_KeyDown;
            // 
            // flpEvents
            // 
            flpEvents.AutoScroll = true;
            flpEvents.Location = new Point(88, 130);
            flpEvents.Name = "flpEvents";
            flpEvents.Size = new Size(1080, 587);
            flpEvents.TabIndex = 13;
            // 
            // btnRegisteredEvents
            // 
            btnRegisteredEvents.BorderRadius = 5;
            btnRegisteredEvents.CustomizableEdges = customizableEdges7;
            btnRegisteredEvents.DisabledState.BorderColor = Color.DarkGray;
            btnRegisteredEvents.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegisteredEvents.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegisteredEvents.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegisteredEvents.FillColor = SystemColors.MenuHighlight;
            btnRegisteredEvents.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegisteredEvents.ForeColor = Color.White;
            btnRegisteredEvents.Location = new Point(533, 863);
            btnRegisteredEvents.Name = "btnRegisteredEvents";
            btnRegisteredEvents.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRegisteredEvents.Size = new Size(236, 50);
            btnRegisteredEvents.TabIndex = 20;
            btnRegisteredEvents.Text = "Sự kiện đã đăng ký";
            btnRegisteredEvents.Click += btnRegisteredEvents_Click;
            // 
            // ucEvents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRegisteredEvents);
            Controls.Add(guna2HtmlLabel7);
            Controls.Add(guna2Panel1);
            Name = "ucEvents";
            Size = new Size(1300, 950);
            Load += ucEvents_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FlowLayoutPanel flpEvents;
        private Guna.UI2.WinForms.Guna2Button btnRegisteredEvents;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBar;
    }
}
