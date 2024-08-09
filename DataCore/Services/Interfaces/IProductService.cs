using DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCore.Data;

namespace DataCore.Services.Interfaces
{
    public interface IProductService
    {
        Task<DataBaseRequest<IEnumerable<Product>>> GetAllProductsAsync();
        Task<DataBaseRequest<IEnumerable<Product>>> GetAllProductsWithDeletedProductsAsync();

        Task<DataBaseRequest<Product>> GetProductByIdAsync(int id);

        Task<DataBaseRequest> CreateProductAsync(Product createProduct);
        Task<DataBaseRequest> UpdateProductAsync(int id, Product product);
        Task<DataBaseRequest> DeleteProductAsync(int id);
    }
}
