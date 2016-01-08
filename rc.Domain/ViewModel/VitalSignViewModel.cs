using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain.ViewModel
{
    public class VitalSignViewModel
    {
        public PatientAdmission PatientAdmission { get; set; }
        public PatientVitalSign PatientVitalSign { get; set; }
        public List<PatientVitalSign> PatientVitalSigns { get; set; }
    }
}
