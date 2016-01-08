using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rc.Repository.Interface;
using System.Data.Entity;
using rc.DAL;

namespace rc.Repository 
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal DbSet<T> dbSet;
        private rcContext dataContext;

        public BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        public rcContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public IQueryable<T> All
        {
            get { return dbSet.AsQueryable(); }
        }

        public IQueryable<T> AllIncluding(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
