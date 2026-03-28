using Guna.UI2.WinForms;
using QLDRL.Enums;
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
        public static DialogResult ConfirmDialog(string title, string messages, Form parent)
        {
            var dialog = new Guna2MessageDialog();
            dialog.Style = MessageDialogStyle.Light;
            dialog.Caption = title;
            dialog.Text = messages;
            dialog.Parent = parent;
            dialog.Buttons = MessageDialogButtons.OKCancel;
            dialog.Icon = MessageDialogIcon.Question;
            return dialog.Show();
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
        public static ValidateDateResult ValidateDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ValidateDateResult.Empty;

            input = input.Replace(" ", "");

            if (input.All(char.IsDigit) && input.Length != 8)
                return ValidateDateResult.InvalidDate;

            if (!DateOnly.TryParseExact(
                    input,
                    new[]
                    {
                    "d-M-yyyy",
                    "dd-MM-yyyy",
                    "d/M/yyyy",
                    "dd/MM/yyyy",
                    "ddMMyyyy"
                    },
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out _))
            {
                return ValidateDateResult.InvalidDate;
            }
            return ValidateDateResult.Success;
        }

        public static DateOnly ConvertDate(string input)
        {
            input = input.Replace(" ", "");

            return DateOnly.ParseExact(
                input,
                new[]
                {
                "d-M-yyyy",
                "dd-MM-yyyy",
                "d/M/yyyy",
                "dd/MM/yyyy",
                "ddMMyyyy"
                },
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None
            );
        }
        public static string? UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(sourcePath);
                string folder = Path.Combine();
                string fullPath = Path.Combine(Application.StartupPath, "Assets", "Images", fileName);
                if (!File.Exists(fullPath))
                {
                    File.Copy(sourcePath, fullPath);
                }
                return fullPath;
            }
            return null;
        }
        public static string FillImage(string relativePath)
        {
            string fullPath = Path.Combine(Application.StartupPath, relativePath);

            if (!File.Exists(fullPath))
                fullPath = Path.Combine(Application.StartupPath, "Assets/Images/no-image.png");

            return fullPath;
        }
    }
}
