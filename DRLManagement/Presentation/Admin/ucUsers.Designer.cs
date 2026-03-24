namespace QLDRL.Presentation.Admin
{
    partial class ucUsers
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            dgvUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Birthday = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            RoleNames = new DataGridViewTextBoxColumn();
            btnUpdateUser = new Guna.UI2.WinForms.Guna2Button();
            btnDeleteUser = new Guna.UI2.WinForms.Guna2Button();
            txtSearchBar = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnViewProfile = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(458, 28);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(360, 51);
            guna2HtmlLabel7.TabIndex = 1;
            guna2HtmlLabel7.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // btnAddUser
            // 
            btnAddUser.BorderRadius = 5;
            btnAddUser.CustomizableEdges = customizableEdges1;
            btnAddUser.DisabledState.BorderColor = Color.DarkGray;
            btnAddUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddUser.FillColor = SystemColors.MenuHighlight;
            btnAddUser.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(20, 789);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddUser.Size = new Size(259, 50);
            btnAddUser.TabIndex = 8;
            btnAddUser.Text = "Thêm người dùng mới";
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.ColumnHeadersHeight = 50;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { Id, Email, FullName, Birthday, PhoneNumber, Address, RoleNames });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Quicksand SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvUsers.GridColor = Color.FromArgb(231, 229, 255);
            dgvUsers.Location = new Point(3, 79);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUsers.Size = new Size(1142, 678);
            dgvUsers.TabIndex = 0;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvUsers.ThemeStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvUsers.ThemeStyle.HeaderStyle.BackColor = Color.Transparent;
            dgvUsers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ThemeStyle.HeaderStyle.Font = new Font("Quicksand SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvUsers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.ThemeStyle.HeaderStyle.Height = 50;
            dgvUsers.ThemeStyle.ReadOnly = true;
            dgvUsers.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            dgvUsers.ThemeStyle.RowsStyle.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvUsers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvUsers.ThemeStyle.RowsStyle.Height = 29;
            dgvUsers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvUsers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 200;
            // 
            // FullName
            // 
            FullName.DataPropertyName = "FullName";
            FullName.HeaderText = "Họ tên";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            FullName.Width = 250;
            // 
            // Birthday
            // 
            Birthday.DataPropertyName = "Birthday";
            Birthday.HeaderText = "Ngày sinh";
            Birthday.MinimumWidth = 6;
            Birthday.Name = "Birthday";
            Birthday.ReadOnly = true;
            Birthday.Width = 150;
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.HeaderText = "Số điện thoại";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            PhoneNumber.Width = 200;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Địa chỉ";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.ReadOnly = true;
            Address.Width = 250;
            // 
            // RoleNames
            // 
            RoleNames.DataPropertyName = "RoleNames";
            RoleNames.HeaderText = "Vai trò";
            RoleNames.MinimumWidth = 6;
            RoleNames.Name = "RoleNames";
            RoleNames.ReadOnly = true;
            RoleNames.Width = 125;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BorderRadius = 5;
            btnUpdateUser.CustomizableEdges = customizableEdges3;
            btnUpdateUser.DisabledState.BorderColor = Color.DarkGray;
            btnUpdateUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdateUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdateUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdateUser.FillColor = SystemColors.MenuHighlight;
            btnUpdateUser.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateUser.ForeColor = Color.White;
            btnUpdateUser.Location = new Point(339, 789);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnUpdateUser.Size = new Size(232, 50);
            btnUpdateUser.TabIndex = 9;
            btnUpdateUser.Text = "Chỉnh sửa thông tin";
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BorderRadius = 5;
            btnDeleteUser.CustomizableEdges = customizableEdges5;
            btnDeleteUser.DisabledState.BorderColor = Color.DarkGray;
            btnDeleteUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeleteUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDeleteUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeleteUser.FillColor = SystemColors.MenuHighlight;
            btnDeleteUser.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(622, 789);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDeleteUser.Size = new Size(201, 50);
            btnDeleteUser.TabIndex = 10;
            btnDeleteUser.Text = "Xóa người dùng";
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderThickness = 2;
            txtSearchBar.CustomizableEdges = customizableEdges7;
            txtSearchBar.DefaultText = "";
            txtSearchBar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchBar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchBar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBar.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBar.Location = new Point(225, 102);
            txtSearchBar.Margin = new Padding(4, 9, 4, 9);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm...";
            txtSearchBar.SelectedText = "";
            txtSearchBar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearchBar.Size = new Size(795, 50);
            txtSearchBar.TabIndex = 11;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.White;
            guna2Panel1.BorderColor = Color.DarkGray;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(btnViewProfile);
            guna2Panel1.Controls.Add(btnDeleteUser);
            guna2Panel1.Controls.Add(dgvUsers);
            guna2Panel1.Controls.Add(btnAddUser);
            guna2Panel1.Controls.Add(btnUpdateUser);
            guna2Panel1.CustomizableEdges = customizableEdges11;
            guna2Panel1.Location = new Point(70, 85);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel1.Size = new Size(1171, 862);
            guna2Panel1.TabIndex = 12;
            // 
            // btnViewProfile
            // 
            btnViewProfile.BorderRadius = 5;
            btnViewProfile.CustomizableEdges = customizableEdges9;
            btnViewProfile.DisabledState.BorderColor = Color.DarkGray;
            btnViewProfile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnViewProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnViewProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnViewProfile.FillColor = SystemColors.MenuHighlight;
            btnViewProfile.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewProfile.ForeColor = Color.White;
            btnViewProfile.Location = new Point(863, 789);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnViewProfile.Size = new Size(152, 50);
            btnViewProfile.TabIndex = 11;
            btnViewProfile.Text = "Xem hồ sơ";
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // ucUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(txtSearchBar);
            Controls.Add(guna2HtmlLabel7);
            Controls.Add(guna2Panel1);
            Name = "ucUsers";
            Size = new Size(1300, 950);
            Load += ucUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsers;
        private Guna.UI2.WinForms.Guna2Button btnUpdateUser;
        private Guna.UI2.WinForms.Guna2Button btnDeleteUser;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn RoleNames;
        private Guna.UI2.WinForms.Guna2Button btnViewProfile;
    }
}
