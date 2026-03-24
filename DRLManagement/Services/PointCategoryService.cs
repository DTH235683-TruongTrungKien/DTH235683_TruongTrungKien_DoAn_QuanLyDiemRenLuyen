//using Microsoft.EntityFrameworkCore;
//using QLDRL.Data;
//using QLDRL.DTOs.PointCategoryDTOs;
//using QLDRL.Models;
//using QLDRL.DTOs.Mappers;

//namespace QLDRL.Services
//{
//    public class PointCategoryService
//    {
//        private readonly AppDbContext _context;

//        public PointCategoryService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<PointCategory>> GetAll()
//        {
//            return await _context.PointCategories
//                .Include(pc => pc.Parent)
//                .Include(pc => pc.Children)
//                .ToListAsync();
//        }

//        public async Task<PointCategory?> GetById(int id)
//        {
//            return await _context.PointCategories
//                .Include(pc => pc.Parent)
//                .Include(pc => pc.Children)
//                .FirstOrDefaultAsync(pc => pc.Id == id);
//        }

//        public async Task<ValidatePointCategoryResult> Create(CreatePointCategoryDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Category))
//                return ValidatePointCategoryResult.EmptyCategory;

//            if (string.IsNullOrWhiteSpace(dto.Title))
//                return ValidatePointCategoryResult.EmptyTitle;

//            if (dto.MaxScore < 0)
//                return ValidatePointCategoryResult.InvalidMaxScore;

//            if (dto.ParentId.HasValue && !await _context.PointCategories.AnyAsync(pc => pc.Id == dto.ParentId.Value))
//                return ValidatePointCategoryResult.InvalidParent;

//            PointCategory pc = PointCategoryMapper.ToPointCategory(dto);
//            await _context.PointCategories.AddAsync(pc);
//            await _context.SaveChangesAsync();
//            return ValidatePointCategoryResult.Success;
//        }

//        public async Task<ValidatePointCategoryResult> Update(PointCategory pc, UpdatePointCategoryDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Category))
//                return ValidatePointCategoryResult.EmptyCategory;

//            if (string.IsNullOrWhiteSpace(dto.Title))
//                return ValidatePointCategoryResult.EmptyTitle;

//            if (dto.MaxScore < 0)
//                return ValidatePointCategoryResult.InvalidMaxScore;

//            if (dto.ParentId.HasValue && !await _context.PointCategories.AnyAsync(p => p.Id == dto.ParentId.Value))
//                return ValidatePointCategoryResult.InvalidParent;

//            PointCategoryMapper.MapUpdate(pc, dto);
//            await _context.SaveChangesAsync();
//            return ValidatePointCategoryResult.Success;
//        }

//        public async Task Delete(PointCategory pc)
//        {
//            _context.PointCategories.Remove(pc);
//            await _context.SaveChangesAsync();
//        }
//    }

//    public enum ValidatePointCategoryResult
//    {
//        Success,
//        EmptyCategory,
//        EmptyTitle,
//        InvalidMaxScore,
//        InvalidParent
//    }
//}