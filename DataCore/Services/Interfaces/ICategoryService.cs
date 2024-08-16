namespace DataCore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<DataBaseRequest<IEnumerable<Category>>> GetAllCategoryAsync();
        Task<DataBaseRequest<IEnumerable<Category>>> GetAllCategoryWithDeletedAsync();
        Task<DataBaseRequest<Category>> GetCategoryByIdAsync(int id);
        Task<DataBaseRequest> CreateCategoryAsync(Category createCategory);
        Task<DataBaseRequest> UpdateCategoryAsync(int id, Category Category);
        Task<DataBaseRequest> DeleteCategoryAsync(int id);
    }
}
