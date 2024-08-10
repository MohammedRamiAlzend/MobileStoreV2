using MobileStoreV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileStoreV2.Data;

namespace MobileStoreV2.Services.Interfaces
{
    public interface IProductService
    {
        Task<DataBaseRequest<IEnumerable<Product>>> GetAllProductsAsync();
        Task<DataBaseRequest<Product>> GetProductByIdAsync(int id);

        Task<DataBaseRequest> CreateProductAsync(Product createProduct);
        Task<DataBaseRequest> UpdateProductAsync(int id, Product product);
        Task<DataBaseRequest> DeleteProductAsync(int id);
    }
}
