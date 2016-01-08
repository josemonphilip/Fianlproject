using rc.Domain;
using rc.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository.Repository
{
    public class StaffProfileRepository : BaseRepository<StaffProfile>, IStaffProfileRepository
    {
        public StaffProfileRepository(IDatabaseFactory dbf)
            : base(dbf)
        {}
    }
}
