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
                .Include(x => x.User)
                .Include(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .ToListAsync();
        }
        public async Task<Student?> GetById(int id)
        {
            return await _context.Students
                .Include (x => x.User)
                .Include(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.UserId == id);
        }
        public async Task<Student?> GetByStudentCode(string code)
        {
            return await _context.Students
                .Include(x => x.User)
                .Include(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.StudentCode == code);
        }
        public ValidateStudentResult ValidateStudent(CreateUpdateStudentDTO studentDTO, StudentClass studentClass)
        {
            if (string.IsNullOrWhiteSpace(studentDTO.StudentCode) ||
                !Regex.IsMatch(studentDTO.StudentCode, @"^[A-Z]{3}\d{6}$"))
            {
                return ValidateStudentResult.InvalidStudentCode;
            }

            if (studentClass == null)
                return ValidateStudentResult.StudentClassNotFound;

            if (!int.TryParse(studentDTO.EnrollmentYear, out int enrollYear))
                return ValidateStudentResult.InvalidEnrollmentYear;

            if (!int.TryParse(studentDTO.GraduationYear, out int gradYear))
                return ValidateStudentResult.InvalidGraduationYear;

            var currentYear = DateTime.Now.Year;

            if (enrollYear < currentYear)
                return ValidateStudentResult.InvalidEnrollmentYear;

            if (gradYear < enrollYear + 4)
                return ValidateStudentResult.InvalidGraduationYear;

            if (studentDTO.GPA < 0 || studentDTO.GPA > 10.0)
                return ValidateStudentResult.InvalidGPA;
            return ValidateStudentResult.Success;

        }
        public async Task<int> Create(CreateUpdateStudentDTO createStudentDTO, User user)
        {   
            var studentClass = await _studentClassService.GetById(createStudentDTO.StudentClassId);
            Student student = StudentMapper.ToStudent(createStudentDTO, studentClass);
            await _context.Students.AddAsync(student);
            user.Student = student;
            student.User = user;
            await _context.SaveChangesAsync();
            return student.UserId;
        }
        public async Task<int> Update(Student student, CreateUpdateStudentDTO updateStudentDTO)
        {
            var studentClass = await _studentClassService.GetById(updateStudentDTO.StudentClassId);
            StudentMapper.MapUpdate(student, updateStudentDTO, studentClass);
            await _context.SaveChangesAsync();
            return student.UserId;
        }
        public async Task<bool> Delete(int userId)
        {
            var student = await GetById(userId);
            if (student == null)
                return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
