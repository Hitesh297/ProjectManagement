using System.Linq.Expressions;

namespace ProjectManagement.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Update(T entity);
        //void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        //void RemoveRange(IEnumerable<T> entities);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}
