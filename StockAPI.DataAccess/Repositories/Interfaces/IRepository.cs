using System.Linq.Expressions;

namespace StockAPI.DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? FindOne(Expression<Func<T, bool>> expression);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Insert(T entity);
    void InsertRange(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
