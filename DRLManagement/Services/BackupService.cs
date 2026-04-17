using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using System.Threading.Tasks;

namespace QLDRL.Services
{
    public class BackupService
    {
        private readonly AppDbContext _context;

        public BackupService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Backup(string path)
        {
            var dbName = _context.Database.GetDbConnection().Database;
            var sqlBackup = $"BACKUP DATABASE [{dbName}] TO DISK = '{path}'";
            await _context.Database.ExecuteSqlRawAsync(sqlBackup);
        }

        public async Task Restore(string path)
        {
            var dbName = _context.Database.GetDbConnection().Database;
            var sqlRestore = $@"
                USE master;
                ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE [{dbName}] FROM DISK = '{path}' WITH REPLACE;
                ALTER DATABASE [{dbName}] SET MULTI_USER;";
            
            await _context.Database.ExecuteSqlRawAsync(sqlRestore);
        }
    }
}
