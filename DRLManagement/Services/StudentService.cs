using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;

namespace QLDRL.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student?> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }
        public async Task<Student?> GetByStudentCode(string code)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.StudentCode == code);
        }
        public async Task Create(CreateUpdateStudentDTO createStudentDTO)
        {
            Student student = StudentMapper.ToStudent(createStudentDTO);
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Student student, CreateUpdateStudentDTO updateStudentDTO)
        {
            StudentMapper.MapUpdate(student, updateStudentDTO);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
