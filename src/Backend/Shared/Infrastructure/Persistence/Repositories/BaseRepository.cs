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

    private const string Id = "Id";
    private const string Entity = "entity";
    private const string CreatedAt = "CreatedAt";
    private const string UpdatedAt = "UpdatedAt";
    private const string DeletedAt = "DeletedAt";

    public BaseRepository(DbContext context)
    {
        Context = context;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var parameter = Expression.Parameter(typeof(TEntity), Entity);

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
        var propertyInfo = typeof(TEntity).GetProperty(DeletedAt);
        Expression<Func<TEntity, bool>>? lambda;
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
        {
            var deletedAtProperty = Expression.Property(parameter, DeletedAt);
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

    public Task<int> GetCountAsync(string? filter = null, string? filterBy = null)
    {
        var query = DbSet.AsQueryable();

        // Filter DeletedAt if applicable
        var propertyInfo = typeof(TEntity).GetProperty(DeletedAt);
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
        {
            var parameter = Expression.Parameter(typeof(TEntity), Entity);
            var deletedAtProperty = Expression.Property(parameter, DeletedAt);
            var nullConstant = Expression.Constant(null, typeof(DateTime?));
            var equalsNull = Expression.Equal(deletedAtProperty, nullConstant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equalsNull, parameter);

            query = query.Where(lambda);
        }

        // Apply text or UUID filter if provided
        if (!string.IsNullOrEmpty(filter))
        {
            var param = Expression.Parameter(typeof(TEntity), Entity);
            Expression? filterExpression = null;

            if (!string.IsNullOrEmpty(filterBy))
            {
                var prop = typeof(TEntity).GetProperty(filterBy);
                if (prop != null && prop.PropertyType == typeof(Guid)) // Specific handling for UUID fields
                {
                    if (Guid.TryParse(filter, out Guid filterGuid))
                    {
                        var propAccess = Expression.Property(param, prop);
                        var exactExpression = Expression.Equal(
                            propAccess,
                            Expression.Constant(filterGuid)
                        );
                        filterExpression = exactExpression;
                    }
                }
                else if (
                    prop != null
                    && prop.PropertyType == typeof(string)
                    && !prop.Name.EndsWith(Id)
                )
                {
                    var propAccess = Expression.Property(param, prop);
                    var likeExpression = Expression.Call(
                        typeof(DbFunctionsExtensions),
                        "Like",
                        Type.EmptyTypes,
                        Expression.Constant(EF.Functions),
                        propAccess,
                        Expression.Constant($"%{filter}%")
                    );
                    filterExpression = likeExpression;
                }
            }
            else
            {
                // Apply filter to all eligible string fields
                foreach (
                    var prop in typeof(TEntity)
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(string) && !p.Name.EndsWith(Id))
                )
                {
                    var propAccess = Expression.Property(param, prop);
                    var likeExpression = Expression.Call(
                        typeof(DbFunctionsExtensions),
                        "Like",
                        Type.EmptyTypes,
                        Expression.Constant(EF.Functions),
                        propAccess,
                        Expression.Constant($"%{filter}%")
                    );

                    filterExpression =
                        filterExpression == null
                            ? likeExpression
                            : Expression.OrElse(filterExpression, likeExpression);
                }
            }

            if (filterExpression != null)
            {
                var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, param);
                query = query.Where(lambda);
            }
        }

        // Return the count of the filtered elements
        return query.CountAsync();
    }

    public async Task<IEnumerable<TEntity>> GetWithPaginationAsync(
        int page,
        int limit,
        string? sort = null,
        string order = "asc",
        string? filter = null,
        string? filterBy = null
    )
    {
        var query = DbSet.AsQueryable();

        // Filter DeletedAt if applicable using reflection
        var deletedPropertyInfo = typeof(TEntity).GetProperty(DeletedAt);
        if (deletedPropertyInfo != null && deletedPropertyInfo.PropertyType == typeof(DateTime?))
        {
            var parameter = Expression.Parameter(typeof(TEntity), Entity);
            var property = Expression.Property(parameter, DeletedAt);
            var nullConstant = Expression.Constant(null, typeof(DateTime?));
            var equalsNull = Expression.Equal(property, nullConstant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equalsNull, parameter);
            query = query.Where(lambda);
        }

        // General or specific filtering
        if (!string.IsNullOrEmpty(filter))
        {
            var param = Expression.Parameter(typeof(TEntity), Entity);
            Expression? filterExpression = null;

            if (!string.IsNullOrEmpty(filterBy))
            {
                var prop = typeof(TEntity).GetProperty(filterBy);
                if (prop != null)
                {
                    if (
                        prop.PropertyType == typeof(Guid)
                        && Guid.TryParse(filter, out var filterGuid)
                    )
                    {
                        var propAccess = Expression.Property(param, prop);
                        var exactExpression = Expression.Equal(
                            propAccess,
                            Expression.Constant(filterGuid)
                        );
                        filterExpression = exactExpression;
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        var propAccess = Expression.Property(param, prop);
                        var likeExpression = Expression.Call(
                            typeof(DbFunctionsExtensions),
                            "Like",
                            Type.EmptyTypes,
                            Expression.Constant(EF.Functions),
                            propAccess,
                            Expression.Constant($"%{filter}%")
                        );
                        filterExpression = likeExpression;
                    }
                }
            }
            else
            {
                foreach (
                    var prop in typeof(TEntity)
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(string) && !p.Name.EndsWith(Id))
                )
                {
                    var propAccess = Expression.Property(param, prop);
                    var likeExpression = Expression.Call(
                        typeof(DbFunctionsExtensions),
                        "Like",
                        Type.EmptyTypes,
                        Expression.Constant(EF.Functions),
                        propAccess,
                        Expression.Constant($"%{filter}%")
                    );

                    filterExpression =
                        filterExpression == null
                            ? likeExpression
                            : Expression.OrElse(filterExpression, likeExpression);
                }
            }

            if (filterExpression != null)
            {
                var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, param);
                query = query.Where(lambda);
            }
        }

        // Handling sorting
        if (string.IsNullOrEmpty(sort) && typeof(TEntity).GetProperty(CreatedAt) != null)
        {
            sort = CreatedAt; // Default to CreatedAt if no sort specified and the property exists
        }

        if (!string.IsNullOrEmpty(sort) && typeof(TEntity).GetProperty(sort) != null)
        {
            var sortParam = Expression.Parameter(typeof(TEntity), Entity);
            var sortExpression = Expression.Property(sortParam, sort);
            var lambdaSort = Expression.Lambda<Func<TEntity, object>>(
                Expression.Convert(sortExpression, typeof(object)),
                sortParam
            );

            query = order.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? query.OrderByDescending(lambdaSort)
                : query.OrderBy(lambdaSort);
        }

        // Apply pagination after sorting
        query = query.Skip((page - 1) * limit).Take(limit);

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

        var updatedAtProperty = entity.GetType().GetProperty(UpdatedAt);
        if (updatedAtProperty != null && updatedAtProperty.PropertyType == typeof(DateTime?))
        {
            updatedAtProperty.SetValue(entity, DateTime.UtcNow);
        }

        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (property.Name == CreatedAt || property.Name == DeletedAt)
            {
                continue;
            }

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

        // Checks if the entity has a "DeletedAt" property
        var deletedAtProperty = entity.GetType().GetProperty(DeletedAt);
        if (deletedAtProperty != null && deletedAtProperty.PropertyType == typeof(DateTime?))
        {
            // If the property exists and it is of the correct type, perform a soft delete
            deletedAtProperty.SetValue(entity, DateTime.UtcNow);
        }
        else
        {
            // If the "DeletedAt" property does not exist, perform a physical deletion
            DbSet.Remove(entity);
        }

        await Context.SaveChangesAsync();
        return entity;
    }

    private static PropertyInfo? FindIdProperty()
    {
        // Search for the first property whose name ends with "Id".
        return typeof(TEntity).GetProperties().FirstOrDefault(p => p.Name.EndsWith(Id));
    }
}

