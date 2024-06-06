using MobileStoreV2.Data;
using MobileStoreV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Services.Interfaces
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
