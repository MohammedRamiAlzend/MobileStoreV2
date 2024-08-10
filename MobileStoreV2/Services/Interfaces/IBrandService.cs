using MobileStoreV2.Data;
using MobileStoreV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Services.Interfaces
{
    public interface IBrandService
    {
        Task<DataBaseRequest<IEnumerable<Brand>>> GetAllBrandsAsync();
        Task<DataBaseRequest<Brand>> GetBrandByIdAsync(int id);
        Task<DataBaseRequest> CreateBrandAsync(Brand createBrand);
        Task<DataBaseRequest> UpdateBrandAsync(int id, Brand brand);
        Task<DataBaseRequest> DeleteBrandAsync(int id);
    }
}
