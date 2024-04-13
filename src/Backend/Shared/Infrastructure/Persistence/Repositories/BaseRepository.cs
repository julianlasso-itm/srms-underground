using System.Net;
using System.Text.Json;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Shared.Application.Interfaces;

namespace Shared.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        return entity ?? throw new Exception($"Entity with id {id} not found");
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return entities;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            var entry = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
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

    public async Task<TEntity> UpdateAsync(string id, TEntity entity)
    {
        var entityToUpdate =
            await _context.Set<TEntity>().FindAsync(id)
            ?? throw new Exception($"Entity with id {id} not found");
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
        return entityToUpdate;
    }

    public async Task<TEntity> DeleteAsync(string id)
    {
        var entity =
            await _context.Set<TEntity>().FindAsync(id)
            ?? throw new Exception($"Entity with id {id} not found");
        entity.GetType().GetProperty("DeletedAt")?.SetValue(entity, DateTime.UtcNow);
        await UpdateAsync(id, entity);
        return entity;
    }
}
