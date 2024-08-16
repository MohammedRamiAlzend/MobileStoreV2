
namespace DataCore.Services;

public class Createdatabase
{

    private readonly ApplicationDbContext _context;
    private readonly DbContextOptions<ApplicationDbContext> _options;


    public Createdatabase(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
    {
        _context = context;
        _options = options;

    }


    //Start database Func
    public async Task<List<string>> GetAllDatabasesAsync()
    {
        try
        {
            var databases = new List<string>();
            using (var context = new ApplicationDbContext(_options))
            {
                var connection = context.Database.GetDbConnection();
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM sys.databases WHERE NAME = 'MobileStore'";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            databases.Add(reader.GetString(0));
                        }
                    }
                }

                await connection.CloseAsync();
            }

            return databases;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    //End database Func

}
