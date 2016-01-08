using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rc.Repository.Interface;
using rc.DAL;
namespace rc.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private rcContext dataContext;
        private bool disposed = false;
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }
        public rcContext DataContext
        {
           get { return dataContext ?? (dataContext = _databaseFactory.Get()); }
        }
        public void Save()
        {
            DataContext.Commit();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
    }
}
