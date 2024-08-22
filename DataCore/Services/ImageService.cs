
namespace DataCore.Services;

public class ImageService : GenericService<ImageModel>
{
    private readonly ApplicationDbContext _context;

    public ImageService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