// using System.Linq.Expressions;
// using System.Net;
// using System.Text.Json;
// using Grpc.Core;
// using Microsoft.EntityFrameworkCore;
// using Shared.Application.Interfaces;

// namespace Shared.Infrastructure.Persistence.Repositories;

// public interface IAuditableEntity
// {
//     DateTime? CreatedAt { get; set; }
//     DateTime? UpdatedAt { get; set; }
//     DateTime? DeletedAt { get; set; }
// }

// public abstract class BaseRepository<TEntity> : IRepository<TEntity>
//     where TEntity : class
// {
//     protected readonly DbContext Context;
//     protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

//     public BaseRepository(DbContext context)
//     {
//         Context = context;
//     }

//     public async Task<TEntity> GetByIdAsync(Guid id)
//     {
//         var parameter = Expression.Parameter(typeof(TEntity), "entity");
//         var idPropertyInfo = typeof(TEntity).GetProperty("Id");
//         var idProperty = Expression.Property(parameter, idPropertyInfo);
//         var idValue = Expression.Constant(id, idPropertyInfo.PropertyType);
//         var idEquals = Expression.Equal(idProperty, idValue);

//         Expression<Func<TEntity, bool>>? lambda = Expression.Lambda<Func<TEntity, bool>>(
//             idEquals,
//             parameter
//         );

