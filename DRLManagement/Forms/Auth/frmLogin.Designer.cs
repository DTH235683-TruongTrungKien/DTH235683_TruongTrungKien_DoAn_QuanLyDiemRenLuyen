namespace QLDRL.Forms.Auth
{
    partial class frmLogin
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
            Login = new GroupBox();
            SuspendLayout();
            // 
            // Login
            // 
            Login.BackColor = SystemColors.WindowFrame;
            Login.Location = new Point(208, 127);
            Login.Name = "Login";
            Login.Size = new Size(403, 209);
            Login.TabIndex = 0;
            Login.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Login);
            Name = "frmLogin";
            Text = "frmLogin";
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Login;
    }
}