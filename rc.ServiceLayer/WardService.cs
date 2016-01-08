using rc.Domain;
using rc.Repository.Interface;
using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public class WardService : IWardService
    {
        private IWardRepository _wards;
        private IUnitOfWork _uow;
        public WardService(IWardRepository wards, IUnitOfWork uow)
        {
            _wards = wards;
            _uow = uow;
        }
        public IEnumerable<Ward> GetAllWardsForCustomer(int id)
        {
            return _wards.SearchFor(w => w.CustomerID == id);
        }
        public void CreateWard(Ward ward)
        {
            _wards.Add(ward);
            _uow.Save();
        }
        public void UpdateWard(Ward ward)
        {
            _wards.Update(ward);
            _uow.Save();
        }
        public Ward GetWardByID(int id, int custID)
        {
            return _wards.SearchFor(w => w.WardID == id && w.CustomerID == custID).SingleOrDefault();
        }
    }
}
