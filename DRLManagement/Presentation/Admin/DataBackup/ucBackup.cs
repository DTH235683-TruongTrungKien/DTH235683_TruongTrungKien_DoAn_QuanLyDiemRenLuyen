using QLDRL.Helpers;
using QLDRL.Services;
using System;
using System.Windows.Forms;

namespace QLDRL.Presentation.Admin.DataBackup
{
    public partial class ucBackup : UserControl
    {
        private readonly Session _session;
        private readonly BackupService _backupService;

        public ucBackup(Session session, BackupService backupService)
        {
            InitializeComponent();
            _session = session;
            _backupService = backupService;
        }

        private async void btnBackup_Click(object? sender, EventArgs e)
        {
            if (!_session.CheckRole("Admin"))
            {
                Utils.ShowMessages("Lỗi", "Bạn không có quyền sử dụng chức năng này", this.FindForm());
                return;
            }

            var result = Utils.ConfirmDialog("Xác nhận", "Bạn có chắc chắn muốn sao lưu dữ liệu?", this.FindForm());
            if (result != DialogResult.Yes) return;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
                saveFileDialog.Title = "Chọn nơi lưu file sao lưu";
                saveFileDialog.FileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnBackup.Enabled = false;
                        await _backupService.Backup(saveFileDialog.FileName);
                        Utils.ShowMessages("Thành công", "Sao lưu dữ liệu thành công", this.FindForm());
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowMessages("Lỗi", "Lỗi sao lưu: " + ex.Message, this.FindForm());
                    }
                    finally
                    {
                        btnBackup.Enabled = true;
                    }
                }
            }
        }

        private async void btnRestore_Click(object? sender, EventArgs e)
        {
            if (!_session.CheckRole("Admin"))
            {
                Utils.ShowMessages("Lỗi", "Bạn không có quyền sử dụng chức năng này", this.FindForm());
                return;
            }

            var result = Utils.ConfirmDialog("Xác nhận", "Bạn có chắc chắn muốn phục hồi dữ liệu?", this.FindForm());
            if (result != DialogResult.Yes) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
                openFileDialog.Title = "Chọn file sao lưu";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnRestore.Enabled = false;
                        await _backupService.Restore(openFileDialog.FileName);
                        Utils.ShowMessages("Thành công", "Phục hồi dữ liệu thành công", this.FindForm());
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowMessages("Lỗi", "Lỗi phục hồi: " + ex.Message, this.FindForm());
                    }
                    finally
                    {
                        btnRestore.Enabled = true;
                    }
                }
            }
        }
    }
}
