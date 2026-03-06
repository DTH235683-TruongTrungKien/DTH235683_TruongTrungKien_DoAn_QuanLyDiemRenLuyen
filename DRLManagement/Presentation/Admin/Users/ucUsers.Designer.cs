using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnSearch = new Guna.UI2.WinForms.Guna2Button();
            txtSearchBar = new Guna.UI2.WinForms.Guna2TextBox();
            dgvUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Birthday = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            RoleNames = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnDeleteUser = new Guna.UI2.WinForms.Guna2Button();
            btnViewProfile = new Guna.UI2.WinForms.Guna2Button();
            btnUpdateUser = new Guna.UI2.WinForms.Guna2Button();
            btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(458, 17);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(360, 51);
            guna2HtmlLabel7.TabIndex = 1;
            guna2HtmlLabel7.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.White;
            guna2Panel1.BorderColor = Color.DarkGray;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(btnSearch);
            guna2Panel1.Controls.Add(txtSearchBar);
            guna2Panel1.Controls.Add(dgvUsers);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(70, 85);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1171, 700);
            guna2Panel1.TabIndex = 12;
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
            btnSearch.Location = new Point(884, 39);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSearch.Size = new Size(131, 50);
            btnSearch.TabIndex = 13;
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
            txtSearchBar.Location = new Point(157, 39);
            txtSearchBar.Margin = new Padding(4, 9, 4, 9);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.PlaceholderText = "Tìm kiếm...";
            txtSearchBar.SelectedText = "";
            txtSearchBar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearchBar.Size = new Size(720, 50);
            txtSearchBar.TabIndex = 11;
            txtSearchBar.KeyDown += txtSearchBar_KeyDown;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new Font("Quicksand SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.ColumnHeadersHeight = 40;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { Id, Email, FullName, Birthday, PhoneNumber, Address, RoleNames, Status });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Quicksand Medium", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle5;
            dgvUsers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvUsers.GridColor = Color.FromArgb(231, 229, 255);
            dgvUsers.Location = new Point(3, 122);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.Size = new Size(1165, 575);
            dgvUsers.TabIndex = 12;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvUsers.ThemeStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvUsers.ThemeStyle.HeaderStyle.BackColor = SystemColors.MenuHighlight;
            dgvUsers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ThemeStyle.HeaderStyle.Font = new Font("Quicksand SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0, true);
            dgvUsers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.ThemeStyle.HeaderStyle.Height = 40;
            dgvUsers.ThemeStyle.ReadOnly = true;
            dgvUsers.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            dgvUsers.ThemeStyle.RowsStyle.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvUsers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvUsers.ThemeStyle.RowsStyle.Height = 40;
            dgvUsers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvUsers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Id.DefaultCellStyle = dataGridViewCellStyle3;
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Email.DataPropertyName = "Email";
            dataGridViewCellStyle4.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            Email.DefaultCellStyle = dataGridViewCellStyle4;
            Email.FillWeight = 3F;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 200;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 206;
            // 
            // FullName
            // 
            FullName.DataPropertyName = "FullName";
            FullName.FillWeight = 3F;
            FullName.HeaderText = "Họ tên";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            // 
            // Birthday
            // 
            Birthday.DataPropertyName = "Birthday";
            Birthday.FillWeight = 2F;
            Birthday.HeaderText = "Ngày sinh";
            Birthday.MinimumWidth = 6;
            Birthday.Name = "Birthday";
            Birthday.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.FillWeight = 2F;
            PhoneNumber.HeaderText = "Số điện thoại";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.FillWeight = 4F;
            Address.HeaderText = "Địa chỉ";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // RoleNames
            // 
            RoleNames.DataPropertyName = "RoleNames";
            RoleNames.FillWeight = 3F;
            RoleNames.HeaderText = "Vai trò";
            RoleNames.MinimumWidth = 6;
            RoleNames.Name = "RoleNames";
            RoleNames.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Visible = false;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BorderRadius = 5;
            btnDeleteUser.CustomizableEdges = customizableEdges7;
            btnDeleteUser.DisabledState.BorderColor = Color.DarkGray;
            btnDeleteUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeleteUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDeleteUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeleteUser.FillColor = SystemColors.MenuHighlight;
            btnDeleteUser.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(734, 832);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDeleteUser.Size = new Size(201, 50);
            btnDeleteUser.TabIndex = 10;
            btnDeleteUser.Text = "Xóa người dùng";
            btnDeleteUser.Click += btnDeleteUser_Click;
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
            btnViewProfile.Location = new Point(977, 832);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnViewProfile.Size = new Size(152, 50);
            btnViewProfile.TabIndex = 11;
            btnViewProfile.Text = "Xem hồ sơ";
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BorderRadius = 5;
            btnUpdateUser.CustomizableEdges = customizableEdges11;
            btnUpdateUser.DisabledState.BorderColor = Color.DarkGray;
            btnUpdateUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdateUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdateUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdateUser.FillColor = SystemColors.MenuHighlight;
            btnUpdateUser.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateUser.ForeColor = Color.White;
            btnUpdateUser.Location = new Point(459, 832);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnUpdateUser.Size = new Size(232, 50);
            btnUpdateUser.TabIndex = 9;
            btnUpdateUser.Text = "Chỉnh sửa thông tin";
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BorderRadius = 5;
            btnAddUser.CustomizableEdges = customizableEdges13;
            btnAddUser.DisabledState.BorderColor = Color.DarkGray;
            btnAddUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddUser.FillColor = SystemColors.MenuHighlight;
            btnAddUser.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(157, 832);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnAddUser.Size = new Size(259, 50);
            btnAddUser.TabIndex = 8;
            btnAddUser.Text = "Thêm người dùng mới";
            btnAddUser.Click += btnAddUser_Click;
            // 
            // ucUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(guna2HtmlLabel7);
            Controls.Add(guna2Panel1);
            Controls.Add(btnViewProfile);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnAddUser);
            Name = "ucUsers";
            Size = new Size(1300, 950);
            Load += ucUsers_Load;
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsers;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn RoleNames;
        private DataGridViewTextBoxColumn Status;
        private Guna.UI2.WinForms.Guna2Button btnDeleteUser;
        private Guna.UI2.WinForms.Guna2Button btnViewProfile;
        private Guna.UI2.WinForms.Guna2Button btnUpdateUser;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
    }
}
