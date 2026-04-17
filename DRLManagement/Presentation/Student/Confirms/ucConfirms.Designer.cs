namespace QLDRL.Presentation.Student.Confirms
{
    partial class ucConfirms
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnConfirmRegister = new Guna.UI2.WinForms.Guna2Button();
            dgvConfirms = new Guna.UI2.WinForms.Guna2DataGridView();
            Id = new DataGridViewTextBoxColumn();
            SemesterName = new DataGridViewTextBoxColumn();
            RegisteredDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvConfirms).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Quicksand Bold", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(373, 35);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(580, 51);
            guna2HtmlLabel7.TabIndex = 21;
            guna2HtmlLabel7.Text = "LỊCH SỬ XÁC NHẬN ĐIỂM RÈN LUYỆN";
            // 
            // btnConfirmRegister
            // 
            btnConfirmRegister.BorderRadius = 5;
            btnConfirmRegister.CustomizableEdges = customizableEdges1;
            btnConfirmRegister.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmRegister.FillColor = SystemColors.MenuHighlight;
            btnConfirmRegister.Font = new Font("Quicksand Bold", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmRegister.ForeColor = Color.White;
            btnConfirmRegister.Location = new Point(548, 721);
            btnConfirmRegister.Name = "btnConfirmRegister";
            btnConfirmRegister.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnConfirmRegister.Size = new Size(256, 50);
            btnConfirmRegister.TabIndex = 23;
            btnConfirmRegister.Text = "Đăng ký xác nhận ĐRL";
            btnConfirmRegister.Click += btnConfirmRegister_Click;
            // 
            // dgvConfirms
            // 
            dgvConfirms.AllowUserToAddRows = false;
            dgvConfirms.AllowUserToDeleteRows = false;
            dgvConfirms.AllowUserToResizeColumns = false;
            dgvConfirms.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvConfirms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvConfirms.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new Font("Quicksand SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvConfirms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvConfirms.ColumnHeadersHeight = 40;
            dgvConfirms.Columns.AddRange(new DataGridViewColumn[] { Id, SemesterName, RegisteredDate, Status });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Quicksand Medium", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvConfirms.DefaultCellStyle = dataGridViewCellStyle5;
            dgvConfirms.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvConfirms.GridColor = Color.FromArgb(231, 229, 255);
            dgvConfirms.Location = new Point(83, 117);
            dgvConfirms.MultiSelect = false;
            dgvConfirms.Name = "dgvConfirms";
            dgvConfirms.ReadOnly = true;
            dgvConfirms.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvConfirms.RowHeadersVisible = false;
            dgvConfirms.RowHeadersWidth = 51;
            dgvConfirms.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvConfirms.RowTemplate.Height = 40;
            dgvConfirms.Size = new Size(1165, 551);
            dgvConfirms.TabIndex = 13;
            dgvConfirms.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvConfirms.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvConfirms.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvConfirms.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvConfirms.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvConfirms.ThemeStyle.BackColor = Color.White;
            dgvConfirms.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvConfirms.ThemeStyle.HeaderStyle.BackColor = SystemColors.MenuHighlight;
            dgvConfirms.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvConfirms.ThemeStyle.HeaderStyle.Font = new Font("Quicksand SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0, true);
            dgvConfirms.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvConfirms.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvConfirms.ThemeStyle.HeaderStyle.Height = 40;
            dgvConfirms.ThemeStyle.ReadOnly = true;
            dgvConfirms.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvConfirms.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            dgvConfirms.ThemeStyle.RowsStyle.Font = new Font("Quicksand", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvConfirms.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvConfirms.ThemeStyle.RowsStyle.Height = 40;
            dgvConfirms.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvConfirms.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            // SemesterName
            // 
            SemesterName.DataPropertyName = "SemesterName";
            dataGridViewCellStyle4.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            SemesterName.DefaultCellStyle = dataGridViewCellStyle4;
            SemesterName.FillWeight = 4F;
            SemesterName.HeaderText = "Học kỳ";
            SemesterName.MinimumWidth = 200;
            SemesterName.Name = "SemesterName";
            SemesterName.ReadOnly = true;
            // 
            // RegisteredDate
            // 
            RegisteredDate.DataPropertyName = "RegisteredDate";
            RegisteredDate.FillWeight = 2F;
            RegisteredDate.HeaderText = "Ngày đăng ký xác nhận";
            RegisteredDate.MinimumWidth = 6;
            RegisteredDate.Name = "RegisteredDate";
            RegisteredDate.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.FillWeight = 1F;
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 2;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // ucConfirms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvConfirms);
            Controls.Add(guna2HtmlLabel7);
            Controls.Add(btnConfirmRegister);
            Name = "ucConfirms";
            Size = new Size(1300, 800);
            Load += ucConfirms_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConfirms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Button btnConfirmRegister;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewTextBoxColumn SemesterName;
        private DataGridViewTextBoxColumn Id;
        private Guna.UI2.WinForms.Guna2DataGridView dgvConfirms;
        private DataGridViewTextBoxColumn RegisteredDate;
    }
}
