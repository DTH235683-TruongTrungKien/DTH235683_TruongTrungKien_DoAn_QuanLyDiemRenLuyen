using Guna.UI2.WinForms;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public static void ShowMessages(string title, string messages, Form parent)
        {
            var dialog = new Guna2MessageDialog();
            dialog.Style = MessageDialogStyle.Light;
            dialog.Caption = title;
            dialog.Text = messages;
            dialog.Parent = parent;
            dialog.Show();
        }
        public static string ListToString<T>(List<T> list)
        {
            return string.Join(", ", list);
        }
        public static void PrintDebug(object? obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            string json = JsonSerializer.Serialize(obj, options);

            Debug.WriteLine(json);
        }
    }
}
