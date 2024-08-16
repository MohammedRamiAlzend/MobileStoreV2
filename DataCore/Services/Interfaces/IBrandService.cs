

namespace DataCore.Services.Interfaces
{
    public interface IBrandService
    {
        Task<DataBaseRequest<IEnumerable<Brand>>> GetAllBrandsAsync();
        Task<DataBaseRequest<IEnumerable<Brand>>> GetAllBrandsWithDeletedAsync();

        Task<DataBaseRequest<Brand>> GetBrandByIdAsync(int id);
        Task<DataBaseRequest> CreateBrandAsync(Brand createBrand);
        Task<DataBaseRequest> UpdateBrandAsync(int id, Brand brand);
        Task<DataBaseRequest> DeleteBrandAsync(int id);
    }
}
