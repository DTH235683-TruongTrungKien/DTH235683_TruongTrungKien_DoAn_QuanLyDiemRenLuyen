using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.Models;

namespace QLDRL.Services
{
    public class StudentClassService
    {
        private readonly AppDbContext _context;

        public StudentClassService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentClass>> GetAll()
        {
            return await _context.StudentClasses
                .Include(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .ToListAsync();
        }

        public async Task<StudentClass?> GetById(int id)
        {
            return await _context.StudentClasses
                .Include(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StudentClass?> GetByClassName(string className)
        {
            return await _context.StudentClasses
                .Include(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.Name == className);
        }

        public async Task<List<Faculty>> GetAllFaculties()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<Faculty> CreateFaculty(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
            return faculty;
        }

        public async Task<Major> CreateMajor(Major major)
        {
            var faculty = await _context.Faculties.FindAsync(major.FacultyId);
            major.Faculty = faculty!;

            await _context.Majors.AddAsync(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task<StudentClass> CreateClass(StudentClass studentClass)
        {
            var major = await _context.Majors.FindAsync(studentClass.MajorId);
            studentClass.Major = major!;

            await _context.StudentClasses.AddAsync(studentClass);
            await _context.SaveChangesAsync();
            return studentClass;
        }
    }
}