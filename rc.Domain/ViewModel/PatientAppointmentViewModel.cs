using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain.ViewModel
{
    public class PatientAppointmentViewModel
    {
        public PatientAdmission PatientAdmission { get; set; }
        public PatientAppointment PatientAppointment { get; set; }
        public List<PatientAppointment> PatientAppointments { get; set; }
    }
}
