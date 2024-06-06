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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataBaseRequest> CreateProductAsync(Product createProduct)
        {
            Product product = new Product
            {
                BarCode = createProduct.BarCode,
                Name = createProduct.Name,
                Brand = createProduct.Brand,
                BrandId = createProduct.BrandId,
                Category = createProduct.Category,
                CategoryId = createProduct.CategoryId,
                Description = createProduct.Description,
                Discount = createProduct.Discount,
                ImagePath = createProduct.ImagePath,
                InsertDate = createProduct.InsertDate,
                Price = createProduct.Price,
                Quantity = createProduct.Quantity
            };
            _context.Products.Add(product);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new DataBaseRequest
                {
                    Message = "Product Added Successfully",
                    Success = true
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = "Error occurred while adding new product",
                    Success = false
                };
            }

        }

        public async Task<DataBaseRequest> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new DataBaseRequestException($"Product with {id} not found!");

            _context.Products.Remove(product);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new DataBaseRequest
                {
                    Message = $"Product {product.Name} Deleted Successfully",
                    Success = true
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = $"an error occurred while Deleting {product.Name} ",
                    Success = false
                };
            }
        }

        public async Task<DataBaseRequest> UpdateProductAsync(int id, Product product)
        {
            var request = await _context.Products.FindAsync(id);

            if (request == null)
                throw new DataBaseRequestException($"Product with {id} not found!");

            request.Name = product.Name;
            request.Description = product.Description;
            request.Price = product.Price;
            request.Discount = product.Discount;
            request.ImagePath = product.ImagePath;
            request.Quantity = product.Quantity;
            request.BarCode = product.BarCode;
            request.InsertDate = product.InsertDate;
            request.Brand = product.Brand;
            request.Category = product.Category;


            _context.Products.Update(request);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new DataBaseRequest
                {
                    Message = $"Product {product.Name} Updated Successfully",
                    Success = true
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = $"an error occurred while Updating {product.Name} ",
                    Success = false
                };
            }
        }

        public async Task<DataBaseRequest<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var request = await _context.Products
                                 .Include(p => p.Brand)
                                 .Include(p => p.Category)
                                 .ToListAsync();
            if (request != null )
            {
                return new DataBaseRequest<IEnumerable<Product>>
                {
                    Data = request,
                    Message = "Product retrieved successfully",
                    Success = true

                };
            }
            else
            {
                return new DataBaseRequest<IEnumerable<Product>>
                {
                    Data = [],
                    Message = "there is no Product or products",
                    Success = false

                };
            }
        }

        public async Task<DataBaseRequest<Product>> GetProductByIdAsync(int id)
        {
            var request = await _context.Products
                                 .Include(p => p.Brand)
                                 .Include(p => p.Category)
                                 .FirstOrDefaultAsync(p => p.Id == id);
            if (request != null)
            {
                return new DataBaseRequest<Product>
                {
                    Data = request,
                    Message = "Product Found!",
                    Success = true,
                };
            }
            else
            {
                return new DataBaseRequest<Product>
                {
                    Data = new Product(),
                    Message = $"The Product with {id} not Found"
                };

            }
        }


    }
}
