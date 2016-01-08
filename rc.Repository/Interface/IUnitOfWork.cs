using rc.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository.Interface
{
    public interface IUnitOfWork:IDisposable 
    {
        void Save();
        rcContext DataContext { get; }
    }
}
