using DataCore.Data;
using DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
