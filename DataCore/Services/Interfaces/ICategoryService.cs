using DataCore.Data;
using DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<DataBaseRequest<IEnumerable<Category>>> GetAllCategoryAsync();
        Task<DataBaseRequest<Category>> GetCategoryByIdAsync(int id);
        Task<DataBaseRequest> CreateCategoryAsync(Category createCategory);
        Task<DataBaseRequest> UpdateCategoryAsync(int id, Category Category);
        Task<DataBaseRequest> DeleteCategoryAsync(int id);
    }
}
