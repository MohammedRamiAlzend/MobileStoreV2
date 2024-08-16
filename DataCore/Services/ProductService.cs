
namespace DataCore.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _context;
        private readonly DbContextOptions<ApplicationDbContext> _options;


        public ProductService(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
        {
            _context = context;


        }

        public async Task<DataBaseRequest> CreateProductAsync(Product createProduct)
        {
            Console.WriteLine("transition");
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
            var request = await GetProductByIdAsync(id);
            var product = request.Success ? request.Data : null;
            if (product == null || product.IsDeleted)
            {
                return new DataBaseRequest { Message = ($"Product with ID {id} not found or already deleted."), Success = false };
            }
            try
            {
                //product.IsDeleted = true;
                //product.DeletedAt = DateTime.UtcNow;
                _context.Entry(product).State = EntityState.Deleted;
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
            catch (Exception)
            {
                //TODO
                return new DataBaseRequest
                {
                    Message = "يوجد سلة لهذا المنتج"
                    ,
                    Success = false
                };
            }
        }

        public async Task<DataBaseRequest> UpdateProductAsync(int id, Product product)
        {
            var checkRequest = await GetProductByIdAsync(id);
            if (checkRequest.Success)
            {
                var request = checkRequest.Data;

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

                _context.Entry(request).State = EntityState.Modified;
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
            else
            {
                return new DataBaseRequest
                {
                    Success = false,
                    Message = checkRequest.Message,
                };
            }

        }

        public async Task<DataBaseRequest<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var request = await _context.Products
                                            .Include(x => x.Category)
                                            .Include(x => x.Brand)
                                            .ToListAsync();
            if (request != null)
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
        public async Task<DataBaseRequest<IEnumerable<Product>>> GetAllProductsWithDeletedProductsAsync()
        {
            var request = await _context.Products
                                            .Include(x => x.Category)
                                            .Include(x => x.Brand)
                                            .AsNoTracking()
                                            .IgnoreQueryFilters()
                                            .ToListAsync();
            if (request != null)
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
