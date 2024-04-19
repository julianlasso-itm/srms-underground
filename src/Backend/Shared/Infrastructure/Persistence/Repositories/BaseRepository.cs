using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text.Json;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Shared.Application.Interfaces;

namespace Shared.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly DbContext Context;
    protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

    public BaseRepository(DbContext context)
    {
        Context = context;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "e");

        // Find the ID property ending with "Id"
        var idPropertyInfo =
            FindIdProperty()
            ?? throw new InvalidOperationException(
                "No property ending in 'Id' found for the TEntity type."
            );

        // Create an expression for the ID
        var idProperty = Expression.Property(parameter, idPropertyInfo);
        var idValue = Expression.Constant(id, idPropertyInfo.PropertyType);
        var idEquals = Expression.Equal(idProperty, idValue);

        // Use reflection to determine if the entity has the DeletedAt property.
        var propertyInfo = typeof(TEntity).GetProperty("DeletedAt");
        Expression<Func<TEntity, bool>>? lambda;
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
        {
            var deletedAtProperty = Expression.Property(parameter, "DeletedAt");
            var nullConstant = Expression.Constant(null, typeof(DateTime?));
            var equalsNull = Expression.Equal(deletedAtProperty, nullConstant);

            // Combining both expressions
            var andExpression = Expression.AndAlso(idEquals, equalsNull);
            lambda = Expression.Lambda<Func<TEntity, bool>>(andExpression, parameter);
        }
        else
        {
            // If the DeletedAt property does not exist, use only the ID condition
            lambda = Expression.Lambda<Func<TEntity, bool>>(idEquals, parameter);
        }

        // Execute the query
        var entity = await DbSet.FirstOrDefaultAsync(lambda);
        return entity ?? throw new Exception($"Entity with id {id} not found");
    }

    public async Task<IEnumerable<TEntity>> GetWithPaginationAsync(
        int page,
        int limit,
        string? sort,
        string? order
    )
    {
        // Use expressions to build the DeletedAt condition if applicable
        var query = DbSet.AsQueryable();

        var propertyInfo = typeof(TEntity).GetProperty("DeletedAt");
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, "DeletedAt");
            var nullConstant = Expression.Constant(null, typeof(DateTime?));
            var equalsNull = Expression.Equal(property, nullConstant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equalsNull, parameter);
            query = query.Where(lambda);
        }

        // Apply pagination
        query = query.Skip((page - 1) * limit).Take(limit);

        // Optional: Add sorting if necessary
        if (!string.IsNullOrEmpty(sort))
        {
            var param = Expression.Parameter(typeof(TEntity), "e");
            var sortExpression = Expression.Property(param, sort);
            var lambda = Expression.Lambda<Func<TEntity, object>>(
                Expression.Convert(sortExpression, typeof(object)),
                param
            );

            query = order == "desc" ? query.OrderByDescending(lambda) : query.OrderBy(lambda);
        }

        var entities = await query.ToListAsync();
        return entities;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            var entry = await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (DbUpdateException exception)
        {
            var message = JsonSerializer.Serialize(
                new
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Message = exception.Message,
                    Errors = exception.InnerException?.Message,
                },
                options: new JsonSerializerOptions { WriteIndented = true, }
            );
            throw new RpcException(new Status(StatusCode.AlreadyExists, message));
        }
    }

    public async Task<TEntity> UpdateAsync(Guid id, TEntity updatedEntity)
    {
        var entity = await GetByIdAsync(id);
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(updatedEntity);
            if (value != null)
            {
                entity.GetType().GetProperty(property.Name)?.SetValue(entity, value);
            }
        }
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        DbSet.Remove(entity);
        return entity;
    }

    public async Task<TEntity> SoftDeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        entity.GetType().GetProperty("DeletedAt")?.SetValue(entity, DateTime.UtcNow);
        await Context.SaveChangesAsync();
        return entity;
    }

    private static PropertyInfo? FindIdProperty()
    {
        // Search for the first property whose name ends with "Id".
        return typeof(TEntity).GetProperties().FirstOrDefault(p => p.Name.EndsWith("Id"));
    }

    public Task<int> GetCountAsync()
    {
        var query = DbSet.AsQueryable();

        // Use reflection to determine if the entity has the property 'DeletedAt'.
        var propertyInfo = typeof(TEntity).GetProperty("DeletedAt");
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var deletedAtProperty = Expression.Property(parameter, "DeletedAt");
            var nullConstant = Expression.Constant(null, typeof(DateTime?));
            var equalsNull = Expression.Equal(deletedAtProperty, nullConstant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equalsNull, parameter);

            query = query.Where(lambda);
        }

        // Return the count of the filtered elements
        return query.CountAsync();
    }
}
