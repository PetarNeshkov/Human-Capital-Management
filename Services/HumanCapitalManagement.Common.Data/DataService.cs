using System.Linq.Expressions;
using HumanCapitalManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Common.Data;

public class DataService<TEntity>(HumanCapitalManagementDbContext db)
    : IDataService<TEntity>
    where TEntity : class
{
    public async Task SaveChanges()
        => await db.SaveChangesAsync();
    public async Task Add(TEntity entity)
        => await db.AddAsync(entity);

    public void Update(TEntity entity)
        => db.Update(entity);
    
    public void Delete(TEntity entity)
        => db.Remove(entity);
    
    public IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool descending = false,
        int? skip = null,
        int? take = null)
    {
        var query = DbSet.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = descending
                ? query.OrderByDescending(orderBy)
                : query.OrderBy(orderBy);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query;
    }
    
    private DbSet<TEntity> DbSet
        => db.Set<TEntity>();
}