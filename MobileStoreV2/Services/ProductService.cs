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

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                                 .Include(p => p.Brand)
                                 .Include(p => p.Category)
                                 .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                                 .Include(p => p.Brand)
                                 .Include(p => p.Category)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
