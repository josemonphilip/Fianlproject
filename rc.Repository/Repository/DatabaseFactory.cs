using rc.DAL;
using rc.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository.Repository
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private rcContext dataContext;
        public rcContext Get()
        {
            return dataContext ?? (dataContext =new rcContext());
        }
        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
