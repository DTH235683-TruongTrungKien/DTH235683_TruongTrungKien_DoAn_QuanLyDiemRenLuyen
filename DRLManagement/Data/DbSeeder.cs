using QLDRL.Data;
using QLDRL.Models;
using QLDRL.Helpers;

namespace QLDRL.Services
{
    public class DbSeeder
    {
        private readonly AppDbContext _context;
        public DbSeeder(AppDbContext context)
        {
            _context = context;
        }
        public void SeedRolesAndAdmin()
        {
            _context.Database.EnsureCreated();

            string[] roles = { "Admin", "Manager", "Organizer", "Student" };

            foreach (var roleName in roles)
            {
                if (!_context.Roles.Any(r => r.Name == roleName))
                {
                    _context.Roles.Add(new Role { Name = roleName });
                }
            }
            _context.SaveChanges();

            var adminRole = _context.Roles.FirstOrDefault(r => r.Name == "Admin");
            var managerRole = _context.Roles.FirstOrDefault(r => r.Name == "Manager");
            var organizerRole = _context.Roles.FirstOrDefault(r => r.Name == "Organizer");
            var studentRole = _context.Roles.FirstOrDefault(r => r.Name == "Student");

            string adminEmail = "admin@local";
            if (!_context.Users.Any(u => u.Email == adminEmail))
            {
                var adminUser = new User
                {
                    Email = adminEmail,
                    Name = "Administrator",
                    HashedPassword = Utils.HashPassword("admin"),
                };
                adminUser.Roles.Add(adminRole);
                _context.Users.Add(adminUser);
                _context.SaveChanges();
            }

            string managerEmail = "manager@local";
            if (!_context.Users.Any(u => u.Email == managerEmail))
            {
                var managerUser = new User
                {
                    Email = managerEmail,
                    Name = "Manager",
                    HashedPassword = Utils.HashPassword("manager"),
                };
                managerUser.Roles.Add(managerRole);
                managerUser.Roles.Add(organizerRole);
                _context.Users.Add(managerUser);
                _context.SaveChanges();
            }

            string studentEmail = "student@local";
            if (!_context.Users.Any(u => u.Email == studentEmail))
            {
                var studentUser = new User
                {
                    Email = studentEmail,
                    Name = "Student 001",
                    HashedPassword = Utils.HashPassword("123456"),
                };
                studentUser.Roles.Add(studentRole);
                studentUser.Roles.Add(organizerRole);
                _context.Users.Add(studentUser);
                _context.SaveChanges();
            }
        }
    }
}