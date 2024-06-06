using Microsoft.EntityFrameworkCore;
using MobileStoreV2.Data;
using MobileStoreV2.Models;
using MobileStoreV2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category createCategory)
        {
            Category category = new Category
            { 
                Name = createCategory.Name,
                Products = createCategory.Products,
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;

        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                throw new KeyNotFoundException("category not found");
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var request = await _context.Categories.FindAsync(id);
            if(request==null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            return request;
        }

        public async Task UpdateCategoryAsync(int id, Category category)
        {
            var request = await _context.Categories.FindAsync(id);
            if (request == null)
                throw new KeyNotFoundException("Category not found");

            request.Name = category.Name;
            request.Products = category.Products;

            _context.Categories.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
