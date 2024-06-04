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

        public async Task<Product> CreateProductAsync(Product createProduct)
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
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(int id, Product product)
        {
            var request = await _context.Products.FindAsync(id);

            if (request == null)
                throw new KeyNotFoundException("Product not found");

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

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                                 .Include(p => p.Brand)
                                 .Include(p => p.Category)
                                 .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var request = await _context.Products
                                 .Include(p => p.Brand)
                                 .Include(p => p.Category)
                                 .FirstOrDefaultAsync(p => p.Id == id);
            return request!;
        }


    }
}
