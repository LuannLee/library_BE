using library_BE.Interfaces;
using library_BE.Models;
using library_BE.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<object> CreateCategory(CategoryRequest request)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Name = request.Name;
            category.CreatedDate = DateTime.Now;
            category.Status = Enums.Status.Active;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;

        }

        public async Task<bool> DeleteCategory(string Id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id.ToString() == Id);
            if (null == category)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<object> GetCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            if (null == categories || 0 == categories.Count())
                return null;
            return categories;
        }

        public async Task<object> UpdateCategory(CategoryRequest request)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == request.Id);
            if (null == category)
                return null;

            category.Name = request.Name;
            category.UpdatedDate = DateTime.Now;
            category.Status = request.Status;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
