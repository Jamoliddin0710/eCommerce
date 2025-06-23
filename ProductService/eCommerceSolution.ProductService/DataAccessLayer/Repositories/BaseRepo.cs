using System.Linq.Expressions;
using DataAccessLayer.RepositoryContracts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class BaseRepo<T>(AppDbContext context) : IBaseRepo<T> 
where T : BaseGuidEntity
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public Task<T> AddAsync(T entity)
    {
        context.Set<T>().AddAsync(entity:entity);
        context.SaveChangesAsync();
        return Task.FromResult(entity);
    }
    
    public void AddRange(IEnumerable<T> entities)
    {
        context.Set<T>().AddRange(entities);
        context.SaveChanges();
    }

    public void Update(T source, T destination)
    {
        context.Set<T>().Entry(source).CurrentValues.SetValues(destination);
    }

    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
        context.SaveChanges();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        IQueryable<T> query = context.Set<T>().AsQueryable().Where(predicate);
        return await query.AnyAsync();
    }

    public async Task<T> GetByIdAsync(Guid Id, string includeProperties = null)
    {
        IQueryable<T> query = context.Set<T>().AsQueryable();
        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            query = GetQueryWithIncludeProperties(query, includeProperties);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == Id);
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includeProperties = null)
    {
        IQueryable<T> query = context.Set<T>().AsQueryable();
        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            query = GetQueryWithIncludeProperties(query, includeProperties);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    private static IQueryable<T> GetQueryWithIncludeProperties(IQueryable<T> query, string includeProperties)
    {
        var props = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach (var prop in props)
        {
            query = query.Include(prop.Trim());
        }

        return query;
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
        string includeProperties = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var query = context.Set<T>().AsQueryable();
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            query = GetQueryWithIncludeProperties(query, includeProperties);
        }

        return await query.ToListAsync();
    }

    public IQueryable<T> GetAllQuerable(Expression<Func<T, bool>> predicate = null, string includeProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var query = context.Set<T>().AsQueryable();
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            query = GetQueryWithIncludeProperties(query, includeProperties);
        }

        return query;
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        IQueryable<T> query = context.Set<T>().AsQueryable().Where(predicate);
        return query.CountAsync();
    }
}