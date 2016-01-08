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
    public class StaffProfileService : IStaffProfileService
    {
        private IStaffProfileRepository _staffProfile;
        private readonly IUnitOfWork _unitOfWork;
        public StaffProfileService(IStaffProfileRepository staffProfile, IUnitOfWork unitOfWork)
        {
            _staffProfile = staffProfile;
            _unitOfWork=unitOfWork;
        }

        public List<StaffProfile> GetAllStaff(int id)
        {
            return _staffProfile.SearchFor(s => s.CustomerID == id).ToList();
        }
        public void Create(StaffProfile staf)
        {
            _staffProfile.Add(staf);
            _unitOfWork.Save();
        }
    }
}
