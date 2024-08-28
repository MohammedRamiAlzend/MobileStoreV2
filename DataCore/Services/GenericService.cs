namespace DataCore.Services;

/// <summary>
/// A generic service class providing CRUD operations for entities that implement ISoftDelete.
/// </summary>
/// <typeparam name="T">The entity type which implements ISoftDelete.</typeparam>
public class GenericService<T> : IGenericService<T> where T : class, ISoftDelete
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes the GenericService with the specified ApplicationDbContext.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public GenericService(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    /// <summary>
    /// Retrieves all entities of type T from the database, with optional soft delete filtering and eager loading.
    /// </summary>
    /// <param name="ignoreSoftDelete">Determines whether to ignore soft delete filtering.</param>
    /// <param name="includes">Optional related entities to include via eager loading.</param>
    /// <returns>A DataBaseRequest containing the retrieved entities.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during data retrieval.</exception>
    public async Task<DataBaseRequest<IEnumerable<T>>> GetAllAsync(bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            var entities = ignoreSoftDelete ? await query.IgnoreQueryFilters().ToListAsync()
                                            : await query.ToListAsync();

            return new DataBaseRequest<IEnumerable<T>>
            {
                Data = entities,
                Message = entities.Any() ? "Data retrieved successfully" : $"No data found for type {typeof(T)}",
                Success = true,
            };
        }
        catch (Exception ex)
        {
            return new DataBaseRequest<IEnumerable<T>>
            {
                Data = null,
                Message = $"Error: {ex.Message}",
                Success = false
            };
        }
    }

    /// <summary>
    /// Retrieves a single entity of type T by its ID, with optional soft delete filtering and eager loading.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <param name="ignoreSoftDelete">Determines whether to ignore soft delete filtering.</param>
    /// <param name="includes">Optional related entities to include via eager loading.</param>
    /// <returns>A DataBaseRequest containing the retrieved entity.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during data retrieval.</exception>
    public async Task<DataBaseRequest<T>> GetByIdAsync(int id, bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            var entity = ignoreSoftDelete
                ? await query.IgnoreQueryFilters().FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id)
                : await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);

            if (entity != null)
            {
                return new DataBaseRequest<T>
                {
                    Data = entity,
                    Message = "Entity found",
                    Success = true
                };
            }

            return new DataBaseRequest<T>
            {
                Data = null,
                Message = "Entity not found",
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new DataBaseRequest<T>
            {
                Data = null,
                Message = $"Error: {ex.Message}",
                Success = false
            };
        }
    }

    /// <summary>
    /// Creates a new entity of type T in the database.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>A DataBaseRequest indicating the result of the operation.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during entity creation.</exception>
    public async Task<DataBaseRequest> CreateAsync(T entity)
    {
        try
        {
            _dbSet.Add(entity);
            var result = await _context.SaveChangesAsync();

            return result > 0
                ? new DataBaseRequest { Message = "Entity created successfully", Success = true }
                : new DataBaseRequest { Message = "Error occurred while creating entity", Success = false };
        }
        catch (Exception ex)
        {
            return new DataBaseRequest { Message = $"Error: {ex.Message}", Success = false };
        }
    }

    /// <summary>
    /// Updates an existing entity of type T in the database.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="entity">The updated entity data.</param>
    /// <returns>A DataBaseRequest indicating the result of the operation.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during entity update.</exception>
    public async Task<DataBaseRequest> UpdateAsync(int id, T entity)
    {
        try
        {
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity == null)
            {
                return new DataBaseRequest { Message = "Entity not found", Success = false };
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            var result = await _context.SaveChangesAsync();

            return result > 0
                ? new DataBaseRequest { Message = "Entity updated successfully", Success = true }
                : new DataBaseRequest { Message = "Error occurred while updating entity", Success = false };
        }
        catch (Exception ex)
        {
            return new DataBaseRequest { Message = $"Error: {ex.Message}", Success = false };
        }
    }

    /// <summary>
    /// Deletes an entity of type T from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <returns>A DataBaseRequest indicating the result of the operation.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during entity deletion.</exception>
    public async Task<DataBaseRequest> DeleteAsync(int id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return new DataBaseRequest { Message = "Entity not found", Success = false };
            }

            _dbSet.Remove(entity);
            var result = await _context.SaveChangesAsync();

            return result > 0
                ? new DataBaseRequest { Message = "Entity deleted successfully", Success = true }
                : new DataBaseRequest { Message = "Error occurred while deleting entity", Success = false };
        }
        catch (Exception ex)
        {
            return new DataBaseRequest { Message = $"Error: {ex.Message}", Success = false };
        }
    }

    /// <summary>
    /// Finds entities of type T based on a specific condition, with optional soft delete filtering and eager loading.
    /// </summary>
    /// <param name="expression">The condition to filter entities by.</param>
    /// <param name="ignoreSoftDelete">Determines whether to ignore soft delete filtering.</param>
    /// <param name="includes">Optional related entities to include via eager loading.</param>
    /// <returns>A DataBaseRequest containing the filtered entities.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during data retrieval.</exception>
    public async Task<DataBaseRequest<IEnumerable<T>>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            var entities = ignoreSoftDelete
                            ? await query.IgnoreQueryFilters().Where(expression).ToListAsync()
                            : await query.Where(expression).ToListAsync();

            return new DataBaseRequest<IEnumerable<T>>
            {
                Data = entities,
                Message = entities.Any() ? "Filtered data retrieved successfully"
                                         : "No matching data found",
                Success = entities.Any()
            };
        }
        catch (Exception ex)
        {
            return new DataBaseRequest<IEnumerable<T>>
            {
                Data = null,
                Message = $"Error: {ex.Message}",
                Success = false
            };
        }
    }

    public async Task<DataBaseRequest<T>> FindSingleEntityByConditionAsync(Expression<Func<T, bool>> expression, bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            var entities = ignoreSoftDelete
                            ? await query.IgnoreQueryFilters().FirstOrDefaultAsync(expression)
                            : await query.FirstOrDefaultAsync(expression);

            return new DataBaseRequest<T>
            {
                Data = entities,
                Message = entities != null ? "Filtered data retrieved successfully"
                                           : "No matching data found",
                Success = entities != null
            };
        }
        catch (Exception ex)
        {
            //implementation log functionality
            return new DataBaseRequest<T>
            {
                Data = null,
                Message = $"Error: {ex.Message}",
                Success = false
            };
        }
    }

}
