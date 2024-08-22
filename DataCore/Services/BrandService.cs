namespace DataCore.Services;

public class BrandService : GenericService<Brand>
{
    public readonly ApplicationDbContext _context;
    public BrandService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

}
