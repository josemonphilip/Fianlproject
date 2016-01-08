using rc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository.Interface
{
    public interface IBaseRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Add(T entry);
        void Update(T entry);
        void Delete(int id);

        rcContext DataContext { get; }
    }
}
