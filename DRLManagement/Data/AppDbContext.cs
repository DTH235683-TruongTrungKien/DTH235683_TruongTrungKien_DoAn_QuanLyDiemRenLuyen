using Microsoft.EntityFrameworkCore;
using QLDRL.Models;
using System.Configuration;

namespace QLDRL.Data
{ 
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users  { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventsRegistrations { get; set; }
        public DbSet<PointCategory> PointCategories { get; set; }
        public DbSet<PointDetail> PointDetails { get; set; }
        public DbSet<Evidence> Evidences { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Confirm> Confirms { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLDRLConnection"].ConnectionString);
        }
    }
}
