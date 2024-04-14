using System.Net;
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
        var entity = await DbSet.FindAsync(id);
        return entity ?? throw new Exception($"Entity with id {id} not found");
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await DbSet.ToListAsync();
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
                new JsonSerializerOptions { WriteIndented = true, }
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
}
