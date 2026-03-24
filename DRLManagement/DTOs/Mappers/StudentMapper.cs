using Microsoft.VisualBasic.ApplicationServices;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class StudentMapper
    {
        public static StudentDTO? ToStudentDTO(Student student)
        {
            if (student == null) return null;
            return new StudentDTO
            {
                UserId = student.UserId,
                StudentCode = student.StudentCode,
                ClassName = student.StudentClass.Name,
                MajorName = student.StudentClass.Major.Name,
                FacultyName = student.StudentClass.Major.Faculty.Name,
                SchoolYear = student.EnrollmentYear + " - " + student.GraduationYear,
                GPA = student.GPA,
            };
        }

        public static Student ToStudent(CreateStudentDTO createStudentDTO, StudentClass studentClass)
        {
            var student = new Student()
            {
                UserId = createStudentDTO.UserId,
                StudentCode = createStudentDTO.StudentCode,
                StudentClass = studentClass,
                EnrollmentYear = createStudentDTO.EnrollmentYear,
                GraduationYear = createStudentDTO.GraduationYear,
                GPA = createStudentDTO.GPA,
            };
            return student;
        }
        public static void MapUpdate(Student student, CreateStudentDTO updateStudentDTO, StudentClass studentClass)
        {
            student.StudentCode = updateStudentDTO.StudentCode;
            student.StudentClass = studentClass;
            student.EnrollmentYear = updateStudentDTO.EnrollmentYear;
            student.GraduationYear = updateStudentDTO.GraduationYear;
            student.GPA = updateStudentDTO.GPA;
        }
    }
}
