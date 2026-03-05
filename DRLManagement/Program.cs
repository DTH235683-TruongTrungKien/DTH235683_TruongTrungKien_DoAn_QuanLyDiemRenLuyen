using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.Data;
using QLDRL.Forms.Auth;
using QLDRL.Forms.Main;
using QLDRL.Helpers;
using QLDRL.Presentation.Main;
using QLDRL.Services;
using System.Configuration;

namespace DRLManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }
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

            services.AddScoped<AuthServices>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleServices>();
            services.AddScoped<StudentService>();

            services.AddSingleton<Session>();

            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();
            services.AddTransient<ucAccount>();
            //services.AddTransient<AdminForm>();
            //services.AddTransient<ManagerForm>();
            //services.AddTransient<StudentForm>();
            //services.AddTransient<OrganizerForm>();

            ServiceProvider = services.BuildServiceProvider();

            var context = ServiceProvider.GetRequiredService<AppDbContext>();
            var seeder = new DbSeeder(context);
            seeder.SeedRolesAndAdmin();

            var loginForm = ServiceProvider.GetRequiredService<frmLogin>();
            Application.Run(loginForm);
        }
    }
}