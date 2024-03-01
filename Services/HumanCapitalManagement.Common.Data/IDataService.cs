﻿using System.Linq.Expressions;

namespace HumanCapitalManagement.Common.Data;

public interface IDataService<TEntity>
    where TEntity: class
{
    Task SaveChanges();

    Task Add(TEntity entity);
    
    void Update(TEntity entity);

    void Delete(TEntity entity);
    
    IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool descending = false,
        int? skip = null,
        int? take = null);
}