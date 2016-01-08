using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain.ViewModel
{
    public class EmployeeCreatViewModel
    {
        public StaffProfile StaffProfile { get; set; }
        public string Password { get; set; }
    }
    public class EmployeeDashboardViewModel
    {
        public List<PatientAppointment> PatientAppointments { get; set; }
        public List<PatientAdmission> Birthdays { get; set; }
    }
}