//         if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
//         {
//             var deletedAtProperty = Expression.Property(
//                 parameter,
//                 typeof(IAuditableEntity).GetProperty("DeletedAt")
//             );
//             var nullConstant = Expression.Constant(null, typeof(DateTime?));
//             var equalsNull = Expression.Equal(deletedAtProperty, nullConstant);
//             var andExpression = Expression.AndAlso(idEquals, equalsNull);
//             lambda = Expression.Lambda<Func<TEntity, bool>>(andExpression, parameter);
//         }

//         var entity = await DbSet.FirstOrDefaultAsync(lambda);
//         return entity ?? throw new Exception($"Entity with id {id} not found");
//     }

//     public Task<int> GetCountAsync(string? filter = null, string? filterBy = null)
//     {
//         var query = DbSet.AsQueryable();

//         if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
//         {
//             query = query.Where(e => ((IAuditableEntity)e).DeletedAt == null);
//         }

//         // Aplicar filtro de texto si se proporciona
//         if (!string.IsNullOrEmpty(filter))
//         {
//             var parameter = Expression.Parameter(typeof(TEntity), "e");
//             Expression? combined = null;

//             if (!string.IsNullOrEmpty(filterBy))
//             {
//                 // Filtering by a specific field
//                 combined = GenerateFilterExpression(parameter, filterBy, filter);
//             }
//             else
//             {
//                 // Generic filter over all string properties
//                 foreach (
//                     var prop in typeof(TEntity)
//                         .GetProperties()
//                         .Where(p => p.PropertyType == typeof(string))
//                 )
//                 {
//                     var currentFilter = GenerateFilterExpression(parameter, prop.Name, filter);
//                     combined =
//                         combined == null
//                             ? currentFilter
//                             : Expression.OrElse(combined, currentFilter);
//                 }
//             }

//             if (combined != null)
//             {
//                 var lambda = Expression.Lambda<Func<TEntity, bool>>(combined, parameter);
//                 query = query.Where(lambda);
//             }
//         }

//         return query.CountAsync();
//     }

//     public async Task<IEnumerable<TEntity>> GetWithPaginationAsync(
//         int page,
//         int limit,
//         string sort = "CreatedAt",
//         string order = "asc",
//         string? filter = null,
//         string? filterBy = null
//     )
//     {
//         var query = DbSet.AsQueryable();

//         if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
//         {
//             query = query.Where(e => ((IAuditableEntity)e).DeletedAt == null);
//         }

//         if (!string.IsNullOrEmpty(filter))
//         {
//             var parameter = Expression.Parameter(typeof(TEntity), "e");
//             Expression? combined = null;

//             if (!string.IsNullOrEmpty(filterBy))
//             {
//                 // Filtering by a specific field
//                 combined = GenerateFilterExpression(parameter, filterBy, filter);
//             }
//             else
//             {
//                 // Generic filter over all string properties
//                 foreach (
//                     var prop in typeof(TEntity)
//                         .GetProperties()
//                         .Where(p => p.PropertyType == typeof(string))
//                 )
//                 {
//                     var currentFilter = GenerateFilterExpression(parameter, prop.Name, filter);
//                     combined =
//                         combined == null
//                             ? currentFilter
//                             : Expression.OrElse(combined, currentFilter);
//                 }
//             }

