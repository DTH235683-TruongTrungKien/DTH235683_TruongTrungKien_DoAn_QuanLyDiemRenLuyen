using QLDRL.DTOs.StudentDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class StudentMapper
    {
        public static StudentDTO ToStudentDTO(Student student)
        {
            var studentDTO = new StudentDTO()
            {
                UserId = student.UserId,
                StudentCode = student.StudentCode,
                StudentName = student.User.Name,
                ClassName = student.ClassName,
                BirthDay = student.BirthDay,
                Address = student.Address,
                GPA = student.GPA,
            };
            return studentDTO;
        }

        public static Student ToStudent(CreateUpdateStudentDTO createStudentDTO)
        {
            var student = new Student()
            {
                UserId = createStudentDTO.UserId,
                StudentCode = createStudentDTO.StudentCode,
                ClassName = createStudentDTO.ClassName,
                BirthDay = createStudentDTO.BirthDay,
                Address = createStudentDTO.Address,
                GPA = createStudentDTO.GPA,
            };
            return student;
        }
        public static void MapUpdate(Student student, CreateUpdateStudentDTO updateStudentDTO)
        {
            student.StudentCode = updateStudentDTO.StudentCode;
            student.ClassName = updateStudentDTO.ClassName;
            student.BirthDay = updateStudentDTO.BirthDay;
            student.Address = updateStudentDTO.Address;
            student.GPA = updateStudentDTO.GPA;
        }
    }
}
