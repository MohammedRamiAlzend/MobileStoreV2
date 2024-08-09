using Microsoft.EntityFrameworkCore;
using DataCore.Data;
using DataCore.Models;
using DataCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Services
{
    public class BrandService : IBrandService
    {
        public readonly ApplicationDbContext _context;
        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataBaseRequest> CreateBrandAsync(Brand createBrand)
        {
            Brand brand = new Brand
            {
                Id = createBrand.Id,
                Name = createBrand.Name,
                Products = createBrand.Products
            };
            await _context.Brands.AddAsync(brand);
            var resutl = await _context.SaveChangesAsync();
            if (resutl > 0)
            {
                return new DataBaseRequest
                {
                    Message = $"Brand {brand.Name} created successfully",
                    Success = true,
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = $"An error occurred while creating Brand ",
                    Success = true,
                };
            }
        }

        public async Task<DataBaseRequest> DeleteBrandAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return new DataBaseRequest
                {
                    Message = $"The brand with {id} not found",
                    Success = false,
                };
            }
            else
            {
                _context.Brands.Remove(brand);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"The brand {brand.Name} has been deleted successfully",
                        Success = true,
                    };
                }
                else
                {
                    return new DataBaseRequest
                    {
                        Message = "an error occurred while Deleting brand"
                    };
                }
            }
        }

        public async Task<DataBaseRequest<IEnumerable<Brand>>> GetAllBrandsAsync()
        {
            var request = await _context.Brands
                .Include(x => x.Products)
                .ToListAsync();

            if (request == null)
            {
                return new DataBaseRequest<IEnumerable<Brand>>
                {
                    Message = "There is no Brand!",
                    Success = false,
                    Data = []
                };
            }
            else
            {
                return new DataBaseRequest<IEnumerable<Brand>>
                {
                    Message = " The Brands Retrieved successfully",
                    Success = true,
                    Data = request,
                };
            }
        }

        public async Task<DataBaseRequest<Brand>> GetBrandByIdAsync(int id)
        {
            var request = await _context.Brands.FindAsync(id);
            if (request == null)
            {
                return new DataBaseRequest<Brand>
                {
                    Message = "Brand not found",
                    Success = false,
                    Data = new Brand { Name = "" },
                };
            }
            else
            {
                return new DataBaseRequest<Brand>
                {
                    Message = $"The Brand {request.Name} successfully retrieved",
                    Success = true,
                    Data = request,
                };
            }
        }

        public async Task<DataBaseRequest> UpdateBrandAsync(int id, Brand brand)
        {
            var request = await _context.Brands.FindAsync(id);
            if (request == null)
            {
                return new DataBaseRequest
                {
                    Message = $"The Brand with id {id} didn't found",
                    Success = false,
                };
            }
            else
            {
                request.Name = brand.Name;
                request.Products = brand.Products;
                _context.Brands.Update(request);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"The Brand {id} has been updated successfully",
                        Success = true,
                    };
                }
                else
                {
                    return new DataBaseRequest
                    {
                        Message = $"An error occurred while update the brand {id}",
                        Success = false,
                    };
                }
            }
        }
    }
}