//             if (combined != null)
//             {
//                 var lambda = Expression.Lambda<Func<TEntity, bool>>(combined, parameter);
//                 query = query.Where(lambda);
//             }
//         }

//         if (!string.IsNullOrEmpty(sort))
//         {
//             query = ApplySorting(query, sort, order);
//         }

//         var result = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
//         return result;
//     }

//     public async Task<TEntity> AddAsync(TEntity entity)
//     {
//         try
//         {
//             var entry = await DbSet.AddAsync(entity);
//             await Context.SaveChangesAsync();
//             return entry.Entity;
//         }
//         catch (DbUpdateException exception)
//         {
//             var message = JsonSerializer.Serialize(
//                 new
//                 {
//                     StatusCode = HttpStatusCode.Conflict,
//                     Message = exception.Message,
//                     Errors = exception.InnerException?.Message,
//                 },
//                 options: new JsonSerializerOptions { WriteIndented = true, }
//             );
//             throw new RpcException(new Status(StatusCode.AlreadyExists, message));
//         }
//     }

//     public async Task<TEntity> UpdateAsync(Guid id, IDictionary<string, object> updatedFields)
//     {
//         var entity = await GetByIdAsync(id);

//         Context.Attach(entity);
//         foreach (var field in updatedFields)
//         {
//             var property = Context.Entry(entity).Property(field.Key);
//             if (property == null)
//                 throw new ArgumentException(
//                     $"Property '{field.Key}' not found on entity type '{typeof(TEntity).Name}'."
//                 );

//             property.CurrentValue = field.Value;
//             property.IsModified = true; // Marking only the updated properties as modified
//         }

//         // Optionally update 'UpdatedAt' if it exists and is of the correct type
//         var updatedAtProperty = Context.Entry(entity).Property("UpdatedAt");
//         if (updatedAtProperty != null && updatedAtProperty.Metadata.ClrType == typeof(DateTime?))
//         {
//             updatedAtProperty.CurrentValue = DateTime.UtcNow;
//         }

//         await Context.SaveChangesAsync();
//         return entity;
//     }

//     public async Task<TEntity> DeleteAsync(Guid id)
//     {
//         var entity = await GetByIdAsync(id);
//         if (entity is IAuditableEntity auditable)
//         {
//             auditable.DeletedAt = DateTime.UtcNow;
//         }
//         else
//         {
//             DbSet.Remove(entity);
//         }

//         await Context.SaveChangesAsync();
//         return entity;
//     }

//     private Expression GenerateFilterExpression(
//         ParameterExpression parameter,
//         string propertyName,
//         string filter
//     )
//     {
//         var property = Expression.Property(parameter, propertyName);
//         if (property.Type == typeof(string))
//         {
//             // Use Like for string properties
//             var constant = Expression.Constant($"%{filter}%");
//             var likeMethod = typeof(DbFunctionsExtensions).GetMethod(
//                 nameof(DbFunctionsExtensions.Like),
//                 new[] { typeof(DbFunctions), typeof(string), typeof(string) }
//             );
//             var functions = Expression.Property(null, typeof(EF), nameof(EF.Functions));
//             return Expression.Call(likeMethod, functions, property, constant);
//         }
//         else if (property.Type == typeof(Guid))
//         {
//             // Use equality for Guid properties
//             if (Guid.TryParse(filter, out Guid guidValue))
//             {
//                 return Expression.Equal(property, Expression.Constant(guidValue));
//             }
//             throw new ArgumentException("Invalid GUID format.");
//         }
//         throw new ArgumentException("Unsupported property type for filtering.");
//     }

//     private IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, string sort, string order)
//     {
//         var parameter = Expression.Parameter(typeof(TEntity), "e");
//         var property = Expression.Property(parameter, sort);
//         var lambda = Expression.Lambda<Func<TEntity, object>>(
//             Expression.Convert(property, typeof(object)),
//             parameter
//         );

//         return order.ToLower() == "asc" ? query.OrderBy(lambda) : query.OrderByDescending(lambda);
//     }
// }
