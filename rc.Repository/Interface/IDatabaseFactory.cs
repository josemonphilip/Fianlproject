using rc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository.Interface
{
    public interface IDatabaseFactory 
    {
        rcContext Get();
    }
}
