using System.Linq.Expressions;

namespace SMHotelBookingApp.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Edit(T entity);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    T Get(int id);
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}

