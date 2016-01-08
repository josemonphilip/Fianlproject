using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain.ViewModel
{
    public class PatientViewModel
    {
        public PatientAdmission patientAdmission { get; set; }
        public List<CarePlan> CarePlans { get; set; }
        public List<PatientAppointment> PatientAppointments { get; set; }
    }
}
