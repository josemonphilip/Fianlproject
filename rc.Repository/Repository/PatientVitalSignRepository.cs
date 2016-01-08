using rc.Domain;
using rc.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository.Repository
{
    public class PatientVitalSignRepository : BaseRepository<PatientVitalSign>, IPatientVitalSignRepository
    {
        public PatientVitalSignRepository(IDatabaseFactory dbf)
            : base(dbf)
        { }
    }
}
