using Microsoft.EntityFrameworkCore;
using UpdatePolicyService.Models.Database;
using UpdatePolicyService.Repositories.Interfaces;

namespace UpdatePolicyService.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DatabaseContext DbContext;
    protected readonly DbSet<T> DbSet;

    public BaseRepository(DatabaseContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<T> InsertAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync();
    }
    
}

