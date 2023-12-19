using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace StockAPI.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    public Repository(DbContext context)
    {
        Context = context;
    }

    public void Insert(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void InsertRange(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        Context.Set<T>().Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Where(expression);
    }
    public T? FindOne(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().FirstOrDefault(expression);
    }

    public IEnumerable<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }

    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
    }
}
