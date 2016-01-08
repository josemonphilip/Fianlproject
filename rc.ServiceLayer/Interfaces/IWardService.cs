using rc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IWardService
    {
        IEnumerable<Ward> GetAllWardsForCustomer(int id);
        void CreateWard(Ward ward);
        Ward GetWardByID(int id, int custID);
        void UpdateWard(Ward ward);
    }
}
