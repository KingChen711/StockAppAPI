using System.Linq.Expressions;

namespace DataAccessLayer.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? FindById(int id);
    T? FindOne(Expression<Func<T, bool>> expression);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Insert(T entity);
    void InsertRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
