
namespace DataCore.Services;

public class CategoryService : GenericService<Category>
{
    private readonly ApplicationDbContext _context;
    public CategoryService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
