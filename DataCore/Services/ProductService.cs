
namespace DataCore.Services
{
    public class ProductService : GenericService<Product>
    {

        private readonly ApplicationDbContext _context;
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ProductService(ApplicationDbContext context,
                              DbContextOptions<ApplicationDbContext> options) : base(context)
        {
            _context = context;
            _options = options;

        }

    }
}
