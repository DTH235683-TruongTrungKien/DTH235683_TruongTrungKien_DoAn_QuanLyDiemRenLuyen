using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
using QLDRL.Helpers;

namespace QLDRL.Services
{
    public class PointCategoryService
    {
        private readonly AppDbContext _context;

        public PointCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PointCategory>> GetAll()
        {
            return await _context.PointCategories
                .Include(pc => pc.Parent)
                .Include(pc => pc.Children)
                .ToListAsync();
        }

        public async Task<List<PointCategory>> GetAllRoots()
        {
            return await _context.PointCategories
                .Where(pc => pc.Parent == null)
                .Include(pc => pc.Children)
                .ToListAsync();
        }

        public async Task<List<PointCategory>> GetAllByParentId(int parentId)
        {
            return await _context.PointCategories
                .Where(pc => pc.ParentId == parentId)
                .ToListAsync();
        }
        public async Task<PointCategory?> GetById(int id)
        {
            return await _context.PointCategories
                .Include(pc => pc.Parent)
                .Include(pc => pc.Children)
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }


        public async Task<ValidatePointCategoryResult> Validate(CreateUpdatePointCategoryDTO dto, int? id = null)
        {
            if (string.IsNullOrWhiteSpace(dto.Category))
                return ValidatePointCategoryResult.EmptyCategory;

            if (string.IsNullOrWhiteSpace(dto.Title))
                return ValidatePointCategoryResult.EmptyTitle;

            if (dto.MaxScore < 0)
                return ValidatePointCategoryResult.InvalidMaxScore;

            if (dto.ParentId.HasValue && !await _context.PointCategories.AnyAsync(pc => pc.Id == dto.ParentId.Value))
                return ValidatePointCategoryResult.InvalidParent;

            return ValidatePointCategoryResult.Success;
        }

        public async Task<int> Create(CreateUpdatePointCategoryDTO dto)
        {
            var pc = PointCategoryMapper.ToPointCategory(dto);

            await _context.PointCategories.AddAsync(pc);
            await _context.SaveChangesAsync();

            return pc.Id;
        }

        public async Task<ValidatePointCategoryResult> Update(int id, CreateUpdatePointCategoryDTO dto)
        {
            var pc = await _context.PointCategories.FindAsync(id);
            if (pc == null)
                return ValidatePointCategoryResult.NotFound;

            PointCategoryMapper.MapUpdate(pc, dto);
            await _context.SaveChangesAsync();

            return ValidatePointCategoryResult.Success;
        }

        public async Task<ValidatePointCategoryResult> Delete(int id)
        {
            var pc = await _context.PointCategories
                .Include(x => x.Children)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (pc == null)
                return ValidatePointCategoryResult.NotFound;

            if (pc.Children.Any())
                return ValidatePointCategoryResult.HasChildren;

            _context.PointCategories.Remove(pc);
            await _context.SaveChangesAsync();

            return ValidatePointCategoryResult.Success;
        }

        //Point Details

        public async Task<bool> AnyPointDetail()
        {
            return await _context.PointDetails.AnyAsync();
        }
        public async Task<List<PointDetail>> GetStudentPreviewPoints(int userId)
        {
            return await _context.PointDetails
                .Where(pd => pd.StudentUserId == userId)
                .Where(pd => pd.PointCategory.Category == "Total")
                .Include(pd => pd.Semester)
                .ToListAsync();
        }
        public async Task<List<PointDetail>> GetStudentPointDetails(int semesterId, int studentUserId)
        {
            return await _context.PointDetails
                .Where(pd => pd.SemesterId == semesterId && pd.StudentUserId == studentUserId)
                .AsNoTracking()
                .Include(pd => pd.Semester)
                .Include(pd => pd.PointCategory)
                .ToListAsync();
        }
        public async Task<PointDetail?> GetPointDetailById(int semesterId, int studentUserId, int pointCategoryId)
        {
            return await _context.PointDetails
                .Include(pd => pd.Semester)
                .Include(pd => pd.PointCategory)
                    .ThenInclude(pc => pc.Parent)
                .FirstOrDefaultAsync(pd => pd.SemesterId == semesterId && pd.StudentUserId == studentUserId && pd.PointCategoryId == pointCategoryId);
        }
        public async Task CreatePointDetails(List<PointDetail> list)
        {
            await _context.PointDetails.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
        public async Task ScoreCalculate(int semesterId, int studentUserId, int pointCategoryId, double score)
        {
            var pd = await GetPointDetailById(semesterId, studentUserId, pointCategoryId);
            Utils.PrintDebug(pd.TotalScore);
            if(pd == null) return;

            double newScore = pd.TotalScore + score;
            if (newScore >= pd.PointCategory.MaxScore)
                pd.TotalScore = pd.PointCategory.MaxScore;
            else
                pd.TotalScore = newScore;

            if (pd.PointCategory.Parent != null)
                await ScoreCalculate(semesterId, studentUserId, pd.PointCategory.ParentId!.Value, score);
            await _context.SaveChangesAsync();
            return;
        }
    }
}