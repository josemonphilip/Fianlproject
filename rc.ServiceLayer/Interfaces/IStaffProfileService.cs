using rc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IStaffProfileService
    {
        List<StaffProfile> GetAllStaff(int id);
        void Create(StaffProfile staf);
    }
}
