using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
using System.Text.RegularExpressions;

namespace QLDRL.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        private readonly StudentClassService _studentClassService;
        public StudentService(AppDbContext context, StudentClassService studentClassService)
        {
            _context = context;
            _studentClassService = studentClassService;
        }
        public async Task<List<Student>> GetAll()
        {
            return await _context.Students
                .Include(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .ToListAsync();
        }
        public async Task<Student?> GetById(int id)
        {
            return await _context.Students
                .Include(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.UserId == id);
        }
        public async Task<Student?> GetByStudentCode(string code)
        {
            return await _context.Students
                .Include(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.StudentCode == code);
        }
        public async Task<ValidateStudentResult> Create(CreateStudentDTO createStudentDTO, User user)
        {
            var studentClass = await _studentClassService.GetByClassName(createStudentDTO.StudentClassName);

            if (string.IsNullOrWhiteSpace(createStudentDTO.StudentCode) ||
                !Regex.IsMatch(createStudentDTO.StudentCode, @"^[A-Z]{3}\d{6}$"))
            {
                return ValidateStudentResult.InvalidStudentCode;
            }

            if (studentClass == null)
                return ValidateStudentResult.StudentClassNotFound;

            if (!int.TryParse(createStudentDTO.EnrollmentYear, out int enrollYear))
                return ValidateStudentResult.InvalidEnrollmentYear;

            if (!int.TryParse(createStudentDTO.GraduationYear, out int gradYear))
                return ValidateStudentResult.InvalidGraduationYear;

            var currentYear = DateTime.Now.Year;

            if (enrollYear < currentYear)
                return ValidateStudentResult.InvalidEnrollmentYear;

            if (gradYear < enrollYear + 4)
                return ValidateStudentResult.InvalidGraduationYear;

            if (createStudentDTO.GPA < 0 || createStudentDTO.GPA > 10.0)
                return ValidateStudentResult.InvalidGPA;

            Student student = StudentMapper.ToStudent(createStudentDTO, studentClass);
            await _context.Students.AddAsync(student);
            user.Student = student;
            await _context.SaveChangesAsync();
            return ValidateStudentResult.Success;
        }
        public async Task Update(Student student, CreateStudentDTO updateStudentDTO)
        {
            var studentClass = await _studentClassService.GetByClassName(updateStudentDTO.StudentClassName);

            StudentMapper.MapUpdate(student, updateStudentDTO, studentClass);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
