using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class PointCategoryMapper
    {
        public static PointCategoryDTO ToPointCategoryDTO(PointCategory pc)
        {
            return new PointCategoryDTO
            {
                Id = pc.Id,
                Category = pc.Category,
                Title = pc.Title,
                MaxScore = pc.MaxScore,
                ParentId = pc.ParentId
            };
        }

        public static List<PointCategoryDTO> ToPointCategoryDTOList(List<PointCategory> list)
        {
            return list.Select(pc => new PointCategoryDTO
            {
                Id = pc.Id,
                Category = pc.Category,
                Title = pc.Title,
                MaxScore = pc.MaxScore,
                ParentId = pc.ParentId
            }).ToList();
        }

        public static PointCategory ToPointCategory(CreateUpdatePointCategoryDTO dto)
        {
            return new PointCategory
            {
                Category = dto.Category,
                Title = dto.Title,
                MaxScore = dto.MaxScore,
                ParentId = dto.ParentId
            };
        }

        public static void MapUpdate(PointCategory pc, CreateUpdatePointCategoryDTO dto)
        {
            pc.Category = dto.Category;
            pc.Title = dto.Title;
            pc.MaxScore = dto.MaxScore;
            pc.ParentId = dto.ParentId;
        }

        public static PointPreviewDTO ToPointPreviewDTO(PointDetail pd)
        {
            return new PointPreviewDTO
            {
                SemesterId = pd.SemesterId,
                SemesterName = pd.Semester.Name,
                TotalScore = pd.TotalScore,
            };
        }
        public static List<PointDetailDTO> ToPointDetailListDTO(List<PointDetail> list)
        {
            return list.Select(pd => new PointDetailDTO
            {
                PointCategoryId = pd.PointCategoryId,
                SemesterId = pd.SemesterId,
                Category = pd.PointCategory.Category,
                Title = pd.PointCategory.Title,
                TotalScore = pd.TotalScore,
                MaxScore = pd.PointCategory.MaxScore,
                ParentId = pd.PointCategory.ParentId,
            }).ToList();
        }

        public static List<TrainingPointReportDTO> ToTrainingPointReportDTOList(List<PointDetail> list)
        {
            return list.Select(pd => new TrainingPointReportDTO
            {
                Id = pd.PointCategoryId,
                Category = pd.PointCategory.Category,
                Name = pd.PointCategory.Title,
                TotalScore = pd.TotalScore,
                MaxScore = pd.PointCategory.MaxScore
            }).ToList();
        }

        public static StudentReportDTO ToStudentReportDTO(Student student)
        {
            return new StudentReportDTO
            {
                FullName = student.User.FullName,
                StudentCode = student.StudentCode,
                StudentClass = student.StudentClass.Name,
                StudentFaculty = student.StudentClass.Major.Faculty.Name
            };
        }
    }
}