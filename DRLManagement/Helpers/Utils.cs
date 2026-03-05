using Guna.UI2.WinForms;

namespace QLDRL.Helpers
{
    public static class Utils
    {
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static void showMessages(string title, string messages, Form parent)
        {
            var dialog = new Guna2MessageDialog();
            dialog.Caption = title;
            dialog.Text = messages;
            dialog.Parent = parent;
            dialog.Show();
        }
    }
}
