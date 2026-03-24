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
        public void SeedSchoolInfo()
        {
            _context.Database.EnsureCreated();

            if (!_context.Faculties.Any())
            {
                var itFaculty = new Faculty { Name = "Công nghệ thông tin" };
                var langFaculty = new Faculty { Name = "Ngoại ngữ" };
                var eduFaculty = new Faculty { Name = "Sư phạm" };

                _context.Faculties.AddRange(itFaculty, langFaculty, eduFaculty);
                _context.SaveChanges();

                var cntt = new Major { Name = "Công nghệ thông tin", Faculty = itFaculty };
                var pm = new Major { Name = "Kỹ thuật phần mềm", Faculty = itFaculty };
                var eng = new Major { Name = "Ngôn ngữ Anh", Faculty = langFaculty };
                var math = new Major { Name = "Sư phạm Toán", Faculty = eduFaculty };

                _context.Majors.AddRange(cntt, pm, eng, math);
                _context.SaveChanges();

                _context.StudentClasses.AddRange(
                    new StudentClass { Name = "DH24TH2", Major = cntt },
                    new StudentClass { Name = "DH24PM", Major = pm },
                    new StudentClass { Name = "DH25TH1", Major = cntt },
                    new StudentClass { Name = "DH23TH3", Major = cntt },
                    new StudentClass { Name = "DH21PM", Major = pm }
                );

                _context.SaveChanges();
            }
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

            // ================= ADMIN =================
            string adminEmail = "admin@local";
            if (!_context.Users.Any(u => u.Email == adminEmail))
            {
                var adminUser = new User
                {
                    Email = adminEmail,
                    HashedPassword = Utils.HashPassword("admin"),
                    FullName = "Administrator",
                    Birthday = new DateOnly(1999, 1, 1),
                    PhoneNumber = "0123456789",
                    Address = "Grove Street, Ganton, Los Santos",
                    Admin = new Admin
                    {
                        IsSuperAdmin = true
                    }
                };

                adminUser.Roles.Add(adminRole);

                _context.Users.Add(adminUser);
                _context.SaveChanges();
            }

            // ================= MANAGER =================
            string managerEmail = "manager@local";
            if (!_context.Users.Any(u => u.Email == managerEmail))
            {
                var managerUser = new User
                {
                    Email = managerEmail,
                    FullName = "Event Manager",
                    HashedPassword = Utils.HashPassword("manager"),
                    Birthday = new DateOnly(1995, 5, 10),
                    PhoneNumber = "0988777666",
                    Address = "Vice City",
                };

                managerUser.Roles.Add(managerRole);
                managerUser.Roles.Add(organizerRole);

                _context.Users.Add(managerUser);
                _context.SaveChanges();
            }
            // ================= STUDENTS =================
            var classTH2 = _context.StudentClasses.FirstOrDefault(c => c.Name == "DH24TH2");
            var classPM = _context.StudentClasses.FirstOrDefault(c => c.Name == "DH24PM");

            string student1Email = "student1@local";
            if (!_context.Users.Any(u => u.Email == student1Email))
            {
                var student1 = new User
                {
                    Email = student1Email,
                    FullName = "Sinh Viên A",
                    HashedPassword = Utils.HashPassword("student"),
                    Birthday = new DateOnly(2004, 3, 12),
                    PhoneNumber = "0900000001",
                    Address = "An Giang",

                    Student = new Student
                    {
                        StudentCode = "DTH235683",
                        StudentClass = classTH2,
                        EnrollmentYear = "2023",
                        GraduationYear = "2027",
                        GPA = 9.09
                    }
                };

                student1.Roles.Add(studentRole);

                _context.Users.Add(student1);
                _context.SaveChanges();
            }
        }
    }
}