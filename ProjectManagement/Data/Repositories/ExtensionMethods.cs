using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagement.Data.Repositories
{
    public static class ExtensionMethods
    {

        public static IEnumerable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public static IEnumerable<T> IncludeMultiples<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
