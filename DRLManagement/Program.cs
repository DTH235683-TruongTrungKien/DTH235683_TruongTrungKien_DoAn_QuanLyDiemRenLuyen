using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.Data;
using QLDRL.Forms.Auth;
using QLDRL.Forms.Main;
using QLDRL.Presentation.Admin;
using QLDRL.Presentation.Admin.DataBackup;
using QLDRL.Presentation.Admin.Dialogs;
using QLDRL.Presentation.Admin.Dialogs.AddUpdateUser;
using QLDRL.Presentation.Main;
using QLDRL.Presentation.Manager.Appeals;
using QLDRL.Presentation.Manager.Confirms;
using QLDRL.Presentation.Manager.EventManagement;
using QLDRL.Presentation.Manager.PointCategory;
using QLDRL.Presentation.Organizer;
using QLDRL.Presentation.Organizer.Dialogs;
using QLDRL.Presentation.Organizer.EventManagement;
using QLDRL.Presentation.Student;
using QLDRL.Presentation.Student.Confirms;
using QLDRL.Presentation.Student.Dialogs;
using QLDRL.Presentation.Student.Events;
using QLDRL.Presentation.Student.Points;
using QLDRL.Services;
using System.Configuration;

namespace DRLManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //DI Registeration
            var services = new ServiceCollection();
            var connectionString = ConfigurationManager.ConnectionStrings["QLDRLConnection"].ConnectionString;

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddSingleton<Session>();

            //Services
            services.AddScoped<AuthServices>();
            services.AddScoped<UserServices>();
            services.AddScoped<RoleServices>();
            services.AddScoped<AdminService>();
            services.AddScoped<ManagerService>();
            services.AddScoped<OrganizerService>();
            services.AddScoped<StudentService>();
            services.AddScoped<StudentClassService>();
            services.AddScoped<RoleServices>();
            services.AddScoped<PointCategoryService>();
            services.AddScoped<SemesterService>();
            services.AddScoped<EventService>();
            services.AddScoped<EvidenceService>();
            services.AddScoped<AppealService>();
            services.AddScoped<ConfirmService>();
            services.AddScoped<BackupService>();

            //Seeder
            services.AddScoped<DbSeeder>();

            //Personal
            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();
            services.AddTransient<ucAccount>();

            //Admin
            services.AddTransient<ucUsers>();
            services.AddTransient<frmAddUpdateUserPopup>();
            services.AddTransient<frmViewProfile>();
            services.AddTransient<ucAdminForm>();
            services.AddTransient<ucManagerForm>();
            services.AddTransient<ucOrganizerForm>();
            services.AddTransient<ucStudentForm>();
            services.AddTransient<frmViewProfile>();
            services.AddTransient<ucBackup>();
            //Manager 
            services.AddTransient<ucPointCategories>();
            services.AddTransient<frmAddUpdatePointCategories>();
            services.AddTransient<frmPointDetail>();
            services.AddTransient<ucPendingEvents>();
            services.AddTransient<ucAppeals>();
            services.AddTransient<ucAppealItem>();
            services.AddTransient<frmAppealDetail>();
            services.AddTransient<ucConfirmManagement>();
            services.AddTransient<ucConfirmItem>();
            services.AddTransient<frmConfirmDetail>();
            services.AddTransient<frmPrintConfirm>();

            //Organizer
            services.AddTransient<ucEventManagement>();
            services.AddTransient<ucEventPreview>();
            services.AddTransient<frmEventDetail>();
            services.AddTransient<frmAddUpdateEvent>();
            services.AddTransient<frmEvidenceList>();
            services.AddTransient<ucEvidenceItem>();

            //Student
            services.AddTransient<ucPreviewPoints>();
            services.AddTransient<ucPoints>();
            services.AddTransient<ucEvents>();
            services.AddTransient<frmEvidence>();
            services.AddTransient<frmRegisteredEvents>();
            services.AddTransient<ucRegisteredEventItem>();
            services.AddTransient<frmAppeal>();
            services.AddTransient<ucConfirms>();
            services.AddTransient<frmConfirmRegister>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var seeder = serviceProvider.GetRequiredService<DbSeeder>();
            seeder.SeedSchoolInfo().GetAwaiter().GetResult();
            seeder.SeedRolesAndUsers().GetAwaiter().GetResult();
            seeder.SeedPointCategories().GetAwaiter().GetResult();
            seeder.SeedSemesterAndPointDetails().GetAwaiter().GetResult();
            seeder.SeedEvents().GetAwaiter().GetResult();

            var loginForm = serviceProvider.GetRequiredService<frmLogin>();
            Application.Run(loginForm);
        }
    }
}