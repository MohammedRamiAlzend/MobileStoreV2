
namespace DataCore.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;
    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<DataBaseRequest<Category>> GetCategoryByNameAsync(string name)
    {
        var request = await _context.Categories.Where(x => x.Name.ToLower() == name.ToLower()).FirstAsync();
        if (request == null)
        {
            return new DataBaseRequest<Category>
            {
                Message = "Category not found",
                Success = false,
                Data = new Category { Name = "" },
            };
        }
        else
        {
            return new DataBaseRequest<Category>
            {
                Message = $"The category {request.Name} successfully retrieved",
                Success = true,
                Data = request,
            };
        }
    }

    public async Task<DataBaseRequest> CreateCategoryAsync(Category createCategory)
    {
        Category category = new Category
        {
            Name = createCategory.Name,
            Products = createCategory.Products,
        };
        _context.Categories.Add(category);
        var resutl = await _context.SaveChangesAsync();
        if (resutl > 0)
        {
            return new DataBaseRequest
            {
                Message = "Category Created Successfully",
                Success = true,
            };
        }
        else
        {
            return new DataBaseRequest
            {
                Message = "An error occurred while creating Category",
                Success = false,
            };
        }
    }

    public async Task<DataBaseRequest> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return new DataBaseRequest
            {
                Message = $"The category with {id} not found",
                Success = false,
            };
        }
        else
        {
            _context.Categories.Remove(category);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new DataBaseRequest
                {
                    Message = $"The Category {category.Name} has been deleted successfully",
                    Success = true,
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = "an error occurred while Deleting Category"
                };
            }
        }

    }

    public async Task<DataBaseRequest<IEnumerable<Category>>> GetAllCategoryAsync()
    {
        var request = await _context.Categories
            .Include(x => x.Products)
            .ToListAsync();

        if (request == null)
        {
            return new DataBaseRequest<IEnumerable<Category>>
            {
                Message = "There is no Category!",
                Success = false,
                Data = []
            };
        }
        else
        {
            return new DataBaseRequest<IEnumerable<Category>>
            {
                Message = " The Categories Retrieved successfully",
                Success = true,
                Data = request,
            };
        }
    }

    public async Task<DataBaseRequest<IEnumerable<Category>>> GetAllCategoryWithDeletedAsync()
    {
        var request = await _context.Categories
            .Include(x => x.Products)
            .ToListAsync();

        if (request == null)
        {
            return new DataBaseRequest<IEnumerable<Category>>
            {
                Message = "There is no Category!",
                Success = false,
                Data = []
            };
        }
        else
        {
            return new DataBaseRequest<IEnumerable<Category>>
            {
                Message = " The Categories Retrieved successfully",
                Success = true,
                Data = request,
            };
        }
    }
    public async Task<DataBaseRequest<Category>> GetCategoryByIdAsync(int id)
    {
        var request = await _context.Categories.FindAsync(id);
        if (request == null)
        {
            return new DataBaseRequest<Category>
            {
                Message = "Category not found",
                Success = false,
                Data = new Category { Name = "" },
            };
        }
        else
        {
            return new DataBaseRequest<Category>
            {
                Message = $"The category {request.Name} successfully retrieved",
                Success = true,
                Data = request,
            };
        }
    }

    public async Task<DataBaseRequest> UpdateCategoryAsync(int id, Category category)
    {
        var request = await _context.Categories.FindAsync(id);
        if (request == null)
        {
            return new DataBaseRequest
            {
                Message = $"The Category with id {id} didn't found",
                Success = false,
            };
        }
        else
        {
            request.Name = category.Name;
            request.Products = category.Products;
            _context.Categories.Update(request);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new DataBaseRequest
                {
                    Message = $"The Category {id} has been updated successfully",
                    Success = true,
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = $"An error occurred while update the category {id}",
                    Success = false,
                };
            }
        }


    }
}
