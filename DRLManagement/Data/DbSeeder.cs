using QLDRL.Data;
using QLDRL.Models;
using QLDRL.DTOs.AdminDTOs;
using QLDRL.DTOs.ManagerDTOs;
using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.DTOs.UserDTOs;
using QLDRL.DTOs.PointCategoryDTOs;
using Microsoft.EntityFrameworkCore;
using QLDRL.DTOs.PointCategoryDTOs;
using Microsoft.EntityFrameworkCore;
using QLDRL.DTOs.EventDTOs;
using QLDRL.Enums;
namespace QLDRL.Services
{
    public class DbSeeder
    {
        private readonly UserServices _userServices;
        private readonly RoleServices _roleServices;
        private readonly StudentService _studentService;
        private readonly AdminService _adminService;
        private readonly ManagerService _managerService;
        private readonly OrganizerService _organizerService;
        private readonly StudentClassService _studentClassService;
        private readonly PointCategoryService _pointCategoryService;
        private readonly SemesterService _semesterService;
        private readonly EventService _eventService;
        public DbSeeder(
            UserServices userServices,
            RoleServices roleServices,
            StudentService studentService,
            AdminService adminService,
            ManagerService managerService,
            OrganizerService organizerService,
            StudentClassService studentClassService,
            PointCategoryService pointCategoryService,
            SemesterService semesterService,
            EventService eventService
            )
        {
            _userServices = userServices;
            _roleServices = roleServices;
            _studentService = studentService;
            _adminService = adminService;
            _managerService = managerService;
            _organizerService = organizerService;
            _studentClassService = studentClassService;
            _pointCategoryService = pointCategoryService;
            _semesterService = semesterService;
            _eventService = eventService;
        }
        public async Task SeedSchoolInfo()
        {
            var faculties = await _studentClassService.GetAllFaculties();
            if (faculties.Any()) return;

            var cntt = await _studentClassService.CreateFaculty(new Faculty
            {
                Name = "Công nghệ thông tin"
            });

            var nn = await _studentClassService.CreateFaculty(new Faculty
            {
                Name = "Ngoại ngữ"
            });

            var sp = await _studentClassService.CreateFaculty(new Faculty
            {
                Name = "Sư phạm"
            });

            var majorCNTT = await _studentClassService.CreateMajor(new Major
            {
                Name = "Công nghệ thông tin",
                FacultyId = cntt.Id
            });

            var majorPM = await _studentClassService.CreateMajor(new Major
            {
                Name = "Kỹ thuật phần mềm",
                FacultyId = cntt.Id
            });

            var majorENG = await _studentClassService.CreateMajor(new Major
            {
                Name = "Ngôn ngữ Anh",
                FacultyId = nn.Id
            });

            var majorMATH = await _studentClassService.CreateMajor(new Major
            {
                Name = "Sư phạm Toán",
                FacultyId = sp.Id
            });

            await _studentClassService.CreateClass(new StudentClass
            {
                Name = "DH24TH2",
                MajorId = majorCNTT.Id
            });

            await _studentClassService.CreateClass(new StudentClass
            {
                Name = "DH24PM",
                MajorId = majorPM.Id
            });

            await _studentClassService.CreateClass(new StudentClass
            {
                Name = "DH25TH1",
                MajorId = majorCNTT.Id
            });

            await _studentClassService.CreateClass(new StudentClass
            {
                Name = "DH23TH3",
                MajorId = majorCNTT.Id
            });

            await _studentClassService.CreateClass(new StudentClass
            {
                Name = "DH21PM",
                MajorId = majorPM.Id
            });
        }
        public async Task SeedRolesAndUsers()
        {
            string[] roles = { "Admin", "Manager", "Organizer", "Student" };

            foreach (var roleName in roles)
            {
                if (!(await _roleServices.ExistsByName(roleName)))
                {
                    await _roleServices.Create(new Role { Name = roleName });
                }
            }

            var allRoles = await _roleServices.GetAll();

            int adminRoleId = allRoles.First(x => x.Name == "Admin").Id;
            int managerRoleId = allRoles.First(x => x.Name == "Manager").Id;
            int organizerRoleId = allRoles.First(x => x.Name == "Organizer").Id;
            int studentRoleId = allRoles.First(x => x.Name == "Student").Id;

            string adminEmail = "admin@local";
            if (!(await _userServices.ExistsByEmail(adminEmail)))
            {
                var userDTO = new CreateUpdateUserDTO
                {
                    Email = adminEmail,
                    Password = "admin",
                    FullName = "Huỳnh Hùng Khiên",
                    Birthday = "1/1/1999",
                    PhoneNumber = "0123456789",
                    Address = "TP. Hồ Chí Minh",
                    RoleIds = new List<int> { adminRoleId }
                };

                var userId = await _userServices.Create(userDTO);

                await _adminService.Create(new CreateUpdateAdminDTO
                {
                    UserId = userId,
                    IsSuperAdmin = true,
                    Department = "Phòng Công nghệ thông tin"
                }, await _userServices.GetById(userId));
            }

            string managerEmail = "manager@local";
            if (!(await _userServices.ExistsByEmail(managerEmail)))
            {
                var userDTO = new CreateUpdateUserDTO
                {
                    Email = managerEmail,
                    Password = "manager",
                    FullName = "Lâm Nguyễn Nhật Trường",
                    Birthday = "10/5/1995",
                    PhoneNumber = "0988777666",
                    Address = "Hà Nội",
                    RoleIds = new List<int> { managerRoleId, organizerRoleId }
                };

                var userId = await _userServices.Create(userDTO);
                var user = await _userServices.GetById(userId);

                await _managerService.Create(new CreateUpdateManagerDTO
                {
                    UserId = userId,
                    ManagerCode = "QL001",
                    Position = "Trưởng phòng",
                    Department = "Phòng Công tác sinh viên",
                    FacultyName = "Công nghệ thông tin"
                }, user);

                await _organizerService.Create(new CreateUpdateOrganizerDTO
                {
                    UserId = userId,
                    ClubName = "Câu lạc bộ bình đẳng giới",
                    Position = "Chủ nhiệm"
                }, user);
            }

            string organizerEmail = "organizer@local";
            if (!(await _userServices.ExistsByEmail(organizerEmail)))
            {
                var userDTO = new CreateUpdateUserDTO
                {
                    Email = organizerEmail,
                    Password = "organizer",
                    FullName = "Trần Quốc Cường",
                    Birthday = "01/01/2001",
                    PhoneNumber = "0909999999",
                    Address = "Trung Quốc",
                    RoleIds = new List<int> { organizerRoleId }
                };

                var userId = await _userServices.Create(userDTO);

                await _organizerService.Create(new CreateUpdateOrganizerDTO
                {
                    UserId = userId,
                    ClubName = "Câu lạc bộ người Hoa",
                    Position = "Phó chủ nhiệm"
                }, await _userServices.GetById(userId));
            }

            var lop = await _studentClassService.GetByClassName("DH24TH2");

            string studentEmail = "student@local";
            if (!(await _userServices.ExistsByEmail(studentEmail)))
            {
                var userDTO = new CreateUpdateUserDTO
                {
                    Email = studentEmail,
                    Password = "student",
                    FullName = "Trương Trung Kiên",
                    Birthday = "12/3/2004",
                    PhoneNumber = "0900000001",
                    Address = "Cần Thơ",
                    RoleIds = new List<int> { studentRoleId }
                };

                var userId = await _userServices.Create(userDTO);

                await _studentService.Create(new CreateUpdateStudentDTO
                {
                    UserId = userId,
                    StudentCode = "DTH123456",
                    StudentClassId = lop.Id,
                    EnrollmentYear = "2023",
                    GraduationYear = "2027",
                    GPA = 8.5
                }, await _userServices.GetById(userId));
            }

            for (int i = 1; i <= 5; i++)
            {
                string sEmail = $"student{i}@local";
                if (!(await _userServices.ExistsByEmail(sEmail)))
                {
                    var userDTO = new CreateUpdateUserDTO
                    {
                        Email = sEmail,
                        Password = "student",
                        FullName = $"Sinh viên {i}",
                        Birthday = "01/01/2004",
                        PhoneNumber = $"090000100{i}",
                        Address = "TP. Hồ Chí Minh",
                        RoleIds = new List<int> { studentRoleId }
                    };

                    var uid = await _userServices.Create(userDTO);

                    await _studentService.Create(new CreateUpdateStudentDTO
                    {
                        UserId = uid,
                        StudentCode = $"DTH{100000 + i}",
                        StudentClassId = lop.Id,
                        EnrollmentYear = "2023",
                        GraduationYear = "2027",
                        GPA = 8.0
                    }, await _userServices.GetById(uid));
                }
            }
        }
        public async Task SeedPointCategories()
        {
            var all = await _pointCategoryService.GetAll();
            if (all.Any()) return;

            var totalId = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "Total",
                Title = "Tổng điểm",
                MaxScore = 100
            });
            var iId = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I",
                Title = "Đánh giá ý thức học tập",
                MaxScore = 30,
                ParentId = totalId
            });

            var i1Id = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.1",
                Title = "Kết quả học tập",
                MaxScore = 10,
                ParentId = iId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.1.1",
                Title = "ĐTBCHT 5 → <7",
                MaxScore = 4,
                ParentId = i1Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.1.2",
                Title = "ĐTBCHT 7 → <8",
                MaxScore = 6,
                ParentId = i1Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.1.3",
                Title = "ĐTBCHT 8 → <9",
                MaxScore = 8,
                ParentId = i1Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.1.4",
                Title = "ĐTBCHT 9 → 10",
                MaxScore = 10,
                ParentId = i1Id
            });

            var i2Id = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.2",
                Title = "Hoạt động ngoại khóa",
                MaxScore = 10,
                ParentId = iId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.2.1",
                Title = "Tham gia CLB",
                MaxScore = 4,
                ParentId = i2Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "I.2.2",
                Title = "Hội thảo",
                MaxScore = 6,
                ParentId = i2Id
            });

            // ===== II =====
            var iiId = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "II",
                Title = "Chấp hành nội quy",
                MaxScore = 20,
                ParentId = totalId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "II.1",
                Title = "Phản hồi",
                MaxScore = 2,
                ParentId = iiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "II.2",
                Title = "Quy chế",
                MaxScore = 8,
                ParentId = iiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "II.3",
                Title = "Nội trú",
                MaxScore = 5,
                ParentId = iiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "II.4",
                Title = "BHYT",
                MaxScore = 3,
                ParentId = iiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "II.5",
                Title = "Giữ tài sản",
                MaxScore = 2,
                ParentId = iiId
            });

            // ===== III =====
            var iiiId = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III",
                Title = "Hoạt động xã hội",
                MaxScore = 25,
                ParentId = totalId
            });

            var iii1Id = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III.1",
                Title = "Sinh hoạt công dân",
                MaxScore = 10,
                ParentId = iiiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III.1.1",
                Title = "Tham gia đầy đủ",
                MaxScore = 5,
                ParentId = iii1Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III.1.2",
                Title = "Bài thu hoạch",
                MaxScore = 5,
                ParentId = iii1Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III.2",
                Title = "Văn hóa, thể thao",
                MaxScore = 10,
                ParentId = iiiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III.3",
                Title = "Phòng chống tệ nạn",
                MaxScore = 2,
                ParentId = iiiId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "III.4",
                Title = "Sinh viên khỏe",
                MaxScore = 3,
                ParentId = iiiId
            });

            // ===== IV =====
            var ivId = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV",
                Title = "Công dân cộng đồng",
                MaxScore = 25,
                ParentId = totalId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV.1",
                Title = "Chấp hành pháp luật",
                MaxScore = 2,
                ParentId = ivId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV.2",
                Title = "Từ thiện",
                MaxScore = 3,
                ParentId = ivId
            });

            var iv3Id = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV.3",
                Title = "Tình nguyện",
                MaxScore = 20,
                ParentId = ivId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV.3.1",
                Title = "Mùa hè xanh",
                MaxScore = 10,
                ParentId = iv3Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV.3.2",
                Title = "Hiến máu",
                MaxScore = 5,
                ParentId = iv3Id
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "IV.3.3",
                Title = "Tiếp sức mùa thi",
                MaxScore = 5,
                ParentId = iv3Id
            });

            // ===== V =====
            var vId = await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "V",
                Title = "Điểm thưởng",
                MaxScore = 10,
                ParentId = totalId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "V.1",
                Title = "Khen thưởng",
                MaxScore = 10,
                ParentId = vId
            });

            await _pointCategoryService.Create(new CreateUpdatePointCategoryDTO
            {
                Category = "V.2",
                Title = "Hoàn cảnh đặc biệt",
                MaxScore = 10,
                ParentId = vId
            });
        }
        public async Task SeedSemesterAndPointDetails()
        {
            // ===== 1. Seed Semester =====
            if (!await _semesterService.Any())
            {
                await _semesterService.Create(new Semester
                {
                    SemesterCode = "HK12425",
                    Name = "Học kỳ 1 - Năm học 2024-2025"
                });

                await _semesterService.Create(new Semester
                {
                    SemesterCode = "HK22425",
                    Name = "Học kỳ 2 - Năm học 2024-2025"
                });

                await _semesterService.Create(new Semester
                {
                    SemesterCode = "HK12526",
                    Name = "Học kỳ 1 - Năm học 2025-2026"
                });

                await _semesterService.Create(new Semester
                {
                    SemesterCode = "HK22526",
                    Name = "Học kỳ 2 - Năm học 2025-2026"
                });

                await _semesterService.Create(new Semester
                {
                    SemesterCode = "HK12627",
                    Name = "Học kỳ 1 - Năm học 2026-2027"
                });

                await _semesterService.Create(new Semester
                {
                    SemesterCode = "HK22627",
                    Name = "Học kỳ 2 - Năm học 2026-2027"
                });
            }

            // ===== 2. Seed PointDetail =====
            if (await _pointCategoryService.AnyPointDetail()) return;

            var students = await _studentService.GetAll();
            var semesters = await _semesterService.GetAll();
            var categories = await _pointCategoryService.GetAll();

            var list = new List<PointDetail>();


            var categoryII = categories.FirstOrDefault(x => x.Category == "II");
            foreach (var semester in semesters)
            {
                foreach (var student in students)
                {
                    foreach (var category in categories)
                    {
                        bool isTotal = category.Category == "Total";
                        bool isII = category.Category == "II";
                        bool isLeafOfII = category.Category.StartsWith("II.") && !category.Children.Any();
                        list.Add(new PointDetail
                        {
                            StudentUserId = student.UserId,
                            PointCategoryId = category.Id,
                            SemesterId = semester.Id,
                            TotalScore = isTotal ? 20 : (isII || isLeafOfII) ? category.MaxScore : 0
                        });
                    }
                }
            }

            await _pointCategoryService.CreatePointDetails(list);
        }


        public async Task SeedEvents()
        {
            var events = await _eventService.GetAll();
            if (events.Any()) return;
            const string DEFAULT_IMG = "Assets\\Images\\no-image.png";
            var semester = await _semesterService.GetById(1);
            var organizer = await _organizerService.GetById(3);
            var pointCategory = await _pointCategoryService.GetById(21);

            var createdEventIds = new List<int>();

            // Event 1: Completed
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "CÔNG TÁC TUYÊN TRUYỀN PHÒNG CHỐNG MA TÚY",
                Description = "🎓 Tuyên truyền\r\n🚫 Phòng chống\r\n💪 Nói KHÔNG",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Completed,
                RegistrationExpired = DateTime.Now.AddDays(-40),
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now.AddDays(-28),
                OrganizationUnit = "Đoàn trường",
                Location = "Hội trường 600",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 3,
                RemovePoint = 1,
                TargetedAmount = 120
            }));

            // Event 2: Completed
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "WORKSHOP KỸ NĂNG MỀM",
                Description = "📘 Giao tiếp\r\n🗣️ Thuyết trình",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Completed,
                RegistrationExpired = DateTime.Now.AddDays(-25),
                StartDate = DateTime.Now.AddDays(-20),
                EndDate = DateTime.Now.AddDays(-19),
                OrganizationUnit = "CLB Kỹ năng",
                Location = "Phòng A101",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 4,
                RemovePoint = 1,
                TargetedAmount = 80
            }));

            // Event 3: Completed
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "GIẢI BÓNG ĐÁ SINH VIÊN",
                Description = "⚽ Thi đấu\r\n🔥 Giao lưu",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Completed,
                RegistrationExpired = DateTime.Now.AddDays(-15),
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(-5),
                OrganizationUnit = "Đoàn khoa",
                Location = "Sân trường",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 5,
                RemovePoint = 2,
                TargetedAmount = 150
            }));

            // Event 4: Ongoing
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "TALKSHOW KHỞI NGHIỆP",
                Description = "🚀 Startup\r\n💡 Kinh nghiệm",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Ongoing,
                RegistrationExpired = DateTime.Now.AddDays(-10),
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(3),
                OrganizationUnit = "CLB Doanh nhân",
                Location = "Hội trường lớn",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 3,
                RemovePoint = 1,
                TargetedAmount = 100
            }));

            // Event 5: Ongoing
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "CUỘC THI LẬP TRÌNH",
                Description = "💻 Code\r\n🧠 Thuật toán",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Ongoing,
                RegistrationExpired = DateTime.Now.AddDays(-5),
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(5),
                OrganizationUnit = "CLB IT",
                Location = "Phòng máy",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 8,
                RemovePoint = 3,
                TargetedAmount = 60
            }));

            // Event 6: Upcoming
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "NGÀY HỘI VIỆC LÀM",
                Description = "🏢 Doanh nghiệp\r\n📄 CV",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Upcoming,
                RegistrationExpired = DateTime.Now.AddDays(2),
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(12),
                OrganizationUnit = "Phòng CTSV",
                Location = "Sân trường",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 4,
                RemovePoint = 1,
                TargetedAmount = 200
            }));

            // Event 7: Upcoming
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "WORKSHOP AI CƠ BẢN",
                Description = "🤖 AI\r\n📊 ML",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Upcoming,
                RegistrationExpired = DateTime.Now.AddDays(10),
                StartDate = DateTime.Now.AddDays(20),
                EndDate = DateTime.Now.AddDays(22),
                OrganizationUnit = "CLB AI",
                Location = "Phòng B202",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 5,
                RemovePoint = 2,
                TargetedAmount = 90
            }));

            // Event 8: Rejected
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "HACKATHON 24H",
                Description = "💻 Code liên tục\r\n🔥 Teamwork",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Rejected,
                RegistrationExpired = DateTime.Now.AddDays(-5),
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(32),
                OrganizationUnit = "CLB IT",
                Location = "Lab 1",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 10,
                RemovePoint = 5,
                TargetedAmount = 70
            }));

            // Event 9: Pending
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "GIAO LƯU VĂN NGHỆ",
                Description = "🎤 Ca hát\r\n🎶 Biểu diễn",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Pending,
                RegistrationExpired = DateTime.Now.AddDays(20),
                StartDate = DateTime.Now.AddDays(40),
                EndDate = DateTime.Now.AddDays(42),
                OrganizationUnit = "CLB Văn nghệ",
                Location = "Hội trường",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 3,
                RemovePoint = 1,
                TargetedAmount = 120
            }));

            // Event 10: Pending
            createdEventIds.Add(await _eventService.Create(new CreateUpdateEventDTO
            {
                Name = "CHIẾN DỊCH TÌNH NGUYỆN MÙA HÈ",
                Description = "🌱 Cộng đồng\r\n❤️ Giúp đỡ",
                ImagePath = DEFAULT_IMG,
                Status = EventStatus.Pending,
                RegistrationExpired = DateTime.Now.AddDays(30),
                StartDate = DateTime.Now.AddDays(50),
                EndDate = DateTime.Now.AddDays(55),
                OrganizationUnit = "Đoàn trường",
                Location = "Ngoại tỉnh",
                SemesterId = semester.Id,
                OrganizerUserId = organizer.UserId,
                PointCategoryId = pointCategory.Id,
                AddPoint = 7,
                RemovePoint = 2,
                TargetedAmount = 250
            }));

            var students = await _studentService.GetAll();
            foreach (var s in students)
            {
                foreach (var eid in createdEventIds)
                {
                    await _eventService.RegisterEvent(eid, s.UserId);
                    var er = await _eventService.GetRegisteredEventById(s.UserId, eid);
                    if (er != null)
                    {
                        var ev = await _eventService.GetById(eid);
                        if (ev != null)
                        {
                            if (ev.Status == EventStatus.Completed)
                                await _eventService.SetRegisterStatus(er, AttendStatus.Attended);
                            else
                                await _eventService.SetRegisterStatus(er, AttendStatus.Processing);
                        }
                    }
                }
            }
        }
    }
}